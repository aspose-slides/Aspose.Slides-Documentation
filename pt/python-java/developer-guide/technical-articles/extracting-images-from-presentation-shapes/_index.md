---
title: Extrair Imagens de Formas de Apresentação em Python via Java
linktitle: Imagem de Forma
type: docs
weight: 100
url: /pt/python-java/extracting-images-from-presentation-shapes/
keywords:
- extrair imagem
- recuperar imagem
- PowerPoint
- OpenDocument
- apresentação
- Python
- Java
- Aspose.Slides
description: "Extrair imagens de formas em apresentações PowerPoint e OpenDocument com Aspose.Slides para Python via Java - solução rápida e amigável ao código."
---
## **Visão geral**

Imagens em uma apresentação podem aparecer em vários tipos de forma: como quadros de imagem comuns, como preenchimentos de imagem aplicados a formas, como imagens de visualização de objetos OLE, como miniaturas de quadros de vídeo ou áudio, como imagens de zoom ou como imagens aninhadas dentro de formas de tabela, gráfico e SmartArt. Aspose.Slides armazena essas imagens na coleção de imagens da apresentação, exposta através dos objetos [ImageCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imagecollection/) e [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/).

Se você precisar apenas exportar todos os recursos de imagem incorporados em uma apresentação, itere através de [Presentation.getImages](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getImages). Este artigo foca em uma tarefa diferente: percorrer formas para encontrar onde as imagens são usadas nos slides, para que os arquivos salvos mantenham contexto útil como número do slide, posição da forma e tipo de origem (quadro de imagem, preenchimento de imagem, visualização de mídia, visualização OLE ou imagem de zoom).

{{% alert title="Tip" color="success" %}}

