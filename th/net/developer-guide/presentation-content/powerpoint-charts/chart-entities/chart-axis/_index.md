---
title: ปรับแต่งแกนแผนภูมิในงานนำเสนอใน .NET
linktitle: แกนแผนภูมิ
type: docs
url: /th/net/chart-axis/
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
- หัวข้อแกน
- ตำแหน่งแกน
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบวิธีการใช้ Aspose.Slides สำหรับ .NET เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการสร้างภาพ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งแกนของแผนภูมิด้วย Aspose.Slides for .NET ครอบคลุมค่าของแกนที่คำนวณ, การสลับแถวและคอลัมน์ของแผนภูมิ, การมองเห็นของแกน, ช่วงเวลาของป้ายชื่อหมวดและเครื่องหมายติ๊ก, หมวดวันที่และการจัดรูปแบบ, การหมุนหัวเรื่อง, การกำหนดตำแหน่งของแกน, หน่วยการแสดงผล, และการสเกลลอการิทึม

## **รับค่ามากที่สุดบนแกนแนวตั้งในแผนภูมิ**

สร้าง [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) และเพิ่มแผนภูมิแบบพื้นที่พร้อมข้อมูลเริ่มต้น เรียกใช้ [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) ก่อนอ่านค่าของแกนที่คำนวณเพื่อให้การจัดรูปแบบแผนภูมิเป็นปัจจุบัน

อ่าน [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) และ [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) สำหรับขีดจำกัดของแกน, และ [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) และ [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) สำหรับช่วงเวลาของเครื่องหมายติ๊ก [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) และ [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) ให้สเกลหน่วยเวลา, ซึ่งเกี่ยวข้องกับแกนวันที่ ตัวอย่างจะเก็บค่าเหล่านี้ในตัวแปรโลคัลและบันทึกแผนภูมิ

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
chart.ValidateChartLayout();

var maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
var minValue = chart.Axes.VerticalAxis.ActualMinValue;

var majorUnit = chart.Axes.VerticalAxis.ActualMajorUnit;
var minorUnit = chart.Axes.VerticalAxis.ActualMinorUnit;

var majorUnitScale = chart.Axes.VerticalAxis.ActualMajorUnitScale;
var minorUnitScale = chart.Axes.VerticalAxis.ActualMinorUnitScale;

presentation.Save("AxisValues_out.pptx", SaveFormat.Pptx);
```

## **สลับข้อมูลระหว่างแกน**

ใช้ [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) เพื่อแลกเปลี่ยนบทบาทของ series และ categories ในข้อมูลแผนภูมิ แต่ละ category เดิมจะกลายเป็น series และแต่ละ series เดิมจะกลายเป็น category สิ่งนี้เปลี่ยนวิธีการจัดกลุ่มข้อมูล; ไม่ได้สลับแกนแนวนอนและแนวตั้ง ตัวอย่างใช้ [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) เพื่อผูกข้อมูลเริ่มต้นกับ `Sheet1!A1:D5` รวมถึงแถวหัวและคอลัมน์ category ก่อนสลับแถวและคอลัมน์ จะบันทึกแผนภูมิที่มีสี่ series และสาม category

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

chart.ChartData.SetRange("Sheet1!A1:D5");
chart.ChartData.SwitchRowColumn();

presentation.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
```

## **ย้อนลำดับการพล็อตของแกน**

ใช้ [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) เพื่อย้อนลำดับของ category หรือ value axis ตัวอย่างเช่น แผนภูมิแท่งแนวนอนสามารถแสดงขั้นตอนของโครงการจากบนลงล่างในลำดับเดียวกับแผ่นงาน: Planning, Development, Testing การย้อนลำดับแกนเปลี่ยนทิศทางการพล็อต; ไม่ได้จัดเรียงหรือย้ายข้อมูลในเวิร์กบุ๊ก เพียบเท่า, [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) แลกเปลี่ยนบทบาทของ series และ categories

