---
title: จัดการสมุดงานแผนภูมิในงานนำเสนอด้วย .NET
linktitle: สมุดงานแผนภูมิ
type: docs
weight: 70
url: /th/net/chart-workbook/
keywords:
- สมุดงานแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์สมุดงาน
- ป้ายข้อมูล
- ชีตงาน
- แหล่งข้อมูล
- สมุดงานภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนสมุดงาน
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบ Aspose.Slides for .NET: จัดการสมุดงานแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลการนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับแผนภูมิที่ใช้สมุดงานใน Aspose.Slides แสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของสมุดงาน ใช้เซลล์ของสมุดงานเป็นป้ายข้อมูลของแผนภูมิ เข้าถึงคอลเลกชันของชีตงาน และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

ยังครอบคลุมการทำงานกับสมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีสร้างและกำหนดสมุดงานภายนอก ดึงเส้นทางของสมุดงานภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อสมุดงานพร้อมใช้งาน

สำหรับเซลล์ของสมุดงานที่แสดงข้อมูลหายไป ดูที่ [ควบคุมการแสดงผลของเซลล์ที่ว่างเปล่า](/slides/th/net/chart-series/) เพื่อเปรียบเทียบความแตกต่างระหว่างเซลล์ว่างและศูนย์ รวมถึงการเปรียบเทียบแบบแผนภูมิเส้นของโหมดการแสดงผลที่มีให้

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อน**

ใช้ [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) เพื่อควบคุมว่าข้อความของแผนภูมิจะพล็อตข้อมูลจากแถวและคอลัมน์ของชีตงานที่ซ่อนหรือไม่ ตั้งค่าเป็น `true` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็นได้ หรือ `false` เพื่อรวมเซลล์ที่มองเห็นและที่ซ่อนไว้ การตั้งค่านี้ส่งผลต่อการพล็อตของแผนภูมิเท่านั้น ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของชีตงาน

ดาวน์โหลดไฟล์ [hidden-source-data.pptx](hidden-source-data.pptx) และวางไว้ในโฟลเดอร์ทำงาน สไลด์แรกมีแผนภูมิคอลัมน์เป็นรูปร่างแรก ชีตงานที่ฝังอยู่ `Sheet1` มีช่วงข้อมูลต้นแบบ `A1:C4` แถว 3 และคอลัมน์ C ถูกซ่อน แต่เซลล์ยังคงมีค่า

| แถวของชีตงาน | A: เดือน | B: ขายปลีก | C: ขายส่ง (คอลัมน์ที่ซ่อน) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (แถวที่ซ่อน) | February | 40 | 60 |
| 4 | March | 20 | 50 |

