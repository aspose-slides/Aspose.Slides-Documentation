---
title: Prezentáció szerkesztésének korlátozása alakzatzárolásokkal Androidon
linktitle: Prezentáció szerkesztésének korlátozása
type: docs
weight: 60
url: /hu/androidjava/applying-protection-to-presentation/
keywords:
- szerkesztés megelőzése
- szerkesztés elleni védelem
- alakzat zárolása
- pozíció zárolása
- kijelölés zárolása
- átméretezés zárolása
- csoportosítás zárolása
- PowerPoint
- PPTX
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet zárolni és feloldani az alakzatokat PPTX prezentációkban az Aspose.Slides for Android via Java segítségével, a kiválasztás, mozgatás, átméretezés és csoportosítás korlátozása érdekében."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java gyakori felhasználása, hogy PowerPoint (PPTX) prezentációkat hozzon létre, frissítsen és mentse egy automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a prezentációkat, az alakzatok módosításának korlátozása segíthet megőrizni a kívánt elrendezést és tartalmat.

Ez a cikk elmagyarázza, hogyan vannak az alakzatok szervezve a diákon, és hogyan lehet alakzatzárakat alkalmazni és eltávolítani egy PPTX prezentációban. Ezek a zárak lehetővé teszik egyes alakzatok szerkesztési műveleteinek korlátozását.

## **Dia felépítése**

Egy prezentációs dia olyan összetevőkből áll, mint az automatikus alakzatok, táblázatok, OLE objektumok, csoportosított alakzatok, képkockák, videokockák, kapcsolók és egyéb elemek, amelyek a prezentáció építésére szolgálnak. Az Aspose.Slides for Android via Java-ban a dia minden eleme egy olyan objektummal van reprezentálva, amely megvalósítja az [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) interfészt vagy onnan származtatott osztályt.

A különböző alakzattípusok különféle zárolási lehetőségeket kínálnak. Az [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) interfész az alakzatzárolások alapinterfésze. Az Aspose.Slides for Android via Java a következő zárolási interfészeket biztosítja:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) zárolja az automatikus alakzatokat.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) zárolja a csatlakozó alakzatokat.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) zárolja a grafikus objektumokat.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) zárolja a csoportos alakzatokat.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) zárolja a képkockákat.  

A [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) zárolások alkalmazásához iteráljon a diákon, és állítsa be a megfelelő zárolásokat minden támogatott alakzatra.

## **Védelem alkalmazása és eltávolítása**

Alakzatzárolások korlátozzák az olyan műveleteket, mint az alakzatok kiválasztása, mozgatása és átméretezése. Nem teszik a teljes prezentációt szerkeszthetetlenné.

### **Védelem alkalmazása PPTX alakzatokra**

Az Aspose.Slides for Android via Java biztosítja az [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) interfészt az alakzatokkal való munkához egy dián.

A példa meghívja a [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-) a [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) és a [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) metódusokat `true` értékkel az automatikus alakzatoknál, valamint a megfelelő zárolásokat a csoportos alakzatoknál, a csatlakozóknál és a képkockáknál. A csatlakozók a [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) metódust használják a mozgáshoz; a csoportok pedig a [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) metódust a csoportosítás korlátozásához.

A példa betölt egy meglévő PPTX prezentációt, ellenőrzi az egyes diák alakzatgyűjteményét, és elment egy másolatot a alkalmazott korlátozásokkal. Az a négy kezelt típuson kívüli alakzatok változatlanul maradnak. A ciklus nem járja be a csoporton belüli gyermek alakzatokat.

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

### **Védelem eltávolítása**

Az alakzatzárolás eltávolításához állítsa az értékét `false`-ra. A következő példa betölt egy prezentációt alakzatzárolásokkal, és törli a kiválasztás, a mozgás és az átméretezés korlátozásait az [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/)​, az [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/)​, az [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/)​ és az [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/)​ segítségével. A csoportosítási korlátozást is eltávolítja, a `false` értéket átadva az [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) metódusnak, majd elment egy másolatot a prezentációról. A többi zár beállítás változatlan marad.

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

### **Következtetés**

Az Aspose.Slides for Android via Java lehetővé teszi, hogy egyes alakzatok szerkesztési műveleteit korlátozza, vagy ugyanazokat a korlátozásokat alkalmazza a diákon. Válassza ki az egyes alakzattípusokhoz támogatott zárolásokat, és állítsa be az értéküket `false`-ra, ha el akarja távolítani ezeket a korlátozásokat.

## **GYIK**

**Kombinálhatok-e alakzatzárolásokat és jelszóvédelem egyazon prezentációban?**

Igen. Az alakzatzárolások specifikus szerkesztési műveleteket korlátoznak, míg a [jelszóvédelem](/slides/hu/androidjava/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettőt használhatja ugyanabban a fájlban.

**Korlátozhatom-e a szerkesztést bizonyos diákon anélkül, hogy a többit érinteném?**

Igen. Csak a kiválasztott diákon lévő alakzatokra alkalmazzon zárolásokat. Ez nem változtatja meg a többi dia zár beállításait.

**Hogyan alkalmazhatok zárolásokat egyéni alakzatokra egy csoporton belül?**

Iteráljon a csoport [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) metódusa által visszaadott gyűjteményen, és alkalmazza a megfelelő zárolásokat minden gyermek alakzatra. Ismételje meg ezt minden beágyazott csoportnál. A fenti példák csak a dia alakzatgyűjteményét dolgozzák fel, így nem állítanak be zárolásokat az egyéni csoporttagokra.