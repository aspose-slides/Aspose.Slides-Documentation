---
title: "Estrai Immagini dalle Forme della Presentazione in Python"
linktitle: "Immagine da Forma"
type: docs
weight: 90
url: /it/python-net/extracting-images-from-presentation-shapes/
keywords:
  - "estrai immagine"
  - "recupera immagine"
  - "PowerPoint"
  - "OpenDocument"
  - "presentazione"
  - "Python"
  - "Aspose.Slides"
description: "Estrai immagini dalle forme in presentazioni PowerPoint e OpenDocument con Aspose.Slides per Python via .NET - soluzione rapida e orientata al codice."
---
## **Panoramica**

Le immagini in una presentazione possono comparire in diversi tipi di forma: come normali riquadri immagine, come riempimenti immagine applicati alle forme, come anteprime di oggetti OLE, come miniature di frame video o audio, come immagini di zoom o come immagini annidate all'interno di forme di tabella, grafico e SmartArt. Aspose.Slides archivia queste immagini nella collezione di immagini della presentazione, esposta tramite gli oggetti [ImageCollection](https://reference.aspose.com/slides/it/python-net/aspose.slides/imagecollection/) e [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/).

Se devi solo esportare tutte le risorse immagine incorporate in una presentazione, itera su `presentation.images`. Questo articolo si concentra su un compito diverso: attraversare le forme per trovare dove le immagini sono utilizzate nelle diapositive, in modo che i file salvati possano conservare informazioni utili come il numero della diapositiva, la posizione della forma e il tipo di origine (riquadri immagine, immagine di riempimento, anteprima multimediale, anteprima OLE o immagine di zoom).

{{% alert title="Tip" color="primary" %}}
Utilizza la proprietà `binary_data` di [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) per preservare i dati immagine codificati originali e il tipo di file. Usa la proprietà `image` con `save` quando desideri normalizzare l'output in un formato specifico come PNG.
{{% /alert %}}

## **Metodi di supporto condivisi**

I metodi di supporto seguenti mantengono gli esempi brevi. `save_original_image` scrive i byte incorporati originali, sceglie un'estensione sicura dal tipo MIME e ignora i binari immagine duplicati tramite hash SHA-256.

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

## **Estrai Immagini da Riquadri Immagine**

Utilizza questo approccio per le immagini inserite come oggetti autonomi. Un [PictureFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/pictureframe/) memorizza la sua immagine in `picture_format.picture.image`, che restituisce un oggetto [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/).

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

## **Estrai Immagini da Forme Riempite con Immagine**

Le forme possono utilizzare un'immagine come riempimento. Controlla prima il tipo di riempimento della forma: se non è [FillType.PICTURE](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/), non c'è alcuna immagine da estrarre da quel riempimento. L'esempio sotto gestisce gli oggetti [AutoShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/autoshape/) e salva ogni immagine come PNG tramite la proprietà `image` di [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/).

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

## **Estrai Immagini di Anteprima da Riquadri Oggetto OLE**

Un [OleObjectFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/oleobjectframe/) può avere un'immagine sostitutiva che PowerPoint utilizza come anteprima dell'oggetto su una diapositiva. Questa immagine è disponibile tramite `substitute_picture_format.picture.image`. Estrarre questa immagine fornisce l'anteprima, non il contenuto del pacchetto OLE incorporato.

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

## **Estrai Immagini di Anteprima da Riquadri Video**

Un [VideoFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/) può anche memorizzare un'immagine di anteprima in `picture_format.picture.image`. Questa è l'immagine di copertina o miniatura mostrata sulla diapositiva, non un fotogramma decodificato dallo stream video.

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

## **Estrai Immagini di Anteprima da Riquadri Audio**

Un [AudioFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/) può memorizzare una miniatura in `picture_format.picture.image`. Questa è l'immagine mostrata per l'oggetto audio sulla diapositiva.

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

## **Estrai Immagini da Oggetti Zoom**

[ZoomFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/zoomframe/) e le forme [SectionZoomFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/sectionzoomframe/) possono utilizzare immagini personalizzate. Leggi `zoom_image` dal riquadro zoom.

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

## **Estrai Immagini da Riquadri Summary Zoom**

Un [SummaryZoomFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/summaryzoomframe/) è anche una forma. I suoi elementi di sezione possono utilizzare immagini personalizzate, esposte tramite la proprietà `zoom_image` di ciascuna sezione di summary zoom.

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

## **Estrai Immagini da Forme Tabella**

