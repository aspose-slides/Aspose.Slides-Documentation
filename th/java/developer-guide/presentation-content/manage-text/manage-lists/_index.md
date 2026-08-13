---
title: จัดการรายการแบบมีจุดหัวข้อและลำดับเลขในงานนำเสนอด้วย Java
linktitle: จัดการรายการ
type: docs
weight: 60
url: /th/java/manage-lists/
keywords:
- จุดหัวข้อ
- รายการแบบมีจุดหัวข้อ
- รายการลำดับเลข
- จุดหัวข้อสัญลักษณ์
- จุดหัวข้อรูปภาพ
- จุดหัวข้อกำหนดเอง
- รายการหลายระดับ
- สร้างจุดหัวข้อ
- เพิ่มจุดหัวข้อ
- เพิ่มรายการ
- PowerPoint
- OpenDocument
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีการสร้างและจัดรูปแบบรายการแบบมีจุดหัวข้อ รูปภาพ หลายระดับ และลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

Aspose.Slides for Java ช่วยให้คุณสร้างและจัดรูปแบบรายการแบบมีจุดหัวข้อและรายการลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument รายการหนึ่งเป็นย่อหน้าที่การตั้งค่าจุดหัวข้อถูกควบคุมผ่านรูปแบบย่อหน้าของมัน

ใช้เมธอด [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/#getParagraphFormat--) เพื่อเข้าถึงการตั้งค่ารายการระดับย่อหน้า จุดเริ่มต้นหลักคือ [IParagraphFormat.getBullet](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#getBullet--) ซึ่งคืนค่าออบเจ็กต์ [IBulletFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/) ด้วยออบเจ็กต์นี้ คุณสามารถตั้งค่าชนิดของจุดหัวข้อ สัญลักษณ์ รูปภาพ สี ขนาด สไตล์การลำดับเลข และหมายเลขเริ่มต้นได้

บทความนี้แสดงวิธีการ:

- สร้างรายการแบบมีจุดหัวข้อด้วยสัญลักษณ์ที่กำหนดเอง
- สร้างจุดหัวข้อรูปภาพ
- สร้างรายการหลายระดับโดยกำหนดความลึกของย่อหน้า
- สร้างรายการลำดับเลข
- ตรวจสอบและเปลี่ยนรูปแบบรายการในงานนำเสนอที่มีอยู่

## **สร้างรายการแบบมีจุดหัวข้อ**

เพื่อสร้างรายการแบบมีจุดหัวข้อ ให้เพิ่มออบเจ็กต์ [IParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/) ลงใน [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) และตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setType-byte-) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/th/java/com.aspose.slides/bullettype/#Symbol) จากนั้นคุณสามารถตั้งค่า [IBulletFormat.setChar](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#getColor--), และ [IBulletFormat.setHeight](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setHeight-float-) เพื่อควบคุมลักษณะของจุดหัวข้อได้

โค้ด Java ต่อไปนี้แสดงวิธีสร้างรายการแบบมีจุดหัวข้อในสไลด์:

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

![จุดหัวข้อสัญลักษณ์](symbol_bullets.png)

## **สร้างรายการลำดับเลข**

ใช้รายการลำดับเลขเมื่อลำดับของรายการมีความสำคัญ ตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setType-byte-) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/th/java/com.aspose.slides/bullettype/#Numbered) คุณยังสามารถเลือกรูปแบบการลำดับเลขด้วย [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) หรือกำหนดค่าเริ่มต้นด้วย [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) หากต้องการให้รายการเริ่มจากค่าที่ไม่ใช่ 1

โค้ด Java ต่อไปนี้แสดงวิธีสร้างรายการลำดับเลขในสไลด์:

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

![จุดหัวข้อลำดับเลข](numbered_bullets.png)

## **สร้างจุดหัวข้อรูปภาพ**

Aspose.Slides อนุญาตให้คุณแทนที่สัญลักษณ์จุดหัวข้อปกติด้วยภาพ จุดหัวข้อรูปภาพทำงานได้ดีที่สุดกับภาพที่เรียบง่ายและยังคงอ่านได้ที่ขนาดเล็ก เช่น ไอคอนหรือไฟล์ PNG โปร่งใสขนาดเล็ก

