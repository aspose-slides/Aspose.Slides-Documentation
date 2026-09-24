---
title: จัดการย่อหน้าข้อความ PowerPoint ด้วย JavaScript
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
- การเยื้องห้อย
- สัญลักษณ์หัวข้อย่อหน้า
- รายการลำดับเลข
- รายการหัวข้อ
- คุณสมบัติย่อหน้า
- นำเข้า HTML
- ข้อความเป็น HTML
- ย่อหน้าเป็น HTML
- ย่อหน้าเป็นภาพ
- ข้อความเป็นภาพ
- ส่งออกย่อหน้า
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและจัดรูปแบบย่อหน้า, ส่วน, สัญลักษณ์หัวข้อ, รายการลำดับเลข, การเยื้อง, เนื้อหา HTML, และภาพย่อหน้าด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides for Node.js via Java แสดงข้อความเป็นลำดับชั้นของ text frame, paragraph, และ portion:

* [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) เป็นตัวบรรจุข้อความใน shape และให้การเข้าถึง collection ของ paragraph
* [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) เป็น paragraph หนึ่งใน text frame และให้การเข้าถึง portion และการจัดรูปแบบระดับ paragraph
* [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) เป็นข้อความรันภายใน paragraph. แต่ละ portion สามารถมีข้อความและการจัดรูปแบบระดับอักขระของตนเอง

ดังนั้น paragraph จึงสามารถบรรจุข้อความที่มีฟอนต์, สี, ขนาด, และการจัดรูปแบบอื่น ๆ ต่างกันโดยใช้หลาย portion

## **สร้างและจัดรูปแบบย่อหน้า**

### **สร้างย่อหน้าด้วยหลาย Portion**

ขั้นตอนต่อไปนี้สร้าง text frame ที่มีสาม paragraph, แต่ละ paragraph มีสาม portion:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่เกี่ยวข้องโดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของ shape
5. ใช้ paragraph เริ่มต้นและเพิ่มวัตถุ [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) อีกสองชิ้นเข้าไปใน text frame
6. เพิ่มวัตถุ [Portion](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) เพียงพอสำหรับแต่ละ paragraph เพื่อให้มีสาม portion. paragraph เริ่มต้นมี portion ว่างหนึ่งตัวอยู่แล้ว
7. กำหนดข้อความของแต่ละ portion
8. ใช้การจัดรูปแบบระดับอักขระผ่าน [Portion.getPortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/getportionformat/)
9. บันทึก presentation ที่แก้ไขแล้ว

ตัวอย่าง JavaScript นี้ดำเนินการตามขั้นตอนดังกล่าว:

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

## **สร้างรายการแบบสัญลักษณ์และลำดับเลข**

### **สร้างรายการแบบสัญลักษณ์หรือเป็นลำดับเลข**

Bullets และการลำดับทำให้รายการที่เกี่ยวข้องอ่านง่ายขึ้น ใน Aspose.Slides การตั้งค่ารายการกำหนดผ่าน [BulletFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/)

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่เกี่ยวข้องโดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์ที่เลือก
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของ shape
5. ลบ paragraph เริ่มต้นออกจาก text frame
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) สำหรับ bullet แบบสัญลักษณ์
7. ตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/settype/) เป็น [BulletType.Symbol](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bullettype/) แล้วระบุอักขระ bullet
8. กำหนดข้อความของ paragraph, ระยะเยื้อง, สีของ bullet, และความสูงของ bullet
9. เพิ่ม paragraph ไปยัง text frame
10. สร้าง paragraph ที่สองและตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/settype/) เป็น [BulletType.Numbered](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bullettype/)
11. กำหนดรูปแบบ bullet แบบลำดับเลขและเพิ่ม paragraph ไปยัง text frame
12. บันทึก presentation

ตัวอย่าง JavaScript นี้สร้าง bullet แบบสัญลักษณ์และ bullet แบบลำดับเลข:

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

