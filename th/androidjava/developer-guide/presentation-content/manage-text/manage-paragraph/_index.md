---
title: จัดการย่อหน้าข้อความ PowerPoint บน Android
linktitle: จัดการย่อหน้า
type: docs
weight: 40
url: /th/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
keywords:
- เพิ่มข้อความ
- เพิ่มย่อหน้า
- จัดการข้อความ
- จัดการย่อหน้า
- จัดการหัวข้อจุด
- การเยื้องย่อหน้า
- การเยื้องห้อย
- หัวข้อจุดย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อจุด
- คุณสมบัติย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "ควบคุมการจัดรูปแบบย่อหน้าด้วย Aspose.Slides สำหรับ Android—เพิ่มประสิทธิภาพการจัดแนว, ระยะห่างและสไตล์ในงานนำเสนอ PPT, PPTX และ ODP ด้วย Java."
---
## **บทนำ**

Aspose.Slides มีส่วนติดต่อและคลาสทั้งหมดที่คุณต้องการใช้ในการทำงานกับข้อความ PowerPoint, ย่อหน้า และส่วนย่อยใน Java

* Aspose.Slides มีส่วนติดต่อ [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) เพื่อให้คุณสามารถเพิ่มอ็อบเจกต์ที่แทนย่อหน้าได้ อ็อบเจกต์ `ITextFame` สามารถมีหนึ่งหรือหลายย่อหน้า (แต่ละย่อหน้าถูกสร้างด้วยการขึ้นบรรทัดใหม่)
* Aspose.Slides มีส่วนติดต่อ [IParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/) เพื่อให้คุณสามารถเพิ่มอ็อบเจกต์ที่แทนส่วนย่อยได้ อ็อบเจกต์ `IParagraph` สามารถมีหนึ่งหรือหลายส่วนย่อย (คอลเลกชันของอ็อบเจกต์ iPortions)
* Aspose.Slides มีส่วนติดต่อ [IPortion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/) เพื่อให้คุณสามารถเพิ่มอ็อบเจกต์ที่แทนข้อความและคุณสมบัติการจัดรูปแบบของมันได้

อ็อบเจกต์ `IParagraph` สามารถจัดการกับข้อความที่มีคุณสมบัติการจัดรูปแบบต่าง ๆ ผ่านอ็อบเจกต์ `IPortion` ที่อยู่ภายใน

## **เพิ่มหลายย่อหน้าที่มีหลายส่วนข้อความ**

ขั้นตอนต่อไปนี้แสดงวิธีเพิ่ม TextFrame ที่มี 3 ย่อหน้าและแต่ละย่อหน้ามี 3 ส่วนย่อย:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
2. เข้าถึงสไลด์ที่ต้องการโดยอ้างอิงจากดัชนีของมัน  
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) รูปสี่เหลี่ยมลงในสไลด์  
4. รับ ITextFrame ที่เชื่อมโยงกับ [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/)  
5. สร้างอ็อบเจกต์ [IParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/) สองตัวและเพิ่มลงในคอลเลกชัน `IParagraphs` ของ [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/)  
6. สำหรับแต่ละ `IParagraph` ใหม่สร้างอ็อบเจกต์ [IPortion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/) สามตัว (สอง Portion สำหรับ Paragraph ปริยาย) แล้วเพิ่มแต่ละ `IPortion` ลงในคอลเลกชัน IPortion ของ `IParagraph` นั้น  
7. กำหนดข้อความให้แต่ละ Portion  
8. ใช้คุณสมบัติจัดรูปแบบที่ต้องการกับแต่ละ Portion ผ่านคุณสมบัติของอ็อบเจกต์ `IPortion`  
9. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด Java ตัวอย่างต่อไปนี้เป็นการทำตามขั้นตอนข้างต้นสำหรับการเพิ่มย่อหน้าที่มีส่วนย่อย:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape ประเภทสี่เหลี่ยม
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // เข้าถึง TextFrame ของ AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // สร้างย่อหน้าและ Portion ด้วยรูปแบบข้อความที่แตกต่างกัน
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

