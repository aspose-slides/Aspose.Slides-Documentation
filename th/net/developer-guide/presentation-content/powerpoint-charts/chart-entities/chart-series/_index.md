---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย .NET
linktitle: ชุดข้อมูล
type: docs
url: /th/net/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุดข้อมูล
- สีของชุดข้อมูล
- สีของหมวดหมู่
- ชื่อชุดข้อมูล
- จุดข้อมูล
- ช่องว่างของชุดข้อมูล
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์ในสมุดงาน, การจัดรูปแบบ, การทับซ้อน, ความกว้างช่องว่าง, และค่าติดลบในงานนำเสนอด้วย C#."
---
## **ภาพรวม**

แผนภูมิจัดเก็บข้อมูลที่พล็อตไว้ในสมุดงานข้อมูลแผนภูมิ แสดงโดย[IChartSeries](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/)เป็นชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ[IChartDataPoint](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/)ในชุดนั้นอ้างอิงถึงหนึ่งหรือหลายเซลล์ในสมุดงาน วัตถุ[IChartCategory](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartcategory/)ให้ป้ายหรือค่ากลุ่มที่ใช้ร่วมกันโดยชุดข้อมูล ชื่อชุดข้อมูล, หมวดหมู่, และค่าจุดจึงเชื่อมต่อกับวัตถุ[IChartDataCell](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/) แทนที่จะถูกเก็บเป็นข้อความแสดงผลเท่านั้น

สำหรับแผนภูมิกลุ่มแบบทั่วไป สมุดงานเริ่มต้นจะใช้แถว 0 สำหรับชื่อชุดข้อมูล, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าชุดข้อมูล ดัชนีแผ่นงาน, แถว, และคอลัมน์ที่ส่งไปยัง[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/getcell/) คือแบบศูนย์ฐาน การจัดวางนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ไม่ควรสมมติว่าทุกแผนภูมิที่มีอยู่ใช้รูปแบบนี้ สำหรับการนำเสนอที่โหลดแล้ว ให้ตรวจสอบเซลล์ที่ชุดข้อมูล, หมวดหมู่, และจุดข้อมูลอ้างอิงก่อนที่จะเปลี่ยนค่าของสมุดงาน

การตั้งค่าแผนภูมิมีสามระดับต่างกัน:

- การตั้งค่าระดับชุดข้อมูล เช่น[IChartSeries.Format](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/format/) ให้ลักษณะเริ่มต้นสำหรับจุดทั้งหมดในชุดเดียว
- การตั้งค่าจุดข้อมูล เช่น[IChartDataPoint.Format](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/format/) จะทับลักษณะของชุดข้อมูลสำหรับจุดเดียว
- การตั้งค่ากลุ่มใช้กับชุดข้อมูลที่เข้ากันซึ่งอยู่ใน[IChartSeriesGroup](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseriesgroup/)เดียวกัน เข้าถึงกลุ่มผ่าน[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/parentseriesgroup/) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่นการทับซ้อนหรือความกว้างช่องว่าง

เมื่อไม่มีการกำหนดการเติมสีอย่างชัดเจนสำหรับจุดหรือชุดข้อมูล สไตล์และธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติ เมื่อมีการจัดรูปแบบทั้งชุดและจุดพร้อมกัน การจัดรูปแบบจุดจะมีอำนาจเหนือสำหรับจุดนั้น

