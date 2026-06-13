---
title: จัดการย่อหน้าข้อความ PowerPoint ใน JavaScript
linktitle: จัดการย่อหน้า
type: docs
weight: 40
url: /th/nodejs-java/manage-paragraph/
keywords:
- เพิ่มข้อความ
- เพิ่มย่อหน้า
- จัดการข้อความ
- จัดการย่อหน้า
- จัดการหัวข้อย่อย
- การเยื้องย่อหน้า
- การเยื้องแขวน
- หัวข้อย่อยย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อย่อย
- คุณสมบัติจัดย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เชี่ยวชาญการจัดรูปแบบย่อหน้าด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java—ปรับแต่งการจัดตำแหน่ง, การเว้นระยะและสไตล์ในงานนำเสนอ PPT, PPTX และ ODP ด้วย JavaScript."
---
## **บทนำ**

Aspose.Slides มีคลาสต่าง ๆ ที่คุณต้องการในการทำงานกับข้อความ PowerPoint, ย่อหน้า, และส่วนต่าง ๆ ใน Java.

* Aspose.Slides มีคลาส [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) เพื่อให้คุณสามารถเพิ่มอ็อบเจกต์ที่เป็นตัวแทนของย่อหน้าได้ อ็อบเจกต์ `TextFame` สามารถมีหนึ่งหรือหลายย่อหน้า (แต่ละย่อหน้าได้ถูกสร้างด้วยการขึ้นบรรทัดใหม่)
* Aspose.Slides มีคลาส [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) เพื่อให้คุณเพิ่มอ็อบเจกต์ที่เป็นตัวแทนของส่วนข้อความ อ็อบเจกต์ `Paragraph` สามารถมีหนึ่งหรือหลายส่วน (คอลเลกชันของอ็อบเจกต์ส่วนข้อความ)
* Aspose.Slides มีคลาส [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) เพื่อให้คุณสามารถเพิ่มอ็อบเจกต์ที่เป็นตัวแทนของข้อความและคุณสมบัติการจัดรูปแบบของมัน

อ็อบเจกต์ `Paragraph` สามารถจัดการกับข้อความที่มีคุณสมบัติการจัดรูปแบบต่าง ๆ ผ่านอ็อบเจกต์ `Portion` ที่เป็นฐานของมัน

## **เพิ่มหลายย่อหน้าที่มีหลายส่วน**

ขั้นตอนต่อไปนี้แสดงวิธีการเพิ่ม TextFrame ที่มี 3 ย่อหน้าและแต่ละย่อหน้ามี 3 Portion:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงการอ้างอิงของสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์
4. รับ ITextFrame ที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/)
5. สร้างอ็อบเจกต์ [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) สองตัวและเพิ่มเข้าไปในคอลเลกชัน `IParagraphs` ของ [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/)
6. สร้างอ็อบเจกต์ [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) สามตัวสำหรับแต่ละ `Paragraph` ใหม่ (สำหรับ Paragraph เริ่มต้นสร้าง Portion สองตัว) แล้วเพิ่มแต่ละอ็อบเจกต์ `Portion` เข้าไปในคอลเลกชัน IPortion ของแต่ละ `Paragraph`
7. ตั้งค่าข้อความบางส่วนให้แต่ละ Portion
8. ใช้คุณสมบัติการจัดรูปแบบที่คุณต้องการกับแต่ละ Portion โดยอ้างอิงจากคุณสมบัติการจัดรูปแบบของอ็อบเจกต์ `Portion`
9. บันทึกการนำเสนอที่แก้ไขแล้ว

โค้ด Javascript นี้เป็นการดำเนินการตามขั้นตอนสำหรับการเพิ่มย่อหน้าที่มี Portion:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // เพิ่ม AutoShape ชนิดสี่เหลี่ยมผืนผ้า
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // เข้าถึง TextFrame ของ AutoShape
    var tf = ashp.getTextFrame();
    // สร้าง Paragraphs และ Portions พร้อมรูปแบบข้อความที่ต่างกัน
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // บันทึก PPTX ลงดิสก์
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **จัดการรายการหัวข้อย่อยของย่อหน้า**

