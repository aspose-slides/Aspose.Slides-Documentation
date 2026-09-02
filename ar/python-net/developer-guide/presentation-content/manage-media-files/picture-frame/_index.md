---
title: إدارة إطارات الصور في العروض التقديمية باستخدام بايثون
linktitle: إطار الصورة
type: docs
weight: 10
url: /ar/python-net/picture-frame/
keywords:
- إطار الصورة
- إضافة إطار صورة
- إنشاء إطار صورة
- صورة مضمَّنة
- صورة مرتبطة
- استخراج صورة
- صورة نقطية
- صورة SVG
- قص صورة
- حذف المناطق المقصوصة
- ضغط صورة
- StretchOffset
- تنسيق إطار الصورة
- مقياس نسبي
- تأثير الصورة
- نسبة العرض إلى الارتفاع
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Aspose.Slides
description: "إنشاء وتنسيق وربط وقص واستخراج وضغط إطارات الصور في العروض التقديمية باستخدام Aspose.Slides لبايثون عبر .NET."
---
## **نظرة عامة**

إطار الصورة هو شكل شريحة يعرض صورة. في Aspose.Slides، مورد الصورة والشكل الذي يعرضها كائنات منفصلة: يمتلك كائن [Presentation](https://reference.aspose.com/slides/ar/python-net/aspose.slides/presentation/) موارد الصور المضمنة عبر [ImageCollection] الخاصة به، بينما يتحكم [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) في موضع الصورة وحجمها وتنسيق الخط وتدويرها واقتطاعها وتأثيرات الصورة وإعدادات الإطار الأخرى.

هذا الفصل مفيد عندما يتم عرض نفس الصورة أكثر من مرة. أضف الصورة إلى العرض مرة واحدة، احتفظ بـ [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) المرجع، واستخدم مورد الصورة هذا عند إنشاء إطارات الصور.

يمكن لإطارات الصور أن تحتوي على صور نقطية مثل PNG أو JPEG وصور متجهة SVG. يمكنها أيضاً الإشارة إلى صور مرتبطة بدلاً من تخزين بايتات الصورة في العرض. يؤثر الاختيار على القابلية للنقل، حجم الملف، الاستخراج، وسلوك التصدير، لذلك من المفيد تحديد طريقة تخزين الصورة قبل تطبيق التنسيق أو التحسين.

## **إضافة وتنسيق صورة مضمنة**

لصورة مضمنة، أضف بيانات الصورة إلى العرض وأنشئ إطار صورة باستخدام [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_picture_frame/). تصبح الصورة جزءًا من حزمة العرض، لذا يبقى العرض مستقلًا عند نقله إلى حاسب آخر.

المثال التالي يضيف صورة JPEG، ينشئ إطارًا بأبعاد الصورة الأصلية، ويطبق تنسيق الخط والتدوير:
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

يتحكم إطار الصورة في الهندسة المعروضة؛ تعديل حجم الإطار لا يغيّر أبعاد البيكسل الأصلية المخزنة في مورد الصورة المضمنة. يصبح هذا الفرق مهمًا عند قص أو ضغط الصورة لاحقًا.

## **استخدام المقياس النسبي**

[PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) تعرض الخصائص [relative_scale_width](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/relative_scale_width/) و [relative_scale_height](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/relative_scale_height/) للإطار. القيمة `1.0` تمثل 100٪ من حجم الصورة الأصلي. المقياس النسبي مفيد عندما يحتاج سير العمل إلى الحفاظ على علاقة بحجم الصورة المصدر بدلاً من حساب الأبعاد النهائية يدويًا.
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

المقياس النسبي يغير إعدادات مقياس الإطار؛ لا يعيد تشكيل أو ضغط الصورة المضمنة.

## **الصور المضمنة والمرتبطة**

تخزن الصورة المضمنة بيانات الصورة داخل العرض وبالتالي فهي الخيار الأكمن للنقل والعرض المتوقع. تخزن الصورة المرتبطة موقعًا خارجيًا عبر مسار الارتباط [Picture](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picture/) بدلاً من تضمين بيانات الصورة بنفس الطريقة.

يمكن للصور المرتبطة تقليل كمية بيانات الصورة المخزنة في PPTX، لكنها تُدخل تبعية خارجية. يجب أن يظل الملف المرتبط متاحًا للتطبيق الذي يفتح أو يعرض العرض. إذا تغير المسار أو تم نقل الملف أو أصبح المورد غير متاح، قد لا تُعرض الصورة المرتبطة كما هو متوقع. بالنسبة للعروض التي يجب إرسالها بالبريد أو أرشفتها أو عرضها في بيئات معزولة، تكون الصور المضمنة عادة أكثر موثوقية.

### **إضافة صورة مرتبطة**

المثال التالي ينشئ إطار صورة ويشير إليه إلى ملف صورة محلي. يتعامل فقط مع ربط الصور؛ ربط الفيديو هو سير عمل وسائط منفصل ولا يتم دمجه عمدًا في هذا المثال.
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

استخدم الروابط عندما يكون إدارة الملفات الخارجية مقصودة. لا تستخدمها مجرد بديل للضغط: عادةً ما يكون PPTX صغير مع تبعيات صور مكسورة أقل فائدة من عرض أكبر مستقل.

## **استخراج الصور من إطارات الصورة**

قبل استخراج صورة من عرض موجود، تحقق من أن الشكل هو فعليًا [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) وأنه يحتوي على صورة مضمنة. قد لا تحتوي إطارات الصور المرتبطة على بايتات صورة يمكن استخراجها بنفس الطريقة.

### **استخراج صورة نقطية**

تستخدم واجهة برمجة التطبيقات الحديثة للصور [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/) مباشرة. المثال التالي يجد أول صورة نقطية مضمنة على شريحة ويحفظها كـ PNG:
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

الحفظ عبر [IImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/iimage/) يحول الصورة المستخرجة إلى تنسيق الإخراج المطلوب. إذا كنت بحاجة إلى البايتات المشفرة المخزنة في العرض بدلاً من ملف نقطي محوَّل، استخدم خاصية [PPImage.binary_data](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/binary_data/) بدلاً من ذلك.

### **استخراج صورة SVG**

بالنسبة لصورة SVG، تعرض [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) كائن [SvgImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/svgimage/). يتيح لك ذلك استرجاع بيانات SVG مباشرةً بدلاً من تحويل الصورة إلى نقطية أولًا.
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

الحفاظ على محتوى SVG كـ SVG يحافظ على المصدر المتجهي داخل العرض. التصديرات النقطية مثل PNG أو JPEG تُحوِّل ذلك المحتوى المتجهي إلى بكسلات بالضرورة. تصدير الشرائح إلى PDF أو SVG هو أيضًا عملية عرض، لذا لا ينبغي التعامل مع الرسومات المصدَّرة كنسخة بايت‑بايت من SVG المضمن الأصلي؛ استخدم [SvgImage.svg_data](https://reference.aspose.com/slides/ar/python-net/aspose.slides/svgimage/svg_data/) المضمّن عندما يكون المورد المتجهي الأصلي مطلوبًا.

## **قَص صورة**

يقوم القص بتغيير الجزء المرئي من الصورة داخل الإطار. قيم القص في [PictureFillFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/) هي نسب مئوية لأبعاد الصورة المصدر. لا يحذف القص في البداية البكسلات المخفية من الصورة المضمنة؛ إنه يغيّر فقط المنطقة المرئية.

المثال التالي يجد إطار صورة بأمان ويطبق قيم القص:
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

نظرًا لأن بيانات الصورة المخفية لا تزال موجودة، يمكن تعديل القص لاحقًا دون فقدان البكسلات الأصلية. إذا كان حجم الملف أهم من القابلية للعكس، يمكن إزالة المناطق المقطوعة فعليًا كما هو موضح في القسم التالي.

## **إزالة بيانات الصورة المقطوعة**

[PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) يزيل بيانات الصورة خارج مستطيل القص الحالي ويعيد مورد الصورة الناتج. يمكن أن يقلل ذلك من حجم الملف، لكنه تحسين تدميري: بعد حفظ العرض، لا تعود البكسلات المحذوفة متاحة لعملية إلغاء القص لاحقًا.
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

قد تضيف الطريقة مورد صورة جديد إلى العرض. إذا كانت الصورة الأصلية مستخدمة أيضًا من قبل إطارات صور أخرى، فإن تلك الإطارات ما زالت تحتاج إلى المورد الحالي، وبالتالي حذف مناطق القص لا يقلل بالضرورة من العدد الإجمالي للصور. قص محتوى WMF أو EMF بهذه الطريقة يحول النتيجة المقطوعة إلى PNG.

## **ضغط الصور النقطية**

[PictureFillFormat.compress_image](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/compress_image/) يقلل من دقة الصورة النقطية بالنسبة إلى الحجم الذي تُعرض به الصورة. يمكنه أيضًا إزالة المناطق المقطوعة في العملية نفسها. تُعيد الطريقة `True` عندما يتم تغيير حجم الصورة أو قصها و `False` عندما لا يكون هناك تغيير مطلوب.

استخدم قيمة [PicturesCompression](https://reference.aspose.com/slides/ar/python-net/aspose.slides.export/picturescompression/) مسبقة التعريف عندما تكون الدقة المستهدفة القياسية كافية:
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

يمكن تمرير قيمة DPI إيجابية مخصصة بدلاً من قيمة تعداد عندما يكون هناك هدف محدد مطلوب.

الضغط مخصص للصور النقطية. محتوى SVG والملفات الوصفية لا يتم تقليله عبر هذا سير عمل الضغط النقطي. وتذكر أيضًا أنه لا يمكن استعادة الدقة المنخفضة أو المناطق المقطوعة المحذوفة من العرض المُحسَّن. اختر دقة مستهدفة استنادًا إلى أكبر حجم يُعرض فيه أو يُصدَّر الصورة فعليًا بدلاً من تطبيق أقل DPI على مستوى العالم.

## **فحص تأثيرات الصورة**

تُخزن تأثيرات الصورة على الصورة المستخدمة في الإطار. يمكن أن تحتوي مجموعة تحويلات الصورة على تأثيرات مثل تعديل ألفا ثابت للشفافية وتغيّر السطوع للإنارة والتباين. المثال أدناه يقرأ بأمان كلا النوعين من التأثيرات من أول إطار صورة على شريحة:
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
        for effect in picture_frame.picture_format.picture.image_transform:
            if isinstance(effect, slides.effects.AlphaModulateFixed):
                transparency = 100 - effect.amount
                print("Transparency: " + str(transparency))

            if isinstance(effect, slides.effects.Luminance):
                luminance = effect.get_effective()
                print("Brightness: " + str(luminance.brightness))
                print("Contrast: " + str(luminance.contrast))
```

[AlphaModulateFixed](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/alphamodulatefixed/) و [Luminance](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/luminance/) يغيّران طريقة عرض الصورة في الإطار؛ لا يعيدان كتابة بايتات الصورة المضمنة الأصلية.

## **قفل هندسة إطار الصورة**

تتحكم إعدادات [PictureFrameLock](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframelock/) في عمليات التحرير التي يتم تعطيلها لإطار الصورة. على سبيل المثال، الخاصية [aspect_ratio_locked](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframelock/aspect_ratio_locked/) تحافظ على نسب الشكل أثناء تغيير حجمه.
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

القفل يطبق على شكل إطار الصورة. ولا يجبر الصورة المصدر على إعادة تشكيل أو تغيير دائم إلى نفس النسبة.

## **ضبط قيم StretchOffset**

عند أن يكون وضع ملء الصورة هو التمدد، تحدد قيم stretch‑offset في [PictureFillFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/) مستطيل التعبئة بالنسبة إلى صندوق إطار الصورة. النسب المئوية الإيجابية تُنشئ تضمينًا من الحافة، بينما النسب السالبة تُنشئ امتدادًا.

هذا يختلف عن القص. قيم القص تحدد أي جزء من الصورة المصدر مرئي؛ قيم stretch‑offset تغير المستطيل الذي يُمدد فيه ملء الصورة المرئي.
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

استخدم stretch‑offsets لتحديد موضع التعبئة. استخدم خصائص القص عندما يكون الهدف إخفاء حواف الصورة المصدر.

## **الاعتبارات المتعلقة بالتخزين، حجم الملف، والتصدير**

تكون المقايضات الرئيسية أسهل في الإدارة عندما يتم التعامل مع تخزين الصور وتنسيق إطارات الصورة بشكل منفصل:

- **الصور المضمنة** تجعل العرض مستقلًا وتُعَد الأكثر موثوقية للمشاركة والعرض على الخادم، لكن الصور النقطية الكبيرة تزيد من حجم PPTX واستخدام الذاكرة.
- **الصور المرتبطة** يمكن أن تجعل الحزمة أصغر، لكن العرض يعتمد على ملفات خارجية تظل متاحة في المسارات أو المواقع المخزنة.
- **القص** غير مدمر في البداية. تظل البكسلات المخفية مضمَّنة حتى يتم حذف المناطق المقصوصة صراحةً أو إزالتها أثناء الضغط.
- **الضغط** يمكن أن يقلل حجم الملف بشكل كبير للصور النقطية الضخمة، لكنه يضحي بدقة المصدر. يجب تطبيقه بعد معرفة الحجم المقصود على الشريحة.
- **صور SVG** ينبغي أن تبقى كـ SVG عندما تكون حفظ المتجهات مهمًا. استخرج SVG المضمن مباشرةً عندما تحتاج إلى المورد المتجهي نفسه. تصدير الشرائح إلى صورة نقطية يحول دائمًا الشريحة المرسومة إلى بكسلات.
- **الصور المتكررة** ينبغي إعادة استخدام مورد [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) موجود عندما يكون ذلك ممكنًا بدلاً من تحميل نفس الملف مرارًا في سير عمل العرض.

## **الأسئلة الشائعة**

**ما الفرق بين إطار الصورة ومورد الصورة؟**

يمثل [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) مورد صورة مرتبط بالعرض. بينما [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) هو شكل على الشريحة يعرض صورة ويخزن إعدادات الإطار مثل الحجم، التدوير، قيم القص، التأثيرات، والقفل.

**هل يجب أن أضمن الصور أم أربطها؟**

قم بتضمين الصور عندما يجب أن يكون العرض قابلًا للنقل أو مؤرشفًا أو معروضًا دون الحاجة إلى موارد خارجية. اربط الصور فقط عندما يكون حفظ ملفات الصور خارج PPTX مقصودًا ويمكن الحفاظ على المواقع الخارجية بشكل موثوق.

**هل يقلل القص حجم ملف PPTX؟**

ليس بمفرده. إعدادات القص العادية تخفي أجزاء من الصورة المصدر ولكنها تحتفظ بالبكسلات الأساسية. استخدم [PictureFillFormat.delete_picture_cropped_areas](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picturefillformat/delete_picture_cropped_areas/) أو ضغط الصورة مع إزالة مناطق القص عندما يمكن حذف تلك البكسلات نهائيًا.

**هل يمكن استعادة جودة الصورة بعد الضغط؟**

لا. يمكن للضغط تقليل دقة الصورة النقطية المخزنة، وإزالة المناطق المقصوصة تحذف بيانات الصورة. احتفظ بالصورة المصدر الأصلية خارج العرض إذا كان قد يُحتاج إلى تعديل عالي الدقة لاحقًا.

**كيف يجب التعامل مع صور SVG؟**

حافظ على محتوى SVG كـ SVG عندما تكون دقة المتجه مهمة. يمكن استخراج [SvgImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/svgimage/) المضمن مباشرةً. عرض الشريحة إلى تنسيق نقطي مثل PNG أو JPEG يحول SVG إلى بكسلات كجزء من صورة الشريحة.

**كيف يمكن تجنب عمليات التحويل غير الآمنة عند قراءة الشرائح الموجودة؟**

تحقق من نوع الشكل قبل استخدام أعضاء خاصة بإطار الصورة. استخدام `isinstance(shape, slides.PictureFrame)` يتجنب التحويلات غير الصالحة ويسمح للشفرة بمعالجة الشرائح التي لا تحتوي على إطارات صور.