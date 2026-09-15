---
title: استخراج تصاویر از اشکال ارائه در پایتون از طریق جاوا
linktitle: تصویر از شکل
type: docs
weight: 100
url: /fa/python-java/extracting-images-from-presentation-shapes/
keywords:
- استخراج تصویر
- بازیابی تصویر
- پاورپوینت
- OpenDocument
- ارائه
- پایتون
- جاوا
- Aspose.Slides
description: "تصاویر را از اشکال در ارائه‌های PowerPoint و OpenDocument با Aspose.Slides برای پایتون از طریق جاوا استخراج کنید - راه‌حل سریع و مناسب برای کد."
---
## **نمای کلی**

تصاویر در یک ارائه می‌توانند در چندین نوع شکل ظاهر شوند: به عنوان قاب تصویر معمولی، به عنوان پر شدن تصویر به اشکال اعمال شده، به عنوان پیش‌نمایش شیء OLE، به عنوان تصویر بندانگشتی فریم ویدیو یا صدا، به عنوان تصویر زوم، یا به عنوان تصاویری تو در تو داخل اشکال جدول، نمودار و SmartArt. Aspose.Slides این تصاویر را در مجموعه تصویر ارائه نگهداری می‌کند که از طریق اشیاء [ImageCollection](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imagecollection/) و [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) در دسترس است.

