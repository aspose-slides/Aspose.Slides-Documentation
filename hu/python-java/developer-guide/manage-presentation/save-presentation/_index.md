---
title: Prezentációk mentése Pythonon keresztül Java-val
linktitle: Prezentáció mentése
type: docs
weight: 80
url: /hu/python-java/save-presentation/
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
- előre definiált nézettípus
- Szigorú Office Open XML formátum
- Zip64 mód
- miniaturák frissítése
- mentési előrehaladás
- Python
- Java
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk mentése fájlokba vagy adatfolyamokba Pythonon keresztül Java-val az Aspose.Slides segítségével, valamint a PPTX kimenet és a mentési előrehaladás beállítása."
---
## **Áttekintés**

Miután létrehoz egy prezentációt vagy [nyisson meg egy meglévőt](/slides/hu/python-java/open-presentation/), használja a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust az eredmény írásához. Az Aspose.Slides for Python via Java képes egy prezentációt fájlba vagy adatfolyamba menteni PowerPoint, OpenDocument, PDF és egyéb formátumokban. A következő szakaszok a standard mentési műveleteket és a PPTX kimenethez elérhető beállításokat mutatják be.

## **Prezentációk mentése fájlokba**

A prezentáció fájlba mentéséhez adja meg a kimeneti útvonalat és egy [SaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/) értéket a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódusnak. A formátumérték határozza meg az Aspose.Slides által létrehozott fájl típusát.

Az alábbi példa egy prezentációt hoz létre, és PPTX fájlként menti el:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Ide adjon hozzá vagy módosítsa a prezentáció tartalmát.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Prezentációk mentése az eredeti formátumban**

A fájl- és adatfolyam‑felismerési példákért, az újonnan létrehozott prezentációk viselkedéséért, valamint a forrás‑ és kimeneti formátumok megkülönböztetéséért lásd a [Determine the Original Presentation Format](/slides/hu/python-java/detect-presentation-source-format/) oldalt.

