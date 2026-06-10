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
- előre meghatározott nézettípus
- szigorú Office Open XML formátum
- Zip64 mód
- bélyegkép frissítése
- mentési előrehaladás
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel, hogyan menthet prezentációkat az Aspose.Slides for Node.js használatával JavaScript‑en keresztül — exportáljon PowerPoint vagy OpenDocument formátumba, miközben megtartja az elrendezéseket, betűtípusokat és effektusokat."
---
## **Áttekintés**

[Open Presentations in JavaScript](/slides/hu/nodejs-java/open-presentation/) bemutatja, hogyan használható a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztály egy bemutató megnyitásához. Ez a cikk elmagyarázza, hogyan hozhatók létre és menthetők a bemutatók. A [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztály tartalmazza a bemutató tartalmát. Akár új bemutatót hoz létre, akár egy meglévőt módosít, a munka befejezésekor mentenie kell azt. Az Aspose.Slides for Node.js segítségével **fájlba** vagy **folyamba** menthet. Ez a cikk bemutatja a bemutató mentésének különböző módjait.

## **Bemutatók mentése fájlokba**

A bemutató mentéséhez egy fájlba hívd meg a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztály `save` metódusát. Add meg a fájl nevét és a mentési formátumot a metódusnak. Az alábbi példa megmutatja, hogyan menthető a bemutató az Aspose.Slides segítségével.

```js
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Végezzen némi munkát itt...

    // Mentse a prezentációt egy fájlba.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bemutatók mentése folyamokba**

A bemutatót egy folyamra mentheted, ha egy kimeneti folyamot adsz át a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztály `save` metódusának. A bemutató számos folyamtípusba írható. Az alábbi példában egy új bemutatót hozunk létre, és azt egy fájlfolyamban mentjük.

```js
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Mentse a prezentációt a folyamba.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Bemutatók mentése előre meghatározott nézettípussal**

Az Aspose.Slides lehetővé teszi, hogy beállítsd a PowerPoint által a generált bemutató megnyitásakor használt kezdeti nézetet a [ViewProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/) osztály segítségével. Használd a [setLastView](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/#setLastView) metódust a [ViewType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewtype/) felsorolásból származó értékkel.

```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bemutatók mentése szigorú Office Open XML formátumban**

Az Aspose.Slides lehetővé teszi, hogy a bemutatót szigorú Office Open XML formátumban mentsd. Használd a [PptxOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxoptions/) osztályt, és állítsd be a `conformance` tulajdonságot a mentéskor. Ha a [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) értéket használod, a kimeneti fájl szigorú Office Open XML formátumban lesz mentve.

Az alábbi példa létrehoz egy bemutatót, és azt szigorú Office Open XML formátumban menti.

```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Mentse a prezentációt a szigorú Office Open XML formátumban.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Bemutatók mentése Office Open XML formátumban ZIP64 módban**

Az Office Open XML fájl egy ZIP archívum, amely 4 GB (2^32 bájt) korlátot szab a kicsomagolt fájlméretre, a tömörített fájlméretre és az archívum teljes méretére, illetve 65 535 (2^16‑1) fájlra korlátozza. A ZIP64 formátumkiterjesztések ezeket a korlátokat 2^64‑re emelik.

A [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) metódus lehetővé teszi, hogy kiválaszd, mikor használd a ZIP64 formátumkiterjesztéseket Office Open XML fájl mentésekor.

Ez a metódus a következő módokkal használható:

- [IfNecessary](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/zip64mode/#IfNecessary) csak akkor használja a ZIP64 kiterjesztéseket, ha a bemutató meghaladja a fenti korlátokat. Ez az alapértelmezett mód.
- [Never](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/zip64mode/#Never) soha nem használja a ZIP64 kiterjesztéseket.
- [Always](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/zip64mode/#Always) mindig használja a ZIP64 kiterjesztéseket.

Az alábbi kód bemutatja, hogyan menthető a bemutató PPTX formátumban ZIP64 kiterjesztésekkel engedélyezve:

```js
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
Amikor a [Zip64Mode.Never](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/zip64mode/#Never) módot használod, egy [PptxException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxexception/) kerül dobásra, ha a bemutatót ZIP32 formátumban nem lehet menteni.
{{% /alert %}}

## **Bemutatók mentése a bélyegkép frissítése nélkül**

A [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) metódus szabályozza a bélyegkép generálását PPTX formátumba mentéskor:

- Ha `true` értékre van állítva, a bélyegkép frissül a mentés során. Ez az alapértelmezett.
- Ha `false` értékre van állítva, az aktuális bélyegkép megmarad. Ha a bemutatónak nincs bélyegképe, akkor nem kerül generálásra.

Az alábbi kódban a bemutató PPTX formátumban kerül mentésre a bélyegkép frissítése nélkül.

```js
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
Ez az opció segít csökkenteni a PPTX formátumba való mentéshez szükséges időt.
{{% /alert %}}

## **Mentési előrehaladás jelentése százalékban**

A mentési előrehaladás jelentését a [SaveOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveoptions/) és alosztályainak [setProgressCallback](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) metódusa konfigurálja. Adj meg egy Java proxy-t, amely megvalósítja az [IProgressCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprogresscallback/) interfészt; az exportálás során a callback periódusos százalékos frissítéseket kap.

Az alábbi kódrészletek mutatják, hogyan használható az `IProgressCallback`.

```javascript
const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Használja itt a készültségi százalékértéket.
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
Az Aspose egy [ingyenes PowerPoint Splitter alkalmazást](https://products.aspose.app/slides/hu/splitter) fejlesztett ki saját API-jával. Az alkalmazás lehetővé teszi, hogy a bemutatót több fájlra bontsd, a kiválasztott diák új PPTX vagy PPT fájlokként történő mentésével.
{{% /alert %}}

## **GYIK**

**Támogatja-e a „gyors mentést” (inkrementális mentés), amely csak a változásokat írja?**  

Nem. A mentés minden alkalommal a teljes célfájlt hozza létre; az inkrementális „gyors mentés” nincs támogatva.

**Biztonságos-e ugyanannak a Presentation példánynak a mentése több szálról?**  

Nem. A [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példány **nem szálbiztos** (/slides/hu/nodejs-java/multithreading/); csak egy szálról kell menteni.

**Mi történik a hiperhivatkozásokkal és a külsőleg linkelt fájlokkal mentéskor?**  

A [Hyperlinks](/slides/hu/nodejs-java/manage-hyperlinks/) megmaradnak. A külsőleg linkelt fájlok (például relatív útvonalon hivatkozott videók) nem kerülnek automatikusan másolásra – biztosítsd, hogy a hivatkozott útvonalak továbbra is elérhetők legyenek.

**Beállítható/menthető-e a dokumentum metaadata (Szerző, Cím, Cég, Dátum)?**  

Igen. A szabványos [document properties](/slides/hu/nodejs-java/presentation-properties/) támogatott, és a mentéskor a fájlba lesznek írva.