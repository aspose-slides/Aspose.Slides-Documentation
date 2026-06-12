---
title: Afbeeldingen extraheren uit presentatievormen in Python
linktitle: Afbeelding uit Vorm
type: docs
weight: 90
url: /nl/python-net/extracting-images-from-presentation-shapes/
keywords:
- afbeelding extraheren
- afbeelding ophalen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Afbeeldingen extraheren uit vormen in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Python via .NET - een snelle, code-vriendelijke oplossing."
---
## **Overzicht**

Afbeeldingen in een presentatie kunnen voorkomen in verschillende vormtypen: als gewone afbeeldingskaders, als afbeeldingsvullingen toegepast op vormen, als OLE‑objectvoorbeeldafbeeldingen, als video‑ of audio‑miniatuurafbeeldingen, als zoom‑afbeeldingen, of als afbeeldingen genest in tabel‑, grafiek‑ en SmartArt‑vormen. Aspose.Slides slaat die afbeeldingen op in de presentatie‑afbeeldingscollectie, toegankelijk via de objecten [ImageCollection](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imagecollection/) en [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/).

Als je alleen elke in de presentatie ingebedde afbeeldingsbron wilt exporteren, kun je itereren over `presentation.images`. Dit artikel richt zich op een andere taak: vormen doorlopen om te vinden waar afbeeldingen worden gebruikt op dia's, zodat de opgeslagen bestanden nuttige context kunnen behouden, zoals het diapernummer, de vormpositie en het brontype (afbeeldingskader, vulafbeelding, mediavoorbeeld, OLE‑voorbeeld of zoom‑afbeelding).

{{% alert title="Tip" color="primary" %}}
Gebruik de eigenschap `binary_data` van [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) om de oorspronkelijk gecodeerde afbeeldingsdata en bestandstype te behouden. Gebruik de eigenschap `image` met `save` wanneer je de uitvoer wilt normaliseren naar een specifiek formaat, zoals PNG.
{{% /alert %}}

## **Gedeelde hulpmethoden**

De hulpmethoden hieronder houden de voorbeelden kort. `save_original_image` schrijft de originele ingebedde bytes, kiest een veilige extensie op basis van het MIME‑type en slaat dubbele afbeeldingsbinaire bestanden over door SHA‑256‑hash.

```py
import hashlib
import re
from pathlib import Path

import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.slides.smartart as smartart


def save_original_image(image, output_directory, file_name_base, saved_image_hashes):
    image_data = bytes(image.binary_data)
    image_hash = hashlib.sha256(image_data).hexdigest()
    if image_hash in saved_image_hashes:
        return False

    saved_image_hashes.add(image_hash)
    extension = get_extension_from_content_type(image.content_type)
    file_name = f"{file_name_base}.{extension}"
    output_path = Path(output_directory) / file_name
    output_path.write_bytes(image_data)
    return True


def save_image_as_png(image, output_directory, file_name_base):
    file_name = f"{file_name_base}.png"
    output_path = Path(output_directory) / file_name
    image.image.save(str(output_path), slides.ImageFormat.PNG)


def get_picture_fill_image(fill_format):
    if fill_format is None or fill_format.fill_type != slides.FillType.PICTURE:
        return None

    return fill_format.picture_fill_format.picture.image


def enumerate_shapes(shapes, prefix, include_grouped_shapes):
    for shape_index, shape in enumerate(shapes, start=1):
        shape_name_part = f"{prefix}_shape_{shape_index}"
        yield shape, shape_name_part

        if include_grouped_shapes and isinstance(shape, slides.GroupShape):
            yield from enumerate_shapes(
                shape.shapes,
                shape_name_part,
                include_grouped_shapes)


def get_extension_from_content_type(content_type):
    if not content_type:
        return "bin"

    media_type = content_type.split(";")[0].strip().lower()
    extensions = {
        "image/jpeg": "jpg",
        "image/png": "png",
        "image/gif": "gif",
        "image/bmp": "bmp",
        "image/tiff": "tiff",
        "image/x-emf": "emf",
        "image/emf": "emf",
        "image/x-wmf": "wmf",
        "image/wmf": "wmf",
        "image/svg+xml": "svg",
    }

    if media_type in extensions:
        return extensions[media_type]

    if media_type.startswith("image/"):
        extension = media_type[len("image/"):]
        return make_safe_file_name_part(extension)

    return "bin"


def make_safe_file_name_part(value):
    return re.sub(r'[<>:"/\\|?*]', "_", value)
```

