---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ Java 15.2.0
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
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการทำลายใน Aspose.Slides สำหรับ Java เพื่อย้ายโซลูชันงานนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ และอื่น ๆ ทั้งหมดที่ถูก [added](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) , ข้อจำกัดใหม่ใด ๆ และ [changes](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-2-0/) ที่นำมาใช้กับ Aspose.Slides for Java 15.2.0 API.

{{% /alert %}} {{% alert color="info" %}} 

มีปัญหาที่ทราบอยู่บางประการกับรูปภาพแบบบูลเล็ตและวัตถุ WordArt ซึ่งจะได้รับการแก้ไขใน Aspose.Slides for Java 15.2.0.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
### **เมธอด addDataPointForDoughnutSeries ถูกเพิ่ม**
มีการเพิ่มอ็อเวอร์โหลดสองแบบของเมธอด IChartDataPointCollection.addDataPointForDoughnutSeries() เพื่อเพิ่มจุดข้อมูลลงในซีรีส์ประเภท Doughnut
### **คลาส com.aspose.slides.SmartArtShape ถูกสืบทอดจากคลาส com.aspose.slides.GeometryShape**
คลาส com.aspose.slides.SmartArtShape ถูกสืบทอดจากคลาส com.aspose.slides.GeometryShape การเปลี่ยนแปลงนี้ทำให้โมเดลวัตถุของ Aspose.Slides ดีขึ้นและเพิ่มฟีเจอร์ใหม่ให้กับคลาส SmartArtShape
### **เมธอด IGradientStopCollection.add(...) และ IGradientStopCollection.insert(...) ถูกเปลี่ยนแปลง**
ลายเซ็นของ IGradientStop add(float position, int presetColor) ถูกแทนที่ด้วยลายเซ็น IGradientStop addPresetColor(float position, int presetColor)

ลายเซ็นของเมธอด IGradientStopCollection IGradientStop add(float position, SchemeColor schemeColor) ถูกแทนที่ด้วยลายเซ็น IGradientStop addSchemeColor(float position, int schemeColor)

ลายเซ็นของเมธอด IGradientStopCollection void insert(int index, float position, int presetColor) ถูกแทนที่ด้วยลายเซ็น void insertPresetColor(int index, float position, int presetColor)

ลายเซ็นของเมธอด IGradientStopCollection void insert(int index, float position, SchemeColor schemeColor) ถูกแทนที่ด้วยลายเซ็น void insertSchemeColor(int index, float position, int schemeColor)
### **เมธอด java.awt.Color getAutomaticSeriesColor() ถูกเพิ่มใน com.aspose.slides.IChartSeries**
เมธอด getAutomaticSeriesColor() คืนค่าสีอัตโนมัติของซีรีส์โดยอิงจากดัชนีซีรีส์และสไตล์แผนภูมิ สีนี้จะถูกใช้เป็นค่าเริ่มต้นหาก FillType มีค่าเป็น NotDefined.
 

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

for (int i = 0; i < chart.getChartData().getSeries().size(); i++)

{

    chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();

}

```
### **เมธอดสำหรับการลบจุดข้อมูลแผนภูมิและหมวดหมู่แผนภูมิตามดัชนีของมันถูกเพิ่ม**
เมธอด IChartDataPointCollection.removeAt(int index) ถูกเพิ่มเพื่อทำการลบจุดข้อมูลแผนภูมิตามดัชนีของมัน
เมธอด IChartCategoryCollection.removeAt(int index) ถูกเพิ่มเพื่อทำการลบหมวดหมู่แผนภูมิตามดัชนีของมัน
### **ค่า PptXPptY ถูกเพิ่มใน enumeration com.aspose.slides.PropertyType**
ค่า PptXPptY ถูกเพิ่มใน enumeration com.aspose.slides.PropertyType เพื่อแก้ไขปัญหาการทำ serialize.