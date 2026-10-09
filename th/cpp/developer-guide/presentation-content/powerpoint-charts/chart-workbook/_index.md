---
title: จัดการสมุดงานแผนภูมิในงานนำเสนอโดยใช้ C++
linktitle: สมุดงานแผนภูมิ
type: docs
weight: 70
url: /th/cpp/chart-workbook/
keywords:
- สมุดงานแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์สมุดงาน
- ป้ายกำกับข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- สมุดงานภายนอก
- ข้อมูลภายนอก
- แคชของแผนภูมิ
- การกู้คืนสมุดงาน
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ C++: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อทำให้ข้อมูลงานนำเสนอของคุณเป็นระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดงานแผนภูมิใน Aspose.Slides แสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของสมุดงาน ใช้เซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ เข้าถึงคอลเลกชันแผ่นงาน และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

บทความยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีสร้างและกำหนดสมุดงานภายนอก ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

สำหรับเซลล์สมุดงานที่แสดงข้อมูลที่หายไป ให้ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/cpp/chart-series/) เพื่อทำความเข้าใจความแตกต่างระหว่างเซลล์ว่างและศูนย์ และดูการเปรียบเทียบแผนภูมิเส้นของโหมดการแสดงผลที่มีให้เลือก

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่**

ใช้ [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) เพื่อควบคุมว่าผังแผนภูมิจะพล็อตข้อมูลจากแถวและคอลัมน์ของแผ่นงานที่ซ่อนอยู่หรือไม่ ตั้งค่าเป็น `true` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็นได้ หรือ `false` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อนอยู่ การตั้งค่านี้ควบคุมการพล็อตของแผนภูมิ ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของแผ่นงาน

[ตัวอย่างงานนำเสนอ](hidden-source-data.pptx) มีแผนภูมิกลับเป็นรูปแบบคอลัมน์เป็นรูปร่างแรกบนสไลด์แรก แผ่นงานฝังอยู่ `Sheet1` มีช่วงข้อมูลต้นฉบับ `A1:C4` แถวที่ 3 และคอลัมน์ C ถูกซ่อนอยู่ แต่เซลล์ของพวกมันยังคงมีค่า

| Worksheet row | A: Month | B: Retail | C: Wholesale (hidden column) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

เข้าถึงเซลล์ต้นฉบับผ่าน [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) และอ่าน [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) เพื่อตรวจสอบสถานะการซ่อนของเซลล์ คุณสมบัตินี้เป็นแบบอ่าน‑อย่างเดียว ในไฟล์นี้ B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างพิมพ์ค่า `False`, `True`, และ `True` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการพล็อต: รักษาสมุดงานฝังด้วย [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) แล้วโหลดใหม่ด้วย [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) เมื่อรวมทุกเซลล์ อย่าลืมใช้ [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) เพื่อคืนช่วงข้อมูลเต็มรวมถึงประเภทเดือนกุมภาพันธ์ที่ซ่อนอยู่ การเปลี่ยนค่าสถานะอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแผนภูมิและป้ายกำกับประเภทที่แคชไว้ในตัวอย่างนี้

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

        // รีเฟรชข้อมูลแผนภูมิจากสมุดงานที่ฝังอยู่.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // คืนช่วงข้อมูลต้นฉบับทั้งหมด รวมถึงประเภทที่ซ่อนอยู่.
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

ตัวอย่างบันทึกสองเวอร์ชันของงานนำเสนอ: เวอร์ชันแรกมีค่า Retail ที่มองเห็นได้เท่านั้น (10 และ 20) และเวอร์ชันที่สองมีค่าทั้งหกค่า รูปภาพด้านล่างแสดงสองโหมดการพล็อต แถวที่ 3 และคอลัมน์ C ยังคงซ่อนอยู่ในสมุดงานฝังทั้งสอง

