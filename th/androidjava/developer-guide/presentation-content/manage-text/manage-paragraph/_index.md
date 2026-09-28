---
title: จัดการย่อความข้อความ PowerPoint บน Android
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
- จัดการสัญลักษณ์
- ย่อหน้าเยื้องบรรทัดแรก
- ย่อหน้าเยื้องแบบห้อย
- สัญลักษณ์ย่อหน้า
- รายการลำดับเลข
- รายการสัญลักษณ์
- คุณสมบัตย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นรูปภาพ
- ข้อความเป็นรูปภาพ
- ส่งออกย่อหน้า
- PowerPoint
- การนำเสนอ
- Android
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า ส่วนข้อความ สัญลักษณ์ รายการลำดับเลข ย่อหน้าเยื้อง เนื้อหา HTML และภาพย่อหน้าด้วย Aspose.Slides สำหรับ Android ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides สำหรับ Android ผ่าน Java แสดงข้อความเป็นโครงสร้างขั้นบันไดของกรอบข้อความ ย่อหน้า และส่วนข้อความ:

* [ITextFrame](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/) เป็นคอนเทนเนอร์ของข้อความในรูปร่างและให้การเข้าถึงคอลเลกชันของย่อหน้า
* [IParagraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/) เป็นย่อหน้าหนึ่งในกรอบข้อความและให้การเข้าถึงส่วนข้อความและการจัดรูปแบบระดับย่อหน้า
* [IPortion](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/) เป็นการทำงานของข้อความภายในย่อหน้า แต่ละส่วนข้อความสามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเอง

ดังนั้น ย่อหน้าจึงสามารถมีข้อความที่ใช้แบบอักษร สี ขนาด และการจัดรูปแบบอื่นๆ ที่แตกต่างกันได้โดยใช้หลายส่วนข้อความ

## **สร้างและจัดรูปแบบย่อหน้า**

### **สร้างย่อหน้าด้วยหลายส่วนข้อความ**

ขั้นตอนต่อไปนี้สร้างกรอบข้อความที่มีย่อหน้า 3 ย่อหน้า โดยแต่ละย่อหน้ามีส่วนข้อความ 3 ส่วน:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่เกี่ยวข้องโดยใช้ดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เข้าถึง [ITextFrame] ของรูปร่าง
5. ใช้ย่อหน้าเริ่มต้นและเพิ่มวัตถุ [IParagraph] อีกสองรายการไปยังกรอบข้อความ
6. เพิ่มวัตถุ [IPortion] จำนวนที่เพียงพอให้แต่ละย่อหน้ามีสามส่วนข้อความ ย่อหน้าเริ่มต้นมีส่วนข้อความว่างหนึ่งส่วนอยู่แล้ว
7. ตั้งข้อความของแต่ละส่วนข้อความ
8. ใช้การจัดรูปแบบระดับอักขระผ่าน [IPortion.getPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/#getPortionFormat--)
9. บันทึกการนำเสนอที่แก้ไขแล้ว

ตัวอย่าง Android ผ่าน Java นี้แสดงการทำตามขั้นตอน:

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

## **สร้างรายการแบบสัญลักษณ์และลำดับเลข**

### **สร้างรายการแบบสัญลักษณ์หรือเลขลำดับ**

สัญลักษณ์และการลำดับทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการกำหนดโดยใช้ [IBulletFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/)

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่เกี่ยวข้องโดยใช้ดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ไปยังสไลด์ที่เลือก
4. เข้าถึง [ITextFrame] ของรูปร่าง
5. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraph/) สำหรับสัญลักษณ์สัญลักษณ์จุด
7. ตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setType-int-) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/bullettype/) และระบุอักขระสัญลักษณ์
8. ตั้งค่าข้อความย่อหน้า ระยะเยื้อง สีสัญลักษณ์และความสูงของสัญลักษณ์
9. เพิ่มย่อหน้าลงในกรอบข้อความ
10. สร้างย่อหน้าที่สองและตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setType-int-) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/bullettype/)
11. กำหนดสไตล์ของสัญลักษณ์เลขลำดับและเพิ่มย่อหน้าลงในกรอบข้อความ
12. บันทึกการนำเสนอ

ตัวอย่าง Android ผ่าน Java นี้สร้างสัญลักษณ์จุดและสัญลักษณ์แบบลำดับเลข:

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

