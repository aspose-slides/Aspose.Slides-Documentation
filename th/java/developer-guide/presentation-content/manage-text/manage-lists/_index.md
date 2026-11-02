---
title: จัดการรายการแบบหัวข้อจุดและลำดับเลขในงานนำเสนอด้วย Java
linktitle: จัดการรายการ
type: docs
weight: 60
url: /th/java/manage-lists/
keywords:
- สัญลักษณ์หัวข้อ
- รายการแบบหัวข้อจุด
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
- Java
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบรายการแบบหัวข้อจุด, รูปภาพ, หลายระดับ, และลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides สำหรับ Java."
---
## **ภาพรวม**

Aspose.Slides for Java ให้คุณสร้างและจัดรูปแบบรายการสัญลักษณ์หัวข้อและรายการลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument รายการแต่ละรายการคือย่อหน้าที่การตั้งค่าสัญลักษณ์หัวข้อถูกควบคุมผ่านรูปแบบย่อหน้า

ใช้เมธอด [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) เพื่อเข้าถึงการตั้งค่ารายการในระดับย่อหน้า จุดเริ่มต้นหลักคือ [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--), ซึ่งคืนค่าอ็อบเจ็กต์ [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) ด้วยอ็อบเจ็กต์นี้คุณสามารถตั้งค่าประเภทสัญลักษณ์หัวข้อ สัญลักษณ์ รูปภาพ สี ขนาด สไตล์การลำดับเลข และหมายเลขเริ่มต้นได้

บทความนี้แสดงวิธีการ:

- สร้างรายการสัญลักษณ์หัวข้อด้วยสัญลักษณ์ที่กำหนดเอง
- สร้างสัญลักษณ์หัวข้อรูปภาพ
- สร้างรายการหลายระดับโดยตั้งค่าความลึกของย่อหน้า
- สร้างรายการลำดับเลข
- ตรวจสอบและเปลี่ยนการจัดรูปแบบรายการในงานนำเสนอที่มีอยู่
- อ่านมาร์คเกอร์และหมายเลขรายการจริงพร้อมกับข้อความย่อหน้า

## **สร้างรายการสัญลักษณ์หัวข้อ**

เพื่อสร้างรายการสัญลักษณ์หัวข้อ ให้เพิ่มอ็อบเจ็กต์ [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) ไปยัง [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) และตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Symbol) จากนั้นคุณสามารถตั้งค่า [IBulletFormat.setChar](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setChar-char-), [IBulletFormat.getColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getColor--), และ [IBulletFormat.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setHeight-float-) เพื่อควบคุมลักษณะของสัญลักษณ์หัวข้อ

โค้ด Java ต่อไปนี้แสดงวิธีสร้างรายการสัญลักษณ์หัวข้อในสไลด์:

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

![สัญลักษณ์หัวข้อแบบสัญลักษณ์](symbol_bullets.png)

## **สร้างรายการลำดับเลข**

ใช้รายการลำดับเลขเมื่อลำดับของรายการมีความสำคัญ ตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Numbered) คุณยังสามารถเลือกรูปแบบการลำดับเลขด้วย [IBulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStyle-byte-) หรือกำหนดค่า [IBulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) เมื่อรายการควรเริ่มจากค่าที่ไม่ใช่ 1

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

![สัญลักษณ์หัวข้อแบบลำดับเลข](numbered_bullets.png)

## **สร้างสัญลักษณ์หัวข้อรูปภาพ**

Aspose.Slides อนุญาตให้คุณแทนที่สัญลักษณ์หัวข้อปกติด้วยรูปภาพ สัญลักษณ์หัวข้อรูปภาพทำงานได้ดีที่สุดกับภาพที่เรียบง่ายและยังคงอ่านได้ในขนาดเล็ก เช่น ไอคอนหรือไฟล์ PNG ที่โปร่งแสงขนาดเล็ก

{{% alert color="info" title="Note" %}}
โดยทั่วไป หากคุณวางแผนจะแทนที่สัญลักษณ์หัวข้อปกติด้วยรูปภาพ ควรเลือกกราฟิกที่เรียบง่ายพร้อมพื้นหลังโปร่งแสง ภาพเช่นนี้ทำงานได้ดีเป็นสัญลักษณ์หัวข้อแบบกำหนดเอง

ควรจำไว้ว่าภาพจะถูกย่อขนาดลงเป็นขนาดเล็กมาก ดังนั้นเราขอแนะนำอย่างยิ่งให้เลือกภาพที่ยังคมชัดและมีประสิทธิภาพในการแสดงผลเมื่อใช้เป็นสัญลักษณ์หัวข้อในรายการ
{{% /alert %}}

