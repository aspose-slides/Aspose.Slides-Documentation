---
title: استنساخ الشرائح
type: docs
weight: 35
url: /ar/nodejs-java/clone-slides/
---

## **استنساخ الشرائح في العرض التقديمي**
الاستنساخ هو العملية التي يتم من خلالها إنشاء نسخة دقيقة أو مكررة من شيء ما. Aspose.Slides for Node.js via Java يجعل من الممكن أيضًا إنشاء نسخة أو استنساخ لأي شريحة ثم إدراج تلك الشريحة المستنسخة إلى العرض التقديمي الحالي أو أي عرض تقديمي مفتوح آخر. عملية استنساخ الشرائح تنشئ شريحة جديدة يمكن للمطورين تعديلها دون تغيير الشريحة الأصلية. هناك عدة طرق ممكنة لاستنساخ شريحة:

- استنساخ في النهاية داخل عرض تقديمي.
- استنساخ في موضع آخر داخل عرض تقديمي.
- استنساخ في النهاية في عرض تقديمي آخر.
- استنساخ في موضع آخر في عرض تقديمي آخر.
- استنساخ في موضع محدد في عرض تقديمي آخر.

في Aspose.Slides for Node.js via Java، (مجموعة من كائنات [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide)) التي تُعرض بواسطة كائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) توفر طريقتي [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) و[insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) لتنفيذ الأنواع السابقة من استنساخ الشرائح

## **استنساخ في النهاية داخل عرض تقديمي**
إذا كنت ترغب في استنساخ شريحة ثم استخدامها داخل ملف العرض التقديمي نفسه في نهاية الشرائح الموجودة، استخدم طريقة [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) وفقًا للخطوات المذكورة أدناه:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. إنشاء كائن من فئة [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) عبر الإشارة إلى مجموعة Slides التي تُعرض بواسطة كائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) التي تُعرض بواسطة كائن [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) وتمرير الشريحة التي سيتم استنساخها كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. حفظ ملف العرض التقديمي المعدل.

في المثال الموضح أدناه، قمنا باستنساخ شريحة (تقع في الموضع الأول – الفهرس صفر – من العرض التقديمي) إلى نهاية العرض التقديمي.
```javascript
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي
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
إذا كنت ترغب في استنساخ شريحة ثم استخدامها داخل ملف العرض التقديمي نفسه ولكن في موضع مختلف، استخدم طريقة [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-):

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. إنشاء كائن عبر الإشارة إلى مجموعة [**Slides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) التي تُعرض بواسطة كائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
1. استدعاء طريقة [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) التي تُعرض بواسطة كائن [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) وتمرير الشريحة التي سيتم استنساخها مع الفهرس للموقع الجديد كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. حفظ العرض التقديمي المعدل كملف PPTX.

في المثال الموضح أدناه، قمنا باستنساخ شريحة (تقع في الفهرس صفر – الموضع 1 – من العرض التقديمي) إلى الفهرس 1 – الموضع 2 – من العرض التقديمي.
```javascript
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي
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
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واستخدامها في ملف عرض تقديمي آخر، في نهاية الشرائح الموجودة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) التي تحتوي على العرض التقديمي الذي ستُستنسخ منه الشريحة.
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) التي تحتوي على العرض التقديمي الهدف الذي ستُضاف إليه الشريحة.
1. إنشاء كائن من فئة [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection) عبر الإشارة إلى مجموعة [**Slides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) التي تُعرض بواسطة كائن Presentation للعرض التقديمي الهدف.
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) التي تُعرض بواسطة كائن [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) وتمرير الشريحة من العرض التقديمي المصدر كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. حفظ ملف العرض التقديمي الهدف المعدل.

