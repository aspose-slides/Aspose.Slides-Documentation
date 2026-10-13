---
title: ปรับแต่งแกนแผนภูมิในงานนำเสนอโดยใช้ C++
linktitle: แกนแผนภูมิ
type: docs
url: /th/cpp/chart-axis/
keywords:
- แกนแผนภูมิ
- แกนแนวตั้ง
- แกนแนวนอน
- ปรับแต่งแกน
- จัดการแกน
- จัดการแกน
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
description: "ค้นพบวิธีใช้ Aspose.Slides สำหรับ C++ เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการสร้างภาพ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนแผนภูมิด้วย Aspose.Slides สำหรับ C++. มันครอบคลุมค่าที่คำนวณของแกน, การสลับแถวและคอลัมน์ของแผนภูมิ, การมองเห็นของแกน, ระยะห่างของป้ายชื่อหมวดหมู่และติ๊กมาร์ก, หมวดหมู่วันที่และการจัดรูปแบบ, การหมุนหัวเรื่อง, การกำหนดตำแหน่งของแกน, หน่วยแสดงผล, และการสเกลลอการิทึม

## **รับค่าสูงสุดบนแกนแนวตั้งในแผนภูมิ**

สร้าง [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) และเพิ่มแผนภูมิพื้นที่พร้อมข้อมูลเริ่มต้น เรียกใช้ [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) ก่อนอ่านค่าที่คำนวณของแกน เพื่อให้การจัดเรียงแผนภูมิเป็นปัจจุบัน

อ่าน [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) และ [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) เพื่อรับขอบเขตของแกน และ [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) และ [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) เพื่อรับช่วงของติ๊ก. [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) และ [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) ให้สเกลหน่วยเวลา ซึ่งเกี่ยวข้องกับแกนวันที่. ตัวอย่างนี้เก็บค่าที่ได้ในตัวแปรภายในและบันทึกแผนภูมิ

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

ใช้ [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) เพื่อแลกเปลี่ยนบทบาทของซีรีส์และหมวดหมู่ในข้อมูลแผนภูมิ. แต่ละหมวดหมู่เดิมจะกลายเป็นซีรีส์, และแต่ละซีรีส์เดิมจะกลายเป็นหมวดหมู่. สิ่งนี้เปลี่ยนวิธีการจัดกลุ่มข้อมูล; ไม่ได้สลับแกนแนวนอนและแนวตั้ง. ตัวอย่างใช้ [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) เพื่อเชื่อมข้อมูลเริ่มต้นกับ `Sheet1!A1:D5`, รวมทั้งแถวหัวเรื่องและคอลัมน์หมวดหมู่, ก่อนทำการสลับแถวและคอลัมน์. มันบันทึกแผนภูมิที่มีสี่ซีรีส์และสามหมวดหมู่

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

## **ปิดการใช้งานแกนแนวตั้งสำหรับแผนภูมิเส้น**

ใช้ [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) พร้อมค่า `false` บนแกนแนวตั้งเพื่อซ่อนไว้. ตัวอย่างนี้สร้างแผนภูมิเส้นพร้อมข้อมูลเริ่มต้นและบันทึกโดยมีแกนแนวตั้งซ่อนอยู่

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

ใช้ [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) พร้อมค่า `false` บนแกนแนวนอนเพื่อซ่อนไว้. ตัวอย่างนี้สร้างแผนภูมิเส้นพร้อมข้อมูลเริ่มต้นและบันทึกโดยมีแกนแนวนอนซ่อนอยู่

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

## **เปลี่ยนแกนหมวดหมู่**

ใช้ [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) เพื่อเลือกแกนหมวดหมู่แบบวันที่หรือข้อความ. ตัวอย่างนี้ต้องการไฟล์ `ExistingChart.pptx`, โดยมีแผนภูมิเป็นรูปแรกบนสไลด์แรกและเซลล์หมวดหมู่มีค่าเลขวันที่ของ Excel. มันเปลี่ยนแกนแนวนอนเป็นแกนวันที่. การเรียกใช้ [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) กับค่า `false`, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) กับค่า `1`, และ [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) กับเดือน จะวางติ๊กหลักที่ช่วงเดือนละหนึ่ง

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

## **ควบคุมช่วงป้ายชื่อแกนหมวดหมู่**

