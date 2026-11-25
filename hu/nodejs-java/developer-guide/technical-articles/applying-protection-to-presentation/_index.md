---
title: Prezentációs szerkesztések korlátozása alakzatzárolásokkal Node.js-ben
linktitle: Prezentációs szerkesztések korlátozása
type: docs
weight: 60
url: /hu/nodejs-java/applying-protection-to-presentation/
keywords:
- szerkesztések megakadályozása
- védés a szerkesztéstől
- alakzat zárolása
- pozíció zárolása
- kiválasztás zárolása
- átméretezés zárolása
- csoportosítás zárolása
- PowerPoint
- PPTX
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan lehet zárolni és feloldani az alakzatokat PPTX prezentációkban az Aspose.Slides for Node.js via Java segítségével, hogy korlátozza a kiválasztást, mozgatást, átméretezést és a csoportosítást."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java gyakori felhasználása PowerPoint (PPTX) prezentációk létrehozása, frissítése és mentése egy automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a prezentációkat, az alakzatok módosításának korlátozása segíthet megőrizni a kívánt elrendezést és tartalmat.

Ez a cikk ismerteti, hogy az alakzatok hogyan vannak elrendezve a diákon, és hogyan lehet alkalmazni és eltávolítani az alakzatzárolásokat egy PPTX prezentációban. Ezek a zárolások lehetővé teszik, hogy egyedi alakzatoknál meghatározott szerkesztési műveleteket korlátozzunk.

## **Dia felépítése**

Egy prezentáció dia alkotóelemei közé tartoznak az autóalakzatok, táblázatok, OLE objektumok, csoportosított alakzatok, képkeretek, videókeretek, csatlakozók és egyéb elemek, amelyeket a prezentáció felépítéséhez használnak. Az Aspose.Slides for Node.js via Java‑ban a dia minden eleme egy olyan objektummal van reprezentálva, amely a [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) osztályból származik.

A különböző alakzat típusok eltérő zárolási lehetőségeket biztosítanak. A [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) osztály az alakzatzárolások alaposztálya. Az Aspose.Slides for Node.js via Java a következő zárolási osztályokat kínálja:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) locks autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) locks connector shapes.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) locks graphical objects.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) locks group shapes.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) locks picture frames.  

A [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) egészére vonatkozó zárolások alkalmazásához iteráljon a diákon, és állítsa be a megfelelő zárolásokat minden támogatott alakzatra.

## **Védelem alkalmazása és eltávolítása**

A kompatibilis prezentációs szerkesztők alakzatzárolásokat használnak az egyedi szerkesztési műveletek korlátozására. A fájl titkosítása és a dokumentumszintű írásvédelmi beállítások különálló [prezentációvédelmi beállítások](/slides/hu/nodejs-java/password-protected-presentation/) beállítások.

### **Védelem alkalmazása PPTX alakzatokra**

Az Aspose.Slides for Node.js via Java a [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) osztályt biztosítja a dián lévő alakzatokkal való munkához.

A példa meghívja a [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) és [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) metódusokat `true` értékkel az autóalakzatokhoz, illetve megfelelő zárolásokat a csoportos alakzatokhoz, csatlakozókhoz és képkeretekhez. A csatlakozók a [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) metódust használják a mozgatáshoz; a csoportok pedig a [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) metódust a csoportosítás korlátozásához.

A példa betölt egy meglévő PPTX prezentációt, ellenőrzi az egyes diák alakzatgyűjteményét, és egy másolatot ment az alkalmazott korlátozásokkal. A négy kezelt típuson kívüli alakzatok változatlanul maradnak. A ciklus nem járja be egy csoporton belüli gyermek alakzatokat.

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

### **Védelem eltávolítása**

Az alakzatzárolás eltávolításához állítsa az értékét `false`‑ra. A következő példa betölt egy prezentációt alakzatzárolásokkal, és törli a kiválasztási, mozgási és átméretezési korlátozásokat az [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) és [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) segítségével. Emellett a csoportosítási korlátozást is eltávolítja a `false` átadásával a [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) metódushoz, és ment egy másolatot a prezentációról. A többi zárolási beállítás változatlan marad.

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

