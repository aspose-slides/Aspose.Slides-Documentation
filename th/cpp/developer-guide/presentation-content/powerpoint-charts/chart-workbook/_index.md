---
title: จัดการเวิร์กบุ๊กแผนภูมิในงานนำเสนอโดยใช้ C++
linktitle: เวิร์กบุ๊กแผนภูมิ
type: docs
weight: 70
url: /th/cpp/chart-workbook/
keywords:
- เวิร์กบุ๊กแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์เวิร์กบุ๊ก
- ป้ายข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- เวิร์กบุ๊กภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนเวิร์กบุ๊ก
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบ Aspose.Slides Для C++: จัดการเวิร์กบุ๊กแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลงานนำเสนอของคุณ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับเวิร์กบุ๊กแผนภูมิใน Aspose.Slides แสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมเวิร์กบุ๊ก ใช้เซลล์เวิร์กบุ๊กเป็นป้ายข้อมูลแผนภูมิ เข้าถึงคอลเลกชันแผ่นงาน และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

มันยังครอบคลุมการทำงานกับเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดเวิร์กบุ๊กภายนอก ดึงเส้นทางของเวิร์กบุ๊กภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อเวิร์กบุ๊กพร้อมใช้งาน

สำหรับเซลล์เวิร์กบุ๊กที่แทนค่าขาดหาย ดู [ควบคุมการแสดงเซลล์ว่าง](/slides/th/cpp/chart-series/) เพื่อเข้าใจความแตกต่างระหว่างเซลล์ว่างกับศูนย์ และเปรียบเทียบโหมดการแสดงผลของแผนภูมิเส้น

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่**

ใช้ [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) เพื่อควบคุมว่าตารางจะพล็อตข้อมูลจากแถวและคอลัมน์ของแผ่นงานที่ซ่อนหรือไม่ ตั้งเป็น `true` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็น หรือ `false` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อน การตั้งค่านี้ควบคุมการพล็อตของแผนภูมิ; มันไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของแผ่นงาน

[ตัวอย่างการนำเสนอ](hidden-source-data.pptx) มีแผนภูมิคอลัมน์เป็นรูปร่างแรกบนสไลด์แรก แผ่นงานที่ฝังอยู่ `Sheet1` มีช่วงแหล่งข้อมูล `A1:C4` แถวที่ 3 และคอลัมน์ C ถูกซ่อน แต่เซลล์ยังคงมีค่า

| แถวแผ่นงาน | A: เดือน | B: ร้านค้า | C: การขายส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวที่ซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์แหล่งข้อมูลผ่าน [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) และอ่าน [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) เพื่อตรวจสอบสถานะการซ่อนของเซลล์ — คุณสมบัตินี้เป็นแบบอ่านอย่างเดียว ในไฟล์นี้ B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างจะแสดง `False`, `True`, และ `True` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการพล็อต: คงเวิร์กบุ๊กที่ฝังไว้ด้วย [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) แล้วโหลดใหม่ด้วย [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) เมื่อรวมทุกเซลล์ ให้ใช้ [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) เพื่อคืนช่วงเต็มรวมถึงหมวด “กุมภาพันธ์” ที่ซ่อน การเปลี่ยนค่าสถานะอย่างเดียวไม่เพียงพอให้รีเฟรชข้อมูลแผนภูมิและป้ายหมวดที่แคชไว้ในตัวอย่างนี้

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

        // รีเฟรชข้อมูลแผนภูมิจากเวิร์กบุ๊กที่ฝังอยู่.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // คืนช่วงต้นทางทั้งหมด รวมถึงหมวดที่ซ่อนไว้.
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

ตัวอย่างบันทึกสองเวอร์ชันของการนำเสนอ: หนึ่งเวอร์ชันมีค่า Retail ที่มองเห็นเท่านั้น (10 และ 20) และอีกเวอร์ชันมีค่าทั้งหกค่า รูปด้านล่างแสดงสองโหมดการพล็อต แถวที่ 3 และคอลัมน์ C ยังคงซ่อนในทั้งสองเวิร์กบุ๊กที่ฝังอยู่

