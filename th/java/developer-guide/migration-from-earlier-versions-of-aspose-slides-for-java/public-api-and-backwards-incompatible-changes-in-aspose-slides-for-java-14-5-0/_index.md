---
title: การเปลี่ยนแปลง API สาธารณะและที่ไม่เข้ากันได้ย้อนหลังใน Aspose.Slides for Java 14.5.0
linktitle: Aspose.Slides สำหรับ Java 14.5.0
type: docs
weight: 40
url: /th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- การย้าย
- โค้ดเก่า
- โค้ดสมัยใหม่
- แนวทางเก่า
- แนวทางสมัยใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ทบทวนการอัปเดต API สาธารณะและการเปลี่ยนแปลงที่ทำให้เกิดการพังใน Aspose.Slides for Java เพื่อการย้ายงานนำเสนอ PowerPoint PPT, PPTX และ ODP ของคุณอย่างราบรื่น."
---
{{% alert color="primary" %}} 

หน้านี้แสดงรายการทั้งหมดของคลาส, เมธอด, คุณสมบัติ ฯลฯ ที่ [เพิ่ม](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) , ข้อจำกัดใหม่ [ข้อจำกัด](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) และการเปลี่ยนแปลงอื่นๆ [การเปลี่ยนแปลง](/slides/th/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) ที่นำมาใช้กับ Aspose.Slides for Java 14.5.0 API.

{{% /alert %}} 
## **API สาธารณะและการเปลี่ยนแปลงที่ไม่เข้ากันได้ย้อนหลัง**
### **คลาสและเมธอดที่เพิ่ม**
#### **เพิ่มอินเทอร์เฟซ Aspose.Slides.IPresentationInfo และคลาส PresentationInfo**
แสดงข้อมูลเกี่ยวกับงานนำเสนอ

เมธอด Boolean isEncrypted() จะคืนค่า True หากงานนำเสนอถูกเข้ารหัส, มิฉะนั้นจะคืนค่า False

เมธอด LoadFormat getLoadFormat() จะคืนประเภทของงานนำเสนอ
#### **เพิ่มเมธอด Aspose.Slides.IShape.isGrouped()**
เมธอด Aspose.Slides.IShape.isGrouped() กำหนดว่ารูปทรงถูกจัดกลุ่มหรือไม่
#### **เพิ่มเมธอด Aspose.Slides.IShape.getParentGroup()**
เมธอด Aspose.Slides.IShape.getParentGroup() จะคืนออบเจ็กต์ GroupShape พาเรนต์หากรูปทรงถูกจัดกลุ่ม. มิฉะนั้นจะคืนค่า null
#### **เพิ่มเมธอด Aspose.Slides.IShapeCollection.addGroupShape()**
เมธอด Aspose.Slides.IShapeCollection.addGroupShape() สร้าง GroupShape ใหม่และเพิ่มลงท้ายของคอลเลกชัน

ขนาดและตำแหน่งของเฟรม GroupShape จะปรับให้พอดีกับเนื้อหาเมื่อมีการเพิ่มรูปทรงใหม่เข้าไปใน GroupShape
#### **เพิ่มเมธอด Aspose.Slides.IShapeCollection.clear()**
เมธอด Aspose.Slides.IShapeCollection.clear() จะลบรูปทรงทั้งหมดออกจากคอลเลกชัน
#### **เพิ่มเมธอด Aspose.Slides.IShapeCollection.insertGroupShape(int)**
เมธอด Aspose.Slides.IShapeCollection.insertGroupShape(int) สร้าง GroupShape ใหม่และแทรกเข้าไปในคอลเลกชันที่ตำแหน่งที่ระบุ

