---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย C++
linktitle: ชุดข้อมูล
type: docs
url: /th/cpp/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุด
- สีของชุด
- สีของหมวดหมู่
- ชื่อชุด
- จุดข้อมูล
- ช่องว่างของชุด
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์ในเวิร์กบุ๊ก, การจัดรูปแบบ, การทับซ้อน, ความกว้างช่องว่าง, และค่าติดลบในงานนำเสนอด้วย C++."
---
## **ภาพรวม**

แผนภูมิจะเก็บข้อมูลที่พล็อตไว้ในเวิร์กบุ๊กข้อมูลแผนภูมิ. [IChartSeries](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด, และแต่ละ [IChartDataPoint](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapoint/) ในชุดจะอ้างอิงถึงหนึ่งหรือหลายเซลล์ในเวิร์กบุ๊ก. วัตถุ [IChartCategory](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartcategory/) ให้ป้ายชื่อหรือค่ากลุ่มที่ใช้ร่วมกันโดยชุดข้อมูล. ชื่อชุด, หมวดหมู่, และค่าจึงเชื่อมต่อกับวัตถุ [IChartDataCell](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatacell/) แทนที่จะเก็บเป็นข้อความแสดงผลเท่านั้น.

สำหรับแผนภูมิประเภทหมวดหมู่ทั่วไป, เวิร์กบุ๊กเริ่มต้นใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าชุด. ดัชนีแผ่นงาน, แถว, และคอลัมน์ที่ส่งไปยัง [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) นั้นอิงศูนย์. การจัดวางนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น, แต่ไม่ควรสมมติว่าทุกแผนภูมิที่มีอยู่ใช้รูปแบบนี้. สำหรับงานนำเสนอที่โหลดแล้ว, ให้ตรวจสอบเซลล์ที่อ้างอิงโดยชุดข้อมูล, หมวดหมู่, และจุดข้อมูลก่อนที่จะเปลี่ยนแปลงค่ในเวิร์กบุ๊ก.

การตั้งค่าแผนภูมิมีสามระดับ:

- การตั้งค่าระดับชุดข้อมูล, เช่น [IChartSeries::get_Format](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/get_format/), ให้ลักษณะเริ่มต้นสำหรับทุกจุดในชุดเดียว.
- การตั้งค่าระดับจุดข้อมูล, เช่น [IChartDataPoint::get_Format](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapoint/get_format/), จะทับลักษณะของชุดสำหรับจุดเดียว.
- การตั้งค่าระดับกลุ่มจะใช้กับชุดข้อมูลที่เข้ากันได้ซึ่งอยู่ใน [IChartSeriesGroup](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseriesgroup/) เดียวกัน. เข้าถึงกลุ่มผ่าน [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) เมื่อจำเป็นต้องตั้งค่าตัวเลือกเช่นการทับซ้อนหรือความกว้างช่องว่าง.

เมื่อไม่มีการกำหนดการเติมจุดหรือชุดอย่างชัดเจน, สไตล์และธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติ. เมื่อมีการกำหนดรูปแบบทั้งชุดและจุด, การกำหนดรูปแบบของจุดจะมีลำดับความสำคัญสำหรับจุดนั้น.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของชุดข้อมูลแผนภูมิ**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/get_overlap/) รายงานว่าบาร์หรือคอลัมน์ทับซ้อนกันเท่าใดในแผนภูมิ 2D, ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์. มันเป็นการฉายแบบอ่านอย่างเดียวของการตั้งค่าในกลุ่มชุดแม่. เรียก [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น. ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; ไม่ส่งผลต่อกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม.

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

![The series overlap](series_overlap.png)

## **เปลี่ยนสีเติมของชุดข้อมูล**

ใช้ [IChartSeries::get_Format](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/get_format/) เพื่อกำหนดสีเติมเริ่มต้นสำหรับชุดทั้งหมด. หากจุดหนึ่งมีการเติมแบบชัดเจนแล้ว, การตั้งค่า [IChartDataPoint::get_Format](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapoint/get_format/) จะทับสีเติมของชุดสำหรับจุดนั้น.

ตัวอย่างต่อไปนี้ใส่สีเติมสีฟ้าเดียวให้กับชุดแรก:

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

ชื่อชุดถูกเก็บในเวิร์กบุ๊กข้อมูลแผนภูมิและโดยทั่วไปจะแสดงในตำนาน. ในเวิร์กบุ๊กเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบกลุ่ม, เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และมีชื่อของชุดแรก. ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนี้ชัดเจน:

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

คุณสามารถอัปเดตเซลล์ที่อ้างอิงโดย [IChartSeries::get_Name](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/get_name/) ได้เช่นกัน. วิธีนี้หลีกเลี่ยงการสมมติแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

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

## **รับสีเติมอัตโนมัติของชุดข้อมูล**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) คืนค่าสีที่คำนวณจากดัชนีชุดและสไตล์แผนภูมิ. นี่คือสีที่ใช้เมื่อสีเติมของชุดไม่ได้กำหนดอย่างชัดเจน. การเรียกเมธอดจะอ่านสีที่คำนวณได้; ไม่ได้กำหนดสีเติมใหม่.

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

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิเบื้องต้น:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

สีที่ได้ขึ้นอยู่กับสไตล์และธีมของแผนภูมิ.

## **ตั้งค่าสีเติมกลับด้านสำหรับชุดข้อมูลแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์, และบับเบิล, [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) สามารถแสดงค่าลบด้วยสีเติมที่ต่างออกไป. ให้ตั้งค่าสีเติมปกติเป็นแบบทึบ, เปิดการกลับด้าน, แล้วกำหนดสีค่าลบผ่าน [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). ตัวเลขลบจะยังคงอยู่ในเวิร์กบุ๊ก; เพียงสีที่แสดงเท่านั้นที่เปลี่ยน.

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิมาตรฐานด้วยชุดเดียว. แถว 0 ของแผ่นงานมีชื่อชุด, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่าต่าง ๆ:

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

คุณสามารถเปิดการกลับด้านสำหรับจุดเดียวผ่าน [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). ในตัวอย่างต่อไปนี้ การกลับด้านถูกปิดสำหรับชุดและเปิดเฉพาะสำหรับจุดที่เลือก. จุดนั้นยังถูกกำหนดค่าเป็นค่าลบเพื่อให้เห็นผล:

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

## **ล้างค่าจุดข้อมูลเฉพาะ**

เพื่อทำให้จุดหนึ่งว่างเปล่าโดยไม่ลบจุดอื่น, ให้ตั้งค่าเซลล์เวิร์กบุ๊กที่เป็นฐานเป็น `nullptr`. สำหรับแผนภูมิคอลัมน์, ค่าที่พล็อตได้สามารถเข้าถึงได้ผ่าน [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/). จุดข้อมูลจะอยู่ที่ตำแหน่งหมวดหมู่เดิม, แต่แผนภูมิจะถือว่าค่าของมันเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ.

ตัวอย่างต่อไปนี้ลบเฉพาะจุดที่สองในชุดแรก:

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

แผนภูมิกระจายจะแยกเซลล์ X และ Y, ส่วนแผนภูมิบับเบิลยังใช้เซลล์ขนาด. ให้ล้างเฉพาะเซลล์ที่เป็นค่าที่คุณต้องการลบ. อย่าเรียก [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) เมื่อคุณต้องการเก็บจุดอื่นไว้, เพราะเมธอดนั้นจะลบทุกจุดจากคอลเล็กชัน.

## **ตั้งค่าความกว้างช่องว่างของชุดข้อมูล**

ความกว้างช่องว่างคือช่องว่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์. เช่นเดียวกับการทับซ้อน, มันเป็นของกลุ่มชุดแม่ ไม่ใช่ของชุดเดียว. เรียก [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) ครั้งเดียวสำหรับกลุ่ม. ค่าที่ใหญ่กว่าจะสร้างพื้นที่ระหว่างกลุ่มมากขึ้น; ค่าที่เล็กกว่าจะทำให้กลุ่มแน่นขึ้น.

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างช่องว่างและบันทึกเพียงงานนำเสนอสุดท้าย:

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

**ประเภทแผนภูมิใดสนับสนุนชุดข้อมูล?**

ทุกประเภทแผนภูมิที่แสดงโดย enumeration [ChartType](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ชุดข้อมูลของพวกมันไม่ทั้งหมดมีโครงสร้างค่าหรือการตั้งค่าเดียวกัน. ตัวอย่างเช่น, แผนภูมิเบื้องต้นใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิบับเบิลเพิ่มขนาดบับเบิล. ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทชุด. ตัวเลือกเช่นการทับซ้อนและความกว้างช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้.

**กลุ่มชุดข้อมูลแผนภูมิคืออะไร?**

[IChartSeriesGroup](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseriesgroup/) ประกอบด้วยชุดข้อมูลที่เข้ากันได้ซึ่งใช้การตั้งค่าการพล็อตระดับกลุ่ม. แผนภูมิแบบผสมอาจมีมากกว่าหนึ่งกลุ่ม, ดังนั้นการเปลี่ยนกลุ่มที่เข้าถึงผ่านชุดหนึ่งไม่ได้หมายความว่าจะเปลี่ยนทุกชุดในแผนภูมิ.

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

มี. โดยค่าเริ่มต้น, [IShapeCollection::AddChart](https://reference.aspose.com/slides/th/cpp/aspose.slides/ishapecollection/addchart/) สร้างชุดตัวอย่าง, หมวดหมู่, และค่า. คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์ทั้งชุดและคอลเล็กชันหมวดหมู่ก่อนที่จะเพิ่มชุดข้อมูลที่กำหนดเองทั้งหมด. มีการ overload ที่สามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้นได้เช่นกัน.

**วัตถุแผนภูมิเชื่อมโยงกับเซลล์เวิร์กบุ๊กอย่างไร?**

ชื่อชุด, ป้ายหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [IChartDataWorkbook](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdataworkbook/). การเปลี่ยนเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิตรงนั้น. เมื่อคุณสร้างข้อมูลแบบกำหนดเอง, ควรรักษาแถวหมวดหมู่และแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุดพล็อตภายใต้หมวดหมู่ที่ตั้งใจ.

**ฉันจะลบจุดเดียวโดยไม่ลบชุดทั้งหมดได้อย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `nullptr` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดให้เป็นจุดว่าง. เรียก [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) เฉพาะเมื่อคุณต้องการลบทุกจุดจากชุดนั้น. หากคุณลบหมวดหมู่ด้วย, ให้ปรับแต่ละชุดให้ค่าของพวกมันยังคงสอดคล้องกับคอลเล็กชันหมวดหมู่.

**จุดว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและ [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichart/get_displayblanksas/). แผนภูมิที่สนับสนุนสามารถแสดงค่าว่างเป็นช่องว่าง, เป็นค่า 0, หรือโดยการเชื่อมต่อจุดใกล้เคียง. เลือกการตั้งค่าที่ตรงกับความหมายของข้อมูลที่ขาดหายในงานนำเสนอของคุณ.

**ค่าติดลบจะถูกจัดรูปแบบอย่างไร?**

สำหรับชุดบาร์, คอลัมน์, และบับเบิลที่สนับสนุน, เรียก [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) และตั้งค่าสีผ่าน [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). คุณสามารถทับการทำงานสำหรับจุดเดี่ยวด้วย [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). วิธีเหล่านี้ส่งผลต่อการจัดรูปแบบ, ไม่ได้เปลี่ยนค่าเชิงตัวเลขที่เก็บไว้.

**รูปแบบใดชนะเมื่อทั้งชุดและจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดข้อมูลโดยชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น. จุดอื่น ๆ จะใช้รูปแบบชุดที่กำหนดไว้ หรือหากไม่มีการกำหนดรูปแบบชุด จะใช้สไตล์และธีมของแผนภูมิอัตโนมัติ. การตั้งค่ากลุ่มเช่นการทับซ้อนและความกว้างช่องว่างควบคุมการจัดวางและไม่ใช่การทับซ้อนระดับจุด.

**แผนภูมิจำกัดจำนวนชุดได้เท่าใด?**

Aspose.Slides ไม่มีการกำหนดขีดจำกัดจำนวนชุดแยกต่างหาก. โดยปฏิบัติ, ข้อจำกัดจะขึ้นอยู่กับข้อจำกัดของไฟล์งานนำเสนอ, หน่วยความจำที่มี, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิ.

**จะปรับอย่างไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

เรียก [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/th/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) บนกลุ่มชุดแม่ที่เหมาะสม. เพิ่มค่าจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น, ลดค่าจะทำให้กลุ่มแน่นขึ้น.