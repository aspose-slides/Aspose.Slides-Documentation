---
title: PPT és PPTX konvertálása PDF-be JavaScriptben [Fejlett funkciók beépítve]
linktitle: PowerPoint PDF-re
type: docs
weight: 40
url: /hu/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- PowerPoint PDF-re
- prezentáció PDF-re
- PPT PDF-re
- PPT PDF-re konvertálása
- PPTX PDF-re
- PPTX PDF-re konvertálása
- PowerPoint mentése PDF-ként
- PPT mentése PDF-ként
- PPTX mentése PDF-ként
- PPT exportálása PDF-be
- PPTX exportálása PDF-be
- melléklet
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertálja a PowerPoint PPT/PPTX fájlokat magas minőségű, kereshető PDF-ekké az Aspose.Slides for Node.js használatával, gyors kódrészletekkel és fejlett konvertálási beállításokkal."
---
## **Áttekintés**

A PowerPoint és OpenDocument prezentációk (PPT, PPTX, ODP stb.) PDF formátumba konvertálása JavaScriptben számos előnnyel jár, többek között különböző eszközök közötti kompatibilitással és a prezentáció elrendezésének, formázásának megőrzésével. Ez az útmutató bemutatja, hogyan lehet a prezentációkat PDF dokumentumokká konvertálni, különböző beállításokkal szabályozni a képek minőségét, belefoglalni a rejtett diákot, jelszóval védeni a PDF fájlokat, észlelni a betűkészlet‑helyettesítéseket, kiválasztani konkrét diákokat a konvertáláshoz, valamint megfelelési szabványokat alkalmazni a kimeneti dokumentumokon.

## **PowerPoint PDF konverziók**

Az Aspose.Slides segítségével a következő formátumú prezentációkat konvertálhatja PDF‑re:

* **PPT**
* **PPTX**
* **ODP**

