---
title: "PowerPoint-presentaties converteren naar Markdown in Python via Java"
linktitle: "PowerPoint naar Markdown"
type: docs
weight: 140
url: /nl/python-java/convert-powerpoint-to-markdown/
keywords:
- "PowerPoint converteren"
- "presentatie converteren"
- "slide converteren"
- "PPT converteren"
- "PPTX converteren"
- "PowerPoint naar MD"
- "presentatie naar MD"
- "slide naar MD"
- "PPT naar MD"
- "PPTX naar MD"
- "PowerPoint opslaan als Markdown"
- "presentatie opslaan als Markdown"
- "slide opslaan als Markdown"
- "PPT opslaan als MD"
- "PPTX opslaan als MD"
- "PPT exporteren naar MD"
- "PPTX exporteren naar MD"
- "Markdown-afbeeldingsexport"
- "CDN-afbeeldingslinks"
- "PowerPoint"
- "presentatie"
- "Markdown"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Converteer PPT- en PPTX-presentaties naar Markdown in Python via Java en beheer waar geëxporteerde bitmap-, metafile- en SVG-afbeeldingen worden opgeslagen en gerefereerd."
---
## **Overzicht**

Aspose.Slides voor Python via Java kan PPT- en PPTX-presentaties omzetten naar Markdown voor documentatie, statische sites, content-migratie en versiebeheersworkflows. Je kunt een Markdown‑variant kiezen, bepalen hoe de slide‑inhoud wordt gerenderd en beslissen waar geëxporteerde afbeeldingen worden opgeslagen en hoe de gegenereerde Markdown ernaar verwijst.

