---
title: Prezentációk létrehozása Pythonban Java-val
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
description: "Készítsen prezentációkat Pythonban Java-val az Aspose.Slides segítségével—hozzon létre PPT, PPTX és ODP fájlokat, élvezze az OpenDocument támogatást, és programozottan mentse őket megbízható eredményekhez."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhatunk létre egy prezentációt az Aspose.Slides for Python via Java könyvtárral, hogyan adhatunk szöveges alakzatot az első diára, és hogyan menthetjük az eredményt PPTX fájlként. A GYIK a kimeneti formátumokat, sablonokat, diaméretezést, memóriahasználatot, szálkezelést, licencelést, digitális aláírásokat és a VBA támogatást tárgyalja.

## **Prezentáció létrehozása**

A PowerPoint fájl létrehozása a semmiből az Aspose.Slides for Python via Java segítségével olyan egyszerű, mint a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztály példányosítása. A konstruktor automatikusan egy üres, egy diát tartalmazó prezentációt biztosít, amely azonnali vászonként szolgál alakzatok, szöveg, diagramok vagy bármilyen egyéb tartalom számára, amelyre az alkalmazásnak szüksége van. Miután módosítja ezt a diát – vagy újakat ad hozzá – az eredményt mentheti PPTX, régebbi PPT vagy akár OpenDocument formátumba. Az alábbi rövid kódrészlet ezt a munkafolyamatot szemlélteti egy egyszerű alakzat hozzáadásával az első diához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
1. Szerezze meg az első diát az indexével.  
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/autoshape/) típusú [ShapeType.Cloud](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapetype/#Cloud) alakzatot a [ShapeCollection.addAutoShape](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/#addAutoShape) segítségével.  
1. Állítsa be az alakzat szövegét a [TextFrame.setText](https://reference.aspose.com/slides/hu/python-java/aspose.slides/textframe/#setText) használatával.  
1. Mentse a prezentációt a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) segítségével [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/#Pptx) használatával.

Az alábbi példa az Aspose.Slides for Python via Java és egy kompatibilis Java futtatókörnyezet meglétét igényli. Elindítja a JVM-et, ha még nem fut, felvesz egy felhő alakzatot az első diára, és elmenti a prezentációt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Készítsen egy prezentációt egy üres diárral.
presentation = Presentation()
try:
    # Szerezze meg az első diát.
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá egy felhő alakzatot, és állítsa be a szövegét.
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

**Milyen formátumokba menthetek egy új prezentációt?**

Menthet a [PPTX, PPT és ODP](/slides/hu/python-java/save-presentation/) formátumokba, és exportálhat [PDF](/slides/hu/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/hu/python-java/convert-powerpoint-to-xps/), [HTML](/slides/hu/python-java/convert-powerpoint-to-html/), [SVG](/slides/hu/python-java/render-slide-as-svg/), valamint [images](/slides/hu/python-java/convert-powerpoint-to-png/) formátumba, többek között.

**Elindíthatok egy sablonnal (POTX/POTM), és menthetem reguláris PPTX-ként?**

Igen. Töltse be a sablont, és mentse a kívánt formátumba; a POTX/POTM/PPTM és hasonló formátumok [támogatottak](/slides/hu/python-java/supported-file-formats/).

**Hogyan szabályozhatom a diák méretét/méretarányát a prezentáció létrehozásakor?**

Állítsa be a [slide size](/slides/hu/python-java/slide-size/) (beleértve az olyan előre beállított értékeket, mint a 4:3 és 16:9 vagy egyedi méreteket), és válassza ki, hogyan skálázódjon a tartalom.

**Milyen egységekben mérik a méreteket és koordinátákat?**

Pontban: 1 hüvelyk 72 egységnek felel meg.

**Hogyan kezeljem a nagyméretű prezentációkat (számos médiafájllal) a memóriahasználat csökkentése érdekében?**

Használjon [BLOB management strategies](/slides/hu/python-java/manage-blob/) módszereket, korlátozza a memória-alapú tárolást ideiglenes fájlok kihasználásával, és részesítse előnyben a fájl-alapú munkafolyamatokat a kizárólag memória-alapú adatfolyamok helyett.

**Készíthetek/menthetek prezentációkat párhuzamosan?**

Nem lehet ugyanazon a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példányon [multiple threads](/slides/hu/python-java/multithreading/) alatt működni. Futtasson külön, elszigetelt példányokat szálanként vagy folyamatként.

**Hogyan távolíthatom el a próbaverzió vízjelet és korlátozásait?**

[Apply a license](/slides/hu/python-java/licensing/) egyszer a folyamatban. A licenc XML-nek változatlanul kell maradnia, és a licenc beállítást szinkronizálni kell, ha több szál vesz részt.

**Alá tudom-e digitálisan aláírni a létrehozott PPTX-et?**

Igen. A [Digital signatures](/slides/hu/python-java/digital-signature-in-powerpoint/) (hozzáadás és ellenőrzés) támogatott a prezentációkban.

**Támogatottak-e makrók (VBA) a létrehozott prezentációkban?**

Igen. [create/edit VBA projects](/slides/hu/python-java/presentation-via-vba/) létrehozhat és szerkeszthet VBA projekteket, és menthet makróval ellátott fájlokat, például PPTM/PPSM.