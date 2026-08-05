---
title: จัดการย่อความข้อความ PowerPoint ใน Java
linktitle: จัดการย่อหน้า
type: docs
weight: 40
url: /th/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- เพิ่มข้อความ
- เพิ่มย่อหน้า
- จัดการข้อความ
- จัดการย่อหน้า
- จัดการหัวข้อ
- ย่อหน้าเยื้อง
- ย่อหน้าที่มีการเยื้องแขวน
- ย่อหน้าหัวข้อ
- รายการลำดับเลข
- รายการหัวข้อ
- คุณสมบัติเย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "ทำความเข้าใจรูปแบบย่อหน้าอย่างชำนาญด้วย Aspose.Slides สำหรับ Java—ปรับการจัดแนว, ระยะห่างและสไตล์ในงานนำเสนอ PPT, PPTX, และ ODP ด้วย Java."
---
## **บทนำ**

Aspose.Slides มีอินเทอร์เฟซและคลาสต่าง ๆ ที่คุณต้องการเพื่อทำงานกับข้อความ PowerPoint, ย่อหน้า, และส่วนต่าง ๆ ใน Java.

* Aspose.Slides มีอินเทอร์เฟซ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) เพื่อให้คุณเพิ่มอ็อบเจกต์ที่แทนย่อหน้าได้ อ็อบเจกต์ `ITextFame` สามารถมีหนึ่งหรือหลายย่อหน้า (แต่ละย่อหน้าถูกสร้างผ่านการขึ้นบรรทัดใหม่)
* Aspose.Slides มีอินเทอร์เฟซ [IParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/) เพื่อให้คุณเพิ่มอ็อบเจกต์ที่แทนส่วนต่าง ๆ ได้ อ็อบเจกต์ `IParagraph` สามารถมีหนึ่งหรือหลายส่วน (ชุดของอ็อบเจกต์ iPortions)
* Aspose.Slides มีอินเทอร์เฟซ [IPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/) เพื่อให้คุณเพิ่มอ็อบเจกต์ที่แทนข้อความและคุณสมบัติการจัดรูปแบบของมัน

อ็อบเจกต์ `IParagraph` สามารถจัดการข้อความที่มีคุณสมบัติการจัดรูปแบบต่างกันผ่านอ็อบเจกต์ `IPortion` ที่เป็นพื้นฐานของมัน

## **เพิ่มหลายย่อหน้าที่มีหลายส่วน**

ขั้นตอนต่อไปนี้แสดงวิธีเพิ่ม TextFrame ที่มี 3 ย่อหน้าและแต่ละย่อหน้ามี 3 ส่วน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการโดยอ้างอิงจากตำแหน่งของมัน
3. เพิ่มสี่เหลี่ยม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์
4. รับ ITextFrame ที่เชื่อมโยงกับ [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/)
5. สร้างอ็อบเจกต์ [IParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/) สองตัวและเพิ่มเข้าไปในคอลเลกชัน `IParagraphs` ของ [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/)
6. สร้างอ็อบเจกต์ [IPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/) สามตัวสำหรับแต่ละ `IParagraph` ใหม่ (สอง Portion สำหรับ Paragraph เริ่มต้น) แล้วเพิ่มแต่ละอ็อบเจกต์ `IPortion` ลงในคอลเลกชัน IPortion ของแต่ละ `IParagraph`
7. ตั้งข้อความสำหรับแต่ละ Portion
8. ใช้คุณสมบัติการจัดรูปแบบที่คุณต้องการบนแต่ละ Portion ผ่านคุณสมบัติของอ็อบเจกต์ `IPortion`
9. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Java นี้เป็นการนำขั้นตอนด้านบนไปใช้:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เขาถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภทสี่เหลี่ยม
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // เขาถึง TextFrame ของ AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // สร้างย่อหน้าและ Portion ที่มีรูปแบบข้อความต่างกัน
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

    // บันทึก PPTX ลงดิสก์
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **จัดการหัวข้อย่อยของย่อหน้า**

