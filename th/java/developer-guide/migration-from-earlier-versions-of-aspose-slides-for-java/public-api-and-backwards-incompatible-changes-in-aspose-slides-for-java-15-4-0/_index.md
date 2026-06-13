---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันย้อนหลังใน Aspose.Slides for Java 15.4.0
linktitle: Aspose.Slides for Java 15.4.0
type: docs
weight: 120
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- การย้าย
- โค้ดเก่า
- โค้ดสมัยใหม่
- วิธีการเดิม
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจทานการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดความไม่เข้ากันใน Aspose.Slides for Java เพื่อการย้ายแบบราบรื่นของโซลูชันงานนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณ."
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ [เพิ่ม](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) ทั้งหมด, ข้อจำกัดใหม่ใด ๆ และ [การเปลี่ยนแปลง](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) อื่น ๆ ที่แนะนำมาพร้อมกับ Aspose.Slides for Java 15.4.0 API.

{{% /alert %}} 
## **การเปลี่ยนแปลง API สาธารณะ**
### **Enum OrganizationChartLayoutType ได้ถูกเพิ่ม**
Enum com.aspose.slides.OrganizationChartLayoutType แสดงประเภทการจัดรูปแบบของโหนดลูกในแผนภูมิโครงสร้างองค์กร.
### **Method IBulletFormat.applyDefaultParagraphIndentsShifts() ได้ถูกเพิ่ม**
เมธอด com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts ตั้งค่าการเลื่อนค่าเริ่มต้นที่ไม่เป็นศูนย์สำหรับ Indent และ MarginLeft ของย่อหน้าที่มีประสิทธิภาพเมื่อเปิดใช้งาน bullet (เช่นที่ PowerPoint ทำเมื่อเปิดใช้งาน bullet/numbering ของย่อหน้า). หาก bullet ถูกปิดใช้งานจะรีเซ็ต Indent และ MarginLeft ของย่อหน้า (เช่นที่ PowerPoint ทำเมื่อปิดการใช้งาน bullet/numbering ของย่อหน้า).
### **Method IConnector.reroute() ได้ถูกเพิ่ม**
เมธอด com.aspose.slides.IConnector.reroute() ทำการกำหนดเส้นเชื่อมใหม่เพื่อให้เส้นเชื่อมใช้เส้นทางที่สั้นที่สุดระหว่างรูปร่างที่เชื่อมต่อกัน. เพื่อทำเช่นนี้ เมธอด reroute() อาจเปลี่ยนค่า StartShapeConnectionSiteIndex และ EndShapeConnectionSiteIndex.

``` java

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
### **Method IPresentation.getSlideById(long) ได้ถูกเพิ่ม**
เมธอด Aspose.Slides.IPresentation.getSlideById(int) คืนค่า Slide, MasterSlide หรือ LayoutSlide ตามรหัสสไลด์.

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Method ISmartArt.getNodes() ได้ถูกเพิ่ม**
เมธอด com.aspose.slides.ISmartArt.getNodes() คืนค่าคอลเลกชันของโหนดรากในอ็อบเจกต์ SmartArt.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // เลือกโหนดรากที่สอง

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArt.setLayout(int) ได้ถูกเพิ่ม**
เมธอดสำหรับ property com.aspose.slides.ISmartArt.setLayout(int) ได้ถูกเพิ่ม. มันอนุญาตให้เปลี่ยนประเภทเลย์เอาต์ของไดอะแกรมที่มีอยู่.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArtNode.isHidden() ได้ถูกเพิ่ม**
เมธอด com.aspose.slides.ISmartArtNode.isHidden() คืนค่า true หากโหนดนี้เป็นโหนดที่ถูกซ่อนไว้ในโมเดลข้อมูล.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //คืนค่า true

if(hidden) {

    //ทำบางอย่างหรือแจ้งเตือน

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **Methods ISmartArt.isReversed(), setReserved() have been added**
Property com.aspose.slides.ISmartArt.IsReversed อนุญาตให้รับหรือกำหนดสถานะของไดอะแกรม SmartArt เกี่ยวกับ (จากซ้ายไปขวา) LTR หรือ (จากขวาไปซ้าย) RTL หากไดอะแกรมรองรับการย้อนกลับ.

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Methods ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) have been added**
เมธอด com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) อนุญาตให้รับหรือกำหนดประเภทแผนภูมิองค์กรที่เชื่อมโยงกับโหนดปัจจุบัน.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Property IShape.getConnectionSiteCount() has been added**
Property com.aspose.slides.getConnectionSiteCount() คืนค่าจำนวนจุดเชื่อมต่อบนรูปร่าง.

``` java

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

|Enum com.aspose.slides.BevelColorMode |ลบ, enum ที่ไม่ได้ใช้ |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |ลบ, property ที่ไม่ได้ใช้ |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |เพิ่ม |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |ลบ |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |ลบเนื่องจากล้าสมัย |