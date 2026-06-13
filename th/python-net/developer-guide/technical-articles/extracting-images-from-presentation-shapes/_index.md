---
title: สกัดภาพจากรูปทรงในงานนำเสนอด้วย Python
linktitle: ภาพจากรูปทรง
type: docs
weight: 90
url: /th/python-net/extracting-images-from-presentation-shapes/
keywords:
- สกัดภาพ
- ดึงภาพ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Python
- Aspose.Slides
description: "สกัดภาพจากรูปทรงในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Python ผ่าน .NET - โซลูชันที่รวดเร็วและเป็นมิตรต่อการเขียนโค้ด"
---
## **ภาพรวม**

ภาพในงานนำเสนออาจปรากฏในหลายประเภทของรูปทรง: เช่น กรอบภาพธรรมดา, การเติมรูปภาพที่ใช้กับรูปทรง, ภาพตัวอย่างของวัตถุ OLE, รูปย่อของเฟรมวิดีโอหรือเสียง, ภาพซูม, หรือภาพที่ซ้อนอยู่ภายในตาราง, แผนภูมิ, และรูปทรง SmartArt. Aspose.Slides จัดเก็บภาพเหล่านั้นในคอลเลกชันภาพของงานนำเสนอ, ที่เปิดเผยผ่านวัตถุ [ImageCollection](https://reference.aspose.com/slides/th/python-net/aspose.slides/imagecollection/) และ [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) 

หากคุณต้องการส่งออกทุกแหล่งภาพที่ฝังอยู่ในงานนำเสนอ, ให้วนลูปผ่าน `presentation.images`. บทความนี้มุ่งเน้นงานที่แตกต่าง: การสำรวจรูปทรงเพื่อหาตำแหน่งที่ภาพถูกใช้งานบนสไลด์, เพื่อให้ไฟล์ที่บันทึกมีบริบทที่เป็นประโยชน์เช่น หมายเลขสไลด์, ตำแหน่งรูปทรง, และประเภทแหล่งที่มา (กรอบภาพ, ภาพเติม, ตัวอย่างสื่อ, ตัวอย่าง OLE, หรือภาพซูม).

{{% alert title="Tip" color="primary" %}}
ใช้คุณสมบัติ `binary_data` ของ [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) เพื่อรักษาข้อมูลภาพที่เข้ารหัสไว้เดิมและประเภทไฟล์. ใช้คุณสมบัติ `image` ร่วมกับ `save` เมื่อคุณต้องการทำให้ผลลัพธ์เป็นรูปแบบเดียวกันเช่น PNG.
{{% /alert %}}

## **เมธอดช่วยเหลือที่ใช้ร่วมกัน**

เมธอดช่วยเหลือด้านล่างทำให้ตัวอย่างสั้นลง. `save_original_image` จะเขียนไบต์เดิมที่ฝังอยู่, เลือกนามสกุลที่ปลอดภัยจาก MIME type, และข้ามไฟล์ภาพซ้ำโดยใช้แฮช SHA-256.

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

## **สกัดภาพจากกรอบภาพ (Picture Frames)**

ใช้วิธีนี้สำหรับรูปภาพที่แทรกเป็นอ็อบเจ็กต์อิสระ. [PictureFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/pictureframe/) เก็บรูปภาพไว้ใน `picture_format.picture.image`, ซึ่งคืนค่าเป็นวัตถุ [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/).

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

## **สกัดภาพจากรูปทรงที่เติมด้วยภาพ (Picture‑Filled Shapes)**

รูปทรงสามารถใช้รูปภาพเป็นพื้นหลังได้. ตรวจสอบประเภทการเติมของรูปทรงก่อน: หากไม่เป็น [FillType.PICTURE](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/), จะไม่มีรูปภาพให้สกัดจากการเติมนั้น. ตัวอย่างด้านล่างจัดการกับอ็อบเจ็กต์ [AutoShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/autoshape/) และบันทึกแต่ละภาพเป็น PNG ผ่านคุณสมบัติ `image` ของ [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/).

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

## **สกัดภาพตัวอย่างจากกรอบวัตถุ OLE (OLE Object Frames)**

[OleObjectFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/oleobjectframe/) สามารถมีภาพทดแทนที่ PowerPoint ใช้เป็นตัวอย่างของวัตถุบนสไลด์. ภาพนี้สามารถเข้าถึงได้ผ่าน `substitute_picture_format.picture.image`. การสกัดภาพนี้จะให้ภาพตัวอย่าง, ไม่ใช่เนื้อหาแพคเกจ OLE ที่ฝังอยู่.

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

## **สกัดภาพตัวอย่างจากกรอบวิดีโอ (Video Frames)**

[VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/) สามารถเก็บภาพตัวอย่างใน `picture_format.picture.image`. นี่คือโปสเตอร์หรือรูปย่อที่แสดงบนสไลด์, ไม่ใช่เฟรมที่ถอดรหัสจากสตรีมวิดีโอ.

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

## **สกัดภาพตัวอย่างจากกรอบเสียง (Audio Frames)**

[AudioFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/) สามารถเก็บรูปย่อใน `picture_format.picture.image`. นี่คือภาพที่แสดงสำหรับอ็อบเจ็กต์เสียงบนสไลด์.

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

## **สกัดภาพจากวัตถุซูม (Zoom Objects)**

[ZoomFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/zoomframe/) และ [SectionZoomFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/sectionzoomframe/) สามารถใช้ภาพกำหนดเอง. อ่าน `zoom_image` จากกรอบซูม.

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

## **สกัดภาพจากกรอบซูมสรุป (Summary Zoom Frames)**

[SummaryZoomFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/summaryzoomframe/) ก็เป็นรูปทรงหนึ่งเช่นกัน. รายการส่วนของมันอาจใช้ภาพกำหนดเอง, ซึ่งเปิดเผยผ่านคุณสมบัติ `zoom_image` ของแต่ละส่วนซูมสรุป.

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

## **สกัดภาพจากรูปทรงตาราง (Table Shapes)**

[Table](https://reference.aspose.com/slides/th/python-net/aspose.slides/table/) เป็นรูปทรง. ภาพในตารางส่วนใหญ่จะถูกเก็บเป็นการเติมรูปภาพในเซลล์ตาราง.

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

## **สกัดภาพจากรูปทรงแผนภูมิ (Chart Shapes)**

[Chart](https://reference.aspose.com/slides/th/python-net/aspose.slides.charts/chart/) คือรูปทรง. ตัวอย่างด้านล่างสกัดภาพจากการเติมรูปภาพของพื้นที่แผนภูมิ.

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

## **สกัดภาพจากรูปทรง SmartArt**

[SmartArt](https://reference.aspose.com/slides/th/python-net/aspose.slides.smartart/smartart/) เป็นอ็อบเจ็กต์รูปทรง. ขึ้นอยู่กับการจัดวางของ SmartArt, ภาพอาจถูกเก็บในการเติมจุดหัวข้อของโหนดหรือในรูปแบบการเติมของรูปทรงโหนด.

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

## **รวมภาพที่อยู่ภายในรูปทรงกลุ่ม (Grouped Shapes)**

รูปทรงที่จัดกลุ่มมีคอลเลกชันรูปทรกของตัวเอง. เมธอดช่วยเหลือ `enumerate_shapes` มีตัวเลือก `include_grouped_shapes`. ตั้งค่าเป็น `True` เมื่อคุณต้องการตรวจสอบรูปทรงภายในอ็อบเจ็กต์ [GroupShape](https://reference.aspose.com/slides/th/python-net/aspose.slides/groupshape/). ตัวอย่างด้านล่างสกัดภาพจากกรอบภาพ, รูปทรงที่เติมภาพ, ตัวอย่าง OLE, รูปย่อของเฟรมวิดีโอ, และรูปย่อของเฟรมเสียง. เพื่อรวมภาพตาราง, แผนภูมิ, SmartArt, และซูมสรุปด้วย, ให้นำตรรกะการสกัดเฉพาะจากส่วนก่อนหน้าไปใช้ซ้ำขณะยังคงใช้การสำรวจรูปทรงแบบเรียกซ้ำเดียวกัน.

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

## **กรณีขอบเขตและหมายเหตุเชิงปฏิบัติ**

- **ภาพซ้ำ:** รูปทรงหลายรูปอาจอ้างอิงภาพเดียวกันหรือภาพที่แยกกันแต่มีไบต์เท่ากัน. ทำแฮชคุณสมบัติ `binary_data` ของ [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) ก่อนเขียนไฟล์หากคุณต้องการไฟล์ผลลัพธ์หนึ่งไฟล์ต่อภาพที่มีความเป็นเอกลักษณ์.
- **ข้อมูลเดิม vs. ผลลัพธ์ที่แปลง:** การบันทึกคุณสมบัติ `binary_data` ของ [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) รักษาข้อมูล JPEG, PNG, GIF, SVG, EMF หรือ WMF ที่ฝังไว้. การบันทึกคุณสมบัติ `image` ผ่าน `save` มีประโยชน์เมื่อคุณต้องการรูปแบบผลลัพธ์สม่ำเสมอ.
- **ประเภทการเติมที่ไม่รองรับ:** รูปทรงที่เป็นสีทึบ, ไอศครีม, แบบลาย, หรือไม่มีการเติมจะไม่มีการเติมรูปภาพ. ตรวจสอบ [FillType](https://reference.aspose.com/slides/th/python-net/aspose.slides/filltype/) ก่อนอ่าน `picture_fill_format`.
- **รูปทรงที่จัดกลุ่ม:** คอลเลกชันรูปทรงระดับบนของสไลด์ไม่ทำการแบนกลุ่ม. ตรวจสอบ [GroupShape.shapes](https://reference.aspose.com/slides/th/python-net/aspose.slides/groupshape/shapes/) อย่างเรียกซ้ำเมื่อเนื้อหากลุ่มเป็นสิ่งสำคัญ.
- **ตัวอย่างวัตถุ OLE:** [OleObjectFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/oleobjectframe/) อาจเปิดเผยภาพตัวอย่างผ่าน `substitute_picture_format`, แต่ภาพนั้นเป็นเพียงตัวอย่างบนสไลด์ ไม่ใช่ไฟล์ที่ฝังอยู่ภายในวัตถุ OLE.
- **รูปย่อเฟรมวิดีโอ:** [VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/) อาจเปิดเผยภาพตัวอย่างผ่าน `picture_format`, แต่ภาพนั้นเป็นโปสเตอร์ที่แสดงบนสไลด์ ไม่ได้สกัดจากสตรีมวิดีโอ.
- **รูปย่อเฟรมเสียง:** [AudioFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/audioframe/) อาจเปิดเผยไอคอนหรือรูปย่อผ่าน `picture_format`; ไม่ใช่ข้อมูลเสียงที่ฝังอยู่.
- **ภาพซูม:** รูปทรงซูม, ซูมส่วน, และซูมสรุปอาจใช้วัตถุ [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) ที่กำหนดเองผ่าน `image`.
- **โมเดลรูปทรงซ้อนกัน:** อ็อบเจ็กต์ตาราง, แผนภูมิ, และ SmartArt ทำตามอินเทอร์เฟซ [Shape](https://reference.aspose.com/slides/th/python-net/aspose.slides/shape/), แต่ภาพของพวกมันมักถูกเก็บในเซลล์ตาราง, ส่วนประกอบแผนภูมิ, หรือวัตถุการจัดรูปแบบโหนด SmartArt ที่ซ้อนกัน.
- **รูปภาพที่ถูกตัดหรือแปรรูป:** การเข้าถึง [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) ให้คุณได้ทรัพยากรภาพที่จัดเก็บไว้. มันไม่ได้แสดงการตัด, ความโปร่งใส, การเปลี่ยนสี, การหมุน, หรือเอฟเฟกต์ภาพอื่น ๆ ที่รูปทรงทำ.

## **คำถามที่พบบ่อย (FAQ)**

**ฉันสามารถสกัดภาพต้นฉบับโดยไม่ตัด, ไม่มีเอฟเฟกต์, หรือการแปรรูปของรูปทรงได้หรือไม่?**

ใช่. เข้าถึงวัตถุ [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) แล้วเขียนคุณสมบัติ `binary_data` ไปยังดิสก์. วิธีนี้จะคงข้อมูลภาพที่เข้ารหัสไว้เดิมในงานนำเสนอ, ไม่ใช่วิธีที่ภาพแสดงบนสไลด์.

**ฉันสามารถส่งออกภาพที่สกัดทั้งหมดเป็น PNG ได้หรือไม่?**

ใช่. ใช้คุณสมบัติ `image` ของ [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) เพื่อรับอ็อบเจ็กต์ภาพ, แล้วเรียก `save` พร้อมกับ [ImageFormat.PNG](https://reference.aspose.com/slides/th/python-net/aspose.slides/imageformat/). วิธีนี้จะแปลงผลลัพธ์และอาจไม่คงประเภทไฟล์หรือข้อมูลเวกเตอร์เดิม.

**ฉันจะหลีกเลี่ยงการบันทึกภาพเดียวกันหลายครั้งอย่างไร?**

ใช้แฮชของคุณสมบัติ `binary_data` ของ [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) และเก็บแฮชไว้ในชุด (set). หากภาพใหม่มีแฮชที่มีอยู่แล้ว, ให้ข้ามหรือบันทึกการอ้างอิงอื่นไปยังไฟล์ผลลัพธ์ที่มีอยู่.

**ทำไมบางรูปทรงไม่สร้างภาพ?**

กรอบภาพ, รูปทรงที่เติมภาพ, กรอบวัตถุ OLE, กรอบสื่อ, กรอบซูม, ตาราง, แผนภูมิ, และอ็อบเจ็กต์ SmartArt สามารถอ้างอิงภาพได้. บางประเภทรูปทรงอาจเปิดเผยภาพผ่านอ็อบเจ็กต์การจัดรูปแบบที่ซ้อนอยู่, ดังนั้นการตรวจสอบ `picture_format` หรือ `fill_format` อย่างง่ายอาจไม่เพียงพอ.

**ฉันสามารถสกัดรูปย่อที่แสดงสำหรับเฟรมวิดีโอได้หรือไม่?**

ใช่. ใช้ [VideoFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/videoframe/) แล้วอ่าน `picture_format.picture.image`. วิธีนี้จะสกัดภาพโปสเตอร์ที่เก็บพร้อมกับเฟรมวิดีโอ, ไม่ใช่เฟรมที่สร้างจากไฟล์วิดีโอ.

**ฉันจะกำหนดรูปทรงใดบ้างที่ใช้ภาพเฉพาะจากคอลเลกชันภาพของงานนำเสนอ?**

Aspose.Slides ไม่เก็บลิงก์ย้อนกลับจาก [PPImage](https://reference.aspose.com/slides/th/python-net/aspose.slides/ppimage/) ไปยังรูปทรง. ให้สร้างแผนที่ระหว่างการสำรวจ: ทุกครั้งที่พบการอ้างอิงภาพ, บันทึกหมายเลขสไลด์, เส้นทางรูปทรง, และแฮชหรือรายการคอลเลกชันของภาพ.

**ฉันสามารถสกัดภาพที่ฝังอยู่ภายในวัตถุ OLE, เช่น เอกสารแนบ, ได้หรือไม่?**

คุณสามารถสกัดภาพตัวอย่างของวัตถุ OLE จากคุณสมบัติ `substitute_picture_format` ของ [OleObjectFrame](https://reference.aspose.com/slides/th/python-net/aspose.slides/oleobjectframe/). อย่างไรก็ตาม, ตัวอย่างนั้นไม่ใช่เอกสารที่ฝังอยู่จริง. หากต้องการสกัดภาพจากไฟล์ที่ฝังอยู่, ให้ดึงข้อมูล OLE แล้วตรวจสอบด้วยเครื่องมือที่เหมาะสมกับประเภทไฟล์นั้น.