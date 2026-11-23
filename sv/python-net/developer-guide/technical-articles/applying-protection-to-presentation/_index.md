---
title: Begränsa redigering av presentationer med formlås i Python
linktitle: Begränsa redigering av presentationer
type: docs
weight: 70
url: /sv/python-net/applying-protection-to-presentation/
keywords:
- förhindra redigering
- skydda mot redigering
- låsa form
- låsa position
- låsa urval
- låsa storleksändring
- låsa gruppering
- PowerPoint
- PPTX
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du låser och låser upp former i PPTX-presentationer med Aspose.Slides för Python via .NET för att begränsa urval, rörelse, storleksändring och gruppering."
---
## **Bakgrund**

En vanlig användning av Aspose.Slides för Python via .NET är att skapa, uppdatera och spara PowerPoint (PPTX)-presentationer som en del av ett automatiserat arbetsflöde. När användare får dessa presentationer kan begränsning av ändringar i former hjälpa till att bevara den avsedda layouten och innehållet.

Den här artikeln förklarar hur former är organiserade på bilder och hur man tillämpar och tar bort lås på former i en PPTX-presentation. Dessa lås låter dig begränsa specifika redigeringsåtgärder på enskilda former.

## **Komposition av en bild**

En presentationsbild består av komponenter såsom autoshapes, tabeller, OLE-objekt, grupperade former, bildramar, videoramar, anslutningar och andra element som används för att bygga en presentation. I Aspose.Slides för Python via .NET representeras varje element på en bild av ett objekt som ärver från klassen [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

Olika formertyper ger olika låsalternativ. Klassen [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) är basklassen för lås på former. Aspose.Slides för Python via .NET tillhandahåller följande låsklasser:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) låser autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) låser anslutningsformer.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) låser grafiska objekt.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) låser gruppformer.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) låser bildramar.  

För att tillämpa lås över en [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) itereras genom dess bilder och de lämpliga låsen sätts på varje stödjade form.

## **Tillämpa och ta bort skydd**

Kompatibla presentationsredigerare använder lås på former för att begränsa individuella redigeringsåtgärder. Filkryptering och skrivskydd på dokumentnivå är separata [presentationsskyddsinställningar](/slides/sv/python-net/password-protected-presentation/).

### **Tillämpa skydd på PPTX-former**

Aspose.Slides för Python via .NET tillhandahåller klassen [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) för att arbeta med former på en bild.

Exemplet sätter [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/), och [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) till `True` för autoshapes, med motsvarande lås för gruppformer, anslutningar och bildramar. Anslutningar använder [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) för rörelse; grupper använder också [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) för att begränsa gruppering.

Exemplet laddar en befintlig PPTX-presentation, kontrollerar formerna i varje bilds formsamling och sparar en kopia med dessa begränsningar tillämpade. Former utanför de fyra hanterade typerna lämnas oförändrade. Loopen traverserar inte de underordnade formerna i en grupp.

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

### **Ta bort skydd**

För att ta bort ett lås på en form, sätt dess värde till `False`. Följande exempel laddar en presentation med lås på former och rensar urval-, rörelse- och storleksändringsbegränsningarna via [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/), och [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Det rensar också [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) och sparar en kopia av presentationen. Andra låsinställningar lämnas oförändrade.

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

### **Bevara en bildbeskärning**

Placera ett foto med namnet `photo.jpg` i arbetskatalogen. Exemplet beskär 12% från vänster och 8% från höger, och sätter sedan [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) på bildramen för att bevara beskärningen.

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

`PictureLocked.pptx` sparar beskärningslåset som `True`. I PowerPoint är kommandot **Crop** inaktiverat när fotot är markerat.

### **Behåll ett diagram grupperat**

Exemplet grupperar en rektangel och en pil, och sätter sedan [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) på själva gruppen för att hålla diagrammets komponenter tillsammans. Andra redigeringar, som att flytta gruppen eller ändra en komponents fyllning, förblir tillgängliga.

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

`DiagramLocked.pptx` sparar avgrupperingslåset som `True`. I PowerPoint är kommandot **Ungroup** inaktiverat när hela diagrammet är markerat.

### **Slutsats**

Aspose.Slides för Python via .NET låter dig begränsa specifika redigeringsåtgärder på enskilda former eller tillämpa samma begränsningar över bilder. Välj de lås som stöds av varje formtyp och sätt deras värden till `False` när du behöver ta bort dessa begränsningar.

## **FAQ**

**Kan jag kombinera lås på former och lösenordsskydd i samma presentation?**

Ja. Lås på former begränsar specifika redigeringsåtgärder, medan [lösenordsskydd](/slides/sv/python-net/password-protected-presentation/) kan begränsa öppning eller modifiering av presentationen. Du kan använda båda i samma fil.

**Kan jag begränsa redigering på specifika bilder utan att påverka andra?**

Ja. Tillämpa lås endast på former på de valda bilderna. Detta ändrar inte låsinställningarna på andra bilder.

**Hur kan jag tillämpa lås på enskilda former i en grupp?**

Iterera genom gruppens [former](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/)‑samling och tillämpa de lämpliga låsen på varje underform. Upprepa detta för eventuella nästlade grupper. Exemplen ovan bearbetar endast bildens formsamling, så de sätter inte lås på enskilda gruppmedlemmar.