## **Afbeeldingen extraheren uit afbeeldingskaders**

Gebruik deze aanpak voor afbeeldingen die als zelfstandige objecten zijn ingevoegd. Een [PictureFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/pictureframe/) slaat zijn afbeelding op in `picture_format.picture.image`, wat een [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/)‑object retourneert.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "extracted-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **Afbeeldingen extraheren uit met een afbeelding gevulde vormen**

Vormen kunnen een afbeelding als vulling gebruiken. Controleer eerst het vultype van de vorm: als het niet [FillType.PICTURE](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) is, is er geen afbeelding om uit die vulling te halen. Het voorbeeld hieronder behandelt [AutoShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/autoshape/)‑objecten en slaat elke afbeelding op als PNG via de `image`‑eigenschap van [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/).

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "shape-fill-images"
output_directory.mkdir(parents=True, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_image_as_png(image, output_directory, name_part)
```

## **Voorbeeldafbeeldingen extraheren uit OLE‑objectkaders**

Een [OleObjectFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/oleobjectframe/) kan een vervangende afbeelding hebben die PowerPoint gebruikt als voorbeeld van het object op een dia. Deze afbeelding is beschikbaar via `substitute_picture_format.picture.image`. Het extraheren van deze afbeelding levert de voorbeeldafbeelding, niet de ingebedde OLE‑pakketinhoud.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "ole-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Voorbeeldafbeeldingen extraheren uit videokaders**

Een [VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/) kan ook een voorbeeldafbeelding opslaan in `picture_format.picture.image`. Dit is de poster‑ of miniatuurafbeelding die op de dia wordt getoond, niet een frame gedecodeerd uit de videostroom.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "video-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Voorbeeldafbeeldingen extraheren uit audiokaders**

Een [AudioFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/) kan een miniatuur opslaan in `picture_format.picture.image`. Dit is de afbeelding die voor het audio‑object op de dia wordt getoond.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "audio-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Afbeeldingen extraheren uit zoom‑objecten**

[ZoomFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/zoomframe/) en [SectionZoomFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/sectionzoomframe/) vormen kunnen aangepaste afbeeldingen gebruiken. Lees `zoom_image` vanuit het zoom‑kader.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.ZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue

            if isinstance(shape, slides.SectionZoomFrame) and shape.zoom_image is not None:
                file_name_base = f"{name_part}_section_zoom"
                save_original_image(shape.zoom_image, output_directory, file_name_base, saved_image_hashes)
                continue
```

## **Afbeeldingen extraheren uit samenvattings‑zoomkaders**

Een [SummaryZoomFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/summaryzoomframe/) is eveneens een vorm. De sectie‑items kunnen aangepaste afbeeldingen gebruiken, toegankelijk via de `zoom_image`‑eigenschap van elke samenvattings‑zoomsectie.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "summary-zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=False):
            if isinstance(shape, slides.SummaryZoomFrame):
                section_count = len(shape.summary_zoom_collection)
                for section_index in range(section_count):
                    section = shape.summary_zoom_collection[section_index]
                    if section.zoom_image is not None:
                        display_index = section_index + 1
                        file_name_base = f"{name_part}_summary_zoom_{display_index}"
                        save_original_image(section.zoom_image, output_directory, file_name_base, saved_image_hashes)
```

## **Afbeeldingen extraheren uit tabel­vormen**

Een [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/) is een vorm. Afbeeldingen in een tabel worden doorgaans opgeslagen als afbeeldingvullingen in tabelcellen.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "table-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.Table):
                row_count = len(shape.rows)
                column_count = len(shape.columns)
                for row_index in range(row_count):
                    for column_index in range(column_count):
                        cell = shape.rows[row_index][column_index]
                        image = get_picture_fill_image(cell.cell_format.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_cell_{row_index + 1}_{column_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Afbeeldingen extraheren uit grafiek­vormen**

Een [Chart](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/) is een vorm. Het voorbeeld hieronder extrahert een afbeelding uit de afbeeldingvulling van het grafiekgebied.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "chart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, charts.Chart):
                fill_format = shape.fill_format
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    file_name_base = f"{name_part}_chart_area"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Afbeeldingen extraheren uit SmartArt‑vormen**

Een [SmartArt](https://reference.aspose.com/slides/nl/python-net/aspose.slides.smartart/smartart/)‑object is een vorm. Afhankelijk van de SmartArt‑indeling kunnen afbeeldingen worden opgeslagen in de vulvullingen van knooppunt‑opsommingstekens of in de vulformaten van knooppunt­vormen.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "smartart-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, smartart.SmartArt):
                node_count = len(shape.all_nodes)
                for node_index in range(node_count):
                    node = shape.all_nodes[node_index]
                    bullet_image = get_picture_fill_image(node.bullet_fill_format)
                    if bullet_image is not None:
                        file_name_base = f"{name_part}_smartart_node_{node_index + 1}_bullet"
                        save_original_image(bullet_image, output_directory, file_name_base, saved_image_hashes)

                    node_shape_count = len(node.shapes)
                    for node_shape_index in range(node_shape_count):
                        node_shape = node.shapes[node_shape_index]
                        image = get_picture_fill_image(node_shape.fill_format)
                        if image is not None:
                            file_name_base = f"{name_part}_smartart_node_{node_index + 1}_shape_{node_shape_index + 1}"
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
```

## **Afbeeldingen opnemen in gegroepeerde vormen**

Gegroepeerde vormen bevatten hun eigen vormcollecties. De gedeelde helper `enumerate_shapes` heeft een optie `include_grouped_shapes`. Zet deze op `True` wanneer je vormen binnen [GroupShape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/groupshape/)‑objecten wilt onderzoeken. Het voorbeeld hieronder extrahert afbeeldingen uit afbeeldingskaders, met een afbeelding gevulde vormen, OLE‑objectvoorbeelden, videokader‑miniaturen en audiokader‑miniaturen. Om ook tabel‑, grafiek‑, SmartArt‑ en samenvattings‑zoom‑afbeeldingen op te nemen, kun je de gespecialiseerde extractielogica uit de voorgaande secties hergebruiken terwijl je dezelfde recursieve vormtraversie behoudt.

```py
input_path = "sample.pptx"
output_directory = Path.cwd() / "all-shape-images"
output_directory.mkdir(parents=True, exist_ok=True)

saved_image_hashes = set()

with slides.Presentation(input_path) as presentation:
    for slide in presentation.slides:
        slide_prefix = f"slide_{slide.slide_number}"
        for shape, name_part in enumerate_shapes(
                slide.shapes,
                slide_prefix,
                include_grouped_shapes=True):
            if isinstance(shape, slides.OleObjectFrame):
                image = shape.substitute_picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.VideoFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if isinstance(shape, slides.AudioFrame):
                image = shape.picture_format.picture.image
                if image is not None:
                    file_name_base = f"{name_part}_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)

                continue

            if type(shape) is slides.PictureFrame:
                image = shape.picture_format.picture.image
                save_original_image(image, output_directory, name_part, saved_image_hashes)
                continue

            if isinstance(shape, slides.AutoShape):
                image = get_picture_fill_image(shape.fill_format)
                if image is not None:
                    save_original_image(image, output_directory, name_part, saved_image_hashes)
```

## **Randgevallen en praktische aantekeningen**

- **Dubbele afbeeldingen:** Meerdere vormen kunnen naar dezelfde afbeelding verwijzen of verschillende afbeeldingen met identieke bytes hebben. Hash de eigenschap `binary_data` van [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) voordat je bestanden schrijft als je één uitvoerbestand per unieke afbeelding wilt.
- **Originele data vs. geconverteerde uitvoer:** Het opslaan van de eigenschap `binary_data` van [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) behoudt de ingebedde JPEG, PNG, GIF, SVG, EMF of WMF‑data. Het opslaan van de `image`‑eigenschap via `save` is nuttig wanneer je een consistent uitvoerformaat wilt.
- **Niet‑ondersteunde vultypes:** Solide, gradient‑, patroon‑ en geen‑vul‑vormen bevatten geen afbeeldingsvulling. Controleer [FillType](https://reference.aspose.com/slides/nl/python-net/aspose.slides/filltype/) voordat je `picture_fill_format` leest.
- **Gegroepeerde vormen:** De bovenste dia‑vormcollectie maakt geen groepen plat. Inspecteer recursief [GroupShape.shapes](https://reference.aspose.com/slides/nl/python-net/aspose.slides/groupshape/shapes/) wanneer gegroepeerde inhoud van belang is.
- **OLE‑objectvoorbeelden:** Een [OleObjectFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/oleobjectframe/) kan een voorbeeldafbeelding blootstellen via `substitute_picture_format`, maar die afbeelding is alleen het dia‑voorbeeld. Het is niet het ingebedde bestand binnen het OLE‑object.
- **Videokader‑miniaturen:** Een [VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/) kan een voorbeeldafbeelding blootstellen via `picture_format`, maar die afbeelding is alleen de poster die op de dia wordt getoond. Hij wordt niet uit de videostroom gehaald.
- **Audiokader‑miniaturen:** Een [AudioFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/audioframe/) kan een pictogram of miniatuur blootstellen via `picture_format`; het is niet de ingebedde audio‑data.
- **Zoom‑afbeeldingen:** Slide‑zoom, sectie‑zoom en samenvattings‑zoom‑vormen kunnen aangepaste [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/)‑objecten gebruiken via `image`.
- **Geneste vormmodellen:** Tabel‑, grafiek‑ en SmartArt‑objecten implementeren [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/), maar hun afbeeldingen worden vaak opgeslagen in geneste tabelcel‑, grafiekelement‑ of SmartArt‑knooppunt‑opmaakeigenschappen.
- **Bijsneden of getransformeerde afbeeldingen:** Toegang tot [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) geeft je de opgeslagen afbeeldingsresource. Het rendert geen bijsnijden, transparantie, herschikking, rotatie of andere visuele effecten die door de vorm zijn toegepast.

## **FAQ**

**Kan ik de originele afbeelding extraheren zonder bijsnijden, effecten of vormtransformaties?**

Ja. Toegang tot het [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/)‑object en schrijf de eigenschap `binary_data` naar schijf. Dit behoudt de oorspronkelijk gecodeerde afbeelding die in de presentatie is opgeslagen, niet de manier waarop de afbeelding op de dia wordt weergegeven.

**Kan ik elke geëxtraheerde afbeelding exporteren als PNG?**

Ja. Gebruik de `image`‑eigenschap van [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) om een afbeelding‑object te krijgen, en roep vervolgens `save` aan met [ImageFormat.PNG](https://reference.aspose.com/slides/nl/python-net/aspose.slides/imageformat/). Dit converteert de uitvoer en behoudt mogelijk niet het oorspronkelijke bestandstype of de vector‑data.

**Hoe voorkom ik dat dezelfde afbeelding meer dan eens wordt opgeslagen?**

Gebruik een hash van de `binary_data`‑eigenschap van [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) en bewaar de hashes in een set. Als een nieuwe afbeelding een hash heeft die al bestaat, sla die dan over of registreer een extra verwijzing naar het bestaande uitvoerbestand.

**Waarom leveren sommige vormen geen afbeelding?**

Afbeeldingskaders, met een afbeelding gevulde vormen, OLE‑objectkaders, mediakaders, zoom‑kaders, tabellen, grafieken en SmartArt‑objecten kunnen afbeeldingen refereren. Sommige vormtypen leveren afbeeldingen via geneste opmaakobjecten, dus een eenvoudige controle van `picture_format` of `fill_format` van de vorm is niet altijd voldoende.

**Kan ik de miniatuur halen die wordt getoond voor een videokader?**

Ja. Gebruik [VideoFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/videoframe/) en lees `picture_format.picture.image`. Dit extrahert de poster‑afbeelding die is opgeslagen bij het videokader, niet een frame dat uit het videobestand wordt gegenereerd.

**Hoe kan ik bepalen welke vormen een specifieke afbeelding uit de presentatiewaardende collectie gebruiken?**

Aspose.Slides slaat geen omgekeerde koppelingen op van [PPImage](https://reference.aspose.com/slides/nl/python-net/aspose.slides/ppimage/) naar vormen. Bouw tijdens de traversie een mapping: telkens wanneer je een afbeeldingsreferentie vindt, noteer het diapernummer, het vormpad en de afbeelding‑hash of collectie‑item.

**Kan ik afbeeldingen extraheren die ingebed zijn in OLE‑objecten, zoals bijgevoegde documenten?**

Je kunt het dia‑voorbeeld van het OLE‑object extraheren via de eigenschap `substitute_picture_format` van [OleObjectFrame](https://reference.aspose.com/slides/nl/python-net/aspose.slides/oleobjectframe/). Dat voorbeeld is echter niet het ingebedde document zelf. Om afbeeldingen uit het ingebedde bestand te halen, moet je de OLE‑data extraheren en deze inspecteren met gereedschappen die geschikt zijn voor dat bestandstype.