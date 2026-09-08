---
title: إدارة تأثيرات تحويل الصورة في العروض التقديمية باستخدام Python
linktitle: تأثيرات تحويل الصورة
type: docs
weight: 11
url: /ar/python-java/image-transform-effects/
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
- Java
- Aspose.Slides
description: "تطبيق، ربط، فحص، إزالة، والتحقق من تأثيرات تحويل الصورة لإطارات الصور باستخدام Aspose.Slides للبايثون عبر Java."
---
## **نظرة عامة**

Aspose.Slides يمثل تعديلات الصورة كمجموعة مرتبة من عمليات تحويل الصورة. لإطار صورة، ابدأ بـ [Picture](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picture/) للإطار واستدعِ [Picture.getImageTransform](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picture/#getImageTransform). المجموعة التي يتم إرجاعها [ImageTransformOperationCollection](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/) تتيح لك إضافة، تعداد، فحص، إزالة، ومسح التأثيرات دون إعادة كتابة بايتات الصورة الأصلية.

هذه المقالة توضح سير عمل كامل للسطوع والتباين، وتحويلات الألوان، والتمويه، والشفافية، وسلاسل التأثير المرتبة، والقيم الفعّالة، والإزالة، والتحقق من جولة PPTX.

## **فهم ملكية التأثير وإعادة استخدام الصورة**

مصدر الصورة والإطار الذي يعرضها كائنات مختلفة:

- [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) يخزن أو يشير إلى بيانات الصورة الأصلية التي يملكها العرض.
- [Picture](https://reference.aspose.com/slides/ar/python-java/aspose.slides/picture/) ينتمي إلى تعبئة صورة ويشير إلى مورد صورة بينما يخزن مجموعة تحويل الصورة.
- [PictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/pictureframe/) هو شكل الشريحة الذي يملك تعبئة الصورة ذات الصلة، الهندسة، إعدادات القطع، وتنسيق المستوى للإطار.

لذلك، عمليات تحويل الصورة لا تعدل البايتات في [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/). عندما يتم تمرير نفس `PPImage` إلى [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shapecollection/#addPictureFrame) أكثر من مرة، يحصل كل إطار صورة جديد على `Picture` خاص به ومجموعة تحويل خاصة به. تطبيق التدرج الرمادي على إطار واحد لا يجعل الأطر الأخرى ذات تدرج رمادي، حتى وإن كانت جميعها تعيد استخدام نفس مورد الصورة المضمّن.

نفس نموذج `Picture.getImageTransform` يُستخدم أيضاً بواسطة تعبئات صور أخرى، مثل شكل أو خلفية شريحة. الأمثلة أدناه تركز على إطارات الصور.

## **استخدام نطاقات ومعايير صحيحة للمعاملات والوحدات**

الطرق الموضحة تستخدم النطاقات الدلالية والوحدات التالية. احتفظ بالقيم ضمن هذه النطاقات حتى لو لم يرفض إصدار المكتبة المحدد القيمة خارج النطاق فوراً؛ قد يقوم تنسيق العرض المستهدف بتطبيع أو حذف أو رفض البيانات غير الصالحة أثناء الحفظ أو عندما يفتح PowerPoint الملف.

| العملية | المعاملات | النطاق والوحدة الصالحة |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` إلى `100`، نسبة مئوية؛ `0` يترك المكوّن دون تغيير. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | لا شيء | لا توجد معاملات رقمية. قيمة ألفا تبقى دون تغيير. |
| [addDuotoneEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | لونين للبكسلات الداكنة والفاتحة. قنوات RGB والألفا في `java.awt.Color` تستخدم القيم من `0` إلى `255`. |
| [addTintEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | درجة اللون `hue` تتراوح من `0` شامل إلى `360` غير شامل، بالدرجات؛ القيمة `amount` تتراوح من `-100` إلى `100`، نسبة مئوية. |
| [addHSLEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | درجة اللون `hue` تتراوح من `0` شامل إلى `360` غير شامل، بالدرجات؛ التشبع `saturation` والسطوع `luminance` يتراوحان من `-100` إلى `100`، نسبة مئوية. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | لون الاستبدال يستخدم قيم القنوات من `0` إلى `255`. قيم ألفا الحالية تبقى دون تغيير. |
| [addBlurEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | نصف القطر غير سالب ويُقاس بالنقاط؛ `grow` هو قيمة منطقية تتحكم فيما إذا كان المحتوى المخفّض يمكن أن يمتد خارج الحدود الأصلية. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | نسبة مئوية غير سلبية. استخدم `0` إلى `100` لتعديل الشفافية العادي: `0` شفاف تماماً و`100` يحافظ على ألفا الحالي. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `0` إلى `100`، نسبة مئوية للشفافية. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `0` إلى `100`، نسبة مئوية لحدّ ألفا. القيم الأقل تصبح شفافة؛ القيم المساوية أو الأعلى تصبح عاتمة. |

للتعديل الثابت للألفا، الشفافية والعتامة متكاملتين. على سبيل المثال، 35% شفافية تعادل مقدار تعديل ألفا قدره 65%.

## **تطبيق السطوع والتباين**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) يرجع عملية [BrightnessContrast](https://reference.aspose.com/slides/ar/python-java/aspose.slides/brightnesscontrast/). إعداداته العددية تُزود عند إنشاء العملية. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/ar/python-java/aspose.slides/brightnesscontrast/#getEffective) يرجع قيمًا محسوبة للقراءة فقط يمكن فحصها أو تسجيلها.

المثال التالي يزيد السطوع بنسبة 15% والتباين بنسبة 20%، ثم يعرض معاينة دون تعديل الصورة المضمنة:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    brightness_contrast = image_transform.addBrightnessContrastEffect(15.0, 20.0)

    effective_values = brightness_contrast.getEffective()
    print("Brightness: ", effective_values.getBrightness(), "%", sep="")
    print("Contrast: ", effective_values.getContrast(), "%", sep="")

    preview = slide.getImage()
    try:
        preview.save("brightness-contrast-preview.png", ImageFormat.Png)
    finally:
        preview.dispose()
finally:
    presentation.dispose()
```

[BrightnessContrast](https://reference.aspose.com/slides/ar/python-java/aspose.slides/brightnesscontrast/) هو امتداد تأثير صورة من Office 2010 وهو أقل قابلية للنقل مقارنةً بتأثير السطوع القياسي في DrawingML. عندما يجب أن يبقى السطوع والتباين قابلين للتحرير بعد جولة PPTX، استخدم [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) وتحقق من النتيجة بعد إعادة فتح الملف. يوضح قسم قيود الصيغة هذا الاختلاف بمزيد من التفصيل.

## **تطبيق تحويلات الألوان**

يمكن تطبيق تأثيرات اللون بشكل مستقل على إطارات صور مختلفة تعيد استخدام مورد صورة واحد. المثال التالي يُنشئ خمسة إطارات ويطبق التدرج الرمادي، الثنائي اللون، الصبغة، تعديل HSL، واستبدال اللون.

[Duotone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/duotone/) يحتوي على معاملين لونيين يمكن تحريرهما بشكل مستقل: `color1` يطابق البكسلات الداكنة، بينما `color2` يطابق البكسلات الفاتحة. هذا يجعله مثالاً مفيداً لتأثير إعداداته أكثر تعقيدًا من قيمة عددية واحدة.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    gray_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image)
    gray_frame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect()

    duotone_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image)
    duotone = duotone_frame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect()
    duotone.getColor1().setColor(Color(0, 0, 128))
    duotone.getColor2().setColor(Color(255, 215, 0))

    tint_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image)
    tint_frame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210.0, 35.0)

    hsl_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image)
    hsl_frame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30.0, 20.0, -10.0)

    replacement_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect()
    color_replacement.getColor().setColor(Color(100, 149, 237))

    presentation.save("color-transformations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[addColorReplaceEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) يستبدل لون كل بكسل بلون ثابت واحد مع الحفاظ على ألفا. وهو مختلف عن [addColorChangeEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect) الذي يطابق لون مصدر بلون هدف ويظهر صيغ كل من اللون المصدر والهدف.

## **إضافة تمويه، شفافية، وتأثيرات ألفا**

[addBlurEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) يؤثر على جميع قنوات اللون، بما في ذلك ألفا. اضبط `grow` إلى `True` عندما قد يمتد حافة التمويه خارج حدود الصورة الأصلية.

لشفافية موحدة، استخدم [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). فهو يضرب كل قيمة ألفا موجودة، لذا تبقى البكسلات شبه الشفافة بنسبة متفاوتة. [addAlphaReplaceEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) يعيّن قيمة ألفا واحدة لكل البكسلات. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) يحول الألفا إلى مستويين بناءً على حدّ.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    blurred_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image)
    blur = blurred_frame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, True)
    blur.setRadius(5)

    transparent_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65.0)
    alpha_modulate.setAmount(60.0)

    uniform_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image)
    uniform_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55.0)

    binary_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50.0)
    alpha_bi_level.setThreshold(45.0)
    binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect()

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

