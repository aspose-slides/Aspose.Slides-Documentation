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
description: "Настраивайте шрифты в слайдах PowerPoint с помощью Aspose.Slides для Android на Java, чтобы ваши презентации выглядели чётко и одинаково на любом устройстве."
---

{{% alert color="primary" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью метода [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Шрифты TrueType (.ttf) и TrueType Collection (.ttc). См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Шрифты OpenType (.otf). См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузить пользовательские шрифты**

Aspose.Slides позволяет загружать шрифты, которые используются при рендеринге презентаций, без необходимости их установки. Шрифты загружаются из пользовательского каталога. 

1. Создайте экземпляр класса [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/) и вызовите метод [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. Загрузите презентацию, которую необходимо отобразить.
3. [Очистить кэш](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader#clearCache--) в классе [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader).

```java
// Папки для поиска шрифтов
String[] folders = new String[] { externalFontsDir };

// Загружает шрифты из пользовательского каталога шрифтов
FontsLoader.loadExternalFonts(folders);

// Выполнить некоторые действия и рендеринг презентации/слайда
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // Очищает кеш шрифтов
    FontsLoader.clearCache();
}
```


## **Получить пользовательские папки шрифтов**

Aspose.Slides предоставляет метод [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) для поиска папок шрифтов. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, а также системные папки шрифтов.

```java
// Эта строка выводит папки, где ищутся файлы шрифтов.
// Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
String[] fontFolders = FontsLoader.getFontFolders();
```


## **Указание пользовательских шрифтов, используемых в презентации**

Aspose.Slides предоставляет свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) для указания внешних шрифтов, которые будут использоваться в презентации.

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Работа с презентацией
    // CustomFont1, CustomFont2 и шрифты из папок assets/fonts и global/fonts и их подпапок доступны для презентации
} finally {
    if (pres != null) pres.dispose();
}
```


## **Управление шрифтами извне**

Aspose.Slides предоставляет метод [loadExternalFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) для загрузки внешних шрифтов из бинарных данных.

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // внешний шрифт, загруженный во время жизни презентации
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

Да. Связанные шрифты используются рендерером во всех форматах экспорта.

**Встраиваются ли пользовательские шрифты автоматически в полученный PPTX?**

Нет. Регистрация шрифта для рендеринга не то же самое, что его встраивание в PPTX. Если требуется, чтобы шрифт был включён в файл презентации, необходимо использовать явные [функции встраивания](/slides/ru/androidjava/embedded-font/).

**Могу ли я контролировать поведение fallback, когда у пользовательского шрифта отсутствуют отдельные глифы?**

Да. Настройте [замену шрифтов](/slides/ru/androidjava/font-substitution/), [правила замены](/slides/ru/androidjava/font-replacement/) и [наборы fallback](/slides/ru/androidjava/fallback-font/), чтобы точно определить, какой шрифт использовать, если запрашиваемый глиф отсутствует.

**Могу ли я использовать шрифты в контейнерах Linux/Docker без их установки на уровне системы?**

Да. Указывайте собственные папки со шрифтами или загружайте шрифты из массивов байтов. Это устраняет любую зависимость от системных каталогов шрифтов в образе контейнера.

**Как насчёт лицензирования — могу ли я встраивать любой пользовательский шрифт без ограничений?**

Вы несёте ответственность за соблюдение условий лицензий шрифтов. Условия различаются; некоторые лицензии запрещают встраивание или коммерческое использование. Всегда проверяйте лицензионное соглашение (EULA) шрифта перед распространением результатов.