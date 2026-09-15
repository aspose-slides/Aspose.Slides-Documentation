---
title: Förhindra redigering av presentationer med form-lås
linktitle: Förhindra redigering av presentationer
type: docs
weight: 60
url: /sv/python-java/applying-protection-to-presentation/
keywords:
- förhindra redigering
- skydda mot redigering
- låsa form
- låsa position
- låsa val
- låsa storlek
- låsa gruppering
- PowerPoint
- OpenDocument
- presentation
- Python
- Java
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för Python via Java låser eller låser upp former i PPT-, PPTX- och ODP-filer, säkrar presentationer samtidigt som kontrollerade redigeringar och snabbare leverans möjliggörs."
---
## **Bakgrund**

En vanlig användning av Aspose.Slides är att skapa, uppdatera och spara Microsoft PowerPoint (PPTX)-presentationer som en del av ett automatiserat arbetsflöde. Användare av applikationer som använder Aspose.Slides på detta sätt har åtkomst till de genererade presentationerna, så att skydda dem från redigering är en vanlig oro. Det är viktigt att automatiskt genererade presentationer behåller sin ursprungliga formatering och innehåll.

Den här artikeln förklarar hur presentationer och bilder är strukturerade och hur Aspose.Slides för Python via Java kan tillämpa skydd på en presentation och senare ta bort det. Den ger utvecklare ett sätt att kontrollera hur de presentationer som deras applikationer genererar används.

## **Komposition av en bild**

En presentationsbild består av komponenter som autoshapes, tabeller, OLE-objekt, grupperade former, bildramar, videoramar, anslutningar och andra element som används för att bygga en presentation. I Aspose.Slides för Python via Java representeras varje element på en bild av ett objekt som ärver från klassen [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/) .

Strukturen för PPTX är komplex, så till skillnad från PPT, där ett generiskt lås kan användas för alla typer av former, kräver olika formlertyper olika lås. Klassen [BaseShapeLock](https://reference.aspose.com/slides/sv/python-java/aspose.slides/baseshapelock/) är den generiska låsklassen för PPTX. Följande typer av lås stöds i Aspose.Slides för Python via Java för PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/sv/python-java/aspose.slides/autoshapelock/) låser autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/sv/python-java/aspose.slides/connectorlock/) låser anslutningsformer.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/sv/python-java/aspose.slides/graphicalobjectlock/) låser grafiska objekt.  
- [GroupShapeLock](https://reference.aspose.com/slides/sv/python-java/aspose.slides/groupshapelock/) låser grupperade former.  
- [PictureFrameLock](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pictureframelock/) låser bildramar.  

Alla åtgärder som utförs på alla formobjekt i ett [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑objekt tillämpas på hela presentationen.

## **Tillämpa och ta bort skydd**

Att tillämpa skydd säkerställer att en presentation inte kan redigeras. Det är en användbar teknik för att skydda presentationens innehåll.

### **Tillämpa skydd på PPTX-former**

Aspose.Slides för Python via Java tillhandahåller klassen [Shape](https://reference.aspose.com/slides/sv/python-java/aspose.slides/shape/) för att arbeta med former på en bild.

Som tidigare nämnts har varje formklass en tillhörande form‑låsklass för skydd. Denna artikel fokuserar på låsen NoSelect, NoMove och NoResize. Dessa lås säkerställer att former inte kan väljas (genom musklick eller andra urvalsmetoder) och att de inte kan flyttas eller ändras i storlek.

Kodexemplet nedan tillämpar skydd på alla formtyper i en presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Instansiera Presentation-klassen som representerar en PPTX-fil.
presentation = Presentation("Sample.pptx")
try:
    # Gå igenom alla bilder i presentationen.
    for slide in presentation.getSlides():
        # Gå igenom alla former i bilden.
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

    # Spara presentationsfilen.
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Ta bort skydd**

För att låsa upp en form, sätt det tillämpade låsets värde till `False`. Följande kodexempel visar hur man låser upp former i en låst presentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Instansiera Presentation-klassen som representerar en PPTX-fil.
presentation = Presentation("ProtectedSample.pptx")
try:
    # Gå igenom alla bilder i presentationen.
    for slide in presentation.getSlides():
        # Gå igenom alla former i bilden.
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

    # Spara presentationsfilen.
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Slutsats**

Aspose.Slides erbjuder flera alternativ för att skydda former i en presentation. Du kan låsa en enskild form eller iterera genom alla former i en presentation och låsa varje form för att effektivt säkra hela filen. Du kan ta bort skyddet genom att sätta låsvärdet till `False`.

## **FAQ**

**Kan jag kombinera formlås och lösenordsskydd i samma presentation?**

Ja. Lås begränsar redigering av objekt i filen, medan [lösenordsskydd](/slides/sv/python-java/password-protected-presentation/) kontrollerar åtkomst för att öppna och/eller spara ändringar. Dessa mekanismer kompletterar varandra och fungerar tillsammans.

**Kan jag begränsa redigering på specifika bilder utan att påverka andra?**

Ja. Tillämpa lås på formerna på de valda bilderna; de återstående bilderna förblir redigerbara.

**Gäller formlås för grupperade objekt och anslutningar?**

Ja. Dedikerade låstyper stöds för grupper, anslutningar, grafiska objekt och andra formtyper.