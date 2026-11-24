---
title: จัดการเวิร์กบุ๊กแผนภูมิในงานนำเสนอด้วย .NET
linktitle: เวิร์กบุ๊กแผนภูมิ
type: docs
weight: 70
url: /th/net/chart-workbook/
keywords:
- เวิร์กบุ๊กแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์เวิร์กบุ๊ก
- ป้ายกำกับข้อมูล
- เวิร์กชีต
- แหล่งข้อมูล
- เวิร์กบุ๊กภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนเวิร์กบุ๊ก
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบ Aspose.Slides for .NET: จัดการเวิร์กบุ๊กแผนภูมิใน PowerPoint และรูปแบบ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับเวิร์กบุ๊กแผนภูมิใน Aspose.Slides แสดงวิธีการอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของเวิร์กบุ๊ก ใช้เซลล์ของเวิร์กบุ๊กเป็นป้ายกำกับข้อมูลแผนภูมิ เข้าถึงคอลเลกชันเวิร์กชีต และกำหนดประเภทของแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีการสร้างและกำหนดเวิร์กบุ๊กภายนอก การดึงพาธของเวิร์กบุ๊กภายนอกที่เชื่อมโยงกับแผนภูมิ และการแก้ไขข้อมูลแผนภูมิเมื่อเวิร์กบุ๊กพร้อมใช้งาน

สำหรับเซลล์ของเวิร์กบุ๊กที่แสดงข้อมูลที่หายไป ให้ดูที่ [ควบคุมการแสดงเซลล์ว่าง](/slides/th/net/chart-series/) เพื่อทำความเข้าใจความแตกต่างระหว่างเซลล์ว่างและศูนย์ พร้อมตัวอย่างการเปรียบเทียบแผนภูมิเส้นของโหมดการแสดงผลที่มีอยู่

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่**

ใช้ [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) เพื่อควบคุมว่าแผนภูมิจะแสดงข้อมูลจากแถวและคอลัมน์ของเวิร์กชีตที่ซ่อนอยู่หรือไม่ ตั้งค่าให้เป็น `true` เพื่อแสดงเฉพาะเซลล์ที่มองเห็นได้ หรือ `false` เพื่อรวมทั้งเซลล์ที่มองเห็นและซ่อน การตั้งค่านี้มีผลต่อการวาดแผนภูมิเท่านั้น ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของเวิร์กชีต

ไฟล์นำเสนอ[ตัวอย่าง](hidden-source-data.pptx) มีแผนภูมิคอลัมน์เป็นรูปร่างแรกบนสไลด์แรก เวิร์กชีตฝังอยู่ชื่อ `Sheet1` มีช่วงข้อมูลต้นทาง `A1:C4` แถวที่ 3 และคอลัมน์ C ถูกซ่อนไว้ แต่เซลล์เหล่านั้นยังคงมีค่า

