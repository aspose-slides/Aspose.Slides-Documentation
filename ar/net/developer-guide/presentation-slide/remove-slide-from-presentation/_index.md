---
title: إزالة شريحة من العرض التقديمي
type: docs
weight: 30
url: /ar/net/remove-slide-from-presentation/
keywords: "إزالة الشريحة, حذف الشريحة, PowerPoint, عرض تقديمي, C#, Csharp, .NET, Aspose.Slides"
description: "إزالة شريحة من PowerPoint بواسطة المرجع أو الفهرس باستخدام C# أو .NET"
---

إذا أصبحت الشريحة (أو محتواها) زائدة، يمكنك حذفها. توفر Aspose.Slides الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) التي تُغلف [ISlideCollection](https://reference.aspose.com/slides/net/aspose.slides/islidecollection)، وهي مستودع لجميع الشرائح في عرض تقديمي. باستخدام مؤشرات (مرجع أو فهرس) لكائن [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) معروف، يمكنك تحديد الشريحة التي تريد إزالتها. 

## **إزالة شريحة بواسطة المرجع**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. الحصول على مرجع للشريحة التي تريد إزالتها عبر معرّفها أو فهرسها.
1. إزالة الشريحة المشار إليها من العرض التقديمي.
1. حفظ العرض التقديمي المعدل. 

يعرض هذا الكود C# الطريقة لإزالة شريحة عبر مرجعها:
```c#
// ينشئ كائن Presentation يمثل ملف عرض تقديمي
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // يصل إلى شريحة عبر فهرستها في مجموعة الشرائح
    ISlide slide = pres.Slides[0];

    // يزيل شريحة عبر مرجعها
    pres.Slides.Remove(slide);

    // يحفظ العرض التقديمي المعدل
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```



## **إزالة شريحة بواسطة الفهرس**

1. إنشاء نسخة من الفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) .
1. إزالة الشريحة من العرض التقديمي عبر موضع فهرسها.
1. حفظ العرض التقديمي المعدل. 

يعرض هذا الكود C# الطريقة لإزالة شريحة عبر فهرسها:
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


## **إزالة شريحة تخطيط غير مستخدمة**

توفر Aspose.Slides الطريقة [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) (من الفئة [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) لتتيح لك حذف شرائح التخطيط غير المرغوب فيها وغير المستخدمة. يعرض هذا الكود C# كيفية إزالة شريحة تخطيط من عرض تقديمي PowerPoint:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **إزالة شريحة رئيسية غير مستخدمة**

توفر Aspose.Slides الطريقة [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) (من الفئة [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)) لتتيح لك حذف الشرائح الرئيسية غير المرغوب فيها وغير المستخدمة. يعرض هذا الكود C# كيفية إزالة شريحة رئيسية من عرض تقديمي PowerPoint:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **الأسئلة الشائعة**

**ماذا يحدث لفهارس الشرائح بعد حذف شريحة؟**

بعد الحذف، تقوم [collection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) بإعادة فهرسة الشرائح: كل شريحة تالية تتحرك إلى اليسار موضعًا واحدًا، لذا تصبح أرقام الفهارس السابقة قديمة. إذا كنت بحاجة إلى مرجع ثابت، استخدم المعرّف الدائم لكل شريحة بدلاً من فهرسها.

**هل معرف الشريحة مختلف عن فهرسها، وهل يتغير عند حذف الشرائح المجاورة؟**

نعم. الفهرس هو موضع الشريحة وسيتغير عند إضافة أو حذف شرائح. معرف الشريحة هو معرّف ثابت ولا يتغير عندما تُحذف الشرائح الأخرى.

**كيف يؤثر حذف شريحة على أقسام الشرائح؟**

إذا كانت الشريحة تنتمي إلى قسم، سيحتوي ذلك القسم ببساطة على شريحة أقل. يبقى هيكل القسم كما هو؛ إذا أصبح القسم فارغًا، يمكنك [remove or reorganize sections](/slides/ar/net/slide-section/) حسب الحاجة.

**ماذا يحدث للملاحظات والتعليقات المرتبطة بشريحة عند حذفها؟**

[Notes](/slides/ar/net/presentation-notes/) و[comments](/slides/ar/net/presentation-comments/) مرتبطان بتلك الشريحة المحددة ويتم حذفهما معها. المحتوى في الشرائح الأخرى لا يتأثر.

**كيف يختلف حذف الشرائح عن تنظيف التخطيطات/الرؤوس غير المستخدمة؟**

الحذف يزيل شرائح عادية محددة من المجموعة. تنظيف التخطيطات/الرؤوس غير المستخدمة يزيل شرائح التخطيط أو الرؤوس التي لا يشير إليها أي شيء، مما يقلل حجم الملف دون تغيير محتوى الشرائح المتبقية. هذان الإجراءان مكملان لبعضهما: عادةً ما يتم الحذف أولاً، ثم التنظيف.