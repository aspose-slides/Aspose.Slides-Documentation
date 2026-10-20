---
title: สร้างแผนภูมิ Excel และฝังลงในงานนำเสนอเป็นวัตถุ OLE
type: docs
weight: 30
url: /th/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- แผนภูมิ Excel
- ฝังแผนภูมิ
- วัตถุ OLE
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "สร้างแผนภูมิ Excel ด้วย Aspose.Cells สำหรับ Node.js ผ่าน Java และฝังเวิร์กบุ๊กในงานนำเสนอ PowerPoint ด้วย Aspose.Slides รวมถึงภาพตัวอย่างของแผนภูมิ"
---
## **ภาพรวม**

บทความนี้แสดงวิธีการสร้างแผนภูมิคอลัมน์ Excel ด้วย Aspose.Cells สำหรับ Node.js ผ่าน Java และฝังเวิร์กบุ๊กของมันในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ Node.js ผ่าน Java. เวิร์กบุ๊กที่ฝังไว้มีข้อมูลต้นฉบับและแผนภูมิอยู่ด้วย. ตัวแสดงตัวอย่าง PNG แยกต่างหากจะแสดงแผนภูมิบนสไลด์ก่อนที่วัตถุ OLE จะถูกเปิดใช้งาน.

ผลลัพธ์คือวัตถุ Excel ที่ฝังอยู่ ไม่ใช่แผนภูมิ PowerPoint เนทีฟ การแก้ไขเวิร์กบุ๊กผ่าน OLE จำเป็นต้องใช้แอปพลิเคชันบนเดสก์ท็อปที่สนับสนุนการเปิดใช้งาน OLE และการติดตั้ง Excel ที่เข้ากันได้.

## **ข้อกำหนดเบื้องต้น**

ติดตั้งแพ็กเกจ Node.js `aspose.cells`, `aspose.slides.via.java` และ `java`. เรียกใช้งานตัวอย่างเป็นสคริปต์ CommonJS สองไฟล์ในกระบวนการ Node.js แยกกัน: อันดับแรก `create-chart.js`, จากนั้น `embed-chart.js`, โดยใช้ไดเรกทอรีทำงานเดียวกัน แพ็กเกจ Aspose ทั้งสองจะเริ่มต้นสะพาน Java ระหว่างการโหลด ดังนั้นตัวอย่างเหล่านี้จะเก็บไว้ในกระบวนการแยกกัน ไม่จำเป็นต้องใช้ Microsoft Office เพื่อสร้างงานนำเสนอด้วยไลบรารีเหล่านี้.

ไม่จำเป็นต้องมีเวิร์กบุ๊กหรือภาพที่มีอยู่แล้ว สคริปต์แรกจะสร้าง `ChartWorkbook.xlsx` และ `ChartPreview.png`; สคริปต์ที่สองจะอ่านไฟล์เหล่านั้นและเขียน `OutputChart.pptx` ไปยังไดเรกทอรีทำงานปัจจุบัน ให้ใช้ไลเซนส์สำหรับผลิตภัณฑ์ทั้งสองเมื่อรันนอกโหมดประเมินผล.

## **วิธีการทำงานของการฝัง**

1. สร้างเวิร์กบุ๊กที่มีแผ่นงานข้อมูลและแผ่นชาร์ต.
2. ทำให้แผ่นชาร์ตเป็นแอคทีฟเพื่อให้เวิร์กบุ๊กเปิดที่แผ่นชาร์ต.
3. ตั้งค่าช่วงการแสดงผล OLE ของเวิร์กบุ๊กและแปลงแผนภูมิเป็น PNG.
4. บันทึกเวิร์กบุ๊กเป็น XLSX และฝังไบต์ของมันในสไลด์ในกระบวนการ Node.js แยกต่างหาก.
5. กำหนด PNG เป็นภาพตัวอย่างของวัตถุ OLE และบันทึกงานนำเสนอเป็น PPTX.

ช่วงการแสดงผลของเวิร์กบุ๊กและกรอบบนสไลด์มีบทบาทที่แตกต่างกัน [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) รับค่าแถวและคอลัมน์เริ่มต้น/สิ้นสุดที่นับจากศูนย์ [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) กลับรับแถวบน, คอลัมน์ซ้าย, แถวล่าง, และคอลัมน์ขวา ตัวอย่างใช้ดัชนีแถว 55 และดัชนีคอลัมน์ 25 เป็นขอบเขตด้านล่างขวา; ค่าต่าง ๆ เหล่านี้เป็นการเลือกการจัดวาง ไม่ใช่จำนวนแถวหรือคอลัมน์ของข้อมูล.

กรอบสไลด์ใช้หน่วยพอยต์ ตัวอย่างปรับให้พอดีภายในสไลด์และจัดกึ่งกลางโดยคงสัดส่วนของ PNG ไว้ แทนการยืดภาพตัวอย่างเพื่อเติมเต็มสไลด์.

## **สร้างและฝังแผนภูมิ**

