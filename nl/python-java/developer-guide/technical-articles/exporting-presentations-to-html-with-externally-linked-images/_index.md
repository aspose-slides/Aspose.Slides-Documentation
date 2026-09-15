---
title: Presentaties exporteren naar HTML met extern gekoppelde afbeeldingen
type: docs
weight: 100
url: /nl/python-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint exporteren
- OpenDocument exporteren
- presentatie exporteren
- dia exporteren
- PPT exporteren
- PPTX exporteren
- ODP exporteren
- PowerPoint naar HTML
- OpenDocument naar HTML
- presentatie naar HTML
- dia naar HTML
- PPT naar HTML
- PPTX naar HTML
- ODP naar HTML
- gekoppelde afbeelding
- extern gekoppelde afbeelding
- gekoppelde resource
- externe resource
- Python
- Java
- Aspose.Slides
description: "Exporteer PowerPoint- en OpenDocument-presentaties naar HTML in Python met Aspose.Slides, waarbij afbeeldingen en andere resources worden opgeslagen als extern gekoppelde bestanden."
---
## **Overzicht**

Standaard exporteert Aspose.Slides een presentatie naar een zelfstandig HTML‑bestand. Afbeeldingen en andere bronnen worden direct in de HTML geschreven, meestal als Base64‑gegevens. Dit is handig wanneer je één draagbaar bestand nodig hebt, maar het is niet altijd het beste formaat voor een website, een CMS of een server‑side conversiepijplijn.

Gebruik extern gekoppelde bronnen wanneer je:

- verklein de grootte van het HTML‑document;
- cache afbeeldingen, lettertypen, audio of video afzonderlijk in een browser of CDN;
- inspecteer, vervang, comprimeer of verwerk gegenereerde bronnen na het exporteren;
- houd de uitvoerstructuur dichter bij wat een webapplicatie verwacht.

Voor de algemene HTML‑conversieworkflow, zie [Convert PowerPoint Presentations to HTML](/slides/nl/python-java/convert-powerpoint-to-html/). Dit artikel richt zich op het resource‑linken gedeelte van de export.

## **Hoe gelinkte resource‑export werkt**

`ILinkEmbedController` laat je applicatie per resource beslissen of de exporter de gegevens in de HTML inbedt of extern opslaat en een link schrijft.

De interface heeft drie methoden:

- `ILinkEmbedController.getObjectStoringLocation` bepaalt of een resource gelinkt of ingesloten moet worden.
- `ILinkEmbedController.getUrl` retourneert de URL die in de gegenereerde HTML of naar een andere gelinkte resource wordt geschreven.
- `ILinkEmbedController.saveExternal` schrijft de gelinkte resource‑data naar schijf of naar een ander opslagdoel.

Het bestandssysteem‑pad en de browser‑URL zijn afzonderlijke zaken. Bijvoorbeeld, het onderstaande voorbeeld schrijft resource‑bestanden naar `html-output/assets` op schijf, terwijl de HTML relatieve URL’s bevat zoals `assets/resource-1.svg`. Een browser lost die URL’s op relatief ten opzichte van het bestand dat de link bevat. Daarom gebruikt een link van `presentation.html` naar een SVG‑bestand `assets/resource-1.svg`, terwijl een link vanuit dat SVG‑bestand naar een afbeelding die in dezelfde `assets`‑map is opgeslagen `resource-4.jpg` gebruikt.

## **HTML exporteren met gelinkte resources**

Het volgende Python‑voorbeeld maakt een uitvoermap aan, slaat het HTML‑bestand daar op en slaat gelinkte resources op in een submap `assets`. De controller linkt veelvoorkomende afbeelding‑, lettertype‑, audio‑, video‑ en CSS‑resources wanneer Aspose.Slides een veilige bestandsextensie biedt of kan afleiden. Resources die niet herkend worden blijven ingesloten.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpife.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Na de export heeft de uitvoermap deze structuur:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

