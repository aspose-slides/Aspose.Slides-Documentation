---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای .NET 15.8.0
linktitle: Aspose.Slides برای .NET 15.8.0
type: docs
weight: 190
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/
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
description: "به‌روزرسانی‌های API عمومی و تغییرات شکسته‌کننده در Aspose.Slides برای .NET را مرور کنید تا به‌راحتی راه‌حل‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}} 

این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و غیره‌ای که [اضافه](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) یا [حذف‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-8-0/) هستند، و سایر تغییرات معرفی‌شده در API Aspose.Slides برای .NET 15.8.0 را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**
#### **ویژگی DoughnutHoleSize به IChartSeries و ChartSeries اضافه شده است**
اندازهٔ سوراخ در نمودار دونات را مشخص می‌کند.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);

   chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

   pres.Save("ChartSeries.API.DoughnutHoleSize.pptx", SaveFormat.Pptx);

}
```