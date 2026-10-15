---
title: ปรับแต่งแกนแผนภูมิในงานนำเสนอด้วย C++
linktitle: แกนแผนภูมิ
type: docs
url: /th/cpp/chart-axis/
keywords:
- แกนแผนภูมิ
- แกนแนวตั้ง
- แกนแนวนอน
- ปรับแต่งแกน
- จัดการแกน
- ควบคุมแกน
- คุณสมบัติของแกน
- ค่าสูงสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- ชื่อแกน
- ตำแหน่งแกน
- PowerPoint
- การนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบวิธีใช้ Aspose.Slides สำหรับ C++ เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงภาพ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนของแผนภูมิด้วย Aspose.Slides สำหรับ C++ ครอบคลุมค่าของแกนที่คำนวณ, การสลับแถวและคอลัมน์ของแผนภูมิ, การมองเห็นของแกน, ระยะห่างของป้ายกำกับหมวดหมู่และเครื่องหมายติ๊ก, หมวดหมู่วันที่และการจัดรูปแบบ, การหมุนหัวเรื่อง, การวางตำแหน่งแกน, หน่วยการแสดงผล, และการสเกลแบบลอการิทึม

## **รับค่ามากสุดบนแกนแนวตั้งในแผนภูมิ**

สร้าง [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) และเพิ่มแผนภูมิแบบพื้นที่ด้วยข้อมูลเริ่มต้น เรียกใช้ [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) ก่อนอ่านค่าของแกนที่คำนวณ เพื่อให้การจัดวางแผนภูมิเป็นปัจจุบัน

อ่าน [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) และ [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) สำหรับขอบเขตของแกน, และ [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) และ [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) สำหรับช่วงเครื่องหมายติ๊ก [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) และ [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) ให้สเกลหน่วยเวลา ซึ่งเกี่ยวข้องกับแกนวันที่ ตัวอย่างเก็บค่าต่าง ๆ ไว้ในตัวแปรท้องถิ่นและบันทึกแผนภูมิ

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 100, 100, 500, 350);
chart->ValidateChartLayout();

auto maxValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMaxValue();
auto minValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMinValue();

auto majorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnit();
auto minorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnit();

auto majorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnitScale();
auto minorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnitScale();

