---
title: สร้างหรืออัปเดตแผนภูมิการนำเสนอ PowerPoint ใน .NET
linktitle: สร้างหรืออัปเดตแผนภูมิ
type: docs
weight: 10
url: /th/net/create-chart/
keywords:
- เพิ่มแผนภูมิ
- สร้างแผนภูมิ
- แก้ไขแผนภูมิ
- เปลี่ยนแผนภูมิ
- อัปเดตแผนภูมิ
- แผนภูมิกระจาย
- แผนภูมิวงกลม
- แผนภูมิเส้น
- แผนภูมิแผนที่ต้นไม้
- แผนภูมิหุ้น
- แผนภูมิกล่องและหนวด
- แผนภูมิกรวย
- แผนภูมิดวงอาทิตย์
- แผนภูมิฮิสโตแกรม
- แผนภูมิกระจุก
- แผนภูมิหลายหมวด
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในการนำเสนอ PowerPoint ด้วย Aspose.Slides สำหรับ .NET. เพิ่ม, จัดรูปแบบ, และแก้ไขแผนภูมิด้วยตัวอย่างโค้ดที่ใช้งานได้จริงใน C#."
---
## **ภาพรวม**

บทความนี้ให้คำแนะนำอย่างละเอียดเกี่ยวกับการสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides for .NET คุณจะได้เรียนรู้วิธีการเพิ่มแผนภูมิลงในสไลด์ด้วยโค้ด, เติมข้อมูลเข้าไป, และใช้ตัวเลือกการจัดรูปแบบต่าง ๆ เพื่อให้ตรงกับความต้องการในการออกแบบของคุณThroughout the article, detailed code examples illustrate each step, from initializing the presentation and chart object to configuring series, axes, and legends. By following this guide, you'll gain a solid understanding of how to integrate dynamic chart generation into your .NET applications, streamlining the process of creating data-driven presentations.

## **สร้างแผนภูมิ**

แผนภูมิช่วยให้ผู้ใช้งานมองเห็นข้อมูลได้อย่างรวดเร็วและสังเกตแนวคิดที่อาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

การใช้แผนภูมิ คุณสามารถ:

* รวม, ย่อ, หรือสรุปข้อมูลจำนวนมากในสไลด์เดียว;
* เปิดเผยรูปแบบและแนวโน้มของข้อมูล;
* สรุปทิศทางและโมเมนตัมของข้อมูลตามเวลา หรือหน่วยวัดที่ระบุ;
* พบค่าผิดปกติ, ความเบียดเส้น, ความเบี่ยงเบน, ข้อผิดพลาด, และข้อมูลที่ไม่มีเหตุผล;
* สื่อสารหรืออธิบายข้อมูลที่ซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิผ่านฟังก์ชัน *Insert* ซึ่งมีเทมเพลตให้เลือกออกแบบหลายประเภท ด้วย Aspose.Slides คุณสามารถสร้างแผนภูมิปกติ (ตามประเภทแผนภูมิยอดนิยม) และแผนภูมิที่กำหนดเองได้

{{% alert color="info" title="Note" %}}
ใช้ enumeration [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) ภายใต้เนมสเปซ [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/) ค่าต่าง ๆ ใน enumeration นี้สอดคล้องกับประเภทแผนภูมิที่แตกต่างกัน
{{% /alert %}}

### **สร้าง Clustered Column Charts**

ตัวอย่างนี้ใช้ [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) เพื่อสร้าง clustered column chart ที่เปรียบเทียบสอง series ผ่านสามประเภท โดย series ใช้สีเติมสีแดงและสีเขียว และป้ายกำกับแสดงชื่อประเภท, ชื่อ series, และค่า ดัชนี Worksheet 0 หมายถึงชีตแรกใน workbook ของแผนภูมิที่ฝังอยู่

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series[0];

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;

series = chart.ChartData.Series[1];

valueCell = workbook.GetCell(worksheetIndex, 1, 2, 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 2, 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 2, 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);

series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;

var label = series.DataPoints[0].Label;
label.DataLabelFormat.ShowCategoryName = true;

label = series.DataPoints[1].Label;
label.DataLabelFormat.ShowSeriesName = true;

label = series.DataPoints[2].Label;
label.DataLabelFormat.ShowValue = true;
label.DataLabelFormat.ShowSeriesName = true;
label.DataLabelFormat.Separator = "/";

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![The Clustered Column chart](clustered_column_chart.png)

### **สร้าง Scatter Charts**

Scatter charts (หรือ scatter plots, x‑y graphs) มักใช้เพื่อตรวจสอบรูปแบบหรือแสดงความสัมพันธ์ระหว่างสองตัวแปร

ใช้ scatter chart เมื่อต้องการ:

* มีข้อมูลตัวเลขเป็นคู่
* มีสองตัวแปรที่สัมพันธ์กันดี
* ต้องการตรวจสอบว่าตัวแปรสองตัวมีความสัมพันธ์หรือไม่
* มีตัวแปรอิสระที่มีค่าหลายค่าเพื่อกำหนดค่าตัวแปรตาม

ตัวอย่างนี้พล็อตค่าชุด x‑y สองชุด ชุดแรกใช้เส้นตรงกับ marker รูปดาว, ชุดที่สองใช้เส้นสมูทกับ marker รูปวงกลม; ทั้งสองใช้ [Size](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/size/) = 10. คุณสมบัติ [Symbol](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/symbol/) ควบคุมรูปแบบ marker

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, 1, 1, "Series 1");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);
seriesNameCell = workbook.GetCell(worksheetIndex, 1, 3, "Series 2");
chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var series = chart.ChartData.Series[0];

var xValueCell = workbook.GetCell(worksheetIndex, 2, 1, 1);
var yValueCell = workbook.GetCell(worksheetIndex, 2, 2, 3);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 1, 2);
yValueCell = workbook.GetCell(worksheetIndex, 3, 2, 10);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

series = chart.ChartData.Series[1];

