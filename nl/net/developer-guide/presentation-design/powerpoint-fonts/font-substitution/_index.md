---
title: Lettertype‑substitutie configureren in presentaties in .NET
linktitle: Lettertype‑substitutie
type: docs
weight: 70
url: /nl/net/font-substitution/
keywords:
- lettertype
- vervangend lettertype
- lettertype‑substitutie
- lettertype vervangen
- lettertype‑vervanging
- substitutieregel
- vervangingsregel
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Configureer lettertype‑substitutieregels en inspecteer vervangen lettertypen in Aspose.Slides voor .NET bij het renderen of converteren van PowerPoint‑ en OpenDocument‑presentaties."
---
## **Overzicht**

Lettertype‑substitutie stelt Aspose.Slides in staat een beschikbaar lettertype te gebruiken in plaats van een lettertype dat niet kan worden benaderd wanneer een presentatie wordt gerenderd of geconverteerd. De substitutie heeft invloed op de gerenderde output; het wijzigt het aan de presentatie‑inhoud toegewezen lettertype niet.

U kunt het te gebruiken lettertype definiëren wanneer een specifiek lettertype niet beschikbaar is, en u kunt de substituties inspecteren die Aspose.Slides tijdens het renderen zal uitvoeren. Dit helpt om de output consistent te houden in omgevingen met verschillende geïnstalleerde lettertypen.

## **Lettertype‑substituties ophalen**

Gebruik de [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/)‑methode om te bepalen welke lettertypen worden vervangen wanneer de presentatie wordt gerenderd. De methode retourneert [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/)-objecten die de originele en de vervangende lettertype­namen identificeren.

Het volgende C#‑voorbeeld geeft alle lettertype‑substituties voor een presentatie weer:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **Lettertype‑substituties voor geselecteerde dia's ophalen**

Gebruik de [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/)‑overload met een `int[] slides`‑argument om alleen de substituties te inspecteren die nodig zijn om specifieke dia's te renderen. Dit is handig wanneer u een deel van een presentatie rendert of exporteert, een grote presentatie incrementeel controleert, dia's zoekt die afhankelijk zijn van niet‑beschikbare lettertypen, een minimaal lettertype‑pakket voor een server of container voorbereidt, of render‑verschillen diagnosticeert zonder ongerelateerde dia's te verwerken.

De `slides`‑array bevat één‑gebaseerde dia‑indexen: `1` identificeert de eerste dia. In tegenstelling tot de indexeur van de [Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/)‑collectie, die nul‑gebaseerd is, wordt dezelfde dia benaderd als `presentation.Slides[0]`. Houd dit verschil in gedachten bij het bouwen van de array om één‑off‑by‑one‑fouten te vermijden.

Roep de overload aan via de [Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/)‑eigenschap. Deze retourneert alleen de substituties die tijdens het renderen van de geselecteerde dia's zijn vastgesteld. Elk resultaat is een [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/)-object dat de originele en vervangende lettertype­namen bevat. Het resultaat weerspiegelt de huidige lettertype‑omgeving en [extern geladen lettertypen](/slides/nl/net/custom-font/). Substitutieregels opgeslagen in een [IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) wijzigen de gerenderde output maar worden niet weergegeven in het resultaat.

Dezelfde substitutie kan door meer dan één geselecteerde dia worden vereist. Dedupliceer de resultaten wanneer u een lettertype‑inventaris of pre‑flight‑rapport maakt. Het volgende voorbeeld rapporteert elke geretourneerde substitutie en maakt vervolgens een gesorteerde lijst van unieke lettertype‑toewijzingen:

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

De [IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/)-interface biedt beide overloads. Kies er één op basis van de reikwijdte van de render‑operatie:

| Overload | Wanneer gebruiken |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) zonder argumenten | U heeft substituties nodig voor de volledige presentatie. |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) met `int[] slides` | U heeft substituties nodig voor een geselecteerd bereik, incrementele controle, of gedeeltelijke export. |

## **Lettertype‑substitutieregels instellen**

