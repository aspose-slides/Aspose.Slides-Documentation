---
title: จัดการแบบอักษรในงานนำเสนอโดยใช้ JavaScript
linktitle: จัดการแบบอักษร
type: docs
weight: 10
url: /th/nodejs-java/manage-fonts/
keywords:
- จัดการแบบอักษร
- คุณสมบัติของแบบอักษร
- ย่อหน้า
- การจัดรูปแบบข้อความ
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ควบคุมแบบอักษรด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java: ฝัง, แทนที่และโหลดแบบอักษรที่กำหนดเองเพื่อให้การนำเสนอ PPT, PPTX และ ODP ชัดเจนและสอดคล้องกัน"
---
## **บทนำ**

งานนำเสนอส่วนใหญ่ประกอบด้วยข้อความและรูปภาพ ทั้งสองอย่างสามารถจัดรูปแบบได้หลายวิธี ไม่ว่าจะเพื่อเน้นส่วนหรือคำเฉพาะหรือเพื่อให้สอดคล้องกับสไตล์ขององค์กร การจัดรูปแบบข้อความช่วยให้ผู้ใช้ปรับรูปลักษณ์และความรู้สึกของเนื้อหาในงานนำเสนอได้ บทความนี้แสดงวิธีใช้ Aspose.Slides for Node.js via Java เพื่อกำหนดคุณสมบัติของแบบอักษรในย่อหน้าข้อความบนสไลด์

## **จัดการคุณสมบัติที่เกี่ยวข้องกับแบบอักษร**

เพื่อจัดการคุณสมบัติของแบบอักษรในย่อหน้าโดยใช้ Aspose.Slides for Node.js via Java:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)  
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน  
1. เข้าถึงรูปร่าง [Placeholder](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/placeholder/) ในสไลด์และแปลงประเภทเป็น [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/)  
1. รับ [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) จาก [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ที่ถูกเปิดเผยโดย [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/)  
1. จัดแนวย่อหน้าแบบจัดเต็ม  
1. เข้าถึง [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) ของข้อความใน [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/)  
1. กำหนดแบบอักษรโดยใช้ [FontData](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fontdata/) และตั้งค่า **Font** ของ [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) ให้สอดคล้อง  
   1. ตั้งค่าแบบอักษรให้เป็นตัวหนา  
   1. ตั้งค่าแบบอักษรให้เป็นตัวเอียง  
1. ตั้งค่าสีของแบบอักษรโดยใช้ [FillFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fillformat/) ที่ถูกเปิดเผยโดยวัตถุ [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/)  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

การดำเนินการตามขั้นตอนข้างต้นแสดงด้านล่าง จะรับไฟล์งานนำเสนอที่ยังไม่ได้ตกแต่งและจัดรูปแบบแบบอักษรบนสไลด์หนึ่ง ภาพหน้าจอที่ตามมาจะแสดงไฟล์ต้นฉบับและวิธีที่โค้ดสคริปต์ทำการเปลี่ยนแปลง ทั้งการเปลี่ยนแบบอักษร สี และสไตล์ของแบบอักษร

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**รูปที่ 1: ข้อความในไฟล์ต้นฉบับ**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**รูปที่ 2: ข้อความเดียวกันพร้อมการจัดรูปแบบที่อัพเดต**|

```javascript
// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์ PPTX
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // เข้าถึงสไลด์โดยใช้ตำแหน่งของสไลด์
    var slide = pres.getSlides().get_Item(0);
    // เข้าถึง placeholder ตัวแรกและตัวที่สองในสไลด์และแปลงประเภทเป็น AutoShape
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // เข้าถึง Paragraph ตัวแรก
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // จัดแนวย่อหน้า
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // เข้าถึง portion ตัวแรก
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // กำหนดแบบอักษรใหม่
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // กำหนดแบบอักษรใหม่ให้กับ portion
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // ตั้งค่าแบบอักษรเป็นตัวหนา
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // ตั้งค่าแบบอักษรเป็นตัวเอียง
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // ตั้งค่าสีของแบบอักษร
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // บันทึกไฟล์ PPTX ลงดิสก์
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งค่าคุณสมบัติแบบอักษรของข้อความ**
{{% alert color="primary" %}} 

ตามที่ได้กล่าวไว้ใน **จัดการคุณสมบัติที่เกี่ยวข้องกับแบบอักษร** การใช้ [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) จะช่วยเก็บข้อความที่มีรูปแบบเดียวกันในย่อหน้า บทความนี้แสดงวิธีใช้ Aspose.Slides for Node.js via Java เพื่อสร้างกล่องข้อความที่มีข้อความบางส่วน แล้วกำหนดแบบอักษรเฉพาะ รวมถึงคุณสมบัติต่าง ๆ ของกลุ่มแบบอักษร

{{% /alert %}} 

เพื่อสร้างกล่องข้อความและตั้งค่าคุณสมบัติของแบบอักษรในข้อความ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation)  
1. รับอ้างอิงของสไลด์โดยใช้ดัชนีของมัน  
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ชนิด **Rectangle** ลงในสไลด์  
1. ลบสไตล์การเติมที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/)  
1. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของ [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/)  
1. เพิ่มข้อความบางส่วนลงใน [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/)  
1. เข้าถึงวัตถุ [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) ที่เชื่อมโยงกับ [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/)  
1. กำหนดแบบอักษรที่จะใช้สำหรับ [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/)  
1. ตั้งค่าคุณสมบัติอื่น ๆ ของแบบอักษรเช่น ตัวหนา, ตัวเอียง, การขีดเส้นใต้, สีและขนาดโดยใช้คุณสมบัติที่เปิดเผยโดยวัตถุ [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/)  
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

การดำเนินการตามขั้นตอนข้างต้นแสดงด้านล่าง

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**รูปที่ 3: ข้อความที่มีคุณสมบัติแบบอักษรถูกตั้งค่าโดย Aspose.Slides for Node.js via Java**|

```javascript
// สร้างอ็อบเจกต์ Presentation ที่เป็นตัวแทนของไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // ดึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // เพิ่ม AutoShape ชนิด Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // ลบสไตล์การเติมใด ๆ ที่เชื่อมโยงกับ AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // เข้าถึง TextFrame ที่เชื่อมโยงกับ AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // เข้าถึง Portion ที่เชื่อมโยงกับ TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // ตั้งค่าแบบอักษรสำหรับ Portion
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // ตั้งค่าคุณสมบัติ Bold ของแบบอักษร
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // ตั้งค่าคุณสมบัติ Italic ของแบบอักษร
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // ตั้งค่าคุณสมบัติ Underline ของแบบอักษร
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // ตั้งค่าขนาดความสูงของแบบอักษร
    port.getPortionFormat().setFontHeight(25);
    // ตั้งค่าสีของแบบอักษร
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // บันทึกงานนำเสนอลงดิสก์
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```