---
title: تغيير حجم شريحة العرض التقديمي في JavaScript
linktitle: حجم الشريحة
type: docs
weight: 70
url: /ar/nodejs-java/slide-size/
keywords:
- حجم الشريحة
- نسبة العرض إلى الارتفاع
- قياسي
- عريض الشاشة
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
- Node.js
- JavaScript
- Aspose.Slides
description: "تعلم كيفية تغيير حجم الشرائح بسرعة في ملفات PPT و PPTX و ODP باستخدام Node.js و Aspose.Slides، وحسّن العروض التقديمية لأي شاشة دون فقدان الجودة."
---
## **المقدمة**

Aspose.Slides توفر أدوات شاملة لضبط حجم الشريحة ونسبة العرض إلى الارتفاع في عروض PowerPoint، وهو أمر حاسم للطباعة والعرض على الشاشة.

الأحجام والنسب الشائعة للشرائح:

- **قياسي (نسبة عرض إلى ارتفاع 4:3)**: مثالي للشاشات والأجهزة القديمة.
- **عريض الشاشة (نسبة عرض إلى ارتفاع 16:9)**: يُنصح به لأجهزة العرض الحديثة والشاشات.

تأكد من الاتساق طوال العرض لأن حجم الشريحة ونسبة العرض إلى الارتفاع الموحدين يطبقان على جميع الشرائح. للحصول على نتائج مثالية، اضبط أبعاد الشريحة في بداية عملية إنشاء العرض لتجنب التعقيدات.

{{% alert color="info" title="Note" %}}
افتراضيًا، العروض التي تُنشئ باستخدام Aspose.Slides تستخدم النسبة القياسية 4:3.
{{% /alert %}}

صفحات الملاحظات والملفات المرفقة لها أبعاد منفصلة عن الشرائح العادية. راجع [Notes Page Size](/slides/ar/nodejs-java/notes-size/) لتغيير حجمها وتوجهها.

## **تغيير حجم الشريحة في العروض التقديمية**

هذا المثال يوضح لك كيفية تغيير حجم الشريحة في عرض تقديمي بلغة JavaScript باستخدام Aspose.Slides:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **تحديد أحجام شرائح مخصصة في العروض التقديمية**

إذا وجدت أن الأحجام الشائعة للشرائح (4:3 و 16:9) غير مناسبة لعملك، قد تقرر استخدام حجم شريحة محدد أو فريد. على سبيل المثال، إذا كنت تخطط لطباعة شرائح بحجم كامل من عرضك على تخطيط صفحة مخصص أو إذا كنت تنوي عرض العرض على أنواع شاشات معينة، فمن المحتمل أن تستفيد من إعداد حجم مخصص للعرض.

هذا المثال يوضح لك كيفية استخدام Aspose.Slides for Node.js عبر Java لتحديد حجم شريحة مخصص لعرض تقديمي بلغة JavaScript:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// حجم ورق A4
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **معالجة المشكلات عند تغيير حجم الشرائح في العروض التقديمية**

بعد تغيير حجم الشريحة لعرض تقديمي، قد يصبح محتوى الشرائح (مثل الصور أو الكائنات) مشوّهًا. افتراضيًا، يتم إعادة تحجيم الكائنات تلقائيًا لتتناسب مع الحجم الجديد. ومع ذلك، عند تغيير حجم شرائح العرض، يمكنك تحديد إعداد يحدد كيف تتعامل Aspose.Slides مع المحتويات على الشرائح.

اعتمادًا على ما تنوي القيام به أو تحقيقه، يمكنك استخدام أي من هذه الإعدادات:

- `DoNotScale`

  إذا لم ترغب في إعادة تحجيم الكائنات على الشرائح، استخدم هذا الإعداد.

- `EnsureFit`

  إذا أردت التحجيم إلى حجم شريحة أصغر وتحتاج إلى أن تقوم Aspose.Slides بتصغير كائنات الشرائح لضمان تناسقها داخل الشرائح (وبذلك تتجنب فقدان المحتوى)، استخدم هذا الإعداد.

- `Maximize`

  إذا أردت التحجيم إلى حجم شريحة أكبر وتحتاج إلى أن تقوم Aspose.Slides بتكبير كائنات الشرائح لتصبح متناسبة مع الحجم الجديد، استخدم هذا الإعداد.

هذا المثال يوضح لك كيفية استخدام إعداد `Maximize` عند تغيير حجم شريحة عرض تقديمي:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**هل يمكنني تعيين حجم شريحة مخصص باستخدام وحدات غير البوصة (مثل النقاط أو المليمترات)؟**

نعم. تستخدم Aspose.Slides النقاط داخليًا، حيث تساوي النقطة الواحدة 1/72 من البوصة. يمكنك تحويل أي وحدة (مثل المليمترات أو السنتيمترات) إلى نقاط واستخدام القيم المحوّلة لتعريف عرض وارتفاع الشريحة.

**هل سيؤثر حجم شريحة مخصص كبير جدًا على الأداء واستهلاك الذاكرة أثناء عملية العرض؟**

نعم. الأبعاد الأكبر للشرائح (بالنقاط) مع مقياس عرض أعلى يؤدي إلى استهلاك ذاكرة أكبر وأوقات معالجة أطول. احرص على اختيار حجم شريحة عملي واضبط مقياس العرض فقط حسب الحاجة لتحقيق جودة الإخراج المطلوبة.

**هل يمكنني تعريف حجم شريحة غير قياسي ثم دمج الشرائح من عروض لها أحجام مختلفة؟**

لا يمكنك [merge presentations](/slides/ar/nodejs-java/merge-presentation/) بينما لها أحجام شرائح مختلفة — يجب أولاً تعديل حجم أحد العروض ليتطابق مع الآخر. عند تغيير حجم الشريحة، يمكنك اختيار طريقة التعامل مع المحتوى الموجود عبر خيار [SlideSizeScaleType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidesizescaletype/). بعد توافق الأحجام، يمكنك دمج الشرائح مع الحفاظ على التنسيق.

**هل يمكنني إنشاء صور مصغرة لأشكال فردية أو مناطق محددة من الشريحة، وهل ستحترم حجم الشريحة الجديد؟**

نعم. يمكن لـ Aspose.Slides إنشاء صور مصغرة لـ [entire slides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#getImage) وكذلك لـ [selected shapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/shape/#getImage). تعكس الصور الناتجة حجم الشريحة الحالي ونسبة العرض إلى الارتفاع، مما يضمن إطارات وجيومتريات متسقة.