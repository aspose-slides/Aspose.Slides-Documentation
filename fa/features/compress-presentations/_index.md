---
title: فشرده‌سازی ارائه‌ها
description: کاهش اندازه ارائه با فشرده‌سازی تصاویر و حذف محتویات استفاده‌نشده.
type: docs
url: /fa/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **بررسی کلی**

تصاویر را فشرده کنید، نواحی برش‌خورده تصویر را وقتی دیگر نیازی به آن‌ها نیست حذف کنید، و قبل از ذخیره‌سازی تنظیمات فشرده‌سازی ارائه را انتخاب کنید. این برای ارائه‌های دارای عکس‌های بزرگ یا رسانه‌های تکراری مفید است. میزان ذخیره‌شده بستگی به محتوای انتخابی و تنظیمات شما دارد.

## **مثال استفاده**

این مثال C# فایل `input.pptx` را بارگیری می‌کند، ارائه را فشرده می‌سازد و به عنوان `compressed.pptx` ذخیره می‌کند.  
از Aspose.Slides برای .NET نسخه 26.11 یا بالاتر استفاده کنید. برای راه‌اندازی، به [نصب Aspose.Slides برای .NET](/slides/fa/net/installation/) مراجعه کنید.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **پرسش‌های متداول**

### **آیا این یک سوئیچ بهینه‌سازی تک‌فایلی است؟**

Aspose.Slides برای .NET نسخه 26.11 متد [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/) را اضافه می‌کند که حذف طرح/مسترارهای استفاده‌نشده، زیرمجموعه‌سازی فونت‌های جاسازی‌شده و فشرده‌سازی تصویر با 150 DPI را ترکیب می‌کند. این نواحی برش‌خورده تصویر را به صورت دائمی حذف می‌کند. برای پردازش فقط تصویر، از [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) استفاده کنید؛ برای کنترل دقیق‌تر، به [مثال فشرده‌سازی تصویر تک‌تک](/slides/fa/net/examples/optimization-batch/compression/) مراجعه کنید. این کمک‌کننده‌های جدید مختص نسخه .NET مذکور هستند؛ برای سایر SDKها راهنمای مربوطه را بررسی کنید.

### **آیا فشرده‌سازی تصویر متن یا نمودارهای قابل ویرایش را تغییر می‌دهد؟**

فشرده‌سازی تصویر بر داده‌های تصویر متمرکز است و نه بر متن یا داده‌های نمودارهای قابل ویرایش. تصاویر را بازبینی کنید زیرا تغییر اندازه یا فشرده‌سازی مجدد ممکن است جزئیات آن‌ها را کاهش دهد.

### **چگونه باید برای تصاویر ارائه رزولوشن را انتخاب کنم؟**

هدف را بر اساس اندازه تصویر نمایش داده‌شده و کاربرد موردنظر برای صفحه‌نمایش یا چاپ انتخاب کنید. برای نمایشگرهای بزرگ، چاپ و نمودارهای جزئی‌گراتر رزولوشن بیشتری حفظ کنید و قبل از حذف نسخه اصلی، خروجی رندر شده را مقایسه کنید.

## **راهنماها**

- [فشرده‌سازی کل ارائه در .NET](/slides/fa/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [بهینه‌سازی مدیریت تصویر در ارائه‌ها در .NET](/slides/fa/net/image/)

قابلیت مرتبط: [حذف مسترها، طرح‌ها و رسانه‌های استفاده‌نشده](/slides/fa/features/remove-unused-content/).

## مثال‌های قابل اجرا در .NET

- [کاهش اندازه ارائه](/slides/fa/net/examples/optimization-batch/compression/)