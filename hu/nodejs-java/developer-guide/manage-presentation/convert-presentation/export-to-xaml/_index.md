---
title: Prezentációk exportálása XAML-be JavaScriptben
linktitle: Prezentáció XAML-be
type: docs
weight: 30
url: /hu/nodejs-java/export-to-xaml/
keywords:
- PowerPoint exportálása
- OpenDocument exportálása
- prezentáció exportálása
- PowerPoint átalakítása
- OpenDocument átalakítása
- prezentáció átalakítása
- PowerPoint XAML-be
- OpenDocument XAML-be
- prezentáció XAML-be
- PPT XAML-be
- PPTX XAML-be
- ODP XAML-be
- PPT mentése XAML-ként
- PPTX mentése XAML-ként
- ODP mentése XAML-ként
- PPT exportálása XAML-be
- PPTX exportálása XAML-be
- ODP exportálása XAML-be
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint és OpenDocument diákat konvertál XAML-be JavaScriptben az Aspose.Slides segítségével – gyors, Office-mentes megoldás, amely megőrzi az elrendezését."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan exportálhatók a PowerPoint‑prezentációk XAML formátumba az Aspose.Slides segítségével. Rövid bevezetést ad a XAML‑ról, megmutatja, hogyan menthető el egy prezentáció XAML‑ként alapértelmezett beállításokkal, és bemutatja, hogyan szabható testre az export a [XamlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/xamloptions/) használatával, beleértve a rejtett diák exportálását is. A cikk néhány gyakori kérdésre is válaszol a helyettesítő betűtípusokkal, a XAML‑verem kompatibilitásával és a rejtett diák export viselkedésével kapcsolatban.

## **A XAML‑ról**

A XAML egy XML‑alapú jelölőnyelv, amelyet felhasználói felületek leírására használnak olyan keretrendszerekben, mint a WPF (Windows Presentation Foundation), az UWP (Universal Windows Platform) és a Xamarin.Forms.

A XAML‑fájlokkal dolgozhat vizuális tervezőben, vagy közvetlenül szerkesztheti a jelölőnyelvet.

## **Prezentációk exportálása XAML‑ba alapértelmezett beállításokkal**

Az alábbi JavaScript‑példa bemutatja, hogyan exportálható egy prezentáció XAML‑ba alapértelmezett beállításokkal:

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

Alapértelmezés szerint az exportált diák az `input` almappába kerülnek a folyamat aktuális munkakönyvtárában. A mappa automatikusan létrejön, és a szükséges képek is oda kerülnek.

A kimeneti mappa neve a forrásfájl neve kiterjesztés nélkül kerül meghatározásra. Az Aspose.Slides for Node.js via Java 26.8 esetén a `input.pptx` exportálása egy beágyazott útvonalat hoz létre, például `input/input/Slide_1.xaml`. A generált teljes útvonalakat meg kell őrizni a kimenet kezelése során. Az alapértelmezett kimenet a jelenlegi munkakönyvtárhoz relatív, nem feltétlenül a bemeneti fájl mellett.

## **Prezentációk exportálása XAML‑ba egyéni beállításokkal**

Használja a [IXamlOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ixamloptions/) interfészt annak szabályozásához, hogy az Aspose.Slides hogyan exportálja a prezentációt XAML‑ba.

A kimenet egyedi helyre történő mentéséhez valósítsa meg a [IXamlOutputSaver](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ixamloutputsaver/) interfészt, és adja át a megvalósítás példányát a [setOutputSaver](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) metódusnak a [XamlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/xamloptions/) objektumból.

A rejtett diák XAML‑kimenetbe való felvételéhez hívja meg a [setExportHiddenSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) metódust `true` értékkel, ahogy az alábbi JavaScript‑példában látható:

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

## **Az összes generált XAML‑eszköz elfogása**

Az XAML‑exportálás minden exportált dia esetén XAML‑dokumentumot, valamint különálló képeket és támogató erőforrásokat hozhat létre. Rendeljen egy egyéni [IXamlOutputSaver](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ixamloutputsaver/) példányt a [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) metódushoz, hogy ezeket az eszközöket a alapértelmezett fájlrendszer‑mentő helyett megkapja. Indítsa el az exportálást a XAML‑specifikus [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) túlterheléssel, amely XAML‑beállításokat fogad.

