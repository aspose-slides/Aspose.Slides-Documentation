---
title: จัดการเวิร์กบุ๊กแผนภูมิในงานนำเสนอใน .NET
linktitle: เวิร์กบุ๊กแผนภูมิ
type: docs
weight: 70
url: /th/net/chart-workbook/
keywords:
- เวิร์กบุ๊กแผนภูมิ
- ข้อมูลแผนภูมิ
- เซลล์เวิร์กบุ๊ก
- ป้ายกำกับข้อมูล
- ชีตงาน
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
description: "ค้นพบ Aspose.Slides สำหรับ .NET: จัดการเวิร์กบุ๊กแผนภูมิในรูปแบบ PowerPoint และ OpenDocument อย่างง่ายดายเพื่อปรับปรุงข้อมูลงานนำเสนอของคุณ."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีทำงานกับเวิร์กบุ๊กของแผนภูมิใน Aspose.Slides โดยแสดงวิธีอ่านและเขียนข้อมูลแผนภูมิผ่านสตรีมของเวิร์กบุ๊ก ใช้เซลล์ของเวิร์กบุ๊กเป็นป้ายกำกับข้อมูลแผนภูมิ เข้าถึงคอลเลกชันของชีตงาน และระบุประเภทแหล่งข้อมูลสำหรับค่าของแผนภูมิ

นอกจากนี้ยังครอบคลุมการทำงานกับเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของแผนภูมิ ตัวอย่างแสดงวิธีสร้างและกำหนดเวิร์กบุ๊กภายนอก การดึงเส้นทางของเวิร์กบุ๊กภายนอกที่เชื่อมโยงกับแผนภูมิ และการแก้ไขข้อมูลแผนภูมิเมื่อเวิร์กบุ๊กพร้อมใช้งาน

สำหรับเซลล์เวิร์กบุ๊กที่แทนค่าข้อมูลที่หายไป โปรดดู [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/net/chart-series/) เพื่อดูความแตกต่างระหว่างเซลล์ว่างกับศูนย์ และการเปรียบเทียบกราฟเส้นของโหมดการแสดงผลที่มีให้

## **รวมข้อมูลจากแถวและคอลัมน์ที่ซ่อน**

ใช้ [IChart.PlotVisibleCellsOnly](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/plotvisiblecellsonly/) เพื่อควบคุมว่ากราฟจะพล็อตข้อมูลจากแถวและคอลัมน์ของชีตที่ซ่อนหรือไม่ ตั้งค่าเป็น `true` เพื่อพล็อตเฉพาะเซลล์ที่มองเห็นได้ หรือ `false` เพื่อรวมทั้งเซลล์ที่มองเห็นและที่ซ่อน การตั้งค่านี้ควบคุมการพล็อตของกราฟ; ไม่ได้ซ่อนหรือแสดงแถวหรือคอลัมน์ของชีต

[การนำเสนอตัวอย่าง](hidden-source-data.pptx) มีแผนภูมิคอลัมน์เป็นรูปร่างแรกบนสไลด์แรกของมัน ชีตที่ฝังอยู่ `Sheet1` มีช่วงข้อมูลต้นแบบต่อไปนี้ `A1:C4` แถวที่ 3 และคอลัมน์ C ถูกซ่อน แต่เซลล์ของพวกมันยังคงมีค่า

| แถวของชีตงาน | A: เดือน | B: ร้านค้าปลีก | C: ค้าส่ง (คอลัมน์ซ่อน) |
| --- | --- | --- | --- |
| 2 | มกราคม | 10 | 30 |
| 3 (แถวซ่อน) | กุมภาพันธ์ | 40 | 60 |
| 4 | มีนาคม | 20 | 50 |

เข้าถึงเซลล์ต้นทางผ่าน [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) และอ่านค่า [IChartDataCell.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/ishidden/) เพื่อตรวจสอบสถานะการซ่อนของพวกมัน คุณสมบัตินี้เป็นแบบอ่านอย่างเดียว ในไฟล์นี้ B2 มองเห็นได้, B3 อยู่ในแถวที่ซ่อน, และ C2 อยู่ในคอลัมน์ที่ซ่อน; ตัวอย่างพิมพ์ค่า `False`, `True`, และ `True` ตามลำดับ

