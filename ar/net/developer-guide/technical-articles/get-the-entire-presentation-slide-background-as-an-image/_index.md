---
title: الحصول على خلفية الشريحة الكاملة في العرض التقديمي كصورة
type: docs
weight: 95
url: /ar/net/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- شريحة
- خلفية
- خلفية الشريحة
- خلفية كصورة
- PowerPoint
- PPT
- PPTX
- عرض PowerPoint
- C#
- VB.NET
- Aspose.Slides for .NET
---

في عروض PowerPoint التقديمية، يمكن أن تتكون خلفية الشريحة من العديد من العناصر. بالإضافة إلى الصورة المحددة كـ [خلفية الشريحة](/slides/ar/net/presentation-background/)، يمكن أن تتأثر الخلفية النهائية بموضوع العرض التقديمي، ونظام الألوان، والأشكال الموجودة على الشريحة الرئيسية وشريحة التخطيط.

لا توفر Aspose.Slides for .NET طريقة بسيطة لاستخراج خلفية الشريحة الكاملة في العرض التقديمي كصورة، ولكن يمكنك اتباع الخطوات أدناه للقيام بذلك:
1. تحميل العرض التقديمي باستخدام فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
1. الحصول على حجم الشريحة من العرض التقديمي.
1. اختيار شريحة.
1. إنشاء عرض تقديمي مؤقت.
1. تعيين نفس حجم الشريحة في العرض التقديمي المؤقت.
1. استنساخ الشريحة المختارة إلى العرض التقديمي المؤقت.
1. حذف الأشكال من الشريحة المستنسخة.
1. تحويل الشريحة المستنسخة إلى صورة.

مثال الكود التالي يستخرج خلفية الشريحة الكاملة في العرض التقديمي كصورة.
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