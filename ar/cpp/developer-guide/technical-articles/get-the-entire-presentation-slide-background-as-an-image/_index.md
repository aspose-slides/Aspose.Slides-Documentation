---
title: الحصول على خلفية الشريحة بالكامل كصورة
type: docs
weight: 95
url: /ar/cpp/get-the-entire-presentation-slide-background-as-an-image/
keywords:
- شريحة
- خلفية
- خلفية الشريحة
- الخلفية إلى صورة
- PowerPoint
- PPT
- PPTX
- عرض PowerPoint
- C++
- Aspose.Slides for C++
---

في عروض PowerPoint، يمكن أن تتكون خلفية الشريحة من العديد من العناصر. بالإضافة إلى الصورة المحددة كـ [خلفية الشريحة](/slides/ar/cpp/presentation-background/)، يمكن أن تتأثر الخلفية النهائية بموضوع العرض، ونظام الألوان، والأشكال الموضوعة على الشريحة الرئيسية وشريحة التخطيط.

لا توفر Aspose.Slides for C++ طريقة بسيطة لاستخراج خلفية الشريحة بالكامل كصورة، ولكن يمكنك اتباع الخطوات أدناه للقيام بذلك:
1. قم بتحميل العرض باستخدام فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. احصل على حجم الشريحة من العرض.
1. اختر شريحة.
1. أنشئ عرضاً مؤقتاً.
1. اضبط نفس حجم الشريحة في العرض المؤقت.
1. انسخ الشريحة المحددة إلى العرض المؤقت.
1. احذف الأشكال من الشريحة المنسوخة.
1. قم بتحويل الشريحة المنسوخة إلى صورة.

مثال الشيفرة التالي يستخرج خلفية الشريحة بالكامل كصورة.
```cpp
auto slideIndex = 0;
auto imageScale = 1;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slideSize = presentation->get_SlideSize()->get_Size();
auto slide = presentation->get_Slides()->idx_get(slideIndex);

auto tempPresentation = System::MakeObject<Presentation>();

auto slideWidth = slideSize.get_Width();
auto slideHeight = slideSize.get_Height();
tempPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::DoNotScale);

auto clonedSlide = tempPresentation->get_Slides()->AddClone(slide);
clonedSlide->get_Shapes()->Clear();

auto background = clonedSlide->GetImage(imageScale, imageScale);
background->Save(u"output.png", ImageFormat::Png);

tempPresentation->Dispose();
presentation->Dispose();
```