Standaard gebruikt Markdown‑export alleen tekstoutput. Om visuele inhoud te exporteren, stel je het exporttype in met de [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/markdownsaveoptions/#setExportType)‑methode op de `Sequential`‑ of `Visual`‑waarde uit de [MarkdownExportType](https://reference.aspose.com/slides/nl/python-java/aspose.slides/markdownexporttype/)‑enumeratie. `Sequential` rendert slide‑elementen afzonderlijk en in volgorde, terwijl `Visual` gegroepeerde elementen samen houdt om hun visuele relatie te behouden. De `TextOnly`‑waarde genereert geen afbeeldingsresources, zodat de callback‑functies voor het opslaan van afbeeldingen niet worden aangeroepen in die modus.

## **Converteer een presentatie naar Markdown**

Laad het bronbestand met de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑klasse en roep vervolgens de [Presentation.save](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/#save)‑methode aan met de `Md`‑waarde uit de [SaveFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/saveformat/)‑enumeratie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.md", SaveFormat.Md)
finally:
    presentation.dispose()
```

Elk voorbeeld leest `presentation.pptx` uit de huidige werkmap. Installeer Aspose.Slides voor Python via Java en een compatibele Java‑runtime voordat je de voorbeelden uitvoert. Start de JVM één keer per Python‑proces.

## **Kies een Markdown‑variant**

De [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/markdownsaveoptions/#setFlavor)‑methode bepaalt welke Markdown‑specificatie voor de output wordt gebruikt. De [Flavor](https://reference.aspose.com/slides/nl/python-java/aspose.slides/flavor/)‑enumeratie omvat CommonMark, GitHub Flavored Markdown en andere ondersteunde varianten.

Het volgende voorbeeld exporteert een presentatie als CommonMark:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Flavor, MarkdownSaveOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setFlavor(Flavor.CommonMark)

    presentation.save("presentation.md", SaveFormat.Md, options)
finally:
    presentation.dispose()
```

## **Exporteer afbeeldingen met het standaard gedrag voor lokaal opslaan**

De [MarkdownSaveOptions](https://reference.aspose.com/slides/nl/python-java/aspose.slides/markdownsaveoptions/)‑klasse biedt twee methoden voor het configureren van lokaal opgeslagen afbeeldingen:

- [setBasePath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/markdownsaveoptions/#setBasePath) specificeert de basisdirectory voor het Markdown‑document en de bijbehorende resources.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/nl/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName) specificeert de subdirectory voor afbeeldingen. De standaardwaarde is `Images`.

Het volgende voorbeeld rendert visuele inhoud, schrijft afbeeldingen naar `output/assets` en maakt relatieve afbeeldingsreferenties aan in het Markdown‑document:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("assets")

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

Dit gedrag dient ook als fallback wanneer een aangepaste afbeelding‑opslaanknop `False` retourneert.

## **Pas het opslaan van afbeeldingen en Markdown‑links aan**

Gebruik de [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/nl/python-java/aspose.slides/markdownsaveoptions/)‑methode om een callback te registreren voor niet‑SVG bitmap‑ en metafile‑resources die tijdens de Markdown‑export worden gegenereerd. Zijn `MarkdownImageSavingHandler`‑callback ontvangt het afbeeldingsobject, de [ImageFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imageformat/)‑waarde, en de gegenereerde Markdown‑link als een één‑element `String[]`‑parameter. Sla de afbeelding op of upload deze met het opgegeven formaat, en vervang `link[0]` door de referentie die in de Markdown‑output moet verschijnen.

Resources die in SVG‑formaat worden uitgegeven, worden apart behandeld. Registreer een callback met de [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/nl/python-java/aspose.slides/markdownsaveoptions/)‑methode. Zijn `MarkdownSvgImageSavingHandler`‑callback ontvangt een [SvgImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgimage/)‑object en de één‑element `String[] link`‑parameter. Een SVG heeft geen `ImageFormat`‑argument; schrijf of upload in plaats daarvan de XML‑data via de [SvgImage.getSvgData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgimage/#getSvgData)‑methode. Afhankelijk van de exportmodus en visuele groepering kan een SVG in de bronpresentatie gerasterd of gecombineerd met andere inhoud worden; de resulterende niet‑SVG‑resource wordt vervolgens doorgegeven aan de afbeelding‑opslaancallback. Registreer beide callbacks wanneer elke geëxporteerde visuele resource aangepaste verwerking vereist.

De retourwaarde van de handler bepaalt wie de afbeelding verwerkt:

- Retourneer `True` nadat de handler de afbeelding heeft opgeslagen, geüpload, getransformeerd of anderszins verwerkt en een geldige waarde aan `link[0]` heeft toegewezen. Aspose.Slides schrijft die waarde naar het Markdown‑document en voert de standaard lokale opslag niet uit.
- Retourneer `False` om Aspose.Slides de afbeelding lokaal te laten opslaan en de link te genereren op basis van de waarden die zijn ingesteld met [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/markdownsaveoptions/#setBasePath) en [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/nl/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

{{% alert color="danger" title="Important" %}}
Een handler die `True` retourneert, neemt de verantwoordelijkheid voor de afbeelding op zich. Als hij `True` retourneert zonder een geldige, niet‑lege link toe te wijzen, mislukt de export met een `InvalidOperationException`.
{{% /alert %}}

In Python registreer je deze callbacks met `jpype.JProxy`, waarbij je de Java‑callback‑interface implementeert via de `invoke`‑methode. Het `link`‑argument is een mutabele Java‑string‑array: converteer `link[0]` naar een Python‑string voordat je deze verwerkt, en wijs vervolgens de vervangende URL toe aan `link[0]`.

### **Sla afbeeldingen op in een CDN‑origin‑directory en gebruik externe URL's**

Het volgende voorbeeld beschouwt `cdn-origin/presentations/quarterly-report` als een gemonteerde of gesynchroniseerde CDN‑origin‑directory. Elke handler haalt de gegenereerde bestandsnaam op, slaat de afbeelding op in die aangepaste directory en vervangt de gegenereerde lokale referentie door een publieke CDN‑URL. Het voorbeeld zelf voert geen netwerkt upload uit: de URL wordt pas geldig nadat de directory is gemonteerd als de CDN‑origin of de bestanden zijn gepubliceerd naar het CDN. Voor objectopslag vervang je de bestands‑systeem‑schrijfbewerking door de upload‑operatie van de storage‑SDK en wijs je `link[0]` pas toe nadat de upload geslaagd is.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from urllib.parse import quote
from asposeslides.api import MarkdownExportType, MarkdownSaveOptions, Presentation, SaveFormat

output_directory = Path("output")
public_base_url = "https://cdn.example.com/presentations/quarterly-report"
storage_directory = Path("cdn-origin", "presentations", "quarterly-report")
output_directory.mkdir(parents=True, exist_ok=True)
storage_directory.mkdir(parents=True, exist_ok=True)

def get_file_name(generated_link):
    normalized_link = str(generated_link).replace("\\", "/")
    return normalized_link.rsplit("/", 1)[-1]

def save_image(image, image_format, link):
    if image.getWidth() < 128 or image.getHeight() < 128:
        return False

    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    image.save(str(storage_path), image_format)
    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

def save_svg(svg_image, link):
    file_name = get_file_name(link[0])
    storage_path = storage_directory / file_name
    svg_data = svg_image.getSvgData()
    try:
        storage_path.write_bytes(bytes(svg_data))
    except OSError as error:
        print(f"Could not save the SVG image: {error}")
        return False

    encoded_file_name = quote(file_name, safe="")
    link[0] = public_base_url + "/" + encoded_file_name
    return True

image_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", dict(invoke=save_image))
svg_handler = jpype.JProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", dict(invoke=save_svg))

presentation = Presentation("presentation.pptx")
try:
    options = MarkdownSaveOptions()
    options.setExportType(MarkdownExportType.Visual)
    options.setBasePath(str(output_directory))
    options.setImagesSaveFolderName("fallback-images")
    options.setImageSaving(image_handler)
    options.setSvgImageSaving(svg_handler)

    markdown_path = output_directory / "presentation.md"
    presentation.save(str(markdown_path), SaveFormat.Md, options)
finally:
    presentation.dispose()
```

De bitmap‑handler retourneert opzettelijk `False` voor afbeeldingen kleiner dan 128 × 128 pixels, zodat Aspose.Slides die afbeeldingen opslaat in `output/fallback-images` met het standaardgedrag. Grotere bitmap‑ en metafile‑resources, evenals SVG‑resources, worden afgehandeld door de aangepaste code. Bijvoorbeeld, een gegenereerde lokale referentie zoals `fallback-images/image1.png` wordt `https://cdn.example.com/presentations/quarterly-report/image1.png`. De handlers gebruiken alleen besturingssysteem‑paden bij het schrijven van bestanden; links die in Markdown worden geschreven gebruiken schuine strepen en URL‑geëncodeerde bestandsnamen. Pas dezelfde regel toe bij het bouwen van relatieve links: gebruik `/`, niet de platform‑specifieke scheidingsteken.

## **FAQ**

**Kan één handler zowel raster‑ als SVG‑afbeeldingen verwerken?**

Nee. Gebruik [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/nl/python-java/aspose.slides/markdownsaveoptions/) voor uitgegeven bitmap‑ en metafile‑resources en [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/nl/python-java/aspose.slides/markdownsaveoptions/) voor resources die als SVG worden uitgegeven. De eerste levert een afbeeldingsobject en een [ImageFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/imageformat/)‑waarde; de tweede levert een [SvgImage](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgimage/)‑object waarvan de SVG‑data kan worden gelezen met [SvgImage.getSvgData](https://reference.aspose.com/slides/nl/python-java/aspose.slides/svgimage/#getSvgData). Een bron‑SVG die tijdens de export wordt gerasterd, wordt verwerkt door de afbeelding‑opslaancallback.

**Wat gebeurt er als een afbeelding‑opslaancallback `False` retourneert?**

Aspose.Slides gebruikt het standaard lokaal‑opslaangedrag. De locatie van de afbeelding en de gegenereerde referentie worden bepaald door de waarden die zijn ingesteld met [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/nl/python-java/aspose.slides/markdownsaveoptions/#setBasePath) en [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/nl/python-java/aspose.slides/markdownsaveoptions/#setImagesSaveFolderName).

**Kan een handler een URL geven zonder de afbeelding lokaal op te slaan?**

Ja. De handler kan de afbeelding uploaden naar objectopslag of doorgeven aan een andere dienst, de resulterende URL toewijzen aan `link[0]`, en `True` retourneren. De handler moet de verwerking zelf voltooien; het retourneren van `True` voorkomt de standaard lokale opslag.

**Waarom gooit de Markdown‑export een `InvalidOperationException` vanuit een handler?**

Deze uitzondering treedt op wanneer de handler `True` retourneert maar geen geldige link opgeeft. Wijs het relatieve pad of de externe URL toe die in Markdown moet worden geschreven voordat je `True` retourneert.

**Welke pad‑scheidingsteken moet worden gebruikt voor afbeeldings‑links?**

Gebruik schuine strepen in Markdown‑links en URL’s. Gebruik `pathlib.Path` alleen voor bestands‑systeem‑paden, en bouw of normaliseer de Markdown‑referentie daarna apart.

**Worden hyperlinks behouden tijdens de Markdown‑export?**

Ja. Tekst [hyperlinks](/slides/nl/python-java/manage-hyperlinks/) worden bewaard als standaard Markdown‑links. Slide‑[transities](/slides/nl/python-java/slide-transition/) en [animaties](/slides/nl/python-java/powerpoint-animation/) worden niet omgezet.

**Kunnen presentaties parallel naar Markdown worden geconverteerd?**

Je kunt verschillende presentatiebestanden parallel verwerken, maar deel dezelfde [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/)‑instantie niet tussen threads. Volg de [multithreading guidelines](/slides/nl/python-java/multithreading/) en gebruik een aparte instantie voor elk bestand.