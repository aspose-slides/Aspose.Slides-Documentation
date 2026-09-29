---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย C++
linktitle: ชุดข้อมูล
type: docs
url: /th/cpp/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุด
- สีของชุด
- สีหมวด
- ชื่อชุด
- จุดข้อมูล
- ช่องว่างของชุด
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์ในสมุดงาน, การฟอร์แมต, การทับซ้อน, ความกว้างช่องว่าง, และค่าติดลบในงานนำเสนอด้วย C++."
---
## **ภาพรวม**

แผนภูมิจะเก็บข้อมูลที่พล็อตไว้ในสมุดงานข้อมูลแผนภูมิ. IChartSeries แทนชุดค่าที่เกี่ยวข้องหนึ่งชุด, และแต่ละ IChartDataPoint ในชุดจะอ้างอิงถึงหนึ่งหรือหลายเซลล์ในสมุดงาน. วัตถุ IChartCategory ให้ป้ายหรือค่าการจัดกลุ่มที่ใช้ร่วมกันโดยชุด. ดังนั้นชื่อชุด, หมวดหมู่, และค่าจุดจึงเชื่อมต่อกับวัตถุ IChartDataCell แทนการเก็บเป็นข้อความแสดงเท่านั้น.

สำหรับแผนภูมิประเภทหมวดแบบทั่วไป, สมุดงานเริ่มต้นจะใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อหมวด, และเซลล์ที่เหลือสำหรับค่าชุด. ดัชนีแผ่นงาน, แถว, และคอลัมน์ที่ส่งไปยัง IChartDataWorkbook::GetCell เป็นแบบเริ่มต้นจากศูนย์. รูปแบบนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น, แต่ไม่ควรสมมติว่าทุกแผนภูมิที่มีอยู่ใช้รูปแบบนี้. สำหรับงานนำเสนอที่โหลดมา, ตรวจสอบเซลล์ที่ชุด, หมวด, และจุดข้อมูลอ้างอิงก่อนที่จะเปลี่ยนค่าของสมุดงาน.

การตั้งค่าแผนภูมิมีสามระดับขอบเขตที่แตกต่างกัน:

- การตั้งค่าระดับชุด, เช่น IChartSeries::get_Format, ให้รูปลักษณ์เริ่มต้นสำหรับทุกจุดในชุดเดียว.
- การตั้งค่าระดับจุดข้อมูล, เช่น IChartDataPoint::get_Format, ครอบคลุมรูปลักษณ์ของชุดสำหรับจุดเดียว.
- การตั้งค่ากลุ่มใช้กับชุดที่เข้ากันได้ซึ่งอยู่ใน IChartSeriesGroup เดียวกัน. เข้าถึงกลุ่มผ่าน IChartSeries::get_ParentSeriesGroup เมื่อคุณต้องการตั้งค่าตัวเลือกเช่นการทับซ้อนหรือความกว้างช่องว่าง.

เมื่อไม่ได้กำหนดการเติมสีแบบชัดเจนให้กับจุดหรือชุด, สไตล์และธีมของแผนภูมิจะกำหนดรูปลักษณ์อัตโนมัติ. เมื่อมีการฟอร์แมตชุดและจุดพร้อมกัน, การฟอร์แมตจุดจะมีลำดับความสำคัญสำหรับจุดนั้น.

