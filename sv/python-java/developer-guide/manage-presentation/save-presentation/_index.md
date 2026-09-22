---
title: Spara presentationer i Python via Java
linktitle: Spara presentation
type: docs
weight: 80
url: /sv/python-java/save-presentation/
keywords:
- spara PowerPoint
- spara OpenDocument
- spara presentation
- spara bild
- spara PPT
- spara PPTX
- spara ODP
- presentation till fil
- presentation till ström
- fördefinierad vytyp
- Strict Office Open XML-format
- Zip64-läge
- uppdatera miniatyr
- sparande framsteg
- Python
- Java
- Aspose.Slides
description: "Spara PowerPoint- och OpenDocument-presentationer till filer eller strömmar i Python via Java med Aspose.Slides, och konfigurera PPTX-utdata samt rapportering av framsteg."
---
## **Översikt**

Efter att du har skapat en presentation eller [öppnat en befintlig](/slides/sv/python-java/open-presentation/), använder du metoden [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) för att skriva resultatet. Aspose.Slides för Python via Java kan spara en presentation till en fil eller ström i PowerPoint, OpenDocument, PDF och andra format. Följande avsnitt behandlar standard‑sparoperationer och de alternativ som finns för PPTX‑utdata.

## **Spara presentationer till filer**

För att spara en presentation till en fil, skicka utdata‑sökvägen och ett [SaveFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/)‑värde till metoden [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save). Formatvärdet bestämmer vilken filtyp Aspose.Slides skapar.

Följande exempel skapar en presentation och sparar den som en PPTX‑fil:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Lägg till eller ändra presentationsinnehåll här.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Spara presentationer i deras ursprungliga format**

För exempel på fil‑ och strömdetektering, beteendet för nysskapade presentationer och skillnaden mellan käll‑ och utdataformat, se [Determine the Original Presentation Format](/slides/sv/python-java/detect-presentation-source-format/).

