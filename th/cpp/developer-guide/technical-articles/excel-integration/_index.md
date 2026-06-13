---
title: ผสานข้อมูล Excel เข้าในพรีเซนเทชัน PowerPoint
linktitle: การบูรณาการ Excel
type: docs
weight: 330
url: /th/cpp/excel-integration/
keywords:
- Excel
- สมุดงาน
- อ่าน Excel
- บูรณาการ Excel
- แหล่งข้อมูล
- เมลเมิร์จ
- นำเข้าตาราง
- Excel ไปยัง PowerPoint
- PowerPoint
- พรีเซนเทชัน
- C++
- Aspose.Slides
description: "อ่านข้อมูลจากสมุดงาน Excel ใน Aspose.Slides โดยใช้ API ExcelDataWorkbook โหลดแผ่นงานและเซลล์และใช้ค่าต่าง ๆ เพื่อสร้างพรีเซนเทชัน PowerPoint ที่ขับเคลื่อนด้วยข้อมูล"
---
## **บทนำ**

งานพรีเซนเทชัน PowerPoint เป็นวิธีที่ทรงพลังในการแสดงและสื่อสารข้อมูล โดยมักใช้ร่วมกับไฟล์ Excel ซึ่ง Excel ทำหน้าที่เป็นแหล่งข้อมูลเชิงโครงสร้างที่ยอดเยี่ยม และ PowerPoint มีความเชี่ยวชาญในการแสดงภาพข้อมูลเหล่านั้นต่อผู้ชม

มีสถานการณ์การใช้งานจริงหลายแบบที่การผสาน Excel กับ PowerPoint เป็นสิ่งจำเป็น ได้แก่ การทำเมลเมิร์จ, การเติมข้อมูลในตาราง, การสร้างสไลด์หนึ่งสไลด์ต่อบันทึกข้อมูล (การสร้างสไลด์เป็นชุด), การสร้างเนื้อหาการฝึกอบรม, และการรวมหลายรายงาน Excel ให้เป็นพรีเซนเทชันเดียว เป็นต้น

จนถึงขณะนี้ การทำฟีเจอร์เหล่านี้ด้วย Aspose.Slides API จำเป็นต้องอ้างอิงโซลูชันจากบุคคลที่สามเช่น Aspose.Cells แม้ว่เครื่องมือเหล่านี้จะมีความแข็งแรง แต่ก็อาจซับซ้อนและมีค่าใช้จ่ายสูงสำหรับผู้ใช้ที่ต้องการเพียงการผสานข้อมูลพื้นฐานเท่านั้น

## **การทำงานของระบบ**

เพื่อทำให้การทำงานกับข้อมูล Excel ง่ายและเป็นระเบียบมากขึ้น Aspose.Slides ได้เปิดตัวคลาสใหม่สำหรับอ่านข้อมูลจากไฟล์ Excel และนำเข้าเนื้อหาเข้าสู่พรีเซนเทชัน ฟีเจอร์นี้เปิดโอกาสใหม่ที่ทรงพลังสำหรับผู้ใช้ API ที่ต้องการใช้ Excel เป็นแหล่งข้อมูลภายในกระบวนการทำพรีเซนเทชันของตน

ฟังก์ชันใหม่ออกแบบมาสำหรับการเข้าถึงข้อมูลทั่วไปและไม่ได้รวมอยู่ใน Presentation Document Object Model (DOM) ซึ่งหมายความว่า *ไม่อนุญาตให้แก้ไขหรือบันทึกไฟล์ Excel* จุดมุ่งหมายเพียงอย่างเดียวคือการเปิดไฟล์ workbook และนำทางผ่านเนื้อหาเพื่อดึงข้อมูลเซลล์