Una [Table](https://reference.aspose.com/slides/it/python-net/aspose.slides/table/) è una forma. Le immagini in una tabella sono solitamente archiviate come riempimenti immagine nelle celle della tabella.

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

## **Estrai Immagini da Forme Grafico**

Un [Chart](https://reference.aspose.com/slides/it/python-net/aspose.slides.charts/chart/) è una forma. L'esempio sotto estrae un'immagine dal riempimento immagine dell'area del grafico.

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

## **Estrai Immagini da Forme SmartArt**

Un oggetto [SmartArt](https://reference.aspose.com/slides/it/python-net/aspose.slides.smartart/smartart/) è una forma. A seconda del layout di SmartArt, le immagini possono essere archiviate nei riempimenti dei puntini dei nodi o nei formati di riempimento delle forme dei nodi.

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

## **Includi Immagini All'interno di Forme Raggruppate**

Le forme raggruppate contengono le proprie collezioni di forme. L'helper condiviso `enumerate_shapes` ha un'opzione `include_grouped_shapes`. Impostala su `True` quando desideri ispezionare le forme all'interno degli oggetti [GroupShape](https://reference.aspose.com/slides/it/python-net/aspose.slides/groupshape/). L'esempio sotto estrae immagini da riquadri immagine, forme riempite con immagine, anteprime di oggetti OLE, miniature di riquadri video e miniature di riquadri audio. Per includere anche le immagini di tabelle, grafici, SmartArt e summary zoom, riutilizza la logica di estrazione specializzata delle sezioni precedenti mantenendo la stessa traversata ricorsiva delle forme.

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

## **Casi Limite e Note Pratiche**

- **Immagini duplicate:** più forme possono fare riferimento alla stessa immagine o a immagini separate con byte identici. Calcola l'hash della proprietà `binary_data` di [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) prima di scrivere i file se desideri un file di output per ogni immagine unica.
- **Dati originali vs. output convertito:** salvare la proprietà `binary_data` di [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) mantiene i dati JPEG, PNG, GIF, SVG, EMF o WMF incorporati. Salvare la proprietà `image` tramite `save` è utile quando vuoi un formato di output coerente.
- **Tipi di riempimento non supportati:** le forme a tinta unita, sfumate, a motivo e senza riempimento non contengono un riempimento immagine. Controlla [FillType](https://reference.aspose.com/slides/it/python-net/aspose.slides/filltype/) prima di leggere `picture_fill_format`.
- **Forme raggruppate:** la collezione di forme della diapositiva di livello superiore non appiattisce i gruppi. Ispeziona ricorsivamente [GroupShape.shapes](https://reference.aspose.com/slides/it/python-net/aspose.slides/groupshape/shapes/) quando il contenuto raggruppato è rilevante.
- **Anteprime oggetti OLE:** un [OleObjectFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/oleobjectframe/) può esporre un'immagine di anteprima tramite `substitute_picture_format`, ma quell'immagine è solo l'anteprima della diapositiva. Non è il file incorporato all'interno dell'oggetto OLE.
- **Miniature dei frame video:** un [VideoFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/) può esporre un'immagine di anteprima tramite `picture_format`, ma quell'immagine è solo la copertina mostrata sulla diapositiva. Non è estratta dallo stream video.
- **Miniature dei frame audio:** un [AudioFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/audioframe/) può esporre un'icona o miniatura tramite `picture_format`; non sono i dati audio incorporati.
- **Immagini di zoom:** le forme di zoom della diapositiva, di sezione e summary zoom possono utilizzare oggetti [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) personalizzati tramite `image`.
- **Modelli di forma annidati:** gli oggetti Table, Chart e SmartArt implementano [Shape](https://reference.aspose.com/slides/it/python-net/aspose.slides/shape/), ma le loro immagini sono spesso archiviate in oggetti nidificati di celle di tabella, elementi di grafico o formattazione dei nodi SmartArt.
- **Immagini ritagliate o trasformate:** accedere a [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) fornisce la risorsa immagine memorizzata. Non rende il ritaglio, la trasparenza, la ricolorazione, la rotazione o altri effetti visivi applicati dalla forma.

## **FAQ**

**Posso estrarre l'immagine originale senza ritagli, effetti o trasformazioni della forma?**

Sì. Accedi all'oggetto [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) e scrivi la sua proprietà `binary_data` su disco. Questo preserva l'immagine codificata originale memorizzata nella presentazione, non il modo in cui l'immagine è renderizzata sulla diapositiva.

**Posso esportare ogni immagine estratta come PNG?**

Sì. Usa la proprietà `image` di [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) per ottenere un oggetto immagine, quindi chiama `save` con [ImageFormat.PNG](https://reference.aspose.com/slides/it/python-net/aspose.slides/imageformat/). Questo converte l'output e potrebbe non preservare il tipo di file originale o i dati vettoriali.

**Come posso evitare di salvare più volte la stessa immagine?**

Utilizza un hash della proprietà `binary_data` di [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) e conserva gli hash in un set. Se una nuova immagine ha un hash già presente, salta l'operazione o registra un'altra referenza al file di output esistente.

**Perché alcune forme non producono un'immagine?**

I riquadri immagine, le forme riempite con immagine, i riquadri oggetto OLE, i riquadri multimediali, i riquadri zoom, le tabelle, i grafici e gli oggetti SmartArt possono fare riferimento a immagini. Alcuni tipi di forma espongono immagini tramite oggetti di formattazione nidificati, quindi un semplice controllo `picture_format` o `fill_format` della forma non è sempre sufficiente.

**Posso estrarre la miniatura mostrata per un riquadro video?**

Sì. Usa [VideoFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/videoframe/) e leggi `picture_format.picture.image`. Questo estrae l'immagine di copertina memorizzata con il riquadro video, non un fotogramma generato dal file video.

**Come posso determinare quali forme utilizzano una specifica immagine dalla collezione di immagini della presentazione?**

Aspose.Slides non memorizza link inversi da [PPImage](https://reference.aspose.com/slides/it/python-net/aspose.slides/ppimage/) alle forme. Costruisci una mappatura durante la traversata: ogni volta che trovi un riferimento a un'immagine, registra il numero della diapositiva, il percorso della forma e l'hash dell'immagine o l'elemento della collezione.

**Posso estrarre le immagini incorporate all'interno di oggetti OLE, come documenti allegati?**

Puoi estrarre l'anteprima della diapositiva dell'oggetto OLE dalla proprietà `substitute_picture_format` di [OleObjectFrame](https://reference.aspose.com/slides/it/python-net/aspose.slides/oleobjectframe/). Tuttavia, tale anteprima non è il documento incorporato stesso. Per estrarre immagini dall'interno del file incorporato, estrai i dati OLE e ispezionali con gli strumenti adatti a quel tipo di file.