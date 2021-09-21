---
title: Embedded Font
type: docs
weight: 40
url: /java/embedded-font/
---

## **Get or Remove Embedded Fonts from Presentation**
Now, you can also work with embedded fonts. [FontsManager](https://apireference.aspose.com/slides/java/com.aspose.slides/FontsManager) class now offer, [getEmbeddedFonts()](https://apireference.aspose.com/slides/java/com.aspose.slides/FontsManager#getEmbeddedFonts--) method that returns a list of embedded fonts inside the presentation. You can also remove any embedded font inside presentation if that is required by using [removeEmbeddedFont()](https://apireference.aspose.com/slides/java/com.aspose.slides/FontsManager#removeEmbeddedFont-com.aspose.slides.IFontData-) method exposed by [FontsManager](https://apireference.aspose.com/slides/java/com.aspose.slides/FontsManager) class. The implementation of the above steps is given below.

```java
// Instantiate a Presentation object that represents a presentation file
Presentation pres = new Presentation("EmbeddedFonts.pptx");
try {
    // render a slide that contains a text frame that uses embedded "FunSized"
    ImageIO.write(pres.getSlides().get_Item(0).getThumbnail(new Dimension(960, 720)),
            "PNG", new File("picture1_out.png"));

    IFontsManager fontsManager = pres.getFontsManager();

    // get all embedded fonts
    IFontData[] embeddedFonts = fontsManager.getEmbeddedFonts();

    // find "Calibri" font
    IFontData calibriEmbeddedFont = null;
    for (int i = 0; i < embeddedFonts.length; i++) {
        System.out.println(""+ embeddedFonts[i].getFontName());
        if ("Calibri".equals(embeddedFonts[i].getFontName())) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }

    // remove "Calibri" font
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);

    // render the presentation; removed "Calibri" font is replaced to an existing one
    ImageIO.write(pres.getSlides().get_Item(0).getThumbnail(new Dimension(960, 720)),
            "PNG", new File("picture2_out.png"));

    // save the presentation without embedded "Calibri" font
    pres.save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Add Embedded Fonts to Presentation**
A new property of embedding fonts has been added. To allow embedding fonts into [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) the new [EmbedFontCharacters](https://apireference.aspose.com/slides/java/com.aspose.slides/EmbedFontCharacters) enum and two overloads of [addEmbeddedFont](https://apireference.aspose.com/slides/java/com.aspose.slides/FontsManager#addEmbeddedFont-com.aspose.slides.IFontData-int-) method have been added. Using these methods and choosing the desired embedding rule (represented by [EmbedFontCharacters](https://apireference.aspose.com/slides/java/com.aspose.slides/EmbedFontCharacters) enum), all fonts used in the [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) can be embedded. The implementation of the above steps is given below.

```java
// Load presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    IFontData[] allFonts = pres.getFontsManager().getFonts();
    IFontData[] embeddedFonts = pres.getFontsManager().getEmbeddedFonts();

    for (IFontData font : allFonts)
    {
        boolean embeddedFontsContainsFont = false;
        for (int i = 0; i < embeddedFonts.length; i++)
        {
            if (embeddedFonts.equals(font)) embeddedFontsContainsFont = true;
        }
        if (!embeddedFontsContainsFont)
        {
            pres.getFontsManager().addEmbeddedFont(font, EmbedFontCharacters.All);
        }
    }

    // Save the presentation
    pres.save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

