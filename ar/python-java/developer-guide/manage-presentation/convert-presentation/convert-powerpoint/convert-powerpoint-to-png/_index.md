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

تشرح هذه المقالة كيفية تحويل عروض PowerPoint إلى صور PNG باستخدام Aspose.Slides للغة Python عبر Java. يمكنك تحميل ملفات PPT و PPTX و ODP، وعرض كل شريحة، وحفظها كصورة PNG منفصلة.

تظهر الأمثلة أيضًا كيفية التحكم بأبعاد الإخراج باستخدام عوامل التحجيم أو تحديد عرض وارتفاع دقيقين. يبدأ كل مثال آلة Java الافتراضية إذا لزم الأمر ويحرر موارد العرض والصورة بعد الاستخدام.

## **تحويل PowerPoint إلى PNG**

1. حمّل ملف الإدخال باستخدام الفئة [Presentation](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/).
2. استرجع الشرائح باستخدام [Presentation.getSlides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/presentation/#getSlides).
3. اعرض كل شريحة باستخدام [Slide.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage).
4. احفظ كل صورة معروضة باستخدام [ImageFormat.Png](https://reference.aspose.com/slides/ar/python-java/aspose.slides/imageformat/#Png)، ثم حرّر مواردها.

المثال التالي بلغة Python يصدر جميع الشرائح بالحجم الافتراضي لها:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **تحويل PowerPoint إلى PNG مع مقياس مخصص**

مرّر عوامل التحجيم الأفقية والعمودية إلى [Slide.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage) لزيادة أو تقليل أبعاد الإخراج. على سبيل المثال، شريحة بحجم 720 × 540 نقطة يتم عرضها بعامل تحجيم 2 على كلا المحورين ينتج صورة بحجم 1440 × 1080 بكسل.

استخدم عوامل تحجيم متساوية للحفاظ على نسبة أبعاد الشريحة. العوامل المختلفة تمد الشريحة أفقيًا أو رأسيًا.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **تحويل PowerPoint إلى PNG بحجم مخصص**

لتحديد أبعاد بكسلية دقيقة، مرّر كائن Java `Dimension` مع العرض والارتفاع المطلوبين إلى [Slide.getImage](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage). اختر أبعادًا بنفس نسبة أبعاد الشريحة الأصلية لتجنب التشويه.

المثال التالي يحفظ كل شريحة كصورة PNG بحجم 960 × 720 بكسل:

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
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يمكنني تصدير شكل فردي، مثل مخطط أو صورة، بدلاً من الشريحة كاملة؟**

نعم. يدعم Aspose.Slides [إنشاء صور مصغّرة للأشكال الفردية](/slides/ar/python-java/create-shape-thumbnails/)، والتي يمكنك حفظها كصور PNG.

**هل يمكنني تحويل العروض التقديمية بالتوازي على الخادم؟**

استخدم نسخة عرض تقديمي منفصلة لكل خيط أو عملية، واستخدم مسارات إخراج فريدة لمنع كتابة الملفات فوق بعضها. لا تشارك نسخة العرض التقديمي بين الخيوط. راجع [Multithreading](/slides/ar/python-java/multithreading/).

**ما هي قيود النسخة التجريبية عند التصدير إلى PNG؟**

يضيف وضع التقييم علامة مائية إلى الصور المصدرة ويطبق [قيودًا أخرى](/slides/ar/python-java/licensing/). قم بتطبيق ترخيص لإزالة هذه القيود.