presentation->Save(u"AxisValues_out.pptx", SaveFormat::Pptx);
```

## **สลับข้อมูลระหว่างแกน**

ใช้ [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) เพื่อสลับบทบาทของซีรีส์และหมวดหมู่ในข้อมูลแผนภูมิ แต่ละหมวดหมู่เดิมจะกลายเป็นซีรีส์และแต่ละซีรีส์เดิมจะกลายเป็นหมวดหมู่ การเปลี่ยนแปลงนี้ส่งผลต่อการจัดกลุ่มข้อมูล; ไม่ได้สลับแกนแนวนอนและแนวตั้ง ตัวอย่างใช้ [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) เพื่อผูกข้อมูลเริ่มต้นกับ `Sheet1!A1:D5` รวมแถวหัวและคอลัมน์หมวดหมู่ ก่อนสลับแถวและคอลัมน์ และบันทึกแผนภูมิที่มีสี่ซีรีส์และสามหมวดหมู่

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 400, 300);

chart->get_ChartData()->SetRange(u"Sheet1!A1:D5");
chart->get_ChartData()->SwitchRowColumn();

presentation->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **ย้อนลำดับการพล็อตของแกน**

ใช้ [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) เพื่อย้อนลำดับของแกนหมวดหมู่หรือค่า ตัวอย่างเช่น แผนภูมิแท่งแนวนอนสามารถแสดงขั้นตอนของโครงการจากบนลงล่างในลำดับเดียวกับแผ่นงาน: Planning, Development, Testing การย้อนแกนเปลี่ยนทิศทางการพล็อต; ไม่ได้จัดเรียงหรือจัดข้อมูลในเวิร์กบุ๊กใหม่ เมื่อเปรียบเทียบกับ [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) ที่สลับบทบาทของซีรีส์และหมวดหมู่

ตัวอย่างต่อไปนี้สร้างแผนภูมิแท่งแนวนอนที่มีสามขั้นตอนและหนึ่งซีรีส์ โดยบันทึกการนำเสนอที่มีสามสไลด์: ลำดับปกติ, หมวดหมู่ย้อน, และค่าย้อน ตัวอย่างแต่ละสำเนาใช้ชุดข้อมูลเดียวกันและมีการย้อนแกนเพียงแกนเดียวในแต่ละสำเนา

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CrossesType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredBar, 50, 40, 620, 320);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredBar);
auto stages = std::array<System::String, 3>{u"Planning", u"Development", u"Testing"};
auto values = std::array<int, 3>{10, 30, 20};
for (auto i = 0; i < stages.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(stages[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

// สไลด์ 2: แสดงหมวดหมู่แรกที่ด้านบน.
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// คงแกนค่าตามแนวนอนไว้ที่ด้านล่าง.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// สไลด์ 3: ย้อนทิศสเกลเชิงตัวเลขแนวนอนเท่านั้น.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

การย้อนแกนยังสามารถย้ายแกนตั้งฉากไปยังด้านตรงข้ามของพล็อตได้ [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) ควบคุมว่ากราฟอื่นข้ามแกนที่กำหนดไว้ที่ใด ในสไลด์ 2 การตั้งค่าเป็น `Maximum` บนแกนหมวดหมู่ที่ย้อนจะทำให้แกนค่าตั้งแนวนอนอยู่ที่ด้านล่าง สำหรับจุดตัดเฉพาะ ให้ใช้ [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) ตรวจสอบการตั้งค่าการตัดเมื่อเปลี่ยนทิศทาง โดยเฉพาะอย่างยิ่งหากแผนภูมิมีจุดตัดที่กำหนดเองแล้วเรียก `set_IsPlotOrderReversed` ด้วย `false` เพื่อคืนทิศทางการพล็อตปกติ; การตั้งค่าการตัดเป็นค่าแยกต่างหาก

| ลำดับปกติ (สไลด์ 1) | หมวดหมู่ย้อน (สไลด์ 2) | ค่าย้อน (สไลด์ 3) |
| --- | --- | --- |
| ![แผนภูมิแท่งแนวนอนที่แสดงลำดับปกติของแกนหมวดหมู่และค่า](axis-order-normal.png) | ![แผนภูมิแท่งแนวนอนที่แสดงหมวดหมู่จากบนลงล่าง](axis-order-categories-reversed.png) | ![แผนภูมิแท่งแนวนอนที่มีแกนค่าย้อนและศูนย์อยู่ทางขวา](axis-order-values-reversed.png) |
| หมวดหมู่ไหลจากล่างขึ้นบน; ค่ามีการเพิ่มจากซ้ายไปขวา. | Planning, Development, และ Testing ไหลจากบนลงล่าง. ค่และลำดับแถวในเวิร์กบุ๊กไม่มีการเปลี่ยนแปลง. | หมวดหมู่ยังคงลำดับปกติ; ค่ามีการเพิ่มจากขวาไปซ้าย. แกนหมวดหมู่ตัดที่ศูนย์ด้านขวา. |

## **ปิดการใช้งานแกนแนวตั้งสำหรับแผนภูมิเส้น**

ใช้ [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) กับ `false` บนแกนแนวตั้งเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยมีแกนแนวตั้งซ่อนอยู่

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenVerticalAxis.pptx", SaveFormat::Pptx);
```

## **ปิดการใช้งานแกนแนวนอนสำหรับแผนภูมิเส้น**