| แถวของเวิร์กชีต | A: เดือน | B: รายละเอียดการขายปลีก | C: การขายส่ง (คอลัมน์ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์ต้นทางผ่าน [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) และอ่านคุณสมบัติ [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) เพื่อตรวจสอบสถานะการซ่อนของเซลล์ คุณสมบัตินี้เป็นอ่านอย่างเดียว ในไฟล์นี้ B2 มองเห็นได้ B3 อยู่ในแถวที่ซ่อน และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างจะแสดงผล `False`, `True`, และ `True` ตามลำดับ

สำหรับตัวอย่างนี้ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการวาด: เก็บเวิร์กบุ๊กฝังไว้ด้วย [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) แล้วโหลดใหม่ด้วย [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) เมื่อรวมทุกเซลล์ ให้ใช้ [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) เพื่อคืนช่วงเต็มรวมถึงหมวด “February” ที่ซ่อนอยู่ การเปลี่ยนค่าแฟล็กอย่างเดียวไม่เพียงพอที่จะรีเฟรชข้อมูลแผนภูมิและป้ายกำกับหมวดที่แคชไว้ในตัวอย่างนี้

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

        // รีเฟรชข้อมูลแผนภูมิจากเวิร์กบุ๊กฝังอยู่.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // คืนค่าช่วงต้นทางทั้งหมด รวมถึงหมวดที่ซ่อนอยู่.
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

ตัวอย่างบันทึกสองเวอร์ชันของไฟล์นำเสนอ: เวอร์ชันแรกมีค่า Retail ที่มองเห็นได้เท่านั้น (10 และ 20) ส่วนเวอร์ชันที่สองมีค่าทั้งหกค่า ภาพด้านล่างแสดงผลจากไฟล์นำเสนอที่บันทึกแล้วและเปิดใหม่ ทั้งสองไฟล์คงการตั้งค่าการวาดที่กำหนดไว้ แถวที่ 3 และคอลัมน์ C ยังคงซ่อนอยู่ในทั้งสองเวิร์กบุ๊กฝัง

| เฉพาะเซลล์ที่มองเห็น (`true`) | ทุกเซลล์ (`false`) |
| --- | --- |
| ![เฉพาะเซลล์ที่มองเห็น: ค่า Retail 10 และ 20 สำหรับเดือนมกราคมและมีนาคม.](hidden_cells_True.png) | ![ทุกเซลล์: ค่า Retail และ Wholesale สำหรับเดือนมกราคม กุมภาพันธ์ และมีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนพร้อมค่าจะแตกต่างจากเซลล์ว่าง [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) ควบคุมวิธีการแสดงค่าที่หายไป; ไม่ได้รวมหรือยกเว้นข้อมูลต้นทางที่ซ่อน ดูที่ [ควบคุมการแสดงเซลล์ว่าง](/slides/th/net/chart-series/#control-the-display-of-empty-cells) เพื่อดูตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนอัปเดตข้อมูลเวิร์กบุ๊กในไฟล์นำเสนอที่มีอยู่ ให้ตรวจสอบช่วงต้นทางเพื่อระบุว่าแผนภูมิเฉพาะใช้เซลล์ของเวิร์กชีตใดบ้าง วิธี [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) จะคืนช่วงข้อมูลปัจจุบันในรูปแบบสูตรที่ระบุเวิร์กชีต เช่น `Sheet1!$A$1:$D$5` ที่นี่ `Sheet1` คือชื่อเวิร์กชีต `!` คั่นกับช่วงเซลล์ และ `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวมถึงสัญลักษณ์ `$` เพื่อระบุการอ้างอิงแบบสัมบูรณ์

เมธอดนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือเวิร์กบุ๊ก หากแผนภูมิไม่ได้ใช้เวิร์กบุ๊กเป็นแหล่งข้อมูล จะโยนข้อยกเว้น [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) ดูข้อมูลเพิ่มเติมที่ [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/)

ตัวอย่างนี้เปิดไฟล์นำเสนอและตรวจสอบรูปร่างบนแต่ละสไลด์เพื่อหาแผนภูมิ พิมพ์ชื่อของแต่ละแผนภูมิและช่วงต้นทาง หากแผนภูมิไม่ใช้เวิร์กบุ๊ก ให้พิมพ์ข้อความแล้วดำเนินการต่อไปยังแผนภูมถัดไป

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IChart chart)
        {
            try
            {
                var range = chart.ChartData.GetRange();
                Console.WriteLine($"{chart.Name}: {range}");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"{chart.Name}: The chart does not use a workbook as its data source.");
            }
        }
    }
}
```

## **อ่านและเขียนข้อมูลแผนภูมิจากเวิร์กบุ๊ก**

Aspose.Slides for .NET มีเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) และ [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) ที่ให้คุณอ่านและเขียนเวิร์กบุ๊กข้อมูลแผนภูมิ (ซึ่งอาจแก้ไขด้วย Aspose.Cells) **หมายเหตุ** ว่าข้อมูลแผนภูมิต้องจัดเรียงในลักษณะเดียวกันหรือมีโครงสร้างคล้ายกับต้นทาง

ตัวอย่างนี้ใช้ไฟล์นำเสนอที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรก อ่านเวิร์กบุ๊กฝังเข้าเป็นสตรีม ล้างชุดข้อมูลและหมวดหมู่เดิม แล้วเขียนเวิร์กบุ๊กเดิมกลับเข้าไป การเปลี่ยนแปลงจะคงอยู่ในหน่วยความจำ ตัวอย่างไม่ได้บันทึกไฟล์นำเสนอ

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

### **ตรวจสอบโครงสร้างแผนภูมิหลังการแก้ไขเวิร์กบุ๊ก**

เมื่อคุณแทนที่เวิร์กบุ๊กฝังด้วยเวิร์กบุ๊กรุ่นใหม่ แผนภูมิอาจยังคงมีชุดข้อมูลและคอลเลกชันหมวดเดิมที่ไม่ตรงกัน สิ่งนี้อาจทำให้ [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) ล้มเหลวด้วยข้อผิดพลาดดัชนีอยู่นอกช่วง ลบชุดข้อมูลและหมวดเดิมก่อนเขียนเวิร์กบุ๊กรุ่นใหม่กลับเข้าแผนภูมิ ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรก คอมเมนต์ระบุจุดที่จะแก้ไขเวิร์กบุ๊ก; ตัวอย่างที่ทำงานได้จะเขียนเวิร์กบุ๊กดั้งเดิมกลับและตรวจสอบโครงสร้างในหน่วยความจำ

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

    // แก้ไขสตรีมเวิร์กบุ๊กที่นี่, ตัวอย่างเช่น, ใช้ Aspose.Cells.

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

การลบคอลเลกชันจะลบการอ้างอิงข้อมูลที่ค้างอยู่ก่อนที่เวิร์กบุ๊กจะถูกเขียนกลับ สร้างชุดข้อมูลและการแมปหมวดใหม่ตามเวิร์กบุ๊กที่อัปเดตก่อนใช้แผนภูมิ

## **เลือกวิธีจัดเก็บป้ายกำกับหมวด**

ตั้งค่า [IChartCategoryCollection.UseCells](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategorycollection/usecells/) บนคอลเลกชันหมวดเปล่า ก่อนเพิ่มป้ายกำกับ ใช้เซลล์ของเวิร์กชีตสำหรับป้ายกำกับที่อ้างอิงข้อมูลจากเวิร์กบุ๊กหรือสร้างลำดับชั้น เช่น ไตรมาสที่จัดกลุ่มตามปี ใช้สตริงลิเทรัลสำหรับระดับเดียวของป้ายกำกับที่ไม่ต้องอ้างอิงเซลล์ การตั้งค่านี้ใช้ได้เฉพาะกับหมวดเท่านั้น แผนภูมิทั้งสองด้านล่างใช้เซลล์เวิร์กชีตสำหรับค่าตัวเลขของชุดข้อมูล

ตัวอย่างสร้างแผนภูมิคอลัมน์สองแบบและพิมพ์ `Q1 Q2 Q3 Q4` พร้อมโหมดการจัดเก็บ สำหรับป้ายกำกับที่อิงเวิร์กชีต [IChartCategory.AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/ascell/) ให้เข้าถึงเซลล์พื้นฐานและ [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) คืนค่าป้ายกำกับ สำหรับป้ายกำหนดแบบลิเทรัล ให้อ่านสตริงโดยตรงจาก [IChartCategory.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/value/)

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

foreach (var useCells in new[] { true, false })
{
    var x = useCells ? 20 : 360;
    var chart = shapes.AddChart(ChartType.ClusteredColumn, x, 20, 320, 250);
    var data = chart.ChartData;
    data.Series.Clear();
    data.Categories.Clear();
    data.Categories.UseCells = useCells;

    var workbook = data.ChartDataWorkbook;
    var seriesName = workbook.GetCell(0, 0, 1, "Sales");
    var series = data.Series.Add(seriesName, chart.Type);
    for (var row = 1; row <= 4; row++)
    {
        var label = $"Q{row}";
        if (useCells)
        {
            var labelCell = workbook.GetCell(0, row, 0, label);
            data.Categories.Add(labelCell);
        }
        else
        {
            data.Categories.Add(label);
        }

        var valueCell = workbook.GetCell(0, row, 1, row * 10);
        series.DataPoints.AddDataPointForBarSeries(valueCell);
    }

    Console.Write($"UseCells = {data.Categories.UseCells}:");
    foreach (var category in data.Categories)
    {
        var label = data.Categories.UseCells ? category.AsCell.Value : category.Value;
        Console.Write($" {label}");
    }
    Console.WriteLine();
}

presentation.Save("category-labels.pptx", SaveFormat.Pptx);
```