Om het lettertype op te geven dat Aspose.Slides moet gebruiken wanneer een bronlettertype niet beschikbaar is:

1. Laad de presentatie.
2. Maak lettertype‑definities voor het bron‑ en het vervangende lettertype.
3. Maak een [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) met de [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/)‑voorwaarde.
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
Voor een onvoorwaardelijke wijziging van de in de hele presentatie gebruikte lettertypen, zie [Font Replacement](/slides/nl/net/font-replacement/).
{{% /alert %}}

## **Beperkingen voor wiskundige vergelijking‑lettertypen**

Lettertype‑substitutieregels maken deel uit van het standaard lettertype‑selectieproces dat tijdens renderen en converteren wordt gebruikt. Ze werken voor gewone tekst wanneer Aspose.Slides een ontoegankelijk lettertype kan vervangen door het beschikbare lettertype dat in een regel is gespecificeerd.

Office‑Math‑vergelijkingen hebben een extra vereiste. Als een vergelijking **Cambria Math** gebruikt, kan Aspose.Slides dat exacte lettertype nodig hebben om de lay‑out van de vergelijking te berekenen en te renderen. Een regel die een ander wiskundig lettertype, zoals **STIX Two Math**, substitueert, kan **Cambria Math** hiervoor niet vervangen, en het renderen kan nog steeds melden dat **Cambria Math** vereist is.

Om zo’n presentatie te renderen of te converteren, maak **Cambria Math** beschikbaar voor Aspose.Slides. Installeer het in het besturingssysteem of laad het als een [extern lettertype](/slides/nl/net/custom-font/).

Deze beperking geldt voor de lay‑out van vergelijking­teksten. De hierboven beschreven substitutieregels blijven van toepassing op gewone presentatietekst.

## **FAQ**

**Wat is het verschil tussen lettertype‑vervanging en lettertype‑substitutie?**

[Font replacement](/slides/nl/net/font-replacement/) wijzigt opzettelijk één lettertype naar een ander door de hele presentatie heen. Lettertype‑substitutie kiest een lettertype voor de gerenderde output wanneer aan de geconfigureerde voorwaarde is voldaan, bijvoorbeeld wanneer het originele lettertype niet beschikbaar is.

**Wanneer worden substitutieregels toegepast?**

De regels nemen deel aan de [font selection sequence](/slides/nl/net/font-selection-sequence/) tijdens renderen en converteren. Met `WhenInaccessible` wordt een regel alleen gebruikt wanneer Aspose.Slides geen toegang heeft tot het bronlettertype.

**Wat gebeurt er als een lettertype ontbreekt en er geen substitutieregel is geconfigureerd?**

Aspose.Slides selecteert het dichtstbijzijnde beschikbare lettertype volgens zijn lettertype‑selectieproces. Het resultaat hangt af van de lettertypen die beschikbaar zijn in de runtime‑omgeving.

**Kan ik externe lettertypen laden om substitutie te voorkomen?**

Ja. U kunt [extern lettertypen laden](/slides/nl/net/custom-font/) zodat Aspose.Slides ze kan gebruiken tijdens renderen en converteren.

**Distribueert Aspose lettertypen met de bibliotheek?**

Nee. U bent zelf verantwoordelijk voor het leveren van lettertypen en het naleven van hun licenties.

**Kunnen substitutieresultaten verschillen tussen Windows, Linux en macOS?**

Ja. Geïnstalleerde lettertypen en zoeklocaties voor lettertypen verschillen per besturingssysteem, dus een lettertype dat op de ene machine beschikbaar is, kan op een andere machine substitutie vereisen.

**Hoe kan ik de lettertype‑selectie consistent houden bij batch‑conversies?**

Gebruik dezelfde lettertype‑bestanden en -versies op elke machine of container, [laad vereiste externe lettertypen](/slides/nl/net/custom-font/), en [embed lettertypen](/slides/nl/net/embedded-font/) wanneer de licentie dit toelaat. U kunt ook [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) aanroepen vóór export om onverwachte substituties te identificeren.