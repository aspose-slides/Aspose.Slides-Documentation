---
title: احصل على خلفية شريحة العرض بالكامل كصورة
type: docs
weight: 95
url: /java/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- شريحة
- خلفية
- خلفية الشريحة
- الخلفية إلى صورة
- PowerPoint
- PPT
- PPTX
- عرض PowerPoint
- Java
- Aspose.Slides for Java
---

في عروض PowerPoint، يمكن أن تتكون خلفية الشريحة من العديد من العناصر. بالإضافة إلى الصورة المعينة كـ [خلفية الشريحة](/slides/java/presentation-background/)، يمكن أن تتأثر الخلفية النهائية بموضوع العرض، ونظام الألوان، والأشكال الموضوعة على الشريحة الأساسية والشريحة التخطيطية.

لا يوفر Aspose.Slides for Java طريقة بسيطة لاستخراج خلفية شريحة العرض بالكامل كصورة، ولكن يمكنك اتباع الخطوات التالية للقيام بذلك:
1. قم بتحميل العرض باستخدام فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. احصل على حجم الشريحة من العرض.
1. اختر شريحة.
1. أنشئ عرضًا مؤقتًا.
1. قم بتعيين نفس حجم الشريحة في العرض المؤقت.
1. قم باستنساخ الشريحة المحددة إلى العرض المؤقت.
1. احذف الأشكال من الشريحة المستنسخة.
1. قم بتحويل الشريحة المستنسخة إلى صورة.

يعرض المثال البرمجي التالي استخراج خلفية شريحة العرض بالكامل كصورة.
```java
var slideIndex = 0;
var imageScale = 1;

var presentation = new Presentation("sample.pptx");

var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(slideIndex);

var tempPresentation = new Presentation();

var slideWidth = (float)slideSize.getWidth();
var slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

var clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

var background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```