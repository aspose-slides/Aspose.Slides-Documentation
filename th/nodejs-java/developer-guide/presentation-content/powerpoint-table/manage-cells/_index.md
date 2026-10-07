---
title: จัดการเซลล์ตารางในงานนำเสนอด้วย JavaScript
linktitle: จัดการเซลล์
type: docs
weight: 30
url: /th/nodejs-java/manage-cells/
keywords:
- เซลล์ตาราง
- รวมเซลล์
- ลบเส้นขอบ
- แยกเซลล์
- รูปภาพในเซลล์
- สีพื้นหลัง
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการเซลล์ตาราง PowerPoint ด้วย JavaScript: ระบุเซลล์ที่รวมกัน, ลบเส้นขอบ, แยกเซลล์, และตั้งค่าสีพื้นหลังและรูปภาพด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java."
---
## **ภาพรวม**

Aspose.Slides ให้คุณเข้าถึงและแก้ไขเซลล์ของตารางในงานนำเสนอ PowerPoint บทความนี้อธิบายวิธีระบุเซลล์ตารางที่รวมกัน, ลบเส้นขอบของเซลล์, ทำงานกับการจัดหมายเลขเซลล์หลังจากการรวมหรือแยกเซลล์, เปลี่ยนสีพื้นหลังของเซลล์, และเพิ่มรูปภาพภายในเซลล์ตาราง ตัวอย่างแสดงวิธีสร้างหรือเปิดงานนำเสนอ, ดึงตารางจากสไลด์, อัปเดตการจัดรูปแบบเซลล์ผ่านคุณสมบัติของเซลล์, และบันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

Aspose.Slides ใช้ดัชนีเริ่มที่ศูนย์เพื่อเข้าถึงเซลล์ของตารางในลำดับ `(column, row)`

## **ระบุเซลล์ตารางที่รวมกัน**