สำหรับตัวอย่างนี้ ให้รีเฟรชข้อมูลแผนภูมิหลังจากเปลี่ยนการตั้งค่าการพล็อต: รักษาเวิร์กบุ๊กที่ฝังไว้ด้วย [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) และโหลดใหม่ด้วย [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) เมื่อรวมทุกเซลล์ ให้ใช้ [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) เพื่อคืนช่วงข้อมูลทั้งหมดรวมถึงหมวดหมู่เดือนกุมภาพันธ์ที่ซ่อน การเปลี่ยนค่าสถานะเพียงอย่างเดียวไม่เพียงพอในการรีเฟรชข้อมูลแผนภูมิที่ถูกแคชและป้ายกำกับหมวดหมู่ของตัวอย่างนี้

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
            // คืนช่วงข้อมูลต้นทางทั้งหมดรวมถึงหมวดหมู่ที่ซ่อนอยู่.
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

ตัวอย่างบันทึกรุ่นสองเวอร์ชันของการนำเสนอ: หนึ่งเวอร์ชันที่มีเฉพาะค่าร้านค้าปลีกที่มองเห็นได้ (10 และ 20) และอีกหนึ่งเวอร์ชันที่มีค่าทั้งหกค่า รูปภาพด้านล่างถูกสร้างจากการนำเสนอที่บันทึกและเปิดใหม่; ทั้งสองไฟล์คงการตั้งค่าการพล็อตที่กำหนดไว้ แถวที่ 3 และคอลัมน์ C ยังคงซ่อนอยู่ในทั้งสองเวิร์กบุ๊กที่ฝัง

| เฉพาะเซลล์ที่มองเห็น (`true`) | เซลล์ทั้งหมด (`false`) |
| --- | --- |
| ![เฉพาะเซลล์ที่มองเห็น: ค่าร้านค้าปลีก 10 และ 20 สำหรับเดือนมกราคมและมีนาคม.](hidden_cells_True.png) | ![เซลล์ทั้งหมด: ค่าร้านค้าปลีกและค้าส่งสำหรับเดือนมกราคม, กุมภาพันธ์, และมีนาคม.](hidden_cells_False.png) |

