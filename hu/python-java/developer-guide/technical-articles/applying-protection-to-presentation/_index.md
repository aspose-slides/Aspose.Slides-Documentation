---
title: Bemutató szerkesztésének korlátozása alakzatzárolásokkal Pythonban
linktitle: Bemutató szerkesztésének korlátozása
type: docs
weight: 60
url: /hu/python-java/applying-protection-to-presentation/
keywords:
- szerkesztés megakadályozása
- védelem a szerkesztés ellen
- alakzat zárolása
- pozíció zárolása
- kijelölés zárolása
- méretezés zárolása
- csoportosítás zárolása
- PowerPoint
- PPTX
- bemutató
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet zárolni és feloldani az alakzatokat PPTX bemutatókban az Aspose.Slides for Python via Java segítségével, a kijelölés, mozgás, méretezés és csoportosítás korlátozása céljából."
---
## **Háttér**

Az Aspose.Slides for Python via Java gyakori felhasználása a PowerPoint (PPTX) bemutatók létrehozása, frissítése és mentése egy automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a bemutatókat, az alakzatok módosításának korlátozása segíthet megőrizni a kívánt elrendezést és a tartalmat.

Ez a cikk elmagyarázza, hogyan vannak az alakzatok elrendezve a diákon, és hogyan lehet alakzatzárolásokat alkalmazni és eltávolítani egy PPTX bemutatóban. Ezek a zárak lehetővé teszik, hogy konkrét szerkesztési műveleteket korlátozzunk egyedi alakzatoknál.

## **Dia összetétele**

Egy prezentációs dia olyan összetevőkből áll, mint az automatikus alakzatok, táblázatok, OLE objektumok, csoportosított alakzatok, képkockák, videokockák, csatlakozók és egyéb elemek, amelyeket a bemutató felépítéséhez használnak. Az Aspose.Slides for Python via Java-ban a dia minden eleme egy olyan objektummal van reprezentálva, amely a [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) osztályból származik.

Különböző alakzat típusok különböző zárolási lehetőségeket kínálnak. A [BaseShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/baseshapelock/) osztály az alakzatzárolások alaposztálya. Az Aspose.Slides for Python via Java a következő zárolási osztályokat biztosítja:

- [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/) locks autoshapes. zárolja az automatikus alakzatokat.  
- [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) locks connector shapes. zárolja a csatlakozó alakzatokat.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-java/aspose.slides/graphicalobjectlock/) locks graphical objects. zárolja a grafikus objektumokat.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/) locks group shapes. zárolja a csoportosított alakzatokat.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) locks picture frames. zárolja a képkockákat.  

A zárolások alkalmazásához egy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) összes diáján iteráljunk végig, és állítsuk be a megfelelő zárolásokat minden támogatott alakzatra.

## **Védelem alkalmazása és eltávolítása**

A kompatibilis prezentációs szerkesztők alakzatzárolásokat használnak az egyedi szerkesztési műveletek korlátozására. A fájl titkosítása és a dokumentumszintű írásvédelem külön [presentation protection settings](/slides/hu/python-java/password-protected-presentation/) beállítás.

### **Védelem alkalmazása PPTX alakzatokra**

Az Aspose.Slides for Python via Java biztosítja a [Shape](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) osztályt az alkatzatokkal való munkához egy dián.

A példa meghívja a [setSelectLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSelectLocked), a [setPositionLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setPositionLocked) és a [setSizeLocked](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/#setSizeLocked) metódusokat `True` értékkel az automatikus alakzatoknál, és az ekvivalens zárakat a csoportosított alakzatoknál, a csatlakozóknál és a képkockáknál. A csatlakozók a [setPositionMove](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/#setPositionMove) metódust használják a mozgatáshoz; a csoportok pedig a [setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) metódust a csoportosítás korlátozására.

A példa betölt egy meglévő PPTX prezentációt, ellenőrzi a diák alakzatgyűjteményét, és egy másolatot ment a felvitt korlátozásokkal. Az négy kezelt típuson kívüli alakzatok változatlanul maradnak. A ciklus nem jár bele a csoporton belüli gyermek alakzatokba.

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

Egy alakzatzárolás eltávolításához állítsa az értékét `False`-ra. A következő példa betölt egy prezentációt alakzatzárolásokkal, és törli a kiválasztási, mozgási és átméretezési korlátozásokat az [AutoShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/autoshapelock/), a [GroupShapeLock](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/), a [ConnectorLock](https://reference.aspose.com/slides/python-java/aspose.slides/connectorlock/) és a [PictureFrameLock](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/) segítségével. A csoportosítási korlátozást is eltávolítja a `False` átadásával a [GroupShapeLock.setGroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setGroupingLocked) metódusnak, majd egy másolatot ment a prezentációról. A többi zárbeállítás változatlan marad.

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

### **Képkivágás megőrzése**

Helyezzen el egy `photo.jpg` nevű fényképet a munkakönyvtárban. A példa 12%-ot vág le balról és 8%-ot jobbról, majd meghívja a [setCropLocked](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframelock/#setCropLocked) metódust `True` értékkel a kivágás megőrzéséhez.

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

A `PictureLocked.pptx` fájlban a PowerPoint letiltja a **Crop** parancsot, amikor kiválasztja a fényképet.

### **Diagram csoportosítva tartása**

A példa egy téglalapot és egy nyilat csoportosít, majd meghívja a [setUngroupingLocked](https://reference.aspose.com/slides/python-java/aspose.slides/groupshapelock/#setUngroupingLocked) metódust `True` értékkel, hogy a két alakzat együtt maradjon. A csoportot még mindig mozgathatja, vagy megváltoztathatja egy komponens kitöltését.

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

A `DiagramLocked.pptx` fájlban a PowerPoint letiltja a **Ungroup** parancsot, amikor az egész diagramot kiválasztja.

### **Összegzés**

Az Aspose.Slides for Python via Java lehetővé teszi, hogy konkrét szerkesztési műveleteket korlátozzon egyedi alakzatoknál, vagy ugyanazokat a korlátozásokat több diára is alkalmazza. Válassza ki az egyes alakzattípusok által támogatott zárolásokat, és állítsa értéküket `False`-ra, amikor el akarja távolítani ezeket a korlátozásokat.

## **GYIK**

**Kombinálhatok alakzatzárolásokat és jelszóvédelmet ugyanabban a prezentációban?**

Igen. Az alakzatzárolások konkrét szerkesztési műveleteket korlátoznak, míg a [jelszóvédelem](/slides/hu/python-java/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettőt használhatja ugyanabban a fájlban.

**Korlátozhatom-e a szerkesztést egyes diákon anélkül, hogy a többi dia érintve lenne?**

Igen. Alkalmazzon zárakat csak a kiválasztott diákon lévő alakzatokra. Ez nem változtatja meg a többi dia zárbeállításait.

**Hogyan alkalmazhatok zárakat egy csoporton belüli egyedi alakzatokra?**

Iteráljon a csoport [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) metódusával visszaadott gyűjteményen, és alkalmazza a megfelelő zárakat minden gyermek alakzatra. Ismételje meg ezt minden beágyazott csoportra. A fenti példák csak a dia alakzatgyűjteményét dolgozzák fel, ezért nem állítanak be zárakat az egyedi csoporttagokra.