ตัวอย่างต่อไปนี้สร้างแผนภูมิแท่งแนวนอนที่มีสามขั้นตอนและหนึ่ง series จะบันทึกงานนำเสนอที่มีสามสไลด์: ลำดับปกติ, หมวดสลับ, ค่าสลับ แต่ละสำเนาใช้ชุดข้อมูลเดียวกัน และแต่ละสำเนาจะย้อนลำดับเพียงแกนเดียว

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredBar, 50, 40, 620, 320);
chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredBar);
var stages = new[] { "Planning", "Development", "Testing" };
var values = new[] { 10, 30, 20 };
for (var i = 0; i < stages.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, stages[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

// สไลด์ 2: แสดงหมวดแรกที่ด้านบน.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// คงแกนค่าทางแนวนอนไว้ที่ด้านล่าง.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// สไลด์ 3: พลิกสเกลเชิงตัวเลขแนวนอนเท่านั้น.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

การย้อนลำดับแกนอาจย้ายแกนตั้งฉากไปยังด้านตรงข้ามของพล็อตได้ [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) ควบคุมจุดที่แกนอื่นตัดกับแกนที่กำหนด ในสไลด์ 2 การตั้งค่าเป็น `Maximum` บน category axis ที่ย้อนลำดับทำให้แกนค่าตั้งแนวนอนอยู่ที่ด้านล่าง หากต้องการจุดตัดที่กำหนดให้ใช้ [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/). ตรวจสอบการตั้งค่าการตัดเมื่อเปลี่ยนทิศทาง, โดยเฉพาะหากแผนภูมิมีจุดตัดแบบกำหนดเอง ตั้งค่า `IsPlotOrderReversed` กลับเป็น `false` เพื่อคืนทิศทางการพล็อตตามปกติ; การตั้งค่าการตัดเป็นเรื่องแยกกัน

| ลำดับปกติ (สไลด์ 1) | หมวดสลับ (สไลด์ 2) | ค่าสลับ (สไลด์ 3) |
| --- | --- | --- |
| ![แผนภูมิแท่งแนวนอนที่มีลำดับหมวดและแกนค่าแบบปกติ](axis-order-normal.png) | ![แผนภูมิแท่งแนวนอนที่แสดงหมวดจากบนลงล่าง](axis-order-categories-reversed.png) | ![แผนภูมิแท่งแนวนอนที่มีแกนค่าสลับและศูนย์อยู่ทางขวา](axis-order-values-reversed.png) |
| หมวดจะวิ่งจากด้านล่างไปด้านบน; ค่าจะเพิ่มจากซ้ายไปขวา. | Planning, Development, และ Testing จะวิ่งจากบนลงล่าง. ค่และลำดับแถวของเวิร์กบุ๊กไม่เปลี่ยนแปลง. | หมวดคงลำดับปกติ; ค่าจะเพิ่มจากขวาไปซ้าย. แกนหมวดตัดที่ศูนย์ทางขวา. |

## **ปิดการใช้งานแกนแนวตั้งสำหรับแผนภูมิเส้น**

ตั้งค่า [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) เป็น `false` บนแกนแนวตั้งเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยมีแกนแนวตั้งซ่อน

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.VerticalAxis.IsVisible = false;

presentation.Save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
```

## **ปิดการใช้งานแกนแนวนอนสำหรับแผนภูมิเส้น**

ตั้งค่า [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) เป็น `false` บนแกนแนวนอนเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยมีแกนแนวนอนซ่อน

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
chart.Axes.HorizontalAxis.IsVisible = false;

presentation.Save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
```

## **แสดงหรือซ่อนเส้นกริดของแผนภูมิ**

อ่าน [ShowMajorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showmajorgridlines/) และ [ShowMinorGridLines](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/showminorgridlines/) เพื่อตรวจสอบว่าแกนแสดงเส้นกริดใดบ้าง คุณสมบัติเหล่านี้เป็นแบบอ่านอย่างเดียว ใช้การเติมสีของ [MinorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/minorgridlinesformat/) เพื่อแสดงหรือซ่อนเส้นกริดย่อย ตั้งค่าการเติมแบบทึบพร้อมสีที่มองเห็นได้เพื่อแสดง, หรือใช้ `FillType.NoFill` เพื่อซ่อน ส่วนการตั้งค่าสำหรับเส้นกริดหลักคือ [MajorGridLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorgridlinesformat/)`.Line.FillFormat`. การเปลี่ยนการเติมของเส้นกริดจะคงการมองเห็นของแกนและเครื่องหมายติ๊กไว้

แกนแนวตั้งของแผนภูมิคอลัมน์แบบจัดกลุ่มนี้เริ่มต้นด้วยเส้นกริดหลักที่มองเห็นและเส้นกริดย่อยซ่อน ตัวอย่างแสดงเส้นกริดย่อยเป็นสีส้ม, แล้วซ่อนอีกครั้งก่อนบันทึกงานนำเสนอ

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 30, 660, 230);
var axis = chart.Axes.VerticalAxis;
Console.WriteLine($"Initial: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

var minorFill = axis.MinorGridLinesFormat.Line.FillFormat;
minorFill.FillType = FillType.Solid;
minorFill.SolidFillColor.Color = Color.DarkOrange;
Console.WriteLine($"Enabled: minor={axis.ShowMinorGridLines}");

minorFill.FillType = FillType.NoFill;
Console.WriteLine($"Hidden: major={axis.ShowMajorGridLines}, minor={axis.ShowMinorGridLines}");

presentation.Save("ChartGridlines.pptx", SaveFormat.Pptx);
```

| เส้นกริดย่อยเปิดใช้งาน | เส้นกริดย่อยซ่อน |
| --- | --- |
| ![เส้นกริดย่อยสีส้มระหว่างเส้นกริดหลักบนแกนแนวตั้ง](minor-gridlines-enabled.png) | ![แผนภูคอลัมน์เดียวกันโดยมีเพียงเส้นกริดหลักที่มองเห็นได้](minor-gridlines-hidden.png) |

## **เปลี่ยนแกนประเภท**

ตั้งค่า [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) เพื่อเลือกแกนประเภทแบบวันที่หรือข้อความ ตัวอย่างนี้ต้องใช้ `ExistingChart.pptx`, โดยมีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรกและเซลล์ category มีค่าที่เป็นตัวเลขของวันที่ Excel จะเปลี่ยนแกนแนวนอนเป็นแกนวันที่ การตั้งค่า [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) เป็น `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) เป็น `1`, และ [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) เป็นเดือน จะทำให้เครื่องหมายหลักอยู่ที่ช่วงเวลาหนึ่งเดือน

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

var chart = (IChart) slide.Shapes[0];
chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
chart.Axes.HorizontalAxis.MajorUnit = 1;
chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
```

### **กำหนดประเภทแกนหมวดจากข้อมูล**

เรียกใช้ [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/) หลังจากเติมข้อมูลลงใน category, แล้วอ่าน [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) เพื่อตรวจสอบการเลือก วิธีนี้มีประโยชน์เมื่อแผนภูมิเดียวกันได้รับป้ายข้อความหรือค่าตัวเลขของวันที่ วิธีจะกำหนดประเภทเมื่อเรียกใช้งาน; ไม่ได้เปิดโหมดคงที่ที่ประเมินข้อมูลใหม่ในภายหลัง เรียกใช้อีกครั้งหลังจากแทนที่ category

ตัวอย่างต่อไปนี้สร้างแผนภูมิที่มี category เป็นข้อความและพิมพ์ `Text` จากนั้นแทนที่ค่าเซลล์ category ด้วยวันที่และเรียกเมธอดอีกครั้ง ซึ่งจะพิมพ์ `Date` วันที่ถูกเก็บเป็นค่าตัวเลข OLE Automation ที่คืนจาก [DateTime.ToOADate](https://learn.microsoft.com/en-us/dotnet/api/system.datetime.tooadate) ไม่ใช่สตริงวันที่ [CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/customnumberformat/) ควบคุมวิธีการแสดงค่าเหล่านั้น; ไม่ได้แปลงข้อความเป็นวันที่ตัวเลข สำหรับข้อมูลเพิ่มเติมเกี่ยวกับเซลล์ category ดู [Chart Workbook](/slides/th/net/chart-workbook/)

ใช้การกำหนดอัตโนมัติเมื่ออินพุตเป็นที่รู้ว่าจะมี category เป็นข้อความหรือวันที่เช่นในตัวอย่างนี้ สำหรับป้ายตัวเลขทั่วไป, category ผสม, หรือข้อมูลว่าง ให้ตั้งค่า [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/categoryaxistype/) อย่างชัดเจนให้สอดคล้องกับความหมายที่ตั้งใจ ค่าตัวเลขเพียงอย่างเดียวไม่บ่งบอกว่า category แทนวันที่

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var seriesName = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);
var labels = new[] { "First", "Second", "Third" };

for (var i = 0; i < labels.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, labels[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // ข้อความ

var dates = new[] { new DateTime(2026, 1, 1), new DateTime(2026, 1, 2), new DateTime(2026, 2, 1) };

for (var i = 0; i < dates.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0);
    categoryCell.Value = dates[i].ToOADate();
    categoryCell.CustomNumberFormat = "yyyy-mm-dd";
}

axis.SetCategoryAxisTypeAutomatically();
Console.WriteLine(axis.CategoryAxisType); // วันที่

presentation.Save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx);
```

## **ควบคุมช่วงเวลาของป้ายชื่อแกนประเภท**

เมื่อแผนภูมิมีหลาย category ให้ลดจำนวนป้ายชื่อแกนที่มองเห็นได้โดยไม่ลบ category หรือจุดข้อมูล ตั้งค่า [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) เป็น `false`, แล้วตั้งค่า [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) ให้เป็นช่วงเวลาที่ต้องการของ category สำหรับ category ข้อความในลำดับปกติ การนับเริ่มจาก category แรก:

| ช่วงเวลา | ป้ายชื่อที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | หมวด 1, หมวด 2, หมวด 3, ... หมวด 24 |
| `2` | หมวด 1, หมวด 3, หมวด 5, ... หมวด 23 |
| `3` | หมวด 1, หมวด 4, หมวด 7, ... หมวด 22 |

ช่วงเวลา `3` จะแสดงป้ายชื่อทุกๆ สามอันดับ, ปล่อยให้สองป้ายชื่อซ่อนอยู่ระหว่างป้ายที่แสดง ไม่ได้ลบคอลัมน์ที่สอดคล้องกัน การจัดช่องว่างอัตโนมัติจะเลือกช่วงเวลาตามพื้นที่ที่มี; ไม่ได้แสดงทุกป้ายเสมอ

เครื่องหมายติ๊กมีการควบคุมแยกต่างหาก ตั้งค่า [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) เป็น `false` และใช้ [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) เพื่อตั้งช่วงเวลาของมัน ตัวอย่างเช่น `1` จะทำให้มีเครื่องหมายติ๊กที่ทุกช่วง category ในขณะที่ป้ายชื่อแสดงแค่ทุกสาม category ตั้งค่า [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) ให้เป็นสไตล์ที่มองเห็นได้เพื่อดูผลลัพธ์ การตั้งค่าคุณสมบัติอัตโนมัติใดๆ กลับเป็น `true` จะให้แผนภูมิเพื่อเลือกช่วงเวลานั้นใหม่อีกครั้ง

ตัวอย่างต่อไปนี้เป็นตัวอย่างครบวงจรที่สร้าง 24 category และหนึ่ง series, แล้วบันทึกสามสไลด์ใน `CategoryAxisIntervals.pptx`: การจัดช่องว่างอัตโนมัติ, การจัดช่องว่างแบบแมนนวลพร้อมเครื่องหมายติ๊กอิสระ, และการคืนค่าอัตโนมัติ ทั้งสองสำเนารักษาข้อมูลแผนภูมิดั้งเดิม ไม่ต้องการงานนำเข้าก่อนหน้าข้อมูลแนวนอนทำให้ความหนาแน่นของป้ายชื่อง่ายต่อการสังเกต

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

chart.HasLegend = false;
chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.ClusteredColumn);
for (var i = 0; i < 24; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, 10 + i % 6 * 5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.CategoryAxisType = CategoryAxisType.Text;
axis.TextFormat.TextBlockFormat.RotationAngle = 0;
axis.TextFormat.PortionFormat.FontHeight = 12;
axis.MajorTickMark = TickMarkType.Outside;
axis.IsAutomaticTickLabelSpacing = true;
axis.IsAutomaticTickMarksSpacing = true;

// สไลด์ 2: แสดงทุกป้ายที่สาม, แต่คงเครื่องหมายติ๊กสำหรับทุกหมวด.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// สไลด์ 3: ให้แผนภูมเลือกช่วงเวลาทั้งสองใหม่อีกครั้ง.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**การจัดช่องว่างอัตโนมัติ (สไลด์ 1):** ในการแสดงผลนี้ ป้ายชื่อแต่ละสอง category จะแสดงและจัดบรรทัดสองบรรทัด ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ, ฟอนต์, และเครื่องมือแสดงผล

![การจัดช่องว่างป้ายชื่อประเภทอัตโนมัติโดยมีคอลัมน์ทั้งหมด 24 คอลัมน์มองเห็นได้](category-axis-automatic.png)

**การจัดช่องว่างแบบแมนนวล (สไลด์ 2):** ป้ายชื่อทุกสามอันดับจะแสดงในบรรทัดเดียว, ในขณะที่เครื่องหมายติ๊กยังคงอยู่ที่ทุกช่วง category ทั้ง 24 คอลัมน์รวมถึงคอลัมน์ที่ไม่มีป้ายชื่อยังคงมองเห็นได้ด้วยค่าที่เท่าเดิม สไลด์ 3 คืนค่าการแสดงผลอัตโนมัติที่แสดงด้านบน

![ช่วงเวลาป้ายชื่อประเภทแบบแมนนวลที่สามโดยมีคอลัมน์ทั้งหมด 24 คอลัมน์มองเห็นได้](category-axis-manual.png)

### **เลือกแกนและช่วงเวลาที่ถูกต้อง**

ใช้ช่วงเวลานี้สำหรับแกนประเภทข้อความ เช่น แกนประเภทของแผนภูมิคอลัมน์, เส้น, พื้นที่, หรือแท่ง ในแผนภูมิคอลัมน์เป็นแกนแนวนอน ในแผนภูมิแท่งแนวนอนแกนประเภทเป็นแนวตั้ง จึงใช้การตั้งค่านี้บน [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) การจัดช่องว่างของเครื่องหมายติ๊กยังใช้ได้กับแกน series ในแผนภูมิที่มีแกนนั้น

อย่าใช้การจัดช่องว่างของป้ายชื่อเพื่อกำหนดสเกลเชิงตัวเลขของแกนค่า บนแกนค่า, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) ระบุความแตกต่างของค่า: เช่น หน่วยหลัก `10` จะสร้างเครื่องหมายที่ 0, 10, 20 ฯลฯ เมื่อแกนเริ่มที่ศูนย์ ช่วงเวลาป้ายชื่อประเภท `3` จะนับตำแหน่ง category โดยไม่คำนึงถึงค่าข้อมูล แผนภูมิกระจายและฟองอากาศใช้แกนค่าแทนแกนประเภทข้อความ สำหรับแกนวันที่ใช้หน่วยหลักและสเกลตามเวลาตามที่อธิบายใน [Change a Category Axis](#change-a-category-axis)

## **ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนประเภท**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยค่าปีละสี่ค่า วันที่เก็บเป็นเลขซีเรียล OLE Automation ในเวิร์กชีตแรก (ดัชนี `0`) ตั้งค่า [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) เป็นแกนวันที่, ปิด [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/), และกำหนด `yyyy` ให้กับ [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) เพื่อให้ป้าย category แสดงปีสี่หลักโดยอิสระจากการจัดรูปแบบเซลล์

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
for (var i = 0; i < 4; i++)
{
    var date = new DateTime(2015 + i, 1, 1);
    var categoryCell = workbook.GetCell(0, i + 1, 0, date.ToOADate());
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, i + 1);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.HorizontalAxis.NumberFormat = "yyyy";

presentation.Save("DateAxisFormat.pptx", SaveFormat.Pptx);
```

## **ตั้งค่ามุมการหมุนสำหรับหัวข้อแกนของแผนภูมิ**

เปิดใช้ [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) บนแกนแนวตั้ง, ใส่ข้อความหัวเรื่อง, และตั้งค่า [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) เพื่อหมุนหัวเรื่อง มุมวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์โดยหัวเรื่องแกนค่าถูกหมุน 90 องศา

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("Value");
chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

presentation.Save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
```

## **กำหนดตำแหน่งแกนบนแกนประเภทหรือค่า**

ใช้ [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) เพื่อควบคุมว่ามากกว่าค่าแกนจะตัดแกนประเภทระหว่าง category หรือที่เครื่องหมายติ๊กของ category คุณสมบัตินี้ใช้กับแกนประเภท ตัวอย่างตั้งค่าเป็น `true` บนแกนประเภทแนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

presentation.Save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าหน่วยการแสดงผลบนแกนค่าของแผนภูมิ**

ตั้งค่า [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) เพื่อสเกลป้ายบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน เมื่อ [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) ตั้งเป็น `Millions` ค่า 60,000,000 จะปรากฏเป็น 60 ตัวอย่างสร้างแผนภูมิคอลัมน์และใช้หน่วยแสดงผลเป็นล้านบนแกนแนวตั้ง

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

## **กำหนดค่าแกนค่าลอการิทึม**

แกนค่าลอการิทึมมีประโยชน์เมื่อค่าบวกกระจายหลายลำดับขนาด เช่น บริการอาจได้รับคำขอ 10, 100, 1,000, 10,000, และ 100,000 ครั้งในห้าวาระยะ เวลาแบบเชิงเส้นทำให้ค่าต่ำอยู่ใกล้ศูนย์กัน ส่วนสเกลลอการิทึมทำให้การเติบโตสัมพันธ์ง่ายต่อการเปรียบเทียบ: ระยะห่างที่เท่ากันแทนอัตราส่วนเท่ากัน ไม่ใช่ความแตกต่างที่เท่ากัน

ตั้งค่า [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) เป็น `true` บนแกนค่าและใช้ [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) เพื่อเลือกฐาน การทำเช่นนี้เปลี่ยนวิธีแสดงค่าที่มีอยู่; ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นแนวโน้มลอการิทึม เส้นแนวโน้มเป็นฟีเจอร์แยกต่างหาก

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์แกนค่าคือ [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) สำหรับแผนภูมิแท่งแนวนอนคือ [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/) แผนภูมิกระจายและฟองอากาศมีสองแกนค่า จึงเลือกแกนแนวนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y หรือทั้งสองแกน อย่าใช้สเกลลอการิทึมกับแกนประเภท

ฐานลอการิทึมเริ่มต้นคือ `10` สำหรับแผนภูมิ PPTX สามารถใช้ฐานตั้งแต่ `2` ถึง `1000` รวมถึงฐานเศษเช่น `2.5` ด้วยฐาน `10` พลังที่ต่อเนื่องเช่น 10, 100, 1,000, 10,000 จะมีระยะห่างเท่าเทียมกัน

### **เปรียบเทียบการสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างต่อไปนี้เป็นตัวอย่างครบวงจรที่สร้างแผนภูมิเส้นด้วยจำนวนคำขอห้าครั้งบนสไลด์แรก, แล้วคัดลอกสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทึมฐาน‑10 บนสไลด์ที่สอง สไลด์ทั้งสองรักษาข้อมูลเดิมไว้

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 30, 40, 660, 200);

