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
- ตำแหน่งป้าย
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides for .NET เพื่อให้สไลด์น่าสนใจยิ่งขึ้น"
---
## **บทนำ**

ป้ายข้อมูลจะแสดงข้อมูลเกี่ยวกับชุดข้อมูลของแผนภูมิและจุดข้อมูลแต่ละจุด ช่วยให้ผู้อ่านระบุค่าและเข้าใจแผนภูมิได้ บทความนี้อธิบายวิธีจัดรูปแบบค่า การแสดงเปอร์เซ็นต์ การอ่านข้อความป้าย การควบคุมป้ายที่อยู่เหนือค่าสูงสุดของแกน การปรับช่องว่างของป้ายแกนประเภท และการจัดตำแหน่งป้ายแผนภูมิวงกลม

## **ตั้งค่าความแม่นยำของข้อมูลในป้ายกำกับแผนภูมิ**

ใช้ [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) เพื่อจัดรูปแบบค่าชุดข้อมูล ตัวอย่างนี้สร้างแผนภูมิเส้นพร้อมข้อมูลเริ่มต้น แสดงตารางข้อมูลของแผนภูมิ และเปิดใช้งานป้ายค่า สำหรับชุดข้อมูลแรก รูปแบบ `#,##0.00` จะแสดงตัวคั่นพันและทศนิยมสองตำแหน่งโดยไม่เปลี่ยนค่าเดิม

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

สำหรับแผนภูมิคอลัมน์แบบซ้อนกัน คำนวณค่าแต่ละค่าตามเปอร์เซ็นต์ของผลรวมประเภทและกำหนดข้อความให้กับ [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) ตัวอย่างนี้ใช้ข้อมูลแผนภูมิเริ่มต้นและแสดงเปอร์เซ็นต์ด้วยทศนิยมสองตำแหน่งในฟอนท์ขนาด 8 จุด ประเภทที่มีผลรวมเป็นศูนย์จะถูกข้ามเพื่อหลีกเลี่ยงการหารด้วยศูนย์ หากข้อมูลแผนภูมิมีการเปลี่ยนแปลงให้คำนวณข้อความป้ายแบบกำหนดใหม่

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

## **ตั้งค่าเครื่องหมายเปอร์เซ็นท์กับป้ายข้อมูลแผนภูมิ**

เมื่อค่าถูกจัดเก็บเป็นเศษส่วน ให้ใช้ [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) เพื่อแสดงเปอร์เซ็นต์ ตั้งค่า [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) เป็น `false` เพื่อให้รูปแบบป้ายทำงานแยกจากเซลล์ข้อมูลต้นทาง

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบซ้อน 100% โดยมีชุดสีแดงและสีฟ้าครอบคลุมสี่ประเภท แต่ละคู่ค่ารวมกันได้ 1 รูปแบบป้าย `0.0%` จะแสดง 0.30 เป็น 30.0% ในขณะที่แกนแนวตั้งใช้ทศนิยมสองตำแหน่ง ทั้งสองชุดใช้ข้อความป้ายสีขาว ขนาด 10 จุด

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

ใช้ [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) เพื่อดึงข้อความที่สร้างโดยการตั้งค่าป้ายข้อมูล ซึ่งมีประโยชน์เมื่อต้องสกัดป้ายสำหรับรายงาน ค้นหาเนื้อหาในงานนำเสนอ หรือยืนยันแผนภูมิที่สร้างขึ้น ในตัวอย่างด้านล่าง รูปแบบ [data label format](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) เริ่มต้นจะรวมชื่อประเภท, ชื่อชุดข้อมูล, และค่าต่าง ๆ จุดหนึ่งจะแสดงค่าเป็นเปอร์เซ็นต์ อีกจุดหนึ่งใช้ข้อความกำหนดเองจาก [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/)

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

ค่าที่จัดเก็บในจุดข้อมูลยังคงเป็น `0.75` แม้ว่าป้ายจะแสดง `75%` พร้อมชื่อประเภทและชุดข้อมูล ข้อความกำหนดเองจะแทนที่ข้อความป้ายที่สร้างขึ้น [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) จะคืนสตริงป้ายในกรณีใด ๆ ตรวจสอบ [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) แยกต่างหากตามที่แสดงด้านบนเมื่อคุณต้องการสกัดเฉพาะป้ายที่มองเห็นได้

## **ควบคุมป้ายข้อมูลที่อยู่เหนือค่าสูงสุดของแกน**

