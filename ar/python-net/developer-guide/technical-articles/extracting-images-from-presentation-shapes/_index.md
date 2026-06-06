---
title: استخراج الصور من أشكال العرض التقديمي في بايثون
linktitle: صورة من الشكل
type: docs
weight: 90
url: /ar/python-net/extracting-images-from-presentation-shapes/
keywords:
- استخراج صورة
- استرجاع صورة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "استخراج الصور من الأشكال في عروض PowerPoint وOpenDocument باستخدام Aspose.Slides لبايثون عبر .NET - حل سريع وسهل للشفرة."
---
## **نظرة عامة**

يمكن أن تظهر الصور في العرض التقديمي بعدة أنواع من الأشكال: كإطارات صور عادية، كملء صورة يُطبق على الأشكال، كصور معاينة كائن OLE، كصوّرات مصغرة لإطار الفيديو أو الصوت، كصور تكبير، أو كصور مدمجة داخل أشكال الجدول، المخطط، وSmartArt. يقوم Aspose.Slides بتخزين تلك الصور في مجموعة صور العرض التقديمي، التي تُعرض عبر كائنات [ImageCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imagecollection/) و[PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) .

إذا كنت بحاجة فقط لتصدير كل مورد صورة مدمج في العرض التقديمي، يمكنك التكرار عبر `presentation.images`. يركز هذا المقال على مهمة مختلفة: استعراض الأشكال للعثور على الأماكن التي تُستخدم فيها الصور على الشرائح، بحيث يمكن للملفات المحفوظة الاحتفاظ بسياق مفيد مثل رقم الشريحة، موقع الشكل، ونوع المصدر (إطار صورة، صورة تعبئة، معاينة وسائط، معاينة OLE، أو صورة تكبير).

{{% alert title="Tip" color="primary" %}}
استخدم خاصية `binary_data` لكائن [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) للحفاظ على بيانات الصورة المشفرة الأصلية ونوع الملف. استخدم خاصية `image` مع `save` عندما تريد توحيد الإخراج إلى تنسيق محدد مثل PNG.
{{% /alert %}}

## **طرق المساعدة المشتركة**

تُبقي طرق المساعدة أدناه الأمثلة قصيرة. تقوم `save_original_image` بكتابة البايتات الأصلية المدمجة، وتختار امتدادًا آمنًا بناءً على نوع MIME، وتتخطى النسخ الثنائية المتكررة للصور باستخدام تجزئة SHA-256.

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

## **استخراج الصور من إطارات الصورة**

استخدم هذه الطريقة للصور المُدرجة ككائنات مستقلة. يُخزن كائن [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) صورته في `picture_format.picture.image`، والذي يعيد كائنًا من نوع [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) .

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

## **استخراج الصور من الأشكال المملوءة بصورة**

