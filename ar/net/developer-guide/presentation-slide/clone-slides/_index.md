---
title: نسخ شرائح العرض التقديمي في .NET
linktitle: نسخ الشرائح
type: docs
weight: 40
url: /ar/net/clone-slides/
keywords:
- استنساخ شريحة
- نسخ شريحة
- حفظ شريحة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استنسخ شرائح PowerPoint بسرعة باستخدام Aspose.Slides for .NET. اتبع أمثلة التعليمات البرمجية الواضحة لتلقائيًا إنشاء ملفات PPT في ثوانٍ وتجنب العمل اليدوي."
---
## **المقدمة**

عملية الاستنساخ هي عملية إنشاء نسخة مطابقة أو تكرار لشيء ما. يتيح Aspose.Slides أيضًا لك نسخ (استنساخ) أي شريحة ثم إدراج الشريحة المستنسخة في العرض التقديمي الحالي أو أي عرض تقديمي آخر مفتوح. ينتج عن استنساخ الشريحة شريحة جديدة يمكن للمطورين تعديلها دون التأثير على الشريحة الأصلية. هناك عدة طرق لاستنساخ شريحة:

- استنساخ في نهاية العرض التقديمي.
- استنساخ في موضع آخر داخل العرض التقديمي.
- استنساخ في نهاية عرض تقديمي آخر.
- استنساخ في موضع آخر في عرض تقديمي آخر.
- استنساخ مع شريحة الماستر الخاصة به إلى عرض تقديمي آخر.

في Aspose.Slides for .NET، مجموعة الشرائح (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/ar/net/aspose.slides/islide/) ) التي ي exposeها كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) توفر طريقتي [AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/addclone/) و[InsertClone](https://reference.aspose.com/slides/ar/net/aspose.slides/ishapecollection/insertclone/) لتنفيذ عمليات استنساخ الشرائح الموضحة أعلاه.

## **استنساخ شريحة في نهاية العرض التقديمي**

إذا كنت تريد استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي في نهاية الشرائح الموجودة، استخدم طريقة [AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/methods/addclone/index) وفقًا للخطوات المذكورة أدناه:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
1. أنشئ كائنًا من فئة [ISlideCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection) عن طريق الإشارة إلى مجموعة Slides التي ي exposeها كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
1. استدعِ طريقة [AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/methods/addclone/index) التي ي exposeها كائن [ISlideCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection) ومرّر الشريحة التي تريد استنساخها كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/methods/addclone/index).
1. احفظ ملف العرض التقديمي المعدل.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (تقع في الموضع الأول – الفهرس صفر – من العرض التقديمي) إلى نهاية العرض التقديمي.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // حفظ العرض التقديمي المعدل إلى القرص
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **استنساخ شريحة إلى موضع آخر داخل العرض التقديمي**

