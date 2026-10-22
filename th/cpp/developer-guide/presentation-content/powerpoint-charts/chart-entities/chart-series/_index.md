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
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์ในเวิร์กบุ๊ค, การจัดรูปแบบ, การทับซ้อน, ความกว้างช่องว่าง, และค่าติดลบในงานนำเสนอด้วย C++."
---
## **ภาพรวม**

แผนภูมิสามารถจัดเก็บค่าที่พล็อตไว้ในเซลล์ของเวิร์กบุ๊คหรือโดยตรงเป็นลิเตอร์ัลตัวเลขได้ [IChartSeries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/) แทนชุดค่าที่เกี่ยวข้องหนึ่งชุดและแต่ละ [IChartDataPoint](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/) แทนจุดหนึ่งในชุดนั้น [IChartCategory](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategory/) ให้ป้ายกำกับหรือค่ากลุ่มที่ใช้ร่วมกันระหว่างชุด  ในแผนภูมิที่สร้างด้วยข้อมูลเริ่มต้น ชื่อชุด, หมวดหมู่และค่าจุดจะใช้ [IChartDataCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/) จากเวิร์กบุ๊คของแผนภูมิ

สำหรับแผนภูมิแบบหมวดหมู่ทั่วไป เวิร์กบุ๊คเริ่มต้นจะใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อหมวดหมู่และเซลล์ที่เหลือสำหรับค่าชุด Worksheet, แถวและคอลัมน์ที่ส่งผ่านไปยัง [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) จะเริ่มจาก 0 เค้าโครงนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสมมติว่าแผนภูมิที่มีอยู่ทั้งหมดใช้เค้าโครงนี้ สำหรับการนำเสนอที่โหลดมา ให้ตรวจสอบเซลล์ที่อ้างอิงโดยชุด, หมวดหมู่และจุดข้อมูลก่อนที่จะเปลี่ยนค่าในเวิร์กบุ๊ค

การตั้งค่าแผนภูมิมีสามระดับ:

- การตั้งค่าระดับชุด เช่น [IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/) ให้รูปแบบเริ่มต้นสำหรับทุกจุดในชุดเดียว
- การตั้งค่าระดับจุด เช่น [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/) จะครอบคลุมรูปแบบชุดสำหรับจุดหนึ่ง
- การตั้งค่ากลุ่มจะใช้กับชุดที่เข้ากันได้ซึ่งอยู่ใน [IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/) เข้าถึงกลุ่มผ่าน [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) เมื่อคุณต้องการตั้งค่าต่าง ๆ เช่น overlap หรือ gap width

เมื่อไม่ได้ตั้งค่าสีเติมจุดหรือชุดโดยชัดเจน สไตล์และธีมของแผนภูมิจะกำหนดรูปลักษณ์อัตโนมัติ เมื่อทั้งรูปแบบชุดและรูปแบบจุดมีอยู่ รูปแบบจุดจะเป็นลำดับแรกสำหรับจุดนั้น

![chart-series-powerpoint](chart-series-powerpoint.png)

## **กำหนดค่าชุดข้อมูลโดยใช้ลิเตอร์ัลตัวเลข**

ใช้ลิเตอร์ัลตัวเลขเมื่อค่าชุดมาจากข้อมูลหรือการคำนวณของแอปพลิเคชันและไม่จำเป็นต้องอ้างอิงเซลล์ในเวิร์กชีต เรียก [set_DataSourceTypeForValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforvalues/) พร้อม [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) ก่อนกำหนดค่าที่ส่งกลับจาก [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_value/) ของแต่ละจุดผ่าน [set_AsLiteralDouble](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idoublechartvalue/set_asliteraldouble/)

