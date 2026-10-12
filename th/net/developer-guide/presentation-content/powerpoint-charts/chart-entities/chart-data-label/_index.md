---
title: จัดการป้ายกำกับข้อมูลของแผนภูมิในงานนำเสนอด้วย .NET
linktitle: ป้ายกำกับข้อมูล
type: docs
url: /th/net/chart-data-label/
keywords:
- แผนภูมิ
- ป้ายกำกับข้อมูล
- ความแม่นยำของข้อมูล
- เปอร์เซ็นต์
- ระยะห่างของป้ายกำกับ
- ตำแหน่งป้ายกำกับ
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีเพิ่มและจัดรูปแบบป้ายกำกับข้อมูลแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ .NET เพื่อสร้างสไลด์ที่น่าสนใจยิ่งขึ้น."
---
## **บทนำ**

ป้ายกำกับข้อมูลแสดงข้อมูลเกี่ยวกับชุดข้อมูลของแผนภูมิและจุดข้อมูลแต่ละจุด ช่วยให้ผู้อ่านระบุค่าต่าง ๆ และเข้าใจแผนภูมิได้ บทความนี้อธิบายวิธีการจัดรูปแบบค่า การแสดงเปอร์เซ็นต์ การอ่านข้อความป้ายกำกับ การควบคุมป้ายกำกับเหนือค่ามากสุดของแกน การปรับระยะห่างของป้ายกำกับแกนประเภท และการจัดตำแหน่งป้ายกำกับของแผนภูมิพาย

## **ตั้งค่าความแม่นยำของข้อมูลในป้ายกำกับแผนภูมิ**

ใช้ [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) เพื่อจัดรูปแบบค่าของชุดข้อมูล ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้น แสดงตารางข้อมูลของแผนภูมิและเปิดใช้ป้ายกำกับค่าสำหรับชุดข้อมูลแรก รูปแบบ `#,##0.00` จะแสดงเครื่องหมายคั่นหลักพันและทศนิยมสองตำแหน่งโดยไม่เปลี่ยนค่าที่อยู่เบื้องหลัง

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

## **แสดงเปอร์เซ็นต์เป็นป้ายกำกับ**

สำหรับแผนภูมิคอลัมน์แบบซ้อนกัน ให้คำนวณค่าต่าง ๆ เป็นเปอร์เซ็นต์ของผลรวมประเภทของมันและกำหนดข้อความให้กับ [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/). ตัวอย่างนี้ใช้ข้อมูลแผนภูมิเบื้องต้นและแสดงเปอร์เซ็นต์ด้วยทศนิยมสองตำแหน่งในแบบอักษรขนาด 8 จุด ประเภทที่ผลรวมเป็นศูนย์จะถูกข้ามเพื่อหลีกเลี่ยงการหารด้วยศูนย์ คำนวณข้อความป้ายกำกับที่กำหนดเองใหม่หากข้อมูลแผนภูมิมีการเปลี่ยนแปลง

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

## **ตั้งสัญลักษณ์เปอร์เซ็นต์กับป้ายกำกับแผนภูมิ**

เมื่อค่าถูกเก็บเป็นเศษส่วน ให้ใช้ [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) เพื่อแสดงเปอร์เซ็นต์ ตั้งค่า [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) เป็น `false` เพื่อใช้รูปแบบป้ายกำกับแยกจากเซลล์ต้นฉบับ

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ซ้อน 100% พร้อมชุดข้อมูลสีแดงและสีน้ำเงินในสี่ประเภท แต่ละคู่ค่ารวมกันเป็น 1 รูปแบบป้ายกำกับ `0.0%` แสดง 0.30 เป็น 30.0% ในขณะที่แกนแนวตั้งใช้ทศนิยมสองตำแหน่ง ทั้งสองชุดข้อมูลใช้ข้อความป้ายกำกับสีขาว ขนาด 10 จุด

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

## **อ่านข้อความจริงของป้ายกำกับข้อมูล**

ใช้ [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) เพื่อดึงข้อความที่สร้างโดยการตั้งค่าของป้ายกำกับข้อมูล ซึ่งเป็นประโยชน์เมื่อต้องดึงป้ายกำกับสำหรับรายงาน ค้นหาเนื้อหาในงานนำเสนอ หรือยืนยันความถูกต้องของแผนภูมิที่สร้างขึ้น ในตัวอย่างด้านล่าง รูปแบบป้ายกำกับข้อมูลเริ่มต้น [data label format](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) จะรวมชื่อประเภท ชื่อชุดข้อมูล และค่าเข้าด้วยกัน จุดหนึ่งจะแสดงค่าของมันเป็นเปอร์เซ็นต์และอีกจุดหนึ่งใช้ข้อความที่กำหนดเองจาก [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/)

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