xValueCell = workbook.GetCell(worksheetIndex, 2, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 2, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 3, 3, 3);
yValueCell = workbook.GetCell(worksheetIndex, 3, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 4, 3, 2);
yValueCell = workbook.GetCell(worksheetIndex, 4, 4, 2);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

xValueCell = workbook.GetCell(worksheetIndex, 5, 3, 5);
yValueCell = workbook.GetCell(worksheetIndex, 5, 4, 1);
series.DataPoints.AddDataPointForScatterSeries(xValueCell, yValueCell);

series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![The Scatter chart](scatter_chart.png)

### **สร้าง Pie Charts**

Pie charts เหมาะสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนของข้อมูล โดยเฉพาะเมื่อข้อมูลมีป้ายกำกับประเภทพร้อมค่าตัวเลข อย่างไรก็ตาม หากข้อมูลมีหลายส่วนหรือหลายป้ายกำกับ ควรพิจารณาใช้ bar chart แทน

ตัวอย่างนี้สร้าง pie chart ที่มีค่าครึ่งไตรมาสสามค่า แต่ละสไลซ์มีการเติมสีและขอบแบบกำหนดเอง, ป้ายแสดงค่าต่าง ๆ, ร้อยละ, และข้อมูล series. คุณสมบัติ [FirstSliceAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/firstsliceangle/) ตั้งให้สไลซ์แรกเริ่มที่ 180 องศา

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var categoryCell = workbook.GetCell(0, 1, 0, "1st Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "2nd Qtr");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "3rd Qtr");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 20);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 2, 1, 50);
series.DataPoints.AddDataPointForPieSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, 3, 1, 30);
series.DataPoints.AddDataPointForPieSeries(valueCell);

chart.ChartData.SeriesGroups[0].IsColorVaried = true;

var firstSlice = series.DataPoints[0];
firstSlice.Format.Fill.FillType = FillType.Solid;
firstSlice.Format.Fill.SolidFillColor.Color = Color.Cyan;

firstSlice.Format.Line.FillFormat.FillType = FillType.Solid;
firstSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
firstSlice.Format.Line.Width = 3.0;
firstSlice.Format.Line.Style = LineStyle.ThinThick;
firstSlice.Format.Line.DashStyle = LineDashStyle.LargeDash;

var secondSlice = series.DataPoints[1];
secondSlice.Format.Fill.FillType = FillType.Solid;
secondSlice.Format.Fill.SolidFillColor.Color = Color.Brown;

secondSlice.Format.Line.FillFormat.FillType = FillType.Solid;
secondSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
secondSlice.Format.Line.Width = 3.0;
secondSlice.Format.Line.Style = LineStyle.Single;
secondSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

var thirdSlice = series.DataPoints[2];
thirdSlice.Format.Fill.FillType = FillType.Solid;
thirdSlice.Format.Fill.SolidFillColor.Color = Color.Coral;

thirdSlice.Format.Line.FillFormat.FillType = FillType.Solid;
thirdSlice.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
thirdSlice.Format.Line.Width = 2.0;
thirdSlice.Format.Line.Style = LineStyle.ThinThin;
thirdSlice.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

var firstLabel = series.DataPoints[0].Label;
firstLabel.DataLabelFormat.ShowValue = true;

var secondLabel = series.DataPoints[1].Label;
secondLabel.DataLabelFormat.ShowValue = true;
secondLabel.DataLabelFormat.ShowLegendKey = true;
secondLabel.DataLabelFormat.ShowPercentage = true;

var thirdLabel = series.DataPoints[2].Label;
thirdLabel.DataLabelFormat.ShowSeriesName = true;
thirdLabel.DataLabelFormat.ShowPercentage = true;

series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