chart.HasLegend = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Line);
var values = new double[] { 10, 100, 1000, 10000, 100000 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Period {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// คงสไลด์แรกเป็นเชิงเส้นและเปลี่ยนสเกลแกนค่าของสำเนาเท่านั้น.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**การสเกลเชิงเส้น (สไลด์ 1):** ระยะห่างแนวตั้งที่เท่ากันแสดงความแตกต่างที่เท่ากันของจำนวนคำขอ ค่าที่ใหญ่ที่สุดครอบงำแผนภูมิ ทำให้ค่าที่เล็กกว่าเห็นได้ยาก

![แผนภูมิเส้นใน PowerPoint แสดงห้าจำนวนคำขอบนแกนค่าช่วงเชิงเส้น](value-axis-linear.png)

**การสเกลลอการิทึม (สไลด์ 2):** ระยะห่างแนวตั้งที่เท่ากันแสดงอัตราส่วนที่เท่ากัน แต่ละระยะมีคำขอมากกว่าระยะก่อนหน้าเป็นสิบเท่า ดังนั้นจุดข้อมูลจะเป็นเส้นตรงที่ขึ้นบนสเกลฐาน‑10 ป้ายแกนยังคงแสดงจำนวนคำขอเดิม

![จำนวนคำขอเดียวกันใน PowerPoint บนแกนค่าลอการิทึมฐาน‑10](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าลบ**

สเกลลอการิทึมสามารถแสดงได้เฉพาะค่าบวกเท่านั้น ตรวจสอบข้อมูลก่อนเปิดใช้งาน หากค่าศูนย์หรือค่าลบมีความหมาย ให้ใช้สเกลเชิงเส้นหรือแสดงแยกออก หากการละเว้นค่าดังกล่าวเหมาะกับการวิเคราะห์ ให้อธิบายเหตุผล อย่าแทนที่ค่าดังกล่าวโดยเงียบๆ ด้วยเลขบวกเล็ก ๆ เพราะจะเปลี่ยนความหมายของข้อมูล ค่าอย่างน้อยหรือสูงสุดที่กำหนดด้วยตนเองสำหรับแกนลอการิทึมต้องเป็นบวกเช่นกัน

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าค่าที่แกนหนึ่งตัดกับอีกแกน (การตัดแกน) อย่างไร?**

ใช้ [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) เพื่อเลือกพฤติกรรมการตัด หากต้องการกำหนดค่าตัดที่เป็นตัวเลข ให้ตั้งค่า [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) การตั้งค่าเหล่านี้ช่วยคุณย้ายการตัดแกนไปยังฐานที่เหมาะสม

**ฉันจะจัดตำแหน่งป้ายระดับติกสัมพันธ์กับแกนอย่างไร?**

ตั้งค่า [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) ด้วยการใช้ [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None` เพื่อควบคุมตำแหน่งป้ายระดับติก หากต้องการควบคุมเครื่องหมายติ๊กเอง ให้ใช้ [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) หรือ [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) ซึ่งเป็นการตั้งค่าแยกจากตำแหน่งป้ายชื่อ