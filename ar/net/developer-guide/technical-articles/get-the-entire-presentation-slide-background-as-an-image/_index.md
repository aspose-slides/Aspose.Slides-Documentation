---
title: الحصول على خلفية شريحة العرض التقديمي بالكامل كصورة
type: docs
weight: 95
url: /ar/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- شريحة
- خلفية
- خلفية الشريحة
- الخلفية إلى صورة
- PowerPoint
- PPT
- PPTX
- عرض تقديمي PowerPoint
- C#
- VB.NET
- Aspose.Slides for .NET
---

## **الحصول على خلفية الشريحة بالكامل**

في عروض PowerPoint التقديمية، يمكن أن تتألف خلفية الشريحة من العديد من العناصر. بالإضافة إلى الصورة المحددة كـ[خلفية الشريحة](/slides/ar/net/presentation-background/)، يمكن أن يتأثر الخلفية النهائية بموضوع العرض، نظام الألوان، والأشكال الموجودة على الشريحة الرئيسية وشريحة التخطيط.

Aspose.Slides for .NET لا يوفر طريقة بسيطة لاستخراج خلفية الشريحة بالكامل كصورة، ولكن يمكنك اتباع الخطوات التالية للقيام بذلك:
1. حمّل العرض باستخدام الفئة[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. احصل على حجم الشريحة من العرض.
1. حدد شريحة.
1. أنشئ عرضًا مؤقتًا.
1. عيّن نفس حجم الشريحة في العرض المؤقت.
1. استنسخ الشريحة المحددة إلى العرض المؤقت.
1. احذف الأشكال من الشريحة المستنسخة.
1. حوّل الشريحة المستنسخة إلى صورة.

المثال البرمجي التالي يستخرج خلفية الشريحة بالكامل كصورة.
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


## **الأسئلة المتكررة**

**هل سيتم الاحتفاظ بالتدرجات المعقدة أو القوام أو تعبئات الصور من الشريحة الرئيسية في صورة الخلفية الناتجة؟**

نعم. يقوم Aspose.Slides بمعالجة تعبئات التدرج والصورة والملمس المحددة على الشريحة أو التخطيط أو الرئيس. إذا كنت بحاجة إلى عزل المظهر عن الرؤساء الموروثة، يمكنك [تعيين خلفية خاصة](/slides/ar/net/presentation-background/) على الشريحة الحالية قبل التصدير.

**هل يمكنني إضافة علامة مائية إلى صورة الخلفية الناتجة قبل حفظها؟**

نعم. يمكنك [إضافة علامة مائية](/slides/ar/net/watermark/) كشكل أو صورة على [نسخة من الشريحة](/slides/ar/net/clone-slides/) (موجودة خلف المحتوى الآخر) ثم تصديرها. هذا يسمح بإنشاء صورة خلفية مدمجة مع العلامة المائية.

**هل يمكنني الحصول على الخلفية لتخطيط أو رئيس معين دون ربطها بشريحة موجودة؟**

نعم. يمكنك الوصول إلى الرئيس أو التخطيط المطلوب، وتطبيقه على [شريحة مؤقتة](/slides/ar/net/clone-slides/) بالحجم المطلوب، ثم تصدير تلك الشريحة للحصول على الخلفية المشتقة من ذلك التخطيط أو الرئيس.

**هل هناك قيود ترخيص تؤثر على تصدير الصور؟**

ميزات التصيير متاحة بالكامل مع [رخصة صالحة](/slides/ar/net/licensing/). في وضع التقييم، قد يتضمن الناتج قيودًا مثل العلامة المائية. فعّل الترخيص مرة واحدة لكل عملية قبل تشغيل تصدير الدفعات.