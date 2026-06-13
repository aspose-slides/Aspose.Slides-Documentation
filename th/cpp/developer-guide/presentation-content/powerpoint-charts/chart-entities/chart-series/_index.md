---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอโดยใช้ С++
linktitle: ชุดข้อมูล
type: docs
url: /th/cpp/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุดข้อมูล
- สีของชุดข้อมูล
- สีของหมวดหมู่
- ชื่อชุดข้อมูล
- จุดข้อมูล
- ช่องว่างของชุดข้อมูล
- PowerPoint
- งานนำเสนอ
- С++
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิใน С++ สำหรับ PowerPoint (PPT/PPTX) พร้อมตัวอย่างโค้ดเชิงปฏิบัติและแนวปฏิบัติที่ดีที่สุดเพื่อปรับปรุงงานนำเสนอข้อมูลของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายบทบาทของ [ChartSeries](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartseries/) ใน Aspose.Slides โดยมุ่งเน้นที่วิธีการจัดโครงสร้างและการแสดงผลข้อมูลภายในงานนำเสนอ วัตถุเหล่านี้ให้ส่วนประกอบพื้นฐานที่กำหนดชุดข้อมูล จุดข้อมูล หมวดหมู่ และพารามิเตอร์การแสดงผลในแผนภูมิอย่างเป็นรายบุคคล โดยการทำงานกับ [ChartSeries](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartseries/) นักพัฒนาสามารถบูรณาการแหล่งข้อมูลพื้นฐานได้อย่างไร้รอยต่อและควบคุมการแสดงผลข้อมูลได้อย่างเต็มที่ ทำให้ได้งานนำเสนอที่เป็นแบบไดนามิกและขับเคลื่อนด้วยข้อมูลที่สื่อสารข้อมูลเชิงลึกและการวิเคราะห์ได้อย่างชัดเจน

ชุดข้อมูล (Series) คือแถวหรือคอลัมน์ของตัวเลขที่ถูกพล็อตในแผนภูมิ

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของชุดข้อมูล**

ด้วยเมธอด [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) คุณสามารถระบุปริมาณการทับซ้อนของแท่งและคอลัมน์บนแผนภูมิ 2D ได้ (ช่วง: -100 ถึง 100) คุณสมบัตินี้จะใช้กับชุดข้อมูลทั้งหมดในกลุ่มชุดข้อมูลพาเรนท์: นี้เป็นการสะท้อนของคุณสมบัติของกลุ่มที่เหมาะสม

ใช้เมธอด `get_ParentSeriesGroup()::set_Overlap()` เพื่อกำหนดค่าที่คุณต้องการสำหรับ `Overlap`.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
1. เพิ่มแผนภูมิกลัสเตอร์คอลัมน์บนสไลด์ 
1. เข้าถึงชุดข้อมูลแผนภูมิแรก 
1. เข้าถึง `ParentSeriesGroup` ของชุดข้อมูลแผนภูมิและกำหนดค่าการทับซ้อนที่คุณต้องการสำหรับชุดนั้น 
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX 

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Adds chart
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // ตั้งค่าการทับซ้อนของชุดข้อมูล
}

// Writes the presentation file to disk
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **เปลี่ยนสีของชุดข้อมูล**

Aspose.Slides for C++ ช่วยให้คุณเปลี่ยนสีของชุดข้อมูลได้โดยวิธีนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
1. เพิ่มแผนภูมิบนสไลด์ 
1. เข้าถึงชุดข้อมูลที่ต้องการเปลี่ยนสี 
1. กำหนดประเภทการเติมและสีการเติมตามที่คุณต้องการ 
1. บันทึกงานนำเสนอที่แก้ไข 