presentation.Save("PieChart.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![The Pie chart](pie_chart.png)

เพื่อทำให้ป้ายที่อยู่ด้านนอก pie อ่านง่ายขึ้น ดูตัวอย่าง [Format Leader Lines](/slides/th/net/chart-data-label/#format-leader-lines) ที่อธิบายการจัดตำแหน่งป้ายและการปรับสี, ความกว้าง, ความโปร่งใส, และสไตล์ของเส้นเชื่อม

### **สร้าง Line Charts**

Line charts (หรือ line graphs) เหมาะกับสถานการณ์ที่ต้องการแสดงการเปลี่ยนแปลงของค่าในช่วงเวลา การใช้ line chart คุณสามารถเปรียบเทียบข้อมูลจำนวนมากในคราวเดียว, ติดตามการเปลี่ยนแปลงและแนวโน้ม, ไฮไลท์ความผิดปกติของ series ฯลฯ

ตัวอย่างนี้ใช้ [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) เพื่อสร้าง line chart ด้วย series และ categories เริ่มต้น, แล้วบันทึกเป็น PPTX

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

presentation.Save("lineChart.pptx", SaveFormat.Pptx);
```

โดยปกติ จุดบน line chart จะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากต้องการให้เชื่อมด้วยเส้นขีด ใหตั้งค่า [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) เป็นค่าจาก [LineDashStyle](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/)

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

foreach (var series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

ผลลัพธ์:

![The Line chart](line_chart.png)

### **สร้าง Tree Map Charts**

Tree map charts เหมาะกับข้อมูลการขายเมื่อคุณต้องการแสดงขนาดสัมพัทธ์ของหมวดหมู่ข้อมูลและดึงความสนใจไปที่รายการที่มีส่วนแบ่งสูงในแต่ละหมวด

ตัวอย่างนี้สร้าง tree map ที่มีใบแปดใบจัดเป็นสี่ stem และสอง branch. วิธี [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) กำหนด stem ที่ระดับการจัดกลุ่ม 1 และ branch ที่ระดับ 2 ค่าใช้ในการกำหนดขนาดสี่เหลี่ยมสัมพัทธ์, ป้ายหมวดและป้ายพาเรนท์ที่ทับซ้อนบ่งบอกลำดับชั้น

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// สาขา 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// สาขา 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Treemap);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForTreemapSeries(valueCell);

series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

presentation.Save("Treemap.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![The Treemap chart](treemap_chart.png)

### **สร้าง Waterfall Charts**

Waterfall chart แสดงว่าการเปลี่ยนแปลงบวกและลบมีผลต่อค่าขั้นสุดท้ายอย่างไร ตัวอย่างเช่น การสรุปกำไรอาจเริ่มจากรายได้, ลบต้นทุน, เพิ่มรายได้อื่น ๆ คอลัมน์การเปลี่ยนแปลงลอยระหว่างค่าก่อนหน้าและค่าปัจจุบัน, ส่วนคอลัมน์รวมต่อจากศูนย์ถึงค่าที่สะสม

ตัวอย่างต่อไปใช้จำนวนในหน่วยพันดอลลาร์สหรัฐ:

| Category | Workbook value | Column type |
| --- | ---: | --- |
| Revenue | 1000 | Increase |
| Cost of sales | -400 | Decrease |
| Gross profit | 600 | Intermediate total |
| Operating expenses | -200 | Decrease |
| Other income | 50 | Increase |
| Net profit | 450 | Final total |

เพื่อทำให้จุดเป็น intermediate หรือ final total ให้ตั้งคุณสมบัติ [SetAsTotal](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatapoint/setastotal/) เป็น `true` และใส่จำนวนที่สะสมจริงในเซลล์ workbook ของจุดนั้น: `600` สำหรับ gross profit (`1000 - 400`) และ `450` สำหรับ net profit (`600 - 200 + 50`). คุณสมบัตินี้ทำเครื่องหมายคอลัมน์ว่าเป็น total; ไม่ได้คำนวณหรือเติมค่าเซลล์ อย่าใช้ศูนย์เป็น placeholder หรือใส่การเปลี่ยนแปลงอื่นสำหรับจุด total. คอลัมน์ total จะแสดงค่าที่สะสมโดยไม่เพิ่มอีกครั้งในค่ารันนิ่ง

ตัวอย่าง C# นี้สร้างแผนภูมิด้วยสมาชิก `Waterfall` ของ [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/), ล้างข้อมูลเริ่มต้น, แล้วเติม workbook ที่ฝังอยู่ ดัชนี Worksheet `0` เลือกชีตแรก; คอลัมน์ A มีชื่อประเภท, คอลัมน์ B มีค่า แต่ละเซลล์ค่าถูกเพิ่มด้วย [AddDataPointForWaterfallSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/adddatapointforwaterfallseries/). ดัชนีจุดฐานศูนย์ `2` และ `5` ระบุ total ระหว่างและสุดท้าย การเปิดใช้ [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) แสดงจำนวนบนคอลัมน์ ไม่จำเป็นต้องมี presentation หรือ workbook อินพุต

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Waterfall, 20, 20, 680, 200);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("Profit breakdown (USD thousands)");
chart.ChartTitle.Overlay = false;
chart.HasLegend = false;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;

workbook.Clear(worksheetIndex);

var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Profit");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Waterfall);
var categories = new[] { "Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit" };
var values = new double[] { 1000, -400, 600, -200, 50, 450 };

for (var i = 0; i < categories.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categories[i]);
    chart.ChartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForWaterfallSeries(valueCell);
}

// จุดที่สามและจุดที่หกเป็นยอดรวม ไม่ใช่การเปลี่ยนแปลงเพิ่มเติม.
series.DataPoints[2].SetAsTotal = true;
series.DataPoints[5].SetAsTotal = true;
series.ShowConnectorLines = true;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("WaterfallChart.pptx", SaveFormat.Pptx);
```

ตั้งคุณสมบัติ series‑level [ShowConnectorLines](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/showconnectorlines/) เป็น `true` เพื่อแสดงเส้นเชื่อมคอลัมน์ต่อเนื่องและทำให้ค่ารันนิ่งติดตามง่ายขึ้น หากต้องการซ่อนเส้นเหล่านี้ให้แทนที่การกำหนดในตัวอย่างด้วย `series.ShowConnectorLines = false;` ก่อนบันทึก การเปลี่ยนแปลงนี้มีผลต่อการมองเห็นเส้นเท่านั้น ไม่กระทบต่อข้อมูลหรือ total

Presentation ที่บันทึกแสดง gross profit 600 และ net profit 450, ทั้งสอง total เริ่มจากศูนย์:

![Waterfall chart showing revenue, costs, gross profit of 600, and net profit of 450, with value labels and connector lines](waterfall_chart.png)

### **สร้าง Stock Charts**

Stock charts ใช้แสดงข้อมูลการเงินเช่นราคาเปิด, สูง, ต่ำ, ปิด เพื่อช่วยวิเคราะห์แนวโน้มและความผันผวนของตลาด พวกมันให้ข้อมูลเชิงลึกสำคัญเกี่ยวกับประสิทธิภาพหุ้น ช่วยนักลงทุนและนักวิเคราะห์ทำการตัดสินใจ

ตัวอย่างนี้สร้าง open‑high‑low‑close chart ที่มีสี่ series ตามลำดับและสามประเภท คุณสมบัติ [HasUpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/hasupdownbars/) เปิดใช้งานแถบขึ้น/ลง, และ [HiLowLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hilowlinesformat/) ควบคุมเส้น high‑low ที่แสดงช่วงราคา, ขณะเดียวกันเส้น series แต่ละตัวและเส้นกริดแนวนอนรองถูกซ่อนไว้

[UpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/updownbars/) manager มีวัตถุ [UpBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/upbarsformat/) และ [DownBarsFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/downbarsformat/) แยกกัน ใช้คุณสมบัติ [Fill](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/fill/) และ [Line](https://reference.aspose.com/slides/net/aspose.slides.charts/iformat/line/) ของแต่ละวัตถุตั้งสีเติมและเส้นขอบอย่างอิสระ ตัวอย่างนี้ใช้แถบสีเขียวกับขอบเขียวเข้มสำหรับช่วงที่ขึ้น, และแถบสีส้ม‑แดงกับขอบแดงเข้มสำหรับช่วงที่ลง

ใส่ค่าตัวเลขให้กับสี่ series ทุกประเภท, โดย High และ Low ล้อมรอบ Open และ Close. แถบเปรียบเทียบ Close กับ Open **ภายในประเภทเดียวกัน**, ไม่ใช่กับประเภทก่อนหน้า: A ลดจาก 72 เหลือ 25, B เพิ่มจาก 25 เหลือ 38, C เพิ่มจาก 38 เหลือ 50. หาก Open และ Close เท่ากัน จะไม่มีช่วงที่เติมสีแสดงขึ้น. แถบ up/down ครอบ Open‑Close; เส้น high‑low ครอบ Low‑High. แถบเหล่านี้เป็นส่วนของ series group ไม่ใช่ series ของแผนภูมิแท่งธรรมดา

รูปแบบนี้ทำงานกับแผนภูมิ [Line and LineWithMarkers](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) ที่มีอย่างน้อยสอง series ในกลุ่มเดียวกันและค่าตัวเลขที่สอดคล้องกันสำหรับแต่ละประเภท. สำหรับ line chart ที่ไม่ stacked, แถบ up/down จะเปรียบเทียบ series แรกและสุดท้าย: ค่าตัวสุดท้ายสูงกว่าจะให้แถบ up, ค่าตัวสุดท้ายต่ำกว่าจะให้แถบ down. การสลับ series จะสลับการจัดประเภท. ตัวอย่างด้านล่างใช้ [OpenHighLowClose](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/); อย่าสมมติว่า stock, stacked‑line, หรือ 3D รุ่นอื่นใช้โครงสร้างข้อมูลหรือการตีความช่วงเดียวกัน

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 150, false);

var workbook = chart.ChartData.ChartDataWorkbook;

var categoryCell = workbook.GetCell(0, 1, 0, "A");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 2, 0, "B");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, 3, 0, "C");
chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, 0, 1, "Open");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 2, "High");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 3, "Low");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);
seriesNameCell = workbook.GetCell(0, 0, 4, "Close");
chart.ChartData.Series.Add(seriesNameCell, ChartType.OpenHighLowClose);

