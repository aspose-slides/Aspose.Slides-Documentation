---
title: تحويل شرائح PowerPoint إلى PNG في C++
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
description: "قم بتحويل عروض PowerPoint إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides للغة C++، مع ضمان نتائج دقيقة وآلية."
---

## **حول تحويل PowerPoint إلى PNG**

تنسيق PNG (Portable Network Graphics) ليس شائعًا كما JPEG (Joint Photographic Experts Group)، لكنه لا يزال شائعًا جدًا. 

**حالة الاستخدام:** عندما يكون لديك صورة معقدة ولا يكون الحجم مشكلة، فإن PNG هو تنسيق صورة أفضل من JPEG. 

{{% alert title="Tip" color="primary" %}} قد ترغب في الاطلاع على محولات Aspose المجانية **PowerPoint إلى PNG**: [PPTX إلى PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و [PPT إلى PNG](https://products.aspose.app/slides/conversion/ppt-to-png). هي تنفيذ حي للعملية الموضحة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. احصل على كائن الشريحة من مجموعة [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) تحت واجهة [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide).
3. استخدم طريقة [ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage) للحصول على صورة مصغرة لكل شريحة.
4. استخدم طريقة [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) لحفظ الصورة المصغرة للشريحة بصيغة PNG. 

هذا الكود بلغة C++ يوضح لك كيفية تحويل عرض PowerPoint إلى PNG:
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

إذا كنت ترغب في الحصول على ملفات PNG بحجم معين، يمكنك تعيين القيم لـ `desiredX` و `desiredY`، والتي تحدد أبعاد الصورة المصغرة الناتجة. 

هذا الكود بلغة C++ يوضح العملية الموصوفة:
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

إذا كنت ترغب في الحصول على ملفات PNG بحجم معين، يمكنك تمرير القيم المفضلة لـ `width` و `height` إلى `ImageSize`. 

هذا الكود يوضح لك كيفية تحويل PowerPoint إلى PNG مع تحديد حجم الصور: 
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


## **الأسئلة المتكررة**

**كيف يمكنني تصدير شكل معين فقط (مثل مخطط أو صورة) بدلاً من الشريحة بالكامل؟**

تدعم Aspose.Slides [إنشاء صور مصغرة للأشكال الفردية](/slides/ar/cpp/create-shape-thumbnails/); يمكنك تحويل الشكل إلى صورة PNG.

**هل يُدعم التحويل المتوازي على الخادم؟**

نعم، ولكن [لا تشارك](/slides/ar/cpp/multithreading/) كائن العرض الواحد عبر الخيوط. استخدم كائنًا منفصلاً لكل خيط أو عملية.

**ما هي قيود نسخة التجربة عند التصدير إلى PNG؟**

يضيف وضع التقييم علامة مائية إلى الصور الناتجة ويُطبق [قيودًا أخرى](/slides/ar/cpp/licensing/) حتى يتم تطبيق الترخيص.