เข้าถึงเซลล์ต้นแบบผ่าน [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/chartdataworkbook/) และอ่านคุณสมบัติ [IChartDataCell.IsHidden](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/ishidden/) เพื่อดูสถานะการซ่อน คุณสมบัตินี้เป็นแบบอ่านอย่างเดียว ในไฟล์นี้ B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างจะแสดงผล `False`, `True`, และ `True` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการพล็อต: รักษาสมุดงานที่ฝังอยู่ด้วย [ReadWorkbookStream](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/readworkbookstream/) แล้วโหลดใหม่ด้วย [WriteWorkbookStream](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/writeworkbookstream/) เมื่อรวมทุกเซลล์ ให้ใช้ [SetRange](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/setrange/) เพื่อคืนช่วงข้อมูลเต็มรวมถึงหมวดเดือน February ที่ซ่อนอยู่ การเปลี่ยนค่าสถานะอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแผนภูมิและป้ายหมวดที่แคชไว้ในตัวอย่างนี้

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("hidden-source-data.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes[0] is IChart chart)
{
    var workbook = chart.ChartData.ChartDataWorkbook;
    Console.WriteLine($"B2 hidden: {workbook.GetCell(0, "B2").IsHidden}");
    Console.WriteLine($"B3 hidden: {workbook.GetCell(0, "B3").IsHidden}");
    Console.WriteLine($"C2 hidden: {workbook.GetCell(0, "C2").IsHidden}");

    using var workbookStream = chart.ChartData.ReadWorkbookStream();
    foreach (var visibleOnly in new[] { true, false })
    {
        chart.PlotVisibleCellsOnly = visibleOnly;

        // รีเฟรชข้อมูลแผนภูมิจากสมุดงานที่ฝังอยู่.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // คืนช่วงต้นฉบับทั้งหมดรวมถึงหมวดที่ซ่อนอยู่.
            chart.ChartData.SetRange("Sheet1!$A$1:$C$4");
        }

        presentation.Save($"hidden_cells_{visibleOnly}.pptx", SaveFormat.Pptx);
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

ตัวอย่างจะบันทึก `hidden_cells_True.pptx` ที่มีเฉพาะค่าขายปลีกที่มองเห็น (`10` และ `20`) และ `hidden_cells_False.pptx` ที่มีค่าทั้งหกค่า รูปภาพด้านล่างแสดงจากการเปิดนำเสนอที่บันทึกแล้ว; ทั้งสองไฟล์รักษาการตั้งค่าการพล็อตของตนเอง แถว 3 และคอลัมน์ C ยังคงซ่อนอยู่ในสมุดงานที่ฝังทั้งสอง

| เฉพาะเซลล์ที่มองเห็น (`true`) | ทุกเซลล์ (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ว่างเปล่า [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/displayblanksas/) ควบคุมวิธีการแสดงค่าที่หายไป; มันไม่ได้รวมหรือยกเว้นข้อมูลต้นแบบที่ซ่อน ดูที่ [ควบคุมการแสดงผลของเซลล์ที่ว่างเปล่า](/slides/th/net/chart-series/#control-the-display-of-empty-cells) สำหรับตัวอย่าง

## **อ่านและเขียนข้อมูลแผนภูมิจากสมุดงาน**

Aspose.Slides for .NET มีเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/readworkbookstream/) และ [WriteWorkbookStream](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/writeworkbookstream/) ที่ให้คุณอ่านและเขียนสมุดงานข้อมูลแผนภูมิ (ซึ่งอาจถูกแก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างที่คล้ายกับต้นแบบ

ตัวอย่างนี้เปิด `chart.pptx` ซึ่งต้องมีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรก มันจะอ่านสมุดงานที่ฝังอยู่เป็นสตรีม ล้างชุดข้อมูลและหมวดหมู่เดิม แล้วเขียนสมุดงานเดิมกลับเข้าไป การเปลี่ยนแปลงอยู่ในหน่วยความจำ; ตัวอย่างไม่ได้บันทึกการนำเสนอ

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **ตรวจสอบโครงสร้างแผนภูมิหลังการแก้ไขสมุดงาน**

เมื่อคุณแทนที่สมุดงานที่ฝังอยู่ด้วยสมุดงานที่แก้ไขแล้ว แผนภูมิจะคงชุดข้อมูลและคอลเลกชันหมวดเดิมไว้ ความไม่ตรงกันนี้อาจทำให้ [IChart.ValidateChartLayout](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/validatechartlayout/) ล้มเหลวด้วยข้อผิดพลาด index-out-of-range ให้ล้างชุดข้อมูลและหมวดเดิมก่อนเขียนสมุดงานที่อัปเดตกลับเข้ากับแผนภูมิ ตัวอย่างนี้ต้องการไฟล์ `chart.pptx` ที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรก คอมเมนต์ระบุจุดที่การแก้ไขสมุดงานจะเกิดขึ้น; ตัวอย่างทำงานจะเขียนสมุดงานต้นฉบับกลับและตรวจสอบโครงสร้างในหน่วยความจำ

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("chart.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    using var workbookStream = chartData.ReadWorkbookStream();

    // แก้ไขสตรีมสมุดงานที่นี่, เช่น ใช้ Aspose.Cells.

    chartData.Series.Clear();
    chartData.Categories.Clear();

    workbookStream.Position = 0;
    chartData.WriteWorkbookStream(workbookStream);
    chart.ValidateChartLayout();
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

การล้างคอลเลกชันจะลบการอ้างอิงข้อมูลเก่าออกก่อนเขียนสมุดงานกลับมา สร้างการแม็พชุดข้อมูลและหมวดใหม่ตามสมุดงานที่อัปเดตก่อนใช้งานแผนภูมิ

## **กำหนดเซลล์ของสมุดงานเป็นป้ายข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์ของสมุดงานเป็นป้ายข้อมูลแผนภูมิ ขั้นตอนต่อไปนี้แสดงวิธีเชื่อมป้ายในแผนภูมิบับเบิลกับเซลล์ในสมุดข้อมูลของมัน

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) 
1. เข้าถึงสไลด์แรกโดยใช้ดัชนีเริ่มจากศูนย์ 
1. เพิ่มแผนภูมิบับเบิลด้วยข้อมูลเริ่มต้น 
1. เข้าถึงชุดข้อมูลของแผนภูมิ 
1. ตั้งค่าเซลล์ของสมุดงานเป็นป้ายข้อมูล 
1. บันทึกการนำเสนอ

ตัวอย่างนี้เปิด `chart2.pptx` ซึ่งต้องมีสไลด์อย่างน้อยหนึ่งสไลด์และเพิ่มแผนภูมิบับเบิลด้วยข้อมูลเริ่มต้น มันใช้เซลล์ A10:A12 ในชีตที่ 0 สำหรับป้ายสามอันแรกของชุดแรก เปิดใช้งานป้ายจากเซลล์ และบันทึกผลลัพธ์เป็น `resultchart.pptx`

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart2.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Bubble, 50, 50, 600, 400, true);
var series = chart.ChartData.Series[0];
var workbook = chart.ChartData.ChartDataWorkbook;

series.Labels.DefaultDataLabelFormat.ShowLabelValueFromCell = true;
series.Labels[0].ValueFromCell = workbook.GetCell(0, "A10", "Label 0 cell value");
series.Labels[1].ValueFromCell = workbook.GetCell(0, "A11", "Label 1 cell value");
series.Labels[2].ValueFromCell = workbook.GetCell(0, "A12", "Label 2 cell value");

presentation.Save("resultchart.pptx", SaveFormat.Pptx);
```

## **จัดการชีตงาน**

คุณสมบัติ [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/worksheets/) ให้เข้าถึงชีตงานในสมุดงานแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิเส้นวงกลมด้วยข้อมูลเริ่มต้นและพิมพ์ชื่อชีตงานแต่ละชื่อไปยังคอนโซล

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 500);
var workbook = chart.ChartData.ChartDataWorkbook;

for (var i = 0; i < workbook.Worksheets.Count; i++)
{
    Console.WriteLine(workbook.Worksheets[i].Name);
}
```

## **ระบุประเภทแหล่งข้อมูล**

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติด้วยข้อมูลเริ่มต้นและตั้งชื่อสองชุดโดยใช้แหล่งข้อมูลต่างกัน ชื่อแรกใช้สตริงลิเทรัล; ชื่อที่สองใช้เซลล์ C1 ในชีตที่ 0 ค่าธรรมชาติ [DataSourceType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/datasourcetype/) จะเลือกแหล่งสำหรับแต่ละชื่อ ผลลัพธ์บันทึกเป็น `pres.pptx`

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Column3D, 50, 50, 600, 400, true);
var literalName = chart.ChartData.Series[0].Name;

literalName.DataSourceType = DataSourceType.StringLiterals;
literalName.Data = "LiteralString";

var cellName = chart.ChartData.Series[1].Name;
var nameCell = chart.ChartData.ChartDataWorkbook.GetCell(0, "C1", "NewCell");
cellName.DataSourceType = DataSourceType.Worksheet;
cellName.Data = nameCell;

presentation.Save("pres.pptx", SaveFormat.Pptx);
```

## **ตรวจจับรูปแบบสมุดงานที่ฝังไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบสมุดงาน Excel แบบไบนารี (.xlsb) ที่อาจฝังในบางแผนภูมิ คุณสามารถใช้คุณสมบัติ [EmbeddedWorkbookType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) บน [IChartData](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/) ร่วมกับค่ำ enumerations [WorkbookType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/workbooktype/) เพื่อค้นหารูปแบบที่ไม่รองรับและข้ามแผนภูมิเหล่านั้น ตัวอย่างนี้ตรวจสอบรูปร่างบนสไลด์แรกของ `sample.pptx` ข้ามรูปร่างที่ไม่ใช่แผนภูมิ และพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มีสมุดงาน .xlsb ฝังอยู่

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
    {
        continue;
    }

    var chartData = chart.ChartData;
    var isInternalWorkbook = chartData.DataSourceType == ChartDataSourceType.InternalWorkbook;
    var isBinaryMacro = chartData.EmbeddedWorkbookType == WorkbookType.WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console.WriteLine("Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // อ่านหรือแก้ไขข้อมูลสมุดงานแผนภูมิที่รองรับที่นี่.
}
```

## **สมุดงานภายนอก**

Aspose.Slides รองรับการใช้สมุดงานภายนอกเป็นแหล่งข้อมูลของแผนภูมิ

### **สร้างสมุดงานภายนอก**

ใช้ [ReadWorkbookStream](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/readworkbookstream/) และ [SetExternalWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/setexternalworkbook/) เพื่อส่งออกสมุดงานแผนภูมิที่ฝังเป็นไฟล์และเชื่อมแผนภูมิกับสมุดงานภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิวงกลมด้วยข้อมูลเริ่มต้น เขียนสมุดงานของมันไปที่ `externalWorkbook1.xlsx` แล้วปิดสตรีมผลลัพธ์ก่อนกำหนดไฟล์เป็นแหล่งข้อมูลของแผนภูมิ บันทึกการนำเสนอที่เชื่อมโยงเป็น `externalWorkbook.pptx`

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600);
var workbookPath = Path.GetFullPath("externalWorkbook1.xlsx");

using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var fileStream = File.Create(workbookPath))
{
    workbookStream.CopyTo(fileStream);
}

