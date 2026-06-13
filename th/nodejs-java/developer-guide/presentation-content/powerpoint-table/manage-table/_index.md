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
description: "สร้างและแก้ไขตารางในสไลด์ PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js ค้นหาตัวอย่างโค้ดง่าย ๆ เพื่อเพิ่มประสิทธิภาพการทำงานกับตารางของคุณ"
---
## **บทนำ**

ตารางใน PowerPoint เป็นวิธีที่มีประสิทธิภาพในการแสดงและสื่อสารข้อมูล ข้อมูลในตารางของเซลล์ (จัดเรียงเป็นแถวและคอลัมน์) มีความชัดเจนและเข้าใจง่าย.

Aspose.Slides มีคลาส [ตาราง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) , [เซลล์](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cell/) และประเภทอื่น ๆ เพื่อให้คุณสามารถสร้าง, อัปเดต, และจัดการตารางในงานนำเสนอทุกประเภท.

## **สร้างตารางจากศูนย์**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน. 
3. กำหนดอาเรย์ของ `columnWidth`.
4. กำหนดอาเรย์ของ `rowHeight`.
5. เพิ่มอ็อบเจ็กต์ [ตาราง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) ไปยังสไลด์โดยใช้เมธอด [addTable](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-).
6. วนซ้ำผ่านแต่ละ [เซลล์](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cell/) เพื่อใช้รูปแบบกับขอบบน, ด้านล่าง, ขวา, และซ้าย.
7. ผสานเซลล์สองเซลล์แรกของแถวแรกของตาราง. 
8. เข้าถึง [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) ของ [เซลล์](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cell/).
9. เพิ่มข้อความบางส่วนลงใน [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/).
10. บันทึกงานนำเสนอที่แก้ไขแล้ว.

