---
title: "Настройка шрифтов PowerPoint в JavaScript"
linktitle: "Пользовательский шрифт"
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
description: "Настройте шрифты в слайдах PowerPoint с помощью JavaScript и Aspose.Slides для Node.js через Java, чтобы ваши презентации были четкими и согласованными на любом устройстве."
---
## **Обзор**

Aspose.Slides позволяет использовать пользовательские шрифты в презентациях без их установки в операционную систему. Вы можете загружать шрифты из пользовательских папок, предоставлять шрифты для конкретной презентации через источники шрифтов уровня документа или загружать внешние шрифты напрямую из бинарных данных.

Загруженные шрифты используются при рендеринге или экспорте презентации, например в PDF, изображения и другие поддерживаемые форматы. Это помогает сохранять вывод презентации одинаковым в разных средах. В статье также объясняется, как просматривать папки шрифтов, используемые Aspose.Slides, и как очистить кэш шрифтов после работы с внешними шрифтами.

Регистрация пользовательских шрифтов для рендеринга отличается от внедрения шрифтов в файл PPTX. Если шрифт необходимо хранить внутри самой презентации, используйте функции встраивания шрифтов явно.

Тема презентации может ссылаться на разные семейства шрифтов для отдельных систем письма. Эти сопоставления хранят имена шрифтов, но не устанавливают и не загружают файлы шрифтов. См. [Шрифты темы, специфичные для скрипта](/slides/ru/nodejs-java/script-specific-font-mappings/) для управления сопоставлениями и используйте параметры загрузки ниже, чтобы сделать указанные шрифты доступными для согласованного рендеринга.

{{% alert color="info" title="Note" %}}
Aspose Slides позволяет загружать эти шрифты с помощью метода [loadExternalFonts](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) и TrueType Collection (.ttc) шрифты. Смотрите [TrueType](https://en.wikipedia.org/wiki/TrueType).
* OpenType (.otf) шрифты. Смотрите [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на вывод при экспорте — например, PDF, изображения и другие поддерживаемые форматы — чтобы полученные документы выглядели одинаково в разных средах. Шрифты загружаются из пользовательских каталогов.

1. Укажите одну или несколько папок, содержащих файлы шрифтов.
2. Вызовите статический метод [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) для загрузки шрифтов из этих папок.
3. Загрузите и отрендерьте/экспортируйте презентацию.
4. Вызовите [FontsLoader.clearCache](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsloader/clearcache/) для очистки кэша шрифтов.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Определите папки, содержащие пользовательские файлы шрифтов.
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Загрузите пользовательские шрифты из указанных папок.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Отрендерите/экспортируйте презентацию (например, в PDF, изображения или другие форматы), используя загруженные шрифты.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Очистите кэш шрифтов после завершения работы.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) добавляет дополнительные папки в пути поиска шрифтов, но не изменяет порядок инициализации шрифтов.  
Шрифты инициализируются в следующем порядке:

1. Путь к шрифтам по умолчанию операционной системы.
2. Путь, загруженный через [FontsLoader](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Получить папку пользовательских шрифтов**

Aspose.Slides предоставляет метод [getFontFolders](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) для поиска папок шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, а также системные папки шрифтов.

Следующий код JavaScript показывает, как использовать [getFontFolders](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Эта строка выводит папки, в которых осуществляется поиск файлов шрифтов.
// Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Указать пользовательские шрифты, используемые в презентации**

Aspose.Slides предоставляет свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) для указания внешних шрифтов, которые будут использоваться в презентации.

Следующий код JavaScript показывает, как использовать свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Работа с презентацией
    // CustomFont1, CustomFont2 и шрифты из папок assets\fonts & global\fonts и их подпапок доступны для презентации
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Управление шрифтами внешне**

Aspose.Slides предоставляет метод [loadExternalFont](https://reference.aspose.com/slides/ru/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) для загрузки внешних шрифтов из бинарных данных.

Следующий код JavaScript демонстрирует процесс загрузки шрифта из массива байтов:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

### Пользовательские шрифты влияют на экспорт во все форматы (PDF, PNG, SVG, HTML)?

Да. Подключенные шрифты используются рендерером во всех форматах экспорта.

### Автоматически ли пользовательские шрифты встраиваются в полученный PPTX?

Нет. Регистрация шрифта для рендеринга не равна его встраиванию в PPTX. Если нужен шрифт внутри файла презентации, используйте явные [функции встраивания](/slides/ru/nodejs-java/embedded-font/).

### Можно ли контролировать поведение fallback, когда у пользовательского шрифта отсутствуют некоторые глифы?

Да. Настройте [замену шрифтов](/slides/ru/nodejs-java/font-substitution/), [правила замены](/slides/ru/nodejs-java/font-replacement/) и [наборы fallback](/slides/ru/nodejs-java/fallback-font/), чтобы точно определить, какой шрифт использовать при отсутствии запрашиваемого глифа.

### Можно ли использовать шрифты в контейнерах Linux/Docker без их установки в системе?

Да. Указывайте свои папки шрифтов или загружайте шрифты из массивов байтов. Это устраняет зависимости от системных каталогов шрифтов в образе контейнера.

### Что насчёт лицензий — могу ли я встраивать любой пользовательский шрифт без ограничений?

Вы несёте ответственность за соблюдение лицензий шрифтов. Условия могут различаться; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.