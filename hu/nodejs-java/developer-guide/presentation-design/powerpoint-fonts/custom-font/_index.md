---
title: PowerPoint betűtípusok testreszabása JavaScript-ben
linktitle: Egyéni betűtípus
type: docs
weight: 20
url: /hu/nodejs-java/custom-font/
keywords:
- betűtípus
- egyéni betűtípus
- külső betűtípus
- betűtípus betöltése
- betűtípusok kezelése
- betűtípus mappa
- PowerPoint
- OpenDocument
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Testreszabja a PowerPoint diák betűtípusait JavaScript és a Node.js-hez készült Aspose.Slides Java segítségével, hogy bemutatói élesek és következetesek legyenek minden eszközön."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy egyéni betűtípusokat használjon a bemutatókban anélkül, hogy azokat az operációs rendszerre telepítené. Betűtípusokat tölthet be egyéni mappákból, megadhat betűtípusokat egy adott bemutatóhoz dokumentumszintű betűtípusforrások segítségével, vagy külső betűtípusokat tölthet be közvetlenül bináris adatokból.

A betöltött betűtípusok a bemutató renderelése vagy exportálása során kerülnek felhasználásra, például PDF, képek és egyéb támogatott formátumok esetén. Ez segít abban, hogy a bemutató kimenete egységes maradjon a különböző környezetekben. A cikk bemutatja, hogyan ellenőrizheti az Aspose.Slides által használt betűtípus-mappákat, és hogyan törölheti a betűtípus-gyorsítót a külső betűtípusok használata után.

Az egyéni betűtípusok regisztrálása a rendereléshez különálló a betűtípusok PPTX fájlba ágyazásától. Ha egy betűtípust a bemutatóban kell tárolni, használja a betűtípus-ágyazási funkciókat kifejezetten.

{{% alert color="primary" %}} 

Az Aspose Slides lehetővé teszi, hogy ezeket a betűtípusokat a [loadExternalFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódussal töltse be:

* TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd [TrueType](https://en.wikipedia.org/wiki/TrueType).

* OpenType (.otf) betűtípusok. Lásd [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Egyéni betűtípusok betöltése**

Az Aspose.Slides lehetővé teszi, hogy a bemutatóban használt betűtípusokat a rendszer telepítése nélkül töltse be. Ez befolyásolja az export kimenetét – például PDF, képek és egyéb támogatott formátumok – így a létrehozott dokumentumok egységesek maradnak a különböző környezetekben. A betűtípusok egyéni könyvtárakból töltődnek be.

1. Adja meg a betűtípus-fájlokat tartalmazó egy vagy több mappát.
2. Hívja meg a statikus [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) metódust a betűtípusok betöltéséhez ezekből a mappákból.
3. Töltse be és renderelje/exportálja a bemutatót.
4. Hívja meg a [FontsLoader.clearCache](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/clearcache/) metódust a betűtípus-gyorsító törléséhez.

A következő kódrészlet bemutatja a betűtípus betöltésének folyamatát:

```js
// Határozza meg az egyéni betűtípus fájlokat tartalmazó mappákat.
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Töltsön be egyéni betűtípusokat a megadott mappákból.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Renderelje/exportálja a bemutatót (például PDF, képek vagy egyéb formátumok) a betöltött betűtípusok használatával.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Törölje a betűtípus-gyorsítót a munka befejezése után.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}

A [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) további mappákat ad a betűtípus-keresési útvonalakhoz, de nem módosítja a betűtípusok inicializálási sorrendjét.  
A betűtípusok e sorrendben inicializálódnak:

1. Az operációs rendszer alapértelmezett betűtípus-útvonala.
1. A [FontsLoader](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/) által betöltött útvonalak.

{{%/alert %}}

## **Egyéni betűtípus mappák lekérése**
Az Aspose.Slides a [getFontFolders](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) metódust biztosítja, amely lehetővé teszi a betűtípus-mappák megtalálását. Ez a metódus visszaadja a `LoadExternalFonts` metódussal hozzáadott és a rendszer betűtípus-mappáit.

Ez a JavaScript-kód megmutatja, hogyan használja a [getFontFolders](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/#getFontFolders--):

```javascript
// Ez a sor kiírja azokat a mappákat, ahol a betűtípus fájlok keresésre kerülnek.
// Ezek a LoadExternalFonts metódussal hozzáadott és a rendszer betűtípus mappái.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Egyéni betűtípusok megadása a bemutatóval**
Az Aspose.Slides a [setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) tulajdonságot biztosítja, amely lehetővé teszi, hogy külső betűtípusok legyenek megadva a bemutatóhoz.

Ez a JavaScript-kód megmutatja, hogyan használja a [setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) tulajdonságot:

```javascript
var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Dolgozzon a prezentációval
    // A CustomFont1, a CustomFont2, valamint az assets\fonts és a global\fonts mappák (és alkönyvtáraik) betűtípusai elérhetők a prezentációban
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Betűtípusok kezelése külsőleg**

Az Aspose.Slides a [loadExternalFont](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) metódust biztosítja, amely lehetővé teszi a külső betűtípusok betöltését bináris adatokból.

Ez a JavaScript-kód bemutatja a bájt tömbből történő betűtípus betöltésének folyamatát:

```javascript
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // külső betűtípus betöltve a prezentáció élettartama alatt
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **GYIK**

**Hatnak az egyéni betűtípusok az exportálásra minden formátumban (PDF, PNG, SVG, HTML)?**

Igen. A kapcsolódó betűtípusok a renderelő által minden export formátumban felhasználásra kerülnek.

**Ágyazódnak automatikusan az egyéni betűtípusok a létrehozott PPTX-be?**

Nem. Egy betűtípus regisztrálása a rendereléshez nem ugyanaz, mint annak PPTX-be ágyazása. Ha a betűtípust a bemutató fájlban szeretné megtartani, kifejezetten használnia kell a [beágyazási funkciókat](/slides/hu/nodejs-java/embedded-font/).

**Kezelhetem a tartalék viselkedést, ha egy egyéni betűtípusnál hiányoznak bizonyos glyfek?**

Igen. Konfigurálja a [betűtípushelyettesítést](/slides/hu/nodejs-java/font-substitution/), a [csere szabályokat](/slides/hu/nodejs-java/font-replacement/), és a [tartalék készleteket](/slides/hu/nodejs-java/fallback-font/), hogy pontosan meghatározza, melyik betűtípus legyen használva, amikor a kért glif hiányzik.

**Használhatok betűtípusokat Linux/Docker konténerekben anélkül, hogy rendszer-szintűen telepíteném őket?**

Igen. Mutasson saját betűtípus-mappákra vagy töltse be a betűtípusokat bájt tömbökből. Ez eltávolít minden függőséget a rendszer betűtípus könyvtáraktól a konténer képen.

**Mi a helyzet a licenceléssel – beágyazhatok bármilyen egyéni betűtípust korlátozások nélkül?**

Ön felelős a betűtípus-licencelés betartásáért. A feltételek változóak; egyes licencek tiltják az ágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizze a betűtípus EULA-ját, mielőtt a kimenetet terjesztené.