---
title: Veřejné API a zpětně nekompatibilní změny v Aspose.Slides pro .NET 14.6.0
linktitle: Aspose.Slides pro .NET 14.6.0
type: docs
weight: 80
url: /cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/
keywords:
- migrace
- zastaralý kód
- moderní kód
- zastaralý přístup
- moderní přístup
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Prozkoumejte aktualizace veřejného API a změny, které přerušují kompatibilitu v Aspose.Slides pro .NET, abyste hladce migrovali své řešení pro prezentace PowerPoint PPT, PPTX a ODP."
---
{{% alert color="primary" %}} 

Tato stránka uvádí všechny [přidané](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) třídy, metody, vlastnosti a další, všechna nová [omezení](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) a další [změny](/slides/cs/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) zavedené v API Aspose.Slides pro .NET 14.6.0.

{{% /alert %}} 
## **Změny veřejného API**
### **Přidaná rozhraní, metody a vlastnosti**
#### **Přidáno rozhraní Aspose.Slides.Charts.IErrorBarsFormat**
Toto představuje chybové pruhy řady grafu.

V případě vlastního typu hodnoty, pro zadání hodnoty použijte vlastnost ErrorBarCustomValues konkrétního datového bodu v kolekci DataPoints řady.

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
#### **Přidáno rozhraní Aspose.Slides.Charts.IErrorBarsCustomValues**
Když je vlastnost IErrorBarsFormat.ValueType rovna Custom, pro zadání hodnoty použijte vlastnost ErrorBarCustomValues konkrétního datového bodu v kolekci DataPoints.

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
#### **Přidáno rozhraní Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues**
Určuje typy hodnot v seznamu vlastností ChartDataPoint.ErrorBarsCustomValues.

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
#### **Přidány metody Aspose.Slides.IShapeCollection.AddClone(...), a .InsertClone(...)**
Následující metody přidají/vloží kopii určeného tvaru do kolekce. 

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
#### **Přidány výčet ViewType, rozhraní IViewProperties, třída ViewProperties a vlastnosti IPresentation.ViewProperties**
IPresentation.ViewProperty umožňuje vývojářům změnit typ zobrazení prezentace a viditelnost poznámek při otevření prezentace v PowerPointu.

``` csharp

 using(Presentation p = new Presentation())
{
    p.ViewProperties.LastView = ViewType.SlideMasterView;
}
```