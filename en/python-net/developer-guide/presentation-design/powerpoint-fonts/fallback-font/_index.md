---
title: Manage Fallback Fonts for Presentations in Python
linktitle: Fallback Font
type: docs
weight: 50
url: /python-net/fallback-font/
keywords:
- fallback font
- available font
- glyph replacement
- specify font
- specify rule
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "See how Aspose.Slides for Python via .NET uses fallback fonts to keep text readable in PowerPoint and OpenDocument presentations when original fonts aren’t available."
---

## **Fallback Font**
Fallback font is used when the font specified for text is available in the system, but this font does not contain a necessary glyph. In this case, it is possible to use one of the specified fallback fonts for the glyph replacement.

Aspose.Slides allows to create fallback fonts, add them to fallback fonts collection, set fallback font collection for a certain presentation, remove fallback fonts from presentation, specify the rules to apply fallback fonts and others.

To get familiar with these features, use the following links:

- [Create Fallback Font](/slides/python-net/create-fallback-font)
- [Create Fallback Fonts Collection](/slides/python-net/create-fallback-fonts-collection)
- [Render Presentation with Fallback Font](/slides/python-net/render-presentation-with-fallback-font)

## **FAQ**

**How do fallback fonts differ from font substitution?**

Fallback is applied per character or per range of Unicode when the primary font lacks specific glyphs; it fills just the missing characters. [Substitution](/slides/python-net/font-substitution/) replaces a missing or unavailable font for an entire run or text portion with another font. They can be combined, but their scope and selection logic are different.

**Are fallback settings saved inside the presentation file?**

No. Fallback configuration lives at processing/rendering time in the library and is not serialized into the PPTX. The presentation does not store your fallback rules.

**Does fallback affect elements created by PowerPoint objects (SmartArt, charts, WordArt)?**

Yes. Text inside these objects goes through the same rendering pipeline, so the same fallback rules apply to it as to regular text.
