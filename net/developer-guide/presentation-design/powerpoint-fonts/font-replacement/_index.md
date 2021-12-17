---
title: Font Replacement
type: docs
weight: 60
url: /net/font-replacement/
keywords: "Font, replace font, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Replace fonts explicitly in PowerPoint in C# or .NET"
---

## **Replacing Fonts Explicitly**
To replace the fonts using explicit replacement following steps are used:

- Load the desired presentation.
- Load the font that is to replace inside the presentation.
- Load the replacing font.
- Replace the fonts.
- Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

```c#
// Load presentation
Presentation presentation = new Presentation("Fonts.pptx");

// Load source font to be replaced
IFontData sourceFont = new FontData("Arial");

// Load the replacing font
IFontData destFont = new FontData("Times New Roman");

// Replace the fonts
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// Save the presentation
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

