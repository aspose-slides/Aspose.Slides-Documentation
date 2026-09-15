---
title: Voorkom bewerking van presentaties met vormvergrendelingen
linktitle: Voorkom bewerking van presentaties
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
- groepering vergrendelen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Java
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides for Python via Java vormen in PPT-, PPTX- en ODP‑bestanden vergrendelt of ontgrendelt, waardoor presentaties worden beveiligd terwijl gecontroleerde bewerkingen mogelijk zijn en de levering wordt versneld."
---
## **Achtergrond**

Een veelvoorkomend gebruik van Aspose.Slides is het maken, bijwerken en opslaan van Microsoft PowerPoint (PPTX)-presentaties als onderdeel van een geautomatiseerde workflow. Gebruikers van applicaties die Aspose.Slides op deze manier inzetten, hebben toegang tot de gegenereerde presentaties, dus het beschermen ervan tegen bewerking is een veelvoorkomend aandachtspunt. Het is belangrijk dat automatisch gegenereerde presentaties hun oorspronkelijke opmaak en inhoud behouden.

Dit artikel legt uit hoe presentaties en dia's zijn gestructureerd en hoe Aspose.Slides for Python via Java bescherming kan toepassen op een presentatie en deze later kan verwijderen. Het biedt ontwikkelaars een manier om te bepalen hoe de presentaties die hun applicaties genereren, worden gebruikt.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autovormen, tabellen, OLE‑objecten, gegroepeerde vormen, foto‑frames, video‑frames, connectoren en andere elementen die worden gebruikt om een presentatie op te bouwen. In Aspose.Slides for Python via Java wordt elk element op een dia weergegeven door een object dat erft van de [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/)‑klasse.

De structuur van PPTX is complex, dus in tegenstelling tot PPT, waar een algemene lock kan worden gebruikt voor alle vormen, vereisen verschillende vormtypen verschillende locks. De [BaseShapeLock](https://reference.aspose.com/slides/nl/python-java/aspose.slides/baseshapelock/)‑klasse is de generieke lock‑klasse voor PPTX. De volgende soorten locks worden ondersteund in Aspose.Slides for Python via Java voor PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/nl/python-java/aspose.slides/autoshapelock/) vergrendelt autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/nl/python-java/aspose.slides/connectorlock/) vergrendelt connector‑vormen.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nl/python-java/aspose.slides/graphicalobjectlock/) vergrendelt grafische objecten.  
- [GroupShapeLock](https://reference.aspose.com/slides/nl/python-java/aspose.slides/groupshapelock/) vergrendelt groep‑vormen.  
- [PictureFrameLock](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pictureframelock/) vergrendelt foto‑frames.  

Elke handeling die wordt uitgevoerd op alle vorm‑objecten in een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑object, wordt toegepast op de volledige presentatie.

## **Bescherming toepassen en verwijderen**

Bescherming toepassen zorgt ervoor dat een presentatie niet kan worden bewerkt. Het is een handige techniek om de inhoud van de presentatie te beveiligen.

### **Bescherming toepassen op PPTX‑vormen**

Aspose.Slides for Python via Java biedt de [Shape](https://reference.aspose.com/slides/nl/python-java/aspose.slides/shape/)‑klasse om met vormen op een dia te werken.

Zoals eerder vermeld, heeft elke vorm‑klasse een bijbehorende vorm‑lock‑klasse voor bescherming. Dit artikel richt zich op de NoSelect-, NoMove- en NoResize‑locks. Deze locks zorgen ervoor dat vormen niet kunnen worden geselecteerd (via muisklikken of andere selectiemethoden) en dat ze niet kunnen worden verplaatst of van grootte veranderd.

De volgende codevoorbeelden passen bescherming toe op alle vormtypen in een presentatie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Instantieer de Presentation‑klasse die een PPTX‑bestand representeert.
presentation = Presentation("Sample.pptx")
try:
    # Doorloop alle dia's in de presentatie.
    for slide in presentation.getSlides():
        # Doorloop alle vormen in de dia.
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

    # Sla het presentatiebestand op.
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Bescherming verwijderen**

Om een vorm te ontgrendelen, zet u de waarde van de toegepaste lock op `False`. Het volgende codevoorbeeld laat zien hoe u vormen in een vergrendelde presentatie kunt ontgrendelen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Instantieer de Presentation-klasse die een PPTX-bestand vertegenwoordigt.
presentation = Presentation("ProtectedSample.pptx")
try:
    # Doorloop alle dia's in de presentatie.
    for slide in presentation.getSlides():
        # Doorloop alle vormen in de dia.
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

    # Sla het presentatie-bestand op.
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Conclusie**

Aspose.Slides biedt verschillende opties om vormen in een presentatie te beschermen. U kunt een individuele vorm vergrendelen of door alle vormen in een presentatie itereren en elke vorm vergrendelen om het gehele bestand effectief te beveiligen. U kunt de bescherming verwijderen door de lock‑waarde op `False` te zetten.

## **FAQ**

**Kan ik vorm‑locks combineren met wachtwoordbeveiliging in dezelfde presentatie?**

Ja. Locks beperken het bewerken van objecten binnen het bestand, terwijl [password protection](/slides/nl/python-java/password-protected-presentation/) de toegang tot het openen en/of opslaan van wijzigingen regelt. Deze mechanismen vullen elkaar aan en werken samen.

**Kan ik bewerking beperken op specifieke dia's zonder andere te beïnvloeden?**

Ja. Pas locks toe op de vormen op de geselecteerde dia's; de overige dia's blijven bewerkbaar.

**Zijn vorm‑locks van toepassing op gegroepeerde objecten en connectoren?**

Ja. Specifieke lock‑typen worden ondersteund voor groepen, connectoren, grafische objecten en andere vormsoorten.