Picture bullets ให้คุณใช้ภาพกำหนดเองแทนสัญลักษณ์หรือหมายเลข

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์ที่เกี่ยวข้องโดยใช้ดัชนีของมัน
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) และเข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของมัน
4. ลบ paragraph เริ่มต้นออกจาก text frame
5. โหลดภาพ bullet แล้วเพิ่มเข้าไปในคอลเลกชันภาพของ presentation เป็น [PPImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ppimage/)
6. สร้าง [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) แล้วกำหนดข้อความของมัน
7. ตั้งค่า [BulletFormat.setType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/settype/) เป็น [BulletType.Picture](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bullettype/)
8. กำหนดภาพผ่าน [BulletFormat.getPicture](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/getpicture/) แล้วตั้งค่าความสูงของ bullet
9. เพิ่ม paragraph ไปยัง text frame
10. บันทึก presentation ที่แก้ไขแล้ว

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

### **สร้างรายการหลายระดับ**

ตั้งค่า [ParagraphFormat.setDepth](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setdepth/) เพื่อวาง paragraph ที่ระดับต่าง ๆ ของรายการ ระดับบนสุดมี depth เป็น `0`

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) แล้วเข้าถึงสไลด์
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) แล้วลบ paragraph เริ่มต้นจาก text frame ของมัน
3. สร้างสี่ paragraph แล้วกำหนดรูปสัญลักษณ์ bullet ของแต่ละอัน
4. ตั้งค่า [ParagraphFormat.setDepth](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setdepth/) ของพวกมันเป็น `0`, `1`, `2`, และ `3`
5. เพิ่ม paragraph เหล่านั้นไปยัง text frame แล้วบันทึก presentation

ตัวอย่าง JavaScript นี้สร้างรายการแบบ bullet สี่ระดับ:

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

### **เริ่มรายการลำดับเลขด้วยค่าเฉพาะ**

ใช้ [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) เพื่อตั้งค่าตัวเลขเริ่มต้นที่จะแสดงสำหรับ paragraph ที่เป็นลำดับเลข

1. สร้าง [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) แล้วเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ไปยังสไลด์หนึ่ง
2. ลบ paragraph เริ่มต้นออกจาก text frame ของ shape
3. สร้างสาม paragraph ที่เป็นลำดับเลข
4. ตั้งค่า [BulletFormat.setNumberedBulletStartWith](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/bulletformat/setnumberedbulletstartwith/) เป็น `2`, `3`, และ `7` สำหรับแต่ละ paragraph ตามลำดับ
5. เพิ่ม paragraph ไปยัง text frame แล้วบันทึก presentation

ตัวอย่าง JavaScript นี้กำหนดตัวเลขเริ่มต้นแบบกำหนดเองให้กับแต่ละ paragraph:

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

## **ควบคุมการจัดวางย่อหน้าและคุณสมบัติ End**

### **ตั้งค่า Indent ของบรรทัดแรก**

ใช้ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) เพื่อควบคุมการเยื้องบรรทัดแรกของ paragraph วิธีนี้จะเลื่อนบรรทัดแรกเท่านั้นเทียบกับระยะซ้ายของ paragraph. ค่าบวกจะเลื่อนบรรทัดแรกไปทางขวา, ส่วนบรรทัดที่เหลือจะคงแนวกับเนื้อหา paragraph

ใช้ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) เมื่อจำเป็นต้องย้ายทั้ง paragraph. ใช้ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) เมื่อต้องการย้ายเฉพาะบรรทัดแรก

ตัวอย่างด้านล่างสร้างหลาย paragraph แล้วใช้ค่าที่ต่างกันของ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) เพื่อแสดงว่าการเยื้องบรรทัดแรกมีผลต่อการจัดวางอย่างไร

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของ shape แล้วลบ paragraph เริ่มต้น
5. สร้างหลาย paragraph แล้วตั้งค่า [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) ที่ต่างกันสำหรับแต่ละอัน
6. เพิ่ม paragraph เหล่านั้นไปยัง text frame
7. บันทึก presentation ที่แก้ไขแล้ว

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

