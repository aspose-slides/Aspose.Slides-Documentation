---
title: API عمومی و تغییرات ناسازگار با نسخه قبلی در Aspose.Slides برای .NET 15.7.0
linktitle: Aspose.Slides برای .NET 15.7.0
type: docs
weight: 180
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای .NET را مرور کنید تا به‌صورت روان راه‌حل‌های ارائه PowerPoint (PPT, PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}} 
این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و موارد مشابه که [اضافه‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) یا [حذف‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-7-0/) هستند و سایر تغییرات اعمال‌شده در API Aspose.Slides برای .NET نسخه 15.7.0 را فهرست می‌کند.
{{% /alert %}} 
## **تغییرات API عمومی**
#### **Enum ImagePixelFormat اضافه شده است**
Enum Aspose.Slides.Export.ImagePixelFormat برای تعیین فرمت پیکسل تصاویر تولید شده اضافه شده است.
#### **متد IChartDataPoint.GetAutomaticDataPointColor() اضافه شده است**
یک رنگ خودکار برای نقطه داده بر اساس ایندکس سری، ایندکس نقطه داده، ParentSeriesGroup، خصوصیت IsColorVaried و سبک نمودار برمی‌گرداند.
این رنگ به‌صورت پیش‌فرض استفاده می‌شود اگر FillType برابر NotDefined باشد.
#### **متد RenderToGraphics به Slide اضافه شده است**
متد RenderToGraphics (و بارگذاری‌های آن) به Aspose.Slides.Slide اضافه شده است تا اسلاید را به شی Graphics رندر کند.
#### **ویژگی PixelFormat به ITiffOptions و TiffOptions اضافه شده است**
ویژگی PixelFormat به Aspose.Slides.Export.ITiffOptions و Aspose.Slides.Export.TiffOptions اضافه شده است تا فرمت پیکسل تصاویر TIFF تولید شده را مشخص کند.