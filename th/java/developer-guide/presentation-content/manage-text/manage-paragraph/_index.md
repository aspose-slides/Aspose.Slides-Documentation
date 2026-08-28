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
- จัดการสัญลักษณ์หัวข้อ
- เยื้องย่อหน้า
- เยื้องห้อย
- สัญลักษณ์หัวข้อย่อหน้า
- รายการลำดับเลข
- รายการสัญลักษณ์หัวข้อ
- คุณสมบัติย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- งานนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า ส่วน สัญลักษณ์หัวข้อ รายการลำดับเลข การเยื้อน เนื้อหา HTML และภาพย่อหน้าด้วย Aspose.Slides for Java."
---
## **ภาพรวม**

Aspose.Slides for Java แสดงข้อความเป็นลำดับขั้นของกรอบข้อความ, ย่อหน้า, และส่วน:

* [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) เป็นตัวบรรจุข้อความในรูปทรงและให้การเข้าถึงคอลเลกชันของย่อหน้า.
* [IParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/) เป็นย่อหน้าเดียวในกรอบข้อความและให้การเข้าถึงส่วนต่าง ๆ และการฟอร์แมตในระดับย่อหน้า.
* [IPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/) เป็นรันข้อความภายในย่อหน้า แต่ละส่วนสามารถมีข้อความของตนเองและการฟอร์แมตระดับอักขระ.

ดังนั้น ย่อหน้าสามารถมีข้อความที่ใช้ฟอนต์, สี, ขนาด, และการฟอร์แมตอื่น ๆ ที่แตกต่างกันโดยใช้หลายส่วน.

## **สร้างและจัดรูปแบบย่อหน้า**

### **สร้างย่อหน้าด้วยหลายส่วน**

ขั้นตอนต่อไปนี้สร้างกรอบข้อความที่มีสามย่อหน้า, แต่ละย่อหน้ามีสามส่วน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/).
2. เข้าถึงสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน.
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) รูปสี่เหลี่ยมให้กับสไลด์.
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของรูปทรง.
5. ใช้ย่อหน้าเริ่มต้นและเพิ่มวัตถุ [IParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/) อีกสองรายการลงในกรอบข้อความ.
6. เพิ่มวัตถุ [IPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/) จำนวนที่เพียงพอให้แต่ละย่อหน้ามีสามส่วน ย่อหน้าเริ่มต้นมีส่วนว่างอยู่แล้วหนึ่งส่วน.
7. ตั้งค่าข้อความของแต่ละส่วน.
8. ใช้การฟอร์แมตระดับอักขระผ่าน [IPortion.getPortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/#getPortionFormat--).
9. บันทึกการพรีเซนเทชันที่แก้ไขแล้ว.

This Java example implements the steps:

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

## **สร้างรายการแบบมีสัญลักษณ์และตัวเลข**

### **สร้างรายการแบบมีสัญลักษณ์หรือหมายเลข**

สัญลักษณ์และการนับเลขทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการถูกกำหนดผ่าน [IBulletFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/).

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/).
2. เข้าถึงสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน.
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ไปยังสไลด์ที่เลือก.
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของรูปทรง.
5. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ.
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/) สำหรับสัญลักษณ์หัวข้อ.
7. ตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setType-int-) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/th/java/com.aspose.slides/bullettype/) และระบุอักขระสัญลักษณ์หัวข้อ.
8. ตั้งค่าข้อความของย่อหน้า, การเยื้อง, สีของสัญลักษณ์หัวข้อ, และความสูงของสัญลักษณ์หัวข้อ.
9. เพิ่มย่อหน้านี้ลงในกรอบข้อความ.
10. สร้างย่อหน้าที่สองและตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setType-int-) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/th/java/com.aspose.slides/bullettype/).
11. กำหนดสไตล์ของสัญลักษณ์หัวข้อแบบนับเลขและเพิ่มย่อหน้านี้ลงในกรอบข้อความ.
12. บันทึกพรีเซนเทชัน.

This Java example creates a symbol bullet and a numbered bullet:

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

