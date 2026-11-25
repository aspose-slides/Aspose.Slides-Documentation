---
title: Begränsa redigering av presentationer med formlås i Node.js
linktitle: Begränsa redigering av presentationer
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
description: "Lär dig hur du låser och låser upp former i PPTX-presentationer med Aspose.Slides för Node.js via Java för att begränsa urval, rörelse, storleksändring och gruppering."
---
## **Översikt**

En vanlig användning för Aspose.Slides för Node.js via Java är att skapa, uppdatera och spara PowerPoint (PPTX)-presentationer som en del av ett automatiserat arbetsflöde. När användare tar emot dessa presentationer kan begränsning av förändringar av former hjälpa till att bevara den avsedda layouten och innehållet.

Denna artikel förklarar hur former organiseras på bilder och hur man applicerar och tar bort lås för former i en PPTX-presentation. Dessa lås låter dig begränsa specifika redigeringsåtgärder på enskilda former.

## **Komposition av en bild**

En presentationsbild är sammansatt av komponenter såsom autoshapes, tabeller, OLE-objekt, grupperade former, bildramar, videoramar, anslutningar och andra element som används för att bygga en presentation. I Aspose.Slides för Node.js via Java representeras varje element på en bild av ett objekt som ärver från klassen [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) .

Olika formtyper exponerar olika låsalternativ. Klassen [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) är basklassen för lås på former. Aspose.Slides för Node.js via Java tillhandahåller följande låsklasser:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) låser autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) låser anslutningsformer.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) låser grafiska objekt.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) låser gruppformer.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) låser bildramar.  

För att applicera lås över en [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), iterera genom dess bilder och sätt de lämpliga låsen på varje stödjande form.

## **Applicera och ta bort skydd**

Kompatibla presentationsredigerare använder lås för former för att begränsa individuella redigeringsåtgärder. Filkryptering och skrivrättighetsskydd på dokumentnivå är separata [inställningar för presentationsskydd](/slides/sv/nodejs-java/password-protected-presentation/).

### **Applicera skydd på PPTX-former**

Aspose.Slides för Node.js via Java tillhandahåller klassen [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) för att arbeta med former på en bild.

Exemplet anropar [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) och [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) med `true` för autoshapes, med motsvarande lås för gruppformer, anslutningar och bildramar. Anslutningar använder [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) för rörelse; grupper använder också [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) för att begränsa gruppering.

Exemplet laddar en befintlig PPTX-presentation, kontrollerar formerna i varje bilds formsamling och sparar en kopia med dessa restriktioner tillämpade. Former utanför de fyra hanterade typerna lämnas oförändrade. Loopen traverserar inte underformerna i en grupp.

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

