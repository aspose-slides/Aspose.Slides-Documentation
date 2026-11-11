---
title: จัดการย่อข้อความ PowerPoint ใน JavaScript
linktitle: จัดการย่อหน้า
type: docs
weight: 40
url: /th/nodejs-java/manage-paragraph/
aliases:
  - /nodejs-java/paragraph/
  - /nodejs-java/portion/
keywords:
- เพิ่มข้อความ
- เพิ่มย่อหน้า
- จัดการข้อความ
- จัดการย่อหน้า
- จัดการหัวข้อรายการ
- การเยื้องย่อหน้า
- การเยื้องห้อย
- หัวข้อรายการย่อหน้า
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
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและกำหนดรูปแบบย่อหน้า, ส่วนย่อย, หัวข้อรายการ, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML, และรูปภาพย่อหน้าด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides สำหรับ Node.js ผ่าน Java แสดงข้อความเป็นโครงสร้างชั้นของกรอบข้อความ, ย่อหน้า, และส่วนย่อย:

* [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) เป็นตัวบรรจุข้อความในรูปทรงและให้เข้าถึงคอลเลกชันย่อหน้า
* [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) แสดงย่อหน้าเดียวในกรอบข้อความและให้เข้าถึงส่วนย่อยและการกำหนดรูปแบบระดับย่อหน้า
* [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) เป็นการทำงานของข้อความภายในย่อหน้า แต่ละส่วนย่อยสามารถมีข้อความและการกำหนดรูปแบบระดับอักขระของตนเองได้

ย่อหน้าจึงสามารถบรรจุข้อความที่มีแบบอักษร, สี, ขนาด, และการกำหนดรูปแบบอื่น ๆ ที่แตกต่างกันโดยใช้หลายส่วนย่อย

## **สร้างและกำหนดรูปแบบย่อหน้า**

สร้างย่อหน้าในกรอบข้อความของรูปทรงและใช้ส่วนย่อยเพื่อกำหนดรูปแบบการทำงานของข้อความแต่ละส่วน ข้อความนี้แสดงวิธีรวมหลายส่วนย่อยภายในแต่ละย่อหน้าและใช้สี, ขนาดแบบอักษร, และสไตล์ที่ต่างกัน

### **สร้างย่อหน้าด้วยหลายส่วนย่อย**

