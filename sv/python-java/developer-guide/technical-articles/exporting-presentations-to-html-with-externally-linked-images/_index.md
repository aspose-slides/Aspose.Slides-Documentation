---
title: Exportera presentationer till HTML med externt länkade bilder
type: docs
weight: 100
url: /sv/python-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- exportera PowerPoint
- exportera OpenDocument
- exportera presentation
- exportera bild
- exportera PPT
- exportera PPTX
- exportera ODP
- PowerPoint till HTML
- OpenDocument till HTML
- presentation till HTML
- bild till HTML
- PPT till HTML
- PPTX till HTML
- ODP till HTML
- länkad bild
- externt länkad bild
- länkad resurs
- extern resurs
- Python
- Java
- Aspose.Slides
description: "Exportera PowerPoint- och OpenDocument-presentationer till HTML i Python med hjälp av Aspose.Slides, där bilder och andra resurser sparas som externt länkade filer."
---
## **Översikt**

Som standard exporterar Aspose.Slides en presentation till en fristående HTML‑fil. Bilder och andra resurser skrivs direkt in i HTML, vanligtvis som Base64‑data. Detta är praktiskt när du behöver en enda portabel fil, men det är inte alltid det bästa formatet för en webbplats, ett CMS eller en server‑sidig konverteringspipeline.

Använd externlänkade resurser när du vill:

- minska HTML‑dokumentets storlek;
- cacha bilder, typsnitt, ljud eller video separat i en webbläsare eller CDN;
- inspektera, ersätta, komprimera eller efterbehandla genererade resurser efter export;
- behålla utdata‑strukturen närmare vad en webbapplikation förväntar sig.

För den allmänna HTML‑konverteringsarbetsflödet, se [Convert PowerPoint Presentations to HTML](/slides/sv/python-java/convert-powerpoint-to-html/). Denna artikel fokuserar på resurs‑länkningdelen av exporten.

## **Hur export med länkade resurser fungerar**

`ILinkEmbedController` låter din applikation avgöra, resurs för resurs, om exportören bäddar in data i HTML eller sparar den externt och skriver en länk.

Gränssnittet har tre metoder:

- `ILinkEmbedController.getObjectStoringLocation` bestämmer om en resurs ska länkas eller bäddas in.
- `ILinkEmbedController.getUrl` returnerar URL‑en som kommer att skrivas till den genererade HTML‑en eller till en annan länkad resurs.
- `ILinkEmbedController.saveExternal` skriver de länkade resursdata till disk eller till ett annat lagringsmål.

Filsystemsvägen och webbläsar‑URL:en är separata frågor. Till exempel skriver provet nedan resursfiler till `html-output/assets` på disk, medan HTML‑en innehåller relativa URL:er som `assets/resource-1.svg`. En webbläsare löser dessa URL:er relativt till filen som innehåller länken. Därför använder en länk från `presentation.html` till en SVG‑fil `assets/resource-1.svg`, medan en länk från den SVG‑filen till en bild sparad i samma `assets`‑mapp använder `resource-4.jpg`.

## **Exportera HTML med länkade resurser**

Följande Python‑exempel skapar en output‑katalog, sparar HTML‑filen där och lagrar länkade resurser i en `assets`‑undermapp. Kontrollen länkar vanliga bild‑, typsnitt‑, ljud‑, video‑ och CSS‑resurser när Aspose.Slides tillhandahåller eller kan härleda en säker filändelse. Resurser som inte känns igen förblir inbäddade.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

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

Efter exporten har output‑mappen denna struktur:

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

De exakta filerna beror på presentationens innehåll och exportalternativ. Till exempel exporteras rasterbilder vanligtvis som JPEG eller PNG. Aspose.Slides kan välja en annan bild‑codec än den som används i källpresentationen när det ger en mindre eller mer lämplig fil. Bilder med transparens exporteras som PNG.

## **Välja URL:er för distribution**

Exemplet använder ett relativt URL‑prefix: `assets/`. Om `presentation.html` öppnas från `html-output/presentation.html` laddar webbläsaren `html-output/assets/resource-1.svg`.

När en länkad resurs hänvisar till en annan länkad resurs använder exemplet parametern `referrer` i `ILinkEmbedController.getUrl` och returnerar bara filnamnet. Till exempel, om `resource-1.svg` och `resource-4.jpg` båda finns i `assets`‑mappen, bör SVG‑filen hänvisa till `resource-4.jpg`, inte till `assets/resource-4.jpg`.

Använd ett annat URL‑prefix när filerna distribueras någon annanstans:

- Använd `assets/` när asset‑katalogen ligger bredvid HTML‑filen.
- Använd `../assets/` när asset‑katalogen är en nivå ovanför HTML‑filen.
- Använd `https://cdn.example.com/presentations/job-123/assets/` när filerna laddas upp till en CDN eller statisk filserver.

URL‑en som returneras av `ILinkEmbedController.getUrl` måste matcha den slutliga distribuerade platsen för filen som skrivs av `ILinkEmbedController.saveExternal`. I server‑applikationer, använd en unik output‑katalog eller objekt‑lagrings‑prefix för varje konverteringsjobb för att undvika att skriva över filer från en annan export.

## **När man ska bädda in istället**

Inbäddad Base64‑HTML är fortfarande användbar när utdata måste vara en enda fil, till exempel som e‑postbilaga, en offline‑förhandsgranskning eller ett dokument som ska flyttas utan en stödjande asset‑mapp. Länkade resurser passar bättre när HTML levereras av en webbapplikation, lagras i ett CMS, optimeras av en byggpipeline eller cachas av webbläsare oberoende av HTML.

## **FAQ**

**Kan jag externalisera endast bilder och behålla andra resurser inbäddade?**

Ja. I `ILinkEmbedController.getObjectStoringLocation` returnerar du [LinkEmbedDecision.Link](https://reference.aspose.com/slides/sv/python-java/aspose.slides/linkembeddecision/#Link) endast för de innehållstyper du vill spara som separata filer, och returnerar [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/sv/python-java/aspose.slides/linkembeddecision/#Embed) för allt annat.

**Varför skiljer sig den exporterade bildfilens filändelse från källpresentationen?**

Aspose.Slides kan omkoda rasterbilder under HTML‑export för att förbättra storlek eller webbläsarkompatibilitet. Till exempel kan en bild från källfilen skrivas som JPEG eller PNG beroende på det renderade resultatet.

**Fungerar relativa URL:er efter att jag flyttat HTML‑filen?**

Relativa URL:er fungerar endast när samma relativa mappstruktur bevaras. Om HTML‑filen refererar till `assets/resource-1.png` måste `assets`‑mappen förbli bredvid HTML‑filen om du inte genererar ett annat URL‑prefix.

**Ska server‑applikationer återanvända samma output‑mapp?**

Nej. Använd en unik output‑katalog eller lagrings‑prefix för varje konverteringsjobb. Detta undviker filnamnskonflikter och förhindrar att en export skriver över resurser som genererats av en annan export.