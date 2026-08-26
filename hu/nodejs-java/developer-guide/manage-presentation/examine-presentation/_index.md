---
title: Prezentációs információk lekérése és frissítése JavaScriptben
linktitle: Prezentációs információk
type: docs
weight: 30
url: /hu/nodejs-java/examine-presentation/
keywords:
- prezentáció formátum
- prezentáció tulajdonságok
- dokumentumtulajdonságok
- tulajdonságok lekérése
- tulajdonságok olvasása
- tulajdonságok módosítása
- tulajdonságok átalakítása
- tulajdonságok frissítése
- PPTX vizsgálata
- PPT vizsgálata
- ODP vizsgálata
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel a diák, a struktúra és a metaadatok PowerPoint és OpenDocument prezentációkban JavaScript segítségével a gyorsabb betekintés és az intelligensebb tartalomelemzés érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet megvizsgálni a prezentáció információit az Aspose.Slides-ban. Ismerteti, hogyan határozható meg egy prezentáció aktuális formátuma a teljes fájl betöltése nélkül, hogyan olvashatók a dokumentum tulajdonságai, és hogyan frissíthetők ezek a tulajdonságok szükség esetén.

A példák a [PresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/) és a [DocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/) API-kon alapulnak, és bemutatják a prezentáció metaadataival való munkavégzés tipikus műveleteit.

## **Ellenőrizze a prezentáció formátumát**

Mielőtt dolgozna egy prezentáción, előfordulhat, hogy meg szeretné tudni, milyen formátumban (PPT, PPTX, ODP és egyebek) van a prezentáció jelenleg.

A prezentáció formátumát a prezentáció betöltése nélkül is ellenőrizheti. Lásd ezt a JavaScript kódot:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Szerezze meg a prezentáció tulajdonságait**

Ez a JavaScript kód megmutatja, hogyan lehet lekérni a prezentáció tulajdonságait (információk a prezentációról):

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

Megtekintheti a [DocumentProperties osztályban lévő tulajdonságokat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--).

## **Frissítse a prezentáció tulajdonságait**

Az Aspose.Slides biztosítja a [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) metódust, amely lehetővé teszi a prezentáció tulajdonságainak módosítását.

Tegyük fel, hogy van egy PowerPoint prezentáció a lenti dokumentumtulajdonságokkal.

![A PowerPoint prezentáció eredeti dokumentumtulajdonságai](input_properties.png)

Ez a kódrészlet megmutatja, hogyan szerkeszthet néhány prezentáció tulajdonságot:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let fileName = "sample.pptx";

let info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(fileName);

let properties = info.readDocumentProperties();
properties.setTitle("My title");
properties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

info.updateDocumentProperties(properties);
info.writeBindedPresentation(fileName);
```

A dokumentumtulajdonságok módosításának eredménye alább látható.

![A PowerPoint prezentáció módosított dokumentumtulajdonságai](output_properties.png)

## **Hasznos hivatkozások**

A prezentációról és annak biztonsági attribútumairól szóló további információkért a következő hivatkozások lehetnek hasznosak:

- [Jelszóval védett prezentációk](/slides/hu/nodejs-java/password-protected-presentation/)
- [Írásvédett prezentációk](/slides/hu/nodejs-java/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűtípusok be vannak-e ágyazva, és melyek azok?**

Keresse a [beágyazott betűtípusok információját](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) a prezentáció szintjén, majd hasonlítsa össze ezeket a bejegyzéseket a [tartalomban ténylegesen használt betűtípusok](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/getfonts/) halmazával, hogy azonosítsa a megjelenítéshez kritikus betűtípusokat.

**Hogyan tudom gyorsan megmondani, hogy a fájl tartalmaz-e rejtett dia(k) és hány darab?**

Iteráljon a [dia gyűjteményen](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/), és vizsgálja meg minden dia [láthatósági jelzőjét](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/gethidden/).

**Felderíthetem-e, hogy egyedi dia méret és tájolás van-e használatban, és eltérnek-e az alapértelmezettektől?**

Igen. Hasonlítsa össze a jelenlegi [dia méretet](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getslidesize/) és tájolást a szabványos előbeállításokkal; ez segít előre jelezni a nyomtatásra és exportálásra vonatkozó viselkedést.

**Van gyors mód arra, hogy megtudjam, a diagramok külső adatforrásokra hivatkoznak-e?**

Igen. Járja be az összes [diagramot](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/), ellenőrizze azok [adatforrását](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), és vegye figyelembe, hogy az adatok belsőek vagy hivatkozáson alapulnak, beleértve a hibás hivatkozásokat is.

**Hogyan értékelhetem a 'nehéz' diákat, amelyek lassíthatják a megjelenítést vagy a PDF exportálást?**

Minden diánál számolja az objektumok mennyiségét, és keressen nagy méretű képeket, átlátszóságot, árnyékokat, animációkat és multimédiát; adjon hozzávetőleges összetettségi pontszámot, hogy jelölje a potenciális teljesítményproblémákat.