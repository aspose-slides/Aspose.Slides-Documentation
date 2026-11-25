---
title: ปรับแต่งแผนภูมิ 3D ในงานนำเสนอด้วย .NET
linktitle: แผนภูมิ 3D
type: docs
url: /th/net/3d-chart/
keywords:
- แผนภูมิ 3D
- การหมุน
- ความลึก
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างแผนภูมิ 3D ในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ .NET ปรับการหมุน, สัดส่วนความสูง, ความลึกของแผนภูมิ, และช่องว่างระหว่างชุดข้อมูลด้วยตัวอย่าง C#."
---
## **ภาพรวม**

Aspose.Slides for .NET ให้คุณปรับแต่งการมองเห็นของแผนภูมิ 3D ผ่านคุณสมบัติ [IChart.Rotation3D](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/rotation3d/) นี้ บทความนี้แสดงวิธีปรับการหมุน, สัดส่วนความสูง, ความลึก, แกนมุมฉาก, และช่องว่างระหว่างชุดข้อมูล, แล้วบันทึกงานนำเสนอเป็นรูปแบบ PPTX

## **ตั้งค่าการหมุนและความลึกของแผนภูมิ 3D**

ตัวอย่างด้านล่างสร้าง [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) และใช้ [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) เพื่อเพิ่มแผนภูมิคอลัมน์ 3D แบบซ้อนลงในสไลด์แรกของมัน มันจะแทนที่ชุดข้อมูลและประเภทตามค่าเริ่มต้นด้วยสองชุดที่มีค่าแต่ละค่า 3 ค่า ดัชนีเวิร์กชีต `0` ระบุเวิร์กชีตข้อมูลแรกของแผนภูมิ; แถว `0` เก็บชื่อชุดข้อมูล, และคอลัมน์ `0` เก็บป้ายชื่อประเภท

คุณสมบัติ [RotationX](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationx/) และ [RotationY](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rotationy/) ตั้งค่าการหมุนของแผนภูมิเป็น 40 และ 270 องศาตามลำดับ [DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) ตั้งค่าความลึกเป็น 150% ของความกว้าง, ในขณะที่ [RightAngleAxes](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/rightangleaxes/) เปิดใช้แกนมุมฉากแทนมุมมองเชิงมุม งานนำเสนอที่ได้จะมีแผนภูมิที่เติมข้อมูลพร้อมการตั้งค่าการมองเห็น 3D เหล่านี้

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

## **ใช้การเติมภาพบนพื้นผิวแผนภูมิ 3D**

แผนภูมิ 3D มีสามพื้นผิวที่คุณสามารถเติมแยกกันได้: [side wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/sidewall/), [back wall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/), และ [floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/). ตั้งค่า [fill type](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) ของพื้นผิวที่เลือกเป็น `Picture` แล้วกำหนดรูปภาพ ตั้งค่า [picture fill mode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) และ [picture type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartwall/picturetype/) ของพื้นผิวเป็น `Stretch` เพื่อให้ภาพเดียวครอบคลุมทั่วพื้นผิว

บันทึกไฟล์ [arrow.png](arrow.png) ไว้ในไดเรกทอรีทำงาน ตัวอย่างนี้หมุนแผนภูมิและเพิ่มค่าสูงสุดของแกนแนวดิ่งเพื่อให้พื้นมองเห็นได้ระหว่างคอลลัมน์ แล้วทำสำเนาสไลด์สองครั้งก่อนที่จะใส่ลูกศรลงบนพื้นผิวที่แตกต่างกันในแต่ละสไลด์ แผนภูมิทั้งสามคงข้อมูล, มุมมอง, และพื้นหลังเหมือนเดิม

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 20, 30, 680, 480);
chart.Rotation3D.RightAngleAxes = true;
chart.Rotation3D.RotationX = 40;
chart.Rotation3D.RotationY = 30;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 24;

var backSlide = presentation.Slides.AddClone(slide);
var floorSlide = presentation.Slides.AddClone(slide);
var backChart = (IChart)backSlide.Shapes[0];
var floorChart = (IChart)floorSlide.Shapes[0];