สัญลักษณ์รูปภาพให้คุณใช้รูปภาพกำหนดเองแทนสัญลักษณ์หรือเลข

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่เกี่ยวข้องโดยใช้ดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) และเข้าถึง [ITextFrame] ของมัน
4. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ
5. โหลดรูปภาพสัญลักษณ์และเพิ่มไปยังคอลเลกชันรูปภาพของการนำเสนอเป็น [IPPImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ippimage/)
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraph/) และตั้งค่าข้อความของมัน
7. ตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setType-int-) เป็น [BulletType.Picture](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/bullettype/)
8. กำหนดรูปภาพผ่าน [IBulletFormat.getPicture](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#getPicture--) และตั้งค่าความสูงของสัญลักษณ์
9. เพิ่มย่อหน้าลงในกรอบข้อความ
10. บันทึกการนำเสนอที่แก้ไขแล้ว

ตัวอย่าง Android ผ่าน Java นี้สร้างสัญลักษณ์รูปภาพ:

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

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) และเข้าถึงสไลด์
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) และลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของมัน
3. สร้างสี่ย่อหน้าและกำหนดสัญลักษณ์สัญลักษณ์ของพวกมัน
4. ตั้งค่า [IParagraphFormat.setDepth](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setDepth-short-) ของพวกมันเป็น `0` `1` `2` และ `3`
5. เพิ่มย่อหน้าลงในกรอบข้อความและบันทึกการนำเสนอ

ตัวอย่าง Android ผ่าน Java นี้สร้างรายการสัญลักษณ์ระดับสี่:

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

### **เริ่มรายการเลขลำดับด้วยค่าที่กำหนดเอง**

ใช้ [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เพื่อตั้งหมายเลขเริ่มต้นของย่อหน้าแบบลำดับเลข

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) และเพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ไปยังสไลด์
2. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของรูปร่าง
3. สร้างย่อหน้าเลขลำดับสามย่อหน้า
4. ตั้งค่า [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เป็น `2` `3` และ `7` สำหรับย่อหน้าแต่ละรายการ
5. เพิ่มย่อหน้าลงในกรอบข้อความและบันทึกการนำเสนอ

ตัวอย่าง Android ผ่าน Java นี้กำหนดหมายเลขเริ่มต้นที่กำหนดเองให้กับแต่ละย่อหน้า:

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

## **ควบคุมการจัดวางย่อหน้าและคุณสมบัติสิ้นสุด**

### **ตั้งค่าเยื้องบรรทัดแรก**

ใช้ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า วิธีนี้จะเลื่อนบรรทัดแรกเท่านั้นโดยอิงตามขอบซ้ายของย่อหน้า ค่าบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือจะคงสอดคล้องกับเนื้อหาย่อหน้า

ใช้ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ใช้ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างต่อไปนี้สร้างหลายย่อหน้าและกำหนดค่า [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) ต่าง ๆ เพื่อแสดงว่าการเยื้องบรรทัดแรกส่งผลต่อการจัดวางอย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เข้าถึง [ITextFrame] ของรูปร่างและลบย่อหน้าเริ่มต้นออก
5. สร้างหลายย่อหน้าและตั้งค่า [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) ที่แตกต่างกันสำหรับแต่ละย่อหน้า
6. เพิ่มย่อหน้าลงในกรอบข้อความ
7. บันทึกการนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่าเยื้องย่อหน้า:

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

### **ตั้งค่าเยื้องแบบห้อย**

การเยื้องแบบห้อยคือการจัดวางย่อหน้าโดยบรรทัดแรกเริ่มที่ด้านซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วย [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) ให้ค่าเป็นลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อหาย่อหน้า

โดยปฏิบัติ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) กำหนดตำแหน่งของบรรทัดแรกเมื่อเทียบกับขอบซ้ายนั้น เพื่อสร้างการเยื้องแบบห้อย ให้กำหนดค่าบวกให้กับ `setMarginLeft` และค่าลบให้กับ `setIndent`

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม การอ้างอิง รายการอภิธานศัพท์ และย่อหน้าอื่น ๆ ที่บรรทัดที่ต่อเนื่องต้องสอดคล้องกับเนื้อหาย่อหน้าแทนที่จะสอดคล้องกับอักขระแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เข้าถึง [ITextFrame] ของรูปร่างและลบย่อหน้าเริ่มต้นออก
5. สร้างย่อหน้าและกำหนดค่าบวกให้กับ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) สำหรับแต่ละย่อหน้า
6. กำหนดค่าลบให้กับ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) เพื่อสร้างเอฟเฟกต์เยื้องแบบห้อย
7. เพิ่มย่อหน้าลงในกรอบข้อความ
8. บันทึกการนำเสนอที่แก้ไขแล้ว

โค้ดนี้แสดงวิธีตั้งค่าเยื้องแบบห้อยสำหรับย่อหน้า:

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

![การเยื้องแบบห้อยของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติส่วนสิ้นสุดของย่อหน้า**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) ควบคุมการจัดรูปแบบของสัญลักษณ์สิ้นสุดย่อหน้า ตัวอย่างต่อไปนี้กำหนดขนาดฟอนต์และฟอนต์ละตินให้กับสัญลักษณ์สิ้นสุดของย่อหน้าที่สอง:

