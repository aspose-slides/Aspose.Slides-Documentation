---
title: จัดการย่อหน้าข้อความ PowerPoint ด้วย Java
linktitle: จัดการย่อหน้า
type: docs
weight: 40
url: /th/java/manage-paragraph/
keywords:
- เพิ่มข้อความ
- เพิ่มย่อหน้า
- จัดการข้อความ
- จัดการย่อหน้า
- จัดการจุดหัวข้อ
- เยื้องย่อหน้า
- เยื้องห้อย
- ย่อหน้าจุดหัวข้อ
- รายการลำดับเลข
- รายการหัวข้อสัญลักษณ์
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
- Java
- Aspose.Slides
description: "ควบคุมการจัดรูปแบบย่อหน้าอย่างเต็มที่ด้วย Aspose.Slides สำหรับ Java—เพิ่มประสิทธิภาพการจัดตำแหน่ง, ระยะห่างและสไตล์ในงานนำเสนอ PPT, PPTX และ ODP ด้วย Java."
---
## **บทนำ**

Aspose.Slides มีส่วนต่อประสานและคลาสทั้งหมดที่คุณต้องการเพื่อทำงานกับข้อความ PowerPoint ย่อหน้า และส่วนต่าง ๆ ใน Java.

* Aspose.Slides มีอินเตอร์เฟซ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) เพื่อให้คุณเพิ่มวัตถุที่แทนย่อหน้า วัตถุ `ITextFame` สามารถมีหนึ่งหรือหลายย่อหน้า (แต่ละย่อหน้าจะสร้างผ่านการขึ้นบรรทัดใหม่)
* Aspose.Slides มีอินเตอร์เฟซ [IParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/) เพื่อให้คุณเพิ่มวัตถุที่แทนส่วนต่าง ๆ วัตถุ `IParagraph` สามารถมีหนึ่งหรือหลายส่วน (คอลเลกชันของวัตถุ iPortions)
* Aspose.Slides มีอินเตอร์เฟซ [IPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/) เพื่อให้คุณเพิ่มวัตถุที่แทนข้อความและคุณสมบัติการฟอร์แมตของมัน

วัตถุ `IParagraph` สามารถจัดการกับข้อความที่มีคุณสมบัติการฟอร์แมตต่าง ๆ ผ่านวัตถุ `IPortion` ภายใน

## **เพิ่มหลายย่อหน้าที่มีหลายส่วน**

ขั้นตอนต่อไปนี้จะแสดงวิธีเพิ่มกรอบข้อความที่มี 3 ย่อหน้าและแต่ละย่อหน้ามี 3 ส่วน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เพิ่มสี่เหลี่ยม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์
4. รับ ITextFrame ที่เชื่อมโยงกับ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/)
5. สร้างวัตถุ [IParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/) สองอันและเพิ่มลงในคอลเลกชัน `IParagraphs` ของ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/)
6. สร้างวัตถุ [IPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/) สามอันสำหรับแต่ละ `IParagraph` ใหม่ (สองวัตถุ Portion สำหรับ Paragraph เริ่มต้น) และเพิ่มวัตถุ `IPortion` แต่ละอันลงในคอลเลกชัน IPortion ของแต่ละ `IParagraph`
7. ตั้งค่าข้อความสำหรับแต่ละ Portion
8. ใช้คุณสมบัติการฟอร์แมตที่คุณต้องการกับแต่ละ Portion ผ่านคุณสมบัติการฟอร์แมตของวัตถุ `IPortion`
9. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Java นี้เป็นการนำขั้นตอนข้างต้นไปใช้:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภทสี่เหลี่ยม
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // เข้าถึง TextFrame ของ AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // สร้าง Paragraphs และ Portions พร้อมรูปแบบข้อความที่แตกต่างกัน
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    // เขียนไฟล์ PPTX ไปยังดิสก์
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **จัดการ Bullet ของย่อหน้า**

รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าที่มี Bullet มักอ่านและเข้าใจง่ายกว่า

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์ที่เลือก
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของ autoshape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างอินสแตนซ์ย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/)
7. ตั้งค่า `Type` ของ Bullet เป็น `Symbol` และกำหนดอักขระ Bullet
8. ตั้งค่า `Text` ของย่อหน้า
9. ตั้งค่า `Indent` ของ Bullet สำหรับย่อหน้า
10. กำหนดสีให้กับ Bullet
11. กำหนดความสูงของ Bullet
12. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าของ `TextFrame`
13. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนที่ 7 ถึง 13
14. บันทึกงานนำเสนอ

