---
title: จัดการเวิร์กบุ๊คแผนภูมิในงานนำเสนอด้วย C++
linktitle: เวิร์กบุ๊คแผนภูมิ
type: docs
weight: 70
url: /th/cpp/chart-workbook/
keywords:
- เวิร์กบุ๊คแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์เวิร์กบุ๊ค
- ป้ายข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- เวิร์กบุ๊คภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนเวิร์กบุ๊ค
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ C++: จัดการเวิร์กบุ๊คแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อทำให้ข้อมูลการนำเสนอของคุณเป็นระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับเวิร์กบุ๊คแผนภูมิใน Aspose.Slides โดยแสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของเวิร์กบุ๊ค ใช้เซลล์ของเวิร์กบุ๊คเป็นป้ายชื่อข้อมูลแผนภูมิ เข้าถึงคอลเลกชันแผ่นงาน และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

ยังครอบคลุมการทำงานกับเวิร์กบุ๊คภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีการสร้างและกำหนดเวิร์กบุ๊คภายนอก ดึงเส้นทางของเวิร์กบุ๊คภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อเวิร์กบุ๊คพร้อมใช้งาน

สำหรับเซลล์เวิร์กบุ๊คที่แสดงข้อมูลที่หายไป ดูที่ [ควบคุมการแสดงเซลล์ว่าง](/slides/th/cpp/chart-series/) เพื่อเปรียบเทียบความแตกต่างระหว่างเซลล์ว่างกับศูนย์ และเปรียบเทียบโหมดการแสดงผลของแผนภูมิเส้น

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อน**

ใช้[IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/)เพื่อควบคุมว่าแผนภูมิจะพล็อตข้อมูลจากแถวและคอลัมน์ของแผ่นงานที่ซ่อนหรือไม่ ตั้งค่าเป็น`true`เพื่อพล็อตเฉพาะเซลล์ที่มองเห็นได้ หรือ `false`เพื่อรวมทั้งเซลล์ที่มองเห็นและซ่อน การตั้งค่านี้ควบคุมการพล็อตของแผนภูมิเท่านั้น ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของแผ่นงาน

ดาวน์โหลด[hidden-source-data.pptx](hidden-source-data.pptx)และวางไว้ในไดเรกทอรีทำงาน สไลด์แรกมีแผนภูมิคอลัมน์เป็นรูปทรงแรก แผ่นงานฝังรวม `Sheet1` มีช่วงข้อมูลต้นทาง `A1:C4` แถวที่ 3 และคอลัมน์ C ถูกซ่อน แต่เซลล์ยังคงมีค่า

| แถวเวิร์กชีต | A: เดือน | B: ขายปลีก | C: ขายส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวที่ซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์ต้นทางผ่าน[IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/)และอ่าน[IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/)เพื่อพิจารณาสถานะการซ่อนของเซลล์ คุณสมบัตินี้อ่านได้อย่างเดียว ในไฟล์นี้ B2 มองเห็นได้ B3 อยู่ในแถวที่ซ่อน และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างจะพิมพ์ `False`, `True`, และ `True` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการพล็อต: รักษาเวิร์กบุ๊คฝังรวมด้วย[ReadWorkbookStream](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/readworkbookstream/)และโหลดใหม่ด้วย[WriteWorkbookStream](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) เมื่อรวมทุกเซลล์ ให้ใช้[SetRange](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/setrange/)เพื่อกู้คืนช่วงทั้งหมดรวมถึงหมวดเดือนกุมภาพันธ์ที่ซ่อน การเปลี่ยนแฟล็กอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแผนภูมิที่แคชไว้และป้ายชื่อหมวดของตัวอย่างนี้

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <initializer_list>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"hidden-source-data.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    Console::WriteLine(u"B2 hidden: {0}", workbook->GetCell(0, u"B2")->get_IsHidden());
    Console::WriteLine(u"B3 hidden: {0}", workbook->GetCell(0, u"B3")->get_IsHidden());
    Console::WriteLine(u"C2 hidden: {0}", workbook->GetCell(0, u"C2")->get_IsHidden());

    auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
    for (auto visibleOnly : {true, false})
    {
        chart->set_PlotVisibleCellsOnly(visibleOnly);

        // รีเฟรชข้อมูลแผนภูมิจากเวิร์กบุ๊คที่ฝังรวม.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // กู้คืนช่วงต้นทางเต็มรวมถึงหมวดที่ซ่อน.
            chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$C$4");
        }

        auto outputPath = visibleOnly ? u"hidden_cells_True.pptx" : u"hidden_cells_False.pptx";
        presentation->Save(outputPath, Export::SaveFormat::Pptx);
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

