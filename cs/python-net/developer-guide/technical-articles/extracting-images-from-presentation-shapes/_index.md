---
title: Extrahování obrázků z tvarů v prezentaci v Pythonu
linktitle: Obrázek z tvaru
type: docs
weight: 90
url: /cs/python-net/extracting-images-from-presentation-shapes/
keywords:
- extrahovat obrázek
- získat obrázek
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Extrahujte obrázky z tvarů v PowerPoint a OpenDocument prezentacích pomocí Aspose.Slides pro Python via .NET – rychlé, kódu přátelské řešení."
---
## **Přehled**

Obrázky v prezentaci se mohou objevit v několika typech tvarů: jako obyčejné rámečky obrázků, jako výplně obrázků aplikované na tvary, jako náhledové obrázky OLE objektů, jako miniatury video‑ nebo audio‑rámců, jako zoom obrázky nebo jako obrázky vnořené uvnitř tabulek, grafů a tvarů SmartArt. Aspose.Slides ukládá tyto obrázky do kolekce obrázků prezentace, která je dostupná přes objekty [ImageCollection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imagecollection/) a [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/).

Pokud potřebujete jen exportovat všechny obrázkové zdroje vložené v prezentaci, projděte `presentation.images`. Tento článek se zaměřuje na jiný úkol: procházet tvary, aby se zjistilo, kde jsou obrázky použity na snímcích, takže uložené soubory mohou zachovat užitečný kontext, jako je číslo snímku, pozice tvaru a typ zdroje (rámec obrázku, výplň obrázkem, náhled média, náhled OLE nebo zoom obrázek).

{{% alert title="Tip" color="primary" %}}
Použijte vlastnost `binary_data` objektu [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) pro zachování původních kódovaných dat obrázku a typu souboru. Použijte vlastnost `image` s metodou `save`, když chcete normalizovat výstup do konkrétního formátu, například PNG.
{{% /alert %}}

## **Sdílené pomocné metody**

Níže uvedené pomocné metody udržují příklady stručné. `save_original_image` zapisuje původní vložené bajty, volí bezpečnou příponu podle MIME typu a přeskočí duplicitní binární data obrázku podle SHA‑256 hashe.

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

## **Extrahování obrázků z rámečků obrázků**

Použijte tento postup pro obrázky vložené jako samostatné objekty. [PictureFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/pictureframe/) ukládá svůj obrázek v `picture_format.picture.image`, který vrací objekt [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/).

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

## **Extrahování obrázků z tvarů vyplněných obrázkem**

