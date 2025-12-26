---
title: Customize PowerPoint Fonts on Android
linktitle: Custom Font
type: docs
weight: 20
url: /androidjava/custom-font/
keywords:
- font
- custom font
- external font
- load font
- manage fonts
- font folder
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Customize fonts in PowerPoint slides with Aspose.Slides for Android via Java to keep your presentations sharp and consistent across any device."
---

{{% alert color="primary" %}} 

Aspose Slides allows you to load these fonts using the [loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) method:

* TrueType (.ttf) and TrueType Collection (.ttc) fonts. See [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) fonts. See [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides allows you to load fonts used in a presentation without installing them on the system. This affects export output—such as PDF, images, and other supported formats—so the resulting documents look consistent across environments. Fonts are loaded from custom directories.

1. Specify one or more folders that contain the font files.
2. Call the static [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) method to load fonts from those folders.
3. Load and render/export the presentation.
4. Call [FontsLoader.clearCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsLoader#clearCache--) to clear the font cache.

The following code example demonstrates the font loading process:

```java
// Define folders that contain custom font files.
String[] fontFolders = new String[] { externalFontFolder1, externalFontFolder2 };

// Load custom fonts from the specified folders.
FontsLoader.loadExternalFonts(fontFolders);

Presentation presentation = null;
try {
    presentation = new Presentation("sample.pptx");
    
    // Render/export the presentation (e.g., to PDF, images, or other formats) using the loaded fonts.
    presentation.save("output.pdf", SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Clear the font cache after the work is finished.
    FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) adds additional folders to the font search paths, but it does not change the font initialization order.
Fonts are initialized in this order:

1. The default operating system font path.
1. The paths loaded via [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/).

{{%/alert %}}

## **Get Custom Font Folders**
Aspose.Slides provides the [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--) method to allow you to find font folders. This method returns folders added through the `LoadExternalFonts` method and system font folders.

This Java code shows you how to use [getFontFolders](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#getFontFolders--):

```java
// This line outputs folders where font files are searched.
// Those are folders added through the LoadExternalFonts method and system font folders.
String[] fontFolders = FontsLoader.getFontFolders();
```

## **Specify Custom Fonts Used with a Presentation**
Aspose.Slides provides the [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) property to allow you to specify external fonts that will be used with the presentation.

This Java code shows you how to use the [setDocumentLevelFontSources](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iloadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) property:

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

Aspose.Slides provides the [loadExternalFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) method to allow you to load external fonts from binary data.

This Java code demonstrates the byte array font loading process:

```java
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALN.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNBI.TTF")));
FontsLoader.loadExternalFont(Files.readAllBytes(Paths.get("ARIALNI.TTF")));

try
{
    Presentation pres = new Presentation("");
    try {
        // external font loaded during the presentation lifetime
    } finally {
        
    }
}
finally
{
    FontsLoader.clearCache();
}
```

## **FAQ**

**Do custom fonts affect export to all formats (PDF, PNG, SVG, HTML)?**

Yes. Connected fonts are used by the renderer across all export formats.

**Are custom fonts automatically embedded into the resulting PPTX?**

No. Registering a font for rendering is not the same as embedding it into a PPTX. If you need the font carried inside the presentation file, you must use the explicit [embedding features](/slides/androidjava/embedded-font/).

**Can I control fallback behavior when a custom font lacks certain glyphs?**

Yes. Configure [font substitution](/slides/androidjava/font-substitution/), [replacement rules](/slides/androidjava/font-replacement/), and [fallback sets](/slides/androidjava/fallback-font/) to define exactly which font is used when the requested glyph is missing.

**Can I use fonts in Linux/Docker containers without installing them system-wide?**

Yes. Point to your own font folders or load fonts from byte arrays. This removes any dependency on system font directories in the container image.

**What about licensing—can I embed any custom font without restrictions?**

You are responsible for font licensing compliance. Terms vary; some licenses prohibit embedding or commercial use. Always review the font’s EULA before distributing outputs.
