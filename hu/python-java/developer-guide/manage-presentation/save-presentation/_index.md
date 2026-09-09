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
- bélyegkép frissítése
- mentés előrehaladása
- Python
- Java
- Aspose.Slides
description: "PowerPoint és OpenDocument prezentációk mentése fájlokba vagy adatfolyamba Pythonon keresztül Java-val az Aspose.Slides használatával, valamint a PPTX kimenet és a folyamatjelentés beállítása."
---
## **Áttekintés**

Miután létrehoz egy prezentációt vagy [nyiss meg egy meglévőt](/slides/hu/python-java/open-presentation/), használja a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust az eredmény írásához. Az Aspose.Slides for Python via Java képes a prezentációt fájlba vagy adatfolyamba menteni PowerPoint, OpenDocument, PDF és egyéb formátumokban. Az alábbi szakaszok a szabványos mentési műveleteket és a PPTX kimenetre elérhető beállításokat tárgyalják.

## **Prezentációk mentése fájlokba**

A prezentáció fájlba mentéséhez adja meg a kimeneti útvonalat és egy [SaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/) értéket a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódusnak. A formátumérték határozza meg, milyen típusú fájlt hoz létre az Aspose.Slides.

Az alábbi példa létrehoz egy prezentációt, és PPTX fájlként menti el:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Itt adja hozzá vagy módosítsa a prezentáció tartalmát.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Prezentációk mentése eredeti formátumban**

