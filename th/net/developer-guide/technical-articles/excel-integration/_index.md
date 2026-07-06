---
title: รวมข้อมูล Excel ลงในงานนำเสนอ PowerPoint
linktitle: การบูรณาการ Excel
type: docs
weight: 330
url: /th/net/excel-integration/
keywords:
- Excel
- สมุดงาน
- อ่าน Excel
- รวม Excel
- แหล่งข้อมูล
- เมลเมิร์จ
- นำเข้าตาราง
- Excel ไปยัง PowerPoint
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "อ่านข้อมูลจากสมุดงาน Excel ใน Aspose.Slides ด้วย API ExcelDataWorkbook โหลดแผ่นงานและเซลล์และใช้ค่าต่างๆ เพื่อสร้างงานนำเสนอ PowerPoint ที่ขับเคลื่อนด้วยข้อมูล"
---
## **คำนำ**

งานนำเสนอ PowerPoint เป็นวิธีที่มีประสิทธิภาพในการแสดงและสื่อสารข้อมูล โดยมักใช้ร่วมกับสมุดงาน Excel ซึ่ง Excel ทำหน้าที่เป็นแหล่งข้อมูลเชิงโครงสร้างที่ยอดเยี่ยมและ PowerPoint มีความสามารถในการสื่อภาพข้อมูลนั้นต่อผู้ฟัง

มีหลายสถานการณ์ที่การผสานรวม Excel กับ PowerPoint เป็นสิ่งจำเป็น เช่น การทำเมลเมิร์จ, การเติมข้อมูลในตาราง, การสร้างสไลด์หนึ่งสไลด์ต่อหนึ่งบันทึกข้อมูล (การสร้างสไลด์เป็นชุด), การจัดทำสื่อการฝึกอบรม, และการรวมหลายรายงาน Excel ให้เป็นงานนำเสนอเดียว เป็นต้น

จนถึงตอนนี้ การทำฟีเจอร์เหล่านี้ด้วย Aspose.Slides API จำเป็นต้องพึ่งพาโซลูชันของบุคคลที่สามอย่าง Aspose.Cells แม้ว่เครื่องมือเหล่านี้จะมีความแข็งแกร่ง แต่ก็อาจซับซ้อนและมีค่าใช้จ่ายสูงเกินไปสำหรับผู้ใช้ที่ต้องการเพียงการรวมข้อมูลพื้นฐาน

## **วิธีการทำงาน**

เพื่อทำให้การทำงานกับข้อมูล Excel ง่ายและราบรื่นยิ่งขึ้น Aspose.Slides ได้แนะนำคลาสใหม่สำหรับการอ่านข้อมูลจากสมุดงาน Excel และนำเนื้อหาเข้ามาในงานนำเสนอ ฟีเจอร์นี้เปิดโอกาสใหม่ที่มีความสามารถสำหรับผู้ใช้ API ที่ต้องการใช้ Excel เป็นแหล่งข้อมูลในกระบวนการทำงานของงานนำเสนอ

ฟังก์ชันใหม่ออกแบบมาสำหรับการเข้าถึงข้อมูลทั่วไปและไม่ได้รวมเข้ากับ Presentation Document Object Model (DOM) ซึ่งหมายความว่า *ไม่สามารถแก้ไขหรือบันทึกไฟล์ Excel* ได้ — จุดประสงค์เดียวของมันคือเปิดสมุดงานและนำทางผ่านเนื้อหาเพื่อดึงข้อมูลเซลล์

