---
title: Ukládání prezentací v Pythonu přes Java
linktitle: Uložit prezentaci
type: docs
weight: 80
url: /cs/python-java/save-presentation/
keywords:
- uložit PowerPoint
- uložit OpenDocument
- uložit prezentaci
- uložit snímek
- uložit PPT
- uložit PPTX
- uložit ODP
- prezentace do souboru
- prezentace do proudu
- předdefinovaný typ zobrazení
- přísný formát Office Open XML
- režim Zip64
- obnovení náhledu
- průběh ukládání
- Python
- Java
- Aspose.Slides
description: "Ukládejte prezentace PowerPoint a OpenDocument do souborů nebo proudů v Pythonu přes Java s Aspose.Slides a nastavujte výstup PPTX a hlášení průběhu."
---
## **Přehled**

Po vytvoření prezentace nebo [otevření existující](/slides/cs/python-java/open-presentation/), použijte metodu [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) k zápisu výsledku. Aspose.Slides pro Python přes Java může uložit prezentaci do souboru nebo proudu ve formátech PowerPoint, OpenDocument, PDF a dalších. Následující sekce pokrývají standardní operace ukládání a možnosti dostupné pro výstup PPTX.

## **Ukládání prezentací do souborů**

Pro uložení prezentace do souboru předáte cestu k výstupu a hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/) metodě [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save). Hodnota formátu určuje typ souboru, který Aspose.Slides vytvoří.

Následující příklad vytvoří prezentaci a uloží ji jako soubor PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Přidejte nebo upravte obsah prezentace zde.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ukládání prezentací v jejich původním formátu**

