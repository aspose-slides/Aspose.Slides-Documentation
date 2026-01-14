---
title: Configure Fallback Font Collections in Python
linktitle: Fallback Font Collection
type: docs
weight: 20
url: /python-net/create-fallback-fonts-collection/
keywords:
- fallback font
- fallback rule
- font collection
- configure font
- set up font
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Set up a fallback fonts collection in Aspose.Slides for Python via .NET to keep text consistent and crisp in PowerPoint and OpenDocument presentations."
---

## **Apply Fallback Rules**

Instances of [FontFallBackRule](https://reference.aspose.com/slides/python-net/aspose.slides/FontFallBackRule/) class can be organized into [FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrulescollection/). It is possible to add or remove rules from the collection.

Then this collection may be assigned to [font_fall_back_rules_collection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_fall_back_rules_collection/) property of the [FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) class. FontsManager controls fonts across the presentation. Read more [About FontsManager and FontsLoader](/slides/python-net/about-fontsmanager-and-fontsloader/).

Each [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) has a [fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) property with its own instance of the FontsManager class.

Here is an examples how to create fallback fonts rules collection and assign in into the FontsManager of a certain presentation:  

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
	userRulesList = slides.FontFallBackRulesCollection()

	userRulesList.add(slides.FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"))
	userRulesList.add(slides.FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"))

	presentation.fonts_manager.font_fall_back_rules_collection = userRulesList
```

After FontsManager is initialised with fallback fonts collection, the fallback fonts are applied during presentation rendering.

{{% alert color="primary" %}} 
Read more how to [Render Presentation with Fallback Font](/slides/python-net/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Will my fallback rules be embedded into the PPTX file and visible in PowerPoint after saving?**

No. Fallback rules are runtime rendering settings; they are not serialized into PPTX and will not appear in PowerPoint's UI.

**Does fallback apply to text inside SmartArt, WordArt, charts, and tables?**

Yes. The same glyph-substitution mechanism is used for any text in these objects.

**Does Aspose distribute any fonts with the library?**

No. You add and use fonts on your side and under your own responsibility.

**Can replacement/substitution for missing fonts and fallback for missing glyphs be used together?**

Yes. They are independent stages of the same font-resolution pipeline: first the engine resolves font availability ([replacement](/slides/python-net/font-replacement/)/[substitution](/slides/python-net/font-substitution/)), then fallback fills gaps for missing glyphs in available fonts.