Node.js‑ben valósítsa meg a Java interfészt a `java.newProxy`‑val a Aspose.Slides által használt `java` csomagból. Tartsa a proxyt elérhető állapotban, amíg az export be nem fejeződik.

### **A visszahívási életciklus megértése**

Az exportáló külön-külön meghívja az [IXamlOutputSaver.save](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) metódust minden egyes generált eszközre:

- `path` azonosítja az eszközt, és tartalmazhat relatív könyvtárakat. Ezt az információt meg kell őrizni, mert a XAML relatív útvonalak segítségével hivatkozhat erőforrásokra.
- `data` tartalmazza az eszköz bájtjait. A képeket és egyéb bináris erőforrásokat nem szabad szövegként dekódolni.
- A mentő feladata, hogy a visszaadása előtt megtartsa vagy perzisztálja az adatokat. A példák minden Java‑byte‑tömböt egy alkalmazás által birtokolt Node.js bufferbe másolnak.
- Az export sikeresnek tekinthető csak akkor, ha a prezentáció mentési művelete visszatér, és minden visszahívás sikeresen befejeződött. Ne nyeljen el tárolási hibákat, és ne indítson megfigyelés nélküli háttér‑írásokat. Ha a perzisztálás utólag történik, a teljes sikerességet csak akkor jelentse, ha ez a lépés is sikeres.

A [XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) szintén érvényes egy egyéni mentőre. Az alapértelmezett beállítás, `false`, kizárja a rejtett dia XAML‑dokumentumait. `true` átadása felveszi őket, valamint minden exportáláshoz szükséges erőforrást. Az erőforrások száma a prezentációtól függ; ne feltételezze, hogy egy visszahívás dia‑onként vagy fix sorrendben történik.

### **Exportálás memóriába és az eszközök ellenőrzése**

Ez a teljes példa betölti a `input.pptx`‑t, minden eszközt egy JavaScript‑térképre (név → buffer) gyűjt, és kiírja a nevét, típusát és bájtszámát. A megadott neveket pontosan megőrzi. Azonos nevek esetén a gyűjtemény érvénytelennek minősül, ahelyett, hogy csendben felülírná az eszközt. A példa ellenőrzi ezt, mielőtt a visszatérő értékeket felhasználná.

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

        // Csak a XAML-t dekódolja, és csak akkor, ha szöveges vizsgálatra van szükség.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

A kiterjesztés‑ellenőrzések hasznosak az ellenőrzéshez; őrizze meg az összes eszközt, beleértve a kevésbé ismert erőforrás‑típusokat is. A tárolás vagy továbbítás során ne módosítsa a bájtokat. Az UTF‑8 dekódolást csak akkor használja, ha a XAML‑szöveget kell feldolgozni.

### **Gyűjtött eszközök csomagolása ZIP‑archívumba**

Ez a független példa összegyűjti az exportot, ellenőrzi a neveket, és az eredeti bájtokat egy Java‑híd segítségével ZIP‑archívumba írja. A ZIP memóriában áll elő, mielőtt lemezre kerülne. Egy egyedi archívumnév elválasztja a párhuzamos exportfeladatokat. A ZIP‑bejegyzések szereplő perjel („/”) karaktert használják, és megőrzik a relatív könyvtárakat. Nem megfelelő vagy normalizálás után ütköző nevek esetén az egész csomag elutasításra kerül, mielőtt írásra kerülne.

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
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // A zárás befejezi a ZIP könyvtárat, mielőtt az archívum mentésre kerül.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

A példa a [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) osztályt használja egy helyi archívum írásához; az exportáló maga nem ír széttagolt XAML‑ vagy kép‑fájlokat. Távoli tároláshoz cserélje le az archívum‑írási lépést a gyűjtött bájt‑tömbök feltöltésére. Használjon egy export‑feladat‑azonosítót és a teljes relatív eszköznevet blob‑kulcsként, vagy tárolja a feladat‑azonosítót, a relatív nevet és a bináris adatot egy adatbázis‑sorban. A feladatot csak akkor tegye közzé, miután minden feltöltés befejeződött vagy a tranzakció elköteleződött. Ha a perzisztálás sikertelen, tisztítsa meg a részleges kimenetet.

