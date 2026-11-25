---
title: A prezentáció szerkesztésének korlátozása alakzatzárolásokkal Pythonban
linktitle: Prezentáció szerkesztésének korlátozása
type: docs
weight: 60
url: /hu/python-java/applying-protection-to-presentation/
keywords:
- szerkesztés megakadályozása
- szerkesztés elleni védelem
- alakzat zárolása
- pozíció zárolása
- kijelölés zárolása
- méretezés zárolása
- csoportosítás zárolása
- PowerPoint
- PPTX
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet zárolni és feloldani az alakzatokat PPTX prezentációkban az Aspose.Slides for Python via Java segítségével, hogy korlátozza a kijelölést, mozgást, méretezést és csoportosítást."
---
## **Háttér**

Az Aspose.Slides for Python via Java gyakori felhasználása a PowerPoint (PPTX) bemutatók létrehozása, frissítése és mentése egy automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a prezentációkat, a alakzatok módosításának korlátozása segíthet megőrizni a tervezett elrendezést és tartalmat.

Ez a cikk elmagyarázza, hogyan vannak szervezve az alakzatok a diákon, valamint hogyan lehet alkalmazni és eltávolítani az alakzatok zárolását egy PPTX prezentációban. Ezek a zárolások lehetővé teszik, hogy korlátozzuk a konkrét szerkesztési műveleteket egyedi alakzatokon.

## **Dia összetétele**

Egy prezentációs dia olyan összetevőkből áll, mint az autoshape-ek, táblázatok, OLE-objektumok, csoportosított alakzatok, képkockák, videokockák, összekötők és más elemek, amelyek a prezentáció felépítéséhez szükségesek. Az Aspose.Slides for Python via Java esetén a dia minden eleme egy olyan objektummal van képviselve, amely a [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) osztályból származik.

Különböző alakzattípusok más‑más zárolási lehetőségeket kínálnak. A [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) osztály a shape zárolások alaposztálya. Az Aspose.Slides for Python via Java a következő zárolási osztályokat biztosítja:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) lezárja az autoshape-eket.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) lezárja a connector alakzatokat.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) lezárja a grafikus objektumokat.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) lezárja a csoportosított alakzatokat.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) lezárja a képkockákat.  

A zárolások alkalmazásához egy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) esetén iteráljon a diákon, és állítsa be a megfelelő zárolásokat minden támogatott alakzatra.

## **Alkalmazás és eltávolítás védelem**

A kompatibilis prezentációs szerkesztők alakzatzárolásokat használnak az egyedi szerkesztési műveletek korlátozására. A fájl titkosítása és a dokumentumszintű írásvédelem külön [presentation protection settings](/slides/hu/python-java/password-protected-presentation/) részek.

### **Védelem alkalmazása PPTX alakzatokra**

Az Aspose.Slides for Python via Java a [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) osztályt biztosítja az alakzatok kezeléséhez egy dián.

A példa meghívja a [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), a [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) és a [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) metódusokat `True` értékkel az autoshape-ekhez, valamint a megfelelő zárolásokat a csoportosított alakzatokhoz, connector-okhoz és képkockákhoz. A connector-ok a [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) metódust használják a mozgatáshoz; a csoportok pedig a [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) metódust a csoportosítás korlátozásához.

A példa betölt egy meglévő PPTX prezentációt, ellenőrzi az egyes diák shape gyűjteményében található alakzatokat, és egy másolatot ment el a felvett korlátozásokkal. A négy kezelési típuson kívül lévő alakzatok változatlanul maradnak. A ciklus nem járja be a csoporton belüli gyerekalakzatokat.

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

A shape zárolás eltávolításához állítsa az értékét `False`‑ra. Az alábbi példa egy olyan prezentációt tölt be, amelyben shape zárolások vannak, és törli a kijelölés, mozgás és átméretezés korlátozásait az [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) és [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) segítségével. A csoportosítás korlátozását is eltávolítja azzal, hogy `False`‑t ad át a [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) metódusnak, majd egy másolatot ment a prezentációból. A többi zárolási beállítás változatlan marad.

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

### **Képvágás megőrzése**