عمليات ألفا الأخرى غير المعتمدة على معاملات تشمل [addAlphaCeilingEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect) الذي يجعل كل ألفا غير صفرية عاتمة بالكامل؛ [addAlphaFloorEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect) الذي يجعل كل ألفا أقل من 100% شفافة تماماً؛ و[addAlphaInverseEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect) الذي يغيّر الألفا إلى `100% - alpha`.

## **بناء سلسلة تأثيرات مرتبة**

كل طريقة `add...Effect` تُضيف عملية جديدة إلى نهاية المجموعة. يستخدم المرسّخ المجموعة كخط إنتاج مرتب: ناتج العملية 0 يصبح مدخل العملية 1، وهكذا. لذلك، نفس العمليات بترتيب مختلف قد تنتج صورة مختلفة.

المثال التالي يبني سلسلة مكوّنة من أربع عمليات، يحفظها كـ PPTX، يعيد فتح العرض، يتحقق من كل من نوع العملية وترتيبها، ويعرض النتيجة المعاد فتحها:

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Blur, GrayScale, ImageFormat, PictureFrame, Presentation, SaveFormat, ShapeType, Tint

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    image_transform.addGrayScaleEffect()
    image_transform.addTintEffect(220.0, 25.0)
    image_transform.addBlurEffect(2.5, False)
    image_transform.addAlphaModulateFixedEffect(80.0)

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("image-transform-chain.pptx")
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(reopened_shape, PictureFrame):
        reopened_transform = reopened_shape.getPictureFormat().getPicture().getImageTransform()
        expected_types = (GrayScale, Tint, Blur, AlphaModulateFixed)
        order_is_preserved = reopened_transform.size() == len(expected_types)
        for index, expected_type in enumerate(expected_types):
            order_is_preserved = order_is_preserved and isinstance(reopened_transform.get_Item(index), expected_type)
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        rendered_slide = reopened_presentation.getSlides().get_Item(0).getImage()
        try:
            rendered_slide.save("reopened-effect-chain.png", ImageFormat.Png)
        finally:
            rendered_slide.dispose()
    else:
        print("The reopened shape is not a picture frame.")
