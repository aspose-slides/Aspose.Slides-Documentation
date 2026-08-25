---
title: Beheer script-specifieke themalettertype-fonts in C++
linktitle: Script-specifieke themalettertype-fonts
type: docs
weight: 15
url: /nl/cpp/script-specific-font-mappings/
keywords:
- script-specifiek lettertype
- themalettertype-mapping
- meertalige presentatie
- schrijfsysteem
- Cyrillisch lettertype
- Arabisch lettertype
- Japans lettertype
- Georgisch lettertype
- Thaana lettertype
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Inspecteer, voeg toe, vervang en verwijder script-specifieke lettertype-mappings in PowerPoint-thema's met Aspose.Slides voor C++."
---
## **Overzicht**

Een presentatiethema kan verschillende lettertypefamilies voor verschillende schrijfsystemen selecteren. Hierdoor kan meertalige tekst die nog steeds themaletters gebruikt één gecoördineerd lettertype‑schema volgen, terwijl geschikte lettertypes worden gebruikt voor Cyrillisch, Arabisch, Japans, Georgisch, Thaana en andere scripts.

Het thema‑[IFontScheme](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/ifontscheme/) bevat een hoofdlettertypecollectie, die doorgaans wordt gebruikt voor koppen, en een secundaire lettertypecollectie, die meestal wordt gebruikt voor de hoofdtekst. Naast hun Latijnse en Oost‑Aziatische lettertype‑eigenschappen, bieden beide collecties mappings van schrijfsysteem‑tags naar lettertypefamilienamen via de [IFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifonts/) interface.

Dit artikel laat zien hoe u die mappings kunt inspecteren en aanpassen in het master‑thema van de presentatie en kunt verifiëren dat de wijzigingen overleven na een opslaan‑en‑herladen‑cyclus.

## **Begrijpen van script‑tags**

De script‑lettertype‑methoden gebruiken vierletterige BCP‑47 script‑subtags om schrijfsystemen te identificeren. Veelvoorkomende waarden zijn:

| Script‑tag | Schrijfsysteem |
|---|---|
| `Cyrl` | Cyrillisch |
| `Arab` | Arabisch |
| `Hans` | Vereenvoudigd Chinees |
| `Jpan` | Japans |
| `Geor` | Georgisch |
| `Thaa` | Thaana |

Deze mappings behoren tot het themaletterschema, niet tot individuele tekstgedeelten. Een presentatie kan verschillende mappings definiëren voor de hoofd‑ en secundaire collecties, en kan mappings voor sommige scripts weglaten.

## **Toegang tot en inspectie van script‑lettertype‑mappings**