เพื่อสร้างสัญลักษณ์หัวข้อรูปภาพ ให้เพิ่มรูปภาพไปยัง [Presentation.getImages](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getImages--) และกำหนดอ็อบเจ็กต์ภาพที่ได้รับให้กับ [IBulletFormat.getPicture](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#getPicture--) ตั้งค่า [IBulletFormat.setType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setType-byte-) เป็น [BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/#Picture) ก่อนที่จะกำหนดภาพ

สมมติว่าเรามีไฟล์ "image.png":

![รูปภาพสำหรับสัญลักษณ์หัวข้อ](picture_for_bullets.png)

โค้ด Java ต่อไปนี้แสดงวิธีสร้างสัญลักษณ์หัวข้อรูปภาพในสไลด์:

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

![สัญลักษณ์หัวข้อรูปภาพ](picture_bullets.png)

## **สร้างรายการหลายระดับ**

ใช้ [IParagraphFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDepth-short-) เพื่อตำแหน่งรายการในระดับต่าง ๆ ระดับ 0 คือระดับบนสุด ระดับ 1 คือระดับย่อยใต้ระดับนั้น เป็นต้น

โค้ด Java ต่อไปนี้แสดงวิธีสร้างรายการสัญลักษณ์หัวข้อหลายระดับ:

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

เพื่อเปลี่ยนการจัดรูปแบบรายการในงานนำเสนอที่มีอยู่ ให้เข้าถึงย่อหน้าที่ต้องการและอัปเดตการตั้งค่า [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) ของมัน คุณสมบัติเดียวกันที่ใช้สร้างรายการสามารถใช้เพื่อตรวจสอบหรือแก้ไขรายการที่โหลดจากไฟล์ PPT, PPTX หรือ ODP ได้

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

## **อ่านค่าจริงของสัญลักษณ์หัวข้อ**

เมื่อแยกเนื้อหางานนำเสนอ ควรเก็บมาร์คเกอร์รายการพร้อมกับข้อความย่อหน้า เรียกใช้ [IParagraphFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getEffective--) และเข้าถึง [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) เพื่อรับรูปแบบสัญลักษณ์หัวข้อที่มีผล ตรวจสอบ [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) ก่อนอ่าน [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--)

สำหรับรายการลำดับเลข ให้แยกแยะค่าทั้งสามนี้:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) กำหนดรูปแบบ เช่น ตัวเลขอารบิกตามด้วยจุด หรืออักษรตัวพิมพ์เล็กตามด้วยจุด
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) ระบุหมายเลขเริ่มต้นสำหรับกลุ่มย่อหน้าลำดับเลข
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) คืนค่ามาร์คเกอร์ที่จัดรูปแบบสำหรับย่อหน้าที่กำหนด ตัวอย่าง รายการที่เริ่มที่ 5 รายการที่สองจะคืนค่า `6.`

รักษา [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDepth--) กับแต่ละย่อหน้าเพื่อคงระดับการซ้อนกันของมัน มาร์คเกอร์จริงไม่ได้เข้ารหัสโครงสร้างเต็ม: รายการซ้อนกันอาจคืนค่า `c.` แทนที่จะเป็นป้ายกำกับรวมเช่น `6.c.`