| เฉพาะเซลล์ที่มองเห็น (`true`) | เซลล์ทั้งหมด (`false`) |
| --- | --- |
| ![เฉพาะเซลล์ที่มองเห็น: ค่ารetail 10 และ 20 สำหรับเดือนมกราคมและมีนาคม.](hidden_cells_True.png) | ![เซลล์ทั้งหมด: ค่ารetailและการขายส่งสำหรับเดือนมกราคม กุมภาพันธ์ และมีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ว่าง [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) ควบคุมวิธีการแสดงค่าที่หายไป; มันไม่ได้รวมหรือยกเว้นข้อมูลแหล่งที่ซ่อน ดู [ควบคุมการแสดงเซลล์ว่าง](/slides/th/cpp/chart-series/#control-the-display-of-empty-cells) เพื่อดูตัวอย่าง

## **รับช่วงข้อมูลของแผนภูมิ**

ก่อนอัปเดตข้อมูลเวิร์กบุ๊กในงานนำเสนอที่มีอยู่ ให้ตรวจสอบช่วงต้นทางเพื่อระบุว่าเซลล์แผ่นงานใดที่แต่ละแผนภูมิใช้งาน วิธี [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) จะคืนช่วงข้อมูลปัจจุบันในรูปสูตรที่อ้างอิงแผ่นงาน เช่น `Sheet1!$A$1:$D$5` โดย `Sheet1` คือชื่อแผ่นงาน, `!` คั่นกับช่วงเซลล์, และ `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวม ทั้งสัญลักษณ์ `$` แสดงการอ้างอิงแบบสัมบูรณ์

เมธอดนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือเวิร์กบุ๊ก หากแผนภูมิไม่ใช้เวิร์กบุ๊กเป็นแหล่งข้อมูล จะโยนข้อผิดพลาด [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) เพิ่มข้อมูลดูที่ [อ้างอิง API ของ ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/)

ตัวอย่างนี้เปิดงานนำเสนอและตรวจสอบรูปร่างบนแต่ละสไลด์เพื่อหาแผนภูมิ พิมพ์ชื่อแผนภูมิและช่วงต้นทาง หากแผนภูมิไม่ใช้เวิร์กบุ๊ก จะพิมพ์ข้อความและดำเนินการต่อไปยังแผนภูมิถัดไป

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

## **อ่านและเขียนข้อมูลแผนภูมิตจากเวิร์กบุ๊ก**

Aspose.Slides for C++ ให้เมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) และ [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) เพื่ออ่านและเขียนเวิร์กบุ๊กข้อมูลแผนภูมิ (ที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ว่าข้อมูลแผนภูมิต้องจัดระเบียบในรูปแบบเดียวกันหรือมีโครงสร้างใกล้เคียงกับแหล่งข้อมูลต้นฉบับ

ตัวอย่างนี้ใช้การนำเสนอที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรก อ่านเวิร์กบุ๊กที่ฝังไว้เข้าสตรีม ล้างชุดข้อมูลและหมวดที่มีอยู่แล้ว และเขียนเวิร์กบุ๊กเดิมกลับไป การเปลี่ยนแปลงคงอยู่ในหน่วยความจำ; ตัวอย่างไม่ได้บันทึกการนำเสนอ

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

### **ตรวจสอบโครงร่างแผนภูมิหลังการแก้ไขเวิร์กบุ๊ก**

เมื่อแทนที่เวิร์กบุ๊กที่ฝังไว้ด้วยเวิร์กบุ๊กที่แก้ไขแล้ว แผนภูมิจะยังคงรักษาชุดข้อมูลและหมวดเดิม ความไม่ตรงกันนี้อาจทำให้ [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) ล้มเหลวด้วยข้อผิดพลาดดัชนีอยู่นอกช่วง ลบชุดข้อมูลและหมวดเดิมก่อนเขียนเวิร์กบุ๊กที่อัปเดตกลับไปยังแผนภูมิ ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรก คอมเมนต์แสดงตำแหน่งที่จะแก้ไขเวิร์กบุ๊ก; ตัวอย่างที่ทำงานได้เขียนเวิร์กบุ๊กต้นฉบับกลับไปและตรวจสอบโครงร่างในหน่วยความจำ

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

    // แก้ไขสตรีมเวิร์กบุ๊กที่นี่, ตัวอย่างเช่น ใช้ Aspose.Cells.

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

การลบคอลเลกชันจะลบการอ้างอิงข้อมูลที่เก่าออกก่อนที่เวิร์กบุ๊กจะถูกเขียนกลับ สร้างชุดข้อมูลและการแมปหมวดใหม่ตามเวิร์กบุ๊กที่อัปเดตก่อนใช้แผนภูมิ

## **ตั้งค่ารูปแบบตัวเลขแบบกำหนดเองสำหรับเซลล์เวิร์กบุ๊ก**

ใช้ [IChartDataCell::set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) เพื่อควบคุมรูปแบบการแสดงค่าตัวเลขในเวิร์กบุ๊กของแผนภูมิ ตัวอย่างเช่น รายงานอาจต้องการแสดงอัตราการแปลงเป็นเปอร์เซ็นต์ด้วยทศนิยมสี่ตำแหน่งและค่าสัมประสิทธิ์ด้วยทศนิยมห้าตำแหน่ง เก็บค่าเป็นตัวเลขทั้งสองเพื่อให้ยังคงคำนวณและพล็อตได้

รูปแบบตัวเลขเปลี่ยนการแสดงผล ไม่ใช่ค่าที่เก็บไว้ รูปแบบ `0.0000%` แสดง `0.125` เป็น `12.5000%` แต่ไม่เปลี่ยนค่าที่เก็บเป็น `12.5` เช่นเดียวกัน `0.00000` แสดง `0.1234567` เป็น `0.12346` โดยไม่ปัดค่า หากรูปแบบกำหนดเองเป็นสตริงว่าง (`""`) จะใช้รูปแบบที่กำหนดผ่าน [set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) แทน

ตัวอย่างต่อไปสร้างแผนภูมิคอลัมน์และเข้าถึงเซลล์ผ่าน [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) บนแผ่นงาน 0 เซลล์ B2 มีอัตราแปลงและ C2 มีค่าสัมประสิทธิ์ ทั้งคู่เป็นค่าที่ใช้ในแผนภูมิ ตัวอย่างยังเปิดใช้งานป้ายค่าที่เชื่อมกับรูปแบบแหล่งข้อมูล

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

รูปแบบเซลล์เวิร์กบุ๊กแยกจากรูปแบบที่ตั้งโดยตรงบนแกนหรือป้ายข้อมูล ในตัวอย่างนี้แต่ละป้ายแสดงค่าจากเซลล์แหล่งที่มาด้วยการเรียก [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) ด้วย `true` และตามรูปแบบตัวเลขของแหล่งด้วยการเรียก [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) ด้วย `true` หลังบันทึกและเปิดการนำเสนอใหม่ ป้ายจะแสดง `12.5000%` และ `0.12346` ตามที่แสดงด้านล่าง แกนนอนใช้รูปแบบของตนเอง `0.00` กำหนดผ่าน [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberformat/) พร้อม [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isnumberformatlinkedtosource/) เป็น `false`

หากต้องการกำหนดรูปแบบป้ายข้อมูลแยกจากแหล่ง ให้ตั้งค่าสถานะเชื่อมกับแหล่งเป็น `false` แล้วกำหนดรูปแบบผ่าน [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/) วิธีนี้ไม่เปลี่ยนรูปแบบของเซลล์เวิร์กบุ๊ก ตัวอย่างเช่น รูปแบบป้ายอิสระ `0.00` จะทำให้ค่แรกแสดงเป็น `0.13` ในขณะที่ B2 ยังคงแสดง `12.5000%` ดู [Chart Data Labels](/slides/th/cpp/chart-data-label/#set-percentage-sign-with-chart-data-labels) เพื่อเรียนรู้การกำหนดรูปแบบป้ายโดยตรง

![แผนภูมิคอลัมน์พร้อมป้ายที่เชื่อมกับแหล่งแสดง 12.5000% และ 0.12346 และแกนตัวเลขที่จัดรูปแบบแยกต่างหาก.](custom-cell-formats.png)

## **กำหนดเซลล์เวิร์กบุ๊กเป็นป้ายข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์เวิร์กบุ๊กเป็นป้ายข้อมูลแผนภูมิ

ตัวอย่างนี้เพิ่มแผนภูมิบับเบิลกับข้อมูลเริ่มต้นบนสไลด์แรกของงานนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บนแผ่นงาน 0 สำหรับป้ายสามอันแรกของชุดแรก เปิดใช้งานป้ายจากเซลล์และบันทึกงานนำเสนอที่อัปเดต

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

เมธอด [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) ให้เข้าถึงแผ่นงานในเวิร์กบุ๊กของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิเพสกับข้อมูลเริ่มต้นและพิมพ์ชื่อแผ่นงานแต่ละอันลงคอนโซล

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

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3D กับข้อมูลเริ่มต้นและตั้งชื่อชุดข้อมูลสองชุดโดยใช้แหล่งข้อมูลที่ต่างกัน ชื่อแรกใช้สตริงลิตเตอร์ัล; ชื่อที่สองใช้เซลล์ C1 บนแผ่นงาน 0 ตัวนับประเภท [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) เลือกแหล่งสำหรับแต่ละชื่อ ตัวอย่างบันทึกงานนำเสนอพร้อมชื่อชุดข้อมูลที่อัปเดต

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

## **ตรวจจับรูปแบบเวิร์กบุ๊กที่ฝังไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบเวิร์กบุ๊ก Excel แบบไบนารี (.xlsb) ที่อาจฝังในบางแผนภูมิ คุณสามารถใช้เมธอด [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) บน [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) ร่วมกับการนับ [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) เพื่อค้นหารูปแบบที่ไม่รองรับและข้ามแผนภูมินั้น ตัวอย่างตรวจสอบรูปร่างบนสไลด์แรกของงานนำเสนอที่มีอยู่ ข้ามรูปร่างที่ไม่ใช่แผนภูมิ และพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มีเวิร์กบุ๊ก .xlsb ฝังอยู่

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

    // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กแผนภูมิที่รองรับที่นี่.
}
```

## **เวิร์กบุ๊กภายนอก**

Aspose.Slides รองรับการใช้เวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของแผนภูมิ

### **สร้างเวิร์กบุ๊กภายนอก**

ใช้ [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) และ [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) เพื่อส่งออกเวิร์กบุ๊กแผนภูมิที่ฝังเป็นไฟล์และเชื่อมแผนภูมิกับเวิร์กบุ๊กภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิวงกลมกับข้อมูลเริ่มต้นและส่งออกเวิร์กบุ๊กของมัน ปิดสตรีมเอาต์พุตก่อนกำหนดเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของแผนภูมิ แล้วบันทึกงานนำเสนอที่เชื่อมโยง

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

### **ตั้งเวิร์กบุ๊กภายนอก**

โดยใช้เมธอด [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) คุณสามารถกำหนดเวิร์กบุ๊กภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางไปยังเวิร์กบุ๊กภายนอก (หากไฟล์ถูกย้าย)

แม้ว่าจะไม่สามารถแก้ไขข้อมูลในเวิร์กบุ๊กที่จัดเก็บในตำแหน่งระยะไกลหรือแหล่งทรัพยากรได้ คุณยังคงใช้เวิร์กบุ๊กเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางแบบสัมพัทธ์สำหรับเวิร์กบุ๊กภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้เวิร์กบุ๊กภายนอกที่แผ่นงานชื่อ `Sheet1` มีชื่อชุดข้อมูลใน B1, ชื่อหมวดใน A2:A4, และค่าเชิงตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิวงกลม, เชื่อมเวิร์กบุ๊ก, และใช้ [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) เพื่อแมป A1:B4 ให้เป็นชุดข้อมูลหนึ่งชุดและสามหมวด บันทึกงานนำเสนอพร้อมแผนภูมิที่เชื่อมโยง

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

พารามิเตอร์ `updateChartData` ของ [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) ควบคุมว่าจะโหลดเวิร์กบุ๊กหรือไม่

* เมื่อ `updateChartData` เป็น `false` จะอัปเดตเฉพาะเส้นทางเวิร์กบุ๊ก เท่านั้น ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากเวิร์กบุ๊กเป้าหมาย ดังนั้นเวิร์กบุ๊กอาจไม่พร้อมใช้งาน
* เมื่อ `updateChartData` เป็น `true` ข้อมูลแผนภูมิจะอัปเดตจากเวิร์กบุ๊กเป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวแทนพร้อม `updateChartData` เป็น `false` คงข้อมูลเริ่มต้นของแผนภูมิวงกลมและบันทึกงานนำเสนอโดยไม่โหลดเวิร์กบุ๊กที่ไม่พร้อมใช้งาน

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

### **รับเส้นทางเวิร์กบุ๊กแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุเวิร์กบุ๊กที่เชื่อมกับแผนภูมิ ตรวจสอบว่ามีการใช้แหล่งข้อมูลภายนอกหรือไม่และดึงเส้นทางเวิร์กบุ๊กออกมา

ตัวอย่างนี้ตรวจสอบรูปร่างแรกบนสไลด์แรกของงานนำเสนอที่มีเวิร์กบุ๊กภายนอกเชื่อมอยู่ หากเป็นแผนภูมิที่เชื่อมเวิร์กบุ๊กภายนอก ตัวอย่างจะแสดงผลของ [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) บนคอนโซล จากนั้นบันทึกสำเนาของงานนำเสนอ

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

คุณสามารถแก้ไขข้อมูลในเวิร์กบุ๊กภายนอกเช่นเดียวกับการเปลี่ยนแปลงเนื้อหาในเวิร์กบุ๊กภายใน หากเวิร์กบุ๊กภายนอกไม่สามารถโหลดได้ ระบบจะโยนข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและเชื่อมกับเวิร์กบุ๊กภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่รับการสนับสนุนโดยเซลล์ของจุดข้อมูลแรกในชุดแรกเป็น 100 และบันทึกงานนำเสนอที่อัปเดต การแก้ไขค่าซึ่งเซลล์อาจอัปเดตไฟล์ XLSX ภายนอกได้ ดังนั้นควรใช้สำเนา หากต้องการรักษาเวิร์กบุ๊กต้นฉบับไว้

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

### **กู้คืนเวิร์กบุ๊กจากแคชของแผนภูมิ**

หากแผนภูมิเชื่อมกับเวิร์กบุ๊กภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างเวิร์กบุ๊กแผนภูมิใหม่จากข้อมูลที่แคชในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) ตั้งค่าด้วย [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) และเรียก [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) ด้วยค่า `true` ก่อนเปิดงานนำเสนอ

ตัวอย่าง C++ ด้านล่างกู้คืนข้อมูลเวิร์กบุ๊กสำหรับแผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและอ้างอิงเวิร์กบุ๊กภายนอกที่ไม่พร้อมใช้งาน เข้าถึงข้อมูลที่กู้คืนผ่าน [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) และ [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

    // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กที่กู้คืนได้ที่นี่.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

หากเวิร์กบุ๊กภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิด Aspose.Slides จะโยน [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) เปิดใช้การกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิที่แคชเป็นตัวเลือกสำรองที่ยอมรับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในเวิร์กบุ๊กภายนอกหลังจากงานนำเสนออัพเดตครั้งสุดท้าย

## **คำถามที่พบบ่อย**

**สามารถระบุได้ว่าแผนภูมิเฉพาะเจาะจงเชื่อมกับเวิร์กบุ๊กภายนอกหรือเวิร์กบุ๊กที่ฝังอยู่หรือไม่?**

ใช่ แผนภูมิมี [data source type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) หากเป็นเวิร์กบุ๊กภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ามีการใช้ไฟล์ภายนอก

**รองรับเส้นทางแบบสัมพัทธ์ไปยังเวิร์กบุ๊กภายนอกหรือไม่ และจัดเก็บอย่างไร?**

ใช่ หากระบุเส้นทางแบบสัมพัทธ์ ระบบจะเปลี่ยนเป็นเส้นทางสมบัติโดยอัตโนมัติ งานนำเสนอเก็บเส้นทางสมบัติในไฟล์ PPTX ดังนั้นการย้ายเวิร์กบุ๊กอาจต้องอัปเดตลิงก์

**สามารถใช้เวิร์กบุ๊กที่ตั้งอยู่บนทรัพยากรเครือข่าย/แชร์ได้หรือไม่?**

ใช่ เวิร์กบุ๊กเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขเวิร์กบุ๊กระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลได้เท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อตSaving งานนำเสนอหรือไม่?**

งานนำเสนอเก็บ [link to the external file](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) การแก้ไขข้อมูลแผนภูมิที่มาจากเซลล์อาจอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมอยู่ ใช้สำเนาของเวิร์กบุ๊กหากต้องการให้ไฟล์ต้นฉบับคงที่

**ต้องทำอย่างไรหากไฟล์ภายนอกมีการป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัส (เช่นใช้ [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงเวิร์กบุ๊กภายนอกเดียวกันได้หรือไม่?**

ใช่ แต่ละแผนภูมิจัดเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปที่ไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิเมื่อนำเข้าข้อมูลครั้งต่อไป