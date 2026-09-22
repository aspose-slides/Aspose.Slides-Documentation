---
title: Prezentációk mentése JavaScriptben
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
- prezentáció adatfolyamba
- előre definiált nézet típus
- Szigorú Office Open XML formátum
- Zip64 mód
- miniatűr frissítése
- mentés előrehaladása
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk mentése fájlokba vagy adatfolyamokba JavaScriptben az Aspose.Slides használatával, valamint a PPTX kimenet és a folyamatjelentés beállítása."
---
## **Áttekintés**

Miután létrehoz egy prezentációt vagy [nyit meg egy meglévőt](/slides/hu/nodejs-java/open-presentation/), használja a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) metódust az eredmény írásához. Az Aspose.Slides for Node.js via Java képes egy prezentációt fájlba vagy adatfolyamba menteni PowerPoint, OpenDocument, PDF és egyéb formátumokban. Az alábbi szakaszok a szabványos mentési műveleteket és a PPTX kimenethez elérhető beállításokat tárgyalják.

## **Prezentációk mentése fájlokba**

A prezentáció fájlba mentéséhez adja át a kimeneti útvonalat és egy [SaveFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveformat/) értéket a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) metódusnak. A formátumérték meghatározza, milyen típusú fájlt hoz létre az Aspose.Slides.

A következő példa létrehoz egy prezentációt és PPTX fájlként menti el:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // Adja hozzá vagy módosítsa a prezentáció tartalmát itt.

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése az eredeti formátumban**

A fájl‑ és adatfolyam‑detektálási példákhoz, az újonnan létrehozott prezentációk viselkedéséhez, valamint a forrás‑ és kimeneti formátumok közti különbséghez lásd a [Determine the Original Presentation Format](/slides/hu/nodejs-java/detect-presentation-source-format/) oldalt.

Kötegelt feldolgozási alkalmazásban előre nem ismert a bemeneti formátum. Egy fájl betöltése után olvassa ki az eredeti formátumát a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#getSourceFormat) metódussal. A kapott [SourceFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sourceformat/) értéket adja át a [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideutil/#toSaveFormat) metódusnak a megfelelő [SaveFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveformat/) érték megszerzéséhez, majd a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) metódussal írja ki a módosított prezentációt.

A következő teljes példában az bemeneti könyvtár minden fájlját feldolgozzák, frissítik a címét, és a betöltött formátumban mentik el egy kimeneti könyvtárba:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/slideutil/#toSaveFormat) a PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP és PowerPoint XML formátumokat a megfelelő prezentáció mentési formátumokhoz rendeli. Csak a prezentáció forrásformátumait térképezi le; nem szolgál exportformátumok (például PDF, HTML, TIFF vagy képek) kiválasztására. Egy nem támogatott vagy érvénytelen [SourceFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sourceformat/) érték átadása hibát eredményez.

A régi PPT, PPS és POT fájlok ugyanazt a bináris konténert használják. Ha egy ilyen prezentációt kiterjesztés nélküli adatfolyamból töltik be, előfordulhat, hogy a PPS vagy POT fájlt PPT‑ként azonosítja a rendszer. Ha meg kell őrizni ezeket a régi altípusokat, tartsa meg az eredeti fájlnevet vagy a formátum‑metaadatot külön, és használja azt a kimeneti fájlnév és formátum kiválasztásakor.

## **Prezentációk mentése adatfolyamokba**

Prezentáció írásához végleges fájlútvonal nélkül adjon át egy írható adatfolyamot és egy [SaveFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveformat/) értéket a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) metódusnak. Ez a megközelítés akkor hasznos, ha a kimenetet egy webszolgáltatásból kell visszaadni, adatbázisban tárolni vagy memóriában feldolgozni.

A következő példa egy új prezentációt fájl‑adatfolyamba ment:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése előre definiált nézet típussal**