![chart-series-powerpoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของชุดข้อมูลแผนภูมิ**

[IChartSeries.Overlap](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/overlap/) รายงานว่าคอลัมน์หรือแท่งทับซ้อนกันในแผนภูมิ 2 มิติเท่าใด ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์ เป็นการฉายภาพแบบอ่านอย่างเดียวของการตั้งค่าบนกลุ่มชุดข้อมูลแม่ ตั้งค่า[IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseriesgroup/overlap/) เพื่ออัปเดตทุกชุดข้อมูลที่เข้ากันในกลุ่มนั้น ตัวเลือกนี้ใช้กับแผนภูมิที่แสดงแท่งหรือคอลัมน์แบบจัดกลุ่ม; ไม่ส่งผลต่อกลุ่มชุดข้อมูลที่ไม่เกี่ยวข้องในแผนภูมิแบบรวม

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่มีชุดข้อมูลแรก:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// แผนภูมิใหม่มีชุดข้อมูลตัวอย่าง, หมวดหมู่และค่า.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![The series overlap](series_overlap.png)

## **เปลี่ยนสีเติมของชุดข้อมูล**

ใช้[IChartSeries.Format](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/format/) เพื่อกำหนดสีเติมเริ่มต้นสำหรับชุดข้อมูลทั้งหมด หากจุดหนึ่งมีการกำหนดสีเติมอย่างชัดเจนแล้ว การตั้งค่า[IChartDataPoint.Format](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/format/) จะทับสีเติมของชุดข้อมูลสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้สีเติมทึบสีฟ้ากับชุดข้อมูลแรก:

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

![The color of the series](series_color.png)

## **เปลี่ยนชื่อชุดข้อมูล**

ชื่อชุดข้อมูลถูกเก็บในสมุดงานข้อมูลแผนภูมิและปกติจะแสดงในบันทัดตำนาน ในสมุดงานเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบกลุ่ม เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และมีชื่อของชุดข้อมูลแรก ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนั้นชัดเจน:

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

คุณยังสามารถอัปเดตเซลล์ที่[IChartSeries.Name](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/name/) อ้างอิงอยู่ วิธีนี้หลีกเลี่ยงการสมมติแถวและคอลัมน์ใด ๆ ในแผนภูมิที่มีอยู่แล้ว:

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

![The series name](series_name.png)

## **รับสีเติมอัตโนมัติของชุดข้อมูล**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) คืนค่าสีที่คำนวณจากดัชนีชุดข้อมูลและสไตล์แผนภูมิ นี่คือสีที่ใช้เมื่อสีเติมของชุดข้อมูลไม่ได้กำหนดอย่างชัดเจน การเรียกเมธอดจะอ่านสีที่คำนวณได้; ไม่ได้กำหนดสีเติมใหม่

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดข้อมูลเริ่มต้น:

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

สีที่แน่นอนขึ้นอยู่กับสไตล์และธีมของแผนภูมิ

## **ตั้งค่าสีเติมสลับสำหรับชุดข้อมูลแผนภูมิ**

สำหรับชุดข้อมูลแท่ง, คอลัมน์, และบับเบิล, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/invertifnegative/) สามารถแสดงค่าติดลบด้วยสีเติมที่ต่างออกไป ตั้งค่าสีเติมปกติของชุดข้อมูลให้เป็นสีทึบ, เปิดใช้งานการสลับ, และกำหนดสีค่าติดลบผ่าน[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). ค่าติดลบในสมุดงานไม่เปลี่ยนแปลง; เพียงสีแสดงผลที่เปลี่ยน

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยชุดข้อมูลหนึ่ง แผ่นงานแถว 0 มีชื่อชุดข้อมูล, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่าต่าง ๆ:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

คุณสามารถเปิดใช้งานการสลับสำหรับจุดเดียวผ่าน[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). ในตัวอย่างต่อไปนี้ การสลับถูกปิดสำหรับชุดข้อมูลและเปิดเฉพาะจุดที่เลือก พร้อมกำหนดค่าติดลบให้จุดนั้นเพื่อให้เห็นผล:

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

เพื่อทำให้จุดหนึ่งเป็นค่าว่างโดยไม่ลบจุดอื่น ๆ ให้ตั้งค่าเซลล์สมุดงานที่สนับสนุนจุดนั้นเป็น `null` สำหรับแผนภูมิคอลัมน์ ค่าที่พล็อตได้สามารถเข้าถึงได้ผ่าน[IChartDataPoint.YValue](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/yvalue/). จุดข้อมูลจะคงอยู่ในตำแหน่งหมวดหมู่เดิม แต่แผนภูมิจะถือค่านั้นเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ล้างเฉพาะจุดที่สองในชุดข้อมูลแรก:

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