รายการหัวข้อย่อยช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าที่มีหัวข้อย่อยมักอ่านง่ายและเข้าใจได้ดีกว่า

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงการอ้างอิงของสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์ที่เลือก
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของ AutoShape
5. ลบย่อหน้าเริ่มต้นที่อยู่ใน `TextFrame`
6. สร้างอินสแตนซ์ย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/)
7. ตั้งค่า `Type` ของหัวข้อย่อยเป็น `Symbol` และตั้งค่าตัวอักษรหัวข้อย่อย
8. ตั้งค่า `Text` ของย่อหน้า
9. ตั้งค่า `Indent` ของหัวข้อย่อยสำหรับย่อหน้า
10. ตั้งค่าสีของหัวข้อย่อย
11. ตั้งค่าความสูงของหัวข้อย่อย
12. เพิ่มย่อหน้าใหม่เข้าไปในคอลเลกชันย่อหน้าของ `TextFrame`
13. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนตั้งแต่ 7 ถึง 13
14. บันทึกการนำเสนอ

โค้ด Javascript นี้แสดงวิธีการเพิ่มหัวข้อย่อยให้กับย่อหน้า:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // เพิ่มและเข้าถึง Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // เข้าถึง TextFrame ของ autoshape
    var txtFrm = aShp.getTextFrame();
    // ลบย่อหน้าเริ่มต้น
    txtFrm.getParagraphs().removeAt(0);
    // สร้างย่อหน้า
    var para = new aspose.slides.Paragraph();
    // ตั้งสไตล์และสัญลักษณ์หัวข้อย่อยของย่อหน้า
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // ตั้งข้อความของย่อหน้า
    para.setText("Welcome to Aspose.Slides");
    // ตั้งการเยื้องหัวข้อย่อย
    para.getParagraphFormat().setIndent(25);
    // ตั้งสีหัวข้อย่อย
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// ตั้ง IsBulletHardColor เป็น true เพื่อใช้สีหัวข้อย่อยของคุณเอง
    // ตั้งความสูงของหัวข้อย่อย
    para.getParagraphFormat().getBullet().setHeight(100);
    // เพิ่มย่อหน้าไปยัง TextFrame
    txtFrm.getParagraphs().add(para);
    // สร้างย่อหน้าที่สอง
    var para2 = new aspose.slides.Paragraph();
    // ตั้งประเภทและสไตล์หัวข้อย่อยของย่อหน้า
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // เพิ่มข้อความย่อหน้า
    para2.setText("This is numbered bullet");
    // ตั้งการเยื้องหัวข้อย่อย
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// ตั้ง IsBulletHardColor เป็น true เพื่อใช้สีหัวข้อย่อยของคุณเอง
    // ตั้งความสูงของหัวข้อย่อย
    para2.getParagraphFormat().getBullet().setHeight(100);
    // เพิ่มย่อหน้าไปยัง TextFrame
    txtFrm.getParagraphs().add(para2);
    // บันทึกการนำเสนอที่แก้ไขแล้ว
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **จัดการหัวข้อย่อยแบบรูปภาพ**

รายการหัวข้อย่อยช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าที่ใช้รูปภาพเป็นหัวข้อย่อยอ่านง่ายและเข้าใจได้ดี

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงการอ้างอิงของสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของ AutoShape
5. ลบย่อหน้าเริ่มต้นที่อยู่ใน `TextFrame`
6. สร้างอินสแตนซ์ย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/)
7. โหลดรูปภาพด้วย [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/)
8. ตั้งค่า `Type` ของหัวข้อย่อยเป็น [Picture](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) และกำหนดรูปภาพ
9. ตั้งค่า `Text` ของ Paragraph
10. ตั้งค่า `Indent` ของหัวข้อย่อยสำหรับ Paragraph
11. ตั้งค่าสีของหัวข้อย่อย
12. ตั้งค่าความสูงของหัวข้อย่อย
13. เพิ่มย่อหน้าใหม่เข้าไปในคอลเลกชันย่อหน้าของ `TextFrame`
14. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนตามที่กล่าวข้างต้น
15. บันทึกการนำเสนอที่แก้ไขแล้ว