Megadhatja azt a nézetet, amelyben a PowerPoint alapértelmezés szerint megnyitja a mentett prezentációt. Használja a [ViewProperties.setLastView](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewproperties/#setLastView) metódust egy [ViewType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/viewtype/) értékkel a mentés előtt.

A következő példa a Dia‑mester nézetet állítja be kezdeti nézetnek:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése a szigorú Office Open XML formátumban**

Ahhoz, hogy egy PPTX fájl a Office Open XML szigorú profiljának megfeleljen, hozza létre a [PptxOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxoptions/) példányt, és használja a [setConformance](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxoptions/#setConformance) metódust a [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict) értékkel. Ezután adja át a beállításokat a [Presentation.save](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/#save) metódusnak.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése Office Open XML formátumban Zip64 módban**

A szabványos ZIP archívum korlátozza minden bejegyzés tömörített és tömörítetlen méretét, az összes archívum méretét, valamint a bejegyzések számát. Mivel egy PPTX fájl ZIP archívum, egy nagyon nagy prezentáció túllépheti ezeket a korlátokat. A ZIP64 kiterjesztések növelik a vonatkozó méret‑ és bejegyzésszám‑korlátokat.

Használja a [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode) metódust annak szabályozására, hogy az Aspose.Slides ZIP64 kiterjesztéseket ír‑e:

- [IfNecessary](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/zip64mode/#IfNecessary) ZIP64‑et csak akkor használja, ha a prezentáció meghaladja a szabványos ZIP‑korlátokat. Ez az alapértelmezett mód.
- [Never](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/zip64mode/#Never) letiltja a ZIP64 kiterjesztéseket.
- [Always](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/zip64mode/#Always) mindig ír ZIP64 kiterjesztéseket.

A következő példa mindig engedélyezi a ZIP64 kiterjesztéseket a kimeneti prezentációhoz:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Ha a [Zip64Mode.Never](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/zip64mode/#Never) van használatban, és a prezentáció nem fér bele a szabványos ZIP‑korlátokba, a mentési művelet egy [PptxException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxexception/) kivételt dob.
{{% /alert %}}

## **Prezentációk mentése Office Open XML formátumban tömörítési szintekkel**

PPTX kimenet esetén a mentés sebessége és a fájlméret egyensúlyozható a [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel) metódus használatával. A [CompressionLevel](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/) osztály a következő értékeket biztosítja:

- [None](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/#None) adatot tömörítés nélkül tárol.
- [Level1](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/#Level1) a leggyorsabb tömörítést és a legnagyobb tömörített kimenetet biztosítja.
- [Level2](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/#Level2)‑től [Level5](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/#Level5)‑ig fokozatosan a kisebb kimenetet részesítik előnyben a mentési sebességnél.
- [Level6](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/#Level6) egyensúlyt teremt a mentési sebesség és a fájlméret között. Ez az alapértelmezett szint.
- [Level7](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/#Level7) és [Level8](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/#Level8) tovább a kisebb kimenetet helyezik előtérbe a sebességnél.
- [Level9](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/compressionlevel/#Level9) a legerősebb tömörítést nyújtja, és a legtöbb feldolgozási időt igényli.

A következő példa egy prezentációt tömörítés nélkül ment:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

A következő példa a maximális tömörítési szintet használja:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Prezentációk mentése a miniatűr frissítése nélkül**

Amikor egy prezentációt PPTX‑ként ment, a [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) metódus szabályozza a dokumentum miniatűrjét:

- `true` újragenerálja a miniatűröt a mentési művelet során. Ez az alapértelmezett érték.
- `false` megőrzi a meglévő miniatűrt. Ha a prezentációnak nincs miniatűre, az Aspose.Slides nem hoz létre újat.

A következő példa egy prezentációt a miniatűr frissítése nélkül ment:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
A miniatűr frissítésének letiltása csökkentheti a PPTX fájl mentéséhez szükséges időt.
{{% /alert %}}

## **Mentés előrehaladási frissítések százalékban**

A mentési művelet megfigyeléséhez valósítsa meg az [IProgressCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprogresscallback/) interfészt Java proxy‑val, és adja át a megvalósítást a [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) metódusnak. Az Aspose.Slides ezután a [IProgressCallback.reporting](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iprogresscallback/#reporting-double-) metódust hívja meg a haladásértékekkel az export során.

A következő példa a PDF‑export haladását írja a konzolra:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Az Aspose egy ingyenes [PowerPoint Splitter](https://products.aspose.app/slides/hu/splitter) alkalmazást kínál, amely az Aspose.Slides API‑val készült. Kiválasztott diák mentését külön PPT vagy PPTX fájlokba teszi lehetővé.
{{% /alert %}}

## **GYIK**

**Támogatja-e az Aspose.Slides az inkrementális vagy „gyors mentés” funkciót?**

Nem. Minden mentési művelet egy teljes kimeneti fájlt ír, a változott részeket nem frissíti külön.

**Több szál is mentheti ugyanazt a Presentation példányt?**

Nem. Egy [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példány **nem szálbiztos** [/slides/hu/nodejs-java/multithreading/]. Minden példányt egyszerre csak egy szálról érjen el és mentse.

**Mi történik a hiperhivatkozásokkal és a külsőleg hivatkozott fájlokkal, amikor mentek egy prezentációt?**

A [Hyperlinks](/slides/hu/nodejs-java/manage-hyperlinks/) a prezentációban marad. Az Aspose.Slides nem másolja a külsőleg hivatkozott fájlokat, ezért a mentett prezentációnak továbbra is hozzá kell férnie azok helyéhez.

**Menthetek-e dokumentum‑metaadatokat, például szerzőt, címet, céget és létrehozási dátumot?**

Igen. Állítsa be a megfelelő [document properties](/slides/hu/nodejs-java/presentation-properties/) értékeket a mentés előtt, és az Aspose.Slides beírja őket a kimeneti fájlba.