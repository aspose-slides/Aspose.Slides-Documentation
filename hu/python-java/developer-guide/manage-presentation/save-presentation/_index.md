---
title: Bemutatók mentése Pythonból Java-val
linktitle: Bemutató mentése
type: docs
weight: 80
url: /hu/python-java/save-presentation/
keywords:
- PowerPoint mentése
- OpenDocument mentése
- bemutató mentése
- dia mentése
- PPT mentése
- PPTX mentése
- ODP mentése
- bemutató fájlba
- bemutató folyamba
- előre meghatározott nézet típusa
- szigorú Office Open XML formátum
- Zip64 mód
- bélyegkép frissítése
- mentési előrehaladás
- Python
- Java
- Aspose.Slides
description: "PowerPoint és OpenDocument bemutatókat menthet fájlokba vagy folyamatokba Pythonon keresztül Java-val az Aspose.Slides segítségével, valamint konfigurálhatja a PPTX kimenetet és a folyamatjelentést."
---
## **Áttekintés**

Miután létrehoztál egy bemutatót vagy [megnyit egy meglévőt](/slides/hu/python-java/open-presentation/), használd a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust az eredmény írásához. Az Aspose.Slides for Python via Java képes egy bemutatót fájlba vagy folyamba menteni PowerPoint, OpenDocument, PDF és más formátumokban. Az alábbi szakaszok bemutatják a szabványos mentési műveleteket és a PPTX kimenethez elérhető beállításokat.

## **Bemutatók mentése fájlba**

Egy bemutató fájlba mentéséhez add meg a kimeneti útvonalat és egy [SaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/) értéket a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódusnak. A formátumérték határozza meg, milyen típusú fájlt hoz létre az Aspose.Slides.

Az alábbi példa egy bemutatót hoz létre és PPTX fájlként menti el:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Adjon hozzá vagy módosítson bemutató tartalmat itt.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Bemutatók mentése az eredeti formátumban**

