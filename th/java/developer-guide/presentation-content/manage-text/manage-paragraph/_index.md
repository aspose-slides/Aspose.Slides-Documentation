---
title: จัดการย่อหน้าข้อความ PowerPoint ใน Java
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
- จัดการ bullet
- ระยะเยื้องย่อหน้า
- ระยะเยื้องแบบ hanging
- จุดหัวข้อย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อ
- คุณสมบัติย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นรูปภาพ
- ข้อความเป็นรูปภาพ
- ส่งออกย่อหน้า
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, portion, bullet, รายการลำดับเลข, ระยะเยื้อง, เนื้อหา HTML, และรูปภาพย่อหน้า ด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

Aspose.Slides for Java แสดงข้อความเป็นลำดับชั้นของ text frames, paragraphs, และ portions:

* [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) คือคอนเทนเนอร์ข้อความใน shape และให้เข้าถึง collection ของ paragraph
* [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) คือนามัยหนึ่งใน text frame และให้เข้าถึง portions และการจัดรูปแบบระดับ paragraph
* [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) คือการรันข้อความภายใน paragraph แต่ละส่วนสามารถมีการจัดรูปแบบข้อความและอักขระของตนเองได้

ดังนั้น paragraph สามารถมีข้อความที่มีฟอนต์, สี, ขนาด, และการจัดรูปแบบอื่น ๆ ที่แตกต่างกันได้โดยใช้หลาย portions

## **สร้างและจัดรูปแบบ Paragraphs**

สร้าง paragraph ใน text frame ของ shape และใช้ portions เพื่อจัดรูปแบบการรันข้อความแต่ละส่วน ส่วนนี้แสดงวิธีการรวมหลาย portions ภายในแต่ละ paragraph และใช้สี, ขนาดฟอนต์, และสไตล์ที่ต่างกัน

### **สร้าง Paragraphs ด้วยหลาย Portions**

ตัวอย่าง Java ด้านล่างสร้างสาม paragraph แต่ละ paragraph มีสาม text run ใน collection ที่คืนค่าจาก [IParagraph.getPortions](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getPortions--)  มันใช้ paragraph เริ่มต้นและ portion ว่างเปล่าของมันซ้ำแล้วเพิ่ม paragraph และ portions ที่เหลือ การจัดรูปแบบทำผ่าน [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--)  portion แรกของแต่ละ paragraph มีสีแดง, เติมหนา, ขนาด 15 pt; portion ที่สองเป็นสีน้ำเงิน, ตัวเอียง, ขนาด 18 pt; portion ที่สามคงการจัดรูปแบบเริ่มต้นไว้:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
    ITextFrame textFrame = shape.getTextFrame();

    IParagraph firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new Portion());
    firstParagraph.getPortions().add(new Portion());

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    secondParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(secondParagraph);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    thirdParagraph.getPortions().add(new Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    int paragraphCount = textFrame.getParagraphs().getCount();
    for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        IParagraph paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        int portionCount = paragraph.getPortions().getCount();
        for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **สร้างรายการแบบ Bulleted และ Numbered**

จัดระเบียบข้อความ paragraph เป็นรายการที่มีสัญลักษณ์, ตัวเลข, หรือรูปภาพกำหนดเอง ตัวอย่างในส่วนนี้ครอบคลุมการจัดรูปแบบ bullet, รายการหลายระดับ, และการกำหนดหมายเลขเริ่มต้นแบบกำหนดเอง

### **สร้าง Bulleted หรือ Numbered List**

Bullet และการใส่หมายเลขทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการกำหนดโดยผ่าน [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/)

ตัวอย่าง Java นี้เพิ่ม bullet สัญลักษณ์และรายการหมายเลขใน text frame เดียวกัน [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) เลือกประเภท bullet, while [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) กำหนดสัญลักษณ์และ [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) เลือกสไตล์การนับเลข รายการทั้งสองใช้ bullet สีดำ ความสูง 100 % และการเยื้อง paragraph 25 pt:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph symbolParagraph = new Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    symbolParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    Paragraph numberedParagraph = new Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True);
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ใช้ Picture Bullets**

Picture bullets ให้คุณใช้รูปภาพกำหนดเองแทนสัญลักษณ์หรือหมายเลข

