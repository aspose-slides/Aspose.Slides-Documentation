---
title: Beperk bewerkingen van presentatie met vormvergrendelingen in Python
linktitle: Beperk bewerkingen van presentatie
type: docs
weight: 70
url: /nl/python-net/applying-protection-to-presentation/
keywords:
- bewerkingen voorkomen
- beschermen tegen bewerken
- vorm vergrendelen
- positie vergrendelen
- selectie vergrendelen
- grootte aanpassen vergrendelen
- groeperen vergrendelen
- PowerPoint
- PPTX
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u vormen in PPTX-presentaties kunt vergrendelen en ontgrendelen met Aspose.Slides for Python via .NET om selectie, beweging, grootte-aanpassing en groeperen te beperken."
---
## **Achtergrond**

Een veelvoorkomend gebruik van Aspose.Slides for Python via .NET is het maken, bijwerken en opslaan van PowerPoint (PPTX) presentaties als onderdeel van een geautomatiseerde workflow. Wanneer gebruikers deze presentaties ontvangen, kan het beperken van wijzigingen aan vormen helpen de beoogde lay‑out en inhoud te behouden.

Dit artikel legt uit hoe vormen georganiseerd zijn op dia's en hoe u vormvergrendelingen kunt toepassen en verwijderen in een PPTX‑presentatie. Deze vergrendelingen stellen u in staat specifieke bewerkingsacties op individuele vormen te beperken.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autovormen, tabellen, OLE‑objecten, gegroepeerde vormen, afbeeldingskaders, videokaders, connectors en andere elementen die worden gebruikt om een presentatie op te bouwen. In Aspose.Slides for Python via .NET wordt elk element op een dia weergegeven door een object dat erft van de [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)‑klasse.

Verschillende vormtypen bieden verschillende vergrendelingsopties. De [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/)‑klasse is de basisklasse voor vormvergrendelingen. Aspose.Slides for Python via .NET levert de volgende vergrendelingsklassen:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) vergrendelt autovormen.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) vergrendelt connectorvormen.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) vergrendelt grafische objecten.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) vergrendelt gegroepeerde vormen.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) vergrendelt afbeeldingskaders.  

Om vergrendelingen toe te passen op een [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), doorloopt u de dia's en stelt u de juiste vergrendelingen in op elke ondersteunde vorm.

## **Toepassen en verwijderen van bescherming**

Compatibele presentatie‑editors gebruiken vormvergrendelingen om individuele bewerkingsacties te beperken. Bestandsversleuteling en schrijfbeveiliging op documentniveau zijn afzonderlijke [presentatie‑beveiligingsinstellingen](/slides/nl/python-net/password-protected-presentation/).

### **Bescherming toepassen op PPTX‑vormen**

Aspose.Slides for Python via .NET biedt de [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)‑klasse om met vormen op een dia te werken.

Het voorbeeld stelt [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/), en [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) in op `True` voor autovormen, met overeenkomstige vergrendelingen voor gegroepeerde vormen, connectoren en afbeeldingskaders. Connectoren gebruiken [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) voor beweging; groepen gebruiken ook [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) om groeperen te beperken.

Het voorbeeld laadt een bestaande PPTX‑presentatie, controleert de vormen in de vormverzameling van elke dia en slaat een kopie op met deze toegepaste beperkingen. Vormen buiten de vier behandelde typen blijven ongewijzigd. De lus doorloopt de onderliggende vormen binnen een groep niet.

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Bescherming verwijderen**

Om een vormvergrendeling te verwijderen, stelt u de waarde in op `False`. Het volgende voorbeeld laadt een presentatie met vormvergrendelingen en wist de selectie‑, beweeg‑ en formaatbeperkingen via [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/), en [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Het wist bovendien [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) en slaat een kopie van de presentatie op. Andere vergrendelingsinstellingen blijven ongewijzigd.

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Een afbeelding‑bijsnijden behouden**

Plaats een foto met de naam `photo.jpg` in de werkmap. Het voorbeeld snijdt 12 % van de linkerkant en 8 % van de rechterkant bij, en stelt vervolgens [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) in op het afbeeldingskader. Deze vlag beperkt verdere bijsnijding en behoudt de bestaande bijsnijding.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` slaat de bijsnijd‑vergrendeling op als `True`. In PowerPoint is de **Crop**‑opdracht uitgeschakeld wanneer de foto is geselecteerd.

### **Een diagram gegroepeerd houden**

Het voorbeeld groepeert een rechthoek en een pijl, en stelt vervolgens [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) in op de groep zelf om de componenten van het diagram bijeengehouden. Andere bewerkingen, zoals het verplaatsen van de groep of het wijzigen van de opvulling van een component, blijven beschikbaar.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` slaat de ungrouping‑vergrendeling op als `True`. In PowerPoint is de **Ungroup**‑opdracht uitgeschakeld wanneer het volledige diagram is geselecteerd.

### **Bestaande vormvergrendelingen rapporteren**

Om een sjabloon te bekijken, opent u deze en leest u het vergrendelingsobject voor elke vorm. [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) is `True` wanneer alle vlaggen op dat object uitgeschakeld zijn en `False` wanneer er ten minste één is ingeschakeld. Een groep en de onderliggende vormen hebben aparte vergrendelingsobjecten, dus inspecteer de onderliggende vormen zelfs wanneer de groep geen vergrendelingen heeft.

Dit voorbeeld controleert beweging voor autovormen, afbeeldingskaders en groepen, bijsnijden voor afbeeldingen, en ungrouping voor groepen. Het rapporteert de vlaggen die het herkent en markeert vormtypen die het niet inspecteert.

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

Stel dat dia 1 van `Sample.pptx` een groep bevat met de naam `Layout` waarvoor ungrouping is vergrendeld, een afbeelding met de naam `Photo` erin met bijsnijden vergrendeld, en een niet‑vergrendelde rechthoek met de naam `Free`. Het rapport slaat `Free` over en toont deze twee regels:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

Het rapport leest de opgeslagen bewerkingsvlaggen op vormniveau zonder ze te wijzigen of de presentatie op te slaan. Schrijfbeveiliging op documentniveau is een aparte instelling, en de handhaving van elke vlag hangt af van de editor.

### **Conclusie**

Aspose.Slides for Python via .NET stelt u in staat specifieke bewerkingsacties op individuele vormen te beperken of dezelfde beperkingen over dia's heen toe te passen. Kies de vergrendelingen die door elk type vorm worden ondersteund en stel hun waarden in op `False` wanneer u die beperkingen wilt verwijderen.

## **FAQ**

**Kan ik vormvergrendelingen en wachtwoordbeveiliging combineren in dezelfde presentatie?**

Ja. Vormvergrendelingen beperken specifieke bewerkingsacties, terwijl [wachtwoordbeveiliging](/slides/nl/python-net/password-protected-presentation/) kan beperken dat de presentatie geopend of gewijzigd wordt. U kunt beide in hetzelfde bestand gebruiken.

**Kan ik bewerking beperken op specifieke dia's zonder andere te beïnvloeden?**

Ja. Pas vergrendelingen alleen toe op vormen op de geselecteerde dia's. Dit verandert de vergrendelingsinstellingen op andere dia's niet.

**Hoe kan ik vergrendelingen toepassen op individuele vormen binnen een groep?**

Doorloop de [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/)‑verzameling van de groep en pas de juiste vergrendelingen toe op elke onderliggende vorm. Herhaal dit voor geneste groepen, volgens de traversing in het rapportage‑voorbeeld.