---
title: Ekstrak Gambar dari Bentuk Presentasi dengan Python via Java
linktitle: Gambar dari Bentuk
type: docs
weight: 100
url: /id/python-java/extracting-images-from-presentation-shapes/
keywords:
- ekstrak gambar
- ambil gambar
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Ekstrak gambar dari bentuk dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python via Java - solusi cepat dan ramah kode."
---
## **Gambaran Umum**

Gambar dalam presentasi dapat muncul dalam beberapa jenis bentuk: sebagai bingkai gambar biasa, sebagai isian gambar yang diterapkan pada bentuk, sebagai gambar pratinjau objek OLE, sebagai thumbnail bingkai video atau audio, sebagai gambar zoom, atau sebagai gambar yang bersarang di dalam bentuk tabel, diagram, dan SmartArt. Aspose.Slides menyimpan gambar‑gambar tersebut dalam koleksi gambar presentasi, yang dapat diakses melalui objek [ImageCollection](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagecollection/) dan [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/).

Jika Anda hanya perlu mengekspor setiap sumber gambar yang tertanam dalam presentasi, iterasi melalui [Presentation.getImages](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getImages). Artikel ini fokus pada tugas yang berbeda: menelusuri bentuk‑bentuk untuk menemukan di mana gambar digunakan pada slide, sehingga file yang disimpan dapat mempertahankan konteks berguna seperti nomor slide, posisi bentuk, dan tipe sumber (bingkai gambar, gambar isian, pratinjau media, pratinjau OLE, atau gambar zoom).

