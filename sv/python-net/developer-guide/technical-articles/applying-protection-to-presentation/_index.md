---
title: Begränsa redigering av presentationer med formlås i Python
linktitle: Begränsa redigering av presentation
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

En vanlig användning av Aspose.Slides för Python via .NET är att skapa, uppdatera och spara PowerPoint (PPTX)-presentationer som en del av ett automatiserat arbetsflöde. När användare får dessa presentationer kan begränsning av ändringar av former hjälpa till att bevara den avsedda layouten och innehållet.

Denna artikel förklarar hur former är organiserade på bilder och hur man tillämpar och tar bort lås för former i en PPTX-presentation. Dessa lås låter dig begränsa specifika redigeringsåtgärder på enskilda former.

## **Komposition av en bild**

En presentationsbild består av komponenter såsom autoshapes, tabeller, OLE-objekt, grupperade former, bildramar, videoramar, anslutningar och andra element som används för att bygga en presentation. I Aspose.Slides för Python via .NET representeras varje element på en bild av ett objekt som ärver från klassen [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) .

Olika formtyper erbjuder olika låsalternativ. Klassen [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) är basklassen för lås på former. Aspose.Slides för Python via .NET tillhandahåller följande låsklasser:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) låser autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) låser anslutningsformer.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) låser grafiska objekt.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) låser grupperade former.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) låser bildramar.  

För att tillämpa lås över en [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), iteration genom dess bilder och sätt de lämpliga låsen på varje stödd form.

## **Tillämpa och ta bort skydd**

Kompatibla presentationsredigerare använder lås för former för att begränsa individuella redigeringsåtgärder. Filkryptering och skrivskydd på dokumentnivå är separata [presentation skyddinställningar](/slides/sv/python-net/password-protected-presentation/).

### **Tillämpa skydd på PPTX-former**

Aspose.Slides för Python via .NET tillhandahåller klassen [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) för att arbeta med former på en bild.

Exemplet sätter [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/), och [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) till `True` för autoshapes, med motsvarande lås för grupperade former, anslutningar och bildramar. Anslutningar använder [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) för rörelse; grupper använder också [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) för att begränsa gruppering.

Exemplet läser in en befintlig PPTX-presentation, kontrollerar formerna i varje bilds formsamling och sparar en kopia med dessa restriktioner tillämpade. Former utanför de fyra hanterade typerna lämnas oförändrade. Loopen traverserar inte de underordnade formerna i en grupp.

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

För att ta bort ett lås på en form, sätt dess värde till `False`. Följande exempel läser in en presentation med lås på former och rensar urval, rörelse och storleksändringsrestriktioner via [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/), och [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/). Det rensar också [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) och sparar en kopia av presentationen. Andra låsinställningar lämnas oförändrade.

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

Placera ett foto med namnet `photo.jpg` i arbetskatalogen. Exemplet beskär 12 % från vänster och 8 % från höger, och sätter sedan [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) på bildramen. Denna flagga begränsar ytterligare beskärning och bevarar den befintliga beskärningen.

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

`PictureLocked.pptx` lagrar beskärningslåset som `True`. I PowerPoint är kommandot **Crop** inaktiverat när fotot är markerat.

### **Behåll ett diagram grupperat**

Exemplet grupperar en rektangel och en pil, och sätter sedan [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) på själva gruppen för att hålla diagrammets komponenter tillsammans. Övriga redigeringar, såsom att flytta gruppen eller ändra en komponents fyllning, förblir tillgängliga.

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

`DiagramLocked.pptx` lagrar avgrupperingslåset som `True`. I PowerPoint är kommandot **Ungroup** inaktiverat när hela diagrammet är markerat.

### **Rapportera befintliga lås för former**

För att granska en mall, öppna den och läs låsobjektet för varje form. [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) är `True` när alla flaggor på det objektet är inaktiverade och `False` när minst en är aktiverad. En grupp och dess underobjekt har separata låsobjekt, så inspektera underobjekten även när gruppen saknar lås.

Detta exempel kontrollerar rörelse för autoshapes, bildramar och grupper, beskärning för bilder och avgruppering för grupper. Det rapporterar de flaggor det känner igen och markerar formtyper som det inte inspekterar.

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

Anta att bild 1 i `Sample.pptx` innehåller en grupp med namn `Layout` där avgruppering är låst, en bild med namn `Photo` inuti den med beskärning låst, och en olåst rektangel med namn `Free`. Rapporten hoppar över `Free` och skriver ut dessa två rader:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

Rapporten läser lagrade redigeringsflaggor på formnivå utan att ändra dem eller spara presentationen. Skrivskydd på dokumentnivå är en separat inställning, och verkställandet av varje flagga beror på redigeraren.

### **Slutsats**

Aspose.Slides för Python via .NET låter dig begränsa specifika redigeringsåtgärder på enskilda former eller tillämpa samma restriktioner över bilder. Välj de lås som stöds av varje formtyp och sätt deras värden till `False` när du behöver ta bort dessa restriktioner.

## **Vanliga frågor**

**Kan jag kombinera lås för former och lösenordsskydd i samma presentation?**

Ja. Lås för former begränsar specifika redigeringsåtgärder, medan [lösenordsskydd](/slides/sv/python-net/password-protected-presentation/) kan begränsa öppning eller modifiering av presentationen. Du kan använda båda i samma fil.

**Kan jag begränsa redigering på specifika bilder utan att påverka andra?**

Ja. Tilldela lås endast till former på de valda bilderna. Detta ändrar inte låsinställningarna på andra bilder.

**Hur kan jag tillämpa lås på enskilda former inom en grupp?**

Iterera genom gruppens [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) -samling och tillämpa lämpliga lås på varje underform. Upprepa detta för eventuella inbäddade grupper, enligt traverseringen i rapportexemplet.