## **จัดการ Bullet ของย่อหน้า**

รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าที่มี Bullet จะอ่านและเข้าใจได้ง่ายกว่ามาก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
2. เข้าถึงสไลด์ที่ต้องการโดยอ้างอิงจากดัชนีของมัน  
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์ที่เลือก  
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) ของ autoshape  
5. ลบย่อปัจจุบันใน `TextFrame`  
6. สร้างอินสแตนซ์ย่อหน้าตัวแรกด้วยคลาส [Paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraph/)  
7. ตั้งค่า `Type` ของ Bullet ให้เป็น `Symbol` และกำหนดอักขระ Bullet  
8. ตั้งค่า `Text` ของย่อหน้า  
9. ตั้งค่า `Indent` ของ Bullet สำหรับย่อหน้า  
10. กำหนดสีสำหรับ Bullet  
11. กำหนดความสูงของ Bullet  
12. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าของ `TextFrame`  
13. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนตั้งแต่ 7 ถึง 13  
14. บันทึกงานนำเสนอ  

โค้ด Java ตัวอย่างนี้แสดงวิธีเพิ่ม Bullet ให้ย่อหน้า:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
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

    // ตั้งค่ารูปแบบหัวข้อจุดของย่อหน้าและสัญลักษณ์
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // ตั้งค่าข้อความของย่อหน้า
    para.setText("Welcome to Aspose.Slides");

    // ตั้งค่าการเยื้องของหัวข้อจุด
    para.getParagraphFormat().setIndent(25);

    // ตั้งค่าสีของหัวข้อจุด
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // ตั้งค่า IsBulletHardColor เป็น true เพื่อใช้สีหัวข้อจุดของคุณเอง

    // ตั้งค่าความสูงของหัวข้อจุด
    para.getParagraphFormat().getBullet().setHeight(100);

    // เพิ่มย่อหน้าเข้าไปใน TextFrame
    txtFrm.getParagraphs().add(para);

    // สร้างย่อหน้าที่สอง
    Paragraph para2 = new Paragraph();

    // ตั้งค่าชนิดและสไตล์ของหัวข้อจุดย่อหน้า
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // เพิ่มข้อความย่อหน้า
    para2.setText("This is numbered bullet");

    // ตั้งค่าการเยื้องของหัวข้อจุด
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // ตั้งค่า IsBulletHardColor เป็น true เพื่อใช้สีหัวข้อจุดของคุณเอง

    // ตั้งค่าความสูงของหัวข้อจุด
    para2.getParagraphFormat().getBullet().setHeight(100);

    // เพิ่มย่อหน้าเข้าไปใน TextFrame
    txtFrm.getParagraphs().add(para2);
    
    // บันทึกงานนำเสนอที่แก้ไขแล้ว
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **จัดการ Picture Bullet**

รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ ย่อหน้าแบบภาพ (Picture) อ่านและเข้าใจได้ง่าย

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
2. เข้าถึงสไลด์ที่ต้องการโดยอ้างอิงจากดัชนีของมัน  
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์  
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) ของ autoshape  
5. ลบย่อปัจจุบันใน `TextFrame`  
6. สร้างอินสแตนซ์ย่อหน้าตัวแรกด้วยคลาส [Paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraph/)  
7. โหลดรูปภาพด้วย [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/)  
8. ตั้งค่า Bullet type เป็น [Picture](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) แล้วกำหนดรูปภาพ  
9. ตั้งค่า `Text` ของ Paragraph  
10. ตั้งค่า `Indent` ของ Bullet สำหรับ Paragraph  
11. กำหนดสีสำหรับ Bullet  
12. กำหนดความสูงของ Bullet  
13. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าของ `TextFrame`  
14. เพิ่มย่อหน้าที่สองและทำซ้ำขั้นตอนตามข้างต้น  
15. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด Java ตัวอย่างนี้แสดงวิธีเพิ่มและจัดการ Picture Bullet:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation presentation = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = presentation.getSlides().get_Item(0);

    // สร้างอิมเมจสำหรับหัวข้อจุด
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // เพิ่มและเข้าถึง Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // เข้าถึง TextFrame ของ Autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // ลบย่อหน้าเริ่มต้น
    textFrame.getParagraphs().removeAt(0);

    // สร้างย่อหน้าใหม่
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // ตั้งค่ารูปแบบหัวข้อจุดของย่อหน้าและรูปภาพ
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // ตั้งค่าความสูงของหัวข้อจุด
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // เพิ่มย่อหน้าเข้าไปใน TextFrame
    textFrame.getParagraphs().add(paragraph);

    // บันทึกงานนำเสนอเป็นไฟล์ PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // บันทึกงานนำเสนอเป็นไฟล์ PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **จัดการ Multilevel Bullet**

