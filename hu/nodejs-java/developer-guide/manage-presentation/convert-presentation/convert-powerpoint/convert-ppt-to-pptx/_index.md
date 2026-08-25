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
description: "Konvertálja a régi PPT fájlokat PPTX-re Node.js-ben az Aspose.Slides használatával. Tartalmaz JavaScript példákat egyetlen fájl és kötegelt konverzióra, hibakezelésre és pontossági megjegyzésekre."
---
## **Áttekintés**

A PPT a régi bináris PowerPoint formátum, míg a PPTX az újabb Open XML formátum. Aspose.Slides for Node.js via Java képes betölteni egy PPT fájlt, és PPTX‑ként menteni Microsoft PowerPoint nélkül. Ez a cikk bemutatja, hogyan konvertálhat egy fájlt vagy fájlok könyvtárát, valamint elmagyarázza, mit kell ellenőrizni a konvertálás után.

## **PPT fájl konvertálása PPTX‑be**

Töltse be a forrásfájlt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztállyal, majd hívja meg a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) metódust a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveformat/) argumentummal. A `finally` blokk megszünteti a prezentációt és felszabadítja annak erőforrásait.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Töltse be a régi PPT prezentációt.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Mentse a prezentációt PPTX formátumban.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A fájlkiterjesztés önmagában nem határozza meg a kimeneti formátumot; ezt a [SaveFormat.Pptx](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveformat/) argumentum végzi. Tartsa külön a bemeneti és kimeneti útvonalakat, ha meg kell őrizni az eredeti PPT fájlt.

## **Több PPT fájl konvertálása**

Az alábbi példa minden egyes `.ppt` fájlt konvertál egy könyvtárban. Minden fájlt önállóan dolgoz fel, így egy hibás konverzió sem állítja le a többi köteg feldolgozását.

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

Éles környezetben naplózza a teljes hibát, döntse el, felülírható‑e egy már létező kimeneti fájl, és írja a sikertelen fájlneveket egy újrapróbálási vagy felülvizsgálati sorba. Sérült fájlok, a szükséges jelszó nélkül megnyitott jelszóval védett fájlok, elérhetetlen útvonalak és nem támogatott tartalom egyaránt okozhatnak konverziós hibát. Lásd a [Password-Protected Presentations](/slides/hu/nodejs-java/password-protected-presentation/) cikket a titkosított fájlok betöltéséhez.

## **Pontosság és örökölt funkciók**

A konverzió általában megőrzi a diák, fő- és elrendezési sablonok, szöveg, alakzatok, képek, táblázatok és diagramok tartalmát. Azonban a PPT és a PPTX nem minden funkciót ábrázol pontosan ugyanúgy. Egy örökölt funkció, amelynek nincs PPTX megfelelője, vagy amelyet a könyvtár nem támogat, normalizálva, kihagyva vagy másként megjelenítve kerülhet át.

Ellenőrizze a konvertált fájlt, ha animációkat, átmeneteket, beágyazott vagy hivatkozott OLE objektumokat, ActiveX vezérlőket, beágyazott médiát, ritka betűtípusokat vagy VBA makrókat tartalmaz. A sima PPTX fájl nem makró‑engedélyezett formátum, ezért használjon megfelelő makró‑engedélyezett munkafolyamatot, ha a VBA-nak elérhetőnek kell maradnia. Ellenőrizze továbbá, hogy a szükséges betűtípusok és külső erőforrások jelen vannak-e abban a környezetben, ahol a konvertált prezentációt megnyitják vagy megjelenítik.

Fontos dokumentumok esetén nyissa meg a generált PPTX-et programozott módon, ellenőrizze a fontos dia számot és a tartalmat, majd hasonlítsa össze a megjelenését és a diavetítés viselkedését a célzott megjelenítőben. Ne tekintse a sikeres [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) hívást bizonyítéknak arra, hogy minden örökölt funkció pontos PPTX megfelelővel rendelkezik.

## **Mikor érdemes PPTX‑et használni**

Használjon PPTX‑et, ha a prezentációt a jelenlegi PowerPoint verziókkal szerkesztik, Open XML csomagokkal dolgozó rendszerek között cserélik, vagy egy olyan formátumban tárolják, amely könnyebben ellenőrizhető és visszaállítható, mint a régi bináris PPT. Tartsa meg az eredeti PPT‑t archiválási vagy visszagörgetési példányként, amíg a konvertált prezentáció át nem esik a pontossági ellenőrzéseken.

Ha inkább PDF, HTML, képek, XPS vagy más kimeneti típusra van szüksége, használja a [Convert Presentations to Multiple Formats](/slides/hu/nodejs-java/convert-presentation/) útmutatót a formátum‑specifikus leírásokhoz, ahelyett, hogy azt feltételezné, hogy minden cél megőrzi az szerkeszthető PowerPoint funkciókat.

## **Online konverter**

Ritkán használt fájlok vagy gyors összehasonlítás esetén használhatja az [online PPT to PPTX converter](https://products.aspose.app/slides/hu/conversion/ppt-to-pptx) szolgáltatást. Ismétlődő konverziókhoz, kötegelt feldolgozáshoz vagy alkalmazásszintű hibakezeléshez használja a Node.js via Java API-t.

## **Kapcsolódó cikkek**

- [PPT vs PPTX](/slides/hu/nodejs-java/ppt-vs-pptx/)
- [Prezentációk mentése Node.js‑ben](/slides/hu/nodejs-java/save-presentation/)
- [Támogatott fájlformátumok](/slides/hu/nodejs-java/supported-file-formats/)
- [Prezentációk megnyitása Node.js‑ben](/slides/hu/nodejs-java/open-presentation/)

## **GYIK**

**Átkonvertálhatom a PPT‑t PPTX‑re anélkül, hogy a Microsoft PowerPoint telepítve lenne?**

Igen. Az Aspose.Slides for Node.js via Java betölti és elmenti a prezentációs fájlokat Microsoft PowerPoint nélkül.

**A PPT‑ról PPTX‑re történő konverzió pontosan megőrzi-e a teljes tartalmat?**

Megőrzi a közös prezentációs tartalmat, de a pontos pontosság nem garantált minden örökölt vagy nem támogatott funkció esetén. Tekintse át a generált fájlt, ha makrókat, OLE vagy ActiveX objektumokat, médiát, speciális animációkat vagy ritka betűtípusokat tartalmaz.

**Konvertálhatok jelszóval védett PPT fájlt?**

Igen, ha a betöltéskor megadja a helyes jelszót. A hiányzó vagy helytelen jelszó miatt a betöltés sikertelen.

**Törötnöm kell a PPT fájlt a konverzió után?**

Tartsa meg az eredetit, amíg a fontos megjelenítőkben és munkafolyamatokban ellenőrizte a PPTX-et. Ez visszagörgetési példányt biztosít, ha egy örökölt funkció másként konvertálódik.