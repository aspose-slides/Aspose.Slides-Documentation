---
title: จัดการแถวและคอลัมน์ในตาราง PowerPoint ด้วย JavaScript
linktitle: แถวและคอลัมน์
type: docs
weight: 20
url: /th/nodejs-java/manage-rows-and-columns/
keywords:
- แถวตาราง
- คอลัมน์ตาราง
- แถวแรก
- หัวตาราง
- ทำซ้ำแถว
- ทำซ้ำคอลัมน์
- คัดลอกแถว
- คัดลอกคอลัมน์
- ลบแถว
- ลบคอลัมน์
- การจัดรูปแบบข้อความของแถว
- การจัดรูปแบบข้อความของคอลัมน์
- สไตล์ตาราง
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการแถวและคอลัมน์ของตารางใน PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อเร่งการแก้ไขงานนำเสนอและการอัปเดตข้อมูล."
---
## **บทนำ**

Aspose.Slides for Node.js via Java ให้คุณจัดการโครงสร้างและการจัดรูปแบบของตารางในงานนำเสนอ PowerPoint ผ่านคลาส [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) คุณสามารถกำหนดแถวหัวเรื่อง คัดลอกหรือเอาแถวและคอลัมน์ออก และใช้การจัดรูปแบบข้อความกับแถวหรือคอลัมน์ทั้งหมดได้

บทความนี้อธิบายการดำเนินการเหล่านี้ด้วยตัวอย่าง JavaScript อีกทั้งยังแสดงวิธีดึงสไตล์พรีเซ็ตของตารางเพื่อใช้ซ้ำ ดัชนีของแถวและคอลัมน์เริ่มต้นที่ศูนย์

## **ควบคุมความสูงของแถว**

