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
description: "ค้นพบ Aspose.Slides สำหรับ C++: จัดการเวิร์กบุ๊คแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลการนำเสนอของคุณ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับเวิร์กบุ๊คของแผนภูมิใน Aspose.Slides แสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของเวิร์กบุ๊ค ใช้เซลล์ของเวิร์กบุ๊คเป็นป้ายข้อมูลแผนภูมิ เข้าถึงคอลเลกชันของแผ่นงาน และกำหนดประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับเวิร์กบุ๊คภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดเวิร์กบุ๊คภายนอกจากศูนย์หรือเปลี่ยนเวิร์กบุ๊คภายในให้เป็นภายนอก ดึงเส้นทางของเวิร์กบุ๊คภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อเวิร์กบุ๊คพร้อมใช้งาน

## **อ่านและเขียนข้อมูลแผนภูมิจากเวิร์กบุ๊ค**

Aspose.Slides มีเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) และ [WriteWorkbookStream](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) ที่ช่วยให้คุณอ่านและเขียนเวิร์กบุ๊คข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **Note** ข้อมูลแผนภูมิต้องจัดเรียงในลักษณะเดิมหรือมีโครงสร้างคล้ายกับต้นฉบับ

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

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

โค้ด C++ นี้แสดงการตั้งค่าเวิร์กบุ๊คข้อมูลแผนภูมิ:

``` cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto pres = MakeObject<Presentation>(u"Test.pptx");

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 500.0f, 400.0f);
chart->get_ChartData()->get_ChartDataWorkbook()->Clear(0);

// อ่านเวิร์กบุ๊คที่เตรียมไว้ใน Excel (หรือใน Aspose.Cells) และตั้งเป็นเวิร์กบุ๊คข้อมูลของแผนภูมิ.
auto workbookData = File::ReadAllBytes(u"a1.xlsx");
auto workbookStream = MakeObject<MemoryStream>(workbookData);

chart->get_ChartData()->WriteWorkbookStream(workbookStream);

chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$B$9");
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);
pres->Save(u"response2.pptx", SaveFormat::Pptx);
```

## **ตั้งค่าเซลล์ของเวิร์กบุ๊คเป็นป้ายข้อมูลแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
1. ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน  
1. เพิ่มแผนภูมิบับเบิลพร้อมข้อมูลบางส่วน  
1. เข้าถึงซีรีส์ของแผนภูมิ  
1. ตั้งค่าเซลล์ของเวิร์กบุ๊คเป็นป้ายข้อมูล  
1. บันทึกการนำเสนอ  

โค้ด C++ นี้แสดงวิธีการตั้งค่าเซลล์ของเวิร์กบุ๊คเป็นป้ายข้อมูลแผนภูมิ:

``` cpp
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

// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์การนำเสนอ 
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

โค้ด C++ นี้แสดงการดำเนินการที่ใช้เมธอด [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) เพื่อเข้าถึงคอลเลกชันของแผ่นงาน:

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

## **กำหนดประเภทแหล่งข้อมูล**

โค้ด C++ นี้แสดงวิธีการกำหนดประเภทสำหรับแหล่งข้อมูล:

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

## **ตรวจจับรูปแบบเวิร์กบุ๊คที่ฝังและไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบเวิร์กบุ๊คไบนารีของ Excel (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้เมธอด `get_EmbeddedWorkbookType` บน [IChartData](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น

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
        // เวิร์กบุ๊คที่ฝังอยู่เป็นรูปแบบ .xlsb ซึ่งไม่รองรับ.
        continue;
    }

    // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊คของแผนภูมิกับที่นี่.
}
```

## **เวิร์กบุ๊คภายนอก**