Tvary mohou používat obrázek jako výplň. Nejprve zkontrolujte typ výplně tvaru: pokud není [FillType.PICTURE](https://reference.aspose.com/slides/cs/python-net/aspose.slides/filltype/), neexistuje obrázek, který by se dalo z výplně extrahovat. Níže uvedený příklad pracuje s objekty [AutoShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/autoshape/) a ukládá každý obrázek jako PNG pomocí vlastnosti `image` objektu [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/).

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

## **Extrahování náhledových obrázků z OLE objektových rámců**

[OleObjectFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/oleobjectframe/) může mít substituční obrázek, který PowerPoint používá jako náhled objektu na snímku. Tento obrázek je dostupný přes `substitute_picture_format.picture.image`. Extrahování tohoto obrázku vám poskytne náhled, nikoli vložený obsah OLE balíčku.

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

## **Extrahování náhledových obrázků z video rámců**

[VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) může také ukládat náhledový obrázek v `picture_format.picture.image`. Jedná se o plakát nebo miniaturu zobrazovanou na snímku, nikoli o snímek dekódovaný z video proudu.

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

## **Extrahování náhledových obrázků z audio rámců**

[AudioFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/) může ukládat miniaturu v `picture_format.picture.image`. Jedná se o obrázek zobrazený pro audio objekt na snímku.

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

## **Extrahování obrázků z zoom objektů**

Tvary [ZoomFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/zoomframe/) a [SectionZoomFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/sectionzoomframe/) mohou používat vlastní obrázky. Přečtěte `zoom_image` ze zoom rámce.

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

## **Extrahování obrázků ze souhrnných zoom rámců**

[SummaryZoomFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/summaryzoomframe/) je také tvarem. Jeho položky sekcí mohou používat vlastní obrázky, které jsou přístupné přes vlastnost `zoom_image` každé položky souhrnného zoomu.

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

## **Extrahování obrázků z tvarů tabulky**

[Table](https://reference.aspose.com/slides/cs/python-net/aspose.slides/table/) je tvarem. Obrázky v tabulce jsou obvykle uloženy jako výplně obrázkem v buňkách tabulky.

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

## **Extrahování obrázků z tvarů grafu**

[Chart](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/) je tvarem. Níže uvedený příklad extrahuje obrázek z výplně obrázkem oblasti grafu.

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

## **Extrahování obrázků z tvarů SmartArt**

Objekt [SmartArt](https://reference.aspose.com/slides/cs/python-net/aspose.slides.smartart/smartart/) je tvarem. V závislosti na rozvržení SmartArt mohou být obrázky uloženy ve výplních teček uzlů nebo ve formátech výplní tvarů uzlů.

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

## **Zahrnutí obrázků uvnitř seskupených tvarů**

Seskupené tvary obsahují vlastní kolekce tvarů. Sdílený pomocník `enumerate_shapes` má možnost `include_grouped_shapes`. Nastavte ji na `True`, pokud chcete prozkoumat tvary uvnitř objektů [GroupShape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/groupshape/). Níže uvedený příklad extrahuje obrázky z rámečků obrázků, tvarů vyplněných obrázkem, náhledů OLE objektů, miniatur video rámců a miniatur audio rámců. Pro zahrnutí obrázků tabulek, grafů, SmartArt a souhrnných zoomů využijte specializovanou logiku extrakce z předchozích sekcí při zachování stejného rekurzivního procházení tvarů.

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

## **Hraniční případy a praktické poznámky**

- **Duplicitní obrázky:** Více tvarů může odkazovat na stejný obrázek nebo na různé obrázky se stejnými bajty. Vytvořte hash vlastnosti `binary_data` objektu [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) před zápisem souborů, pokud chcete jeden výstupní soubor na unikátní obrázek.
- **Původní data vs. konvertovaný výstup:** Uložení vlastnosti `binary_data` objektu [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) zachová vložená data JPEG, PNG, GIF, SVG, EMF nebo WMF. Uložení vlastnosti `image` pomocí `save` je užitečné, když chcete jednotný výstupní formát.
- **Nepodporované typy výplní:** Tvary se solidní, gradientní, vzorovou nebo žádnou výplní neobsahují obrázek. Zkontrolujte [FillType](https://reference.aspose.com/slides/cs/python-net/aspose.slides/filltype/) před čtením `picture_fill_format`.
- **Seskupené tvary:** Kolekce tvarů na úrovni snímku neflattenuje skupiny. Rekurzivně prozkoumejte [GroupShape.shapes](https://reference.aspose.com/slides/cs/python-net/aspose.slides/groupshape/shapes/), pokud je seskupený obsah relevantní.
- **Náhledy OLE objektů:** [OleObjectFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/oleobjectframe/) může vystavit náhledový obrázek přes `substitute_picture_format`, ale tento obrázek je jen náhled snímku. Není to vložený soubor uvnitř OLE objektu.
- **Miniatury video rámců:** [VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) může vystavit náhledový obrázek přes `picture_format`, ale tento obrázek je jen plakát zobrazovaný na snímku. Není extrahován z video proudu.
- **Miniatury audio rámců:** [AudioFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/audioframe/) může vystavit ikonu nebo miniaturu přes `picture_format`; není to vložený audio soubor.
- **Zoom obrázky:** Tvary slide zoom, section zoom a summary zoom mohou používat vlastní objekty [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) přes `image`.
- **Vnořené modely tvarů:** Objektům Table, Chart a SmartArt implementuje [Shape](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shape/), ale jejich obrázky jsou často uloženy v vnořených buňkách tabulky, elementech grafu nebo formátovacích objektech uzlů SmartArt.
- **Ořezané nebo transformované obrázky:** Přístup k [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) vám poskytne uložený obrazový zdroj. Neprovádí ořez, průhlednost, přeobarvení, rotaci ani jiné vizuální efekty aplikované tvarem.

## **Časté dotazy**

**Mohu extrahovat původní obrázek bez ořezu, efektů nebo transformací tvaru?**

Ano. Přistupte k objektu [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) a zapište jeho vlastnost `binary_data` na disk. Tím zachováte původní kódovaný obrázek uložený v prezentaci, ne způsob, jak je obrázek vykreslen na snímku.

**Mohu exportovat každý extrahovaný obrázek jako PNG?**

Ano. Použijte vlastnost `image` objektu [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) k získání obrazového objektu a poté zavolejte `save` s [ImageFormat.PNG](https://reference.aspose.com/slides/cs/python-net/aspose.slides/imageformat/). To převádí výstup a nemusí zachovat původní typ souboru nebo vektorová data.

**Jak zabránit ukládání stejných obrázků vícekrát?**

Vytvořte hash vlastnosti `binary_data` objektu [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) a udržujte hashe v množině. Pokud nový obrázek má hash, který již existuje, přeskočte jej nebo zaznamenejte další odkaz na existující výstupní soubor.

**Proč některé tvary nevytvářejí obrázek?**

Rámečky obrázků, tvary vyplněné obrázkem, OLE objektové rámečky, mediální rámečky, zoom rámečky, tabulky, grafy a SmartArt objekty mohou odkazovat na obrázky. Některé typy tvarů vystavují obrázky skrze vnořené formátovací objekty, takže jednoduchá kontrola `picture_format` nebo `fill_format` tvaru není vždy dostatečná.

**Mohu extrahovat miniaturu zobrazenou pro video rámec?**

Ano. Použijte [VideoFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/videoframe/) a přečtěte `picture_format.picture.image`. Tím získáte plakát uložený s video rámcem, ne snímek vygenerovaný z video souboru.

**Jak zjistit, které tvary používají konkrétní obrázek z kolekce obrázků prezentace?**

Aspose.Slides neukládá reverzní odkazy z [PPImage](https://reference.aspose.com/slides/cs/python-net/aspose.slides/ppimage/) na tvary. Během procházení vytvořte mapování: kdykoli najdete odkaz na obrázek, zaznamenejte číslo snímku, cestu tvaru a hash obrázku nebo položku kolekce.

**Mohu extrahovat obrázky vložené uvnitř OLE objektů, například připojené dokumenty?**

Můžete extrahovat náhled OLE objektu ze vlastnosti `substitute_picture_format` objektu [OleObjectFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/oleobjectframe/). Tento náhled však není samotný vložený dokument. Pro extrahování obrázků zevnitř vloženého souboru nejprve extrahujte OLE data a prozkoumejte je pomocí nástrojů určených pro daný typ souboru.