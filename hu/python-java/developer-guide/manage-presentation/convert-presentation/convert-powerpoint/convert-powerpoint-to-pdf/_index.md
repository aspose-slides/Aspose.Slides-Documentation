---
title: PPT és PPTX konvertálása PDF-be Pythonon keresztül Java-val [Haladó funkciók beépítve]
linktitle: PowerPoint PDF-be
type: docs
weight: 40
url: /hu/python-java/convert-powerpoint-to-pdf/
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
- melléklet
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "PowerPoint PPT/PPTX konvertálása magas minőségű, kereshető PDF-re Pythonon keresztül Java-val az Aspose.Slides használatával, gyors kódpéldákkal és haladó konverziós opciókkal."
---
## **Áttekintés**

A PowerPoint-prezentációk (PPT, PPTX, ODP stb.) PDF formátumba konvertálása Pythonon keresztül Java-val több előnnyel jár, többek között különböző eszközök közötti kompatibilitással és a bemutató elrendezésének és formázásának megőrzésével. Ez az útmutató bemutatja, hogyan konvertálhatók a prezentációk PDF-dokumentumokká, hogyan használhatók különféle beállítások a képek minőségének szabályozásához, a rejtett diák beillesztéséhez, a PDF-fájlok jelszóval való védelméhez, a betűkészlet-helyettesítések észleléséhez, a konvertálandó diák kiválasztásához, valamint a megfelelőségi szabványok alkalmazásához a kimeneti dokumentumokon.

## **PowerPoint PDF konvertálások**

Az Aspose.Slides segítségével a következő formátumú prezentációkat konvertálhatja PDF-be:

* **PPT**
* **PPTX**
* **ODP**

