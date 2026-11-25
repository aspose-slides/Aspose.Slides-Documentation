---
title: ปรับแต่งแผนภูมิ 3 มิติในงานนำเสนอโดยใช้ C++
linktitle: แผนภูมิ 3 มิติ
type: docs
url: /th/cpp/3d-chart/
keywords:
- แผนภูมิ 3 มิติ
- การหมุน
- ความลึก
- PowerPoint
- งานนำเสนอ
- C++
- Aspose.Slides
description: "สร้างแผนภูมิ 3 มิติในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ C++. ปรับการหมุน, อัตราส่วนความสูง, ความลึกของแผนภูมิ, และช่องว่างระหว่างซีรีส์ด้วยตัวอย่างโค้ด C++."
---
## **ภาพรวม**

Aspose.Slides for C++ ให้คุณปรับแต่งมุมมองของแผนภูมิ 3 มิติผ่าน [IChart::get_Rotation3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_rotation3d/). บทความนี้แสดงวิธีปรับการหมุน, อัตราส่วนความสูง, ความลึก, แกนมุมฉาก, และช่องว่างระหว่างซีรีส์, จากนั้นบันทึกงานนำเสนอในรูปแบบ PPTX.

## **ตั้งค่าการหมุนและความลึกของแผนภูมิ 3 มิติ**

ตัวอย่างด้านล่างสร้าง [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) และใช้ [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) เพื่อเพิ่มแผนภูมิคอลัมน์ 3 มิติแบบ stacked ไปยังสไลด์แรกของมัน. มันจะแทนที่ซีรีส์และประเภทเริ่มต้นด้วยสองซีรีส์ที่แต่ละซีรีส์มีสามค่า. ดัชนีเวิร์กชีต `0` ระบุเวิร์กชีตข้อมูลแรกของแผนภูมิ; แถว `0` เก็บชื่อซีรีส์, และคอลัมน์ `0` เก็บป้ายชื่อประเภท.

เมธอด [set_RotationX](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationx/) และ [set_RotationY](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rotationy/) ตั้งค่าการหมุนของแผนภูมิเป็น 40 และ 270 องศาตามลำดับ. [set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) ตั้งค่าความลึกเป็น 150% ของความกว้าง, ในขณะที่ [set_RightAngleAxes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_rightangleaxes/) เปิดใช้งานแกนมุมฉากแทนการมองในมุมมองเชิงมิติ. งานนำเสนอที่ได้จะมีแผนภูมิที่เติมข้อมูลพร้อมการตั้งค่ามุมมอง 3 มิติเหล่านี้.

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

## **ใช้การเติมรูปภาพบนพื้นผิวแผนภูมิ 3 มิติ**

