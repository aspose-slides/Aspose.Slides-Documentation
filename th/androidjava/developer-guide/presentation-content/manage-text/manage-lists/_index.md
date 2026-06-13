---
title: จัดการรายการหัวข้อและลำดับเลขในงานนำเสนอบน Android
linktitle: จัดการรายการ
type: docs
weight: 60
url: /th/androidjava/manage-lists/
keywords:
- หัวข้อ
- รายการหัวข้อ
- รายการลำดับเลข
- สัญลักษณ์หัวข้อ
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
description: "เรียนรู้วิธีสร้างและจัดรูปแบบรายการหัวข้อ, รายการรูปภาพ, รายการหลายระดับ และรายการลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Android via Java ให้คุณสร้างและจัดรูปแบบรายการที่มีหัวข้อและรายการลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument. รายการหนึ่งเป็นย่อหน้าที่การตั้งค่าหัวข้อถูกควบคุมผ่านรูปแบบย่อหน้าของมัน.

ใช้เมธอด [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) เพื่อเข้าถึงการตั้งค่ารายการระดับย่อหน้า. จุดเริ่มต้นหลักคือ [IParagraphFormat.getBullet](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), ซึ่งจะคืนค่าเป็นวัตถุ [IBulletFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/). ด้วยวัตถุนี้ คุณสามารถตั้งค่าชนิดของหัวข้อ, สัญลักษณ์, รูปภาพ, สี, ขนาด, รูปแบบการนับเลข, และหมายเลขเริ่มต้นได้.

บทความนี้จะแสดงวิธีการ:

- สร้างรายการหัวข้อโดยใช้สัญลักษณ์ที่กำหนดเอง
- สร้างหัวข้อแบบรูปภาพ
- สร้างรายการหลายระดับโดยการกำหนดระดับความลึกของย่อหน้า
- สร้างรายการลำดับเลข
- ตรวจสอบและเปลี่ยนแปลงรูปแบบรายการในงานนำเสนอที่มีอยู่

## **สร้างรายการหัวข้อ**