| Only visible cells (`true`) | All cells (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ว่าง [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) ควบคุมวิธีการแสดงค่าที่ขาดหาย ไม่ได้รวมหรือยกเว้นข้อมูลต้นฉบับที่ซ่อน ดูที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/cpp/chart-series/#control-the-display-of-empty-cells) สำหรับตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนอัปเดตข้อมูลสมุดงานในงานนำเสนอที่มีอยู่ ให้ตรวจสอบช่วงต้นฉบับเพื่อระบุว่าแผ่นงานเซลล์ใดที่แต่ละแผนภูมิใช้ วิธีการ [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) จะคืนช่วงข้อมูลปัจจุบันในรูปสูตรที่อ้างอิงแผ่นงาน เช่น `Sheet1!$A$1:$D$5` โดย `Sheet1` คือชื่อแผ่นงาน `!` แยกออกจากช่วงเซลล์ และ `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวมถึงเครื่องหมายดอลลาร์บ่งบอกอ้างอิงแถวและคอลัมน์แบบสัมบันทึก

เมธ็อดนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือสมุดงานของมัน หากแผนภูมิไม่ได้ใช้สมุดงานเป็นแหล่งข้อมูล จะเกิดข้อยกเว้น [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) สำหรับข้อมูลเพิ่มเติม ดูที่ [ChartData API Reference](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/)

ตัวอย่างนี้เปิดงานนำเสนอและตรวจสอบรูปร่างบนแต่ละสไลด์เพื่อหาแผนภูมิ พิมพ์ชื่อแผนภูมิและช่วงต้นฉบับ หากแผนภูมิไม่ใช้สมุดงาน จะพิมพ์ข้อความและดำเนินการต่อไปยังแผนภูมถัดไป

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

for (auto slide : IterateOver(presentation->get_Slides()))
{
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        auto chart = AsCast<IChart>(shape);
        if (chart != nullptr)
        {
            try
            {
                auto range = chart->get_ChartData()->GetRange();
                Console::WriteLine(u"{0}: {1}", chart->get_Name(), range);
            }
            catch (const InvalidOperationException&)
            {
                Console::WriteLine(u"{0}: The chart does not use a workbook as its data source.", chart->get_Name());
            }
        }
    }
}
```

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides for C++ มีเมธ็อด [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) และ [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) ที่ให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งอาจแก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งข้อมูล

ตัวอย่างนี้ใช้งานนำเสนอที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรก อ่านสมุดงานฝังเป็นสตรีม ล้างชุดข้อมูลและประเภทข้อมูลเดิม แล้วเขียนสมุดงานเดียวกันกลับไป การเปลี่ยนแปลงยังคงอยู่ในหน่วยความจำ ตัวอย่างไม่ได้บันทึกงานนำเสนอ

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

### **ตรวจสอบการจัดรูปแบบแผนภูมิหลังการแก้ไขสมุดงาน**

เมื่อคุณแทนที่สมุดงานฝังด้วยสมุดงานที่แก้ไขแล้ว แผนภูมิจะยังคงรักษาชุดข้อมูลและคอลเลกชันประเภทเดิม ความไม่สอดคล้องนี้อาจทำให้ [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) ล้มเหลวด้วยข้อผิดพลาดดัชนีอยู่นอกช่วง ล้างชุดข้อมูลและประเภทเดิมก่อนเขียนสมุดงานที่อัปเดตกลับไปยังแผนภูมิ ตัวอย่างใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรก คอมเมนต์ระบุจุดที่ควรแก้ไขสมุดงาน ตัวอย่างทำงานเขียนสมุดงานดั้งเดิมกลับและตรวจสอบการจัดรูปแบบในหน่วยความจำ

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

    // แก้ไขสตรีมสมุดงานที่นี่, ตัวอย่างเช่นโดยใช้ Aspose.Cells.

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

การล้างคอลเลกชันจะลบการอ้างอิงข้อมูลที่เก่าแล้วก่อนที่สมุดงานจะถูกเขียนกลับ สร้างชุดข้อมูลและการแมพประเภทใหม่ตามสมุดงานที่อัปเดตก่อนใช้แผนภูมิ

## **ตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ

ตัวอย่างนี้เพิ่มแผนภูมิบับกับข้อมูลเริ่มต้นบนสไลด์แรกของงานนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บนแผ่นงาน 0 เป็นป้ายกำกับสามรายการแรกของชุดแรก เปิดใช้งานการใช้ป้ายกำกับจากเซลล์ และบันทึกงานนำเสนอที่อัปเดต

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

เมธ็อด [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) ให้เข้าถึงแผ่นงานในสมุดงานแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิโปร่งกับข้อมูลเริ่มต้นและพิมพ์ชื่อแผ่นงานแต่ละอันลงคอนโซล

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

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติด้วยข้อมูลเริ่มต้นและตั้งชื่อชุดข้อมูลสองชุดโดยใช้แหล่งข้อมูลต่างกัน ชื่อแรกใช้สตริงลิต้าเลิล; ชื่อที่สองใช้เซลล์ C1 บนแผ่นงาน 0 การนับประเภท [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) จะเลือกแหล่งสำหรับแต่ละชื่อ ตัวอย่างบันทึกงานนำเสนอพร้อมชื่อชุดข้อมูลที่อัปเดต

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

## **ตรวจจับรูปแบบสมุดงานฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจฝังในแผนภูมิบางประเภท คุณสามารถใช้เมธ็อด [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) บน [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) ร่วมกับการนับประเภท [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) เพื่อตรวจพบรูปแบบที่ไม่รองรับและข้ามแผนภูมินั้น ตัวอย่างตรวจสอบรูปร่างบนสไลด์แรกของงานนำเสนอที่มีอยู่ ข้ามรูปร่างที่ไม่ใช่แผนภูมิ และพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มีสมุดงาน .xlsb ฝังอยู่

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

    // อ่านหรือแก้ไขข้อมูลสมุดงานแผนภูมิที่รองรับที่นี่.
}
```

