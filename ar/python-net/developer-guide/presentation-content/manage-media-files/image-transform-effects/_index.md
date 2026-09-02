---
title: إدارة تأثيرات تحويل الصورة في العروض التقديمية باستخدام بايثون
linktitle: تأثيرات تحويل الصورة
type: docs
weight: 11
url: /ar/python-net/image-transform-effects/
keywords:
- تحويل الصورة
- تأثير الصورة
- سطوع
- تباين
- تدرج رمادي
- ثنائي اللون
- صبغة
- HSL
- استبدال اللون
- تمويه
- شفافية
- تأثير ألفا
- سلسلة تأثير
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تطبيق، ربط، فحص، إزالة، والتحقق من تأثيرات تحويل الصورة لإطارات الصور باستخدام Aspose.Slides للغة بايثون عبر .NET."
---
## **نظرة عامة**

تمثل Aspose.Slides تعديلات الصورة كمجموعة مرتبة من عمليات تحويل الصورة. لإطار صورة، ابدأ بـ[Picture](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picture/) الخاص بالإطار وتوصل إلى خاصية [image_transform](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picture/image_transform/). مجموعة [ImageTransformOperationCollection](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/) المرتَّجعة تتيح لك إضافة، تعداد، فحص، إزالة، ومسح التأثيرات دون إعادة كتابة بايتات الصورة الأصلية.

هذه المقالة توضح سير عمل كامل للسطوع والتباين، تحويلات اللون، التمويه، الشفافية، سلاسل التأثير المرتبة، القيم الفعّالة، الإزالة، والتحقق من جولة PPTX.

## **فهم ملكية التأثير وإعادة استخدام الصورة**

موارد الصورة والصورة التي تُعرضها كائنان مختلفان:

