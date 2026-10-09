---
title: "Prezentációk exportálása XAML-be JavaScriptben"
linktitle: "Prezentáció XAML-be"
type: docs
weight: 30
url: /hu/nodejs-java/export-to-xaml/
keywords:
- "PowerPoint exportálása"
- "OpenDocument exportálása"
- "prezentáció exportálása"
- "PowerPoint konvertálása"
- "OpenDocument konvertálása"
- "prezentáció konvertálása"
- "PowerPoint XAML-be"
- "OpenDocument XAML-be"
- "prezentáció XAML-be"
- "PPT XAML-be"
- "PPTX XAML-be"
- "ODP XAML-be"
- "PPT mentése XAML-ként"
- "PPTX mentése XAML-ként"
- "ODP mentése XAML-ként"
- "PPT exportálása XAML-be"
- "PPTX exportálása XAML-be"
- "ODP exportálása XAML-be"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "PowerPoint és OpenDocument diákat konvertál XAML-be JavaScriptben az Aspose.Slides használatával – gyors, Office-független megoldás, amely megőrzi a megjelenést."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet a PowerPoint‑prezentációkat XAML formátumba exportálni az Aspose.Slides használatával. Tartalmaz egy rövid bevezetést a XAML‑be, bemutatja, hogyan lehet egy prezentációt alapértelmezett beállításokkal XAML‑be menteni, és megmutatja, hogyan lehet testreszabni az exportálást a [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) segítségével, beleértve a rejtett diák exportálását is. A cikk továbbá válaszol néhány gyakori kérdésre, amelyek a tartalék betűtípusokra, a XAML verem kompatibilitásra és a rejtett diák export viselkedésére vonatkoznak.

## **A XAML**

A XAML egy XML‑alapú jelölőnyelv, amelyet a felhasználói felületek leírására használnak olyan keretrendszerekben, mint a WPF (Windows Presentation Foundation), az UWP (Universal Windows Platform) és a Xamarin.Forms.

XAML‑fájlokkal vizuális tervezőben dolgozhatsz, vagy közvetlenül írhatod és szerkesztheted a jelölést.

## **Exportálás prezentációk XAML‑be alapértelmezett beállításokkal**

Az alábbi JavaScript példa bemutatja, hogyan lehet egy prezentációt alapértelmezett beállításokkal XAML‑be exportálni:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Alapértelmezés szerint az exportált diák a folyamat aktuális munkakönyvtárának `input` almappájába kerülnek mentésre. A mappa automatikusan létrejön, és a szükséges képek is oda kerülnek mentésre.

A kimeneti mappa neve a forrásfájl nevéből származik a kiterjesztés nélkül. Az Aspose.Slides for Node.js via Java 26.8 verzióban az `input.pptx` exportálása olyan beágyazott útvonalat eredményez, mint `input/input/Slide_1.xaml`. Kezeléskor őrizd meg a teljes generált útvonalakat. Az alapértelmezett kimenet a jelenlegi munkakönyvtárhoz relatív, nem feltétlenül a bemeneti fájl mellett.

## **Exportálás prezentációk XAML‑be egyéni beállításokkal**

Használd az [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/) interfészt az Aspose.Slides exportálásának XAML‑be történő vezérléséhez.

A kimenet egyedi helyre mentéséhez implementáld a [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) interfészt, és add át implementációd példányát a [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) metódusnak a [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) osztályból.

A rejtett diák XAML kimenetbe való belefoglalásához hívd meg a [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) metódust `true` értékkel, ahogyan az alábbi JavaScript példában látható:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Az összes generált XAML‑eszköz rögzítése**

A XAML exportálás minden egyes exportált diához XAML dokumentumot, valamint különálló képeket és támogatási erőforrásokat hozhat létre. Adj egy egyéni [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) példányt a [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) metódusnak, hogy ezeket az eszközöket a default fájlrendszeres mentő helyett kapd meg. Indítsd az exportálást a XAML‑specifikus [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) túlterheléssel, amely XAML beállításokat fogad.

