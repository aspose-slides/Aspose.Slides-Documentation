---
title: API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันแบบย้อนกลับใน Aspose.Slides สำหรับ Java 14.5.0
linktitle: Aspose.Slides สำหรับ Java 14.5.0
type: docs
weight: 40
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- การย้ายข้อมูล
- โค้ดเก่า
- โค้ดสมัยใหม่
- วิธีการเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- Java
- Aspose.Slides
description: "ตรวจสอบการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการแตกหักใน Aspose.Slides สำหรับ Java เพื่อย้ายโซลูชันการนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="info" %}}

หน้านี้แสดงรายการคลาส, เมธอด, คุณสมบัติ และอื่น ๆ ทั้งหมดที่ [ที่เพิ่ม](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) ใหม่, [ข้อจำกัด](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) และ [การเปลี่ยนแปลง](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) ที่แนะนำใน Aspose.Slides for Java 14.5.0 API.

{{% /alert %}} 
## **API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันแบบย้อนกลับ**
### **คลาสและเมธอดที่เพิ่มเข้ามา**
#### **เพิ่มอินเทอร์เฟซ Aspose.Slides.IPresentationInfo และคลาส PresentationInfo**
แสดงข้อมูลเกี่ยวกับงานนำเสนอ

เมธอด Boolean isEncrypted() คืนค่า True หากงานนำเสนอถูกเข้ารหัส, มิฉะนั้นคืนค่า False

เมธอด LoadFormat getLoadFormat() คืนค่าประเภทของงานนำเสนอ
#### **เพิ่มเมธอด Aspose.Slides.IShape.isGrouped()**
เมธอด Aspose.Slides.IShape.isGrouped() กำหนดว่ารูปร่างเป็นกลุ่มหรือไม่
#### **เพิ่มเมธอด Aspose.Slides.IShape.getParentGroup()**
เมธอด Aspose.Slides.IShape.getParentGroup() คืนค่าออบเจกต์ GroupShape พ่อแม่หากรูปร่างเป็นกลุ่ม มิฉะนั้นคืนค่า null
#### **เพิ่มเมธอด Aspose.Slides.IShapeCollection.addGroupShape()**
เมธอด Aspose.Slides.IShapeCollection.addGroupShape() สร้าง GroupShape ใหม่และเพิ่มไว้ที่ท้ายคอลเลกชัน

ขนาดและตำแหน่งเฟรมของ GroupShape จะถูกปรับให้พอดีกับเนื้อหาเมื่อมีรูปร่างใหม่ถูกเพิ่มเข้าไปใน GroupShape
#### **เพิ่มเมธอด Aspose.Slides.IShapeCollection.clear()**
เมธอด Aspose.Slides.IShapeCollection.clear() ลบรูปร่างทั้งหมดออกจากคอลเลกชัน
#### **เพิ่มเมธอด Aspose.Slides.IShapeCollection.insertGroupShape(int)**
เมธอด Aspose.Slides.IShapeCollection.insertGroupShape(int) สร้าง GroupShape ใหม่และแทรกเข้าไปในคอลเลกชันที่ตำแหน่งที่กำหนด
ขนาดและตำแหน่งเฟรมของ GroupShape จะถูกปรับให้พอดีกับเนื้อหาเมื่อมีรูปร่างใหม่ถูกเพิ่มเข้าไปใน GroupShape
#### **เพิ่มเมธอด IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream)**
เมธอดเหล่านี้อำนวยความสะดวกให้ผู้พัฒนาสามารถรับข้อมูลเกี่ยวกับไฟล์/สตรีมของงานนำเสนอได้โดยไม่ต้องโหลดงานนำเสนอเต็มรูปแบบ
#### **เพิ่มเมธอด IPresentationFactory PresentationFactory.getInstance()**
อนุญาตให้ใช้ฟังก์ชันของแฟคทอรีโดยไม่ต้องสร้างอินสแตนซ์
### **ข้อจำกัด**
#### **เพิ่มข้อจำกัดสำหรับการใช้ค่าไม่กำหนดใน IShape.getFrame()**
โค้ดที่พยายามกำหนดเฟรมที่ไม่มีค่าให้ IShape.setFrame(IShapeFrame) ไม่มีความหมายในกรณีทั่วไป (โดยเฉพาะเมื่อ GroupShape พ่อแม่ซ้อนกันหลายระดับใน {{GroupShape}} อื่น) ตัวอย่างเช่น

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // โยน ArgumentException: ค่ากรอบต้องกำหนด.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

