---
title: Font Substitution - PowerPoint Java API
linktitle: Font Substitution
type: docs
weight: 70
url: /nodejs-java/font-substitution/
keywords: "Font, substitute font, PowerPoint presentation, Java, Aspose.Slides for Node.js via Java"
description: "Substitute font in PowerPoint in Javascript"
---

Aspose.Slides allows you to set rules for fonts that determines what must be done in certain conditions (for example, when a font cannot be accessed) this way:

1. Load the relevant presentation.
2. Load the font that will be replaced.
3. Load the new font.
4. Add a rule for the replacement.
5. Add the rule to the presentation font replacement rule collection.
6. Generate the slide image to observe the effect.

This Java code demonstrates the font substitution process:

```javascript
    // Loads a presentation
    var pres = new  aspose.slides.Presentation("Fonts.pptx");
    try {
        // Loads the source font that will be replaced
        var sourceFont = new  aspose.slides.FontData("SomeRareFont");
        // Loads the new font
        var destFont = new  aspose.slides.FontData("Arial");
        // Adds a font rule for font replacement
        var fontSubstRule = new  aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
        // Adds the rule to font substitute rules collection
        var fontSubstRuleCollection = new  aspose.slides.FontSubstRuleCollection();
        fontSubstRuleCollection.add(fontSubstRule);
        // Adds a font rule collection to the rule list
        pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
        // Arial font will be used in place of SomeRareFont when the latter is inaccessible
        var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
        // Saves the image to disk in the JPEG format
        try {
            slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

{{%  alert title="NOTE"  color="warning"   %}} 

You may want to see [**Font Replacement**](/slides/java/font-replacement/). 

{{% /alert %}}
