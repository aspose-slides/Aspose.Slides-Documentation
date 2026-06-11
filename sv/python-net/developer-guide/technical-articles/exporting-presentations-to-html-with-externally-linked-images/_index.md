---
title: Exportera presentationer till HTML med externt länkade bilder i Python
linktitle: Exportera presentationer till HTML med externt länkade bilder
type: docs
weight: 100
url: /sv/python-net/exporting-presentations-to-html-with-externally-linked-images/
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
- extern länkad bild
- länkad resurs
- extern resurs
- Python
- Aspose.Slides
description: "Exportera PowerPoint- och OpenDocument-presentationer till HTML i Python med Aspose.Slides där bilder sparas som externt länkade filer."
---
## **Översikt**

Som standard exporterar Aspose.Slides en presentation till en fristående HTML-fil. Bilder och andra resurser skrivs direkt in i HTML, vanligtvis som Base64-data. Detta är bekvämt när du behöver en portabel fil, men det är inte alltid det bästa formatet för en webbplats, ett CMS eller en server-sidig konverteringspipeline.

Använd externa länkade bilder när du vill:

- reducera storleken på HTML-dokumentet;
- cacha bilder separat i en webbläsare eller CDN;
- inspektera, ersätta, komprimera eller efterbehandla genererade bilder efter export;
- behålla utdata-strukturen närmare vad en webbapplikation förväntar sig.

För den allmänna HTML-konverteringsarbetsflödet, se [Convert PowerPoint Presentations to HTML](/slides/sv/python-net/convert-powerpoint-to-html/). Denna artikel fokuserar på bild-länkningen i exporten.

## **Hur länkad bildexport fungerar**

I .NET och Java representerar [ILinkEmbedController](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/ilinkembedcontroller/) callback-gränssnittet som exportören använder för att avgöra om en resurs ska bäddas in eller länkas. I Python via .NET kan Python-klasser för närvarande inte implementera detta .NET-callback-gränssnitt direkt, så det praktiska arbetsflödet är:

1. Exportera presentationen till HTML med [HtmlOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/htmloptions/).
1. Använd [SlideImageFormat](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/slideimageformat/) tillsammans med [SVGOptions](https://reference.aspose.com/slides/sv/python-net/aspose.slides.export/svgoptions/) så att bilderna representeras som SVG i HTML.
1. Flytta Base64-bilddata från HTML `data:`-URL:er till separata filer.
1. Ersätt de ursprungliga `data:`-URL:erna med relativa länkar, till exempel `assets/resource-1.jpg`.

Filsystemssökvägen och webbläsar-URL:en är separata aspekter. Till exempel skriver exempelprogrammet nedanstående bildfiler till `html-output/assets` på disken, medan HTML-filen innehåller relativa URL:er såsom `assets/resource-1.jpg`. En webbläsare löser dessa URL:er relativt till HTML-filen som innehåller länken.

## **Exportera HTML med länkade bilder**

Det följande Python-exemplet skapar en utdata-katalog, sparar HTML-filen där, lagrar extraherade bilder i en `assets`-undermapp och skriver om Base64-bild-URL:er till relativa länkar. Exemplet extraherar vanliga Base64-bildformat när Aspose.Slides tillhandahåller en säker filändelse. Data-URL:er som inte känns igen förblir inbäddade.

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

Efter exporten kan utdata-mappen ha denna struktur:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

De exakta filerna beror på presentationens innehåll och exportalternativen. Till exempel exporteras rasterbilder ofta som JPEG eller PNG. Aspose.Slides kan välja en annan bild-codec än den som används i källpresentationen när det ger en mindre eller mer lämplig fil. Bilder med transparens exporteras som PNG.

## **Välja URL:er för distribution**

Exempelprogrammet använder ett relativt URL-prefix: `assets/`. Om `presentation.html` öppnas från `html-output/presentation.html` laddar webbläsaren `html-output/assets/resource-1.jpg`.

Använd ett annat namn på tillgångsmappen eller skriv om de genererade länkarna när filerna distribueras någon annanstans:

- Använd `assets/` när tillgångsmappen ligger bredvid HTML-filen.
- Använd `../assets/` när tillgångsmappen ligger en nivå ovanför HTML-filen.
- Använd `https://cdn.example.com/presentations/job-123/assets/` när filerna laddas upp till ett CDN eller en statisk filserver.

I serverapplikationer, använd en unik utdata-katalog eller objekt-lagrings-prefix för varje konverteringsjobb för att undvika att skriv över filer från en annan export.

## **När man istället bör bädda in**

Inbäddad Base64-HTML är fortfarande användbar när utskriften måste vara en enda fil, till exempel som ett e-post-bilaga, en offline-förhandsvisning eller ett dokument som ska flyttas utan en stödjande tillgångsmapp. Länkade bilder är ett bättre alternativ när HTML kommer att serveras av en webbapplikation, lagras i ett CMS, optimeras av en byggpipeline eller cachas av webbläsare oberoende av HTML.

## **FAQ**

**Kan jag bara externalisera bilder och behålla andra resurser inbäddade?**

Ja. Exempelprogrammet extraherar endast `image/*` Base64-data-URL:er vars innehållstyper listas i `EXTENSIONS_BY_CONTENT_TYPE`. Andra data-URL:er förblir inbäddade.

**Varför skiljer sig den exporterade bildfilens filändelse från källpresentationen?**

Aspose.Slides kan återkoda rasterbilder under HTML-export för att förbättra storlek eller webbläsarkompatibilitet. Till exempel kan en bild från källfilen skrivas som JPEG eller PNG beroende på det renderade resultatet.

**Fungerar relativa URL:er efter att jag flyttar HTML-filen?**

Relativa URL:er fungerar endast när samma relativa mappstruktur bevaras. Om HTML-filen refererar till `assets/resource-1.png` måste `assets`-mappen ligga bredvid HTML-filen om du inte genererar ett annat URL-prefix.

**Ska serverapplikationer återanvända samma utdata-mapp?**

Nej. Använd en unik utdata-katalog eller lagrings-prefix för varje konverteringsjobb. Detta undviker filnamnskollisioner och förhindrar att en export skriver över resurser som genererats av en annan export.