รายการ Bullet ช่วยให้คุณจัดระเบียบและนำเสนอข้อมูลได้อย่างรวดเร็วและมีประสิทธิภาพ Bullet ระดับหลายชั้นอ่านและเข้าใจได้ง่าย

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
2. เข้าถึงสไลด์ที่ต้องการโดยอ้างอิงจากดัชนีของมัน  
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ในสไลด์ใหม่  
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) ของ autoshape  
5. ลบย่อปัจจุบันใน `TextFrame`  
6. สร้างย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraph/) และตั้งค่า depth เป็น 0  
7. สร้างย่อหน้าที่สองผ่านคลาส `Paragraph` แล้วตั้งค่า depth เป็น 1  
8. สร้างย่อหน้าที่สามผ่านคลาส `Paragraph` แล้วตั้งค่า depth เป็น 2  
9. สร้างย่อหน้าที่สี่ผ่านคลาส `Paragraph` แล้วตั้งค่า depth เป็น 3  
10. เพิ่มย่อหน้าใหม่ทั้งหมดลงในคอลเลกชันย่อหน้าของ `TextFrame`  
11. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด Java ตัวอย่างนี้แสดงวิธีเพิ่มและจัดการ Multilevel Bullet:

```java
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรก
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่มและเข้าถึง Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // เข้าถึง TextFrame ของ Autoshape ที่สร้างขึ้น
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
    // ตั้งค่าระดับหัวข้อจุด
    para1.getParagraphFormat().setDepth((short)0);

    // เพิ่มย่อหน้าที่สอง
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // ตั้งค่าระดับหัวข้อจุด
    para2.getParagraphFormat().setDepth((short)1);

    // เพิ่มย่อหน้าที่สาม
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // ตั้งค่าระดับหัวข้อจุด
    para3.getParagraphFormat().setDepth((short)2);

    // เพิ่มย่อหน้าที่สี่
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // ตั้งค่าระดับหัวข้อจุด
    para4.getParagraphFormat().setDepth((short)3);

    // เพิ่มย่อหน้าเข้าไปในคอลเลกชัน
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

## **จัดการย่อหน้าด้วยรายการเลขกำหนดเอง**

ส่วนติดต่อ [IBulletFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/) มีคุณสมบัติ [NumberedBulletStartWith](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) และอื่น ๆ ที่ช่วยให้คุณจัดการย่อหน้าด้วยการนับเลขหรือการจัดรูปแบบที่กำหนดเองได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
2. เข้าถึงสไลด์ที่มีย่อหน้าอยู่  
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์  
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) ของ autoshape  
5. ลบย่อปัจจุบันใน `TextFrame`  
6. สร้างย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraph/) แล้วตั้งค่า [NumberedBulletStartWith](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เป็น 2  
7. สร้างย่อหน้าที่สองผ่านคลาส `Paragraph` แล้วตั้งค่า `NumberedBulletStartWith` เป็น 3  
8. สร้างย่อหน้าที่สามผ่านคลาส `Paragraph` แล้วตั้งค่า `NumberedBulletStartWith` เป็น 7  
9. เพิ่มย่อหน้าใหม่ลงในคอลเลกชันย่อหน้าของ `TextFrame`  
10. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด Java ตัวอย่างนี้แสดงวิธีเพิ่มและจัดการย่อหน้าที่มีการนับเลขหรือการจัดรูปแบบที่กำหนดเอง:

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

## **กำหนด Indent ของบรรทัดแรกสำหรับย่อหน้า**

ใช้เมธอด [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) เพื่อควบคุมการจัดย่อหน้าบรรทัดแรกของย่อหน้า วิธีนี้จะย้ายบรรทัดแรกเท่านั้นโดยอิงจากขอบซ้ายของย่อหน้า ค่าเป็นบวกจะย้ายบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงอยู่ตามตำแหน่งของเนื้อหาย่อหน้า

ใช้ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) เมื่อต้องการย้ายย่อหน้าเต็มบรรทัด ใช้ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) เมื่อต้องการย้ายเฉพาะบรรทัดแรกเท่านั้น

ตัวอย่างด้านล่างสร้างย่อหน้าหลายอันและกำหนดค่า Indent ที่แตกต่างกันเพื่อแสดงว่า Indent ของบรรทัดแรกส่งผลต่อการจัดวางย่ออย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
2. เข้าถึงสไลด์เป้าหมาย  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/autoshape/) สี่เหลี่ยมลงในสไลด์  
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/) เปล่าในรูปและลบย่อปริยายออก  
5. สร้างย่อหน้าหลายอันและกำหนดค่า [Indent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) ที่ต่างกันให้กับแต่ละอัน  
6. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ดนี้แสดงวิธีกำหนด Indent ให้กับย่อหน้า:

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

![Indent ของบรรทัดแรกของย่อหน้า](first_line_indent.png)

## **กำหนด Hanging Indent สำหรับย่อหน้า**

Hanging Indent คือการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยเมธอด [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) ตั้งค่า Indent เป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อหาย่อหน้า

โดยปกติ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) กำหนดตำแหน่งของบรรทัดแรกเมื่อเทียบกับ MarginLeft การสร้าง Hanging Indent ทำได้โดยตั้งค่า `MarginLeft` เป็นค่าบวกและ `Indent` เป็นค่าลบ

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, รายการอ้างอิง, บทคัดย่อ, หรือย่อหน้าอื่น ๆ ที่ต้องการให้บรรทัดต่อเนื่องเรียงชิดใต้เนื้อหาย่อหน้าแทนที่จะชิดใต้ตัวอักษรแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
2. เข้าถึงสไลด์เป้าหมาย  
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/autoshape/) สี่เหลี่ยมลงในสไลด์  
4. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/) เปล่าในรูปและลบย่อปริยายออก  
5. สร้างย่อหน้าและกำหนดค่า [MarginLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) เป็นค่าบวกสำหรับแต่ละย่อหน้า  
6. ตั้งค่า [Indent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) เป็นค่าลบเพื่อสร้างเอฟเฟกต์ Hanging Indent  
7. เพิ่มย่อหน้าเหล่านั้นลงใน TextFrame  
8. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ดนี้แสดงวิธีกำหนด Hanging Indent ให้กับย่อหน้า:

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

![Hanging Indent ของย่อหน้า](hanging_indent.png)

## **จัดการ End Paragraph Run Properties**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
1. รับอ้างอิงของสไลด์ที่มีย่อหน้าผ่านตำแหน่งของมัน  
1. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) รูปสี่เหลี่ยมลงในสไลด์  
1. เพิ่ม [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) ที่มีสองย่อหน้าลงในรูปสี่เหลี่ยม  
1. ตั้งค่า `FontHeight` และประเภทฟอนต์สำหรับย่อหน้า  
1. ตั้งค่า End properties สำหรับย่อหน้า  
1. เขียนไฟล์ PPTX ที่แก้ไขแล้ว

โค้ด Java ตัวอย่างนี้แสดงวิธีตั้งค่า End properties สำหรับย่อหน้าใน PowerPoint:

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

## **นำเข้า HTML Text เข้าสู่ย่อหน้า**

Aspose.Slides มีการสนับสนุนที่เพิ่มขึ้นสำหรับการนำเข้า HTML Text เข้าไปในย่อหน้า

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)  
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน  
3. เพิ่ม [autoshape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ลงในสไลด์  
4. เพิ่มและเข้าถึง `autoshape` [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/)  
5. ลบย่อปริยายใน `ITextFrame`  
6. อ่านไฟล์ HTML ต้นทางด้วย TextReader  
7. สร้างย่อหน้าแรกผ่านคลาส [Paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraph/)  
8. เพิ่มเนื้อหาไฟล์ HTML ที่อ่านจาก TextReader ลงใน [ParagraphCollection](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraphcollection/) ของ TextFrame  
9. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด Java ตัวอย่างนี้เป็นการทำตามขั้นตอนการนำเข้า HTML Text ในย่อหน้า:

```java
// สร้างอินสแตนซ์ Presentation ว่างเปล่า
Presentation pres = new Presentation();
try {
    // เข้าถึงสไลด์แรกเริ่มต้นของงานนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);

    // เพิ่ม AutoShape เพื่อรองรับเนื้อหา HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // เพิ่ม TextFrame ให้กับรูปร่าง
    ashape.addTextFrame("");

    // ล้างย่อหน้าทั้งหมดใน TextFrame ที่เพิ่ม
    ashape.getTextFrame().getParagraphs().clear();

    // โหลดไฟล์ HTML โดยใช้ StreamReader
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

Aspose.Slides มีการสนับสนุนที่เพิ่มขึ้นสำหรับการส่งออกข้อความ (ที่อยู่ในย่อหน้า) ไปเป็น HTML

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) และโหลดงานนำเสนอที่ต้องการ  
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน  
3. เข้าถึงรูปร่างที่มีข้อความที่จะส่งออกเป็น HTML  
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframe/) ของรูปร่างนั้น  
5. สร้างอินสแตนซ์ของ `StreamWriter` และเพิ่มไฟล์ HTML ใหม่  
6. กำหนดดัชนีเริ่มต้นให้กับ StreamWriter แล้วส่งออกย่อหน้าที่ต้องการ

