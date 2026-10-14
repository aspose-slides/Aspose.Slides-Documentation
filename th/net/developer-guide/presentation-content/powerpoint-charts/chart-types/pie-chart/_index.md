---
title: ปรับแต่งแผนภูมิวงกลมในการนำเสนอด้วย .NET
linktitle: แผนภูมิวงกลม
type: docs
url: /th/net/pie-chart/
keywords:
- แผนภูมิวงกลม
- จัดการแผนภูมิ
- ปรับแต่งแผนภูมิ
- ตัวเลือกแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกการพล็อต
- สีชิ้นส่วน
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิวงกลมใน .NET ด้วย Aspose.Slides กำหนดค่ากราฟรอง แสดงป้ายข้อมูล และใช้สีชิ้นส่วนอัตโนมัติใน PowerPoint."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับแผนภูมิวงกลมใน Aspose.Slides โดยจะแสดงวิธีกำหนดค่าตัวเลือกกราฟรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie และวิธีเปิดใช้งานการกำหนดสีสลับอัตโนมัติสำหรับแผนภูมิวงกลมมาตรฐาน

ตัวอย่างเหล่านี้มุ่งเน้นที่งานปรับแต่งแผนภูมิเช่น การเพิ่มแผนภูมิลงในสไลด์ การปรับตั้งค่าชุดข้อมูลและป้ายชื่อ การแทนที่ข้อมูลแผนภูมิเบื้องต้นด้วยหมวดหมู่และค่าที่กำหนดเอง และการบันทึกการนำเสนอที่อัปเดต

## **ตัวเลือกกราฟรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie**

Aspose.Slides for .NET รองรับตัวเลือกกราฟรองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie ตัวเลือกเหล่านี้ควบคุมขนาดของกราฟรองและวิธีการแยกจุดข้อมูลระหว่างกราฟสองชุด

ตัวอย่างต่อไปนี้สร้างแผนภูมิ Pie of Pie ในการนำเสนอใหม่และแสดงค่า จุดข้อมูลเป็นป้ายชื่อ คุณสมบัติ [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) ตั้งค่าขนาดของกราฟรองเป็น 149% ของกราฟหลัก [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) เลือกการแยกแบบเปอร์เซ็นต์ และ [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) ตั้งค่าขีดจำกัดที่ 53%.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Display values and configure the secondary plot.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **เลือกหมวดหมู่สำหรับกราฟรอง**

ใช้การแยกแบบกำหนดเองเมื่อคุณต้องการจัดกลุ่มหมวดหมู่เฉพาะในกราฟรองโดยไม่คำนึงถึงค่าร้อยละของพวกมัน ตัวอย่างเช่น รายงานการขายอาจแสดง Online และ Events ร่วมกันเพื่อให้ผู้อ่านเปรียบเทียบสองช่องทางนี้ แม้ว่าพวกมันจะเป็น 35% และ 10% ของยอดขายรวม

ตั้งค่า [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) เป็น [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) แล้วเลือกจุดผ่าน [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/). วิธีการ [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) ของคอลเลกชันรับทั้งดัชนีที่เริ่มจากศูนย์ในชุดข้อมูลหรืออ็อบเจ็กต์จุดข้อมูล ในตัวอย่างนี้ ดัชนี 1 เลือก Online และจุดที่ดัชนี 3 เลือก Events เพิ่ม Partners ชั่วคราวแล้วลบออกโดยใช้ [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// แทนที่ข้อมูลเริ่มต้นด้วยยอดขายตามช่องทาง.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// เลือก Online โดยใช้ดัชนีเริ่มจากศูนย์และ Events โดยใช้วัตถุจุดข้อมูล.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// ยกเว้น Partners จากการเลือกโดยไม่ลบข้อมูลต้นฉบับของมัน.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) และ Events (10) ปรากฏเป็นชิ้นส่วนแยกในกราฟรอง ในกราฟหลัก พวกมันจะแสดงเป็นชิ้นส่วนรวมหนึ่งชิ้นที่มีค่า 45 พร้อมกับ Retail (40) และ Partners (15) การลบ Partners จากการเลือกแบบกำหนดเองทำให้มันยังคงอยู่ในกราฟหลัก; ไม่ได้ลบหมวดหมู่หรือค่าของมันออกจากข้อมูลต้นฉบับของแผนภูมิ

รูปภาพต่อไปนี้แสดงการนำเสนอที่บันทึกใน PowerPoint:

![แผนภูมิ Pie of Pie ที่มี Online และ Events ในกราฟรองและค่ารวมของพวกมันเป็น 45 ในกราฟหลัก](pie_of_pie_custom.png)

## **ตั้งค่าสีชิ้นส่วนอัตโนมัติสำหรับแผนภูมิวงกลม**

Aspose.Slides for .NET สามารถกำหนดสีที่แตกต่างให้กับชิ้นส่วนของแผนภูมิวงกลมโดยอัตโนมัติ ตัวอย่างต่อไปนี้สร้างแผนภูมวงกลมที่มีหัวเรื่องอยู่กึ่งกลางและแทนที่ข้อมูลเริ่มต้นด้วยสามหมวดไตรมาสและค่าของพวกมัน คุณสมบัติ [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) แสดงค่าที่ 20, 50, และ 30 เป็นป้ายชื่อ ในขณะที่ [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) เปิดใช้งานสีที่แตกต่างสำหรับแต่ละชิ้นส่วน

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// เพิ่มหัวเรื่องของแผนภูมิที่อยู่กึ่งกลาง.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// แทนที่ข้อมูลเริ่มต้นโดยใช้แผ่นงานแรก.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// แสดงค่าและกำหนดสีที่แตกต่างให้กับแต่ละชิ้นส่วน.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **คำถามที่พบบ่อย**

**Are the Pie of Pie and Bar of Pie variations supported?**

ใช่, ไลบรารี [supports](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) กราฟรองสำหรับแผนภูมิวงกลม รวมถึงประเภท Pie of Pie และ Bar of Pie

**Can I export just the chart as an image (for example, PNG)?**

ใช่, คุณสามารถ [export the chart itself as an image](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (เช่น PNG) โดยไม่ต้องส่งออกการนำเสนอทั้งหมด