เมื่อแผนภูมิมีหลายหมวดหมู่, ลดจำนวนป้ายชื่อแกนที่มองเห็นได้โดยไม่ลบหมวดหมู่หรือจุดข้อมูล. ใช้ [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) กับค่า `false`, จากนั้นใช้ [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) กับช่วงหมวดหมู่ที่ต้องการ. สำหรับหมวดหมู่ข้อความในลำดับปกติ, การนับเริ่มที่หมวดหมู่แรก:

| ช่วง | ป้ายที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | หมวดหมู่ 1, หมวดหมู่ 2, หมวดหมู่ 3, ... หมวดหมู่ 24 |
| `2` | หมวดหมู่ 1, หมวดหมู่ 3, หมวดหมู่ 5, ... หมวดหมู่ 23 |
| `3` | หมวดหมู่ 1, หมวดหมู่ 4, หมวดหมู่ 7, ... หมวดหมู่ 22 |

ช่วง `3` จะทำให้แสดงทุกป้ายที่สาม, เหลือป้ายสองป้ายระหว่างป้ายที่แสดง. มันไม่ได้ลบคอลัมน์ที่สอดคล้องกัน. การจัดระยะอัตโนมัติเลือกช่วงตามพื้นที่ที่มี; ไม่ได้จำเป็นต้องแสดงทุกป้าย

ติ๊กมาร์กมีการควบคุมแยกต่างหาก. ใช้ [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) กับค่า `false` และใช้ [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) เพื่อกำหนดช่วงของมัน. ตัวอย่างเช่น, `1` จะทำให้มีติ๊กมาร์กที่ทุกช่วงหมวดหมู่ขณะที่ป้ายปรากฏเพียงทุกหมวดหมู่ที่สาม. ใช้ [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) พร้อมสไตล์ที่มองเห็นได้เพื่อให้คุณเห็นผลลัพธ์. การตั้งค่าคุณสมบัติการจัดระยะอัตโนมัติใด ๆ กลับเป็น `true` จะทำให้แผนภูมิเ�เลือกช่วงนั้นอีกครั้ง

ตัวอย่างต่อไปนี้เป็นตัวอย่างอิสระที่สร้าง 24 หมวดหมู่และหนึ่งซีรีส์, จากนั้นบันทึกสามสไลด์ใน `CategoryAxisIntervals.pptx`: การจัดระยะอัตโนมัติ, การจัดระยะด้วยตนเองพร้อมติ๊กมาร์กอิสระ, และการคืนค่าอัตโนมัติ. ทั้งสองสำเนารักษาข้อมูลแผนภูมิเดิม. ไม่ต้องใช้การนำเสนออินพุต. ข้อความป้ายแนวนอนทำให้เห็นความแตกต่างของความหนาแน่นได้ง่าย

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

// Slide 2: แสดงป้ายทุกสามรายการ แต่ยังคงมีติ๊กมาร์กสำหรับทุกหมวดหมู่.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// Slide 3: ให้แผนภูมิเลือกช่วงทั้งสองอีกครั้ง.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**การจัดระยะอัตโนมัติ (สไลด์ 1):** ในการแสดงผลนี้, ป้ายหมวดหมู่ทุกสองรายการจะแสดงและตัดบรรทัดเป็นสองบรรทัด. ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ, ฟอนต์, และเครื่องเรนเดอร์

![การจัดระยะป้ายหมวดหมู่อัตโนมัติพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็น](category-axis-automatic.png)

**การจัดระยะด้วยตนเอง (สไลด์ 2):** ทุกป้ายที่สามจะแสดงบนบรรทัดเดียว, ในขณะที่ติ๊กมาร์กยังคงอยู่ที่ทุกช่วงหมวดหมู่. ทั้ง 24 คอลัมน์, รวมถึงคอลัมน์ที่ไม่มีป้าย, ยังมองเห็นได้ด้วยค่าที่เหมือนกัน. สไลด์ 3 คืนรูปแบบอัตโนมัติที่แสดงด้านบน

![ช่วงป้ายหมวดหมู่ด้วยตนเองที่สามพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็น](category-axis-manual.png)

### **เลือกแกนและช่วงที่ถูกต้อง**

