---
title: الحصول على خلفية الشريحة بالكامل من عرض تقديمي كصورة
linktitle: خلفية الشريحة بالكامل
type: docs
weight: 95
url: /ar/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- خلفية الشريحة
- الخلفية النهائية
- استخراج الخلفية
- الخلفية الكاملة
- الخلفية إلى صورة
- خلفية PPT
- خلفية PPTX
- خلفية ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استخراج خلفيات الشرائح الكاملة كصور من عروض PowerPoint و OpenDocument باستخدام Aspose.Slides for .NET، مما يبسط سير العمل البصري."
---

## **الحصول على خلفية الشريحة بالكامل**

في عروض PowerPoint التقديمية، يمكن أن تتكون خلفية الشريحة من عدة عناصر. بالإضافة إلى الصورة المعينة كـ[خلفية الشريحة](/slides/ar/net/presentation-background/)، يمكن أن يتأثر الخلفية النهائية بموضوع العرض، نظام الألوان، والأشكال الموجودة على الشريحة الرئيسية وشريحة التخطيط.

لا توفر Aspose.Slides for .NET طريقة بسيطة لاستخراج خلفية الشريحة الكاملة كصورة، ولكن يمكنك اتباع الخطوات التالية للقيام بذلك:
1. تحميل العرض باستخدام فئة[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. الحصول على حجم الشريحة من العرض.
1. اختيار شريحة.
1. إنشاء عرض مؤقت.
1. تعيين نفس حجم الشريحة في العرض المؤقت.
1. استنساخ الشريحة المحددة إلى العرض المؤقت.
1. حذف الأشكال من الشريحة المستنسخة.
1. تحويل الشريحة المستنسخة إلى صورة.

```cs
var slideIndex = 0;
var imageScale = 1;

using var presentation = new Presentation("sample.pptx");

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[slideIndex];

using var tempPresentation = new Presentation();    
tempPresentation.SlideSize.SetSize(slideSize.Width, slideSize.Height, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.Slides.AddClone(slide);
clonedSlide.Shapes.Clear();

using var background = clonedSlide.GetImage(imageScale, imageScale);
background.Save("output.png", ImageFormat.Png);
```


## **FAQ**

**هل سيتم الحفاظ على التدرجات المعقدة أو القوام أو تعبئات الصور من الشريحة الرئيسية في صورة الخلفية الناتجة؟**

نعم. يقوم Aspose.Slides بمعالجة التدرجات وتعبئة الصور والقوام المحددة على الشريحة أو التخطيط أو الرئيس. إذا كنت بحاجة لعزل المظهر من الرؤوس الموروثة،[تعيين خلفية خاصة](/slides/ar/net/presentation-background/) على الشريحة الحالية قبل التصدير.

**هل يمكنني إضافة علامة مائية إلى صورة الخلفية الناتجة قبل حفظها؟**

نعم. يمكنك[إضافة علامة مائية](/slides/ar/net/watermark/) كشكل أو صورة على[نسخة من الشريحة](/slides/ar/net/clone-slides/) (موجودة خلف المحتوى الآخر) ثم تصديرها. هذا يتيح لك إنشاء صورة خلفية مع دمج العلامة المائية.

**هل يمكنني الحصول على الخلفية لتخطيط أو رئيس محدد دون ربطها بشريحة موجودة؟**

نعم. قم بالوصول إلى الرئيس أو التخطيط المطلوب، وطبّقه على[شريحة مؤقتة](/slides/ar/net/clone-slides/) بالحجم المطلوب، ثم قم بتصدير تلك الشريحة للحصول على الخلفية المستمدة من ذلك التخطيط أو الرئيس.

**هل هناك قيود ترخيص تؤثر على تصدير الصور؟**

تتوفر جميع ميزات التصيير بالكامل مع[رخصة صالحة](/slides/ar/net/licensing/). في وضع التقييم، قد يتضمن الناتج قيودًا مثل علامة مائية. فعّل الرخصة مرة واحدة لكل عملية قبل تشغيل عمليات التصدير الجماعية.