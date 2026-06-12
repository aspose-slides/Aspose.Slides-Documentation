---
title: Beheer presentatietoegankelijkheid in JavaScript
linktitle: Presentatietoegankelijkheid
type: docs
weight: 30
url: /nl/nodejs-java/presentation-accessibility/
keywords:
- presentatietoegankelijkheid
- markeren als decoratief
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Automatiseer controles op presentatietoegankelijkheid in PPT-, PPTX- en ODP-bestanden met Aspose.Slides voor Node.js—verbeter de ervaring voor screenreaders en verhoog de naleving."
---
## **Overzicht**

Toegankelijkheid van presentaties zorgt ervoor dat mensen die gebruikmaken van assistieve technologieën—zoals screenreaders, brailledisplays of alleen‑toetsenbordnavigatie—uw dia's kunnen begrijpen en er doorheen kunnen navigeren net zo effectief als zichtbare, met de muis werkende publiek. Goede praktijk richt zich op een duidelijke leesvolgorde, betekenisvolle alternatieve tekst voor informatieve beelden, voldoende kleurcontrast, leesbare typografie, beschrijvende linktekst en het vermijden van betekenisoverdracht uitsluitend via kleur of positie. Wanneer toegankelijkheid vanaf het begin wordt meegenomen, resulteert dat in een schonere structuur, meer consistente visuals en content die elke kijker bereikt zonder oplossingen.

## **Markeren als decoratief**

Markeren als decoratief labelt puur ornamentale visuals, zodat screenreaders ze overslaan, ruis verminderen en de focus op betekenisvolle inhoud behouden blijft. Pas dit toe op achtergronden, versieringen en spaties—nooit op grafieken, iconen of afbeeldingen die informatie overbrengen. Aspose.Slides maakt deze vlag beschikbaar voor detectie en validatie, waardoor geautomatiseerde toegankelijkheidscontroles en opruiming mogelijk zijn.

![Mark as Decorative](mark_as_decorative.png)

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Is shape decorative:", shape.isDecorative());
} finally {
    presentation.dispose();
}
```