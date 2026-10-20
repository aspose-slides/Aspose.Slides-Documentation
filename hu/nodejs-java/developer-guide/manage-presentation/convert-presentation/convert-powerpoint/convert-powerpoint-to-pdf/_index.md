---
title: "PPT és PPTX konvertálása PDF-be JavaScript-ben [Fejlett funkciók beépítve]"
linktitle: "PowerPoint PDF-be"
type: docs
weight: 40
url: /hu/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- "PowerPoint konvertálása"
- "prezentáció konvertálása"
- "PowerPoint PDF-be"
- "prezentáció PDF-be"
- "PPT PDF-be"
- "PPT konvertálása PDF-be"
- "PPTX PDF-be"
- "PPTX konvertálása PDF-be"
- "PowerPoint mentése PDF-ként"
- "PPT mentése PDF-ként"
- "PPTX mentése PDF-ként"
- "PPT exportálása PDF-be"
- "PPTX exportálása PDF-be"
- "melléklet"
- PDF/A1a
- PDF/A1b
- PDF/UA
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertálja a PowerPoint PPT/PPTX fájlokat nagy felbontású, kereshető PDF-ekbe az Aspose.Slides for Node.js használatával, gyors kódpéldákkal és fejlett konvertálási beállításokkal."
---
## **Áttekintés**

Az PowerPoint és OpenDocument (PPT, PPTX, ODP stb.) prezentációk PDF formátumba konvertálása JavaScriptben több előnnyel jár, többek között különböző eszközök közötti kompatibilitással és a prezentáció elrendezésének és formázásának megőrzésével. Ez az útmutató bemutatja, hogyan konvertálhatók a prezentációk PDF dokumentumokká, hogyan használhatók különféle beállítások a képminőség szabályozásához, a rejtett diák belefoglalásához, a PDF fájlok jelszóval való védelméhez, a betűkészlet-helyettesítések észleléséhez, a konkrét diák kiválasztásához a konvertáláshoz, valamint a megfelelőségi szabványok alkalmazásához a kimeneti dokumentumokra.

## **PowerPoint PDF konverziók**

Az Aspose.Slides használatával a következő formátumokból konvertálhatja a prezentációkat PDF-be:

* **PPT**
* **PPTX**
* **ODP**

