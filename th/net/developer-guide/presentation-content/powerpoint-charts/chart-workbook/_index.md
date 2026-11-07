---
title: จัดการเวิร์กบุ๊กแผนภูมิในการนำเสนอด้วย .NET
linktitle: เวิร์กบุ๊กแผนภูมิ
type: docs
weight: 70
url: /th/net/chart-workbook/
keywords:
- เวิร์กบุ๊กแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์เวิร์กบุ๊ก
- ป้ายกำกับข้อมูล
- แผ่นงาน
- แหล่งข้อมูล
- เวิร์กบุ๊กภายนอก
- ข้อมูลภายนอก
- แคชแผนภูมิ
- การกู้คืนเวิร์กบุ๊ก
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบ Aspose.Slides สำหรับ .NET: จัดการเวิร์กบุ๊กแผนภูมิในรูปแบบ PowerPoint และ OpenDocument ได้อย่างง่ายดายเพื่อปรับปรุงข้อมูลการนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับแผนภูมิในรูปแบบเวิร์กบุ๊กของ Aspose.Slides แสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของเวิร์กบุ๊ก ใช้เซลล์ของเวิร์กบุ๊กเป็นป้ายกำกับข้อมูลแผนภูมิ เข้าถึงคอลเลกชันของแผ่นงาน และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างจะแสดงวิธีสร้างและกำหนดเวิร์กบุ๊กภายนอก ดึงพาธของเวิร์กบุ๊กภายนอกที่เชื่อมโยงกับแผนภูมิ และแก้ไขข้อมูลแผนภูมิเมื่อเวิร์กบุ๊กพร้อมใช้งาน

สำหรับเซลล์เวิร์กบุ๊กที่เป็นค่าหายไป ดูที่ [Control the Display of Empty Cells](/slides/th/net/chart-series/) เพื่อเรียนรู้ความแตกต่างระหว่างเซลล์ว่างและศูนย์ รวมถึงการเปรียบเทียบแบบกราฟเส้นของโหมดการแสดงผลที่มีให้เลือก

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อน**

ใช้ [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) เพื่อควบคุมว่ากราฟจะวางข้อมูลจากแถวและคอลัมน์ของแผ่นงานที่ซ่อนหรือไม่ ตั้งค่าเป็น `true` เพื่อวางเฉพาะเซลล์ที่มองเห็นได้ หรือ `false` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อน การตั้งค่านี้ควบคุมการวางกราฟเท่านั้น ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของแผ่นงาน

[ตัวอย่างการนำเสนอ](hidden-source-data.pptx) มีกราฟคอลัมน์เป็นรูปทรงแรกบนสไลด์แรก แผ่นงานที่ฝังอยู่ `Sheet1` มีช่วงข้อมูลต้นฉบับ `A1:C4` แถวที่ 3 และคอลัมน์ C ถูกซ่อนไว้ แต่เซลล์ยังมีค่าอยู่

