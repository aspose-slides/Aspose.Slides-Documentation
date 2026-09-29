---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย .NET
linktitle: ชุดข้อมูล
type: docs
url: /th/net/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุด
- สีของชุด
- สีของหมวดหมู่
- ชื่อชุด
- จุดข้อมูล
- ช่องว่างของชุด
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์ในสมุดงาน, การจัดรูปแบบ, การทับซ้อน, ความกว้างช่องว่าง, และค่าติดลบในงานนำเสนอด้วย C#."
---
## **ภาพรวม**

แผนภูมิจัดเก็บข้อมูลที่วางแผนไว้ใน **chart data workbook**. [IChartSeries](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด, และแต่ละ [IChartDataPoint](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/) ในชุดนั้นอ้างอิงไปยังเซลล์หนึ่งหรือหลายเซลล์ในสมุดงาน. วัตถุ [IChartCategory](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartcategory/) ให้ป้ายกำกับหรือค่ากลุ่มที่ใช้ร่วมกันโดยชุดข้อมูล. ดังนั้นชื่อชุด, หมวดหมู่และค่าจุดจึงเชื่อมต่อกับวัตถุ [IChartDataCell](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/) แทนที่จะเก็บเป็นข้อความแสดงผลเท่านั้น.

สำหรับแผนภูมิมีประเภทแบบหมวดหมู่ทั่วไป, สมุดงานเริ่มต้นจะใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าชุด. ดัชนี worksheet, แถวและคอลัมน์ที่ส่งไปยัง [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/getcell/) เป็นแบบศูนย์‑อิง (zero‑based). เค้าโครงนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น, แต่ไม่ควรสันนิษฐานว่าทุกแผนภูมิที่มีอยู่ใช้เค้าโครงนี้. สำหรับการนำเสนอที่โหลดเข้ามา, ให้ตรวจสอบเซลล์ที่อ้างอิงโดยชุด, หมวดหมู่และจุดข้อมูลก่อนที่จะเปลี่ยนค่าของสมุดงาน.

การตั้งค่าแผนภูมิมีสามระดับที่แตกต่างกัน:

- การตั้งค่าระดับชุด, เช่น [IChartSeries.Format](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/format/), ให้รูปลักษณ์เริ่มต้นสำหรับทุกจุดในชุดเดียว.
- การตั้งค่าระดับจุดข้อมูล, เช่น [IChartDataPoint.Format](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/format/), จะบังคับทับรูปลักษณ์ของชุดสำหรับจุดนั้น.
- การตั้งค่าระดับกลุ่มจะใช้กับชุดที่เข้ากันได้ซึ่งอยู่ใน [IChartSeriesGroup](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseriesgroup/) เดียวกัน. เข้าถึงกลุ่มผ่าน [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/parentseriesgroup/) เมื่อคุณต้องการกำหนดตัวเลือกเช่นการทับซ้อนหรือความกว้างของช่องว่าง.

เมื่อไม่มีการกำหนดการเติมสี (fill) จุดหรือชุดอย่างชัดเจน, สไตล์และธีมของแผนภูมิจะกำหนดรูปลักษณ์อัตโนมัติ. เมื่อทั้งการกำหนดรูปแบบของชุดและจุดมีอยู่, การกำหนดรูปแบบของจุดจะมีสิทธิ์เหนือสำหรับจุดนั้น.

![ซีรีส์แผนภูมิ PowerPoint](chart-series-powerpoint.png)

## **กำหนดค่าการทับซ้อนของซีรีส์แผนภูมิ**

[IChartSeries.Overlap](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/overlap/) รายงานว่าบาร์หรือคอลัมน์ทับซ้อนกันเท่าใดในแผนภูมิ 2D, ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์. ค่าดังกล่าวเป็นการฉายภาพแบบอ่าน‑อย่างเดียวของการตั้งค่าในกลุ่มชุดพาเร้นท์. ตั้งค่า [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseriesgroup/overlap/) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น. ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์ที่จัดกลุ่ม; จะไม่ส่งผลต่อกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิแบบคอมบิเนชัน.

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่มีชุดแรกอยู่ในนั้น:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// แผนภูมิใหม่ประกอบด้วยชุดตัวอย่าง, หมวดหมู่และค่า.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![การทับซ้อนของชุด](series_overlap.png)

## **เปลี่ยนสีเติมของชุด**

ใช้ [IChartSeries.Format](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/format/) เพื่อตั้งค่าสีเติมเริ่มต้นสำหรับชุดทั้งหมด. หากจุดมีการกำหนดสีเติมอย่างชัดเจนอยู่แล้ว, การตั้งค่า [IChartDataPoint.Format](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/format/) จะบังคับทับการเติมสีของชุดสำหรับจุดนั้น.

ตัวอย่างต่อไปนี้ทำการเติมสีฟ้าแบบทึบให้กับชุดแรก:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Blue;

presentation.Save("series_color.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![สีของชุด](series_color.png)

## **เปลี่ยนชื่อชุด**

ชื่อชุดถูกเก็บไว้ในสมุดข้อมูลของแผนภูมิและโดยปกติจะแสดงใน legend. ในสมุดงานเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบ clustered, เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และบรรจุชื่อของชุดแรก. ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างดังกล่าวชัดเจน:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var workbook = chart.ChartData.ChartDataWorkbook;
var seriesNameCell = workbook.GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

คุณสามารถอัปเดตเซลล์ที่อ้างอิงโดย [IChartSeries.Name](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/name/) ได้เช่นกัน. วิธีนี้หลีกเลี่ยงการสันนิษฐานแถวหรือคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var seriesNameCell = series.Name.AsCells[firstNameCellIndex];
seriesNameCell.Value = "Revenue";

presentation.Save("series_name.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ชื่อชุด](series_name.png)

## **รับสีเติมอัตโนมัติของชุด**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) คืนค่าสีที่คำนวณจากดัชนีของชุดและสไตล์ของแผนภูมิ. นี่คือสีที่ใช้เมื่อการเติมสีของชุดไม่ได้กำหนดอย่างชัดเจน. การเรียกเมธ็อดนี้เพียงอ่านสีที่คำนวณ; ไม่ได้กำหนดสีใหม่.

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดเริ่มต้น:

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;

const int firstSlideIndex = 0;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var seriesCount = chart.ChartData.Series.Count;
for (var seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    var series = chart.ChartData.Series[seriesIndex];
    var automaticColor = series.GetAutomaticSeriesColor();
    Console.WriteLine($"Series {seriesIndex}: {automaticColor.Name}");
}
```

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิเริ่มต้น:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

สีที่ได้จะแตกต่างตามสไตล์และธีมของแผนภูมิ.

## **ตั้งค่าสีเติมกลับหัวสำหรับชุดแผนภูมิ**

สำหรับชุดแบบบาร์, คอลัมน์และบับเบิล, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/invertifnegative/) สามารถแสดงค่าติดลบด้วยสีเติมที่ต่างออกไป. ตั้งค่าสีเติมปกติให้เป็นแบบทึบ, เปิดใช้งานการกลับหัว, แล้วกำหนดสีค่าติดลบผ่าน [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). ตัวเลขติดลบจะยังคงอยู่ในสมุดงานโดยไม่เปลี่ยน; เพียงสีการแสดงผลที่เปลี่ยน.

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยหนึ่งชุด. แถว 0 ของ worksheet มีชื่อชุด, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่า:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;

var categoryNames = new[] { "Category 1", "Category 2", "Category 3" };
var seriesValues = new[] { -20, 50, -30 };

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
var series = chartData.Series.Add(seriesNameCell, chart.Type);

for (var categoryIndex = 0; categoryIndex < categoryNames.Length; categoryIndex++)
{
    var dataRowIndex = firstDataRowIndex + categoryIndex;
    var categoryName = categoryNames[categoryIndex];
    var seriesValue = seriesValues[categoryIndex];

    var categoryCell = workbook.GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
    chartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
    series.DataPoints.AddDataPointForBarSeries(valueCell);
}

var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertIfNegative = true;
series.InvertedSolidFillColor.Color = Color.Red;

presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![สีเติมทึบกลับหัว](inverted_solid_fill_color.png)

คุณสามารถเปิดใช้งานการกลับหัวสำหรับจุดเดียวผ่าน [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). ตัวอย่างต่อไปนี้ปิดการกลับหัวสำหรับชุดทั้งหมดและเปิดเฉพาะสำหรับจุดที่เลือก. จุดนั้นยังได้รับค่าติดลบเพื่อให้เห็นผล:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var automaticSeriesColor = series.GetAutomaticSeriesColor();
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = automaticSeriesColor;
series.InvertedSolidFillColor.Color = Color.Red;
series.InvertIfNegative = false;

var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = negativeValue;
dataPoint.InvertIfNegative = true;

presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
```

## **ล้างค่าจุดข้อมูลเฉพาะ**

เพื่อทำให้จุดหนึ่งว่างเปล่าโดยไม่ลบจุดอื่น, ตั้งค่าเซลล์ในสมุดงานที่รองรับเป็น `null`. สำหรับแผนภูมิคอลัมน์, ค่าที่วาดแสดงผ่าน [IChartDataPoint.YValue](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/yvalue/). จุดข้อมูลจะยังคงอยู่ที่ตำแหน่งหมวดหมู่เดียวกัน, แต่แผนภูมิจะแสดงค่าของมันเป็นค่าว่างตามการตั้งค่าการแสดงค่าว่างของแผนภูมิ.

ตัวอย่างต่อไปนี้ล้างเฉพาะจุดที่สองในชุดแรก:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
var dataPoint = series.DataPoints[targetDataPointIndex];
dataPoint.YValue.AsCell.Value = null;

presentation.Save("clear_data_point_value.pptx", SaveFormat.Pptx);
```

แผนภูมิกระจาย (scatter) ใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิลยังใช้เซลล์ขนาด. ให้ล้างเฉพาะเซลล์ที่แทนค่าที่คุณต้องการลบ. ไม่ควรเรียก [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapointcollection/clear/) หากต้องการคงจุดอื่นไว้, เนื่องจากเมธ็อดนี้จะลบจุดข้อมูลทั้งหมดในคอลเลกชัน.

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนอยู่แต่มีค่าเป็นกรณีที่แตกต่างจากเซลล์ว่าง. เพื่อรวมหรือยกเว้นข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่, ดูที่ [Include Data from Hidden Rows and Columns](/slides/th/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

เซลล์สมุดงานที่ว่างเปล่าหมายถึงข้อมูลที่ขาดหาย; เซลล์ที่มีค่า `0` หมายถึงค่าตัวเลขที่รู้จัก. ตั้งค่า [IChartDataCell.Value](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/value/) เป็น `null` เพื่อทำให้เซลล์ว่าง. ตัวเลขศูนย์ยังคงเป็นศูนย์ไม่ว่าการตั้งค่าค่าว่างจะเป็นเช่นไร.

ใช้ [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/displayblanksas/) เพื่อเลือกว่แผนภูมิจะแสดงเซลล์ว่างอย่างไร. การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด. มันเปลี่ยนวิธีที่ช่องว่างถูกพล็อต, โดยไม่เติมค่า 0 หรือค่าประมาณในเซลล์สมุดงานที่ว่าง.

ตัวอย่างต่อไปนี้เป็นตัวอย่างสมบูรณ์ที่สร้างแผนภูมิเส้นหนึ่งชุด, ลบค่าในวัน 3, แล้วบันทึกแผนภูมิเดียวกันด้วยแต่ละโหมด. ไม่ต้องใช้ไฟล์อินพุต. [IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/) ใช้ worksheet 0, คอลัมน์ 0 สำหรับป้ายชื่อหมวดหมู่, และคอลัมน์ 1 สำหรับค่าต่าง ๆ; แถว 0 เก็บชื่อชุด. ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 40, 40, 640, 400);
var chartData = chart.ChartData;
var workbook = chartData.ChartDataWorkbook;

chartData.Series.Clear();
chartData.Categories.Clear();

var seriesNameCell = workbook.GetCell(0, 0, 1, "Measurements");
var series = chartData.Series.Add(seriesNameCell, chart.Type);
var values = new[] { 10, 20, 25, 30, 40 };

for (var i = 0; i < values.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, $"Day {i + 1}");
    chartData.Categories.Add(categoryCell);
    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForLineSeries(valueCell);
}

// Leave Day 3 genuinely empty, while retaining its category and data point.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

แต่ละไฟล์ผลลัพธ์จะบันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` และ `empty_cells_Span.pptx`. หากต้องการบันทึกเพียงเวอร์ชันเดียว, ให้กำหนดโหมดที่ต้องการแล้วบันทึกงานนำเสนอเพียงครั้งเดียวแทนการวนลูปตามโหมด.

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในทั้งสามไฟล์. วัน 3 จะว่างเปล่าในสมุดงานในทุกกรณี:

![แผนภูมิเส้นที่มีข้อมูลเหมือนกัน: Gap แตกเส้นที่วัน 3, Zero ทำเส้นลดลงเป็นศูนย์, และ Span เชื่อมวัน 2 กับวัน 4.](display_blanks_as.png)

ผลที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ. แผนภูมิเส้นทำให้เห็นความแตกต่างของทั้งสามโหมดได้ง่าย. แผนภูมิแท่งและคอลัมน์ไม่มีเส้นเชื่อมผ่านหมวดหมู่ที่หายไป, ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมที่แสดงไว้ข้างต้น; คอลัมน์ที่หายไปและคอลัมน์ที่สูงศูนย์อาจดูคล้ายกัน. เช่นเดียวกับแผนภูมิกระจายที่มีเพียงมาร์คเกอร์, ไม่มีเส้นเชื่อม. อย่าคาดหวังผลลัพธ์ที่แตกต่างกันสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้.

## **ตั้งค่าความกว้างช่องว่างของชุด**

ความกว้างช่องว่างคือระยะห่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์. เช่นเดียวกับการทับซ้อน, ค่าดังกล่าวเป็นของกลุ่มชุดพาเร้นท์ ไม่ได้เป็นของชุดเดียว. ตั้งค่า [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) ครั้งเดียวสำหรับกลุ่ม. ค่าที่ใหญ่กว่าจะเพิ่มช่องว่างระหว่างกลุ่ม; ค่าที่เล็กกว่าจะทำให้กลุ่มใกล้กันมากขึ้น.

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างช่องว่างและบันทึกเฉพาะงานนำเสนอขั้นสุดท้าย:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int gapWidthPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

var chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.GapWidth = gapWidthPercent;

presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![ความกว้างช่องว่าง](gap_width.png)

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดบ้างที่รองรับชุดข้อมูล?**

ประเภทแผนภูมิทั้งหมดที่แสดงโดย enumeration [ChartType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ชุดของพวกมันไม่ได้มีโครงสร้างหรือการตั้งค่าเดียวกัน. ตัวอย่างเช่น แผนภูมิมีประเภทหมวดหมู่ใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิบับเบิลเพิ่มขนาดบับเบิล. ใช้วิธีการสร้างจุดข้อมูลที่สอดคล้องกับประเภทของชุด. ตัวเลือกเช่นการทับซ้อนและความกว้างช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้.

**ชุดแผนภูมิกลุ่ม (chart series group) คืออะไร?**

[IChartSeriesGroup](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseriesgroup/) ประกอบด้วยชุดที่เข้ากันได้และแชร์การตั้งค่าการพล็อตระดับกลุ่ม. แผนภูมิคอมบิเนชันสามารถมีหลายกลุ่ม, ดังนั้นการเปลี่ยนแปลงกลุ่มผ่านชุดหนึ่งไม่ได้หมายความว่าจะเปลี่ยนทุกชุดในแผนภูมิ.

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

มี. ตามค่าเริ่มต้น, [IShapeCollection.AddChart](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addchart/) จะสร้างชุดตัวอย่าง, หมวดหมู่และค่า. คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดคอลเลกชันของชุดและหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างเต็มที่. มี overload ที่สามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้นได้.

**แผนภูมิกับเซลล์ในสมุดงานเชื่อมต่ออย่างไร?**

ชื่อชุด, ป้ายหมวดหมู่และค่าจุดข้อมูลอ้างอิงเซลล์ใน [IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/). การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิที่สอดคล้อง. เมื่อคุณสร้างข้อมูลแบบกำหนดเอง, ให้จัดแถวหมวดหมู่และแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุดถูกวางภายใต้หมวดหมู่ที่ต้องการ.

**จะล้างจุดเดียวโดยไม่ลบทั้งชุดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดนั้นเป็นจุดว่าง. ใช้ [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapointcollection/clear/) เฉพาะเมื่อต้องการลบจุดทั้งหมดจากชุดนั้น. หากคุณลบหมวดหมู่ด้วย, ให้อัปเดตทุกชุดเพื่อให้ค่าตรงกับคอลเลกชันหมวดหมู่.

**จุดว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นกับประเภทแผนภูมิและ [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/displayblanksas/). แผนภูมิที่รองรับสามารถแสดงช่องว่างเป็นช่องว่าง, เป็นค่าศูนย์, หรือโดยเชื่อมจุดใกล้เคียงกัน. เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่ขาดหายไปในงานนำเสนอของคุณ. ดูหัวข้อ [ควบคุมการแสดงผลของเซลล์ว่าง](#control-the-display-of-empty-cells) สำหรับตัวอย่างสมบูรณ์และการเปรียบเทียบภาพ.

**ค่าติดลบจะถูกจัดรูปแบบอย่างไร?**

สำหรับชุดบาร์, คอลัมน์และบับเบิลที่สนับสนุน, เปิดใช้ [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/invertifnegative/) และตั้งค่า [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). คุณสามารถบังคับทับพฤติกรรมสำหรับจุดเดี่ยวด้วย [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). คุณสมบัติเหล่านี้มีผลต่อการจัดรูปแบบ, ไม่ได้เปลี่ยนค่าตัวเลขที่เก็บไว้.

**การจัดรูปแบบใดชนะเมื่อทั้งชุดและจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดข้อมูลที่ชัดเจนจะมีสิทธิ์เหนือสำหรับจุดนั้น. จุดอื่น ๆ จะยังคงใช้การจัดรูปแบบของชุด (ถ้ากำหนด) หรือหากชุดไม่ได้กำหนด, จะใช้สไตล์และธีมของแผนภูมิโดยอัตโนมัติ. คุณสมบัติกลุ่มเช่นการทับซ้อนและความกว้างช่องว่างควบคุมการจัดวางและไม่ใช่การจัดรูปแบบระดับจุด.

**แผนภูมิสามารถมีชุดได้กี่ชุด?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดคงที่แยกต่างหาก. อย่างไรก็ตาม, ข้อจำกัดของไฟล์งานนำเสนอ, หน่วยความจำที่ใช้ได้, เวลาเรนเดอร์และความอ่านง่ายของแผนภูมิจะกำหนดขีดจำกัดที่เป็นประโยชน์ในทางปฏิบัติ.

**ควรทำอย่างไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

ตั้งค่า [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) บนกลุ่มชุดพาเร้นท์ที่เหมาะสม. เพิ่มค่าจะเพิ่มระยะห่างระหว่างกลุ่ม, ลดค่าจะทำให้กลุ่มเข้ามาใกล้กันมากขึ้น.