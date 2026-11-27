---
title: فشرده‌سازی ارائه‌ها
description: اندازهٔ ارائه را با فشرده‌سازی تصاویر و حذف محتوای استفاده‌نشده کاهش دهید.
type: docs
url: /fa/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: عملیات
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **نمای کلی**

تصاویر را فشرده کنید، نواحی برش‌خورده تصویر را زمانی که دیگر لازم نیستند حذف کنید، و پیش از ذخیره‌سازی تنظیمات فشرده‌سازی ارائه را انتخاب کنید. این برای مجموعه‌هایی با تصاویر بزرگ یا رسانه‌های تکراری مفید است. مقدار ذخیره‌شده بستگی به محتوای انتخابی و تنظیماتی که انتخاب می‌کنید دارد.

## **نمونه استفاده**

این مثال C# فایل `input.pptx` را بارگذاری می‌کند، ارائه را فشرده می‌سازد و به عنوان `compressed.pptx` ذخیره می‌کند.

از Aspose.Slides برای .NET نسخه 26.11 یا بالاتر استفاده کنید. برای راه‌اندازی، به [نصب Aspose.Slides برای .NET](/slides/fa/net/installation/) مراجعه کنید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

<!-- visual-explanation:compress-presentations:start -->
[![نمایش‌های تصویر با مقیاس یکسان قبل و بعد از فشرده‌سازی، به همراه نوارهای اندازه‌گیری‌شدهٔ حجم فایل PPTX و ابعاد ذخیره‌شده تصویر.](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*اندازه‌گیری شده بر روی یک دستگاه جزئیات مصنوعی: 584,030 → 128,323 بایت. هر دو رندر از یک مقیاس و قاب 252 × 336 نقطه‌ای استفاده می‌کنند. فشرده‌سازی حاشیه‌های برش‌خورده را حذف کرده و تصویر ذخیره‌شده را به 525 × 700 پیکسل کاهش می‌دهد؛ صرفه‌جویی در اندازه بستگی به ورودی دارد.* 
<!-- visual-explanation:compress-presentations:end -->

## **سؤالات متداول**

### **آیا این یک سوئیچ بهینه‌سازی یک‌بارهٔ تمام فایل است؟**

نسخه 26.11 Aspose.Slides برای .NET متد [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/) را اضافه می‌کند که حذف چیدمان/مسترهای استفاده‌نشده، زیرمجموعه‌سازی فونت‌های توکار و فشرده‌سازی تصویر با 150 DPI را ترکیب می‌نماید. این متد به‌صورت دائمی نواحی برش‌خورده تصویر را حذف می‌کند. برای پردازش صرفاً تصویر، از [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) استفاده کنید؛ برای کنترل دقیق‌تر، به [مثال فشرده‌سازی تصویر تک‌تک](/slides/fa/net/examples/optimization-batch/compression/) مراجعه کنید. از نسخه 26.11، همین فراخوانی برای کل ارائه همچنین در Java، Node.js از طریق Java، Python از طریق .NET و C++ در دسترس است. مثال و پیوندهای این صفحه برای .NET هستند.

### **آیا فشرده‌سازی تصویر متن یا چارت‌های قابل ویرایش را تغییر می‌دهد؟**

فشرده‌سازی تصویر بر روی داده‌های تصویر هدف می‌گیرد و نه بر متن یا داده‌های نمودارهای قابل ویرایش. تصاویر را بازبینی کنید زیرا تغییر اندازه یا فشرده‌سازی مجدد می‌تواند جزئیات آنها را کاهش دهد.

### **چگونه باید وضوح تصاویر ارائه را انتخاب کنم؟**

یک هدف را بر پایهٔ اندازه تصویر نمایش داده‌شده و استفادهٔ موردنظر برای صفحه‌نمایش یا چاپ انتخاب کنید. برای نمایشگرهای بزرگ، چاپ و نمودارهای دقیق، وضوح بیشتری حفظ کنید و قبل از حذف نسخهٔ اصلی، خروجی رندر شده را مقایسه کنید.

## **راهنماها**

- [فشرده‌سازی کل ارائه در .NET](/slides/fa/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [بهینه‌سازی مدیریت تصاویر در ارائه‌ها در .NET](/slides/fa/net/image/)

قابلیت مرتبط: [حذف استادها، طرح‌بندی‌ها و رسانه‌های استفاده‌نشده](/slides/fa/features/remove-unused-content/).

## نمونه‌های قابل اجرا برای .NET

- [کاهش اندازه ارائه](/slides/fa/net/examples/optimization-batch/compression/)