---
title: Korlátozza a bemutató szerkesztését formázárolásokkal Androidon
linktitle: Korlátozza a bemutató szerkesztését
type: docs
weight: 60
url: /hu/androidjava/applying-protection-to-presentation/
keywords:
- szerkesztések megakadályozása
- védje a szerkesztéstől
- forma zárolása
- pozíció zárolása
- kijelölés zárolása
- átméretezés zárolása
- csoportosítás zárolása
- PowerPoint
- PPTX
- bemutató
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet zárolni és feloldani a formákat PPTX bemutatókban az Aspose.Slides for Android via Java segítségével, hogy korlátozza a kijelölést, mozgatást, átméretezést és csoportosítást."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java gyakori felhasználása, hogy PowerPoint (PPTX) bemutatókat hozzon létre, frissítsen és mentse automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a bemutatókat, a formák módosításának korlátozása segíthet megőrizni a tervezett elrendezést és tartalmat.

Ez a cikk elmagyarázza, hogyan vannak a formák elrendezve a diákon, valamint hogyan alkalmazhatók és távolíthatók el a formazárolások egy PPTX bemutatóban. Ezek a zárolások lehetővé teszik, hogy egyes formákra vonatkozó szerkesztési műveleteket korlátozzunk.

## **Dia összetétele**

Egy bemutató dia komponensekből áll, mint például automatikus alakzatok, táblázatok, OLE objektumok, csoportosított formák, képkockák, videókockák, csatlakozók és egyéb elemek, amelyeket a bemutató építéséhez használnak. Az Aspose.Slides for Android via Java-ban a dia minden eleme egy olyan objektummal van reprezentálva, amely megvalósítja a [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) interfészt, vagy egy olyan osztályból származik, amely megvalósítja.

A különböző formatípusok eltérő zárolási lehetőségeket kínálnak. Az [IBaseShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/) interfész a formazárolások alapinterfésze. Az Aspose.Slides for Android via Java a következő zárolási interfészeket biztosítja:

- [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/) az automatikus alakzatokat zárolja.  
- [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) a csatlakozó alakzatokat zárolja.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) a grafikus objektumokat zárolja.  
- [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/) a csoportos alakzatokat zárolja.  
- [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) a képkockákat zárolja.  

A zárolások alkalmazásához egy [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) során iterálja végig a diákon, és állítsa be a megfelelő zárolásokat minden támogatott formen.

## **Védelem alkalmazása és eltávolítása**

Az kompatibilis bemutató szerkesztők a formazárolásokat használják egyedi szerkesztési műveletek korlátozására. A fájl titkosítása és a dokumentumszintű írásvédelme külön [bemutató védelmi beállításai](/slides/hu/androidjava/password-protected-presentation/).

### **Védelem alkalmazása PPTX formákra**

Az Aspose.Slides for Android via Java biztosítja a [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) interfészt a dián lévő formákkal való munkához.

A példa a [setSelectLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-), a [setPositionLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) és a [setSizeLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) metódusokat hívja `true` értékkel az automatikus alakzatoknál, valamint a csoportos formák, csatlakozók és képkockák esetén az ekvivalens zárolásokat. A csatlakozók a [setPositionMove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) metódust használják a mozgáshoz; a csoportok a [setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) metódust is alkalmazzák a csoportosítás korlátozására.

A példa betölt egy meglévő PPTX bemutatót, ellenőrzi a formákat minden dia forma-gyűjteményében, és egy másolatot ment el a rá alkalmazott korlátozásokkal. A négy kezelt típuson kívüli formák változatlanok maradnak. A ciklus nem járja be a csoporton belüli gyermekformákat.

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

A formazárolás eltávolításához állítsa az értékét `false`-ra. A következő példa betölt egy bemutatót formazárolásokkal, és törli a kijelölés, mozgatás és átméretezés korlátozásait az [IAutoShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshapelock/), [IGroupShapeLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/), [IConnectorLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iconnectorlock/) és [IPictureFrameLock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/) segítségével. A csoportosítási korlátozást is eltávolítja, ha `false`-t ad át az [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) metódusnak, és egy másolatot ment a bemutatóról. A többi zárolási beállítás változatlan marad.

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