1. โหลด [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) และเข้าถึงสไลด์
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) และลบย่อหน้าเริ่มต้นของมัน
3. สร้างย่อหน้าสองรายการและเพิ่มส่วนข้อความลงในแต่ละรายการ
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/portionformat/) สำหรับสัญลักษณ์สิ้นสุดของย่อหน้าที่สอง
5. ตั้งค่า [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) และ [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-)
6. กำหนดรูปแบบด้วย [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) และบันทึกการนำเสนอ

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

สำหรับกฎของย่อหน้าที่ส่งผลต่อการตัดบรรทัดอัตโนมัติและเครื่องหมายวรรคตอนที่จบบรรทัด ดูที่ [Control Line Breaking](/slides/th/androidjava/text-formatting/#control-line-breaking) และ [Control Hanging Punctuation](/slides/th/androidjava/text-formatting/#control-hanging-punctuation)

ใช้ [IParagraph.getLinesCount](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#getLinesCount--) เพื่อนับบรรทัดที่ย่อหน้าครอบครองหลังจากการจัดวางข้อความ รวมถึงการตัดบรรทัดอัตโนมัติ สิ่งนี้มีประโยชน์เมื่อทำการตรวจสอบความยาวและการจัดวางของข้อความในเทมเพลตการนำเสนอ

ย่อหน้าเป็นรายการใน [ITextFrame.getParagraphs](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframe/#getParagraphs--) และอาจครอบคลุมหลายบรรทัดที่แสดงผล การใส่การตัดบรรทัดอย่างชัดเจนภายในย่อหน้าจะบังคับให้มีบรรทัดใหม่โดยไม่ต้องสร้างย่อหน้าใหม่ การตัดบรรทัดอัตโนมัติจะสร้างบรรทัดตามความกว้างที่มีอยู่โดยไม่แทรกการตัดบรรทัดแบบชัดเจนลงในข้อความ ดังนั้นการนับย่อหน้าหรืออักขระการตัดบรรทัดจะไม่ให้จำนวนบรรทัดที่แสดงผลได้

ตัวอย่างต่อไปนี้สร้างรูปร่างข้อความ นับบรรทัดของมัน ลดความกว้างของรูปร่าง แล้วแทนที่ข้อความด้วยสตริงสั้นกว่า การตัดบรรทัดเปิดใช้งานและการปรับอัตโนมัติปิดเพื่อให้ความกว้างของรูปร่างควบคุมการตัดบรรทัดโดยไม่ย่อขนาดข้อความหรือปรับขนาดรูปร่าง มิติของรูปร่างเป็นจุด ในที่สุด ตัวอย่างเพิ่มย่อหน้าอีกหนึ่งรายการและรวมจำนวนบรรทัดจากกรอบข้อความทั้งหมด

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

ด้วยข้อความและมิตินี้ การลดความกว้างของรูปร่างจะเพิ่มจำนวนบรรทัด ในขณะที่การแทนที่ข้อความด้วยสตริงสั้นจะลดจำนวนบรรทัด จำนวนที่แน่นอนอาจแตกต่างตามการใช้งานฟอนต์และการแทนที่ ขนาดฟอนต์, ขอบ, ระยะเยื้อง, การตัดบรรทัดและการตั้งค่า autofit ใช้ฟอนต์และการตั้งค่าการจัดวางที่กำหนดสำหรับสภาพแวดล้อมเป้าหมายเมื่อทำการตรวจสอบเทมเพลต

จำนวนบรรทัดอย่างเดียวไม่กำหนดว่าข้อความล้นออกจากคอนเทนเนอร์หรือไม่ ความสูงที่ใช้ได้, ความสูงของบรรทัด, ระยะห่างระหว่างย่อหน้าและบรรทัด, และพฤติกรรม autofit ก็สำคัญ; แม้แต่บรรทัดเดียวก็อาจเกินความกว้างที่ใช้ได้เมื่อปิดการตัดบรรทัด

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

### **นำเข้า HTML ลงในย่อหน้า**

ใช้ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) เพื่อแปลง markup HTML เป็นย่อหน้าและส่วนข้อความในกรอบข้อความ

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์และเพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/)
3. เข้าถึง [ITextFrame] ของรูปร่างและลบย่อหน้าเริ่มต้นออก
4. อ่านไฟล์ HTML ต้นทาง
5. ส่งสตริง HTML ไปยัง [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)
6. บันทึกการนำเสนอที่แก้ไขแล้ว

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

ใช้ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/presentation/) และโหลดการนำเสนอที่ต้องการ
2. เข้าถึงสไลด์และค้นหา [IAutoShape](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iautoshape/) ที่มีข้อความ
3. เข้าถึง [ITextFrame] ของรูปร่าง
4. เรียกใช้ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) พร้อมดัชนีย่อหน้าเริ่มต้นและจำนวนย่อหน้าที่ต้องการส่งออก
5. เขียนสตริง HTML ที่ส่งคืนไปยังไฟล์

