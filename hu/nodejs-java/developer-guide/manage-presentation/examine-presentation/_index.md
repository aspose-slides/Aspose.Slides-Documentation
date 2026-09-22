---
title: Bemutatóinformációk lekérése és frissítése JavaScriptben
linktitle: Bemutatóinformációk
type: docs
weight: 30
url: /hu/nodejs-java/examine-presentation/
keywords:
- bemutató formátum
- bemutató tulajdonságok
- dokumentumtulajdonságok
- tulajdonságok lekérése
- tulajdonságok olvasása
- tulajdonságok módosítása
- tulajdonságok szerkesztése
- tulajdonságok frissítése
- PPTX vizsgálata
- PPT vizsgálata
- ODP vizsgálata
- PowerPoint
- OpenDocument
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel a diákat, a felépítést és a metaadatokat PowerPoint és OpenDocument bemutatókban JavaScript használatával a gyorsabb betekintés és intelligensebb tartalomellenőrzés érdekében."
---
## **Áttekintés**

Az Aspose.Slides képes azonosítani egy bemutató formátumát, és elolvasni a dokumentum metaadatait anélkül, hogy teljes bemutató objektummodellt hozna létre. Ez akkor hasznos, ha fájlokat kell kategorizálni, leltárt készíteni, vagy tulajdonságokat ellenőrizni kell, mielőtt eldöntené, hogy betölti és feldolgozza a bemutató tartalmát.

Ez a cikk bemutatja a könnyű ellenőrzést a [PresentationFactory](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationfactory/) és a [PresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/) segítségével, valamint a célzott frissítéseket a [DocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/) használatával.

## **Egy bemutató formátumának ellenőrzése**

Ha már betöltött bemutatója van, lásd a [Az eredeti bemutató formátum meghatározása](/slides/hu/nodejs-java/detect-presentation-source-format/) cikket a betöltés utáni és a régi PPT, PPS és POT adatfolyamok korlátaival kapcsolatban.

Használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) metódust egy fájl vizsgálatához anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt hozna létre. A [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/getloadformat/) metódus jelzi a felismert formátumot, például PPTX, PPT vagy ODP.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **Könnyű bemutató leltár felépítése**