finally:
    reopened_presentation.dispose()
```

المجموعة لا تفرض مصفوفة توافق تقيد عمليات اللون، الألفا، والتمويه لسلاسل منفصلة. يمكن دمجها، لكن ليست كل التركيبات مفيدة دائماً. استبدال اللون الثابت يزيل تباين RGB الذي أنشأته عمليات اللون السابقة؛ التدرج الرمادي بعد الثنائي اللون يزيل اللونين المحددين؛ وعملية سقف أو أرضية أو استبدال أو ثنائية الألفا يمكن أن تحذف تفاصيل الألفا التي تم إنشاؤها سابقاً. ابنِ السلسلة وفقاً لتسلسل معالجة البكسل المطلوب بدلاً من اعتبار عناصرها كعلامات تنسيق غير مرتبة.

## **فحص القيم القابلة للتحرير والفعّالة**

عملية قابلة للتحرير هي الكائن المخزن في `Picture.getImageTransform`. بحسب التأثير، قد تعرض أعضاء قابلة للكتابة مباشرة. على سبيل المثال، [Blur](https://reference.aspose.com/slides/ar/python-java/aspose.slides/blur/) يعرض قيم `radius` و `grow` القابلة للكتابة، [AlphaModulateFixed](https://reference.aspose.com/slides/ar/python-java/aspose.slides/alphamodulatefixed/) يعرض `amount` قابل للكتابة، و[AlphaBiLevel](https://reference.aspose.com/slides/ar/python-java/aspose.slides/alphabilevel/) يعرض `threshold` قابل للكتابة. تأثيرات اللون مثل [Duotone](https://reference.aspose.com/slides/ar/python-java/aspose.slides/duotone/) تعرّض كائنات [ColorFormat](https://reference.aspose.com/slides/ar/python-java/aspose.slides/colorformat/) قابلة للتعديل.

بعض فئات العمليات، بما فيها [BrightnessContrast](https://reference.aspose.com/slides/ar/python-java/aspose.slides/brightnesscontrast/)، [HSL](https://reference.aspose.com/slides/ar/python-java/aspose.slides/hsl/)، [Tint](https://reference.aspose.com/slides/ar/python-java/aspose.slides/tint/)، و[AlphaReplace](https://reference.aspose.com/slides/ar/python-java/aspose.slides/alphareplace/)، لا تعرض القيم العددية التي تم إنشاؤها كخصائص قابلة للكتابة. لتغيير تلك الإعدادات، احذف العملية وأضف بديلة في الموضع المطلوب.

البيانات الفعّالة التي تُرجعها `getEffective` محسوبة ولا يمكن تعديلها. هي مفيدة لحل الألوان المعتمدة على السمة وقراءة القيم المُعيّنة التي يستخدمها المرسّخ، لكنها ليست سطح تحرير آخر. المثال التالي يُعدّ السلسلة ويُفحص القيم الفعّالة حيث توفر الـ API ما يلزم:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaBiLevel, AlphaModulateFixed, AlphaReplace, Blur, BrightnessContrast, ColorReplace, Duotone, HSL, Luminance, PictureFrame, Presentation, Tint

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()

        for index in range(image_transform.size()):
            operation = image_transform.get_Item(index)
            print(index, ": ", operation.getClass().getSimpleName(), sep="")

            if isinstance(operation, BrightnessContrast):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Luminance):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Duotone):
                data = operation.getEffective()
                print("  Dark color: ", data.getColor1(), sep="")
                print("  Light color: ", data.getColor2(), sep="")
            elif isinstance(operation, ColorReplace):
                data = operation.getEffective()
                print("  Replacement color: ", data.getColor(), sep="")
            elif isinstance(operation, HSL):
                data = operation.getEffective()
                print("  HSL: ", data.getHue(), ", ", data.getSaturation(), ", ", data.getLuminance(), sep="")
            elif isinstance(operation, Tint):
                data = operation.getEffective()
                print("  Tint: ", data.getHue(), ", ", data.getAmount(), sep="")
            elif isinstance(operation, Blur):
                data = operation.getEffective()
                print("  Blur radius: ", data.getRadius(), " pt", sep="")
            elif isinstance(operation, AlphaModulateFixed):
                data = operation.getEffective()
                print("  Alpha amount: ", data.getAmount(), "%", sep="")
            elif isinstance(operation, AlphaReplace):
                data = operation.getEffective()
                print("  Replacement alpha: ", data.getAlpha(), "%", sep="")
            elif isinstance(operation, AlphaBiLevel):
                data = operation.getEffective()
                print("  Alpha threshold: ", data.getThreshold(), "%", sep="")
finally:
    presentation.dispose()
```

