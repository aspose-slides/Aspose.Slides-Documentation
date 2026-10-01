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
- ดูแลแกน
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
description: "ค้นพบวิธีใช้ Aspose.Slides สำหรับ .NET เพื่อปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงผลข้อมูล."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการปรับแต่งแกนแผนภูมิกับ Aspose.Slides สำหรับ .NET โดยครอบคลุมค่าที่คำนวณของแกน, การสลับแถวและคอลัมน์ของแผนภูมิ, การแสดงหรือซ่อนแกน, ช่วงเวลาของป้ายชื่อหมวดและเครื่องหมายติ๊ก, หมวดวันที่และการจัดรูปแบบ, การหมุนหัวเรื่อง, การกำหนดตำแหน่งแกน, และหน่วยแสดงผล

## **รับค่าสูงสุดบนแกนแนวตั้งของแผนภูมิ**

สร้าง [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) และเพิ่มแผนภูมิพื้นที่ด้วยข้อมูลเริ่มต้น เรียกใช้ [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/validatechartlayout/) ก่อนอ่านค่าที่คำนวณของแกนเพื่อให้การจัดเรียงแผนภูมิเป็นปัจจุบัน

อ่าน [ActualMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmaxvalue/) และ [ActualMinValue](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminvalue/) เพื่อกำหนดขีดจำกัดของแกน, และ [ActualMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunit/) และ [ActualMinorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunit/) เพื่อระยะของเครื่องหมายติ๊ก. [ActualMajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualmajorunitscale/) และ [ActualMinorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/actualminorunitscale/) ให้สเกลหน่วยเวลา, ซึ่งเกี่ยวข้องกับแกนวันที่. ตัวอย่างทำการเก็บค่าดังกล่าวในตัวแปรท้องถิ่นและบันทึกแผนภูมิ

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

ใช้ [SwitchRowColumn](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/switchrowcolumn/) เพื่อสลับบทบาทของซีรีส์และประเภทในข้อมูลแผนภูมิ แต่ละประเภทเดิมจะกลายเป็นซีรีส์และแต่ละซีรีส์เดิมจะกลายเป็นประเภท การเปลี่ยนแปลงนี้ทำให้การจัดกลุ่มข้อมูลเปลี่ยนไป; ไม่ได้สลับแกนแนวนอนและแนวตั้ง ตัวอย่างใช้ [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/setrange/) เพื่อผูกข้อมูลเริ่มต้นกับ `Sheet1!A1:D5` รวมถึงแถวหัวตารางและคอลัมน์ประเภท ก่อนสลับแถวและคอลัมน์ ตัวอย่างบันทึกแผนภูมิที่มีสี่ซีรีส์และสามประเภท

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

## **ปิดการใช้งานแกนแนวตั้งสำหรับแผนภูมิเส้น**

ตั้งค่า [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) เป็น `false` บนแกนแนวตั้งเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยมีแกนแนวตั้งซ่อนอยู่

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

ตั้งค่า [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isvisible/) เป็น `false` บนแกนแนวนอนเพื่อซ่อนมัน ตัวอย่างสร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้นและบันทึกโดยมีแกนแนวนอนซ่อนอยู่

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

ตั้งค่า [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) เพื่อเลือกแกนประเภทแบบวันที่หรือข้อความ ตัวอย่างนี้ต้องการไฟล์ `ExistingChart.pptx` ที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรกและเซลล์ประเภทมีค่าตัวเลขวันที่ของ Excel จะเปลี่ยนแกนแนวนอนเป็นแกนวันที่ การตั้งค่า [IsAutomaticMajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticmajorunit/) เป็น `false`, [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunit/) เป็น `1`, และ [MajorUnitScale](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majorunitscale/) เป็นเดือน จะวางเครื่องหมายหลักที่ช่วงหนึ่งเดือน

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

## **ควบคุมช่วงเวลาป้ายชื่อแกนประเภท**

เมื่อแผนภูมิมีหลายประเภท ให้ลดจำนวนป้ายชื่อแกนที่มองเห็นได้โดยไม่ลบประเภทหรือจุดข้อมูลออก ตั้งค่า [IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticticklabelspacing/) เป็น `false` แล้วตั้งค่า [TickLabelSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/ticklabelspacing/) เป็นช่วงเวลาที่ต้องการของประเภท สำหรับประเภทข้อความในลำดับปกติ การนับเริ่มตั้งแต่ประเภทแรก:

| ช่วงเวลา | ป้ายชื่อที่แสดงในตัวอย่าง |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, ... Category 24 |
| `2` | Category 1, Category 3, Category 5, ... Category 23 |
| `3` | Category 1, Category 4, Category 7, ... Category 22 |

