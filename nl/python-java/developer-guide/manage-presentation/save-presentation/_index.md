---
title: Presentaties opslaan in Python via Java
linktitle: Presentatie opslaan
type: docs
weight: 80
url: /nl/python-java/save-presentation/
keywords:
- PowerPoint opslaan
- OpenDocument opslaan
- presentatie opslaan
- dia opslaan
- PPT opslaan
- PPTX opslaan
- ODP opslaan
- presentatie naar bestand
- presentatie naar stream
- voorgedefinieerd weergavetype
- Strict Office Open XML-formaat
- Zip64-modus
- thumbnail vernieuwen
- voortgang opslaan
- Python
- Java
- Aspose.Slides
description: "PowerPoint- en OpenDocument-presentaties opslaan naar bestanden of streams in Python via Java met Aspose.Slides, en de PPTX-output en voortgangsrapportage configureren."
---
## **Overzicht**

Nadat u een presentatie hebt gemaakt of [een bestaande openen](/slides/nl/python-java/open-presentation/), gebruikt u de [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) methode om het resultaat weg te schrijven. Aspose.Slides voor Python via Java kan een presentatie opslaan in een bestand of stream in PowerPoint, OpenDocument, PDF en andere formaten. De volgende secties behandelen de standaard opslaoperaties en de opties die beschikbaar zijn voor PPTX‑uitvoer.

## **Presentaties opslaan naar bestanden**

Om een presentatie op te slaan naar een bestand, geeft u het uitvoerpad en een [SaveFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/) waarde door aan de [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) methode. De formaatwaarde bepaalt het type bestand dat Aspose.Slides maakt.

Het volgende voorbeeld maakt een presentatie en slaat deze op als een PPTX‑bestand:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Voeg hier inhoud toe aan de presentatie of wijzig deze.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Presentaties opslaan in hun oorspronkelijke formaat**

