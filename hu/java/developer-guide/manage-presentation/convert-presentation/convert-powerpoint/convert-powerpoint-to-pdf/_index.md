---
title: PPT és PPTX konvertálása PDF-be Java-ban [Fejlett funkciók beépítve]
linktitle: PowerPoint PDF-re
type: docs
weight: 40
url: /hu/java/convert-powerpoint-to-pdf/
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
- Java
- Aspose.Slides
description: "Konvertálja a PowerPoint PPT/PPTX fájlokat magas minőségű, kereshető PDF-ekbe Java-ban az Aspose.Slides használatával, gyors kódrészletekkel és fejlett konverziós beállításokkal."
---
## **Áttekintés**

PowerPoint prezentációk (PPT, PPTX, ODP stb.) PDF formátumba konvertálása Java-ban több előnnyel jár, többek között különböző eszközök közötti kompatibilitással és a bemutató elrendezésének és formázásának megőrzésével. Ez az útmutató bemutatja, hogyan lehet a prezentációkat PDF dokumentumokká konvertálni, különféle beállításokkal szabályozni a képek minőségét, belefoglalni a rejtett diákot, jelszóval védeni a PDF fájlokat, felismerni a betűtípus helyettesítéseket, kiválasztani a konvertálandó diát, és alkalmazni a megfelelőségi szabványokat a kimeneti dokumentumokra.

## **PowerPoint PDF konverziók**

Az Aspose.Slides segítségével a következő formátumokban lévő prezentációkat konvertálhatja PDF-be:

* **PPT**
* **PPTX**
* **ODP**

