---
title: ปรับแต่งแผนภูมิ 3 มิติในงานนำเสนอด้วย .NET
linktitle: แผนภูมิ 3 มิติ
type: docs
url: /th/net/3d-chart/
keywords:
- แผนภูมิ 3 มิติ
- การหมุน
- ความลึก
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างแผนภูมิ 3 มิติในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ .NET ปรับการหมุน สัดส่วนความสูง ความลึกของแผนภูมิ และระยะห่างระหว่างชุดข้อมูลด้วยตัวอย่าง C#"
---
## **ภาพรวม**

Aspose.Slides for .NET ให้คุณปรับแต่งมุมมองของแผนภูมิ 3 มิติผ่านคุณสมบัติ [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) . บทความนี้แสดงวิธีปรับการหมุน, สัดส่วนความสูง, ความลึก, แกนมุมฉาก, และระยะห่างระหว่างชุดข้อมูล, จากนั้นบันทึกงานนำเสนอเป็นรูปแบบ PPTX

## **กำหนดการหมุนและความลึกของแผนภูมิ 3 มิติ**

ตัวอย่างด้านล่างสร้าง [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) และใช้ [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) เพื่อเพิ่มแผนภูมิคอลัมน์ 3 มิติแบบซ้อนในสไลด์แรกของมัน. มันแทนที่ชุดข้อมูลและหมวดหมู่เริ่มต้นด้วยสองชุดข้อมูลที่แต่ละชุดมีสามค่า. ดัชนีเวิร์กชีต `0` ระบุแผ่นข้อมูลแรกของแผนภูมิ; แถว `0` เก็บชื่อชุดข้อมูล, และคอลัมน์ `0` เก็บป้ายหมวดหมู่.

คุณสมบัติ [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) และ [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) กำหนดการหมุนของแผนภูมิเป็น 40 และ 270 องศาตามลำดับ. [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) ตั้งค่าความลึกเป็น 150% ของความกว้าง, ในขณะที่ [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) เปิดใช้งานแกนมุมฉากแทนการมองแบบแหลมมุม. งานนำเสนอที่ได้จะมีแผนภูมิที่เติมข้อมูลพร้อมการตั้งค่ามุมมอง 3 มิติเหล่านี้.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

var values = new double[,] { { 20, 50, 30 }, { 30, 10, 60 } };

for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, 0, $"Category {categoryIndex + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

for (var seriesIndex = 0; seriesIndex < 2; seriesIndex++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, seriesIndex + 1, $"Series {seriesIndex + 1}");
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

    for (var categoryIndex = 0; categoryIndex < 3; categoryIndex++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }
}

chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 270;
chart.Rotation3D.DepthPercents = 150;

presentation.Save("Rotation3D_out.pptx", SaveFormat.Pptx);
```

## **ปรับสัดส่วนความสูงของแผนภูมิ 3 มิติ**

ใช้ [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) เพื่อตั้งค่าความสูงของแผนภูมิ 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง. สิ่งนี้เปลี่ยนสัดส่วนของฉาก 3 มิติโดยไม่ต้องปรับขนาดวัตถุแผนภูมิบนสไลด์.

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) ด้วยข้อมูลเริ่มต้น: สามชุดข้อมูลและสี่หมวดหมู่. มันบันทึกงานนำเสนอสามไฟล์โดยมีสัดส่วนความสูงที่ 50%, 100% และ 200%. ตำแหน่ง, ความกว้างและความสูงของแผนภูมิก็ยังคงคงที่. ข้อมูล, การหมุน, ความลึก, ระยะห่างระหว่างชุดข้อมูลและการฟอร์แมตตรงกันในทุกไฟล์; มีเพียงเปอร์เซ็นต์ความสูงที่เปลี่ยนแปลง.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 460);
chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.DepthPercents = 100;
chart.ChartData.Series[0].ParentSeriesGroup.GapDepth = 150;

foreach (ushort heightPercent in new ushort[] { 50, 100, 200 })
{
    chart.Rotation3D.HeightPercents = heightPercent;
    presentation.Save($"chart_height_{heightPercent}.pptx", SaveFormat.Pptx);
}
```

ภาพต่อไปนี้ถูกส่งออกจากงานนำเสนอที่สร้างขึ้นโดยใช้ Microsoft PowerPoint. ค่าร้อยละที่น้อยกว่าให้ฉากที่แบนลง, ส่วนค่าร้อยละที่สูงกว่าให้ฉากที่สูงขึ้นภายในวัตถุแผนภูมิเดียวกัน. PowerPoint อาจปรับช่วงการแบ่งเครื่องหมายแกนและตำแหน่งป้ายเพื่อให้พอดีกับฉาก.

| ความสูง: 50% | ความสูง: 100% | ความสูง: 200% |
| --- | --- | --- |
| ![แผนภูมิคอลัมน์ 3 มิติที่ตั้งค่าความสูงเป็น 50% ของความกว้าง](height_percent_50.png) | ![แผนภูมิคอลัมน์ 3 มิติที่ตั้งค่าความสูงเป็น 100% ของความกว้าง](height_percent_100.png) | ![แผนภูมิคอลัมน์ 3 มิติที่ตั้งค่าความสูงเป็น 200% ของความกว้าง](height_percent_200.png) |

คุณสมบัติเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| คุณสมบัติ | ผล |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | ความสูงของฉาก 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | ความสูงของวัตถุแผนภูมิบนสไลด์, หน่วยเป็นพอยต์ |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | ความลึกของฉาก 3 มิติเป็นเปอร์เซ็นต์ของความกว้าง |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | ระยะห่างระหว่างชุดข้อมูลตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างของมาร์กเกอร์ |

การตั้งค่าความสูงนี้ส่งผลต่อแผนภูมิคอลัมน์และแผนภูมิแท่ง 3 มิติ รวมถึงรูปแบบทรงกระบอก, รูปทรงกรวย และรูปทรงปิรามิด, รวมถึงแผนภูมิเส้น, พื้นที่, พายและพื้นผิว 3 มิติ. การเปรียบเทียบด้านบนใช้ประเภท `Column3D` ที่ผ่านการตรวจสอบแล้ว. การตั้งค่านี้ไม่เปลี่ยนลักษณะของแผนภูมิ 2 มิติ `ClusteredColumn` หรือแผนภูมิ `BubbleWith3D`; ชื่อเหล่านี้เป็นสมาชิกของสาธารณ enum [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). สำหรับการตั้งค่าลักษณะของแผนภูมิอื่น ๆ ดูที่ [Chart Formatting](/slides/th/net/chart-formatting/).

## **ปรับช่องว่างระหว่างชุดข้อมูล**

ใช้ [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) เพื่อควบคุมระยะห่างระหว่างชุดข้อมูลตามแกนความลึกของแผนภูมิ 3 มิติ, แสดงเป็นเปอร์เซ็นต์ของความกว้างของมาร์กเกอร์. ใช้ค่าตั้งแต่ **0 ถึง 500** รวม: `0` ลบช่องว่าง, ขณะที่ค่าที่ใหญ่กว่าจะเพิ่มระยะห่าง. เมื่อความลึกของแผนภูมิคงที่, การเพิ่มช่องว่างทำให้มาร์กเกอร์บางลงตามแกนความลึก.

เข้าถึงกลุ่มผ่าน [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). การตั้งค่านี้ใช้กับทุกชุดข้อมูลในกลุ่มนั้น, ไม่ได้จำกัดแค่ชุดที่ใช้เข้าถึง. [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) เป็นแบบอ่านอย่างเดียวและสะท้อนการตั้งค่าของกลุ่มแม่.

การตั้งค่านี้ส่งผลต่อแผนภูมิคอลัมน์และแท่ง 3 มิติ รวมถึงรูปแบบทรงกระบอก, รูปทรงกรวยและรูปทรงปิรามิด, รวมถึงแผนภูมิเส้นและพื้นที่ 3 มิติ. ลักษณะขึ้นกับว่าชุดข้อมูลถูกจัดเรียงในแนวความลึก, แบบกลุ่มหรือแบบซ้อน. สำหรับการเปรียบเทียบช่องว่างระหว่างชุดแยกกันอย่างชัดเจน, ใช้ `ChartType.Column3D` จาก enum [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/).

คุณสมบัติเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ:

| คุณสมบัติ | ผล |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | ระยะห่างระหว่างชุดข้อมูลตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างของมาร์กเกอร์ |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | ระยะห่างระหว่างกลุ่มแท่งหรือคอลัมน์ที่อยู่ติดกัน, เป็นเปอร์เซ็นต์ของความกว้างของแท่งหรือคอลัมน์ |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | ความลึกโดยรวมของแผนภูมิ, เป็นเปอร์เซ็นต์ของความกว้างของแผนภูมิ |

ตัวอย่างต่อไปนี้ใช้ข้อมูลแผนภูมิเบื้องต้นที่มีสามชุดข้อมูลและสี่หมวดหมู่. มันบันทึกงานนำเสนอสองไฟล์โดยมีข้อมูล, การหมุน, ความกว้างช่องว่างและความลึกของแผนภูมิเท่ากัน; มีเพียงความลึกของช่องว่างที่เปลี่ยนแปลง.

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 40, 30, 620, 230);

chart.Rotation3D.RotationX = 20;
chart.Rotation3D.RotationY = 30;
chart.Rotation3D.DepthPercents = 100;

var series = chart.ChartData.Series[0];
var group = series.ParentSeriesGroup;
group.GapWidth = 150;

foreach (ushort gapDepth in new ushort[] { 0, 500 })
{
    group.GapDepth = gapDepth;

    var fileName = $"series_gap_depth_{gapDepth}.pptx";
    presentation.Save(fileName, SaveFormat.Pptx);

}
```

ภาพต่อไปนี้ถูกส่งออกจากงานนำเสนอที่สร้างขึ้นโดยใช้ Microsoft PowerPoint.

| ความลึกช่องว่าง: 0% | ความลึกช่องว่าง: 500% |
| --- | --- |
| ![แผนภูมิคอลัมน์ 3 มิติที่ไม่มีช่องว่างระหว่างชุดข้อมูลตามแกนความลึก](gap_depth_0.png) | ![แผนภูมิคอลัมน์ 3 มิติที่มีช่องว่าง 500% ระหว่างชุดข้อมูลตามแกนความลึก](gap_depth_500.png) |

## **เปลี่ยนประเภทชุดข้อมูล 3 มิติและรูปร่างแท่ง**

ในแผนภูมิเคลัสเตอร์ทรงกระบอก, ชุดข้อมูลแรกเริ่มต้นด้วยรูปร่างแท่งทรงกระบอก. ตัวอย่างนี้อ่าน [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) และ [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) ก่อนและหลังการเปลี่ยนแต่ละครั้ง.

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Type = ChartType.ClusteredCone;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

series.Bar3DShape = ChartShapeType.Box;
Console.WriteLine($"{series.Type} | {series.Bar3DShape}");

presentation.Save("series_shape.pptx", SaveFormat.Pptx);
```

| การเปลี่ยนชุดข้อมูลแรก | `Type` | `Bar3DShape` |
| --- | --- | --- |
| สร้างแผนภูมิ | `ClusteredCylinder` | `Cylinder` |
| ตั้งค่า `Type` เป็น `ClusteredCone` | `ClusteredCone` | `Cone` |
| ตั้งค่า `Bar3DShape` เป็น `Box` | `ClusteredColumn3D` | `Box` |

การตั้งค่ารูปร่างเป็น `Box` ยังทำให้ประเภทชุดข้อมูลเปลี่ยนเป็น `ClusteredColumn3D`. หากโค้ดของคุณทำการสาขาตามประเภทชุดข้อมูล, ให้อ่าน `series.Type` หลังจากเปลี่ยนรูปร่าง. ค่าที่ถูกแคชก่อนการกำหนดค่าอาจยังเลือกสาขา `ClusteredCone` อยู่.

![การเปรียบเทียบใน PowerPoint แสดงชุดข้อมูลแรกเป็นทรงกระบอก, รูปทรงกรวยและคอลัมน์สี่เหลี่ยมจากซ้ายไปขวา](series-shapes.png)

## **คำถามที่พบบ่อย**

**แผนภูมิประเภทใดรองรับโหมด 3D ใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3 มิติของแผนภูมิคอลัมน์, รวมถึง Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D, พร้อมกับประเภท 3 มิติที่เกี่ยวข้องซึ่งเปิดเผยผ่าน enum [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/). สำหรับรายการที่แม่นยำและอัปเดต, ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) ในเอกสาร API ของเวอร์ชันที่คุณติดตั้ง

**ฉันสามารถรับภาพเรสเตอร์ของแผนภูมิ 3D เพื่อใช้ในรายงานหรือเว็บได้หรือไม่?**

ได้. คุณสามารถส่งออกแผนภูมิเป็นภาพด้วย [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) หรือ [เรนเดอร์สไลด์ทั้งหมด](/slides/th/net/convert-powerpoint-to-png/) เป็นรูปแบบเช่น PNG หรือ JPEG. นี้มีประโยชน์เมื่อคุณต้องการภาพตัวอย่างแบบเรสเตอร์หรือฝังแผนภูมิลงในเอกสาร, แดชบอร์ดหรือหน้าเว็บโดยไม่ต้องการ PowerPoint

**ประสิทธิภาพในการสร้างและเรนเดอร์แผนภูมิ 3D ขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของภาพ. เพื่อผลลัพธ์ที่ดีที่สุด, ควรลดเอฟเฟกต์ 3D ให้น้อยที่สุด, หลีกเลี่ยงการใช้พื้นผิวที่มีเทกซ์เจอร์หนักบนผนังและพื้นที่พล็อต, จำกัดจำนวนจุดข้อมูลต่อชุดเมื่อเป็นไปได้, และเรนเดอร์เป็นขนาดเอาต์พุตที่เหมาะสม (ความละเอียดและมิติ) เพื่อให้ตรงกับการแสดงผลหรือการพิมพ์ที่ต้องการ.