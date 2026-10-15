---
title: "จัดการย่อหน้าข้อความ PowerPoint ใน Java"
linktitle: "จัดการย่อหน้า"
type: docs
weight: 40
url: /th/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
- "เพิ่มข้อความ"
- "เพิ่มย่อหน้า"
- "จัดการข้อความ"
- "จัดการย่อหน้า"
- "จัดการหัวข้อ"
- "เยื้องย่อหน้า"
- "เยื้องห้อย"
- "หัวข้อย่อหน้า"
- "รายการลำดับเลข"
- "รายการหัวข้อ"
- "คุณสมบัติย่อหน้า"
- "นำเข้า HTML"
- "ข้อความเป็น HTML"
- "ย่อหน้าเป็น HTML"
- "ย่อหน้าเป็นภาพ"
- "ข้อความเป็นภาพ"
- "ส่งออกย่อหน้า"
- "PowerPoint"
- "การนำเสนอ"
- "Java"
- "Aspose.Slides"
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, ส่วนข้อความ, bullet, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML และภาพย่อหน้า ด้วย Aspose.Slides for Java."
---
## **ภาพรวม**

Aspose.Slides for Java แสดงข้อความเป็นลำดับชั้นของ text frames, paragraphs และ portions:

* [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) แสดงตัวเก็บข้อความในรูปร่างและให้การเข้าถึงคอลเลกชันของย่อหน้า
* [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) แสดงย่อหน้าเดียวใน text frame และให้การเข้าถึง portions และการจัดรูปแบบระดับย่อหน้า
* [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) แสดงรันข้อความภายในย่อหน้า แต่ละ portion สามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเองได้

ดังนั้น ย่อหน้าจึงสามารถบรรจุข้อความที่มีแบบอักษร, สี, ขนาดและการจัดรูปแบบอื่น ๆ ต่างกันโดยใช้หลาย portion

## **สร้างและจัดรูปแบบย่อหน้า**

สร้างย่อหน้าใน text frame ของรูปร่างและใช้ portion เพื่อจัดรูปแบบรันข้อความแต่ละส่วน ส่วนนี้จะแสดงวิธีรวมหลาย portion ภายในแต่ละย่อหน้าและใช้สี, ขนาดแบบอักษรและสไตล์ที่ต่างกัน

### **สร้างย่อหน้าด้วยหลาย Portion**

ตัวอย่าง Java ต่อไปนี้สร้างย่อหน้า 3 ย่อหน้า แต่ละย่อหน้ามี portion 3 รันข้อความในคอลเลกชันที่ได้จาก [IParagraph.getPortions](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getPortions--) ตัวอย่างนี้ใช้ย่อหน้าเริ่มต้นและ portion เปล่าแล้วเพิ่มย่อหน้าและ portion ที่เหลือ การจัดรูปแบบทำผ่าน [IPortion.getPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getPortionFormat--): portion แรกในแต่ละย่อหน้ามีสีแดง, ตัวหนา และขนาด 15 จุด; portion ที่สองมีสีฟ้า, ตัวเอียง และขนาด 18 จุด; portion ที่สามใช้การจัดรูปแบบเริ่มต้นของมัน:

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

## **สร้างรายการแบบหัวข้อและตัวเลข**

จัดระเบียบข้อความย่อหน้าเป็นรายการที่มีสัญลักษณ์, ตัวเลข หรือรูปภาพที่กำหนดเอง ตัวอย่างในส่วนนี้ครอบคลุมการจัดรูปแบบหัวข้อ, รายการหลายระดับ, และการกำหนดหมายเลขเริ่มต้นแบบกำหนดเอง

### **สร้างรายการแบบหัวข้อหรือเลขลำดับ**

หัวข้อและการจัดลำดับทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการกำหนดผ่าน [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/)

ตัวอย่าง Java นี้เพิ่มหัวข้อสัญลักษณ์และรายการเลขลำดับใน text frame เดียวกัน [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) เลือกประเภทหัวข้อ, ในขณะที่ [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) ระบุสัญลักษณ์และ [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) เลือกสไตล์การจัดลำดับ ทั้งสองรายการใช้หัวข้อสีดำที่สูง 100 % และการเยื้องย่อหน้า 25 จุด:

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

### **ใช้หัวข้อรูปภาพ**

หัวข้อรูปภาพให้คุณใช้รูปภาพกำหนดเองแทนสัญลักษณ์หรือเลข

