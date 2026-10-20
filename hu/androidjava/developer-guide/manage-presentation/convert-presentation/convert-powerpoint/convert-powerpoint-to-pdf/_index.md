---
title: PPT és PPTX konvertálása PDF‑re Androidon [Haladó funkciók]
linktitle: PowerPoint PDF‑re
type: docs
weight: 40
url: /hu/androidjava/convert-powerpoint-to-pdf/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- PowerPoint PDF‑re
- prezentáció PDF‑re
- PPT PDF‑re
- PPT konvertálása PDF‑re
- PPTX PDF‑re
- PPTX konvertálása PDF‑re
- PowerPoint mentése PDF‑ként
- PPT mentése PDF‑ként
- PPTX mentése PDF‑ként
- PPT exportálása PDF‑be
- PPTX exportálása PDF‑be
- melléklet
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Konvertálja a PowerPoint PPT/PPTX fájlokat magas minőségű, kereshető PDF‑ekre Java-ban az Aspose.Slides for Android segítségével, gyors kódrészletekkel és haladó konverziós beállításokkal."
---
## **Áttekintés**

A PowerPoint‑prezentációk (PPT, PPTX, ODP stb.) PDF formátumba konvertálása Androidon több előnnyel jár, többek között a különböző eszközök közötti kompatibilitással, valamint a bemutató elrendezésének és formázásának megőrzésével. Ez az útmutató bemutatja, hogyan konvertálhatók a prezentációk PDF‑dokumentumokká, hogyan használhatók különböző beállítások a képminőség szabályozásához, a rejtett diák belefoglalásához, a PDF‑fájlok jelszóval való védelméhez, a betűkészlet‑helyettesítések észleléséhez, a konkrét diák kiválasztásához a konvertáláshoz, valamint a megfelelőségi szabványok alkalmazásához a kimeneti dokumentumokon.

## **PowerPoint PDF konverziók**

Az Aspose.Slides segítségével a következő formátumú prezentációkat konvertálhatja PDF‑be:

* **PPT**
* **PPTX**
* **ODP**

