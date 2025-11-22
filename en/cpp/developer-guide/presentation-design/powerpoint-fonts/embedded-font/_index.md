---
title: Embed Fonts in Presentations Using С++
linktitle: Embedding Font
type: docs
weight: 40
url: /cpp/embedded-font/
keywords:
- add font
- embed font
- font embedding
- get embedded font
- add embedded font
- remove embedded font
- compress embedded font
- PowerPoint
- OpenDocument
- presentation
- С++
- Aspose.Slides
description: "Embed TrueType fonts in PowerPoint and OpenDocument presentations with Aspose.Slides for С++, ensuring accurate rendering across all platforms."
---

## **Overview**

**Embedded fonts in PowerPoint** help ensure that your presentation retains its intended appearance when opened on any system or device. This is especially important when using custom, third-party, or non-standard fonts for branding or creative purposes. Without embedded fonts, text may be substituted, layouts can break, and characters might appear as unreadable symbols or rectangles, compromising the overall design.

Aspose.Slides for C++ provides a set of powerful APIs to manage embedded fonts programmatically. You can use the [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) and [FontData](https://reference.aspose.com/slides/cpp/aspose.slides/fontdata/) classes to inspect, add, or remove embedded fonts in your presentation files. Additionally, the [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) class allows you to optimize file size by compressing font data without affecting quality or appearance.

These tools give you full control over font embedding, helping you maintain consistent typography across platforms while reducing file size when needed.

## **Get Embedded Fonts from a Presentation**

Aspose.Slides for C++ provides the `GetEmbeddedFonts` method through the [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) class, which allows you to retrieve a list of fonts embedded in a PowerPoint presentation. This can be useful for auditing font usage, ensuring compliance with branding guidelines, or verifying that all necessary fonts are properly included before sharing the file.

The following C++ code demonstrates how to get embedded fonts from a presentation file:

```cpp
// Instantiate the Presentation class that represents a presentation file.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Get all embedded fonts.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Print names of the embedded fonts.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Add Embedded Fonts to a Presentation**

Aspose.Slides for C++ allows you to embed fonts into a PowerPoint presentation using the [AddEmbeddedFont](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/addembeddedfont/) method, which comes with two overloads for flexible usage. You can control how much of the font is embedded by using the [EmbedFontCharacters](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedfontcharacters/) enumeration — for example, choosing to embed only used characters or the entire font set. This feature is especially useful when preparing a presentation for sharing or distribution, ensuring that custom or non-standard fonts appear correctly on all systems, even if those fonts are not installed.

The following C++ code checks all the fonts used in a presentation, and embeds any fonts that are not already embedded.

```cpp
// Load a presentation file.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Check if the font is already embedded.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Embed the font into the presentation.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Save the presentation to disk.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Remove Embedded Fonts from a Presentation**

Aspose.Slides for C++ provides the `RemoveEmbeddedFont` method through the [FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/fontsmanager/) class, which enables you to remove specific fonts embedded in a PowerPoint presentation. This can help reduce the overall file size, especially if the embedded fonts are no longer used or needed. Removing unused fonts can also improve performance and ensure that your presentation only includes essential resources.

The following C++ code demonstrates how to remove an embedded font from a presentation:

```cpp
auto fontName = u"Calibri";

// Instantiate the Presentation class that represents a presentation file.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Get all embedded fonts.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Remove the embedded font.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Compress Embedded Fonts**

Aspose.Slides for C++ provides the `CompressEmbeddedFonts` method through the [Compress](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/) class, allowing you to reduce the overall file size of a presentation by optimizing the embedded font data. This is especially useful when your presentation includes large or multiple fonts, and you want to keep the file lightweight for sharing, storage, or online use — without compromising the visual fidelity of the content.

The following C++ code demonstrates how to compress embedded fonts in a PowerPoint presentation:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQs**

**What happens if I remove an embedded font that is used on a slide?**

If you remove an embedded font that is still used in the presentation and that font is not installed on the system, PowerPoint will substitute it with a default font. This may cause layout shifts or visual inconsistencies in the text.

**Can I embed only the characters that are actually used?**

Yes. When using the `AddEmbeddedFont` method, you can specify `EmbedFontCharacters::OnlyUsed` to embed only the characters that appear in the presentation. This helps reduce the overall file size.

**Can I embed fonts that are not currently used in the slides?**

Yes, you can embed any font by creating a [FontData](https://reference.aspose.com/slides/cpp/aspose.slides/fontdata/) object and calling `AddEmbeddedFont`, even if it's not applied to any slide content. However, this will increase the file size unnecessarily if the font is never used.
