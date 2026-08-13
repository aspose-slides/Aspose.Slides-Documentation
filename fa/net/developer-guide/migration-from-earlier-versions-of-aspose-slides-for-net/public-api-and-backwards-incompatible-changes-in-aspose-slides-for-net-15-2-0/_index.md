---
title: API عمومی و تغییرات ناسازگار معکوس در Aspose.Slides برای .NET 15.2.0
linktitle: Aspose.Slides برای .NET 15.2.0
type: docs
weight: 140
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/
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
description: "به‌روزرسانی‌های API عمومی و تغییرات سازگاری‌شکنی در Aspose.Slides برای .NET را بررسی کنید تا بتوانید به‌سادگی راه‌حل‌های ارائه PowerPoint (PPT, PPTX) و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}} 
این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و موارد مشابه که [اضافه](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) یا [حذف](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) شده‌اند، و سایر تغییرات معرفی‌شده در API Aspose.Slides برای .NET نسخه 15.2.0 را فهرست می‌کند.
{{% /alert %}} 
## **تغییرات API عمومی**
#### **متدهای AddDataPointForDoughnutSeries اضافه شده‌اند**
دو overload از متد IChartDataPointCollection.AddDataPointForDoughnutSeries() برای افزودن نقاط داده به سری‌های نوع نمودار Doughnut اضافه شده‌اند.
#### **کلاس Aspose.Slides.SmartArt.SmartArtShape از کلاس Aspose.Slides.GeometryShape ارث‌بری شده است**
کلاس Aspose.Slides.SmartArt.SmartArtShape از کلاس Aspose.Slides.GeometryShape ارث‌بری شده است. این تغییر مدل شیء Aspose.Slides را بهبود می‌بخشد و ویژگی‌های جدیدی به کلاس SmartArtShape اضافه می‌کند.
#### **متدهایی برای حذف نقطه داده نمودار و دسته‌بندی نمودار بر اساس اندیس اضافه شده‌اند**
متد IChartDataPointCollection.RemoveAt(int index) برای حذف نقطه داده نمودار بر اساس اندیس آن اضافه شده است.
متد IChartCategoryCollection.RemoveAt(int index) برای حذف دسته‌بندی نمودار بر اساس اندیس آن اضافه شده است.
#### **مقدار PptXPptY به شمارش Aspose.Slides.Animation.PropertyType اضافه شده است**
مقدار PptXPptY در چارچوب رفع یک مشکل سری‌سازی به شمارش Aspose.Slides.Animation.PropertyType اضافه شده است.
#### **متد System.Drawing.Color GetAutomaticSeriesColor() به Aspose.Slides.Charts.IChartSeries اضافه شده است**
متد GetAutomaticSeriesColor یک رنگ خودکار برای سری بر اساس اندیس سری و سبک نمودار باز می‌گرداند. این رنگ به طور پیش‌فرض استفاده می‌شود اگر FillType برابر NotDefined باشد.
``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```