โค้ด Java ตัวอย่างนี้แสดงวิธีส่งออกข้อความย่อหน้าใน PowerPoint ไปเป็น HTML:

```java
// โหลดไฟล์งานนำเสนอ
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // เข้าถึงสไลด์แรกเริ่มต้นของงานนำเสนอ
    ISlide slide = pres.getSlides().get_Item(0);

    // ดัชนีที่ต้องการ
    int index = 0;

    // เข้าถึงรูปร่างที่เพิ่มเข้าไป
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // สร้างไฟล์ HTML ผลลัพธ์
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // ดึงย่อหน้าแรกเป็น HTML
    // เขียนข้อมูลย่อหน้าเป็น HTML โดยระบุตำแหน่งเริ่มต้นของย่อหน้าและจำนวนย่อหน้าที่จะคัดลอก
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **บันทึกย่อหน้าเป็นรูปภาพ**

ในส่วนนี้เราจะสำรวจตัวอย่างสองแบบที่แสดงวิธีบันทึกย่อข้อความที่แสดงโดยอินเทอร์เฟซ [IParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/) เป็นรูปภาพ ตัวอย่างทั้งสองจะดึงรูปภาพของรูปทรงที่มีย่อหน้าโดยใช้เมธอด `getImage` ของอินเทอร์เฟซ [IShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/) คำนวณขอบเขตของย่อหน้าในรูปทรง และส่งออกเป็นภาพบิตแมพ วิธีการเหล่านี้ช่วยให้คุณสามารถดึงส่วนข้อความเฉพาะจากงานนำเสนอ PowerPoint และบันทึกเป็นภาพแยกต่างหาก ซึ่งอาจมีประโยชน์ในหลายสถานการณ์

สมมติว่าเรามีไฟล์งานนำเสนอชื่อ sample.pptx ที่มีสไลด์หนึ่งสไลด์ โดยรูปทรงแรกเป็นกล่องข้อความที่มีสามย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

**ตัวอย่างที่ 1**

ในตัวอย่างนี้เราจะดึงย่อหน้าที่สองเป็นภาพ โดยการดึงภาพของรูปจากสไลด์แรกของงานนำเสนอแล้วคำนวณขอบเขตของย่อหน้าที่สองใน TextFrame ของรูปนั้น จากนั้นย่อหน้าจะถูกวาดใหม่บนบิตแมพใหม่และบันทึกเป็นรูป PNG วิธีนี้มีประโยชน์เมื่อคุณต้องการบันทึกย่อหน้าเฉพาะเป็นภาพแยกโดยคงรายละเอียดและการจัดรูปแบบของข้อความไว้

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
    RectF paragraphRectangle = secondParagraph.getRect();

    // คำนวณพิกัดและขนาดสำหรับภาพผลลัพธ์ (ขนาดขั้นต่ำ - 1x1 พิกเซล).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // ครอปบิตแมพของรูปร่างเพื่อให้ได้บิตแมพของย่อหน้าเท่านั้น.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

ผลลัพธ์:

![ภาพของย่อหน้า](paragraph_to_image_output.png)

**ตัวอย่างที่ 2**

ในตัวอย่างนี้เราขยายวิธีเดิมโดยเพิ่มปัจจัยสเกลให้กับภาพย่อหน้า รูปร่างจะถูกดึงจากงานนำเสนอและบันทึกเป็นภาพโดยใช้สเกล  `2` ทำให้ได้ผลลัพธ์ความละเอียดสูงขึ้นเมื่อส่งออกย่อหน้า ขอบเขตของย่อหน้าจะคำนวณโดยคำนึงถึงสเกล การสเกลจะเป็นประโยชน์เมื่อ ต้องการภาพที่มีรายละเอียดมากขึ้น เช่น การใช้ในสื่อพิมพ์คุณภาพสูง

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
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // คำนวณพิกัดและขนาดสำหรับภาพผลลัพธ์ (ขนาดขั้นต่ำ - 1x1 พิกเซล).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // ครอปบิตแมพของรูปร่างเพื่อให้ได้บิตแมพของย่อหน้าเท่านั้น.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**ฉันสามารถปิดการตัดบรรทัดอัตโนมัติภายใน TextFrame ได้หรือไม่?**

ได้ ใช้การตั้งค่าการตัดบรรทัดของ TextFrame ([setWrapText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) เพื่อปิดการตัดบรรทัด sehingga บรรทัดจะไม่ตัดที่ขอบของเฟรม

**ฉันจะรับขอบเขตบนสไลด์ของย่อหน้าที่เฉพาะเจาะจงได้อย่างไร?**

คุณสามารถดึงสี่เหลี่ยมขอบของย่อหน้า (หรือแม้กระทั่งของ Portion เดียว) เพื่อให้ทราบตำแหน่งและขนาดที่แม่นยำบนสไลด์

**ตำแหน่งการจัดแนวของย่อหน้า (ซ้าย/ขวา/กึ่งกลาง/จัดเต็ม) ควบคุมที่ไหน?**

[Alignment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) เป็นการตั้งค่าระดับย่อหน้าใน [ParagraphFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraphformat/) ซึ่งใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของ Portion แต่ละส่วน

**ฉันสามารถตั้งค่าภาษาเช็คการสะกดสำหรับส่วนของย่อหน้าเดียว (เช่น คำเดียว) ได้หรือไม่?**

ได้ ภาษาเท่านั้นตั้งค่าที่ระดับ Portion ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)) ดังนั้นหลายภาษาอาจอยู่ร่วมกันภายในย่อหน้าเดียวได้