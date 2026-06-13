---
title: เพิ่มสี่เหลี่ยมผืนผ้าในงานนำเสนอด้วย JavaScript
linktitle: สี่เหลี่ยมผืนผ้า
type: docs
weight: 80
url: /th/nodejs-java/rectangle/
keywords:
- เพิ่มสี่เหลี่ยมผืนผ้า
- สร้างสี่เหลี่ยมผืนผ้า
- รูปทรงสี่เหลี่ยมผืนผ้า
- สี่เหลี่ยมผืนผ้าง่าย
- สี่เหลี่ยมผืนผ้ารูปแบบ
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เสริมงานนำเสนอ PowerPoint ของคุณด้วยการเพิ่มสี่เหลี่ยมผืนผ้าด้วย JavaScript และ Aspose.Slides สำหรับ Node.js—ออกแบบและแก้ไขรูปทรงได้อย่างง่ายดายโดยใช้โปรแกรม"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการเพิ่มรูปทรงสี่เหลี่ยมผืนผ้าลงในสไลด์ PowerPoint โดยใช้ Aspose.Slides ครอบคลุมการสร้างสี่เหลี่ยมผืนผ้าธรรมดา, การสร้างสี่เหลี่ยมผืนผ้ารูปแบบ, และการบันทึกงานนำเสนอที่อัปเดตเป็นไฟล์ PPTX  

คุณยังจะได้เห็นวิธีการกำหนดรูปแบบพื้นฐานของสี่เหลี่ยมผืนผ้า เช่น สีเติมพื้นทึบ, สีเส้น, และความกว้างของเส้น นอกจากนี้ส่วนคำถามที่พบบ่อยของบทความยังชี้ไปที่งานที่เกี่ยวข้องกับสี่เหลี่ยมผืนผ้า เช่น มุมโค้ง, เติมรูปภาพ, เอฟเฟกต์ภาพ, ไฮเปอร์ลิงก์, การล็อกรูปร่าง, ตัวเลือกการส่งออก, และคุณสมบัติที่มีผลจริง  

## **เพิ่มสี่เหลี่ยมผืนผ้าลงในสไลด์**

เช่นหัวข้อก่อนหน้า, หัวข้อนี้ก็เกี่ยวกับการเพิ่มรูปทรงและในครั้งนี้รูปทรงที่เราจะพูดถึงคือสี่เหลี่ยมผืนผ้า ในหัวข้อนี้เราได้อธิบายว่านักพัฒนาสามารถเพิ่มสี่เหลี่ยมผืนผ้าธรรมดาหรือที่มีรูปแบบลงในสไลด์ของพวกเขาโดยใช้ Aspose.Slides  

หากต้องการเพิ่มสี่เหลี่ยมผืนผ้าธรรมดาลงในสไลด์ที่เลือกของงานนำเสนอ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape) ชนิด Rectangle โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดให้ใช้โดยออบเจ็กต์ [ShapeCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection)
- เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ในตัวอย่างด้านล่าง เราได้เพิ่มสี่เหลี่ยมผืนผ้าธรรมดาลงในสไลด์แรกของงานนำเสนอ

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // เพิ่ม AutoShape ประเภท ellipse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("RecShp1.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เพิ่มสี่เหลี่ยมผืนผ้ารูปแบบลงในสไลด์**

หากต้องการเพิ่มสี่เหลี่ยมผืนผ้ารูปแบบลงในสไลด์ โปรดทำตามขั้นตอนต่อไปนี้:

- สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)
- รับอ้างอิงของสไลด์โดยใช้ Index ของมัน
- เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/AutoShape) ชนิด Rectangle โดยใช้เมธอด [addAutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection#addAutoShape-int-float-float-float-float-) ที่เปิดให้ใช้โดยออบเจ็กต์ [ShapeCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection)
- ตั้งค่า [Fill Type](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FillType) ของสี่เหลี่ยมผืนผ้าเป็น Solid
- ตั้งค่าสีของสี่เหลี่ยมผืนผ้าโดยใช้เมธอด [SolidFillColor.setColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ColorFormat#setColor-java.awt.Color-) ที่เปิดให้ใช้โดยออบเจ็กต์ [FillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/FillFormat) ที่เชื่อมโยงกับออบเจ็กต์ [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Shape)
- ตั้งค่าสีของเส้นของสี่เหลี่ยมผืนผ้า
- ตั้งค่าความกว้างของเส้นของสี่เหลี่ยมผืนผ้า
- เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

ขั้นตอนข้างต้นได้ถูกนำไปใช้ในตัวอย่างด้านล่าง

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // เพิ่ม AutoShape ประเภท ellipse
    var shp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 50);
    // ทำการกำหนดรูปแบบบางอย่างให้กับรูปร่าง ellipse
    shp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    // ทำการกำหนดรูปแบบบางอย่างให้กับเส้นของ Ellipse
    shp.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shp.getLineFormat().setWidth(5);
    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("RecShp2.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันจะเพิ่มสี่เหลี่ยมผืนผ้าที่มุมโค้งได้อย่างไร?**  
ใช้ [shape type](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapetype/) ที่มีมุมโค้งและปรับรัศมีของมุมในคุณสมบัติของรูปร่าง; การทำมุมโค้งยังสามารถกำหนดแยกตามมุมผ่านการปรับแต่งเรขาคณิตได้  

**ฉันจะเติมสี่เหลี่ยมผืนผ้าด้วยรูปภาพ (เทกเจอร์) ได้อย่างไร?**  
เลือก [fill type](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/filltype/) ของรูปภาพ, ระบุแหล่งภาพ, และกำหนด [stretching/tiling modes](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillmode/)  

**สี่เหลี่ยมผืนผ้าสามารถมีเงาและแสงเรืองรองได้หรือไม่?**  
ใช่. มี [Outer/inner shadow, glow, and soft edges](/slides/th/nodejs-java/shape-effect/) ที่สามารถปรับพารามิเตอร์ได้  

**ฉันสามารถเปลี่ยนส四เหลี่ยมผืนผ้าให้เป็นปุ่มพร้อมไฮเปอร์ลิงก์ได้หรือไม่?**  
ใช่. สามารถ [Assign a hyperlink](/slides/th/nodejs-java/manage-hyperlinks/) ให้กับการคลิกรูปร่าง (กระโดดไปยังสไลด์, ไฟล์, ที่อยู่เว็บ, หรืออีเมล)  

**ฉันจะป้องกันไม่ให้สี่เหลี่ยมผืนผ้าเคลื่อนย้ายหรือเปลี่ยนแปลงได้อย่างไร?**  
ใช้การล็อกรูปร่าง: คุณสามารถห้ามการย้าย, ปรับขนาด, การเลือก, หรือการแก้ไขข้อความเพื่อรักษาเค้าโครง  

**ฉันสามารถแปลงสี่เหลี่ยมผืนผ้าเป็นภาพแรสเตอร์หรือ SVG ได้หรือไม่?**  
ใช่. คุณสามารถ [render the shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getImage) เป็นภาพที่มีขนาด/สเกลที่ระบุ หรือ [export it as SVG](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/writeassvg/) สำหรับใช้เป็นเวกเตอร์  

**ฉันจะรับคุณสมบัติที่แท้จริง (effective) ของสี่เหลี่ยมผืนผ้าโดยพิจารณาธีมและการสืบทอดได้อย่างรวดเร็วอย่างไร?**  
[Use the shape’s effective properties](/slides/th/nodejs-java/shape-effective-properties/): API จะส่งค่าที่คำนวณแล้วซึ่งพิจารณาถึงสไตล์ของธีม, เค้าโครง, และการตั้งค่าท้องถิ่น ทำให้การวิเคราะห์รูปแบบง่ายขึ้น