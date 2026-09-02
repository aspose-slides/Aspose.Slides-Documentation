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
- ป้ายข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- สมุดงานภายนอก
- ข้อมูลภายนอก
- แคชของแผนภูมิ
- การกู้คืนสมุดงาน
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ C++: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อทำให้ข้อมูลการนำเสนอของคุณเป็นระเบียบ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับสมุดงานแผนภูมิใน Aspose.Slides โดยแสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของสมุดงาน, ใช้เซลล์ของสมุดงานเป็นป้ายข้อมูลแผนภูมิ, เข้าถึงคอลเลกชัน Worksheet, และระบุประเภทของแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดสมุดงานภายนอก, การดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ, และการแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides ให้บริการเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) และ [WriteWorkbookStream](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) ที่ช่วยให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งเป็นข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดเรียงในลักษณะเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูล

``` cpp
auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

โค้ด C++ นี้แสดงการตั้งค่าสมุดงานข้อมูลแผนภูมิ:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Charts::ChartType::Pie, 50.0f, 50.0f, 500.0f, 400.0f);
chart->get_ChartData()->get_ChartDataWorkbook()->Clear(0);

intrusive_ptr<Aspose::Cells::IWorkbook> workbook;
try
{
    workbook = Aspose::Cells::Factory::CreateIWorkbook(new String("a1.xlsx"));
}
catch (Aspose::Cells::Systems::Exception& ex)
{
    System::Console::Write(System::String::FromWCS(ex.GetMessageExp()->value()));
}

intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
workbook->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);

cellsOutputStream->SetPosition(0);
System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);

chart->get_ChartData()->WriteWorkbookStream(msout);

chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$B$9");
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);
pres->Save(u"response2.pptx", Export::SaveFormat::Pptx);
```

## **ตั้งค่าเซลล์ของ WorkBook เป็นป้ายข้อมูลแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มแผนภูมิ Bubble พร้อมข้อมูลบางส่วน  
4. เข้าถึงซีรีส์ของแผนภูมิ  
5. ตั้งค่าเซลล์ของสมุดงานเป็นป้ายข้อมูล  
6. บันทึกการนำเสนอ  

โค้ด C++ นี้แสดงวิธีตั้งค่าเซลล์ของสมุดงานเป็นป้ายข้อมูลแผนภูมิ:

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงถึงไฟล์การนำเสนอ 
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

## **จัดการ Worksheet**

โค้ด C++ นี้แสดงการดำเนินการที่ใช้เมธอด [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) เพื่อเข้าถึงคอลเลกชัน Worksheet:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **ระบุประเภทของแหล่งข้อมูล**

โค้ด C++ นี้แสดงวิธีระบุประเภทสำหรับแหล่งข้อมูล:

```c++
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

## **ตรวจจับรูปแบบสมุดงานที่ฝังอยู่ที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel binary (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้เมธอด `get_EmbeddedWorkbookType` บน [IChartData](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/) ร่วมกับ enumeration [WorkbookType](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/workbooktype/) เพื่อดักจับรูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
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
        // สมุดงานที่ฝังอยู่ในรูปแบบ .xlsb ซึ่งไม่รองรับ
        continue;
    }

    // อ่านหรือแก้ไขข้อมูลสมุดงานของแผนภูมิที่นี่.
}
```

## **สมุดงานภายนอก**

