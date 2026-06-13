---
title: Public API และการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ Java 15.2.0
linktitle: Aspose.Slides สำหรับ Java 15.2.0
type: docs
weight: 110
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/
keywords:
- การย้าย
- โค้ดเก่า
- โค้ดสมัยใหม่
- วิธีการเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ทบทวนการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้โค้ดเสียหายใน Aspose.Slides สำหรับ Java เพื่อช่วยให้คุณย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณได้อย่างราบรื่น."
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ ฯลฯ ทั้งหมดที่ [เพิ่ม](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) รวมถึงข้อจำกัดใหม่และ [การเปลี่ยนแปลง](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) ที่แนะนำใน API ของ Aspose.Slides for Java 15.2.0

{{% /alert %}} {{% alert color="primary" %}} 

มีปัญหาที่ทราบอยู่กับบูลเล็ตภาพบางประเภทและวัตถุ WordArt ซึ่งจะได้รับการแก้ไขใน Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
### **เมธอด addDataPointForDoughnutSeries ถูกเพิ่ม**
ได้เพิ่มออเวอร์โหลดสองรูปแบบของเมธอด IChartDataPointCollection.addDataPointForDoughnutSeries() เพื่อเพิ่มจุดข้อมูลเข้าสู่ซีรีส์ประเภท Doughnut
### **คลาส com.aspose.slides.SmartArtShape ได้สืบทอดจากคลาส com.aspose.slides.GeometryShape**
คลาส com.aspose.slides.SmartArtShape ได้สืบทอดจากคลาส com.aspose.slides.GeometryShape การเปลี่ยนแปลงนี้ทำให้โมเดลวัตถุของ Aspose.Slides ดีขึ้นและเพิ่มคุณลักษณะใหม่ให้กับคลาส SmartArtShape
### **เมธอด IGradientStopCollection.add(...) และ IGradientStopCollection.insert(...) ถูกเปลี่ยนแปลง**
ลายเซ็นของ IGradientStop add(float position, int presetColor) ถูกเปลี่ยนเป็นลายเซ็น IGradientStop addPresetColor(float position, int presetColor)

ลายเซ็นของเมธอด IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) ถูกเปลี่ยนเป็นลายเซ็น IGradientStop addSchemeColor(float position, int schemeColor)

ลายเซ็นของเมธอด IGradientStopCollection void insert(int index, float position, int presetColor) ถูกเปลี่ยนเป็นลายเซ็น void insertPresetColor(int index, float position, int presetColor)

ลายเซ็นของเมธอด IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) ถูกเปลี่ยนเป็นลายเซ็น void insertSchemeColor(int index, float position, int schemeColor)
### **เมธอด java.awt.Color getAutomaticSeriesColor() ถูกเพิ่มไปยัง com.aspose.slides.IChartSeries**
เมธอด getAutomaticSeriesColor() คืนค่าสีอัตโนมัติของซีรีส์ตามดัชนีซีรีส์และสไตล์ของแผนภูมิ สีนี้จะถูกใช้เป็นค่าเริ่มต้นหาก FillType มีค่าเป็น NotDefined
 

``` java

 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **เพิ่มเมธอดสำหรับลบจุดข้อมูลแผนภูมิและหมวดหมู่แผนภูมิตามดัชนี**
เมธอด IChartDataPointCollection.removeAt(int index) ถูกเพิ่มเพื่อทำการลบจุดข้อมูลแผนภูมิตามดัชนี
เมธอด IChartCategoryCollection.removeAt(int index) ถูกเพิ่มเพื่อทำการลบหมวดหมู่แผนภูมิตามดัชนี
### **ค่า PptXPptY ได้ถูกเพิ่มไปยัง enumeration com.aspose.slides.PropertyType**
ค่า PptXPptY ได้ถูกเพิ่มไปยัง enumeration com.aspose.slides.PropertyType เพื่อแก้ไขปัญหาการทำซีเรียลไลเซชัน