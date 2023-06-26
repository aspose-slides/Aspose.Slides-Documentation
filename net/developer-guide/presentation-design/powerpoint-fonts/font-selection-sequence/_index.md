---
title: Font Selection Sequence in C#
linktitle: Font Selection Sequence in C#
type: docs
weight: 80
url: /net/font-selection-sequence/
keywords: "Font, Font selection, Font substitution, Font replacement, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: Font selection sequence in C#
---

## Font Selection

Certain rules apply to fonts in a presentation when the presentation is loaded, rendered, or converted to another format. For example, when you try to convert a presentation (its slides) to images, the presentation's fonts are checked to verify that the chosen fonts are available in the operating system. If the fonts are confirmed to be missing, they are replaced--see [**Font Replacement**](https://docs.aspose.com/slides/net/font-replacement/) and [**Font substitution**](https://docs.aspose.com/slides/net/font-substitution/).

This is the process Aspose.Slides follows when dealing with fonts:

1. Aspose.Slides searches for fonts in the operating system to find the font that matches the presentation's chosen font.
2. When the default font is available but lacks an important glyph, Aspose.Slides uses a fallback font as the glyph replacement. 
3. If Aspose.Slides fails to find the default font, it uses the specified replacement font.

Aspose.Slides allows you to add fonts to Aspose runtime and then use those fonts. See [**Custom fonts**](https://docs.aspose.com/slides/net/custom-font/). When those additional fonts are placed within the presentation files, they are called [**Embedded fonts.**](https://docs.aspose.com/slides/net/embedded-font/)

Aspose.Slides allows that to add fonts that are applied to *only* output documents. For example, if a presentation you are looking to convert to PDF contains fonts missing from operating system and embedded fonts, you can add or load the needed fonts as **External fonts**. 


