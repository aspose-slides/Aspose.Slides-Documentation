---
title: เพิ่มวงรีในงานนำเสนอบน Android
linktitle: วงรี
type: docs
weight: 30
url: /th/androidjava/ellipse/
keywords:
- วงรี
- รูปร่าง
- เพิ่มวงรี
- สร้างวงรี
- วาดวงรี
- วงรีที่มีรูปแบบ
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้าง, กำหนดรูปแบบและจัดการรูปวงรีใน Aspose.Slides สำหรับ Android ทั้งในงานนำเสนอ PPT และ PPTX — รวมตัวอย่างโค้ด Java"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการเพิ่มรูปวงรีลงในสไลด์ PowerPoint โดยใช้ Aspose.Slides ครอบคลุมการสร้างวงรีแบบง่าย การสร้างวงรีที่มีรูปแบบ และการบันทึกการนำเสนอที่อัปเดตเป็นไฟล์ PPTX นอกจากนี้ยังกล่าวถึงคำถามที่เกี่ยวข้อง เช่น การทำงานกับตำแหน่งและขนาดของวงรี การควบคุมลำดับการซ้อนกัน และการใช้เอฟเฟกต์แอนิเมชัน

## **สร้างวงรี**

เพื่อเพิ่มวงรีแบบง่ายลงในสไลด์ที่เลือกของการนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
- รับการอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ชนิด Ellipse โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดให้ใช้โดยวัตถุ [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection)
- บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มวงรีลงในสไลด์แรก

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของ PPTX
Presentation pres = new Presentation();
try {
    // รับสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);
    
    // เพิ่ม AutoShape ชนิด ellipse
    sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);
    
    // เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **สร้างวงรีที่มีรูปแบบ**

เพื่อเพิ่มวงรีที่มีรูปแบบที่ดีกว่าในสไลด์ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation)
- รับการอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ชนิด Ellipse โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดให้ใช้โดยวัตถุ [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection)
- ตั้งค่า Fill Type ของวงรีเป็น Solid
- ตั้งค่าสีของวงรีโดยใช้คุณสมบัติ SolidFillColor.Color ที่เปิดให้ใช้โดยวัตถุ [FillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IFillFormat) ที่เชื่อมโยงกับวัตถุ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape)
- ตั้งค่าสีของเส้นของวงรี
- ตั้งค่าความกว้างของเส้นของวงรี
- บันทึกการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มวงรีที่มีรูปแบบลงในสไลด์แรกของการนำเสนอ

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของ PPTX
Presentation pres = new Presentation();
try {
    // รับสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ชนิด ellipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Ellipse, 50, 150, 150, 50);

    // กำหนดรูปแบบบางอย่างให้กับรูปวงรี
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.Chocolate));

    // กำหนดรูปแบบบางอย่างให้กับเส้นของวงรี
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("EllipseShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันจะตั้งตำแหน่งและขนาดที่แม่นยำของวงรีโดยอิงหน่วยของสไลด์ได้อย่างไร?**

พิกัดและขนาดมักจะระบุเป็น **points**. เพื่อให้ได้ผลลัพธ์ที่คาดการณ์ได้ ให้คำนวณบนพื้นฐานของขนาดสไลด์และแปลงมิลลิเมตรหรืออินช์ที่ต้องการเป็น points ก่อนกำหนดค่า

**ฉันจะวางวงรีให้อยู่เหนือหรือใต้วัตถุตัวอื่นได้อย่างไร (ควบคุมลำดับการซ้อนกัน)?**

ปรับลำดับการวาดของวัตถุโดยนำไปอยู่ด้านหน้า หรือส่งไปอยู่ด้านหลัง ซึ่งจะทำให้วงรีทับซ้อนวัตถุอื่นหรือเปิดเผยวัตถุตัวที่อยู่ใต้มัน

**ฉันจะทำให้วงรีมีการแอนิเมชันการปรากฏหรือการเน้นอย่างไร?**

[Apply](/slides/th/androidjava/shape-animation/) เอฟเฟกต์การเข้ามา, การเน้น, หรือการออกจากรูปร่าง, และกำหนดค่า trigger และ timing เพื่อควบคุมว่าแอนิเมชันจะเล่นเมื่อใดและอย่างไร