- [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) يخزن أو يشير إلى بيانات الصورة الأصلية المملوكة للعرض التقديمي.
- [Picture](https://reference.aspose.com/slides/ar/python-net/aspose.slides/picture/) ينتمي إلى تعبئة الصورة ويشير إلى مورد الصورة بينما يخزن مجموعة تحويل الصورة.
- [PictureFrame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/pictureframe/) هو شكل الشريحة الذي يملك تعبئة الصورة ذات الصلة، الهندسة، إعدادات الاقتصاص، وتنسيق المستوى للإطار.

لذا لا تقوم عمليات تحويل الصورة بتعديل بايتات [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/). عندما يتم تمرير نفس `PPImage` إلى [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/ar/python-net/aspose.slides/shapecollection/add_picture_frame/) أكثر من مرة، يحصل كل إطار صورة جديد على `Picture` خاص به ومجموعته الخاصة من التحويلات. تطبيق التدرج الرمادي على إطار واحد لا يجعل الإطارات الأخرى رمادية، رغم أن جميعها يعيد استخدام نفس مورد الصورة المدمج.

نموذج `Picture.image_transform` نفسه يُستخدم أيضاً بواسطة تعبئات صور أخرى، مثل شكل أو خلفية شريحة. الأمثلة أدناه تركز على إطارات الصور.

## **استخدام نطاقات المعلمات والوحدات الصالحة**

الطرق الموضحة تستخدم النطاقات الدلالية والوحدات التالية. احتفظ بالقيم ضمن هذه النطاقات حتى إذا لم يرفض إصدار المكتبة ما هو خارج النطاق فوراً؛ قد يقوم تنسيق العرض الهدف بتطبيع، حذف، أو رفض البيانات غير الصالحة أثناء الحفظ أو عند فتح الملف في PowerPoint.

| العملية | المعلمات | النطاق الصالح والوحدة |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | من `-100` إلى `100`، النسبة المئوية؛ `0` يترك المكوّن دون تغيير. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | لا شيء | لا توجد معلمات رقمية. يظل ألفا دون تغيير. |
| [add_duotone_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | لونان للبيكسلات الداكنة والفاتحة. القنوات RGB والألفا تستخدم قيم من `0` إلى `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | `hue` من `0` (شامل) إلى `360` (غير شامل) درجة؛ `amount` من `-100` إلى `100`، النسبة المئوية. |
| [add_hsl_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | `hue` من `0` (شامل) إلى `360` (غير شامل) درجة؛ `saturation` و `luminance` من `-100` إلى `100`، النسبة المئوية. |
| [add_color_replace_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | لون الاستبدال يستخدم قيم القنوات من `0` إلى `255`. قيم الألفا الحالية تبقى دون تغيير. |
| [add_blur_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | `radius` غير سالب ويقاس بالنقاط؛ `grow` قيمة منطقية تتحكم فيما إذا كان المحتوى المهشّم قد يمتد خارج الحدود الأصلية. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | نسبة مئوية غير سلبية. استخدم `0` إلى `100` لتعديل الشفافية العادي: `0` شفاف بالكامل و`100` يحافظ على الألفا الحالي. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | من `0` إلى `100`، نسبة مئوية للشفافية. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | من `0` إلى `100`، نسبة مئوية للحد الألفا. القيم الأقل تصبح شفافة؛ القيم عند أو فوق الحد تصبح معتمة. |

للتعديل الثابت على ألفا، الشفافية والعتامة مكملان لبعضهما. على سبيل المثال، شفافية 35% تعادل تعديل ألفا بنسبة 65%.

## **تطبيق السطوع والتباين**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) تُعيد عملية [BrightnessContrast](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/brightnesscontrast/). يتم توفير إعداداتها العددية عند إنشاء العملية. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) تُعيد القيم المحسوبة للقراءة فقط والتي يمكن فحصها أو تسجيلها.

المثال التالي يزيد السطوع بنسبة 15% والتباين بنسبة 20%، ثم يعرض معاينة دون تعديل الصورة المدمجة:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    brightness_contrast = image_transform.add_brightness_contrast_effect(15, 20)

    effective_values = brightness_contrast.get_effective()
    print("Brightness: " + str(effective_values.brightness) + "%")
    print("Contrast: " + str(effective_values.contrast) + "%")

    with slide.get_image() as preview:
        preview.save("brightness-contrast-preview.png")
```

[BrightnessContrast](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/brightnesscontrast/) هو امتداد تأثير صورة من Office 2010 وأقل قابلية للنقل مقارنةً بتأثير الإضاءة القياسي في DrawingML. عندما يجب الحفاظ على قابلية تحرير السطوع والتباين بعد جولة PPTX، استخدم [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) وتحقق من النتيجة بعد إعادة فتح الملف. يوضح قسم قيود الصيغة هذا الاختلاف بمزيد من التفصيل.

## **تطبيق تحويلات اللون**

يمكن تطبيق تأثيرات اللون بشكل مستقل على إطارات صور مختلفة تُعيد استخدام مورد صورة واحد. المثال التالي ينشئ خمسة إطارات ويطبق التدرج الرمادي، الدوتون، الصبغة، تعديل HSL، واستبدال اللون.

[Duotone](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/duotone/) يحتوي على معاملين لونيين قابلين للتحرير بشكل مستقل: `color1` يطابق البيكسلات الداكنة، بينما `color2` يطابق البيكسلات الفاتحة. هذا يجعله مثالاً مفيداً لتأثير إعداداته أكثر تعقيداً من قيمة عددية واحدة.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    gray_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 180, 120, image)
    gray_frame.picture_format.picture.image_transform.add_gray_scale_effect()

    duotone_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 180, 120, image)
    duotone = duotone_frame.picture_format.picture.image_transform.add_duotone_effect()
    duotone.color1.color = draw.Color.navy
    duotone.color2.color = draw.Color.gold

    tint_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 420, 20, 180, 120, image)
    tint_frame.picture_format.picture.image_transform.add_tint_effect(210, 35)

    hsl_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 120, 170, 180, 120, image)
    hsl_frame.picture_format.picture.image_transform.add_hsl_effect(30, 20, -10)

    replacement_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.picture_format.picture.image_transform.add_color_replace_effect()
    color_replacement.color.color = draw.Color.cornflower_blue

    presentation.save("color-transformations.pptx", slides.export.SaveFormat.PPTX)
