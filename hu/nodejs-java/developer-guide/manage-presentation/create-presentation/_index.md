---
title: JavaScriptben bemutatók létrehozása
linktitle: Bemutató létrehozása
type: docs
weight: 10
url: /hu/nodejs-java/create-presentation/
keywords:
- bemutató létrehozása
- új bemutató
- PPT létrehozása
- új PPT
- PPTX létrehozása
- új PPTX
- ODP létrehozása
- új ODP
- PowerPoint
- OpenDocument
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Készítsen bemutatókat az Aspose.Slides segítségével — állítson elő PPT, PPTX és ODP fájlokat, élvezze az OpenDocument támogatást, és programozottan mentse őket megbízható eredményekért."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan hozhatunk létre egy bemutatót az Aspose.Slides-ban, hogyan adhatunk szövegdobozt az első diahoz, és hogyan menthetjük az eredményt fájlként.

Mielőtt elkezdené, telepítse a `aspose.slides.via.java` csomagot az npm-ről, valamint a szükséges JDK-t, Pythont és C++ fordítóeszközöket. Lásd [Telepítés](/slides/hu/nodejs-java/installation/).

## **PowerPoint bemutató létrehozása**

A bemutató létrehozásához és egy szövegdoboz elhelyezéséhez az első diára, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból. Egy új bemutató már tartalmaz egy üres diát.  
2. Szerezze meg azt a diát a [slide collection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getslides/) gyűjteményből az indexével, 0.  
3. Adjon hozzá egy téglalapot a [addAutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/addautoshape/) metódussal, és állítsa be a szövegét a [setText](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/textframe/settext/) segítségével.  
4. Mentse a bemutatót PPTX fájlként a [save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/save/) metódus segítségével.  
5. Szabadítsa fel a bemutatót a [dispose](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/dispose/) metódussal, és fejezze be a folyamatot.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Az Aspose.Slides egy Java virtuális gépben fut, amely a Node.js futását fenntartja, ezért explicit módon kell befejezni a folyamatot.
process.exit(0);
```

A téglalap bal‑felső sarka 50 ponttal van a dia bal szélétől és 50 ponttal a felső szélétől, a téglalap szélessége 400 pont, magassága 100 pont. Mentse a kódot *hello.js* néven a projekt mappájába, és futtassa a `node hello.js` parancsot: ez *hello.pptx*-t hoz létre, amely egy diát tartalmaz a téglalappal és a hozzá tartozó szöveggel, az aktuális mappában.

Az Aspose.Slides egy Java virtuális gépben fut, amelyet a `java` csomag indít a Node.js folyamaton belül. Ez a virtuális gép megakadályozza, hogy a Node.js önmagától kilépjen a szkript befejezése után, ezért a példa a `process.exit(0)` parancssal zárul.

Licenc nélkül az Aspose.Slides minden mentett diára egy értékelési vízjelet helyez el; lásd a [Licenc](/slides/hu/nodejs-java/licensing/) oldalt.

## **GYIK**

### Milyen formátumokba menthetek egy új bemutatót?

Menthet [PPTX, PPT és ODP](/slides/hu/nodejs-java/save-presentation/) formátumban, és exportálhat [PDF](/slides/hu/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/hu/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/hu/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/hu/nodejs-java/render-a-slide-as-an-svg-image/), és [képek](/slides/hu/nodejs-java/convert-powerpoint-to-png/) formátumokba, többek között.

### Kezdhetek sablonból (POTX/POTM) és menthetem normál PPTX‑ként?

Igen. Töltse be a sablont és mentse a kívánt formátumba; a POTX/POTM/PPTM és hasonló formátumok [támogatottak](/slides/hu/nodejs-java/supported-file-formats/).

### Hogyan szabályozhatom a dia méretét/méretarányát bemutató létrehozásakor?

Állítsa be a [dia mérete](/slides/hu/nodejs-java/slide-size/) (beleértve az előre beállítottakat, mint a 4:3 és 16:9, vagy egyéni méreteket), és válassza ki, hogy a tartalom hogyan méreteződjön.

### Milyen egységekben vannak megadva a méretek és koordináták?

Pontokban: 1 hüvelyk egyenlő 72 egységgel.

### Hogyan kezeljem a nagyon nagy bemutatókat (sok médiafájllal) a memóriahasználat csökkentése érdekében?

Használja a [BLOB‑kezelési stratégiákat](/slides/hu/nodejs-java/manage-blob/), korlátozza a memóriában tárolt adatokat ideiglenes fájlok használatával, és részesítse előnyben a fájl‑alapú munkafolyamatokat a kizárólag memóriában lévő adatfolyamok helyett.

### Létrehozhatok/menthetek bemutatókat párhuzamosan?

Nem lehet ugyanazon a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányon műveleteket végrehajtani [több szál](/slides/hu/nodejs-java/multithreading/) esetén. Futtasson külön, elszigetelt példányokat szálanként vagy folyamatanként.

### Hogyan távolíthatom el a próba vízjelet és korlátozásokat?

[Licenc alkalmazása](/slides/hu/nodejs-java/licensing/) egyszer a folyamatban. A licenc XML‑nek módosítatlanul kell maradnia, és a licenc beállítását szinkronizálni kell, ha több szál van jelen.

### Digitálisan aláírhatom a létrehozott PPTX‑et?

Igen. A [Digitális aláírások](/slides/hu/nodejs-java/digital-signature-in-powerpoint/) (létrehozás és ellenőrzés) támogatott a bemutatókhoz.

### Támogatottak a makrók (VBA) a létrehozott bemutatókban?

Igen. [VBA projektek létrehozása/szerkesztése](/slides/hu/nodejs-java/presentation-via-vba/) és makróval ellátott fájlokat, például PPTM/PPSM menthet.