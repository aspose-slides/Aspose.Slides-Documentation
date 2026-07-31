---
title: จัดการเวิร์กบุ๊กของแผนภูมิในงานนำเสนอด้วย C++
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
  - PowerPoint
  - งานนำเสนอ
  - C++
  - Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ C++: จัดการเวิร์กบุ๊กของแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อเพิ่มประสิทธิภาพข้อมูลงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับเวิร์กบุ๊กของแผนภูมิใน Aspose.Slides โดยแสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของเวิร์กบุ๊ก, ใช้เซลล์ของเวิร์กบุ๊กเป็นป้ายข้อมูลแผนภูมิ, เข้าถึงคอลเลกชันของแผ่นงาน, และระบุประเภทของแหล่งข้อมูลสำหรับค่าของแผนภูมิ  

บทความยังครอบคลุมการทำงานกับเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีการสร้างและกำหนดเวิร์กบุ๊กภายนอก, ดึงเส้นทางของเวิร์กบุ๊กภายนอกที่เชื่อมโยงกับแผนภูมิ, และแก้ไขข้อมูลแผนภูมิเมื่อเวิร์กบุ๊กพร้อมใช้งาน  

## **อ่านและเขียนข้อมูลแผนภูมิจากเวิร์กบุ๊ก**

Aspose.Slides ให้เมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) และ [WriteWorkbookStream](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) ที่ช่วยให้คุณอ่านและเขียนเวิร์กบุ๊กข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ว่าข้อมูลแผนภูมิต้องถูกจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างคล้ายกับแหล่งข้อมูล  

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

โค้ด C++ นี้แสดงการดำเนินการตั้งค่าเวิร์กบุ๊กข้อมูลแผนภูมิ:  

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

## **กำหนดเซลล์เวิร์กบุ๊กเป็นป้ายข้อมูลแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. เพิ่มแผนภูมิกระจับ (Bubble) พร้อมข้อมูลบางส่วน  
4. เข้าถึงซีรีส์ของแผนภูมิ  
5. กำหนดเซลล์เวิร์กบุ๊กเป็นป้ายข้อมูล  
6. บันทึกการพรีเซนเทชัน  

โค้ด C++ นี้แสดงวิธีการกำหนดเซลล์เวิร์กบุ๊กเป็นป้ายข้อมูลแผนภูมิ:  

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// สร้างอินสแตนซ์ของคลาส Presentation ที่เป็นตัวแทนของไฟล์พรีเซนเทชัน 
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

โค้ด C++ นี้แสดงการดำเนินการที่เมธอด [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) ถูกใช้เพื่อเข้าถึงคอลเลกชันของแผ่นงาน:  

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

โค้ด C++ นี้แสดงวิธีการระบุประเภทสำหรับแหล่งข้อมูล:  

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

