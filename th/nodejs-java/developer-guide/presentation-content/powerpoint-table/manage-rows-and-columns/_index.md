---
title: จัดการแถวและคอลัมน์ในตาราง PowerPoint ด้วย JavaScript
linktitle: แถวและคอลัมน์
type: docs
weight: 20
url: /th/nodejs-java/manage-rows-and-columns/
keywords:
- แถวของตาราง
- คอลัมน์ของตาราง
- แถวแรก
- หัวตาราง
- คัดลอกแถว
- คัดลอกคอลัมน์
- คัดลอกแถว
- คัดลอกคอลัมน์
- ลบแถว
- ลบคอลัมน์
- การจัดรูปแบบข้อความแถว
- การจัดรูปแบบข้อความคอลัมน์
- สไตล์ตาราง
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "จัดการแถวและคอลัมน์ของตารางใน PowerPoint ด้วย JavaScript และ Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อเพิ่มความเร็วในการแก้ไขงานนำเสนอและอัปเดตข้อมูล"
---
## **บทนำ**

เพื่อให้คุณสามารถจัดการแถวและคอลัมน์ของตารางในงานนำเสนอ PowerPoint, Aspose.Slides มีคลาส [Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/table/) และประเภทอื่น ๆ

## **ตั้งค่าแถวแรกเป็นส่วนหัว**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) และโหลดงานนำเสนอ
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน
3. สร้างอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) และกำหนดค่าเป็น null
4. วนลูปผ่านอ็อบเจกต์ [Shape](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shape/) ทั้งหมดเพื่อค้นหาตารางที่เกี่ยวข้อง
5. ตั้งค่าแถวแรกของตารางเป็นส่วนหัวของมัน

