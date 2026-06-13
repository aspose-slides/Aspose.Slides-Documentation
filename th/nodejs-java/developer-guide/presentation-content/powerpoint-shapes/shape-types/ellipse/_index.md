---
title: เพิ่มวงรีลงในงานนำเสนอใน JavaScript
linktitle: วงรี
type: docs
weight: 30
url: /th/nodejs-java/ellipse/
keywords:
- วงรี
- รูปร่าง
- เพิ่มวงรี
- สร้างวงรี
- วาดวงรี
- วงรีที่จัดรูปแบบ
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีสร้าง จัดรูปแบบ และจัดการรูปร่างวงรีใน Aspose.Slides สำหรับ Node.js ในงานนำเสนอ PPT และ PPTX รวมถึงตัวอย่างโค้ด JavaScript"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการเพิ่มรูปร่างวงรีลงในสไลด์ PowerPoint ด้วยการใช้ Aspose.Slides ซึ่งครอบคลุมการสร้างวงรีแบบง่าย การสร้างวงรีที่จัดรูปแบบ และการบันทึกงานนำเสนอที่อัปเดตเป็นไฟล์ PPTX นอกจากนี้ยังกล่าวถึงคำถามที่เกี่ยวข้อง เช่น การทำงานกับตำแหน่งและขนาดของวงรี การควบคุมลำดับการซ้อนกัน และการใช้เอฟเฟกต์แอนิเมชัน

## **สร้างวงรี**
เพื่อเพิ่มวงรีแบบง่ายลงในสไลด์ที่เลือกของงานนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) 
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ประเภท Ellipse โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดเผยโดยอ็อบเจกต์ [ShapeCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection) 
- เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างที่ให้ด้านล่าง เราได้เพิ่มวงรีลงในสไลด์แรก

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของ PPTX
var pres = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // เพิ่ม AutoShape ประเภทวงรี
    sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **สร้างวงรีที่จัดรูปแบบ**
เพื่อเพิ่มวงรีที่จัดรูปแบบอย่างดีขึ้นลงในสไลด์ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation) 
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม AutoShape ประเภท Ellipse โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดเผยโดยอ็อบเจกต์ [ShapeCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection) 
- ตั้งค่า Fill Type ของวงรีเป็น Solid
- ตั้งค่าสีของวงรีโดยใช้คุณสมบัติ SolidFillColor.Color ที่เปิดเผยโดยอ็อบเจกต์ [FillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FillFormat) ที่เชื่อมโยงกับอ็อบเจกต์ [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape) 
- ตั้งค่าสีของเส้นของวงรี
- ตั้งค่าความกว้างของเส้นของวงรี
- เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างที่ให้ด้านล่าง เราได้เพิ่มวงรีที่จัดรูปแบบลงในสไลด์แรกของงานนำเสนอ

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของ PPTX
var pres = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // เพิ่ม AutoShape ประเภทวงรี
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 150, 150, 50);
    // ใช้การจัดรูปแบบบางอย่างกับรูปร่างวงรี
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.Chocolate));
    // ใช้การจัดรูปแบบบางอย่างกับเส้นของวงรี
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("EllipseShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
 
## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าตำแหน่งและขนาดที่แม่นยำของวงรีโดยอิงกับหน่วยของสไลด์ได้อย่างไร?**

พิกัดและขนาดโดยทั่วไปจะกำหนดเป็น **จุด** (points) เพื่อให้ได้ผลลัพธ์ที่คาดเดาได้ ควรอ้างอิงการคำนวณกับขนาดของสไลด์และแปลงมิลลิเมตรหรืออินช์ที่ต้องการเป็นจุดก่อนกำหนดค่า

**ฉันจะวางวงรีให้เหนือหรือใต้วัตถุอื่นได้อย่างไร (ควบคุมลำดับการซ้อนกัน)?**

ปรับลำดับการวาดของอ็อบเจกต์โดยนำไปให้อยู่ด้านหน้า (bring to front) หรือส่งไปยังด้านหลัง (send to back) ซึ่งทำให้วงรีสามารถทับซ้อนกับวัตถุอื่นหรือเผยให้เห็นวัตถุที่อยู่ด้านล่างได้

**ฉันจะทำให้วงรีมีการแอนิเมชันการปรากฏหรือการเน้นอย่างไร?**

ใช้เอฟเฟกต์ [Apply](/slides/th/nodejs-java/shape-animation/) แบบเข้า (entrance), เน้น (emphasis) หรือออก (exit) กับรูปร่าง, แล้วกำหนด Trigger และเวลาเพื่อควบคุมว่าแอนิเมชันจะทำงานเมื่อใดและอย่างไร