### **ใช้สัญลักษณ์หัวข้อแบบรูปภาพ**

สัญลักษณ์หัวข้อแบบรูปภาพให้คุณใช้รูปภาพกำหนดเองแทนสัญลักษณ์หรือเลข.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/).
2. เข้าถึงสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน.
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) และเข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/).
4. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ.
5. โหลดรูปภาพสัญลักษณ์หัวข้อและเพิ่มเข้าไปในคอลเลกชันภาพของพรีเซนเทชันเป็น [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/).
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/) และตั้งค่าข้อความของมัน.
7. ตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setType-int-) เป็น [BulletType.Picture](https://reference.aspose.com/slides/th/java/com.aspose.slides/bullettype/).
8. กำหนดรูปภาพผ่าน [IBulletFormat.getPicture](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#getPicture--) และตั้งค่าความสูงของสัญลักษณ์หัวข้อ.
9. เพิ่มย่อหน้านี้ลงในกรอบข้อความ.
10. บันทึกการพรีเซนเทชันที่แก้ไขแล้ว.

This Java example creates a picture bullet:

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

ตั้งค่า [IParagraphFormat.setDepth](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setDepth-short-) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึกเป็น `0`.

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และเข้าถึงสไลด์.
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) และลบย่อหน้าเริ่มต้นจากกรอบข้อความของมัน.
3. สร้างสี่ย่อหน้าและกำหนดสัญลักษณ์หัวข้อให้แต่ละย่อหน้า.
4. ตั้งค่าความลึกของพวกมันด้วย [IParagraphFormat.setDepth](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setDepth-short-) เป็น `0`, `1`, `2` และ `3`.
5. เพิ่มย่อหน้าเหล่านั้นลงในกรอบข้อความและบันทึกพรีเซนเทชัน.

This Java example creates a four-level bulleted list:

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

### **เริ่มรายการนับเลขด้วยค่าที่กำหนดเอง**

ใช้ [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เพื่อกำหนดหมายเลขเริ่มต้นที่จะแสดงสำหรับย่อหน้าที่นับเลข.

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และเพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ไปยังสไลด์.
2. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของรูปทรง.
3. สร้างย่อหน้าแบบนับเลขสามรายการ.
4. ตั้งค่า [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เป็น `2`, `3` และ `7` สำหรับย่อหน้าแต่ละรายการ.
5. เพิ่มย่อหน้าเหล่านั้นลงในกรอบข้อความและบันทึกพรีเซนเทชัน.

This Java example assigns a custom starting number to each paragraph:

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

## **ควบคุมรูปแบบย่อหน้าและคุณสมบัติส่วนท้าย**

### **ตั้งการเยื้องบรรทัดแรก**

ใช้ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า วิธีนี้จะย้ายเฉพาะบรรทัดแรกสัมพันธ์กับขอบซ้ายของย่อหน้า ค่าบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือยังคงจัดแนวกับเนื้อหาย่อหน้า

ใช้ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ใช้ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างด้านล่างสร้างย่อหน้าหลายรายการและกำหนดค่า [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) ที่ต่างกันเพื่อแสดงว่าการเยื้องบรรทัดแรกมีผลต่อการจัดวางย่อหน้าอย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/).
2. เข้าถึงสไลด์เป้าหมาย.
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) รูปสี่เหลี่ยมให้กับสไลด์.
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น.
5. สร้างย่อหน้าหลายรายการและกำหนดค่า [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) ที่ต่างกันสำหรับแต่ละย่อหน้า.
6. เพิ่มย่อหน้าเหล่านั้นลงในกรอบข้อความ.
7. บันทึกการพรีเซนเทชันที่แก้ไขแล้ว.

This code shows you how to set a paragraph indent:

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

The result:

![การเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งการเยื้องห้อย**

การเยื้องห้อยคือรูปแบบย่อหน้าที่บรรทัดแรกเริ่มอยู่ด้านซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วย [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-). ให้ค่าติดลบเพื่อย้ายบรรทัดแรกไปทางซ้ายสัมพันธ์กับเนื้อหาย่อหน้า

โดยปกติ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า, และ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) กำหนดตำแหน่งของบรรทัดแรกสัมพันธ์กับขอบซ้ายนั้น เพื่อสร้างการเยื้องห้อย ให้ใส่ค่าบวกใน `setMarginLeft` และค่าลบใน `setIndent`.

การฟอร์แมตนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการอภิธานศัพท์, และย่อหน้าอื่น ๆ ที่บรรทัดที่บรรจบต้องจัดแนวอยู่ใต้เนื้อหาย่อหน้าแทนที่จะอยู่ใต้ตัวอักษรแรกของบรรทัดแรก.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/).
2. เข้าถึงสไลด์เป้าหมาย.
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) รูปสี่เหลี่ยมให้กับสไลด์.
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น.
5. สร้างย่อหน้าและใส่ค่าบวกใน [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) สำหรับแต่ละย่อหน้า.
6. ใส่ค่าลบใน [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) เพื่อสร้างเอฟเฟกต์การเยื้องห้อย.
7. เพิ่มย่อหน้าเหล่านั้นลงในกรอบข้อความ.
8. บันทึกการพรีเซนเทชันที่แก้ไขแล้ว.