ตัวอย่าง Java นี้เพิ่มรูปภาพลงใน collection ของภาพของงานนำเสนอเป็น [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) แล้วใช้เป็น bullet ของ paragraph มันเรียก [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) เพื่อใช้ picture bullet และกำหนดรูปภาพผ่าน [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--)  [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) ตั้งเป็น 100 % เพื่อกำหนดขนาด bullet ให้สัมพันธ์กับข้อความ paragraph:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IImage bulletImage = Images.fromFile("bullets.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **สร้าง Multilevel List**

ตั้งค่า [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) เพื่อวาง paragraph ในระดับต่าง ๆ ของรายการ ระดับบนสุดมี depth `0`

ตัวอย่าง Java นี้กำหนดค่า [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) ตั้งแต่ 0 ถึง 3 ให้กับสี่ paragraph สร้างโครงสร้างลำดับชั้นใน text frame เดียว แต่ละ paragraph ใช้ bullet สัญลักษณ์ โดยที่ [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) สลับกันระหว่าง bullet กลมและ hyphen เพื่อบ่งชี้ระดับที่อยู่ถัดกัน:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    IParagraph firstParagraph = new Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    firstParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setDepth((short) 0);

    IParagraph secondParagraph = new Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    secondParagraph.getParagraphFormat().getBullet().setChar('-');
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setDepth((short) 1);

    IParagraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    thirdParagraph.getParagraphFormat().getBullet().setChar((char) 0x2022);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setDepth((short) 2);

    IParagraph fourthParagraph = new Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    fourthParagraph.getParagraphFormat().getBullet().setChar('-');
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    fourthParagraph.getParagraphFormat().setDepth((short) 3);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **กำหนดค่าเริ่มต้นของ Numbered List Items ให้เป็นค่ากำหนดเอง**

ใช้ [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เพื่อกำหนดหมายเลขเริ่มต้นที่แสดงสำหรับ paragraph ที่มีการนับเลข

ตัวอย่าง Java นี้ตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) ให้ใช้การนับเลขสำหรับสาม paragraph และกำหนดค่า [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เป็น 2, 3, และ 7 ค่าที่เริ่มต้นกำหนดแยกกันสำหรับแต่ละ paragraph ทำให้หมายเลขที่แสดงข้ามค่า:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 2);
    textFrame.getParagraphs().add(firstParagraph);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 3);
    textFrame.getParagraphs().add(secondParagraph);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith((short) 7);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ควบคุมการจัดวาง Paragraph และคุณสมบัติ End**

ปรับ margin และ indent ของ paragraph เพื่อควบคุมตำแหน่งของบรรทัดแรกและบรรทัดที่ตัดต่อ นอกจากนี้คุณยังสามารถจัดรูปแบบเครื่องหมายจบ paragraph แยกจากส่วนข้อความที่มองเห็นได้

### **ตั้งค่า First-Line Indent**

ใช้เมธอด [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) เพื่อควบคุมการเยื้องบรรทัดแรกของ paragraph การตั้งค่านี้จะเคลื่อนย้ายเฉพาะบรรทัดแรกเทียบกับ margin ซ้ายของ paragraph ค่าบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือยังคงจัดตำแหน่งกับเนื้อหา paragraph

ใช้ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) เมื่อคุณต้องการย้ายทั้ง paragraph ใช้ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างต่อไปนี้ให้สาม paragraph มี [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) เท่ากับ 20 pt และค่า [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) เป็น 0, 20, และ 40 pt ตามลำดับ บรรทัดแรกเริ่มที่ระยะที่เพิ่มขึ้นในขณะที่บรรทัดต่อเนื่องคง margin ซ้ายเท่าเดิม:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ระยะเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งค่า Hanging Indent**

Hanging indent คือการจัดวาง paragraph ที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วย property [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) ตั้งค่า `Indent` เป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อหา paragraph

โดยทั่วไป [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) กำหนดตำแหน่งซ้ายของเนื้อหา paragraph, ส่วน [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) กำหนดตำแหน่งของบรรทัดแรกสัมพันธ์กับ margin นั้น เพื่อตั้งค่า hanging indent ให้ตั้งค่า `MarginLeft` เป็นบวกและ `Indent` เป็นลบ

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการอักษรย่อ, และ paragraph อื่น ๆ ที่บรรทัดต่อเนื่องต้องจัดแนวใต้เนื้อหา paragraph แทนที่จะจัดแนวใต้ตัวอักษรแรกของบรรทัดแรก

