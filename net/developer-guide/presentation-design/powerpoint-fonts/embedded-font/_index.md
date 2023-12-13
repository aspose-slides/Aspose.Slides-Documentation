---
title: Embedded Font - PowerPoint C# API
linktitle: Embedded Font
type: docs
weight: 40
url: /net/embedded-font/
keywords: "Fonts, embedded fonts, add fonts, PowerPoint presentation C#, Csharp, Aspose.Slides for .NET"
description: "Use embedded fonts in PowerPoint presentation in C# or .NET"
---

**Embedded fonts in PowerPoint** are useful when you want your presentation to appear correctly when opened on any system or device. If you used a third-party or non-standard font because you got creative with your work, then you have even more reasons to embed your font. Otherwise (without embedded fonts), the texts or numbers on your slides, the layout, styling, etc. may change or turn into confusing rectangles. 

The [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/) class, [FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/) class, [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) class, and their interfaces contain most of the properties and methods you need to work with embedded fonts in PowerPoint presentations. 

## **Get or Remove Embedded Fonts from Presentation**

Aspose.Slides provides the [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) method (exposed by the class) to allow you to get (or find out) the fonts embedded in a presentation. To remove fonts, the [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont) method (exposed by the same class) is used.

This C# code shows you how to get and remove embedded fonts from a presentation:

```c#
// Instantiates a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    // Renders a slide containing a text frame that uses embedded "FunSized"
    presentation.Slides[0].GetThumbnail(new Size(960, 720)).Save("picture1_out.png", ImageFormat.Png);

    IFontsManager fontsManager = presentation.FontsManager;

    // Gets all embedded fonts
    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Finds the "Calibri" font
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate(IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Removes "Calibri" font
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Renders the presentation; "Calibri" font is replaced with an existing one
    presentation.Slides[0].GetThumbnail(new Size(960, 720)).Save("picture2_out.png", ImageFormat.Png);

    // Saves the presentation without embedded "Calibri" font
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **Add Embedded Fonts to Presentation**
Using the [EmbedFontCharacters](https://reference.aspose.com/slides/net/aspose.slides.export/embedfontcharacters/) enum and two overloads of the [AddEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/addembeddedfont/) method, you can select your preferred (embedding) rule to embed the fonts in a presentation. This C# code shows you how to embed and add fonts to a presentation:

```c#
// Loads the presentation
Presentation presentation = new Presentation("Fonts.pptx");

// Loads the source font to be replaced
IFontData sourceFont = new FontData("Arial");


IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// Saves the presentation
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **Compress Embedded Fonts**

To allow you to compress the fonts embedded in a presentation and reduce its file size, Aspose.Slides provides the [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) method (exposed by the [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) class).

This C# code shows you how to compress embedded PowerPoint fonts:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

