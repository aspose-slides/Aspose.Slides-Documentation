---
title: استنساخ الشرائح
type: docs
weight: 40
url: /ar/net/clone-slides/
keywords: "استنساخ شريحة, نسخ شريحة, حفظ نسخة شريحة, PowerPoint, عرض تقديمي, C#, Csharp, .NET, Aspose.Slides"
description: "استنساخ شريحة PowerPoint في C# أو .NET"
---

## **استنساخ الشرائح في العرض التقديمي**
الاستنساخ هو عملية إنشاء نسخة مطابقة أو مكررة من شيء ما. يتيح Aspose.Slides for .NET أيضًا إمكانية إنشاء نسخة أو استنساخ لأي شريحة ثم إدراج تلك الشريحة المستنسخة في العرض التقديمي الحالي أو أي عرض تقديمي آخر مفتوح. عملية استنساخ الشريحة تُنشئ شريحة جديدة يمكن للمطورين تعديلها دون تغيير الشريحة الأصلية. هناك عدة طرق محتملة لاستنساخ شريحة:

- استنساخ في النهاية داخل عرض تقديمي.
- استنساخ في موضع آخر داخل عرض تقديمي.
- استنساخ في النهاية في عرض تقديمي آخر.
- استنساخ في موضع آخر في عرض تقديمي آخر.
- استنساخ في موضع محدد في عرض تقديمي آخر.

في Aspose.Slides for .NET، (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide)) التي يُعرّفها كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) توفر طريقتي [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) و[InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) لتنفيذ الأنواع المذكورة أعلاه من استنساخ الشرائح
## **استنساخ في النهاية داخل عرض تقديمي**
إذا رغبت في استنساخ شريحة ثم استخدامها ضمن نفس ملف العرض التقديمي في نهاية الشرائح الموجودة، استخدم طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) وفقًا للخطوات المذكورة أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. إنشاء كائن من فئة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) بالإشارة إلى مجموعة Slides التي يُعرّفها كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. استدعاء طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) التي يُعرّفها كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمرير الشريحة المراد استنساخها كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. كتابة ملف العرض التقديمي المعدل.

في المثال المعطى أدناه، استنساخنا شريحة (تقع في الموضع الأول – الفهرس صفر – للعرض التقديمي) إلى نهاية العرض التقديمي.
```c#
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // استنساخ الشريحة المطلوبة إلى نهاية مجموعة الشرائح في نفس العرض التقديمي
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // كتابة العرض التقديمي المعدل إلى القرص
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```



## **استنساخ في موضع آخر داخل عرض تقديمي**
إذا رغبت في استنساخ شريحة ثم استخدامها ضمن نفس ملف العرض التقديمي ولكن في موضع مختلف، استخدم طريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. إنشاء الكائن بالإشارة إلى مجموعة **Slides** التي يُعرّفها كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. استدعاء طريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) التي يُعرّفها كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمرير الشريحة المراد استنساخها مع الفهرس للموضع الجديد كمعامل إلى طريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. كتابة العرض التقديمي المعدل كملف PPTX.

