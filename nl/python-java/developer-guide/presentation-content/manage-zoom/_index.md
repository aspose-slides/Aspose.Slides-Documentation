---
title: Beheer presentatiezoom in Python via Java
linktitle: Beheer Zoom
type: docs
weight: 60
url: /nl/python-java/manage-zoom/
keywords:
- zoom
- zoomframe
- dia-zoom
- sectie-zoom
- samenvatting-zoom
- zoom toevoegen
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Maak en pas Zoom aan met Aspose.Slides voor Python via Java — spring tussen secties, voeg miniaturen en overgangen toe in PowerPoint-presentaties."
---
## **Introductie**

PowerPoint-zoom's stellen u in staat om tijdens een diavoorstelling tussen specifieke dia's en secties te navigeren. Met Aspose.Slides voor Python via Java kunt u dia‑, sectie‑ en samenvatting‑zoom’s maken en de voorvertoningen, randen en overgangen aanpassen.

![PowerPoint zoom overview](overview.png)

* Om een volledige presentatie op één dia samen te vatten, gebruikt u een [Samenvatting Zoom](#summary-zoom).
* Om alleen geselecteerde dia's weer te geven, gebruikt u een [Dia Zoom](#slide-zoom).
* Om slechts één sectie weer te geven, gebruikt u een [Sectie Zoom](#section-zoom).

## **Dia Zoom**

Een dia‑zoom kan uw presentatie dynamischer maken, waardoor u vrijelijk tussen dia's kunt navigeren in elke gewenste volgorde zonder de stroom van uw presentatie te onderbreken. Dia‑zoom’s zijn ideaal voor korte presentaties zonder veel secties, maar u kunt ze ook in verschillende presentatiescenario’s gebruiken.

Dia‑zoom’s laten u gerelateerde informatie verkennen vanaf één overzichts‑dia.

![Selecting slides for a slide zoom](slidezoomsel.png)

Voor dia‑zoom‑objecten biedt Aspose.Slides de [ZoomImageType](https://reference.aspose.com/slides/python-java/aspose.slides/zoomimagetype/) enumeratie, de [ZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/zoomframe/) klasse en methoden op de [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) klasse.

### **Zoom‑frames maken**

Gebruik [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame) om koppelingen naar individuele dia's op een overzichts‑dia te plaatsen. Dit voorbeeld maakt twee doel‑dia's met verschillende achtergronden en labels, voegt vervolgens een voorvertoning van elke toe aan de eerste dia en slaat de presentatie op als PPTX. Posities en afmetingen van de frames worden opgegeven in points.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Zoom‑frames maken met aangepaste afbeeldingen**

Geef een aangepaste afbeelding door aan [ShapeCollection.addZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addZoomFrame), zodat de standaardvoorvertoning van de doel‑dia wordt vervangen. Dit voorbeeld vereist een lokale afbeelding, laadt deze met [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile), en voegt haar toe aan de presentatie via [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). Het resulterende frame toont die afbeelding terwijl het nog steeds naar de tweede dia linkt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().setType(BackgroundType.OwnBackground)
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    overview_slide.getShapes().addZoomFrame(20, 20, 300, 200, slide, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Zoom‑frames opmaken**

Dit voorbeeld past twee dia‑zoom‑frames aan. Het kent een lokale afbeelding toe aan het eerste frame via [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage), en geeft het tweede frame een roze rand van vijf points, streep‑punt stijl via [Shape.getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat). Het doorgeven van `False` aan [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) verbergt de achtergrond van het tweede frame. Een lokale afbeelding is vereist voor de aangepaste voorvertoning; beide frames behouden hun dia‑doelen in de opgeslagen PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    second_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    third_slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())

    second_slide.getBackground().setType(BackgroundType.OwnBackground)
    second_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    second_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)

    text_box = second_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Second Slide")

    third_slide.getBackground().setType(BackgroundType.OwnBackground)
    third_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    third_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(189, 183, 107))

    text_box = third_slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200)
    text_box.getTextFrame().setText("Third Slide")

    first_zoom_frame = overview_slide.getShapes().addZoomFrame(20, 20, 250, 200, second_slide)
    second_zoom_frame = overview_slide.getShapes().addZoomFrame(200, 250, 250, 200, third_slide)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    first_zoom_frame.setZoomImage(preview_image)

    second_zoom_frame.getLineFormat().setWidth(5)
    second_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    second_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(255, 105, 180))
    second_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)

    second_zoom_frame.setShowBackground(False)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Sectie Zoom**

Een sectie‑zoom linkt naar een sectie in uw presentatie. Gebruik het om een onderwerp opnieuw te bezoeken of te laten zien hoe verschillende delen van de presentatie met elkaar verbonden zijn.

