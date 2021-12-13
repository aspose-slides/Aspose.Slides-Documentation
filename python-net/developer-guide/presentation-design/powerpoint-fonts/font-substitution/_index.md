---
title: Font Substitution
type: docs
weight: 70
url: /python-net/font-substitution/
keywords: "Font, substitute font, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Substitute font in PowerPoint in Python"
---

## **Rule Based Font Substitution**
To replace the fonts by setting some rules of replacement following steps are used:

- Load the desired presentation.
- Load the font that is to replaced inside the presentation.
- Load the replacing font.
- Add rule for replacement.
- Add the rule to presentation font replacement rule collection.
- Generate the slide image to observe the effect.

The implementation of the above steps is given below.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Load presentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Load source font to be replaced
    sourceFont = slides.FontData("SomeRareFont")

    # Load the replacing font
    destFont = slides.FontData("Arial")

    # Add font rule for font replacement
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Add rule to font substitute rules collection
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Add font rule collection to rule list
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    # Arial font will be used instead of SomeRareFont when inaccessible
    bmp = presentation.slides[0].get_thumbnail(1, 1)

    # Save the image to disk in JPEG format
    bmp.save("Thumbnail_out.jpg", draw.imaging.ImageFormat.jpeg)
```

