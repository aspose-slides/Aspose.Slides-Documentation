---
title: จัดการรายการแบบหัวข้อและลำดับตัวเลขในงานนำเสนอบน Android
linktitle: จัดการรายการ
type: docs
weight: 60
url: /th/androidjava/manage-lists/
keywords:
- หัวข้อ
- รายการแบบหัวข้อ
- รายการลำดับตัวเลข
- หัวข้อสัญลักษณ์
- หัวข้อรูปภาพ
- หัวข้อกำหนดเอง
- รายการหลายระดับ
- สร้างหัวข้อ
- เพิ่มหัวข้อ
- เพิ่มรายการ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบรายการแบบหัวข้อ, รูปภาพ, หลายระดับและลำดับตัวเลขในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **Overview**

Aspose.Slides for Android via Java ให้คุณสร้างและจัดรูปแบบรายการแบบกล่องสัญลักษณ์และรายการลำดับตัวเลขในงานนำเสนอ PowerPoint และ OpenDocument รายการหนึ่งเป็นย่อหน้าที่การตั้งค่ารูปแบบหัวข้อสัญลักษณ์ถูกควบคุมผ่านรูปแบบย่อหน้าของมัน

ใช้เมธอด[IParagraph.getParagraphFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--)เพื่อเข้าถึงการตั้งค่ารายการระดับย่อหน้า จุดเข้าถึงหลักคือ[IParagraphFormat.getBullet](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), ซึ่งจะคืนค่าออบเจกต์[IBulletFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/) ด้วยออบเจกต์นี้ คุณสามารถตั้งค่าชนิดของสัญลักษณ์, สัญลักษณ์, รูปภาพ, สี, ขนาด, รูปแบบการนับเลข, และหมายเลขเริ่มต้น

บทความนี้แสดงวิธี:

- สร้างรายการแบบกล่องสัญลักษณ์ด้วยสัญลักษณ์ที่กำหนดเอง
- สร้างสัญลักษณ์รูปภาพ
- สร้างรายการหลายระดับโดยตั้งค่าความลึกของย่อหน้า
- สร้างรายการลำดับตัวเลข
- ตรวจสอบและเปลี่ยนแปลงการจัดรูปแบบรายการในงานนำเสนอที่มีอยู่

## **Create a Bulleted List**

