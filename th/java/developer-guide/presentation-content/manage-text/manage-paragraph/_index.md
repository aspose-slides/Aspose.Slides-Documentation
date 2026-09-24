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
- จัดการหัวข้อจุด
- การเยื้องย่อหน้า
- การเยื้องแบบ hanging
- หัวข้อจุดย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อจุด
- คุณสมบัติย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, portion, bullet, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML, และภาพย่อหน้า ด้วย Aspose.Slides for Java."
---
## **ภาพรวม**

Aspose.Slides for Java แสดงข้อความเป็นโครงสร้างลำดับชั้นของ text frames, paragraphs และ portions:

* [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) เป็นคอนเทนเนอร์ข้อความในรูปร่างและให้การเข้าถึงคอลเลกชันของ paragraph
* [IParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/) เป็นย่อหน้าหนึ่งใน text frame และให้การเข้าถึง portions และการฟอร์แมตระดับ paragraph
* [IPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/) เป็นการรันข้อความภายใน paragraph แต่ละ portion สามารถมีข้อความและการฟอร์แมตระดับอักขระของตนเองได้

ดังนั้น paragraph สามารถมีข้อความที่ใช้ฟอนต์ สี ขนาดและการฟอร์แมตอื่น ๆ ที่แตกต่างกันโดยใช้หลาย portion

## **สร้างและจัดรูปแบบย่อหน้า**

### **สร้างย่อหน้าด้วยหลาย Portion**

ขั้นตอนต่อไปนี้จะสร้าง text frame ที่มีสามย่อหน้า แต่ละย่อหน้ามีสาม portion:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของรูปทรง
5. ใช้ paragraph เริ่มต้นและเพิ่มวัตถุ [IParagraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/) อีกสองอันลงใน text frame
6. เพิ่มวัตถุ [IPortion](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/) ให้เพียงพอสำหรับแต่ละ paragraph เพื่อให้มีสาม portion. paragraph เริ่มต้นมี portion ว่างหนึ่งอันอยู่แล้ว
7. กำหนดข้อความของแต่ละ portion
8. ใช้การฟอร์แมตระดับอักขระผ่าน [IPortion.getPortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/#getPortionFormat--)
9. บันทึก presentation ที่แก้ไข

ตัวอย่าง Java นี้ทำตามขั้นตอนดังกล่าว:

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

## **สร้างรายการแบบหัวข้อและลำดับเลข**

### **สร้างรายการหัวข้อหรือรายการลำดับเลข**

Bullets และการจัดลำดับทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการจะกำหนดโดย [IBulletFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/)

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ไปยังสไลด์ที่เลือก
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของรูปทรง
5. ลบ paragraph เริ่มต้นออกจาก text frame
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/) สำหรับ bullet แบบสัญลักษณ์
7. ตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setType-int-) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/th/java/com.aspose.slides/bullettype/) และระบุอักขระ bullet
8. ตั้งค่าข้อความ paragraph, ระยะเยื้อง, สี bullet และความสูง bullet
9. เพิ่ม paragraph ลงใน text frame
10. สร้าง paragraph ที่สองและตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setType-int-) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/th/java/com.aspose.slides/bullettype/)
11. กำหนดสไตล์ bullet ลำดับเลขและเพิ่ม paragraph ลงใน text frame
12. บันทึก presentation

ตัวอย่าง Java นี้สร้าง bullet สัญลักษณ์และ bullet ลำดับเลข:

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