โค้ด Javascript นี้แสดงวิธีการเพิ่มและจัดการหัวข้อย่อยแบบรูปภาพ:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
var presentation = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var slide = presentation.getSlides().get_Item(0);
    // สร้างอิมเมจสำหรับหัวข้อย่อยแบบรูปภาพ
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // เพิ่มและเข้าถึง Autoshape
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // เข้าถึง TextFrame ของ autoshape
    var textFrame = autoShape.getTextFrame();
    // ลบย่อหน้าเริ่มต้น
    textFrame.getParagraphs().removeAt(0);
    // สร้างย่อหน้าใหม่
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // ตั้งสไตล์หัวข้อย่อยและรูปภาพของย่อหน้า
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // ตั้งความสูงของหัวข้อย่อย
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // เพิ่มย่อหน้าไปยัง TextFrame
    textFrame.getParagraphs().add(paragraph);
    // บันทึกการนำเสนอเป็นไฟล์ PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // บันทึกการนำเสนอเป็นไฟล์ PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **จัดการหัวข้อย่อยระดับหลายชั้น**

รายการหัวข้อย่อยช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ หัวข้อย่อยหลายระดับอ่านง่ายและเข้าใจได้ดี

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงการอ้างอิงของสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ในสไลด์ใหม่
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของ AutoShape
5. ลบย่อหน้าเริ่มต้นที่อยู่ใน `TextFrame`
6. สร้างอินสแตนซ์ย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) และกำหนดความลึกเป็น 0
7. สร้างอินสแตนซ์ย่อหน้าที่สองผ่านคลาส `Paragraph` และกำหนดความลึกเป็น 1
8. สร้างอินสแตนซ์ย่อหน้าที่สามผ่านคลาส `Paragraph` และกำหนดความลึกเป็น 2
9. สร้างอินสแตนซ์ย่อหน้าที่สี่ผ่านคลาส `Paragraph` และกำหนดความลึกเป็น 3
10. เพิ่มย่อหน้าใหม่เหล่านี้เข้าไปในคอลเลกชันย่อหน้าของ `TextFrame`
11. บันทึกการนำเสนอที่แก้ไขแล้ว

โค้ด Javascript นี้แสดงวิธีการเพิ่มและจัดการหัวข้อย่อยหลายระดับ:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // เพิ่มและเข้าถึง Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // เข้าถึง TextFrame ของ Autoshape ที่สร้างขึ้น
    var text = aShp.addTextFrame("");
    // ลบย่อหน้าเริ่มต้น
    text.getParagraphs().clear();
    // เพิ่มย่อหน้าแรก
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // ตั้งระดับหัวข้อย่อย
    para1.getParagraphFormat().setDepth(0);
    // เพิ่มย่อหน้าที่สอง
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // ตั้งระดับหัวข้อย่อย
    para2.getParagraphFormat().setDepth(1);
    // เพิ่มย่อหน้าที่สาม
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // ตั้งระดับหัวข้อย่อย
    para3.getParagraphFormat().setDepth(2);
    // เพิ่มย่อหน้าที่สี่
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // ตั้งระดับหัวข้อย่อย
    para4.getParagraphFormat().setDepth(3);
    // เพิ่มย่อหน้าเข้าไปในคอลเลกชัน
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // บันทึกการนำเสนอเป็นไฟล์ PPTX
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **จัดการย่อหน้าด้วยรายการลำดับเลขแบบกำหนดเอง**

คลาส [BulletFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/) มีคุณสมบัติ [NumberedBulletStartWith](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) และอื่น ๆ ที่ช่วยให้คุณจัดการย่อหน้าด้วยการนับเลขหรือการจัดรูปแบบที่กำหนดเอง

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่มีย่อหน้า
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของ AutoShape
5. ลบย่อหน้าเริ่มต้นที่อยู่ใน `TextFrame`
6. สร้างอินสแตนซ์ย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) และตั้งค่า [NumberedBulletStartWith](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) เป็น 2
7. สร้างอินสแตนซ์ย่อหน้าที่สองผ่านคลาส `Paragraph` และตั้งค่า `NumberedBulletStartWith` เป็น 3
8. สร้างอินสแตนซ์ย่อหน้าที่สามผ่านคลาส `Paragraph` และตั้งค่า `NumberedBulletStartWith` เป็น 7
9. เพิ่มย่อหน้าใหม่เหล่านี้เข้าไปในคอลเลกชันย่อหน้าของ `TextFrame`
10. บันทึกการนำเสนอที่แก้ไขแล้ว