ช่วงเวลา `3` จะแสดงป้ายชื่อทุกสามรายการโดยทิ้งสองป้ายระหว่างที่แสดงไว้ ไม่ได้ลบคอลัมน์ที่สอดคล้องกัน การเว้นระยะอัตโนมัติเลือกช่วงเวลาตามพื้นที่ที่มีอยู่; ไม่ได้จำเป็นต้องแสดงทุกป้ายชื่อ

เครื่องหมายติ๊กมีการควบคุมแยกต่างหาก ตั้งค่า [IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomatictickmarksspacing/) เป็น `false` และใช้ [TickMarksSpacing](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/tickmarksspacing/) เพื่อตั้งค่าช่วงเวลาของมัน ตัวอย่างเช่น `1` จะทำให้มีเครื่องหมายติ๊กที่ทุกช่วงประเภทในขณะที่ป้ายชื่อปรากฏเพียงทุกสามประเภท ตั้งค่า [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majortickmark/) ให้เป็นสไตล์ที่มองเห็นได้เพื่อดูผลลัพธ์ การตั้งค่าใดๆ ของคุณสมบัติเว้นระยะอัตโนมัติกลับเป็น `true` จะทำให้แผนภูมิเลือกช่วงเวลานั้นอีกครั้ง

ตัวอย่างอิสระต่อไปนี้สร้างประเภท 24 รายการและหนึ่งซีรีส์ จากนั้นบันทึกสามสไลด์ในไฟล์ `CategoryAxisIntervals.pptx`: การเว้นระยะอัตโนมัติ, การเว้นระยะป้ายชื่อด้วยตนเองพร้อมเครื่องหมายติ๊กอิสระ, และการคืนค่าเว่นระยะอัตโนมัติ ตัวอย่างสองสำเนาเก็บข้อมูลแผนภูมิต้นฉบับ ไม่จำเป็นต้องมีการนำเสนออินพุต ข้อความป้ายชื่อแนวนอนทำให้เห็นความแตกต่างของความหนาแน่นได้ง่าย

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

// สไลด์ 2: แสดงทุกป้ายชื่อที่สาม แต่คงเครื่องหมายติ๊กไว้สำหรับทุกประเภท.
var manualSlide = presentation.Slides.AddClone(slide);
var manualChart = (IChart)manualSlide.Shapes[0];
var manualAxis = manualChart.Axes.HorizontalAxis;
manualAxis.IsAutomaticTickLabelSpacing = false;
manualAxis.TickLabelSpacing = 3;
manualAxis.IsAutomaticTickMarksSpacing = false;
manualAxis.TickMarksSpacing = 1;

// สไลด์ 3: ให้แผนภูมิเ�เลือกช่วงเวลาทั้งสองครั้งใหม่.
var restoredSlide = presentation.Slides.AddClone(manualSlide);
var restoredChart = (IChart)restoredSlide.Shapes[0];
restoredChart.Axes.HorizontalAxis.IsAutomaticTickLabelSpacing = true;
restoredChart.Axes.HorizontalAxis.IsAutomaticTickMarksSpacing = true;