Hanging indent คือการจัดวางที่บรรทัดแรกเริ่มอยู่ทางซ้ายของบรรทัดที่เหลือ ใน Aspose.Slides คุณสร้างเอฟเฟกต์นี้ด้วย [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) โดยใส่ค่าลบเพื่อย้ายบรรทัดแรกไปทางซ้ายเทียบกับเนื้อหา paragraph

โดยปกติ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) กำหนดตำแหน่งซ้ายของเนื้อหา paragraph, ส่วน [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) กำหนดตำแหน่งของบรรทัดแรกเทียบกับระยะซ้ายนั้น. เพื่อสร้าง hanging indent ให้ใส่ค่าบวกกับ `setMarginLeft` และค่าลบกับ `setIndent`

การจัดรูปแบบนี้มีประโยชน์สำหรับบรรณานุกรม, การอ้างอิง, รายการศัพท์, และ paragraph อื่น ๆ ที่บรรทัดต่อเนื่องต้องจัดแนวใต้เนื้อหา paragraph แทนใต้ตัวอักษรแรกของบรรทัดแรก

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์เป้าหมาย
3. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) รูปสี่เหลี่ยมผืนผ้าไปยังสไลด์
4. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของ shape แล้วลบ paragraph เริ่มต้น
5. สร้าง paragraph แล้วใส่ค่าบวกกับ [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) สำหรับแต่ละ paragraph
6. ใส่ค่าลบกับ [ParagraphFormat.setIndent](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setindent/) เพื่อสร้างเอฟเฟกต์ hanging indent
7. เพิ่ม paragraph ไปยัง text frame
8. บันทึก presentation ที่แก้ไขแล้ว

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

![การเยื้องห้อยของย่อหน้า](hanging_indent.png)

### **ตั้งค่าคุณสมบัติ End Paragraph Run**

[Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) ควบคุมการจัดรูปแบบของเครื่องหมายสิ้นสุด paragraph ตัวอย่างต่อไปนี้กำหนดขนาดฟอนต์และฟอนต์ Latin ให้กับเครื่องหมายสิ้นสุดของ paragraph ที่สอง:

1. สร้างหรือโหลด [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) แล้วเข้าถึงสไลด์หนึ่ง
2. เพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) แล้วลบ paragraph เริ่มต้นของมัน
3. สร้างสอง paragraph แล้วเพิ่ม portion ของข้อความลงในแต่ละอัน
4. สร้าง [PortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portionformat/) สำหรับเครื่องหมายสิ้นสุดของ paragraph ที่สอง
5. ตั้งค่า [BasePortionFormat.setFontHeight](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) และ [BasePortionFormat.setLatinFont](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setLatinFont)
6. กำหนดรูปแบบด้วย [Paragraph.setEndParagraphPortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/setendparagraphportionformat/) แล้วบันทึก presentation

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

