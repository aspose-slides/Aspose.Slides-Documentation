---
title: الحصول على خلفية شريحة العرض بالكامل كصورة
type: docs
weight: 95
url: /androidjava/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- شريحة
- خلفية
- خلفية الشريحة
- الخلفية إلى صورة
- باوربوينت
- PPT
- PPTX
- عرض باوربوينت
- جافا
- Aspose.Slides for Android عبر جافا
---

في عروض باوربوينت، يمكن أن تتكون خلفية الشريحة من العديد من العناصر. بالإضافة إلى الصورة المعينة كـ [خلفية الشريحة](/slides/androidjava/presentation-background/)، يمكن أن تؤثر سمة العرض ونظام الألوان والأشكال الموضوعة على الشريحة الرئيسية وشريحة التخطيط على الخلفية النهائية.

لا يوفر Aspose.Slides for Android عبر جافا طريقة بسيطة لاستخراج خلفية الشريحة بالكامل كصورة، ولكن يمكنك اتباع الخطوات أدناه للقيام بذلك:
1. تحميل العرض باستخدام فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. الحصول على حجم الشريحة من العرض.
1. اختيار شريحة.
1. إنشاء عرض تقديمي مؤقت.
1. تعيين نفس حجم الشريحة في العرض التقديمي المؤقت.
1. استنساخ الشريحة المحددة إلى العرض التقديمي المؤقت.
1. حذف الأشكال من الشريحة المستنسخة.
1. تحويل الشريحة المستنسخة إلى صورة.

مثال الشيفرة أدناه يستخرج خلفية الشريحة بالكامل كصورة.
```java
int slideIndex = 0;
int imageScale = 1;

Presentation presentation = new Presentation("sample.pptx");

Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(slideIndex);

Presentation tempPresentation = new Presentation();

float slideWidth = (float)slideSize.getWidth();
float slideHeight = (float)slideSize.getHeight();
tempPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);

ISlide clonedSlide = tempPresentation.getSlides().addClone(slide);
clonedSlide.getShapes().clear();

IImage background = clonedSlide.getImage(imageScale, imageScale);
background.save("output.png", ImageFormat.Png);

tempPresentation.dispose();
presentation.dispose();
```