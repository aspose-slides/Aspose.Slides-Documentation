---
title: Настройка шрифтов PowerPoint в Java
linktitle: Пользовательский шрифт
type: docs
weight: 20
url: /ru/java/custom-font/
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
- Java
- Aspose.Slides
description: "Настройте шрифты в слайдах PowerPoint с помощью Aspose.Slides для Java, чтобы ваши презентации оставались чёткими и согласованными на любом устройстве."
---

{{% alert color="primary" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью метода [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* TrueType (.ttf) и TrueType Collection (.ttc) шрифты. См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) шрифты. См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на экспорт — например, PDF, изображения и другие поддерживаемые форматы — поэтому получающиеся документы выглядят одинаково в разных средах. Шрифты загружаются из пользовательских каталогов.

1. Укажите один или несколько каталогов, содержащих файлы шрифтов.
2. Вызовите статический метод [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) для загрузки шрифтов из этих каталогов.
3. Загрузите и отрендерите/экспортируйте презентацию.
4. Вызовите [FontsLoader.clearCache](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader#clearCache--) для очистки кеша шрифтов.

Ниже приведён пример кода, демонстрирующий процесс загрузки шрифтов:
```java
// Определите папки, содержащие файлы пользовательских шрифтов.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Загрузите пользовательские шрифты из указанных папок.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Выполните рендеринг/экспорт презентации (например, в PDF, изображения или другие форматы) с использованием загруженных шрифтов.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Очистите кэш шрифтов после завершения работы.
    FontsLoader.clearCache();
}
```


{{% alert color="info" title="Примечание" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) добавляет дополнительные каталоги в пути поиска шрифтов, но не изменяет порядок инициализации шрифтов. Шрифты инициализируются в следующем порядке:

1. Путь к шрифтам по умолчанию в операционной системе.
1. Пути, загруженные через [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Get Custom Font Folders**
Aspose.Slides предоставляет метод [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) для получения каталогов шрифтов. Этот метод возвращает каталоги, добавленные через метод `LoadExternalFonts`, а также системные каталоги шрифтов.

В этом примере Java показано, как использовать [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--):
```java
// Эта строка выводит папки, где ищутся файлы шрифтов.
// Это папки, добавленные через метод LoadExternalFonts и системные папки шрифтов.
String[] fontFolders = FontsLoader.getFontFolders();
```


## **Specify Custom Fonts Used with a Presentation**
Aspose.Slides предоставляет свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) для указания внешних шрифтов, которые будут использоваться с презентацией. 

В этом примере Java показано, как использовать свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):
```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Работа с презентацией
    // CustomFont1, CustomFont2 и шрифты из папок assets\fonts & global\fonts и их подпапок доступны для презентации
} finally {
    if (pres != null) pres.dispose();
}
```


## **Manage Fonts Externally**

Aspose.Slides предоставляет метод [loadExternalFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) для загрузки внешних шрифтов из бинарных данных.

В этом примере Java демонстрируется процесс загрузки шрифта из массива байтов:
```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // внешний шрифт загружен в течение жизни презентации
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```


## **FAQ**

**Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?**

Да. Подключённые шрифты используются рендерером во всех форматах экспорта.

**Встраиваются ли пользовательские шрифты автоматически в получаемый PPTX?**

Нет. Регистрация шрифта для рендеринга не то же самое, что его встраивание в PPTX. Если нужен шрифт внутри файла презентации, следует использовать явные возможности [встраивания](/slides/ru/java/embedded-font/).

**Можно ли управлять поведением fallback, когда у пользовательского шрифта отсутствуют отдельные глифы?**

Да. Настройте [замену шрифтов](/slides/ru/java/font-substitution/), [правила замены](/slides/ru/java/font-replacement/) и [наборы fallback](/slides/ru/java/fallback-font/), чтобы точно определить, какой шрифт использовать при отсутствии требуемого глифа.

**Можно ли использовать шрифты в контейнерах Linux/Docker без их установки в системе?**

Да. Укажите свои каталоги шрифтов или загрузите шрифты из массивов байтов. Это устраняет любую зависимость от системных каталогов шрифтов в образе контейнера.

**Что касается лицензирования — могу ли я встраивать любой пользовательский шрифт без ограничений?**

Вы несёте ответственность за соблюдение лицензий на шрифты. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте EULA шрифта перед распространением результатов.