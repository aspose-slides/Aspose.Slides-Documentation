---
title: نسخ الشرائح
type: docs
weight: 40
url: /net/clone-slides/
keywords: "نسخ شريحة, نسخ شريحة, حفظ نسخة الشريحة, PowerPoint, تقديم, C#, Csharp, .NET, Aspose.Slides"
description: "نسخ شريحة PowerPoint في C# أو .NET"
---

## **نسخ الشرائح في التقديم**
النسخ هو عملية إنشاء نسخة مطابقة تمامًا أو تكرار لشيء ما. تتيح Aspose.Slides لـ .NET أيضًا إمكانية عمل نسخة أو تكرار لأي شريحة ثم إدراج تلك الشريحة المكررة في التقديم الحالي أو أي تقديم آخر مفتوح. عملية نسخ الشريحة تنشئ شريحة جديدة يمكن تعديلها بواسطة المطورين دون تغيير الشريحة الأصلية. هناك عدة طرق ممكنة لنسخ شريحة:

- نسخ في النهاية داخل التقديم.
- نسخ في موضع آخر داخل التقديم.
- نسخ في النهاية في تقديم آخر.
- نسخ في موضع آخر في تقديم آخر.
- نسخ في موضع محدد في تقديم آخر.

في Aspose.Slides لـ .NET، (مجموعة من [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide) كائنات) التي يكشف عنها كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) تقدم طرق [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) و [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) لتنفيذ أنواع النسخ المذكورة أعلاه
## **نسخ في النهاية داخل التقديم**
إذا كنت تريد نسخ شريحة ثم استخدامها داخل نفس ملف التقديم في نهاية الشرائح الموجودة، استخدم طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) وفقًا للخطوات المذكورة أدناه:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. إنشاء مثيل لفئة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) عن طريق الإشارة إلى مجموعة الشرائح التي يكشف عنها كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. استدعاء طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) التي يكشف عنها كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمرير الشريحة المراد نسخها كمعلمة إلى طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. كتابة ملف التقديم المعدل.

في المثال المعطى أدناه، قمنا بنسخ شريحة (تقع في الموضع الأول - فهرس صفر - من التقديم) إلى نهاية التقديم.

```c#
// إنشاء مثيل لفئة Presentation التي تمثل ملف تقديم
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // نسخ الشريحة المرغوبة إلى نهاية مجموعة الشرائح في نفس التقديم
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // كتابة التقديم المعدل على القرص
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```


## **نسخ في موضع آخر داخل التقديم**
إذا كنت تريد نسخ شريحة ثم استخدامها داخل نفس ملف التقديم ولكن في موضع مختلف، استخدم طريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1):

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. إنشاء مثيل للفئة عن طريق الإشارة إلى مجموعة **Slides** التي يكشف عنها كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. استدعاء طريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) التي يكشف عنها كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمرير الشريحة المراد نسخها مع الفهرس للموقع الجديد كمعلمة لطريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. كتابة التقديم المعدل كملف PPTX.

في المثال المعطى أدناه، قمنا بنسخ شريحة (تقع في فهرس صفر - الموضع 1 - من التقديم) إلى الفهرس 1 - الموضع 2 - من التقديم.

```c#
// إنشاء مثيل لفئة Presentation التي تمثل ملف تقديم
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // نسخ الشريحة المرغوبة إلى نهاية مجموعة الشرائح في نفس التقديم
    ISlideCollection slds = pres.Slides;

    // نسخ الشريحة المرغوبة إلى الفهرس المحدد في نفس التقديم
    slds.InsertClone(2, pres.Slides[1]);

    // كتابة التقديم المعدل على القرص
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```


## **نسخ في النهاية في تقديم آخر**
إذا كنت بحاجة إلى نسخ شريحة من تقديم واحد واستخدامها في ملف تقديم آخر، في نهاية الشرائح الموجودة:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على التقديم الذي ستنسخ منه الشريحة.
1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على التقديم الوجهة التي ستضاف إليها الشريحة.
1. إنشاء مثيل لفئة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) عن طريق الإشارة إلى مجموعة **Slides** التي يكشف عنها كائن Presentation الخاص بالتقديم الوجهة.
1. استدعاء طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) التي يكشف عنها كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمرير الشريحة من التقديم المصدر كمعلمة لطريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. كتابة ملف التقديم المعدل الوجهة.

في المثال المعطى أدناه، قمنا بنسخ شريحة (من الفهرس الأول من التقديم المصدر) إلى نهاية التقديم الوجهة.

