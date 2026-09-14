---
title: Font Selection Sequence in Aspose.Slides for Python via Java
linktitle: Font Selection
type: docs
weight: 80
url: /python-java/font-selection-sequence/
keywords:
- font selection
- font substitution
- font replacement
- substitution rule
- available font
- missing font
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Discover how Aspose.Slides for Python via Java selects fonts, ensuring crisp, consistent presentation of PPT, PPTX and ODP files—improve your slides now."
---

## **Overview**

When a presentation is loaded, rendered, or converted to another format, Aspose.Slides checks whether the fonts used in the presentation are available in the operating system. If a required font is missing, Aspose.Slides selects a replacement font that is as close as possible to the one PowerPoint would use.

Aspose.Slides first searches for the selected font in the operating system. If the font is found, it is used. If it is not found, a suitable replacement is applied. When font substitution rules are defined through [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/), those rules are also taken into account.

You can also add fonts at application runtime, use embedded fonts from a presentation, or load external fonts for output documents such as PDF files.

## **Font Selection**

Certain rules apply to fonts in a presentation when the presentation is loaded, rendered, or converted to another format. For example, when you try to convert a presentation (its slides) to images, the presentation's fonts are checked to verify that the chosen fonts are available in the operating system. If the fonts are confirmed to be missing, they are replaced — see [Font Replacement](/slides/python-java/font-replacement/) and [Font Substitution](/slides/python-java/font-substitution/).

This is the process Aspose.Slides follows when dealing with fonts:

1. Aspose.Slides searches for fonts in the operating system to find the font that matches the presentation's chosen font.
2. If the chosen font is found, Aspose.Slides uses it. Otherwise, Aspose.Slides uses a replacement font that is as close as possible to what PowerPoint would use.
3. If font replacement rules have been set through [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/), they are applied.

Aspose.Slides allows you to add fonts at application runtime and then use those fonts. See [Custom fonts](/slides/python-java/custom-font/).

When additional fonts are placed within a presentation, they are called [Embedded fonts](/slides/python-java/embedded-font/).

Aspose.Slides allows you to add fonts that are applied *only* to output documents. For example, if a presentation you are looking to convert to PDF uses fonts that are neither installed on your system nor embedded in the presentation, you can add or load the needed fonts as **external fonts**.

{{% alert title="Note" color="info" %}}
We do not distribute any fonts, either paid or free. Our API allows you to load external fonts and embed them in documents, but you do so at your own discretion and responsibility.
{{% /alert %}}

## **FAQ**

**How can I determine which fonts are actually used in a presentation before conversion?**

Aspose.Slides lets you inspect the fonts used via the [font manager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/), so you can decide whether to [embed](/slides/python-java/embedded-font/), [replace](/slides/python-java/font-replacement/), or add [external sources](/slides/python-java/custom-font/). This helps you prevent unwanted substitutions during rendering and export.

**Can I add extra font directories without installing them on the operating system?**

Yes. You can register [external font sources](/slides/python-java/custom-font/) such as folders or in-memory streams for rendering and export. This removes dependency on host system fonts and keeps layout predictable.

**How do I prevent a silent fallback to an unsuitable font when a glyph is missing?**

Define explicit [font replacement](/slides/python-java/font-replacement/) and font [fallback rules](/slides/python-java/fallback-font/) in advance. By analyzing used fonts and setting a controlled priority for substitutes, you ensure consistent typography and avoid unexpected results.