Node.js‑ben a Java interfészt a `java.newProxy` segítségével valósítsd meg a Aspose.Slides által használt `java` csomagból. Tartsd a proxy‑t elérhető állapotban, amíg az exportálás be nem fejeződik.

### **A visszahívási életciklus megértése**

Az exportáló a [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) metódust külön‑külön hívja minden egyes generált eszközhöz:

- `path` azonosítja az eszközt, és tartalmazhat relatív könyvtárakat. Tartsd meg ezt az információt, mert a XAML relatív útvonalakat használhat az erőforrásokra hivatkozva.
- `data` tartalmazza az eszköz bájtjait. A képeket és egyéb bináris erőforrásokat nem szabad szövegként dekódolni.
- A mentő felelős a data megtartásáért vagy tartósítért a visszatérés előtt. A példák minden Java byte tömböt egy alkalmazás által birtokolt Node.js pufferbe másolnak.
- Az exportálást csak akkor tekintsd sikeresnek, ha a prezentáció mentési művelete visszatér, és minden visszahívás sikeresen befejeződött. Ne nyelj el tárolási hibákat, és ne indíts nem felügyelt háttérírásokat. Ha a tartósítás később történik, csak akkor jelentsd a teljes sikert, ha az a lépés is sikeres.
- [XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) szintén érvényes egy egyéni mentőre. Az alapértelmezett beállítás, `false`, kizárja a rejtett diák XAML dokumentumait. `true` megadása belefoglalja őket és minden erőforrást, amely az exportálásukhoz szükséges. Az erőforrások száma a prezentációtól függ; ne feltételezd, hogy egy visszahívás van diáronként vagy egy fix sorrend.

### **Exportálás memóriába és az eszközök vizsgálata**

Ez a teljes példa betölti az `input.pptx`‑t, összegyűjti az összes eszközt egy JavaScript térképen, ahol a név a pufferekhez van rendelve, és kiírja a nevét, típusát és bájt számlálóját. Pontosan megőrzi a megadott neveket. A duplikált nevek az összegyűjtést érvénytelennek jelölik ahelyett, hogy csendben felülírnák az eszközt. A példa ezt ellenőrzi a használat előtt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XtraOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // Csak a XAML-t dekódold, és csak akkor, ha szöveges ellenőrzés szükséges.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

A kiterjesztés ellenőrzése hasznos a vizsgálathoz; tartsd meg az összes eszközt, beleértve az ismeretlen erőforrás típusokat is. A bájtokat változatlanul hagyd tároláskor vagy továbbításkor. UTF‑8 dekódolást csak akkor használj, ha a XAML szöveges feldolgozást igényel.

### **Gyűjtött eszközök csomagolása ZIP archívumba**

Ez a független példa összegyűjti az exportot, ellenőrzi a neveket, és az eredeti bájtokat egy ZIP archívumba írja a Java híd segítségével. A ZIP memóriában van összeállítva, mielőtt lemezre mentésre kerülne. Egy egyedi archívum név elválasztja a párhuzamos export feladatokat. A ZIP bejegyzések előre írt perjeleket használnak és megőrzik a relatív könyvtárakat. A nem biztonságos nevek vagy a normalizáció után ütköző nevek elutasítják a teljes csomagot, mielőtt az írásra kerülne.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const bytes = java.newArray("byte", Array.from(data));
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // A zárás véglegesíti a ZIP könyvtárat, mielőtt az archívum mentésre kerül.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

A példa a [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) használatával ír egy helyi archívumot; maga az exportáló nem ír szétvágott XAML vagy kép fájlokat. Távoli tárolás esetén cseréld le az archívumírási lépést a gyűjtött byte tömbök feltöltésére. Használj egy export‑feladat azonosítót a teljes relatív eszköz névvel együtt blob kulcsként, vagy tárold az azonosítót, a relatív nevet és a bináris adatot egy adatbázis sorban. A feladatot csak akkor tedd közzé, ha minden feltöltés befejeződött vagy a tranzakció elköteleződött. Tisztítsd meg a részleges kimenetet, ha a tartósítás sikertelen.

