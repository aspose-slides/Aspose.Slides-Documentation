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
- งานนำเสนอ
- C++
- Aspose.Slides
description: "ค้นพบวิธีการใช้ Aspose.Slides สำหรับ C++ เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงภาพ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนแผนภูมิด้วย Aspose.Slides for C++ รวมถึงค่าแกนที่คำนวณ, การสลับแถวและคอลัมน์ของแผนภูมิ, การแสดงหรือซ่อนแกน, ระยะห่างของป้ายชื่อหมวดหมู่และเครื่องหมายระดับ, หมวดหมู่วันที่และการจัดรูปแบบ, การหมุนชื่อหัวเรื่อง, การกำหนดตำแหน่งแกน, หน่วยการแสดงผล, และการปรับสเกลแบบลอการิทึม

## **รับค่าสูงสุดบนแกนแนวตั้งในแผนภูมิ**

สร้าง [การนำเสนอ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) และเพิ่มแผนภูมิแบบพื้นที่โดยใช้ข้อมูลเริ่มต้น เรียก [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) ก่อนอ่านค่าแกนที่คำนวณเพื่อให้เลย์เอาต์ของแผนภูมิเป็นเวอร์ชันล่าสุด

อ่าน [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) และ [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) เพื่อรับขอบเขตของแกน, และ [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) กับ [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) เพื่อรับระยะห่างของเครื่องหมายระดับ [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) และ [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) ให้สเกลหน่วยเวลา ซึ่งเกี่ยวข้องกับแกนวันที่ ตัวอย่างเก็บค่าดังกล่าวในตัวแปรท้องถิ่นและบันทึกแผนภูมิ

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

ใช้ [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) เพื่อเปลี่ยนบทบาทของซีรีส์และหมวดหมู่ในข้อมูลแผนภูมิ แต่ละหมวดหมู่เดิมจะกลายเป็นซีรีส์และแต่ละซีรีส์เดิมจะกลายเป็นหมวดหมู่ สิ่งนี้เปลี่ยนวิธีการจัดกลุ่มข้อมูล; ไม่ได้สลับแกนแนวนอนและแนวตั้ง ตัวอย่างใช้ [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) เพื่อผูกข้อมูลเริ่มต้นกับ `Sheet1!A1:D5` รวมถึงแถวหัวเรื่องและคอลัมน์หมวดหมู่ ก่อนสลับแถวและคอลัมน์ จากนั้นบันทึกแผนภูมิที่มีสี่ซีรีส์และสามหมวดหมู่

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

## **กลับทิศทางการพล็อตของแกน**

ใช้ [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) เพื่อกลับลำดับการพล็อตของแกนหมวดหมู่หรือค่า ตัวอย่างเช่น แผนภูมิแท่งแนวนอนสามารถแสดงขั้นตอนของโครงการจากบนลงล่างในลำดับเดียวกับแผ่นงาน: Planning, Development, Testing การกลับแกนเปลี่ยนทิศทางการพล็อต; ไม่ได้จัดเรียงหรือปรับข้อมูลในเวิร์กบุ๊ก โดยเทียบกับ [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) ที่แลกเปลี่ยนบทบาทของซีรีส์และหมวดหมู่

ตัวอย่างต่อไปสร้างแผนภูมิแท่งแนวนอนที่มีสามขั้นตอนและหนึ่งซีรีส์ บันทึกการนำเสนอที่มีสามสไลด์: ลำดับปกติ, แกนหมวดหมู่กลับ, และแกนค่ากลับ แต่ละสำเนาใช้ชุดข้อมูลเดียวกันและมีการกลับแกนเพียงแกนเดียวต่อสำเนา

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

// Slide 2: แสดงหมวดหมู่แรกที่ด้านบน.
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// คงแกนค่าตามแนวนอนที่ด้านล่าง.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// Slide 3: สลับทิศสเกลเชิงตัวเลขแนวนอนเท่านั้น.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

