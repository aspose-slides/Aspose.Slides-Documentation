---
title: "الوصول إلى الشريحة في العرض التقديمي"
type: docs
weight: 20
url: /ar/net/access-slide-in-presentation/
keywords: "الوصول إلى عرض PowerPoint, الوصول إلى الشريحة, تحرير خصائص الشريحة, تغيير موضع الشريحة, تعيين رقم الشريحة, الفهرس, المعرّف, الموضع, C#, Csharp, .NET, Aspose.Slides"
description: "الوصول إلى شريحة PowerPoint عبر الفهرس أو المعرف أو الموضع في C# أو .NET. تحرير خصائص الشريحة"
---

Aspose.Slides تتيح لك الوصول إلى الشرائح بطريقتين: حسب الفهرس أو حسب المعرف.

## **Access Slide by Index**
## **الوصول إلى الشريحة حسب الفهرس**

جميع الشرائح في العرض التقديمي مرتبة رقمياً بناءً على موضع الشريحة بدءاً من 0. الشريحة الأولى يمكن الوصول إليها عبر الفهرس 0؛ والشريحة الثانية يمكن الوصول إليها عبر الفهرس 1؛ إلخ.

الفئة Presentation، التي تمثل ملف عرض تقديمي، تعرض جميع الشرائح كـ [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection) (مجموعة من كائنات [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/)). يُظهر لك هذا الكود C# كيفية الوصول إلى شريحة عبر فهرسها:
```c#
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
Presentation presentation = new Presentation("AccessSlides.pptx");

// يحصل على مرجع الشريحة عبر فهرستها
ISlide slide = presentation.Slides[0];
```


## **Access Slide by ID**
## **الوصول إلى الشريحة حسب المعرف**

كل شريحة في العرض التقديمي لها معرّف فريد مرتبط بها. يمكنك استخدام طريقة [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid) (المعروضة بواسطة الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)) لاستهداف ذلك المعرّف. يُظهر لك هذا الكود C# كيفية توفير معرف شريحة صالح والوصول إلى تلك الشريحة عبر طريقة [GetSlideById](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/getslidebyid):
```c#
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
Presentation presentation = new Presentation("AccessSlides.pptx");

// يحصل على معرّف الشريحة
uint id = presentation.Slides[0].SlideId;

// الوصول إلى الشريحة عبر معرّفها
IBaseSlide slide = presentation.GetSlideById(id);
```


## **Change Slide Position**
## **تغيير موضع الشريحة**

تتيح لك Aspose.Slides تغيير موضع شريحة. على سبيل المثال، يمكنك تحديد أن تصبح الشريحة الأولى هي الشريحة الثانية.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على مرجع الشريحة (الموضع الذي تريد تغييره) عبر فهرسه
3. تعيين موضع جديد للشريحة عبر خاصية [SlideNumber](https://reference.aspose.com/slides/net/aspose.slides/islide/slidenumber/).
4. حفظ العرض التقديمي المعدل.

يُظهر لك هذا الكود C# عملية يتم فيها نقل الشريحة الموجودة في الموضع 1 إلى الموضع 2:
```c#
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("ChangePosition.pptx"))
{
    // يحصل على الشريحة التي سيتم تغيير موضعها
    ISlide sld = pres.Slides[0];

    // يحدد الموضع الجديد للشريحة
    sld.SlideNumber = 2;

    // يحفظ العرض التقديمي المعدل
    pres.Save("Aspose_out.pptx", SaveFormat.Pptx);
}
```


أصبحت الشريحة الأولى هي الثانية؛ وأصبحت الشريحة الثانية هي الأولى. عند تغيير موضع شريحة، يتم تعديل الشرائح الأخرى تلقائيًا.

## **Set Slide Number**
## **تعيين رقم الشريحة**

باستخدام خاصية [FirstSlideNumber](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) (المعروضة بواسطة الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation))، يمكنك تحديد رقم جديد للشريحة الأولى في العرض التقديمي. هذه العملية تؤدي إلى إعادة حساب أرقام الشرائح الأخرى.

1. إنشاء مثال من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. الحصول على رقم الشريحة.
3. تعيين رقم الشريحة.
4. حفظ العرض التقديمي المعدل.

يُظهر لك هذا الكود C# عملية يتم فيها تعيين رقم الشريحة الأولى إلى 10:
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


إذا كنت تفضل تخطي الشريحة الأولى، يمكنك بدء الترقيم من الشريحة الثانية (وإخفاء الترقيم للشريحة الأولى) بهذه الطريقة:
```c#
using (var presentation = new Presentation())
{
    var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);
    presentation.Slides.AddEmptySlide(layoutSlide);

    // يحدد رقم الشريحة الأولى في العرض التقديمي
    presentation.FirstSlideNumber = 0;

    // يعرض أرقام الشرائح لجميع الشرائح
    presentation.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    // يخفي رقم الشريحة الأولى
    presentation.Slides[0].HeaderFooterManager.SetSlideNumberVisibility(false);

    // يحفظ العرض التقديمي المعدل
    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```


## **FAQ**
## **الأسئلة الشائعة**

**Does the slide number a user sees match the collection’s zero-based index?**
**هل رقم الشريحة الذي يراه المستخدم يطابق فهرس المجموعة المستند إلى الصفر؟**

يمكن أن يبدأ الرقم المعروض على الشريحة من قيمة عشوائية (مثل 10) ولا يجب أن يطابق الفهرس؛ يتم التحكم في العلاقة عبر إعداد [first slide number](https://reference.aspose.com/slides/net/aspose.slides/presentation/firstslidenumber/) للعرض التقديمي.

**Do hidden slides affect indexing?**
**هل تؤثر الشرائح المخفيّة على الفهرسة؟**

نعم. تظل الشريحة المخفيّة ضمن المجموعة وتُحسب في الفهرسة؛ "مخفي" يشير إلى العرض، وليس إلى موضعها في المجموعة.

**Does a slide’s index change when other slides are added or removed?**
**هل يتغيّر فهرس الشريحة عندما تُضاف أو تُحذف شرائح أخرى؟**

نعم. الفهارس دائمًا تعكس الترتيب الحالي للشرائح وتُعاد حسابها عند عمليات الإدراج أو الحذف أو النقل.