Nagy prezentációk esetén egy egyéni mentő közvetlenül az alkalmazás tárolójába tartósíthatja az egyes eszközöket, ezáltal elkerülve a teljes export további példányának tárolását az alkalmazás memóriájában. Tartsa a visszahívásokat szinkronnak az exportáló szemszögéből: csak akkor térjen vissza, ha a célhely elfogadta a bájtokat, és engedje meg, hogy a hibák eljussanak a hívóhoz.

### **Erőforrásnevek megőrzése és hivatkozások ellenőrzése**

- Normalizáld az útvonal elválasztókat, ha a célhely megköveteli, de őrizd meg a relatív könyvtárakat. Ne csak az alap nevet használd, kivéve ha minden generált név egyedi, és az erőforrás hivatkozások érvényesek maradnak.
- Alkalmazz célhely‑specifikus névvalidációt. Szétvágott fájlok írásakor utasítsd el a gyökér útvonalakat és a traverszálás szegmenseket, oldd fel a célhelyet abszolút úttá, és ellenőrizd, hogy a kívánt export könyvtár alatt marad, beleértve a könyvtár elválasztót a tartalmazási ellenőrzésbe. Használj alkalmazás által vezérelt könyvtárat szimbolikus linkek nélkül, amelyek átír‑ányíthatják a írásokat.
- Használj külön mentőt és tárolási névtérrel minden export feladathoz. Észleld az ütközéseket az elválasztó normalizálása után és a célhely kis‑ és nagybetű érzékenységi szabályai szerint.
- Közzététel előtt parse‑oljuk minden XAML dokumentumot XML‑ként, és ellenőrizzük a fájlalapú erőforrás hivatkozásokat, mint például a kép `Source` vagy `ImageSource` attribútumait. A relatív URI‑kat oldjuk fel a tartalmazó XAML eszköz könyvtárához képest, normalizáljuk a kapott tárolási nevet, és erősítsük meg, hogy a megfelelő térkép kulcs, ZIP bejegyzés vagy tárolt objektum létezik. Kezeld külön a külső URI‑kat és a XAML jelölés kifejezéseket a relatív fájlnevektől.

Például, ha az `input/Slide_1.xaml` a `images/image1.png`‑re hivatkozik, a tárolt erőforrásnak elérhetőnek kell lennie `input/images/image1.png` formában. Csak az `image1.png` megtartása megszakítja ezt a kapcsolatot. Objektumtárolás esetén őrizd meg ugyanazt a struktúrát a feladat előtag alatt, és tedd elérhetővé a XAML fogyasztó számára ezeket az erőforrás URL‑eket. Nyisd újra a kész ZIP‑et a bejegyzés nevek és erőforrás bájtok ellenőrzéséhez, és tölts be reprezentatív diákat a cél XAML környezetben, hogy megerősítsd a képek helyes feloldását.

## **GYIK**

**Hogyan biztosíthatom a kiszámítható betűtípusokat, ha az eredeti betűtípus nincs a gépen?**

Hívd meg a [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) metódust a [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) osztályban — ez a hiányzó eredeti betűtípus helyett tartalék betűtípusként kerül felhasználásra az exportálás során. Ez nem garantálja, hogy a generált XAML hivatkozik a tartalék betűtípusra, vagy hogy a betűtípus elérhető legyen a célgépen. Győződj meg arról, hogy a XAML által hivatkozott betűtípusok elérhetők abban a környezetben, ahol megjelenik.

**A kiexportált XAML csak WPF‑re szánt, vagy más XAML veremekben is használható?**

Az Aspose.Slides a WPF XAML‑t exportálja a publikus API‑ján keresztül. Az kompatibilitás más XAML veremekkel, például az UWP‑vel és a Xamarin.Forms‑zal, nem garantált. Teszteld a generált jelölést a célkörnyezetben.

**Támogatottak a rejtett diák, és hogyan lehet őket alapértelmezetten kizárni az exportálásból?**

Alapértelmezés szerint a rejtett diák nincsenek belefoglalva. Ezt a viselkedést a [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) metódussal a [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) osztályban szabályozhatod — tartsd letiltva, ha nincs szükséged azok exportálására.