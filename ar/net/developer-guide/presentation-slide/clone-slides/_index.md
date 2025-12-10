---
title: استنساخ شرائح العرض التقديمي في .NET
linktitle: استنساخ الشرائح
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
description: "قم بتكرار شرائح PowerPoint بسرعة باستخدام Aspose.Slides لـ .NET. اتبع أمثلتنا الواضحة في الشيفرة لأتمتة إنشاء ملفات PPT في ثوانٍ وإزالة العمل اليدوي."
---

## **استنساخ الشرائح في عرض تقديمي**
الاستنساخ هو عملية إنشاء نسخة دقيقة أو مكرر لشيء ما. Aspose.Slides for .NET تجعل من الممكن أيضًا إنشاء نسخة أو استنساخ لأي شريحة ثم إدراج تلك الشريحة المستنسخة إلى العرض الحالي أو أي عرض آخر مفتوح. عملية استنساخ الشرائح تنشئ شريحة جديدة يمكن للمطورين تعديلها دون تغيير الشريحة الأصلية. هناك عدة طرق ممكنة لاستنساخ الشريحة:

- استنساخ في النهاية داخل عرض تقديمي.
- استنساخ في موضع آخر داخل العرض.
- استنساخ في النهاية في عرض تقديمي آخر.
- استنساخ في موضع آخر في عرض تقديمي آخر.
- استنساخ في موضع محدد في عرض تقديمي آخر.

في Aspose.Slides for .NET، (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)) التي يعرّفها كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) توفر طرق [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) و[InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) لتنفيذ أنواع استنساخ الشرائح المذكورة أعلاه
## **استنساخ شريحة في نهاية عرض تقديمي**
إذا كنت تريد استنساخ شريحة ثم استخدامها داخل نفس ملف العرض في نهاية الشرائح الموجودة، استخدم طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) وفقًا للخطوات المذكورة أدناه:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. إنشاء كائن من فئة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) بالإشارة إلى مجموعة Slides التي يعرّفها كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. استدعاء طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) التي يعرّفها كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمرير الشريحة المراد استنساخها كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. حفظ ملف العرض المعدَّل.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (تقع في الموضع الأول – الفهرس صفر – من العرض) إلى نهاية العرض.
```c#
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // كتابة العرض التقديمي المعدل إلى القرص
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```


## **استنساخ شريحة إلى موضع آخر داخل عرض تقديمي**
إذا كنت تريد استنساخ شريحة ثم استخدامها داخل نفس ملف العرض ولكن في موضع مختلف، استخدم طريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. إنشاء كائن بالإشارة إلى مجموعة **Slides** التي يعرّفها كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. استدعاء طريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) التي يعرّفها كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمرير الشريحة المراد استنساخها مع الفهرس للموضع الجديد كمعامل إلى طريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. حفظ العرض المعدَّل كملف PPTX.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (تقع في الفهرس صفر – الموضع 1 – من العرض) إلى الفهرس 1 – الموضع 2 – من العرض.
```c#
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    ISlideCollection slds = pres.Slides;

    // استنساخ الشريحة المطلوبة إلى الفهرس المحدد في نفس العرض التقديمي
    slds.InsertClone(2, pres.Slides[1]);

    // كتابة العرض التقديمي المعدل إلى القرص
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```


## **استنساخ شريحة في نهاية عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة من عرض تقديمي واستخدامها في ملف عرض تقديمي آخر، في نهاية الشرائح الموجودة:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على العرض الذي ستُستنسَخ منه الشريحة.
1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على العرض الوجهة الذي ستُضاف إليه الشريحة.
1. إنشاء كائن من فئة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) بالإشارة إلى مجموعة **Slides** التي يعرّفها كائن Presentation للعرض الوجهة.
1. استدعاء طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) التي يعرّفها كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمرير الشريحة من العرض المصدر كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. حفظ ملف العرض الوجهة المعدَّل.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (من الفهرس الأول للعرض المصدر) إلى نهاية العرض الوجهة.
```c#
// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // إنشاء كائن من فئة Presentation للملف PPTX الوجهة (حيث ستُستنسخ الشريحة)
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

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على العرض المصدر الذي ستُستنسَخ منه الشريحة.
1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي سيُضاف إليها الشريحة.
1. إنشاء كائن من فئة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) بالإشارة إلى مجموعة Slides التي يعرّفها كائن Presentation للعرض الوجهة.
1. استدعاء طريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) التي يعرّفها كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمرير الشريحة من العرض المصدر مع الموضع المرغوب كمعامل إلى طريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. حفظ ملف العرض الوجهة المعدَّل.

في المثال المعطى أدناه، قمنا باستنساخ شريحة (من الفهرس صفر للعرض المصدر) إلى الفهرس 1 (الموضع 2) للعرض الوجهة.
```c#
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


