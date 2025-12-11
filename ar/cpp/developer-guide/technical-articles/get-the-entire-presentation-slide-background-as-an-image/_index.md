---
title: الحصول على خلفية الشريحة بالكامل من العرض كصورة
linktitle: خلفية الشريحة بالكامل
type: docs
weight: 95
url: /ar/cpp/get-the-entire-presentation-slide-background-as-an-image/
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
- C++
- Aspose.Slides
description: "استخراج خلفيات الشريحة الكاملة كصور من عروض PowerPoint وOpenDocument باستخدام Aspose.Slides للغة C++، مما يُسهل سير العمل البصري."
---

## **الحصول على خلفية الشريحة بالكامل**

في عروض PowerPoint التقديمية، يمكن أن تتكون خلفية الشريحة من عدة عناصر. بالإضافة إلى الصورة المعينة كـ[خلفية الشريحة](/slides/ar/cpp/presentation-background/)، يمكن أن يتأثر الخلفية النهائية بموضوع العرض، ونظام الألوان، والأشكال الموضوعة على الشريحة الرئيسة وشريحة التخطيط.

Aspose.Slides for C++ لا يوفر طريقة بسيطة لاستخراج خلفية شريحة العرض بالكامل كصورة، ولكن يمكنك اتباع الخطوات أدناه للقيام بذلك:
1. تحميل العرض باستخدام الفئة[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
1. احصل على حجم الشريحة من العرض.
1. اختر شريحة.
1. أنشئ عرضًا مؤقتًا.
1. ضبط حجم الشريحة نفسه في العرض المؤقت.
1. استنسخ الشريحة المحددة إلى العرض المؤقت.
1. احذف الأشكال من الشريحة المستنسخة.
1. حوّل الشريحة المستنسخة إلى صورة.

مثال الشيفرة التالي يستخرج خلفية شريحة العرض بالكامل كصورة.
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


## **الأسئلة المتكررة**

**هل ستُحافظ على التدرجات المعقدة أو القوام أو تعبئات الصور من الشريحة الرئيسة في صورة الخلفية الناتجة؟**

نعم. تقوم Aspose.Slides بتصيير تعبئات التدرج والصورة والقوام المعرفة على الشريحة أو التخطيط أو الرئيسة. إذا كنت بحاجة لعزل المظهر عن الرئيسات الموروثة،[حدد خلفية خاصة](/slides/ar/cpp/presentation-background/) على الشريحة الحالية قبل التصدير.

**هل يمكنني إضافة علامة مائية إلى صورة الخلفية الناتجة قبل حفظها؟**

نعم. يمكنك[إضافة علامة مائية](/slides/ar/cpp/watermark/) كشكل أو صورة على[نسخة من الشريحة](/slides/ar/cpp/clone-slides/) (موجودة خلف المحتوى الآخر) ثم تصديرها. هذا يسمح لك بإنشاء صورة خلفية مدمجة بالعلامة المائية.

**هل يمكنني الحصول على الخلفية لتخطيط أو رئيسة محددة دون ربطها بشريحة موجودة؟**

نعم. يمكنك الوصول إلى الرئيسة أو التخطيط المطلوب، وتطبيقه على[شريحة مؤقتة](/slides/ar/cpp/clone-slides/) بالحجم المطلوب، ثم تصدير تلك الشريحة للحصول على الخلفية المستخرجة من ذلك التخطيط أو الرئيسة.

**هل توجد قيود ترخيص تؤثر على تصدير الصور؟**

ميزات التصيير متاحة بالكامل مع[رخصة صالحة](/slides/ar/cpp/licensing/). في وضع التقييم، قد يتضمن الناتج قيودًا مثل العلامة المائية. فعل الرخصة مرة واحدة لكل عملية قبل تشغيل تصديرات الدُفعات.