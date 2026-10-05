---
title: PPT és PPTX konvertálása PDF-be PHP-ben [Fejlett funkciók beépítve]
linktitle: PowerPoint PDF-be
type: docs
weight: 40
url: /hu/php-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- PowerPoint PDF-be
- prezentáció PDF-be
- PPT PDF-be
- PPT konvertálása PDF-be
- PPTX PDF-be
- PPTX konvertálása PDF-be
- PowerPoint mentése PDF-ként
- PPT mentése PDF-ként
- PPTX mentése PDF-ként
- PPT exportálása PDF-be
- PPTX exportálása PDF-be
- csatolmány
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Konvertálja a PowerPoint PPT/PPTX fájlokat magas minőségű, kereshető PDF-ekbe PHP-ben az Aspose.Slides használatával, gyors kódrészletekkel és fejlett konvertálási beállításokkal."
---
## **Áttekintés**

A PowerPoint‑prezentációk (PPT, PPTX, ODP stb.) PDF formátumba konvertálása PHP‑ben több előnnyel jár, többek között különböző eszközök közötti kompatibilitással és a prezentáció elrendezésének és formázásának megőrzésével. Ez az útmutató bemutatja, hogyan konvertálhatók a prezentációk PDF‑dokumentumokká, hogyan használhatók különféle beállítások a képek minőségének szabályozásához, a rejtett diák belefoglalásához, a PDF‑fájlok jelszóval való védelméhez, a betűkészlet‑cserék észleléséhez, a konkrét diák kiválasztásához a konvertáláshoz, valamint a megfelelőségi szabványok alkalmazásához a kimeneti dokumentumokra.

## **PowerPoint PDF konvertálások**

Az Aspose.Slides használatával a következő formátumú prezentációkat konvertálhatja PDF‑be:

* **PPT**
* **PPTX**
* **ODP**

