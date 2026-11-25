---
title: Beperk presentatiebewerkingen met vormvergrendelingen in Node.js
linktitle: Beperk presentatiebewerkingen
type: docs
weight: 60
url: /nl/nodejs-java/applying-protection-to-presentation/
keywords:
- bewerkingen voorkomen
- beschermen tegen bewerken
- vorm vergrendelen
- positie vergrendelen
- selectie vergrendelen
- grootte vergrendelen
- groepering vergrendelen
- PowerPoint
- PPTX
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u vormen in PPTX-presentaties kunt vergrendelen en ontgrendelen met Aspose.Slides voor Node.js via Java om selectie, verplaatsing, formaatwijziging en groepering te beperken."
---
## **Overzicht**

Een veelvoorkomend gebruik van Aspose.Slides voor Node.js via Java is het maken, bijwerken en opslaan van PowerPoint‑presentaties (PPTX) als onderdeel van een geautomatiseerde workflow. Wanneer gebruikers deze presentaties ontvangen, kan het beperken van wijzigingen aan vormen helpen de beoogde lay‑out en inhoud te behouden.

Dit artikel legt uit hoe vormen zijn georganiseerd op dia's en hoe je vormvergrendelingen kunt toepassen en verwijderen in een PPTX‑presentatie. Deze vergrendelingen stellen je in staat specifieke bewerkingsbewerkingen op individuele vormen te beperken.

## **Samenstelling van een dia**

Een presentatiedia bestaat uit componenten zoals autovormen, tabellen, OLE‑objecten, gegroepeerde vormen, afbeeldingskaders, video‑kaders, verbindingslijnen en andere elementen die worden gebruikt om een presentatie op te bouwen. In Aspose.Slides voor Node.js via Java wordt elk element op een dia weergegeven door een object dat erft van de [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)‑klasse.

Verschillende vormtypen bieden verschillende vergrendelingsopties. De [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/)‑klasse is de basisklasse voor vormvergrendelingen. Aspose.Slides voor Node.js via Java biedt de volgende vergrendelingsklassen:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) vergrendelt autovormen.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) vergrendelt verbindingsvormen.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) vergrendelt grafische objecten.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) vergrendelt gegroepeerde vormen.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) vergrendelt afbeeldingskaders.  

Om vergrendelingen toe te passen op een [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/), doorloop je de dia's en stel je de juiste vergrendelingen in op elke ondersteunde vorm.

## **Bescherming toepassen en verwijderen**

Compatibele presentatieredacteurs gebruiken vormvergrendelingen om individuele bewerkingsbewerkingen te beperken. Bestandversleuteling en schrijfbeveiliging op documentniveau zijn afzonderlijke [presentatiebeveiligingsinstellingen](/slides/nl/nodejs-java/password-protected-presentation/).

### **Bescherming toepassen op PPTX‑vormen**

Aspose.Slides voor Node.js via Java biedt de [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)‑klasse om met vormen op een dia te werken.

Het voorbeeld roept [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) en [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) aan met `true` voor autovormen, met equivalente vergrendelingen voor gegroepeerde vormen, verbindingslijnen en afbeeldingskaders. Verbindingslijnen gebruiken [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) voor verplaatsing; groepen gebruiken ook [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) om groepering te beperken.

Het voorbeeld laadt een bestaande PPTX‑presentatie, controleert de vormen in de vormverzameling van elke dia en slaat een kopie op met deze beperkingen toegepast. Vormen buiten de vier behandelde types blijven ongewijzigd. De lus doorloopt de onderliggende vormen binnen een groep niet.

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

### **Vergrendeling verwijderen**

Om een vormvergrendeling te verwijderen, stel je de waarde in op `false`. Het volgende voorbeeld laadt een presentatie met vormvergrendelingen en wist de selectie‑, verplaatsings‑ en vergrootingsbeperkingen via [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) en [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/). Het verwijdert ook de groeperingsbeperking door `false` door te geven aan [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) en slaat een kopie van de presentatie op. Andere vergrendelingsinstellingen blijven ongewijzigd.

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