โค้ด Java นี้แสดงวิธีเพิ่ม Bullet ให้ย่อหน้า:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // เพิ่มและเข้าถึง Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // เข้าถึง TextFrame ของ autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // ลบย่อหน้าเริ่มต้น
    txtFrm.getParagraphs().removeAt(0);

    // สร้างย่อหน้า
    Paragraph para = new Paragraph();

    // ตั้งค่ารูปแบบและสัญลักษณ์ของ Bullet ย่อหน้า
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // ตั้งค่าข้อความย่อหน้า
    para.setText("Welcome to Aspose.Slides");

    // ตั้งค่าการเยื้องของ Bullet
    para.getParagraphFormat().setIndent(25);

    // ตั้งค่าสีของ Bullet
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // ตั้งค่า IsBulletHardColor เป็น true เพื่อใช้สี Bullet ของผู้ใช้

    // ตั้งค่าความสูงของ Bullet
    para.getParagraphFormat().getBullet().setHeight(100);

    // เพิ่มย่อหน้าลงใน TextFrame
    txtFrm.getParagraphs().add(para);

    // สร้างย่อหน้าที่สอง
    Paragraph para2 = new Paragraph();

    // ตั้งค่าชนิดและสไตล์ของ Bullet ย่อหน้า
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // เพิ่มข้อความย่อหน้า
    para2.setText("This is numbered bullet");

    // ตั้งค่าการเยื้องของ Bullet
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // ตั้งค่า IsBulletHardColor เป็น true เพื่อใช้สี Bullet ของผู้ใช้

    // ตั้งค่าความสูงของ Bullet
    para2.getParagraphFormat().getBullet().setHeight(100);

    // เพิ่มย่อหน้าลงใน TextFrame
    txtFrm.getParagraphs().add(para2);
    
    // บันทึกงานนำเสนอที่แก้ไขแล้ว
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **จัดการ Picture Bullets**

รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าที่มีรูปภาพเป็น Bullet อ่านและเข้าใจง่าย

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของ autoshape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างอินสแตนซ์ย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/)
7. โหลดภาพใน [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/)
8. ตั้งค่า Bullet type เป็น [Picture](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) และกำหนดภาพ
9. ตั้งค่า `Text` ของ Paragraph
10. ตั้งค่า `Indent` ของ Bullet สำหรับ Paragraph
11. กำหนดสีให้กับ Bullet
12. กำหนดความสูงของ Bullet
13. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าของ `TextFrame`
14. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนตามที่กล่าวไว้ก่อนหน้า
15. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Java นี้แสดงวิธีเพิ่มและจัดการ Picture Bullets:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
Presentation presentation = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = presentation.getSlides().get_Item(0);

    // สร้างอินสแตนซ์ของภาพสำหรับ Bullet
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // เพิ่มและเข้าถึง Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // เข้าถึง TextFrame ของ autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // ลบย่อหน้าเริ่มต้น
    textFrame.getParagraphs().removeAt(0);

    // สร้างย่อหน้าใหม่
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // ตั้งค่าสไตล์ Bullet ของย่อหน้าและภาพ
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // ตั้งค่าความสูงของ Bullet
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // เพิ่มย่อหน้าลงใน TextFrame
    textFrame.getParagraphs().add(paragraph);

    // เขียนพรีเซนเทชั่นเป็นไฟล์ PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // เขียนพรีเซนเทชั่นเป็นไฟล์ PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **จัดการ Multilevel Bullets**

รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ Multilevel Bullets อ่านและเข้าใจง่าย

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ในสไลด์ใหม่
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของ autoshape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างอินสแตนซ์ย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/) และกำหนดระดับความลึกเป็น 0
7. สร้างอินสแตนซ์ย่อหน้าที่สองผ่านคลาส `Paragraph` และกำหนดระดับความลึกเป็น 1
8. สร้างอินสแตนซ์ย่อหน้าที่สามผ่านคลาส `Paragraph` และกำหนดระดับความลึกเป็น 2
9. สร้างอินสแตนซ์ย่อหน้าที่สี่ผ่านคลาส `Paragraph` และกำหนดระดับความลึกเป็น 3
10. เพิ่มย่อหน้าใหม่ทั้งหมดลงในคอลเลกชันย่อหน้าของ `TextFrame`
11. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Java นี้แสดงวิธีเพิ่มและจัดการ Multilevel Bullets:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่มและเข้าถึง Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // เข้าถึง TextFrame ของ Autoshape ที่สร้างขึ้น
    ITextFrame text = aShp.addTextFrame("");

    // เคลียร์ย่อหน้าเริ่มต้น
    text.getParagraphs().clear();

    // เพิ่มย่อหน้าแรก
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // ตั้งค่าระดับของ Bullet
    para1.getParagraphFormat().setDepth((short)0);

    // เพิ่มย่อหน้าที่สอง
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // ตั้งค่าระดับของ Bullet
    para2.getParagraphFormat().setDepth((short)1);

    // เพิ่มย่อหน้าที่สาม
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // ตั้งค่าระดับของ Bullet
    para3.getParagraphFormat().setDepth((short)2);

    // เพิ่มย่อหน้าที่สี่
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // ตั้งค่าระดับของ Bullet
    para4.getParagraphFormat().setDepth((short)3);

    // เพิ่มย่อหน้าลงในคอลเลกชัน
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // บันทึกพรีเซนเทชั่นเป็นไฟล์ PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **จัดการย่อหน้าที่มีรายการจัดลำดับเลขแบบกำหนดเอง**

