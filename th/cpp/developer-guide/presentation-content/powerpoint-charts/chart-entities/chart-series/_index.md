---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย C++
linktitle: ชุดข้อมูล
type: docs
url: /th/cpp/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุด
- สีชุด
- สีหมวดหมู่
- ชื่อชุด
- จุดข้อมูล
- ช่องว่างชุด
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์สมุดงาน, การจัดรูปแบบ, การทับซ้อน, ความกว้างช่องว่าง, และค่าติดลบในงานนำเสนอด้วย C++."
---
## **ภาพรวม**

แผนภูมิจัดเก็บข้อมูลที่แสดงผลในสมุดงานข้อมูลของแผนภูมิหนึ่งชุด คำสั่ง [IChartSeries](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ [IChartDataPoint](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapoint/) ในชุดข้อมูลอ้างอิงถึงหนึ่งหรือหลายเซลล์ในสมุดงาน วัตถุ [IChartCategory](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartcategory/) ให้ป้ายหรือค่าการจัดกลุ่มที่ใช้ร่วมกันโดยชุดข้อมูล ชื่อชุด, หมวดหมู่ และค่าจุดจึงเชื่อมต่อกับวัตถุ [IChartDataCell](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/) แทนที่จะเก็บเป็นเพียงข้อความแสดงผลเท่านั้น

สำหรับแผนภูมิจัดประเภททั่วไป สมุดงานค่าเริ่มต้นจะใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าชุดข้อมูล ดัชนี worksheet, แถว และคอลัมน์ที่ส่งผ่านไปยัง [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) เป็นค่าเริ่มต้นจากศูนย์ การจัดวางนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสันนิษฐานว่าแผนภูมิที่มีอยู่ทั้งหมดใช้รูปแบบนี้ สำหรับการนำเสนอที่โหลดเข้ามา ให้ตรวจสอบเซลล์ที่อ้างอิงโดยชุดข้อมูล, หมวดหมู่, และจุดข้อมูลก่อนทำการเปลี่ยนแปลงค่าที่สมุดงาน

การตั้งค่าแผนภูมิมีขอบเขตสามระดับ:

- การตั้งค่าระดับชุดข้อมูล เช่น [IChartSeries::get_Format](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/get_format/) ให้ลักษณะเริ่มต้นสำหรับจุดทั้งหมดในชุดเดียว
- การตั้งค่าระดับจุดข้อมูล เช่น [IChartDataPoint::get_Format](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapoint/get_format/) จะทับลักษณะของชุดสำหรับจุดหนึ่ง
- การตั้งค่ากลุ่มจะใช้กับชุดข้อมูลที่เข้ากันได้ที่อยู่ใน [IChartSeriesGroup](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseriesgroup/) เดียวกัน เข้าถึงกลุ่มผ่าน [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่น overlap หรือ gap width

เมื่อไม่มีการกำหนดการเติมจุดหรือชุดข้อมูลโดยชัดเจน สไตล์และธีมของแผนภูมิจะกำหนดลักษณะที่แสดงโดยอัตโนมัติ เมื่อมีการกำหนดรูปแบบทั้งชุดและจุดพร้อมกัน รูปแบบของจุดจะมีลำดับความสำคัญต่อจุดนั้น

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่า Overlap ของชุดข้อมูลแผนภูมิ**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/get_overlap/) รายงานว่าคลื่นหรือคอลัมน์ทับกันเท่าไรในแผนภูมิ 2 มิติ ค่าอยู่ระหว่าง -100 ถึง 100 เปอร์เซ็นท์ เป็นการแสดงผลแบบอ่านอย่างเดียวของการตั้งค่าในกลุ่มชุดข้อมูลแม่ เรียก [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) เพื่ออัปเดตทุกชุดข้อมูลที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงกลุ่มคอลัมน์หรือบาร์; ไม่ส่งผลต่อกลุ่มชุดข้อมูลที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม

ตัวอย่างต่อไปนี้ตั้งค่า overlap สำหรับกลุ่มที่มีชุดแรกอยู่ในนั้น:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int8_t overlapPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

// แผนภูมิใหม่มีชุดตัวอย่าง, หมวดหมู่, และค่า.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The series overlap](series_overlap.png)

## **เปลี่ยนสีการเติมของชุดข้อมูล**

ใช้ [IChartSeries::get_Format](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/get_format/) เพื่อกำหนดการเติมเริ่มต้นสำหรับชุดทั้งหมด หากจุดหนึ่งมีการเติมที่ระบุไว้แล้ว การตั้งค่า [IChartDataPoint::get_Format](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapoint/get_format/) ของจุดนั้นจะทับการเติมของชุดสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้การเติมสีฟ้าแบบทึบกับชุดแรก:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesColor = Color::get_Blue();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);

