---
title: API عمومی و تغییرات ناسازگار به عقب در Aspose.Slides برای .NET 15.2.0
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
description: "به‌روز رسانی‌های API عمومی و تغییرات شکسته‌کننده در Aspose.Slides برای .NET را بررسی کنید تا به‌صورت روان برنامه‌های ارائه PowerPoint PPT، PPTX و ODP خود را مهاجرت دهید."
---
{{% alert color="primary" %}} 
این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و موارد مشابه که [اضافه‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) یا [حذف‌شده](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-2-0/) هستند و سایر تغییرات معرفی‌شده در API Aspose.Slides برای .NET 15.2.0 را فهرست می‌کند.
{{% /alert %}} 
## **تغییرات API عمومی**
#### **متدهای AddDataPointForDoughnutSeries اضافه شده‌اند**
دو overload از متد IChartDataPointCollection.AddDataPointForDoughnutSeries() برای افزودن نقاط داده به سری‌های نوع نمودار دونات اضافه شده‌اند.
#### **کلاس Aspose.Slides.SmartArt.SmartArtShape از کلاس Aspose.Slides.GeometryShape ارث‌برده است**
کلاس Aspose.Slides.SmartArt.SmartArtShape از کلاس Aspose.Slides.GeometryShape ارث‌برده شده است. این تغییر مدل شیء Aspose.Slides را بهبود می‌بخشد و ویژگی‌های جدیدی به کلاس SmartArtShape اضافه می‌کند.
#### **متدهایی برای حذف نقطه داده نمودار و دسته‌بندی نمودار بر اساس شاخص اضافه شده‌اند**
متد IChartDataPointCollection.RemoveAt(int index) برای حذف نقطه داده نمودار بر اساس شاخص آن اضافه شده است.
متد IChartCategoryCollection.RemoveAt(int index) برای حذف دسته‌بندی نمودار بر اساس شاخص آن اضافه شده است.
#### **مقدار PptXPptY به شمارش Aspose.Slides.Animation.PropertyType اضافه شده است**
مقدار PptXPptY در چارچوب رفع مشکل سریال‌سازی به شمارش Aspose.Slides.Animation.PropertyType اضافه شده است.
#### **متد System.Drawing.Color GetAutomaticSeriesColor() به Aspose.Slides.Charts.IChartSeries اضافه شده است**
متد GetAutomaticSeriesColor یک رنگ خودکار برای سری بر اساس شاخص سری و سبک نمودار برمی‌گرداند. این رنگ به‌طور پیش‌فرض استفاده می‌شود اگر FillType برابر NotDefined باشد.
``` csharp



using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)

    {

        chart.ChartData.Series[i].GetAutomaticSeriesColor();

    }

}
```