รายการหัวข้อช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าที่มีหัวข้อย่อยมักอ่านและเข้าใจได้ง่ายกว่า

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการโดยอ้างอิงจากตำแหน่งของมัน
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์ที่เลือก
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของ autoshape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างอ็อบเจกต์ย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/)
7. ตั้งค่า `Type` ของหัวข้อเป็น `Symbol` และกำหนดอักขระหัวข้อ
8. ตั้งค่า `Text` ของย่อหน้า
9. ตั้งค่า `Indent` ของหัวข้อสำหรับย่อหน้า
10. ตั้งค่าสีสำหรับหัวข้อ
11. ตั้งค่าสูงของหัวข้อ
12. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าใน `TextFrame`
13. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนตั้งแต่ 7 ถึง 13
14. บันทึกงานนำเสนอ

โค้ด Java นี้แสดงวิธีเพิ่มหัวข้อย่อยในย่อหน้า:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เขาถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);
    
    // เพิ่มและเข้าถึง Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // เขาถึง TextFrame ของ autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // ลบย่อหน้าเริ่มต้น
    txtFrm.getParagraphs().removeAt(0);

    // สร้างย่อหน้า
    Paragraph para = new Paragraph();

    // ตั้งสไตล์และสัญลักษณ์หัวข้อย่อยของย่อหน้า
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // ตั้งข้อความย่อหน้า
    para.setText("Welcome to Aspose.Slides");

    // ตั้งค่าการเยื้องของหัวข้อย่อย
    para.getParagraphFormat().setIndent(25);

    // ตั้งค่าสีของหัวข้อย่อย
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // ตั้งค่า IsBulletHardColor เป็น true เพื่อใช้สีหัวข้อย่อยของตนเอง

    // ตั้งความสูงของหัวข้อย่อย
    para.getParagraphFormat().getBullet().setHeight(100);

    // เพิ่มย่อหน้าไปยัง TextFrame
    txtFrm.getParagraphs().add(para);

    // สร้างย่อหน้าที่สอง
    Paragraph para2 = new Paragraph();

    // ตั้งประเภทและสไตล์ของหัวข้อย่อยย่อหน้า
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // เพิ่มข้อความย่อหน้า
    para2.setText("This is numbered bullet");

    // ตั้งค่าการเยื้องของหัวข้อย่อย
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // ตั้งค่า IsBulletHardColor เป็น true เพื่อใช้สีหัวข้อย่อยของตนเอง

    // ตั้งความสูงของหัวข้อย่อย
    para2.getParagraphFormat().getBullet().setHeight(100);

    // เพิ่มย่อหน้าไปยัง TextFrame
    txtFrm.getParagraphs().add(para2);
    
    // บันทึกงานนำเสนอที่แก้ไขแล้ว
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **จัดการหัวข้อย่อยแบบภาพ**

