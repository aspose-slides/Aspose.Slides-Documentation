---
title: "จัดการรายการหัวข้อสัญลักษณ์และลำดับเลขในงานนำเสนอโดยใช้ JavaScript"
linktitle: "จัดการรายการ"
type: docs
weight: 60
url: /th/nodejs-java/manage-lists/
keywords:
- "หัวข้อสัญลักษณ์"
- "รายการหัวข้อสัญลักษณ์"
- "รายการลำดับเลข"
- "สัญลักษณ์หัวข้อ"
- "หัวข้อสัญลักษณ์แบบภาพ"
- "หัวข้อสัญลักษณ์ที่กำหนดเอง"
- "รายการหลายระดับ"
- "สร้างหัวข้อสัญลักษณ์"
- "เพิ่มหัวข้อสัญลักษณ์"
- "เพิ่มรายการ"
- "PowerPoint"
- "OpenDocument"
- "งานนำเสนอ"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "เรียนรู้วิธีสร้างและจัดรูปแบบรายการหัวข้อสัญลักษณ์, รายการหัวข้อสัญลักษณ์แบบภาพ, รายการหลายระดับและรายการลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument ด้วย Aspose.Slides for Node.js via Java."
---
## **ภาพรวม**

Aspose.Slides for Node.js via Java ให้คุณสร้างและจัดรูปแบบรายการแบบหัวข้อสัญลักษณ์และรายการลำดับเลขในงานนำเสนอ PowerPoint และ OpenDocument รายการหนึ่งเป็นย่อหน้าที่การตั้งค่าหัวข้อสัญลักษณ์ถูกควบคุมผ่านรูปแบบย่อหน้าของมัน

ใช้คลาส [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) เพื่อเข้าถึงการตั้งค่ารายการระดับย่อหน้า จุดเริ่มต้นหลักคือ `Paragraph.getParagraphFormat().getBullet()` ซึ่งจะคืนค่าอ็อบเจ็กต์ [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) ด้วยอ็อบเจ็กต์นี้คุณสามารถตั้งค่าชนิดของหัวข้อสัญลักษณ์, สัญลักษณ์, ภาพ, สี, ขนาด, รูปแบบการลำดับเลข, และหมายเลขเริ่มต้นได้

บทความนี้แสดงวิธี:

- สร้างรายการแบบหัวข้อสัญลักษณ์ด้วยสัญลักษณ์ที่กำหนดเอง
- สร้างหัวข้อสัญลักษณ์แบบภาพ
- สร้างรายการหลายระดับโดยการตั้งค่าความลึกของย่อหน้า
- สร้างรายการลำดับเลข
- ตรวจสอบและเปลี่ยนแปลงรูปแบบรายการในงานนำเสนอที่มีอยู่
- อ่านสัญลักษณ์รายการและหมายเลขจริงพร้อมกับข้อความย่อหน้า

## **สร้างรายการแบบหัวข้อสัญลักษณ์**

เพื่อสร้างรายการแบบหัวข้อสัญลักษณ์ ให้เพิ่มวัตถุ [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) ไปยัง [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) แล้วตั้งค่า `BulletFormat.setType` เป็น [BulletType.Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) แล้วคุณสามารถตั้งค่า `BulletFormat.setChar`, `BulletFormat.getColor` และ `BulletFormat.setHeight` เพื่อควบคุมรูปแบบหัวข้อสัญลักษณ์ได้

