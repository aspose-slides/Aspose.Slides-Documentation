---
title: Render Presentation with Fallback Font
type: docs
weight: 30
url: /nodejs-java/render-presentation-with-fallback-font/
---

The following example includes these steps:

1. We [create fallback font rules collection](/slides/nodejs-java/create-fallback-fonts-collection/).
1. [Remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) a fallback font rule and [addFallBackFonts](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) to another rule.
1. Set rules collection to [getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) method.
1. With [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) method we can save presentation in the same format, or save it in another one. After fallback font rules collection is set to [FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/FontsManager), these rules are applied during any operations over the presentation: save, render, convert, etc.

```javascript
// Create new instance of a rules collection
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// create a number of rules
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // Trying to remove FallBack font "Tahoma" from loaded rules
    fallBackRule.remove("Tahoma");
    // And to update of rules for specified range
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// Also we can remove any existing rules from list
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // Assigning a prepared rules list for using
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // Rendering of thumbnail with using of initialized rules collection and saving to JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Save the image to disk in JPEG format
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
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

{{% alert color="primary" %}} 
Read more about [Save and Convertion in Presentation](/slides/nodejs-java/creating-saving-and-converting-a-presentation/).
{{% /alert %}}
