---
title: Alakzatzárolásokkal a prezentáció szerkesztésének korlátozása Java-ban
linktitle: Prezentáció szerkesztésének korlátozása
type: docs
weight: 60
url: /hu/java/applying-protection-to-presentation/
keywords:
- szerkesztés megelőzése
- védelem a szerkesztés ellen
- alakzat zárolása
- pozíció zárolása
- kijelölés zárolása
- átméretezés zárolása
- csoportosítás zárolása
- PowerPoint
- PPTX
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet zárolni és feloldani az alakzatokat PPTX prezentációkban az Aspose.Slides for Java-val, hogy korlátozza a kijelölést, mozgatást, átméretezést és a csoportosítást."
---
## **Háttér**

Az Aspose.Slides for Java gyakori felhasználási módja, hogy automatikus munkafolyamat részeként PowerPoint (PPTX) prezentációkat hozzon létre, frissítsen és mentse. Amikor a felhasználók megkapják ezeket a prezentációkat, az alakzatok módosításának korlátozása segíthet megőrizni az eredeti elrendezést és tartalmat.

Ez a cikk elmagyarázza, hogyan vannak szervezve az alakzatok a diákon, valamint hogyan lehet alkalmazni és eltávolítani az alakzatzárolásokat egy PPTX prezentációban. Ezek a zárolások lehetővé teszik, hogy egyedi alakzatokon specifikus szerkesztési műveleteket korlátozzunk.

## **Dia összetétele**

Egy prezentációs dia olyan komponensekből áll, mint az automatikus alakzatok, táblázatok, OLE‑objektumok, csoportos alakzatok, képkockák, videókockák, csatlakozók és egyéb elemek, amelyek a prezentáció felépítéséhez szükségesek. Az Aspose.Slides for Java‑ban minden egyes elem egy olyan objektummal van reprezentálva, amely implementálja a [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) interfészt, vagy ebből egy osztályból származik.

A különböző alakzattípusok különböző zárolási lehetőségeket biztosítanak. Az [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) interfész a formazárolások alapinterfésze. Az Aspose.Slides for Java a következő zárolási interfészeket kínálja:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) automatikus alakzatok zárolása.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) csatlakozó alakzatok zárolása.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) grafikus objektumok zárolása.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) csoportos alakzatok zárolása.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) képkockák zárolása.  

A zárolások alkalmazásához egy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) esetén iterálja végig a diákat, és állítsa be a megfelelő zárolásokat minden támogatott alakzaton.

## **Védelem alkalmazása és eltávolítása**

A kompatibilis prezentációs szerkesztők az alakzatzárolásokat használják egyedi szerkesztési műveletek korlátozására. A fájl titkosítás és a dokumentumszintű írásvédelem külön [presentation protection settings](/slides/hu/java/password-protected-presentation/) beállítások.

### **Védelem alkalmazása PPTX alakzatokra**

Az Aspose.Slides for Java biztosítja a [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) interfészt az alakzatokkal való munkához.

A példa meghívja a [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), a [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-), valamint a [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) metódusokat `true` értékkel automatikus alakzatoknál, és a megfelelő zárolásokat csoportos alakzatok, csatlakozók és képkockák esetén. A csatlakozók a [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) metódust használják a mozgáshoz; a csoportok pedig a [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) metódust a csoportosítás korlátozásához.

A példa betölti a meglévő PPTX prezentációt, ellenőrzi az egyes diák alakzatgyűjteményét, és egy másolatot ment el a beállított korlátozásokkal. Az a négy kezelt típuson kívüli alakzatok változatlanok maradnak. A ciklus nem járja be a csoporton belüli gyermekalakzatokat.

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

A formazárolás eltávolításához állítsa az értékét `false`‑ra. Az alábbi példa betölt egy olyan prezentációt, amelyben alakzatzárolások vannak, és törli a kijelölés, a mozgatás és az átméretezés korlátozásait az [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) és [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) segítségével. A csoportosítási korlátot is eltávolítja a [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) `false` paraméterrel, majd egy másolatot ment a prezentációról. A többi zárolási beállítás változatlan marad.

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

### **Kép vágásának megőrzése**

Helyezzen egy `photo.jpg` nevű fényképet a munkakönyvtárba. A példa 12 %‑ot vág le balról, 8 %‑ot jobbról, majd meghívja a [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) metódust a képkocka zárolásán. A `true` érték átadása korlátozza a további vágást, és megőrzi a meglévő vágást.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    byte[] photoBytes = Files.readAllBytes(Paths.get("photo.jpg"));
    IPPImage photo = presentation.getImages().addImage(photoBytes);

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

`PictureLocked.pptx` a vágászárolást `true`‑ként tárolja. PowerPointban a **Crop** (Vágás) parancs le van tiltva, ha a fénykép ki van választva.

### **Diagram csoportos állapotának megtartása**

A példa egy téglalapot és egy nyilat csoportosít, majd meghívja a [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) metódust a csoport zárolásán, hogy a diagram elemei együtt maradjanak. Más szerkesztések, például a csoport mozgatása vagy egy komponens kitöltésének módosítása továbbra is elérhetők.

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

`DiagramLocked.pptx` az ungrouping (csoport felbontás) zárolást `true`‑ként tárolja. PowerPointban a **Ungroup** (Csoport felbontása) parancs le van tiltva, ha a teljes diagram ki van választva.

### **Összegzés**

Az Aspose.Slides for Java lehetővé teszi, hogy specifikus szerkesztési műveleteket korlátozzunk egyedi alakzatokon, vagy ugyanazokat a korlátozásokat alkalmazzuk a diákon át. Válassza ki az egyes alakzattípusok által támogatott zárolásokat, és állítsa értéküket `false`‑ra, amikor el kell távolítani a korlátozásokat.

## **GYIK**

**Kombinálhatok alakzatzárolást és jelszóvédelmet ugyanabban a bemutatóban?**

Igen. Az alakzatzárolások specifikus szerkesztési műveleteket korlátoznak, míg a [password protection](/slides/hu/java/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettőt használhatja egy fájlban.

**Korlátozhatom a szerkesztést bizonyos diákon anélkül, hogy másokon változna?**

Igen. Csak a kijelölt diák alakzataira alkalmazza a zárolásokat. Ez nem módosítja a többi dia zárolási beállításait.

**Hogyan alkalmazhatok zárakat egy csoporton belüli egyedi alakzatokra?**

Iteráljon a csoport által visszaadott [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) gyűjteményen, és alkalmazza a megfelelő zárolásokat minden gyermekalakzatra. Ismételje meg ezt minden beágyazott csoportra. A fenti példák csak a dia alakzatgyűjteményét dolgozzák fel, így nem állítanak be zárolásokat az egyedi csoporttagokon.