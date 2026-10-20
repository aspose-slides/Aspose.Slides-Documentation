---
title: Begränsa redigering av presentationer med formlås på Android
linktitle: Begränsa redigering av presentationer
type: docs
weight: 60
url: /sv/androidjava/applying-protection-to-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du låser och låser upp former i PPTX‑presentationer med Aspose.Slides för Android via Java för att begränsa val, förflyttning, storleksändring och gruppering."
---
## **Översikt**

En vanlig användning av Aspose.Slides för Android via Java är att skapa, uppdatera och spara PowerPoint‑presentationer (PPTX) som en del av ett automatiserat arbetsflöde. När användare får dessa presentationer kan begränsning av ändringar av former hjälpa till att bevara den avsedda layouten och innehållet.

Den här artikeln förklarar hur former är organiserade på bilder och hur man tillämpar och tar bort lås för former i en PPTX‑presentation. Dessa lås låter dig begränsa specifika redigeringsåtgärder på enskilda former.

## **Komposition av en bild**

En presentationsbild består av komponenter såsom autoshapes, tabeller, OLE‑objekt, grupperade former, bildramar, videoram, anslutningar och andra element som används för att bygga en presentation. I Aspose.Slides för Android via Java representeras varje element på en bild av ett objekt som implementerar gränssnittet [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) eller ärver från en klass som gör det.

Olika typ av former visar olika låsalternativ. Gränssnittet [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) är grundgränssnittet för lås på former. Aspose.Slides för Android via Java tillhandahåller följande låsgränssnitt:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) låser autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) låser anslutningsformer.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) låser grafiska objekt.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) låser gruppformer.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) låser bildramar.  

För att tillämpa lås på en [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), iterera genom dess bilder och sätt de lämpliga låsen på varje stödjande form.

## **Tillämpa och ta bort skydd**

Formlås begränsar operationer såsom att välja, flytta och ändra storlek på former. De gör inte hela presentationen oredigerbar.

### **Tillämpa skydd på PPTX‑former**

Aspose.Slides för Android via Java tillhandahåller gränssnittet [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) för att arbeta med former på en bild.

Exemplet anropar [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), och [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) med `true` för autoshapes, med motsvarande lås för gruppformer, anslutningar och bildramar. Anslutningar använder [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) för förflyttning; grupper använder även [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) för att begränsa gruppering.

Exemplet laddar en befintlig PPTX‑presentation, kontrollerar formerna i varje bilds formsamling och sparar en kopia med dessa begränsningar tillämpade. Former utanför de fyra hanterade typerna lämnas oförändrade. Loopen traverserar inte barnformerna inuti en grupp.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(true);
                autoShapeLock.setSelectLocked(true);
                autoShapeLock.setSizeLocked(true);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(true);
                groupShapeLock.setPositionLocked(true);
                groupShapeLock.setSelectLocked(true);
                groupShapeLock.setSizeLocked(true);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(true);
                connectorShapeLock.setSelectLocked(true);
                connectorShapeLock.setSizeLocked(true);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(true);
                pictureFrameLock.setSelectLocked(true);
                pictureFrameLock.setSizeLocked(true);
            }
        }
    }

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Ta bort skydd**

För att ta bort ett formlås, sätt dess värde till `false`. Följande exempel laddar en presentation med formlås och rensar urvalet, förflyttning och storleksändring via [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/), och [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). Det tar också bort grupperingstillståndet genom att skicka `false` till [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-), och sparar en kopia av presentationen. Övriga låsinställningar lämnas oförändrade.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ProtectedSample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                IAutoShapeLock autoShapeLock = (IAutoShapeLock) autoShape.getShapeLock();
                autoShapeLock.setPositionLocked(false);
                autoShapeLock.setSelectLocked(false);
                autoShapeLock.setSizeLocked(false);
            } else if (shape instanceof IGroupShape) {
                IGroupShape groupShape = (IGroupShape) shape;
                IGroupShapeLock groupShapeLock = (IGroupShapeLock) groupShape.getShapeLock();
                groupShapeLock.setGroupingLocked(false);
                groupShapeLock.setPositionLocked(false);
                groupShapeLock.setSelectLocked(false);
                groupShapeLock.setSizeLocked(false);
            } else if (shape instanceof IConnector) {
                IConnector connectorShape = (IConnector) shape;
                IConnectorLock connectorShapeLock = connectorShape.getShapeLock();
                connectorShapeLock.setPositionMove(false);
                connectorShapeLock.setSelectLocked(false);
                connectorShapeLock.setSizeLocked(false);
            } else if (shape instanceof IPictureFrame) {
                IPictureFrame pictureFrame = (IPictureFrame) shape;
                IPictureFrameLock pictureFrameLock = (IPictureFrameLock) pictureFrame.getShapeLock();
                pictureFrameLock.setPositionLocked(false);
                pictureFrameLock.setSelectLocked(false);
                pictureFrameLock.setSizeLocked(false);
            }
        }
    }

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Slutsats**

Aspose.Slides för Android via Java låter dig begränsa specifika redigeringsåtgärder på enskilda former eller tillämpa samma begränsningar över flera bilder. Välj de lås som stöds av varje formtyp och sätt deras värden till `false` när du behöver ta bort dessa begränsningar.

## **FAQ**

**Kan jag kombinera formlås och lösenordsskydd i samma presentation?**

Ja. Formlås begränsar specifika redigeringsåtgärder, medan [lösenordsskydd](/slides/sv/androidjava/password-protected-presentation/) kan begränsa öppning eller modifiering av presentationen. Du kan använda båda i samma fil.

**Kan jag begränsa redigering på specifika bilder utan att påverka andra?**

Ja. Tillämpa lås endast på former på de valda bilderna. Detta ändrar inte låsinställningarna på andra bilder.

**Hur kan jag tillämpa lås på enskilda former i en grupp?**

Iterera genom samlingen som returneras av gruppens [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--)‑metod och tillämpa lämpliga lås på varje barnform. Upprepa detta för eventuella nästlade grupper. Exemplen ovan bearbetar endast bildens formsamling, så de sätter inte lås på enskilda gruppmedlemmar.