{{% alert color="info" %}} 
ใน [Aspose.Slides](https://releases.aspose.com/slides/th/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4 เราได้เพิ่มการสนับสนุนเวิร์กบุ๊คภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ
{{% /alert %}} 

### **สร้างเวิร์กบุ๊คภายนอก**

โดยใช้เมธอด **`ReadWorkbookStream`** และ **`SetExternalWorkbook`** คุณสามารถสร้างเวิร์กบุ๊คภายนอกจากศูนย์หรือเปลี่ยนเวิร์กบุ๊คภายในให้เป็นภายนอกได้

โค้ด C++ นี้แสดงกระบวนการสร้างเวิร์กบุ๊คภายนอก:

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

### **ตั้งค่าเวิร์กบุ๊คภายนอก**

โดยใช้เมธอด **`IChartData::SetExternalWorkbook`** คุณสามารถกำหนดเวิร์กบุ๊คภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลของมันได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางของเวิร์กบุ๊คภายนอก (หากไฟล์ดังกล่าวถูกย้าย)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในเวิร์กบุ๊คที่เก็บในตำแหน่งหรือทรัพยากรระยะไกลได้ แต่คุณยังสามารถใช้เวิร์กบุ๊คเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพัทธ์สำหรับเวิร์กบุ๊คภายนอก ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

โค้ด C++ นี้แสดงวิธีการตั้งค่าเวิร์กบุ๊คภายนอก:

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

พารามิเตอร์ `updateChartData` (ภายใต้เมธอด `SetExternalWorkbook`) ใช้เพื่อระบุว่าจะโหลดเวิร์กบุ๊ค Excel หรือไม่

* เมื่อค่า `updateChartData` ตั้งเป็น `false` จะอัปเดตเฉพาะเส้นทางของเวิร์กบุ๊คเท่านั้น — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากเวิร์กบุ๊คเป้าหมาย คุณอาจต้องการใช้การตั้งค่านี้เมื่อเวิร์กบุ๊คเป้าหมายไม่มีหรือไม่สามารถเข้าถึงได้  
* เมื่อค่า `updateChartData` ตั้งเป็น `true` ข้อมูลแผนภูมิจะได้รับการอัปเดตจากเวิร์กบุ๊คเป้าหมาย

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

### **ดึงเส้นทางเวิร์กบุ๊คแหล่งข้อมูลภายนอกจากแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
1. ดึงอ้างอิงของสไลด์ผ่านดัชนีของมัน  
1. สร้างอ็อบเจกต์สำหรับรูปร่างแผนภูมิ  
1. สร้างอ็อบเจกต์สำหรับประเภทของแหล่ง (`ChartDataSourceType`) ที่เป็นตัวแทนแหล่งข้อมูลของแผนภูมิ  
1. ระบุเงื่อนไขที่เกี่ยวข้องโดยอ้างอิงจากประเภทของแหล่งที่เป็นประเภทเดียวกับแหล่งข้อมูลเวิร์กบุ๊คภายนอก  

โค้ด C++ นี้แสดงการดำเนินการ:

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

// บันทึกการนำเสนอ
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในเวิร์กบุ๊คภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาในเวิร์กบุ๊คภายใน เมื่อไม่สามารถโหลดเวิร์กบุ๊คภายนอก ระบบจะโยนข้อยกเว้น

โค้ด C++ นี้เป็นการนำกระบวนการที่อธิบายไปใช้:

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

### **กู้คืนเวิร์กบุ๊คจากแคชของแผนภูมิ**

หากแผนภูมิกำลังใช้เวิร์กบุ๊คภายนอกที่หายไปหรือไม่สามารถเข้าถึงได้ Aspose.Slides สามารถสร้างเวิร์กบุ๊คของแผนภูมิใหม่จากข้อมูลที่เก็บไว้ในแคชของการนำเสนอ สร้างอ็อบเจกต์ [LoadOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/), ตั้งค่าโดยใช้ [set_SpreadsheetOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), และเรียก [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) ด้วยค่า `true` ก่อนเปิดการนำเสนอ

ตัวอย่าง C++ ด้านล่างเปิดการนำเสนอที่แผนภูมิอ้างอิงเวิร์กบุ๊คภายนอกที่ไม่พร้อมใช้งานและเข้าถึงข้อมูลที่กู้คืนผ่าน [IChart::get_ChartData](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/get_chartdata/) และ [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

หากเวิร์กบุ๊คภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิดใช้งาน Aspose.Slides จะโยน `System::InvalidOperationException` ให้เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิค้างเป็นทางเลือกที่ยอมรับได้ เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในเวิร์กบุ๊คภายนอกหลังจากการนำเสนอได้รับการอัปเดตครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันสามารถระบุได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับเวิร์กบุ๊คภายนอกหรือที่ฝังอยู่?**

ใช่ แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) หากแหล่งเป็นเวิร์กบุ๊คภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ากำลังใช้ไฟล์ภายนอก

**รองรับเส้นทางสัมพัทธ์ไปยังเวิร์กบุ๊คภายนอกจากหรือไม่ และจัดเก็บอย่างไร?**

ใช่ หากคุณระบุเส้นทางสัมพัทธ์ ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ สิ่งนี้สะดวกสำหรับการพกพาโปรเจกต์; อย่างไรก็ตามต้องระวังว่าการนำเสนอจะเก็บเส้นทางเต็มไว้ในไฟล์ PPTX

**ฉันสามารถใช้เวิร์กบุ๊คที่ตั้งอยู่บนทรัพยากร/แชร์ในเครือข่ายได้หรือไม่?**

ได้ เวิร์กบุ๊คเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขเวิร์กบุ๊คในระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลได้เท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกการนำเสนอหรือไม่?**

ไม่ การนำเสนอเก็บ [link to the external file](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) แล้วใช้เพื่ออ่านข้อมูล ไฟล์ภายนอกเองจะไม่ถูกแก้ไขเมื่อบันทึกการนำเสนอ

**ควรทำอย่างไรหากไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีทั่วไปคือการลบการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น การใช้ [Aspose.Cells](/cells/cpp/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงเวิร์กบุ๊คภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนให้แต่ละแผนภูมิเห็นในการโหลดข้อมูลครั้งต่อไป