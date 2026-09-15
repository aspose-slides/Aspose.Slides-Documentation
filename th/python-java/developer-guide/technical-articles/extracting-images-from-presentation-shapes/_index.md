---
title: ดึงรูปภาพจากรูปร่างการนำเสนอใน Python ผ่าน Java
linktitle: รูปภาพจากรูปร่าง
type: docs
weight: 100
url: /th/python-java/extracting-images-from-presentation-shapes/
keywords:
- ดึงรูปภาพ
- เรียกคืนรูปภาพ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Python
- Java
- Aspose.Slides
description: "ดึงรูปภาพจากรูปร่างในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน Java - โซลูชันที่รวดเร็วและเป็นมิตรต่อโค้ด"
---
## **ภาพรวม**

รูปภาพในงานนำเสนออาจปรากฏในหลายรูปแบบ: เป็นกรอบรูปภาพธรรมดา, เป็นรูปภาพเติมสีให้กับรูปร่าง, เป็นรูปภาพตัวอย่างของอ็อบเจ็กต์ OLE, เป็นภาพย่อของเฟรมวิดีโอหรือเสียง, เป็นรูปภาพซูม, หรือเป็นรูปภาพที่ซ้อนอยู่ภายในรูปแบบตาราง, แผนภูมิและ SmartArt. Aspose.Slides เก็บรูปภาพเหล่านี้ไว้ในคอลเลกชันรูปภาพของงานนำเสนอ, ซึ่งเปิดให้เข้าถึงผ่านอ็อบเจ็กต์ [ImageCollection](https://reference.aspose.com/slides/th/python-java/aspose.slides/imagecollection/) และ [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/).

หากคุณต้องการส่งออกทรัพยากรรูปภาพทั้งหมดที่ฝังอยู่ในงานนำเสนอ, ให้วนลูปผ่าน [Presentation.getImages](https://reference.aspose.com/slides/th/python-java/aspose.slides/presentation/#getImages). บทความนี้มุ่งเน้นที่งานอื่น: การท่องรูปร่างเพื่อค้นหาตำแหน่งที่รูปภาพถูกใช้บนสไลด์, เพื่อให้ไฟล์ที่บันทึกไว้สามารถเก็บบริบทที่เป็นประโยชน์ เช่น หมายเลขสไลด์, ตำแหน่งรูปร่าง, และประเภทแหล่งที่มา (กรอบรูปภาพ, รูปภาพเติม, ตัวอย่างสื่อ, ตัวอย่าง OLE, หรือรูปภาพซูม).

{{% alert title="Tip" color="success" %}}
ใช้ [PPImage.getBinaryData](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/#getBinaryData) เพื่อเก็บข้อมูลรูปภาพที่เข้ารหัสเดิมและประเภทไฟล์ไว้. ใช้ [PPImage.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/#getImage) พร้อม `save` เมื่อคุณต้องการทำให้ผลลัพธ์เป็นรูปแบบที่กำหนดเช่น PNG.
{{% /alert %}}

## **ฟังก์ชันช่วยเหลือที่ใช้ร่วมกัน**

บันทึกฟังก์ชันช่วยเหลือที่ใช้ร่วมกันด้านล่างในไฟล์ `image_helpers.py` ควบคู่กับสคริปต์ตัวอย่าง. ฟังก์ชันเหล่านี้ทำให้ตัวอย่างสั้นลง. `save_original_image` จะเขียนไบต์ที่ฝังเดิม, เลือกนามสกุลที่ปลอดภัยจาก MIME type, และข้ามไบต์รูปภาพที่ซ้ำกันโดยตรวจสอบแฮช SHA‑256.

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

## **ดึงรูปภาพจากกรอบรูปภาพ (Picture Frames)**

ใช้วิธีนี้สำหรับรูปภาพที่แทรกเป็นอ็อบเจกต์อิสระ. [PictureFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/) ให้เข้าถึงรูปภาพผ่าน [getPictureFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#getPicture), และ [getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/picture/#getImage), ซึ่งส่งคืนอ็อบเจกต์ [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/).

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

## **ดึงรูปภาพจากรูปร่างที่เติมด้วยรูปภาพ (Picture‑Filled Shapes)**

รูปร่างสามารถใช้รูปภาพเป็นการเติมสีได้. ตรวจสอบประเภทการเติมของรูปร่างก่อน: หากไม่ได้เป็น [FillType.Picture](https://reference.aspose.com/slides/th/python-java/aspose.slides/filltype/), จะไม่มีรูปภาพให้ดึงออกจากการเติมนั้น. ตัวอย่างด้านล่างจัดการกับอ็อบเจกต์ [AutoShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/autoshape/) และบันทึกรูปภาพแต่ละรายการเป็น PNG ผ่าน [PPImage.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/#getImage).

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

## **ดึงรูปภาพตัวอย่างจากกรอบอ็อบเจกต์ OLE (OLE Object Frames)**

[OleObjectFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleobjectframe/) สามารถมีรูปภาพทดแทนที่ PowerPoint ใช้เป็นตัวอย่างของอ็อบเจกต์บนสไลด์. รูปภาพนี้สามารถเข้าถึงได้ผ่าน [getSubstitutePictureFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), [getPicture](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#getPicture), และ [getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/picture/#getImage). การดึงรูปภาพนี้จะให้คุณได้รูปตัวอย่าง, ไม่ใช่เนื้อหาแพ็คเกจ OLE ที่ฝังอยู่.

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

## **ดึงรูปภาพตัวอย่างจากเฟรมวิดีโอ (Video Frames)**

[VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) สามารถเก็บรูปภาพตัวอย่างใน [getPictureFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#getPicture), และ [getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/picture/#getImage). นี่คือโปสเตอร์หรือภาพย่อที่แสดงบนสไลด์, ไม่ใช่เฟรมที่ถอดรหัสจากสตรีมวิดีโอ.

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

## **ดึงรูปภาพตัวอย่างจากเฟรมเสียง (Audio Frames)**

[AudioFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/) สามารถเก็บภาพย่อใน [getPictureFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#getPicture), และ [getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/picture/#getImage). นี่คือภาพที่แสดงสำหรับอ็อบเจกต์เสียงบนสไลด์.

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

## **ดึงรูปภาพจากอ็อบเจกต์ซูม (Zoom Objects)**

รูปร่าง [ZoomFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/zoomframe/) และ [SectionZoomFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/sectionzoomframe/) สามารถใช้รูปภาพกำหนดเอง. อ่านค่า [getZoomImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/zoomobject/#getZoomImage) จากเฟรมซูม.

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

## **ดึงรูปภาพจากเฟรมซูมสรุป (Summary Zoom Frames)**

[SummaryZoomFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/summaryzoomframe/) ก็เป็นรูปร่างเช่นกัน. รายการส่วนของมันสามารถใช้รูปภาพกำหนดเอง, เปิดให้เข้าถึงผ่านเมธอด [getZoomImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/zoomobject/#getZoomImage) ของแต่ละส่วนสรุปซูม.

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

## **ดึงรูปภาพจากรูปร่างตาราง (Table Shapes)**

[Table](https://reference.aspose.com/slides/th/python-java/aspose.slides/table/) เป็นรูปร่าง. รูปภาพในตารางมักจะถูกจัดเก็บเป็นการเติมรูปภาพในเซลล์ของตาราง.

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

## **ดึงรูปภาพจากรูปร่างแผนภูมิ (Chart Shapes)**

[Chart](https://reference.aspose.com/slides/th/python-java/aspose.slides/chart/) เป็นรูปร่าง. ตัวอย่างด้านล่างดึงรูปภาพจากการเติมรูปภาพของพื้นที่แผนภูมิ.

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

## **ดึงรูปภาพจากรูปร่าง SmartArt**

[SmartArt](https://reference.aspose.com/slides/th/python-java/aspose.slides/smartart/) เป็นอ็อบเจกต์รูปร่าง. ขึ้นอยู่กับการจัดวางของ SmartArt, รูปภาพอาจถูกเก็บในการเติมรูปแบบของโหนดหรือในการเติมของรูปร่างโหนด.

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

## **รวมรูปภาพภายในรูปร่างที่จัดเป็นกลุ่ม (Grouped Shapes)**

รูปร่างที่จัดเป็นกลุ่มมีคอลเลกชันรูปร่างของตัวเอง. ตัวช่วย `enumerate_shapes` ร่วมมีตัวเลือก `include_grouped_shapes`. ตั้งค่าเป็น `True` เมื่อคุณต้องการตรวจสอบรูปร่างภายในอ็อบเจกต์ [GroupShape](https://reference.aspose.com/slides/th/python-java/aspose.slides/groupshape/). ตัวอย่างด้านล่างดึงรูปภาพจากกรอบรูปภาพ, รูปร่างที่เติมด้วยรูปภาพ, ตัวอย่างอ็อบเจกต์ OLE, ภาพย่อเฟรมวิดีโอ, และภาพย่อเฟรมเสียง. เพื่อรวมรูปภาพจากตาราง, แผนภูมิ, SmartArt, และซูมสรุปด้วย, ให้ใช้ตรรกะการดึงรูปภาพเฉพาะที่ได้จากส่วนก่อนหน้าโดยคงการท่องรูปร่างแบบเรียกซ้ำเดิม.

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

## **กรณีเฉพาะและข้อควรปฏิบัติ**

- **รูปภาพซ้ำ:** หลายรูปร่างอาจอ้างอิงรูปภาพเดียวกันหรือรูปภาพที่มีไบต์เท่าเดิม. ให้ใช้แฮชของ [PPImage.getBinaryData](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/#getBinaryData) ก่อนบันทึกไฟล์หากต้องการไฟล์ผลลัพธ์หนึ่งไฟล์ต่อหนึ่งรูปภาพที่มีความเอกลักษณ์.
- **ข้อมูลเดิม vs. ผลลัพธ์ที่แปลง:** การบันทึก [PPImage.getBinaryData](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/#getBinaryData) จะคงข้อมูล JPEG, PNG, GIF, SVG, EMF หรือ WMF ที่ฝังอยู่. การบันทึก [PPImage.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/#getImage) ผ่าน `save` มีประโยชน์เมื่อคุณต้องการรูปแบบผลลัพธ์ที่สม่ำเสมอ.
- **ประเภทการเติมที่ไม่รองรับ:** รูปร่างที่เป็นสีทึบ, ความไล่สี, ลวดลาย, หรือไม่มีการเติมจะไม่มีรูปภาพเติม. ตรวจสอบ [FillType](https://reference.aspose.com/slides/th/python-java/aspose.slides/filltype/) ก่อนอ่าน [getPictureFillFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/fillformat/#getPictureFillFormat).
- **รูปร่างที่จัดเป็นกลุ่ม:** คอลเลกชันรูปร่างระดับบนสุดของสไลด์ไม่ทำการแบนกลุ่ม. ตรวจสอบ [GroupShape.getShapes](https://reference.aspose.com/slides/th/python-java/aspose.slides/groupshape/#getShapes) อย่างเรียกซ้ำเมื่อเนื้อหากลุ่มมีความสำคัญ.
- **ตัวอย่างอ็อบเจกต์ OLE:** [OleObjectFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleobjectframe/) อาจเผยรูปภาพตัวอย่างผ่าน [getSubstitutePictureFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat), แต่รูปภาพนั้นเป็นเพียงตัวอย่างบนสไลด์ ไม่ใช่ไฟล์ที่ฝังอยู่ในอ็อบเจกต์ OLE.
- **ภาพย่อเฟรมวิดีโอ:** [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) อาจเผยรูปภาพตัวอย่างผ่าน [getPictureFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/#getPictureFormat), แต่รูปภาพนั้นเป็นโปสเตอร์ที่แสดงบนสไลด์ ไม่ได้มาจากสตรีมวิดีโอ.
- **ภาพย่อเฟรมเสียง:** [AudioFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/audioframe/) อาจเผยไอคอนหรือภาพย่อผ่าน [getPictureFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/#getPictureFormat); ไม่ได้เป็นข้อมูลเสียงที่ฝังอยู่.
- **รูปภาพซูม:** รูปร่างซูมสไลด์, ซูมส่วน, และซูมสรุปอาจใช้วัตถุ [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/) ผ่าน [getZoomImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/zoomobject/#getZoomImage).
- **โมเดลรูปร่างที่ซ้อนกัน:** อ็อบเจกต์ตาราง, แผนภูมิ, และ SmartArt ลงทะเบียนเป็น [Shape](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/), แต่รูปภาพของพวกเขามักเก็บอยู่ในเซลล์ตาราง, องค์ประกอบแผนภูมิ, หรือวัตถุการจัดรูปแบบของโหนด SmartArt ที่ซ้อนกัน.
- **รูปภาพที่ถูกครอปหรือแปลง:** การเข้าถึง [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/) จะให้คุณทรัพยากรรูปภาพที่จัดเก็บไว้. มันไม่แสดงการครอป, ความโปร่งใส, การปรับสี, การหมุน, หรือเอฟเฟกต์ภาพอื่น ๆ ที่รูปแบบโดยรูปร่าง.

## **คำถามที่พบบ่อย (FAQ)**

**ฉันสามารถดึงรูปภาพต้นฉบับโดยไม่มีการครอป, เอฟเฟกต์ หรือการแปลงรูปร่างได้หรือไม่?**

ได้. เข้าถึงอ็อบเจกต์ [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/) และเขียน [PPImage.getBinaryData](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/#getBinaryData) ลงดิสก์. วิธีนี้จะคงรูปภาพที่เข้ารหัสเดิมที่เก็บอยู่ในงานนำเสนอ, ไม่ใช่วิธีการแสดงผลบนสไลด์.

**ฉันสามารถส่งออกรูปภาพที่ดึงออกทั้งหมดเป็น PNG ได้หรือไม่?**

ได้. ใช้ [PPImage.getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/#getImage) เพื่อรับอ็อบเจกต์ภาพ, จากนั้นเรียก `save` พร้อม [ImageFormat.Png](https://reference.aspose.com/slides/th/python-java/aspose.slides/imageformat/). วิธีนี้จะแปลงผลลัพธ์และอาจไม่คงประเภทไฟล์หรือข้อมูลเวกเตอร์เดิม.

**ฉันจะหลีกเลี่ยงการบันทึกรูปภาพเดียวกันหลายครั้งได้อย่างไร?**

ใช้แฮชของ [PPImage.getBinaryData](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/#getBinaryData) และเก็บแฮชไว้ในชุด. หากรูปใหม่มีแฮชที่มีอยู่แล้ว, ให้ข้ามหรือบันทึกการอ้างอิงอื่นไปยังไฟล์ผลลัพธ์ที่มีอยู่แล้ว.

**ทำไมบางรูปร่างจึงไม่สร้างรูปภาพได้?**

กรอบรูปภาพ, รูปร่างที่เติมด้วยรูปภาพ, เฟรมอ็อบเจกต์ OLE, เฟรมสื่อ, เฟรมซูม, ตาราง, แผนภูมิ, และอ็อบเจกต์ SmartArt สามารถอ้างอิงรูปภาพได้. บางประเภทรูปร่างเปิดเผยรูปภาพผ่านวัตถุการจัดรูปแบบที่ซ้อนกัน, ดังนั้นการตรวจสอบแบบง่ายด้วย [getPictureFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/#getPictureFormat) หรือ [getFillFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/shape/#getFillFormat) อาจไม่เพียงพอ.

**ฉันสามารถดึงภาพย่อที่แสดงสำหรับเฟรมวิดีโอได้หรือไม่?**

ได้. ใช้ [VideoFrame](https://reference.aspose.com/slides/th/python-java/aspose.slides/videoframe/) และอ่าน [getPictureFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/pictureframe/#getPictureFormat), [getPicture](https://reference.aspose.com/slides/th/python-java/aspose.slides/picturefillformat/#getPicture), และ [getImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/picture/#getImage). วิธีนี้ดึงภาพโปสเตอร์ที่เก็บร่วมกับเฟรมวิดีโอ, ไม่ใช่เฟรมที่สร้างจากไฟล์วิดีโอ.

**ฉันจะกำหนดว่ารูปร่างใดใช้รูปภาพเฉพาะจากคอลเลกชันรูปภาพของงานนำเสนอได้อย่างไร?**

Aspose.Slides ไม่จัดเก็บลิงก์ย้อนกลับจาก [PPImage](https://reference.aspose.com/slides/th/python-java/aspose.slides/ppimage/) ไปยังรูปร่าง. ให้สร้างการแมประหว่างการท่อง: ทุกครั้งที่พบการอ้างอิงรูปภาพ, บันทึกหมายเลขสไลด์, เส้นทางรูปร่าง, และแฮชหรือรายการคอลเลกชันของรูปภาพ.

**ฉันสามารถดึงรูปภาพที่ฝังอยู่ในอ็อบเจกต์ OLE, เช่น เอกสารที่แนบมาด้วย, ได้หรือไม่?**

คุณสามารถดึงภาพตัวอย่างของสไลด์จาก [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/th/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) ได้. อย่างไรก็ตาม, ตัวอย่างนั้นไม่ใช่เอกสารที่ฝังอยู่. หากต้องการดึงรูปภาพจากไฟล์ที่ฝังอยู่, ให้ดึงข้อมูล OLE แล้วตรวจสอบด้วยเครื่องมือที่เหมาะสมสำหรับประเภทไฟล์นั้น.