I en batch‑bearbetningsapplikation kan indatformatet vara okänt i förväg. Efter att ha laddat en fil, läs dess ursprungliga format från metoden [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#getSourceFormat). Skicka det resulterande [SourceFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sourceformat/)‑värdet till [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideutil/#toSaveFormat) för att få motsvarande [SaveFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/)‑värde, och använd sedan [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save) för att skriva den modifierade presentationen.

Följande kompletta exempel behandlar varje fil i en indatakatalog, uppdaterar dess titel och sparar den till en utdata‑katalog i det format den laddades i:

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/slideutil/#toSaveFormat) mappar PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP och PowerPoint XML till deras motsvarande presentations‑sparformat. Det mappar bara presentations‑källformat; det är inte avsett att välja exportformat som PDF, HTML, TIFF eller bilder. Att skicka ett ej‑stött eller ogiltigt [SourceFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/sourceformat/)‑värde resulterar i ett [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Legacy‑PPT, PPS och POT‑filer använder samma binära behållare. När en sådan presentation laddas från en ström utan filändelse kan en PPS‑ eller POT‑fil därför identifieras som PPT. Om bevarande av dessa äldre undertyper krävs, behåll det ursprungliga filnamnet eller formatmetadata separat och använd det när du väljer utdatafilnamn och format.

## **Spara presentationer till strömmar**

För att skriva en presentation utan att förlita dig på en slutlig filsökväg, skicka en skrivbar ström och ett [SaveFormat](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveformat/)‑värde till metoden [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save). Detta tillvägagångssätt är användbart när utdata måste returneras från en webbtjänst, lagras i en databas eller bearbetas i minnet.

Följande exempel sparar en ny presentation till en filström:

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

## **Spara presentationer med en fördefinierad vytyp**

Du kan ange den vy som PowerPoint initialt öppnar en sparad presentation i. Använd metoden [ViewProperties.setLastView](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewproperties/#setLastView) med ett [ViewType](https://reference.aspose.com/slides/sv/python-java/aspose.slides/viewtype/)‑värde innan du sparar.

Följande exempel konfigurerar Slide Master‑vyn som initial vy:

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

## **Spara presentationer i Strict Office Open XML‑format**

För att skapa en PPTX‑fil som följer Strict‑profilen för Office Open XML, skapa en [PptxOptions](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pptxoptions/)-instans och använd dess [setConformance](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pptxoptions/#setConformance)-metod med [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/sv/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). Skicka sedan alternativen till metoden [Presentation.save](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/#save).

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

## **Spara presentationer i Office Open XML‑format i Zip64‑läge**

Ett standard‑ZIP‑arkiv begränsar den komprimerade och okomprimerade storleken för varje post, den totala arkivstorleken och antalet poster. Eftersom en PPTX‑fil är ett ZIP‑arkiv kan en mycket stor presentation överstiga dessa gränser. Zip64‑tillägg höjer de tillämpliga storleks‑ och post‑gränserna.

Använd metoden [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pptxoptions/#setZip64Mode) för att styra om Aspose.Slides skriver Zip64‑tillägg:

- [IfNecessary](https://reference.aspose.com/slides/sv/python-java/aspose.slides/zip64mode/#IfNecessary) använder Zip64 endast när presentationen överskrider standard‑ZIP‑gränser. Detta är standardläget.
- [Never](https://reference.aspose.com/slides/sv/python-java/aspose.slides/zip64mode/#Never) inaktiverar Zip64‑tillägg.
- [Always](https://reference.aspose.com/slides/sv/python-java/aspose.slides/zip64mode/#Always) skriver alltid Zip64‑tillägg.

Följande exempel aktiverar alltid Zip64‑tillägg för utdata‑presentationen:

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
Om [Zip64Mode.Never](https://reference.aspose.com/slides/sv/python-java/aspose.slides/zip64mode/#Never) används och presentationen inte får plats inom standard‑ZIP‑gränser, kastar spar‑operationen ett [PptxException](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Spara presentationer i Office Open XML‑format med komprimeringsnivåer**

För PPTX‑utdata kan du balansera sparhastighet mot filstorlek genom att använda metoden [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pptxoptions/#setCompressionLevel). Klassen [CompressionLevel](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compressionlevel/) tillhandahåller följande värden:

- [None](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compressionlevel/#None) lagrar data utan komprimering.
- [Level1](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compressionlevel/#Level1) ger snabbast komprimering och största komprimerade utdata.
- [Level2](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compressionlevel/#Level2) till [Level5](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compressionlevel/#Level5) favoriserar gradvis mindre utdata framför sparhastighet.
- [Level6](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compressionlevel/#Level6) balanserar sparhastighet och filstorlek. Detta är standardnivån.
- [Level7](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compressionlevel/#Level7) och [Level8](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compressionlevel/#Level8) favoriserar ännu mer mindre utdata framför sparhastighet.
- [Level9](https://reference.aspose.com/slides/sv/python-java/aspose.slides/compressionlevel/#Level9) ger starkast komprimering och kräver längst bearbetningstid.

Följande exempel sparar en presentation utan komprimering:

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

Följande exempel använder den maximala komprimeringsnivån:

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

## **Spara presentationer utan att uppdatera miniatyren**

När en presentation sparas som PPTX styr metoden [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/sv/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) dess dokuments miniatyr:

- `True` regenererar miniatyren under spar‑operationen. Detta är standardvärdet.
- `False` bevarar befintlig miniatyr. Om presentationen saknar miniatyr genererar Aspose.Slides ingen.

Följande exempel sparar en presentation utan att uppdatera miniatyren:

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
Att inaktivera miniatyruppdatering kan minska den tid som krävs för att spara en PPTX‑fil.
{{% /alert %}}

## **Rapportera spar‑framsteg som procentandel**

För att övervaka en spar‑operation, registrera en Python‑progress‑handler via `jpype.JProxy` och skicka den till metoden [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/sv/python-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides anropar sedan handlerns `reporting`‑metod med framstegsvärden under exporten.

Följande exempel rapporterar framstegen för en PDF‑export till konsolen:

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
Aspose erbjuder en gratis [PowerPoint Splitter](https://products.aspose.app/slides/sv/splitter) byggd med Aspose.Slides‑API:n. Den sparar utvalda bilder från en presentation som separata PPT‑ eller PPTX‑filer.
{{% /alert %}}

## **FAQ**

**Stöder Aspose.Slides inkrementell eller ”fast save”?**

Nej. Varje spar‑operation skriver en komplett output‑fil istället för att bara uppdatera de ändrade delarna.

**Kan flera trådar spara samma Presentation‑instans?**

Nej. En [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/)‑instans [är inte trådsäker](/slides/sv/python-java/multithreading/). Åtkomst och sparning av varje instans får endast ske från en tråd åt gången.

**Vad händer med hyperlänkar och externt länkade filer när jag sparar en presentation?**

[Hyperlinks](/slides/sv/python-java/manage-hyperlinks/) förblir i presentationen. Aspose.Slides kopierar inte externt länkade filer, så den sparade presentationen måste fortfarande kunna nå deras platser.

**Kan jag spara dokumentmetadata såsom författare, titel, företag och skapandedatum?**

Ja. Ställ in lämpliga [document properties](/slides/sv/python-java/presentation-properties/) innan du sparar, så skriver Aspose.Slides dem till output‑filen.