ตัวอย่าง Java นี้เพิ่มรูปภาพลงในคอลเลกชันรูปของงานพรีเซนเทชันในฐานะ [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) และใช้เป็นหัวข้อย่อหน้า มันเรียก [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) เพื่อใช้หัวข้อรูปภาพและกำหนดรูปภาพผ่าน [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--) [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) ตั้งค่าเป็น 100 % เพื่อกำหนดขนาดหัวข้อสัมพันธ์กับข้อความย่อหน้า:

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

### **สร้างรายการหลายระดับ**

ตั้งค่า [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมี depth เป็น `0`

ตัวอย่าง Java นี้กำหนดค่า [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) ตั้งแต่ 0 ถึง 3 ให้กับย่อหน้า 4 ย่อหน้า สร้างลำดับชั้นภายใน text frame เดียวกัน แต่ละย่อหน้าใช้หัวข้อสัญลักษณ์ โดย [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-) สลับระหว่างหัวข้อกลมและเครื่องหมายขีดเพื่อแยกระดับที่ใกล้เคียง:

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

### **กำหนดค่าเริ่มต้นของรายการเลขลำดับเป็นค่ากำหนดเอง**

ใช้ [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เพื่อตั้งค่าตัวเลขเริ่มต้นที่แสดงสำหรับย่อหน้าเลขลำดับ

ตัวอย่าง Java นี้ตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) ให้ใช้การจัดลำดับกับย่อหน้า 3 ย่อหน้าและกำหนดค่า [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เป็น 2, 3 และ 7 ค่าการเริ่มต้นนี้กำหนดแยกกันสำหรับแต่ละย่อหน้า ทำให้เลขที่แสดงข้ามค่าได้:

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

## **ควบคุมการจัดวางย่อหน้าและคุณสมบัติ End**

ปรับระยะขอบและการเยื้องของย่อหน้าเพื่อควบคุมตำแหน่งบรรทัดแรกและบรรทัดที่พันกัน คุณยังสามารถจัดรูปแบบเครื่องหมายสิ้นสุดของย่อหน้าแยกจากส่วนข้อความที่มองเห็นได้

### **ตั้งค่าเยื้องบรรทัดแรก**

ใช้เมธอด [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) เพื่อควบคุมเยื้องบรรทัดแรกของย่อหน้า การตั้งค่านี้จะย้ายบรรทัดแรกเท่านั้นสัมพันธ์กับระยะขอบซ้ายของย่อหน้า ค่าเป็นบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือยังคงจัดชิดกับเนื้อหาย่อหน้า

ใช้ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ใช้ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างต่อไปนี้ให้ย่อหน้า 3 ย่อหน้ามี [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) เป็น 20 จุดและ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) เป็น 0, 20, และ 40 จุด บรรทัดแรกเริ่มที่ช่องว่างที่เพิ่มขึ้นเรื่อย ๆ ขณะที่บรรทัดที่พันกันยังคงระยะขอบซ้ายเท่าเดิม:

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

![การเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งค่าเยื้องแบบ Hanging**

เยื้องแบบ Hanging คือการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ทางซือของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยคุณสมบัติ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) ตั้งค่า `Indent` เป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายสัมพันธ์กับเนื้อหาย่อหน้า

ในการปฏิบัติ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) กำหนดตำแหน่งของบรรทัดแรกสัมพันธ์กับระยะขอบนั้น เพื่อสร้างเยื้องแบบ Hanging ให้ตั้งค่า `MarginLeft` เป็นบวกและ `Indent` เป็นลบ

การจัดรูปแบบนี้เป็นประโยชน์สำหรับบรรณานุกรม, เอกสารอ้างอิง, รายการสารานุกรมและย่อหน้าอื่น ๆ ที่บรรทัดที่พันต้องจัดชิดใต้เนื้อหาย่อหน้าแทนบรรทัดแรก

ตัวอย่าง Java ต่อไปนี้จับคู่ค่า [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) เป็น 40 และ 60 จุด กับค่า [IParagraphFormat.setIndent](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setIndent-float-) เป็น -20 และ -30 จุด ในแต่ละย่อหน้า บรรทัดแรกเริ่มอยู่ซ้ายของบรรทัดที่พัน; ย่อหน้าที่สองมีการเยื้อง Hanging ลึกกว่า:

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

