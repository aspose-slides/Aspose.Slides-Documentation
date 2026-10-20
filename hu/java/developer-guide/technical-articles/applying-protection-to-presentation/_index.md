---
title: A prezentáció szerkesztésének korlátozása alakzatzárolásokkal Java-ban
linktitle: A prezentáció szerkesztésének korlátozása
type: docs
weight: 60
url: /hu/java/applying-protection-to-presentation/
keywords:
- szerkesztés megelőzése
- védelem a szerkesztéstől
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
description: "Ismerje meg, hogyan zárolhatja és oldhatja fel az alakzatokat PPTX prezentációkban az Aspose.Slides for Java segítségével, hogy korlátozza a kijelölést, mozgást, átméretezést és a csoportosítást."
---
## **Háttér**

Az Aspose.Slides for Java gyakori felhasználása PowerPoint (PPTX) prezentációk létrehozása, frissítése és mentése automatizált munkafolyamat keretében. Amikor a felhasználók megkapják ezeket a prezentációkat, az alakzatok módosításának korlátozása segíthet megőrizni a tervezett elrendezést és tartalmat.

Ez a cikk elmagyarázza, hogyan vannak szervezve az alakzatok a diákon, valamint hogyan lehet alkalmazni és eltávolítani az alakzatzárolásokat egy PPTX prezentációban. Ezek a zárolások lehetővé teszik, hogy egyes alakzatok szerkesztési műveleteit korlátozza.

## **Dia összetétele**

Egy prezentációs dia olyan összetevőkből áll, mint az automatikus alakzatok, táblázatok, OLE objektumok, csoportosított alakzatok, képkockák, videokockák, csatlakozók és egyéb elemek, amelyeket a prezentáció felépítéséhez használnak. Az Aspose.Slides for Java-ban a dia minden eleme egy olyan objektum által van reprezentálva, amely megvalósítja a [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) interfészt, vagy egy olyan osztályból származik, amely ezt teszi.

Különböző alakzat típusok eltérő zárási lehetőségeket kínálnak. A [IBaseShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseshapelock/) interfész az alakzat zárolások alapinterfésze. Az Aspose.Slides for Java a következő zárolási interfészeket biztosítja:

- [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) zárolja az automatikus alakzatokat.  
- [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) zárolja a csatlakozó alakzatokat.  
- [IGraphicalObjectLock](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/) zárolja a grafikus objektumokat.  
- [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) zárolja a csoportos alakzatokat.  
- [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) zárolja a képkockákat.  

Az [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) során a zárolások alkalmazásához iteráljon a diákkal, és állítsa be a megfelelő zárolásokat minden támogatott alakzatra.

## **Védelem alkalmazása és eltávolítása**

Az alakzatzárolások korlátozzák a kijelölés, mozgatás és átméretezés műveleteit. Nem teszik a teljes prezentációt szerkeszthetetlenné.

### **Védelem alkalmazása PPTX alakzatokra**

Az Aspose.Slides for Java biztosítja a [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) interfészt a diámon lévő alakzatok kezeléséhez.

Az példa a [setSelectLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSelectLocked-boolean-) , a [setPositionLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setPositionLocked-boolean-) és a [setSizeLocked](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/#setSizeLocked-boolean-) metódusokat hívja `true` értékkel az automatikus alakzatoknál, illetve a megfelelő zárolásokat a csoportos alakzatok, csatlakozók és képkockák esetén. A csatlakozók a [setPositionMove](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/#setPositionMove-boolean-) metódust használják a mozgáshoz; a csoportok a [setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) metódust is alkalmazzák a csoportosítás korlátozására.

A példa betölt egy meglévő PPTX prezentációt, ellenőrzi az egyes diák alakzatgyűjteményét, és elment egy másolatot a beállított korlátozásokkal. A négy kezelt típuson kívüli alakzatok változatlanul maradnak. A ciklus nem járja be a csoporton belüli gyermekalakzatokat.

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

Az alakzat zárolásának eltávolításához állítsa az értékét `false`-ra. A következő példa betölt egy prezentációt alakzatzárolásokkal, és a [IAutoShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshapelock/) , [IGroupShapeLock](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/) , [IConnectorLock](https://reference.aspose.com/slides/java/com.aspose.slides/iconnectorlock/) valamint [IPictureFrameLock](https://reference.aspose.com/slides/java/com.aspose.slides/ipictureframelock/) segítségével törli a kiválasztás, mozgás és átméretezés korlátozásait. A csoportosítási korlátozást is eltávolítja a `false` érték átadásával az [IGroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshapelock/#setGroupingLocked-boolean-) metódusnak, majd elment egy másolatot a prezentációról. A többi zárolási beállítás változatlan marad.

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

Az Aspose.Slides for Java lehetővé teszi, hogy egyes alakzatok szerkesztési műveleteit korlátozza, vagy ugyanazokat a korlátozásokat alkalmazza a diákkal. Válassza ki az egyes alakzat típusok által támogatott zárolásokat, és állítsa azok értékét `false`-ra, ha el szeretné távolítani a korlátozásokat.

## **FAQ**

**Kombinálhatom a shape lock-okat és a jelszóvédelmet egyetlen prezentációban?**

Igen. A shape lock-ok bizonyos szerkesztési műveleteket korlátoznak, míg a [jelszóvédelem](/slides/hu/java/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettőt használhatja ugyanabban a fájlban.

**Korlátozhatom-e a szerkesztést csak bizonyos diákon, anélkül, hogy a többit érintené?**

Igen. Csak a kiválasztott diák alakzataira alkalmazza a zárolásokat. Ez nem változtatja meg a többi dia zárolási beállításait.

**Hogyan alkalmazhatok zárolásokat egyes alakzatokra egy csoporton belül?**

Iteráljon a csoport [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) metódusa által visszaadott gyűjteményen, és alkalmazza a megfelelő zárolásokat minden gyermek alakzatra. Ismételje meg ezt bármely beágyazott csoport esetén. A fenti példák csak a dia alakzatgyűjteményét dolgozzák fel, így nem állítanak be zárolásokat az egyes csoporttagokra.