ตัวเลขที่เก็บในจุดข้อมูลยังคงเป็น `0.75` แม้ว่าป้ายกำกับจะแสดงเป็น `75%` พร้อมกับชื่อประเภทและชื่อชุดข้อมูล ข้อความที่กำหนดเองจะทดแทนข้อความป้ายกำกับที่สร้างขึ้น [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) จะคืนสตริงป้ายกำกับที่ได้ไม่ว่าจะในกรณีใด ๆ ตรวจสอบ [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) แยกต่างหากตามที่แสดงด้านบนเมื่อต้องการดึงเฉพาะป้ายกำกับที่มองเห็นได้

## **ควบคุมป้ายกำกับข้อมูลที่เหนือค่ามากสุดของแกน**

เมื่อคุณกำหนดช่วงแกนด้วยตนเอง บางจุดข้อมูลอาจเกินค่าสูงสุดของแกน ใช้ [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) เพื่อควบคุมว่าป้ายกำกับของพวกมันจะแสดงหรือไม่ การตั้งค่านี้เปลี่ยนสถานะการมองเห็นของป้ายกำกับ แต่ไม่เปลี่ยนช่วงแกนหรือค่าข้อมูลที่อยู่เบื้องหลัง

ตัวอย่างด้านล่างสร้างแผนภูมิคอลัมน์แบบกลุ่ม 2 มิติที่มีค่าตั้งแต่ 60 และ 120 กำหนด [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) เป็น `false` และ [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) เป็น 100 บนแกนแนวตั้ง สไลด์แรกอนุญาตให้แสดงป้ายกำกับเหนือค่าสูงสุด; สำเนาของสไลด์นั้นปิดการแสดงป้ายกำกับ ทั้งสองสไลด์บันทึกเป็นไฟล์ `DataLabelsOverMaximum.pptx`

เปิดใช้งานป้ายกำกับค่าโดยใช้ [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). การตั้งค่าที่ระดับแผนภูมิจะไม่ทำให้แสดงค่าด้วยตัวเองหรือทำให้การแสดงค่าของป้ายกำกับแต่ละรายการที่ถูกปิดการทำงานเปลี่ยนแปลง ตัวอย่างนี้เปิดใช้ค่าทั้งหมดสำหรับชุดข้อมูลและใช้ [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) เพื่อตำแหน่งป้ายกำกับที่ปลายด้านนอกของแต่ละคอลัมน์

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

