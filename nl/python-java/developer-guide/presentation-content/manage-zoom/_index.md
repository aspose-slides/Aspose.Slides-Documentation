---
title: Beheer Presentatie‑Zoom in Python via Java
linktitle: Zoom beheren
type: docs
weight: 60
url: /nl/python-java/manage-zoom/
keywords:
- zoom
- zoomframe
- dia‑zoom
- sectie‑zoom
- samenvatting‑zoom
- zoom toevoegen
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Maak en pas Zoom aan met Aspose.Slides voor Python via Java — spring tussen secties, voeg miniaturen en overgangen toe in PPT-, PPTX- en ODP‑presentaties."
---
## **Introductie**

Zooms in PowerPoint laten u naar specifieke dia's, secties en delen van een presentatie springen en weer terugkeren. Tijdens het presenteren kan deze mogelijkheid om snel door de inhoud te navigeren erg handig zijn.

![overview_image](overview.png)

* Om een volledige presentatie op één dia samen te vatten, gebruikt u een [Samenvatting Zoom](#summary-zoom).
* Om alleen geselecteerde dia's weer te geven, gebruikt u een [Slide Zoom](#slide-zoom).
* Om slechts één sectie weer te geven, gebruikt u een [Section Zoom](#section-zoom).

## **Slide Zoom**

Een slide‑zoom kan uw presentatie dynamischer maken, waardoor u vrij tussen dia's kunt navigeren in elke gewenste volgorde zonder de stroom van uw presentatie te onderbreken. Slide‑zooms zijn ideaal voor korte presentaties zonder veel secties, maar u kunt ze ook in verschillende presentatiescenario’s gebruiken.

Slide‑zooms helpen u meerdere stukken informatie te verkennen terwijl het voelt alsof u zich op één enkel canvas bevindt.

![overview_image](slidezoomsel.png)

Voor slide‑zoom‑objecten biedt Aspose.Slides de enumeratie ZoomImageType, de klasse ZoomFrame en enkele methoden in de klasse ShapeCollection.

### **Zoom‑frames maken**

Zo voegt u een zoom‑frame toe aan een dia:

1. Maak een instantie van de klasse Presentation.
2. Maak nieuwe dia's aan waaraan u de zoom‑frames wilt koppelen.
3. Voeg identificerende tekst en een achtergrond toe aan de gemaakte dia's.
4. Voeg zoom‑frames (met verwijzingen naar de gemaakte dia's) toe aan de eerste dia.
5. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Python‑code laat zien hoe u een zoom‑frame op een dia kunt maken:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Voegt nieuwe dia's toe aan de presentatie
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Maakt een achtergrond voor de tweede dia
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Maakt een tekstvak voor de tweede dia
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Maakt een achtergrond voor de derde dia
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Maakt een tekstvak voor de derde dia
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Voegt ZoomFrame-objecten toe
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Slaat de presentatie op
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Zoom‑frames maken met aangepaste afbeeldingen**

Met Aspose.Slides voor Python via Java kunt u op deze manier een zoom‑frame met een andere dia‑voorbeeldafbeelding maken:

1. Maak een instantie van de klasse Presentation.
2. Maak een nieuwe dia aan waaraan u het zoom‑frame wilt koppelen.
3. Voeg identificerende tekst en een achtergrond toe aan de dia.
4. Maak een PPImage‑object aan door een afbeelding toe te voegen aan de afbeeldingenverzameling die aan het Presentation‑object is gekoppeld en die wordt gebruikt om het frame te vullen.
5. Voeg zoom‑frames (met de verwijzing naar de gemaakte dia) toe aan de eerste dia.
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Python‑code laat zien hoe u een zoom‑frame met een andere afbeelding kunt maken:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Voegt een nieuwe dia toe aan de presentatie
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Maakt een achtergrond voor de tweede dia
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Maakt een tekstvak voor de tweede dia
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Maakt een nieuwe afbeelding voor het zoom-object
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Voegt het ZoomFrame-object toe
    presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture)

    #  Slaat de presentatie op
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Zoom‑frames opmaken**

In de vorige secties hebben wij u laten zien hoe u eenvoudige zoom‑frames maakt. Om complexere zoom‑frames te maken, moet u de opmaak van een eenvoudig frame aanpassen. Er zijn verschillende opmaakopties die u op een zoom‑frame kunt toepassen.

Zo kunt u de opmaak van een zoom‑frame op een dia regelen:

1. Maak een instantie van de klasse Presentation.
2. Maak nieuwe dia's aan waaraan u de zoom‑frames wilt koppelen.
3. Voeg identificerende tekst en een achtergrond toe aan de gemaakte dia's.
4. Voeg zoom‑frames (met verwijzingen naar de gemaakte dia's) toe aan de eerste dia.
5. Maak een PPImage‑object aan door een afbeelding toe te voegen aan de afbeeldingenverzameling die aan het Presentation‑object is gekoppeld en die wordt gebruikt om het frame te vullen.
6. Stel een aangepaste afbeelding in voor het eerste zoom‑frame‑object.
7. Wijzig de lijstopmaak voor het tweede zoom‑frame‑object.
8. Verwijder de achtergrond van een afbeelding van het tweede zoom‑frame‑object.
9. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Python‑code laat zien hoe u de opmaak van een zoom‑frame op een dia kunt wijzigen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # Voegt nieuwe dia's toe aan de presentatie
    second_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())

    #  Maakt een achtergrond voor de tweede dia
    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)

    #  Maakt een tekstvak voor de tweede dia
    auto_shape = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Second Slide")

    #  Maakt een achtergrond voor de derde dia
    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray)

    #  Maakt een tekstvak voor de derde dia
    auto_shape = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    auto_shape.getTextFrame().setText("Third Slide")

    # Voegt ZoomFrame-objecten toe
    first_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    #  Maakt een nieuwe afbeelding voor het zoom-object
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Stelt aangepaste afbeelding in voor het first_zoom_frame-object
    first_zoom_frame.setZoomImage(picture)

    #  Stelt een zoom-frame-opmaak in voor het second_zoom_frame-object
    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink)
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    #  Instelling om de achtergrond niet te tonen voor het second_zoom_frame-object
    second_zoom_frame.setShowBackground(False)

    #  Slaat de presentatie op
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Section Zoom**