ตัวอย่างบันทึก `hidden_cells_True.pptx` โดยมีค่า Retail ที่มองเห็นเท่านั้น (10 และ 20) และ `hidden_cells_False.pptx` โดยมีค่าทั้งหกค่า รูปภาพด้านล่างแสดงสองโหมดการพล็อต แถวที่ 3 และคอลัมน์ C ยังคงซ่อนอยู่ในทั้งสองเวิร์กบุ๊คฝังรวม

| เฉพาะเซลล์ที่มองเห็น (`true`) | ทุกเซลล์ (`false`) |
| --- | --- |
| ![เฉพาะเซลล์ที่มองเห็น: ค่าขายปลีก 10 และ 20 สำหรับเดือนมกราคมและมีนาคม.](hidden_cells_True.png) | ![ทุกเซลล์: ค่าขายปลีกและขายส่งสำหรับเดือนมกราคม, กุมภาพันธ์, และมีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนซึ่งมีค่าแตกต่างจากเซลล์ว่าง[IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/get_displayblanksas/)ควบคุมวิธีการแสดงค่าที่หายไป; มันไม่ได้รวมหรือยกเว้นข้อมูลต้นทางที่ซ่อน ดูที่[ควบคุมการแสดงเซลล์ว่าง](/slides/th/cpp/chart-series/#control-the-display-of-empty-cells)สำหรับตัวอย่าง

## **อ่านและเขียนข้อมูลแผนภูมิจากเวิร์กบุ๊ค**

Aspose.Slides for C++ มีเมธอด[ReadWorkbookStream](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/readworkbookstream/)และ[WriteWorkbookStream](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/)ที่ให้คุณอ่านและเขียนเวิร์กบุ๊คข้อมูลแผนภูมิ (ซึ่งอาจแก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดระเบียบในลักษณะเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งต้นทาง

ตัวอย่างนี้เปิด `chart.pptx` ซึ่งต้องมีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรก มันอ่านเวิร์กบุ๊คฝังรวมเข้าสตรีม ลบชุดข้อมูลและหมวดหมู่ที่มีอยู่ และเขียนเวิร์กบุ๊คเดิมกลับไป การเปลี่ยนแปลงยังคงอยู่ในหน่วยความจำ ตัวอย่างไม่ได้บันทึกงานนำเสนอ

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **ตรวจสอบเค้าโครงแผนภูมิหลังการแก้ไขเวิร์กบุ๊ค**

เมื่อคุณแทนที่เวิร์กบุ๊คฝังรวมด้วยเวิร์กบุ๊คที่แก้ไขแล้ว แผนภูมิจะยังคงรักษาชุดข้อมูลและคอลเลกชันหมวดเดิม ความไม่ตรงกันนี้อาจทำให้[IChart::ValidateChartLayout](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/validatechartlayout/)ล้มเหลวด้วยข้อผิดพลาดดัชนีอยู่นอกช่วง ก่อนเขียนเวิร์กบุ๊คที่อัปเดตกลับไปยังแผนภูมิ ให้ลบชุดข้อมูลและหมวดเดิมออก ตัวอย่างนี้ต้องการ `chart.pptx` ที่มีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรก คอมเมนต์ระบุจุดที่การแก้ไขเวิร์กบุ๊คจะเกิดขึ้น; ตัวอย่างที่ทำงานได้จะเขียนเวิร์กบุ๊คเดิมกลับและตรวจสอบเค้าโครงในหน่วยความจำ

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    // แก้ไขสตรีมเวิร์กบุ๊คที่นี่, ตัวอย่างเช่น, ด้วย Aspose.Cells.

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
    chart->ValidateChartLayout();
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

การลบคอลเลกชันจะทำให้การอ้างอิงข้อมูลล้าสมัยถูกตัดออกก่อนที่เวิร์กบุ๊คจะถูกเขียนกลับ ให้สร้างชุดข้อมูลและการแมปหมวดใหม่ตามที่ต้องการสำหรับเวิร์กบุ๊คที่อัปเดตก่อนใช้แผนภูมิ

## **ตั้งค่าเซลล์เวิร์กบุ๊คเป็นป้ายข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์เวิร์กบุ๊คเป็นป้ายข้อมูลแผนภูมิ ขั้นตอนต่อไปนี้แสดงวิธีการเชื่อมป้ายในแผนภูมิบับเบิลกับเซลล์ในเวิร์กบุ๊คข้อมูลของมัน

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. เข้าถึงสไลด์แรกด้วยดัชนีที่เริ่มจากศูนย์  
3. เพิ่มแผนภูมิบับเบิลด้วยข้อมูลเริ่มต้น  
4. เข้าถึงชุดข้อมูลของแผนภูมิ  
5. ตั้งค่าเซลล์เวิร์กบุ๊คเป็นป้ายข้อมูล  
6. บันทึกงานนำเสนอ

ตัวอย่างนี้เปิด `chart2.pptx` ซึ่งต้องมีอย่างน้อยหนึ่งสไลด์ และเพิ่มแผนภูมิบับเบิลด้วยข้อมูลเริ่มต้น ใช้เซลล์ A10:A12 ในแผ่นงาน 0 สำหรับป้ายสามอันแรกของชุดข้อมูลแรก เปิดใช้งานป้ายจากเซลล์ และบันทึกผลลัพธ์เป็น `resultchart.pptx`

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart2.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Bubble, 50, 50, 600, 400, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);
auto firstLabelCell = workbook->GetCell(0, u"A10", ObjectExt::Box<String>(u"Label 0 cell value"));
auto secondLabelCell = workbook->GetCell(0, u"A11", ObjectExt::Box<String>(u"Label 1 cell value"));
auto thirdLabelCell = workbook->GetCell(0, u"A12", ObjectExt::Box<String>(u"Label 2 cell value"));
series->get_Labels()->idx_get(0)->set_ValueFromCell(firstLabelCell);
series->get_Labels()->idx_get(1)->set_ValueFromCell(secondLabelCell);
series->get_Labels()->idx_get(2)->set_ValueFromCell(thirdLabelCell);

presentation->Save(u"resultchart.pptx", Export::SaveFormat::Pptx);
```

## **จัดการแผ่นงาน**

เมธอด[IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/)ให้เข้าถึงแผ่นงานในเวิร์กบุ๊คแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิพายด้วยข้อมูลเริ่มต้นและพิมพ์ชื่อแผ่นงานแต่ละชื่อลงคอนโซล

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 500);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

for (auto i = 0; i < workbook->get_Worksheets()->get_Count(); i++)
{
    Console::WriteLine(workbook->get_Worksheets()->idx_get(i)->get_Name());
}
```

## **ระบุประเภทแหล่งข้อมูล**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติด้วยข้อมูลเริ่มต้นและตั้งชื่อชุดข้อมูลสองชุดโดยใช้แหล่งข้อมูลที่ต่างกัน ชื่อแรกใช้สตริงลิเทอรัล; ชื่อที่สองใช้เซลล์ C1 ในแผ่นงาน 0 ค่าตัวเลข[DataSourceType](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/datasourcetype/)เลือกแหล่งข้อมูลสำหรับแต่ละชื่อ ผลลัพธ์บันทึกเป็น `pres.pptx`

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 600, 400, true);
auto literalName = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

literalName->set_DataSourceType(DataSourceType::StringLiterals);
literalName->set_Data(ObjectExt::Box<String>(u"LiteralString"));

auto cellName = chart->get_ChartData()->get_Series()->idx_get(1)->get_Name();
auto nameCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, u"C1", ObjectExt::Box<String>(u"NewCell"));
cellName->set_DataSourceType(DataSourceType::Worksheet);
cellName->set_Data(nameCell);

