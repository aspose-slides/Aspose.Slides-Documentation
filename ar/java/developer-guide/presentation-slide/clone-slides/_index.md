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
description: "انسخ شرائح PowerPoint بسرعة باستخدام Aspose.Slides للـ Java. اتبع أمثلة الشيفرة الواضحة لتلقائيًا إنشاء عروض PPT في ثوانٍ وإلغاء الحاجة إلى العمل اليدوي."
---
## **المقدمة**

الاستنساخ هو عملية إنشاء نسخة مطابقة أو نسخة مكررة من شيء ما. يتيح Aspose.Slides for Java أيضًا إمكانية عمل نسخة أو استنساخ لأي شريحة ثم إدراج تلك الشريحة المستنسخة إلى العرض التقديمي الحالي أو أي عرض تقديمي مفتوح آخر. عملية استنساخ الشريحة تُنشئ شريحة جديدة يمكن للمطورين تعديلها دون تغيير الشريحة الأصلية. هناك عدة طرق ممكنة لاستنساخ شريحة:

- استنساخ في النهاية داخل عرض تقديمي.
- استنساخ في موضع آخر داخل عرض تقديمي.
- استنساخ في النهاية في عرض تقديمي آخر.
- استنساخ في موضع آخر في عرض تقديمي آخر.
- استنساخ مع الشريحة الرئيسية إلى عرض تقديمي آخر.

في Aspose.Slides for Java، (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlide)) التي يُعرّفها كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) توفر طريقتي [addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) و[insertClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) لتنفيذ الأنواع المذكورة أعلاه من استنساخ الشرائح.

