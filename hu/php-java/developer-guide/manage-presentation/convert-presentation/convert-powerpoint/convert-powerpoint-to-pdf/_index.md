---
title: PPT és PPTX konvertálása PDF-be PHP-ben [Haladó funkciók beépítve]
linktitle: PowerPoint PDF-re
type: docs
weight: 40
url: /hu/php-java/convert-powerpoint-to-pdf/
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
- PHP
- Aspose.Slides
description: "PowerPoint PPT/PPTX konvertálása magas minőségű, kereshető PDF-ekre PHP-ben az Aspose.Slides használatával, gyors kódrészletekkel és haladó konverziós beállításokkal."
---
## **Áttekintés**

A PowerPoint‑prezentációk (PPT, PPTX, ODP stb.) PDF formátumba konvertálása PHP‑ben több előnnyel jár, többek között különböző eszközök közötti kompatibilitással és a prezentáció elrendezésének és formázásának megőrzésével. Ez az útmutató bemutatja, hogyan konvertálhatók a prezentációk PDF‑dokumentumokká, használhatók különféle beállítások a képek minőségének szabályozására, a rejtett diák beillesztésére, a PDF‑fájlok jelszóval való védelmére, a betűkészlet‑helyettesítések észlelésére, meghatározott diák kiválasztására a konverzióhoz, valamint a megfelelőségi szabványok alkalmazására a kimeneti dokumentumokra.

## **PowerPoint‑PDF konverziók**

Az Aspose.Slides használatával a következő formátumú prezentációkat konvertálhatja PDF‑be:

* **PPT**
* **PPTX**
* **ODP**

