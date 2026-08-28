---
title: จัดการย่อหน้าข้อความ PowerPoint ใน JavaScript
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
- จัดการสัญลักษณ์หัวข้อ
- การเยื้องย่อหน้า
- การเยื้องแบบ hanging
- หัวข้อย่อยของย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อจุด
- คุณสมบัติของย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, ส่วนข้อความ, สัญลักษณ์หัวข้อ, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML, และภาพย่อหน้า ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides สำหรับ Node.js ผ่าน Java แสดงข้อความในรูปแบบโครงสร้างลำดับขั้นของ text frame, paragraph, และ portion:

* [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) แสดงคอนเทนเนอร์ข้อความในรูปทรงและให้เข้าถึงคอลเลกชันของ paragraph
* [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) แสดง paragraph หนึ่งใน text frame และให้เข้าถึง portion และการจัดรูปแบบระดับ paragraph
* [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) แสดงการรันข้อความภายใน paragraph แต่ละ portion สามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเองได้

ดังนั้น paragraph จึงสามารถมีข้อความที่มีฟอนต์, สี, ขนาด, และการจัดรูปแบบอื่น ๆ ที่แตกต่างกันได้โดยใช้หลาย portion

## **สร้างและจัดรูปแบบ Paragraphs**

### **สร้าง Paragraphs ด้วยหลาย Portion**

ขั้นตอนต่อไปนี้จะสร้าง text frame ที่มีสาม paragraph แต่ละ paragraph มีสาม portion:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนี
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมลงบนสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของรูปทรง
5. ใช้ paragraph เริ่มต้นและเพิ่มอีกสองอ็อบเจ็กต์ [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) ลงใน text frame
6. เพิ่มอ็อบเจ็กต์ [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) เพียงพอให้แต่ละ paragraph มีสาม portion โดยปริยาย paragraph เริ่มต้นมีหนึ่ง portion ว่างอยู่แล้ว
7. ตั้งค่าข้อความของแต่ละ portion
8. ใช้การจัดรูปแบบระดับอักขระผ่าน [Portion.getPortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/getportionformat/)
9. บันทึกพรีเซนเทชันที่แก้ไขแล้ว

ตัวอย่าง JavaScript นี้แสดงการดำเนินการขั้นตอนดังกล่าว:

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

## **สร้างรายการ Bulleted และ Numbered**

### **สร้างรายการ Bulleted หรือ Numbered**

Bullets และการจัดระเบียบเลขทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการกำหนดโดยใช้ [BulletFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/)

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนี
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ลงบนสไลด์ที่เลือก
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของรูปทรง
5. ลบ paragraph เริ่มต้นออกจาก text frame
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) สำหรับ bullet สัญลักษณ์
7. ตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/settype/) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bullettype/) และกำหนดอักขระ bullet
8. ตั้งค่าข้อความของ paragraph, ระยะเยื้อง, สี bullet, และความสูงของ bullet
9. เพิ่ม paragraph ลงใน text frame
10. สร้าง paragraph ที่สองและตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/settype/) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bullettype/)
11. กำหนดสไตล์ bullet แบบลำดับเลขและเพิ่ม paragraph ลงใน text frame
12. บันทึกพรีเซนเทชัน

ตัวอย่าง JavaScript นี้สร้าง bullet สัญลักษณ์และ bullet หมายเลข:

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

### **ใช้ Picture Bullets**

Picture bullets ให้คุณใช้รูปภาพกำหนดเองแทนสัญลักษณ์หรือเลข

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่ต้องการผ่านดัชนี
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) และเข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของมัน
4. ลบ paragraph เริ่มต้นออกจาก text frame
5. โหลดรูปภาพ bullet และเพิ่มเข้าไปในคอลเลกชันภาพของพรีเซนเทชันเป็น [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/)
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) และตั้งค่าข้อความของมัน
7. ตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/settype/) เป็น [BulletType.Picture](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bullettype/)
8. กำหนดรูปภาพผ่าน [BulletFormat.getPicture](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/getpicture/) และตั้งค่าความสูงของ bullet
9. เพิ่ม paragraph ลงใน text frame
10. บันทึกพรีเซนเทชันที่แก้ไข

