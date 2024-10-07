---
title: نسخ الشرائح
type: docs
weight: 35
url: /java/clone-slides/
---

## **نسخ الشرائح في العرض التقديمي**
النسخ هو عملية إنشاء نسخةطبق الأصل أو نسخة من شيء ما. كما أن Aspose.Slides لجافا يجعل من الممكن أيضًا عمل نسخة أو استنساخ لأي شريحة ثم إدراج تلك الشريحة المستنسخة في العرض التقديمي الحالي أو أي عرض تقديمي آخر مفتوح. عملية نسخ الشرائح تنتج شريحة جديدة يمكن تعديلها بواسطة المطورين دون تغيير الشريحة الأصلية. هناك несколько طرق ممكنة لنسخ الشريحة:

- النسخ في النهاية ضمن العرض التقديمي.
- النسخ في موضع آخر ضمن العرض التقديمي.
- النسخ في النهاية في عرض تقديمي آخر.
- النسخ في موضع آخر في عرض تقديمي آخر.
- النسخ في موضع محدد في عرض تقديمي آخر.

في Aspose.Slides لجافا، (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide)) المعرضة بواسطة كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) توفر طرق [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) و [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) لأداء أنواع النسخ أعلاه.

## **نسخ في النهاية ضمن العرض التقديمي**
إذا كنت تريد نسخ شريحة ثم استخدامها ضمن نفس ملف العرض التقديمي في نهاية الشرائح الموجودة، استخدم طريقة [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) وفقًا للخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاؤها من خلال مرجعية مجموعة [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) المعرضة بواسطة كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
3. استدعاء طريقة [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) المعرضة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) وتمرير الشريحة ليتم نسخها كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
4. اكتب ملف العرض التقديمي المعدل.

في المثال المعطى أدناه، قمنا بنسخ شريحة (ترتفع في الموضع الأول – مؤشر صفر – من العرض التقديمي) إلى نهاية العرض التقديمي.

```java
// إنشاء مثيل لفئة Presentation التي تمثل ملف العرض التقديمي
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // نسخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // كتابة العرض التقديمي المعدل إلى القرص
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **نسخ في موضع آخر ضمن العرض التقديمي**
إذا كنت تريد نسخ شريحة ثم استخدامها ضمن نفس ملف العرض التقديمي ولكن في موضع مختلف، استخدم طريقة [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) :

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
2. إنشاؤها من خلال مرجعية مجموعة [**Slides**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) المعرضة بواسطة كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
3. استدعاء طريقة [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) المعرضة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) وتمرير الشريحة ليتم نسخها مع الفهرس للموضع الجديد كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
4. اكتب العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، قمنا بنسخ شريحة (ترتفع في المؤشر صفر – الموضع 1 – من العرض التقديمي) إلى المؤشر 1 – الموضع 2 – من العرض التقديمي.

```java
// إنشاء مثيل لفئة Presentation التي تمثل ملف العرض التقديمي
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // نسخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    ISlideCollection slds = pres.getSlides();

    // نسخ الشريحة المطلوبة إلى الفهرس المحدد في نفس العرض التقديمي
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // كتابة العرض التقديمي المعدل إلى القرص
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **نسخ في النهاية في عرض تقديمي آخر**
إذا كنت بحاجة إلى نسخ شريحة من عرض تقديمي واحد واستخدامها في ملف عرض تقديمي آخر، في نهاية الشرائح الموجودة:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي تحتوي على العرض التقديمي الذي سيتم النسخ منه.
2. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي تحتوي على العرض التقديمي الهدف الذي سيتم إضافة الشريحة إليه.
3. إنشاؤها من خلال مرجعية مجموعة [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) من خلال مرجعية مجموعة [**Slides**](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) المعرضة بواسطة كائن العرض التقديمي للعرض التقديمي الهدف.
4. استدعاء طريقة [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) المعرضة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) وتمرير الشريحة من العرض التقديمي المصدر كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) .
5. كتابة ملف العرض التقديمي المعدل.

في المثال المعطى أدناه، قمنا بنسخ شريحة (من الفهرس الأول من العرض التقديمي المصدر) إلى نهاية العرض التقديمي الهدف.