ใช้ [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight-double-) เพื่อกำหนดความสูงขั้นต่ำของแถวเป็นจุด จำนวนนี้เป็นขอบล่าง ไม่ใช่ความสูงคงที่ [Row.getHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#getHeight--) คืนค่าความสูงจริง เข้าถึงแถวผ่าน [Table.getRows](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getRows--)

ตัวอย่างโหลดไฟล์ [row-height-input.pptx](row-height-input.pptx) ซึ่งมีตารางเป็นรูปร่างแรกบนสไลด์แรก แถวแรกเริ่มที่ 70 จุด เซลล์ใช้ข้อความ Arial ขนาด 18 จุด มีการตัดบรรทัดและระยะขอบบนและล่าง 6 จุด; ข้อความยาวในคอลัมน์ที่สองตัดบรรทัดหลายบรรทัด ตัวอย่างเพิ่มค่าขั้นต่ำเป็น 100 จุด แล้วลดลงเหลือ 20 จุด พิมพ์ความสูงจริงหลังแต่ละการเปลี่ยนแปลงและบันทึกผลลัพธ์ทั้งสอง

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("row-height-input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    const row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    console.log("Increased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-increased.pptx", slides.SaveFormat.Pptx);

    row.setMinimalHeight(20);
    console.log("Decreased: minimum = " + row.getMinimalHeight().toFixed(1) + ", actual = " + row.getHeight().toFixed(1) + " pt");
    presentation.save("row-height-decreased.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ด้วยงานนำเสนอที่ให้มา การเพิ่มค่าขั้นต่ำจะเพิ่มพื้นที่ให้กับแถว การลดค่าขั้นต่ำจะลบพื้นที่พิเศษนั้นออก แต่ความสูงจริงยังคงมากกว่า 20 จุด เพราะข้อความและระยะขอบของเซลล์ต้องการพื้นที่เพิ่ม การลดค่าขั้นต่ำเพียงอย่างเดียวไม่สามารถบังคับให้แถวต่ำกว่าพื้นที่ที่เนื้อหาต้องการได้

หลายปัจจัยส่งผลต่อความสูงจริง:

- **ข้อความและขนาดฟอนต์:** ข้อความยาวขึ้น การขึ้นบรรทัดใหม่โดยตรง หรือฟอนต์ใหญ่ขึ้นอาจต้องการพื้นที่แนวตั้งเพิ่ม
- **การตัดบรรทัดและความกว้างคอลัมน์:** เมื่อเปิดการตัดบรรทัด การลดความกว้างคอลัมน์ด้วย [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth-double-) จะทำให้เกิดบรรทัดเพิ่มขึ้น คอลัมน์กว้างขึ้นสามารถลดพื้นที่ที่ต้องการในแนวตั้งได้
- **ระยะขอบของเซลล์:** [Cell.setMarginTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginTop-double-) และ [Cell.setMarginBottom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginBottom-double-) เพิ่มพื้นที่แนวตั้ง [Cell.setMarginLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginLeft-double-) และ [Cell.setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#setMarginRight-double-) ลดความกว้างที่ใช้สำหรับข้อความและอาจทำให้ตัดบรรทัดเพิ่มขึ้น

สำหรับตารางนี้ที่ไม่มีการรวมเซลล์ เซลล์ที่ต้องการพื้นที่แนวตั้งมากที่สุดจะกำหนดขอบล่างที่กำหนดโดยเนื้อหาเพื่อทั้งแถว หากต้องการให้แถวสั้นลง คุณอาจต้องย่อข้อความ ลดขนาดฟอนต์หรือระยะขอบ หรือเพิ่มความกว้างของคอลัมน์

ภาพด้านล่างแสดงตารางเดียวกันในสเกลเดียวกัน ในผลลัพธ์ที่แสดง ความสูงจริงคือ 70, 100 และ 55.2 จุด: แถวสุดท้ายยังคงสูงกว่าขั้นต่ำ 20 จุด การวัดข้อความที่แม่นยำอาจแตกต่างตามฟอนต์ที่มีในสภาพแวดล้อมของคุณ ดาวน์โหลดผลลัพธ์ที่บันทึกไว้: [เพิ่มขั้นต่ำ](row-height-increased.pptx) และ [ลดขั้นต่ำ](row-height-decreased.pptx)

| ต้นฉบับ: ขั้นต่ำ 70 pt, ความจริง 70 pt | เพิ่ม: ขั้นต่ำ 100 pt, ความจริง 100 pt | ลด: ขั้นต่ำ 20 pt, ความจริง 55.2 pt |
| --- | --- | --- |
| ![รูปตารางต้นฉบับที่มีแถวแรก 70 จุด.](row-height-before.png) | ![รูปตารางหลังจากเพิ่มขั้นต่ำของแถวแรกเป็น 100 จุด.](row-height-increased.png) | ![รูปตารางหลังจากลดขั้นต่ำของแถวแรกเป็น 20 จุด; ข้อความที่ตัดบรรทัดทำให้แถวสูงกว่าขั้นต่ำ.](row-height-decreased.png) |

## **ตั้งค่าแถวแรกเป็นหัวเรื่อง**

ใช้เมธอด [setFirstRow](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#setFirstRow-boolean-) เพื่อทำเครื่องหมายแถวแรกสำหรับการจัดรูปแบบหัวเรื่อง การแสดงผลขึ้นอยู่กับสไตล์ตารางที่ใช้กับตารางนั้น

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)  
2. เข้าถึงสไลด์แรก  
3. เข้าถึงตารางที่เก็บเป็นรูปร่างแรกบนสไลด์  
4. เปิดการจัดรูปแบบหัวเรื่องสำหรับแถวแรก  
5. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่างต้องการไฟล์ `table.pptx` ที่มีตารางเป็นรูปร่างแรกบนสไลด์แรก เปิดการจัดรูปแบบหัวเรื่องสำหรับแถวแรกและบันทึกเป็น `First_row_header.pptx`

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คัดลอกแถวหรือคอลัมน์ของตาราง**

คัดลอกแถวหรือคอลัมน์เพื่อใช้เนื้อหาและการจัดรูปแบบซ้ำ คุณสามารถต่อท้ายสำเนาที่ส่วนท้ายของตารางหรือแทรกที่ตำแหน่งเฉพาะ

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)  
2. เข้าถึงสไลด์แรก  
3. กำหนดความกว้างของคอลัมน์และความสูงของแถว  
4. เพิ่มตารางด้วยเมธอด [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---)  
5. คัดลอกแถวที่ต้องการ  
6. คัดลอกคอลัมน์ที่ต้องการ  
7. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่างต้องการไฟล์ `Test.pptx` อย่างน้อยหนึ่งสไลด์ จะสร้างตารางที่มีสามคอลัมน์และห้าแถวโดยกำหนดขนาดเป็นจุด คัดลอกแถวและคอลัมน์แรกแล้วแทรกสำเนาแถวและคอลัมน์ที่สองที่ตำแหน่ง 3 (ตำแหน่งที่สี่) ตารางที่ได้จะมีเจ็ดแถวและห้าคอลัมน์ อาร์กิวเมนต์ `false` ปิดการคัดลอกไปยังแถวหรือคอลัมน์ที่รวมอยู่ใกล้เคียง; ตารางนี้ไม่มีเซลล์ที่รวมกัน

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("Test.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [50, 50, 50]);
    const rowHeights = java.newArray("double", [50, 30, 30, 30, 30]);
    const table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ลบแถวหรือคอลัมน์จากตาราง**

ลบแถวหรือคอลัมน์ที่ไม่ต้องการอีกต่อไปในตาราง การลบรายการหนึ่งจะทำให้ดัชนีของแถวหรือคอลัมน์ที่ตามมาถูกเลื่อนตำแหน่ง

1. สร้างงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)  
2. เข้าถึงสไลด์แรก  
3. กำหนดความกว้างของคอลัมน์และความสูงของแถว  
4. เพิ่มตารางด้วยเมธอด [addTable](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---)  
5. ลบแถวที่สองและคอลัมน์ที่สอง  
6. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่างนี้สร้างตาราง 3x3 แล้วลบแถวและคอลัมน์ที่ตำแหน่ง 1 ทำให้เหลือตาราง 2x2 ในไฟล์ `TestTable_out.pptx` ขนาดเป็นจุด อาร์กิวเมนต์ `false` ปิดการลบแถวหรือคอลัมน์ที่รวมอยู่ใกล้เคียง; ตารางนี้ไม่มีเซลล์ที่รวมกัน

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 50, 30]);
    const rowHeights = java.newArray("double", [30, 50, 30]);
    const table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าการจัดรูปแบบข้อความบนระดับแถวของตาราง**

ใช้การจัดรูปแบบข้อความกับแถวทั้งหมดเพื่อให้เซลล์มีลักษณะสอดคล้องกัน คุณสามารถกำหนดคุณสมบัติของฟอนต์ การจัดรูปแบบย่อหน้า และทิศทางข้อความโดยไม่ต้องจัดรูปแบบแต่ละเซลล์แยกกัน

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)  
2. เข้าถึงตารางบนสไลด์แรก  
3. ใช้เมธอด [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) สำหรับแถวแรก  
4. ใช้เมธอด [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) และ [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) สำหรับแถวแรก  
5. ใช้เมธอด [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) สำหรับแถวที่สอง  
6. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่างต้องการไฟล์ `table.pptx` ที่มีตารางเป็นรูปร่างแรกบนสไลด์แรกและต้องมีอย่างน้อยสองแถว จะใช้ข้อความขนาด 25 จุด การจัดชิดขวา และระยะขอบย่อหน้าขวา 20 จุดกับแถวแรก แล้วตั้งค่าข้อความแนวตั้งในแถวที่สอง

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ตั้งค่าการจัดรูปแบบข้อความบนระดับคอลัมน์ของตาราง**

