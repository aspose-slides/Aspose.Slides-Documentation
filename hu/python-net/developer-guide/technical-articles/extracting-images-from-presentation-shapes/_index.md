---
title: Képek kinyerése a prezentáció alakzataiból Pythonban
linktitle: Kép az alakzatról
type: docs
weight: 90
url: /hu/python-net/extracting-images-from-presentation-shapes/
keywords:
- kép kinyerése
- kép lekérése
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Képek kinyerése alakzatokból PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Python via .NET segítségével – gyors, kódközeli megoldás."
---
## **Áttekintés**

A képek a prezentációban többféle alakú objektumban jelenhetnek meg: egyszerű képkeretekben, alakzatokhoz alkalmazott képkitöltésként, OLE-objektum előnézeti képeként, videó‑ vagy hangkeret bélyegképeként, nagyítási képként, illetve táblázat, diagram és SmartArt alakzatokba ágyazott képekként. Az Aspose.Slides ezeket a képeket a prezentáció képgyűjteményében tárolja, amely a [ImageCollection](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imagecollection/) és a [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) objektumokon keresztül érhető el.

Ha csak a prezentációba ágyazott összes képernyőforrást szeretné exportálni, iteráljon a `presentation.images` gyűjteményen. Ez a cikk egy másik feladatra összpontosít: alakzatok bejárására, hogy megtalálja, hol használnak képeket a diákon, így a mentett fájlok megtarthatják a hasznos kontextust, például diaszámot, alakzatpozíciót és forrástípust (képkeret, kitöltő kép, média előnézet, OLE előnézet vagy nagyítási kép).

{{% alert title="Tip" color="primary" %}}
Használja a [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) `binary_data` tulajdonságát az eredeti kódolt képadat és fájltípus megőrzéséhez. Az `image` tulajdonságot a `save` metódussal használja, ha a kimenetet egy meghatározott formátumra (például PNG) szeretné normalizálni.
{{% /alert %}}

## **Közös Segítő Metódusok**

Az alábbi segítő metódusok röviden tartják a példákat. A `save_original_image` az eredeti beágyazott bájtokat írja, a MIME‑típus alapján biztonságos kiterjesztést választ, és a SHA‑256 hash alapján kihagyja a duplikált kép binárisokat.

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

## **Képek Kinyerése Képkeretekből**

Ezt a megközelítést használja azokhoz a képekhez, amelyeket önálló objektumként szúrt be. Egy [PictureFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/pictureframe/) a képet a `picture_format.picture.image`‑ben tárolja, amely egy [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) objektumot ad vissza.

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

## **Képek Kinyerése Kép‑Kitöltésű Alakzatokból**