แผนภูมิกระจายนำจุด X และ Y แยกกัน, และแผนภูมิบับเบิลยังใช้เซลล์ขนาดด้วย ลบเฉพาะเซลล์ที่แทนค่าที่คุณต้องการลบ อย่าเรียก[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapointcollection/clear/) หากคุณต้องการเก็บจุดอื่น ๆ เพราะเมธอดนั้นจะลบจุดข้อมูลทั้งหมดจากคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์สมุดงานที่ว่างแสดงถึงข้อมูลที่ขาดหาย; เซลล์ที่มีค่า `0` แสดงถึงค่าตัวเลขที่รู้จัก ตั้งค่า[IChartDataCell.Value](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/value/) เป็น `null` เพื่อทำให้เซลล์เป็นค่าว่าง ค่าเลขศูนย์ยังคงเป็นศูนย์ไม่ว่าจะตั้งค่าค่าว่างอย่างไร

ใช้[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/displayblanksas/) เพื่อเลือกวิธีที่แผนภูมิจะแสดงเซลล์ว่าง การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด เปลี่ยนการพล็อตค่าว่างโดยไม่ต้องเติมค่า 0 หรือค่าที่ประมาณไว้ในเซลล์ว่าง

ตัวอย่างต่อไปนี้เป็นตัวอย่างที่ทำงานแยกกันสร้างแผนภูมิเส้นด้วยชุดข้อมูลหนึ่ง, ลบค่าของวัน 3, แล้วบันทึกแผนภูมิเดียวกันในแต่ละโหมด ไม่ต้องมีไฟล์อินพุต[IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/) ใช้แผ่นงาน 0, คอลัมน์ 0 สำหรับป้ายหมวดหมู่, และคอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อชุดข้อมูล ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`.

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

// ปล่อยให้วัน 3 ว่างจริง ๆ ขณะที่ยังคงหมวดหมู่และจุดข้อมูลไว้.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

แต่ละไฟล์ผลลัพธ์จะบันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx` หากต้องการบันทึกเฉพาะเวอร์ชันเดียว ให้กำหนดโหมดที่ต้องการและบันทึกการนำเสนอเพียงครั้งเดียวแทนการวนหลายโหมด

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในทั้งสามไฟล์ วัน 3 เป็นค่าว่างในสมุดงานทุกกรณี:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นจะขึ้นอยู่กับประเภทแผนภูมิ แผนภูมิเส้นทำให้การเปรียบเทียบสามโหมดง่าย ส่วนแผนภูมิแท่งและคอลัมน์ไม่มีเส้นเชื่อมต่อช่องว่าง จึงทำให้ `Span` ไม่สร้างส่วนเชื่อมต่อที่แสดงด้านบน; คอลัมน์ที่หายและคอลัมน์สูงศูนย์อาจดูคล้ายกัน เช่นกัน แผนภูมิกระจายที่มีเพียงมาร์คเกอร์ก็ไม่มีเส้นเชื่อมต่อ อย่าคาดหวังผลลัพธ์ที่แตกต่างสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้

## **ตั้งค่าความกว้างช่องว่างของชุดข้อมูล**

ความกว้างช่องว่างคือช่องว่างระหว่างกลุ่มแท่งหรือคอลัมน์ที่อยู่ติดกัน แสดงเป็นเปอร์เซ็นต์ของความกว้างแท่งหรือคอลัมน์ เช่นเดียวกับการทับซ้อน มันเป็นของกลุ่มชุดข้อมูลแม่ ไม่ได้เป็นของชุดข้อมูลเดียว ตั้งค่า[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) หนึ่งครั้งสำหรับกลุ่ม ค่าที่มากกว่าจะทำให้ช่องว่างระหว่างกลุ่มเพิ่มขึ้น; ค่าที่น้อยกว่าจะทำให้กลุ่มแน่นขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างช่องว่างและบันทึกการนำเสนอสุดท้ายเท่านั้น:

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

![The gap width](gap_width.png)

## **FAQ**

**ประเภทแผนภูมิใดบ้างที่สนับสนุนชุดข้อมูล?**