This code shows you how to set a hanging indent for a paragraph:

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

The result:

![การเยื้องห้อยของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติการทำงานของย่อหน้าสุดท้าย**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) ควบคุมการฟอร์แมตของเครื่องหมายจบบรรทัดของย่อหน้า ตัวอย่างต่อไปนี้กำหนดขนาดฟอนต์และฟอนต์ลาตินให้กับเครื่องหมายจบบรรทัดของย่อหน้าที่สอง:

1. โหลด [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และเข้าถึงสไลด์.
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) และลบย่อหน้าเริ่มต้นของมัน.
3. สร้างสองย่อหน้าและเพิ่มส่วนข้อความให้กับแต่ละย่อหน้า.
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/portionformat/) สำหรับเครื่องหมายจบบรรทัดของย่อหน้าที่สอง.
5. ตั้งค่า [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) และ [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-).
6. กำหนดฟอร์แมตด้วย [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) แล้วบันทึกพรีเซนเทชัน.

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

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

### **นำเข้า HTML ลงในย่อหน้า**

ใช้ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) เพื่อแปลงมาร์คอัป HTML ให้เป็นย่อหน้าและส่วนในกรอบข้อความ.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/).
2. เข้าถึงสไลด์และเพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/).
3. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น.
4. อ่านไฟล์ HTML ต้นทาง.
5. ส่งสตริง HTML ไปยัง [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-).
6. บันทึกการพรีเซนเทชันที่แก้ไขแล้ว.

This Java example imports HTML into a text frame:

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