{{% alert color="info" %}}
โดยทั่วไป หากคุณมีแผนจะเปลี่ยนสัญลักษณ์จุดหัวข้อปกติเป็นภาพ ควรเลือกกราฟิกที่เรียบง่ายพร้อมพื้นหลังโปร่งใส ภาพดังกล่าวทำงานได้ดีเป็นสัญลักษณ์จุดหัวข้อแบบกำหนดเอง

ควรจำไว้ว่า ภาพจะถูกย่อขนาดลงเป็นขนาดเล็กมาก ด้วยเหตุนี้ เราขอแนะนำอย่างยิ่งให้เลือกภาพที่คงความคมชัดและมีประสิทธิภาพเชิงสายตาเมื่อใช้เป็นจุดหัวข้อในรายการ
{{% /alert %}}

เพื่อสร้างจุดหัวข้อรูปภาพ ให้เพิ่มภาพลงใน [Presentation.getImages](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/#getImages--) แล้วกำหนดออบเจ็กต์ภาพที่คืนค่าให้กับ [IBulletFormat.getPicture](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#getPicture--) ตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setType-byte-) เป็น [BulletType.Picture](https://reference.aspose.com/slides/th/java/com.aspose.slides/bullettype/#Picture) ก่อนกำหนดภาพ

สมมติว่าเรามีไฟล์ “image.png”:

![รูปภาพสำหรับจุดหัวข้อ](picture_for_bullets.png)

โค้ด Java ต่อไปนี้แสดงวิธีสร้างจุดหัวข้อรูปภาพในสไลด์:

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

![จุดหัวข้อรูปภาพ](picture_bullets.png)

## **สร้างรายการหลายระดับ**

ใช้ [IParagraphFormat.setDepth](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setDepth-short-) เพื่อวางรายการในระดับที่ต่างกัน ระดับ 0 คือระดับบนสุด ระดับ 1 อยู่ด้านในระดับนั้นและต่อไป

โค้ด Java ต่อไปนี้แสดงวิธีสร้างรายการแบบมีจุดหัวข้อหลายระดับ:

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

## **เปลี่ยนรายการที่มีอยู่**

เพื่อเปลี่ยนรูปแบบรายการในงานนำเสนอที่มีอยู่ ให้เข้าถึงย่อหน้าที่ต้องการและอัปเดตการตั้งค่า [IParagraphFormat.getBullet](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#getBullet--) ของมัน คุณสามารถใช้คุณสมบัติเช่นเดียวกับที่ใช้สร้างรายการเพื่อสอบถามหรือแก้ไขรายการที่โหลดจากไฟล์ PPT, PPTX หรือ ODP ได้

โค้ด Java ต่อไปนี้เปลี่ยนย่อหน้าแรกในเฟรมข้อความให้ใช้สไตล์รายการลำดับเลข:

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

## **คำถามที่พบบ่อย**

### สามารถส่งออกรายการแบบมีจุดหัวข้อและรายการลำดับเลขเป็น PDF หรือภาพได้หรือไม่?

ใช่ Aspose.Slides รักษารูปแบบรายการเมื่อรูปแบบเป้าหมายสนับสนุนการจัดวางข้อความและคุณสมบัติของจุดหัวข้อที่สอดคล้องกัน

### ฉันสามารถแก้ไขรายการในงานนำเสนอที่มีอยู่ได้หรือไม่?

ใช่ โหลดงานนำเสนอเข้ามา เข้าถึงย่อหน้าที่ต้องการ ตรวจสอบหรืออัปเดตการตั้งค่า [IParagraphFormat.getBullet](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#getBullet--) ของมัน แล้วบันทึกงานนำเสนอ

### รายการสามารถมีข้อความที่ไม่ใช่อักษรละตินได้หรือไม่?

ใช่ ข้อความของรายการสามารถประกอบด้วยอักขระยูนิโค้ดได้ ดังนั้นคุณจึงสร้างรายการในงานนำเสนอหลายภาษได้ ตรวจสอบให้แน่ใจว่าแบบอักษรที่ใช้ในงานนำเสนอสนับสนุนอักขระที่คุณต้องการ