คุณสามารถเติม [side wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_sidewall/), [back wall](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_backwall/), และ [floor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_floor/) ของแผนภูมิ 3 มิติได้แบบอิสระ. ตั้งค่า [fill type](https://reference.aspose.com/slides/cpp/aspose.slides/ifillformat/set_filltype/) ของพื้นผิวเป็น `Picture` แล้วกำหนดรูปภาพ. เพื่อให้รูปภาพหนึ่งสำเนาครอบคลุมพื้นผิวทั้งหมด, ตั้งค่า [picture fill mode](https://reference.aspose.com/slides/cpp/aspose.slides/ipicturefillformat/set_picturefillmode/) และ [picture type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartwall/set_picturetype/) ของพื้นผิวเป็น `Stretch`.

บันทึกไฟล์ [arrow.png](arrow.png) ไว้ในโฟลเดอร์ทำงาน. ตัวอย่างจะหมุนแผนภูมิและเพิ่มค่ามากที่สุดบนแกนตั้งเพื่อให้เห็นพื้นระหว่างคอลัมน์. จากนั้นทำสำเนาสไลด์สองครั้งและใส่ลูกศรบนพื้นผิวที่แตกต่างกันของแต่ละสไลด์. ทั้งสามแผนภูมิจะรักษาข้อมูล, มุมมอง, และพื้นหลังเดิมไว้.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartWall.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/Chart/IRotation3D.h>
#include <DOM/Chart/PictureType.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IFillFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/PictureFillMode.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/shared_ptr.h>
#include <initializer_list>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 20, 30, 680, 480);
chart->get_Rotation3D()->set_RightAngleAxes(true);
chart->get_Rotation3D()->set_RotationX(40);
chart->get_Rotation3D()->set_RotationY(30);

auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_IsAutomaticMaxValue(false);
verticalAxis->set_MaxValue(24);

auto backSlide = presentation->get_Slides()->AddClone(slide);
auto floorSlide = presentation->get_Slides()->AddClone(slide);
auto backChart = ExplicitCast<IChart>(backSlide->get_Shape(0));
auto floorChart = ExplicitCast<IChart>(floorSlide->get_Shape(0));

auto imageBytes = IO::File::ReadAllBytes(u"arrow.png");
auto arrow = presentation->get_Images()->AddImage(imageBytes);

for (const auto& surface : { chart->get_SideWall(), backChart->get_BackWall(), floorChart->get_Floor() })
{
    auto fill = surface->get_Format()->get_Fill();
    fill->set_FillType(FillType::Picture);
    auto pictureFill = fill->get_PictureFillFormat();
    pictureFill->get_Picture()->set_Image(arrow);
    pictureFill->set_PictureFillMode(PictureFillMode::Stretch);
    surface->set_PictureType(PictureType::Stretch);
}

presentation->Save(u"chart-surfaces.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Microsoft PowerPoint แสดงสไลด์สามสไลด์ดังนี้.

| ผนังด้านข้าง | ผนังด้านหลัง | พื้น |
| --- | --- | --- |
| ![ลูกศรชี้เข้าสู่แผนภูมิด้านผนังด้านข้าง](side-wall.png) | ![ลูกศรชี้ขวาผ่านผนังด้านหลัง](back-wall.png) | ![ลูกศรชี้ขวาผ่านพื้นระหว่างคอลัมน์](floor.png) |

## **ปรับอัตราส่วนความสูงของแผนภูมิ 3 มิติ**

ใช้ [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) เพื่อตั้งค่าความสูงของแผนภูมิ 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง. วิธีนี้เปลี่ยนอัตราส่วนของฉาก 3 มิติโดยไม่ต้องปรับขนาดวัตถุแผนภูมิบนสไลด์.

ตัวอย่างต่อไปสร้างแผนภูมิ [Column3D](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) ด้วยข้อมูลเริ่มต้น: สามซีรีส์และสี่ประเภท. มันบันทึกงานนำเสนอสามไฟล์ที่อัตราส่วนความสูง 50%, 100%, และ 200%. ตำแหน่ง, ความกว้าง, และความสูงของแผนภูมิก็ยังคงที่. ข้อมูล, การหมุน, ความลึก, ช่องว่างระหว่างซีรีส์, และการจัดรูปแบบเหมือนกันในทุกไฟล์; มีเพียงเปอร์เซ็นต์ความสูงที่เปลี่ยน.

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

ภาพต่อไปนี้จากตัวอย่าง .NET ที่เทียบเท่าถูกส่งออกด้วย Microsoft PowerPoint เพื่อแสดงการตั้งค่าความสูงเดียวกัน. เปอร์เซ็นต์ที่น้อยกว่าจะทำให้ฉากแบนลง, ส่วนเปอร์เซ็นต์ที่มากจะทำให้ฉากสูงขึ้นภายในวัตถุแผนภูมิเดียวกัน. PowerPoint อาจปรับช่วงการทำเครื่องหมายแกนและตำแหน่งป้ายเพื่อให้พอดีกับฉาก.

| ความสูง: 50% | ความสูง: 100% | ความสูง: 200% |
| --- | --- | --- |
| ![แผนภูมิคอลัมน์ 3 มิติที่ความสูงตั้งเป็น 50% ของความกว้าง](height_percent_50.png) | ![แผนภูมิคอลัมน์ 3 มิติที่ความสูงตั้งเป็น 100% ของความกว้าง](height_percent_100.png) | ![แผนภูมิคอลัมน์ 3 มิติที่ความสูงตั้งเป็น 200% ของความกว้าง](height_percent_200.png) |

วิธีเหล่านี้ควบคุมแง่มุมที่ต่างกันของแผนภูมิ:

| วิธีการ | ผล |
| --- | --- |
| [IRotation3D::set_HeightPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_heightpercents/) | ความสูงของฉาก 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง |
| [IShape::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/set_height/) | ความสูงของวัตถุแผนภูมิบนสไลด์, หน่วยเป็นพอยต์ |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | ความลึกของฉาก 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | ช่องว่างระหว่างซีรีส์ตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างของมาร์คเกอร์ |

การตั้งค่าความสูงมีผลกับแผนภูมิคอลัมน์และแถบ 3 มิติ, รวมถึงรูปแบบกระบอก, กรวย, และพีระมิด, รวมถึงแผนภูมิ 3 มิติแบบเส้น, พื้นที่, พาย, และผิว. การเปรียบเทียบด้านบนใช้ประเภท `Column3D` ที่ได้รับการตรวจสอบแล้ว. การตั้งค่านี้ไม่เปลี่ยนลักษณะของแผนภูมิ 2 มิติ `ClusteredColumn` หรือแผนภูมิ `BubbleWith3D`; ชื่อเหล่านี้เป็นสมาชิกของ enumeration [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). สำหรับการตั้งค่าลักษณะอื่น ๆ ของแผนภูมิ, ดู [Chart Formatting](/slides/th/cpp/chart-formatting/).

## **ปรับช่องว่างระหว่างซีรีส์**

ใช้ [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) เพื่อควบคุมระยะทางระหว่างซีรีส์ข้อมูลตามแกนความลึกของแผนภูมิ 3 มิติ, แสดงเป็นเปอร์เซ็นต์ของความกว้างมาร์คเกอร์. ใช้ค่าตั้งแต่ **0 ถึง 500**, รวม: `0` จะลบช่องว่าง, ค่ามากกว่าเพิ่มช่องว่าง. เมื่อความลึกของแผนภูมิคงที่, การเพิ่มช่องว่างจะทำให้มาร์คเกอร์บางลงตามแกนความลึก.

เข้าถึงกลุ่มผ่าน [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/). การตั้งค่านี้ใช้กับทุกซีรีส์ในกลุ่มนั้น, ไม่ใช่แค่ซีรีส์ที่ใช้เข้าถึง. [IChartSeries::get_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_gapdepth/) จะคืนค่าการตั้งค่าของกลุ่มแม่.

การตั้งค่านี้มีผลกับแผนภูมิคอลัมน์และแถบ 3 มิติ, รวมถึงรูปแบบกระบอก, กรวย, และพีระมิด, รวมถึงแผนภูมิ 3 มิติแบบเส้นและพื้นที่. ลักษณะการแสดงผลขึ้นอยู่กับว่าซีรีส์ถูกจัดเรียงตามความลึก, แบบจัดกลุ่ม, หรือแบบ stacked. เพื่อเปรียบเทียบช่องว่างระหว่างซีรีส์แยกกันอย่างชัดเจน, ใช้ `ChartType::Column3D` จาก enumeration [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/).

วิธีเหล่านี้ควบคุมแง่มุมที่ต่างกันของแผนภูมิ:

| วิธีการ | ผล |
| --- | --- |
| [IChartSeriesGroup::set_GapDepth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapdepth/) | ช่องว่างระหว่างซีรีส์ตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างมาร์คเกอร์ |
| [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) | ช่องว่างระหว่างกลุ่มคอลลัมน์หรือแถบที่อยู่ติดกัน, เป็นเปอร์เซ็นต์ของความกว้างคอลลัมน์หรือแถบ |
| [IRotation3D::set_DepthPercents](https://reference.aspose.com/slides/cpp/aspose.slides.charts/irotation3d/set_depthpercents/) | ความลึกรวมของแผนภูมิ, เป็นเปอร์เซ็นต์ของความกว้างแผนภูมิ |

ตัวอย่างต่อไปนี้เป็นแบบอิสระที่ใช้ข้อมูลแผนภูมิเบื้องต้น ซึ่งประกอบด้วยสามซีรีส์และสี่ประเภท. มันบันทึกงานนำเสนอสองไฟล์ที่มีข้อมูล, การหมุน, ความกว้างช่องว่าง, และความลึกของแผนภูมิเดียวกัน; มีเพียงความลึกช่องว่างที่เปลี่ยน.

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

ภาพต่อไปนี้จากตัวอย่าง .NET ที่เทียบเท่าถูกส่งออกด้วย Microsoft PowerPoint เพื่อแสดงการตั้งค่าช่องว่างความลึกเดียวกัน.

| ความลึกช่องว่าง: 0% | ความลึกช่องว่าง: 500% |
| --- | --- |
| ![แผนภูมิคอลัมน์ 3 มิติที่ไม่มีช่องว่างระหว่างซีรีส์ตามแกนความลึก](gap_depth_0.png) | ![แผนภูมิคอลัมน์ 3 มิติที่มีช่องว่าง 500% ระหว่างซีรีส์ตามแกนความลึก](gap_depth_500.png) |

## **เปลี่ยนประเภทซีรีส์ 3 มิติและรูปร่างแท่ง**

ในแผนภูมิกระบอกแบบจัดกลุ่ม, ซีรีส์แรกเริ่มต้นด้วยแท่งแบบกระบอก. ตัวอย่างอ่านค่า [IChartSeries::get_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_type/) และ [IChartSeries::get_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_bar3dshape/) ก่อนและหลังการเปลี่ยนแต่ละครั้ง.

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

| การเปลี่ยนแปลงในซีรีส์แรก | `get_Type` | `get_Bar3DShape` |
| --- | --- | --- |
| สร้างแผนภูมิ | `ClusteredCylinder` | `Cylinder` |
| เรียก [set_Type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_type/) ด้วย `ClusteredCone` | `ClusteredCone` | `Cone` |
| เรียก [set_Bar3DShape](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_bar3dshape/) ด้วย `Box` | `ClusteredColumn3D` | `Box` |

การตั้งค่าให้รูปร่างเป็น `Box` จะเปลี่ยนประเภทซีรีส์เป็น `ClusteredColumn3D` ด้วย. หากโค้ดของคุณทำสาขาตามประเภทซีรีส์, ให้เรียก `series->get_Type()` หลังจากเปลี่ยนรูปร่าง. ค่าที่เก็บไว้ก่อนการเปลี่ยนจะยังคงเลือกสาขา `ClusteredCone`.

![การเปรียบเทียบ PowerPoint แสดงซีรีส์แรกเป็นกระบอก, กรวย, และคอลัมน์สี่เหลี่ยมจากซ้ายไปขวา](series-shapes.png)

## **FAQ**

**แผนภูมิประเภทใดบ้างที่รองรับโหมด 3 มิติใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3 มิติของแผนภูมิคอลัมน์, รวมถึง Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D, พร้อมประเภท 3 มิติที่เกี่ยวข้องที่เปิดผ่าน enumeration [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/). เพื่อดูรายการที่แม่นยำและอัปเดตล่าสุด, ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) ในเอกสาร API ของเวอร์ชันที่คุณติดตั้ง.

**ฉันสามารถรับภาพเรสเตอร์ของแผนภูมิ 3 มิติสำหรับรายงานหรือเว็บได้หรือไม่?**

ได้. คุณสามารถส่งออกแผนภูมิเป็นภาพด้วย [Shape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/shape/getimage/) หรือ [เรนเดอร์สไลด์ทั้งหมด](/slides/th/cpp/convert-powerpoint-to-png/) ไปเป็นรูปแบบเช่น PNG หรือ JPEG. นี้มีประโยชน์เมื่อคุณต้องการพรีวิวแบบเรสเตอร์หรือฝังแผนภูมิลงในเอกสาร,แดชบอร์ด, หรือหน้าเว็บโดยไม่ต้องใช้ PowerPoint.

**ประสิทธิภาพการสร้างและเรนเดอร์แผนภูมิ 3 มิติที่ใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของกราฟิก. เพื่อให้ได้ผลลัพธ์ที่ดีที่สุด, ควรลดเอฟเฟกต์ 3 มิติให้น้อยที่สุด, อย่าใช้พื้นผิวหรือพื้นที่พล็อตที่มีพื้นผิวซับซ้อนมาก, จำกัดจำนวนจุดข้อมูลต่อซีรีส์เมื่อเป็นไปได้, และเรนเดอร์เป็นขนาดเอาต์พุตที่เหมาะสม (ความละเอียดและมิติ) เพื่อให้ตรงกับการแสดงผลหรือการพิมพ์ที่ต้องการ.