## **กำหนดรูปแบบตัวเลขแบบกำหนดเองสำหรับเซลล์ของเวิร์กบุ๊ก**

ใช้ [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) เพื่อควบคุมวิธีการแสดงค่าตัวเลขในเวิร์กบุ๊กฝังของแผนภูมิ ตัวอย่างเช่น รายงานอาจต้องแสดงอัตราแปลงเป็นเปอร์เซ็นต์กับทศนิยมสี่ตำแหน่งและค่าสัมประสิทธิ์กับทศนิยมห้าตำแหน่ง ควรรักษาค่าทั้งสองเป็นตัวเลขเพื่อให้ยังคงใช้ในการคำนวณและการวาดแผนภูมิได้

รูปแบบตัวเลขเปลี่ยนการแสดงผล ไม่ได้เปลี่ยนค่าที่จัดเก็บ รูปแบบ `0.0000%` จะทำให้ `0.125` แสดงเป็น `12.5000%` แต่ไม่ได้แทนที่ค่าที่จัดเก็บด้วย `12.5` เช่นกัน `0.00000` จะแสดง `0.1234567` เป็น `0.12346` โดยไม่ปัดเศษค่าเก็บ ถ้ารูปแบบกำหนดเองเป็นสตริงว่าง (`""`) จะใช้ [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) แทน

