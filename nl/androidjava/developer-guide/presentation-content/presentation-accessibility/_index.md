---
title: Beheer presentatie-toegankelijkheid op Android
linktitle: Presentatie-toegankelijkheid
type: docs
weight: 30
url: /nl/androidjava/presentation-accessibility/
keywords:
- presentatie toegankelijkheid
- markeer als decoratief
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor Android via Java helpt bij het automatiseren van controles op presentatie-toegankelijkheid in PPT-, PPTX- en ODP-bestanden - verbeter de ervaring voor schermlezers en vergroot de naleving."
---
## **Overzicht**

Toegankelijkheid van presentaties zorgt ervoor dat mensen die assistieve technologieën gebruiken — zoals schermlezers, braille-displays of navigatie met alleen het toetsenbord — je dia's kunnen begrijpen en doorlopen net zo effectief als zichtbare, met de muis werkende toeschouwers. Goede praktijken richten zich op een duidelijke leesvolgorde, betekenisvolle alternatieve tekst voor informatieve afbeeldingen, voldoende kleurcontrast, leesbare typografie, beschrijvende linktekst, en het vermijden van betekenisoverdracht uitsluitend via kleur of positie. Wanneer toegankelijkheid vanaf het begin wordt gepland, resulteert dat in een schonere structuur, consistenter beeldmateriaal en inhoud die elke kijker bereikt zonder omwegen.

## **Markeer als decoratief**

Markeer als decoratief labelt louter sierlijke visuals zodat schermlezers ze overslaan, waardoor ruis wordt verminderd en de focus op betekenisvolle content blijft. Pas het toe op achtergronden, versieringen en tussenruimtes — nooit op diagrammen, pictogrammen of afbeeldingen die informatie overbrengen. Aspose.Slides maakt deze vlag beschikbaar voor detectie en validatie, waardoor geautomatiseerde toegankelijkheidscontroles en opruiming mogelijk zijn.

![Mark als decoratief](mark_as_decorative.png)

De volgende code-voorbeeld laat zien hoe je kunt bepalen of een vorm gemarkeerd is als decoratief.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Is shape decorative: " + shape.isDecorative());
} finally {
    presentation.dispose();
}
```