ตัวอย่างเปิดงานนำเสนอที่มีอยู่และเข้าถึงรูปทรงแรกบนสไลด์แรกเป็นตาราง โดยสมมติว่าสไลด์และรูปทรงมีอยู่และรูปทรงเป็นตาราง จากนั้นวนลูปผ่านทุกแถวและคอลัมน์และใช้ [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) เพื่อระบุเซลล์ในเขตที่รวมกัน สำหรับแต่ละผลลัพธ์ จะพิมพ์พิกัดเซลล์ในลำดับ `row;column`, [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/), [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/), และพิกัดเริ่มต้นของเขต, [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) และ [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/)

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation_with_table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const rowCount = table.getRows().size();
    for (let rowIndex = 0; rowIndex < rowCount; rowIndex++) {
        const columnCount = table.getColumns().size();
        for (let columnIndex = 0; columnIndex < columnCount; columnIndex++) {
            const cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell()) {
                console.log("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **ลบเส้นขอบของเซลล์ตาราง**

สร้าง [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) และเพิ่มตารางไปยังสไลด์แรกด้วย [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addtable/). ความกว้างของคอลัมน์, ความสูงของแถว, และตำแหน่งของตารางถูกกำหนดเป็นหน่วยจุด ตัวอย่างตั้งค่าเส้นขอบของเซลล์ทั้งหมดสี่ด้านเป็น [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/), ทำให้มันไม่ปรากฏ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
        const row = table.getRows().get_Item(rowIndex);
        for (let columnIndex = 0; columnIndex < row.size(); columnIndex++) {
            const cell = row.get_Item(columnIndex);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }

    presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **รวมเซลล์ตาราง**

ใช้ [mergeCells](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/mergecells/) เพื่อรวมช่วงสี่เหลี่ยมของเซลล์ตารางให้เป็นเซลล์เดียว ระบุเซลล์ที่มุมซ้ายบนและมุมขวาล่างของช่วง อาร์กิวเมนต์สุดท้ายควบคุมว่าการรวมอาจรวมเซลล์นอกช่วงที่กำหนดหรือไม่; `false` ทำให้การรวมอยู่ภายในช่วงนั้น

ตัวอย่างสร้างตาราง 4x4 โดยมีคอลัมน์และแถวความกว้าง/ความสูง 70 จุด จากนั้นรวมเซลล์ศูนย์กลางสี่เซลล์จาก `(1, 1)` ถึง `(2, 2)` เซลล์ที่ได้จะครอบคลุมสองคอลัมน์และสองแถว ในขณะที่กริดพื้นฐานของตารางยังคงมีสี่คอลัมน์และสี่แถว เพื่อเข้าถึงเนื้อหาหรือการจัดรูปแบบของเซลล์ที่รวม ใช้ตำแหน่งมุมซ้ายบน: `table.get_Item(1, 1)` ในตัวอย่างนี้ ตำแหน่งอื่น ๆ ในช่วงที่รวมยังคงเป็นส่วนหนึ่งของกริดของตาราง ดังนั้นดัชนีของเซลล์ที่อยู่นอกช่วงจะไม่เปลี่ยนแปลง

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **แยกเซลล์ตาราง**

การรวมเซลล์ในตัวอย่างก่อนหน้ารักษากริดของตารางไว้ การแยกเซลล์อาจทำให้เกิดคอลัมน์กริดใหม่และเปลี่ยนดัชนีคอลัมน์ของเซลล์ทางด้านขวา Aspose.Slides ปฏิบัติตามโมเดลกริดของตาราง PowerPoint

ตัวอย่างนี้สร้างตาราง 4x4 โดยมีคอลัมน์และแถวความกว้าง/ความสูง 70 จุดและเรียกใช้ [splitByWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbywidth/) บนเซลล์ `(1, 1)` ครึ่งหนึ่งของความกว้าง 70 จุดของเซลล์จะถูกใช้เพื่อสร้างเซลล์สองเซลล์ที่มีความกว้างเท่ากัน

หลังจากการแยกนี้, ทั้งสองครึ่งจะถูกเข้าถึงเป็น `table.get_Item(1, 1)` และ `table.get_Item(2, 1)` ตารางกริดตอนนี้มีห้าคอลัมน์: เซลล์ที่อยู่เดิมในคอลัมน์ 2 และ 3 ย้ายไปยังคอลัมน์ 3 และ 4 ตามลำดับ ดัชนีแถวคงที่ ใช้ดัชนีคอลัมน์ที่อัปเดตนี้เมื่อเข้าถึงเซลล์หลังการแยก

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [70, 70, 70, 70]);
    const rowHeights = java.newArray("double", [70, 70, 70, 70]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **แยกเซลล์ที่รวมกันตามช่วงแถวหรือคอลัมน์**

เพื่อเตรียมเซลล์แม่แบบที่รวมไว้สำหรับการเติมข้อมูล, ใช้ [splitByRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbyrowspan/) เพื่อแยกตามเส้นขอบแถวที่มีอยู่, หรือ [splitByColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/splitbycolspan/) เพื่อแยกตามเส้นขอบคอลัมน์

อาร์กิวเมนต์ `index` นับจำนวนแถวในส่วนบนหรือคอลัมน์ในส่วนซ้ายของการแยก; มันเป็นค่าที่สัมพันธ์กับเขตที่รวม:

- การแยกแถว: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getrowspan/).
- การแยกคอลัมน์: `0 < index <` [getColSpan](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getcolspan/).

ตัวอย่างคาดว่างานนำเสนอจะมีตารางเป็นรูปทรงแรกบนสไลด์แรก, โดย `(1, 2)` และ `(1, 3)` รวมกันในแนวตั้ง โดยเริ่มจากตำแหน่งล่าง, ใช้ [getFirstColumnIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstcolumnindex/) และ [getFirstRowIndex](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/getfirstrowindex/) เพื่อตำแหน่งต้นกำเนิดและตรวจสอบทั้งสองช่วง `splitByRowSpan(1)` จะแยกแถวที่ 2 และ 3 สำหรับชื่อสินค้า สำหรับการรวมสองคอลัมน์แนวนอน ให้ใช้ `splitByColSpan(1)` แทน

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("table_template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);

    const selectedCell = table.get_Item(1, 3);
    const firstColumnIndex = selectedCell.getFirstColumnIndex();
    const firstRowIndex = selectedCell.getFirstRowIndex();
    const mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1) {
        mergedCell.splitByRowSpan(1);

        // ดึงเซลล์ผลลัพธ์จากตารางหลังจากการแยก.
        const upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        const lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        console.log("Upper cell merged: " + upperCell.isMergedCell());
        console.log("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

กริดของตารางและดัชนีเซลล์โดยรอบคงที่ ดึงเซลล์ผลลัพธ์ตามพิกัดของมัน; ที่นี่ทั้งสองมีช่วงเป็น 1 และ [isMergedCell](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/ismergedcell/) พิมพ์ `false` เขตที่ใหญ่กว่าสามารถยังคงรวมกันบางส่วนหลังจากการแยกหนึ่งครั้ง

ข้อความต้นฉบับและการจัดรูปแบบของมันคงอยู่ในเซลล์บน (หรือซ้าย); เซลล์ใหม่จะว่างเปล่าแต่สืบมาจากการจัดรูปแบบของเซลล์เช่นการเติม, เส้นขอบ, และระยะขอบ เติมข้อมูลลงในเซลล์หลังจากการแยกและตั้งค่าการจัดรูปแบบข้อความที่ต้องการอย่างชัดเจน

งานนำเสนอที่บันทึกไว้มีเซลล์ \"Product A\" และ \"Product B\" แยกกันโดยคงการจัดรูปแบบของเซลล์แม่แบบไว้ ดู [Cell API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/) สำหรับรายละเอียด

## **เปลี่ยนสีพื้นหลังของเซลล์ตาราง**

ตัวอย่างนี้สร้างตารางที่มีคอลัมน์ 150 จุดและแถว 50 จุด ใช้ [setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) เพื่อเลือกการเติมแบบทึบและตั้งค่าสีที่คืนค่าจาก [getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/getsolidfillcolor/) เป็นสีแดงสำหรับเซลล์ `(2, 3)`, ในคอลัมน์ที่สามและแถวที่สี่

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [50, 50, 50, 50, 50]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    const cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **เพิ่มรูปภาพภายในเซลล์ตาราง**

วางรูปภาพต้นฉบับในไดเรกทอรีทำงานก่อนรันตัวอย่างนี้ มันโหลดรูปภาพด้วย [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Images#fromFile) และเพิ่มลงในคอลเลกชันรูปภาพของงานนำเสนอด้วย [addImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagecollection/addimage/). จากนั้นกำหนดรูปภาพให้กับการเติมรูปภาพของเซลล์ `(0, 0)`, เซลล์แรกในตาราง

[PictureFillMode.Stretch](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) ยืดรูปภาพให้เติมเต็มเซลล์, ซึ่งอาจเปลี่ยนอัตราส่วนภาพ ความกว้างของคอลัมน์และความสูงของแถวเป็นหน่วยจุด รูปภาพที่โหลดจะถูกทำลายในบล็อก `finally` หลังจากเพิ่มลงในงานนำเสนอ

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [150, 150, 150, 150]);
    const rowHeights = java.newArray("double", [100, 100, 100, 100, 90]);
    const table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    let ppImage;
    const image = aspose.slides.Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งความหนาและสไตล์ของเส้นที่แตกต่างกันสำหรับแต่ละด้านของเซลล์เดียวได้หรือไม่?**

ใช่. ด้าน [top](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cellformat/getborderright/) มีคุณสมบัติเกี่ยวกับแต่ละด้านแยกกัน ดังนั้นความหนาและสไตล์ของแต่ละด้านสามารถแตกต่างกันได้

**เกิดอะไรขึ้นกับรูปภาพหากฉันเปลี่ยนขนาดคอลัมน์/แถวหลังจากตั้งรูปเป็นพื้นหลังของเซลล์?**

พฤติกรรมขึ้นอยู่กับ [fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). หากยืด, รูปภาพจะปรับให้เข้ากับเซลล์ใหม่; หากเป็นการทำแผ่นกระเบื้อง, แผ่นกระเบื้องจะถูกคำนวณใหม่

**ฉันสามารถกำหนดลิงก์ไฮเพอร์ลิงก์ให้กับเนื้อหาทั้งหมดของเซลล์ได้หรือไม่?**

[Hyperlinks](/slides/th/nodejs-java/manage-hyperlinks/) ถูกตั้งค่าที่ระดับข้อความ (portion) ภายในกรอบข้อความของเซลล์หรือที่ระดับของตาราง/รูปทรงทั้งหมด ในทางปฏิบัติคุณสามารถกำหนดลิงก์ให้กับส่วนหนึ่งหรือให้กับข้อความทั้งหมดในเซลล์ได้

**ฉันสามารถตั้งฟอนต์ที่แตกต่างกันภายในเซลล์เดียวได้หรือไม่?**

ใช่. กรอบข้อความของเซลล์รองรับ [portions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) (runs) ที่มีการจัดรูปแบบอิสระ—ครอบครัวฟอนต์, สไตล์, ขนาด, และสี