![Selecting a section for a section zoom](seczoomsel.png)

Voor sectie‑zoom‑objecten biedt Aspose.Slides de [SectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/) klasse en methoden op de [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) klasse.

### **Sectie‑zoom‑frames maken**

Maak een sectie met [SectionCollection.addSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectioncollection/#addSection), geef vervolgens de teruggegeven sectie door aan [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame). Dit voorbeeld plaatst een sectie‑zoom op de eerste dia en linkt deze naar een sectie die begint met een gekleurde dia. De positie en afmetingen van het frame worden opgegeven in points, en de presentatie wordt opgeslagen als PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Sectie‑zoom‑frames maken met aangepaste afbeeldingen**

De afbeelding‑overload van [ShapeCollection.addSectionZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSectionZoomFrame) maakt het mogelijk een aangepaste voorvertoning weer te geven zonder de doel‑sectie te wijzigen. Dit voorbeeld vereist een lokale afbeelding, die wordt geladen met [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) en toegevoegd via [ImageCollection.addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage). De opgeslagen presentatie bevat een sectie‑zoom op de eerste dia die gekoppeld is aan de nieuw aangemaakte sectie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section = presentation.getSections().addSection("Section 1", slide)
    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section, preview_image)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Doel‑sectie van een sectie‑zoom wijzigen**

Gebruik [SectionZoomFrame.setTargetSection](https://reference.aspose.com/slides/python-java/aspose.slides/sectionzoomframe/#setTargetSection) om een bestaande sectie‑zoom te herrouteren zonder deze opnieuw te maken. Kies een gevulde sectie uit de [Presentation.getSections](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSections) collectie van dezelfde presentatie. Het toewijzen van een lege sectie laat het huidige doel ongewijzigd, controleer dus [Section.getSlidesListOfSection](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSlidesListOfSection) voordat u dit doet. Zie [Beheer dia‑secties](/slides/nl/python-java/slide-section/) voor meer informatie over secties.

Het onderstaande voorbeeld laadt een presentatiew‑bestand dat meerdere gevulde secties moet bevatten, een bestaande sectie‑zoom met de naam `Section navigation` en een sectie met de unieke naam `Results`. Het doorzoekt alle dia's naar de zoom en vindt het doel op naam in plaats van via een collectie‑index die kan veranderen wanneer secties opnieuw worden geordend. Als namen niet uniek zijn, gebruik dan [Section.getSectionId](https://reference.aspose.com/slides/python-java/aspose.slides/section/#getSectionId) om het doel te identificeren.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SectionZoomFrame

presentation = Presentation("section-zoom.pptx")
try:
    zoom = None
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, SectionZoomFrame) and shape.getName() == "Section navigation":
                zoom = shape
                break
        if zoom is not None:
            break

    target_section = None
    for section in presentation.getSections():
        if section.getName() == "Results":
            target_section = section
            break

    if zoom is None or target_section is None:
        print("The section zoom or destination section was not found.")
    elif target_section.getSlidesListOfSection().size() == 0:
        print("The destination section is empty.")
    else:
        current_section = zoom.getTargetSection()
        current_name = "" if current_section is None else current_section.getName()
        print("Current section: " + str(current_name))
        zoom.setTargetSection(target_section)
        presentation.save("section-zoom-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Sectie‑zoom‑frames opmaken**

Dit voorbeeld verplaatst en schaalt een sectie‑zoom tot 100 bij 75 points, kent een lokale afbeelding toe via [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage), en past een bruine rand van 2,5 points, streep‑punt stijl toe. Het activeert [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) zodat er na de sectie wordt teruggegaan naar de oorspronkelijke dia, schakelt [ZoomObject.setShowBackground](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setShowBackground) uit en stelt [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) in op 1,5 seconden. Een lokale afbeelding is vereist voor de aangepaste voorvertoning.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(154, 205, 50))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    section = presentation.getSections().addSection("Section 1", slide)

    section_zoom_frame = overview_slide.getShapes().addSectionZoomFrame(20, 20, 300, 200, section)
    section_zoom_frame.setX(100)
    section_zoom_frame.setY(300)
    section_zoom_frame.setWidth(100)
    section_zoom_frame.setHeight(75)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    section_zoom_frame.setZoomImage(preview_image)

    section_zoom_frame.setReturnToParent(True)
    section_zoom_frame.setShowBackground(False)

    section_zoom_frame.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    section_zoom_frame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    section_zoom_frame.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    section_zoom_frame.getLineFormat().setWidth(2.5)

    section_zoom_frame.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Samenvatting Zoom**