รายการหัวข้อช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าที่ใช้ภาพเป็นหัวข้อย่อยอ่านง่ายและเข้าใจง่าย

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการโดยอ้างอิงจากตำแหน่งของมัน
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของ autoshape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างอ็อบเจกต์ย่อหน้าแรกโดยใช้คลาส [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/)
7. โหลดภาพด้วย [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/)
8. ตั้งค่า `Type` ของหัวข้อเป็น [Picture](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/) แล้วกำหนดภาพ
9. ตั้งค่า `Text` ของ Paragraph
10. ตั้งค่า `Indent` ของหัวข้อสำหรับย่อหน้า
11. ตั้งค่าสีสำหรับหัวข้อ
12. ตั้งค่าสูงของหัวข้อ
13. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าใน `TextFrame`
14. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนตามข้อก่อนหน้า
15. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Java นี้แสดงวิธีเพิ่มและจัดการหัวข้อย่อยแบบภาพ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation presentation = new Presentation();
try {
    // เขาถึงสไลด์แรก
    ISlide slide = presentation.getSlides().get_Item(0);

    // สร้างอินสแตนซ์ของภาพสำหรับหัวข้อย่อย
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // เพิ่มและเข้าถึง Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // เขาถึง TextFrame ของ autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // ลบย่อหน้าเริ่มต้น
    textFrame.getParagraphs().removeAt(0);

    // สร้างย่อหน้าใหม่
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // ตั้งสไตล์หัวข้อย่อยของย่อหน้าและภาพ
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // ตั้งความสูงของหัวข้อย่อย
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // เพิ่มย่อหน้าไปยัง TextFrame
    textFrame.getParagraphs().add(paragraph);

    // เขียนงานนำเสนอเป็นไฟล์ PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // เขียนงานนำเสนอเป็นไฟล์ PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **จัดการหัวข้อย่อยหลายระดับ**

รายการหัวข้อช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ หัวข้อย่อยหลายระดับอ่านง่ายและเข้าใจได้ดี

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการโดยอ้างอิงจากตำแหน่งของมัน
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ในสไลด์ใหม่
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของ autoshape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างอ็อบเจกต์ย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/) แล้วตั้งค่าความลึกเป็น 0
7. สร้างอ็อบเจกต์ย่อหน้าอันดับสองผ่านคลาส `Paragraph` แล้วตั้งค่าความลึกเป็น 1
8. สร้างอ็อบเจกต์ย่อหน้าอันดับสามผ่านคลาส `Paragraph` แล้วตั้งค่าความลึกเป็น 2
9. สร้างอ็อบเจกต์ย่อหน้าอันดับสี่ผ่านคลาส `Paragraph` แล้วตั้งค่าความลึกเป็น 3
10. เพิ่มย่อหน้าใหม่ทั้งหมดลงในคอลเลกชันย่อหน้าใน `TextFrame`
11. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Java นี้แสดงวิธีเพิ่มและจัดการหัวข้อย่อยหลายระดับ:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เขาถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่มและเข้าถึง Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // เขาถึง TextFrame ของ Autoshape ที่สร้างขึ้น
    ITextFrame text = aShp.addTextFrame("");

    // ลบย่อหน้าเริ่มต้น
    text.getParagraphs().clear();

    // เพิ่มย่อหน้าแรก
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // ตั้งระดับหัวข้อย่อย
    para1.getParagraphFormat().setDepth((short)0);

    // เพิ่มย่อหน้าที่สอง
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // ตั้งระดับหัวข้อย่อย
    para2.getParagraphFormat().setDepth((short)1);

    // เพิ่มย่อหน้าที่สาม
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // ตั้งระดับหัวข้อย่อย
    para3.getParagraphFormat().setDepth((short)2);

    // เพิ่มย่อหน้าที่สี่
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // ตั้งระดับหัวข้อย่อย
    para4.getParagraphFormat().setDepth((short)3);

    // เพิ่มย่อหน้าไปยังคอลเลกชัน
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **จัดการย่อหน้าที่มีรายการลำดับเลขแบบกำหนดเอง**

อินเทอร์เฟซ [IBulletFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/) มีคุณสมบัติ [NumberedBulletStartWith](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) และอื่น ๆ ที่ช่วยให้คุณจัดการย่อหน้าที่มีการตั้งลำดับเลขหรือการจัดรูปแบบแบบกำหนดเอง

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่มีย่อหน้า
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของ autoshape
5. ลบย่อหน้าเริ่มต้นใน `TextFrame`
6. สร้างย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/) แล้วตั้งค่า [NumberedBulletStartWith](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เป็น 2
7. สร้างย่อหน้าที่สองผ่านคลาส `Paragraph` แล้วตั้งค่า `NumberedBulletStartWith` เป็น 3
8. สร้างย่อหน้าที่สามผ่านคลาส `Paragraph` แล้วตั้งค่า `NumberedBulletStartWith` เป็น 7
9. เพิ่มย่อหน้าใหม่ทั้งหมดลงในคอลเลกชันย่อหน้าใน `TextFrame`
10. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Java นี้แสดงวิธีเพิ่มและจัดการย่อหน้าที่มีการตั้งลำดับเลขแบบกำหนดเอง:

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // เขาถึง TextFrame ของ Autoshape ที่สร้างขึ้น
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

## **ตั้งค่า Indent บรรทัดแรกของย่อหน้า**

ใช้เมธอด [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า วิธีนี้จะย้ายเฉพาะบรรทัดแรกเทียบกับขอบซ้ายของย่อหน้า ค่าบวกจะย้ายบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงอยู่ตามแนวของเนื้อหา

เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ให้ใช้ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) ส่วนเมื่อต้องการย้ายเฉพาะบรรทัดแรก ให้ใช้ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-)

