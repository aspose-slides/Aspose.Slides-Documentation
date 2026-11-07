---
title: จัดการป้ายข้อมูลแผนภูมิในการนำเสนอด้วย .NET
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
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการเพิ่มและจัดรูปแบบป้ายข้อมูลแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ .NET เพื่อให้สไลด์น่าสนใจมากขึ้น."
---
## **บทนำ**

ป้ายข้อมูลจะแสดงข้อมูลเกี่ยวกับซีรีส์ของแผนภูมิและจุดข้อมูลแต่ละจุด ช่วยให้ผู้อ่านระบุค่าและเข้าใจแผนภูมิได้ บทความนี้อธิบายวิธีจัดรูปแบบค่า แสดงร้อยละ อ่านข้อความป้าย ควบคุมป้ายเหนือค่ามากสุดของแกน ปรับช่องว่างของป้ายแกนประเภท และกำหนดตำแหน่งป้ายของแผนภูมิวงกลม

## **Count Visible Data Labels**

ใช้ [CountOfVisibleDataLabels](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/countofvisibledatalabels/) เพื่อตรวจสอบว่ามีป้ายข้อมูลกี่รายการที่เปิดให้แสดงก่อนเผยแพร่งานนำเสนอ แตกต่างจาก [Count](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/count/) ซึ่งคืนค่าจำนวนป้ายทั้งหมดในคอลเลกชัน วิธีนี้จะพิจารณาค่าพื้นฐานของซีรีส์และการตั้งค่าป้ายแต่ละรายการด้วย

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ที่มีซีรีส์หนึ่งและจุดข้อมูลสามจุด เข้าถึงคอลเลกชัน [Labels](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/labels/) ของซีรีส์และพิมพ์จำนวนที่มองเห็นได้เมื่อการตั้งค่าเปลี่ยน: **0, 3, 2, 3** จำนวนทั้งหมดคงเป็น **3**  

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesCell = workbook.GetCell(0, 0, 1, "Values");
var series = chart.ChartData.Series.Add(seriesCell, chart.Type);

for (int i = 0; i < 3; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Category {i + 1}");
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, (i + 1) * 10);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var labels = series.Labels;
Console.WriteLine($"Total: {labels.Count}; visible: {labels.CountOfVisibleDataLabels}"); // รวม: 3; มองเห็น: 0

labels.DefaultDataLabelFormat.ShowValue = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // มองเห็น: 3

labels[1].DataLabelFormat.ShowValue = false;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // มองเห็น: 2

labels[1].DataLabelFormat.ShowLegendKey = true;
Console.WriteLine($"Visible: {labels.CountOfVisibleDataLabels}"); // มองเห็น: 3
```

[DefaultDataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultdatalabelformat/) ของซีรีส์ให้การตั้งค่าพื้นฐาน การเปิดใช้งาน [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) ที่นั่นจะแสดงค่าของป้ายทั้งสาม รายการตั้งค่าเป็น `false` ผ่าน [DataLabelFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/datalabelformat/) ของป้ายหนึ่งรายการจะลบการตั้งค่านี้สำหรับป้ายที่เลือก การเปิดใช้งาน [ShowLegendKey](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showlegendkey/) ทำให้ป้ายดังกล่าวนับเป็นที่มองเห็นได้อีกครั้ง แม้ว่าค่าจะยังคงถูกซ่อนอยู่

จำนวนที่มองเห็นได้สะท้อนการตั้งค่าการมองเห็นเท่านั้น ไม่ได้วัดว่าป้ายทับกัน ถูกตัด หรืออ่านได้ในแผนภูมิที่แสดงผล

## **Set Data Precision in Chart Data Labels**

ใช้ [NumberFormatOfValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/numberformatofvalues/) เพื่อจัดรูปแบบค่าของซีรีส์ ตัวอย่างนี้สร้างแผนภูมิเส้นด้วยข้อมูลเริ่มต้น แสดงตารางข้อมูลและเปิดป้ายค่าของซีรีส์แรก รูปแบบ `#,##0.00` จะแสดงคั่นหลักพันและทศนิยมสองตำแหน่งโดยไม่เปลี่ยนค่าฐานข้อมูล  

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

