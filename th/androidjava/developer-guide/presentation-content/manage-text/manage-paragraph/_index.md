---
title: จัดการย่อหน้าข้อความ PowerPoint บน Android
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
- จัดการสัญลักษณ์หัวข้อ
- เยื้องย่อหน้า
- เยื้องแบบห้อย
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
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า ส่วนย่อย สัญลักษณ์หัวข้อ รายการลำดับเลข การเยื้อน เนื้อหา HTML และภาพย่อหน้าด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Android via Java แสดงข้อความเป็นโครงสร้างลำดับชั้นของกรอบข้อความ ย่อหน้า และส่วนย่อย:

* [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) เป็นตัวเก็บข้อความในรูปร่างและให้การเข้าถึงคอลเลกชันของย่อหน้า.
* [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) เป็นย่อหน้าเดียวในกรอบข้อความและให้การเข้าถึงส่วนย่อยและการจัดรูปแบบระดับย่อหน้า.
* [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) เป็นการรันข้อความภายในย่อหน้า แต่ละส่วนย่อยสามารถมีข้อความของตนเองและการจัดรูปแบบระดับอักขระ.

ดังนั้น ย่อหน้าจึงสามารถบรรจุข้อความที่มีแบบอักษร สี ขนาด และการจัดรูปแบบอื่น ๆ ที่แตกต่างกันโดยใช้หลายส่วนย่อย

## **สร้างและจัดรูปแบบย่อหน้า**

สร้างย่อหน้าในกรอบข้อความของรูปร่างและใช้ส่วนย่อยเพื่อจัดรูปแบบการรันข้อความแต่ละส่วน ส่วนนี้แสดงวิธีการรวมหลายส่วนย่อยภายในแต่ละย่อหน้าและใช้สี ขนาดแบบอักษร และสไตล์ที่ต่างกัน

### **สร้างย่อหน้าด้วยหลายส่วนย่อย**

ตัวอย่าง Android via Java ด้านล่างสร้างย่อหน้า 3 ย่อหน้า แต่ละย่อหน้ามีการรันข้อความ 3 ครั้งในคอลเลกชันที่ส่งคืนโดย [IParagraph.getPortions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getPortions--). โดยใช้ย่อหน้าเริ่มต้นและส่วนย่อยว่างเป็นพื้นฐาน แล้วเพิ่มย่อหน้าและส่วนย่อยที่เหลือ การจัดรูปแบบทำผ่าน [IPortion.getPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getPortionFormat--): ส่วนย่อยแรกในแต่ละย่อหน้ามีสีแดง หนา 15 จุด; ส่วนที่สองมีสีน้ำเงิน เอียง 18 จุด; ส่วนที่สามคงการจัดรูปแบบเริ่มต้น:

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

## **สร้างรายการสัญลักษณ์และลำดับเลข**

จัดระเบียบข้อความย่อหน้าเป็นรายการด้วยสัญลักษณ์ ตัวเลข หรือรูปภาพที่กำหนดเอง ตัวอย่างในส่วนนี้ครอบคลุมการจัดรูปแบบสัญลักษณ์ รายการหลายระดับ และการกำหนดค่าเริ่มต้นของตัวเลข

### **สร้างรายการด้วยสัญลักษณ์หรือเลขลำดับ**

สัญลักษณ์และการนับเลขทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการถูกกำหนดผ่าน [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/).

ตัวอย่าง Android via Java นี้เพิ่มสัญลักษณ์สัญลักษณ์หัวข้อและรายการลำดับเลขในกรอบข้อความเดียวกัน [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) เลือกประเภทสัญลักษณ์, ในขณะที่ [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) ให้สัญลักษณ์และ [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) เลือกสไตล์การนับเลข รายการทั้งสองใช้สัญลักษณ์สีดำที่ความสูง 100 เปอร์เซ็นต์และการเยื้องย่อหน้า 25 จุด:

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

### **ใช้สัญลักษณ์รูปภาพ**

สัญลักษณ์รูปภาพช่วยให้คุณใช้ภาพที่กำหนดเองแทนสัญลักษณ์หรือเลข.

