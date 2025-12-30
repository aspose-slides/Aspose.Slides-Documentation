---
title: Настройка шрифтов PowerPoint на Android
linktitle: Пользовательский шрифт
type: docs
weight: 20
url: /ru/androidjava/custom-font/
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
- Android
- Java
- Aspose.Slides
description: "Настройте шрифты в слайдах PowerPoint с помощью Aspose.Slides для Android на Java, чтобы ваши презентации были чёткими и согласованными на любом устройстве."
---

{{% alert color="primary" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью метода [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Шрифты TrueType (.ttf) и TrueType Collection (.ttc). См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Шрифты OpenType (.otf). См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, используемые в презентации, без их установки в системе. Это влияет на вывод при экспорте — например PDF, изображения и другие поддерживаемые форматы — так что получающиеся документы выглядят одинаково в разных средах. Шрифты загружаются из пользовательских каталогов.

1. Укажите один или несколько каталогов, содержащих файлы шрифтов.
2. Вызовите статический метод [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---), чтобы загрузить шрифты из этих каталогов.
3. Загрузите и отрендерите/экспортируйте презентацию.
4. Вызовите [FontsLoader.clearCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader#clearCache--) , чтобы очистить кэш шрифтов.

Следующий пример кода демонстрирует процесс загрузки шрифтов:
```java
// Определите папки, содержащие пользовательские файлы шрифтов.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Загрузите пользовательские шрифты из указанных папок.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Отобразите/экспортируйте презентацию (например, в PDF, изображения или другие форматы), используя загруженные шрифты.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Очистите кэш шрифтов после завершения работы.
    FontsLoader.clearCache();
}
```


{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) добавляет дополнительные каталоги в пути поиска шрифтов, но не изменяет порядок инициализации шрифтов.
Шрифты инициализируются в следующем порядке:

1. Путь к шрифтам по умолчанию операционной системы.
1. Пути, загруженные через [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Получить пользовательские каталоги шрифтов**
Aspose.Slides предоставляет метод [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) , позволяющий находить каталоги шрифтов. Этот метод возвращает каталоги, добавленные через метод `LoadExternalFonts`, а также системные каталоги шрифтов.

Этот код Java показывает, как использовать [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):
```java
// Эта строка выводит папки, где ищутся файлы шрифтов.
// Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
String[] fontFolders = FontsLoader.getFontFolders();
```


## **Указать пользовательские шрифты, используемые в презентации**
Aspose.Slides предоставляет свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) , позволяющее указывать внешние шрифты, которые будут использоваться в презентации.

Этот код Java показывает, как использовать свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):
```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Работайте с презентацией
    // CustomFont1, CustomFont2 и шрифты из папок assets\fonts & global\fonts и их подпапок доступны для презентации
} finally {
    if (pres != null) pres.dispose();
}
```


## **Управление шрифтами извне**

Aspose.Slides предоставляет метод [loadExternalFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data), позволяющий загружать внешние шрифты из бинарных данных.

Этот код Java демонстрирует процесс загрузки шрифта из массива байтов:
```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // внешний шрифт загружен на протяжении времени жизни презентации
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

**Автоматически ли пользовательские шрифты встраиваются в полученный PPTX?**

Нет. Регистрация шрифта для рендеринга не равна его встраиванию в PPTX. Если требуется, чтобы шрифт был включён в файл презентации, необходимо использовать явные [возможности встраивания](/slides/ru/androidjava/embedded-font/).

**Могу ли я управлять поведением резервного шрифта, если пользовательский шрифт не содержит определённые глифы?**

Да. Настройте [замену шрифтов](/slides/ru/androidjava/font-substitution/), [правила замены](/slides/ru/androidjava/font-replacement/) и [наборы резервных шрифтов](/slides/ru/androidjava/fallback-font/), чтобы точно указать, какой шрифт использовать, если запрашиваемый глиф отсутствует.

**Могу ли я использовать шрифты в контейнерах Linux/Docker без их системной установки?**

Да. Укажите собственные каталоги шрифтов или загружайте шрифты из массивов байтов. Это устраняет любую зависимость от системных каталогов шрифтов в образе контейнера.

**Что касается лицензирования — могу ли я встраивать любой пользовательский шрифт без ограничений?**

Вы отвечаете за соблюдение лицензий шрифтов. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте пользовательское соглашение (EULA) шрифта перед распространением результатов.