เพื่อจัดรูปแบบเซลล์ตัวเลขในหนังสือทำงานที่ฝังอยู่ของแผนภูมิ ดูที่ [Set Custom Number Formats for Workbook Cells](/slides/th/net/chart-workbook/#set-custom-number-formats-for-workbook-cells) ตัวอย่างนั้นยังแสดงว่าป้ายค่าจะสืบตามรูปแบบเซลล์ต้นทางในขณะที่ยังคงเก็บค่าตัวเลขไว้เดิม

## **Display Percentage as Labels**

สำหรับแผนภูมิคอลัมน์แบบเรียงซ้อน ให้คำนวณแต่ละค่าเป็นเปอร์เซ็นต์ของผลรวมหมวดหมู่และกำหนดข้อความให้กับ [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/) ตัวอย่างนี้ใช้ข้อมูลแผนภูมิเริ่มต้นและแสดงเปอร์เซ็นต์ด้วยทศนิยมสองตำแหน่งในฟอนต์ขนาด 8 จุด หมวดหมู่ที่ผลรวมเป็นศูนย์จะถูกข้ามเพื่อหลีกเลี่ยงการหารด้วยศูนย์ หากข้อมูลแผนภูมิมีการเปลี่ยนแปลงต้องคำนวณข้อความป้ายใหม่  

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

## **Set Percentage Sign with Chart Data Labels**

เมื่อค่าถูกเก็บเป็นเศษส่วน ให้ใช้ [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) เพื่อแสดงเป็นเปอร์เซ็นต์ ตั้งค่า [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) เป็น `false` เพื่อให้รูปแบบป้ายทำงานแยกจากเซลล์ต้นทาง

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 100% แบบเรียงซ้อนที่มีซีรีส์สีแดงและสีน้ำเงินสี่หมวด หมายเหตุแต่ละคู่ค่ารวมกันเป็น 1 รูปแบบป้าย `0.0%` จะทำให้ 0.30 แสดงเป็น 30.0% ส่วนแกนแนวตั้งใช้ทศนิยมสองตำแหน่ง ทั้งสองซีรีส์ใช้ข้อความป้ายสีขาว ขนาด 10 จุด  

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

## **Read the Actual Text of Data Labels**

ใช้ [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) เพื่อดึงข้อความที่สร้างโดยการตั้งค่าป้ายข้อมูล วิธีนี้มีประโยชน์เมื่อดึงป้ายเพื่อรายงาน ค้นหาเนื้อหาในงานนำเสนอ หรือยืนยันแผนภูมิที่สร้างขึ้น ในตัวอย่างด้านล่าง รูปแบบ [data label format](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/) เริ่มต้นรวมชื่อหมวด ชื่อซีรีส์ และค่า จุดหนึ่งจัดรูปแบบค่าของมันเป็นเปอร์เซ็นต์ อีกจุดหนึ่งใช้ข้อความกำหนดเองจาก [TextFrameForOverriding](https://reference.aspose.com/slides/net/aspose.slides.charts/ioverridabletext/textframeforoverriding/)  

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

ค่าที่ถูกเก็บในจุดข้อมูลยังคงเป็น `0.75` แม้ว่าป้ายจะแสดง `75%` พร้อมกับชื่อหมวดและชื่อซีรีส์ ข้อความกำหนดเองจะทับข้อความป้ายที่สร้างโดยอัตโนมัติ [GetActualLabelText](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/getactuallabeltext/) จะส่งกลับสตริงป้ายในทั้งสองกรณี ตรวจสอบ [IsVisible](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/isvisible/) แยกต่างหากตามที่แสดงในส่วนก่อนหน้าเมื่อคุณต้องการดึงป้ายที่มองเห็นได้เท่านั้น

## **Control Data Labels Beyond the Axis Maximum**

เมื่อคุณกำหนดช่วงแกนด้วยตนเอง บางจุดข้อมูลอาจเกินค่ามากสุด ใช้ [ShowDataLabelsOverMaximum](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/showdatalabelsovermaximum/) เพื่อควบคุมว่าป้ายข้อมูลของพวกเขาจะถูกแสดงหรือไม่ การตั้งค่านี้เปลี่ยนการมองเห็นของป้ายเท่านั้น ไม่ได้เปลี่ยนช่วงแกนหรือค่าข้อมูลพื้นฐาน

ตัวอย่างด้านล่างสร้างแผนภูมิคอลัมน์แบบคลัสเตอร์ 2D ที่มีค่า 60 และ 120 ตั้งค่า [IsAutomaticMaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isautomaticmaxvalue/) เป็น `false` และ [MaxValue](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/maxvalue/) เป็น 100 บนแกนแนวตั้ง สไลด์แรกเปิดให้ป้ายแสดงเกินค่ามากสุด; สำเนาของสไลด์นั้นปิดคุณสมบัตินี้ สไลด์ทั้งสองบันทึกเป็น `DataLabelsOverMaximum.pptx`

เปิดป้ายค่าโดยใช้ [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) การตั้งค่าระดับแผนภูมิไม่ทำให้ค่าถูกแสดงโดยอัตโนมัติหรือเขียนทับการปิดการแสดงค่าของป้ายแต่ละรายการ ตัวอย่างนี้เปิดค่าจากซีรีส์ทั้งหมดและใช้ [Position](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/position/) เพื่อวางป้ายที่ปลายนอกของแต่ละคอลัมน์  

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

ภาพต่อไปแสดงสไลด์ที่บันทึกแล้วโดย Microsoft PowerPoint เมื่อ `true` ป้าย **120** จะมองเห็นได้ที่ขอบบน; เมื่อ `false` ป้ายจะถูกซ่อน ป้าย **60** ยังคงมองเห็นได้ ค่าแกนสูงสุดคงที่ที่ **100** และจุดข้อมูลที่สองยังคงเป็น **120** ในทั้งสองกรณี  

| ShowDataLabelsOverMaximum = true | ShowDataLabelsOverMaximum = false |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
ตัวอย่างนี้ใช้แผนภูมิคอลัมน์ 2D ที่มีแกนค่า แผนภูมิที่ไม่มีแกนค่า เช่น แผนภูมิวงกลมหรือโดนัท จะไม่มีค่ามากสุดของแกนให้จำกัดแบบนี้
{{% /alert %}}

## **Set Label Distance from an Axis**

ใช้ [LabelOffset](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/labeloffset/) เพื่อควบคุมระยะห่างระหว่างป้ายแกนประเภทและแกน ค่าเป็นเปอร์เซ็นต์ของขนาดฟอนต์สูงสุดของป้ายแกน ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบคลัสเตอร์และตั้งค่าออฟเซ็ตป้ายแกนแนวนอนเป็น 500 การตั้งค่านี้ส่งผลต่อป้ายแกนประเภท ไม่ใช่ป้ายที่ผูกติดกับจุดข้อมูลแต่ละจุด  

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

## **Adjust Label Location**

บนแผนภูมิวงกลม ปรับตำแหน่งป้ายข้อมูลเพื่อเพิ่มระยะห่างและให้พื้นที่สำหรับเส้นเชื่อม

ตัวอย่างนี้แสดงค่าของจุดข้อมูลแรก วางป้ายออกนอกส่วนของชิ้น และปรับออฟเซ็ต [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) และ [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) ของมัน ออฟเซ็ตเหล่านี้อ้างอิงจากความกว้างและความสูงของแผนภูมิตามลำดับ  

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **Format Leader Lines**

เมื่อป้ายแผนภูมิวงกลมอยู่ด้านนอกชิ้นเส้นเชื่อมช่วยให้ผู้อ่านจับคู่ค่ากับชิ้นที่ถูกต้อง สีที่ตัดกันและเส้นที่หนาขึ้นเล็กน้อยทำให้การเชื่อมต่ออ่านง่ายขึ้น ขณะเดียวกันความโปร่งใสและสไตล์จุดประจายทำให้เส้นไม่รบกายต่อสายตา

ใช้ [LeaderLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/datalabelcollection/leaderlinesformat/) เพื่อจัดรูปแบบเส้นเชื่อมระดับคอลเลกชันป้ายข้อมูลของซีรีส์ การตั้งค่าใน `series.Labels.LeaderLinesFormat.Line` จะใช้กับคอลเลกชันทั้งชุด ไม่ใช่กับป้ายแต่ละอัน

ตัวอย่างนี้สร้างแผนภูมิวงกลมด้วยข้อมูลเริ่มต้น แสดงค่าที่นอกชิ้น และเปิดใช้งาน [ShowLeaderLines](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showleaderlines/) ย้ายป้ายสองอันให้ห่างจากชิ้นมากขึ้นโดยใช้ออฟเซ็ต [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) และ [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) เป็นส่วนของความกว้างและความสูงของแผนภูมิ ไม่ต้องมีงานนำเสนออินพุต

[FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) ของเส้นตั้งค่าสีฟ้าทึบพร้อมค่าอัลฟา 191 จาก 255 ให้ความโปร่งใสประมาณ 25% [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) ตั้งความหนาเป็น 2 จุด และ [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) ทำให้เส้นเป็นจุดประจาย  

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

// ย้ายป้ายสองอันให้ห่างออกจากส่วนของมันมากขึ้น.
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

การเปิดใช้เส้นเชื่อมไม่ได้รับประกันว่าจะมีเส้นสำหรับทุกป้าย การมองเห็นขึ้นอยู่กับตำแหน่งป้ายและพฤติกรรมการจัดวางของแผนภูมิ ในตัวอย่างนี้สองป้ายที่ย้ายตำแหน่งจะมีเส้นเชื่อมที่มองเห็นได้; ป้ายที่อยู่ใกล้ชิ้นไม่จำเป็นต้องมีเส้น

ภาพต่อไปแสดงไฟล์ `FormattedLeaderLines.pptx` ที่บันทึกแล้วและเรนเดอร์ด้วย Aspose.Slides:

![Pie chart with blue, semitransparent dashed leader lines connecting two outside labels to their slices](formatted-leader-lines.png)

## **Add Multiple Rows of Data Labels Above a Column Chart**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ที่มีสองแถวของป้ายข้อมูลอยู่เหนือพื้นที่พล็อต ซีรีส์ A แสดงคอลัมน์ที่มองเห็นได้ ส่วนซีรีส์ B และ C ให้ป้ายเพิ่มเติม คอลัมน์ของพวกมันถูกซ่อนโดยลบการเติมสีและรูปลายเส้น คุณสมบัติ [Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) ทำให้ทั้งสามซีรีส์ลับกับศูนย์กลางหมวดเดียวกัน

การตั้งค่า [PlotArea](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotarea/) จะสงวนพื้นที่ให้กับแถวป้าย หลังจากที่ [ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) คำนวณตำแหน่งเริ่มต้นแล้ว [X](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/x/) และ [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/ilayoutable/y/) จะรักษาการจัดแนวนอนและใช้ค่าออฟเซ็ตแนวตั้งเพื่อจัดแถวป้ายสองแถว ตัวเลขยังคงเป็นป้ายข้อมูลที่เชื่อมโยงกับค่าของซีรีส์; เพียงหัวข้อแถวที่เป็นรูปร่างข้อความแยกต่างหาก  

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
        // ซ่อนคอลัมน์ของ B และ C แต่ยังคงป้ายข้อมูลไว้.
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

// จัดตำแหน่งซีรีส์ทั้งสามให้ตรงกับศูนย์กลางหมวดเดียวกัน.
chart.ChartData.Series[0].ParentSeriesGroup.Overlap = 100;

// ใช้เส้นกริดน้อยลงสำหรับตัวอย่างแบบกระชับนี้.
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.MajorUnit = 10;

// สงวนพื้นที่เหนือกราฟสำหรับแถวป้ายข้อมูลสองแถว.
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
        // รักษาตำแหน่งแนวนอนเริ่มต้นไว้. Y เป็นการออฟเซ็ตจาก
        // ตำแหน่งป้ายเริ่มต้น, แสดงเป็นสัดส่วนของความสูงแผนภูมิ.
        dataLabel.X = 0;
        dataLabel.Y = rowTop - dataLabel.ActualY / chart.Height;
    }

    // เฉพาะหัวแถวเป็นรูปร่างข้อความแยกต่างหาก.
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

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **Change Data Label Shapes**

Aspose.Slides for .NET 26.11 เพิ่ม [IDataLabel.LabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabel/labelshapetype/) สำหรับป้ายเดียวและ [IDataLabelCollection.DefaultLabelShapeType](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelcollection/defaultlabelshapetype/) สำหรับป้ายทั้งหมดในซีรีส์ การเปลี่ยนแปลงนี้จะปรับรูปทรงของป้าย ไม่ใช่เครื่องหมายจุด สำหรับการตั้งค่า callout แยกต่างหาก ดูที่ [Data Label Callouts](/slides/th/net/callout/)

การกำหนดค่าคอลเลกชันจะอัปเดตป้ายที่มีอยู่ ดังนั้นให้นำการตั้งค่าแบบเฉพาะเจาะจงไปใช้ **หลัง** การตั้งค่าคอลเลกชัน ตัวอย่างสมบูรณ์นี้ต้องการ [Aspose.Slides for .NET](/slides/th/net/installation/) 26.11 หรือใหม่กว่า จะสร้างป้ายค่าที่มองเห็นได้ เลือกรูปวงรีสำหรับซีรีส์แรก แล้วทำให้ป้ายแรกของซีรีส์นั้นเป็นสี่เหลี่ยม  

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 350);
var labels = chart.ChartData.Series[0].Labels;
labels.DefaultDataLabelFormat.ShowValue = true;
labels.DefaultLabelShapeType = ShapeType.Ellipse;
labels[0].LabelShapeType = ShapeType.Rectangle;

