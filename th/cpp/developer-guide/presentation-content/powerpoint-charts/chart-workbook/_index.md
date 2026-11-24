---
title: จัดการเวิร์กบุ๊คแผนภูมิในการนำเสนอโดยใช้ C++
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
description: "ค้นพบ Aspose.Slides สำหรับ C++: จัดการเวิร์กบุ๊คแผนภูมิโดยง่ายในรูปแบบ PowerPoint และ OpenDocument เพื่อปรับปรุงข้อมูลการนำเสนอของคุณให้เป็นระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับเวิร์กบุ๊คแผนภูมิใน Aspose.Slides แสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของเวิร์กบุ๊ค ใช้เซลล์ของเวิร์กบุ๊คเป็นป้ายข้อมูลแผนภูมิ เข้าถึงคอลเลกชันของแผ่นงาน และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

บทความยังครอบคลุมการทำงานกับเวิร์กบุ๊คภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดเวิร์กบุ๊คภายนอก ดึงเส้นทางของเวิร์กบุ๊คภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อเวิร์กบุ๊คพร้อมใช้งาน

สำหรับเซลล์ของเวิร์กบุ๊คที่แสดงข้อมูลหายไป ให้ดูที่ [ควบคุมการแสดงของเซลล์ว่าง](/slides/th/cpp/chart-series/) เพื่อเปรียบเทียบความแตกต่างระหว่างเซลล์ว่างกับศูนย์ รวมถึงการเปรียบเทียบแบบแผนภูมิเส้นของโหมดการแสดงผลที่มีให้เลือก

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่**

ใช้ [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) เพื่อควบคุมว่าระดับแผนภูมิจะพล็อตข้อมูลจากแถวและคอลัมน์ของแผ่นงานที่ซ่อนอยู่หรือไม่ ตั้งค่าเป็น `true` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็นได้ หรือ `false` เพื่อรวมทั้งเซลล์ที่มองเห็นและซ่อน การตั้งค่านี้ควบคุมการพล็อตของแผนภูมิเท่านั้น ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของแผ่นงาน

[ตัวอย่างการนำเสนอ](hidden-source-data.pptx) มีแผนภูมิคอลัมน์เป็นรูปทรงแรกบนสไลด์แรกของมัน แผ่นงานฝังอยู่ชื่อ `Sheet1` มีช่วงแหล่งข้อมูล `A1:C4` แถว 3 และคอลัมน์ C ถูกซ่อนไว้ แต่เซลล์ของพวกมันยังคงมีค่าอยู่