يمكن للأشكال استخدام صورة كملئها. تحقق أولاً من نوع ملئ الشكل: إذا لم يكن [FillType.PICTURE](https://reference.aspose.com/slides/ar/python-net/aspose.slides/filltype/) ، فلا توجد صورة لاستخراجها من ذلك الملء. يتعامل المثال أدناه مع كائنات [AutoShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/autoshape/) ويحفظ كل صورة كملف PNG عبر خاصية `image` لكائن [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) .

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

## **استخراج صور المعاينة من إطارات كائن OLE**

يمكن أن يحتوي [OleObjectFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/oleobjectframe/) على صورة بديلة يستخدمها PowerPoint كمعاينة للكائن على الشريحة. تتوفر هذه الصورة عبر `substitute_picture_format.picture.image`. استخراج هذه الصورة يمنحك صورة المعاينة، وليس محتويات حزمة OLE المدمجة.

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

## **استخراج صور المعاينة من إطارات الفيديو**

يمكن أيضًا لكائن [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/) تخزين صورة معاينة في `picture_format.picture.image`. هذه هي الصورة أو المصغرة المعروضة على الشريحة، وليست إطارًا مُستخرجًا من تدفق الفيديو.

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

## **استخراج صور المعاينة من إطارات الصوت**

يمكن لكائن [AudioFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/) تخزين صورة مصغرة في `picture_format.picture.image`. هذه هي الصورة المعروضة لكائن الصوت على الشريحة.

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

## **استخراج الصور من كائنات التكبير**

يمكن لأشكال [ZoomFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/zoomframe/) و[SectionZoomFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/sectionzoomframe/) استخدام صور مخصصة. اقرأ `zoom_image` من إطار التكبير.

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

## **استخراج الصور من إطارات التكبير الملخص**

كائن [SummaryZoomFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/summaryzoomframe/) هو أيضًا شكل. يمكن لعناصر القسم الخاصة به استخدام صور مخصصة، وتُعرض عبر خاصية `zoom_image` لكل قسم من أقسام التكبير الملخص.

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

## **استخراج الصور من أشكال الجداول**

[Table](https://reference.aspose.com/slides/ar/python-net/aspose.slides/table/) هو شكل. عادةً ما تُخزن الصور في جدول كملء صورة داخل خلايا الجدول.

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

## **استخراج الصور من أشكال المخططات**

[Chart](https://reference.aspose.com/slides/ar/python-net/aspose.slides.charts/chart/) هو شكل. المثال أدناه يستخرج صورة من ملء صورة منطقة المخطط.

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

## **استخراج الصور من أشكال SmartArt**

[SmartArt](https://reference.aspose.com/slides/ar/python-net/aspose.slides.smartart/smartart/) هو شكل. بناءً على تخطيط SmartArt، قد تُخزن الصور في ملء نقط التعداد للعقد أو في تنسيقات ملء أشكال العقد.

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

## **تضمين الصور داخل الأشكال المجمعة**

تحتوي الأشكال المجمعة على مجموعات أشكال خاصة بها. يحتوي المساعد المشترك `enumerate_shapes` على خيار `include_grouped_shapes`. عيّنها إلى `True` عندما تريد فحص الأشكال داخل كائنات [GroupShape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/groupshape/) . المثال أدناه يستخرج الصور من إطارات الصور، الأشكال المملوءة بصورة، معاينات كائن OLE، المصغرات لإطارات الفيديو، والمصغرات لإطارات الصوت. لتضمين صور الجداول، المخططات، SmartArt، وصور التكبير الملخص كذلك، أعد استخدام منطق الاستخراج المتخصص من الأقسام السابقة مع الحفاظ على نفس استعراض الأشكال المتكرر.

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

## **الحالات الخاصة والملاحظات العملية**

- **صور مكررة:** قد تشير أشكال متعددة إلى نفس الصورة أو إلى صور منفصلة ذات بايتات متطابقة. احسب تجزئة خاصية `binary_data` لكائن [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) قبل كتابة الملفات إذا كنت تريد ملف إخراج واحد لكل صورة فريدة.
- **البيانات الأصلية مقابل الإخراج المحوّل:** حفظ خاصية `binary_data` لكائن [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) يحفظ بيانات JPEG أو PNG أو GIF أو SVG أو EMF أو WMF المدمجة. حفظ خاصية `image` عبر `save` مفيد عندما تريد تنسيق إخراج موحد.
- **أنواع الملء غير المدعومة:** الأشكال الصلبة، المتدرجة، النمطية، والخالية من الملئ لا تحتوي على ملء صورة. تحقق من [FillType](https://reference.aspose.com/slides/ar/python-net/aspose.slides/filltype/) قبل قراءة `picture_fill_format`.
- **الأشكال المجمعة:** مجموعة أشكال الشريحة العليا لا تُسطّح المجموعات. افحص بشكل متكرر [GroupShape.shapes](https://reference.aspose.com/slides/ar/python-net/aspose.slides/groupshape/shapes/) عندما يكون محتوى المجموعات مهمًا.
- **معاينات كائن OLE:** قد يُظهر [OleObjectFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/oleobjectframe/) صورة معاينة عبر `substitute_picture_format`، لكن تلك الصورة هي فقط معاينة الشريحة. ليست الملف المدمج داخل كائن OLE.
- **مصغرات إطار الفيديو:** قد يُظهر [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/) صورة معاينة عبر `picture_format`، لكن تلك الصورة هي فقط البوستر المعروض على الشريحة. ليست مستخرجة من تدفق الفيديو.
- **مصغرات إطار الصوت:** قد يُظهر [AudioFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/audioframe/) أيقونة أو صورة مصغرة عبر `picture_format`؛ وهي ليست بيانات الصوت المدمجة.
- **صور التكبير:** قد تستخدم أشكال تكبير الشريحة، تكبير القسم، وتكبير الملخص كائنات [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) مخصصة عبر `image`.
- **نماذج الأشكال المتداخلة:** تُطبق كائنات الجدول، المخطط، وSmartArt واجهة [Shape](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shape/)، لكن غالبًا ما تُخزن صورها في خلايا جدول متداخلة، عنصر مخطط، أو كائنات تنسيق عقدة SmartArt.
- **الصور المقصوصة أو المُحوّلة:** الوصول إلى [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) يمنحك مورد الصورة المخزن. لا يُظهر القص، الشفافية، إعادة التلوين، الدوران، أو غيرها من التأثيرات البصرية التي يطبقها الشكل.

## **الأسئلة المتكررة**

**هل يمكنني استخراج الصورة الأصلية دون قص أو تأثيرات أو تحولات الشكل؟**

نعم. قم بالوصول إلى كائن [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) واكتب خاصية `binary_data` إلى القرص. هذا يحافظ على الصورة المشفرة الأصلية المخزنة في العرض التقديمي، وليس الطريقة التي تُظهر بها الصورة على الشريحة.

**هل يمكنني تصدير كل صورة مستخرجة كملف PNG؟**

نعم. استخدم خاصية `image` لكائن [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) للحصول على كائن صورة، ثم استدعِ `save` مع [ImageFormat.PNG](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imageformat/). هذا يحول الإخراج وقد لا يحافظ على نوع الملف الأصلي أو بيانات المتجه.

**كيف يمكنني تجنب حفظ نفس الصورة أكثر من مرة؟**

استخدم تجزئة خاصية `binary_data` لكائن [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) واحتفظ بالتجزئات في مجموعة. إذا كان للصورة الجديدة تجزئة موجودة بالفعل، فتخطها أو سجّل إشارة أخرى إلى ملف الإخراج الموجود.

**لماذا لا تُنتج بعض الأشكال صورة؟**

إطارات الصورة، الأشكال المملوءة بصورة، إطارات كائن OLE، إطارات الوسائط، إطارات التكبير، الجداول، المخططات، وكائنات SmartArt يمكن أن تشير إلى صور. بعض أنواع الأشكال تُظهر الصور عبر كائنات تنسيق متداخلة، لذا فإن التحقق البسيط من `picture_format` أو `fill_format` للشكل ليس دائمًا كافيًا.

**هل يمكنني استخراج الصورة المصغرة المعروضة لإطار الفيديو؟**

نعم. استخدم [VideoFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/videoframe/) واقرأ `picture_format.picture.image`. هذا يستخرج صورة البوستر المخزنة مع إطار الفيديو، وليس إطارًا مُستخرجًا من ملف الفيديو.

**كيف يمكنني تحديد الأشكال التي تستخدم صورة معينة من مجموعة صور العرض التقديمي؟**

لا يخزن Aspose.Slides روابط عكسية من [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) إلى الأشكال. قم بإنشاء خريطة أثناء الاستعراض: كلما وجدت إشارة إلى صورة، سجّل رقم الشريحة، مسار الشكل، وتجزئة الصورة أو عنصر المجموعة.

**هل يمكنني استخراج الصور المدمجة داخل كائنات OLE، مثل المستندات المرفقة؟**

يمكنك استخراج معاينة شريحة كائن OLE من خاصية `substitute_picture_format` لكائن [OleObjectFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/oleobjectframe/). ومع ذلك، هذه المعاينة ليست المستند المدمج نفسه. لاستخراج الصور من داخل الملف المدمج، استخرج بيانات OLE وتفحصها بأدوات مخصصة لنوع الملف.