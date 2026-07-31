---
title: จัดการซีรีส์ข้อมูลแผนภูมิในงานนำเสนอด้วย C++
linktitle: ซีรีส์ข้อมูล
type: docs
url: /th/cpp/chart-series/
keywords:
- ซีรีส์แผนภูมิ
- การซ้อนทับซีรีส์
- สีของซีรีส์
- สีของหมวดหมู่
- ชื่อซีรีส์
- จุดข้อมูล
- ช่องว่างของซีรีส์
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีจัดการซีรีส์แผนภูมิด้วย C++ สำหรับ PowerPoint (PPT/PPTX) พร้อมตัวอย่างโค้ดเชิงปฏิบัติและแนวทางปฏิบัติที่ดีที่สุดเพื่อปรับปรุงการนำเสนอข้อมูลของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายบทบาทของ [ChartSeries](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartseries/) ใน Aspose.Slides โดยมุ่งเน้นที่วิธีการจัดโครงสร้างและการแสดงผลข้อมูลภายในงานนำเสนอ วัตถุเหล่านี้ให้พื้นฐานในการกำหนดชุดข้อมูลจุด, หมวดหมู่และพารามิเตอร์การแสดงผลในแผนภูมิแต่ละรายการ โดยการทำงานกับ [ChartSeries](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/chartseries/) นักพัฒนาสามารถบูรณาการแหล่งข้อมูลพื้นฐานได้อย่างไร้รอยต่อและควบคุมการแสดงผลข้อมูลอย่างเต็มที่ ส่งผลให้งานนำเสนอที่เป็นไดนามิกและขับโดยข้อมูลสื่อสารข้อมูลเชิงลึกและการวิเคราะห์ได้อย่างชัดเจน

ซีรีส์คือแถวหรือคอลัมน์ของตัวเลขที่แสดงบนแผนภูมิ

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าการซ้อนทับของซีรีส์ข้อมูล**

ด้วยวิธีการ [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) คุณสามารถระบุว่าความซ้อนทับของแถบและคอลัมน์บนแผนภูมิ 2D ควรเป็นเท่าใด (ช่วง: -100 ถึง 100) คุณสมบัตินี้ใช้กับซีรีส์ทั้งหมดในกลุ่มซีรีส์แม่: ซึ่งเป็นการสืบทอดคุณสมบัติของกลุ่มที่เหมาะสม

ใช้เมธอด `get_ParentSeriesGroup()::set_Overlap()` เพื่อกำหนดค่าที่คุณต้องการสำหรับ `Overlap`.

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
1. เพิ่มแผนภูมิคอลัมน์แบบกลุ่มบนสไลด์ 
1. เข้าถึงซีรีส์แผนภูมิแรก 
1. เข้าถึง `ParentSeriesGroup` ของซีรีส์แผนภูมิและกำหนดค่าการซ้อนทับที่ต้องการสำหรับซีรีส์ 
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX 

โค้ด C++ นี้แสดงวิธีการตั้งค่าการซ้อนทับสำหรับซีรีส์แผนภูมิ:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// เพิ่มแผนภูมิ
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // ตั้งค่าการซ้อนทับของซีรีส์
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// บันทึกไฟล์งานนำเสนอลงดิสก์
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **เปลี่ยนสีของซีรีส์ข้อมูล**

Aspose.Slides สำหรับ C++ อนุญาตให้คุณเปลี่ยนสีของซีรีส์ได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
1. เพิ่มแผนภูมิบนสไลด์ 
1. เข้าถึงซีรีส์ที่ต้องการเปลี่ยนสี 
1. กำหนดประเภทการเติมและสีการเติมที่ต้องการ 
1. บันทึกงานนำเสนอที่แก้ไข 

โค้ด C++ นี้แสดงวิธีการเปลี่ยนสีของซีรีส์:

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

## **เปลี่ยนสีของหมวดหมู่ซีรีส์ข้อมูล**

