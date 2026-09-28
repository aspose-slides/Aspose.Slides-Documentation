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
- เยื้องย่อหน้า
- เยื้องห้อย
- สัญลักษณ์หัวข้อย่อหน้า
- รายการลำดับเลข
- รายการสัญลักษณ์หัวข้อ
- คุณสมบัตีย่อหน้า
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
description: "เรียนรู้วิธีการสร้างและจัดรูปแบบย่อหน้า, ส่วนข้อความ, สัญลักษณ์หัวข้อ, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML, และภาพย่อหน้าด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Node.js via Java แสดงข้อความเป็นโครงสร้างชั้นของกรอบข้อความ, ย่อหน้า, และส่วนข้อความ:

* [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) เป็นตัวเก็บข้อความในรูปทรงและให้การเข้าถึงคอลเลกชันของย่อหน้า
* [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) เป็นย่อหน้าเดียวในกรอบข้อความและให้การเข้าถึงส่วนข้อความและการจัดรูปแบบระดับย่อหน้า
* [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) เป็นช่วงข้อความภายในย่อหน้า แต่ละส่วนข้อความสามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเอง

ดังนั้น ย่อหน้าจึงสามารถมีข้อความที่มีแบบอักษร, สี, ขนาด, และการจัดรูปแบบอื่น ๆ ที่แตกต่างกันได้โดยใช้หลายส่วนข้อความ.

## **สร้างและจัดรูปแบบย่อหน้า**

### **สร้างย่อหน้าด้วยหลายส่วนข้อความ**

ขั้นตอนต่อไปนี้จะสร้างกรอบข้อความที่มีสามย่อหน้า แต่ละย่อหน้ามีสามส่วนข้อความ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) แบบสี่เหลี่ยมให้กับสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของรูปทรง
5. ใช้ย่อหน้าเริ่มต้นและเพิ่มออบเจ็กต์ [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) อีกสองรายการเข้าไปในกรอบข้อความ
6. เพิ่มออบเจ็กต์ [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) จำนวนเพียงพอสำหรับแต่ละย่อหน้าให้มีสามส่วนข้อความ ย่อหน้าเริ่มต้นมีส่วนข้อความว่างหนึ่งส่วนอยู่แล้ว
7. กำหนดข้อความของแต่ละส่วนข้อความ
8. ใช้การจัดรูปแบบระดับอักขระผ่าน [Portion.getPortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/getportionformat/)
9. บันทึกการนำเสนอที่แก้ไขแล้ว

ตัวอย่าง JavaScript นี้ทำตามขั้นตอนเหล่านั้น:

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

## **สร้างรายการสัญลักษณ์และรายการลำดับเลข**

### **สร้างรายการสัญลักษณ์หรือรายการลำดับเลข**

สัญลักษณ์และการลำดับเลขทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการจะกำหนดผ่าน [BulletFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/)

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์ที่เลือก
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของรูปทรง
5. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) สำหรับสัญลักษณ์หัวข้อ
7. ตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/settype/) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bullettype/) และระบุอักขระสัญลักษณ์หัวข้อ
8. กำหนดข้อความย่อหน้า, ระยะเยื้อง, สีสัญลักษณ์หัวข้อ, และความสูงของสัญลักษณ์หัวข้อ
9. เพิ่มย่อหน้าเข้าไปในกรอบข้อความ
10. สร้างย่อหน้าที่สองและตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/settype/) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bullettype/)
11. ตั้งค่าสไตล์สัญลักษณ์หัวข้อเป็นลำดับเลขและเพิ่มย่อหน้าเข้าไปในกรอบข้อความ
12. บันทึกการนำเสนอ

ตัวอย่าง JavaScript นี้สร้างสัญลักษณ์หัวข้อแบบสัญลักษณ์และแบบลำดับเลข:

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

### **ใช้สัญลักษณ์หัวข้อเป็นรูปภาพ**

สัญลักษณ์หัวข้อเป็นรูปภาพทำให้คุณใช้รูปภาพที่กำหนดเองแทนสัญลักษณ์หรือหมายเลข

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่เกี่ยวข้องผ่านดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) และเข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของมัน
4. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความ
5. โหลดภาพสัญลักษณ์หัวข้อและเพิ่มลงในคอลเลกชันภาพของการนำเสนอเป็น [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/)
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) และกำหนดข้อความของมัน
7. ตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/settype/) เป็น [BulletType.Picture](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bullettype/)
8. กำหนดภาพผ่าน [BulletFormat.getPicture](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/getpicture/) และตั้งค่าความสูงของสัญลักษณ์หัวข้อ
9. เพิ่มย่อหน้าเข้าไปในกรอบข้อความ
10. บันทึกการนำเสนอที่แก้ไขแล้ว

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

