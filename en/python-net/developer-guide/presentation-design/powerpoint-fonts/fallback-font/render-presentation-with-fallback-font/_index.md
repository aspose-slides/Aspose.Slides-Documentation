---
title: Render Presentations with Fallback Fonts in Python
linktitle: Render Presentations
type: docs
weight: 30
url: /python-net/render-presentation-with-fallback-font/
keywords:
- fallback font
- render PowerPoint
- render presentation
- render slide
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Render presentations with fallback fonts in Aspose.Slides for Python via .NET – keep text consistent across PPT, PPTX and ODP with step-by-step code samples."
---

The following example includes these steps:

1. We [create fallback font rules collection](/slides/python-net/create-fallback-fonts-collection/).
1. [Remove()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) a fallback font rule and [AddFallBackFonts()](https://reference.aspose.com/slides/python-net/aspose.slides/fontfallbackrule/) to another rule.
1. Set rules collection to [FontsManager.FontFallBackRulesCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) property.
1. With [Presentation.Save()](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) method we can save presentation in the same format, or save it in another one. After fallback font rules collection is set to FontsManager, these rules are applied during any operations over the presentation: save, render, convert, etc.

```py
import aspose.slides as slides

# Create new instance of a rules collection
rulesList = slides.FontFallBackRulesCollection()

# create a number of rules
rulesList.add(slides.FontFallBackRule(0x400, 0x4FF, "Times New Roman"))

for fallBackRule in rulesList:
	#Trying to remove FallBack font "Tahoma" from loaded rules
	fallBackRule.remove("Tahoma")

	#And to update of rules for specified range
	if fallBackRule.range_end_index >= 0x4000 and fallBackRule.range_start_index < 0x5000:
		fallBackRule.add_fall_back_fonts("Verdana")

#Also we can remove any existing rules from list
if len(rulesList) > 0:
	rulesList.remove(rulesList[0])

with slides.Presentation(path + "input.pptx") as pres:
	#Assigning a prepared rules list for using
	pres.fonts_manager.font_fall_back_rules_collection = rulesList

	# Rendering of thumbnail with using of initialized rules collection and saving to PNG
	with pres.slides[0].get_image(1, 1) as img:
		img.save("Slide_0.png", slides.ImageFormat.PNG)
```


{{% alert color="primary" %}} 
Read more about [Save and Convertion in Presentation](/slides/python-net/creating-saving-and-converting-a-presentation/).
{{% /alert %}}