---
title: Beperk Bewerken van Presentaties met Vormvergrendelingen in Python
linktitle: Beperk Bewerken van Presentaties
type: docs
weight: 70
url: /nl/python-net/applying-protection-to-presentation/
keywords:
- voorkom bewerkingen
- bescherm tegen bewerken
- vergrendel vorm
- vergrendel positie
- vergrendel selectie
- vergrendel grootte wijzigen
- vergrendel groeperen
- PowerPoint
- PPTX
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u vormen in PPTX-presentaties kunt vergrendelen en ontgrendelen met Aspose.Slides for Python via .NET om selectie, verplaatsing, grootte wijzigen en groepering te beperken."
---
## **Achtergrond**

Een veelvoorkomende toepassing van Aspose.Slides for Python via .NET is het maken, bijwerken en opslaan van PowerPoint (PPTX)-presentaties als onderdeel van een geautomatiseerde workflow. Wanneer gebruikers deze presentaties ontvangen, kan het beperken van wijzigingen in vormen helpen de beoogde lay-out en inhoud te behouden.

Dit artikel legt uit hoe vormen op dia's zijn georganiseerd en hoe je vormvergrendelingen kunt toepassen en verwijderen in een PPTX‑presentatie. Deze vergrendelingen stellen je in staat specifieke bewerkingsbewerkingen op individuele vormen te beperken.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autoshapes, tabellen, OLE‑objecten, gegroepeerde vormen, beeldframes, videoframes, connectoren en andere elementen die worden gebruikt om een presentatie op te bouwen. In Aspose.Slides for Python via .NET wordt elk element op een dia weergegeven door een object dat erft van de [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) klasse.

Verschillende vormtypen bieden verschillende vergrendelingsopties. De [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) klasse is de basisklasse voor vormvergrendelingen. Aspose.Slides for Python via .NET biedt de volgende vergrendelingsklassen:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) vergrendelt autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) vergrendelt connectorvormen.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) vergrendelt grafische objecten.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) vergrendelt gegroepeerde vormen.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) vergrendelt beeldframes.  

Om vergrendelingen toe te passen over een [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), doorloop je de dia's en stel je de juiste vergrendelingen in op elke ondersteunde vorm.

## **Vergrendeling toepassen en verwijderen**

Vormvergrendelingen beperken bewerkingen zoals het selecteren, verplaatsen en de grootte wijzigen van vormen. Ze maken de hele presentatie niet onbewerkbaar.

### **Beveiliging toepassen op PPTX‑vormen**

Aspose.Slides for Python via .NET biedt de [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) klasse om met vormen op een dia te werken.

Het voorbeeld stelt [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/) , [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) en [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) in op `True` voor autoshapes, met overeenkomstige vergrendelingen voor gegroepeerde vormen, connectoren en beeldframes. Connectoren gebruiken [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) voor verplaatsing; groepen gebruiken ook [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) om groeperen te beperken.

Het voorbeeld laadt een bestaande PPTX‑presentatie, controleert de vormen in de vormverzameling van elke dia en slaat een kopie op met deze beperkingen toegepast. Vormen buiten de vier behandelde types blijven ongewijzigd. De lus doorloopt de onderliggende vormen van een groep niet.

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

### **Beveiliging verwijderen**

Om een vormvergrendeling te verwijderen, stel je de waarde in op `False`. Het volgende voorbeeld laadt een presentatie met vormvergrendelingen en wist de selecteer‑, verplaats‑ en grootte‑wijzigingsbeperkingen via [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) , [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) , [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) en [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Het wist ook [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) en slaat een kopie van de presentatie op. Andere vergrendelingsinstellingen blijven ongewijzigd.

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

### **Conclusie**

Aspose.Slides for Python via .NET stelt je in staat specifieke bewerkingsbewerkingen op individuele vormen te beperken of dezelfde beperkingen over dia's toe te passen. Kies de vergrendelingen die door elk type vorm worden ondersteund, en stel hun waarden in op `False` wanneer je die beperkingen wilt verwijderen.

## **FAQ**

**Kan ik vormvergrendelingen combineren met wachtwoordbeveiliging in dezelfde presentatie?**

Ja. Vormvergrendelingen beperken specifieke bewerkingsbewerkingen, terwijl [wachtwoordbeveiliging](/slides/nl/python-net/password-protected-presentation/) kan beperken wie de presentatie kan openen of wijzigen. Je kunt beide in hetzelfde bestand gebruiken.

**Kan ik bewerken beperken op specifieke dia's zonder anderen te beïnvloeden?**

Ja. Pas vergrendelingen alleen toe op vormen op de geselecteerde dia's. Dit verandert de vergrendelingsinstellingen op andere dia's niet.

**Hoe kan ik vergrendelingen toepassen op individuele vormen binnen een groep?**

Itereer door de [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) collectie van de groep en pas de juiste vergrendelingen toe op elke onderliggende vorm. Herhaal dit voor geneste groepen. De bovenstaande voorbeelden verwerken alleen de vormverzameling van de dia, dus ze stellen geen vergrendelingen in op individuele groepsleden.