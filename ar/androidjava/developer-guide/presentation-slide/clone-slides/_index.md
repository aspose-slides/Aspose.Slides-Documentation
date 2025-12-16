---
title: استنساخ شرائح العرض التقديمي على Android
linktitle: استنساخ الشرائح
type: docs
weight: 35
url: /ar/androidjava/clone-slides/
keywords:
- استنساخ شريحة
- نسخ شريحة
- حفظ شريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "استنساخ شرائح PowerPoint باستخدام Aspose.Slides لنظام Android. اتبع أمثلة الشيفرة الواضحة بلغة Java لتلقائيًّا إنشاء ملفات PPT في ثوانٍ وإزالة العمل اليدوي."
---

## **استنساخ الشرائح في عرض تقديمي**
الاستنساخ هو عملية إنشاء نسخة مطابقة أو نسخة مكررة من شيء ما. Aspose.Slides for Android via Java يجعل من الممكن أيضًا إنشاء نسخة أو استنساخ لأي شريحة ثم إدراج تلك الشريحة المستنسخة إلى العرض التقديمي الحالي أو أي عرض تقديمي آخر مفتوح. عملية استنساخ الشريحة تُنشئ شريحة جديدة يمكن للمطورين تعديلها دون تغيير الشريحة الأصلية. هناك عدة طرق ممكنة لاستنساخ شريحة:

- استنساخ في النهاية داخل عرض تقديمي.
- استنساخ في موضع آخر داخل العرض التقديمي.
- استنساخ في النهاية في عرض تقديمي آخر.
- استنساخ في موضع آخر في عرض تقديمي آخر.
- استنساخ في موضع محدد في عرض تقديمي آخر.

في Aspose.Slides for Android via Java، (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) التي يُعرّفها كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)) توفر طريقتي [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) و [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) لتنفيذ الأنواع المذكورة أعلاه من استنساخ الشرائح.

## **استنساخ شريحة في نهاية عرض تقديمي**
إذا كنت تريد استنساخ شريحة ثم استخدامها داخل ملف العرض التقديمي نفسه في نهاية الشرائح الحالية، استخدم طريقة [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) وفقًا للخطوات المذكورة أدناه:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. أنشئ كائنًا من فئة [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) بالإشارة إلى مجموعة الشرائح التي يُعرّفها كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. استدعِ طريقة [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي يُعرّفها كائن [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) ومرّر الشريحة المراد استنساخها كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. اكتب ملف العرض التقديمي المعدل.

في المثال المعطى أدناه، استنسخنا شريحة (تقع في الموضع الأول – الفهرس صفر – من العرض التقديمي) إلى نهاية العرض التقديمي.
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


## **استنساخ شريحة إلى موضع آخر داخل عرض تقديمي**
إذا كنت تريد استنساخ شريحة ثم استخدامها داخل ملف العرض التقديمي نفسه ولكن في موضع مختلف، استخدم طريقة [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. أنشئ الكائن بالإشارة إلى مجموعة **[Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)** التي يُعرّفها كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
1. استدعِ طريقة [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) التي يُعرّفها كائن [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) ومرّر الشريحة المراد استنساخها مع الفهرس للموضع الجديد كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. اكتب العرض التقديمي المعدل بصيغة PPTX.

في المثال المعطى أدناه، استنسخنا شريحة (تقع في الفهرس صفر – الموضع 1 – من العرض التقديمي) إلى الفهرس 1 – الموضع 2 – من العرض التقديمي.
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
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واستخدامها في عرض تقديمي آخر، في نهاية الشرائح الحالية:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) يحتوي على العرض التقديمي الذي ستُستنسخ منه الشريحة.
1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) يحتوي على عرض تقديمي الوجهة الذي ستُضاف إليه الشريحة.
1. أنشئ كائنًا من فئة [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) بالإشارة إلى مجموعة **[Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)** التي يُعرّفها كائن العرض التقديمي للوجهة.
1. استدعِ طريقة [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي يُعرّفها كائن [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) ومرّر الشريحة من عرض التقديمي المصدر كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. اكتب ملف عرض تقديمي الوجهة المعدل.

في المثال المعطى أدناه، استنسخنا شريحة (من الفهرس الأول في عرض التقديمي المصدر) إلى نهاية عرض التقديمي الوجهة.
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


## **استنساخ شريحة إلى موضع آخر في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واستخدامها في عرض تقديمي آخر، في موضع محدد:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) يحتوي على العرض التقديمي المصدر الذي ستُستنسخ منه الشريحة.
1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) يحتوي على عرض التقديمي الذي ستُضاف إليه الشريحة.
1. أنشئ كائنًا من فئة [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) بالإشارة إلى مجموعة الشرائح التي يُعرّفها كائن العرض التقديمي للوجهة.
1. استدعِ طريقة [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) التي يُعرّفها كائن [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) ومرّر الشريحة من العرض التقديمي المصدر مع الموضع المرغوب كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. اكتب ملف عرض التقديمي الوجهة المعدل.