## **สมุดงานภายนอก**

Aspose.Slides รองรับการใช้สมุดงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างสมุดงานภายนอก**

ใช้ [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) และ [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) เพื่อส่งออกสมุดงานแผนภูมิที่ฝังไว้เป็นไฟล์และเชื่อมโยงแผนภูมิกับสมุดงานภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิวงกลมด้วยข้อมูลเริ่มต้นและส่งออกสมุดงานของมัน ปิดสตรีมเอาต์พุตก่อนกำหนดสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ แล้วบันทึกงานนำเสนอที่เชื่อมโยง

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

### **กำหนดสมุดงานภายนอก**

โดยใช้เมธ็อด [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธ็อดนี้ยังใช้เพื่ออัปเดตเส้นทางไปยังสมุดงานภายนอก (หากไฟล์นั้นถูกย้าย)

แม้ว่าจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่จัดเก็บในตำแหน่งระยะไกลหรือทรัพยากรได้ คุณก็ยังสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพันธ์สำหรับสมุดงานภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้สมุดงานภายนอกที่แผ่นงานชื่อ `Sheet1` มีชื่อชุดข้อมูลใน B1, ชื่อประเภทใน A2:A4 และค่าเชิงตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิเส้นวงกลม, เชื่อมโยงสมุดงาน, แล้วใช้ [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) เพื่อแมพ A1:B4 ไปยังชุดข้อมูลหนึ่งชุดและประเภทสามประเภท บันทึกงานนำเสนอพร้อมแผนภูมิลิงก์

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

พารามิเตอร์ `updateChartData` ของ [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) ควบคุมว่าจะโหลดสมุดงานหรือไม่

* เมื่อ `updateChartData` เป็น `false` จะอัปเดตเฉพาะเส้นทางสมุดงานเท่านั้น ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดงานเป้าหมาย ดังนั้นสมุดงานอาจไม่มีอยู่ได้
* เมื่อ `updateChartData` เป็น `true` ข้อมูลแผนภูมิจะอัปเดตจากสมุดงานเป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวแทนพร้อม `updateChartData` เป็น `false` รักษาข้อมูลเริ่มต้นของแผนภูมิวงกลมและบันทึกงานนำเสนอโดยไม่โหลดสมุดงานที่ไม่มีอยู่

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

### **รับเส้นทางสมุดงานแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุสมุดงานที่เชื่อมโยงกับแผนภูมิ ให้ตรวจสอบว่าแผนภูมิใช้แหล่งข้อมูลภายนอกหรือไม่และดึงเส้นทางสมุดงานของมัน

ตัวอย่างนี้ตรวจสอบรูปร่างแรกบนสไลด์แรกของงานนำเสนอที่มีสมุดงานภายนอกเชื่อมโยง หากเป็นแผนภูมิที่เชื่อมกับสมุดงานภายนอก ตัวอย่างจะพิมพ์ [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) ไปยังคอนโซล จากนั้นบันทึกสำเนาของงานนำเสนอ

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

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาในสมุดงานภายใน หากสมุดงานภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและเชื่อมโยงกับสมุดงานภายนอกที่สามารถเข้าถึงได้ ตั้งค่าค่าที่ได้จากเซลล์ของจุดข้อมูลแรกในชุดแรกเป็น 100 แล้วบันทึกงานนำเสนอที่อัปเดต การแก้ไขค่าจากเซลล์อาจอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยง ดังนั้นควรใช้สำเนาหากต้องการเก็บสมุดงานต้นฉบับไว้

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

### **กู้คืนสมุดงานจากแคชของแผนภูมิ**

หากแผนภูมิใช้สมุดงานภายนอกที่หายไปหรือไม่มีอยู่ Aspose.Slides สามารถสร้างสมุดงานแผนภูมิจากข้อมูลที่แคชไว้ในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/), ตั้งค่าโดยใช้ [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), แล้วเรียก [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) ด้วยค่า `true` ก่อนเปิดงานนำเสนอ

