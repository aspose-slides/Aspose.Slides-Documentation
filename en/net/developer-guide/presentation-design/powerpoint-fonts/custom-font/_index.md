---
title: Custom PowerPoint Font in C#
linktitle: Custom Font
type: docs
weight: 20
url: /net/custom-font/
keywords: "Fonts, custom fonts, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "PowerPoint custom fonts in C#"
---

{{% alert color="primary" %}} 

Aspose Slides allows you to load these fonts using the [FontsLoader.LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) method:

* TrueType (.ttf) and TrueType Collection (.ttc) fonts. See [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) fonts. See [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides allows you to load fonts that are rendered in presentations without having to install those fonts. The fonts are loaded from a custom directory. 

1. Create an instance of the [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) Class and call the [LoadExternalFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfonts/) method.
2. Load the presentation that will be rendered.
3. Clear the cache in the [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) Class.

This C# code demonstrates the font loading process:

``` csharp
// The path to the documents directory
string dataDir = "C:\\";

// folders to seek fonts
String[] folders = new String[] { dataDir };

// Loads the custom font directory fonts
FontsLoader.LoadExternalFonts(folders);

// Do some work and perform presentation/slide rendering
using (Presentation presentation = new Presentation(dataDir + "DefaultFonts.pptx"))
    presentation.Save(dataDir + "NewFonts_out.pptx", SaveFormat.Pptx);

// Clears the font cache
FontsLoader.ClearCache();
```

## **Get Custom Fonts Folder**
Aspose.Slides provides the [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/) method to allow you to find font folders. This method returns folders added through the `LoadExternalFonts` method and system font folders.

This C# code shows you how to use [GetFontFolders](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/getfontfolders/):

```c#
// This line outputs the folders that are checked for font files.
// Those are folders added through the LoadExternalFonts method and system font folders.
string[] fontFolders = FontsLoader.GetFontFolders();
```


## **Specify Custom Fonts Used With Presentation**
Aspose.Slides provides the [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) property to allow you to specify external fonts that will be used with the presentation.

This C# code shows you how to use the [DocumentLevelFontSources](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/documentlevelfontsources/) property:

```c#
byte[] memoryFont1 = File.ReadAllBytes("customfonts\\CustomFont1.ttf");
byte[] memoryFont2 = File.ReadAllBytes("customfonts\\CustomFont2.ttf");

LoadOptions loadOptions = new LoadOptions();
loadOptions.DocumentLevelFontSources.FontFolders = new string[] { "assets\\fonts", "global\\fonts" };
loadOptions.DocumentLevelFontSources.MemoryFonts = new byte[][] { memoryFont1, memoryFont2 };
using (IPresentation presentation = new Presentation("MyPresentation.pptx", loadOptions))
{
    // Work with the presentation
    // CustomFont1, CustomFont2, and fonts from assets\fonts & global\fonts folders and their subfolders are available to the presentation
}
```

## **Manage Fonts Externally**

Aspose.Slides provides the [LoadExternalFont](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/loadexternalfont/)(byte[] data) method to allow you to load external fonts from binary data.

This C# code demonstrates the byte array font loading process: 

```c#
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALN.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNBI.TTF"));
FontsLoader.LoadExternalFont(File.ReadAllBytes("ARIALNI.TTF"));

try
{
    using (Presentation pres = new Presentation(""))
    {
        // external font loaded during the presentation lifetime
    }
}
finally
{
    FontsLoader.ClearCache();
}
```

## **FAQ**

**Do custom fonts affect export to all formats (PDF, PNG, SVG, HTML)?**

Yes. Connected fonts are used by the renderer across all export formats.

**Are custom fonts automatically embedded into the resulting PPTX?**

No. Registering a font for rendering is not the same as embedding it into a PPTX. If you need the font carried inside the presentation file, you must use the explicit [embedding features](/slides/net/embedded-font/).

**Can I control fallback behavior when a custom font lacks certain glyphs?**

Yes. Configure [font substitution](/slides/net/font-substitution/), [replacement rules](/slides/net/font-replacement/), and [fallback sets](/slides/net/fallback-font/) to define exactly which font is used when the requested glyph is missing.

**Can I use fonts in Linux/Docker containers without installing them system-wide?**

Yes. Point to your own font folders or load fonts from byte arrays. This removes any dependency on system font directories in the container image.

**What about licensing—can I embed any custom font without restrictions?**

You are responsible for font licensing compliance. Terms vary; some licenses prohibit embedding or commercial use. Always review the font’s EULA before distributing outputs.