เพื่อสร้างรายการแบบกล่องสัญลักษณ์ เพิ่มย่อหน้าใน[ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/)และตั้งค่า[IBulletFormat.setType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setType-byte-)เป็น[BulletType.Symbol](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/bullettype/) จากนั้นคุณสามารถตั้งค่า[IBulletFormat.setChar](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setChar-char-),[IBulletFormat.getColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#getColor--),และ[IBulletFormat.setHeight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-)เพื่อควบคุมลักษณะของสัญลักษณ์

โค้ด Java ด้านล่างแสดงวิธีสร้างรายการแบบกล่องสัญลักษณ์ในสไลด์:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Color bulletColor = new Color(205, 92, 92);

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(bulletColor);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![สัญลักษณ์หัวข้อสัญลักษณ์](symbol_bullets.png)

## **Create a Numbered List**

ใช้รายการลำดับตัวเลขเมื่อลำดับของรายการมีความสำคัญ ตั้งค่า[IBulletFormat.setType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setType-byte-)เป็น[BulletType.Numbered](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/bullettype/) คุณยังสามารถเลือกรูปแบบการนับเลขด้วย[IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-)หรือกำหนดค่า[IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-)เมื่อรายการควรเริ่มจากค่าที่ไม่ใช่ 1

โค้ด Java ด้านล่างแสดงวิธีสร้างรายการลำดับตัวเลขในสไลด์:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![สัญลักษณ์หัวข้อเป็นตัวเลข](numbered_bullets.png)

## **Create a Picture Bullet**

Aspose.Slides อนุญาตให้คุณแทนที่สัญลักษณ์หัวข้อทั่วไปด้วยภาพ สัญลักษณ์รูปภาพทำงานได้ดีสุดกับภาพที่เรียบง่ายและยังคงอ่านได้ในขนาดเล็ก เช่น ไอคอนหรือไฟล์ PNG ที่มีพื้นหลังโปร่งใส

{{% alert color="info" %}}
โดยอุดมคติ หากคุณวางแผนจะแทนที่สัญลักษณ์หัวข้อทั่วไปด้วยภาพ ควรเลือกกราฟิกที่เรียบง่ายพร้อมพื้นหลังโปร่งใส ภาพเหล่านี้ทำงานได้ดีเป็นสัญลักษณ์หัวข้อแบบกำหนดเอง

โปรดจำไว้ว่าภาพจะถูกย่อขนาดลงเป็นขนาดเล็กมาก ดังนั้นเราขอแนะนำให้เลือกภาพที่ยังคงชัดเจนและมองเห็นได้ดีเมื่อนำไปใช้เป็นสัญลักษณ์หัวข้อในรายการ
{{% /alert %}}

เพื่อสร้างสัญลักษณ์รูปภาพ เพิ่มภาพเข้าไปใน[Presentation.getImages](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getImages--)และกำหนดออบเจกต์[IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/)ที่ได้ให้กับ[IBulletFormat.getPicture](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#getPicture--). ตั้งค่า[IBulletFormat.setType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setType-byte-)เป็น[BulletType.Picture](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/bullettype/) ก่อนกำหนดภาพ

สมมติว่าเรามีไฟล์ "image.png":

![รูปภาพสำหรับสัญลักษณ์หัวข้อ](picture_for_bullets.png)

โค้ด Java ด้านล่างแสดงวิธีสร้างสัญลักษณ์รูปภาพในสไลด์:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    IPPImage bulletImage = presentation.getImages().addImage(Images.fromFile("image.png"));

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph1.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph2.getParagraphFormat().getBullet().getPicture().setImage(bulletImage);
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![สัญลักษณ์หัวข้อรูปภาพ](picture_bullets.png)

## **Create a Multilevel List**

ใช้[IParagraphFormat.setDepth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-)เพื่อวางรายการในระดับต่าง ๆ ระดับ 0 คือระดับบนสุด ระดับ 1 อยู่ภายในระดับนั้นต่อไป

โค้ด Java ด้านล่างแสดงวิธีสร้างรายการหลายระดับ:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().setDepth((short) 0);
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().setDepth((short) 1);
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    Paragraph paragraph3 = new Paragraph();
    paragraph3.getParagraphFormat().setDepth((short) 2);
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    Paragraph paragraph4 = new Paragraph();
    paragraph4.getParagraphFormat().setDepth((short) 3);
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รายการหลายระดับ](multilevel_list.png)

## **Change an Existing List**

เพื่อเปลี่ยนรูปแบบรายการในงานนำเสนอที่มีอยู่ ให้เข้าถึงย่อหน้าเป้าหมายและอัปเดตการตั้งค่า[IParagraphFormat.getBullet](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) ของมัน วิธีเดียวกันที่ใช้สร้างรายการสามารถใช้ตรวจสอบหรือแก้ไขรายการที่โหลดจากไฟล์ PPT, PPTX หรือ ODP ได้

โค้ด Java ด้านล่างเปลี่ยนย่อหน้าแรกในกรอบข้อความให้ใช้สไตล์รายการลำดับตัวเลข:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletRomanUCPeriod);
    paragraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 1);
    paragraph.getParagraphFormat().setMarginLeft(30);
    paragraph.getParagraphFormat().setIndent(-20);

    presentation.save("updated_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### สามารถส่งออกรายการแบบกล่องสัญลักษณ์และลำดับตัวเลขเป็น PDF หรือรูปภาพได้หรือไม่?

ได้ Aspose.Slides รักษาการจัดรูปแบบรายการเมื่อรูปแบบเป้าหมายรองรับการจัดวางข้อความและคุณสมบัติของสัญลักษณ์ที่สอดคล้องกัน

### สามารถแก้ไขรายการในงานนำเสนอที่มีอยู่ได้หรือไม่?

ได้ โหลดงานนำเสนอ, เข้าถึงย่อหน้าเป้าหมาย, ตรวจสอบหรืออัปเดตการตั้งค่า[IParagraphFormat.getBullet](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) ของมัน และบันทึกงานนำเสนอ

### รายการสามารถมีข้อความที่ไม่ใช่ละตินได้หรือไม่?

ได้ ข้อความของรายการสามารถมีอักษร Unicode ได้ ดังนั้นคุณจึงสามารถสร้างรายการในงานนำเสนอหลายภาษาต่างกันได้ ตรวจสอบให้แน่ใจว่าแบบอักษรที่ใช้ในงานนำเสนอสนับสนุนอักขระที่คุณต้องการ