เซลล์ที่ซ่อนและมีค่าแตกต่างจากเซลล์ว่าง [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) ควบคุมวิธีการแสดงค่าที่หายไป; ไม่ได้รวมหรือไม่รวมข้อมูลต้นทางที่ซ่อน ดูตัวอย่างที่ [ควบคุมการแสดงผลของเซลล์ว่าง](/slides/th/net/chart-series/#control-the-display-of-empty-cells)

## **ดึงช่วงข้อมูลของแผนภูมิ**

ก่อนที่จะอัปเดตข้อมูลเวิร์กบุ๊กในงานนำเสนอที่มีอยู่ ให้ตรวจสอบช่วงต้นทางเพื่อระบุว่าเซลล์ของชีตงานใดที่แต่ละแผนภูมิใช้ วิธีการ [IChartData.GetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/getrange/) จะคืนค่าช่วงข้อมูลปัจจุบันเป็นสูตรที่ระบุชีต เช่น `Sheet1!$A$1:$D$5` ที่นี่ `Sheet1` คือชื่อชีต, `!` แยกจากช่วงเซลล์, และ `$A$1:$D$5` ระบุเซลล์ A1 ถึง D5 รวมทั้งสองตำแหน่ง สัญลักษณ์ดอลลาร์บ่งบอกการอ้างอิงแถวและคอลัมน์แบบสัมบูรณ์

เมธอดนี้อ่านช่วงปัจจุบันโดยไม่เปลี่ยนแปลงแผนภูมิหรือเวิร์กบุ๊กของมัน หากแผนภูมิไม่ใช้เวิร์กบุ๊กเป็นแหล่งข้อมูล จะทำให้เกิดข้อยกเว้น [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) สำหรับข้อมูลเพิ่มเติม ดู [ChartData API Reference](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/)

ตัวอย่างนี้เปิดงานนำเสนอและตรวจสอบรูปร่างบนแต่ละสไลด์โดยตรงเพื่อหาแผนภูมิ พิมพ์ชื่อและช่วงต้นทางของแต่ละแผนภูมิ หากแผนภูมิไม่ใช้เวิร์กบุ๊ก จะพิมพ์ข้อความและดำเนินการต่อไปยังแผนภูมิถัดไป

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

Aspose.Slides for .NET มีเมธอด [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) และ [WriteWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/writeworkbookstream/) ที่ให้คุณอ่านและเขียนเวิร์กบุ๊กข้อมูลแผนภูมิ (ซึ่งมีข้อมูลแผนภูมิที่แก้ไขด้วย Aspose.Cells) **หมายเหตุ** ข้อมูลแผนภูมิจำเป็นต้องจัดเรียงในลักษณะเดียวกันหรือมีโครงสร้างที่คล้ายกับต้นแบบ

ตัวอย่างนี้ใช้งานนำเสนอที่มีแผนภูมิเป็นรูปร่างแรกบนสไลด์แรก อ่านเวิร์กบุ๊กที่ฝังอยู่ลงในสตรีม, ลบ series และ category ที่มีอยู่, แล้วเขียนเวิร์กบุ๊กเดิมกลับไป การเปลี่ยนแปลงอยู่ในหน่วยความจำ; ตัวอย่างไม่ได้บันทึกงานนำเสนอ

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

### **ตรวจสอบโครงสร้างแผนภูมิหลังจากแก้ไขเวิร์กบุ๊ก**

เมื่อคุณแทนที่เวิร์กบุ๊กที่ฝังด้วยเวิร์กบุ๊กที่แก้ไขแล้ว แผนภูมิจะคง series และ collection ของ category ดั้งเดิม ความไม่ตรงกันนี้อาจทำให้ [IChart.ValidateChartLayout](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/validatechartlayout/) ล้มเหลวด้วยข้อผิดพลาด index-out-of-range ให้ลบ series และ category ที่มีอยู่ก่อนเขียนเวิร์กบุ๊กที่อัปเดตกลับไปยังแผนภูมิ ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรก คอมเมนต์บ่งชี้จุดที่ควรแก้ไขเวิร์กบุ๊ก; ตัวอย่างที่สามารถรันได้เขียนเวิร์กบุ๊กเดิมกลับและตรวจสอบโครงสร้างในหน่วยความจำ

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

    // แก้ไขสตรีมเวิร์กบุ๊กที่นี่, เช่น การใช้ Aspose.Cells.

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

การลบ collection จะลบการอ้างอิงข้อมูลเก่าออกก่อนที่เวิร์กบุ๊กจะถูกเขียนกลับ เรียกสร้าง series และการแมป category ที่จำเป็นสำหรับเวิร์กบุ๊กที่อัปเดตก่อนใช้แผนภูมิ

## **กำหนดรูปแบบตัวเลขแบบกำหนดเองสำหรับเซลล์เวิร์กบุ๊ก**

ใช้ [ChartDataCell.CustomNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/customnumberformat/) เพื่อควบคุมวิธีการแสดงค่าตัวเลขในเวิร์กบุ๊กที่ฝังของแผนภูมิ ตัวอย่างเช่น รายงานอาจต้องการอัตราแปลงที่แสดงเป็นเปอร์เซ็นต์ด้วยทศนิยมสี่ตำแหน่งและค่าสัมประสิทธิ์ที่แสดงด้วยทศนิยมห้าตำแหน่ง ให้ค่าสองค่าเป็นตัวเลขเพื่อให้ยังสามารถใช้ในการคำนวณและพล็อตแผนภูมิได้

รูปแบบตัวเลขจะเปลี่ยนการแสดงผล ไม่ใช่ค่าที่เก็บไว้ รูปแบบ `0.0000%` จะทำให้แสดง `0.125` เป็น `12.5000%`; ไม่ได้แทนที่ตัวเลขที่เก็บไว้ด้วย `12.5` เช่นเดียวกัน `0.00000` จะแสดง `0.1234567` เป็น `0.12346` โดยไม่ทำการปัดเศษค่าที่เก็บ หากรูปแบบกำหนดเองเป็นสตริงว่าง (`""`) จะใช้ [PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdatacell/presetnumberformat/) แทน

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์และเข้าถึงเซลล์ผ่าน [ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/) ในชีตงาน 0, B2 มีอัตราการแปลงและ C2 มีค่าสัมประสิทธิ์ ทั้งสองเซลล์เป็นแหล่งค่าของแผนภูมิ ตัวอย่างยังเปิดใช้ป้ายกำกับค่าที่เชื่อมต่อกับรูปแบบต้นทาง

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

รูปแบบเซลล์ของเวิร์กบุ๊กแยกจากรูปแบบที่ตั้งตรงบนแกนแผนภูมิหรือป้ายกำกับข้อมูล ในตัวอย่างนี้แต่ละป้ายแสดงค่าของเซลล์ต้นทางเนื่องจาก [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) เปิดใช้งานและปฏิบัติตามรูปแบบตัวเลขของต้นทางเนื่องจาก [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/isnumberformatlinkedtosource/) เป็น `true` หลังจากบันทึกและเปิดงานนำเสนอใหม่ ป้ายจะแสดง `12.5000%` และ `0.12346` ตามที่แสดงด้านล่าง แกนแนวตั้งใช้ [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) ของตัวเองเป็น `0.00` โดยตั้งค่า [IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/isnumberformatlinkedtosource/) เป็น `false`

หากต้องการจัดรูปแบบป้ายกำกับข้อมูลอย่างอิสระ ให้ตั้งค่าสถานะเชื่อมต่อกับต้นทางเป็น `false` และกำหนด [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/numberformat/) ของมัน การทำเช่นนี้จะไม่เปลี่ยนรูปแบบของเซลล์เวิร์กบุ๊ก ตัวอย่างรูปแบบป้ายอิสระ `0.00` จะแสดงค่าตัวแรกเป็น `0.13` ในขณะที่ B2 ยังคงแสดง `12.5000%` ดูที่ [Chart Data Labels](/slides/th/net/chart-data-label/#set-percentage-sign-with-chart-data-labels) สำหรับการจัดรูปแบบป้ายโดยตรง

รูปภาพด้านล่างถูกสร้างจากงานนำเสนอที่บันทึกแล้วเปิดใหม่:

![แผนภูมิคอลัมน์ที่มีป้ายกำกับเชื่อมต่อกับต้นทางแสดง 12.5000% และ 0.12346 และแกนตัวเลขที่จัดรูปแบบอย่างอิสระ](custom-cell-formats.png)

## **ตั้งค่าเซลล์เวิร์กบุ๊กเป็นป้ายกำกับข้อมูลของแผนภูมิ**

คุณสามารถใช้ข้อความจากเซลล์ของเวิร์กบุ๊กเป็นป้ายกำกับข้อมูลของแผนภูมิ

ตัวอย่างนี้เพิ่มแผนภูมิบับเบิลพร้อมข้อมูลเริ่มต้นบนสไลด์แรกของงานนำเสนอที่มีอยู่ ใช้เซลล์ A10:A12 บนชีตงาน 0 สำหรับป้ายชื่อสามตัวแรกใน series แรก เปิดใช้งานป้ายจากเซลล์และบันทึกงานนำเสนอที่อัปเดต

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

คุณสมบัติ [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/worksheets/) ให้เข้าถึงชีตงานในเวิร์กบุ๊กของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิวงกลมพร้อมข้อมูลเริ่มต้นและพิมพ์ชื่อชีตงานแต่ละรายการลงคอนโซล

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

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์ 3D พร้อมข้อมูลเริ่มต้นและตั้งชื่อ series สองชื่อโดยใช้แหล่งข้อมูลที่แตกต่างกัน ชื่อแรกใช้สตริงลิเทรัล; ชื่อที่สองใช้เซลล์ C1 บนชีตงาน 0 ค่าตัวนับ [DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) เลือกแหล่งสำหรับแต่ละชื่อ ตัวอย่างบันทึกงานนำเสนอพร้อมชื่อ series ที่อัปเดต

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

## **ตรวจจับรูปแบบเวิร์กบุ๊กที่ฝังไม่รองรับ**

Aspose.Slides ไม่รองรับรูปแบบเวิร์กบุ๊กไบนารีของ Excel (.xlsb) ที่สามารถฝังอยู่ในบางแผนภูมิ คุณสามารถใช้คุณสมบัติ [EmbeddedWorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/embeddedworkbooktype/) บน [IChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/) ร่วมกับตัวนับ [WorkbookType](https://reference.aspose.com/slides/net/aspose.slides.charts/workbooktype/) เพื่อตรวจจับรูปแบบที่ไม่รองรับและข้ามแผนภูมินั้น ตัวอย่างนี้ตรวจสอบรูปร่างบนสไลด์แรกของงานนำเสนอที่มีอยู่ ข้ามรูปร่างที่ไม่ใช่แผนภูมิ และพิมพ์ข้อความการวินิจฉัยสำหรับแต่ละแผนภูมิที่มีเวิร์กบุ๊ก .xlsb ฝังอยู่

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

    // อ่านหรือแก้ไขข้อมูลเวิร์กบุ๊กของแผนภูมิที่สนับสนุนที่นี่.
}
```

## **เวิร์กบุ๊กภายนอก**

Aspose.Slides รองรับการใช้เวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลสำหรับแผนภูมิ

### **สร้างเวิร์กบุ๊กภายนอก**

ใช้ [ReadWorkbookStream](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/readworkbookstream/) และ [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) เพื่อส่งออกเวิร์กบุ๊กแผนภูมิที่ฝังเป็นไฟล์และเชื่อมแผนภูมิไปยังเวิร์กบุ๊กภายนอกนั้น

ตัวอย่างนี้สร้างแผนภูมิวงกลมพร้อมข้อมูลเริ่มต้นและส่งออกเวิร์กบุ๊กของมัน ปิดสตรีมเอาต์พุตก่อนกำหนดเวิร์กบุ๊กภายนอกเป็นแหล่งข้อมูลของแผนภูมิ แล้วบันทึกงานนำเสนอที่มีการเชื่อมโยง

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

โดยใช้เมธอด [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) คุณสามารถกำหนดเวิร์กบุ๊กภายนอกให้กับแผนภูมิเป็นแหล่งข้อมูลของมันได้ เมธอดนี้ยังสามารถใช้เพื่ออัปเดตเส้นทางไปยังเวิร์กบุ๊กภายนอก (หากเวิร์กบุ๊กนั้นถูกย้าย)

แม้ว่าคุณไม่สามารถแก้ไขข้อมูลในเวิร์กบุ๊กที่เก็บไว้ในตำแหน่งหรือทรัพยากรระยะไกลได้ คุณยังสามารถใช้เวิร์กบุ๊กเหล่านั้นเป็นแหล่งข้อมูลภายนอกได้ หากระบุเส้นทางสัมพัทธ์สำหรับเวิร์กบุ๊กภายนอก ระบบจะทำการแปลงเป็นเส้นทางเต็มโดยอัตโนมัติ

ตัวอย่างนี้ใช้เวิร์กบุ๊กภายนอกที่มีชีตงานชื่อ `Sheet1` ซึ่งมีชื่อ series อยู่ใน B1, ชื่อหมวดหมู่ใน A2:A4, และค่าตัวเลขใน B2:B4 ตัวอย่างสร้างแผนภูมิวงกลม, เชื่อมเวิร์กบุ๊ก, และใช้ [SetRange](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setrange/) เพื่อแมพ A1:B4 เป็น series หนึ่งและหมวดหมู่สามรายการ จากนั้นบันทึกงานนำเสนอพร้อมแผนภูมิที่เชื่อม

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

พารามิเตอร์ `updateChartData` ของ [SetExternalWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/setexternalworkbook/) ควบคุมว่ามีการโหลดเวิร์กบุ๊กหรือไม่

* เมื่อ `updateChartData` เป็น `false` จะอัพเดตเฉพาะเส้นทางของเวิร์กบุ๊กเท่านั้น ข้อมูลแผนภูมิจะไม่ถูกโหลดหรืออัปเดตจากเวิร์กบุ๊กเป้าหมาย ดังนั้นเวิร์กบุ๊กอาจไม่มีอยู่
* เมื่อ `updateChartData` เป็น `true` ข้อมูลแผนภูมิจะอัปเดตจากเวิร์กบุ๊กเป้าหมาย

ตัวอย่างต่อไปนี้กำหนด URL ตัวแทนพร้อมตั้งค่า `updateChartData` เป็น `false` จะรักษาข้อมูลเริ่มต้นของแผนภูมิวงกลมและบันทึกงานนำเสนอโดยไม่โหลดเวิร์กบุ๊กที่ไม่มีอยู่

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

### **รับเส้นทางเวิร์กบุ๊กแหล่งข้อมูลภายนอกของแผนภูมิ**

เพื่อระบุเวิร์กบุ๊กที่เชื่อมกับแผนภูมิ ตรวจสอบว่าแผนภูมิใช้แหล่งข้อมูลภายนอกหรือไม่และดึงเส้นทางเวิร์กบุ๊กของมัน

ตัวอย่างนี้ตรวจสอบรูปร่างแรกบนสไลด์แรกของงานนำเสนอที่มีเวิร์กบุ๊กภายนอกเชื่อมอยู่ หากเป็นแผนภูมิที่เชื่อมกับเวิร์กบุ๊กภายนอก ตัวอย่างจะพิมพ์ค่า [ExternalWorkbookPath](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/externalworkbookpath/) ลงคอนโซล แล้วบันทึกสำเนาของงานนำเสนอ

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

คุณสามารถแก้ไขข้อมูลในเวิร์กบุ๊กภายนอกได้เช่นเดียวกับที่คุณเปลี่ยนแปลงเนื้อหาของเวิร์กบุ๊กภายใน หากเวิร์กบุ๊กภายนอกไม่สามารถโหลดได้ จะเกิดข้อยกเว้น

ตัวอย่างนี้ใช้แผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและเชื่อมกับเวิร์กบุ๊กภายนอกที่เข้าถึงได้ ตั้งค่าค่าที่สนับสนุนโดยเซลล์ของจุดข้อมูลแรกใน series แรกเป็น 100 และบันทึกงานนำเสนอที่อัปเดต การแก้ไขค่าของเซลล์สามารถอัปเดตไฟล์ XLSX ภายนอกที่เชื่อมได้ ดังนั้นให้ใช้สำเนาหากต้องการรักษาเวิร์กบุ๊กต้นฉบับ

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

### **กู้คืนเวิร์กบุ๊กจากแคชของแผนภูมิ**

หากแผนภูมิใช้เวิร์กบุ๊กภายนอกที่หายไปหรือไม่พร้อมใช้งาน Aspose.Slides สามารถสร้างเวิร์กบุ๊กของแผนภูมิใหม่จากข้อมูลที่แคชไว้ในงานนำเสนอได้ สร้าง [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) ตั้งค่า [SpreadsheetOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/spreadsheetoptions/) และกำหนดค่า [ISpreadsheetOptions.RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/net/aspose.slides/ispreadsheetoptions/recoverworkbookfromchartcache/) เป็น `true` ก่อนเปิดงานนำเสนอ

ตัวอย่าง C# ต่อไปนี้กู้คืนข้อมูลเวิร์กบุ๊กสำหรับแผนภูมิที่เป็นรูปร่างแรกบนสไลด์แรกและอ้างอิงเวิร์กบุ๊กภายนอกที่ไม่สามารถใช้ได้ เข้าถึงข้อมูลที่กู้คืนผ่าน [IChart.ChartData](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/chartdata/) และ [IChartData.ChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/chartdataworkbook/):

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

หากเวิร์กบุ๊กภายนอกไม่พร้อมใช้งานและการกู้คืนถูกปิดใช้ Aspose.Slides จะทำให้เกิด [InvalidOperationException](https://learn.microsoft.com/en-us/dotnet/api/system.invalidoperationexception) เปิดการกู้คืนเฉพาะเมื่อการใช้ข้อมูลแผนภูมิที่แคชเป็นวิธีสำรองที่ยอมรับได้ เพราะแคชอาจไม่มีการเปลี่ยนแปลงที่ทำในเวิร์กบุ๊กภายนอกหลังจากอัปเดตงานนำเสนอครั้งล่าสุด

## **คำถามที่พบบ่อย**

**ฉันสามารถตรวจสอบได้หรือไม่ว่าแผนภูมิเฉพาะเจาะจงเชื่อมกับเวิร์กบุ๊กภายนอกหรือเวิร์กบุ๊กที่ฝังอยู่?**

ใช่ แผนภูมิมี [data source type](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/datasourcetype/) และ [path to an external workbook](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) หากแหล่งเป็นเวิร์กบุ๊กภายนอก คุณสามารถอ่านเส้นทางเต็มเพื่อยืนยันว่ากำลังใช้ไฟล์ภายนอก

**รองรับการใช้เส้นทางสัมพัทธ์ไปยังเวิร์กบุ๊กภายนอกหรือไม่ และจัดเก็บอย่างไร?**

ใช่ หากคุณระบุเส้นทางสัมพัทธ์ ระบบจะเปลี่ยนเป็นเส้นทางเต็มโดยอัตโนมัติ งานนำเสนอจะเก็บเส้นทางเต็มในไฟล์ PPTX ดังนั้นการย้ายเวิร์กบุ๊กอาจต้องอัปเดตลิงก์

**ฉันสามารถใช้เวิร์กบุ๊กที่ตั้งอยู่บนทรัพยากรเครือข่ายหรือแชร์ได้หรือไม่?**

ได้ เวิร์กบุ๊กเช่นนั้นสามารถใช้เป็นแหล่งข้อมูลภายนอกได้ อย่างไรก็ตาม การแก้ไขเวิร์กบุ๊กระยะไกลโดยตรงจาก Aspose.Slides ไม่รองรับ — สามารถใช้เป็นแหล่งข้อมูลได้เท่านั้น

**Aspose.Slides เขียนทับไฟล์ XLSX ภายนอกเมื่อตบลงงานนำเสนอหรือไม่?**

งานนำเสนอเก็บ [link to the external file](https://reference.aspose.com/slides/net/aspose.slides.charts/chartdata/externalworkbookpath/) การแก้ไขข้อมูลแผนภูมิที่สนับสนุนโดยเซลล์อาจอัปเดตไฟล์ XLSX ภายนอกในเครื่องได้ ใช้สำเนาของเวิร์กบุ๊กหากต้องการให้ต้นฉบับคงเดิม

**ฉันควรทำอย่างไรถ้าไฟล์ภายนอกถูกป้องกันด้วยรหัสผ่าน?**

Aspose.Slides ไม่รับรหัสผ่านเมื่อทำการเชื่อมต่อ วิธีทั่วไปคือการลบการป้องกันล่วงหน้าหรือเตรียมสำเนาที่ถอดรหัสไว้ (เช่น ใช้ [Aspose.Cells](https://reference.aspose.com/cells/net/)) แล้วเชื่อมไปยังสำเนานั้น

**หลายแผนภูมิสามารถอ้างอิงเวิร์กบุ๊กภายนอกเดียวกันได้หรือไม่?**

ได้ แต่ละแผนภูมิจะเก็บลิงก์ของตนเอง หากทั้งหมดชี้ไปที่ไฟล์เดียวกัน การอัปเดตไฟล์นั้นจะสะท้อนในแต่ละแผนภูมิเมื่อมีการโหลดข้อมูลครั้งถัดไป