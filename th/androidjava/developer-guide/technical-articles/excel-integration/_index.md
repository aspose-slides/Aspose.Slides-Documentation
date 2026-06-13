---
title: "รวมข้อมูล Excel เข้ากับการนำเสนอ PowerPoint"
linktitle: "การบูรณาการ Excel"
type: docs
weight: 330
url: /th/androidjava/excel-integration/
keywords:
- "Excel"
- "สมุดงาน"
- "อ่าน Excel"
- "บูรณาการ Excel"
- "แหล่งข้อมูล"
- "การผสานจดหมาย"
- "นำเข้าตาราง"
- "Excel ไปยัง PowerPoint"
- "PowerPoint"
- "การนำเสนอ"
- "Android"
- "Java"
- "Aspose.Slides"
description: "อ่านข้อมูลจากสมุดงาน Excel ใน Aspose.Slides ด้วย API ExcelDataWorkbook โหลดแผ่นงานและเซลล์และใช้ค่าต่าง ๆ เพื่อสร้างการนำเสนอ PowerPoint ที่ขับเคลื่อนด้วยข้อมูล"
---
## **บทนำ**

การนำเสนอ PowerPoint เป็นวิธีที่ทรงพลังในการแสดงและสื่อสารข้อมูล โดยมักใช้ร่วมกับหนังสือ Excel ซึ่ง Excel ทำหน้าที่เป็นแหล่งข้อมูลที่มีโครงสร้างดีและ PowerPoint เก่งในการทำภาพข้อมูลเหล่านั้นให้ผู้ชมเห็นชัดเจน

มีหลายสถานการณ์ที่การรวม Excel กับ PowerPoint เป็นสิ่งจำเป็น เช่น การทำเมลเมิร์จ, การเติมข้อมูลตาราง, การสร้างสไลด์หนึ่งสไลด์ต่อแต่ละบันทึกข้อมูล (การสร้างสไลด์เป็นชุด), การทำเอกสารการฝึกอบรม, และการรวมหลายรายงาน Excel ให้เป็นการนำเสนอเดียวกัน เป็นต้น

จนถึงขณะนี้ การทำคุณลักษณะเหล่านี้ด้วย Aspose.Slides API จำเป็นต้องพึ่งพาโซลูชันจากบุคคลที่สามอย่าง Aspose.Cells แม้เครื่องมือเหล่านี้จะมีความแข็งแกร่ง แต่ก็อาจซับซ้อนและมีค่าใช้จ่ายสูงเกินไปสำหรับผู้ใช้ที่ต้องการเพียงการบูรณาการข้อมูลพื้นฐานเท่านั้น

## **วิธีการทำงาน**

เพื่อให้การทำงานกับข้อมูล Excel ง่ายและเป็นระเบียบยิ่งขึ้น Aspose.Slides ได้เปิดตัวคลาสใหม่สำหรับอ่านข้อมูลจากหนังสือ Excel และนำเข้าเนื้อหาเข้าสู่การนำเสนอ ฟีเจอร์นี้เปิดโอกาสใหม่ที่ทรงพลังสำหรับผู้ใช้ API ที่ต้องการใช้ Excel เป็นแหล่งข้อมูลในกระบวนการทำงานของการนำเสนอ

ฟังก์ชันใหม่ออกแบบมาเพื่อการเข้าถึงข้อมูลแบบทั่วไปและไม่ได้รวมเข้าไปใน Presentation Document Object Model (DOM) ซึ่งหมายความว่า *ไม่อนุญาตให้แก้ไขหรือบันทึกไฟล์ Excel* – วัตถุประสงค์เพียงอย่างเดียวคือการเปิดหนังสือและนำทางผ่านเนื้อหาเพื่อดึงข้อมูลเซลล์

