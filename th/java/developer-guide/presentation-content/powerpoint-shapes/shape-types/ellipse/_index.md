---
title: เพิ่มวงรีในงานนำเสนอด้วย Java
linktitle: วงรี
type: docs
weight: 30
url: /th/java/ellipse/
keywords:
- วงรี
- รูปร่าง
- เพิ่มวงรี
- สร้างวงรี
- วาดวงรี
- วงรีที่จัดรูปแบบ
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้าง จัดรูปแบบ และจัดการรูปวงรีใน Aspose.Slides สำหรับ Java ในงานนำเสนอรูปแบบ PPT และ PPTX — รวมตัวอย่างโค้ด Java"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการเพิ่มรูปวงรีลงในสไลด์ PowerPoint โดยใช้ Aspose.Slides ครอบคลุมการสร้างวงรีง่าย ๆ การสร้างวงรีที่มีการจัดรูปแบบ และการบันทึกงานนำเสนอที่อัปเดตเป็นไฟล์ PPTX นอกจากนี้ยังกล่าวถึงคำถามที่เกี่ยวข้อง เช่น การทำงานกับตำแหน่งและขนาดของวงรี การควบคุมลำดับการซ้อนกัน และการใช้เอฟเฟกต์แอนิเมชัน

## **สร้างวงรี**
เพื่อเพิ่มวงรีง่าย ๆ ไปยังสไลด์ที่เลือกในงานนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) 
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ชนิด Ellipse โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดให้ใช้งานโดยวัตถุ [IShapeCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection)
- บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มวงรีไปยังสไลด์แรก

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // เพิ่ม AutoShape ประเภทวงรี
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // เขียนไฟล์ PPTX ลงดิสก์
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **สร้างวงรีที่จัดรูปแบบ**
เพื่อเพิ่มวงรีที่จัดรูปแบบดียิ่งขึ้นไปยังสไลด์ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation) 
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ชนิด Ellipse โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดให้ใช้งานโดยวัตถุ [IShapeCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection)
- ตั้งค่า Fill Type ของวงรีเป็น Solid
- ตั้งค่าสีของวงรีโดยใช้คุณสมบัติ SolidFillColor.Color ที่เปิดให้ใช้งานโดยวัตถุ [FillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/IFillFormat) ที่เชื่อมต่อกับวัตถุ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape)
- ตั้งค่าสีของเส้นของวงรี
- ตั้งค่าความกว้างของเส้นของวงรี
- บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มวงรีที่จัดรูปแบบไปยังสไลด์แรกของงานนำเสนอ

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภทวงรี
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // ใช้การจัดรูปแบบบางอย่างกับรูปร่างวงรี
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // ใช้การจัดรูปแบบบางอย่างกับเส้นของวงรี
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // เขียนไฟล์ PPTX ลงดิสก์
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันจะตั้งตำแหน่งและขนาดที่แน่นอนของวงรีโดยอ้างอิงหน่วยของสไลด์ได้อย่างไร?**

พิกัดและขนาดโดยทั่วไปจะระบุเป็น **points** สำหรับผลลัพธ์ที่พอควร ควรอ้างอิงการคำนวณจากขนาดสไลด์และแปลงมิลลิเมตรหรืออินช์ที่ต้องการเป็น points ก่อนกำหนดค่า

**ฉันจะวางวงรีเหนือหรือใต้วัตถุอื่น ๆ (ควบคุมลำดับการซ้อนกัน) อย่างไร?**

ปรับลำดับการวาดของวัตถุโดยย้ายไปด้านหน้า หรือส่งไปด้านหลัง การทำเช่นนี้ทำให้วงรีทับซ้อนวัตถุอื่นหรือเปิดเผยวัตถุที่อยู่ใต้มัน

**ฉันจะทำแอนิเมชันการปรากฏหรือการเน้นของวงรีได้อย่างไร?**

[Apply](/slides/th/java/shape-animation/) เอฟเฟกต์การเข้า, การเน้น, หรือการออกให้กับรูปร่าง และกำหนดค่า trigger และ timing เพื่อควบคุมเวลาและวิธีการเล่นของแอนิเมชัน