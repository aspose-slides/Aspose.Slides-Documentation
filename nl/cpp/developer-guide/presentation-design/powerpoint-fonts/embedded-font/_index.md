---
title: Lettertypen insluiten in presentaties in C++
linktitle: Ingesloten lettertypen
type: docs
weight: 40
url: /nl/cpp/embedded-font/
keywords:
- lettertype toevoegen
- lettertype insluiten
- insluiten van lettertypen
- ingesloten lettertype ophalen
- ingesloten lettertype toevoegen
- ingesloten lettertype verwijderen
- ingesloten lettertype comprimeren
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Beheer ingesloten lettertypen in PowerPoint met Aspose.Slides voor C++. Voeg toe, haal op, verwijder en comprimeer lettertypen om de weergave van tekst te behouden en de bestandsgrootte te verminderen."
---
## **Introductie**

Embedded fonts slaan lettertype‑gegevens op binnen een PowerPoint‑presentatie. Wanneer een viewer embedded fonts ondersteunt, kan hij de tekst weergeven met die lettertypen, zelfs wanneer ze niet op het doelsysteem geïnstalleerd zijn. Dit helpt om regeleinden, tekstafstand en slide‑lay‑out te behouden.

Aspose.Slides for C++ laat je embedded fonts ophalen, toevoegen en verwijderen via de [Presentation::get_FontsManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_fontsmanager/)‑methode van een [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/). Je kunt ook de grootte van embedded lettertype‑gegevens verkleinen door tekens te verwijderen die de presentatie niet gebruikt.

De voorbeelden hieronder werken met PPTX‑bestanden. Zorg er vóór het embedden van een lettertype voor dat de lettertype‑gegevens beschikbaar zijn voor Aspose.Slides en dat de licentie het embedden toestaat.

## **Embedded fonts ophalen en verwijderen**

Gebruik [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) om de fonts die in een presentatie zijn opgeslagen te tonen. Om er één te verwijderen, geef een font uit die lijst door aan [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontsmanager/removeembeddedfont/), en sla vervolgens de presentatie op.

Het volgende voorbeeld toont de embedded fonts in `EmbeddedFonts.pptx` en verwijdert Calibri als het aanwezig is:

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

Het verwijderen van een embedded font verwijdert de opgeslagen font‑gegevens; het wijzigt niet het toegewezen font voor de tekst. Als het font op het doelsysteem geïnstalleerd is, kan de tekst het nog steeds gebruiken. Anders kan rendering een [font substitution](/slides/nl/cpp/font-substitution/) vereisen, wat de lay‑out kan beïnvloeden.

## **Lettertype‑gegevens en embed‑permissies inspecteren**

Gebruik de [IFontsManager](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontsmanager/)‑interface om fonts te inspecteren vóór je ze embedt. Roep [IFontsManager::GetFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontsmanager/getfonts/) aan om de fonts op te halen die in de presentatie worden gebruikt. Voor elk font geef je een [IFontData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontdata/)‑object en de vereiste [FontStyleType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontstyletype/)‑waarde door aan [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontsmanager/getfontbytes/). De methode retourneert de binaire gegevens voor die font‑stijl, of `nullptr` wanneer het gevraagde font of de stijl niet beschikbaar is. Geef geen `nullptr`‑resultaat door aan [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/), want die methode vereist een byte‑array.

