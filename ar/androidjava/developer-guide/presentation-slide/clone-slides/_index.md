---
title: استنساخ الشرائح
type: docs
weight: 35
url: /ar/androidjava/clone-slides/
---


## **استنساخ الشرائح في العرض التقديمي**
الاستنساخ هو عملية إنشاء نسخة دقيقة أو مماثلة لشيء ما. كما أن Aspose.Slides لنظام Android عبر Java يجعل من الممكن إنشاء نسخة أو استنساخ لأي شريحة ثم إدراج تلك الشريحة المستنسخة في العرض التقديمي الحالي أو أي عرض تقديمي آخر مفتوح. عملية استنساخ الشرائح تنشئ شريحة جديدة يمكن تعديلها بواسطة المطورين دون تغيير الشريحة الأصلية. هناك عدة طرق ممكنة لاستنساخ شريحة:

- استنساخ في النهاية داخل عرض تقديمي.
- استنساخ في موقع آخر داخل العرض التقديمي.
- استنساخ في النهاية في عرض تقديمي آخر.
- استنساخ في موقع آخر في عرض تقديمي آخر.
- استنساخ في موقع محدد في عرض تقديمي آخر.

في Aspose.Slides لنظام Android عبر Java، (مجموعة من [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) الكائنات) التي تعرضها [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) الكائن يوفر [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) و [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) الأساليب لتنفيذ أنواع الاستنساخ المذكورة أعلاه.

## **استنساخ في النهاية داخل عرض تقديمي**
إذا كنت ترغب في استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي في نهاية الشرائح الحالية، استخدم [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) الأسلوب وفقًا للخطوات المدرجة أدناه:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) الفئة.
1. قم بإنشاء مثيل من [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) الفئة عن طريق الإشارة إلى مجموعة الشرائح التي تعرضها [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) الكائن.
1. استدعاء [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) الأسلوب الذي تعرضه [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) الكائن ومرر الشريحة التي تريد استنساخها كمعامل إلى [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) الأسلوب.
1. كتابة ملف العرض التقديمي المعدّل.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (تقع في الموضع الأول – مؤشر صفر – من العرض التقديمي) إلى نهاية العرض التقديمي.

```java
// إنشاء مثيل لفئة Presentation تمثل ملف عرض تقديمي
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // استنساخ الشريحة المرغوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // الكتابة إلى ملف العرض التقديمي المعدل على القرص
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **استنساخ في موقع آخر داخل عرض تقديمي**
إذا كنت ترغب في استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي ولكن في موقع مختلف، استخدم [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) الأسلوب:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) الفئة.
1. قم بإنشاء مثيل من الفئة عن طريق الإشارة إلى مجموعة [**Slides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) التي تعرضها [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) الكائن.
1. استدعاء [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) الأسلوب الذي تعرضه [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) الكائن ومرر الشريحة التي تريد استنساخها مع الفهرس للموقع الجديد كمعامل إلى [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) الأسلوب.
1. كتابة العرض التقديمي المعدّل كملف PPTX.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (تقع في مؤشر صفر – الموضع 1 – من العرض التقديمي) إلى المؤشر 1 – الموضع 2 – من العرض التقديمي.

```java
// إنشاء مثيل لفئة Presentation تمثل ملف عرض تقديمي
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // استنساخ الشريحة المرغوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    ISlideCollection slds = pres.getSlides();

    // استنساخ الشريحة المرغوبة إلى الفهرس المحدد في نفس العرض التقديمي
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // الكتابة إلى ملف العرض التقديمي المعدل على القرص
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **استنساخ في النهاية في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واحد واستخدامها في ملف عرض تقديمي آخر، في نهاية الشرائح الحالية:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) الفئة التي تحتوي على العرض التقديمي الذي سيتم استنساخ الشريحة منه.
1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) الفئة التي تحتوي على العرض التقديمي الوجهة التي ستتم إضافة الشريحة إليها.
1. قم بإنشاء مثيل من [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) الفئة عن طريق الإشارة إلى مجموعة [**Slides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) التي تعرضها كائن العرض التقديمي للعرض التقديمي الوجهة.
1. استدعاء [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) الأسلوب الذي تعرضه [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) الكائن ومرر الشريحة من العرض التقديمي المصدر كمعامل إلى [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) الأسلوب.
1. كتابة ملف العرض التقديمي المعدّل للوجهة.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (من الفهرس الأول للعرض التقديمي المصدر) إلى نهاية العرض التقديمي الوجهة.