อินเทอร์เฟซ [IBulletFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/) มีคุณสมบัติ [NumberedBulletStartWith](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) และอื่น ๆ ที่ช่วยให้คุณจัดการย่อหน้าที่มีการจัดลำดับเลขหรือฟอร์แมตแบบกำหนดเอง

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่มีย่อหน้า
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของ autoshape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างอินสแตนซ์ย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/) และตั้งค่า [NumberedBulletStartWith](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เป็น 2
7. สร้างอินสแตนซ์ย่อหน้าที่สองผ่านคลาส `Paragraph` และตั้งค่า `NumberedBulletStartWith` เป็น 3
8. สร้างอินสแตนซ์ย่อหน้าที่สามผ่านคลาส `Paragraph` และตั้งค่า `NumberedBulletStartWith` เป็น 7
9. เพิ่มย่อหน้าใหม่ทั้งหมดลงในคอลเลกชันย่อหน้าของ `TextFrame`
10. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Java นี้แสดงวิธีจัดการย่อหน้าที่มีการจัดลำดับเลขแบบกำหนดเอง:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // เข้าถึง TextFrame ของ Autoshape ที่สร้างขึ้น
    ITextFrame textFrame = shape.getTextFrame();

    // ลบย่อหน้าเริ่มต้นที่มีอยู่
    textFrame.getParagraphs().removeAt(0);

    // รายการแรก
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **ตั้งค่า Indent บรรทัดแรกสำหรับย่อหน้า**

ใช้เมธอด [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า เมธอดนี้จะเลื่อนบรรทัดแรกเท่านั้นเมื่อเทียบกับระยะขอบซ้ายของย่อหน้า ค่าเป็นบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือยังคงจัดชิดกับตัวเนื้อหาของย่อหน้า

ใช้ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ใช้ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) เมื่อต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างด้านล่างสร้างหลายย่อหน้าและกำหนดค่าการเยื้องที่แตกต่างกันเพื่อแสดงผลของการเยื้องบรรทัดแรกต่อการจัดวางย่อหน้า

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/) สี่เหลี่ยมลงในสไลด์
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/) ว่างเปล่าลงในรูปร่างและลบย่อหน้าเริ่มต้น
5. สร้างหลายย่อหน้าและกำหนดค่า [Indent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) ที่แตกต่างกันสำหรับแต่ละย่อหน้า
6. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่าเยื้องย่อหน้า:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ระยะย่อหน้าบรรทัดแรกของย่อหน้า](first_line_indent.png)

## **ตั้งค่า Hanging Indent สำหรับย่อหน้า**

Hanging Indent คือรูปแบบการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ด้านซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยเมธอด [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) ให้ค่าการเยื้องเป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อหาของย่อหน้า

โดยปกติ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) กำหนดตำแหน่งของบรรทัดแรกเมื่อเทียบกับขอบซ้ายนั้น เพื่อสร้าง Hanging Indent ให้ตั้งค่า `MarginLeft` เป็นบวกและ `Indent` เป็นลบ

การจัดฟอร์แมตนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, คำอธิบายในอภิธานศัพท์, และย่อหน้าอื่น ๆ ที่บรรทัดหักต้องจัดชิดกับเนื้อหาของย่อหน้า ไม่ใช่กับอักขระแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/) สี่เหลี่ยมลงในสไลด์
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/) ว่างเปล่าลงในรูปร่างและลบย่อหน้าเริ่มต้น
5. สร้างย่อหน้าและตั้งค่า [MarginLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) บวกสำหรับแต่ละย่อหน้า
6. ตั้งค่า [Indent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) เป็นลบเพื่อสร้างเอฟเฟกต์ Hanging Indent
7. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame
8. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่า Hanging Indent สำหรับย่อหน้า:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ระยะย่อหน้าติดแขวนของย่อหน้า](hanging_indent.png)

