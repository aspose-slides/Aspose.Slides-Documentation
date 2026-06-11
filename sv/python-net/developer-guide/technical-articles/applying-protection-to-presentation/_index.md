---
title: Förhindra redigering av presentationer med formlås i Python
linktitle: Förhindra redigering av presentation
type: docs
weight: 70
url: /sv/python-net/applying-protection-to-presentation/
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
- Aspose.Slides
description: "Upptäck hur Aspose.Slides for Python via .NET låser eller låser upp former i PPT-, PPTX- och ODP-filer, säkrar presentationer samtidigt som kontrollerade redigeringar och snabbare leverans möjliggörs."
---
## **Bakgrund**

Ett vanligt bruk för Aspose.Slides är att skapa, uppdatera och spara Microsoft PowerPoint (PPTX)-presentationer som en del av ett automatiserat arbetsflöde. Användare av applikationer som använder Aspose.Slides på detta sätt har tillgång till de genererade presentationerna, så att skydda dem från redigering är en vanlig oro. Det är viktigt att automatiskt genererade presentationer behåller sin ursprungliga formatering och sitt innehåll.

Denna artikel förklarar hur presentationer och bilder är strukturerade samt hur Aspose.Slides for Python kan applicera skydd på en presentation och senare ta bort det. Den ger utvecklare ett sätt att kontrollera hur de presentationer som deras applikationer genererar används.

## **Komposition av en bild**

En presentationsbild består av komponenter såsom autoshapes, tabeller, OLE-objekt, grupperade former, bildramar, videoram, anslutningar och andra element som används för att skapa en presentation. I Aspose.Slides for Python representeras varje element på en bild av ett objekt som ärver klassen [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/) .

Strukturen för PPTX är komplex, så till skillnad från PPT, där ett generiskt lås kan användas för alla typer av former, kräver olika former olika lås. Klassen [BaseShapeLock](https://reference.aspose.com/slides/sv/python-net/aspose.slides/baseshapelock/) är den generiska låsklassen för PPTX. Följande typer av lås stöds i Aspose.Slides for Python för PPTX:

- [AutoShapeLock](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshapelock/) låser autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/sv/python-net/aspose.slides/connectorlock/) låser connector‑former.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/sv/python-net/aspose.slides/graphicalobjectlock/) låser grafiska objekt.  
- [GroupShapeLock](https://reference.aspose.com/slides/sv/python-net/aspose.slides/groupshapelock/) låser gruppformer.  
- [PictureFrameLock](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframelock/) låser bildramar.  

Alla åtgärder som utförs på alla formobjekt i ett [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/)‑objekt tillämpas på hela presentationen.

## **Tillämpa och ta bort skydd**

Att tillämpa skydd säkerställer att en presentation inte kan redigeras. Det är en användbar teknik för att skydda presentationens innehåll.

### **Tillämpa skydd på PPTX‑former**

Aspose.Slides for Python tillhandahåller klassen [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/) för att arbeta med former på en bild.

Som tidigare nämnts har varje formklass en tillhörande shape‑lock‑klass för skydd. Denna artikel fokuserar på låsen NoSelect, NoMove och NoResize. Dessa lås säkerställer att former inte kan väljas (genom musklick eller andra urvalsmetoder) och att de inte kan flyttas eller storleksändras.

Kodexemplet som följer tillämpar skydd på alla formtyper i en presentation.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar en PPTX-fil.
with slides.Presentation("Sample.pptx") as presentation:
    # Traversera alla bilder i presentationen.
    for slide in presentation.slides:
        # Traversera alla former i bilden.
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
    # Spara presentationsfilen.
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Ta bort skydd**

För att låsa upp en form, sätt det tillämpade låsets värde till `False`. Följande kodexempel visar hur man låser upp former i en låst presentation.

```py
import aspose.slides as slides

# Instansiera Presentation-klassen som representerar en PPTX-fil.
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # Traversera alla bilder i presentationen.
    for slide in presentation.slides:
        # Traversera alla former i bilden.
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
    # Sparar presentationsfilen.
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Slutsats**

Aspose.Slides erbjuder flera alternativ för att skydda former i en presentation. Du kan låsa en enskild form eller iterera genom alla former i en presentation och låsa varje form för att effektivt säkra hela filen. Du kan ta bort skyddet genom att sätta låsvärdet till `False`.

## **FAQ**

**Kan jag kombinera formlås och lösenordsskydd i samma presentation?**

Ja. Lås begränsar redigering av objekt i filen, medan [password protection](/slides/sv/python-net/password-protected-presentation/) styr åtkomst till att öppna och/eller spara ändringar. Dessa mekanismer kompletterar varandra och fungerar tillsammans.

**Kan jag begränsa redigering på specifika bilder utan att påverka andra?**

Ja. Tillåt lås på formerna på de valda bilderna; de återstående bilderna förblir redigerbara.

**Gäller formlås för grupperade objekt och anslutningar?**

Ja. Specifika låstyper stöds för grupper, anslutningar, grafiska objekt och andra formtyper.