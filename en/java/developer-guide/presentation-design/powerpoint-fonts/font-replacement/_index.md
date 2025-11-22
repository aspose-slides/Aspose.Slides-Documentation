---
title: Streamline Font Replacement in Presentations Using Java
linktitle: Font Replacement
type: docs
weight: 60
url: /java/font-replacement/
keywords:
- font
- replace font
- font replacement
- change font
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Seamlessly replace fonts in Aspose.Slides for Java to ensure consistent typography in PowerPoint and OpenDocument presentations."
---

If you change your mind about using a font, you can replace that font with another font. All instances of the old font will be replaced by the new font. 

Aspose.Slides allows you to replace a font this way:

1. Load the relevant presentation. 
2. Load the font that will be replaced.
3. Load the new font. 
4. Replace the font. 
5. Write the modified presentation as a PPTX file.

This Java code demonstrates font replacement:

```java
// Loads a presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Loads the source font that will be replaced
    IFontData sourceFont = new FontData("Arial");
    
    // Loads the new font
    IFontData destFont = new FontData("Times New Roman");
    
    // Replaces the fonts
    pres.getFontsManager().replaceFont(sourceFont, destFont);
    
    // Saves the presentation
    pres.save("UpdatedFont_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

To set rules that determine what happens in certain conditions (if a font cannot be accessed, for example), see [**Font Substitution**](/slides/java/font-substitution/). 

{{% /alert %}}
