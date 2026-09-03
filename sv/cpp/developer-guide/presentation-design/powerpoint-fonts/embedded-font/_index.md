---
title: Inbädda teckensnitt i presentationer i C++
linktitle: Inbädda teckensnitt
type: docs
weight: 40
url: /sv/cpp/embedded-font/
keywords:
- lägg till teckensnitt
- bädda in teckensnitt
- inbäddning av teckensnitt
- hämta inbäddat teckensnitt
- lägga till inbäddat teckensnitt
- ta bort inbäddat teckensnitt
- komprimera inbäddat teckensnitt
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Hantera inbäddade teckensnitt i PowerPoint med Aspose.Slides för C++. Lägg till, hämta, ta bort och komprimera teckensnitt för att bevara textens utseende och minska filstorleken."
---
## **Introduktion**

Embedding fonts stores font data inside a PowerPoint presentation. When a viewer supports embedded fonts, it can display text using those fonts even if they are not installed on the target system. This helps preserve line breaks, text spacing, and slide layout.

Aspose.Slides för C++ låter dig hämta, lägga till och ta bort inbäddade teckensnitt via metoden [Presentation::get_FontsManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_fontsmanager/) på ett [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/). Du kan också minska storleken på inbäddade teckensnittsdata genom att ta bort tecken som presentationen inte använder.

Exemplen nedan fungerar med PPTX-filer. Innan du bäddar in ett teckensnitt, se till att dess teckensnittsdata är tillgänglig för Aspose.Slides och att licensen tillåter inbäddning.

## **Hämta och ta bort inbäddade teckensnitt**

Använd [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) för att lista teckensnitten som lagras i en presentation. För att ta bort ett, skicka ett teckensnitt från den listan till [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontsmanager/removeembeddedfont/), och spara sedan presentationen.

Följande exempel listar de inbäddade teckensnitten i `EmbeddedFonts.pptx` och tar bort Calibri om det finns:

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

Att ta bort ett inbäddat teckensnitt tar bort dess lagrade teckensnittsdata; det ändrar inte det teckensnitt som är tilldelat texten. Om teckensnittet är installerat på målsystemet kan texten fortfarande använda det. Annars kan rendering kräva [font substitution](/slides/sv/cpp/font-substitution/), vilket kan påverka layouten.

## **Inspektera teckensnittsdata och inbäddningsbehörigheter**

Använd gränssnittet [IFontsManager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontsmanager/) för att inspektera teckensnitt innan de bäddas in. Anropa [IFontsManager::GetFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontsmanager/getfonts/) för att hämta teckensnitten som används i presentationen. För varje teckensnitt, skicka ett [IFontData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontdata/)‑objekt och det erforderliga [FontStyleType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontstyletype/)-värdet till [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontsmanager/getfontbytes/). Metoden returnerar de binära data för den teckensnittsstilen, eller `nullptr` när det begärda teckensnittet eller stilen inte är tillgänglig. Skicka inte ett `nullptr`‑resultat till [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/), eftersom den metoden kräver en byte‑array.