การตั้งค่าคอลเลกชันจะควบคุมประเภทแหล่งที่มาของค่าจุดทั้งหมดในชุด แต่ละ [get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ibasechartvalue/get_datasourcetype/) ของ IBaseChartValue รายงานประเภทที่เลือก เปลี่ยนผ่านการตั้งค่าคอลเลกชัน หากใช้ Worksheet ให้เรียก [get_AsCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/isinglecellchartvalue/get_ascell/) เพื่อเข้าถึงเซลล์ที่อ้างอิง หากใช้ DoubleLiterals ให้เรียก [get_AsLiteralDouble](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idoublechartvalue/get_asliteraldouble/) หรือ set_AsLiteralDouble เพื่ออ่านหรือเขียนตัวเลขโดยตรง

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์พร้อมชุดและหมวดหมู่เริ่มต้น แล้วกำหนดค่าที่คำนวณได้ 10, 20 เป็นต้น ให้กับจุดที่มีอยู่ของชุดแรก บันทึกการนำเสนอ, เปิดใหม่อีกครั้งและพิมพ์ค่าที่เก็บไว้

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
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
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

series->get_DataPoints()->set_DataSourceTypeForValues(DataSourceType::DoubleLiterals);
for (auto i = 0; i < series->get_DataPoints()->get_Count(); i++)
{
    series->get_DataPoints()->idx_get(i)->get_Value()->set_AsLiteralDouble((i + 1) * 10);
}

