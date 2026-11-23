---
title: Beperk bewerkingen van presentaties met vormvergrendelingen in Python
linktitle: Beperk bewerkingen van presentaties
type: docs
weight: 70
url: /nl/python-net/applying-protection-to-presentation/
keywords:
- bewerkingen voorkomen
- beschermen tegen bewerking
- vorm vergrendelen
- positie vergrendelen
- selectie vergrendelen
- grootte vergrendelen
- groepering vergrendelen
- PowerPoint
- PPTX
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u vormen in PPTX-presentaties kunt vergrendelen en ontgrendelen met Aspose.Slides for Python via .NET om selectie, verplaatsing, grootte-aanpassing en groepering te beperken."
---
## **Achtergrond**

Een veelvoorkomend gebruik van Aspose.Slides for Python via .NET is het maken, bijwerken en opslaan van PowerPoint‑presentaties (PPTX) als onderdeel van een geautomatiseerde werkstroom. Wanneer gebruikers deze presentaties ontvangen, kan het beperken van wijzigingen aan vormen helpen de beoogde lay‑out en inhoud te behouden.

Dit artikel legt uit hoe vormen zijn georganiseerd op dia's en hoe u vormvergrendelingen kunt toepassen en verwijderen in een PPTX‑presentatie. Deze vergrendelingen laten u specifieke bewerkingsbewerkingen op individuele vormen beperken.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autoshapes, tabellen, OLE‑objecten, gegroepeerde vormen, afbeeldingskaders, video‑kaders, connectoren en andere elementen die worden gebruikt om een presentatie op te bouwen. In Aspose.Slides for Python via .NET wordt elk element op een dia weergegeven door een object dat erft van de [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) klasse.

Verschillende vormtypes bieden verschillende vergrendelingsopties. De [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) klasse is de basisklasse voor vormvergrendelingen. Aspose.Slides for Python via .NET levert de volgende vergrendelingsklassen:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) vergrendelt autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) vergrendelt connectorvormen.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) vergrendelt grafische objecten.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) vergrendelt gegroepeerde vormen.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) vergrendelt afbeeldingskaders.  

Om vergrendelingen toe te passen op een [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), doorloop je de dia's en stel je de juiste vergrendelingen in op elke ondersteunde vorm.

## **Toepassen en verwijderen van bescherming**

Compatibele presentatie‑editors gebruiken vormvergrendelingen om individuele bewerkingsbewerkingen te beperken. Bestand‑versleuteling en document‑niveau schrijfbescherming zijn afzonderlijke [presentation protection settings](/slides/nl/python-net/password-protected-presentation/).

### **Bescherming toepassen op PPTX‑vormen**

Aspose.Slides for Python via .NET biedt de [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) klasse om met vormen op een dia te werken.

Het voorbeeld stelt [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/) , [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) en [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) in op `True` voor autoshapes, met gelijksoortige vergrendelingen voor gegroepeerde vormen, connectoren en afbeeldingskaders. Connectoren gebruiken [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) voor verplaatsing; groepen gebruiken ook [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) om groeperen te beperken.

Het voorbeeld laadt een bestaande PPTX‑presentatie, controleert de vormen in de vormverzameling van elke dia en slaat een kopie op met deze restricties toegepast. Vormen buiten de vier behandelde typen blijven ongewijzigd. De lus doorloopt niet de onderliggende vormen binnen een groep.

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

Om een vormvergrendeling te verwijderen, stel je de waarde in op `False`. Het volgende voorbeeld laadt een presentatie met vormvergrendelingen en wist de selectie‑, verplaatsings‑ en formaat‑restricties via [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) , [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) , [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) en [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Het wist ook [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) en slaat een kopie van de presentatie op. Andere vergrendelingsinstellingen blijven ongewijzigd.

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

### **Bijsnede van afbeelding behouden**

Plaats een foto met de naam `photo.jpg` in de werkmap. Het voorbeeld snijdt 12 % van de linkerkant en 8 % van de rechterkant bij, en stelt vervolgens [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) in op het afbeeldingskader om de bijsnijding te behouden.

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

`PictureLocked.pptx` slaat de bijsnijdingsvergrendeling op als `True`. In PowerPoint is de **Crop**‑opdracht uitgeschakeld wanneer de foto is geselecteerd.

### **Diagram gegroepeerd houden**

Het voorbeeld groepeert een rechthoek en een pijl, en stelt vervolgens [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) in op de groep zelf om de componenten van het diagram samen te houden. Andere bewerkingen, zoals het verplaatsen van de groep of het wijzigen van de vulling van een component, blijven beschikbaar.

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

### **Conclusie**

Aspose.Slides for Python via .NET stelt u in staat specifieke bewerkingsbewerkingen op individuele vormen te beperken of dezelfde beperkingen over dia's heen toe te passen. Kies de vergrendelingen die door elk vormtype worden ondersteund, en zet hun waarden op `False` wanneer u die restricties wilt verwijderen.

## **Veelgestelde vragen**

**Kan ik vormvergrendelingen en wachtwoordbeveiliging combineren in dezelfde presentatie?**

Ja. Vormvergrendelingen beperken specifieke bewerkingsbewerkingen, terwijl [password protection](/slides/nl/python-net/password-protected-presentation/) het openen of wijzigen van de presentatie kan beperken. U kunt beide in hetzelfde bestand gebruiken.

**Kan ik bewerken beperken op specifieke dia's zonder andere dia's te beïnvloeden?**

Ja. Pas vergrendelingen alleen toe op vormen op de geselecteerde dia's. Dit verandert de vergrendelingsinstellingen op andere dia's niet.

**Hoe kan ik vergrendelingen toepassen op individuele vormen binnen een groep?**

Itereer door de [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) collectie van de groep en stel de juiste vergrendelingen in voor elke onderliggende vorm. Herhaal dit voor eventuele geneste groepen. De voorbeelden hierboven verwerken alleen de vormverzameling van de dia, dus ze stellen geen vergrendelingen in voor individuele groepsleden.