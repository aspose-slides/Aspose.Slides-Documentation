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
- ชื่อแกน
- ตำแหน่งแกน
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบวิธีใช้ Aspose.Slides สำหรับ .NET เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงภาพ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งแกนของแผนภูมิด้วย Aspose.Slides for .NET ครอบคลุมค่าที่คำนวณได้ของแกน การสลับแถวและคอลัมน์ของแผนภูมิ การแสดงหรือซ่อนแกน ป้ายชื่อประเภทและช่วงของเครื่องหมายระดับวันที่ การจัดรูปแบบวันที่ การหมุนชื่อเรื่อง การกำหนดตำแหน่งแกน หน่วยการแสดงผล และการสเกลเชิงลอการิทึม

## **รับค่ามากสุดบนแกนแนวตั้งของแผนภูมิ**

สร้าง [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) และเพิ่มแผนภูมิพื้นที่พร้อมข้อมูลเริ่มต้น เรียกใช้ [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) ก่อนอ่านค่าที่คำนวณได้ของแกน เพื่อให้การจัดวางแผนภูมิมีการอัปเดตล่าสุด

อ่าน [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) และ [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) สำหรับขอบเขตของแกน และ [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) และ [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) สำหรับช่วงของเครื่องหมายระดับ [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) และ [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) จะให้สเกลหน่วยเวลา ซึ่งสำคัญต่อแกนวันที่ ตัวอย่างจะจัดเก็บค่าเหล่านี้ในตัวแปรท้องถิ่นและบันทึกแผนภูมิ

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

ใช้ [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) เพื่อสลับบทบาทของชุดข้อมูลและประเภทในข้อมูลแผนภูมิ แต่ละประเภทก่อนหน้า จะกลายเป็นชุดข้อมูล และแต่ละชุดข้อมูลก่อนหน้า จะกลายเป็นประเภท สิ่งนี้จะเปลี่ยนวิธีการจัดกลุ่มข้อมูล; ไม่ได้สลับแกนแนวนอนกับแนวตั้ง ตัวอย่างใช้ [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) เพื่อผูกข้อมูลเริ่มต้นกับ `Sheet1!A1:D5` รวมถึงแถวหัวและคอลัมน์ประเภท ก่อนสลับแถวและคอลัมน์ จากนั้นบันทึกแผนภูมิที่มีสี่ชุดข้อมูลและสามประเภท

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

## **ซ่อนแกนแนวตั้งสำหรับแผนภูมิเส้น**

ตั้งค่า [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) เป็น `false` บนแกนแนวตั้งเพื่อซ่อน แสดงตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยซ่อนแกนแนวตั้ง

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

ตั้งค่า [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) เป็น `false` บนแกนแนวนอนเพื่อซ่อน แสดงตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยซ่อนแกนแนวนอน

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

## **เปลี่ยนแกนประเภท**

ตั้งค่า [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) เพื่อเลือกแกนประเภทแบบวันที่หรือข้อความ ตัวอย่างนี้ต้องใช้ `ExistingChart.pptx` โดยแผนภูมิเป็นรูปร่างแรกบนสไลด์แรกและเซลล์ประเภทมีค่าตัวเลขของวันที่ Excel จะเปลี่ยนแกนแนวนอนเป็นแกนวันที่ การตั้งค่า [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) เป็น `false` , [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) เป็น `1` และ [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) เป็น months จะวางเครื่องหมายระดับหลักที่ช่วงหนึ่งเดือน

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

## **ควบคุมช่วงป้ายชื่อแกนประเภท**

เมื่อแผนภูมิมีหลายประเภท ให้ลดจำนวนป้ายชื่อแกนที่มองเห็นได้โดยไม่ลบประเภทหรือจุดข้อมูลออก ตั้งค่า [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) เป็น `false` แล้วตั้งค่า [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) เป็นช่วงประเภทที่ต้องการ สำหรับประเภทข้อความในลำดับปกติ การนับเริ่มจากประเภทแรก:

| Interval | Labels displayed in the example |
| --- | --- |
| `1` | หมวด 1, หมวด 2, หมวด 3, ... หมวด 24 |
| `2` | หมวด 1, หมวด 3, หมวด 5, ... หมวด 23 |
| `3` | หมวด 1, หมวด 4, หมวด 7, ... หมวด 22 |

ช่วง `3` จะทำให้แสดงป้ายชื่อทุกสามตำแหน่ง โดยเหลือสองป้ายอยู่เบื้องหลัง ช่วงนี้ไม่ได้ลบคอลัมน์ที่เกี่ยวข้องออก การเว้นระยะอัตโนมัติจะเลือกช่วงตามพื้นที่ที่มีอยู่; ไม่ได้บังคับให้แสดงป้ายทั้งหมดเสมอ

เครื่องหมายระดับมีการควบคุมแยกกัน ตั้งค่า [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) เป็น `false` แล้วใช้ [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) เพื่อตั้งค่าช่วงของมัน ตัวอย่างเช่น `1` จะทำให้มีเครื่องหมายระดับที่ทุกช่วงประเภท แม้ว่าป้ายชื่อจะแสดงเพียงทุกสามประเภทเท่านั้น ตั้งค่า [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) ให้เป็นสไตล์ที่มองเห็นได้เพื่อดูผลลัพธ์ การตั้งค่าคุณสมบัติระยะอัตโนมัติใด ๆ กลับเป็น `true` จะทำให้แผนภูมือเลือกช่วงนั้นใหม่อีกครั้ง

ตัวอย่างอิสระต่อไปนี้สร้าง 24 ประเภทและหนึ่งชุดข้อมูล จากนั้นบันทึกสามสไลด์ใน `CategoryAxisIntervals.pptx`: การเว้นระยะอัตโนมัติ, การเว้นระยะแบบแมนนวลพร้อมเครื่องหมายระดับอิสระ, และการคืนค่าเป็นการเว้นระยะอัตโนมัติ สองสำเนารักษาข้อมูลแผนภูมิดั้งเดิม ไม่จำเป็นต้องมีการนำเข้าผลการนำเสนอ ข้อความป้ายแนวนอนทำให้ความหนาแน่นที่แตกต่างกันเห็นได้ง่าย

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

// สไลด์ 2: แสดงทุกป้ายชื่อที่สาม แต่คงเครื่องหมายระดับสำหรับทุกประเภท.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// สไลด์ 3: ให้แผนภูมิเลือกช่วงทั้งสองอีกครั้ง.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**การเว้นระยะอัตโนมัติ (สไลด์ 1):** ในการแสดงนี้ ทุกป้ายชื่อประเภทที่สองจะแสดงและขึ้นบรรทัดสองบรรทัด ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ, ฟอนต์, และเครื่องมือแสดงผล

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**การเว้นระยะแบบแมนนวล (สไลด์ 2):** ทุกป้ายชื่อที่สามจะแสดงบนบรรทัดเดียว ในขณะที่เครื่องหมายระดับยังคงอยู่ที่ทุกช่วงประเภท ทั้ง 24 คอลัมน์ รวมถึงคอลัมน์ที่ไม่มีป้ายชื่อ ยังคงมองเห็นได้ด้วยค่าที่เหมือนกัน สไลด์ 3 คืนค่าการแสดงอัตโนมัติที่แสดงด้านบน

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **เลือกแกนและช่วงที่ถูกต้อง**

ใช้ช่วงจำนวนประเภทนี้สำหรับแกนประเภทข้อความ เช่น แกนประเภทของแผนภูมิคอลัมน์, เส้น, พื้นที่ หรือแถบ ในแผนภูมิคอลัมน์ จะเป็นแกนแนวนอน ในแผนภูมิบาร์แนวนอน แกนประเภทจะเป็นแนวตั้ง ดังนั้นให้ใช้การตั้งค่าเหล่านี้กับ [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) การเว้นระยะของเครื่องหมายระดับยังใช้กับแกนชุดข้อมูลในแผนภูมิที่มีแกนนี้ด้วย

