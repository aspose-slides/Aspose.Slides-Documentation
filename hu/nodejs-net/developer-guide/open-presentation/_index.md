---
title: Prezentációk megnyitása Node.js-ben .NET segítségével
linktitle: Prezentáció megnyitása
type: docs
weight: 20
url: /hu/nodejs-net/open-presentation/
keywords:
- prezentáció megnyitása
- PowerPoint megnyitása
- PPTX megnyitása
- PPT megnyitása
- ODP megnyitása
- prezentáció betöltése
- prezentáció bufferből
- diák száma
- prezentáció konvertálása
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "PPTX, PPT és ODP prezentációk megnyitása JavaScriptben az Aspose.Slides for Node.js via .NET segítségével: fájlútról vagy bufferből betöltés, a diák számának lekérdezése, és mentés más formátumban."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via .NET megnyitja a PowerPoint és OpenDocument bemutatókat, például PPTX, PPT és ODP fájlokat, akár fájlútról, akár egy Node.js `Buffer`‑ből. Ez a cikk mindkét módszert bemutatja, kiolvassa a diák számát, és egy megnyitott bemutatót egy másik formátumban ment.

A példák egy `sample.pptx` nevű bemutatót várnak a projekt mappában, amit a [Installation](/slides/hu/nodejs-net/installation/) lépésben állítottál be. Bármely PowerPoint bemutató megfelel. Mentsd minden példát egy `.js` fájlba a projekt mappában, és futtasd a mappából a `node` paranccsal.

{{% alert color="info" title="Megjegyzés" %}}
Az Aspose.Slides for Node.js via .NET-nek nincs saját API-referenciája. A .NET Aspose.Slides API-ját tükrözi camelCase nevekkel, ezért ebben a cikkben szereplő API linkek a [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/hu/net/) megfelelő osztályaira és tagjaira mutatnak.
{{% /alert %}}

## **Prezentáció megnyitása fájlból**

Egy prezentáció megnyitásához add meg az elérési útját a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/presentation/) konstruktorának. Az Aspose.Slides a formátumot a fájl tartalmából, nem a kiterjesztésből határozza meg, ezért ugyanaz a kód képes megnyitni PPTX, PPT és ODP fájlokat. A relatív útvonal a jelenlegi munkakönyvtárhoz képest kerül feloldásra, amely a szkript onnan való futtatásakor a projekt mappa.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

A szkript kiírja a `sample.pptx` diáinak számát, például `Slide count: 9`. A [slides](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/slides/hu/) gyűjtemény `count` tulajdonsága a rejtett diákot is bele számolja. Hívd meg a `dispose` metódust egy `finally` blokkban, ahogy itt látható, hogy a prezentáció mögötti .NET erőforrások felszabaduljanak még akkor is, ha a kód hibát dob.

## **Prezentáció megnyitása Bufferből**

Amikor egy prezentáció adatbázisból, HTTP feltöltésből vagy más, csak bájtokat (nem fájlútot) biztosító forrásból érkezik, add meg a második konstruktorargumentumként egy Node.js `Buffer`‑t, az elsőt pedig `null`‑ként. A következő példa beolvassa a `sample.pptx` fájlt egy bufferbe, hogy ezt a forrást szimulálja:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

A szkript ugyanazt a diák számát írja ki, mint az előző példában. A második argumentumnak `Buffer`‑nek kell lennie. Bármely más típus, például `Uint8Array`, esetén a konstruktor nem dob hibát; egy új prezentációt hoz létre egy üres diával. Más bináris típusokat először konvertáld `Buffer.from`‑ral.

## **Prezentáció mentése más formátumban**

Egy prezentáció másik formátumba konvertálásához nyisd meg, majd mentsd el egy eltérő [SaveFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.export/saveformat/) értékkel. A következő példa kiírja azt a formátumot, amelyet az Aspose.Slides felismer, a [sourceFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/sourceformat/) tulajdonság visszaadja, és az prezentációt OpenDocument prezentációként menti:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

A szkript kiírja a `Source format: Pptx` üzenetet, és létrehozza a `sample.odp` fájlt, amely ugyanazokat a diákat tartalmazza. A `sourceFormat` `Ppt`, `Pptx` vagy `Odp` értéket ad vissza. Ha PDF‑ként vagy képként szeretnéd menteni, lásd a [Convert PowerPoint to PDF](/slides/hu/nodejs-net/convert-powerpoint-to-pdf/) és a [Convert Slides to Images](/slides/hu/nodejs-net/convert-slide/) oldalakat.

## **GYIK**

**Hogyan nyithatok meg jelszóval védett prezentációt?**

Hozz létre egy [LoadOptions](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/) objektumot, állítsd be a [password](https://reference.aspose.com/slides/hu/net/aspose.slides/loadoptions/password/) tulajdonságát, majd add meg az objektumot a konstruktor harmadik argumentumaként: `new Presentation("protected.pptx", null, loadOptions)`. Helyes jelszó hiányában a konstruktor hibát dob.

**Miért dob a konstruktor egy üres üzenetű `Error`‑t?**

Amikor a `Presentation` konstruktor .NET‑ben hibát jelez, például ha a fájl hiányzik, nem prezentáció, vagy más jelszót igényel, a JavaScript egy `Error` objektumot kap, amelynek üzenete üres. Mielőtt megnyitnál egy fájlt, ellenőrizd, hogy létezik‑e a munkakönyvtárhoz viszonyítva, például a `fs.existsSync` használatával.

**Milyen formátumokat nyithatok meg?**

PowerPoint és OpenDocument prezentáció formátumok, beleértve a PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP és FODP.