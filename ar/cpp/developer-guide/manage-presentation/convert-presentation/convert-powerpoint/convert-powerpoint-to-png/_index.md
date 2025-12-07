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
description: "قم بتحويل عروض PowerPoint التقديمية إلى صور PNG عالية الجودة بسرعة باستخدام Aspose.Slides للغة C++، مع ضمان نتائج دقيقة ومؤتمتة."
---

## **حول تحويل PowerPoint إلى PNG**

تنسيق PNG (Portable Network Graphics) ليس شائعًا مثل JPEG (Joint Photographic Experts Group)، لكنه لا يزال شائعًا جدًا.

**حالة الاستخدام:** عندما يكون لديك صورة معقدة ولا تكون الحجم مشكلة، يكون PNG تنسيق صورة أفضل من JPEG.

{{% alert title="Tip" color="primary" %}} ربما ترغب في إلقاء نظرة على **محولات PowerPoint إلى PNG** المجانية من Aspose: [PPTX to PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و [PPT to PNG](https://products.aspose.app/slides/conversion/ppt-to-png). هي تنفيذ مباشر للعملية الموضحة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

اتبع الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. احصل على كائن الشريحة من مجموعة [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) تحت الواجهة [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide).
3. استخدم الطريقة [ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage) للحصول على الصورة المصغرة لكل شريحة.
4. استخدم الطريقة [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) لحفظ الصورة المصغرة للشرائح بتنسيق PNG.

يعرض لك هذا الشيفرة بلغة C++ كيفية تحويل عرض تقديمي PowerPoint إلى PNG:
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

إذا كنت ترغب في الحصول على ملفات PNG بحجم معين، يمكنك ضبط القيم `desiredX` و `desiredY`، التي تحدد أبعاد الصورة المصغرة الناتجة.

هذا الشيفرة بلغة C++ توضح العملية الموصوفة:
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

إذا كنت تريد الحصول على ملفات PNG بحجم معين، يمكنك تمرير قيم `width` و `height` التي تفضلها لـ `ImageSize`.

هذا الشيفرة يوضح لك كيفية تحويل PowerPoint إلى PNG مع تحديد حجم الصور:
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
يدعم Aspose.Slides [إنشاء صور مصغرة للأشكال الفردية](/slides/ar/cpp/create-shape-thumbnails/); يمكنك تصيير الشكل إلى صورة PNG.

**هل يدعم التحويل المتوازي على الخادم؟**  
نعم، ولكن يجب [عدم مشاركة](/slides/ar/cpp/multithreading/) مثيل عرض تقديمي واحد عبر الخيوط. استخدم مثيلًا منفصلاً لكل خيط أو عملية.

**ما هي قيود الإصدار التجريبي عند التصدير إلى PNG؟**  
إصدار التقييم يضيف علامة مائية إلى الصور الناتجة ويفرض [قيودًا أخرى](/slides/ar/cpp/licensing/) حتى يتم تطبيق ترخيص.