---
title: เพิ่มสี่เหลี่ยมลงในงานนำเสนอบน Android
linktitle: สี่เหลี่ยม
type: docs
weight: 80
url: /th/androidjava/rectangle/
keywords:
- เพิ่มสี่เหลี่ยม
- สร้างสี่เหลี่ยม
- รูปร่างสี่เหลี่ยม
- สี่เหลี่ยมง่าย
- สี่เหลี่ยมที่จัดรูปแบบ
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เพิ่มพลังให้การนำเสนอ PowerPoint ของคุณด้วยการเพิ่มสี่เหลี่ยมด้วย Aspose.Slides สำหรับ Android ผ่าน Java—ออกแบบและแก้ไขรูปร่างได้อย่างง่ายดายโดยอัตโนมัติ."
---
## **ภาพรวม**

บทความนี้แสดงวิธีเพิ่มรูปสี่เหลี่ยมลงในสไลด์ PowerPoint โดยใช้ Aspose.Slides ครอบคลุมการสร้างสี่เหลี่ยมธรรมดา การสร้างสี่เหลี่ยมที่มีการจัดรูปแบบ และการบันทึกการนำเสนอที่อัปเดตเป็นไฟล์ PPTX

คุณยังจะได้เห็นวิธีใช้การจัดรูปแบบสี่เหลี่ยมพื้นฐาน เช่น สีเติมแบบทึบ สีเส้น และความกว้างของเส้น นอกจากนี้ส่วนคำถามที่พบบ่อยของบทความยังเชื่อมโยงไปยังงานสี่เหลี่ยมที่เกี่ยวข้อง รวมถึงมุมโค้ง การเติมรูปภาพ เอฟเฟกต์ภาพลักษณ์ ไฮเปอร์ลิงก์ การล็อกรูปร่าง ตัวเลือกการส่งออกและคุณสมบัติที่มีผล

## **เพิ่มสี่เหลี่ยมลงในสไลด์**
เพื่อเพิ่มสี่เหลี่ยมธรรมดาลงในสไลด์ที่เลือกของการนำเสนอ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) 
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAutoShape) ประเภท Rectangle ด้วยวิธี [addAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดให้ใช้โดยอ็อบเจ็กต์ [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection)
- เขียนการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มสี่เหลี่ยมธรรมดาลงในสไลด์แรกของการนำเสนอ

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภท ellipse
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **เพิ่มสี่เหลี่ยมที่จัดรูปแบบลงในสไลด์**
เพื่อเพิ่มสี่เหลี่ยมที่จัดรูปแบบลงในสไลด์ โปรดทำตามขั้นตอนด้านล่าง:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation) 
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IAutoShape) ประเภท Rectangle ด้วยวิธี [addAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดให้ใช้โดยอ็อบเจ็กต์ [IShapeCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShapeCollection)
- ตั้งค่า [Fill Type](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/FillType) ของสี่เหลี่ยมเป็น Solid
- ตั้งค่าสีของสี่เหลี่ยมโดยใช้วิธี [SolidFillColor.setColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) ที่เปิดให้ใช้โดยอ็อบเจ็กต์ [IFillFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IFillFormat) ที่เชื่อมกับอ็อบเจ็กต์ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/IShape)
- ตั้งค่าสีของเส้นของสี่เหลี่ยม
- ตั้งค่าความกว้างของเส้นของสี่เหลี่ยม
- เขียนการนำเสนอที่แก้ไขเป็นไฟล์ PPTX

ขั้นตอนข้างต้นได้ถูกนำไปใช้ในตัวอย่างด้านล่าง

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // ดึงสไลด์แรก
    ISlide sld = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภทวงรี
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // ปรับการจัดรูปแบบบางอย่างให้กับรูปร่างวงรี
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // ปรับการจัดรูปแบบบางอย่างให้กับเส้นของวงรี
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันจะเพิ่มสี่เหลี่ยมที่มุมโค้งได้อย่างไร?**

ใช้ [shape type](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shapetype/) ที่มีมุมโค้งและปรับค่ารัศมีของมุมในคุณสมบัติของรูปร่าง; สามารถทำให้มุมโค้งแยกตามมุมได้ด้วยการปรับเรขาคณิต

**ฉันจะเติมสี่เหลี่ยมด้วยภาพ (เทกซ์เจอร์) ได้อย่างไร?**

เลือก [fill type](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/filltype/) แบบ picture ให้แหล่งภาพและกำหนด [stretching/tiling modes](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/picturefillmode/)

**สี่เหลี่ยมสามารถมีเงาและแสงรอบได้หรือไม่?**

ได้. [Outer/inner shadow, glow, and soft edges](/slides/th/androidjava/shape-effect/) มีให้ใช้พร้อมพารามิเตอร์ที่ปรับได้

**ฉันสามารถแปลงสี่เหลี่ยมเป็นปุ่มพร้อมไฮเปอร์ลิงก์ได้หรือไม่?**

ได้. [Assign a hyperlink](/slides/th/androidjava/manage-hyperlinks/) ให้กับการคลิกรูปร่าง (กระโดดไปยังสไลด์, ไฟล์, เว็บไซต์ หรืออีเมล)

**ฉันจะป้องกันสี่เหลี่ยมจากการย้ายและการเปลี่ยนแปลงได้อย่างไร?**

ใช้การล็อกรูปร่าง: สามารถห้ามการย้าย, ปรับขนาด, การเลือก หรือการแก้ไขข้อความเพื่อคงรูปแบบไว้

**ฉันสามารถแปลงสี่เหลี่ยมเป็นภาพเรสเตอร์หรือ SVG ได้หรือไม่?**

ได้. คุณสามารถ [render the shape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) เป็นภาพด้วยขนาด/สเกลที่กำหนดหรือ [export it as SVG](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) เพื่อใช้งานแบบเวกเตอร์

**ฉันจะรับคุณสมบัติจริง (effective) ของสี่เหลี่ยมที่คำนึงถึงธีมและการสืบทอดได้อย่างรวดเร็วอย่างไร?**

[Use the shape’s effective properties](/slides/th/androidjava/shape-effective-properties/): API จะคืนค่าแบบคำนวณที่รวมสไตล์ธีม, การจัดวางและการตั้งค่าท้องถิ่น ทำให้การวิเคราะห์การจัดรูปแบบง่ายขึ้น