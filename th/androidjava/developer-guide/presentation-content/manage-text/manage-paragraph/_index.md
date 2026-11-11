---
title: จัดการย่อข้อความ PowerPoint บน Android
linktitle: จัดการย่อหน้า
type: docs
weight: 40
url: /th/androidjava/manage-paragraph/
aliases:
  - /androidjava/paragraph/
  - /androidjava/portion/
keywords:
- เพิ่มข้อความ
- เพิ่มย่อหน้า
- จัดการข้อความ
- จัดการย่อหน้า
- จัดการจุดรายการ
- ระยะเยื้องย่อหน้า
- ระยะเยื้องห้อย
- จุดรายการย่อหน้า
- รายการเลขลำดับ
- รายการจุด
- คุณสมบัติกย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- การพรีเซนเทชัน
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, ส่วน, จุดรายการ, รายการเลขลำดับ, ระยะเยื้อน, เนื้อหา HTML, และภาพย่อหน้าด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides สำหรับ Android ผ่าน Java แสดงข้อความเป็นลำดับชั้นของกรอบข้อความ ย่อหน้า และส่วน:

* [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) แสดงคอนเทนเนอร์ข้อความในรูปและให้การเข้าถึงคอลเลคชันของย่อหน้า
* [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) แทนย่อหน้าเดียวในกรอบข้อความและให้การเข้าถึงส่วนต่าง ๆ และการจัดรูปแบบระดับย่อหน้า
* [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) แทนการวิ่งของข้อความภายในย่อหน้า แต่ละส่วนสามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเองได้

ดังนั้นย่อหน้าจึงสามารถมีข้อความที่มีแบบอักษร สี ขนาด และการจัดรูปแบบอื่น ๆ ที่แตกต่างกันโดยใช้หลายส่วน

## **สร้างและจัดรูปแบบย่อหน้า**

สร้างย่อหน้าในกรอบข้อความของรูปและใช้ส่วนเพื่อจัดรูปแบบการวิ่งของข้อความแต่ละส่วน ส่วนนี้แสดงวิธีการรวมหลายส่วนในแต่ละย่อหน้าและใช้สี ขนาดแบบอักษร และสไตล์ที่แตกต่างกัน

### **สร้างย่อหน้าด้วยหลายส่วน**

ตัวอย่าง Android ผ่าน Java ต่อไปนี้สร้างย่อหน้า 3 ย่อหน้า โดยแต่ละย่อหน้ามีการวิ่งของข้อความ 3 ครั้งในคอลเลคชันที่คืนค่าโดย [IParagraph.getPortions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getPortions--). ตัวอย่างนี้ใช้ย่อหน้าเริ่มต้นและส่วนเปล่าของมันซ้ำแล้วเพิ่มย่อหน้าและส่วนที่เหลือ การจัดรูปแบบทำผ่าน [IPortion.getPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getPortionFormat--): ส่วนแรกในแต่ละย่อหนาสีแดง ตัวหนา และขนาด 15 จุด; ส่วนที่สองสีน้ำเงิน ตัวเอียง และขนาด 18 จุด; ส่วนที่สามคงการจัดรูปแบบเริ่มต้นไว้:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **สร้างรายการแบบมีจุดและเลขลำดับ**

จัดระเบียบข้อความในย่อหน้าเป็นรายการด้วยสัญลักษณ์ ตัวเลข หรือรูปภาพแบบกำหนดเอง ตัวอย่างในส่วนนี้ครอบคลุมการจัดรูปแบบจุดรายการ รายการหลายระดับ และการกำหนดเลขเริ่มต้นแบบกำหนดเอง

### **สร้างรายการแบบมีจุดหรือเลขลำดับ**

จุดรายการและการลำดับหมายเลขทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการกำหนดโดยใช้ [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/)

