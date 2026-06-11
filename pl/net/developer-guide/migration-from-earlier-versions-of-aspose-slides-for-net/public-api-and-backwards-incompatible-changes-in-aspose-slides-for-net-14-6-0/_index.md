---
title: Publiczne API i zmiany niekompatybilne wstecz w Aspose.Slides dla .NET 14.6.0
linktitle: Aspose.Slides dla .NET 14.6.0
type: docs
weight: 80
url: /pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/
keywords:
- migracja
- kod legacy
- nowoczesny kod
- podejście legacy
- nowoczesne podejście
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Przejrzyj aktualizacje publicznego API oraz zmiany niekompatybilne w Aspose.Slides dla .NET, aby płynnie migrować rozwiązania prezentacji PowerPoint PPT, PPTX i ODP."
---
{{% alert color="primary" %}} 

Ta strona wymienia wszystkie [dodane](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) klasy, metody, własności itd., wszelkie nowe [ograniczenia](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) i inne [zmiany](/slides/pl/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) wprowadzone w API Aspose.Slides dla .NET 14.6.0.

{{% /alert %}} 
## **Zmiany w publicznym API**
### **Dodane interfejsy, metody i własności**
#### **Dodano interfejs Aspose.Slides.Charts.IErrorBarsFormat**
Reprezentuje paski błędów serii wykresu.

W przypadku niestandardowego typu wartości, aby określić wartość, użyj właściwości ErrorBarCustomValues konkretnego punktu danych w kolekcji DataPoints serii.

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
#### **Dodano interfejs Aspose.Slides.Charts.IErrorBarsCustomValues**
Gdy właściwość IErrorBarsFormat.ValueType ma wartość Custom, aby określić wartość, użyj właściwości ErrorBarCustomValues konkretnego punktu danych w kolekcji DataPoints.

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
#### **Dodano interfejs Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues**
Określa typy wartości w liście właściwości ChartDataPoint.ErrorBarsCustomValues.

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
#### **Dodano metody Aspose.Slides.IShapeCollection.AddClone(...), oraz .InsertClone(...)**
Poniższe metody dodają/wstawiają kopię określonego kształtu do kolekcji. 

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
#### **Dodano wyliczenie ViewType, interfejs IViewProperties, klasę ViewProperties oraz własności IPresentation.ViewProperties**
IPresentation.ViewProperty umożliwia deweloperom zmianę typu widoku prezentacji oraz widoczności notatek, gdy prezentacja jest otwierana w programie PowerPoint.

``` csharp

 using(Presentation p = new Presentation())

{

    p.ViewProperties.LastView = ViewType.SlideMasterView;

}

```