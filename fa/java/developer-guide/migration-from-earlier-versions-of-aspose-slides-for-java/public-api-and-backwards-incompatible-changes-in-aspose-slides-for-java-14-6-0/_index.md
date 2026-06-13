---
title: API عمومی و تغییرات ناسازگار با نسخه‌های قبلی در Aspose.Slides برای جاوا 14.6.0
linktitle: Aspose.Slides برای جاوا 14.6.0
type: docs
weight: 50
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/
keywords:
- مهاجرت
- کد قدیمی
- کد مدرن
- رویکرد قدیمی
- رویکرد مدرن
- پاورپوینت
- سند باز
- ارائه
- جاوا
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات شکسته‌کننده در Aspose.Slides برای جاوا را مرور کنید تا راه‌حل‌های ارائه PowerPoint PPT، PPTX و ODP خود را به‌صورت روان مهاجرت کنید."
---
{{% alert color="primary" %}} 

این صفحه تمام [added](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/) کلاس‌ها، متدها، ویژگی‌ها و موارد مشابه، هر محدودیت جدید و سایر تغییرات معرفی‌شده در API Aspose.Slides for Java 14.6.0 را فهرست می‌کند.

{{% /alert %}} 
## **تغییرات API عمومی**
### **کلاس‌ها، متدها، اینترفیس‌ها و شمارش‌ها اضافه‌شده**
#### **شمارش ViewType، اینترفیس IViewProperties، کلاس ViewProperties و متد IPresentation.getViewProperties() اضافه شدند**
متد IPresentation.getViewProperty() دسترسی به IViewProperties را فراهم می‌کند و به شما اجازه می‌دهد نوع نمایش ارائه و قابلیت نمایش یادداشت‌ها را زمانی که ارائه در Microsoft PowerPoint باز می‌شود، تغییر دهید.

``` java

 Presentation p = new Presentation();

p.getViewProperties().setLastView(ViewType.SlideMasterView);

```
#### **متدهای Aspose.Slides.IShapeCollection.addClone(...) و .insertClone(...) اضافه شدند**
این متدها

- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y, float width, float height),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y), and
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y, float width, float height)

یک نسخه از شکل مشخص‌شده را به مجموعه اضافه/درج می‌کند. 

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
#### **اینترفیس Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues اضافه شد**
این اینترفیس انواع مقادیر موجود در فهرست ویژگی‌های ChartDataPoint.ErrorBarsCustomValues را مشخص می‌کند.

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
#### **اینترفیس Aspose.Slides.Charts.IErrorBarsCustomValues اضافه شد**
هنگامی که ویژگی IErrorBarsFormat.ValueType برابر با Custom باشد، برای تعیین مقدار از ویژگی ErrorBarCustomValues نقطه داده خاص در مجموعه DataPoints سری استفاده کنید.

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
#### **اینترفیس Aspose.Slides.Charts.IErrorBarsFormat اضافه شد**
این اینترفیس نمایانگر نوارهای خطای سری نمودار است.
در صورت استفاده از نوع مقدار سفارشی، برای تعیین مقدار از ویژگی ErrorBarCustomValues نقطه داده خاص در مجموعه DataPoins سری استفاده کنید.

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