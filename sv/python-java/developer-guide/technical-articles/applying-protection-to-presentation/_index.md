---
title: Begränsa redigering av presentation med lås för former i Python
linktitle: Begränsa redigering av presentation
type: docs
weight: 60
url: /sv/python-java/applying-protection-to-presentation/
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
- Java
- Aspose.Slides
description: "Lär dig hur du låser och låser upp former i PPTX-presentationer med Aspose.Slides för Python via Java för att begränsa urval, förflyttning, storleksändring och gruppering."
---
## **Bakgrund**

En vanlig användning av Aspose.Slides för Python via Java är att skapa, uppdatera och spara PowerPoint (PPTX)-presentationer som en del av ett automatiserat arbetsflöde. När användare får dessa presentationer kan begränsning av ändringar i former hjälpa till att bevara den avsedda layouten och innehållet.

Denna artikel förklarar hur former är organiserade på bilder och hur man tillämpar och tar bort lås för former i en PPTX-presentation. Dessa lås låter dig begränsa specifika redigeringsåtgärder på enskilda former.

## **Komposition av en bild**

En presentationsbild består av komponenter såsom autoshapes, tabeller, OLE-objekt, grupperade former, bildramar, videoramar, anslutningar och andra element som används för att bygga en presentation. I Aspose.Slides för Python via Java representeras varje element på en bild av ett objekt som ärver från klassen [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) .

Olika formtyper visar olika låsalternativ. Klassen [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) är basklassen för lås på former. Aspose.Slides för Python via Java tillhandahåller följande låsklasser:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) låser autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) låser anslutningsformer.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) låser grafiska objekt.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) låser gruppformer.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) låser bildramar.  

För att tillämpa lås över en [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), iterera genom dess bilder och ange de lämpliga låsen på varje stödjd form.

## **Tillämpa och ta bort skydd**

Lås för former begränsar operationer såsom att välja, flytta och ändra storlek på former. De gör inte hela presentationen oföränderlig.

### **Tillämpa skydd på PPTX-former**

Aspose.Slides för Python via Java tillhandahåller klassen [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) för att arbeta med former på en bild.

Exemplet anropar [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) och [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) med `True` för autoshapes, med motsvarande lås för gruppformer, anslutningar och bildramar. Anslutningar använder [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) för förflyttning; grupper använder även [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) för att begränsa gruppering.

Exemplet läser in en befintlig PPTX-presentation, kontrollerar formerna i varje bilds formsamling och sparar en kopia med dessa begränsningar tillämpade. Former utanför de fyra hanterade typerna lämnas oförändrade. Loopen traverserar inte de underordnade formerna inuti en grupp.

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

### **Ta bort skydd**

För att ta bort ett lås på en form, sätt dess värde till `False`. Följande exempel läser in en presentation med lås på former och rensar urval, förflyttning och storleksändringsrestriktioner via [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) och [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/). Det tar också bort grupperingrestriktionen genom att skicka `False` till [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) och sparar en kopia av presentationen. Andra låsinställningar lämnas oförändrade.

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

### **Slutsats**

Aspose.Slides för Python via Java låter dig begränsa specifika redigeringsåtgärder på enskilda former eller tillämpa samma begränsningar över bilder. Välj de lås som stöds av varje formtyp och sätt deras värden till `False` när du behöver ta bort dessa begränsningar.

## **FAQ**

**Kan jag kombinera lås för former och lösenordsskydd i samma presentation?**

Ja. Lås för former begränsar specifika redigeringsåtgärder, medan [lösenordsskydd](/slides/sv/python-java/password-protected-presentation/) kan begränsa öppning eller ändring av presentationen. Du kan använda båda i samma fil.

**Kan jag begränsa redigering på specifika bilder utan att påverka andra?**

Ja. Tillämpa lås endast på former på de valda bilderna. Detta ändrar inte låsinställningarna på andra bilder.

**Hur kan jag tillämpa lås på enskilda former i en grupp?**

Iterera genom samlingen som returneras av gruppens [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes)‑metod och tillämpa lämpliga lås på varje underform. Upprepa detta för eventuella inbäddade grupper. Exemplen ovan bearbetar endast bildens formsamling, så de sätter inte lås på enskilda gruppmedlemmar.