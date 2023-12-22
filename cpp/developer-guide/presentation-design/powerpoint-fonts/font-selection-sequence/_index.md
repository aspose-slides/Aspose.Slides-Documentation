---
title: Font Selection Sequence in C++
linktitle: Font Selection Sequence in C++
type: docs
weight: 80
url: /cpp/font-selection-sequence/
keywords: "Font, Font selection, Font substitution, Font replacement, PowerPoint presentation, C++, CPP, Aspose.Slides for C++"
description: "PowerPoint font selection sequence in C++"
---

## Font Selection

Certain rules apply to fonts in a presentation when the presentation is loaded, rendered, or converted to another format. For example, when you try to convert a presentation (its slides) to images, the presentation's fonts are checked to verify that the chosen fonts are available in the operating system. If the fonts are confirmed to be missing, they are replaced—see [**Font Replacement**](https://docs.aspose.com/slides/cpp/font-replacement/) and [**Font Substitution**](https://docs.aspose.com/slides/cpp/font-substitution/).

This is the process Aspose.Slides follows when dealing with fonts:

1. Aspose.Slides searches for fonts in the operating system to find the font that matches the presentation's chosen font. 
2. If the chosen font is found, Aspose.Slides uses it. Otherwise, Aspose.Slides uses a replacement font that is as close as possible to what PowerPoint would use. 
3. If font replacement rules have been set through [FontSubstRule](https://reference.aspose.com/slides/cpp/aspose.slides/fontsubstrule/), they are applied. 

Aspose.Slides allows you to add fonts to Aspose runtime and then use those fonts. See [**Custom fonts**](https://docs.aspose.com/slides/cpp/custom-font/). 

When additional fonts are placed within a presentation, they are called [**Embedded fonts**](https://docs.aspose.com/slides/cpp/embedded-font/).



xxx. 

Aspose.Slides allows you to add fonts that are applied to *only* output documents. For example, if a presentation you are looking to convert to PDF contains fonts missing from your system and embedded fonts, you can add or load the needed fonts as **External fonts**. 

