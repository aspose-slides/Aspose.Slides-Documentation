---
title: Förhindra redigering av presentationer med formlås
linktitle: Förhindra redigering av presentationer
type: docs
weight: 60
url: /sv/java/applying-protection-to-presentation/
keywords:
- förhindra redigering
- skydda mot redigering
- låsa form
- låsa position
- låsa urval
- låsa storlek
- låsa gruppering
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Upptäck hur Aspose.Slides for Java låser eller låser upp former i PPT-, PPTX- och ODP-filer, säkrar presentationer samtidigt som kontrollerade redigeringar möjliggörs och leveransen blir snabbare."
---
## **Bakgrund**

En vanlig användning av Aspose.Slides är att skapa, uppdatera och spara Microsoft PowerPoint (PPTX)-presentationer som en del av ett automatiserat arbetsflöde. Användare av applikationer som använder Aspose.Slides på detta sätt har tillgång till de genererade presentationerna, så att skydda dem mot redigering är en vanlig oro. Det är viktigt att automatiskt genererade presentationer behåller sin ursprungliga formatering och sitt innehåll.

Den här artikeln förklarar hur presentationer och bilder är strukturerade och hur Aspose.Slides for Java kan tillämpa skydd på en presentation och senare ta bort det. Den ger utvecklare ett sätt att kontrollera hur de presentationer deras applikationer genererar används.

## **Komposition av en bild**

En presentationsbild består av komponenter såsom autoshapes, tabeller, OLE‑objekt, grupperade former, bildrutor, videorutor, anslutningar och andra element som används för att bygga en presentation. I Aspose.Slides for Java representeras varje element på en bild av ett objekt som implementerar gränssnittet [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/) eller ärver från en klass som gör det.

Strukturen för PPTX är komplex, så till skillnad från PPT, där ett generiskt lås kan användas för alla typer av former, kräver olika formtyper olika lås. Gränssnittet [IBaseShapeLock](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ibaseshapelock/) är den generiska låsklassen för PPTX. Följande typer av lås stöds i Aspose.Slides for Java för PPTX:

- [IAutoShapeLock](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iautoshapelock/) låser autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iconnectorlock/) låser anslutningsformer.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/sv/java/com.aspose.slides/igraphicalobjectlock/) låser grafiska objekt.  
- [IGroupShapeLock](https://reference.aspose.com/slides/sv/java/com.aspose.slides/igroupshapelock/) låser gruppformer.  
- [IPictureFrameLock](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipictureframelock/) låser bildrutor.  

Alla åtgärder som utförs på alla formobjekt i ett [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/)‑objekt tillämpas på hela presentationen.

## **Tillämpa och ta bort skydd**

Att tillämpa skydd säkerställer att en presentation inte kan redigeras. Det är en användbar teknik för att skydda presentationens innehåll.

### **Tillämpa skydd på PPTX‑former**

Aspose.Slides for Java tillhandahåller gränssnittet [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/) för att arbeta med former på en bild.

Som nämnts tidigare har varje formklass en tillhörande form‑lås‑klass för skydd. Denna artikel fokuserar på låsen NoSelect, NoMove och NoResize. Dessa lås säkerställer att former inte kan väljas (genom mus‑klick eller andra urvalsmetoder) och att de inte kan flyttas eller ändra storlek.

Kodexemplet nedan tillämpar skydd på alla formtyper i en presentation.

```java
// Skapa en instans av Presentation-klassen som representerar en PPTX-fil.
Presentation presentation = new Presentation("Sample.pptx");

// Gå igenom alla bilder i presentationen.
for (ISlide slide : presentation.getSlides()) {

    // Gå igenom alla former i bilden.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Typkonvertera formen till en autoshape och hämta dess form-lås.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(true);
            autoShapeLock.setSelectLocked(true);
            autoShapeLock.setSizeLocked(true);
        } else if (shape instanceof IGroupShape) {
            // Typkonvertera formen till en gruppform och hämta dess form-lås.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(true);
            groupShapeLock.setPositionLocked(true);
            groupShapeLock.setSelectLocked(true);
            groupShapeLock.setSizeLocked(true);
        } else if (shape instanceof IConnector) {
            // Typkonvertera formen till en anslutningsform och hämta dess form-lås.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(true);
            connectorShapeLock.setSelectLocked(true);
            connectorShapeLock.setSizeLocked(true);
        } else if (shape instanceof IPictureFrame) {
            // Typkonvertera formen till en bildram och hämta dess form-lås.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(true);
            pictureFrameLock.setSelectLocked(true);
            pictureFrameLock.setSizeLocked(true);
        }
    }
}

// Spara presentationsfilen.
presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Ta bort skydd**

För att låsa upp en form, sätt det tillämpade låsets värde till `false`. Följande kodexempel visar hur man låser upp former i en låst presentation.

```java
// Instansiera Presentation-klassen som representerar en PPTX-fil.
Presentation presentation = new Presentation("ProtectedSample.pptx");

// Traversera alla bilder i presentationen.
for (ISlide slide : presentation.getSlides()) {

    // Traversera alla former i bilden.
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IAutoShape) {
            // Typkonvertera formen till en autoshape och hämta dess form‑lås.
            IAutoShape autoShape = (IAutoShape) shape;
            IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();

            autoShapeLock.setPositionLocked(false);
            autoShapeLock.setSelectLocked(false);
            autoShapeLock.setSizeLocked(false);
        } else if (shape instanceof IGroupShape) {
            // Typkonvertera formen till en gruppform och hämta dess form‑lås.
            IGroupShape groupShape = (IGroupShape) shape;
            IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();

            groupShapeLock.setGroupingLocked(false);
            groupShapeLock.setPositionLocked(false);
            groupShapeLock.setSelectLocked(false);
            groupShapeLock.setSizeLocked(false);
        } else if (shape instanceof IConnector) {
            // Typkonvertera formen till en anslutningsform och hämta dess form‑lås.
            IConnector connectorShape = (IConnector) shape;
            IConnectorLock connectorShapeLock = connectorShape.getShapeLock();

            connectorShapeLock.setPositionMove(false);
            connectorShapeLock.setSelectLocked(false);
            connectorShapeLock.setSizeLocked(false);
        } else if (shape instanceof IPictureFrame) {
            // Typkonvertera formen till en bildram och hämta dess form‑lås.
            IPictureFrame pictureFrame = (IPictureFrame) shape;
            IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();

            pictureFrameLock.setPositionLocked(false);
            pictureFrameLock.setSelectLocked(false);
            pictureFrameLock.setSizeLocked(false);
        }
    }
}

// Spara presentationsfilen.
presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Slutsats**

Aspose.Slides erbjuder flera alternativ för att skydda former i en presentation. Du kan låsa en enskild form eller iterera genom alla former i en presentation och låsa varje för att effektivt skydda hela filen. Du kan ta bort skyddet genom att sätta låsvärdet till `false`.

## **FAQ**

**Kan jag kombinera form‑lås och lösenordsskydd i samma presentation?**

Ja. Lås begränsar redigering av objekt i filen, medan [lösenordsskydd](/slides/sv/java/password-protected-presentation/) styr åtkomst till att öppna och/eller spara ändringar. Dessa mekanismer kompletterar varandra och fungerar tillsammans.

**Kan jag begränsa redigering på specifika bilder utan att påverka andra?**

Ja. Tillämpa lås på formerna på de valda bilderna; de återstående bilderna förblir redigerbara.

**Gäller form‑lås för grupperade objekt och anslutningar?**

Ja. Specifika låstyper stöds för grupper, anslutningar, grafiska objekt och andra formtyper.