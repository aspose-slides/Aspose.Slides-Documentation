---
title: Prezentáció szerkesztésének korlátozása formazárolásokkal Pythonban
linktitle: Prezentáció szerkesztésének korlátozása
type: docs
weight: 70
url: /hu/python-net/applying-protection-to-presentation/
keywords:
- szerkesztés megakadályozása
- védelem a szerkesztés ellen
- forma zárolása
- pozíció zárolása
- kiválasztás zárolása
- átméretezés zárolása
- csoportosítás zárolása
- PowerPoint
- PPTX
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan zárolhat és oldhat fel formákat PPTX prezentációkban az Aspose.Slides for Python via .NET segítségével, a kiválasztás, mozgatás, átméretezés és csoportosítás korlátozása érdekében."
---
## **Háttér**

Az Aspose.Slides for Python via .NET gyakori felhasználása automatikus munkafolyamat részeként PowerPoint (PPTX) prezentációk létrehozása, frissítése és mentése. Amikor a felhasználók megkapják ezeket a prezentációkat, a formák módosításának korlátozása segíthet megőrizni a szándékolt elrendezést és tartalmat.

Ez a cikk elmagyarázza, hogyan szerveződnek a formák a diákon, valamint hogyan lehet alkalmazni és eltávolítani a formazárolásokat egy PPTX prezentációban. Ezek a zárolások lehetővé teszik meghatározott szerkesztési műveletek korlátozását egyes formákon.

## **Dia felépítése**

A prezentációs dia olyan összetevőkből áll, mint az autoshape‑ek, táblázatok, OLE‑objektumok, csoportosított formák, képkeretek, videokeretek, összekötők és egyéb elemek, amelyek a prezentáció építéséhez szükségesek. Az Aspose.Slides for Python via .NET‑ben a dia minden eleme egy olyan objektummal van reprezentálva, amely a [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) osztályból származik.

A különböző forma típusok különböző zárolási lehetőségeket kínálnak. A [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) osztály a formazárolások alaposztálya. Az Aspose.Slides for Python via .NET a következő zárolási osztályokat biztosítja:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) zárolja az autoshape‑eket.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) zárolja a connector formákat.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) zárolja a grafikus objektumokat.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) zárolja a csoportosított formákat.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) zárolja a képkereteket.  

A [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) során a zárolások alkalmazásához iterálja végig a diákat, és állítsa be a megfelelő zárolásokat minden támogatott formán.

## **Védelem alkalmazása és eltávolítása**

A kompatibilis prezentációs szerkesztők a formazárolásokat használják egyedi szerkesztési műveletek korlátozására. A fájl titkosítása és a dokumentumszintű írásvédettség külön [prezentációvédelmi beállítások](/slides/hu/python-net/password-protected-presentation/).

### **Védelem alkalmazása PPTX alakzatokra**

Az Aspose.Slides for Python via .NET biztosítja a [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) osztályt a diákon lévő formákkal való munka érdekében.

A példa a [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), a [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) és a [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) beállításait `True`‑ra állítja az autoshape‑eknél, ekvivalens zárolásokat alkalmazva a csoportosított formákra, összekötőkre és képkeretekre. Az összekötők a [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) használatával mozoghatnak; a csoportok pedig a [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) segítségével korlátozzák a csoportosítást.

A példa betölt egy meglévő PPTX prezentációt, ellenőrzi minden dia forma gyűjteményét, és elment egy másolatot a felvitt korlátozásokkal. A négy kezelt típuson kívül eső formákat változatlanul hagyja. A ciklus nem járja be a csoporton belüli gyermekformákat.

```python
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True

    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Védelem eltávolítása**

Egy formazárolás eltávolításához állítsa az értékét `False`‑ra. Az alábbi példa betölt egy formazárolásokat tartalmazó prezentációt, és törli a kiválasztás, mozgatás és átméretezés korlátozásait az [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), a [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), a [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) és a [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) segítségével. Továbbá törli a [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) beállítást, és elment egy másolatot a prezentációból. A többi zárolási beállítás változatlan marad.

```python
import aspose.slides as slides

with slides.Presentation("ProtectedSample.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, slides.AutoShape):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.GroupShape):
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.Connector):
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif isinstance(shape, slides.PictureFrame):
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False

    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Kép kivágásának megőrzése**

Helyezzen egy `photo.jpg` nevű fotót a munkakönyvtárba. A példa 12 %‑ot vág le balról és 8 %‑ot jobbról, majd a [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) beállítást alkalmazza a képkereten, hogy megőrizze a kivágást.

```python
from pathlib import Path

import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes

    photo_bytes = Path("photo.jpg").read_bytes()
    photo = presentation.images.add_image(photo_bytes)

    picture_frame = shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 30, 270, 160, photo)
    picture_frame.picture_format.crop_left = 12
    picture_frame.picture_format.crop_right = 8
    picture_frame.shape_lock.aspect_ratio_locked = False
    picture_frame.shape_lock.crop_locked = True

    presentation.save("PictureLocked.pptx", slides.export.SaveFormat.PPTX)
```

`PictureLocked.pptx` a crop lock értékét `True`‑ként tárolja. PowerPointban a **Crop** parancs le van tiltva, ha a fotó van kijelölve.

### **Diagram csoportos állapotának megtartása**

A példa egy téglalapot és egy nyilat csoportosít, majd a [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) beállítást alkalmazza a csoporton magán, hogy a diagram elemei együtt maradjanak. A további szerkesztések, például a csoport mozgatása vagy egy komponens kitöltésének módosítása továbbra is elérhetők.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    group_shape = shapes.add_group_shape()
    group_shape.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 70, 90, 50)
    group_shape.shapes.add_auto_shape(slides.ShapeType.RIGHT_ARROW, 190, 80, 60, 30)
    group_shape.shape_lock.ungrouping_locked = True

    presentation.save("DiagramLocked.pptx", slides.export.SaveFormat.PPTX)
```

`DiagramLocked.pptx` az ungrouping lock értékét `True`‑ként tárolja. PowerPointban a **Ungroup** parancs le van tiltva, ha a teljes diagram ki van jelölve.

### **Összegzés**

Az Aspose.Slides for Python via .NET lehetővé teszi meghatározott szerkesztési műveletek korlátozását egyedi formákon, vagy ugyanezen korlátozások alkalmazását diákon át. Válassza ki az egyes forma típusok által támogatott zárolásokat, és állítsa értéküket `False`‑ra, ha el szeretné távolítani ezeket a korlátozásokat.

## **GYIK**

**Meg tudom-e kombinálni a forma zárolásokat és a jelszóvédelmet ugyanabban a prezentációban?**

Igen. A formazárolások meghatározott szerkesztési műveleteket korlátoznak, míg a [jelszóvédelem](/slides/hu/python-net/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettő használható ugyanabban a fájlban.

**Korlátozhatom-e a szerkesztést adott diákon anélkül, hogy a többit érinteném?**

Igen. Csak a kiválasztott diák formáira alkalmazzon zárolásokat. Ez nem változtatja meg a többi dia zárolási beállításait.

**Hogyan alkalmazhatok zárolásokat egy csoporton belüli egyedi formákra?**

Iterálja végig a csoport [alakzatok](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) gyűjteményét, és alkalmazza a megfelelő zárolásokat minden gyermekforma esetén. Ismételje meg ezt minden beágyazott csoportnál. A fenti példák csak a dia formagyűjteményét dolgozzák fel, így nem állítanak be zárolásokat az egyedi csoporttagokon.