V aplikaci pro dávkové zpracování nemusí být vstupní formát znám předem. Po načtení souboru si přečtěte jeho původní formát pomocí metody [Presentation.getSourceFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getSourceFormat). Výslednou hodnotu [SourceFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sourceformat/) předajte metodě [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideutil/#toSaveFormat), abyste získali odpovídající hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/), a následně použijte [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) k zápisu upravené prezentace.

Následující kompletní příklad zpracuje každý soubor ve vstupním adresáři, aktualizuje jeho název a uloží jej do výstupního adresáře ve formátu, ze kterého byl načten:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/slideutil/#toSaveFormat) mapuje PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP a PowerPoint XML na jejich odpovídající formáty ukládání prezentací. Mapuje pouze zdrojové formáty prezentací; není určena k výběru exportních formátů jako PDF, HTML, TIFF nebo obrázky. Předání nepodporované nebo neplatné [SourceFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/sourceformat/) vede k vyvolání výjimky [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Starší soubory PPT, PPS a POT používají stejný binární kontejner. Když je taková prezentace načtena z proudu bez přípony souboru, může být soubor PPS nebo POT identifikován jako PPT. Pokud je vyžadováno zachování těchto starých podtypů, uchovejte původní název souboru nebo metadata formátu samostatně a použijte je při výběru výstupního názvu souboru a formátu.

## **Ukládání prezentací do proudů**

Pro zápis prezentace bez použití konečné cesty k souboru předáte zapisovatelný proud a hodnotu [SaveFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveformat/) metodě [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save). Tento přístup je užitečný, když musí být výstup vrácen z webové služby, uložen v databázi nebo zpracován v paměti.

Následující příklad uloží novou prezentaci do souborového proudu:

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

## **Ukládání prezentací s předdefinovaným typem zobrazení**

Můžete určit zobrazení, v němž PowerPoint otevře uloženou prezentaci při prvním spuštění. Použijte metodu [ViewProperties.setLastView](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewproperties/#setLastView) s hodnotou [ViewType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/viewtype/) před uložením.

Následující příklad nastaví zobrazení Slide Master jako počáteční zobrazení:

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

## **Ukládání prezentací v přísném formátu Office Open XML**

Pro vytvoření souboru PPTX, který odpovídá přísnému profilu Office Open XML, vytvořte instanci [PptxOptions](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pptxoptions/) a použijte její metodu [setConformance](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pptxoptions/#setConformance) s hodnotou [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/cs/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). Poté předáte možnosti metodě [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save).

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

## **Ukládání prezentací v formátu Office Open XML v režimu Zip64**

Standardní archiv ZIP omezuje komprimovanou a nekomprimovanou velikost každé položky, celkovou velikost archivu a počet položek. Protože soubor PPTX je archiv ZIP, velmi velká prezentace může tato omezení překročit. Rozšíření ZIP64 zvyšují příslušná omezení velikosti a počtu položek.

Použijte metodu [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pptxoptions/#setZip64Mode) pro řízení, zda Aspose.Slides zapisuje rozšíření ZIP64:

- [IfNecessary](https://reference.aspose.com/slides/cs/python-java/aspose.slides/zip64mode/#IfNecessary) používá ZIP64 pouze když prezentace překročí standardní limity ZIP. Toto je výchozí režim.
- [Never](https://reference.aspose.com/slides/cs/python-java/aspose.slides/zip64mode/#Never) zakazuje rozšíření ZIP64.
- [Always](https://reference.aspose.com/slides/cs/python-java/aspose.slides/zip64mode/#Always) vždy zapisuje rozšíření ZIP64.

Následující příklad vždy povolí rozšíření ZIP64 pro výstupní prezentaci:

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
Pokud je použito [Zip64Mode.Never](https://reference.aspose.com/slides/cs/python-java/aspose.slides/zip64mode/#Never) a prezentace se nevejde do standardních limitů ZIP, operace uložení vyhodí výjimku [PptxException](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Ukládání prezentací v formátu Office Open XML s úrovněmi komprese**

Pro výstup PPTX můžete vyvážit rychlost ukládání oproti velikosti souboru použitím metody [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pptxoptions/#setCompressionLevel). Třída [CompressionLevel](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compressionlevel/) poskytuje následující hodnoty:

- [None](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compressionlevel/#None) ukládá data bez komprese.
- [Level1](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compressionlevel/#Level1) poskytuje nejrychlejší kompresi a největší komprimovaný výstup.
- [Level2](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compressionlevel/#Level2) až [Level5](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compressionlevel/#Level5) postupně upřednostňují menší výstup před rychlostí ukládání.
- [Level6](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compressionlevel/#Level6) vyvažuje rychlost ukládání a velikost souboru. Toto je výchozí úroveň.
- [Level7](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compressionlevel/#Level7) a [Level8](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compressionlevel/#Level8) dále upřednostňují menší výstup před rychlostí ukládání.
- [Level9](https://reference.aspose.com/slides/cs/python-java/aspose.slides/compressionlevel/#Level9) poskytuje nejvyšší kompresi a vyžaduje nejvíce výpočetního času.

Následující příklad uloží prezentaci bez komprese:

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

Následující příklad použije maximální úroveň komprese:

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

## **Ukládání prezentací bez obnovení náhledu**

Při uložení prezentace jako PPTX metoda [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/cs/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) řídí náhled dokumentu:

- `True` regeneruje náhled během operace uložení. Toto je výchozí hodnota.
- `False` zachová existující náhled. Pokud prezentace nemá náhled, Aspose.Slides ho nevygeneruje.

Následující příklad uloží prezentaci bez obnovení náhledu:

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
Zakázání obnovy náhledu může zkrátit dobu potřebnou k uložení souboru PPTX.
{{% /alert %}}

## **Ukládání aktualizací průběhu v procentech**

Pro sledování operace ukládání zaregistrujte Python handler pro průběh pomocí `jpype.JProxy` a předáte jej metodě [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/cs/python-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides poté volá metodu `reporting` handleru s hodnotami průběhu během exportu.

Následující příklad vykazuje průběh exportu PDF do konzole:

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
Aspose poskytuje zdarma [PowerPoint Splitter](https://products.aspose.app/slides/cs/splitter) postavený na Aspose.Slides API. Ukládá vybrané snímky z prezentace jako samostatné soubory PPT nebo PPTX.
{{% /alert %}}

## **Často kladené otázky**

**Podporuje Aspose.Slides inkrementální nebo „rychlé uložení“?**  
Ne. Každá operace uložení zapíše kompletní výstupní soubor, místo aktualizace pouze změněných částí.

**Mohou více vláken ukládat stejnou instanci Presentation?**  
Ne. Instance [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) není thread‑safe. Přistupujte a ukládejte každou instanci pouze z jednoho vlákna najednou.

**Co se stane s hypertextovými odkazy a externě odkazovanými soubory při uložení prezentace?**  
[Hyperlinks](/slides/cs/python-java/manage-hyperlinks/) zůstávají v prezentaci. Aspose.Slides nekopíruje externě odkazované soubory, takže uložená prezentace musí stále mít přístup k jejich umístěním.

**Mohu uložit metadata dokumentu, jako je autor, název, společnost a datum vytvoření?**  
Ano. Nastavte příslušné [document properties](/slides/cs/python-java/presentation-properties/) před uložením a Aspose.Slides je zapíše do výstupního souboru.