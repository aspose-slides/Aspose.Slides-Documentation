---
title: จัดการย่อความข้อความ PowerPoint ใน JavaScript
linktitle: จัดการย่อหน้า
type: docs
weight: 40
url: /th/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- เพิ่มข้อความ
- เพิ่มย่อหน้า
- จัดการข้อความ
- จัดการย่อหน้า
- จัดการหัวข้อย่อย
- เยื้องย่อหน้า
- เยื้องห้อย
- หัวข้อย่อยย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อย่อย
- คุณสมบัติย่อหน้า
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
description: "ควบคุมการจัดรูปแบบย่อหน้าอย่างเต็มที่ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java—ปรับการจัดแนว, ระยะห่างและสไตล์ในงานนำเสนอ PPT, PPTX และ ODP ด้วย JavaScript."
---
## **แนะนำ**

Aspose.Slides มีคลาสทั้งหมดที่คุณต้องการสำหรับทำงานกับข้อความ PowerPoint ย่อหน้า และส่วนต่าง ๆ ใน Java.

* Aspose.Slides มีคลาส [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) เพื่อให้คุณสามารถเพิ่มอ็อบเจ็กต์ที่เป็นตัวแทนของย่อหน้าได้. อ็อบเจ็กต์ `TextFame` สามารถมีหนึ่งหรือหลายย่อหน้า (แต่ละย่อหน้าถูกสร้างผ่านการขึ้นบรรทัดใหม่).
* Aspose.Slides มีคลาส [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) เพื่อให้คุณสามารถเพิ่มอ็อบเจ็กต์ที่เป็นตัวแทนของส่วนได้. อ็อบเจ็กต์ `Paragraph` สามารถมีหนึ่งหรือหลายส่วน (คอลเลกชันของอ็อบเจ็กต์ Portion).
* Aspose.Slides มีคลาส [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) เพื่อให้คุณสามารถเพิ่มอ็อบเจ็กต์ที่เป็นตัวแทนของข้อความและคุณสมบัติการจัดรูปแบบของมันได้.

อ็อบเจ็กต์ `Paragraph` สามารถจัดการข้อความที่มีคุณสมบัติการจัดรูปแบบต่าง ๆ ผ่านอ็อบเจ็กต์ `Portion` ที่เป็นพื้นฐานของมัน.

## **เพิ่มหลายย่อหน้าที่มีหลายส่วน**

ขั้นตอนเหล่านี้จะแสดงวิธีเพิ่ม TextFrame ที่มี 3 ย่อหน้าและแต่ละย่อหน้ามี 3 Portion:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/).
2. เข้าถึงอ้างอิงสไลด์ที่เกี่ยวข้องโดยใช้ดัชนีของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) แบบสี่เหลี่ยมผืนผ้าลงในสไลด์.
4. รับ ITextFrame ที่เชื่อมโยงกับ [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/).
5. สร้างอ็อบเจ็กต์ [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) สองตัวและเพิ่มลงในคอลเลกชัน `IParagraphs` ของ [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/).
6. สร้างอ็อบเจ็กต์ [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) สามตัวสำหรับแต่ละ `Paragraph` ใหม่ (สอง Portion สำหรับ Paragraph เริ่มต้น) และเพิ่มแต่ละอ็อบเจ็กต์ `Portion` ลงในคอลเลกชัน IPortion ของแต่ละ `Paragraph`.
7. กำหนดข้อความบางส่วนให้กับแต่ละ Portion.
8. ใช้คุณสมบัติการจัดรูปแบบที่คุณต้องการกับแต่ละ Portion โดยใช้คุณสมบัติการจัดรูปแบบของอ็อบเจ็กต์ `Portion`.
9. บันทึกการนำเสนอที่แก้ไขแล้ว.

