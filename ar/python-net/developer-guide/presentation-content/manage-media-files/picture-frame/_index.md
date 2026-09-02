---
title: إدارة إطارات الصور في العروض التقديمية باستخدام بايثون
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/python-net/picture-frame/
keywords:
- إطار صورة
- إضافة إطار صورة
- إنشاء إطار صورة
- صورة مضمّنة
- صورة مرتبطة
- استخراج صورة
- صورة نقطية
- صورة SVG
- قص صورة
- حذف المناطق المقصوصة
- ضغط صورة
- إزاحة التمدد
- تنسيق إطار الصورة
- مقياس نسبي
- تأثير صورة
- نسبة الأبعاد
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء، تنسيق، ربط، قص، استخراج، وضغط إطارات الصور في العروض التقديمية باستخدام Aspose.Slides للبايثون عبر .NET."
---
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides، مورد الصورة والشكل الذي يعرضها كائنان منفصلان: [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) يمتلك موارد الصور المضمنة عبر [ImageCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides/imagecollection/)، بينما [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) يتحكم في موضع الصورة، حجمها، تنسيق الخط، الدوران، القص، تأثيرات الصورة، وإعدادات المستوى الإطاري الأخرى.

هذا الفصل مفيد عندما يتم عرض الصورة نفسها أكثر من مرة. أضف الصورة إلى العرض مرة واحدة، احتفظ بـ [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) المرجعة، واستخدم مورد الصورة هذا عند إنشاء إطارات الصور.

يمكن لإطارات الصور احتواء صور نقطية مثل PNG أو JPEG وصور متجهة SVG. كما يمكنها الإشارة إلى صور مرتبطة بدلاً من تخزين بايتات الصورة داخل العرض. يؤثر الاختيار على القابلية للنقل، حجم الملف، الاستخراج، وسلوك التصدير، لذا من المفيد اتخاذ قرار بشأن طريقة تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة وتنسيق صورة مضمّنة**

لصورة مضمّنة، أضف بيانات الصورة إلى العرض وأنشئ إطار صورة باستخدام [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_picture_frame/). تصبح الصورة جزءًا من حزمة العرض، وبالتالي يظل العرض مستقلًا عند نقله إلى كمبيوتر آخر.

المثال التالي يضيف صورة JPEG، ينشئ إطارًا بأبعاد الصورة الأصلية، ويطبق تنسيق الخط والدوران:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.line_format.fill_format.fill_type = slides.FillType.SOLID
    picture_frame.line_format.fill_format.solid_fill_color.color = draw.Color.blue
    picture_frame.line_format.width = 3
    picture_frame.rotation = 15

    presentation.save("picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

يتحكم إطار الصورة في الشكل المعروض؛ تغيير حجم الإطار لا يغيّر أبعاد البكسل الأصلية المخزنة في مورد الصورة المضمّن. يصبح هذا التمييز مهمًا عند قص الصورة أو ضغطها لاحقًا.

## **استخدام المقياس النسبي**

[PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) يكشف عن [relative_scale_width](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/relative_scale_width/) و [relative_scale_height](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/relative_scale_height/) للإطار. القيمة `1.0` تمثل 100% من حجم الصورة الأصلي. المقياس النسبي مفيد عندما يحتاج سير العمل إلى الحفاظ على علاقة بحجم الصورة المصدر بدلًا من حساب الأبعاد النهائية يدويًا.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)
    picture_frame.relative_scale_width = 1.35
    picture_frame.relative_scale_height = 0.8

    presentation.save("relative-scale.pptx", slides.export.SaveFormat.PPTX)
```

المقياس النسبي يغيّر إعدادات مقياس الإطار؛ لا يعيد أخذ العينات ولا يضغط الصورة المضمّنة.

## **الصور المضمّنة والمرتبطة**

الصورة المضمّنة تخزن بيانات الصورة داخل العرض وبالتالي تعتبر الخيار الأكثر أمانًا للنقل والعرض المتوقع. الصورة المرتبطة تخزن مسارًا خارجيًا عبر رابط [Picture](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picture/) بدلاً من تضمين بيانات الصورة بنفس الطريقة.

يمكن للصور المرتبطة تقليل كمية بيانات الصورة المخزنة في PPTX، لكنها تخلق اعتمادًا خارجيًا. يجب أن يظل الملف المرتبط قابلًا للوصول للتطبيق الذي يفتح أو يعرض العرض. إذا تغير المسار أو تم نقل الملف أو أصبح المورد غير متاح، قد لا يتم عرض الصورة المرتبطة كما هو متوقع. بالنسبة للعروض التي يجب إرسالها بالبريد الإلكتروني أو أرشفتها أو عرضها في بيئات معزولة، عادةً ما تكون الصور المضمّنة أكثر موثوقية.

### **إضافة صورة مرتبطة**

المثال التالي ينشئ إطار صورة ويوجهّه إلى ملف صورة محلي. يتعامل فقط مع ربط الصورة؛ ربط الفيديو هو سير عمل وسائط منفصل ولا يتم دمجه في هذا المثال عن قصد.

```python
import os
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 320, 180, None)
    linked_image_path = os.path.abspath("linked-image.jpg")
    picture_frame.picture_format.picture.link_path_long = linked_image_path

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

