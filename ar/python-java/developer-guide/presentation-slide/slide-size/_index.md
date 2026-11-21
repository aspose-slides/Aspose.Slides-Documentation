---
title: "تغيير حجم شريحة العرض التقديمي في Python عبر Java"
linktitle: "حجم الشريحة"
type: docs
weight: 70
url: /ar/python-java/slide-size/
keywords:
  - "حجم الشريحة"
  - "نسبة العرض إلى الارتفاع"
  - "قياسي"
  - "عريض الشاشة"
  - "4:3"
  - "16:9"
  - "تعيين حجم الشريحة"
  - "تغيير حجم الشريحة"
  - "حجم شريحة مخصص"
  - "حجم شريحة خاص"
  - "حجم شريحة فريد"
  - "شريحة بالحجم الكامل"
  - "نوع الشاشة"
  - "عدم التحجيم"
  - "التأكد من الملاءمة"
  - "تعظيم"
  - PowerPoint
  - OpenDocument
  - "عرض تقديمي"
  - Python
  - Java
  - Aspose.Slides
description: "تعلم كيفية تغيير حجم الشرائح بسرعة في ملفات PPT و PPTX و ODP باستخدام Python عبر Java و Aspose.Slides، وتحسين العروض التقديمية لأي شاشة دون فقدان الجودة."
---
## **مقدمة**

توفر Aspose.Slides أدوات شاملة لضبط حجم الشريحة ونسبة العرض إلى الارتفاع في عروض PowerPoint، وهو أمر حاسم لكل من الطباعة والعرض على الشاشة.

أحجام الشرائح الشائعة والنسب:

- **قياسي (نسبة 4:3)**: مثالي للشاشات والأجهزة القديمة.
- **عريض (نسبة 16:9)**: يوصى به لأجهزة العرض الحديثة والشاشات.

تأكد من الاتساق عبر جميع الشرائح حيث يتم تطبيق حجم شريحة واحد ونسبة عرض إلى ارتفاع واحدة على جميع الشرائح. للحصول على أفضل النتائج، اضبط أبعاد الشريحة في بداية عملية إنشاء العرض لتجنب التعقيدات.

{{% alert color="info" title="Note" %}}
بشكل افتراضي، يستخدم العروض التي تُنشأ بـ Aspose.Slides النسبة القياسية 4:3.
{{% /alert %}}

صفحات الملاحظات والمواد المرافقه لها أبعاد منفصلة عن الشرائح العادية. راجع [حجم صفحة الملاحظات](/slides/ar/python-java/notes-size/) لتغيير الحجم والاتجاه.

## **تغيير حجم الشريحة في العروض التقديمية**

يعرض هذا المثال البرمجي كيفية تغيير حجم الشريحة في عرض تقديمي باستخدام Python عبر Java مع Aspose.Slides:

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

## **تحديد أحجام شرائح مخصصة في العروض التقديمية**

إذا وجدت أن أحجام الشرائح الشائعة (4:3 و16:9) غير مناسبة لعملك، يمكنك اختيار حجم شريحة محدد أو فريد. على سبيل المثال، إذا كنت تخطط لطباعة الشرائح بحجم كامل من عرضك على تخطيط صفحة مخصص أو إذا كنت ترغب في عرض العرض على أنواع شاشات معينة، قد تستفيد من استخدام إعداد حجم مخصص للعرض.

يعرض هذا المثال البرمجي كيفية استخدام Aspose.Slides للـ Python عبر Java لتحديد حجم شريحة مخصص لعرض تقديمي:

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

## **معالجة محتوى الشرائح بعد تعديل الحجم**

بعد تغيير حجم الشريحة لعرض تقديمي، قد يصبح محتوى الشرائح (مثل الصور أو الكائنات) مشوهًا. بشكل افتراضي، يتم تحجيم الكائنات تلقائيًا لتتناسب مع حجم الشريحة الجديد. ومع ذلك، عند تغيير حجم شريحة العرض، يمكنك تحديد إعداد يحدد كيفية تعامل Aspose.Slides مع المحتوى داخل الشرائح.

اعتمادًا على ما تنوي القيام به أو تحقيقه، يمكنك استخدام أي من هذه الإعدادات:

- [DoNotScale](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesizescaletype/#DoNotScale)

  إذا كنت لا تريد تحجيم الكائنات على الشرائح، استخدم هذا الإعداد.

- [EnsureFit](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesizescaletype/#EnsureFit)

  إذا كنت تريد التحجيم إلى حجم شريحة أصغر وتحتاج إلى أن يقوم Aspose.Slides بتقليل حجم كائنات الشرائح لضمان ملاءتها جميعًا (وبالتالي تجنب فقدان المحتوى)، استخدم هذا الإعداد.

- [Maximize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesizescaletype/#Maximize)

  إذا كنت تريد التحجيم إلى حجم شريحة أكبر وتحتاج إلى أن يقوم Aspose.Slides بتكبير كائنات الشرائح لتصبح متناسبة مع الحجم الجديد، استخدم هذا الإعداد.

يعرض هذا المثال البرمجي كيفية استخدام إعداد [Maximize](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesizescaletype/#Maximize) عند تغيير حجم شريحة عرض تقديمي:

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

**هل يمكنني تعيين حجم شريحة مخصص باستخدام وحدات غير البوصة (مثل النقاط أو المليمترات)؟**

نعم. تستخدم Aspose.Slides النقاط داخليًا، حيث يساوي 1 نقطة 1/72 من البوصة. يمكنك تحويل أي وحدة (مثل المليمترات أو السنتيمترات) إلى نقاط واستخدام القيم المحولة لتعريف عرض وارتفاع الشريحة.

**هل سيؤثر حجم شريحة مخصص كبير جدًا على الأداء واستهلاك الذاكرة أثناء التصيير؟**

نعم. الأبعاد الأكبر للشرائح (بالنقاط) مقترنة بمقياس تصيير أعلى تؤدي إلى زيادة استهلاك الذاكرة وزيادة وقت المعالجة. استهدف حجم شريحة عملي وقم بضبط مقياس التصيير فقط حسب الحاجة لتحقيق جودة الإخراج المطلوبة.

**هل يمكنني تعريف حجم شريحة غير قياسي ثم دمج شرائح من عروض تقديمية ذات أحجام مختلفة؟**

لا يمكنك [merge presentations](/slides/ar/python-java/merge-presentation/) بينما تكون الأحجام مختلفة — يجب أولاً تعديل حجم أحد العروض ليتطابق مع الآخر. عند تغيير حجم الشريحة، يمكنك اختيار كيفية معالجة المحتوى الموجود عبر خيار [SlideSizeScaleType](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slidesizescaletype/). بعد توحيد الأحجام، يمكنك دمج الشرائح مع الحفاظ على التنسيق.

**هل يمكنني إنشاء صور مصغرة لأشكال فردية أو مناطق معينة من الشريحة، وهل ستحترم الحجم الجديد للشريحة؟**

نعم. يمكن لـ Aspose.Slides إنشاء صور مصغرة لكل [entire slides](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slide/#getImage) وكذلك لـ [selected shapes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/shape/#getImage). تعكس الصور الناتجة حجم الشريحة الحالي ونسبة العرض إلى الارتفاع، مما يضمن تأطيرًا وتناسقًا ثابتًا.