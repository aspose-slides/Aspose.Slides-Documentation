---
title: Prezentáció szerkesztésének megakadályozása alakzatzárral Pythonban
linktitle: Prezentáció szerkesztésének megakadályozása
type: docs
weight: 70
url: /hu/python-net/applying-protection-to-presentation/
keywords:
- szerkesztések megakadályozása
- védés a szerkesztéstől
- alakzat zárolása
- pozíció zárolása
- kijelölés zárolása
- méret zárolása
- csoportosítás zárolása
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Fedezze fel, hogyan zárolja vagy oldja fel az Aspose.Slides for Python a .NET-en keresztül a PPT, PPTX és ODP fájlokban az alakzatokat, így biztosítva a prezentációk védelmét, miközben szabályozott szerkesztéseket és gyorsabb szállítást tesz lehetővé."
---
## **Háttér**

Az Aspose.Slides gyakori felhasználása a Microsoft PowerPoint (PPTX) prezentációk létrehozása, frissítése és mentése egy automatizált munkafolyamat részeként. Az ilyen módon Aspose.Slides-t használó alkalmazások felhasználói hozzáférnek a generált prezentációkhoz, így a szerkesztés elleni védelem gyakori aggály. Fontos, hogy az automatikusan generált prezentációk megőrizzék eredeti formázásukat és tartalmukat.

Ez a cikk elmagyarázza, hogyan vannak felépítve a prezentációk és diák, valamint hogyan tudja az Aspose.Slides for Python védelmet alkalmazni egy prezentáción, majd később eltávolítani azt. Fejlesztők számára lehetőséget biztosít a generált prezentációk felhasználásának szabályozására.

## **Dia felépítése**

A prezentációs dia olyan összetevőkből áll, mint az automatikus alakzatok, táblázatok, OLE-objektumok, csoportosított alakzatok, képkockák, videókockák, összekötők és egyéb, a prezentáció építéséhez használt elemek. Az Aspose.Slides for Python-ban a dia minden eleme egy objektum által van reprezentálva, amely örökli a [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) osztályt.

A PPTX felépítése összetett, ezért a PPT-től eltérően, ahol egy általános zárat lehet használni minden alakzattípusra, a különböző alakzattípusok eltérő zárakat igényelnek. A [BaseShapeLock](https://reference.aspose.com/slides/hu/python-net/aspose.slides/baseshapelock/) osztály az általános záróosztály a PPTX-hez. Az alábbi záratípusok támogatottak az Aspose.Slides for Python-ban a PPTX-hez:

- [AutoShapeLock](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshapelock/) zárolja az automatikus alakzatokat.  
- [ConnectorLock](https://reference.aspose.com/slides/hu/python-net/aspose.slides/connectorlock/) zárolja a csatlakozó alakzatokat.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/hu/python-net/aspose.slides/graphicalobjectlock/) zárolja a grafikus objektumokat.  
- [GroupShapeLock](https://reference.aspose.com/slides/hu/python-net/aspose.slides/groupshapelock/) zárolja a csoportos alakzatokat.  
- [PictureFrameLock](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframelock/) zárolja a képkockákat.  

Az összes alakzategységen végzett művelet egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) objektumban a teljes prezentációra vonatkozik.

## **Védelem alkalmazása és eltávolítása**

A védelem alkalmazása biztosítja, hogy a prezentációt ne lehessen szerkeszteni. Hasznos technika a prezentáció tartalmának védelmére.

### **Védelem alkalmazása PPTX alakzatokra**

Az Aspose.Slides for Python biztosítja a [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/) osztályt a dia alakzataival való munkához.

Mint korábban említettük, minden alakzat osztályhoz tartozik egy hozzá kapcsolódó shape-lock osztály a védelemhez. Ez a cikk a NoSelect, NoMove és NoResize zárakra összpontosít. Ezek a zárak biztosítják, hogy az alakzatok ne legyenek kiválaszthatók (egérkattintással vagy egyéb kiválasztási módokkal), valamint ne mozgathatók vagy átméretezhetők.

Az alábbi kódrészlet a védelem alkalmazását mutatja minden alakzattípusra egy prezentációban.

```py
import aspose.slides as slides

# Példányosítsa a Presentation osztályt, amely egy PPTX fájlt képvisel.
with slides.Presentation("Sample.pptx") as presentation:
    # Bejárja a prezentáció összes diáját.
    for slide in presentation.slides:
        # Bejárja a dia összes alakzatát.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = True
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = True
                shape.shape_lock.select_locked = True
                shape.shape_lock.size_locked = True
    # Mentse a prezentáció fájlt.
    presentation.save("ProtectedSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Védelem eltávolítása**

Egy alakzat feloldásához állítsa a alkalmazott zár értékét `False`-ra. Az alábbi kódrészlet bemutatja, hogyan lehet feloldani a zárt prezentációban lévő alakzatokat.

```py
import aspose.slides as slides

# Példányosítja a Presentation osztályt, amely egy PPTX fájlt képvisel.
with slides.Presentation("ProtectedSample.pptx") as presentation:
    # Bejárja a prezentáció összes diáját.
    for slide in presentation.slides:
        # Bejárja a dia összes alakzatát.
        for shape in slide.shapes:
            if type(shape) is slides.AutoShape:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.GroupShape:
                shape.shape_lock.grouping_locked = False
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.Connector:
                shape.shape_lock.position_move = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
            elif type(shape) is slides.PictureFrame:
                shape.shape_lock.position_locked = False
                shape.shape_lock.select_locked = False
                shape.shape_lock.size_locked = False
    # Mentse a prezentáció fájlt.
    presentation.save("RemovedProtectionSample.pptx", slides.export.SaveFormat.PPTX)
```

### **Következtetés**

Az Aspose.Slides több lehetőséget kínál a prezentáció alakzatainak védelmére. Zárolhat egyedi alakzatot, vagy végig iterálhat a prezentáció összes alakzatán és mindegyiket lezárhatja, ezáltal hatékonyan biztosítva a teljes fájl védelmét. A védelmet a zár értékének `False`-ra állításával távolíthatja el.

## **GYIK**

**Kombinálhatom a shape lock-ot és a jelszavas védelmet ugyanabban a prezentációban?**

Igen. A zárak korlátozzák a fájlban lévő objektumok szerkesztését, míg a [password protection](/slides/hu/python-net/password-protected-presentation/) szabályozza a megnyitáshoz és/vagy a módosítások mentéséhez való hozzáférést. Ezek a mechanizmusok egymást kiegészítik és együtt működnek.

**Korlátozhatom a szerkesztést bizonyos diákon anélkül, hogy a többit befolyásolnám?**

Igen. Alkalmazzon zárakat a kiválasztott diák alakzataira; a maradék diák szerkeszthetőek maradnak.

**Alkalmazhatók a shape lock-ok csoportosított objektumokra és összekötőkre?**

Igen. Külön dedikált zár típusok támogatottak a csoportokra, összekötőkre, grafikus objektumokra és egyéb alakzatokra.