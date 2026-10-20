---
title: "Prezentáció szerkesztésének korlátozása alakzatzárolásokkal Node.js-ben"
linktitle: "Prezentáció szerkesztésének korlátozása"
type: docs
weight: 60
url: /hu/nodejs-java/applying-protection-to-presentation/
keywords:
- "szerkesztés megelőzése"
- "védje a szerkesztéstől"
- "alakzat zárolása"
- "pozíció zárolása"
- "kiválasztás zárolása"
- "átméretezés zárolása"
- "csoportosítás zárolása"
- "PowerPoint"
- "PPTX"
- "prezentáció"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Ismerje meg, hogyan zárolhat és feloldhat alakzatokat PPTX prezentációkban az Aspose.Slides for Node.js via Java segítségével, hogy korlátozza a kiválasztást, mozgatást, átméretezést és a csoportosítást."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via Java gyakori felhasználási módja, hogy PowerPoint (PPTX) prezentációkat hozzon létre, frissítsen és mentse egy automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a prezentációkat, a formák módosításának korlátozása segíthet megőrizni a szándékolt elrendezést és tartalmat.

Ez a cikk bemutatja, hogyan szerveződnek a formák a diákon, és hogyan lehet alkalmazni és eltávolítani a formazárolásokat egy PPTX prezentációban. Ezek a zárolások lehetővé teszik, hogy korlátozzuk a specifikus szerkesztési műveleteket az egyes formákon.

## **Dia felépítése**

Egy prezentációs dia olyan összetevőkből áll, mint az autoshape-ek, táblázatok, OLE-objektumok, csoportosított formák, képkeretek, videokeretek, csatlakozók és egyéb elemek, amelyekkel a prezentáció felépül. Az Aspose.Slides for Node.js via Java esetében a dia minden eleme egy olyan objektummal van reprezentálva, amely a [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) osztályból származik.

Különböző forma típusok különböző zárolási lehetőségeket kínálnak. A [BaseShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseshapelock/) osztály a formazárolások alaposztálya. Az Aspose.Slides for Node.js via Java a következő zárolási osztályokat biztosítja:

- [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/) zárolja az autoshape-eket.  
- [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) zárolja a csatlakozó formákat.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) zárolja a grafikus objektumokat.  
- [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/) zárolja a csoportosított formákat.  
- [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) zárolja a képkereteket.  

A zárolások alkalmazásához egy [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) esetén iteráljunk végig a diákon, és állítsuk be a megfelelő zárolásokat minden támogatott formán.

## **Védelem alkalmazása és eltávolítása**

A formazárolások korlátozzák az olyan műveleteket, mint a formák kiválasztása, mozgatása és átméretezése. Nem teszik a teljes prezentációt szerkeszthetetlenné.

### **Védelem alkalmazása PPTX formákra**

Az Aspose.Slides for Node.js via Java a [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) osztályt biztosítja a diáikon található formákkal való munkához.

A példa meghívja a [setSelectLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSelectLocked), a [setPositionLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setPositionLocked) és a [setSizeLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/#setSizeLocked) metódusokat `true` értékkel az autoshape-eknél, a csoportosított formák, csatlakozók és képkeretek esetén pedig a megfelelő ekvivalens zárolásokat. A csatlakozók a [setPositionMove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/#setPositionMove) metódust használják a mozgatáshoz; a csoportok a [setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) metódussal korlátozzák a csoportosítást.

A példa betölt egy meglévő PPTX prezentációt, ellenőrzi a formákat minden dia forma gyűjteményében, és egy másolatot ment el a beállított korlátozásokkal. A négy kezelt típuson kívüli formák változatlanul maradnak. A ciklus nem járja be a csoporton belüli gyermekformákat.

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

A formazárolás eltávolításához állítsa az értékét `false`‑ra. A következő példa betölt egy prezentációt formazárolásokkal, és a [AutoShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshapelock/), a [GroupShapeLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/), a [ConnectorLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/connectorlock/) és a [PictureFrameLock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframelock/) segítségével törli a kiválasztás, mozgatás és átméretezés korlátozásait. A csoportosítási korlátozást is eltávolítja a [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshapelock/#setGroupingLocked) `false` értékének átadásával, majd elment egy másolatot a prezentációról. A többi zárolási beállítás változatlan marad.

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

### **Következtetés**

Az Aspose.Slides for Node.js via Java lehetővé teszi specifikus szerkesztési műveletek korlátozását egyedi formákon, vagy azonos korlátozások alkalmazását több dián is. Válassza ki az egyes forma típusok által támogatott zárolásokat, és állítsa az értéküket `false`‑ra, ha el kell távolítania ezeket a korlátozásokat.

## **GYIK**

**Kombinálhatom a formazárolásokat és a jelszóvédelmet egyetlen prezentációban?**

Igen. A formazárolások specifikus szerkesztési műveleteket korlátoznak, míg a [jelszóvédelem](/slides/hu/nodejs-java/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettő használható ugyanabban a fájlban.

**Korlátozhatom a szerkesztést egyes diákon anélkül, hogy másokra hatással lenne?**

Igen. Csak a kiválasztott diák formáin alkalmazzon zárolásokat. Ez nem változtatja meg a többi dia zárolási beállításait.

**Hogyan alkalmazhatok zárolásokat egyéni formákra egy csoporton belül?**

Iteráljon a csoport [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) metódusa által visszaadott gyűjteményen, és alkalmazza a megfelelő zárolásokat minden gyermekformára. Ismételje meg ezt minden beágyazott csoport esetén. A fenti példák csak a dia forma gyűjteményét dolgozzák fel, ezért nem állítják be a zárolásokat az egyedi csoporttagokon.