إذا كنت تريد استنساخ شريحة ثم استخدامها داخل نفس ملف العرض التقديمي ولكن في موضع مختلف، استخدم طريقة [InsertClone](https://reference.aspose.com/slides/ar/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
1. أنشئ كائنًا من فئة **Slides** التي ي exposeها كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation).
1. استدعِ طريقة [InsertClone](https://reference.aspose.com/slides/ar/net/aspose.slides.ishapecollection/insertclone/methods/1) التي ي exposeها كائن [ISlideCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection) ومرّر الشريحة التي تريد استنساخها مع الفهرس للموضع الجديد كمعامل إلى طريقة [InsertClone](https://reference.aspose.com/slides/ar/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. احفظ العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (تقع في الفهرس 1 – الموضع 2 – من العرض التقديمي) إلى الفهرس 2 – الموضع 3 – من العرض التقديمي.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    ISlideCollection slds = pres.Slides;

    // استنساخ الشريحة المطلوبة إلى الفهرس المحدد في نفس العرض التقديمي
    slds.InsertClone(2, pres.Slides[1]);

    // حفظ العرض التقديمي المعدل إلى القرص
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **استنساخ شريحة في نهاية عرض تقديمي آخر**

إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واستخدامها في ملف عرض تقديمي آخر، في نهاية الشرائح الموجودة:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) يحتوي على العرض الذي سيتم استنساخ الشريحة منه.
1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) يحتوي على العرض الهدف الذي ستتم إضافة الشريحة إليه.
1. أنشئ كائنًا من فئة [ISlideCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection) عن طريق الإشارة إلى مجموعة **Slides** التي ي exposeها كائن Presentation للعرض الهدف.
1. استدعِ طريقة [AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/methods/addclone/index) التي ي exposeها كائن [ISlideCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection) ومرّر الشريحة من العرض المصدر كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/methods/addclone/index).
1. احفظ ملف العرض الهدف المعدل.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (من الفهرس الأول للعرض المصدر) إلى نهاية العرض الهدف.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // إنشاء كائن من فئة Presentation لملف PPTX الوجهة (حيث سيتم استنساخ الشريحة)
    using (Presentation destPres = new Presentation())
    {
        // استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الوجهة
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // حفظ العرض التقديمي الوجهة إلى القرص
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **استنساخ شريحة إلى موضع آخر في عرض تقديمي آخر**

إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واستخدامها في ملف عرض تقديمي آخر، في موضع محدد:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) يحتوي على العرض المصدر الذي ستستنسخ منه الشريحة.
1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) يحتوي على العرض الذي ستتم إضافة الشريحة إليه.
1. أنشئ كائنًا من فئة [ISlideCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection) عن طريق الإشارة إلى مجموعة Slides التي ي exposeها كائن Presentation للعرض الهدف.
1. استدعِ طريقة [InsertClone](https://reference.aspose.com/slides/ar/net/aspose.slides.ishapecollection/insertclone/methods/1) التي ي exposeها كائن [ISlideCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection) ومرّر الشريحة من العرض المصدر مع الموضع المطلوب كمعامل إلى طريقة [InsertClone](https://reference.aspose.com/slides/ar/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. احفظ ملف العرض الهدف المعدل.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (من الفهرس صفر للعرض المصدر) إلى الفهرس 1 (الموضع 2) للعرض الهدف.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // إنشاء كائن من فئة Presentation لملف PPTX الوجهة (حيث سيتم استنساخ الشريحة)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // حفظ العرض التقديمي الوجهة إلى القرص
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **استنساخ شريحة مع شريحة الماستر الخاصة بها إلى عرض تقديمي آخر**

إذا كنت بحاجة إلى استنساخ شريحة مع شريحة ماسترك من عرض تقديمي واستخدامها في عرض تقديمي آخر، يجب أولاً استنساخ شريحة الماستر المطلوبة من العرض المصدر إلى العرض الهدف. ثم تحتاج إلى استخدام تلك شريحة الماستر لاستنساخ الشريحة مع الماستر. طريقة **AddClone(ISlide, IMasterSlide)** تتوقع شريحة ماستر من العرض الهدف وليس من العرض المصدر. لاستنساخ الشريحة مع ماستر، يرجى اتباع الخطوات التالية:

1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) يحتوي على العرض المصدر الذي ستستنسخ منه الشريحة.
1. أنشئ مثيلاً من فئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) يحتوي على العرض الهدف الذي ستستنسخ إليه الشريحة.
1. الوصول إلى الشريحة التي سيتم استنساخها مع شريحة الماستر.
1. أنشئ كائنًا من فئة [IMasterSlideCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslidecollection) عن طريق الإشارة إلى مجموعة Masters التي ي exposeها كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) للعرض الهدف.
1. استدعِ طريقة [AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/methods/addclone/index) التي ي exposeها كائن [IMasterSlideCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/imasterslidecollection) ومرّر الماستر من ملف PPTX المصدر لاستنساخه كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/methods/addclone/index).
1. أنشئ كائنًا من فئة [ISlideCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection) عن طريق ضبط المرجع إلى مجموعة Slides التي ي exposeها كائن [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation) للعرض الهدف.
1. استدعِ طريقة [AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/methods/addclone/index) التي ي exposeها كائن [ISlideCollection](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection) ومرّر الشريحة من العرض المصدر لاستنساخها مع شريحة الماستر كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/methods/addclone/index).
1. احفظ ملف العرض الهدف المعدل.