การกลับแกนอาจทำให้แกนตั้งฉากย้ายไปด้านตรงข้ามของพลอตได้ [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) ควบคุมว่แกนอื่นตัดกับแกนที่กำหนดอย่างไร ในสไลด์ 2 การตั้งค่าเป็น `Maximum` บนแกนหมวดหมู่ที่กลับกลับ ทำให้แกนค่าตั้งอยู่ที่ด้านล่างของแกนนอน สำหรับจุดตัดที่กำหนดโดยเฉพาะ ให้ใช้ [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) ตรวจสอบการตั้งค่าการตัดเมื่อเปลี่ยนทิศทาง โดยเฉพาะเมื่อแผนภูมิมีจุดตัดแบบกำหนดเองแล้ว เรียก `set_IsPlotOrderReversed` พร้อมค่า `false` เพื่อคืนทิศทางการพล็อตปกติ; การตั้งค่าการตัดเป็นการตั้งค่าแยกจากกัน

| ลำดับปกติ (สไลด์ 1) | แกนหมวดหมู่กลับ (สไลด์ 2) | แกนค่ากลับ (สไลด์ 3) |
| --- | --- | --- |
| ![แผนภูมิแท่งแนวนอนที่มีลำดับแกนหมวดหมู่และค่าแบบปกติ](axis-order-normal.png) | ![แผนภูมิแท่งแนวนอนที่แสดงหมวดหมู่จากบนลงล่าง](axis-order-categories-reversed.png) | ![แผนภูมิแท่งแนวนอนที่มีแกนค่ากลับและศูนย์อยู่ด้านขวา](axis-order-values-reversed.png) |
| หมวดหมู่ไหลจากล่างขึ้นบน; ค่ามีการเพิ่มจากซ้ายไปขวา. | Planning, Development, และ Testing ไหลจากบนลงล่าง. ค่ารวมถึงลำดับแถวในเวิร์กบุ๊กไม่เปลี่ยน. | หมวดหมู่คงลำดับเดิม; ค่ามีการเพิ่มจากขวาไปซ้าย. แกนหมวดหมู่ตัดที่ศูนย์ด้านขวา. |

## **ซ่อนแกนแนวตั้งสำหรับแผนภูมิเส้น**

ใช้ [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) กับค่า `false` บนแกนแนวตั้งเพื่อซ่อน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยซ่อนแกนแนวตั้ง

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

## **ซ่อนแกนแนวนอนสำหรับแผนภูมิเส้น**

ใช้ [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) กับค่า `false` บนแกนแนวนอนเพื่อซ่อน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยซ่อนแกนแนวนอน

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

## **แสดงหรือซ่อนเส้นกริดของแผนภูมิ**

ใช้ [get_ShowMajorGridLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_showmajorgridlines/) และ [get_ShowMinorGridLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_showminorgridlines/) เพื่อตรวจสอบว่าแกนแสดงเส้นกริดใดบ้าง ทั้งสองคุณสมบัติเสียเพียงอ่านอย่างเดียว เพื่อแสดงเส้นกริดย่อย ให้ใช้ [get_MinorGridLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_minorgridlinesformat/) แล้วตั้งการเติมเส้นเป็นสีทึบที่มองเห็นได้ เพื่อซ่อนให้ตั้งค่าเป็น [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) ใช้ [get_MajorGridLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_majorgridlinesformat/) เพื่อเปลี่ยนเส้นกริดใหญ่อย่างเดียวกัน การเปลี่ยนการเติมสีของเส้นกริดจะไม่กระทบต่อการมองเห็นแกนหรือเครื่องหมายระดับ

แกนแนวตั้งของแผนภูมิคอลัมน์แบบคลัสเตอร์นี้เริ่มต้นแสดงเพียงเส้นกริดหลัก ตัวอย่างแสดงเส้นกริดย่อยเป็นสีส้ม จากนั้นซ่อนอีกครั้งก่อนบันทึกการนำเสนอ

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartLinesFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 30, 660, 230);
auto axis = chart->get_Axes()->get_VerticalAxis();
std::cout << std::boolalpha << "Initial: major=" << axis->get_ShowMajorGridLines() << ", minor=" << axis->get_ShowMinorGridLines() << '\n';

auto minorFill = axis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat();
minorFill->set_FillType(FillType::Solid);
minorFill->get_SolidFillColor()->set_Color(Color::get_DarkOrange());
std::cout << "Enabled: minor=" << axis->get_ShowMinorGridLines() << '\n';

minorFill->set_FillType(FillType::NoFill);
std::cout << "Hidden: major=" << axis->get_ShowMajorGridLines() << ", minor=" << axis->get_ShowMinorGridLines() << '\n';

