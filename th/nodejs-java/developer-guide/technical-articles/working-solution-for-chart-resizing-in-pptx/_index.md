---
title: วิธีแก้ปัญหาการปรับขนาดแผนภูมิใน PPTX
type: docs
weight: 40
url: /th/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- การปรับขนาดแผนภูมิ
- แผนภูมิ Excel
- วัตถุ OLE
- ฝังแผนภูมิ
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "แก้ไขการปรับขนาดแผนภูมิที่ไม่คาดคิดใน PPTX เมื่อใช้วัตถุ Excel OLE ที่ฝังไว้กับ Aspose.Slides สำหรับ Node.js ผ่าน Java ตั้งค่าขนาดแผนภูมิคงที่เพื่อให้ขนาดของแผนภูมิและกรอบ OLE สอดคล้องกัน"
---
## **ภาพรวม**

แผนภูมิ Excel ที่ฝังเป็นวัตถุ OLE ในงานนำเสนอ PowerPoint ด้วยส่วนประกอบของ Aspose สามารถเปลี่ยนขนาดได้หลังจากการเปิดใช้งานครั้งแรก สิ่งนี้สามารถทำให้เกิดความแตกต่างที่สังเกตได้ในการแสดงผลของแผนภูมิก่อนและหลังการเปิดใช้งาน บทความนี้อธิบายเหตุผลที่เกิดการปรับขนาดและแสดงวิธีป้องกันโดยการจับคู่ขนาดแผนภูมิที่กำหนดกับกรอบ OLE.

ใน [สร้างแผนภูมิ Excel และฝังเป็นวัตถุ OLE ในงานนำเสนอ](/slides/th/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/), เราได้อธิบายวิธีสร้างแผนภูมิ Excel ด้วย Aspose.Cells สำหรับ Node.js ผ่าน Java และฝังลงในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java เพื่อแก้ไข [ปัญหาการพรีวิววัตถุ](/slides/th/nodejs-java/object-preview-issue-when-adding-oleobjectframe/), เราได้กำหนดภาพแผนภูมิให้กับกรอบวัตถุ OLE ของแผนภูมิ ในงานนำเสนอผลลัพธ์ เมื่อคุณคลิกดับเบิลบนกรอบวัตถุ OLE ที่แสดงภาพแผนภูมิ แผนภูมิ Excel จะถูกเปิดใช้งาน ผู้ใช้สามารถแก้ไขสมุดงาน Excel ที่ฝังอยู่แล้วกลับไปยังสไลด์โดยคลิกนอกสมุดงานที่เปิดใช้งาน ขนาดของกรอบวัตถุ OLE จะเปลี่ยนเมื่อผู้ใช้กลับไปยังสไลด์และปัจจัยการปรับขนาดจะแตกต่างกันขึ้นอยู่กับขนาดเดิมของกรอบวัตถุ OLE และสมุดงาน Excel ที่ฝังอยู่

## **สาเหตุของการปรับขนาด**

สมุดงาน Excel ที่ฝังอยู่มีขนาดหน้าต่างของตนเอง ซึ่ง Excel พยายามรักษาไว้เมื่อวัตถุถูกเปิดใช้งานครั้งแรก กรอบ OLE บนสไลด์มีขนาดที่กำหนดโดยอิสระ เมื่อสมุดงาน Excel ถูกเปิดใช้งาน Excel และ PowerPoint จะเจรจากันเกี่ยวกับขนาดของวัตถิเพื่อรักษาสัดส่วนของมันเป็นส่วนหนึ่งของกระบวนการฝัง ความแตกต่างระหว่างหน้าต่างสมุดงานและกรอบ OLE จึงอาจทำให้วัตถุปรับขนาดได้

## **วิธีแก้ปัญหาที่ใช้งานได้**

จับคู่ขนาดของแผนภูมิให้ตรงกับกรอบ OLE บนสไลด์และให้ขนาดของแผนภูมิเสรีจากหน้าต่างสมุดงาน วิธีแก้ปัญหานี้ใช้งานได้กับงานนำเสนอใหม่หรือแม่แบบที่มีอยู่

