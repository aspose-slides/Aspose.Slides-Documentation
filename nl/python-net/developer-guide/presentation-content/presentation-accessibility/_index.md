---
title: Beheer toegankelijkheid van presentaties in Python
linktitle: Presentatie-toegankelijkheid
type: docs
weight: 30
url: /nl/python-net/presentation-accessibility/
keywords:
- presentatie toegankelijkheid
- markeren als decoratief
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor Python helpt bij het automatiseren van controle op presentatie-toegankelijkheid in PPT-, PPTX- en ODP-bestanden - verbeter de ervaring voor schermlezers en verhoog de naleving."
---
## **Inleiding**

Toegankelijkheid van presentaties zorgt ervoor dat mensen die assistieve technologieën gebruiken — zoals schermlezers, brailleleesregels of alleen-toetsenbordnavigatie — je dia’s kunnen begrijpen en doorlopen net zo effectief als kijkers met zicht en een muis. Goede praktijken richten zich op een duidelijke leesvolgorde, betekenisvolle alternatieve tekst voor informatieve visuals, voldoende kleurcontrast, leesbare typografie, beschrijvende linktekst en het vermijden van betekenisgeving uitsluitend via kleur of positie. Wanneer toegankelijkheid vanaf het begin wordt gepland, levert dat een schonere structuur op, consistenter beeldmateriaal en inhoud die elke kijker bereikt zonder workarounds.

## **Markeren als decoratief**

Markeren als decoratief labelt louter decoratieve visuals zodat schermlezers ze overslaan, waardoor ruis wordt verminderd en de focus op betekenisvolle inhoud behouden blijft. Pas het toe op achtergronden, versieringen en spaties — nooit op grafieken, iconen of afbeeldingen die informatie overbrengen. Aspose.Slides biedt dit label aan voor detectie en validatie, waardoor geautomatiseerde toegankelijkheidscontroles en opschoning mogelijk zijn.

![Markeren als decoratief](mark_as_decorative.png)

De volgende code‑voorbeeld toont hoe je kunt bepalen of een vorm gemarkeerd is als decoratief.

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    print(f"Is shape decorative: {shape.is_decorative}")
```