استخدم الروابط عندما يكون إدارة الملفات الخارجية مقصودة. لا تستخدمها كبديل للضغط فقط: PPTX صغير يحتوي على تبعات صور مكسورة عادةً ما يكون أقل فائدة من عرض أكبر مكتمل ذاتيًا.

## **استخراج الصور من إطارات الصور**

قبل استخراج صورة من عرض موجود، تحقّق أن الشكل هو فعلاً [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) وأنّه يحتوي على صورة مضمّنة. قد لا تحتوي إطارات الصور المرتبطة على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

واجهة برمجة التطبيقات الحديثة للصور تستخدم [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/) مباشرة. المثال التالي يجد أول صورة نقطية مضمّنة على شريحة ويحفظها كملف PNG:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        if embedded_image is None or embedded_image.svg_image is not None:
            continue

        raster_image = embedded_image.image
        raster_image.save("extracted-image.png", slides.ImageFormat.PNG)
        break
```

الحفظ عبر [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/) يحوّل الصورة المستخرجة إلى تنسيق الإخراج المطلوب. إذا كنت بحاجة إلى البايتات المشفرة المخزنة في العرض بدلاً من ملف نقطي محوَّل، استخدم خاصية [PPImage.binary_data](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/binary_data/) بدلاً من ذلك.

### **استخراج صورة SVG**

بالنسبة لصورة SVG، يقدم [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) كائن [SvgImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/svgimage/). يتيح لك ذلك استرداد بيانات SVG مباشرة بدلًا من تحويل الصورة إلى نقطية أولاً.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, slides.PictureFrame):
            continue

        embedded_image = shape.picture_format.picture.image
        svg_image = embedded_image.svg_image if embedded_image is not None else None
        if svg_image is None:
            continue

        svg_data = bytes(svg_image.svg_data)
        with open("extracted-image.svg", "wb") as svg_stream:
            svg_stream.write(svg_data)
        break
```

