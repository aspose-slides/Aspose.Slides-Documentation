---
title: รับคุณสมบัติรูปทรงที่มีผลจากการนำเสนอใน JavaScript
linktitle: คุณสมบัติที่มีผล
type: docs
weight: 50
url: /th/nodejs-java/shape-effective-properties/
keywords:
- คุณสมบัติรูปทรง
- คุณสมบัติกล้อง
- ระบบแสง
- รูปทรงบเวล
- กรอบข้อความ
- สไตล์ข้อความ
- ความสูงของฟอนต์
- รูปแบบการเติม
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "เรียนรู้วิธีใช้ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อแยกแยะการจัดรูปแบบรูปทรงที่ท้องถิ่น, สืบทอด, และมีผลในงานนำเสนอ PowerPoint"
---
## **ทำความเข้าใจค่าคุณสมบัติท้องถิ่น, สืบทอด, และผลลัพธ์ที่มีผล**

รูปแบบของ PowerPoint สามารถมาจากหลายที่ ค่า ที่เก็บโดยตรงบนอ็อบเจ็กต์คือ **ค่าท้องถิ่น** หากค่านั้นไม่ได้ตั้งค่า PowerPoint จะตรวจสอบแหล่งรูปแบบของพาเรนต์ เช่น ค่าตั้งต้นของย่อหน้า, สไตล์ข้อความ, รูปแบบเลเอาต์หรือมาสเตอร์สไลด์, ธีม, หรือค่าตั้งต้นระดับการนำเสนอ ค่าต่าง ๆ เหล่านั้นคือ **ค่าที่สืบทอด** ค่าที่เหลืออยู่หลังจากการแก้ลำดับชั้นทั้งหมดเรียบร้อยคือ **ค่าที่มีผล** — ค่าที่ใช้ในการแสดงอ็อบเจ็กต์