### **Kép vágás megőrzése**

Helyezzen el egy `photo.jpg` nevű fényképet a munkakönyvtárban. A példa 12%-ot vág le balról és 8%-ot jobbról, majd meghívja a [setCropLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframelock/#setCropLocked-boolean-) metódust a képkocka zárolásán. `true` átadása tovább korlátozza a vágást és megőrzi a meglévő vágást.

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

`PictureLocked.pptx` a vágászárolást `true` értékkel tárolja. PowerPointban a **Vágás** parancs le van tiltva, amikor a fénykép ki van jelölve.

### **Diagram csoportos állapotának megtartása**

A példa egy négyzetet és egy nyilat csoportosít, majd meghívja a [setUngroupingLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshapelock/#setUngroupingLocked-boolean-) metódust a csoport zárolásán, hogy a diagram elemei együtt maradjanak. Más szerkesztések, például a csoport mozgatása vagy egy komponens kitöltésének módosítása, továbbra is elérhetők.

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

`DiagramLocked.pptx` az ungrouping (csoport felbontása) zárolást `true`-ként tárolja. PowerPointban a **Csoport felbontása** parancs le van tiltva, amikor a teljes diagram ki van jelölve.

### **Meglévő formazárolások jelentése**

Egy sablon áttekintéséhez nyissa meg, és olvassa ki a zárolás objektumot minden formához. A [getNoLocks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseshapelock/#getNoLocks--) metódus `true` értéket ad, ha az objektumon lévő összes jelző ki van kapcsolva, és `false`-t, ha legalább egy engedélyezve van. Egy csoport és annak gyermekei külön zárolási objektumokkal rendelkeznek, ezért vizsgálja meg a gyermekeket akkor is, ha a csoportnak nincs zárolása.

Ez a példa ellenőrzi a mozgást az automatikus alakzatoknál, a képkockáknál és a csoportoknál. Emellett ellenőrzi a képek vágását és a csoportok felbontását. A jelentés felsorolja a felismert engedélyezett jelzőket, és megjelöli azokat a forma típusokat, amelyeket nem ellenőriz.

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

Feltételezzük, hogy a `Sample.pptx` 1. diája egy `Layout` nevű csoportot tartalmaz, amelynek a csoport felbontása zárolva van, egy `Photo` nevű képet, amelynek a vágása zárolva van, és egy `Free` nevű feloldott négyzetet. A jelentés kihagyja a `Free` elemet és ezt a két sort írja ki:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

A jelentés a tárolt forma-szintű szerkesztési jelzőket olvassa ki anélkül, hogy megváltoztatná őket vagy mentené a bemutatót. A dokumentumszintű írásvédelmet külön beállítás jelenti, és az egyes jelzők érvényesítése a szerkesztőtől függ.

## **Következtetés**

Az Aspose.Slides for Android via Java lehetővé teszi, hogy egyes formákra vonatkozó szerkesztési műveleteket korlátozzon, vagy ugyanazokat a korlátozásokat alkalmazza a diákon keresztül. Válassza ki az egyes forma típusok által támogatott zárolásokat, és állítsa értéküket `false`-ra, ha el szeretné távolítani ezeket a korlátozásokat.

## **GYIK**

**Kombinálhatok formazárolásokat és jelszóvédelmet ugyanabban a bemutatóban?**

Igen. A formazárolások bizonyos szerkesztési műveleteket korlátoznak, míg a [jelszóvédelem](/slides/hu/androidjava/password-protected-presentation/) a bemutató megnyitását vagy módosítását korlátozhatja. Mindkettőt használhatja ugyanabban a fájlban.

**Korlátozhatom a szerkesztést egyes diákon anélkül, hogy másokat befolyásolnám?**

Igen. Csak a kiválasztott diákon lévő formákra alkalmazza a zárolásokat. Ez nem módosítja a többi dia zárolási beállításait.

**Hogyan alkalmazhatok zárolásokat egy csoporton belüli egyedi formákra?**

Iterálja végig a csoport [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) metódusa által visszaadott gyűjteményt, és alkalmazza a megfelelő zárolásokat minden gyermekformára. Ismételje meg ezt minden egymásba ágyazott csoportnál, a jelentési példában bemutatott bejárás szerint.