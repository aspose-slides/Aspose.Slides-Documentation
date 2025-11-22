---
title: Font Substitution - PowerPoint JavaScript API
linktitle: Font Substitution
type: docs
weight: 70
url: /nodejs-java/font-substitution/
keywords: "Font, substitute font, PowerPoint presentation, Java, Aspose.Slides for Node.js via Java"
description: "Substitute font in PowerPoint in JavaScript"
---

## **Set Font Substitution Rules**

Aspose.Slides allows you to set rules for fonts that determines what must be done in certain conditions (for example, when a font cannot be accessed) this way:

1. Load the relevant presentation.
2. Load the font that will be replaced.
3. Load the new font.
4. Add a rule for the replacement.
5. Add the rule to the presentation font replacement rule collection.
6. Generate the slide image to observe the effect.

This JavaScript code demonstrates the font substitution process:

```javascript
// Loads a presentation
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Loads the source font that will be replaced
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // Loads the new font
    var destFont = new aspose.slides.FontData("Arial");
    // Adds a font rule for font replacement
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // Adds the rule to font substitute rules collection
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
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

You may want to see [**Font Replacement**](/slides/nodejs-java/font-replacement/).

{{% /alert %}}

## **FAQ**

**What is the difference between font replacement and font substitution?**

[Replacement](/slides/nodejs-java/font-replacement/) is a forced override of one font with another across the entire presentation. Substitution is a rule that triggers under a specific condition, for example when the original font is unavailable, and then a designated fallback font is used.

**When exactly are substitution rules applied?**

The rules participate in the standard [font selection](/slides/nodejs-java/font-selection-sequence/) sequence that is evaluated during loading, rendering, and conversion; if the chosen font is unavailable, replacement or substitution is applied.

**What is the default behavior if neither replacement nor substitution is configured and the font is missing on the system?**

The library will try to pick the closest available system font, similar to how PowerPoint would behave.

**Can I attach custom external fonts at runtime to avoid substitution?**

Yes. You can [add external fonts](/slides/nodejs-java/custom-font/) at runtime so the library considers them for selection and rendering, including for subsequent conversions.

**Does Aspose distribute any fonts with the library?**

No. Aspose does not distribute paid or free fonts; you add and use fonts at your own discretion and responsibility.

**Are there differences in substitution behavior on Windows, Linux, and macOS?**

Yes. Font discovery starts from the operating system’s font directories. The set of default available fonts and the search paths differ across platforms, which affects availability and the need for substitution.

**How should I prepare the environment to minimize unexpected substitution during batch conversions?**

Synchronize the font set across machines or containers, [add the external fonts](/slides/nodejs-java/custom-font/) required for the output documents, and [embed fonts](/slides/nodejs-java/embedded-font/) in presentations when possible so the chosen fonts are available during rendering.