ที่แกนหลักของฟีเจอร์นี้คือคลาสใหม่ [ExcelDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.excel/exceldataworkbook/) คลาสนี้ช่วยให้คุณโหลดสมุดงาน Excel จากไฟล์ในเครื่องหรือสตรีม เมื่อโหลดแล้วจะมีเมธอด [GetCell](https://reference.aspose.com/slides/th/net/aspose.slides.excel/exceldataworkbook/getcell/) ที่มีการโอเวอร์โหลดหลายรูปแบบ ที่คุณสามารถใช้ดึงเซลล์เฉพาะตามตำแหน่ง (เช่น ดัชนีแถวและคอลัมน์หรือช่วงที่ตั้งชื่อไว้)

การเรียกแต่ละครั้งของ [GetCell](https://reference.aspose.com/slides/th/net/aspose.slides.excel/exceldataworkbook/getcell/) จะส่งคืนอ็อบเจ็กต์แบบ [ExcelDataCell](https://reference.aspose.com/slides/th/net/aspose.slides.excel/exceldatacell/) ซึ่งเป็นตัวแทนของเซลล์เดียวในสมุดงาน Excel และให้คุณเข้าถึงค่าของมันอย่างง่ายและเป็นธรรมชาติ

#### **นำเข้าแผนภูมิ Excel**

ขั้นตอนต่อไปเพื่อขยายฟังก์ชันคือคลาส [ExcelWorkbookImporter](https://reference.aspose.com/slides/th/net/aspose.slides.import/excelworkbookimporter/) คลาสยูทิลิตี้นี้ให้ความสามารถในการนำเข้าเนื้อหาจากสมุดงาน Excel ไปยังงานนำเสนอ มีเมธอด [AddChartFromWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) ที่มีการโอเวอร์โหลดหลายรูปแบบ ช่วยให้คุณดึงแผนภูมิที่เลือกจากสมุดงาน Excel ที่ระบุและเพิ่มลงในคอลเลกชันรูปทรงที่ให้ไว้ที่พิกัดที่กำหนด

#### **นำเข้าตาราง Excel**

คลาส [ExcelWorkbookImporter](https://reference.aspose.com/slides/th/net/aspose.slides.import/excelworkbookimporter/) ยังมีเมธอด [AddTableFromWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/) ที่มีการโอเวอร์โหลดหลายรูปแบบ วิธีเหล่านี้ทำให้คุณสามารถนำเข้าช่วงเซลล์ที่ระบุจากแผ่นงานที่ระบุและเพิ่มเป็นตารางลงในคอลเลกชันรูปทรงที่ให้ไว้ที่พิกัดที่กำหนด

สรุปง่ายๆ คือ API ที่เบาและง่ายต่อการอ่านข้อมูล Excel — ตรงตามความต้องการของนักพัฒนาหลายคนโดยไม่ต้องพึ่งพาห้องสมุดการประมวลผลสเปรดชีตเต็มรูปแบบ

## **มาดูโค้ดกัน**

### **ตัวอย่างสถานการณ์เมลเมิร์จ**

ในตัวอย่างต่อไปนี้ เราจะทำการประยุกต์ใช้สถานการณ์เมลเมิร์จอย่างง่ายโดยสร้างงานนำเสนอหลายไฟล์จากข้อมูลที่เก็บไว้ในสมุดงาน Excel

เพื่อเริ่มต้น เราต้องการสองสิ่ง:
1. สมุดงาน Excel ที่มีข้อมูล

![ตัวอย่างข้อมูล Excel](example1_image0.png)

2. เทมเพลตงานนำเสนอ PowerPoint

![ตัวอย่างเทมเพลต PowerPoint](example1_image1.png)

```csharp
// โหลดสมุดงาน Excel ที่มีข้อมูลพนักงาน.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// โหลดเทมเพลตงานนำเสนอ.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// วนลูปผ่านแถวของ Excel (ยกเว้นหัวตารางที่แถว 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // สร้างงานนำเสนอใหม่สำหรับแต่ละบันทึกพนักงาน.
    using Presentation employeePresentation = new Presentation();

    // ลบสไลด์เปล่าเริ่มต้น.
    employeePresentation.Slides.RemoveAt(0);

    // คัดลอกสไลด์เทมเพลตไปยังงานนำเสนอใหม่.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // ดึงย่อหน้าจากรูปร่างเป้าหมาย (สมมติว่ารูปร่างที่ 1 ถูกใช้).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // แทนที่ตัวแปรตำแหน่งด้วยข้อมูลจาก Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // บันทึกงานนำเสนอที่ปรับให้เป็นส่วนตัวเป็นไฟล์แยก.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![ผลลัพธ์](example1_image2.png)

### **ตัวอย่างตาราง Excel**

ในตัวอย่างที่สอง เราเพียงคัดลอกข้อมูลจากตาราง Excel แล้วแสดงบนสไลด์ PowerPoint ในรูปแบบที่ดูสวยงามยิ่งขึ้น

ในตัวอย่างนี้ เราใช้สมุดงาน Excel เดียวกันจากตัวอย่างแรก ซึ่งมีตารางพนักงานอย่างง่าย

```csharp
// โหลดสมุดงาน Excel ที่มีข้อมูลพนักงาน.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// สร้างงานนำเสนอ PowerPoint ใหม่.
using Presentation presentation = new Presentation();

// เพิ่มรูปร่างตารางไปยังสไลด์แรก.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// เติมข้อมูลจากสมุดงาน Excel ลงในตาราง PowerPoint.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// บันทึกงานนำเสนอที่ได้เป็นไฟล์.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![ผลลัพธ์](example2_image0.png)

### **ตัวอย่างการนำเข้าแผนภูมิ Excel**

ในตัวอย่างนี้ เรานำเข้าแผนภูมิจากแผ่นงานแรกของสมุดงาน Excel ที่ใช้ในตัวอย่างก่อนหน้า แผนภูมินี้จะเชื่อมโยงกับสมุดงานภายนอกในงานนำเสนอที่ได้

ขั้นแรก เราเพิ่มแผนภูมิวงกลมลงในสมุดงาน Excel โดยอิงจากตารางพนักงาน

![ตัวอย่างแผนภูมิ Excel](example3_image0.png)

```csharp
// สร้างงานนำเสนอ PowerPoint ใหม่.
using Presentation presentation = new Presentation();

// ดึงคอลเลกชันรูปร่างของสไลด์แรก.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// นำเข้าแผนภูมิชื่อ "Chart 1" จากแผ่นแรกของสมุดงานและเพิ่มลงในคอลเลกชันรูปร่าง.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// บันทึกงานนำเสนอที่ได้เป็นไฟล์.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![ผลลัพธ์](example3_image1.png)

### **ตัวอย่างการนำเข้าทุกแผนภูมิ Excel**

ลองนึกว่าคุณมีสมุดงาน Excel ที่เต็มไปด้วยแผนภูมิและต้องการนำเข้าทั้งหมดเข้าสู่งานนำเสนอ แต่ละแผนภูมิควรอยู่บนสไลด์ใหม่

โค้ดต่อไปนี้จะวนผ่านทุกแผ่นงานในไฟล์ Excel ต้นทาง ดึงแผนภูมิจากแต่ละแผ่นงาน และเพิ่มแต่ละแผนภูมิลงในสไลด์แยกโดยใช้เค้าโครงสไลด์เปล่า ในงานนำเสนอที่ได้จะฝังเฉพาะข้อมูลแผนภูมิ ไม่ใช่สมุดงานทั้งหมด

```csharp
// โหลดสมุดงาน Excel ที่มีข้อมูลพนักงาน.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// สร้างงานนำเสนอ PowerPoint ใหม่.
using Presentation presentation = new Presentation();

// ดึงเค้าโครงสไลด์เปล่า.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// ดึงชื่อของทุกแผ่นงานที่อยู่ในสมุดงาน Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // ดึงพจนานุกรมที่แมปดัชนีแผนภูมิเป็นชื่อแผนภูมิสำหรับแผ่นงาน.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // เพิ่มสไลด์ใหม่โดยใช้เค้าโครงเปล่า.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // นำเข้าแผนภูมิที่ระบุจากสมุดงาน Excel ไปยังคอลเลกชันรูปร่างของสไลด์.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// บันทึกงานนำเสนอที่ได้เป็นไฟล์.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **ตัวอย่างการนำเข้าตาราง Excel**

ในตัวอย่างนี้ เรานำเข้าตารางที่จัดรูปแบบจากแผ่นงาน Excel โดยตรงเข้าสู่การนำเสนอ PowerPoint

แผ่นงาน Excel ต้นทางมีตารางที่จัดรูปแบบพร้อมข้อมูลพนักงาน:

![ตัวอย่างตาราง Excel](example4_image0.png)

```csharp
// สร้างงานนำเสนอ PowerPoint ใหม่.
using Presentation presentation = new Presentation();

// ดึงคอลเลกชันรูปร่างของสไลด์แรก.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// นำเข้าตารางจากแผ่นแรกของสมุดงานและเพิ่มลงในคอลเลกชันรูปร่าง.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// บันทึกงานนำเสนอที่ได้เป็นไฟล์.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![ผลลัพธ์](example4_image1.png)

## **สรุป**

กลไกนี้ซึ่งพร้อมใช้งานโดยตรงใน Aspose.Slides ทำให้การทำงานกับข้อมูล Excel และการนำเสนอรวมอยู่ในที่เดียว ช่วยให้คุณสร้างสไลด์พร้อมแผนภูมิแบบภาพและข้อมูลที่แสดงเป็นตาราง Excel — โดยไม่ต้องใช้ไลบรารีเพิ่มเติมหรือการบูรณาการที่ซับซ้อน