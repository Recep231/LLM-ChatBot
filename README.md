# 🤖 LLM ChatBot

Windows Forms tabanlı, Gemini API kullanan modern bir chatbot uygulaması.

## ✨ Özellikler

- 💬 Gemini AI ile gerçek zamanlı sohbet
- ⌨️ Enter tuşu ile hızlı mesaj gönderme
- 🎨 Modern ve kullanıcı dostu Windows Forms arayüzü
- 🔒 Güvenli API key yönetimi
- ⚡ Async/await ile performanslı işlemler
- 🛡️ Hata yönetimi ve kullanıcı bildirimleri

## 🚀 Kurulum

### Gereksinimler

- Windows 10/11
- Visual Studio 2019 veya üzeri
- .NET Framework 4.6.2 veya üzeri
- Gemini API Key ([Google AI Studio](https://makersuite.google.com/app/apikey)'dan alabilirsiniz)

### Adımlar

1. **Repository'yi klonlayın:**
   ```bash
   git clone https://github.com/Recep231/LLM-ChatBot.git
   cd LLM-ChatBot
   ```

2. **Visual Studio'da açın:**
   - `ChatBot.sln` dosyasını Visual Studio ile açın

3. **API Key'i ekleyin:**
   - `ChatBot/Form1.cs` dosyasını açın
   - 58. satırdaki `apiKey` değişkenine kendi Gemini API key'inizi ekleyin:
   ```csharp
   string apiKey = "BURAYA_KENDI_API_KEY_INIZI_YAZIN";
   ```

4. **Projeyi derleyin ve çalıştırın:**
   - `F5` tuşuna basın veya `Build > Build Solution` menüsünden derleyin

## 📖 Kullanım

1. Uygulamayı başlatın
2. Alt kısımdaki metin kutusuna mesajınızı yazın
3. **Enter** tuşuna basın veya **Gönder** butonuna tıklayın
4. Bot'un cevabını bekleyin

## 🔑 API Key Nasıl Alınır?

1. [Google AI Studio](https://makersuite.google.com/app/apikey) adresine gidin
2. Google hesabınızla giriş yapın
3. **Create API Key** butonuna tıklayın
4. Oluşturulan API key'i kopyalayın
5. `Form1.cs` dosyasındaki `apiKey` değişkenine yapıştırın

## 🛠️ Teknolojiler

- **C#** - Programlama dili
- **Windows Forms** - UI Framework
- **.NET Framework 4.6.2** - Framework
- **System.Net.Http** - HTTP istekleri
- **System.Text.Json** - JSON işlemleri
- **Gemini API** - AI modeli

## 📁 Proje Yapısı

```
ChatBot/
├── ChatBot/
│   ├── Form1.cs              # Ana form ve chatbot mantığı
│   ├── Form1.Designer.cs     # Form tasarımı
│   ├── Program.cs             # Uygulama giriş noktası
│   └── Properties/            # Proje özellikleri
├── packages/                  # NuGet paketleri
└── ChatBot.sln                # Visual Studio solution dosyası
```

## ⚠️ Önemli Notlar

- API key'inizi **asla** GitHub'a yüklemeyin! (Bu repo'da örnek olarak gösterilmiştir)
- API key'inizi güvenli bir yerde saklayın
- Gemini API'nin ücretsiz kullanım limitleri vardır, aşırı kullanımda ücretlendirme uygulanabilir
- İnternet bağlantısı gereklidir

## 🐛 Sorun Giderme

### "API hatası (404)" hatası alıyorsanız:
- API key'inizin doğru olduğundan emin olun
- Gemini API'nin aktif olduğunu kontrol edin

### "insufficient_quota" hatası alıyorsanız:
- Google AI Studio'da hesabınızın limitlerini kontrol edin
- Gerekirse yeni bir API key oluşturun

### Designer hatası alıyorsanız:
- Visual Studio'yu kapatıp tekrar açın
- `bin` ve `obj` klasörlerini silip projeyi yeniden derleyin

## 📝 Lisans

Bu proje açık kaynak kodludur ve özgürce kullanılabilir.

## 👤 Geliştirici

**Recep231**
- GitHub: [@Recep231](https://github.com/Recep231)

## 🙏 Katkıda Bulunma

Pull request'ler memnuniyetle karşılanır! Büyük değişiklikler için lütfen önce bir issue açarak neyi değiştirmek istediğinizi tartışın.

## 📞 İletişim

Sorularınız için GitHub Issues kullanabilirsiniz.

---

⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!