ภาพต่อไปนี้แสดงสไลด์ที่บันทึกแล้วซึ่งเรนเดอร์โดย Microsoft PowerPoint เมื่อค่าตั้งเป็น `true` ป้ายกำกับ **120** จะมองเห็นได้ที่ขอบบน; เมื่อเป็น `false` ป้ายกำกับจะถูกซ่อน ป้ายกำกับ **60** ยังมองเห็นได้ ค่าสูงสุดของแกนคงที่ที่ **100** และจุดข้อมูลที่สองยังคงเป็น **120** ในทั้งสองกรณี

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![แผนภูมิโพเวอร์พอยท์แสดงป้ายกำกับค่า 120 พร้อมค่ามากสุดของแกนที่ 100](data-labels-over-maximum-true.png) | ![แผนภูมิโพเวอร์พอยท์ซ่อนป้ายกำกับค่า 120 พร้อมค่ามากสุดของแกนที่ 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
ตัวอย่างนี้ใช้แผนภูมิคอลัมน์ 2D พร้อมแกนค่า แผนภูมิที่ไม่มีแกนค่า เช่น แผนภูมิกลมและแผนภูมอด doughnut จะไม่มีค่ามากสุดของแกนที่สามารถจำกัดได้ในลักษณะนี้
{{% /alert %}}

## **ตั้งระยะห่างของป้ายกำกับจากแกน**

ใช้ [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) เพื่อควบคุมระยะห่างระหว่างป้ายกำกับแกนประเภทกับแกน ค่าเป็นเปอร์เซ็นต์ของขนาดฟอนต์สูงสุดของป้ายกำกับแกน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มและกำหนดค่า offset ของป้ายกำกับแกนแนวนอนเป็น 500 การตั้งค่านี้ส่งผลต่อป้ายกำกับแกนประเภทมากกว่าป้ายกำกับที่แนบกับจุดข้อมูลแต่ละจุด

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

## **ปรับตำแหน่งป้ายกำกับ**

ในแผนภูมิพาย ปรับตำแหน่งป้ายกำกับข้อมูลเพื่อเพิ่มระยะห่างและให้พื้นที่สำหรับเส้นนำ

ตัวอย่างนี้แสดงค่าของจุดข้อมูลแรก วางป้ายกำกับไว้ด้านนอกของชิ้นส่วนพาย และปรับ offset ของ [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) และ [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) offset เหล่านี้จะสัมพันธ์กับความกว้างและความสูงของแผนภูมิ ตามลำดับ

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

![แผนภูมิกลมที่มีตำแหน่งป้ายกำกับข้อมูลปรับแล้ว](pie-chart-adjusted-label.png)

## **เพิ่มหลายแถวของป้ายกำกับข้อมูลเหนือแผนภูมิคอลัมน์**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ที่มีสองแถวของป้ายกำกับข้อมูลเหนือพื้นที่พล็อต ชุดข้อมูล A แสดงคอลัมน์ที่มองเห็นได้ในขณะที่ชุดข้อมูล B และ C ให้ป้ายกำกับเพิ่มเติม คอลัมน์ของพวกมันถูกซ่อนโดยการลบการเติมสีและเส้นขอบ คุณสมบัติ [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) ทำให้ชุดข้อมูลทั้งสามจัดตำแหน่งตรงกับศูนย์กลางประเภทเดียวกัน

การตั้งค่า [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) จัดสรรพื้นที่สำหรับแถวของป้ายกำกับ หลังจากที่ [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) คำนวณตำแหน่งเริ่มต้นแล้ว [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) และ [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) รักษาการจัดแนวนอนและใช้ offset แนวตั้งเพื่อจัดป้ายกำกับในสองแถว ตัวเลขยังคงเป็นป้ายกำกับข้อมูลที่เชื่อมโยงกับค่าชุดข้อมูล; เพียงแถวหัวเรื่องเป็นรูปทรงข้อความแยกต่างหาก

```csharp
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
        // ซ่อนคอลัมน์ของ B และ C แต่คงป้ายข้อมูลไว้
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

// จัดตำแหน่งชุดข้อมูลทั้งสามให้ศูนย์กลางประเภทเดียวกัน
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// ใช้เส้นกริดน้อยลงสำหรับตัวอย่างนี้ที่กระชับ
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// จองพื้นที่เหนือแผนที่พล็อตสำหรับสองแถวของป้ายข้อมูล
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
        // คงตำแหน่งแนวนอนเริ่มต้นไว้ Y เป็นการเยื้องจาก
        // ตัวตำแหน่งป้ายเริ่มต้น โดยแสดงเป็นสัดส่วนของความสูงแผนภูมิ
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // เฉพาะหัวแถวเป็นรูปร่างข้อความแยกต่างหาก
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

![แผนภูมิคอลัมน์ที่มีสองแถวของป้ายกำกับข้อมูลเหนือพื้นที่พล็อต](multiple-rows-of-labels.png)

## **FAQ**

**ฉันจะป้องกันไม่ให้ป้ายกำกับข้อมูลซ้อนทับกันในแผนภูมิที่แออัดได้อย่างไร?**  
ใช้การวางป้ายกำกับอัตโนมัติ, เส้นนำ, และขนาดฟอนต์ที่ลดลงร่วมกัน; หากจำเป็นให้ซ่อนบางฟิลด์ (เช่น ประเภท) หรือแสดงป้ายกำกับเฉพาะค่ามากสุดหรือจุดสำคัญเท่านั้น

**ฉันจะปิดการแสดงป้ายกำกับเฉพาะค่าศูนย์, ค่าติดลบ หรือค่าที่ว่างได้อย่างไร?**  
กรองจุดข้อมูลก่อนเปิดใช้งานป้ายกำกับและปิดการแสดงผลสำหรับค่าศูนย์, ค่าติดลบ, หรือค่าที่หายไปตามกฎที่กำหนด

**ฉันจะทำให้แน่ใจว่ารูปแบบป้ายกำกับสอดคล้องกันเมื่อส่งออกเป็น PDF/รูปภาพได้อย่างไร?**  
กำหนดฟอนต์และขนาดอย่างชัดเจนและตรวจสอบว่าฟอนต์นั้นมีอยู่ในสภาพแวดล้อมการเรนเดอร์เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรอง