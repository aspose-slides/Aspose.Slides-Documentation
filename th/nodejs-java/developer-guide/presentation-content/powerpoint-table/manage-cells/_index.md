---
title: จัดการเซลล์ตารางในงานนำเสนอด้วย JavaScript
linktitle: จัดการเซลล์
type: docs
weight: 30
url: /th/nodejs-java/manage-cells/
keywords:
- เซลล์ตาราง
- รวมเซลล์
- ลบขอบ
- แยกเซลล์
- รูปภาพในเซลล์
- สีพื้นหลัง
- PowerPoint
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการเซลล์ตารางใน PowerPoint ด้วย Aspose.Slides สำหรับ Node.js. เชี่ยวชาญการเข้าถึง, แก้ไขและจัดรูปแบบเซลล์อย่างรวดเร็วเพื่อการทำงานอัตโนมัติของสไลด์ที่ไร้รอยต่อ."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเข้าถึงและแก้ไขเซลล์ตารางในงานนำเสนอ PowerPoint บทความนี้อธิบายวิธีระบุเซลล์ตารางที่รวมกัน, ลบขอบเซลล์, ทำงานกับการจัดหมายเลขเซลล์หลังจากรวมหรือแยกเซลล์, เปลี่ยนสีพื้นหลังของเซลล์, และเพิ่มรูปภาพภายในเซลล์ตาราง ตัวอย่างแสดงวิธีสร้างหรือเปิดงานนำเสนอ, ดึงตารางจากสไลด์, อัปเดตการจัดรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

## **ระบุเซลล์ตารางที่รวมกัน**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
2. รับตารางจากสไลด์แรก 
3. วนลูปผ่านแถวและคอลัมน์ของตารางเพื่อค้นหาเซลล์ที่รวมกัน 
4. พิมพ์ข้อความเมื่อพบเซลล์ที่รวมกัน 

โค้ด JavaScript นี้แสดงวิธีระบุเซลล์ตารางที่รวมกันในงานนำเสนอ:

