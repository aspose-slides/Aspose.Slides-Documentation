---
title: รวมข้อมูล Excel เข้าไปในงานนำเสนอ PowerPoint
linktitle: การผสาน Excel
type: docs
weight: 330
url: /th/nodejs-java/excel-integration/
keywords:
- Excel
- สมุดงาน
- อ่าน Excel
- ผสาน Excel
- แหล่งข้อมูล
- เมลเมิร์จ
- นำเข้าตาราง
- Excel ไปยัง PowerPoint
- PowerPoint
- งานนำเสนอ
- Node.js
- JavaScript
- Aspose.Slides
description: "อ่านข้อมูลจากสมุดงาน Excel ด้วย JavaScript ผ่าน Aspose.Slides โหลดแผ่นงานและเซลล์และใช้ค่าต่าง ๆ เพื่อสร้างงานนำเสนอ PowerPoint ที่ขับเคลื่อนด้วยข้อมูล"
---
## **บทนำ**

งานนำเสนอ PowerPoint เป็นวิธีที่ทรงพลังในการแสดงและสื่อสารข้อมูล มักใช้ร่วมกับสมุดงาน Excel โดยที่ Excel ทำหน้าที่เป็นแหล่งข้อมูลเชิงโครงสร้างที่ยอดเยี่ยมและ PowerPoint มีความเชี่ยวชาญในการแสดงภาพข้อมูลนั้นต่อผู้ชม

มีหลายสถานการณ์ที่การผสมผสาน Excel กับ PowerPoint เป็นสิ่งจำเป็น เช่น การทำเมลเมิร์จ, การเติมข้อมูลในตาราง, การสร้างสไลด์หนึ่งสไลด์ต่อหนึ่งแถวข้อมูล (การสร้างสไลด์แบบเป็นชุด), การสร้างวัสดุการฝึกอบรม, และการรวมรายงาน Excel หลายชิ้นเป็นหนึ่งงานนำเสนอ เป็นต้น

จนถึงตอนนี้ การนำคุณลักษณะเหล่านี้ไปใช้กับ Aspose.Slides API จำเป็นต้องพึ่งพาโซลูชันของบุคคลที่สามเช่น Aspose.Cells แม้ว่าทูลเหล่านี้จะมีความแข็งแกร่ง แต่ก็อาจซับซ้อนเกินไปและมีค่าใช้จ่ายสูงสำหรับผู้ใช้ที่ต้องการเพียงฟังก์ชันการรวมข้อมูลพื้นฐาน

## **วิธีการทำงาน**

เพื่อทำให้การทำงานกับข้อมูล Excel ง่ายขึ้นและเป็นระเบียบ Aspose.Slides ได้นำคลาสใหม่เพื่ออ่านข้อมูลจากสมุดงาน Excel และนำเนื้อหาเข้าไปในงานนำเสนอ คุณลักษณะนี้เปิดโอกาสใหม่ที่ทรงพลังสำหรับผู้ใช้ API ที่ต้องการใช้ Excel เป็นแหล่งข้อมูลภายในกระบวนการทำงานของการนำเสนอ

ฟังก์ชันใหม่ออกแบบมาสำหรับการเข้าถึงข้อมูลทั่วไปและไม่ได้ผสานเข้ากับ Presentation Document Object Model (DOM) ซึ่งหมายความว่า *ไม่อนุญาตให้แก้ไขหรือบันทึกไฟล์ Excel* – จุดประสงค์เดียวคือการเปิดสมุดงานและนำทางผ่านเนื้อหาเพื่อดึงข้อมูลเซลล์