This Javascript code is an implementation of the steps for adding paragraphs containing portions:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เขาถึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // เพิ่ม AutoShape ประเภท Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // เขาถึง TextFrame ของ AutoShape
    var tf = ashp.getTextFrame();
    // สร้าง Paragraphs และ Portions ด้วยรูปแบบข้อความที่แตกต่างกัน
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
    // บันทึก PPTX ไปยังดิสก์
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **จัดการหัวข้อย่อยของย่อหน้า**

รายการหัวข้อย่อยช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ. ย่อหน้าที่มีหัวข้อย่อยมักอ่านง่ายและเข้าใจได้ดีกว่า.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/).
2. เข้าถึงอ้างอิงสไลด์ที่เกี่ยวข้องโดยใช้ดัชนีของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์ที่เลือก.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของ AutoShape.
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`.
6. สร้างอินสแตนซ์ย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/).
7. ตั้งค่า `Type` ของลูกศรหัวข้อย่อยเป็น `Symbol` และตั้งค่าตัวอักษรหัวข้อย่อย.
8. ตั้งค่า `Text` ของย่อหน้า.
9. ตั้งค่า `Indent` ของย่อหน้าสำหรับหัวข้อย่อย.
10. ตั้งค่าสีสำหรับหัวข้อย่อย.
11. ตั้งค่าความสูงของหัวข้อย่อย.
12. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าของ `TextFrame`.
13. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนตั้งแต่ 7 ถึง 13.
14. บันทึกการนำเสนอ.

This Javascript code shows you how to add a paragraph bullet:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เขาถึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // เพิ่มและเข้าถึง Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // เขาถึง TextFrame ของ autoshape
    var txtFrm = aShp.getTextFrame();
    // ลบย่อหน้าเริ่มต้น
    txtFrm.getParagraphs().removeAt(0);
    // สร้างย่อหน้า
    var para = new aspose.slides.Paragraph();
    // ตั้งค่าสไตล์หัวข้อย่อยของย่อหน้าและสัญลักษณ์
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // ตั้งค่าข้อความย่อหน้า
    para.setText("Welcome to Aspose.Slides");
    // ตั้งค่าเยื้องของหัวข้อย่อย
    para.getParagraphFormat().setIndent(25);
    // ตั้งค่าสีของหัวข้อย่อย
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// ตั้งค่า IsBulletHardColor เป็น true เพื่อใช้สีหัวข้อย่อยของผู้ใช้
    // ตั้งค่าสูงของหัวข้อย่อย
    para.getParagraphFormat().getBullet().setHeight(100);
    // เพิ่มย่อหน้าไปยัง TextFrame
    txtFrm.getParagraphs().add(para);
    // สร้างย่อหน้าที่สอง
    var para2 = new aspose.slides.Paragraph();
    // ตั้งค่าประเภทและสไตล์หัวข้อย่อยของย่อหน้า
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // เพิ่มข้อความย่อหน้า
    para2.setText("This is numbered bullet");
    // ตั้งค่าเยื้องของหัวข้อย่อย
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// ตั้งค่า IsBulletHardColor เป็น true เพื่อใช้สีหัวข้อย่อยของผู้ใช้
    // ตั้งค่าสูงของหัวข้อย่อย
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

รายการหัวข้อย่อยช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ. ย่อหน้าที่ใช้รูปภาพเป็นหัวข้อย่อยอ่านง่ายและเข้าใจได้ดี.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/).
2. เข้าถึงอ้างอิงสไลด์ที่เกี่ยวข้องโดยใช้ดัชนีของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของ AutoShape.
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`.
6. สร้างอินสแตนซ์ย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/).
7. โหลดภาพใน [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/).
8. ตั้งค่า `Type` ของหัวข้อย่อยเป็น [Picture](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/) และกำหนดภาพ.
9. ตั้งค่า `Text` ของย่อหน้า.
10. ตั้งค่า `Indent` ของย่อหน้าสำหรับหัวข้อย่อย.
11. ตั้งค่าสีสำหรับหัวข้อย่อย.
12. ตั้งค่าความสูงของหัวข้อย่อย.
13. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าของ `TextFrame`.
14. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนตามขั้นตอนก่อนหน้า.
15. บันทึกการนำเสนอที่แก้ไขแล้ว.