chart.ChartData.SetExternalWorkbook(workbookPath);
presentation.Save("externalWorkbook.pptx", SaveFormat.Pptx);
```

### **กำหนดสมุดงานภายนอก**

โดยใช้เมธอด [SetExternalWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/setexternalworkbook/) คุณสามารถกำหนดสมุดงานภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังใช้เพื่ออัปเดตเส้นทางไปยังสมุดงานภายนอก (หากไฟล์นั้นถูกย้าย)

แม้ว่าจะไม่สามารถแก้ไขข้อมูลในสมุดงานที่อยู่บนทรัพยากรระยะไกลได้ แต่ยังสามารถใช้สมุดงานเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพัทธ์สำหรับสมุดงานภายนอก ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ต้องการไฟล์ `externalWorkbook.xlsx` ในโฟลเดอร์ทำงาน ชีตที่ชื่อ `Sheet1` ต้องมีชื่อชุดข้อมูลใน B1, ชื่อหมวดใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิวงกลม เชื่อมสมุดงาน และใช้ [SetRange](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/setrange/) เพื่อแม็พ A1:B4 เป็นชุดข้อมูลหนึ่งชุดและสามหมวด บันทึกผลลัพธ์เป็น `Presentation_with_externalWorkbook.pptx`

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);
var chartData = chart.ChartData;
var workbookPath = Path.GetFullPath("externalWorkbook.xlsx");

chartData.SetExternalWorkbook(workbookPath);
chartData.SetRange("Sheet1!$A$1:$B$4");

presentation.Save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
```

