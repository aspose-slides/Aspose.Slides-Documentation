---
title: Customize PowerPoint Fonts in JavaScript
linktitle: Custom Font
type: docs
weight: 20
url: /nodejs-java/custom-font/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Customize fonts in PowerPoint slides with JavaScript and Aspose.Slides for Node.js via Java to keep your presentations sharp and consistent across any device."
---

{{% alert color="primary" %}} 

Aspose Slides allows you to load these fonts using the [loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) method:

* TrueType (.ttf) and TrueType Collection (.ttc) fonts. See [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) fonts. See [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides allows you to load fonts used in a presentation without installing them on the system. This affects export output—such as PDF, images, and other supported formats—so the resulting documents look consistent across environments. Fonts are loaded from custom directories.

1. Specify one or more folders that contain the font files.
2. Call the static [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) method to load fonts from those folders.
3. Load and render/export the presentation.
4. Call [FontsLoader.clearCache](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/clearcache/) to clear the font cache.

The following code example demonstrates the font loading process:

```js
// Define folders that contain custom font files.
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Load custom fonts from the specified folders.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Render/export the presentation (e.g., to PDF, images, or other formats) using the loaded fonts.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Clear the font cache after the work is finished.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) adds additional folders to the font search paths, but it does not change the font initialization order.
Fonts are initialized in this order:

1. The default operating system font path.
1. The paths loaded via [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Get Custom Fonts Folder**
Aspose.Slides provides the [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) method to allow you to find font folders. This method returns folders added through the `LoadExternalFonts` method and system font folders.

This JavaScript code shows you how to use [getFontFolders](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
// This line outputs folders where font files are searched.
// Those are folders added through the LoadExternalFonts method and system font folders.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Specify Custom Fonts Used With Presentation**
Aspose.Slides provides the [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) property to allow you to specify external fonts that will be used with the presentation.

This JavaScript code shows you how to use the [setDocumentLevelFontSources](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) property:

```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Work with the presentation
    // CustomFont1, CustomFont2, and fonts from assets\fonts & global\fonts folders and their subfolders are available to the presentation
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Manage Fonts Externally**

Aspose.Slides provides the [loadExternalFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) method to allow you to load external fonts from binary data.

This JavaScript code demonstrates the byte array font loading process:

```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // external font loaded during the presentation lifetime
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **FAQ**

**Do custom fonts affect export to all formats (PDF, PNG, SVG, HTML)?**

Yes. Connected fonts are used by the renderer across all export formats.

**Are custom fonts automatically embedded into the resulting PPTX?**

No. Registering a font for rendering is not the same as embedding it into a PPTX. If you need the font carried inside the presentation file, you must use the explicit [embedding features](/slides/nodejs-java/embedded-font/).

**Can I control fallback behavior when a custom font lacks certain glyphs?**

Yes. Configure [font substitution](/slides/nodejs-java/font-substitution/), [replacement rules](/slides/nodejs-java/font-replacement/), and [fallback sets](/slides/nodejs-java/fallback-font/) to define exactly which font is used when the requested glyph is missing.

**Can I use fonts in Linux/Docker containers without installing them system-wide?**

Yes. Point to your own font folders or load fonts from byte arrays. This removes any dependency on system font directories in the container image.

**What about licensing—can I embed any custom font without restrictions?**

You are responsible for font licensing compliance. Terms vary; some licenses prohibit embedding or commercial use. Always review the font’s EULA before distributing outputs.
