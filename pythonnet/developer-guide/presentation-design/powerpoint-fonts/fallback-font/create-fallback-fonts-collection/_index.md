---
title: Create Fallback Fonts Collection
type: docs
weight: 20
url: /pythonnet/create-fallback-fonts-collection/
keywords: "Fallback fonts collection, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Fallback fonts collection in PowerPoint in Python"
---

Instances of [FontFallBackRule](https://apireference.aspose.com/slides/pythonnet/aspose.slides/FontFallBackRule) class can be organized into [FontFallBackRulesCollection](https://apireference.aspose.com/slides/pythonnet/aspose.slides/fontfallbackrulescollection), that implements [IFontFallBackRulesCollection](https://apireference.aspose.com/slides/pythonnet/aspose.slides/ifontfallbackrulescollection) interface. It is possible to add or remove rules from the collection.

Then this collection may be assigned to [FontFallBackRulesCollection ](https://apireference.aspose.com/slides/pythonnet/aspose.slides/fontsmanager/properties/fontfallbackrulescollection)property of the [FontsManager](https://apireference.aspose.com/slides/pythonnet/aspose.slides/fontsmanager) class. FontsManager controls fonts across the presentation. Read more [About FontsManager and FontsLoader](/slides/pythonnet/about-fontsmanager-and-fontsloader/).

Each [Presentation ](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation)has a [FontsManager ](https://apireference.aspose.com/slides/pythonnet/aspose.slides/presentation/properties/fontsmanager)property with its own instance of the FontsManager class.

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
Read more how to [Render Presentation with Fallback Font](/slides/pythonnet/render-presentation-with-fallback-font/).
{{% /alert %}}

