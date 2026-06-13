---
title: API عمومی و تغییرات ناسازگار به عقب در Aspose.Slides برای .NET 15.8.0
linktitle: Aspose.Slides برای .NET 15.8.0
type: docs
weight: 190
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
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
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای .NET را مرور کنید تا به‌صورت روان راه‌حل‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}} 
این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و غیره که [افزوده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) یا [حذف](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) شده‌اند و سایر تغییرات معرفی‌شده در API Aspose.Slides for .NET 15.8.0 را فهرست می‌کند.
{{% /alert %}} 
## **تغییرات API عمومی**
#### **Property DoughnutHoleSize به IChartSeries و ChartSeries اضافه شده است**
اندازه سوراخ در یک نمودار دونات را مشخص می‌کند.
``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}

```