โค้ด Javascript นี้แสดงวิธีการเพิ่มและจัดการย่อหน้าด้วยการนับเลขแบบกำหนดเอง:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // เข้าถึง TextFrame ของ Autoshape ที่สร้างขึ้น
    var textFrame = shape.getTextFrame();
    // ลบย่อหน้าเริ่มต้นที่มีอยู่
    textFrame.getParagraphs().removeAt(0);
    // รายการแรก
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **ตั้งค่าการเยื้องบรรทัดแรกของย่อหน้า**

ใช้เมธอด [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า เมธอดนี้จะย้ายเฉพาะบรรทัดแรกเทียบกับขอบซ้ายของย่อหน้า ค่าเชิงบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงอยู่ในตำแหน่งเดิม

ใช้ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ใช้ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างด้านล่างสร้างหลายย่อหน้าและกำหนดค่าเยื้องที่แตกต่างกันเพื่อสาธิตว่าเยื้องบรรทัดแรกมีผลต่อการจัดวางย่ออย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ว่างเปล่าลงในรูปร่างและลบย่อหน้าเริ่มต้น
5. สร้างหลายย่อหน้าและกำหนดค่า [Indent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) ที่แตกต่างกันให้แต่ละย่อหน้า
6. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame
7. บันทึกการนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่าเยื้องของย่อหน้า:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

## **ตั้งค่าการเยื้องแขวนสำหรับย่อหน้า**

การเยื้องแขวนคือรูปแบบการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ด้านซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยเมธอด [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) ให้กำหนดค่าเยื้องเป็นค่าลบเพื่อเลื่อนบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อย่อหน้า

โดยทั่วไป [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) กำหนดตำแหน่งซ้ายของเนื้อย่อหน้า และ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) กำหนดตำแหน่งของบรรทัดแรกสัมพันธ์กับขอบซ้ายนั้น เพื่อสร้างการเยื้องแขวน ให้กำหนดค่า `MarginLeft` เป็นบวกและ `Indent` เป็นลบ

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณนาการ, การอ้างอิง, รายการอภิธานศัพท์, และย่อหน้าอื่น ๆ ที่บรรทัดที่ต่อเนื่องต้องจัดตำแหน่งอยู่ใต้เนื้อย่อหน้าแทนที่จะอยู่ใต้ตัวอักษรตัวแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ว่างเปล่าลงในรูปร่างและลบย่อหน้าเริ่มต้น
5. สร้างย่อหน้าและกำหนดค่า `MarginLeft` เชิงบวกให้แต่ละย่อหน้า
6. ตั้งค่า `Indent` เชิงลบเพื่อสร้างเอฟเฟ็กต์เยื้องแขวน
7. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame
8. บันทึกการนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่าเยื้องแขวนสำหรับย่อหน้า:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![การเยื้องแขวนของย่อหน้า](hanging_indent.png)

## **จัดการคุณสมบัติ Run ของส่วนสุดท้ายสำหรับย่อหน้า**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
1. รับการอ้างอิงของสไลด์ที่มีย่อหน้าผ่านตำแหน่งของมัน
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์
1. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ที่มีสองย่อหน้าไปยังสี่เหลี่ยมผืนผ้า
1. ตั้งค่า `FontHeight` และประเภทฟอนต์สำหรับย่อหน้า
1. ตั้งค่าคุณสมบัติ End สำหรับย่อหน้า
1. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด Javascript นี้แสดงวิธีตั้งค่าคุณสมบัติ End สำหรับย่อหน้าใน PowerPoint:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **นำเข้า HTML Text เข้าไปในย่อหน้า**

