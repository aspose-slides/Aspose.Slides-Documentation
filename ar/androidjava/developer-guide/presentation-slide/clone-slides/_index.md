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
description: "استنسخ شرائح PowerPoint باستخدام Aspose.Slides لنظام Android. تابع أمثلة الكود الواضحة بلغة Java لأتمتة إنشاء ملفات PPT في ثوانٍ وإلغاء الحاجة إلى العمل اليدوي."
---
## **المقدمة**

الاستنساخ هو العملية التي يتم من خلالها إنشاء نسخة مطابقة أو نسخة مماثلة لشيء ما. تسمح مكتبة Aspose.Slides for Android عبر Java بإنشاء نسخة أو استنساخ لأي شريحة ثم إدراج تلك الشريحة المستنسخة في العرض التقديمي الحالي أو أي عرض آخر مفتوح. عملية استنساخ الشرائح تُنشئ شريحة جديدة يمكن للمطورين تعديلها دون تغيير الشريحة الأصلية. هناك عدة طرق محتملة لاستنساخ شريحة:

- استنساخ في النهاية داخل عرض تقديمي.
- استنساخ في موقع آخر داخل العرض التقديمي.
- استنساخ في النهاية في عرض تقديمي آخر.
- استنساخ في موقع آخر في عرض تقديمي آخر.
- استنساخ في موقع محدد في عرض تقديمي آخر.

في Aspose.Slides for Android عبر Java، (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlide) ) التي تُعرَض عبر كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) توفر طريقتي [addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) و[insertClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) لتنفيذ الأنواع المذكورة أعلاه من استنساخ الشرائح.

## **استنساخ شريحة في نهاية عرض تقديمي**
إذا أردت استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي في نهاية الشرائح الموجودة، استخدم طريقة [addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) وفقًا للخطوات المذكورة أدناه:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation).
2. إنشاء كائن من الفئة [ISlideCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getSlides--) عبر الإشارة إلى مجموعة Slides التي تُعرَض من خلال كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation).
3. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي تُعرَض من كائن [ISlideCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getSlides--) وتمرير الشريحة المراد استنساخها كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
4. حفظ ملف العرض التقديمي المعدل.

في المثال المعطى أدناه، تم استنساخ شريحة (الواقعة في الموضع الأول – الفهرس صفر – من العرض التقديمي) إلى نهاية العرض التقديمي.

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // حفظ العرض التقديمي المعدل إلى القرص
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **استنساخ شريحة إلى موقع آخر داخل عرض تقديمي**
إذا أردت استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي ولكن في موضع مختلف، استخدم طريقة [insertClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-):

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation).
2. إنشاء كائن من الفئة [**Slides**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getSlides--) عبر الإشارة إلى مجموعة Slides التي تُعرَض من خلال كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation).
3. استدعاء طريقة [insertClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) التي تُعرَض من كائن [ISlideCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getSlides--) وتمرير الشريحة المراد استنساخها مع الفهرس للموقع الجديد كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-).
4. حفظ العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، تم استنساخ شريحة (الواقعة في الفهرس 1 – الموضع 2 – من العرض التقديمي) إلى الفهرس 2 – الموضع 3 – من العرض التقديمي.

