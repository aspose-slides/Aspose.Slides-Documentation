---
title: Embed Fonts in Presentations on Android
linktitle: Embedding Font
type: docs
weight: 40
url: /androidjava/embedded-font/
keywords:
- add font
- embed font
- font embedding
- get embedded font
- add embedded font
- remove embedded font
- compress embedded font
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Embed TrueType fonts in PowerPoint and OpenDocument presentations with Aspose.Slides for Android via Java, ensuring accurate rendering across all platforms."
---

**Embedded fonts in PowerPoint** are useful when you want your presentation to appear correctly when opened on any system or device. If you used a third-party or non-standard font because you got creative with your work, then you have even more reasons to embed your font. Otherwise (without embedded fonts), the texts or numbers on your slides, the layout, styling, etc. may change or turn into confusing rectangles. 

The [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) class, [FontData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontdata/) class, [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) class, and their interfaces contain most of the properties and methods you need to work with embedded fonts in PowerPoint presentations.

## **Get and Remove Embedded Fonts**

Aspose.Slides provides the [getEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) method (exposed by the [FontsManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/FontsManager) class) to allow you to get (or find out) the fonts embedded in a presentation. To remove fonts, the [removeEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#removeEmbeddedFont-com.aspose.slides.IFontData-) method (exposed by the same class) is used.

This Java code shows you how to get and remove embedded fonts from a presentation:

```java
// Instantiates a Presentation object that represents a presentation file
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // Renders a slide containing a text frame that uses embedded "FunSized"
    IImage slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

    //Save the image to disk in JPEG format
    try {
        slideImage.save("picture1_out.jpg", ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) slideImage.dispose();
    }

    IFontsManager fontsManager = pres.getFontsManager();

    // Gets all embedded fonts
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // Finds the "Calibri" font
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // Removes "Calibri" font
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // Renders the presentation; "Calibri" font is replaced with an existing one
     slideImage = pres.getSlides().get_Item(0).getImage(new Dimension(960, 720));

     //Save the image to disk in JPEG format
     try {
         slideImage.save("picture2_out.jpg", ImageFormat.Jpeg);
     } finally {
         if (slideImage != null) slideImage.dispose();
     }

    // Saves the presentation without embedded "Calibri" font to disk
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Add Embedded Fonts**

Using the [EmbedFontCharacters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/embedfontcharacters/) enum and two overloads of the [addEmbeddedFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsmanager/#addEmbeddedFont-com.aspose.slides.IFontData-int-) method, you can select your preferred (embedding) rule to embed the fonts in a presentation. This Java code shows you how to embed and add fonts to a presentation:

```java
// Loads the presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts[i].equals(font))
            {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);

            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    }

    // Saves the presentation to disk
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Compress Embedded Fonts**

To allow you to compress the fonts embedded in a presentation and reduce its file size, Aspose.Slides provides the [compressEmbeddedFonts](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) method (exposed by the [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) class).

This Java code shows you how to compress embedded PowerPoint fonts:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**How can I tell that a specific font in the presentation will still be substituted during rendering despite embedding?**

Check the [substitution information](/slides/androidjava/font-substitution/) in the font manager and the [fallback/substitution rules](/slides/androidjava/fallback-font/): if the font is unavailable or restricted, a fallback will be used.

**Is it worth embedding "system" fonts like Arial/Calibri?**

Usually no—they are almost always available. But for full portability in "thin" environments (Docker, a Linux server without preinstalled fonts), embedding system fonts can eliminate the risk of unexpected substitutions.
