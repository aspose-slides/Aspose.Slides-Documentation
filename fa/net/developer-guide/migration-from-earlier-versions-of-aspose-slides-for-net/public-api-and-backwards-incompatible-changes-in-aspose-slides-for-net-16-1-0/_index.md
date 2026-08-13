---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای .NET 16.1.0
linktitle: Aspose.Slides برای .NET 16.1.0
type: docs
weight: 220
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
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
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای .NET را بررسی کنید تا بتوانید راه‌حل‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را به‌صورت روان مهاجرت دهید."
---
{{% alert color="info" %}} 
این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و غیره که [اضافه‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) یا [حذف‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) هستند و سایر تغییرات معرفی‌شده در API Aspose.Slides for .NET 16.1.0 را فهرست می‌کند.
{{% /alert %}} 
## **تغییرات API عمومی**

#### **ویژگی RotationAngle به اینترفیس‌های IChartTextBlockFormat و ITextFrameFormat اضافه شده است**
ویژگی RotationAngle به اینترفیس‌های Aspose.Slides.Charts.IChartTextBlockFormat و Aspose.Slides.ITextFrameFormat اضافه شده است. این ویژگی چرخش سفارشی که بر متن داخل جعبه مرزی اعمال می‌شود را مشخص می‌کند.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;


 using (Presentation pres = new Presentation())

{

IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

IChartSeries series = chart.ChartData.Series[0];

series.Labels.DefaultDataLabelFormat.ShowValue = true;

series.Labels.DefaultDataLabelFormat.TextFormat.TextBlockFormat.RotationAngle = 65;

chart.HasTitle = true;

chart.ChartTitle.AddTextFrameForOverriding("Custom title").TextFrameFormat.RotationAngle = -30;

pres.Save("out.pptx", SaveFormat.Pptx);

}


``` 
#### **استثنای OdpException از Aspose.Slides.Odp به فضای نام Aspose.Slides منتقل شد**