ตั้งค่า [ParagraphFormat.setDepth](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setdepth/) เพื่อวางย่อหน้าในระดับต่าง ๆ ของรายการ ระดับบนสุดมีความลึก `0`

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) และเข้าถึงสไลด์
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) และลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของมัน
3. สร้างสี่ย่อหน้าและกำหนดสัญลักษณ์หัวข้อของพวกมัน
4. ตั้งค่าความลึกของพวกมันโดยใช้ [ParagraphFormat.setDepth](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setdepth/) เป็น `0`, `1`, `2`, และ `3`
5. เพิ่มย่อหน้าเข้าไปในกรอบข้อความและบันทึกการนำเสนอ

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

### **เริ่มรายการลำดับเลขด้วยค่าที่กำหนดเอง**

ใช้ [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) เพื่อตั้งค่าตัวเลขเริ่มต้นที่จะแสดงสำหรับย่อหน้าแบบลำดับเลข

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) และเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ลงในสไลด์
2. ลบย่อหน้าเริ่มต้นออกจากกรอบข้อความของรูปทรง
3. สร้างย่อหน้าแบบลำดับเลขสามรายการ
4. ตั้งค่า [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) เป็น `2`, `3`, และ `7` สำหรับย่อหน้าที่สอดคล้องกัน
5. เพิ่มย่อหน้าเข้าไปในกรอบข้อความและบันทึกการนำเสนอ

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

## **ควบคุมการจัดวางย่อหน้าและคุณสมบัติส่วนท้าย**

### **ตั้งค่าเยื้องบรรทัดแรก**

ใช้ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) เพื่อควบคุมการเยื้องบรรทัดแรกของย่อหน้า วิธีนี้จะย้ายเฉพาะบรรทัดแรกเทียบกับขอบซ้ายของย่อหน้า ค่าเป็นบวกจะเลื่อนบรรทัดแรกไปทางขวา ส่วนบรรทัดที่เหลือยังคงจัดชิดกับเนื้อหาย่อหน้า  
ใช้ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) เมื่อคุณต้องการย้ายย่อหน้าทั้งหมด ใช้ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) เมื่อคุณต้องการย้ายเฉพาะบรรทัดแรก  

ตัวอย่างด้านล่างสร้างหลายย่อหน้าและกำหนดค่าต่าง ๆ ของ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) เพื่อแสดงว่าการเยื้องบรรทัดแรกมีผลต่อการจัดวางย่ออย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) แบบสี่เหลี่ยมให้กับสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น
5. สร้างหลายย่อหน้าและกำหนดค่าต่าง ๆ ของ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) สำหรับพวกมัน
6. เพิ่มย่อหน้าเข้าไปในกรอบข้อความ
7. บันทึกการนำเสนอที่แก้ไขแล้ว

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

### **ตั้งค่าเยื้องห้อย**

เยื้องห้อยเป็นรูปแบบการจัดวางย่อหน้าที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟ็กต์นี้ด้วย [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) ใช้ค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเทียบกับเนื้อหาย่อหน้า  
โดยปฏิบัติ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) กำหนดตำแหน่งซ้ายของเนื้อหาย่อหน้า และ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) กำหนดตำแหน่งของบรรทัดแรกเทียบกับขอบนั้น เพื่อสร้างเยื้องห้อย ให้ส่งค่าบวกให้ `setMarginLeft` และค่าลบให้ `setIndent`  
การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, อ้างอิง, รายการอภิธานศัพท์, และย่อหน้าอื่น ๆ ที่บรรทัดที่ตัดต่อ ต้องจัดชิดใต้เนื้อหาย่อหน้าไม่ใช่ใต้ตัวอักษรแรกของบรรทัดแรก  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) แบบสี่เหลี่ยมให้กับสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น
5. สร้างย่อหน้าและส่งค่าบวกให้ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) สำหรับแต่ละย่อหน้า
6. ส่งค่าลบให้ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) เพื่อสร้างเอฟเฟ็กต์เยื้องห้อย
7. เพิ่มย่อหน้าเข้าไปในกรอบข้อความ
8. บันทึกการนำเสนอที่แก้ไขแล้ว

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

![เยื้องหของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติส่วนสิ้นสุดของย่อหน้า**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) ควบคุมการจัดรูปแบบของเครื่องหมายสิ้นสุดย่อหน้า ตัวอย่างต่อไปนี้กำหนดขนาดฟอนต์และฟอนต์ละตินให้กับเครื่องหมายสิ้นสุดของย่อหน้าที่สอง:

1. สร้างหรือโหลด [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) แล้วเข้าถึงสไลด์
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) และลบย่อหน้าเริ่มต้นของมัน
3. สร้างสองย่อหน้าและเพิ่มส่วนข้อความลงในแต่ละย่อหน้า
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portionformat/) สำหรับเครื่องหมายสิ้นสุดของย่อหน้าที่สอง
5. ตั้งค่า [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) และ [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setLatinFont)
6. กำหนดรูปแบบด้วย [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) และบันทึกการนำเสนอ

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

## **นับจำนวนบรรทัดที่แสดงผล**

สำหรับกฎของย่อหน้าที่ส่งผลต่อการตัดบรรทัดอัตโนมัติและเครื่องหมายวรรคตอนที่ท้ายบรรทัด ดูที่ [ควบคุมการตัดบรรทัด](/slides/th/nodejs-java/text-formatting/#control-line-breaking) และ [ควบคุมเครื่องหมายวรรคตอนห้อย](/slides/th/nodejs-java/text-formatting/#control-hanging-punctuation)  
ใช้ [Paragraph.getLinesCount](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/#getLinesCount) เพื่อนับจำนวนบรรทัดที่ย่อหน้าใช้หลังจากการจัดข้อความรวมถึงการตัดบรรทัดอัตโนมัติ ซึ่งมีประโยชน์เมื่อทำการตรวจสอบความยาวของข้อความและการจัดวางในเทมเพลตการนำเสนอ  
ย่อหน้าเป็นรายการหนึ่งใน [TextFrame.getParagraphs](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#getParagraphs) และอาจใช้หลายบรรทัดที่แสดงผล การใส่การตัดบรรทัดอย่างชัดเจนภายในย่อหน้าจะบังคับให้ขึ้นบรรทัดใหม่โดยไม่สร้างย่อหน้าใหม่ การตัดบรรทัดอัตโนมัติสร้างบรรทัดตามความกว้างที่มีอยู่โดยไม่ต้องใส่การตัดบรรทัดลงในข้อความ ดังนั้นการนับย่อหน้าหรืออักขระการตัดบรรทัดจะไม่ให้จำนวนบรรทัดที่แสดงผล  

ตัวอย่างต่อไปนี้สร้างรูปข้อความ, นับจำนวนบรรทัด, ทำให้รูปแคบลง, และจากนั้นแทนที่ข้อความด้วยสตริงสั้นกว่า การตัดบรรทัดเปิดใช้งานและการปรับอัตโนมัติปิดอยู่เพื่อให้ความกว้างของรูปควบคุมการตัดบรรทัดโดยไม่ลดขนาดข้อความหรือรูปโดยอัตโนมัติ มิติของรูปวัดเป็น point สุดท้าย ตัวอย่างเพิ่มย่อหน้าอีกหนึ่งรายการและรวมจำนวนบรรทัดทั้งหมดในกรอบข้อความ  

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

ด้วยข้อความและมิตินี้ การทำให้รูปแคบลงจะเพิ่มจำนวนบรรทัด ในขณะที่การแทนที่ข้อความด้วยสตริงสั้นจะลดจำนวนบรรทัด จำนวนที่แน่นอนอาจเปลี่ยนแปลงได้ตามการมีฟอนต์และการทดแทน, ขนาดฟอนต์, ระยะขอบ, การเยื้อง, การตัดบรรทัด, และการตั้งค่า autofit ใช้ฟอนต์และการตั้งค่าการจัดวางที่ตั้งใจไว้สำหรับสภาพแวดล้อมเป้าหมายเมื่อทำการตรวจสอบเทมเพลต  

จำนวนบรรทัดเพียงอย่างเดียวไม่บ่งบอกว่าข้อความล้นจากคอนเทนเนอร์หรือไม่ ความสูงที่มีอยู่, ความสูงของบรรทัด, ระยะห่างระหว่างย่อหน้าและบรรทัด, และพฤติกรรม autofit ก็มีผล; แม้บรรทัดเดียวก็อาจเกินความกว้างที่มีเมื่อการตัดบรรทัดถูกปิด  

## **นำเข้าและส่งออกเนื้อหาย่อหน้า**

### **นำเข้าข้อความ HTML ไปยังย่อหน้า**

ใช้ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) เพื่อแปลงเครื่องหมาย HTML เป็นย่อหน้าและส่วนข้อความในกรอบข้อความ  

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์และเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/)
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของรูปทรงและลบย่อหน้าเริ่มต้น
4. กำหนดหรืออ่านสตริง HTML แหล่งที่มา
5. ส่งสตริง HTML ไปยัง [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/)
6. บันทึกการนำเสนอที่แก้ไขแล้ว  

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

### **ส่งออกข้อความย่อหน้าเป็น HTML**

ใช้ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) เพื่อส่งออกช่วงของย่อหน้าที่เลือกเป็น HTML  