A prezentáció PDF‑be konvertálásához adja át a fájlnevet argumentumként a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztálynak, majd mentse a prezentációt PDF‑ként a [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) módszerrel. A [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztály a [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) metódust teszi elérhetővé, amely általában a prezentáció PDF‑be konvertálásához használatos.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Android via Java hozzáfűzi az API‑információkat és a verziószámot a kimeneti dokumentumokhoz. Például, amikor egy prezentációt PDF‑be konvertál, az Aspose.Slides az Application mezőt a "*Aspose.Slides*" értékkel, a PDF Producer mezőt pedig a "*Aspose.Slides v XX.XX*" formátummal tölti ki. **Megjegyzés** hogy nem adhatja meg az Aspose.Slides‑nek, hogy módosítsa vagy eltávolítsa ezeket az információkat a kimeneti dokumentumokból.
{{% /alert %}}

Aspose.Slides lehetővé teszi:

* Teljes prezentációk PDF‑be
* Kiválasztott diák egy prezentációból PDF‑be

Aspose.Slides a prezentációkat PDF‑be exportálja, biztosítva, hogy a létrehozott PDF‑ek szorosan megfeleljenek az eredeti prezentációknak. Az elemek és attribútumok pontosan megjelennek a konverzió során, többek között:

* Képek
* Szövegdobozok és alakzatok
* Szövegformázás
* Bekezdésformázás
* Hiperhivatkozások
* Fejlécek és láblécek
* Felsorolásjel
* Táblázatok

## **PowerPoint PDF konvertálása**

A szabványos PowerPoint‑PDF konverziós folyamat alapértelmezett beállításokat használ. Ebben az esetben az Aspose.Slides megpróbálja a megadott prezentációt optimalizált beállításokkal, a legmagasabb minőségi szinteken PDF‑be konvertálni.

A következő példa betölt egy prezentációt, és az alapértelmezett exportbeállításokkal menti az összes látható diát PDF‑ként.

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
Az Aspose ingyenes online [**PowerPoint PDF konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) szolgáltatást kínál, amely bemutatja a prezentáció‑PDF konverziós folyamatot. A konverterrel tesztelhet a leírt eljárás élő megvalósítását.
{{% /alert %}}

## **PowerPoint PDF konvertálása beállításokkal**

Az Aspose.Slides egyéni beállításokat—tulajdonságokat a [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) osztályban—biztosít, amelyekkel testre szabhatja a létrehozott PDF‑et, jelszóval zárolhatja, vagy meghatározhatja a konverziós folyamat menetét.

### **PowerPoint PDF konvertálása egyedi beállításokkal**

Egyedi konverziós beállítások használatával megadhatja a raszter képek kívánt minőségi beállítását, meghatározhatja a metafájlok kezelését, beállíthatja a szöveg tömörítési szintjét, konfigurálhatja a képek DPI értékét, és egyebeket.

A következő példa egy prezentációt PDF 1.5 formátumba exportál, JPEG minőség 90‑re, képfelbontás 300 DPI‑ra, metafájlok PNG‑ként mentve, és Flate szövegtömörítéssel.

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

### **Kép tömörítés automatikus kiválasztása**

Amikor egy prezentáció sok fényképet vagy képernyőfelvételt tartalmaz, az exportált PDF méretének csökkentése megkönnyítheti az e‑mailben történő küldést vagy letöltést. Hívja meg a [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setBestImagesCompressionRatio-boolean-) metódust `true` értékkel, hogy a PDF exportálás során automatikusan kiválassza a legmegfelelőbb tömörítési algoritmust minden egyes képhez.

A következő példa betölt egy meglévő prezentációt, engedélyezi az automatikus kép tömörítés kiválasztását, és PDF‑dokumentumként menti. A többi PDF export beállítás az alapértelmezett értékeken marad.

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

Ez a beállítás minden egyes képhez algoritmust választ a tömörítéshez. A [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) érték csökkentése JPEG képek minőségét csökkenti, míg a [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) érték csökkentése lehetővé teszi a képek alacsonyabb felbontásra történő leképezését, ami részletek veszteségét eredményezheti. Az automatikus tömörítés választásának engedélyezése önmagában nem csökkenti ezeket a beállításokat.

Az automatikus tömörítés választásának engedélyezése önmagában nem csökkenti ezeket a beállításokat.

A kép tömörítési algoritmusok kiválasztása további feldolgozási időt és memóriát igényel. A méretcsökkentés a prezentáció képeitől és az export beállításaitól függ; fix csökkenés nem garantált minden prezentációnál.

### **Beágyazott OLE fájlok megőrzése PDF mellékletként**

Ha egy prezentáció beágyazott Excel munkafüzetet tartalmaz, előfordulhat, hogy a PDF címzetteknek szeretné elérhetővé tenni a munkafüz­et adatait is a diák mellett. Hívja meg a [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) metódust `true` értékkel, hogy a beágyazott OLE fájlok PDF mellékleteként megmaradjanak.

Az alapértelmezett érték `false`: az OLE objektum előnézeti képe vagy ikonja megjelenik a PDF oldalon, de a beágyazott fájl nem kerül mellékletként hozzáadásra. A beállítás `true`‑ra módosítása továbbiként a fájl adatokat is mellékletként hozzáadja. Az előnézet vizuális ábrázolás marad; a melléklet lehetővé teszi a címzetteknek a beágyazott fájl külön megnyitását vagy mentését. Az OLE objektum nem válik interaktív Excel munkalappá a PDF oldalon.

A következő példa betölt egy olyan prezentációt, amely már beágyazott Excel munkafüzetet tartalmaz, és PDF‑ként exportálja a munkafüzet mellékleteként.

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

1. Nyissa meg az exportált PDF‑et egy olyan nézőben, amely támogatja a mellékleteket, például az Adobe Acrobat Readerben.  
2. Nyissa meg a néző **Attachments** paneljét, és keresse meg a beágyazott munkafüzetet.  
3. Mentse a mellékletet, és nyissa meg Excelben az adat ellenőrzéséhez, vagy közvetlenül nyissa meg, ha a néző ezt megengedi. Az előnézet a PDF oldalon különálló a melléklettől.

{{% alert color="info" title="Note" %}}
A PDF/A szabványok korlátozásokat szabnak a mellékletekre: a PDF/A-1 tiltja a beágyazott fájlokat, a PDF/A-2 csak PDF/A mellékleteket engedélyez, a PDF/A-3 pedig más fájltípusokat, köztük Excel munkafüzeteket is engedélyez. Ezek a szabványkövetelmények, nem az Aspose.Slides‑re vonatkozó korlátozások. Ez a példa az alapértelmezett PDF megfelelőségi beállítást használja, és nem mutat be PDF/A exportot.
{{% /alert %}}

### **PowerPoint PDF konvertálása rejtett diákra**

Ha egy prezentáció rejtett diákot tartalmaz, a [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) metódust a [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) osztályból használva belefoglalhatja a rejtett diákat a kimeneti PDF oldalaiba.

A következő példa egy prezentációt PDF‑ként exportál, belefoglalva minden rejtett diát.

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

### **PowerPoint PDF konvertálása jelszóval védett PDF‑be**

A következő példa egy prezentációt PDF‑ként exportál, amely megnyitásához a `password` jelszó szükséges. A hozzáférési jogosultságok engedélyezik a nyomtatást, beleértve a kiváló minőségű nyomtatást.

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

### **Betűkészlet‑helyettesítések észlelése**

Az Aspose.Slides a [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) metódust a [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) osztály alatt biztosítja, ami lehetővé teszi a betűkészlet‑helyettesítések észlelését a prezentáció‑PDF konverzió során.

A következő példa egy prezentációt PDF‑ként exportál, és a konzolra írja a betűkészlet‑helyettesítési figyelmeztetéseket. Figyelmeztetés csak akkor jelenik meg, ha a exportálás során egy nem elérhető betűkészletet helyettesítenek.

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
További információért a betűkészlet‑helyettesítésekről lásd a [Font Substitution](/slides/hu/androidjava/font-substitution/) cikket.
{{% /alert %}}

### **Kezelje a nem dedikált félkövér íráskészlettel rendelkező betűtípusokat**

Egy prezentáció félkövér formázást alkalmazhat a szövegre, még ha a betűtípusa nem rendelkezik dedikált félkövér íráskészlettel is. A szöveg szintetikus félkövérrel is megjelenhet, ami mesterségesen vastagabbá teszi a normál glifeket. Ha ez a szöveg túl nehéznek tűnik vagy eltér a várt megjelenéstől a PDF‑ben, próbálja meg meghívni a [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles-boolean-) metódust `true` értékkel.

Ez a beállítás bitmapként rendereli az érintett szöveget a PDF exportálása során, és javíthatja a megjelenését bizonyos betűtípusoknál. Alapértelmezett értéke `false`.

A minta prezentáció két szövegdobozt tartalmaz: egyet normál szöveggel és egyet ugyanazon betűtípusra alkalmazott félkövér formázással, amelynek nincs dedikált félkövér íráskészlete. A következő példa betölti a prezentációt, engedélyezi a nem támogatott betűtípusstílusok rasterizálását, és PDF‑ként exportálja:

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

A következő előnézetek mutatják a letiltott és a engedélyezett kimenetet. Ebben a példában a félkövér szöveg vastagabb vonalakkal jelenik meg, ha a beállítás le van tiltva. Engedélyezve a vonalak vékonyabbak; a normál szöveg változatlan marad. Hasonlítsa össze az eredményeket, mielőtt kiválasztaná a beállítást a saját prezentációjához.

| Beállítás letiltva (`false`, az alapértelmezett) | Beállítás engedélyezve (`true`) |
|---|---|
| ![PDF a nem támogatott betűstílus rasterizálásával letiltva](unsupported-bold-disabled.png) | ![PDF a nem támogatott betűstílus rasterizálásával engedélyezve](unsupported-bold-enabled.png) |

Ebben a példában a beállítás engedélyezése csak a félkövér szöveget bitmapként képzi le: nem lehet kijelölni, másolni vagy szövegként keresni OCR nélkül, és az élei lágyabbak 800 % zoomnál. A normál szöveg kereshető marad. Letiltva mindkét karakterlánc szöveg marad.

Ez a beállítás a félkövérre formázott szöveget rasterizálja, ha a betűtípusa nem rendelkezik dedikált félkövér íráskészlettel. A [Font substitution](/slides/hu/androidjava/font-substitution/) ehelyett egy másik betűtípust választ, amikor az eredeti nem elérhető.

## **Kiválasztott diák konvertálása PowerPointból PDF‑be**

A következő példa a prezentáció 1. és 3. diaját exportálja PDF‑be. A tömbben szereplő diák száma egy‑alapú, és a bemeneti prezentációnak legalább három diát kell tartalmaznia.

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

## **PowerPoint PDF konvertálása egyéni diamérettel**

A következő példa az első diát egy új prezentációba másolja, melynek dia mérete 612 × 792 pont (8,5 × 11 hüvelyk). A diatartalmat átméretezi, hogy illeszkedjen, és az egyetlen diát PDF‑ként exportálja.

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

    // Távolítsa el az üres diát, amelyet az új prezentáció létrehozott.
    resizedPresentation.getSlides().removeAt(1);

    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **PowerPoint PDF konvertálása jegyzet‑diák nézetben**

A következő példa egy prezentációt PDF‑be exportál, minden dia előadói jegyzeteit a dia alá helyezve. Használjon előadói jegyzeteket tartalmazó prezentációt az eredmény megtekintéséhez.

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

## **PDF hozzáférhetőségi és megfelelőségi szabványok**

Az Aspose.Slides lehetővé teszi egy olyan konverziós eljárás használatát, amely megfelel a [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) szabványnak. A PowerPoint dokumentumot PDF‑be exportálhatja a következő megfelelőségi szabványok valamelyikével: **PDF/A1a**, **PDF/A1b**, és **PDF/UA**.

Ez a kód egy PowerPoint‑PDF konverziós folyamatot mutat be, amely különböző megfelelőségi szabványok alapján több PDF‑et állít elő:

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
Az Aspose.Slides PDF konvertálási műveleteket támogat, lehetővé téve a PDF‑fájlok népszerű formátumokra való konvertálását. Végezhet [PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), és [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) konverziókat. Egyéb PDF konvertálási műveletek speciális formátumokra — [PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), és [PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — szintén támogatottak.
{{% /alert %}}

> **Megjegyzés:** PDF/UA exportálásakor az Aspose.Slides a komplex grafikákat, például a SmartArt‑ot, diagramokat és képleteket egyetlen alakzatként kezeli. Az egyedi útvonal‑elemek nem maradnak meg különálló tartalomként, és előfordulhat, hogy artefaktként vannak jelölve; alternatív szöveg csak a teljes alakzatra vonatkozik.

## **GYIK**

**Több PowerPoint fájlt konvertálhatok egyszerre PDF‑be?**

Igen, az Aspose.Slides támogatja több PPT vagy PPTX fájl kötegelt PDF‑be konvertálását. A fájlokon programozottan iterálhat, és alkalmazhatja a konverziós folyamatot.

**Lehetőség van a konvertált PDF jelszóval való védelmére?**

Igen. A [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) osztályt használva állíthat be jelszót, és meghatározhatja a hozzáférési jogosultságokat a konverziós folyamat során.

**Hogyan foglaljam bele a rejtett diákat a PDF‑be?**

Hívja meg a [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) metódust `true` értékkel a [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) osztályban, hogy a rejtett diák benne legyenek a létrehozott PDF‑ben.

**Az Aspose.Slides képes megőrizni a magas képminőséget a PDF‑ben?**

Igen, a képminőséget a [setJpegQuality](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setJpegQuality-byte-) és a [setSufficientResolution](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setSufficientResolution-float-) metódusokkal a [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) osztályban szabályozhatja, így biztosíthatja a magas minőségű képeket a PDF‑ben.

**Az Aspose.Slides támogatja a PDF/A megfelelőségi szabványokat?**

Igen, az Aspose.Slides lehetővé teszi, hogy olyan PDF‑eket exportáljon, amelyek megfelelnek a [various standards](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfcompliance/) szabványoknak, beleértve a PDF/A1a, PDF/A1b és PDF/UA szabványokat, ezáltal biztosítva, hogy dokumentumai megfeleljenek a hozzáférhetőségi és archiválási követelményeknek.

## **További források**

- [Aspose.Slides Androidra Java‑val Dokumentáció](/slides/hu/androidjava/)
- [Aspose.Slides Androidra Java API referencia](https://reference.aspose.com/slides/androidjava/)
- [Aspose ingyenes online konverterek](https://products.aspose.app/slides/conversion)