Nagy prezentációk esetén egy egyéni mentő közvetlenül az alkalmazás‑tárolóba mentheti az egyes eszközöket, elkerülve a teljes export egy további példányának memóriában tartását. Tartsa minden visszahívást szinkronban az exportáló szemszögéből: csak akkor térjen vissza, amikor a célpont elfogadta a bájtokat, és engedje, hogy a hibák elérjék a hívót.

### **Erőforrásnevek megőrzése és hivatkozások ellenőrzése**

- Normalizálja az útvonal‑elválasztókat, ha a célhely megköveteli, de őrizze meg a relatív könyvtárakat. Ne csak az alapnevet használja, hacsak nem biztos, hogy minden generált név egyedi, és a hivatkozások érvényesek maradnak.
- Alkalmazzon célspecifikus név‑validációt. Szétállomány‑írásnál utasítsa el a gyökér‑útvonalakat és a traversális szegmenseket, oldja fel a célhelyet abszolút úttá, és ellenőrizze, hogy az a kívánt exportkönyvtár alatt marad‑e, beleértve az útvonal‑elválasztót is a tartalmazási ellenőrzésben. Használjon alkalmazás‑vezérelt könyvtárat szimbolikus linkek nélkül, amelyek átirányíthatják az írásokat.
- Minden exportfeladathoz használjon külön mentőt és tárolási névtér‑kört. Ütközéseket detektáljon az elválasztó‑normalizálás után, és a célhely esetleges nagy‑/kisbetű‑érzékenységének szabályai szerint.
- Közzététel előtt parse-olja minden XAML‑dokumentumot XML‑ként, és ellenőrizze a fájl‑alapú erőforrás‑hivatkozásokat, például az `Image` `Source` vagy `ImageSource` attribútumokat. Oldja fel minden relatív URI‑t a tartalmazó XAML‑eszköz könyvtára alapján, normalizálja a kapott tárolási nevet, és erősítse meg, hogy a megfelelő térkép‑kulcs, ZIP‑bejegyzés vagy tárolt objektum létezik. Kezelje külön a külső URI‑kat és a XAML‑kifejezéseket a relatív fájlnevektől.

Például, ha az `input/Slide_1.xaml` a `images/image1.png`‑re hivatkozik, a tárolt erőforrásnak `input/images/image1.png` néven kell elérhetőnek lennie. A `image1.png` csak tárolása megtöri a kapcsolatot. Objektumtárolás esetén őrizze meg ugyanazt a struktúrát a feladat‑előtag alatt, és tegye elérhetővé ezeket az URL‑eket a XAML‑fogyasztó számára. Nyissa meg a kész ZIP‑et az entry‑nevek és erőforrás‑bájtok ellenőrzéséhez, és töltsön be reprezentatív diákat a cél‑XAML környezetben, hogy megerősítse a képek helyes feloldását.

## **GYIK**

**Hogyan biztosítható a prediktív betűtípus, ha az eredeti betűtípus nem érhető el a gépen?**

Hívja meg a [setDefaultRegularFont](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) metódust a [XamlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/xamloptions/) objektumban – ez a fallback betűtípusként kerül felhasználásra az exportálás során, ha az eredeti hiányzik. Ez nem garantálja, hogy a generált XAML a fallback betűtípust használja, vagy hogy a betűtípus elérhető a célgépen. Győződjön meg róla, hogy a XAML által hivatkozott betűtípusok elérhetők abban a környezetben, ahol megjelenik.

**Az exportált XAML csak WPF‑hez szánt, vagy más XAML‑veremekben is használható?**

Az Aspose.Slides a WPF XAML‑t exportálja a nyilvános API‑ján keresztül. Más XAML‑veremekkel, például az UWP‑vel vagy a Xamarin.Forms‑szal való kompatibilitás nem garantált. Tesztelje a generált jelölőnyelvet a célkörnyezetben.

**Támogatottak a rejtett diák, és hogyan akadályozható meg, hogy alapértelmezés szerint exportálódjanak?**

Alapértelmezés szerint a rejtett diák nincsenek benne. Ezt a viselkedést a [setExportHiddenSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) metódussal szabályozhatja a [XamlOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/xamloptions/) objektumban – tartsa letiltva, ha nem szeretné exportálni őket.