A prezentáció PDF-be konvertálásához adja meg a fájlnevet argumentumként a [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztálynak, majd mentse a prezentációt PDF-ként a [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) metódus használatával. A [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) osztály a [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/save/) metódust biztosítja, amelyet általában a prezentáció PDF-be konvertálásához használnak.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides for Node.js via Java beilleszti az API információkat és a verziószámot a kimeneti dokumentumokba. Például, amikor egy prezentációt PDF-be konvertál, az Aspose.Slides a Application mezőt "*Aspose.Slides*" értékkel, a PDF Producer mezőt pedig "*Aspose.Slides v XX.XX*" formában tölti ki. **Note** hogy nem adhatja meg az Aspose.Slides-nek, hogy megváltoztassa vagy eltávolítsa ezt az információt a kimeneti dokumentumokból.
{{% /alert %}}

Az Aspose.Slides lehetővé teszi, hogy konvertáljon:

* Teljes prezentációk PDF-be
* Egyes diák egy prezentációból PDF-be

Az Aspose.Slides exportálja a prezentációkat PDF-be, biztosítva, hogy a kapott PDF-ek nagyon hasonlóak legyenek az eredeti prezentációkhoz. Az elemek és attribútumok pontosan jelennek meg a konvertálás során, beleértve:

* Képek
* Szövegdobozok és alakzatok
* Szövegformázás
* Bekezdésformázás
* Hiperhivatkozások
* Fejlécek és láblécek
* Listaelemek
* Táblázatok

## **Convert PowerPoint to PDF**

Az alapértelmezett PowerPoint-PDF konverziós folyamat alapértelmezett beállításokat használ. Ebben az esetben az Aspose.Slides megkísérli a megadott prezentáció PDF-be konvertálását optimális beállításokkal a legmagasabb minőségi szinteken.

Az alábbi példa betölt egy prezentációt, és az összes látható diát PDF-be menti az alapértelmezett export beállításokkal.

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
Az Aspose ingyenes online [**PowerPoint PDF konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) szolgáltatást kínál, amely bemutatja a prezentáció-PDF konverziós folyamatot. Tesztelheti ezt a konvertert, hogy élőben megvalósítsa a leírt eljárást.
{{% /alert %}}

## **Convert PowerPoint to PDF with Options**

Az Aspose.Slides egyéni beállításokat—tulajdonságokat a [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) osztályban—nyújt, amelyekkel testreszabhatja a kimeneti PDF-et, jelszóval védheti a PDF-et, vagy megadhatja a konvertálási folyamat menetét.

### **Convert PowerPoint to PDF with Custom Options**

Az egyéni konverziós beállításokkal meghatározhatja a raszteres képek preferált minőségi beállítását, megadhatja, hogyan kezeljék a metafájlokat, beállíthatja a szöveg tömörítési szintjét, konfigurálhatja a DPI-t a képekhez, és egyebeket.

Az alábbi példa egy prezentációt PDF 1.5 formátumba exportál JPEG minőség 90, kép felbontás 300 DPI, metafájlok PNG-ként mentve, és Flate szöveg tömörítéssel.

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

### **Automatically Select Image Compression**

Ha egy prezentáció sok fényképet vagy képernyőképet tartalmaz, az exportált PDF méretének csökkentése egyszerűbbé teheti az e-mail küldést vagy a letöltést. Hívja meg a [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) metódust `true` értékkel, hogy a PDF export során automatikusan kiválassza a legmegfelelőbb tömörítési algoritmust minden egyes képhez.

Az alábbi példa betölt egy meglévő prezentációt, engedélyezi az automatikus képkompresszió kiválasztását, és PDF-dokumentumként menti. Minden egyéb PDF export beállítás az alapértelmezett értékek maradnak.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Ez a beállítás minden képhez kiválaszt egy tömörítési algoritmust. A [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) értékének csökkentése JPEG képminőséget ront, míg a [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) értékének csökkentése alacsonyabb felbontású mintavételezést engedélyez, ami részletek elvesztését okozhat. Az automatikus tömörítés kiválasztásának engedélyezése önmagában nem csökkenti ezeket a beállításokat.

A képkompressziós algoritmusok kiválasztása további feldolgozási időt és memóriát igényel. A méretcsökkenés a prezentáció képei és export beállításaitól függ; fix csökkenés nem garantált minden prezentációra.

### **Preserve Embedded OLE Files as PDF Attachments**

Ha egy prezentáció beágyazott Excel-munkafüzetet tartalmaz, előfordulhat, hogy a PDF fogadók szeretnék elérni a munkafüzet adatait, illetve megtekinteni a diákat. Hívja meg a [setIncludeOleData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) metódust `true` értékkel, hogy a beágyazott OLE fájlokat mellékletként megőrizze a kimeneti PDF-ben.

Az alapértelmezett érték `false`: az OLE objektum előnézeti képe vagy ikonja megjelenik a PDF lapon, de a beágyazott fájl nem kerül mellékletként. Az opció `true`-ra állítása továbbá a fájl adatát is tartalmazza. Az előnézet továbbra is vizuális ábrázolás, a melléklet lehetővé teszi a fogadók számára a beágyazott fájl különálló megnyitását vagy mentését. Az OLE objektum nem válik interaktív Excel munkalappá a PDF lapon.

Az alábbi példa betölt egy prezentációt, amely már tartalmaz beágyazott Excel-munkafüzetet, és PDF-be exportálja a munkafüzet mellékletként csatolásával.

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

A végeredmény ellenőrzéséhez:

1. Nyissa meg az exportált PDF-et egy olyan megjelenítőben, amely támogatja a fájl mellékleteket, például az Adobe Acrobat Reader-ben.
2. Nyissa meg a megjelenítő **Mellékletek** paneljét, és keresse meg a beágyazott munkafüzetet.
3. Mentse el a mellékletet és nyissa meg Excelben, hogy ellenőrizze az adatokat, vagy nyissa meg közvetlenül, ha a megjelenítő engedélyezi. Az előnézet a PDF oldalon különálló a melléklettől.

{{% alert color="info" title="Note" %}}
A PDF/A szabványok korlátozásokat szabnak a mellékletekre: a PDF/A-1 tilos a beágyazott fájlokat, a PDF/A-2 csak PDF/A mellékleteket engedélyez, a PDF/A-3 pedig egyéb fájltípusokat, például Excel munkafüzeteket. Ezek a szabványok követelményei, nem az Aspose.Slides saját korlátozásai. Ez a példa az alapértelmezett PDF megfelelőség beállítást használja, és nem mutat be PDF/A exportot.
{{% /alert %}}

### **Convert PowerPoint to PDF with Hidden Slides**

Ha egy prezentáció rejtett diákat tartalmaz, a [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) metódust a [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) osztályból használva a rejtett diák is oldalként megjelennek a kimeneti PDF-ben.

Az alábbi példa egy prezentációt PDF-be exportál, beleértve minden rejtett diát.

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

### **Convert PowerPoint to a Password-Protected PDF**

Az alábbi példa egy prezentációt PDF-be exportál, amely megnyitásához a `password` jelszó szükséges. A hozzáférési engedélyek megengedik a nyomtatást, beleértve a nagy felbontású nyomtatást.

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

### **Detect Font Substitutions**

Az Aspose.Slides a [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/) metódust biztosítja a [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) osztály alatt, lehetővé téve a betűkészlet-helyettesítések észlelését a prezentáció-PDF konverziós folyamat során.

Az alábbi példa egy prezentációt PDF-be exportál, és a konzolra írja a betűkészlet-helyettesítési figyelmeztetéseket. Figyelmeztetés csak akkor jelenik meg, ha egy nem elérhető betűkészletet helyettesítenek az export során.

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
További információk a betűkészlet-helyettesítésről a [Font Substitution](/slides/hu/nodejs-java/font-substitution/) cikkben találhatók.
{{% /alert %}}

### **Handle Fonts Without a Dedicated Bold Typeface**

Egy prezentáció alkalmazhat félkövér formázást a szövegre akkor is, ha a betűkészletnek nincs külön félkövér változata. A szöveg továbbra is félkövérnek jelenhet meg szintetikus félkövérrel, amely mesterségesen megvastagítja a normál glifeket. Ha ez a szöveg túl nehéznek vagy a PDF-ben kívánt megjelenéstől eltérőnek tűnik, próbálja meg hívni a [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) metódust `true` értékkel. Ez a beállítás a PDF export során bitmapként rendereli az érintett szöveget, és javíthatja a megjelenését bizonyos betűkészleteknél. Alapértelmezett értéke `false`.

A minta prezentáció két szövegdobozt tartalmaz: egyet normál szöveggel és egyet ugyanarra a betűkészletre alkalmazott félkövér formázással, amelynek nincs külön félkövér változata. Az alábbi példa betölti a prezentációt, engedélyezi a nem támogatott betűstílusok raszterizálását, és PDF-be exportálja:

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

Az alábbi előnézetek a letiltott és az engedélyezett kimenetet mutatják. Ebben a példában a félkövér szöveg vastagabb vonalakkal jelenik meg a letiltott opcióval. Az engedélyezett opcióval a vonalak vékonyabbak, a normál szöveg változatlan marad. Hasonlítsa össze az eredményeket, mielőtt beállítaná a prezentációját.

| Letiltott opció (`false`, alapértelmezett) | Engedélyezett opció (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Ebben a példában az opció engedélyezése csak a félkövér szöveget bitmap-pé alakítja: nem lehet kijelölni, másolni vagy szövegként keresni OCR nélkül, és élei lágyabbak 800% nagyítással. A normál szöveg kereshető marad. Opció letiltásakor mindkét szöveg szöveg marad.

Ez az opció a félkövér formázású szöveget raszterizálja, ha a betűkészletnek nincs külön félkövér változata. A [Font substitution](/slides/hu/nodejs-java/font-substitution/) ehelyett másik betűkészletet választ, ha az eredeti nem elérhető.

## **Convert Selected Slides from PowerPoint to PDF**

Az alábbi példa egy prezentáció 1. és 3. diaját exportálja PDF-be. A tömbben szereplő diák számozása egy alapú, és a bemeneti prezentációnak legalább három diát kell tartalmaznia.

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

## **Convert PowerPoint to PDF with Custom Slide Size**

Az alábbi példa az első diát egy prezentációból egy új prezentációba másolja, amelynek diamérete 612 × 792 pont (8,5 × 11 hüvelyk). Átméretezi a diatartalmat, hogy illeszkedjen, és az egyetlen diát PDF-be exportálja.

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

    // Távolítsa el az új prezentáció létrehozásakor keletkezett üres diát.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Convert PowerPoint to PDF in Notes Slide View**

Az alábbi példa egy prezentációt PDF-be exportál, úgy, hogy minden dia előadói jegyzete a dia alatt helyezkedik el. Egy előadói jegyzeteket tartalmazó prezentációval láthatja az eredményt.

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

## **Accessibility and Compliance Standards for PDF**

Az Aspose.Slides lehetővé teszi egy olyan konverziós eljárás használatát, amely megfelel a [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) szabványnak. A PowerPoint dokumentumot PDF-be exportálhatja bármelyik következő megfelelőségi szabvánnyal: **PDF/A1a**, **PDF/A1b**, és **PDF/UA**.

Ez a kód egy PowerPoint-PDF konverziós folyamatot mutat be, amely több PDF-et hoz létre különböző megfelelőségi szabványok szerint:

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
Az Aspose.Slides támogatja a PDF konverziós műveleteket, lehetővé téve a PDF fájlok népszerű formátumokba történő konvertálását. Végrehajthatók a [PDF to HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF to JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) és [PDF to PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/) konverziók. A specializált formátumokba, például a [PDF to SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/) és [PDF to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) konverziók is támogatottak.
{{% /alert %}}

> **Note:** PDF/UA exportálásakor az Aspose.Slides a komplex grafikákat, például a SmartArt-ot, diagramokat és képleteket egyetlen ábraként kezeli. Az egyedi útvonal elemek nem maradnak meg különálló tartalomként, és esetleg hibákként jelölődnek; az alternatív szöveg csak az egész ábrához van megadva.

## **FAQ**

**Több PowerPoint fájlt konvertálhatok egyszerre PDF-be?**

Igen, az Aspose.Slides támogatja több PPT vagy PPTX fájl kötegelt konvertálását PDF-be. Fájljaikon iterálhat és programozottan alkalmazhatja a konvertálási folyamatot.

**Lehetséges jelszóval védeni a konvertált PDF-et?**

Igen. Használja a [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) osztályt a jelszó beállításához és az hozzáférési engedélyek meghatározásához a konvertálás során.

**Hogyan foglalhatom bele a rejtett diákot a PDF-be?**

Hívja meg a [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setshowhiddenslides/) metódust `true` értékkel a [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) osztályban, hogy a rejtett diák a kimeneti PDF-ben is megjelenjenek.

**Az Aspose.Slides képes fenntartani a magas képminőséget a PDF-ben?**

Igen, a képminőséget olyan metódusokkal szabályozhatja, mint a [setJpegQuality](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setjpegquality/) és a [setSufficientResolution](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/setsufficientresolution/) a [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) osztályban, hogy a PDF-jében magas minőségű képek legyenek.

**Támogatja az Aspose.Slides a PDF/A megfelelőségi szabványokat?**

Igen, az Aspose.Slides lehetővé teszi, hogy olyan PDF-eket exportáljon, amelyek megfelelnek a [various standards](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfcompliance/) közül, beleértve a PDF/A1a, PDF/A1b és PDF/UA szabványokat, ezáltal biztosítva, hogy dokumentumai megfeleljenek a hozzáférhetőségi és archiválási követelményeknek.

## **Additional Resources**

- [Aspose.Slides a Node.js Java dokumentációja](/slides/hu/nodejs-java/)
- [Aspose.Slides a Node.js Java API hivatkozása](https://reference.aspose.com/slides/nodejs-java/)
- [Aspose Ingyenes Online Konverterek](https://products.aspose.app/slides/conversion)