This Javascript code shows you how to add and manage picture bullets:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
var presentation = new aspose.slides.Presentation();
try {
    // เขาถึงสไลด์แรก
    var slide = presentation.getSlides().get_Item(0);
    // สร้างอินสแตนซ์ของภาพสำหรับหัวข้อย่อย
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
    // เขาถึง TextFrame ของ autoshape
    var textFrame = autoShape.getTextFrame();
    // ลบย่อหน้าเริ่มต้น
    textFrame.getParagraphs().removeAt(0);
    // สร้างย่อหน้าใหม่
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // ตั้งค่าสไตล์หัวข้อย่อยของย่อหน้าและภาพ
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // ตั้งค่าสูงของหัวข้อย่อย
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

## **จัดการหัวข้อย่อยหลายระดับ**

รายการหัวข้อย่อยช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ. หัวข้อย่อยหลายระดับอ่านง่ายและเข้าใจได้ดี.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/).
2. เข้าถึงอ้างอิงสไลด์ที่เกี่ยวข้องโดยใช้ดัชนีของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ในสไลด์ใหม่.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของ AutoShape.
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`.
6. สร้างอินสแตนซ์ย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) และตั้งค่าความลึกเป็น 0.
7. สร้างอินสแตนซ์ย่อหน้าที่สองผ่านคลาส `Paragraph` และตั้งค่าความลึกเป็น 1.
8. สร้างอินสแตนซ์ย่อหน้าที่สามผ่านคลาส `Paragraph` และตั้งค่าความลึกเป็น 2.
9. สร้างอินสแตนซ์ย่อหน้าที่สี่ผ่านคลาส `Paragraph` และตั้งค่าความลึกเป็น 3.
10. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าของ `TextFrame`.
11. บันทึกการนำเสนอที่แก้ไขแล้ว.

This Javascript code shows you how to add and manage multilevel bullets:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เขาถึงสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // เพิ่มและเข้าถึง Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // เขาถึง TextFrame ของ Autoshape ที่สร้างขึ้น
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
    // ตั้งค่าระดับหัวข้อย่อย
    para1.getParagraphFormat().setDepth(0);
    // เพิ่มย่อหน้าที่สอง
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // ตั้งค่าระดับหัวข้อย่อย
    para2.getParagraphFormat().setDepth(1);
    // เพิ่มย่อหน้าที่สาม
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // ตั้งค่าระดับหัวข้อย่อย
    para3.getParagraphFormat().setDepth(2);
    // เพิ่มย่อหน้าที่สี่
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // ตั้งค่าระดับหัวข้อย่อย
    para4.getParagraphFormat().setDepth(3);
    // เพิ่มย่อหน้าไปยังคอลเลกชัน
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

คลาส [BulletFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/) มีคุณสมบัติ [NumberedBulletStartWith](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) และอื่น ๆ ที่ช่วยให้คุณจัดการย่อหน้าด้วยการตั้งค่าเลขลำดับหรือรูปแบบที่กำหนดเองได้.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/).
2. เข้าถึงสไลด์ที่มีย่อหน้า.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของ AutoShape.
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`.
6. สร้างอินสแตนซ์ย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) และตั้งค่า [NumberedBulletStartWith](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) เป็น 2.
7. สร้างอินสแตนซ์ย่อหน้าที่สองผ่านคลาส `Paragraph` และตั้งค่า `NumberedBulletStartWith` เป็น 3.
8. สร้างอินสแตนซ์ย่อหน้าที่สามผ่านคลาส `Paragraph` และตั้งค่า `NumberedBulletStartWith` เป็น 7.
9. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าของ `TextFrame`.
10. บันทึกการนำเสนอที่แก้ไขแล้ว.

This Javascript code shows you how to add and manage paragraphs with custom numbering or formatting:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // เขาถึง TextFrame ของ Autoshape ที่สร้างขึ้น
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