presentation->Save(u"numeric_literals.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"numeric_literals.pptx");
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedChart = ExplicitCast<IChart>(reopenedSlide->get_Shape(0));
auto reopenedSeries = reopenedChart->get_ChartData()->get_Series()->idx_get(0);
for (auto i = 0; i < reopenedSeries->get_DataPoints()->get_Count(); i++)
{
    auto point = reopenedSeries->get_DataPoints()->idx_get(i);
    Console::WriteLine(point->get_Value()->get_AsLiteralDouble());
}
reopenedPresentation->Dispose();
```

ประเภทแหล่งที่มาของค่าจุดแยกจาก [IChartData::get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_datasourcetype/) ซึ่งระบุการกำหนดค่าเวิร์กบุ๊คภายในหรือภายนอกของแผนภูมิ การใช้ลิเตอร์ัลตัวเลขโดยตัวมันเองไม่ได้ลบเวิร์กบุ๊คที่ฝังอยู่ ในตัวอย่างนี้ เวิร์กบุ๊คยังคงใช้สำหรับป้ายชื่อหมวดหมู่, ชื่อชุดและชุดอื่น ๆ ดู [Chart Workbook](/slides/th/cpp/chart-workbook/) เพื่อการจัดการเวิร์กบุ๊ค

สำหรับแผนภูมิแบบกระจายและฟองน้ำ ให้เรียก [set_DataSourceTypeForXValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforxvalues/) และ [set_DataSourceTypeForYValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforyvalues/) เพื่อเลือกแหล่งที่มาสำหรับ [get_XValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_xvalue/) และ [get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) แผนภูมิบับน้ำ additionally ใช้ [set_DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforbubblesizes/) สำหรับ [get_BubbleSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_bubblesize/) ตั้งค่าแหล่งที่มาที่เกี่ยวข้องเป็น DoubleLiterals ก่อนกำหนดตัวเลขผ่านเมธอด set_AsLiteralDouble ของค่านั้น

## **ตั้งค่าการทับซ้อนของชุดแผนภูมิ**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_overlap/) รายงานว่าคอลัมน์หรือแถบทับซ้อนกันเท่าใดในแผนภูมิ 2D ค่าตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์ เป็นการฉายภาพแบบอ่าน‑อย่างเดียวของการตั้งค่าในกลุ่มชุดแม่ เรียก [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนี้ ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงแถบหรือคอลัมน์แบบจัดกลุ่ม; จะไม่กระทบต่อกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่บรรจุชุดแรก

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

// แผนภูมิใหม่ประกอบด้วยชุดตัวอย่าง, หมวดหมู่, และค่า.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ผลลัพธ์:

![The series overlap](series_overlap.png)

## **เปลี่ยนสีเติมของชุดแผนภูมิ**

ใช้ [IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/) เพื่อกำหนดสีเติมเริ่มต้นสำหรับชุดทั้งหมด หากจุดมีการกำหนดสีเติมโดยชัดเจน [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/) ของจุดนั้นจะครอบคลุมสีเติมของชุดสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้สีเติมสีน้ำเงินทึบกับชุดแรก

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

## **เปลี่ยนชื่อชุดแผนภูมิ**

ชื่อชุดจะถูกจัดเก็บในเวิร์กบุ๊คของแผนภูมิและปกติจะแสดงในคำอธิบาย ในเวิร์กบุ๊คเริ่มต้นสำหรับแผนภูมิคอลัมน์แบบกลุ่ม เซลล์ B1 อยู่ที่แถว 0 คอลัมน์ 1 และบรรจุชื่อของชุดแรก ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างดังกล่าวชัดเจน

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

คุณยังสามารถอัปเดตเซลล์ที่ [IChartSeries::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_name/) อ้างอิงอยู่ วิธีนี้หลีกเลี่ยงการสมมติแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่

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

### **สร้างชุดโดยใช้ชื่อจากหลายเซลล์**

ชื่อชุดแบบผสมเป็นประโยชน์เมื่อชื่อสินค้าและช่วงเวลารายงานถูกจัดเก็บในเซลล์เวิร์กบุ๊คแยกกัน เช่น คุณสามารถรวม `Product A` ใน B1 และ `2026` ใน C1 เป็นชื่อชุดเดียวขณะยังคงเชื่อมต่อแต่ละส่วนกับเซลล์ต้นทางของมัน

ใช้ [IChartDataWorkbook::GetCellCollection](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcellcollection/) เพื่อดึงช่วงชื่อแล้วส่งคอลเลกชันนั้นไปยัง [IChartSeriesCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriescollection/add/) อาร์กิวเมนต์ skipHiddenCells ควบคุมว่าจะรวมเซลล์ที่ซ่อนหรือไม่ `true` จะเว้นไว้, `false` จะรวม ตัวอย่างนี้ใช้ `false` เพื่อรวมทุกเซลล์ในช่วงชื่อ

ตัวอย่างต่อไปนี้สร้างการนำเสนอที่มีหนึ่งชุดและสองจุดข้อมูล เซลล์ B1:C1 ให้เฉพาะชื่อชุด; A2:A3 ให้ป้ายหมวดหมู่, B2:B3 ให้ค่าตัวเลข

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartCellCollection.h>
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

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 620.0f, 180.0f);
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
chart->set_HasLegend(true);

auto workbook = chartData->get_ChartDataWorkbook();
workbook->Clear(0);

// เซลล์สองเซลล์นี้ให้ชื่อชุด.
auto productName = ObjectExt::Box<String>(u"Product A");
auto reportingPeriod = ObjectExt::Box<String>(u"2026");
workbook->GetCell(0, 0, 1, productName);
workbook->GetCell(0, 0, 2, reportingPeriod);
auto nameCells = workbook->GetCellCollection(u"Sheet1!$B$1:$C$1", false);
auto series = chartData->get_Series()->Add(nameCells, ChartType::ClusteredColumn);

// เซลล์แยกต่างหากให้หมวดหมู่และจุดข้อมูลเชิงตัวเลข.
auto northLabel = ObjectExt::Box<String>(u"North");
auto southLabel = ObjectExt::Box<String>(u"South");
auto northCategory = workbook->GetCell(0, 1, 0, northLabel);
auto southCategory = workbook->GetCell(0, 2, 0, southLabel);
chartData->get_Categories()->Add(northCategory);
chartData->get_Categories()->Add(southCategory);
auto northAmount = ObjectExt::Box<int>(120);
auto southAmount = ObjectExt::Box<int>(150);
auto northValue = workbook->GetCell(0, 1, 1, northAmount);
auto southValue = workbook->GetCell(0, 2, 1, southAmount);
series->get_DataPoints()->AddDataPointForBarSeries(northValue);
series->get_DataPoints()->AddDataPointForBarSeries(southValue);

presentation->Save(u"composite_series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ชื่อชุดที่ได้คือ `Product A 2026` โดยมีช่องว่างระหว่างค่าจากสองเซลล์ คำอธิบายจะแสดงเป็นรายการเดียวในคำอธิบายของทั้งสองคอลัมน์ รูปด้านล่างแสดงผลลัพธ์:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **รับสีเติมอัตโนมัติของชุดแผนภูมิ**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) คืนค่าสีที่คำนวณจากดัชนีชุดและสไตล์ของแผนภูมิ นี่คือสีที่ใช้เมื่อสีเติมของชุดไม่ได้กำหนดอย่างชัดเจน การเรียกเมธอดนี้เพียงอ่านสีที่คำนวณ ไม่ได้กำหนดสีเติมใหม่

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดเริ่มต้น

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

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิปริยาย:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

สีที่ได้จะขึ้นกับสไตล์และธีมของแผนภูมิ

## **กำหนดสีเติมที่กลับด้านสำหรับชุดแผนภูมิ**

สำหรับชุดแบบแถบ, คอลัมน์และฟองน้ำ [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) สามารถแสดงค่าลบด้วยสีเติมที่ต่างออกไป ตั้งค่าสีเติมของชุดเป็นสีทึบ, เปิดการกลับด้าน, แล้วกำหนดสีค่าลบผ่าน [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) ค่าติดลบในเวิร์กบุ๊คจะไม่มีการเปลี่ยนแปลง; เพียงสีที่แสดงเท่านั้นที่เปลี่ยน

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยชุดเดียว แถว 0 ของ Worksheet บรรจุชื่อชุด, คอลัมน์ 0 บรรจุชื่อหมวดหมู่, คอลัมน์ 1 บรรจุค่าต่าง ๆ

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

คุณสามารถเปิดการกลับด้านสำหรับจุดเดียวผ่าน [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) ในตัวอย่างต่อไปนี้ การกลับด้านจะปิดสำหรับชุดและเปิดเฉพาะสำหรับจุดที่เลือก จุดนั้นยังถูกกำหนดค่าเป็นค่าลบเพื่อให้เห็นผล

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

เพื่อทำให้จุดหนึ่งว่างโดยไม่ลบจุดอื่น ๆ ให้ตั้งค่าเซลล์เวิร์กบุ๊คที่เป็นพื้นหลังของจุดนั้นเป็น `nullptr` สำหรับแผนภูมิคอลัมน์ ค่าที่พล็อตสามารถเข้าถึงได้ผ่าน [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) จุดข้อมูลจะคงตำแหน่งหมวดหมู่เดิม แต่แผนภูมิจะถือค่านั้นว่าเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ล้างเฉพาะจุดที่สองของชุดแรก

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

แผนภูมิแบบกระจายใช้เซลล์ X และ Y แยกกัน, แผนภูมิบับน้ำก็ใช้เซลล์ขนาด เช่นกัน ลบเฉพาะเซลล์ที่แทนค่าที่คุณต้องการลบ อย่าเรียก [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) เมื่อต้องการเก็บจุดอื่น ๆ เนื่องจากเมธอดนี้จะลบจุดข้อมูลทั้งหมดจากคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนอยู่ซึ่งมีค่าเป็นกรณีแยกจากเซลล์ว่าง เพื่อรวมหรือยกเว้นข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่ ให้ดู [Include Data from Hidden Rows and Columns](/slides/th/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns)

เซลล์เวิร์กบุ๊คที่ว่างแทนข้อมูลที่หายไป; เซลล์ที่มีค่า `0` แทนค่าตัวเลขที่รู้จัก เรียก [IChartDataCell::set_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_value/) ด้วย `nullptr` เพื่อทำให้เซลล์ว่าง ศูนย์จำนวนจะคงเป็นศูนย์ไม่ว่าการตั้งค่าเซลล์ว่างจะเป็นอย่างไร

ใช้ [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_displayblanksas/) เพื่อเลือกวิธีที่แผนภูมิแสดงเซลล์ว่าง การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด มันเปลี่ยนวิธีการพล็อตค่าว่างโดยไม่เติมศูนย์หรือค่าที่ประมาณลงในเซลล์เวิร์กบุ๊คที่ว่าง

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีชุดเดียว, ลบค่าของ Day 3, แล้วบันทึกแผนภูมิเดียวกันในแต่ละโหมด ไม่ต้องใช้ไฟล์อินพุต [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/) ใช้ Worksheet 0, คอลัมน์ 0 สำหรับป้ายหมวดหมู่, และคอลัมน์ 1 สำหรับค่า; แถว 0 บรรจุชื่อชุด ค่าขั้นสุดท้ายคือ `10, 20, empty, 30, 40`

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

// ปล่อยให้วันที่ 3 ว่างจริง ๆ ขณะยังคงรักษาหมวดหมู่และจุดข้อมูลของมันไว้
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

แต่ละไฟล์เอาต์พุตจะบันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx` เพื่อบันทึกเวอร์ชันเดียว ให้กำหนดโหมดที่ต้องการและบันทึกการนำเสนอครั้งเดียวแทนการวนลูปตามโหมด

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในสามไฟล์ Day 3 จะว่างในเวิร์กบุ๊คทุกกรณี:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

ผลกระทบที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ แผนภูมิเส้นทำให้เปรียบเทียบทั้งสามโหมดได้ง่าย แผนภูมิแบบแถบและคอลัมน์ไม่มีเส้นเชื่อมต่อผ่านหมวดหมู่ที่หายไป ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมต่อที่แสดงด้านบน; คอลัมน์ที่หายไปและคอลัมน์ที่สูงศูนย์อาจดูคล้ายกัน เช่นกัน แผนภูมิแบบกระจายที่มีเพียงมาร์คเกอร์ก็ไม่มีเส้นเชื่อมต่อ อย่าคาดหวังผลลัพธ์ที่แตกต่างสามแบบสำหรับทุกประเภทแผนภูมิ; ให้ตรวจสอบเอาต์พุตสำหรับประเภทที่คุณใช้

## **ตั้งค่าความกว้างช่องว่างของชุด**

ความกว้างช่องว่างคือช่องว่างระหว่างกลุ่มแถบหรือคอลัมน์ที่อยู่ติดกัน คำนวณเป็นเปอร์เซ็นต์ของความกว้างแถบหรือคอลัมน์ คล้ายกับการทับซ้อน มันเป็นของกลุ่มชุดแม่ ไม่ใช่ของชุดเดียว เรียก [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) ครั้งเดียวสำหรับกลุ่ม ค่าที่มากจะสร้างช่องว่างมากระหว่างกลุ่ม, ค่าที่น้อยจะทำให้กลุ่มแน่นขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างช่องว่างและบันทึกการนำเสนอครั้งสุดท้ายเท่านั้น

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

## **FAQ**

**แผนภูมิประเภทใดบ้างที่สนับสนุนชุดข้อมูล?**

ทุกประเภทแผนภูมิที่แสดงโดย [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ชุดข้อมูลของแต่ละประเภทไม่ได้มีโครงสร้างค่า หรือการตั้งค่าเดียวกัน เช่น แผนภูมิประเภทหมวดหมู่ใช้ categories และ values, แผนภูมิแบบกระจายใช้ X และ Y values, แผนภูมิบับน้ำเพิ่ม bubble sizes ใช้เมธอดการสร้างจุดข้อมูลที่สอดคล้องกับประเภทชุด ตัวเลือกเช่น overlap และ gap width ใช้ได้กับกลุ่มแถบหรือคอลัมน์ที่เข้ากันได้เท่านั้น

**กลุ่มชุดแผนภูมิคืออะไร?**

[IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/) ประกอบด้วยชุดที่เข้ากันได้ซึ่งแชร์การตั้งค่าการพล็อตระดับกลุ่ม แผนภูมิผสมอาจมีมากกว่าหนึ่งกลุ่ม, ดังนั้นการเปลี่ยนแปลงกลุ่มผ่านชุดหนึ่งไม่จำเป็นต้องเปลี่ยนทุกชุดในแผนภูมิ

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่ โดยค่าเริ่มต้น [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) สร้างชุดตัวอย่าง, หมวดหมู่และค่า คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์ทั้งชุดและคอลเลกชันหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างสมบูรณ์ การ overload ยังสามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้นได้

**แผนภูมิเชื่อมต่อกับเซลล์เวิร์กบุ๊คอย่างไร?**

ชื่อชุด, ป้ายหมวดหมู่และค่าจุดข้อมูลอ้างอิงเซลล์ใน [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/) การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิที่สอดคล้อง เมื่อคุณสร้างข้อมูลกำหนดเอง, รักษาให้แถวหมวดหมู่และแถวค่าชุดสอดคล้องกันเพื่อให้แต่ละจุดถูกพล็อตภายใต้หมวดหมู่ที่ตั้งใจ

**จะลบจุดหนึ่งแทนการลบทั้งชุดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `nullptr` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดเป็นจุดว่าง เรียก [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) เฉพาะเมื่อคุณต้องการลบจุดทั้งหมดจากชุดนั้น หากคุณลบหมวดหมู่ด้วย, ให้อัปเดตทุกชุดเพื่อให้ค่าของพวกเขายังคงสอดคล้องกับคอลเลกชันหมวดหมู่

**จุดว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นกับประเภทแผนภูมิและ [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) แผนภูมิที่รองรับสามารถแสดงค่าว่างเป็นช่องว่าง, เป็นค่า 0 หรือโดยเชื่อมต่อจุดใกล้เคียง เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ ดู [Control the Display of Empty Cells](#control-the-display-of-empty-cells) สำหรับตัวอย่างครบและการเปรียบเทียบภาพ

**ค่าติดลบถูกจัดรูปแบบอย่างไร?**

สำหรับชุดแถบ, คอลัมน์และบับน้ำที่รองรับ, เรียก [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) และกำหนดสีผ่าน [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) คุณสามารถลบการทำงานนี้สำหรับจุดเดี่ยวด้วย [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) เมธอดเหล่านี้ส่งผลต่อการจัดรูปแบบ, ไม่ใช่ค่าตัวเลขที่บันทึกไว้

**รูปแบบใดชนะเมื่อทั้งชุดและจุดมีการจัดรูปแบบ?**

การจัดรูปแบบจุดโดยชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น จุดอื่น ๆ จะใช้รูปแบบชุดที่กำหนดไว้หรือถ้าชุดไม่มีการกำหนดรูปแบบ จะใช้สไตล์และธีมอัตโนมัติของแผนภูมิ การตั้งค่ากลุ่มเช่น overlap และ gap width ควบคุมการจัดวางและไม่ใช่การแทนที่ระดับจุด

**มีขีดจำกัดจำนวนชุดที่แผนภูมิสามารถมีได้หรือไม่?**

Aspose.Slides ไม่กำหนดขีดจำกัดจำนวนชุดแยกจากกัน อย่างไรก็ตามข้อจำกัดของไฟล์พรีเซนเทชั่น, หน่วยความจำที่มี, เวลาเรนเดอร์และความอ่านง่ายของแผนภูมิจะกำหนดขีดจำกัดที่ใช้งานได้จริง

**ควรเปลี่ยนอะไรเมื่อคอลัมน์อยู่ใกล้กันเกินไปหรือห่างเกินไป?**

เรียก [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) บนกลุ่มชุดแม่ที่เหมาะสม เพิ่มค่าที่จะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น, หรือ ลดค่าที่จะทำให้กลุ่มเข้าหาใกล้กันมากขึ้น.