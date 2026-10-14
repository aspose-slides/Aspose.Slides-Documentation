---
title: تحويل شرائح PowerPoint إلى PNG في Python
linktitle: PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/python-java/convert-powerpoint-to-png/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PNG
- العرض التقديمي إلى PNG
- الشريحة إلى PNG
- PPT إلى PNG
- PPTX إلى PNG
- حفظ PPT كـ PNG
- حفظ PPTX كـ PNG
- تصدير PPT إلى PNG
- تصدير PPTX إلى PNG
- Python
- Java
- Aspose.Slides
description: "تحويل شرائح PowerPoint إلى صور PNG في Python عبر Java. تصدير عروض PPT و PPTX و ODP مع مقاييس مخصصة أو أبعاد صورة دقيقة."
---
## **نظرة عامة**

تشرح هذه المقالة كيفية تحويل شرائح العروض التقديمية إلى صور PNG باستخدام Aspose.Slides للـ Python عبر Java. يمكنك تحميل العروض بتنسيقات مثل PPT و PPTX و ODP، وعرض كل شريحة، وحفظها كصورة PNG منفصلة.

توضح الأمثلة أدناه عرض الشرائح بالمقياس الافتراضي، زيادة المقياس، تحديد أبعاد الإخراج بالبكسل، واختيار نمط عرض التدرج.

## **Convert PowerPoint to PNG**

حمّل عرضًا باستخدام الفئة [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) وادخل إلى شرائحه عبر مجموعة [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides). يقوم المثال بعرض كل شريحة باستخدام [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) بدون معاملات لإنشاء صورة مصغرة. ثم يستدعي [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) مع [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) لحفظ كل شريحة معروضة كصورة PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
تقوم الدالة [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) التي لا تتطلب معاملات بعرض الصورة بمقياس 0.2. على سبيل المثال، شريحة قياسها 720 × 540 نقطة تنتج صورة مصغرة بحجم 144 × 108 بكسل. للتحكم في أبعاد الإخراج، استخدم الدالات التي تقبل عوامل مقياس أو حجم صورة صريح كما هو موضح أدناه.
{{% /alert %}}

## **Convert PowerPoint to PNG With Custom Dimensions**

مرّر عوامل مقياس أفقية ورأسية إلى [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) للتحكم في أبعاد العرض. في هذا المثال، كلا العاملين يساويان 2، وبالتالي شريحة قياسها 720 × 540 نقطة تنتج صورة بحجم 1440 × 1080 بكسل. عوامل المقياس المتساوية تحافظ على نسبة أبعاد الشريحة. كل صورة تم عرضها تُحفظ بتنسيق PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Convert PowerPoint to PNG With Custom Size**

لتحديد أبعاد الإخراج بالبكسل، مرّر حجمًا إلى [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) بدلاً من عوامل المقياس. يعرض هذا المثال كل شريحة بدقة 960 × 720 بكسل ويحفظ النتيجة بتنسيق PNG. اختر أبعادًا تتطابق مع نسبة أبعاد الشريحة لتجنب تشويه الصورة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Choose a Gradient Rendering Style**

افترض أن الشريحة تحتوي على تعبئات متدرجة، لكن الانتقالات في صورة PNG المصدرة تظهر أخف أو مختلفة عن ما تراه في PowerPoint. يمكنك استخدام الطريقة [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) الموروثة من [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) لاختيار طريقة عرض التدرجات.

حمّل الملف [gradient-styles.pptx](gradient-styles.pptx) وضعه في دليل العمل الخاص بالتطبيق. تحتوي شريحته الأولى على تدرجين خطيين: من السيان إلى البرتقالي في الأعلى ومن الأزرق إلى الأصفر في الأسفل. كل تدرج له نقطتا توقف عند 0% و 100%.

المثال التالي يحمل هذا العرض ويعرض الشريحة الأولى نفسها في كلا الوضعين باستخدام [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

الصور أدناه تُظهر النتيجة من نفس الشريحة، مع وجود كل من التدرجات في كل صورة:

| الافتراضي | PowerPointUI |
| --- | --- |
| ![تدرجات من السيان إلى البرتقالي ومن الأزرق إلى الأصفر تم عرضها باستخدام الافتراضي](gradient-Default.png) | ![نفس التدرجات تم عرضها باستخدام PowerPointUI](gradient-PowerPointUI.png) |

في هذا المثال، ينتج `Default` ألوانًا وسطية أخف، بينما ينتج `PowerPointUI` ألوانًا وسطية أغمق. يعتمد الفرق على الألوان ونقاط التوقف في التدرج.

اختر `Default` عندما يكون إخراج Aspose.Slides القياسي مناسبًا لاحتياجاتك. جرّب `PowerPointUI` عندما تكون الأولوية لمطابقة المظهر في PowerPoint. قارن كلا الإخراجين مع النتيجة المطلوبة؛ لا يُفضَّل أي وضع على الآخر بشكل عالمي.

## **FAQ**

**كيف يمكنني تصدير شكل معين، مثل مخطط أو صورة، بدلاً من الشريحة بأكملها؟**

يدعم Aspose.Slides [إنشاء صور مصغرة للأشكال الفردية](/slides/ar/python-java/create-shape-thumbnails/)، مما يتيح لك عرض شكل كصورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**

نعم. استخدم مثيل عرض منفصل لكل خيط أو عملية؛ [عدم مشاركة مثيل واحد عبر الخيوط](/slides/ar/python-java/multithreading/).

**ما هي قيود النسخة التجريبية عند التصدير إلى PNG؟**

تضيف وضعية التقييم علامة مائية إلى الصور المصدرة وتطبق [قيود أخرى](/slides/ar/python-java/licensing/) حتى يتم تفعيل الترخيص.