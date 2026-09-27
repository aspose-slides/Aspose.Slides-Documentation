---
title: Presentaties maken in Python
linktitle: Presentatie maken
type: docs
weight: 10
url: /nl/python-net/create-presentation/
keywords:
- presentatie maken
- nieuwe presentatie
- PPT maken
- nieuwe PPT
- PPTX maken
- nieuwe PPTX
- ODP maken
- nieuwe ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Maak PowerPoint-presentaties in Python met Aspose.Slides - maak PPT, PPTX en ODP bestanden, profiteer van OpenDocument-ondersteuning, en sla ze programmatically op voor betrouwbare resultaten."
---
## **Overzicht**

Dit artikel laat zien hoe u een presentatie maakt met Aspose.Slides for Python via .NET, een vorm met tekst toevoegt aan de eerste dia, en het resultaat opslaat als een PPTX‑bestand. Dezelfde API kan presentaties ook opslaan als PPT en ODP, zodat u zowel PowerPoint‑ als OpenDocument‑formaten kunt targeten vanuit één code‑basis, zonder Microsoft Office. Een korte FAQ aan het einde beantwoordt veelgestelde vragen over formaten, sjablonen, dia‑grootte, eenheden, geheugengebruik, threading, licenties, digitale handtekeningen en VBA‑ondersteuning.

Voordat u begint, installeert u het pakket vanaf PyPI met `pip install aspose.slides`. Zie [Installatie](/slides/nl/python-net/installation/) voor de bibliotheken die Linux en macOS ook nodig hebben, en voor de virtuele omgeving die de systeem‑Python van Debian en Ubuntu vereist.

## **Presentatie maken**

Om een presentatie te maken en een vorm met tekst op de eerste dia te plaatsen, volgt u deze stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑klasse. Een nieuwe presentatie bevat al één lege dia.  
1. Haal die dia op uit de [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/)‑collectie op index 0.  
1. Voeg een wolk‑vormige [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) toe met de [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/)‑methode van de [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/)‑collectie van de dia, en stel de [text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text/) in.  
1. Sla de presentatie op als een PPTX‑bestand met de [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/)‑methode.

```py
import aspose.slides as slides

# Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt.
with slides.Presentation() as presentation:
    # Haal de eerste dia op.
    slide = presentation.slides[0]

    # Voeg een auto-vorm van type CLOUD toe.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Sla de presentatie op als een PPTX-bestand.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

De linkerbovenhoek van de wolk ligt 20 punten vanaf de linkerrand en 20 punten vanaf de bovenzijde van de dia, en de wolk is 200 punten breed en 80 punten hoog. De `with`‑statement geeft de resources van de presentatie vrij wanneer het blok eindigt. Het script slaat *new_presentation.pptx* op in de huidige map, met één dia die de wolk en de tekst bevat. Zonder licentie voegt Aspose.Slides ook een evaluatiewatermerk toe aan elke dia die wordt opgeslagen; zie [Licentie](/slides/nl/python-net/licensing/).

Het resultaat:

![The new presentation](new_presentation.png)

## **FAQ**

### In welke formaten kan ik een nieuwe presentatie opslaan?

U kunt opslaan als [PPTX, PPT en ODP](/slides/nl/python-net/save-presentation/), en exporteren naar [PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/nl/python-net/convert-powerpoint-to-xps/), [HTML](/slides/nl/python-net/convert-powerpoint-to-html/), [SVG](/slides/nl/python-net/render-a-slide-as-an-svg-image/), en [images](/slides/nl/python-net/convert-powerpoint-to-png/), onder andere.

### Kan ik beginnen met een sjabloon (POTX/POTM) en opslaan als een gewone PPTX?

Ja. Laad het sjabloon en sla op in het gewenste formaat; POTX/POTM/PPTM en vergelijkbare formaten [worden ondersteund](/slides/nl/python-net/supported-file-formats/).

### Hoe bepaal ik de dia‑grootte/beeldverhouding bij het maken van een presentatie?

Stel de [slide size](/slides/nl/python-net/slide-size/) (inclusief presets zoals 4:3 en 16:9 of aangepaste afmetingen) in en kies hoe de inhoud moet worden geschaald.

### In welke eenheden worden afmetingen en coördinaten gemeten?

In punten: 1 inch gelijk aan 72 eenheden.

### Hoe ga ik om met zeer grote presentaties (met veel mediabestanden) om het geheugengebruik te verminderen?

Gebruik [BLOB management strategies](/slides/nl/python-net/manage-blob/), beperk de in‑memory‑opslag door tijdelijke bestanden te gebruiken, en geef de voorkeur aan bestands‑gebaseerde workflows boven puur in‑memory‑streams.

### Kan ik presentaties parallel maken/opslaan?

U kunt niet opereren op dezelfde [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)‑instantie vanuit [multiple threads](/slides/nl/python-net/multithreading/). Gebruik aparte, geïsoleerde instanties per thread of proces.

### Hoe verwijder ik het proef‑watermerk en de beperkingen?

[Apply a license](/slides/nl/python-net/licensing/) één keer per proces. De licentie‑XML moet ongewijzigd blijven, en de licentie‑instelling moet gesynchroniseerd worden als er meerdere threads actief zijn.

### Kan ik de PPTX die ik maak digitaal ondertekenen?

Ja. [Digital signatures](/slides/nl/python-net/digital-signature-in-powerpoint/) (toevoegen en verifiëren) worden ondersteund voor presentaties.

### Worden macro's (VBA) ondersteund in gemaakte presentaties?

Ja. U kunt [create/edit VBA projects](/slides/nl/python-net/presentation-via-vba/) en macro‑ingeschakelde bestanden opslaan zoals PPTM/PPSM.