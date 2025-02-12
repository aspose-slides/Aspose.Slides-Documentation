---
title: Embedding Fonts in PowerPoint with C#
linktitle: Embedding Fonts
type: docs
weight: 40
url: /net/embedded-font/
keywords:
- embed fonts
- PowerPoint C#
- add fonts
- presentation
- Aspose.Slides for .NET
description: "Learn to embed, add, and manage fonts in PowerPoint presentations using C# and .NET"
---

**Embedding fonts in PowerPoint** ensures your presentation maintains its intended appearance across different systems. Whether using unique fonts for creativity or standard ones, embedding fonts prevents text and layout disruption.

If you used a third-party or non-standard font because you got creative with your work, then you have even more reasons to embed your font. Otherwise (without embedded fonts), the texts or numbers on your slides, the layout, styling, etc. may change or turn into confusing rectangles. 

Utilize the [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/net/aspose.slides/fontdata/), and [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) classes to manage embedded fonts.

## **Getting and Removing Embedded Fonts**

Retrieve or remove embedded fonts from a presentation effortlessly with the [GetEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/getembeddedfonts) and [RemoveEmbeddedFont](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/removeembeddedfont) methods.

This C# code shows you how to get and remove embedded fonts from a presentation:

```c#
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Renders a slide containing a text frame that uses embedded "FunSized"
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture1_out.png", ImageFormat.Png);
    }

    IFontsManager fontsManager = presentation.FontsManager;

    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // Finds the "Calibri" font
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate (IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // Removes the "Calibri" font
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // Renders the presentation; the "Calibri" font is replaced with an existing one
    using (IImage image = slide.GetImage(new Size(960, 720)))
    {
        image.Save("picture2_out.png", ImageFormat.Png);
    }

    // Saves the presentation without embedded "Calibri" font to disk
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```

## **Adding Embedded Fonts**

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

// Saves the presentation to disk
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

## **Compressing Embedded Fonts**

Optimize file size by compressing embedded fonts using [CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/).

Example code for compression:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.CompressEmbeddedFonts(pres);
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```