ตัวอย่าง Java ด้านล่างจับคู่ค่า [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) 40 pt และ 60 pt กับค่า [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) -20 pt และ -30 pt ในแต่ละ paragraph บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดต่อเนื่อง; paragraph ที่สองมี hanging indent ที่ลึกกว่า:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![Hanging indent ของย่อหน้า](hanging_indent.png)

### **ตั้งค่า End Paragraph Run Properties**

เมธอด [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) ควบคุมการจัดรูปแบบของเครื่องหมายจบ paragraph ตัวอย่างต่อไปนี้สร้าง [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) ที่มี [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) ตั้งเป็น 48 pt และ [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) ตั้งเป็น Times New Roman จากนั้นกำหนดรูปแบบนี้ให้กับเครื่องหมายจบของ paragraph ที่สอง โดยไม่กระทบต่อ portion ที่มองเห็น:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getPortions().add(new Portion("Sample text"));

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getPortions().add(new Portion("Sample text 2"));

    PortionFormat endParagraphFormat = new PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **นับจำนวนบรรทัดที่แสดงผล**

สำหรับกฎของ paragraph ที่มีผลต่อการตัดบรรทัดอัตโนมัติและเครื่องหมายวรรคตอนที่ด้านท้ายบรรทัด ดูที่ [Control Line Breaking](/slides/th/java/text-formatting/#control-line-breaking) และ [Control Hanging Punctuation](/slides/th/java/text-formatting/#control-hanging-punctuation)

ใช้เมธอด [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) เพื่อนับจำนวนบรรทัดที่ paragraph ใช้หลังจากการจัดวางข้อความ รวมถึงการตัดบรรทัดอัตโนมัติ สิ่งนี้เป็นประโยชน์เมื่อคุณต้องตรวจสอบความยาวของข้อความและการจัดวางในเท็มเพลตงานนำเสนอ

paragraph เป็นรายการหนึ่งใน [ITextFrame.getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParagraphs--) และอาจครอบคลุมหลายบรรทัดที่แสดงผล การใส่ line break อย่างชัดเจนภายใน paragraph จะบังคับให้เริ่มบรรทัดใหม่โดยไม่สร้าง paragraph ใหม่ การตัดบรรทัดอัตโนมัติสร้างบรรทัดตามความกว้างที่มีอยู่โดยไม่แทรก line break ลงในข้อความ ดังนั้นการนับ paragraph หรืออักขระ line‑break ไม่ได้ให้จำนวนบรรทัดที่แสดงผล

ตัวอย่างต่อไปนี้สร้าง shape ข้อความ, นับบรรทัด, ทำให้ shape แคบลง, แล้วเปลี่ยนข้อความเป็นสตริงสั้นกว่า ตัวอย่างเปิดใช้งานการตัดบรรทัดด้วย [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) และปิดการ Autofit ด้วย [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) เพื่อให้ความกว้างของ shape ควบคุมการตัดบรรทัดโดยไม่ย่อข้อความหรือปรับขนาด shape โดยอัตโนมัติ การวัดแต่ละครั้งใช้ [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--)  มิติของ shape อยู่ในหน่วย point สุดท้าย ตัวอย่างเพิ่ม paragraph อีกหนึ่งและรวมจำนวนบรรทัดทั้งหมดของ text frame:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    System.out.println("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    System.out.println("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    System.out.println("Shorter text: " + paragraph.getLinesCount());

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    int totalLineCount = 0;
    for (IParagraph currentParagraph : textFrame.getParagraphs()) {
        totalLineCount += currentParagraph.getLinesCount();
    }
    System.out.println("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

กับข้อความและมิติเหล่านี้ การทำให้ shape แคบลงจะเพิ่มจำนวนบรรทัด ในขณะที่การเปลี่ยนเป็นสตริงสั้นจะลดจำนวนบรรทัด จำนวนที่แท้จริงอาจแตกต่างกันตามฟอนต์ที่มีอยู่และการแทนที่, ขนาดฟอนต์, margin, การเยื้อง, การตัดบรรทัด, และการตั้งค่า Autofit ใช้ฟอนต์และการตั้งค่าการจัดวางที่ใช้ในสภาพแวดล้อมเป้าหมายเมื่อทำการตรวจสอบเท็มเพลต

จำนวนบรรทัดเพียงอย่างเดียวไม่ได้บ่งบอกว่าข้อความล้นจากคอนเทนเนอร์หรือไม่ ความสูงที่ใช้ได้, ความสูงของบรรทัด, ระยะห่างระหว่าง paragraph และบรรทัด, รวมถึงพฤติกรรม Autofit ก็มีผลเช่นกัน; แม้บรรทัดเดียวก็อาจเกินกว่าความกว้างที่มีเมื่อปิดการตัดบรรทัด

## **นำเข้าและส่งออกเนื้อหา Paragraph**

ใช้ HTML เพื่อนำข้อความเข้าสู่งานนำเสนอหรือส่งออก paragraph ที่มีอยู่เพื่อใช้ภายนอก ส่วนนี้ยังแสดงวิธีการแสดงผล paragraph แยกเป็นภาพ รวมถึง paragraph ในเซลล์ตารางด้วย

### **นำเข้า HTML Text ไปยัง Paragraphs**

ใช้เมธอด [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) เพื่อแปลง HTML markup ให้เป็น paragraph และ portion ใน text frame

ตัวอย่าง Java นี้อ่าน HTML จากไฟล์และส่ง markup ไปยัง [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)  มันลบ paragraph เริ่มต้นของ text frame เพื่อให้ frame มีเฉพาะเนื้อหาที่นำเข้า รูปสี่เหลี่ยมเว้น margin 10 pt ทั้งสี่ด้านของสไลด์:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    float shapeWidth = (float) presentation.getSlideSize().getSize().getWidth() - 20;
    float shapeHeight = (float) presentation.getSlideSize().getSize().getHeight() - 20;
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    try {
        byte[] htmlBytes = Files.readAllBytes(Paths.get("file.html"));
        String html = new String(htmlBytes, StandardCharsets.UTF_8);
        shape.getTextFrame().getParagraphs().addFromHtml(html);
        presentation.save("html_text.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("The HTML file could not be read: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **ส่งออกข้อความ Paragraph เป็น HTML**

ใช้เมธอด [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) เพื่อส่งออกช่วง paragraph ที่เลือกเป็น HTML เมื่อใช้ข้อความจากงานนำเสนอบนเว็บไซต์ คุณอาจต้องการเก็บการเน้นแบบท้องถิ่นโดยไม่พกฟอนต์, ขนาด, หรือสไตล์ของ TextBox ไปด้วย ตั้งค่า [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) เพื่อควบคุมความลึกที่ตัวแปลงจะสืบทอดการจัดรูปแบบ

ดาวน์โหลด [ตัวอย่างงานนำเสนอ](text-inheritance.pptx) แล้ววางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกมีรูปข้อความหนึ่งรูปที่มีข้อความ “Inherited text; explicit red 18pt”  อินพุตใช้หลายระดับการจัดรูปแบบโดยเจตนา:

- สไตล์ข้อความเริ่มต้นของงานนำเสนอใช้ Calibri และขนาด 28 pt
- สไตล์ข้อความระดับแรกของ text frame ใช้ข้อความสีน้ำเงินและตัวเอียง
- paragraph ตั้งค่าตัวหนาอย่างชัดเจน
- portion ที่สอง “explicit red 18pt” ตั้งค่าสีแดงและขนาด 18 pt อย่างชัดเจน

ตัวอย่างเต็มด้านล่างส่งออก paragraph เดียวกันสามครั้ง มันส่งค่า [TextToHtmlConversionOptions](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/) ไปยังเมธอดส่งออกและบันทึกแต่ละผลลัพธ์เป็นไฟล์ HTML UTF‑8 แยกไฟล์:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("text-inheritance.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            
            int[] modes = { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };
            String[] fileNames = { "All.html", "TextBox.html", "ParagraphOnly.html" };

            for (int i = 0; i < modes.length; i++) {
                TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                byte[] htmlBytes = html.getBytes(StandardCharsets.UTF_8);
                try {
                    Files.write(Paths.get(fileNames[i]), htmlBytes);
                } catch (IOException exception) {
                    System.out.println("The HTML file could not be written: " + exception.getMessage());
                }
            }
        } else {
            System.out.println("The first shape does not contain a text frame.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

HTML ที่สร้างขึ้นมี CSS ดังต่อไปนี้สำหรับ portion แรก “Inherited text; ” ตารางแสดงการประกาศที่เกี่ยวข้อง; คุณสมบัติที่สร้างเพิ่มเติมถูกละเว้นเพื่อความกระชับ

| Output | Relevant CSS for the first portion | Appearance |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีน้ำเงิน, ตัวหนา, ตัวเอียง ขนาด 28 pt ใน Calibri หากฟอนต์นั้นมี |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีน้ำเงิน, ตัวหนา, ตัวเอียง; หน้าเว็บหรือเบราว์เซอร์จะกำหนดฟอนต์และขนาด |
| `ParagraphOnly.html` | `font-weight:bold` | ตัวหนา; ฟอนต์, ขนาด, สี, และสไตล์เอียงจะมาจากหน้าเว็บหรือเบราว์เซอร์ |

portion ที่สองคง `color:#ff0000`, `font-size:18pt`, และ `font-weight:bold` ในทุกผลลัพธ์ ทั้งยังคงเอียงใน `All` และ `TextBox` แต่ไม่อยู่ใน `ParagraphOnly` การจำกัดการสืบทอดจึงไม่ได้ลบการจัดรูปแบบที่กำหนดโดยตรงให้กับ paragraph หรือ portion

เปิดไฟล์ในเบราว์เซอร์เดียวกันเพื่อเปรียบเทียบ ในสองโหมดที่จำกัด คุณสมบัติ CSS ที่ถูกละเว้นจะถูกกำหนดโดยสไตล์ของหน้าเป้าหมายหรือค่าตั้งต้นของเบราว์เซอร์ ดังนั้นลักษณะที่แสดงผลจะขึ้นกับที่ใช้ HTML

### **สร้าง HTML Clipboard Fragment**

ใช้เมธอด [TextToHtmlConversionOptions.setAddClipboardFragmentHeader](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/#setAddClipboardFragmentHeader-boolean-) เพื่อเลือกผลลัพธ์จาก [IParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-)  หากตั้งค่าเป็น `false` เมธอดจะคืนค่า HTML ปกติ หากตั้งค่าเป็น `true` สตริงที่คืนค่าจะเริ่มด้วยส่วนหัวของคลิปบอร์ด Windows ฟิลด์ `StartHTML` และ `EndHTML` ให้ตำแหน่งไบต์ของ HTML ส่วน `StartFragment` และ `EndFragment` ระบุเนื้อหาที่จะวางลงคลิปบอร์ด

ตัวอย่างนี้ส่งออกสอง paragraph ที่จัดรูปแบบเป็น HTML ธรรมดา (`html`) และเป็น HTML Clipboard Fragment (`clipboardHtml`)  จากนั้นแอปพลิเคชันสามารถเขียน fragment ไปยังคลิปบอร์ดของระบบ หาก API ของคลิปบอร์ดคาดหวังไบต์ดิบ ให้เข้ารหัส fragment เป็น UTF‑8 โดยไม่มี BOM

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 400, 100);
    IParagraphCollection paragraphs = shape.getTextFrame().getParagraphs();
    paragraphs.clear();
    paragraphs.addFromHtml("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>");

    TextToHtmlConversionOptions options = new TextToHtmlConversionOptions();
    options.setAddClipboardFragmentHeader(false);
    String html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);

    options.setAddClipboardFragmentHeader(true);
    String clipboardHtml = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
} finally {
    presentation.dispose();
}
```

### **แสดง Paragraph เป็นรูปภาพ**

เมธอด [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) แสดงผล paragraph เดี่ยวโดยตรงและคืนค่า [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/)  บันทึกผลลัพธ์เป็นไฟล์หรือสตรีมด้วย [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-)  ไม่จำเป็นต้องแสดง shape ทั้งหมดหรือครอบตัด bitmap ด้วยตนเอง

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) อาจคืนค่า `null` หากไม่พบ paragraph ใน collection พ่อแม่, ไม่มีขอบเขตการแสดงผลที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายภาพที่คืนค่าหลังใช้

#### **แสดง Paragraph ที่อัตราส่วนเริ่มต้น**

ตัวอย่างใช้งานนำเสนอหนึ่งสไลด์ที่มี shape แรกเป็น TextBox ที่มีสาม paragraph

![TextBox พร้อมสาม paragraph](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เลือก paragraph ที่สองที่ดัชนี 1 แล้วเรียก [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) โดยไม่ระบุพารามิเตอร์อัตราส่วน  ตรวจสอบว่า shape มี paragraph ที่ต้องการและการเรนเดอร์คืนภาพก่อนเรียก [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) เพื่อบันทึกเป็น PNG  บล็อก `finally` ทำลายภาพหลังใช้

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null && textFrame.getParagraphs().getCount() > 1) {
            IParagraph paragraph = textFrame.getParagraphs().get_Item(1);
            IImage paragraphImage = paragraph.getImage();

            if (paragraphImage != null) {
                try {
                    paragraphImage.save("paragraph.png", ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                System.out.println("The paragraph could not be rendered.");
            }
        } else {
            System.out.println("The expected paragraph was not found.");
        }
    } else {
        System.out.println("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ภาพของ paragraph](paragraph_to_image_output.png)

#### **แสดง Paragraph ในเซลล์ตารางพร้อมการสเกล**

ใช้ overload ของ [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage-float-float-) ที่รับพารามิเตอร์ `float scaleX` และ `float scaleY` เพื่อกำหนดอัตราส่วนแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, แสดง paragraph ในเซลล์แรกด้วยความกว้างและสูงสองเท่าของค่าเริ่มต้น, แล้วบันทึกผลเป็น PNG

```java
import com.aspose.slides.*;

float scaleX = 2f;
float scaleY = 2f;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = slide.getShapes().addTable(50, 50, new double[] { 300 }, new double[] { 80 });
    IParagraph paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    IImage paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage != null) {
        try {
            paragraphImage.save("table_paragraph.png", ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        System.out.println("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

ค่าอัตราส่วน `1` รักษาขนาดพิกเซลเริ่มต้นของแกนนั้น ตัวอย่างเช่น `2` สำหรับทั้งสองอัตราส่วนจะสร้างภาพที่กว้างและสูงประมาณสองเท่าของมิติเริ่มต้น ทำให้จำนวนพิกเซลเพิ่มเป็นสี่เท่า ค่าอัตราส่วนที่ใหญ่กว่าจะให้ข้อความคมชัดขึ้นสำหรับการซูมหรือเอาต์พุตความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ค่าอัตราส่วนต่ำกว่า `1` จะให้ภาพขนาดเล็กลงและรายละเอียดน้อยลง ใช้อัตราส่วนเท่ากันเพื่อคงอัตราส่วนภาพของ paragraph; อัตราส่วนแนวนอนและแนวตั้งที่ต่างกันจะยืดภาพออกอย่างอิสระ

การแสดงภาพของ shape ทั้งหมดด้วย [IShape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getImage--) ยังมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติม, เส้นขอบ, หรือบริบทภาพอื่นของ shape  สำหรับภาพเฉพาะ paragraph ให้ใช้ [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) เท่านั้น

## **FAQ**

**ฉันสามารถปิดการตัดบรรทัดภายใน text frame ได้ทั้งหมดหรือไม่?**

ได้. ตั้งค่า [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) เพื่อปิดการตัดบรรทัดเพื่อให้บรรทัดไม่ตัดที่ขอบของ text frame

**ฉันจะรับขอบเขตบนสไลด์ของ paragraph เฉพาะได้อย่างไร?**

ใช้เมธอด [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getRect--) เพื่อดึงสี่เหลี่ยมขอบของ paragraph  [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getRect--) ให้ขอบเขตของ portion เดี่ยว

**การจัดแนวของ paragraph (ซ้าย, ขวา, กลาง, หรือจัดเต็ม) ถูกควบคุมที่ไหน?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) เป็นการตั้งค่าระดับ paragraph และใช้กับ paragraph ทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของ portion แยกแต่ละอัน

เพื่อจัดแนวแนวตั้งของ portion ที่มีขนาดฟอนต์ต่างกันในแต่ละบรรทัด โปรดดูที่ [Align Fonts Within a Line](/slides/th/java/text-formatting/#align-fonts-within-a-line)

**ฉันสามารถตั้งค่าภาษา proofing สำหรับส่วนหนึ่งของ paragraph ได้หรือไม่?**

ได้. ตั้งค่า [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) สำหรับ portion 個 ละเพื่อให้ paragraph หนึ่งสามารถมีข้อความหลายภาษาได้.