เพื่อสร้างรายการหัวข้อ, เพิ่มย่อหน้าไปยัง [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) และตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/bullettype/). จากนั้นคุณสามารถตั้งค่า [IBulletFormat.setChar](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#getColor--) และ [IBulletFormat.setHeight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) เพื่อควบคุมลักษณะของหัวข้อได้.

โค้ด Java ด้านล่างแสดงวิธีสร้างรายการหัวข้อในสไลด์:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph1 = new Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph1.getParagraphFormat().getBullet().setChar('*');
    paragraph1.getParagraphFormat().setIndent(15);
    paragraph1.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph1.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph1.getParagraphFormat().getBullet().setHeight(100);
    paragraph1.setText("The first paragraph");
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    paragraph2.getParagraphFormat().getBullet().setChar('*');
    paragraph2.getParagraphFormat().setIndent(15);
    paragraph2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    paragraph2.getParagraphFormat().getBullet().getColor().setColor(Color.RED);
    paragraph2.getParagraphFormat().getBullet().setHeight(100);
    paragraph2.setText("The second paragraph");
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![หัวข้อสัญลักษณ์](symbol_bullets.png)

## **สร้างรายการลำดับเลข**

ใช้รายการลำดับเลขเมื่อลำดับของรายการมีความสำคัญ. ตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/bullettype/). คุณยังสามารถเลือกรูปแบบการนับเลขด้วย [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) หรือกำหนดค่าเริ่มต้นด้วย [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เมื่อรายการควรเริ่มจากค่าที่ไม่ใช่ 1.

โค้ด Java ด้านล่างแสดงวิธีสร้างรายการลำดับเลขในสไลด์:

```java
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

![หัวข้อลำดับเลข](numbered_bullets.png)

## **สร้างหัวข้อแบบรูปภาพ**

Aspose.Slides อนุญาตให้คุณเปลี่ยนสัญลักษณ์หัวข้อทั่วไปเป็นภาพ. หัวข้อแบบรูปภาพทำงานได้ดีที่สุดกับภาพที่เรียบง่ายและยังคงอ่านได้เมื่อขนาดเล็ก, เช่น ไอคอนหรือไฟล์ PNG โปร่งใสขนาดเล็ก.

{{% alert color="primary" %}}
โดยแนวคิด, หากคุณวางแผนจะเปลี่ยนสัญลักษณ์หัวข้อทั่วไปเป็นภาพ, ควรเลือกกราฟิกที่เรียบง่ายพร้อมพื้นหลังโปร่งใส. ภาพเช่นนั้นทำงานได้ดีเป็นสัญลักษณ์หัวข้อแบบกำหนดเอง.

โปรดจำไว้ว่าภาพจะถูกย่อขนาดลงเป็นขนาดเล็กมาก. ด้วยเหตุผลนี้ เราขอแนะนำให้เลือกภาพที่ยังคงชัดเจนและมีประสิทธิภาพในการมองเห็นเมื่อนำไปใช้เป็นหัวข้อในรายการ.
{{% /alert %}}

เพื่อสร้างหัวข้อแบบรูปภาพ, เพิ่มภาพไปยัง [Presentation.getImages](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/#getImages--) และกำหนดวัตถุ [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/) ที่ได้ให้กับ [IBulletFormat.getPicture](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#getPicture--). ตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) เป็น [BulletType.Picture](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/bullettype/) ก่อนการกำหนดภาพ.

สมมติว่าเรามีไฟล์ "image.png":

![ภาพสำหรับหัวข้อ](picture_for_bullets.png)

โค้ด Java ด้านล่างแสดงวิธีสร้างหัวข้อรูปภาพในสไลด์:

```java
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

![หัวข้อรูปภาพ](picture_bullets.png)

## **สร้างรายการหลายระดับ**

ใช้ [IParagraphFormat.setDepth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) เพื่อวางรายการในระดับต่าง ๆ. ระดับ 0 คือระดับบนสุด, ระดับ 1 อยู่ด้านล่างของระดับ 0, และต่อไปเช่นกัน.

โค้ด Java ด้านล่างแสดงวิธีสร้างรายการหัวข้อหลายระดับ:

```java
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

เพื่อเปลี่ยนรูปแบบรายการในงานนำเสนอที่มีอยู่, เข้าถึงย่อเป้าหมายและอัปเดตการตั้งค่า [IParagraphFormat.getBullet](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#getBullet--) ของมัน. วิธีเดียวกันที่ใช้เพื่อสร้างรายการสามารถใช้เพื่อตรวจสอบหรือแก้ไขรายการที่โหลดจากไฟล์ PPT, PPTX หรือ ODP ได้.

โค้ด Java ด้านล่างเปลี่ยนย่อหน้าตัวแรกในกรอบข้อความให้ใช้สไตล์รายการลำดับเลข:

```java
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

**สามารถส่งออกรายการหัวข้อและลำดับเลขเป็น PDF หรือรูปภาพได้หรือไม่?**

ใช่. Aspose.Slides รักษารูปแบบรายการเมื่อรูปแบบเป้าหมายสนับสนุนการจัดวางข้อความและคุณลักษณะหัวข้อที่สอดคล้องกัน.

**ฉันสามารถแก้ไขรายการในงานนำเสนอที่มีอยู่ได้หรือไม่?**

ใช่. โหลดงานนำเสนอ, เข้าถึงย่อเป้าหมาย, ตรวจสอบหรืออัปเดตการตั้งค่า [IParagraphFormat.getBullet](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#getBullet--), แล้วบันทึกงานนำเสนอ.

**รายการสามารถมีข้อความที่ไม่ใช่ละตินได้หรือไม่?**

ใช่. ข้อความของรายการสามารถบรรจุอักขระ Unicode ได้, ดังนั้นคุณจึงสามารถสร้างรายการในงานนำเสนอหลายภาษาได้. ตรวจสอบให้แน่ใจว่าแบบอักษรที่ใช้ในงานนำเสนอสนับสนุนอักขระที่คุณต้องการ.