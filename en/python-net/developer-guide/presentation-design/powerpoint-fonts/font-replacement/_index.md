---
title: Streamline Font Replacement in Presentations Using Python
linktitle: Font Replacement
type: docs
weight: 60
url: /python-net/font-replacement/
keywords:
- font
- replace font
- font replacement
- change font
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Seamlessly replace fonts in Aspose.Slides Python via .NET to ensure consistent typography in PowerPoint and OpenDocument presentations."
---

## **Replace Fonts**

If you change your mind about using a font, you can replace that font with another font. All instances of the old font will be replaced by the new font. 

Aspose.Slides allows you to replace a font this way:

1. Load the relevant presentation. 
2. Load the font that will be replaced.
3. Load the new font. 
4. Replace the font. 
5. Write the modified presentation as a PPTX file.

This Python code demonstrates font replacement:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

# Loads a presentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Loads the source font that will be replaced
    sourceFont = slides.FontData("Arial")

    # Loads the new font
    destFont = slides.FontData("Times New Roman")

    # Replaces the fonts
    presentation.fonts_manager.replace_font(sourceFont, destFont)

    # Saves the presentation
    presentation.save("UpdatedFont_out.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert title="Note" color="warning" %}} 

To set rules that determine what happens in certain conditions (if a font cannot be accessed, for example), see [**Font Substitution**](/slides/python-net/font-substitution/). 

{{% /alert %}}

## **FAQ**

**What is the difference between "font replacement", "font substitution", and "fallback fonts"?**

Replacement is an intentional switch from one family to another across the whole document. [Substitution](/slides/python-net/font-substitution/) is a rule like "if the font is unavailable, use X." [Fallback](/slides/python-net/fallback-font/) is applied surgically for individual missing glyphs when the base font is installed but does not contain the required characters.

**Does replacement apply to master slides, layouts, notes, and comments?**

Yes. Replacement affects all presentation objects that use the original font, including master slides and notes; comments are also part of the document and are taken into account by the font engine.

**Will the font change inside embedded OLE objects (for example, Excel)?**

No. [OLE content](/slides/python-net/manage-ole/) is controlled by its own application. Replacement in the presentation does not reformat the internal OLE data; it may be displayed as an image or as externally editable content.

**Can I replace a font only in part of the presentation (by slides or regions)?**

Targeted replacement is possible if you change the font at the level of the required objects/ranges rather than applying a global replacement to the entire document. The overall font selection logic during rendering remains the same.

**How can I determine in advance which fonts the presentation uses at all?**

Use the presentation’s [font manager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/): it provides a list of the [families in use](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/) and information about [substitutions/"unknown" fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/), which helps plan the replacement.

**Does font replacement work when converting to PDF/images?**

Yes. During export, Aspose.Slides applies the same [font selection/substitution sequence](/slides/python-net/font-selection-sequence/), so a replacement performed in advance will be honored during conversion.

**Do I need to install the target font in the system, or can I attach a fonts folder?**

Installation is not required: the library allows [loading external fonts](/slides/python-net/custom-font/) from user folders for use during [rendering and export](/slides/python-net/convert-powerpoint/).

**Will replacement fix "tofu" (squares) instead of characters?**

Only if the target font actually contains the required glyphs. If not, [configure fallback](/slides/python-net/fallback-font/) to cover the missing characters.