var series = chart.ChartData.Series[0];
var valueCell = workbook.GetCell(0, 1, 1, 72);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 1, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 1, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[1];
valueCell = workbook.GetCell(0, 1, 2, 172);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 57);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[2];
valueCell = workbook.GetCell(0, 1, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 3, 12);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 3, 13);
series.DataPoints.AddDataPointForStockSeries(valueCell);

series = chart.ChartData.Series[3];
valueCell = workbook.GetCell(0, 1, 4, 25);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 4, 38);
series.DataPoints.AddDataPointForStockSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 4, 50);
series.DataPoints.AddDataPointForStockSeries(valueCell);

var upDownBars = chart.ChartData.SeriesGroups[0].UpDownBars;
upDownBars.HasUpDownBars = true;

upDownBars.UpBarsFormat.Fill.FillType = FillType.Solid;
upDownBars.UpBarsFormat.Fill.SolidFillColor.Color = Color.LimeGreen;
upDownBars.UpBarsFormat.Line.FillFormat.FillType = FillType.Solid;
upDownBars.UpBarsFormat.Line.FillFormat.SolidFillColor.Color = Color.DarkGreen;
upDownBars.UpBarsFormat.Line.Width = 2;

upDownBars.DownBarsFormat.Fill.FillType = FillType.Solid;
upDownBars.DownBarsFormat.Fill.SolidFillColor.Color = Color.OrangeRed;
upDownBars.DownBarsFormat.Line.FillFormat.FillType = FillType.Solid;
upDownBars.DownBarsFormat.Line.FillFormat.SolidFillColor.Color = Color.DarkRed;
upDownBars.DownBarsFormat.Line.Width = 2;

chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

foreach (var stockSeries in chart.ChartData.Series)
{
    stockSeries.Format.Line.FillFormat.FillType = FillType.NoFill;
}

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
```

ผลลัพธ์ที่ส่งออกจาก PowerPoint:

![Stock chart with an orange-red falling interval for A and green rising intervals for B and C](stock_chart.png)

### **สร้าง Box and Whisker Charts**

Box and whisker charts ใช้แสดงการกระจายของข้อมูลโดยสรุปมาตรการสถิติสำคัญ เช่น ค่า median, quartiles, และ outlier ที่อาจเกิดขึ้น เหมาะสำหรับการวิเคราะห์สำรวจและการศึกษาสถิติ เพื่อทำความเข้าใจความแปรปรวนของข้อมูลและระบุความผิดปกติอย่างรวดเร็ว

ตัวอย่างนี้สร้าง box and whisker chart จากหกค่า. คุณสมบัติ [QuartileMethod](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/quartilemethod/) เลือกการคำนวน quartile แบบ exclusive. ตัวอย่างยังเปิด mean lines, mean markers, inner points, และ outlier points

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

series.QuartileMethod = QuartileMethodType.Exclusive;
series.ShowMeanLine = true;
series.ShowMeanMarkers = true;
series.ShowInnerPoints = true;
series.ShowOutlierPoints = true;

var valueCell = workbook.GetCell(0, "B1", 15);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 41);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 10);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 23);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 16);
series.DataPoints.AddDataPointForBoxAndWhiskerSeries(valueCell);

presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
```

### **สร้าง Funnel Charts**

Funnel charts ใช้แสดงกระบวนการที่มีขั้นตอนต่อเนื่อง โดยปริมาณข้อมูลจะลดลงเมื่อดำเนินการจากขั้นตอนหนึ่งไปยังขั้นตอนต่อไป เหมาะสำหรับการวิเคราะห์อัตราการแปลง, การระบุคอขวด, และการติดตามประสิทธิภาพของกระบวนการขายหรือการตลาด

