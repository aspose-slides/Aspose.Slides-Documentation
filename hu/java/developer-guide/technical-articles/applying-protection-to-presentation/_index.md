---
title: Prezentációs szerkesztések korlátozása alakzatzárakkal Java-ban
linktitle: Prezentációs szerkesztések korlátozása
type: docs
weight: 60
url: /hu/java/applying-protection-to-presentation/
keywords:
- szerkesztés megelőzése
- szerkesztéstől védett
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
description: "Ismerje meg, hogyan zárolhatja és feloldhatja az alakzatokat PPTX prezentációkban az Aspose.Slides for Java használatával, hogy korlátozza a kijelölést, a mozgást, az átméretezést és a csoportosítást."
---
## **Háttér**

Az Aspose.Slides for Java gyakori felhasználása, hogy PowerPoint (PPTX) prezentációkat hozzon létre, frissítsen és mentse egy automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a prezentációkat, az alakzatok módosításának korlátozása segíthet megőrizni a szándékos elrendezést és tartalmat.

Ez a cikk elmagyarázza, hogyan vannak az alakzatok elrendezve a diákon, és hogyan alkalmazhatók és távolíthatók el az alakzatzárak egy PPTX prezentációban. Ezek a zárak lehetővé teszik, hogy meghatározott szerkesztési műveleteket korlátozzunk az egyes alakzatokon.

## **Dia felépítése**

Egy prezentációs dia olyan komponensekből áll, mint az automatikus alakzatok, táblázatok, OLE objektumok, csoportosított alakzatok, képkeretek, videokeretek, összekötők és egyéb elemek, amelyek a prezentáció felépítéséhez szükségesek. Az Aspose.Slides for Java‑ban a dia minden eleme egy olyan objektummal van reprezentálva, amely megvalósítja az [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) interfészt, vagy ebből származó osztályt.

A különböző alakzat típusok különböző zárolási lehetőségeket biztosítanak. Az [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) interfész a alakzatzárak alapeszköze. Az Aspose.Slides for Java a következő zárolási interfészeket biztosítja:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) az automatikus alakzatokat zárolja.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) a csatlakozó alakzatokat zárolja.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) a grafikus objektumokat zárolja.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) a csoportosított alakzatokat zárolja.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) a képkereteket zárolja.  

A [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) során történő zárolások alkalmazásához iteráljon a diákon, és állítsa be a megfelelő zárolásokat az egyes támogatott alakzatokra.

## **Zárolás alkalmazása és eltávolítása**

A kompatibilis prezentációs szerkesztők alakzatzárakat használnak az egyes szerkesztési műveletek korlátozására. A fájl titkosítása és a dokumentumszintű írásvédelem különálló [prezentációvédelmi beállítások](/slides/hu/java/password-protected-presentation/) beállítás.

### **Zárolás alkalmazása PPTX alakzatokra**

Az Aspose.Slides for Java biztosítja az [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) interfészt az alakzatokkal való munkához a diákon.

A példa a [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), a [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) és a [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) metódusokat hívja meg `true` értékkel az automatikus alakzatoknál, illetve megfelelő zárakat a csoportos alakzatoknál, csatlakozóknál és képkereteknél. A csatlakozók a [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) metódust használják a mozgáshoz; a csoportok a [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) metódust is használják a csoportosítás korlátozásához.

A példa betölt egy meglévő PPTX prezentációt, ellenőrzi az egyes diák alakzatgyűjteményét, és elment egy másolatot a beállított korlátozásokkal. A négy kezelt típuson kívüli alakzatok változatlanok maradnak. A ciklus nem járja be a csoporton belüli gyermek alakzatokat.

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

Az alakzatzár eltávolításához állítsa az értékét `false`-ra. A következő példa betölt egy prezentációt alakzatzárakkal, és törli a kijelölés, a mozgatás és az átméretezés korlátozásait az [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) és [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) segítségével. A csoportosítási korlátozást is eltávolítja a `false` értékkel a [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) meghívásával, majd elment egy másolatot a prezentációról. A többi zárolási beállítás változatlan marad.

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

### **Képvágás megőrzése**

Helyezzen egy `photo.jpg` nevű fotót a munkakönyvtárba. A példa 12 %-ot vágt el balról és 8 %-ot jobbról, majd meghívja a [setCropLocked](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) metódust a képkeret zárolásán. A `true` átadása további vágást korlátoz, és megőrzi a meglévő vágást.

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