## **ตรวจจับรูปแบบเวิร์กบุ๊กฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบเวิร์กบุ๊กไบนารีของ Excel (.xlsb) ที่อาจฝังอยู่ในบางแผนภูมิ คุณสามารถใช้เมธอด `get_EmbeddedWorkbookType` บน [IChartData](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdata/) ร่วมกับการนับค่า [WorkbookType](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมินั้นได้  

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
        // เวิร์กบุ๊กที่ฝังอยู่เป็นรูปแบบ .xlsb ซึ่งไม่รองรับ.
        continue;
    }

    // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กของแผนภูมิที่นี่.
}
```

## **เวิร์กบุ๊กภายนอก**

{{% alert color="primary" %}} 
ใน [Aspose.Slides](https://releases.aspose.com/slides/th/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4 เราได้เพิ่มการสนับสนุนเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ
{{% /alert %}} 

### **สร้างเวิร์กบุ๊กภายนอก**

โดยใช้เมธอด **`ReadWorkbookStream`** และ **`SetExternalWorkbook`** คุณสามารถสร้างเวิร์กบุ๊กภายนอกตั้งแต่เริ่มต้นหรือทำให้เวิร์กบุ๊กภายในกลายเป็นภายนอกได้  

โค้ด C++ นี้แสดงกระบวนการสร้างเวิร์กบุ๊กภายนอก:  

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

### **กำหนดเวิร์กบุ๊กภายนอก**

โดยใช้เมธอด **`IChartData::SetExternalWorkbook`** คุณสามารถกำหนดเวิร์กบุ๊กภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถใช้อัปเดตเส้นทางของเวิร์กบุ๊กภายนอก (หากไฟล์นั้นถูกย้าย) ด้วย  

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในเวิร์กบุ๊กที่จัดเก็บในตำแหน่งหรือทรัพยากรระยะไกลได้ แต่คุณยังสามารถใช้เวิร์กบุ๊กเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากมีการระบุเส้นทางสัมพัทธ์สำหรับเวิร์กบุ๊กภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ  

โค้ด C++ นี้แสดงวิธีการกำหนดเวิร์กบุ๊กภายนอก:  

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

พารามิเตอร์ `updateChartData` (ภายใต้เมธอด `SetExternalWorkbook`) ใช้กำหนดว่าจะโหลดเวิร์กบุ๊ก Excel หรือไม่  

* เมื่อค่าของ `updateChartData` ถูกตั้งเป็น `false` จะมีการอัปเดตเฉพาะเส้นทางของเวิร์กบุ๊ก — ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากเวิร์กบุ๊กเป้าหมาย คุณอาจใช้การตั้งค่านี้เมื่อเวิร์กบุ๊กเป้าหมายไม่มีหรือไม่พร้อมใช้งาน  
* เมื่อค่าของ `updateChartData` ถูกตั้งเป็น `true` ข้อมูลแผนภูมิจะอัปเดตจากเวิร์กบุ๊กเป้าหมาย  

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **รับเส้นทางเวิร์กบุ๊กแหล่งข้อมูลภายนอกของแผนภูมิ**

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/aspose.slides/presentation/)  
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน  
3. สร้างอ็อบเจ็กต์สำหรับรูปร่างแผนภูมิ  
4. สร้างอ็อบเจ็กต์สำหรับประเภทแหล่งข้อมูล (`ChartDataSourceType`) ที่แสดงถึงแหล่งข้อมูลของแผนภูมิ  
5. ระบุเงื่อนไขที่เกี่ยวข้องโดยอิงจากประเภทแหล่งข้อมูลที่เหมือนกับประเภทแหล่งข้อมูลเวิร์กบุ๊กภายนอก  

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

// บันทึกการพรีเซนเทชัน
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในเวิร์กบุ๊กภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงเนื้อหาของเวิร์กบุ๊กภายใน เมื่อเวิร์กบุ๊กภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น  

โค้ด C++ นี้เป็นการนำกระบวนการที่อธิบายไปใช้:  

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **คำถามยอดนิยม**

**ฉันสามารถกำหนดได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับเวิร์กบุ๊กภายนอกหรือเวิร์กบุ๊กที่ฝังอยู่?**  
ได้. แผนภูมิมี [data source type](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); หากแหล่งข้อมูลเป็นเวิร์กบุ๊กภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่าใช้ไฟล์ภายนอกได้  

**รองรับเส้นทางสัมพัทธ์ไปยังเวิร์กบุ๊กภายนอกหรือไม่ และจะจัดเก็บอย่างไร?**  
ใช่. หากคุณระบุเส้นทางสัมพัทธ์ ระบบจะเปลี่ยนเป็นเส้นทางแบบเต็มโดยอัตโนมัติ สิ่งนี้สะดวกสำหรับการพกพาโปรเจค; อย่างไรก็ตามต้องทราบว่าการพรีเซนเทชันจะเก็บเส้นทางเต็มในไฟล์ PPTX  

**ฉันสามารถใช้เวิร์กบุ๊กที่อยู่บนทรัพยากร/แชร์เครือข่ายได้หรือไม่?**  
ได้, เวิร์กบุ๊กดังกล่าวสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขเวิร์กบุ๊กระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลเท่านั้น  

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกการพรีเซนเทชันหรือไม่?**  
ไม่. การพรีเซนเทชันจะเก็บ [link to the external file](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) และใช้เพื่ออ่านข้อมูล ไฟล์ภายนอกเองจะไม่ถูกแก้ไขเมื่อบันทึกการพรีเซนเทชัน  

**ฉันควรทำอย่างไรหากไฟล์ภายนอกมีการป้องกันด้วยรหัสผ่าน?**  
Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีที่พบบ่อยคือการลบการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถูกถอดรหัส (เช่น ใช้ [Aspose.Cells](/cells/cpp/)) แล้วเชื่อมโยงไปยังสำเนานั้น  

**หลายแผนภูมิสามารถอ้างอิงเวิร์กบุ๊กภายนอกเดียวกันได้หรือไม่?**  
ได้. แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิในครั้งต่อไปที่โหลดข้อมูล  