## **จัดการ End Paragraph Run Properties**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
1. รับอ้างอิงของสไลด์ที่มีย่อหน้าผ่านตำแหน่งของมัน
1. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) สี่เหลี่ยมลงในสไลด์
1. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ที่มีสองย่อหน้าในสี่เหลี่ยม
1. ตั้งค่า `FontHeight` และประเภทฟอนต์สำหรับย่อหน้า
1. ตั้งค่า End properties สำหรับย่อหน้า
1. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีตั้งค่า End properties สำหรับย่อหน้าใน PowerPoint:

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **นำเข้า HTML Text ไปยังย่อหน้า**

Aspose.Slides ให้การสนับสนุนขั้นสูงสำหรับการนำเข้า HTML Text ไปยังย่อหน้า

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์
4. เพิ่มและเข้าถึง `autoshape` [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/)
5. ลบย่อหน้าเริ่มต้นใน `ITextFrame`
6. อ่านไฟล์ HTML ต้นฉบับด้วย TextReader
7. สร้างอินสแตนซ์ย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/)
8. เพิ่มเนื้อหาไฟล์ HTML ที่อ่านจาก TextReader ลงใน [ParagraphCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraphcollection/) ของ TextFrame
9. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Java นี้เป็นการนำขั้นตอนการนำเข้า HTML Text ไปยังย่อหน้ามาใช้:

```java
// สร้างอินสแตนซ์ Presentation ว่าง
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรกเริ่มต้นของพรีเซนเทชั่น
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape เพื่อรองรับเนื้อหา HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // เพิ่ม TextFrame ให้กับรูปร่าง
    ashape.addTextFrame("");

    // ล้างย่อหน้าทั้งหมดใน TextFrame ที่เพิ่มไว้
    ashape.getTextFrame().getParagraphs().clear();

    // โหลดไฟล์ HTML ด้วย StreamReader
    TextReader tr = new StreamReader("file.html");

    // เพิ่มข้อความจาก StreamReader ของ HTML ลงใน TextFrame
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // บันทึกพรีเซนเทชั่น
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ส่งออกข้อความย่อหน้าเป็น HTML**

Aspose.Slides ให้การสนับสนุนขั้นสูงสำหรับการส่งออกข้อความ (ที่อยู่ในย่อหน้า) เป็น HTML

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และโหลดงานนำเสนอที่ต้องการ
2. เข้าถึงสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เข้าถึงรูปร่างที่มีข้อความที่จะส่งออกเป็น HTML
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/) ของรูปร่าง
5. สร้างอินสแตนซ์ของ `StreamWriter` และเพิ่มไฟล์ HTML ใหม่
6. ระบุดัชนีเริ่มต้นให้กับ StreamWriter และส่งออกย่อหน้าที่ต้องการ

โค้ด Java นี้แสดงวิธีส่งออกข้อความย่อหน้า PowerPoint ไปเป็น HTML:

```java
// โหลดไฟล์พรีเซนเทชั่น
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // เข้าถึงสไลด์แรกเริ่มต้นของพรีเซนเทชั่น
    ISlide slide = pres.getSlides().get_Item(0);

    // ดัชนีที่ต้องการ
    int index = 0;

    // เข้าถึงรูปร่างที่เพิ่มไว้
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // สร้างไฟล์ HTML เอาต์พุต
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Extracting first paragraph as HTML
    // เขียนข้อมูลย่อหน้าเป็น HTML โดยระบุดัชนีเริ่มต้นของย่อหน้าและจำนวนย่อหน้าที่จะคัดลอก
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **บันทึกย่อหน้าเป็นภาพ**

ในส่วนนี้ เราจะอธิบายสองตัวอย่างที่แสดงวิธีบันทึกย่อข้อความที่แสดงโดยอินเทอร์เฟซ [IParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/) เป็นภาพ ทั้งสองตัวอย่างรวมถึงการดึงภาพของรูปร่างที่มีย่อหน้าโดยใช้เมธอด `getImage` จากอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/) คำนวณขอบเขตของย่อหน้าในรูปร่าง และส่งออกเป็นภาพบิทแมพ วิธีเหล่านี้ช่วยให้คุณสามารถสกัดส่วนของข้อความจากพรีเซนเทชั่นและบันทึกเป็นภาพแยกต่างหาก ซึ่งอาจมีประโยชน์ในหลายสถานการณ์