A prezentáció PDF-be konvertálásához adja meg a fájlnevet argumentumként a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztálynak, majd mentse a prezentációt PDF-ként a [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) metódussal. A [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztály biztosítja a [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) metódust, amelyet általában a prezentáció PDF-be konvertálásához használnak.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java a kimeneti dokumentumokba beilleszti az API-információkat és a verziószámot. Például egy prezentáció PDF-be konvertálásakor az Aspose.Slides az Application mezőt a "*Aspose.Slides*" értékkel, a PDF Producer mezőt pedig a "*Aspose.Slides v XX.XX*" formátummal tölti ki. **Megjegyzés** hogy nem adhatja meg az Aspose.Slides számára, hogy ezt az információt megváltoztassa vagy eltávolítsa a kimeneti dokumentumokból.
{{% /alert %}}

Aspose.Slides lehetővé teszi, hogy konvertáljon:

* Teljes bemutatókat PDF-be
* Megadott diákat egy bemutatóból PDF-be

Aspose.Slides a prezentációkat PDF-be exportálja, biztosítva, hogy a kapott PDF-ek szorosan megfeleljenek az eredeti bemutatóknak. A konverzió során az elemek és attribútumok pontosan kerülnek megjelenítésre, többek között:

* Képek
* Szövegdobozok és alakzatok
* Szövegformázás
* Bekezdésformázás
* Hiperhivatkozások
* Fejlécek és élőfejek
* Felsorolások
* Táblázatok

## **PowerPoint PDF konvertálása**

A standard konverzió az alapértelmezett PDF export beállításokat használja. Egyedi beállításokat használjon, ha a képek minőségét, az oldal tartalmát vagy a PDF megfelelőséget szeretné szabályozni.

A következő példa betölt egy prezentációt, és az alapértelmezett export beállításokkal ment minden látható diát PDF-be.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose egy ingyenes online [**PowerPoint PDF konvertert**](https://products.aspose.app/slides/conversion/ppt-to-pdf) kínál, amely bemutatja a prezentáció PDF-be konvertálásának folyamatát. Tesztelheti ezt a konvertert a leírt eljárás élő megvalósításához.
{{% /alert %}}

## **PowerPoint PDF konvertálása opciókkal**

Aspose.Slides egyedi opciókat biztosít – a [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) osztályban található tulajdonságok –, amelyekkel testreszabhatja a kapott PDF-et, jelszóval zárolhatja azt, vagy meghatározhatja a konverziós folyamat menetét.

### **PowerPoint PDF konvertálása egyéni opciókkal**

Egyedi konverziós beállítások használatával meghatározhatja a raszteres képek kívánt minőségi szintjét, megadhatja a metafájlok kezelését, beállíthatja a szöveg tömörítési szintjét, konfigurálhatja a DPI-t képekhez, és egyebeket.

A következő példa a prezentációt PDF 1.5 formátumba exportálja, 90-es JPEG minőséggel, 300 DPI képfelbontással, a metafájlokat PNG-ként mentve, és Flate szöveg tömörítéssel.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Automatikus képtömörítés kiválasztása**

Egy prezentációban, ha sok fénykép vagy képernyőkép van, az exportált PDF méretének csökkentése egyszerűbbé teszi az e‑mailben küldést vagy a letöltést. Hívja meg a [PdfOptions.setBestImagesCompressionRatio](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setBestImagesCompressionRatio) metódust `True` értékkel, hogy az exportálás során automatikusan a legmegfelelőbb tömér

tési algoritmust válassza minden képre.

A következő példa betölt egy meglévő prezentációt, engedélyezi az automatikus képtömörítés kiválasztását, és PDF-dokumentumként menti. A többi PDF export beállítás az alapértelmezett értékeket megtartja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setBestImagesCompressionRatio(True)

presentation = Presentation("image-heavy.pptx")
try:
    presentation.save("image-heavy.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Ez az opció minden képre tömörítési algoritmust választ. A [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) értékének csökkentése JPEG képminőséget ront, míg a [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) értékének csökkentése alacsonyabb felbontásra történő lecsökkentést tesz lehetővé, ami részletek elvesztéséhez vezethet. Az automatikus tömörítés kiválasztásának engedélyezése önmagában nem csökkenti ezeket a beállításokat.

A képtömörítési algoritmusok kiválasztása további feldolgozási időt és memóriát igényel. A méretcsökkentés a prezentáció képeitől és az export beállításoktól függ; nem garantált állandó csökkenés minden prezentációra.

### **Beágyazott OLE fájlok megőrzése PDF mellékletekként**

Ha egy prezentáció beágyazott Excel-munkafüzetet tartalmaz, a PDF-olvasóknak szeretné lehetővé tenni a munkafüzet adatainak elérését, valamint a diák megtekintését. Hívja meg a [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) metódust `True` értékkel, hogy a beágyazott OLE-fájlok a kapott PDF-ben mellékletekként maradjanak.

Az alapértelmezett érték `False`: az OLE-objektum előnézeti képe vagy ikonjai a PDF-oldalon jelennek meg, de a beágyazott fájl nem kerül mellékletként hozzáadásra. A `True` értékre állítva a fájl adatai is mellékletként szerepelnek. Az előnézet vizuális megjelenítés marad; a melléklet lehetővé teszi a címzetteknek a beágyazott fájl különálló megnyitását vagy mentését. Az OLE-objektum nem válik interaktív Excel munkalappá a PDF-oldalon.

A következő példa betölt egy olyan prezentációt, amely már beágyazott Excel-munkafüzetet tartalmaz, és PDF-be exportálja, a munkafüzetet mellékletként csatolva.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

A végeredmény ellenőrzéséhez:

1. Hozza megnyitni az exportált PDF-et olyan nézőprogrammal, amely támogatja a fájl mellékleteket, például az Adobe Acrobat Readerrel.
2. A néző **Mellékletek** paneljét nyissa meg, és keresse meg a beágyazott munkafüzetet.
3. A mellékletet mentse, majd nyissa meg Excelben az adat ellenőrzéséhez, vagy közvetlenül nyissa meg, ha a néző engedélyezi. Az előnézet a PDF-oldalon különálló a melléklettől.

{{% alert color="info" title="Note" %}}
 A PDF/A szabványok korlátozásokat szabnak a mellékletekre: a PDF/A-1 tiltja a beágyazott fájlokat, a PDF/A-2 csak PDF/A mellékleteket enged meg, a PDF/A-3 pedig más fájltípusokat, köztük Excel munkafüzeteket is engedélyez. Ezek a szabványkövetelmények, nem az Aspose.Slides specifikus korlátozások. Ez a példa az alapértelmezett PDF megfelelőségi beállítást használja, és nem mutat be PDF/A exportot.
{{% /alert %}}

### **PowerPoint PDF konvertálása rejtett diákkal**

Ha egy prezentáció rejtett diákot tartalmaz, a [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) metódust a [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) osztályból használhatja, hogy a rejtett diák a kapott PDF oldalaként szerepeljenek.

A következő példa a prezentációt PDF-be exportálja, beleértve a rejtett diát is.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **PowerPoint PDF konvertálása jelszóval védett PDF-be**

A következő példa a prezentációt olyan PDF-be exportálja, amelyhez a `password` jelszó szükséges a megnyitáshoz. A hozzáférési engedélyek megengedik a nyomtatást, beleértve a nagy minőségű nyomtatást.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Betűkészlet-helyettesítések észlelése**

Aspose.Slides biztosítja a [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) metódust a [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) osztály alatt, lehetővé téve a betűkészlet-helyettesítések észlelését a prezentáció PDF-be konvertálása során.

A következő példa a prezentációt PDF-be exportálja, és a konzolra írja a betűkészlet-helyettesítési figyelmeztetéseket. Figyelmeztetés csak akkor jelenik meg, ha az exportálás során nem elérhető betűtípust helyettesítenek. Használjon JPype proxy-t a Java API figyelmeztetési visszahívásainak fogadásához. A Java leíró karakterláncot Python karakterlánccá konvertálja, mielőtt ellenőrizné az előtagját:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
További információért a betűkészlet-helyettesítésekről lásd a [Font Substitution](/slides/hu/python-java/font-substitution/) cikket.
{{% /alert %}}

### **Betűtípusok kezelése, amelyeknek nincs dedikált félkövér változatuk**

Egy prezentáció alkalmazhat félkövér formázást a szövegre még akkor is, ha a betűtípusnak nincs dedikált félkövér változata. A szöveg szintetikus félkövérrel is megjelenhet, ami mesterségesen megvastagítja a normál glifeket. Ha ez a szöveg túl nehéznek vagy eltérőnek tűnik a kívánt PDF-megjelenéshez képest, próbálja meg a [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) metódust `True` értékkel hívni. Ez az opció a PDF exportálása során bitmapként jeleníti meg az érintett szöveget, és javíthatja a megjelenését bizonyos betűtípusoknál. Az alapértelmezett érték `False`.

A minta prezentáció két szövegdobozt tartalmaz: egyet normál szöveggel és egyet ugyanazon betűtípusra alkalmazott félkövér formázással, amelynek nincs dedikált félkövér változata. A következő példa betölti a prezentációt, engedélyezi a nem támogatott betűstílusok rasterizálását, és PDF-be exportálja:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setRasterizeUnsupportedFontStyles(True)

presentation = Presentation("unsupported-bold.pptx")
try:
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

A következő előnézetek mutatják a kikapcsolt és a bekapcsolt kimenetet. Ebben a példában a félkövér szöveg vastagabb vonalakkal jelenik meg, ha az opció ki van kapcsolva. Az opció bekapcsolásával a vonalak vékonyabbak; a normál szöveg változatlan. Hasonlítsa össze az eredményeket, mielőtt beállítaná a prezentációját.

| Opció kikapcsolva (`False`, alapértelmezett) | Opció bekapcsolva (`True`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Ebben a példában az opció bekapcsolása csak a félkövér szöveget alakítja bitmapkévé: nem lehet kijelölni, másolni vagy OCR nélkül keresni szövegként, és a szélei lágyabbak 800%-os nagyítással. A normál szöveg továbbra is kereshető. Az opció kikapcsolásával mindkét szöveg karakterként marad.

Ez az opció rasterizálja a félkövérre formázott szöveget, ha a betűtípusnak nincs dedikált félkövér változata. A [Font substitution](/slides/hu/python-java/font-substitution/) helyette egy másik betűtípust választ, ha az eredeti nem elérhető.

## **Kiválasztott diák konvertálása PowerPointból PDF-be**

A [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) metódusnak átadott dia számok 1-től kezdődnek. Ez a példa a 1-es és 3-as diát exportálja, ha mindkettő létezik:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **PowerPoint PDF konvertálása egyedi dia mérettel**

Ez a példa az első diát 612 x 792 pont méretű (US Letter) oldalra exportálja. A diát egy új prezentációba klónozza a megadott mérettel, és a dia tartalmát a mérethez igazítja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # Távolítsa el az új prezentációval létrehozott üres diát.
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **PowerPoint PDF konvertálása jegyzetdia nézetben**

A következő példa a prezentációt PDF-be exportálja, minden dia előadói jegyzeteit a dia alá helyezve. Használjon olyan prezentációt, amely előadói jegyzeteket tartalmaz, az eredmény megtekintéséhez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **PDF hozzáférhetőségi és megfelelőségi szabványok**

Elérhető PDF-ek elkészítésekor tekintse meg a [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) útmutatót. Használja a [PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) metódust a kimeneti szabvány kiválasztásához: **PDF/A1a**, **PDF/A1b**, és **PDF/UA**.

Ez a kód bemutat egy PowerPoint-PDF konvertálási folyamatot, amely a különböző megfelelőségi szabványok alapján több PDF-et hoz létre:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()

    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)

    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **Megjegyzés:** PDF/UA exportálásakor az Aspose.Slides a komplex grafikai elemeket, például a SmartArt-ot, diagramokat és képleteket egyetlen alakzatként kezeli. Az egyes útvonal elemek nem maradnak meg különálló tartalomként, és esetleg artefaktként vannak jelölve; alternatív szöveg csak az egész alakzatra vonatkozik.

## **GYIK**

**Több PowerPoint-fájlt konvertálhatok egyszerre PDF-be?**

Igen, az Aspose.Slides támogatja a több PPT vagy PPTX fájl kötegelt PDF-be konvertálását. A fájlokon iterálhat, és a konverziós folyamatot programozottan alkalmazhatja.

**Lehet jelszóval védeni a konvertált PDF-et?**

Igen. Használja a [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) osztályt a jelszó beállításához és a hozzáférési jogosultságok meghatározásához a konverzió során.

**Hogyan lehet a rejtett diákot beilleszteni a PDF-be?**

Hívja meg a [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) metódust `True` értékkel a [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) osztályban, hogy a rejtett diák a kimeneti PDF-be kerüljenek.

**Tudja az Aspose.Slides megőrizni a magas képi minőséget a PDF-ben?**

Igen, a képek minőségét szabályozhatja a [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality), illetve a [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) metódusokkal a [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) osztályban, hogy a PDF-ben magas minőségű képek maradjanak.

**Támogatja az Aspose.Slides a PDF/A megfelelőségi szabványokat?**

Igen, az Aspose.Slides lehetővé teszi a PDF-ek exportálását, amelyek megfelelnek a [különböző szabványoknak](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/), beleértve a PDF/A1a, PDF/A1b és PDF/UA szabványokat, a hozzáférhetőség vagy archiválás céljából. Válassza ki a megfelelő szabványt, és ellenőrizze a kimenetet a követelményei szerint.

## **További források**

- [Aspose.Slides for Python via Java dokumentáció](/slides/hu/python-java/)
- [Aspose.Slides for Python via Java API hivatkozás](https://reference.aspose.com/slides/python-java/)
- [Aspose ingyenes online konverterek](https://products.aspose.app/slides/conversion)