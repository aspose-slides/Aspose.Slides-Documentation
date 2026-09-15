---
title: استخراج الصور من أشكال العرض التقديمي باستخدام Python عبر Java
linktitle: صورة من الشكل
type: docs
weight: 100
url: /ar/python-java/extracting-images-from-presentation-shapes/
keywords:
- استخراج صورة
- استرجاع صورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "استخراج الصور من الأشكال في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لPython عبر Java - حل سريع وصديق للمطور."
---
## **نظرة عامة**

يمكن أن تظهر الصور في العرض التقديمي بأكثر من نوع شكل: كإطارات صور عادية، أو كملء صور يُطبق على الأشكال، أو كصور معاينة لكائنات OLE، أو كصورة مصغرة لإطار فيديو أو صوت، أو كصور تكبير، أو كصور متداخلة داخل جداول، مخططات، وأشكال SmartArt. يتم حفظ هذه الصور في مجموعة صور العرض التقديمي في Aspose.Slides، والتي يمكن الوصول إليها عبر كائنات [ImageCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagecollection/) و[PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/).

إذا كنت بحاجة فقط لتصدير كل مورد صورة مضمّن في العرض التقديمي، قم بالتكرار عبر [Presentation.getImages](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getImages). يركّز هذا المقال على مهمة مختلفة: استعراض الأشكال للعثور على الأماكن التي تُستخدم فيها الصور على الشرائح، بحيث يمكن للملفات المحفوظة الحفاظ على سياق مفيد مثل رقم الشريحة، موضع الشكل، ونوع المصدر (إطار صورة، صورة ملء، معاينة وسائط، معاينة OLE، أو صورة تكبير).

{{% alert title="Tip" color="success" %}}