### **Képvágás megőrzése**

Helyezzen egy `photo.jpg` nevű fotót a munkakönyvtárba. A példa 12 %-ot vág le balról és 8 %-ot jobb oldalról, majd meghívja a [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked) metódust a képkeret zárolásán. A `true` átadása további vágást korlátoz és megőrzi a meglévő vágást.

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

`PictureLocked.pptx` a vágás zárolást `true`‑ként tárolja. PowerPointban a **Crop** (Vágás) parancs le van tiltva, ha a fotó ki van választva.

### **Diagram csoportosítva tartása**

A példa egy téglalapot és egy nyilat csoportosít, majd meghívja a [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) metódust a csoport zárolásán, hogy a diagram elemei együtt maradjanak. Más szerkesztések, például a csoport mozgatása vagy egy komponens kitöltésének változtatása, továbbra elérhetők.

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

`DiagramLocked.pptx` az ungrouping (csoport bontása) zárolást `true`‑ként tárolja. PowerPointban a **Ungroup** (Csoport bontása) parancs le van tiltva, ha az egész diagram ki van választva.

### **Létező alakzatzárolások jelentése**

Egy sablon áttekintéséhez nyissa meg, és olvassa ki az egyes alakzatok zárolási objektumát. A [getNoLocks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/#getNoLocks) metódus `true`‑t ad vissza, ha az objektum összes jelzője le van tiltva, és `false`‑t, ha legalább egy engedélyezve van. Egy csoport és annak gyermekei külön zárolási objektumokkal rendelkeznek, ezért ellenőrizze a gyermekeket akkor is, ha a csoportnak nincs zárolása.

Ez a példa ellenőrzi a mozgást autóalakzatoknál, képkereteknél és csoportoknál. Ezen felül a képek vágását és a csoportok csoport bontását is vizsgálja. A jelentés felsorolja az észlelt engedélyezett jelzőket és megjelöli azokat az alakzattípusokat, amelyeket nem vizsgál.

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

Tegyük fel, hogy a `Sample.pptx` első diáján egy `Layout` nevű csoport van, amelynek a csoport bontása zárolva van, egy benne lévő `Photo` nevű kép, amelynek a vágása zárolva van, és egy `Free` nevű, zárolás nélküli téglalap. A jelentés kihagyja a `Free` elemet, és ezt a két sort írja ki:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

A jelentés a tárolt alakzatszintű szerkesztési jelzőket olvassa anélkül, hogy módosítaná őket vagy mentené a prezentációt. A dokumentumszintű írásvédelmet külön beállításként kell kezelni, és a jelzők érvényesítését az adott szerkesztő határozza meg.

### **Összegzés**

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy egyedi alakzatoknál meghatározott szerkesztési műveleteket korlátozzon, vagy ugyanazokat a korlátozásokat az összes dián alkalmazza. Válassza ki az egyes alakzattípusok által támogatott zárolásokat, és állítsa értéküket `false`‑ra, ha el szeretné távolítani ezeket a korlátozásokat.

## **GYIK**

**Kombinálhatok alakzatzárolásokat és jelszóvédelmet ugyanabban a prezentációban?**

Igen. Az alakzatzárolások meghatározott szerkesztési műveleteket korlátoznak, míg a [jelszóvédelem](/slides/hu/nodejs-java/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettőt használhatja ugyanabban a fájlban.

**Korlátozhatom a szerkesztést bizonyos diákon anélkül, hogy másokat befolyásolnék?**

Igen. Csak a kijelölt diák alakzataira alkalmazzon zárolásokat. Ez nem változtatja meg a többi dia zárolási beállításait.

**Hogyan alkalmazhatok zárolásokat egy csoporton belüli egyedi alakzatokra?**

Iteráljon a csoport által visszaadott gyűjteményen a [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) metódus segítségével, és alkalmazza a megfelelő zárolásokat minden gyermek alakzatra. Ismételje meg ezt a beágyazott csoportok esetén, a jelentéspéldában bemutatott bejárást követve.