เมื่อคุณกำหนดช่วงแกนด้วยตนเอง บางจุดข้อมูลอาจเกินค่าสูงสุด ใช้ [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) เพื่อควบคุมว่าจะแสดงป้ายข้อมูลของพวกมันหรือไม่ การตั้งค่านี้เปลี่ยนการมองเห็นของป้ายเท่านั้น ไม่ได้เปลี่ยนช่วงแกนหรือค่าข้อมูลพื้นฐาน

ตัวอย่างด้านล่างสร้างแผนภูมิคอลัมน์แบบจัดกลุ่ม 2D ด้วยค่าที่ 60 และ 120 ตั้งค่า [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) เป็น `false` และ [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) เป็น 100 บนแกนแนวตั้ง สไลด์แรกอนุญาตให้แสดงป้ายเหนือค่าสูงสุด; สำเนาของสไลด์นั้นปิดการแสดงป้าย ทั้งสองสไลด์บันทึกเป็น `DataLabelsOverMaximum.pptx`

เปิดใช้งานป้ายค่าโดยใช้ [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). การตั้งค่าระดับแผนภูมิไม่ทำให้ค่าแสดงโดยอัตโนมัติหรือเขียนทับการปิดการแสดงค่าของป้ายแต่ละอัน ตัวอย่างนี้เปิดใช้งานค่าทั้งชุดและใช้ [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) เพื่อวางป้ายที่ปลายด้านนอกของแต่ละคอลัมน์

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var firstCategory = workbook.GetCell(0, 1, 0, "Within range");
var secondCategory = workbook.GetCell(0, 2, 0, "Above maximum");

chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);

var seriesName = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesName, chart.Type);

var firstValue = workbook.GetCell(0, 1, 1, 60);
var secondValue = workbook.GetCell(0, 2, 1, 120);

series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);

series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.OutsideEnd;

chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 100;
chart.ShowDataLabelsOverMaximum = true;

var secondSlide = presentation.Slides.AddClone(slide);
var secondChart = (IChart)secondSlide.Shapes[0];
secondChart.ShowDataLabelsOverMaximum = false;

presentation.Save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
```

ภาพต่อไปนี้แสดงสไลด์ที่บันทึกโดย Microsoft PowerPoint ด้วยค่า `true` ป้าย **120** ปรากฏที่ขอบบน; ด้วยค่า `false` ป้ายจะถูกซ่อน ป้าย **60** ยังคงมองเห็นได้ แกนค่าสูงสุดคงที่ที่ **100** และจุดข้อมูลที่สองยังคงเป็น **120** ในทั้งสองกรณี

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![แผนภูมิ PowerPoint แสดงป้ายค่า 120 โดยมีค่าสูงสุดของแกนเป็น 100](data-labels-over-maximum-true.png) | ![แผนภูมิ PowerPoint ซ่อนป้ายค่า 120 โดยมีค่าสูงสุดของแกนเป็น 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
ตัวอย่างนี้ใช้แผนภูมิคอลัมน์ 2D พร้อมแกนค่า แผนภูมิที่ไม่มีแกนค่า เช่น แผนภูมิวงกลมและโดนัท จะไม่มีค่าสูงสุดของแกนให้จำกัดในลักษณะนี้
{{% /alert %}}

## **ตั้งค่าระยะห่างของป้ายจากแกน**

ใช้ [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) เพื่อควบคุมระยะห่างระหว่างป้ายแกนประเภทและแกน ค่าเป็นเปอร์เซ็นต์ของขนาดฟอนท์สูงสุดของป้ายแกน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบจัดกลุ่มและตั้งค่า offset ของป้ายแกนแนวนอนเป็น 500 การตั้งค่านี้ส่งผลต่อป้ายแกนประเภทมากกว่าป้ายที่แนบกับจุดข้อมูลแต่ละจุด

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

บนแผนภูมิว​งกลม ปรับตำแหน่งป้ายข้อมูลเพื่อเพิ่มช่องว่างและให้พื้นที่สำหรับเส้นนำ

ตัวอย่างนี้แสดงค่าของจุดข้อมูลแรก วางป้ายไว้ด้านนอกส่วนของแผนภูมิ และปรับ offset ของ [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) และ [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) ซึ่งเป็นอัตราส่วนของความกว้างและความสูงของแผนภูมิ

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

![แผนภูมิว​งกลมที่ปรับตำแหน่งป้ายข้อมูล](pie-chart-adjusted-label.png)

## **ฟอร์แมตเส้นนำ**

เมื่อป้ายแผนภูมิว​งกลมอยู่ด้านนอกส่วนของแผนภูมิ เส้นนำช่วยให้ผู้อ่านจับคู่ค่ากับส่วนที่ถูกต้องได้ สีที่ตัดกันและเส้นที่หนานิดหน่อยทำให้การเชื่อมต่อเหล่านี้อ่านง่ายขึ้น ในขณะที่ความโปร่งใสและสไตล์เส้นขีดทำให้เส้นดูไม่รบกวนสายตา

ใช้ [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) เพื่อจัดรูปแบบเส้นนำระดับคอลเลกชันป้ายข้อมูลของชุดข้อมูล การตั้งค่าใน `series.Labels.LeaderLinesFormat.Line` จะใช้กับคอลเลกชันทั้งหมด ไม่ได้ใช้กับป้ายเดี่ยว

ตัวอย่างนี้สร้างแผนภูมิว​งกลมด้วยข้อมูลเริ่มต้น แสดงค่าด้านนอกส่วนและเปิดใช้งาน [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/). ใช้ [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) และ [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) เพื่อย้ายสองป้ายไกลจากส่วนของแผนภูมิ โดยอัตราส่วนเป็นส่วนของความกว้างและความสูงของแผนภูมิ ไม่ต้องมีการนำเสนออินพุต

[FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) ของเส้นกำหนดสีฟ้าเด่นพร้อมค่าอัลฟา 191 จาก 255 ซึ่งให้ความโปร่งใสประมาณ 25% [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) ตั้งความหนาเป็น 2 จุด และ [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) ทำให้เส้นเป็นเส้นขีด

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 80, 50, 560, 400);
chart.HasLegend = false;

var series = chart.ChartData.Series[0];

var labelFormat = series.Labels.DefaultDataLabelFormat;
labelFormat.ShowValue = true;
labelFormat.Position = LegendDataLabelPosition.OutsideEnd;
labelFormat.ShowLeaderLines = true;

// ย้ายป้ายสองอันให้ไกลออกจากส่วนของแผนภูมิมากขึ้น.
series.Labels[0].X = 0.10f;
series.Labels[0].Y = -0.05f;
series.Labels[1].X = -0.10f;
series.Labels[1].Y = 0.05f;

var line = series.Labels.LeaderLinesFormat.Line;
line.FillFormat.FillType = FillType.Solid;
line.FillFormat.SolidFillColor.Color = Color.FromArgb(191, 30, 90, 160);
line.Width = 2;
line.DashStyle = LineDashStyle.Dash;

presentation.Save("FormattedLeaderLines.pptx", SaveFormat.Pptx);
```