| แถวของแผ่นงาน | A: เดือน | B: รายละเอียดการขายปลีก | C: รายละเอียดการขายส่ง (คอลัมน์ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์ต้นฉบับผ่าน [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) และอ่านคุณสมบัติ [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) เพื่อดูสถานะการซ่อนของเซลล์นั้น ๆ คุณสมบัตินี้เป็นแบบอ่านอย่างเดียว ในไฟล์นี้ B2 สามารถมองเห็นได้, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างจะพิมพ์ `False`, `True`, `True` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลกราฟหลังจากเปลี่ยนการตั้งค่าการวาง: รักษาเวิร์กบุ๊กที่ฝังอยู่ด้วย [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) แล้วโหลดกลับด้วย [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) เมื่อรวมทุกเซลล์ให้ใช้ [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) เพื่อกู้คืนช่วงเต็มรวมถึงหมวด “February” ที่ซ่อนอยู่ การเปลี่ยนค่าแฟล็กอย่างเดียวไม่เพียงพอที่จะรีเฟรชแคชข้อมูลกราฟและป้ายกำกับหมวดในตัวอย่างนี้

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

        // รีเฟรชข้อมูลแผนภูมิจากเวิร์กบุ๊กที่ฝังอยู่.
        workbookStream.Position = 0;
        chart.ChartData.WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // กู้คืนช่วงแหล่งข้อมูลทั้งหมดรวมถึงหมวดที่ซ่อนอยู่.
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

ตัวอย่างบันทึกสองเวอร์ชันของการนำเสนอ: เวอร์ชันหนึ่งมีเฉพาะค่าปลีกที่มองเห็นได้ (10 และ 20) อีกเวอร์ชันหนึ่งมีค่าทั้งหกค่า รูปภาพด้านล่างได้มาจากการแสดงผลของไฟล์ที่บันทึกแล้วหลังจากเปิดใหม่; ทั้งสองไฟล์คงค่าการตั้งค่าการวางไว้ แถวที่ 3 และคอลัมน์ C ยังคงซ่อนอยู่ในทั้งสองเวิร์กบุ๊กที่ฝังอยู่

| เฉพาะเซลล์ที่มองเห็น (`true`) | ทุกเซลล์ (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

เซลล์ที่ซ่อนอยู่ซึ่งมีค่าแตกต่างจากเซลล์ว่าง [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) ควบคุมวิธีการแสดงค่าที่หายไป; ไม่ได้รวมหรือยกเว้นข้อมูลต้นฉบับที่ซ่อน ดูที่ [Control the Display of Empty Cells](/slides/th/net/chart-series/#control-the-display-of-empty-cells) เพื่อดูตัวอย่าง

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนอัปเดตข้อมูลเวิร์กบุ๊กในงานนำเสนอที่มีอยู่ ให้ตรวจสอบช่วงต้นฉบับเพื่อระบุว่าแผ่นงานใดบ้างที่แต่ละแผนภูมิใช้ วิธี [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) จะคืนค่าช่วงข้อมูลปัจจุบันในรูปสูตรที่อ้างอิงถึงแผ่นงาน เช่น `Sheet1!$A$1:$D$5` โดย `Sheet1` คือชื่อแผ่นงาน, `!` แยกจากช่วงเซลล์, `$A$1:$D$5` ระบุเซลล์จาก A1 ถึง D5 รวมถึงเครื่องหมายดอลลาร์ที่บ่งบอกการอ้างอิงแบบสัมบูรณ์

เมธอดนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือเวิร์กบุ๊ก หากแผนภูมิไม่ได้ใช้เวิร์กบุ๊กเป็นแหล่งข้อมูล จะเกิดข้อผิดพลาด [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) ดูข้อมูลเพิ่มเติมได้จาก [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/)

ตัวอย่างนี้เปิดงานนำเสนอและตรวจสอบรูปทรงบนแต่ละสไลด์เพื่อค้นหาแผนภูมิ พิมพ์ชื่อและช่วงต้นฉบับของแต่ละแผนภูมิ หากแผนภูมิไม่ได้ใช้เวิร์กบุ๊ก จะพิมพ์ข้อความและดำเนินการต่อไปยังแผนภูมถัดไป

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

Aspose.Slides for .NET มีเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) และ [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) ที่ช่วยให้คุณอ่านและเขียนเวิร์กบุ๊กข้อมูลแผนภูมิ (ซึ่งอาจถูกแก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิต้องจัดเรียงในรูปแบบเดียวกันหรือมีโครงสร้างที่คล้ายกับแหล่งข้อมูลต้นฉบับ

ตัวอย่างนี้ใช้การนำเสนอที่มีแผนภูมิกเป็นรูปทรงแรกบนสไลด์แรก อ่านเวิร์กบุ๊กที่ฝังอยู่ลงสตรีม, เคลียร์ชุดข้อมูลและหมวดหมู่เดิม, จากนั้นเขียนเวิร์กบุ๊กเดิมกลับไป การเปลี่ยนแปลงยังคงอยู่ในหน่วยความจำ; ตัวอย่างไม่ได้บันทึกการนำเสนอ

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

เมื่อคุณแทนที่เวิร์กบุ๊กที่ฝังอยู่ด้วยเวิร์กบุ๊กที่แก้ไขแล้ว แผนภูมิจะยังคงมีชุดข้อมูลและคอลเลกชันหมวดเดิม การไม่ตรงกันนี้อาจทำให้ [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) ล้มเหลวด้วยข้อผิดพลาด “index‑out‑of‑range” ให้ล้างชุดข้อมูลและหมวดเดิมก่อนเขียนเวิร์กบุ๊กที่อัปเดตกลับไปแผนภูมิ ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปทรงแรกบนสไลด์แรก คอมเมนต์แสดงจุดที่ควรแก้ไขเวิร์กบุ๊ก; ตัวอย่างทำการเขียนเวิร์กบุ๊กต้นเดิมกลับและตรวจสอบโครงสร้างในหน่วยความจำ

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

    // แก้ไขสตรีมเวิร์กบุ๊กที่นี่, ตัวอย่างเช่น, โดยใช้ Aspose.Cells.

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

การล้างคอลเลกชันจะลบการอ้างอิงข้อมูลที่ตกรุ่นก่อนที่เวิร์กบุ๊กจะถูกเขียนกลับ ให้สร้างชุดข้อมูลและการแมปหมวดใหม่ตามเวิร์กบุ๊กที่อัปเดตก่อนนำแผนภูมิไปใช้

## **กำหนดรูปแบบตัวเลขแบบกำหนดเองสำหรับเซลล์เวิร์กบุ๊ก**

ใช้ [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) เพื่อควบคุมรูปแบบการแสดงค่าตัวเลขในเวิร์กบุ๊กที่ฝังอยู่ของแผนภูมิ ตัวอย่างเช่น รายงานอาจต้องการแสดงอัตราการแปลงเป็นเปอร์เซ็นต์ด้วยทศนิยมสี่ตำแหน่งและค่าสัมประสิทธิ์ด้วยทศนิยมห้าตำแหน่ง ให้เก็บค่าทั้งสองเป็นตัวเลขเพื่อให้ยังคงใช้คำนวณและวางกราฟได้

รูปแบบตัวเลขเปลี่ยนการแสดงผล ไม่เปลี่ยนค่าที่เก็บไว้ รูปแบบ `0.0000%` จะทำให้ค่า `0.125` แสดงเป็น `12.5000%` แต่ไม่ทำให้ตัวเลขที่เก็บเปลี่ยนเป็น `12.5` เช่นเดียวกัน `0.00000` จะทำให้ `0.1234567` แสดงเป็น `0.12346` โดยไม่ปัดเศษค่าที่เก็บไว้ หากรูปแบบกำหนดเองเป็นสตริงว่าง (`""`) จะใช้ [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) แทน

ตัวอย่างต่อไปสร้างแผนภูมิคอลัมน์และเข้าถึงเซลล์ผ่าน [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/). ที่แผ่นงาน 0, B2 มีอัตราการแปลงและ C2 มีค่าสัมประสิทธิ์ ทั้งสองเซลล์ให้ค่ากราฟ ตัวอย่างยังเปิดใช้งานป้ายกำกับค่าที่เชื่อมโยงกับรูปแบบต้นฉบับ

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

รูปแบบเซลล์เวิร์กบุ๊กแยกจากรูปแบบที่ตั้งโดยตรงบนแกนหรือป้ายกำกับข้อมูล ในตัวอย่างนี้แต่ละป้ายกำกับจะแสดงค่าจากเซลล์ต้นทางเนื่องจาก [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) ถูกเปิดใช้งาน และตามรูปแบบตัวเลขของเซลล์ต้นทางเพราะ [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) เป็น `true` หลังจากบันทึกและเปิดงานนำเสนอใหม่ ป้ายกำกับจะแสดง `12.5000%` และ `0.12346` ตามที่แสดงด้านล่าง แกนแนวตั้งใช้ [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) ของตัวเองเป็น `0.00` โดยตั้งค่า [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) เป็น `false`

เพื่อฟอร์แมตป้ายกำกับข้อมูลแยกออกมา ให้ตั้งค่าธงเชื่อมต่อกับแหล่งเป็น `false` แล้วกำหนด [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) ของป้ายกำกับ วิธีนี้จะไม่เปลี่ยนรูปแบบของเซลล์เวิร์กบุ๊ก ตัวอย่างเช่น ฟอร์แมตป้ายกำกับอิสระ `0.00` จะแสดงค่าแรกเป็น `0.13` ในขณะที่ B2 ยังคงแสดง `12.5000%` ดูที่ [Chart Data Labels](/slides/th/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) สำหรับการฟอร์แมตป้ายโดยตรง

รูปภาพด้านล่างได้มาจากการแสดงผลของงานนำเสนอที่บันทึกแล้วหลังจากเปิดใหม่:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **กำหนดเซลล์เวิร์กบุ๊กเป็นป้ายกำกับข้อมูลของแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์เวิร์กบุ๊กเป็นป้ายกำกับข้อมูลของแผนภูมิได้

ตัวอย่างนี้เพิ่มแผนภูมิบับเบิลที่มีข้อมูลเริ่มต้นบนสไลด์แรกของงานนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บนแผ่นงาน 0 เป็นป้ายชื่อสามอันแรกในชุดข้อมูลแรก เปิดใช้งานป้ายจากเซลล์และบันทึกงานนำเสนอที่อัปเดตแล้ว

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

## **จัดการแผ่นงาน**

คุณสมบัติ [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) ให้เข้าถึงแผ่นงานในเวิร์กบุ๊กของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิวงกลมที่มีข้อมูลเริ่มต้นและพิมพ์ชื่อแผ่นงานแต่ละชื่อไปยังคอนโซล

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

ค่าจุดของชุดข้อมูลยังสามารถเก็บเป็นค่าตัวเลขโดยตรง ดูที่ [Set Series Values Using Numeric Literals](/slides/th/net/chart-series/#set-series-values-using-numeric-literals) สำหรับตัวอย่างสมบูรณ์ที่บันทึกและอ่านค่าเหล่านั้น ประเภทแหล่งข้อมูลของค่าจุดแยกจากการตั้งค่าเวิร์กบุ๊กภายในหรือภายนอกของแผนภูมิ; การใช้ค่าลิเทรัลตัวเลขเองไม่ได้ลบเวิร์กบุ๊กที่ฝังอยู่โดยอัตโนมัติ

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3 มิติที่มีข้อมูลเริ่มต้นและตั้งชื่อชุดข้อมูลสองชุดด้วยแหล่งข้อมูลที่แตกต่างกัน ชื่อแรกใช้ลิเทรัลสตริง; ชื่อที่สองใช้เซลล์ C1 บนแผ่นงาน 0 การนับประเภท [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) กำหนดแหล่งสำหรับแต่ละชื่อ ตัวอย่างบันทึกงานนำเสนอพร้อมชื่อชุดข้อมูลที่อัปเดต

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

## **ตรวจจับรูปแบบเวิร์กบุ๊กที่ฝังไม่ได้สนับสนุน**

Aspose.Slides ไม่สนับสนุนรูปแบบเวิร์กบุ๊ก Excel แบบไบนารี (.xlsb) ที่อาจฝังในบางแผนภูมิ คุณสามารถใช้คุณสมบัติ [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) บน [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) ร่วมกับการนับประเภท [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่สนับสนุนและข้ามแผนภูมิเหล่านั้น ตัวอย่างนี้ตรวจสอบรูปทรงบนสไลด์แรกของงานนำเสนอที่มีอยู่ ข้ามรูปทรงที่ไม่ใช่แผนภูมิ และพิมพ์ข้อความวินิจฉัยสำหรับแต่ละแผนภูมิที่มีเวิร์กบุ๊ก .xlsb ฝังอยู่

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

ใช้ [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) และ [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) เพื่อส่งออกเวิร์กบุ๊กของแผนภูมิที่ฝังอยู่เป็นไฟล์และเชื่อมแผนภูมิกับเวิร์กบุ๊กภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิเวราตัวอย่างที่มีข้อมูลเริ่มต้นและส่งออกเวิร์กบุ๊กของมัน ปิดสตรีมผลลัพธ์ก่อนกำหนดเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของแผนภูมิ จากนั้นบันทึกงานนำเสนอที่เชื่อมโยงแล้ว

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

### **กำหนดเวิร์กบุ๊กภายนอก**

โดยใช้เมธอด [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) คุณสามารถกำหนดเวิร์กบุ๊กภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลได้ เมธอดนี้ยังใช้เพื่ออัปเดตพาธไปยังเวิร์กบุ๊กภายนอก (หากไฟล์นั้นถูกย้าย)

แม้ว่าจะไม่สามารถแก้ไขข้อมูลในเวิร์กบุ๊กที่จัดเก็บในตำแหน่งระยะไกลหรือทรัพยากรได้ แต่ยังสามารถใช้เวิร์กบุ๊กเหล่านั้นเป็นแหล่งข้อมูลภายนอก หากให้พาธแบบสัมพันธ์กับเวิร์กบุ๊กภายนอก ระบบจะเปลี่ยนเป็นพาธเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้เวิร์กบุ๊กภายนอกที่มีแผ่นงานชื่อ `Sheet1` ซึ่งมีชื่อชุดข้อมูลใน B1, ชื่อหมวดใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิเวราตัวอย่าง, ลิงก์เวิร์กบุ๊ก, และใช้ [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) เพื่อแมป A1:B4 เป็นหนึ่งชุดข้อมูลและสามหมวด แล้วบันทึกงานนำเสนอพร้อมแผนภูมิที่เชื่อมโยง

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

พารามิเตอร์ `updateChartData` ของ [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) ควบคุมนำเข้าเวิร์กบุ๊กหรือไม่

* เมื่อ `updateChartData` เป็น `false` จะอัปเดตเฉพาะพาธของเวิร์กบุ๊ก เท่านั้น ไม่ได้โหลดหรืออัปเดตข้อมูลแผนภูมิจากเวิร์กบุ๊กเป้าหมาย ดังนั้นเวิร์กบุ๊กอาจไม่มีอยู่ได้
* เมื่อ `updateChartData` เป็น `true` จะอัปเดตข้อมูลแผนภูมิจากเวิร์กบุ๊กเป้าหมาย

ตัวอย่างต่อไปกำหนด URL ตัวล็อกโดยตั้งค่า `updateChartData` เป็น `false` เวิร์กบุ๊กภายนอกจึงไม่ได้โหลด ตัวอย่างยังคงใช้ข้อมูลเริ่มต้นของแผนภูมิเวราตัวอย่างและบันทึกงานนำเสนอโดยไม่โหลดเวิร์กบุ๊กที่ไม่มีอยู่

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

เพื่อระบุว่าแผนภูมิมีการเชื่อมต่อกับเวิร์กบุ๊กภายนอกหรือไม่ ให้ตรวจสอบว่ามีประเภทแหล่งข้อมูลภายนอกและดึงพาธเวิร์กบุ๊กออกมา

ตัวอย่างนี้ตรวจสอบรูปทรงแรกบนสไลด์แรกของงานนำเสนอที่มีเวิร์กบุ๊กภายนอกเชื่อมโยง หากเป็นแผนภูมิที่เชื่อมกับเวิร์กบุ๊กภายนอก ตัวอย่างจะพิมพ์ [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) ไปยังคอนโซล จากนั้นบันทึกสำเนาของงานนำเสนอ

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

คุณสามารถแก้ไขข้อมูลในเวิร์กบุ๊กภายนอกได้เช่นเดียวกับการแก้ไขข้อมูลในเวิร์กบุ๊กภายใน เมื่อเวิร์กบุ๊กภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปทรงแรกบนสไลด์แรกและเชื่อมโยงกับเวิร์กบุ๊กภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่อยู่ในเซลล์ของจุดข้อมูลแรกในชุดที่หนึ่งเป็น `100` แล้วบันทึกงานนำเสนอที่อัปเดต การแก้ไขค่าจากเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมโยงได้ ดังนั้นหากต้องการเก็บไฟล์ต้นฉบับไว้ ให้ใช้สำเนา

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

## **รีเฟรชข้อมูลแผนภูมิกจากเวิร์กบุ๊กแหล่งข้อมูล**

Aspose.Slides for .NET 26.11 เพิ่มเมธอด [IChartData.RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) สำหรับแผนภูมิเดียวและ [IPresentation.RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) สำหรับงานนำเสนอ ใช้เมธอดเหล่านี้หลังจากค่าของเวิร์กบุ๊กแหล่งข้อมูลเปลี่ยน แพ็คเวิร์กบุ๊กภายนอกต้องสามารถเข้าถึงและได้รับการสนับสนุน

เมื่อมีการติดตั้ง [Aspose.Slides for .NET](/slides/th/net/installation/) รุ่น 26.11 หรือใหม่กว่า ตัวอย่างนี้รีเฟรชแผนภูมิแรกบนสไลด์แรกของ `charts.pptx` เวิร์กบุ๊กแหล่งข้อมูลต้องพร้อมใช้งาน บันทึกผลลัพธ์เพื่อคงค่าที่อัปเดตของแผนภูมิ

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

เพื่อรีเฟรชทุกแผนภูมิ ใช้อินสแตนซ์งานนำเสนอแยกต่างหากตามนี้ การส่งค่า `false` ทำให้ความล้มเหลวของการรีเฟรชส่งต่อไปยังผู้เรียกและไม่ทำการย้อนกลับแผนภูมิที่รีเฟรชแล้ว

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("charts.pptx");
presentation.RefreshChartsData(skipFailedCharts: false);
presentation.Save("refreshed-charts.pptx", SaveFormat.Pptx);
```

พารามิเตอร์มีค่าเริ่มต้นเป็น `true`: [RefreshChartsData](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/refreshchartsdata/) จะข้ามแผนภูมิที่ล้มเหลวและดำเนินการต่อกับแผนภูมิอื่น ๆ ไม่ได้คืนค่าผลลัพธ์ต่อแผนภูมิ ดังนั้นการเรียกสำเร็จไม่ได้หมายความว่าแผนภูมิเพาะทุกอันรีเฟรชสำเร็จ ใช้การเรียก [RefreshData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/refreshdata/) แยกกันหากต้องการระบุแผนภูมิที่ล้มเหลว

รีเฟรชจะโหลดข้อมูลแหล่งข้อมูลใหม่ แยกจากการคำนวณสูตร, การตรวจสอบโครงสร้างแผนภูมิและการอัปเดตภาพตัวอย่าง OLE ตรวจสอบค่าที่อิงเซลล์แบบสดเพื่อยืนยันการรีเฟรชในหน่วยความจำ [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) ยังอาจอธิบายแผนภูมิที่บันทึกไว้ก่อนหน้า จนกว่าจะบันทึกและเปิดงานนำเสนอใหม่

### **อ่านค่าที่แคชของแผนภูมิโดยไม่มีเวิร์กบุ๊ก**

ใน .NET 26.11 ตัวเข้าถึงค่าแคชจะอ่านค่าที่บันทึกไว้กับแผนภูมิโดยไม่ต้องเปิดเวิร์กบุ๊กของมัน เหมาะเมื่อตัวไฟล์ที่เชื่อมโยงไม่พร้อมและต้องการข้อมูลสุดท้ายที่บันทึกไว้ ซึ่งต่างจากการสร้างเวิร์กบุ๊กใหม่ด้วยตัวเลือกการกู้คืนด้านล่าง

| วัตถุ | ตัวเข้าถึงแบบแคช |
| --- | --- |
| จุดข้อมูลชุดธรรมดา | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedvalue/) |
| จุดข้อมูลกระจายหรือบับเบิล | [CachedXValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedxvalue/), [CachedYValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedyvalue/) |
| จุดข้อมูลบับเบิล | [CachedBubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/cachedbubblesize/) |
| หมวดของแผนภูมิ | [CachedValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/cachedvalue/) |

แต่ละตัวเข้าถึงจะคืนค่า [ICachedChartValue](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/) [Data](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/data/) ให้ข้อมูลที่เก็บไว้; [ToString](https://reference.aspose.com/slides/net/aspose.slides.charts/cachedchartvalue/tostring/) ให้ข้อความ; [ToDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/icachedchartvalue/todouble/) คืนค่า `NaN` หากไม่มีค่าหรือค่าที่ไม่ใช่ตัวเลข แคชอาจหายหรือเก่า รวมถึงแผนภูมิที่สร้างใหม่แต่ยังไม่ได้บันทึก อย่าเชื่อว่าฟิลด์ทุกฟิลด์มีอยู่หรือเป็นตัวเลข

ตัวอย่างนี้อ่านฟิลด์ทั้งหมดจาก `cached-chart.pptx` งานนำเสนอที่บันทึกไว้และมีแผนภูมิ พาธของเวิร์กบุ๊กภายนอกที่หายไปเป็นที่ยอมรับได้เพราะโค้ดไม่ได้เข้าถึง [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) หรือเซลล์เวิร์กบุ๊กจริง

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

ใช้รีเฟรชเมื่อต้องการข้อมูลแหล่งที่เป็นปัจจุบัน; ใช้การอ่านแบบแคชเมื่อสแน็ปช็อตที่เก็บไว้เพียงพอ แคชไม่ใช่สำเนาครบของเวิร์กบุ๊กและไม่สามารถจัดหา การเปลี่ยนแปลงที่ทำหลังจากการอัปเดตล่าสุดได้

### **กู้คืนเวิร์กบุ๊กจากแคชของแผนภูมิ**

หากแผนภูมิใช้เวิร์กบุ๊กภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างเวิร์กบุ๊กของแผนภูมิจากข้อมูลที่แคชในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), ตั้งค่า [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/), และเปิดใช้งาน [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) เป็น `true` ก่อนเปิดงานนำเสนอ

ตัวอย่าง C# ด้านล่างกู้คืนข้อมูลเวิร์กบุ๊กสำหรับแผนภูมิที่เป็นรูปทรงแรกบนสไลด์แรกและอ้างอิงเวิร์กบุ๊กภายนอกที่ไม่อยู่ การเข้าถึงข้อมูลที่กู้คืนทำได้ผ่าน [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) และ [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

หากโค้ดพยายามเข้าถึงเวิร์กบุ๊กภายนอกขณะมันไม่พร้อมและการกู้คืนถูกปิดใช้งาน Aspose.Slides จะโยงข้อยกเว้น [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) เปิดใช้งานการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแคชของแผนภูมิเป็นทางเลือกที่ยอมรับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในเวิร์กบุ๊กภายนอกหลังจากงานนำเสนออัปเดตครั้งล่าสุด

## **FAQ**

**ฉันสามารถตรวจสอบได้ว่าแผนภูมิเฉพาะเชื่อมโยงกับเวิร์กบุ๊กภายนอกหรือเวิร์กบุ๊กที่ฝังไว้หรือไม่?**

ได้. แผนภูมิมี [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) หากแหล่งเป็นเวิร์กบุ๊กภายนอก คุณสามารถอ่านพาธเต็มเพื่อยืนยันว่ามีการใช้ไฟล์ภายนอก

**รองรับพาธสัมพันธ์กับเวิร์กบุ๊กภายนอกหรือไม่ และเก็บอย่างไร?**

ใช่. หากระบุพาธสัมพันธ์ ระบบจะเปลี่ยนเป็นพาธแน่นอนโดยอัตโนมัติ งานนำเสนอเก็บพาธแน่นอนในไฟล์ PPTX ดังนั้นการย้ายเวิร์กบุ๊กอาจต้องอัปเดตลิงก์

**สามารถใช้เวิร์กบุ๊กที่อยู่บนทรัพยากร/แชร์เครือข่ายได้หรือไม่?**

ได้, เวิร์กบุ๊กเหล่านั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขเวิร์กบุ๊กระยะไกลโดยตรงจาก Aspose.Slides ไม่ได้รับการสนับสนุน – สามารถใช้เป็นแหล่งข้อมูลเท่านั้น

**Aspose.Slides จะเขียนทับไฟล์ XLSX ภายนอกเมื่อบันทึกงานนำเสนอหรือไม่?**

งานนำเสนอเก็บ [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) การแก้ไขค่าที่อิงเซลล์ของแผนภูมิอาจอัปเดตไฟล์ XLSX ภายนอกด้วย ใช้สำเนาเวิร์กบุ๊กหากต้องการให้ไฟล์ต้นฉบับไม่เปลี่ยนแปลง

**หากไฟล์ภายนอกมีการป้องกันด้วยรหัสผ่าน ควรทำอย่างไร?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมโยง วิธีทั่วไปคือถอดการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสแล้ว (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/net/)) แล้วเชื่อมโยงกับสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงเวิร์กบุ๊กภายนอกเดียวกันได้หรือไม่?**

ได้. แต่ละแผนภูมิเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปยังไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในทุกแผนภูมิในครั้งถัดไปที่โหลดข้อมูล**