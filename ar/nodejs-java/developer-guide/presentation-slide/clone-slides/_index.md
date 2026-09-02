---
title: استنساخ شرائح العرض التقديمي في JavaScript
linktitle: استنساخ الشرائح
type: docs
weight: 35
url: /ar/nodejs-java/clone-slides/
keywords:
- استنساخ شريحة
- نسخ شريحة
- حفظ شريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "قم بسرعة بتكرار شرائح PowerPoint باستخدام Aspose.Slides for Node.js. اتبع أمثلة الشيفرة الخاصة بنا لأتمتة إنشاء PPT في ثوانٍ وإزالة العمل اليدوي."
---
## **المقدمة**

الاستنساخ هو عملية إنشاء نسخة مطابقة أو نسخة مكررة من شيء ما. يجعل Aspose.Slides for Node.js via Java من الممكن أيضًا إنشاء نسخة أو استنساخ من أي شريحة ثم إدراج تلك الشريحة المستنسخة إلى العرض التقديمي الحالي أو أي عرض تقديمي مفتوح آخر. عملية استنساخ الشرائح تنشئ شريحة جديدة يمكن للمطورين تعديلها دون تغيير الشريحة الأصلية. هناك عدة طرق ممكنة لاستنساخ شريحة:

- استنساخ في النهاية داخل عرض تقديمي.
- استنساخ في موضع آخر داخل العرض التقديمي.
- استنساخ في النهاية في عرض تقديمي آخر.
- استنساخ في موضع آخر في عرض تقديمي آخر.
- استنساخ في موضع محدد في عرض تقديمي آخر.

في Aspose.Slides for Node.js via Java، (مجموعة من [شريحة](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Slide) objects) التي يُظهرها كائن [عرض تقديمي](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation) يوفر طريقتي [addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) و[insertClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) لأداء الأنواع المذكورة أعلاه من استنساخ الشرائح

## **استنساخ في النهاية داخل عرض تقديمي**
إذا كنت تريد استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي في نهاية الشرائح الموجودة، استخدم طريقة [addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) وفقًا للخطوات المذكورة أدناه:

1. إنشاء مثال من فئة [عرض تقديمي](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation).
1. إنشاء كائن [SlideCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation#getSlides--) بالإشارة إلى مجموعة الشرائح التي يُظهرها كائن [عرض تقديمي](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation).
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) التي يُظهرها كائن [SlideCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation#getSlides--) وتمرير الشريحة التي ستُستنسخ كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. كتابة ملف العرض التقديمي المعدل.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (تقع في الموضع الأول – الفهرس صفر – من العرض التقديمي) إلى نهاية العرض التقديمي.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // حفظ العرض التقديمي المعدل إلى القرص
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **استنساخ في موضع آخر داخل عرض تقديمي**
إذا كنت تريد استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي لكن في موضع مختلف، استخدم طريقة [insertClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. إنشاء مثال من فئة [عرض تقديمي](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation).
1. إنشاء الكائن بالإشارة إلى مجموعة [الشرائح](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation#getSlides--) التي يُظهرها كائن [عرض تقديمي](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation).
1. استدعاء طريقة [insertClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) التي يُظهرها كائن [SlideCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation#getSlides--) وتمرير الشريحة التي ستُستنسخ مع الفهرس للموقع الجديد كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (تقع في الفهرس 1 – الموضع 2 – من العرض التقديمي) إلى الفهرس 2 – الموضع 3 – من العرض التقديمي.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    var slds = pres.getSlides();
    // استنساخ الشريحة المطلوبة إلى الفهرس المحدد في نفس العرض التقديمي
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // حفظ العرض التقديمي المعدل إلى القرص
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **استنساخ في النهاية في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واحد واستخدامها في ملف عرض تقديمي آخر، في نهاية الشرائح الموجودة:

1. إنشاء مثال من فئة [عرض تقديمي](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation) يحتوي على العرض التقديمي الذي ستُستنسخ منه الشريحة.
1. إنشاء مثال من فئة [عرض تقديمي](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation) يحتوي على العرض التقديمي الهدف الذي ستُضاف إليه الشريحة.
1. إنشاء كائن [SlideCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection) بالإشارة إلى مجموعة [الشرائح](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation#getSlides--) التي يُظهرها كائن العرض التقديمي للعرض الهدف.
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) التي يُظهرها كائن [SlideCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation#getSlides--) وتمرير الشريحة من العرض المصدر كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. كتابة ملف العرض التقديمي الهدف المعدل.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (من الفهرس الأول للعرض المصدر) إلى نهاية العرض الهدف.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // إنشاء كائن من فئة Presentation لعروض PPTX الوجهة (حيث سيتم استنساخ الشريحة)
    var destPres = new aspose.slides.Presentation();
    try {
        // استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الوجهة
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // حفظ العرض التقديمي الوجهة إلى القرص
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **استنساخ في موضع آخر في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واحد واستخدامها في ملف عرض تقديمي آخر، في موضع محدد:

1. إنشاء مثال من فئة [عرض تقديمي](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation) يحتوي على العرض المصدر الذي ستُستنسخ منه الشريحة.
1. إنشاء مثال من فئة [عرض تقديمي](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation) يحتوي على العرض الذي ستُضاف إليه الشريحة.
1. إنشاء كائن [SlideCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation#getSlides--) بالإشارة إلى مجموعة الشرائح التي يُظهرها كائن العرض التقديمي للعرض الهدف.
1. استدعاء طريقة [insertClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) التي يُظهرها كائن [SlideCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation#getSlides--) وتمرير الشريحة من العرض المصدر مع الموضع المطلوب كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. كتابة ملف العرض التقديمي الهدف المعدل.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (من الفهرس صفر للعرض المصدر) إلى الفهرس 1 (الموضع 2) من العرض الهدف.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // إنشاء كائن من فئة Presentation لملف PPTX الوجهة (حيث سيتم استنساخ الشريحة)
    var destPres = new aspose.slides.Presentation();
    try {
        // استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الوجهة
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // حفظ العرض التقديمي الوجهة إلى القرص
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **استنساخ في موضع محدد في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة مع شريحة رئيسية من عرض تقديمي واستخدامها في عرض تقديمي آخر، تحتاج أولاً إلى استنساخ الشريحة الرئيسية المطلوبة من العرض المصدر إلى العرض الهدف. ثم تحتاج إلى استخدام تلك الشريحة الرئيسية لاستنساخ الشريحة مع الشريحة الرئيسية. طريقة [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) تتوقع شريحة رئيسية من العرض الهدف بدلاً من العرض المصدر. لاستنساخ الشريحة مع رئيسية، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [عرض تقديمي](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation) يحتوي على العرض المصدر الذي ستُستنسخ منه الشريحة.
1. إنشاء مثال من فئة [عرض تقديمي](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation) يحتوي على العرض الهدف الذي ستُستنسخ إليه الشريحة.
1. الوصول إلى الشريحة التي ستُستنسخ مع الشريحة الرئيسية.
1. إنشاء كائن [MasterSlideCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/MasterSlideCollection) بالإشارة إلى مجموعة الرئيسيات التي يُظهرها كائن [عرض تقديمي](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation) للعرض الهدف.
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) التي يُظهرها كائن [MasterSlideCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/MasterSlideCollection) وتمرير الرئيسيه من ملف PPTX المصدر لتُستنسخ كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. إنشاء كائن [SlideCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation#getSlides--) بتعيين المرجع إلى مجموعة الشرائح التي يُظهرها كائن [عرض تقديمي](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation) للعرض الهدف.
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) التي يُظهرها كائن [SlideCollection](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/Presentation#getSlides--) وتمرير الشريحة من العرض المصدر لاستنساخها والشريحة الرئيسية كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. كتابة ملف العرض التقديمي الهدف المعدل.

في المثال المعطى أدناه، قمنا باستنساخ شريحة مع رئيسية (تقع في الفهرس صفر للعرض المصدر) إلى نهاية العرض الهدف باستخدام رئيسية من الشريحة المصدر.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // إنشاء كائن من فئة Presentation للعرض التقديمي الوجهة (حيث سيتم استنساخ الشريحة)
    var destPres = new aspose.slides.Presentation();
    try {
        // إنشاء ISlide من مجموعة الشرائح في العرض التقديمي المصدر مع
        // الشريحة الرئيسية
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الرئيسيات في
        // العرض التقديمي الهدف
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // استنساخ الشريحة المطلوبة من العرض التقديمي المصدر مع الرئيسيه المطلوبة إلى نهاية
        // مجموعة الشرائح في العرض التقديمي الهدف
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // حفظ العرض التقديمي الهدف إلى القرص
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **استنساخ في النهاية في قسم محدد**
إذا كنت تريد استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي لكن في قسم مختلف، استخدم طريقة [**addClone**](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) التي يُظهرها كلاس [**SlideCollection**](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/SlideCollection). يجعل Aspose.Slides for Node.js via Java من الممكن استنساخ شريحة من القسم الأول ثم إدراج تلك الشريحة المستنسخة إلى القسم الثاني من نفس العرض التقديمي.

القطعة البرمجية التالية توضح لك كيفية استنساخ شريحة وإدراج الشريحة المستنسخة في قِسم محدد.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // حفظ العرض التقديمي الهدف إلى القرص
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **التأكد من مطابقة حجم الشريحة**

عند استنساخ الشرائح إلى عرض تقديمي آخر، تأكد من أن حجم الشريحة في العرض الهدف يطابق حجم الشريحة في المصدر. إذا اختلفت الأحجام، لا يقوم Aspose.Slides تلقائيًا بإعادة تحجيم الأشكال المستنسخة—تُحافظ على الإحداثيات والأبعاد الأصلية، مما قد يتسبب في ظهور المحتوى بشكل غير محاذٍ أو يتجاوز حدود الشريحة.

يمكنك ضبط حجم شريحة العرض الهدف لتطابق المصدر قبل استنساخ الرئيسيه والشريحة:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

قم بذلك قبل استنساخ الرئيسيه والشريحة.

## **الأسئلة الشائعة**

**هل يتم استنساخ ملاحظات المتحدث وتعليقات المراجعين؟**

نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في النسخة المستنسخة. إذا كنت لا تريدها، [قم بإزالتها](/slides/ar/nodejs-java/presentation-notes/) بعد الإدراج.

**كيف يتم التعامل مع المخططات ومصادر بياناتها؟**

يتم نسخ كائن المخطط، التنسيق، والبيانات المدمجة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثل دفتر عمل OLE مدمج)، يتم الحفاظ على هذا الارتباط كـ [كائن OLE](/slides/ar/nodejs-java/manage-ole/). بعد النقل بين الملفات، تحقق من توفر البيانات وسلوك التحديث.

**هل يمكنني التحكم في موضع الإدراج والأقسام للنسخة المستنسخة؟**

نعم. يمكنك إدراج النسخة المستنسخة عند فهرس شريحة محدد ووضعها في [قسم](/slides/ar/nodejs-java/slide-section/) مختار. إذا لم يكن القسم الهدف موجودًا، أنشئه أولاً ثم انقل الشريحة إليه.