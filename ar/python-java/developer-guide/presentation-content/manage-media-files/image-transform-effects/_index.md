---
title: إدارة تأثيرات تحويل الصورة في العروض التقديمية باستخدام بايثون
linktitle: تأثيرات تحويل الصورة
type: docs
weight: 11
url: /ar/python-java/image-transform-effects/
keywords:
- تحويل الصورة
- تأثير الصورة
- السطوع
- التباين
- تدرج رمادي
- ثنائي اللون
- صبغ
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
description: "تطبيق، ربط، فحص، إزالة، والتحقق من تأثيرات تحويل الصورة لإطارات الصور باستخدام Aspose.Slides لبايثون عبر جافا."
---
## **نظرة عامة**

يمثل Aspose.Slides تعديلات الصورة كمجموعة مرتبة من عمليات تحويل الصورة. لإطار صورة، ابدأ بإطار الـ[Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) وادخل إلى [Picture.getImageTransform](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#getImageTransform). تعيد [ImageTransformOperationCollection](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/) لك إمكانية إلحاق، تعداد، فحص، إزالة، ومسح التأثيرات دون إعادة كتابة بايتات الصورة الأصلية.

توضح هذه المقالة سير عمل كامل للسطوع والتباين، تحويلات اللون، التمويه، الشفافية، سلاسل التأثير المرتبة، القيم الفعّالة، الإزالة، والتحقق من جولة PPTX.

## **فهم ملكية التأثير وإعادة استخدام الصورة**

مورد الصورة والصورة التي تعرضه كائنان مختلفان:

- [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) يخزن أو يشير إلى بيانات الصورة المصدر التي تملكها العرض التقديمي.
- [Picture](https://reference.aspose.com/slides/python-java/aspose.slides/picture/) يخص تعبئة الصورة ويشير إلى مورد الصورة بينما يخزن مجموعة تحويل الصورة.
- [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) هو شكل الشريحة الذي يملك تعبئة الصورة ذات الصلة، الهندسة، إعدادات القص، وغيرها من تنسيقات المستوى الإطاري.

لذلك، لا تعدل عمليات تحويل الصورة البايتات في [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/). عندما يتم تمرير نفس `PPImage` إلى [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) أكثر من مرة، يحصل كل إطار صورة جديد على `Picture` خاص به ومجموعة تحويل خاصة به. تطبيق التدرج الرمادي على إطار واحد لا يجعل باقي الأطر تتبع نفس التأثير، رغم أن جميعها تعيد استخدام نفس مورد الصورة المضمّن.

نفس نموذج `Picture.getImageTransform` يُستعمل أيضاً بواسطة تعبئات الصور الأخرى، مثل شكل أو خلفية الشريحة. الأمثلة أدناه تركز على إطارات الصور.

## **استخدام نطاقات المعلمات الواضحة والوحدات**

تستخدم الطرق الموضحة النطاقات الدلالية والوحدات التالية. حافظ على القيم ضمن هذه النطاقات حتى إذا لم ترفض نسخة المكتبة المستخدمة القيم خارج النطاق فوراً؛ قد يقوم تنسيق العرض المستهدف بتطبيع أو حذف أو رفض البيانات غير الصالحة أثناء الحفظ أو عند فتح الملف في PowerPoint.

| العملية | المعلمات | النطاق والواحدة الصالحة |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | من `-100` إلى `100`٪؛ `0` يترك المكوّن دون تغيير. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | لا شيء | لا توجد معلمات عددية. لا يتغير ألفا. |
| [addDuotoneEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | لونان للبيكسلات الداكنة والفاتحة. قيم القنوات RGB وألفا في `java.awt.Color` تتراوح من `0` إلى `255`. |
| [addTintEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | `hue` من `0` (شاملاً) إلى `360` (إقصائي) بالدرجات؛ `amount` من `-100` إلى `100`٪. |
| [addHSLEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | `hue` من `0` (شاملاً) إلى `360` (إقصائي) بالدرجات؛ التشبع والإضاءة من `-100` إلى `100`٪. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | يستخدم اللون البديل قيم القنوات من `0` إلى `255`. تظل قيم ألفا الحالية دون تغيير. |
| [addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | نصف القطر غير سالب ويُقاس بالنقاط؛ `grow` هو قيمة منطقية تتحكم فيما إذا كان المحتوى المموه قد يمتد خارج الحدود الأصلية. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | نسبة مئوية غير سلبية. استخدم `0` إلى `100` لتقليص الشفافية العادية: `0` شفاف بالكامل و`100` يحافظ على ألفا الحالي. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | من `0` إلى `100`٪ شفافية. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | من `0` إلى `100`٪ عتبة ألفا. القيم الأقل تصبح شفافة؛ القيم عند أو فوق العتبة تصبح غير شفافة. |

في تعديل ألفا الثابت، الشفافية والعتامة متكاملتان. على سبيل المثال، شفافية بنسبة 35٪ تقابل مقدار تعديل ألفا بنسبة 65٪.

## **تطبيق السطوع والتباين**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) تُعيد عملية [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/). تُزوَّد إعدادات المتغيّر عند إنشاء العملية. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/#getEffective) تُعيد قيماً محسوبة للقراءة فقط يمكن فحصها أو تسجيلها.

الشفرة التالية تزيد السطوع بنسبة 15٪ والتباين بنسبة 20٪، ثم تُظهر معاينة دون تعديل الصورة المضمّنة:

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

[BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) هو امتداد لتأثيرات الصور في Office 2010 وهو أقل قابلية للنقل من تأثير الإضاءة القياسي في DrawingML. عندما يجب أن يبقى السطوع والتباين قابليين للتحرير بعد جولة PPTX، استخدم [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) وتحقق من النتيجة بعد إعادة فتح الملف. يوضح قسم قيود التنسيق هذا الفرق بمزيد من التفصيل.

## **تطبيق تحويلات اللون**

يمكن تطبيق تأثيرات اللون بصورة مستقلة على إطارات صور مختلفة تعيد استخدام مورد صورة واحد. المثال التالي ينشئ خمسة إطارات ويطبق التدرج الرمادي، الثنائي اللون، الصبغ، تعديل HSL، واستبدال اللون.

[Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) يحتوي على معاملين لونيين يمكن تحريرهما بشكل مستقل: `color1` يطبع البيكسلات الداكنة، بينما `color2` يطبع البيكسلات الفاتحة. هذا يجعله مثالاً مفيداً لتأثير إعداداته أكثر تعقيداً من قيمة متغيّر واحدة.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) يستبدل لون كل بيكسل بلون ثابت مع الحفاظ على قيمة ألفا. وهو مختلف عن [addColorChangeEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect) الذي يطبع لون مصدر إلى آخر ويكشف تنسيقات اللون المصدر والهدف.

### **تطبيق عتبة الإضاءة**

يمكن لعَتبة الإضاءة أن تجعل العلامات الخفيفة على صفحة ممسوحة ضوئياً أسهل للتمييز عن الخلفية. [addGrayScaleEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) يحافظ على الدرجات المتوسطة من الرمادي. [addBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBiLevelEffect) يطبع الإضاءة إلى أسود أو أبيض، بينما [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) يطبق عتبة على العتمة.

تتراوح عتبة الإضاءة من 0٪ إلى 100٪ شاملة. البيكسلات أدنى العتبة تصبح سوداء. البيكسلات عند أو فوق العتبة تصبح بيضاء. رفع العتبة يجعل المزيد من الظلال سوداء لأن المزيد منها يقع تحت الحد.

حمّل [grayscale-swatches.png](grayscale-swatches.png) إلى دليل العمل. كل تسمية تعطي مستوى الرمادي الأصلي على مقياس من 0 إلى 255. يعرض المثال الأصلي جنباً إلى جنب نسختين ويخزن عتبة كل نسخة في العرض التقديمي.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720.0, 150.0, SlideSizeScaleType.DoNotScale)
    shapes = presentation.getSlides().get_Item(0).getShapes()

    image_data = Path("grayscale-swatches.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    frames = []
    for index, caption in enumerate(("Original", "Threshold 20%", "Threshold 60%")):
        x = 12 + 240 * index
        label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36)
        label.getTextFrame().setText(caption)
        frame = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image)
        frames.append(frame)

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20.0)
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60.0)

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

افتح العرض التقديمي الناتج في PowerPoint لمقارنة الإطارات الثلاثة. العينة الموسومة بـ 96 تمتلك تقريباً 38٪ إضاءة (96 من 255). تتحول إلى أبيض عند عتبة 20٪ وتصبح سوداء عند عتبة 60٪.

![مقاييس الرمادي الأصلية بجانب نتائج الأسود‑أبيض عند عتبة إضاءة 20٪ و60٪](luminance-threshold.png)

## **إضافة تمويه، شفافية، وتأثيرات ألفا**

[addBlurEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) يؤثر على جميع قنوات اللون، بما فيها ألفا. اضبط `grow` إلى `True` عندما قد يمتد الحافة المموهة خارج حدود الصورة الأصلية.

للشفافية المتساوية، استخدم [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). إنه يضرب كل قيمة ألفا موجودة، لذا تبقى البيكسلات نصف شفافة بنسب متفاوتة. [addAlphaReplaceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) يعيّن قيمة ألفا واحدة لكل البيكسلات. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) يحول ألفا إلى مستويين بناءً على عتبة.

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