หรือ

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // โยน ArgumentException: ค่าของ x, y, ความกว้างและความสูงต้องกำหนด.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

โค้ดดังกล่าวอาจนำไปสู่สถานการณ์ที่ไม่ชัดเจน ดังนั้นจึงได้เพิ่มข้อจำกัดสำหรับการใช้ค่าไม่กำหนดใน IShape.Frame ค่าของ x, y, width, height, flipH, flipV และ rotationAngle ต้องถูกกำหนด (ไม่ใช่ Float.NaN หรือ NullableBool.NotDefined) ตัวอย่างโค้ดข้างต้นตอนนี้จะทำให้เกิดข้อยกเว้น ArgumentException
ข้อกำหนดนี้ใช้กับกรณีต่อไปนี้

``` java
// เฟรมที่ส่งไปยัง IShape.setFrame(IShapeFrame) ไม่สามารถมีค่าที่ไม่ได้กำหนด.

// พารามิเตอร์ x, y, ความกว้างและความสูงของเมธอด IShapeCollection ต่อไปนี้
// ไม่สามารถเป็น Float.NaN ได้เช่นกัน:
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

แต่เฟรมจาก IShape.getRawFrame() สามารถเป็นค่าไม่กำหนดได้ ซึ่งมีเหตุผลเมื่อรูปร่างเชื่อมโยงกับ placeholder จากนั้นค่าเฟรมที่ไม่กำหนดของรูปร่างจะถูกแทนที่จาก placeholder พ่อแม่ หากไม่มี placeholder พ่อแม่สำหรับรูปร่างนั้น ระบบจะใช้ค่าปริยายเมื่อประเมินเฟรมที่มีประสิทธิภาพตาม IShape.getRawFrame() ค่าปริยายคือ 0 และ NullableBool.False สำหรับ x, y, width, height, flipH, flipV และ rotationAngle ตัวอย่างเช่น

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // รูปร่างเชื่อมโยงกับ placeholder.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // ตอนนี้รูปร่างสืบทอดค่า x, y, height, flipH และ flipV จาก placeholder
    // และแทนที่ width = 100 และ rotationAngle = 0.
} finally {
    if (pres != null) pres.dispose();
}
```
### **คุณสมบัติที่เปลี่ยนแปลง**
#### **เปลี่ยนประเภทและชื่อของเมธอด Aspose.Slides.IShapeCollection.getParent()**
ประเภทของพรอพเพอร์ตี้ Aspose.Slides.IShapeCollection.Parent ถูกเปลี่ยนจาก ISlideComponent เป็นอินเทอร์เฟซ IGroupShape ใหม่ IGroupShape สืบทอดจาก ISlideComponent ดังนั้นโค้ดเดิมไม่ต้องปรับเปลี่ยนใด ๆ

ชื่อของเมธอด Aspose.Slides.IShapeCollection.getParent() ถูกเปลี่ยนจาก getParent เป็น getParentGroup()
#### **เปลี่ยนประเภทของเมธอด Aspose.Slides.IShapeFrame.getFlipH() และ .getFlipV()**
ประเภทของเมธอด Aspose.Slides.IShapeFrame.getFlipH() ถูกเปลี่ยนจาก bool เป็น NullableBool

เมธอด IShape.getFrame() คืนค่าอินสแตนซ์ IShapeFrame ที่มีค่าประสิทธิภาพทั้งหมดที่กำหนด

เมธอด IShape.getRawFrame() คืนค่าอินสแตนซ์ IShapeFrame ที่แต่ละพรอพเพอร์ตี้อาจไม่มีค่า (โดยเฉพาะ FlipH หรือ FlipV อาจมีค่า NullableBool.NotDefined)