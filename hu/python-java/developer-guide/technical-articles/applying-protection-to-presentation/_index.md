---
title: Prezentációs szerkesztések korlátozása alakzatzárolásokkal Pythonban
linktitle: Prezentációs szerkesztések korlátozása
type: docs
weight: 60
url: /hu/python-java/applying-protection-to-presentation/
keywords:
- szerkesztés megakadályozása
- szerkesztés elleni védelem
- alakzat zárolása
- pozíció zárolása
- kijelölés zárolása
- átméretezés zárolása
- csoportosítás zárolása
- PowerPoint
- PPTX
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet zárolni és feloldani az alakzatokat PPTX prezentációkban az Aspose.Slides for Python via Java használatával, hogy korlátozzák a kijelölést, mozgatást, átméretezést és csoportosítást."
---
## **Háttér**

Az Aspose.Slides for Python via Java gyakori felhasználása, hogy PowerPoint (PPTX) prezentációkat hozzon létre, frissítsen és mentse egy automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a prezentációkat, a formák módosításának korlátozása segíthet megőrizni a tervezett elrendezést és tartalmat.

Ez a cikk bemutatja, hogyan szerveződnek a formák a diákon, valamint hogyan alkalmazhatók és távolíthatók el a formazárolások egy PPTX prezentációban. Ezek a zárolások lehetővé teszik, hogy egyes formákon adott szerkesztési műveleteket korlátozzon.

## **Dia felépítése**

Egy prezentációs dia olyan összetevőkből áll, mint az automatikus alakzatok, táblázatok, OLE objektumok, csoportosított formák, képkockák, videokockák, csatlakozók és más, a prezentáció építéséhez használt elemek. Az Aspose.Slides for Python via Java-ban a dia minden eleme egy olyan objektum által van reprezentálva, amely a [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) osztályból származik.

A különböző forma típusok különböző zárolási lehetőségeket kínálnak. A [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) osztály a formazárolások alaposztálya. Az Aspose.Slides for Python via Java a következő zárolási osztályokat biztosítja:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) zárolja az automatikus alakzatokat.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) zárolja a csatlakozó formákat.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) zárolja a grafikus objektumokat.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) zárolja a csoportosított formákat.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) zárolja a képkockákat.  

A [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) során történő zárolások alkalmazásához iteráljon a diáknál, és állítsa be a megfelelő zárolásokat minden támogatott formára.

## **Védelem alkalmazása és eltávolítása**

A formazárolások korlátozzák a műveleteket, például a formák kijelölését, mozgatását és átméretezését. Nem teszik a teljes prezentációt szerkeszthetetlenné.

### **Védelem alkalmazása PPTX formákra**

Az Aspose.Slides for Python via Java biztosítja a [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) osztályt a dián lévő formákkal való munkához.

A példa a [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), a [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) és a [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) metódusokat hívja meg `True` értékkel az automatikus alakzatokra, a csoportosított formákra, csatlakozókra és képkockákra vonatkozó megfelelő zárolásokkal. A csatlakozók a [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) metódust használják a mozgatáshoz; a csoportok a [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) metódust is használják a csoportosítás korlátozásához.

A példa betölt egy meglévő PPTX prezentációt, ellenőrzi a formákat minden dia forma gyűjteményében, és elment egy másolatot a beállított korlátozásokkal. A négy kezelt típuson kívüli formák változatlanok maradnak. A ciklus nem járja be a csoporton belüli gyermekformákat.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(True)
                auto_shape_lock.setSelectLocked(True)
                auto_shape_lock.setSizeLocked(True)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(True)
                group_shape_lock.setPositionLocked(True)
                group_shape_lock.setSelectLocked(True)
                group_shape_lock.setSizeLocked(True)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(True)
                connector_shape_lock.setSelectLocked(True)
                connector_shape_lock.setSizeLocked(True)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(True)
                picture_frame_lock.setSelectLocked(True)
                picture_frame_lock.setSizeLocked(True)

    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Védelem eltávolítása**

Egy formazárolás eltávolításához állítsa az értékét `False`-ra. A következő példa betölt egy prezentációt formazárolásokkal, és törli a kijelölés, a mozgatás és az átméretezés korlátozásait a [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), a [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), a [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) és a [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) segítségével. A csoportosítási korlátozást is eltávolítja a [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) `False` értékkel történő átadása után, majd elment egy másolatot a prezentációról. A többi zárolási beállítás változatlan marad.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

presentation = Presentation("ProtectedSample.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                auto_shape_lock = shape.getShapeLock()
                auto_shape_lock.setPositionLocked(False)
                auto_shape_lock.setSelectLocked(False)
                auto_shape_lock.setSizeLocked(False)
            elif isinstance(shape, GroupShape):
                group_shape_lock = shape.getShapeLock()
                group_shape_lock.setGroupingLocked(False)
                group_shape_lock.setPositionLocked(False)
                group_shape_lock.setSelectLocked(False)
                group_shape_lock.setSizeLocked(False)
            elif isinstance(shape, Connector):
                connector_shape_lock = shape.getShapeLock()
                connector_shape_lock.setPositionMove(False)
                connector_shape_lock.setSelectLocked(False)
                connector_shape_lock.setSizeLocked(False)
            elif isinstance(shape, PictureFrame):
                picture_frame_lock = shape.getShapeLock()
                picture_frame_lock.setPositionLocked(False)
                picture_frame_lock.setSelectLocked(False)
                picture_frame_lock.setSizeLocked(False)

    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Összegzés**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy egyes formákon adott szerkesztési műveleteket korlátozzon, vagy ugyanazokat a korlátozásokat alkalmazza a diákon. Válassza ki az egyes forma típusok által támogatott zárolásokat, és állítsa az értéküket `False`-ra, amikor el szeretné távolítani ezeket a korlátozásokat.

## **GYIK**

**Kombinálhatok formazárolásokat és jelszóvédelmet ugyanabban a prezentációban?**  
Igen. A formazárolások adott szerkesztési műveleteket korlátoznak, míg a [jelszóvédelem](/slides/hu/python-java/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettő használható ugyanabban a fájlban.

**Korlátozhatom a szerkesztést bizonyos diákon anélkül, hogy másokra hatásuk lenne?**  
Igen. Csak a kiválasztott diákon található formákra alkalmazzon zárolásokat. Ez nem változtatja meg a többi dia zárolási beállításait.

**Hogyan alkalmazhatok zárolásokat egyes formákra egy csoporton belül?**  
Iteráljon a csoport által visszaadott [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) metódus gyűjteményén, és alkalmazza a megfelelő zárolásokat minden gyermekformára. Ismételje meg ezt a beágyazott csoportok esetén is. A fenti példák csak a dia forma gyűjteményét dolgozzák fel, így nem állítanak be zárolásokat az egyes csoporttagokra.