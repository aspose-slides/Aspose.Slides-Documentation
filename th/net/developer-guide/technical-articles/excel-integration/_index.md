---
title: รวมข้อมูล Excel เข้าไปในงานนำเสนอ PowerPoint
linktitle: การรวม Excel
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
description: "อ่านข้อมูลจากสมุดงาน Excel ใน Aspose.Slides ด้วย API ExcelDataWorkbook โหลดแผ่นงานและเซลล์และใช้ค่าที่ได้เพื่อสร้างงานนำเสนอ PowerPoint ที่ขับเคลื่อนด้วยข้อมูล"
---
## **บทนำ**

การนำเสนอ PowerPoint เป็นวิธีที่ทรงพลังในการแสดงและสื่อสารข้อมูล ซึ่งมักใช้ร่วมกับสมุดงาน Excel ซึ่ง Excel ทำหน้าที่เป็นแหล่งข้อมูลที่มีโครงสร้างยอดเยี่ยมและ PowerPoint มีความเชี่ยวชาญในการสร้างภาพข้อมูลเหล่านั้นสำหรับผู้ชม

มีสถานการณ์การใช้งานจริงหลายอย่างที่การรวม Excel กับ PowerPoint เป็นสิ่งจำเป็น เช่น การทำเมลเมิร์จ, การเติมข้อมูลลงในตาราง, การสร้างสไลด์หนึ่งสไลด์ต่อบรรทัดข้อมูล (การสร้างสไลด์แบบเป็นชุด), การสร้างสื่อการฝึกอบรม, และการรวมรายงาน Excel หลายฉบับเป็นงานนำเสนอเดียว เป็นต้น

จนถึงตอนนี้ การใช้งานคุณลักษณะเหล่านี้ด้วย Aspose.Slides API จำเป็นต้องพึ่งพาโซลูชันของบุคคลที่สามเช่น Aspose.Cells แม้ว่าจะเป็นเครื่องมือที่แข็งแรง แต่ก็อาจซับซ้อนและมีค่าใช้จ่ายสูงสำหรับผู้ใช้ที่ต้องการเพียงฟังก์ชันการรวมข้อมูลขั้นพื้นฐานเท่านั้น

## **วิธีการทำงาน**

เพื่อทำให้การทำงานกับข้อมูล Excel ง่ายและเป็นระบบมากขึ้น Aspose.Slides ได้แนะนำคลาสใหม่สำหรับอ่านข้อมูลจากสมุดงาน Excel และนำเข้าข้อมูลไปยังงานนำเสนอ คุณลักษณะนี้เปิดโอกาสใหม่ที่ทรงพลังสำหรับผู้ใช้ API ที่ต้องการใช้ Excel เป็นแหล่งข้อมูลในกระบวนการทำงานของงานนำเสนอ

ฟังก์ชันใหม่ถูกออกแบบมาเพื่อการเข้าถึงข้อมูลทั่วไปและไม่ได้ผนวกรวมเข้ากับ Presentation Document Object Model (DOM) ซึ่งหมายความว่า *ไม่อนุญาตให้แก้ไขหรือบันทึกไฟล์ Excel* — จุดประสงค์เดียวของมันคือการเปิดสมุดงานและนำทางผ่านเนื้อหาเพื่อดึงข้อมูลเซลล์

