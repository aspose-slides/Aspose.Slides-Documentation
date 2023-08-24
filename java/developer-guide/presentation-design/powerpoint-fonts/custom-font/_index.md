---
title: Custom PowerPoint Font in Java
linktitle: Custom Font
type: docs
weight: 20
url: /java/custom-font/
keywords: "Fonts, custom fonts, PowerPoint presentation, Java, Aspose.Slides for Java"
description: "PowerPoint custom fonts in Java"
---

{{% alert color="primary" %}} 

Aspose Slides allows you to load these fonts using the [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) method:

* TrueType (.ttf) and TrueType Collection (.ttc) fonts. See [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) fonts. See [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides allows you to load fonts that are rendered in presentations without having to install those fonts. The fonts are loaded from a custom directory. 

1. Create an instance of the [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) class and call the [loadExternalFonts](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) method.
2. Load the presentation that will be rendered.
3. [Clear the cache](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader#clearCache--) in the [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/FontsLoader) class.

This Java code demonstrates the font loading process:

```java
// Folders to seek fonts
String[] folders = new String[] { externalFontsDir };

// Loads the custom font directory fonts
FontsLoader.loadExternalFonts(folders);

// Do Some work and perform presentation/slide rendering
Presentation pres = new Presentation("DefaultFonts.pptx");
try {
    pres.save("NewFonts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();

    // Clears Font Cachce
    FontsLoader.clearCache();
}
```

## **Get Custom Fonts Folder**
Aspose.Slides provides the [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--) method to allow you to find font folders. This method returns folders added through the `LoadExternalFonts` method and system font folders.

This Java code shows you how to use [getFontFolders](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// This line outputs folders where font files are searched.
// Those are folders added through the LoadExternalFonts method and system font folders.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Specify Custom Fonts Used With Presentation**
Aspose.Slides provides the [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) property to allow you to specify external fonts that will be used with the presentation. 

This Java code shows you how to use the [setDocumentLevelFontSources](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) property:

```java
byte[] memoryFont1 = Files.readAllBytes("customfonts/CustomFont1.ttf");
byte[] memoryFont2 = Files.readAllBytes("customfonts/CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(new String[] { "assets/fonts", "global/fonts" });
loadOptions.getDocumentLevelFontSources().setMemoryFonts(new byte[][] { memoryFont1, memoryFont2 });

Presentation pres = new Presentation("MyPresentation.pptx", loadOptions);
try {
    // Work with the presentation
    // CustomFont1, CustomFont2, and fonts from assets\fonts & global\fonts folders and their subfolders are available to the presentation
} finally {
    if (pres != null) pres.dispose();
}
```

## **Manage Fonts Externally**

Aspose.Slides provides the [loadExternalFont](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) method to allow you to load external fonts from binary data.

This Java code demonstrates the byte array font loading process: xxx

```java

```

