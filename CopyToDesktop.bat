@echo off
echo ChatBot'u masaustune kopyaliyorum...
echo.

set SOURCE_DIR=ChatBot\bin\Debug
set DEST_DIR=%USERPROFILE%\Desktop\ChatBot

if not exist "%SOURCE_DIR%" (
    echo HATA: %SOURCE_DIR% klasoru bulunamadi!
    echo Lutfen once projeyi Visual Studio'da derleyin (Build > Build Solution)
    pause
    exit /b 1
)

if exist "%DEST_DIR%" (
    echo Eski klasor siliniyor...
    rmdir /s /q "%DEST_DIR%"
)

echo Klasor olusturuluyor...
mkdir "%DEST_DIR%"

echo Dosyalar kopyalaniyor...
xcopy /E /I /Y "%SOURCE_DIR%\*" "%DEST_DIR%\"

echo.
echo Tamamlandi! ChatBot masaustunde %DEST_DIR% klasorunde.
echo.
pause

