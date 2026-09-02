---
title: Lettertypevervanging configureren in presentaties in .NET
linktitle: Lettertypevervanging
type: docs
weight: 70
url: /nl/net/font-substitution/
keywords:
- lettertype
- vervangend lettertype
- lettertypevervanging
- lettertype vervangen
- lettertypevervanging
- vervangingsregel
- vervangingsregel
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Configureer lettertypevervangingsregels en inspecteer vervangen lettertypen in Aspose.Slides voor .NET bij het renderen of converteren van PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Lettertypevervanging maakt het mogelijk dat Aspose.Slides een beschikbaar lettertype gebruikt in plaats van een lettertype dat niet toegankelijk is wanneer een presentatie wordt gerenderd of geconverteerd. De vervanging heeft invloed op de weergegeven output; het wijzigt niet het lettertype dat aan de presentatietekst is toegewezen.

U kunt het te gebruiken lettertype definiëren wanneer een bepaald lettertype niet beschikbaar is, en u kunt de vervangingen inspecteren die Aspose.Slides tijdens het renderen zal uitvoeren. Dit helpt de output consistent te houden tussen omgevingen met verschillende geïnstalleerde lettertypen.

## **Lettertypevervangingen ophalen**

Gebruik de [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontsmanager/getsubstitutions/)‑methode om te bepalen welke lettertypen worden vervangen wanneer de presentatie wordt gerenderd. De methode retourneert [FontSubstitutionInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsubstitutioninfo/)‑objecten die de oorspronkelijke en vervangende lettertype‑namen identificeren.

Het volgende C#‑voorbeeld geeft alle lettertypevervangingen voor een presentatie weer:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Lettertypevervangingen voor geselecteerde dia's ophalen**

Gebruik de overload van [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontsmanager/getsubstitutions/) met een `int[] slides`‑argument om alleen de vervangingen te inspecteren die nodig zijn om specifieke dia's te renderen. Dit is handig wanneer u een deel van een presentatie rendert of exporteert, een grote presentatie incrementeel controleert, dia's zoekt die afhankelijk zijn van niet‑beschikbare lettertypen, een minimalistisch lettertype‑pakket voor een server of container voorbereidt, of renderverschillen diagnosticeert zonder ongerelateerde dia's te verwerken.

De `slides`‑array bevat één‑gebaseerde dia‑indexen: `1` identificeert de eerste dia. Daarentegen is de indexer van de [Presentation.Slides](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/slides/nl/)‑collectie nul‑gebaseerd, zodat dezelfde dia wordt aangesproken als `presentation.Slides[0]`. Houd dit verschil in gedachten bij het bouwen van de array om off‑by‑one‑fouten te vermijden.

Roep de overload aan via de [Presentation.FontsManager](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/fontsmanager/)‑eigenschap. Deze retourneert alleen de vervangingen die zijn bepaald tijdens het renderen van de geselecteerde dia's. Elk resultaat is een [FontSubstitutionInfo](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsubstitutioninfo/)‑object dat de oorspronkelijke en vervangende lettertype‑namen bevat. Het resultaat weerspiegelt de huidige lettertype‑omgeving, geconfigureerde fallback‑regels, vervangingsregels opgeslagen in een [IFontSubstRuleCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontsubstrulecollection/), en [extern geladen lettertypen](/slides/nl/net/custom-font/).

Dezelfde vervanging kan door meer dan één geselecteerde dia vereist zijn. Dupliceer de resultaten niet wanneer u een lettertype‑inventaris of preflight‑rapport maakt. Het volgende voorbeeld rapporteert elke teruggegeven vervanging en maakt vervolgens een gesorteerde lijst van unieke lettertype‑koppelingen:

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

De [IFontsManager](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontsmanager/)‑interface biedt beide overloads. Kies er één op basis van de reikwijdte van de render‑operatie:

| Overload | Gebruik wanneer |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontsmanager/getsubstitutions/) zonder argumenten | U heeft vervangingen nodig voor de gehele presentatie. |
| [GetSubstitutions](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontsmanager/getsubstitutions/) met `int[] slides` | U heeft vervangingen nodig voor een geselecteerd bereik, incrementele controle of gedeeltelijke export. |

## **Lettertypevervangingsregels instellen**

Om het lettertype op te geven dat Aspose.Slides moet gebruiken wanneer een bronlettertype niet beschikbaar is:

1. Laad de presentatie.
2. Maak lettertype‑definities voor het bron‑ en vervangende lettertype.
3. Maak een [FontSubstRule](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsubstrule/) met de [WhenInaccessible](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsubstcondition/)‑conditie.
4. Voeg de regel toe aan een [FontSubstRuleCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsubstrulecollection/).
5. Wijs de collectie toe aan de eigenschap [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/nl/net/aspose.slides/fontsmanager/fontsubstrulelist/).
6. Render of converteer de presentatie.

Het volgende C#‑voorbeeld vervangt `Arial` door `SomeRareFont` wanneer `SomeRareFont` niet beschikbaar is, en rendert vervolgens de eerste dia om het resultaat te verifiëren. Het vervangende lettertype moet beschikbaar zijn voor Aspose.Slides.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
Voor een onvoorwaardelijke wijziging van de in de gehele presentatie gebruikte lettertypen, zie [Font Replacement](/slides/nl/net/font-replacement/).
{{% /alert %}}

## **Beperkingen voor lettertypen in wiskundige vergelijkingen**

Lettertypevervangingsregels maken deel uit van het standaard lettertype‑selectieproces dat wordt gebruikt tijdens rendering en conversie. Ze werken voor gewone tekst wanneer Aspose.Slides een ontoegankelijk lettertype kan vervangen door het beschikbare lettertype dat door een regel is opgegeven.

Office Math‑vergelijkingen hebben een extra vereiste. Als een vergelijking **Cambria Math** gebruikt, kan Aspose.Slides dat exacte lettertype nodig hebben om de lay‑out van de vergelijking te berekenen en te renderen. Een regel die een ander wiskundig lettertype vervangt, zoals **STIX Two Math**, kan **Cambria Math** voor dit doel niet vervangen, en de rendering kan nog steeds melden dat **Cambria Math** vereist is.

Om een dergelijke presentatie te renderen of te converteren, moet **Cambria Math** beschikbaar zijn voor Aspose.Slides. Installeer het in het besturingssysteem of laad het als een [extern lettertype](/slides/nl/net/custom-font/).

Deze beperking geldt voor de vergelijking‑lay‑out. De hierboven beschreven vervangingsregels blijven wel van toepassing op gewone presentatietekst.

## **FAQ**

**Wat is het verschil tussen lettertypevervanging en lettertypevervanging?**

[Font replacement](/slides/nl/net/font-replacement/) verandert opzettelijk één lettertype in een ander door de gehele presentatie. Lettertypevervanging kiest een lettertype voor de gerenderde output wanneer aan de geconfigureerde voorwaarde wordt voldaan, bijvoorbeeld wanneer het oorspronkelijke lettertype niet beschikbaar is.

**Wanneer worden vervangingsregels toegepast?**

De regels nemen deel aan de [lettertype‑selectiesequentie](/slides/nl/net/font-selection-sequence/) tijdens rendering en conversie. Met `WhenInaccessible` wordt een regel alleen gebruikt wanneer Aspose.Slides geen toegang heeft tot het bronlettertype.

**Wat gebeurt er als een lettertype ontbreekt en er geen vervangingsregel is geconfigureerd?**

Aspose.Slides kiest het meest geschikte beschikbare lettertype volgens zijn selectieproces. Het resultaat hangt af van de lettertypen die beschikbaar zijn in de runtime‑omgeving.

**Kan ik externe lettertypen laden om vervanging te vermijden?**

Ja. U kunt [externe lettertypen laden](/slides/nl/net/custom-font/) zodat Aspose.Slides ze kan gebruiken tijdens rendering en conversie.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U bent verantwoordelijk voor het leveren van lettertypen en het naleven van hun licenties.

**Kunnen vervangingsresultaten verschillen tussen Windows, Linux en macOS?**

Ja. Geïnstalleerde lettertypen en zoeklocaties verschillen per besturingssysteem, waardoor een lettertype dat op het ene systeem beschikbaar is, op een ander moet worden vervangen.

**Hoe zorg ik voor consistente lettertype‑selectie bij batchconversies?**

Gebruik dezelfde lettertype‑bestanden en -versies op elke machine of container, [laad vereiste externe lettertypen](/slides/nl/net/custom-font/), en [embed lettertypen](/slides/nl/net/embedded-font/) wanneer de licentie dit toestaat. U kunt ook [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/nl/net/aspose.slides/ifontsmanager/getsubstitutions/) aanroepen vóór export om onverwachte vervangingen te identificeren.