ตัวอย่างต่อไปสร้างแผนภูมิคอลัมน์และเข้าถึงเซลล์ผ่าน [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) บนเวิร์กชีต 0 B2 มีอัตราแปลงและ C2 มีค่าสัมประสิทธิ์ ทั้งสองเซลล์ใช้เป็นค่าแผนภูมิ ตัวอย่างยังเปิดใช้งานป้ายค่าที่เชื่อมโยงกับรูปแบบต้นทาง

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 270, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
chart.HasTitle = false;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.NumberFormat = "0.00";
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = 0;

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

var categoryCell = workbook.GetCell(0, "A2", "Sample");
chart.ChartData.Categories.Add(categoryCell);

var percentageCell = workbook.GetCell(0, "B2", 0.125);
percentageCell.CustomNumberFormat = "0.0000%";
var percentageName = workbook.GetCell(0, "B1", "Conversion rate");
var percentageSeries = chart.ChartData.Series.Add(percentageName, chart.Type);
percentageSeries.DataPoints.AddDataPointForBarSeries(percentageCell);

var precisionCell = workbook.GetCell(0, "C2", 0.1234567);
precisionCell.CustomNumberFormat = "0.00000";
var precisionName = workbook.GetCell(0, "C1", "Coefficient");
var precisionSeries = chart.ChartData.Series.Add(precisionName, chart.Type);
precisionSeries.DataPoints.AddDataPointForBarSeries(precisionCell);

foreach (var series in chart.ChartData.Series)
{
    var labelFormat = series.DataPoints[0].Label.DataLabelFormat;
    labelFormat.ShowValue = true;
    labelFormat.IsNumberFormatLinkedToSource = true;
}

