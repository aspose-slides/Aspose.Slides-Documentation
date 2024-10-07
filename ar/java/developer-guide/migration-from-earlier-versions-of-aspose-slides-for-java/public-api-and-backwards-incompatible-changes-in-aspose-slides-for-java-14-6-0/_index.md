---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 14.6.0
type: docs
weight: 50
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/
---

{{% alert color="primary" %}} 

تسرد هذه الصفحة جميع [المضاف](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/) من الفئات والطرق والخصائص وما إلى ذلك، أي قيود جديدة وتغييرات أخرى تم إدخالها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 14.6.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **الفئات والطرق والواجهات والتعدادات المضافة**
#### **التعداد ViewType المضاف، الواجهة IViewProperties، الفئة ViewProperties وطريقة IPresentation.getViewProperties()**
توفر طريقة IPresentation.getViewProperty() الوصول إلى IViewProperties وتسمح لك بتغيير نوع عرض العرض وظهور الملاحظات عند فتح العرض في Microsoft PowerPoint.

``` java

 Presentation p = new Presentation();

p.getViewProperties().setLastView(ViewType.SlideMasterView);

```
#### **إضافة طرق Aspose.Slides.IShapeCollection.addClone(...) و .insertClone(...)**
تضيف الطرق

- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y, float width, float height),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y)، و
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y, float width, float height)

نسخة/تدرج من شكل محدد إلى المجموعة.

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
#### **إضافة الواجهة Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues**
تحدد هذه الواجهة أنواع القيم في قائمة خصائص ChartDataPoint.ErrorBarsCustomValues.

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
#### **إضافة الواجهة Aspose.Slides.Charts.IErrorBarsCustomValues**
عندما تكون خاصية IErrorBarsFormat.ValueType تساوي Custom لتحديد القيمة استخدم خاصية ErrorBarCustomValues لنقطة البيانات المحددة في مجموعة DataPoints للسلسلة.

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
#### **إضافة الواجهة Aspose.Slides.Charts.IErrorBarsFormat**
تمثل هذه الواجهة أشرطة الأخطاء لسلاسل المخططات.
في حالة نوع القيمة المخصصة لتحديد القيمة استخدم خاصية ErrorBarCustomValues لنقطة البيانات المحددة في مجموعة DataPoins للسلسلة.

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