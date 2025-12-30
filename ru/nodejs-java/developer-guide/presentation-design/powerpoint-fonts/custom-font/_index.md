---
title: Настройка шрифтов PowerPoint в JavaScript
linktitle: Пользовательский шрифт
type: docs
weight: 20
url: /ru/nodejs-java/custom-font/
keywords:
- шрифт
- пользовательский шрифт
- внешний шрифт
- загрузка шрифта
- управление шрифтами
- папка шрифтов
- PowerPoint
- OpenDocument
- презентация
- Node.js
- JavaScript
- Aspose.Slides
description: "Настройте шрифты в слайдах PowerPoint с помощью JavaScript и Aspose.Slides для Node.js через Java, чтобы ваши презентации оставались чёткими и согласованными на любом устройстве."
---

{{% alert color="primary" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью метода [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Шрифты TrueType (.ttf) и коллекции TrueType (.ttc). См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Шрифты OpenType (.otf). См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на вывод при экспорте — например PDF, изображения и другие поддерживаемые форматы — так что получаемые документы выглядят одинаково в разных средах. Шрифты загружаются из пользовательских каталогов.

1. Укажите одну или несколько папок, содержащих файлы шрифтов.  
2. Вызовите статический метод [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) для загрузки шрифтов из этих папок.  
3. Загрузите и отрендерите/экспортируйте презентацию.  
4. Вызовите [FontsLoader.clearCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/clearcache/) для очистки кэша шрифтов.

Ниже приведён пример кода, демонстрирующий процесс загрузки шрифтов:
```js
// Определите папки, содержащие пользовательские файлы шрифтов.
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Загрузите пользовательские шрифты из указанных папок.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Выполните рендеринг/экспорт презентации (например, в PDF, изображения или другие форматы), используя загруженные шрифты.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Очистите кэш шрифтов после завершения работы.
    aspose.slides.FontsLoader.clearCache();
}
```


{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) добавляет дополнительные папки в пути поиска шрифтов, но не изменяет порядок инициализации шрифтов.  
Шрифты инициализируются в следующем порядке:

1. Путь к шрифтам по умолчанию операционной системы.  
1. Путья, загруженные через [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Get Custom Fonts Folder**
Aspose.Slides предоставляет метод [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) для поиска папок шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, а также системные папки шрифтов.

Ниже JavaScript‑код, показывающий, как использовать [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):
```javascript
// Эта строка выводит папки, где ищутся файлы шрифтов.
// Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```


## **Specify Custom Fonts Used With Presentation**
Aspose.Slides предоставляет свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) для указания внешних шрифтов, которые будут использоваться в презентации.

Ниже JavaScript‑код, демонстрирующий использование свойства [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):
```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Работа с презентацией
    // CustomFont1, CustomFont2 и шрифты из папок assets\fonts и global\fonts и их подпапок доступны для презентации
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Manage Fonts Externally**

Aspose.Slides предоставляет метод [loadExternalFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) для загрузки внешних шрифтов из бинарных данных.

Ниже JavaScript‑код, показывающий процесс загрузки шрифта из массива байтов:
```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // внешний шрифт, загруженный во время жизни презентации
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

Нет. Регистрация шрифта для рендеринга не равна его встраиванию в PPTX. Если нужен шрифт внутри файла презентации, используйте явные [возможности встраивания](/slides/ru/nodejs-java/embedded-font/).

**Можно ли управлять поведением fallback, когда у пользовательского шрифта отсутствуют некоторые глифы?**

Да. Настройте [замену шрифтов](/slides/ru/nodejs-java/font-substitution/), [правила замены](/slides/ru/nodejs-java/font-replacement/) и [наборы fallback](/slides/ru/nodejs-java/fallback-font/), чтобы точно определить, какой шрифт использовать при отсутствии требуемого глифа.

**Можно ли использовать шрифты в контейнерах Linux/Docker без их установки в системе?**

Да. Указывайте собственные папки со шрифтами или загружайте шрифты из массивов байтов. Это устраняет зависимость от системных каталогов шрифтов в образе контейнера.

**А что с лицензированием — можно ли встраивать любой пользовательский шрифт без ограничений?**

Вы несёте ответственность за соблюдение лицензий шрифтов. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.