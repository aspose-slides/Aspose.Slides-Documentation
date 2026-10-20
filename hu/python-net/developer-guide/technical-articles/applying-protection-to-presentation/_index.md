---
title: Prezentáció szerkesztésének korlátozása formazárolással Pythonban
linktitle: Prezentáció szerkesztésének korlátozása
type: docs
weight: 70
url: /hu/python-net/applying-protection-to-presentation/
keywords:
- szerkesztés megelőzése
- szerkesztéstől védelem
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
description: "Ismerje meg, hogyan zárolhat és feloldhat alakzatokat PPTX prezentációkban az Aspose.Slides for Python via .NET segítségével, hogy korlátozza a kiválasztást, mozgást, átméretezést és a csoportosítást."
---
## **Háttér**

Az Aspose.Slides for Python via .NET gyakori felhasználása PowerPoint (PPTX) prezentációk létrehozása, frissítése és mentése egy automatizált munkafolyamat részeként. Amikor a felhasználók megkapják ezeket a prezentációkat, a formák módosításának korlátozása segíthet megőrizni a tervezett elrendezést és tartalmat.

Ez a cikk bemutatja, hogyan szerveződnek a formák a diákon, valamint hogyan lehet alkalmazni és eltávolítani a formazárakat egy PPTX prezentációban. Ezek az zárolások lehetővé teszik, hogy egyedi formákra vonatkozó specifikus szerkesztési műveleteket korlátozzunk.

## **Dia összetétele**

Egy prezentációs dia olyan összetevőkből áll, mint az automatikus alakzatok, táblázatok, OLE objektumok, csoportosított formák, képkockák, videókockák, összekötő elemek és egyéb elemek, amelyek a prezentáció felépítéséhez szükségesek. Az Aspose.Slides for Python via .NET-ben a dia minden eleme egy objektummal van ábrázolva, amely a [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) osztályból örököl.

A különböző forma típusok különböző zárolási lehetőségeket biztosítanak. A [BaseShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/baseshapelock/) osztály a formazárak alaposztálya. Az Aspose.Slides for Python via .NET a következő zárolási osztályokat kínálja:

- [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/) az automatikus alakzatokat zárolja.  
- [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) az összekötő alakzatokat zárolja.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/) a grafikus objektumokat zárolja.  
- [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/) a csoportosított formákat zárolja.  
- [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) a képkockákat zárolja.  

A zárolások alkalmazásához egy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) esetén iteráljon a diáikon, és állítsa be a megfelelő zárolásokat minden támogatott formára.

## **Védelem alkalmazása és eltávolítása**

A formazárak korlátozzák az olyan műveleteket, mint a formák kiválasztása, áthelyezése és átméretezése. Nem teszik a teljes prezentációt szerkeszthetetlenné.

### **Védelem alkalmazása PPTX formákra**

Az Aspose.Slides for Python via .NET biztosítja a [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) osztályt a dia formáival való munkához.

A példa a [select_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/select_locked/), a [position_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/position_locked/) és a [size_locked](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/size_locked/) tulajdonságokat `True`‑ra állítja az automatikus alakzatok esetén, a csoportosított formákra, összekötőkre és képkockákra ekvivalens zárolásokkal. Az összekötők a [position_move](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/position_move/) használatával mozgathatók; a csoportok a [grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) segítségével korlátozzák a csoportosítást.

A példa betölt egy meglévő PPTX prezentációt, ellenőrzi a formákat minden dia forma gyűjteményében, majd egy ilyen korlátozásokkal ellátott másolatot ment. A négy kezelt típuson kívüli formák változatlanul maradnak. A ciklus nem járja be a csoporton belüli gyermekformákat.

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

A formazár eltávolításához állítsa az értékét `False`‑ra. Az alábbi példa egy formazárral ellátott prezentációt tölt be, és a [AutoShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/autoshapelock/), a [GroupShapeLock](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/), a [ConnectorLock](https://reference.aspose.com/slides/python-net/aspose.slides/connectorlock/) és a [PictureFrameLock](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframelock/) segítségével törli a kiválasztás, mozgás és átméretezés korlátozásait. Ezenkívül törli a [GroupShapeLock.grouping_locked](https://reference.aspose.com/slides/python-net/aspose.slides/groupshapelock/grouping_locked/) beállítást, és elment egy másolatot a prezentációról. A többi zárolási beállítás változatlan marad.

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

### **Összegzés**

Az Aspose.Slides for Python via .NET lehetővé teszi, hogy egyedi formákra vonatkozó specifikus szerkesztési műveleteket korlátozzon, vagy ugyanazokat a korlátozásokat alkalmazza a diákon át. Válassza ki az egyes forma típusok által támogatott zárolásokat, és állítsa azok értékét `False`‑ra, amikor el kell távolítania ezeket a korlátozásokat.

## **GYIK**

**Kombinálhatok formazárakat és jelszóvédelmet ugyanabban a prezentációban?**

Igen. A formazárak specifikus szerkesztési műveleteket korlátoznak, míg a [jelszóvédelem](/slides/hu/python-net/password-protected-presentation/) korlátozhatja a prezentáció megnyitását vagy módosítását. Mindkettőt használhatja ugyanabban a fájlban.

**Korlátozhatom a szerkesztést adott diákon anélkül, hogy másokra hatással lenne?**

Igen. Csak a kiválasztott diák formáira alkalmazzon zárolásokat. Ez nem változtatja meg a többi dia zárolási beállításait.

**Hogyan alkalmazhatok zárolásokat egyes formákra egy csoporton belül?**

Iteráljon a csoport [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/groupshape/shapes/) gyűjteményén, és alkalmazza a megfelelő zárolásokat minden gyermekformára. Ismételje meg minden beágyazott csoport esetén. A fenti példák csak a dia forma gyűjteményét dolgozzák fel, így nem állítanak be zárolásokat az egyes csoporttagokra.