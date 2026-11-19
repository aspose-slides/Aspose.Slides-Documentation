---
title: ปรับแต่งแผนภูมิ 3D ในงานนำเสนอด้วย C++
linktitle: แผนภูมิ 3D
type: docs
url: /th/cpp/3d-chart/
keywords:
- แผนภูมิ 3D
- การหมุน
- ความลึก
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "สร้างแผนภูมิ 3D ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ C++. ปรับการหมุน, สัดส่วนความสูง, ความลึกของแผนภูมิ, และระยะห่างระหว่างชุดข้อมูลด้วยตัวอย่าง C++."
---
## **ภาพรวม**

Aspose.Slides for C++ ช่วยให้คุณปรับแต่งมุมมองของแผนภูมิ 3 มิติผ่าน [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). บทความนี้แสดงวิธีปรับการหมุน, สัดส่วนความสูง, ความลึก, แกนมุมฉาก, และระยะห่างระหว่างชุดข้อมูล, จากนั้นบันทึกงานนำเสนอเป็นรูปแบบ PPTX.

## **ตั้งค่าการหมุนและความลึกของแผนภูมิ 3 มิติ**

ตัวอย่างด้านล่างสร้าง [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) และใช้ [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) เพื่อเพิ่มแผนภูมิคอลัมน์ 3 มิติแบบสแต็กบนสไลด์แรกของมัน. ตัวอย่างนี้แทนที่ชุดข้อมูลและประเภทเริ่มต้นด้วยสองชุดข้อมูลที่แต่ละชุดมีค่า 3 ค่า. ดัชนีแผ่นงาน `0` ระบุแผ่นงานข้อมูลแรกของแผนภูมิ; แถว `0` เก็บชื่อชุดข้อมูล, และคอลัมน์ `0` เก็บป้ายชื่อประเภท.

[set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) และ [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) ตั้งค่าการหมุนของแผนภูมเป็น 40 และ 270 องศาตามลำดับ. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) ตั้งค่าความลึกเป็น 150% ของความกว้าง, ขณะเดียวกัน [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) เปิดใช้งานแกนมุมฉากแทนการมองแบบมุมมอง. งานนำเสนอที่ได้จะมีแผนภูมิที่เติมข้อมูลโดยใช้การตั้งค่ามุมมอง 3 มิติเหล่านี้.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn3D, 0, 0, 500, 500);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheetIndex = 0;

double values[2][3] = { { 20, 50, 30 }, { 30, 10, 60 } };

for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    auto categoryName = String::Format(u"Category {0}", categoryIndex + 1);
    auto categoryCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, 0, ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
}

for (auto seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    auto seriesName = String::Format(u"Series {0}", seriesIndex + 1);
    auto seriesCell = workbook->GetCell(worksheetIndex, 0, seriesIndex + 1, ObjectExt::Box(seriesName));
    auto series = chart->get_ChartData()->get_Series()->Add(seriesCell, chart->get_Type());

    for (auto categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        auto valueCell = workbook->GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, ObjectExt::Box(values[seriesIndex][categoryIndex]));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }
}

chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(270);
chart->get_Rotation3D()->set_DepthPercents(150);

presentation->Save(u"Rotation3D_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **ปรับสัดส่วนความสูงของแผนภูมิ 3 มิติ**

ใช้ [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) เพื่อตั้งค่าความสูงของแผนภูมิ 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง. วิธีนี้เปลี่ยนสัดส่วนของฉาก 3 มิติโดยไม่ต้องปรับขนาดวัตถุแผนภูมิบนสไลด์.

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) ด้วยข้อมูลเริ่มต้น: สามชุดข้อมูลและสี่ประเภท. ตัวอย่างบันทึกงานนำเสนอสามไฟล์โดยใช้สัดส่วนความสูง 50%, 100% และ 200%. ตำแหน่ง, ความกว้างและความสูงของแผนภูมิคงที่. ข้อมูล, การหมุน, ความลึก, ระยะห่างระหว่างชุดข้อมูลและการจัดรูปแบบเหมือนกันในไฟล์ทั้งสาม; มีเพียงเปอร์เซ็นต์ความสูงที่เปลี่ยน.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 460);
chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_DepthPercents(100);
chart->get_ChartData()->get_Series()->idx_get(0)->get_ParentSeriesGroup()->set_GapDepth(150);