```java
import com.aspose.slides.*;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // الحصول على مجموعة الشرائح في نفس العرض التقديمي
    ISlideCollection slds = pres.getSlides();

    // استنساخ الشريحة المطلوبة إلى الفهرس المحدد في نفس العرض التقديمي
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // حفظ العرض التقديمي المعدل إلى القرص
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **استنساخ شريحة في نهاية عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واستخدامها في عرض تقديمي آخر، في نهاية الشرائح الموجودة:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) يحتوي على العرض التقديمي الذي سيتم استنساخ الشريحة منه.
2. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) يحتوي على العرض التقديمي الهدف الذي ستُضاف إليه الشريحة.
3. إنشاء كائن من الفئة [ISlideCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection) عبر الإشارة إلى مجموعة **Slides** التي تُعرَض من خلال كائن Presentation للعرض التقديمي الهدف.
4. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي تُعرَض من كائن [ISlideCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getSlides--) وتمرير الشريحة من العرض التقديمي المصدر كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-).
5. حفظ ملف العرض التقديمي الهدف المعدل.

في المثال المعطى أدناه، تم استنساخ شريحة (من الفهرس الأول للعرض التقديمي المصدر) إلى نهاية العرض التقديمي الهدف.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // إنشاء كائن من فئة Presentation للملف الهدف PPTX (حيث سيتم استنساخ الشريحة)
    Presentation destPres = new Presentation();
    try {
        // استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الهدف
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // حفظ العرض التقديمي الهدف إلى القرص
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **استنساخ شريحة إلى موقع آخر في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واستخدامها في عرض تقديمي آخر، في موضع محدد:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) يحتوي على العرض التقديمي المصدر الذي ستُستنسَخ منه الشريحة.
2. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) يحتوي على العرض التقديمي الذي ستُضاف إليه الشريحة.
3. إنشاء كائن من الفئة [ISlideCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getSlides--) عبر الإشارة إلى مجموعة Slides التي تُعرَض من خلال كائن Presentation للعرض التقديمي الهدف.
4. استدعاء طريقة [insertClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) التي تُعرَض من كائن [ISlideCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getSlides--) وتمرير الشريحة من العرض التقديمي المصدر مع الموضع المطلوب كمعامل إلى طريقة [insertClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISSlide-).
5. حفظ ملف العرض التقديمي الهدف المعدل.

في المثال المعطى أدناه، تم استنساخ شريحة (من الفهرس صفر للعرض التقديمي المصدر) إلى الفهرس 1 (الموضع 2) من العرض التقديمي الهدف.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // إنشاء كائن من فئة Presentation للملف PPTX الهدف (حيث سيتم استنساخ الشريحة)
    Presentation destPres = new Presentation();
    try {
        // استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى الفهرس المحدد في العرض التقديمي الهدف
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // حفظ العرض التقديمي الهدف إلى القرص
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **استنساخ شريحة في موقع محدد في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة تحتوي على شريحة رئيسية من عرض تقديمي واستخدامها في عرض تقديمي آخر، يجب أولاً استنساخ الشريحة الرئيسية المطلوبة من العرض المصدر إلى العرض الهدف. بعد ذلك يستخدم تلك الشريحة الرئيسية لاستنساخ الشريحة مع الشريحة الرئيسية. الطريقة [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) تتوقع شريحة رئيسية من العرض الهدف وليس من العرض المصدر. لتنفيذ استنساخ الشريحة مع الشريحة الرئيسية، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) يحتوي على العرض التقديمي المصدر الذي ستُستنسَخ منه الشريحة.
2. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) يحتوي على العرض التقديمي الهدف الذي ستُستنسَخ إليه الشريحة.
3. الوصول إلى الشريحة المراد استنساخها مع الشريحة الرئيسية.
4. إنشاء كائن من الفئة [IMasterSlideCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IMasterSlideCollection) عبر الإشارة إلى مجموعة Masters التي تُعرَض من خلال كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) للعرض التقديمي الهدف.
5. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي تُعرَض من كائن [IMasterSlideCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/IMasterSlideCollection) وتمرير الشريحة الرئيسية من ملف PPTX المصدر كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
6. إنشاء كائن من الفئة [ISlideCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getSlides--) بضبط الإشارة إلى مجموعة Slides التي تُعرَض من خلال كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation) للعرض التقديمي الهدف.
7. استدعاء طريقة [addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) التي تُعرَض من كائن [ISlideCollection](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/Presentation#getSlides--) وتمرير الشريحة من العرض التقديمي المصدر إلى أن تُستنسَخ مع الشريحة الرئيسية كمعامل إلى طريقة [addClone](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-).
8. حفظ ملف العرض التقديمي الهدف المعدل.

في المثال المعطى أدناه، تم استنساخ شريحة مع شريحة رئيسية (الواقعة في الفهرس صفر للعرض التقديمي المصدر) إلى نهاية العرض التقديمي الهدف باستخدام شريحة رئيسية من الشريحة المصدر.

```java
import com.aspose.slides.*;

// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // إنشاء كائن من فئة Presentation للعرض التقديمي الهدف (حيث سيتم استنساخ الشريحة)
    Presentation destPres = new Presentation();
    try {
        // إنشاء كائن ISlide من مجموعة الشرائح في العرض التقديمي المصدر مع
        // الشريحة الرئيسية
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الشرائح الرئيسية في
        // العرض التقديمي الهدف
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // استنساخ الشريحة المطلوبة من العرض التقديمي المصدر مع الشريحة الرئيسية المطلوبة إلى نهاية
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

## **استنساخ شريحة في نهاية قسم محدد**
إذا أردت استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي ولكن في قسم مختلف، استخدم طريقة [**addClone**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) التي تُعرَض من واجهة [**ISlideCollection**](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ISlideCollection). تتيح Aspose.Slides for Android عبر Java إمكانية استنساخ شريحة من القسم الأول ثم إدراج تلك الشريحة المستنسخة إلى القسم الثاني من نفس العرض التقديمي.

المقتطف البرمجي التالي يوضح كيفية استنساخ شريحة وإدراجها في قسم محدد.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// حفظ العرض التقديمي الهدف إلى القرص
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **تأكد من تطابق حجم الشريحة**

عند استنساخ الشرائح إلى عرض تقديمي آخر، تأكد من أن حجم الشرائح في العرض الهدف يطابق حجم الشرائح في المصدر. إذا اختلف حجم الشرائح، لا تقوم Aspose.Slides بإعادة تحجيم الأشكال المستنسخة تلقائيًا—تُحافظ على إحداثياتها وأبعادها الأصلية، مما قد يؤدي إلى ظهور المحتوى بشكل غير محاذٍ أو تجاوز حدود الشريحة.

يمكنك ضبط حجم شرائح العرض الهدف ليتطابق مع حجم المصدر قبل استنساخ الشريحة والشريحة الرئيسية:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

قم بذلك قبل استنساخ الشريحة الرئيسية والشريحة.

## **الأسئلة المتكررة**

**هل يتم استنساخ ملاحظات المتحدث وتعليقات المراجعين؟**

نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في النسخة المستنسخة. إذا لم ترغب بها، قم بـ[إزالتها](/slides/ar/androidjava/presentation-notes/) بعد الإدراج.

**كيف يتم التعامل مع المخططات ومصادر بياناتها؟**

يتم نسخ كائن المخطط، تنسيقه، والبيانات المضمنة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثل مصنف OLE مضمن)، يبقى هذا الارتباط محفوظًا كـ[كائن OLE](/slides/ar/androidjava/manage-ole/). بعد نقل الملف بين العروض، تحقق من توفر البيانات وسلوك التحديث.

**هل يمكنني التحكم في موضع الإدراج والأقسام للنسخة المستنسخة؟**

نعم. يمكنك إدراج النسخة في فهرس شريحة محدد ووضعها في [قسم](/slides/ar/androidjava/slide-section/) مختار. إذا لم يكن القسم الهدف موجودًا، أنشئه أولًا ثم انقل الشريحة إليه.