في المثال المعطى أدناه، قمنا باستنساخ شريحة مع ماستر (تقع في الفهرس صفر للعرض المصدر) إلى نهاية العرض الهدف باستخدام ماستر من الشريحة المصدر.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // إنشاء كائن من فئة Presentation للعرض التقديمي الوجهة (حيث سيتم استنساخ الشريحة)
    using (Presentation destPres = new Presentation())
    {

        // إنشاء كائن ISlide من مجموعة الشرائح في العرض التقديمي المصدر مع
        // شريحة ماستر
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // استنساخ شريحة الماستر المطلوبة من العرض التقديمي المصدر إلى مجموعة الماسترات في الـ
        // العرض التقديمي الوجهة
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // استنساخ شريحة الماستر المطلوبة من العرض التقديمي المصدر إلى مجموعة الماسترات في الـ
        // العرض التقديمي الوجهة
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // استنساخ الشريحة المطلوبة من العرض التقديمي المصدر مع الماستر المطلوب إلى نهاية
        // مجموعة الشرائح في العرض التقديمي الوجهة
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // استنساخ شريحة الماستر المطلوبة من العرض التقديمي المصدر إلى مجموعة الماسترات في الـ // العرض التقديمي الوجهة
        // حفظ العرض التقديمي الوجهة إلى القرص
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **استنساخ شريحة في نهاية القسم المحدد**

مع Aspose.Slides for .NET، يمكنك استنساخ شريحة من قسم من العرض وإدراج تلك الشريحة في قسم آخر داخل نفس العرض. في هذه الحالة، يجب استخدام طريقة [AddClone](https://reference.aspose.com/slides/ar/net/aspose.slides/islidecollection/methods/addclone/index) من واجهة [ISlideCollection].

يوضح لك هذا الكود C# كيفية استنساخ شريحة وإدراج الشريحة المستنسخة في قسم محدد:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // للاستنساخ
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **تأكد من تطابق حجم الشريحة**

عند استنساخ الشرائح إلى عرض آخر، تأكد من أن حجم العرض الهدف يطابق حجم العرض المصدر. إذا اختلف حجم الشرائح، لا يقوم Aspose.Slides تلقائيًا بإعادة تحجيم الأشكال المستنسخة—تظل إحداثياتها وأبعادها الأصلية محفوظة، مما قد يؤدي إلى ظهور المحتوى غير محاذٍ أو امتداده خارج حدود الشريحة.

يمكنك ضبط حجم شرائح العرض الهدف لمطابقة المصدر قبل استنساخ الماستر والشريحة:

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

قم بذلك قبل استنساخ الماستر والشريحة.

## **الأسئلة الشائعة**

**هل يتم استنساخ ملاحظات المتحدث وتعليقات المراجعين؟**

نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في النسخة المستنسخة. إذا لم ترغب بها، [إزالتها](/slides/ar/net/presentation-notes/) بعد الإدراج.

**كيف يتم التعامل مع المخططات ومصادر بياناتها؟**

يتم نسخ كائن المخطط والتنسيق والبيانات المضمنة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثل مصنف OLE مضمن)، يتم الحفاظ على هذا الارتباط كـ [كائن OLE](/slides/ar/net/manage-ole/). بعد النقل بين الملفات، تحقق من توفر البيانات وسلوك التحديث.

**هل يمكنني التحكم في موضع الإدراج والأقسام للنسخة المستنسخة؟**

نعم. يمكنك إدراج النسخة المستنسخة عند فهرس شريحة محدد ووضعها في [القسم](/slides/ar/net/slide-section/) المختار. إذا لم يكن القسم الهدف موجودًا، أنشئه أولًا ثم انقل الشريحة إليه.