في المثال الموضح أدناه، قمنا باستنساخ شريحة (من الفهرس الأول للعرض التقديمي المصدر) إلى نهاية العرض التقديمي الهدف.
```javascript
// إنشاء فئة Presentation لتحميل ملف العرض التقديمي المصدر
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // إنشاء فئة Presentation لملف PPTX الوجهة (حيث سيتم استنساخ الشريحة)
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
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واستخدامها في ملف عرض تقديمي آخر، في موضع محدد:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) التي تحتوي على العرض التقديمي المصدر الذي ستُستنسخ منه الشريحة.
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) التي تحتوي على العرض التقديمي الذي ستُضاف إليه الشريحة.
1. إنشاء كائن من فئة [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) عبر الإشارة إلى مجموعة Slides التي تُعرض بواسطة كائن Presentation للعرض التقديمي الهدف.
1. استدعاء طريقة [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) التي تُعرض بواسطة كائن [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) وتمرير الشريحة من العرض التقديمي المصدر مع الموضع المطلوب كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-).
1. حفظ ملف العرض التقديمي الهدف المعدل.

في المثال الموضح أدناه، قمنا باستنساخ شريحة (من الفهرس صفر للعرض التقديمي المصدر) إلى الفهرس 1 (الموضع 2) للعرض التقديمي الهدف.
```javascript
// إنشاء فئة Presentation لتحميل ملف العرض التقديمي المصدر
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // إنشاء فئة Presentation لملف PPTX الوجهة (حيث سيتم استنساخ الشريحة)
    var destPres = new aspose.slides.Presentation();
    try {
        // استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الوجهة
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
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
إذا كنت بحاجة إلى استنساخ شريحة مع شريحة رئيسية من عرض تقديمي واستخدامها في عرض تقديمي آخر، يجب أولاً استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى العرض التقديمي الهدف. ثم تحتاج إلى استخدام تلك الشريحة الرئيسية لاستنساخ الشريحة مع الشريحة الرئيسية. الطريقة [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) تتوقع شريحة رئيسية من العرض التقديمي الهدف وليس من العرض التقديمي المصدر. لاستنساخ الشريحة مع الرئيسية، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) التي تحتوي على العرض التقديمي المصدر الذي ستُستنسخ منه الشريحة.
1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) التي تحتوي على العرض التقديمي الهدف الذي ستُستنسخ إليه الشريحة.
1. الوصول إلى الشريحة التي سيتم استنساخها مع الشريحة الرئيسية.
1. إنشاء كائن من فئة [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection) عبر الإشارة إلى مجموعة Masters التي تُعرض بواسطة كائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) للعرض التقديمي الهدف.
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) التي تُعرض بواسطة كائن [MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection) وتمرير الشريحة الرئيسية من ملف PPTX المصدر لتستنسخ كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. إنشاء كائن من فئة [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) عن طريق تعيين الإشارة إلى مجموعة Slides التي تُعرض بواسطة كائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) للعرض التقديمي الهدف.
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) التي تُعرض بواسطة كائن [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--) وتمرير الشريحة من العرض التقديمي المصدر لتستنسخ مع الشريحة الرئيسية كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-).
1. حفظ ملف العرض التقديمي الهدف المعدل.

في المثال الموضح أدناه، قمنا باستنساخ شريحة مع رئيسية (تقع في الفهرس صفر للعرض التقديمي المصدر) إلى نهاية العرض التقديمي الهدف باستخدام رئيسية من الشريحة المصدر.
```javascript
// إنشاء فئة Presentation لتحميل ملف العرض التقديمي المصدر
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // إنشاء فئة Presentation للعرض التقديمي الوجهة (حيث سيتم استنساخ الشريحة)
    var destPres = new aspose.slides.Presentation();
    try {
        // إنشاء كائن ISlide من مجموعة الشرائح في العرض التقديمي المصدر مع
        // الشريحة الرئيسية
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الرؤوس في
        // العرض التقديمي الوجهة
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الرؤوس في
        // العرض التقديمي الوجهة
        var iSlide = masters.addClone(SourceMaster);
        // استنساخ الشريحة المطلوبة من العرض التقديمي المصدر مع الشريحة الرئيسية المطلوبة إلى نهاية
        // مجموعة الشرائح في العرض التقديمي الوجهة
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // حفظ العرض التقديمي الوجهة إلى القرص
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **استنساخ في النهاية في قسم محدد**
إذا كنت ترغب في استنساخ شريحة ثم استخدامها داخل ملف العرض التقديمي نفسه ولكن في قسم مختلف، فاستعن بطريقة [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) التي تُعرض بواسطة فئة [**SlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection). Aspose.Slides for Node.js via Java يجعل من الممكن استنساخ شريحة من القسم الأول ثم إدراج تلك الشريحة المستنسخة إلى القسم الثاني من نفس العرض التقديمي.

المقتطف البرمجي التالي يوضح لك كيفية استنساخ شريحة وإدراج الشريحة المستنسخة في قسم محدد.
```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // حفظ العرض التقديمي الوجهة إلى القرص
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **الأسئلة المتكررة**

**هل يتم استنساخ ملاحظات المتحدث وتعليقات المراجع؟**
نعم. صفحة الملاحظات وتعليقات المراجعة تُدرج في النسخة المستنسخة. إذا لم ترغب فيها، [قم بإزالتها](/slides/ar/nodejs-java/presentation-notes/) بعد الإدراج.

**كيف يتم التعامل مع المخططات ومصادر بياناتها؟**
يتم نسخ كائن المخطط وتنسيقه والبيانات المدمجة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثل مصنف OLE مدمج)، يتم الحفاظ على هذا الارتباط كـ [OLE object](/slides/ar/nodejs-java/manage-ole/). بعد النقل بين الملفات، تحقق من توفر البيانات وسلوك التحديث.

**هل يمكنني التحكم في موضع الإدراج والأقسام للنسخة المستنسخة؟**
نعم. يمكنك إدراج النسخة المستنسخة عند فهرس شريحة محدد ووضعها في [قسم](/slides/ar/nodejs-java/slide-section/) مختار. إذا لم يكن القسم الهدف موجودًا، أنشئه أولاً ثم انقل الشريحة إليه.