Az alakzatok használhatnak képet kitöltésként. Először ellenőrizze az alakzat kitöltésének típusát: ha nem [FillType.PICTURE](https://reference.aspose.com/slides/hu/python-net/aspose.slides/filltype/) típusú, nincs kép, amit ki lehetne nyerni. Az alábbi példa a [AutoShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/autoshape/) objektumokat kezeli, és minden képet PNG‑ként ment a [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) `image` tulajdonságán keresztül.

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

## **Előnézeti Képek Kinyerése OLE‑Objektum Keretekből**

Egy [OleObjectFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/oleobjectframe/) helyettesítő képet tartalmazhat, amelyet a PowerPoint az objektum előnézeteként használ a dián. Ez a kép a `substitute_picture_format.picture.image`‑ben érhető el. Ennek a képnek a kinyerése az előnézeti képet adja, nem az OLE‑csomag beágyazott tartalmát.

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

## **Előnézeti Képek Kinyerése Videókeretekből**

Egy [VideoFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/) szintén tárolhat előnézeti képet a `picture_format.picture.image`‑ben. Ez a poszter vagy bélyegkép, amely a dián jelenik meg, nem egy a videófolyamból dekódolt keret.

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

## **Előnézeti Képek Kinyerése Hangkeretekből**

Egy [AudioFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/) tárolhat bélyegképet a `picture_format.picture.image`‑ben. Ez a kép jelenik meg a hangobjektus mellett a dián.

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

## **Képek Kinyerése Nagyítási Objektumokból**

A [ZoomFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/zoomframe/) és a [SectionZoomFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/sectionzoomframe/) alakzatok használhatnak egyéni képeket. Olvassa ki a `zoom_image`‑t a nagyítási keretből.

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

## **Képek Kinyerése Összegző Nagyítási Keretekből**

A [SummaryZoomFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/summaryzoomframe/) szintén egy alakzat. Szakaszai egyéni képeket használhatnak, amelyeket az egyes összegző nagyítási szakasz `zoom_image` tulajdonsága tesz elérhetővé.

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

## **Képek Kinyerése Táblázat Alakzatokból**

Egy [Table](https://reference.aspose.com/slides/hu/python-net/aspose.slides/table/) egy alakzat. A táblázatban lévő képek általában képkitöltésként tárolódnak a táblázat celláiban.

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

## **Képek Kinyerése Diagram Alakzatokból**

Egy [Chart](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/) egy alakzat. Az alábbi példa a diagram területének képkitöltéséből nyeri ki a képet.

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

## **Képek Kinyerése SmartArt Alakzatokból**

Egy [SmartArt](https://reference.aspose.com/slides/hu/python-net/aspose.slides.smartart/smartart/) objektum egy alakzat. A SmartArt elrendezésétől függően a képek lehetnek csomópont golyó kitöltésében vagy a csomópont alakzatok kitöltési formátumaiban tárolva.

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

## **Képek Tartalmazása Csoportosított Alakzatokban**

A csoportosított alakzatok saját alakzatgyűjteménnyel rendelkeznek. A megosztott `enumerate_shapes` segítőnek van egy `include_grouped_shapes` opciója. Állítsa `True`‑ra, ha a [GroupShape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/groupshape/) objektumok belső alakzatait is vizsgálni szeretné. Az alábbi példa képeket nyer ki képkeretekből, kép‑kitöltésű alakzatokból, OLE‑objektum előnézetekből, videókeret bélyegképekből és hangkeret bélyegképekből. Ahhoz, hogy a táblázat, diagram, SmartArt és összegző nagyítási képeket is belefoglalja, használja újra a korábbi szekciók speciális kinyerési logikáját, miközben ugyanazt a rekurzív alakzat bejárást tartja.

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

## **Különleges Esetek és Gyakorlati Megjegyzések**

- **Duplikált képek:** Több alakzat is hivatkozhat ugyanarra a képre, vagy azonos bájtokkal rendelkező külön képekre. Hash‑elje a [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) `binary_data` tulajdonságát a fájlok írása előtt, ha egyedi képhez egy kimeneti fájlt szeretne.
- **Eredeti adat vs. konvertált kimenet:** A [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) `binary_data` mentése megtartja a beágyazott JPEG, PNG, GIF, SVG, EMF vagy WMF adatokat. Az `image` tulajdonság `save`‑val való mentése akkor hasznos, ha egységes kimeneti formátumra van szükség.
- **Nem támogatott kitöltéstípusok:** Szilárd, fokozatos, mintázott és üres kitöltésű alakzatok nem tartalmaznak képkitöltést. Ellenőrizze a [FillType](https://reference.aspose.com/slides/hu/python-net/aspose.slides/filltype/) értéket a `picture_fill_format` olvasása előtt.
- **Csoportosított alakzatok:** A felső szintű diák alakzatgyűjteménye nem lapítja le a csoportokat. Rekurzívan vizsgálja a [GroupShape.shapes](https://reference.aspose.com/slides/hu/python-net/aspose.slides/groupshape/shapes/)‑t, ha a csoportos tartalom fontos.
- **OLE‑objektum előnézetek:** Egy [OleObjectFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/oleobjectframe/) a `substitute_picture_format`‑on keresztül mutathat előnézeti képet, de ez csak a dia előnézete, nem a beágyazott fájl.
- **Videókeret bélyegképek:** Egy [VideoFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/) a `picture_format`‑on keresztül adhat előnézeti képet, amely csak a dián megjelenő poszter, nem a videófolyamból származik.
- **Hangkeret bélyegképek:** Egy [AudioFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/audioframe/) ikon vagy bélyegkép lehet a `picture_format`‑on keresztül; ez nem az beágyazott hangadat.
- **Nagyítási képek:** Diánagyítás, szakasznagyítás és összegző nagyítási alakzatok egyéni [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) objektumokat használhatnak az `image`‑en keresztül.
- **Beágyazott alakzatmodellek:** A táblázat, diagram és SmartArt objektumok implementálják a [Shape](https://reference.aspose.com/slides/hu/python-net/aspose.slides/shape/)‑t, de képeik gyakran beágyazott táblacellák, diagramelemek vagy SmartArt csomópontformázási objektumokban tárolódnak.
- **Vágott vagy transzformált képek:** A [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) elérése a tárolt képforrást adja. Nem alkalmazza a vágást, átlátszóságot, átszínezést, forgást vagy egyéb vizuális hatásokat, amelyeket az alakzat alkalmaz.

## **GYIK**

**Kinyerhetem az eredeti képet vágás, hatás vagy alakzattranszformáció nélkül?**

Igen. Hozzáférhet a [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) objektumhoz, és a `binary_data` tulajdonságát írja le a lemezre. Ez megőrzi a prezentációban tárolt eredeti kódolt képet, nem pedig a dián megjelenő változatot.

**Exportálhatom az összes kinyert képet PNG‑ként?**

Igen. Használja a [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) `image` tulajdonságát, majd hívja meg a `save`‑ot a [ImageFormat.PNG](https://reference.aspose.com/slides/hu/python-net/aspose.slides/imageformat/)‑el. Ez a kimenetet PNG‑re konvertálja, de előfordulhat, hogy nem őrzi meg az eredeti fájltípust vagy vektoradatot.

**Hogyan kerülhetem el, hogy ugyanazt a képet többször mentsem?**

Hash‑elje a [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) `binary_data` tulajdonságát, és tárolja a hash‑eket egy halmazban. Ha egy új kép hash‑e már létezik, hagyja ki, vagy rögzítse a meglévő kimeneti fájlra mutató másik hivatkozást.

**Miért nem ad ki kép minden alakzat?**

Képkeretek, kép‑kitöltésű alakzatok, OLE‑objektum keretek, média keretek, nagyítási keretek, táblázatok, diagramok és SmartArt objektumok hivatkozhatnak képekre. Egyes alakzatok képeket rejtett formázó objektumokban tárolnak, így egyszerű `picture_format` vagy `fill_format` ellenőrzés nem mindig elegendő.

**Kinyerhetem a videókerethez tartozó bélyegképet?**

Igen. Használja a [VideoFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/videoframe/) objektumot, és olvassa a `picture_format.picture.image`‑t. Ez a videókerethez tárolt poszterképet adja, nem a videófájlból generált keretet.

**Hogyan határozhatom meg, melyik alakzat használ egy adott képet a prezentáció képgyűjteményéből?**

Az Aspose.Slides nem tárol visszautalásokat a [PPImage](https://reference.aspose.com/slides/hu/python-net/aspose.slides/ppimage/) objektumtól az alakzatok felé. Építsen fel egy leképezést a bejárás során: amikor képhivatkozást talál, rögzítse a diaszámot, az alakzat útvonalát és a kép hash‑ét vagy gyűjteményelemet.

**Kinyerhetem az OLE‑objektumokba ágyazott képeket, például a csatolt dokumentumokból?**

Kinyerheti az OLE‑objektum diaelőnézetét a [OleObjectFrame](https://reference.aspose.com/slides/hu/python-net/aspose.slides/oleobjectframe/) `substitute_picture_format` tulajdonságán keresztül. Azonban ez az előnézet nem maga a beágyazott dokumentum. Az OLE‑objektumban lévő képek kinyeréséhez először ki kell nyernie az OLE‑adatot, majd a megfelelő eszközökkel elemeznie a beágyazott fájlt.