Az prezentáció PDF-be konvertálásához adja át a fájlnevet argumentumként a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztálynak, majd mentse a prezentációt PDF-ként a [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódussal. A [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztály biztosítja a [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust, amelyet általában a prezentáció PDF-be konvertálásához használnak.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides for Java beilleszti az API-információkat és a verziószámot a kimeneti dokumentumokba. Például, amikor egy prezentációt PDF-be konvertál, az Aspose.Slides az Application mezőbe "*Aspose.Slides*" értéket, a PDF Producer mezőbe pedig "*Aspose.Slides v XX.XX*" formátumú értéket helyezi. **Megjegyzés** hogy nem adhatja ki az Aspose.Slides-nek, hogy megváltoztassa vagy eltávolítsa ezeket az információkat a kimeneti dokumentumokból.
{{% /alert %}}

Aspose.Slides lehetővé teszi a következők konvertálását:

* A teljes prezentáció PDF-be
* Egy prezentáció meghatározott diái PDF-be

Aspose.Slides a prezentációkat PDF-be exportálja, biztosítva, hogy a létrejövő PDF-ek szorosan megegyezzenek az eredeti prezentációkkal. Az átalakítás során az elemek és attribútumok pontosan jelennek meg, többek között:

* Képek
* Szövegdobozok és alakzatok
* Szövegformázás
* Bekezdésformázás
* Hiperhivatkozások
* Fejlécek és láblécek
* Felsorolásjelek
* Táblázatok

## **PowerPoint PDF konvertálás**

Az alapértelmezett PowerPoint‑PDF konverziós folyamat az alapbeállításokat használja. Ebben az esetben az Aspose.Slides megpróbálja a megadott prezentációt PDF‑be konvertálni a legoptimálisabb beállítások és a maximális minőségi szintek alkalmazásával.

A következő példában egy prezentációt betölt, majd az összes látható diát PDF‑be menti az alapértelmezett exportbeállításokkal.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Az Aspose egy ingyenes online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) kínál, amely bemutatja a prezentáció‑PDF konverziós folyamatot. A konverterrel tesztelheti a leírt eljárás gyakorlati megvalósítását.
{{% /alert %}}

## **PowerPoint PDF konvertálás opciókkal**

Az Aspose.Slides egyéni beállításokat—tulajdonságokat a [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) osztályban—biztosít, amelyekkel testre szabhatja a létrejövő PDF-et, jelszóval zárolhatja azt, vagy meghatározhatja, hogyan zajlódjon a konverziós folyamat.

### **PowerPoint PDF konvertálás egyéni opciókkal**

Egyéni konverziós beállítások használatával meghatározhatja a raszteres képek kívánt minőségi beállítását, megadhatja a metafájlok kezelését, beállíthatja a szöveg tömörítési szintjét, konfigurálhatja a képek DPI‑jét, és egyebeket.

A következő példa egy prezentációt exportál PDF 1.5‑ként, JPEG minőség 90‑re, képfelbontás 300 DPI‑ra, a metafájlok PNG‑ként mentése, valamint Flate szövegtömörítés.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setJpegQuality((byte)90);
pdfOptions.setSufficientResolution(300);
pdfOptions.setSaveMetafilesAsPng(true);
pdfOptions.setTextCompression(PdfTextCompression.Flate);
pdfOptions.setCompliance(PdfCompliance.Pdf15);

Presentation presentation = new Presentation("PowerPoint.pptx");

try {
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Automatikus képtömörítés kiválasztása**

Ha egy prezentáció sok fényképet vagy képernyőképet tartalmaz, a exportált PDF méretének csökkentése egyszerűbbé teheti a küldést vagy letöltést. Hívja a [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) metódust `true` értékkel, hogy a PDF‑export során automatikusan kiválassza a legmegfelelőbb tömörítési algoritmust minden képre.

A következő példában egy meglévő prezentációt betölt, engedélyezi az automatikus képtömörítés kiválasztását, és PDF‑dokumentumként menti. A többi PDF‑export beállítás az alapértelmezett értékek maradnak.

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setBestImagesCompressionRatio(true);

Presentation presentation = new Presentation("image-heavy.pptx");
try {
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Ez az opció minden képhez egy tömörítési algoritmust választ. A [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) értékének csökkentése JPEG képminőséget ront, míg a [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) érték csökkentése alacsonyabb felbontású mintavételezést tesz lehetővé, ami részletek elvesztéséhez vezethet. Az automatikus tömörítés kiválasztásának engedélyezése önmagában nem csökkenti ezeket a beállításokat.

Képtömörítési algoritmusok kiválasztása további feldolgozási időt és memóriát igényel. A méretcsökkenés a prezentáció képeitől és az export beállításaitól függ; nem garantált egy állandó csökkenés minden prezentáció esetén.

### **Beágyazott OLE fájlok megőrzése PDF mellékletekként**

Ha egy prezentáció beágyazott Excel munkafüzetet tartalmaz, akkor a PDF‑fogadók számára is hozzáférhetővé teheti a munkafüzet adatait, miközben a diákat megjeleníti. Hívja a [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) metódust `true` értékkel, hogy a beágyazott OLE fájlokat mellékletként megőrizze a létrehozott PDF‑ben.

Az alapértelmezett érték `false`: az OLE‑objektum előnézeti képe vagy ikonja megjelenik a PDF‑oldalon, de a beágyazott fájl nem kerül mellékletként hozzáadásra. A `true` beállítás további: a fájl adatait is mellékletként tartalmazza. Az előnézet továbbra is vizuális ábrázolás marad; a melléklet lehetővé teszi a fogadók számára, hogy a beágyazott fájlt külön megnyissák vagy elmentsék. Az OLE‑objektum nem válik interaktív Excel munkalappá a PDF‑oldalon.

A következő példa betölt egy olyan prezentációt, amely már tartalmaz egy beágyazott Excel munkafüzetet, és PDF‑ként exportálja a munkafüzettel mellékletként.

```java
import com.aspose.slides.*;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setIncludeOleData(true);

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

A végeredmény ellenőrzéséhez:

1. Nyissa meg az exportált PDF‑et egy fájlmellékleteket támogató nézőprogramban, például az Adobe Acrobat Readerben.
2. Nyissa meg a néző **Attachments** paneljét, és keresse meg a beágyazott munkafüzetet.
3. Mentse el a mellékletet, és nyissa meg Excelben az adatainak ellenőrzéséhez, vagy közvetlenül nyissa meg, ha a néző engedélyezi. A PDF‑oldalon megjelenő előnézet különálló a melléklettől.

{{% alert color="info" title="Note" %}}
A PDF/A szabványok mellékletekre vonatkozó korlátozásokat támasztanak: a PDF/A-1 tiltja a beágyazott fájlokat, a PDF/A-2 csak PDF/A mellékleteket engedélyez, a PDF/A-3 pedig más fájltípusokat, köztük Excel munkafüzeteket is engedélyez. Ezek a szabványok követelményei, nem az Aspose.Slides specifikus korlátozásai. Ez a példa az alapértelmezett PDF megfelelőség beállítást használja, és nem mutat be PDF/A exportot.
{{% /alert %}}

### **PowerPoint PDF konvertálás rejtett diák használatával**

Ha egy prezentáció rejtett diát tartalmaz, a [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) metódust a [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) osztályból használva a rejtett diák is megjelennek oldalként a létrehozott PDF‑ben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setShowHiddenSlides(true);

    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **PowerPoint PDF konvertálás jelszóval védett PDF‑kép**

A következő példában egy prezentációt PDF‑ként exportál, amelynek megnyitásához a `password` jelszó szükséges. A hozzáférési jogosultságok engedélyezik a nyomtatást, beleértve a nagy felbontású nyomtatást.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Betűtípus helyettesítések észlelése**

Az Aspose.Slides a [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) osztály alatt a [setWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) metódust biztosítja, amely lehetővé teszi a betűtípus helyettesítések észlelését a prezentáció‑PDF konverziós folyamat során.

A következő példa egy prezentációt PDF‑ként exportál, és a betűtípus helyettesítési figyelmeztetéseket a konzolra írja. Figyelmeztetés csak akkor jelenik meg, ha exportálás közben egy nem elérhető betűtípust helyettesítenek.

```java
import com.aspose.slides.*;

class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss && warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setWarningCallback(new FontSubstitutionHandler());

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
További információért a betűtípus helyettesítésről lásd a [Font Substitution](/slides/hu/java/font-substitution/) cikket.
{{% /alert %}} 

### **Betűtípusok kezelése, amelyeknek nincs külön **Bold** változata**

Egy prezentáció lehetővé teszi a félkövér formázás alkalmazását a szövegre, még akkor is, ha a betűtípusnak nincs külön **Bold** változata. A szöveg továbbra is félkövérnek tűnhet szintetikus félkövérrel, amely mesterségesen megvastagítja a normál glifeket. Ha a szöveg túl nehézkesnek vagy a PDF‑ben kívánt megjelenéstől eltérőnek tűnik, próbálja meg a [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) metódust `true` értékkel hívni. Ez az opció bitmapként rendereli az érintett szöveget a PDF‑export során, és javíthatja megjelenését bizonyos betűtípusoknál. Alapértelmezett értéke `false`.

A mintaprezentáció két szövegdobozt tartalmaz: egyet normál szöveggel és egyet ugyanarra a betűtípusra alkalmazott félkövér formázással, amelynek nincs külön **Bold** változata. A következő példa betölti a prezentációt, engedélyezi a nem támogatott betűtípus stílusok raszterizálását, és PDF‑ként exportálja:

```java
import com.aspose.slides.PdfOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

PdfOptions pdfOptions = new PdfOptions();
pdfOptions.setRasterizeUnsupportedFontStyles(true);

Presentation presentation = new Presentation("unsupported-bold.pptx");
try {
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

A következő előnézetek mutatják a letiltott és a engedélyezett kimenetet. Ebben a példában a félkövér szöveg vastagabb vonalakkal jelenik meg a opció letiltásakor. Az opció engedélyezése esetén a vonalak vékonyabbak; a normál szöveg változatlan marad. Hasonlítsa össze az eredményeket, mielőtt beállítaná a prezentációját.

| Opció letiltva (`false`, az alapértelmezett) | Opció engedélyezve (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Ebben a példában az opció engedélyezése csak a félkövér szöveget alakítja bitmapké, amely nem jelölhető ki, másolható vagy kereshető szövegként OCR nélkül, és szélei 800%-os nagyítással lágyabbnak tűnnek. A normál szöveg továbbra is kereshető marad. Az opció letiltásakor mindkét szöveg karakterként marad.

Ez az opció a félkövérként formázott szöveget raszterizálja, ha a betűtípusnak nincs külön **Bold** változata. A [Font substitution](/slides/hu/java/font-substitution/) ehelyett egy másik betűtípust választ, ha az eredeti nem elérhető.

## **Kijelölt diák konvertálása PowerPointból PDF‑be**

A következő példa a prezentáció 1. és 3. diaját exportálja PDF‑be. A tömbben a dia számok egytől indulnak, és a bemeneti prezentációnak legalább három diával kell rendelkeznie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    int[] slides = { 1, 3 };
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **PowerPoint PDF konvertálás egyéni diákmérettel**

A következő példában az első diát egy új prezentációba másolja, amelynek diamérete 612 × 792 pont (8,5 × 11 hüvelyk). A diáktartalmat átméretezi, hogy illeszkedjen, és az egyetlen diát PDF‑be exportálja.

```java
import com.aspose.slides.*;

float slideWidth = 612;
float slideHeight = 792;

Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation resizedPresentation = new Presentation();

try {
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
    
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Eltávolítja az üres diát, amelyet az új prezentáció hozott létre.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint PDF konvertálás jegyzet diák nézetben**

A következő példában egy prezentációt exportál PDF‑be, úgy, hogy minden dia előadói jegyzetei a dia alá kerülnek. Használjon előadói jegyzetekkel rendelkező prezentációt a végeredmény megtekintéséhez.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **PDF hozzáférhetőség és megfelelőségi szabványok**

Az Aspose.Slides lehetővé teszi egy olyan konverziós eljárás használatát, amely megfelel a [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) irányelveknek. PDF‑re exportálhat PowerPoint dokumentumot a következő megfelelőségi szabványok valamelyikével: **PDF/A1a**, **PDF/A1b**, és **PDF/UA**.

Ez a kód bemutat egy PowerPoint‑PDF konverziós folyamatot, amely több PDF‑et állít elő különböző megfelelőségi szabványok alapján:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Az Aspose.Slides támogatja a PDF konverziós műveleteket, lehetővé téve a PDF fájlok konvertálását népszerű formátumokba. Végrehajthatja a [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/) és [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) konverziókat. Egyéb speciális formátumokba, például a [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/) és [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) konverziók is támogatottak.
{{% /alert %}}

> **Megjegyzés:** PDF/UA exportálásakor az Aspose.Slides a komplex grafikákat, mint a SmartArt, diagramok és képletek, egyetlen ábraként kezeli. Az egyedi útelemek nem maradnak meg különálló tartalomként, és lehetnek artefaktként jelölve; alternatív szöveg csak az egész ábrához kerül megadásra.

## **GYIK**

**Több PowerPoint fájlt tudok egyszerre PDF‑be konvertálni?**  
Igen, az Aspose.Slides támogatja több PPT vagy PPTX fájl kötegelt PDF‑be konvertálását. Programozottan végig iterálhat a fájlokon, és alkalmazhatja a konverziós folyamatot.

**Lehet jelszóval védeni a konvertált PDF‑et?**  
Igen. Használja a [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) osztályt a jelszó beállításához és a hozzáférési jogosultságok meghatározásához a konverziós folyamat során.

**Hogyan tudom a rejtett diát beilleszteni a PDF‑be?**  
Hívja a [setShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) metódust `true` értékkel a [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) osztályban, hogy a rejtett diák is benne legyenek a létrehozott PDF‑ben.

**Az Aspose.Slides képes fenntartani a magas képadatminőséget a PDF‑ben?**  
Igen, a képek minőségét a [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/) osztályban található [setJpegQuality](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) és [setSufficientResolution](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) metódusok használatával szabályozhatja, így magas minőségű képek lesznek a PDF‑ben.

**Az Aspose.Slides támogatja a PDF/A megfelelőségi szabványokat?**  
Igen, az Aspose.Slides lehetővé teszi olyan PDF‑ek exportálását, amelyek megfelelnek a [különböző szabványoknak](https://reference.aspose.com/slides/java/com.aspose.slides/pdfcompliance/), beleértve a PDF/A1a, PDF/A1b és PDF/UA szabványokat, ezzel biztosítva, hogy dokumentumai megfeleljenek a hozzáférhetőségi és archiválási követelményeknek.

## **További források**

- [Aspose.Slides for Java dokumentáció](/slides/hu/java/)
- [Aspose.Slides for Java API referencia](https://reference.aspose.com/slides/java/)
- [Aspose ingyenes online konvertálók](https://products.aspose.app/slides/conversion)