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
- แผนภูมิต้นไม้
- แผนภูมิตลาดหุ้น
- แผนภูมิกล่องและวิสเกอร์
- แผนภูมุกระบอก
- แผนภูมิดวงอาทิตย์
- แผนภูมิเฮิสโตแกรม
- แผนภูมิโรดาร์
- แผนภูมิมัลติคาติเกอรี
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "สร้างและปรับแต่งแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides for .NET เพิ่ม, จัดรูปแบบ, และแก้ไขแผนภูมิด้วยตัวอย่างโค้ดเชิงปฏิบัติใน C#."
---
## **ภาพรวม**

บทความนี้ให้คำแนะนำอย่างครบถ้วนเกี่ยวกับวิธีสร้างและปรับแต่งแผนภูมิด้วย Aspose.Slides for .NET คุณจะได้เรียนรู้วิธีเพิ่มแผนภูมิเข้าไปในสไลด์แบบโปรแกรมเมติก, เติมข้อมูลลงในแผนภูมิ, และใช้ตัวเลือกการจัดรูปแบบต่าง ๆ เพื่อให้ตรงกับข้อกำหนดการออกแบบของคุณอย่างเฉพาะเจาะจง ตลอดบทความมีตัวอย่างโค้ดที่ละเอียดอธิบายแต่ละขั้นตอน ตั้งแต่การเริ่มต้น Presentation และอ็อบเจกต์แผนภูมิ ไปจนถึงการกำหนด Series, แกน, และ Legend โดยทำตามคำแนะนำนี้ คุณจะเข้าใจวิธีผสานการสร้างแผนภูมิกระแสไหลลงในแอปพลิเคชัน .NET ของคุณได้อย่างมั่นคง ช่วยเร่งรัดกระบวนการสร้างการนำเสนอที่ขับเคลื่อนด้วยข้อมูล

## **สร้างแผนภูมิ**

แผนภูมิช่วยให้ผู้ใช้มองเห็นข้อมูลได้อย่างรวดเร็วและค้นพบข้อมูลเชิงลึกที่อาจไม่ชัดเจนจากตารางหรือสเปรดชีต

**ทำไมต้องสร้างแผนภูมิ?**

การใช้แผนภูมิคุณสามารถ:

* รวม, ย่อ, หรือสรุปข้อมูลจำนวนมากในสไลด์เดียว;
* แสดงรูปแบบและแนวโน้มของข้อมูล;
* ระบุทิศทางและโมเมนตัมของข้อมูลตามเวลา หรือหน่วยวัดเฉพาะ;
* พบค่าผิดปกติ, ความเบี่ยงเบน, ข้อผิดพลาด, และข้อมูลที่ไม่มีเหตุผล;
* สื่อสารหรือแสดงข้อมูลที่ซับซ้อน

ใน PowerPoint คุณสามารถสร้างแผนภูมิผ่านฟังก์ชัน *Insert* ที่มีแม่แบบสำหรับออกแบบแผนภูมิหลายประเภท โดยใช้ Aspose.Slides คุณสามารถสร้างแผนภูมิโดยปกติ (ตามประเภทแผนภูมิที่เป็นที่นิยม) และแผนภูมิที่กำหนดเองได้

