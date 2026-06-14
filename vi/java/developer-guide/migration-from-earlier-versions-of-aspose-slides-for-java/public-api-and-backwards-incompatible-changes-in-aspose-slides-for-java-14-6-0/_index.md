---
title: API công cộng và các thay đổi không tương thích ngược trong Aspose.Slides cho Java 14.6.0
linktitle: Aspose.Slides cho Java 14.6.0
type: docs
weight: 50
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/
keywords:
- di chuyển
- mã di sản
- mã hiện đại
- phương pháp di sản
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Xem lại các cập nhật API công cộng và những thay đổi gây phá vỡ trong Aspose.Slides cho Java để di chuyển suôn sẻ các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính [được thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/) và các yếu tố khác, bất kỳ hạn chế mới nào và các thay đổi khác được giới thiệu trong API Aspose.Slides for Java 14.6.0.

{{% /alert %}} 
## **Thay đổi API công cộng**
### **Các lớp, phương thức, giao diện và liệt kê được thêm**
#### **Đã thêm Enumeration ViewType, Interface IViewProperties, Class ViewProperties và Method IPresentation.getViewProperties()**
Phương thức IPresentation.getViewProperty() cung cấp quyền truy cập vào IViewProperties và cho phép bạn thay đổi loại chế độ xem bài thuyết trình và hiển thị ghi chú khi một bài thuyết trình được mở trong Microsoft PowerPoint.

``` java

 Presentation p = new Presentation();

p.getViewProperties().setLastView(ViewType.SlideMasterView);

```
#### **Đã thêm các phương thức Aspose.Slides.IShapeCollection.addClone(...) và .insertClone(...)**
Các phương thức

- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y, float width, float height),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y), and
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y, float width, float height)

thêm/chèn một bản sao của hình dạng được chỉ định vào bộ sưu tập. 

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
#### **Đã thêm Interface Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues**
Giao diện này xác định các loại giá trị trong danh sách thuộc tính ChartDataPoint.ErrorBarsCustomValues.

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
#### **Đã thêm Interface Aspose.Slides.Charts.IErrorBarsCustomValues**
Khi thuộc tính IErrorBarsFormat.ValueType bằng Custom, để chỉ định giá trị hãy sử dụng thuộc tính ErrorBarCustomValues của điểm dữ liệu cụ thể trong bộ sưu tập DataPoints của chuỗi.

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
#### **Đã thêm Interface Aspose.Slides.Charts.IErrorBarsFormat**
Giao diện này đại diện cho các thanh lỗi của chuỗi biểu đồ.
Trong trường hợp loại giá trị tùy chỉnh, để chỉ định giá trị hãy sử dụng thuộc tính ErrorBarCustomValues của một điểm dữ liệu cụ thể trong bộ sưu tập DataPoins của chuỗi.

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