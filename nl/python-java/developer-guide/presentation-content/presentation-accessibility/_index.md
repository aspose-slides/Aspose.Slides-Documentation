---
title: Beheer presentatie-toegankelijkheid in Python via Java
linktitle: Presentatie-toegankelijkheid
type: docs
weight: 30
url: /nl/python-java/presentation-accessibility/
keywords:
- presentatie-toegankelijkheid
- markeer als decoratief
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides voor Python via Java helpt om controles op presentatie-toegankelijkheid in PPT-, PPTX- en ODP-bestanden te automatiseren — de ervaring voor schermlezers te verbeteren en de naleving te verhogen."
---
## **Introductie**

Presentatie-toegankelijkheid zorgt ervoor dat mensen die assistieve technologieën gebruiken — zoals schermlezers, braille‑displays of alleen‑toetsenbordnavigatie — je dia’s kunnen begrijpen en doorbladeren net zo effectief als geziene, muis‑gebruikende doelgroepen. Goede praktijk richt zich op een duidelijke leesvolgorde, betekenisvolle alternatieve tekst voor informatieve afbeeldingen, voldoende kleurcontrast, leesbare typografie, beschrijvende linktekst en het vermijden van betekenisoverdracht uitsluitend via kleur of positie. Wanneer toegankelijkheid vanaf het begin wordt gepland, resulteert dit in een schonere structuur, consistentere visuals en content die elke kijker bereikt zonder omwegen.

## **Markeren als decoratief**

De markering ‘Mark as decorative’ labelt louter sierlijke visuals zodat schermlezers ze overslaan, ruis verminderen en de focus op betekenisvolle inhoud houden. Pas deze toe op achtergronden, versieringen en tussenruimtes — nooit op grafieken, pictogrammen of afbeeldingen die informatie overbrengen. Aspose.Slides maakt deze vlag beschikbaar voor detectie en validatie, waardoor geautomatiseerde toegankelijkheidscontroles en opschoning mogelijk worden.

![Mark as Decorative](mark_as_decorative.png)

De onderstaande code‑voorbeeld toont hoe je kunt bepalen of een vorm gemarkeerd is als decoratief.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    print(f"Is shape decorative: {shape.isDecorative()}")
finally:
    presentation.dispose()
```