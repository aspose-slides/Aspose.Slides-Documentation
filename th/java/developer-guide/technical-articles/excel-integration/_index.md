---
title: บูรณาการข้อมูล Excel เข้าไปในงานนำเสนอ PowerPoint
linktitle: การบูรณาการ Excel
type: docs
weight: 330
url: /th/java/excel-integration/
keywords:
- Excel
- เวิร์กบุ๊ก
- อ่าน Excel
- บูรณาการ Excel
- แหล่งข้อมูล
- เมลเมิร์จ
- อิมพอร์ตตาราง
- Excel ไปยัง PowerPoint
- PowerPoint
- การนำเสนอ
- Java
- Aspose.Slides
description: "อ่านข้อมูลจากเวิร์กบุ๊ก Excel ใน Aspose.Slides ด้วย API ExcelDataWorkbook โหลดแผ่นงานและเซลล์และใช้ค่าต่างๆ เพื่อสร้างงานนำเสนอ PowerPoint ที่ขับเคลื่อนด้วยข้อมูล"
---
## **บทนำ**

การนำเสนอ PowerPoint เป็นวิธีที่มีประสิทธิภาพในการแสดงและสื่อสารข้อมูล โดยมักใช้ร่วมกับเวิร์กบุ๊กของ Excel ซึ่ง Excel ทำหน้าที่เป็นแหล่งข้อมูลที่มีโครงสร้างที่ยอดเยี่ยมและ PowerPoint โดดเด่นในการแสดงภาพข้อมูลนั้นต่อผู้ชม

มีหลายสถานการณ์ปฏิบัติที่การผสาน Excel กับ PowerPoint เป็นสิ่งจำเป็น เช่น การทำเมลเมิร์จ, การเติมข้อมูลในตาราง, การสร้างสไลด์หนึ่งต่อบันทึกข้อมูล (การสร้างสไลด์เป็นชุด), การสร้างวัสดุการฝึกอบรม, และการรวมหลายรายงาน Excel เข้าด้วยกันเป็นการนำเสนอเดียว เป็นต้น

จนถึงตอนนี้ การทำคุณลักษณะเหล่านี้ด้วย Aspose.Slides API ต้องอาศัยโซลูชันของบุคคลที่สามเช่น Aspose.Cells แม้ว่เครื่องมือเหล่านี้จะแข็งแกร่ง แต่ก็อาจซับซ้อนและแพงเกินไปสำหรับผู้ใช้ที่ต้องการเพียงฟังก์ชันการบูรณาการข้อมูลพื้นฐาน

## **วิธีการทำงาน**

เพื่อทำให้การทำงานกับข้อมูล Excel ง่ายและเป็นระเบียบยิ่งขึ้น Aspose.Slides ได้นำเข้าคลาสใหม่สำหรับอ่านข้อมูลจากเวิร์กบุ๊ก Excel และการนำเข้าข้อมูลเข้าสู่การนำเสนอ ฟีเจอร์นี้เปิดโอกาสใหม่ที่มีประสิทธิภาพสำหรับผู้ใช้ API ที่ต้องการใช้ Excel เป็นแหล่งข้อมูลในกระบวนการทำงานของการนำเสนอ

ฟังก์ชันใหม่ถูกออกแบบเพื่อการเข้าถึงข้อมูลทั่วไปและไม่ได้ผสานเข้าไปใน Presentation Document Object Model (DOM) ซึ่งหมายความว่า *ไม่อนุญาตให้แก้ไขหรือบันทึกไฟล์ Excel* — จุดประสงค์เดียวของมันคือการเปิดเวิร์กบุ๊กและนำทางผ่านเนื้อหาเพื่อดึงข้อมูลเซลล์

ที่หัวใจของฟีเจอร์นี้คือคลาสใหม่ [ExcelDataWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/exceldataworkbook/) คลาสนี้ให้คุณโหลดเวิร์กบุ๊ก Excel จากไฟล์ในเครื่องหรือสตรีม เมื่อโหลดแล้ว จะมีเมธอด [getCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) หลายรูปแบบที่คุณสามารถใช้ดึงเซลล์เฉพาะตามตำแหน่ง (เช่น ดัชนีแถวและคอลัมน์หรือช่วงที่ตั้งชื่อ)