Kötegelt feldolgozási alkalmazásban a bemeneti formátum nem ismerhető előre. Fájl betöltése után olvassa ki az eredeti formátumot a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSourceFormat) metódussal. Adja át a kapott [SourceFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sourceformat/) értéket a [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideutil/#toSaveFormat) metódusnak a megfelelő [SaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/) érték lekéréséhez, majd használja a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust a módosított prezentáció írásához.

Az alábbi teljes példa minden fájlt feldolgoz egy bemeneti könyvtárban, frissíti a címét, és a betöltött formátumból a kimeneti könyvtárba menti:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideutil/#toSaveFormat) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP és PowerPoint XML formátumokat térképezi a megfelelő prezentáció‑mentés formátumokra. Csak a prezentáció forrásformátumait térképezi; nem arra szolgál, hogy exportformátumokat, például PDF, HTML, TIFF vagy képek válasszon. Nem támogatott vagy érvénytelen [SourceFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sourceformat/) érték átadása [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) kivételt eredményez.

A régi PPT, PPS és POT fájlok ugyanazt a bináris konténert használják. Ha egy ilyen prezentációt kiterjesztés nélküli adatfolyamból töltik be, egy PPS vagy POT fájlt ezért PPT‑nek azonosíthatnak. Ha meg kell őrizni ezeket a régi al-típusokat, tartsa meg az eredeti fájlnevet vagy formátum‑metaadatot külön, és használja őket a kimeneti fájlnév és formátum meghatározásához.

## **Prezentációk mentése adatfolyamokba**

Prezentáció írásához végső fájlútvonal nélkül adjon meg egy írható adatfolyamot és egy [SaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/) értéket a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódusnak. Ez a megközelítés akkor hasznos, ha a kimenetet egy webszolgáltatásból kell visszaadni, adatbázisba tárolni vagy memória‑szinten feldolgozni.

Az alábbi példa egy új prezentációt fájl‑adatfolyamba ment:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **Prezentációk mentése előre meghatározott nézettípussal**

Megadhatja azt a nézetet, amelyben a PowerPoint először megnyitja a mentett prezentációt. Használja a [ViewProperties.setLastView](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#setLastView) metódust egy [ViewType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewtype/) értékkel a mentés előtt.

Az alábbi példa a Dia‑mester nézetet állítja be kezdeti nézetként:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Prezentációk mentése szigorú Office Open XML formátumban**

Ahhoz, hogy egy PPTX fájl a Office Open XML szigorú profiljának megfeleljen, hozzon létre egy [PptxOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxoptions/) példányt, és használja a [setConformance](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxoptions/#setConformance) metódust a [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hu/python-java/aspose.slides/conformance/#Iso29500_2008_Strict) értékkel. Ezután adja át az opciókat a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódusnak.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Prezentációk mentése Office Open XML formátumban Zip64 módban**

Egy szabványos ZIP archívum korlátozza az egyes bejegyzések tömörített és tömörítetlen méretét, a teljes archívum méretét és a bejegyzések számát. Mivel egy PPTX fájl ZIP archívum, egy nagyon nagy prezentáció túllépheti ezeket a korlátokat. A ZIP64 kiterjesztések emelik a vonatkozó méret‑ és bejegyzésszám‑korlátokat.

Használja a [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxoptions/#setZip64Mode) metódust annak szabályozására, hogy az Aspose.Slides ZIP64 kiterjesztéseket írjon-e:

- [IfNecessary](https://reference.aspose.com/slides/hu/python-java/aspose.slides/zip64mode/#IfNecessary) csak akkor használ ZIP64‑et, ha a prezentáció meghaladja a szabványos ZIP‑korlátokat. Ez az alapértelmezett mód.
- [Never](https://reference.aspose.com/slides/hu/python-java/aspose.slides/zip64mode/#Never) letiltja a ZIP64 kiterjesztéseket.
- [Always](https://reference.aspose.com/slides/hu/python-java/aspose.slides/zip64mode/#Always) mindig írja a ZIP64 kiterjesztéseket.

Az alábbi példa mindig engedélyezi a ZIP64 kiterjesztéseket a kimeneti prezentációhoz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Ha a [Zip64Mode.Never](https://reference.aspose.com/slides/hu/python-java/aspose.slides/zip64mode/#Never) kerül használatra, és a prezentáció nem fér bele a szabványos ZIP‑korlátokba, a mentési művelet [PptxException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxexception/) kivételt dob.
{{% /alert %}}

## **Prezentációk mentése Office Open XML formátumban tömörítési szintekkel**

PPTX kimenetnél a mentési sebesség és a fájlméret egyensúlyozásához használhatja a [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxoptions/#setCompressionLevel) metódust. A [CompressionLevel](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/) osztály a következő értékeket kínálja:

- [None](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#None) adatot tömörítés nélkül tárol.
- [Level1](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level1) a leggyorsabb tömörítést és a legnagyobb tömörített kimenetet biztosítja.
- [Level2](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level2)‑től [Level5](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level5) fokozatosan a kisebb kimenet felé hajlik a mentési sebesség rovására.
- [Level6](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level6) egyensúlyban tartja a mentési sebességet és a fájlméretet. Ez az alapértelmezett szint.
- [Level7](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level7) és [Level8](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level8) tovább részesítik a kisebb kimenetet a sebesség rovására.
- [Level9](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level9) a legerősebb tömörítést nyújtja, és a legtöbb feldolgozási időt igényli.

Az alábbi példa tömörítés nélkül menti a prezentációt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

Az alábbi példa a maximális tömörítési szintet használja:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Prezentációk mentése a miniatűr frissítése nélkül**

Amikor egy prezentációt PPTX‑ként ment, a [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) metódus szabályozza a dokumentum miniatűrjét:

- `True` a mentés során újra generálja a miniatűröt. Ez az alapértelmezett érték.
- `False` megőrzi a meglévő miniatűrt. Ha a prezentációnak nincs miniatűre, az Aspose.Slides nem generál újat.

Az alábbi példa a miniatűr frissítése nélkül menti a prezentációt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
A miniatűr frissítésének letiltása csökkentheti a PPTX fájl mentéséhez szükséges időt.
{{% /alert %}}

## **Mentés előrehaladásának jelentése százalékban**

A mentési művelet nyomon követéséhez regisztráljon egy Python előrehaladás‑kezelőt a `jpype.JProxy`‑val, és adja át a [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveoptions/#setProgressCallback) metódusnak. Az Aspose.Slides ekkor a kezelő `reporting` metódusát hívja meg előrehaladási értékekkel az export során.

Az alábbi példa a PDF export előrehaladását jelzi a konzolra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Az Aspose egy ingyenes [PowerPoint Splitter](https://products.aspose.app/slides/hu/splitter) szolgáltatást kínál, amely az Aspose.Slides API‑val készült. Kiválasztott diákat ment külön PPT vagy PPTX fájlokba.
{{% /alert %}}

## **Gyakran Ismételt Kérdések**

**Támogatja az Aspose.Slides az inkrementális vagy „gyors mentést”?**

Nem. Minden mentési művelet egy teljes kimeneti fájlt ír, nem csak a megváltozott részeket frissíti.

**Több szál mentheti ugyanazt a Presentation példányt?**

Nem. Egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példány [nem szálbiztos](/slides/hu/python-java/multithreading/). Minden példányt egyszerre csak egy szálól szabad hozzáférni és menteni.

**Mi történik a hiperhivatkozásokkal és külsőleg hivatkozott fájlokkal, amikor mentek egy prezentációt?**

[Hyperlinks](/slides/hu/python-java/manage-hyperlinks/) megmaradnak a prezentációban. Az Aspose.Slides nem másolja a külsőleg hivatkozott fájlokat, ezért a mentett prezentációnak továbbra is hozzá kell férnie azok helyéhez.

**Menthetek dokumentum metaadatokat, például szerzőt, címet, céget és létrehozás dátumát?**

Igen. Állítsa be a megfelelő [document properties](/slides/hu/python-java/presentation-properties/) értékeket a mentés előtt, és az Aspose.Slides beírja őket a kimeneti fájlba.