ขนาดและตำแหน่งของเฟรม GroupShape จะปรับให้พอดีกับเนื้อหาเมื่อมีการเพิ่มรูปทรงใหม่เข้าไปใน GroupShape
#### **เพิ่มเมธอด IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream)**
เมธอดเหล่านี้ช่วยให้นักพัฒนาสามารถรับข้อมูลเกี่ยวกับไฟล์/สตรีมของงานนำเสนอได้โดยไม่ต้องโหลดงานนำเสนอเต็มรูปแบบ
#### **เพิ่มเมธอด IPresentationFactory PresentationFactory.getInstance()**
อนุญาตให้ใช้ฟังก์ชันของโรงงานโดยไม่ต้องสร้างอินสแตนซ์
### **ข้อจำกัด**
#### **ได้เพิ่มข้อจำกัดสำหรับการใช้ค่าที่ไม่กำหนดใน IShape.getFrame()**
โค้ดที่พยายามกำหนดเฟรมที่ไม่ได้กำหนดค่าให้กับ IShape.setFrame(IShapeFrame) ไม่มีความหมายในกรณีทั่วไป (โดยเฉพาะเมื่อ GroupShape พาเรนต์ถูกซ้อนหลายชั้นใน {{GroupShape}} อื่น). ตัวอย่างเช่น:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

หรือ

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

โค้ดดังกล่าวอาจทำให้เกิดสถานการณ์ที่ไม่ชัดเจน ดังนั้นจึงมีการเพิ่มข้อจำกัดสำหรับการใช้ค่าที่ไม่ได้กำหนดใน IShape.Frame ค่าของ x, y, width, height, flipH, flipV และ rotationAngle ต้องถูกกำหนด (ไม่ใช่ Float.NaN หรือ NullableBool.NotDefined) ตัวอย่างโค้ดด้านบนตอนนี้จะโยนข้อยกเว้น ArgumentException

ข้อกำหนดนี้ใช้กับกรณีการใช้งานต่อไปนี้:

``` java

 IShape shape = ...;

shape.setFrame(...); // ห้ามเป็นค่า undefined

IShapeCollection shapes = ...;

// พารามิเตอร์ x, y, width, height ไม่สามารถเป็น Float.NaN ได้:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}

```

แต่เฟรมของ IShape.getRawFrame() สามารถไม่มีการกำหนดค่าได้ ซึ่งสมเหตุสมผลเมื่อรูปทรงเชื่อมโยงกับตัวเก็บตำแหน่ง (placeholder) จากนั้นค่าที่ไม่มีการกำหนดของเฟรมรูปทรงจะถูกแทนที่จากรูปทรง placeholder พาเรนต์ หากไม่มี placeholder พาเรนต์สำหรับรูปทรงนั้น ระบบจะใช้ค่าเริ่มต้นเมื่อประเมินเฟรมที่มีผลตาม IShape.getRawFrame() ค่าเริ่มต้นคือ 0 และ NullableBool.False สำหรับ x, y, width, height, flipH, flipV และ rotationAngle ตัวอย่างเช่น:

``` java

 IShape shape = ...; // รูปทรงเชื่อมโยงกับ placeholder

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// ตอนนี้รูปทรงสืบทอดค่า x, y, height, flipH, flipV จาก placeholder และแทนที่ width=100 และ rotationAngle=0.

```
### **คุณสมบัติที่เปลี่ยนแปลง**
#### **เปลี่ยนประเภทและชื่อของเมธอด Aspose.Slides.IShapeCollection.getParent()**
ประเภทของคุณสมบัติ Aspose.Slides.IShapeCollection.Parent ถูกเปลี่ยนจาก ISlideComponent เป็นอินเทอร์เฟซ IGroupShape ใหม่ อินเทอร์เฟซ IGroupShape สืบทอดมาจาก ISlideComponent จึงไม่ต้องปรับโค้ดเดิม

ชื่อของเมธอด Aspose.Slides.IShapeCollection.getParent() ถูกเปลี่ยนจาก getParent เป็น getParentGroup()
#### **เปลี่ยนประเภทของเมธอด Aspose.Slides.IShapeFrame.getFlipH() และ .getFlipV()**
ประเภทของเมธอด Aspose.Slides.IShapeFrame.getFlipH() ถูกเปลี่ยนจาก bool เป็น NullableBool

เมธอด IShape.getFrame() จะคืนอินสแตนซ์ของ IShapeFrame ที่มีค่าที่กำหนดอย่างมีประสิทธิผล (ทุกคุณสมบัติมีค่าที่กำหนด)

เมธอด IShape.getRawFrame() จะคืนอินสแตนซ์ของ IShapeFrame ที่แต่ละคุณสมบัติอาจไม่มีการกำหนดค่า (โดยเฉพาะ FlipH หรือ FlipV อาจมีค่า NullableBool.NotDefined)