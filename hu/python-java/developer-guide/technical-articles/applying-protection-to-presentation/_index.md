---
title: Megakadályozza a prezentáció szerkesztését alakzatzárakkal
linktitle: Prezentáció szerkesztésének megakadályozása
type: docs
weight: 60
url: /hu/python-java/applying-protection-to-presentation/
keywords:
- szerkesztés megakadályozása
- szerkesztés elleni védelem
- alakzat zárolása
- pozíció zárolása
- kijelölés zárolása
- méret zárolása
- csoportosítás zárolása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan zárolja vagy oldja fel az Aspose.Slides for Python via Java az alakzatokat PPT, PPTX és ODP fájlokban, ezzel védve a prezentációkat, miközben ellenőrzött szerkesztéseket és gyorsabb szállítást tesz lehetővé."
---
## **Háttér**

Az Aspose.Slides gyakori felhasználása Microsoft PowerPoint (PPTX) prezentációk létrehozása, frissítése és mentése automatizált munkafolyamat részeként. Azoknak az alkalmazásoknak a felhasználói, amelyek ilyen módon használják az Aspose.Slides‑t, hozzáférnek a generált prezentációkhoz, ezért a szerkesztés elleni védelem gyakori aggály. Fontos, hogy az automatikusan létrehozott prezentációk megőrizzék az eredeti formázásukat és tartalmukat.

Ez a cikk elmagyarázza, hogyan vannak felépítve a prezentációk és diák, valamint hogyan alkalmazhat védelem egy prezentációra az Aspose.Slides for Python via Java, és hogyan távolítható el később. A fejlesztők számára lehetőséget biztosít arra, hogy szabályozzák, hogyan használják az alkalmazásaik által generált prezentációkat.

## **Dia összetétele**

Egy prezentációs diát alkotó elemek közé tartoznak az automatikus alakzatok, táblázatok, OLE objektumok, csoportos alakzatok, képkeretek, videókeretek, csatlakozók és egyéb, a prezentáció építéséhez használt elemek. Az Aspose.Slides for Python via Java esetén a dia minden elemét egy olyan objektum képviseli, amely a [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) osztályból származik.

A PPTX struktúrája összetett, ezért a PPT-vel ellentétben, ahol általános zárat lehet használni minden alakzattípusra, a különböző alakzatfajták különféle zárakat igényelnek. A [BaseShapeLock](https://reference.aspose.com/slides/hu/python-java/aspose.slides/baseshapelock/) osztály az általános záróosztály a PPTX számára. Az alábbi zártípusok támogatottak az Aspose.Slides for Python via Java-ban a PPTX-hez:

- [AutoShapeLock](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshapelock/) zárja az automatikus alakzatokat.  
- [ConnectorLock](https://reference.aspose.com/slides/hu/python-java/aspose.slides/connectorlock/) zárja a csatlakozó alakzatokat.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/hu/python-java/aspose.slides/graphicalobjectlock/) zárja a grafikus objektumokat.  
- [GroupShapeLock](https://reference.aspose.com/slides/hu/python-java/aspose.slides/groupshapelock/) zárja a csoportos alakzatokat.  
- [PictureFrameLock](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pictureframelock/) zárja a képkockákat.  

Az [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) objektumban végzett bármely művelet, amely az összes alakzaton történik, a teljes prezentációra vonatkozik.

## **Védelem alkalmazása és eltávolítása**

A védelem alkalmazása biztosítja, hogy a prezentációt ne lehessen szerkeszteni. Hasznos technika a prezentáció tartalmának védelmére.

### **Védelem alkalmazása PPTX alakzatokra**

Az Aspose.Slides for Python via Java biztosítja a [Shape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/) osztályt a dián lévő alakzatok kezeléséhez.

Ahogy korábban említettük, minden alakzat osztályhoz tartozik egy megfelelő alakzat-zár osztály a védelemhez. Ez a cikk a NoSelect, NoMove és NoResize zárakra koncentrál. Ezek a zárak biztosítják, hogy az alakzatok ne legyenek kiválaszthatók (egérkattintással vagy egyéb kiválasztási módszerekkel), és ne mozgathatók vagy méretezhetők.

Az alábbi kódrészlet védelem alkalmazását mutatja be minden alakzattípusra egy prezentációban.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# A Presentation osztály példányosítása, amely egy PPTX fájlt képvisel.
presentation = Presentation("Sample.pptx")
try:
    # A prezentáció összes diájának bejárása.
    for slide in presentation.getSlides():
        # A dián lévő összes alakzat bejárása.
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

    # A prezentáció fájl mentése.
    presentation.save("ProtectedSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Védelem eltávolítása**

Egy alakzat feloldásához állítsa a beállított zár értékét `False`-ra. Az alábbi kódrészlet bemutatja, hogyan oldható fel a zár egy lezárt prezentációban lévő alakzatok.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Connector, GroupShape, PictureFrame, Presentation, SaveFormat

# Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel.
presentation = Presentation("ProtectedSample.pptx")
try:
    # A prezentáció összes diájának bejárása.
    for slide in presentation.getSlides():
        # A dián lévő összes alakzat bejárása.
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

    # A prezentáció fájl mentése.
    presentation.save("RemovedProtectionSample.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Következtetés**

Az Aspose.Slides több lehetőséget kínál a prezentációban lévő alakzatok védelmére. Lezárhat egyetlen alakzatot, vagy végigiterálhat az összes alakzaton a prezentációban, és mindegyiket lezárhatja, így hatékonyan biztosítva a teljes fájl védelmét. A védelmet úgy távolíthatja el, hogy a zár értékét `False`-ra állítja.

## **GYIK**

**Kombinálhatok alakzatzárakat és jelszóvédelmet ugyanabban a prezentációban?**

Igen. A zárak korlátozzák a fájlon belüli objektumok szerkesztését, míg a [jelszóvédelem](/slides/hu/python-java/password-protected-presentation/) a megnyitási és/vagy mentési hozzáférést szabályozza. Ezek a mechanizmusok kiegészítik egymást és együtt működnek.

**Korlátozhatom a szerkesztést bizonyos diákon anélkül, hogy másokra hatással lenne?**

Igen. Alkalmazzon zárakat a kiválasztott diákon lévő alakzatokra; a többi dia szerkeszthető marad.

**Az alakzatzárak vonatkoznak a csoportos objektumokra és csatlakozókra?**

Igen. Külön zár típusok támogatottak a csoportokra, csatlakozókra, grafikus objektumokra és egyéb alakzatfajtákra.