presentation->Save(u"ChartGridlines.pptx", SaveFormat::Pptx);
```

| เส้นกริดย่อยเปิด | เส้นกริดย่อยซ่อน |
| --- | --- |
| ![เส้นกริดย่อยสีส้มระหว่างเส้นกริดหลักบนแกนแนวตั้ง](minor-gridlines-enabled.png) | ![แผนภูมิคอลัมน์เดียวกันที่เห็นเฉพาะเส้นกริดหลัก](minor-gridlines-hidden.png) |

## **เปลี่ยนแกนหมวดหมู่**

ใช้ [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) เพื่อเลือกแกนหมวดหมู่แบบวันที่หรือข้อความ ตัวอย่างนี้ต้องการไฟล์ `ExistingChart.pptx` ที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรกและเซลล์หมวดหมู่อ้างอิงค่าจำนวนวันที่จาก Excel มันเปลี่ยนแกนนอนให้เป็นแกนวันที่ การเรียก [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) กับค่า `false`, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) กับค่า `1`, และ [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) กับเดือน จะวางเครื่องหมายระดับหลักที่ช่วงหนึ่งเดือน

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

### **กำหนดประเภทแกนหมวดหมู่จากข้อมูล**

เรียก [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/) หลังจากใส่ค่าหมวดหมู่แล้ว จากนั้นเรียก [get_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_categoryaxistype/) เพื่อตรวจสอบการเลือก วิธีนี้มีประโยชน์เมื่อแผนภูมิเดียวกันอาจได้รับป้ายข้อความหรือค่าตัวเลขวันที่ วิธีนี้กำหนดประเภทเมื่อถูกเรียก; ไม่ได้เปิดโหมดคงที่ที่ประเมินข้อมูลใหม่ภายหลัง เรียกใหม่หลังจากแทนที่หมวดหมู่

ตัวอย่างต่อไปสร้างแผนภูมิที่มีหมวดหมู่ข้อความและพิมพ์ `Text` จากนั้นแทนค่าของเซลล์หมวดหมู่ด้วยวันที่และเรียกเมธอดอีกครั้ง ซึ่งพิมพ์ `Date` วันที่ถูกเก็บเป็นค่าตัวเลข OLE Automation ที่คืนค่าจาก [System::DateTime::ToOADate](https://reference.aspose.com/slides/cpp/system/datetime/tooadate/) ไม่ใช่สตริงวันที่ [set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) ควบคุมการแสดงค่าดังกล่าว; ไม่ได้แปลงข้อความเป็นวันที่ตัวเลข สำหรับข้อมูลเพิ่มเติมเกี่ยวกับเซลล์หมวดหมู่ ดูที่ [Chart Workbook](/slides/th/cpp/chart-workbook/)

ใช้การกำหนดอัตโนมัติเมื่ออินพุตมีหมวดหมู่แบบข้อความหรือวันที่ตัวเลข ตามที่ตัวอย่างนี้ แสำหรับป้ายกำกับตัวเลขธรรมดา, หมวดหมู่ผสม, หรือข้อมูลว่าง ให้เรียก [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_categoryaxistype/) อย่างชัดเจนเพื่อให้สอดคล้องกับความหมายที่ตั้งใจ ค่าเชิงตัวเลขอย่างเดียวไม่บ่งบอกว่าหมวดหมู่เป็นวันที่

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/date_time.h>
#include <system/console.h>
#include <system/enum.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto seriesName = workbook->GetCell(0, 0, 1, System::ObjectExt::Box(System::String(u"Sales")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesName, chart->get_Type());
auto labels = std::array<System::String, 3>{u"First", u"Second", u"Third"};

for (auto i = 0; i < labels.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(labels[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box((i + 1) * 10));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->SetCategoryAxisTypeAutomatically();
System::Console::WriteLine(System::Enum<CategoryAxisType>::GetName(axis->get_CategoryAxisType())); // ข้อความ

auto dates = std::array<System::DateTime, 3>{System::DateTime(2026, 1, 1), System::DateTime(2026, 1, 2), System::DateTime(2026, 2, 1)};

for (auto i = 0; i < dates.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0);
    categoryCell->set_Value(System::ObjectExt::Box(dates[i].ToOADate()));
    categoryCell->set_CustomNumberFormat(u"yyyy-mm-dd");
}

axis->SetCategoryAxisTypeAutomatically();
System::Console::WriteLine(System::Enum<CategoryAxisType>::GetName(axis->get_CategoryAxisType())); // วันที่

presentation->Save(u"AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
```

