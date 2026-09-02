---
title: PowerPoint Betűtípusok testreszabása JavaScript-ben
linktitle: Egyéni Betűtípus
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
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Testreszabhatja a betűtípusokat a PowerPoint diáknál JavaScript és az Aspose.Slides for Node.js Java segítségével, hogy előadásai élesek és következetesek legyenek minden eszközön."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi egyéni betűtípusok használatát a bemutatókban anélkül, hogy az operációs rendszerre telepítené őket. Betűtípusokat betölthetsz egyéni mappákból, megadhatsz betűtípusokat egy adott bemutatóhoz a dokumentumszintű betűforrások segítségével, vagy külső betűtípusokat tölthetsz be közvetlenül bináris adatokból.

A betöltött betűtípusok a bemutató renderelésekor vagy exportálásakor kerülnek felhasználásra, például PDF, képek és más támogatott formátumok esetén. Ez segít abban, hogy a bemutató kimenete különböző környezetekben is egységes maradjon. Ez a cikk azt is bemutatja, hogyan ellenőrizheted az Aspose.Slides által használt betűtípus-mappákat, és hogyan törölheted a betűtípus-gyorsítót a külső betűtípusok használata után.

Az egyéni betűtípusok regisztrálása a rendereléshez elkülönül a betűtípusok PPTX fájlba ágyazásától. Ha egy betűtípust a bemutatóba kell ágyazni, használja a betűtípuságyazási funkciókat kifejezetten.

Az előadás témája különböző betűcsaládokra hivatkozhat az egyes írásrendszerekhez. Ezek a leképezések csak betűtípusneveket tárolnak, de nem telepítik vagy töltik be a betűtípusfájlokat. Tekintsd meg a [Script-Specific Theme Fonts](/slides/hu/nodejs-java/script-specific-font-mappings/) oldalt a leképezések kezeléséhez, és használd az alábbi betöltési beállításokat, hogy a hivatkozott betűtípusok elérhetők legyenek az egységes rendereléshez.

{{% alert color="info" title="Note" %}}
Az Aspose Slides lehetővé teszi ezen betűtípusok betöltését a [loadExternalFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) metódus segítségével:

