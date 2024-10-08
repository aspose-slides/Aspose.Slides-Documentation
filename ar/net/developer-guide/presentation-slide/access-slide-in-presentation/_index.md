---
title: الوصول إلى الشريحة في العرض التقديمي
type: docs
weight: 20
url: /ar/net/access-slide-in-presentation/
keywords: "الوصول إلى عرض PowerPoint، الوصول إلى شريحة، تعديل خصائص الشريحة، تغيير موضع الشريحة، تعيين رقم الشريحة، الفهرس، المعرف، الموضع C#، Csharp، .NET، Aspose.Slides"
description: "الوصول إلى شريحة PowerPoint بواسطة الفهرس أو المعرف أو الموضع في C# أو .NET. تعديل خصائص الشريحة"
---

تتيح لك Aspose.Slides الوصول إلى الشرائح بطريقتين: بواسطة الفهرس وبواسطة المعرف.

## **الوصول إلى الشريحة بواسطة الفهرس**

جميع الشرائح في العرض التقديمي مرتبة رقميًا بناءً على موضع الشريحة بدءًا من 0. الشريحة الأولى يمكن الوصول إليها من خلال الفهرس 0؛ الشريحة الثانية يمكن الوصول إليها من خلال الفهرس 1؛ وهكذا.

تقوم فئة Presentation، التي تمثل ملف العرض التقديمي، بتعريض جميع الشرائح كمجموعة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)). يُظهر هذا الكود C# كيفية الوصول إلى شريحة من خلال فهرسها:

```c#
// إنشاء كائن Presentation يمثل ملف العرض التقديمي
Presentation presentation = new Presentation("AccessSlides.pptx");

// الحصول على مرجع الشريحة من خلال فهرسها
ISlide slide = presentation.Slides[0];
```

## **الوصول إلى الشريحة بواسطة المعرف**

كل شريحة في العرض التقديمي لها معرف فريد مرتبط بها. يمكنك استخدام الطريقة [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) (المكشوفة من قبل فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)) لاستهداف ذلك المعرف. يُظهر هذا الكود C# كيفية توفير معرف شريحة صالح والوصول إلى تلك الشريحة من خلال الطريقة [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid):

```c#
// إنشاء كائن Presentation يمثل ملف العرض التقديمي
Presentation presentation = new Presentation("AccessSlides.pptx");

// الحصول على معرف الشريحة
uint id = presentation.Slides[0].SlideId;

// الوصول إلى الشريحة من خلال معرفها
IBaseSlide slide = presentation.GetSlideById(id);
```

## **تغيير موضع الشريحة**
تسمح لك Aspose.Slides بتغيير موضع الشريحة. على سبيل المثال، يمكنك تحديد أن الشريحة الأولى يجب أن تصبح الشريحة الثانية.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على مرجع الشريحة (التي تريد تغيير موضعها) من خلال فهرسها.
1. تعيين موضع جديد للشريحة من خلال خاصية [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/).
1. حفظ العرض التقديمي المعدل.

هذا الكود C# يوضح عملية يتم فيها نقل الشريحة في الموضع 1 إلى الموضع 2:

```c#
// إنشاء كائن Presentation يمثل ملف العرض التقديمي
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // الحصول على الشريحة التي سيتم تغيير موضعها
    ISlide sld = pres.Slides[0];

    // تعيين الموضع الجديد للشريحة
    sld.SlideNumber = 2;

    // حفظ العرض التقديمي المعدل
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```

أصبحت الشريحة الأولى هي الثانية؛ وأصبحت الشريحة الثانية هي الأولى. عندما تغير موضع الشريحة، يتم ضبط الشرائح الأخرى تلقائيًا.

## **تعيين رقم الشريحة**
باستخدام خاصية [FirstSlideNumber](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) (المكشوفة من قبل فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation))، يمكنك تعيين رقم جديد للشريحة الأولى في العرض التقديمي. تتسبب هذه العملية في إعادة حساب أرقام الشرائح الأخرى.

1. إنشاء مثيل من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. الحصول على رقم الشريحة.
1. تعيين رقم الشريحة.
1. حفظ العرض التقديمي المعدل.

هذا الكود C# يوضح عملية يتم فيها تعيين رقم الشريحة الأولى إلى 10:

```c#
// إنشاء كائن Presentation يمثل ملف العرض التقديمي
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // الحصول على رقم الشريحة
    int firstSlideNumber = presentation.FirstSlideNumber;

    // تعيين رقم الشريحة
    presentation.FirstSlideNumber=10;
    
    // حفظ العرض التقديمي المعدل
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```

إذا كنت تفضل تخطي الشريحة الأولى، يمكنك بدء الترقيم من الشريحة الثانية (وإخفاء الترقيم للشريحة الأولى) بهذه الطريقة:

```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // تعيين الرقم للشريحة الأولى في العرض التقديمي
    presentation.FirstSlideNumber = 0;

    // إظهار أرقام الشرائح لجميع الشرائح
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // إخفاء رقم الشريحة للشريحة الأولى
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // حفظ العرض التقديمي المعدل
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```