ตัวอย่าง JavaScript ต่อไปนี้สร้างย่อหน้า 3 ย่อหน้า แต่ละย่อหน้าเป็นส่วนย่อยข้อความ 3 ส่วนในคอลเลกชันที่ส่งกลับโดย [Paragraph.getPortions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getportions/) มันใช้ย่อหน้าเริ่มต้นและส่วนย่อยว่างเปล่าของมันซ้ำ แล้วเพิ่มย่อหน้าและส่วนย่อยที่เหลือ การกำหนดรูปแบบทำผ่าน [Portion.getPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getportionformat/) ส่วนแรกในแต่ละย่อหน้าเป็นสีแดง, หนา, ขนาด 15 จุด; ส่วนที่สองเป็นสีน้ำเงิน, ตัวเอียง, ขนาด 18 จุด; ส่วนที่สามคงรูปแบบเริ่มต้นไว้:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    const textFrame = shape.getTextFrame();

    const firstParagraph = textFrame.getParagraphs().get_Item(0);
    firstParagraph.getPortions().add(new aspose.slides.Portion());
    firstParagraph.getPortions().add(new aspose.slides.Portion());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    secondParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    thirdParagraph.getPortions().add(new aspose.slides.Portion());
    textFrame.getParagraphs().add(thirdParagraph);

    const paragraphCount = textFrame.getParagraphs().getCount();
    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
        const portionCount = paragraph.getPortions().getCount();
        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = paragraph.getPortions().get_Item(portionIndex);
            portion.setText("Portion " + (paragraphIndex + 1) + "." + (portionIndex + 1));

            if (portionIndex === 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(15);
            } else if (portionIndex === 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    presentation.save("paragraphs_with_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **สร้างรายการแบบหัวข้อและลำดับเลข**

จัดระเบียบข้อความย่อหน้าเป็นรายการโดยใช้สัญลักษณ์, ตัวเลข, หรือรูปภาพแบบกำหนดเอง ตัวอย่างในส่วนนี้ครอบคลุมการกำหนดรูปแบบหัวข้อ, รายการหลายระดับ, และตัวเลขเริ่มต้นแบบกำหนดเอง

### **สร้างรายการหัวข้อหรือรายการลำดับเลข**

หัวข้อและการตั้งหมายเลขทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการถูกกำหนดผ่าน [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/)

ตัวอย่าง JavaScript นี้เพิ่มหัวข้อสัญลักษณ์และรายการลำดับเลขในกรอบข้อความเดียวกัน [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) เลือกประเภทหัวข้อ, ขณะที่ [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) ระบุสัญลักษณ์และ [BulletFormat.setNumberedBulletStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstyle/) เลือกสไตล์การลำดับเลข รายการทั้งสองใช้หัวข้อสีดำ มีความสูง 100% และเยื้องย่อหน้า 25 จุด:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const symbolParagraph = new aspose.slides.Paragraph();
    symbolParagraph.setText("Welcome to Aspose.Slides");
    symbolParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    symbolParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    symbolParagraph.getParagraphFormat().setIndent(25);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    symbolParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    symbolParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    symbolParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(symbolParagraph);

    const numberedParagraph = new aspose.slides.Paragraph();
    numberedParagraph.setText("This is a numbered item");
    numberedParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    numberedParagraph.getParagraphFormat().getBullet().setNumberedBulletStyle(java.newByte(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain));
    numberedParagraph.getParagraphFormat().setIndent(25);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    numberedParagraph.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    numberedParagraph.getParagraphFormat().getBullet().setBulletHardColor(java.newByte(aspose.slides.NullableBool.True));
    numberedParagraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(numberedParagraph);

    presentation.save("bulleted_and_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ใช้หัวข้อรูปภาพ**

หัวข้อรูปภาพทำให้คุณใช้รูปภาพกำหนดเองแทนสัญลักษณ์หรือหมายเลข

ตัวอย่าง JavaScript นี้โหลด `image.png` จากไดเรกทอรีทำงานของแอปพลิเคชัน, เพิ่มรูปภาพไปยังคอลเลกชันรูปภาพของงานนำเสนอเป็น [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) และใช้เป็นหัวข้อย่อหน้า มันเรียก [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) เพื่อใช้หัวข้อรูปภาพและกำหนดรูปภาพผ่าน [BulletFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/getpicture/) [BulletFormat.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setheight/) ตั้งค่าเป็น 100% เพื่อกำหนดขนาดหัวข้อสัมพันธ์กับข้อความย่อหน้า:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const bulletImage = aspose.slides.Images.fromFile("image.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(bulletImage);
    } finally {
        bulletImage.dispose();
    }

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    paragraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Picture));
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(presentationImage);
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    textFrame.getParagraphs().add(paragraph);

    presentation.save("picture_bullet.pptx", aspose.slides.SaveFormat.Pptx);
    presentation.save("picture_bullet.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

### **สร้างรายการหลายระดับ**

ตั้งค่า [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) เพื่อจัดย่อหน้าให้อยู่ที่ระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึก `0`

ตัวอย่าง JavaScript นี้กำหนดค่า [ParagraphFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setdepth/) จาก 0 ถึง 3 ให้กับย่อหน้า 4 ย่อหน้า สร้างโครงสร้างชั้นภายในกรอบข้อความเดียวกัน ย่อหน้าแต่ละข้อใช้หัวข้อสัญลักษณ์, โดย [BulletFormat.setChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setchar/) สลับระหว่างหัวข้อกลมและขีดเพื่อแยกระดับที่อยู่ถัดกัน:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Content");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    firstParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setDepth(java.newShort(0));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Second level");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    secondParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setDepth(java.newShort(1));

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Third level");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    thirdParagraph.getParagraphFormat().getBullet().setChar(java.newChar(0x2022));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setDepth(java.newShort(2));

    const fourthParagraph = new aspose.slides.Paragraph();
    fourthParagraph.setText("Fourth level");
    fourthParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    fourthParagraph.getParagraphFormat().getBullet().setChar(java.newChar(45));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    fourthParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    fourthParagraph.getParagraphFormat().setDepth(java.newShort(3));

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);
    textFrame.getParagraphs().add(fourthParagraph);

    presentation.save("multilevel_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **เริ่มรายการลำดับเลขด้วยค่ากำหนดเอง**

ใช้ [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) เพื่อกำหนดหมายเลขเริ่มต้นที่แสดงสำหรับย่อหน้าลำดับเลข

ตัวอย่าง JavaScript นี้ตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/settype/) ให้ใช้การลำดับเลขสำหรับย่อหน้า 3 ตัวและกำหนดค่า [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) เป็น 2, 3, และ 7 ค่าที่เริ่มต้นถูกตั้งแยกตามแต่ละย่อหน้า ทำให้หมายเลขที่แสดงข้ามค่าได้:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("Start at 2");
    firstParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    firstParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(2));
    textFrame.getParagraphs().add(firstParagraph);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Start at 3");
    secondParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    secondParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(3));
    textFrame.getParagraphs().add(secondParagraph);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("Start at 7");
    thirdParagraph.getParagraphFormat().getBullet().setType(java.newByte(aspose.slides.BulletType.Numbered));
    thirdParagraph.getParagraphFormat().getBullet().setNumberedBulletStartWith(java.newShort(7));
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("custom_numbered_list.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ควบคุมการจัดวางย่อหน้าและคุณสมบัติสิ้นสุด**

ปรับระยะขอบและเยื้องของย่อหน้าเพื่อควบคุมตำแหน่งของบรรทัดแรกและบรรทัดที่ตัดบรรทัด คุณยังสามารถกำหนดรูปแบบเครื่องหมายสิ้นสุดของย่อหน้าแยกจากส่วนข้อความที่มองเห็นได้

### **ตั้งค่าเยื้องบรรทัดแรก**

ใช้เมธอด [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) เพื่อควบคุมเยื้องบรรทัดแรกของย่อหน้า การตั้งค่านี้จะย้ายบรรทัดแรกเท่านั้นตามระยะห่างจากขอบซ้ายของย่อหน้า ค่าบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือคงอยู่ตามแนวของเนื้อย่อหน้า

ใช้ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ใช้ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) เมื่อคุณต้องการย้ายบรรทัดแรกเท่านั้น

