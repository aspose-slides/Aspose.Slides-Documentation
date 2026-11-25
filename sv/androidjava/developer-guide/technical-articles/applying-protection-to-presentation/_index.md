---
title: "Begränsa redigering av presentationer med formlås på Android"
linktitle: "Begränsa redigering av presentationer"
type: docs
weight: 60
url: /sv/androidjava/applying-protection-to-presentation/
keywords:
- förhindra redigering
- skydda mot redigering
- låsa form
- låsa position
- låsa markering
- låsa storleksändring
- låsa gruppering
- PowerPoint
- PPTX
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig hur du låser och låser upp former i PPTX-presentationer med Aspose.Slides för Android via Java för att begränsa markering, rörelse, storleksändring och gruppering."
---
## **Översikt**

En vanlig användning av Aspose.Slides for Android via Java är att skapa, uppdatera och spara PowerPoint (PPTX)-presentationer som en del av ett automatiserat arbetsflöde. När användare tar emot dessa presentationer kan begränsning av ändringar av former hjälpa till att bevara den avsedda layouten och innehållet.

Den här artikeln förklarar hur former organiseras på bilder och hur man tillämpar och tar bort lås på former i en PPTX-presentation. Dessa lås gör att du kan begränsa specifika redigeringsåtgärder för enskilda former.

## **Komposition av en bild**

En presentationsbild består av komponenter såsom autoshapes, tabeller, OLE-objekt, grupperade former, bildramar, videoramar, anslutningar och andra element som används för att bygga en presentation. I Aspose.Slides for Android via Java representeras varje element på en bild av ett objekt som implementerar gränssnittet [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) eller ärver från en klass som gör det.

Olika formtyper exponerar olika låsalternativ. Gränssnittet [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) är basgränssnittet för formlås. Aspose.Slides for Android via Java tillhandahåller följande låsgränssnitt:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) låser autoshapes.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) låser anslutningsformer.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) låser grafiska objekt.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) låser grupperade former.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) låser bildramar.  

För att tillämpa lås i en [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/), iterera genom dess bilder och ange lämpliga lås på varje stödjande form.

## **Applicera och ta bort skydd**

Kompatibla presentationsredigerare använder formlås för att begränsa enskilda redigeringsåtgärder. Filkryptering och dokumentnivå‑skrivskydd är separata [presentation protection settings](/slides/sv/androidjava/password-protected-presentation/).

### **Applicera skydd på PPTX-former**

Aspose.Slides for Android via Java tillhandahåller gränssnittet [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) för att arbeta med former på en bild.

Exemplet anropar [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-) , [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) och [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) med `true` för autoshapes, med motsvarande lås för grupperade former, anslutningar och bildramar. Anslutningar använder [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) för rörelse; grupper använder också [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) för att begränsa gruppering.

Exemplet laddar en befintlig PPTX-presentation, kontrollerar formerna i varje bilds formsamling och sparar en kopia med dessa begränsningar tillämpade. Former utanför de fyra hanterade typerna lämnas oförändrade. Loopen traverserar inte underordnade former i en grupp.

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

För att ta bort ett formlås, sätt dess värde till `false`. Följande exempel laddar en presentation med formlås och rensar selektions‑, rörelse‑ och storleksbegränsningarna via [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) och [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/). Det tar också bort grupperingens begränsning genom att skicka `false` till [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) och sparar en kopia av presentationen. Andra låsinställningar lämnas oförändrade.

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

### **Bevara bildbeskärning**

Placera en bild med namnet `photo.jpg` i arbetskatalogen. Exemplet beskär 12 % från vänster och 8 % från höger, och anropar sedan [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) på bildramens lås. Att skicka `true` begränsar vidare beskärning och bevarar den befintliga beskärningen.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage photo;
    try (FileInputStream input = new FileInputStream("photo.jpg")) {
        photo = presentation.getImages().addImage(input);
    }

    IPictureFrame pictureFrame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    IPictureFrameLock pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` lagrar beskärningslåset som `true`. I PowerPoint är **Crop**‑kommandot inaktiverat när bilden är markerad.

### **Behåll ett diagram grupperat**

Exemplet grupperar en rektangel och en pil, och anropar sedan [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) på gruppens lås för att hålla diagrammets komponenter tillsammans. Andra redigeringar, såsom att flytta gruppen eller ändra en komponents fyllning, förblir möjliga.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IGroupShape groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` lagrar avgrupperingslåset som `true`. I PowerPoint är **Ungroup**‑kommandot inaktiverat när hela diagrammet är markerat.