التأثيرات التي لا تحتاج إلى معلمات مثل التدرج الرمادي، سقف الألفا، والعكس الألفا لا يزال لها كائن بيانات فعّالة، لكن لا توجد إعدادات عددية لطبعها. وجودها وموقعها في المجموعة هو ما يهم.

## **إزالة أو مسح تحويلات الصورة**

استخدم [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) لإزالة عملية واحدة بحسب الفهرس. لأن الفهارس تتshift بعد الإزالة، ابحث عن الهدف أولاً ثم احذفه بعد التعداد. استخدم [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#clear) لإزالة السلسلة بأكملها.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Blur, PictureFrame, Presentation, SaveFormat

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
        blur_index = -1

        for index in range(image_transform.size()):
            if isinstance(image_transform.get_Item(index), Blur):
                blur_index = index
                break

        if blur_index >= 0:
            image_transform.removeAt(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: ", image_transform.size(), sep="")
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

إزالة أو مسح التحويلات يغيّر تنسيق الصورة فقط. لا يحذف أو يُعيد ضغط أو يغير مورد [PPImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/ppimage/) المعاد استخدامه.

## **النظر في صيغ العرض وأهداف التصدير**

تنشأ تحويلات الصورة في DrawingML، لذا فإن PPTX هو الصيغة القابلة للتحرير المفضلة لسلاسل التأثير. حتى مع PPTX، ليست كل عملية ذات قابلية نقل متطابقة:

- عمليات DrawingML القياسية مثل السطوع، التدرج الرمادي، الثنائي اللون، الصبغة، HSL، التمويه، وعمليات الألفا الشائعة لديها أفضل فرصة للبقاء بعد جولة PPTX. دائمًا أعد فتح الملف المُنشأ وتفقد المجموعة عندما تكون الحفظ مطلوبًا.
- [BrightnessContrast](https://reference.aspose.com/slides/ar/python-java/aspose.slides/brightnesscontrast/) هو امتداد Office 2010 وليس عملية سطوع DrawingML القياسية. يمكن استخدامه للتصيير في الذاكرة، لكنه غير مضمون أن يبقى كـ [BrightnessContrast](https://reference.aspose.com/slides/ar/python-java/aspose.slides/brightnesscontrast/) قابل للتحرير بعد حفظ وإعادة فتح PPTX. فضلًا عن ذلك استخدم [addLuminanceEffect](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) للتعديلات المستدامة للسطوع والتباين.
- صيغة PPT الثنائية سابقة لنموذج تأثير DrawingML الكامل. الحفظ إلى PPT قد يحذف عمليات غير مدعومة، يقلل السلسلة إلى مجموعة فرعية مدعومة، أو يقرّب المظهر. لا تستخدم PPT كصيغة للتحقق من سلسلة تحرير معقدة.
- التصيير إلى PNG أو JPEG أو TIFF أو PDF أو SVG أو HTML أو أي مخرج بصري آخر يطبّق السلسلة المدعومة على المظهر المُصوَّر. تلك الصيغ لا تحتوي على `ImageTransformOperationCollection` قابل للتحرير؛ الصيغ النقطية تُسطيح النتيجة إلى بكسلات، وصادرات المستند/الرسوم المتجهة تخزن تمثيل التصيّر الخاص بها.
- التأثيرات لا تجعل الصورة المرتبطة ذاتية الاكتفاء. لا يزال تصيير صورة مرتبطة يعتمد على توفر المورد المرتبط عندما يُحمَّل العرض.

مستهلكو العروض المختلفون قد يصورون الحالات الحدودية بشكل مختلف، خاصةً عندما تُدمج عدة عمليات ألفا أو تلوين. للنتائج الحرجة، اختبر كلًا من جولة التحرير النهائية وصيغة التصدير النهائية باستخدام نفس نسخة Aspose.Slides المستخدمة في الإنتاج.

## **الأسئلة المتكررة**

**هل تعدّ تأثيرات تحويل الصورة بيانات الصورة المضمّنة؟**

لا. العمليات تنتمي إلى `Picture` المستخدمة في تعبئة الصورة. تبقى بايتات `PPImage` الأساسية دون تغيير.

**هل تشترك إطاري صورة يعيدان استخدام نفس الصورة في تأثيراتهما؟**

لا. إعادة استخدام `PPImage` يجنّب تكرار بيانات الصورة، لكن كل إطار صورة عادةً ما يمتلك `Picture` ومجموعة تحويل خاصة به.

**هل يمكن دمج تأثيرات اللون والتمويه والألفا؟**

نعم. تقبل المجموعة ذلك في سلسلة مرتبة واحدة. ضع في اعتبارك ما تفعله كل عملية على مخرجات العملية السابقة لأن عمليات الاستبدال والحدّ قد تُزيل تفاصيل اللون أو الألفا السابقة.

**لماذا القيم الفعّالة للقراءة فقط؟**

البيانات الفعّالة تمثل القيم المحسوبة المستخدمة في التصيير، بما في ذلك الألوان المُحَلَّة. حرّر العملية المخزّنة في مجموعة التحويل حيث تتوفر أعضاء قابلة للكتابة؛ وإلا احذفها وأضف بديلة بمعلمات إنشاء جديدة.

**أي صيغة يجب أن أستخدمها للحفاظ على سلسلة التحويل؟**

استخدم PPTX وتحقق من الملف بإعادة فتحه. صيغة PPT القديمة لا يمكنها تمثيل نموذج تأثير DrawingML الكامل، والصيغ المُصدَّرة (PNG، PDF، إلخ) تحتفظ بالمظهر فقط دون عمليات تحويل قابلة للتحرير.