ตัวอย่างด้านล่างสร้างย่อหน้าหลาย ๆ ย่อหน้าและกำหนดค่า Indent ที่แตกต่างกันเพื่อแสดงว่าการเยื้องบรรทัดแรกมีผลต่อการจัดวางของย่อหน้าอย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/) สี่เหลี่ยมผืนผ้าลงในสไลด์
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/) ที่ว่างเปล่าในรูปร่างและลบย่อหน้าเริ่มต้น
5. สร้างย่อหน้าหลายย่อหน้าและกำหนดค่า [Indent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) ที่แตกต่างกันสำหรับแต่ละย่อหน้า
6. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่าเยื้องของย่อหน้า:

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

![การเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

## **ตั้งค่า Hanging Indent สำหรับย่อหน้า**

Hanging Indent คือการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ด้านซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟ็กต์นี้ด้วยเมธอด [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) โดยตั้งค่า Indent เป็นค่าติดลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อหาย่อหน้า

โดยปกติ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) จะกำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) จะกำหนดตำแหน่งของบรรทัดแรกเมื่อเทียบกับ MarginLeft การสร้าง Hanging Indent ให้ตั้งค่า `MarginLeft` เป็นค่าบวกและ `Indent` เป็นค่าลบ

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการสารานุกรม และย่อหน้าอื่น ๆ ที่ต้องการให้บรรทัดที่ต่อเนื่องอยู่ภายใต้เนื้อหาย่อหน้า ไม่ใช่ภายใต้อักขระแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/autoshape/) สี่เหลี่ยมผืนผ้าลงในสไลด์
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/) ที่ว่างเปล่าในรูปร่างและลบย่อหน้าเริ่มต้น
5. สร้างย่อหน้าและตั้งค่า `MarginLeft` เป็นค่าบวกสำหรับแต่ละย่อหน้า
6. ตั้งค่า `Indent` เป็นค่าลบเพื่อสร้างเอฟเฟ็กต์ Hanging Indent
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

![การเยื้อง Hanging ของย่อหน้า](hanging_indent.png)

## **จัดการคุณสมบัติ Run ของย่อหน้าสุดท้าย**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
1. รับอ้างอิงของสไลด์ที่มีย่อหน้าโดยอิงตำแหน่งของมัน
1. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) สี่เหลี่ยมผืนผ้าลงในสไลด์
1. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ที่มีสองย่อหน้าลงในสี่เหลี่ยม
1. ตั้งค่า `FontHeight` และประเภทฟอนต์สำหรับย่อหน้า
1. ตั้งค่าคุณสมบัติ End สำหรับย่อหน้า
1. เขียนไฟล์งานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

โค้ด Java นี้แสดงวิธีตั้งค่าคุณสมบัติ End สำหรับย่อหน้าใน PowerPoint:

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

Aspose.Slides รองรับการนำเข้า HTML Text ไปยังย่อหน้าอย่างเต็มรูปแบบ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการโดยอ้างอิงจากตำแหน่งของมัน
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ลงในสไลด์
4. เพิ่มและเข้าถึง `autoshape` [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/)
5. ลบย่อหน้าเริ่มต้นใน `ITextFrame`
6. อ่านไฟล์ HTML ต้นทางด้วย TextReader
7. สร้างย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/)
8. เพิ่มเนื้อหาไฟล์ HTML ที่อ่านจาก TextReader ลงใน [ParagraphCollection](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraphcollection/) ของ TextFrame
9. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด Java นี้เป็นการนำขั้นตอนการนำเข้า HTML Text ไปยังย่อหน้ามาใช้:

