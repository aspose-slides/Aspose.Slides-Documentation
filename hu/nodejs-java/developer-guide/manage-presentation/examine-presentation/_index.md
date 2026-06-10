---
title: Prezentációs információk lekérése és frissítése JavaScriptben
linktitle: Prezentációs információ
type: docs
weight: 30
url: /hu/nodejs-java/examine-presentation/
keywords:
- prezentáció formátuma
- prezentáció tulajdonságai
- dokumentum tulajdonságai
- tulajdonságok lekérése
- tulajdonságok olvasása
- tulajdonságok módosítása
- tulajdonságok módosítása
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
description: "Fedezze fel a diák, a felépítés és a metaadatok részleteit PowerPoint és OpenDocument prezentációkban JavaScript használatával a gyorsabb betekintés és az okosabb tartalomelemzés érdekében."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet megvizsgálni a prezentáció adatait az Aspose.Slides segítségével. Elmagyarázza, hogyan határozható meg egy prezentáció aktuális formátuma a teljes fájl betöltése nélkül, hogyan olvashatók a dokumentumtulajdonságai, és hogyan frissíthetők ezek a tulajdonságok szükség esetén.

A példák a [PresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/) és a [DocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/) API‑kon alapulnak, és tipikus műveleteket mutatnak be a prezentáció metaadatainak kezelésére.

## **Prezentáció formátumának ellenőrzése**

Mielőtt dolgoznál egy prezentáción, szeretnéd megtudni, hogy jelenleg milyen formátumban (PPT, PPTX, ODP és egyéb) van a fájl.

A prezentáció formátuma ellenőrizhető a prezentáció betöltése nélkül. Lásd ezt a JavaScript kódot:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
console.log(info.getLoadFormat());// PPTX
var info2 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.ppt");
console.log(info2.getLoadFormat());// PPT
var info3 = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.odp");
console.log(info3.getLoadFormat());// ODP
```

## **Prezentáció tulajdonságainak lekérése**

Ez a JavaScript kód megmutatja, hogyan lehet lekérni a prezentáció tulajdonságait (információk a prezentációról):

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("pres.pptx");
var props = info.readDocumentProperties();
console.log(props.getCreatedTime());
console.log(props.getSubject());
console.log(props.getTitle());
// ..
```

Érdemes megtekinteni a [DocumentProperties osztályban található tulajdonságokat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Prezentáció tulajdonságainak frissítése**

Az Aspose.Slides biztosítja a [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-) metódust, amely lehetővé teszi a prezentáció tulajdonságainak módosítását.

Tegyük fel, hogy van egy PowerPoint prezentációnk a lenti dokumentumtulajdonságokkal.

![A PowerPoint prezentáció eredeti dokumentumtulajdonságai](input_properties.png)

Ez a kódrészlet bemutatja, hogyan szerkeszthetünk néhány prezentációs tulajdonságot:

```javascript
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

További információkért a prezentációról és annak biztonsági attribútumairól hasznosak lehetnek a következő hivatkozások:

- [Annak ellenőrzése, hogy egy prezentáció titkosított-e](https://docs.aspose.com/slides/hu/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Annak ellenőrzése, hogy egy prezentáció írásvédett (csak olvasható)-e](https://docs.aspose.com/slides/hu/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Annak ellenőrzése, hogy egy prezentáció jelszóval védett-e betöltés előtt](https://docs.aspose.com/slides/hu/nodejs-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [A prezentáció védelméhez használt jelszó megerősítése](https://docs.aspose.com/slides/hu/nodejs-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűtípusok beágyazottak-e, és melyek azok?**

Keress a prezentáció szintjén [beágyazott betűtípus információkat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/), majd hasonlítsd össze ezeket a [tartalom által ténylegesen használt betűtípusok](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/getfonts/) halmazával, hogy azonosítsd, mely betűtípusok kritikusak a megjelenítéshez.

**Hogyan tudom gyorsan megállapítani, hogy a fájl rejtett diákot tartalmaz-e, és ha igen, hányat?**

Iterálj a [dia gyűjteményen](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidecollection/), és ellenőrizd minden dia [láthatósági jelzőjét](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/gethidden/) .

**Felismerhető-e, hogy egyedi dia méret és orientáció van-e használatban, és eltérnek-e az alapértelmezettől?**

Igen. Hasonlítsd össze a jelenlegi [dia méretet](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getslidesize/) és orientációt a szabványos előbeállításokkal; ez segít előre jelezni a nyomtatás és export viselkedését.

**Van gyors módja annak, hogy megtudjam, a diagramok hivatkoznak-e külső adatforrásokra?**

Igen. Járd be az összes [diagramot](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/), ellenőrizd azok [adatforrását](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/getdatasourcetype/), és jegyezd fel, hogy az adat belső vagy hivatkozáson alapul, beleértve a hibás hivatkozásokat is.

**Hogyan értékeljem a „nehéz” diákot, amelyek lassíthatják a megjelenítést vagy a PDF exportot?**

Minden dia esetén számold meg az objektumok számát, keresd a nagy képeket, átláthatóságot, árnyékokat, animációkat és multimédiát; adj hozzávetőleges bonyolultsági pontszámot, hogy jelöld a potenciális teljesítményproblémákat.