Picture bullets ให้คุณใช้ภาพกำหนดเองแทนสัญลักษณ์หรือเลข

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนีของมัน
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) และเข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของมัน
4. ลบ paragraph เริ่มต้นออกจาก text frame
5. โหลดภาพ bullet และเพิ่มลงในคอลเลกชันภาพของ presentation เป็น [IPPImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ippimage/)
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraph/) และตั้งค่าข้อความของมัน
7. ตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setType-int-) เป็น [BulletType.Picture](https://reference.aspose.com/slides/th/java/com.aspose.slides/bullettype/)
8. กำหนดภาพผ่าน [IBulletFormat.getPicture](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#getPicture--) และตั้งค่าความสูง bullet
9. เพิ่ม paragraph ลงใน text frame
10. บันทึก presentation ที่แก้ไข

ตัวอย่าง Java นี้สร้าง picture bullet:

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

ตั้งค่า [IParagraphFormat.setDepth](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setDepth-short-) เพื่อวาง paragraph ในระดับต่าง ๆ ของรายการ ระดับบนสุดมี depth เป็น `0`

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และเข้าถึงสไลด์หนึ่ง
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) และลบ paragraph เริ่มต้นออกจาก text frame ของมัน
3. สร้างสี่ paragraph และกำหนดสัญลักษณ์ bullet ของพวกมัน
4. ตั้งค่า [IParagraphFormat.setDepth](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setDepth-short-) ของพวกมันเป็นค่า `0`, `1`, `2` และ `3`
5. เพิ่ม paragraph ลงใน text frame และบันทึก presentation

ตัวอย่าง Java นี้สร้างรายการหัวข้อระดับสี่:

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

### **กำหนดค่าเริ่มต้นของ Numbered List ให้เป็นค่าที่กำหนดเอง**

ใช้ [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เพื่อกำหนดหมายเลขเริ่มต้นที่แสดงสำหรับ paragraph ที่เป็น numbered

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และเพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ไปยังสไลด์หนึ่ง
2. ลบ paragraph เริ่มต้นออกจาก text frame ของรูปทรง
3. สร้างสาม paragraph แบบ numbered
4. ตั้งค่า [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เป็น `2`, `3` และ `7` สำหรับแต่ละ paragraph ตามลำดับ
5. เพิ่ม paragraph ลงใน text frame และบันทึก presentation

ตัวอย่าง Java นี้กำหนดหมายเลขเริ่มต้นที่กำหนดเองให้กับแต่ละ paragraph:

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

## **ควบคุมการจัดวางและคุณสมบัติ End ของ Paragraph**

### **ตั้งค่า First-Line Indent**

ใช้ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) เพื่อควบคุมการเยื้องบรรทัดแรกของ paragraph วิธีนี้ย้ายเฉพาะบรรทัดแรกเทียบกับขอบซ้ายของ paragraph ค่าบวกจะเลื่อนบรรทัดแรกไปทางขวา ในขณะที่บรรทัดที่เหลือยังคงจัดตำแหน่งตามเนื้อหา paragraph

ใช้ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) เมื่อคุณต้องการย้ายทั้ง paragraph ใช้ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) เมื่อต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างด้านล่างสร้างหลาย paragraph และใช้ค่า [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) ที่ต่างกันเพื่อแสดงว่าการเยื้องบรรทัดแรกส่งผลต่อการวาง layout อย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของรูปทรงและลบ paragraph เริ่มต้น
5. สร้างหลาย paragraph และตั้งค่า [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) ที่ต่างกันสำหรับแต่ละอัน
6. เพิ่ม paragraph ลงใน text frame
7. บันทึก presentation ที่แก้ไข

โค้ดนี้แสดงวิธีตั้งค่าเยื้องของ paragraph:

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

![การเยื้อนบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งค่า Hanging Indent**

Hanging indent คือการจัด layout ของ paragraph ที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟ็กต์นี้ด้วย [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) ให้ค่าติดลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเทียบกับตัวเนื้อหา paragraph

โดยปกติ [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) กำหนดตำแหน่งซ้ายของเนื้อหา paragraph และ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) กำหนดตำแหน่งของบรรทัดแรกเทียบกับขอบซ้ายนั้น เพื่อสร้าง hanging indent ให้ตั้งค่า [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) เป็นค่าบวกและ [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) เป็นค่าลบ

การฟอร์แมตนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการอภิธานศัพท์ และ paragraph อื่น ๆ ที่ต้องการให้บรรทัดที่ต่อเนื่องจัดตำแหน่งใต้เนื้อหา paragraph แทนที่จะอยู่ใต้ตัวอักษรแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของรูปทรงและลบ paragraph เริ่มต้น
5. สร้าง paragraph และตั้งค่า [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) เป็นค่าบวกสำหรับแต่ละ paragraph
6. ตั้งค่า [IParagraphFormat.setIndent](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setIndent-float-) เป็นค่าลบเพื่อสร้างเอฟเฟ็กต์ hanging indent
7. เพิ่ม paragraph ลงใน text frame
8. บันทึก presentation ที่แก้ไข

โค้ดนี้แสดงวิธีตั้งค่า hanging indent สำหรับ paragraph:

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

![การเยื้องแบบ hanging ของย่อหน้า](hanging_indent.png)

### **ตั้งค่า End Paragraph Run Properties**

[IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) ควบคุมการฟอร์แมตของเครื่องหมายจบ paragraph ตัวอย่างต่อไปนี้กำหนดขนาดฟอนต์และฟอนต์ Latin ให้กับเครื่องหมายจบของ paragraph ที่สอง:

1. โหลด [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และเข้าถึงสไลด์หนึ่ง
2. เพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) และลบ paragraph เริ่มต้นของมัน
3. สร้างสอง paragraph และเพิ่ม portion ข้อความให้กับพวกมัน
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/portionformat/) สำหรับเครื่องหมายจบของ paragraph ที่สอง
5. ตั้งค่า [IBasePortionFormat.setFontHeight](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setFontHeight-float-) และ [IBasePortionFormat.setLatinFont](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setLatinFont-com.aspose.slides.IFontData-)
6. นำฟอร์แมตไปกำหนดด้วย [IParagraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/#setEndParagraphPortionFormat-com.aspose.slides.IPortionFormat-) แล้วบันทึก presentation

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

ใช้ [IParagraph.getLinesCount](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/#getLinesCount--) เพื่อให้นับบรรทัดที่ paragraph ใช้หลังจากการจัด layout ของข้อความ รวมถึงการห่ออัตโนมัติ ซึ่งมีประโยชน์เมื่อตรวจสอบความยาวและ layout ของข้อความในเทมเพลต presentation

paragraph เป็นรายการหนึ่งใน [ITextFrame.getParagraphs](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/#getParagraphs--) และอาจครอบคลุมหลายบรรทัดที่แสดงผล การใส่ line break อย่างชัดเจนภายใน paragraph จะทำให้ขึ้นบรรทัดใหม่โดยไม่ต้องสร้าง paragraph ใหม่ การห่ออัตโนมัติจะสร้างบรรทัดตามความกว้างที่มีให้โดยไม่ต้องแทรก line break ลงในข้อความ ดังนั้นการนับ paragraph หรืออักขระ line‑break จะไม่ให้จำนวนบรรทัดที่แสดงผลได้

ตัวอย่างต่อไปนี้สร้างรูปร่างข้อความ, นับจำนวนบรรทัด, ลดความกว้างของรูปร่าง, แล้วแทนที่ข้อความด้วยสตริงสั้นกว่า การห่อเปิดอยู่และ autofit ปิดอยู่เพื่อให้ความกว้างของรูปร่างควบคุมการห่อโดยไม่ให้ข้อความหรือรูปร่างหดโดยอัตโนมัติ มิติของรูปร่างหน่วยเป็น points สุดท้าย ตัวอย่างเพิ่ม paragraph อีกหนึ่งอันและรวมจำนวนบรรทัดทั้งหมดของ text frame

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

ด้วยข้อความและมิติเหล่านี้ การทำให้รูปร่างแคบลงจะเพิ่มจำนวนบรรทัด ในขณะที่การแทนที่ข้อความด้วยสตริงสั้นจะลดจำนวนบรรทัด จำนวนที่แม่นยำอาจแตกต่างกันตามฟอนต์ที่ใช้ การทดแทน ฟอนต์ขนาด, ระยะขอบ, ระยะเยื้อง, การห่อและการตั้งค่า autofit ใช้ฟอนต์และการตั้งค่า layout ที่ตั้งใจสำหรับสภาพแวดล้อมเป้าหมายเมื่อทดสอบเทมเพลต

จำนวนบรรทัดเพียงอย่างเดียวไม่ได้บ่งบอกว่าข้อความล้นพื้นที่ของมันหรือไม่ ความสูงที่ใช้ได้, ความสูงของบรรทัด, ระยะห่างระหว่าง paragraph และบรรทัด, รวมถึงพฤติกรรม autofit ก็มีผลด้วย แม้บรรทัดเดียวก็อาจเกินความกว้างที่ใช้ได้เมื่อการห่อถูกปิด

## **นำเข้าและส่งออกเนื้อหา Paragraph**

### **นำเข้า HTML Text เข้าไปใน Paragraphs**

ใช้ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-) เพื่อแปลง markup HTML เป็น paragraph และ portion ใน text frame

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/)
2. เข้าถึงสไลด์และเพิ่ม [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/)
3. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/) ของรูปทรงและลบ paragraph เริ่มต้น
4. อ่านไฟล์ HTML ต้นทาง
5. ส่งสตริง HTML ไปยัง [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraphcollection/#addFromHtml-java.lang.String-)
6. บันทึก presentation ที่แก้ไข

ตัวอย่าง Java นี้นำเข้า HTML ไปยัง text frame:

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

ใช้ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) เพื่อส่งออกรายช่วงของ paragraph เป็น HTML

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/java/com.aspose.slides/presentation/) และโหลด presentation ที่ต้องการ
2. เข้าถึงสไลด์และค้นหา [IAutoShape](https://reference.aspose.com/slides/th/java/com.aspose.slides/iautoshape/) ที่มีข้อความอยู่
3. เข้าถึง [ITextFrame](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframe/)
4. เรียก [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/th/java/com.aspose.slides/paragraphcollection/#exportToHtml-int-int-com.aspose.slides.ITextToHtmlConversionOptions-) พร้อมกับดัชนีเริ่มต้นของ paragraph และจำนวน paragraph ที่ต้องการส่งออก
5. เขียนสตริง HTML ที่ได้ลงไฟล์

ตัวอย่าง Java นี้ส่งออกทุก paragraph จาก text shape แรก:

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

### **เรนเดอร์ Paragraph เป็น Image**

[IParagraph.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/#getImage--) เรนเดอร์ paragraph แยกแต่ละอันโดยตรงและคืนค่าเป็น [IImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/) บันทึกผลลัพธ์ไปยังไฟล์หรือสตรีมด้วย [IImage.save](https://reference.aspose.com/slides/th/java/com.aspose.slides/iimage/#save-java.lang.String-int-) คุณไม่จำเป็นต้องเรนเดอร์รูปร่างที่บรรจุหรือครอปบิตแมพด้วยตนเอง

[IParagraph.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/#getImage--) อาจคืนค่า `null` หากไม่พบ paragraph ในคอลเลกชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายภาพที่คืนค่าหลังใช้เสร็จ

#### **เรนเดอร์ Paragraph ที่อัตราส่วนเริ่มต้น**

สมมติว่าเรามีไฟล์ presentation ชื่อ sample.pptx ที่มีสไลด์หนึ่ง โดยรูปร่างแรกเป็น text box ที่มีสาม paragraph

![กล่องข้อความที่มีสาม paragraph](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เรนเดอร์ paragraph ที่สองใน text shape ปกติที่อัตราส่วนเริ่มต้นและบันทึกภาพที่ได้ในรูปแบบ PNG บล็อก `finally` ทำให้แน่ใจว่าภาพถูกทำลายอย่างถูกต้อง

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

![ภาพ paragraph](paragraph_to_image_output.png)

#### **เรนเดอร์ Paragraph ในเซลล์ตารางพร้อมการสเกล**

ใช้ overload ของ [IParagraph.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/#getImage-float-float-) ที่รับพารามิเตอร์ `float scaleX` และ `float scaleY` เพื่อกำหนดอัตราส่วนแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, เรนเดอร์ paragraph ในเซลล์แรกที่สเกลเป็นสองเท่าของความกว้างและความสูงเริ่มต้น, แล้วบันทึกผลเป็นภาพ PNG

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

ค่าอัตราส่วน `1` จะคงขนาดพิกเซลเริ่มต้นของแกนนั้นไว้ ตัวอย่างเช่น `2` สำหรับทั้งสองค่า จะทำให้ภาพที่ได้มีความกว้างและความสูงประมาณสองเท่าของมิติเริ่มต้น, ส่งผลให้มีจำนวนพิกเซลสี่เท่า การใช้ค่าอัตราส่วนที่สูงกว่าจะทำให้ข้อความคมชัดขึ้นสำหรับการซูมหรือเอาต์พุตความละเอียดสูง, แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ค่าอัตราส่วนต่ำกว่า `1` จะทำให้ภาพเล็กลงและรายละเอียดน้อยลง ใช้ค่าอัตราส่วนที่เท่ากันเพื่อรักษาสัดส่วนของ paragraph; ค่าต่างกันระหว่างแนวนอนและแนวตั้งจะยืดภาพอย่างอิสระ

การเรนเดอร์รูปร่างทั้งหมดด้วย [IShape.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/ishape/#getImage--) ยังคงมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติมสี, ขอบ, หรือบริบทภาพอื่นของรูปร่าง สำหรับภาพที่มีเฉพาะ paragraph เท่านั้น ให้ใช้ [IParagraph.getImage](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/#getImage--)

## **FAQ**

**ฉันสามารถปิดการห่อบรรทัดภายใน text frame ได้อย่างสมบูรณ์หรือไม่?**

ใช่ ตั้งค่า [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/th/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) เพื่อปิดการห่อบรรทัด ทำให้บรรทัดไม่ตัดที่ขอบของ text frame

**ฉันจะรับค่าขอบเขตบนสไลด์ของ paragraph เฉพาะได้อย่างไร?**

ใช้ [IParagraph.getRect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraph/#getRect--) เพื่อดึงสี่เหลี่ยมขอบของ paragraph. [IPortion.getRect](https://reference.aspose.com/slides/th/java/com.aspose.slides/iportion/#getRect--) ให้ค่าขอบเขตของ portion แยกแต่ละอัน

**การจัดแนว paragraph (ซ้าย, ขวา, กลาง หรือ justify) ถูกควบคุมที่ไหน?**

[IParagraphFormat.setAlignment](https://reference.aspose.com/slides/th/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) เป็นการตั้งค่าระดับ paragraph และใช้กับทั้ง paragraph ไม่ว่าตัว portion แต่ละอันจะฟอร์แมตอย่างไร

**ฉันสามารถตั้งค่าภาษา proofing สำหรับส่วนหนึ่งของ paragraph ได้หรือไม่?**

ได้ ตั้งค่า [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) สำหรับ portion แยกต่างหาก เพื่อให้ paragraph หนึ่งสามารถมีข้อความหลายภาษาได้