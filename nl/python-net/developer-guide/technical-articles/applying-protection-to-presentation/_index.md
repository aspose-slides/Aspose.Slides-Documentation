---
title: Voorkom bewerkingen van presentaties met shape-vergrendelingen in Python
linktitle: Voorkom bewerkingen van presentaties
type: docs
weight: 70
url: /nl/python-net/applying-protection-to-presentation/
keywords:
- bewerkingen voorkomen
- beschermen tegen bewerken
- shape vergrendelen
- positie vergrendelen
- selectie vergrendelen
- grootte vergrendelen
- groepering vergrendelen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Ontdek hoe Aspose.Slides for Python via .NET shapes in PPT-, PPTX- en ODP-bestanden vergrendelt of ontgrendelt, presentaties beveiligt terwijl gecontroleerde bewerkingen mogelijk worden gemaakt en een snellere levering wordt bereikt."
---
## **Achtergrond**

Een veelvoorkomend gebruik van Aspose.Slides is het maken, bijwerken en opslaan van Microsoft PowerPoint (PPTX)-presentaties als onderdeel van een geautomatiseerde workflow. Gebruikers van toepassingen die Aspose.Slides op deze manier gebruiken hebben toegang tot de gegenereerde presentaties, waardoor het beschermen ervan tegen bewerking een veelvoorkomend punt van zorg is. Het is belangrijk dat automatisch gegenereerde presentaties hun oorspronkelijke opmaak en inhoud behouden.

Dit artikel legt uit hoe presentaties en dia's zijn gestructureerd en hoe Aspose.Slides for Python bescherming kan toepassen op een presentatie en later kan verwijderen. Het biedt ontwikkelaars een manier om te bepalen hoe de presentaties die hun toepassingen genereren gebruikt worden.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autoshapes, tabellen, OLE‑objecten, gegroepeerde shapes, beeldkaders, videokaders, connectoren en andere elementen die worden gebruikt om een presentatie op te bouwen. In Aspose.Slides for Python wordt elk element op een dia vertegenwoordigd door een object dat erft van de [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/)‑klasse.

De structuur van PPTX is complex, dus in tegenstelling tot PPT, waar een generieke vergrendeling voor alle soorten shapes kan worden gebruikt, vereisen verschillende shape‑typen verschillende vergrendelingen. De [BaseShapeLock](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseshapelock/)‑klasse is de generieke vergrendelingsklasse voor PPTX. De volgende soorten vergrendelingen worden ondersteund in Aspose.Slides for Python voor PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshapelock/) vergrendelt autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/nl/python-net/aspose.slides/connectorlock/) vergrendelt connector‑shapes.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nl/python-net/aspose.slides/graphicalobjectlock/) vergrendelt grafische objecten.  
- [GroupShapeLock](https://reference.aspose.com/slides/nl/python-net/aspose.slides/groupshapelock/) vergrendelt groep‑shapes.  
- [PictureFrameLock](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframelock/) vergrendelt beeldkaders.  

Elke handeling die wordt uitgevoerd op alle shape‑objecten in een [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑object, wordt toegepast op de volledige presentatie.

## **Bescherming toepassen en verwijderen**

Het toepassen van bescherming zorgt ervoor dat een presentatie niet kan worden bewerkt. Het is een handige techniek om de inhoud van de presentatie te beschermen.

### **Bescherming toepassen op PPTX‑shapes**

Aspose.Slides for Python biedt de [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/)‑klasse om met shapes op een dia te werken.

Zoals eerder vermeld, heeft elke shape‑klasse een bijbehorende shape‑lock‑klasse voor bescherming. Dit artikel richt zich op de NoSelect‑, NoMove‑ en NoResize‑vergrendelingen. Deze vergrendelingen zorgen ervoor dat shapes niet kunnen worden geselecteerd (via muisklikken of andere selectiemethoden) en dat ze niet kunnen worden verplaatst of van formaat kunnen worden veranderd.

De code‑voorbeeld hieronder past bescherming toe op alle shape‑typen in een presentatie.

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een PPTX-bestand vertegenwoordigt.
with slides.Presentation("Sample.pptx") as presentation:
    # Doorloop alle dia's in de presentatie.
    for slide in presentation.slides:
        # Doorloop alle shapes in de dia.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # Sla het presentiebestand op.
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Bescherming verwijderen**

Om een shape te ontgrendelen, stel je de waarde van de toegepaste vergrendeling in op `False`. Het volgende code‑voorbeeld laat zien hoe je shapes in een vergrendelde presentatie kunt ontgrendelen.

```py
import aspose.slides as slides

# Maak een instantie van de Presentation-klasse die een PPTX-bestand vertegenwoordigt.
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # Doorloop alle dia's in de presentatie.
    for slide in presentation.slides:
        # Doorloop alle shapes in de dia.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # Sla het presentiebestand op.
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Conclusie**

Aspose.Slides biedt diverse opties om shapes in een presentatie te beschermen. Je kunt een individuele shape vergrendelen of door alle shapes in een presentatie itereren en elk afzonderlijk vergrendelen om het gehele bestand effectief te beveiligen. Je kunt de bescherming verwijderen door de vergrendelingswaarde op `False` te zetten.

## **FAQ**

**Kan ik shape‑vergrendelingen en wachtwoordbeveiliging combineren in dezelfde presentatie?**

Ja. Vergrendelingen beperken het bewerken van objecten in het bestand, terwijl de [password protection](/slides/nl/python-net/password-protected-presentation/) de toegang tot het openen en/of opslaan van wijzigingen regelt. Deze mechanismen vullen elkaar aan en werken samen.

**Kan ik bewerken beperken op specifieke dia's zonder de andere te beïnvloeden?**

Ja. Breng vergrendelingen aan op de shapes op de geselecteerde dia's; de overige dia's blijven bewerkbaar.

**Zijn shape‑vergrendelingen van toepassing op gegroepeerde objecten en connectoren?**

Ja. Er worden specifieke vergrendelings‑types ondersteund voor groepen, connectoren, grafische objecten en andere shape‑soorten.