* TrueType (.ttf) és TrueType Collection (.ttc) betűtípusok. Lásd a [TrueType](https://en.wikipedia.org/wiki/TrueType) oldalt.

* OpenType (.otf) betűtípusok. Lásd a [OpenType](https://en.wikipedia.org/wiki/OpenType) oldalt.
{{% /alert %}}

## **Egyéni betűtípusok betöltése**

Az Aspose.Slides lehetővé teszi a bemutatóban használt betűtípusok betöltését anélkül, hogy telepítené őket a rendszerre. Ez befolyásolja az export kimenetét – például PDF, képek és más támogatott formátumok –, így a létrehozott dokumentumok különböző környezetekben is egységesnek tűnnek. A betűtípusok egyéni könyvtárakból töltődnek be.

1. Adj meg egy vagy több mappát, amely a betűtípusfájlokat tartalmazza.
2. Hívd meg a statikus [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) metódust a betűtípusok betöltéséhez a megadott mappákból.
3. Töltsd be és rendereld/exportáld a bemutatót.
4. Hívd meg a [FontsLoader.clearCache](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/clearcache/) metódust a betűtípus-gyorsítót törléséhez.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Határozd meg az egyéni betűtípusfájlokat tartalmazó mappákat.
let externalFontFolder1 = "fonts";
let externalFontFolder2 = "extra-fonts";
let fontFolders = java.newArray("java.lang.String", [externalFontFolder1, externalFontFolder2]);

// Töltsd be az egyéni betűtípusokat a megadott mappákból.
aspose.slides.FontsLoader.loadExternalFonts(fontFolders);

let presentation = null;
try {
    presentation = new aspose.slides.Presentation("sample.pptx");
    
    // Rendereld/exportáld a bemutatót (pl. PDF-be, képekbe vagy más formátumokba) a betöltött betűtípusok használatával.
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();

    // Töröld a betűtípus gyorsítótárát a munka befejezése után.
    aspose.slides.FontsLoader.clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/loadexternalfonts/) további mappákat ad a betűtípus-keresési útvonalakhoz, de nem módosítja a betűtípusok inicializálási sorrendjét.
A betűtípusok ebben a sorrendben inicializálódnak:

1. Az alapértelmezett operációs rendszer betűtípus útvonala.
1. A [FontsLoader](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/) által betöltött útvonalak.
{{%/alert %}}

## **Egyéni betűtípusok mappájának lekérése**
Az Aspose.Slides a [getFontFolders](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) metódust biztosítja, amely lehetővé teszi a betűtípus-mappák megtalálását. Ez a metódus visszaadja a `LoadExternalFonts` metódus által hozzáadott mappákat és a rendszer betűtípus-mappákat.

Ez a JavaScript kód bemutatja, hogyan használhatod a [getFontFolders](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/#getFontFolders--) metódust:
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Ez a sor kiírja azokat a mappákat, ahol a betűtípusfájlok keresése történik.
// Ezek a LoadExternalFonts metódussal hozzáadott és a rendszer betűtípus mappái.
var fontFolders = aspose.slides.FontsLoader.getFontFolders();
```

## **Egyéni betűtípusok megadása a bemutatóhoz**
Az Aspose.Slides a [setDocumentLevelFontSources](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/#setDocumentLevelFontSources-aspose.slides.IFontSources-) tulajdonságot biztosítja, amely lehetővé teszi, hogy külső betűtípusokat adj meg a bemutatóhoz.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var memoryFont1 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont1.ttf"));
var memoryFont2 = java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "customfonts/CustomFont2.ttf"));
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getDocumentLevelFontSources().setFontFolders(java.newArray("java.lang.String", ["assets/fonts", "global/fonts"]));
loadOptions.getDocumentLevelFontSources().setMemoryFonts(java.newArray("[B", [java.newArray("byte", ["item1", "item2", "item3"])]));
var pres = new aspose.slides.Presentation("MyPresentation.pptx", loadOptions);
try {
    // Munkát végez a bemutatóval
    // A CustomFont1, CustomFont2, valamint az assets\fonts & global\fonts mappákból és azok almappáiból származó betűtípusok elérhetők a bemutató számára
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Betűtípusok külső kezelése**
Az Aspose.Slides a [loadExternalFont](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) metódust biztosítja, amely lehetővé teszi a külső betűtípusok betöltését bináris adatokból.
```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALN.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNBI.TTF")));
java.callStaticMethodSync("com.aspose.slides.FontsLoader", "loadExternalFonts", java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "ARIALNI.TTF")));
try {
    var pres = new aspose.slides.Presentation("");
    try {
        // külső betűtípus betöltve a bemutató élettartama alatt
    } finally {
    }
} finally {
    java.callStaticMethodSync("com.aspose.slides.FontsLoader", "clearCache");
}
```

## **GYIK**

### Az egyéni betűtípusok befolyásolják az exportálást minden formátumra (PDF, PNG, SVG, HTML)?
Igen. A csatlakoztatott betűtípusokat a renderelő használja az összes export formátumban.

### Az egyéni betűtípusok automatikusan beágyazódnak a létrehozott PPTX-be?
Nem. Egy betűtípus regisztrálása a rendereléshez nem ugyanaz, mint a betűtípus beágyazása egy PPTX-be. Ha a betűtípust a bemutató fájljába szeretnéd ágyazni, használni kell a kifejezett [embedding features](/slides/hu/nodejs-java/embedded-font/) funkciókat.

### Ellenőrizhetem a helyettesítő viselkedést, ha egy egyéni betűtípus bizonyos glifekkel nem rendelkezik?
Igen. Konfiguráld a [font substitution](/slides/hu/nodejs-java/font-substitution/), [replacement rules](/slides/hu/nodejs-java/font-replacement/) és [fallback sets](/slides/hu/nodejs-java/fallback-font/) beállításokat, hogy pontosan meghatározd, melyik betűtípust kell használni, ha a kért glif hiányzik.

### Használhatok betűtípusokat Linux/Docker konténerekben anélkül, hogy a rendszer szintjén telepíteném őket?
Igen. Mutass a saját betűtípus-mappáidra, vagy tölts betűtípusokat byte tömbökből. Ez eltávolít minden függőséget a konténer képen lévő rendszer betűtípus könyvtáraktól.

### Mi a helyzet a licenceléssel – beágyazhatok bármilyen egyéni betűtípust korlátozások nélkül?
A te felelősséged a betűtípusok licencelésének betartása. A feltételek változóak; egyes licencek tiltják a beágyazást vagy a kereskedelmi felhasználást. Mindig ellenőrizd a betűtípus EULA‑ját a kimenetek terjesztése előtt.