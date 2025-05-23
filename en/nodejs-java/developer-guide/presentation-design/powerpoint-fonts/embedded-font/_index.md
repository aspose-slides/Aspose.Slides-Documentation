---
title: Embedded Font - PowerPoint JavaScript API
linktitle: Embedded Font
type: docs
weight: 40
url: /nodejs-java/embedded-font/
keywords: "Fonts, embedded fonts, add fonts, PowerPoint presentation, Java, Aspose.Slides for Node.js via Java"
description: "Use embedded fonts in PowerPoint presentation in JavaScript"

---

**Embedded fonts in PowerPoint** are useful when you want your presentation to appear correctly when opened on any system or device. If you used a third-party or non-standard font because you got creative with your work, then you have even more reasons to embed your font. Otherwise (without embedded fonts), the texts or numbers on your slides, the layout, styling, etc. may change or turn into confusing rectangles. 

The [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager) class, [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) class, [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) class, and their classs contain most of the properties and methods you need to work with embedded fonts in PowerPoint presentations.

## **Get or Remove Embedded Fonts from Presentation**

Aspose.Slides provides the [getEmbeddedFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) method (exposed by the [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager) class) to allow you to get (or find out) the fonts embedded in a presentation. To remove fonts, the [removeEmbeddedFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#removeEmbeddedFont-aspose.slides.IFontData-) method (exposed by the same class) is used.

This JavaScript code shows you how to get and remove embedded fonts from a presentation:

```javascript
// Instantiates a Presentation object that represents a presentation file
var pres = new aspose.slides.Presentation("EmbeddedFonts.pptx");
try {
    // Renders a slide containing a text frame that uses embedded "FunSized"
    var slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Save the image to disk in JPEG format
    try {
        slideImage.save("picture1_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    var fontsManager = pres.getFontsManager();
    // Gets all embedded fonts
    var embeddedFonts = fontsManager.getEmbeddedFonts();
    // Finds the "Calibri" font
    var calibriEmbeddedFont = null;
    for (var i = 0; i < embeddedFonts.length; i++) {
        console.log("" + embeddedFonts[i].getFontName());
        if ("Calibri" == embeddedFonts[i].getFontName()) {
            calibriEmbeddedFont = embeddedFonts[i];
            break;
        }
    }
    // Removes "Calibri" font
    fontsManager.removeEmbeddedFont(calibriEmbeddedFont);
    // Renders the presentation; "Calibri" font is replaced with an existing one
    slideImage = pres.getSlides().get_Item(0).getImage(java.newInstanceSync("java.awt.Dimension", 960, 720));
    // Save the image to disk in JPEG format
    try {
        slideImage.save("picture2_out.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
    // Saves the presentation without embedded "Calibri" font to disk
    pres.save("WithoutManageEmbeddedFonts_out.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Add Embedded Fonts to Presentation**

Using the [EmbedFontCharacters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/embedfontcharacters/) enum and two overloads of the [addEmbeddedFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/#addEmbeddedFont-aspose.slides.IFontData-int-) method, you can select your preferred (embedding) rule to embed the fonts in a presentation. This JavaScript code shows you how to embed and add fonts to a presentation:

```javascript
// Loads the presentation
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    var allFonts = pres.getFontsManager().getFonts();
    var embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
    allFonts.forEach(font => {
        var embeddedFontsContainsFont = false;
        for (var i = 0; i < embeddedFonts.length; i++) {
            if (embeddedFonts[i].equals(font)) {
                embeddedFontsContainsFont = true;
                break;
            }
        }
        if (!embeddedFontsContainsFont) {
            pres.getFontsManager().addEmbeddedFont(font, aspose.slides.EmbedFontCharacters.All);
            embeddedFonts = pres.getFontsManager().getEmbeddedFonts();
        }
    });
    // Saves the presentation to disk
    pres.save("AddEmbeddedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Compress Embedded Fonts**

To allow you to compress the fonts embedded in a presentation and reduce its file size, Aspose.Slides provides the [compressEmbeddedFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts-aspose.slides.Presentation-) method (exposed by the [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) class).

This JavaScript code shows you how to compress embedded PowerPoint fonts:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.compressEmbeddedFonts(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

