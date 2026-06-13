---
title: เพิ่มสี่เหลี่ยมลงในงานนำเสนอด้วย Java
linktitle: สี่เหลี่ยม
type: docs
weight: 80
url: /th/java/rectangle/
keywords:
- เพิ่มสี่เหลี่ยม
- สร้างสี่เหลี่ยม
- รูปร่างสี่เหลี่ยม
- สี่เหลี่ยมง่าย
- สี่เหลี่ยมที่กำหนดรูปแบบ
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เพิ่มพลังให้การนำเสนอ PowerPoint ของคุณด้วยการเพิ่มสี่เหลี่ยมด้วย Aspose.Slides สำหรับ Java - ออกแบบและแก้ไขรูปร่างได้อย่างง่ายดายด้วยโปรแกรม"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการเพิ่มรูปสี่เหลี่ยมไปยังสไลด์ PowerPoint โดยใช้ Aspose.Slides ครอบคลุมการสร้างสี่เหลี่ยมธรรมดา, การสร้างสี่เหลี่ยมที่มีการจัดรูปแบบ, และการบันทึกงานนำเสนอที่อัปเดตเป็นไฟล์ PPTX

คุณจะได้เห็นวิธีการกำหนดรูปแบบพื้นฐานของสี่เหลี่ยม เช่น สีเติมเต็มแบบทึบ, สีเส้น, และความกว้างของเส้น นอกจากนี้ส่วนคำถามที่พบบ่อยของบทความยังชี้ไปยังงานที่เกี่ยวข้องกับสี่เหลี่ยม เช่น มุมโค้ง, การเติมภาพ, เอฟเฟ็กต์ภาพ, ไฮเปอร์ลิงก์, การล็อกรูปร่าง, ตัวเลือกการส่งออก, และคุณสมบัติที่มีผล

## **เพิ่มสี่เหลี่ยมลงในสไลด์**
เพื่อเพิ่มสี่เหลี่ยมธรรมดาลงในสไลด์ที่เลือกของงานนำเสนอ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation)  
- ดึงอ้างอิงของสไลด์โดยใช้ Index ของมัน  
- เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) ประเภท Rectangle โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดเผยโดยอ็อบเจกต์ [IShapeCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection)  
- บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มสี่เหลี่ยมธรรมดาลงในสไลด์แรกของงานนำเสนอ

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape แบบวงรี
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // เขียนไฟล์ PPTX ลงดิสก์
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เพิ่มสี่เหลี่ยมที่มีการจัดรูปแบบลงในสไลด์**
เพื่อเพิ่มสี่เหลี่ยมที่มีการจัดรูปแบบลงในสไลด์ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation)  
- ดึงอ้างอิงของสไลด์โดยใช้ Index ของมัน  
- เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IAutoShape) ประเภท Rectangle โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดเผยโดยอ็อบเจกต์ [IShapeCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShapeCollection)  
- ตั้งค่า [Fill Type](https://reference.aspose.com/slides/th/java/com.aspose.slides/FillType) ของสี่เหลี่ยมเป็น Solid  
- ตั้งค่าสีของสี่เหลี่ยมโดยใช้เมธอด [SolidFillColor.setColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) ที่เปิดเผยโดยอ็อบเจกต์ [IFillFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/IFillFormat) ที่เชื่อมโยงกับอ็อบเจกต์ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/IShape)  
- ตั้งค่าสีของเส้นของสี่เหลี่ยม  
- ตั้งค่าความกว้างของเส้นของสี่เหลี่ยม  
- บันทึกงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ขั้นตอนด้านบนถูกนำไปใช้ในตัวอย่างด้านล่าง

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภทวงรี
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // กำหนดการจัดรูปแบบบางอย่างให้กับรูปร่างวงรี
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // กำหนดการจัดรูปแบบบางอย่างให้กับเส้นของวงรี
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันจะเพิ่มสี่เหลี่ยมที่มุมโค้งได้อย่างไร?**

ใช้ [shape type](https://reference.aspose.com/slides/th/java/com.aspose.slides/shapetype/) ที่มีมุมโค้งและปรับรัศมีของมุมในคุณสมบัติของรูปร่าง; สามารถทำให้มุมโค้งแยกตามมุมได้ผ่านการปรับ geometry

**ฉันจะเติมสี่เหลี่ยมด้วยรูปภาพ (เท็กซ์เจอร์) ได้อย่างไร?**

เลือก [fill type](https://reference.aspose.com/slides/th/java/com.aspose.slides/filltype/) แบบ picture, ระบุแหล่งภาพ, และกำหนด [stretching/tiling modes](https://reference.aspose.com/slides/th/java/com.aspose.slides/picturefillmode/)

**สี่เหลี่ยมสามารถมีเงาและแสงรอบได้หรือไม่?**

ได้. [Outer/inner shadow, glow, and soft edges](/slides/th/java/shape-effect/) มีให้ใช้พร้อมพารามิเตอร์ที่ปรับได้

**ฉันจะทำให้สี่เหลี่ยมเป็นปุ่มพร้อมไฮเปอร์ลิงก์ได้หรือไม่?**

ได้. [Assign a hyperlink](/slides/th/java/manage-hyperlinks/) ให้กับคลิกของรูปร่าง (ไปยังสไลด์, ไฟล์, ที่อยู่เว็บ, หรืออีเมล)

**ฉันจะป้องกันไม่ให้สี่เหลี่ยมเคลื่อนที่หรือเปลี่ยนแปลงได้อย่างไร?**

[Use shape locks](/slides/th/java/applying-protection-to-presentation/): สามารถห้ามการย้าย, การปรับขนาด, การเลือก, หรือการแก้ไขข้อความเพื่อคงรูปแบบ

**ฉันสามารถแปลงสี่เหลี่ยมเป็นภาพเรสเตอร์หรือ SVG ได้หรือไม่?**

ได้. คุณสามารถ [render the shape](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#getImage-int-float-float-) เป็นภาพด้วยขนาด/สเกลที่กำหนด หรือ [export it as SVG](https://reference.aspose.com/slides/th/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) เพื่อใช้เป็นเวกเตอร์

**ฉันจะดึงคุณสมบัติเชิงประสิทธิผลของสี่เหลี่ยมที่พิจารณาธีมและการสืบทอดอย่างรวดเร็วได้อย่างไร?**

[Use the shape’s effective properties](/slides/th/java/shape-effective-properties/): API จะคืนค่าที่คำนวณแล้วซึ่งคำนึงถึงสไตล์ธีม, เลย์เอาต์, และการตั้งค่าท้องถิ่น ช่วยให้ง่ายต่อการวิเคราะห์การจัดรูปแบบ