## **ควบคุมระยะห่างของป้ายชื่อแกนหมวดหมู่**

เมื่อแผนภูมิมีหมวดหมู่จำนวนมาก ลดจำนวนป้ายชื่อแกนที่มองเห็นได้โดยไม่ต้องลบหมวดหมู่หรือจุดข้อมูล ใช้ [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) กับค่า `false` แล้วใช้ [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) พร้อมระยะห่างของหมวดหมู่ที่ต้องการ สำหรับหมวดหมู่ข้อความในลำดับปกติ การนับเริ่มที่หมวดหมู่แรก:

| ระยะห่าง | ป้ายชื่อที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

ระยะห่าง `3` แสดงทุกป้ายชื่อที่สาม โดยปล่อยให้สองป้ายชื่อค้างระหว่างป้ายที่แสดง ไม่ได้ลบคอลัมน์ที่เกี่ยวข้อง การจัดช่องว่างอัตโนมัติเลือกระยะห่างตามพื้นที่ที่มีอยู่; ไม่จำเป็นต้องแสดงทุกป้ายชื่อ

เครื่องหมายระดับมีการควบคุมแยกกัน ใช้ [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) กับค่า `false` แล้วใช้ [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) เพื่อกำหนดระยะห่างของเครื่องหมายระดับ ตัวอย่างเช่น `1` จะทำให้มีเครื่องหมายระดับที่ทุกช่วงหมวดหมู่โดยที่ป้ายชื่อปรากฏเพียงทุกช่วงที่สาม ใช้ [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) พร้อมสไตล์ที่มองเห็นได้เพื่อดูผลลัพธ์ การตั้งค่าคุณสมบัติเชิงอัตโนมัติใด ๆ กลับเป็น `true` จะให้แผนภูมิกำหนดระยะห่างนั้นใหม่อีกครั้ง

ตัวอย่างต่อไปสร้างหมวดหมู่ 24 รายการและหนึ่งซีรีส์ จากนั้นบันทึกสามสไลด์ในไฟล์ `CategoryAxisIntervals.pptx`: การจัดช่องว่างอัตโนมัติ, การจัดช่องว่างด้วยมือพร้อมเครื่องหมายระดับอิสระ, และการคืนค่าเป็นการจัดช่องว่างอัตโนมัติ สองสำเนารักษาข้อมูลแผนภูมิดั้งเดิม ไม่จำเป็นต้องมีการนำเสนออินพุต ข้อความป้ายแนวนอนทำให้เห็นความหนาแน่นได้ชัดเจน

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

// Slide 2: แสดงทุกป้ายชื่อที่สาม แต่คงเครื่องหมายระดับสำหรับทุกหมวดหมู่.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// Slide 3: ให้แผนภูมิกำหนดช่วงทั้งสองใหม่อีกครั้ง.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**การจัดช่องว่างอัตโนมัติ (สไลด์ 1):** ในการแสดงผลนี้ ป้ายชื่อทุกสองหมวดหมู่จะปรากฏและห่อบรรทัดเป็นสองบรรทัด ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ, ฟอนต์, และเรนเดอร์

![การจัดช่องว่างป้ายชื่อหมวดหมู่อัตโนมัติพร้อมคอลัมน์ 24 คอลัมน์ที่มองเห็นทั้งหมด](category-axis-automatic.png)

**การจัดช่องว่างด้วยมือ (สไลด์ 2):** ป้ายชื่อทุกสามตำแหน่งจะแสดงในบรรทัดเดียวขณะที่เครื่องหมายระดับอยู่ที่ทุกช่วงหมวดหมู่ ทั้ง 24 คอลัมน์รวมถึงที่ไม่มีป้ายชื่อยังคงมองเห็นได้ด้วยค่าเดียวกัน สไลด์ 3 คืนค่าการแสดงผลอัตโนมัติที่แสดงข้างต้น

![ระยะห่างป้ายชื่อหมวดหมู่แบบมือสามตำแหน่งพร้อมคอลัมน์ 24 คอลัมน์ที่มองเห็นทั้งหมด](category-axis-manual.png)