ตัวอย่างนี้ต้องการ Aspose.Cells สำหรับ Node.js ผ่าน Java และ Aspose.Slides สำหรับ Node.js ผ่าน Java ติดตั้งแพคเกจ Node.js `aspose.cells`, `aspose.slides.via.java` และ `java` รันสคริปต์ CommonJS สองไฟล์ด้านล่างในกระบวนการ Node.js แยกกันโดยใช้ไดเรกทอรีทำงานเดียวกัน เนื่องจากแพคเกจ Aspose ทั้งสองจะเริ่มต้นการเชื่อมต่อ Java ระหว่างการโหลด มันสร้างแผนภูมิโดยใช้คอลัมน์ง่าย ๆ บนแผ่นแผนภูมิที่ใช้งานอยู่และฝังสมุดงานในรูปแบบ XLS ไม่ได้กำหนดภาพพรีวิวของแผนภูมิ; แผนภูมิจะปรากฏเมื่อวัตถุ OLE ถูกเปิดใช้งานใน PowerPoint

ตัวอย่างนี้สร้างงานนำเสนอใหม่ที่มีกรอบ OLE ขนาด 9.5 × 4 นิ้ว ตั้งตำแหน่งห่างจากขอบซ้าย 0.5 นิ้วและจากด้านบน 1 นิ้ว พิกัดและขนาดของสไลด์ใช้หน่วยจุด (72 จุดต่อหนึ่งนิ้ว) สำหรับงานนำเสนอที่มีอยู่แล้ว ดูที่ [ใช้แม่แบบ](#use-a-template).

## **ตั้งค่าขนาดแผนภูมิคงที่**

ตั้งค่า [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) เป็น false เพื่อให้ขนาดของแผนภูมิเป็นอิสระจากหน้าต่างสมุดงาน ตั้งค่า dimensions ของ [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject) ผ่าน [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) และ [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight), แปลงหน่วยจากจุดเป็นพิกเซลโดยใช้ 96 พิกเซลต่อหนึ่งนิ้ว: กรอบที่มีขนาด 684 × 288 จุดสอดคล้องกับแผนภูมิที่มีขนาด 912 × 384 พิกเซล ตั้งค่า [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) เป็นค่า CUSTOM ของ `PrintSizeType` ตัวอย่างฝังสมุดงานด้วย [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) และบันทึกงานนำเสนอที่มีกรอบ OLE ขนาด 9.5 × 4 นิ้ว

บันทึกสคริปต์แรกนี้เป็น `create-fixed-chart.js`. สคริปต์นี้จะสร้าง `chart-fixed-size.xls` ที่มีแผนภูมิขนาด 912 × 384 พิกเซล ซึ่งตรงกับกรอบขนาด 684 × 288 จุดที่ใช้โดยสคริปต์ที่สอง ไม่ต้องการสมุดงานอินพุต

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // จับคู่ขนาดกรอบ OLE ในหน่วยจุด (72 จุดต่อหนึ่งนิ้ว).
    const width = 684; // 9.5 นิ้ว.
    const height = 288; // 4 นิ้ว.

    chart.setSizeWithWindow(false);
    // แปลงหน่วยจุดเป็นพิกเซลของแผนภูมิโดยใช้ 96 พิกเซลต่อหนึ่งนิ้ว.
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// งานแบบซิงโครนัสทั้งหมดเสร็จสิ้น; หยุดกระบวนการเชื่อมต่อ Java.
process.exit(0);
```

บันทึกสคริปต์ที่สองเป็น `embed-fixed-chart.js` แล้วเรียกใช้งานหลังจาก `create-fixed-chart.js`. สคริปต์นี้อ่านสมุดงาน XLS ที่สร้างขึ้นและบันทึกเป็น `chart-fixed-size.pptx`. การเชื่อมต่อ Java ต้องการอาร์เรย์ไบต์ของ Java สำหรับข้อมูลสมุดงานและค่าจำนวนจริงแบบ float ของ Java สำหรับพิกัดและขนาดของกรอบ ส่วนต่อท้าย `xls` สอดคล้องกับรูปแบบที่บันทึกของสมุดงาน

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // พิกัดและขนาดของสไลด์ใช้หน่วยจุด (72 จุดต่อหนึ่งนิ้ว).
    const width = 684; // 9.5 นิ้ว.
    const height = 288; // 4 นิ้ว.
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// งานแบบซิงโครนัสทั้งหมดเสร็จสิ้น; หยุดกระบวนการเชื่อมต่อ Java.
process.exit(0);
```

## **ใช้แม่แบบ**

ตรรกะการกำหนดขนาดเหมือนกันสำหรับงานนำเสนอที่มีอยู่แล้ว เพื่อปรับตัวอย่างนี้:

1. โหลดงานนำเสนอจากแม่แบบแทนการสร้างงานนำเสนอว่างเปล่า.
2. ตรวจสอบว่าสไลด์แรกมีรูปร่างอย่างน้อยสามรูปร่าง แล้วใช้รูปร่างที่ดัชนี 2 เป็นตัวแทน.
3. นำความกว้างและความสูงของกรอบจากรูปร่างนั้นแทนการใช้ค่าคงที่ 684 และ 288. ใช้ขนาดเดียวกันในสคริปต์สร้างสมุดงาน, รักษาการคำนวณขนาดไม่เปลี่ยนแปลง, และสร้างสมุดงาน XLSใหม่ก่อนฝัง.
4. ใส่กรอบ OLE ที่ตำแหน่งของตัวแทนแทนการใช้พิกัดคงที่ 36 และ 72.
5. ลบตัวแทนออกก่อนบันทึกงานนำเสนอ.

## **FAQ**

**ทำไมแผนภูมิ Excel ที่ฝังไว้ของฉันจึงเปลี่ยนขนาดหลังจากเปิดใช้งานใน PowerPoint?**

นี่เกิดขึ้นเนื่องจาก Excel พยายามคืนขนาดหน้าต่างดั้งเดิมเมื่อเปิดใช้งานครั้งแรก ในขณะที่กรอบวัตถุ OLE ใน PowerPoint มีขนาดของตนเอง PowerPoint และ Excel จะเจรจาขนาดเพื่อรักษาอัตราส่วนภาพ ซึ่งอาจทำให้เกิดการปรับขนาด

**ฉันจะทำให้ขนาดของแผนภูมิและกรอบ OLE สอดคล้องกันได้อย่างไร?**

กำหนดขนาดแผนภูมิคงที่ที่ตรงกับกรอบ OLE และใช้ขนาดการพิมพ์แผนภูมิกำหนดเองก่อนฝังสมุดงาน ตัวอย่างด้านบนแสดงการตั้งค่าที่จำเป็นและการแปลงหน่วย

**การจับขนาดหน้าต่างสมุดงานเพียงอย่างเดียวเพียงพอหรือไม่?**

การจับขนาดหน้าต่างสมุดงานเพียงอย่างเดียวไม่สามารถป้องกันการเปลี่ยนขนาดของกรอบ OLE หลังจากการเปิดใช้งานได้อย่างเชื่อถือ ใช้ขนาดแผนภูมิคงที่ตามที่แสดงในตัวอย่าง

**วิธีแก้ปัญหานี้ใช้งานได้กับงานนำเสนอที่สร้างจากแม่แบบและงานนำเสนอใหม่หรือไม่?**

ใช่ สำหรับแม่แบบ ให้ใช้ขนาดและตำแหน่งของตัวแทน สำหรับงานนำเสนอใหม่ ใหระบุขนาดและตำแหน่งของกรอบโดยตรง

**ฉันสามารถใช้ตัวอย่างนี้กับแผนภูมิที่สร้างจากโปรแกรมสเปรดชีตอื่นได้หรือไม่?**

ตัวอย่างนี้ใช้สมุดงาน Excel ที่สร้างด้วย Aspose.Cells ไม่แสดงพฤติกรรมการเปิดใช้งานสำหรับโปรแกรมสเปรดชีตอื่น

## **ส่วนที่เกี่ยวข้อง**

- [สร้างแผนภูมิ Excel และฝังเป็นวัตถุ OLE ในงานนำเสนอ](/slides/th/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)