استخدم [PPImage.getBinaryData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/#getBinaryData) للحفاظ على بيانات الصورة المشفرة الأصلية ونوع الملف. استخدم [PPImage.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/#getImage) مع `save` عندما تريد توحيد الناتج إلى تنسيق معين مثل PNG.

{{% /alert %}}

## **وظائف المساعد المشتركة**

احفظ وظائف المساعد المشتركة أدناه في ملف `image_helpers.py` بجانب سكريبتات الأمثلة. تُبقي هذه الوظائف الأمثلة مختصرة. تقوم الدالة `save_original_image` بكتابة البايتات المضمّنة الأصلية، وتختار امتدادًا آمنًا من نوع MIME، وتتخطّى ملفات الصور المكررة باستخدام تجزئة SHA-256.

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

## **استخراج الصور من إطارات الصور**

استخدم هذا النهج للصور المُدخلة ككائنات مستقلة. توفر كائنات [PictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/) إمكانية الوصول إلى صورتها عبر [getPictureFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/#getPictureFormat)، [getPicture](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#getPicture)، و[getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picture/#getImage)، والتي تُعيد كائنًا من النوع [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/).

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

## **استخراج الصور من الأشكال المملوءة بالصور**

يمكن للأشكال أن تستخدم صورة كملء لها. تحقق أولاً من نوع ملء الشكل: إذا لم يكن [FillType.Picture](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filltype/) فليس هناك صورة لاستخراجها من ذلك الملء. المثال أدناه يتعامل مع كائنات [AutoShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/autoshape/) ويحفظ كل صورة بصيغة PNG عبر [PPImage.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/#getImage).

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

## **استخراج صور المعاينة من إطارات كائنات OLE**

يمكن لإطار [OleObjectFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleobjectframe/) أن يحتوي على صورة بديلة يستخدمها PowerPoint كمعاينة للكائن على الشريحة. تتوفر هذه الصورة عبر [getSubstitutePictureFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat)، [getPicture](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#getPicture)، و[getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picture/#getImage). استخراج هذه الصورة يعطيك صورة المعاينة، وليس محتوى حزمة OLE المضمّنة.

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

## **استخراج صور المعاينة من إطارات الفيديو**

يمكن لإطار [VideoFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/) أيضًا أن يخزن صورة معاينة في [getPictureFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/#getPictureFormat)، [getPicture](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#getPicture)، و[getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picture/#getImage). هذه هي الصورة أو الملصق المعروض على الشريحة، ليست إطارًا مُستخرجًا من تدفق الفيديو.

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

## **استخراج صور المعاينة من إطارات الصوت**

يمكن لإطار [AudioFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/) أن يخزن صورة مصغرة في [getPictureFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/#getPictureFormat)، [getPicture](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#getPicture)، و[getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picture/#getImage). هذه هي الصورة المعروضة لكائن الصوت على الشريحة.

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

## **استخراج الصور من كائنات التكبير**

يمكن للأشكال [ZoomFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/zoomframe/) و[SectionZoomFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/sectionzoomframe/) أن تستخدم صورًا مخصصة. اقرأ [getZoomImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/zoomobject/#getZoomImage) من إطار التكبير.

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

## **استخراج الصور من إطارات التكبير المختصر**

إطار [SummaryZoomFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/summaryzoomframe/) هو أيضًا شكل. يمكن لعناصر القسم الخاصة به أن تستخدم صورًا مخصصة، تُعرض عبر طريقة [getZoomImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/zoomobject/#getZoomImage) لكل قسم من أقسام التكبير المختصر.

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

## **استخراج الصور من أشكال الجداول**

الجدول [Table](https://reference.aspose.com/slides/ar/python-java/aspose.slides/table/) هو شكل. تُخزن الصور في جدول عادةً كملء صور في خلايا الجدول.

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

## **استخراج الصور من أشكال المخططات**

المخطط [Chart](https://reference.aspose.com/slides/ar/python-java/aspose.slides/chart/) هو شكل. المثال أدناه يستخرج صورة من ملء صورة منطقة المخطط.

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

## **استخراج الصور من أشكال SmartArt**

كائن [SmartArt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/smartart/) هو شكل. اعتمادًا على تخطيط SmartArt، قد تُخزن الصور في ملء نقاط الرصاص للعقد أو في صيغ ملء أشكال العقد.

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

## **تضمين الصور داخل الأشكال المجمعة**

الأشكال المجمعة تحتوي على مجموعات أشكال خاصة بها. المساعد المشترك `enumerate_shapes` يحتوي على خيار `include_grouped_shapes`. اضبطه على `True` عندما تريد فحص الأشكال داخل كائنات [GroupShape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/groupshape/). المثال أدناه يستخرج الصور من إطارات الصور، الأشكال المملوءة بالصور، معاينات كائنات OLE، صور مصغرة لإطارات الفيديو، وصور مصغرة لإطارات الصوت. لتضمين صور الجداول، المخططات، SmartArt، وصور التكبير المختصر أيضًا، أعد استخدام منطق الاستخراج المتخصص من الأقسام السابقة مع الحفاظ على نفس استعراض الأشكال المتكرر.

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

## **الحالات الخاصة والملاحظات العملية**

- **الصور المكررة:** قد تشير أشكال متعددة إلى نفس الصورة أو إلى صور منفصلة ذات بايتات متطابقة. احسب تجزئة [PPImage.getBinaryData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/#getBinaryData) قبل كتابة الملفات إذا رغبت بملف واحد لكل صورة فريدة.
- **البيانات الأصلية مقابل الناتج المحوّل:** حفظ [PPImage.getBinaryData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/#getBinaryData) يحافظ على بيانات JPEG، PNG، GIF، SVG، EMF، أو WMF المضمّنة. حفظ [PPImage.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/#getImage) عبر `save` مفيد عندما تريد تنسيق ناتج موحد.
- **أنواع الملء غير المدعومة:** الأشكال ذات الملء الصلب، المتدرج، النمط، أو بدون ملء لا تحتوي على ملء صورة. تحقق من [FillType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/filltype/) قبل قراءة [getPictureFillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/fillformat/#getPictureFillFormat).
- **الأشكال المجمعة:** مجموعة أشكال الشريحة العليا لا تُسطّح المجموعات. قم بفحص [GroupShape.getShapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/groupshape/#getShapes) بصورة متكررة عندما تكون محتويات المجموعة مهمة.
- **معاينات كائنات OLE:** قد يُظهر إطار [OleObjectFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleobjectframe/) صورة معاينة عبر [getSubstitutePictureFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat)، لكن هذه الصورة هي فقط معاينة الشريحة. ليست الملف المضمّن داخل كائن OLE.
- **مصغرات إطار الفيديو:** قد يُظهر إطار [VideoFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/) صورة معاينة عبر [getPictureFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/#getPictureFormat)، لكن هذه الصورة هي فقط الملصق المعروض على الشريحة. ليست استخراجًا من تدفق الفيديو.
- **مصغرات إطار الصوت:** قد يُظهر إطار [AudioFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/audioframe/) أيقونة أو صورة مصغرة عبر [getPictureFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/#getPictureFormat)؛ ليست بيانات الصوت المضمّنة.
- **صور التكبير:** قد تستخدم أشكال التكبير للشرائح، القسم، والتكبير المختصر صورًا مخصصة من نوع [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) عبر [getZoomImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/zoomobject/#getZoomImage).
- **نماذج الأشكال المتداخلة:** كائنات الجدول، المخطط، وSmartArt تُنفّذ واجهة [Shape](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/)، لكن صورها غالبًا ما تُخزن في تنسيقات خلايا الجدول، عناصر المخطط، أو تنسيقات عقد SmartArt.
- **الصور المقتطعة أو المحوّلة:** الوصول إلى [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) يمنحك المورد الصورة المخزن. لا يُطبق قطع، شفافية، إعادة تلوين، دوران أو أي تأثيرات بصرية أخرى يطبقها الشكل.

## **الأسئلة الشائعة**

**هل يمكنني استخراج الصورة الأصلية دون قص أو تأثيرات أو تحويلات الشكل؟**

نعم. اعمل على كائن [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) واكتب [PPImage.getBinaryData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/#getBinaryData) إلى القرص. هذا يحافظ على الصورة المشفرة الأصلية المخزنة في العرض التقديمي، وليس على طريقة عرض الصورة على الشريحة.

**هل يمكنني تصدير كل صورة مُستخرجة كـ PNG؟**

نعم. استخدم [PPImage.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/#getImage) للحصول على كائن صورة، ثم استدعِ `save` مع [ImageFormat.Png](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imageformat/). هذا يُحوّل الناتج وقد لا يحافظ على نوع الملف الأصلي أو البيانات المتجهية.

**كيف أتجنب حفظ الصورة نفسها أكثر من مرة؟**

استخدم تجزئة [PPImage.getBinaryData](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/#getBinaryData) واحفظ التجزئات في مجموعة. إذا كان للصورة الجديدة تجزئة موجودة بالفعل، فتجاوزها أو سجّل مرجعًا آخر للملف الناتج الموجود.

**لماذا لا تُنتج بعض الأشكال صورة؟**

إطارات الصور، الأشكال المملوءة بالصور، إطارات كائنات OLE، إطارات الوسائط، إطارات التكبير، الجداول، المخططات، وكائنات SmartArt يمكن أن تُشير إلى صور. بعض أنواع الأشكال تُظهر الصور عبر كائنات تنسيق متداخلة، لذا فإن فحص بسيط لـ [getPictureFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/#getPictureFormat) أو [getFillFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getFillFormat) قد لا يكون كافيًا.

**هل يمكنني استخراج الصورة المصغرة المعروضة لإطار الفيديو؟**

نعم. استخدم [VideoFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/videoframe/) واقرأ [getPictureFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/#getPictureFormat)، [getPicture](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picturefillformat/#getPicture)، و[getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picture/#getImage). هذا يستخرج صورة الملصق المخزنة مع إطار الفيديو، وليس إطارًا مُستخرجًا من ملف الفيديو.

**كيف يمكنني تحديد أي الأشكال تستخدم صورة معينة من مجموعة صور العرض التقديمي؟**

لا يخزن Aspose.Slides روابط عكسية من [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) إلى الأشكال. أنشئ خريطة أثناء الاستعراض: كلما وجدت إشارة إلى صورة، سجّل رقم الشريحة، مسار الشكل، وتجزئة الصورة أو عنصر المجموعة.

**هل يمكنني استخراج الصور المضمّنة داخل كائنات OLE، مثل المستندات المرفقة؟**

يمكنك استخراج معاينة الشريحة لكائن OLE عبر [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat). ومع ذلك، هذه المعاينة ليست المستند المضمّن نفسه. لاستخراج الصور من داخل الملف المضمّن، استخرج بيانات OLE وافحصها بأدوات مخصصة لنوع ذلك الملف.