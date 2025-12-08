---
title: Font Selection Sequence in Aspose.Slides for PHP
linktitle: Font Selection
type: docs
weight: 80
url: /php-java/font-selection-sequence/
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
- PHP
- Aspose.Slides
description: "Discover how Aspose.Slides for PHP via Java selects fonts, ensuring crisp, consistent presentation of PPT, PPTX and ODP files — improve your slides now."
---

## Font Selection

Certain rules apply to fonts in a presentation when the presentation is loaded, rendered, or converted to another format. For example, when you try to convert a presentation (its slides) to images, the presentation's fonts are checked to verify that the chosen fonts are available in the operating system. If the fonts are confirmed to be missing, they are replaced—see [**Font Replacement**](https://docs.aspose.com/slides/php-java/font-replacement/) and [**Font Substitution**](https://docs.aspose.com/slides/php-java/font-substitution/).

This is the process Aspose.Slides follows when dealing with fonts:

1. Aspose.Slides searches for fonts in the operating system to find the font that matches the presentation's chosen font. 
2. If the chosen font is found, Aspose.Slides uses it. Otherwise, Aspose.Slides uses a replacement font that is as close as possible to what PowerPoint would use. 
3. If font replacement rules have been set through [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/), they are applied.

Aspose.Slides allows you to add fonts to Aspose runtime and then use those fonts. See [**Custom fonts**](https://docs.aspose.com/slides/php-java/custom-font/).

When additional fonts are placed within a presentation, they are called [**Embedded fonts**](https://docs.aspose.com/slides/php-java/embedded-font/).

Aspose.Slides allows you to add fonts that are applied to *only* output documents. For example, if a presentation you are looking to convert to PDF contains fonts missing from your system and embedded fonts, you can add or load the needed fonts as **External fonts**. 

