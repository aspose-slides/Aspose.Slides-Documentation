---
title: จัดการสมุดงานแผนภูมิในพรีเซนเทชันโดยใช้ C++
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
- พรีเซนเทชัน
- C++
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ C++: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อทำให้ข้อมูลพรีเซนเทชันของคุณเป็นระบบระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดงานแผนภูมิใน Aspose.Slides โดยแสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิโดยใช้สตรีมของสมุดงาน ใช้เซลล์ของสมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ เข้าถึงคอลเลกชันของแผ่นงาน และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

บทความนี้ยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีการสร้างและกำหนดสมุดงานภายนอก การดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ และการแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides ให้บริการเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) และ [WriteWorkbookStream](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) ที่ช่วยให้คุณสามารถอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **Note** ว่าข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งข้อมูล

``` cpp
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slide(0)->get_Shape(0));
auto data = chart->get_ChartData();

auto = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

### **ตรวจสอบโครงสร้างแผนภูมิหลังการแก้ไขสมุดงาน**

เมื่อคุณแทนที่สมุดงานที่ฝังอยู่ด้วยสมุดงานที่แก้ไขแล้ว แผนภูมิจะยังคงรักษาชุดข้อมูลและประเภทของหมวดหมู่เดิมไว้ ความไม่ตรงกันนี้อาจทำให้ [IChart::ValidateChartLayout](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/validatechartlayout/) ล้มเหลวด้วยข้อผิดพลาด out-of-range ให้ล้างชุดข้อมูลและหมวดหมู่ที่มีอยู่ก่อนที่จะเขียนสมุดงานที่อัปเดตกลับไปยังแผนภูมิ

```cpp
// หลังจากการแก้ไขสตรีมของสมุดงาน (เช่น การใช้ Aspose.Cells)
auto updatedWorkbook = chartData->ReadWorkbookStream();

// ล้างการอ้างอิงข้อมูลที่มีอยู่.
chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

updatedWorkbook->set_Position(0);
chartData->WriteWorkbookStream(updatedWorkbook);

chart->ValidateChartLayout();
```

การล้างคอลเลกชันช่วยให้โครงสร้างข้อมูลแผนภูมิตรงกันกับสมุดงานใหม่ ทำให้ `ValidateChartLayout` ทำงานสำเร็จโดยไม่มีข้อผิดพลาด

## **ตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/) 
1. รับอ้างอิงสไลด์ผ่านดัชนีของมัน
1. เพิ่มแผนภูมิ Bubble พร้อมข้อมูลบางส่วน
1. เข้าถึงซีรีส์ของแผนภูมิ
1. ตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูล
1. บันทึกพรีเซนเทชัน

โค้ด C++ ตัวอย่างต่อไปนี้แสดงวิธีตั้งค่าเซลล์สมุดงานเป็นป้ายกำกับข้อมูลแผนภูมิ:

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
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์พรีเซนเทชัน
auto pres = System::MakeObject<Presentation>(u"chart2.pptx");

auto slide = pres->get_Slides()->idx_get(0);

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Bubble, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto series = chart->get_ChartData()->get_Series();

series->idx_get(0)->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

series->idx_get(0)->get_Labels()->idx_get(0)->set_ValueFromCell(wb->GetCell(0, u"A10", System::ObjectExt::Box<System::String>(lbl0)));
series->idx_get(0)->get_Labels()->idx_get(1)->set_ValueFromCell(wb->GetCell(0, u"A11", System::ObjectExt::Box<System::String>(lbl1)));
series->idx_get(0)->get_Labels()->idx_get(2)->set_ValueFromCell(wb->GetCell(0, u"A12", System::ObjectExt::Box<System::String>(lbl2)));

pres->Save(u"resultchart.pptx", SaveFormat::Pptx);
```

## **จัดการแผ่นงาน**

โค้ด C++ ตัวอย่างต่อไปนี้สาธิตการดำเนินการที่ใช้เมธอด [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) เพื่อเข้าถึงคอลเลกชันของแผ่นงาน:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **ระบุประเภทแหล่งข้อมูล**

