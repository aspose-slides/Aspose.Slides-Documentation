---
title: الوصول إلى شرائح العرض التقديمي في .NET
linktitle: الوصول إلى الشريحة
type: docs
weight: 20
url: /ar/net/access-slide-in-presentation/
keywords:
- الوصول إلى الشريحة
- فهرس الشريحة
- معرف الشريحة
- موضع الشريحة
- تغيير الموضع
- خصائص الشريحة
- رقم الشريحة
- PowerPoint
- OpenDocument
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "تعرّف على كيفية الوصول إلى الشرائح وإدارتها في عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لـ .NET. زد الإنتاجية بأمثلة الشيفرة."
---

Aspose.Slides يسمح لك بالوصول إلى الشرائح بطريقتين: حسب الفهرس وحسب المعرف.

## **الوصول إلى شريحة حسب الفهرس**

جميع الشرائح في العرض التقديمي مرتبة رقمياً بناءً على موضع الشريحة بدءًا من 0. الشريحة الأولى يمكن الوصول إليها عبر الفهرس 0؛ الشريحة الثانية عبر الفهرس 1؛ وما إلى ذلك.

الفئة Presentation، التي تمثل ملف عرض تقديمي، تكشف جميع الشرائح كمجموعة [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) ). يعرض هذا الكود C# كيفية الوصول إلى شريحة عبر فهرسها:
```c#
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
Presentation presentation = new Presentation("AccessSlides.pptx");

// يحصل على مرجع الشريحة من خلال فهرستها
ISlide slide = presentation.Slides[0];
```


## **الوصول إلى شريحة حسب المعرف**

كل شريحة في العرض التقديمي لها معرف فريد مرتبط بها. يمكنك استخدام طريقة [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) (المُعرَضة من قبل الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) ) لاستهداف ذلك المعرف. يعرض هذا الكود C# كيفية تقديم معرف شريحة صالح والوصول إلى تلك الشريحة من خلال طريقة [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid):
```c#
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
Presentation presentation = new Presentation("AccessSlides.pptx");

// يحصل على معرف الشريحة
uint id = presentation.Slides[0].SlideId;

// يصل إلى الشريحة عبر معرفها
IBaseSlide slide = presentation.GetSlideById(id);
```


## **تغيير موضع الشريحة**
توفر Aspose.Slides إمكانية تغيير موضع شريحة. على سبيل المثال، يمكنك تحديد أن الشريحة الأولى تصبح الشريحة الثانية.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الحصول على مرجع الشريحة (الذي تريد تغيير موضعه) عبر فهرسه
3. تعيين موضع جديد للشريحة عبر الخاصية [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/) .
4. حفظ العرض التقديمي المعدل.

يعرض هذا الكود C# عملية نقل الشريحة الموجودة في الموضع 1 إلى الموضع 2:
```c#
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // يحصل على الشريحة التي سيُغير موضعها
    ISlide sld = pres.Slides[0];

    // يحدد الموضع الجديد للشريحة
    sld.SlideNumber = 2;

    // يحفظ العرض التقديمي المعدل
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```


أصبحت الشريحة الأولى هي الثانية؛ وأصبحت الشريحة الثانية هي الأولى. عند تغيير موضع شريحة، يتم ضبط الشرائح الأخرى تلقائيًا.

## **تعيين رقم الشريحة**
باستخدام الخاصية [FirstSlideNumber](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) (المُعرَضة من قبل الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) )، يمكنك تحديد رقم جديد للشريحة الأولى في العرض التقديمي. تتسبب هذه العملية في إعادة حساب أرقام الشرائح الأخرى.

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
2. الحصول على رقم الشريحة.
3. تعيين رقم الشريحة.
4. حفظ العرض التقديمي المعدل.

يعرض هذا الكود C# عملية تعيين رقم الشريحة الأولى إلى 10:
```c#
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    // يحصل على رقم الشريحة
    int firstSlideNumber = presentation.FirstSlideNumber;

    // يحدد رقم الشريحة
    presentation.FirstSlideNumber=10;
    
    // يحفظ العرض التقديمي المعدل
    presentation.Save("Set_Slide_Number_out.pptx", SaveFormat.Pptx);
}
```


إذا كنت تفضل تخطي الشريحة الأولى، يمكنك بدء الترقيم من الشريحة الثانية (والإخفاء الترقيم للشريحة الأولى) على النحو التالي:
```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // يحدد رقم الشريحة الأولى في العرض التقديمي
    presentation.FirstSlideNumber = 0;

    // يظهر أرقام الشرائح لجميع الشرائح
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // يخفي رقم الشريحة الأولى
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // يحفظ العرض التقديمي المعدل
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**هل رقم الشريحة الذي يراه المستخدم يتطابق مع فهرس المجموعة القائم على الصفر؟**

يمكن أن يبدأ الرقم المعروض على الشريحة من قيمة عشوائية (مثل 10) ولا يجب أن يتطابق مع الفهرس؛ يتم التحكم في العلاقة بواسطة إعداد [first slide number](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) للعرض التقديمي.

**هل تؤثر الشرائح المخفية على الفهرسة؟**

نعم. الشريحة المخفية تبقى في المجموعة وتُحتسب في الفهرسة؛ "مخفي" يشير إلى العرض، وليس إلى موضعها في المجموعة.

**هل يتغير فهرس الشريحة عندما تُضاف أو تُحذف شرائح أخرى؟**

نعم. الفهارس دائماً تعكس الترتيب الحالي للشرائح وتُعاد حسابها عند عمليات الإدراج أو الحذف أو النقل.