## **استنساخ شريحة في موضع محدد في عرض تقديمي آخر**
إذا كنت بحاجة إلى استنساخ شريحة مع شريحة رئيسية من عرض تقديمي واستخدامها في عرض تقديمي آخر، يجب أولاً استنساخ الشريحة الرئيسية المطلوبة من العرض المصدر إلى العرض الوجهة. ثم تحتاج إلى استخدام تلك الشريحة الرئيسية لاستنساخ الشريحة ذات الشريحة الرئيسية. طريقة **AddClone(ISlide, IMasterSlide)** تتوقع شريحة رئيسية من العرض الوجهة وليس من المصدر. لاستنساخ الشريحة مع رئيس، يرجى اتباع الخطوات التالية:

1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على العرض المصدر الذي ستُستنسَخ منه الشريحة.
1. إنشاء نسخة من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على العرض الوجهة الذي ستُستنسَخ إليه الشريحة.
1. الوصول إلى الشريحة المراد استنساخها مع الشريحة الرئيسية.
1. إنشاء كائن من فئة [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) بالإشارة إلى مجموعة Masters التي يعرّفها كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) للعرض الوجهة.
1. استدعاء طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) التي يعرّفها كائن [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) وتمرير الشريحة الرئيسية من ملف PPTX المصدر ليتم استنساخها كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. إنشاء كائن من فئة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) عبر تعيين الإشارة إلى مجموعة Slides التي يعرّفها كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) للعرض الوجهة.
1. استدعاء طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) التي يعرّفها كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمرير الشريحة من العرض المصدر ليتم استنساخها مع الشريحة الرئيسية كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. حفظ ملف العرض الوجهة المعدَّل.

في المثال المعطى أدناه، قمنا باستنساخ شريحة مع رئيس (تقع في الفهرس صفر للعرض المصدر) إلى نهاية العرض الوجهة باستخدام رئيس من الشريحة المصدر.
```c#
// إنشاء كائن من فئة Presentation لتحميل ملف العرض التقديمي المصدر

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // إنشاء كائن من فئة Presentation للعرض التقديمي الوجهة (حيث سيتم استنساخ الشريحة)
    using (Presentation destPres = new Presentation())
    {

        // إنشاء ISlide من مجموعة الشرائح في العرض التقديمي المصدر مع
        // الشريحة الرئيسية
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الشرائح الرئيسية في الـ
        // العرض التقديمي الوجهة
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الشرائح الرئيسية في الـ
        // العرض التقديمي الوجهة
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // استنساخ الشريحة المطلوبة من العرض التقديمي المصدر مع الشريحة الرئيسية المطلوبة إلى نهاية الـ
        // مجموعة الشرائح في العرض التقديمي الوجهة
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // استنساخ الشريحة الرئيسية المطلوبة من العرض التقديمي المصدر إلى مجموعة الشرائح الرئيسية في الـ // العرض التقديمي الوجهة
        // حفظ العرض التقديمي الوجهة إلى القرص
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```


## **استنساخ شريحة في نهاية قسم محدد**
مع Aspose.Slides for .NET، يمكنك استنساخ شريحة من قسم في عرض تقديمي وإدراجها في قسم آخر داخل نفس العرض. في هذه الحالة، يجب عليك استخدام طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) من واجهة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection).

هذا الكود C# يوضح لك كيفية استنساخ شريحة وإدراج الشريحة المستنسخة في قسم محدد:
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // لاستنساخ
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);
    pres.Slides.AddClone(slide, section);
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**هل يتم استنساخ ملاحظات المتحدث وتعليقات المراجعين؟**  
نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في الاستنساخ. إذا لم ترغب فيها، [قم بإزالتها](/slides/ar/net/presentation-notes/) بعد الإدراج.

**كيف يتم التعامل مع المخططات ومصادر بياناتها؟**  
يتم نسخ كائن المخطط وتنسيقه والبيانات المدمجة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثل دفتر عمل مضمن OLE)، يتم الحفاظ على ذلك الارتباط كـ [كائن OLE](/slides/ar/net/manage-ole/). بعد النقل بين الملفات، تحقق من توفر البيانات وسلوك التحديث.

**هل يمكنني التحكم في موضع الإدراج والأقسام للاستنساخ؟**  
نعم. يمكنك إدراج الاستنساخ عند فهرس شريحة محدد ووضعه في [قسم](/slides/ar/net/slide-section/) مختار. إذا لم يكن القسم المستهدف موجودًا، أنشئه أولاً ثم انقل الشريحة إليه.