{{% alert title="Tip" color="success" %}}
Gunakan [PPImage.getBinaryData](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/#getBinaryData) untuk mempertahankan data gambar yang terenkode asli dan tipe berkasnya. Gunakan [PPImage.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/#getImage) dengan `save` ketika Anda ingin menormalkan output ke format tertentu seperti PNG.
{{% /alert %}}

## **Fungsi Pembantu Bersama**

Simpan fungsi pembantu bersama di bawah ini dalam `image_helpers.py` bersamaan dengan skrip contoh. Mereka membuat contoh menjadi singkat. `save_original_image` menulis byte yang tertanam asli, memilih ekstensi yang aman dari tipe MIME, dan melewatkan duplikat biner gambar berdasarkan hash SHA‑256.

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

## **Ekstrak Gambar dari Bingkai Gambar**

Gunakan pendekatan ini untuk gambar yang dimasukkan sebagai objek mandiri. Sebuah [PictureFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/) menyediakan akses ke gambarnya melalui [getPictureFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillformat/#getPicture), dan [getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/picture/#getImage), yang mengembalikan objek [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/).

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

## **Ekstrak Gambar dari Bentuk yang Diisi Gambar**

Bentuk dapat menggunakan gambar sebagai isian mereka. Periksa tipe isian bentuk terlebih dahulu: jika bukan [FillType.Picture](https://reference.aspose.com/slides/id/python-java/aspose.slides/filltype/), tidak ada gambar yang dapat diekstrak dari isian tersebut. Contoh di bawah menangani objek [AutoShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/autoshape/) dan menyimpan setiap gambar sebagai PNG melalui [PPImage.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/#getImage).

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

## **Ekstrak Gambar Pratinjau dari Bingkai Objek OLE**

Sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleobjectframe/) dapat memiliki gambar pengganti yang digunakan PowerPoint sebagai pratinjau objek pada slide. Gambar ini tersedia melalui [getSubstitutePictureFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), [getPicture](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillformat/#getPicture), dan [getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/picture/#getImage). Mengekstrak gambar ini memberi Anda gambar pratinjau, bukan isi paket OLE yang tertanam.

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

## **Ekstrak Gambar Pratinjau dari Bingkai Video**

Sebuah [VideoFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/) juga dapat menyimpan gambar pratinjau dalam [getPictureFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillformat/#getPicture), dan [getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/picture/#getImage). Ini adalah poster atau thumbnail yang ditampilkan pada slide, bukan frame yang didekode dari aliran video.

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

## **Ekstrak Gambar Pratinjau dari Bingkai Audio**

Sebuah [AudioFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/) dapat menyimpan thumbnail dalam [getPictureFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillformat/#getPicture), dan [getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/picture/#getImage). Ini adalah gambar yang ditampilkan untuk objek audio pada slide.

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

## **Ekstrak Gambar dari Objek Zoom**

[ZoomFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/zoomframe/) dan [SectionZoomFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/sectionzoomframe/) dapat menggunakan gambar khusus. Baca [getZoomImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/zoomobject/#getZoomImage) dari bingkai zoom.

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

## **Ekstrak Gambar dari Bingkai Zoom Ringkasan**

Sebuah [SummaryZoomFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/summaryzoomframe/) juga merupakan bentuk. Item bagiannya dapat menggunakan gambar khusus, yang diekspos melalui metode [getZoomImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/zoomobject/#getZoomImage) pada setiap bagian zoom ringkasan.

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

## **Ekstrak Gambar dari Bentuk Tabel**

Sebuah [Table](https://reference.aspose.com/slides/id/python-java/aspose.slides/table/) adalah bentuk. Gambar dalam tabel biasanya disimpan sebagai isian gambar di sel tabel.

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

## **Ekstrak Gambar dari Bentuk Diagram**

Sebuah [Chart](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/) adalah bentuk. Contoh di bawah mengekstrak gambar dari isian gambar area diagram.

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

## **Ekstrak Gambar dari Bentuk SmartArt**

Sebuah objek [SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/) adalah bentuk. Tergantung pada tata letak SmartArt, gambar dapat disimpan dalam isian bullet node atau dalam format isian bentuk node.

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

## **Sertakan Gambar di Dalam Bentuk yang Dikelompokkan**

Bentuk yang dikelompokkan memiliki koleksi bentuk masing‑masing. Pembantu `enumerate_shapes` yang dibagikan memiliki opsi `include_grouped_shapes`. Atur ke `True` ketika Anda ingin memeriksa bentuk di dalam objek [GroupShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/groupshape/). Contoh di bawah mengekstrak gambar dari bingkai gambar, bentuk yang diisi gambar, pratinjau objek OLE, thumbnail bingkai video, dan thumbnail bingkai audio. Untuk menyertakan gambar tabel, diagram, SmartArt, dan zoom ringkasan juga, gunakan kembali logika ekstraksi khusus dari bagian sebelumnya sambil mempertahankan penelusuran bentuk rekursif yang sama.

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

## **Kasus Tepi dan Catatan Praktis**

- **Gambar duplikat:** Beberapa bentuk dapat merujuk ke gambar yang sama atau gambar terpisah dengan byte yang identik. Hash [PPImage.getBinaryData](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/#getBinaryData) sebelum menulis berkas jika Anda menginginkan satu berkas output per gambar unik.
- **Data asli vs. output yang dikonversi:** Menyimpan [PPImage.getBinaryData](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/#getBinaryData) mempertahankan data JPEG, PNG, GIF, SVG, EMF, atau WMF yang tertanam. Menyimpan [PPImage.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/#getImage) melalui `save` berguna ketika Anda menginginkan format output yang konsisten.
- **Tipe isian yang tidak didukung:** Bentuk solid, gradien, pola, dan tanpa isian tidak mengandung isian gambar. Periksa [FillType](https://reference.aspose.com/slides/id/python-java/aspose.slides/filltype/) sebelum membaca [getPictureFillFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/fillformat/#getPictureFillFormat).
- **Bentuk yang dikelompokkan:** Koleksi bentuk slide tingkat atas tidak meratakan grup. Periksa secara rekursif [GroupShape.getShapes](https://reference.aspose.com/slides/id/python-java/aspose.slides/groupshape/#getShapes) ketika konten grup penting.
- **Pratinjau objek OLE:** Sebuah [OleObjectFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleobjectframe/) dapat mengekspor gambar pratinjau melalui [getSubstitutePictureFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), tetapi gambar itu hanya pratinjau slide. Itu bukan berkas yang tertanam di dalam objek OLE.
- **Thumbnail bingkai video:** Sebuah [VideoFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/) dapat mengekspor gambar pratinjau melalui [getPictureFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/#getPictureFormat), tetapi gambar itu hanya poster yang ditampilkan pada slide. Itu tidak diekstrak dari aliran video.
- **Thumbnail bingkai audio:** Sebuah [AudioFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/audioframe/) dapat mengekspor ikon atau thumbnail melalui [getPictureFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/#getPictureFormat); itu bukan data audio yang tertanam.
- **Gambar zoom:** Bentuk zoom slide, zoom bagian, dan zoom ringkasan dapat menggunakan objek [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) khusus melalui [getZoomImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/zoomobject/#getZoomImage).
- **Model bentuk bersarang:** Objek tabel, diagram, dan SmartArt mengimplementasikan [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/), tetapi gambar mereka sering disimpan dalam objek format sel tabel, elemen diagram, atau node SmartArt yang bersarang.
- **Gambar yang dipotong atau ditransformasi:** Mengakses [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) memberi Anda sumber daya gambar yang disimpan. Itu tidak menerapkan pemotongan, transparansi, pewarnaan ulang, rotasi, atau efek visual lain yang diterapkan oleh bentuk.

## **Tanya Jawab**

**Apakah saya dapat mengekstrak gambar asli tanpa pemotongan, efek, atau transformasi bentuk?**

Ya. Akses objek [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) dan tulis [PPImage.getBinaryData](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/#getBinaryData) ke disk. Ini mempertahankan gambar terenkode asli yang disimpan dalam presentasi, bukan cara gambar dirender pada slide.

**Apakah saya dapat mengekspor setiap gambar yang diekstrak sebagai PNG?**

Ya. Gunakan [PPImage.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/#getImage) untuk mendapatkan objek gambar, lalu panggil `save` dengan [ImageFormat.Png](https://reference.aspose.com/slides/id/python-java/aspose.slides/imageformat/). Ini mengonversi output dan mungkin tidak mempertahankan tipe berkas asli atau data vektor.

**Bagaimana cara menghindari penyimpanan gambar yang sama lebih dari satu kali?**

Gunakan hash dari [PPImage.getBinaryData](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/#getBinaryData) dan simpan hash tersebut dalam sebuah set. Jika gambar baru memiliki hash yang sudah ada, lewati atau catat referensi lain ke berkas output yang sudah ada.

**Mengapa beberapa bentuk tidak menghasilkan gambar?**

Bingkai gambar, bentuk yang diisi gambar, bingkai objek OLE, bingkai media, bingkai zoom, tabel, diagram, dan objek SmartArt dapat merujuk ke gambar. Beberapa tipe bentuk mengekspos gambar melalui objek format yang bersarang, sehingga pemeriksaan sederhana [getPictureFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/#getPictureFormat) atau [getFillFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getFillFormat) pada bentuk tidak selalu cukup.

**Apakah saya dapat mengekstrak thumbnail yang ditampilkan untuk bingkai video?**

Ya. Gunakan [VideoFrame](https://reference.aspose.com/slides/id/python-java/aspose.slides/videoframe/) dan baca [getPictureFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/id/python-java/aspose.slides/picturefillformat/#getPicture), dan [getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/picture/#getImage). Ini mengekstrak poster yang disimpan bersama bingkai video, bukan frame yang dihasilkan dari berkas video.

**Bagaimana saya dapat menentukan bentuk mana yang menggunakan gambar tertentu dari koleksi gambar presentasi?**

Aspose.Slides tidak menyimpan tautan terbalik dari [PPImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/) ke bentuk. Bangun pemetaan selama penelusuran: setiap kali Anda menemukan referensi gambar, catat nomor slide, jalur bentuk, dan hash atau item koleksi gambar.

**Apakah saya dapat mengekstrak gambar yang tertanam di dalam objek OLE, seperti dokumen terlampir?**

Anda dapat mengekstrak pratinjau slide objek OLE melalui [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat). Namun pratinjau tersebut bukan dokumen yang tertanam. Untuk mengekstrak gambar dari dalam berkas yang tertanam, ekstrak data OLE dan periksa dengan alat yang sesuai untuk tipe berkas tersebut.