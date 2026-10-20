---
title: Begränsa redigering av presentationer med formlås i Node.js
linktitle: Begränsa redigering av presentation
type: docs
weight: 60
url: /sv/nodejs-java/applying-protection-to-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du låser och låser upp former i PPTX-presentationer med Aspose.Slides för Node.js via Java för att begränsa urval, förflyttning, storleksändring och gruppering."
---
## **Översikt**

En vanlig användning av Aspose.Slides for Node.js via Java är att skapa, uppdatera och spara PowerPoint (PPTX)-presentationer som en del av ett automatiserat arbetsflöde. När användare får dessa presentationer kan begränsning av ändringar i former hjälpa till att bevara den avsedda layouten och innehållet.

Denna artikel förklarar hur former organiseras på bilder och hur man tillämpar och tar bort lås på former i en PPTX-presentation. Dessa lås låter dig begränsa specifika redigeringsåtgärder på enskilda former.

## **Komposition av en bild**

En presentationsbild består av komponenter som autoshapes, tabeller, OLE-objekt, grupperade former, bildramar, videoramar, anslutare och andra element som används för att bygga en presentation. I Aspose.Slides for Node.js via Java representeras varje element på en bild av ett objekt som ärver från klassen [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) .

Olika formtyper erbjuder olika låsalternativ. Klassen [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) är basklassen för formlås. Aspose.Slides for Node.js via Java tillhandahåller följande låsklasser:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) låser autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) låser connector shapes.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) låser graphical objects.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) låser group shapes.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) låser picture frames.  

För att tillämpa lås över en [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), iterera genom dess bilder och ange lämpliga lås på varje stödjande form.

## **Applicera och ta bort skydd**

Formlås begränsar operationer såsom att välja, flytta och ändra storlek på former. De gör inte hela presentationen oredigerbar.

### **Applicera skydd på PPTX-former**

Aspose.Slides for Node.js via Java tillhandahåller klassen [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) för att arbeta med former på en bild.

Exemplet anropar [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) och [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) med `true` för autoshapes, med motsvarande lås för gruppformer, anslutare och bildramar. Anslutare använder [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) för förflyttning; grupper använder också [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) för att begränsa gruppering.

Exemplet laddar en befintlig PPTX-presentation, kontrollerar formerna i varje bilds formsamling och sparar en kopia med dessa begränsningar tillämpade. Former utanför de fyra hanterade typerna lämnas oförändrade. Loopen traverserar inte barnformerna inuti en grupp.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ta bort skydd**

För att ta bort ett formlås sätts dess värde till `false`. Följande exempel laddar en presentation med formlås och rensar begränsningarna för urval, förflyttning och storleksändring via [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) och [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Det tar också bort grupperingsobegränsningen genom att skicka `false` till [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) och sparar en kopia av presentationen. Övriga låsinställningar lämnas oförändrade.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("ProtectedSample.pptx");
try {
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                const autoShapeLock = shape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IGroupShape")) {
                const groupShapeLock = shape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IConnector")) {
                const connectorShapeLock = shape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                const pictureFrameLock = shape.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Slutsats**

Aspose.Slides for Node.js via Java låter dig begränsa specifika redigeringsåtgärder på enskilda former eller tillämpa samma begränsningar över bilder. Välj de lås som stöds av varje formtyp och sätt deras värden till `false` när du behöver ta bort dessa begränsningar.

## **Vanliga frågor**

**Kan jag kombinera formlås och lösenordsskydd i samma presentation?**

Ja. Formlås begränsar specifika redigeringsåtgärder, medan [lösenordsskydd](/slides/sv/nodejs-java/password-protected-presentation/) kan begränsa öppning eller ändring av presentationen. Du kan använda båda i samma fil.

**Kan jag begränsa redigering på specifika bilder utan att påverka andra?**

Ja. Tilldela lås endast till former på de valda bilderna. Detta ändrar inte låsinställningarna på andra bilder.

**Hur kan jag tillämpa lås på enskilda former i en grupp?**

Iterera genom samlingen som returneras av gruppens [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes)-metod och tillämpa lämpliga lås på varje barnform. Upprepa detta för eventuella nästlade grupper. Exemplen ovan bearbetar endast bildens formsamling, så de sätter inte lås på enskilda gruppmedlemmar.