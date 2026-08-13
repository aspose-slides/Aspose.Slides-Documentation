---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ Java 14.10.0
linktitle: Aspose.Slides สำหรับ Java 14.10.0
type: docs
weight: 90
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- การย้าย
- โค้ดเก่า
- โค้ดสมัยใหม่
- แนวทางดั้งเดิม
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ทบทวนการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้ไม่เข้ากันใน Aspose.Slides สำหรับ Java เพื่อให้คุณย้ายการแก้ไขโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ได้อย่างราบรื่น"
---
{{% alert color="info" %}} 
หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่เพิ่มเข้ามา, ข้อจำกัดใหม่ใด ๆ และการเปลี่ยนแปลงอื่น ๆ ที่แนะนำร่วมกับ Aspose.Slides for Java 14.10.0 API.
{{% /alert %}} 
## **Public API Changes**
### **com.aspose.slides.FieldType.getFooter() method has been added**
เมธอด getFooter() คืนค่าชนิดฟิลด์ส่วนท้าย (footer). เมธอดนี้ถูกเพิ่มเพื่อให้สามารถสร้างฟิลด์ชนิดนี้ได้และเพื่อการทำซีเรียลไลซ์พรีเซนเทชันที่ถูกต้อง
### **Element com.aspose.slides.ShapeElementFillSource.Own has been deleted**
อิลิเมนต์ ShapeElementFillSource.Own ถูกลบเนื่องจากซ้ำซ้อน. ให้ใช้ ShapeElementFillSource.Shape แทน ShapeElementFillSource.Own
### **Methods for chart data points, categories removing have been added**
**เมธอดต่อไปนี้ที่ช่วยลบจุดข้อมูลแผนภูมิจากคอลเลกชันจุดข้อมูลแผนภูมิได้ถูกเพิ่มเข้ามา:**

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

**เมธอดต่อไปนี้ที่ช่วยลบหมวดหมู่แผนภูมิจากคอลเลกชันที่บรรจุอยู่ได้ถูกเพิ่มเข้ามา:**

IChartCategory.remove()

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // ลบโดยใช้ ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // ลบโดยใช้ ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // ลบโดยใช้ ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **Obsolete Aspose.Slides.ParagraphFormat methods have been removed**
เมธอด getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() และเมธอด set ที่สอดคล้องกันได้ถูกลบออกแล้ว เนื่องจากถูกทำเครื่องหมายว่าเลิกใช้มานานแล้ว
### **Un-useful and obsolete constructors have been removed**
คอนสตรัคเตอร์ต่อไปนี้ได้ถูกลบออก:

com.aspose.slides.AlphaBiLevel(float)
com.aspose.slides.AlphaModulateFixed(float)
com.aspose.slides.AlphaReplace(float)
com.aspose.slides.BiLevel(float)
com.aspose.slides.Blur(double, boolean)
com.aspose.slides.HSL(float, float, float)
com.aspose.slides.ImageTransformOperation(com.aspose.slides.ImageTransformOperationCollection)
com.aspose.slides.Luminance(float, float)
com.aspose.slides.Tint(float, float)
com.aspose.slides.PortionFormat(com.aspose.slides.ParagraphFormat)
com.aspose.slides.PortionFormat(com.aspose.slides.Portion)
com.aspose.slides.PortionFormat(com.aspose.slides.PortionFormat)