โค้ด C++ ตัวอย่างต่อไปนี้แสดงวิธีระบุประเภทสำหรับแหล่งข้อมูล:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto chartData = chart->get_ChartData();
auto val = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

val->set_DataSourceType(DataSourceType::StringLiterals);
val->set_Data(System::ObjectExt::Box<System::String>(u"LiteralString"));
val = chartData->get_Series()->idx_get(1)->get_Name();
val->set_Data(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1", System::ObjectExt::Box<System::String>(u"NewCell")));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **ตรวจจับรูปแบบสมุดงานที่ฝังอยู่ซึ่งไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้เมธอด `get_EmbeddedWorkbookType` บน [IChartData](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/) พร้อมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/ISlide.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : System::IterateOver(slide->get_Shapes()))
{
    if (!System::ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = System::ExplicitCast<IChart>(shape);
    auto chartData = chart->get_ChartData();

    if (chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook &&
        chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro)
    {
        // สมุดงานที่ฝังอยู่เป็นรูปแบบ .xlsb ซึ่งไม่รองรับ.
        continue;
    }

    // อ่านหรือแก้ไขข้อมูลสมุดงานของแผนภูมิที่นี่.
}
```

## **สมุดงานภายนอก**

{{% alert color="info" %}} 
ใน [Aspose.Slides](https://releases.aspose.com/slides/th/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) รุ่น 19.4 เราได้เพิ่มการสนับสนุนสมุดงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ
{{% /alert %}} 

### **สร้างสมุดงานภายนอก**

โดยใช้เมธอด **`ReadWorkbookStream`** และ **`SetExternalWorkbook`** คุณสามารถสร้างสมุดงานภายนอกจากศูนย์หรือทำให้สมุดงานภายในกลายเป็นภายนอก

โค้ด C++ ตัวอย่างต่อไปนี้สาธิตกระบวนการสร้างสมุดงานภายนอก:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

const System::String workbookPath = u"externalWorkbook1.xlsx";

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f);
auto chartData = chart->get_ChartData();

{
    System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(workbookPath, System::IO::FileMode::Create);

    System::ArrayPtr<uint8_t> workbookData = chartData->ReadWorkbookStream()->ToArray();
    fileStream->Write(workbookData, 0, workbookData->get_Length());
}

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(workbookPath));

pres->Save(u"externalWorkbook.pptx", SaveFormat::Pptx);
```

### **กำหนดสมุดงานภายนอก**

โดยใช้เมธอด **`IChartData::SetExternalWorkbook`** คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถใช้อัปเดตเส้นทางไปยังสมุดงานภายนอก (หากไฟล์ดังกล่าวถูกย้าย)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่เก็บอยู่ในตำแหน่งระยะไกลหรือทรัพยากรได้ แต่คุณยังสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางแบบสัมพันธ์สำหรับสมุดงานภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

โค้ด C++ ตัวอย่างต่อไปนี้แสดงวิธีกำหนดสมุดงานภายนอก:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, false);
auto chartData = chart->get_ChartData();

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(u"externalWorkbook.xlsx"));