พารามิเตอร์ `updateChartData` ของ [SetExternalWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/setexternalworkbook/) ควบคุมว่าจะแปลงสมุดงานหรือไม่

* เมื่อ `updateChartData` เป็น `false` จะอัปเดตเพียงเส้นทางของสมุดงาน แผนภูมิจะไม่โหลดหรืออัปเดตข้อมูลจากสมุดงานเป้าหมาย ดังนั้นสมุดงานอาจไม่พร้อมใช้งาน
* เมื่อ `updateChartData` เป็น `true` แผนภูมิจะอัปเดตข้อมูลจากสมุดงานเป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวแทนด้วย `updateChartData` เป็น `false` รักษาข้อมูลเริ่มต้นของแผนภูมิวงกลมและบันทึกการนำเสนอโดยไม่โหลดสมุดงานที่ไม่มี

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 50, 50, 400, 600, true);

chart.ChartData.SetExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);
presentation.Save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
```

### **รับเส้นทางของสมุดงานแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อตรวจสอบสมุดงานที่เชื่อมโยงกับแผนภูมิ ให้ตรวจสอบก่อนว่าแผนภูมิใช้แหล่งข้อมูลภายนอกหรือไม่ หากใช่ ให้ดึงเส้นทางของสมุดงานตามขั้นตอนต่อไปนี้

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation/) 
1. เข้าถึงสไลด์แรกโดยใช้ดัชนีเริ่มจากศูนย์ 
1. ตรวจสอบว่ารูปร่างแรกเป็นแผนภูมิหรือไม่ 
1. อ่านประเภทแหล่งข้อมูลของแผนภูมิ 
1. หากเป็นสมุดงานภายนอก ให้อ่านเส้นทางของมัน

ตัวอย่างนี้เปิด `externalWorkbook.pptx` ที่สร้างจากตัวอย่างก่อนหน้า และตรวจสอบรูปร่างแรกบนสไลด์แรก หากเป็นแผนภูมิที่เชื่อมกับสมุดงานภายนอก ตัวอย่างจะแสดงผล [ExternalWorkbookPath](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/externalworkbookpath/) ไปยังคอนโซล จากนั้นบันทึกสำเนาการนำเสนอเป็น `Result.pptx`

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("externalWorkbook.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var chartData = chart.ChartData;
    if (chartData.DataSourceType == ChartDataSourceType.ExternalWorkbook)
    {
        Console.WriteLine(chartData.ExternalWorkbookPath);
    }
    else
    {
        Console.WriteLine("The chart does not use an external workbook.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}

presentation.Save("Result.pptx", SaveFormat.Pptx);
```

