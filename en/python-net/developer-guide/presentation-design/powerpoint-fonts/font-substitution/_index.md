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

## **Set Substitution Rules**

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

## **FAQ**

**What is the difference between font replacement and font substitution?**

[Replacement](/slides/python-net/font-replacement/) is a forced override of one font with another across the entire presentation. Substitution is a rule that triggers under a specific condition, for example when the original font is unavailable, and then a designated fallback font is used.

**When exactly are substitution rules applied?**

The rules participate in the standard [font selection](/slides/python-net/font-selection-sequence/) sequence that is evaluated during loading, rendering, and conversion; if the chosen font is unavailable, replacement or substitution is applied.

**What is the default behavior if neither replacement nor substitution is configured and the font is missing on the system?**

The library will try to pick the closest available system font, similar to how PowerPoint would behave.

**Can I attach custom external fonts at runtime to avoid substitution?**

Yes. You can [add external fonts](/slides/python-net/custom-font/) at runtime so the library considers them for selection and rendering, including for subsequent conversions.

**Does Aspose distribute any fonts with the library?**

No. Aspose does not distribute paid or free fonts; you add and use fonts at your own discretion and responsibility.

**Are there differences in substitution behavior on Windows, Linux, and macOS?**

Yes. Font discovery starts from the operating system’s font directories. The set of default available fonts and the search paths differ across platforms, which affects availability and the need for substitution.

**How should I prepare the environment to minimize unexpected substitution during batch conversions?**

Synchronize the font set across machines or containers, [add the external fonts](/slides/python-net/custom-font/) required for the output documents, and [embed fonts](/slides/python-net/embedded-font/) in presentations when possible so the chosen fonts are available during rendering.
