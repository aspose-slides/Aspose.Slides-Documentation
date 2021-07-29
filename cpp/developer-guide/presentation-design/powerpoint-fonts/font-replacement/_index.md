---
title: Font Replacement
type: docs
weight: 60
url: /cpp/font-replacement/
---

## **Replacing Fonts Explicitly**
To replace the fonts using explicit replacement following steps are used:

- Load the desired presentation.
- Load the font that is to replace inside the presentation.
- Load the replacing font.
- Replace the fonts.
- Write the modified presentation as a PPTX file.

The implementation of the above steps is given below.

``` cpp
// Load presentation
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Load source font to be replaced
auto sourceFont = System::MakeObject<FontData>(u"Arial");

// Load the replacing font
auto destFont = System::MakeObject<FontData>(u"Times New Roman");

// Replace the fonts
presentation->get_FontsManager()->ReplaceFont(sourceFont, destFont);

// Save the presentation
presentation->Save(u"UpdatedFont_out.pptx", SaveFormat::Pptx);
```