ตัวอย่างแยกส่วนต่อไปนี้สร้างรายการ บันทึกลงในงานนำเสนอ และโหลดงานนำเสนอใหม่เพื่อรายงานข้อความของแต่ละย่อหน้า ความลึก ประเภทสัญลักษณ์หัวข้อ และค่าจริง มาร์คเกอร์รูปภาพสีน้ำเงินขนาดเล็กสร้างจาก SVG ในบรรทัดเดียว

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // สร้างเครื่องหมายรูปภาพโดยไม่มีไฟล์รูปภาพภายนอก.
    SvgImage svg = new SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    IPPImage bulletImage = presentation.getImages().addImage(svg);

    class ListBuilder {
        void addParagraph(String text, short depth, byte type, short start, byte style) {
            Paragraph paragraph = new Paragraph();
            paragraph.setText(text);

            IParagraphFormat format = paragraph.getParagraphFormat();
            format.setDepth(depth);
            format.setMarginLeft(30 + depth * 40);
            format.setIndent(-28);
            format.setSpaceAfter(8);
            format.getDefaultPortionFormat().setFontHeight(22);
            format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
            format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
            format.getBullet().setType(type);
            format.getBullet().setBulletHardColor(NullableBool.True);
            format.getBullet().getColor().setColor(Color.BLACK);
            if (type == BulletType.Numbered) {
                format.getBullet().setNumberedBulletStyle(style);
                format.getBullet().setNumberedBulletStartWith(start);
            } else if (type == BulletType.Symbol) {
                format.getBullet().setChar('\u2022');
            } else if (type == BulletType.Picture) {
                format.getBullet().getPicture().setImage(bulletImage);
            }

            textFrame.getParagraphs().add(paragraph);
        }
    }

    ListBuilder list = new ListBuilder();
    list.addParagraph("First item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Second item", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Next nested item", (short) 1, BulletType.Numbered, (short) 3, NumberedBulletStyle.BulletAlphaLCPeriod);
    list.addParagraph("Deep item", (short) 2, BulletType.Numbered, (short) 4, NumberedBulletStyle.BulletRomanLCPeriod);
    list.addParagraph("Back to top level", (short) 0, BulletType.Numbered, (short) 5, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Symbol marker", (short) 0, BulletType.Symbol, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("No bullet", (short) 0, BulletType.None, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    list.addParagraph("Picture marker", (short) 0, BulletType.Picture, (short) 1, NumberedBulletStyle.BulletArabicPeriod);
    presentation.save("actual_bullet_values.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation loadedPresentation = new Presentation("actual_bullet_values.pptx");
try {
    IAutoShape loadedShape = (IAutoShape) loadedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    System.out.println("Text | Depth | Type | Actual value");
    for (IParagraph paragraph : loadedShape.getTextFrame().getParagraphs()) {
        IBulletFormatEffectiveData bullet = paragraph.getParagraphFormat().getEffective().getBullet();
        String marker;
        switch (bullet.getType()) {
            case BulletType.Numbered:
            case BulletType.Symbol:
                marker = bullet.getActualBulletValue();
                break;
            case BulletType.None:
                marker = bullet.getActualBulletValue() + " (no bullet)";
                break;
            case BulletType.Picture:
                marker = bullet.getActualBulletValue() + " (image required)";
                break;
            default:
                marker = "unsupported bullet type";
                break;
        }
        String typeName = BulletType.getName(BulletType.class, bullet.getType());
        System.out.println(paragraph.getText() + " | " + paragraph.getParagraphFormat().getDepth() + " | " + typeName + " | " + marker);
    }
} finally {
    loadedPresentation.dispose();
}
```

รายการต้นฉบับแสดงด้านล่าง.

![รายการที่เริ่มที่ 5, รายการย่อยอักษรและหมายเลขโรมัน, สัญลักษณ์, ย่อหน้าไม่มีสัญลักษณ์, และมาร์คเกอร์รูปภาพสีน้ำเงิน](actual_bullet_values.png)

รายงานตรงกับมาร์คเกอร์ที่แสดงใน PowerPoint:

```text
Text | Depth | Type | Actual value
First item | 0 | Numbered | 5.
Second item | 0 | Numbered | 6.
Nested item | 1 | Numbered | c.
Next nested item | 1 | Numbered | d.
Deep item | 2 | Numbered | iv.
Back to top level | 0 | Numbered | 7.
Symbol marker | 0 | Symbol | •
No bullet | 0 | None | null (no bullet)
Picture marker | 0 | Picture | null (image required)
```

สำหรับ [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/java/com.aspose.slides/bullettype/), [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) คืนค่า `null` ไม่ใช่สตริงว่าง ให้จัดการประเภทเหล่านี้แยกกัน: ประเภทแรกไม่มีมาร์คเกอร์ ส่วนประเภทที่สองต้องดึงรูปภาพสัญลักษณ์หัวข้อออกแยกต่างหาก ไม่สามารถสร้างสัญลักษณ์หัวข้อรูปภาพได้โดยอาศัยการดึงมาร์คเตอร์ข้อความเท่านั้น

## **คำถามที่พบบ่อย**

**รายการสัญลักษณ์หัวข้อและลำดับเลขสามารถส่งออกเป็น PDF หรือรูปภาพได้หรือไม่?**

ใช่ Aspose.Slides คงรูปแบบรายการเมื่อรูปแบบเป้าหมายสนับสนุนการจัดวางข้อความและคุณลักษณะสัญลักษณ์หัวข้อที่สอดคล้องกัน

**ฉันสามารถแก้ไขรายการในงานนำเสนอที่มีอยู่ได้หรือไม่?**

ใช่ โหลดงานนำเสนอ เข้าถึงย่อหน้าที่ต้องการ ตรวจสอบหรืออัปเดตการตั้งค่า [IParagraphFormat.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getBullet--) ของมัน แล้วบันทึกงานนำเสนอ

**รายการสามารถมีข้อความที่ไม่ใช่อักษรละตินได้หรือไม่?**

ใช่ ข้อความรายการสามารถมีอักขระ Unicode ดังนั้นคุณสามารถสร้างรายการในงานนำเสนอหลายภาษาได้ ตรวจสอบให้แน่ใจว่าแบบอักษรที่ใช้ในงานนำสนับสนุนอักขระที่คุณต้องการ