![แผนภูมิซีรีส์ใน PowerPoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของชุดแผนภูมิ**

IChartSeries::get_Overlap รายงานว่าบาร์หรือคอลัมน์ทับซ้อนกันเท่าใดในแผนภูมิ 2D, ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์. เป็นการฉายภาพแบบอ่านอย่างเดียวของการตั้งค่าในกลุ่มชุดพาเรนท์. เรียก IChartSeriesGroup::set_Overlap เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น. ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์แบบจัดกลุ่ม; มันไม่ส่งผลต่อกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิตรร่วม.

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่มีชุดแรก:

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

![การทับซ้อนของชุด](series_overlap.png)

## **เปลี่ยนสีเติมของชุด**

ใช้ IChartSeries::get_Format เพื่อตั้งค่าสีเติมเริ่มต้นสำหรับชุดทั้งหมด. หากจุดมีการเติมสีอย่างชัดเจน, การตั้งค่า IChartDataPoint::get_Format จะครอบคลุมการเติมสีของชุดสำหรับจุดนั้น.

ตัวอย่างต่อไปนี้ใช้สีเติมสีน้ำเงินทึบกับชุดแรก:

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

![สีของชุด](series_color.png)

## **เปลี่ยนชื่อชุด**

ชื่อชุดถูกเก็บในสมุดงานข้อมูลแผนภูมิและโดยปกติจะแสดงในคำอธิบาย. ในสมุดงานเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบกลุ่ม, เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และบรรจุชื่อของชุดแรก. ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างดังกล่าวชัดเจน:

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

คุณสามารถอัปเดตเซลล์ที่ IChartSeries::get_Name อ้างอิงอยู่แล้วได้เช่นกัน. วิธีนี้หลีกเลี่ยงการสันนิษฐานแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

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

![ชื่อชุด](series_name.png)

## **รับสีเติมอัตโนมัติของชุด**

IChartSeries::GetAutomaticSeriesColor คืนค่าสีที่คำนวณจากดัชนีชุดและสไตล์แผนภูมิ. นี่คือสีที่ใช้เมื่อการเติมสีชุดไม่ได้กำหนดอย่างชัดเจน. การเรียกเมธอดนี้อ่านสีที่คำนวณแล้ว; มันไม่ได้กำหนดการเติมสีใหม่.

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

สีที่แน่นอนขึ้นอยู่กับสไตล์และธีมของแผนภูมิ.

## **ตั้งค่าสีเติมกลับสำหรับชุดแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์, และบับเบิล, IChartSeries::set_InvertIfNegative สามารถแสดงค่าติดลบด้วยสีเติมที่ต่างออกไป. ตั้งค่าการเติมสีชุดทั่วไปเป็นสีทึบ, เปิดใช้งานการกลับสี, และกำหนดสีค่าติดลบผ่าน IChartSeries::get_InvertedSolidFillColor. ตัวเลขติดลบจะคงอยู่ในสมุดงาน; มีเพียงสีการแสดงผลที่เปลี่ยน.

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเบื้องต้นด้วยชุดเดียว. แถว 0 ของแผ่นงานมีชื่อชุด, คอลัมน์ 0 มีชื่อหมวด, และคอลัมน์ 1 มีค่าต่าง ๆ:

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

![สีเติมแบบหนากลับ](inverted_solid_fill_color.png)

คุณสามารถเปิดใช้งานการกลับสีสำหรับจุดเดียวผ่าน IChartDataPoint::set_InvertIfNegative. ในตัวอย่างต่อไปนี้ การกลับสีถูกปิดสำหรับชุดและเปิดเฉพาะสำหรับจุดที่เลือก. จุดดังกล่าวยังได้รับค่าติดลบเพื่อให้เห็นเอฟเฟกต์:

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

เพื่อทำให้จุดหนึ่งเป็นค่าว่างโดยไม่ลบจุดอื่น, ตั้งค่าเซลล์สมุดงานที่สนับสนุนให้เป็น `nullptr`. สำหรับแผนภูมิคอลัมน์, ค่าที่พล็อตได้สามารถเข้าถึงได้ผ่าน IChartDataPoint::get_YValue. จุดข้อมูลจะคงตำแหน่งหมวดเดิม, แต่แผนภูมิจะถือว่าค่าของมันเป็นค่าว่างตามการตั้งค่าการแสดงค่าว่างของแผนภูมิ.

ตัวอย่างต่อไปนี้ลบค่าจุดที่สองในชุดแรก:

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

แผนภูมิกระจายใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิลยังใช้เซลล์ขนาด. ให้ลบเฉพาะเซลล์ที่เป็นค่าที่คุณต้องการลบ. อย่าเรียก IChartDataPointCollection::Clear หากคุณต้องการเก็บจุดอื่นไว้, เพราะเมธอดนั้นจะลบทุกจุดในคอลเลกชัน.

## **ควบคุมการแสดงเซลล์ว่าง**

เซลล์ที่ซ่อนอยู่และมีค่าถือเป็นกรณีแยกจากเซลล์ว่าง. หากต้องการรวมหรือแยกข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่, ดู Include Data from Hidden Rows and Columns(/slides/th/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns).

เซลล์สมุดงานที่ว่างเปล่าแสดงถึงข้อมูลที่ขาดหาย; เซลล์ที่มีค่า `0` แสดงถึงค่าตัวเลขที่รู้จัก. เรียก IChartDataCell::set_Value ด้วย `nullptr` เพื่อทำให้เซลล์เป็นค่าว่าง. ศูนย์เชิงตัวเลขจะคงเป็นศูนย์ไม่ว่าการตั้งค่าเซลล์ว่างจะเป็นอย่างไร.

ใช้ IChart::set_DisplayBlanksAs เพื่อเลือกว่าแผนภูมิจะแสดงเซลล์ว่างอย่างไร. การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด. มันเปลี่ยนวิธีที่ค่าว่างถูกพล็อต, โดยไม่ได้เติมเซลล์ว่างด้วยศูนย์หรือค่าที่ประมาณ.

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีชุดเดียว, ลบค่าของ Day 3, และบันทึกแผนภูมิเดียวกันด้วยแต่ละโหมด. ไม่ต้องใช้ไฟล์อินพุต. IChartDataWorkbook ใช้แผ่นงาน 0, คอลัมน์ 0 สำหรับป้ายหมวด, และคอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อชุด. ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`.

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

// ปล่อยให้ Day 3 เป็นค่าว่างจริง ๆ โดยคงไว้ซึ่งหมวดและจุดข้อมูลของมัน.
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


แต่ละไฟล์เอาต์พุตบันทึกโหมดที่กำหนดไว้ก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx`. หากต้องการบันทึกเพียงหนึ่งเวอร์ชัน, ตั้งค่าโหมดที่ต้องการและบันทึกงานนำเสนอเพียงครั้งเดียวแทนการวนลูปผ่านโหมดต่าง ๆ.

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในไฟล์ทั้งสาม. Day 3 เป็นค่าว่างในสมุดงานในทุกกรณี:

![แผนภูมิเส้นที่มีข้อมูลเดียวกัน: Gap ทำให้เส้นขาดที่ Day 3, Zero ทำให้เส้นลดลงเป็นศูนย์, และ Span เชื่อม Day 2 ไป Day 4.](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ. แผนภูมิเส้นทำให้เปรียบเทียบทั้งสามโหมดได้ง่าย. แผนภูมิแท่งและคอลัมน์ไม่มีเส้นเชื่อมข้ามหมวดที่หายไป, ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมที่แสดงด้านบน; คอลัมน์ที่หายและคอลัมน์ศูนย์อาจดูคล้ายกัน. อย่างเช่น, แผนภูมิกระจายที่มีเพียงมาร์กเกอร์ก็ไม่มีเส้นเชื่อม. อย่าคาดหวังผลลัพธ์ที่แตกต่างกันสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบเอาต์พุตสำหรับประเภทที่คุณใช้.

## **ตั้งค่าความกว้างช่องว่างของชุด**

ความกว้างช่องว่างคือช่องว่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์. เช่นเดียวกับการทับซ้อน, มันเป็นของกลุ่มชุดพาเรนท์แทนที่เป็นของชุดเดียว. เรียก IChartSeriesGroup::set_GapWidth ครั้งเดียวสำหรับกลุ่ม. ค่าที่ใหญ่ขึ้นจะสร้างช่องว่างมากขึ้นระหว่างกลุ่ม; ค่าที่เล็กลงจะทำให้กลุ่มแน่นขึ้น.

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างช่องว่างและบันทึกงานนำเสนอสุดท้ายเท่านั้น:

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

![ความกว้างช่องว่าง](gap_width.png)

## **คำถามที่พบบ่อย**

**แผนภูมิประเภทใดสนับสนุนชุดข้อมูล?**

แผนภูมิทุกประเภทที่ระบุโดย перечисление ChartType ใช้ข้อมูลแผนภูมิ, แต่ชุดของพวกมันไม่ทั้งหมดมีโครงสร้างค่าและการตั้งค่าเดียวกัน. ตัวอย่างเช่น, แผนภูมิกลุ่มใช้หมวดและค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิบับเบิลเพิ่มขนาดบับเบิล. ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทชุด. ตัวเลือกเช่นการทับซ้อนและความกว้างช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้.

**กลุ่มชุดแผนภูมิคืออะไร?**

IChartSeriesGroup ประกอบด้วยชุดที่เข้ากันได้ซึ่งแชร์การตั้งค่าการพล็อตระดับกลุ่ม. แผนภูมิตรร่วมสามารถมีมากกว่าหนึ่งกลุ่ม, ดังนั้นการเปลี่ยนแปลงกลุ่มที่เข้าถึงผ่านชุดหนึ่งอาจไม่เปลี่ยนแปลงทุกชุดในแผนภูมิ.

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่. โดยค่าเริ่มต้น, IShapeCollection::AddChart จะสร้างชุดตัวอย่าง, หมวด, และค่า. คุณสามารถแก้ไขเซลล์เหล่านั้นหรือลบทั้งชุดและคอลเลกชันหมวดก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างเต็มที่. การโอเวอร์โหลดบางตัวยังสามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้น.

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์สมุดงานอย่างไร?**

ชื่อชุด, ป้ายหมวด, และค่าจุดข้อมูลอ้างอิงเซลล์ใน IChartDataWorkbook. การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิเช่นนั้น. เมื่อคุณสร้างข้อมูลกำหนดเอง, ให้แน่ใจว่าแถวหมวดและแถวค่าชุดเรียงตรงกันเพื่อให้แต่ละจุดถูกพล็อตภายใต้หมวดที่ตั้งใจ.

**จะลบจุดเดียวแทนการลบชุดทั้งหมดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `nullptr` เพื่อคงตำแหน่งหมวดของจุดเป็นจุดว่าง. เรียก IChartDataPointCollection::Clear เฉพาะเมื่อคุณต้องการลบทุกจุดจากชุดนั้น. หากคุณลบหมวดด้วย, ให้อัปเดตทุกชุดเพื่อให้ค่าของพวกมันยังคงสอดคล้องกับคอลเลกชันหมวด.

**จุดว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและ IChart::get_DisplayBlanksAs. แผนภูมิที่สนับสนุนสามารถแสดงค่าว่างเป็นช่องว่าง, ค่าศูนย์, หรือโดยการเชื่อมจุดใกล้เคียง. เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่ขาดหายในงานนำเสนอของคุณ. ดู Control the Display of Empty Cells สำหรับตัวอย่างครบและการเปรียบเทียบภาพ.

**ค่าติดลบถูกฟอร์แมตอย่างไร?**

สำหรับชุดบาร์, คอลัมน์, และบับเบิลที่รองรับ, เรียก IChartSeries::set_InvertIfNegative และกำหนดสีผ่าน IChartSeries::get_InvertedSolidFillColor. คุณสามารถครอบคลุมพฤติกรรมสำหรับจุดเดี่ยวด้วย IChartDataPoint::set_InvertIfNegative. วิธีเหล่านี้มีผลต่อการฟอร์แมต, ไม่ได้เปลี่ยนค่าตัวเลขที่เก็บไว้.

**การฟอร์แมตใดชนะเมื่อทั้งชุดและจุดถูกฟอร์แมต?**

การฟอร์แมตจุดข้อมูลอย่างชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น. จุดอื่น ๆ ยังคงใช้การฟอร์แมตชุดที่ชัดเจนหรือ, เมื่อไม่มีการฟอร์แมตชุด, จะใช้สไตล์และธีมแผนภูมิอัตโนมัติ. การตั้งค่ากลุ่มเช่นการทับซ้อนและความกว้างช่องว่างควบคุมการจัดวางและไม่ใช่การฟอร์แมตระดับจุด.

**แผนภูมิสามารถมีชุดได้มากแค่ไหน?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดคงที่แยกต่างหาก. อย่างไรก็ตาม, ข้อจำกัดของไฟล์งานนำเสนอ, หน่วยความจำที่ใช้, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิจะแสดงขีดจำกัดที่ใช้งานได้จริง.

**ควรทำอย่างไรเมื่อคอลัมน์อยู่ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก IChartSeriesGroup::set_GapWidth บนกลุ่มชุดพาเรนท์ที่เหมาะสม. เพิ่มค่าก็จะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น, หรือลดค่าก็จะทำให้กลุ่มเข้ามาใกล้กันมากขึ้น.