ใช้ [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) กับ `false` บนแกนแนวนอนเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยมีแกนแนวนอนซ่อนอยู่

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
```

## **เปลี่ยนแกนประเภท**

ใช้ [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) เพื่อเลือกแกนประเภทเป็นวันที่หรือข้อความ ตัวอย่างนี้ต้องการไฟล์ `ExistingChart.pptx` โดยมีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรกและเซลล์หมวดหมู่มีค่าตัวเลขของวันที่ Excel มันจะเปลี่ยนแกนแนวนอนให้เป็นแกนวันที่ การเรียก [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) กับ `false`, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) กับ `1`, และ [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) กับเดือน จะทำให้เครื่องหมายหลักอยู่ที่ช่วงหนึ่งเดือน

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TimeUnitType.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = System::ExplicitCast<IChart>(slide->get_Shape(0));
chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnit(1);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **ควบคุมช่วงป้ายกำกับแกนประเภท**

เมื่อแผนภูมิมีหลายหมวดหมู่ ให้ลดจำนวนป้ายกำกับแกนที่มองเห็นได้โดยไม่ต้องลบหมวดหมู่หรือจุดข้อมูล ใช้ [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) กับ `false` แล้วใช้ [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) กับช่วงหมวดหมู่ที่ต้องการ สำหรับหมวดหมู่ข้อความในลำดับปกติ การนับเริ่มจากหมวดหมู่แรก:

| Interval | ป้ายกำกับที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | หมวด 1, หมวด 2, หมวด 3, ... หมวด 24 |
| `2` | หมวด 1, หมวด 3, หมวด 5, ... หมวด 23 |
| `3` | หมวด 1, หมวด 4, หมวด 7, ... หมวด 22 |

ช่วง `3` จะแสดงป้ายกำกับทุกสามตำแหน่งโดยเว้นสองตำแหน่งไว้ระหว่างป้ายที่แสดง ไม่ได้ลบคอลัมน์ที่สอดคล้องกัน การเว้นระยะอัตโนมัติเลือกช่วงตามพื้นที่ที่มี; ไม่ได้แสดงทุกป้ายเสมอ

เครื่องหมายติ๊กมีการควบคุมแยก ใช้ [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) กับ `false` และใช้ [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) เพื่อกำหนดช่วงของมัน ตัวอย่างเช่น `1` จะทำให้มีเครื่องหมายติ๊กที่ทุกช่วงหมวดหมู่ในขณะที่ป้ายกำกับแสดงเพียงทุกสามหมวดหมู่ ใช้ [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) กับสไตล์ที่มองเห็นได้เพื่อดูผล การตั้งค่าคุณสมบัติเว้นระยะอัตโนมัติใด ๆ กลับเป็น `true` จะให้แผนภูมิกำหนดช่วงนั้นใหม่อีกครั้ง

ตัวอย่างต่อไปนี้สร้าง 24 หมวดหมู่และหนึ่งซีรีส์ จากนั้นบันทึกสามสไลด์ใน `CategoryAxisIntervals.pptx`: การจัดเว้นระยะอัตโนมัติ, การจัดเว้นระยะด้วยตนเองพร้อมเครื่องหมายติ๊กอิสระ, และการคืนค่าให้เป็นอัตโนมัติสำเนาสองฉบับคงข้อมูลแผนภูมิเดิมไว้ ไม่จำเป็นต้องมีการนำเสนออินพุต ข้อความป้ายกำกับแนวนอนทำให้เห็นความหนาแน่นได้ง่าย

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TickMarkType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <DOM/ISlideCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->set_HasLegend(false);
chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredColumn);
for (auto i = 0; i < 24; i++)
{
    auto categoryName = System::String::Format(u"Category {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(10 + i % 6 * 5));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->set_CategoryAxisType(CategoryAxisType::Text);
axis->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(0);
axis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
axis->set_MajorTickMark(TickMarkType::Outside);
axis->set_IsAutomaticTickLabelSpacing(true);
axis->set_IsAutomaticTickMarksSpacing(true);

// สไลด์ 2: แสดงป้ายกำกับทุกสามตำแหน่ง แต่ให้มีเครื่องหมายติ๊กสำหรับทุกหมวดหมู่.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// สไลด์ 3: ให้แผนภูมิเ�เลือกช่วงทั้งสองใหม่อีกครั้ง.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**การจัดเว้นระยะอัตโนมัติ (สไลด์ 1):** ในการแสดงผลนี้ ป้ายกำกับหมวดหมู่ทุกสองตำแหน่งจะแสดงและทำบรรทัดใหม่เป็นสองบรรทัด ผลลัพธ์อัตโนมัติอาจแตกต่างกันตามขนาดแผนภูมิ, ฟอนต์, และเครื่องเรนเดอร์

![การจัดเว้นระยะป้ายกำกับหมวดหมู่อัตโนมัติพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็นได้](category-axis-automatic.png)

**การจัดเว้นระยะด้วยตนเอง (สไลด์ 2):** ป้ายกำกับทุกสามตำแหน่งจะแสดงในบรรทัดเดียว ในขณะที่เครื่องหมายติ๊กยังคงอยู่ที่ทุกช่วงหมวดหมู่ คอลัมน์ทั้งหมด 24 คอลัมน์รวมถึงคอลัมน์ที่ไม่มีป้ายกำกับยังคงมองเห็นได้พร้อมค่าทีเดียวกัน สไลด์ 3 คืนค่าการแสดงผลอัตโนมัติที่แสดงข้างบน

![การจัดเว้นระยะป้ายกำกับหมวดหมู่แบบมือสามพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็นได้](category-axis-manual.png)

### **เลือกแกนและช่วงที่ถูกต้อง**

ใช้ช่วงจำนวนหมวดหมู่นี้สำหรับแกนประเภทข้อความ เช่น แกนประเภทของแผนภูมิคอลัมน์, เส้น, พื้นที่ หรือแท่ง ในแผนภูมิคอลัมน์ เป็นแกนแนวนอน ในแผนภูมิแท่งแนวนอน แกนประเภทจะเป็นแนวตั้ง ดังนั้นให้ใช้การตั้งค่านี้กับ [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) การกำหนดช่วงเครื่องหมายติ๊กยังใช้ได้กับแกนซีรีส์ในแผนภูมิที่มีแกนซีรีส์

ห้ามใช้การจัดเว้นระยะป้ายกำกับหมวดหมู่เพื่อกำหนดสเกลเชิงจำนวนของแกนค่า บนแกนค่า [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) ระบุความแตกต่างของค่า เช่น หน่วยหลัก `10` จะทำให้เครื่องหมายที่ 0, 10, 20 เป็นต้นเมื่อแกนเริ่มจากศูนย์ ส่วนช่วงป้ายกำกับหมวดหมู่ `3` จะนับตำแหน่งหมวดหมู่โดยไม่คำนึงถึงค่าข้อมูล แผนภูมิกระจายและฟองใช้แกนค่าแทนแกนประเภทข้อความ สำหรับแกนวันที่ ให้ใช้หน่วยเวลาและสเกลตามที่อธิบายใน [Change a Category Axis](#change-a-category-axis)

## **ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนประเภท**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยค่าประจำปีสี่ค่า วันที่ถูกเก็บเป็นเลขอนุกรม OLE Automation ในเวิร์กชีตแรก (ดัชนี `0`) ใช้ [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) เพื่อเลือกแกนวันที่, ปิดการเชื่อมโยงรูปแบบตัวเลขกับแหล่งโดยใช้ [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/), และกำหนด `yyyy` ด้วย [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) เพื่อให้ป้ายกำกับแสดงปีสี่หลักโดยอิสระจากการจัดรูปแบบเซลล์

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
for (auto i = 0; i < 4; i++)
{
    auto date = System::DateTime(2015 + i, 1, 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(date.ToOADate()));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(i + 1));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_HorizontalAxis()->set_NumberFormat(u"yyyy");

presentation->Save(u"DateAxisFormat.pptx", SaveFormat::Pptx);
```