![การเยื้องแบบ Hanging ของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติ Run ของ End Paragraph**

เมธอด [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) ควบคุมการจัดรูปแบบของเครื่องหมายสิ้นสุดย่อหน้า ตัวอย่างต่อไปนี้สร้าง [PortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/portionformat/) ด้วย [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) ตั้งเป็น 48 จุดและ [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) ตั้งเป็น Times New Roman จากนั้นกำหนดรูปแบบนี้ให้กับเครื่องหมายสิ้นสุดของย่อหน้าที่สองโดยไม่กระทบต่อ portion ที่มองเห็นได้:

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

สำหรับกฎของย่อหน้าที่มีผลต่อการพันอัตโนมัติและเครื่องหมายวรรคตอนที่บรรทัดสุดท้าย ดูที่ [Control Line Breaking](/slides/th/java/text-formatting/#control-line-breaking) และ [Control Hanging Punctuation](/slides/th/java/text-formatting/#control-hanging-punctuation)

ใช้ [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) เพื่อนับจำนวนบรรทัดที่ย่อใช้หลังจากการจัดรูปแบบข้อความ รวมถึงการพันอัตโนมัติ ซึ่งมีประโยชน์เมื่อทำการตรวจสอบความยาวและการจัดวางข้อความในเทมเพลตพรีเซนเทชัน

ย่อหน้าเป็นรายการหนึ่งใน [ITextFrame.getParagraphs](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParagraphs--) และอาจครอบคลุมหลายบรรทัดที่แสดงผล การเจาะบรรทัดใหม่ภายในย่อหน้าจะบังคับให้สร้างบรรทัดใหม่โดยไม่ต้องสร้างย่อหน้าใหม่ การพันอัตโนมัติสร้างบรรทัดตามความกว้างที่มีโดยไม่แทรกการเจาะบรรทัดลงในข้อความ ดังนั้นการนับย่อหน้า หรืออักขระเจาะบรรทัดไม่ได้ให้จำนวนบรรทัดที่แสดงผล

ตัวอย่างต่อไปนี้สร้างรูปทรงข้อความ, นับบรรทัด, ลดความกว้างของรูปทรง, แล้วแทนที่ข้อความด้วยสตริงสั้นลง ตัวอย่างเปิดใช้งานการพันด้วย [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) และปิดการทำออโต้ฟิตด้วย [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) เพื่อให้ความกว้างของรูปทรงควบคุมการพันโดยไม่ให้ข้อความหรือรูปทรงย่ออัตโนมัติ การวัดแต่ละครั้งใช้ [IParagraph.getLinesCount](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getLinesCount--) มิติสภาพอยู่ในหน่วยจุด สุดท้าย ตัวอย่างเพิ่มย่อหน้าอีกหนึ่งย่อหน้าและรวมจำนวนบรรทัดทั้งหมดของ text frame:

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

เมื่อใช้ข้อความและมิติที่ระบุ การทำให้รูปทรงเจียรลงจะเพิ่มจำนวนบรรทัด ในขณะที่การแทนที่ข้อความด้วยสตริงสั้นจะลดจำนวนบรรทัด จำนวนที่แน่นอนอาจแตกต่างตามความพร้อมใช้งานของแบบอักษรและการทดแทน, ขนาดแบบอักษร, ระยะขอบ, การเยื้อง, การพันและการตั้งค่าออโต้ฟิต ใช้แบบอักษรและการตั้งค่าการจัดวางที่ตั้งใจสำหรับสภาพแวดล้อมเป้าหมายเมื่อทำการตรวจสอบเทมเพลต

จำนวนบรรทัดเพียงอย่างเดียวไม่ได้บ่งบอกว่าข้อความล้นพื้นที่หรือไม่ ความสูงที่ใช้ได้, ความสูงบรรทัด, ระยะห่างระหว่างย่อหน้าและบรรทัด, และพฤติกรรมออโต้ฟิตก็มีความสำคัญ; แม้แต่บรรทัดเดียวอาจเกินความกว้างที่มีเมื่อปิดการพัน

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

ใช้ HTML เพื่อนำข้อความเข้าสู่พรีเซนเทชันหรือส่งออกย่อหน้าที่มีอยู่เพื่อใช้ภายนอก ส่วนนี้ยังแสดงวิธีเรนเดอร์ย่อหน้าเดียวเป็นรูปภาพ รวมถึงย่อหน้าในเซลล์ตาราง

### **นำเข้า HTML เข้าในย่อหน้า**

ใช้ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) เพื่อแปลง markup HTML ให้เป็นย่อหน้าและ portion ใน text frame

ตัวอย่าง Java นี้อ่าน HTML จากไฟล์และส่ง markup ให้กับ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) มันลบย่อหน้าเริ่มต้นของ text frame เพื่อให้เฟรมมีเฉพาะเนื้อหาที่นำเข้า รูปร่างสี่เหลี่ยมทำให้มีระยะขอบ 10 จุดทุกด้านของสไลด์:

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