ตัวอย่างนี้ใช้ [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) เพื่อเพิ่ม funnel chart ไปยังสไลด์แรกของ presentation ที่มีอยู่แล้ว แทนที่ข้อมูลเริ่มต้นด้วยหกประเภทและค่าตั้งแต่ 50 ถึง 500, แล้วบันทึก presentation ที่อัปเดต. Presentation อินพุตต้องมีสไลด์อย่างน้อยหนึ่งสไลด์

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A1", "Category 1");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A2", "Category 2");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A3", "Category 3");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A4", "Category 4");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A5", "Category 5");
chart.ChartData.Categories.Add(categoryCell);
categoryCell = workbook.GetCell(0, "A6", "Category 6");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Funnel);

var valueCell = workbook.GetCell(0, "B1", 50);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B2", 100);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B3", 200);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B4", 300);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B5", 400);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);
valueCell = workbook.GetCell(0, "B6", 500);
series.DataPoints.AddDataPointForFunnelSeries(valueCell);

presentation.Save("Funnel.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![The Funnel chart](funnel_chart.png)

### **สร้าง Sunburst Charts**

Sunburst charts ใช้แสดงข้อมูลเชิงลำดับชั้นเป็นวงแหวนทรงศูนย์กลางหลายระดับ ช่วยอธิบายความสัมพันธ์ส่วนต่อส่วนทั้งหมดและเหมาะกับการแสดงหมวดหมู่และหมวดย่อยที่ซ้อนกันในรูปแบบที่กระชับและชัดเจน

ตัวอย่างนี้สร้าง sunburst chart ที่มีแปดใบจัดเป็นสี่ stem และสอง branch. วิธี [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) กำหนด stem ที่ระดับ 1 และ branch ที่ระดับ 2. ป้ายประเภทบ่งบอกส่วนต่าง ๆ, ค่ากำหนดขนาดสัมพัทธ์ของแต่ละส่วน

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// สาขา 1
var categoryCell = workbook.GetCell(0, "C1", "Leaf1");
var leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

categoryCell = workbook.GetCell(0, "C2", "Leaf2");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C3", "Leaf3");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

categoryCell = workbook.GetCell(0, "C4", "Leaf4");
chart.ChartData.Categories.Add(categoryCell);

// สาขา 2
categoryCell = workbook.GetCell(0, "C5", "Leaf5");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

categoryCell = workbook.GetCell(0, "C6", "Leaf6");
chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "C7", "Leaf7");
leaf = chart.ChartData.Categories.Add(categoryCell);
leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

categoryCell = workbook.GetCell(0, "C8", "Leaf8");
chart.ChartData.Categories.Add(categoryCell);

var series = chart.ChartData.Series.Add(ChartType.Sunburst);
series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
var valueCell = workbook.GetCell(0, "D1", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D2", 5);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D3", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D4", 6);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D5", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D6", 9);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D7", 4);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);
valueCell = workbook.GetCell(0, "D8", 3);
series.DataPoints.AddDataPointForSunburstSeries(valueCell);

presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![The Sunburst chart](sunburst_chart.png)

### **สร้าง Histogram Charts**

Histogram charts แสดงการกระจายของค่าตัวเลขตามช่วง (bins). สำหรับรายงานเดือนเกี่ยวกับเวลาในการประมวลผลคำสั่ง, ใช้ความกว้างของ bin และเกณฑ์เดียวกันเพื่อให้ช่วงสม่ำเสมอและเปรียบเทียบการกระจายได้ง่าย

ตั้งค่าระบบแนวนอน [AggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/aggregationtype/) ให้เป็นโหมดจาก [AxisAggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/axisaggregationtype/). [BinWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/binwidth/) ใช้เฉพาะกับ `ByBinWidth`; [NumberOfBins](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/numberofbins/) ใช้เฉพาะกับ `ByNumberOfBins`. ใช้ `Automatic` ให้แผนภูมิตัดสินใจเลือก bin เอง

#### **ใช้ Bin Width คงที่**

ตัวอย่างนี้จัดกลุ่มเวลาในการประมวลผลเป็นช่วง 10 นาที, มี bin แยกสำหรับ ≤10 นาทีและ >40 นาที เปิดใช้ bin เหล่านี้ด้วย [IsUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isunderflowbin/) และ [IsOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isoverflowbin/). เมื่อกำหนด thresholds ด้วย [UnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/underflowbin/) และ [OverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/overflowbin/), ตั้ง [IsAutomaticUnderflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticunderflowbin/) และ [IsAutomaticOverflowBin](https://reference.aspose.com/slides/net/aspose.slides.charts/axis/isautomaticoverflowbin/) เป็น `false`

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByBinWidth;
axis.BinWidth = 10;
axis.IsUnderflowBin = true;
axis.IsAutomaticUnderflowBin = false;
axis.UnderflowBin = 10;
axis.IsOverflowBin = true;
axis.IsAutomaticOverflowBin = false;
axis.OverflowBin = 40;

presentation.Save("Histogram-bin-width.pptx", SaveFormat.Pptx);
```

Presentation ใน PowerPoint แสดงจำนวนในแต่ละ bin **3, 4, 4, 4, และ 2**. Bin underflow มีค่า `5, 10, 10` ดังนั้นเกณฑ์รวมถึงค่าเหล่านั้น. Bin overflow มีค่า `41, 50` ดังนั้นเกณฑ์ไม่รวมค่าเหล่านั้น; ค่า `40` อยู่ใน bin ก่อนหน้า. Bin ภายในมีค่ามากกว่าขอบล่างและไม่เกินขอบบน

![Histogram with 10-minute bins and explicit underflow and overflow thresholds](histogram_bin_width.png)

#### **ระบุจำนวน Bin**

เพื่อให้ระดับรายละเอียดคงที่แทนการกำหนดช่วงคงที่, ขอ 5 bin สำหรับข้อมูลเดียวกัน ตัวอย่างนี้ปิดการใช้งาน bin underflow และ overflow. แผนภูมิคำนวณความกว้างจากช่วงข้อมูล, ดังนั้นขอบเขตอาจเปลี่ยนระหว่างรายงาน

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 680, 200);

chart.HasLegend = false;
chart.HasTitle = false;

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
double[] values = { 5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50 };
for (var i = 0; i < values.Length; i++)
{
    var valueCell = workbook.GetCell(0, i, 0, values[i]);
    series.DataPoints.AddDataPointForHistogramSeries(valueCell);
}

var axis = chart.Axes.HorizontalAxis;
axis.AggregationType = AxisAggregationType.ByNumberOfBins;
axis.NumberOfBins = 5;

presentation.Save("Histogram-bin-count.pptx", SaveFormat.Pptx);
```

ห้าค่า bin มีจำนวน **4, 4, 4, 4, และ 1**. เปรียบเทียบการกระจายนี้กับผลลัพธ์ความกว้างคงที่ด้านบน: ค่าต่าง ๆ เหมือนกัน แต่ขอบเขตต่างกัน

![Histogram with five bins calculated from the same data](histogram_bin_count.png)

### **สร้าง Radar Charts**

Radar charts ใช้แสดงข้อมูลหลายมิติในรูปแบบสองมิติ, ทำให้เปรียบเทียบหลายตัวแปรพร้อมกันได้ง่าย. เหมาะสำหรับระบุรูปแบบ, จุดแข็ง, และจุดอ่อนของเมตริกหรือคุณสมบัติหลายประการ

ตัวอย่างนี้ใช้ [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) เพื่อสร้าง radar chart ด้วย series และ categories เริ่มต้น, แล้วบันทึกเป็น PPTX

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);

presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![The Radar chart](radar_chart.png)

### **สร้าง Multi-Category Charts**

Multi-category charts ใช้แสดงข้อมูลที่มีการจัดกลุ่มประเภทหลายระดับพร้อมกัน, ช่วยเปรียบเทียบค่าข้ามมิติต่าง ๆ ได้พร้อมกัน. มีประโยชน์เมื่อจำเป็นต้องวิเคราะห์แนวโน้มและความสัมพันธ์ในชุดข้อมูลหลายชั้น

ตัวอย่างนี้สร้าง clustered column chart ที่มีแปดประเภทจัดเป็นสี่คู่. วิธี [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) ให้แต่ละคู่มีป้ายร่วมที่ระดับการจัดกลุ่ม 1, ทำให้แกนประเภทมีป้ายปัจเจกและป้ายกลุ่มร่วม

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var worksheetIndex = 0;

var categoryCell = workbook.GetCell(0, "c2", "A");
var category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group1");
categoryCell = workbook.GetCell(0, "c3", "B");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c4", "C");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group2");
categoryCell = workbook.GetCell(0, "c5", "D");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c6", "E");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group3");
categoryCell = workbook.GetCell(0, "c7", "F");
category = chart.ChartData.Categories.Add(categoryCell);

categoryCell = workbook.GetCell(0, "c8", "G");
category = chart.ChartData.Categories.Add(categoryCell);
category.GroupingLevels.SetGroupingItem(1, "Group4");
categoryCell = workbook.GetCell(0, "c9", "H");
category = chart.ChartData.Categories.Add(categoryCell);

var seriesNameCell = workbook.GetCell(0, "D1", "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

var valueCell = workbook.GetCell(worksheetIndex, "D2", 10);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D3", 20);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D4", 30);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D5", 40);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D6", 50);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D7", 60);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D8", 70);
series.DataPoints.AddDataPointForBarSeries(valueCell);
valueCell = workbook.GetCell(worksheetIndex, "D9", 80);
series.DataPoints.AddDataPointForBarSeries(valueCell);

presentation.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![The multi category chart](multi_category_chart.png)

#### **ลบป้ายไตรมาส**

ดาวน์โหลด [quarters.pptx](quarters.pptx) แล้ววางในไดเรกทอรีทำงาน. แผนภูมิโดยมันแสดง 9 เดือนและ series การขายหนึ่ง series ค่า 10‑18. แกนประเภทมีป้ายไตรมาสสามอัน: Q1 ครอบ Jan–Mar, Q2 ครอบ Apr–Jun, Q3 ครอบ Jul–Sep.

เดือนเมษายนคือประเภทที่สี่และเป็นที่ที่ตั้งค่า Q2 ไว้อย่างชัดเจน. เรียกใช้ [DeleteGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/deletegroupingitem/) บนคอลเล็กชัน [GroupingLevels](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/groupinglevels/) ของเดือนเมษายน. ระดับสัมพันธ์กับเมษายน: ระดับ 1 คือไตรมาส, ระดับ 0 คือเดือนเอง. เมธอดไม่สามารถลบ leaf category ที่ระดับ 0 ได้

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using (var presentation = new Presentation("quarters.pptx"))
{
    var chart = (IChart)presentation.Slides[0].Shapes[0];
    var april = chart.ChartData.Categories[3];
    april.GroupingLevels.DeleteGroupingItem(1);

    presentation.Save("quarters-updated.pptx", SaveFormat.Pptx);
}

using var reopened = new Presentation("quarters-updated.pptx");
var updatedChart = (IChart)reopened.Slides[0].Shapes[0];
var data = updatedChart.ChartData;