Helyezzen egy `photo.jpg` nevű fotót a munkakönyvtárba. A példa 12 % -ot vág le balról és 8 % -ot jobbról, majd a [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) metódust hívja `True` értékkel a vágás megőrzéséhez.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.getImages().addImage(photo_bytes)
    
    picture_frame = shapes.addPictureFrame(ShapeType.Rectangle, 20, 30, 270, 160, photo)
    picture_frame.getPictureFormat().setCropLeft(12)
    picture_frame.getPictureFormat().setCropRight(8)

    picture_lock = picture_frame.getPictureFrameLock()
    picture_lock.setAspectRatioLocked(False)
    picture_lock.setCropLocked(True)

    presentation.save("PictureLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A `PictureLocked.pptx` esetén a PowerPoint letiltja a **Crop** parancsot, amikor a képet kijelöli.

### **Diagram csoportosítva tartása**

A példa egy téglalapot és egy nyilat csoportosít, majd a [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) metódust hívja `True` értékkel, hogy a két alakzat együtt maradjon. A csoportot továbbra is mozgathatja, vagy módosíthatja egy komponens kitöltését.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()

    group = shapes.addGroupShape()
    group.getShapes().addAutoShape(ShapeType.Rectangle, 100, 70, 90, 50)
    group.getShapes().addAutoShape(ShapeType.RightArrow, 190, 80, 60, 30)
    group.getGroupShapeLock().setUngroupingLocked(True)

    presentation.save("DiagramLocked.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A `DiagramLocked.pptx` esetén a PowerPoint letiltja a **Ungroup** parancsot, amikor a teljes diagramot kijelöli.

### **Meglévő shape zárolások jelentése**

Egy sablon áttekintéséhez nyissa meg, és olvassa ki a lock objektumot minden alakzatra. A [getNoLocks](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/#getNoLocks) metódus `True`‑t ad vissza, ha az objektum összes zászlója le van tiltva, és `False`‑t, ha legalább egy engedélyezve van. Egy csoport és annak gyerekei külön lock objektummal rendelkeznek, ezért a gyerekeket is vizsgálja, még akkor is, ha a csoportnak nincsenek zárolásai.

Ez a példa ellenőrzi a mozgást autoshape-eken, képkockákon és csoportokon. Emellett ellenőrzi a képek vágását és a csoportok felbontását. A jelentés felsorolja az általa felismert engedélyezett zászlókat, és megjelöli azokat a shape típusokat, amelyeket nem vizsgál.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, GroupShape, PictureFrame, Presentation


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = f"{prefix}{shape.getName()}"
        label = f"Slide {slide_number} | {path} | {shape.getClass().getSimpleName()}"
        flags = []

        if isinstance(shape, GroupShape):
            shape_lock = shape.getGroupShapeLock()
            if shape_lock.getUngroupingLocked():
                flags.append("UngroupingLocked")
        elif isinstance(shape, PictureFrame):
            shape_lock = shape.getPictureFrameLock()
            if shape_lock.getCropLocked():
                flags.append("CropLocked")
        elif isinstance(shape, AutoShape):
            shape_lock = shape.getAutoShapeLock()
        else:
            print(f"{label} | Uninspected")
            continue

        if shape_lock.getPositionLocked():
            flags.append("PositionLocked")
        if not shape_lock.getNoLocks():
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, GroupShape):
            inspect_shapes(shape.getShapes(), slide_number, f"{path}/")


presentation = Presentation("Sample.pptx")
try:
    for slide in presentation.getSlides():
        inspect_shapes(slide.getShapes(), slide.getSlideNumber())
finally:
    presentation.dispose()
```

Tegyük fel, hogy a `Sample.pptx` első diáján van egy `Layout` nevű csoport, amelynek a felbontása le van tiltva, a csoporton belül egy `Photo` nevű kép, amelynek a vágása le van tiltva, valamint egy `Free` nevű feloldott téglalap. A jelentés kihagyja a `Free` elemet, és ezt a két sort nyomtatja:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

A jelentés a tárolt shape‑szintű szerkesztési zászlókat olvassa el módosítás vagy mentés nélkül. A dokumentumszintű írásvédelem egy külön beállítás, és minden zászló érvényesítése a szerkesztőtől függ.

### **Összegzés**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy korlátozza a konkrét szerkesztési műveleteket egyedi alakzatokon, vagy ugyanazokat a korlátozásokat alkalmazza több diára. Válassza ki az egyes shape típusok által támogatott zárolásokat, és állítsa értéküket `False`‑ra, ha el szeretné távolítani a korlátozásokat.

## **GYIK**

**Összekapcsolhatom a shape zárolásokat és a jelszóvédelmet ugyanabban a prezentációban?**

Igen. A shape zárolások a konkrét szerkesztési műveleteket korlátozzák, míg a [password protection](/slides/hu/python-java/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettő használható egy fájlban.

**Korlátozhatom a szerkesztést csak bizonyos diákon anélkül, hogy a többit befolyásolnám?**

Igen. Alkalmazza a zárolásokat csak a kiválasztott diák alakzataira. Ez nem módosítja a többi dia lock beállításait.

**Hogyan alkalmazhatok zárolásokat egy csoporton belüli egyedi alakzatokra?**

Iteráljon a csoport [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) metódusa által visszaadott gyűjteményen, és alkalmazza a megfelelő zárolásokat minden gyermek alakzatra. Ismételje meg ezt minden beágyazott csoport esetén, a jelentési példában bemutatott bejárás szerint.