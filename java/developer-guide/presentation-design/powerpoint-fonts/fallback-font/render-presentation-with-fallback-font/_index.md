---
title: Render Presentation with Fallback Font
type: docs
weight: 30
url: /java/render-presentation-with-fallback-font/
---

The following example includes these steps:

1. We [create fallback font rules collection](/slides/java/create-fallback-fonts-collection/).
1. [Remove](https://apireference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#remove-java.lang.String-) a fallback font rule and [addFallBackFonts](https://apireference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) to another rule.
1. Set rules collection to [getFontsManager](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/FontsManager#getFontFallBackRulesCollection--) method.
1. With [Presentation.save](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) method we can save presentation in the same format, or save it in another one. After fallback font rules collection is set to [FontsManager](https://apireference.aspose.com/slides/java/com.aspose.slides/FontsManager), these rules are applied during any operations over the presentation: save, render, convert, etc.

```java
// Create new instance of a rules collection
IFontFallBackRulesCollection rulesList = new FontFallBackRulesCollection();

// create a number of rules
rulesList.add(new FontFallBackRule(0x400, 0x4FF, "Times New Roman"));

for (IFontFallBackRule fallBackRule : rulesList)
{
    //Trying to remove FallBack font "Tahoma" from loaded rules
    fallBackRule.remove("Tahoma");

    //And to update of rules for specified range
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000))
        fallBackRule.addFallBackFonts("Verdana");
}

//Also we can remove any existing rules from list
if (rulesList.size() > 0)
    rulesList.remove(rulesList.get_Item(0));

Presentation pres = new Presentation("input.pptx");
try {
    //Assigning a prepared rules list for using
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);

    // Rendering of thumbnail with using of initialized rules collection and saving to PNG
    ImageIO.write(pres.getSlides().get_Item(0).getThumbnail(1f, 1f), 
            "PNG", new File("Slide_0.png"));
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="primary" %}} 
Read more about [Save and Convertion in Presentation](/slides/java/creating-saving-and-converting-a-presentation/).
{{% /alert %}}