Aspose.Slides มีการสนับสนุนขั้นสูงสำหรับการนำเข้า HTML Text เข้าไปในย่อหน้า

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงการอ้างอิงของสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์
4. เพิ่มและเข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของ `AutoShape`
5. ลบย่อหน้าเริ่มต้นที่อยู่ใน `TextFrame`
6. อ่านไฟล์ HTML ต้นฉบับด้วย TextReader
7. สร้างอินสแตนซ์ย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/)
8. เพิ่มเนื้อหาไฟล์ HTML ที่อ่านจาก TextReader ไปยัง [ParagraphCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphcollection/) ของ TextFrame
9. บันทึกการนำเสนอที่แก้ไขแล้ว

โค้ด Javascript นี้เป็นการดำเนินการตามขั้นตอนสำหรับการนำเข้า HTML Text เข้าไปในย่อหน้า:

```javascript
// สร้างอินสแตนซ์การนำเสนอเปล่า
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรกเริ่มต้นของการนำเสนอ
    var slide = pres.getSlides().get_Item(0);
    // เพิ่ม AutoShape เพื่อรองรับเนื้อหา HTML
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // เพิ่ม TextFrame ให้กับรูปร่าง
    ashape.addTextFrame("");
    // ลบย่อหน้าทั้งหมดใน TextFrame ที่เพิ่มเข้ามา
    ashape.getTextFrame().getParagraphs().clear();
    // โหลดไฟล์ HTML โดยใช้ StreamReader
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // เพิ่มข้อความจาก StreamReader ของ HTML เข้าไปใน TextFrame
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // บันทึกการนำเสนอ
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ส่งออกข้อความย่อหน้าเป็น HTML**

Aspose.Slides มีการสนับสนุนขั้นสูงสำหรับการส่งออกข้อความ (ที่อยู่ในย่อหน้า) ไปเป็น HTML

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) และโหลดการนำเสนอที่ต้องการ
2. เข้าถึงการอ้างอิงของสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เข้าถึงรูปร่างที่มีข้อความที่จะส่งออกเป็น HTML
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของรูปร่างนั้น
5. สร้างอินสแตนซ์ของ `StreamWriter` และเพิ่มไฟล์ HTML ใหม่
6. ให้ค่า Index เริ่มต้นกับ StreamWriter แล้วส่งออกย่อหน้าที่คุณต้องการ

โค้ด Javascript นี้แสดงวิธีส่งออกข้อความย่อหน้า PowerPoint เป็น HTML:

```javascript
// โหลดไฟล์การนำเสนอ
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // เข้าถึงสไลด์แรกเริ่มต้นของการนำเสนอ
    var slide = pres.getSlides().get_Item(0);
    // ดัชนีที่ต้องการ
    var index = 0;
    // เข้าถึงรูปร่างที่เพิ่มเข้ามา
    var ashape = slide.getShapes().get_Item(index);
    // สร้างไฟล์ HTML ผลลัพธ์
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // สกัดย่อหน้าแรกเป็น HTML
    // เขียนข้อมูลย่อหน้าไปยัง HTML โดยกำหนดดัชนีเริ่มต้นของย่อหน้าและจำนวนย่อหน้าที่จะคัดลอก
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **บันทึกย่อหน้าเป็นภาพ**

ในส่วนนี้ เราจะสำรวจสองตัวอย่างที่แสดงวิธีบันทึกย่อความข้อความ ซึ่งแทนด้วยคลาส [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) เป็นภาพ ตัวอย่างทั้งสองรวมถึงการดึงภาพของรูปร่างที่มีย่อหน้าด้วยเมธอด `getImage` ของคลาส [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) คำนวณขอบเขตของย่อหน้าในรูปร่าง และส่งออกเป็นภาพบิตแมพ วิธีเหล่านี้ช่วยให้คุณสกัดส่วนเฉพาะของข้อความจากการนำเสนอ PowerPoint และบันทึกเป็นภาพแยกต่างหาก ซึ่งอาจเป็นประโยชน์สำหรับการใช้งานต่อในหลายสถานการณ์

สมมติว่าเรามีไฟล์การนำเสนอชื่อ sample.pptx ที่มีสไลด์หนึ่งสไลด์ โดยรูปร่างแรกเป็นกล่องข้อความที่มีสามย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

