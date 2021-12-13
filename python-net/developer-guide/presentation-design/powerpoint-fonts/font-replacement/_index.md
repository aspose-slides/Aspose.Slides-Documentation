---
title: Font Replacement
type: docs
weight: 60
url: /python-net/font-replacement/
keywords: "Font, replace font, PowerPoint presentation, Python, Aspose.Slides for Python via .NET"
description: "Replace fonts explicitly in PowerPoint in Python"
---

## **Replacing Fonts Explicitly**
To replace the fonts using explicit replacement following steps are used:

- Load the desired presentation.
- Load the font that is to replace inside the presentation.
- Load the replacing font.
- Replace the fonts.
- Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Load presentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Load source font to be replaced
    sourceFont = slides.FontData("Arial")

    # Load the replacing font
    destFont = slides.FontData("Times New Roman")

    # Replace the fonts
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Save the presentation
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

