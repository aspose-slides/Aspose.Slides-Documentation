---
title: استنساخ شرائح العرض التقديمي في Java
linktitle: استنساخ الشرائح
type: docs
weight: 35
url: /ar/java/clone-slides/
keywords:
- استنساخ شريحة
- نسخ شريحة
- حفظ شريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "استنسخ شرائح PowerPoint بسرعة باستخدام Aspose.Slides لجافا. اتبع أمثلة الشيفرة الواضحة لأتمتة إنشاء PPT في ثوانٍ وإزالة العمل اليدوي."
---

## **استنساخ الشرائح في عرض تقديمي**
الاستنساخ هو عملية إنشاء نسخة مطابقة أو نسخة مكررة من شيء ما. يتيح Aspose.Slides for Java أيضًا إمكانية إنشاء نسخة أو استنساخ لأي شريحة ثم إدراج تلك الشريحة المستنسخة إلى العرض التقديمي الحالي أو أي عرض تقديمي آخر مفتوح. عملية استنساخ الشرائح تخلق شريحة جديدة يمكن للمطورين تعديلها دون تغيير الشريحة الأصلية. هناك عدة طرق محتملة لاستنساخ شريحة:

- استنساخ في النهاية داخل عرض تقديمي.
- استنساخ في موقع آخر داخل العرض التقديمي.
- استنساخ في النهاية في عرض تقديمي آخر.
- استنساخ في موقع آخر في عرض تقديمي آخر.
- استنساخ في موقع محدد في عرض تقديمي آخر.

في Aspose.Slides for Java ، (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) ) التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) توفر طُرُق [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) و [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) لتنفيذ أنواع استنساخ الشرائح المذكورة أعلاه.

## **استنساخ شريحة في نهاية عرض تقديمي**
إذا كنت ترغب في استنساخ شريحة ثم استخدامها داخل ملف العرض التقديمي نفسه في نهاية الشرائح الموجودة ، استخدم طريقة [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) وفقًا للخطوات المذكورة أدناه:

1. أنشئ مثالًا من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. قم بإنشاء كائن من الفئة [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) عن طريق الإشارة إلى مجموعة Slides التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. استدعِ طريقة [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي يُظهرها كائن [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) ومرّر الشريحة التي تريد استنساخها كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. اكتب ملف العرض التقديمي المعدل.

في المثال المعطى أدناه ، لقد استنسخنا شريحة (تقع في الموضع الأول – الفهرس صفر – من العرض التقديمي) إلى نهاية العرض التقديمي.
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // كتابة العرض التقديمي المعدل إلى القرص
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **استنساخ شريحة إلى موقع آخر داخل عرض تقديمي**
إذا كنت ترغب في استنساخ شريحة ثم استخدامها داخل ملف العرض التقديمي نفسه ولكن في موضع مختلف ، استخدم طريقة [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. أنشئ مثالًا من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. قم بإنشاء كائن من الفئة عن طريق الإشارة إلى مجموعة [**Slides**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
1. استدعِ طريقة [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) التي يُظهرها كائن [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) ومرّر الشريحة التي تريد استنساخها مع الفهرس للموقع الجديد كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. اكتب العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه ، لقد استنسخنا شريحة (تقع في الفهرس صفر – الموضع 1 – من العرض التقديمي) إلى الفهرس 1 – الموضع 2 – من العرض التقديمي.
```java
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    ISlideCollection slds = pres.getSlides();

    // استنساخ الشريحة المطلوبة إلى الفهرس المحدد في نفس العرض التقديمي
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // كتابة العرض التقديمي المعدل إلى القرص
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **استنساخ شريحة في نهاية عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واستخدامها في ملف عرض تقديمي آخر ، في نهاية الشرائح الموجودة:

1. أنشئ مثالًا من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي تحتوي على العرض التقديمي الذي ستُستنسخ منه الشريحة.
1. أنشئ مثالًا من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي تحتوي على عرض التقديمي الوجهة الذي ستُضاف إليه الشريحة.
1. قم بإنشاء كائن من الفئة [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) عن طريق الإشارة إلى مجموعة [**Slides**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) التي يُظهرها كائن Presentation للعرض التقديمي الوجهة.
1. استدعِ طريقة [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي يُظهرها كائن [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) ومرّر الشريحة من عرض التقديمي المصدر كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. اكتب ملف عرض التقديمي الوجهة المعدل.

في المثال المعطى أدناه ، لقد استنسخنا شريحة (من الفهرس الأول للعرض التقديمي المصدر) إلى نهاية العرض التقديمي الوجهة.
```java
// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // إنشاء كائن من فئة Presentation لملف PPTX الوجهة (حيث سيتم استنساخ الشريحة)
    Presentation destPres = new Presentation();
    try {
        // استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الوجهة
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // كتابة العرض التقديمي الوجهة إلى القرص
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **استنساخ شريحة إلى موقع آخر في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واستخدامها في ملف عرض تقديمي آخر ، في موضع محدد:

1. أنشئ مثالًا من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي تحتوي على العرض التقديمي المصدر الذي ستُستنسخ منه الشريحة.
1. أنشئ مثالًا من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي ستُضاف إليها الشريحة.
1. قم بإنشاء كائن من الفئة [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) عن طريق الإشارة إلى مجموعة Slides التي يُظهرها كائن Presentation للعرض التقديمي الوجهة.
1. استدعِ طريقة [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) التي يُظهرها كائن [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) ومرّر الشريحة من العرض التقديمي المصدر مع الموضع المطلوب كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. اكتب ملف عرض التقديمي الوجهة المعدل.

في المثال المعطى أدناه ، لقد استنسخنا شريحة (من الفهرس صفر للعرض التقديمي المصدر) إلى الفهرس 1 (الموضع 2) للعرض التقديمي الوجهة.
```java
// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // إنشاء كائن من فئة Presentation لملف PPTX الوجهة (حيث ستتم استنساخ الشريحة)
    Presentation destPres = new Presentation();
    try {
        // استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الوجهة
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // كتابة العرض التقديمي الوجهة إلى القرص
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **استنساخ شريحة في موضع محدد في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة لها شريحة رئيسية (Master Slide) من عرض تقديمي واستخدامها في عرض تقديمي آخر ، يجب أولاً استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى العرض التقديمي الوجهة. ثم تحتاج إلى استخدام تلك الشريحة الرئيسية لاستنساخ الشريحة مع الشريحة الرئيسية. طريقة [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) تتوقع شريحة رئيسية من العرض التقديمي الوجهة بدلاً من المصدر. لاستنساخ الشريحة مع الشريحة الرئيسية ، يرجى اتباع الخطوات التالية:

1. أنشئ مثالًا من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي تحتوي على العرض التقديمي المصدر الذي ستُستنسخ منه الشريحة.
1. أنشئ مثالًا من الفئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي تحتوي على العرض التقديمي الوجهة التي ستُستنسخ إليها الشريحة.
1. الوصول إلى الشريحة المراد استنسخها مع الشريحة الرئيسية.
1. قم بإنشاء كائن من الفئة [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) عن طريق الإشارة إلى مجموعة Masters التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) للعرض التقديمي الوجهة.
1. استدعِ طريقة [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي يُظهرها كائن [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) ومرّر الشريحة الرئيسية من ملف PPTX المصدر لاستنساخها كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. قم بإنشاء كائن من الفئة [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) عن طريق ضبط الإشارة إلى مجموعة Slides التي يُظهرها كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) للعرض التقديمي الوجهة.
1. استدعِ طريقة [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي يُظهرها كائن [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) ومرّر الشريحة من العرض التقديمي المصدر التي ستُستنسخ والشريحة الرئيسية كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. اكتب ملف عرض التقديمي الوجهة المعدل.

في المثال المعطى أدناه ، لقد استنسخنا شريحة مع شريحة رئيسية (تقع في الفهرس صفر للعرض التقديمي المصدر) إلى نهاية العرض التقديمي الوجهة باستخدام شريحة رئيسية من الشريحة المصدر.
```java
// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // إنشاء كائن من فئة Presentation للعرض التقديمي الوجهة (حيث سيتم استنساخ الشريحة)
    Presentation destPres = new Presentation();
    try {
        // إنشاء ISlide من مجموعة الشرائح في العرض التقديمي المصدر مع
        // الشريحة الرئيسية
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الشرائح الرئيسية في الـ
        // عرض تقديمي الوجهة
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الشرائح الرئيسية في الـ
        // عرض تقديمي الوجهة
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // استنساخ الشريحة المطلوبة من العرض التقديمي المصدر مع الشريحة الرئيسية المطلوبة إلى نهاية الـ
        // مجموعة الشرائح في عرض تقديمي الوجهة
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // حفظ عرض تقديمي الوجهة إلى القرص
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **استنساخ شريحة في نهاية قسم محدد**
إذا كنت تريد استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي ولكن في قسم مختلف ، فاستخدم طريقة [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) التي يُظهرها واجهة [**ISlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection). يتيح Aspose.Slides for Java إمكانية استنساخ شريحة من القسم الأول ثم إدراج تلك الشريحة المستنسخة إلى القسم الثاني من نفس العرض التقديمي.

القطعة البرمجية التالية توضح لك كيفية استنساخ شريحة وإدراج الشريحة المستنسخة في قسم محدد.
```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// حفظ العرض التقديمي الوجهة إلى القرص
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **الأسئلة المتكررة**
**هل يتم استنساخ ملاحظات المتحدث وتعليقات المراجعين؟**

نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في النسخة المستنسخة. إذا لم ترغب فيها ، يمكنك [إزالتها](/slides/ar/java/presentation-notes/) بعد الإدراج.

**كيف يتم التعامل مع المخططات ومصادر بياناتها؟**

يتم نسخ كائن المخطط والتنسيق والبيانات المضمنة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثل مصنف مدمج كـ OLE) ، فسيتم الحفاظ على هذا الارتباط كـ [OLE object](/slides/ar/java/manage-ole/). بعد النقل بين الملفات ، تحقق من توفر البيانات وسلوك التحديث.

**هل يمكنني التحكم في موضع الإدراج والأقسام للنسخة المستنسخة؟**

نعم. يمكنك إدراج النسخة المستنسخة عند فهرس شريحة محدد ووضعها في [القسم](/slides/ar/java/slide-section/) المختار. إذا لم يكن القسم المستهدف موجودًا ، قم بإنشائه أولًا ثم انقل الشريحة إليه.