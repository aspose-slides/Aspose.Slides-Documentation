---
title: API عمومی و تغییرات ناسازگار به سمت عقب در Aspose.Slides برای جاوا 15.7.0
linktitle: Aspose.Slides برای جاوا 15.7.0
type: docs
weight: 150
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای جاوا را بررسی کنید تا به‌صورت روانی راه‌حل‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}} 

این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و موارد مشابهی که [اضافه‌شده](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) یا [حذف‌شده](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) هستند و سایر تغییرات معرفی‌شده در API Aspose.Slides for Java نسخه 15.7.0 را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**
#### **Enum com.aspose.slides.ImagePixelFormat اضافه شده است**
Enum com.aspose.slides.ImagePixelFormat برای تعیین قالب پیکسل تصاویر تولید شده اضافه شده است.
#### **متد com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() اضافه شده است**
این متد رنگ خودکار نقطه داده را بر اساس شاخص سری، شاخص نقطه داده، parentSeriesGroup، مقدار isColorVaried و سبک نمودار بر می‌گرداند. این رنگ به‌صورت پیش‌فرض استفاده می‌شود اگر fillType برابر NotDefined باشد.
#### **متدهای getPixelFormat()، setPixelFormat(int) به com.aspose.slides.ITiffOptions اضافه شده‌اند**
متدهای getPixelFormat() و setPixelFormat(/ImagePixelFormat/int) به com.aspose.slides.ITiffOptions و com.aspose.slides.TiffOptions اضافه شده‌اند تا قالب پیکسل تصاویر TIFF تولید شده را تعیین کنند.

``` java

 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```