ตัวอย่าง C++ ต่อไปนี้กู้คืนข้อมูลสมุดงานสำหรับแผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและอ้างอิงถึงสมุดงานภายนอกที่ไม่มีอยู่ เข้าถึงข้อมูลที่กู้คืนผ่าน [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) และ [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

    // อ่านหรือแก้ไขข้อมูลสมุดงานที่กู้คืนที่นี่.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

หากสมุดงานภายนอกไม่มีอยู่และการกู้คืนถูกปิดใช้งาน Aspose.Slides จะโยงข้อยกเว้น [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแคชของแผนภูมิเป็นทางเลือกที่ยอมรับได้ เพราะแคชอาจไม่รวมการเปลี่ยนแปลงที่ทำกับสมุดงานภายนอกหลังจากที่งานนำเสนอได้รับการอัปเดตล่าสุด

## **FAQ**

**ฉันจะตรวจสอบได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับสมุดงานภายนอกหรือสมุดงานฝังอยู่?**

ได้ แอปพลิเคชันแผนภูมิมี [ประเภทแหล่งข้อมูล](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) และ [เส้นทางไปยังสมุดงานภายนอก](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) หากแหล่งเป็นสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ามีการใช้ไฟล์ภายนอก

**รองรับเส้นทางสัมพันธ์ไปยังสมุดงานภายนอกหรือไม่ และจัดเก็บอย่างไร?**

รองรับ หากคุณระบุเส้นทางสัมพันธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ งานนำเสนอจะบันทึกเส้นทางเต็มในไฟล์ PPTX ดังนั้นการย้ายสมุดงานอาจต้องอัปเดตลิงก์

**สามารถใช้สมุดงานที่อยู่บนแหล่งข้อมูลเครือข่ายหรือแชร์ได้หรือไม่?**

ได้ สมุดงานเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

งานนำเสนอบันทึก [ลิงก์ไปยังไฟล์ภายนอก](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) การแก้ไขข้อมูลแผนภูมิที่มาจากเซลล์อาจอัปเดตไฟล์ XLSX ภายในที่เชื่อมโยง ใช้สำเนาของสมุดงานหากต้องการให้ไฟล์ต้นฉบับคงเดิม

**ควรทำอย่างไรหากไฟล์ภายนอกมีการป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อเชื่อมโยง วิธีที่พบบ่อยคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถูกถอดรหัส (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิเก็บลิงก์ของตนเอง หากทั้งหมดอ้างอิงไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะส่งผลต่อทุกแผนภูมิเมื่อต่อไปข้อมูลถูกโหลด.