Console.WriteLine(string.Join(", ", data.Categories.Select(month => month.AsCell.Value)));
Console.WriteLine(string.Join(", ", data.Series[0].DataPoints.Select(point => point.Value.Data)));
```

แผนภูมิที่เปิดใหม่พิมพ์เดือนเดิม (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) และค่าการขาย (`10, 11, 12, 13, 14, 15, 16, 17, 18`) ตามลำดับเดิม. เปิด `quarters-updated.pptx` ใน PowerPoint เพื่อตรวจสอบการเปรียบเทียบป้ายแกน. ป้าย Q2 และเส้นแบ่งกลุ่มก่อนเดือนเมษายนหายไป, ดังนั้น Q1 ครอบ Jan‑Jun. Q3 ยังคงเริ่มต้นในเดือนกรกฎาคม

![Quarter labels before and after removal. On the left, Q2 spans April through June. On the right, Q1 spans January through June.](quarter-label-comparison.png)

### **สร้าง Map Charts**

Map charts ใช้แสดงข้อมูลภูมิศาสตร์โดยแมปข้อมูลไปยังตำแหน่งเฉพาะเช่น ประเทศ, รัฐ, หรือเมือง เหมาะสำหรับวิเคราะห์แนวโน้มภูมิภาค, ข้อมูลประชากร, และการกระจายเชิงพื้นที่ในรูปแบบที่ชัดเจนและดึงดูดสายตา

ตัวอย่างนี้ใช้ [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) เพื่อสร้าง map chart ด้วยข้อมูลภูมิศาสตร์เริ่มต้น แล้วบันทึกเพื่อดูใน PowerPoint

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);

presentation.Save("mapChart.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![The Map chart](map_chart.png)

{{% alert color="info" title="Note" %}}
รูปภาพด้านบนแสดง presentation ที่บันทึกแล้วเปิดใน PowerPoint. Aspose.Slides เขียน map chart และข้อมูลได้ถูกต้อง, แต่ไม่ได้วาด map chart ด้วยตัวเอง: เมื่อสไลด์ที่มี map chart ถูกเรนเดอร์เป็นภาพหรือแปลงเป็น PDF หรือ SVG, พื้นที่แผนภูมิจะเป็นสีว่าง. รูปทรงอื่นบนสไลด์เดียวกันไม่มีผลกระทบ
{{% /alert %}}

### **สร้าง Combination Charts**

Combination chart (หรือ combo chart) ผสานสองหรือหลายประเภทแผนภูมิไว้ในกราฟเดียว ช่วยให้คุณไฮไลท์, เปรียบเทียบ, หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลหลายชุด, ช่วยระบุความสัมพันธ์ระหว่างข้อมูลเหล่านั้น

![The combination chart](combination_chart.png)

ตัวอย่างนี้ผสานสอง series ของ clustered column กับ series ของ line ในสี่ประเภท. คอลัมน์ใช้แกนแนวตั้งหลัก, ส่วน [PlotOnSecondAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/plotonsecondaxis/) วาง line บนแกนแนวตั้งรองขวา. ฟังก์ชันช่วยตั้งชื่อ, legend, ป้ายแกน, และเส้นกริด

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

CreateComboChart();

static void CreateComboChart()
{
    using var presentation = new Presentation();
    var chart = CreateChartWithFirstSeries(presentation.Slides[0]);

    AddSecondSeriesToChart(chart);
    AddThirdSeriesToChart(chart);

    SetPrimaryAxesFormat(chart);
    SetSecondaryAxesFormat(chart);

    presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
}

static IChart CreateChartWithFirstSeries(ISlide slide)
{
    var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    var portionFormat = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    var worksheetIndex = 0;

    var categoryCell = workbook.GetCell(worksheetIndex, 1, 0, "Category 1");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 2, 0, "Category 2");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 3, 0, "Category 3");
    chart.ChartData.Categories.Add(categoryCell);
    categoryCell = workbook.GetCell(worksheetIndex, 4, 0, "Category 4");
    chart.ChartData.Categories.Add(categoryCell);

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
    var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 1, 4.3);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 1, 2.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 1, 3.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 1, 4.5);
    series.DataPoints.AddDataPointForBarSeries(valueCell);

    return chart;
}

static void AddSecondSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 2, "Series 2");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    var valueCell = workbook.GetCell(worksheetIndex, 1, 2, 2.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 2, 4.4);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 2, 1.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 2, 2.8);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

static void AddThirdSeriesToChart(IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
    var series = chart.ChartData.Series.Add(seriesNameCell, ChartType.Line);

    var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 2, 3, 2.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 3, 3, 3.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
    valueCell = workbook.GetCell(worksheetIndex, 4, 3, 5.0);
    series.DataPoints.AddDataPointForLineSeries(valueCell);

    series.PlotOnSecondAxis = true;
}

static void SetPrimaryAxesFormat(IChart chart)
{
    var horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    var verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    var majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

static void SetSecondaryAxesFormat(IChart chart)
{
    var secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    var secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    var titlePortionFormat = axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **อัปเดตแผนภูมิ**

Aspose.Slides for .NET ช่วยให้คุณอัปเดตแผนภูมิ PowerPoint โดยแก้ไขข้อมูลแผนภูมิ, การจัดรูปแบบ, และสไตล์ สิ่งนี้ทำให้การรักษา presentation ให้ทันสมัยด้วยเนื้อหาไดนามิกง่ายขึ้นและรับประกันว่าแผนภูมิสะท้อนข้อมูลและมาตรฐานการออกแบบปัจจุบันอย่างแม่นยำ

ตัวอย่างนี้อัปเดตแผนภูมิชื่อ "My chart" บนสไลด์แรกของ presentation ที่มีอยู่แล้ว ต้องมี series คอลัมน์สอง series, แต่ละ series มีจุดข้อมูลสามจุด, ป้ายประเภทอยู่ในคอลัมน์ A และชื่อ series อยู่ในแถวแรกของ worksheet แรก ตัวอย่างใช้ [GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) เพื่อเปลี่ยนค่า workbook, อัปเดตค่าของ series, เพิ่ม series ที่สาม, และเปลี่ยนแผนภูมิเป็น clustered cylinders ผ่าน [Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/type/)

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        var worksheetIndex = 0;

        var workbook = chart.ChartData.ChartDataWorkbook;

        workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
        workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

        var series = chart.ChartData.Series[0];

        workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1");
        series.DataPoints[0].Value.Data = 90;
        series.DataPoints[1].Value.Data = 123;
        series.DataPoints[2].Value.Data = 44;

        series = chart.ChartData.Series[1];

        workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2");
        series.DataPoints[0].Value.Data = 23;
        series.DataPoints[1].Value.Data = 67;
        series.DataPoints[2].Value.Data = 99;

        var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Series 3");
        series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

        var valueCell = workbook.GetCell(worksheetIndex, 1, 3, 20);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 2, 3, 50);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
        valueCell = workbook.GetCell(worksheetIndex, 3, 3, 30);
        series.DataPoints.AddDataPointForBarSeries(valueCell);

        chart.Type = ChartType.ClusteredCylinder;
    }
}

presentation.Save("AsposeChartModified.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าช่วงข้อมูลสำหรับแผนภูมิ**

เพื่อดูช่วงข้อมูลที่แผนภูมิใช้แล้ว, ดู [Retrieve a Chart's Data Range](/slides/th/net/chart-workbook/#retrieve-a-charts-data-range)

Aspose.Slides for .NET ให้ความยืดหยุ่นในการกำหนดช่วงข้อมูลเฉพาะจาก worksheet เป็นแหล่งข้อมูลของแผนภูมิของคุณ ซึ่งหมายความว่าคุณสามารถแมปส่วนของ worksheet ไปยังแผนภูมิได้โดยตรง, ควบคุมเซลล์ใดบ้างที่มีส่วนร่วมใน series และประเภทของแผนภูมิ ผลคือคุณสามารถอัปเดตและซิงค์แผนภูมิของคุณกับการเปลี่ยนแปลงข้อมูลล่าสุดใน worksheet ได้ง่าย, ทำให้ presentation ของคุณสื่อข้อมูลที่เป็นปัจจุบันและแม่นยำ

ตัวอย่างนี้ใช้ [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) เพื่อตั้งแหล่งข้อมูลของแผนภูมิชื่อ "My chart" บนสไลด์แรกของ presentation ที่มีอยู่เป็น `Sheet1!A1:B4`. workbook ของแผนภูมิต้องมี worksheet นั้นและช่วงที่มีหัว series ในแถวแรก, ป้ายประเภทในคอลัมน์ A, และค่าสามค่าในคอลัมน์ B

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const string chartName = "My chart";

using var presentation = new Presentation("ExistingChart.pptx");
var slide = presentation.Slides[0];

foreach (IShape shape in slide.Shapes)
{
    if (shape is IChart chart && chart.Name == chartName)
    {
        chart.ChartData.SetRange("Sheet1!A1:B4");
    }
}

presentation.Save("SetDataRange.pptx", SaveFormat.Pptx);
```

