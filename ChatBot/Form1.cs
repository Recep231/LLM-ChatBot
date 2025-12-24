using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace ChatBot
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        // Mesaj kutusunda Enter'a basınca gönderme
        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // satır atlamasını engelle
                btnSend.PerformClick();
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
                return;

            string userMessage = txtMessage.Text;

            txtChat.AppendText("Sen: " + userMessage + Environment.NewLine);
            txtMessage.Clear();

            btnSend.Enabled = false;

            try
            {
                string response = await GetChatResponse(userMessage);
                txtChat.AppendText("Bot: " + response + Environment.NewLine + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSend.Enabled = true;
            }
        }

        private async System.Threading.Tasks.Task<string> GetChatResponse(string userMessage)
        {
            // BURADA SADECE DEĞİŞKENİ KULLANIYORUZ, DEĞERİNE DOKUNMA
            string apiKey = "AIzaSyBBVg7ZtbPsd5VHmR7lepccIRX0AyZ_OO4";

            // Güncel Gemini REST API endpoint (flash-001, v1)
            string url = $"https://generativelanguage.googleapis.com/v1/models/gemini-2.5-flash:generateContent?key={apiKey}";

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = userMessage }
                        }
                    }
                }
            };

            string json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();

            HttpResponseMessage response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                string errorBody = await response.Content.ReadAsStringAsync();
                throw new Exception($"API hatası ({(int)response.StatusCode}): {errorBody}");
            }

            string responseJson = await response.Content.ReadAsStringAsync();

            try
            {
                using (JsonDocument doc = JsonDocument.Parse(responseJson))
                {
                    JsonElement root = doc.RootElement;

                    if (!root.TryGetProperty("candidates", out JsonElement candidates) ||
                        candidates.GetArrayLength() == 0)
                    {
                        return "Üzgünüm, modelden geçerli bir cevap alamadım.";
                    }

                    JsonElement contentElement = candidates[0].GetProperty("content");

                    if (!contentElement.TryGetProperty("parts", out JsonElement parts) ||
                        parts.GetArrayLength() == 0)
                    {
                        return "Üzgünüm, model cevabını okuyamadım.";
                    }

                    var sb = new StringBuilder();
                    foreach (var part in parts.EnumerateArray())
                    {
                        if (part.TryGetProperty("text", out JsonElement textEl) &&
                            textEl.ValueKind == JsonValueKind.String)
                        {
                            sb.Append(textEl.GetString());
                        }
                    }

                    if (sb.Length == 0)
                    {
                        return "Üzgünüm, model cevabını okuyamadım.";
                    }

                    return sb.ToString();
                }
            }
            catch (JsonException je)
            {
                throw new Exception("API cevabı beklenen formatta değil: " + je.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
