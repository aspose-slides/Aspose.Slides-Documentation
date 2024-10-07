---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ .NET 14.6.0
type: docs
weight: 80
url: /net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/
---

{{% alert color="primary" %}} 

تحتوي هذه الصفحة على جميع [الإضافات](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) من الفصول والأساليب والخصائص وما إلى ذلك، وأي [قيود](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) جديدة وتغييرات أخرى [مقدمة](/slides/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) مع واجهة برمجة التطبيقات Aspose.Slides لـ .NET 14.6.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **واجهات وأساليب وخصائص مضافة**
#### **تمت إضافة واجهة Aspose.Slides.Charts.IErrorBarsFormat**
تمثل هذه واجهات الخطأ لسلاسل الرسوم البيانية.

في حالة نوع القيمة المخصصة، لتحديد قيمة، استخدم خاصية ErrorBarCustomValues لنقطة البيانات المحددة في مجموعة DataPoints للسلسلة.

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
#### **تمت إضافة واجهة Aspose.Slides.Charts.IErrorBarsCustomValues**
عندما تكون خاصية IErrorBarsFormat.ValueType مساوية لـ Custom، لتحديد قيمة، استخدم خاصية ErrorBarCustomValues لنقطة البيانات المحددة في مجموعة DataPoints.

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
#### **تمت إضافة واجهة Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues**
تحدد أنواع القيم في قائمة الخصائص ChartDataPoint.ErrorBarsCustomValues.

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
#### **تمت إضافة أساليب Aspose.Slides.IShapeCollection.AddClone(...)، و.InsertClone(...)**
تعمل الأساليب التالية على إضافة/إدراج نسخة من شكل محدد في المجموعة.

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
#### **تمت إضافة enum ViewType، واجهة IViewProperties، فئة ViewProperties وخصائص IPresentation.ViewProperties**
تسمح خاصية IPresentation.ViewProperty للمطورين بتغيير نوع عرض العرض وظهور الملاحظات عند فتح العرض في PowerPoint.

``` csharp

 using(Presentation p = new Presentation())

{

    p.ViewProperties.LastView = ViewType.SlideMasterView;

}

```