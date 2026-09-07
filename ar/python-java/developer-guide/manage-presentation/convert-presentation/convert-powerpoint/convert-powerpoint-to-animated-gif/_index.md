---
title: تحويل عروض PowerPoint إلى GIF متحرك في Python
linktitle: PowerPoint إلى GIF
type: docs
weight: 65
url: /ar/python-java/convert-powerpoint-to-animated-gif/
keywords:
- GIF متحرك
- تحويل PowerPoint
- تحويل العرض
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى GIF
- العرض إلى GIF
- الشريحة إلى GIF
- PPT إلى GIF
- PPTX إلى GIF
- حفظ PPT كـ GIF
- حفظ PPTX كـ GIF
- تصدير PPT كـ GIF
- تصدير PPTX كـ GIF
- الإعدادات الافتراضية
- الإعدادات المخصصة
- PowerPoint
- العرض
- Python
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint (PPT, PPTX) إلى GIFs متحركة بسهولة باستخدام Aspose.Slides للـ Python عبر Java. نتائج سريعة وعالية الجودة."
---
## **نظرة عامة**

Aspose.Slides for Python via Java تسمح لك بتحويل عروض PowerPoint إلى ملفات GIF متحركة ببضعة أسطر من الشيفرة فقط. هذا مفيد لمشاركة محتوى الشرائح في صفحات الويب أو التطبيقات الرسائلية أو الوثائق. يشرح هذا المقال كيفية تصدير عرض باستخدام الإعدادات الافتراضية وكيفية تخصيص حجم الإطار، وتأخير الشريحة، ومعدل إطارات الانتقال عبر [GifOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/gifoptions/).

## **تحويل العروض إلى GIF متحرك باستخدام الإعدادات الافتراضية**

المثال التالي بلغة Python يقوم بتحميل `pres.pptx` ويحفظه كملف GIF متحرك باستخدام الإعدادات القياسية:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.gif", SaveFormat.Gif)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}
لتخصيص مخرجات GIF، مرر كائن [GifOptions](https://reference.aspose.com/slides/ar/python-java/aspose.slides/gifoptions/) عند الحفظ، كما هو موضح أدناه.
{{% /alert %}}

## **تحويل العروض إلى GIF متحرك باستخدام إعدادات مخصصة**

استخدم [setFrameSize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/gifoptions/#setFrameSize) لتحديد أبعاد الإخراج بالبكسل، و[setDefaultDelay](https://reference.aspose.com/slides/ar/python-java/aspose.slides/gifoptions/#setDefaultDelay) لتعيين تأخير الشريحة الافتراضي بالمللي ثانية، و[setTransitionFps](https://reference.aspose.com/slides/ar/python-java/aspose.slides/gifoptions/#setTransitionFps) للتحكم في معدل إطارات الانتقال.

المثال التالي يصدر GIF بحجم 960 × 720 مع تأخير افتراضي للشريحة يبلغ ثانيتين و35 إطارًا في الثانية للانتقالات. يُطبق التأخير الافتراضي عندما لا يتم ضبط زمن التقدم بعد الشريحة.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GifOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    gif_options = GifOptions()
    frame_size = Dimension(960, 720)
    gif_options.setFrameSize(frame_size)
    gif_options.setDefaultDelay(2000)
    gif_options.setTransitionFps(35)

    presentation.save("pres.gif", SaveFormat.Gif, gif_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
يمكنك أيضًا تجربة أداة التحويل المجانية من Aspose [Text to GIF](https://products.aspose.app/slides/ar/text-to-gif).
{{% /alert %}}

## **الأسئلة الشائعة**

**ماذا لو لم تكن الخطوط المستخدمة في العرض مثبتة على النظام؟**

ثبّت الخطوط المفقودة أو [configure fallback fonts](/slides/ar/python-java/powerpoint-fonts/). يمكن لاستبدال الخطوط أن يغيّر مظهر الـ GIF المصدر. من الضروري توفير الخطوط الأصلية لضمان مطابقة تصميم العرض.

**هل يمكنني إضافة علامة مائية على إطارات GIF؟**

نعم. [Add a semi-transparent object or logo](/slides/ar/python-java/watermark/) إلى الشرائح الرئيسية ذات الصلة أو إلى الشرائح الفردية قبل التصدير. تصبح العلامة المائية جزءًا من محتوى الشريحة المرسوم.