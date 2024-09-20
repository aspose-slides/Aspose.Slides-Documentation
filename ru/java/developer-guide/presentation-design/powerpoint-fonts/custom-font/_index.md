---
title: Пользовательский шрифт PowerPoint на Java
linktitle: Пользовательский шрифт
type: docs
weight: 20
url: /java/custom-font/
keywords: "Шрифты, пользовательские шрифты, презентация PowerPoint, Java, Aspose.Slides для Java"
description: "Пользовательские шрифты PowerPoint на Java"
---

{{% alert color="primary" %}} 

Aspose Slides позволяет загружать эти шрифты с помощью метода [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Шрифты TrueType (.ttf) и коллекции TrueType (.ttc). См. [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Шрифты OpenType (.otf). См. [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Загрузка пользовательских шрифтов**

Aspose.Slides позволяет загружать шрифты, которые отображаются в презентациях, не устанавливая эти шрифты. Шрифты загружаются из пользовательского каталога. 

1. Создайте экземпляр класса [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) и вызовите метод [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---).
2. Загрузите презентацию, которая будет отображена.
3. [Очистите кеш](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader#clearCache--) в классе [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader).

Этот Java код демонстрирует процесс загрузки шрифтов:

```java
// Папки для поиска шрифтов
String[] folders = new String[] { externalFontsDir };

// Загружает шрифты из пользовательского каталога
FontsLoader.loadExternalFonts(folders);

// Выполнение работы и рендеринг презентации/слайда
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // Очищает кеш шрифтов
    FontsLoader.clearCache();
}
```

## **Получение папки пользовательских шрифтов**
Aspose.Slides предоставляет метод [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) для поиска папок с шрифтами. Этот метод возвращает папки, добавленные через метод `LoadExternalFonts`, и системные папки шрифтов.

Этот Java код показывает, как использовать [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// Эта строка выводит папки, где ищутся файлы шрифтов.
// Это папки, добавленные через метод LoadExternalFonts, и системные папки шрифтов.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Указание пользовательских шрифтов, используемых в презентации**
Aspose.Slides предоставляет свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) для указания внешних шрифтов, которые будут использоваться в презентации. 

Этот Java код показывает, как использовать свойство [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Работа с презентацией
    // CustomFont1, CustomFont2 и шрифты из папок assets\fonts и global\fonts, а также их подкаталогов доступны для презентации
} finally {
    if (pres != null) pres.dispose();
}
```

## **Управление шрифтами извне**

Aspose.Slides предоставляет метод [loadExternalFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) для загрузки внешних шрифтов из двоичных данных.

Этот Java код демонстрирует процесс загрузки шрифтов из массива байтов:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // внешний шрифт загружен в течение времени жизни презентации
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```