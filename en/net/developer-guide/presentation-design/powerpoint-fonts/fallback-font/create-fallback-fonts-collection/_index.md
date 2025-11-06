---
title: Create Fallback Fonts Collection
type: docs
weight: 20
url: /net/create-fallback-fonts-collection/
keywords: "Fallback fonts collection, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Fallback fonts collection in PowerPoint in C# or .NET"
---

## **Apply Fallback Rules**

Instances of [FontFallBackRule](https://reference.aspose.com/slides/net/aspose.slides/FontFallBackRule) class can be organized into [FontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/fontfallbackrulescollection), that implements [IFontFallBackRulesCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontfallbackrulescollection) interface. It is possible to add or remove rules from the collection.

Then this collection may be assigned to [FontFallBackRulesCollection ](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)property of the [FontsManager](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager) class. FontsManager controls fonts across the presentation. Read more [About FontsManager and FontsLoader](/slides/net/about-fontsmanager-and-fontsloader/).

Each [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)has a [FontsManager ](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/fontsmanager)property with its own instance of the FontsManager class.

Here is an examples how to create fallback fonts rules collection and assign in into the FontsManager of a certain presentation:  

```c#
using (Presentation presentation = new Presentation())
{
	IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

	userRulesList.Add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
	userRulesList.Add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

	presentation.FontsManager.FontFallBackRulesCollection = userRulesList;
}
```

After FontsManager is initialised with fallback fonts collection, the fallback fonts are applied during presentation rendering.

{{% alert color="primary" %}} 
Read more how to [Render Presentation with Fallback Font](/slides/net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Will my fallback rules be embedded into the PPTX file and visible in PowerPoint after saving?**

No. Fallback rules are runtime rendering settings; they are not serialized into PPTX and will not appear in PowerPoint's UI.

**Does fallback apply to text inside SmartArt, WordArt, charts, and tables?**

Yes. The same glyph-substitution mechanism is used for any text in these objects.

**Does Aspose distribute any fonts with the library?**

No. You add and use fonts on your side and under your own responsibility.

**Can replacement/substitution for missing fonts and fallback for missing glyphs be used together?**

Yes. They are independent stages of the same font-resolution pipeline: first the engine resolves font availability ([replacement](/slides/net/font-replacement/)/[substitution](/slides/net/font-substitution/)), then fallback fills gaps for missing glyphs in available fonts.