presentation.Save("CustomCellFormats.pptx", SaveFormat.Pptx);
```

รูปแบบเซลล์ของเวิร์กบุ๊กแยกจากรูปแบบที่ตั้งโดยตรงบนแกนหรือป้ายข้อมูล ในตัวอย่างนี้แต่ละป้ายแสดงค่าจากเซลล์ต้นทางเนื่องจาก [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) เปิดใช้งานและเชื่อมโยงรูปแบบตัวเลขด้วย [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) เป็น `true` หลังจากบันทึกและเปิดไฟล์นำเสนอใหม่ ป้ายจะแสดง `12.5000%` และ `0.12346` ตามภาพด้านล่าง แกนแนวตั้งใช้ [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) ของตัวเองคือ `0.00` พร้อมตั้งค่า [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) เป็น `false`

หากต้องการฟอร์แมตป้ายข้อมูลโดยอิสระ ตั้งค่าสถานะเชื่อมโยงเป็น `false` แล้วกำหนด [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) ของป้ายเอง ซึ่งจะไม่เปลี่ยนรูปแบบของเซลล์เวิร์กบุ๊ก ตัวอย่างเช่น รูปแบบอิสระ `0.00` จะทำให้ค่าตัวแรกแสดงเป็น `0.13` ในขณะที่ B2 ยังคงแสดง `12.5000%` ดูที่ [Chart Data Labels](/slides/th/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) สำหรับการฟอร์แมตป้ายโดยตรง

ภาพด้านล่างสร้างจากไฟล์นำเสนอที่บันทึกแล้วและเปิดใหม่:

![แผนภูมิคอลัมน์ที่มีป้ายเชื่อมโยงต้นทางแสดง 12.5000% และ 0.12346 พร้อมแกนแนวตั้งที่ฟอร์แมตแบบอิสระ.](custom-cell-formats.png)

## **ตั้งค่าเซลล์ของเวิร์กบุ๊กเป็นป้ายข้อมูลแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์ของเวิร์กบุ๊กเป็นป้ายข้อมูลแผนภูมิได้

ตัวอย่างนี้เพิ่มแผนภูมิบับเบิลด้วยข้อมูลเริ่มต้นบนสไลด์แรกของไฟล์นำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บนเวิร์กชีต 0 เป็นป้ายสามรายการแรกของชุดข้อมูลแรก เปิดใช้งานป้ายจากเซลล์และบันทึกไฟล์นำเสนอที่อัปเดต

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

## **จัดการเวิร์กชีต**

คุณสมบัติ [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) ให้เข้าถึงเวิร์กชีตในเวิร์กบุ๊กของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิปายกับข้อมูลเริ่มต้นและพิมพ์ชื่อแต่ละเวิร์กชีตลงคอนโซล

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

## **ระบุประเภทของแหล่งข้อมูล**

ค่าจุดของชุดข้อมูลอาจจัดเก็บเป็นลิเทรัลตัวเลขโดยตรง ดูที่ [Set Series Values Using Numeric Literals](/slides/th/net/chart-series/#set-series-values-using-numeric-literals) สำหรับตัวอย่างครบถ้วนที่บันทึกและอ่านค่าดังกล่าว ประเภทของแหล่งข้อมูลสำหรับค่าจุดแยกจากการกำหนดเวิร์กบุ๊กภายในหรือภายนอกของแผนภูมิ; การใช้ลิเทรัลตัวเลขไม่ได้ลบเวิร์กบุ๊กฝังโดยอัตโนมัติ

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติด้วยข้อมูลเริ่มต้นและตั้งชื่อชุดข้อมูลสองชุดโดยใช้แหล่งข้อมูลที่ต่างกัน ชื่อแรกใช้ลิเทรัลสตริง; ชื่อที่สองอ้างอิงเซลล์ C1 บนเวิร์กชีต 0 ตัวเลือก [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) กำหนดแหล่งข้อมูลสำหรับแต่ละชื่อ ตัวอย่างบันทึกไฟล์นำเสนอพร้อมชื่อชุดข้อมูลที่อัปเดต

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

## **ตรวจจับรูปแบบเวิร์กบุ๊กฝังที่ไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบเวิร์กบุ๊ก Excel แบบไบนารี (.xlsb) ที่อาจฝังในบางแผนภูมิ คุณสามารถใช้คุณสมบัติ [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) บน [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) ร่วมกับการนับประเภท [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) เพื่อค้นหารูปแบบที่ไม่รองรับและข้ามแผนภูมินั้น ตัวอย่างตรวจสอบรูปร่างบนสไลด์แรกของไฟล์นำเสนอที่มีอยู่ ข้ามรูปร่างที่ไม่ใช่แผนภูมิและพิมพ์ข้อความวินิจฉัยสำหรับแผนภูมิที่มีเวิร์กบุ๊ก .xlsb ฝังอยู่

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

    // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กแผนภูมิที่รองรับที่นี่.
}
```

## **เวิร์กบุ๊กภายนอก**

Aspose.Slides รองรับการใช้เวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของแผนภูมิ

### **สร้างเวิร์กบุ๊กภายนอก**

ใช้ [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) และ [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) เพื่อนำออกเวิร์กบุ๊กแผนภูมิฝังเป็นไฟล์และเชื่อมแผนภูมิกับเวิร์กบุ๊กภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิปายด้วยข้อมูลเริ่มต้นและส่งออกเวิร์กบุ๊กของมัน ปิดสตรีมผลลัพธ์ก่อนกำหนดเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของแผนภูมิ แล้วบันทึกไฟล์นำเสนอที่เชื่อมโยง

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

### **ตั้งค่าเวิร์กบุ๊กภายนอก**

โดยใช้เมธอด [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) คุณสามารถกำหนดเวิร์กบุ๊กภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตพาธของเวิร์กบุ๊กภายนอก (หากเวิร์กบุ๊กนั้นถูกย้ายไป)

