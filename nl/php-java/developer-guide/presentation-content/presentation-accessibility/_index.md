---
title: Beheer presentatietoegankelijkheid in PHP
linktitle: Presentatietoegankelijkheid
type: docs
weight: 30
url: /nl/php-java/presentation-accessibility/
keywords:
- presentatietoegankelijkheid
- markeren als decoratief
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides helpt bij het automatiseren van controles op presentatietoegankelijkheid in PPT-, PPTX- en ODP-bestanden—verbeter de ervaring voor schermlezers en verhoog de naleving."
---
## **Overzicht**

Presentatietoegankelijkheid zorgt ervoor dat mensen die assistieve technologieën gebruiken—zoals schermlezers, braille‑displays of alleen‑toetsenbordnavigatie—uw dia's net zo goed kunnen begrijpen en doorlopen als zichtbare, met de muis bedienende publieken. Goede praktijken richten zich op een duidelijke leesvolgorde, betekenisvolle alternatieve tekst voor informatieve afbeeldingen, voldoende kleurcontrast, leesbare typografie, beschrijvende linktekst en het vermijden van betekenisoverdracht uitsluitend door kleur of positie. Wanneer toegankelijkheid vanaf het begin wordt gepland, levert dat een schonere structuur, consistenter visueel materiaal en inhoud die elke kijker bereikt zonder workarounds.

## **Markeren als decoratief**

Markeren als decoratief vinkt zuiver ornamentale visuals zodat schermlezers ze overslaan, waardoor ruis vermindert en de focus op betekenisvolle inhoud behouden blijft. Pas het toe op achtergronden, versieringen en spaties—nooit op grafieken, iconen of afbeeldingen die informatie overbrengen. Aspose.Slides maakt deze vlag beschikbaar voor detectie en validatie, waardoor geautomatiseerde toegankelijkheidscontroles en opschoning mogelijk zijn.

![Markeer als decoratief](mark_as_decorative.png)

De volgende code‑voorbeeld toont hoe u kunt bepalen of een vorm gemarkeerd is als decoratief.

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    echo "Is shape decorative: " . ($shape->isDecorative() ? "true" : "false") . "\n";
} finally {
    $presentation->dispose();
}
```