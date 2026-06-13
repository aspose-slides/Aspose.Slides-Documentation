---
title: ตาราง
type: docs
weight: 120
url: /th/nodejs-java/examples/elements/table/
keywords:
- ตัวอย่างโค้ด
- ตาราง
- PowerPoint
- OpenDocument
- การนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "ทำงานกับตารางใน Aspose.Slides for Node.js: สร้าง, จัดรูปแบบ, รวมเซลล์, ใช้สไตล์, นำเข้าข้อมูล และส่งออก พร้อมตัวอย่างสำหรับ PPT, PPTX, และ ODP."
---
ตัวอย่างการเพิ่มตาราง, การเข้าถึงตาราง, การลบตาราง และการรวมเซลล์โดยใช้ **Aspose.Slides for Node.js via Java**.

## **เพิ่มตาราง**

สร้างตารางง่าย ๆ ที่มีสองแถวและสองคอลัมน์

```js
function addTable() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let widths = java.newArray("double", [80, 80]);
        let heights = java.newArray("double", [30, 30]);
        let table = slide.getShapes().addTable(50, 50, widths, heights);

        presentation.save("table.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **เข้าถึงตาราง**

ดึงรูปร่างตารางแรกจากสไลด์

```js
function accessTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // เข้าถึงตารางแรกบนสไลด์.
        let firstTable = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
                firstTable = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ลบตาราง**

ลบตารางจากสไลด์

```js
function removeTable() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่ารูปร่างแรกเป็นตาราง.
        let table = slide.getShapes().get_Item(0);

        slide.getShapes().remove(table);

        presentation.save("table_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **รวมเซลล์ของตาราง**

รวมเซลล์ที่อยู่ติดกันของตารางเป็นเซลล์เดียว

```js
function mergeTableCells() {
    let presentation = new aspose.slides.Presentation("table.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // สมมติว่ารูปร่างแรกเป็นตาราง.
        let table = slide.getShapes().get_Item(0);

        // รวมเซลล์.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);

        presentation.save("cells_merged.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```