แม้ว่าคุณจะไม่สามารถแก้ไขข้อมูลในเวิร์กบุ๊กที่จัดเก็บในที่ตั้งระยะไกลหรือทรัพยากรได้ แต่ยังสามารถใช้เวิร์กบุ๊กรูปแบบดังกล่าวเป็นแหล่งข้อมูลภายนอก หากระบุพาธสัมพันธ์สำหรับเวิร์กบุ๊กภายนอก ระบบจะเปลี่ยนเป็นพาธเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้เวิร์กบุ๊กภายนอกที่เวิร์กชีตชื่อ `Sheet1` มีชื่อชุดข้อมูลใน B1, ชื่อหมวดใน A2:A4 และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิปาย, เชื่อมเวิร์กบุ๊ก, และใช้ [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) เพื่อแมป A1:B4 เป็นชุดข้อมูลหนึ่งและสามหมวด บันทึกไฟล์นำเสนอพร้อมแผนภูมิเชื่อมโยง

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

พารามิเตอร์ `updateChartData` ของเมธอด [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) ควบคุมว่าจะโหลดเวิร์กบุ๊กหรือไม่

* เมื่อ `updateChartData` เป็น `false` จะอัปเดตเฉพาะพาธของเวิร์กบุ๊ก แผนภูมิจะไม่โหลดหรืออัปเดตข้อมูลจากเวิร์กบุ๊กเป้าหมาย ดังนั้นเวิร์กบุ๊กอาจไม่มีอยู่
* เมื่อ `updateChartData` เป็น `true` แผนภูมิจะอัปเดตข้อมูลจากเวิร์กบุ๊กเป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวแทนพร้อม `updateChartData` เท่ากับ `false` จะคงข้อมูลเริ่มต้นของแผนภูมิปายและบันทึกไฟล์นำเสนอโดยไม่โหลดเวิร์กบุ๊กที่ไม่มีอยู่

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

### **รับพาธของเวิร์กบุ๊กแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุเวิร์กบุ๊กที่เชื่อมโยงกับแผนภูมิ ตรวจสอบว่าแผนภูมิกำลังใช้แหล่งข้อมูลภายนอกหรือไม่ และดึงพาธของเวิร์กบุ๊กได้

ตัวอย่างนี้ตรวจสอบรูปร่างแรกบนสไลด์แรกของไฟล์นำเสนอที่เชื่อมโยงเวิร์กบุ๊กภายนอก หากเป็นแผนภูมิกับเวิร์กบุ๊กภายนอก ตัวอย่างจะแสดง [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) บนคอนโซล แล้วบันทึกสำเนาของไฟล์นำเสนอ

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

คุณสามารถแก้ไขข้อมูลในเวิร์กบุ๊กภายนอกได้เช่นเดียวกับการเปลี่ยนแปลงข้อมูลในเวิร์กบุ๊กภายใน หากเวิร์กบุ๊กภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและเชื่อมกับเวิร์กบุ๊กภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่อ้างอิงเซลล์ของจุดข้อมูลแรกในชุดข้อมูลแรกเป็น 100 และบันทึกไฟล์นำเสนอที่อัปเดต การแก้ไขค่าเซลล์อาจอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยง ดังนั้นควรใช้สำเนาหากต้องการเก็บเวิร์กบุ๊กต้นฉบับไว้

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

## **รีเฟรชข้อมูลแผนภูมิจากเวิร์กบุ๊กต้นทาง**

Aspose.Slides for .NET 26.11 เพิ่มเมธอด [IChartData.RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) สำหรับแผนภูมิเดียวและ [IPresentation.RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) สำหรับไฟล์นำเสนอทั้งหมด ใช้เมธอดเหล่านี้หลังจากค่าของเวิร์กบุ๊กต้นทางเปลี่ยนแปลง เวิร์กบุ๊กภายนอกต้องสามารถเข้าถึงและรองรับ

เมื่อมีการติดตั้ง [Aspose.Slides for .NET](/slides/th/net/installation/) เวอร์ชัน 26.11 หรือใหม่กว่า ตัวอย่างนี้รีเฟรชแผนภูมิแรกบนสไลด์แรกของ `charts.pptx` เวิร์กบุ๊กต้นทางต้องพร้อมใช้งาน บันทึกผลลัพธ์เพื่อคงข้อมูลแผนภูมิที่อัปเดต

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
var chart = presentation.Slides[0].Shapes.OfType<IChart>().FirstOrDefault();
if (chart == null)
{
    Console.WriteLine("The first slide must contain a chart.");
    return;
}