## **ตั้งค่ามุมการหมุนสำหรับหัวเรื่องแกนแผนภูมิ**

เปิดใช้งานหัวเรื่องแกนแนวตั้งด้วย [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/), ระบุข้อความหัวเรื่อง, และใช้ [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) เพื่อหมุนหัวเรื่อง มุมวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์พร้อมหัวเรื่องแกนค่าที่หมุน 90 องศา

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartTitle.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"Value");
chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90);

presentation->Save(u"RotatedAxisTitle.pptx", SaveFormat::Pptx);
```

## **ตั้งตำแหน่งแกนบนแกนประเภทหรือค่า**

ใช้ [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) เพื่อควบคุมว่าแกนค่าข้ามแกนประเภทระหว่างหมวดหมู่หรือที่เครื่องหมายติ๊กของหมวดหมู่ คุณสมบัตินี้ใช้กับแกนประเภท ตัวอย่างตั้งเป็น `true` บนแกนประเภทแนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

presentation->Save(u"AxisBetweenCategories.pptx", SaveFormat::Pptx);
```

## **ตั้งค่าหน่วยการแสดงผลบนแกนค่าของแผนภูมิ**

ใช้ [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) เพื่อสเกลป้ายกำกับบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน เมื่อ [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) ตั้งเป็น `Millions` ค่า 60,000,000 จะปรากฏเป็น 60 ตัวอย่างนี้สร้างแผนภูมิคอลัมน์และใช้หน่วยการแสดงผลเป็นล้านบนแกนแนวตั้ง

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/DisplayUnitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

presentation->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **กำหนดค่าแกนค่าลอการิทึม**

แกนค่าลอการิทึมมีประโยชน์เมื่อค่าบวกครอบคลุมหลายระดับจำนวน ตัวอย่างเช่น บริการอาจได้รับ 10, 100, 1,000, 10,000, และ 100,000 คำร้องขอในห้าช่วง บนสเกลเชิงเส้น ค่าต่ำกว่าจะอยู่ชิดกันใกล้ศูนย์ สเกลลอการิทึมทำให้การเปรียบเทียบการเติบโตสัมพันธ์ง่ายขึ้น: ระยะเท่ากันแทนอัตราส่วนที่เท่ากัน ไม่ใช่ความแตกต่างที่เท่าเดิม

