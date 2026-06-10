---
title: Prezentációk létrehozása JavaScriptben
linktitle: Prezentáció létrehozása
type: docs
weight: 10
url: /hu/nodejs-java/create-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Készítsen prezentációkat az Aspose.Slides segítségével — hozzon létre PPT, PPTX és ODP fájlokat, élvezze az OpenDocument támogatást, és mentse őket programozott módon a megbízható eredmények érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhat létre egy prezentációt az Aspose.Slides‑ban, egyszerű tartalmat adhat egy diára, és mentheti az eredményt fájlként.

## **PowerPoint prezentáció létrehozása**

Egy egyszerű egyenes vonal hozzáadásához a prezentáció kiválasztott diájához, kövesse az alábbi lépéseket:

1. Hozzon létre egy Presentation osztály példányt.  
2. Szerezze be egy dia referenciáját az Index használatával.  
3. Adjon hozzá egy vonal típusú AutoShape‑t az addAutoShape metódussal, amelyet a Shapes objektum biztosít.  
4. Írja a módosított prezentációt PPTX fájlként.

Az alább bemutatott példában egy vonalat adtunk hozzá a prezentáció első diájához.

```javascript
// Egy Presentation objektum példányosítása, amely egy prezentációfájlt képvisel
var pres = new aspose.slides.Presentation();
try {
    // Az első dia lekérése
    var slide = pres.getSlides().get_Item(0);
    // Vonaltípusú autoshape hozzáadása
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Milyen formátumokba menthetem az új prezentációt?**  
Menthet [PPTX, PPT és ODP](/slides/hu/nodejs-java/save-presentation/) formátumba, valamint exportálhat [PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/hu/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/hu/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/hu/nodejs-java/convert-powerpoint-to-png/) és [képek](/slides/hu/nodejs-java/convert-powerpoint-to-png/) formátumokba, többek között.

**Kezdhetek egy sablonnal (POTX/POTM), és menthetem normál PPTX‑ként?**  
Igen. Töltse be a sablont, és mentse a kívánt formátumba; a POTX/POTM/PPTM és hasonló formátumok [támogatottak](/slides/hu/nodejs-java/supported-file-formats/).

**Hogyan szabályozhatom a dia méretét/méretarányát egy prezentáció létrehozásakor?**  
Állítsa be a [dia méretét](/slides/hu/nodejs-java/slide-size/) (beleértve az olyan előre beállított értékeket, mint a 4:3 és 16:9, vagy egyedi méreteket), és válassza ki, hogyan méreteződjön a tartalom.

**Milyen egységekben vannak megadva a méretek és koordináták?**  
Pontokban: 1 hüvelyk 72 egységnek felel meg.

**Hogyan kezeljem a nagyon nagy prezentációkat (sok médiafájllal), hogy csökkentsem a memóriahasználatot?**  
Használjon [BLOB kezelési stratégiákat](/slides/hu/nodejs-java/manage-blob/), korlátozza a memóriában tárolt adatot ideiglenes fájlok használatával, és részesítse előnyben a fájl‑alapú munkafolyamatokat a tisztán memória‑alapú adatfolyamok helyett.

**Létrehozhatok/menthetek prezentációkat párhuzamosan?**  
Nem használhatja ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt [több szál](/slides/hu/nodejs-java/multithreading/). Indítson külön, izolált példányokat szálanként vagy folyamatként.

**Hogyan távolíthatom el a próba vízjelet és a korlátozásokat?**  
[Alkalmazzon licencet](/slides/hu/nodejs-java/licensing/) egyszer a folyamatonként. A licenc XML‑nek módosítatlanul kell maradnia, és a licenc beállítást szinkronizálni kell, ha több szál is részt vesz.

**Alá tudom-e digitálisan írni a létrehozott PPTX‑et?**  
Igen. A [digitális aláírások](/slides/hu/nodejs-java/digital-signature-in-powerpoint/) (hozzáadás és ellenőrzés) támogatottak a prezentációkhoz.

**Támogatottak a makrók (VBA) a létrehozott prezentációkban?**  
Igen. [VBA projektek létrehozhatók/szerkeszthetők](/slides/hu/nodejs-java/presentation-via-vba/), és menthet makrókkal ellátott fájlokat, például PPTM/PPSM.