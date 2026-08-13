---
title: Public API และการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides สำหรับ Java 15.4.0
linktitle: Aspose.Slides สำหรับ Java 15.4.0
type: docs
weight: 120
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- การย้ายข้อมูล
- โค้ดเดิม
- โค้ดสมัยใหม่
- วิธีการเดิม
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบการอัปเดต Public API และการเปลี่ยนแปลงที่ทำให้แตกหักใน Aspose.Slides สำหรับ Java เพื่อการย้ายข้อมูล PowerPoint PPT, PPTX และโซลูชันการนำเสนอ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="info" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ และอื่น ๆ ที่[เพิ่ม](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) รวมถึงข้อจำกัดใหม่และ[การเปลี่ยนแปลง](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)ที่แนะนำใน Aspose.Slides for Java 15.4.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง Public API**
### **Enum OrganizationChartLayoutType ถูกเพิ่ม**
Enum com.aspose.slides.OrganizationChartLayoutType แสดงประเภทการจัดรูปแบบของโหนดลูกในแผนภูมิองค์กร.
### **Method IBulletFormat.applyDefaultParagraphIndentsShifts() ถูกเพิ่ม**
Method com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts ตั้งค่าการเลื่อนค่าเริ่มต้นที่ไม่เป็นศูนย์สำหรับ Indent และ MarginLeft ของย่อหน้าที่มีจุดหัวข้อเมื่อเปิดใช้งาน bullets (เช่น PowerPoint ทำเมื่อเปิดใช้งานหัวข้อย่อหน้า/ลำดับเลข). หาก bullets ปิดใช้งานจะรีเซ็ต Indent และ MarginLeft ของย่อหน้า (เช่น PowerPoint ทำเมื่อปิดใช้งานหัวข้อย่อหน้า/ลำดับเลข).
### **Method IConnector.reroute() ถูกเพิ่ม**
Method com.aspose.slides.IConnector.reroute() ปรับเส้นเชื่อมต่อให้ใช้เส้นทางที่สั้นที่สุดระหว่างรูปทรงที่เชื่อมต่อกัน. เพื่อทำเช่นนี้ เมธอด reroute() อาจเปลี่ยนค่า StartShapeConnectionSiteIndex และ EndShapeConnectionSiteIndex.

``` java
import com.aspose.slides.*;


 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

connector.reroute();

input.save("output.pptx", SaveFormat.Pptx);

```
### **Method IPresentation.getSlideById(long) ถูกเพิ่ม**
Method Aspose.Slides.IPresentation.getSlideById(long) คืนค่า Slide, MasterSlide หรือ LayoutSlide ตามรหัสสไลด์.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Method ISmartArt.getNodes() ถูกเพิ่ม**
Method com.aspose.slides.ISmartArt.getNodes() คืนค่าคอลเลกชันของโหนดรากในวัตถุ SmartArt.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // เลือกโหนดรากที่สอง

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArt.setLayout(int) ถูกเพิ่ม**
Method สำหรับ property com.aspose.slides.ISmartArt.setLayout(int) ถูกเพิ่ม. สามารถเปลี่ยนประเภทการจัดวางของไดอะแกรมที่มีอยู่ได้.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArtNode.isHidden() ถูกเพิ่ม**
Method com.aspose.slides.ISmartArtNode.isHidden() คืนค่า true หากโหนดนี้เป็นโหนดที่ซ่อนอยู่ในโมเดลข้อมูล.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //คืนค่า true

if(hidden) {

    //ทำบางอย่างหรือแจ้งเตือน

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Methods ISmartArt.isReversed(), setReversed() ถูกเพิ่ม**
Property com.aspose.slides.ISmartArt.IsReversed ให้สามารถรับหรือกำหนดสถานะของไดอะแกรม SmartArt ว่าเป็น (ซ้ายไปขวา) LTR หรือ (ขวาไปซ้าย) RTL หากไดอะแกรมรองรับการกลับทิศ.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Methods ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) ถูกเพิ่ม**
Methods com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) ให้สามารถรับหรือกำหนดประเภทแผนภูมิองค์กรที่เชื่อมโยงกับโหนดปัจจุบันได้.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Property IShape.getConnectionSiteCount() ถูกเพิ่ม**
Property com.aspose.slides.getConnectionSiteCount() คืนค่าจำนวนจุดเชื่อมต่อบนรูปทรง.

``` java
import com.aspose.slides.*;


 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

long wantedIndex = 6;

if (ellipse.getConnectionSiteCount() > wantedIndex) {

  connector.setStartShapeConnectionSiteIndex(wantedIndex);

}

input.save("output.pptx", SaveFormat.Pptx);

```
### **การเปลี่ยนแปลงเล็กน้อย**
นี่คือรายการการเปลี่ยนแปลง API เล็กน้อย:

| Enum com.aspose.slides.BevelColorMode | ถูกลบ, ไม่ใช้ enum |
| :- | :- |
| Method ThreeDFormatEffectiveData.getBevelColorMode() | ถูกลบ, ไม่ใช้ property |
| Method com.aspose.slides.ChartSeriesGroup.getChart() | เพิ่ม |
| Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent | ถูกลบ |
| Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() | ถูกลบเนื่องจากล้าสมัย |