ตัวอย่างต่อไปนี้ให้ย่อหน้า 3 ย่อหน้ามี [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) ที่ 20 จุด และค่า [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) ที่ 0, 20, และ 40 จุด บรรทัดแรกเริ่มที่ระยะห่างที่เพิ่มขึ้นเรื่อย ๆ ขณะที่บรรทัดตัดต่อคงระยะขอบซ้ายเท่าเดิม:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    const thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งค่าเยื้องห้อย**

เยื้องห้อยคือการจัดวางย่อหน้าโดยที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วยเมธอด [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) ตั้งค่าเยื้องเป็นค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายสัมพันธ์กับเนื้อย่อหน้า

โดยปฏิบัติ, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) กำหนดตำแหน่งซ้ายของเนื้อย่อหน้า, และ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) กำหนดตำแหน่งของบรรทัดแรกสัมพันธ์กับขอบซ้ายนั้น เพื่อสร้างเยื้องห้อยให้ตั้งขอบซ้ายเป็นค่าบวกและเยื้องเป็นค่าลบ

การกำหนดรูปแบบนี้เป็นประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการอภิธานศัพท์, และย่อหน้าอื่น ๆ ที่ต้องการให้บรรทัดตัดต่อจัดชิดกับเนื้อย่อหน้าแทนที่จะชิดกับอักขระแรกของบรรทัดแรก

ตัวอย่าง JavaScript ต่อไปนี้จับคู่ค่า [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) ที่ 40 และ 60 จุด กับค่า [ParagraphFormat.setIndent](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setindent/) ที่ -20 และ -30 จุด ในแต่ละย่อหน้า บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่ตัดต่อ; ย่อหน้าที่สองมีเยื้องห้อยลึกขึ้น:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![เยื้องห้อยของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติรันสิ้นสุดของย่อหน้า**

เมธอด [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) ควบคุมการกำหนดรูปแบบของเครื่องหมายสิ้นสุดย่อหน้า ตัวอย่างต่อไปนี้สร้าง [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/) ที่มี [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) ตั้งเป็น 48 จุดและ [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLatinFont) ตั้งเป็น Times New Roman จากนั้นกำหนดรูปแบบนี้ให้กับเครื่องหมายสิ้นสุดของย่อหน้าที่สองโดยไม่กระทบต่อส่วนข้อความที่มองเห็นได้:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    const textFrame = shape.getTextFrame();
    textFrame.getParagraphs().clear();

    const firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getPortions().add(new aspose.slides.Portion("Sample text"));

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getPortions().add(new aspose.slides.Portion("Sample text 2"));

    const endParagraphFormat = new aspose.slides.PortionFormat();
    endParagraphFormat.setFontHeight(48);
    endParagraphFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    secondParagraph.setEndParagraphPortionFormat(endParagraphFormat);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("end_paragraph_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **นับจำนวนบรรทัดที่เรนเดอร์**

สำหรับกฎของย่อหน้าที่ส่งผลต่อการตัดบรรทัดอัตโนมัติและเครื่องหมายวรรคตอนที่ตำแหน่งสุดท้ายของบรรทัด ดู [Control Line Breaking](/slides/th/nodejs-java/text-formatting/#control-line-breaking) และ [Control Hanging Punctuation](/slides/th/nodejs-java/text-formatting/#control-hanging-punctuation)

ใช้ [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) เพื่อคืนค่าจำนวนบรรทัดที่ย่อหน้าครอบครองหลังจากการวางตำแหน่งข้อความรวมถึงการตัดบรรทัดอัตโนมัติ สิ่งนี้มีประโยชน์เมื่อทำการตรวจสอบความยาวข้อความและการจัดวางในเทมเพลตพรีเซนเทชั่น

ย่อหน้าเป็นรายการหนึ่งใน [TextFrame.getParagraphs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/getparagraphs/) และอาจครอบคลุมหลายบรรทัดที่เรนเดอร์ การใส่การตัดบรรทัดโดยชัดเจนภายในย่อหน้าจะบังคับให้ขึ้นบรรทัดใหม่โดยไม่สร้างย่อหน้าใหม่ การตัดบรรทัดอัตโนมัติสร้างบรรทัดตามความกว้างที่มีโดยไม่แทรกอักขระตัดบรรทัดลงในข้อความ ดังนั้นการนับจำนวนย่อหน้าหรืออักขระตัดบรรทัดจึงไม่ให้จำนวนบรรทัดที่เรนเดอร์ได้

ตัวอย่างต่อไปนี้สร้างรูปทรงข้อความ, นับบรรทัดของมัน, ลดความกว้างของรูปทรง, แล้วแทนที่ข้อความด้วยสตริงสั้นกว่า ตัวอย่างเปิดใช้การตัดบรรทัดด้วย [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) และปิดการปรับขนาดอัตโนมัติด้วย [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setautofittype/) เพื่อให้ความกว้างของรูปทรงควบคุมการตัดบรรทัดโดยไม่ย่อข้อความหรือปรับขนาดรูปทรงโดยอัตโนมัติ การวัดแต่ละครั้งใช้ [Paragraph.getLinesCount](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getLinesCount) มิติของรูปทรงเป็นหน่วยจุด ในที่สุดตัวอย่างเพิ่มย่อหน้าอีกหนึ่งย่อหน้าและรวมจำนวนบรรทัดทั้งหมดของกรอบข้อความ:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 200);
    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    paragraph.setText("This text demonstrates how automatic wrapping changes the number of rendered lines.");
    console.log("Original width: " + paragraph.getLinesCount());

    shape.setWidth(150);
    console.log("Narrower shape: " + paragraph.getLinesCount());

    paragraph.setText("Short text.");
    console.log("Shorter text: " + paragraph.getLinesCount());

    const secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.setText("Another paragraph.");
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(20);
    textFrame.getParagraphs().add(secondParagraph);

    let totalLineCount = 0;
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const currentParagraph = textFrame.getParagraphs().get_Item(i);
        totalLineCount += currentParagraph.getLinesCount();
    }
    console.log("Total lines in the text frame: " + totalLineCount);
} finally {
    presentation.dispose();
}
```

ด้วยข้อความและมิติเหล่านี้ การลดความกว้างของรูปทรงจะเพิ่มจำนวนบรรทัด, ขณะที่การแทนที่ข้อความด้วยสตริงสั้นจะลดจำนวนบรรทัด จำนวนที่แน่นอนอาจแตกต่างตามความพร้อมใช้งานของแบบอักษรและการแทนที่, ขนาดแบบอักษร, ระยะขอบ, ระยะเยื้อง, การตัดบรรทัด, และการตั้งค่าการปรับขนาดอัตโนมัติ ใช้แบบอักษรและการตั้งค่าการจัดวางที่กำหนดสำหรับสภาพแวดล้อมเป้าหมายเมื่อทำการตรวจสอบเทมเพลต

จำนวนบรรทัดเพียงอย่างเดียวไม่ได้กำหนดว่าข้อความจะล้นคอนเทนเนอร์หรือไม่ ความสูงที่ใช้ได้, ความสูงของบรรทัด, ระยะห่างระหว่างย่อหน้าและบรรทัด, และพฤติกรรมการปรับขนาดอัตโนมัติทั้งหมดมีผล; แม้บรรทัดเดียวก็อาจเกินความกว้างที่ใช้ได้เมื่อปิดการตัดบรรทัด

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

ใช้ HTML เพื่อนำข้อความเข้าสู่พรีเซนเทชั่นหรือส่งออกย่อหน้าที่มีอยู่เพื่อใช้งานภายนอก ส่วนนี้ยังแสดงวิธีเรนเดอร์ย่อหน้าแต่ละรายการเป็นรูปภาพ รวมถึงย่อหน้าในเซลล์ตารางด้วย

### **นำเข้า HTML เป็นข้อความในย่อหน้า**

ใช้ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) เพื่อแปลงมาร์กอัป HTML เป็นย่อหน้าและส่วนย่อยในกรอบข้อความ

ตัวอย่าง JavaScript นี้อ่าน HTML จาก `file.html` ในไดเรกทอรีทำงานของแอปพลิเคชันและส่งมาร์กอัปไปยัง [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) มันลบย่อหน้าเริ่มต้นของกรอบข้อความเพื่อให้กรอบมีเฉพาะเนื้อหาที่นำเข้า รูปทรงสี่เหลี่ยมทำให้มีขอบ 10 จุดในแต่ละด้านของสไลด์:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = fs.readFileSync("file.html", "utf8");
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ส่งออกข้อความย่อหน้าเป็น HTML**

ใช้ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) เพื่อส่งออกช่วงย่อหน้าที่เลือกเป็น HTML เมื่อใช้ข้อความพรีเซนเทชั่นบนเว็บไซต์ คุณอาจต้องการรักษาการเน้นในระดับท้องถิ่นโดยไม่ต้องนำฟอนต์, ขนาด, หรือสไตล์กล่องข้อความของพรีเซนเทชั่นไปด้วย ตั้งค่า [TextToHtmlConversionOptions.setTextInheritanceLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/settextinheritancelimit/) เพื่อควบคุมว่าตัวแปลงจะสืบทอดการกำหนดรูปแบบไกลแค่ไหน

ดาวน์โหลด [ตัวอย่างพรีเซนเทชั่น](text-inheritance.pptx) แล้ววางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกมีรูปทรงข้อความที่มีข้อความ "Inherited text; explicit red 18pt" อินพุตมีการใช้หลายระดับของการกำหนดรูปแบบอย่างเจตนา:

- สไตล์ข้อความเริ่มต้นของพรีเซนเทชั่นใช้ Calibri ขนาด 28 pt
- สไตล์ข้อความระดับแรกของกรอบข้อความใช้ข้อความสีน้ำเงินและตัวเอียง
- ย่อหน้ากำหนดข้อความหนาอย่างชัดเจน
- ส่วนที่สอง "explicit red 18pt" กำหนดข้อความสีแดงและขนาด 18 pt อย่างชัดเจน

ตัวอย่างเต็มต่อไปนี้ส่งออกย่อหน้าเดียวกันสามครั้ง มันส่งผ่าน [TextToHtmlConversionOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/) ไปยังเมธอดส่งออกและเขียนผลลัพธ์แต่ละอันเป็นไฟล์ HTML UTF-8 แยกกัน:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("text-inheritance.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();

            const modes = [aspose.slides.TextInheritanceLimit.All, aspose.slides.TextInheritanceLimit.TextBox, aspose.slides.TextInheritanceLimit.ParagraphOnly];
            const fileNames = ["All.html", "TextBox.html", "ParagraphOnly.html"];

            for (let i = 0; i < modes.length; i++) {
                const options = new aspose.slides.TextToHtmlConversionOptions();
                options.setTextInheritanceLimit(modes[i]);

                const html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
                fs.writeFileSync(fileNames[i], html, "utf8");
            }
        } else {
            console.log("The first shape does not contain a text frame.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

HTML ที่สร้างมี CSS ต่อไปนี้สำหรับส่วนแรก "Inherited text; " ตารางแสดงการประกาศที่เกี่ยวข้อง; คุณสมบัติเพิ่มเติมที่สร้างจะถูกละเว้นเพื่อความกระชับ

| ผลลัพธ์ | CSS ที่เกี่ยวข้องสำหรับส่วนแรก | ลักษณะการแสดงผล |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีน้ำเงิน, หนา, ตัวเอียง ขนาด 28 pt ใน Calibri หากฟอนต์พร้อมใช้งาน |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | ข้อความสีน้ำเงิน, หนา, ตัวเอียง; หน้าเว็บหรือเบราว์เซอร์กำหนดฟอนต์และขนาด |
| `ParagraphOnly.html` | `font-weight:bold` | ข้อความหนา; หน้าเว็บหรือเบราว์เซอร์กำหนดฟอนต์, ขนาด, สี, และสไตล์ตัวเอียง |

ส่วนที่สองคง `color:#ff0000`, `font-size:18pt`, และ `font-weight:bold` ในทุก ๆ ผลลัพธ์ ทั้งสามไฟล์ยังคงตัวเอียงใน `All` และ `TextBox` แต่ไม่คงใน `ParagraphOnly` การจำกัดการสืบทอดจึงไม่ลบการกำหนดรูปแบบที่ตั้งไว้โดยตรงสำหรับย่อหน้า或ส่วนย่อย