A prezentáció PDF‑re konvertálásához adja át a fájlnevet argumentumként a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztálynak, majd a [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) metódussal mentse a prezentációt PDF‑ként. A [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztály a [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) metódust teszi elérhetővé, amelyet általában a prezentáció PDF‑re konvertálásához használnak.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides for PHP via Java beilleszti az API‑információkat és a verziószámot a kimeneti dokumentumokba. Például egy prezentáció PDF‑re konvertálásakor az Aspose.Slides az Application mezőt "*Aspose.Slides*" értékkel, a PDF Producer mezőt pedig "*Aspose.Slides v XX.XX*" formában tölti ki. **Megjegyzés**, hogy nem adhatja meg az Aspose.Slides‑nek, hogy módosítsa vagy eltávolítsa ezeket az információkat a kimeneti dokumentumokból.
{{% /alert %}}

Az Aspose.Slides lehetővé teszi, hogy konvertáljon:
* Teljes prezentációkat PDF‑be
* A prezentáció egyes diákját PDF‑be

Az Aspose.Slides a prezentációkat PDF‑be exportálja, biztosítva, hogy a kapott PDF‑ek szorosan megegyezzenek az eredeti prezentációkkal. Az elemek és attribútumok pontosan jelennek meg a konvertálás során, többek között:
* Képek
* Szövegdobozok és alakzatok
* Szövegformázás
* Bekezdésformázás
* Hiperhivatkozások
* Élőfejek és élőlábak
* Felsorolásjelek
* Táblázatok

## **PowerPoint konvertálása PDF‑be**

Az alapértelmezett PowerPoint‑PDF konvertálási folyamat alapértelmezett beállításokat használ. Ebben az esetben az Aspose.Slides a megadott prezentációt a legoptimálisabb beállításokkal, a legmagasabb minőségi szinteken próbálja PDF‑re konvertálni.

Az alábbi példa betölt egy prezentációt, és az alapértelmezett exportbeállításokkal menti az összes látható diát PDF‑be.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Az Aspose ingyenes online [**PowerPoint PDF konvertáló**](https://products.aspose.app/slides/conversion/ppt-to-pdf) szolgáltatást kínál, amely bemutatja a prezentáció‑PDF konvertálási folyamatot. Ezzel a konvertálóval tesztelheti az itt leírt eljárás élő megvalósítását.
{{% /alert %}}

## **PowerPoint konvertálása PDF‑be beállításokkal**

Az Aspose.Slides egyedi beállításokat – a [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) osztály tulajdonságait – biztosít, amelyekkel testreszabhatja a létrehozott PDF‑et, jelszóval lezárhatja, vagy meghatározhatja a konvertálási folyamat menetével kapcsolatos paramétereket.

### **PowerPoint konvertálása PDF‑be egyéni beállításokkal**

Az egyéni konvertálási beállítások használatával meghatározhatja a raszteres képek kívánt minőségét, megadhatja a metafájlok kezelésének módját, beállíthat egy szöveg‑tömörítési szintet, konfigurálhatja a képek DPI‑értékét, és egyebeket.

Az alábbi példa egy prezentációt PDF 1.5‑ként exportál, JPEG‑minőség 90‑re állítva, kép felbontás 300 DPI, a metafájlok PNG‑ként mentve, és Flate szövegtömörítéssel.

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Beágyazott OLE fájlok megőrzése PDF‑csatolmányként**

Ha egy prezentáció beágyazott Excel‑munkafüzetet tartalmaz, előfordulhat, hogy a PDF‑fogadók szeretnék elérni a munkafüzet adatait, valamint megtekinteni a diát. Hívja meg a [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) metódust `true`‑val, hogy a beágyazott OLE‑fájlok csatolmányként maradjanak a létrehozott PDF‑ben.

Az alapértelmezett érték `false`: az OLE‑objektum előnézeti képe vagy ikonja megjelenik a PDF‑oldalon, de a beágyazott fájl nem kerül csatolmányként bele. Az opció `true`‑ra állítása megjeleníti a fájl adatát is. Az előnézet továbbra is vizuális ábrázolás marad; a csatolmány lehetővé teszi a fogadók számára, hogy külön nyissák meg vagy mentsék a beágyazott fájlt. Az OLE‑objektum nem alakul interaktív Excel‑munkalappá a PDF‑oldalon.

Az alábbi példa betölt egy olyan prezentációt, amely már tartalmaz beágyazott Excel‑munkafüzetet, és azt PDF‑ként exportálja a munkafüzet csatolásával.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Az eredmény ellenőrzéséhez:
1. Nyissa meg az exportált PDF‑et olyan megjelenítővel, amely támogatja a fájlcsatolmányokat, például az Adobe Acrobat Readerrel.
2. Nyissa meg a megjelenítő **Csatolmányok** paneljét, és keresse meg a beágyazott munkafüzetet.
3. Mentse a csatolmányt, és nyissa meg Excelben az adatok ellenőrzéséhez, vagy nyissa meg közvetlenül, ha a megjelenítő engedélyezi. Az előnézet a PDF‑oldalon különálló a csatolmánytól.

{{% alert color="info" title="Note" %}}
**Megjegyzés** A PDF/A szabványok korlátozásokat szabnak a csatolmányokra: a PDF/A‑1 tiltja a beágyazott fájlokat, a PDF/A‑2 csak PDF/A‑csatolmányokat enged meg, a PDF/A‑3 pedig más fájltípusokat, köztük Excel‑munkafüzeteket is. Ezek a szabványok követelményei, nem az Aspose.Slides‑re vonatkozó korlátozások. Ez a példa az alapértelmezett PDF‑megfelelőségi beállítást használja, és nem mutat be PDF/A‑exportot.
{{% /alert %}}

### **PowerPoint konvertálása PDF‑be rejtett diákkal**

Ha egy prezentáció rejtett diákat tartalmaz, a [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) metódust a [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) osztályból használva a rejtett diák a létrehozott PDF‑ben is megjelennek oldalként.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **PowerPoint konvertálása jelszóval védett PDF‑be**

Az alábbi példa egy prezentációt olyan PDF‑ként exportál, amely megnyitásához a `password` jelszó szükséges. A hozzáférési jogosultságok engedélyezik a nyomtatást, beleértve a nagy felbontású nyomtatást.

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Betűkészlet‑cserék észlelése**

Az Aspose.Slides a [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) metódust a [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) osztály alatt biztosítja, amely lehetővé teszi a betűkészlet‑cserék észlelését a prezentáció‑PDF konvertálási folyamat során.

Az alábbi példa egy prezentációt PDF‑ként exportál, és a konzolra írja a betűkészlet‑csere figyelmeztetéseket. Figyelmeztetés csak akkor jelenik meg, ha egy nem elérhető betűkészletet cserélnek ki az export során.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
További információért a betűkészlet‑cserékről lásd a [Betűkészlet‑csere](/slides/hu/php-java/font-substitution/) cikket.
{{% /alert %}}

## **Kiválasztott diák konvertálása PowerPoint‑ból PDF‑be**

Az alábbi példa egy prezentáció 1‑es és 3‑as diáját exportálja PDF‑be. A tömbben a diák számozása egy‑alapú, és a bemeneti prezentációnak legalább három diát kell tartalmaznia.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **PowerPoint konvertálása PDF‑be egyéni diamérettel**

Az alábbi példa a prezentáció első diáját átmásolja egy új prezentációba, amelynek diamérete 612 × 792 pont (8,5 × 11 hüvelyk). A diatartalmat átméretezi, hogy illeszkedjen, és az egyetlen diát PDF‑be exportálja.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // Távolítsa el azt az üres diát, amelyet az új prezentáció létrehozott.

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **PowerPoint konvertálása PDF‑be jegyzetes dianézetben**

Az alábbi példa egy prezentációt PDF‑be exportál, amelyben minden dia előadói jegyzete a dia alatt jelenik meg. Használjon előadói jegyzeteket tartalmazó prezentációt a végeredmény megtekintéséhez.

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **PDF‑hez kapcsolódó hozzáférhetőség és megfelelőségi szabványok**

Az Aspose.Slides lehetővé teszi egy olyan konvertálási eljárás használatát, amely megfelel a [Webtartalom‑hozzáférhetőségi irányelvek (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) szabványnak. A PowerPoint dokumentumot PDF‑be exportálhatja a következő megfelelőségi szabványok bármelyikével: **PDF/A1a**, **PDF/A1b**, és **PDF/UA**.

Ez a kód bemutat egy PowerPoint‑PDF konvertálási folyamatot, amely különböző megfelelőségi szabványok alapján több PDF‑et állít elő:

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Az Aspose.Slides támogatja a PDF konvertálási műveleteket, lehetővé téve a PDF‑fájlok népszerű formátumokba való átalakítását. Végrehajthatja a [PDF‑t HTML‑re](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), a [PDF‑t képre](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), a [PDF‑t JPG‑re](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), illetve a [PDF‑t PNG‑re](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) konvertálásokat. Egyéb PDF‑konvertálási műveletek speciális formátumokra – [PDF‑t SVG‑re](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF‑t TIFF‑re](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), és [PDF‑t XML‑re](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) – szintén támogatottak.
{{% /alert %}}

> **Megjegyzés:** PDF/UA‑ba exportáláskor az Aspose.Slides a komplex grafikákat, például a SmartArt‑ot, diagramokat és képleteket egyetlen alakzatként kezeli. Az egyedi útvonal‑elemek nem maradnak meg különálló tartalomként, és esetleg műtárgyként vannak jelölve; alternatív szöveg csak az egész alakzatra vonatkozik.

## **GYIK**

**Konvertálhatok több PowerPoint fájlt egyszerre PDF‑be?**  
Igen, az Aspose.Slides támogatja a több PPT vagy PPTX fájl kötegelt PDF‑re konvertálását. A fájlokon programozott módon iterálhat, és alkalmazhatja a konvertálási folyamatot.

**Lehetséges a konvertált PDF jelszóval védése?**  
Igen. Használja a [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) osztályt a jelszó beállításához és a hozzáférési jogosultságok meghatározásához a konvertálási folyamat során.

**Hogyan foglalhatom bele a rejtett diákat a PDF‑be?**  
Hívja meg a [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) metódust `true`‑val a [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) osztályban, hogy a rejtett diák megjelenjenek a létrehozott PDF‑ben.

**Meg tudja az Aspose.Slides fenntartani a magas képi minőséget a PDF‑ben?**  
Igen, a képek minőségét úgy szabályozhatja, hogy a [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setJpegQuality) és a [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setSufficientResolution) metódusokat a [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) osztályban használja, biztosítva, hogy dokumentumai megfeleljenek a hozzáférhetőségi és archiválási követelményeknek.

**Támogatja az Aspose.Slides a PDF/A megfelelőségi szabványokat?**  
Igen, az Aspose.Slides lehetővé teszi olyan PDF‑ek exportálását, amelyek megfelelnek a [különféle szabványoknak](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), beleértve a PDF/A1a, PDF/A1b és PDF/UA szabványokat, ezáltal biztosítva, hogy dokumentumai megfeleljenek a hozzáférhetőségi és archiválási követelményeknek.

## **További források**

- [Aspose.Slides for PHP via Java dokumentáció](/slides/hu/php-java/)
- [Aspose.Slides for PHP via Java API referencia](https://reference.aspose.com/slides/php-java/)
- [Aspose ingyenes online konverterek](https://products.aspose.app/slides/conversion)