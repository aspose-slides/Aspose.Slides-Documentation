---
title: Prezentációk létrehozása Pythonban
linktitle: Prezentáció létrehozása
type: docs
weight: 10
url: /hu/python-net/create-presentation/
keywords:
- prezentáció létrehozása
- új prezentáció
- PPT létrehozása
- új PPT
- PPTX létrehozása
- új PPTX
- ODP létrehozása
- új ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Prezentációk (PowerPoint) létrehozása Pythonban az Aspose.Slides segítségével – PPT, PPTX és ODP fájlok előállítása, OpenDocument támogatás kihasználása, és programozott mentés megbízható eredményekért."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhatunk létre egy prezentációt az Aspose.Slides for Python via .NET segítségével, hogyan adhatunk hozzá egy szöveges alakzatot az első diára, és hogyan menthetjük el az eredményt PPTX fájlként. Ugyanaz az API PPT és ODP formátumba is képes menteni a prezentációkat, így egy kódbázisból célozhatunk a PowerPoint és az OpenDocument formátumokra is, Microsoft Office nélkül. A végén egy rövid GYIK tárgyalja a formátumokra, sablonokra, dia méretezésre, mértékegységekre, memóriahasználatra, szálkezelésre, licencelésre, digitális aláírásra és VBA támogatásra vonatkozó gyakori kérdéseket.

Mielőtt elkezdené, telepítse a csomagot a PyPI‑ról a `pip install aspose.slides` paranccsal. Lásd a [Telepítés](/slides/hu/python-net/installation/) oldalt a Linux és macOS számára szükséges könyvtárakról, illetve a Debian és Ubuntu rendszer‑Pythonjéhez szükséges virtuális környezetről.

## **Prezentáció létrehozása**

Egy prezentáció létrehozásához és egy szöveges alakzat hozzáadásához az első diájához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) osztályból. Egy új prezentáció már tartalmaz egy üres diát.
2. Szerezze meg azt a diát a [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) gyűjteményből index alapján, 0.
3. A dia [shapes](https://reference.aspose.com/slides/python-net/aspose.slides/slide/shapes/) gyűjteményének [add_auto_shape](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_auto_shape/) metódusával adjon hozzá egy felhő alakú [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/)-t, és állítsa be a [text](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/text/) tulajdonságát.
4. Mentse a prezentációt PPTX fájlként a [save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) metódussal.

```py
import aspose.slides as slides

# Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
with slides.Presentation() as presentation:
    # Lekéri az első diát.
    slide = presentation.slides[0]

    # Hozzáad egy CLOUD típusú auto-shape-t.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Mentés PPTX fájlként.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

A felhő bal‑felső sarka 20 ponttal van a dia bal és felső szélétől, a felhő szélessége 200 pont, magassága pedig 80 pont. A `with` utasítás a blokk végeztével felszabadítja a prezentáció erőforrásait. A szkript a *new_presentation.pptx* fájlt a jelenlegi mappába menti, amely egyetlen diát tartalmaz a felhővel és a szövegével. Licenc nélkül az Aspose.Slides minden mentett diára egy értékelési vízjelet helyez; lásd a [Licencelés](/slides/hu/python-net/licensing/) oldalt.

Az eredmény:

![Az új prezentáció](new_presentation.png)

## **GYIK**

### Milyen formátumokba menthetem az új prezentációt?

Menthet [PPTX, PPT és ODP](/slides/hu/python-net/save-presentation/) formátumokba, és exportálhat [PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/hu/python-net/convert-powerpoint-to-xps/), [HTML](/slides/hu/python-net/convert-powerpoint-to-html/), [SVG](/slides/hu/python-net/render-a-slide-as-an-svg-image/) és [képek](/slides/hu/python-net/convert-powerpoint-to-png/) formátumba, többek között.

### Kezdhetek sablonnal (POTX/POTM), és menthetem reguláris PPTX‑ként?

Igen. Töltse be a sablont, és mentse a kívánt formátumba; a POTX/POTM/PPTM és hasonló formátumok [támogatottak](/slides/hu/python-net/supported-file-formats/).

### Hogyan szabályozhatom a dia méretét/méretarányát a prezentáció létrehozásakor?

Állítsa be a [slide size](/slides/hu/python-net/slide-size/) értékét (beleértve az 4:3 és 16:9 előre beállítottakat vagy egyedi méreteket), és válassza ki, hogyan skálázódjon a tartalom.

### Milyen mértékegységekben vannak a méretek és koordináták?

Pontban: 1 hüvelyk 72 egységnek felel meg.

### Hogyan kezeljem a nagyon nagy prezentációkat (sok médiával) a memóriahasználat csökkentése érdekében?

Használjon [BLOB kezelési stratégiai](/slides/hu/python-net/manage-blob/) megoldásokat, korlátozza a memóriában tárolt adatot ideiglenes fájlok használatával, és részesítse előnyben a fájl‑alapú munkafolyamatokat a pusztán memóriában lévő adatfolyamok helyett.

### Készíthetek/sMenthetek prezentációkat párhuzamosan?

Nem működik, ha ugyanazon [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) példányon több [thread](/slides/hu/python-net/multithreading/) dolgozik. Indítson külön, izolált példányokat szálanként vagy folyamatanként.

### Hogyan távolíthatom el a próba‑vízjelet és a korlátozásokat?

[Töltse be a licencet](/slides/hu/python-net/licensing/) egyszer a folyamatban. A licenc XML‑nek változatlanul kell maradnia, és a licenc beállítást szinkronizálni kell, ha több szál vesz részt.

### Aláírhatom digitálisan a létrehozott PPTX‑t?

Igen. A [Digital signatures](/slides/hu/python-net/digital-signature-in-powerpoint/) (hozzáadás és ellenőrzés) támogatott a prezentációkhoz.

### Támogatottak‑e a makrók (VBA) a létrehozott prezentációkban?

Igen. [Létrehozhat/szerkeszthet VBA projekteket](/slides/hu/python-net/presentation-via-vba/), és menthet makró‑támogatott fájlokat, például PPTM/PPSM.