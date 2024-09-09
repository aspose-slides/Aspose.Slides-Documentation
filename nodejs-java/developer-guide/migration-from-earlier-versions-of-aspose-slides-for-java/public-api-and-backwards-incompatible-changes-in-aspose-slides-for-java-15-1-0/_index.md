---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for Java 15.1.0
type: docs
weight: 100
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) classes, methods, properties and so on, any new restrictions and other [changes](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) introduced with the Aspose.Slides for Java 15.1.0 API.

{{% /alert %}} {{% alert color="primary" %}} 

There are known issues with some image bullets and WordArt objects which will be fixed in Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **Public API Changes**
### **Fonts substitutions functinality has been added**
The possibility to replace fonts globally across the presentation and temporary for rendering has been added.

New method getFontsManager() of Presentation class has been introduced. FontsManager class has following members:

**IFontSubstRuleCollection getFontSubstRuleList**() method

This is the collection of IFontSubstRule instances used to substitute fonts during rendering. IFontSubstRule has getSourceFont() and getDestFont() methods implementing IFontData interface and getReplaceFontCondition() method allowing to choose the condition of replacement ("WhenInaccessible" or "Always").

**IFontData[] getFonts()** method can be used to retrieve all fonts used in the current presentation.

**replaceFont(...)** methods can be used to persistently replace a font in a presentation. 

The following example shows how to replace a font in a presentation:

```javascript
    var pres = new  com.aspose.slides.Presentation("PresContainsArialFont.pptx");
    var sourceFont = new  com.aspose.slides.FontData("Arial");
    var destFont = new  com.aspose.slides.FontData("Times New Roman");
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    pres.save("PresContainsTimesNoewRomanFont.pptx", com.aspose.slides.SaveFormat.Pptx);
```

Another example, shows font substitution for rendering when it is inaccessible:

```javascript
    var pres = new  com.aspose.slides.Presentation("PresContainsSomeRareFontFont.pptx");
    var sourceFont = new  com.aspose.slides.FontData("SomeRareFont");
    var destFont = new  com.aspose.slides.FontData("Arial");
    var fontSubstRule = new  com.aspose.slides.FontSubstRule(sourceFont, destFont, com.aspose.slides.FontSubstCondition.WhenInaccessible);
    var fontSubstRuleCollection = new  com.aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // Arial font will be used instead of SomeRareFont when inaccessible
    pres.getSlides().get_Item(0).getThumbnail(1, 1);
```