De exacte bestanden hangen af van de inhoud van de presentatie en de exportopties. Bijvoorbeeld, raster‑afbeeldingen worden doorgaans geëxporteerd als JPEG of PNG. Aspose.Slides kan een andere afbeeldingcodec kiezen dan die in de bronpresentatie wordt gebruikt wanneer dat een kleiner of geschikter bestand oplevert. Afbeeldingen met transparantie worden geëxporteerd als PNG.

## **URL’s kiezen voor implementatie**

Het voorbeeld gebruikt een relatieve URL‑prefix: `assets/`. Als `presentation.html` wordt geopend vanaf `html-output/presentation.html`, laadt de browser `html-output/assets/resource-1.svg`.

Wanneer een gelinkte resource verwijst naar een andere gelinkte resource, gebruikt het voorbeeld de `referrer`‑parameter in `ILinkEmbedController.getUrl` en retourneert alleen de bestandsnaam. Bijvoorbeeld, als `resource-1.svg` en `resource-4.jpg` beide in de `assets`‑map staan, moet het SVG‑bestand verwijzen naar `resource-4.jpg`, niet naar `assets/resource-4.jpg`.

Gebruik een andere URL‑prefix wanneer de bestanden elders worden geïmplementeerd:

- Gebruik `assets/` wanneer de asset‑map naast het HTML‑bestand staat.
- Gebruik `../assets/` wanneer de asset‑map één niveau boven het HTML‑bestand staat.
- Gebruik `https://cdn.example.com/presentations/job-123/assets/` wanneer de bestanden geüpload worden naar een CDN of statische bestandsserver.

De URL die door `ILinkEmbedController.getUrl` wordt geretourneerd moet overeenkomen met de uiteindelijke geïmplementeerde locatie van het bestand dat door `ILinkEmbedController.saveExternal` wordt geschreven. In serverapplicaties, gebruik een unieke uitvoermap of object‑storage‑prefix voor elke conversietaak om te voorkomen dat bestanden van een andere export worden overschreven.

## **Wanneer in plaats daarvan insluiten**

Ingesloten Base64‑HTML blijft nuttig wanneer de output één enkel bestand moet zijn, zoals een e‑mailbijlage, een offline voorbeeld of een document dat wordt verplaatst zonder een ondersteunende asset‑map. Gelinkte resources passen beter wanneer de HTML wordt geserveerd door een webapplicatie, opgeslagen in een CMS, geoptimaliseerd door een build‑pipeline, of door browsers onafhankelijk van de HTML wordt gecached.

## **FAQ**

**Kan ik alleen afbeeldingen externaliseren en andere resources ingesloten houden?**

Ja. In `ILinkEmbedController.getObjectStoringLocation` retourneer je [LinkEmbedDecision.Link](https://reference.aspose.com/slides/nl/python-java/aspose.slides/linkembeddecision/#Link) alleen voor de content‑types die je als afzonderlijke bestanden wilt opslaan, en retourneer je [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/nl/python-java/aspose.slides/linkembeddecision/#Embed) voor alles overige.

**Waarom verschilt de geëxporteerde afbeeldingsextensie van de bronpresentatie?**

Aspose.Slides kan raster‑afbeeldingen tijdens de HTML‑export opnieuw coderen om grootte of browser‑compatibiliteit te verbeteren. Bijvoorbeeld, een afbeelding uit het bronbestand kan worden weggeschreven als JPEG of PNG afhankelijk van het gerenderde resultaat.

**Werken relatieve URL’s als ik het HTML‑bestand verplaats?**

Relatieve URL’s werken alleen wanneer dezelfde relatieve mapstructuur behouden blijft. Als de HTML `assets/resource-1.png` refereert, moet de `assets`‑map naast het HTML‑bestand blijven, tenzij je een andere URL‑prefix genereert.

**Moeten serverapplicaties dezelfde uitvoermap hergebruiken?**

Nee. Gebruik een unieke uitvoermap of opslag‑prefix voor elke conversietaak. Dit voorkomt bestandsnaamconflicten en voorkomt dat één export resources van een andere export overschrijft.