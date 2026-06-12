---
title: Beheer presentatietoegankelijkheid in C++
linktitle: Presentatietoegankelijkheid
type: docs
weight: 30
url: /nl/cpp/presentation-accessibility/
keywords:
- presentatietoegankelijkheid
- markeren als decoratief
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor C++ helpt bij het automatiseren van controles op presentatietoegankelijkheid in PPT, PPTX en ODP-bestanden - verbeter de ervaring voor schermlezers en verhoog de naleving."
---
## **Overzicht**

Toegankelijkheid van presentaties zorgt ervoor dat mensen die assistieve technologieën gebruiken — zoals schermlezers, brailleleesregels of alleen-toetsenbordnavigatie — je dia's kunnen begrijpen en erdoorheen kunnen navigeren net zo effectief als zichtbare gebruikers met muis. Goede praktijken richten zich op een duidelijke leesvolgorde, betekenisvolle alternatieve tekst voor informatieve visuals, voldoende kleurcontrast, leesbare typografie, beschrijvende linktekst, en het vermijden van betekenisoverdracht uitsluitend via kleur of positie. Wanneer toegankelijkheid vanaf het begin wordt gepland, levert dat een schonere structuur op, meer consistente visuals, en content die elke kijker bereikt zonder workarounds.

## **Markeren als decoratief**

Markeren als decoratief geeft een vlag aan puur ornamentale afbeeldingen zodat schermlezers ze overslaan, wat ruis vermindert en de focus op betekenisvolle inhoud behoudt. Pas het toe op achtergronden, versieringen en spaties—nooit op grafieken, iconen of afbeeldingen die informatie overbrengen. Aspose.Slides maakt deze vlag beschikbaar voor detectie en validatie, waardoor geautomatiseerde toegankelijkheidscontroles en opruiming mogelijk worden.

![Markeren als decoratief](mark_as_decorative.png)

De volgende codevoorbeeld laat zien hoe je kunt bepalen of een vorm gemarkeerd is als decoratief.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);
Console::WriteLine(u"Is shape decorative: {0}", shape->get_IsDecorative());

presentation->Dispose();
```