ใจกลางของคุณลักษณะนี้คือคลาสใหม่ [ExcelDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.excel/exceldataworkbook/) คลาสนี้ทำให้คุณสามารถโหลดสมุดงาน Excel จากไฟล์ในเครื่องหรือสตรีมได้ หลังจากโหลดแล้ว จะมีการให้โอเวอร์โหลดหลายรูปแบบของเมธอด [GetCell](https://reference.aspose.com/slides/th/net/aspose.slides.excel/exceldataworkbook/getcell/) ที่คุณสามารถใช้เพื่อดึงข้อมูลเซลล์เฉพาะตามตำแหน่งของมัน (เช่น ดัชนีแถวและคอลัมน์ หรือช่วงที่ตั้งชื่อไว้)

การเรียกใช้เมธอด [GetCell](https://reference.aspose.com/slides/th/net/aspose.slides.excel/exceldataworkbook/getcell/) แต่ละครั้งจะคืนค่าเป็นอินสแตนซ์ของคลาส [ExcelDataCell](https://reference.aspose.com/slides/th/net/aspose.slides.excel/exceldatacell/) วัตถุนี้แทนเซลล์เดียวในสมุดงาน Excel และให้คุณเข้าถึงค่าของเซลล์นั้นด้วยวิธีที่ง่ายและเป็นธรรมชาติ

#### **นำเข้าชาร์ต Excel**

ขั้นตอนต่อไปเพื่อขยายการทำงานคือคลาส [ExcelWorkbookImporter](https://reference.aspose.com/slides/th/net/aspose.slides.import/excelworkbookimporter/) คลาสยูทิลิตี้นี้ให้ฟังก์ชันการนำเข้าข้อมูลจากสมุดงาน Excel ไปยังงานนำเสนอ มีโอเวอร์โหลดหลายรูปแบบของเมธอด [AddChartFromWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) ที่ช่วยให้คุณดึงชาร์ตที่เลือกจากสมุดงาน Excel ที่ระบุและเพิ่มลงในตำแหน่งสุดท้ายของคอลเลกชันรูปร่างที่กำหนดตามพิกัดที่ระบุ

โดยสรุป นี่คือ API ที่เบาและเรียบง่ายสำหรับการอ่านข้อมูล Excel — ตรงกับความต้องการของนักพัฒนาหลายคนโดยไม่ต้องรับภาระของไลบรารีการประมวลผลสเปรดชีตเต็มรูปแบบ

## **มาเขียนโค้ดกัน**

### **ตัวอย่างสถานการณ์การทำเมลเมิร์จ**

ในตัวอย่างต่อไปนี้ เราจะทำการจำลองสถานการณ์เมลเมิร์จอย่างง่ายโดยการสร้างงานนำเสนอหลายชุดจากข้อมูลที่จัดเก็บในสมุดงาน Excel

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

// วนลูปผ่านแถวของ Excel (ยกเว้นส่วนหัวที่แถว 0).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // สร้างงานนำเสนอใหม่สำหรับแต่ละบันทึกพนักงาน.
    using Presentation employeePresentation = new Presentation();

    // ลบสไลด์เปล่าตั้งต้น.
    employeePresentation.Slides.RemoveAt(0);

    // คัดลอกสไลด์เทมเพลตไปยังงานนำเสนอใหม่.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // ดึงย่อหน้าจากรูปทรงเป้าหมาย (สมมติว่ารูปทรงที่ 1 ถูกใช้).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // แทนที่ตัวแปรตำแหน่งที่จัดเก็บข้อมูลด้วยข้อมูลจาก Excel.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // บันทึกงานนำเสนอส่วนบุคคลลงไฟล์แยก.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![ผลลัพธ์](example1_image2.png)

### **ตัวอย่างตาราง Excel**

ในตัวอย่างที่สอง เราเพียงคัดลอกข้อมูลจากตาราง Excel และแสดงบนสไลด์ PowerPoint ในรูปแบบที่ดูสวยงามยิ่งขึ้น

ในตัวอย่างนี้ เราใช้สมุดงาน Excel เดียวกันจากตัวอย่างแรกซึ่งมีตารางพนักงานอย่างง่าย

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

// บันทึกงานนำเสนอที่ได้ลงไฟล์.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![ผลลัพธ์](example2_image0.png)

### **ตัวอย่างการนำเข้าชาร์ต Excel**

ในตัวอย่างนี้ เรานำเข้าชาร์ตจากเวิร์กชีตแรกของสมุดงาน Excel ที่ใช้ในตัวอย่างก่อนหน้า ชาร์ตนี้จะเชื่อมโยงกับสมุดงานภายนอกในงานนำเสนอที่ได้

แรกสุด เราเพิ่มชาร์ตพายลงในสมุดงาน Excel โดยอิงจากตารางพนักงาน

![ตัวอย่างชาร์ต Excel](example3_image0.png)

```csharp
// สร้างงานนำเสนอ PowerPoint ใหม่.
using Presentation presentation = new Presentation();

// ดึงคอลเลกชันรูปทรงของสไลด์แรก.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// นำเข้าชาร์ตที่ชื่อ "Chart 1" จากแผ่นงานแรกของสมุดงานและเพิ่มไปยังคอลเลกชันรูปทรง.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// บันทึกงานนำเสนอที่ได้ลงไฟล์.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![ผลลัพธ์](example3_image1.png)

### **ตัวอย่างการนำเข้าชาร์ต Excel ทั้งหมด**

ลองนึกว่าคุณมีสมุดงาน Excel ที่เต็มไปด้วยชาร์ตและต้องการนำเข้าทั้งหมดเข้าสู่การนำเสนอ ชาร์ตแต่ละชาร์ตควรจัดวางบนสไลด์ใหม่

โค้ดต่อไปนี้วนลูปผ่านเวิร์กชีตทั้งหมดในไฟล์ Excel ต้นฉบับ ดึงชาร์ตจากแต่ละเวิร์กชีตและเพิ่มชาร์ตแต่ละชาร์ตไปยังสไลด์แยกโดยใช้เลย์เอาต์สไลด์เปล่า ในงานนำเสนอที่ได้ จะฝังเฉพาะข้อมูลชาร์ตเท่านั้น ไม่ใช่สมุดงานทั้งหมด

```csharp
// โหลดสมุดงาน Excel ที่มีข้อมูลพนักงาน.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// สร้างงานนำเสนอ PowerPoint ใหม่.
using Presentation presentation = new Presentation();

// ดึงรูปแบบสไลด์เปล่า.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// ดึงชื่อของทุกแผ่นงานที่อยู่ในสมุดงาน Excel.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // ดึงพจนานุกรมที่แมพดัชนีชาร์ตกับชื่อชาร์ตสำหรับแผ่นงานนั้น.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // เพิ่มสไลด์ใหม่โดยใช้รูปแบบเปล่า.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // นำเข้าชาร์ตที่ระบุจากสมุดงาน Excel ไปยังคอลเลกชันรูปทรงของสไลด์.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// บันทึกงานนำเสนอที่ได้ลงไฟล์.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

## **สรุป**

กลไกนี้ซึ่งมีให้โดยตรงใน Aspose.Slides ทำให้การทำงานกับข้อมูล Excel และงานนำเสนอเป็นหนึ่งเดียว คุณสามารถสร้างสไลด์ที่มีชาร์ตภาพและข้อมูลที่นำเสนอในรูปแบบตาราง Excel ได้โดยไม่ต้องใช้ไลบรารีเพิ่มเติมหรือการบูรณาการที่ซับซ้อน