```java
// إنشاء مثيل لفئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // إنشاء مثيل لفئة Presentation لعرض PPTX الوجهة (حيث سيتم استنساخ الشريحة)
    Presentation destPres = new Presentation();
    try {
        // استنساخ الشريحة المرغوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الوجهة
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // الكتابة إلى ملف العرض التقديمي الوجهة على القرص
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **استنساخ في موقع آخر في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واحد واستخدامها في ملف عرض تقديمي آخر، في موقع محدد:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) الفئة التي تحتوي على العرض التقديمي المصدر الذي سيتم استنساخ الشريحة منه.
1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) الفئة التي تحتوي على العرض التقديمي الذي ستتم إضافة الشريحة إليه.
1. قم بإنشاء مثيل من [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) الفئة عن طريق الإشارة إلى مجموعة الشرائح التي تعرضها كائن العرض التقديمي للعرض التقديمي الوجهة.
1. استدعاء [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) الأسلوب الذي تعرضه [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) الكائن ومرر الشريحة من العرض التقديمي المصدر مع الموقع المطلوب كمعامل إلى [insertClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) الأسلوب.
1. كتابة ملف العرض التقديمي المعدّل للوجهة.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (من الفهرس صفر للعرض التقديمي المصدر) إلى المؤشر 1 (الموضع 2) من العرض التقديمي الوجهة.

```java
// إنشاء مثيل لفئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // إنشاء مثيل لفئة Presentation لعرض PPTX الوجهة (حيث سيتم استنساخ الشريحة)
    Presentation destPres = new Presentation();
    try {
        // استنساخ الشريحة المرغوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الوجهة
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // الكتابة إلى ملف العرض التقديمي الوجهة على القرص
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **استنساخ في موقع محدد في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة مع شريحة رئيسية من عرض تقديمي واحد واستخدامها في عرض تقديمي آخر، تحتاج إلى استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى العرض التقديمي الوجهة أولاً. ثم تحتاج إلى استخدام تلك الشريحة الرئيسية لاستنساخ الشريحة مع الشريحة الرئيسية. يتوقع [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) شريحة رئيسية من العرض التقديمي الوجهة بدلاً من العرض التقديمي المصدر. من أجل استنساخ الشريحة مع الرئيسية، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) الفئة التي تحتوي على العرض التقديمي المصدر الذي سيتم استنساخ الشريحة منه.
1. إنشاء مثيل من [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) الفئة التي تحتوي على العرض التقديمي الوجهة التي ستستنسخ إليها الشريحة.
1. الوصول إلى الشريحة التي ستستنسخ جنبًا إلى جنب مع الشريحة الرئيسية.
1. قم بإنشاء مثيل من [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) الفئة عن طريق الإشارة إلى مجموعة الرئيسيات التي تعرضها [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) الكائن للعرض التقديمي الوجهة.
1. استدعاء [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) الأسلوب الذي تعرضه [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) الكائن ومرر الشريحة الرئيسية من عرض PPTX المصدر التي سيتم استنساخها كمعامل إلى [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) الأسلوب.
1. قم بإنشاء مثيل من [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) الفئة عن طريق تعيين المرجعية إلى مجموعة الشرائح التي تعرضها كائن العرض التقديمي للعرض التقديمي الوجهة.
1. استدعاء [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) الأسلوب الذي تعرضه [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--) الكائن ومرر الشريحة من العرض التقديمي المصدر التي سيتم استنساخها والشريحة الرئيسية كمعامل إلى [addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) الأسلوب.
1. كتابة ملف العرض التقديمي المعدّل للوجهة.

في المثال المعطى أدناه، قمنا باستنساخ شريحة مع شريحة رئيسية (تقع في الفهرس صفر من العرض التقديمي المصدر) إلى نهاية العرض التقديمي الوجهة باستخدام شريحة رئيسية من شريحة المصدر.

```java
// إنشاء مثيل لفئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // إنشاء مثيل لفئة Presentation للعرض التقديمي الوجهة (حيث سيتم استنساخ الشريحة)
    Presentation destPres = new Presentation();
    try {
        // إنشاء ISlide من مجموعة الشرائح في العرض التقديمي المصدر جنبًا إلى جنب مع
        // الشريحة الرئيسية
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الرئيسيات في
        // العرض التقديمي الوجهة
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الرئيسيات في
        // العرض التقديمي الوجهة
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // استنساخ الشريحة المرغوبة من العرض التقديمي المصدر مع الرئيسية المطلوبة إلى نهاية
        // مجموعة الشرائح في العرض التقديمي الوجهة
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // حفظ العرض التقديمي الوجهة على القرص
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **استنساخ في النهاية في قسم محدد**
إذا كنت ترغب في استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي ولكن في قسم مختلف، استخدم [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) الأسلوب الذي تعرضه [**ISlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) الواجهة. تجعل Aspose.Slides لنظام Android عبر Java من الممكن استنساخ شريحة من القسم الأول ثم إدراج تلك الشريحة المستنسخة إلى القسم الثاني من نفس العرض التقديمي.

يظهر مقتطف الكود التالي كيفية استنساخ شريحة وإدراج الشريحة المستنسخة في قسم محدد.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// حفظ العرض التقديمي الوجهة على القرص
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```