```java
// إنشاء مثيل لفئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // إنشاء مثيل لفئة Presentation لعرض تقديمي الهدف PPTX (الذي سيتم النسخ إليه)
    Presentation destPres = new Presentation();
    try {
        // نسخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الهدف
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // كتابة العرض التقديمي الهدف إلى القرص
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **نسخ في موضع آخر في عرض تقديمي آخر**
إذا كنت بحاجة إلى نسخ شريحة من عرض تقديمي واحد واستخدامها في ملف عرض تقديمي آخر، في موضع محدد:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي تحتوي على العرض التقديمي المصدر الذي سيتم النسخ منه.
2. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي تحتوي على العرض التقديمي الذي سيتم إضافة الشريحة إليه.
3. إنشاؤها من خلال مرجعية مجموعة [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) من خلال مرجعية مجموعة الشرائح المعرضة بواسطة كائن العرض التقديمي الهدف.
4. استدعاء طريقة [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) المعرضة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) وتمرير الشريحة من العرض التقديمي المصدر مع الموضع المطلوب كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
5. كتابة ملف العرض التقديمي المعدل.

في المثال المعطى أدناه، قمنا بنسخ شريحة (من الفهرس صفر من العرض التقديمي المصدر) إلى الفهرس 1 (الموضع 2) من العرض التقديمي الهدف.

```java
// إنشاء مثيل لفئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // إنشاء مثيل لفئة Presentation لعرض تقديمي الهدف PPTX (الذي سيتم النسخ إليه)
    Presentation destPres = new Presentation();
    try {
        // نسخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الهدف
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // كتابة العرض التقديمي الهدف إلى القرص
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **نسخ في موضع محدد في عرض تقديمي آخر**
إذا كنت بحاجة إلى نسخ شريحة تحتوي على شريحة رئيسية من عرض تقديمي واحد واستخدامها في عرض تقديمي آخر، تحتاج إلى نسخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر أولاً إلى العرض التقديمي الهدف. ثم تحتاج إلى استخدام تلك الشريحة الرئيسية لنسخ الشريحة مع الشريحة الرئيسية. تتطلب طريقة [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) شريحة رئيسية من العرض التقديمي الهدف بدلاً من العرض التقديمي المصدر. لنسخ الشريحة مع الشريحة الرئيسية، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي تحتوي على العرض التقديمي المصدر الذي سيتم النسخ منه.
2. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) التي تحتوي على العرض التقديمي الهدف الذي سيتم النسخ إليه.
3. الوصول إلى الشريحة ليتم نسخها مع الشريحة الرئيسية.
4. إنشاؤها من خلال مرجعية مجموعة [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) من خلال مرجعية مجموعة السلايدات المعرضة بواسطة كائن [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) للعروض التقديمية الهدف.
5. استدعاء طريقة [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) المعرضة بواسطة كائن [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) وتمرير الشريحة الرئيسية من PPTX المصدر إلى أن يتم نسخها كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) .
6. إنشاؤها من خلال مرجعية مجموعة [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) من خلال مرجعية مجموعة الشرائح المعرضة بواسطة كائن العرض التقديمي الهدف.
7. استدعاء طريقة [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) المعرضة بواسطة كائن [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--) وتمرير الشريحة من العرض التقديمي المصدر التي سيتم نسخها وشريحة رئيسية كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) .
8. كتابة ملف العرض التقديمي الهدف المعدل.

في المثال المعطى أدناه، قمنا بنسخ شريحة مع شريحة رئيسية (ترتفع في المؤشر صفر من العرض التقديمي المصدر) إلى نهاية العرض التقديمي الهدف مستخدمين شريحة رئيسية من الشريحة المصدر.

```java
// إنشاء مثيل لفئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // إنشاء مثيل لفئة Presentation للعرض التقديمي الهدف (الذي سيتم نسخ الشريحة إليه)
    Presentation destPres = new Presentation();
    try {
        // إنشاء ISlide من مجموعة الشرائح في العرض التقديمي المصدر مع
        // الشريحة الرئيسية
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // نسخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الشرائح الرئيسية في
        // العرض التقديمي الهدف
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // نسخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الشرائح الرئيسية في
        // العرض التقديمي الهدف
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // نسخ الشريحة المطلوبة من العرض التقديمي المصدر مع الشريحة الرئيسية المطلوبة إلى نهاية
        // مجموعة الشرائح في العرض التقديمي الهدف
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // حفظ العرض التقديمي الهدف إلى القرص
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **نسخ في النهاية في قسم محدد**
إذا كنت ترغب في نسخ شريحة ثم استخدامها ضمن نفس ملف العرض التقديمي ولكن في قسم مختلف، استخدم طريقة [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) المعرضة بواسطة واجهة [**ISlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection). يساعد Aspose.Slides لجافا في نسخ شريحة من القسم الأول ثم إدراج تلك الشريحة المنسوخة في القسم الثاني من نفس العرض التقديمي.

يوضح مقتطف الكود التالي كيفية نسخ شريحة وإدراج الشريحة المنسوخة في قسم محدد.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("القسم 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("القسم 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// حفظ العرض التقديمي الهدف إلى القرص
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```