presentation->Save(u"pres.pptx", Export::SaveFormat::Pptx);
```

## **ตรวจจับรูปแบบเวิร์กบุ๊คที่ฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบเวิร์กบุ๊ค Excel แบบไบนารี (.xlsb) ที่อาจฝังในบางแผนภูมิ คุณสามารถใช้เมธอด[IChartData::get_EmbeddedWorkbookType](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/)ร่วมกับ[WorkbookType](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/workbooktype/)เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมนั้น ตัวอย่างนี้ตรวจสอบรูปร่างบนสไลด์แรกของ `sample.pptx` ข้ามรูปร่างที่ไม่ใช่แผนภูมิ และพิมพ์ข้อความวินิจฉัยสำหรับแผนภูมิแต่ละอันที่มีเวิร์กบุ๊ค .xlsb ฝัง

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto shape : IterateOver(slide->get_Shapes()))
{
    auto chart = AsCast<IChart>(shape);
    if (chart == nullptr)
    {
        continue;
    }

    auto chartData = chart->get_ChartData();
    auto isInternalWorkbook = chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook;
    auto isBinaryMacro = chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console::WriteLine(u"Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊คแผนภูมิที่รองรับที่นี่.
}
```

## **เวิร์กบุ๊คภายนอก**

Aspose.Slides รองรับการใช้เวิร์กบุ๊คภายนอกเป็นแหล่งข้อมูลของแผนภูมิ

