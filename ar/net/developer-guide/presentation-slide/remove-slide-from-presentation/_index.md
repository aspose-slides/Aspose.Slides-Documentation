---
title: إزالة الشرائح من العروض التقديمية في .NET
linktitle: إزالة شريحة
type: docs
weight: 30
url: /ar/net/remove-slide-from-presentation/
keywords:
- إزالة شريحة
- حذف شريحة
- إزالة شريحة غير مستخدمة
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "قم بإزالة الشرائح بسهولة من عروض PowerPoint وOpenDocument التقديمية باستخدام Aspose.Slides لـ .NET. احصل على أمثلة شفرة C# واضحة ورفع كفاءة سير العمل الخاص بك."
---

إذا أصبحت شريحة (أو محتوياتها) غير ضرورية، يمكنك حذفها. توفر Aspose.Slides الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) التي تضمّ [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)، وهو مستودع لجميع الشرائح في العرض التقديمي. باستخدام مؤشرات (مرجعية أو فهرس) لكائن [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) معروف، يمكنك تحديد الشريحة التي تريد إزالتها. 

## **إزالة شريحة عبر المرجع**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. الحصول على مرجع للشريحة التي تريد إزالتها من خلال معرّفها أو فهرسها.
1. إزالة الشريحة المشار إليها من العرض التقديمي.
1. حفظ العرض التقديمي المعدّل. 

هذا الكود C# يوضح لك كيفية إزالة شريحة عبر مرجعها:
```c#
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // الوصول إلى شريحة عبر فهرستها في مجموعة الشرائح
    ISlide slide = pres.Slides[0];

    // يزيل شريحة عبر مرجعها
    pres.Slides.Remove(slide);

    // يحفظ العرض التقديمي المعدل
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **إزالة شريحة عبر الفهرس**

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. إزالة الشريحة من العرض التقديمي عبر موضع فهرستها.
1. حفظ العرض التقديمي المعدّل. 

هذا الكود C# يوضح لك كيفية إزالة شريحة عبر فهرستها:
```c#
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // يزيل شريحة عبر فهرسها
    pres.Slides.RemoveAt(0);

    // يحفظ العرض التقديمي المعدل
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **إزالة شرائح التخطيط غير المستخدمة**

توفر Aspose.Slides الطريقة [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (من الفئة [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) لتسمح لك بحذف شرائح التخطيط غير المرغوب فيها وغير المستخدمة. هذا الكود C# يوضح لك كيفية إزالة شريحة تخطيط من عرض PowerPoint:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **إزالة شرائح القالب غير المستخدمة**

توفر Aspose.Slides الطريقة [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (من الفئة [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) لتسمح لك بحذف شرائح القالب غير المرغوب فيها وغير المستخدمة. هذا الكود C# يوضح لك كيفية إزالة شريحة قالب من عرض PowerPoint:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**ماذا يحدث لمؤشرات الشرائح بعد حذف شريحة؟**

بعد الحذف، تقوم [collection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) بإعادة فهرسة: كل شريحة لاحقة تتحرك إلى اليسار بموقع واحد، لذا تصبح أرقام الفهرس السابقة غير صالحة. إذا كنت بحاجة إلى مرجع ثابت، استخدم المعرّف الدائم لكل شريحة بدلاً من فهرسها.

**هل يختلف معرّف الشريحة عن فهرسها، وهل يتغير عند حذف الشرائح المجاورة؟**

نعم. الفهرس هو موضع الشريحة وسييتغير عندما تُضاف أو تُحذف شرائح. معرّف الشريحة هو معرف ثابت ولا يتغير عندما تُحذف شرائح أخرى.

**كيف يؤثر حذف شريحة على أقسام الشرائح؟**

إذا كانت الشريحة تنتمي إلى قسم، سيحتوي ذلك القسم على شريحة أقل. يبقى هيكل القسم كما هو؛ إذا أصبح القسم فارغًا، يمكنك [remove or reorganize sections](/slides/ar/net/slide-section/) حسب الحاجة.

**ماذا يحدث للملاحظات والتعليقات المرتبطة بشريحة عند حذفها؟**

[Notes](/slides/ar/net/presentation-notes/) و[comments](/slides/ar/net/presentation-comments/) مرتبطان بهذه الشريحة المحددة ويتم إزالتهما معها. المحتوى في الشرائح الأخرى لا يتأثر.

**كيف يختلف حذف الشرائح عن تنظيف التخطيطات/القوالب غير المستخدمة؟**

الحذف يزيل الشرائح العادية المحددة من العرض. تنظيف التخطيطات/القوالب غير المستخدمة يزيل شرائح التخطيط أو القالب التي لا يشير إليها شيء، مما يقلل حجم الملف دون تغيير محتوى الشرائح المتبقية. هاتان العمليتان مكملتان: عادةً احذف أولاً، ثم نظّف.