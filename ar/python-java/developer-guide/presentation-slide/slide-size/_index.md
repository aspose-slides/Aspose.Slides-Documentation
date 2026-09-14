---
title: تغيير حجم شريحة العرض التقديمي باستخدام Python عبر Java
linktitle: حجم الشريحة
type: docs
weight: 70
url: /ar/python-java/slide-size/
keywords:
- حجم الشريحة
- نسبة العرض إلى الارتفاع
- قياسي
- شاشة عريضة
- 4:3
- 16:9
- تعيين حجم الشريحة
- تغيير حجم الشريحة
- حجم شريحة مخصص
- حجم شريحة خاص
- حجم شريحة فريد
- شريحة بالحجم الكامل
- نوع الشاشة
- عدم التحجيم
- تأكد من الملاءمة
- تكبير
- PowerPoint
- OpenDocument
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تعلّم كيفية تغيير حجم الشرائح بسرعة في ملفات PPT و PPTX و ODP باستخدام Python عبر Java و Aspose.Slides، وتحسين العروض التقديمية لأي شاشة دون فقدان الجودة."
---
## **المقدمة**

توفر Aspose.Slides أدوات شاملة لضبط حجم الشريحة ونسبة العرض إلى الارتفاع في عروض PowerPoint التقديمية، وهو أمر حاسم لكل من الطباعة والعرض على الشاشة.

الأحجام الشائعة للشرائح والنسب:

- **قياسي (نسبة 4:3)**: مثالي للشاشات والأجهزة القديمة.
- **شاشة عريضة (نسبة 16:9)**: يُنصح به للعارضات الحديثة وأجهزة العرض.

تأكد من الاتساق طوال العرض التقديمي حيث يُطبق حجم الشريحة ونسبة العرض إلى الارتفاع الموحد على جميع الشرائح. للحصول على أفضل النتائج، اضبط أبعاد الشريحة في بداية عملية إنشاء العرض لتجنب التعقيدات.

{{% alert color="info" title="Note" %}}
بشكل افتراضي، تستخدم العروض التي تم إنشاؤها باستخدام Aspose.Slides النسبة القياسية 4:3.
{{% /alert %}}

## **تغيير حجم الشريحة في العروض التقديمية**

يظهر لك هذا المثال البرمجي كيفية تغيير حجم الشريحة في عرض تقديمي باستخدام Python عبر Java مع Aspose.Slides:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres-4x3-aspect-ratio.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.OnScreen16x9, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-16x9-aspect-ratio.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **تحديد أحجام شريحة مخصصة في العروض التقديمية**

إذا وجدت أن أحجام الشرائح الشائعة (4:3 و 16:9) غير مناسبة لعملك، قد تقرر استخدام حجم شريحة محدد أو فريد. على سبيل المثال، إذا كنت تخطط لطباعة شرائح بالحجم الكامل من عرضك على تخطيط صفحة مخصص أو إذا كنت تنوي عرض عرضك على أنواع معينة من الشاشات، فمن المرجح أن تستفيد من إعداد حجم مخصص للعرض.

يظهر لك هذا المثال البرمجي كيفية استخدام Aspose.Slides للـ Python عبر Java لتحديد حجم شريحة مخصص لعرض تقديمي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(780, 540, SlideSizeScaleType.DoNotScale)
    presentation.save("pres-custom-slide-size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **معالجة محتوى الشريحة بعد إعادة الحجم**

بعد تغيير حجم الشريحة في عرض تقديمي، قد يصبح محتوى الشرائح (مثل الصور أو الكائنات) مشوشًا. بشكل افتراضي، يتم تعديل حجم الكائنات تلقائيًا لتتناسب مع حجم الشريحة الجديد. ومع ذلك، عند تغيير حجم شريحة العرض، يمكنك تحديد إعداد يحدد كيفية تعامل Aspose.Slides مع المحتوى على الشرائح.

اعتمادًا على ما تنوي القيام به أو تحقيقه، يمكنك استخدام أي من هذه الإعدادات:

- [DoNotScale](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  إذا لم تكن تريد أن يُعاد تحجيم الكائنات على الشرائح، استخدم هذا الإعداد.

- [EnsureFit](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  إذا أردت التحجيم إلى حجم شريحة أصغر وتحتاج إلى أن تقوم Aspose.Slides بتقليص كائنات الشرائح لضمان ملائمتها جميعًا (بهذا تتجنب فقدان المحتوى)، استخدم هذا الإعداد.

- [Maximize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesizescaletype/#Maximize)

  إذا أردت التحجيم إلى حجم شريحة أكبر وتحتاج إلى أن تقوم Aspose.Slides بتكبير كائنات الشرائح لتصبح متناسبة مع الحجم الجديد، استخدم هذا الإعداد.

يظهر لك هذا المثال البرمجي كيفية استخدام إعداد [Maximize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesizescaletype/#Maximize) عند تغيير حجم شريحة العرض التقديمي:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType, SlideSizeType

presentation = Presentation("pres.pptx")
try:
    presentation.getSlideSize().setSize(SlideSizeType.Ledger, SlideSizeScaleType.Maximize)
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**هل يمكنني تعيين حجم شريحة مخصص باستخدام وحدات غير البوصة (على سبيل المثال، النقاط أو المليمترات)؟**

نعم. تستخدم Aspose.Slides النقاط داخليًا، حيث أن النقطة الواحدة تساوي 1/72 من الإنش. يمكنك تحويل أي وحدة (مثل المليمترات أو السنتيمترات) إلى نقاط واستخدام القيم المحولة لتحديد عرض وارتفاع الشريحة.

**هل سيؤثر حجم شريحة مخصص كبير جدًا على الأداء واستهلاك الذاكرة أثناء التصيير؟**

نعم. الأبعاد الأكبر للشرائح (بالنقاط) بالإضافة إلى مقياس تصيير أعلى يؤدي إلى زيادة استهلاك الذاكرة وزيادة زمن المعالجة. احرص على اختيار حجم شريحة عملي وضبط مقياس التصيير فقط حسب الحاجة لتحقيق الجودة المطلوبة للمخرجات.

**هل يمكنني تعريف حجم شريحة غير قياسي ثم دمج الشرائح من عروض تقديمية ذات أحجام مختلفة؟**

لا يمكنك [merge presentations](/slides/ar/python-java/merge-presentation/) بينما لديها أحجام شرائح مختلفة — أولاً، أعد تحجيم أحد العروض ليطابق الآخر. عند تغيير حجم الشريحة، يمكنك اختيار كيفية معالجة المحتوى الموجود عبر خيار [SlideSizeScaleType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesizescaletype/). بعد توحيد الأحجام، يمكنك دمج الشرائح مع الحفاظ على التنسيق.

**هل يمكنني إنشاء صور مصغرة للأشكال الفردية أو مناطق معينة من الشريحة، وهل ستحترم حجم الشريحة الجديد؟**

نعم. يمكن لـ Aspose.Slides إنشاء صور مصغرة لـ [entire slides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage) وكذلك لـ [selected shapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getImage). تعكس الصور الناتجة حجم الشريحة الحالي والنسبة المئوية، مما يضمن تأطيرًا وتكوينًا متسقًا.