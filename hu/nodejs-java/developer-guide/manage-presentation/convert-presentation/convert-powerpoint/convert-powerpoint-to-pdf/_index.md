---
title: PPT és PPTX konvertálása PDF-be JavaScript-ben [Haladó funkciók benne]
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
- PPT konvertálása PDF-be
- PPTX PDF-re
- PPTX konvertálása PDF-be
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
description: "Konvertálja a PowerPoint PPT/PPTX fájlokat magas minőségű, kereshető PDF-ekre az Aspose.Slides for Node.js használatával, gyors kódpéldákkal és haladó konverziós beállításokkal."
---
## **Áttekintés**

PowerPoint és OpenDocument prezentációk (PPT, PPTX, ODP stb.) PDF formátumba konvertálása JavaScript-ben több előnnyel jár, többek között különböző eszközök közötti kompatibilitással és a prezentáció elrendezésének és formázásának megőrzésével. Ez az útmutató bemutatja, hogyan konvertálhatók a prezentációk PDF dokumentumokká, hogyan használhatók különféle lehetőségek a képek minőségének szabályozásához, hogyan vehetők bele a rejtett diák, hogyan lehet jelszóval védeni a PDF fájlokat, hogyan lehet felismerni a betűkészlet-helyettesítéseket, hogyan választhatók ki konkrét diák a konvertáláshoz, és hogyan alkalmazhatók megfelelőségi szabványok a kimeneti dokumentumokra.

## **PowerPoint PDF konverziók**

Az Aspose.Slides segítségével a következő formátumú prezentációkat konvertálhatja PDF-be:

* **PPT**
* **PPTX**
* **ODP**

