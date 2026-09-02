---
title: จัดการตารางการนำเสนอด้วย JavaScript
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
- รูปแบบข้อความ
- สไตล์ตาราง
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js. ค้นพบตัวอย่างโค้ดง่าย ๆ เพื่อทำให้กระบวนการทำงานกับตารางของคุณเป็นระเบียบ"
---
## **Introduction**

ตารางใน PowerPoint เป็นวิธีที่มีประสิทธิภาพในการแสดงและสื่อสารข้อมูล ข้อมูลในกริดของเซลล์ (จัดเรียงเป็นแถวและคอลัมน์) เข้าใจง่ายและตรงไปตรงมา

Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) , [Cell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cell/) และประเภทอื่น ๆ ที่ช่วยให้คุณสร้าง, อัปเดตและจัดการตารางในงานนำเสนอทุกประเภท

## **Create Table from Scratch**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. กำหนดอาร์เรย์ของ `columnWidth`  
4. กำหนดอาร์เรย์ของ `rowHeight`  
5. เพิ่มอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) ไปยังสไลด์ผ่านเมธอด [addTable](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-)  
6. วนลูปผ่านแต่ละ [Cell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cell/) เพื่อกำหนดรูปแบบให้ขอบบน, ล่าง, ขวาและซ้าย  
7. ผสานสี่เซลล์ในมุมบนซ้ายของตาราง (สองคอลัมน์แรกของสองแถวแรก) ให้เป็นเซลล์เดียว  
8. เข้าถึง [Cell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cell/)'s [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/)  
9. เพิ่มข้อความบางส่วนลงใน [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/)  
10. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด JavaScript นี้แสดงวิธีสร้างตารางในงานนำเสนอ:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // เพิ่มรูปร่างตารางลงในสไลด์
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // กำหนดรูปแบบเส้นขอบสำหรับแต่ละเซลล์
    for (var row = 0; row < tbl.getRows().size(); row++) {
        for (var cell = 0; cell < tbl.getRows().get_Item(row).size(); cell++) {
            var cellFormat = tbl.getRows().get_Item(row).get_Item(cell).getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderTop().setWidth(5);
            cellFormat.getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderBottom().setWidth(5);
            cellFormat.getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderLeft().setWidth(5);
            cellFormat.getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cellFormat.getBorderRight().setWidth(5);
        }
    }
    // ผสานบล็อกเซลล์ 2x2 ที่อยู่ด้านบนซ้ายให้เป็นเซลล์เดียว
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // เพิ่มข้อความบางส่วนลงในเซลล์ที่ผสานแล้ว
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // บันทึกการนำเสนอลงดิสก์
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Numbering in Standard Table**

ในตารางมาตรฐาน การนับลำดับของเซลล์เป็นศูนย์ฐาน (zero‑based) เซลล์แรกในตารางจะมีดัชนีเป็น 0,0 (คอลัมน์ 0, แถว 0)

ตัวอย่างเช่น เซลล์ในตารางที่มี 4 คอลัมน์และ 4 แถวจะมีการจัดลำดับดังนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

โค้ด JavaScript นี้แสดงวิธีระบุการนับลำดับของเซลล์ในตาราง:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // เพิ่มรูปร่างตารางลงในสไลด์
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // กำหนดรูปแบบเส้นขอบสำหรับแต่ละเซลล์
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // บันทึกการนำเสนอไปยังดิสก์
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Access Existing Table**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ที่มีตารางผ่านดัชนีของมัน  
3. สร้างอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) แล้วกำหนดค่าเป็น null  
4. วนลูปผ่านอ็อบเจกต์ [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) ทั้งหมดจนกว่าจะพบตาราง  

   หากคุณสงสัยว่าสไลด์ที่ทำงานอยู่มีเพียงตารางเดียว คุณสามารถตรวจสอบทุก shape ที่มันมีได้ เมื่อพบ shape ที่ระบุว่าเป็นตาราง คุณสามารถแคสต์เป็นอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) ได้ แต่ถ้าสไลด์มีหลายตาราง คุณควรค้นหาตารางที่ต้องการผ่านเมธอด [setAlternativeText(String value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-)  

5. ใช้อ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) เพื่อทำงานกับตาราง ในตัวอย่างด้านล่าง เราตั้งค่าข้อความของเซลล์หนึ่งในตาราง  
6. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด JavaScript นี้แสดงวิธีเข้าถึงและทำงานกับตารางที่มีอยู่:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // เข้าถึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // เริ่มต้น TableEx เป็น null
    var tbl = null;
    // วนรอบผ่าน shapes และตั้งค่าอ้างอิงไปยังตารางที่พบ
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // ตั้งค่าข้อความสำหรับคอลัมน์แรกของแถวที่สอง
            tbl.get_Item(0, 1).getTextFrame().setText("New");
        }
    }
    // บันทึกการนำเสนอที่แก้ไขแล้วลงดิสก์
    pres.save("table1_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Find the Cell That Owns a Text Frame**

เมื่อโค้ดประมวลผลข้อความทั่วไปได้รับ [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) จากตาราง ให้ใช้เมธอด [TextFrame.getParentCell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#getParentCell--) เพื่อดึง [Cell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cell/) เจ้าของ สำหรับ TextFrame ของเซลล์ตาราง, [TextFrame.getParentCell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#getParentCell--) จะคืนเจ้าของและ [TextFrame.getParentShape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#getParentShape--) จะคืนค่า `null` แม้ว่าตารางเองเป็น shape ก็ตาม  

พิกัดของเซลล์สามารถเข้าถึงได้ผ่านเมธอดอ่านอย่างเดียว [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cell/#getFirstColumnIndex--) และ [Cell.getFirstRowIndex](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cell/#getFirstRowIndex--)  [TextFrame.getParentCell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/#getParentCell--) ยังให้การนำทางแบบอ่านอย่างเดียว: มันคืนเจ้าของแต่ไม่เปลี่ยนสภาพของการเป็นเจ้าของ ให้ตรวจสอบว่าเซลล์ที่ได้เป็น `null` ก่อนใช้งานเสมอ  

สำหรับตัวอย่างสมบูรณ์ที่ระบุตัวตนของเจ้าของเซลล์ตารางและ shape รวมถึง shape ที่เชื่อมโยงกับโหนด SmartArt ดูที่ [Search and Replace Text](/slides/th/nodejs-java/search-and-replace-text/)

## **Align Text in Table**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เพิ่มอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) ไปยังสไลด์  
4. เข้าถึงอ็อบเจกต์ [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) จากตาราง  
5. เข้าถึง [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) ของ [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/)  
6. จัดแนวข้อความในแนวตั้ง  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด JavaScript นี้แสดงวิธีจัดแนวข้อความในตาราง:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    // รับสไลด์แรก
    var slide = pres.getSlides().get_Item(0);
    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    var dblCols = java.newArray("double", [120, 120, 120, 120]);
    var dblRows = java.newArray("double", [100, 100, 100, 100]);
    // เพิ่มรูปร่างตารางลงในสไลด์
    var tbl = slide.getShapes().addTable(100, 50, dblCols, dblRows);
    tbl.get_Item(1, 0).getTextFrame().setText("10");
    tbl.get_Item(2, 0).getTextFrame().setText("20");
    tbl.get_Item(3, 0).getTextFrame().setText("30");
    // เข้าถึง TextFrame
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // สร้างอ็อบเจกต์ Paragraph สำหรับ TextFrame
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // สร้างอ็อบเจกต์ Portion สำหรับ Paragraph
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // จัดแนวข้อความในแนวตั้ง
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(java.newByte(aspose.slides.TextAnchorType.Center));
    cell.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));
    // บันทึกการนำเสนอไปยังดิสก์
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Text Formatting on Table Level**

1. สร้างอินสแตนซ์ของ คลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation)  
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
3. เข้าถึงอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) จากสไลด์  
4. ตั้งค่า [setFontHeight(float value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) สำหรับข้อความ  
5. ตั้งค่า [setAlignment(int value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) และ [setMarginRight(float value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-)  
6. ตั้งค่า [setTextVerticalType(byte value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-)  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

โค้ด JavaScript นี้แสดงวิธีนำทางเลือกการจัดรูปแบบที่คุณต้องการไปใช้กับข้อความในตาราง:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // ตั้งค่าความสูงของฟอนต์ในเซลล์ตาราง
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // ตั้งค่าการจัดแนวข้อความและระยะขอบด้านขวาของเซลล์ตารางในคำสั่งเดียว
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // ตั้งค่าประเภทการจัดแนวข้อความแนวตั้งของเซลล์ตาราง
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical));
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Set Table Style Preset**

Aspose.Slides มีสไตล์ตารางของ PowerPoint ที่สร้างมาในตัวเป็น enumeration [TableStylePreset](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/tablestylepreset/) ดังนั้นคุณสามารถใช้ลุคเดียวกันกับตารางใด ๆ โค้ด JavaScript นี้แสดงวิธีแทนที่สไตล์เริ่มต้นของตารางด้วยสไตล์ที่กำหนดล่วงหน้า:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var pres = new aspose.slides.Presentation();
try {
    var table = pres.getSlides().get_Item(0).getShapes().addTable(10, 10, java.newArray("double", [100, 150]), java.newArray("double", [5, 5, 5]));
    table.setStylePreset(aspose.slides.TableStylePreset.DarkStyle1);// เปลี่ยนธีมสไตล์พรีเซ็ตเริ่มต้น
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lock Aspect Ratio of Table**

อัตราส่วนของรูปทรงเรขาคณิตคือสัดส่วนของขนาดในมิติที่ต่างกัน Aspose.Slides มีคุณสมบัติ [**setAspectRatioLocked**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) เพื่อให้คุณล็อคการตั้งค่าอัตราส่วนของตารางและรูปทรงอื่น ๆ  

โค้ด JavaScript นี้แสดงวิธีล็อคอัตราส่วนสำหรับตาราง:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    table.getGraphicalObjectLock().setAspectRatioLocked(!table.getGraphicalObjectLock().getAspectRatioLocked());// invert
    console.log("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**ฉันสามารถเปิดใช้งานทิศทางการอ่านจากขวาไปซ้าย (RTL) สำหรับตารางทั้งหมดและข้อความในเซลล์ได้หรือไม่?**

ได้ ตารางมีเมธอด [setRightToLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/table/setrighttoleft/) และย่อหน้ามี [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/) การใช้ทั้งสองจะทำให้ลำดับ RTL และการเรนเดอร์ภายในเซลล์ถูกต้อง

**ฉันจะป้องกันผู้ใช้ไม่ให้ย้ายหรือปรับขนาดตารางในไฟล์สุดท้ายได้อย่างไร?**

ใช้การล็อค shape เพื่อปิดการย้าย, ปรับขนาด, การเลือก ฯลฯ ซึ่งการล็อคนี้ใช้กับตารางด้วย

**การแทรกรูปภาพเป็นพื้นหลังในเซลล์ได้รับการสนับสนุนหรือไม่?**

ได้ คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/) สำหรับเซลล์; รูปภาพจะครอบพื้นที่เซลล์ตามโหมดที่เลือก (ยืดหรือเรียงต่อกัน)  