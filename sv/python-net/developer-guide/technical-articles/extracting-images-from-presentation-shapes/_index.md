---
title: Extrahera bilder från presentationsformer i Python
linktitle: Bild från form
type: docs
weight: 90
url: /sv/python-net/extracting-images-from-presentation-shapes/
keywords:
- extrahera bild
- hämta bild
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Extrahera bilder från former i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Python via .NET - snabb, kodvänlig lösning."
---
## **Översikt**

Bilder i en presentation kan visas i flera formtyper: som vanliga bildramar, som bildfyllningar som tillämpas på former, som förhandsgranskningsbilder för OLE‑objekt, som miniatyrbilder för video‑ eller ljudramar, som zoombilder eller som bilder inbäddade i tabell‑, diagram‑ och SmartArt‑former. Aspose.Slides lagrar dessa bilder i presentationens bildsamling, som exponeras via [ImageCollection](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imagecollection/) och [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/)‑objekt.

Om du bara behöver exportera varje bildresurs som är inbäddad i en presentation, iterera genom `presentation.images`. Den här artikeln fokuserar på en annan uppgift: att gå igenom former för att hitta var bilder används på bilder, så att de sparade filerna kan behålla användbar kontext såsom bildnumret, formens position och källtyp (bildram, fyllningsbild, media‑förhandsgranskning, OLE‑förhandsgranskning eller zoom‑bild).

{{% alert title="Tips" color="primary" %}}
Använd egenskapen `binary_data` på [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/) för att bevara de ursprungliga kodade bilddata och filtypen. Använd egenskapen `image` med `save` när du vill normalisera utdata till ett specifikt format såsom PNG.
{{% /alert %}}

## **Delade hjälpfunktioner**

Hjälpfunktionerna nedan håller exemplen korta. `save_original_image` skriver de ursprungliga inbäddade bytena, väljer en säker filändelse från MIME‑typen och hoppar över duplicerade bild‑binärer genom SHA‑256‑hash.

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

## **Extrahera bilder från bildramar**

Använd detta tillvägagångssätt för bilder som infogats som fristående objekt. En [PictureFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/pictureframe/) lagrar sin bild i `picture_format.picture.image`, vilket returnerar ett [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/)‑objekt.

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

## **Extrahera bilder från bildfyllda former**