chartData->get_Series()->Add(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1"), ChartType::Pie);
auto dataPoints = chartData->get_Series()->idx_get(0)->get_DataPoints();
auto workbook = chartData->get_ChartDataWorkbook();
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B2"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B3"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B4"));

auto categories = chartData->get_Categories();
categories->Add(workbook->GetCell(0, u"A2"));
categories->Add(workbook->GetCell(0, u"A3"));
categories->Add(workbook->GetCell(0, u"A4"));
pres->Save(u"Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
```

พารามิเตอร์ `updateChartData` (ภายใต้เมธอด `SetExternalWorkbook`) ใช้ระบุว่าจะโหลดสมุดงาน Excel หรือไม่  

* เมื่อค่าของ `updateChartData` ตั้งเป็น `false` จะอัปเดตเฉพาะเส้นทางของสมุดงาน — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดงานเป้าหมาย คุณอาจใช้การตั้งค่านี้ในกรณีที่สมุดงานเป้าหมายไม่มีหรือไม่พร้อมใช้งาน  
* เมื่อค่าของ `updateChartData` ตั้งเป็น `true` ข้อมูลแผนภูมิจะอัปเดตจากสมุดงานเป้าหมาย

```c++
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **ดึงเส้นทางของสมุดงานแหล่งข้อมูลภายนอกของแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
1. รับอ้างอิงสไลด์ผ่านดัชนีของมัน  
1. สร้างอ็อบเจ็กต์สำหรับรูปร่างแผนภูมิ  
1. สร้างอ็อบเจ็กต์สำหรับประเภทแหล่งข้อมูล (`ChartDataSourceType`) ที่แทนแหล่งข้อมูลของแผนภูมิ  
1. ระบุเงื่อนไขที่เกี่ยวข้องโดยอิงจากประเภทแหล่งข้อมูลที่เป็นสมุดงานภายนอกเดียวกัน

โค้ด C++ ตัวอย่างต่อไปนี้สาธิตการดำเนินการ:

```c++
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// บันทึกพรีเซนเทชัน
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการแก้ไขเนื้อหาของสมุดงานภายใน เมื่อตัวสมุดงานภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

โค้ด C++ ตัวอย่างต่อไปนี้เป็นการดำเนินการตามที่อธิบายไว้:

```c++
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **กู้คืนสมุดงานจากแคชของแผนภูมิ**

หากแผนภูมิกำลังใช้สมุดงานภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างสมุดงานแผนภูมิจากข้อมูลที่เก็บไว้ในแคชของพรีเซนเทชันได้ สร้างอ็อบเจ็กต์ [LoadOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/), ตั้งค่าโดยใช้เมธอด [set_SpreadsheetOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), แล้วเรียก [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) ด้วยค่า `true` ก่อนเปิดพรีเซนเทชัน

ตัวอย่าง C++ ด้านล่างเปิดพรีเซนเทชันที่แผนภูมิเชื่อมโยงกับสมุดงานภายนอกที่ไม่พร้อมใช้งานและเข้าถึงข้อมูลที่กู้คืนผ่าน [IChart::get_ChartData](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/get_chartdata/) และ [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Read or modify the recovered workbook data here.

presentation->Dispose();
```

หากสมุดงานภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิดใช้งาน Aspose.Slides จะโยน `System::InvalidOperationException` เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิจากแคชเป็นทางเลือกที่ยอมรับได้ เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในสมุดงานภายนอกหลังจากพรีเซนเทชันได้รับการอัปเดตล่าสุด

## **FAQ**

**ฉันสามารถระบุได้หรือไม่ว่าแผนภูมิกำหนดลิงก์ไปยังสมุดงานภายนอกหรือสมุดงานที่ฝังอยู่?**

ได้ แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) หากแหล่งข้อมูลเป็นสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ามีการใช้ไฟล์ภายนอก

**รองรับเส้นทางแบบสัมพันธ์สำหรับสมุดงานภายนอกหรือไม่ และเก็บไว้แบบใด?**

รองรับ หากคุณระบุเส้นทางแบบสัมพันธ์ ระบบจะเปลี่ยนเป็นเส้นทางแบบเต็มโดยอัตโนมัติ ซึ่งช่วยให้โครงการพกพาได้ง่ายขึ้น แต่โปรดทราบว่าพรีเซนเทชันจะเก็บเส้นทางแบบเต็มไว้ในไฟล์ PPTX

**ฉันสามารถใช้สมุดงานที่อยู่บนทรัพยากรเครือข่ายหรือแชร์ไฟล์ได้หรือไม่?**

ได้ สามารถใช้สมุดงานเหล่านี้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกพรีเซนเทชันหรือไม่?**

ไม่ พรีเซนเทชันจะเก็บ [link to the external file](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) และใช้ลิงก์นั้นเพื่ออ่านข้อมูล ไฟล์ภายนอกจะไม่ถูกแก้ไขเมื่อพรีเซนเทชันถูกบันทึก

**ถ้าไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่านฉันควรทำอย่างไร?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการลิงก์ วิธีทั่วไปคือการลบการป้องกันล่วงหน้า หรือเตรียมสำเนาที่ถอดรหัส (เช่น โดยใช้ [Aspose.Cells](/cells/cpp/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งต่อไปที่โหลดข้อมูล