A prezentáció PDF‑be konvertálásához a fájlnevet argumentumként adja át a [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztálynak, majd a [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) metódussal mentse a prezentációt PDF‑ként. A [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) osztály a [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) metódust biztosítja, amelyet általában a prezentáció PDF‑be konvertálására használnak.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides for PHP via Java beilleszti az API‑információkat és a verziószámot a kimeneti dokumentumokba. Például egy prezentáció PDF‑be konvertálásakor az Aspose.Slides az Application mezőbe a „*Aspose.Slides*” értéket, a PDF Producer mezőbe pedig a „*Aspose.Slides v XX.XX*” formátumú értéket helyezi. **Megjegyzés** hogy nem adható utasítás az Aspose.Slidesnek ezen információk módosítására vagy eltávolítására a kimeneti dokumentumokból.
{{% /alert %}}

Aspose.Slides lehetővé teszi a következő konverziókat:

* Teljes prezentációk PDF‑be
* A prezentáció egyes diái PDF‑be

Aspose.Slides a prezentációkat PDF‑be exportálja, biztosítva, hogy a keletkezett PDF‑ek szorosan megegyezzenek az eredeti prezentációkkal. Az átalakítás során a következő elemek és attribútumok pontosan megjelennek:

* Képek
* Szövegdobozok és alakzatok
* Szövegformázás
* Bekezdésformázás
* Hiperhivatkozások
* Fejléc és lábléc
* Felsorolások
* Táblázatok

## **PowerPoint PDF‑re konvertálása**

Az alapértelmezett PowerPoint‑PDF konverziós folyamat az alapértelmezett beállításokat használja. Ebben az esetben az Aspose.Slides a megadott prezentációt a legoptimálisabb beállításokkal, maximális minőségi szinteken próbálja PDF‑be konvertálni.

A következő példa betölt egy prezentációt, és az alapértelmezett exportbeállításokkal menti az összes látható diát PDF‑ként.

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
Az Aspose ingyenes online [**PowerPoint‑PDF konvertert**](https://products.aspose.app/slides/conversion/ppt-to-pdf) kínál, amely bemutatja a prezentáció‑PDF konverziós folyamatot. Tesztelheti ezt a konvertert a leírt eljárás élő megvalósításához.
{{% /alert %}}

## **PowerPoint PDF‑re konvertálás opciókkal**

Az Aspose.Slides egyedi beállításokat—a [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) osztály alatti tulajdonságokat—biztosít, amelyekkel testre szabhatja a keletkezett PDF‑et, jelszóval zárolhatja azt, vagy megadhatja a konverziós folyamat menetét.

### **PowerPoint PDF‑re konvertálás egyedi opciókkal**

Egyedi konverziós beállítások használatával meghatározhatja a raster képek kívánt minőségi beállítását, megadhatja a metafájlok kezelésének módját, beállíthatja a szöveg tömörítési szintjét, konfigurálhatja a képek DPI‑ját és egyebeket.

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

### **Képtömörítés automatikus kiválasztása**

Amikor egy prezentáció sok fényképet vagy képernyőképet tartalmaz, az exportált PDF méretének csökkentése megkönnyítheti az e‑mailben történő küldést vagy letöltést. Hívja a [PdfOptions::setBestImagesCompressionRatio](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) metódust `true` értékkel, hogy a PDF‑export során automatikusan kiválassza a legmegfelelőbb tömörítési algoritmust minden egyes képhez.

A következő példa betölt egy meglévő prezentációt, engedélyezi a képtömörítés automatikus kiválasztását, és PDF‑dokumentumként menti. A többi PDF‑export beállítás az alapértelmezett értékeket megtartja.

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setBestImagesCompressionRatio(true);

$presentation = new Presentation("image-heavy.pptx");
try {
    $presentation->save("image-heavy.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Ez az opció minden képre kiválaszt egy tömörítési algoritmust. A [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) értékének csökkentése a JPEG képminőség romlását eredményezi, míg a [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) értékének csökkentése lehetővé teszi a képek alacsonyabb felbontásra való mintavételezését, ami részletcsökkenéshez vezethet. Az automatikus tömörítés kiválasztásának engedélyezése önmagában nem csökkenti ezeket a beállításokat.

A képtömörítési algoritmusok kiválasztása további feldolgozási időt és memóriát igényel. A méretcsökkenés a prezentáció képeitől és az export beállításaitól függ; nem garantálható állandó csökkenés minden prezentáció esetén.

### **Beágyazott OLE fájlok megőrzése PDF mellékletekként**

Ha egy prezentáció beágyazott Excel munkafüzetet tartalmaz, előfordulhat, hogy a PDF‑fogadók szeretnék hozzáférni a munkafüzet adataihoz, valamint megtekinteni a diákat. Hívja a [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) metódust `true` értékkel, hogy a beágyazott OLE fájlokat mellékletekként megőrizze a keletkezett PDF‑ben.

Az alapértelmezett érték `false`: az OLE objektum előnézeti képe vagy ikonját megjeleníti a PDF‑oldalon, de a beágyazott fájlt nem tartalmazza mellékletként. Az opció `true`-ra állítása továbbiként hozzáadja a fájl adatát. Az előnézet vizuális reprezentáció marad; a melléklet lehetővé teszi a fogadók számára a beágyazott fájl különálló megnyitását vagy mentését. Az OLE objektum nem válik interaktív Excel munkalappá a PDF‑oldalon.

A következő példa betölt egy olyan prezentációt, amely már tartalmaz beágyazott Excel munkafüzetet, és PDF‑ként exportálja a munkafüzet csatolásával.

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

1. Nyissa meg az exportált PDF‑et olyan megjelenítőben, amely támogatja a fájl mellékleteket, például az Adobe Acrobat Reader‑ben.
2. Nyissa meg a megjelenítő **Mellékletek** paneljét, és keresse meg a beágyazott munkafüzetet.
3. Mentse el a mellékletet, és nyissa meg Excelben az adatok ellenőrzéséhez, vagy közvetlenül nyissa meg, ha a megjelenítő engedélyezi. A PDF‑oldalon megjelenő előnézet különbözik a melléklettől.

{{% alert color="info" title="Note" %}}
A PDF/A szabványok korlátozásokat szabnak a mellékletekre: a PDF/A-1 tiltja a beágyazott fájlokat, a PDF/A-2 csak PDF/A mellékleteket engedélyez, a PDF/A-3 pedig más fájltípusokat, köztük Excel munkafüzeteket is megenged. Ezek a szabványok követelményei, nem az Aspose.Slides speciális korlátozásai. Ez a példa az alapértelmezett PDF megfelelőségi beállítást használja, és nem demonstrálja a PDF/A exportot.
{{% /alert %}}

### **PowerPoint PDF‑re konvertálás rejtett diák használatával**

Ha egy prezentáció rejtett diákat tartalmaz, a [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) metódust a [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) osztályból használva beillesztheti a rejtett diát a keletkezett PDF oldalaiba.

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

### **PowerPoint PDF‑re konvertálás jelszóval védett PDF‑ként**

A következő példa egy prezentációt PDF‑ként exportál, amely a `password` jelszó megadása nélkül nem nyitható meg. A hozzáférési jogosultságok engedélyezik a nyomtatást, beleértve a magas minőségű nyomtatást.

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

### **Betűkészlet‑helyettesítések észlelése**

Az Aspose.Slides a [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) metódust a [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) osztályban biztosítja, amely lehetővé teszi a betűkészlet‑helyettesítések észlelését a prezentáció‑PDF konverziós folyamat során.

A következő példa egy prezentációt PDF‑ként exportál, és a konzolra írja a betűkészlet‑helyettesítési figyelmeztetéseket. Figyelmeztetés csak akkor jelenik meg, ha exportálás közben egy nem elérhető betűkészletet helyettesítenek.

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
A betűkészlet‑helyettesítésekkel kapcsolatos további információkért tekintse meg a [Font Substitution](/slides/hu/php-java/font-substitution/) cikket.
{{% /alert %}}

### **Betűtípusok kezelése, amelyeknek nincs saját félkövér változata**

Egy prezentáció képes félkövér formázást alkalmazni a szövegre, még akkor is, ha a betűtípusnak nincs saját félkövér változata. A szöveg szintetikus félkövérrel is megjelenhet, ami mesterségesen megvastagítja a normál glifeket. Ha ez a szöveg túl nehézkesnek vagy a PDF‑ben eltérőnek tűnik a kívánt megjelenéstől, próbálja meg hívni a [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) metódust `true` értékkel. Ez az opció a PDF‑export során bitmapként rendereli az érintett szöveget, és bizonyos betűtípusok esetén javíthatja a megjelenést. Alapértelmezett értéke `false`.

A minta prezentáció két szövegdobozt tartalmaz: egyet normál szöveggel, és egyet ugyanazon betűtípusra alkalmazott félkövér formázással, amelynek nincs saját félkövér változata. A következő példa betölti a prezentációt, engedélyezi a nem támogatott betűtípus‑stílusok rasterizálását, és PDF‑ként exportálja:

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

Az alábbi előnézetek mutatják a letiltott és az engedélyezett kimenetet. Ebben a példában a félkövér szöveg vastagabb vonalakkal jelenik meg a opció letiltásakor. Az opció engedélyezése esetén a vonalak vékonyabbak; a normál szöveg változatlan. Hasonlítsa össze az eredményeket, mielőtt beállítaná a prezentációját.

| Letiltott opció (`false`, alapértelmezett) | Engedélyezett opció (`true`) |
|---|---|
| ![PDF a nem támogatott betűtípus‑stílus rasterizálásával letiltva](unsupported-bold-disabled.png) | ![PDF a nem támogatott betűtípus‑stílus rasterizálásával engedélyezve](unsupported-bold-enabled.png) |

Ebben a példában az opció engedélyezése csak a félkövér szöveget alakítja bitmapkévé: nem lehet kijelölni, másolni vagy szövegként keresni OCR nélkül, és a szélei 800 % nagyításnál lágyabbnak tűnnek. A normál szöveg továbbra is kereshető marad. Letiltott opció esetén mindkét szöveg karakterként marad.

Ez az opció rasterizálja a félkövérként formázott szöveget, ha a betűtípusnak nincs saját félkövér változata. A [Font substitution](/slides/hu/php-java/font-substitution/) helyette másik betűtípust választ, ha az eredeti nem elérhető.

## **Kijelölt diák konvertálása PowerPoint‑ból PDF‑be**

A következő példa az 1‑es és 3‑as diákot exportálja egy prezentációból PDF‑be. Az tömbben szereplő diák számozása egytől indul, és a bemeneti prezentációnak legalább három diája kell legyen.

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

## **PowerPoint PDF‑re konvertálás egyedi dia mérettel**

A következő példa az első diát egy új prezentációba másolja, 612 × 792 pont (8,5 × 11 hüvelyk) dia mérettel. A dia tartalmát átméretezi, hogy illeszkedjen, és a egyetlen diát PDF‑be exportálja.

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

    // Távolítsa el az új prezentáció által létrehozott üres diát.
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **PowerPoint PDF‑re konvertálás jegyzet dia nézetben**

A következő példa egy prezentációt PDF‑ként exportál, minden dia előadói jegyzeteit a dia alá helyezve. Használjon olyan prezentációt, amely előadói jegyzeteket tartalmaz, hogy lássa az eredményt.

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

## **PDF hozzáférhetőségi és megfelelőségi szabványok**

Az Aspose.Slides lehetővé teszi egy olyan konverziós eljárás használatát, amely megfelel a [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) irányelveinek. A PowerPoint‑dokumentumot PDF‑ként exportálhatja bármelyik alábbi megfelelőségi szabvánnyal: **PDF/A1a**, **PDF/A1b** és **PDF/UA**.

Ez a kód bemutat egy PowerPoint‑PDF konverziós folyamatot, amely különböző megfelelőségi szabványok alapján több PDF‑et hoz létre:

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
Az Aspose.Slides támogatja a PDF konverziós műveleteket, lehetővé téve a PDF fájlok konvertálását népszerű fájlformátumokba. Végrehajthatók a [PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), és [PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) konverziók. Egyéb PDF konverziós műveletek speciális formátumokra—[PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), és [PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—szintén támogatottak.
{{% /alert %}}

> **Megjegyzés:** PDF/UA exportálásakor az Aspose.Slides a komplex grafikákat, például a SmartArt-et, diagramokat és képleteket egyetlen alakzatként kezeli. Az egyes útelemek nem maradnak meg különálló tartalomként, és lehetnek jelölve artefaktumokként; alternatív szöveget csak a teljes alakzatra biztosít.

## **GYIK**

**Több PowerPoint‑fájlt konvertálhatok egyszerre PDF‑be?**

Igen, az Aspose.Slides támogatja több PPT vagy PPTX fájl kötegelt konvertálását PDF‑be. Programozottan iterálhat a fájlokon, és alkalmazhatja a konverziós folyamatot.

**Lehet jelszóval védeni a konvertált PDF‑et?**

Igen. Használja a [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) osztályt a jelszó beállításához és a hozzáférési jogosultságok meghatározásához a konverziós folyamat során.

**Hogyan tudom beilleszteni a rejtett diákat a PDF‑be?**

Hívja a [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) metódust `true` értékkel a [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) osztályban, hogy a rejtett diák bekerüljenek a keletkezett PDF‑be.

**Meg tudja az Aspose.Slides biztosítani a magas képi minőséget a PDF‑ben?**

Igen, a képek minőségét szabályozhatja a [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) és a [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) metódusok használatával a [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) osztályban, hogy a PDF‑ben magas minőségű képek legyenek.

**Támogatja az Aspose.Slides a PDF/A megfelelőségi szabványokat?**

Igen, az Aspose.Slides lehetővé teszi a PDF‑ek exportálását, amelyek megfelelnek a [különböző szabványoknak](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/), beleértve a PDF/A1a, PDF/A1b és PDF/UA szabványokat, biztosítva, hogy dokumentumai megfeleljenek a hozzáférhetőségi és archiválási követelményeknek.

## **További források**

- [Aspose.Slides for PHP via Java dokumentáció](/slides/hu/php-java/)
- [Aspose.Slides for PHP via Java API referencia](https://reference.aspose.com/slides/php-java/)
- [Aspose ingyenes online konverterek](https://products.aspose.app/slides/conversion)