`PictureLocked.pptx` a vágási zárat `true` értékkel tárolja. PowerPointban a **Crop** (Vágás) parancs le van tiltva, amikor a fotó ki van választva.

### **Diagram csoportosítva tartása**

A példa egy téglalapot és egy nyílt csoportosít, majd meghívja a [setUngroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) metódust a csoport zárolásán, hogy a diagram komponensei együtt maradjanak. Más szerkesztések, például a csoport mozgatása vagy egy komponens kitöltésének módosítása továbbra is elérhetők.

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

`DiagramLocked.pptx` az csoportbontás zárat `true` értékkel tárolja. PowerPointban a **Ungroup** (Csoport bontása) parancs le van tiltva, amikor az egész diagram ki van választva.

### **Meglévő alakzatzárak jelentése**

Egy sablon áttekintéséhez nyissa meg, és olvassa ki minden alakzat zárolási objektumát. A [getNoLocks](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/#getNoLocks--) metódus `true` értéket ad, ha az objektum összes jelzője le van tiltva, és `false`-t, ha legalább egy engedélyezve van. Egy csoport és annak gyermekei külön zárolási objektummal rendelkeznek, ezért vizsgálja meg a gyermekeket is akkor is, ha a csoport nem rendelkezik zárakkal.

Ez a példa az automatikus alakzatok, képkeretek és csoportok mozgását ellenőrzi. Emellett a képek vágását és a csoportok csoportbontását is ellenőrzi. A jelentés felsorolja a felismert engedélyezett jelzőket, és megjelöli azokat az alakzat típusokat, amelyeket nem vizsgál.

```java
import com.aspose.slides.*;
import java.util.StringJoiner;

class ShapeLockReport {
    void inspect(IShapeCollection shapes, int slideNumber, String prefix) {
        for (IShape shape : shapes) {
            String path = prefix + shape.getName();
            String label = "Slide " + slideNumber + " | " + path + " | " + shape.getClass().getSimpleName();
            StringJoiner flags = new StringJoiner(", ");
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
                String restrictions = flags.length() > 0 ? flags.toString() : "Active flag not identified";
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

Tegyük fel, hogy a `Sample.pptx` 1. diája egy `Layout` nevű csoportot tartalmaz, amelynek a csoportbontása zárva van, egy `Photo` nevű képet, amelynek a vágása zárva van, és egy `Free` nevű, záratlan téglalapot. A jelentés kihagyja a `Free` elemet és ezt a két sort írja ki:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

A jelentés a tárolt alakzatszintű szerkesztési jelzőket olvassa el anélkül, hogy módosítaná vagy mentené a prezentációt. A dokumentumszintű írásvédelem egy külön beállítás, és az egyes jelzők érvényesítése a szerkesztőtől függ.

## **Összegzés**

Az Aspose.Slides for Java lehetővé teszi, hogy meghatározott szerkesztési műveleteket korlátozzon az egyes alakzatokon, vagy ugyanazokat a korlátozásokat alkalmazza a diákon. Válassza ki az egyes alakzat típusok által támogatott zárakat, és állítsa értéküket `false`-ra, ha el szeretné távolítani ezeket a korlátozásokat.

## **GYIK**

**Kombinálhatom-e az alakzatzárakat és a jelszóvédelmet ugyanabban a prezentációban?**

Igen. Az alakzatzárak meghatározott szerkesztési műveleteket korlátoznak, míg a [jelszóvédelem](/slides/hu/java/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettőt használhatja ugyanabban a fájlban.

**Korlátozhatom-e a szerkesztést egyes diákon anélkül, hogy a többit befolyásolnám?**

Igen. A zárakat csak a kiválasztott diák alakzataira alkalmazza. Ez nem módosítja a többi dia zárolási beállításait.

**Hogyan alkalmazhatok zárakat az egyes csoporton belüli alakzatokra?**

Iteráljon a csoport [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) metódusa által visszaadott gyűjteményen, és alkalmazza a megfelelő zárakat minden gyermek alakzatra. Ismételje meg ezt minden beágyazott csoport esetén, a jelentési példában bemutatott bejárás szerint.