ใช้ช่วงจำนวนหมวดหมู่นี้สำหรับแกนหมวดหมู่แบบข้อความ, เช่น แกนหมวดหมู่ของแผนภูมิคอลัมน์, เส้น, พื้นที่หรือแท่ง. ในแผนภูมิคอลัมน์, เป็นแกนแนวนอน. ในแผนภูมิแท่งแนวนอน, แกนหมวดหมู่อยู่แนวตั้ง, ดังนั้นให้ใช้การตั้งค่านี้กับ [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). การจัดระยะติ๊กมาร์กยังใช้กับแกนซีรีส์ในแผนภูมิที่มี

ไม่ควรใช้การจัดระยะป้ายชื่อเพื่อกำหนดสเกลเชิงตัวเลขของแกนค่า. บนแกนค่า, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) ระบุความแตกต่างของค่า: ตัวอย่างเช่น, หน่วยหลัก `10` จะสร้างติ๊กที่ 0, 10, 20, ฯลฯ เมื่อแกนเริ่มที่ศูนย์. ช่วงป้ายชื่อหมวดหมู่ `3` จะนับตำแหน่งหมวดหมู่โดยไม่คำนึงถึงค่าข้อมูล. แผนภูมิกระจายและฟองใช้แกนค่าแทนแกนหมวดหมู่แบบข้อความ. สำหรับแกนวันที่, ใช้หน่วยหลักและสเกลตามเวลาเช่นที่อธิบายใน [Change a Category Axis](#change-a-category-axis)

## **ตั้งค่ารูปแบบวันที่สำหรับค่าตามแกนหมวดหมู่**

ตัวอย่างนี้แทนค่าข้อมูลเริ่มต้นของแผนภูมิด้วยค่าปีสี่ค่า. วันที่ถูกจัดเก็บเป็นเลขอนุกรม OLE Automation ในแผ่นงานแรก (ดัชนี `0`). ใช้ [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) เพื่อเลือกแกนวันที่, ปิดการจัดรูปแบบที่เชื่อมกับแหล่งด้วย [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/), และกำหนด `yyyy` ด้วย [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) เพื่อให้ป้ายหมวดหมู่แสดงปีสี่หลักโดยอิสระจากการจัดรูปแบบเซลล์

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

เปิดใช้งานชื่อแกนแนวตั้งด้วย [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/), ให้ข้อความชื่อ, และใช้ [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) เพื่อหมุนชื่อ. มุมวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์ที่ชื่อแกนค่าถูกหมุน 90 องศา

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

## **ตั้งค่าตำแหน่งแกนบนแกนหมวดหมู่หรือค่า**

ใช้ [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) เพื่อควบคุมว่าแกนค่าตัดแกนหมวดหมู่ระหว่างหมวดหมู่หรือที่ติ๊กของหมวดหมู่. คุณสมบัตินี้ใช้กับแกนหมวดหมู่. ตัวอย่างตั้งค่าเป็น `true` บนแกนหมวดหมู่แนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์

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

## **ตั้งค่าหน่วยแสดงผลบนแกนค่าของแผนภูมิ**

ใช้ [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) เพื่อสเกลป้ายบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน. เมื่อ [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) ตั้งเป็น `Millions`, ค่า 60,000,000 จะแสดงเป็น 60. ตัวอย่างนี้สร้างแผนภูมิคอลัมน์และใช้หน่วยแสดงผลเป็นล้านบนแกนแนวตั้ง

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

## **กำหนดค่ากราฟแกนค่าลอการิทึม**

แกนค่าลอการิทึมมีประโยชน์เมื่อค่าบวกกระจายหลายลำดับขนาด. ตัวอย่างเช่น, บริการอาจรับคำขอ 10, 100, 1,000, 10,000, และ 100,000 ในห้าช่วงเวลา. บนสเกลเชิงเส้น, ค่าที่เล็กกว่าอยู่ใกล้กันที่ศูนย์. สเกลลอการิทึมทำให้การเติบโตสัมพัทธ์ง่ายต่อการเปรียบเทียบ: ระยะเท่าเทียมแทนสัดส่วนเท่าเทียมแทนความต่างเท่าเทียม

เรียกใช้ [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) กับค่า `true` บนแกนค่าและใช้ [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) เพื่อเลือกฐาน. สิ่งนี้เปลี่ยนวิธีการแสดงค่าที่มีอยู่; ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นแนวโน้มลอการิทึม. เส้นแนวโน้มแสดงความสัมพันธ์ที่ฟิตกับข้อมูลและเป็นฟีเจอร์แยกต่างหาก

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์, แกนค่าคือ [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). สำหรับแผนภูมิแท่งแนวนอน, เป็น [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/). แผนภูมิกระจายและฟองมีสองแกนค่า, ดังนั้นเลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y, หรือทั้งสอง. ไม่ควรใช้การสเกลลอการิทึมกับแกนหมวดหมู่

ฐานลอการิทึมเริ่มต้นคือ `10`. สำหรับแผนภูมิ PPTX, ใช้ฐานตั้งแต่ `2` ถึง `1000` รวมทั้งฐานเศษส่วนเช่น `2.5` ก็รองรับ. ด้วยฐาน `10`, พลังต่อเนื่องเช่น 10, 100, 1,000, และ 10,000 จะเท่า ๆ กัน

### **เปรียบเทียบการสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างต่อไปนี้เป็นตัวอย่างอิสระที่สร้างแผนภูมิเส้นด้วยค่าคำขอห้าครั้งบนสไลด์แรก, จากนั้นคัดลอกสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทึมฐาน-10 บนสไลด์ที่สอง. ทั้งสองสไลด์รักษาข้อมูลเดิม

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

// ทำให้สไลด์แรกเป็นเชิงเส้นและเปลี่ยนสเกลแกนค่าของสำเนาเท่านั้น
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**สเกลเชิงเส้น (สไลด์ 1):** ระยะแนวตั้งเท่า ๆ กันแทนค่าคำขอที่แตกต่างกัน. ค่าที่มากที่สุดครอบคลุมแผนภูมิเพื่อให้ค่าที่น้อยกว่าแยกออกยาก

![แผนภูมิเส้นใน PowerPoint แสดงค่าคำขอห้าครั้งบนแกนค่าที่เป็นเชิงเส้น](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะแนวตั้งเท่า ๆ กันแทนสัดส่วนเท่า ๆ กัน. แต่ละช่วงมีจำนวนคำขอเพิ่มขึ้นสิบเท่า, ดังนั้นจุดข้อมูลจะเป็นเส้นตรงขึ้นบนสเกลฐาน-10. ป้ายแกนยังคงแสดงค่าคำขอเดิม

![ค่าคำขอห้าครั้งเดียวกันใน PowerPoint บนแกนค่าลอการิทึมฐาน-10](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าติดลบ**

สเกลลอการิทึมสามารถแสดงได้เฉพาะค่าบวกเท่านั้น. ตรวจสอบข้อมูลก่อนเปิดใช้งาน. หากค่าศูนย์หรือค่าติดลบมีความหมาย, ให้คงสเกลเชิงเส้นหรือแสดงแยกต่างหาก. หากการคัดค่าเหล่านั้นออกเป็นวิธีที่เหมาะสมสำหรับการวิเคราะห์, ควรอธิบายเหตุผล. ห้ามแทนที่ค่าดังกล่าวด้วยจำนวนบวกเล็ก ๆ อย่างเงียบ ๆ เนื่องจากจะเปลี่ยนความหมายของข้อมูล. ค่าต่ำสุดหรือค่าสูงสุดที่กำหนดเองสำหรับแกนลอการิทึมต้องเป็นบวกเช่นกัน

## **FAQ**

**ฉันจะตั้งค่าตำแหน่งที่แกนหนึ่งตัดกับอีกแกน (การตัดแกน) อย่างไร?**

ใช้ [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) เพื่อเลือกพฤติกรรมการตัด. เพื่อระบุตำแหน่งตัดเชิงตัวเลข, ใช้ [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). การตั้งค่าเหล่านี้ช่วยให้คุณย้ายตำแหน่งการตัดแกนไปยังฐานที่เหมาะสม

**ฉันจะกำหนดตำแหน่งป้ายติ๊กสัมพันธ์กับแกนอย่างไร?**

ใช้ [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) กับค่าจาก [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None`. เพื่อควบคุมติ๊กมาร์กเอง, ใช้ [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) หรือ [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/); สิ่งเหล่านี้แยกจากการกำหนดตำแหน่งป้าย