Een samenvatting‑zoom biedt een overzicht van de presentatiesecties. Tijdens een diavoorstelling kunt u ernaar springen om naar een sectie te gaan, vooruit te bladeren of een onderwerp opnieuw te bekijken zonder de volgorde van de dia's te volgen.

![Selecting sections for a summary zoom](sumzoomsel.png)

Voor samenvatting‑zoom‑objecten biedt Aspose.Slides de [SummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/), [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/), en [SummaryZoomSectionCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/) klassen en methoden op de [ShapeCollection](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/) klasse.

### **Een samenvatting‑zoom maken**

Gebruik [ShapeCollection.addSummaryZoomFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addSummaryZoomFrame) om een overzicht van de secties van de presentatie te maken. Dit voorbeeld maakt vier secties met verschillende dia‑achtergronden en voegt een samenvatting‑zoom toe aan de eerste dia. De positie en afmetingen van het frame worden opgegeven in points, en het resulterende overzicht wordt opgeslagen in een PPTX‑presentatie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 3", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(0, 100, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 4", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Een samenvatting‑zoom‑sectie toevoegen en verwijderen**

Een samenvatting‑zoom slaat zijn [SummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsection/) objecten op in [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection). Dit voorbeeld maakt een overzicht van twee secties, voegt een derde sectie toe met [SummaryZoomSectionCollection.addSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#addSummaryZoomSection), en verwijdert de eerste sectie‑entry met [SummaryZoomSectionCollection.removeSummaryZoomSection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomsectioncollection/#removeSummaryZoomSection). Het verwijderen van de entry laat de presentatiesectie en de dia's onaangetast.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    first_section = presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(127, 255, 0))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    third_section = presentation.getSections().addSection("Section 3", slide)

    summary_zoom_frame.getSummaryZoomCollection().addSummaryZoomSection(third_section)

    summary_zoom_frame.getSummaryZoomCollection().removeSummaryZoomSection(first_section)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Samenvatting‑zoom‑secties opmaken**

Dit voorbeeld formatteert de eerste entry in [SummaryZoomFrame.getSummaryZoomCollection](https://reference.aspose.com/slides/python-java/aspose.slides/summaryzoomframe/#getSummaryZoomCollection), met de nul‑gebaseerde index `0`. Het vereist een lokale afbeelding voor [ZoomObject.setZoomImage](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setZoomImage), past een zwarte rand van 1,5 points, streep‑punt stijl toe, en stelt [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration) in op 1,5 seconden. Het doorgeven van `False` aan [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) schakelt de automatische terugkeer naar de samenvattingsdia voor deze entry uit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Images, LineDashStyle, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    overview_slide = presentation.getSlides().get_Item(0)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color(165, 42, 42))
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 1", slide)

    slide = presentation.getSlides().addEmptySlide(overview_slide.getLayoutSlide())
    slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.CYAN)
    slide.getBackground().setType(BackgroundType.OwnBackground)

    presentation.getSections().addSection("Section 2", slide)

    summary_zoom_frame = overview_slide.getShapes().addSummaryZoomFrame(150, 50, 300, 200)

    summary_section = summary_zoom_frame.getSummaryZoomCollection().get_Item(0)

    image = Images.fromFile("image.png")
    try:
        preview_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    summary_section.setZoomImage(preview_image)
    summary_section.setReturnToParent(False)

    summary_section.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    summary_section.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    summary_section.getLineFormat().setDashStyle(LineDashStyle.DashDot)
    summary_section.getLineFormat().setWidth(1.5)

    summary_section.setTransitionDuration(1.5)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Veelgestelde vragen**

**Kan ik het terugkeren naar de 'ouder'-dia regelen na het weergeven van het doel?**

Ja. Roep [ZoomObject.setReturnToParent](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setReturnToParent) aan met `True` om terug te keren naar de oorspronkelijke dia nadat de doelinhoud is getoond.

**Kan ik de 'snelheid' of duur van de Zoom‑overgang aanpassen?**

Ja. Gebruik [ZoomObject.setTransitionDuration](https://reference.aspose.com/slides/python-java/aspose.slides/zoomobject/#setTransitionDuration), om de duur van de overgang in seconden te regelen.

**Zijn er limieten voor het aantal Zoom‑objecten dat een presentatie kan bevatten?**

Er is geen harde API‑limiet gedocumenteerd. Praktische limieten hangen af van de algehele complexiteit van de presentatie en de prestaties van de viewer. U kunt veel Zoom‑frames toevoegen, maar houd rekening met de bestandsgrootte en render‑tijd.