```java
// สร้างอินสแตนซ์ Presentation ที่ว่างเปล่า
Presentation pres = new Presentation();
try {
    // เขาถึงสไลด์แรกของงานนำเสนอโดยค่าเริ่มต้น
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape เพื่อรองรับเนื้อหา HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // เพิ่ม TextFrame ให้กับรูปทรง
    ashape.addTextFrame("");

    // ลบย่อหน้าทั้งหมดใน TextFrame ที่เพิ่มเข้ามา
    ashape.getTextFrame().getParagraphs().clear();

    // โหลดไฟล์ HTML ด้วย StreamReader
    TextReader tr = new StreamReader("file.html");

    // เพิ่มข้อความจาก StreamReader ของ HTML ลงใน TextFrame
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // บันทึกงานนำเสนอ
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **ส่งออกข้อความย่อหน้าเป็น HTML**

Aspose.Slides รองรับการส่งออกข้อความ (ที่อยู่ในย่อหน้า) ไปเป็น HTML อย่างเต็มรูปแบบ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และโหลดงานนำเสนอที่ต้องการ
2. เข้าถึงสไลด์ที่ต้องการโดยอ้างอิงจากตำแหน่งของมัน
3. เข้าถึงรูปร่างที่มีข้อความที่จะส่งออกเป็น HTML
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframe/) ของรูปร่างนั้น
5. สร้างอินสแตนซ์ของ `StreamWriter` และเพิ่มไฟล์ HTML ใหม่
6. ระบุดัชนีเริ่มต้นให้กับ StreamWriter แล้วส่งออกย่อหน้าที่ต้องการ

โค้ด Java นี้แสดงวิธีส่งออกข้อความย่อหน้า PowerPoint ไปเป็น HTML:

```java
// โหลดไฟล์งานนำเสนอ
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // เขาถึงสไลด์แรกของงานนำเสนอโดยค่าเริ่มต้น
    ISlide slide = pres.getSlides().get_Item(0);

    // ดัชนีที่ต้องการ
    int index = 0;

    // เขาถึงรูปทรงที่เพิ่มเข้ามา
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // สร้างไฟล์ HTML output
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //ดึงย่อหน้าที่แรกเป็น HTML
    // เขียนข้อมูลย่อหน้าเป็น HTML โดยระบุตำแหน่งเริ่มต้นของย่อหน้าและจำนวนย่อหน้าที่จะคัดลอก
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **บันทึกย่อหน้าเป็นภาพ**

ในส่วนนี้ เราจะสำรวจตัวอย่างสองกรณีที่แสดงวิธีบันทึกย่อความข้อความซึ่งแสดงโดยอินเทอร์เฟซ [IParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/) เป็นภาพ ตัวอย่างทั้งสองรวมถึงการดึงภาพของรูปร่างที่มีย่อหน้าด้วยเมธอด `getImage` ของอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/), การคำนวณขอบเขตของย่อหน้าในรูปร่าง, และการส่งออกเป็นภาพบิทแมป วิธีเหล่านี้ทำให้คุณสามารถแยกส่วนของข้อความจากพรีเซนเทชั่นและบันทึกเป็นภาพแยกต่างหาก ซึ่งอาจมีประโยชน์ในหลายสถานการณ์

สมมุติว่ามีไฟล์พรีเซนเทชั่นชื่อ **sample.pptx** มีหนึ่งสไลด์ โดยรูปร่างแรกเป็น TextBox ที่มีสามย่อหน้า

![TextBox ที่มีสามย่อหน้า](paragraph_to_image_input.png)

**ตัวอย่างที่ 1**

