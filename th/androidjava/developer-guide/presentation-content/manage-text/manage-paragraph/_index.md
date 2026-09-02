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
  - จัดการหัวข้อแบบจุด
  - ระยะเยื้องย่อหน้า
  - ระยะเยื้องแขวน
  - หัวข้อย่อหน้า
  - รายการเลขลำดับ
  - รายการหัวข้อแบบจุด
  - คุณสมบัติย่อหน้า
  - นำเข้า HTML
  - ข้อความเป็น HTML
  - ย่อหน้าเป็น HTML
  - ย่อหน้าเป็นภาพ
  - ข้อความเป็นภาพ
  - ส่งออกย่อหน้า
  - PowerPoint
  - งานนำเสนอ
  - Android
  - Java
  - Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, ส่วนย่อย, จุดหัวข้อ, รายการลำดับเลข, ระยะเยื้อง, เนื้อหา HTML, และภาพย่อหน้าด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Android via Java แสดงข้อความเป็นลำดับชั้นของกรอบข้อความ, ย่อหน้า, และส่วนย่อย:

* [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) แสดงเป็นคอนเทนเนอร์ข้อความในรูปทรงและให้เข้าถึงคอลเลกชันย่อหน้าได้
* [IParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/) แสดงย่อหน้าเดียวในกรอบข้อความและให้เข้าถึงส่วนย่อยและการจัดรูปแบบระดับย่อหน้า
* [IPortion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/) แสดงการไหลของข้อความภายในย่อหน้า แต่ละส่วนย่อยสามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเองได้

ดังนั้นย่อหน้าจึงสามารถมีข้อความที่ใช้แบบอักษร, สี, ขนาด, และการจัดรูปแบบอื่น ๆ ที่แตกต่างกันโดยใช้หลายส่วนย่อย

## **สร้างและจัดรูปแบบย่อหน้า**

### **สร้างย่อหน้าที่มีหลายส่วนย่อย**

ขั้นตอนต่อไปนี้สร้างกรอบข้อความที่มีสามย่อหน้า, แต่ละย่อหน้ามีสามส่วนย่อย:

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) แบบสี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) ของรูปร่าง
5. ใช้ย่อหน้าเริ่มต้นและเพิ่มอ็อบเจ็กต์ [IParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/) อีกสองอันไปยังกรอบข้อความ
6. เพิ่มอ็อบเจ็กต์ [IPortion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/) ให้เพียงพอสำหรับแต่ละย่อหน้าเพื่อให้มีสามส่วนย่อย ส่วนย่อหน้าเริ่มต้นมีส่วนย่อยว่างหนึ่งส่วนอยู่แล้ว
7. ตั้งค่าข้อความของแต่ละส่วนย่อย
8. ใช้การจัดรูปแบบระดับอักขระผ่าน [IPortion.getPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/#getPortionFormat--)
9. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่าง Android ผ่าน Java นี้ทำตามขั้นตอนดังกล่าว:

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

## **สร้างรายการแบบหัวข้อและลำดับเลข**

### **สร้างรายการแบบหัวข้อหรือแบบลำดับเลข**

หัวข้อและการนับลำดับทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการถูกกำหนดผ่าน [IBulletFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/)

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ไปยังสไลด์ที่เลือก
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) ของรูปร่าง
5. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraph/) สำหรับหัวข้อสัญลักษณ์
7. ตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setType-int-) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/bullettype/) และกำหนดอักขระหัวข้อ
8. ตั้งค่าข้อความย่อหน้า, ระยะเยื้อง, สีหัวข้อ, และความสูงของหัวข้อ
9. เพิ่มย่อหน้าไปยังกรอบข้อความ
10. สร้างย่อหน้าที่สองและตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setType-int-) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/bullettype/)
11. กำหนดสไตล์หัวข้อเลขและเพิ่มย่อหน้าไปยังกรอบข้อความ
12. บันทึกงานนำเสนอ

ตัวอย่าง Android ผ่าน Java นี้สร้างหัวข้อสัญลักษณ์และหัวข้อเลข:

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

