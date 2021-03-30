---
title: Create Fallback Fonts Collection
type: docs
weight: 20
url: /java/create-fallback-fonts-collection/
---

Instances of [FontFallBackRule](https://apireference.aspose.com/slides/java/com.aspose.slides/FontFallBackRule) class can be organized into [FontFallBackRulesCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection), that implements [IFontFallBackRulesCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/IFontFallBackRulesCollection) interface. It is possible to add or remove rules from the collection.

Then this collection may be assigned to [FontFallBackRulesCollection](https://apireference.aspose.com/slides/java/com.aspose.slides/FontFallBackRulesCollection) method of the [FontsManager](https://apireference.aspose.com/slides/java/com.aspose.slides/FontsManager) class. FontsManager controls fonts across the presentation. Read more [About FontsManager and FontsLoader](/slides/java/about-fontsmanager-and-fontsloader/).

Each [Presentation](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation) has a [getFontsManager](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) method with its own instance of the [FontsManager](https://apireference.aspose.com/slides/java/com.aspose.slides/FontsManager) class.

Here is an examples how to create fallback fonts rules collection and assign in into the [FontsManager](https://apireference.aspose.com/slides/java/com.aspose.slides/Presentation#getFontsManager--) of a certain presentation:  

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