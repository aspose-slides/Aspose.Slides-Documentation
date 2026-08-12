---
title: Prezentációk mentése JavaScript-ben
linktitle: Prezentáció mentése
type: docs
weight: 80
url: /hu/nodejs-java/save-presentation/
keywords:
- PowerPoint mentése
- OpenDocument mentése
- prezentáció mentése
- dia mentése
- PPT mentése
- PPTX mentése
- ODP mentése
- prezentáció fájlba
- prezentáció folyamba
- előre definiált nézettípus
- szigorú Office Open XML formátum
- Zip64 mód
- miniatűr frissítése
- mentés előrehaladása
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel, hogyan menthet prezentációkat az Aspose.Slides for Node.js segítségével JavaScript‑en keresztül — exportálás PowerPoint vagy OpenDocument formátumba, miközben megőrzik a elrendezéseket, betűtípusokat és effektusokat."
---
## **Áttekintés**

[Prezentációk megnyitása JavaScript-ben](/slides/hu/nodejs-java/open-presentation/) leírja, hogyan használjuk a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályt egy prezentáció megnyitásához. Ez a cikk bemutatja, hogyan hozhatunk létre és menthetünk prezentációkat. A [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztály a prezentáció tartalmát tartalmazza. Akár egy prezentációt építünk fel a semmiből, akár egy meglévőt módosítunk, a végén menteni kell. Az Aspose.Slides for Node.js segítségével **fájlba** vagy **folyamba** menthetünk. Ez a cikk a prezentáció mentésének különböző módjait mutatja be.

## **Prezentációk mentése fájlokba**

Egy prezentációt fájlba menthet a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztály `save` metódusának hívásával. A metódusnak adja át a fájlnevet és a mentés formátumát. A következő példa bemutatja, hogyan menthet prezentációt az Aspose.Slides használatával.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Hozzon létre egy Presentation osztályt, amely egy prezentációfájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Végezzen itt némi munkát...

    // Mentse a prezentációt egy fájlba.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése folyamatokba**

Egy prezentációt folyamatba menthet, ha egy kimeneti streamet ad át a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztály `save` metódusának. A prezentáció számos stream típusba írható. Az alábbi példában új prezentációt hozunk létre, és fájl streambe mentjük.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Hozzon létre egy Presentation osztályt, amely egy prezentációfájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Mentse a prezentációt a streambe.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése előre definiált nézettípussal**

Az Aspose.Slides lehetővé teszi, hogy a generált prezentáció megnyitásakor a PowerPoint által használt kezdeti nézetet a [ViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/) osztályon keresztül állítsa be. Használja a [setLastView](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/#setLastView) metódust a [ViewType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewtype/) felsorolás egyik értékével.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése a szigorú Office Open XML formátumban**

Az Aspose.Slides lehetővé teszi, hogy egy prezentációt a szigorú Office Open XML formátumban mentse. Használja a [PptxOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxoptions/) osztályt, és a mentéskor állítsa be a megfelelőség tulajdonságát. Ha a [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) értéket állítja be, a kimeneti fájl a szigorú Office Open XML formátumban kerül mentésre.

Az alábbi példa egy prezentációt hoz létre, és a szigorú Office Open XML formátumban menti.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Hozzon létre egy Presentation osztályt, amely egy prezentációfájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Mentse a prezentációt a szigorú Office Open XML formátumban.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése Office Open XML formátumban Zip64 módban**

Az Office Open XML fájl egy ZIP archívum, amely 4 GB (2^32 bájt) korlátot szab a bármely fájl kitömörített méretére, a tömörített méretére és az archívum teljes méretére, valamint legfeljebb 65 535 (2^16‑1) fájl tárolására. A ZIP64 formátumkiterjesztések ezeknek a korlátoknak a 2^64-re emelését teszik lehetővé.

A [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) metódus lehetővé teszi, hogy kiválassza, mikor használja a ZIP64 formátumkiterjesztéseket Office Open XML fájl mentésekor.

Ez a metódus a következő módokkal használható:

- [IfNecessary](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/zip64mode/#IfNecessary) csak akkor használ ZIP64 formátumkiterjesztéseket, ha a prezentáció meghaladja a fenti korlátokat. Ez az alapértelmezett mód.
- [Never](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/zip64mode/#Never) soha nem használ ZIP64 formátumkiterjesztéseket.
- [Always](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/zip64mode/#Always) mindig használ ZIP64 formátumkiterjesztéseket.

Az alábbi kód bemutatja, hogyan menthetünk egy prezentációt PPTX fájlként a ZIP64 formátumkiterjesztésekkel engedélyezve:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Ha a [Zip64Mode.Never](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/zip64mode/#Never) használatával ment, a [PptxException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxexception/) kerül dobásra, ha a prezentációt ZIP32 formátumban nem lehet menteni.
{{% /alert %}}

## **Prezentációk mentése Office Open XML formátumban tömörítési szintekkel**

Nagy prezentációk esetén beállíthatja a tömörítési szintet a fájlméret és a feldolgozási idő egyensúlyozásához. Igényeitől függően gyorsabb feldolgozást vagy kisebb kimeneti fájlokat választhat.

Az Aspose.Slides biztosítja a [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel) metódust, amely lehetővé teszi a prezentáció Office Open XML formátumba mentésekor használt tömörítési szint megadását.

A következő tömörítési szintek érhetők el:

- [**None**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/#None): Nem alkalmaz tömörítést. A fájlok változatlanul kerülnek tárolásra.
- [**Level1**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/#Level1): A leggyorsabb tömörítés, a legalacsonyabb tömörítési aránnyal.
- [**Level2**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/#Level2): Gyorsabb tömörítés, valamivel jobb tömörítési aránnyal, mint a **Level1**.
- [**Level3**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/#Level3): Jobb tömörítést nyújt, mint a **Level2**, közepes hatással a feldolgozási időre.
- [**Level4**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/#Level4): Jobb tömörítést nyújt, mint a **Level3**.
- [**Level5**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/#Level5): Javított tömörítés a **Level4**-hez képest, további feldolgozási idővel.
- [**Level6**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/#Level6): Standard tömörítés, amely jó egyensúlyt kínál a feldolgozási sebesség és a fájlméret között. Ez a *alapértelmezett tömörítési szint*.
- [**Level7**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/#Level7): Jobb tömörítést nyújt, mint a **Level6**, lassabb feldolgozással.
- [**Level8**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/#Level8): Jobb tömörítést nyújt, mint a **Level7**.
- [**Level9**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/#Level9): Maximális tömörítés. A legkisebb fájlméretet eredményezi, a leghosszabb feldolgozási idő ára fejében.

Az alábbi példa bemutatja, hogyan menthet prezentációt PPTX fájlként *tömörítés nélkül*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Ez a példa bemutatja, hogyan menthet prezentációt PPTX fájlként *maximális tömörítéssel*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése a miniatűr frissítése nélkül**

A [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) metódus szabályozza a miniatűr generálását PPTX formátumba történő mentéskor:

- Ha `true`-ra van állítva, a mentés közben frissül a miniatűr. Ez az alapértelmezett.
- Ha `false`-ra van állítva, a jelenlegi miniatűr megmarad. Ha a prezentációnak nincs miniatűrje, akkor nem generálódik.

Az alábbi kódban a prezentáció a miniatűr frissítése nélkül kerül mentésre PPTX-be.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Ez a beállítás segít csökkenteni a PPTX formátumba történő mentéshez szükséges időt.
{{% /alert %}}

## **Mentés előrehaladásának százalékos jelentése**

A mentés előrehaladásának jelentését a [setProgressCallback](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) metódus konfigurálja a [SaveOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveoptions/) és alosztályain. Adjon meg egy Java proxyt, amely implementálja az [IProgressCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprogresscallback/) interfészt; az exportálás során a visszahívás periódikusan százalékos frissítéseket kap.

Az alábbi kódrészletek bemutatják, hogyan kell használni az `IProgressCallback`-ot.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Használja itt a százalékos előrehaladási értéket.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Az Aspose egy [ingyenes PowerPoint Splitter alkalmazást](https://products.aspose.app/slides/hu/splitter) fejlesztett ki saját API-ja segítségével. Az alkalmazás lehetővé teszi egy prezentáció több fájlra bontását, a kiválasztott diák új PPTX vagy PPT fájlként való mentésével.
{{% /alert %}}

## **FAQ**

**Támogatja a "gyors mentés" (inkrementális mentés) funkciót, amely csak a változásokat írja?**

Nem. A mentés minden alkalommal a teljes célfájlt hozza létre; az inkrementális „gyors mentés” nem támogatott.

**Biztonságos-e több szálról menteni ugyanazt a Presentation példányt?**

Nem. A [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példány [nem szálbiztonságos]; ezért egyetlen szálról mentse.

**Mi történik a hiperhivatkozásokkal és a külsőleg hivatkozott fájlokkal a mentés során?**

[Hyperlinks](/slides/hu/nodejs-java/manage-hyperlinks/) megmaradnak. A külsőleg hivatkozott fájlok (például relatív útvonalú videók) nem másolódnak automatikusan – győződjön meg arról, hogy a hivatkozott útvonalak továbbra is elérhetők.

**Beállíthatom/menthetem a dokumentum metaadatait (Szerző, Cím, Cég, Dátum)?**

Igen. A szabványos [document properties](/slides/hu/nodejs-java/presentation-properties/) támogatott, és mentéskor a fájlba kerülnek.