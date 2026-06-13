---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای .NET 15.11.0
linktitle: Aspose.Slides برای .NET 15.11.0
type: docs
weight: 210
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/
keywords:
- مهاجرت
- کد میراثی
- کد مدرن
- رویکرد میراثی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات شکسته‌کننده در Aspose.Slides برای .NET را مرور کنید تا به‌صورت روان ارائه PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}} 
این صفحه تمام کلاس‌ها، متدها، ویژگی‌های [added](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) یا [removed](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-11-0/) و سایر موارد و تغییرات دیگری که در API Aspose.Slides برای .NET نسخه 15.11.0 معرفی شده‌اند را فهرست می‌کند.
{{% /alert %}} 
## **تغییرات API عمومی**

#### **ویژگی‌های منسوخ‌شده در کلاس DataLabelCollection حذف شده‌اند**
ویژگی‌های منسوخ‌شده در کلاس DataLabelCollection حذف شده‌اند:
Aspose.Slides.Charts.DataLabelCollection.Delete
Aspose.Slides.Charts.DataLabelCollection.Format
Aspose.Slides.Charts.DataLabelCollection.LinkedSource
Aspose.Slides.Charts.DataLabelCollection.NumberFormat
Aspose.Slides.Charts.DataLabelCollection.Position
Aspose.Slides.Charts.DataLabelCollection.Separator
Aspose.Slides.Charts.DataLabelCollection.ShowBubbleSize
Aspose.Slides.Charts.DataLabelCollection.ShowCategoryName
Aspose.Slides.Charts.DataLabelCollection.ShowLeaderLines
Aspose.Slides.Charts.DataLabelCollection.ShowLegendKey
Aspose.Slides.Charts.DataLabelCollection.ShowPercentage
Aspose.Slides.Charts.DataLabelCollection.ShowSeriesName
Aspose.Slides.Charts.DataLabelCollection.ShowValue

#### **ویژگی جدید FirstSlideNumber به کلاس Presentation اضافه شده است**
ویژگی جدید FirstSlideNumber که به کلاس Presentation اضافه شده است، امکان دریافت یا تنظیم شماره اولین اسلاید در یک ارائه را فراهم می‌کند.

زمانی که مقدار جدیدی برای FirstSlideNumber تعیین شود، تمام شماره‌های اسلاید مجدداً محاسبه می‌شوند.

``` csharp

 using(var pres = new Presenation(path))

{

  int firstSlideNumber = pres.FirstSlideNumber;

  pres.FirstSlideNumber = 10;

  pres.Save(newPath, SaveFormat.Pptx);

}

```