A prezentáció PDF‑re konvertálásához adja át a fájlnevet argumentumként a [Prezentáció](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztálynak, majd mentse a prezentációt PDF‑ként a [mentés](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) metódussal. A [Prezentáció](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztály biztosítja a [mentés](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) metódust, amelyet általában a prezentáció PDF‑re konvertálásához használnak.

{{% alert color="info" title="Note" %}}

Az Aspose.Slides for Node.js via Java beilleszti API‑információit és verziószámát a kimeneti dokumentumokba. Például egy prezentáció PDF‑re konvertálásakor az Aspose.Slides kitölti az Application mezőt a "*Aspose.Slides*" értékkel, a PDF Producer mezőt pedig "*Aspose.Slides v XX.XX*" formában. **Megjegyzés**: nem adható ki utasítás az Aspose.Slides számára, hogy ezt az információt megváltoztassa vagy eltávolítsa a kimeneti dokumentumokból.

{{% /alert %}}

Az Aspose.Slides lehetővé teszi a következőket:

* Teljes prezentációk PDF‑re konvertálása
* Kiválasztott diák PDF‑re konvertálása

Az Aspose.Slides exportálja a prezentációkat PDF‑be, biztosítva, hogy a létrejövő PDF‑k szorosan megegyezzenek az eredeti prezentációkkal. A konverzió során a következő elemek és attribútumok pontosan jelennek meg:

* Képek
* Szövegdobozok és alakzatok
* Szövegformázás
* Bekezdésformázás
* Hiperhivatkozások
* Fejléc és lábléc
* Felsorolások
* Táblázatok

## **PowerPoint PDF konvertálása**

Az alapértelmezett PowerPoint‑PDF konverzió a standard beállításokat használja. Ebben az esetben az Aspose.Slides a lehető legmagasabb minőségi szintekkel, optimális beállításokkal próbálja meg a prezentációt PDF‑re alakítani.

Az alábbi példa betölti egy prezentációt, és az összes látható diát PDF‑be menti az alapértelmezett exportbeállításokkal.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Az Aspose ingyenes online [**PowerPoint PDF konvertert**](https://products.aspose.app/slides/conversion/ppt-to-pdf) kínál, amely bemutatja a prezentáció‑PDF konvertálási folyamatot. Ezzel a konverterrel tesztelhet egy élő megvalósítást az itt leírt eljárásra.

{{% /alert %}}

## **PowerPoint PDF konvertálása beállításokkal**

Az Aspose.Slides egyedi beállításokat (a [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) osztály tulajdonságait) biztosít, amelyekkel testreszabhatja a kimeneti PDF‑et, jelszóval védezheti azt, vagy meghatározhatja a konvertálási folyamat módját.

### **PowerPoint PDF konvertálása egyedi beállításokkal**

Egyedi konvertálási beállítások segítségével meghatározhatja a raszteres képek kívánt minőségét, megadhatja a metafájlok kezelését, beállíthatja a szöveg tömörítési szintjét, konfigurálhatja a DPI‑t képekhez, stb.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setJpegQuality(java.newByte(90));
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Beágyazott OLE fájlok megőrzése PDF mellékletként**

Ha a prezentáció beágyazott Excel‑könyvtárat tartalmaz, a PDF‑beli címzetteknek is hozzá kell férniük a könyvtár adataihoz, miközben a diák megtekinthetők. Hívja meg a [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setIncludeOleData) metódust `true`‑val, hogy a beágyazott OLE fájlok mellékletként maradjanak a létrehozott PDF‑ben.

Az alapértelmezett érték `false`: az OLE‑objektum előnézeti képe vagy ikonja megjelenik a PDF‑oldalon, de a beágyazott fájl nem kerül mellékletként. A `true` beállítás további fájladatot is belevesz. Az előnézet továbbra is vizuális ábrázolás marad; a melléklet lehetővé teszi a címzettek számára, hogy a beágyazott fájlt külön megnyissák vagy lementsék. Az OLE‑objektum nem alakul interaktív Excel‑munkalappá a PDF‑oldalon.

Az alábbi példa betölt egy már beágyazott Excel‑könyvtárat tartalmazó prezentációt, és PDF‑be exportálja a könyvtárral együtt.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setIncludeOleData(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Az eredmény ellenőrzéséhez:

1. Nyissa meg az exportált PDF‑et egy olyan megjelenítőben, amely támogatja a fájlmellékleteket, például az Adobe Acrobat Reader‑ben.
2. Nyissa meg a megjelenítő **Mellékletek** paneljét, és keresse meg a beágyazott könyvtárat.
3. Mentse a mellékletet, és nyissa meg Excelben az adatok ellenőrzéséhez, vagy nyissa meg közvetlenül, ha a megjelenítő engedélyezi. Az előnézet a PDF‑oldalon különálló a mellékletől.

{{% alert color="info" title="Note" %}}

A PDF/A szabványok korlátozzák a mellékleteket: a PDF/A‑1 tiltja a beágyazott fájlokat, a PDF/A‑2 csak PDF/A mellékleteket engedélyez, a PDF/A‑3 pedig más fájltípusokat, így az Excel‑könyvtárakat is. Ezek a szabvány követelményei, nem az Aspose.Slides által bevezetett korlátozások. Ez a példa az alapértelmezett PDF megfelelési beállítást használja, és nem demonstrál PDF/A exportot.

{{% /alert %}}

### **PowerPoint PDF konvertálása rejtett diák használatával**

Ha a prezentáció rejtett diákot tartalmaz, a [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setShowHiddenSlides) metódust a [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) osztályból használva a rejtett diák is megjelennek a kimeneti PDF‑ben.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setShowHiddenSlides(true);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint PDF konvertálása jelszóval védett PDF‑re**

Az alábbi példa egy PDF‑et hoz létre, amely megnyitásához a `password` jelszó szükséges. A hozzáférési engedélyek megengedik a nyomtatást, köztük a magas minőségű nyomtatást.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setPassword("password");
pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Betűkészlet‑helyettesítések észlelése**

Az Aspose.Slides a [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) metódust a [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) osztály alatt biztosítja, amely lehetővé teszi a betűkészlet‑helyettesítések észlelését a prezentáció‑PDF konvertálási folyamat során.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

A betűkészlet‑helyettesítésekkel kapcsolatos további információkért lásd a [Betűkészlet helyettesítése](/slides/hu/nodejs-java/font-substitution/) cikket.

{{% /alert %}} 

## **Kiválasztott diák konvertálása PowerPoint‑ból PDF‑be**

Az alábbi példa a prezentáció 1. és 3. diaját exportálja PDF‑be. A tömbben szereplő diaszámok egy‑alapúak, és a bemeneti prezentációnak legalább három diával kell rendelkeznie.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    let slides = java.newArray("int", [1, 3]);
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **PowerPoint PDF konvertálása egyedi dia mérettel**

Az alábbi példa az első diát egy új prezentációba másolja, amelynek dia mérete 612 × 792 pont (8,5 × 11 inch). A tartalmat átméretezi a megfelelő illeszkedéshez, és az egyetlen diát PDF‑be exportálja.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const slideWidth = 612;
const slideHeight = 792;

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
let resizedPresentation = new aspose.slides.Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Távolítsa el az új prezentáció által létrehozott üres diát.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint PDF konvertálása jegyzet dianézetben**

Az alábbi példa a prezentációt PDF‑be exportálja, minden dia előadói jegyzeteit a dia alá helyezve. A hatást egy olyan prezentációval láthatja, amely tartalmaz előadói jegyzeteket.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setSlidesLayoutOptions(notesOptions);

let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF hozzáférhetőség és megfelelőségi szabványok**

Az Aspose.Slides lehetővé teszi, hogy olyan konvertálási eljárást használjon, amely megfelel a [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) szabványnak. A PowerPoint dokumentumot bármelyik következő megfelelőségi szabvánnyal exportálhatja PDF‑be: **PDF/A1a**, **PDF/A1b** és **PDF/UA**.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}

Az Aspose.Slides támogatja a PDF konvertálási műveleteket, lehetővé téve, hogy a PDF‑eket népszerű fájlformátumokra konvertálja. Végrehajthatja a [PDF‑t HTML‑re](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF‑t JPG‑re](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) és [PDF‑t PNG‑re](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) konverziókat. Egyéb, speciális formátumokra irányuló PDF konvertálások – például a [PDF‑t SVG‑re](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF‑t TIFF‑re](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) – szintén támogatottak.

{{% /alert %}}

> **Megjegyzés:** PDF/UA exportálásakor az Aspose.Slides a komplex grafikákat, mint a SmartArt, diagramok és képletek, egyetlen alakzattá alakítja. Az egyedi útvonal‑elemek nem maradnak meg különálló tartalomként, és lehet, hogy csak artefaktumokként jelennek meg; az alternatív szöveg csak az egész alakzatra vonatkozik.

## **GYIK**

**Több PowerPoint‑fájlt konvertálhatok egyszerre PDF‑re?**

Igen, az Aspose.Slides támogatja a több PPT vagy PPTX fájl kötegelt konvertálását PDF‑re. A fájlokon iterálva programozottan alkalmazhatja a konvertálási folyamatot.

**Lehet a konvertált PDF‑et jelszóval védeni?**

Igen. Használja a [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) osztályt a jelszó beállításához és a hozzáférési engedélyek meghatározásához a konvertálás során.

**Hogyan foglalhatom bele a rejtett diákot a PDF‑be?**

Hívja meg a [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setShowHiddenSlides) metódust `true`‑val a [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) osztályban a rejtett diák kimeneti PDF‑be való belefoglalásához.

**Az Aspose.Slides képes magas képméret‑minőséget fenntartani a PDF‑ben?**

Igen, a képminőséget a [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setJpegQuality) és a [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/#setSufficientResolution) metódusokkal szabályozhatja a [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) osztályban, így biztosítva a magas minőségű képeket a PDF‑jében.

**Az Aspose.Slides támogatja a PDF/A megfelelőségi szabványokat?**

Igen, az Aspose.Slides lehetővé teszi, hogy olyan PDF‑eket exportáljon, amelyek megfelelnek a [különböző szabványoknak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), beleértve a PDF/A1a, PDF/A1b és PDF/UA szabványokat, ezzel biztosítva a dokumentumok hozzáférhetőségét és archiválási követelményeit.

## **További források**

- [Aspose.Slides Node.js‑Java dokumentáció](/slides/hu/nodejs-java/)
- [Aspose.Slides Node.js‑Java API‑referencia](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose Ingyenes Online Átalakítók](https://products.aspose.app/slides/conversion)