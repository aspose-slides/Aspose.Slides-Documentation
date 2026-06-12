---
title: Beheer toegankelijkheid van presentaties in .NET
linktitle: Presentatietoegankelijkheid
type: docs
weight: 30
url: /nl/net/presentation-accessibility/
keywords:
- toegankelijkheid van presentaties
- markeer als decoratief
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Automatiseer controles op toegankelijkheid van presentaties in PPT-, PPTX- en ODP-bestanden met Aspose.Slides voor .NET - verbeter de ervaring voor schermlezers en verhoog de naleving."
---
## **Inleiding**

Toegankelijkheid van presentaties zorgt ervoor dat mensen die assistieve technologieën gebruiken—zoals schermlezers, braille‑displays of alleen‑toetsenbordnavigatie—uw dia’s kunnen begrijpen en navigeren net zo effectief als geziene, muis‑gebruikende doelgroepen. Een goede praktijk richt zich op een duidelijke leesvolgorde, betekenisvolle alternatieve tekst voor informatieve afbeeldingen, voldoende kleurcontrast, leesbare typografie, beschrijvende linktekst en het vermijden van het overbrengen van betekenis uitsluitend via kleur of positie. Wanneer toegankelijkheid vanaf het begin wordt gepland, resulteert dit in een schonere structuur, consistentere afbeeldingen en inhoud die elke kijker bereikt zonder omsluitende oplossingen.

## **Markeer als decoratief**

Mark as decorative markeert louter ornamentale visuals zodat schermlezers ze overslaan, ruis verminderen en de focus op betekenisvolle inhoud behouden. Pas het toe op achtergronden, versieringen en spatiërende elementen—nooit op grafieken, pictogrammen of afbeeldingen die informatie overbrengen. Aspose.Slides maakt deze vlag beschikbaar voor detectie en validatie, waardoor geautomatiseerde toegankelijkheidscontroles en opschoning mogelijk worden.

![Mark as Decorative](mark_as_decorative.png)

De volgende codevoorbeelden laten zien hoe u kunt bepalen of een vorm is gemarkeerd als decoratief.

```cs
using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
Console.WriteLine($"Is shape decorative: {shape.IsDecorative}");
```