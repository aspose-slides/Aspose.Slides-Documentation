---
title: Beheer script‑specifieke themalettertypen in .NET
linktitle: Script‑specifieke themalettertypen
type: docs
weight: 15
url: /nl/net/script-specific-font-mappings/
keywords:
- script‑specifiek lettertype
- thema‑lettertypekoppeling
- meertalige presentatie
- schrijfsysteem
- Cyrillisch lettertype
- Arabisch lettertype
- Japans lettertype
- Georgisch lettertype
- Thaana-lettertype
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Inspecteer, voeg toe, vervang en verwijder script‑specifieke lettertypekoppelingen in PowerPoint‑thema's met Aspose.Slides voor .NET."
---
## **Overzicht**

Een presentatiethema kan verschillende lettertypefamilies selecteren voor verschillende schrijftalen. Dit maakt meertalige tekst die nog steeds themalettertypen gebruikt mogelijk om één gecoördineerd lettertype‑schema te volgen, terwijl geschikte lettertypen voor Cyrillisch, Arabisch, Japans, Georgisch, Thaana en andere schriften worden gebruikt.

Het [IFontScheme] van het thema bevat een hoofdlettertypecollectie, doorgaans gebruikt voor koppen, en een onderlettertypecollectie, doorgaans gebruikt voor de hoofdtekst. Naast hun Latijnse en Oost‑Azia‑lettertype‑eigenschappen, maken beide collecties via de [IFonts] interface koppelingen beschikbaar van schrijftaals‑tags naar lettertypefamilienamen.

Dit artikel toont hoe die koppelingen in het master‑thema van de presentatie kunnen worden geïnspecteerd en aangepast, en hoe geverifieerd kan worden dat de wijzigingen een opslaan‑en‑herladen‑cyclus overleven.

## **Script‑tags begrijpen**

De scriptlettertype‑methoden gebruiken vierletterige BCP‑47 script‑subtags om schrijftalen te identificeren. Veelvoorkomende waarden zijn:

| Script‑tag | Schrijfsysteem |
|---|---|
| `Cyrl` | Cyrillisch |
| `Arab` | Arabisch |
| `Hans` | Vereenvoudigd Chinees |
| `Jpan` | Japans |
| `Geor` | Georgisch |
| `Thaa` | Thaana |

Deze koppelingen behoren tot het themalettertype‑schema, niet tot individuele tekstgedeelten. Een presentatie kan verschillende koppelingen definiëren voor de hoofd‑ en ondercollecties, en kan koppelingen voor sommige scripts weglaten.

## **Toegang tot en inspectie van script‑lettertype‑koppelingen**

Gebruik [Presentation.MasterTheme] om het thema op presentatieniveau te benaderen. De eigenschappen [FontScheme.Major] en [FontScheme.Minor] geven de twee [IFonts]‑collecties terug.

Roep [IFonts.GetScriptFontMap] aan om alle koppelingen uit een collectie op te halen. Om één schrijftaal op te zoeken, roep je [IFonts.GetScriptFont] aan met de bijbehorende script‑tag. `GetScriptFont` retourneert `null` wanneer die collectie de gevraagde koppeling niet definieert.

## **Koppelingen wijzigen en persistentie verifiëren**

Gebruik [IFonts.SetScriptFont] om een koppeling te maken of de huidige lettertypefamilie te vervangen. Gebruik [IFonts.RemoveScriptFont] om een koppeling te verwijderen.

Het onderstaande end‑to‑end‑voorbeeld leest alle bestaande hoofd‑ en onderkoppelingen, zoekt het Japanse hoofdlettertype op, wijzigt het Cyrillische hoofdlettertype, verwijdert de Thaana‑onderkoppeling, slaat de presentatie op en opent deze opnieuw om beide wijzigingen te verifiëren. Om de verwijderstap onafhankelijk van het oorspronkelijke thema te maken, maakt het voorbeeld eerst een Thaana‑koppeling aan alleen als er nog geen bestaat.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

static void PrintScriptFontMap(string label, IFonts fonts)
{
    Console.WriteLine(label);
    foreach (var mapping in fonts.GetScriptFontMap())
    {
        Console.WriteLine($"  {mapping.Key}: {mapping.Value}");
    }
}

using var presentation = new Presentation();
var fontScheme = presentation.MasterTheme.FontScheme;
var majorFonts = fontScheme.Major;
var minorFonts = fontScheme.Minor;

PrintScriptFontMap("Existing major mappings:", majorFonts);
PrintScriptFontMap("Existing minor mappings:", minorFonts);

var japaneseFont = majorFonts.GetScriptFont("Jpan");
if (japaneseFont is null)
{
    Console.WriteLine("No major Japanese font is defined.");
}
else
{
    Console.WriteLine($"Major Japanese font: {japaneseFont}");
}

majorFonts.SetScriptFont("Cyrl", "Arial");

if (minorFonts.GetScriptFont("Thaa") is null)
{
    minorFonts.SetScriptFont("Thaa", "Arial");
}

