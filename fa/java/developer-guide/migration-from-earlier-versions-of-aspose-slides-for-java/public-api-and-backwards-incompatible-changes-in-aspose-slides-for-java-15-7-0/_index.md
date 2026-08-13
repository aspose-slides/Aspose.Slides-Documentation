---
title: تغییرات API عمومی و ناسازگاری‌های عقب‌گرد در Aspose.Slides برای Java 15.7.0
linktitle: Aspose.Slides for Java 15.7.0
type: docs
weight: 150
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/
keywords:
- مهاجرت
- کد قدیمی
- کد مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای Java را بررسی کنید تا به‌صورت روان ارائه‌های PowerPoint PPT، PPTX و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}} 

این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و موارد مشابه که [اضافه](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) یا [حذف](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-7-0/) شده‌اند را فهرست می‌کند و سایر تغییراتی که با Aspose.Slides for Java 15.7.0 API معرفی شده‌اند.

{{% /alert %}} 
## **تغییرات API عمومی**
#### **Enum com.aspose.slides.ImagePixelFormat اضافه شده است**
Enum com.aspose.slides.ImagePixelFormat برای تعیین فرمت پیکسل تصاویر تولید شده اضافه شده است.
#### **متد com.aspose.slides.IChartDataPoint.getAutomaticDataPointColor() اضافه شده است**
این متد رنگ خودکار نقطه داده را بر اساس شاخص سری، شاخص نقطه داده، parentSeriesGroup، مقادیر isColorVaried و سبک نمودار برمی‌گرداند. این رنگ به‌صورت پیش‌فرض زمانی استفاده می‌شود که fillType برابر NotDefined باشد.
#### **متدهای getPixelFormat()، setPixelFormat(int) به com.aspose.slides.ITiffOptions اضافه شده‌اند**
متدهای getPixelFormat() و setPixelFormat(/ImagePixelFormat/int) به com.aspose.slides.ITiffOptions و com.aspose.slides.TiffOptions اضافه شده‌اند تا فرمت پیکسل تصاویر TIFF تولید شده را تعیین کنند.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("demo.pptx");

TiffOptions options = new TiffOptions();

options.setPixelFormat(ImagePixelFormat.Format8bppIndexed);

pres.save("demo-out.tiff", SaveFormat.Tiff, options);

```