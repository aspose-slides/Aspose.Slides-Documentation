---
title: Embedded Font
type: docs
weight: 40
url: /cpp/embedded-font/
---

## **Get or Remove Embedded Fonts from Presentation**
Now, you can also work with embedded fonts. FontsManger class now offers, GetEmbeddedFonts() method that returns a list of embedded fonts inside the presentation. You can also remove any embedded font inside presentation if that is required by using RemoveEmbeddedFont() method exposed by FontsManager class. The implementation of the above steps is given below.

```c#
// Instantiate a Presentation object that represents a presentation file
auto presentation = System::MakeObject<Presentation>(u"EmbeddedFonts.pptx");
// render a slide that contains a text frame that uses embedded "FunSized"
presentation->get_Slides()->idx_get(0)->GetThumbnail(Size(960, 720))->Save(u"picture1_out.png", ImageFormat::get_Png());

auto fontsManager = presentation->get_FontsManager();

// get all embedded fonts
auto embeddedFonts = fontsManager->GetEmbeddedFonts();

std::function<bool(SharedPtr<IFontData>)> comparer = [](SharedPtr<IFontData> data) -> bool
{
    return data->get_FontName() == u"Calibri";
};

// find "Calibri" font
auto funSizedEmbeddedFont = Array<SharedPtr<IFontData>>::Find(embeddedFonts, comparer);

// remove "Calibri" font
fontsManager->RemoveEmbeddedFont(funSizedEmbeddedFont);

// render the presentation; removed "Calibri" font is replaced to an existing one
presentation->get_Slides()->idx_get(0)->GetThumbnail(Size(960, 720))->Save(u"picture2_out.png", ImageFormat::get_Png());

// save the presentation without embedded "Calibri" font
presentation->Save(u"WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
```



## **Add Embedded Fonts to Presentation**
A new property of embedding fonts has been added. To allow embedding fonts into Presentation the new EmbedFontCharacters enum and two overloads of AddEmbeddedFont method have been added. Using these methods and choosing the desired embedding rule (represented by EmbedFontCharacters enum), all fonts used in the Presentation can be embedded. The implementation of the above steps is given below.

``` cpp
// Load presentation
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Load source font to be replaced
auto sourceFont = System::MakeObject<FontData>(u"Arial");

auto allFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (SharedPtr<IFontData> font : allFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&font](SharedPtr<IFontData> data) -> bool
    {
        return data == font;
    };

    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        presentation->get_FontsManager()->AddEmbeddedFont(font, EmbedFontCharacters::All);
    }
}

// Save the presentation
presentation->Save(u"AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
```
