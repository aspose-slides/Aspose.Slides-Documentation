---
title: บูรณาการข้อมูล Excel เข้ากับการนำเสนอ PowerPoint
linktitle: บูรณาการ Excel
type: docs
weight: 330
url: /th/php-java/excel-integration/
keywords:
- Excel
- สมุดงาน
- อ่าน Excel
- บูรณาการ Excel
- แหล่งข้อมูล
- รวมจดหมาย
- นำเข้าตาราง
- Excel ไปยัง PowerPoint
- PowerPoint
- การนำเสนอ
- PHP
- Aspose.Slides
description: "อ่านข้อมูลจากสมุดงาน Excel ด้วย Aspose.Slides สำหรับ PHP ผ่าน Java โหลดแผ่นงานและเซลล์และใช้ค่าที่ได้เพื่อสร้างการนำเสนอ PowerPoint ที่ขับเคลื่อนด้วยข้อมูล"
---
## **บทนำ**

การนำเสนอ PowerPoint เป็นวิธีที่ทรงพลังในการแสดงและสื่อสารข้อมูล มักถูกใช้ร่วมกับสมุดงาน Excel ซึ่ง Excel ทำหน้าที่เป็นแหล่งข้อมูลเชิงโครงสร้างที่ยอดเยี่ยมและ PowerPoint จะทำหน้าที่แสดงภาพข้อมูลนั้นต่อผู้ชมอย่างมีประสิทธิภาพ

มีสถานการณ์เชิงปฏิบัติมากมายที่การผสานรวม Excel และ PowerPoint เป็นสิ่งจำเป็น เช่น การรวมจดหมาย การเติมตารางข้อมูล การสร้างสไลด์หนึ่งสไลด์ต่อบันทึกข้อมูล (การสร้างสไลด์แบบเป็นชุด) การสร้างสื่อการฝึกอบรม และการรวมหลายรายงาน Excel ให้เป็นการนำเสนอเดียว เป็นต้น

จนถึงขณะนี้ การนำคุณลักษณะเหล่านี้ไปใช้ด้วย Aspose.Slides API จำเป็นต้องพึ่งพาโซลูชันของบุคคลภายนอกเช่น Aspose.Cells แม้เครื่องมือเหล่านี้จะมีความแข็งแรง แต่ก็อาจซับซ้อนเกินไปและมีค่าใช้จ่ายสูงสำหรับผู้ใช้ที่ต้องการฟังก์ชันการรวมข้อมูลพื้นฐานเท่านั้น

## **วิธีการทำงาน**

เพื่อให้งานกับข้อมูล Excel ง่ายขึ้นและเป็นกระบวนการที่ราบรื่นยิ่งขึ้น Aspose.Slides ได้เปิดตัวคลาสใหม่สำหรับการอ่านข้อมูลจากสมุดงาน Excel และการนำเนื้อหาเข้ามาในงานนำเสนอ ฟีเจอร์นี้เปิดโอกาสใหม่ๆ ที่ทรงพลังสำหรับผู้ใช้ API ที่ต้องการใช้ Excel เป็นแหล่งข้อมูลในกระบวนการทำงานของการนำเสนอ

ฟังก์ชันใหม่ถูกออกแบบสำหรับการเข้าถึงข้อมูลทั่วไปและไม่ได้รวมเข้ากับ Presentation Document Object Model (DOM) ซึ่งหมายความว่า *ไม่อนุญาตให้แก้ไขหรือบันทึกไฟล์ Excel* — จุดประสงค์เพียงอย่างเดียวคือเปิดสมุดงานและนำทางผ่านเนื้อหาของมันเพื่อดึงข้อมูลเซลล์