Kötegelt feldolgozást végző alkalmazásban a bemeneti formátum előre nem ismerhető. Egy fájl betöltése után olvasd ki az eredeti formátumát a [Presentation.getSourceFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#getSourceFormat) metódussal. Add át a kapott [SourceFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sourceformat/) értéket a [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideutil/#toSaveFormat) metódusnak, hogy megkapd a megfelelő [SaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/) értéket, majd használd a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódust a módosított bemutató írásához.

Az alábbi teljes példa minden fájlt feldolgoz egy bemeneti könyvtárban, frissíti a címét, és a betöltéskor használt formátumban menti el egy kimeneti könyvtárba:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/slideutil/#toSaveFormat) a PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP és PowerPoint XML formátumokat térképezi a megfelelő bemutató mentési formátumokra. Csak prezentáció forrásformátumokra térképez; nem exportálási formátumok, például PDF, HTML, TIFF vagy képek kiválasztására szolgál. Nem támogatott vagy érvénytelen [SourceFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/sourceformat/) érték átadása [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) kivételt eredményez.

A régi PPT, PPS és POT fájlok ugyanazt a bináris konténert használják. Ha egy ilyen bemutatót kiterjesztés nélküli folyamatról töltesz be, egy PPS vagy POT fájl PPT‑ként azonosítható. Ha meg kell őrizni ezeket a régi altípusokat, tartsd meg az eredeti fájlnevet vagy a formátum metaadatait külön, és használd őket a kimeneti fájlnév és formátum kiválasztásakor.

## **Bemutatók mentése folyamba**

A prezentáció írásához egy írható folyamattal és egy [SaveFormat](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveformat/) értékkel a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódusnak, elkerülhető a végső fájlútvonal használata. Ez akkor hasznos, ha a kimenetet egy webszolgáltatásból kell visszaadni, adatbázisban tárolni vagy memóriában feldolgozni.

Az alábbi példa egy új bemutatót fájlfolyamba ment:

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

## **Bemutatók mentése előre meghatározott nézet típussal**

Megadhatod, hogy a PowerPoint milyen nézetben nyissa meg a mentett bemutatót. Használd a [ViewProperties.setLastView](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewproperties/#setLastView) metódust egy [ViewType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/viewtype/) értékkel a mentés előtt.

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

## **Bemutatók mentése a szigorú Office Open XML formátumban**

A Strict profilú Office Open XML‑nek megfelelő PPTX fájl létrehozásához hozz létre egy [PptxOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxoptions/) példányt, és használd a [setConformance](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxoptions/#setConformance) metódust a [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/hu/python-java/aspose.slides/conformance/#Iso29500_2008_Strict) értékkel. Ezután add át a beállításokat a [Presentation.save](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/#save) metódusnak.

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

## **Bemutatók mentése Office Open XML formátumban Zip64 módban**

A szabványos ZIP archívum korlátozza az egyes bejegyzések tömörített és tömörítetlen méretét, a teljes archívum méretét és a bejegyzések számát. Mivel egy PPTX fájl ZIP archívum, egy nagyon nagy bemutató túllépheti ezeket a korlátokat. A ZIP64 kiterjesztések emelik a méret- és bejegyzésszám‑korlátokat.

Használd a [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxoptions/#setZip64Mode) metódust a ZIP64‑kiterjesztések írásának szabályozásához:

- [IfNecessary](https://reference.aspose.com/slides/hu/python-java/aspose.slides/zip64mode/#IfNecessary) csak akkor használja a ZIP64‑et, ha a bemutató meghaladja a szabványos ZIP korlátokat. Ez az alapértelmezett mód.
- [Never](https://reference.aspose.com/slides/hu/python-java/aspose.slides/zip64mode/#Never) letiltja a ZIP64 kiterjesztéseket.
- [Always](https://reference.aspose.com/slides/hu/python-java/aspose.slides/zip64mode/#Always) mindig írja a ZIP64 kiterjesztéseket.

Az alábbi példa mindig engedélyezi a ZIP64 kiterjesztéseket a kimeneti bemutatóhoz:

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
Ha a [Zip64Mode.Never] kerül használatra, és a bemutató nem fér bele a szabványos ZIP korlátokba, a mentési művelet [PptxException](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxexception/) kivételt dob.
{{% /alert %}}

## **Bemutatók mentése Office Open XML formátumban tömörítési szintekkel**

PPTX kimenetnél a mentés sebessége és a fájlméret egyensúlyozható a [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxoptions/#setCompressionLevel) metódussal. A [CompressionLevel](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/) osztály a következő értékeket biztosítja:

- [None](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#None) adatot tömörítés nélkül tárol.
- [Level1](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level1) a leggyorsabb tömörítést és a legnagyobb tömörített kimenetet biztosítja.
- [Level2](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level2)‑től [Level5](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level5) fokozatosan a kisebb kimenetet részesítik előnyben a mentési sebességgel szemben.
- [Level6](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level6) egyensúlyoz a mentési sebesség és a fájlméret között. Ez az alapértelmezett szint.
- [Level7](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level7) és [Level8](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level8) tovább kedveznek a kisebb kimenetnek a sebességgel szemben.
- [Level9](https://reference.aspose.com/slides/hu/python-java/aspose.slides/compressionlevel/#Level9) a legerősebb tömörítést nyújtja, de a legtöbb feldolgozási időt igényli.

Az alábbi példa egy bemutatót tömörítés nélkül ment:

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

## **Bemutatók mentése a bélyegkép frissítése nélkül**

Amikor egy bemutatót PPTX formátumban mentünk, a [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/hu/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) metódus szabályozza a dokumentum bélyegképét:

- `True` újra generálja a bélyegképet a mentés során. Ez az alapértelmezett érték.
- `False` megőrzi a meglévő bélyegképet. Ha a bemutatónak nincs bélyegképe, az Aspose.Slides nem generál újat.

Az alábbi példa egy bemutatót a bélyegkép frissítése nélkül ment:

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
A bélyegkép frissítésének letiltása csökkentheti egy PPTX fájl mentéséhez szükséges időt.
{{% /alert %}}

## **Mentési előrehaladás frissítései százalékban**

A mentési művelet nyomon követéséhez regisztrálj egy Python előrehaladás‑kezelőt a `jpype.JProxy` segítségével, és add át a [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/hu/python-java/aspose.slides/saveoptions/#setProgressCallback) metódusnak. Az Aspose.Slides ezután a kezelő `reporting` metódusát hívja meg a mentés közbeni előrehaladási értékekkel.

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

{{% alert color="info" title="Megjegyzés" %}}
Az Aspose ingyenes [PowerPoint Splitter](https://products.aspose.app/slides/hu/splitter) szolgáltatást nyújt, amely az Aspose.Slides API‑val készült. Kijelölt diákat külön PPT vagy PPTX fájlokként ment.
{{% /alert %}}

## **GYIK**

**Támogatja az Aspose.Slides az inkrementális vagy „gyors mentést”?**

Nem. Minden mentési művelet egy teljes kimeneti fájlt ír, nem csak a módosított részeket.

**Több szál is mentheti ugyanazt a Presentation példányt?**

Nem. A [Presentation] példány nem szálbiztos. Minden példányhoz egyszerre csak egy szál férhet hozzá és mentheti.

**Mi történik a hiperhivatkozásokkal és a külsőleg kapcsolt fájlokkal, amikor mentek egy bemutatót?**

A [Hyperlinks](/slides/hu/python-java/manage-hyperlinks/) megmaradnak a bemutatóban. Az Aspose.Slides nem másolja a külsőleg kapcsolt fájlokat, ezért a mentett bemutatónak továbbra is el kell érnie azok helyét.

**Menthetők dokumentum metaadatai, például szerző, cím, cég és a létrehozás dátuma?**

Igen. Állítsd be a megfelelő [document properties](/slides/hu/python-java/presentation-properties/) értékeket a mentés előtt, és az Aspose.Slides beírja őket a kimeneti fájlba.