---
title: การเปลี่ยนแปลง Public API และการไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ Java 14.6.0
linktitle: Aspose.Slides สำหรับ Java 14.6.0
type: docs
weight: 50
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/
keywords:
- การย้าย
- โค้ดเดิม
- โค้ดสมัยใหม่
- วิธีการเดิม
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "รีวิวการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้ไม่เข้ากันใน Aspose.Slides สำหรับ Java เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ [เพิ่ม](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-6-0/) รวมถึงข้อจำกัดใหม่และการเปลี่ยนแปลงอื่น ๆ ที่นำเสนอด้วย Aspose.Slides for Java 14.6.0 API

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
### **คลาส, เมธอด, อินเทอร์เฟซ และ Enumerations ที่เพิ่มขึ้น**
#### **เพิ่ม Enumeration ViewType, อินเทอร์เฟซ IViewProperties, คลาส ViewProperties และเมธอด IPresentation.getViewProperties()**
เมธอด IPresentation.getViewProperty() ให้การเข้าถึง IViewProperties และอนุญาตให้คุณเปลี่ยนประเภทการแสดงผลของงานนำเสนอและการมองเห็นหมายเหตุเมื่อเปิดงานนำเสนอใน Microsoft PowerPoint

``` java

 Presentation p = new Presentation();

p.getViewProperties().setLastView(ViewType.SlideMasterView);

```
#### **เพิ่มเมธอด Aspose.Slides.IShapeCollection.addClone(...) และ .insertClone(...)**
เมธอด

- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y),
- Aspose.Slides.IShapeCollection.addClone(IShape sourceShape, float x, float y, float width, float height),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape),
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y), and
- Aspose.Slides.IShapeCollection.insertClone(int index, IShape sourceShape, float x, float y, float width, float height)

เพิ่ม/แทรกสำเนาของรูปทรงที่ระบุลงในคอลเลกชัน

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
#### **เพิ่มอินเทอร์เฟซ Aspose.Slides.Charts.IDataSourceTypeForErrorBarsCustomValues**
อินเทอร์เฟซนี้ระบุประเภทของค่าที่อยู่ในรายการคุณสมบัติ ChartDataPoint.ErrorBarsCustomValues

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
#### **เพิ่มอินเทอร์เฟซ Aspose.Slides.Charts.IErrorBarsCustomValues**
เมื่อคุณสมบัติ IErrorBarsFormat.ValueType มีค่าเป็น Custom เพื่อตั้งค่าค่า ให้ใช้คุณสมบัติ ErrorBarCustomValues ของจุดข้อมูลเฉพาะในคอลเลกชัน DataPoints ของซีรีส์

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
#### **เพิ่มอินเทอร์เฟซ Aspose.Slides.Charts.IErrorBarsFormat**
อินเทอร์เฟซนี้แสดงถึงแถบความคลาดเคลื่อนของชุดข้อมูลแผนภูมิ
ในกรณีที่ประเภทค่าคือ custom เพื่อระบุค่า ให้ใช้คุณสมบัติ ErrorBarCustomValues ของจุดข้อมูลเฉพาะในคอลเลกชัน DataPoins ของซีรีส์

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