---
title: استخراج تصاویر از اشکال ارائه در پایتون
linktitle: تصویر از شکل
type: docs
weight: 90
url: /fa/python-net/extracting-images-from-presentation-shapes/
keywords:
- استخراج تصویر
- دریافت تصویر
- PowerPoint
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "تصاویر را از اشکال در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای پایتون از طریق .NET استخراج کنید - راه‌حل سریع و مناسب برای کدنویسی."
---
## **بررسی کلی**

تصاویر در یک ارائه می‌توانند در چندین نوع شکل ظاهر شوند: به عنوان فریم‌های تصویری عادی، به عنوان پرکردن تصویر اعمال شده به اشکال، به عنوان تصاویر پیش‌نمایش شیء OLE، به عنوان تصویرهای کوچک فریم ویدئو یا صدا، به عنوان تصاویر زوم، یا به عنوان تصاویر تو در تو داخل اشکال جدول، نمودار و SmartArt. Aspose.Slides این تصاویر را در مجموعه تصاویر ارائه ذخیره می‌کند که از طریق اشیاء [ImageCollection](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imagecollection/) و [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) در دسترس است.

اگر فقط نیاز به استخراج تمام منابع تصویری جاسازی شده در یک ارائه دارید، از `presentation.images` مرور کنید. این مقاله بر یک کار متفاوت تمرکز دارد: پیمایش اشکال برای یافتن مکان‌های استفاده از تصاویر در اسلایدها، به طوری که فایل‌های ذخیره‌شده بتوانند زمینه مفیدی مانند شماره اسلاید، موقعیت شکل و نوع منبع (فریم تصویر، تصویر پرکردن، پیش‌نمایش رسانه، پیش‌نمایش OLE یا تصویر زوم) را حفظ کنند.

{{% alert title="Tip" color="primary" %}}
از ویژگی `binary_data` در [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) برای حفظ داده‌های تصویر کدگذاری‌شده اصلی و نوع فایل استفاده کنید. وقتی می‌خواهید خروجی را به فرمت خاصی مانند PNG نرمال کنید، از ویژگی `image` همراه با `save` استفاده کنید.
{{% /alert %}}

## **متدهای کمکی مشترک**

متدهای کمکی زیر مثال‌ها را کوتاه نگه می‌دارند. `save_original_image` بایت‌های جاسازی‌شده اصلی را می‌نویسد، پسوند امنی را از نوع MIME انتخاب می‌کند و با استفاده از هش SHA-256 تصاویر تکراری باینری را رد می‌کند.

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

## **استخراج تصاویر از فریم‌های تصویر**

از این روش برای تصاویری که به عنوان اشیای مستقل وارد شده‌اند استفاده کنید. یک [PictureFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/pictureframe/) تصویر خود را در `picture_format.picture.image` ذخیره می‌کند که یک شیء [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) را برمی‌گرداند.

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

## **استخراج تصاویر از اشکال پر شده با تصویر**

اشکال می‌توانند یک تصویر را به عنوان پرکردن خود استفاده کنند. ابتدا نوع پرکردن شکل را بررسی کنید: اگر برابر با [FillType.PICTURE](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) نباشد، تصویری برای استخراج از آن پرکردن وجود ندارد. مثال زیر اشیاء [AutoShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/autoshape/) را پردازش می‌کند و هر تصویر را به‌صورت PNG از طریق ویژگی `image` در [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) ذخیره می‌کند.

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

## **استخراج تصاویر پیش‌نمایش از فریم‌های شیء OLE**

یک [OleObjectFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/oleobjectframe/) می‌تواند تصویر جایگزینی داشته باشد که PowerPoint به عنوان پیش‌نمایش شیء بر روی اسلاید استفاده می‌کند. این تصویر از طریق `substitute_picture_format.picture.image` در دسترس است. استخراج این تصویر پیش‌نمایش را می‌دهد، نه محتوای بسته OLE جاسازی‌شده.

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

## **استخراج تصاویر پیش‌نمایش از فریم‌های ویدئو**

یک [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) همچنین می‌تواند تصویر پیش‌نمایش را در `picture_format.picture.image` ذخیره کند. این پوستر یا تصویر کوچک است که بر روی اسلاید نشان داده می‌شود، نه فریمی استخراج‌شده از جریان ویدئو.

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

## **استخراج تصاویر پیش‌نمایش از فریم‌های صدا**

یک [AudioFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/) می‌تواند تصویر کوچک را در `picture_format.picture.image` ذخیره کند. این تصویری است که برای شیء صدا بر روی اسلاید نشان داده می‌شود.

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

## **استخراج تصاویر از اشیاء زوم**