اگر فقط نیاز دارید تمام منابع تصویری جاسازی شده در یک ارائه را صادر کنید، از [Presentation.getImages](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/#getImages) پیمایش کنید. این مقاله بر یک کار متفاوت تمرکز دارد: پیمایش اشکال برای یافتن مکان‌های استفاده از تصاویر در اسلایدها، به طوری که فایل‌های ذخیره شده بتوانند زمینه مفیدی مانند شماره اسلاید، موقعیت شکل و نوع منبع (قاب تصویر، تصویر پرشده، پیش‌نمایش رسانه، پیش‌نمایش OLE یا تصویر زوم) را حفظ کنند.

{{% alert title="Tip" color="success" %}}
از [PPImage.getBinaryData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/#getBinaryData) برای حفظ داده‌های تصویر اصلی کدگذاری‌شده و نوع فایل استفاده کنید. از [PPImage.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/#getImage) همراه با `save` وقتی می‌خواهید خروجی را به قالب خاصی مانند PNG نرمال کنید، استفاده کنید.
{{% /alert %}}

## **توابع کمکی مشترک**

توابع کمکی مشترک زیر را در فایلی به نام `image_helpers.py` در کنار اسکریپت‌های نمونه ذخیره کنید. این توابع مثال‌ها را کوتاه نگه می‌دارند. `save_original_image` بایت‌های اصلی جاسازی‌شده را می‌نویسد، پسوند ایمن را بر پایه نوع MIME انتخاب می‌کند و از ذخیره باینری‌های تکراری تصویر بر پایه هش SHA‑256 جلوگیری می‌کند.

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

## **استخراج تصاویر از قاب‌های تصویر**

از این روش برای تصاویری که به عنوان اشیاء مستقل وارد شده‌اند استفاده کنید. یک [PictureFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/) دسترسی به تصویر خود را از طریق [getPictureFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/#getPictureFormat)، [getPicture](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillformat/#getPicture) و [getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picture/#getImage) که یک شیء [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) را برمی‌گرداند، فراهم می‌کند.

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

## **استخراج تصاویر از اشکال پرشده با تصویر**

اشکال می‌توانند از یک تصویر به عنوان پر شدن استفاده کنند. ابتدا نوع پر شدن شکل را بررسی کنید: اگر برابر با [FillType.Picture](https://reference.aspose.com/slides/fa/python-java/aspose.slides/filltype/) نباشد، تصویری برای استخراج از آن پر شدن وجود ندارد. مثال زیر اشیاء [AutoShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/autoshape/) را پردازش می‌کند و هر تصویر را از طریق [PPImage.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/#getImage) به صورت PNG ذخیره می‌کند.

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

## **استخراج تصاویر پیش‌نمایش از قاب‌های شیء OLE**

یک [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) می‌تواند تصویر جایگزینی داشته باشد که PowerPoint آن را به عنوان پیش‌نمایش شیء در اسلاید استفاده می‌کند. این تصویر از طریق [getSubstitutePictureFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat)، [getPicture](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillformat/#getPicture) و [getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picture/#getImage) در دسترس است. استخراج این تصویر پیش‌نمایش را می‌دهد، نه محتوای بسته OLE جاسازی‌شده.

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

## **استخراج تصاویر پیش‌نمایش از قاب‌های ویدیو**

یک [VideoFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/) نیز می‌تواند تصویر پیش‌نمایش را در [getPictureFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/#getPictureFormat)، [getPicture](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillformat/#getPicture) و [getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picture/#getImage) ذخیره کند. این تصویر پوستر یا بندانگشتی‌ای است که در اسلاید نشان داده می‌شود، نه فریمی که از جریان ویدیو استخراج شده باشد.

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

## **استخراج تصاویر پیش‌نمایش از قاب‌های صدا**

یک [AudioFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/) می‌تواند یک تصویر بندانگشتی را در [getPictureFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/#getPictureFormat)، [getPicture](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillformat/#getPicture) و [getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picture/#getImage) ذخیره کند. این تصویری است که برای شیء صدا در اسلاید نشان داده می‌شود.

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

## **استخراج تصاویر از اشیاء زوم**

اشکال [ZoomFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/zoomframe/) و [SectionZoomFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/sectionzoomframe/) می‌توانند تصاویر سفارشی استفاده کنند. از [getZoomImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/zoomobject/#getZoomImage) در قاب زوم بخوانید.

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

## **استخراج تصاویر از قاب‌های زوم خلاصه**

یک [SummaryZoomFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/summaryzoomframe/) نیز یک شکل است. آیتم‌های بخش آن می‌توانند تصاویر سفارشی داشته باشند که از طریق متد [getZoomImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/zoomobject/#getZoomImage) هر بخش زوم خلاصه در دسترس است.

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

## **استخراج تصاویر از اشکال جدول**

یک [Table](https://reference.aspose.com/slides/fa/python-java/aspose.slides/table/) یک شکل است. تصاویر در جدول معمولاً به عنوان پر شدن تصویر در سلول‌های جدول ذخیره می‌شوند.

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

## **استخراج تصاویر از اشکال نمودار**

یک [Chart](https://reference.aspose.com/slides/fa/python-java/aspose.slides/chart/) یک شکل است. مثال زیر تصویری را از پر شدن تصویر ناحیه نمودار استخراج می‌کند.

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

## **استخراج تصاویر از اشکال SmartArt**

یک شیء [SmartArt](https://reference.aspose.com/slides/fa/python-java/aspose.slides/smartart/) یک شکل است. بسته به طرح‌بندی SmartArt، ممکن است تصاویر در پر شدن گلوله گره‌ها یا در فرمت‌های پر شدن اشکال گره‌ها ذخیره شوند.

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

## **شمول تصاویر داخل اشکال گروه‌بندی‌شده**

اشکال گروه‌بندی‌شده مجموعه‌های شکل خود را دارند. تابع کمکی مشترک `enumerate_shapes` گزینه `include_grouped_shapes` دارد. وقتی می‌خواهید اشکال داخل اشیاء [GroupShape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/groupshape/) را بررسی کنید، آن را روی `True` تنظیم کنید. مثال زیر تصاویر را از قاب‌های تصویر، اشکال پرشده با تصویر، پیش‌نمایش‌های شیء OLE، تصویر بندانگشتی فریم ویدیو و تصویر بندانگشتی فریم صدا استخراج می‌کند. برای شمول تصاویر جدول، نمودار، SmartArt و زوم خلاصه نیز می‌توانید منطق استخراج تخصصی بخش‌های قبلی را دوباره استفاده کنید و همان پیمایش بازگشتی اشکال را حفظ کنید.

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

## **موارد ویژه و نکات عملی**

- **تصاویر تکراری:** ممکن است چندین شکل به یک تصویر یا به تصاویر جداگانه با بایت‌های یکسان اشاره کنند. قبل از نوشتن فایل‌ها، [PPImage.getBinaryData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/#getBinaryData) را هش کنید تا برای هر تصویر منحصر به‌فرد یک فایل خروجی داشته باشید.
- **داده اصلی در مقابل خروجی تبدیل‌شده:** ذخیره‌سازی [PPImage.getBinaryData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/#getBinaryData) داده‌های JPEG، PNG، GIF, SVG, EMF یا WMF جاسازی‌شده را حفظ می‌کند. ذخیره‌سازی [PPImage.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/#getImage) از طریق `save` وقتی می‌خواهید قالب خروجی یکسانی داشته باشید، مفید است.
- **انواع پر شدن پشتیبانی‌نشده:** اشکال تک‌رنگ، گرادیان، الگوی و بدون پر شدن تصویر، پر شدن تصویری ندارند. قبل از خواندن [getPictureFillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/fillformat/#getPictureFillFormat) نوع پر شدن را از [FillType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/filltype/) بررسی کنید.
- **اشکال گروه‌بندی‌شده:** مجموعه شکل‌های سطح بالای اسلاید گروه‌ها را صاف نمی‌کند. وقتی محتویات گروه مهم است، به‌صورت بازگشتی [GroupShape.getShapes](https://reference.aspose.com/slides/fa/python-java/aspose.slides/groupshape/#getShapes) را بررسی کنید.
- **پیش‌نمایش شیء OLE:** یک [OleObjectFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/) ممکن است تصویر پیش‌نمایشی از طریق [getSubstitutePictureFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) ارائه دهد، اما این تصویر فقط پیش‌نمایش اسلاید است و محتوای فایل جاسازی‌شده در داخل شیء OLE نیست.
- **بندانگشتی فریم ویدیو:** یک [VideoFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/) ممکن است تصویر پیش‌نمایشی از طریق [getPictureFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/#getPictureFormat) ارائه دهد، اما این تصویر فقط پوستر نشان‌داده‌شده در اسلاید است و از جریان ویدیو استخراج نشده.
- **بندانگشتی فریم صدا:** یک [AudioFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/audioframe/) ممکن است از طریق [getPictureFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/#getPictureFormat) یک نماد یا بندانگشتی ارائه دهد؛ این تصویر داده‌ اصیل صدا نیست.
- **تصاویر زوم:** اشکال زوم اسلاید، زوم بخش و زوم خلاصه ممکن است از اشیاء سفارشی [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) از طریق [getZoomImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/zoomobject/#getZoomImage) استفاده کنند.
- **مدل‌های شکل تو در تو:** اشیاء جدول، نمودار و SmartArt همگی از [Shape](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/) ارث‌بری می‌کنند، اما تصاویر آن‌ها اغلب در سلول‌های جدول، عنصر نمودار یا اشیاء قالب‌بندی گره SmartArt تو در تو ذخیره می‌شوند.
- **تصاویر برش‌خورده یا تبدیل‌شده:** دسترسی به [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) منبع تصویری ذخیره‌شده را می‌دهد. این کار برش، شفافیت، تغییر رنگ، چرخش یا سایر اثرات بصری اعمال‌شده توسط شکل را رندر نمی‌کند.

## **سوالات متداول**

**آیا می‌توانم تصویر اصلی را بدون برش، اثرات یا تبدیل‌های شکل استخراج کنم؟**

بله. به شیء [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) دسترسی پیدا کنید و [PPImage.getBinaryData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/#getBinaryData) را روی دیسک بنویسید. این کار تصویر اصلی کدگذاری‌شده ذخیره‌شده در ارائه را حفظ می‌کند، نه شیوه‌ای که تصویر در اسلاید رندر می‌شود.

**آیا می‌توانم هر تصویر استخراج‌شده را به‌صورت PNG صادر کنم؟**

بله. از [PPImage.getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/#getImage) برای دریافت شیء تصویر استفاده کنید و سپس با [ImageFormat.Png](https://reference.aspose.com/slides/fa/python-java/aspose.slides/imageformat/) `save` را فراخوانی کنید. این کار خروجی را به PNG تبدیل می‌کند و ممکن است نوع فایل اصلی یا داده‌های برداری را حفظ نکند.

**چگونه می‌توانم از ذخیره‌سازی یک تصویر بیش از یک‌بار جلوگیری کنم؟**

هش [PPImage.getBinaryData](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/#getBinaryData) را محاسبه کنید و هش‌ها را در یک مجموعه نگهداری کنید. اگر تصویر جدیدی همان هش را داشته باشد، آن را نادیده بگیرید یا به فایل خروجی موجود ارجاع دیگری ثبت کنید.

**چرا برخی از اشکال تصویر تولید نمی‌کنند؟**

قاب‌های تصویر، اشکال پرشده با تصویر، قاب‌های شیء OLE، فریم‌های رسانه‌ای، فریم‌های زوم، جدول‌ها، نمودارها و اشیاء SmartArt می‌توانند به تصاویر ارجاع دهند. برخی انواع شکل‌ها تصاویر را از طریق اشیاء قالب‌بندی تو در تو ارائه می‌دهند، بنابراین بررسی ساده‌ای مانند [getPictureFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/#getPictureFormat) یا [getFillFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/shape/#getFillFormat) همیشه کافی نیست.

**آیا می‌توانم بندانگشتی نمایش داده‌شده برای فریم ویدیو را استخراج کنم؟**

بله. از [VideoFrame](https://reference.aspose.com/slides/fa/python-java/aspose.slides/videoframe/) استفاده کنید و [getPictureFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/pictureframe/#getPictureFormat)، [getPicture](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picturefillformat/#getPicture) و [getImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/picture/#getImage) را بخوانید. این کار تصویر پوستر ذخیره‌شده با فریم ویدیو را استخراج می‌کند، نه فریمی که از فایل ویدیو تولید شده باشد.

**چگونه می‌توانم تعیین کنم کدام شکل‌ها از یک تصویر خاص در مجموعه تصویر ارائه استفاده می‌کنند؟**

Aspose.Slides لینک معکوسی از [PPImage](https://reference.aspose.com/slides/fa/python-java/aspose.slides/ppimage/) به اشکال ذخیره نمی‌کند. در حین پیمایش یک نگاشت بسازید: هر بار که به یک ارجاع تصویر برخوردید، شماره اسلاید، مسیر شکل و هش یا آیتم مجموعه تصویر را ثبت کنید.

**آیا می‌توانم تصاویر جاسازی‌شده داخل اشیاء OLE، مانند اسناد پیوست‌شده را استخراج کنم؟**

می‌توانید پیش‌نمایش اسلاید شیء OLE را از طریق [OleObjectFrame.getSubstitutePictureFormat](https://reference.aspose.com/slides/fa/python-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) استخراج کنید. اما این پیش‌نمایش خود فایل سند جاسازی‌شده نیست. برای استخراج تصاویر از داخل فایل جاسازی‌شده، داده OLE را استخراج کنید و با ابزارهای مناسب برای آن نوع فایل بررسی کنید.