För att ta bort ett lås för en form, sätt dess värde till `false`. Följande exempel laddar en presentation med lås för former och rensar urval, rörelse och storleksändringsrestriktioner via [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) och [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Det tar också bort grupperingens restriktion genom att skicka `false` till [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) och sparar en kopia av presentationen. Andra låsinställningar lämnas oförändrade.

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

### **Bevara bildbeskärning**

Placera ett foto med namnet `photo.jpg` i arbetskatalogen. Exemplet beskär 12 % från vänster och 8 % från höger, och anropar sedan [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked) på bildramens lås. Att skicka `true` begränsar ytterligare beskärning och bevarar den befintliga beskärningen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const photoStream = java.newInstanceSync("java.io.FileInputStream", "photo.jpg");
    let photo;
    try {
        photo = presentation.getImages().addImage(photoStream);
    } finally {
        photoStream.close();
    }

    const pictureFrame = shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 30, 270, 160, photo);
    pictureFrame.getPictureFormat().setCropLeft(12);
    pictureFrame.getPictureFormat().setCropRight(8);

    const pictureFrameLock = pictureFrame.getPictureFrameLock();
    pictureFrameLock.setAspectRatioLocked(false);
    pictureFrameLock.setCropLocked(true);

    presentation.save("PictureLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`PictureLocked.pptx` lagrar beskärningslåset som `true`. I PowerPoint är kommandot **Crop** inaktiverat när fotot är markerat.

### **Behåll ett diagram grupperat**

Exemplet grupperar en rektangel och en pil, och anropar sedan [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) på gruppens lås för att hålla diagrammets komponenter sammansatta. Andra redigeringar, såsom att flytta gruppen eller ändra en komponents fyllning, förblir tillgängliga.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    
    const groupShape = shapes.addGroupShape();
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 70, 90, 50);
    groupShape.getShapes().addAutoShape(aspose.slides.ShapeType.RightArrow, 190, 80, 60, 30);
    groupShape.getGroupShapeLock().setUngroupingLocked(true);

    presentation.save("DiagramLocked.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`DiagramLocked.pptx` lagrar avgrupperingslåset som `true`. I PowerPoint är kommandot **Ungroup** inaktiverat när hela diagrammet är markerat.

### **Rapportera befintliga lås för former**

För att granska en mall, öppna den och läs låsobjektet för varje form. Metoden [getNoLocks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/#getNoLocks) returnerar `true` när alla flaggor på objektet är inaktiverade och `false` när minst en är aktiverad. En grupp och dess underobjekt har separata låsobjekt, så inspektera underobjekten även när gruppen saknar lås.

Detta exempel kontrollerar rörelse för autoshapes, bildramar och grupper. Det kontrollerar också beskärning för bilder och avgruppering för grupper. Rapporten listar de aktiverade flaggorna den känner igen och markerar formtyper som den inte inspekterar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function inspectShapes(shapes, slideNumber, prefix) {
    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const path = prefix + shape.getName();
        const type = shape.getClass().getSimpleName();
        const label = `Slide ${slideNumber} | ${path} | ${type}`;
        const flags = [];
        const isGroup = java.instanceOf(shape, "com.aspose.slides.IGroupShape");
        let shapeLock;

        if (isGroup) {
            shapeLock = shape.getGroupShapeLock();
            if (shapeLock.getUngroupingLocked()) flags.push("UngroupingLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            shapeLock = shape.getPictureFrameLock();
            if (shapeLock.getCropLocked()) flags.push("CropLocked");
        } else if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shapeLock = shape.getAutoShapeLock();
        } else {
            console.log(`${label} | Uninspected`);
            continue;
        }

        if (!shapeLock.getNoLocks()) {
            if (shapeLock.getPositionLocked()) flags.push("PositionLocked");
            const restrictions = flags.length ? flags.join(", ") : "Active flag not identified";
            console.log(`${label} | ${restrictions}`);
        }

        if (isGroup) {
            inspectShapes(shape.getShapes(), slideNumber, path + "/");
        }
    }
}

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    const slides = presentation.getSlides();
    for (let i = 0; i < slides.size(); i++) {
        const slide = slides.get_Item(i);
        inspectShapes(slide.getShapes(), slide.getSlideNumber(), "");
    }
} finally {
    presentation.dispose();
}
```

Anta att bild 1 i `Sample.pptx` innehåller en grupp med namnet `Layout` där avgruppering är låst, en bild med namnet `Photo` inuti den med beskärning låst, och en olåst rektangel med namnet `Free`. Rapporten hoppar över `Free` och skriver ut dessa två rader:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Rapporten läser de lagrade redigeringsflaggan på formnivå utan att ändra dem eller spara presentationen. Skrivrättighetsskydd på dokumentnivå är en separat inställning, och verkställandet av varje flagga beror på redigeraren.

## **Slutsats**

Aspose.Slides för Node.js via Java låter dig begränsa specifika redigeringsåtgärder på enskilda former eller applicera samma restriktioner över bilder. Välj de lås som stöds av varje formtyp och sätt deras värden till `false` när du behöver ta bort dessa restriktioner.

## **Vanliga frågor**

**Kan jag kombinera lås för former och lösenordsskydd i samma presentation?**

Ja. Lås för former begränsar specifika redigeringsåtgärder, medan [lösenordsskydd](/slides/sv/nodejs-java/password-protected-presentation/) kan begränsa öppning eller modifiering av presentationen. Du kan använda båda i samma fil.

**Kan jag begränsa redigering på specifika bilder utan att påverka andra?**

Ja. Applicera lås endast på formerna på de valda bilderna. Detta ändrar inte låsinställningarna på andra bilder.

**Hur kan jag applicera lås på enskilda former i en grupp?**

Iterera genom samlingen som returneras av gruppens metod [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) och applicera lämpliga lås på varje underform. Upprepa detta för eventuella nästlade grupper och följ traverseringen i rapportexemplet.