في المثال المعطى أدناه، استنسخنا شريحة (من الفهرس صفر في عرض التقديمي المصدر) إلى الفهرس 1 (الموضع 2) من عرض التقديمي الوجهة.
```java
// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // إنشاء كائن من فئة Presentation لملف PPTX الوجهة (حيث سيتم استنساخ الشريحة)
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
إذا كنت بحاجة إلى استنساخ شريحة مع شريحة رئيسية من عرض تقديمي واستخدامها في عرض تقديمي آخر، تحتاج أولاً إلى استنساخ الشريحة الرئيسة المطلوبة من العرض المصدر إلى العرض الوجهة. ثم تحتاج لاستخدام تلك الشريحة الرئيسة لاستنساخ الشريحة مع الشريحة الرئيسة. طريقة [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) تتوقع شريحة رئيسة من عرض التقديمي الوجهة وليس من العرض المصدر. لاستنساخ الشريحة مع رئيسة، يرجى اتباع الخطوات أدناه:

1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) يحتوي على العرض التقديمي المصدر الذي ستُستنسخ منه الشريحة.
1. أنشئ مثيلًا من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) يحتوي على العرض التقديمي الوجهة الذي ستُستنسخ إليه الشريحة.
1. احصل على الشريحة المستنسخة مع الشريحة الرئيسة.
1. أنشئ كائنًا من فئة [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) بالإشارة إلى مجموعة Masters التي يُعرّفها كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) للعرض الوجهة.
1. استدعِ طريقة [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي يُعرّفها كائن [IMasterSlideCollection] ومرّر الشريحة الرئيسة من عرض PPTX المصدر لتُستنسخ كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. أنشئ كائنًا من فئة [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) بتعيين الإشارة إلى مجموعة الشرائح التي يُعرّفها كائن [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) للعرض الوجهة.
1. استدعِ طريقة [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي يُعرّفها كائن [ISlideCollection] ومرّر الشريحة من العرض المصدر لتُستنسخ والشريحة الرئيسة كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. اكتب ملف عرض التقديمي الوجهة المعدل.

في المثال المعطى أدناه، استنسخنا شريحة مع شريحة رئيسة (تقع في الفهرس صفر من العرض التقديمي المصدر) إلى نهاية العرض التقديمي الوجهة باستخدام شريحة رئيسة من الشريحة المصدر.
```java
// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // إنشاء كائن من فئة Presentation للعرض التقديمي الوجهة (حيث سيتم استنساخ الشريحة)
    Presentation destPres = new Presentation();
    try {
        // إنشاء ISlide من مجموعة الشرائح في العرض التقديمي المصدر مع
        // الشريحة الرئيسة
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // استنساخ الشريحة الرئيسة المطلوبة من العرض التقديمي المصدر إلى مجموعة الرؤساء في الـ
        // العرض التقديمي الوجهة
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // استنساخ الشريحة الرئيسة المطلوبة من العرض التقديمي المصدر إلى مجموعة الرؤساء في الـ
        // العرض التقديمي الوجهة
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // استنساخ الشريحة المطلوبة من العرض التقديمي المصدر مع الشريحة الرئيسة المطلوبة إلى نهاية الـ
        // مجموعة الشرائح في العرض التقديمي الوجهة
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // حفظ العرض التقديمي الوجهة إلى القرص
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```


## **استنساخ شريحة في نهاية قسم محدد**
إذا كنت تريد استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي ولكن في قسم مختلف، استخدم طريقة [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) التي يُعرّفها واجهة [**ISlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection). Aspose.Slides for Android via Java يجعل من الممكن استنساخ شريحة من القسم الأول ثم إدراج تلك الشريحة المستنسخة إلى القسم الثاني من نفس العرض التقديمي.

تُظهر المَقطَع البرمجي التالي كيفية استنساخ شريحة وإدراج الشريحة المستنسخة في قسم محدد.
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

نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في الاستنساخ. إذا كنت لا تريدها، [قم بإزالتها](/slides/ar/androidjava/presentation-notes/) بعد الإدراج.

**كيف يتم التعامل مع المخططات ومصادر بياناتها؟**

يتم نسخ كائن المخطط، وتنسيقه، والبيانات المضمنة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثل مصنف OLE مضمّن)، يتم الحفاظ على هذا الارتباط ككائن [OLE](/slides/ar/androidjava/manage-ole/). بعد النقل بين الملفات، تحقق من توفر البيانات وسلوك التحديث.

**هل يمكنني التحكم في موضع الإدراج والأقسام للاستنساخ؟**

نعم. يمكنك إدراج الاستنساخ عند فهرس شريحة محدد ووضعه في [قسم](/slides/ar/androidjava/slide-section/) مختار. إذا لم يكن القسم الهدف موجودًا، أنشئه أولاً ثم انقل الشريحة إليه.