ใช้ [Paragraph.getLinesCount](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/#getLinesCount) เพื่อนับจำนวนบรรทัดที่ paragraph ใช้หลังจากการจัดวางข้อความ, รวมถึงการตัดบรรทัดอัตโนมัติ. สิ่งนี้เป็นประโยชน์เมื่อตรวจสอบความยาวข้อความและการจัดวางในเทมเพลตพรีเซนเทชัน

paragraph เป็นรายการใน [TextFrame.getParagraphs](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#getParagraphs) และอาจใช้หลายบรรทัดที่เรนเดอร์ได้. การใส่ line break อย่างชัดเจนภายใน paragraph จะบังคับให้ขึ้นบรรทัดใหม่โดยไม่สร้าง paragraph ใหม่. การตัดบรรทัดอัตโนมัติจะสร้างบรรทัดตามความกว้างที่มีอยู่โดยไม่เพิ่มตัวอักษร line break ลงในข้อความ. ดังนั้นการนับ paragraph หรืออักขระ line‑break ไม่ได้ให้จำนวนบรรทัดที่เรนเดรได้

ตัวอย่างต่อไปนี้สร้าง shape ที่มีข้อความ, นับบรรทัด, ลดความกว้างของ shape, แล้วแทนที่ข้อความด้วยสตริงสั้นลง. การตัดบรรทัดเปิดไว้และ autofit ปิดเพื่อให้ความกว้างของ shape ควบคุมการตัดบรรทัดโดยไม่ให้ข้อความหรือ shape ลดขนาดโดยอัตโนมัติ. ขนาดของ shape หน่วยเป็น points. สุดท้ายตัวอย่างเพิ่ม paragraph อีกหนึ่งอันและรวมจำนวนบรรทัดจากทั้ง text frame

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

ด้วยข้อความและขนาดเหล่านี้, การทำให้ shape แคบลงจะเพิ่มจำนวนบรรทัด, ขณะเดียวกันการแทนที่ข้อความด้วยสตริงสั้นจะลดจำนวนบรรทัด. จำนวนที่แม่นยำอาจแตกต่างตามการมีฟอนต์, การแทนที่ฟอนต์, ขนาดฟอนต์, ระยะขอบ, การเยื้อง, การตัดบรรทัด, และการตั้งค่า autofit. ให้ใช้ฟอนต์และการตั้งค่าการจัดวางที่ตั้งใจสำหรับสภาพแวดล้อมเป้าหมายเมื่อตรวจสอบเทมเพลต

จำนวนบรรทัดโดยตัวมันเองไม่ได้บ่งบอกว่าข้อความล้นจากคอนเทนเนอร์หรือไม่. ความสูงที่มีอยู่, ความสูงของบรรทัด, ระยะห่างของ paragraph และบรรทัด, รวมถึงพฤติกรรม autofit ก็มีผล; แม้บรรทัดเดียวก็อาจเกินความกว้างที่มีเมื่อปิดการตัดบรรทัด

## **นำเข้าและส่งออกเนื้อหา Paragraph**

### **นำเข้า HTML Text ลงใน Paragraphs**

ใช้ [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/) เพื่อแปลง markup HTML ให้เป็น paragraph และ portion ใน text frame

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์และเพิ่ม [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/)
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของ shape แล้วลบ paragraph เริ่มต้น
4. กำหนดหรืออ่านสตริง HTML ต้นทาง
5. ส่งสตริง HTML ไปยัง [ParagraphCollection.addFromHtml](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphcollection/addfromhtml/)
6. บันทึก presentation ที่แก้ไขแล้ว

ตัวอย่าง JavaScript นี้นำเข้า HTML ลงใน text frame:

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

ใช้ [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) เพื่อส่งออกช่วงของ paragraph ที่เลือกเป็น HTML

1. สร้างหรือโหลดอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/)
2. เข้าถึงสไลด์และหา [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ที่มีข้อความ
3. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของ shape
4. เรียก [ParagraphCollection.exportToHtml](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphcollection/exporttohtml/) พร้อมดัชนี paragraph เริ่มต้นและจำนวน paragraph ที่ต้องการส่งออก
5. เขียนสตริง HTML ที่ได้ไปยังไฟล์

ตัวอย่าง JavaScript นี้สร้าง shape ที่มีข้อความและส่งออกทุก paragraph:

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

### **แสดง Paragraph เป็นภาพ**

[Paragraph.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/#getImage) แสดงผล paragraph เป็นภาพโดยตรงและคืนค่า [IImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/). บันทึกผลลัพธ์เป็นไฟล์ด้วย [IImage.save](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/iimage/#save). คุณไม่จำเป็นต้องเรนเดอร์ shape ทั้งหมดหรือทำการครอป bitmap ด้วยตนเอง

[Paragraph.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/#getImage) อาจคืนค่า `null` หากไม่พบ paragraph ในคอลเลกชันแม่, ไม่มีขอบเขตการเรนเดอร์ที่ถูกต้อง, หรือไม่สามารถเรนเดอร์ได้. ตรวจสอบผลลัพธ์ก่อนบันทึกและทำการ dispose รูปที่คืนค่าเมื่อใช้เสร็จ

#### **แสดง Paragraph ที่อัตราส่วนเริ่มต้น**

กล่องข้อความต่อไปนี้มีสาม paragraph:

![The text box with three paragraphs](paragraph_to_image_input.png)

ตัวอย่างต่อไปนี้แสดง paragraph ที่สองใน shape ข้อความปกติที่อัตราส่วนเริ่มต้นและบันทึกภาพที่ได้เป็น PNG. ส่วน `finally` จะทำให้แน่ใจว่าภาพถูก dispose อย่างถูกต้อง

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

![The paragraph image](paragraph_to_image_output.png)

#### **แสดง Paragraph ในเซลล์ตารางพร้อมการสเกล**

ใช้ overload ของ [Paragraph.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/#getImage) ที่รับพารามิเตอร์ `scaleX` และ `scaleY` เพื่อกำหนดอัตราส่วนแนวนอนและแนวตั้ง ตัวอย่างต่อไปนี้สร้างตาราง, แสดง paragraph ในเซลล์แรกโดยขยายความกว้างและความสูงเป็นสองเท่า แล้วบันทึกผลเป็น PNG

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

ค่า scale `1` จะคงแกนนั้นที่ขนาดพิกเซลเริ่มต้น. ตัวอย่างเช่น `2` สำหรับทั้งสองแกนจะให้ภาพที่กว้างและสูงประมาณสองเท่าของขนาดเริ่มต้น ส่งผลให้มีพิกเซลสี่เท่า. ค่า scale ใหญ่ทำให้ข้อความคมชัดขึ้นสำหรับการซูมหรือผลลัพธ์ความละเอียดสูง, แต่ก็เพิ่มการใช้หน่วยความจำและขนาดไฟล์. ค่าใต`1` จะให้ภาพเล็กลงและรายละเอียดน้อยลง. ใช้ค่า scale เท่ากันเพื่ รักษาอัตราส่วนของ paragraph; ค่าแนวนอนและแนวตั้งที่ต่างกันจะดึงภาพออกในแต่ละทิศ independently

การเรนเดอร์ shape ทั้งหมดด้วย [Shape.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#getImage) ยังคงมีประโยชน์เมื่อผลลัพธ์ต้องรวมการเติมสี, เส้นขอบ, หรือบริบทภาพอื่นของ shape. สำหรับภาพเฉพาะ paragraph ให้ใช้ [Paragraph.getImage](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/#getImage)

## **คำถามที่พบบ่อย**

**ฉันสามารถปิดการตัดบรรทัดภายใน text frame อย่างสมบูรณ์ได้หรือไม่?**

ใช่. ตั้งค่า [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/setwraptext/) ให้เป็น false เพื่อปิดการตัดบรรทัด zodat บรรทัดไม่ตัดที่ขอบของ text frame

**ฉันจะได้ขอบเขตบนสไลด์ของ paragraph เฉพาะได้อย่างไร?**

ใช้ [Paragraph.getRect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/getrect/) เพื่อดึงสี่เหลี่ยมขอบของ paragraph. [Portion.getRect](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/#getRect) ให้ขอบของ portion แยกแต่ละอัน

**การจัดแนว paragraph (ซ้าย, ขวา, กลาง, หรือ justify) ควบคุมที่ไหน?**

[ParagraphFormat.setAlignment](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setalignment/) เป็นการตั้งค่าระดับ paragraph และใช้กับทั้ง paragraph ไม่ว่าจะมีการจัดรูปแบบ portion แยกกันอย่างไร

**ฉันสามารถตั้งค่าภาษา proofing สำหรับส่วนหนึ่งของ paragraph ได้หรือไม่?**

ใช่. ตั้งค่า [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) สำหรับ portion แต่ละอัน, ทำให้ paragraph หนึ่งสามารถมีข้อความหลายภาษาได้