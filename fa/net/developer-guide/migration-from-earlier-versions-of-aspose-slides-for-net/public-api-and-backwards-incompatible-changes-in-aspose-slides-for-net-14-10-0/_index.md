---
title: API عمومی و تغییرات ناسازگار با نسخه قبلی در Aspose.Slides برای .NET 14.10.0
linktitle: Aspose.Slides برای .NET 14.10.0
type: docs
weight: 120
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/
keywords:
- مهاجرت
- کدهای میراثی
- کدهای مدرن
- رویکرد میراثی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات مخرب در Aspose.Slides برای .NET را مرور کنید تا بتوانید به‌صورت روان راه‌حل‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}} 

این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و موارد مشابه که [اضافه‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) یا [حذف‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-10-0/) هستند و سایر تغییرات معرفی‌شده با Aspose.Slides for .NET 14.10.0 API را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات عمومی API**
#### **نوع فیلد Footer در Aspose.Slides.FieldType اضافه شده است**
نوع فیلد Footer برای امکان‌پذیری ایجاد فیلدهای این نوع و برای سریال‌سازی صحیح ارائه اضافه شده است.
#### **عنصر شمارشی ShapeElementFillSource.Own حذف شده است**
عنصر شمارشی ShapeElementFillSource.Own به‌عنوان تکراری حذف شده است. به جای آن از ShapeElementFillSource.Shape استفاده کنید.
#### **متدهایی برای حذف نقاط داده نمودار و دسته‌ها اضافه شده‌اند**
متدهای زیر که امکان حذف نقطه داده نمودار از مجموعه نقاط داده را فراهم می‌کنند، اضافه شده‌اند:

IChartDataPointCollection.Remove(IChartDataPoint)
IChartDataPoint.Report()

متد زیر که امکان حذف دسته‌بندی نمودار از مجموعه مربوطه را فراهم می‌کند، اضافه شده است:

IChartCategory.Remove()

``` csharp

 using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);
    chart.ChartData.Categories[0].Remove(); //حذف با ChartCategory.Remove()
    chart.ChartData.Categories.Remove(chart.ChartData.Categories[0]); //حذف با ChartCategoryCollection.Remove()
    foreach (var ser in chart.ChartData.Series)
    {
        ser.DataPoints[0].Remove();//حذف با ChartDataPoint.Remove()
        ser.DataPoints.Remove(ser.DataPoints[0]);//ChartDataPointCollection.Remove()
    }
    pres.Save(outPath, SaveFormat.Pptx);
}
``` 
#### **ویژگی‌های منسوخ‌شده Aspose.Slides.ParagraphFormat حذف شده‌اند**
ویژگی‌های BulletChar، BulletColor، BulletColorFormat، BulletFont، BulletHeight، BulletType، IsBulletHardColor، IsBulletHardFont، NumberedBulletStartWith و NumberedBulletStyle حذف شده‌اند. این ویژگی‌ها مدت‌ها پیش به‌عنوان منسوخ علامت‌دار شده بودند.
#### **سازنده‌های غیرقابل استفاده و منسوخ‌شده حذف شده‌اند**
سازنده‌های زیر حذف شده‌اند:

- Aspose.Slides.Effects.AlphaBiLevel(System.Single)
- Aspose.Slides.Effects.AlphaModulateFixed(System.Single)
- Aspose.Slides.Effects.AlphaReplace(System.Single)
- Aspose.Slides.Effects.BiLevel(System.Single)
- Aspose.Slides.Effects.Blur(System.Double,System.Boolean)
- Aspose.Slides.Effects.HSL(System.Single,System.Single,System.Single)
- Aspose.Slides.Effects.ImageTransformOperation(Aspose.Slides.Effects.ImageTransformOperationCollection)
- Aspose.Slides.Effects.Luminance(System.Single,System.Single)
- Aspose.Slides.Effects.Tint(System.Single,System.Single)
- Aspose.Slides.PortionFormat(Aspose.Slides.ParagraphFormat)
- Aspose.Slides.PortionFormat(Aspose.Slides.Portion)
- Aspose.Slides.PortionFormat(Aspose.Slides.PortionFormat)