for (uint16_t heightPercent : { 50, 100, 200 })
{
    chart->get_Rotation3D()->set_HeightPercents(heightPercent);
    auto fileName = String::Format(u"chart_height_{0}.pptx", heightPercent);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

ภาพต่อไปนี้มาจากตัวอย่าง .NET ที่เทียบเท่า ซึ่งส่งออกโดย Microsoft PowerPoint และแสดงการตั้งค่าความสูงเดียวกัน. ค่าเปอร์เซ็นต์ที่เล็กกว่าจะทำให้ฉากแบนลง, ในขณะที่ค่าเปอร์เซ็นต์ที่ใหญ่กว่าจะทำให้ฉากสูงขึ้นภายในวัตถุแผนภูมิเดียวกัน. PowerPoint อาจปรับช่วงของตารางแกนและตำแหน่งป้ายชื่อเพื่อให้พอดีกับฉากด้วย.

| ความสูง: 50% | ความสูง: 100% | ความสูง: 200% |
| --- | --- | --- |
| ![แผนภูมิคอลัมน์ 3 มิติที่มีความสูงตั้งค่าเป็น 50% ของความกว้าง](height_percent_50.png) | ![แผนภูมิคอลัมน์ 3 มิติที่มีความสูงตั้งค่าเป็น 100% ของความกว้าง](height_percent_100.png) | ![แผนภูมิคอลัมน์ 3 มิติที่มีความสูงตั้งค่าเป็น 200% ของความกว้าง](height_percent_200.png) |

เมธอดเหล่านี้ควบคุมแง่มุมต่างๆ ของแผนภูมิ:

| เมธอด | ผลลัพธ์ |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | ความสูงของฉาก 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | ความสูงของวัตถุแผนภูมบนสไลด์, หน่วยเป็นพอยต์ |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | ความลึกของฉาก 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | ระยะห่างระหว่างชุดข้อมูลตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างของมาร์คเกอร์ |

การตั้งค่าความสูงส่งผลต่อแผนภูมิคอลัมน์และแผนภูมิบาร์ 3 มิติ รวมถึงรูปแบบกระบอก, ปริซึมและพีระมิด, รวมถึงแผนภูมิเส้น, พื้นที่, พายและพื้นผิว 3 มิติ. การเปรียบเทียบด้านบนใช้ประเภท `Column3D` ที่ตรวจสอบแล้ว. การตั้งค่านี้ไม่เปลี่ยนลักษณะของแผนภูมิ 2 มิติ `ClusteredColumn` หรือแผนภูมิ `BubbleWith3D`; ชื่อเหล่านี้เป็นสมาชิกของ enumeration [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). สำหรับการตั้งค่าลักษณะอื่นของแผนภูมิ, ดู [การจัดรูปแบบแผนภูมิ](/slides/th/cpp/chart-formatting/).

## **ปรับช่องว่างระหว่างชุดข้อมูล**

ใช้ [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) เพื่อควบคุมระยะห่างระหว่างชุดข้อมูลตามแกนความลึกของแผนภูมิ 3 มิติ, แสดงเป็นเปอร์เซ็นต์ของความกว้างของมาร์คเกอร์. ใช้ค่าตั้งแต่ **0 ถึง 500**, รวมทั้งสองค่า: `0` จะลบช่องว่าง, ขณะที่ค่าที่ใหญ่กว่าจะเพิ่มระยะห่าง. หากความลึกของแผนภูมิคงที่, การเพิ่มช่องว่างทำให้มาร์คเกอร์บางลงตามแกนความลึก.

เข้าถึงกลุ่มผ่าน [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/). การตั้งค่านี้ใช้กับทุกชุดข้อมูลในกลุ่มนั้น, ไม่ได้จำกัดแค่ชุดข้อมูลที่ใช้เข้าถึง. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) ส่งคืนค่าการตั้งค่าของกลุ่มแม่.

การตั้งค่านี้ส่งผลต่อแผนภูมิคอลัมน์และบาร์ 3 มิติ รวมถึงรูปแบบกระบอก, ปริซึมและพีระมิด, รวมถึงแผนภูมิเส้นและพื้นที่ 3 มิติ. การแสดงผลขึ้นอยู่กับว่าชุดข้อมูลถูกจัดเรียงตามความลึก, เป็นกลุ่มหรือเป็นสแต็ก. เพื่อเปรียบเทียบช่องว่างระหว่างชุดข้อมูลที่แยกจากกันอย่างชัดเจน, ใช้ `ChartType::Column3D` จาก enumeration [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/).

เมธอดเหล่านี้ควบคุมแง่มุมต่างๆ ของแผนภูมิ:

| เมธอด | ผลลัพธ์ |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | ระยะห่างระหว่างชุดข้อมูลตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างของมาร์คเกอร์ |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | ระยะห่างระหว่างกลุ่มแท่งหรือคอลัมน์ที่อยู่ติดกัน, เป็นเปอร์เซ็นต์ของความกว้างของแท่งหรือคอลัมน์ |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | ความลึกโดยรวมของแผนภูมิ, เป็นเปอร์เซ็นต์ของความกว้างของแผนภูมิ |

ตัวอย่างต่อไปนี้เป็นตัวอย่างแบบอิสระที่ใช้ข้อมูลแผนภูมิเริ่มต้นซึ่งมีสามชุดข้อมูลและสี่ประเภท. ตัวอย่างบันทึกงานนำเสนอสองไฟล์โดยมีข้อมูล, การหมุน, ความกว้างของช่องว่างและความลึกของแผนภูมิเหมือนกัน; มีเพียงความลึกของช่องว่างที่เปลี่ยน.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <cstdint>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 40, 30, 620, 230);

chart->get_Rotation3D()->set_RotationX(20);
chart->get_Rotation3D()->set_RotationY(30);
chart->get_Rotation3D()->set_DepthPercents(100);

auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto group = series->get_ParentSeriesGroup();
group->set_GapWidth(150);

for (uint16_t gapDepth : { 0, 500 })
{
    group->set_GapDepth(gapDepth);

    auto fileName = String::Format(u"series_gap_depth_{0}.pptx", gapDepth);
    presentation->Save(fileName, SaveFormat::Pptx);
}
presentation->Dispose();
```

ภาพต่อไปนี้มาจากตัวอย่าง .NET ที่เทียบเท่า ซึ่งส่งออกโดย Microsoft PowerPoint และแสดงการตั้งค่าความลึกของช่องว่างเดียวกัน.

| ความลึกของช่องว่าง: 0% | ความลึกของช่องว่าง: 500% |
| --- | --- |
| ![แผนภูมิคอลัมน์ 3 มิติที่ไม่มีช่องว่างระหว่างชุดข้อมูลตามแกนความลึก](gap_depth_0.png) | ![แผนภูมิคอลัมน์ 3 มิติที่มีช่องว่าง 500% ระหว่างชุดข้อมูลตามแกนความลึก](gap_depth_500.png) |

## **เปลี่ยนประเภทชุดข้อมูล 3D และรูปร่างของแท่ง**

ในแผนภูมิกระบอกสแต็ก, ชุดข้อมูลแรกเริ่มด้วยแท่งทรงกระบอก. ตัวอย่างอ่าน [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) และ [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) ก่อนและหลังการเปลี่ยนแต่ละครั้ง.

```cpp
#include <DOM/Chart/ChartShapeType.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredCylinder, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto printSeries = [&series]()
{
    auto type = Enum<ChartType>::GetName(series->get_Type());
    auto shape = Enum<ChartShapeType>::GetName(series->get_Bar3DShape());
    Console::WriteLine(u"{0} | {1}", type, shape);
};

printSeries();

series->set_Type(ChartType::ClusteredCone);
printSeries();

series->set_Bar3DShape(ChartShapeType::Box);
printSeries();

presentation->Save(u"series_shape.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

| เปลี่ยนสำหรับชุดข้อมูลแรก | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| สร้างแผนภูมิ | `ClusteredCylinder` | `Cylinder` |
| เรียก [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) ด้วย `ClusteredCone` | `ClusteredCone` | `Cone` |
| เรียก [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) ด้วย `Box` | `ClusteredColumn3D` | `Box` |

การตั้งรูปร่างเป็น `Box` ยังทำให้ประเภทชุดข้อมูลเปลี่ยนเป็น `ClusteredColumn3D`. หากโค้ดของคุณสาขาตามประเภทชุดข้อมูล, เรียก `series->get_Type()` หลังจากเปลี่ยนรูปร่าง. ค่าที่เก็บไว้ก่อนการเปลี่ยนจะยังคงเลือกสาขา `ClusteredCone`.

![การเปรียบเทียบ PowerPoint แสดงชุดข้อมูลแรกเป็นแท่งทรงกระบอก, รูกระบอก, และคอลัมน์สี่เหลี่ยมจากซ้ายไปขวา](series-shapes.png)

## **คำถามที่พบบ่อย**

**Aspose.Slides รองรับประเภทแผนภูมิใดบ้างที่มีโหมด 3D?**

Aspose.Slides รองรับรูปแบบ 3 มิติของแผนภูมิคอลัมน์, ได้แก่ Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D, พร้อมประเภท 3 มิติที่เกี่ยวข้องที่เปิดให้ใช้ผ่าน enumeration [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). สำหรับรายการที่แม่นยำและอัปเดตล่าสุด, ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) ในเอกสาร API ของรุ่นที่คุณติดตั้ง.

**ฉันสามารถรับภาพเรสเตอร์ของแผนภูมิ 3D สำหรับรายงานหรือเว็บได้หรือไม่?**

ได้. คุณสามารถส่งออกแผนภูมิเป็นภาพด้วย [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) หรือ [เรนเดอร์สไลด์ทั้งหมด](/slides/th/cpp/convert-powerpoint-to-png/) ไปเป็นรูปแบบเช่น PNG หรือ JPEG. วิธีนี้เป็นประโยชน์เมื่อคุณต้องการพรีวิวแบบเรสเตอร์หรือฝังแผนภูมิในเอกสาร, แดชบอร์ด หรือหน้าเว็บโดยไม่ต้องพึ่งพา PowerPoint.

**ประสิทธิภาพของการสร้างและเรนเดอร์แผนภูมิ 3D ขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของภาพ. เพื่อให้ได้ผลลัพธ์ที่ดีที่สุด, ควรลดเอฟเฟกต์ 3D ให้น้อยที่สุด, หลีกเลี่ยงพื้นผิวที่มีเท็กซ์เจอร์หนักบนผนังและพื้นที่พล็อต, จำกัดจำนวนจุดข้อมูลต่อชุดข้อมูลเมื่อเป็นไปได้, และเรนเดอร์เป็นขนาดเอาต์พุตที่เหมาะสม (ความละเอียดและมิติ) ให้ตรงกับการแสดงผลหรือการพิมพ์ที่ต้องการ.