تشمل العمليات الأخرى غير المعتمدة على معلمات ألفا: [addAlphaCeilingEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect) الذي يجعل كل ألفا غير صفرية غير شفافة بالكامل؛ [addAlphaFloorEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect) الذي يجعل كل ألفا أقل من 100٪ شفافة بالكامل؛ و[addAlphaInverseEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect) الذي يغيّر ألفا إلى `100% - alpha`.

## **بناء سلسلة تأثيرات مرتبة**

كل طريقة `add...Effect` ترفق عملية جديدة في نهاية المجموعة. يستخدم المُظهر المجموعة كهامش مرتّب: ناتج العملية 0 يصبح مدخل العملية 1، وهكذا. وبالتالي، يمكن أن ينتج عن نفس العمليات بترتيب مختلف صورة مختلفة.

على سبيل المثال، التدرج الرمادي ثم الصبغ يزيل أولاً المعلومات اللونية ثم يعيد تلوين النتيجة الإضائية. الصبغ ثم التدرج الرمادي يزيل الصبغ مجدداً. بالمثل، استبدال ألفا يمكن أن يتجاوز قيم ألفا التي حسبتها العمليات السابقة، بينما تعديل ألفا يحافظ على الفروقات النسبية بينها.

الشفرة التالية تبني سلسلة مكوَّنة من أربع عمليات، تحفظها كملف PPTX، تفتح العرض مرة أخرى، تتحقق من نوعية العمليات وترتيبها، وتُظهر النتيجة المفتوحة مجدداً:

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

