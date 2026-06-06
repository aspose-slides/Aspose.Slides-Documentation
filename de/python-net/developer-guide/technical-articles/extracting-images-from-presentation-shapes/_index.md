---
title: Bilder aus Präsentationsformen in Python extrahieren
linktitle: Bild aus Form
type: docs
weight: 90
url: /de/python-net/extracting-images-from-presentation-shapes/
keywords:
- Bild extrahieren
- Bild abrufen
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Extrahieren Sie Bilder aus Formen in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für Python via .NET - schnelle, code-freundliche Lösung."
---
## **Übersicht**

Bilder in einer Präsentation können in mehreren Formtyp­en vorkommen: als gewöhnliche Bildrahmen, als Bildfüllungen, die auf Formen angewendet werden, als OLE‑Objekt‑Vorschaubilder, als Miniaturansichten von Video‑ oder Audio‑Frames, als Zoom‑Bilder oder als in Tabellen, Diagrammen und SmartArt‑Formen verschachtelte Bilder. Aspose.Slides speichert diese Bilder in der Präsentations‑Bilder‑Sammlung, die über die Objekte [ImageCollection](https://reference.aspose.com/slides/de/python-net/aspose.slides/imagecollection/) und [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/) bereitgestellt wird.

Wenn Sie nur jede in einer Präsentation eingebettete Bild‑Ressource exportieren möchten, iterieren Sie über `presentation.images`. Dieser Artikel konzentriert sich auf eine andere Aufgabe: das Durchlaufen von Formen, um herauszufinden, wo Bilder in Folien verwendet werden, sodass die gespeicherten Dateien nützlichen Kontext wie Foliennummer, Formposition und Quelltyp (Bildrahmen, Füllungsbild, Medien‑Vorschau, OLE‑Vorschau oder Zoom‑Bild) behalten können.

{{% alert title="Tip" color="primary" %}}

Verwenden Sie die `binary_data`‑Eigenschaft von [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/), um die ursprünglich codierten Bilddaten und den Dateityp zu erhalten. Verwenden Sie die `image`‑Eigenschaft mit `save`, wenn Sie die Ausgabe in ein bestimmtes Format wie PNG normalisieren möchten.

{{% /alert %}}

## **Gemeinsame Hilfsmethoden**

Die Hilfsmethoden unten halten die Beispiele kurz. `save_original_image` schreibt die original eingebetteten Bytes, wählt eine sichere Erweiterung aus dem MIME‑Typ und überspringt doppelte Bild‑Binärdaten anhand des SHA‑256‑Hashes.

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

## **Bilder aus Bildrahmen extrahieren**

Verwenden Sie diesen Ansatz für Bilder, die als eigenständige Objekte eingefügt wurden. Ein [PictureFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/pictureframe/) speichert sein Bild in `picture_format.picture.image`, das ein [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/)‑Objekt zurückgibt.

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

## **Bilder aus bildgefüllten Formen extrahieren**

Formen können ein Bild als Füllung verwenden. Prüfen Sie zuerst den Fülltyp der Form: Wenn es nicht [FillType.PICTURE](https://reference.aspose.com/slides/de/python-net/aspose.slides/filltype/) ist, gibt es kein Bild zum Extrahieren aus dieser Füllung. Das Beispiel unten verarbeitet [AutoShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/autoshape/)‑Objekte und speichert jedes Bild als PNG über die `image`‑Eigenschaft von [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/).

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

## **Vorschaubilder aus OLE‑Objekt‑Frames extrahieren**

Ein [OleObjectFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/oleobjectframe/) kann ein Ersatzbild haben, das PowerPoint als Vorschau des Objekts auf einer Folie verwendet. Dieses Bild ist über `substitute_picture_format.picture.image` verfügbar. Das Extrahieren dieses Bildes liefert das Vorschaubild, nicht den eingebetteten OLE‑Paket‑Inhalt.

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

## **Vorschaubilder aus Video‑Frames extrahieren**

Ein [VideoFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/) kann ebenfalls ein Vorschaubild in `picture_format.picture.image` speichern. Dies ist das Poster oder die Miniatur, die auf der Folie angezeigt wird, nicht ein Frame, der aus dem Videostream dekodiert wurde.

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

## **Vorschaubilder aus Audio‑Frames extrahieren**

Ein [AudioFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/audioframe/) kann ein Miniaturbild in `picture_format.picture.image` speichern. Dies ist das Bild, das für das Audio‑Objekt auf der Folie angezeigt wird.

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

## **Bilder aus Zoom‑Objekten extrahieren**

[ZoomFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/zoomframe/) und [SectionZoomFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/sectionzoomframe/) Formen können benutzerdefinierte Bilder verwenden. Lesen Sie `zoom_image` aus dem Zoom‑Frame.

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

## **Bilder aus Summary‑Zoom‑Frames extrahieren**

Ein [SummaryZoomFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/summaryzoomframe/) ist ebenfalls eine Form. Seine Abschnitts‑Elemente können benutzerdefinierte Bilder verwenden, die über die `zoom_image`‑Eigenschaft jedes Summary‑Zoom‑Abschnitts bereitgestellt werden.

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

## **Bilder aus Tabellenformen extrahieren**

Eine [Table](https://reference.aspose.com/slides/de/python-net/aspose.slides/table/) ist eine Form. Bilder in einer Tabelle werden normalerweise als Bildfüllungen in Tabellenzellen gespeichert.

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

## **Bilder aus Diagrammformen extrahieren**

Ein [Chart](https://reference.aspose.com/slides/de/python-net/aspose.slides.charts/chart/) ist eine Form. Das Beispiel unten extrahiert ein Bild aus der Bildfüllung des Diagrammbereichs.

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

## **Bilder aus SmartArt‑Formen extrahieren**

Ein [SmartArt](https://reference.aspose.com/slides/de/python-net/aspose.slides.smartart/smartart/)‑Objekt ist eine Form. Je nach SmartArt‑Layout können Bilder in den Aufzählungs‑Füllungen von Knoten oder in den Füllformaten von Knotenformen gespeichert sein.

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

## **Bilder innerhalb gruppierter Formen einbeziehen**

Gruppierte Formen enthalten eigene Form‑Sammlungen. Die gemeinsam genutzte Hilfsmethode `enumerate_shapes` verfügt über die Option `include_grouped_shapes`. Setzen Sie sie auf `True`, wenn Sie Formen innerhalb von [GroupShape](https://reference.aspose.com/slides/de/python-net/aspose.slides/groupshape/)‑Objekten untersuchen möchten. Das Beispiel unten extrahiert Bilder aus Bildrahmen, bildgefüllten Formen, OLE‑Objekt‑Vorschaubildern, Video‑Frame‑Miniaturen und Audio‑Frame‑Miniaturen. Um zusätzlich Bilder aus Tabellen, Diagrammen, SmartArt und Summary‑Zoom‑Formen zu berücksichtigen, verwenden Sie die spezialisierte Extraktionslogik aus den vorherigen Abschnitten bei gleichzeitigem rekursivem Durchlaufen der Formen.

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

## **Randfälle und praktische Hinweise**

- **Doppelte Bilder:** Mehrere Formen können auf dasselbe Bild verweisen oder separate Bilder mit identischen Bytes enthalten. Erstellen Sie einen Hash der `binary_data`‑Eigenschaft von [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/), bevor Sie Dateien schreiben, wenn Sie pro eindeutigem Bild nur eine Ausgabedatei benötigen.
- **Originaldaten vs. konvertierte Ausgabe:** Das Speichern der `binary_data`‑Eigenschaft von [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/) bewahrt die eingebetteten JPEG‑, PNG‑, GIF‑, SVG‑, EMF‑ oder WMF‑Daten. Das Speichern der `image`‑Eigenschaft über `save` ist sinnvoll, wenn Sie ein konsistentes Ausgabeformat wünschen.
- **Nicht unterstützte Fülltypen:** Vollton-, Farbverlauf‑, Muster‑ und Keine‑Füllungs‑Formen enthalten keine Bildfüllung. Prüfen Sie [FillType](https://reference.aspose.com/slides/de/python-net/aspose.slides/filltype/), bevor Sie `picture_fill_format` lesen.
- **Gruppierte Formen:** Die oberste Form‑Sammlung einer Folie flacht Gruppen nicht ab. Untersuchen Sie rekursiv [GroupShape.shapes](https://reference.aspose.com/slides/de/python-net/aspose.slides/groupshape/shapes/), wenn gruppierter Inhalt von Bedeutung ist.
- **OLE‑Objekt‑Vorschauen:** Ein [OleObjectFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/oleobjectframe/) kann über `substitute_picture_format` ein Vorschaubild bereitstellen, aber dieses Bild ist nur die Folien‑Vorschau. Es ist nicht die eingebettete Datei im OLE‑Objekt.
- **Video‑Frame‑Miniaturen:** Ein [VideoFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/) kann über `picture_format` ein Vorschaubild bereitstellen, das jedoch nur das auf der Folie angezeigte Poster ist. Es wird nicht aus dem Videostream extrahiert.
- **Audio‑Frame‑Miniaturen:** Ein [AudioFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/audioframe/) kann über `picture_format` ein Symbol oder eine Miniatur bereitstellen; es ist nicht das eingebettete Audiodaten‑Material.
- **Zoom‑Bilder:** Folien‑Zoom-, Abschnitts‑Zoom‑ und Summary‑Zoom‑Formen können benutzerdefinierte [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/)‑Objekte über `image` verwenden.
- **Verschachtelte Form‑Modelle:** Tabellen-, Diagramm‑ und SmartArt‑Objekte implementieren [Shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/), aber ihre Bilder werden häufig in verschachtelten Tabellenzellen, Diagrammelementen oder SmartArt‑Knoten‑Formatierungsobjekten gespeichert.
- **Zugeschnittene oder transformierte Bilder:** Der Zugriff auf [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/) liefert die gespeicherte Bildressource. Es werden keine Zuschneidungen, Transparenz, Nachfärbungen, Drehungen oder andere visuelle Effekte, die von der Form angewendet werden, gerendert.

## **FAQ**

**Kann ich das Originalbild ohne Zuschneiden, Effekte oder Form‑Transformationen extrahieren?**

Ja. Greifen Sie auf das [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/)‑Objekt zu und schreiben Sie seine `binary_data`‑Eigenschaft auf die Festplatte. Dadurch bleibt das ursprünglich codierte Bild in der Präsentation erhalten, nicht die Art, wie das Bild auf der Folie gerendert wird.

**Kann ich jedes extrahierte Bild als PNG exportieren?**

Ja. Verwenden Sie die `image`‑Eigenschaft von [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/), um ein Bildobjekt zu erhalten, und rufen Sie dann `save` mit [ImageFormat.PNG](https://reference.aspose.com/slides/de/python-net/aspose.slides/imageformat/) auf. Dies konvertiert die Ausgabe und kann den ursprünglichen Dateityp oder Vektordaten nicht erhalten.

**Wie vermeide ich, dass dasselbe Bild mehr als einmal gespeichert wird?**

Verwenden Sie einen Hash der `binary_data`‑Eigenschaft von [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/) und bewahren Sie die Hashes in einer Menge auf. Wenn ein neues Bild einen bereits vorhandenen Hash hat, überspringen Sie es oder verzeichnen Sie eine weitere Referenz zur bestehenden Ausgabedatei.

**Warum liefern einige Formen kein Bild?**

Bildrahmen, bildgefüllte Formen, OLE‑Objekt‑Frames, Medien‑Frames, Zoom‑Frames, Tabellen, Diagramme und SmartArt‑Objekte können Bilder referenzieren. Einige Formtypen geben Bilder über verschachtelte Formatierungsobjekte frei, sodass eine einfache Prüfung von `picture_format` oder `fill_format` nicht immer ausreicht.

**Kann ich das für ein Video‑Frame angezeigte Miniaturbild extrahieren?**

Ja. Verwenden Sie [VideoFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/videoframe/) und lesen Sie `picture_format.picture.image`. Damit wird das Poster‑Bild extrahiert, das mit dem Video‑Frame gespeichert ist, nicht ein Frame, das aus der Videodatei generiert wird.

**Wie kann ich feststellen, welche Formen ein bestimmtes Bild aus der Präsentations‑Bilder‑Sammlung verwenden?**

Aspose.Slides speichert keine Rückverknüpfungen von [PPImage](https://reference.aspose.com/slides/de/python-net/aspose.slides/ppimage/) zu Formen. Erstellen Sie während der Traversierung eine Zuordnung: Wann immer Sie eine Bildreferenz finden, notieren Sie Foliennummer, Formpfad und Bild‑Hash oder Sammlungs‑Eintrag.

**Kann ich Bilder extrahieren, die in OLE‑Objekten eingebettet sind, z. B. angehängte Dokumente?**

Sie können die Folien‑Vorschau des OLE‑Objekts aus der `substitute_picture_format`‑Eigenschaft von [OleObjectFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/oleobjectframe/) extrahieren. Diese Vorschau ist jedoch nicht das eingebettete Dokument selbst. Um Bilder aus der eingebetteten Datei zu extrahieren, holen Sie die OLE‑Daten heraus und prüfen sie mit Werkzeugen für den jeweiligen Dateityp.