{{% alert color="primary" %}} 
ใน [Aspose.Slides](https://releases.aspose.com/slides/th/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4 เราได้เพิ่มการสนับสนุนสมุดงานภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ
{{% /alert %}} 

### **สร้างสมุดงานภายนอก**

ด้วยเมธอด **`ReadWorkbookStream`** และ **`SetExternalWorkbook`** คุณสามารถสร้างสมุดงานภายนอกจากศูนย์หรือทำให้สมุดงานภายในกลายเป็นภายนอกได้

โค้ด C++ นี้แสดงกระบวนการสร้างสมุดงานภายนอก:

```c++
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

### **ตั้งสมุดงานภายนอก**

โดยใช้เมธอด **`IChartData::SetExternalWorkbook`** คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถใช้อัปเดตเส้นทางไปยังสมุดงานภายนอก (หากไฟล์ถูกย้าย)

แม้ว่าจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่จัดเก็บในตำแหน่งระยะไกลหรือทรัพยากรได้ แต่คุณยังคงใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพันธ์สำหรับสมุดงานภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

โค้ด C++ นี้แสดงวิธีตั้งสมุดงานภายนอก:

```c++
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

พารามิเตอร์ `updateChartData` (ภายใต้เมธอด `SetExternalWorkbook`) ใช้เพื่อกำหนดว่าจะโหลดสมุดงาน Excel หรือไม่  

* เมื่อค่าของ `updateChartData` เป็น `false` จะอัปเดตเฉพาะเส้นทางของสมุดงาน — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากสมุดงานเป้าหมาย คุณอาจใช้การตั้งค่านี้เมื่อต้องการทำงานกับสมุดงานเป้าหมายที่ไม่มีหรือไม่พร้อมใช้งาน  
* เมื่อค่าของ `updateChartData` เป็น `true` ข้อมูลแผนภูมิจะอัปเดตจากสมุดงานเป้าหมาย

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **รับเส้นทางของสมุดงานแหล่งข้อมูลภายนอกจากแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจ็กต์สำหรับรูปแบบแผนภูมิ  
4. สร้างอ็อบเจ็กต์สำหรับประเภทแหล่งข้อมูล (`ChartDataSourceType`) ที่แสดงถึงแหล่งข้อมูลของแผนภูมิ  
5. ระบุเงื่อนไขที่เกี่ยวข้องตามประเภทแหล่งข้อมูลที่เป็นประเภทเดียวกับแหล่งข้อมูลสมุดงานภายนอก  

โค้ด C++ นี้แสดงการดำเนินการ:

```c++
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

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาของสมุดงานภายใน เมื่อสมุดงานภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

โค้ด C++ นี้เป็นการดำเนินการตามกระบวนการที่อธิบายไว้:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **กู้คืนสมุดงานจากแคชของแผนภูมิ**

หากแผนภูมิใช้สมุดงานภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างสมุดงานแผนภูมิจากข้อมูลที่แคชไว้ในพรีเซนเทชันได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/), ตั้งค่าโดยใช้ [set_SpreadsheetOptions](https://reference.aspose.com/slides/th/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), แล้วเรียก [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) ด้วยค่า `true` ก่อนเปิดพรีเซนเทชัน

ตัวอย่าง C++ ต่อไปนี้เปิดพรีเซนเทชันที่แผนภูมิอ้างอิงสมุดงานภายนอกที่ไม่พร้อมใช้งานและเข้าถึงข้อมูลที่กู้คืนผ่าน [IChart::get_ChartData](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/get_chartdata/) และ [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// อ่านหรือแก้ไขข้อมูลสมุดงานที่กู้คืนที่นี่.

presentation->Dispose();
```

หากสมุดงานภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิดใช้งาน Aspose.Slides จะโยน `System::InvalidOperationException` เปิดใช้งานการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิที่แคชมเป็นวิธีสำรองที่ยอมรับได้ เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำกับสมุดงานภายนอกหลังจากพรีเซนเทชันอัปเดตครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันสามารถตรวจสอบได้หรือไม่ว่าแผนภูมิใดเชื่อมโยงกับสมุดงานภายนอกหรือสมุดงานที่ฝังอยู่?**  
ใช่ แผนภูมิมี [ประเภทแหล่งข้อมูล](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) และ [เส้นทางไปยังสมุดงานภายนอก](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) หากแหล่งเป็นสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าไฟล์ภายนอกกำลังถูกใช้

**รองรับเส้นทางสัมพันธ์ไปยังสมุดงานภายนอกหรือไม่ และจะจัดเก็บอย่างไร?**  
ใช่ หากคุณระบุเส้นทางสัมพันธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ ซึ่งสะดวกต่อการพกพาโครงการ; อย่างไรก็ตามพรีเซนเทชันจะบันทึกเส้นทางเต็มไว้ในไฟล์ PPTX

**ฉันสามารถใช้สมุดงานที่อยู่บนทรัพยากร/แชร์เครือข่ายได้หรือไม่?**  
ได้ สมุดงานเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม Aspose.Slides ไม่รองรับการแก้ไขสมุดงานระยะไกลโดยตรง – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกพรีเซนเทชันหรือไม่?**  
ไม่ พรีเซนเทชันจะเก็บ [ลิงก์ไปยังไฟล์ภายนอก](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) และใช้ลิงก์นั้นเพื่ออ่านข้อมูล ไฟล์ภายนอกเองจะไม่ถูกแก้ไขเมื่อบันทึกพรีเซนเทชัน

**จะทำอย่างไรหากไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**  
Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการลิงก์ วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัส (เช่นโดยใช้ [Aspose.Cells](/cells/cpp/)) แล้วลิงก์ไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**  
ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดอ้างอิงไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งต่อไปที่โหลดข้อมูล