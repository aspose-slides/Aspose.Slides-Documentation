---
title: การเปลี่ยนแปลง Public API และความเข้ากันไม่ได้ย้อนหลังใน Aspose.Slides สำหรับ Java 14.10.0
linktitle: Aspose.Slides สำหรับ Java 14.10.0
type: docs
weight: 90
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/
keywords:
- การย้ายข้อมูล
- โค้ดเก่า
- โค้ดสมัยใหม่
- แนวทางเก่า
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบการอัพเดต Public API และการเปลี่ยนแปลงที่ทำให้แตกหักใน Aspose.Slides สำหรับ Java เพื่อการย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP อย่างราบรื่น."
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ และอื่น ๆ ที่[เพิ่ม](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) , ข้อจำกัดใหม่และ[การเปลี่ยนแปลง](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-10-0/) ที่นำเสนอพร้อมกับ API ของ Aspose.Slides สำหรับ Java 14.10.0

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
### **เมธอด com.aspose.slides.FieldType.getFooter() ถูกเพิ่มเข้ามา**
เมธอด getFooter() คืนค่าชนิดฟิลด์ส่วนท้าย ถูกเพิ่มเพื่อให้สามารถสร้างฟิลด์ชนิดนี้ได้และเพื่อการทำซีเรียลไลเซชันของงานนำเสนอที่ถูกต้อง
### **อิลิเมนต์ com.aspose.slides.ShapeElementFillSource.Own ถูกลบออก**
อิลิเมนต์ ShapeElementFillSource.Own ถูกลบเนื่องจากซ้ำซ้อน ใช้ ShapeElementFillSource.Shape แทน ShapeElementFillSource.Own
### **เมธอดสำหรับการลบจุดข้อมูลแผนภูมิและหมวดหมู่ถูกเพิ่มเข้ามา**
เมธอดต่อไปนี้ ซึ่งอนุญาตให้ลบจุดข้อมูลแผนภูมิออกจากคอลเลกชันจุดข้อมูลแผนภูมิเพิ่มเข้ามา:

IChartDataPointCollection.remove(IChartDataPoint)
IChartDataPoint.remove()

เมธอดต่อไปนี้ ซึ่งอนุญาตให้ลบหมวดหมู่แผนภูมิออกจากคอลเลกชันที่บรรจุอยู่ เพิ่มเข้ามา:

IChartCategory.remove()

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 400, true);

chart.getChartData().getCategories().get_Item(0).remove(); // ลบด้วย ChartCategory.remove()

chart.getChartData().getCategories().remove(chart.getChartData().getCategories().get_Item(0)); // ลบด้วย ChartCategoryCollection.remove()

for (IChartSeries ser : chart.getChartData().getSeries())

{

    ser.getDataPoints().get_Item(0).remove(); // ลบด้วย ChartDataPoint.remove()

    ser.getDataPoints().remove(ser.getDataPoints().get_Item(0)); // ChartDataPointCollection.remove()

}

pres.save("presentation.pptx", SaveFormat.Pptx);

```
### **เมธอด Aspose.Slides.ParagraphFormat ที่ล้าสมัยถูกลบออก**
เมธอด getBulletChar(), getBulletColor(), getBulletColorFormat(), getBulletFont(), getBulletHeight(), getBulletType(), isBulletHardColor(), isBulletHardFont(), getNumberedBulletStartWith(), getNumberedBulletStyle() และเมธอด set ที่สอดคล้องกันถูกลบออก เนื่องจากได้ถูกทำเครื่องหมายว่าล้าสมัยมานานแล้ว
### **คอนสตรัคเตอร์ที่ไม่มีประโยชน์และล้าสมัยถูกลบออก**
คอนสตรัคเตอร์ต่อไปนี้ถูกลบออก:

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