{{% alert color="info" title="Note" %}}
ใช้ enumeration [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) ภายใต้ namespace [Aspose.Slides.Charts](https://reference.aspose.com/slides/net/aspose.slides.charts/) ค่าต่าง ๆ ใน enumeration นี้สอดคล้องกับประเภทแผนภูมิที่แตกต่างกัน
{{% /alert %}}

### **สร้าง Clustered Column Charts**

ตัวอย่างนี้ใช้ [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) เพื่อสร้างแผนภูมิคอลัมน์แบบกลุ่มที่เปรียบเทียบสอง Series ผ่านสาม Category Series ใช้สีเต็มแบบสีแดงและสีเขียว, และป้ายกำกับแต่ละอันแสดงชื่อ Category, ชื่อ Series, และค่าต่าง ๆ ดัชนี Worksheet 0 หมายถึงแผ่นงานแรกในเวิร์กบุ๊คของแผนภูมิที่ฝังอยู่

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

![แผนภูมิคอลัมน์แบบกลุ่ม](clustered_column_chart.png)

### **สร้าง Scatter Charts**

Scatter charts (หรือที่เรียกว่า scatter plots หรือ x‑y graphs) มักใช้เพื่อตรวจสอบรูปแบบหรือแสดงความสัมพันธ์ระหว่างสองตัวแปร

ใช้แผนภูมิ scatter เมื่อ:

* คุณมีข้อมูลตัวเลขที่จับคู่กัน
* คุณมีสองตัวแปรที่สัมพันธ์กันดี
* คุณต้องการตรวจสอบว่าตัวแปรสองตัวมีความสัมพันธ์หรือไม่
* คุณมีตัวแปรอิสระที่มีค่าหลายค่าเพื่อเป็นตัวแปรตาม

ตัวอย่างนี้พล็อตค่าคู่ x‑y สองชุด Series แรกใช้เส้นตรงพร้อมเครื่องหมายดาว, ส่วนที่สองใช้เส้นโค้งพร้อมเครื่องหมายวงกลม; ทั้งสองใช้ [Size](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/size/) ขนาด 10. คุณสมบัติ [Symbol](https://reference.aspose.com/slides/net/aspose.slides.charts/imarker/symbol/) ควบคุมรูปแบบเครื่องหมาย

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

![แผนภูมิ Scatter](scatter_chart.png)

### **สร้าง Pie Charts**

Pie charts เหมาะสำหรับแสดงความสัมพันธ์ส่วนต่อส่วนทั้งหมดของข้อมูล โดยเฉพาะเมื่อข้อมูลมีป้ายกำกับแบบหมวดหมู่ที่มีค่าตัวเลข อย่างไรก็ตาม หากข้อมูลของคุณมีหลายส่วนหรือหลายป้ายกำกับ คุณอาจพิจารณาใช้แผนภูมิบาร์แทน

ตัวอย่างนี้สร้างแผนภูมิวงกลมที่มีค่าทรานส์สามไตรมาส แต่ละสไลซ์มีการเติมสีและเส้นขอบกำหนดเอง, ป้ายกำกับแสดงการผสมค่าต่าง ๆ, เปอร์เซ็นต์, และข้อมูล Series. คุณสมบัติ [FirstSliceAngle](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/firstsliceangle/) กำหนดให้สไลซ์แรกเริ่มที่ 180 องศา

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

![แผนภูมิ Pie](pie_chart.png)

### **สร้าง Line Charts**

Line charts (หรือ line graphs) เหมาะเมื่อคุณต้องการแสดงการเปลี่ยนแปลงของค่าเมื่อเวลาผ่านไป ใช้แผนภูมิเส้นคุณสามารถเปรียบเทียบข้อมูลจำนวนมากพร้อมกัน, ติดตามการเปลี่ยนแปลงและแนวโน้ม, ไฮไลท์ค่าผิดปกติใน Series, และอื่น ๆ

ตัวอย่างนี้ใช้ [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) เพื่อสร้างแผนภูมิเส้นด้วย Series และ Category เริ่มต้น, แล้วบันทึกเป็น PPTX

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var lineChart = slide.Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

presentation.Save("lineChart.pptx", SaveFormat.Pptx);
```

โดยค่าเริ่มต้น จุดบนแผนภูมิเส้นจะเชื่อมต่อด้วยเส้นตรงต่อเนื่อง หากต้องการให้เชื่อมต่อด้วยเส้นประ ให้ตั้งค่า [DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) จาก [LineDashStyle](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/):

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

![แผนภูมิ Line](line_chart.png)

### **สร้าง Tree Map Charts**

Tree map charts เหมาะสำหรับข้อมูลการขายเมื่อคุณต้องการแสดงขนาดสัมพัทธ์ของหมวดหมู่ข้อมูลและดึงความสนใจไปยังรายการที่เป็นผู้มีส่วนร่วมใหญ่ในแต่ละหมวด

ตัวอย่างนี้สร้าง tree map ที่มีแผ่นใบแปดใบจัดเป็นสี่สเตมและสองสาขา วิธี [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) กำหนดสเตมที่ระดับการจัดกลุ่ม 1 และสาขาที่ระดับ 2 ค่าใช้ในการกำหนดขนาดสี่เหลี่ยมสัมพัทธ์, ป้ายกำกับหมวดและป้ายกำกับพาเร็นท์ที่ทับซ้อนระบุโครงสร้างลำดับชั้น

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

![แผนภูมิ Treemap](treemap_chart.png)

### **สร้าง Waterfall Charts**

Waterfall chart แสดงว่าการเปลี่ยนแปลงบวกและลบมีส่วนทำให้ค่าสุดท้ายเป็นเท่าใด ตัวอย่างเช่น การแยกกำไรอาจเริ่มจากรายได้, ลดค่าใช้จ่าย, แล้วเพิ่มรายได้อื่น ๆ คอลัมน์การเปลี่ยนแปลงลอยอยู่ระหว่างค่าที่ก่อนหน้าและค่าที่ใหม่, ในขณะที่คอลัมน์รวมจะขยายจากศูนย์ไปยังค่าที่สะสม

ตัวอย่างต่อไปนี้ใช้จำนวนเป็นพันดอลลาร์สหรัฐ:

| หมวดหมู่ | ค่าใน Workbook | ประเภทคอลัมน์ |
| --- | ---: | --- |
| Revenue | 1000 | Increase |
| Cost of sales | -400 | Decrease |
| Gross profit | 600 | Intermediate total |
| Operating expenses | -200 | Decrease |
| Other income | 50 | Increase |
| Net profit | 450 | Final total |

เพื่อทำเครื่องหมายจุดว่าเป็นผลรวมระดับกลางหรือสุดท้าย ให้ตั้งคุณสมบัติ [SetAsTotal](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatapoint/setastotal/) เป็น `true` และใส่จำนวนที่สะสมจริงในเซลล์ workbook ของจุดนั้น: `600` สำหรับกำไรขั้นต้น (`1000 - 400`) และ `450` สำหรับกำไรสุทธิ (`600 - 200 + 50`) คุณสมบัตินี้ทำเครื่องหมายคอลัมน์ว่าเป็นผลรวม; ไม่ได้คำนวณหรือเติมค่าเซลล์ อย่าใช้ศูนย์เป็นตัวแทน หรือใส่การเปลี่ยนแปลงอื่นสำหรับจุดผลรวม คอลัมน์ผลรวมจะแสดงค่าที่สะสมโดยไม่เพิ่มอีกครั้งต่อค่าที่กำลังดำเนินอยู่

ตัวอย่าง C# เต็มรูปแบบนี้สร้างแผนภูมิด้วยสมาชิก `Waterfall` ของ [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/), ลบข้อมูลเริ่มต้น, และเติมเวิร์กบุ๊คฝังอยู่ ดัชนี Worksheet `0` เลือกเวิร์กชีตแรก; คอลัมน์ A มีชื่อ Category, คอลัมน์ B มีค่า แต่ละเซลล์ค่าถูกเพิ่มด้วย [AddDataPointForWaterfallSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/adddatapointforwaterfallseries/) ดัชนีจุดฐานศูนย์ `2` และ `5` ระบุผลรวมระดับกลางและสุดท้าย เปิดใช้งาน [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) เพื่อแสดงจำนวนบนคอลัมน์ ไม่จำเป็นต้องมีการนำเข้าการนำเสนอหรือเวิร์กบุ๊ค

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

// จุดที่สามและหกเป็นผลรวม ไม่ใช่การเปลี่ยนแปลงเพิ่มเติม.
series.DataPoints[2].SetAsTotal = true;
series.DataPoints[5].SetAsTotal = true;
series.ShowConnectorLines = true;
series.Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("WaterfallChart.pptx", SaveFormat.Pptx);
```

ตั้งคุณสมบัติระดับ Series [ShowConnectorLines](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseries/showconnectorlines/) เป็น `true` เพื่อแสดงเส้นเชื่อมคอลัมน์ต่อเนื่องและทำให้ค่าที่ดำเนินอยู่ตามติดง่ายขึ้น หากต้องการซ่อนเส้นเหล่านี้ ให้เปลี่ยนการกำหนดค่าในตัวอย่างเป็น `series.ShowConnectorLines = false;` ก่อนบันทึก การเปลี่ยนนี้มีผลเพียงต่อการแสดงเส้น ไม่กระทบต่อข้อมูลหรือผลรวม

การนำเสนองานที่บันทึกแสดงกำไรขั้นต้น 600 และกำไรสุทธิ 450, โดยทั้งสองผลรวมเริ่มจากศูนย์:

![แผนภูมิ Waterfall แสดงรายได้, ค่าใช้จ่าย, กำไรขั้นต้น 600, และกำไรสุทธิ 450 พร้อมป้ายค่าและเส้นเชื่อม](waterfall_chart.png)

### **สร้าง Stock Charts**

Stock charts ใช้แสดงข้อมูลการเงินเช่น ราคาเปิด, สูง, ต่ำ, และปิด เพื่อช่วยวิเคราะห์แนวโน้มและความผันผวนในตลาด ให้ข้อมูลสำคัญเกี่ยวกับการดำเนินงานของหุ้น ช่วยนักลงทุนและนักวิเคราะห์ทำการตัดสินใจอย่างมีข้อมูล

ตัวอย่างนี้สร้างแผนภูมิ OHLC (open‑high‑low‑close) ด้วยสี่ Series ตามลำดับและสาม Category คุณสมบัติ [HasUpDownBars](https://reference.aspose.com/slides/net/aspose.slides.charts/iupdownbarsmanager/hasupdownbars/) เปิดใช้งานแถบบาร์ขึ้น/ลง, และ [HiLowLinesFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hilowlinesformat/) ควบคุมเส้นสูง‑ต่ำที่แสดงช่วงราคา, ในขณะเดียวกันเส้น Series แยกและเส้นกริดแนวนอนย่อยถูกซ่อนไว้

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

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

chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

foreach (var stockSeries in chart.ChartData.Series)
{
    stockSeries.Format.Line.FillFormat.FillType = FillType.NoFill;
}

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![แผนภูมิ Stock](stock_chart.png)

### **สร้าง Box and Whisker Charts**

Box and whisker charts ใช้แสดงการกระจายของข้อมูลโดยสรุปสถิติสำคัญ เช่น ค่ามัธยฐาน, ควอร์ไทล์, และค่าอุบัติการณ์ พวกมันมีประโยชน์มากในขั้นตอนการสำรวจข้อมูลและการศึกษาเชิงสถิติ เพื่อทำความเข้าใจความแปรปรวนของข้อมูลและระบุความผิดปกติ

ตัวอย่างนี้สร้าง box and whisker chart จากหกค่า คุณสมบัติ [QuartileMethod](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/quartilemethod/) เลือกการคำนวณควอร์ไทล์แบบ exclusive ตัวอย่างยังเปิดใช้งานเส้นค่าเฉลี่ย, ตัวบ่งชี้ค่าเฉลี่ย, จุดภายใน, และจุดอุบัติการณ์

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

Funnel charts ใช้แสดงกระบวนการที่มีขั้นตอนต่อเนื่องโดยปริมาณข้อมูลจะลดลงเมื่อขยับจากขั้นตอนหนึ่งไปยังขั้นตอนต่อไป เหมาะสำหรับการวิเคราะห์อัตราการแปลง, ระบุคอขวด, และติดตามประสิทธิภาพของกระบวนการขายหรือการตลาด

ตัวอย่างนี้ใช้ [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) เพื่อเพิ่ม funnel chart ไปยังสไลด์แรกของงานนำเสนอที่มีอยู่ แทนที่ข้อมูลเริ่มต้นด้วยหก Category และค่าตั้งแต่ 50 ถึง 500, แล้วบันทึกงานนำเสนอที่อัปเดต งานนำเสนออินพุตต้องมีอย่างน้อยหนึ่งสไลด์

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

![แผนภูมิ Funnel](funnel_chart.png)

### **สร้าง Sunburst Charts**

Sunburst charts ใช้แสดงข้อมูลเชิงลำดับขั้นโดยแสดงระดับต่าง ๆ เป็นวงแหวนซ้อนกัน ช่วยอธิบายความสัมพันธ์ส่วนต่อส่วนทั้งหมดและเหมาะสำหรับการแทนหมวดหมู่ที่ซ้อนกันในรูปแบบที่กระชับชัดเจน

ตัวอย่างนี้สร้าง sunburst chart ที่มีแผ่นใบแปดใบจัดเป็นสี่สเตมและสองสาขา วิธี [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) กำหนดสเตมที่ระดับการจัดกลุ่ม 1 และสาขาที่ระดับ 2 ป้ายกำกับ Category ระบุส่วนต่าง ๆ, ส่วนค่าเป็นตัวกำหนดขนาดสัมพัทธ์

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

![แผนภูมิ Sunburst](sunburst_chart.png)

### **สร้าง Histogram Charts**

Histogram charts ใช้แสดงการกระจายของข้อมูลเชิงตัวเลขโดยจัดกลุ่มค่าเป็นช่วงหรือ bin เหมาะสำหรับระบุรูปแบบเช่น ความถี่, ความเอียง, และการกระจาย, รวมถึงการตรวจจับอุบัติการณ์ในชุดข้อมูล

ตัวอย่างนี้สร้าง histogram จากหกค่าตัวเลข รวมถึงค่าลบ การตั้งค่า [AggregationType](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/aggregationtype/) เป็นอัตโนมัติทำให้แผนภูมิเลือก bin ที่เหมาะสมเพื่อแสดงการกระจาย

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);

chart.ChartData.Categories.Clear();
chart.ChartData.Series.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var series = chart.ChartData.Series.Add(ChartType.Histogram);
var valueCell = workbook.GetCell(0, "A1", 15);
series.DataPoints.AddDataPointForHistogramSeries(valueCell);
valueCell = workbook.GetCell(0, "A2", -41);
series.DataPoints.AddDataPointForHistogramSeries(valueCell);
valueCell = workbook.GetCell(0, "A3", 16);
series.DataPoints.AddDataPointForHistogramSeries(valueCell);
valueCell = workbook.GetCell(0, "A4", 10);
series.DataPoints.AddDataPointForHistogramSeries(valueCell);
valueCell = workbook.GetCell(0, "A5", -23);
series.DataPoints.AddDataPointForHistogramSeries(valueCell);
valueCell = workbook.GetCell(0, "A6", 16);
series.DataPoints.AddDataPointForHistogramSeries(valueCell);

chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

presentation.Save("Histogram.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![แผนภูมิ Histogram](histogram_chart.png)

### **สร้าง Radar Charts**

Radar charts ใช้แสดงข้อมูลหลายตัวแปรในรูปแบบสองมิติ ทำให้เปรียบเทียบหลายตัวแปรพร้อมกันได้ง่าย เหมาะสำหรับระบุรูปแบบ, จุดแข็ง, และจุดอ่อนในหลายเมตริกหรือคุณลักษณะ

ตัวอย่างนี้ใช้ [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) เพื่อสร้าง radar chart ด้วย Series และ Category เริ่มต้น, แล้วบันทึกเป็น PPTX

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

![แผนภูมิ Radar](radar_chart.png)

### **สร้าง Multi-Category Charts**

Multi-category charts ใช้แสดงข้อมูลที่มีการจัดกลุ่มหมวดหมู่หลายระดับพร้อมกัน ทำให้คุณเปรียบเทียบค่าข้ามหลายมิติได้ในครั้งเดียว มีประโยชน์ในการวิเคราะห์แนวโน้มและความสัมพันธ์ในชุดข้อมูลที่ซับซ้อนและหลายชั้น

ตัวอย่างนี้สร้าง clustered column chart ที่มีแปด Category จัดเป็นสี่คู่ วิธี [SetGroupingItem](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorylevelsmanager/setgroupingitem/) ให้แต่ละคู่มีป้ายร่วมที่ระดับการจัดกลุ่ม 1 ทำให้แกน Category มีทั้งป้ายบุคคลและป้ายกลุ่ม

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

![แผนภูมิ Multi Category](multi_category_chart.png)

### **สร้าง Map Charts**

Map charts ใช้แสดงข้อมูลภูมิศาสตร์โดยแมปข้อมูลไปยังตำแหน่งเฉพาะ เช่น ประเทศ, รัฐ, หรือเมือง มีประโยชน์ในการวิเคราะห์แนวโน้มภูมิภาค, ข้อมูลประชากร, และการกระจายเชิงพื้นที่ในรูปแบบที่ชัดเจนและดึงดูดสายตา

ตัวอย่างนี้ใช้ [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) เพื่อสร้าง map chart ด้วยข้อมูลทางภูมิศาสตร์เริ่มต้นและบันทึกเพื่อดูใน PowerPoint

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

![แผนภูมิ Map](map_chart.png)

{{% alert color="info" title="Note" %}}
ภาพด้านบนแสดงงานนำเสนอที่บันทึกแล้วเปิดใน PowerPoint. Aspose.Slides เขียนแผนภูมิแผนที่และข้อมูลได้อย่างถูกต้อง, แต่ไม่ได้วาดแผนภูมิแผนที่เอง: เมื่อสไลด์ที่มีแผนภูมิดังกล่าวถูกเรนเดอร์เป็นภาพหรือแปลงเป็น PDF หรือ SVG, พื้นที่แผนภูมิจะออกมาเป็นสีขาว ส่วนรูปทรงอื่นบนสไลด์เดียวกันไม่ถูกกระทบ
{{% /alert %}}

### **สร้าง Combination Charts**

Combination chart (หรือ combo chart) ผสมสองหรือหลายประเภทแผนภูมิในกราฟเดียว ทำให้คุณสามารถไฮไลท์, เปรียบเทียบ, หรือวิเคราะห์ความแตกต่างระหว่างชุดข้อมูลหลายชุด เพื่อระบุความสัมพันธ์ระหว่างพวกมัน

![แผนภูมิ Combination](combination_chart.png)

ตัวอย่างนี้ผสมสอง Series คอลัมน์แบบกลุ่มกับ Series เส้นหนึ่งชุดบนสี่ Category คอลัมน์ใช้แกนแนวตั้งหลัก, ส่วน [PlotOnSecondAxis](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/plotonsecondaxis/) วางเส้นบนแกนแนวตั้งรองด้านขวา ฟังก์ชันช่วยเหลือกำหนดค่าชื่อเรื่อง, Legend, ป้ายแกน, และเส้นกริด

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

Aspose.Slides for .NET ทำให้คุณอัปเดตแผนภูมิ PowerPoint โดยแก้ไขข้อมูลแผนภูมิ, การจัดรูปแบบ, และสไตล์ ฟังก์ชันนี้ช่วยลดความซับซ้อนในการทำให้การนำเสนอเป็นปัจจุบันด้วยเนื้อหาแบบไดนามิก และทำให้แผนภูม้อัพเดตให้สอดคล้องกับข้อมูลและมาตรฐานการออกแบบล่าสุด

ตัวอย่างนี้อัปเดตแผนภูมิที่ชื่อ "My chart" บนสไลด์แรกของงานนำเสนอที่มีอยู่ ต้องการ Series คอลัมน์สองชุดที่มีจุดข้อมูลสามจุดแต่ละชุด, ป้าย Category อยู่ในคอลัมน์ A และชื่อ Series อยู่ในแถวแรกของเวิร์กชีตแรก ตัวอย่างใช้ [GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) เพื่อเปลี่ยนเซลล์ workbook, อัปเดตค่า Series, เพิ่ม Series ที่สาม, และเปลี่ยนแผนภูมิเป็น clustered cylinders ผ่าน [Type](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/type/)

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

## **กำหนดช่วงข้อมูลสำหรับแผนภูมิ**

เพื่อดูช่วงที่แผนภูมิใช้แล้วในแผนภูมิที่มีอยู่ ดูที่ [Retrieve a Chart's Data Range](/slides/th/net/chart-workbook/#retrieve-a-charts-data-range)

Aspose.Slides for .NET ให้ความยืดหยุ่นในการกำหนดช่วงข้อมูลเฉพาะจากเวิร์กชีตเป็นแหล่งข้อมูลสำหรับแผนภูมิของคุณ ซึ่งหมายความว่าคุณสามารถแมปส่วนหนึ่งของเวิร์กชีตไปยังแผนภูมิได้โดยตรง ควบคุมได้ว่าเซลล์ใดบ้างที่จะมีส่วนร่วมใน Series และ Category ของแผนภูมิ ดังนั้นคุณจึงอัปเดตและซิงโครไนซ์แผนภูมิได้ง่ายตามการเปลี่ยนแปลงข้อมูลล่าสุดในเวิร์กชีตของคุณ ทำให้การนำเสนอ PowerPoint สะท้อนข้อมูลที่ถูกต้องและเป็นปัจจุบัน

ตัวอย่างนี้ใช้ [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) เพื่อตั้งแหล่งข้อมูลของแผนภูมิที่ชื่อ "My chart" บนสไลด์แรกของงานนำเสนอที่มีอยู่เป็น `Sheet1!A1:B4` แผนภูมิ workbook ต้องมีแผ่นงานนั้นและช่วงที่มีหัวข้อ Series ในแถวแรก, ป้าย Category ในคอลัมน์ A, และค่าสามค่าในคอลัมน์ B

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

เมื่อคุณใช้ Marker เริ่มต้นในแผนภูมิ, แต่ละ Series จะได้รับสัญลักษณ์ Marker เริ่มต้นที่แตกต่างกันโดยอัตโนมัติ

ตัวอย่างนี้ใช้ [AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) เพื่อสร้างแผนภูมิที่มีสอง Series เส้นและ Legend การตั้งค่า [Marker](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/marker/) เก็บสัญลักษณ์ Marker ที่กำหนดอัตโนมัติ Series แรกมีค่าลบและค่าที่หายไป (null) ส่วน Series ที่สองมีค่าทุก Category

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

**ประเภทแผนภูมิใดบ้างที่ Aspose.Slides for .NET รองรับ?**

Aspose.Slides for .NET รองรับแผนภูมิหลายประเภท รวมถึง bar, line, pie, area, scatter, histogram, radar, และอื่น ๆ อีกมาก ความยืดหยุ่นนี้ทำให้คุณเลือกประเภทแผนภูมิที่เหมาะสมกับการแสดงข้อมูลของคุณ

**ฉันจะเพิ่มแผนภูมิใหม่ลงในสไลด์ได้อย่างไร?**

เพื่อเพิ่มแผนภูมิ, เริ่มแรกให้สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) แล้วดึงสไลด์ที่ต้องการโดยใช้ดัชนี, จากนั้นเรียกเมธอดเพื่อเพิ่มแผนภูมิโดยระบุประเภทแผนภูมิและข้อมูลเริ่มต้น กระบวนการนี้ผสานแผนภูมิเข้ากับงานนำเสนอของคุณโดยตรง

**ฉันจะอัปเดตข้อมูลที่แสดงในแผนภูมิได้อย่างไร?**

คุณสามารถอัปเดตข้อมูลของแผนภูมิได้โดยเข้าถึงเวิร์กบุ๊คข้อมูลของมัน ([IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/)), ล้าง Series และ Category เริ่มต้น, แล้วเพิ่มข้อมูลที่กำหนดเองของคุณ วิธีนี้ช่วยให้คุณรีเฟรชแผนภูมิโปรแกรมเมติกให้สอดคล้องกับข้อมูลล่าสุด

**สามารถปรับแต่งรูปลักษณ์ของแผนภูมิได้หรือไม่?**

ได้, Aspose.Slides for .NET มีตัวเลือกการปรับแต่งที่หลากหลาย คุณสามารถแก้ไขสี, ฟอนต์, ป้าย, Legend, และองค์ประกอบการจัดรูปแบบอื่น ๆ เพื่อให้รูปลักษณ์ของแผนภูมิตรงตามความต้องการการออกแบบของคุณ