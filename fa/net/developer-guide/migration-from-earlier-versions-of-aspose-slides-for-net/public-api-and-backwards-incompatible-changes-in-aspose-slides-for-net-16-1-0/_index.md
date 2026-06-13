---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای .NET 16.1.0
linktitle: Aspose.Slides برای .NET 16.1.0
type: docs
weight: 220
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- پاورپوینت
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات ناسازگار در Aspose.Slides برای .NET را بررسی کنید تا به‌صورت یکپارچه راه‌حل‌های ارائه PowerPoint (PPT, PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}} 

این صفحه تمام کلاس‌ها، متدها، خصوصیات و موارد مشابهی که [اضافه‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) یا [حذف‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-1-0/) هستند، و سایر تغییراتی که در API Aspose.Slides برای .NET نسخه 16.1.0 معرفی شده‌اند را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**


#### **ویژگی RotationAngle به اینترفیس‌های IChartTextBlockFormat و ITextFrameFormat اضافه شد**
ویژگی RotationAngle به اینترفیس‌های Aspose.Slides.Charts.IChartTextBlockFormat و Aspose.Slides.ITextFrameFormat اضافه شده است.
این ویژگی چرخش سفارشی را که بر روی متن داخل کادر مرزی اعمال می‌شود، مشخص می‌کند.

``` csharp

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
#### **OdpException از Aspose.Slides.Odp به فضای نام Aspose.Slides منتقل شد**