ห้ามใช้การเว้นระยะป้ายชื่อประเภทเพื่อกำหนดสเกลเชิงตัวเลขของแกนค่าตัวเลข บนแกนค่า, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) ระบุความแตกต่างของค่า เช่น หน่วยหลัก `10` จะสร้างเครื่องหมายระดับที่ 0, 10, 20 เป็นต้น เมื่อแกนเริ่มที่ศูนย์ ช่วงป้ายชื่อประเภท `3` จะนับตำแหน่งประเภทโดยไม่สนใจค่าข้อมูล แผนภูมิกระจายและบับเบิลใช้แกนค่าแทนแกนประเภทข้อความ สำหรับแกนวันที่ ให้ใช้หน่วยหลักและสเกลตามเวลาตามที่อธิบายใน [Change a Category Axis](#change-a-category-axis)

## **ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนประเภท**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยค่าปีสี่ค่า วันที่ถูกจัดเก็บเป็นหมายเลขซีเรียล OLE Automation ในเวิร์กชีตแรก (ดัชนี `0`) ตั้งค่า [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) ให้เป็นแกนวันที่ ปิดการเชื่อมโยง [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) แล้วกำหนด `yyyy` ให้กับ [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) เพื่อให้ป้ายชื่อประเภทแสดงปีสี่หลักโดยอิสระจากรูปแบบเซลล์

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

## **ตั้งค่ามุมการหมุนสำหรับชื่อแกนแผนภูมิ**

เปิดใช้ [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) บนแกนแนวตั้ง ให้ข้อความชื่อเรื่อง และตั้งค่า [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) เพื่อหมุนชื่อเรื่อง มุมวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์โดยหมุนชื่อแกนค่าตัวเลขเป็น 90 องศา

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

## **ตั้งค่าตำแหน่งแกนบนแกนประเภทหรือค่า**

ใช้ [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) เพื่อควบคุมว่าแกนค่าจะตัดกับแกนประเภทระหว่างประเภทหรือที่เครื่องหมายระดับของประเภท คุณสมบัตินี้ใช้กับแกนประเภท ตัวอย่างตั้งค่าเป็น `true` บนแกนประเภทแนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์

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

ตั้งค่า [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) เพื่อสเกลป้ายบนแกนค่าโดยไม่ได้เปลี่ยนข้อมูลพื้นฐาน กับ [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) เป็น `Millions` ค่าที่เป็น 60,000,000 จะปรากฏเป็น 60 ตัวอย่างสร้างแผนภูมิคอลัมน์และใช้หน่วยการแสดงผลเป็นล้านบนแกนแนวตั้ง

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

แกนค่าลอการิทึมมีประโยชน์เมื่อค่าบวกกระจายหลายลำดับขนาด เช่น บริการอาจรับคำขอ 10, 100, 1,000, 10,000, และ 100,000 ครั้งในห้าช่วง เวลาแบบเชิงเส้น ค่าตัวเล็กจะอยู่อย่างใกล้กันใกล้ศูนย์ สเกลลอการิทึมทำให้การเปรียบเทียบการเติบโตสัมพัทธ์ง่ายขึ้น: ระยะห่างที่เท่ากันแทนอัตราส่วนที่เท่ากันแทนความแตกต่างที่เท่ากัน

ตั้งค่า [IsLogarithmic](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/islogarithmic/) เป็น `true` บนแกนค่าและใช้ [LogBase](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/logbase/) เพื่อเลือกฐาน สิ่งนี้จะเปลี่ยนวิธีการแสดงค่าที่มีอยู่; ไม่ได้เปลี่ยนข้อมูลหรือเพิ่มเส้นเทรนด์ลอการิทึม เส้นเทรนด์เป็นฟีเจอร์แยกที่แสดงความสัมพันธ์ที่ฟิตกับข้อมูล

### **เลือกแกนค่และฐาน**

สำหรับแผนภูมิเส้นหรือคอลัมน์ แกนค่าคือ [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/) สำหรับแผนภูมิบาร์แนวนอน คือ [HorizontalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/horizontalaxis/) แผนภูมิกระจายและบับเบิลมีสองแกนค่า ดังนั้นเลือกแกนนอนสำหรับค่า X, แกนแนวตั้งสำหรับค่า Y หรือทั้งสอง อย่าใช้สเกลลอการิทึมกับแกนประเภท

ฐานลอการิทึมเริ่มต้นคือ `10` สำหรับแผนภูมิ PPTX ให้ใช้ฐานตั้งแต่ `2` ถึง `1000` รวมทั้งฐานเศษส่วนเช่น `2.5` ก็รองรับด้วย ฐาน `10` จะทำให้กำลังต่อเนื่องเช่น 10, 100, 1,000, และ 10,000 มีระยะห่างเท่ากัน

### **เปรียบเทียบสเกลเชิงเส้นกับลอการิทึม**

ตัวอย่างอิสระต่อไปนี้สร้างแผนภูมิเส้นที่มีจำนวนคำขอห้าช่วงบนสไลด์แรก แล้วทำสำเนาสไลด์นั้นและเปิดใช้แกนค่าลอการิทึมฐาน 10 บนสไลด์ที่สอง ทั้งสองสไลด์เก็บข้อมูลเดียวกัน

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

// เก็บสไลด์แรกเป็นเชิงเส้นและเปลี่ยนสเกลแกนค่าของสำเนาเท่านั้น.
var logarithmicSlide = presentation.Slides.AddClone(slide);
var logarithmicChart = (IChart)logarithmicSlide.Shapes[0];
var valueAxis = logarithmicChart.Axes.VerticalAxis;
valueAxis.IsLogarithmic = true;
valueAxis.LogBase = 10;

presentation.Save("LogarithmicAxis.pptx", SaveFormat.Pptx);
```

**สเกลเชิงเส้น (สไลด์ 1):** ระยะแนวตั้งที่เท่ากันแสดงความแตกต่างของจำนวนคำขอที่เท่ากัน ค่ามากที่สุดครอบงำแผนภูมิ ทำให้ค่าตัวเล็กยากที่จะมองเห็น

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**สเกลลอการิทึม (สไลด์ 2):** ระยะแนวตั้งที่เท่ากันแสดงอัตราส่วนที่เท่ากัน ทุกช่วงมีจำนวนคำขอเพิ่มขึ้นสิบเท่าเมื่อเทียบกับช่วงก่อนหน้า ดังนั้นจุดข้อมูลจะแสดงเป็นเส้นตรงที่เพิ่มขึ้นบนสเกลฐาน 10 ป้ายแกนยังคงแสดงจำนวนคำขอเดิม

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **จัดการค่าศูนย์และค่าติดลบ**

สเกลลอการิทึมสามารถแสดงได้เฉพาะค่าบวกอย่างเคร่งครัด ตรวจสอบข้อมูลก่อนเปิดใช้งาน หากค่าศูนย์หรือค่าติดลบมีความหมาย ควรใช้สเกลเชิงเส้นหรือแสดงแยกต่างหาก หากการยกเว้นค่าดังกล่าวเหมาะสมกับการวิเคราะห์ ให้อธิบายเหตุผล อย่าแทนที่ค่าดังกล่าวอย่างเงียบ ๆ ด้วยจำนวนบวกเล็ก ๆ เพราะจะเปลี่ยนความหมายของข้อมูล ค่าต่ำสุดหรือสูงสุดที่กำหนดด้วยตนเองสำหรับแกนลอการิทึมต้องเป็นค่าบวกด้วยเช่นกัน

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าค่าที่แกนหนึ่งตัดกับแกนอีกอย่างไร (การตัดแกน)?**

ใช้ [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) เพื่อเลือกพฤติกรรมการตัด หากต้องการระบุค่าตัดเชิงตัวเลข ตั้งค่า [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) การตั้งค่าเหล่านี้ทำให้คุณย้ายจุดตัดแกนไปยังพื้นฐานที่เหมาะสม

**ฉันจะกำหนดตำแหน่งป้ายกำกับเครื่องหมายระดับสัมพันธ์กับแกนอย่างไร?**

ตั้งค่า [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) โดยใช้ [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` หรือ `None` เพื่อควบคุมตำแหน่งป้ายกำกับ หากต้องการควบคุมเครื่องหมายระดับเอง ให้ใช้ [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) หรือ [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/) ซึ่งแยกจากการกำหนดตำแหน่งป้ายกำกับอย่างอิสระ