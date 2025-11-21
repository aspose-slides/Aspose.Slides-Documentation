---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة في Aspose.Slides لـ .NET 14.6.0
linktitle: Aspose.Slides لـ .NET 14.6.0
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
description: "استعراض تحديثات واجهة برمجة التطبيقات العامة والتغييرات المكسرة في Aspose.Slides لـ .NET لترحيل حلول عروض PowerPoint (PPT, PPTX) و ODP بسلاسة."
---

{{% alert color="primary" %}} 

تُظهر هذه الصفحة جميع الفئات والطرق والخصائص وما إلى ذلك التي تم [إضافتها](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/)، وأي [قيود](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) جديدة، وغيرها من [التغييرات](/slides/ar/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) التي تم تقديمها مع Aspose.Slides for .NET 14.6.0 API.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **الواجهات والطرق والخصائص التي تم إضافتها**
#### **تمت إضافة الواجهة Aspose.Slides.Charts.IErrorBarsFormat**
تمثل هذه شريط الأخطاء لسلسلة المخطط.

في حالة نوع القيمة المخصصة، لتحديد قيمة، استخدم الخاصية ErrorBarCustomValues للنقطة البيانات المحددة في مجموعة DataPoints للسلسلة.

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
#### **تمت إضافة الواجهة Aspose.Slides.Charts.IErrorBarsCustomValues**
عندما تكون الخاصية IErrorBarsFormat.ValueType مساوية لـ Custom، لتحديد قيمة، استخدم الخاصية ErrorBarCustomValues للنقطة البيانات المحددة في مجموعة DataPoints.

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
#### **تمت إضافة الواجهة Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues**
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
#### **تمت إضافة الأساليب Aspose.Slides.IShapeCollection.AddClone(...), و .InsertClone(...)**
تضيف/تدرج الأساليب التالية نسخة من الشكل المحدد إلى المجموعة. 

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
#### **تمت إضافة تعداد ViewType، الواجهة IViewProperties، الفئة ViewProperties وخصائص IPresentation.ViewProperties**
تتيح خاصية IPresentation.ViewProperty للمطورين تغيير نوع عرض العرض وإمكانية رؤية الملاحظات عند فتح العرض في PowerPoint.

``` csharp

 using(Presentation p = new Presentation())

{

    p.ViewProperties.LastView = ViewType.SlideMasterView;

}

```