ตัวอย่าง Android via Java นี้เพิ่มภาพลงในคอลเลกชันภาพของงานนำเสนอเป็น [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) และใช้เป็นสัญลักษณ์ย่อหน้า มันเรียก [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) เพื่อใช้สัญลักษณ์รูปภาพและกำหนดภาพผ่าน [IBulletFormat.getPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#getPicture--). [IBulletFormat.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setHeight-float-) ตั้งค่าเป็น 100 เปอร์เซ็นต์เพื่อกำหนดขนาดสัญลักษณ์สัมพันธ์กับข้อความย่อหน้า:

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

ตั้งค่า [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึก `0`.

ตัวอย่าง Android via Java นี้กำหนดค่า [IParagraphFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) ตั้งแต่ 0 ถึง 3 ให้กับย่อหน้า 4 ย่อหน้า สร้างลำดับชั้นภายในกรอบข้อความเดียวแต่ละย่อหน้าใช้สัญลักษณ์หัวข้อ โดย [IBulletFormat.setChar](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setChar-char-) สลับระหว่างสัญลักษณ์กลมและเครื่องหมายขีดเพื่อแยกระดับที่อยู่ติดกัน:

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

### **เริ่มรายการลำดับเลขที่ค่าที่กำหนดเอง**

ใช้ [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เพื่อกำหนดหมายเลขเริ่มต้นที่แสดงสำหรับย่อหน้าแบบลำดับเลข.

ตัวอย่าง Android via Java นี้ตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setType-byte-) เพื่อใช้การนับเลขในสามย่อหน้าและกำหนดค่า [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เป็น 2, 3, และ 7 ค่าที่เริ่มต้นถูกกำหนดแยกแต่ละย่อหน้า ทำให้เลขที่แสดงสามารถข้ามค่าได้:

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

## **ควบคุมการจัดวางย่อหน้าและคุณสมบัติท้าย**

ปรับขอบเขตและการเยื้อนของย่อหน้าเพื่อควบคุมตำแหน่งของบรรทัดแรกและบรรทัดที่ต่อเนื่อง คุณยังสามารถจัดรูปแบบเครื่องหมายจบย่อหน้าแยกจากส่วนข้อความที่มองเห็น.

### **ตั้งค่าการเยื้องบรรทัดแรก**

ใช้เมธอด [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า การตั้งค้านี้ย้ายเฉพาะบรรทัดแรกสัมพันธ์กับขอบซ้ายของย่อหน้า ค่าเป็นบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงอยู่สอดคล้องกับเนื้อหารูปย่อหน้า.

ใช้ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) เมื่อต้องการย้ายย่อหน้าทั้งหมด ใช้ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) เมื่อต้องการย้ายเฉพาะบรรทัดแรก.

ตัวอย่างต่อไปนี้ให้ย่อหน้า 3 ย่อหน้าใช้ค่า [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) เท่ากับ 20 จุดและค่า [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) เป็น 0, 20, และ 40 จุด บรรทัดแรกเริ่มที่ระยะห่างที่เพิ่มขึ้นเป็นลำดับขณะที่บรรทัดที่ต่อเนื่องคงขอบซ้ายเดียวกัน:

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

![การเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งค่าการเยื้อนแบบห้อย**

การเยื้อนแบบห้อยเป็นการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ด้านซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยคุณสมบัติ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). ตั้งค่า `Indent` เป็นค่าลบเพื่อเลื่อนบรรทัดแรกไปทางซ้ายสัมพันธ์กับเนื้อหาย่อหน้า.

โดยปฏิบัติ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) กำหนดตำแหน่งของบรรทัดแรกสัมพันธ์กับขอบนี้ เพื่อสร้างการเยื้อนแบบห้อย ให้ตั้งค่า `MarginLeft` เป็นบวกและ `Indent` เป็นลบ.

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม อ้างอิง รายการอภิธานศัพท์ และย่อหน้าอื่น ๆ ที่บรรทัดต่อเนื่องต้องจัดตำแหน่งใต้เนื้อหาย่อหน้าแทนที่ภายใต้อักษรแรกของบรรทัดแรก.

ตัวอย่าง Android via Java ต่อไปนี้จับคู่ค่า [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) เป็น 40 และ 60 จุดกับค่า [IParagraphFormat.setIndent](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) เป็น -20 และ -30 จุดในแต่ละย่อบรรทัดแรกเริ่มอยู่ด้านซ้ายของบรรทัดต่อเนื่อง; ย่อหน้าที่สองมีการเยื้อนแบบห้อยที่ลึกกว่า:

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

![การเยื้อนแบบห้อยของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติการรันย่อหน้าสุดท้าย**

เมธอด [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) ควบคุมการจัดรูปแบบของเครื่องหมายจบย่อหน้า ตัวอย่างต่อไปนี้สร้าง [PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/) ที่มี [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) ตั้งเป็น 48 จุดและ [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-) ตั้งเป็น Times New Roman มันกำหนดรูปแบบนี้ให้กับเครื่องหมายจบของย่อหน้าที่สองโดยไม่เปลี่ยนส่วนข้อความที่มองเห็น:

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

สำหรับกฎย่อหน้าที่มีผลต่อการตัดบรรทัดอัตโนมัติและเครื่องหมายวรรคตอนที่ท้ายบรรทัด ดูที่ [Control Line Breaking](/slides/th/androidjava/text-formatting/#control-line-breaking) และ [Control Hanging Punctuation](/slides/th/androidjava/text-formatting/#control-hanging-punctuation).

ใช้ [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) เพื่อนับจำนวนบรรทัดที่ย่อหน้าครอบคลุมหลังการจัดวางข้อความ รวมถึงการตัดบรรทัดอัตโนมัติ ซึ่งมีประโยชน์เมื่อตรวจสอบความยาวข้อความและการจัดวางในแม่แบบการนำเสนอ.

ย่อหน้าเป็นรายการหนึ่งใน [ITextFrame.getParagraphs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParagraphs--) และอาจครอบคลุมหลายบรรทัดที่แสดงผล การขึ้นบรรทัดใหม่อย่างชัดเจนภายในย่อหน้าจะบังคับให้มีบรรทัดใหม่โดยไม่สร้างย่อหน้าใหม่ การตัดบรรทัดอัตโนมัติสร้างบรรทัดตามความกว้างที่มีโดยไม่แทรกตัวอักขระขึ้นบรรทัดใหม่ การนับย่อหน้าหรืออักขระขึ้นบรรทัดจึงไม่ให้จำนวนบรรทัดที่แสดงผล.

ตัวอย่างต่อไปนี้สร้างรูปร่างข้อความ, นับบรรทัด, ทำให้รูปร่างแคบลง, แล้วแทนที่ข้อความด้วยสตริงสั้นกว่า ตัวอย่างเปิดใช้งานการตัดบรรทัดด้วย [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) และปิดการปรับขนาดอัตโนมัติด้วย [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) เพื่อให้ความกว้างของรูปร่างควบคุมการตัดบรรทัดโดยไม่ย่อขนาดข้อความหรือรูปร่างโดยอัตโนมัติ การวัดแต่ละครั้งใช้ [IParagraph.getLinesCount](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getLinesCount--). มิติของรูปร่างเป็นจุด ในที่สุดตัวอย่างเพิ่มย่อหน้าอีกหนึ่งและรวมจำนวนบรรทัดทั้งหมดในกรอบข้อความ.

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

ด้วยข้อความและมิติเหล่านี้ การทำให้รูปร่างแคบลงจะเพิ่มจำนวนบรรทัด ส่วนการแทนที่ข้อความด้วยสตริงสั้นจะลดจำนวนบรรทัด จำนวนที่แน่นอนอาจแตกต่างตามความพร้อมของฟอนต์และการแทนที่, ขนาดฟอนต์, ขอบ, การเยื้อน, การตัดบรรทัด, และการตั้งค่า autofit ใช้ฟอนต์และการตั้งค่าเลย์เอาต์ที่ตั้งใจสำหรับสภาพแวดล้อมเป้าหมายเมื่อทำการตรวจสอบแม่แบบ.

จำนวนบรรทัดเพียงอย่างเดียวไม่ได้กำหนดว่าข้อความจะล้นจากคอนเทนเนอร์หรือไม่ ความสูงที่ใช้ได้, ความสูงของบรรทัด, ระยะห่างระหว่างย่อหน้าและบรรทัด, และพฤติกรรม autofit ก็สำคัญ; แม้บรรทัดเดียวก็อาจเกินความกว้างที่ใช้ได้เมื่อปิดการตัดบรรทัด.

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

ใช้ HTML เพื่อนำข้อความเข้าสู่งานนำเสนอหรือส่งออกย่อหน้าที่มีอยู่เพื่อใช้ภายนอกส่วนนี้ยังแสดงวิธีการแสดงย่อหน้าเป็นภาพ รวมถึงย่อหน้าในเซลล์ตาราง.

### **นำเข้าข้อความ HTML สู่ย่อหน้า**

ใช้ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) เพื่อแปลง HTML markup ให้เป็นย่อหน้าและส่วนย่อยในกรอบข้อความ.

ตัวอย่าง Android via Java นี้อ่าน HTML จากไฟล์และส่ง markup ให้กับ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-). มันลบย่อหน้าเริ่มต้นของกรอบข้อความเพื่อให้กรอบมีเฉพาะเนื้อหาที่นำเข้า รูปร่างสี่เหลี่ยมทำให้ขอบ 10 จุดแต่ละด้านของสไลด์:

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

ใช้ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML เมื่อใช้ข้อความจากงานนำเสนอในเว็บไซต์ คุณอาจต้องการรักษาการเน้นภายในโดยไม่นำฟอนต์ ขนาด หรือสไตล์กล่องข้อความของงานนำเสนอไปตั้งค่า [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/#setTextInheritanceLimit-int-) เพื่อควบคุมระยะที่ตัวส่งออกตามการสืบทอดการจัดรูปแบบ.

ดาวน์โหลด [the sample presentation](text-inheritance.pptx) และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกมีรูปร่างข้อความหนึ่งรูปพร้อมข้อความ "Inherited text; explicit red 18pt" อินพุตตั้งใจใช้ระดับการจัดรูปแบบหลายระดับ:

- รูปแบบข้อความเริ่มต้นของงานนำเสนอใช้ฟอนต์ Calibri และขนาด 28 pt.
- รูปแบบข้อความระดับแรกของกรอบข้อความใช้ข้อความสีน้ำเงินและเอียง.
- ย่อหน้าเป็นการตั้งค่าข้อความหนาโดยชัดเจน.
- ส่วนที่สอง, "explicit red 18pt", ตั้งค่าข้อความสีแดงและขนาด 18 pt อย่างชัดเจน.

ตัวอย่างเต็มต่อไปนี้ส่งออกย่อหน้าเดียวกันสามครั้ง มันส่ง [TextToHtmlConversionOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/texttohtmlconversionoptions/) ให้กับเมธอดส่งออกและเขียนผลลัพธ์แต่ละไฟล์เป็นไฟล์ HTML UTF-8 แยกกัน:

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

HTML ที่สร้างขึ้นมี CSS ดังต่อไปนี้สำหรับส่วนแรก, "Inherited text; ". ตารางแสดงการประกาศที่เกี่ยวข้อง; คุณสมบัติที่สร้างอื่น ๆ ถูกละเว้นเพื่อความชัดเจน.

| ผลลัพธ์ | CSS ที่เกี่ยวข้องสำหรับส่วนแรก | ลักษณะ |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีน้ำเงิน หนา เอียง ขนาด 28 pt ใน Calibri หากฟอนต์นั้นมีอยู่. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีน้ำเงิน หนา เอียง; หน้าเว็บหรือเบราว์เซอร์ที่อยู่รอบ ๆ จะให้ฟอนต์และขนาด. |
| `ParagraphOnly.html` | `font-weight:bold` | ข้อความหนา; หน้าเว็บหรือเบราว์เซอร์ที่อยู่รอบ ๆ จะให้ฟอนต์, ขนาด, สี, และสไตล์เอียง. |

ส่วนที่สองคง `color:#ff0000`, `font-size:18pt`, และ `font-weight:bold` ในผลลัพธ์ทั้งสาม อีกทั้งยังคงเอียงใน `All` และ `TextBox` แต่ไม่ใน `ParagraphOnly` การจำกัดการสืบทอดจึงไม่ได้ลบการจัดรูปแบบที่กำหนดให้ย่อหน้าหรือส่วนย่อยโดยชัดเจน.

เปิดไฟล์ในเบราว์เซอร์เดียวกันเพื่อเปรียบเทียบ ในสองโหมดที่จำกัด คุณสมบัติ CSS ที่ละเว้นจะถูกกำหนดโดยสไตล์ของหน้าปลายทางหรือค่าเริ่มต้นของเบราว์เซอร์ ดังนั้นลักษณะที่ได้จึงขึ้นอยู่กับที่ใช้ HTML.

### **แสดงย่อหน้าเป็นภาพ**

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) แสดงย่อหน้าเดี่ยวโดยตรงและส่งคืน [IImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/). บันทึกผลลัพธ์เป็นไฟล์หรือสตรีมด้วย [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-). คุณไม่จำเป็นต้องแสดงรูปร่างที่บรรจุหรือครอปบิตแมพด้วยตนเอง.

[IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) สามารถคืนค่า `null` หากไม่พบย่อหน้าในคอลเลกชันแม่, ไม่มีขอบเขตการแสดงผลที่ถูกต้อง, หรือไม่สามารถแสดงผลได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและปล่อยภาพที่คืนค่าหลังการใช้.

#### **แสดงย่อหน้าที่สเกลเริ่มต้น**

ตัวอย่างนี้ใช้การนำเสนอที่มีสไลด์หนึ่งซึ่งรูปร่างแรกเป็นกล่องข้อความที่มีย่อหน้า 3 ย่อหน้า.

![กล่องข้อความที่มีย่อหน้า 3 ย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เลือกย่อหน้าที่สองที่ดัชนี 1 และเรียก [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--) โดยไม่มีพารามิเตอร์สเกล มันตรวจสอบว่ารูปร่างมีย่อหน้าที่ต้องการและการแสดงผลให้ภาพก่อนเรียก [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) เพื่อบันทึกเป็นรูปแบบ PNG บล็อก `finally` ปล่อยภาพหลังการใช้.

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

#### **แสดงย่อหน้าในเซลล์ตารางด้วยการสเกล**

ใช้ overload ของ [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) ที่รับพารามิเตอร์ `float scaleX` และ `float scaleY` เพื่อกำหนดตัวคูณสเกลแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, แสดงย่อหน้าในเซลล์แรกที่กว้างและสูงเป็นสองเท่าของค่าเริ่มต้น, และบันทึกผลลัพธ์เป็นภาพ PNG.

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

ตัวคูณสเกล `1` จะคงแกนนั้นที่ขนาดพิกเซลเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองตัวคูณจะสร้างภาพที่ความกว้างและสูงประมาณสองเท่าของมิติเริ่มต้น ทำให้มีพิกเซลเพิ่มเป็นสี่เท่า ตัวคูณที่ใหญ่กว่ามักให้ข้อความคมชัดขึ้นสำหรับการซูมหรือเอาต์พุตความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ตัวคูณต่ำกว่า `1` จะทำให้ภาพมีขนาดเล็กลงและรายละเอียดน้อยลง ใช้ตัวคูณเท่ากันเพื่อรักษาอัตราส่วนของย่อหน้า; ตัวคูณแนวนอนและแนวตั้งที่แตกต่างกันจะยืดเอาต์พุตแยกกัน.

การแสดงผลรูปร่างทั้งหมดด้วย [IShape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getImage--) ยังคงมีประโยชน์เมื่อต้องการรวมการเติม, ขอบ, หรือบริบทภาพอื่นของรูปร่าง สำหรับภาพที่มีเฉพาะย่อหน้า ให้ใช้ [IParagraph.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getImage--).

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดภายในกรอบข้อความได้ทั้งหมดหรือไม่?**

ใช่. ตั้งค่า [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) เพื่อปิดการตัดบรรทัดเพื่อให้บรรทัดไม่ตัดที่ขอบของกรอบข้อความ.

**ฉันจะรับขอบเขตที่แน่นอนบนสไลด์ของย่อหน้าที่ระบุได้อย่างไร?**

ใช้ [IParagraph.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getRect--) เพื่อดึงสี่เหลี่ยมขอบเขตของย่อหน้า [IPortion.getRect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/#getRect--) ให้ขอบเขตของส่วนย่อยแต่ละส่วน.

**ตำแหน่งการจัดย่อหน้า (ซ้าย, ขวา, กึ่งกลาง, หรือจัดชิด) ถูกควบคุมที่ไหน?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) เป็นการตั้งค่าระดับย่อหน้าและใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของส่วนย่อยแต่ละส่วน. เพื่อจัดแนวส่วนย่อยของขนาดฟอนต์ที่ต่างกันในแนวตั้งภายในแต่ละบรรทัด ดูที่ [Align Fonts Within a Line](/slides/th/androidjava/text-formatting/#align-fonts-within-a-line).

**ฉันสามารถตั้งค่าภาษา proofing สำหรับส่วนของย่อหน้าได้หรือไม่?**

ใช่. ตั้งค่า [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) สำหรับส่วนย่อยแต่ละส่วน เพื่อให้ย่อหน้าเดียวสามารถมีข้อความหลายภาษาได้.