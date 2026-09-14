---
title: Jämför presentationsbilder i Python
linktitle: Jämför bilder
type: docs
weight: 50
url: /sv/python-java/compare-slides/
keywords:
- jämför bilder
- bildjämförelse
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Jämför PowerPoint- och OpenDocument-presentationer programmässigt med Aspose.Slides för Python via Java. Identifiera bildskillnader i kod snabbt."
---
## **Översikt**

Aspose.Slides låter dig jämföra bilder, layoutbilder och masterbilder med hjälp av [equals](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/#equals) metoden som tillhandahålls av klassen [BaseSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/). Denna metod returnerar `True` när de jämförda bilderna är identiska i sin struktur och statiska innehåll.

## **Jämför två bilder**

Metoden [equals](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/#equals) i klassen [BaseSlide](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseslide/) returnerar `True` för bilder, layoutbilder och masterbilder som är identiska i struktur och statiskt innehåll.

Två bilder är lika om alla deras former, stilar, text, animationer och andra inställningar är lika. Jämförelsen tar inte hänsyn till unika identifierarvärden, såsom bild-ID:n, eller dynamiskt innehåll, såsom det aktuella datumet i en datumplatshållare.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

source_presentation = Presentation("AccessSlides.pptx")
try:
    target_presentation = Presentation("HelloWorld.pptx")
    try:
        for i in range(source_presentation.getMasters().size()):
            for j in range(target_presentation.getMasters().size()):
                if source_presentation.getMasters().get_Item(i).equals(target_presentation.getMasters().get_Item(j)):
                    print(f"AccessSlides MasterSlide#{i} is equal to HelloWorld MasterSlide#{j}")
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **FAQ**

**Påverkar det faktum att en bild är dold jämförelsen av själva bilderna?**

[Hidden status](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slide/#getHidden) är en egenskap på presentations-/uppspelningsnivå, inte visuellt innehåll. Likheten mellan två specifika bilder bestäms av deras struktur och statiska innehåll; det faktum att en bild är dold gör inte bilderna olika.

**Tas hyperlänkar och deras parametrar i beaktande?**

Ja. Länkar är en del av en bilds statiska innehåll. Om URL‑en eller hyperlänkåtgärden skiljer sig, behandlas detta normalt som en skillnad i statiskt innehåll.

**Om ett diagram refererar till en extern Excel‑fil, kommer innehållet i den filen att tas i beaktande?**

Nej. Jämförelsen utförs baserat på själva bilderna. Externa datakällor läses normalt inte vid jämförelsetillfället; endast det som finns i bildens struktur och statiska tillstånd beaktas.