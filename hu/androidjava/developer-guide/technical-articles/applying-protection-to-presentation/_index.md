---
title: Alkalmazás szerkesztésének korlátozása alakzatzárakkal Androidon
linktitle: Prezentáció szerkesztésének korlátozása
type: docs
weight: 60
url: /hu/androidjava/applying-protection-to-presentation/
keywords:
- szerkesztés megakadályozása
- védelem a szerkesztés ellen
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
description: "Ismerje meg, hogyan lehet alakzatokat zárolni és feloldani PPTX prezentációkban az Aspose.Slides for Android via Java használatával, a kijelölés, mozgatás, átméretezés és csoportosítás korlátozása érdekében."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java gyakori felhasználása PowerPoint (PPTX) prezentációk létrehozása, frissítése és mentése automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a prezentációkat, az alakzatok módosításának korlátozása segíthet megőrizni a tervezett elrendezést és tartalmat.

Ez a cikk elmagyarázza, hogyan szerveződnek az alakzatok a diákon, és hogyan alkalmazhatók és távolíthatók el az alakzatzárak egy PPTX prezentációban. Ezek a zárolások lehetővé teszik, hogy bizonyos szerkesztési műveleteket korlátozzunk egyes alakzatokon.

## **Dia összetétele**

Egy prezentációs dia olyan összetevőkből áll, mint az automatikus alakzatok, táblázatok, OLE objektumok, csoportosított alakzatok, képkeretek, videokeretek, csatlók és más elemek, amelyeket a prezentáció építéséhez használnak. Az Aspose.Slides for Android via Java-ban a dia minden eleme egy olyan objektum által van képviselve, amely megvalósítja az [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) interfészt, vagy egy olyan osztályból származik, amely megvalósítja azt.

A különböző alakzat típusok különböző zárolási lehetőségeket kínálnak. Az [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) interfész az alakzatzárak alap interfésze. Az Aspose.Slides for Android via Java a következő zárolási interfészeket biztosítja:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) az automatikus alakzatokat zárolja.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) a csatló alakzatokat zárolja.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) a grafikus objektumokat zárolja.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) a csoportosított alakzatokat zárolja.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) a képkereteket zárolja.  

A zárolások egy [Prezentáció](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) alkalmazásához iteráljon a diákon, és állítsa be a megfelelő zárolásokat minden támogatott alakzatra.

## **Védelem alkalmazása és eltávolítása**

A kompatibilis prezentációs szerkesztők alakzatzárakat használnak az egyedi szerkesztési műveletek korlátozására. A fájl titkosítás és a dokumentumszintű írásvédelem külön [prezentációvédelmi beállítások](/slides/hu/androidjava/password-protected-presentation/).

### **Védelem alkalmazása PPTX alakzatokra**

Az Aspose.Slides for Android via Java biztosítja az [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) interfészt az alakzatok kezeléséhez egy dián.

A példa meghívja a [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-) a [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) és a [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) metódusokat `true` értékkel az automatikus alakzatokhoz, valamint a csoportosított alakzatok, csatlók és képkeretek megfelelő zárolásait. A csatlók a [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) metódust használják a mozgáshoz; a csoportok a [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) metódussal korlátozzák a csoportosítást.

A példa betölt egy meglévő PPTX prezentációt, ellenőrzi az egyes diák alakzatgyűjteményét, és elment egy másolatot a felhasznált korlátozásokkal. A négy kezelt típustól eltérő alakzatok változatlanok maradnak. A ciklus nem járja be a csoporton belüli gyermekalakzatokat.

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

Az alakzatzár eltávolításához állítsa az értékét `false`‑ra. A következő példa betölt egy prezentációt alakzatzárral, és törli a kijelölés, a mozgás és az átméretezés korlátozásait az [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) és [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) segítségével. A csoportosítási korlátozást is eltávolítja, ha `false`‑t ad át az [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) metódusnak, majd elment egy másolatot a prezentációról. A többi zár beállítás változatlan marad.

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

Helyezzen el egy `photo.jpg` nevű fényképet a munkakönyvtárban. A példa 12%-ot vág le balról és 8%-ot jobbról, majd meghívja a [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) metódust a képkeret zárolásán. Ha `true`‑t ad át, korlátozza a további vágást és megőrzi a meglévő vágást.

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

`PictureLocked.pptx` a vágászárat `true`‑ként tárolja. PowerPointban a **Crop** (Vágás) parancs le van tiltva, ha a fénykép ki van választva.

### **Diagram csoportosítva tartása**

A példa egy téglalapot és egy nyilat csoportosít, majd meghívja a [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) metódust a csoport zárolásán, hogy a diagram elemei együttesen maradjanak. Más szerkesztések, például a csoport mozgatása vagy egy elem kitöltésének módosítása, továbbra is elérhetők.

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

`DiagramLocked.pptx` a csoportosítás feloldásának zárolását `true`‑ként tárolja. PowerPointban a **Ungroup** (Csoport feloldása) parancs le van tiltva, ha az egész diagram ki van választva.

### **Következtetés**

Az Aspose.Slides for Android via Java lehetővé teszi, hogy korlátozza a specifikus szerkesztési műveleteket egyes alakzatokon, vagy ugyanazokat a korlátozásokat alkalmazza a diákon keresztül. Válassza ki az egyes alakzat típusok által támogatott zárolásokat, és állítsa értéküket `false`‑ra, ha el szeretné távolítani ezeket a korlátozásokat.

## **GYIK**

**Kombinálhatok alakzatzárakat és jelszóvédelmet ugyanabban a prezentációban?**

Igen. Az alakzatzárak bizonyos szerkesztési műveleteket korlátoznak, míg a [jelszóvédelem](/slides/hu/androidjava/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettőt használhatja ugyanabban a fájlban.

**Korlátozhatom a szerkesztést konkrét diákon anélkül, hogy a többit érinteném?**

Igen. Csak a kiválasztott diák alakzataira alkalmazzon zárolásokat. Ez nem módosítja a többi dia zárbeállításait.

**Hogyan alkalmazhatok zárolásokat egyes alakzatokra egy csoporton belül?**

Iteráljon a csoport [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) metódusa által visszaadott gyűjteményen, és alkalmazza a megfelelő zárolásokat minden gyermekalakzatra. Ismételje meg ezt minden beágyazott csoportnál. A fenti példák csak a dia alakzatgyűjteményét dolgozzák fel, így nem állítanak be zárolásokat az egyes csoporttagokra.