### **สร้างเวิร์กบุ๊คภายนอก**

ใช้[ReadWorkbookStream](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/readworkbookstream/)และ[SetExternalWorkbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/)เพื่อส่งออกเวิร์กบุ๊คแผนภูมิที่ฝังรวมเป็นไฟล์และเชื่อมแผนภูมิไปยังเวิร์กบุ๊คภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิพายด้วยข้อมูลเริ่มต้น เขียนเวิร์กบุ๊คเป็น `externalWorkbook1.xlsx` และปิดสตรีมออกก่อนกำหนดไฟล์เป็นแหล่งข้อมูลของแผนภูมิ งานนำเสนอที่เชื่อมโยงจะถูกบันทึกเป็น `externalWorkbook.pptx`

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600);
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook1.xlsx");
auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
auto fileStream = IO::File::Create(workbookPath);
workbookStream->CopyTo(fileStream);
fileStream->Close();

chart->get_ChartData()->SetExternalWorkbook(workbookPath);
presentation->Save(u"externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

### **กำหนดเวิร์กบุ๊คภายนอก**

โดยใช้เมธอด[SetExternalWorkbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/)คุณสามารถกำหนดเวิร์กบุ๊คภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้เมธอดนี้ยังใช้เพื่ออัปเดตเส้นทางของเวิร์กบุ๊คภายนอก (หากไฟล์นั้นถูกย้าย)

แม้ว่าจะไม่สามารถแก้ไขข้อมูลในเวิร์กบุ๊คที่เก็บไว้ในตำแหน่งระยะไกลหรือทรัพยากรได้ คุณยังคงใช้เวิร์กบุ๊คเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางแบบสัมพัทธ์สำหรับเวิร์กบุ๊คภายนอก มันจะถูกแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ต้องการ `externalWorkbook.xlsx` อยู่ในไดเรกทอรีทำงาน แผ่นงานชื่อ `Sheet1` จะต้องมีชื่อชุดข้อมูลใน B1 ชื่อหมวดใน A2:A4 และค่าเชิงตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิพาย เชื่อมเวิร์กบุ๊ค และใช้[SetRange](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/setrange/)เพื่อแมป A1:B4 เป็นหนึ่งชุดข้อมูลและสามหมวด ผลลัพธ์บันทึกเป็น `Presentation_with_externalWorkbook.pptx`

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);
auto chartData = chart->get_ChartData();
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook.xlsx");