```

[add_color_replace_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) يستبدل لون كل بيكسل بلون ثابت مع الحفاظ على الألفا. وهو مختلف عن [add_color_change_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/)، الذي يطابق لون مصدر إلى آخر ويظهر صيغتي اللون المصدر والهدف.

## **إضافة تمويه، شفافية، وتأثيرات ألفا**

[add_blur_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) يؤثر على جميع قنوات اللون، بما في ذلك الألفا. اضبط `grow` إلى `True` عندما قد يمتد الحافة المهشّمة خارج حدود الصورة الأصلية.

للشفافية المتساوية، استخدم [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). فهو يضاعف كل قيمة ألفا موجودة، لذا تبقى البيكسلات شبه الشفافة مختلفة نسبياً. [add_alpha_replace_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) بدلاً من ذلك يعيّن قيمة ألفا واحدة لكل البيكسلات. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) يحوّل الألفا إلى مستويين بناءً على حد معين.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    blurred_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 140, image)
    blur = blurred_frame.picture_format.picture.image_transform.add_blur_effect(4.5, True)
    blur.radius = 5

    transparent_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.picture_format.picture.image_transform.add_alpha_modulate_fixed_effect(65)
    alpha_modulate.amount = 60

    uniform_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 180, 200, 140, image)
    uniform_alpha_frame.picture_format.picture.image_transform.add_alpha_replace_effect(55)

    binary_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.picture_format.picture.image_transform.add_alpha_bi_level_effect(50)
    alpha_bi_level.threshold = 45
    binary_alpha_frame.picture_format.picture.image_transform.add_alpha_inverse_effect()

    presentation.save("blur-and-alpha-effects.pptx", slides.export.SaveFormat.PPTX)
```

عمليات ألفا بدون معاملات أخرى تشمل [add_alpha_ceiling_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/)، الذي يجعل كل ألفا غير صفرية معتمة بالكامل؛ [add_alpha_floor_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/)، الذي يجعل كل ألفا أقل من 100% شفافة بالكامل؛ و[add_alpha_inverse_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/)، الذي يغيّر الألفا إلى `100% - alpha`.

## **بناء سلسلة تأثيرات مرتبة**

كل طريقة `add_..._effect` تضيف عملية جديدة إلى نهاية المجموعة. يستخدم المُعالج المجموعة كخط أنابيب مرتب: ناتج العملية 0 يصبح مدخلاً للعملية 1، وهكذا. وبالتالي، نفس العمليات بترتيب مختلف قد تنتج صورة مختلفة.

على سبيل المثال، التدرج الرمادي يليه الصبغة يزيل أولاً المعلومات اللونية ثم يعيد تلوين نتيجة الإضاءة. الصبغة يليه التدرج الرمادي يزيل الصبغة مرة أخرى. بالمثل، استبدال الألفا يمكن أن يتجاوز قيم الألفا المحسوبة بواسطة العمليات السابقة، بينما تعديل الألفا يحافظ على الفروقات النسبية بينها.