[EmbeddingLevel](https://reference.aspose.com/slides/nl/cpp/aspose.slides/embeddinglevel/) is een flags‑enumeratie die de embed‑restricties in het font aangeeft:

- `Installable` staat embedden en permanente installatie op een ander systeem toe, onder voorbehoud van de font‑licentie.
- `Restricted` verbiedt embedden tenzij toestemming verkregen is van de juridische eigenaar van het font wanneer dit de enige usage‑permission‑flag is.
- `PreviewPrint` staat tijdelijk gebruik voor bekijken en afdrukken toe; een document dat het font bevat moet alleen‑lezen zijn.
- `Editable` staat tijdelijk gebruik toe en maakt het mogelijk het document te bewerken en op te slaan.
- `NoSubsetting` is een extra restrictie die het embedden van slechts een deel van de glyphs verbiedt. Embed alle tekens wanneer deze flag aanwezig is.
- `BitmapOnly` is een extra restrictie die alleen bitmap‑strikes toestaat om te embedden, niet de outline‑data. Als het font geen bitmap‑strikes heeft, kan het niet worden embedded.

De eerste vier waarden beschrijven de gebruikstoestemming, terwijl `NoSubsetting` en `BitmapOnly` er met gecombineerd kunnen worden. Controleer de modifiers met bitwise‑operaties. Omdat `Installable` nul is, maskeer je de usage‑permission‑bits en vergelijk je het resultaat met `Installable`. Huidige fonts zouden maximaal één usage‑permission‑bit moeten hebben. Voor compatibiliteit met oudere fonts die meer dan één hebben, kiest de helper hieronder de minst beperkende permissie: `Editable`, daarna `PreviewPrint`, daarna `Restricted`.

Het volgende voorbeeld controleert de gewone, vet, cursief en vet‑cursief data die beschikbaar is voor elk font dat `GetFonts` retourneert. Het slaat niet‑beschikbare stijlen, restricted fonts, bitmap‑only fonts, fonts beperkt tot preview‑en‑print (omdat de output bewerkbaar blijft) en al embedded fonts over. Als een beschikbare stijl `NoSubsetting` heeft, embedt het alle tekens voor die font‑familie.

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

Deze inspectie rapporteert de restricties die in elk font‑bestand gecodeerd zijn. Het verleent geen licentie, bewijst niet dat je het font legaal hebt verkregen, en vervangt niet het controleren van de licentie‑overeenkomst van het font vóór distributie van een embedded kopie.

## **Embedded fonts toevoegen**

Gebruik [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontsmanager/addembeddedfont/) om een font te embedden. De overloads accepteren een [IFontData](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontdata/)‑object of een byte‑array met de font‑gegevens. De [EmbedFontCharacters](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/embedfontcharacters/)‑enumeratie bepaalt welke tekens worden meegenomen:

- [All](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/embedfontcharacters/) embedt alle tekens in het font. Gebruik deze optie wanneer ontvangers de presentatie moeten kunnen bewerken en nieuwe tekst moeten invoeren.
- [OnlyUsed](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/embedfontcharacters/) embedt alleen de tekens die in de presentatie gebruikt worden om de bestandsgrootte te verkleinen. Kies deze optie voor een afgewerkte presentatie die hoofdzakelijk bedoeld is om bekeken te worden.

Het volgende voorbeeld gebruikt [IFontsManager::GetFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontsmanager/getfonts/) om de fonts op te halen die in `Fonts.pptx` gebruikt worden en embedt die die nog niet embedded zijn. De fonts die moeten worden toegevoegd, moeten beschikbaar zijn op de machine die de code uitvoert. Bestaande embedded fonts behouden hun huidige tekensets.

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

## **Embedded fonts comprimeren**

[Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) verkleint embedded font‑gegevens door ongebruikte tekens te verwijderen. Het werkt op fonts die al embedded zijn, dus de grootte‑reductie hangt af van hoeveel ongebruikte font‑data de presentatie bevat.

Het volgende voorbeeld comprimeert de fonts in `EmbeddedFonts.pptx` en slaat het resultaat op als een apart bestand:

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

Bewaar het originele bestand als ontvangers later tekst moeten kunnen toevoegen. Tekens die tijdens compressie verwijderd worden, zijn niet langer beschikbaar vanuit het embedded font, zelfs als je oorspronkelijk alle tekens had embedded.

## **FAQ**

**Hoe kan ik controleren of een embedded font nog steeds wordt gesubstitueerd tijdens rendering?**

Roep [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifontsmanager/getsubstitutions/) aan in de omgeving waarin je de presentatie rendert om te zien welke fonts Aspose.Slides zal vervangen. Controleer ook de instellingen voor [font substitution](/slides/nl/cpp/font-substitution/) en de regels voor [font fallback](/slides/nl/cpp/fallback-font/). Fallback behandelt ontbrekende tekens, dus embedden van een font lost geen tekens op die het font zelf niet bevat.

**Moet ik veelgebruikte fonts zoals Arial en Calibri embedden?**

Baseer de beslissing op de doelomgeving. Als de benodigde fonts op elke machine beschikbaar zijn die de presentatie opent of rendert, kan embedden onnodig bestandsgrootte toevoegen. Als ontvangers of servers deze fonts mogelijk niet hebben, kan embedden helpen het gewenste uiterlijk te behouden, mits de licenties het toestaan.