Aspose.Slides สำหรับ C++ อนุญาตให้คุณเปลี่ยนสีของหมวดหมู่ซีรีส์ได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
1. เพิ่มแผนภูมิบนสไลด์ 
1. เข้าถึงหมวดหมู่ซีรีส์ที่ต้องการเปลี่ยนสี 
1. กำหนดประเภทการเติมและสีการเติมที่ต้องการ 
1. บันทึกงานนำเสนอที่แก้ไข 

โค้ด C++ นี้แสดงวิธีการเปลี่ยนสีของหมวดหมู่ซีรีส์:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **เปลี่ยนชื่อซีรีส์ข้อมูล**

โดยค่าเริ่มต้น ชื่อในตำนานของแผนภูมิจะมาจากเนื้อหาของเซลล์เหนือแต่ละคอลัมน์หรือแถวของข้อมูล

ในตัวอย่างของเรา (ภาพตัวอย่าง),

* คอลัมน์คือ *Series 1, Series 2,* และ *Series 3*;
* แถวคือ *Category 1, Category 2, Category 3,* และ *Category 4*.

Aspose.Slides สำหรับ C++ อนุญาตให้คุณอัปเดตหรือเปลี่ยนชื่อซีรีส์ในข้อมูลแผนภูมิและตำนานของมัน

โค้ด C++ นี้แสดงวิธีการเปลี่ยนชื่อของซีรีส์ในข้อมูลแผนภูมิ `ChartDataWorkbook`:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

โค้ด C++ นี้แสดงวิธีการเปลี่ยนชื่อของซีรีส์ในตำนานผ่าน`Series`:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **ตั้งค่าสีเติมของซีรีส์ข้อมูล**

Aspose.Slides สำหรับ C++ อนุญาตให้คุณตั้งค่าสีเติมอัตโนมัติสำหรับซีรีส์แผนภูมิภายในพื้นที่พล็อตได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
1. รับอ้างอิงของสไลด์ตามดัชนี 
1. เพิ่มแผนภูมิที่มีข้อมูลเริ่มต้นตามประเภทที่คุณต้องการ (ในตัวอย่างด้านล่างเราใช้ `ChartType::ClusteredColumn`) 
1. เข้าถึงซีรีส์แผนภูมิและตั้งค่าสีเติมเป็น Automatic 
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX 

โค้ด C++ นี้แสดงวิธีการตั้งค่าสีเติมอัตโนมัติสำหรับซีรีส์แผนภูมิ:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// สร้างแผนภูมิคอลัมน์แบบกลุ่ม
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// ตั้งค่ารูปแบบการเติมซีรีส์เป็นอัตโนมัติ
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// บันทึกไฟล์งานนำเสนอลงดิสก์
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **ตั้งค่าการเติมสีย้อนกลับของซีรีส์ข้อมูล**

Aspose.Slides อนุญาตให้คุณตั้งค่าการเติมสีย้อนกลับสำหรับซีรีส์แผนภูมิภายในพื้นที่พล็อตได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
1. รับอ้างอิงของสไลด์ตามดัชนี 
1. เพิ่มแผนภูมิที่มีข้อมูลเริ่มต้นตามประเภทที่คุณต้องการ (ในตัวอย่างด้านล่างเราใช้ `ChartType::ClusteredColumn`) 
1. เข้าถึงซีรีส์แผนภูมิและตั้งค่าสีเติมเป็น invert 
1. บันทึกงานนำเสนอเป็นไฟล์ PPTX 

โค้ด C++ นี้แสดงการทำงาน:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// เพิ่มซีรีส์และหมวดหมู่ใหม่
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// ดึงซีรีส์แผนภูมิแรกและเติมข้อมูลซีรีส์ของมัน
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

## **ตั้งค่าสีเติมย้อนกลับสำหรับซีรีส์แผนภูมิ**