```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **เปลี่ยนสีของหมวดหมู่ชุดข้อมูล**

Aspose.Slides for C++ ช่วยให้คุณเปลี่ยนสีของหมวดหมู่ชุดข้อมูลได้โดยวิธีนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
1. เพิ่มแผนภูมิบนสไลด์ 
1. เข้าถึงหมวดหมู่ชุดข้อมูลที่ต้องการเปลี่ยนสี 
1. กำหนดประเภทการเติมและสีการเติมตามที่คุณต้องการ 
1. บันทึกงานนำเสนอที่แก้ไข 

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **เปลี่ยนชื่อชุดข้อมูล**

โดยค่าเริ่มต้น ชื่อในเลเจนด์ของแผนภูมิจะเป็นเนื้อหาของเซลล์ที่อยู่เหนือแต่ละคอลัมน์หรือแถวของข้อมูล

ในตัวอย่างของเรา (ภาพตัวอย่าง),

* คอลัมน์คือ *Series 1, Series 2,* และ *Series 3*;
* แถวคือ *Category 1, Category 2, Category 3,* และ *Category 4.* 

Aspose.Slides for C++ ช่วยให้คุณอัปเดตหรือเปลี่ยนชื่อชุดข้อมูลในข้อมูลแผนภูมิและเลเจนด์ได้

โค้ด C++ นี้แสดงวิธีการเปลี่ยนชื่อชุดข้อมูลในข้อมูลแผนภูมิ `ChartDataWorkbook`:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

โค้ด C++ นี้แสดงวิธีการเปลี่ยนชื่อชุดข้อมูลในเลเจนด์ผ่าน`Series`:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **ตั้งค่าสีเติมของชุดข้อมูล**

Aspose.Slides for C++ ช่วยให้คุณตั้งค่าสีเติมอัตโนมัติสำหรับชุดข้อมูลแผนภูมิภายในพื้นที่พล็อตได้โดยวิธีนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
1. รับอ้างอิงของสไลด์ตามดัชนีของมัน 
1. เพิ่มแผนภูมิพร้อมข้อมูลค่าเริ่มต้นตามประเภทที่คุณต้องการ (ในตัวอย่างด้านล่าง เราใช้ `ChartType::ClusteredColumn`) 
1. เข้าถึงชุดข้อมูลแผนภูมิและกำหนดสีเติมเป็น Automatic 
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX 

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// สร้างแผนภูมิกลัสเตอร์คอลัมน์
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// ตั้งค่าฟอร์แมตการเติมของชุดข้อมูลเป็นอัตโนมัติ
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// เขียนไฟล์งานนำเสนอไปยังดิสก์
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **ตั้งค่าสีเติมแบบกลับสีของชุดข้อมูล**

Aspose.Slides ให้คุณตั้งค่าสีเติมแบบกลับสีสำหรับชุดข้อมูลแผนภูมิภายในพื้นที่พล็อตได้โดยวิธีนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
1. รับอ้างอิงของสไลด์ตามดัชนีของมัน 
1. เพิ่มแผนภูมิพร้อมข้อมูลค่าเริ่มต้นตามประเภทที่คุณต้องการ (ในตัวอย่างด้านล่าง เราใช้ `ChartType::ClusteredColumn`) 
1. เข้าถึงชุดข้อมูลแผนภูมิและกำหนดสีเติมเป็น invert 
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX 

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Adds new series and categories
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Takes the first chart series and populates its series data.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```

## **ตั้งค่าสีเติมกลับสีสำหรับชุดข้อมูลแผนภูมิ**

Aspose.Slides ให้คุณตั้งค่าการกลับสีผ่านเมธอด`IChartDataPoint::set_InvertIfNegative()` และ `ChartDataPoint.set_InvertIfNegative()` เมื่อกำหนดการกลับสีโดยใช้เมธอดเหล่านี้ จุดข้อมูลจะกลับสีเมื่อค่าติดลบ 

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```

## **ล้างค่าจุดข้อมูลเฉพาะ**

Aspose.Slides for C++ ช่วยให้คุณล้างข้อมูล `DataPoints` สำหรับชุดข้อมูลแผนภูมิที่ระบุได้โดยวิธีนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
2. รับอ้างอิงของสไลด์ผ่านดัชนีของมัน 
3. รับอ้างอิงของแผนภูมิผ่านดัชนีของมัน 
4. วนลูปผ่าน `DataPoints` ทั้งหมดของแผนภูมิและตั้งค่า `XValue` และ `YValue` เป็น null 
5. ล้าง `DataPoints` ทั้งหมดสำหรับชุดข้อมูลแผนภูมิที่ระบุ 
6. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX 

```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```

## **ตั้งค่าความกว้างช่องว่างของชุดข้อมูล**

Aspose.Slides for C++ ช่วยให้คุณตั้งค่าความกว้างช่องว่างของชุดข้อมูลผ่านเมธอด **`set_GapWidth()`** ได้โดยวิธีนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
1. เข้าถึงสไลด์แรก 
1. เพิ่มแผนภูมิพร้อมข้อมูลค่าเริ่มต้น 
1. เข้าถึงชุดข้อมูลแผนภูมิใดก็ได้ 
1. ตั้งค่าคุณสมบัติ `GapWidth` 
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX 

```cpp
// สร้างงานนำเสนอว่าง
auto presentation = System::MakeObject<Presentation>();

// เข้าถึงสไลด์แรกของงานนำเสนอ
auto slide = presentation->get_Slides()->idx_get(0);

// เพิ่มแผนภูมิพร้อมข้อมูลค่าเริ่มต้น
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ
int32_t worksheetIndex = 0;

// ดึงแผ่นงานข้อมูลแผนภูมิ
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// เพิ่มชุดข้อมูล
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// เพิ่มหมวดหมู่
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// ดึงชุดข้อมูลแผนภูมิที่สอง
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// เติมข้อมูลให้ชุดข้อมูล
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// ตั้งค่าความกว้างช่องว่าง
series->get_ParentSeriesGroup()->set_GapWidth(50);

// บันทึกงานนำเสนอลงดิสก์
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **คำถามที่พบบ่อย**

**Is there a limit to how many series a single chart can contain?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดคงที่สำหรับจำนวนชุดข้อมูลที่คุณเพิ่ม ขีดจำกัดเชิงปฏิบัติกำหนดโดยความอ่านง่ายของแผนภูมิและโดยหน่วยความจำที่แอปพลิเคชันของคุณสามารถใช้ได้

**What if the columns within a cluster are too close together or too far apart?**

ปรับการตั้งค่าความกว้างช่องว่างสำหรับชุดข้อมูลนั้น (หรือกลุ่มชุดข้อมูลพาเรนท์ของมัน) การเพิ่มค่าจะทำให้ช่องว่างระหว่างคอลัมน์กว้างขึ้น ในขณะที่การลดค่าจะทำให้คอลัมน์ใกล้กันมากขึ้น