1. สร้างหรือโหลดอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์และค้นหา [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ที่บรรจุข้อความ
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของรูปทรง
4. เรียก [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) พร้อมดัชนีย่อหน้าเริ่มต้นและจำนวนย่อหน้าที่ต้องการส่งออก
5. เขียนสตริง HTML ที่คืนค่าลงไฟล์  

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

### **แสดงย่อหน้าเป็นรูปภาพ**

[Paragraph.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/#getImage) ทำการแสดงย่อหน้าเดี่ยวโดยตรงและคืนค่า [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/) บันทึกผลลัพธ์ลงไฟล์ด้วย [IImage.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/#save) คุณไม่จำเป็นต้องแสดงรูปทรงที่บรรจุหรือครอบภาพบิตแมพด้วยตนเอง  
[Paragraph.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/#getImage) สามารถคืนค่า `null` หากไม่พบย่อหน้าในคอลเลกชันแม่, ไม่มีขอบเขตการแสดงที่ถูกต้อง, หรือไม่สามารถแสดงได้ ตรวจสอบผลลัพธ์ก่อนบันทึกและทำลายภาพที่คืนค่าหลังการใช้งาน  

#### **แสดงย่อหน้าที่สเกลเริ่มต้น**

กล่องข้อความต่อไปนี้มีสามย่อหน้า:

![กล่องข้อความที่มีสามย่อหน้า](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้ทำการแสดงย่อหน้าที่สองในรูปข้อความปกติที่สเกลเริ่มต้นและบันทึกภาพที่ได้เป็นรูปแบบ PNG ส่วน `finally` ทำให้แน่ใจว่าภาพถูกทำลายอย่างถูกต้อง  

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

![ภาพของย่อหน้า](paragraph_to_image_output.png)

#### **แสดงย่อหน้าในเซลล์ตารางโดยปรับสเกล**

ใช้ overload ของ [Paragraph.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/#getImage) ที่รับพารามิเตอร์ `scaleX` และ `scaleY` เพื่อตั้งค่าปัจจัยสเกลแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, ทำการแสดงย่อหน้าในเซลล์แรกที่กว้างและสูงเป็นสองเท่าของค่าเริ่มต้น, และบันทึกผลลัพธ์เป็นภาพ PNG  

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

ปัจจัยสเกล `1` ทำให้แกนนั้นคงขนาดพิกเซลเริ่มต้น ตัวอย่างเช่น `2` สำหรับทั้งสองปัจจัยจะสร้างภาพที่ความกว้างและความสูงประมาณสองเท่าของมิติเริ่มต้น ทำให้มีพิกเซลสี่เท่า ปัจจัยที่ใหญ่กว่ามักให้ข้อความที่คมชัดขึ้นสำหรับการซูมหรือผลลัพธ์ความละเอียดสูง แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์ ปัจจัยต่ำกว่า `1` จะสร้างภาพที่เล็กลงพร้อมรายละเอียดน้อยกว่า ใช้ปัจจัยเท่ากันเพื่อคงอัตราส่วนของย่อหน้า; ปัจจัยแนวนอนและแนวตั้งที่แตกต่างกันจะยืดขยายผลลัพธ์แยกกัน  

การทำการแสดงรูปทั้งหมดด้วย [Shape.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getImage) ยังคงมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติม, เส้นขอบ หรือบริบทภาพอื่นของรูป สำหรับภาพที่เป็นแค่ย่อหน้า ให้ใช้ [Paragraph.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/#getImage)  

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดในกรอบข้อความได้ทั้งหมดหรือไม่?**  
ใช่. ตั้งค่า [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/setwraptext/) เพื่อปิดการตัดบรรทัด sehingga บรรทัดจะไม่ตัดที่ขอบของกรอบข้อความ  

**ฉันจะได้รับขอบเขตที่แน่นอนบนสไลด์ของย่อหน้าเฉพาะได้อย่างไร?**  
ใช้ [Paragraph.getRect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/getrect/) เพื่อดึงสี่เหลี่ยมขอบของย่อหน้า [Portion.getRect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/#getRect) ให้ขอบเขตของส่วนข้อความเดี่ยว  

**การจัดแนวย่อหน้า (ซ้าย, ขวา, กลาง หรือจัดแนวเต็ม) ถูกควบคุมที่ไหน?**  
[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setalignment/) เป็นการตั้งค่าระดับย่อหน้าและใช้กับย่อหน้าทั้งหมดโดยไม่คำนึงถึงการจัดรูปแบบของแต่ละส่วนข้อความ  

**ฉันสามารถตั้งค่าภาษา proofing สำหรับส่วนหนึ่งของย่อหน้าได้หรือไม่?**  
ใช่. ตั้งค่า [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) สำหรับส่วนข้อความแต่ละส่วน เพื่อให้ย่อหน้าเดียวสามารถมีข้อความหลายภาษาได้.