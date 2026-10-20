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
- låsa val
- låsa storleksändring
- låsa gruppering
- PowerPoint
- PPTX
- presentation
- Python
- Aspose.Slides
description: "Lär dig hur du låser och låser upp former i PPTX-presentationer med Aspose.Slides for Python via .NET för att begränsa val, förflyttning, storleksändring och gruppering."
---
## **Bakgrund**

En vanlig användning av Aspose.Slides for Python via .NET är att skapa, uppdatera och spara PowerPoint (PPTX)-presentationer som en del av ett automatiserat arbetsflöde. När användare får dessa presentationer kan begränsning av ändringar av former hjälpa till att bevara den avsedda layouten och innehållet.

Den här artikeln förklarar hur former är organiserade på bilder och hur man tillämpar och tar bort lås för former i en PPTX‑presentation. Dessa lås låter dig begränsa specifika redigeringsåtgärder på enskilda former.

## **Komposition av en bild**

En presentationsbild består av komponenter som autoshapes, tabeller, OLE‑objekt, grupperade former, bildramar, videoramar, anslutningar och andra element som används för att bygga en presentation. I Aspose.Slides for Python via .NET representeras varje element på en bild av ett objekt som ärver från klassen [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/).

Olika formtyper exponerar olika låsalternativ. Klassen [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) är basklassen för lås för former. Aspose.Slides for Python via .NET tillhandahåller följande låsklasser:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) låser autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) låser anslutningsformer.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) låser grafiska objekt.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) låser gruppformer.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) låser bildramar.  

För att tillämpa lås över en [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), iterera genom dess bilder och sätt de lämpliga låsen på varje stödd form.

## **Tillämpa och ta bort skydd**

Formlås begränsar operationer såsom att välja, flytta och ändra storlek på former. De gör inte hela presentationen oredigerbar.

### **Tillämpa skydd på PPTX‑former**

Aspose.Slides for Python via .NET tillhandahåller klassen [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) för att arbeta med former på en bild.

Exemplet sätter [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) och [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) till `True` för autoshapes, med motsvarande lås för gruppformer, anslutningar och bildramar. Anslutningar använder [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) för förflyttning; grupper använder också [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) för att begränsa gruppering.

Exemplet läser in en befintlig PPTX‑presentation, kontrollerar formerna i varje bilds formsamling och sparar en kopia med dessa begränsningar tillämpade. Former utanför de fyra hanterade typerna lämnas oförändrade. Loopen traverserar inte de underliggande formerna i en grupp.

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

För att ta bort ett formlås, sätt dess värde till `False`. Följande exempel läser in en presentation med formlås och rensar urval-, förflyttnings- och storleksändringsbegränsningarna via [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) och [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Det rensar också [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) och sparar en kopia av presentationen. Övriga låsinställningar lämnas oförändrade.

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

### **Slutsats**

Aspose.Slides for Python via .NET låter dig begränsa specifika redigeringsåtgärder på enskilda former eller tillämpa samma begränsningar över flera bilder. Välj de lås som stöds av varje formtyp och sätt deras värden till `False` när du behöver ta bort dessa begränsningar.

## **Vanliga frågor**

**Kan jag kombinera formlås och lösenordsskydd i samma presentation?**

Ja. Formlås begränsar specifika redigeringsåtgärder, medan [password protection](/slides/sv/python-net/password-protected-presentation/) kan begränsa öppning eller ändring av presentationen. Du kan använda båda i samma fil.

**Kan jag begränsa redigering på specifika bilder utan att påverka andra?**

Ja. Tillämpar lås endast på former på de valda bilderna. Detta ändrar inte låsinställningarna på andra bilder.

**Hur kan jag tillämpa lås på enskilda former i en grupp?**

Iterera genom gruppens [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/)‑samling och tillämpa lämpliga lås på varje underliggande form. Upprepa detta för eventuella nästlade grupper. Exemplen ovan bearbetar endast bildens formsamling, så de sätter inte lås på enskilda gruppmedlemmar.