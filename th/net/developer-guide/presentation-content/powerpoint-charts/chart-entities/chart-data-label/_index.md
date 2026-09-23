---
title: จัดการป้ายข้อมูลแผนภูมิในงานนำเสนอด้วย .NET
linktitle: ป้ายข้อมูล
type: docs
url: /th/net/chart-data-label/
keywords:
- แผนภูมิ
- ป้ายข้อมูล
- ความแม่นยำของข้อมูล
- เปอร์เซ็นต์
- ระยะห่างของป้าย
- ตำแหน่งของป้าย
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ .NET เพื่อสร้างสไลด์ที่น่าสนใจยิ่งขึ้น"
---
## **บทนำ**

ป้ายข้อมูลแสดงข้อมูลเกี่ยวกับชุดข้อมูลของแผนภูมิและจุดข้อมูลแต่ละจุด ช่วยให้ผู้อ่านระบุค่าและเข้าใจแผนภูมิได้ บทความนี้อธิบายวิธีจัดรูปแบบค่า แสดงเปอร์เซ็นต์ อ่านข้อความป้าย ปรับระยะห่างของป้ายแกนหมวดหมู่ และกำหนดตำแหน่งป้ายของแผนภูมิวงกลม

## **ตั้งค่าความแม่นยำของข้อมูลในป้ายแผนภูมิ**

ใช้ [NumberFormatOfValues](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/numberformatofvalues/) เพื่อจัดรูปแบบค่าของชุดข้อมูล ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้น แสดงตารางข้อมูลของมัน และเปิดใช้งานป้ายค่าสำหรับชุดข้อมูลแรก รูปแบบ `#,##0.00` แสดงตัวคั่นหลักพันและทศนิยมสองตำแหน่งโดยไม่เปลี่ยนค่าพื้นฐาน

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Line, 50, 50, 450, 300);
chart.HasDataTable = true;

var series = chart.ChartData.Series[0];
series.NumberFormatOfValues = "#,##0.00";
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
```

## **แสดงเปอร์เซ็นต์เป็นป้าย**

สำหรับแผนภูมิตารางซ้อนกัน ให้คำนวณแต่ละค่เป็นเปอร์เซ็นต์ของผลรวมในหมวดหมู่ของมันและกำหนดข้อความไปที่ [TextFrameForOverriding](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) ตัวอย่างนี้ใช้ข้อมูลแผนภูมิเบื้องต้นและแสดงเปอร์เซ็นต์ด้วยทศนิยมสองตำแหน่งในฟอนต์ขนาด 8 จุด หมวดหมู่ที่มีผลรวมเป็นศูนย์จะถูกข้ามเพื่อหลีกเลี่ยงการหารด้วยศูนย์ ให้คำนวณข้อความป้ายแบบกำหนดใหม่หากข้อมูลแผนภูมิมีการเปลี่ยนแปลง

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 400, 400);

var categoryTotals = new double[chart.ChartData.Categories.Count];
for (int k = 0; k < chart.ChartData.Categories.Count; k++)
{
    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        var series = chart.ChartData.Series[i];
        var pointValue = Convert.ToDouble(series.DataPoints[k].Value.Data);
        categoryTotals[k] += pointValue;
    }
}

for (int x = 0; x < chart.ChartData.Series.Count; x++)
{
    var series = chart.ChartData.Series[x];
    series.Labels.DefaultDataLabelFormat.ShowLegendKey = false;

    for (int j = 0; j < series.DataPoints.Count; j++)
    {
        var label = series.DataPoints[j].Label;
        if (categoryTotals[j] == 0)
        {
            continue;
        }

        var pointValue = Convert.ToDouble(series.DataPoints[j].Value.Data);
        var dataPointPercent = (pointValue / categoryTotals[j]) * 100;

        var portion = new Portion();
        portion.Text = string.Format("{0:F2} %", dataPointPercent);
        portion.PortionFormat.FontHeight = 8f;

        label.TextFrameForOverriding.Text = "";

        var paragraph = label.TextFrameForOverriding.Paragraphs[0];
        paragraph.Portions.Add(portion);

        label.DataLabelFormat.ShowValue = true;
        label.DataLabelFormat.ShowSeriesName = false;
        label.DataLabelFormat.ShowPercentage = false;
        label.DataLabelFormat.ShowLegendKey = false;
        label.DataLabelFormat.ShowCategoryName = false;
        label.DataLabelFormat.ShowBubbleSize = false;
    }
}

presentation.Save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
```

## **ตั้งสัญลักษณ์เปอร์เซ็นต์กับป้ายข้อมูลแผนภูมิ**

เมื่อค่าถูกเก็บเป็นเศษส่วน ให้ใช้ [NumberFormat](https://reference.aspose.com/slides/th/net/aspose.slides.charts/idatalabelformat/numberformat/) เพื่อแสดงเป็นเปอร์เซ็นต์ ตั้งค่า [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/th/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) เป็น `false` เพื่อให้รูปแบบป้ายทำงานแยกจากเซลล์ต้นทาง

ตัวอย่างนี้สร้างแผนภูมิตารางซ้อน 100% พร้อมชุดข้อมูลสีแดงและสีน้ำเงินในสี่หมวดหมู่ แต่ละคู่ค่ารวมกันเป็น 1 รูปแบบป้าย `0.0%` แสดง 0.30 เป็น 30.0% ขณะที่แกนแนวตั้งใช้ทศนิยมสองตำแหน่ง ทั้งสองชุดข้อมูลใช้ข้อความป้ายสีขาว ขนาด 10 จุด

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00%";

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
int worksheetIndex = 0;
for (int i = 0; i < 4; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
}

string[] seriesNames = { "Reds", "Blues" };
Color[] seriesColors = { Color.Red, Color.Blue };
double[,] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

for (int i = 0; i < seriesNames.Length; i++)
{
    var seriesCell = workbook.GetCell(worksheetIndex, 0, i + 1, seriesNames[i]);
    var series = chart.ChartData.Series.Add(seriesCell, chart.Type);
    for (int j = 0; j < 4; j++)
    {
        var valueCell = workbook.GetCell(worksheetIndex, j + 1, i + 1, values[i, j]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColors[i];

    var labelFormat = series.Labels.DefaultDataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = false;
    labelFormat.NumberFormat = "0.0%";
    labelFormat.TextFormat.PortionFormat.FontHeight = 10;
    labelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
    labelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.White;
}

presentation.Save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
```

## **อ่านข้อความจริงของป้ายข้อมูล**

ใช้ [GetActualLabelText](https://reference.aspose.com/slides/th/net/aspose.slides.charts/idatalabel/getactuallabeltext/) เพื่อดึงข้อความที่สร้างโดยการตั้งค่าป้ายข้อมูล ซึ่งมีประโยชน์เมื่อดึงป้ายสำหรับรายงาน ค้นหาเนื้อหาในงานนำเสนอ หรือยืนยันความถูกต้องของแผนภูมิที่สร้างขึ้น ในตัวอย่างด้านล่าง รูปแบบป้ายข้อมูลเริ่มต้น [data label format](https://reference.aspose.com/slides/th/net/aspose.slides.charts/idatalabelformat/) จะรวมชื่อหมวดหมู่ ชื่อชุดข้อมูล และค่าไว้ด้วยกัน จุดหนึ่งจัดรูปแบบค่าของมันเป็นเปอร์เซ็นต์ และอีกจุดหนึ่งใช้ข้อความกำหนดเองจาก [TextFrameForOverriding](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/)

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));

var north = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "North"), chart.Type);
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 0.25));
north.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 0.75));

var south = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "South"), chart.Type);
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 2, 0.40));
south.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 2, 0.60));

foreach (var series in chart.ChartData.Series)
{
    var format = series.Labels.DefaultDataLabelFormat;
    format.ShowCategoryName = true;
    format.ShowSeriesName = true;
    format.ShowValue = true;
}

north.Labels[1].DataLabelFormat.IsNumberFormatLinkedToSource = false;
north.Labels[1].DataLabelFormat.NumberFormat = "0%";
south.Labels[0].TextFrameForOverriding.Text = "Reviewed";

foreach (var series in chart.ChartData.Series)
{
    foreach (var point in series.DataPoints)
    {
        var label = point.Label;
        if (!label.IsVisible)
        {
            continue;
        }

        Console.WriteLine($"Value: {point.Value.Data}; label: {label.GetActualLabelText()}");
    }
}
```

ค่าที่เก็บในจุดข้อมูลยังคงเป็น `0.75` แม้ว่าป้ายของมันจะแสดง `75%` พร้อมกับชื่อหมวดหมู่และชื่อชุดข้อมูล ข้อความกำหนดเองจะทับข้อความป้ายที่สร้างขึ้น [GetActualLabelText](https://reference.aspose.com/slides/th/net/aspose.slides.charts/idatalabel/getactuallabeltext/) จะคืนสตริงป้ายผลลัพธ์ในทั้งสองกรณี ตรวจสอบ [IsVisible](https://reference.aspose.com/slides/th/net/aspose.slides.charts/idatalabel/isvisible/) แยกต่างหากตามที่แสดงด้านบนเมื่อคุณต้องการดึงเฉพาะป้ายที่มองเห็นได้

## **ตั้งระยะห่างของป้ายจากแกน**

ใช้ [LabelOffset](https://reference.aspose.com/slides/th/net/aspose.slides.charts/iaxis/labeloffset/) เพื่อควบคุมระยะห่างระหว่างป้ายแกนหมวดหมู่และแกน ค่าจะเป็นเปอร์เซ็นต์ของขนาดฟอนต์สูงสุดของป้ายแกน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มและตั้งค่าออฟเซ็ตป้ายแกนแนวนอนเป็น 500 การตั้งค่านี้ส่งผลต่อป้ายแกนหมวดหมู่ไม่ใช่ป้ายที่แนบกับจุดข้อมูลแต่ละจุด

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
chart.Axes.HorizontalAxis.LabelOffset = 500;

presentation.Save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
```

## **ปรับตำแหน่งป้าย**

ในแผนภูมวงกลมปรับตำแหน่งป้ายข้อมูลเพื่อปรับระยะห่างและให้พื้นที่สำหรับเส้นนำ

ตัวอย่างนี้จะแสดงค่าของจุดข้อมูลแรก วางป้ายของมันด้านนอกส่วนของชิ้น และปรับออฟเซ็ต [X](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ilayoutable/x/) และ [Y](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ilayoutable/y/) ของมัน ออฟเซ็ตเหล่านี้สัมพันธ์กับความกว้างและความสูงของแผนภูมิแต่ละอย่าง

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 200, 200);
var series = chart.ChartData.Series;

var label = series[0].Labels[0];
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;
label.X = 0.71f;
label.Y = 0.04f;

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

![แผนภูมิวงกลมที่ปรับตำแหน่งป้ายข้อมูล](pie-chart-adjusted-label.png)

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันไม่ให้ป้ายข้อมูลซ้อนทับกันในแผนภูมิที่หนาแน่นได้อย่างไร?**

ผสานการจัดวางป้ายอัตโนมัติ, เส้นนำ, และลดขนาดฟอนต์; หากจำเป็นให้ซ่อนไฟล์บางส่วน (เช่น หมวดหมู่) หรือแสดงป้ายเฉพาะค่าที่สุดหรือจุดสำคัญ

**ฉันจะปิดการใช้งานป้ายสำหรับค่าเป็นศูนย์, ลบ, หรือค่าว่างได้อย่างไร?**

กรองจุดข้อมูลก่อนเปิดใช้ป้ายและปิดการแสดงผลสำหรับค่าที่เท่ากับ 0, ค่าลบ, หรือค่าว่างตามกฎที่กำหนด

**ฉันจะทำให้สไตล์ของป้ายคงที่เมื่อส่งออกเป็น PDF/รูปภาพได้อย่างไร?**

กำหนดแบบอักษรและขนาดอย่างชัดเจนและตรวจสอบว่าแบบอักษรพร้อมใช้งานในสภาพแวดล้อมการเรนเดอร์เพื่อหลีกเลี่ยงการใช้แบบอักษรสำรอง