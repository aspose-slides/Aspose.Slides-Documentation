---
title: Prezentációk létrehozása Pythonon keresztül Java használatával
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
description: "Prezentációk létrehozása Pythonon keresztül Java használatával az Aspose.Slides segítségével - PPT, PPTX és ODP fájlok előállítása, az OpenDocument támogatás kihasználása, és programozott mentés a megbízható eredményekért."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhat létre prezentációt az Aspose.Slides for Python via Java segítségével, hogyan adhat hozzá szöveges alakzatot az első diára, és hogyan mentheti az eredményt PPTX fájlba. Az FAQ a kimeneti formátumokat, sablonokat, diaméretezést, memóriahasználatot, szálkezelést, licencelést, digitális aláírásokat és VBA támogatást tárgyalja.

Mielőtt elkezdené, telepítse a Python‑t, egy JDK‑t, a JPype‑ot és az Aspose.Slides for Python via Java‑t. Tekintse meg a [Telepítés](/slides/hu/python-java/installation/) oldalt a Windows, Linux és macOS lépéseihez.

## **Prezentáció létrehozása**

PowerPoint‑fájl létrehozása az Aspose.Slides for Python via Java‑ban a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztály példányosításával olyan egyszerű, mint egy üres füzet létrehozása egyetlen diával, amely azonnali vászonként szolgál alakzatok, szöveg, diagramok vagy bármilyen egyéb tartalom számára, amelyre az alkalmazásának szüksége van. Miután módosította azt a diát – vagy újakat ad hozzá – elmentheti az eredményt PPTX, régebbi PPT vagy akár OpenDocument formátumba is. Az alábbi rövid kópminta illusztrálja ezt a munkafolyamatot egy egyszerű alakzat hozzáadásával az első diára.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.  
1. Szerezze be az első diát a 0 indexével.  
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) típusú [ShapeType.Cloud](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Cloud) alakzatot a [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addAutoShape) metódussal.  
1. Állítsa be az alakzat szövegét a [TextFrame.setText](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/#setText) segítségével.  
1. Mentse a prezentációt a [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) metódussal, a [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx) formátummal.

Az alábbi példa elindítja a Java Virtual Machine‑et (JVM), ha még nem fut, hozzáad egy felhő alakzatot szöveggel az első diához, majd elmenti a prezentációt. Mentse *create_presentation.py* néven:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Készítsen egy prezentációt egy üres diával.
presentation = Presentation()
try:
    # Szerezze be az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá egy felhő alakzatot és állítsa be a szöveget.
    auto_shape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80)
    auto_shape.getTextFrame().setText("Hello, Aspose!")

    # Mentse a prezentációt PPTX fájlként.
    presentation.save("new_presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Futtassa a szkriptet abban a környezetben, ahol telepítette a csomagokat:

```sh
python create_presentation.py
```

A felhő bal felső sarka 20 ponttal van a dia bal és felső szélétől, a felhő 200 pont széles és 80 pont magas. A szkript a *new_presentation.pptx* fájlt a jelenlegi munkakönyvtárban menti, egyetlen diával, amely a felhőt és annak szövegét tartalmazza. A JVM addig fut, amíg a Python folyamat be nem fejeződik; lásd a [Korlátozások és API‑különbségek](/slides/hu/python-java/limitations-and-api-differences/#import-the-library) oldalt. Licenc nélkül az Aspose.Slides minden mentett diára egy értékelési vízjel szövegdobozt is hozzáad; lásd a [Licencelés](/slides/hu/python-java/licensing/) oldalt.

![Az új prezentáció](new_presentation.png)

## **GYIK**

**Milyen formátumokba menthetek egy új prezentációt?**

Menthet PPTX, PPT és ODP formátumba, valamint exportálhat [PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/hu/python-java/convert-powerpoint-to-xps/), [HTML](/slides/hu/python-java/convert-powerpoint-to-html/), [SVG](/slides/hu/python-java/render-a-slide-as-an-svg-image/) és [képek](/slides/hu/python-java/convert-powerpoint-to-png/) formátumokba, többek között.

**Kezdhetek egy sablonnal (POTX/POTM), és menthetem szabványos PPTX‑ként?**

Igen. Töltse be a sablont, és mentse a kívánt formátumba; a POTX/POTM/PPTM és hasonló formátumok [támogatottak](/slides/hu/python-java/supported-file-formats/).

**Hogyan szabályozhatom a dia méretét/méretarányát a prezentáció létrehozásakor?**

Állítsa be a [dia méretét](/slides/hu/python-java/slide-size/) (beleértve az előre definiált 4:3 és 16:9 beállításokat vagy egyedi méreteket), és válassza ki, hogyan méreteződjön a tartalom.

**Milyen egységekben mérik a méreteket és koordinátákat?**

Pontokban: 1 hüvelyk = 72 egység.

**Hogyan kezelhetek nagyon nagy prezentációkat (számos médiafájllal) a memóriahasználat csökkentése érdekében?**

Használja a [BLOB kezelési stratégiákat](/slides/hu/python-java/manage-blob/), korlátozza a memóriában lévő tárolást ideiglenes fájlokkal, és részesítse előnyben a fájlalapú munkafolyamatokat a kizárólag memóriában lévő adatfolyamok helyett.

**Létrehozhatok/menthetek prezentációkat párhuzamosan?**

Nem működhet ugyanazon a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) példányon több [szál](/slides/hu/python-java/multithreading/) egyidejűleg. Indítson külön, izolált példányokat szálanként vagy folyamatanként.

**Hogyan távolíthatom el a próba vízjelet és a korlátozásokat?**

[Alkalmazzon licencet](/slides/hu/python-java/licensing/) egyszer a folyamatban. A licenc XML‑nek módosítás nélkül kell maradnia, és a licenc beállítást szinkronizálni kell, ha több szál használja.

**Digitálisan alá tudom-e írni a létrehozott PPTX‑et?**

Igen. A [digitális aláírások](/slides/hu/python-java/digital-signature-in-powerpoint/) (létrehozása és ellenőrzése) támogatottak a prezentációkhoz.

**Támogatottak-e a makrók (VBA) a létrehozott prezentációkban?**

Igen. [Létrehozhat/szerkeszthet VBA projekteket](/slides/hu/python-java/presentation-via-vba/), és menthet makró‑támogatott fájlokat, például PPTM/PPSM.