chart.ChartData.RefreshData();
presentation.Save("refreshed-chart.pptx", SaveFormat.Pptx);
```

เพื่อรีเฟรชทุกแผนภูมิ ให้สร้างอินสแตนซ์ไฟล์นำเสนอแยกต่างหากดังต่อไปนี้ การส่ง `false` ทำให้ข้อผิดพลาดการรีเฟรชถูกส่งต่อไปยังผู้เรียกใช้; ไม่ได้ทำการย้อนกลับแผนภูมิที่รีเฟรชแล้ว

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
presentation.RefreshChartsData(skipFailedCharts: false);
presentation.Save("refreshed-charts.pptx", SaveFormat.Pptx);
```

พารามิเตอร์นี้มีค่าเริ่มต้นเป็น `true`: [RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) จะข้ามแผนภูมิที่ล้มเหลวและดำเนินการต่อกับแผนภูมิอื่น ๆ ไม่ได้คืนผลลัพธ์ต่อแผนภูมิโดยเฉพาะ ดังนั้นการเรียกที่สำเร็จไม่ได้รับประกันว่าแต่ละแผนภูมิรีเฟรชชสำเร็จ ใช้การเรียก [RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) แยกกันหากต้องการระบุแผนภูมิที่ล้มเหลวแต่ละอัน

การรีเฟรชโหลดข้อมูลต้นทางใหม่ ซึ่งแยกจากการคำนวนสูตร การตรวจสอบโครงสร้างแผนภูมิ และการอัปเดตพรีวิว OLE ตรวจสอบค่าที่อ้างอิงเซลล์ในหน่วยความจำเพื่อยืนยันการรีเฟรช ค่าที่แคชไว้ [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) ยังคงอธิบายแผนภูมิที่บันทึกไว้จนกว่าจะบันทึกและเปิดไฟล์นำเสนอใหม่

### **อ่านค่าที่แคชของแผนภูมิโดยไม่มีเวิร์กบุ๊ก**

ใน .NET 26.11 ตัวเข้าถึงค่าแคชจะอ่านค่าที่จัดเก็บกับแผนภูมิโดยไม่ต้องเปิดเวิร์กบุ๊กของมัน มีประโยชน์เมื่อไฟล์ที่เชื่อมโยงไม่พร้อมและคุณต้องการข้อมูลที่บันทึกล่าสุดของแผนภูมิ เทียบกับการสร้างเวิร์กบุ๊กใหม่จากตัวเลือกการกู้คืนด้านล่าง

| วัตถุ | ตัวเข้าถึงแคช |
| --- | --- |
| จุดข้อมูลชุดทั่วไป | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) |
| จุดข้อมูลกระจายหรือบับเบิล | [CachedXValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedxvalue/), [CachedYValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedyvalue/) |
| จุดข้อมูลบับเบิล | [CachedBubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedbubblesize/) |
| หมวดของแผนภูมิ | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/cachedvalue/) |