presentation->Save(u"series_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The color of the series](series_color.png)

## **เปลี่ยนชื่อชุดข้อมูล**

ชื่อชุดถูกเก็บไว้ในสมุดงานข้อมูลของแผนภูมิและโดยปกติจะแสดงใน legend ในสมุดงานค่าเริ่มต้นที่สร้างขึ้นสำหรับแผนภูมิคอลัมน์แบบ clustered เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และบรรจุชื่อของชุดแรก ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนี้ชัดเจน:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto seriesNameCell = workbook->GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

คุณสามารถอัปเดตเซลล์ที่อ้างอิงโดย [IChartSeries::get_Name](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/get_name/) ได้เช่นกัน วิธีนี้หลีกเลี่ยงการสันนิษฐานแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesNameCells = series->get_Name()->get_AsCells();
auto seriesNameCell = seriesNameCells->idx_get(firstNameCellIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The series name](series_name.png)

## **รับสีการเติมอัตโนมัติของชุดข้อมูล**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) คืนค่าสีที่คำนวณจากดัชนีชุดและสไตล์ของแผนภูมิ นี่คือสีที่ใช้เมื่อการเติมของชุดไม่ได้ถูกกำหนดอย่างชัดเจน การเรียกเมธอดนี้อ่านค่าสีที่คำนวณได้; ไม่ได้กำหนดการเติมใหม่

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดเริ่มต้น:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Presentation;
using System::Console;
using System::String;

const int firstSlideIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
const int seriesCount = seriesCollection->get_Count();
for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    auto series = seriesCollection->idx_get(seriesIndex);
    auto automaticColor = series->GetAutomaticSeriesColor();
    auto colorName = automaticColor.get_Name();
    auto outputLine = String::Format(u"Series {0}: {1}", seriesIndex, colorName);
    Console::WriteLine(outputLine);
}

presentation->Dispose();
```

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิเริ่มต้น:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

สีที่แน่นอนขึ้นอยู่กับสไตล์และธีมของแผนภูมิ

## **ตั้งค่า Invert Fill Color สำหรับชุดข้อมูลแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์และบับเบิ้ล, [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) สามารถแสดงค่าติดลบด้วยการเติมที่แตกต่างกัน ตั้งค่าการเติมปกติของชุดเป็นสีทึบ, เปิดการกลับค่า, แล้วกำหนดสีค่าติดลบผ่าน [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) ตัวเลขลบจะคงไว้ในสมุดงาน; มีเพียงสีการแสดงผลที่เปลี่ยน

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยชุดเดียว worksheet แถว 0 มีชื่อชุด, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่าต่าง ๆ:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;
const int categoryCount = 3;

const String categoryNames[] = {u"Category 1", u"Category 2", u"Category 3"};
const int seriesValues[] = {-20, 50, -30};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

auto seriesCollection = chartData->get_Series();
seriesCollection->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Series 1");
auto seriesNameCell = workbook->GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, seriesName);
auto chartType = chart->get_Type();
auto series = seriesCollection->Add(seriesNameCell, chartType);

for (int categoryIndex = 0; categoryIndex < categoryCount; categoryIndex++)
{
    const int dataRowIndex = firstDataRowIndex + categoryIndex;
    auto categoryName = categoryNames[categoryIndex];
    const int seriesValue = seriesValues[categoryIndex];

    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);

    auto boxedSeriesValue = ObjectExt::Box<int>(seriesValue);
    auto valueCell = workbook->GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, boxedSeriesValue);
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->set_InvertIfNegative(true);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);

presentation->Save(u"inverted_solid_fill_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The inverted solid fill color](inverted_solid_fill_color.png)

คุณสามารถเปิดการกลับค่าสำหรับจุดเดียวผ่าน [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) ในตัวอย่างต่อไปนี้ การกลับค่าสำหรับชุดถูกปิดและเปิดเฉพาะจุดที่เลือก จุดนั้นยังได้รับค่าติดลบเพื่อให้เห็นผล:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);
series->set_InvertIfNegative(false);

auto dataPoint = series->get_DataPoint(targetDataPointIndex);
auto boxedNegativeValue = ObjectExt::Box<int>(negativeValue);
dataPoint->get_YValue()->get_AsCell()->set_Value(boxedNegativeValue);
dataPoint->set_InvertIfNegative(true);

presentation->Save(u"data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ลบค่าจุดข้อมูลเฉพาะ**

เพื่อทำให้จุดหนึ่งว่างเปล่าตโดยไม่ลบจุดอื่น ให้ตั้งค่าเซลล์สมุดงานที่สนับสนุนจุดนั้นเป็น `nullptr` สำหรับแผนภูมิคอลัมน์ ค่าที่ plotted สามารถเข้าถึงได้ผ่าน [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) จุดข้อมูลจะคงตำแหน่งหมวดหมู่เดิม แต่แผนภูมิจะถือค่าของมันเป็นค่าว่างตามการตั้งค่า blank-value ของแผนภูมิ

ตัวอย่างต่อไปนี้ลบค่าเฉพาะของจุดที่สองในชุดแรก:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto dataPoint = series->get_DataPoint(targetDataPointIndex);
dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);

presentation->Save(u"clear_data_point_value.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

แผนภูมีกระจายใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิ้ลยังใช้เซลล์ขนาดด้วย ลบเฉพาะเซลล์ที่เป็นค่าที่คุณต้องการลบ อย่าเรียก [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) เมื่อคุณต้องการเก็บจุดอื่นไว้ เนื่องจากเมธอดนี้จะลบทุกจุดจากคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์สมุดงานที่ว่างเปล่าหมายถึงข้อมูลหาย; เซลล์ที่มีค่า `0` หมายถึงค่าตัวเลขที่ทราบอยู่ เรียก [IChartDataCell::set_Value](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/set_value/) พร้อม `nullptr` เพื่อทำให้เซลล์ว่างเปล่า ศูนย์ตัวเลขจะยังคงเป็นศูนย์ไม่ว่าจะตั้งค่า blank-cell อย่างไร

ใช้ [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/set_displayblanksas/) เพื่อเลือกวิธีที่แผนภูมิแสดงเซลล์ว่าง ตัวตั้งค่านี้ใช้กับแผนภูมิทั้งหมด เปลี่ยนวิธีการ plot ค่าที่ว่างโดยไม่ต้องเติมศูนย์หรือค่าประมาณลงในเซลล์ว่าง

ตัวอย่างต่อไปนี้เป็นตัวอย่างครบวงจรที่สร้างแผนภูมิเส้นหนึ่งชุด, ลบค่าของ Day 3, แล้วบันทึกแผนภูมิเดียวกันในแต่ละโหมด ไม่ต้องการไฟล์อินพุต [IChartDataWorkbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/) ใช้ worksheet 0, คอลัมน์ 0 สำหรับป้ายหมวดหมู่, และคอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อชุด ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`

```cpp
#include <array>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DisplayBlanksAsType.h>
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
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 40.0f, 40.0f, 640.0f, 400.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Measurements");
auto seriesNameCell = workbook->GetCell(0, 0, 1, seriesName);
auto series = chartData->get_Series()->Add(seriesNameCell, chart->get_Type());
auto values = std::array<int, 5>{10, 20, 25, 30, 40};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = String::Format(u"Day {0}", i + 1);
    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);
    auto boxedValue = ObjectExt::Box<int>(values[i]);
    auto valueCell = workbook->GetCell(0, i + 1, 1, boxedValue);
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook->GetCell(0, 3, 1)->set_Value(nullptr);

auto modes = std::array<DisplayBlanksAsType, 3>{DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span};
for (auto mode : modes)
{
    chart->set_DisplayBlanksAs(mode);
    auto outputPath = String::Format(u"empty_cells_{0}.pptx", mode);
    presentation->Save(outputPath, SaveFormat::Pptx);
}

presentation->Dispose();
```

แต่ละไฟล์ผลลัพธ์บันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx` หากต้องการบันทึกเพียงเวอร์ชันเดียว ให้กำหนดโหมดที่ต้องการและบันทึกการนำเสนอครั้งเดียวแทนการวนลูปตามโหมด

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในไฟล์ทั้งสาม Day 3 เป็นค่าว่างในสมุดงานในทุกกรณี:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

ผลกระทบที่มองเห็นได้ขึ้นกับประเภทแผนภูมิ แผนภูมิเส้นทำให้เปรียบเทียบสามโหมดได้ง่าย แผนภูมิแท่งและคอลัมน์ไม่มีเส้นเชื่อมต่อผ่านหมวดหมู่ที่หายไป ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมตามที่แสดงด้านบน; คอลัมน์ที่หายและคอลัมน์ศูนย์อาจดูคล้ายกันได้เช่นกัน อีกอย่างคือแผนภูมิกระจายที่มีเพียงมาร์คเกอร์ก็ไม่มีเส้นเชื่อมด้วย อย่าคาดหวังผลลัพธ์ที่แตกต่างสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้

## **ตั้งค่า Gap Width ของชุดข้อมูล**

Gap width คือช่องว่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์ เช่นเดียวกับ overlap มันเป็นของกลุ่มชุดข้อมูลแม่ ไม่ได้เป็นของชุดเดียว เรียก [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) ครั้งเดียวสำหรับกลุ่ม ค่าใหญ่กว่าจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น; ค่าเล็กกว่าจะทำให้กลุ่มแน่นขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนค่า gap width และบันทึกเพียงการนำเสนอสุดท้าย:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const uint16_t gapWidthPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_GapWidth(gapWidthPercent);

presentation->Save(u"gap_width_30.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The gap width](gap_width.png)

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดบ้างที่รองรับชุดข้อมูล?**

ประเภทแผนภูมิทั้งหมดที่ระบุโดย enumeration [ChartType](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/charttype/) ใช้ข้อมูลแผนภูมิ แต่ชุดข้อมูลของพวกมันไม่ใช่ทั้งหมดที่มีโครงสร้างค่าหรือการตั้งค่าเดียวกัน ตัวอย่างเช่น แผนภูมิจัดประเภทใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิบับเบิ้ลเพิ่มขนาดบับเบิ้ล ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทของชุดข้อมูล การตั้งค่าต่าง ๆ เช่น overlap และ gap width ใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้

**ชุดข้อมูลกลุ่ม (Series Group) คืออะไร?**

[IChartSeriesGroup](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseriesgroup/) ประกอบด้วยชุดข้อมูลที่เข้ากันได้และใช้การตั้งค่าการ plot ระดับกลุ่ม แผนภูมิแบบผสมอาจมีหลายกลุ่ม ดังนั้นการเปลี่ยนแปลงกลุ่มผ่านชุดข้อมูลหนึ่งไม่ได้หมายความว่าจะเปลี่ยนแปลงทุกชุดในแผนภูมิ

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่ โดยค่าเริ่มต้น [IShapeCollection::AddChart](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/addchart/) จะสร้างชุดตัวอย่าง, หมวดหมู่, และค่า คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์ทั้งชุดและคอลเลกชันหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองได้อย่างเต็มที่ อีกหนึ่ง overload ยังสามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้น

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์สมุดงานอย่างไร?**

ชื่อชุด, ป้ายหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [IChartDataWorkbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/) การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิตรงนั้น เมื่อคุณสร้างข้อมูลแบบกำหนดเอง ให้รักษาแถวหมวดหมู่และแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุด plotted ใต้หมวดหมู่ที่ตั้งใจไว้

**ฉันจะลบจุดเดียวแทนการลบทั้งชุดได้อย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `nullptr` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดนั้นเป็นจุดว่าง เรียก [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) เฉพาะเมื่อคุณต้องการลบทุกจุดในชุด หากคุณลบหมวดหมู่ด้วย ควรอัปเดตทุกชุดให้ค่าของพวกเขายังคงสอดคล้องกับคอลเลกชันหมวดหมู่

**จุดว่างแสดงผลอย่างไร?**

ผลลัพธ์ขึ้นกับประเภทแผนภูมิและ [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/get_displayblanksas/) แผนภูมิที่รองรับสามารถแสดงช่องว่างเป็น gap, เป็นค่า zero, หรือเชื่อมต่อจุดใกล้เคียงกัน เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ ดูส่วน **ควบคุมการแสดงผลของเซลล์ว่าง** เพื่อดูตัวอย่างเต็มและการเปรียบเทียบภาพ

**ค่าติดลบถูกจัดรูปแบบอย่างไร?**

สำหรับชุดบาร์, คอลัมน์, และบับเบิ้ลที่รองรับ ให้เรียก [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) แล้วตั้งค่าสีผ่าน [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) คุณสามารถทับพฤติกรรมสำหรับจุดเดี่ยวด้วย [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) วิธีเหล่านี้ส่งผลต่อรูปแบบการแสดงผล ไม่ได้เปลี่ยนค่าเชิงตัวเลขที่เก็บไว้

**การจัดรูปแบบใดชนะเมื่อทั้งชุดและจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดข้อมูลที่ระบุโดยชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น จุดอื่น ๆ ยังคงใช้การจัดรูปแบบชุดที่ระบุหรือ หากชุดไม่ได้กำหนดรูปแบบ จะใช้สไตล์และธีมของแผนภูมิอัตโนมัติ การตั้งค่ากลุ่มเช่น overlap และ gap width ควบคุมการจัดวางและไม่ใช่การทับรูปแบบระดับจุด

**แผนภูมิสามารถมีชุดข้อมูลได้สูงสุดเท่าไหร่?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดข้อมูลแบบคงที่ อย่างไรก็ตาม ข้อจำกัดของไฟล์นำเสนอ, หน่วยความจำที่มี, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิจะกำหนดขีดจำกัดที่เป็นประโยชน์ในทางปฏิบัติ

**ฉันควรทำอย่างไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างเกินไป?**

เรียก [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) บนกลุ่มชุดข้อมูลแม่ที่เหมาะสม เพิ่มค่าจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น หรือ ลดค่าจะทำให้กลุ่มเข้าใกล้กันมากขึ้น