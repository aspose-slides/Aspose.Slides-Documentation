---
title: تبدیل اسلایدهای پاورپوینت به PNG در C++
linktitle: پاورپوینت به PNG
type: docs
weight: 30
url: /fa/cpp/convert-powerpoint-to-png/
keywords:
- تبدیل پاورپوینت
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- پاورپوینت به PNG
- ارائه به PNG
- اسلاید به PNG
- PPT به PNG
- PPTX به PNG
- ذخیره PPT به عنوان PNG
- ذخیره PPTX به عنوان PNG
- صادرات PPT به PNG
- صادرات PPTX به PNG
- C++
- Aspose.Slides
description: تبدیل ارائه‌های پاورپوینت به تصاویر PNG با کیفیت بالا به‌سرعت با Aspose.Slides برای C++، با تضمین نتایج دقیق و خودکار.
---
## **مرور کلی**

این مقاله توضیح می‌دهد که چگونه ارائه‌های PowerPoint را با استفاده از Aspose.Slides به تصاویر PNG تبدیل کنید. این مقاله نشان می‌دهد چگونه فایل‌های ارائه را در قالب‌های PPT، PPTX و ODP بارگذاری کنید، اسلایدها را به‌صورت تصویر رندر کنید و نتایج را در قالب PNG ذخیره نمایید.

همچنین این مقاله نحوه سفارشی‌سازی تصاویر PNG تولید شده را با تنظیم مقادیر مقیاس یا تعیین عرض و ارتفاع موردنظر نشان می‌دهد.

## **تبدیل PowerPoint به PNG**

این مراحل را دنبال کنید:

1. نمونه‌سازی کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation).
2. شی اسلاید را از مجموعه [Presentation::get_Slides()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) در زیررابط [ISlide](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.i_slide) دریافت کنید.
3. از متد [ISlide::GetImage()](https://reference.aspose.com/slides/fa/cpp/aspose.slides/islide/getimage) برای دریافت تصویر بندانگشتی هر اسلاید استفاده کنید.
4. از متد [IImage::Save(String, ImageFormatPtr](https://reference.aspose.com/slides/fa/cpp/aspose.slides/iimage/save/#iimagesavesystemstring-imageformat-method) برای ذخیره تصویر بندانگشتی اسلاید در قالب PNG استفاده کنید.

این کد C++ نشان می‌دهد چگونه یک ارائه PowerPoint را به PNG تبدیل کنید:

```cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
    
for (int32_t index = 0; index < pres->get_Slides()->get_Count(); index++)
{
    auto slide = pres->get_Slides()->idx_get(index);
    auto fileName = String::Format(u"slide_{0}.png", index);
    slide->GetImage()->Save(fileName, ImageFormat::Png);
}
```

## **تبدیل PowerPoint به PNG با ابعاد سفارشی**

اگر می‌خواهید فایل‌های PNG را با مقیاس خاصی بدست آورید، می‌توانید مقادیر `desiredX` و `desiredY` را تعیین کنید که ابعاد تصویر بندانگشتی نهایی را مشخص می‌کنند.

این کد C++ عملیات توصیف‌شده را نشان می‌دهد:

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

## **تبدیل PowerPoint به PNG با اندازه سفارشی**

اگر می‌خواهید فایل‌های PNG را با اندازه خاصی بدست آورید، می‌توانید آرگومان‌های `width` و `height` موردنظر خود را برای `ImageSize` ارسال کنید.

این کد نشان می‌دهد چگونه یک PowerPoint را به PNG تبدیل کنید در حالی که اندازه تصاویر را مشخص می‌کنید:

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

## **سؤالات متداول**

**چگونه می‌توانم فقط یک شکل خاص (مثلاً نمودار یا تصویر) را به‌جای کل اسلاید صادر کنم؟**  
Aspose.Slides از [ایجاد تصویر بندانگشتی برای اشکال جداگانه](/slides/fa/cpp/create-shape-thumbnails/) پشتیبانی می‌کند؛ می‌توانید یک شکل را به تصویر PNG رندر کنید.

**آیا تبدیل موازی بر روی سرور پشتیبانی می‌شود؟**  
بله، اما [نشرنکنید](/slides/fa/cpp/multithreading/) یک نمونه ارائه را بین رشته‌ها. برای هر رشته یا فرآیند از یک نمونه جداگانه استفاده کنید.

**محدودیت‌های نسخه آزمایشی هنگام صادرات به PNG چیست؟**  
حالت ارزیابی یک واترمارک به تصاویر خروجی اضافه می‌کند و تا زمانی که لایسنس اعمال نشود، [محدودیت‌های دیگری](/slides/fa/cpp/licensing/) را اعمال می‌کند.