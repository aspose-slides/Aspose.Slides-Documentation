---
title: Beperk bewerkingen van presentaties met vormvergrendelingen in Python
linktitle: Beperk presentatie-bewerkingen
type: docs
weight: 60
url: /nl/python-java/applying-protection-to-presentation/
keywords:
- bewerkingen voorkomen
- beschermen tegen bewerken
- vorm vergrendelen
- positie vergrendelen
- selectie vergrendelen
- grootte vergrendelen
- groeperen vergrendelen
- PowerPoint
- PPTX
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u vormen in PPTX-presentaties kunt vergrendelen en ontgrendelen met Aspose.Slides for Python via Java om selectie, verplaatsing, formaatwijziging en groeperen te beperken."
---
## **Achtergrond**

Een veelvoorkomend gebruik van Aspose.Slides for Python via Java is het maken, bijwerken en opslaan van PowerPoint‑presentaties (PPTX) als onderdeel van een geautomatiseerde workflow. Wanneer gebruikers deze presentaties ontvangen, kan het beperken van wijzigingen aan vormen helpen de beoogde lay‑out en inhoud te behouden.

Dit artikel legt uit hoe vormen zijn georganiseerd op dia’s en hoe je vormvergrendelingen kunt toepassen en verwijderen in een PPTX‑presentatie. Deze vergrendelingen laten je specifieke bewerkingshandelingen op individuele vormen beperken.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autoshapes, tabellen, OLE‑objecten, gegroepeerde vormen, foto‑frames, video‑frames, connectors en andere elementen die worden gebruikt om een presentatie op te bouwen. In Aspose.Slides for Python via Java wordt elk element op een dia weergegeven door een object dat is afgeleid van de [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)‑klasse.

Verschillende vormtypen bieden verschillende vergrendelingsopties. De [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/)‑klasse is de basisklasse voor vormvergrendelingen. Aspose.Slides for Python via Java biedt de volgende vergrendelingsklassen:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) vergrendelt autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) vergrendelt connector‑vormen.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) vergrendelt grafische objecten.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) vergrendelt gegroepeerde vormen.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) vergrendelt foto‑frames.  

Om vergrendelingen toe te passen op een [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), doorloop je de dia’s en stel je de juiste vergrendelingen in op elke ondersteunde vorm.

## **Vergrendeling toepassen en verwijderen**

Compatibele presentatieredacteurs gebruiken vormvergrendelingen om individuele bewerkingsacties te beperken. Bestandsversleuteling en schrijfbescherming op documentniveau zijn aparte [presentation protection settings](/slides/nl/python-java/password-protected-presentation/).

### **Vergrendeling toepassen op PPTX‑vormen**

Aspose.Slides for Python via Java biedt de [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)‑klasse om met vormen op een dia te werken.

Het voorbeeld roept [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) en [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) aan met `True` voor autoshapes, met equivalente vergrendelingen voor gegroepeerde vormen, connectors en foto‑frames. Connectors gebruiken [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) voor verplaatsing; groepen gebruiken bovendien [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) om groeperen te beperken.

Het voorbeeld laadt een bestaande PPTX‑presentatie, controleert de vormen in de vormcollectie van elke dia en slaat een kopie op met deze beperkingen toegepast. Vormen buiten de vier behandelde typen blijven ongewijzigd. De lus doorloopt de kindvormen binnen een groep niet.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Vergrendeling verwijderen**

Om een vormvergrendeling te verwijderen, stel je de waarde in op `False`. Het volgende voorbeeld laadt een presentatie met vormvergrendelingen en wist de selectie‑, verplaatsings‑ en wijzigingsbeperkingen via [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) en [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Het verwijdert tevens de groeperingsbeperking door `False` door te geven aan [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) en slaat een kopie van de presentatie op. Andere vergrendelingsinstellingen blijven ongewijzigd.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Een foto‑bijsnijding behouden**

Plaats een foto met de naam `photo.jpg` in de werkmap. Het voorbeeld snijdt 12 % van de linker‑ en 8 % van de rechterkant bij, en roept vervolgens [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) aan met `True` om de bijsnijding te behouden.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

In `PictureLocked.pptx` schakelt PowerPoint de **Crop**‑opdracht uit wanneer je de foto selecteert.

### **Een diagram gegroepeerd houden**

Het voorbeeld groepeert een rechthoek en een pijl, en roept vervolgens [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) aan met `True` om de twee vormen samen te houden. Je kunt de groep nog steeds verplaatsen of de opvulling van een component wijzigen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

In `DiagramLocked.pptx` schakelt PowerPoint de **Ungroup**‑opdracht uit wanneer je het volledige diagram selecteert.

### **Bestaande vormvergrendelingen rapporteren**

Om een sjabloon te inspecteren, open je deze en lees je het vergrendelingsobject voor elke vorm. De [getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks)‑methode retourneert `True` wanneer alle vlaggen op dat object zijn uitgeschakeld en `False` wanneer er minstens één is ingeschakeld. Een groep en haar kinderen hebben afzonderlijke vergrendelingsobjecten, dus inspecteer je de kinderen ook wanneer de groep geen vergrendelingen heeft.

Dit voorbeeld controleert verplaatsing voor autoshapes, foto‑frames en groepen. Het controleert tevens bijsnijden voor foto's en degroeperen voor groepen. Het rapport vermeldt de ingeschakelde vlaggen die het herkent en markeert vormtypen die het niet inspecteert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

Stel je voor dat dia 1 van `Sample.pptx` een groep bevat met de naam `Layout` waarvan het degroeperen is vergrendeld, een foto met de naam `Photo` binnen die groep waarvoor de bijsnijding is vergrendeld, en een niet‑vergrendelde rechthoek met de naam `Free`. Het rapport slaat `Free` over en geeft deze twee regels weer:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Het rapport leest de opgeslagen bewerkingsvlaggen op vormniveau zonder ze te wijzigen of de presentatie op te slaan. Bescherming op documentniveau is een aparte instelling, en de handhaving van elke vlag hangt af van de editor.

### **Conclusie**

Aspose.Slides for Python via Java stelt je in staat specifieke bewerkingshandelingen op individuele vormen te beperken of dezelfde beperkingen over meerdere dia’s toe te passen. Kies de vergrendelingen die worden ondersteund door elk vormtype, en stel hun waarden in op `False` wanneer je die beperkingen moet verwijderen.

## **FAQ**

**Kan ik vormvergrendelingen combineren met wachtwoordbeveiliging in dezelfde presentatie?**

Ja. Vormvergrendelingen beperken specifieke bewerkingsacties, terwijl [password protection](/slides/nl/python-java/password-protected-presentation/) kan beperken wie de presentatie mag openen of wijzigen. Je kunt beide in hetzelfde bestand gebruiken.

**Kan ik bewerking op specifieke dia’s beperken zonder de andere te beïnvloeden?**

Ja. Pas vergrendelingen alleen toe op vormen op de geselecteerde dia’s. Dit verandert de vergrendelingsinstellingen op andere dia’s niet.

**Hoe kan ik vergrendelingen toepassen op individuele vormen binnen een groep?**

Door de collectie te doorlopen die wordt geretourneerd door de [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes)‑methode van de groep en de juiste vergrendelingen op elke child‑vorm toe te passen. Herhaal dit voor geneste groepen, volgens de traversaal in het rapportage‑voorbeeld.