หัวใจของฟีเจอร์นี้คือคลาสใหม่ [ExcelDataWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/exceldataworkbook/) คลาสนี้ช่วยให้คุณโหลดหนังสือ Excel จากไฟล์ในเครื่องหรือจากสตรีม เมื่อโหลดแล้วจะมีเมธอด [getCell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) จำนวนหลายเวอร์ชันให้คุณดึงเซลล์เฉพาะตามตำแหน่ง (เช่น ดัชนีแถวและคอลัมน์หรือช่วงที่กำหนดชื่อ)

การเรียกแต่ละครั้งของ [getCell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) จะคืนค่าเป็นอินสแตนซ์ของคลาส [ExcelDataCell](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/exceldatacell/) วัตถุนี้แทนเซลล์เดียวในหนังสือ Excel และให้คุณเข้าถึงค่าของเซลล์นั้นอย่างง่ายและเป็นธรรมชาติ

#### **การนำเข้าชาร์ต Excel**

ขั้นตอนต่อไปเพื่อขยายฟังก์ชันคือคลาส [ExcelWorkbookImporter](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/excelworkbookimporter/) คลาสยูทิลิตี้นี้ให้ความสามารถในการนำเข้าเนื้อหาจากหนังสือ Excel ไปยังการนำเสนอ มีเมธอด [addChartFromWorkbook](https://reference.aspose.com/slides/th/androidjava/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) จำนวนหลายเวอร์ชันที่ช่วยให้คุณดึงชาร์ตที่เลือกจากหนังสือ Excel ที่ระบุและเพิ่มลงท้ายคอลเลกชันเชป Shape ที่กำหนดในพิกัดที่ระบุ

สรุปคือ API ที่เบาลงและตรงไปตรงมาสำหรับการอ่านข้อมูล Excel – สิ่งที่นักพัฒนาหลายคนต้องการโดยไม่ต้องพึ่งพาห้องสมุดการประมวลผลสเปรดชีตแบบเต็มรูปแบบ

## **มาลงมือเขียนโค้ดกัน**

### **ตัวอย่างสถานการณ์เมลเมิร์จ**

ในตัวอย่างต่อไปนี้ เราจะทำสถานการณ์เมลเมิร์จอย่างง่ายโดยสร้างการนำเสนอหลายชุดจากข้อมูลที่เก็บไว้ในหนังสือ Excel

เพื่อเริ่มต้น เราต้องการสองอย่าง:
1. หนังสือ Excel ที่มีข้อมูล

![Excel data example](example1_image0.png)

2. แม่แบบการนำเสนอ PowerPoint

![PowerPoint template example](example1_image1.png)

```java
// โหลดสมุดงาน Excel ด้วยข้อมูลพนักงาน.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// โหลดแม่แบบการนำเสนอ.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // วนลูปผ่านแถวของ Excel (ยกเว้นหัวตารางที่แถว 0).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // สร้างการนำเสนอใหม่สำหรับแต่ละบันทึกพนักงาน.
        Presentation employeePresentation = new Presentation();

        try {
            // ลบสไลด์เปล่าเริ่มต้น.
            employeePresentation.getSlides().removeAt(0);

            // คัดลอกสไลด์แม่แบบเข้าสู่การนำเสนอใหม่.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // ดึงย่อหน้าจากรูปร่างเป้าหมาย (สมมติว่าใช้รูปร่างดัชนี 1).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // แทนที่ตำแหน่งตัวแปรด้วยข้อมูลจาก Excel.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // บันทึกการนำเสนอที่ปรับให้เหมาะกับแต่ละบุคคลเป็นไฟล์แยก.
            employeePresentation.save(String.format("%s Report.pptx", employeeName), SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Result](example1_image2.png)

### **ตัวอย่างตาราง Excel**

ในตัวอย่างที่สอง เราจะคัดลอกข้อมูลจากตาราง Excel แล้วแสดงบนสไลด์ PowerPoint ในรูปแบบที่ดูเป็นภาพมากขึ้น

ในตัวอย่างนี้ เราใช้หนังสือ Excel เดียวกับตัวอย่างแรก ซึ่งมีตารางพนักงานแบบง่าย

```java
// โหลดสมุดงาน Excel ที่มีข้อมูลพนักงาน.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// สร้างการนำเสนอ PowerPoint ใหม่.
Presentation presentation = new Presentation();

try {
    // เพิ่มรูปร่างตารางไปยังสไลด์แรก.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // เติมตาราง PowerPoint ด้วยข้อมูลจากสมุดงาน Excel.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // บันทึกการนำเสนอที่ได้เป็นไฟล์.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Result](example2_image0.png)

### **ตัวอย่างการนำเข้าชาร์ต Excel**

ในตัวอย่างนี้ เรานำเข้าชาร์ตจากแผ่นงานแรกของหนังสือ Excel ที่ใช้ในตัวอย่างก่อนหน้า ชาร์ตจะลิงก์ไปยังหนังสือภายนอกในการนำเสนอที่สร้างขึ้น

แรกเริ่ม เราเพิ่มชาร์ตวงกลม (Pie) ลงในหนังสือ Excel ตามตารางพนักงาน

![Excel Chart example](example3_image0.png)

```java
// สร้างการนำเสนอ PowerPoint ใหม่.
Presentation presentation = new Presentation();
try {
    // ดึงคอลเลกชันรูปร่างของสไลด์แรก.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // นำเข้าชาร์ตชื่อ "Chart 1" จากแผ่นงานแรกของสมุดงานและเพิ่มลงในคอลเลกชันรูปร่าง.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // บันทึกการนำเสนอที่ได้เป็นไฟล์.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Result](example3_image1.png)

### **ตัวอย่างการนำเข้าชาร์ต Excel ทั้งหมด**

ลองนึกว่าคุณมีหนังสือ Excel ที่เต็มไปด้วยชาร์ตและต้องการนำเข้าทั้งหมดเข้าสู่การนำเสนอ แต่ละชาร์ตควรอยู่บนสไลด์ใหม่

โค้ดต่อไปนี้วนลูปผ่านแผ่นงานทั้งหมดในไฟล์ Excel แหล่งข้อมูล ดึงชาร์ตจากแต่ละแผ่นงานและเพิ่มแต่ละชาร์ตลงบนสไลด์แยกโดยใช้เลย์เอาต์สไลด์เปล่า ในการนำเสนอผลลัพธ์จะฝังเฉพาะข้อมูลชาร์ตเท่านั้น ไม่ได้ฝังหนังสือ Excel เต็มฉบับ

```java
// โหลดสมุดงาน Excel ที่มีข้อมูลพนักงาน.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// สร้างการนำเสนอ PowerPoint ใหม่.
Presentation presentation = new Presentation();
try {
    // ดึงเลย์เอาต์สไลด์เปล่า.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // ดึงชื่อของแผ่นงานทั้งหมดที่อยู่ในสมุดงาน Excel.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // ดึงแผนที่ที่แมปดัชนีชาร์ตไปยังชื่อชาร์ตสำหรับแผ่นงานนั้น.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // เพิ่มสไลด์ใหม่โดยใช้เลย์เอาต์เปล่า.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // นำเข้าชาร์ตที่ระบุจากสมุดงาน Excel ไปยังคอลเลกชันรูปร่างของสไลด์.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // บันทึกการนำเสนอที่ได้เป็นไฟล์.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **สรุป**

กลไกนี้ซึ่งรวมอยู่ใน Aspose.Slides โดยตรง ช่วยให้การทำงานกับข้อมูล Excel และการนำเสนอทำได้ในที่เดียว มันทำให้คุณสร้างสไลด์พร้อมชาร์ตภาพและข้อมูลในรูปแบบตาราง Excel ได้โดยไม่ต้องใช้ไลบรารีเพิ่มเติมหรือการบูรณาการที่ซับซ้อน