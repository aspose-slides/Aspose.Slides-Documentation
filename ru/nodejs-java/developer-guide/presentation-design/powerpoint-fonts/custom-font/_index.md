---
title: Пользовательский шрифт PowerPoint на JavaScript
linktitle: Пользовательский шрифт
type: docs
weight: 20
url: /ru/nodejs-java/custom-font/
keywords: "Шрифты, пользовательские шрифты, презентация PowerPoint, Java, Aspose.Slides для Node.js через Java"
description: "Пользовательские шрифты PowerPoint в JavaScript"
---

{{% alert color="primary" %}} 

Aspose Slides позволяет вам загружать эти шрифты с помощью метода [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) и TrueType Collection (.ttc) шрифты. См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) шрифты. См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides позволяет вам загружать шрифты, которые будут использоваться в презентациях, без их установки. Шрифты загружаются из пользовательского каталога. 

1. Создайте экземпляр класса [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/) и вызовите метод [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. Загрузите презентацию, которая будет отрисована.
3. [Очистите кэш](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsLoader#clearCache--) в классе [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsLoader).

Этот JavaScript код демонстрирует процесс загрузки шрифтов:
```javascript
// Папки для поиска шрифтов
var folders = java.newArray("java.lang.String", [externalFontsDir]);
// Загружает шрифты из пользовательского каталога шрифтов
aspose.slides.FontsLoader.loadExternalFonts(folders);
// Выполняет работу и рендеринг презентации/слайда
var pres = new aspose.slides.Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
    // Очищает кеш шрифтов
    aspose.slides.FontsLoader.clearCache();
}
```


## **Get Custom Fonts Folder**
Aspose.Slides предоставляет метод [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) для поиска папок со шрифтами. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, а также системные папки шрифтов.

Этот JavaScript код показывает, как использовать [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):
```javascript
// Эта строка выводит папки, в которых ищутся файлы шрифтов.
// Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```


## **Specify Custom Fonts Used With Presentation**
Aspose.Slides предоставляет свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) для указания внешних шрифтов, которые будут использоваться в презентации.

Этот JavaScript код показывает, как использовать свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):
```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Работа с презентацией
    // CustomFont1, CustomFont2 и шрифты из папок assets\fonts & global\fonts, а также их подпапок, доступны в презентации
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Manage Fonts Externally**

Aspose.Slides предоставляет метод [loadExternalFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) для загрузки внешних шрифтов из бинарных данных.

Этот JavaScript код демонстрирует процесс загрузки шрифта из массива байтов:
```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // внешний шрифт загружен в течение срока жизни презентации
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```


## **FAQ**

**Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?**

Да. Подключённые шрифты используются рендерером во всех форматах экспорта.

**Автоматически ли пользовательские шрифты встраиваются в полученный PPTX?**

Нет. Регистрация шрифта для рендеринга не то же самое, что его встраивание в PPTX. Если нужно, чтобы шрифт был включён в файл презентации, необходимо использовать явные функции [embedding features](/slides/ru/nodejs-java/embedded-font/).

**Могу ли я управлять поведением fallback, когда у пользовательского шрифта отсутствуют определённые глифы?**

Да. Настройте [font substitution](/slides/ru/nodejs-java/font-substitution/), [replacement rules](/slides/ru/nodejs-java/font-replacement/) и [fallback sets](/slides/ru/nodejs-java/fallback-font/), чтобы точно определить, какой шрифт использовать, когда запрашиваемый глиф отсутствует.

**Могу ли я использовать шрифты в контейнерах Linux/Docker без их установки в системе?**

Да. Указывайте свои папки со шрифтами или загружайте шрифты из массивов байтов. Это устраняет зависимость от системных каталогов шрифтов в образе контейнера.

**А как насчёт лицензирования — могу ли я встраивать любой пользовательский шрифт без ограничений?**

Вы отвечаете за соблюдение лицензий на шрифты. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.