المثال التالي يبني سلسلة من أربع عمليات، يحفظها كـ PPTX، يعيد فتح العرض التقديمي، يتحقق من نوعية العمليات وترتيبها، ثم يعرض النتيجة المعاد فتحها:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    image_transform.add_gray_scale_effect()
    image_transform.add_tint_effect(220, 25)
    image_transform.add_blur_effect(2.5, False)
    image_transform.add_alpha_modulate_fixed_effect(80)

    presentation.save("image-transform-chain.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("image-transform-chain.pptx") as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]

    if isinstance(reopened_shape, slides.PictureFrame):
        reopened_transform = reopened_shape.picture_format.picture.image_transform
        order_is_preserved = (
            len(reopened_transform) == 4 and
            isinstance(reopened_transform[0], slides.effects.GrayScale) and
            isinstance(reopened_transform[1], slides.effects.Tint) and
            isinstance(reopened_transform[2], slides.effects.Blur) and
            isinstance(reopened_transform[3], slides.effects.AlphaModulateFixed)
        )
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        with reopened_presentation.slides[0].get_image() as rendered_slide:
            rendered_slide.save("reopened-effect-chain.png")
    else:
        print("The reopened shape is not a picture frame.")
```

المجموعة لا تفرض مصفوفة توافق تقيد عمليات اللون، الألفا، والتمويه إلى سلاسل منفصلة. يمكن دمجها، لكن الجمع ليس دائماً مفيداً. استبدال اللون الثابت يزيل اختلافات RGB التي تنتجها تأثيرات لون سابقة؛ التدرج الرمادي بعد الدوتون يزيل اللونين المحددين؛ عمليات الألفا مثل السقيفة، الأرضية، الاستبدال أو الثنائي المستوى يمكن أن تُهمل تفاصيل الألفا التي أنشئت مسبقاً. بنِ السلسلة وفق تسلسل معالجة البكسل المطلوب بدلاً من اعتبار عناصرها كعلامات تنسيق غير مرتبة.

## **فحص القيم القابلة للتحرير والفعّالة**

العملية القابلة للتحرير هي الكائن المخزن في `Picture.image_transform`. اعتماداً على التأثير، قد يكشف عن أعضاء قابلة للكتابة مباشرة. على سبيل المثال، [Blur](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/blur/) يكشف عن خصائص `radius` و `grow` القابلة للكتابة، [AlphaModulateFixed](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/alphamodulatefixed/) يكشف عن خاصية `amount` القابلة للكتابة، و[AlphaBiLevel](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/alphabilevel/) يكشف عن خاصية `threshold` القابلة للكتابة. تأثيرات اللون مثل [Duotone](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/duotone/) تكشف عن كائنات [ColorFormat](https://reference.aspose.com/slides/ar/python-net/aspose.slides/colorformat/) القابلة للتعديل.

بعض العمليات، بما في ذلك [BrightnessContrast](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/brightnesscontrast/)، [HSL](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/hsl/)، [Tint](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/tint/)، و[AlphaReplace](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/alphareplace/)، لا تكشف المتغيرات العددية الخاصة بإنشائها كخصائص قابلة للكتابة. لتغيير هذه الإعدادات، احذف العملية وأضف بديلًا في الموقع المطلوب.

البيانات الفعّالة التي تُرجعها `get_effective()` محسوبة ولا يمكن تعديلها. هي مفيدة لحل ألوان تعتمد على السمة وقراءة القيم المُطَبَّقة التي يستخدمها المُعالج، لكنها ليست سطح تحرير آخر. المثال التالي يعدّ السلسلة ويفحص القيم الفعّالة حيث توفر API ما يلزم:

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform

        for index, operation in enumerate(image_transform):
            print(str(index) + ": " + type(operation).__name__)

            if isinstance(operation, slides.effects.BrightnessContrast):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Luminance):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Duotone):
                effect_data = operation.get_effective()
                print("  Dark color: " + str(effect_data.color1))
                print("  Light color: " + str(effect_data.color2))
            elif isinstance(operation, slides.effects.ColorReplace):
                effect_data = operation.get_effective()
                print("  Replacement color: " + str(effect_data.color))
            elif isinstance(operation, slides.effects.HSL):
                effect_data = operation.get_effective()
                print("  HSL: " + str(effect_data.hue) + ", " + str(effect_data.saturation) + ", " + str(effect_data.luminance))
            elif isinstance(operation, slides.effects.Tint):
                effect_data = operation.get_effective()
                print("  Tint: " + str(effect_data.hue) + ", " + str(effect_data.amount))
            elif isinstance(operation, slides.effects.Blur):
                effect_data = operation.get_effective()
                print("  Blur radius: " + str(effect_data.radius) + " pt")
            elif isinstance(operation, slides.effects.AlphaModulateFixed):
                effect_data = operation.get_effective()
                print("  Alpha amount: " + str(effect_data.amount) + "%")
            elif isinstance(operation, slides.effects.AlphaReplace):
                effect_data = operation.get_effective()
                print("  Replacement alpha: " + str(effect_data.alpha) + "%")
            elif isinstance(operation, slides.effects.AlphaBiLevel):
                effect_data = operation.get_effective()
                print("  Alpha threshold: " + str(effect_data.threshold) + "%")
```

التأثيرات بدون معاملات مثل التدرج الرمادي، السقيفة الألفا، والعكس الألفا لا يزال لديها كائن بيانات فعّالة، لكن لا توجد إعدادات عددية للطباعة. وجودها وموقعها في المجموعة هو المعلومات المهمة.

## **إزالة أو مسح تحويلات الصورة**

استخدم [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) لإزالة عملية واحدة بحسب الفهرس. لأن الفهارس تنتقل بعد الإزالة، ابحث عن الهدف أولاً وأزله بعد التعداد. استخدم `clear()` لإزالة السلسلة بالكامل.

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform
        blur_index = None

        for index, operation in enumerate(image_transform):
            if isinstance(operation, slides.effects.Blur):
                blur_index = index
                break

        if blur_index is not None:
            image_transform.remove_at(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: " + str(len(image_transform)))
        presentation.save("image-transforms-cleared.pptx", slides.export.SaveFormat.PPTX)
```

إزالة أو مسح التحويلات يغيّر فقط تنسيق الصورة. لا يحذف، يعيد ضغط، أو يغيّر مورد [PPImage](https://reference.aspose.com/slides/ar/python-net/aspose.slides/ppimage/) المعاد استخدامه.

## **اعتبارات صيغ العروض التقديمية وأهداف التصدير**

تنشأ تحويلات الصورة في DrawingML، لذا يعتبر PPTX الصيغة القابلة للتعديل المفضلة لسلاسل التأثير. حتى مع PPTX، ليست كل عملية متطابقة من حيث القابلية للنقل:

- عمليات DrawingML القياسية مثل الإضاءة، التدرج الرمادي، الدوتون، الصبغة، HSL، التمويه، والعمليات الشائعة للألفا لديها أفضل فرصة للبقاء بعد جولة PPTX. دائمًا أعد فتح الملف الناتج وفحص المجموعة عندما يكون الحفاظ شرطًا.
- [BrightnessContrast](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/brightnesscontrast/) هو امتداد Office 2010 وليس عملية إضاءة DrawingML القياسية. يمكن استخدامه للعرض في الذاكرة، لكنه غير مضمون أن يبقى كعملية `BrightnessContrast` قابلة للتحرير بعد حفظ وإعادة فتح PPTX. يفضَّل استخدام [add_luminance_effect](https://reference.aspose.com/slides/ar/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) لتعديلات السطوع والتباين الدائمة.
- تنسيق PPT الثنائي يسبق نموذج تأثير DrawingML الكامل. الحفظ إلى PPT قد يحذف عمليات غير مدعومة، يقلل السلسلة إلى مجموعة جزئية مدعومة، أو يقرّب المظهر. لا تستخدم PPT كصيغة للتحقق لسلسلة تحريرية معقدة.
- التحويل إلى PNG، JPEG، TIFF، PDF، SVG، HTML أو غيرها من المخرجات البصرية يطبق السلسلة المدعومة على المظهر المرسوم. تلك المخرجات لا تحتوي على `ImageTransformOperationCollection` قابلة للتحرير؛ صيغ الرستر تُسطّح النتيجة إلى بيكسلات، وتصديرات المستند أو المتجه تخزن تمثيلها الخاص للعرض.
- التأثيرات لا تجعل الصورة المرتبطة ذاتية المحتوى. عرض صورة مرتبطة ما يزال يعتمد على توفر المورد المرتبط عند تحميل العرض التقديمي.

قد يُظهر مستهلكو العروض التقديمية المختلفون حالات حافة مختلفة، خاصةً عندما تُدمج عدة عمليات ألفا أو تكميم لون. للاخراج الحاسم، اختبر كلا من جولة التحرير النهائية وصيغة التصدير النهائية باستخدام نفس إصدار Aspose.Slides المستخدم في الإنتاج.

## **الأسئلة المتكررة**

**هل تُعدّل تأثيرات تحويل الصورة بيانات الصورة المدمجة؟**

لا. العمليات تنتمي إلى `Picture` المستخدمة في تعبئة الصورة. بايتات `PPImage` الأساسية تظل دون تغيير.

**هل تشارك إطاري صورة يعيدان استخدام نفس الصورة تأثيراتهما؟**

لا. إعادة استخدام `PPImage` يجنب تكرار بيانات الصورة، لكن كل إطار صورة عادةً ما يكون له `Picture` منفصل ومجموعة تحويل صورة خاصة.

**هل يمكن دمج تأثيرات اللون، التمويه، والألفا؟**

نعم. المجموعة تقبلها في سلسلة مرتبة واحدة. ضع في اعتبارك ما تفعله كل عملية على ناتج العملية السابقة لأن عمليات الاستبدال والحد قد تُهمل تفاصيل اللون أو الألفا السابقة.

**لماذا القيم الفعّالة للقراءة فقط؟**

البيانات الفعّالة تمثل القيم المحسوبة المستخدمة للعرض، بما في ذلك الألوان التي تم حلّها. حرّر العملية المخزنة في مجموعة التحويل حيث توجد خصائص قابلة للكتابة؛ وإلا احذفها وأضف بديلًا بمعاملات إنشاء جديدة.

**ما الصيغة التي يجب استخدامها للحفاظ على سلسلة التحويل؟**

استخدم PPTX وتحقق من الملف بإعادة فتحه. لا يمكن للصيغة القديمة PPT تمثيل نموذج تأثير DrawingML الكامل، وتُحافظ صيغ التصدير المرئية على المظهر دون عمليات تحويل قابلة للتحرير.