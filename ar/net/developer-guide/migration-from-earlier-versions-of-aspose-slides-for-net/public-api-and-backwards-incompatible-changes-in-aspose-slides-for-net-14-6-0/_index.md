---
title: "واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة للوراء في Aspose.Slides for .NET 14.6.0"
linktitle: "Aspose.Slides لـ .NET 14.6.0"
type: docs
weight: 80
url: /ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/
keywords:
- ترحيل
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "راجع تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides لـ .NET لتتمكن من ترحيل حلول العروض التقديمية PowerPoint PPT، PPTX و ODP بسلاسة."
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع الفئات والطرق والخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) وأي [قيود](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) جديدة و[التغييرات](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) الأخرى التي تم تقديمها مع Aspose.Slides for .NET 14.6.0 API.

{{% /alert %}} 
## **التغييرات العامة لواجهة برمجة التطبيقات**
### **الواجهات والطرق والخصائص المضافة**
#### **تمت إضافة واجهة Aspose.Slides.Charts.IErrorBarsFormat**
تمثل هذه الأخطاء الشريطية لسلسلة المخطط.

في حالة نوع القيمة المخصصة، لتحديد قيمة، استخدم الخاصية ErrorBarCustomValues للنقطة البيانية المحددة في مجموعة DataPoints الخاصة بالسلسلة.

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
عند كون الخاصية IErrorBarsFormat.ValueType مساوية لـ Custom، لتحديد قيمة، استخدم الخاصية ErrorBarCustomValues للنقطة البيانية المحددة في مجموعة DataPoints.

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
يحدد أنواع القيم في قائمة خصائص ChartDataPoint.ErrorBarsCustomValues.

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
#### **تمت إضافة الأساليب Aspose.Slides.IShapeCollection.AddClone(...)، و .InsertClone(...)**
الطرق التالية تقوم بإضافة/إدراج نسخة من الشكل المحدد إلى المجموعة. 

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
#### **تمت إضافة تعداد ViewType، والواجهة IViewProperties، وفئة ViewProperties وخصائص IPresentation.ViewProperties**
تسمح خاصية IPresentation.ViewProperties للمطورين بتغيير نوع عرض العرض وإظهار الملاحظات عند فتح العرض في PowerPoint.

``` csharp

 using(Presentation p = new Presentation())

{

    p.ViewProperties.LastView = ViewType.SlideMasterView;

}

```