แกนหลักของฟีเจอร์นี้คือคลาสใหม่ [ExcelDataWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/exceldataworkbook/) คลาสนี้ให้คุณโหลดสมุดงาน Excel จากไฟล์ในเครื่องหรือสตรีม เมื่อโหลดแล้ว จะมีเมธอด [getCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/exceldataworkbook/#getCell) หลายแบบให้คุณเลือกใช้เพื่อดึงเซลล์เฉพาะตามตำแหน่ง (เช่น แถวและคอลัมน์ หรือช่วงที่ตั้งชื่อ)

การเรียกใช้แต่ละครั้งของ [getCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/exceldataworkbook/#getCell) จะส่งคืนอินสแตนซ์ของคลาส [ExcelDataCell](https://reference.aspose.com/slides/th/php-java/aspose.slides/exceldatacell/) วัตถุนี้แทนเซลล์เดียวในสมุดงาน Excel และให้คุณเข้าถึงค่าของเซลล์ได้อย่างง่ายและเป็นธรรมชาติ

#### **นำเข้าชาร์ต Excel**

ขั้นตอนต่อไปเพื่อขยายฟังก์ชันคือคลาส [ExcelWorkbookImporter](https://reference.aspose.com/slides/th/php-java/aspose.slides/excelworkbookimporter/) คลาสยูทิลิตี้นี้ให้ฟังก์ชันการนำเข้าข้อมูลจากสมุดงาน Excel ไปยังงานนำเสนอ มีเมธอด [addChartFromWorkbook](https://reference.aspose.com/slides/th/php-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) หลายแบบที่ช่วยให้คุณดึงชาร์ตที่เลือกจากสมุดงาน Excel ที่ระบุและเพิ่มลงในคอลเลกชันรูปทรงที่กำหนด ณ พิกัดที่กำหนด

โดยสรุป นี่คือ API ที่เบาและใช้งานง่ายสำหรับอ่านข้อมูล Excel — สิ่งที่นักพัฒนาหลายคนต้องการโดยไม่ต้องมีห้องสมุดประมวลผลสเปรดชีตเต็มรูปแบบ

## **มาทำโค้ดกัน**

### **ตัวอย่างสถานการณ์การรวมจดหมาย**

ในตัวอย่างต่อไปนี้ เราจะดำเนินการสร้างสถานการณ์การรวมจดหมายอย่างง่ายโดยการสร้างงานนำเสนอหลายไฟล์จากข้อมูลที่เก็บอยู่ในสมุดงาน Excel

เพื่อเริ่มต้น เราต้องการสองสิ่ง:
1. สมุดงาน Excel ที่มีข้อมูล

![ตัวอย่างข้อมูล Excel](example1_image0.png)

2. แม่แบบงานนำเสนอ PowerPoint

![ตัวอย่างแม่แบบ PowerPoint](example1_image1.png)

```php
// โหลดสมุดงาน Excel พร้อมข้อมูลพนักงาน.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// โหลดแม่แบบการนำเสนอ.
$templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // วนลูปผ่านแถวของ Excel (ยกเว้นส่วนหัวที่แถว 0).
    for ($rowIndex = 1; $rowIndex <= 4; $rowIndex++) {

        // สร้างการนำเสนอใหม่สำหรับแต่ละบันทึกพนักงาน.
        $employeePresentation = new Presentation();

        try {
            // ลบสไลด์เปล่าดีฟอลต์.
            $employeePresentation->getSlides()->removeAt(0);

            // คัดลอกสไลด์แม่แบบไปยังการนำเสนอใหม่.
            $slide = $employeePresentation->getSlides()->addClone($templatePresentation->getSlides()->get_Item(0));

            // ดึงย่อหน้าจากรูปทรงเป้าหมาย (สมมติว่าใช้รูปทรงที่ดัชนี 1).
            $paragraphs = $slide->getShapes()->get_Item(1)->getTextFrame()->getParagraphs();

            // แทนที่ตำแหน่งตัวแปรด้วยข้อมูลจาก Excel.
            $employeeName = $workbook->getCell($worksheetIndex, $rowIndex, 0)->getValue()->toString();
            $namePortion = $paragraphs->get_Item(0)->getPortions()->get_Item(0);
            $namePortion->setText($namePortion->getText()->replace("{{EmployeeName}}", $employeeName));

            $department = $workbook->getCell($worksheetIndex, $rowIndex, 1)->getValue()->toString();
            $departmentPortion = $paragraphs->get_Item(1)->getPortions()->get_Item(0);
            $departmentPortion->setText($departmentPortion->getText()->replace("{{Department}}", $department));

            $yearsOfService = $workbook->getCell($worksheetIndex, $rowIndex, 2)->getValue()->toString();
            $yearsPortion = $paragraphs->get_Item(2)->getPortions()->get_Item(0);
            $yearsPortion->setText($yearsPortion->getText()->replace("{{YearsOfService}}", $yearsOfService));

            // บันทึกการนำเสนอที่ปรับแต่งเป็นไฟล์แยก.
            $employeePresentation->save(sprintf("%s Report.pptx", $employeeName), SaveFormat::Pptx);
        } finally {
            $employeePresentation->dispose();
        }
    }
} finally {
    $templatePresentation->dispose();
}
```

![ผลลัพธ์](example1_image2.png)

### **ตัวอย่างตาราง Excel**

ในตัวอย่างที่สอง เราจะคัดลอกข้อมูลจากตาราง Excel และแสดงบนสไลด์ PowerPoint ในรูปแบบที่ดูสวยงามยิ่งขึ้น

ในตัวอย่างนี้ เราใช้สมุดงาน Excel เดียวกับตัวอย่างแรก ซึ่งมีตารางพนักงานอย่างง่าย

```php
// โหลดสมุดงาน Excel ที่มีข้อมูลพนักงาน.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// สร้างการนำเสนอ PowerPoint ใหม่.
$presentation = new Presentation();

try {
    // เพิ่มรูปทรงตารางไปยังสไลด์แรก.
    $table = $presentation->getSlides()->get_Item(0)->getShapes()->addTable(
            50, 200,
            array(200, 200, 200),
            array(30, 30, 30, 30, 30)
    );

    // เติมตาราง PowerPoint ด้วยข้อมูลจากสมุดงาน Excel.
    for ($rowIndex = 0; $rowIndex < 5; $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < 3; $columnIndex++) {
            $cellValue = $workbook->getCell($worksheetIndex, $rowIndex, $columnIndex)->getValue()->toString();
            $table->getColumns()->get_Item($columnIndex)->get_Item($rowIndex)->getTextFrame()->setText($cellValue);
        }
    }

    // บันทึกการนำเสนอที่ได้ลงไฟล์.
    $presentation->save("Table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![ผลลัพธ์](example2_image0.png)

### **ตัวอย่างการนำเข้าชาร์ต Excel**

ในตัวอย่างนี้ เราจะนำเข้าชาร์ตจากแผ่นงานแรกของสมุดงาน Excel ที่ใช้ในตัวอย่างก่อนหน้า ชาร์ตจะเชื่อมโยงกับสมุดงานภายนอกในงานนำเสนอที่ได้ผลลัพธ์

ขั้นแรก เราเพิ่มชาร์ตวงกลม (Pie chart) ลงในสมุดงาน Excel ตามตารางพนักงาน

![ตัวอย่างชาร์ต Excel](example3_image0.png)

```php
// สร้างการนำเสนอ PowerPoint ใหม่.
$presentation = new Presentation();
try {
    // ดึงคอลเลกชันรูปทรงของสไลด์แรก.
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    // นำเข้าชาร์ตชื่อ "Chart 1" จากแผ่นงานแรกของสมุดงานและเพิ่มลงในคอลเลกชันรูปทรง.
    ExcelWorkbookImporter::addChartFromWorkbook($shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // บันทึกการนำเสนอที่ได้ลงไฟล์.
    $presentation->save("Chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![ผลลัพธ์](example3_image1.png)

### **ตัวอย่างการนำเข้าทุกชาร์ต Excel**

ลองจินตนาการว่าคุณมีสมุดงาน Excel ที่เต็มไปด้วยชาร์ตและต้องการนำเข้าทั้งหมดเข้าสู่การนำเสนอ แต่ละชาร์ตควรอยู่บนสไลด์ใหม่

โค้ดต่อไปนี้วนผ่านทุกแผ่นงานในไฟล์ Excel ต้นทาง ดึงชาร์ตจากแต่ละแผ่นงาน และเพิ่มแต่ละชาร์ตลงในสไลด์แยกกันโดยใช้เค้าโครงสไลด์เปล่า ในงานนำเสนอที่ได้ จะฝังเฉพาะข้อมูลชาร์ต ไม่ได้ฝังสมุดงานทั้งหมด

```php
// โหลดสมุดงาน Excel ที่มีข้อมูลพนักงาน.
$workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// สร้างการนำเสนอ PowerPoint ใหม่.
$presentation = new Presentation();
try {
    // ดึงเค้าโครงสไลด์เปล่า.
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // ดึงชื่อของทุกแผ่นงานที่อยู่ในสมุดงาน Excel.
    $worksheetNames = $workbook->getWorksheetNames()->iterator();

    while (java_values($worksheetNames->hasNext())) {
        $name = $worksheetNames->next();
        // ดึงแผนที่ที่แมปดัชนีชาร์ตไปยังชื่อชาร์ตสำหรับแผ่นงาน.
        $worksheetCharts = $workbook->getChartsFromWorksheet($name)->iterator();

        while (java_values($worksheetCharts->hasNext())) {
            $chart = $worksheetCharts->next();
            // เพิ่มสไลด์ใหม่โดยใช้เค้าโครงเปล่า.
            $slide = $presentation->getSlides()->addEmptySlide($blankLayout);

            // นำเข้าชาร์ตที่ระบุจากสมุดงาน Excel ไปยังคอลเลกชันรูปทรงของสไลด์.
            ExcelWorkbookImporter::addChartFromWorkbook(
                    $slide->getShapes(), 10, 10, $workbook, $name, $chart->getKey(), false);
        }
    }

    // บันทึกการนำเสนอที่ได้ลงไฟล์.
    $presentation->save("Charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **สรุป**

กลไกนี้ซึ่งมีให้ใช้งานโดยตรงใน Aspose.Slides ทำให้การทำงานกับข้อมูล Excel และงานนำเสนออยู่ในที่เดียว มันช่วยให้คุณสร้างสไลด์ที่มีชาร์ตภาพและข้อมูลในรูปแบบตาราง Excel — โดยไม่ต้องพึ่งพาห้องสมุดเพิ่มเติมหรือการผสานรวมที่ซับซ้อน.