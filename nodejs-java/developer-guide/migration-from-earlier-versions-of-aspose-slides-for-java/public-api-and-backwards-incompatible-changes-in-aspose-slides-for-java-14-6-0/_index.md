---
title: Public API and Backwards Incompatible Changes in Aspose.Slides for Java 14.6.0
type: docs
weight: 50
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/
---

{{% alert color="primary" %}} 

This page lists all [added](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/) classes, methods, properties and so on, any new restrictions and other changes introduced with the Aspose.Slides for Java 14.6.0 API.

{{% /alert %}} 
## **Public API Changes**
### **Added Classes, Methods, Interfaces and Enumerations**
#### **Added ViewType Enumeration, IViewProperties Interface, ViewProperties Class and IPresentation.getViewProperties() Method**
The IPresentation.getViewProperty() method provides access to IViewProperties and allows you to change the presentation view type and notes visibility when a presentation is opened in Microsoft PowerPoint.

```javascript
    var p = new  com.aspose.slides.Presentation();
    p.getViewProperties().setLastView(com.aspose.slides.ViewType.SlideMasterView);
```
#### **Added the Aspose.Slides.IShapeCollection.addClone(...) and .insertClone(...) Methods**
The methods

- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y, float width, float height),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y), and
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y, float width, float height)

adds/inserts a copy of a specified shape into the collection. 

```javascript
    var srcPres = new  com.aspose.slides.Presentation("data/Source Frame.pptx");
    var sourceShapes = srcPres.getSlides().get_Item(0).getShapes();
    var blankLayout = srcPres.getMasters().get_Item(0).getLayoutSlides().getByType(com.aspose.slides.SlideLayoutType.Blank);
    var destSlide = srcPres.getSlides().addEmptySlide(blankLayout);
    var destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.addClone(sourceShapes.get_Item(3), 50, 200, 50, 50);
    destShapes.addClone(sourceShapes.get_Item(4));
    destShapes.addClone(sourceShapes.get_Item(5), 300, 300, 50, 200);
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);
```
#### **Added the Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues Interface**
This interface specifies the types of values in the ChartDataPoint.ErrorBarsCustomValues properties list.

```javascript
    var pres = new  com.aspose.slides.Presentation();
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(com.aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.setVisible(true);
    errBarY.setVisible(true);
    errBarX.setValueType(com.aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(com.aspose.slides.ErrorBarValueType.Custom);
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(com.aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(com.aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(com.aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(com.aspose.slides.DataSourceType.DoubleLiterals);
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    pres.save("data/ErrorBarsCustomValues.pptx", com.aspose.slides.SaveFormat.Pptx);
```
#### **Added the Aspose.Slides.Charts.IErrorBarsCustomValues Interface**
When the IErrorBarsFormat.ValueType property is equal to Custom to specify value use the ErrorBarCustomValues property of the specific data point in the DataPoints collection of the series.

```javascript
    var pres = new  com.aspose.slides.Presentation();
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(com.aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var errBarX = series.getErrorBarsXFormat();
    var errBarY = series.getErrorBarsYFormat();
    errBarX.setVisible(true);
    errBarY.setVisible(true);
    errBarX.setValueType(com.aspose.slides.ErrorBarValueType.Custom);
    errBarY.setValueType(com.aspose.slides.ErrorBarValueType.Custom);
    var points = series.getDataPoints();
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXPlusValues(com.aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForXMinusValues(com.aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYPlusValues(com.aspose.slides.DataSourceType.DoubleLiterals);
    points.getDataSourceTypeForErrorBarsCustomValues().setDataSourceTypeForYMinusValues(com.aspose.slides.DataSourceType.DoubleLiterals);
    for (var i = 0; i < points.size(); i++) {
        points.get_Item(i).getErrorBarsCustomValues().getXMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getXPlus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYMinus().setAsLiteralDouble(i + 1);
        points.get_Item(i).getErrorBarsCustomValues().getYPlus().setAsLiteralDouble(i + 1);
    }
    pres.save("data/ErrorBarsCustomValues.pptx", com.aspose.slides.SaveFormat.Pptx);
```
#### **Added the Aspose.Slides.Charts.IErrorBarsFormat Interface**
This interface represents error bars of chart series.
In case of custom value type to specify value use the ErrorBarCustomValues property of a specific data point in the DataPoins collection of the series.

```javascript
    var pres = new  com.aspose.slides.Presentation();
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(com.aspose.slides.ChartType.Bubble, 50, 50, 400, 300, true);
    var errBarX = chart.getChartData().getSeries().get_Item(0).getErrorBarsXFormat();
    var errBarY = chart.getChartData().getSeries().get_Item(0).getErrorBarsYFormat();
    errBarX.setVisible(true);
    errBarY.setVisible(true);
    errBarX.setValueType(com.aspose.slides.ErrorBarValueType.Fixed);
    errBarX.setValue(0.1);
    errBarY.setValueType(com.aspose.slides.ErrorBarValueType.Percentage);
    errBarY.setValue(5);
    errBarX.setType(com.aspose.slides.ErrorBarType.Plus);
    errBarY.getFormat().getLine().setWidth(2);
    errBarX.setEndCap(true);
    pres.save("data/ErrorBars.pptx", com.aspose.slides.SaveFormat.Pptx);
```