```c#
// إنشاء مثيل لفئة Presentation لتحميل ملف التقديم المصدر
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // إنشاء مثيل لفئة Presentation لملف PPTX الوجهة (حيث سيتم نسخ الشريحة)
    using (Presentation destPres = new Presentation())
    {
        // نسخ الشريحة المرغوبة من التقديم المصدر إلى نهاية مجموعة الشرائح في التقديم الوجهة
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // كتابة التقديم الوجهة على القرص
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **نسخ في موضع آخر في تقديم آخر**
إذا كنت بحاجة إلى نسخ شريحة من تقديم واحد واستخدامها في ملف تقديم آخر، في موضع محدد:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على التقديم المصدر الذي ستنسخ منه الشريحة.
1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على التقديم الذي ستضاف إليه الشريحة.
1. إنشاء مثيل لفئة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) عن طريق الإشارة إلى مجموعة الشرائح التي يكشف عنها كائن Presentation الخاص بالتقديم الوجهة.
1. استدعاء طريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1) التي يكشف عنها كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمرير الشريحة من التقديم المصدر مع الموقع المطلوب كمعلمة لطريقة [InsertClone](https://reference.aspose.com/slides/net/aspose.slides.ishapecollection/insertclone/methods/1).
1. كتابة ملف التقديم المعدل الوجهة.

في المثال المعطى أدناه، قمنا بنسخ شريحة (من الفهرس صفر من التقديم المصدر) إلى الفهرس 1 (الموضع 2) من التقديم الوجهة.

```c#
// إنشاء مثيل لفئة Presentation لتحميل ملف التقديم المصدر
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // إنشاء مثيل لفئة Presentation لملف PPTX الوجهة (حيث سيتم نسخ الشريحة)
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // كتابة التقديم الوجهة على القرص
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```


## **نسخ في موضع محدد في تقديم آخر**
إذا كنت بحاجة إلى نسخ شريحة مع شريحة رئيسية من تقديم واحد واستخدامها في تقديم آخر، تحتاج إلى نسخ الشريحة الرئيسية المطلوبة من التقديم المصدر إلى التقديم الوجهة أولاً. ثم تحتاج إلى استخدام هذه الشريحة الرئيسية لنسخ الشريحة مع الشريحة الرئيسية. تتوقع طريقة **AddClone(ISlide, IMasterSlide)** شريحة رئيسية من التقديم الوجهة بدلاً من التقديم المصدر. من أجل نسخ الشريحة مع الرئيسية، يرجى اتباع الخطوات أدناه:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على التقديم المصدر الذي ستنسخ منه الشريحة.
1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) التي تحتوي على التقديم الوجهة التي ستنسخ إليها.
1. الوصول إلى الشريحة المراد نسخها مع الشريحة الرئيسية.
1. إنشاء مثيل لفئة [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) عن طريق الإشارة إلى مجموعة الماستر التي تكشف عنها كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) الخاص بالتقديم الوجهة.
1. استدعاء طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) التي يكشف عنها كائن [IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) وتمرير الماستر من ملف التقديم المصدر الذي سيتم نسخه كمعلمة لطريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. إنشاء مثيل لفئة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) عن طريق تعيين الإشارة إلى مجموعة الشرائح التي يكشف عنها كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) الخاص بالتقديم الوجهة.
1. استدعاء طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) التي يكشف عنها كائن [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) وتمرير الشريحة من التقديم المصدر التي سيتم نسخها وماستر الشريحة كمعلمة لطريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index).
1. كتابة ملف التقديم المعدل الوجهة.

في المثال المعطى أدناه، قمنا بنسخ شريحة مع شريحة رئيسية (تقع في الفهرس صفر من التقديم المصدر) إلى نهاية التقديم الوجهة باستخدام شريحة رئيسية من الشريحة المصدر.

```c#
// إنشاء مثيل لفئة Presentation لتحميل ملف التقديم المصدر

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // إنشاء مثيل لفئة Presentation للتقديم الوجهة (حيث سيتم نسخ الشريحة)
    using (Presentation destPres = new Presentation())
    {

        // إنشاء ISlide من مجموعة الشرائح في التقديم المصدر مع
        // الشريحة الرئيسية
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // نسخ الشريحة الرئيسية المطلوبة من التقديم المصدر إلى مجموعة الماستر في
        // التقديم الوجهة
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // نسخ الشريحة الرئيسية المطلوبة من التقديم المصدر إلى مجموعة الماستر في
        // التقديم الوجهة
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // نسخ الشريحة المطلوبة من التقديم المصدر مع الشريحة الرئيسية المطلوبة إلى نهاية
        // مجموعة الشرائح في التقديم الوجهة
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // نسخ الشريحة الرئيسية المطلوبة من التقديم المصدر إلى مجموعة الماستر في التقديم الوجهة
        // حفظ التقديم الوجهة على القرص
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```



## نسخ في النهاية في قسم محدد

مع Aspose.Slides لـ .NET، يمكنك نسخ شريحة من قسم واحد من التقديم وإدراج تلك الشريحة في قسم آخر في نفس التقديم. في هذه الحالة، يجب عليك استخدام طريقة [AddClone](https://reference.aspose.com/slides/net/aspose.slides/islidecollection/methods/addclone/index) من واجهة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection). 

يوضح لك هذا الكود C# كيفية نسخ شريحة وإدراج الشريحة المنسوخة في قسم محدد:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // للنسخ
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```