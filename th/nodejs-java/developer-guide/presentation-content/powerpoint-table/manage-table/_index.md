---
title: จัดการตารางการนำเสนอใน JavaScript
linktitle: จัดการตาราง
type: docs
weight: 10
url: /th/nodejs-java/manage-table/
keywords:
- เพิ่มตาราง
- สร้างตาราง
- เข้าถึงตาราง
- อัตราส่วน
- จัดแนวข้อความ
- การจัดรูปแบบข้อความ
- สไตล์ตาราง
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js ค้นหาตัวอย่างโค้ดง่าย ๆ เพื่อทำให้กระบวนการทำงานกับตารางของคุณรวดเร็วขึ้น"
---
## **บทนำ**

ตารางใน PowerPoint จัดระเบียบข้อมูลเป็นแถวและคอลัมน์ ทำให้การอ่านและเปรียบเทียบค่าเป็นเรื่องง่าย

Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) , คลาส [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) และประเภทอื่น ๆ เพื่อให้คุณสามารถสร้าง, ปรับปรุงและจัดการตารางในงานนำเสนอได้

## **สร้างตารางจากศูนย์**

สร้างตารางโดยระบุตำแหน่ง, ความกว้างของคอลัมน์, และความสูงของแถว หลังจากเพิ่มลงในสไลด์แล้ว คุณสามารถจัดรูปแบบเส้นขอบของเซลล์, ผสานเซลล์, และแทรกข้อความได้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน 
3. กำหนดอาร์เรย์ของความกว้างคอลัมน์ในหน่วยจุด 
4. กำหนดอาร์เรย์ของความสูงแถวในหน่วยจุด 
5. เพิ่มอ็อบเจกต์ [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) ไปยังสไลด์ผ่านเมธอด [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double:A-double:A-) 
6. วนลูปผ่านแต่ละ [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) เพื่อใช้การจัดรูปแบบกับเส้นขอบบน, ล่าง, ขวา, และซ้าย 
7. ผสานเซลล์สองเซลล์แรกของแถวแรกของตาราง 
8. เข้าถึงเซลล์ที่ผสานโดยใช้เมธอด [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame--) 
9. ตั้งค่าข้อความในเซลล์ที่ผสาน 
10. บันทึกงานนำเสนอที่ถูกแก้ไข 

