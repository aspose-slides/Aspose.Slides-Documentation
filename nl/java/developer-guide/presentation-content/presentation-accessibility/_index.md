---
title: Beheer presentatie-toegankelijkheid in Java
linktitle: Presentatie-toegankelijkheid
type: docs
weight: 30
url: /nl/java/presentation-accessibility/
keywords:
- presentatie-toegankelijkheid
- decoratief markeren
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides for Java helpt bij het automatiseren van controles op presentatie-toegankelijkheid in PPT-, PPTX- en ODP-bestanden - verbeter de ervaring voor schermlezers en verhoog de naleving."
---
## **Introduction**

Toegankelijkheid van presentaties zorgt ervoor dat mensen die gebruikmaken van ondersteunende technologieën — zoals schermlezers, braille‑displays of uitsluitend via het toetsenbord navigeren — je dia’s net zo goed kunnen begrijpen en doorlopen als zichtbare, met een muis werkende kijkers. Goede praktijk richt zich op een duidelijke leesvolgorde, betekenisvolle alternatieve tekst voor informatieve visualisaties, voldoende kleurcontrast, leesbare typografie, beschrijvende linktekst en het vermijden van het overbrengen van betekenis louter door kleur of positie. Wanneer toegankelijkheid vanaf het begin wordt gepland, leidt dat tot een schonere structuur, meer consistente visualisaties en inhoud die elke kijker bereikt zonder omwegen.

## **Mark as Decorative**

Mark as decorative geeft aan dat louter decoratieve afbeeldingen zijn, zodat schermlezers ze overslaan, waardoor ruis wordt verminderd en de focus op betekenisvolle inhoud blijft. Pas het toe op achtergronden, versieringen en spaties — nooit op grafieken, pictogrammen of afbeeldingen die informatie overbrengen. Aspose.Slides maakt deze vlag beschikbaar voor detectie en validatie, waardoor geautomatiseerde toegankelijkheidscontroles en opschoning mogelijk worden.

![Mark as Decorative](mark_as_decorative.png)

De volgende codevoorbeeld toont hoe je kunt bepalen of een vorm als decoratief gemarkeerd is.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```