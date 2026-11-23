---
title: Prezentáció szerkesztésének korlátozása alakzatzárlakkal Node.js-ben
linktitle: Prezentáció szerkesztésének korlátozása
type: docs
weight: 60
url: /hu/nodejs-java/applying-protection-to-presentation/
keywords:
- szerkesztés megakadályozása
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
description: "Ismerje meg, hogyan lehet zárolni és feloldani alakzatokat PPTX prezentációkban az Aspose.Slides for Node.js via Java segítségével, hogy korlátozza a kiválasztást, mozgást, átméretezést és a csoportosítást."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java gyakori felhasználása, hogy PowerPoint (PPTX) prezentációkat hozzunk létre, frissítsünk és mentsünk egy automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a prezentációkat, az alakzatok módosításának korlátozása segíthet megőrizni a szándékolt elrendezést és tartalmat.

Ez a cikk elmagyarázza, hogyan szerveződnek az alakzatok a diákon, és hogyan lehet alkalmazni és eltávolítani az alakzatzárakat egy PPTX prezentációban. Ezek a zárak lehetővé teszik, hogy egyes alakzatokra vonatkozó szerkesztési műveleteket korlátozzunk.

## **Dia összetétele**

Egy prezentációs dia olyan összetevőkből áll, mint az automatikus alakzatok, táblázatok, OLE objektumok, csoportosított alakzatok, képkockák, videokockák, csatlakozók és egyéb elemek, amelyek a prezentáció építésére szolgálnak. Az Aspose.Slides for Node.js via Java-ban a dia minden eleme egy olyan objektum által van reprezentálva, amely a [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) osztályból származik.

A különböző alakzattípusok különböző zárolási lehetőségeket kínálnak. A [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) osztály az alakzatzárak alaposztálya. Az Aspose.Slides for Node.js via Java a következő zárolási osztályokat biztosítja:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) zárolja az automatikus alakzatokat.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) zárolja a csatlakozó alakzatokat.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) zárolja a grafikus objektumokat.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) zárolja a csoportos alakzatokat.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) zárolja a képkockákat.  

A zárak alkalmazásához egy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) során iteráljon a diáknál, és állítsa be a megfelelő zárakat minden támogatott alakzatra.

## **Zárolás alkalmazása és eltávolítása**

A kompatibilis prezentációs szerkesztők alakzatzárakat használnak az egyedi szerkesztési műveletek korlátozására. A fájl titkosítása és a dokumentumszintű írásvédelmet külön [prezentációvédelmi beállítások](/slides/hu/nodejs-java/password-protected-presentation/) tartalmazza.

### **Alkalmazás védelem PPTX alakzatokra**

Az Aspose.Slides for Node.js via Java biztosítja a [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) osztályt az alakzatokkal való munkához egy dián.

A példa a [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), a [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) és a [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) metódusokat hívja `true` értékkel az automatikus alakzatok esetén, valamint az ekvivalens zárakat a csoportos alakzatok, csatlakozók és képkockák esetén. A csatlakozók a [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) metódust használják a mozgatáshoz; a csoportok a [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) metódust is használják a csoportosítás korlátozásához.

A példa betölt egy meglévő PPTX prezentációt, ellenőrzi az alakzatokat minden dia alakzatgyűjteményében, és egy másolatot ment el ezekkel a korlátozásokkal. A négy kezelt típuson kívüli alakzatok változatlanok maradnak. A ciklus nem járja be a csoporton belüli gyermekalakzatokat.

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

Az alakzatzár eltávolításához állítsa az értékét `false`-ra. A következő példa betölt egy prezentációt alakzatzárral, és törli a kiválasztási, mozgási és átméretezési korlátozásokat a [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), a [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), a [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) és a [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) segítségével. A csoportosítási korlátozást is eltávolítja, ha `false`-t ad a [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) metódusnak, majd egy másolatot ment a prezentációról. A többi zárolási beállítás változatlan marad.

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

Tegyen egy `photo.jpg` nevű fényképet a munkakönyvtárba. A példa 12%-ot vág le balról és 8%-ot jobbról, majd meghívja a [setCropLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/#setCropLocked) metódust a képkocka zárolásán. A `true` érték átadása további vágást korlátoz, és megőrzi a már meglévő vágást.

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

`PictureLocked.pptx` a vágászárat `true` értékként tárolja. PowerPointban a **Crop** parancs le van tiltva, ha a fénykép ki van jelölve.

### **Diagram csoportosítva tartása**

A példa egy téglalapot és egy nyilat csoportosít, majd meghívja a [setUngroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setUngroupingLocked) metódust a csoport zárolásán, hogy a diagram elemei együtt maradjanak. Más szerkesztések, például a csoport mozgatása vagy egy komponens kitöltésének módosítása továbbra is elérhetők.

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

`DiagramLocked.pptx` a csoportbontás zárolását `true` értékként tárolja. PowerPointban a **Ungroup** parancs le van tiltva, ha a teljes diagram ki van jelölve.

### **Összegzés**

Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy egyes alakzatokra vonatkozó specifikus szerkesztési műveleteket korlátozzon, vagy ugyanazokat a korlátozásokat alkalmazza a diákon át. Válassza ki az adott alakzattípus által támogatott zárakat, és állítsa az értéküket `false`-ra, ha el szeretné távolítani ezeket a korlátozásokat.

## **GYIK**

**Kombinálhatok alakzatzárakat és jelszóvédelmet ugyanabban a prezentációban?**

Igen. Az alakzatzárak a specifikus szerkesztési műveleteket korlátozzák, míg a [jelszóvédelem](/slides/hu/nodejs-java/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettőt használhatja ugyanabban a fájlban.

**Korlátozhatom a szerkesztést adott diákon anélkül, hogy a többit befolyásolnám?**

Igen. Csak a kiválasztott diák alakzataira alkalmazzon zárakat. Ez nem változtatja meg a többi dia zárbeállításait.

**Hogyan alkalmazhatok zárakat egyes alakzatokra egy csoporton belül?**

Iteráljon a csoport által visszaadott [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) metódus gyűjteményén, és alkalmazza a megfelelő zárakat minden gyermekalakzatra. Ismételje meg ezt minden beágyazott csoportra. A fenti példák csak a dia alakzatgyűjteményét dolgozzák fel, ezért nem állítanak be zárakat az egyes csoporttagokra.