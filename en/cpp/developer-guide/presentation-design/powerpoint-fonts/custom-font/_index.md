---
title: Customize PowerPoint Fonts in С++
linktitle: Custom Font
type: docs
weight: 20
url: /cpp/custom-font/
keywords:
- font
- custom font
- external font
- load font
- manage fonts
- font folder
- PowerPoint
- OpenDocument
- presentation
- С++
- Aspose.Slides
description: "Customize fonts in PowerPoint slides with Aspose.Slides for С++ to keep your presentations sharp and consistent across any device."
---

{{% alert color="primary" %}} 

Aspose Slides allows you to load these fonts using [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/):

* TrueType (.ttf) and TrueType Collection (.ttc) fonts. See [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) fonts. See [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides allows you to load fonts that are rendered in presentations without having to install those fonts. The fonts are loaded from a custom directory. 

1. Create an instance of the [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) class and call the [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/)  method.
2. Load the presentation that will be rendered.
3. Clear the cache in the [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) class.

This C++ code demonstrates the font loading process:

``` cpp
const String fontPath = u"../templates/";
const String outPath = u"../out/UseCustomFonts_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";

// Sets the fonts path
ArrayPtr<String> folders = System::MakeObject<Array<String>>(1, fontPath);

// Loads the custom font directory fonts
FontsLoader::LoadExternalFonts(folders);

// Do some work and perform presentation/slide rendering
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);
pres->Save(outPath, Export::SaveFormat::Pptx);

// Clears Font Cache
FontsLoader::ClearCache();
```

## **Get Custom Fonts Folder**
Aspose.Slides provides [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) to allow you to find font folders. This method returns folders added through the `LoadExternalFonts` method and system font folders.

This C++ code shows you how to use [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) method:

``` cpp
// This line outputs the folders that are checked for font files.
// Those are folders added through the LoadExternalFonts method and system font folders.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Specify Custom Fonts Used With Presentation**
Aspose.Slides provides the [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) property to allow you to specify external fonts that will be used with the presentation.

This C++  code shows you how to use the [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/) property:

``` cpp
auto memoryFont1 = File::ReadAllBytes(u"customfonts\\CustomFont1.ttf");
auto memoryFont2 = File::ReadAllBytes(u"customfonts\\CustomFont2.ttf");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_DocumentLevelFontSources()->set_FontFolders(System::MakeArray<String>({u"assets\\fonts", u"global\\fonts"}));
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(System::MakeArray<ArrayPtr<uint8_t>>({memoryFont1, memoryFont2}));
{
    auto presentation = System::MakeObject<Presentation>(u"MyPresentation.pptx", loadOptions);
    //work with the presentation
    //CustomFont1, CustomFont2 as well as fonts from assets\fonts & global\fonts folders and their subfolders are available to the presentation
}
```

## **Manage Fonts Externally**
Aspose.Slides provides the [FontsLoader::LoadExternalFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfont/) method to allow you to load external fonts into a byte array.

This C++ code demonstrates the byte array font loading process:

```cpp
// The path to the documents directory
const String outPath = u"../out/SpecifyFontsUsedWithPresentation.pptx";
const String templatePath = u"../templates/AccessSlides.pptx";

ArrayPtr<String> fontsLocation =  MakeArray<System::String>({ u"assets\\fonts", u"global\\fonts" });// ;
ArrayPtr<ArrayPtr<uint8_t>> memoryfontsLocation = MakeArray < ArrayPtr<uint8_t>>({ File::ReadAllBytes(u"../templates/CustomFont1.ttf"), File::ReadAllBytes(u"../templates/CustomFont2.ttf") });

SharedPtr < Aspose::Slides::LoadOptions > loadOptions = MakeObject <Aspose::Slides::LoadOptions>();

loadOptions->get_DocumentLevelFontSources()->set_FontFolders(fontsLocation);
loadOptions->get_DocumentLevelFontSources()->set_MemoryFonts(memoryfontsLocation);
	
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath, loadOptions);
```

