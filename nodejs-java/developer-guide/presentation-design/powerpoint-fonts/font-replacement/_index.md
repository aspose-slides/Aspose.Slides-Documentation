---
title: Font Replacement - PowerPoint Java API
linktitle: Font Replacement
type: docs
weight: 60
url: /nodejs-java/font-replacement/
description: Learn how to replace fonts using the explicit replacement method in PowerPoint using the Java API.
---

If you change your mind about using a font, you can replace that font with another font. All instances of the old font will be replaced by the new font. 

Aspose.Slides allows you to replace a font this way:

1. Load the relevant presentation. 
2. Load the font that will be replaced.
3. Load the new font. 
4. Replace the font. 
5. Write the modified presentation as a PPTX file.

This Javascript code demonstrates font replacement:

```javascript
    // Loads a presentation
    var pres = new aspose.slides.Presentation("Fonts.pptx");
    try {
        // Loads the source font that will be replaced
        var sourceFont = new aspose.slides.FontData("Arial");
        // Loads the new font
        var destFont = new aspose.slides.FontData("Times New Roman");
        // Replaces the fonts
        pres.getFontsManager().replaceFont(sourceFont, destFont);
        // Saves the presentation
        pres.save("UpdatedFont_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

{{% alert title="Note" color="warning" %}} 

To set rules that determine what happens in certain conditions (if a font cannot be accessed, for example), see [**Font Substitution**](/slides/nodejs-java/font-substitution/).

{{% /alert %}}
