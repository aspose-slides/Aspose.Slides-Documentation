---
title: Beheer presentatie-toegankelijkheid in .NET
linktitle: Presentatie-toegankelijkheid
type: docs
weight: 30
url: /nl/net/presentation-accessibility/
keywords:
- presentatie-toegankelijkheid
- alternatieve tekst
- alternatieve tekst titel
- alternatieve tekst beschrijving
- markeer als decoratief
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Automatiseer controles op presentatie-toegankelijkheid in PPT-, PPTX- en ODP-bestanden met Aspose.Slides voor .NET — verbeter de ervaring voor schermlezers en verhoog de naleving."
---
## **Inleiding**

Alternatieve tekst helpt mensen die assistieve technologieën gebruiken om de betekenis van afbeeldingen, grafieken en andere informatieve vormen te begrijpen. Dit artikel legt uit hoe u alternatieve tekst‑titels en -beschrijvingen kunt lezen en bijwerken met Aspose.Slides for .NET, toegankelijkheidsbeschrijvingen onderscheidt van vormnamen die in code worden gebruikt, en controleert of een vorm als decoratief is gemarkeerd.

Deze functies ondersteunen de toegankelijkheid van presentaties, maar garanderen dit niet. Leesvolgorde, kleurcontrast, leesbaarheid van tekst en andere toegankelijkheidseisen moeten ook worden gecontroleerd.

## **Beheer alternatieve tekst‑titels en -beschrijvingen**

Gebruik alternatieve tekst om de betekenis van afbeeldingen, grafieken en andere informatieve vormen uit te leggen aan mensen die ze niet kunnen zien. De volgende eigenschappen hebben verschillende doelen:

| Eigenschap of inhoud | Doel |
| --- | --- |
| [AlternativeTextTitle](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/alternativetexttitle/) | Een korte titel voor de alternatieve beschrijving. |
| [AlternativeText](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/alternativetext/) | Een betekenisvolle beschrijving van de inhoud of het doel van de vorm in de context van de dia. |
| [Name](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/name/) | De naam van de vorm, die code kan gebruiken om een specifieke vorm in de presentatie te vinden. |
| Visible text | Inhoud die op de dia wordt weergegeven, zoals de tekst van een vorm of de titel en labels van een grafiek. Het bijwerken van alternatieve tekst verandert deze inhoud niet. |

Wanneer een presentatie opnieuw wordt gebruikt als sjabloon, kan code een vorm vinden via de [Name](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/name/) voordat deze wordt bijgewerkt. Deze naam heeft een ander doel dan alternatieve tekst, die uitlegt wat de visuele weergave aan de lezer communiceert. Zoeken op naam stelt auteurs in staat beschrijvingen te verbeteren of te vertalen zonder de manier waarop code de vorm vindt te wijzigen. Namen kunnen worden bewerkt en zijn niet gegarandeerd uniek, controleer daarom dat de naam overeenkomt met de beoogde vorm; zie [Identificeer en vind vormen](/slides/nl/net/shape-manipulations/#identify-and-find-shapes).

Het onderstaande voorbeeld vereist `input.pptx` met een afbeelding van een kantooringang als de eerste vorm op de eerste dia. De afbeelding mag niet gemarkeerd zijn als decoratief. Het voorbeeld leest en toont de huidige alternatieve tekst‑titel en -beschrijving, werkt beide waarden bij en slaat de presentatie op als `output.pptx`. Pas de bewoording aan de daadwerkelijke afbeelding en de informatie die deze overbrengt aan.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var shape = presentation.Slides[0].Shapes[0];

Console.WriteLine($"Alternative text title: {shape.AlternativeTextTitle}");
Console.WriteLine($"Alternative text description: {shape.AlternativeText}");

shape.AlternativeTextTitle = "Office entrance";
shape.AlternativeText = "The office entrance has a wheelchair ramp to the right of the steps.";

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Het alleen toevoegen van alternatieve tekst garandeert geen toegankelijkheid van de presentatie of naleving van toegankelijkheidsnormen. Controleer de beschrijvingen op juistheid en relevantie, en controleer ook leesvolgorde, kleurcontrast, leesbare tekst en andere toegankelijkheidseisen. Informatieve visuals mogen niet als decoratief gemarkeerd worden; de volgende sectie laat zien hoe u [IsDecorative](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/isdecorative/) kunt lezen.

## **Markeer als decoratief**

Markeer als decoratief markeert puur ornamentale visuals zodat schermlezers deze overslaan, ruis verminderen en de focus op betekenisvolle inhoud houden. Pas het toe op achtergronden, versieringen en opvullers—nooit op grafieken, pictogrammen of afbeeldingen die informatie overbrengen. Aspose.Slides maakt deze vlag beschikbaar voor detectie en validatie, waardoor geautomatiseerde toegankelijkheidscontroles en opruiming mogelijk worden.

![Markeer als decoratief](mark_as_decorative.png)

```cs
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```

## **Veelgestelde vragen**

**Wat moet ik in de alternatieve tekst‑titel en -beschrijving plaatsen?**

Gebruik een korte titel om het onderwerp te identificeren en een beschrijving om de informatie die de visual in de context van de dia overbrengt uit te leggen. Beschrijf bij een grafiek de relevante trend of vergelijking in plaats van alleen “grafiek” te zeggen.

**Moet ik alternatieve tekst gebruiken om vormen in een sjabloon te vinden?**

Zoek liever de vorm op via de [Name](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/name/) en controleer of het de verwachte vorm is. Alternatieve tekst kan worden bewerkt of vertaald, waardoor code die zoekt naar een exacte beschrijving kan falen; zie [Identificeer en vind vormen](/slides/nl/net/shape-manipulations/).

**Wanneer moet een vorm als decoratief gemarkeerd worden?**

Gebruik de decoratieve vlag voor visuals die geen informatie toevoegen, zoals ornamentale versieringen. Afbeeldingen en grafieken die betekenis overbrengen hebben in plaats daarvan een passende beschrijving nodig.

**Zorgt het toevoegen van alternatieve tekst ervoor dat een presentatie volledig toegankelijk is?**

Nee. Alternatieve tekst behandelt slechts een deel van de toegankelijkheid. Controleer ook leesvolgorde, kleurcontrast, leesbaarheid van tekst en andere toepasselijke eisen; alleen het instellen van deze eigenschappen zorgt niet voor naleving.