ตัวอย่าง JavaScript นี้สร้าง picture bullet:

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

### **สร้าง Multilevel List**

ตั้งค่า [ParagraphFormat.setDepth](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setdepth/) เพื่อกำหนดระดับของ paragraph ในรายการ ระดับบนสุดมีความลึก `0`

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) และเข้าถึงสไลด์
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) และลบ paragraph เริ่มต้นจาก text frame ของมัน
3. สร้างสี่ paragraph และกำหนดสัญลักษณ์ bullet ของแต่ละอัน
4. ตั้งค่า [ParagraphFormat.setDepth](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setdepth/) ของพวกมันเป็น `0`, `1`, `2`, และ `3`
5. เพิ่ม paragraph ลงใน text frame แล้วบันทึกพรีเซนเทชัน

ตัวอย่าง JavaScript นี้สร้างรายการ bullet ที่มีสี่ระดับ:

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

### **เริ่มรายการ Numbered ที่ค่าที่กำหนดเอง**

ใช้ [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) เพื่อตั้งค่าตัวเลขเริ่มต้นของ paragraph ที่เป็น numbered

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) แล้วเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ลงบนสไลด์
2. ลบ paragraph เริ่มต้นจาก text frame ของรูปทรง
3. สร้าง three numbered paragraph
4. ตั้งค่า [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) เป็น `2`, `3`, และ `7` สำหรับแต่ละ paragraph
5. เพิ่ม paragraph ลงใน text frame และบันทึกพรีเซนเทชัน

ตัวอย่าง JavaScript นี้กำหนดตัวเลขเริ่มต้นที่กำหนดเองให้แต่ละ paragraph:

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

## **ควบคุมการจัดวาง Paragraph และคุณสมบัติ End**

### **ตั้งค่า First-Line Indent**

ใช้ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) เพื่อควบคุมการเยื้องบรรทัดแรกของ paragraph วิธีนี้จะเลื่อนบรรทัดแรกเท่านั้นเมื่อเทียบกับขอบซ้ายของ paragraph ค่าเป็นบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือยังคงจัดชิดตามเนื้อหา paragraph

ใช้ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) เมื่อคุณต้องการเลื่อนทั้ง paragraph ใช้ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) เมื่อต้องการเลื่อนเฉพาะบรรทัดแรกเท่านั้น

ตัวอย่างด้านล่างสร้างหลาย paragraph และกำหนดค่า [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) ที่แตกต่างกันเพื่อแสดงผลของการเยื้องบรรทัดแรกต่อการจัดวาง paragraph

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมลงบนสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของรูปทรงและลบ paragraph เริ่มต้น
5. สร้างหลาย paragraph แล้วตั้งค่า [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) ที่แตกต่างกันสำหรับแต่ละอัน
6. เพิ่ม paragraph ลงใน text frame
7. บันทึกพรีเซนเทชันที่แก้ไข

โค้ดนี้แสดงวิธีตั้งค่าเยื้องของ paragraph:

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

![การเยื้องบรรทัดแรกของย่อหน้า](first_line_indent.png)

### **ตั้งค่า Hanging Indent**

Hanging indent คือการจัดวาง paragraph ที่บรรทัดแรกเริ่มอยู่ด้านซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วย [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) ให้ค่าเป็นลบเพื่อเลื่อนบรรทัดแรกไปทางซ้ายเมื่อเทียบกับเนื้อหา paragraph

โดยทั่วไป [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) กำหนดตำแหน่งซ้ายของเนื้อหา paragraph และ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) กำหนดตำแหน่งของบรรทัดแรกเมื่อเทียบกับขอบซ้านนั้น เพื่อสร้าง hanging indent ให้ตั้งค่าเป็นบวกใน `setMarginLeft` และเป็นลบใน `setIndent`