สมมติว่าเรามีไฟล์พรีเซนเทชั่นชื่อ sample.pptx ที่มีหนึ่งสไลด์ โดยรูปร่างแรกเป็นกล่องข้อความที่มีสามย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

**ตัวอย่าง 1**

ในตัวอย่างนี้ เราจะดึงย่อหน้าที่สองเป็นภาพ โดยการดึงภาพของรูปร่างจากสไลด์แรกของพรีเซนเทชั่น แล้วคำนวณขอบเขตของย่อหน้าที่สองใน TextFrame ของรูปร่าง จากนั้นวาดย่อหน้าใหม่บนบิทแมพและบันทึกเป็นรูปแบบ PNG วิธีนี้เหมาะสำหรับการบันทึกย่อหน้าเฉพาะเป็นภาพแยกโดยคงความละเอียดและฟอร์แมตเดิมของข้อความ

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // บันทึกรูปร่างในหน่วยความจำเป็นบิตแมพ.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // สร้างบิตแมพของรูปร่างจากหน่วยความจำ.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // คำนวณขอบเขตของย่อหน้าที่สอง.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // คำนวณพิกัดและขนาดของภาพเอาต์พุต (ขนาดขั้นต่ำ - 1x1 พิกเซล).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // ตัดบิตแมพของรูปร่างเพื่อให้ได้บิตแมพของย่อหน้าเท่านั้น.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

ผลลัพธ์:

![ภาพย่อหน้า](paragraph_to_image_output.png)

**ตัวอย่าง 2**

ในตัวอย่างนี้ เราขยายวิธีก่อนหน้าโดยเพิ่มปัจจัยสเกลให้กับภาพย่อหน้า รูปร่างถูกดึงออกจากพรีเซนเทชั่นและบันทึกเป็นภาพด้วยสเกล `2` ซึ่งให้ผลลัพธ์ความละเอียดสูงกว่าเมื่อส่งออกย่อหน้า ขอบเขตของย่อหน้าถูกคำนวณโดยคำนึงถึงสเกล การสเกลเป็นประโยชน์เมื่อต้องการภาพที่ละเอียดมากขึ้น เช่น ใช้ในวัสดุพิมพ์คุณภาพสูง

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // บันทึกรูปร่างในหน่วยความจำเป็นบิตแมพพร้อมการสเกล.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // สร้างบิตแมพของรูปร่างจากหน่วยความจำ.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // คำนวณขอบเขตของย่อหน้าที่สอง.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // คำนวณพิกัดและขนาดของภาพเอาต์พุต (ขนาดขั้นต่ำ - 1x1 พิกเซล).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // ตัดบิตแมพของรูปร่างเพื่อให้ได้บิตแมพของย่อหน้าเท่านั้น.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**ฉันสามารถปิดการตัดบรรทัดภายใน Text Frame ได้ทั้งหมดหรือไม่?**

ได้ ใช้การตั้งค่าการตัดบรรทัดของ Text Frame ([setWrapText](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframeformat/#setWrapText-byte-)) เพื่อปิดการตัดบรรทัด ทำให้บรรทัดไม่หักที่ขอบของกรอบ

**ฉันจะรับขอบเขตบนสไลด์ของย่อหน้าใดย่อหน้าหนึ่งได้อย่างแม่นยำอย่างไร?**

คุณสามารถดึงสี่เหลี่ยมขอบของย่อหน้า (หรือแม้แต่ของ Portion หนึ่ง) เพื่อทราบตำแหน่งและขนาดที่แม่นยำบนสไลด์

**การจัดแนวของย่อหน้า (ซ้าย/ขวา/ศูนย์/เต็ม) ถูกควบคุมที่ไหน?**

[Alignment](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraphformat/#setAlignment-int-) เป็นการตั้งค่าที่ระดับย่อหน้าใน [ParagraphFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraphformat/) ซึ่งจะส่งผลต่อย่อหน้าทั้งหมดโดยไม่คำนึงถึงฟอร์แมตของ Portion แยกแต่ละส่วน

**ฉันสามารถตั้งค่าภาษาเช็กสำหรับส่วนของย่อหน้าเดียว (เช่น คำเดียว) ได้หรือไม่?**

ได้ ภาษาถูกตั้งค่าที่ระดับ Portion ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)) ทำให้สามารถใช้หลายภาษาในย่อหน้าเดียวได้