### **Beeldbijsnijding behouden**

Plaats een foto met de naam `photo.jpg` in de werkmap. Het voorbeeld bijsnijdt 12 % van de linkerkant en 8 % van de rechterkant, en roept vervolgens [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked) aan op de vergrendeling van het afbeeldingskader. Het doorgeven van `true` beperkt verdere bijsnijding en behoudt de bestaande bijsnijding.

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

`PictureLocked.pptx` slaat de bijsnijdingsvergrendeling op als `true`. In PowerPoint is de **Crop**‑opdracht uitgeschakeld wanneer de foto is geselecteerd.

### **Diagram gegroepeerd houden**

Het voorbeeld groepeert een rechthoek en een pijl, en roept vervolgens [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) aan op de vergrendeling van de groep om de componenten van het diagram samen te houden. Andere bewerkingen, zoals het verplaatsen van de groep of het wijzigen van de vulling van een component, blijven beschikbaar.

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

`DiagramLocked.pptx` slaat de ontgroeperingsvergrendeling op als `true`. In PowerPoint is de **Ungroup**‑opdracht uitgeschakeld wanneer het volledige diagram is geselecteerd.

### **Bestaande vormvergrendelingen rapporteren**

Om een sjabloon te beoordelen, open je deze en lees je het vergrendelingsobject voor elke vorm. De [getNoLocks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/#getNoLocks)‑methode geeft `true` terug wanneer alle vlaggen op dat object zijn uitgeschakeld en `false` wanneer er minstens één is ingeschakeld. Een groep en zijn onderliggende vormen hebben afzonderlijke vergrendelingsobjecten, dus inspecteer de onderliggende vormen zelfs als de groep geen vergrendelingen heeft.

Dit voorbeeld controleert de verplaatsing voor autovormen, afbeeldingskaders en groepen. Het controleert ook de bijsnijding voor afbeeldingen en de ontgroepering voor groepen. Het rapport vermeldt de ingeschakelde vlaggen die het herkent en markeert vormtypen die het niet inspecteert.

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

Stel dat dia 1 van `Sample.pptx` een groep bevat met de naam `Layout` waarvan de ontgroepering vergrendeld is, een afbeelding met de naam `Photo` erin waarvan de bijsnijding vergrendeld is, en een niet‑vergrendelde rechthoek met de naam `Free`. Het rapport slaat `Free` over en drukt deze twee regels af:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Het rapport leest de opgeslagen bewerkingsvlaggen op vormniveau zonder ze te wijzigen of de presentatie op te slaan. Schrijfbeveiliging op documentniveau is een aparte instelling, en de handhaving van elke vlag hangt af van de editor.

## **Conclusie**

Aspose.Slides voor Node.js via Java stelt je in staat specifieke bewerkingsbewerkingen op individuele vormen te beperken of dezelfde beperkingen op meerdere dia's toe te passen. Kies de vergrendelingen die door elk vormtype worden ondersteund, en stel hun waarden in op `false` wanneer je die beperkingen wilt verwijderen.

## **FAQ**

**Kan ik vormvergrendelingen en wachtwoordbeveiliging combineren in dezelfde presentatie?**

Ja. Vormvergrendelingen beperken specifieke bewerkingsbewerkingen, terwijl [wachtwoordbeveiliging](/slides/nl/nodejs-java/password-protected-presentation/) het openen of wijzigen van de presentatie kan beperken. Je kunt beide in hetzelfde bestand gebruiken.

**Kan ik bewerken beperken op specifieke dia's zonder andere te beïnvloeden?**

Ja. Pas vergrendelingen alleen toe op vormen op de geselecteerde dia's. Dit verandert de vergrendelingsinstellingen op andere dia's niet.

**Hoe kan ik vergrendelingen toepassen op individuele vormen binnen een groep?**

Doorloop de collectie die wordt geretourneerd door de [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes)‑methode van de groep en pas de juiste vergrendelingen toe op elke onderliggende vorm. Herhaal dit voor eventuele geneste groepen, volgens de doorloop in het rapportage‑voorbeeld.