In een batch‑verwerkingsapplicatie is het invoerformaat mogelijk niet van tevoren bekend. Na het laden van een bestand, lees u het oorspronkelijke formaat via de [Presentation.getSourceFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#getSourceFormat) methode. Geef de verkregen [SourceFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sourceformat/) waarde door aan [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideutil/#toSaveFormat) om de bijbehorende [SaveFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/) waarde te verkrijgen, en gebruik vervolgens [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) om de gewijzigde presentatie weg te schrijven.

Het volgende volledige voorbeeld verwerkt elk bestand in een invoermap, werkt de titel bij en slaat het op in een uitvoermap in het formaat waarin het is geladen:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/slideutil/#toSaveFormat) koppelt PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP en PowerPoint XML aan hun overeenkomstige presentatie‑opslaformaten. Het mappt alleen bronformaten van presentaties; het is niet bedoeld om exportformaten zoals PDF, HTML, TIFF of afbeeldingen te selecteren. Het doorgeven van een niet‑ondersteunde of ongeldige [SourceFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/sourceformat/) waarde leidt tot een [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Legacy‑PPT, PPS en POT‑bestanden gebruiken dezelfde binaire container. Wanneer zo’n presentatie uit een stream zonder bestandsextensie wordt geladen, kan een PPS‑ of POT‑bestand daarom als PPT worden geïdentificeerd. Als het behouden van deze legacy‑subtypen vereist is, bewaar dan de oorspronkelijke bestandsnaam of format‑metadata apart en gebruik deze bij het kiezen van de uitvoer‑bestandsnaam en -formaat.

## **Presentaties opslaan naar streams**

Om een presentatie weg te schrijven zonder een definitief bestandspad, geeft u een schrijfbare stream en een [SaveFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/) waarde door aan de [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) methode. Deze aanpak is nuttig wanneer de uitvoer moet worden geretourneerd vanuit een webservice, opgeslagen in een database of in het geheugen moet worden verwerkt.

Het volgende voorbeeld slaat een nieuwe presentatie op naar een bestands‑stream:

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

## **Presentaties opslaan met een vooraf gedefinieerd weergavetype**

U kunt de weergave specificeren waarin PowerPoint een opgeslagen presentatie initieel opent. Gebruik de [ViewProperties.setLastView](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewproperties/#setLastView) methode met een [ViewType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/viewtype/) waarde vóór het opslaan.

Het volgende voorbeeld stelt de Master‑slide‑weergave in als de initiële weergave:

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

## **Presentaties opslaan in het Strict Office Open XML-formaat**

Om een PPTX‑bestand te maken dat voldoet aan het Strict‑profiel van Office Open XML, maakt u een [PptxOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pptxoptions/) instantie en gebruikt u de [setConformance](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pptxoptions/#setConformance) methode met [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/nl/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). Geef vervolgens de opties door aan de [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save) methode.

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

## **Presentaties opslaan in Office Open XML-formaat in Zip64-modus**

Een standaard ZIP‑archief beperkt de gecomprimeerde en ongecomprimeerde grootte van elk element, de totale archiefgrootte en het aantal elementen. Omdat een PPTX‑bestand een ZIP‑archief is, kan een zeer grote presentatie deze limieten overschrijden. ZIP64‑extensies verhogen de toepasselijke grootte‑ en element‑limieten.

Gebruik de [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pptxoptions/#setZip64Mode) methode om te bepalen of Aspose.Slides ZIP64‑extensies schrijft:

- [IfNecessary](https://reference.aspose.com/slides/nl/python-java/aspose.slides/zip64mode/#IfNecessary) gebruikt ZIP64 alleen wanneer de presentatie de standaard ZIP‑limieten overschrijdt. Dit is de standaardmodus.
- [Never](https://reference.aspose.com/slides/nl/python-java/aspose.slides/zip64mode/#Never) schakelt ZIP64‑extensies uit.
- [Always](https://reference.aspose.com/slides/nl/python-java/aspose.slides/zip64mode/#Always) schrijft altijd ZIP64‑extensies.

Het volgende voorbeeld schakelt ZIP64‑extensies altijd in voor de uitvoerpresentatie:

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

{{% alert color="warning" title="Waarschuwing" %}}
Als [Zip64Mode.Never](https://reference.aspose.com/slides/nl/python-java/aspose.slides/zip64mode/#Never) wordt gebruikt en de presentatie past niet binnen de standaard ZIP‑limieten, werpt de opslaactie een [PptxException](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Presentaties opslaan in Office Open XML-formaat met compressieniveaus**

Voor PPTX‑uitvoer kunt u de opslagsnelheid afwegen tegen de bestandsgrootte door de [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pptxoptions/#setCompressionLevel) methode te gebruiken. De [CompressionLevel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compressionlevel/) klasse biedt deze waarden:

- [None](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compressionlevel/#None) slaat gegevens zonder compressie op.
- [Level1](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compressionlevel/#Level1) biedt de snelste compressie en de grootste gecomprimeerde output.
- [Level2](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compressionlevel/#Level2) tot en met [Level5](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compressionlevel/#Level5) geven steeds meer de voorkeur aan een kleinere output ten koste van de opslagsnelheid.
- [Level6](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compressionlevel/#Level6) balanceert opslagsnelheid en bestandsgrootte. Dit is het standaardniveau.
- [Level7](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compressionlevel/#Level7) en [Level8](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compressionlevel/#Level8) geven nog meer de voorkeur aan een kleinere output ten koste van de opslagsnelheid.
- [Level9](https://reference.aspose.com/slides/nl/python-java/aspose.slides/compressionlevel/#Level9) biedt de sterkste compressie en vergt de meeste verwerkingstijd.

Het volgende voorbeeld slaat een presentatie op zonder compressie:

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

Het volgende voorbeeld gebruikt het maximale compressieniveau:

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

## **Presentaties opslaan zonder de thumbnail te verversen**

Wanneer een presentatie wordt opgeslagen als PPTX, bepaalt de [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/nl/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) methode de document‑thumbnail:

- `True` genereert de thumbnail opnieuw tijdens het opslaan. Dit is de standaardwaarde.
- `False` behoudt de bestaande thumbnail. Als de presentatie geen thumbnail heeft, genereert Aspose.Slides er geen.

Het volgende voorbeeld slaat een presentatie op zonder de thumbnail te verversen:

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

{{% alert color="info" title="Opmerking" %}}
Het uitschakelen van thumbnail‑verversing kan de tijd die nodig is om een PPTX‑bestand op te slaan verminderen.
{{% /alert %}}

## **Voortgangsupdates opslaan in procenten**

Om een opslaactie te monitoren, registreert u een Python‑voortgangs‑handler via `jpype.JProxy` en geeft u deze door aan de [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveoptions/#setProgressCallback) methode. Aspose.Slides roept vervolgens de `reporting`‑methode van de handler aan met voortgangswaarden tijdens de export.

Het volgende voorbeeld meldt de voortgang van een PDF‑export naar de console:

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

{{% alert color="info" title="Opmerking" %}}
Aspose biedt een gratis [PowerPoint Splitter](https://products.aspose.app/slides/nl/splitter) gebouwd met de Aspose.Slides‑API. Het slaat geselecteerde dia’s uit een presentatie op als afzonderlijke PPT‑ of PPTX‑bestanden.
{{% /alert %}}

## **FAQ**

**Ondersteunt Aspose.Slides incrementeel of “fast save”?**

Nee. Elke opslaactie schrijft een compleet uitvoerbestand weg in plaats van alleen de gewijzigde delen bij te werken.

**Kunnen meerdere threads dezelfde Presentation‑instantie opslaan?**

Nee. Een [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) instantie **is not thread-safe**(/slides/nl/python-java/multithreading/). Toegang tot en opslaan van elke instantie mag slechts vanuit één thread tegelijk gebeuren.

**Wat gebeurt er met hyperlinks en extern gelinkte bestanden wanneer ik een presentatie opsla?**

[Hyperlinks](/slides/nl/python-java/manage-hyperlinks/) blijven in de presentatie bestaan. Aspose.Slides kopieert geen extern gelinkte bestanden, dus de opgeslagen presentatie moet nog steeds toegang hebben tot hun locaties.

**Kan ik documentmetadata zoals auteur, titel, bedrijf en aanmaakdatum opslaan?**

Ja. Stel de juiste [document properties](/slides/nl/python-java/presentation-properties/) in vóór het opslaan, en Aspose.Slides schrijft ze naar het uitvoerbestand.