في المثال المعطى أدناه، استنساخنا شريحة (تقع في الفهرس صفر – الموضع 1 – للعرض التقديمي) إلى الفهرس 1 – الموضع 2 – للعرض التقديمي.
```c#
 // إنشاء فئة Presentation التي تمثل ملف عرض تقديمي
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



## **استنساخ في النهاية في عرض تقديمي آخر**
إذا احتجت إلى استنساخ شريحة من عرض تقديمي واستخدامها في ملف عرض تقديمي آخر، في نهاية الشرائح الموجودة:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) يحتوي على العرض التقديمي الذي ستُستنسخ منه الشريحة.
1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) يحتوي على العرض التقديمي الوجهة التي ستُضاف إليها الشريحة.
1. إنشاء كائن من فئة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) بالإشارة إلى مجموعة **Slides** التي يُعرّفها كائن Presentation للعرض التقديمي الوجهة.
1. استدعاء طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) التي يُعرّفها كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمرير الشريحة من العرض التقديمي المصدر كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. كتابة ملف العرض التقديمي الوجهة المعدل.

في المثال المعطى أدناه، استنساخنا شريحة (من الفهرس الأول للعرض التقديمي المصدر) إلى نهاية العرض التقديمي الوجهة.
```c#
 // إنشاء فئة Presentation لتحميل ملف العرض التقديمي المصدر
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // إنشاء فئة Presentation لملف PPTX الوجهة (حيث سيتم استنساخ الشريحة)
    using (Presentation destPres = new Presentation())
    {
        // استنساخ الشريحة المطلوبة من العرض التقديمي المصدر إلى نهاية مجموعة الشرائح في العرض التقديمي الوجهة
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // كتابة العرض التقديمي الوجهة إلى القرص
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```



## **استنساخ في موضع آخر في عرض تقديمي آخر**
إذا احتجت إلى استنساخ شريحة من عرض تقديمي واستخدامها في ملف عرض تقديمي آخر، في موضع محدد:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) يحتوي على العرض التقديمي المصدر الذي ستُستنسخ منه الشريحة.
1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) يحتوي على العرض التقديمي الذي ستُضاف إليه الشريحة.
1. إنشاء كائن من فئة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) بالإشارة إلى مجموعة Slides التي يُعرّفها كائن Presentation للعرض التقديمي الوجهة.
1. استدعاء طريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) التي يُعرّفها كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمرير الشريحة من العرض التقديمي المصدر مع الموضع المطلوب كمعامل إلى طريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. كتابة ملف العرض التقديمي الوجهة المعدل.

في المثال المعطى أدناه، استنساخنا شريحة (من الفهرس صفر للعرض التقديمي المصدر) إلى الفهرس 1 (الموضع 2) للعرض التقديمي الوجهة.
```c#
// إنشاء فئة Presentation لتحميل ملف العرض التقديمي المصدر
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // إنشاء فئة Presentation لملف PPTX الوجهة (حيث سيتم استنساخ الشريحة)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // كتابة العرض التقديمي الوجهة إلى القرص
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```



## **استنساخ في موضع محدد في عرض تقديمي آخر**
إذا احتجت إلى استنساخ شريحة مع شريحة رئيسية من عرض تقديمي واستخدامها في عرض تقديمي آخر، يجب أولًا استنساخ الشريحة الرئيسية المطلوبة من العرض المصدر إلى العرض الوجهة. ثم استخدم تلك الشريحة الرئيسية لاستنساخ الشريحة مع الشريحة الرئيسية. تتوقع طريقة **AddClone(ISlide, IMasterSlide)** شريحة رئيسية من العرض الوجهة بدلاً من العرض المصدر. لاستنساخ الشريحة مع الرئيسية، يرجى اتباع الخطوات أدناه:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) يحتوي على العرض التقديمي المصدر الذي ستُستنسخ منه الشريحة.
1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) يحتوي على العرض التقديمي الوجهة التي ستُستنسخ إليها الشريحة.
1. الوصول إلى الشريحة المراد استنساخها مع الشريحة الرئيسية.
1. إنشاء كائن من فئة [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) بالإشارة إلى مجموعة Masters التي يُعرّفها كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) للعرض الوجهة.
1. استدعاء طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) التي يُعرّفها كائن [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) وتمرير الشريحة الرئيسية من ملف PPTX المصدر لتُستنسخ كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. إنشاء كائن من فئة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) بضبط الإشارة إلى مجموعة Slides التي يُعرّفها كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) للعرض الوجهة.
1. استدعاء طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) التي يُعرّفها كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمرير الشريحة من العرض المصدر لتُستنسخ مع الشريحة الرئيسية كمعامل إلى طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. كتابة ملف العرض التقديمي الوجهة المعدل.

في المثال المعطى أدناه، استنساخنا شريحة مع رئيسية (تقع في الفهرس صفر للعرض المصدر) إلى نهاية العرض الوجهة باستخدام رئيسية من الشريحة المصدر.
```c#
// إنشاء فئة Presentation لتحميل ملف العرض التقديمي المصدر

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // إنشاء فئة Presentation للعرض التقديمي الوجهة (حيث سيتم استنساخ الشريحة)
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




## **استنساخ في النهاية في قسم محدد**

مع Aspose.Slides for .NET، يمكنك استنساخ شريحة من قسم في عرض تقديمي وإدراج تلك الشريحة في قسم آخر داخل نفس العرض. في هذه الحالة، يجب استخدام طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) من واجهة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection).

هذا الكود بلغة C# يوضح كيفية استنساخ شريحة وإدراج الشريحة المستنسخة في قسم محدد:
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

نعم. يتم تضمين صفحة الملاحظات وتعليقات المراجعة في النسخة المستنسخة. إذا كنت لا تريدها، [قم بإزالتها](/slides/ar/net/presentation-notes/) بعد الإدراج.

**كيف يتم التعامل مع المخططات ومصادر بياناتها؟**

يتم نسخ كائن المخطط، التنسيق، والبيانات المدمجة. إذا كان المخطط مرتبطًا بمصدر خارجي (مثل مصنف OLE مدمج)، يتم الحفاظ على هذا الارتباط كـ [كائن OLE](/slides/ar/net/manage-ole/). بعد النقل بين الملفات، تحقق من توفر البيانات وسلوك التحديث.

**هل يمكن التحكم في موضع الإدراج والأقسام للنسخة المستنسخة؟**

نعم. يمكنك إدراج النسخة في فهرس شريحة محدد ووضعها في [قسم](/slides/ar/net/slide-section/) مختار. إذا لم يكن القسم الهدف موجودًا، أنشئه أولاً ثم انقل الشريحة إليه.