Former kan använda en bild som sin fyllning. Kontrollera först formens fyllningstyp: om den inte är [FillType.PICTURE](https://reference.aspose.com/slides/sv/python-net/aspose.slides/filltype/), finns ingen bild att extrahera från den fyllningen. Exemplet nedan hanterar [AutoShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/autoshape/)‑objekt och sparar varje bild som PNG via `image`‑egenskapen på [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/).

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

## **Extrahera förhandsgranskningsbilder från OLE‑objektram**

En [OleObjectFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/oleobjectframe/) kan ha en ersättningsbild som PowerPoint använder som objektets förhandsgranskning på en bild. Denna bild är tillgänglig via `substitute_picture_format.picture.image`. Att extrahera denna bild ger dig förhandsgranskningsbilden, inte det inbäddade OLE‑paketinnehållet.

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

## **Extrahera förhandsgranskningsbilder från videoram**

En [VideoFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/videoframe/) kan också lagra en förhandsgranskningsbild i `picture_format.picture.image`. Detta är postern eller miniatyren som visas på bilden, inte en bild avkodad från videoströmmen.

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

## **Extrahera förhandsgranskningsbilder från ljudramar**

En [AudioFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/) kan lagra en miniatyr i `picture_format.picture.image`. Detta är bilden som visas för ljudobjektet på bilden.

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

## **Extrahera bilder från zoom‑objekt**

[ZoomFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/zoomframe/) och [SectionZoomFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/sectionzoomframe/)‑former kan använda anpassade bilder. Läs `zoom_image` från zoom‑ramen.

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

## **Extrahera bilder från sammanfattnings‑zoomramar**

En [SummaryZoomFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/summaryzoomframe/) är också en form. Dess sektionsobjekt kan använda anpassade bilder, som exponeras genom varje sammanfattnings‑zoomsektionens `zoom_image`‑egenskap.

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

## **Extrahera bilder från tabellformer**

En [Table](https://reference.aspose.com/slides/sv/python-net/aspose.slides/table/) är en form. Bilder i en tabell lagras vanligtvis som bildfyllningar i tabellceller.

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

## **Extrahera bilder från diagramformer**

Ett [Chart](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/) är en form. Exemplet nedan extraherar en bild från diagramområdets bildfyllning.

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

## **Extrahera bilder från SmartArt‑former**

Ett [SmartArt](https://reference.aspose.com/slides/sv/python-net/aspose.slides.smartart/smartart/)‑objekt är en form. Beroende på SmartArt‑layout kan bilder lagras i nodernas punkt‑fyllningar eller i fyllningsformaten för nodformer.

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

## **Inkludera bilder i grupperade former**

Grupperade former innehåller sina egna formsamlingar. Den delade hjälpfunktionen `enumerate_shapes` har ett alternativ `include_grouped_shapes`. Ställ in det på `True` när du vill inspektera former inuti [GroupShape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/groupshape/)‑objekt. Exemplet nedan extraherar bilder från bildramar, bildfyllda former, OLE‑objekt‑förhandsgranskningar, videoramin‑miniatyrer och ljudram‑miniatyrer. För att också inkludera tabell-, diagram-, SmartArt‑ och sammanfattnings‑zoombilder, återanvänd den specialiserade extraktionslogiken från de föregående avsnitten samtidigt som du behåller samma rekursiva formtraversering.

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

## **Särskilda fall och praktiska anmärkningar**

- **Duplicerade bilder:** Flera former kan referera till samma bild eller separata bilder med identiska byten. Hasha `binary_data`‑egenskapen på [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/) innan du skriver filer om du vill ha en utdatafil per unik bild.
- **Ursprungliga data vs. konverterad output:** Att spara `binary_data`‑egenskapen på [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/) bevarar den inbäddade JPEG‑, PNG‑, GIF‑, SVG‑, EMF‑ eller WMF‑daten. Att spara `image`‑egenskapen via `save` är användbart när du vill ha ett konsekvent utdataformat.
- **Ej stödda fyllningstyper:** Solid, gradient, pattern och ingen‑fyllning former innehåller ingen bildfyllning. Kontrollera [FillType](https://reference.aspose.com/slides/sv/python-net/aspose.slides/filltype/) innan du läser `picture_fill_format`.
- **Grupperade former:** Den översta bildens formsamling plattar inte till grupper. Inspektera rekursivt [GroupShape.shapes](https://reference.aspose.com/slides/sv/python-net/aspose.slides/groupshape/shapes/) när grupperat innehåll är relevant.
- **OLE‑objekt‑förhandsgranskningar:** En [OleObjectFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/oleobjectframe/) kan exponera en förhandsgranskningsbild via `substitute_picture_format`, men den bilden är endast bildens förhandsgranskning. Det är inte den inbäddade filen i OLE‑objektet.
- **Videoramin‑miniatyrer:** En [VideoFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/videoframe/) kan exponera en förhandsgranskningsbild via `picture_format`, men den bilden är endast postern som visas på bilden. Den extraheras inte från videoströmmen.
- **Ljudram‑miniatyrer:** En [AudioFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/audioframe/) kan exponera en ikon eller miniatyr via `picture_format`; den är inte den inbäddade ljuddatan.
- **Zoom‑bilder:** Slide‑zoom, sektion‑zoom och sammanfattnings‑zoomformer kan använda anpassade [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/)‑objekt via `image`.
- **Inbäddade formmodeller:** Tabell-, diagram- och SmartArt‑objekt implementerar [Shape](https://reference.aspose.com/slides/sv/python-net/aspose.slides/shape/), men deras bilder lagras ofta i inbäddade tabellceller, diagramdelar eller SmartArt‑nodformatobjekt.
- **Beskurna eller transformerade bilder:** Att få åtkomst till [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/) ger dig den lagrade bildresursen. Det renderar inte beskärning, transparens, omfärgning, rotation eller andra visuella effekter som tillämpas av formen.

## **Vanliga frågor**

**Kan jag extrahera den ursprungliga bilden utan beskärning, effekter eller formtransformeringar?**

Ja. Åtkomst till [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/)-objektet och skriv dess `binary_data`‑egenskap till disk. Detta bevarar den ursprungliga kodade bilden som lagras i presentationen, inte hur bilden renderas på bilden.

**Kan jag exportera varje extraherad bild som PNG?**

Ja. Använd `image`‑egenskapen på [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/) för att få ett bildobjekt och anropa sedan `save` med [ImageFormat.PNG](https://reference.aspose.com/slides/sv/python-net/aspose.slides/imageformat/). Detta konverterar utdata och kanske inte bevarar den ursprungliga filtypen eller vektordata.

**Hur undviker jag att spara samma bild mer än en gång?**

Använd en hash av `binary_data`‑egenskapen på [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/) och håll hasharna i en uppsättning. Om en ny bild har en hash som redan finns, hoppa över den eller registrera en annan referens till den befintliga utdatafilen.

**Varför ger vissa former ingen bild?**

Bildramar, bildfyllda former, OLE‑objektramar, media‑ramar, zoom‑ramar, tabeller, diagram och SmartArt‑objekt kan referera till bilder. Vissa formtyper exponerar bilder genom inbäddade formatobjekt, så en enkel kontroll av `picture_format` eller formens `fill_format` är inte alltid tillräcklig.

**Kan jag extrahera miniatyren som visas för ett videoram?**

Ja. Använd [VideoFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/videoframe/) och läs `picture_format.picture.image`. Detta extraherar poster‑bilden som lagras med videoramen, inte en bild genererad från videofilen.

**Hur kan jag avgöra vilka former som använder en specifik bild från presentationens bildsamling?**

Aspose.Slides lagrar inte omvända länkar från [PPImage](https://reference.aspose.com/slides/sv/python-net/aspose.slides/ppimage/) till former. Bygg en karta under traversering: när du hittar en bildreferens, registrera bildnumret, formens sökväg och bildens hash eller samlingsobjekt.

**Kan jag extrahera bilder som är inbäddade i OLE‑objekt, till exempel bifogade dokument?**

Du kan extrahera OLE‑objektets slide‑förhandsgranskning via `substitute_picture_format`‑egenskapen på [OleObjectFrame](https://reference.aspose.com/slides/sv/python-net/aspose.slides/oleobjectframe/). Den förhandsgranskningen är dock inte det inbäddade dokumentet självt. För att extrahera bilder från den inbäddade filen, extrahera OLE‑data och inspektera den med verktyg för den filtypen.