ตัวอย่าง Android ผ่าน Java นี้เพิ่มจุดสัญลักษณ์และรายการหมายเลขลงในกรอบข้อความเดียวกัน [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) เลือกประเภทของจุดรายการ ในขณะที่ [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) ระบุสัญลักษณ์และ [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) เลือกสไตล์การลำดับ ทั้งสองรายการใช้จุดสีดำ ความสูง 100 % และระยะเยื้องย่อหน้า 25 จุด:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **ใช้จุดรูปภาพ**

จุดรูปภาพทำให้คุณใช้รูปภาพที่กำหนดเองแทนสัญลักษณ์หรือหมายเลข

ตัวอย่าง Android ผ่าน Java นี้เพิ่มรูปภาพเข้าไปในคอลเลคชันภาพของการพรีเซนเทชันเป็น [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) และใช้เป็นจุดของย่อหน้า โดยเรียก [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) เพื่อใช้จุดรูปภาพและกำหนดรูปภาพผ่าน [IBulletFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getPicture--). [IBulletFormat.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) ตั้งค่าเป็น 100 % เพื่อขนาดจุดสัมพันธ์กับข้อความย่อหน้า:

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

ตั้งค่า [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึก `0`

ตัวอย่าง Android ผ่าน Java นี้กำหนดค่า [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) ตั้งแต่ 0 ถึง 3 สำหรับย่อหน้า 4 ย่อหน้า ทำให้เกิดลำดับชั้นภายในกรอบข้อความเดียวกัน แต่ละย่อหน้าใช้จุดสัญลักษณ์ โดย [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) สลับระหว่างจุดกลมและเครื่องหมายขีดเพื่อแยกระดับที่ใกล้เคียง:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **เริ่มรายการหมายเลขที่ค่าที่กำหนดเอง**

ใช้ [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เพื่อตั้งค่าตัวเลขเริ่มต้นที่แสดงสำหรับย่อหน้าที่มีหมายเลข

ตัวอย่าง Android ผ่าน Java นี้ตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) เพื่อใช้การลำดับหมายเลขสำหรับย่อหน้า 3 ย่อหน้าและกำหนดค่า [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เป็น 2, 3, และ 7 ค่าตั้งต้นเหล่านี้กำหนดแยกสำหรับแต่ละย่อหน้า ทำให้ตัวเลขที่แสดงข้ามค่าได้:

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

## **ควบคุมการจัดวางย่อหน้าและคุณสมบัติการสิ้นสุด**

ปรับระยะขอบและการเยื้องของย่อหน้าเพื่อควบคุมตำแหน่งของบรรทัดแรกและบรรทัดที่ตัดต่อ คุณยังสามารถจัดรูปแบบเครื่องหมายสิ้นสุดของย่อหน้าแยกจากส่วนข้อความที่มองเห็นได้

### **ตั้งการเยื้องบรรทัดแรก**

ใช้เมธอด [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) เพื่อควบคุมการเยื้องของบรรทัดแรกของย่อหน้า การตั้งค่านี้ย้ายบรรทัดแรกเท่านั้นสัมพันธ์กับระยะขอบซ้ายของย่อหน้า ค่าบวกจะย้ายบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือยังคงจัดแนวตามเนื้อหาย่อหน้า

ใช้ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ใช้ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างต่อไปนี้ให้ย่อหน้า 3 ย่อหน้ามี [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) เท่ากับ 20 จุดและค่า [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) เป็น 0, 20, และ 40 จุด บรรทัดแรกเริ่มที่ระยะที่เพิ่มขึ้นอย่างต่อเนื่อง ส่วนบรรทัดที่ตัดต่อยังคงระยะขอบซ้ายเท่ากัน:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![The first-line indent of the paragraphs](first_line_indent.png)

### **ตั้งการเยื้องห้อย**

การเยื้องห้อยคือการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยคุณสมบัติ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). ตั้งค่า `Indent` เป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายสัมพันธ์กับเนื้อย่อหน้า

โดยปฏิบัติการ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) กำหนดตำแหน่งซ้ายของเนื้อย่อหน้า และ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) กำหนดตำแหน่งของบรรทัดแรกสัมพันธ์กับระยะขอบนั้น การสร้างการเยื้องห้อยให้ตั้งค่า `MarginLeft` เป็นค่าบวกและ `Indent` เป็นค่าลบ

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม การอ้างอิง รายการอภิธานศัพท์ และย่อหน้าอื่น ๆ ที่ต้องการให้บรรทัดที่ตัดต่อจัดแนวอยู่ใต้เนื้อย่อหน้ามากกว่าภายใต้อักขระแรกของบรรทัดแรก