Een sectie‑zoom is een koppeling naar een sectie in uw presentatie. U kunt sectie‑zooms gebruiken om terug te gaan naar secties die u wilt benadrukken. Of u kunt ze gebruiken om te laten zien hoe bepaalde delen van uw presentatie met elkaar verbonden zijn.

![overview_image](seczoomsel.png)

Voor sectie‑zoom‑objecten biedt Aspose.Slides de klasse SectionZoomFrame en enkele methoden in de klasse ShapeCollection.

### **Sectie‑zoom‑frames maken**

Zo voegt u een sectie‑zoom‑frame toe aan een dia:

1. Maak een instantie van de klasse Presentation.
2. Maak een nieuwe dia aan.
3. Voeg een opvallende achtergrond toe aan de gemaakte dia.
4. Maak een nieuwe sectie aan waaraan u het zoom‑frame wilt koppelen.
5. Voeg een sectie‑zoom‑frame (met verwijzingen naar de gemaakte sectie) toe aan de eerste dia.
6. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Python‑code laat zien hoe u een zoom‑frame op een dia kunt maken:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Voegt een nieuwe dia toe aan de presentatie
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Voegt een nieuwe sectie toe aan de presentatie
    presentation.getSections().addSection("Section 1", slide)

    #  Voegt een SectionZoomFrame-object toe
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Slaat de presentatie op
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Sectie‑zoom‑frames maken met aangepaste afbeeldingen**

Met Aspose.Slides voor Python via Java kunt u op deze manier een sectie‑zoom‑frame met een andere dia‑voorbeeldafbeelding maken:

1. Maak een instantie van de klasse Presentation.
2. Maak een nieuwe dia aan.
3. Voeg een opvallende achtergrond toe aan de gemaakte dia.
4. Maak een nieuwe sectie aan waaraan u het zoom‑frame wilt koppelen.
5. Maak een PPImage‑object aan door een afbeelding toe te voegen aan de afbeeldingenverzameling die aan het Presentation‑object is gekoppeld en die wordt gebruikt om het frame te vullen.
6. Voeg een sectie‑zoom‑frame (met een verwijzing naar de gemaakte sectie) toe aan de eerste dia.
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Python‑code laat zien hoe u een zoom‑frame met een andere afbeelding kunt maken:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Voegt nieuwe dia toe aan de presentatie
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Voegt een nieuwe sectie toe aan de presentatie
    presentation.getSections().addSection("Section 1", slide)

    #  Maakt een nieuwe afbeelding voor het zoom-object
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    #  Voegt SectionZoomFrame-object toe
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1), picture)

    #  Slaat de presentatie op
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```
### **Sectie‑zoom‑frames opmaken**

Om complexere sectie‑zoom‑frames te maken, moet u de opmaak van een eenvoudig frame aanpassen. Er zijn verschillende opmaakopties die u op een sectie‑zoom‑frame kunt toepassen.

Zo kunt u de opmaak van een sectie‑zoom‑frame op een dia regelen:

1. Maak een instantie van de klasse Presentation.
2. Maak een nieuwe dia aan.
3. Voeg een opvallende achtergrond toe aan de gemaakte dia.
4. Maak een nieuwe sectie aan waaraan u het zoom‑frame wilt koppelen.
5. Voeg een sectie‑zoom‑frame (met verwijzingen naar de gemaakte sectie) toe aan de eerste dia.
6. Wijzig de grootte en positie van het gemaakte sectie‑zoom‑object.
7. Maak een PPImage‑object aan door een afbeelding toe te voegen aan de afbeeldingenverzameling die aan het Presentation‑object is gekoppeld en die wordt gebruikt om het frame te vullen.
8. Stel een aangepaste afbeelding in voor het gemaakte sectie‑zoom‑frame‑object.
9. Schakel de *terugkeren naar de oorspronkelijke dia vanaf de gekoppelde sectie* mogelijkheid in.
10. Verwijder de achtergrond van een afbeelding van het sectie‑zoom‑frame‑object.
11. Wijzig de lijstopmaak voor het sectie‑zoom‑frame‑object.
12. Wijzig de overgangsduur.
13. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Python‑code laat zien hoe u de opmaak van een sectie‑zoom‑frame kunt wijzigen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Voegt een nieuwe dia toe aan de presentatie
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Voegt een nieuwe sectie toe aan de presentatie
    presentation.getSections().addSection("Section 1", slide)

    #  Voegt SectionZoomFrame-object toe
    section_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, presentation.getSections().get_Item(1))

    #  Opmaak voor SectionZoomFrame
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    section_zoom_frame.setZoomImage(picture)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray)
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    #  Slaat de presentatie op
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Summary Zoom**

Een samenvatting‑zoom is als een landingspagina waarop alle onderdelen van uw presentatie tegelijk worden weergegeven. Tijdens het presenteren kunt u de zoom gebruiken om van de ene plek in uw presentatie naar een andere te gaan in elke gewenste volgorde. U kunt creatief zijn, vooruit springen of delen van uw diavoorstelling opnieuw bekijken zonder de stroom van uw presentatie te onderbreken.

![overview_image](sumzoomsel.png)

Voor samenvatting‑zoom‑objecten biedt Aspose.Slides de klassen SummaryZoomFrame, SummaryZoomSection en SummaryZoomSectionCollection en enkele methoden in de klasse ShapeCollection.

### **Een samenvatting‑zoom maken**

Zo voegt u een samenvatting‑zoom‑frame toe aan een dia:

1. Maak een instantie van de klasse Presentation.
2. Maak nieuwe dia's met een opvallende achtergrond en nieuwe secties voor de gemaakte dia's.
3. Voeg het samenvatting‑zoom‑frame toe aan de eerste dia.
4. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Python‑code laat zien hoe u een samenvatting‑zoom‑frame op een dia kunt maken:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Voegt een nieuwe dia toe aan de presentatie
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Voegt een nieuwe sectie toe aan de presentatie
    presentation.getSections().addSection("Section 1", slide)

    # Voegt een nieuwe dia toe aan de presentatie
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Voegt een nieuwe sectie toe aan de presentatie
    presentation.getSections().addSection("Section 2", slide)

    # Voegt een nieuwe dia toe aan de presentatie
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Voegt een nieuwe sectie toe aan de presentatie
    presentation.getSections().addSection("Section 3", slide)

    # Voegt een nieuwe dia toe aan de presentatie
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Voegt een nieuwe sectie toe aan de presentatie
    presentation.getSections().addSection("Section 4", slide)

    #  Voegt een SummaryZoomFrame-object toe
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Slaat de presentatie op
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Een samenvatting‑zoom‑sectie toevoegen en verwijderen**

Alle secties in een samenvatting‑zoom‑frame worden vertegenwoordigd door SummaryZoomSection‑objecten, die worden opgeslagen in het SummaryZoomSectionCollection‑object. U kunt een samenvatting‑zoom‑sectie‑object toevoegen of verwijderen via de SummaryZoomSectionCollection‑klasse op de volgende manier:

1. Maak een instantie van de klasse Presentation.
2. Maak nieuwe dia's met een opvallende achtergrond en nieuwe secties voor de gemaakte dia's.
3. Voeg een samenvatting‑zoom‑frame toe aan de eerste dia.
4. Voeg een nieuwe dia en sectie toe aan de presentatie.
5. Voeg de gemaakte sectie toe aan het samenvatting‑zoom‑frame.
6. Verwijder de eerste sectie uit het samenvatting‑zoom‑frame.
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Python‑code laat zien hoe u secties in een samenvatting‑zoom‑frame kunt toevoegen en verwijderen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Voegt een nieuwe dia toe aan de presentatie
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Voegt een nieuwe sectie toe aan de presentatie
    presentation.getSections().addSection("Section 1", slide)

    # Voegt een nieuwe dia toe aan de presentatie
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Voegt een nieuwe sectie toe aan de presentatie
    presentation.getSections().addSection("Section 2", slide)

    #  Voegt SummaryZoomFrame-object toe
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    # Voegt een nieuwe dia toe aan de presentatie
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Voegt een nieuwe sectie toe aan de presentatie
    third_section = presentation.getSections().addSection("Section 3", slide)

    #  Voegt een sectie toe aan de Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    #  Verwijdert sectie uit de Summary Zoom
    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(presentation.getSections().get_Item(1))

    #  Slaat de presentatie op
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Samenvatting‑zoom‑secties opmaken**

Om complexere samenvatting‑zoom‑sectie‑objecten te maken, moet u de opmaak van een eenvoudig frame aanpassen. Er zijn verschillende opmaakopties die u op een samenvatting‑zoom‑sectie‑object kunt toepassen.

Zo kunt u de opmaak van een samenvatting‑zoom‑sectie‑object in een samenvatting‑zoom‑frame regelen:

1. Maak een instantie van de klasse Presentation.
2. Maak nieuwe dia's met een opvallende achtergrond en nieuwe secties voor de gemaakte dia's.
3. Voeg een samenvatting‑zoom‑frame toe aan de eerste dia.
4. Haal het eerste samenvatting‑zoom‑sectie‑object op uit de SummaryZoomSectionCollection.
5. Maak een PPImage‑object aan door een afbeelding toe te voegen aan de afbeeldingenverzameling die aan het Presentation‑object is gekoppeld en die wordt gebruikt om het frame te vullen.
6. Stel een aangepaste afbeelding in voor het samenvatting‑zoom‑sectie‑object.
7. Schakel de *terugkeren naar de oorspronkelijke dia vanaf de gekoppelde sectie* mogelijkheid in.
8. Wijzig de lijstopmaak voor het samenvatting‑zoom‑sectie‑object.
9. Wijzig de overgangsduur.
10. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

Deze Python‑code laat zien hoe u de opmaak van een samenvatting‑zoom‑sectie‑object kunt wijzigen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Voegt een nieuwe dia toe aan de presentatie
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Voegt een nieuwe sectie toe aan de presentatie
    presentation.getSections().addSection("Section 1", slide)

    # Voegt een nieuwe dia toe aan de presentatie
    slide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    #  Voegt een nieuwe sectie toe aan de presentatie
    presentation.getSections().addSection("Section 2", slide)

    #  Voegt een SummaryZoomFrame-object toe
    summary_zoom_frame = presentation.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    #  Haalt het eerste SummaryZoomSection-object op
    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    #  Opmaak voor SummaryZoomSection-object
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()
    summary_section.setZoomImage(picture)

    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    #  Slaat de presentatie op
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan ik het terugkeren naar de ‘ouder’-dia regelen nadat het doel is getoond?**

Ja. De ZoomFrame of SectionZoomFrame ondersteunt het terugkeren naar de oorspronkelijke dia via setReturnToParent, waardoor kijkers worden teruggestuurd nadat ze de doelinhoud hebben bezocht wanneer dit is ingeschakeld.

**Kan ik de ‘snelheid’ of duur van de Zoom‑overgang aanpassen?**

Ja. Zoom ondersteunt het instellen van een overgangsduur met setTransitionDuration, zodat u kunt bepalen hoe lang de springanimatie duurt.

**Zijn er beperkingen op het aantal Zoom‑objecten dat een presentatie kan bevatten?**

Er is geen harde API‑limiet gedocumenteerd. Praktische beperkingen hangen af van de algehele complexiteit van de presentatie en de prestaties van de viewer. U kunt veel Zoom‑frames toevoegen, maar houd rekening met de bestandsgrootte en de renderingsduur.