### **Rapportera befintliga formlås**

För att granska en mall, öppna den och läs låsobjektet för varje form. Metoden [getNoLocks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/#getNoLocks--) returnerar `true` när alla flaggor på det objektet är inaktiverade och `false` när minst en är aktiverad. En grupp och dess underordnade har separata låsobjekt, så inspektera underordnade även när gruppen saknar lås.

Detta exempel kontrollerar rörelse för autoshapes, bildramar och grupper. Det kontrollerar också beskärning för bilder och avgruppering för grupper. Rapporten listar de flaggor den känner igen och markerar formtyper den inte inspekterar.

```java
import com.aspose.slides.*;
import android.text.TextUtils;
import java.util.ArrayList;
import java.util.List;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            List<String> flags = new ArrayList<>();
            IBaseShapeLock shapeLock;

            if (shape instanceof IGroupShape) {
                IGroupShapeLock groupLock = ((IGroupShape) shape).getGroupShapeLock();
                shapeLock = groupLock;
                if (groupLock.getUngroupingLocked()) flags.add("UngroupingLocked");
                if (groupLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IPictureFrame) {
                IPictureFrameLock pictureLock = ((IPictureFrame) shape).getPictureFrameLock();
                shapeLock = pictureLock;
                if (pictureLock.getCropLocked()) flags.add("CropLocked");
                if (pictureLock.getPositionLocked()) flags.add("PositionLocked");
            } else if (shape instanceof IAutoShape) {
                IAutoShapeLock autoShapeLock = ((IAutoShape) shape).getAutoShapeLock();
                shapeLock = autoShapeLock;
                if (autoShapeLock.getPositionLocked()) flags.add("PositionLocked");
            } else {
                System.out.println(label + " | Uninspected");
                continue;
            }

            if (!shapeLock.getNoLocks()) {
                String restrictions = !flags.isEmpty() ? TextUtils.join(", ", flags) : "Active flag not identified";
                System.out.println(label + " | " + restrictions);
            }

            if (shape instanceof IGroupShape) {
                inspect(((IGroupShape) shape).getShapes(), slideNumber, path + "/");
            }
        }
    }
}

ShapeLockReport report = new ShapeLockReport();
Presentation presentation = new Presentation("Sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        report.inspect(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

Anta att bild 1 i `Sample.pptx` innehåller en grupp med namn `Layout` där avgruppering är låst, en bild med namn `Photo` i gruppen där beskärning är låst, och en olåst rektangel med namn `Free`. Rapporten hoppar över `Free` och skriver ut dessa två rader:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Rapporten läser de lagrade form‑nivå‑redigeringsflaggan utan att ändra dem eller spara presentationen. Dokumentnivå‑skrivskydd är en separat inställning, och verkställandet av varje flagga beror på redigeraren.

### **Slutsats**

Aspose.Slides for Android via Java låter dig begränsa specifika redigeringsåtgärder för enskilda former eller tillämpa samma begränsningar över flera bilder. Välj de lås som stöds av varje formtyp och sätt deras värden till `false` när du behöver ta bort dessa begränsningar.

## **FAQ**

**Kan jag kombinera formlås och lösenordsskydd i samma presentation?**

Ja. Formlås begränsar specifika redigeringsåtgärder, medan [password protection](/slides/sv/androidjava/password-protected-presentation/) kan begränsa öppning eller ändring av presentationen. Du kan använda båda i samma fil.

**Kan jag begränsa redigering på specifika bilder utan att påverka andra?**

Ja. Tillämpa lås endast på former på de valda bilderna. Detta ändrar inte låsinställningarna på andra bilder.

**Hur kan jag tillämpa lås på enskilda former i en grupp?**

Iterera genom samlingen som returneras av gruppens [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--)‑metod och tillämpa lämpliga lås på varje underform. Upprepa detta för eventuella nästlade grupper, enligt traverseringen i rapportexemplet.