ตัวอย่าง Android ผ่าน Java ด้านล่างจับคู่ค่า [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) ที่ 40 และ 60 จุดกับค่า [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) ที่ -20 และ -30 จุด ในแต่ละย่อบรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่ตัดต่อ; ย่อหน้าที่สองมีการเยื้องห้อยที่ลึกกว่า:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![The hanging indent of the paragraphs](hanging_indent.png)

### **ตั้งค่าคุณสมบัติการวิ่งของย่อหน้าสิ้นสุด**

เมธอด [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) ควบคุมการจัดรูปแบบของเครื่องหมายสิ้นสุดย่อหน้า ตัวอย่างต่อไปนี้สร้าง [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) โดยตั้งค่า [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) เป็น 48 จุดและ [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) เป็น Times New Roman แล้วกำหนดรูปแบบนี้ให้กับเครื่องหมายสิ้นสุดของย่อหน้าที่สองโดยไม่กระทบต่อส่วนข้อความที่มองเห็น:

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

## **นับบรรทัดที่แสดงผล**

สำหรับกฎของย่อหน้าที่ส่งผลต่อการตัดบรรทัดอัตโนมัติและเครื่องหมายวรรคตอนที่บรรทัดสิ้นสุด ดูที่ [Control Line Breaking](/slides/th/androidjava/text-formatting/#control-line-breaking) และ [Control Hanging Punctuation](/slides/th/androidjava/text-formatting/#control-hanging-punctuation)

ใช้ [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) เพื่อนับจำนวนบรรทัดที่ย่อหน้าใช้หลังจากการจัดรูปแบบข้อความรวมถึงการตัดบรรทัดอัตโนมัติ ซึ่งมีประโยชน์เมื่อตรวจสอบความยาวและการจัดวางข้อความในเทมเพลตการพรีเซนเทชัน

ย่อหน้าเป็นหนึ่งรายการใน [ITextFrame.getParagraphs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParagraphs--) และอาจใช้หลายบรรทัดที่แสดงผล การใส่การตัดบรรทัดแบบชัดเจนภายในย่อหน้าจะบังคับให้ขึ้นบรรทัดใหม่โดยไม่ต้องสร้างย่อหน้าใหม่ การตัดบรรทัดอัตโนมัติสร้างบรรทัดตามความกว้างที่มีอยู่โดยไม่แทรกตัวอักษรตัดบรรทัดลงในข้อความ ดังนั้นการนับย่อหน้าหรืออักขระตัดบรรทัดจึงไม่ให้จำนวนบรรทัดที่แสดงผล

ตัวอย่างต่อไปนี้สร้างรูปทรงข้อความ, นับบรรทัด, ลดความกว้างของรูปทรง, แล้วแทนที่ข้อความด้วยสตริงสั้นกว่า ตัวอย่างเปิดใช้งานการตัดบรรทัดด้วย [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) และปิดการปรับขนาดอัตโนมัติด้วย [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) เพื่อให้ความกว้างของรูปทรงควบคุมการตัดบรรทัดโดยไม่ย่อข้อความหรือปรับขนาดรูปทรงโดยอัตโนมัติ การวัดแต่ละครั้งใช้ [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--). ขนาดของรูปทรงเป็นหน่วยจุด ในที่สุดตัวอย่างเพิ่มย่อหน้าอีกหนึ่งย่อหน้าและรวมจำนวนบรรทัดทั้งหมดในกรอบข้อความ

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

ด้วยข้อความและขนาดเหล่านี้ การลดความกว้างของรูปทรงทำให้จำนวนบรรทัดเพิ่มขึ้น ในขณะที่การแทนที่ข้อความด้วยสตริงสั้นทำให้จำนวนบรรทัดลดลง ค่าที่ได้อาจแตกต่างตามการมีฟอนต์และการแทนที่, ขนาดฟอนต์, ระยะขอบ, การเยื้อง, การตัดบรรทัดและการตั้งค่า autofit ใช้ฟอนต์และการตั้งค่าการจัดวางที่ตั้งใจสำหรับสภาพแวดล้อมเป้าหมายเมื่อตรวจสอบเทมเพลต

จำนวนบรรทัดเพียงอย่างเดียวไม่บ่งบอกว่าข้อความล้นพื้นที่หรือไม่ ความสูงที่มี, ความสูงของบรรทัด, ระยะห่างระหว่างย่อหน้าและบรรทัด, รวมถึงพฤติกรรม autofit ก็มีผลเช่นกัน; แม้บรรทัดเดียวอาจเกินความกว้างที่มีเมื่อปิดการตัดบรรทัด

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

ใช้ HTML เพื่อนำข้อความเข้ามาในพรีเซนเทชันหรือส่งออกย่อหน้าที่มีอยู่เพื่อใช้ภายนอก ส่วนนี้ยังแสดงวิธีการแสดงย่อหน้าเป็นภาพแยก รวมถึงย่อหน้าในเซลล์ตาราง

### **นำเข้า HTML ข้อความเข้าสู่ย่อหน้า**

ใช้เมธอด [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) เพื่อแปลงมาร์คอัป HTML ให้เป็นย่อหน้าและส่วนในกรอบข้อความ

ตัวอย่าง Android ผ่าน Java นี้อ่าน HTML จากไฟล์และส่งมาร์คอัปให้กับ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-). ตัวอย่างนี้ล้างย่อหน้าเริ่มต้นของกรอบข้อความเพื่อให้กรอบมีเฉพาะเนื้อหาที่นำเข้า รูปร่างสี่เหลี่ยมทำให้มีระยะขอบ 10 จุดบนทุกด้านของสไลด์:

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