ตัวอย่างด้านล่างสร้างตารางที่มีสามคอลัมน์และห้าแถวที่ตำแหน่ง (100, 50) จุด มันใช้เส้นขอบสีแดงความกว้าง 5 จุด, ผสานเซลล์สองเซลล์แรกในแถวแรก, และบันทึกผลลัพธ์เป็น `table.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **การนับในตารางมาตรฐาน**

ในตารางมาตรฐาน ดัชนีของเซลล์จะเริ่มจากศูนย์และใช้ลำดับ (คอลัมน์, แถว) เซลล์แรกมีดัชนีเป็น (0, 0)

ตัวอย่างเช่น เซลล์ในตารางที่มี 4 คอลัมน์และ 4 แถวจะถูกจัดหมายเลขดังนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

ตัวอย่างนี้สร้างตาราง 4 × 4 ตามที่แสดงข้างต้น โดยให้ความกว้างของคอลัมน์และความสูงของแถวเป็น 70 จุด และเส้นขอบเซลล์สีแดงความกว้าง 5 จุด พิกัดแสดงดัชนีของเซลล์; ตัวอย่างนี้ปล่อยเซลล์ว่างเปล่าและบันทึกตารางเป็น `StandardTables_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const red = java.getStaticFieldValue("java.awt.Color", "RED");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let i = 0; i < table.getRows().size(); i++) {
        const row = table.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            const cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(red);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เข้าถึงตารางที่มีอยู่**

ตารางจะถูกจัดเก็บในคอลเลกชันรูปทรงของสไลด์ การวนลูปผ่านรูปทรงเพื่อค้นหาตาราง แล้วใช้คลาส [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) เพื่ออ่านหรืออัปเดตเซลล์ของมัน

1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 
2. รับอ้างอิงไปยังสไลด์ที่มีตารางโดยใช้ดัชนีของมัน 
3. วนลูปผ่านอ็อบเจกต์ [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) และหยุดเมื่อพบตาราง หากสไลด์มีหลายตาราง ให้ใช้ [getAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getAlternativeText--) เพื่อระบุตารางที่ต้องการ 
4. อัปเดตข้อความในเซลล์เป้าหมาย 
5. บันทึกงานนำเสนอที่แก้ไขแล้ว 

ตัวอย่างด้านล่างเปิดไฟล์ `UpdateExistingTable.pptx` และค้นหาตารางแรกบนสไลด์แรก มันตั้งค่าเซลล์ที่คอลัมน์ 0, แถว 1 เป็น `New` และบันทึกผลลัพธ์เป็น `table1_out.pptx` อินพุตต้องมีอย่างน้อยหนึ่งสไลด์ และตารางแรกบนสไลด์นั้นต้องมีอย่างน้อยหนึ่งคอลัมน์และสองแถว.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    let table = null;

    for (let i = 0; i < slide.getShapes().size(); i++) {
        const shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            table = shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

เพื่อปรับขนาดแถวในตารางที่มีอยู่และเข้าใจว่าทำไมความสูงจริงจึงอาจเกินค่าต่ำสุดที่ร้องขอ ดูที่ [ควบคุมความสูงแถว](/slides/th/nodejs-java/manage-rows-and-columns/#control-row-height)

## **ค้นหาเซลล์ที่เป็นเจ้าของ Text Frame**

เมื่อโค้ดการประมวลผลข้อความทั่วไปได้รับอ็อบเจกต์ [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) จากตาราง ให้ใช้เมธอด [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) เพื่อดึงเซลล์เจ้าของ [Cell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) สำหรับ TextFrame ของเซลล์ตาราง, [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) จะคืนค่าเจ้าของและ [TextFrame.getParentShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentShape--) จะคืนค่า `null` แม้ว่าตารางเองเป็นรูปทรง

พิกัดของเซลล์สามารถเข้าถึงได้ผ่านเมธอดอ่านอย่างเดียว [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) และ [Cell.getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getFirstRowIndex--) [TextFrame.getParentCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/#getParentCell--) ยังให้การนำทางแบบอ่านอย่างเดียว: มันคืนค่าเจ้าของแต่ไม่เปลี่ยนการเป็นเจ้าของ ตรวจสอบเสมอว่าเซลล์ที่ได้รับเป็น `null` ก่อนใช้

สำหรับตัวอย่างที่สมบูรณ์ซึ่งระบุเจ้าของเซลล์ตารางและรูปทรง, รวมถึงรูปทรงที่เชื่อมโยงกับโหนด SmartArt, ดูที่ [ค้นหาและแทนที่ข้อความ](/slides/th/nodejs-java/search-and-replace-text/)

## **จัดแนวข้อความในตาราง**

คุณสามารถควบคุมการยึดแนวตั้งและทิศทางของข้อความในแต่ละเซลล์ของตาราง ตัวอย่างในส่วนนี้ทำให้ข้อความอยู่ตรงกลางในเซลล์แรกและหมุนที่ 270 องศา

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน 
3. เพิ่มอ็อบเจกต์ [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) ไปยังสไลด์ 
4. เข้าถึงอ็อบเจกต์ [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) จากตาราง 
5. เข้าถึง [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) แรกและตั้งค่าข้อความและสีของมัน 
6. ตั้งค่าการยึดแนวตั้งและทิศทางข้อความของเซลล์โดยใช้ [setTextAnchorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextAnchorType-byte-) และ [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setTextVerticalType-byte-) 
7. บันทึกงานนำเสนอที่แก้ไขแล้ว 

ตัวอย่างนี้สร้างตาราง 4 × 4 โดยความกว้างคอลัมน์ 120 จุดและความสูงแถว 100 จุด มันจัดรูปแบบข้อความในเซลล์ (0, 0), เพิ่มค่าให้กับเซลล์ที่เหลือในแถวแรก, และบันทึกผลลัพธ์เป็น `Vertical_Align_Text_out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const black = java.getStaticFieldValue("java.awt.Color", "BLACK");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [120, 120, 120, 120]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    const textFrame = table.get_Item(0, 0).getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);

    const portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(black);

    const cell = table.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าการจัดรูปแบบข้อความระดับตาราง**

ใช้ [setTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setTextFormat-com.aspose.slides.IPortionFormat-) เพื่อใช้การจัดรูปแบบข้อความกับทุกเซลล์ในตาราง วิธีการโอเวอร์โหลดของมันรับการจัดรูปแบบส่วน, ย่อหน้า, และ TextFrame, ดังนั้นคุณสามารถตั้งค่าคุณสมบัติเหล่านี้โดยไม่ต้องวนลูปผ่านแต่ละเซลล์

1. โหลดงานนำเสนอโดยใช้คลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) 
2. รับอ้างอิงไปยังสไลด์โดยใช้ดัชนีของมัน 
3. เข้าถึงอ็อบเจกต์ [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) จากสไลด์ 
4. ตั้งค่าขนาดฟอนต์โดยใช้ [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) สำหรับข้อความ 
5. ตั้งค่าการจัดแนวย่อหน้าและระยะขอบขวาโดยใช้ [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) และ [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) 
6. ตั้งค่าทิศทางของข้อความโดยใช้ [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) 
7. บันทึกงานนำเสนอที่แก้ไขแล้ว 

ตัวอย่างด้านล่างเปิดไฟล์ `table.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์ที่มีตารางเป็นรูปทรงแรก มันตั้งค่าขนาดฟอนต์เป็น 25 จุด, จัดย่อหน้าให้ชิดขวาพร้อมระยะขอบขวา 20 จุด, และทำให้ข้อความเป็นแนวตั้ง งานนำเสนอที่จัดรูปแบบแล้วจะถูกบันทึกเป็น `result.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    const paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    const textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **รับคุณสมบัติสไตล์ของตาราง**

ใช้ [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) เพื่ออ่านสไตล์ที่กำหนดไว้ล่วงหน้าของตารางและใช้ [setStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setStylePreset-int-) เพื่อกำหนดค่า ตัวอย่างนี้ใช้ [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/) กับตารางหนึ่ง, พิมพ์ค่าพรีเซ็ต, และกำหนดพรีเซ็ตเดียวกันให้กับตารางที่สอง ทั้งสองตารางถูกบันทึกใน `table-style.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log("Table style preset: " + stylePreset);

    const anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ล็อกอัตราส่วนของตาราง**

อัตราส่วนของตารางคืออัตราส่วนระหว่างความกว้างกับความสูง ใช้ [setAspectRatioLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked-boolean-) เพื่อทำการล็อกอัตราส่วนนี้สำหรับตาราง

ตัวอย่างด้านล่างเปิดไฟล์ `pres.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์ที่มีตารางเป็นรูปทรงแรก มันพิมพ์สถานะล็อกปัจจุบัน, เปิดการล็อกอัตราส่วน, พิมพ์สถานะที่อัปเดต (`true`), และบันทึกผลลัพธ์เป็น `pres-out.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**ฉันสามารถเปิดใช้งานทิศทางการอ่านจากขวาไปซ้าย (RTL) สำหรับตารางทั้งหมดและข้อความในเซลล์ของมันได้หรือไม่?**

ใช่ ตารางมีเมธอด [setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setRightToLeft-boolean-) และย่อหน้ามีเมธอด [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setRightToLeft-byte-) การใช้ทั้งสองจะทำให้ลำดับ RTL ถูกต้องและการแสดงผลภายในเซลล์เป็นไปตามที่ต้องการ

**ฉันจะป้องกันไม่ให้ผู้ใช้ย้ายหรือปรับขนาดตารางในไฟล์สุดท้ายได้อย่างไร?**

ใช้ [shape locks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/graphicalobjectlock/) เพื่อปิดการย้าย, ปรับขนาด, การเลือก ฯลฯ การล็อกเหล่านี้ใช้กับตารางด้วย

**การแทรกรูปภาพภายในเซลล์เป็นพื้นหลังได้รับการสนับสนุนหรือไม่?**

ใช่ คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) สำหรับเซลล์; ภาพจะครอบคลุมพื้นที่เซลล์ตามโหมดที่เลือก (ขยายหรือซ้ำ).