แต่ละครั้งที่เรียก [getCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) จะคืนค่าเป็นอินสแตนซ์ของคลาส [ExcelDataCell](https://reference.aspose.com/slides/th/java/com.aspose.slides/exceldatacell/) วัตถุนี้แทนเซลล์เดียวในเวิร์กบุ๊ก Excel และให้คุณเข้าถึงค่าของเซลล์อย่างง่ายและเป็นธรรมชาติ

#### **นำเข้าชาร์ตจาก Excel**

ขั้นตอนต่อไปเพื่อขยายฟังก์ชันคือคลาส [ExcelWorkbookImporter](https://reference.aspose.com/slides/th/java/com.aspose.slides/excelworkbookimporter/) คลาสเครื่องมือนี้ให้ความสามารถในการนำเข้าข้อมูลจากเวิร์กบุ๊ก Excel ไปยังการนำเสนอ มันมีเมธอด [addChartFromWorkbook](https://reference.aspose.com/slides/th/java/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) หลายรูปแบบที่ช่วยให้คุณดึงชาร์ตที่เลือกจากเวิร์กบุ๊ก Excel ที่ระบุและเพิ่มลงในส่วนท้ายของคอล렉ชันรูปร่างที่กำหนดในพิกัดที่ระบุ

โดยสรุป นี่คือ API ที่เบาและตรงไปตรงมาสำหรับการอ่านข้อมูล Excel — สิ่งที่นักพัฒนาหลายคนต้องการโดยไม่ต้องพึ่งพาห้องสมุดการประมวลผลสเปรดชีตแบบเต็มรูปแบบ

## **มาลองเขียนโค้ด**

### **ตัวอย่างสถานการณ์เมลเมิร์จ**

ในตัวอย่างต่อไปนี้ เราจะทำการประยุกต์ใช้สถานการณ์เมลเมิร์จอย่างง่ายโดยสร้างการนำเสนอหลายชุดจากข้อมูลที่เก็บอยู่ในเวิร์กบุ๊ก Excel

เพื่อเริ่มต้น เราต้องการสองสิ่ง:
1. เวิร์กบุ๊ก Excel ที่มีข้อมูล

![ตัวอย่างข้อมูล Excel](example1_image0.png)

2. แม่แบบการนำเสนอ PowerPoint

![ตัวอย่างแม่แบบ PowerPoint](example1_image1.png)

```java
// โหลดเวิร์กบุ๊ก Excel ด้วยข้อมูลพนักงาน.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// โหลดแม่แบบการนำเสนอ.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // วนลูปผ่านแถวของ Excel (ยกเว้นแถวหัวเรื่องที่แถว 0).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // สร้างการนำเสนอใหม่สำหรับแต่ละระเบียนพนักงาน.
        Presentation employeePresentation = new Presentation();

        try {
            // ลบสไลด์เปล่าเริ่มต้นออก.
            employeePresentation.getSlides().removeAt(0);

            // คัดลอกสไลด์แม่แบบเข้าสู่การนำเสนอใหม่.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // ดึงย่อหน้าจากรูปทรงเป้าหมาย (สมมติว่ารูปทรงดัชนี 1 ถูกใช้).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // แทนที่ตัวแปรตำแหน่งด้วยข้อมูลจาก Excel.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // บันทึกการนำเสนอที่ปรับให้เป็นส่วนตัวเป็นไฟล์แยก.
            employeePresentation.save(String.format("%s Report.pptx", employeeName), SaveFormat.Pptx);
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

ในตัวอย่างที่สอง เราจะคัดลอกข้อมูลจากตาราง Excel แล้วแสดงบนสไลด์ PowerPoint ในรูปแบบที่ดูน่าเห็นยิ่งขึ้น

ในตัวอย่างนี้ เราใช้เวิร์กบุ๊ก Excel เดียวกันจากตัวอย่างแรก ซึ่งมีตารางพนักงานอย่างง่าย

```java
// โหลดเวิร์กบุ๊ก Excel ที่มีข้อมูลพนักงาน.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// สร้างการนำเสนอ PowerPoint ใหม่.
Presentation presentation = new Presentation();

try {
    // เพิ่มรูปทรงตารางไปยังสไลด์แรก.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // เติมตาราง PowerPoint ด้วยข้อมูลจากเวิร์กบุ๊ก Excel.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // บันทึกการนำเสนอที่ได้ลงไฟล์.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![ผลลัพธ์](example2_image0.png)

### **ตัวอย่างการนำเข้าชาร์ต Excel**

ในตัวอย่างนี้ เรานำเข้าชาร์ตจากแผ่นงานแรกของเวิร์กบุ๊ก Excel ที่ใช้ในตัวอย่างก่อนหน้า ชาร์ตจะเชื่อมโยงกับเวิร์กบุ๊กภายนอกในการนำเสนอที่ได้

แรกสุด เราเพิ่มชาร์ตพายลงในเวิร์กบุ๊ก Excel ตามตารางพนักงาน

![ตัวอย่างชาร์ต Excel](example3_image0.png)

```java
// สร้างการนำเสนอ PowerPoint ใหม่.
Presentation presentation = new Presentation();
try {
    // ดึงคอลเลกชันรูปทรงของสไลด์แรก.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // นำเข้าชาร์ตชื่อ "Chart 1" จากแผ่นแรกของเวิร์กบุ๊กและเพิ่มลงในคอลเลกชันรูปทรง.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // บันทึกการนำเสนอที่ได้ลงไฟล์.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![ผลลัพธ์](example3_image1.png)

### **ตัวอย่างการนำเข้าชาร์ต Excel ทั้งหมด**

ลองนึกว่า คุณมีเวิร์กบุ๊ก Excel ที่เต็มไปด้วยชาร์ตและต้องการนำเข้าทั้งหมดลงในการนำเสนอ แต่ละชาร์ตควรอยู่บนสไลด์ใหม่

โค้ดต่อไปนี้จะวนผ่านแผ่นงานทั้งหมดในไฟล์ Excel ต้นทาง ดึงชาร์ตจากแต่ละแผ่นงาน และเพิ่มชาร์ตแต่ละอันลงบนสไลด์แยกโดยใช้เค้าโครงสไลด์เปล่า ในการนำเสนอที่ได้ จะฝังเฉพาะข้อมูลชาร์ตเท่านั้น ไม่ใช่เวิร์กบุ๊กทั้งหมด

```java
// โหลดเวิร์กบุ๊ก Excel ที่มีข้อมูลพนักงาน.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// สร้างการนำเสนอ PowerPoint ใหม่.
Presentation presentation = new Presentation();
try {
    // ดึงเค้าโครงสไลด์เปล่า.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // ดึงชื่อของแผ่นงานทั้งหมดที่อยู่ในเวิร์กบุ๊ก Excel.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // ดึงแผนที่ที่แมปดัชนีชาร์ตกับชื่อชาร์ตสำหรับแผ่นงาน.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // เพิ่มสไลด์ใหม่โดยใช้เค้าโครงเปล่า.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // นำเข้าชาร์ตที่ระบุจากเวิร์กบุ๊ก Excel ไปยังคอลเลกชันรูปทรงของสไลด์.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // บันทึกการนำเสนอที่ได้ลงไฟล์.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **สรุป**

กลไกนี้ที่มีให้โดยตรงใน Aspose.Slides ผสานการทำงานกับข้อมูล Excel และการนำเสนอไว้ในที่เดียว ทำให้คุณสร้างสไลด์ที่มีชาร์ตภาพและข้อมูลในรูปแบบตาราง Excel — ไม่ต้องพึ่งห้องสมุดเพิ่มเติมหรือการบูรณาการที่ซับซ้อน