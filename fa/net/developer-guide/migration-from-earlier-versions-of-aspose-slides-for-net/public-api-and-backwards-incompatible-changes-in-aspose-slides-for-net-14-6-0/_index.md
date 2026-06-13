---
title: API عمومی و تغییرات ناسازگار با عقب‌گرد در Aspose.Slides برای .NET 14.6.0
linktitle: Aspose.Slides برای .NET 14.6.0
type: docs
weight: 80
url: /fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/
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
description: "به‌روزرسانی‌های API عمومی و تغییرات شکست‌پذیر در Aspose.Slides برای .NET را بررسی کنید تا راه‌حل‌های ارائه PowerPoint (PPT، PPTX) و ODP خود را به‌صورت روان مهاجرت دهید."
---
{{% alert color="primary" %}} 

این صفحه تمام کلاس‌ها، متدها، ویژگی‌ها و موارد مشابهی که [اضافه](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) شده‌اند، هرگونه [محدودیت](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) جدید و سایر [تغییرات](/slides/fa/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) معرفی‌شده با API Aspose.Slides برای .NET 14.6.0 را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**
### **رابط‌ها، متدها و ویژگی‌های اضافه‌شده**
#### **رابط Aspose.Slides.Charts.IErrorBarsFormat اضافه شد**
این نمایانگر نوارهای خطا در سری‌های نمودار است.

در صورت نوع مقدار سفارشی، برای مشخص کردن مقدار، از ویژگی ErrorBarCustomValues نقطه داده خاص در مجموعه DataPoints سری استفاده کنید.

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    IErrorBarsFormat errBarX = chart.ChartData.Series[0].ErrorBarsXFormat;

    IErrorBarsFormat errBarY = chart.ChartData.Series[0].ErrorBarsYFormat;

    errBarX.IsVisible = true;

    errBarY.IsVisible = true;

    errBarX.ValueType = ErrorBarValueType.Fixed;

    errBarX.Value = 0.1f;

    errBarY.ValueType = ErrorBarValueType.Percentage;

    errBarY.Value = 5;

    errBarX.Type = ErrorBarType.Plus;

    errBarY.Format.Line.Width = 2;

    errBarX.HasEndCap = true;

    pres.Save("ErrorBars.pptx", SaveFormat.Pptx);

}

``` 
#### **رابط Aspose.Slides.Charts.IErrorBarsCustomValues اضافه شد**
زمانی که ویژگی IErrorBarsFormat.ValueType برابر با Custom باشد، برای مشخص کردن مقدار، از ویژگی ErrorBarCustomValues نقطه داده خاص در مجموعه DataPoints استفاده کنید.

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    IChartSeries series = chart.ChartData.Series[0];

    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;

    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;

    errBarX.IsVisible = true;

    errBarY.IsVisible = true;

    errBarX.ValueType = ErrorBarValueType.Custom;

    errBarY.ValueType = ErrorBarValueType.Custom;

    IChartDataPointCollection points = series.DataPoints;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    for (int i = 0; i < points.Count; i++)

    {

        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;

    }

    pres.Save("ErrorBarsCustomValues", SaveFormat.Pptx);

}

``` 
#### **رابط Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues اضافه شد**
انواع مقادیر را در لیست ویژگی‌های ChartDataPoint.ErrorBarsCustomValues مشخص می‌کند.

``` csharp

 using (Presentation pres = new Presentation())

{

    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Bubble, 50, 50, 400, 300, true);

    IChartSeries series = chart.ChartData.Series[0];

    IErrorBarsFormat errBarX = series.ErrorBarsXFormat;

    IErrorBarsFormat errBarY = series.ErrorBarsYFormat;

    errBarX.IsVisible = true;

    errBarY.IsVisible = true;

    errBarX.ValueType = ErrorBarValueType.Custom;

    errBarY.ValueType = ErrorBarValueType.Custom;

    IChartDataPointCollection points = series.DataPoints;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXPlusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForXMinusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYPlusValues = DataSourceType.DoubleLiterals;

    points.DataSourceTypeForErrorBarsCustomValues.DataSourceTypeForYMinusValues = DataSourceType.DoubleLiterals;

    for (int i = 0; i < points.Count; i++)

    {

        points[i].ErrorBarsCustomValues.XMinus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.XPlus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.YMinus.AsLiteralDouble = i + 1;

        points[i].ErrorBarsCustomValues.YPlus.AsLiteralDouble = i + 1;

    }

    pres.Save("ErrorBarsCustomValues", SaveFormat.Pptx);

}

``` 
#### **متدهای Aspose.Slides.IShapeCollection.AddClone(... ) و .InsertClone(... ) اضافه شدند**
متدهای زیر یک کپی از شکل مشخص‌شده را به مجموعه اضافه/درج می‌کنند. 

- Aspose.Slides.IShapeCollection.AddClone(IShape sourceShape)
- Aspose.Slides.IShapeCollection.AddClone(IShape sourceShape, float x, float y)
- Aspose.Slides.IShapeCollection.AddClone(IShape sourceShape, float x, float y, float width, float height)
- Aspose.Slides.IShapeCollection.InsertClone(int index, IShape sourceShape)
- Aspose.Slides.IShapeCollection.InsertClone(int index, IShape sourceShape, float x, float y)
- Aspose.Slides.IShapeCollection.InsertClone(int index, IShape sourceShape, float x, float y, float width, float height)

``` csharp

 using (Presentation srcPres = new Presentation(dataPath_ShapeCloning + "Source Frame.pptx"))

{

    IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;

    ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);

    ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);

    IShapeCollection destShapes = destSlide.Shapes;

    destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);

    destShapes.AddClone(sourceShapes[2]);

    destShapes.AddClone(sourceShapes[3], 50, 200, 50, 50);

    destShapes.AddClone(sourceShapes[4]);

    destShapes.AddClone(sourceShapes[5], 300, 300, 50, 200);

    destShapes.InsertClone(0, sourceShapes[0], 50, 150);

}

``` 
#### **Enum ViewType، رابط IViewProperties، کلاس ViewProperties و ویژگی‌های IPresentation.ViewProperties اضافه شدند**
ویژگی IPresentation.ViewProperty به توسعه‌دهندگان امکان می‌دهد نوع نمایش ارائه و نمایش یادداشت‌ها را زمانی که ارائه در PowerPoint باز می‌شود، تغییر دهند.

``` csharp

 using(Presentation p = new Presentation())

{

    p.ViewProperties.LastView = ViewType.SlideMasterView;

}

```