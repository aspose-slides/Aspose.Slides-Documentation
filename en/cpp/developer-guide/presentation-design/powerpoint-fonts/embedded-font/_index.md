---
title: Embed Fonts in Presentations in C++
linktitle: Embedded Fonts
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
- presentation
- C++
- Aspose.Slides
description: "Manage embedded fonts in PowerPoint with Aspose.Slides for C++. Add, retrieve, remove, and compress fonts to preserve text appearance and reduce file size."
---

## **Introduction**

Embedding fonts stores font data inside a PowerPoint presentation. When a viewer supports embedded fonts, it can display text using those fonts even if they are not installed on the target system. This helps preserve line breaks, text spacing, and slide layout.

Aspose.Slides for C++ lets you retrieve, add, and remove embedded fonts through the [Presentation::get_FontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_fontsmanager/) method of a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/). You can also reduce the size of embedded font data by removing characters that the presentation does not use.

The examples below work with PPTX files. Before embedding a font, make sure its font data is available to Aspose.Slides and its license permits embedding.

## **Get and Remove Embedded Fonts**

Use [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) to list the fonts stored in a presentation. To remove one, pass a font from that list to [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/removeembeddedfont/), then save the presentation.

The following example lists the embedded fonts in `EmbeddedFonts.pptx` and removes Calibri if it is present:

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

Removing an embedded font removes its stored font data; it does not change the font assigned to the text. If the font is installed on the target system, the text can still use it. Otherwise, rendering may require [font substitution](/slides/cpp/font-substitution/), which can affect the layout.

## **Inspect Font Data and Embedding Permissions**

Use the [IFontsManager](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/) interface to inspect fonts before embedding them. Call [IFontsManager::GetFonts](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getfonts/) to retrieve the fonts used in the presentation. For each font, pass an [IFontData](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/) object and the required [FontStyleType](https://reference.aspose.com/slides/cpp/aspose.slides/fontstyletype/) value to [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getfontbytes/). The method returns the binary data for that font style, or `nullptr` when the requested font or style is unavailable. Do not pass a `nullptr` result to [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/), because that method requires a byte array.

[EmbeddingLevel](https://reference.aspose.com/slides/cpp/aspose.slides/embeddinglevel/) is a flags enumeration that reports the embedding restrictions stored in the font:

- `Installable` permits embedding and permanent installation on another system, subject to the font license.
- `Restricted` prohibits embedding unless permission is obtained from the font's legal owner when it is the only usage-permission flag.
- `PreviewPrint` permits temporary use for viewing and printing; a document containing the font must be read-only.
- `Editable` permits temporary use and allows the document to be edited and saved.
- `NoSubsetting` is an additional restriction that prohibits embedding only a subset of the glyphs. Embed all characters when this flag is present.
- `BitmapOnly` is an additional restriction that permits only bitmap strikes to be embedded, not outline data. If the font has no bitmap strikes, it cannot be embedded.

The first four values describe usage permission, while `NoSubsetting` and `BitmapOnly` can be combined with them. Check the modifiers with bitwise operations. Because `Installable` is zero, mask the usage-permission bits and compare the result with `Installable`. Current fonts should set at most one usage-permission bit. For compatibility with older fonts that set more than one, the helper below selects the least restrictive permission: `Editable`, then `PreviewPrint`, then `Restricted`.

The following example audits the regular, bold, italic, and bold-italic data available for every font returned by `GetFonts`. It skips unavailable styles, restricted fonts, bitmap-only fonts, fonts limited to preview and print because the output remains editable, and fonts that are already embedded. If any available style has `NoSubsetting`, it embeds all characters for that font family.

```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

This inspection reports the restrictions encoded in each font file. It does not grant a license, prove that you obtained the font legally, or replace checking the font's license agreement before distributing an embedded copy.

## **Add Embedded Fonts**

Use [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/addembeddedfont/) to embed a font. Its overloads accept either an [IFontData](https://reference.aspose.com/slides/cpp/aspose.slides/ifontdata/) object or a byte array containing the font data. The [EmbedFontCharacters](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedfontcharacters/) enumeration controls which characters are included:

- [All](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedfontcharacters/) embeds all characters in the font. Use this option when recipients need to edit the presentation and enter new text.
- [OnlyUsed](https://reference.aspose.com/slides/cpp/aspose.slides.export/embedfontcharacters/) embeds only the characters used in the presentation to reduce file size. Choose this option for a finished presentation that is primarily intended for viewing.

The following example uses [IFontsManager::GetFonts](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getfonts/) to retrieve the fonts used in `Fonts.pptx` and embeds those that are not already embedded. The fonts to add must be available on the machine running the code. Existing embedded fonts retain their current character sets.

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Compress Embedded Fonts**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) reduces embedded font data by removing unused characters. It operates on fonts that are already embedded, so the size reduction depends on how much unused font data the presentation contains.

The following example compresses the fonts in `EmbeddedFonts.pptx` and saves the result as a separate file:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Keep the original file if recipients may need to add text later. Characters removed during compression are no longer available from the embedded font, even if you originally embedded all characters.

## **FAQ**

**How can I check whether an embedded font will still be substituted during rendering?**

Call [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/cpp/aspose.slides/ifontsmanager/getsubstitutions/) in the environment where you render the presentation to see which fonts Aspose.Slides will replace. Also check [font substitution](/slides/cpp/font-substitution/) settings and [font fallback](/slides/cpp/fallback-font/) rules. Fallback handles missing characters, so embedding a font does not resolve characters that the font itself does not contain.

**Should I embed common fonts such as Arial and Calibri?**

Base the decision on the target environment. If the required fonts are available on every machine that opens or renders the presentation, embedding them may add unnecessary file size. If recipients or servers may lack those fonts, embedding them can help preserve the intended appearance, provided their licenses allow it.