A prezentáció PDF‑be konvertálásához adja át a fájl nevét argumentumként a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztálynak, majd mentse a prezentációt PDF‑ként a [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) metódussal. A [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztály elérhetővé teszi a [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) metódust, amelyet általában a prezentáció PDF‑be konvertálására használnak.

{{% alert color="info" title="Megjegyzés" %}}
Aspose.Slides for Node.js via Java inserts its API information and version number into output documents. For example, when converting a presentation to PDF, Aspose.Slides populates the Application field with "*Aspose.Slides*" and the PDF Producer field with a value in "*Aspose.Slides v XX.XX*" form. **Megjegyzés** that you cannot instruct Aspose.Slides to change or remove this information from output documents.
{{% /alert %}}

Aspose.Slides lehetővé teszi a következő konvertálását:

* Teljes prezentációk PDF‑be
* A prezentáció egyes diái PDF‑be

Aspose.Slides exportálja a prezentációkat PDF‑be, biztosítva, hogy a kapott PDF‑ek szorosan megegyezzenek az eredeti prezentációkkal. A konverzió során pontosan jelennek meg az elemek és attribútumok, többek között:

* Képek
* Szövegdobozok és alakzatok
* Szövegformázás
* Bekezdésformázás
* Hiperhivatkozások
* Fejléc és lábléc
* Felsorolások
* Táblázatok

## **PowerPoint PDF konvertálása**

Az alapértelmezett PowerPoint‑PDF konverziós folyamat az alapbeállításokat használja. Ebben az esetben az Aspose.Slides a megadott prezentációt a legoptimálisabb beállításokkal, a maximális minőségi szinteken konvertálja PDF‑be.

Az alábbi példa betölt egy prezentációt, és az alapértelmezett exportbeállításokkal menti az összes látható diát PDF‑be.

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

{{% alert color="info" title="Megjegyzés" %}}
Aspose ingyenes online [**PowerPoint PDF konvertáló**](https://products.aspose.app/slides/conversion/ppt-to-pdf) szolgáltatást kínál, amely bemutatja a prezentáció‑PDF konvertálási folyamatot. Tesztelheti ezt a konvertálót a leírt eljárás valós időben történő megvalósításához.
{{% /alert %}}

## **PowerPoint PDF konvertálása beállításokkal**

Az Aspose.Slides egyéni beállításokat—tulajdonságokat a [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) osztályban—biztosít, amelyekkel testreszabhatja a kapott PDF‑et, jelszóval zárolhatja a PDF‑et, vagy meghatározhatja, hogyan haladjon a konverziós folyamat.

### **PowerPoint PDF konvertálása egyéni beállításokkal**

Az egyéni konvertálási beállításokkal meghatározhatja a raszteres képek kívánt minőségi beállítását, megadhatja a metafájlok kezelésének módját, beállíthatja a szöveg tömörítési szintjét, konfigurálhatja a képek DPI‑jét, és egyebeket.

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

### **Beágyazott OLE fájlok megőrzése PDF mellékletekként**

Ha egy prezentáció beágyazott Excel munkafüzetet tartalmaz, akkor előfordulhat, hogy a PDF‑felhasználóknak szeretné hozzáférni a munkafüzet adataihoz, valamint megtekinteni a diákat. Hívja meg a [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) metódust `true` értékkel, hogy a beágyazott OLE fájlok mellékletek legyenek a kapott PDF‑ben.

Az alapértelmezett érték `false`: az OLE objektum előnézeti képe vagy ikonjának megjelenése a PDF‑oldalon történik, de a beágyazott fájl nem kerül mellékletként hozzáadásra. Az opció `true`‑ra állítása továbbiként hozzáadja a fájl adatát. Az előnézet vizuális ábrázolás marad; a melléklet lehetővé teszi a felhasználók számára a beágyazott fájl különálló megnyitását vagy mentését. Az OLE objektum nem válik interaktív Excel munkalappá a PDF‑oldalon.

A mintaprezentáció két szövegdobozt tartalmaz: egyet normál szöveggel, egyet ugyanarra a betűkészletre alkalmazott félkövér formázással, amelynek nincs dedikált félkövér változata. Az alábbi példa betölti a prezentációt, engedélyezi a nem támogatott betűkészlet‑stílusok rasterizálását, és PDF‑be exportálja:

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

1. Nyissa meg az exportált PDF‑et egy olyan megjelenítőben, amely támogatja a fájl mellékleteket, például az Adobe Acrobat Reader‑ben.
2. Nyissa meg a megjelenítő **Attachments** (Mellékletek) paneljét, és keresse meg a beágyazott munkafüzetet.
3. Mentse a mellékletet, és nyissa meg Excelben az adatok megtekintéséhez, vagy közvetlenül nyissa meg, ha a megjelenítő engedélyezi. Az előnézet a PDF‑oldalon különálló a melléklettől.

{{% alert color="info" title="Megjegyzés" %}}
PDF/A szabványok meghatározzák a mellékletekre vonatkozó korlátozásokat: a PDF/A-1 tiltja a beágyazott fájlokat, a PDF/A-2 csak PDF/A mellékleteket engedélyez, a PDF/A-3 pedig egyéb fájltípusokat, köztük az Excel munkafüzeteket is megenged. Ezek a szabványok követelményei, nem az Aspose.Slides saját korlátozásai. Ez a példa az alapértelmezett PDF megfelelőségi beállítást használja, és nem demonstrálja a PDF/A exportálást.
{{% /alert %}}

### **PowerPoint PDF konvertálása rejtett diák felhasználásával**

Ha egy prezentáció rejtett diákot tartalmaz, a [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) metódust a [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) osztályból használva belefoglalhatja a rejtett diát a kapott PDF oldalai közé.

Az alábbi példa exportál egy prezentációt PDF‑be, beleértve az esetleges rejtett diákot is.

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

### **PowerPoint PDF konvertálása jelszóval védett PDF‑ké**

Az alábbi példa egy prezentációt olyan PDF‑be exportál, amely megnyitásához a `password` jelszó szükséges. A hozzáférési jogosultságok engedélyezik a nyomtatást, beleértve a magas minőségű nyomtatást.

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

### **Betűkészlet-helyettesítések észlelése**

Aspose.Slides a [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) metódust a [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) osztályban biztosítja, lehetővé téve a betűkészlet-helyettesítések észlelését a prezentáció‑PDF konverziós folyamat során.

Az alábbi példa egy prezentációt PDF‑be exportál, és a konzolra írja a betűkészlet-helyettesítési figyelmeztetéseket. Figyelmeztetés csak akkor kerül kiírásra, ha egy nem elérhető betűkészletet helyettesítenek az exportálás során.

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

{{% alert color="info" title="Megjegyzés" %}}
További információk a betűkészlet‑helyettesítésről: lásd a [Betűkészlet‑helyettesítés](/slides/hu/nodejs-java/font-substitution/) cikket.
{{% /alert %}}

### **Kezelje a betűkészleteket, amelyeknek nincs dedikált félkövér változata**

A prezentáció képes félkövér formázást alkalmazni a szövegre akkor is, ha a betűkészletnek nincs dedikált félkövér változata. A szöveg szintetikus félkövérrel is megjelenhet, amely mesterségesen vastagabbá teszi a normál glifeket. Ha ez a szöveg túl nehéznek vagy egyébként eltérőnek tűnik a kívánt PDF‑megjelenéshez képest, próbálja meg hívni a [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) metódust `true` értékkel. Ez az opció a PDF exportálás során bitmapként rendereli az érintett szöveget, és bizonyos betűkészletek esetén javíthatja a megjelenést. Alapértelmezett értéke `false`.

A mintaprezentáció két szövegdobozt tartalmaz: egyet normál szöveggel és egyet ugyanarra a betűkészletre alkalmazott félkövér formázással, amelynek nincs dedikált félkövér változata. Az alábbi példa betölti a prezentációt, engedélyezi a nem támogatott betűkészlet‑stílusok rasterizálását, és PDF‑be exportálja:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

let presentation = new aspose.slides.Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

A következő előnézetek a letiltott és az engedélyezett kimenetet mutatják. Ebben a példában a félkövér szöveg nehezebb vonalakkal jelenik meg, ha az opció le van tiltva. Az opció engedélyezése esetén a vonalak vékonyabbak; a normál szöveg változatlan marad. Hasonlítsa össze az eredményeket, mielőtt beállítaná a prezentációnál.

| Letiltott opció (`false`, az alapértelmezett) | Engedélyezett opció (`true`) |
|---|---|
| ![PDF a nem támogatott betűkészlet‑stílus rasterizálásával letiltva](unsupported-bold-disabled.png) | ![PDF a nem támogatott betűkészlet‑stílus rasterizálásával engedélyezve](unsupported-bold-enabled.png) |

Ebben a példában az opció engedélyezése csak a félkövér szöveget bitmapté alakítja: nem lehet kijelölni, másolni vagy szövegként keresni OCR nélkül, és a szélei lágyabbak 800 %-os nagyítással. A normál szöveg továbbra is kereshető. Ha az opció ki van kapcsolva, mindkét karakterlánc szöveg marad.

Ez az opció a félkövérként formázott szöveget rasterizálja, ha a betűkészletnek nincs dedikált félkövér változata. A [Betűkészlet‑helyettesítés](/slides/hu/nodejs-java/font-substitution/) ehelyett egy másik betűkészletet választ, ha az eredeti nem elérhető.

## **Kiválasztott diák konvertálása PowerPoint‑ból PDF‑be**

Az alábbi példa a prezentáció 1. és 3. diáját exportálja PDF‑be. A tömbben szereplő diák száma egyalapú, és a bemeneti prezentációnak legalább három diával kell rendelkeznie.

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

Az alábbi példa a prezentáció első diáját átmásolja egy új prezentációba, amelynek dia mérete 612 × 792 pont (8,5 × 11 hüvelyk). A dia tartalmát átméretezi, hogy illeszkedjen, és az egyetlen diát PDF‑be exportálja.

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

    // Távolítsa el a létrehozott új prezentáció üres diáját.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint PDF konvertálása jegyzet diák nézetben**

Az alábbi példa egy prezentációt PDF‑be exportál, minden dia előadói jegyzeteit a dia alatt elhelyezve. Használjon előadói jegyzeteket tartalmazó prezentációt a megjelenítéshez.

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

Az Aspose.Slides lehetővé teszi egy olyan konverziós eljárás használatát, amely megfelel a [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) szabványnak. A PowerPoint dokumentumot PDF‑be exportálhatja a következő megfelelőségi szabványok bármelyikével: **PDF/A1a**, **PDF/A1b**, és **PDF/UA**.

Ez a kód bemutat egy PowerPoint‑PDF konverziós folyamatot, amely különböző megfelelőségi szabványok alapján több PDF‑et hoz létre:

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

{{% alert color="info" title="Megjegyzés" %}}
Az Aspose.Slides támogatja a PDF konverziós műveleteket, lehetővé téve a PDF fájlok konvertálását népszerű formátumokba. Végrehajthatja a [PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/), és a [PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) konverziókat. Egyéb PDF konverziós műveletek speciális formátumokba – [PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) – szintén támogatottak.
{{% /alert %}}

> **Megjegyzés:** PDF/UA exportálásakor az Aspose.Slides összetett grafikákat, például SmartArt, diagramokat és képleteket egyetlen alakzatként kezel. Az egyedi útvonal elemek nem maradnak meg különálló tartalomként, és artefaktumokként jelölhetők; alternatív szöveg csak az egész alakzatra vonatkozik.

## **GYIK**

**Konvertálhatok több PowerPoint fájlt PDF‑be egyszerre?**

Igen, az Aspose.Slides támogatja több PPT vagy PPTX fájl kötegelt konvertálását PDF‑be. A fájlokat ciklikusan bejárva programozottan alkalmazhatja a konverziós folyamatot.

**Lehet jelszóval védeni a konvertált PDF‑et?**

Igen. A konverziós folyamat során a [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) osztály segítségével állíthat be jelszót és meghatározhatja a hozzáférési jogosultságokat.

**Hogyan foglalhatom bele a rejtett diákot a PDF‑be?**

Hívja meg a [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) metódust `true` értékkel a [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) osztályban, hogy a rejtett diák a kapott PDF‑ben is megjelenjenek.

**Meg tudja az Aspose.Slides fenntartani a képek magas minőségét a PDF‑ben?**

Igen, a képek minőségét a [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) osztályban található [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) és [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) metódusok használatával szabályozhatja, hogy a PDF‑jében magas minőségű képek legyenek.

**Támogatja az Aspose.Slides a PDF/A megfelelőségi szabványokat?**

Igen, az Aspose.Slides lehetővé teszi olyan PDF‑ek exportálását, amelyek megfelelnek a [különféle szabványoknak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/), beleértve a PDF/A1a, PDF/A1b és PDF/UA szabványokat, ezáltal biztosítva, hogy dokumentumai megfeleljenek a hozzáférhetőségi és archiválási követelményeknek.

## **További források**

- [Aspose.Slides Node.js for Java dokumentáció](/slides/hu/nodejs-java/)
- [Aspose.Slides Node.js for Java API referencia](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose ingyenes online konvertálók](https://products.aspose.app/slides/conversion)