ตัวอย่าง Android ผ่าน Java นี้ส่งออกย่อหน้าทั้งหมดจากกรอบข้อความแรก:

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

### **แปลงย่อหน้าเป็นภาพ**

[IParagraph.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#getImage--) แสดงย่อหน้าเดี่ยวโดยตรงและคืนค่า [IImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/) บันทึกผลลัพธ์เป็นไฟล์หรือสตรีมด้วย [IImage.save](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) คุณไม่จำเป็นต้องแสดงรูปแบบของรูปร่างที่บรรจุหรือครอบตัดบิทแมพด้วยตนเอง

[IParagraph.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#getImage--) อาจคืนค่า `null` หากไม่พบย่อหน้าในคอลเลกชันแม่ ไม่มีขอบเขตการแสดงผลที่ถูกต้อง หรือไม่สามารถแสดงผลได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายภาพที่ส่งคืนหลังการใช้งาน

#### **แปลงย่อหน้าโดยใช้สเกลเริ่มต้น**

สมมติว่าเรามีไฟล์ presentation ชื่อ sample.pptx ที่มีสไลด์หนึ่งสไลด์ โดยรูปร่างแรกเป็นกล่องข้อความที่มีย่อหน้า 3 ย่อหน้า

![The text box with three paragraphs](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้แสดงย่อหน้าที่สองในรูปร่างข้อความธรรมดาที่สเกลเริ่มต้นและบันทึกภาพที่คืนค่าเป็น PNG บล็อก `finally` จะทำให้มั่นใจว่าภาพถูกทำลายอย่างถูกต้อง

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

#### **แปลงย่อหน้าในเซลล์ตารางพร้อมสเกล**

ใช้การโหลดฟังก์ชัน [IParagraph.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#getImage-float-float-) ที่รับพารามิเตอร์ `float scaleX` และ `float scaleY` เพื่อกำหนดค่าตามแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง แสดงย่อหน้าในเซลล์แรกที่ความกว้างและความสูงเป็นสองเท่าของค่าเริ่มต้น และบันทึกผลเป็นภาพ PNG

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

ค่าสเกล `1` คงแกนนั้นไว้ที่ขนาดพิกเซลเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองแกนจะให้ภาพที่กว้างและสูงประมาณสองเท่าของมิติเริ่มต้น ทำให้จำนวนพิกเซลเพิ่มเป็นสี่เท่า สเกลที่สูงกว่าจะให้ข้อความคมชัดมากขึ้นสำหรับการซูมหรือเอาต์พุตความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ สเกลต่ำกว่า `1` จะสร้างภาพที่เล็กลงและรายละเอียดลดลง ใช้สเกลเท่ากันเพื่อรักษาอัตราส่วนของย่อหน้า; สเกลแนวนอนและแนวตั้งที่ต่างกันจะบิดการแสดงผลแยกกัน

การแสดงผลรูปร่างทั้งหมดด้วย [IShape.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ishape/#getImage--) ยังคงมีประโยชน์เมื่อเอาต์พุตต้องรวมการเติมสีของรูปร่าง ขอบ หรือบริบทภาพอื่น ๆ สำหรับภาพที่มีเพียงย่อหน้า ให้ใช้ [IParagraph.getImage](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#getImage--)

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดอัตโนมัติภายในกรอบข้อความได้หรือไม่?**

ใช่ ตั้งค่า [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) เพื่อปิดการตัดบรรทัดเพื่อให้บรรทัดไม่ตัดที่ขอบของกรอบข้อความ

**ฉันจะรับขอบเขตบนสไลด์ของย่อหน้าเฉพาะได้อย่างไร?**

ใช้ [IParagraph.getRect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraph/#getRect--) เพื่อดึงสี่เหลี่ยมขอบเขตของย่อหน้า [IPortion.getRect](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iportion/#getRect--) ให้ขอบเขตของส่วนข้อความแต่ละส่วน

**การจัดตำแหน่งย่อหน้า (ซ้าย ขวา กลาง หรือจัดเต็ม) ถูกควบคุมที่ไหน?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) เป็นการตั้งค่าระดับย่อหน้าและจะใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของส่วนย่อย

**ฉันสามารถตั้งค่าภาษา proofing สำหรับบางส่วนของย่อหน้าได้หรือไม่?**

ใช่ ตั้งค่า [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) สำหรับส่วนย่อยแต่ละส่วน เพื่อให้ย่อหน้าเดียวสามารถมีข้อความหลายภาษาได้