### **แก้ไขข้อมูลแผนภูมิ**

คุณสามารถแก้ไขข้อมูลในสมุดงานภายนอกได้เช่นเดียวกับการแก้ไขข้อมูลในสมุดงานภายใน หากไม่สามารถโหลดสมุดงานภายนอกได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ต้องการไฟล์ `presentation.pptx` ที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรกและสมุดงานภายนอกที่เข้าถึงได้ มันตั้งค่าค่าที่ได้จากเซลล์ของจุดข้อมูลแรกในชุดแรกเป็น 100 และบันทึกการนำเสนอเป็น `presentation_out.pptx` การแก้ไขค่าผ่านเซลล์อาจอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยง ดังนั้นควรใช้สำเนาไฟล์หากต้องการรักษาสมุดงานต้นฉบับไว้

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var series = chart.ChartData.Series;
    if (series.Count > 0 && series[0].DataPoints.Count > 0)
    {
        var valueCell = series[0].DataPoints[0].Value.AsCell;
        if (valueCell != null)
        {
            valueCell.Value = 100;
            presentation.Save("presentation_out.pptx", SaveFormat.Pptx);
        }
        else
        {
            Console.WriteLine("The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console.WriteLine("The chart has no data points to edit.");
    }
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

### **กู้คืนสมุดงานจากแคชของแผนภูมิ**

หากแผนภูมิใช้สมุดงานภายนอกที่หายไปหรือไม่สามารถเข้าถึงได้ Aspose.Slides สามารถสร้างสมุดงานแผนภูมิจากข้อมูลที่แคชไว้ในไฟล์นำเสนอได้ สร้างอ็อบเจ็กต์ [LoadOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/) ตั้งค่า [SpreadsheetOptions](https://reference.aspose.com/slides/th/net/aspose.slides/loadoptions/spreadsheetoptions/) และกำหนด [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/th/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) เป็น `true` ก่อนเปิดไฟล์นำเสนอ

ตัวอย่าง C# ด้านล่างเปิด `presentation.pptx` ซึ่งรูปร่างแรกบนสไลด์แรกต้องเป็นแผนภูมิที่อ้างอิงสมุดงานภายนอกที่ไม่สามารถเข้าถึงได้และเข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.ChartData](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/chartdata/) และ [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

var spreadsheetOptions = new SpreadsheetOptions
{
    RecoverWorkbookFromChartCache = true
};
var loadOptions = new LoadOptions
{
    SpreadsheetOptions = spreadsheetOptions
};

using var presentation = new Presentation("presentation.pptx", loadOptions);
var slide = presentation.Slides[0];

var shapeCount = slide.Shapes.Count;
if (shapeCount > 0 && slide.Shapes[0] is IChart chart)
{
    var recoveredWorkbook = chart.ChartData.ChartDataWorkbook;

    // อ่านหรือแก้ไขข้อมูลสมุดงานที่กู้คืนได้ที่นี่.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

หากสมุดงานภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิด, Aspose.Slides จะโยนข้อยกเว้น [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) ให้เปิดใช้งานการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแคชของแผนภูมิเป็นวิธีสำรองที่ยอมรับได้ เนื่องจากแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในสมุดงานภายนอกหลังจากที่นำเสนออัปเดตครั้งสุดท้าย

## **คำถามที่พบบ่อย**

**ฉันสามารถระบุได้หรือไม่ว่าแผนภูมิเฉพาะเชื่อมโยงกับสมุดงานภายนอกหรือที่ฝังไว้?**

ใช่ แผนภูมิมี [ประเภทแหล่งข้อมูล](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/datasourcetype/) และ [เส้นทางไปยังสมุดงานภายนอก](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/externalworkbookpath/) หากแหล่งเป็นสมุดงานภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ามีไฟล์ภายนอกถูกใช้

**รองรับเส้นทางสัมพัทธ์ไปยังสมุดงานภายนอกหรือไม่ และมันถูกจัดเก็บอย่างไร?**

รองรับ หากระบุเส้นทางสัมพัทธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ การนำเสนอจะเก็บเส้นทางเต็มในไฟล์ PPTX ดังนั้นการย้ายสมุดงานอาจต้องอัปเดตลิงก์

**ฉันสามารถใช้สมุดงานที่อยู่บนเครือข่ายหรือแชร์ได้หรือไม่?**

ได้ สมุดงานเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขสมุดงานระยะไกลโดยตรงจาก Aspose.Slides ไม่รองรับ – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกการนำเสนอหรือไม่?**

การนำเสนอจะเก็บ [ลิงก์ไปยังไฟล์ภายนอก](https://reference.aspose.com/slides/th/net/aspose.slides.charts/chartdata/externalworkbookpath/) การแก้ไขข้อมูลแผนภูมิที่มาจากเซลล์อาจอัปเดตไฟล์ XLSX ภายในเครื่องด้วย ใช้สำเนาของสมุดงานหากต้องการให้ไฟล์ต้นฉบับคงเดิม

**ถ้าไฟล์ภายนอกมีการป้องกันด้วยรหัสผ่านฉันควรทำอย่างไร?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีทั่วไปคือเอาการป้องกันออกล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น โดยใช้ [Aspose.Cells](https://reference.aspose.com/cells/net/)) แล้วเชื่อมโยงกับสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงสมุดงานภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปที่ไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในทุกแผนภูมิในครั้งต่อไปที่โหลดข้อมูล**