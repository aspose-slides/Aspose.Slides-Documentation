---
title: إدارة تأثيرات تحويل الصورة في العروض التقديمية باستخدام Python
linktitle: تأثيرات تحويل الصورة
type: docs
weight: 11
url: /ar/python-net/image-transform-effects/
keywords:
- تحويل الصورة
- تأثير الصورة
- سطوع
- تباين
- تحويل إلى رمادي
- لون مزدوج
- تلون
- HSL
- استبدال اللون
- تشويش
- شفافية
- تأثير ألفا
- سلسلة تأثير
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تطبيق، ربط، فحص، إزالة، والتحقق من تأثيرات تحويل الصورة لإطارات الصور باستخدام Aspose.Slides للـ Python عبر .NET."
---
## **نظرة عامة**

تمثل Aspose.Slides تعديلات الصورة كمجموعة مرتبة من عمليات تحويل الصورة. لإطار صورة، ابدأ بإطار الـ[Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) وابدأ بالوصول إلى خاصية [image_transform](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image_transform/). مجموعة [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/) المعادة تتيح لك إضافة، تعداد، فحص، إزالة، ومسح التأثيرات دون إعادة كتابة بايتات الصورة الأصلية.

توضح هذه المقالة سير عمل كامل للسطوع والتباين، تحويلات اللون، التشويش، الشفافية، سلاسل التأثير المرتبة، القيم الفعّالة، الإزالة، والتحقق من جولة PPTX.

## **فهم ملكية التأثير وإعادة استخدام الصورة**

مورد صورة والصورة التي تعرضه كائنات مختلفة:

- [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) يخزن أو يشير إلى بيانات الصورة المصدر التي تملكها العرض.
- [Picture](https://reference.aspose.com/slides/python-net/aspose.slides/picture/) ينتمي إلى تعبئة صورة ويشير إلى مورد صورة مع تخزين مجموعة تحويل الصورة.
- [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) هو شكل الشريحة الذي يمتلك تعبئة الصورة ذات الصلة، الهندسة، إعدادات القص، وغيرها من تنسيقات المستوى الإطاري.

لذلك، عمليات تحويل الصورة لا تعدّل البايتات في [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/). عندما يتم تمرير نفس `PPImage` إلى [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) أكثر من مرة، كل إطار صورة جديد يحصل على `Picture` خاص به ومجموعة تحويل خاصة به. تطبيق التحويل إلى الرمادي على إطار واحد لا يجعل الأطر الأخرى رمادية، حتى وإن كانت جميعها تعيد استخدام نفس مورد الصورة المضمّن.

نموذج `Picture.image_transform` نفسه يُستخدم أيضًا من قبل تعبئات صور أخرى، مثل شكل أو خلفية الشريحة. تركز الأمثلة أدناه على إطارات الصور.

## **استخدام نطاقات المعلمات الصالحة والوحدات**

الطرق الموضحة تستخدم النطاقات الدلالية والوحدات التالية. احافظ على القيم ضمن هذه النطاقات حتى لو لم ترفض نسخة المكتبة المحددة القيمة الخارجة عن النطاق فورًا؛ قد يقوم تنسيق العرض الهدف بتطبيع، حذف، أو رفض البيانات غير الصالحة أثناء الحفظ أو عندما يفتح PowerPoint الملف.

| العملية | المعلمات | النطاق والوحدة الصالحة |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | `-100` إلى `100`، نسبة مئوية؛ `0` يترك المكوّن دون تغيير. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | None | لا معلمات رقمية. الألفا يبقى دون تغيير. |
| [add_duotone_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | لونان للبكسلات الداكنة والفاتحة. قنوات RGB والألفا تستخدم `0` إلى `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | درجة اللون `hue` من `0` شامل إلى `360` غير شامل، بالدرجات؛ `amount` من `-100` إلى `100`، نسبة مئوية. |
| [add_hsl_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | درجة اللون `hue` من `0` شامل إلى `360` غير شامل، بالدرجات؛ التشبع `saturation` والسطوع `luminance` من `-100` إلى `100`، نسبة مئوية. |
| [add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | لون الاستبدال يستخدم قيم القنوات من `0` إلى `255`. قيم الألفا الحالية تبقى دون تغيير. |
| [add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | نصف القطر غير سالب ويقاس بالنقاط؛ `grow` هو قيمة منطقية تتحكم فيما إذا كان المحتوى المشوش قد يمتد خارج الحدود الأصلية. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | نسبة مئوية غير سلبية. استخدم `0` إلى `100` لتنسيق الشفافية العادي: `0` يعني شفاف بالكامل و `100` يحافظ على الألفا الحالي. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | `0` إلى `100`، نسبة مئوية للشفافية. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | `0` إلى `100`، نسبة مئوية لعتبة الألفا. القيم الأقل تصبح شفافة؛ القيم عند أو فوق العتبة تصبح معتمة. |

للتعديل الثابت على الألفا، الشفافية والعتامة مكملان لبعضهما. على سبيل المثال، 35% شفافية تعادل مقدار تعديل ألفا يساوي 65%.

## **تطبيق السطوع والتباين**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) يعيد عملية [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/). يتم تزويد إعدادات المقياس عند إنشاء العملية. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) تُعيد القيم المحسوبة للقراءة فقط والتي يمكن فحصها أو تسجيلها.

المثال التالي يزيد السطوع بنسبة 15% والتباين بنسبة 20%، ثم يعرض معاينة دون تعديل الصورة المضمّنة:

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

[BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) هو امتداد تأثير صورة Office 2010 وهو أقل قابلية للنقل مقارنةً بتأثير الإضاءة القياسي في DrawingML. عندما يجب أن يبقى السطوع والتباين قابلين للتحرير بعد جولة PPTX، استخدم [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) وتحقق من النتيجة بعد إعادة فتح الملف. يشرح قسم قيود الصيغة هذا الاختلاف بمزيد من التفصيل.

## **تطبيق تحويلات اللون**

يمكن تطبيق تأثيرات اللون بشكل مستقل على إطارات صور مختلفة تعيد استخدام مورد صورة واحد. المثال التالي ينشئ خمسة إطارات ويطبق التحويل إلى الرمادي، والذرون، وتلوين، وتعديل HSL، واستبدال اللون.

[Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) يحتوي على معاملين لونيين قابلين للتحرير بشكل مستقل: `color1` يحدد البكسلات الداكنة، بينما `color2` يحدد البكسلات الفاتحة. هذا يجعل منه مثالًا مفيدًا لتأثير إعداداته أكثر تعقيدًا من قيمة عددية واحدة.

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

[add_color_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) يستبدل لون كل بكسل بلون ثابت واحد مع الحفاظ على الألفا. وهو مختلف عن [add_color_change_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/)، الذي يطابق لون مصدر إلى آخر ويظهر كل من صيغ اللون المصدر والهدف.

### **تطبيق عتبة الإضاءة**

يمكن أن تجعل عتبة الإضاءة العلامات الضعيفة على صفحة ممسوحة ضوئيًا أسهل للتمييز عن الخلفية. [add_gray_scale_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) يحافظ على الدرجات المتوسطة من الرمادي. [add_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_bi_level_effect/) يطابق الإضاءة إلى أسود أو أبيض، بينما [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) يطبق عتبة على العتمة.

يتراوح نطاق عتبة الإضاءة من 0% إلى 100% inclusive. البكسلات دون العتبة تصبح سوداء. البكسلات عند أو فوق العتبة تصبح بيضاء. رفع العتبة يحول مزيد من الظلال إلى اللون الأسود لأن المزيد منها يقع تحت الحد.

Download [grayscale-swatches.png](grayscale-swatches.png) to the working directory. Each label gives the original gray level on a scale from 0 to 255. The example places the original beside two copies and saves each copy's threshold in the presentation.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 150, slides.SlideSizeScaleType.DO_NOT_SCALE)
    shapes = presentation.slides[0].shapes

    with slides.Images.from_file("grayscale-swatches.png") as source_image:
        image = presentation.images.add_image(source_image)

    def add_frame(x, caption):
        label = shapes.add_auto_shape(slides.ShapeType.RECTANGLE, x, 12, 216, 36)
        label.text_frame.text = caption
        return shapes.add_picture_frame(slides.ShapeType.RECTANGLE, x, 60, 216, 72, image)

    add_frame(12, "Original")

    low_threshold = add_frame(252, "Threshold 20%")
    low_threshold.picture_format.picture.image_transform.add_bi_level_effect(20)
    
    high_threshold = add_frame(492, "Threshold 60%")
    high_threshold.picture_format.picture.image_transform.add_bi_level_effect(60)

    presentation.save("luminance-threshold.pptx", slides.export.SaveFormat.PPTX)
```

Open the output presentation in PowerPoint to compare the three frames. The swatch labeled 96 has about 38% luminance (96 out of 255). It turns white at the 20% threshold and black at the 60% threshold.

![الأشرطة الرمادية الأصلية بجانب نتائج الأسود‑الأبيض عند عتبات إضاءة 20% و60%](luminance-threshold.png)

## **إضافة تشويش، شفافية، وتأثيرات ألفا**

[add_blur_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) يؤثر على جميع القنوات اللونية، بما فيها الألفا. اضبط `grow` إلى `True` عندما قد يمتد الحافة المشوشة خارج حدود الصورة الأصلية.

لشفافية موحدة، استخدم [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). فهو يضاعف كل قيمة ألفا موجودة، لذا تبقى البكسلات نصف شفافة بفارق نسبي. [add_alpha_replace_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) بدلاً من ذلك يعيّن قيمة ألفا واحدة لجميع البكسلات. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) يحوّل الألفا إلى مستويين بناءً على عتبة.

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

تشمل عمليات الألفا الخالية من المعلمات أيضاً [add_alpha_ceiling_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/)، التي تجعل كل ألفا غير صفرية معتمة تمامًا؛ [add_alpha_floor_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/)، التي تجعل كل ألفا أقل من 100% شفافة تمامًا؛ و[add_alpha_inverse_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/)، التي تغير الألفا إلى `100% - alpha`.

## **إنشاء سلسلة تأثير مرتبة**

كل طريقة `add_..._effect` تُضيف عملية جديدة إلى نهاية المجموعة. يستخدم المولد المجموعة كخط أنابيب مرتب: ناتج العملية 0 يصبح مدخل العملية 1، وهكذا. وبالتالي، يمكن أن تُنتج نفس العمليات بترتيب مختلف صورة مختلفة.

على سبيل المثال، التحويل إلى الرمادي ثم التلوين يزيل أولاً المعلومات اللونية ثم يعيد تلوين نتيجة الإضاءة. التلوين ثم التحويل إلى الرمادي يزيل التلوين مرة أخرى. بالمثل، استبدال الألفا يمكن أن يتجاوز قيم الألفا التي حسبتها العمليات السابقة، بينما تعديل الألفا يحافظ على الفروقات النسبية بينها.

المثال التالي يبني سلسلة مكوّنة من أربع عمليات، يحفظها كـ PPTX، يُعيد فتح العرض، يتحقق من نوعية العملية وترتيبها، ثم يُظهر النتيجة التي أُعيد فتحها:

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

لا تفرض المجموعة مصفوفة توافق تقيد عمليات اللون، الألفا، والتشويش إلى سلاسل منفصلة. يمكن دمجها، لكن ليست كل التركيبات مفيدة دائمًا. استبدال اللون الثابت يزيل تباين RGB الناتج عن تأثيرات اللون السابقة؛ التحويل إلى الرمادي بعد الديون يزيل اللونين المحددين؛ وعملية السقف أو الأرضية أو الاستبدال أو المستويات الثنائية للألفا يمكن أن تُهمل تفاصيل الألفا التي أنشئت مسبقًا. بّن السلسلة وفقًا لتسلسل معالجة البكسل المطلوب بدلاً من اعتبار عناصرها علامات تنسيق غير مرتبة.

<!-- visual-explanation:image-transform-effects:start -->
[![نفس الصورة تمر عبر التحويل إلى الرمادي ثم التلوين، والعكس؛ الصور الرمادية النهائية لديها نغمات مختلفة.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*في هذا العرض التوضيحي لـ Aspose.Slides for .NET 26.11، التلوين بزاوية 220° بنسبة 25% لا يغيّر الصورة الرمادية. تطبيق نفس التلوين قبل التحويل إلى الرمادي ينتج نغمات مختلفة.*
<!-- visual-explanation:image-transform-effects:end -->

## **فحص القيم القابلة للتحرير والفعّالة**

عملية قابلة للتحرير هي الكائن المخزن في `Picture.image_transform`. بحسب التأثير، قد يكشف عن أعضاء قابلة للكتابة مباشرة. على سبيل المثال، [Blur](https://reference.aspose.com/slides/python-net/aspose.slides.effects/blur/) يكشف عن خصائص `radius` و `grow` القابلة للكتابة، [AlphaModulateFixed](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphamodulatefixed/) يتيح خاصية `amount` القابلة للكتابة، و[AlphaBiLevel](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphabilevel/) يتيح خاصية `threshold` القابلة للكتابة. تأثيرات اللون مثل [Duotone](https://reference.aspose.com/slides/python-net/aspose.slides.effects/duotone/) تكشف عن كائنات [ColorFormat](https://reference.aspose.com/slides/python-net/aspose.slides/colorformat/) قابلة للتغيير.

بعض العمليات، بما فيها [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/)، [HSL](https://reference.aspose.com/slides/python-net/aspose.slides.effects/hsl/)، [Tint](https://reference.aspose.com/slides/python-net/aspose.slides.effects/tint/)، و[AlphaReplace](https://reference.aspose.com/slides/python-net/aspose.slides.effects/alphareplace/)، لا تكشف عن القيم العددية التي أنشئت كخصائص قابلة للكتابة. لتغيير تلك الإعدادات، احذف العملية وأضف بديلًا في الموضع المطلوب.

البيانات الفعّالة التي تُعيدها `get_effective()` محسوبة ولا يمكن تعديلها. هي مفيدة لحل الألوان المعتمدة على السمة وقراءة القيم المُطَبَّقَة التي يستخدمها المولد، لكنها ليست سطح تحرير آخر. المثال التالي يعدد السلسلة ويفحص القيم الفعّالة حيث توفر الواجهة البرمجية ما يلزم:

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

التأثيرات الخالية من المعلمات مثل التحويل إلى الرمادي، السقف الألفي، والعكس الألفي لا تزال تمتلك كائن بيانات فعّالة، لكن لا توجد إعدادات عددية للطباعة. وجودها وموقعها في المجموعة هو المعلومات الهامة.

## **إزالة أو مسح تحويلات الصورة**

استخدم [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) لإزالة عملية واحدة حسب الفهرس. لأن الفهارس تتShift بعد الإزالة، ابحث عن الهدف أولاً واحذفه بعد التعداد. استخدم `clear()` لإزالة السلسلة بأكملها.

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

إزالة أو مسح التحويلات يغيّر فقط تنسيق الصورة. لا يحذف، ولا يعيد ضغط، ولا يغيّر مورد [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) المعاد استخدامه.

## **النظر في صيغ العرض وأهداف التصدير**

تنشأ تحويلات الصورة في DrawingML، لذا فإن PPTX هو الصيغة القابلة للتحرير المفضلة لسلاسل التأثير. حتى مع PPTX، لا تمتلك كل عملية قابلية نقل متطابقة:

- عمليات DrawingML القياسية مثل الإضاءة، التحويل إلى الرمادي، الديون، التلوين، HSL، التشويش، والعمليات الألفية الشائعة لديها أفضل فرص للبقاء بعد جولة PPTX. دائمًا أعد فتح الملف المُنشأ وافحص المجموعة عندما يكون الحفاظ متطلبًا.
- [BrightnessContrast](https://reference.aspose.com/slides/python-net/aspose.slides.effects/brightnesscontrast/) هو امتداد Office 2010 وليس عملية الإضاءة القياسية في DrawingML. يمكن استخدامه في التصيّر داخل الذاكرة، لكنه غير مضمون أن يبقى كعملية `BrightnessContrast` قابلة للتحرير بعد حفظ وإعادة فتح PPTX. فضلًا عن ذلك استخدم [add_luminance_effect](https://reference.aspose.com/slides/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) لضبط السطوع والتباين بشكل دائم.
- صيغ PPT الثنائية سابقة لنموذج تأثير DrawingML الكامل. قد يحذف حفظ إلى PPT عمليات غير مدعومة، أو يقلل السلسلة إلى مجموعة فرعية مدعومة، أو يقرب المظهر. لا تستخدم PPT كصيغة للتحقق من سلسلة تحريرية معقدة.
- التصيّر إلى PNG، JPEG، TIFF، PDF، SVG، HTML، أو أي مخرجات بصرية أخرى يطبق السلسلة المدعومة على المظهر المُصوّر. تلك المخرجات لا تحتوي على `ImageTransformOperationCollection` قابلة للتحرير؛ صيغ الرستر تُسطّح النتيجة إلى بكسلات، والصادرات المستندية أو المتجهة تخزن تمثيلها الخاص بالتصيّر.
- التأثيرات لا تجعل الصورة المرتبطة ذاتية الاكتفاء. لا يزال تصيّر صورة مرتبطة يعتمد على توفر المورد المرتبط عند تحميل العرض.

قد يُظهر مستهلكو العروض المختلفون الحالات الطرفية بشكل مختلف، خاصة عندما تُدمج عمليات ألفا أو تقليل الألوان المتعددة. للاختبارات الحرجة، اختبر كلًا من جولة التحرير النهائية وتصدير الصيغة النهائية باستخدام نفس نسخة Aspose.Slides المستخدمة في الإنتاج.

## **الأسئلة المتكررة**

**هل تعدّل تأثيرات تحويل الصورة بيانات الصورة المضمّنة؟**

لا. العمليات تنتمي إلى `Picture` المستخدمة في تعبئة الصورة. تبقى بايتات `PPImage` الأساسية دون تغيير.

**هل سيتشارك تأثيران إطارا صورة يعيدان استخدام نفس الصورة؟**

لا. إعادة استخدام `PPImage` يوفّر تكرار بيانات الصورة، ولكن كل إطار صورة عادةً ما يكون له `Picture` ومجموعة تحويل صورة منفصلة.

**هل يمكن دمج تأثيرات اللون، التشويش، والألفا؟**

نعم. المجموعة تقبلها في سلسلة مرتبة واحدة. ضع في اعتبارك ما تفعله كل عملية على ناتج العملية السابقة لأن عمليات الاستبدال والعتبة قد تُهمل تفاصيل اللون أو الألفا السابقة.

**لماذا القيم الفعّالة للقراءة فقط؟**

تمثل البيانات الفعّالة القيم المحسوبة المستخدمة في التصيّر، بما فيها الألوان المحلولة. حرّر العملية المخزنة في مجموعة التحويل حيث توجد أعضاء قابلة للكتابة؛ وإلا احذفها وأضف استبدالًا بمعلمات إنشاء جديدة.

**أي صيغة يجب أن أستخدمها للحفاظ على سلسلة تحويل؟**

استخدم PPTX وتحقق من الملف بإعادة فتحه. لا يمكن لصيغة PPT القديمة تمثيل نموذج تأثير DrawingML الكامل، وتُحافظ صيغ التصدير البصرية على المظهر فقط دون عمليات تحويل قابلة للتحرير.