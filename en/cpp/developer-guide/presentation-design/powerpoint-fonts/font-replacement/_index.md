---
title: Streamline Font Replacement in Presentations Using С++
linktitle: Font Replacement
type: docs
weight: 60
url: /cpp/font-replacement/
keywords:
- font
- replace font
- font replacement
- change font
- PowerPoint
- OpenDocument
- presentation
- С++
- Aspose.Slides
description: "Seamlessly replace fonts in Aspose.Slides for С++ to ensure consistent typography in PowerPoint and OpenDocument presentations."
---

If you change your mind about using a font, you can replace that font with another font. All instances of the old font will be replaced by the new font. 

Aspose.Slides allows you to replace a font this way:

1. Load the relevant presentation. 
2. Load the font that will be replaced.
3. Load the new font. 
4. Replace the font. 
5. Write the modified presentation as a PPTX file.

This C++ code demonstrates font replacement:

``` cpp
// Loads a presentation
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Loads the source font that will be replaced
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Loads the new font
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Replaces the fonts
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Saves the presentation
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

To set rules that determine what happens in certain conditions (if a font cannot be accessed, for example), see [**Font Substitution**](/slides/cpp/font-substitution/). 

{{% /alert %}}
