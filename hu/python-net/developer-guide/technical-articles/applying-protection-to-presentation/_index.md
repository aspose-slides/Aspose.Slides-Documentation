---
title: Prezentációs szerkesztések korlátozása alakzatzárolásokkal Pythonban
linktitle: Prezentációs szerkesztések korlátozása
type: docs
weight: 70
url: /hu/python-net/applying-protection-to-presentation/
keywords:
- szerkesztések megakadályozása
- szerkesztés elleni védelem
- alakzat zárolása
- pozíció zárolása
- kiválasztás zárolása
- méretezés zárolása
- csoportosítás zárolása
- PowerPoint
- PPTX
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan lehet zárolni és feloldani alakzatokat PPTX prezentációkban az Aspose.Slides for Python via .NET segítségével, a kiválasztás, mozgás, átméretezés és csoportosítás korlátozásához."
---
## **Háttér**

Az Aspose.Slides for Python via .NET gyakori felhasználása, hogy PowerPoint (PPTX) prezentációkat hozzon létre, frissítsen és mentse egy automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a prezentációkat, az alakzatok módosításának korlátozása segíthet megőrizni a szándékolt elrendezést és tartalmat.

Ez a cikk bemutatja, hogyan vannak rendezve az alakzatok a diákon, valamint hogyan lehet alkalmazni és eltávolítani az alakzatzárolásokat egy PPTX prezentációban. Ezek a zárolások lehetővé teszik, hogy bizonyos szerkesztési műveleteket korlátozzunk egyedi alakzatokon.

## **Dia összetétele**

Egy prezentációs dia olyan összetevőkből áll, mint az autóalakzatok, táblázatok, OLE‑objektumok, csoportosított alakzatok, képkockák, videókockák, csatlakozók és egyéb elemek, amelyekkel a prezentáció felépül. Az Aspose.Slides for Python via .NET‑ben a dián lévő minden elem egy olyan objektummal van reprezentálva, amely a [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) osztályból származik.

A különböző alakzattípusok különféle zárolási beállításokat kínálnak. A [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) osztály az alakzatzárolások alaposztálya. Az Aspose.Slides for Python via .NET a következő zárolási osztályokat biztosítja:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) zárolja az autóalakzatokat.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) zárolja a csatlakozó alakzatokat.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) zárolja a grafikus objektumokat.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) zárolja a csoportos alakzatokat.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) zárolja a képkockákat.  

A zárolások alkalmazásához egy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) esetén iteráljon végig a diákn, és állítsa be a megfelelő zárolásokat az egyes támogatott alakzatokra.

## **Zárolás alkalmazása és eltávolítása**

A kompatibilis prezentációs szerkesztők alakzatzárolásokat használnak bizonyos szerkesztési műveletek korlátozására. A fájl titkosítása és a dokumentumszintű írásvédettség külön [presentation protection settings](/slides/hu/python-net/password-protected-presentation/) beállítás.

### **Zárolás alkalmazása PPTX alakzatokra**

Az Aspose.Slides for Python via .NET biztosítja a [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) osztályt az alakzatok kezeléséhez a dián.

A példa a [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) és [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) tulajdonságokat `True`‑ra állítja az autóalakzatoknál, a csoportos alakzatok, csatlakozók és képkockák esetén ekvivalens zárolásokat alkalmazva. A csatlakozók a [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) használatával mozgathatók; a csoportok a [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) segítségével korlátozzák a csoportosítást.

A példa betölti a meglévő PPTX prezentációt, ellenőrzi az egyes diák alakzatgyűjteményét, és egy olyan másolatot ment, amelyben ezek a korlátozások alkalmazva vannak. A négy kezelt típustól eltérő alakzatok változatlanul maradnak. A ciklus nem járja be a csoporton belüli alalakzatokat.

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

### **Zárolás eltávolítása**

Az alakzatzárolás eltávolításához állítsa értékét `False`‑ra. Az alábbi példa betölt egy zárolt prezentációt, és a [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) és [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) segítségével törli a kiválasztásra, mozgásra és átméretezésre vonatkozó korlátozásokat. Továbbá törli a [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) beállítást, és ment egy másolatot a prezentációból. A többi zárolási beállítás változatlan marad.

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

### **Képvágás megőrzése**

Helyezze a `photo.jpg` nevű fényképet a munkakönyvtárba. A példa a bal oldaltól 12 %-ot, a jobbról 8 %-ot vág le, majd beállítja a [crop_locked](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/crop_locked/) jelzőt a képkockán. Ez a jelző megakadályozza a további vágást és megőrzi a már meglévő vágást.

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

A `PictureLocked.pptx` fájl a vágászárolást `True`‑ként tárolja. PowerPointban a **Crop** parancs le van tiltva, ha a fénykép ki van választva.