minorFonts.RemoveScriptFont("Thaa");
presentation.Save("script-font-mappings.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("script-font-mappings.pptx");
var savedMajorFonts = savedPresentation.MasterTheme.FontScheme.Major;
var savedMinorFonts = savedPresentation.MasterTheme.FontScheme.Minor;
var savedCyrillicFont = savedMajorFonts.GetScriptFont("Cyrl");
var savedThaanaFont = savedMinorFonts.GetScriptFont("Thaa");

if (savedCyrillicFont == "Arial")
{
    Console.WriteLine("The Cyrillic mapping was preserved.");
}
else
{
    Console.WriteLine("The Cyrillic mapping was not preserved.");
}

if (savedThaanaFont is null)
{
    Console.WriteLine("The Thaana mapping removal was preserved.");
}
else
{
    Console.WriteLine("The Thaana mapping still exists.");
}
```

De verificatie gebruikt hetzelfde `null`‑gedrag als een gewone zoekopdracht: nadat de verwijdering is opgeslagen, retourneert `GetScriptFont("Thaa")` `null` voor de ondercollectie.

## **Themakoppelingen onderscheiden van andere lettertype‑instellingen**

Script‑specifieke themakoppelingen nemen deel aan de lettertype‑selectie, maar ze lossen een ander probleem op dan directe tekstopmaak, substitutie en fallback:

| Mechanisme | Doel | Effect van het wijzigen van een themakoppeling |
|---|---|---|
| Script‑specifieke themalettertype‑koppeling | Selecteert een hoofd‑ of onderthema‑lettertype voor een schrijftaal. | Tekst die nog steeds het overeenkomstige themalettertype gebruikt, kan naar de nieuw gekoppelde familie verwijzen. |
| Lettertype expliciet toegewezen aan een tekstgedeelte | Fixeert de gevraagde lettertypefamilie op dat gedeelte in plaats van te vertrouwen op het thema. | Het gedeelte kan ongewijzigd blijven omdat directe opmaak de themakeuze overschrijft. |
| Lettertype‑substitutie | Vervangt een aangevraagd lettertype wanneer dat lettertype niet beschikbaar is of wanneer een substitutieregel van toepassing is. | Het treedt op nadat een lettertype is aangevraagd; het herschrijft de script‑koppeling van het thema niet. |
| Lettertype‑fallback | Levert tekensets die het geselecteerde lettertype niet bevat, vaak voor specifieke Unicode‑bereiken. | Het vult ontbrekende tekensets aan; het wijzigt de opgeslagen themakoppeling niet. |

Voor meer informatie over de laatste twee mechanismen, zie [Font Substitution](/slides/nl/net/font-substitution/) en [Fallback Fonts](/slides/nl/net/fallback-font/).

Het wijzigen van een koppeling in [Presentation.MasterTheme] beïnvloedt alleen inhoud waarvan de effectieve opmaak nog steeds afhankelijk is van dat thema. Tekst kan in plaats daarvan een themadoorvoer overerven van een master, lay‑out of dia, of een expliciet toegewezen lettertype gebruiken. Controleer die niveaus wanneer het zichtbare resultaat niet overeenkomt met de koppeling op presentatieniveau.

## **Gekoppelde lettertypen beschikbaar maken en het resultaat valideren**

Een script‑koppeling slaat een lettertypefamilienaam op; ze installeert of laadt het bijbehorende lettertype‑bestand niet. Voor consistente weergave en export moet elk gekoppeld lettertype in de omgeving geïnstalleerd zijn of aan Aspose.Slides worden geleverd via een aangepaste bron, zoals [FontsLoader.LoadExternalFonts] of [LoadOptions.DocumentLevelFontSources]. Zie [Custom Fonts](/slides/nl/net/custom-font/) voor de beschikbare laadopties.

Het verifiëren van de opgeslagen koppeling bevestigt alleen dat de themadefinitie behouden bleef. Het bewijst niet dat het lettertype beschikbaar is, alle vereiste tekens bevat of de beoogde lay‑out oplevert. Render representatieve tekst voor elk vereist schrijftaal naar een afbeelding of PDF en inspecteer de output. Dit detecteert ontbrekende lettertypen, onvolledige teken‑dekking, fallback‑gedrag en lay‑outwijzigingen voordat de presentatie wordt verspreid. Zie [Convert PowerPoint Presentations](/slides/nl/net/convert-powerpoint/) voor voorbeelden van weergave en export.

## **FAQ**

**Wat retourneert `GetScriptFont` wanneer een script niet is gekoppeld?**

[IFonts.GetScriptFont] retourneert `null` wanneer de gevraagde script‑koppeling niet is gedefinieerd in die hoofd‑ of onderlettertypecollectie.

**Voegt `SetScriptFont` een tweede koppeling toe wanneer het script al bestaat?**

Nee. [IFonts.SetScriptFont] maakt de koppeling aan wanneer deze ontbreekt en vervangt de gekoppelde lettertypefamilie wanneer dezelfde script‑tag al aanwezig is.

**Waarom wijzigde het aanpassen van een themakoppeling bepaalde tekst niet?**

De tekst kan een expliciet toegewezen lettertype hebben, een ander thema erven via een overschrijving, of beïnvloed worden door substitutie of fallback tijdens de weergave. Een script‑koppeling op presentatieniveau beïnvloedt alleen tekst waarvan de effectieve opmaak nog steeds naar die themalettertype‑collectie verwijst.

**Is opslaan en opnieuw openen voldoende om meertalige output te valideren?**

Nee. Heropenen verifieert de persistentie van de themagegevens. Render daarnaast representatieve tekst uit elk vereist schrijftaal om te bevestigen dat de gekoppelde lettertypen beschikbaar zijn en de benodigde tekens bevatten.