เปิดไฟล์ในเบราว์เซอร์เดียวกันเพื่อเปรียบเทียบ ในสองโหมดที่จำกัด คุณสมบัติ CSS ที่ละเว้นจะถูกใช้โดยสไตล์ของหน้าเป้าหมายหรือค่าเริ่มต้นของเบราว์เซอร์ ดังนั้นลักษณะการแสดงผลจะขึ้นกับที่ใช้งาน HTML นั้น

### **สร้างส่วนคลิปบอร์ด HTML**

ใช้ [TextToHtmlConversionOptions.setAddClipboardFragmentHeader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/texttohtmlconversionoptions/setaddclipboardfragmentheader/) เพื่อเลือกผลลัพธ์จาก [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) เมื่อเป็น `false` เมธอดจะคืนค่า HTML ธรรมดา เมื่อเป็น `true` สตริงที่คืนค่าจะขึ้นต้นด้วยหัวข้อคลิปบอร์ดของ Windows ฟิลด์ `StartHTML` และ `EndHTML` ให้ตำแหน่งไบต์ UTF‑8 ของ HTML, ส่วน `StartFragment` และ `EndFragment` ระบุเนื้อหาที่จะวาง

ตัวอย่างนี้ส่งออกย่อหน้าที่มีการกำหนดรูปแบบสองย่อหน้าเป็น HTML ธรรมดา (`html`) และเป็นคลิปบอร์ด HTML (`clipboardHtml`) หลังจากนั้นแอปพลิเคชันสามารถเขียนคลิปบอร์ดไปยังระบบคลิปบอร์ดได้ หาก API ของคลิปบอร์ดคาดหวังไบต์ดิบ ใหเข้ารหัสคลิปบอร์ดเป็น UTF‑8 โดยไม่มี BOM

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 0, 0, 400, 100);
    const paragraphs = shape.getTextFrame().getParagraphs();
    paragraphs.clear();
    paragraphs.addFromHtml("<p>Status: <b>Ready</b></p><p><i>Next steps</i></p>");

    const options = new slides.TextToHtmlConversionOptions();
    options.setAddClipboardFragmentHeader(false);
    const html = paragraphs.exportToHtml(0, paragraphs.getCount(), options);

    options.setAddClipboardFragmentHeader(true);
    const clipboardHtml = paragraphs.exportToHtml(0, paragraphs.getCount(), options);
} finally {
    presentation.dispose();
}
```

### **เรนเดอร์ย่อหน้าเป็นรูปภาพ**

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) เรนเดอร์ย่อหน้าเดี่ยวโดยตรงและคืนค่าเป็น [IImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/) บันทึกผลลัพธ์ลงไฟล์หรือสตรีมด้วย [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) คุณไม่จำเป็นต้องเรนเดอร์รูปทรงโดยรวมหรือครอปบิตแมพด้วยตนเอง

[Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) อาจคืนค่า `null` หากย่อหน้าไม่พบในคอลเลกชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ให้ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายภาพที่คืนค่าหลังใช้งาน

#### **เรนเดอร์ย่อหน้าที่อัตราส่วนเริ่มต้น**

ตัวอย่างนี้สร้างพรีเซนเทชั่นที่มีสไลด์หนึ่งสไลด์ที่รูปทรงแรกเป็นกล่องข้อความที่มีย่อหน้า 3 ย่อหน้า

![กล่องข้อความที่มีย่อหน้า 3 ย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เลือกย่อหน้าที่สองที่อินเด็กซ์ 1 และเรียก [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) โดยไม่มีพารามิเตอร์สเกล มันตรวจสอบว่ารูปทรงมีย่อหน้าที่ต้องการและการเรนเดอร์คืนภาพก่อนเรียก [IImage.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/iimage/#save) เพื่อบันทึกเป็น PNG บล็อก `finally` ทำลายภาพหลังใช้งาน

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const sourceShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 100);
    const sourceTextFrame = sourceShape.getTextFrame();
    sourceTextFrame.getParagraphs().clear();
    for (const text of ["First paragraph", "Second paragraph", "Third paragraph"]) {
        const sourceParagraph = new aspose.slides.Paragraph();
        sourceParagraph.setText(text);
        sourceTextFrame.getParagraphs().add(sourceParagraph);
    }
    const shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        const textFrame = shape.getTextFrame();
        if (textFrame !== null && textFrame.getParagraphs().getCount() > 1) {
            const paragraph = textFrame.getParagraphs().get_Item(1);
            const paragraphImage = paragraph.getImage();

            if (paragraphImage !== null) {
                try {
                    paragraphImage.save("paragraph.png", aspose.slides.ImageFormat.Png);
                } finally {
                    paragraphImage.dispose();
                }
            } else {
                console.log("The paragraph could not be rendered.");
            }
        } else {
            console.log("The expected paragraph was not found.");
        }
    } else {
        console.log("The first shape is not a text shape.");
    }
} finally {
    presentation.dispose();
}
```

