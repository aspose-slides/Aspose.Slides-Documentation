---
title: Publikt API och bakåt oförenliga ändringar i Aspose.Slides för .NET 14.6.0
linktitle: Aspose.Slides för .NET 14.6.0
type: docs
weight: 80
url: /sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/
keywords:
- migrering
- legacy-kod
- modern kod
- legacy-metod
- modern metod
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Granska uppdateringar av publikt API och brytande förändringar i Aspose.Slides för .NET för att smidigt migrera dina PowerPoint‑PPT, PPTX‑ och ODP‑presentationslösningar."
---
{{% alert color="primary" %}} 
Den här sidan listar alla [tillagda](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) klasser, metoder, egenskaper med mera, eventuella nya [restriktioner](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) och andra [ändringar](/slides/sv/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-6-0/) som introducerats med Aspose.Slides för .NET 14.6.0 API.
{{% /alert %}} 
## **Ändringar i publikt API**
### **Tillagda gränssnitt, metoder och egenskaper**
#### **Tillagt gränssnittet Aspose.Slides.Charts.IErrorBarsFormat**
Detta representerar felstaplar för diagramserier.

Om typen är anpassad, ange ett värde genom att använda egenskapen ErrorBarCustomValues för den specifika datapunkten i DataPoints‑samlingen för serien.

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
#### **Tillagt gränssnittet Aspose.Slides.Charts.IErrorBarsCustomValues**
När egenskapen IErrorBarsFormat.ValueType är lika med Custom, ange ett värde genom att använda egenskapen ErrorBarCustomValues för den specifika datapunkten i DataPoints‑samlingen.

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
#### **Tillagt gränssnittet Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues**
Anger typer av värden i listan för egenskapen ChartDataPoint.ErrorBarsCustomValues.

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
#### **Tillagda metoderna Aspose.Slides.IShapeCollection.AddClone(...), och .InsertClone(...)**
Följande metoder lägger till/infogar en kopia av en specificerad form i samlingen. 

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
#### **Tillagda ViewType Enum, IViewProperties Interface, ViewProperties-klass och IPresentation.ViewProperties-egenskaper**
IPresentation.ViewProperty låter utvecklare ändra presentationsvystyp och synlighet för anteckningar när en presentation öppnas i PowerPoint.

``` csharp

 using(Presentation p = new Presentation())

{

    p.ViewProperties.LastView = ViewType.SlideMasterView;

}

```