### **Diagram csoportosítása megőrzése**

A példa egy téglalapot és egy nyilat csoportosít, majd a csoporton magán a [ungrouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/ungrouping_locked/) beállítást `True`‑ra állítja, hogy a diagram elemei együtt maradjanak. Egyéb szerkesztések, például a csoport mozgatása vagy egy komponens kitöltésének módosítása továbbra is elérhetők.

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

A `DiagramLocked.pptx` fájl az ungrouping zárolást `True`‑ként tárolja. PowerPointban a **Ungroup** parancs le van tiltva, ha a teljes diagram ki van választva.

### **Meglévő alakzatzárolások jelentése**

Egy sablon áttekintéséhez nyissa meg azt, és olvassa ki az egyes alakzatok lock objektumát. A [no_locks](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/no_locks/) `True`, ha az objektum összes jelzője le van tiltva, és `False`, ha legalább egy engedélyezve van. Egy csoport és annak gyermekei külön lock objektummal rendelkeznek, ezért a gyermekeket is ellenőrizni kell, még ha a csoportnak nincs is zárolása.

Ez a példa ellenőrzi a mozgást autóalakzatoknál, képkockáknál és csoportoknál, a vágást képeknél, valamint az ungrouping‑ot csoportoknál. Jelenti az általa felismert jelzőket, és megjelöli azokat az alakzattípusokat, amelyeket nem vizsgál.

```python
import aspose.slides as slides


def inspect_shapes(shapes, slide_number, prefix=""):
    for shape in shapes:
        path = prefix + shape.name
        label = f"Slide {slide_number} | {path} | {type(shape).__name__}"
        if not isinstance(shape, (slides.GroupShape, slides.PictureFrame, slides.AutoShape)):
            print(f"{label} | Uninspected")
            continue

        shape_lock = shape.shape_lock
        if not shape_lock.no_locks:
            flags = []
            if isinstance(shape, slides.GroupShape) and shape_lock.ungrouping_locked:
                flags.append("ungrouping_locked")
            if isinstance(shape, slides.PictureFrame) and shape_lock.crop_locked:
                flags.append("crop_locked")
            if shape_lock.position_locked:
                flags.append("position_locked")
            restrictions = ", ".join(flags) if flags else "Active flag not identified"
            print(f"{label} | {restrictions}")

        if isinstance(shape, slides.GroupShape):
            inspect_shapes(shape.shapes, slide_number, path + "/")


with slides.Presentation("Sample.pptx") as presentation:
    for slide in presentation.slides:
        inspect_shapes(slide.shapes, slide.slide_number)
```

Tegyük fel, hogy a `Sample.pptx` első diáján egy `Layout` nevű csoport található, amelyben az ungrouping zárolt, egy `Photo` nevű kép van benne, amelynek a vágás zárolt, és egy `Free` nevű, zárolás nélküli téglalap. A jelentés kihagyja a `Free` elemet, és a következő két sort írja ki:

```text
Slide 1 | Layout | GroupShape | ungrouping_locked
Slide 1 | Layout/Photo | PictureFrame | crop_locked
```

A jelentés a tárolt alakzatszintű szerkesztési jelzőket olvassa ki anélkül, hogy módosítaná vagy mentené a prezentációt. A dokumentumszintű írásvédettség egy külön beállítás, és minden jelző érvényesítését a szerkesztő határozza meg.

### **Összegzés**

Az Aspose.Slides for Python via .NET lehetővé teszi, hogy egyedi alakzatokon konkrét szerkesztési műveleteket korlátozzunk, vagy ugyanazokat a korlátozásokat több diára alkalmazzuk. Válassza ki az egyes alakzattípusok által támogatott zárolásokat, és állítsa értéküket `False`‑ra, amikor el kell távolítani ezeket a korlátozásokat.

## **GYIK**

**Összekapcsolhatom a shape lock‑okat jelszóvédettséggel ugyanabban a prezentációban?**

Igen. A shape lock‑ok bizonyos szerkesztési műveleteket korlátoznak, míg a [password protection](/slides/hu/python-net/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettőt használhatja egy fájlban.

**Korlátozhatom a szerkesztést csak bizonyos diákon anélkül, hogy a többit érinteném?**

Igen. A zárolásokat csak a kiválasztott diák alakzatain alkalmazza. Ez nem változtatja meg a többi dia zárolási beállításait.

**Hogyan alkalmazhatok zárolásokat egyedi alakzatokra egy csoporton belül?**

Iteráljon végig a csoport [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) gyűjteményén, és alkalmazza a megfelelő zárolásokat minden gyermek alakzatra. Ismételje meg a folyamatot minden beágyazott csoportra a jelentési példában bemutatott bejárás szerint.