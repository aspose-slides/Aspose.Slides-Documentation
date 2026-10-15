---
title: ปรับแต่งแกนแผนภูมิในงานนำเสนอด้วย .NET
linktitle: แกนแผนภูมิ
type: docs
url: /th/net/chart-axis/
keywords:
- แกนแผนภูมิ
- แกนแนวตั้ง
- แกนแนวนอน
- ปรับแต่งแกน
- จัดการแกน
- บริหารแกน
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
description: "ค้นพบวิธีใช้ Aspose.Slides สำหรับ .NET เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงผล"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนของแผนภูมิด้วย Aspose.Slides for .NET ครอบคลุมค่าที่คำนวณได้ของแกน การสลับแถวและคอลัมน์ของแผนภูมิ การแสดงหรือซ่อนแกน ช่วงเวลาระหว่างป้ายชื่อหมวดและเครื่องหมายติ๊ก การจัดรูปแบบและประเภทของหมวดวันที่ การหมุนหัวข้อ การกำหนดตำแหน่งของแกน หน่วยแสดงผล และการปรับสเกลแบบลอการิทึม

## **รับค่ามากที่สุดบนแกนแนวตั้งในแผนภูมิ**

สร้าง a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) และเพิ่มแผนภูมิแบบพื้นที่ด้วยข้อมูลค่าเริ่มต้น เรียกใช้ [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) ก่อนอ่านค่าที่คำนวณได้ของแกนเพื่อให้การจัดวางแผนภูมิเป็นปัจจุบัน

อ่าน [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) และ [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) สำหรับขอบเขตของแกน และ [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) และ [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) สำหรับช่วงของเครื่องหมายติ๊ก [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) และ [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) ให้สเกลหน่วยเวลา ซึ่งเกี่ยวข้องกับแกนวันที่ ตัวอย่างจะเก็บค่าต่าง ๆ ลงในตัวแปรท้องถิ่นและบันทึกแผนภูมิ

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

ใช้ [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) เพื่อสลับบทบาทของชุดข้อมูลและหมวดในข้อมูลแผนภูมิ หมวดเดิมจะกลายเป็นชุดข้อมูลและชุดข้อมูลเดิมจะกลายเป็นหมวด ซึ่งเปลี่ยนวิธีการจัดกลุ่มข้อมูล แต่ไม่สลับแกนแนวนอนและแนวตั้ง ตัวอย่างใช้ [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) เพื่อตั้งค่าช่วงข้อมูลเริ่มต้นเป็น `Sheet1!A1:D5` รวมแถวหัวและคอลัมน์หมวดก่อนสลับแถวและคอลัมน์ และบันทึกแผนภูมิโดยมีสี่ชุดข้อมูลและสามหมวด

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

ใช้ [IsPlotOrderReversed](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isplotorderreversed/) เพื่อย้อนลำดับของแกนหมวดหรือค่าตัวอย่างเช่น แผนภูมิแท่งแนวนอนสามารถแสดงขั้นตอนของโครงการจากบนลงล่างตามลำดับในแผ่นงาน: Planning, Development, Testing การย้อนลำดับแกนจะเปลี่ยนทิศทางการพล็อต ไม่ได้จัดเรียงหรือเปลี่ยนแปลงข้อมูลในเวิร์กบุ๊ก โดยเปรียบเทียบกับ [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) ที่สลับบทบาทของชุดข้อมูลและหมวด

ตัวอย่างต่อไปนี้สร้างแผนภูมิแท่งแนวนอนที่มีสามขั้นตอนและหนึ่งชุดข้อมูล โดยบันทึกงานนำเสนอสามสไลด์: ลำดับปกติ, หมวดย้อนลำดับ, และค่าย้อนลำดับ แต่ละสำเนาใช้ชุดข้อมูลเดียวกันและมีการย้อนลำดับของแกนเพียงหนึ่งแกนเท่านั้น

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

// สไลด์ 2: แสดงหมวดแรกที่บนสุด.
var categorySlide = presentation.Slides.AddClone(slide);
var categoryChart = (IChart)categorySlide.Shapes[0];
categoryChart.Axes.VerticalAxis.IsPlotOrderReversed = true;
// คงแกนค่าตามแนวนอนไว้ที่ด้านล่าง.
categoryChart.Axes.VerticalAxis.CrossType = CrossesType.Maximum;

