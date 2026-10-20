---
title: Beperk bewerkingen van presentaties met vormvergrendelingen in Python
linktitle: Beperk presentatiewijzigingen
type: docs
weight: 60
url: /nl/python-java/applying-protection-to-presentation/
keywords:
- bewerkingen voorkomen
- beschermen tegen bewerken
- vorm vergrendelen
- positie vergrendelen
- selectie vergrendelen
- grootte wijzigen vergrendelen
- groepering vergrendelen
- PowerPoint
- PPTX
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u vormen in PPTX‑presentaties kunt vergrendelen en ontgrendelen met Aspose.Slides for Python via Java om selectie, verplaatsing, grootte‑aanpassing en groepering te beperken."
---
## **Achtergrond**

Een veelvoorkomend gebruik van Aspose.Slides for Python via Java is het maken, bijwerken en opslaan van PowerPoint (PPTX) presentaties als onderdeel van een geautomatiseerde workflow. Wanneer gebruikers deze presentaties ontvangen, kan het beperken van wijzigingen aan vormen helpen de beoogde lay‑out en inhoud te behouden.

Dit artikel legt uit hoe vormen op dia's zijn georganiseerd en hoe je vergrendelingen op vormen kunt toepassen en verwijderen in een PPTX‑presentatie. Deze vergrendelingen laten je specifieke bewerkingsbewerkingen op individuele vormen beperken.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autoshapes, tabellen, OLE‑objecten, gegroepeerde vormen, afbeelding‑frames, video‑frames, connectoren en andere elementen die worden gebruikt om een presentatie op te bouwen. In Aspose.Slides for Python via Java wordt elk element op een dia weergegeven door een object dat erft van de [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)‑klasse.

Verschillende vormtypes bieden verschillende vergrendelingsopties. De [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/)‑klasse is de basisklasse voor vormvergrendelingen. Aspose.Slides for Python via Java levert de volgende vergrendelingsklassen:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) vergrendelt autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) vergrendelt connectorvormen.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) vergrendelt grafische objecten.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) vergrendelt groepvormen.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) vergrendelt afbeelding‑frames.  

Om vergrendelingen toe te passen op een [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), doorloop je de dia's en stel je de juiste vergrendelingen in op elke ondersteunde vorm.

## **Bescherming toepassen en verwijderen**

Vormvergrendelingen beperken bewerkingen zoals het selecteren, verplaatsen en wijzigen van de grootte van vormen. Ze maken de hele presentatie niet onveranderlijk.

### **Bescherming toepassen op PPTX‑vormen**

Aspose.Slides for Python via Java biedt de [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/)‑klasse om met vormen op een dia te werken.

Het voorbeeld roept [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) en [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) aan met `True` voor autoshapes, met overeenkomstige vergrendelingen voor groepvormen, connectoren en afbeelding‑frames. Connectoren gebruiken [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) voor verplaatsing; groepen gebruiken ook [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) om groepering te beperken.

Het voorbeeld laadt een bestaande PPTX‑presentatie, controleert de vormen in de vormverzameling van elke dia en slaat een kopie op met deze beperkingen toegepast. Vormen buiten de vier behandelde typen blijven ongewijzigd. De lus doorloopt niet de onderliggende vormen binnen een groep.

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

### **Bescherming verwijderen**

Om een vormvergrendeling te verwijderen, stel je de waarde in op `False`. Het volgende voorbeeld laadt een presentatie met vormvergrendelingen en wist de selectie‑, verplaatsings‑ en grootte‑beperkingen via [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) en [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Het verwijdert ook de groeperingsbeperking door `False` door te geven aan [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) en slaat een kopie van de presentatie op. Andere vergrendelingsinstellingen blijven ongewijzigd.

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

### **Conclusie**

Aspose.Slides for Python via Java stelt je in staat specifieke bewerkingsbewerkingen op individuele vormen te beperken of dezelfde beperkingen over meerdere dia's toe te passen. Kies de vergrendelingen die door elk vormtype worden ondersteund en stel hun waarden in op `False` wanneer je die beperkingen wilt verwijderen.

## **FAQ**

**Kan ik vormvergrendelingen en wachtwoordbeveiliging combineren in dezelfde presentatie?**

Ja. Vormvergrendelingen beperken specifieke bewerkingsbewerkingen, terwijl [wachtwoordbeveiliging](/slides/nl/python-java/password-protected-presentation/) de opening of wijziging van de presentatie kan beperken. Je kunt beide in hetzelfde bestand gebruiken.

**Kan ik bewerken beperken op specifieke dia's zonder andere te beïnvloeden?**

Ja. Pas vergrendelingen alleen toe op vormen op de geselecteerde dia's. Dit verandert de vergrendelingsinstellingen op andere dia's niet.

**Hoe kan ik vergrendelingen toepassen op individuele vormen binnen een groep?**

Doorloop de verzameling die wordt geretourneerd door de [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes)‑methode van de groep en pas de juiste vergrendelingen toe op elke onderliggende vorm. Herhaal dit voor eventuele geneste groepen. De bovenstaande voorbeelden verwerken alleen de vormverzameling van de dia, dus ze stellen geen vergrendelingen in op individuele groepsleden.