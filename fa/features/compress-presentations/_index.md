---
title: فشرده‌سازی ارائه‌ها
description: اندازه ارائه را با فشرده‌سازی تصویر و تنظیمات ذخیره‌سازی کاهش دهید.
type: docs
url: /fa/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operations
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **نمای کلی**

تصاویر را فشرده کنید، هنگام عدم نیاز نواحی بریده‌شده تصویر را حذف کنید و قبل از ذخیره‌سازی تنظیمات فشرده‌سازی ارائه را انتخاب کنید. این برای ارایه‌های شامل عکس‌های بزرگ یا رسانه‌های تکراری مفید است. میزان صرفه‌جویی به محتوای انتخابی و تنظیمات شما بستگی دارد.

## **مثال استفاده**

این مثال C# از Aspose.Slides for .NET استفاده می‌کند. به‌صورت واضح یک تصویر PNG گرادیان با ابعاد 1600 × 900 پیکسل تولید می‌کند، آن را در یک فریم تصویر کوچک وارد می‌کند و *before.pptx* را ذخیره می‌سازد. سپس آن تصویر را با وضوح هدف 96 DPI فشرده می‌کند و *compressed.pptx* را ذخیره می‌کند. هر دو اندازه فایل و پیش‌نمایش‌ها را مقایسه کنید: صرفه‌جویی به تصویر ورودی و اندازه نمایشی آن بستگی دارد.

برای راه‌اندازی، ببینید [نصب Aspose.Slides for .NET](/slides/fa/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **سؤالات متداول**

### **آیا این یک سوئیچ بهینه‌سازی تک‌فایلی است؟**

Aspose.Slides for .NET 26.11 گزینه [Compress.CompressPresentation](/slides/fa/net/low-code-presentation-operations/#compress-the-whole-presentation) را اضافه می‌کند که حذف طرح/مسترهای استفاده‌نشده، زیر مجموعه‌سازی فونت‌های توکار و فشرده‌سازی تصویر با 150 DPI را ترکیب می‌کند. این گزینه نواحی بریده‌شده تصویر را به طور دائم حذف می‌نماید. برای پردازش فقط تصویر، از Compress.CompressImages استفاده کنید؛ برای کنترل دقیق‌تر، جریان کاری هر تصویر را همان‌طور که در بالا توضیح دادیم، حفظ کنید. این کمک‌کننده‌های جدید مخصوص نسخه .NET مذکور هستند؛ راهنمای مربوطه را برای سایر SDKها بررسی کنید.

### **آیا فشرده‌سازی تصویر متن یا نمودارهای قابل ویرایش را تغییر می‌دهد؟**

فشرده‌سازی تصویر بر داده‌های تصویر متمرکز می‌شود، نه بر متن یا داده‌های نمودار قابل ویرایش. تصاویر را بررسی کنید زیرا تغییر اندازه یا فشرده‌سازی مجدد می‌تواند جزئیات آنها را کاهش دهد.

### **چگونه باید وضوح مناسب برای تصاویر ارائه انتخاب کنم؟**

هدف خود را بر اساس اندازه تصویر نمایش داده‌شده و استفاده مورد نظر برای صفحه نمایش یا چاپ انتخاب کنید. برای نمایشگرهای بزرگ، چاپ و نمودارهای جزئی، وضوح بیشتری را نگه دارید و قبل از حذف اصلی، خروجی رندر شده را مقایسه کنید.

## **راهنماها**

- [بهینه‌سازی مدیریت تصویر در ارائه‌ها در .NET](/slides/fa/net/image/)

Related feature: [حذف مسترها، لایه‌ها و رسانه‌های استفاده‌نشده](/slides/fa/features/remove-unused-content/).

## مثال‌های قابل اجرا در .NET

- [کاهش اندازه ارائه](/slides/fa/net/examples/optimization-batch/compression/)