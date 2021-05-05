---
title: Font Substitution
type: docs
weight: 70
url: /java/font-substitution/
---


## **Rule Based Font Substitution**
To replace the fonts by setting some rules of replacement following steps are used:

- Load the desired presentation.
- Load the font that is to replaced inside the presentation.
- Load the replacing font.
- Add rule for replacement.
- Add the rule to presentation font replacement rule collection.
- Generate the slide image to observe the effect.

The implementation of the above steps is given below.

```java
// Load presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Load source font to be replaced
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Load the replacing font
    IFontData destFont = new FontData("Arial");
    
    // Add font rule for font replacement
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Add rule to font substitute rules collection
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Add font rule collection to rule list
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Arial font will be used instead of SomeRareFont when inaccessible
    BufferedImage image = pres.getSlides().get_Item(0).getThumbnail(1f, 1f);
    
    // Save the image to disk in JPEG format
    ImageIO.write(image, "PNG", new File("Thumbnail_out.jpg"));
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

