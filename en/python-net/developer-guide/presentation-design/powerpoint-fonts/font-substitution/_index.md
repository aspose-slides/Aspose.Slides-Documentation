---
title: Configure Font Substitution in Presentations with Python
linktitle: Font Substitution
type: docs
weight: 70
url: /python-net/font-substitution/
keywords:
- font
- substitute font
- font substitution
- replace font
- font replacement
- substitution rule
- replacement rule
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Enable optimal font substitution in Aspose.Slides for Python via .NET when converting PowerPoint & OpenDocument presentations to other file formats."
---

Aspose.Slides allows you to set rules for fonts that determines what must be done in certain conditions (for example, when a font cannot be accessed) this way:

1. Load the relevant presentation.
2. Load the font that will be replaced.
3. Load the new font.
4. Add a rule for the replacement.
5. Add the rule to the presentation font replacement rule collection.
6. Generate the slide image to observe the effect.

This Python code demonstrates the font substitution process:

```python
import aspose.slides as slides

# Loads a presentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Loads the source font that will be replaced
    sourceFont = slides.FontData("SomeRareFont")

    # Load the new font
    destFont = slides.FontData("Arial")

    # Adds a font rule for font replacement
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Adds the rule to font substitute rules collection
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Adds the font rule collection to rule list
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    #Arial font will be used in place of SomeRareFont when the latter is inaccessible
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Saves the image to disk in the JPEG format
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="NOTE"  color="warning"   %}} 

You may want to see [**Font Replacement**](/slides/python-net/font-replacement/). 

{{% /alert %}}
