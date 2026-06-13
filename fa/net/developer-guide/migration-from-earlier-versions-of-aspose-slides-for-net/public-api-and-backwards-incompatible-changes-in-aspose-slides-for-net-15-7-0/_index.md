---
title: تغییرات API عمومی و ناسازگاری‌های عقبگردی در Aspose.Slides برای .NET 15.7.0
linktitle: Aspose.Slides برای .NET 15.7.0
type: docs
weight: 180
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- مهاجرت
- کد قدیمی
- کد مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات شکسته‌کننده در Aspose.Slides برای .NET را بررسی کنید تا به‌صورت روان برنامه‌های ارائه PowerPoint PPT, PPTX و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}} 

این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و موارد مشابه که [اضافه‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) یا [حذف‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) هستند، و سایر تغییرات معرفی‌شده در API Aspose.Slides for .NET نسخه 15.7.0 را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات عمومی API**
#### **Enum ImagePixelFormat اضافه شده است**
Enum Aspose.Slides.Export.ImagePixelFormat برای تعیین فرمت پیکسل تصاویر تولید شده اضافه شده است.
#### **متد IChartDataPoint.GetAutomaticDataPointColor() اضافه شده است**
یک رنگ خودکار برای نقطه داده بر اساس شاخص سری، شاخص نقطه داده، ParentSeriesGroup، خاصیت IsColorVaried و سبک نمودار برمی‌گرداند. این رنگ به صورت پیش‌فرض استفاده می‌شود اگر FillType برابر NotDefined باشد.
#### **متد RenderToGraphics به Slide اضافه شده است**
متد RenderToGraphics (و overloadهای آن) به Aspose.Slides.Slide اضافه شده است تا اسلاید را به شیء Graphics رندر کند.
#### **خاصیت PixelFormat به ITiffOptions و TiffOptions اضافه شده است**
خاصیت PixelFormat به Aspose.Slides.Export.ITiffOptions و Aspose.Slides.Export.TiffOptions اضافه شده است تا فرمت پیکسل تصاویر TIFF تولید شده را مشخص کند.