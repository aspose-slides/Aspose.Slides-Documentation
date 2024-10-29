---
title: تحويل PowerPoint إلى PNG
type: docs
weight: 30
url: /ar/cpp/convert-powerpoint-to-png/
keywords: PowerPoint إلى PNG، PPT إلى PNG، PPTX إلى PNG، C++، Aspose.Slides لـ C++
description: تحويل عرض PowerPoint إلى PNG
---

## **حول تحويل PowerPoint إلى PNG**

تنسيق PNG (صور الشبكة المحمولة) ليس شائعًا مثل JPEG (مجموعة خبراء التصوير المشتركة)، لكنه لا يزال شائعًا جدًا.

**حالة الاستخدام:** عندما يكون لديك صورة معقدة والحجم ليس مشكلة، فإن PNG هو تنسيق صورة أفضل من JPEG.

{{% alert title="نصيحة" color="primary" %}} قد ترغب في مراجعة **محولات PowerPoint إلى PNG** المجانية من Aspose: [PPTX إلى PNG](https://products.aspose.app/slides/conversion/pptx-to-png) و [PPT إلى PNG](https://products.aspose.app/slides/conversion/ppt-to-png). إنها تنفيذ حي للعملية الموضحة في هذه الصفحة. {{% /alert %}}

## **تحويل PowerPoint إلى PNG**

اتبع هذه الخطوات:

1. انشئ كائن من فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
2. احصل على كائن الشريحة من مجموعة [Presentation::get_Slides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) تحت واجهة [ISlide](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide).
3. استخدم طريقة [ISlide::GetImage()](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage) للحصول على الصورة المصغرة لكل شريحة.
4. استخدم طريقة [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) لحفظ الصورة المصغرة للشريحة بتنسيق PNG.

يعرض هذا الكود بلغة C++ كيفية تحويل عرض PowerPoint إلى PNG:

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

إذا كنت تريد الحصول على ملفات PNG حول مقياس معين، يمكنك تعيين القيم لـ `desiredX` و `desiredY`، التي تحدد أبعاد الصورة المصغرة الناتجة.

يوضح هذا الكود بلغة C++ العملية الموصوفة:

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

إذا كنت تريد الحصول على ملفات PNG حول حجم معين، يمكنك تمرير وسيطتي `width` و `height` المفضلتين لـ `ImageSize`.

يوضح هذا الكود لك كيفية تحويل PowerPoint إلى PNG مع تحديد الحجم للصور:

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