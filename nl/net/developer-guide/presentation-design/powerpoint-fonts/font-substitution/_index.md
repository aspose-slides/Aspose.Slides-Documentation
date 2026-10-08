---
title: "Lettertypevervanging configureren in presentaties in .NET"
linktitle: "Lettertypevervanging"
type: docs
weight: 70
url: /nl/net/font-substitution/
keywords:
- lettertype
- vervangend lettertype
- lettertypevervanging
- lettertype vervangen
- lettertypevervanging
- substitutieregel
- vervangingsregel
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Lettertypevervangingsregels configureren en vervangen lettertypen inspecteren in Aspose.Slides voor .NET bij het renderen of converteren van PowerPoint- en OpenDocument‑presentaties."
---
## **Overzicht**

Lettertypevervanging stelt Aspose.Slides in staat om een beschikbaar lettertype te gebruiken in plaats van een lettertype dat niet toegankelijk is wanneer een presentatie wordt gerenderd of geconverteerd. De vervanging beïnvloedt de gerenderde uitvoer; het verandert het aan de presentatie toegewezen lettertype niet.

U kunt het te gebruiken lettertype definiëren wanneer een bepaald lettertype niet beschikbaar is, en u kunt de vervangingen inspecteren die Aspose.Slides tijdens het renderen zal uitvoeren. Dit helpt om de uitvoer consistent te houden tussen omgevingen met verschillende geïnstalleerde lettertypen.