// สไลด์ 3: พลิกเฉพาะสเกลเชิงตัวเลขแนวนอนเท่านั้น.
var valueSlide = presentation.Slides.AddClone(slide);
var valueChart = (IChart)valueSlide.Shapes[0];
valueChart.Axes.HorizontalAxis.IsPlotOrderReversed = true;

presentation.Save("ReversedAxes.pptx", SaveFormat.Pptx);
```

การย้อนลำดับแกนยังสามารถย้ายแกนตั้งฉากไปด้านตรงข้ามของพื้นที่พล็อตได้ [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) ควบคุมตำแหน่งที่แกนอื่นตัดกับแกนที่กำลังกำหนดค่า ในสไลด์ 2 การตั้งค่าเป็น `Maximum` บนแกนหมวดที่ย้อนลำดับทำให้แกนค่าตั้งแนวนอนอยู่ที่ด้านล่าง สำหรับจุดตัดที่เฉพาะเจาะจง ให้ใช้ [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) ตรวจสอบการตั้งค่าการตัดขวางเมื่อเปลี่ยนทิศทางโดยเฉพาะอย่างยิ่งหากแผนภูมิมีจุดตัดที่กำหนดเองแล้ว ตั้งค่า `IsPlotOrderReversed` กลับเป็น `false` เพื่อคืนทิศทางการพล็อตปกติ การตั้งค่าการตัดขวางเป็นเรื่องที่แยกจากกัน

| ลำดับปกติ (สไลด์ 1) | หมวดย้อนลำดับ (สไลด์ 2) | ค่ากลับลำดับ (สไลด์ 3) |
| --- | --- | --- |
| ![แผนภูมิแท่งแนวนอนที่มีลำดับแกนหมวดและค่าแบบปกติ](axis-order-normal.png) | ![แผนภูมิแท่งแนวนอนที่แสดงหมวดจากบนลงล่าง](axis-order-categories-reversed.png) | ![แผนภูมิแท่งแนวนอนที่มีแกนค่าย้อนลำดับและศูนย์อยู่ด้านขวา](axis-order-values-reversed.png) |
| หมวดวิ่งจากล่างขึ้นบน; ค่าเพิ่มจากซ้ายไปขวา. | Planning, Development, และ Testing วิ่งจากบนลงล่าง. ค่าและลำดับแถวในเวิร์กบุ๊กไม่เปลี่ยน. | หมวดยังคงลำดับปกติ; ค่าหน่วยเพิ่มจากขวาไปซ้าย. แกนหมวดตัดที่ศูนย์ด้านขวา. |

## **ซ่อนแกนแนวตั้งสำหรับแผนภูมิเส้น**

ตั้งค่า [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) เป็น `false` บนแกนแนวตั้งเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลค่าเริ่มต้นและบันทึกโดยซ่อนแกนแนวตั้ง

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

## **ซ่อนแกนแนวนอนสำหรับแผนภูมิเส้น**

ตั้งค่า [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) เป็น `false` บนแกนแนวนอนเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลค่าเริ่มต้นและบันทึกโดยซ่อนแกนแนวนอน

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

## **เปลี่ยนแกนหมวด**

ตั้งค่า [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) เพื่อเลือกแกนหมวดเป็นวันที่หรือข้อความ ตัวอย่างนี้ต้องการไฟล์ `ExistingChart.pptx` โดยมีแผนภูมิเป็นรูปทรงแรกบนสไลด์แรกและเซลล์หมวดมีค่าตาราง Excel เป็นวันที่แบบตัวเลข จะเปลี่ยนแกนแนวนอนเป็นแกนวันที่ การตั้งค่า [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) เป็น `false` , [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) เป็น `1` และ [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) เป็น months จะวางเครื่องหมายหลักที่ช่วงหนึ่งเดือน

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

## **ควบคุมช่วงเวลาป้ายชื่อแกนหมวด**

เมื่อแผนภูมิมีหมวดจำนวนมาก ให้ลดจำนวนป้ายชื่อแกนที่แสดงโดยไม่ต้องลบหมวดหรือจุดข้อมูล ตั้งค่า [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) เป็น `false` แล้วตั้งค่า [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) เป็นช่วงหมวดที่ต้องการ สำหรับหมวดข้อความในลำดับปกติ การนับจะเริ่มจากหมวดแรก:

| ช่วง | ป้ายชื่อที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | หมวด 1, หมวด 2, หมวด 3, … หมวด 24 |
| `2` | หมวด 1, หมวด 3, หมวด 5, … หมวด 23 |
| `3` | หมวด 1, หมวด 4, หมวด 7, … หมวด 22 |

ช่วง `3` จะแสดงทุกป้ายชื่อที่สามโดยเว้นสองป้ายชื่อระหว่างที่แสดง ไม่ได้ลบคอลัมน์ที่สอดคล้องกัน การจัดช่องว่างอัตโนมัติจะเลือกช่วงตามพื้นที่ว่างที่มี ไม่ได้จำเป็นต้องแสดงทุกป้ายชื่อ

เครื่องหมายติ๊กมีการควบคุมแยกกัน ตั้งค่า [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) เป็น `false` แล้วใช้ [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) เพื่อตั้งค่าช่วงของมัน ตัวอย่างเช่น `1` จะวางเครื่องหมายติ๊กที่ทุกช่วงหมวดในขณะที่ป้ายชื่อปรากฏเพียงทุกหมวดที่สาม ตั้งค่า [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) ให้เป็นสไตล์ที่มองเห็นได้เพื่อให้เห็นผล การตั้งค่าคุณสมบัติเชิงอัตโนมัติใด ๆ กลับเป็น `true` จะให้แผนภูมิกำหนดช่วงนั้นใหม่อีกครั้ง

ตัวอย่างต่อไปนี้สร้างหมวด 24 หมวดและหนึ่งชุดข้อมูล แล้วบันทึกสไลด์สามสไลด์ในไฟล์ `CategoryAxisIntervals.pptx`: การจัดช่องว่างอัตโนมัติ, การจัดช่องว่างป้ายชื่อด้วยเครื่องหมายติ๊กอิสระ,และการคืนค่าเป็นอัตโนมัติ สำเนาสองฉบับเก็บข้อมูลแผนภูมิดั้งเดิม ไม่จำเป็นต้องมีงานนำเข้าพรีเซนเทชัน ข้อความป้ายชื่อแนวนอนทำให้เห็นความหนาแน่นได้ชัดเจน

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

// สไลด์ 2: แสดงทุกป้ายชื่อที่สาม แต่คงเครื่องหมายติ๊กสำหรับทุกหมวด.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// สไลด์ 3: ให้แผนภูมเลือกระยะเวลาทั้งสองครั้งอีกครั้ง.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**การจัดช่องว่างอัตโนมัติ (สไลด์ 1):** ในการแสดงผลนี้ ป้ายชื่อหมวดที่สองจะแสดงและห่อบรรทัดเป็นสองบรรทัด ผลลัพธ์อัตโนมัติอาจแตกต่างกันตามขนาดแผนภูมิ ฟอนต์ และตัวเรนเดอร์

![การจัดช่องว่างป้ายชื่อหมวดอัตโนมัติพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็นได้](category-axis-automatic.png)

**การจัดช่องว่างด้วยตนเอง (สไลด์ 2):** ทุกป้ายชื่อที่สามจะแสดงในบรรทัดเดียวขณะที่เครื่องหมายติ๊กยังคงอยู่ที่ทุกช่วงหมวด ทุกคอลัมน์ 24 คอลัมน์รวมถึงคอลัมน์ที่ไม่มีป้ายชื่อยังคงมองเห็นได้พร้อมค่าตามเดิม สไลด์ 3 คืนค่าการแสดงผลอัตโนมัติที่แสดงด้านบน

![ช่วงป้ายชื่อหมวดแบบมือที่สามพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็นได้](category-axis-manual.png)

### **เลือกแกนและช่วงเวลาที่ถูกต้อง**

ใช้ช่วงเวลานับหมวดนี้สำหรับแกนหมวดแบบข้อความ เช่น แกนหมวดของแผนภูมิคอลัมน์, เส้น, พื้นที่ หรือแท่ง ในแผนภูมิคอลัมน์เป็นแกนแนวนอน ในแผนภูมิแท่งแนวนอนแกนหมวดเป็นแนวตั้ง ดังนั้นให้ใช้การตั้งค่านี้กับ [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) การจัดช่องว่างของเครื่องหมายติ๊กยังใช้ได้กับแกนชุดข้อมูลในแผนภูมิที่มีแกนชุดข้อมูล

ห้ามใช้การจัดช่องว่างป้ายชื่อหมวดเพื่อกำหนดสเกลเชิงตัวเลขของแกนค่า บนแกนค่าจะใช้ [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) เพื่อระบุความแตกต่างของค่า เช่น หน่วยหลัก `10` จะสร้างเครื่องหมายที่ 0, 10, 20 เป็นต้นเมื่อแกนเริ่มจากศูนย์ ส่วนช่วงเวลาป้ายชื่อหมวด `3` จะนับตำแหน่งหมวดโดยไม่สนใจค่าข้อมูล แผนภูมิกระจายและฟองอากาศใช้แกนค่าแทนแกนหมวดแบบข้อความ สำหรับแกนวันที่ ให้ใช้หน่วยหลักและสเกลตามเวลาที่อธิบายในหัวข้อ [เปลี่ยนแกนหมวด](#change-a-category-axis)

## **ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนหมวด**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยค่าปีสี่ค่า วันที่ถูกเก็บเป็นหมายเลขอนุกรม OLE Automation ในเวิร์กชีตแรก (ดัชนี `0`) ตั้งค่า [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) เป็นแกนวันที่ ปิดการทำงานของ [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) และกำหนด `yyyy` ให้กับ [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) เพื่อให้ป้ายชื่อหมวดแสดงปีสี่หลักโดยอิสระจากการจัดรูปแบบเซลล์

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

## **ตั้งค่ามุมการหมุนสำหรับหัวข้อแกนแผนภูมิ**

เปิดใช้งาน [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) บนแกนแนวตั้ง ให้ข้อความหัวข้อ และตั้งค่า [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) เพื่อหมุนหัวข้อ มุมวัดเป็นองศา ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์โดยหัวข้อแกนค่าหมุน 90 องศา

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

## **ตั้งค่าตำแหน่งแกนบนแกนหมวดหรือแกนค่า**

ใช้ [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) เพื่อควบคุมว่าแกนค่าตัดแกนหมวดระหว่างหมวดหรือที่เครื่องหมายติ๊กของหมวด คุณสมบัตินี้ใช้กับแกนหมวด ตัวอย่างตั้งค่าเป็น `true` บนแกนหมวดแนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์

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

## **ตั้งค่าหน่วยแสดงผลบนแกนค่าของแผนภูมิ**

ตั้งค่า [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) เพื่อสเกลป้ายบนแกนค่าโดยไม่ต้องเปลี่ยนข้อมูลพื้นฐาน เมื่อ [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) ตั้งเป็น `Millions` ค่าที่ 60,000,000 จะปรากฏเป็น 60 ตัวอย่างสร้างแผนภูมิคอลัมน์และใช้หน่วยแสดงผลเป็นล้านบนแกนแนวตั้ง

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

## **กำหนดค่าการแสดงผลแกนค่าลอการิทึม**

แกนค่าลอการิทึมมีประโยชน์เมื่อค่าบวกกระจายหลายอันดับ ตัวอย่างเช่น บริการอาจรับคำขอ 10, 100, 1,000, 10,000 และ 100,000 ครั้งในห้าช่วง บนสเกลเชิงเส้น ค่าที่เล็กจะอยู่ใกล้ศูนย์กันมาก ลำดับลอการิทึมทำให้การเติบโตสัมพัทธ์ง่ายต่อการเปรียบเทียบ ระยะเท่ากันแทนที่จะแสดงความแตกต่างเชิงจำนวน จะเป็นอัตราส่วนเท่าเดิม

ตั้งค่า [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) เป็น `true` บนแกนค่าและใช้ [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) เพื่อเลือกฐาน การทำเช่นนี้เปลี่ยนวิธีการแสดงค่าที่มีอยู่ ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นเทรนด์ลอการิทึม เส้นเทรนด์เป็นการแสดงความสัมพันธ์ที่ฟิตกับข้อมูลและเป็นฟีเจอร์แยกต่างหาก

### **เลือกแกนค่าและฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์ แกนค่าคือ [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) สำหรับแผนภูมิแท่งแนวนอนคือ [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/) แผนภูมิกระจายและฟองอากาศมีแกนค่าสองแกน ดังนั้นให้เลือกแกนแนวนอนสำหรับค่า X แกนแนวตั้งสำหรับค่า Y หรือทั้งสองแกน อย่าใช้การสเกลแบบลอการิทึมกับแกนหมวด

ฐานลอการิทึมเริ่มต้นคือ `10` สำหรับแผนภูมิ PPTX สามารถใช้ฐานตั้งแต่ `2` ถึง `1000` รวมถึงฐานเศษส่วนเช่น `2.5` ได้ โดยฐาน `10` จะทำให้กำลังต่อเนื่องเช่น 10, 100, 1,000, 10,000 มีระยะห่างเท่ากัน

### **เปรียบเทียบการสเกลเชิงเส้นและลอการิทึม**

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีจำนวนคำขอห้าช่วงบนสไลด์แรก จากนั้นคัดลอกสไลด์นั้นและเปิดใช้งานแกนค่าลอการิทึมฐาน 10 บนสไลด์ที่สอง ทั้งสองสไลด์คงข้อมูลเดิม

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

// คงสไลด์แรกเป็นเชิงเส้นและเปลี่ยนสเกลแกนค่าของสำเนาเฉพาะ.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**สเกลเชิงเส้น (สไลด์ 1):** ระยะแนวตั้งเท่าเดิมแสดงความแตกต่างของจำนวนคำขอ ค่าที่ใหญ่ที่สุดครอบครองพื้นที่ของแผนภูมิ ทำให้ค่าที่เล็กยากต่อการมองเห็น

![แผนภูมิเส้นใน PowerPoint ที่แสดงจำนวนคำขอห้าช่วงบนแกนค่าเชิงเส้น](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะแนวตั้งเท่าเดิมแสดงอัตราส่วนเท่าเดิม แต่ละช่วงมีคำขอเพิ่มขึ้นสิบเท่าจึงสร้างเส้นตรงที่ขึ้นสูงบนสเกลฐาน 10 ป้ายแกนยังคงแสดงจำนวนคำขอเดิม

![จำนวนคำขอเดียวกันใน PowerPoint บนแกนค่าลอการิทึมฐาน 10](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าติดลบ**

สเกลลอการิทึมสามารถแสดงได้เฉพาะค่าบวกเท่านั้น ตรวจสอบข้อมูลก่อนเปิดใช้งาน หากค่าศูนย์หรือค่าติดลบมีความหมาย ให้คงสเกลเชิงเส้นหรือแสดงแยกออกไป หากการละเว้นค่าดังกล่าวเหมาะสมกับการวิเคราะห์ ให้อธิบายเหตุผล อย่าแทนที่ค่าดังกล่าวด้วยจำนวนบวกเล็ก ๆ อย่างเงียบ ๆ เพราะจะเปลี่ยนความหมายของข้อมูล ค่าต่ำสุดหรือค่าสูงสุดที่กำหนดด้วยตนเองสำหรับแกนลอการิทึมต้องเป็นค่าบวกด้วย

## **FAQ**

**ฉันจะตั้งค่าค่าที่แกนหนึ่งตัดแกนอีก (การตัดแกน) อย่างไร?**

ใช้ [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) เพื่อเลือกพฤติกรรมการตัด หากต้องการกำหนดค่าตัดเชิงตัวเลข ให้ตั้งค่า [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) การตั้งค่าเหล่านี้ทำให้คุณย้ายตำแหน่งการตัดแกนไปยังฐานที่เหมาะสม

**ฉันจะกำหนดตำแหน่งป้ายเลเบลของเครื่องหมายติ๊กสัมพันธ์กับแกนอย่างไร?**

ตั้งค่า [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) โดยใช้ [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo`, หรือ `None` เพื่อควบคุมตำแหน่งของป้ายเลเบล สำหรับควบคุมเครื่องหมายติ๊กเอง ให้ใช้ [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) หรือ [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) ซึ่งแยกจากการจัดตำแหน่งเลเบลอย่างอิสระ.