## **ตั้งค่าเยื้องบรรทัดแรกของย่อหน้า**

ใช้เมธอด [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า. เมธอดนี้จะเลื่อนบรรทัดแรกเท่านั้นจากขอบซ้ายของย่อหน้า. ค่าเป็นบวกจะเลื่อนบรรทัดแรกไปทางขวา, ส่วนบรรทัดที่เหลือคงที่ตามเนื้อหาย่อหน้า.

ใช้ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) เมื่อคุณต้องการย้ายทั้งย่อหน้า. ใช้ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก.

ตัวอย่างด้านล่างสร้างหลายย่อหน้าและใช้ค่าการเยื้องที่แตกต่างกันเพื่อแสดงผลของการเยื้องบรรทัดแรกต่อการจัดวางย่อหน้า.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/).
2. เข้าถึงสไลด์เป้าหมาย.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) สี่เหลี่ยมผืนผ้าลงในสไลด์.
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ว่างลงในรูปร่างและลบย่อหน้าเริ่มต้น.
5. สร้างหลายย่อหน้าและตั้งค่าคุณสมบัติ [Indent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) ที่แตกต่างกันสำหรับแต่ละย่อหน้า.
6. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame.
7. บันทึกการนำเสนอที่แก้ไขแล้ว.

This code shows you how to set a paragraph indent:

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

## **ตั้งค่าเยื้องห้อยสำหรับย่อหน้า**

เยื้องห้อยเป็นรูปแบบการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ. ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยเมธอด [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/). ตั้งค่าเยื้องเป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายจากเนื้อหาย่อหน้า.

ในทางปฏิบัติ, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า, และ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) กำหนดตำแหน่งบรรทัดแรกสัมพันธ์กับ MarginLeft นั้น. เพื่อสร้างเยื้องห้อย, ตั้งค่า `MarginLeft` เป็นค่าบวกและ `Indent` เป็นค่าลบ.

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, ตำแหน่งอ้างอิง, รายการอภิธานศัพท์, และย่อหน้าอื่น ๆ ที่ต้องการให้บรรทัดที่ห่อหุ้มตรงกับเนื้อหาย่อหน้าแทนที่จะตรงกับอักขระแรกของบรรทัดแรก.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/).
2. เข้าถึงสไลด์เป้าหมาย.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) สี่เหลี่ยมผืนผ้าลงในสไลด์.
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ว่างลงในรูปร่างและลบย่อหน้าเริ่มต้น.
5. สร้างย่อหน้าและตั้งค่า [MarginLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) เป็นค่าบวกสำหรับแต่ละย่อหน้า.
6. ตั้งค่า [Indent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) เป็นค่าลบเพื่อสร้างเอฟเฟกต์เยื้องห้อย.
7. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame.
8. บันทึกการนำเสนอที่แก้ไขแล้ว.

This code shows you how to set a hanging indent for a paragraph:

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

![เยื้องห้อยของย่อหน้า](hanging_indent.png)

## **จัดการคุณสมบัติการทำงานของย่อหน้าสุดท้ายสำหรับย่อหน้า**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/).
1. รับอ้างอิงของสไลด์ที่มีย่อหน้าผ่านตำแหน่งของมัน.
1. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) สี่เหลี่ยมผืนผ้าลงในสไลด์.
1. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ที่มีสองย่อหน้าในสี่เหลี่ยม.
1. ตั้งค่า `FontHeight` และประเภทฟอนต์สำหรับย่อหน้า.
1. ตั้งค่าคุณสมบัติ End สำหรับย่อหน้า.
1. เขียนการนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX.

This Javascript code shows you how to set the End properties for paragraphs in PowerPoint:

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

## **นำเข้า HTML Text ไปยังย่อหน้า**