โค้ด JavaScript นี้แสดงวิธีตั้งค่าแถวแรกของตารางเป็นส่วนหัว:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation("table.pptx");
try {
    // เข้าถึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // กำหนดค่าเริ่มต้นให้กับ TableEx ที่เป็น null
    var tbl = null;
    // วนลูปผ่านรูปร่างทั้งหมดและตั้งค่าอ้างอิงไปยังตาราง
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (java.instanceOf(shp, "com.aspose.slides.ITable")) {
            tbl = shp;
            // ตั้งค่าแถวแรกของตารางเป็นส่วนหัว
            tbl.setFirstRow(true);
        }
    }
    // บันทึกงานนำเสนอไปยังดิสก์
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **คัดลอกแถวหรือคอลัมน์ของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) และโหลดงานนำเสนอ,
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน
3. กำหนดอาร์เรย์ของ `columnWidth`
4. กำหนดอาร์เรย์ของ `rowHeight`
5. เพิ่มอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) ไปยังสไลด์โดยใช้เมธอด [addTable](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---)
6. คัดลอกแถวของตาราง
7. คัดลอกคอลัมน์ของตาราง
8. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด JavaScript นี้แสดงวิธีคัดลอกแถวหรือคอลัมน์ของตาราง PowerPoint:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation("Test.pptx");
try {
    // เข้าถึงสไลด์แรก
    var sld = pres.getSlides().get_Item(0);
    // กำหนดคอลัมน์ด้วยความกว้างและแถวด้วยความสูง
    var dblCols = java.newArray("double", [50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // เพิ่มรูปร่างตารางลงในสไลด์
    var table = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // เพิ่มข้อความบางส่วนลงในแถว 1 เซลล์ 1
    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    // เพิ่มข้อความบางส่วนลงในแถว 1 เซลล์ 2
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    // ทำการคัดลอกแถว 1 ไปยังส่วนท้ายของตาราง
    table.getRows().addClone(table.getRows().get_Item(0), false);
    // เพิ่มข้อความบางส่วนลงในแถว 2 เซลล์ 1
    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    // เพิ่มข้อความบางส่วนลงในแถว 2 เซลล์ 2
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    // คัดลอกแถว 2 เป็นแถวที่ 4 ของตาราง
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);
    // คัดลอกคอลัมน์แรกไปยังส่วนท้าย
    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    // คัดลอกคอลัมน์ที่ 2 ไปยังตำแหน่งคอลัมน์ที่ 4
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);
    // บันทึกงานนำเสนอไปยังดิสก์
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ลบแถวหรือคอลัมน์จากตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) และโหลดงานนำเสนอ,
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน
3. กำหนดอาร์เรย์ของ `columnWidth`
4. กำหนดอาร์เรย์ของ `rowHeight`
5. เพิ่มอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) ไปยังสไลด์โดยใช้เมธอด [addTable](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/shapecollection/#addTable-float-float-double---double---)
6. ลบแถวของตาราง
7. ลบคอลัมน์ของตาราง
8. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด JavaScript นี้แสดงวิธีลบแถวหรือคอลัมน์จากตาราง:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var colWidth = java.newArray("double", [100, 50, 30]);
    var rowHeight = java.newArray("double", [30, 50, 30]);
    var table = slide.getShapes().addTable(100, 100, colWidth, rowHeight);
    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);
    pres.save("TestTable_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งค่าการจัดรูปแบบข้อความในระดับแถวของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) และโหลดงานนำเสนอ,
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน
3. เข้าถึงอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) ที่เกี่ยวข้องจากสไลด์
4. ตั้งค่า [setFontHeight(float value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) ของเซลล์ในแถวแรก
5. ตั้งค่า [setAlignment(int value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) และ [setMarginRight(float value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) ของเซลล์ในแถวแรก
6. ตั้งค่า [setTextVerticalType(byte value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) ของเซลล์ในแถวที่สอง
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด JavaScript นี้แสดงการดำเนินการ

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    // สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // ตั้งความสูงฟอนต์ของเซลล์ในแถวแรก
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getRows().get_Item(0).setTextFormat(portionFormat);
    // ตั้งการจัดแนวข้อความและระยะขอบขวาของเซลล์ในแถวแรก
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getRows().get_Item(0).setTextFormat(paragraphFormat);
    // ตั้งประเภทการวางแนวข้อความแนวตั้งของเซลล์ในแถวที่สอง
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getRows().get_Item(1).setTextFormat(textFrameFormat);
    // บันทึกงานนำเสนอไปยังดิสก์
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ตั้งค่าการจัดรูปแบบข้อความในระดับคอลัมน์ของตาราง**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/presentation/) และโหลดงานนำเสนอ,
2. ดึงอ้างอิงสไลด์ผ่านดัชนีของมัน
3. เข้าถึงอ็อบเจกต์ [Table](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/Table) ที่เกี่ยวข้องจากสไลด์
4. ตั้งค่า [setFontHeight(float value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/baseportionformat/#setFontHeight-float-) ของเซลล์ในคอลัมน์แรก
5. ตั้งค่า [setAlignment(int value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) และ [setMarginRight(float value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/paragraphformat/#setMarginRight-float-) ของเซลล์ในคอลัมน์แรก
6. ตั้งค่า [setTextVerticalType(byte value)](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) ของเซลล์ในคอลัมน์ที่สอง
7. บันทึกงานนำเสนอที่แก้ไขแล้ว

โค้ด JavaScript นี้แสดงการดำเนินการ:

```javascript
// สร้างอินสแตนซ์ของคลาส Presentation
var pres = new aspose.slides.Presentation();
try {
    // สมมติว่ารูปร่างแรกบนสไลด์แรกเป็นตาราง
    var someTable = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    // ตั้งความสูงฟอนต์ของเซลล์ในคอลัมน์แรก
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(25);
    someTable.getColumns().get_Item(0).setTextFormat(portionFormat);
    // ตั้งการจัดแนวข้อความและระยะขอบขวาของเซลล์ในคอลัมน์แรกในคำสั่งเดียว
    var paragraphFormat = new aspose.slides.ParagraphFormat();
    paragraphFormat.setAlignment(aspose.slides.TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    someTable.getColumns().get_Item(0).setTextFormat(paragraphFormat);
    // ตั้งประเภทการวางแนวข้อความแนวตั้งของเซลล์ในคอลัมน์ที่สอง
    var textFrameFormat = new aspose.slides.TextFrameFormat();
    textFrameFormat.setTextVerticalType(aspose.slides.TextVerticalType.Vertical);
    someTable.getColumns().get_Item(1).setTextFormat(textFrameFormat);
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **รับคุณสมบัติรูปแบบของตาราง**

Aspose.Slides ให้คุณดึงคุณสมบัติรูปแบบของตารางเพื่อที่คุณจะได้ใช้รายละเอียดเหล่านั้นกับตารางอื่นหรือที่อื่น โค้ด JavaScript นี้แสดงวิธีดึงคุณสมบัติรูปแบบจากสไตล์ตารางที่กำหนดไว้ล่วงหน้า:

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

## **FAQ**

**Can I apply PowerPoint themes/styles to a table that’s already created?**

ได้ ตารางสืบทอดธีมของสไลด์/เลย์เอาต์/มาสเตอร์ และคุณยังสามารถเขียนทับสีเติม, ขอบ, และสีข้อความเหนือธีมนั้นได้

**Can I sort table rows like in Excel?**

ไม่ได้ ตารางของ Aspose.Slides ไม่มีการจัดเรียงหรือการกรองในตัว จัดเรียงข้อมูลของคุณในหน่วยความจำก่อน แล้วจึงเติมแถวของตารางใหม่ตามลำดับนั้น

**Can I have banded (striped) columns while keeping custom colors on specific cells?**

ได้ เปิดคอลัมน์แบบเป็นแถบ แล้วเขียนทับเซลล์เฉพาะด้วยการจัดรูปแบบท้องถิ่น; การจัดรูปแบบในระดับเซลล์จะมีอำนาจเหนือสไตล์ของตาราง