ใช้เมธอด [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML เมื่อทำซ้ำข้อความพรีเซนเทชันบนเว็บไซต์ คุณอาจต้องการรักษาการเน้นข้อความโดยไม่ต้องพกฟอนต์ ขนาด หรือสไตล์กล่องข้อความของพรีเซนเทชันตั้งค่า [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) เพื่อควบคุมความลึกที่ตัวส่งออกตามการสืบทอดการจัดรูปแบบ

ดาวน์โหลด [ตัวอย่างพรีเซนเทชัน](text-inheritance.pptx) แล้ววางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกมีรูปทรงข้อความหนึ่งรูปที่มีข้อความ “Inherited text; explicit red 18pt”. อินพุตใช้หลายระดับการจัดรูปแบบโดยเจตนา:

- สไตล์ข้อความเริ่มต้นของพรีเซนเทชันใช้ Calibri ขนาด 28 pt
- สไตล์ข้อความระดับแรกของกรอบข้อความใช้ข้อความสีฟ้าและตัวเอียง
- ย่อหน้ากำหนดข้อความตัวหนาอย่างชัดเจน
- ส่วนที่สอง “explicit red 18pt” กำหนดข้อความสีแดงและขนาด 18 pt อย่างชัดเจน

ตัวอย่างเต็มต่อไปนี้ส่งออกย่อหน้าเดียวกันสามครั้ง โดยส่งผ่าน [TextToHtmlConversionOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/) ไปยังเมธอดส่งออกและเขียนผลลัพธ์แต่ละไฟล์เป็น HTML UTF‑8 แยกไฟล์:

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

HTML ที่สร้างขึ้นมี CSS ต่อไปนี้สำหรับส่วนแรก “Inherited text; ” ตารางแสดงการประกาศที่เกี่ยวข้อง; คุณสมบัติเพิ่มเติมอื่น ๆ ถูกละเว้นเพื่อความกระชับ

| ผลลัพธ์ | CSS ที่เกี่ยวข้องสำหรับส่วนแรก | ลักษณะ |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีฟ้าตัวหนาตัวเอียง ขนาด 28 pt ใน Calibri หากฟอนต์นั้นมีอยู่ |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีฟ้าตัวหนาตัวเอียง; หน้าเว็บหรือเบราว์เซอร์จะกำหนดฟอนต์และขนาด |
| `ParagraphOnly.html` | `font-weight:bold` | ข้อความตัวหนา; หน้าเว็บหรือเบราว์เซอร์จะกำหนดฟอนต์, ขนาด, สี และสไตล์เอียง |

ส่วนที่สองคง `color:#ff0000`, `font-size:18pt`, และ `font-weight:bold` ในผลลัพธ์ทั้งสามและยังคงเอียงใน `All` และ `TextBox` แต่ไม่ใช่ใน `ParagraphOnly` การจำกัดการสืบทอดจึงไม่ลบการจัดรูปแบบที่กำหนดให้กับย่อหน้าหรือส่วนอย่างชัดเจน

เปิดไฟล์เดียวกันในเบราว์เซอร์เพื่อเปรียบเทียบ ในสองโหมดที่จำกัด CSS ที่ละไว้จะถูกเติมโดยสไตล์ของหน้าปลายทางหรือค่าเริ่มต้นของเบราว์เซอร์ ดังนั้นลุคที่ได้จะขึ้นกับที่ใช้ HTML

### **สร้างส่วนคลิปบอร์ด HTML**

ใช้เมธอด [TextToHtmlConversionOptions.setAddClipboardFragmentHeader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/#setAddClipboardFragmentHeader-boolean-) เพื่อเลือกผลลัพธ์จาก [IParagraphCollection.exportToHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-). ตั้งค่า `false` เมธอดจะคืนค่า HTML ปกติ ตั้งค่า `true` จะทำให้สตริงที่คืนมามีส่วนหัวคลิปบอร์ดของ Windows ฟิลด์ `StartHTML` และ `EndHTML` ให้ตำแหน่งไบต์ UTF‑8 ของ HTML ส่วน `StartFragment` และ `EndFragment` ระบุตำแหน่งเนื้อหาเพื่อวาง

ตัวอย่างนี้ส่งออกย่อหน้าที่จัดรูปแบบสองย่อหน้าเป็น HTML ธรรมดา (`html`) และเป็นส่วนคลิปบอร์ด HTML (`clipboardHtml`) แอปพลิเคชันที่รองรับรูปแบบคลิปบอร์ด HTML ของ Windows สามารถใช้ส่วนนี้ได้โดยตรง หาก API ของคลิปบอร์ดคาดหวังไบต์ดิบ ให้เข้ารหัสส่วนนี้เป็น UTF‑8 โดยไม่มี BOM

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

### **แสดงย่อหน้าเป็นภาพ**

เมธอด [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) เรนเดอร์ย่อหน้าเดี่ยวโดยตรงและคืนค่า [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/). บันทึกผลลัพธ์ลงไฟล์หรือสตรีมด้วย [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). ไม่จำเป็นต้องเรนเดอร์รูปทรงที่บรรจุหรือครอปบิตแมปด้วยตนเอง

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) อาจคืนค่า `null` หากไม่พบย่อหน้าในคอลเลคชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายอิมเมจที่คืนมาเมื่อใช้งานเสร็จ

#### **แสดงย่อหน้าที่อัตราส่วนเริ่มต้น**

ตัวอย่างนี้ใช้พรีเซนเทชันที่มีหนึ่งสไลด์โดยรูปแรกเป็นกล่องข้อความที่มีสามย่อหน้า

![The text box with three paragraphs](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เลือกย่อหน้าที่สองที่ตำแหน่งดัชนี 1 และเรียก [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) โดยไม่ระบุพารามิเตอร์สเกล ตรวจสอบว่ารูปทรงมีย่อหน้าที่ต้องการและการเรนเดอร์คืนภาพก่อนเรียก [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) เพื่อบันทึกเป็น PNG บล็อก `finally` ทำลายอิมเมจหลังการใช้งาน

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

![The paragraph image](paragraph_to_image_output.png)

#### **แสดงย่อหน้าในเซลล์ตารางพร้อมการปรับสเกล**

ใช้เมธอด [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) ที่รับพารามิเตอร์ `float scaleX` และ `float scaleY` เพื่อกำหนดค่าอัตราส่วนแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, เรนเดอร์ย่อหน้าในเซลล์แรกด้วยความกว้างและความสูงเท่ากับสองเท่าของค่าเริ่มต้น, และบันทึกผลเป็น PNG

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

ค่าอัตราส่วน `1` รักษาขนาดพิกเซลเริ่มต้นของแกนนั้น ตัวอย่างเช่น `2` สำหรับทั้งสองแกนจะได้ภาพที่ความกว้างและความสูงประมาณสองเท่าของมิติเริ่มต้น, ทำให้จำนวนพิกเซลเพิ่มเป็นสี่เท่า ค่าอัตราส่วนที่ใหญ่กว่าจะให้ข้อความคมชัดขึ้นสำหรับการซูม或เอาต์พุตความละเอียดสูง, แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ค่าอัตราส่วนต่ำกว่า `1` จะให้ภาพขนาดเล็กลงและรายละเอียดน้อยลง ใช้อัตราส่วนเท่ากันเพื่อคงอัตราส่วนภาพของย่อหน้า; ค่าอัตราส่วนแนวนอนและแนวตั้งต่างกันจะยืดหรือหดผลลัพธ์แยกกัน

การเรนเดอร์รูปทรงทั้งหมดด้วย [IShape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getImage--) ยังคงมีประโยชน์เมื่อต้องการรวมการเติมสี, ขอบ, หรือบริบทภาพอื่น ๆ ของรูปทรง สำหรับภาพที่มีเพียงย่อหน้า ให้ใช้ [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--)

## **คำถามที่พบบ่อย**

**สามารถปิดการตัดบรรทัดอัตโนมัติภายในกรอบข้อความได้หรือไม่?**

ได้. ตั้งค่า [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) เป็นค่า `false` เพื่อปิดการตัดบรรทัด ทำให้บรรทัดไม่ตัดที่ขอบของกรอบข้อความ

**จะตรวจสอบขอบเขตบนสไลด์ของย่อหน้าเฉพาะได้อย่างไร?**

ใช้เมธอด [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getRect--) เพื่อรับสี่เหลี่ยมขอบเขตของย่อหน้า ส่วน [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getRect--) ให้ขอบเขตของส่วนแต่ละส่วน

**การจัดแนวย่อหน้า (ซ้าย, ขวา, กึ่งกลาง หรือ จัดเต็ม) ถูกควบคุมที่ไหน?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) เป็นการตั้งค่าระดับย่อหน้าและใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของส่วนแต่ละส่วน

เพื่อจัดแนวฟอนต์ที่มีขนาดแตกต่างกันภายในแต่ละบรรทัด ดูที่ [Align Fonts Within a Line](/slides/th/androidjava/text-formatting/#align-fonts-within-a-line)

**สามารถตั้งค่าภาษา proofing สำหรับส่วนหนึ่งของย่อหน้าได้หรือไม่?**

ได้. ตั้งค่า [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) สำหรับส่วนแต่ละส่วน ทำให้ย่อหน้าหนึ่งสามารถมีข้อความหลายภาษาได้