---
title: Presentaties maken in Python via Java
linktitle: Presentatie maken
type: docs
weight: 10
url: /nl/python-java/create-presentation/
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
- presentatie
- Python
- Java
- Aspose.Slides
description: "Presentaties maken in Python via Java met Aspose.Slides—produceer PPT-, PPTX- en ODP-bestanden, profiteer van OpenDocument-ondersteuning en sla ze programmatisch op voor betrouwbare resultaten."
---
## **Overzicht**

Dit artikel laat zien hoe u een presentatie maakt met Aspose.Slides for Python via Java, een vorm met tekst toevoegt aan de eerste dia, en het resultaat opslaat als een PPTX‑bestand. De FAQ behandelt uitvoerformaten, sjablonen, dia‑grootte, geheugengebruik, threading, licenties, digitale handtekeningen en VBA‑ondersteuning.

## **Maak een presentatie**

Een PowerPoint‑bestand vanaf nul maken in Aspose.Slides for Python via Java is net zo simpel als het instantieren van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse. De constructor levert automatisch een lege presentatie met één dia, waardoor u onmiddellijk een canvas heeft voor vormen, tekst, grafieken of andere inhoud die uw toepassing nodig heeft. Zodra u die dia wijzigt — of nieuwe dia's toevoegt — kunt u het resultaat opslaan als PPTX, legacy PPT of zelfs OpenDocument‑formaten. Het korte code‑voorbeeld hieronder illustreert deze workflow door een eenvoudige vorm toe te voegen aan de eerste dia.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse.  
1. Haal de eerste dia op via de index.  
1. Voeg een [AutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshape/) van het type [ShapeType.Cloud](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapetype/#Cloud) toe met behulp van [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shapecollection/#addAutoShape).  
1. Stel de tekst van de vorm in met [TextFrame.setText](https://reference.aspose.com/slides/nl/python-java/aspose.slides/textframe/#setText).  
1. Sla de presentatie op met [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) en [SaveFormat.Pptx](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/#Pptx).

Het volgende voorbeeld vereist Aspose.Slides for Python via Java en een compatibele Java‑runtime. Het start de JVM als deze nog niet draait, voegt een wolk‑vorm toe aan de eerste dia, en slaat de presentatie op:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Maak een presentatie met één lege dia.
presentation = Presentation()
try:
    # Haal de eerste dia op.
    slide = presentation.getSlides().get_Item(0)

    # Voeg een wolkvorm toe en stel de tekst in.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Sla de presentatie op als een PPTX‑bestand.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Het resultaat:

![De nieuwe presentatie](new_presentation.png)

## **FAQ**

**In welke formaten kan ik een nieuwe presentatie opslaan?**

U kunt opslaan naar [PPTX, PPT, en ODP](/slides/nl/python-java/save-presentation/), en exporteren naar [PDF](/slides/nl/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/nl/python-java/convert-powerpoint-to-xps/), [HTML](/slides/nl/python-java/convert-powerpoint-to-html/), [SVG](/slides/nl/python-java/render-slide-as-svg/), en [afbeeldingen](/slides/nl/python-java/convert-powerpoint-to-png/), onder andere.

**Kan ik starten vanuit een sjabloon (POTX/POTM) en opslaan als een gewone PPTX?**

Ja. Laad het sjabloon en sla op in het gewenste formaat; POTX/POTM/PPTM en soortgelijke formaten [worden ondersteund](/slides/nl/python-java/supported-file-formats/).

**Hoe kan ik de dia‑grootte/verhouding regelen bij het maken van een presentatie?**

Stel de [dia‑grootte](/slides/nl/python-java/slide-size/) in (inclusief presets zoals 4:3 en 16:9 of aangepaste afmetingen) en kies hoe de inhoud geschaald moet worden.

**In welke eenheden worden afmetingen en coördinaten gemeten?**

In punten: 1 inch is gelijk aan 72 eenheden.

**Hoe ga ik om met zeer grote presentaties (met veel mediabestanden) om het geheugengebruik te verminderen?**

Gebruik [BLOB‑beheersstrategieën](/slides/nl/python-java/manage-blob/), beperk opslag in het geheugen door tijdelijke bestanden te gebruiken, en geef de voorkeur aan bestands‑gebaseerde workflows boven volledig in‑geheugen‑streams.

**Kan ik presentaties parallel maken/op slaan?**

U kunt niet dezelfde [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑instantie gebruiken vanuit [meerdere threads](/slides/nl/python-java/multithreading/). Gebruik afzonderlijke, geïsoleerde instanties per thread of proces.

**Hoe verwijder ik het proef‑watermerk en de beperkingen?**

[Pas een licentie toe](/slides/nl/python-java/licensing/) één keer per proces. Het licentie‑XML‑bestand moet ongewijzigd blijven, en de licentie‑configuratie moet gesynchroniseerd worden wanneer meerdere threads betrokken zijn.

**Kan ik de PPTX die ik maak digitaal ondertekenen?**

Ja. [Digitale handtekeningen](/slides/nl/python-java/digital-signature-in-powerpoint/) (toevoegen en verifiëren) worden ondersteund voor presentaties.

**Worden macro’s (VBA) ondersteund in gemaakte presentaties?**

Ja. U kunt [VBA‑projecten maken/bewerken](/slides/nl/python-java/presentation-via-vba/) en macro‑ingeschakelde bestanden opslaan, zoals PPTM/PPSM.