ทุกประเภทแผนภูมิที่แสดงโดยอาเรย์[ChartType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ชุดข้อมูลของแต่ละประเภทอาจมีโครงสร้างค่าและการตั้งค่าที่แตกต่างกัน ตัวอย่างเช่น แผนภูมิกลุ่มใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, และแผนภูมิบับเบิลเพิ่มขนาดของบับเบิล ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทชุดข้อมูล ตัวเลือกเช่นการทับซ้อนและความกว้างช่องว่างใช้ได้เฉพาะกับกลุ่มแท่งหรือคอลัมน์ที่เข้ากัน

**ชุดข้อมูลกลุ่มคืออะไร?**

[IChartSeriesGroup](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseriesgroup/) ประกอบด้วยชุดข้อมูลที่เข้ากันซึ่งใช้การตั้งค่าการพล็อตระดับกลุ่มเดียวกัน แผนภูมิแบบรวมอาจมีมากกว่าหนึ่งกลุ่ม ดังนั้นการเปลี่ยนแปลงกลุ่มผ่านชุดข้อมูลหนึ่งไม่ได้หมายความว่าจะเปลี่ยนแปลงทุกชุดข้อมูลในแผนภูมิ

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่ โดยปกติ[IShapeCollection.AddChart](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addchart/) จะสร้างชุดข้อมูล, หมวดหมู่, และค่าเป็นตัวอย่าง คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดคอลเลกชันชุดข้อมูลและหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างเต็มรูปแบบ อีกหนึ่งการโอเวอร์โหลดยังสามารถสร้างแผนภูมิที่ไม่มีข้อมูลเริ่มต้นได้

**วัตถุแผนภูมิต่อกับเซลล์สมุดงานอย่างไร?**

ชื่อชุดข้อมูล, ป้ายหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน[IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/). การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิตรงนั้น เมื่อคุณสร้างข้อมูลกำหนดเอง ควรรักษาแถวของหมวดหมู่และแถวของค่าชุดข้อมูลให้สอดคล้องกัน เพื่อให้แต่ละจุดพล็อตภายใต้หมวดหมู่ที่ต้องการ

**จะลบจุดเดียวโดยไม่ลบชุดข้อมูลทั้งหมดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดเป็นจุดว่าง ใช้[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapointcollection/clear/) เฉพาะเมื่อต้องการลบจุดทั้งหมดจากชุดนั้น หากคุณลบหมวดหมู่ออกด้วย ควรอัปเดตทุกชุดข้อมูลให้ค่าตรงกับคอลเลกชันหมวดหมู่ใหม่

**จุดว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและ[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/displayblanksas/). แผนภูมิที่รองรับสามารถแสดงช่องว่างเป็นช่องว่าง, เป็นค่า 0, หรือเชื่อมต่อจุดใกล้เคียงได้ เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ ดูส่วน[ควบคุมการแสดงผลของเซลล์ว่าง](#control-the-display-of-empty-cells) เพื่อดูตัวอย่างเต็มและการเปรียบเทียบภาพ

**ค่าติดลบจะถูกจัดรูปแบบอย่างไร?**

สำหรับชุดข้อมูลแท่ง, คอลัมน์, และบับเบิลที่สนับสนุน ให้เปิด[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/invertifnegative/) และตั้ง[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). คุณสามารถทับการทำงานสำหรับจุดเดียวด้วย[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). คุณสมบัติเหล่านี้ส่งผลต่อการจัดรูปแบบ ไม่ได้เปลี่ยนค่าตัวเลขที่เก็บไว้

**การจัดรูปแบบใดชนะเมื่อทั้งชุดและจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดโดยตรงจะมีอำนาจเหนือสำหรับจุดนั้น จุดอื่น ๆ จะใช้รูปแบบชุดข้อมูลที่กำหนดไว้หรือถ้าไม่มีจะใช้สไตล์และธีมของแผนภูมิโดยอัตโนมัติ คุณสมบัติกลุ่มเช่นการทับซ้อนและความกว้างช่องว่างควบคุมการจัดวางและไม่ใช่การทับซ้อนระดับจุด

**แผนภูมิสามารถมีจำนวนชุดข้อมูลได้สูงสุดเท่าใด?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดข้อมูลแบบคงที่ ในทางปฏิบัติ ข้อจำกัดของไฟล์การนำเสนอ, หน่วยความจำที่มี, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิจะเป็นตัวกำหนดขีดจำกัดที่ใช้ได้จริง

**ควรทำอย่างไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

ตั้งค่า[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) บนกลุ่มชุดข้อมูลแม่ที่เหมาะสม เพิ่มค่าจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น หรือ ลดค่าเพื่อให้กลุ่มใกล้กันมากขึ้น.