المجموعة لا تفرض مصفوفة توافق تقيد عمليات اللون، ألفا، والتمويه إلى سلاسل منفصلة. يمكن دمجها، لكن الجمع ليس دائماً مفيداً. استبدال اللون الثابت يزيل تباين RGB الناتج عن تأثيرات اللون السابقة؛ التدرج الرمادي بعد الثنائي اللون يزيل اللونين المختارين؛ وعمليات ألفا السقفية، الأرضية، الاستبدال أو العتبة قد تُزيل تفاصيل ألفا التي أُنشئت مسبقاً. ابنِ السلسلة بناءً على تسلسل معالجة البكسل المطلوب بدلاً من اعتبار عناصرها كعلامات تنسيق غير مرتبة.

<!-- visual-explanation:image-transform-effects:start -->
[![تمرّن الصورة نفسها عبر التدرج الرمادي ثم الصبغ، والصبغ ثم التدرج الرمادي. الصورتان النهائيتان ذات التدرج الرمادي لهما نغمات مختلفة.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*في هذا التوضيح باستخدام Aspose.Slides for .NET 26.11، صبغ بزاوية 220° بنسبة 25٪ لا يغيّر الصورة الرمادية. تطبيق الصبغ نفسه قبل التدرج الرمادي ينتج نغمات مختلفة.*
<!-- visual-explanation:image-transform-effects:end -->

## **فحص القيم القابلة للتحرير والفعّالة**

العملية القابلة للتحرير هي الكائن المخزن في `Picture.getImageTransform`. بحسب التأثير، قد يعرض أعضاء قابلين للكتابة مباشرة. على سبيل المثال، [Blur](https://reference.aspose.com/slides/python-java/aspose.slides/blur/) يعرض قيم `radius` و `grow` القابلة للكتابة، و[AlphaModulateFixed](https://reference.aspose.com/slides/python-java/aspose.slides/alphamodulatefixed/) يعرض `amount` القابل للكتابة، و[AlphaBiLevel](https://reference.aspose.com/slides/python-java/aspose.slides/alphabilevel/) يعرض `threshold` القابل للكتابة. تأثيرات اللون مثل [Duotone](https://reference.aspose.com/slides/python-java/aspose.slides/duotone/) تعرض كائنات [ColorFormat](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/) قابلة للتعديل.

بعض فئات العمليات، بما فيها [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/)، [HSL](https://reference.aspose.com/slides/python-java/aspose.slides/hsl/)، [Tint](https://reference.aspose.com/slides/python-java/aspose.slides/tint/)، و[AlphaReplace](https://reference.aspose.com/slides/python-java/aspose.slides/alphareplace/)، لا تعرض المتغيّرات التي تم إنشاؤها كخصائص قابلة للكتابة. لتغيير هذه الإعدادات، احذف العملية وأضف بديلًا في الموضع المطلوب.

البيانات الفعّالة التي تُرجعها `getEffective` محسوبة ولا يمكن تعديلها. هي مفيدة لحل ألوان تعتمد على السمة وقراءة القيم المُعيرة التي يستخدمها المُظهر، لكنها ليست سطح تحرير آخر. الشفرة التالية تعداد السلسلة وتفحص القيم الفعّالة حيث توفر API المقابلة هذه القيم:

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

التأثيرات غير المعتمدة على معلمات مثل التدرج الرمادي، السقف ألفا، والعكس ألفا لا يزال لديها كائن بيانات فعّال، لكن لا توجد إعدادات متغيّرة لطبعها. وجودها وموقعها في المجموعة هو المعلومات المهمة.

## **إزالة أو مسح تحويلات الصورة**

استخدم [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) لإزالة عملية واحدة بحسب الفهرس. لأن الفهارس تنتقل بعد الإزالة، ابحث عن الهدف أولاً وأزله بعد التعداد. استخدم [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#clear) لإزالة السلسلة بأكملها.

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

إزالة أو مسح التحويلات يغيّر تنسيق الصورة فقط. لا يحذف، يضغط، أو يغيّر بأي شكل مورد [PPImage](https://reference.aspose.com/slides/python-java/aspose.slides/ppimage/) المعاد استخدامها.

## **مراعاة تنسيقات العرض ووجهات التصدير**

تنشأ تحويلات الصورة في DrawingML، لذا فإن PPTX هو التنسيق القابل للتحرير المفضّل لسلاسل التأثير. حتى مع PPTX، ليست كل عملية ذات قابلية نقل متساوية:

- عمليات DrawingML القياسية مثل الإضاءة، التدرج الرمادي، الثنائي اللون، الصبغ، HSL، التمويه، والعمليات الشائعة لألفا لديها أفضل فرصة للبقاء بعد جولة PPTX. احفظ الملف وافتحه مرة أخرى وتفقد المجموعة عندما يكون الحفاظ شرطاً.
- [BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) هو امتداد Office 2010 وليس عملية الإضاءة القياسية في DrawingML. يمكن استعماله للعرض داخل الذاكرة، لكنه غير مضمون أن يبقى كـ[BrightnessContrast](https://reference.aspose.com/slides/python-java/aspose.slides/brightnesscontrast/) قابل للتحرير بعد حفظ وإعادة فتح PPTX. فضلًا عن [addLuminanceEffect](https://reference.aspose.com/slides/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) للتعديلات المستدامة للسطوع والتباين.
- تنسيق PPT الثنائي يسبق نموذج تأثير DrawingML الكامل. الحفظ إلى PPT قد يحذف عمليات غير مدعومة، يقلّص السلسلة إلى مجموعة فرعية مدعومة، أو يقرّب المظهر. لا تستخدم PPT كتنسيق تحقق لسلسلة تحريرية مركبة.
- التصدير إلى PNG، JPEG، TIFF، PDF، SVG، HTML أو أي إخراج بصري آخر يطبق السلسلة المدعومة على المظهر المرسوم. تلك المخرجات لا تحتوي على `ImageTransformOperationCollection` قابلة للتحرير؛ الصيغ النقطية (raster) تسطح النتيجة إلى بيكسلات، وتصديرات المستند/الرسوم المتجهة تخزن تمثيلها الخاص للعرض.
- التأثيرات لا تجعل الصورة المرتبطة ذاتية الاكتفاء. لا يزال عرض صورة مرتبطة يعتمد على توفر المورد المرتبط عند تحميل العرض التقديمي.

قد يعرض مستهلكو العروض التقديمية المختلفون الحالات الحدية بشكل مختلف، خصوصاً عند دمج عدة عمليات ألفا أو تكميم اللون. للنتائج الحرجة، اختبر كل من جولة التحرير النهائية وتنسيق التصدير النهائي باستخدام نفس نسخة Aspose.Slides المستخدمة في الإنتاج.

## **الأسئلة المتكررة**

**هل تعدّل تأثيرات تحويل الصورة البيانات المضمّنة للصورة؟**

لا. العمليات تخص الـ`Picture` المستخدم لتعبئة الصورة. تبقى بايتات الـ`PPImage` الأساسية دون تغيير.

**هل تشارك إطاري صور يعيدان استخدام نفس الصورة تأثيراتهما؟**

لا. إعادة استخدام `PPImage` تجنّب تكرار بيانات الصورة، لكن كل إطار صورة يمتلك عادةً `Picture` ومجموعة تحويل منفصلة.

**هل يمكن دمج تأثيرات اللون، التمويه، والألفا؟**

نعم. تقبل المجموعة دمجها في سلسلة مرتّبة واحدة. ضع في اعتبارك ما تفعله كل عملية على ناتج السابقة لأن عمليات الاستبدال والعتبة قد تُزيل تفاصيل اللون أو الألفا السابقة.

**لماذا القيم الفعّالة للقراءة فقط؟**

البيانات الفعّالة تمثل القيم المحسوبة المستخدمة للعرض، بما فيها الألوان محلولة. حرّر العملية المخزنة في مجموعة التحويل حيث توجد خصائص قابلة للكتابة؛ وإلا احذفها وأضف بديلة بمعلمات إنشاء جديدة.

**أي تنسيق يجب أن أستخدم للحفاظ على سلسلة التحويل؟**

استخدم PPTX وتحقق من الملف بإعادة فتحه. لا يمكن لـ PPT القديم تمثيل نموذج تأثير DrawingML بالكامل، وتنسيقات التصدير المرئية تحتفظ بالمظهر فقط دون عمليات تحويل قابلة للتحرير.