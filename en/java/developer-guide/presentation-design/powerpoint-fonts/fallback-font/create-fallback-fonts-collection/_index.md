---
title: Configure Fallback Font Collections in Java
linktitle: Fallback Font Collection
type: docs
weight: 20
url: /java/create-fallback-fonts-collection/
keywords:
- fallback font
- fallback rule
- font collection
- configure font
- set up font
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Set up a fallback fonts collection in Aspose.Slides for Java to keep text consistent and crisp in PowerPoint and OpenDocument presentations."
---

## **Apply Fallback Rules**

Instances of [FontFallBackRule](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) class can be organized into [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection), that implements [IFontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRulesCollection) interface. It is possible to add or remove rules from the collection.

Then this collection may be assigned to [FontFallBackRulesCollection](https://reference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) method of the [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) class. FontsManager controls fonts across the presentation. Read more [About FontsManager and FontsLoader](/slides/java/about-fontsmanager-and-fontsloader/).

Each [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) has a [getFontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) method with its own instance of the [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/FontsManager) class.

Here is an examples how to create fallback fonts rules collection and assign in into the [FontsManager](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) of a certain presentation:  

```java
Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

After FontsManager is initialised with fallback fonts collection, the fallback fonts are applied during presentation rendering.

{{% alert color="primary" %}} 
Read more how to [Render Presentation with Fallback Font](/slides/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Will my fallback rules be embedded into the PPTX file and visible in PowerPoint after saving?**

No. Fallback rules are runtime rendering settings; they are not serialized into PPTX and will not appear in PowerPoint's UI.

**Does fallback apply to text inside SmartArt, WordArt, charts, and tables?**

Yes. The same glyph-substitution mechanism is used for any text in these objects.

**Does Aspose distribute any fonts with the library?**

No. You add and use fonts on your side and under your own responsibility.

**Can replacement/substitution for missing fonts and fallback for missing glyphs be used together?**

Yes. They are independent stages of the same font-resolution pipeline: first the engine resolves font availability ([replacement](/slides/java/font-replacement/)/[substitution](/slides/java/font-substitution/)), then fallback fills gaps for missing glyphs in available fonts.
