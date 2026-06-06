---
title: Extraer imágenes de formas de presentación en Python
linktitle: Imagen desde forma
type: docs
weight: 90
url: /es/python-net/extracting-images-from-presentation-shapes/
keywords:
- extraer imagen
- recuperar imagen
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Extrae imágenes de formas en presentaciones PowerPoint y OpenDocument con Aspose.Slides para Python mediante .NET: solución rápida y adecuada para código."
---
## **Visión general**

Las imágenes en una presentación pueden aparecer en varios tipos de forma: como marcos de imagen ordinarios, como rellenos de imagen aplicados a formas, como imágenes de vista previa de objetos OLE, como miniaturas de fotogramas de vídeo o audio, como imágenes de zoom o como imágenes incrustadas dentro de formas de tabla, gráfico y SmartArt. Aspose.Slides almacena esas imágenes en la colección de imágenes de la presentación, expuesta a través de [ImageCollection](https://reference.aspose.com/slides/es/python-net/aspose.slides/imagecollection/) y [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) objetos.

Si solo necesitas exportar cada recurso de imagen incrustado en una presentación, itera a través de `presentation.images`. Este artículo se centra en una tarea diferente: recorrer las formas para encontrar dónde se utilizan las imágenes en las diapositivas, de modo que los archivos guardados puedan conservar contexto útil como el número de diapositiva, la posición de la forma y el tipo de origen (marco de imagen, imagen de relleno, vista previa de medios, vista previa OLE o imagen de zoom).

{{% alert title="Tip" color="primary" %}}
Utiliza la propiedad `binary_data` de [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) para conservar los datos de imagen codificados originales y el tipo de archivo. Utiliza la propiedad `image` con `save` cuando desees normalizar la salida a un formato específico, como PNG.
{{% /alert %}}

## **Métodos auxiliares compartidos**

Los métodos auxiliares a continuación mantienen los ejemplos breves. `save_original_image` escribe los bytes incrustados originales, elige una extensión segura a partir del tipo MIME y omite los binarios de imagen duplicados mediante hash SHA-256.

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

## **Extraer imágenes de marcos de imagen**

Utiliza este enfoque para imágenes insertadas como objetos independientes. Un [PictureFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/pictureframe/) almacena su imagen en `picture_format.picture.image`, que devuelve un objeto [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/).

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

## **Extraer imágenes de formas rellenas con imagen**

Las formas pueden usar una imagen como su relleno. Primero verifica el tipo de relleno de la forma: si no es [FillType.PICTURE](https://reference.aspose.com/slides/es/python-net/aspose.slides/filltype/), no hay imagen que extraer de ese relleno. El ejemplo a continuación maneja objetos [AutoShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/autoshape/) y guarda cada imagen como PNG mediante la propiedad `image` de [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/).

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

## **Extraer imágenes de vista previa de marcos de objetos OLE**

Un [OleObjectFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/oleobjectframe/) puede tener una imagen sustituta que PowerPoint usa como vista previa del objeto en una diapositiva. Esta imagen está disponible a través de `substitute_picture_format.picture.image`. Extraer esta imagen proporciona la vista previa, no el contenido del paquete OLE incrustado.

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

## **Extraer imágenes de vista previa de marcos de vídeo**

Un [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/) también puede almacenar una imagen de vista previa en `picture_format.picture.image`. Esta es la portada o miniatura mostrada en la diapositiva, no un fotograma decodificado del flujo de vídeo.

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

## **Extraer imágenes de vista previa de marcos de audio**

Un [AudioFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/) puede almacenar una miniatura en `picture_format.picture.image`. Esta es la imagen mostrada para el objeto de audio en la diapositiva.

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

## **Extraer imágenes de objetos Zoom**

[ZoomFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/zoomframe/) y [SectionZoomFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/sectionzoomframe/) pueden usar imágenes personalizadas. Lee `zoom_image` del marco de zoom.

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

## **Extraer imágenes de marcos de Zoom resumido**

Un [SummaryZoomFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/summaryzoomframe/) también es una forma. Sus elementos de sección pueden usar imágenes personalizadas, expuestas a través de la propiedad `zoom_image` de cada sección de zoom resumido.

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

## **Extraer imágenes de formas de tabla**

Una [Table](https://reference.aspose.com/slides/es/python-net/aspose.slides/table/) es una forma. Las imágenes en una tabla suelen almacenarse como rellenos de imagen en las celdas de la tabla.

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

## **Extraer imágenes de formas de gráfico**

Un [Chart](https://reference.aspose.com/slides/es/python-net/aspose.slides.charts/chart/) es una forma. El ejemplo a continuación extrae una imagen del relleno de imagen del área del gráfico.

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

## **Extraer imágenes de formas SmartArt**

Un objeto [SmartArt](https://reference.aspose.com/slides/es/python-net/aspose.slides.smartart/smartart/) es una forma. Dependiendo del diseño de SmartArt, las imágenes pueden almacenarse en los rellenos de viñetas de los nodos o en los formatos de relleno de las formas de los nodos.

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

## **Incluir imágenes dentro de formas agrupadas**

Las formas agrupadas contienen sus propias colecciones de formas. El método auxiliar compartido `enumerate_shapes` tiene una opción `include_grouped_shapes`. Establécela en `True` cuando quieras inspeccionar formas dentro de objetos [GroupShape](https://reference.aspose.com/slides/es/python-net/aspose.slides/groupshape/) . El ejemplo a continuación extrae imágenes de marcos de imagen, formas rellenas con imagen, vistas previas de objetos OLE, miniaturas de marcos de vídeo y miniaturas de marcos de audio. Para incluir también imágenes de tabla, gráfico, SmartArt y zoom resumido, reutiliza la lógica de extracción especializada de las secciones anteriores manteniendo el mismo recorrido recursivo de formas.

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

## **Casos límite y notas prácticas**

- **Imágenes duplicadas:** Varias formas pueden referenciar la misma imagen o imágenes distintas con bytes idénticos. Calcula el hash de la propiedad `binary_data` de [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) antes de escribir los archivos si deseas un archivo de salida por cada imagen única.
- **Datos originales vs. salida convertida:** Guardar la propiedad `binary_data` de [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) conserva los datos incrustados JPEG, PNG, GIF, SVG, EMF o WMF. Guardar la propiedad `image` mediante `save` es útil cuando deseas un formato de salida coherente.
- **Tipos de relleno no compatibles:** Las formas sólidas, degradados, patrones y sin relleno no contienen un relleno de imagen. Verifica [FillType](https://reference.aspose.com/slides/es/python-net/aspose.slides/filltype/) antes de leer `picture_fill_format`.
- **Formas agrupadas:** La colección de formas de la diapositiva de nivel superior no aplana los grupos. Inspecciona recursivamente [GroupShape.shapes](https://reference.aspose.com/slides/es/python-net/aspose.slides/groupshape/shapes/) cuando el contenido agrupado sea relevante.
- **Vistas previas de objetos OLE:** Un [OleObjectFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/oleobjectframe/) puede exponer una imagen de vista previa mediante `substitute_picture_format`, pero esa imagen es solo la vista previa de la diapositiva. No es el archivo incrustado dentro del objeto OLE.
- **Miniaturas de marcos de vídeo:** Un [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/) puede exponer una imagen de vista previa mediante `picture_format`, pero esa imagen es solo el póster mostrado en la diapositiva. No se extrae del flujo de vídeo.
- **Miniaturas de marcos de audio:** Un [AudioFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/audioframe/) puede exponer un ítem o miniatura mediante `picture_format`; no son los datos de audio incrustados.
- **Imágenes de zoom:** Las formas de zoom de diapositiva, zoom de sección y zoom resumido pueden usar objetos [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) personalizados a través de `image`.
- **Modelos de forma anidados:** Los objetos de tabla, gráfico y SmartArt implementan [Shape](https://reference.aspose.com/slides/es/python-net/aspose.slides/shape/), pero sus imágenes a menudo se almacenan en objetos de formato anidados de celdas de tabla, elementos de gráfico o nodos de SmartArt.
- **Imágenes recortadas o transformadas:** Acceder a [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) te proporciona el recurso de imagen almacenado. No representa recortes, transparencias, recoloreado, rotación u otros efectos visuales aplicados por la forma.

## **FAQ**

**¿Puedo extraer la imagen original sin recortes, efectos o transformaciones de forma?**

Sí. Accede al objeto [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) y escribe su propiedad `binary_data` en disco. Esto conserva la imagen codificada original almacenada en la presentación, no la forma en que la imagen se renderiza en la diapositiva.

**¿Puedo exportar cada imagen extraída como PNG?**

Sí. Utiliza la propiedad `image` de [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) para obtener un objeto de imagen y luego llama a `save` con [ImageFormat.PNG](https://reference.aspose.com/slides/es/python-net/aspose.slides/imageformat/). Esto convierte la salida y puede no conservar el tipo de archivo original ni los datos vectoriales.

**¿Cómo evito guardar la misma imagen más de una vez?**

Utiliza un hash de la propiedad `binary_data` de [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) y guarda los hash en un conjunto. Si una nueva imagen tiene un hash que ya existe, sáltala o registra otra referencia al archivo de salida existente.

**¿Por qué algunas formas no generan una imagen?**

Los marcos de imagen, las formas rellenas con imagen, los marcos de objetos OLE, los marcos de medios, los marcos de zoom, las tablas, los gráficos y los objetos SmartArt pueden referenciar imágenes. Algunos tipos de forma exponen imágenes a través de objetos de formato anidados, por lo que una simple comprobación de `picture_format` o `fill_format` de la forma no siempre es suficiente.

**¿Puedo extraer la miniatura mostrada para un marco de vídeo?**

Sí. Utiliza [VideoFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/videoframe/) y lee `picture_format.picture.image`. Esto extrae la imagen de portada almacenada con el marco de vídeo, no un fotograma generado a partir del archivo de vídeo.

**¿Cómo puedo determinar qué formas usan una imagen específica de la colección de imágenes de la presentación?**

Aspose.Slides no almacena enlaces inversos de [PPImage](https://reference.aspose.com/slides/es/python-net/aspose.slides/ppimage/) a las formas. Construye un mapeo durante el recorrido: cada vez que encuentres una referencia a una imagen, registra el número de diapositiva, la ruta de la forma y el hash de la imagen o el elemento de la colección.

**¿Puedo extraer imágenes incrustadas dentro de objetos OLE, como documentos adjuntos?**

Puedes extraer la vista previa del OLE de la diapositiva desde la propiedad `substitute_picture_format` de [OleObjectFrame](https://reference.aspose.com/slides/es/python-net/aspose.slides/oleobjectframe/). Sin embargo, esa vista previa no es el documento incrustado en sí. Para extraer imágenes desde dentro del archivo incrustado, extrae los datos OLE y examínalos con herramientas para ese tipo de archivo.