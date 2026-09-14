---
title: Render Presentations with Fallback Fonts in Python via Java
linktitle: Render Presentations
type: docs
weight: 30
url: /python-java/render-presentation-with-fallback-font/
keywords:
- fallback font
- render PowerPoint
- render presentation
- render slide
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Render presentations with fallback fonts in Aspose.Slides for Python via Java – keep text consistent across PPT, PPTX, and ODP with step-by-step Python code samples."
---

## **Overview**

Aspose.Slides allows you to render presentations using fallback font rules. This article shows how to create a fallback font rules collection, modify its rules by removing or adding fallback fonts, and assign the collection using the [FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) method.

Once the fallback font rules collection is assigned to the presentation's [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/), the rules are applied during operations such as saving, rendering, and converting the presentation. The example demonstrates how to use the configured rules when rendering a slide thumbnail and saving it as a JPEG image.

## **Render a Slide Using Fallback Font Rules**

The following example includes these steps:

1. [Create a fallback font rules collection](/slides/python-java/create-fallback-fonts-collection/).
1. [Remove](https://reference.aspose.com/slides/python-java/aspose.slides/fontfallbackrule/#remove) a fallback font from a rule and [add fallback fonts](https://reference.aspose.com/slides/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) to another rule.
1. Assign the rules collection using [setFontFallBackRulesCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) on the font manager returned by [getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager).
1. Use the [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) method to save the presentation in the same format or another format. After the fallback font rules collection is assigned to [FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/), these rules are applied during operations on the presentation: saving, rendering, converting, and so on.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# Create a new rules collection.
fallback_rules = FontFallBackRulesCollection()

# Create several rules.
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # Try to remove the fallback font "Tahoma" from the rules.
    fallback_rule.remove("Tahoma")

    # Update the rules for the specified range.
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# Remove an existing rule, keeping at least one rule for rendering.
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # Assign the prepared rules collection.
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # Render a thumbnail using the configured rules collection.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Save the image to disk in JPEG format.
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Read more about how to [convert PPT and PPTX to JPG in Python via Java](/slides/python-java/convert-powerpoint-to-jpg/).
{{% /alert %}}
