---
title: Font Selection Sequence in Java
linktitle: Font Selection Sequence in Java
type: docs
weight: 80
url: /androidjava/font-selection-sequence/
keywords:
- font
- font selection
- font substitution
- font replacement
- PowerPoint presentation
- Java
- Aspose.Slides for Android via Java
description: PowerPoint font selection sequence in Java
---

## Font Selection

Certain rules apply to fonts in a presentation when the presentation is loaded, rendered, or converted to another format. For example, when you try to convert a presentation (its slides) to images, the presentation's fonts are checked to verify that the chosen fonts are available in the operating system. If the fonts are confirmed to be missing, they are replaced — see [**Font Replacement**](https://docs.aspose.com/slides/androidjava/font-replacement/) and [**Font Substitution**](https://docs.aspose.com/slides/androidjava/font-substitution/).

This is the process Aspose.Slides follows when dealing with fonts:

1. Aspose.Slides searches for fonts in the operating system to find the font that matches the presentation's chosen font. 
2. If the chosen font is found, Aspose.Slides uses it. Otherwise, Aspose.Slides uses a replacement font that is as close as possible to what PowerPoint would use.
3. If font replacement rules have been set through [FontSubstRule](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsubstrule/), they are applied.

Aspose.Slides allows you to add fonts to application runtime and then use those fonts. See [**Custom fonts**](https://docs.aspose.com/slides/androidjava/custom-font/).

When additional fonts are placed within a presentation, they are called [**Embedded fonts**](https://docs.aspose.com/slides/androidjava/embedded-font/).

Aspose.Slides allows you to add fonts that are applied to *only* output documents. For example, if a presentation you are looking to convert to PDF contains fonts missing from your system and embedded fonts, you can add or load the needed fonts as **external fonts**. 

{{% alert title="Note" color="primary" %}} 
We do not distribute any fonts, either paid or free. Our API allows you to load external fonts and embed them in documents, but you do so with fonts at your discretion and responsibility.
{{% /alert %}}