[EmbeddingLevel](https://reference.aspose.com/slides/sv/cpp/aspose.slides/embeddinglevel/) är en flagg‑enumeration som rapporterar inbäddningsrestriktionerna som lagras i teckensnittet:

- `Installable` tillåter inbäddning och permanent installation på ett annat system, under förutsättning att teckensnittets licens tillåter det.
- `Restricted` förbjuder inbäddning om inte tillstånd erhålls från teckensnittets juridiska ägare när det är den enda användnings‑tillståndsflaggan.
- `PreviewPrint` tillåter tillfällig användning för visning och utskrift; ett dokument som innehåller teckensnittet måste vara skrivskyddat.
- `Editable` tillåter tillfällig användning och gör att dokumentet kan redigeras och sparas.
- `NoSubsetting` är en extra restriktion som förbjuder inbäddning av endast en delmängd av tecknen. Bädda in alla tecken när denna flagga är närvarande.
- `BitmapOnly` är en extra restriktion som endast tillåter inbäddning av bitmap‑slag, inte konturdata. Om teckensnittet saknar bitmap‑slag kan det inte bäddas in.

De första fyra värdena beskriver användningstillstånd, medan `NoSubsetting` och `BitmapOnly` kan kombineras med dem. Kontrollera modifierarna med bitvisa operationer. Eftersom `Installable` är noll maskeras användningstillståndsbitarna och resultatet jämförs med `Installable`. Aktuella teckensnitt bör sätta högst en användningstillståndsbit. För kompatibilitet med äldre teckensnitt som sätter fler än en, väljer hjälpfunktionen nedan den minst restriktiva tillståndet: `Editable`, sedan `PreviewPrint`, sedan `Restricted`.

Följande exempel granskar de vanliga, fetstilta, kursiva och fet‑kursiva data som finns för varje teckensnitt som returneras av `GetFonts`. Det hoppar över otillgängliga stilar, restriktiva teckensnitt, enbart bitmap‑teckensnitt, teckensnitt begränsade till förhandsgranskning och utskrift eftersom utdata förblir redigerbar, och teckensnitt som redan är inbäddade. Om någon tillgänglig stil har `NoSubsetting` bäddas alla tecken in för den teckensnittsfamiljen.

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

Denna inspektion rapporterar de restriktioner som kodas i varje teckensnittsfil. Den ger inte någon licens, bevisar att du har skaffat teckensnittet lagligt, eller ersätter kontrollen av teckensnittets licensavtal innan en inbäddad kopia distribueras.

## **Lägg till inbäddade teckensnitt**

Använd [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontsmanager/addembeddedfont/) för att bädda in ett teckensnitt. Dess överlagringar accepterar antingen ett [IFontData](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontdata/)‑objekt eller en byte‑array som innehåller teckensnittsdata. Enumerationen [EmbedFontCharacters](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/embedfontcharacters/) styr vilka tecken som inkluderas:

- [All](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/embedfontcharacters/) bäddar in alla tecken i teckensnittet. Använd detta alternativ när mottagarna behöver redigera presentationen och skriva in ny text.
- [OnlyUsed](https://reference.aspose.com/slides/sv/cpp/aspose.slides.export/embedfontcharacters/) bäddar endast in de tecken som används i presentationen för att minska filstorleken. Välj detta alternativ för en färdig presentation som främst är avsedd för visning.

Följande exempel använder [IFontsManager::GetFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontsmanager/getfonts/) för att hämta teckensnitten som används i `Fonts.pptx` och bäddar in de som ännu inte är inbäddade. Teckensnitten som ska läggas till måste finnas på maskinen som kör koden. Existerande inbäddade teckensnitt behåller sina nuvarande teckenset.

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

## **Komprimera inbäddade teckensnitt**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/sv/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) minskar de inbäddade teckensnittsdata genom att ta bort oanvända tecken. Den arbetar på teckensnitt som redan är inbäddade, så storleksreduktionen beror på hur mycket oanvänd teckensnittsdata presentationen innehåller.

Följande exempel komprimerar teckensnitten i `EmbeddedFonts.pptx` och sparar resultatet som en separat fil:

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

Behåll originalfilen om mottagarna kan behöva lägga till text senare. Tecken som tas bort under komprimeringen är inte längre tillgängliga från det inbäddade teckensnittet, även om du ursprungligen bäddade in alla tecken.

## **FAQ**

**Hur kan jag kontrollera om ett inbäddat teckensnitt fortfarande kommer att ersättas vid rendering?**

Anropa [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ifontsmanager/getsubstitutions/) i den miljö där du renderar presentationen för att se vilka teckensnitt Aspose.Slides kommer att ersätta. Kontrollera även inställningarna för [font substitution](/slides/sv/cpp/font-substitution/) och reglerna för [font fallback](/slides/sv/cpp/fallback-font/). Fallback hanterar saknade tecken, så inbäddning av ett teckensnitt löser inte tecken som själva teckensnittet inte innehåller.

**Bör jag bädda in vanliga teckensnitt såsom Arial och Calibri?**

Basera beslutet på målmiljön. Om de nödvändiga teckensnitten finns på varje maskin som öppnar eller renderar presentationen kan inbäddning av dem öka filstorleken i onödan. Om mottagare eller servrar kan sakna dessa teckensnitt kan inbäddning hjälpa till att bevara det avsedda utseendet, förutsatt att deras licenser tillåter det.