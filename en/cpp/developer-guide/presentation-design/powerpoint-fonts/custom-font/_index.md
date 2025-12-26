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

Aspose.Slides allows you to load fonts used in a presentation without installing them on the system. This affects export output—such as PDF, images, and other supported formats—so the resulting documents look consistent across environments. Fonts are loaded from custom directories.

1. Specify one or more folders that contain the font files.
2. Call the static [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) method to load fonts from those folders.
3. Load and render/export the presentation.
4. Call [FontsLoader.clearCache](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/clearcache/) to clear the font cache.

The following code example demonstrates the font loading process:

```cpp
// Define folders that contain custom font files.
auto fontFolders = MakeObject<Array<String>>(1, externalFontFolder );

// Load custom fonts from the specified folders.
FontsLoader::LoadExternalFonts(fontFolders);

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Render/export the presentation (e.g., to PDF, images, or other formats) using the loaded fonts.
presentation->Save(u"output.pdf", SaveFormat::Pdf);
presentation->Dispose();

// Clear the font cache after the work is finished.
FontsLoader::ClearCache();
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/loadexternalfonts/) adds additional folders to the font search paths, but it does not change the font initialization order.
Fonts are initialized in this order:

1. The default operating system font path.
1. The paths loaded via [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/).

{{%/alert %}}

## **Get Custom Font Folders**
Aspose.Slides provides [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) to allow you to find font folders. This method returns folders added through the `LoadExternalFonts` method and system font folders.

This C++ code shows you how to use [FontsLoader::GetFontFolders()](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/getfontfolders/) method:

``` cpp
// This line outputs the folders that are checked for font files.
// Those are folders added through the LoadExternalFonts method and system font folders.
auto fontFolders = FontsLoader::GetFontFolders();
```

## **Specify Custom Fonts Used with a Presentation**
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

## **FAQ**

**Do custom fonts affect export to all formats (PDF, PNG, SVG, HTML)?**

Yes. Connected fonts are used by the renderer across all export formats.

**Are custom fonts automatically embedded into the resulting PPTX?**

No. Registering a font for rendering is not the same as embedding it into a PPTX. If you need the font carried inside the presentation file, you must use the explicit [embedding features](/slides/cpp/embedded-font/).

**Can I control fallback behavior when a custom font lacks certain glyphs?**

Yes. Configure [font substitution](/slides/cpp/font-substitution/), [replacement rules](/slides/cpp/font-replacement/), and [fallback sets](/slides/cpp/fallback-font/) to define exactly which font is used when the requested glyph is missing.

**Can I use fonts in Linux/Docker containers without installing them system-wide?**

Yes. Point to your own font folders or load fonts from byte arrays. This removes any dependency on system font directories in the container image.

**What about licensing—can I embed any custom font without restrictions?**

You are responsible for font licensing compliance. Terms vary; some licenses prohibit embedding or commercial use. Always review the font’s EULA before distributing outputs.
