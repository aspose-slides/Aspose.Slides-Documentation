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
- каталог шрифтов
- PowerPoint
- OpenDocument
- презентация
- Java
- Aspose.Slides
description: "Настройте шрифты в слайдах PowerPoint с помощью Aspose.Slides для Java, чтобы ваши презентации оставались чёткими и согласованными на любом устройстве."
---

{{% alert color="primary" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью метода [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Шрифты TrueType (.ttf) и коллекции TrueType (.ttc). См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Шрифты OpenType (.otf). См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, которые используются при рендеринге презентаций, без необходимости их установки. Шрифты загружаются из пользовательского каталога. 

1. Создайте экземпляр класса [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) и вызовите метод [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. Загрузите презентацию, которую нужно отобразить.
3. [Очистите кэш](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader#clearCache--) в классе [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader).

Этот код Java демонстрирует процесс загрузки шрифтов:
```java
// Папки для поиска шрифтов
String[] folders = new String[] { externalFontsDir };

// Загружает шрифты из пользовательского каталога
FontsLoader.loadExternalFonts(folders);

// Выполняем некоторые действия и рендерим презентацию/слайды
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // Очищает кэш шрифтов
    FontsLoader.clearCache();
}
```


## **Получить пользовательские папки шрифтов**
Aspose.Slides предоставляет метод [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) , позволяющий находить каталоги шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, а также системные каталоги шрифтов.

Этот код Java показывает, как использовать [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--):
```java
// Эта строка выводит папки, где ищутся файлы шрифтов.
// Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
String[] fontFolders = FontsLoader.getFontFolders();
```


## **Указание пользовательских шрифтов, используемых в презентации**
Aspose.Slides предоставляет свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) , позволяющее указывать внешние шрифты, которые будут использоваться в презентации. 

Этот код Java демонстрирует, как использовать свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):
```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Работайте с презентацией
    // CustomFont1, CustomFont2 и шрифты из папок assets\fonts & global\fonts и их подпапок доступны в презентации
} finally {
    if (pres != null) pres.dispose();
}
```


## **Внешнее управление шрифтами**

Aspose.Slides предоставляет метод [loadExternalFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data), позволяющий загружать внешние шрифты из бинарных данных.

Этот код Java демонстрирует процесс загрузки шрифта из массива байтов:
```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // внешний шрифт загружен в течение срока жизни презентации
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```


## **Часто задаваемые вопросы**

**Влияют ли пользовательские шрифты на экспорт во все форматы (PDF, PNG, SVG, HTML)?**

Да. Подключённые шрифты используются рендерером при экспорте во все форматы.

**Автоматически ли пользовательские шрифты встраиваются в получающийся PPTX?**

Нет. Регистрация шрифта для рендеринга не равна его встраиванию в PPTX. Если необходимо, чтобы шрифт был включён в файл презентации, следует использовать явные [возможности встраивания](/slides/ru/java/embedded-font/).

**Могу ли я управлять поведением резервного шрифта, когда пользовательский шрифт не содержит определённых глифов?**

Да. Настройте [замещение шрифтов](/slides/ru/java/font-substitution/), [правила замены](/slides/ru/java/font-replacement/) и [наборы резервных шрифтов](/slides/ru/java/fallback-font/), чтобы точно указать, какой шрифт использовать, если запрашиваемый глиф отсутствует.

**Можно ли использовать шрифты в контейнерах Linux/Docker без их системной установки?**

Да. Укажите собственные каталоги шрифтов или загружайте шрифты из массивов байтов. Это устраняет любую зависимость от системных каталогов шрифтов в образе контейнера.

**Как насчёт лицензирования — могу ли я встраивать любой пользовательский шрифт без ограничений?**

Вы отвечаете за соблюдение условий лицензирования шрифтов. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда изучайте договор EULA шрифта перед распространением результатов.