**ตัวอย่างที่ 1**

ในตัวอย่างนี้ เราจะดึงย่อหน้าที่สองเป็นภาพ โดยทำการสกัดภาพของรูปร่างจากสไลด์แรกของการนำเสนอแล้วคำนวณขอบเขตของย่อหน้าที่สองใน TextFrame ของรูปร่าง ย่อหน้าจะถูกวาดใหม่ลงบนบิตแมพใหม่และบันทึกเป็นรูปแบบ PNG วิธีนี้มีประโยชน์เมื่อคุณต้องการบันทึกย่อหน้าที่เฉพาะเป็นภาพแยกโดยคงรักษาขนาดและการจัดรูปแบบเดิมของข้อความ

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // บันทึกรูปร่างในหน่วยความจำเป็นบิตแมพ.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // สร้างบิตแมพของรูปร่างจากหน่วยความจำ.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // คำนวณขอบเขตของย่อหน้าที่สอง.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // คำนวณพิกัดและขนาดสำหรับภาพผลลัพธ์ (ขนาดขั้นต่ำ 1x1 พิกเซล).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // ครอบตัดบิตแมพของรูปร่างเพื่อให้ได้บิตแมพของย่อหน้าเท่านั้น.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

ผลลัพธ์:

![ภาพย่อหน้า](paragraph_to_image_output.png)

**ตัวอย่างที่ 2**

ในตัวอย่างนี้ เราขยายวิธีการก่อนหน้าโดยเพิ่มปัจจัยการสเกลให้กับภาพย่อหน้า รูปร่างจะถูกสกัดจากการนำเสนอและบันทึกเป็นภาพด้วยปัจจัยสเกล `2` ซึ่งทำให้ได้ผลลัพธ์ความละเอียดสูงขึ้นเมื่อส่งออกย่อหน้า ขอบเขตของย่อหน้าจะถูกคำนวณโดยคำนึงถึงสเกล การสเกลเป็นประโยชน์เมื่อจำเป็นต้องมีภาพที่มีรายละเอียดมากขึ้น เช่น สำหรับการใช้ในสื่อพิมพ์คุณภาพสูง

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // บันทึกรูปร่างในหน่วยความจำเป็นบิตแมพพร้อมการสเกล.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // สร้างบิตแมพของรูปร่างจากหน่วยความจำ.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // คำนวณขอบเขตของย่อหน้าที่สอง.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // คำนวณพิกัดและขนาดสำหรับภาพผลลัพธ์ (ขนาดขั้นต่ำ 1x1 พิกเซล).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // ครอบตัดบิตแมพของรูปร่างเพื่อให้ได้บิตแมพของย่อหน้าเท่านั้น.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดภายใน TextFrame ได้หรือไม่?**

ได้ ใช้การตั้งค่าการตัดบรรทัดของ TextFrame ([setWrapText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/setwraptext/)) เพื่อปิดการตัดบรรทัด sehingga บรรทัดจะไม่ตัดที่ขอบของกรอบ

**ฉันจะรับขอบเขตบนสไลด์ของย่อหน้าที่ระบุได้อย่างแม่นยำอย่างไร?**

คุณสามารถดึงสี่เหลี่ยมขอบของย่อหน้า (หรือต้นส่วนเดียว) เพื่อทราบตำแหน่งและขนาดที่แม่นยำบนสไลด์

**การจัดแนวของย่อหน้า (ซ้าย/ขวา/กลาง/เติมเต็ม) ควบคุมที่ไหน?**

[setAlignment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setalignment/) เป็นเมธอดระดับย่อหน้าใน [ParagraphFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/) ซึ่งนำไปใช้กับย่อหน้าเต็ม ไม่ว่าการจัดรูปแบบของ Portion จะเป็นอย่างไร

**ฉันสามารถตั้งค่าภาษาตรวจสอบการสะกดสำหรับส่วนย่อหน้าบางส่วน (เช่น คำเดียว) ได้หรือไม่?**

ได้ ภาษาถูกตั้งค่าที่ระดับ Portion ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)) ดังนั้นจึงสามารถมีหลายภาษาในย่อหน้าเดียวกันได้.