เรียก [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) ด้วย `true` บนแกนค่าและใช้ [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) เพื่อเลือฐาน นี้เปลี่ยนวิธีแสดงค่าที่มีอยู่; ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นแนวโน้มลอการิทึม เส้นแนวโน้มเป็นฟีเจอร์แยกต่างหาก

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์ แกนค่าคือ [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) สำหรับแผนภูมิแท่งแนวนอน คือ [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/) แผนภูมิกระจายและฟองมีแกนค่าสองแกน ดังนั้นเลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y, หรือทั้งสองแกน อย่าใช้สเกลลอการิทึมกับแกนประเภท

ฐานลอการิทึมเริ่มต้นคือ `10` สำหรับแผนภูมิ PPTX สามารถใช้ฐานตั้งแต่ `2` ถึง `1000` รวมถึงฐานเศษส่วนเช่น `2.5` ด้วย ฐาน `10` จะให้กำลังต่อเนื่องเช่น 10, 100, 1,000, 10,000 อยู่ห่างกันเท่าเดิม

### **เปรียบเทียบการสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีจำนวนคำร้องขอห้าช่วงบนสไลด์แรก จากนั้นคัดลอกสไลด์นั้นและเปิดใช้แกนค่าลอการิทึมฐาน 10 บนสไลด์ที่สอง ทั้งสองสไลด์คงข้อมูลเดียวกัน

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 30, 40, 660, 200);

chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto values = std::array<double, 5>{10, 100, 1000, 10000, 100000};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = System::String::Format(u"Period {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// คงสไลด์แรกเป็นเชิงเส้นและเปลี่ยนสเกลแกนค่าของสำเนาเท่านั้น.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**สเกลเชิงเส้น (สไลด์ 1):** ระยะแนวตั้งเท่ากันแทนค่าความแตกต่างที่เท่าเดิมของจำนวนคำร้องขอ ค่าที่ใหญ่ที่สุดครอบงำแผนภูมิ ทำให้ค่าต่ำกว่าดูแย่ลง

![แผนภูมิเส้นใน PowerPoint ที่แสดงห้าจำนวนคำร้องขอบนแกนค่าที่เป็นเชิงเส้น](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะแนวตั้งเท่ากันแทนอัตราส่วนที่เท่าเดิม แต่ละช่วงมีจำนวนคำร้องขอเพิ่มเป็นสิบเท่าของช่วงก่อนหน้า ทำให้จุดเหล่านั้นเป็นเส้นตรงที่ขึ้นบนสเกลฐาน 10 แกนป้ายยังคงแสดงจำนวนคำร้องขอเดิม

![ห้าจำนวนคำร้องขอเดียวกันใน PowerPoint บนแกนค่าลอการิทึมฐาน 10](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าติดลบ**

สเกลลอการิทึมสามารถแสดงค่าเป็นบวกเท่านั้น ตรวจสอบข้อมูลก่อนเปิดใช้งาน หากค่าศูนย์หรือค่าน้ำลบมีความหมาย ควรใช้สเกลเชิงเส้นหรือแสดงแยกออก หากการตัดค่าเหล่านั้นออกเป็นสิ่งที่เหมาะสมให้ชี้แจงเหตุผล อย่าแทนที่ค่าด้วยตัวเลขบวกเล็ก ๆ อย่างเงียบ ๆ เพราะจะเปลี่ยนความหมายของข้อมูล ค่า minimum หรือ maximum ที่กำหนดด้วยตนเองสำหรับแกนลอการิทึมต้องเป็นบวกเช่นกัน

## **คำถามที่พบบ่อย**

**How do I set the value at which one axis crosses the other (axis crossing)?**  
ใช้ [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) เพื่อเลือกพฤติกรรมการตัด หากต้องการระบุค่าตัดเชิงตัวเลข ให้ใช้ [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) การตั้งค่าเหล่านี้ช่วยให้คุณย้ายจุดตัดของแกนไปยังฐานที่เหมาะสม

**How can I position tick labels relative to the axis?**  
ใช้ [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) กับค่าจาก [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None` เพื่อควบคุมตำแหน่งป้ายกำกับ เทียบกับแกน หากต้องการควบคุมเครื่องหมายติ๊กเอง ให้ใช้ [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) หรือ [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/) ซึ่งเป็นการตั้งค่าแยกจากตำแหน่งป้ายกำกับ