การเปิดใช้เส้นนำไม่ได้รับประกันว่าจะมีเส้นสำหรับทุกป้าย ความมองเห็นขึ้นอยู่กับตำแหน่งป้ายและพฤติกรรมการจัดวางของแผนภูมิ ในตัวอย่างนี้สองป้ายที่ถูกย้ายมีเส้นนำที่มองเห็นได้; ป้ายที่ยังคงอยู่ใกล้กับส่วนของแผนภูมิไม่ต้องการเส้นนำ

ภาพต่อไปนี้แสดงไฟล์ `FormattedLeaderLines.pptx` ที่บันทึกและเรนเดอร์ด้วย Aspose.Slides:

![แผนภูมิว​งกลมที่มีเส้นนำสีฟ้า โปร่งใส ขีด เชื่อมสองป้ายด้านนอกกับส่วนของแผนภูมิ](formatted-leader-lines.png)

## **เพิ่มหลายแถวของป้ายข้อมูลเหนือแผนภูมิคอลัมน์**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์พร้อมสองแถวของป้ายข้อมูลเหนือพื้นที่กราฟ ชุด A แสดงคอลัมน์ที่มองเห็นได้ ส่วนชุด B และ C ให้ป้ายเพิ่มเติม คอลัมน์ของพวกเขาถูกซ่อนโดยการลบสีเติมและเส้นขอบ คุณสมบัติ [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) ทำให้ทั้งสามชุดจัดแนวกับศูนย์กลางประเภทเดียวกัน

การตั้งค่า [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) จองพื้นที่สำหรับแถวป้าย หลังจาก [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) คำนวนตำแหน่งเริ่มต้นแล้ว [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) และ [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) จะรักษาการจัดแนวนอนและใช้ offset แนวตั้งเพื่อจัดเรียงป้ายเป็นสองแถว ตัวเลขยังคงเป็นป้ายข้อมูลที่เชื่อมโยงกับค่าชุดข้อมูล; เฉพาะหัวแถวที่เป็นรูปร่างข้อความแยกต่างหาก

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
chart.HasTitle = false;
chart.HasLegend = false;
chart.TextFormat.PortionFormat.FontHeight = 12;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

string[] categories = { "North", "South", "East", "West" };
string[] seriesNames = { "Series A", "Series B", "Series C" };
double[,] seriesValues = {
    { 35, 42, 28, 47 },
    { 22, 31, 19, 26 },
    { 12, 16, 14, 18 }
};

for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
{
    var categoryCell = workbook.GetCell(0, categoryIndex + 1, 0, categories[categoryIndex]);
    chart.ChartData.Categories.Add(categoryCell);
}

for (int seriesIndex = 0; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var seriesCell = workbook.GetCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]);
    var series = chart.ChartData.Series.Add(seriesCell, ChartType.ClusteredColumn);

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var valueCell = workbook.GetCell(0, categoryIndex + 1, seriesIndex + 1, seriesValues[seriesIndex, categoryIndex]);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    if (seriesIndex > 0)
    {
        // ซ่อนคอลัมน์ของ B และ C แต่ยังคงแสดงป้ายข้อมูลของพวกมัน.
        series.Format.Fill.FillType = FillType.NoFill;
        series.Format.Line.FillFormat.FillType = FillType.NoFill;
        var labelFormat = series.Labels.DefaultDataLabelFormat;
        labelFormat.ShowValue = true;
        labelFormat.TextFormat.PortionFormat.FontHeight = 12;
        var labelFill = labelFormat.TextFormat.PortionFormat.FillFormat;
        labelFill.FillType = FillType.Solid;
        labelFill.SolidFillColor.Color = Color.Black;
        labelFormat.Position = LegendDataLabelPosition.InsideBase;
    }
}

// จัดตำแหน่งชุดข้อมูลทั้งสามให้ศูนย์กลางประเภทเดียวกัน.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// ใช้เส้นกริดน้อยลงสำหรับตัวอย่างที่กะทัดรัดนี้.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// จองพื้นที่เหนือพื้นที่พล็อตสำหรับสองแถวของป้ายข้อมูล.
chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;
chart.PlotArea.X = 0.15f;
chart.PlotArea.Y = 0.32f;
chart.PlotArea.Width = 0.80f;
chart.PlotArea.Height = 0.48f;
chart.ValidateChartLayout();

for (int seriesIndex = 1; seriesIndex < seriesNames.Length; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

    for (int categoryIndex = 0; categoryIndex < categories.Length; categoryIndex++)
    {
        var dataLabel = series.DataPoints[categoryIndex].Label;
        // คงตำแหน่งแนวนอนค่าเริ่มต้น. Y เป็นการชดเชยจาก
        // ตำแหน่งป้ายค่าเริ่มต้น, แสดงเป็นส่วนของความสูงแผนภูมิ.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // เฉพาะหัวแถวเป็นรูปทรงข้อความแยก.
    var rowHeading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, chart.X, chart.Y + rowTop * chart.Height, 85, 18);
    rowHeading.FillFormat.FillType = FillType.NoFill;
    rowHeading.LineFormat.FillFormat.FillType = FillType.NoFill;
    rowHeading.AddTextFrame(seriesNames[seriesIndex]);
    rowHeading.TextFrame.TextFrameFormat.MarginTop = 0;
    rowHeading.TextFrame.TextFrameFormat.MarginBottom = 0;
    var headingFormat = rowHeading.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
    headingFormat.FontHeight = 12;
    headingFormat.FillFormat.FillType = FillType.Solid;
    headingFormat.FillFormat.SolidFillColor.Color = Color.Black;
}

presentation.Save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
```

![แผนภูมิคอลัมน์ที่มีสองแถวของป้ายข้อมูลเหนือพื้นที่กราฟ](multiple-rows-of-labels.png)

## **คำถามที่พบบ่อย**

**ฉันจะป้องกันไม่ให้ป้ายข้อมูลซ้อนทับกันบนแผนภูมิที่หนาแน่นได้อย่างไร?**

ใช้การวางป้ายอัตโนมัติ, เส้นนำ, และลดขนาดฟอนท์; หากจำเป็นให้ซ่อนบางฟิลด์ (เช่น ประเภท) หรือแสดงป้ายเฉพาะค่าตีสุดหรือจุดสำคัญ

**ฉันจะปิดการทำงานของป้ายเฉพาะค่าศูนย์, ลบลง, หรือว่างได้อย่างไร?**

กรองจุดข้อมูลก่อนเปิดป้ายและปิดการแสดงค่าที่เป็น 0, ค่าลบ, หรือค่าที่หายไปตามกฎที่กำหนด

**ฉันจะทำให้สไตล์ป้ายสม่ำเสมอเมื่อต้องส่งออกเป็น PDF/รูปภาพได้อย่างไร?**

ตั้งค่าฟอนท์และขนาดอย่างชัดเจนและตรวจสอบว่าฟอนท์นั้นมีอยู่ในสภาพแวดล้อมการเรนเดอร์เพื่อหลีกเลี่ยงการใช้ฟอนท์สำรอง