var imageBytes = File.ReadAllBytes("arrow.png");
var arrow = presentation.Images.AddImage(imageBytes);

foreach (var surface in new[] { chart.SideWall, backChart.BackWall, floorChart.Floor })
{
    var fill = surface.Format.Fill;
    fill.FillType = FillType.Picture;
    fill.PictureFillFormat.Picture.Image = arrow;
    fill.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
    surface.PictureType = PictureType.Stretch;
}

presentation.Save("chart-surfaces.pptx", SaveFormat.Pptx);
```

Microsoft PowerPoint แสดงสามสไลด์ดังต่อไปนี้

| ผนังด้านข้าง | ผนังด้านหลัง | พื้น |
| --- | --- | --- |
| ![ลูกศรชี้เข้าไปในแผนภูมิตามผนังด้านข้าง](side-wall.png) | ![ลูกศรชี้ขวาแนวผนังด้านหลัง](back-wall.png) | ![ลูกศรชี้ขวาเหนือพื้นระหว่างคอลลัมน์](floor.png) |

## **ปรับสัดส่วนความสูงของแผนภูมิ 3D**

ใช้ [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) เพื่อกำหนดความสูงของแผนภูมิ 3D เป็นเปอร์เซ็นต์ของความกว้าง สิ่งนี้เปลี่ยนสัดส่วนของฉาก 3D โดยไม่ต้องปรับขนาดวัตถุแผนภูมิบนสไลด์

ตัวอย่างต่อไปนี้สร้างแผนภูมิ [Column3D](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) ด้วยข้อมูลเริ่มต้น: สามชุดและสี่ประเภท มันบันทึกงานนำเสนอสามไฟล์โดยใช้สัดส่วนความสูง 50%, 100%, และ 200% ตำแหน่ง, ความกว้าง, และความสูงของแผนภูมิคงที่ ข้อมูล, การหมุน, ความลึก, ช่องว่างระหว่างชุด, และการจัดรูปแบบทั้งหมดเหมือนกันในทั้งสามไฟล์; มีเพียงเปอร์เซ็นต์ความสูงที่เปลี่ยน

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

ภาพต่อไปนี้ถูกส่งออกจากงานนำเสนอที่สร้างโดยใช้ Microsoft PowerPoint เปอร์เซ็นต์ที่น้อยกว่าจะให้ฉากแบนลง, ส่วนเปอร์เซ็นต์ที่มากจะให้ฉากสูงขึ้นภายในวัตถุแผนภูมิเดียวกัน PowerPoint อาจปรับช่วงติ๊กแกนและการวางตำแหน่งป้ายกำกับให้พอดีกับฉากด้วย

| ความสูง: 50% | ความสูง: 100% | ความสูง: 200% |
| --- | --- | --- |
| ![แผนภูมิคอลัมน์ 3D ความสูงตั้งเป็น 50% ของความกว้าง](height_percent_50.png) | ![แผนภูมิคอลัมน์ 3D ความสูงตั้งเป็น 100% ของความกว้าง](height_percent_100.png) | ![แผนภูมิคอลัมน์ 3D ความสูงตั้งเป็น 200% ของความกว้าง](height_percent_200.png) |

คุณสมบัติเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ

| คุณสมบัติ | ผลกระทบ |
| --- | --- |
| [IRotation3D.HeightPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/heightpercents/) | ความสูงของฉาก 3D เป็นเปอร์เซ็นต์ของความกว้าง |
| [IChart.Height](https://reference.aspose.com/slides/net/aspose.slides/ishape/height/) | ความสูงของวัตถุแผนภูมิบนสไลด์, หน่วยเป็นพิกเซล |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | ความลึกของฉาก 3D เป็นเปอร์เซ็นต์ของความกว้าง |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | ช่องว่างระหว่างชุดข้อมูลตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างมาร์กเกอร์ |

การตั้งค่านี้ส่งผลต่อแผนภูมิคอลัมน์และแผนภูมิแท่ง 3D รวมถึงรูปแบบทรงกระบอก, รูปกรวย, และรูปพีระมิด, รวมถึงแผนภูมิเส้น, พื้นที่, พาย, และพื้นผิว 3D การเปรียบเทียบด้านบนใช้ประเภทที่ตรวจสอบแล้ว `Column3D` การตั้งค่าไม่ได้เปลี่ยนลักษณะของแผนภูมิ 2D `ClusteredColumn` หรือแผนภูมิ `BubbleWith3D`; ชื่อเหล่านี้เป็นสมาชิกของการนับจำนวน [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) สำหรับการตั้งค่าลักษณะแผนภูมิอื่น ๆ ดูที่ [Chart Formatting](/slides/th/net/chart-formatting/)

## **ปรับช่องว่างระหว่างชุดข้อมูล**

ใช้ [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) เพื่อควบคุมระยะห่างระหว่างชุดข้อมูลตามแกนความลึกของแผนภูมิ 3D, แสดงเป็นเปอร์เซ็นต์ของความกว้างมาร์กเกอร์ ใช้ค่าตั้งแต่ **0 ถึง 500**, รวม: `0` จะลบช่องว่าง, ค่าที่มากขึ้นจะเพิ่มช่องว่าง ด้วยความลึกแผนภูมิคงที่ การเพิ่มช่องว่างทำให้มาร์กเกอร์บางลงตามแกนความลึก

เข้าถึงกลุ่มผ่าน [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) การตั้งค่านี้ใช้กับทุกชุดในกลุ่มนั้น, ไม่ได้จำกัดแค่ชุดที่ใช้เข้าถึงมัน [IChartSeries.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/gapdepth/) เป็นแบบอ่านอย่างเดียวและสะท้อนการตั้งค่าของกลุ่มแม่

การตั้งค่านี้ส่งผลต่อแผนภูมิคอลัมน์และแผนภูมิแท่ง 3D รวมถึงรูปแบบทรงกระบอก, รูปกรวย, และรูปพีระมิด, รวมถึงแผนภูมิเส้นและพื้นที่ 3D ลักษณะการแสดงผลขึ้นอยู่กับว่าชุดข้อมูลถูกจัดเรียงตามความลึก, แบบกลุ่ม, หรือแบบซ้อน สำหรับการเปรียบเทียบช่องว่างระหว่างชุดที่แยกจากกันอย่างชัดเจน ให้ใช้ `ChartType.Column3D` จากการนับจำนวน [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)

คุณสมบัติเหล่านี้ควบคุมแง่มุมต่าง ๆ ของแผนภูมิ

| คุณสมบัติ | ผลกระทบ |
| --- | --- |
| [IChartSeriesGroup.GapDepth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapdepth/) | ช่องว่างระหว่างชุดข้อมูลตามแกนความลึก, เป็นเปอร์เซ็นต์ของความกว้างมาร์กเกอร์ |
| [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) | ช่องว่างระหว่างกลุ่มแท่งหรือคอลัมน์ที่อยู่ติดกัน, เป็นเปอร์เซ็นต์ของความกว้างแท่งหรือคอลัมน์ |
| [IRotation3D.DepthPercents](https://reference.aspose.com/slides/net/aspose.slides.charts/irotation3d/depthpercents/) | ความลึกรวมของแผนภูมิ, เป็นเปอร์เซ็นต์ของความกว้างแผนภูมิ |

ตัวอย่างอิสระต่อไปนี้ใช้ข้อมูลแผนภูมิมาตรฐานที่มีสามชุดและสี่ประเภท มันบันทึกงานนำเสนอสองไฟล์ด้วยข้อมูล, การหมุน, ความกว้างช่องว่าง, และความลึกแผนภูมิที่เหมือนกัน; มีเพียงความลึกช่องว่างที่แตกต่าง

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

ภาพต่อไปนี้ถูกส่งออกจากงานนำเสนอที่สร้างโดยใช้ Microsoft PowerPoint

| ความลึกช่องว่าง: 0% | ความลึกช่องว่าง: 500% |
| --- | --- |
| ![แผนภูมิคอลัมน์ 3D ไม่มีช่องว่างระหว่างชุดข้อมูลตามแกนความลึก](gap_depth_0.png) | ![แผนภูมิคอลัมน์ 3D มีช่องว่าง 500% ระหว่างชุดข้อมูลตามแกนความลึก](gap_depth_500.png) |

## **เปลี่ยนประเภทชุด 3D และรูปทรงแท่ง**

ในแผนภูมทรงกระบอกแบบกลุ่ม, ชุดแรกเริ่มด้วยรูปทรงแท่งทรงกระบอก ตัวอย่างอ่าน [IChartSeries.Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/type/) และ [IChartSeries.Bar3DShape](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/bar3dshape/) ก่อนและหลังการเปลี่ยนแปลงแต่ละครั้ง

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

| การเปลี่ยนแปลงชุดแรก | `Type` | `Bar3DShape` |
| --- | --- | --- |
| สร้างแผนภูมิ | `ClusteredCylinder` | `Cylinder` |
| ตั้งค่า `Type` เป็น `ClusteredCone` | `ClusteredCone` | `Cone` |
| ตั้งค่า `Bar3DShape` เป็น `Box` | `ClusteredColumn3D` | `Box` |

การตั้งรูปทรงเป็น `Box` จะเปลี่ยนประเภทชุดเป็น `ClusteredColumn3D` ด้วย หากโค้ดของคุณตรวจสอบประเภทชุด, ให้อ่าน `series.Type` หลังจากการเปลี่ยนรูปทรง ค่าที่เก็บไว้ก่อนการกำหนดจะยังคงเลือกสาขา `ClusteredCone`

![การเปรียบเทียบ PowerPoint แสดงชุดแรกเป็นทรงกระบอก, รูปกรวย, และคอลัมน์สี่เหลี่ยมจากซ้ายไปขวา](series-shapes.png)

## **FAQ**

**แผนภูมิประเภทใดบ้างที่รองรับโหมด 3D ใน Aspose.Slides?**

Aspose.Slides รองรับรูปแบบ 3D ของแผนภูมิคอลัมน์ รวมถึง Column 3D, Clustered Column 3D, Stacked Column 3D, และ 100% Stacked Column 3D พร้อมกับประเภท 3D ที่เกี่ยวข้องที่เปิดเผยผ่านการนับจำนวน [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) เพื่อดูรายการที่แม่นยำและเป็นปัจจุบัน ตรวจสอบสมาชิกของ [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) ในอ้างอิง API ของเวอร์ชันที่คุณติดตั้ง

**ฉันสามารถรับภาพเรสเตอร์ของแผนภูมิ 3D เพื่อนำไปใช้ในรายงานหรือเว็บได้หรือไม่?**

ได้ คุณสามารถส่งออกแผนภูมิเป็นภาพด้วย [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) หรือ [เรนเดอร์สไลด์ทั้งหมด](/slides/th/net/convert-powerpoint-to-png/) เป็นรูปแบบเช่น PNG หรือ JPEG สิ่งนี้มีประโยชน์เมื่อคุณต้องการตัวอย่างภาพแบบเรสเตอร์หรือฝังแผนภูมิลงในเอกสาร, แดชบอร์ด, หรือหน้าเว็บโดยไม่ต้องใช้ PowerPoint

**ประสิทธิภาพการสร้างและเรนเดอร์แผนภูมิ 3D ขนาดใหญ่เป็นอย่างไร?**

ประสิทธิภาพขึ้นอยู่กับปริมาณข้อมูลและความซับซ้อนของภาพ เพื่อให้ได้ผลลัพธ์ดีที่สุด ควรลดเอฟเฟกต์ 3D ให้น้อยที่สุด, หลีกเลี่ยงเทกซ์เจอร์หนักบนผนังและพื้นที่พล็อต, จำกัดจำนวนจุดข้อมูลต่อชุดเมื่อทำได้, และเรนเดอร์เป็นขนาดเอาต์พุตที่เหมาะสม (ความละเอียดและขนาด) ให้ตรงกับการแสดงผลหรือการพิมพ์ที่ต้องการ