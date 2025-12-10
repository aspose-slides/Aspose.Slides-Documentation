---
title: تحويل شرائح PowerPoint إلى PNG باستخدام C++
linktitle: PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/cpp/convert-powerpoint-to-png/
keywords:
- تحويل PowerPoint
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى PNG
- العرض التقديمي إلى PNG
- الشريحة إلى PNG
- PPT إلى PNG
- PPTX إلى PNG
- حفظ PPT كـ PNG
- حفظ PPTX كـ PNG
- تصدير PPT إلى PNG
- تصدير PPTX إلى PNG
- C++
- Aspose.Slides
description: "قم بتحويل عروض PowerPoint التقديمية إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides للغة C++، مما يضمن نتائج دقيقة ومؤتمتة."
---

## **حول تحويل PowerPoint إلى PNG**

يُعد تنسيق PNG (Portable Network Graphics) أقل شيوعًا من JPEG (Joint Photographic Experts Group)، لكنه لا يزال شائعًا جدًا. 

**حالة الاستخدام:** عندما يكون لديك صورة معقدة ولا تشكل حجمها مشكلة، يكون PNG تنسيق صورة أفضل من JPEG. 

{{% alert title="Tip" color="primary" %}} قد ترغب في تجربة محولات Aspose المجانية **PowerPoint to PNG**: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و[PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). هي تنفيذ حي للعملية الموضحة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. الحصول على كائن الشريحة من مجموعة [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) عبر الواجهة [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide).
3. استخدام طريقة [ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage) للحصول على الصورة المصغرة لكل شريحة.
4. استعمال طريقة [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) لحفظ الصورة المصغرة للشفرة بصيغة PNG.

يظهر هذا الكود C++ كيفية تحويل عرض تقديمي PowerPoint إلى PNG:
```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```


## **تحويل PowerPoint إلى PNG بأبعاد مخصصة**

إذا كنت تريد الحصول على ملفات PNG بمقاس معين، يمكنك تعيين القيم لـ `desiredX` و `desiredY`، التي تحدد أبعاد الصورة المصغرة الناتجة. 

هذا الكود في C++ يوضح العملية الموصوفة:
```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

float scaleX = 2.f;
float scaleY = 2.f;
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(scaleX, scaleY)->Save(fileName, ImageFormat::Png);
}
```


## **تحويل PowerPoint إلى PNG بحجم مخصص**

إذا كنت تريد الحصول على ملفات PNG بحجم معين، يمكنك تمرير القيم المفضلة لـ `width` و `height` كوسائط لـ `ImageSize`. 

هذا الكود يوضح كيفية تحويل PowerPoint إلى PNG مع تحديد حجم الصور:
```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
Size size(960, 720);
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage(size)->Save(fileName, ImageFormat::Png);
}
```


## **الأسئلة الشائعة**

**كيف يمكنني تصدير شكل محدد فقط (مثل مخطط أو صورة) بدلاً من الشريحة بأكملها؟**

يدعم Aspose.Slides [إنشاء صور مصغرة للأشكال الفردية](/slides/ar/cpp/create-shape-thumbnails/)؛ يمكنك تصيير الشكل إلى صورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**

نعم، ولكن لا تُشَارِك [presentation](/slides/ar/cpp/multithreading/) واحدًا عبر الخيوط. استخدم مثيلًا منفصلًا لكل خيط أو عملية.

**ما هي قيود الإصدار التجريبي عند التصدير إلى PNG؟**

يضيف وضع التقييم علامة مائية على الصور المُخرجة ويفرض [قيودًا أخرى](/slides/ar/cpp/licensing/) حتى يتم تطبيق الترخيص.