الحفاظ على محتوى SVG كـ SVG يحافظ على المصدر المتجهي داخل العرض. تصديرات النقطية مثل PNG أو JPEG تفرض تحويل هذا المحتوى المتجهي إلى بكسلات. تصدير الشريحة إلى PDF أو SVG أيضًا عملية عرض، لذا لا يجب اعتبار الرسومات المصدرة نسخة بايت-ل‑بايت من SVG المضمّن الأصلي؛ استخدم [SvgImage.svg_data](https://reference.aspose.com/slides/ar/python-net/aspose.slides/svgimage/svg_data/) المضمّن عندما يكون المورد المتجهي الأصلي مطلوبًا.

## **قص صورة**

يؤدي القص إلى تغيير الجزء الظاهر من الصورة داخل الإطار. قيم القص على [PictureFillFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/) هي نسب مئوية لأبعاد الصورة المصدر. لا يحذف القص في البداية البكسلات المخفية من الصورة المضمّنة؛ فقط يغيّر المنطقة الظاهرة.

المثال التالي يجد إطار صورة بأمان ويطبّق قيم القص:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        picture_frame.picture_format.crop_left = 23.6
        picture_frame.picture_format.crop_right = 21.5
        picture_frame.picture_format.crop_top = 3
        picture_frame.picture_format.crop_bottom = 31
        presentation.save("cropped-image.pptx", slides.export.SaveFormat.PPTX)
```

نظرًا لأن بيانات الصورة المخفية لا تزال موجودة، يمكن تغيير القص لاحقًا دون فقدان البكسلات الأصلية. إذا كان حجم الملف أكثر أهمية من القابلية للعكس، يمكن إزالة المناطق المقصوصة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصورة المقصوصة**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) يزيل بيانات الصورة خارج مستطيل القص الحالي ويعيد مورد الصورة الناتج. يمكن لهذا الإجراء تقليل حجم الملف، لكنه تحسين تدميري: بعد حفظ العرض، لا تعود البكسلات المُزالة متاحة لعملية إلغاء القص لاحقًا.

```python
import aspose.slides as slides

with slides.Presentation("cropped-image.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        cropped_image = picture_frame.picture_format.delete_picture_cropped_areas()
        if cropped_image is not None:
            presentation.save("cropped-data-removed.pptx", slides.export.SaveFormat.PPTX)
```

قد تضيف الطريقة مورد صورة جديد إلى العرض. إذا كانت الصورة الأصلية تُستخدم أيضًا من قبل إطارات صور أخرى، فإن تلك الإطارات ما زالت بحاجة إلى موردها الحالي، لذا لا يؤدي حذف المناطق المقصوصة بالضرورة إلى تقليل العدد الكلي للصور. قص محتوى WMF أو EMF بهذه الطريقة يحوّل النتيجة المقصوصة إلى PNG.

## **ضغط الصور النقطية**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/compress_image/) يقلل دقة الصورة النقطية نسبة إلى الحجم الذي تُعرض به الصورة. يمكنه أيضًا حذف المناطق المقصوصة في نفس العملية. تُرجع الطريقة `True` عندما تُعاد تحجيم الصورة أو تُقص، وتُرجع `False` عندما لا يكون هناك تعديل ضروري.

استخدم قيمة [PicturesCompression](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/picturescompression/) محددة مسبقًا عندما يكون دقة هدف قياسية كافية:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]
    picture_frame = None

    for shape in slide.shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        compressed = picture_frame.picture_format.compress_image(True, slides.export.PicturesCompression.DPI150)
        print("The image was compressed." if compressed else "No compression was necessary.")
        presentation.save("compressed-image.pptx", slides.export.SaveFormat.PPTX)
```

يمكن تمرير قيمة DPI إيجابية مخصصة بدلاً من قيمة التعداد عندما يكون هدف محدد مطلوبًا.

الضغط مخصص للصور النقطية. لا يتم تقليل محتوى SVG أو ملفات الميتافايل بهذا الإجراء. تذكّر أيضًا أن الدقة الأقل والمناطق المقصوصة المحذوفة لا يمكن استردادها من العرض المُحسّن. اختر دقة الهدف بناءً على أكبر حجم ستُعرض فيه الصورة فعليًا أو تُصَدّر بدلاً من تطبيق أدنى DPI عالميًا.

## **إدارة تأثيرات تحويل الصورة**

لِسير عمل كامل يغطي السطوع، التباين، تحويلات اللون، الضبابية، تأثيرات ألفا، السلاسل المرتبة، الفحص، الإزالة، والتحقق من الرحلة المتكاملة، راجع [Image Transform Effects](/slides/ar/python-net/image-transform-effects/).

## **قفل هندسة إطار الصورة**

إعدادات [PictureFrameLock](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframelock/) تتحكم في عمليات التحرير التي تُعطَّل لإطار الصورة. على سبيل المثال، خاصية [aspect_ratio_locked](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) تحافظ على نسب الشكل أثناء تعديل حجمه.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.jpg") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 100, image.width, image.height, image)
    picture_frame.picture_frame_lock.aspect_ratio_locked = True

    presentation.save("locked-picture-frame.pptx", slides.export.SaveFormat.PPTX)
```

القفل يطبق على شكل إطار الصورة. لا يجبر الصورة المصدر على إعادة أخذ العينات أو تغيير دائم لنفس نسبة الأبعاد.

## **ضبط قيم StretchOffset**

عندما يكون وضع ملء الصورة هو "stretch"، تُعرّف قيم stretch‑offset على [PictureFillFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/) مستطيل الملء نسبة إلى صندوق الإطار. النسب المئوية الإيجابية تُنشئ انحشارًا من الحافة، بينما النسب السلبية تُنشئ بُعدًا خارج الحافة.

هذا مختلف عن القص. قيم القص تحدد أي جزء من الصورة المصدر يكون مرئيًا؛ قيم الـ stretch‑offset تغير المستطيل الذي يُمدد فيه ملء الصورة المرئي.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 400, 300, image)
    picture_frame.picture_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    picture_frame.picture_format.stretch_offset_left = 12
    picture_frame.picture_format.stretch_offset_right = 12
    picture_frame.picture_format.stretch_offset_top = 8
    picture_frame.picture_format.stretch_offset_bottom = 8

    presentation.save("stretch-offsets.pptx", slides.export.SaveFormat.PPTX)
```

استخدم stretch‑offset لتحديد موضع الملء. استخدم خصائص القص عندما يكون الهدف إخفاء حواف الصورة المصدر.

## **الاعتبارات المتعلقة بالتخزين، حجم الملف، والتصدير**

التبادلات الرئيسية تصبح أسهل في الإدارة عندما يُعامل تخزين الصورة وتنسيق إطار الصورة بشكل منفصل:

- **الصور المضمّنة** تجعل العرض مكتملًا ذاتيًا وهي الأكثر موثوقية للمشاركة والعرض على الخوادم، لكن الصور النقطية الكبيرة تزيد من حجم PPTX واستخدام الذاكرة.
- **الصور المرتبطة** يمكن أن تحافظ على حجم الحزمة أصغر، لكن العرض يعتمد على ملفات خارجية تظل متاحة في المسارات أو المواقع المخزنة.
- **القص** غير تدميري في البداية. تبقى البكسلات المخفية مضمّنة حتى تُحذف المناطق المقصوصة صراحةً أو تُزيل أثناء الضغط.
- **الضغط** يمكن أن يقلل حجم الملف بشكل كبير للصور النقطية الضخمة، لكنه يفرط في دقة المصدر. يجب تطبيقه بعد معرفة الحجم النهائي على الشريحة.
- **صور SVG** يجب أن تظل كـ SVG عندما تكون حفظ المتجهات مهمًا. استخرج الـ SVG المضمّن مباشرة عندما تحتاج إلى المورد المتجهي ذاته. تصدير الشريحة إلى صورة نقطية دائمًا يحوّل المحتوى المتجهي إلى بكسلات.
- **الصور المتكررة** ينبغي إعادة استخدام مورد [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) قائم عندما يكون ذلك ممكنًا بدلاً من تحميل الملف نفسه مرارًا في سير العمل.

للعروض الكبيرة، عادةً ما تكون تحسينات الصور أكثر فاعلية عند تنفيذها بشكل انتقائي: احتفظ بالشعارات والرسوم التخطيطية كالمحتوى المتجهي، اضغط الصور الفوتوغرافية وفقًا لحجم عرضها الفعلي، احذف البكسلات المقصوصة فقط عندما لا تكون هناك حاجة لتعديل لاحق، وتجنب الروابط الخارجية ما لم يكن إدارة التبعيات جزءًا من تصميم النشر.

## **الأسئلة المتكررة**

**ما الفرق بين إطار الصورة و مورد الصورة؟**

[PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) يمثل مورد الصورة المرتبط بالعرض. [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) هو شكل على الشريحة يعرض صورة ويخزن هندسة وإعدادات الإطار مثل الحجم، الدوران، قيم القص، التأثيرات، والقفل.

**هل يجب أن أضمّن الصور أم أربطها؟**

امضن الصور عندما يجب أن يكون العرض قابلًا للنقل، مؤرشفًا، أو مُعْرَضًا دون الحاجة إلى موارد خارجية. اربط الصور فقط عندما تكون إدارة ملفات الصور خارج PPTX مقصودة ويمكن الحفاظ على المواقع الخارجية بشكل موثوق.

**هل يقلل القص من حجم ملف PPTX؟**

ليس بمفرده. إعدادات القص العادية تخفي أجزاء من الصورة المصدر ولكن تحتفظ بالبكسلات الأساسية. استخدم [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) أو ضغط الصور مع حذف المناطق المقصوصة عندما يمكن تجاهل تلك البكسلات نهائيًا.

**هل يمكن استعادة جودة الصورة بعد الضغط؟**

لا. الضغط قد يقلل من دقة الصورة المخزنة، وإزالة المناطق المقصوصة تحذف بيانات الصورة. احتفظ بالصورة المصدر الأصلية خارج العرض إذا كان من المحتمل الحاجة إلى تحرير عالي الدقة لاحقًا.

**كيف يجب التعامل مع صور SVG؟**

احتفظ بمحتوى SVG كـ SVG عندما تكون وفاء المتجهات مهمة. يمكن استخراج الـ [SvgImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/svgimage/) المضمّن مباشرة. عرض شريحة إلى تنسيق نقطي مثل PNG أو JPEG يحوّل الـ SVG إلى بكسلات كجزء من صورة الشريحة.

**كيف أتجنب عمليات التحويل غير الآمنة عند قراءة شرائح موجودة؟**

تحقق من نوع الشكل قبل استخدام أعضاء خاصة بإطار الصورة. استخدام `isinstance(shape, slides.PictureFrame)` يمنع التحويلات غير الصالحة ويسمح للكود بمعالجة الشرائح التي لا تحتوي على إطارات صورة.