chartData->SetExternalWorkbook(workbookPath);
chartData->SetRange(u"Sheet1!$A$1:$B$4");

presentation->Save(u"Presentation_with_externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

พารามิเตอร์`updateChartData`ของ[SetExternalWorkbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/)ควบคุมว่าจะโหลดเวิร์กบุ๊คหรือไม่

* เมื่อ`updateChartData`เป็น`false` จะอัปเดตเฉพาะเส้นทางของเวิร์กบุ๊ค เท่านั้น ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากเวิร์กบุ๊คเป้าหมาย ดังนั้นเวิร์กบุ๊คอาจไม่มีอยู่  
* เมื่อ`updateChartData`เป็น`true` ข้อมูลแผนภูมิจะถูกอัปเดตจากเวิร์กบุ๊คเป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวแทนพร้อม`updateChartData`เป็น`false` มันยังคงรักษาข้อมูลเริ่มต้นของแผนภูมิพายและบันทึกงานนำเสนอโดยไม่โหลดเวิร์กบุ๊คที่ไม่มีอยู่

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);

chart->get_ChartData()->SetExternalWorkbook(u"https://example.com/unavailable-workbook.xlsx", false);
presentation->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", Export::SaveFormat::Pptx);
```

### **รับเส้นทางเวิร์กบุ๊คแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุเวิร์กบุ๊คที่เชื่อมโยงกับแผนภูมิ ให้ตรวจสอบว่ามีการใช้แหล่งข้อมูลภายนอกหรือไม่ หากมี ให้ดึงเส้นทางเวิร์กบุ๊คตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส[Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. เข้าถึงสไลด์แรกด้วยดัชนีที่เริ่มจากศูนย์  
3. ตรวจสอบว่ารูปร่างแรกเป็นแผนภูมิหรือไม่  
4. อ่านประเภทแหล่งข้อมูลของแผนภูมิ  
5. หากเป็นเวิร์กบุ๊คภายนอก ให้อ่านเส้นทางของมัน

ตัวอย่างนี้เปิด `externalWorkbook.pptx` ที่สร้างในตัวอย่างก่อนหน้าและตรวจสอบรูปร่างแรกบนสไลด์แรก หากมันเป็นแผนภูมิที่เชื่อมกับเวิร์กบุ๊คภายนอก ตัวอย่างจะพิมพ์[get_ExternalWorkbookPath](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/)ไปยังคอนโซล จากนั้นบันทึกสำเนาของงานนำเสนอเป็น `Result.pptx`

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"externalWorkbook.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    if (chartData->get_DataSourceType() == ChartDataSourceType::ExternalWorkbook)
    {
        Console::WriteLine(chartData->get_ExternalWorkbookPath());
    }
    else
    {
        Console::WriteLine(u"The chart does not use an external workbook.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}

presentation->Save(u"Result.pptx", Export::SaveFormat::Pptx);
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในเวิร์กบุ๊คภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาของเวิร์กบุ๊คภายใน หากเวิร์กบุ๊คภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ต้องการ `presentation.pptx` ที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรกและเวิร์กบุ๊คภายนอกที่เข้าถึงได้ มันตั้งค่าค่าที่รองรับจากเซลล์ของจุดข้อมูลแรกในชุดข้อมูลแรกเป็น 100 และบันทึกงานนำเสนอเป็น `presentation_out.pptx` การแก้ไขค่าจากเซลล์อาจอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยง จึงควรใช้สำเนาเมื่อต้องการเก็บเวิร์กบุ๊คต้นฉบับไว้

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto series = chart->get_ChartData()->get_Series();
    if (series->get_Count() > 0 && series->idx_get(0)->get_DataPoints()->get_Count() > 0)
    {
        auto valueCell = series->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell();
        if (valueCell != nullptr)
        {
            valueCell->set_Value(ObjectExt::Box<int32_t>(100));
            presentation->Save(u"presentation_out.pptx", Export::SaveFormat::Pptx);
        }
        else
        {
            Console::WriteLine(u"The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console::WriteLine(u"The chart has no data points to edit.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **กู้คืนเวิร์กบุ๊คจากแคชของแผนภูมิ**

หากแผนภูมิใช้เวิร์กบุ๊คภายนอกที่หายไปหรือไม่มีอยู่ Aspose.Slides สามารถสร้างเวิร์กบุ๊คแผนภูมิจากข้อมูลที่แคชในงานนำเสนอได้ สร้าง[LoadOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/) กำหนดค่าโดยใช้[set_SpreadsheetOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) และเรียก[ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/)เป็น`true`ก่อนเปิดงานนำเสนอ

ตัวอย่าง C++ ด้านล่างเปิด `presentation.pptx` โดยรูปร่างแรกบนสไลด์แรกต้องเป็นแผนภูมิที่อ้างอิงเวิร์กบุ๊คภายนอกที่ไม่มีอยู่ และเข้าถึงข้อมูลที่กู้คืนผ่าน[IChart::get_ChartData](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/get_chartdata/)และ[IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);
auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊คที่กู้คืนที่นี่.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

หากเวิร์กบุ๊คภายนอกไม่มีอยู่และการกู้คืนถูกปิดใช้งาน Aspose.Slides จะโยน[System::InvalidOperationException](https://reference.aspose.com/slides/th/cpp/system/details_invalidoperationexception/) ให้เปิดการกู้คืนเท่านั้นเมื่อการใช้ข้อมูลแคชของแผนภูมิเป็นวิธีสำรองที่ยอมรับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในเวิร์กบุ๊ครุ่นหลังจากที่งานนำเสนออัพเดตล่าสุด

## **คำถามที่พบบ่อย**

**ฉันสามารถตรวจสอบได้หรือไม่ว่าแผนภูมิใดเชื่อมโยงกับเวิร์กบุ๊คภายนอกหรือเวิร์กบุ๊คที่ฝังรวม?**

ได้ แผนภูมิมี[ประเภทแหล่งข้อมูล](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_datasourcetype/)และ[เส้นทางไปยังเวิร์กบุ๊คภายนอก](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) หากแหล่งเป็นเวิร์กบุ๊คภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าใช้ไฟล์ภายนอกหรือไม่

**รองรับเส้นทางแบบสัมพัทธ์ไปยังเวิร์กบุ๊คภายนอกหรือไม่ และเก็บอย่างไร?**

รองรับ หากคุณระบุเส้นทางแบบสัมพัทธ์ มันจะถูกแปลงเป็นเส้นทางเต็มอัตโนมัติ งานนำเสนอเก็บเส้นทางเต็มในไฟล์ PPTX ดังนั้นการย้ายเวิร์กบุ๊คอาจต้องอัปเดตลิงก์

**ฉันสามารถใช้เวิร์กบุ๊คที่อยู่บนทรัพยากร/แชร์เครือข่ายได้หรือไม่?**

ได้ เวิร์กบุ๊คเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขเวิร์กบุ๊คราวไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

งานนำเสนอเก็บ[ลิงก์ไปยังไฟล์ภายนอก](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) การแก้ไขข้อมูลแผนภูมิที่อิงจากเซลล์อาจอัปเดตไฟล์ XLSX ภายในเครื่องได้ ใช้สำเนาของเวิร์กบุ๊คหากต้องการให้ไฟล์ต้นฉบับไม่เปลี่ยนแปลง

**ควรทำอย่างไรหากไฟล์ภายนอกมีการป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้[Aspose.Cells](https://reference.aspose.com/cells/cpp/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงเวิร์กบุ๊คภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิเมื่อโหลดข้อมูลครั้งถัดไป