## **استنساخ شريحة في نهاية عرض تقديمي**
إذا أردت استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي في نهاية الشرائح الموجودة، استخدم طريقة [addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) وفقًا للخطوات المذكورة أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
1. استدعاء فئة [ISlideCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#getSlides--) بالإشارة إلى مجموعة الشرائح التي يُعرّفها كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي يُعرّفها كائن [ISlideCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#getSlides--) وتمرير الشريحة التي سيتم استنساخها كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. كتابة ملف العرض التقديمي المعدل.

في المثال أدناه، قمنا باستنساخ شريحة (تقع في الموضع الأول – الفهرس صفر – من العرض التقديمي) إلى نهاية العرض التقديمي.

```java
import com.aspose.slides.*;

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
إذا أردت استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي لكن في موضع مختلف، استخدم طريقة [insertClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
1. استدعاء الفئة بالإشارة إلى مجموعة [**Slides**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#getSlides--) التي يُعرّفها كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation).
1. استدعاء طريقة [insertClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) التي يُعرّفها كائن [ISlideCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#getSlides--) وتمرير الشريحة التي سيتم استنساخها مع الفهرس للموقع الجديد كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال أدناه، قمنا باستنساخ شريحة (تقع في الفهرس 1 – الموضع 2 – من العرض التقديمي) إلى الفهرس 2 – الموضع 3 – من العرض التقديمي.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // الحصول على مجموعة الشرائح في العرض التقديمي
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
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واستخدامها في ملف عرض تقديمي آخر، في نهاية الشرائح الموجودة:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) التي تحتوي على العرض التقديمي الذي ستُستنسخ منه الشريحة.
1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) التي تحتوي على العرض التقديمي الوجهة التي ستُضاف إليها الشريحة.
1. استدعاء فئة [ISlideCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection) بالإشارة إلى مجموعة [**Slides**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#getSlides--) التي يُعرّفها كائن العرض التقديمي للعرض الوجهة.
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي يُعرّفها كائن [ISlideCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#getSlides--) وتمرير الشريحة من العرض المصدر كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. كتابة ملف العرض التقديمي الوجهة المعدل.

في المثال أدناه، قمنا باستنساخ شريحة (من الفهرس الأول للعرض المصدر) إلى نهاية العرض الوجهة.

```java
import com.aspose.slides.*;

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

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) التي تحتوي على العرض المصدر الذي ستُستنسخ منه الشريحة.
1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) التي تحتوي على العرض التقديمي الذي ستُضاف إليه الشريحة.
1. استدعاء فئة [ISlideCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#getSlides--) بالإشارة إلى مجموعة الشرائح التي يُعرّفها كائن العرض التقديمي للعرض الوجهة.
1. استدعاء طريقة [insertClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) التي يُعرّفها كائن [ISlideCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#getSlides--) وتمرير الشريحة من العرض المصدر مع الموضع المطلوب كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-).
1. كتابة ملف العرض التقديمي الوجهة المعدل.

في المثال أدناه، قمنا باستنساخ شريحة (من الفهرس صفر للعرض المصدر) إلى الفهرس 1 (الموضع 2) للعرض الوجهة.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // إنشاء كائن من فئة Presentation لملف PPTX الوجهة (حيث سيتم استنساخ الشريحة)
    Presentation destPres = new Presentation();
    try {
        // استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى الفهرس المحدد في العرض التقديمي الوجهة
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // كتابة العرض التقديمي الوجهة إلى القرص
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **استنساخ شريحة مع شريحة رئيسية إلى عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة مع شريحة رئيسية من عرض تقديمي واستخدامها في عرض تقديمي آخر، يجب أولاً استنساخ الشريحة الرئيسية المطلوبة من العرض المصدر إلى العرض الوجهة. ثم تحتاج إلى استخدام تلك الشريحة الرئيسية لاستنساخ الشريحة مع الشريحة الرئيسية. طريقة [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) تتوقع شريحة رئيسية من العرض الوجهة وليس من العرض المصدر. لاستنساخ الشريحة مع الشريحة الرئيسية، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) التي تحتوي على العرض المصدر الذي ستُستنسخ منه الشريحة.
1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) التي تحتوي على العرض الوجهة الذي ستُستنسخ إليه الشريحة.
1. الوصول إلى الشريحة التي ستُستنسخ مع الشريحة الرئيسية.
1. استدعاء فئة [IMasterSlideCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/IMasterSlideCollection) بالإشارة إلى مجموعة Masters التي يُعرّفها كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) للعرض الوجهة.
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي يُعرّفها كائن [IMasterSlideCollection] وتمرير الشريحة الرئيسية من ملف PPTX المصدر ليتم استنساخها كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. استدعاء فئة [ISlideCollection](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation#getSlides--) بتعيين الإشارة إلى مجموعة الشرائح التي يُعرّفها كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/Presentation) للعرض الوجهة.
1. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي يُعرّفها كائن [ISlideCollection] وتمرير الشريحة من العرض المصدر إلى أن تُستنسخ مع الشريحة الرئيسية كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
1. كتابة ملف العرض التقديمي الوجهة المعدل.

في المثال أدناه، قمنا باستنساخ شريحة مع شريحة رئيسية (تقع في الفهرس صفر للعرض المصدر) إلى نهاية العرض الوجهة باستخدام شريحة رئيسية من الشريحة المصدر.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // إنشاء كائن من فئة Presentation للعرض التقديمي الوجهة (حيث سيتم استنساخ الشريحة)
    Presentation destPres = new Presentation();
    try {
        // إنشاء كائن ISlide من مجموعة الشرائح في العرض التقديمي المصدر مع
        // الشريحة الرئيسية
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الشرائح الرئيسية في
        // العرض التقديمي الوجهة
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // استنساخ الشريحة المطلوبة من العرض التقديمي المصدر مع الشريحة الرئيسية المطلوبة إلى نهاية
        // مجموعة الشرائح في العرض التقديمي الوجهة
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

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
إذا أردت استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي لكن في قسم مختلف، استخدم طريقة [**addClone**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) التي يُعرّفها واجهة [**ISlideCollection**](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ISlideCollection). يتيح Aspose.Slides for Java إمكانية استنساخ شريحة من القسم الأول ثم إدراج تلك الشريحة المستنسخة إلى القسم الثاني من نفس العرض التقديمي.

المقتطف البرمجي التالي يوضح كيفية استنساخ شريحة وإدراج الشريحة المستنسخة إلى قسم محدد.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);

    // حفظ العرض التقديمي الوجهة إلى القرص
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تأكد من توافق حجم الشريحة**

عند استنساخ الشرائح إلى عرض تقديمي آخر، تأكد من أن حجم الشريحة في العرض الوجهة يطابق حجم الشريحة في المصدر. إذا اختلف حجم الشرائح، لا يقوم Aspose.Slides بإعادة تحجيم الأشكال المستنسخة تلقائيًا—تُحفظ إحداثياتها وأبعادها الأصلية، مما قد يتسبب في ظهور المحتوى غير مرتب أو يمتد خارج حدود الشريحة.

يمكنك ضبط حجم شريحة العرض الوجهة ليتطابق مع المصدر قبل استنساخ الشريحة والرئيسية:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

قم بذلك قبل استنساخ الشريحة والرئيسية.

## **الأسئلة المتكررة**

**هل يتم استنساخ ملاحظات المتحدث وتعليقات المراجعين؟**

نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في النسخة المستنسخة. إذا لم ترغب فيها، [أزلها](/slides/ar/java/presentation-notes/) بعد الإدراج.

**كيف يتم التعامل مع المخططات ومصادر بياناتها؟**

يتم نسخ كائن المخطط وتنسيقه والبيانات المدمجة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثل ملف عمل مضمن OLE)، يُحافظ على هذا الارتباط كـ[كائن OLE](/slides/ar/java/manage-ole/). بعد النقل بين الملفات، تحقق من توفر البيانات وسلوك التحديث.

**هل يمكنني التحكم في موضع الإدراج والأقسام للنسخة المستنسخة؟**

نعم. يمكنك إدراج النسخة المستنسخة عند فهرس شريحة معين ووضعها في [قسم](/slides/ar/java/slide-section/) مختار. إذا كان القسم المستهدف غير موجود، أنشئه أولاً ثم انقل الشريحة إليه.