presentation.Save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
```

**การเว้นระยะอัตโนมัติ (สไลด์ 1):** ในการแสดงผลนี้ ป้ายชื่อประเภททุกสองรายการจะถูกแสดงและตัดบรรทัดเป็นสองบรรทัด ผลลัพธ์อัตโนมัติอาจแตกต่างตามขนาดแผนภูมิ, ฟอนต์, และตัวเรนเดอร์

![การเว้นระยะป้ายชื่อประเภทแบบอัตโนมัติพร้อมคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็นได้](category-axis-automatic.png)

**การเว้นระยะด้วยตนเอง (สไลด์ 2):** ป้ายชื่อทุกสามรายการจะแสดงในบรรทัดเดียวในขณะที่เครื่องหมายติ๊กยังคงอยู่ที่ทุกช่วงประเภท คอลัมน์ทั้งหมด 24 คอลัมน์ รวมถึงที่ไม่มีป้ายชื่อ ยังคงมองเห็นได้พร้อมค่าตรงเดิม สไลด์ 3 จะคืนรูปแบบอัตโนมัติที่แสดงด้านบน

![ช่วงเวลาป้ายชื่อประเภทแบบมือ (3) พร้อมคอลัมน์ทั้งหมด 24 คอลัมน์ที่มองเห็นได้](category-axis-manual.png)

### **เลือกแกนและช่วงเวลาที่ถูกต้อง**

ใช้ช่วงเวลานับประเภทนี้สำหรับแกนประเภทข้อความ เช่น แกนประเภทของแผนภูมิคอลัมน์, เส้น, พื้นที่ หรือแท่ง ในแผนภูมิคอลัมน์ จะเป็นแกนแนวนอน ในแผนภูมิแท่งแนวนอน แกนประเภทจะอยู่ในแนวตั้ง ดังนั้นจึงใช้การตั้งค่าเหล่านี้กับ [VerticalAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxesmanager/verticalaxis/). การเว้นระยะเครื่องหมายติ๊กยังใช้ได้กับแกนซีรีส์ในแผนภูมิที่มีแกนซีรีส์

ห้ามใช้การเว้นระยะป้ายชื่อประเภทเพื่อกำหนดสเกลตัวเลขของแกนค่า ในแกนค่าจะใช้ [MajorUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/majorunit/) กำหนดความแตกต่างของค่า ตัวอย่างเช่น หน่วยหลัก `10` จะสร้างเครื่องหมายที่ 0, 10, 20 เป็นต้น เมื่อแกนเริ่มจากศูนย์ ส่วนช่วงเวลาป้ายชื่อประเภท `3` จะนับตำแหน่งประเภทโดยไม่สนค่าสำหรับข้อมูล แผนภูมิกระจายและฟองอากาศใช้แกนค่าแทนแกนประเภทข้อความ สำหรับแกนวันที่ ให้ใช้หน่วยหลักและสเกลตามเวลา ตามที่อธิบายใน [Change a Category Axis](#change-a-category-axis)

## **ตั้งค่ารูปแบบวันที่สำหรับค่าของแกนประเภท**

ตัวอย่างนี้แทนที่ข้อมูลแผนภูมิเบื้องต้นด้วยค่าประจำปีสี่ค่า วันที่ถูกเก็บเป็นหมายเลขลำดับ OLE Automation ในงานชีตแรก (ดัชนี `0`). ตั้งค่า [CategoryAxisType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/categoryaxistype/) เป็นแกนวันที่ ปิดการทำงานของ [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isnumberformatlinkedtosource/) และกำหนด `yyyy` ให้กับ [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberformat/) เพื่อให้ป้ายชื่อประเภทแสดงปีสี่หลักโดยไม่ขึ้นกับการจัดรูปแบบของเซลล์

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

เปิดใช้งาน [HasTitle](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/hastitle/) บนแกนแนวตั้ง, กำหนดข้อความหัวเรื่อง, และตั้งค่า [RotationAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextblockformat/rotationangle/) เพื่อหมุนหัวเรื่อง มุมจะวัดเป็นองศา; ตัวอย่างนี้บันทึกแผนภูมิคอลัมน์ที่หัวเรื่องแกนค่ได้รับการหมุน 90 องศา

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

ใช้ [AxisBetweenCategories](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/axisbetweencategories/) เพื่อควบคุมว่ามากกค่าของแกนค่าจะตัดกับแกนประเภทระหว่างประเภทหรือที่เครื่องหมายติ๊กของประเภท คุณสมบัตินี้ใช้กับแกนประเภท ตัวอย่างตั้งค่าเป็น `true` บนแกนประเภทแนวนอนของแผนภูมิคอลัมน์และบันทึกผลลัพธ์

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

ตั้งค่า [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/displayunit/) เพื่อปรับสเกลป้ายบนแกนค่าโดยไม่เปลี่ยนข้อมูลพื้นฐาน เมื่อกำหนด [DisplayUnitType](https://reference.aspose.com/slides/net/aspose.slides.charts/displayunittype/) เป็น `Millions` ค่าที่ 60,000,000 จะแสดงเป็น 60 ตัวอย่างสร้างแผนภูมิคอลัมน์และใช้งานหน่วยการแสดงผลล้านบนแกนแนวตั้งของมัน

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

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าค่าที่แกนหนึ่งข้ามแกนอื่น (axis crossing) อย่างไร?**

ใช้ [CrossType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crosstype/) เพื่อเลือกพฤติกรรมการข้าม ใช้ [CrossAt](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/crossat/) เพื่อกำหนดค่าการข้ามแบบตัวเลข การตั้งค่าเหล่านี้ทำให้คุณสามารถย้ายจุดข้ามแกนไปยังฐานที่เหมาะสมได้

**ฉันจะวางตำแหน่งป้ายกำกับติ๊กสัมพันธ์กับแกนอย่างไร?**

ตั้งค่า [TickLabelPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/ticklabelposition/) โดยใช้ [TickLabelPositionType](https://reference.aspose.com/slides/net/aspose.slides.charts/ticklabelpositiontype/) ที่มีค่า `Low`, `High`, `NextTo` หรือ `None`. เพื่อควบคุมเครื่องหมายติ๊กเอง ให้ใช้ [MajorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/majortickmark/) หรือ [MinorTickMark](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/minortickmark/); สิ่งเหล่านี้แยกจากการกำหนดตำแหน่งป้ายชื่อ