ตัวอย่างเช่น ส่วนของข้อความอาจไม่ได้กำหนดความสูงของฟอนต์ของตนเอง ค่าท้องถิ่นของ [getFontHeight](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portionformat/#getFontHeight) จะเป็น `NaN` ซึ่งหมายถึง “ไม่ได้ตั้งค้าที่นี่” ส่วนข้อความนี้สามารถสืบทอดความสูงจากย่อหน้า, สไตล์ข้อความตั้งต้นของการนำเสนอ, หรือแหล่งอื่น ๆ ที่เกี่ยวข้อง การเรียก [getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portionformat/#getEffective) บนรูปแบบ Portion จะคืนค่าความสูงที่ได้แก้ไขแล้ว

ใช้ข้อมูลการจัดรูปแบบสองประเภทนี้เพื่อวัตถุประสงค์ที่แตกต่างกัน:

- อ่านหรือเปลี่ยนอ็อบเจ็กต์รูปแบบท้องถิ่น เช่น [PortionFormat](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portionformat/) เมื่อคุณต้องการควบคุมว่าค่าอยู่ที่ไหน
- อ่าน **ข้อมูลที่มีผล** ที่คืนมาจาก `PortionFormat.getEffective` เมื่อคุณต้องการผลลัพธ์ที่แสดงขั้นสุดท้าย ข้อมูลที่มีผลเป็นแบบอ่านอย่างเดียว

ก่อนเรียกตัวอย่าง, [install Aspose.Slides for Node.js via Java](/slides/th/nodejs-java/installation/).

## **เปรียบเทียบค่าท้องถิ่น, สืบทอด, และผลลัพธ์ที่มีผล**

ตัวอย่างเต็มต่อไปนี้สร้างรูปทรงและกำหนดความสูงของฟอนต์ที่ระดับการนำเสนอ, ย่อหน้า, และส่วนของข้อความ แต่ละขั้นตอนพิมพ์ค่าที่กำหนดในแต่ละระดับและค่าที่มีผลที่ได้จากส่วนข้อความเดียวกัน นอกจากนี้ยังแสดงว่าทำไมต้องอ่านข้อมูลที่มีผลใหม่หลังจากการเปลี่ยนแปลงรูปแบบ

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // อ่านข้อมูลที่มีผลหลังจากการเปลี่ยนแปลงก่อนหน้า.
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // กำหนดค่าที่สืบทอดที่สองระดับแตกต่างกัน.
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // ค่าท้องถิ่นบนส่วนข้อความจะทับค่าที่สืบทอดทั้งสองค่า.
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // การเปลี่ยนค่าที่สืบทอดจะไม่ทับค่าท้องถิ่นที่มีอยู่.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // ลบค่าท้องถิ่นออก ส่วนข้อความจะสืบทอดจากย่อหน้าอีกครั้ง.
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // ลบค่าของย่อออก ค่าตั้งต้นของการนำเสนอจะให้ผลลัพธ์แทน.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ความสำคัญในตัวอย่างนี้คือรูปแบบท้องถิ่นของส่วนข้อความ, ตามด้วยรูปแบบของย่อหน้า, แล้วตามด้วยค่าตั้งต้นของการนำเสนอ อ็อบเจ็กต์อื่น ๆ อาจมีโซ่การสืบทอดที่ต่างกัน แต่หลักการเดียวกัน: ค่าที่ระบุอย่างเฉพาะเจาะจงมากกว่าจะชนะ, และ [getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portionformat/#getEffective) จะคืนผลลัพธ์ขั้นสุดท้าย

## **รับคุณสมบัติข้อความที่มีผล**

การจัดรูปแบบข้อความถูกแบ่งออกเป็นหลายอ็อบเจ็กต์:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/#getEffective) แก้ไขคุณสมบัติกรอบข้อความเช่น ระยะขอบ, การยึด, การปรับอัตโนมัติ, และทิศทางข้อความแนวตั้ง
- [TextStyle.getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textstyle/#getEffective) แก้ไขรูปแบบย่อหน้าสำหรับแต่ละระดับของสไตล์ข้อความ
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/#getEffective) แก้ไขคุณสมบัติกย่อหน้าเช่น การจัดแนว, การเยื้อง, และสัญลักษณ์หัวข้อ
- [PortionFormat.getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portionformat/#getEffective) แก้ไขคุณสมบัติตัวอักษรเช่น ความสูงของฟอนต์, แบบอักษร, สี, ตัวหนา, และตัวเอียง

สำหรับตัวอย่างต่อไป, `text-formatting.pptx` ต้องมีอย่างน้อยหนึ่งสไลด์และหนึ่ง [AutoShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/autoshape/) ที่มีกรอบข้อความที่ไม่ว่างเปล่า AutoShape สามารถอยู่ในตำแหน่งใดก็ได้ในคอลเลกชันของรูปทรง; โค้ดจะค้นหาอ็อบเจ็กต์ที่เหมาะสมและตรวจสอบก่อนใช้งาน

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **รับคุณสมบัติ 3D ที่มีผล**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#getEffective) คืนอ็อบเจ็กต์ข้อมูลที่มีผลหนึ่งตัวซึ่งรวมการตั้งค่า 3D ทั้งหมดที่แก้ไขแล้ว วิธีการ [getCamera](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#getCamera), [getLightRig](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#getLightRig), [getBevelTop](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#getBevelTop), และ [getBevelBottom](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/threedformat/#getBevelBottom) เปิดเผยข้อมูลที่มีผลที่สอดคล้องกัน การอ่านการตั้งค่าเหล่านี้ร่วมกันทำให้เข้าใจลักษณะ 3D ที่สุดของรูปทรงได้ง่ายขึ้น

สำหรับตัวอย่างนี้, `shape-3d.pptx` ต้องมีอย่างน้อยหนึ่งรูปทรงบนสไลด์แรก ของคุณอาจเพิ่มการตั้งค่ากล้อง 3D, แสง, หรือ bevel ให้กับรูปทรงนั้นหากต้องการให้ผลลัพธ์มีค่าที่แตกต่างจากค่าเริ่มต้น

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **รับการจัดรูปแบบตารางที่มีผล**

การจัดรูปแบบตารางสามารถมาจากสไตล์ของตารางและจากรูปแบบที่นำไปใช้กับตารางทั้งหมด, คอลัมน์, แถว, หรือเซลล์แต่ละเซลล์ สำหรับความขัดแย้งของการเติมสีที่กำหนดโดยชัดเจน ความสำคัญคือ เซลล์, แถว, คอลัมน์, และสุดท้ายคือทั้งตาราง รูปแบบที่มีผลของเซลล์คือรูปแบบสุดท้ายที่ใช้วาดเซลล์นั้น

สำหรับตัวอย่างนี้, `table-formatting.pptx` ต้องมีอย่างน้อยหนึ่งตารางบนสไลด์แรก ตารางต้องมีอย่างน้อยหนึ่งแถวและหนึ่งคอลัมน์ โค้ดจะค้นหา [Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/table/) แทนการสมมติว่า `getShapes().get_Item(0)` คือ ตาราง

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

หากคุณต้องการสีมากกว่าชนิดการเติม, ให้ตรวจสอบ [getFillType](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fillformat/#getFillType) ก่อน, แล้วจึงอ่านเมธอดที่สอดคล้องกับชนิดนั้น — ตัวอย่างเช่น [getSolidFillColor](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/fillformat/#getSolidFillColor) สำหรับการเติมแบบสีทึบ

## **อ่านข้อมูลที่มีผลใหม่หลังจากการเปลี่ยนแปลง**

ข้อมูลที่มีผลอธิบายลำดับชั้นของรูปแบบในขณะนั้นเมื่อถูกแก้ไข ให้เรียก `getEffective` อีกครั้งหลังจากเปลี่ยนแปลงสิ่งใดที่อาจมีส่วนร่วมในลำดับชั้นนั้น, รวมถึง:

- การจัดรูปแบบท้องถิ่นของอ็อบเจ็กต์
- ค่าตั้งต้นของย่อหน้า หรือกรอบข้อความ
- สไตล์ตาราง, ตาราง, คอลัมน์, แถว, หรือรูปแบบเซลล์
- การจัดรูปแบบของเลเอาต์หรือมาสเตอร์สไลด์
- ข้อมูลธีมหรือค่าตั้งต้นระดับการนำเสนอ
- เลเอาต์หรือมาสเตอร์ที่กำหนดให้กับสไลด์

ห้ามเก็บอ็อบเจ็กต์ข้อมูลที่มีผลเป็นสแนปช็อตถาวร Aspose.Slides อาจแคชข้อมูลที่มีผลบางส่วนภายใน, และการเรียก `getEffective` ครั้งต่อมาสามารถรีเฟรชข้อมูลนั้นได้ หากต้องการเปรียบเทียบค่าก่อนและหลังการเปลี่ยนแปลง, ให้คัดลอกค่ามาตรฐานที่ต้องการ เช่น ความสูงของฟอนต์, สี, การจัดแนว, หรือความกว้างของ bevel ไปยังตัวแปรของคุณเองก่อนทำการเปลี่ยนแปลง

เพื่อเปลี่ยนค่า, ให้อัปเดตอ็อบเจ็กต์รูปแบบท้องถิ่นที่เหมาะสมแล้วเรียก `getEffective` เพื่อตรวจสอบผลลัพธ์ ข้อมูลที่มีผลเองเป็นแบบอ่านอย่างเดียว

## **FAQ**

**ฉันจะบอกได้อย่างไรว่าระดับใดให้ค่าที่มีผล?**

ข้อมูลที่มีผลบรรจุค่าขั้นสุดท้าย, ไม่ได้บอกแหล่งที่มา ตรวจสอบอ็อบเจ็กต์ท้องถิ่นที่เกี่ยวข้องจากระดับที่เจาะจงที่สุดออกไปเป็นระดับที่กว้างกว่า สำหรับข้อความอาจรวมถึงส่วนของข้อความ, ย่อหน้า, กรอบข้อความ, เลเอาต์, มาสเตอร์, ธีม, และค่าตั้งต้นของการนำเสนอ ค่าที่ไม่ได้กำหนดเช่น `NaN` หรือ `null` แสดงว่าการค้นหายังดำเนินต่อไปที่ระดับอื่น

**จะเกิดอะไรขึ้นเมื่อไม่มีระดับใดกำหนดคุณสมบัตินั้น?**

Aspose.Slides จะเลือกใช้ค่าตั้งต้นของ PowerPoint หรือไลบรารีที่เหมาะสม ค่าที่ถูกแก้ไขนั้นจะปรากฏในข้อมูลที่มีผลแม้ว่าจะไม่มีอ็อบเจ็กต์ท้องถิ่นใดกำหนดโดยตรง

**ทำไมค่าที่มีผลบางครั้งจึงเท่ากับค่าท้องถิ่น?**

ค่าท้องถิ่นชนะการคำนวณการสืบทอด นี่เป็นผลตามปกติเมื่อคุณสมบัตินั้นถูกตั้งค่าอย่างชัดเจนบนอ็อบเจ็กต์และไม่มีกฎที่เจาะจงมากกว่านั้นมากำหนดให้ทับ

**เมื่อใดควรใช้ข้อมูลท้องถิ่นแทนข้อมูลที่มีผล?**

ใช้ข้อมูลท้องถิ่นเมื่อต้องการตรวจสอบหรือแก้ไขระดับการจัดรูปแบบเฉพาะ ใช้ข้อมูลที่มีผลเมื่อคุณต้องการผลลัพธ์ขั้นสุดท้ายหลังจากการสืบทอด, กฎธีม, และสไตล์ที่เกี่ยวข้องถูกแก้ไขแล้ว [ตัวอย่างเปรียบเทียบอย่างครบถ้วน](#compare-local-inherited-and-effective-values) แสดงให้เห็นทั้งสองแบบในขั้นตอนทำงานเดียวกัน.