اشکال [ZoomFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/zoomframe/) و [SectionZoomFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/sectionzoomframe/) می‌توانند از تصاویر سفارشی استفاده کنند. `zoom_image` را از فریم زوم بخوانید.

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

## **استخراج تصاویر از فریم‌های زوم خلاصه**

یک [SummaryZoomFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/summaryzoomframe/) نیز یک شکل است. موارد بخش آن می‌توانند از تصاویر سفارشی استفاده کنند که از طریق ویژگی `zoom_image` هر بخش زوم خلاصه در دسترس است.

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

## **استخراج تصاویر از اشکال جدول**

یک [Table](https://reference.aspose.com/slides/fa/python-net/aspose.slides/table/) یک شکل است. تصاویر در جدول معمولاً به‌عنوان پرکردن تصویر در سلول‌های جدول ذخیره می‌شوند.

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

## **استخراج تصاویر از اشکال نمودار**

یک [Chart](https://reference.aspose.com/slides/fa/python-net/aspose.slides.charts/chart/) یک شکل است. مثال زیر تصویری را از پرکردن تصویر ناحیه نمودار استخراج می‌کند.

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

## **استخراج تصاویر از اشکال SmartArt**

یک شیء [SmartArt](https://reference.aspose.com/slides/fa/python-net/aspose.slides.smartart/smartart/) یک شکل است. بسته به طرح‌بندی SmartArt، ممکن است تصاویر در پرکردن گلوله‌های گره یا در قالب‌های پرکردن شکل‌های گره ذخیره شوند.

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

## **شامل کردن تصاویر داخل اشکال گروه‌بندی شده**

اشکال گروه‌بندی شده مجموعه‌های شکل خود را دارند. متد کمکی مشترک `enumerate_shapes` گزینه `include_grouped_shapes` دارد. وقتی می‌خواهید اشکال داخل اشیای [GroupShape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/groupshape/) را بررسی کنید، آن را به `True` تنظیم کنید. مثال زیر تصاویر را از فریم‌های تصویری، اشکال پر شده با تصویر، پیش‌نمایش‌های شیء OLE، تصویرهای کوچک فریم‌های ویدئو و صدا استخراج می‌کند. برای شامل کردن تصاویر جدول، نمودار، SmartArt و زوم خلاصه نیز، منطق استخراج تخصصی بخش‌های قبلی را بازاستفاده کنید در حالی که همان پیمایش بازگشتی شکل را حفظ می‌کنید.

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

## **موارد خاص و نکات عملیاتی**

- **تصاویر تکراری:** چندین شکل ممکن است به همان تصویر یا به تصاویر جداگانه با بایت‌های یکسان اشاره کنند. قبل از نوشتن فایل‌ها `binary_data` در [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) را هش کنید تا برای هر تصویر منحصربه‌فرد یک فایل خروجی داشته باشید.
- **داده اصلی در مقابل خروجی تبدیل‌شده:** ذخیره ویژگی `binary_data` در [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) داده‌های JPEG، PNG، GIF، SVG، EMF یا WMF جاسازی‌شده را حفظ می‌کند. ذخیره ویژگی `image` از طریق `save` زمانی مفید است که می‌خواهید فرمت خروجی ثابت باشد.
- **انواع پرکردن پشتیبانی‌نشده:** اشکال با پرکردن ثابت، گرادیان، الگو و بدون پرکردن تصویری ندارند. قبل از خواندن `picture_fill_format` نوع پرکردن را با [FillType](https://reference.aspose.com/slides/fa/python-net/aspose.slides/filltype/) بررسی کنید.
- **اشکال گروه‌بندی شده:** مجموعه شکل‌های سطح بالا در اسلاید گروه‌ها را مسطح نمی‌کند. هنگامیکه محتوای گروه مهم است، به‌صورت بازگشتی [GroupShape.shapes](https://reference.aspose.com/slides/fa/python-net/aspose.slides/groupshape/shapes/) را بررسی کنید.
- **پیش‌نمایش‌های شیء OLE:** یک [OleObjectFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/oleobjectframe/) ممکن است تصویر پیش‌نمایشی از طریق `substitute_picture_format` ارائه دهد، اما این تصویر فقط پیش‌نمایش اسلاید است و نه فایل جاسازی‌شده داخل شیء OLE.
- **تصویرهای کوچک فریم ویدئو:** یک [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) ممکن است تصویر پیش‌نمایشی از طریق `picture_format` ارائه دهد، اما این تصویر فقط پوستر نمایش داده‌شده بر روی اسلاید است و از جریان ویدئو استخراج نمی‌شود.
- **تصویرهای کوچک فریم صدا:** یک [AudioFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/audioframe/) ممکن است یک آیکون یا تصویر کوچک از طریق `picture_format` ارائه دهد؛ این داده‌های صوتی جاسازی‌شده نیستند.
- **تصاویر زوم:** اشکال زوم اسلاید، زوم بخش و زوم خلاصه ممکن است از اشیاء سفارشی [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) از طریق `image` استفاده کنند.
- **مدل‌های شکل تو در تو:** اشیای جدول، نمودار و SmartArt رابط [Shape](https://reference.aspose.com/slides/fa/python-net/aspose.slides/shape/) را پیاده‌سازی می‌کنند، ولی تصاویرشان اغلب در سلول‌های جدول، عناصر نمودار یا قالب‌بندی گره‌های SmartArt تو در تو ذخیره می‌شوند.
- **تصاویر بریده یا تبدیل‌شده:** دسترسی به [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) منبع تصویر ذخیره‌شده را می‌دهد. این کار برش، شفافیت، تغییر رنگ، چرخش یا سایر افکت‌های بصری اعمال‌شده توسط شکل را رندر نمی‌کند.

## **پرسش‌های متداول**

**آیا می‌توانم تصویر اصلی را بدون برش، افکت یا تبدیل شکل استخراج کنم؟**

بله. شیء [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) را دسترسی گرفته و ویژگی `binary_data` آن را روی دیسک بنویسید. این کار تصویر کدگذاری‌شده اصلی ذخیره‌شده در ارائه را حفظ می‌کند، نه نحوه رندر شدن تصویر روی اسلاید.

**آیا می‌توانم هر تصویر استخراج‌شده را به PNG صادر کنم؟**

بله. از ویژگی `image` در [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) برای دریافت شیء تصویر استفاده کنید، سپس با [ImageFormat.PNG](https://reference.aspose.com/slides/fa/python-net/aspose.slides/imageformat/) `save` کنید. این کار خروجی را به PNG تبدیل می‌کند و ممکن است نوع فایل اصلی یا داده‌های برداری را حفظ نکند.

**چگونه می‌توانم از ذخیره یک تصویر بیش از یک بار جلوگیری کنم؟**

هش ویژگی `binary_data` در [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) را محاسبه کنید و هش‌ها را در یک مجموعه نگهدارید. اگر تصویری جدید دارای هشی باشد که قبلاً موجود است، آن را رد کنید یا مرجع دیگری به فایل خروجی موجود ثبت کنید.

**چرا برخی اشکال تصویر تولید نمی‌کنند؟**

فریم‌های تصویری، اشکال پر شده با تصویر، فریم‌های شیء OLE، فریم‌های رسانه‌ای، فریم‌های زوم، جدول‌ها، نمودارها و اشیای SmartArt می‌توانند به تصاویر ارجاع دهند. برخی انواع شکل‌ها تصویر را از طریق اشیای قالب‌بندی تو در تو ارائه می‌دهند، بنابراین بررسی ساده `picture_format` یا `fill_format` شکل همیشه کافی نیست.

**آیا می‌توانم تصویر کوچک نشان‌داده‌شده برای فریم ویدئو را استخراج کنم؟**

بله. از [VideoFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/videoframe/) استفاده کنید و `picture_format.picture.image` را بخوانید. این کار تصویر پوستر ذخیره‌شده با فریم ویدئو را استخراج می‌کند، نه فریمی تولیدشده از فایل ویدئویی.

**چگونه می‌توانم تشخیص دهم کدام اشکال از تصویر خاصی در مجموعه تصاویر ارائه استفاده می‌کنند؟**

Aspose.Slides لینک‌های معکوسی از [PPImage](https://reference.aspose.com/slides/fa/python-net/aspose.slides/ppimage/) به اشکال ذخیره نمی‌کند. هنگام پیمایش، هر بار که مرجع تصویری پیدا می‌کنید، شماره اسلاید، مسیر شکل و هش یا شناسه تصویر را ثبت کنید.

**آیا می‌توانم تصاویر جاسازی‌شده درون اشیای OLE، مانند اسناد پیوست‌شده، را استخراج کنم؟**

می‌توانید پیش‌نمایش اسلاید شیء OLE را از ویژگی `substitute_picture_format` در [OleObjectFrame](https://reference.aspose.com/slides/fa/python-net/aspose.slides/oleobjectframe/) استخراج کنید. اما این پیش‌نمایش خود فایل سند جاسازی‌شده نیست. برای استخراج تصاویر از داخل فایل جاسازی‌شده، داده‌های OLE را استخراج کنید و با ابزارهای مناسب برای آن نوع فایل بررسی کنید.