### **เลือกแกนและระยะห่างที่ถูกต้อง**

ใช้ระยะห่างจำนวนหมวดหมู่นี้สำหรับแกนหมวดหมู่แบบข้อความ เช่น แกนหมวดหมู่ของคอลัมน์, เส้น, พื้นที่ หรือแผนภูมิแท่ง ในแผนภูมิคอลัมน์นั้นเป็นแกนนอน ในแผนภูมิแท่งแนวนอนแกนหมวดหมู่เป็นแนวตั้ง ดังนั้นให้ใช้การตั้งค่านี้กับ [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) การจัดช่องว่างของเครื่องหมายระดับยังใช้ได้กับแกนซีรีส์ในแผนภูมิที่มี

ห้ามใช้การจัดช่องว่างของป้ายชื่อหมวดหมู่เพื่อกำหนดสเกลเชิงตัวเลขของแกนค่า บนแกนค่า, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) ระบุความแตกต่างของค่าตัวเลข: ตัวอย่างเช่น หน่วยหลัก `10` จะทำให้เครื่องหมายระดับที่ 0, 10, 20 เป็นต้นเมื่อแกนเริ่มที่ศูนย์ ระยะห่างป้ายชื่อหมวดหมู่ `3` จะนับตำแหน่งหมวดหมู่โดยไม่สนใจค่าข้อมูล แผนภูมิกระจายและฟองใช้แกนค่าแทนแกนหมวดหมู่แบบข้อความ สำหรับแกนวันที่ ใช้หน่วยและสเกลตามเวลาตามที่อธิบายในส่วน [Change a Category Axis](#change-a-category-axis)

## **ตั้งค่ารูปแบบวันที่สำหรับค่าแกนหมวดหมู่**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิดั้งเดิมด้วยค่าปีสี่ค่า วันที่ถูกจัดเก็บเป็นหมายเลขอนุกรม OLE Automation ในแผ่นงานแรก (ดัชนี `0`) ใช้ [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) เพื่อเลือกแกนวันที่ ปิดการเชื่อมรูปแบบตัวเลขกับแหล่งที่มาด้วย [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/) และกำหนด `yyyy` ด้วย [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) เพื่อให้ป้ายชื่อหมวดหมู่แสดงปีสี่หลักโดยอิสระจากการฟอร์แมตในเซลล์

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

## **ตั้งค่ามุมการหมุนสำหรับชื่อแกนแผนภูมิ**

เปิดใช้งานชื่อแกนแนวตั้งด้วย [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/), ระบุข้อความชื่อหัวเรื่อง, และใช้ [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) เพื่อหมุนชื่อหัวเรื่อง มุมวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์โดยหมุนชื่อแกนค่าที่ 90 องศา

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

## **ตั้งตำแหน่งแกนบนแกนหมวดหมู่หรือค่า**

ใช้ [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) เพื่อควบคุมว่าแกนค่าจะตัดแกนหมวดหมู่ระหว่างหมวดหมู่หรือที่เครื่องหมายระดับหมวดหมู่ คุณสมบัตินี้ใช้กับแกนหมวดหมู่ ตัวอย่างตั้งค่าเป็น `true` บนแกนหมวดหมู่แนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์

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

ใช้ [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) เพื่อปรับสเกลป้ายกำกับบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน ด้วย [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) ที่ตั้งเป็น `Millions` ค่า 60,000,000 จะถูกแสดงเป็น 60 ตัวอย่างสร้างแผนภูมิคอลัมน์และใช้หน่วยการแสดงผลเป็นล้านบนแกนแนวตั้ง

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

## **กำหนดค่าการแสดงผลแกนค่าลอการิทึม**

แกนค่าลอการิทึมมีประโยชน์เมื่อค่าบวกกระจายหลายระดับ ตัวอย่างเช่น บริการอาจรับคำขอ 10, 100, 1,000, 10,000, และ 100,000 ครั้งในห้าช่วง เวลาแบบเชิงเส้นค่าตัวเลขเล็กจะอยู่ใกล้ศูนย์ แต่อักขระลอการิทึมทำให้การเจริญเติบโตสัมพัทธ์ง่ายต่อการเปรียบเทียบ: ระยะทางเท่ากันแสดงอัตราส่วนเท่ากันไม่ใช่ความต่างเท่ากัน

เรียก [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) ด้วย `true` บนแกนค่าและใช้ [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) เพื่อเลือกฐาน การเปลี่ยนนี้จะส่งผลต่อการแสดงผลค่าที่มีอยู่; ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นแนวโน้มลอการิทึม เส้นแนวโน้มเป็นคุณลักษณะแยก

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์ แกนค่าคือ [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) สำหรับแผนภูมิแท่งแนวนอนคือ [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/) แผนภูมิกระจายและฟองมีแกนค่าสองแกน ดังนั้นเลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y, หรือทั้งสอง อย่าใช้สเกลลอการิทึมกับแกนหมวดหมู่

ฐานลอการิทึมเริ่มต้นคือ `10` สำหรับแผนภูมิ PPTX ใช้ฐานตั้งแต่ `2` ถึง `1000` รวมทั้งฐานเศษส่วนเช่น `2.5` ก็รองรับด้วย ฐาน `10` จะให้พลังงานต่อเนื่องเช่น 10, 100, 1,000, 10,000 ที่เว้นระยะเท่ากัน

### **เปรียบเทียบสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างต่อไปสร้างแผนภูมิเส้นที่แสดงจำนวนการร้องขอห้าวันบนสไลด์แรก แล้วคัดลอกสไลด์นั้นและเปิดใช้แกนค่าลอการิทึมฐาน‑10 บนสไลด์ที่สอง ทั้งสองสไลด์คงข้อมูลเดียวกัน

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

// รักษาให้สไลด์แรกเป็นเชิงเส้นและเปลี่ยนสเกลแกนค่าของสำเนาเท่านั้น.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**สเกลเชิงเส้น (สไลด์ 1):** ระยะทางแนวตั้งเท่ากันแสดงความแตกต่างของจำนวนการร้องขอ ค่าที่สูงสุดครอบคลุมแผนภูมิ ทำให้ค่าต่ำกว่าแยกไม่ออก

![แผนภูมิเส้นใน PowerPoint แสดงจำนวนการร้องขอห้ารายการบนแกนค่าที่เป็นเชิงเส้น](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะทางแนวตั้งเท่ากันแสดงอัตราส่วนที่เท่ากัน แต่ละช่วงมีจำนวนการร้องขอเพิ่มขึ้นสิบเท่าจากช่วงก่อนหน้า ดังนั้นจุดข้อมูลจะสร้างเส้นตรงขึ้นบนสเกลฐาน‑10 ป้ายแกนยังคงแสดงจำนวนการร้องขอเดิม

![จำนวนการร้องขอห้ารายการเดียวกันใน PowerPoint บนแกนค่าลอการิทึมฐาน‑10](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าลบ**

สเกลลอการิทึมสามารถแสดงได้เฉพาะค่าบวกเท่านั้น ตรวจสอบข้อมูลก่อนเปิดใช้งาน หากค่าศูนย์หรือค่าลบมีความหมายควรใช้สเกลเชิงเส้นหรือแสดงแยกออก หากการยกเว้นค่าดังกล่าวเป็นการวิเคราะห์ที่เหมาะสม ให้อธิบายเหตุผล อย่าแทนที่ค่าดังกล่าวด้วยตัวเลขบวกเล็ก ๆ อย่างเงียบ ๆ เพราะจะเปลี่ยนความหมายของข้อมูล ค่าอย่างน้อยหรือมากสุดที่ตั้งค่าโดยมือสำหรับแกนลอการิทึมต้องเป็นบวกเช่นกัน

## **FAQ**

**ฉันจะตั้งค่าจุดที่แกนหนึ่งตัดกับอีกแกน (การตัดแกน) อย่างไร?**

ใช้ [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) เพื่อเลือกพฤติกรรมการตัด ใช้ [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) เพื่อระบุค่าตัดเชิงตัวเลข การตั้งค่าเหล่านี้ช่วยให้คุณย้ายการตัดแกนไปยังระดับฐานที่เหมาะสม

**ฉันจะจัดตำแหน่งป้ายระดับสัมพันธ์กับแกนอย่างไร?**

ใช้ [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) กับค่าจาก [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None` เพื่อควบคุมป้ายระดับ สำหรับเครื่องหมายระดับเอง ใช้ [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) หรือ [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/) ซึ่งแยกจากการจัดตำแหน่งป้ายชื่อ