### **ส่งออกข้อความย่อหน้าเป็น HTML**

ใช้ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML เมื่อทำการใช้ข้อความพรีเซนเทชันบนเว็บไซต์ คุณอาจต้องการรักษาการเน้นแบบท้องถิ่นโดยไม่ต้องพ่วงแบบอักษร, ขนาด หรือสไตล์ของกล่องข้อความตั้งค่า [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) เพื่อควบคุมระยะทางที่ตัวส่งออกตามการสืบทอดรูปแบบ

ดาวน์โหลด [ตัวอย่างพรีเซนเทชัน](text-inheritance.pptx) แล้ววางไว้ในโฟลเดอร์ทำงานของแอปพลิเคชัน สไลด์แรกมีรูปทรงข้อความหนึ่งรูปพร้อมข้อความ “Inherited text; explicit red 18pt” อินพุตตั้งค่าแบบฟอร์มหลายระดับโดยเจตนา:

- สไตล์ข้อความเริ่มต้นของพรีเซนเทชันกำหนดฟอนต์ Calibri ขนาด 28 pt
- สไตล์ข้อความระดับแรกของ text frame กำหนดข้อความสีน้ำเงินและอักษรเอียง
- ย่อหน้ากำหนดข้อความตัวหนาอย่างชัดเจน
- Portion ที่สอง “explicit red 18pt” กำหนดข้อความสีแดงและขนาด 18 pt อย่างชัดเจน

ตัวอย่างเต็มต่อไปนี้ส่งออกย่อหน้าเดียวกันสามครั้ง มันส่งค่า [TextToHtmlConversionOptions](https://reference.aspose.com/slides/java/com.aspose.slides/texttohtmlconversionoptions/) ให้กับเมธอดส่งออกและเขียนแต่ละผลลัพธ์เป็นไฟล์ HTML UTF‑8 แยกไฟล์:

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

HTML ที่สร้างขึ้นมี CSS ต่อไปนี้สำหรับ Portion แรก “Inherited text; ” ตารางแสดงการประกาศที่เกี่ยวข้อง; คุณสมบัติที่สร้างอื่น ๆ ถูกละเว้นเพื่อความกระจ่าง

| ผลลัพธ์ | CSS ที่เกี่ยวข้องสำหรับ Portion แรก | ลักษณะ |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีน้ำเงิน, ตัวหนา, อักษรเอียง ขนาด 28 pt ใน Calibri หากฟอนต์นั้นพร้อมใช้งาน |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีน้ำเงิน, ตัวหนา, อักษรเอียง; หน้าเว็บหรือเบราว์เซอร์จะกำหนดฟอนต์และขนาด |
| `ParagraphOnly.html` | `font-weight:bold` | ข้อความตัวหนา; หน้าเว็บหรือเบราว์เซอร์จะกำหนดฟอนต์, ขนาด, สีและสไตล์อักษรเอียง |

Portion ที่สองยังคงมี `color:#ff0000`, `font-size:18pt` และ `font-weight:bold` ทั้งสามผลลัพธ์ ทั้งยังคงอักษรเอียงใน `All` และ `TextBox` แต่ไม่ใน `ParagraphOnly` การจำกัดการสืบทอดจึงไม่ลบรูปแบบที่กำหนดโดยตรงให้กับย่อหน้าหรือ portion

เปิดไฟล์ในเบราว์เซอร์เดียวกันเพื่อเปรียบเทียบ ในโหมดที่จำกัด CSS ที่ถูกละเว้นจะถูกใช้โดยสไตล์ของหน้าปลายทางหรือค่าเริ่มต้นของเบราว์เซอร์ ดังนั้นลักษณะที่แสดงผลจะขึ้นกับที่นำ HTML ไปใช้

### **เรนเดอร์ย่อหน้าเป็นรูปภาพ**

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) เรนเดอร์ย่อหน้าเดี่ยวโดยตรงและคืนค่า [IImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/) บันทึกผลลัพธ์เป็นไฟล์หรือสตรีมด้วย [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) ไม่จำเป็นต้องเรนเดอร์รูปร่างที่บรรจุหรือทำการครอบตัดบิตแมปด้วยตนเอง

[IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) อาจคืนค่า `null` หากไม่พบย่อหน้าในคอลเลกชันพ่อ, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายภาพที่คืนค่าหลังการใช้

#### **เรนเดอร์ย่อหน้าในสเกลค่าเริ่มต้น**

ตัวอย่างใช้พรีเซนเทชันที่มีสไลด์หนึ่งสไลด์แรกมีรูปร่างข้อความที่บรรจุย่อหน้า 3 ย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เลือกย่อหน้าที่สองที่ดัชนี 1 แล้วเรียก [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) โดยไม่ระบุตัวแปรสเกล มันตรวจสอบว่ารูปร่างมีย่อหน้าที่ต้องการและการเรนเดอร์ได้ภาพก่อนเรียก [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) เพื่อบันทึกเป็น PNG ส่วน `finally` ทำลายภาพหลังการใช้

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

![ภาพย่อหน้า](paragraph_to_image_output.png)

#### **เรนเดอร์ย่อหน้าในเซลล์ตารางพร้อมสเกล**

ใช้เมธอด overload ของ [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage-float-float-) ที่รับพารามิเตอร์ `float scaleX` และ `float scaleY` เพื่อกำหนดอัตราส่วนสเกลแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, เรนเดอร์ย่อหน้าในเซลล์แรกที่สเกลกว้างและสูงเป็นสองเท่าของค่าเริ่มต้น, และบันทึกผลเป็น PNG

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

อัตราส่วนสเกล `1` ทำให้แกนนั้นคงขนาดพิกเซลเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองอัตราส่วนจะให้ภาพที่กว้างและสูงประมาณสองเท่าของมิติเริ่มต้น ทำให้พิกเซลเพิ่มเป็นสี่เท่า อัตราส่วนที่ใหญ่กว่ามักให้ข้อความคมชัดมากขึ้นสำหรับการซูมหรือเอาต์พุตความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ อัตราส่วนต่ำกว่า `1` จะให้ภาพเล็กลงและรายละเอียดน้อยลง ใช้อัตราส่วนเท่ากันเพื่อรักษาอัตราส่วนภาพของย่อหน้า; อัตราส่วนที่ต่างกันระหว่างแนวนอนและแนวตั้งจะยืดรูปภาพแยกกัน

การเรนเดอร์รูปทรงทั้งหมดด้วย [IShape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getImage--) ยังคงมีประโยชน์เมื่อต้องการรวมการเติมสี, เส้นขอบ หรือบริบทภาพอื่นของรูปทรง สำหรับภาพที่มีเฉพาะย่อหน้า ใช้ [IParagraph.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getImage--) แทน

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการพันบรรทัดภายใน text frame ได้ทั้งหมดหรือไม่?**

ได้. ตั้งค่า [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) เพื่อปิดการพันบรรทัดให้บรรทัดไม่แตกที่ขอบของ text frame

**ฉันจะรับขอบเขตบนสไลด์ของย่อหน้าเฉพาะได้อย่างไร?**

ใช้ [IParagraph.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getRect--) เพื่อดึงสี่เหลี่ยมขอบของย่อหน้า [IPortion.getRect](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/#getRect--) ให้ขอบของ portion แยกแต่ละส่วน

**การจัดแนวของย่อหน้า (ซ้าย, ขวา, จัดกึ่งกลาง, หรือเติมเต็ม) ถูกควบคุมที่ไหน?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) เป็นการตั้งค่าระดับย่อหน้าและใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของ portion แยกต่างหาก

เพื่อจัดแนวแนวตั้งของ portion ที่มีขนาดฟอนต์ต่างกันในแต่ละบรรทัด ให้ดูที่ [Align Fonts Within a Line](/slides/th/java/text-formatting/#align-fonts-within-a-line)

**ฉันสามารถตั้งค่าภาษา proofing สำหรับส่วนหนึ่งของย่อหน้าได้หรือไม่?**

ได้. ตั้งค่า [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) สำหรับ portion แยกต่างหาก เพื่อให้ย่อหน้าหนึ่งสามารถมีข้อความหลายภาษาต่างกันได้