ผลลัพธ์:

![ภาพย่อหน้า](paragraph_to_image_output.png)

#### **เรนเดอร์ย่อหน้าในเซลล์ตารางพร้อมการสเกล**

ใช้โอเวอร์โหลดของ [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage) ที่รับพารามิเตอร์ `scaleX` และ `scaleY` เพื่อกำหนดปัจจัยสเกลแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, เรนเดอร์ย่อหน้าในเซลล์แรกที่กว้างและสูงเป็นสองเท่าของค่าเริ่มต้น, แล้วบันทึกผลเป็น PNG

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const scaleX = 2;
const scaleY = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const columnWidths = java.newArray("double", [300]);
    const rowHeights = java.newArray("double", [80]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    const paragraph = table.get_Item(0, 0).getTextFrame().getParagraphs().get_Item(0);
    paragraph.setText("Text in a table cell");

    const paragraphImage = paragraph.getImage(scaleX, scaleY);
    if (paragraphImage !== null) {
        try {
            paragraphImage.save("table_paragraph.png", aspose.slides.ImageFormat.Png);
        } finally {
            paragraphImage.dispose();
        }
    } else {
        console.log("The paragraph could not be rendered.");
    }
} finally {
    presentation.dispose();
}
```

ค่าปัจจัยสเกล `1` รักษาขนาดพิกเซลตามค่าเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองปัจจัยจะได้ภาพที่ความกว้างและความสูงประมาณสองเท่าของมิติเริ่มต้น ทำให้พิกเซลเพิ่มเป็นสี่เท่า ปัจจัยที่ใหญ่กว่าให้ข้อความคมชัดยิ่งขึ้นสำหรับการซูมหรือเอาต์พุตความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ปัจจัยที่ต่ำกว่า `1` ให้ภาพขนาดเล็กลงพร้อมรายละเอียดน้อยลง ใช้ปัจจัยเท่ากันเพื่อคงอัตราส่วนของย่อหน้า; ปัจจัยแนวนอนและแนวตั้งที่ต่างกันจะยืดภาพอย่างอิสระ

การเรนเดอร์รูปทรงทั้งหมดด้วย [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getImage) ยังคงมีประโยชน์เมื่อเอาต์พุตต้องรวมพื้นหลัง, ขอบ, หรือบริบทภาพอื่น ๆ สำหรับภาพที่มีเพียงย่อหน้าให้ใช้ [Paragraph.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getImage)

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดอัตโนมัติในกรอบข้อความได้หรือไม่?**

ได้. ตั้งค่า [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/) เพื่อปิดการตัดบรรทัดเพื่อให้บรรทัดไม่ตัดที่ขอบของกรอบข้อความ

**ฉันจะรับขอบเขตบนสไลด์ที่แน่นอนของย่อหน้าเฉพาะได้อย่างไร?**

ใช้ [Paragraph.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/getrect/) เพื่อดึงสี่เหลี่ยมขอบของย่อหน้า ส่วน [Portion.getRect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/getrect/) ให้ขอบของส่วนย่อยแต่ละส่วน

**การจัดแนวย่อหน้า (ซ้าย, ขวา, กลาง, หรือจัดเต็ม) ถูกควบคุมที่ไหน?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) เป็นการตั้งค่าระดับย่อหน้าและใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการกำหนดรูปแบบของส่วนย่อยแต่ละส่วน

เพื่อจัดแนวแนวตั้งของส่วนย่อยที่มีขนาดฟอนต์ต่างกันภายในบรรทัดเดียวกัน ดู [Align Fonts Within a Line](/slides/th/nodejs-java/text-formatting/#align-fonts-within-a-line)

**ฉันสามารถตั้งค่าภาษา proofing สำหรับส่วนหนึ่งของย่อหน้าได้หรือไม่?**

ได้. ตั้งค่า [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) สำหรับส่วนย่อยแต่ละส่วน เพื่อให้ย่อหน้าเดียวสามารถมีข้อความหลายภาษาผสมกัน