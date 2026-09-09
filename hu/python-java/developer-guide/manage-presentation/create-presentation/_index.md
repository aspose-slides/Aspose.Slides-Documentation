---
title: Prezentációk létrehozása Pythonban Java segítségével
linktitle: Prezentáció létrehozása
type: docs
weight: 10
url: /hu/python-java/create-presentation/
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
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Készíts prezentációkat Pythonban Java segítségével az Aspose.Slides használatával—hozz létre PPT, PPTX és ODP fájlokat, élvezd az OpenDocument támogatást, és mentsd őket programozottan a megbízható eredmények érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhatunk létre egy prezentációt az Aspose.Slides for Python via Java segítségével, hogyan adhatunk szöveges alakzatot az első diára, és hogyan menthetjük az eredményt PPTX fájlként. Az GYIK az output formátumokat, sablonokat, dia méretezést, memóriahasználatot, szálkezelést, licencelést, digitális aláírásokat és a VBA támogatást tárgyalja.

## **Prezentáció létrehozása**

A PowerPoint fájl nulláról történő létrehozása az Aspose.Slides for Python via Java-ban olyan egyszerű, mint a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztály példányosítása. A konstruktor automatikusan egy üres bemutatót ad egyetlen diárral, így azonnal rendelkezésre áll egy vászon alakzatok, szöveg, diagramok vagy bármilyen egyéb tartalom számára, amelyre az alkalmazásnak szüksége van. Miután módosítja azt a diát – vagy újakat ad hozzá – a végeredményt PPTX, régi PPT vagy akár OpenDocument formátumban mentheti. Az alábbi rövid kódrészlet bemutatja ezt a munkafolyamatot egy egyszerű alakzat hozzáadásával az első diára.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
1. Szerezze meg az első diát indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) típusú [ShapeType.Cloud](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/#Cloud) alakzatot a [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addAutoShape) segítségével.
1. Állítsa be az alakzat szövegét a [TextFrame.setText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/#setText) metódussal.
1. Mentse a prezentációt a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódussal a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Pptx) formátummal.

Az alábbi példa az Aspose.Slides for Python via Java és egy kompatibilis Java futtatókörnyezet használatát igényli. Elindítja a JVM-et, ha az még nem fut, hozzáad egy felhő alakzatot az első diához, és elmenti a prezentációt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Hozzon létre egy prezentációt egy üres diával.
presentation = Presentation()
try:
    # Szerezze meg az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá egy felhő alakzatot és állítsa be a szöveget.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Mentse a prezentációt PPTX fájlként.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az eredmény:

![Az új prezentáció](new_presentation.png)

## **GYIK**

**Milyen formátumokba menthetem az új prezentációt?**

Menthet [PPTX, PPT, and ODP](/slides/hu/python-java/save-presentation/) formátumokba, és exportálhat [PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/hu/python-java/convert-powerpoint-to-xps/), [HTML](/slides/hu/python-java/convert-powerpoint-to-html/), [SVG](/slides/hu/python-java/render-slide-as-svg/), valamint [images](/slides/hu/python-java/convert-powerpoint-to-png/) formátumokba, többek között.

**Kezdhetek egy sablonból (POTX/POTM), és menthetem szabványos PPTX-ként?**

Igen. Töltse be a sablont, majd mentse a kívánt formátumba; a POTX/POTM/PPTM és hasonló formátumok [támogatottak](/slides/hu/python-java/supported-file-formats/).

**Hogyan szabályozhatom a dia méretét/méretarányát prezentáció létrehozásakor?**

Állítsa be a [slide size](/slides/hu/python-java/slide-size/) (beleértve az előre definiált 4:3 és 16:9 arányokat vagy egyéni méreteket), és válassza ki, hogyan skálázzák a tartalmat.

**Milyen egységekben mérik a méreteket és koordinátákat?**

Pontokban: 1 hüvelyk 72 egységnek felel meg.

**Hogyan kezeljem a nagyon nagy prezentációkat (sok médiafájlt tartalmazókat) a memóriahasználat csökkentése érdekében?**

Használjon [BLOB management strategies](/slides/hu/python-java/manage-blob/), korlátozza a memóriában tárolást ideiglenes fájlok használatával, és részesítse előnyben a fájl-alapú munkafolyamatokat a kizárólag memóriaáramokkal szemben.

**Létrehozhatok/menthetek prezentációkat párhuzamosan?**

Nem működtethető ugyanazon [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példány több [thread](/slides/hu/python-java/multithreading/) részéről. Hozzon létre külön, izolált példányokat szálanként vagy folyamatanként.

**Hogyan távolíthatom el a próba vízjelet és a korlátozásokat?**

[Apply a license](/slides/hu/python-java/licensing/) egyszer a folyamatra. A licenc XML‑nek módosítás nélkül kell maradnia, és a licenc beállítást szinkronizálni kell, ha több szál van jelen.

**Digitálisan alá tudom-e írni a létrehozott PPTX-et?**

Igen. A [Digital signatures](/slides/hu/python-java/digital-signature-in-powerpoint/) (hozzáadás és ellenőrzés) támogatott a prezentációkhoz.

**Támogatottak a makrók (VBA) a létrehozott prezentációkban?**

Igen. [Create/edit VBA projects](/slides/hu/python-java/presentation-via-vba/) és makró‑engedélyezett fájlok, például PPTM/PPSM mentése lehetséges.