### **ใช้หัวข้อภาพ**

หัวข้อภาพช่วยให้คุณใช้รูปภาพกำหนดเองแทนสัญลักษณ์หรือหมายเลข

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) และเข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) ของมัน
4. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ
5. โหลดรูปภาพหัวข้อและเพิ่มลงในคอลเลกชันรูปภาพของงานนำเสนอเป็น [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/)
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraph/) และตั้งค่าข้อความของมัน
7. ตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setType-int-) เป็น [BulletType.Picture](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/bullettype/)
8. กำหนดรูปภาพผ่าน [IBulletFormat.getPicture](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#getPicture--) และตั้งค่าความสูงของหัวข้อ
9. เพิ่มย่อหน้าไปยังกรอบข้อความ
10. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่าง Android ผ่าน Java นี้สร้างหัวข้อภาพ:

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

ตั้งค่า [IParagraphFormat.setDepth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึกเป็น `0`

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) และเข้าถึงสไลด์หนึ่งสไลด์
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) แล้วลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของมัน
3. สร้างสี่ย่อหน้าและกำหนดสัญลักษณ์หัวข้อของแต่ละย่อหน้า
4. ตั้งค่าความลึกของพวกมันโดยใช้ [IParagraphFormat.setDepth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) ที่ค่า `0`, `1`, `2`, และ `3`
5. เพิ่มย่อหน้าเหล่านั้นไปยังกรอบข้อความและบันทึกงานนำเสนอ

ตัวอย่าง Android ผ่าน Java นี้สร้างรายการหัวข้อสี่ระดับ:

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

### **ตั้งค่าตำแหน่งเริ่มต้นของรายการเลขที่กำหนดเอง**

ใช้ [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เพื่อกำหนดหมายเลขเริ่มต้นที่แสดงสำหรับย่อหน้าแบบลำดับเลข

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) แล้วเพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ไปยังสไลด์หนึ่งสไลด์
2. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของรูปร่าง
3. สร้างย่อหน้าเลขสามย่อหน้า
4. ตั้งค่า [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) ให้เป็น `2`, `3`, และ `7` สำหรับย่อหน้าที่เกี่ยวข้องแต่ละอัน
5. เพิ่มย่อหน้าเหล่านั้นไปยังกรอบข้อความและบันทึกงานนำเสนอ

ตัวอย่าง Android ผ่าน Java นี้กำหนดหมายเลขเริ่มต้นแบบกำหนดเองให้แต่ละย่อหน้า:

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

## **ควบคุมการจัดรูปแบบและคุณสมบัติเส้นสิ้นสุดของย่อหน้า**

### **ตั้งค่าระยะเยื้องบรรทัดแรก**

ใช้ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) เพื่อควบคุมระยะเยื้องบรรทัดแรกของย่อหน้า วิธีนี้จะย้ายบรรทัดแรกเท่านั้นเมื่อเทียบกับขอบซ้ายของย่อหน้า ค่าเป็นบวกจะย้ายบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงอยู่ตรงกับเนื้อหาย่อหน้า

ใช้ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) หากต้องการย้ายทั้งย่อหน้า ใช้ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) เมื่อต้องการย้ายเฉพาะบรรทัดแรกเท่านั้น

ตัวอย่างด้านล่างสร้างย่อหน้าหลายย่อหน้าและใช้ค่าต่าง ๆ ของ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) เพื่อแสดงว่าระยะเยื้องบรรทัดแรกส่งผลต่อการจัดเรียงย่ออย่างไร

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) แบบสี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) ของรูปร่างและลบย่อหน้าเริ่มต้นออก
5. สร้างย่อหน้าหลายย่อหน้าและตั้งค่าค่าต่าง ๆ ของ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) ให้กับพวกมัน
6. เพิ่มย่อหน้าเหล่านั้นไปยังกรอบข้อความ
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่าระยะเยื้องของย่อหน้า:

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

![ระยะเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งค่าระยะเยื้องแขวน**

ระยะเยื้องแขวนคือการจัดรูปแบบย่อหน้าโดยที่บรรทัดแรกเริ่มอยู่ด้านซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วย [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) โดยส่งค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อหาย่อหน้า

โดยปฏิบัติการ, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า, ส่วน [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) กำหนดตำแหน่งของบรรทัดแรกเมื่อเทียบกับขอบซ้านั้น เพื่อสร้างระยะเยื้องแขวน ให้กำหนดค่าเป็นบวกกับ `setMarginLeft` และค่าลบกับ `setIndent`

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, อ้างอิง, รายการอภิธานศัพท์, และย่อหน้าอื่น ๆ ที่บรรทัดที่พับควรอยู่ใต้เนื้อหาย่อหน้าแทนที่จะอยู่ใต้ตัวอักษรแรกของบรรทัดแรก

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) แบบสี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) ของรูปร่างและลบย่อหน้าเริ่มต้นออก
5. สร้างย่อหน้าและกำหนดค่าเป็นบวกให้กับ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) สำหรับแต่ละย่อหน้า
6. กำหนดค่าเป็นลบให้กับ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) เพื่อสร้างเอฟเฟกต์ระยะเยื้องแขวน
7. เพิ่มย่อหน้าเหล่านั้นไปยังกรอบข้อความ
8. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่าระยะเยื้องแขวนสำหรับย่อหน้า:

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

![ระยะเยื้องแขวนของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติการรันของย่อหน้าสิ้นสุด**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) ควบคุมการจัดรูปแบบของสัญลักษณ์สิ้นสุดย่อหน้า ตัวอย่างต่อไปนี้กำหนดขนาดฟอนต์และฟอนต์ Latin ให้กับสัญลักษณ์สิ้นสุดของย่อหน้าที่สอง:

1. โหลด [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) และเข้าถึงสไลด์หนึ่งสไลด์
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) แล้วลบย่อหน้าเริ่มต้นของมัน
3. สร้างย่อหน้าสองอันและเพิ่มส่วนข้อความไปยังพวกมัน
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portionformat/) สำหรับสัญลักษณ์สิ้นสุดของย่อหน้าที่สอง
5. ตั้งค่า [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) และ [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-)
6. นำฟอร์แม็ตไปใช้ด้วย [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) แล้วบันทึกงานนำเสนอ

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

ใช้ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) เพื่อแปลงมาร์กอัป HTML เป็นย่อหน้าและส่วนย่อยภายในกรอบข้อความ

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์และเพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/)
3. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) ของรูปร่างและลบย่อหน้าเริ่มต้นออก
4. อ่านไฟล์ HTML ต้นทาง
5. ส่งสตริง HTML ไปยัง [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)
6. บันทึกงานนำเสนอที่แก้ไขแล้ว

ตัวอย่าง Android ผ่าน Java นี้นำเข้า HTML ไปยังกรอบข้อความ:

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

ใช้ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) เพื่อส่งออกช่วงของย่อหน้าที่เลือกเป็น HTML

1. สร้างอินสแทนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) แล้วโหลดงานนำเสนอที่ต้องการ
2. เข้าถึงสไลด์และหาตัว [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ที่บรรจุข้อความ
3. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) ของรูปร่างนั้น
4. เรียก [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) พร้อมดัชนีย่อหน้าเริ่มต้นและจำนวนย่อหน้าที่ต้องการส่งออก
5. เขียนสตริง HTML ที่ได้ลงในไฟล์

ตัวอย่าง Android ผ่าน Java นี้ส่งออกย่อหน้าทั้งหมดจากรูปข้อความแรก:

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

### **เรนเดอร์ย่อหน้าเป็นภาพ**