Kötegfeldolgozó alkalmazásban a bemeneti formátum előre nem ismert. Fájl betöltése után olvassa ki az eredeti formátumot a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSourceFormat) metódussal. Adja át a kapott [SourceFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sourceformat/) értéket a [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideutil/#toSaveFormat) metódusnak, hogy megkapja a megfelelő [SaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/) értéket, majd használja a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust a módosított prezentáció írásához.

Az alábbi teljes példa minden fájlt feldolgoz egy bemeneti könyvtárban, frissíti a címét, és egy kimeneti könyvtárba menti abban a formátumban, amiben betöltötték:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideutil/#toSaveFormat) PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP és PowerPoint XML formátumokat térképezi a megfelelő prezentáció mentési formátumokra. Csak prezentáció forrásformátumokat térképez; nem célja exportformátumok, például PDF, HTML, TIFF vagy képek kiválasztása. Nem támogatott vagy érvénytelen [SourceFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sourceformat/) érték átadása [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) kivételt eredményez.

A régi PPT, PPS és POT fájlok ugyanazt a bináris konténert használják. Ha egy ilyen prezentációt kiterjesztés nélküli adatfolyamból töltik be, egy PPS vagy POT fájl ezért PPT‑ként azonosítható. Ha meg kell őrizni ezeket a régi altípusokat, tartsa meg az eredeti fájlnevet vagy formátummetaadatokat külön, és használja őket a kimeneti fájlnév és formátum kiválasztásakor.

## **Prezentációk mentése adatfolyamokba**

A prezentáció írásához, anélkül hogy végleges fájlútvonalra támaszkodna, adjon meg egy írható adatfolyamot és egy [SaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/) értéket a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódusnak. Ez a megközelítés hasznos, ha a kimenetet webszolgáltatásból kell visszaadni, adatbázisban tárolni vagy memóriában feldolgozni.

Az alábbi példa egy új prezentációt fájl adatfolyamba ment:

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

## **Prezentációk mentése előre meghatározott nézet típussal**

Megadhatja azt a nézetet, amelyben a PowerPoint kezdetben megnyit egy mentett prezentációt. Használja a [ViewProperties.setLastView](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#setLastView) metódust egy [ViewType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewtype/) értékkel a mentés előtt.

Az alábbi példa a Dia Mester nézetet állítja be kezdeti nézetként:

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

## **Prezentációk mentése a szigorú Office Open XML formátumban**

A Strict profilú Office Open XML‑nek megfelelő PPTX fájl létrehozásához hozza létre egy [PptxOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxoptions/) példányt, és használja a [setConformance](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxoptions/#setConformance) metódust a [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hu/python-java/aspose.slides/conformance/#Iso29500_2008_Strict) értékkel. Ezután adja át az opciókat a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódusnak.

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

Egy szabványos ZIP archívum korlátozza az egyes bejegyzések tömörített és tömörítetlen méretét, a teljes archívum méretét és a bejegyzések számát. Mivel egy PPTX fájl ZIP archívum, egy nagyon nagy prezentáció túllépheti ezeket a határokat. A ZIP64 kiterjesztések megemelik a vonatkozó méret- és bejegyzésszám‑korlátokat.

Használja a [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxoptions/#setZip64Mode) metódust annak szabályozására, hogy az Aspose.Slides ír‑e ZIP64 kiterjesztéseket:

- [IfNecessary](https://reference.aspose.com/slides/hu/python-java/aspose.slides/zip64mode/#IfNecessary) csak akkor használ ZIP64‑et, ha a prezentáció meghaladja a szabványos ZIP határokat. Ez az alapértelmezett mód.
- [Never](https://reference.aspose.com/slides/hu/python-java/aspose.slides/zip64mode/#Never) letiltja a ZIP64 kiterjesztéseket.
- [Always](https://reference.aspose.com/slides/hu/python-java/aspose.slides/zip64mode/#Always) minden esetben ír ZIP64 kiterjesztéseket.

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

{{% alert color="warning" title="Figyelmeztetés" %}}
Ha a [Zip64Mode.Never](https://reference.aspose.com/slides/hu/python-java/aspose.slides/zip64mode/#Never) mód van beállítva, és a prezentáció nem fér bele a szabványos ZIP határokba, a mentési művelet [PptxException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxexception/) kivételt dob.
{{% /alert %}}

## **Prezentációk mentése Office Open XML formátumban tömörítési szintekkel**

PPTX kimenetnél a mentési sebesség és a fájlméret egyensúlyozásához használhatja a [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxoptions/#setCompressionLevel) metódust. A [CompressionLevel](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/) osztály a következő értékeket biztosítja:

- [None](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#None) adatot tömörítés nélkül tárol.
- [Level1](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level1) a leggyorsabb tömörítést és a legnagyobb tömörített kimenetet biztosítja.
- [Level2](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level2)‑től [Level5](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level5) fokozatosan a kisebb kimenetet részesítik előnyben a mentési sebességgel szemben.
- [Level6](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level6) egyensúlyt teremt a mentési sebesség és a fájlméret között. Ez az alapértelmezett szint.
- [Level7](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level7) és [Level8](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level8) továbbra is a kisebb kimenetet részesítik előnyben a sebességgel szemben.
- [Level9](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level9) a legerősebb tömörítést biztosítja, és a legtöbb feldolgozási időt igényli.

Az alábbi példa egy prezentációt tömörítés nélkül ment:

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

## **Prezentációk mentése a bélyegkép frissítése nélkül**

Amikor egy prezentációt PPTX‑ként ment, a [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) metódus szabályozza a dokumentum bélyegképét:

- `True` újra generálja a bélyegképet a mentési művelet során. Ez az alapértelmezett érték.
- `False` megőrzi a meglévő bélyegképet. Ha a prezentációnak nincs bélyegképe, az Aspose.Slides nem hoz létre újat.

Az alábbi példa egy prezentációt a bélyegkép frissítése nélkül ment:

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

{{% alert color="info" title="Megjegyzés" %}}
A bélyegkép frissítésének letiltása csökkentheti a PPTX fájl mentéséhez szükséges időt.
{{% /alert %}}

## **Mentési folyamat jelentése százalékban**

A mentési művelet nyomon követéséhez regisztráljon egy Python progress kezelőt a `jpype.JProxy`‑val, és adja át a [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveoptions/#setProgressCallback) metódusnak. Az Aspose.Slides ezután a handler `reporting` metódusát hívja meg előrehaladási értékekkel az export során.

Az alábbi példa a PDF export előrehaladását konzolra jelenti:

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

{{% alert color="info" title="Megjegyzés" %}}
Az Aspose ingyenes [PowerPoint Splitter](https://products.aspose.app/slides/hu/splitter) eszközt biztosít, amely az Aspose.Slides API‑val készült. Kiválasztott diákot külön PPT vagy PPTX fájlokként ment.
{{% /alert %}}

## **GYIK**

**Támogatja az Aspose.Slides az inkrementális vagy „gyors mentést”?**

Nem. Minden mentési művelet teljes kimeneti fájlt ír, nem csak a megváltozott részeket frissíti.

**Több szál mentheti ugyanazt a Presentation példányt?**

Nem. Egy [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) példány [nem szálbiztonságos](/slides/hu/python-java/multithreading/). Mindig csak egy szál férjen hozzá és mentse a példányt egy időben.

**Mi történik a hiperhivatkozásokkal és a külsőleg linkelt fájlokkal, amikor mentek egy prezentációt?**

[Hyperlinks](/slides/hu/python-java/manage-hyperlinks/) megmaradnak a prezentációban. Az Aspose.Slides nem másolja a külsőleg linkelt fájlokat, így a mentett prezentációnak továbbra is hozzá kell férnie azok helyeihez.

**Menthetők dokumentum metaadatok, mint például a szerző, cím, cég és létrehozás dátuma?**

Igen. Állítsa be a megfelelő [document properties](/slides/hu/python-java/presentation-properties/) értékeket a mentés előtt, és az Aspose.Slides beírja őket a kimeneti fájlba.