แต่ละตัวเข้าถึงจะคืนค่า [ICachedChartValue](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/) โดย [Data](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/data/) ให้ข้อมูลที่จัดเก็บ; [ToString](https://reference.aspose.com/slides/net/aspose.slides.charts/cachedchartvalue/tostring/) ให้ข้อความ; [ToDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/todouble/) คืน `NaN` สำหรับค่าที่ไม่มีหรือไม่ใช่ตัวเลข แคชอาจหายหรือเก่า รวมถึงบนแผนภูมิเฉพาะที่ยังไม่บันทึก อย่าเชื่อว่าฟิลด์ทุกอย่างมีอยู่หรือเป็นตัวเลข

ตัวอย่างนี้อ่านฟิลด์ทั้งหมดจาก `cached-chart.pptx` ไฟล์นำเสนอที่บันทึกไว้และมีแผนภูมิ แม้ไม่มีเวิร์กบุ๊กภายนอกก็ยอมรับได้เพราะโค้ดไม่ได้เข้าถึง [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) หรือเซลล์เวิร์กบุ๊กสด

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

using var presentation = new Presentation("cached-chart.pptx");
foreach (var slide in presentation.Slides)
foreach (var shape in slide.Shapes)
{
    if (shape is not IChart chart)
        continue;

    foreach (var category in chart.ChartData.Categories)
        PrintCache("Category", category.CachedValue);

    foreach (var series in chart.ChartData.Series)
    foreach (var point in series.DataPoints)
    {
        PrintCache("Value", point.CachedValue);
        PrintCache("X", point.CachedXValue);
        PrintCache("Y", point.CachedYValue);
        PrintCache("Bubble size", point.CachedBubbleSize);
    }
}

static void PrintCache(string name, ICachedChartValue value)
{
    var number = value.ToDouble();
    if (value.Data == null)
        Console.WriteLine($"{name}: no cached value");
    else if (double.IsNaN(number))
        Console.WriteLine($"{name}: {value} (not numeric)");
    else
        Console.WriteLine($"{name}: {number}");
}
```

ใช้รีเฟรชเมื่อคุณต้องการข้อมูลต้นทางปัจจุบัน ใช้การอ่านแคชเมื่อข้อมูลที่บันทึกไว้เพียงพอ แคชไม่ใชสำเนาครบถ้วนของเวิร์กบุ๊กและไม่สามารถให้การเปลี่ยนแปลงที่ทำหลังจากการอัปเดตล่าสุดได้

### **กู้คืนเวิร์กบุ๊กจากแคชของแผนภูมิ**

หากแผนภูมิใช้เวิร์กบุ๊กภายนอกที่หายไปหรือไม่สามารถเข้าถึงได้ Aspose.Slides สามารถสร้างเวิร์กบุ๊กแผนภูมิจากข้อมูลที่แคชไว้ในไฟล์นำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) ตั้งค่า [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) และเปิดใช้ [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) ให้เป็น `true` ก่อนเปิดไฟล์นำเสนอ

ตัวอย่าง C# ด้านล่างกู้คืนข้อมูลเวิร์กบุ๊กสำหรับแผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและอ้างอิงเวิร์กบุ๊กภายนอกที่ไม่มีอยู่ เข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) และ [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

    // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กที่กู้คืนที่นี่.
}
else
{
    Console.WriteLine("The first shape is not a chart.");
}
```

หากโค้ดพยายามเข้าถึงเวิร์กบุ๊กภายนอกขณะไม่มีและการกู้คืนปิดอยู่ Aspose.Slides จะโยน [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) ให้เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแคชของแผนภูมิเป็นทางเลือกที่ยอมรับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในเวิร์กบุ๊กภายนอกหลังจากไฟล์นำเสนออัปเดตครั้งล่าสุด

## **FAQ**

**ฉันสามารถตรวจสอบได้หรือไม่ว่าแผนภูมิใดเชื่อมโยงกับเวิร์กบุ๊กภายนอกหรือเวิร์กบุ๊กฝัง?**

ได้ แผนภูมิมี [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) หากเป็นแหล่งข้อมูลภายนอก สามารถอ่านพาธเต็มเพื่อยืนยันไฟล์ภายนอกที่ใช้

**รองรับพาธแบบสัมพันธ์สำหรับเวิร์กบุ๊กภายนอกหรือไม่ และเก็บอย่างไร?**

รองรับ หากระบุพาธสัมพันธ์ ระบบจะเปลี่ยนเป็นพาธเต็มโดยอัตโนมัติ ไฟล์นำเสนอเก็บพาธเต็มในไฟล์ PPTX ดังนั้นการย้ายเวิร์กบุ๊กอาจต้องอัปเดตลิงก์

**สามารถใช้เวิร์กบุ๊กที่อยู่บนเครือข่ายหรือแชร์ได้หรือไม่?**

ได้ เวิร์กบุ๊กเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขเวิร์กบุ๊กระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน — สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกไฟล์นำเสนอหรือไม่?**

ไฟล์นำเสนอเก็บ [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) การแก้ไขค่าที่อ้างอิงเซลล์ในแผนภูมิอาจอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยง ใช้สำเนาเวิร์กบุ๊กหากต้องการให้ไฟล์ต้นฉบับคงอยู่ไม่เปลี่ยน

**ต้องทำอย่างไรถ้าไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อเชื่อมโยง วิธีทั่วไปคือถอดรหัสล่วงหน้าหรือสร้างสำเนาที่ไม่ป้องกัน (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/net/)) แล้วเชื่อมโยงไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงเวิร์กบุ๊กภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียว การอัปเดตไฟล์นั้นจะสะท้อนในทุกแผนภูมิในครั้งต่อไปที่โหลดข้อมูล