การจัดรูปแบบนี้เป็นประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการสารานุกรมและ paragraph อื่น ๆ ที่ต้องการให้บรรทัดที่หักบรรทัดต่อกันเรียงชิดใต้เนื้อหา paragraph ไม่ใช่ใต้ตัวอักษรแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมลงบนสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของรูปทรงและลบ paragraph เริ่มต้น
5. สร้าง paragraph แล้วตั้งค่า [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) เป็นค่าบวกสำหรับแต่ละ paragraph
6. ตั้งค่า [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) เป็นค่าลบเพื่อสร้างเอฟเฟกต์ hanging indent
7. เพิ่ม paragraph ลงใน text frame
8. บันทึกพรีเซนเทชันที่แก้ไข

โค้ดนี้แสดงวิธีตั้งค่า hanging indent สำหรับ paragraph:

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

![การเยื้องแบบ hanging ของย่อหน้า](hanging_indent.png)

### **ตั้งค่า End Paragraph Run Properties**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) ควบคุมการจัดรูปแบบของเครื่องหมายจบบรรทัดของ paragraph ตัวอย่างต่อไปนี้กำหนดขนาดฟอนต์และฟอนต์ Latin ให้กับเครื่องหมายจบบรรทัดของ paragraph ที่สอง:

1. สร้างหรือโหลด [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) แล้วเข้าถึงสไลด์
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) และลบ paragraph เริ่มต้นของมัน
3. สร้างสอง paragraph แล้วเพิ่ม portion ของข้อความลงในแต่ละอัน
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portionformat/) สำหรับเครื่องหมายจบของ paragraph ที่สอง
5. ตั้งค่า [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) และ [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setLatinFont)
6. ใช้ [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) เพื่อกำหนดรูปแบบแล้วบันทึกพรีเซนเทชัน

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

## **นำเข้าและส่งออกเนื้อหา Paragraph**

### **นำเข้า HTML Text เข้าไปใน Paragraphs**

ใช้ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) เพื่อแปลง markup HTML ให้เป็น paragraph และ portion ภายใน text frame

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์และเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/)
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของรูปทรงและลบ paragraph เริ่มต้น
4. กำหนดหรืออ่านสตริง HTML ต้นทาง
5. ส่งสตริง HTML ไปยัง [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/)
6. บันทึกพรีเซนเทชันที่แก้ไข

ตัวอย่าง JavaScript นี้นำเข้าข้อมูล HTML ไปยัง text frame:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapeWidth = presentation.getSlideSize().getSize().getWidth() - 20;
    const shapeHeight = presentation.getSlideSize().getSize().getHeight() - 20;
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const html = "<p><b>Aspose.Slides</b> imports HTML text into presentation paragraphs.</p>";
    shape.getTextFrame().getParagraphs().addFromHtml(html);
    presentation.save("html_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **ส่งออกข้อความ Paragraph เป็น HTML**

ใช้ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) เพื่อส่งออกรายการของ paragraph ที่เลือกเป็น HTML

