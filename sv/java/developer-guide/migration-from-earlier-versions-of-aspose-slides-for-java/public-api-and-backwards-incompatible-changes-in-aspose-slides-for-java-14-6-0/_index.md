---
title: Offentlig API och bakåtinkompatibla ändringar i Aspose.Slides för Java 14.6.0
linktitle: Aspose.Slides för Java 14.6.0
type: docs
weight: 50
url: /sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/
keywords:
- migration
- gammal kod
- modern kod
- gammaldags tillvägagångssätt
- modernt tillvägagångssätt
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Granska offentliga API-uppdateringar och brytande förändringar i Aspose.Slides för Java för att smidigt migrera dina PowerPoint-PPT, PPTX- och ODP-presentationslösningar."
---
{{% alert color="primary" %}} 

Den här sidan listar alla [added](/slides/sv/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/) klasser, metoder, egenskaper osv., eventuella nya begränsningar och andra ändringar som införts med Aspose.Slides for Java 14.6.0 API.

{{% /alert %}} 
## **Offentliga API-ändringar**
### **Tillagda klasser, metoder, gränssnitt och uppräkningar**
#### **Tillagd ViewType‑enumeration, IViewProperties‑gränssnitt, ViewProperties‑klass och IPresentation.getViewProperties()-metod**
IPresentation.getViewProperty()-metoden ger åtkomst till IViewProperties och låter dig ändra presentationens vytyp och anteckningssynlighet när en presentation öppnas i Microsoft PowerPoint.

``` java

 Presentation p = new Presentation();

p.getViewProperties().setLastView(ViewType.SlideMasterView);

```
#### **Tillagda metoderna Aspose.Slides.IShapeCollection.addClone(...) och .insertClone(...)**
Metoderna

- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y, float width, float height),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y), and
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y, float width, float height)

lägger till/inserterar en kopia av en angiven form i samlingen. 

``` java

 Presentation srcPres = new Presentation("data/Source Frame.pptx");

IShapeCollection sourceShapes = srcPres.getSlides().get_Item(0).getShapes();

ILayoutSlide blankLayout = srcPres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);

ISlide destSlide = srcPres.getSlides().addEmptySlide(blankLayout);

IShapeCollection destShapes = destSlide.getShapes();

destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());

destShapes.addClone(sourceShapes.get_Item(2));

destShapes.addClone(sourceShapes.get_Item(3), 50, 200, 50, 50);

destShapes.addClone(sourceShapes.get_Item(4));

destShapes.addClone(sourceShapes.get_Item(5), 300, 300, 50, 200);

destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

```
#### **Tillagt Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues‑gränssnitt**
Detta gränssnitt specificerar typerna av värden i listan för ChartDataPoint.ErrorBarsCustomValues‑egenskaper. 

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

IErrorBarsFormat errBarX = series.getErrorBarsXFormat();

IErrorBarsFormat errBarY = series.getErrorBarsYFormat();

errBarX.setVisible(true);

errBarY.setVisible(true);

errBarX.setValueType(ErrorBarValueType.Custom);

errBarY.setValueType(ErrorBarValueType.Custom);

IChartDataPointCollection points = series.getDataPoints();

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(DataSourceType.DoubleLiterals);

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(DataSourceType.DoubleLiterals);

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(DataSourceType.DoubleLiterals);

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(DataSourceType.DoubleLiterals);

for (int i = 0; i < points.size(); i++)

{

    points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);

    points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);

    points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);

    points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);

}

pres.save("data/ErrorBarsCustomValues.pptx", SaveFormat.Pptx);

```
#### **Tillagt Aspose.Slides.Charts.IErrorBarsCustomValues‑gränssnitt**
När egenskapen IErrorBarsFormat.ValueType är lika med Custom för att specificera värde, använd ErrorBarCustomValues‑egenskapen för den specifika datapunkten i DataPoints‑samlingen för serien. 

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

IChartSeries series = chart.getChartData().getSeries().get_Item(0);

IErrorBarsFormat errBarX = series.getErrorBarsXFormat();

IErrorBarsFormat errBarY = series.getErrorBarsYFormat();

errBarX.setVisible(true);

errBarY.setVisible(true);

errBarX.setValueType(ErrorBarValueType.Custom);

errBarY.setValueType(ErrorBarValueType.Custom);

IChartDataPointCollection points = series.getDataPoints();

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(DataSourceType.DoubleLiterals);

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(DataSourceType.DoubleLiterals);

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(DataSourceType.DoubleLiterals);

points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(DataSourceType.DoubleLiterals);

for (int i = 0; i < points.size(); i++)

{

    points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);

    points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);

    points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);

    points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);

}

pres.save("data/ErrorBarsCustomValues.pptx", SaveFormat.Pptx);

```
#### **Tillagt Aspose.Slides.Charts.IErrorBarsFormat‑gränssnitt**
Detta gränssnitt representerar felstaplar för diagramserie.
Om värdetypen är Custom för att specificera värde, använd ErrorBarCustomValues‑egenskapen för en specifik datapunkt i DataPoins‑samlingen för serien. 

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 400, 300, true);

IErrorBarsFormat errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();

IErrorBarsFormat errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();

errBarX.setVisible(true);

errBarY.setVisible(true);

errBarX.setValueType(ErrorBarValueType.Fixed);

errBarX.setValue(0.1f);

errBarY.setValueType(ErrorBarValueType.Percentage);

errBarY.setValue(5);

errBarX.setType(ErrorBarType.Plus);

errBarY.getFormat().getLine().setWidth(2);

errBarX.setEndCap(true);

pres.save("data/ErrorBars.pptx", SaveFormat.Pptx);

```