ที่หัวใจของฟีเจอร์นี้คือคลาสใหม่ [ExcelDataWorkbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.excel/exceldataworkbook/) คลาสนี้ช่วยให้คุณโหลดไฟล์ Excel จากไฟล์ในเครื่องหรือสตรีม เมื่อโหลดเสร็จจะมีเมธอด [GetCell](https://reference.aspose.com/slides/th/cpp/aspose.slides.excel/exceldataworkbook/getcell/) ที่มีหลายรูปแบบให้เลือกใช้เพื่อดึงเซลล์เฉพาะตามตำแหน่ง (เช่น ดัชนีแถวและคอลัมน์ หรือช่วงที่กำหนดชื่อ)

การเรียกใช้ [GetCell](https://reference.aspose.com/slides/th/cpp/aspose.slides.excel/exceldataworkbook/getcell/) แต่ละครั้งจะคืนอ็อบเจกต์ของคลาส [ExcelDataCell](https://reference.aspose.com/slides/th/cpp/aspose.slides.excel/exceldatacell/) ซึ่งเป็นตัวแทนของเซลล์เดียวในไฟล์ Excel และให้คุณเข้าถึงค่าของเซลล์อย่างง่ายและเป็นธรรมชาติ

#### **นำเข้าแผนภูมิ Excel**

ขั้นตอนต่อไปเพื่อขยายฟังก์ชัน คือคลาส [ExcelWorkbookImporter](https://reference.aspose.com/slides/th/cpp/aspose.slides.import/excelworkbookimporter/) คลาสยูทิลิตี้นี้ให้ความสามารถในการนำเข้าเนื้อหาจากไฟล์ Excel ไปยังพรีเซนเทชัน มีเมธอด [AddChartFromWorkbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) ที่มีหลายรูปแบบ ช่วยให้คุณดึงแผนภูมิที่เลือกจากไฟล์ Excel ที่ระบุและเพิ่มลงในส่วนท้ายของคอลเลกชันรูปทรงที่กำหนด ณ พิกัดที่ระบุ

โดยสรุป นี่คือ API ที่เบาและตรงประเด็นสำหรับการอ่านข้อมูล Excel — สิ่งที่นักพัฒนาหลายคนต้องการโดยไม่ต้องพึ่งพาไลบรารีประมวลผลสเปรดชีตเต็มรูปแบบ

## **มาเขียนโค้ดกัน**

### **ตัวอย่างสถานการณ์เมลเมิร์จ**

ในตัวอย่างต่อไปนี้ เราจะพัฒนาเหตุการณ์เมลเมิร์จอย่างง่ายโดยสร้างพรีเซนเทชันหลายไฟล์จากข้อมูลที่เก็บในไฟล์ Excel

เพื่อเริ่มต้น เราต้องการสองอย่าง:
1. ไฟล์ Excel ที่บรรจุข้อมูล

![ตัวอย่างข้อมูล Excel](example1_image0.png)

2. เทมเพลตพรีเซนเทชัน PowerPoint

![ตัวอย่างเทมเพลต PowerPoint](example1_image1.png)

```cpp
// โหลดไฟล์ Excel workbook ที่มีข้อมูลพนักงาน.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// โหลดเทมเพลตพรีเซนเทชัน.
auto templatePresentation = MakeObject<Presentation>(u"PresentationTemplate.pptx");

    // วนซ้ำผ่านแถวของ Excel (ยกเว้นหัวเรื่องที่แถว 0).
for (auto rowIndex = 1; rowIndex <= 4; rowIndex++) {

    // สร้างพรีเซนเทชันใหม่สำหรับแต่ละบันทึกพนักงาน.
    auto employeePresentation = MakeObject<Presentation>();

    // ลบสไลด์เปล่าที่กำหนดไว้โดยค่าเริ่มต้น.
    employeePresentation->get_Slides()->RemoveAt(0);

    // คัดลอกสไลด์เทมเพลตไปยังพรีเซนเทชันใหม่.
    auto slide = employeePresentation->get_Slides()->AddClone(templatePresentation->get_Slide(0));

    // รับพารากราฟจากรูปร่างเป้าหมาย (สมมติว่าใช้รูปร่างที่ดัชนี 1).
    auto paragraphs = ExplicitCast<IAutoShape>(slide->get_Shape(1))->get_TextFrame()->get_Paragraphs();

    // แทนที่ข้อความแทนด้วยข้อมูลจาก Excel.
    auto employeeName = workbook->GetCell(worksheetIndex, rowIndex, 0)->get_Value()->ToString();
    auto namePortion = paragraphs->idx_get(0)->get_Portion(0);
    namePortion->set_Text(namePortion->get_Text().Replace(u"{{EmployeeName}}", employeeName));

    auto department = workbook->GetCell(worksheetIndex, rowIndex, 1)->get_Value()->ToString();
    auto departmentPortion = paragraphs->idx_get(1)->get_Portion(0);
    departmentPortion->set_Text(departmentPortion->get_Text().Replace(u"{{Department}}", department));

    auto yearsOfService = workbook->GetCell(worksheetIndex, rowIndex, 2)->get_Value()->ToString();
    auto yearsPortion = paragraphs->idx_get(2)->get_Portion(0);
    yearsPortion->set_Text(yearsPortion->get_Text().Replace(u"{{YearsOfService}}", yearsOfService));

    // บันทึกพรีเซนเทชันที่ปรับแต่งแล้วเป็นไฟล์แยก.
    employeePresentation->Save(String::Format(u"{0} Report.pptx", employeeName), SaveFormat::Pptx);
    employeePresentation->Dispose();
}

templatePresentation->Dispose();
```

![ผลลัพธ์](example1_image2.png)

### **ตัวอย่างตาราง Excel**

ในตัวอย่างที่สอง เราจะคัดลอกข้อมูลจากตาราง Excel แล้วแสดงบนสไลด์ PowerPoint ในรูปแบบที่ดูสวยงามมากขึ้น

ในตัวอย่างนี้ เราใช้ไฟล์ Excel เดียวกันจากตัวอย่างแรก ซึ่งมีตารางพนักงานอย่างง่าย

```cpp
// โหลดไฟล์ Excel workbook ที่มีข้อมูลพนักงาน.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// สร้างพรีเซนเทชัน PowerPoint ใหม่.
auto presentation = MakeObject<Presentation>();

// เพิ่มรูปร่างตารางไปยังสไลด์แรก.
auto table = presentation->get_Slide(0)->get_Shapes()->AddTable(
    50, 200,
    MakeArray<double>({200, 200, 200}),
    MakeArray<double>({30, 30, 30, 30, 30})
);

// เติมตาราง PowerPoint ด้วยข้อมูลจากไฟล์ Excel workbook.
for (auto rowIndex = 0; rowIndex < 5; rowIndex++) {
    for (auto columnIndex = 0; columnIndex < 3; columnIndex++) {
        auto cellValue = workbook->GetCell(worksheetIndex, rowIndex, columnIndex)->get_Value()->ToString();
        table->get_Column(columnIndex)->idx_get(rowIndex)->get_TextFrame()->set_Text(cellValue);
    }
}

// บันทึกพรีเซนเทชันที่ได้เป็นไฟล์.
presentation->Save(u"Table.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![ผลลัพธ์](example2_image0.png)

### **ตัวอย่างการนำเข้าแผนภูมิ Excel**

ในตัวอย่างนี้ เรานำเข้าแผนภูมิจากเวิร์กชีตแรกของไฟล์ Excel ที่ใช้ในตัวอย่างก่อนหน้า แผนภูมิจะแนบลิงก์ไปยังไฟล์ Excel ภายนอกในพรีเซนเทชันที่สร้างขึ้น

ขั้นแรก เราเพิ่มแผนภูมิวงกลมลงในไฟล์ Excel ตามตารางพนักงาน

![ตัวอย่างแผนภูมิ Excel](example3_image0.png)

```cpp
// สร้างพรีเซนเทชัน PowerPoint ใหม่.
auto presentation = MakeObject<Presentation>();

// ดึงคอลเลกชันรูปร่างของสไลด์แรก.
auto shapes = presentation->get_Slide(0)->get_Shapes();

// นำเข้าชาร์ตชื่อ "Chart 1" จากแผ่นแรกของ workbook และเพิ่มลงในคอลเลกชันรูปร่าง.
ExcelWorkbookImporter::AddChartFromWorkbook(shapes, 10.0, 10.0, u"TemplateData.xlsx", u"Sheet1", u"Chart 1", false);

// บันทึกพรีเซนเทชันที่ได้เป็นไฟล์.
presentation->Save(u"Chart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![ผลลัพธ์](example3_image1.png)

### **ตัวอย่างการนำเข้าทุกแผนภูมิ Excel**

ลองนึกว่าคุณมีไฟล์ Excel ที่เต็มไปด้วยแผนภูมิและต้องการนำเข้าทั้งหมดเข้าสู่พรีเซนเทชัน แต่ละแผนภูมิควรวางบนสไลด์ใหม่

โค้ดต่อไปนี้จะวนลูปผ่านทุกเวิร์กชีตในไฟล์ Excel ต้นทาง ดึงแผนภูมิจากแต่ละเวิร์กชีต และเพิ่มแผนภูมิแต่ละอันลงบนสไลด์แยกต่างหากโดยใช้เค้าโครงสไลด์เปล่า ในพรีเซนเทชันที่ได้ จะฝังเฉพาะข้อมูลแผนภูมิเท่านั้น ไม่ใช่ไฟล์ Excel ทั้งหมด

```cpp
// โหลดไฟล์ Excel workbook ที่มีข้อมูลพนักงาน.
auto workbook = MakeObject<ExcelDataWorkbook>(u"ExcelWithCharts.xlsx");

// สร้างพรีเซนเทชัน PowerPoint ใหม่.
auto presentation = MakeObject<Presentation>();

// ดึงเค้าโครงสไลด์เปล่า.
auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// ดึงชื่อของทุกแผ่นงานที่อยู่ในไฟล์ Excel workbook.
auto worksheetNames = workbook->GetWorksheetNames();

for (auto&& name : worksheetNames)
{
    // ดึงพจนานุกรมที่แมปดัชนีแผนภูมิกับชื่อแผนภูมิสำหรับแผ่นงานนี้.
    auto worksheetCharts = workbook->GetChartsFromWorksheet(name);

    for (auto&& chart : worksheetCharts)
    {
        // เพิ่มสไลด์ใหม่โดยใช้เค้าโครงเปล่า.
        auto slide = presentation->get_Slides()->AddEmptySlide(blankLayout);

        // นำเข้าชาร์ตที่ระบุจากไฟล์ Excel workbook ไปยังคอลเลกชันรูปร่างของสไลด์.
        ExcelWorkbookImporter::AddChartFromWorkbook(slide->get_Shapes(), 10.0, 10.0, workbook, name, chart.get_Key(), false);
    }
}

// บันทึกพรีเซนเทชันที่ได้เป็นไฟล์.
presentation->Save(u"Charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **สรุป**

กลไกนี้ที่ให้บริการโดยตรงใน Aspose.Slides ทำให้การทำงานกับข้อมูล Excel และพรีเซนเทชันอยู่ในที่เดียว ช่วยให้คุณสร้างสไลด์พร้อมแผนภูมิวิสวลและข้อมูลที่แสดงเป็นตาราง Excel — ไม่ต้องพึ่งไลบรารีเพิ่มเติมหรือการผสานซับซ้อนใด ๆ