[IParagraph.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#getImage--) เรนเดอร์ย่อหน้าเดี่ยวโดยตรงและคืนค่า [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) คุณสามารถบันทึกผลลัพธ์เป็นไฟล์หรือสตรีมด้วย [IImage.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) ไม่จำเป็นต้องเรนเดอร์รูปร่างที่บรรจุหรือครอบตัดบิตแมปด้วยตนเอง

[IParagraph.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#getImage--) อาจคืนค่า `null` หากไม่พบย่อหน้าในคอลเลกชันพาเรนท์, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายภาพที่คืนค่าหลังการใช้

#### **เรนเดอร์ย่อหน้าที่สเกลเริ่มต้น**

สมมติว่ามีไฟล์งานนำเสนอชื่อ sample.pptx ที่มีสไลด์เดียว, รูปร่างแรกเป็นกล่องข้อความที่มีสามย่อหน้า

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เรนเดอร์ย่อหน้าที่สองในรูปข้อความทั่วไปที่สเกลเริ่มต้นและบันทึกภาพที่ได้ในรูปแบบ PNG บล็อก `finally` จะทำให้แน่ใจว่าภาพถูกทำลายอย่างถูกต้อง

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

ใช้ overload ของ [IParagraph.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) ที่รับพารามิเตอร์ `float scaleX` และ `float scaleY` เพื่อกำหนดค่าปัจจัยสเกลในแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, เรนเดอร์ย่อหน้าในเซลล์แรกด้วยความกว้างและความสูงเป็นสองเท่าของค่าเริ่มต้น, แล้วบันทึกผลเป็นภาพ PNG

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

ค่าปัจจัยสเกล `1` จะรักษาขนาดพิกเซลเริ่มต้นของแกนนั้นไว้ ตัวอย่างเช่น `2` สำหรับทั้งสองค่า จะทำให้ภาพที่ได้มีความกว้างและความสูงประมาณสองเท่าของมิติเริ่มต้น, ทำให้จำนวนพิกเซลเพิ่มเป็นสี่เท่า ปัจจัยที่ใหญ่กว่าจะทำให้ข้อความคมชัดขึ้นสำหรับการซูมหรือเอาต์พุตความละเอียดสูง, แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ปัจจัยที่ต่ำกว่า `1` จะทำให้ภาพเล็กลงและรายละเอียดน้อยลง ใช้ปัจจัยเท่ากันเพื่อรักษาอัตราส่วนของย่อหน้า; ปัจจัยแนวนอนและแนวตั้งที่ต่างกันจะทำให้เอาต์พุตยืดออกอย่างอิสระ

การเรนเดอร์รูปร่างทั้งหมดด้วย [IShape.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getImage--) ยังคงมีประโยชน์เมื่อเอาต์พุตต้องรวมการเติม, เส้นขอบ, หรือบริบทภาพอื่น ๆ ของรูปร่าง สำหรับภาพที่มีเพียงย่อหน้าเดียว ให้ใช้ [IParagraph.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#getImage--)

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดภายในกรอบข้อความได้อย่างสมบูรณ์หรือไม่?**

ได้. ตั้งค่า [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) เพื่อปิดการตัดบรรทัดเพื่อให้บรรทัดไม่ตัดที่ขอบของกรอบข้อความ

**ฉันจะรับขอบเขตบนสไลด์ที่แม่นยำของย่อหน้าที่เฉพาะเจาะจงได้อย่างไร?**

ใช้ [IParagraph.getRect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#getRect--) เพื่อดึงสี่เหลี่ยมขอบของย่อหน้า [IPortion.getRect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/#getRect--) ให้ขอบเขตของส่วนย่อยแต่ละส่วน

**การจัดตำแหน่งย่อหน้า (ซ้าย, ขวา, ศูนย์กลาง, หรือจัดเต็ม) ถูกควบคุมที่ใด?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) เป็นการตั้งค่าระดับย่อหน้าและใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของส่วนย่อยแต่ละส่วน

**ฉันสามารถตั้งค่าภาษา proofing สำหรับส่วนของย่อหน้าได้หรือไม่?**

ได้. ตั้งค่า [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) สำหรับส่วนย่อยแต่ละส่วน เพื่อให้ย่อหน้าเดียวสามารถมีข้อความได้หลายภาษา