Gebruik [Presentation::get_MasterTheme](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_mastertheme/) om toegang te krijgen tot het thema op presentatieniveau. De [FontScheme::get_Major](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/fontscheme/get_major/) en [FontScheme::get_Minor](https://reference.aspose.com/slides/nl/cpp/aspose.slides.theme/fontscheme/get_minor/) methoden geven respectievelijk de twee [IFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ifonts/) collecties terug.

Roep [Fonts::GetScriptFontMap](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fonts/getscriptfontmap/) aan om alle mappings uit een collectie op te halen. Om één schrijfsysteem op te zoeken, roep [Fonts::GetScriptFont](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fonts/getscriptfont/) aan met de bijbehorende script‑tag. `GetScriptFont` retourneert een null‑string wanneer die collectie de gevraagde mapping niet definieert.

## **Mappings wijzigen en persistentie verifiëren**

Gebruik [Fonts::SetScriptFont](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fonts/setscriptfont/) om een mapping te maken of de huidige lettertypefamilie te vervangen. Gebruik [Fonts::RemoveScriptFont](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fonts/removescriptfont/) om een mapping te verwijderen.

Het volgende end‑to‑end voorbeeld leest alle bestaande hoofd‑ en secundaire mappings, zoekt het Japanse hoofdlettertype op, wijzigt het Cyrillische hoofdlettertype, verwijdert de Thaana‑secundaire mapping, slaat de presentatie op en opent deze opnieuw om beide wijzigingen te verifiëren. Om de verwijderstap onafhankelijk van het oorspronkelijke thema te maken, creëert het voorbeeld eerst een Thaana‑mapping alleen wanneer er nog geen is gedefinieerd.

```cpp
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/collections/idictionary.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto fontScheme = presentation->get_MasterTheme()->get_FontScheme();
auto majorFonts = fontScheme->get_Major();
auto minorFonts = fontScheme->get_Minor();

Console::WriteLine(u"Existing major mappings:");
for (auto&& mapping : majorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

Console::WriteLine(u"Existing minor mappings:");
for (auto&& mapping : minorFonts->GetScriptFontMap())
{
    Console::WriteLine(u"  {0}: {1}", mapping.get_Key(), mapping.get_Value());
}

auto japaneseFont = majorFonts->GetScriptFont(u"Jpan");
if (japaneseFont.IsNull())
{
    Console::WriteLine(u"No major Japanese font is defined.");
}
else
{
    Console::WriteLine(u"Major Japanese font: {0}", japaneseFont);
}

majorFonts->SetScriptFont(u"Cyrl", u"Arial");

if (minorFonts->GetScriptFont(u"Thaa").IsNull())
{
    minorFonts->SetScriptFont(u"Thaa", u"Arial");
}

minorFonts->RemoveScriptFont(u"Thaa");
presentation->Save(u"script-font-mappings.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"script-font-mappings.pptx");
auto savedFontScheme = savedPresentation->get_MasterTheme()->get_FontScheme();
auto savedMajorFonts = savedFontScheme->get_Major();
auto savedMinorFonts = savedFontScheme->get_Minor();
auto savedCyrillicFont = savedMajorFonts->GetScriptFont(u"Cyrl");
auto savedThaanaFont = savedMinorFonts->GetScriptFont(u"Thaa");

if (savedCyrillicFont == u"Arial")
{
    Console::WriteLine(u"The Cyrillic mapping was preserved.");
}
else
{
    Console::WriteLine(u"The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont.IsNull())
{
    Console::WriteLine(u"The Thaana mapping removal was preserved.");
}
else
{
    Console::WriteLine(u"The Thaana mapping still exists.");
}
```

De verificatie maakt gebruik van hetzelfde null‑string‑gedrag als een gewone opzoeking: nadat de verwijdering is opgeslagen, geeft `GetScriptFont(u"Thaa")` een null‑string terug voor de secundaire collectie.

## **Verschil tussen themamappings en andere lettertype‑instellingen**

Script‑specifieke themalettertype‑mappings nemen deel aan lettertypekeuze, maar lossen een ander probleem op dan directe tekstopmaak, substitutie en fallback:

| Mechanisme | Doel | Effect van het wijzigen van een themamapping |
|---|---|---|
| Script‑specifieke themalettertype‑mapping | Selecteert een hoofd‑ of secundair themalettertype voor een schrijfsysteem. | Tekst die nog steeds het bijbehorende themalettertype gebruikt, kan worden omgezet naar de nieuw gemapte familie. |
| Lettertype expliciet toegewezen aan een tekstdelen | Stelt de gevraagde lettertypefamilie vast op dat deel in plaats van te vertrouwen op het thema. | Het deel kan ongewijzigd blijven omdat de directe opmaak de themakeuze overschrijft. |
| Lettertype‑substitutie | Vervangt een gevraagd lettertype wanneer dat lettertype niet beschikbaar is of wanneer een substitutieregel van toepassing is. | Het treedt op nadat een lettertype is aangevraagd; het herdefinieert de script‑mapping van het thema niet. |
| Lettertype‑fallback | Levert glyphs die het geselecteerde lettertype niet bevat, vaak voor specifieke Unicode‑bereiken. | Het vult ontbrekende glyph‑dekking aan; het wijzigt de opgeslagen themamapping niet. |

Voor meer informatie over de laatste twee mechanismen, zie [Font Substitution](/slides/nl/cpp/font-substitution/) en [Fallback Fonts](/slides/nl/cpp/fallback-font/).

Het wijzigen van een mapping in [Presentation::get_MasterTheme](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_mastertheme/) heeft alleen invloed op inhoud waarvan de effectieve opmaak nog steeds afhankelijk is van dat thema. Tekst kan in plaats daarvan een themaversie erven van een master, layout of dia, of een expliciet toegewezen lettertype gebruiken. Inspecteer die niveaus wanneer het zichtbare resultaat niet overeenkomt met de mapping op presentatieniveau.

## **Gemapte lettertypes beschikbaar maken en het resultaat valideren**

Een script‑mapping slaat een lettertypefamilienaam op; het installeert of laadt het bijbehorende lettertype‑bestand niet. Voor consistente weergave en export moet elk gemapt lettertype geïnstalleerd zijn in de omgeving of beschikbaar worden gesteld aan Aspose.Slides via een aangepaste bron zoals [FontsLoader::LoadExternalFonts](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fontsloader/loadexternalfonts/) of [LoadOptions::set_DocumentLevelFontSources](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_documentlevelfontsources/). Zie [Custom Fonts](/slides/nl/cpp/custom-font/) voor de beschikbare laadinopties.

Het verifiëren van de opgeslagen mapping bevestigt alleen dat de themadefinitie bewaard is gebleven. Het bewijst niet dat het lettertype beschikbaar is, alle vereiste glyphs bevat, of de beoogde lay‑out oplevert. Render representatieve tekst voor elk vereist schrijfsysteem naar een afbeelding of PDF en inspecteer de output. Dit detecteert ontbrekende lettertypes, onvolledige glyph‑dekking, fallback‑gedrag en lay‑out‑veranderingen voordat de presentatie wordt verspreid. Zie [Convert PowerPoint Presentations](/slides/nl/cpp/convert-powerpoint/) voor render‑ en export‑voorbeelden.

## **FAQ**

**Wat retourneert `GetScriptFont` wanneer een script niet is gemapt?**

[Fonts::GetScriptFont](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fonts/getscriptfont/) retourneert een null‑string wanneer de gevraagde script‑mapping niet is gedefinieerd in die hoofd‑ of secundaire lettertypecollectie.

**Voegt `SetScriptFont` een tweede mapping toe wanneer het script al bestaat?**

Nee. [Fonts::SetScriptFont](https://reference.aspose.com/slides/nl/cpp/aspose.slides/fonts/setscriptfont/) maakt de mapping aan wanneer deze ontbreekt en vervangt de gemapte lettertypefamilie wanneer dezelfde script‑tag al aanwezig is.

**Waarom wijzigde een themamapping niet sommige tekst?**

De tekst kan een expliciet toegewezen lettertype hebben, een ander thema erven via een override, of beïnvloed worden door substitutie of fallback tijdens het renderen. Een script‑mapping op presentatieniveau regelt alleen tekst waarvan de effectieve opmaak nog naar die themalettertype‑collectie verwijst.

**Is opslaan en opnieuw openen voldoende om de meertalige output te valideren?**

Nee. Het opnieuw openen verifieert alleen de persistentie van de themagegevens. Render bovendien representatieve tekst uit elk vereist schrijfsysteem om te bevestigen dat de gemapte lettertypes beschikbaar zijn en de nodige glyphs bevatten.