Aspose.Slides อนุญาตให้คุณตั้งค่าการย้อนกลับผ่านเมธอด `IChartDataPoint::set_InvertIfNegative()` และ `ChartDataPoint.set_InvertIfNegative()` เมื่อมีการตั้งค่าการย้อนกลับโดยใช้เมธอดเหล่านี้ จุดข้อมูลจะเปลี่ยนสีเป็นสีตรงกันข้ามเมื่อรับค่าเป็นลบ

โค้ด C++ นี้แสดงการทำงาน:

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

Aspose.Slides สำหรับ C++ อนุญาตให้คุณล้างข้อมูล `DataPoints` สำหรับซีรีส์แผนภูมิเฉพาะได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
2. รับอ้างอิงของสไลด์ผ่านดัชนี 
3. รับอ้างอิงของแผนภูมิผ่านดัชนี 
4. ทำการวนซ้ำผ่าน `DataPoints` ของแผนภูมิทั้งหมดและตั้งค่า `XValue` และ `YValue` ให้เป็น null 
5. ล้าง `DataPoints` ทั้งหมดสำหรับซีรีส์แผนภูมิที่ระบุ 
6. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX 

โค้ด C++ นี้แสดงการทำงาน:

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

## **ตั้งค่าความกว้างช่องว่างของซีรีส์ข้อมูล**

Aspose.Slides สำหรับ C++ อนุญาตให้คุณตั้งค่าความกว้างช่องว่างของซีรีส์ผ่านเมธอด **`set_GapWidth()`** ได้ดังนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/cpp/class/aspose.slides.presentation) 
1. เข้าถึงสไลด์แรก 
1. เพิ่มแผนภูมิที่มีข้อมูลเริ่มต้น 
1. เข้าถึงซีรีส์แผนภูมิใด ๆ 
1. ตั้งค่าคุณสมบัติ `GapWidth` 
1. บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX 

โค้ด C++ นี้แสดงวิธีการตั้งค่าความกว้างช่องว่างของซีรีส์:

```cpp
// สร้างงานนำเสนอเปล่า 
auto presentation = System::MakeObject<Presentation>();

// เข้าถึงสไลด์แรกของงานนำเสนอ
auto slide = presentation->get_Slides()->idx_get(0);

// เพิ่มแผนภูมิกับข้อมูลเริ่มต้น
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ
int32_t worksheetIndex = 0;

// รับแผ่นงานข้อมูลแผนภูมิ
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// เพิ่มซีรีส์
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// เพิ่มหมวดหมู่
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// ดึงซีรีส์แผนภูมิที่สอง
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// เติมข้อมูลซีรีส์
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// ตั้งค่าค่าความกว้างช่องว่าง
series->get_ParentSeriesGroup()->set_GapWidth(50);

// บันทึกงานนำเสนอลงดิสก์
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **คำถามที่พบบ่อย**

**มีขีดจำกัดจำนวนซีรีส์ที่แผนภูมิเดียวสามารถบรรจุได้หรือไม่?**

Aspose.Slides ไม่มีการกำหนดขีดจำกัดคงที่สำหรับจำนวนซีรีส์ที่คุณเพิ่ม ขีดจำกัดโดยปฏิบัติจริงจะถูกกำหนดโดยความสามารถในการอ่านของแผนภูมิและโดยหน่วยความจำที่แอปพลิเคชันของคุณมี

**ถ้าคอลัมน์ภายในกลุ่มใกล้กันเกินไปหรือห่างกันมากเกินไปควรทำอย่างไร?**

ปรับค่าความกว้างช่องว่างสำหรับซีรีส์นั้น (หรือกลุ่มซีรีส์แม่) การเพิ่มค่าจะทำให้ช่องว่างระหว่างคอลัมน์กว้างขึ้น ในขณะที่การลดค่าจะทำให้คอลัมน์เข้าใกล้กันมากขึ้น