หัวใจของคุณลักษณะนี้คือคลาสใหม่ [ExcelDataWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/exceldataworkbook/) คลาสนี้อนุญาตให้คุณโหลดสมุดงาน Excel จากไฟล์ในเครื่องหรือสตรีม เมื่อโหลดแล้ว จะมีการโอเวอร์โหลดหลายรูปแบบของเมธอด [getCell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/exceldataworkbook/#getCell) ที่คุณสามารถใช้ดึงค่าเซลล์เฉพาะตามตำแหน่ง (เช่น ดัชนีแถวและคอลัมน์หรือช่วงที่ตั้งชื่อไว้)

แต่ละการเรียกเมธอด [getCell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/exceldataworkbook/#getCell) จะส่งคืนอินสแตนซ์ของคลาส [ExcelDataCell](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/exceldatacell/) วัตถุนี้แทนเซลล์เดียวในสมุดงาน Excel และให้คุณเข้าถึงค่าของมันในวิธีที่ง่ายและเป็นธรรมชาติ

#### **นำเข้าแผนภูมิ Excel**

ขั้นตอนต่อไปเพื่อขยายฟังก์ชันคือคลาส [ExcelWorkbookImporter](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/excelworkbookimporter/) คลาสยูทิลิตี้นี้ให้ความสามารถในการนำเข้าข้อมูลจากสมุดงาน Excel ไปยังงานนำเสนอ มันมีการโอเวอร์โหลดหลายรูปแบบของเมธอด [addChartFromWorkbook](https://reference.aspose.com/slides/th/nodejs-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) ที่ช่วยให้คุณดึงแผนภูมิที่เลือกจากสมุดงาน Excel ที่ระบุและเพิ่มลงในตำแหน่งสุดท้ายของคอลเลกชันรูปร่างที่กำหนดตามพิกัดที่ระบุ

สรุปคือเป็น API ที่เบาและเรียบง่ายสำหรับการอ่านข้อมูล Excel – ตรงกับที่นักพัฒนาหลายคนต้องการโดยไม่ต้องพิมพ์พังของไลบรารีการประมวลผลสเปรดชีตเต็มรูปแบบ

## **มาลองเขียนโค้ดกัน**

### **ตัวอย่างสถานการณ์เมลเมิร์จ**

ในตัวอย่างต่อไปนี้ เราจะทำการใช้สถานการณ์เมลเมิร์จอย่างง่ายโดยสร้างงานนำเสนอหลายชุดจากข้อมูลที่เก็บอยู่ในสมุดงาน Excel

เพื่อเริ่มต้นเราต้องการสองสิ่ง:
1. สมุดงาน Excel ที่มีข้อมูล

![ตัวอย่างข้อมูล Excel](example1_image0.png)

2. แม่แบบงานนำเสนอ PowerPoint

![ตัวอย่างแม่แบบ PowerPoint](example1_image1.png)

```js
// โหลดสมุดงาน Excel ที่มีข้อมูลพนักงาน.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// โหลดแม่แบบงานนำเสนอ.
let templatePresentation = new aspose.slides.Presentation("PresentationTemplate.pptx");

try {
    // วนลูปผ่านแถวของ Excel (ยกเว้นหัวตารางที่แถวที่ 0).
    for (let rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // สร้างงานนำเสนอใหม่สำหรับแต่ละบันทึกพนักงาน.
        let employeePresentation = new aspose.slides.Presentation();

        try {
            // ลบสไลด์เปล่าเริ่มต้นออก.
            employeePresentation.getSlides().removeAt(0);

            // คัดลอกสไลด์แม่แบบเข้าสู่งานนำเสนอใหม่.
            let slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // ดึงย่อหน้าจากรูปร่างเป้าหมาย (สมมติว่าใช้รูปร่างที่มีดัชนี 1).
            let paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs();

            // แทนที่ตำแหน่งตัวแปรด้วยข้อมูลจาก Excel.
            let employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            let namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            let department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            let departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            let yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            let yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // บันทึกงานนำเสนอที่ปรับแต่งแล้วเป็นไฟล์แยก.
            employeePresentation.save(`${employeeName} Report.pptx`, aspose.slides.SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![ผลลัพธ์](example1_image2.png)

### **ตัวอย่างตาราง Excel**

ในตัวอย่างที่สอง เราเพียงคัดลอกข้อมูลจากตาราง Excel และแสดงบนสไลด์ PowerPoint ในรูปแบบที่ดูสวยงามมากขึ้น

ในตัวอย่างนี้ เราใช้สมุดงาน Excel เดียวกับตัวอย่างแรกซ้ำ ซึ่งมีตารางพนักงานอย่างง่าย

```js
// โหลดสมุดงาน Excel ที่มีข้อมูลพนักงาน.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// สร้างงานนำเสนอ PowerPoint ใหม่.
let presentation = new aspose.slides.Presentation();

try {
    // เพิ่มรูปร่างตารางไปยังสไลด์แรก.
    let table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            java.newArray("double", [200, 200, 200]),
            java.newArray("double", [30, 30, 30, 30, 30])
    );

    // เติมข้อมูลลงในตาราง PowerPoint จากสมุดงาน Excel.
    for (let rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (let columnIndex = 0; columnIndex < 3; columnIndex++) {
            let cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // บันทึกงานนำเสนอที่ได้ลงไฟล์.
    presentation.save("Table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![ผลลัพธ์](example2_image0.png)

### **ตัวอย่างการนำเข้าแผนภูมิ Excel**

ในตัวอย่างนี้ เรานำเข้าแผนภูมิจากแผ่นงานแรกของสมุดงาน Excel ที่ใช้ในตัวอย่างก่อนหน้า แผนภูมิจะลิงก์ไปยังสมุดงานภายนอกในงานนำเสนอที่ได้

แรกเริ่ม เราเพิ่มแผนภูมิพายลงในสมุดงาน Excel ตามตารางพนักงาน

![ตัวอย่างแผนภูมิ Excel](example3_image0.png)

```js
// สร้างงานนำเสนอ PowerPoint ใหม่.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงคอลเลกชันรูปร่างของสไลด์แรก.
    let shapes = presentation.getSlides().get_Item(0).getShapes();

    // นำเข้าชาร์ตชื่อ "Chart 1" จากชีทแรกของสมุดงานและเพิ่มไปยังคอลเลกชันรูปร่าง.
    aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // บันทึกงานนำเสนอที่ได้ลงไฟล์.
    presentation.save("Chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![ผลลัพธ์](example3_image1.png)

### **ตัวอย่างการนำเข้าทุกแผนภูมิ Excel**

ลองนึกว่าคุณมีสมุดงาน Excel ที่เต็มไปด้วยแผนภูมิและคุณต้องการนำเข้าทั้งหมดไปยังงานนำเสนอ แผนภูมิแต่ละรายการควรอยู่บนสไลด์ใหม่

โค้ดต่อไปนี้จะวนผ่านแผ่นงานทั้งหมดในไฟล์ Excel ต้นทาง ดึงแผนภูมิจากแต่ละแผ่นงาน และเพิ่มแต่ละแผนภูมิลงในสไลด์แยกโดยใช้เลเอาต์สไลด์เปล่า ในงานนำเสนอผลลัพธ์ จะฝังเฉพาะข้อมูลแผนภูมิ ไม่ใช่สมุดงานทั้งหมด

```js
// โหลดสมุดงาน Excel ที่มีข้อมูลพนักงาน.
let workbook = new aspose.slides.ExcelDataWorkbook("ExcelWithCharts.xlsx");

// สร้างงานนำเสนอ PowerPoint ใหม่.
let presentation = new aspose.slides.Presentation();
try {
    // ดึงเค้าโครงสไลด์เปล่า.
    let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

    // ดึงชื่อของแผ่นงานทั้งหมดที่อยู่ในสมุดงาน Excel.
    let worksheetNames = workbook.getWorksheetNames().iterator();

    while (worksheetNames.hasNext()) {
        let name = worksheetNames.next();
        // ดึงแผนที่ที่จับดัชนีแผนภูมิกับชื่อแผนภูมิสำหรับแผ่นงาน.
        let worksheetCharts = workbook.getChartsFromWorksheet(name).iterator();

        while (worksheetCharts.hasNext()) {
            let chart = worksheetCharts.next();
            // เพิ่มสไลด์ใหม่โดยใช้เค้าโครงเปล่า.
            let slide = presentation.getSlides().addEmptySlide(layoutSlide);

            // นำเข้าแผนภูมิที่ระบุจากสมุดงาน Excel ไปยังคอลเลกชันรูปร่างของสไลด์.
            aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // บันทึกงานนำเสนอที่ได้ลงไฟล์.
    presentation.save("Charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **สรุป**

กลไกนี้ซึ่งพร้อมใช้งานโดยตรงใน Aspose.Slides รวมการทำงานกับข้อมูล Excel และงานนำเสนอไว้ในที่เดียว ช่วยให้คุณสร้างสไลด์ที่มีแผนภูมิเชิงภาพและข้อมูลที่แสดงในรูปแบบตาราง Excel — โดยไม่ต้องพึ่งไลบรารีเพิ่มเติมหรือการรวมระบบที่ซับซ้อน