```javascript
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
    // ตั้งค่ารูปแบบขอบสำหรับแต่ละเซลล์
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
    // ผสานเซลล์ 1 และ 2 ของแถวที่ 1
    tbl.mergeCells(tbl.getRows().get_Item(0).get_Item(0), tbl.getRows().get_Item(1).get_Item(1), false);
    // เพิ่มข้อความบางส่วนลงในเซลล์ที่ผสาน
    tbl.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells");
    // บันทึกการนำเสนอลงดิสก์
    pres.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การจัดเลขในตารางมาตรฐาน**

ในตารางมาตรฐาน การกำหนดหมายเลขของเซลล์เป็นแบบศูนย์ฐานและง่ายต่อการเข้าใจ เซลล์แรกในตารางมีดัชนีเป็น 0,0 (คอลัมน์ 0, แถว 0). 

ตัวอย่างเช่น เซลล์ในตารางที่มี 4 คอลัมน์และ 4 แถวจะถูกนับเลขดังนี้:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

โค้ด JavaScript นี้แสดงวิธีกำหนดการจัดเลขสำหรับเซลล์ในตาราง:

```javascript
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
    // ตั้งค่ารูปแบบขอบสำหรับแต่ละเซลล์
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
    // บันทึกการนำเสนอลงดิสก์
    pres.save("StandardTables_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เข้าถึงตารางที่มีอยู่**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation).

2. รับอ้างอิงสไลด์ที่มีตารางผ่านดัชนีของมัน. 

3. สร้างอ็อบเจ็กต์ [ตาราง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) แล้วตั้งค่าเป็น null.

4. วนผ่านอ็อบเจ็กต์ [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) ทั้งหมดจนกว่าตารางจะพบ.

    If you suspect the slide you are dealing with contains a single table, you can simply check all the shapes it contains. When a shape is identified as a table, you can typecast it as a [Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) object. But if the slide you are dealing with contains several tables, then you are better off searching for the table you need through its [setAlternativeText(String value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/#setAlternativeText-java.lang.String-).

5. ใช้วัตถุ [ตาราง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) เพื่อทำงานกับตาราง ในตัวอย่างด้านล่าง เราได้เพิ่มแถวใหม่ลงในตาราง.

6. บันทึกงานนำเสนอที่แก้ไขแล้ว.

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
var pres = new aspose.slides.Presentation("UpdateExistingTable.pptx");
try {
    // เข้าถึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // เริ่มต้น TableEx เป็น null
    var tbl = null;
    // วนซ้ำผ่านรูปร่างและตั้งค่าอ้างอิงไปยังตารางที่พบ
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

## **จัดแนวข้อความในตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน. 
3. เพิ่มอ็อบเจ็กต์ [ตาราง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) ไปยังสไลด์.
4. เข้าถึงอ็อบเจ็กต์ [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/) จากตาราง.
5. เข้าถึง [Paragraph](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraph/) ของ [TextFrame](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframe/).
6. จัดแนวข้อความในแนวตั้ง.
7. บันทึกงานนำเสนอที่แก้ไขแล้ว.

```javascript
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
    // เข้าถึงกรอบข้อความ
    var txtFrame = tbl.get_Item(0, 0).getTextFrame();
    // สร้างอ็อบเจ็กต์ Paragraph สำหรับกรอบข้อความ
    var paragraph = txtFrame.getParagraphs().get_Item(0);
    // สร้างอ็อบเจ็กต์ Portion สำหรับย่อหน้า
    var portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // จัดเรียงข้อความในแนวตั้ง
    var cell = tbl.get_Item(0, 0);
    cell.setTextAnchorType(aspose.slides.TextAnchorType.Center);
    cell.setTextVerticalType(aspose.slides.TextVerticalType.Vertical270);
    // บันทึกการนำเสนอลงดิสก์
    pres.save("Vertical_Align_Text_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งค่าการจัดรูปแบบข้อความระดับตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation).
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน. 
3. เข้าถึงอ็อบเจ็กต์ [ตาราง](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) จากสไลด์.
4. ตั้งค่า [setFontHeight(float value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) สำหรับข้อความ.
5. ตั้งค่า [setAlignment(int value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) และ [setMarginRight(float value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-).
6. ตั้งค่า [setTextVerticalType(byte value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. บันทึกงานนำเสนอที่แก้ไขแล้ว. 

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation("simpletable.pptx");
try {
    // สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // ตั้งค่าความสูงของฟอนต์ในเซลล์ตาราง
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.setTextFormat(portionFormat);
    // ตั้งค่าการจัดแนวข้อความและระยะขอบด้านขวาของเซลล์ตารางในหนึ่งคำสั่ง
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.setTextFormat(paragraphFormat);
    // ตั้งค่าชนิดการจัดแนวข้อความแนวตั้งของเซลล์ตาราง
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **รับคุณสมบัติรูปแบบตาราง**

Aspose.Slides ให้คุณดึงคุณสมบัติรูปแบบของตารางเพื่อที่คุณจะใช้รายละเอียดเหล่านั้นกับตารางอื่นหรือที่อื่น โค้ด JavaScript นี้แสดงวิธีดึงคุณสมบัติรูปแบบจากสไตล์ตารางที่กำหนดไว้ล่วงหน้า:

```javascript
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

## **ล็อคอัตราส่วนของตาราง**

อัตราส่วนของรูปร่างเรขาคณิตคืออัตราส่วนของขนาดในมิติต่าง ๆ Aspose.Slides มีคุณสมบัติ [**setAspectRatioLocked**](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/GraphicalObjectLock#setAspectRatioLocked-boolean-) เพื่อให้คุณล็อคการตั้งค่าอัตราส่วนสำหรับตารางและรูปร่างอื่น ๆ.

```javascript
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

**ฉันสามารถเปิดใช้งานการอ่านจากขวาไปซ้าย (RTL) สำหรับตารางทั้งหมดและข้อความในเซลล์ของมันได้หรือไม่?**

ใช่ ตารางมีเมธอด [setRightToLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/table/setrighttoleft/) และย่อหน้ามี [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/setrighttoleft/) การใช้ทั้งสองจะทำให้ลำดับ RTL ถูกต้องและการแสดงผลในเซลล์เป็นไปอย่างเหมาะสม.

**ฉันจะป้องกันไม่ให้ผู้ใช้ย้ายหรือปรับขนาดตารางในไฟล์สุดท้ายได้อย่างไร?**

ใช้การล็อครูปร่างเพื่อปิดการย้าย, ปรับขนาด, การเลือก เป็นต้น การล็อคเหล่านี้ใช้กับตารางด้วยเช่นกัน.

**การแทรกรูปภาพเข้าในเซลล์เป็นพื้นหลังได้รับการรองรับหรือไม่?**

ใช่ คุณสามารถตั้งค่า [picture fill](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillformat/) ให้กับเซลล์; ภาพจะครอบพื้นที่เซลล์ตามโหมดที่เลือก (ยืดหรือเรียงกระเบื้อง).