ในตัวอย่างนี้ เราจะดึงย่อหน้าที่สองเป็นภาพ โดยทำการดึงภาพของรูปร่างจากสไลด์แรกของพรีเซนเทชั่น แล้วคำนวณขอบเขตของย่อหน้าที่สองใน TextFrame ของรูปร่างนั้น จากนั้นวาดย่อหน้านั้นลงบนบิทแมปใหม่และบันทึกเป็นรูปแบบ PNG วิธีนี้เหมาะเมื่อต้องการบันทึกย่อหน้าเฉพาะเป็นภาพแยกโดยคงความละเอียดและการจัดรูปแบบเดิมไว้

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // บันทึกรูปทรงในหน่วยความจำเป็นบิตแมพ.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // สร้างบิตแมพของรูปทรงจากหน่วยความจำ.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // คำนวณขอบเขตของย่อหน้าที่สอง.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // คำนวณพิกัดและขนาดสำหรับภาพเอาต์พุต (ขนาดขั้นต่ำ - 1x1 พิกเซล).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // ตัดบิตแมพของรูปทรงเพื่อให้ได้บิตแมพของย่อหน้าเท่านั้น.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

ผลลัพธ์:

![ภาพย่อหน้า](paragraph_to_image_output.png)

**ตัวอย่างที่ 2**

ในตัวอย่างนี้ เราขยายวิธีการก่อนหน้าโดยเพิ่มปัจจัยการสเกลให้กับภาพย่อหน้า รูปร่างถูกดึงจากพรีเซนเทชั่นและบันทึกเป็นภาพพร้อมสเกลเป็น `2` ซึ่งทำให้ได้ความละเอียดสูงขึ้นเมื่อส่งออกย่อหน้า ขอบเขตของย่อหน้าถูกคำนวณโดยคำนึงถึงสเกล การสเกลนี้มีประโยชน์เมื่อต้องการภาพที่มีรายละเอียดมากขึ้น เช่น สำหรับใช้ในสื่อพิมพ์คุณภาพสูง

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // บันทึกรูปทรงในหน่วยความจำเป็นบิตแมพพร้อมการสเกล.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // สร้างบิตแมพของรูปทรงจากหน่วยความจำ.
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

    // คำนวณพิกัดและขนาดสำหรับภาพเอาต์พุต (ขนาดขั้นต่ำ - 1x1 พิกเซล).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // ตัดบิตแมพของรูปทรงเพื่อให้ได้บิตแมพของย่อหน้าเท่านั้น.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดใน TextFrame ได้ทั้งหมดหรือไม่?**

ได้เลย ใช้การตั้งค่าการตัดบรรทัดของ TextFrame ([setWrapText](https://reference.aspose.com/slides/th/java/com.aspose.slides/textframeformat/#setWrapText-byte-)) เพื่อปิดการตัดบรรทัด ทำให้บรรทัดไม่แตกที่ขอบของกรอบ

**ฉันจะได้รับขอบเขตบนสไลด์ของย่อหน้าใดย่อหน้าเฉพาะได้อย่างไร?**

คุณสามารถดึงสี่เหลี่ยมขอบของย่อหน้า (รวมถึงส่วนหนึ่งของ Portion) เพื่อทราบตำแหน่งและขนาดที่แม่นยำบนสไลด์

**การจัดแนวของย่อหน้า (ซ้าย/ขวา/ศูนย์/ชิดขอบ) ควบคุมอยู่ที่ไหน?**

[Alignment](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraphformat/#setAlignment-int-) เป็นการตั้งค่าระดับย่อหน้าภายใน [ParagraphFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraphformat/) ซึ่งใช้กับย่อหน้าทั้งหมดโดยไม่สนใจการจัดรูปแบบของ Portion แต่ละอัน

**ฉันสามารถตั้งค่าภาษาตรวจสอบการสะกดให้กับส่วนของย่อหน้า (เช่น คำเดียว) ได้หรือไม่?**

ได้ ภาษาเป็นการตั้งค่าที่ระดับ Portion ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/th/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)) ดังนั้นย่อหน้าหนึ่งสามารถมีหลายภาษาอยู่พร้อมกันได้.