Als een lettertype beschikbaar is maar geen specifiek vet lettertype heeft, zie [Lettertypen behandelen zonder een specifiek vet lettertype](/slides/nl/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Die sectie legt uit hoe u de betreffende tekst kunt rasteren tijdens PDF-export en de gevolgen voor tekstselectie, zoeken en schalen.

## **Lettertypevervangingen ophalen**

Gebruik de [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/)‑methode om te bepalen welke lettertypen worden vervangen wanneer de presentatie wordt gerenderd. De methode retourneert [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/)‑objecten die de oorspronkelijke en vervangende lettertypenamen identificeren.

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

Gebruik de [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) overload met een `int[] slides`‑argument om alleen de vervangingen te inspecteren die nodig zijn om specifieke dia's te renderen. Dit is nuttig wanneer u een deel van een presentatie rendert of exporteert, een grote presentatie incrementeel controleert, dia's zoekt die afhankelijk zijn van niet‑beschikbare lettertypen, een minimaal lettertype‑pakket voorbereidt voor een server of container, of renderingsverschillen diagnosticeert zonder niet‑relevante dia's te verwerken.

De `slides`‑array bevat één‑gebaseerde dia‑indexen: `1` verwijst naar de eerste dia. Daarentegen is de indexer van de [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/)‑collectie nul‑gebaseerd, zodat dezelfde dia wordt benaderd als `presentation.Slides[0]`. Houd dit verschil in gedachten bij het opbouwen van de array om off‑by‑one‑fouten te voorkomen.

Roep de overload aan via de eigenschap [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/). Deze retourneert alleen de vervangingen die zijn bepaald tijdens het renderen van de geselecteerde dia's. Elk resultaat is een [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/)‑object dat de oorspronkelijke en vervangende lettertypenamen bevat. Het resultaat weerspiegelt de huidige lettertype‑omgeving en [extern geladen lettertypen](/slides/nl/net/custom-font/). Vervangingsregels die zijn opgeslagen in een [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) wijzigen de gerenderde uitvoer, maar worden niet in het resultaat weergegeven.

Dezelfde vervanging kan vereist zijn voor meer dan één geselecteerde dia. Verwijder dubbele resultaten wanneer u een lettertype‑inventaris of preflight‑rapport maakt. Het volgende voorbeeld rapporteert elke teruggegeven vervanging en maakt vervolgens een gesorteerde lijst van unieke lettertype‑toewijzingen:

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

De [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/)‑interface biedt beide overloads. Kies er één op basis van de reikwijdte van de render‑operatie:

| Overload | Wanneer gebruiken |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | U hebt vervangingen nodig voor de gehele presentatie. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | U hebt vervangingen nodig voor een geselecteerd bereik, incrementele controle of gedeeltelijke export. |

## **Lettertypevervangingsregels instellen**

Om het lettertype op te geven dat Aspose.Slides moet gebruiken wanneer een bronlettertype niet beschikbaar is:

1. Laad de presentatie.
2. Maak lettertype‑definities voor het bron‑ en vervangende lettertype.
3. Maak een [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) met de [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/)‑conditie.
4. Voeg de regel toe aan een [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/).
5. Wijs de collectie toe aan de eigenschap [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/).
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
Voor een onvoorwaardelijke wijziging van de lettertypen die in een presentatie worden gebruikt, zie [Font Replacement](/slides/nl/net/font-replacement/).
{{% /alert %}}

## **Beperkingen voor wiskundige vergelijkingslettertypen**

Lettertypevervangingsregels maken deel uit van het standaardlettertype‑selectieproces dat tijdens het renderen en converteren wordt gebruikt. Ze werken voor gewone tekst wanneer Aspose.Slides een ontoegankelijk lettertype kan vervangen door het beschikbare lettertype dat door een regel is opgegeven.

Office Math‑vergelijkingen hebben een extra vereiste. Als een vergelijking **Cambria Math** gebruikt, kan Aspose.Slides dat exacte lettertype nodig hebben om de lay-out van de vergelijking te berekenen en te renderen. Een regel die een ander wiskundig lettertype vervangt, zoals **STIX Two Math**, kan **Cambria Math** voor dit doel niet vervangen, en renderen kan nog steeds melden dat **Cambria Math** vereist is.

Om zo’n presentatie te renderen of te converteren, zorg ervoor dat **Cambria Math** beschikbaar is voor Aspose.Slides. Installeer het in het besturingssysteem of laad het als een [external font](/slides/nl/net/custom-font/).

Deze beperking geldt voor de lay-out van vergelijkingen. De hierboven beschreven vervangingsregels blijven van toepassing op gewone presentatietekst.

## **FAQ**

**Wat is het verschil tussen lettertype‑vervanging en lettertype‑substitutie?**

[Font replacement](/slides/nl/net/font-replacement/) verandert opzettelijk één lettertype in een ander gedurende de hele presentatie. Lettertype‑substitutie kiest een lettertype voor de gerenderde uitvoer wanneer aan de geconfigureerde voorwaarde wordt voldaan, bijvoorbeeld wanneer het originele lettertype niet beschikbaar is.

**Wanneer worden substitutieregels toegepast?**

De regels nemen deel aan de [font selection sequence](/slides/nl/net/font-selection-sequence/) tijdens het renderen en converteren. Met `WhenInaccessible` wordt een regel alleen gebruikt wanneer Aspose.Slides geen toegang heeft tot het bronlettertype.

**Wat gebeurt er als een lettertype ontbreekt en er geen substitutieregel is geconfigureerd?**

Aspose.Slides selecteert het dichtstbijzijnde beschikbare lettertype volgens zijn lettertype‑selectieproces. Het resultaat hangt af van de lettertypen die beschikbaar zijn in de runtime‑omgeving.

**Kan ik externe lettertypen laden om substitutie te voorkomen?**

Ja. U kunt [load external fonts](/slides/nl/net/custom-font/) zodat Aspose.Slides ze kan gebruiken tijdens het renderen en converteren.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U bent verantwoordelijk voor het leveren van lettertypen en het naleven van hun licenties.

**Kunnen substitutieresultaten verschillen tussen Windows, Linux en macOS?**

Ja. Geïnstalleerde lettertypen en zoeklocaties voor lettertypen verschillen per besturingssysteem, zodat een lettertype dat op één machine beschikbaar is, op een andere mogelijk substitutie vereist.

**Hoe kan ik de lettertype‑selectie consistent maken bij batch‑conversies?**

Gebruik dezelfde lettertypebestanden en -versies op elke machine of container, [load required external fonts](/slides/nl/net/custom-font/), en [embed fonts](/slides/nl/net/embedded-font/) wanneer licenties dat toestaan. U kunt ook vóór export [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) aanroepen om onverwachte substituties te identificeren.