foreach (var label in labels)
{
    var format = label.DataLabelFormat.Format;
    format.Fill.FillType = FillType.Solid;
    format.Fill.SolidFillColor.Color = Color.LightYellow;
    format.Line.FillFormat.FillType = FillType.Solid;
    format.Line.FillFormat.SolidFillColor.Color = Color.DarkBlue;
}

presentation.Save("label-shapes.pptx", SaveFormat.Pptx);

// รีเซ็ตการเลือกรูปทรงที่กำหนดไว้ล่วงหน้าสำหรับป้ายทั้งหมดที่มีอยู่.
labels.DefaultLabelShapeType = ShapeType.NotDefined;
presentation.Save("label-shapes-reset.pptx", SaveFormat.Pptx);
```

การกำหนดรูปทรงคอลเลกชันอีกครั้งจะทับการเลือกรูปทรงแบบเดิม [NotDefined](https://reference.aspose.com/slides/net/aspose.slides/shapetype/) จะล้างการเลือกรูปทรงโดยเจาะจง; ไม่ได้ทำให้ป้ายหายหรือเคลียร์การจัดรูปแบบอื่น ๆ ตั้งค่ารูปทรงที่ต้องการหลังจากเติมข้อมูลซีรีส์แทนการคาดการณ์ว่าจุดที่เพิ่มภายหลังจะสืบรับการตั้งค่าก่อนหน้า รูปสี่เหลี่ยมและวงรีถูกใช้ที่นี่; ตรวจสอบผลลัพธ์ที่เรนเดอร์เมื่อเลือกประเภทรูปทรงอื่น

## **FAQ**

**How can I prevent data labels from overlapping on dense charts?**

ผสานการจัดวางป้ายอัตโนมัติ, เส้นเชื่อม, และการลดขนาดฟอนต์; หากจำเป็นให้ซ่อนฟิลด์บางส่วน (เช่น หมวด) หรือแสดงป้ายเฉพาะค่าข extremos หรือจุดสำคัญ

**How can I disable labels only for zero, negative, or empty values?**

กรองจุดข้อมูลก่อนเปิดป้ายและปิดการแสดงค่าที่เป็น 0, ค่าติดลบ, หรือค่าที่ขาดหายตามกฎที่กำหนด

**How can I ensure a consistent label style when exporting to PDF/images?**

กำหนดฟอนต์และขนาดอย่างชัดเจนและตรวจสอบว่าฟอนต์นั้นมีอยู่ในสภาพแวดล้อมการเรนเดอร์เพื่อหลีกเลี่ยงการใช้ฟอนต์สำรอง