โค้ด JavaScript ต่อไปนี้สาธิตวิธีการสร้างรายการแบบหัวข้อสัญลักษณ์ในสไลด์:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createParagraph(text, bulletColor) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Symbol));
    bulletFormat.setChar(java.newChar("*"));
    paragraphFormat.setIndent(15);
    bulletFormat.setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    bulletFormat.getColor().setColor(bulletColor);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const bulletColor = java.newInstanceSync("java.awt.Color", 205, 92, 92);

    const paragraph1 = createParagraph("The first paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletColor);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("symbol_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![หัวข้อสัญลักษณ์](symbol_bullets.png)

## **สร้างรายการลำดับเลข**

ใช้รายการลำดับเลขเมื่อลำดับของรายการมีความสำคัญ ตั้งค่า `BulletFormat.setType` เป็น [BulletType.Numbered](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) คุณยังสามารถเลือกรูปแบบตัวเลขด้วย `BulletFormat.setNumberedBulletStyle` หรือกำหนดค่า `BulletFormat.setNumberedBulletStartWith` เมื่อรายการควรเริ่มจากค่าที่ไม่ใช่ 1

โค้ด JavaScript ต่อไปนี้แสดงวิธีการสร้างรายการลำดับเลขในสไลด์:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 90, 80);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph1.setText("Apple");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph2.setText("Orange");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    paragraph3.setText("Banana");
    textFrame.getParagraphs().add(paragraph3);

    presentation.save("numbered_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![หัวข้อรายการลำดับเลข](numbered_bullets.png)

## **สร้างหัวข้อสัญลักษณ์แบบภาพ**

Aspose.Slides อนุญาตให้คุณแทนที่สัญลักษณ์หัวข้อสัญลักษณ์ปกติกับภาพ หัวข้อสัญลักษณ์แบบภาพทำงานได้ดีที่สุดกับภาพที่เรียบง่ายซึ่งยังคงอ่านได้เมื่อตรงขนาดเล็ก เช่น ไอคอนหรือไฟล์ PNG ที่มีพื้นหลังโปร่งแสง

{{% alert color="info" title="Note" %}}
โดย理想 หากคุณวางแผนที่จะแทนที่สัญลักษณ์หัวข้อสัญลักษณ์ปกติกับภาพ ควรเลือกกราฟิกที่เรียบง่ายพร้อมพื้นหลังโปร่งแสง รูปภาพเช่นนี้ทำงานได้ดีเป็นสัญลักษณ์หัวข้อสัญลักษณ์แบบกำหนดเอง

โปรดจำไว้ว่า ภาพจะถูกย่อให้มีขนาดเล็กมาก ดังนั้นเราขอแนะนำอย่างยิ่งให้เลือกภาพที่ยังคงคมชัดและมีประสิทธิภาพเชิงสายตาเมื่อนำไปใช้เป็นหัวข้อสัญลักษณ์ในรายการ
{{% /alert %}}

เพื่อสร้างหัวข้อสัญลักษณ์แบบภาพ ให้เพิ่มภาพลงใน [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) ด้วย `Presentation.getImages().addImage` แล้วกำหนดอ็อบเจ็กต์ [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) ที่ได้ให้กับ `BulletFormat.getPicture().setImage` ตั้งค่า `BulletFormat.setType` เป็น [BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) ก่อนกำหนดภาพ

สมมติว่าเรามีไฟล์ "image.png":

![ภาพสำหรับหัวข้อสัญลักษณ์](picture_for_bullets.png)

โค้ด JavaScript ต่อไปนี้แสดงวิธีการสร้างหัวข้อสัญลักษณ์แบบภาพในสไลด์:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function createParagraph(text, image) {
    const paragraph = new aspose.slides.Paragraph();
    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Picture));
    bulletFormat.getPicture().setImage(image);
    paragraphFormat.setIndent(15);
    bulletFormat.setHeight(100);
    paragraph.setText(text);

    return paragraph;
}

const presentation = new aspose.slides.Presentation();
let image = null;
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 50);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    image = aspose.slides.Images.fromFile("image.png");
    const bulletImage = presentation.getImages().addImage(image);

    const paragraph1 = createParagraph("The first paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = createParagraph("The second paragraph", bulletImage);
    textFrame.getParagraphs().add(paragraph2);

    presentation.save("picture_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (image !== null) {
        image.dispose();
    }
    presentation.dispose();
}
```

ผลลัพธ์:

![หัวข้อสัญลักษณ์แบบภาพ](picture_bullets.png)

## **สร้างรายการหลายระดับ**

ใช้ `ParagraphFormat.setDepth` เพื่อวางรายการในระดับที่แตกต่างกัน ระดับ 0 คือระดับบนสุด ระดับ 1 อยู่ด้านล่างของระดับนั้นและต่อไป

โค้ด JavaScript ต่อไปนี้แสดงวิธีการสร้างรายการหัวข้อสัญลักษณ์หลายระดับ:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 260, 110);

    const textFrame = autoShape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph1 = new aspose.slides.Paragraph();
    paragraph1.getParagraphFormat().setDepth(java.newShort(0));
    paragraph1.setText("My text - Depth 0");
    textFrame.getParagraphs().add(paragraph1);

    const paragraph2 = new aspose.slides.Paragraph();
    paragraph2.getParagraphFormat().setDepth(java.newShort(1));
    paragraph2.setText("My text - Depth 1");
    textFrame.getParagraphs().add(paragraph2);

    const paragraph3 = new aspose.slides.Paragraph();
    paragraph3.getParagraphFormat().setDepth(java.newShort(2));
    paragraph3.setText("My text - Depth 2");
    textFrame.getParagraphs().add(paragraph3);

    const paragraph4 = new aspose.slides.Paragraph();
    paragraph4.getParagraphFormat().setDepth(java.newShort(3));
    paragraph4.setText("My text - Depth 3");
    textFrame.getParagraphs().add(paragraph4);

    presentation.save("multilevel_bullets.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![รายการหลายระดับ](multilevel_list.png)

## **เปลี่ยนรายการที่มีอยู่**

เพื่อเปลี่ยนรูปแบบรายการในงานนำเสนอที่มีอยู่ ให้เข้าถึงย่อหน้าที่ต้องการและอัปเดตการตั้งค่า `ParagraphFormat.getBullet` คุณสามารถใช้คุณสมบัติเดียวกันที่ใช้สร้างรายการเพื่อสำรวจหรือแก้ไขรายการที่โหลดจากไฟล์ PPT, PPTX หรือ ODP

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    const paragraphFormat = paragraph.getParagraphFormat();
    const bulletFormat = paragraphFormat.getBullet();

    bulletFormat.setType(java.newByte(aspose.slides.BulletType.Numbered));
    bulletFormat.setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletRomanUCPeriod));
    bulletFormat.setNumberedBulletStartWith(java.newShort(1));
    paragraphFormat.setMarginLeft(30);
    paragraphFormat.setIndent(-20);

    presentation.save("updated_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **อ่านค่าหัวข้อสัญลักษณ์จริง**

เมื่อสกัดเนื้อหางานนำเข้า ให้เก็บสัญลักษณ์รายการไว้พร้อมกับข้อความย่อหน้า เรียกใช้ [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective) แล้วเข้าถึง [IParagraphFormatEffectiveData.getBullet](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformateffectivedata/#getBullet--) เพื่อรับรูปแบบหัวข้อสัญลักษณ์ที่มีผล ตรวจสอบ [getType](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getType--) ก่อนอ่าน [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--)

สำหรับรายการลำดับเลข ให้แยกแยะค่าทั้งสามนี้:

- [getNumberedBulletStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStyle--) กำหนดรูปแบบ เช่น ตัวเลขอารบิกตามด้วยจุดหรืออักษรตัวพิมพ์เล็กตามด้วยจุด
- [getNumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getNumberedBulletStartWith--) ระบุหมายเลขเริ่มต้นสำหรับกลุ่มของย่อหน้าลำดับเลข
- [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) คืนค่าตัวบ่งชี้ที่จัดรูปแบบสำหรับย่อหน้านั้น ตัวอย่าง ย่อหน้าที่สองในรายการที่เริ่มจาก 5 จะคืนค่า `6.`

คงค่า [getDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDepth) ไว้กับแต่ละย่อหน้าเพื่อรักษาระดับการซ้อนกันของมัน ตัวบ่งชี้จริงไม่ได้เข้ารหัสโครงสร้างลำดับชั้นทั้งหมด: รายการย่อยอาจคืนค่า `c.` แทนที่จะเป็นป้ายรวมเช่น `6.c.`

ตัวอย่างอิสระต่อไปนี้สร้างรายการ เก็บไว้ในงานนำเสนอ และโหลดงานนำเสนอใหม่เพื่อรายงานข้อความย่อหน้า ความลึก ประเภทหัวข้อสัญลักษณ์ และค่าจริงของแต่ละรายการ สัญลักษณ์รูปภาพสีน้ำเงินขนาดเล็กสร้างจาก SVG ในบรรทัดข้อความ

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);

const presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 440, aspose.slides.SlideSizeScaleType.DoNotScale);
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20, 660, 400);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    // สร้างเครื่องหมายรูปภาพโดยไม่ต้องใช้ไฟล์รูปภาพภายนอก.
    const svg = new aspose.slides.SvgImage("<svg xmlns='http://www.w3.org/2000/svg' width='16' height='16'><rect width='16' height='16' rx='4' fill='#0078D4'/></svg>");
    const bulletImage = presentation.getImages().addImage(svg);

    function addParagraph(text, depth, type, start, style) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.setText(text);

        const format = paragraph.getParagraphFormat();
        format.setDepth(java.newShort(depth));
        format.setMarginLeft(30 + depth * 40);
        format.setIndent(-28);
        format.setSpaceAfter(8);
        format.getDefaultPortionFormat().setFontHeight(22);
        format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(black);
        format.getBullet().setType(java.newByte(type));
        format.getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
        format.getBullet().getColor().setColor(black);
        if (type === aspose.slides.BulletType.Numbered) {
            format.getBullet().setNumberedBulletStyle(java.newByte(style));
            format.getBullet().setNumberedBulletStartWith(java.newShort(start));
        } else if (type === aspose.slides.BulletType.Symbol) {
            format.getBullet().setChar(java.newChar(0x2022));
        } else if (type === aspose.slides.BulletType.Picture) {
            format.getBullet().getPicture().setImage(bulletImage);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    addParagraph("First item", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Second item", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Nested item", 1, aspose.slides.BulletType.Numbered, 3, aspose.slides.NumberedBulletStyle.BulletAlphaLCPeriod);
    addParagraph("Next nested item", 1, aspose.slides.BulletType.Numbered, 3, aspose.slides.NumberedBulletStyle.BulletAlphaLCPeriod);
    addParagraph("Deep item", 2, aspose.slides.BulletType.Numbered, 4, aspose.slides.NumberedBulletStyle.BulletRomanLCPeriod);
    addParagraph("Back to top level", 0, aspose.slides.BulletType.Numbered, 5, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Symbol marker", 0, aspose.slides.BulletType.Symbol, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("No bullet", 0, aspose.slides.BulletType.None, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    addParagraph("Picture marker", 0, aspose.slides.BulletType.Picture, 1, aspose.slides.NumberedBulletStyle.BulletArabicPeriod);
    presentation.save("actual_bullet_values.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const loadedPresentation = new aspose.slides.Presentation("actual_bullet_values.pptx");
try {
    const loadedShape = loadedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Text | Depth | Type | Actual value");
    const paragraphs = loadedShape.getTextFrame().getParagraphs();
    for (let i = 0; i < paragraphs.getCount(); i++) {
        const paragraph = paragraphs.get_Item(i);
        const bullet = paragraph.getParagraphFormat().getEffective().getBullet();
        let marker;
        switch (bullet.getType()) {
            case aspose.slides.BulletType.Numbered:
            case aspose.slides.BulletType.Symbol:
                marker = bullet.getActualBulletValue();
                break;
            case aspose.slides.BulletType.None:
                marker = bullet.getActualBulletValue() + " (no bullet)";
                break;
            case aspose.slides.BulletType.Picture:
                marker = bullet.getActualBulletValue() + " (image required)";
                break;
            default:
                marker = "unsupported bullet type";
                break;
        }
        const typeName = Object.keys(aspose.slides.BulletType).find(name => aspose.slides.BulletType[name] === bullet.getType());
        console.log(paragraph.getText() + " | " + paragraph.getParagraphFormat().getDepth() + " | " + typeName + " | " + marker);
    }
} finally {
    loadedPresentation.dispose();
}
```

รายการต้นฉบับแสดงด้านล่าง

![รายการที่เริ่มจาก 5, รายการย่อยเป็นตัวอักษรและเลขโรมัน, สัญลักษณ์แบบสัญลักษณ์, ย่อหน้าไม่มีหัวข้อสัญลักษณ์, และสัญลักษณ์รูปภาพสีน้ำเงิน](actual_bullet_values.png)

รายงานตรงกับสัญลักษณ์ที่แสดงใน PowerPoint:

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

สำหรับ [BulletType.None and BulletType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bullettype/) [getActualBulletValue](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformateffectivedata/#getActualBulletValue--) คืนค่า `null` ไม่ใช่สตริงว่าง ให้จัดการประเภทเหล่านี้แยกกัน: ตัวแรกไม่มีสัญลักษณ์ ส่วนตัวหลังต้องดึงภาพหัวข้อสัญลักษณ์ออกแยกต่างหาก หัวข้อสัญลักษณ์แบบภาพไม่สามารถทำซ้ำได้โดยการดึงสัญลักษณ์ข้อความเพียงอย่างเดียว

## **คำถามที่พบบ่อย**

**สามารถส่งออกรายการแบบหัวข้อสัญลักษณ์และลำดับเลขเป็น PDF หรือรูปภาพได้หรือไม่?**

ได้ Aspose.Slides รักษารูปแบบรายการเมื่อรูปแบบเป้าหมายรองรับการจัดวางข้อความและคุณสมบัตหัวข้อสัญลักษณ์ที่สอดคล้องกัน

**ฉันสามารถแก้ไขรายการในงานนำเสนอที่มีอยู่ได้หรือไม่?**

ได้ โหลดงานนำเสนอเข้ามาเข้าถึงย่อหน้าที่ต้องการ ตรวจสอบหรืออัปเดตการตั้งค่า `ParagraphFormat.getBullet` แล้วบันทึกงานนำเสนอ

**รายการสามารถประกอบด้วยข้อความที่ไม่ใช่ละตินได้หรือไม่?**

ได้ ข้อความของรายการสามารถมีอักขระยูนิโค้ดได้ ดังนั้นคุณสามารถสร้างรายการในงานนำเสนอหลายภาษาตามต้องการ ตรวจสอบให้แน่ใจว่าแบบอักษรที่ใช้ในงานนำเสนอรองรับอักขระที่คุณต้องการ