## **ใช้ Marker เริ่มต้นในแผนภูมิ**

เมื่อใช้ marker เริ่มต้นในแผนภูมิ, แต่ละ series จะได้รับสัญลักษณ์ marker เริ่มต้นที่แตกต่างโดยอัตโนมัติ

ตัวอย่างนี้ใช้ [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) เพื่อสร้างแผนภูมิที่มีสอง series ของ line และ legend. การตั้งค่า [Marker](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/marker/) รักษาสัญลักษณ์ marker ที่กำหนดอัตโนมัติ. series แรกมีค่าลบและค่าที่ขาด (`null`), series ที่สองมีค่าทุกประเภท

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;

var seriesNameCell = workbook.GetCell(0, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

var categoryCell = workbook.GetCell(0, 1, 0, "C1");
chart.ChartData.Categories.Add(categoryCell);
var valueCell = workbook.GetCell(0, 1, 1, 24);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 2, 0, "C2");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 2, 1, 23);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 3, 0, "C3");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 3, 1, -10);
series.DataPoints.AddDataPointForLineSeries(valueCell);

categoryCell = workbook.GetCell(0, 4, 0, "C4");
chart.ChartData.Categories.Add(categoryCell);
valueCell = workbook.GetCell(0, 4, 1, null);
series.DataPoints.AddDataPointForLineSeries(valueCell);

seriesNameCell = workbook.GetCell(0, 0, 2, "Series 2");
var secondSeries = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

valueCell = workbook.GetCell(0, 1, 2, 30);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 2, 2, 10);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 3, 2, 60);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);
valueCell = workbook.GetCell(0, 4, 2, 40);
secondSeries.DataPoints.AddDataPointForLineSeries(valueCell);

chart.HasLegend = true;
chart.Legend.Overlay = false;

presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Aspose.Slides for .NET รองรับประเภทแผนภูมิใดบ้าง?**

Aspose.Slides for .NET รองรับแผนภูมิกว้างหลายประเภท รวมถึง bar, line, pie, area, scatter, histogram, radar, และอื่น ๆ อีกมากมาย ความยืดหยุ่นนี้ช่วยให้คุณเลือกประเภทแผนภูมิที่เหมาะกับการแสดงผลข้อมูลของคุณที่สุด

**วิธีเพิ่มแผนภูมิใหม่ลงในสไลด์คืออะไร?**

เพื่อเพิ่มแผนภูมิ, คุณสร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation), ดึงสไลด์ตามดัชนีที่ต้องการ, แล้วเรียกเมธอดเพิ่มแผนภูมิโดยระบุประเภทแผนภูมิและข้อมูลเริ่มต้น กระบวนการนี้ผสานแผนภูมิเข้าใน presentation ของคุณโดยตรง

**ฉันจะอัปเดตข้อมูลที่แสดงในแผนภูมิได้อย่างไร?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึง workbook ของข้อมูล ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)), ลบ series และประเภทเริ่มต้น, แล้วเพิ่มข้อมูลที่กำหนดเองของคุณ ซึ่งช่วยให้คุณรีเฟรชแผนภูมิโดยโปรแกรมตามข้อมูลล่าสุด

**สามารถปรับแต่งลักษณะของแผนภูมิได้หรือไม่?**

ได้, Aspose.Slides for .NET มีตัวเลือกการปรับแต่งมากมาย คุณสามารถแก้ไขสี, ฟอนต์, ป้าย, legend, และองค์ประกอบการจัดรูปแบบอื่น ๆ เพื่อให้แผนภูมิตรงกับความต้องการออกแบบของคุณ

Related feature: [Create editable charts](/slides/th/features/create-charts/).