```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);// สมมติว่า Slide#0.Shape#0 เป็นตาราง
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ลบขอบเซลล์ตาราง**
1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. กำหนดอาเรย์ของคอลัมน์พร้อมความกว้าง 
4. กำหนดอาเรย์ของแถวพร้อมความสูง 
5. เพิ่มตารางลงในสไลด์ผ่านเมธอด [addTable](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) 
6. วนลูปผ่านทุกเซลล์เพื่อเคลียร์ขอบบน, ล่าง, ขวา, และซ้าย 
7. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX 

โค้ด JavaScript นี้แสดงวิธีลบขอบจากเซลล์ตาราง:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // กำหนดคอลัมน์พร้อมความกว้างและแถวพร้อมความสูง
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // เพิ่มรูปร่างตารางลงในสไลด์
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // ตั้งค่าฟอร์แมตขอบสำหรับแต่ละเซลล์
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การจัดหมายเลขในเซลล์ที่รวมกัน**
หากเรารวมเซลล์ 2 คู่คือ (1, 1) × (2, 1) และ (1, 2) × (2, 2) ตารางที่ได้จะถูกจัดหมายเลข โค้ด JavaScript นี้สาธิตกระบวนการ:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // เพิ่มรูปร่างตารางลงในสไลด์
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // ตั้งค่าฟอร์แมตขอบสำหรับแต่ละเซลล์
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
    // รวมเซลล์ (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // รวมเซลล์ (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

จากนั้นเราจะรวมเซลล์ต่อโดยรวม (1, 1) และ (1, 2) ผลลัพธ์คือ ตารางที่มีเซลล์ที่รวมใหญ่ตรงกลาง:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
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
    // รวมเซลล์ (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // รวมเซลล์ (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // รวมเซลล์ (1, 1) x (1, 2)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **การจัดหมายเลขในเซลล์ที่แยกออก**
ในตัวอย่างก่อนหน้าเมื่อเซลล์ตารางถูกรวม การจัดหมายเลขหรือระบบเลขในเซลล์อื่น ๆ ไม่ได้เปลี่ยนแปลง

ครั้งนี้เราจะใช้ตารางปกติ (ตารางที่ไม่มีเซลล์ที่รวม) แล้วลองแยกเซลล์ (1,1) เพื่อให้ได้ตารางพิเศษ คุณอาจต้องสนใจการจัดหมายเลขของตารางนี้ซึ่งอาจดูแปลก แต่เช่นนั้นคือวิธีที่ Microsoft PowerPoint จัดหมายเลขเซลล์ตารางและ Aspose.Slides ทำเช่นเดียวกัน

โค้ด JavaScript นี้สาธิตกระบวนการที่อธิบาย:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
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
    // รวมเซลล์ (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // รวมเซลล์ (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // แยกเซลล์ (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // บันทึกไฟล์ PPTX ไปยังดิสก์
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

โค้ด JavaScript นี้แสดงวิธีเปลี่ยนสีพื้นหลังของเซลล์ตาราง:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // สร้างตารางใหม่
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // ตั้งค่าสีพื้นหลังให้เซลล์
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **เพิ่มรูปภาพภายในเซลล์ตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Presentation) 
2. รับอ้างอิงสไลด์ผ่านดัชนีของมัน 
3. กำหนดอาเรย์ของคอลัมน์พร้อมความกว้าง 
4. กำหนดอาเรย์ของแถวพร้อมความสูง 
5. เพิ่มตารางลงในสไลด์ผ่านเมธอด [addTable](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-) 
6. สร้างอ็อบเจ็กต์ `Images` เพื่อเก็บไฟล์รูปภาพ 
7. เพิ่มรูปภาพ `IImage` ไปยังอ็อบเจ็กต์ `PPImage` 
8. ตั้งค่า `FillFormat` ของเซลล์ตารางเป็น `Picture` 
9. เพิ่มรูปภาพลงในเซลล์แรกของตาราง 
10. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX 

โค้ด JavaScript นี้แสดงวิธีวางรูปภาพภายในเซลล์ตารางเมื่อสร้างตาราง:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
var pres = new aspose.slides.Presentation();
try {
    // เข้าถึงสไลด์แรก
    var islide = pres.getSlides().get_Item(0);
    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // เพิ่มรูปร่างตารางลงในสไลด์
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // สร้างอ็อบเจ็กต์ PPImage ด้วยไฟล์รูปภาพ
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // เพิ่มรูปภาพลงในเซลล์ตารางแรก
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // บันทึกไฟล์ PPTX ลงในดิสก์
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**ฉันสามารถตั้งความหนาและสไตล์ของเส้นแตกต่างกันสำหรับแต่ละด้านของเซลล์เดียวได้หรือไม่?**

ใช่. ขอบ [top](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/cellformat/getborderright/) มีคุณสมบัติแยกกัน ดังนั้นความหนาและสไตล์ของแต่ละด้านจึงสามารถแตกต่างกันได้ ซึ่งสอดคล้องกับการควบคุมขอบแยกแต่ละด้านสำหรับเซลล์ที่อธิบายในบทความ

**อะไรจะเกิดขึ้นกับภาพหากฉันเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งรูปเป็นพื้นหลังของเซลล์?**

พฤติกรรมขึ้นอยู่กับ [fill mode](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile) หากใช้การขยาย (stretch) ภาพจะปรับให้พอดีกับเซลล์ใหม่; หากใช้การเรียงต่อ (tile) แผ่นภาพจะถูกคำนวณใหม่ บทความกล่าวถึงโหมดการแสดงผลของภาพในเซลล์

**ฉันสามารถกำหนดลิงก์ไฮเปอร์ลิงก์ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**

[Hyperlinks](/slides/th/nodejs-java/manage-hyperlinks/) ถูกตั้งที่ระดับข้อความ (portion) ภายในกรอบข้อความของเซลล์หรือที่ระดับของตาราง/รูปร่างทั้งหมด ในทางปฏิบัติคุณจะกำหนดลิงก์ให้กับส่วนหนึ่งหรือกับข้อความทั้งหมดในเซลล์

**ฉันสามารถตั้งฟอนต์ต่าง ๆ ภายในเซลล์เดียวได้หรือไม่?**

ใช่. กรอบข้อความของเซลล์รองรับ [portions](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/portion/) (runs) ที่มีการจัดรูปแบบอิสระ ได้แก่ ชื่อฟอนต์, สไตล์, ขนาด, และสี