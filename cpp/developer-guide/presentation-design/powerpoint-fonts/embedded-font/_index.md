---
title: Embedded Font
type: docs
weight: 40
url: /cpp/embedded-font/
keywords: "Fonts, embedded fonts, add fonts, PowerPoint presentation C++, CPP, Aspose.Slides for C++"
description: "Use embedded fonts in PowerPoint presentation in C++"
---

**Embedded fonts in PowerPoint** are useful when you want your presentation to appear correctly when opened on any system or device. If you used a third-party or non-standard font because you got creative with your work, then you have even more reasons to embed your font. Otherwise (without embedded fonts), the texts or numbers on your slides, the layout, styling, etc. may change or turn into confusing rectangles. 

The [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) class, [FontData](https://reference.aspose.com/slides/cpp/aspose.slides/fontdata/) class, [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) class, and their interfaces contain most of the properties and methods you need to work with embedded fonts in PowerPoint presentations. 

## **Get or Remove Embedded Fonts from Presentation**

Aspose.Slides provides the [GetEmbeddedFonts()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/getembeddedfonts/) method (exposed by the [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) class) to allow you to get (or find out) the fonts embedded in a presentation. To remove fonts, the [RemoveEmbeddedFont()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/removeembeddedfont/) method (exposed by the same class) is used.

This C++ code shows you how to get and remove embedded fonts from a presentation:

```c++
// Instantiates a Presentation object that represents a presentation file
auto presentation = System::MakeObject<Presentation>(u"EmbeddedFonts.pptx");
// Renders a slide containing a text frame that uses embedded "FunSized"
presentation->get_Slides()->idx_get(0)->GetThumbnail(Size(960, 720))->Save(u"picture1_out.png", ImageFormat::get_Png());

auto fontsManager = presentation->get_FontsManager();

// Gets all embedded fonts
auto embeddedFonts = fontsManager->GetEmbeddedFonts();

std::function<bool(SharedPtr<IFontData>)> comparer = [](SharedPtr<IFontData> data) -> bool
{
    return data->get_FontName() == u"Calibri";
};

// Finds the "Calibri" font
auto funSizedEmbeddedFont = Array<SharedPtr<IFontData>>::Find(embeddedFonts, comparer);

// Removes "Calibri" font
fontsManager->RemoveEmbeddedFont(funSizedEmbeddedFont);

// Renders the presentation; "Calibri" font is replaced with an existing one
presentation->get_Slides()->idx_get(0)->GetThumbnail(Size(960, 720))->Save(u"picture2_out.png", ImageFormat::get_Png());

// Saves the presentation without embedded "Calibri" font to disk
presentation->Save(u"WithoutManageEmbeddedFonts_out.ppt", SaveFormat::Ppt);
```

## **Add Embedded Fonts to Presentation**

Using the [EmbedFontCharacters](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedfontcharacters/) enum and two overloads of the [AddEmbeddedFont()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/addembeddedfont/) method, you can select your preferred (embedding) rule to embed the fonts in a presentation. This C++ code shows you how to embed and add fonts to a presentation:

```c++
// Loads the presentation
auto presentation = System::MakeObject<Presentation>(u"Fonts.pptx");

// Loads the source font to be replaced
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

// Saves the presentation to disk
presentation->Save(u"AddEmbeddedFont_out.pptx", SaveFormat::Pptx);
```

## **Compress Embedded Fonts**

To allow you to compress the fonts embedded in a presentation and reduce its file size, Aspose.Slides provides the [CompressEmbeddedFonts()](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) method (exposed by the [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) class).

This C++ code shows you how to compress embedded PowerPoint fonts:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

Aspose::Slides::LowCode::Compress::CompressEmbeddedFonts(pres);
pres->Save(u"pres-out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

