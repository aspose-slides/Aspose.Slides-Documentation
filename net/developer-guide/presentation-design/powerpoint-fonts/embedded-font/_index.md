---
title: Embedded Font
type: docs
weight: 40
url: /net/embedded-font/
---

## **Get or Remove Embedded Fonts from Presentation**
Now, you can also work with embedded fonts. FontsManger class now offer, GetEmbeddedFonts() method that returns a list of embedded fonts inside the presentation. You can also remove any embedded font inside presentation if that is required by using RemoveEmbeddedFont() method exposed by FontsManager class. The implementation of the above steps is given below.

```c#
// Instantiate a Presentation object that represents a presentation file
using (Presentation presentation = new Presentation("EmbeddedFonts.pptx"))
{
    // render a slide that contains a text frame that uses embedded "FunSized"
    presentation.Slides[0].GetThumbnail(new Size(960, 720)).Save("picture1_out.png", ImageFormat.Png);

    IFontsManager fontsManager = presentation.FontsManager;

    // get all embedded fonts
    IFontData[] embeddedFonts = fontsManager.GetEmbeddedFonts();

    // find "Calibri" font
    IFontData funSizedEmbeddedFont = Array.Find(embeddedFonts, delegate(IFontData data)
    {
        return data.FontName == "Calibri";
    });

    // remove "Calibri" font
    fontsManager.RemoveEmbeddedFont(funSizedEmbeddedFont);

    // render the presentation; removed "Calibri" font is replaced to an existing one
    presentation.Slides[0].GetThumbnail(new Size(960, 720)).Save("picture2_out.png", ImageFormat.Png);

    // save the presentation without embedded "Calibri" font
    presentation.Save("WithoutManageEmbeddedFonts_out.ppt", SaveFormat.Ppt);
}
```



## **Add Embedded Fonts to Presentation**
A new property of embedding fonts has been added. To allow embedding fonts into Presentation the new EmbedFontCharacters enum and two overloads of AddEmbeddedFont method have been added. Using these methods and choosing the desired embedding rule (represented by EmbedFontCharacters enum), all fonts used in the Presentation can be embedded. The implementation of the above steps is given below.

```c#
// Load presentation
Presentation presentation = new Presentation("Fonts.pptx");

// Load source font to be replaced
IFontData sourceFont = new FontData("Arial");


IFontData[] allFonts = presentation.FontsManager.GetFonts();
IFontData[] embeddedFonts = presentation.FontsManager.GetEmbeddedFonts();
foreach (IFontData font in allFonts)
{
    if (!embeddedFonts.Contains(font))
    {
        presentation.FontsManager.AddEmbeddedFont(font, EmbedFontCharacters.All);
    }
}

// Save the presentation
presentation.Save("AddEmbeddedFont_out.pptx", SaveFormat.Pptx);
```