| แถวของ Worksheet | A: Month | B: Retail | C: Wholesale (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (แถวที่ซ่อน) | February | 40 | 60 |
| 4 | March | 20 | 50 |

เข้าถึงเซลล์แหล่งข้อมูลผ่าน [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) และอ่าน [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) เพื่อตรวจสอบสถานะการซ่อนของเซลล์ property นี้เป็นแบบอ่านอย่างเดียว ในไฟล์นี้ B2 สามารถมองเห็นได้, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างจะแสดงผล `False`, `True`, และ `True` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการพล็อต: คงเวิร์กบุ๊คฝังไว้โดยใช้ [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) แล้วโหลดใหม่ด้วย [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) เมื่อรวมเซลล์ทั้งหมด ให้ใช้ [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) เพื่อกู้คืนช่วงเต็มรวมถึงหมวด “February” ที่ซ่อนอยู่ การเปลี่ยนแค่ค่าสำดับไม่เพียงพอที่จะรีเฟรชข้อมูลแคชของแผนภูมิและป้ายหมวดในตัวอย่างนี้

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

        // รีเฟรชข้อมูลแผนภูมิจากเวิร์กบุ๊คฝัง.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // กู้คืนช่วงแหล่งข้อมูลทั้งหมด รวมถึงหมวดที่ซ่อนอยู่.
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

ตัวอย่างจะบันทึกสองเวอร์ชันของการนำเสนอ: หนึ่งเวอร์ชันที่มีเฉพาะค่าการขายส่งปลีกที่มองเห็นได้ (10 และ 20) อีกเวอร์ชันหนึ่งที่มีค่าทั้งหกค่า ภาพด้านล่างแสดงสองโหมดการพล็อต แถว 3 และคอลัมน์ C ยังคงซ่อนอยู่ในทั้งสองเวิร์กบุ๊คฝัง

| เฉพาะเซลล์ที่มองเห็น (`true`) | ทุกเซลล์ (`false`) |
| --- | --- |
| ![เฉพาะเซลล์ที่มองเห็น: ค่าการขายปลีก 10 และ 20 สำหรับ January และ March.](hidden_cells_True.png) | ![ทุกเซลล์: ค่าการขายปลีกและการขายส่งสำหรับ January, February, และ March.](hidden_cells_False.png) |

เซลล์ที่ซ่อนพร้อมค่าต่างจากเซลล์ว่าง [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) ควบคุมวิธีการแสดงค่าที่หายไป; มันไม่ได้รวมหรือยกเว้นข้อมูลแหล่งที่ซ่อน ดูที่ [ควบคุมการแสดงของเซลล์ว่าง](/slides/th/cpp/chart-series/#control-the-display-of-empty-cells) สำหรับตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนอัปเดตข้อมูลเวิร์กบุ๊คในงานนำเสนอที่มีอยู่ ให้ตรวจสอบช่วงแหล่งข้อมูลเพื่อระบุว่าแต่ละแผนภูมิใช้เซลล์ของแผ่นงานใดเมธอด [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) คืนค่าช่วงข้อมูลปัจจุบันในรูปสูตรที่อ้างอิงแผ่นงาน เช่น `Sheet1!$A$1:$D$5` ที่นี่ `Sheet1` คือชื่อแผ่นงาน, `!` คั่นกับช่วงเซลล์, และ `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวมทั้งสองค่าเครื่องหมายดอลลาร์แสดงการอ้างอิงแบบสัมบูรณ์ต่อแถวและคอลัมน์

เมธอดนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือเวิร์กบุ๊ค หากแผนภูมิไม่ได้ใช้เวิร์กบุ๊คเป็นแหล่งข้อมูล จะเกิดข้อผิดพลาด [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) สำหรับข้อมูลเพิ่มเติม ดูที่ [ChartData API Reference](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/)

ตัวอย่างนี้เปิดงานนำเสนอและตรวจสอบรูปทรงบนแต่ละสไลด์เพื่อหาข้อมูลแผนภูมิ พิมพ์ชื่อแผนภูมิและช่วงแหล่งข้อมูล หากแผนภูมิไม่ได้ใช้เวิร์กบุ๊ค จะพิมพ์ข้อความและดำเนินต่อไปยังแผนภูมิถัดไป

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

## **อ่านและเขียนข้อมูลแผนภูมิจากเวิร์กบุ๊ค**

Aspose.Slides for C++ มีเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) และ [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) ที่ช่วยให้คุณอ่านและเขียนเวิร์กบุ๊คข้อมูลแผนภูมิ (ซึ่งอาจแก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูลต้นฉบับ

ตัวอย่างนี้ใช้การนำเสนอที่มีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรก อ่านเวิร์กบุ๊คฝังเป็นสตรีม, ลบซีรีส์และหมวดที่มีอยู่, แล้วเขียนเวิร์กบุ๊คเดิมกลับไป การเปลี่ยนแปลงจะคงอยู่ในหน่วยความจำ; ตัวอย่างไม่ได้บันทึกการนำเสนอ

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

### **ตรวจสอบโครงสร้างแผนภูมิหลังการแก้ไขเวิร์กบุ๊ค**

เมื่อคุณแทนที่เวิร์กบุ๊คฝังด้วยเวิร์กบุ๊คที่แก้ไขแล้ว แผนภูมิอาจยังคงมีซีรีส์และคอลเลกชันหมวดเดิม การไม่ตรงกันนี้อาจทำให้ [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) ล้มเหลวด้วยข้อผิดพลาดดัชนีอยู่นอกช่วง ให้ลบซีรีส์และหมวดที่มีอยู่ก่อนเขียนเวิร์กบุ๊คที่อัปเดตกลับไป แผนภูมิในตัวอย่างเป็นรูปทรงแรกบนสไลด์แรก คอมเมนต์แสดงตำแหน่งที่ควรแก้ไขเวิร์กบุ๊ค; ตัวอย่างทำงานเขียนเวิร์กบุ๊คเดิมกลับและตรวจสอบโครงสร้างในหน่วยความจำ

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

    // แก้ไขสตรีมเวิร์กบุ๊คที่นี่, ตัวอย่างเช่น ใช้ Aspose.Cells.

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

การลบคอลเลกชันจะลบการอ้างอิงข้อมูลที่ล้าสมัยก่อนที่เวิร์กบุ๊คจะถูกเขียนกลับ ให้สร้างซีรีส์และการแมปหมวดที่จำเป็นสำหรับเวิร์กบุ๊คที่อัปเดตก่อนใช้แผนภูมิ

## **เลือกวิธีการจัดเก็บป้ายหมวด**

เรียก [IChartCategoryCollection::set_UseCells](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategorycollection/set_usecells/) บนคอลเลกชันหมวดที่ว่างก่อนเพิ่มป้าย ใช้เซลล์ของแผ่นงานสำหรับป้ายที่อ้างอิงข้อมูลเวิร์กบุ๊คหรือสร้างลำดับชั้น เช่น ไตรมาสที่จัดกลุ่มตามปี ใช้สตริงโดยตรงสำหรับป้ายระดับเดียวที่ไม่ต้องอ้างอิงเซลล์ การตั้งค่านี้ใช้กับหมวดเท่านั้น ทั้งสองแผนภูมิในตัวอย่างใช้เซลล์ของแผ่นงานสำหรับค่าตัวเลขของซีรีส์

ตัวอย่างสร้างแผนภูมิคอลัมน์สองอันและพิมพ์โหมดการจัดเก็บและป้าย `Q1 Q2 Q3 Q4` สำหรับแต่ละอัน สำหรับป้ายที่อ้างอิงแผ่นงาน, [IChartCategory::get_AsCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategory/get_ascell/) ให้เข้าถึงเซลล์พื้นฐานและ [IChartDataCell::get_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_value/) คืนค่าป้ายนั้น สำหรับป้ายตัวอักษรอ่านสตริงโดยตรงจาก [IChartCategory::get_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategory/get_value/)

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategory.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <initializer_list>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

for (auto useCells : {true, false})
{
    auto x = useCells ? 20 : 360;
    auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, 20, 320, 250);
    auto data = chart->get_ChartData();
    auto categories = data->get_Categories();
    data->get_Series()->Clear();
    categories->Clear();
    categories->set_UseCells(useCells);

    auto workbook = data->get_ChartDataWorkbook();
    auto seriesName = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Sales"));
    auto series = data->get_Series()->Add(seriesName, chart->get_Type());
    for (auto row = 1; row <= 4; ++row)
    {
        auto label = String::Format(u"Q{0}", row);
        auto labelValue = ObjectExt::Box<String>(label);
        if (useCells)
        {
            auto labelCell = workbook->GetCell(0, row, 0, labelValue);
            categories->Add(labelCell);
        }
        else
        {
            categories->Add(labelValue);
        }

        auto valueCell = workbook->GetCell(0, row, 1, ObjectExt::Box<int32_t>(row * 10));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }

    Console::Write(u"UseCells = {0}:", categories->get_UseCells());
    for (auto category : IterateOver(categories))
    {
        auto label = categories->get_UseCells() ? category->get_AsCell()->get_Value() : category->get_Value();
        Console::Write(u" {0}", label->ToString());
    }
    Console::WriteLine();
}

presentation->Save(u"category-labels.pptx", Export::SaveFormat::Pptx);
```

## **ตั้งรูปแบบตัวเลขที่กำหนดเองสำหรับเซลล์เวิร์กบุ๊ค**

ใช้ [IChartDataCell::set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) เพื่อควบคุมวิธีการแสดงค่าตัวเลขในเวิร์กบุ๊คฝังของแผนภูมิ ตัวอย่างเช่น รายงานอาจต้องการแสดงอัตราแลกเปลี่ยนเป็นเปอร์เซ็นต์ที่มีสี่ตำแหน่งทศนิยมและค่าสัมประสิทธิ์ที่มีห้าตำแหน่งทศนิยม ค่าทั้งสองต้องคงเป็นตัวเลขเพื่อให้ยังคงใช้ในการคำนวณและพล็อตแผนภูมิได้

รูปแบบตัวเลขเปลี่ยนการแสดงผล ไม่ได้เปลี่ยนค่าที่เก็บไว้ รูปแบบ `0.0000%` จะทำให้ `0.125` แสดงเป็น `12.5000%`; ไม่ได้แทนที่ตัวเลขที่เก็บเป็น `12.5` เช่นเดียวกัน `0.00000` แสดง `0.1234567` เป็น `0.12346` โดยไม่มีการปัดค่าที่เก็บ หากรูปแบบกำหนดเองเป็นสตริงว่าง (`""`) จะใช้รูปแบบที่กำหนดผ่าน [set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) แทน

ตัวอย่างต่อไปสร้างแผนภูมิคอลัมน์และเข้าถึงเซลล์ผ่าน [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/). บนแผ่นงาน 0, B2 มีอัตราแลกเปลี่ยนและ C2 มีค่าสัมประสิทธิ์ ทั้งสองเซลล์เป็นค่าที่ใช้ในแผนภูมิ ตัวอย่างยังเปิดใช้ป้ายค่าที่เชื่อมโยงกับรูปแบบของแหล่งข้อมูล

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 270, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
chart->set_HasTitle(false);

chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00");
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(0);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto categoryCell = workbook->GetCell(0, u"A2", ObjectExt::Box<String>(u"Sample"));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

auto percentageCell = workbook->GetCell(0, u"B2", ObjectExt::Box<double>(0.125));
percentageCell->set_CustomNumberFormat(u"0.0000%");
auto percentageName = workbook->GetCell(0, u"B1", ObjectExt::Box<String>(u"Conversion rate"));
auto percentageSeries = chart->get_ChartData()->get_Series()->Add(percentageName, chart->get_Type());
percentageSeries->get_DataPoints()->AddDataPointForBarSeries(percentageCell);

auto precisionCell = workbook->GetCell(0, u"C2", ObjectExt::Box<double>(0.1234567));
precisionCell->set_CustomNumberFormat(u"0.00000");
auto precisionName = workbook->GetCell(0, u"C1", ObjectExt::Box<String>(u"Coefficient"));
auto precisionSeries = chart->get_ChartData()->get_Series()->Add(precisionName, chart->get_Type());
precisionSeries->get_DataPoints()->AddDataPointForBarSeries(precisionCell);

for (auto series : IterateOver(chart->get_ChartData()->get_Series()))
{
    auto labelFormat = series->get_DataPoint(0)->get_Label()->get_DataLabelFormat();
    labelFormat->set_ShowValue(true);
    labelFormat->set_IsNumberFormatLinkedToSource(true);
}

presentation->Save(u"CustomCellFormats.pptx", Export::SaveFormat::Pptx);
```

รูปแบบเซลล์เวิร์กบุ๊คแยกจากรูปแบบที่ตั้งโดยตรงบนแกนหรือป้ายข้อมูล ในตัวอย่างนี้ ป้ายแต่ละอันแสดงค่าจากเซลล์ต้นทางเพราะ [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) ถูกเรียกด้วย `true` และตามรูปแบบตัวเลขของแหล่งข้อมูลเพราะ [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) ถูกเรียกด้วย `true` หลังจากบันทึกและเปิดงานนำเสนอใหม่ ป้ายจะแสดง `12.5000%` และ `0.12346` ตามที่แสดงด้านล่าง แกนแนวตั้งใช้รูปแบบของตนเอง `0.00` ที่กำหนดผ่าน [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberformat/) พร้อมกับ [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isnumberformatlinkedtosource/) ที่ตั้งเป็น `false`

หากต้องการจัดรูปแบบป้ายข้อมูลอย่างอิสระ ให้ตั้งค่าสถานะการเชื่อมโยงแหล่งเป็น `false` แล้วกำหนดรูปแบบผ่าน [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/) วิธีนี้จะไม่เปลี่ยนรูปแบบของเซลล์เวิร์กบุ๊ค ตัวอย่างเช่น รูปแบบป้ายอิสระ `0.00` จะแสดงค่าตัวแรกเป็น `0.13` ในขณะที่ B2 ยังคงแสดง `12.5000%` ดูที่ [Chart Data Labels](/slides/th/cpp/chart-data-label/#set-percentage-sign-with-chart-data-labels) สำหรับการจัดรูปแบบป้ายโดยตรง

ภาพด้านล่างสร้างจากงานนำเสนอที่บันทึกแล้วและเปิดใหม่อีกครั้ง:

![แผนภูมิคอลัมน์ที่มีป้ายเชื่อมโยงกับแหล่งแสดง 12.5000% และ 0.12346 พร้อมแกนเชิงตัวเลขที่จัดรูปแบบอย่างอิสระ.](custom-cell-formats.png)

## **กำหนดเซลล์เวิร์กบุ๊คเป็นป้ายข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์เวิร์กบุ๊คเป็นป้ายข้อมูลแผนภูมิได้

ตัวอย่างนี้เพิ่มแผนภูมิบับเบิลที่มีข้อมูลเริ่มต้นบนสไลด์แรกของงานนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บนแผ่นงาน 0 เป็นสามป้ายแรกของซีรีส์แรก เปิดใช้ป้ายจากเซลล์และบันทึกงานนำเสนอที่อัปเดต

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

เมธอด [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) ให้เข้าถึงแผ่นงานในเวิร์กบุ๊คของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิโปร่งที่มีข้อมูลเริ่มต้นและพิมพ์ชื่อแผ่นงานแต่ละอันลงคอนโซล

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

ค่าจุดของซีรีส์อาจเก็บเป็นลิเตอรัลตัวเลขโดยตรง ดูที่ [ตั้งค่าค่าซีรีส์โดยใช้ลิเตอรัลตัวเลข](/slides/th/cpp/chart-series/#set-series-values-using-numeric-literals) สำหรับตัวอย่างสมบูรณ์ที่บันทึกและอ่านค่าเหล่านั้น ประเภทแหล่งข้อมูลของค่าจุดแยกจากการกำหนดค่าเวิร์กบุ๊ครายการภายในหรือภายนอกของแผนภูมิ; การใช้ลิเตอรัลตัวเลขโดยตัวเองไม่ได้ลบเวิร์กบุ๊คฝังออก

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติที่มีข้อมูลเริ่มต้นและตั้งชื่ิอซีรีส์สองชื่อโดยใช้แหล่งข้อมูลที่แตกต่าง ชื่อแรกใช้ลิเตอรัลสตริง; ชื่อที่สองใช้เซลล์ C1 บนแผ่นงาน 0 ค่าตenumeration [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) เลือกแหล่งสำหรับแต่ละชื่อ ตัวอย่างบันทึกงานนำเสนอพร้อมชื่อซีรีส์ที่อัปเดต

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

## **ตรวจจับรูปแบบเวิร์กบุ๊คฝังที่ไม่สนับสนุน**

Aspose.Slides ไม่สนับสนุนรูปแบบเวิร์กบุ๊ค Excel แบบไบนารี (.xlsb) ที่อาจฝังในบางแผนภูมิ คุณสามารถใช้เมธอด [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) บน [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) เพื่อค้นหารูปแบบที่ไม่สนับสนุนและข้ามแผนภูมิที่เกี่ยวข้อง ตัวอย่างตรวจสอบรูปทรงบนสไลด์แรกของงานนำเสนอที่มีอยู่ ข้ามรูปทรงที่ไม่ใช่แผนภูมิ และพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มีเวิร์กบุ๊ค .xlsb ฝังอยู่

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

    // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊คแผนภูมิที่สนับสนุนที่นี่.
}
```

## **เวิร์กบุ๊คภายนอก**

Aspose.Slides รองรับการใช้เวิร์กบุ๊คภายนอกเป็นแหล่งข้อมูลของแผนภูมิ

### **สร้างเวิร์กบุ๊คภายนอก**

ใช้ [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) และ [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) เพื่อส่งออกเวิร์กบุ๊คแผนภูมิฝังเป็นไฟล์และเชื่อมแผนภูมิกับเวิร์กบุ๊คภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิโปร่งที่มีข้อมูลเริ่มต้นและส่งออกเวิร์กบุ๊คของมัน ปิดสตรีมเอาต์พุตก่อนกำหนดเวิร์กบุ๊คภายนอกเป็นแหล่งข้อมูลของแผนภูมิ จากนั้นบันทึกงานนำเสนอที่เชื่อมโยง

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

โดยใช้เมธอด [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) คุณสามารถกำหนดเวิร์กบุ๊คภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางไปยังเวิร์กบุ๊คภายนอก (หากไฟล์นั้นถูกย้าย)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในเวิร์กบุ๊คที่จัดเก็บในตำแหน่งระยะไกลหรือทรัพยากรได้ แต่ยังสามารถใช้เวิร์กบุ๊คเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพัทธ์สำหรับเวิร์กบุ๊คภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้เวิร์กบุ๊คภายนอกที่มีแผ่นงานชื่อ `Sheet1` มีชื่อซีรีส์ใน B1, ชื่อหมวดใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิพาย, เชื่อมโยงเวิร์กบุ๊ค, แล้วใช้ [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) เพื่อแมป A1:B4 เป็นซีรีส์หนึ่งและสามหมวด แล้วบันทึกงานนำเสนอที่มีแผนภูมิเชื่อมโยง

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

พารามิเตอร์ `updateChartData` ของ [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) ควบคุมว่าจะโหลดเวิร์กบุ๊คหรือไม่

* เมื่อ `updateChartData` เป็น `false` จะอัปเดตเฉพาะเส้นทางของเวิร์กบุ๊ค แผนภูมิจะไม่โหลดหรืออัปเดตข้อมูลจากเวิร์กบุ๊คเป้าหมาย ดังนั้นเวิร์กบุ๊คอาจไม่พร้อมใช้งาน
* เมื่อ `updateChartData` เป็น `true` จะอัปเดตข้อมูลแผนภูมิจากเวิร์กบุ๊คเป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวแทนพร้อม `updateChartData` เป็น `false` คงข้อมูลเริ่มต้นของแผนภูมิพายและบันทึกงานนำเสนอโดยไม่โหลดเวิร์กบุ๊คที่ไม่พร้อมใช้งาน

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

เพื่อระบุเวิร์กบุ๊คที่เชื่อมกับแผนภูมิ, ตรวจสอบว่าแผนภูมิกำลังใช้แหล่งข้อมูลภายนอกหรือไม่และดึงเส้นทางเวิร์กบุ๊คของมัน

ตัวอย่างนี้ตรวจสอบรูปทรงแรกบนสไลด์แรกของงานนำเสนอที่เชื่อมกับเวิร์กบุ๊คภายนอก หากเป็นแผนภูมิที่เชื่อมกับเวิร์กบุ๊คภายนอก ตัวอย่างจะพิมพ์ [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) ลงคอนโซล แล้วบันทึกสำเนาของงานนำเสนอ

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

คุณสามารถแก้ไขข้อมูลในเวิร์กบุ๊คภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงข้อมูลในเวิร์กบุ๊คภายใน เมื่อเวิร์กบุ๊คภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปทรงแรกบนสไลด์แรกและเชื่อมกับเวิร์กบุ๊คภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่อิงเซลล์ของจุดข้อมูลแรกในซีรีส์แรกเป็น 100 แล้วบันทึกงานนำเสนอที่อัปเดต การแก้ไขค่าที่อิงเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยงได้ ดังนั้นควรใช้สำเนาหากต้องการเก็บเวิร์กบุ๊คต้นฉบับไว้

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

หากแผนภูมิใช้เวิร์กบุ๊คภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างเวิร์กบุ๊คแผนภูมิจากข้อมูลที่แคชไว้ในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/), ตั้งค่าโดยใช้ [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), แล้วเรียก [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) ด้วยค่า `true` ก่อนเปิดงานนำเสนอ

ตัวอย่าง C++ ต่อไปกู้คืนข้อมูลเวิร์กบุ๊คสำหรับแผนภูมิที่เป็นรูปทรงแรกบนสไลด์แรกและอ้างอิงเวิร์กบุ๊คภายนอกที่ไม่พร้อมใช้งาน เข้าถึงข้อมูลที่กู้คืนผ่าน [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) และ [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

ถ้าเวิร์กบุ๊คภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิด Aspose.Slides จะโยนข้อยกเว้น [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแคชของแผนภูมิเป็นวิธีสำรองที่ยอมรับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับเวิร์กบุ๊คภายนอกหลังจากงานนำเสนออัปเดตครั้งสุดท้าย

## **FAQ**

**ฉันจะตรวจสอบได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับเวิร์กบุ๊คภายนอกหรือเวิร์กบุ๊คฝัง?**

ได้. แผนภูมิมี [data source type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); หากแหล่งเป็นเวิร์กบุ๊คภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าใช้ไฟล์ภายนอก

**รองรับเส้นทางสัมพัทธ์ไปยังเวิร์กบุ๊คภายนอกหรือไม่และจัดเก็บอย่างไร?**

รองรับ. หากคุณระบุเส้นทางสัมพัทธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ งานนำเสนอเก็บเส้นทางเต็มในไฟล์ PPTX ดังนั้นการย้ายเวิร์กบุ๊คอาจต้องอัปเดตลิงก์

**ฉันสามารถใช้เวิร์กบุ๊คที่อยู่บนทรัพยากรเครือข่าย/แชร์ได้หรือไม่?**

ได้, เวิร์กบุ๊คเหล่านี้สามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขเวิร์กบุ๊คระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

งานนำเสนอเก็บ [link to the external file](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) การแก้ไขข้อมูลแผนภูมิที่อิงเซลล์อาจอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยง ใช้สำเนาของเวิร์กบุ๊คหากต้องการให้ไฟล์ต้นฉบับไม่เปลี่ยนแปลง

**ต้องทำอย่างไรหากไฟล์ภายนอกถูกตั้งรหัสผ่าน?**

Aspose.Slides ไม่รับพาสเวิร์ดเมื่อเชื่อมโยง วิธีทั่วไปคือเอารหัสผ่านออกล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงเวิร์กบุ๊คภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละแผนภูมจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปที่ไฟล์เดียว การอัปเดตไฟล์นั้นจะสะท้อนในทุกแผนภูมิในครั้งต่อไปที่โหลดข้อมูล.