Aspose.Slides มีการสนับสนุนการนำเข้า HTML Text ไปยังย่อหน้าอย่างเต็มรูปแบบ.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/).
2. เข้าถึงอ้างอิงสไลด์ที่เกี่ยวข้องโดยใช้ดัชนีของมัน.
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์.
4. เพิ่มและเข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของ AutoShape.
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`.
6. อ่านไฟล์ HTML ต้นฉบับใน TextReader.
7. สร้างอินสแตนซ์ย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/).
8. เพิ่มเนื้อหาไฟล์ HTML ที่อ่านจาก TextReader ลงใน [ParagraphCollection](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphcollection/) ของ TextFrame.
9. บันทึกการนำเสนอที่แก้ไขแล้ว.

This Javascript code is an implementation of the steps for importing HTML texts in paragraphs:

```javascript
// สร้างอินสแตนซ์การนำเสนอว่าง
var pres = new aspose.slides.Presentation();
try {
    // เขาถึงสไลด์แรกเริ่มต้นของการนำเสนอ
    var slide = pres.getSlides().get_Item(0);
    // เพิ่ม AutoShape เพื่อรองรับเนื้อหา HTML
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // เพิ่ม TextFrame ให้กับรูปทรง
    ashape.addTextFrame("");
    // ลบย่อหน้าทั้งหมดใน TextFrame ที่เพิ่ม
    ashape.getTextFrame().getParagraphs().clear();
    // โหลดไฟล์ HTML ด้วย StreamReader
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // เพิ่มข้อความจาก StreamReader ของ HTML ลงใน TextFrame
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

Aspose.Slides มีการสนับสนุนการส่งออกข้อความ (ที่อยู่ในย่อหน้า) เป็น HTML อย่างเต็มรูปแบบ.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) และโหลดการนำเสนอที่ต้องการ.
2. เข้าถึงอ้างอิงสไลด์ที่เกี่ยวข้องโดยใช้ดัชนีของมัน.
3. เข้าถึงรูปร่างที่มีข้อความที่จะส่งออกเป็น HTML.
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของรูปร่างนั้น.
5. สร้างอินสแตนซ์ของ `StreamWriter` และเพิ่มไฟล์ HTML ใหม่.
6. ระบุดัชนีเริ่มต้นให้กับ StreamWriter และส่งออกย่อหน้าที่ต้องการ.

This Javascript code shows you how to export PowerPoint paragraph texts to HTML:

```javascript
// โหลดไฟล์การนำเสนอ
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // เขาถึงสไลด์แรกเริ่มต้นของการนำเสนอ
    var slide = pres.getSlides().get_Item(0);
    // ดัชนีที่ต้องการ
    var index = 0;
    // เขาถึงรูปร่างที่เพิ่มไว้
    var ashape = slide.getShapes().get_Item(index);
    // สร้างไฟล์ HTML เอาท์พุต
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // ดึงย่อหน้าแรกเป็น HTML
    // เขียนข้อมูลย่อหน้าเป็น HTML โดยระบุดัชนีเริ่มต้นของย่อหน้าและจำนวนย่อหน้าที่จะคัดลอก
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

ในส่วนนี้ เราจะสำรวจตัวอย่างสองกรณีที่แสดงวิธีบันทึกย่อความข้อความที่เป็นตัวแทนโดยคลาส [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) เป็นภาพ. ตัวอย่างทั้งสองรวมถึงการดึงภาพของรูปร่างที่มีย่อหน้าด้วยเมธอด `getImage` จากคลาส [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/), การคำนวณขอบเขตของย่อหน้าในรูปร่าง, และการส่งออกเป็นภาพบิตแมพ. วิธีเหล่านี้ช่วยให้คุณดึงส่วนเฉพาะของข้อความจากงานนำเสนอ PowerPoint และบันทึกเป็นภาพแยกต่างหาก ซึ่งมีประโยชน์ในการใช้งานต่อในหลายสถานการณ์.

สมมติว่าเรามีไฟล์การนำเสนอชื่อ sample.pptx ที่มีสไลด์หนึ่งสไลด์ โดยรูปร่างแรกเป็นกล่องข้อความที่มีสามย่อหน้า.

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

**ตัวอย่างที่ 1**

ในตัวอย่างนี้ เราจะดึงย่อหน้าที่สองเป็นภาพ. เราต้องดึงภาพของรูปร่างจากสไลด์แรกของการนำเสนอแล้วคำนวณขอบเขตของย่อหน้าที่สองใน TextFrame ของรูปร่างนั้น. จากนั้นเราวาดย่อหน้านั้นลงบนบิตแมพใหม่และบันทึกในรูปแบบ PNG. วิธีนี้เหมาะสำหรับการบันทึกย่อหน้าเฉพาะเป็นภาพแยกโดยคงขนาดและการจัดรูปแบบของข้อความเดิม.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // บันทึกรูปร่างไว้ในหน่วยความจำเป็นบิทแมพ.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // สร้างบิทแมพของรูปร่างจากหน่วยความจำ.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // คำนวณขอบเขตของย่อหน้าที่สอง.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // คำนวณพิกัดและขนาดของภาพผลลัพธ์ (ขนาดขั้นต่ำ - 1x1 พิกเซล).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // ตัดบิทแมพของรูปร่างเพื่อให้ได้เฉพาะบิทแมพของย่อหน้า.
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

ในตัวอย่างนี้ เราขยายแนวคิดก่อนหน้าโดยเพิ่มปัจจัยการสเกลให้กับภาพย่อหน้า. เราดึงรูปร่างจากการนำเสนอและบันทึกเป็นภาพด้วยปัจจัยสเกล `2`. วิธีนี้ช่วยให้ได้ผลลัพธ์ความละเอียดสูงเมื่อส่งออกย่อหน้า. ขอบเขตของย่อหน้าถูกคำนวณโดยพิจารณาตามสเกล. การสเกลเป็นประโยชน์เมื่อต้องการภาพที่มีรายละเอียดมากขึ้น เช่น ใช้ในสื่อพิมพ์คุณภาพสูง.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // บันทึกรูปร่างไว้ในหน่วยความจำเป็นบิทแมพพร้อมการสเกล.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // สร้างบิทแมพของรูปร่างจากหน่วยความจำ.
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

    // คำนวณพิกัดและขนาดของภาพผลลัพธ์ (ขนาดขั้นต่ำ - 1x1 พิกเซล).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // ตัดบิทแมพของรูปร่างเพื่อให้ได้เฉพาะบิทแมพของย่อหน้า.
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

**ฉันสามารถปิดการตัดบรรทัดอัตโนมัติภายใน TextFrame ได้หรือไม่?**

ได้. ใช้การตั้งค่าการตัดบรรทัดของ TextFrame ([setWrapText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/setwraptext/)) เพื่อปิดการตัดบรรทัดเพื่อให้บรรทัดไม่ถูกตัดที่ขอบของกรอบ.

**ฉันจะรับขอบเขตบนสไลด์ของย่อหน้าที่ระบุได้อย่างแม่นยำอย่างไร?**

คุณสามารถดึงสี่เหลี่ยมขอบของย่อหน้า (หรือแม้แต่ของ Portion เดียว) เพื่อทราบตำแหน่งและขนาดที่แน่นอนบนสไลด์.

**การจัดแนวของย่อหน้า (ซ้าย/ขวา/กลาง/จัดเต็ม) ถูกควบคุมที่ไหน?**

[setAlignment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setalignment/) เป็นเมธอดสำหรับการตั้งค่าระดับย่อหน้าใน [ParagraphFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/); มันจะนำไปใช้กับทั้งย่อหน้าโดยไม่คำนึงถึงการจัดรูปแบบของ Portion แต่ละอัน.

**ฉันสามารถตั้งค่าภาษาเพื่อตรวจสอบการสะกดย่อยสำหรับส่วนของย่อหน้าเฉพาะ (เช่น คำเดียว) ได้หรือไม่?**

ได้. ภาษาถูกตั้งค่าที่ระดับ Portion ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)) ดังนั้นหลายภาษาอาจอยู่ร่วมกันภายในย่อหน้าเดียว.