Use [PPImage.getBinaryData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/#getBinaryData) para preservar os dados da imagem codificados original e o tipo de arquivo. Use [PPImage.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/#getImage) com `save` quando quiser normalizar a saída para um formato específico, como PNG.

{{% /alert %}}

## **Funções auxiliares compartilhadas**

Salve as funções auxiliares compartilhadas abaixo em `image_helpers.py` ao lado dos scripts de exemplo. Elas mantêm os exemplos curtos. `save_original_image` grava os bytes incorporados originais, escolhe uma extensão segura a partir do tipo MIME e ignora binários de imagem duplicados por hash SHA-256.

```python
from pathlib import Path
import hashlib
import re

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, GroupShape, ImageFormat


def save_original_image(image, output_directory, file_name_base, saved_image_hashes):
    image_data = bytes(image.getBinaryData())
    image_hash = hashlib.sha256(image_data).hexdigest()
    if image_hash in saved_image_hashes:
        return False
    saved_image_hashes.add(image_hash)
    extension = get_extension_from_content_type(image.getContentType())
    output_file = Path(output_directory) / f"{file_name_base}.{extension}"
    output_file.write_bytes(image_data)
    return True


def save_image_as_png(image, output_directory, file_name_base):
    output_file = Path(output_directory) / f"{file_name_base}.png"
    output_image = image.getImage()
    try:
        output_image.save(str(output_file), ImageFormat.Png)
    finally:
        output_image.dispose()


def get_picture_fill_image(fill_format):
    if fill_format is None or fill_format.getFillType() != FillType.Picture:
        return None
    return fill_format.getPictureFillFormat().getPicture().getImage()


def enumerate_shapes(shapes, prefix, include_grouped_shapes):
    shape_references = []
    for shape_index in range(shapes.size()):
        shape = shapes.get_Item(shape_index)
        shape_name_part = f"{prefix}_shape_{shape_index + 1}"
        shape_references.append((shape, shape_name_part))
        if include_grouped_shapes and isinstance(shape, GroupShape):
            child_shapes = shape.getShapes()
            child_references = enumerate_shapes(child_shapes, shape_name_part, include_grouped_shapes)
            shape_references.extend(child_references)
    return shape_references


def get_extension_from_content_type(content_type):
    if content_type is None or not str(content_type).strip():
        return "bin"
    media_type = str(content_type).split(";")[0].strip().lower()
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
        return re.sub(r"[^A-Za-z0-9._-]", "_", media_type[len("image/"):])
    return "bin"
```

## **Extrair imagens de quadros de imagem**

Use esta abordagem para imagens inseridas como objetos independentes. Um [PictureFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/) fornece acesso à sua imagem através de [getPictureFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/#getPicture) e [getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picture/#getImage), que retorna um objeto [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/).

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "extracted-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, PictureFrame):
                picture_frame = shape
                image = picture_frame.getPictureFormat().getPicture().getImage()
                save_original_image(image, output_directory, name_part, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extrair imagens de formas preenchidas com imagem**

Formas podem usar uma imagem como preenchimento. Verifique primeiro o tipo de preenchimento da forma: se não for [FillType.Picture](https://reference.aspose.com/slides/pt/python-java/aspose.slides/filltype/), não há imagem a extrair desse preenchimento. O exemplo abaixo lida com objetos [AutoShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/autoshape/) e salva cada imagem como PNG através de [PPImage.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/#getImage).

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "shape-fill-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, AutoShape):
                auto_shape = shape
                fill_format = auto_shape.getFillFormat()
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    save_image_as_png(image, output_directory, name_part)
finally:
    presentation.dispose()
```

## **Extrair imagens de visualização de quadros de objeto OLE**

Um [OleObjectFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleobjectframe/) pode ter uma imagem substituta que o PowerPoint usa como visualização do objeto no slide. Essa imagem está disponível através de [getSubstitutePictureFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), [getPicture](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/#getPicture) e [getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picture/#getImage). Extrair essa imagem fornece a visualização, não o conteúdo do pacote OLE incorporado.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, OleObjectFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "ole-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, OleObjectFrame):
                ole_object_frame = shape
                image = ole_object_frame.getSubstitutePictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extrair imagens de visualização de quadros de vídeo**

Um [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) também pode armazenar uma imagem de visualização em [getPictureFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/#getPicture) e [getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picture/#getImage). Esta é a capa ou miniatura exibida no slide, não um quadro decodificado da sequência de vídeo.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, VideoFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "video-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, VideoFrame):
                video_frame = shape
                image = video_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extrair imagens de visualização de quadros de áudio**

Um [AudioFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/) pode armazenar uma miniatura em [getPictureFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/#getPicture) e [getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picture/#getImage). Esta é a imagem mostrada para o objeto de áudio no slide.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AudioFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "audio-preview-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, AudioFrame):
                audio_frame = shape
                image = audio_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extrair imagens de objetos de zoom**

Formas [ZoomFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/zoomframe/) e [SectionZoomFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sectionzoomframe/) podem usar imagens personalizadas. Leia [getZoomImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/zoomobject/#getZoomImage) do quadro de zoom.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SectionZoomFrame, ZoomFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, ZoomFrame):
                zoom_frame = shape
                image = zoom_frame.getZoomImage()
                if image is not None:
                    file_name_base = name_part + "_zoom"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                    continue
            if isinstance(shape, SectionZoomFrame):
                section_zoom_frame = shape
                image = section_zoom_frame.getZoomImage()
                if image is not None:
                    file_name_base = name_part + "_section_zoom"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                    continue
finally:
    presentation.dispose()
```

## **Extrair imagens de quadros de zoom resumido**

Um [SummaryZoomFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/summaryzoomframe/) também é uma forma. Seus itens de seção podem usar imagens personalizadas, expostas através do método [getZoomImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/zoomobject/#getZoomImage) de cada seção de zoom resumido.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SummaryZoomFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "summary-zoom-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, False)
        for shape, name_part in shape_references:
            if isinstance(shape, SummaryZoomFrame):
                summary_zoom_frame = shape
                section_count = summary_zoom_frame.getSummaryZoomCollection().size()
                for section_index in range(section_count):
                    section = summary_zoom_frame.getSummaryZoomCollection().get_Item(section_index)
                    image = section.getZoomImage()
                    if image is not None:
                        display_index = section_index + 1
                        file_name_base = name_part + "_summary_zoom_" + str(display_index)
                        save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extrair imagens de formas de tabela**

Uma [Table](https://reference.aspose.com/slides/pt/python-java/aspose.slides/table/) é uma forma. Imagens em uma tabela geralmente são armazenadas como preenchimentos de imagem nas células da tabela.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "table-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, Table):
                table = shape
                row_count = table.getRows().size()
                column_count = table.getColumns().size()
                for row_index in range(row_count):
                    for column_index in range(column_count):
                        cell = table.get_Item(column_index, row_index)
                        fill_format = cell.getCellFormat().getFillFormat()
                        image = get_picture_fill_image(fill_format)
                        if image is not None:
                            display_row = row_index + 1
                            display_column = column_index + 1
                            file_name_base = name_part + "_cell_" + str(display_row) + "_" + str(display_column)
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extrair imagens de formas de gráfico**

Um [Chart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/) é uma forma. O exemplo abaixo extrai uma imagem do preenchimento de imagem da área do gráfico.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "chart-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, Chart):
                chart = shape
                fill_format = chart.getFillFormat()
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    file_name_base = name_part + "_chart_area"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Extrair imagens de formas SmartArt**

Um objeto [SmartArt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/smartart/) é uma forma. Dependendo do layout do SmartArt, imagens podem ser armazenadas em preenchimentos de marcadores de nós ou nos formatos de preenchimento das formas dos nós.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "smartart-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, SmartArt):
                smart_art = shape
                node_count = smart_art.getAllNodes().size()
                for node_index in range(node_count):
                    node = smart_art.getAllNodes().get_Item(node_index)
                    bullet_fill_format = node.getBulletFillFormat()
                    bullet_image = get_picture_fill_image(bullet_fill_format)
                    if bullet_image is not None:
                        display_node = node_index + 1
                        file_name_base = name_part + "_smartart_node_" + str(display_node) + "_bullet"
                        save_original_image(bullet_image, output_directory, file_name_base, saved_image_hashes)
                    node_shape_count = node.getShapes().size()
                    for node_shape_index in range(node_shape_count):
                        node_shape = node.getShapes().get_Item(node_shape_index)
                        fill_format = node_shape.getFillFormat()
                        image = get_picture_fill_image(fill_format)
                        if image is not None:
                            display_node = node_index + 1
                            display_node_shape = node_shape_index + 1
                            file_name_base = name_part + "_smartart_node_" + str(display_node) + "_shape_" + str(display_node_shape)
                            save_original_image(image, output_directory, file_name_base, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Incluir imagens dentro de formas agrupadas**

Formas agrupadas contêm suas próprias coleções de formas. O auxiliar compartilhado `enumerate_shapes` possui a opção `include_grouped_shapes`. Defina-a como `True` quando quiser inspecionar formas dentro de objetos [GroupShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/groupshape/). O exemplo abaixo extrai imagens de quadros de imagem, formas preenchidas com imagem, visualizações de objetos OLE, miniaturas de quadros de vídeo e miniaturas de quadros de áudio. Para incluir também imagens de tabela, gráfico, SmartArt e zoom resumido, reutilize a lógica de extração especializada das seções anteriores mantendo a mesma travessia recursiva de formas.

```python
from pathlib import Path
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AudioFrame, AutoShape, OleObjectFrame, PictureFrame, VideoFrame
from image_helpers import enumerate_shapes, get_picture_fill_image, save_image_as_png, save_original_image

input_path = "sample.pptx"
output_directory = Path.cwd() / "all-shape-images"
output_directory.mkdir(parents=True, exist_ok=True)
saved_image_hashes = set()

presentation = Presentation(input_path)
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide.getSlideNumber()
        slide_prefix = "slide_" + str(slide_number)
        shapes = slide.getShapes()
        shape_references = enumerate_shapes(shapes, slide_prefix, True)
        for shape, name_part in shape_references:
            if isinstance(shape, OleObjectFrame):
                ole_object_frame = shape
                image = ole_object_frame.getSubstitutePictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_ole_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                continue
            if isinstance(shape, VideoFrame):
                video_frame = shape
                image = video_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_video_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                continue
            if isinstance(shape, AudioFrame):
                audio_frame = shape
                image = audio_frame.getPictureFormat().getPicture().getImage()
                if image is not None:
                    file_name_base = name_part + "_audio_preview"
                    save_original_image(image, output_directory, file_name_base, saved_image_hashes)
                continue
            if isinstance(shape, PictureFrame):
                picture_frame = shape
                image = picture_frame.getPictureFormat().getPicture().getImage()
                save_original_image(image, output_directory, name_part, saved_image_hashes)
                continue
            if isinstance(shape, AutoShape):
                auto_shape = shape
                fill_format = auto_shape.getFillFormat()
                image = get_picture_fill_image(fill_format)
                if image is not None:
                    save_original_image(image, output_directory, name_part, saved_image_hashes)
finally:
    presentation.dispose()
```

## **Casos extremos e observações práticas**

- **Imagens duplicadas:** Várias formas podem referenciar a mesma imagem ou imagens diferentes com bytes idênticos. Gere hash de [PPImage.getBinaryData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/#getBinaryData) antes de gravar arquivos se quiser um arquivo de saída por imagem única.
- **Dados originais vs. saída convertida:** Salvar [PPImage.getBinaryData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/#getBinaryData) preserva os dados JPEG, PNG, GIF, SVG, EMF ou WMF incorporados. Salvar [PPImage.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/#getImage) via `save` é útil quando se deseja um formato de saída consistente.
- **Tipos de preenchimento não suportados:** Formas sólidas, gradientes, padrões e sem preenchimento não contêm preenchimento de imagem. Verifique [FillType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/filltype/) antes de ler [getPictureFillFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/fillformat/#getPictureFillFormat).
- **Formas agrupadas:** A coleção de formas de nível superior do slide não achata grupos. Inspecione recursivamente [GroupShape.getShapes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/groupshape/#getShapes) quando o conteúdo agrupado for relevante.
- **Visualizações de objetos OLE:** Um [OleObjectFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleobjectframe/) pode expor uma imagem de visualização via [getSubstitutePictureFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), mas essa imagem é apenas a visualização do slide. Não é o arquivo incorporado dentro do objeto OLE.
- **Miniaturas de quadros de vídeo:** Um [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) pode expor uma imagem de visualização via [getPictureFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/#getPictureFormat), mas essa imagem é apenas o cartaz exibido no slide. Não é extraída do fluxo de vídeo.
- **Miniaturas de quadros de áudio:** Um [AudioFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audioframe/) pode expor um ícone ou miniatura via [getPictureFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/#getPictureFormat); não é o dado de áudio incorporado.
- **Imagens de zoom:** Formas de zoom de slide, zoom de seção e zoom resumido podem usar objetos [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/) personalizados via [getZoomImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/zoomobject/#getZoomImage).
- **Modelos de forma aninhados:** Objetos de tabela, gráfico e SmartArt implementam [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/), mas suas imagens costumam estar armazenadas em objetos de formatação de célula de tabela, elemento de gráfico ou nó de SmartArt.
- **Imagens recortadas ou transformadas:** Acessar [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/) fornece o recurso de imagem armazenado. Não renderiza recortes, transparência, recoloração, rotação ou outros efeitos visuais aplicados pela forma.

## **Perguntas frequentes**

**Posso extrair a imagem original sem recortes, efeitos ou transformações da forma?**

Sim. Acesse o objeto [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/) e grave [PPImage.getBinaryData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/#getBinaryData) no disco. Isso preserva a imagem codificada original armazenada na apresentação, não a forma como a imagem é renderizada no slide.

**Posso exportar todas as imagens extraídas como PNG?**

Sim. Use [PPImage.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/#getImage) para obter um objeto de imagem e, em seguida, chame `save` com [ImageFormat.Png](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imageformat/). Isso converte a saída e pode não preservar o tipo de arquivo original ou dados vetoriais.

**Como evito salvar a mesma imagem mais de uma vez?**

Use um hash de [PPImage.getBinaryData](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/#getBinaryData) e mantenha os hashes em um conjunto. Se uma nova imagem possuir um hash que já exista, ignore-a ou registre outra referência ao arquivo de saída existente.

**Por que algumas formas não geram uma imagem?**

Quadros de imagem, formas preenchidas com imagem, quadros de objetos OLE, quadros de mídia, quadros de zoom, tabelas, gráficos e objetos SmartArt podem referenciar imagens. Alguns tipos de forma expõem imagens através de objetos de formatação aninhados, portanto uma simples verificação de [getPictureFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/#getPictureFormat) ou de [getFillFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getFillFormat) da forma nem sempre é suficiente.

**Posso extrair a miniatura mostrada para um quadro de vídeo?**

Sim. Use [VideoFrame](https://reference.aspose.com/slides/pt/python-java/aspose.slides/videoframe/) e leia [getPictureFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picturefillformat/#getPicture) e [getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/picture/#getImage). Isso extrai a imagem de capa armazenada com o quadro de vídeo, não um quadro gerado a partir do arquivo de vídeo.

**Como posso determinar quais formas usam uma imagem específica da coleção de imagens da apresentação?**

Aspose.Slides não armazena links reversos de [PPImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ppimage/) para formas. Construa um mapeamento durante a travessia: sempre que encontrar uma referência de imagem, registre o número do slide, o caminho da forma e o hash da imagem ou o item da coleção.

**Posso extrair imagens incorporadas dentro de objetos OLE, como documentos anexados?**

Você pode extrair a visualização do slide do objeto OLE via [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/pt/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat). Contudo, essa visualização não é o documento incorporado propriamente dito. Para extrair imagens de dentro do arquivo incorporado, extraia os dados OLE e inspecione-os com ferramentas adequadas ao tipo de arquivo.