ใช้ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และโหลดพรีเซนเทชันที่ต้องการ.
2. เข้าถึงสไลด์และค้นหา [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ที่มีข้อความ.
3. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของรูปทรง.
4. เรียก [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) พร้อมดัชนีย่อหน้าเริ่มต้นและจำนวนย่อหน้าที่ต้องการส่งออก.
5. เขียนสตริง HTML ที่ได้ลงไฟล์.

This Java example exports all paragraphs from the first text shape:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("ExportingHTMLText.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (shape instanceof IAutoShape) {
        IAutoShape textShape = (IAutoShape) shape;
        ITextFrame textFrame = textShape.getTextFrame();
        if (textFrame != null) {
            IParagraphCollection paragraphs = textFrame.getParagraphs();
            String html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            try {
                Files.write(Paths.get("paragraphs.html"), html.getBytes(StandardCharsets.UTF_8));
            } catch (IOException exception) {
                System.out.println("The HTML file could not be written: " + exception.getMessage());
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

### **แสดงย่อหน้าเป็นภาพ**

[IParagraph.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/#getImage--) แสดงย่อหน้าเดี่ยวโดยตรงและคืนค่าเป็น [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/). บันทึกผลลัพธ์ลงไฟล์หรือสตรีมด้วย [IImage.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/#save-java.lang.String-int-). คุณไม่จำเป็นต้องเรนเดอร์รูปทรงที่บรรจุหรือครอบตัดบิทแมพด้วยตนเอง.

[IParagraph.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/#getImage--) อาจคืนค่า `null` หากไม่พบย่อหน้าในคอลเลกชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายภาพที่คืนค่าหลังการใช้งาน.

#### **แสดงย่อหน้าโดยสเกลเริ่มต้น**

สมมติว่าเรามีพรีเซนเทชันไฟล์ชื่อ sample.pptx ที่มีสไลด์เดียว, โดยรูปทรงแรกเป็นกล่องข้อความที่มีสามย่อหน้า.

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้แสดงย่อหน้าที่สองในรูปทรงข้อความปกติที่สเกลเริ่มต้นและบันทึกภาพที่ได้ในรูปแบบ PNG. บล็อก `finally` ทำให้แน่ใจว่าภาพถูกทำลายอย่างถูกต้อง.

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

The result:

![ภาพของย่อหน้า](paragraph_to_image_output.png)

#### **แสดงย่อหน้าในเซลล์ตารางพร้อมการสเกล**

ใช้ overload ของ [IParagraph.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/#getImage-float-float-) ที่รับพารามิเตอร์ `float scaleX` และ `float scaleY` เพื่อกำหนดปัจจัยสเกลแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, แสดงย่อหน้าในเซลล์แรกด้วยความกว้างและความสูงเป็นสองเท่าของค่าเริ่มต้น, แล้วบันทึกผลเป็นภาพ PNG.

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

ปัจจัยสเกลค่า `1` จะคงขนาดพิกเซลเริ่มต้นของแกนนั้น ๆ ตัวอย่างเช่น `2` สำหรับทั้งสองแกนจะทำให้ความกว้างและความสูงของภาพประมาณสองเท่าของมิติเริ่มต้น, ทำให้จำนวนพิกเซลเพิ่มเป็นสี่เท่า ปัจจัยที่ใหญ่ขึ้นมักให้ข้อความคมชัดขึ้นสำหรับการซูมหรือการส่งออกความละเอียดสูง, แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ปัจจัยน้อยกว่า `1` จะทำให้ภาพเล็กลงและรายละเอียดน้อยลง ใช้ปัจจัยเท่ากันเพื่อรักษาอัตราส่วนของย่อหน้า; ปัจจัยแนวนอนและแนวตั้งที่ต่างกันจะยืดผลลัพธ์แยกกัน.

การเรนเดอร์รูปทรงทั้งหมดด้วย [IShape.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getImage--) ยังคงมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติมสี, ขอบ, หรือบริบทภาพอื่นของรูปทรง สำหรับภาพเฉพาะย่อหน้าให้ใช้ [IParagraph.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/#getImage--).

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดภายในกรอบข้อความได้อย่างสมบูรณ์หรือไม่?**

ใช่. ตั้งค่า [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) เพื่อปิดการตัดบรรทัด so lines do not break at the text frame's edges.

**ฉันจะได้ขอบเขตบนสไลด์ที่แม่นยำของย่อหน้าที่ระบุได้อย่างไร?**

ใช้ [IParagraph.getRect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/#getRect--) เพื่อดึงสี่เหลี่ยมขอบของย่อหน้า. [IPortion.getRect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/#getRect--) ให้ขอบเขตของส่วนเดี่ยว.

**การจัดแนวของย่อหน้า (ซ้าย, ขวา, กลางหรือเต็ม) ถูกควบคุมที่ไหน?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) เป็นการตั้งค่าระดับย่อหน้าและใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงฟอร์แมตของส่วนแต่ละส่วน.

**ฉันสามารถตั้งค่าภาษา proofing สำหรับส่วนของย่อหน้าได้หรือไม่?**

ได้. ตั้งค่า [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) สำหรับแต่ละส่วน, เพื่อให้ย่อหน้าเดียวสามารถมีข้อความหลายภาษา.