บันทึกตัวอย่างแรกเป็น `create-chart.js`. ตัวอย่างนี้จะเติมข้อมูลลงใน `DataSheet` ด้วยแถวสี่แถวและคอลัมน์ห้าคอลัมน์ของค่า แต่ละแถวจะกลายเป็นซีรีส์ของแผนภูมิ `ChartSheet` ถูกเลือกเป็นแผ่นงานที่ทำงานอยู่ก่อนบันทึกเวิร์กบุ๊ก.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // เรนเดอร์ภาพตัวอย่างของแผนภูมิและทำการซีเรียลไลซ์เวิร์กบุ๊กที่แก้ไขได้แยกจากกัน.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// งานซิงโครนัสทั้งหมดเสร็จสิ้น; หยุดกระบวนการสะพาน Java.
process.exit(0);
```

บันทึกตัวอย่างต่อไปนี้เป็น `embed-chart.js`. เรียกใช้งานหลังจากที่ `create-chart.js` สร้างไฟล์อินพุตทั้งสองแล้ว ตัวอย่างจะจัดกึ่งกลางกรอบ OLE และคงสัดส่วนของภาพตัวอย่าง.

สคริปต์ที่สองฝังเวิร์กบุ๊กที่บันทึกไว้และใช้ PNG เป็นภาพตัวอย่าง เวิร์กบุ๊กถูกบันทึกเป็น XLSX อย่างชัดเจน เพื่อให้ตรงกับส่วนขยาย `xlsx` ที่ส่งผ่านไปยัง [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/). PNG ถูกโหลดโดยตรงจากไบต์โดยไม่มีการแปลงบิตแมปกลาง สะพาน Java จำเป็นต้องมีอาเรย์ไบต์ของ Java สำหรับภาพและข้อมูลเวิร์กบุ๊กอย่างชัดเจน และค่าทศนิยมแบบ float ของ Java สำหรับพิกัดกรอบสไลด์ การกำหนดค่าโดยผ่าน [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) จะเปลี่ยนตัวแทน OLE เริ่มต้น.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // ปรับภาพตัวอย่างให้พอดีภายในสไลด์โดยไม่เปลี่ยนอัตราส่วนของมัน.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// งานซิงโครนัสทั้งหมดเสร็จสิ้น; หยุดกระบวนการสะพาน Java.
process.exit(0);
```

## **ผลลัพธ์ที่คาดหวัง**

`OutputChart.pptx` มีสไลด์หนึ่งสไลด์ที่มีเวิร์กบุ๊ก Excel ที่ฝังและภาพตัวอย่างของแผนภูมิ ภายในเวิร์กบุ๊กมีข้อมูลเดิมและแผนภูมิคอลัมน์ที่มีสี่ซีรีส์ ภาพตัวอย่างถูกจัดกึ่งกลางบนสไลด์และคงอัตราส่วนเดิม.

![แผนภูมิคอลัมน์ Excel ที่แสดงเป็นภาพตัวอย่างของเวิร์กบุ๊กที่ฝัง](excel-chart-ole-preview.png)

ในสภาพแวดล้อม PowerPoint บนเดสก์ท็อปที่รองรับและมี Excel พร้อมใช้งาน ให้คลิกสองครั้งที่วัตถุเพื่อเปิดใช้งานและแก้ไขเวิร์กบุ๊กที่ฝัง การเปิดใช้งานและการแก้ไขขึ้นอยู่กับการสนับสนุน OLE ของแอปพลิเคชันโฮสต์และการตั้งค่าความปลอดภัย.

## **คำถามที่พบบ่อย**

**ทำไมต้องใช้ภาพตัวอย่าง?**

เวิร์กบุ๊กที่ฝังและภาพตัวอย่างบนสไลด์เป็นเนื้อหาแยกกัน ให้จัดเตรียมภาพแผนภูมิเพื่อให้สไลด์แสดงแผนภูมิแทนการแสดงตำแหน่งเริ่มต้น "EMBEDDED OLE OBJECT" ดูที่ [ปัญหาภาพตัวอย่างของวัตถุเมื่อเพิ่ม OleObjectFrame](/slides/th/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**ภาพตัวอย่างจะอัปเดตโดยอัตโนมัติเมื่อฉันเปลี่ยนเวิร์กบุ๊กในโค้ดหรือไม่?**

ถือว่าภาพตัวอย่างเป็นสแนปช็อต เมื่ออัปเดตข้อมูลเวิร์กบุ๊กด้วยโปรแกรม ให้สร้างภาพแผนภูมิใหม่และแทนที่ภาพตัวอย่างรวมทั้งข้อมูลเวิร์กบุ๊กที่ฝังด้วย.

**ฉันสามารถใช้ XLS แทน XLSX ได้หรือไม่?**

ได้. บันทึกเวิร์กบุ๊กในรูปแบบ XLS และใช้ `xls` เป็นส่วนขยายของข้อมูลที่ฝัง ส่วนขยายต้องตรงกับรูปแบบของเวิร์กบุ๊กจริง; การเปลี่ยนส่วนขยายอย่างเดียวไม่ทำให้ข้อมูลแปลงรูปแบบ.

**ทำไมวัตถุอาจเปลี่ยนขนาดหลังจากเปิดใช้งาน?**

แอปพลิเคชันโฮสต์อาจอัปเดตการแสดงผลของวัตถุ OLE เมื่อเปิดใช้งานเวิร์กบุ๊ก ช่วงการแสดงผล OLE ของเวิร์กบุ๊กและขนาดกรอบสไลด์มีผลสำคัญเช่นกัน ดูที่ [วิธีการแก้ปัญหาการปรับขนาดแผนภูมิใน PPTX](/slides/th/java/working-solution-for-chart-resizing-in-pptx/).

## **ส่วนที่เกี่ยวข้อง**

- [วิธีการแก้ปัญหาการปรับขนาดแผนภูมิใน PPTX](/slides/th/java/working-solution-for-chart-resizing-in-pptx/)
- [ปัญหาภาพตัวอย่างของวัตถุเมื่อเพิ่ม OleObjectFrame](/slides/th/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)