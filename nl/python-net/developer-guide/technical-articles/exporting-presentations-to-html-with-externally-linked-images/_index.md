---
title: Presentaties exporteren naar HTML met extern gelinkte afbeeldingen in Python
linktitle: Presentaties exporteren naar HTML met extern gelinkte afbeeldingen
type: docs
weight: 100
url: /nl/python-net/exporting-presentations-to-html-with-externally-linked-images/
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
- gelinkte afbeelding
- extern gelinkte afbeelding
- gelinkte resource
- externe resource
- Python
- Aspose.Slides
description: "PowerPoint- en OpenDocument-presentaties exporteren naar HTML in Python met Aspose.Slides, waarbij afbeeldingen worden opgeslagen als extern gelinkte bestanden."
---
## **Overzicht**

Standaard exporteert Aspose.Slides een presentatie naar een zelfvoorzienend HTML‑bestand. Afbeeldingen en andere resources worden direct in de HTML geschreven, meestal als Base64‑gegevens. Dit is handig wanneer u één draagbaar bestand nodig hebt, maar het is niet altijd het beste format voor een website, een CMS of een server‑side conversiepijplijn.

- verklein de grootte van het HTML‑document;
- cache afbeeldingen apart in een browser of CDN;
- inspecteer, vervang, comprimeer of voer post‑processing uit op gegenereerde afbeeldingen na export;
- houd de outputstructuur dichter bij wat een webapplicatie verwacht.

Voor de algemene HTML‑conversieworkflow, zie [Convert PowerPoint Presentations to HTML](/slides/nl/python-net/convert-powerpoint-to-html/). Dit artikel richt zich op het gedeelte van de export dat afbeeldingen koppelt.

## **Hoe gelinkte afbeeldingsexport werkt**

In .NET en Java vertegenwoordigt [ILinkEmbedController](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/ilinkembedcontroller/) de callback‑interface die de exporter gebruikt om te bepalen of een resource moet worden ingesloten of gelinkt. In Python via .NET kunnen Python‑klassen deze .NET‑callback‑interface momenteel niet direct implementeren, dus is de praktische workflow:

1. Exporteer de presentatie naar HTML met [HtmlOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/htmloptions/).
2. Gebruik [SlideImageFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/slideimageformat/) met [SVGOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/svgoptions/) zodat de dia's worden weergegeven als SVG in de HTML.
3. Verplaats Base64‑afbeeldingsgegevens van HTML `data:`‑URL's naar afzonderlijke bestanden.
4. Vervang de oorspronkelijke `data:`‑URL's door relatieve koppelingen zoals `assets/resource-1.jpg`.

Het bestandssysteempad en de browser‑URL zijn afzonderlijke zaken. Bijvoorbeeld, het voorbeeld hieronder schrijft afbeeldingsbestanden naar `html-output/assets` op schijf, terwijl de HTML relatieve URL's bevat zoals `assets/resource-1.jpg`. Een browser lost die URL's op ten opzichte van het HTML‑bestand dat de koppeling bevat.

## **HTML exporteren met gelinkte afbeeldingen**

Het volgende Python‑voorbeeld maakt een uitvoermap aan, slaat het HTML‑bestand daar op, legt geëxtraheerde afbeeldingen op in een `assets`‑submap, en herschrijft Base64‑afbeeldings‑URL's naar relatieve koppelingen. Het voorbeeld extraheert gangbare Base64‑afbeeldingsformaten wanneer Aspose.Slides een veilig bestandsextensie levert. Data‑URL's die niet herkend worden blijven ingesloten.

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

Na de export kan de uitvoermap er als volgt uitzien:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

De exacte bestanden hangen af van de inhoud van de presentatie en de exportopties. Bijvoorbeeld, rasterafbeeldingen worden meestal geëxporteerd als JPEG of PNG. Aspose.Slides kan een andere afbeeldingcodec kiezen dan die in de bronpresentatie werd gebruikt wanneer dat een kleiner of geschikter bestand oplevert. Afbeeldingen met transparantie worden geëxporteerd als PNG.

## **URL's kiezen voor inzet**

Het voorbeeld gebruikt een relatieve URL‑prefix: `assets/`. Als `presentation.html` wordt geopend vanuit `html-output/presentation.html`, laadt de browser `html-output/assets/resource-1.jpg`.

- Gebruik `assets/` wanneer de asset‑map naast het HTML‑bestand staat.
- Gebruik `../assets/` wanneer de asset‑map één niveau boven het HTML‑bestand ligt.
- Gebruik `https://cdn.example.com/presentations/job-123/assets/` wanneer de bestanden geüpload worden naar een CDN of een statische bestandsserver.

In serverapplicaties, gebruik een unieke uitvoermap of object‑storage prefix voor elke conversietaak om overschrijven van bestanden van een andere export te voorkomen.

## **Wanneer inbedden in plaats daarvan**

Ingesloten Base64‑HTML blijft nuttig wanneer de output één enkel bestand moet zijn, zoals een e‑mailbijlage, een offline preview, of een document dat zonder een ondersteunende asset‑map verplaatst wordt. Gelinkte afbeeldingen passen beter wanneer de HTML wordt geserveerd door een webapplicatie, opgeslagen in een CMS, geoptimaliseerd door een build‑pipeline, of gecachet door browsers onafhankelijk van de HTML.

## **FAQ**

**Kan ik alleen afbeeldingen externaliseren en andere resources ingesloten laten?**

Ja. Het voorbeeld extraheert alleen `image/*` Base64‑data‑URL's waarvan de content‑types zijn opgesomd in `EXTENSIONS_BY_CONTENT_TYPE`. Andere data‑URL's blijven ingesloten.

**Waarom verschilt de geëxporteerde afbeeldingsextensie van de bronpresentatie?**

Aspose.Slides kan rasterafbeeldingen opnieuw coderen tijdens HTML‑export om grootte of browser‑compatibiliteit te verbeteren. Bijvoorbeeld, een afbeelding uit het bronbestand kan geschreven worden als JPEG of PNG afhankelijk van het gerenderde resultaat.

**Werken relatieve URL's nadat ik het HTML‑bestand verplaats?**

Relatieve URL's werken alleen wanneer dezelfde relatieve mapstructuur behouden blijft. Als de HTML `assets/resource-1.png` refereert, moet de `assets`‑map naast het HTML‑bestand blijven tenzij u een andere URL‑prefix genereert.

**Moeten serverapplicaties dezelfde uitvoermap hergebruiken?**

Nee. Gebruik een unieke uitvoermap of opslag‑prefix voor elke conversietaak. Dit voorkomt naamconflicten en voorkomt dat één export resources van een andere export overschrijft.