---
title: Font Replacement
type: docs
weight: 60
url: /net/font-replacement/
keywords: "Font, replace font, PowerPoint presentation, C#, Csharp, Aspose.Slides for .NET"
description: "Replace fonts explicitly in PowerPoint in C# or .NET"
---

If you change your mind about using a font, you can replace that font with another font. All instances of the old font will be replaced by the new font. 

Aspose.Slides allows you to replace a font this way:

1. Load the relevant presentation. 
2. Load the font that will be replaced.
3. Load the new font. 
4. Replace the font. 
5. Write the modified presentation as a PPTX file.

This C# code demonstrates font replacement:

```c#
// Loads a presentation
Presentation presentation = new Presentation("Fonts.pptx");

// Loads the source font that will be replaced
IFontData sourceFont = new FontData("Arial");

// Loads the new font
IFontData destFont = new FontData("Times New Roman");

// Replaces the fonts
presentation.FontsManager.ReplaceFont(sourceFont, destFont);

// Saves the presentation
presentation.Save("UpdatedFont_out.pptx", SaveFormat.Pptx);
```

{{% alert title="Note" color="warning" %}} 

To set rules that determine what happens in certain conditions (if a font cannot be accessed, for example), see [**Font Substitution**](/slides/net/font-substitution/). 

{{% /alert %}}