Ha sok bemutatófájlt dolgoz fel, előfordulhat, hogy egy kompakt leltárra van szüksége érvényesítéshez, indexeléshez vagy dokumentumkezelő rendszerhez. Ebben a helyzetben használja a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) metódust egy [PresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/) objektum megszerzéséhez, majd hívja a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) metódust a dokumentum metaadatainak beolvasásához. Ez a megközelítés nem hoz létre [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt, és nem igényli a teljes bemutató objektummodell bejárását.

A [DocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/) által biztosított kiterjesztett tulajdonságok a következő leltárértékeket adják:

| Módszer | Leltár érték |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/#getSlides) | Diák összes száma. |
| [getHiddenSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Rejtett diák száma. |
| [getNotes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/#getNotes) | Jegyzetet tartalmazó diák száma. |
| [getParagraphs](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Bekezdések összes száma, ha elérhető. |
| [getWords](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/#getWords) | Szavak összes száma. |
| [getMultimediaClips](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Hang- és videoklipek összes száma. |

Az alábbi példa ezeket az értékeket olvassa be anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) objektumot hozna létre, és egy kompakt leltárt nyomtat. Emellett a [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) metódust kombinálja a [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) metódussal, hogy megjelenítse a tartalomcsoportokat, például betűtípusokat, témákat és dia címeket.

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

Minden [HeadingPair](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/headingpair/) egy csoportnevet ad a [HeadingPair.getName](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/headingpair/#getName) segítségével, és a csoportban lévő elemek számát a [HeadingPair.getCount](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/headingpair/#getCount) adja vissza. A [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) lapos, rendezett tömböt ad vissza, ezért a címek számát a megfelelő heading pair által megadott egymást követő címek mennyiségére kell felhasználni.

### **Tárolt metaadatok és formátumkorlátok**

Az [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) által visszaadott leltártulajdonságok tükrözik a forrásdokumentumban elérhető metaadatokat. Az Aspose.Slides nem tölti be és nem járja be a bemutató objektummodellt, hogy újraszámolja ezeket az értékeket a hívás során. A hiányzó tulajdonságokat alapértelmezett értékek képviselik, és a tárolt értékek elavultak lehetnek, ha az utolsó mentést végző alkalmazás nem frissítette a dokumentumtulajdonságokat.

- **PPTX:** A formátum kibővített dokumentum tulajdonságokat biztosít a dia, jegyzet, rejtett dia, bekezdés, szó és multimédia számlálókhoz, valamint a heading pair-ekhez és részcímekhez. A rendelkezésre állás attól függ, hogy a dokumentum előállítója mely tulajdonságokat írta.
- **PPT:** A bináris formátum képes megfelelő dokumentum-összegző tulajdonságok tárolására. Ha egy tulajdonság hiányzik vagy nem frissült a dokumentum előállítója által, az Aspose.Slides a tárolt vagy alapértelmezett értéket adja vissza, a diákból számolva nem.
- **ODP:** Az OpenDocument metaadatok általános dokumentumstatisztikákat biztosítanak, mint például oldal-, bekezdés- és szószám, de ezek az értékek nem térképezhetők minden PowerPoint-specifikus kiterjesztett tulajdonságra. A rejtett dia, jegyzet dia, multimédia, heading-pair és részcím metaadatok lehetnek hiányosak, és a leltár értékek alapértelmezett értékekkel térhetnek vissza. Ne tekintse a null értéket vagy egy üres tömböt bizonyítéknak arra, hogy a megfelelő tartalom hiányzik.

Használja a könnyű metaadat‑megközelítést leltárak és előzetes ellenőrzések esetén. Töltse be a bemutatót, és vizsgálja meg a futó objektummodellt, ha az eredménynek tükröznie kell a memóriában történt változásokat, vagy ha a tényleges bemutató tartalmát kell ellenőrizni.

## **Bemutató tulajdonságok frissítése**

Az [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) által visszaadott tulajdonságok szintén módosíthatók anélkül, hogy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt hoznánk létre. Alkalmazza a változtatásokat a [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/) metódussal, majd írja ki a kötött bemutatót a [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/) segítségével.

Az alábbi kép a PowerPoint bemutató eredeti dokumentumtulajdonságait mutatja.

![A PowerPoint bemutató eredeti dokumentumtulajdonságai](input_properties.png)

Az alábbi példa megváltoztatja a címet és az utolsó mentés időpontját, majd az eredményt egy új fájlba írja:

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

Az alábbi kép a frissített dokumentumtulajdonságokat mutatja.

![A PowerPoint bemutató módosított dokumentumtulajdonságai](output_properties.png)

## **Hasznos hivatkozások**

Kapcsolódó biztonsági ellenőrzések és védelmi beállítások tekintetében lásd a következő cikkeket:

- [Password-Protect Presentations](/slides/hu/nodejs-java/password-protected-presentation/)
- [Write-Protect Presentations](/slides/hu/nodejs-java/write-protected-presentation/)

## **GYIK**

**Hogyan ellenőrizhetem, hogy a betűkészletek be vannak-e ágyazva, és melyek azok?**

Töltse be a bemutatót, és használja a [Presentation.getFontsManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getfontsmanager/) metódust. Hívja a [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) metódust a beágyazott betűkészletek lekéréséhez, valamint a [FontsManager.getFonts](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/fontsmanager/getfonts/) metódust a bemutató által használt betűkészletekhez. Hasonlítsa össze a két eredményt, hogy megtalálja a megjelenítéshez szükséges, de nincs beágyazva lévő betűkészleteket.

**Hogyan tudom gyorsan megállapítani, hogy a fájl rejtett diákot tartalmaz-e, és hány darabot?**

Ha a tárolt dokumentum metaadatai elegendőek, olvassa a [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) értéket a [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) és a [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) segítségével. Ez alkalmas egy könnyű leltárra. Ha a bemutatót memóriában módosították, a tárolt metaadat hiányozhat vagy elavult lehet, vagy élő értékeket kell ellenőrizni; ekkor járja be a [Presentation.getSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getslides/) gyűjteményt, és minden dia [Slide.getHidden](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slide/gethidden/) metódusát vizsgálja meg.

**Észlelhetem-e, hogy egyéni dia méret és tájolás van‑e használatban, és eltérnek‑e az alapértelmezettől?**

Igen. Töltse be a bemutatót, és hívja a [Presentation.getSlideSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getslidesize/) metódust. Használja a [SlideSize.getType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidesize/gettype/), a [SlideSize.getSize](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidesize/getsize/) és a [SlideSize.getOrientation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slidesize/getorientation/) metódusokat a jelenlegi beállítások összehasonlításához az elvárt előre beállított méretekkel és tájolással.

**Van gyors mód arra, hogy lássam, a diagramok külső adatforrásra hivatkoznak‑e?**

Igen. Keresse meg minden [Chart](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chart/) elemet, és hívja a [ChartData.getDataSourceType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) metódust. Külső munkafüzet esetén hívja a [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) metódust. Az adatforrás típus és az elérési út külső hivatkozást jelez, de annak elérhetősége külön erőforrás‑ellenőrzést igényel.

**Hogyan tudom felmérni a „nehéz” diákat, amelyek lassíthatják a renderelést vagy a PDF exportot?**

Nincs egyetlen „komplexitás” tulajdonság. Járja be a [Presentation.getSlides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/getslides/) gyűjteményt, és minden dia [BaseSlide.getShapes](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/baseslide/#getShapes) kollekcióját. Használjon alakzat‑számok és nagy képek, effektusok, animációk vagy multimédia jelenlétének jelzéseit szűrési tényezőként, és mérje egy reprezentatív renderelés vagy export időt, mielőtt a diát megerősített teljesítmény‑szűkítőnek tekintené.