ใช้การจัดรูปแบบข้อความกับคอลัมน์ทั้งหมดเพื่อให้เซลล์มีลักษณะสอดคล้องกัน คุณสามารถกำหนดคุณสมบัติของฟอนต์ การจัดรูปแบบย่อหน้า และทิศทางข้อความโดยไม่ต้องจัดรูปแบบแต่ละเซลล์แยกกัน

1. โหลดงานนำเสนอด้วยคลาส [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/)  
2. เข้าถึงตารางบนสไลด์แรก  
3. ใช้เมธอด [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) สำหรับคอลัมน์แรก  
4. ใช้เมธอด [setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) และ [setMarginRight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) สำหรับคอลัมน์แรก  
5. ใช้เมธอด [setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) สำหรับคอลัมน์ที่สอง  
6. บันทึกงานนำเสนอที่แก้ไขแล้ว  

ตัวอย่างต้องการไฟล์ `table.pptx` ที่มีตารางเป็นรูปร่างแรกบนสไลด์แรกและต้องมีอย่างน้อยสองคอลัมน์ จะใช้ข้อความขนาด 25 จุด การจัดชิดขวา และระยะขอบย่อหน้าขวา 20 จุดกับคอลัมน์แรก แล้วตั้งค่าข้อความแนวตั้งในคอลัมน์ที่สอง

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("table.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const table = slide.getShapes().get_Item(0);

    const portionFormat = new slides.PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    const paragraphFormat = new slides.ParagraphFormat();
    paragraphFormat.setAlignment(slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    const textFrameFormat = new slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(java.newByte(slides.TextVerticalType.Vertical));
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **รับคุณสมบัติสไตล์ของตาราง**

ใช้เมธอด [getStylePreset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/#getStylePreset--) เพื่อดึงพรีเซ็ตที่ใช้กับตารางและนำมาใช้ซ้ำกับตารางอื่น วิธีนี้ระบุพรีเซ็ตแทนการแทนที่การฟอร์แมตของเซลล์แต่ละเซลล์

ตัวอย่างสร้างตาราง ใช้ [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tablestylepreset/#DarkStyle1) แล้วอ่านพรีเซ็ตกลับมา พิมพ์ค่าจำนวนเต็มที่สอดคล้องกับ `DarkStyle1` และบันทึกตารางเป็น `table.pptx`

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const columnWidths = java.newArray("double", [100, 150]);
    const rowHeights = java.newArray("double", [5, 5, 5]);
    const table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(slides.TableStylePreset.DarkStyle1);

    const stylePreset = table.getStylePreset();
    console.log(stylePreset);

    presentation.save("table.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **คำถามที่พบบ่อย**

**ฉันสามารถนำธีมหรือสไตล์ของ PowerPoint ไปใช้กับตารางที่สร้างแล้วได้หรือไม่?**

ได้ ตารางสืบทอดธีมของสไลด์/เลเอาท์/มาสเตอร์ และคุณยังสามารถลบการเติมสี เส้นขอบ และสีข้อความได้เหนือธีมนั้น

**ฉันสามารถเรียงลำดับแถวของตารางแบบ Excel ได้หรือไม่?**

ไม่ได้ ตารางของ Aspose.Slides ไม่มีฟีเจอร์เรียงลำดับหรือฟิลเตอร์ในตัว คุณต้องจัดเรียงข้อมูลในหน่วยความจำก่อนแล้วค่อยใส่แถวตารางใหม่ตามลำดับนั้น

**ฉันต้องการคอลัมน์แบบมีแถบสีสลับพร้อมยังคงใช้สีที่กำหนดเองในเซลล์บางเซลล์ได้หรือไม่?**

ได้ เปิดคอลัมน์แบบมีแถบสีสลับ แล้วลบสีในเซลล์เฉพาะด้วยการฟอร์แมตระดับเซลล์; การฟอร์แมตระดับเซลล์จะมี 우선순위เหนือสไตล์ของตาราง**