1. สร้างหรือโหลดอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์และค้นหา [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ที่มีข้อความอยู่
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของรูปทรง
4. เรียก [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) พร้อมดัชนี paragraph เริ่มต้นและจำนวน paragraph ที่ต้องการส่งออก
5. เขียนสตริง HTML ที่ได้ลงไฟล์

ตัวอย่าง JavaScript ที่ทำงานอิสระนี้สร้างรูปทรงข้อความและส่งออกทุก paragraph ของมัน:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

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
        if (textFrame !== null) {
            const paragraphs = textFrame.getParagraphs();
            const html = paragraphs.exportToHtml(0, paragraphs.getCount(), null);
            fs.writeFileSync("paragraphs.html", html, "utf8");
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

### **เรนเดอร์ Paragraph เป็นภาพ**

[Paragraph.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/#getImage) เรนเดอร์ paragraph เดียวโดยตรงและคืนค่าเป็น [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/) บันทึกผลลัพธ์ลงไฟล์ด้วย [IImage.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/#save) คุณไม่จำเป็นต้องเรนเดอร์รูปทรงที่บรรจุหรือทำการตัดภาพ bitmap ด้วยตนเอง

[Paragraph.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/#getImage) อาจคืนค่า `null` หากไม่พบ paragraph ในคอลเลกชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำการ Dispose ภาพที่คืนค่าหลังการใช้งาน

#### **เรนเดอร์ Paragraph ด้วยสเกลค่าเริ่มต้น**

กล่องข้อความต่อไปนี้มีสาม paragraph:

![กล่องข้อความที่มีสาม paragraph](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้เรนเดอร์ paragraph ที่สองในรูปทรงข้อความปกติด้วยสเกลค่าเริ่มต้นและบันทึกภาพที่ได้เป็น PNG บล็อก `finally` ทำให้แน่ใจว่าภาพถูก Dispose อย่างถูกต้อง

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

![ภาพของ paragraph](paragraph_to_image_output.png)

#### **เรนเดอร์ Paragraph ในเซลล์ตารางพร้อมการสเกล**

ใช้ overload ของ [Paragraph.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/#getImage) ที่รับพารามิเตอร์ `scaleX` และ `scaleY` เพื่อตั้งค่าค่าขนาดแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, เรนเดอร์ paragraph ในเซลล์แรกด้วยความกว้างและความสูงที่สองเท่าของค่าเริ่มต้น, แล้วบันทึกผลลัพธ์เป็น PNG

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

ค่าสเกล `1` ทำให้แกนนั้นคงขนาดพิกเซลค่าเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองแกนจะสร้างภาพที่กว้างและสูงประมาณสองเท่าของมิติค่าเริ่มต้น ทำให้จำนวนพิกเซลเพิ่มเป็นสี่เท่า ค่าใหญ่ขึ้นมักทำให้ข้อความคมชัดขึ้นสำหรับการซูมหรือผลลัพธ์ความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ค่าใต `1` จะทำให้ภาพเล็กลงและรายละเอียดน้อยลง ใช้ค่าที่เท่ากันเพื่อคงสัดส่วนของ paragraph; ค่าตั้งแนวนอนและแนวตั้งต่างกันจะทำให้ภาพยืดออกตามแกนที่กำหนด

การเรนเดอร์รูปทรงทั้งหมดด้วย [Shape.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getImage) ยังคงมีประโยชน์เมื่อต้องการรวมการเติมสี, ขอบ, หรือบริบทภาพอื่น ๆ ของรูปทรง สำหรับภาพที่มีเพียง paragraph เท่านั้น ให้ใช้ [Paragraph.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/#getImage)

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการบรรจบบรรทัดภายใน text frame ได้ทั้งหมดหรือไม่?**

ได้. ตั้งค่า [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/setwraptext/) เพื่อปิดการบรรจบบรรทัด ทำให้บรรทัดไม่ตัดตรงขอบของ text frame

**ฉันจะรับขอบเขตบนสไลด์ที่แม่นยำของ paragraph เฉพาะได้อย่างไร?**

ใช้ [Paragraph.getRect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/getrect/) เพื่อดึงสี่เหลี่ยมขอบของ paragraph. [Portion.getRect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/#getRect) ให้ขอบเขตของ portion รายบุคคล

**ตำแหน่งการจัดแนวของ paragraph (ซ้าย, ขวา, กลาง, หรือจัดเต็ม) ถูกควบคุมที่ไหน?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setalignment/) เป็นการตั้งค่าระดับ paragraph และนำไปใช้กับทั้ง paragraph แม้ว่าจะมีการจัดรูปแบบระดับ portion แยกต่างหาก

**ฉันสามารถตั้งค่าภาษา proofing ให้กับบางส่วนของ paragraph ได้หรือไม่?**

ได้. ตั้งค่า [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) สำหรับ portion แต่ละอัน ทำให้ paragraph หนึ่งสามารถมีข้อความหลายภาษาได้