---
title: PPT konvertálása PPTX-re Node.js-ben
linktitle: PPT PPTX-re
type: docs
weight: 20
url: /hu/nodejs-java/convert-ppt-to-pptx/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- dia konvertálása
- PPT konvertálása
- PPT PPTX-re
- PPT mentése PPTX-ként
- PPT exportálása PPTX-be
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertálja a régi PPT fájlokat PPTX-re Node.js-ben az Aspose.Slides segítségével. Tartalmaz JavaScript példákat egyedi fájlok és kötegelt konverziók számára, hibakezelésről és pontossági megjegyzésekről."
---
## **Áttekintés**

A PPT a régi bináris PowerPoint formátum, míg a PPTX az újabb Open XML formátum. Az Aspose.Slides for Node.js via Java képes betölteni egy PPT fájlt, és Microsoft PowerPoint nélkül PPTX-ként menteni. Ez a cikk bemutatja, hogyan konvertálhat egy fájlt vagy egy könyvtár fájljait, és elmagyarázza, mit kell ellenőrizni a konvertálás után.

## **PPT fájl konvertálása PPTX-re**

Töltsük be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztállyal, majd hívjuk meg a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveformat/) argumentummal. A `finally` blokk felszabadítja a prezentációt és elengedi annak erőforrásait.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Töltsük be a régi PPT prezentációt.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Mentsük a prezentációt PPTX formátumban.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A fájlkiterjesztés önmagában nem határozza meg a kimeneti formátumot; ezt a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveformat/) argumentum teszi. Tartsa különbözőnek a bemeneti és kimeneti útvonalakat, ha meg szeretné őrizni az eredeti PPT fájlt.

## **Több PPT fájl konvertálása**

Az alábbi példa minden `.ppt` fájlt egy könyvtárban konvertál. Minden fájlt külön‑külön dolgozunk fel, így egy sikertelen konverzió sem állítja le a többieket.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

Éles környezetben naplózza a teljes hibát, döntsön arról, hogy felülírható‑e egy már létező kimeneti fájl, és írja a sikertelen fájlneveket egy újrapróbálási vagy felülvizsgálati sorba. Sérült fájlok, jelszóval védett fájlok, amelyekhez nem a megfelelő jelszó van megadva, elérhetetlen útvonalak és nem támogatott tartalom is okozhat konverziós hibát. Lásd a [Jelszóval védett prezentációk](/nodejs-java/password-protected-presentation/) oldalt a titkosított fájlok betöltéséhez.

## **Pontosság és örökölt funkciók**

A konverzió általában megőrzi a diák, fő sablonok, elrendezések, szöveg, alakzatok, képek, táblázatok és diagramok állapotát. Azonban a PPT és a PPTX nem minden funkciót ábrázol pontosan ugyanúgy. Egy örökölt funkció, amelynek nincs PPTX megfelelője, vagy amelyet a könyvtár nem támogat, normalizálható, kihagyható vagy másképp jeleníthető meg.

Ellenőrizze a konvertált fájlt, ha animációkat, áttűnéseket, beágyazott vagy hivatkozott OLE objektumokat, ActiveX vezérlőket, beágyazott médiát, ritka betűtípusokat vagy VBA makrókat tartalmaz. Egy egyszerű PPTX fájl nem makró‑támogatott formátum, ezért használjon megfelelő makró‑képességgel rendelkező munkafolyamatot, ha a VBA‑nak továbbra is elérhetőnek kell maradnia. Továbbá ellenőrizze, hogy a szükséges betűtípusok és külső erőforrások jelen vannak‑e abban a környezetben, ahol a konvertált prezentációt megnyitják vagy megjelenítik.

Fontos dokumentumok esetén programozottan nyissa meg újra a létrehozott PPTX‑et, ellenőrizze a kulcsfontosságú diák számát és tartalmát, majd hasonlítsa össze megjelenését és diavetítés viselkedését a kívánt megjelenítőben. Ne tekintse a sikeres [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) hívást bizonyítéknak arra, hogy minden örökölt funkció pontos PPTX megfelelővel rendelkezik.

## **Mikor használjuk a PPTX-et**

Használja a PPTX‑et, ha a prezentációt a jelenlegi PowerPoint verziókkal szerkesztik, Open XML csomagokkal dolgozó rendszerek között cserélik, vagy ha olyan formátumban akarja tárolni, amely könnyebben ellenőrizhető és helyreállítható, mint a régi bináris PPT. Tartsa meg az eredeti PPT‑et archiválási vagy visszalépési másolatként, amíg a konvertált prezentáció át nem esik a pontossági ellenőrzéseken.

Ha PDF, HTML, képek, XPS vagy egyéb kimeneti típusra van szükség, használja a [Prezentációk konvertálása több formátumba](/nodejs-java/convert-presentation/) útmutatóját a formátumspecifikus irányelvekhez, ahelyett hogy feltételezné, hogy minden cél megőrzi a szerkeszthető PowerPoint funkciókat.

## **Online konverter**

Ritkán felmerülő fájlokhoz vagy gyors összehasonlításhoz használhatja az [online PPT to PPTX konverter](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx) szolgáltatást. Ismétlődő konverziókhoz, kötegelt feldolgozáshoz vagy alkalmazásszintű hibakezeléshez használja a Node.js via Java API‑t.

## **Kapcsolódó cikkek**

- [PPT vs PPTX](/nodejs-java/ppt-vs-pptx/)
- [Prezentációk mentése Node.js‑ben](/nodejs-java/save-presentation/)
- [Támogatott fájlformátumok](/nodejs-java/supported-file-formats/)
- [Prezentációk megnyitása Node.js‑ben](/nodejs-java/open-presentation/)

## **FAQ**

**Átkonvertálhatom a PPT‑t PPTX‑re anélkül, hogy a Microsoft PowerPoint telepítve lenne?**

Igen. Az Aspose.Slides for Node.js via Java betölti és elmenti a prezentációs fájlokat anélkül, hogy a Microsoft PowerPoint szükséges lenne.

**Megőrzi a PPT‑PPTX konverzió a tartalmat pontosan?**

Megőrzi a gyakori prezentációs tartalmakat, de a teljes pontosság nem garantált minden örökölt vagy nem támogatott funkció esetén. Tekintse át a létrehozott fájlt, ha makrókat, OLE‑ vagy ActiveX‑objektumokat, médiát, speciális animációkat vagy ritka betűtípusokat tartalmaz.

**Átkonvertálhatok jelszóval védett PPT fájlt?**

Igen, ha a betöltéskor megadja a helyes jelszót. A hiányzó vagy helytelen jelszó miatt a betöltés sikertelen.

**Törötnöm kell a PPT fájlt a konverzió után?**

Tartsa meg az eredetit, amíg ellenőrizte a PPTX‑et a fontos megjelenítőkben és munkafolyamatokban. Ez visszalépési másolatot biztosít, ha egy örökölt funkció másként konvertálódik.