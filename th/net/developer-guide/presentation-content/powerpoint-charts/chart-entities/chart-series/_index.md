---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอด้วย .NET
linktitle: ชุดข้อมูล
type: docs
url: /th/net/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การทับซ้อนของชุดข้อมูล
- สีของชุดข้อมูล
- สีหมวดหมู่
- ชื่อชุดข้อมูล
- จุดข้อมูล
- ช่องว่างของชุดข้อมูล
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์ workbook, การจัดรูปแบบ, การทับซ้อน, ความกว้างของช่องว่าง, และค่าติดลบในงานนำเสนอด้วย C#."
---
## **ภาพรวม**

แผนภูมิจัดเก็บข้อมูลที่พล็อตไว้ใน workbook ของข้อมูลแผนภูมิ ตัว[IChartSeries](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ[IChartDataPoint](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/) ในซีรีส์อ้างอิงถึงเซลล์ workbook หนึ่งหรือหลายเซลล์ วัตถุ[IChartCategory](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartcategory/) จัดหาเลเบลหรือค่ากลุ่มที่ใช้ร่วมกันโดยซีรีส์ ชื่อซีรีส์, หมวดหมู่, และค่าจุดจึงเชื่อมต่อกับวัตถุ[IChartDataCell](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatacell/) แทนที่จะจัดเก็บเป็นข้อความแสดงผลอย่างเดียว

สำหรับแผนภูมิประเภทหมวดหมู่ทั่วไป workbook เริ่มต้นใช้แถว 0 สำหรับชื่อซีรีส์, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าซีรีส์ ดัชนี worksheet, แถว, และคอลัมน์ที่ส่งให้[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/getcell/) เป็นค่าเริ่มจากศูนย์ โครงสร้างนี้มีประโยชน์เมื่อคุณสร้างแผนภูมิพร้อมข้อมูลเริ่มต้น แต่ห้ามสันนิษฐานว่าทุกแผนภูมิที่มีอยู่ใช้โครงสร้างนี้ สำหรับการนำเสนอที่โหลดแล้ว ให้ตรวจสอบเซลล์ที่อ้างอิงโดยซีรีส์, หมวดหมู่, และจุดข้อมูลก่อนที่จะแก้ไขค่าของ workbook

การตั้งค่าแผนภูมิมีสามระดับขอบเขตที่แตกต่างกัน:

- การตั้งค่าระดับซีรีส์ เช่น[IChartSeries.Format](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/format/) ให้ลักษณะเริ่มต้นสำหรับจุดทั้งหมดในซีรีส์เดียว
- การตั้งค่าจุดข้อมูล เช่น[IChartDataPoint.Format](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/format/) จะครอบคลุมลักษณะของซีรีส์สำหรับจุดเดียว
- การตั้งค่ากลุ่มใช้กับซีรีส์ที่เข้ากันได้ซึ่งอยู่ใน[IChartSeriesGroup](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseriesgroup/) เดียวกัน เข้าถึงกลุ่มผ่าน[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/parentseriesgroup/) เมื่อคุณต้องการตั้งค่าต่าง ๆ เช่น การทับซ้อนหรือความกว้างของช่องว่าง

เมื่อไม่ได้ตั้งค่าการเติมจุดหรือซีรีส์อย่างชัดเจน สไตล์และธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติ เมื่อมีการกำหนดรูปแบบทั้งซีรีส์และจุดพร้อมกัน การกำหนดรูปแบบจุดจะมีลำดับความสำคัญสำหรับจุดนั้น

![แผนภูมิซีรีส์ใน PowerPoint](chart-series-powerpoint.png)

## **ตั้งค่าการทับซ้อนของซีรีส์แผนภูมิ**

[IChartSeries.Overlap](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/overlap/) รายงานว่าบาร์หรือคอลัมน์ทับซ้อนกันเท่าใดในแผนภูมิ 2D ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์ เป็นการฉายค่าที่อ่านได้อย่างเดียวจากการตั้งค่ากลุ่มซีรีส์แม่ ตั้งค่า[IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseriesgroup/overlap/) เพื่ออัปเดตทุกซีรีส์ที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้ได้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์ที่จัดกลุ่ม; ไม่ส่งผลต่อกลุ่มซีรีส์ที่ไม่เกี่ยวข้องในแผนภูมิกำหนดค่าแบบผสม

ตัวอย่างต่อไปนี้ตั้งค่าการทับซ้อนสำหรับกลุ่มที่ประกอบด้วยซีรีส์แรก:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// แผนภูมิใหม่มีซีรีส์ตัวอย่าง, หมวดหมู่, และค่า.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![การทับซ้อนของซีรีส์](series_overlap.png)

## **เปลี่ยนสีเติมของซีรีส์**

ใช้[IChartSeries.Format](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/format/) เพื่อกำหนดสีเติมเริ่มต้นให้กับทั้งซีรีส์ หากจุดหนึ่งมีการกำหนดสีเติมไว้แล้ว การตั้งค่า[IChartDataPoint.Format](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/format/) จะครอบคลุมสีเติมของซีรีส์สำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้สีเติมสีฟ้าแบบทึบกับซีรีส์แรก:

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

![สีของซีรีส์](series_color.png)

## **เปลี่ยนชื่อซีรีส์**

ชื่อซีรีส์ถูกเก็บไว้ใน workbook ของข้อมูลแผนภูมิและปกติแสดงในคำอธิบาย (legend) ใน workbook เริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบกลุ่ม เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และมีชื่อของซีรีส์แรก ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างดังกล่าวชัดเจน:

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

คุณยังสามารถอัปเดตเซลล์ที่[IChartSeries.Name](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/name/) อ้างอิงอยู่ได้ วิธีนี้ช่วยหลีกเลี่ยงการสันนิษฐานแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

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

![ชื่อซีรีส์](series_name.png)

## **รับสีเติมอัตโนมัติของซีรีส์**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) คืนค่าผลลัพธ์สีที่คำนวณจากดัชนีซีรีส์และสไตล์ของแผนภูมิ นี่คือสีที่ใช้เมื่อสีเติมของซีรีส์ไม่ได้กำหนดอย่างชัดเจน การเรียกเมธอดนี้อ่านสีที่คำนวณแล้ว; ไม่ได้กำหนดสีเติมใหม่

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละซีรีส์เริ่มต้น:

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

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิเบื้องต้น:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

สีที่ได้จะขึ้นอยู่กับสไตล์และธีมของแผนภูมิ

## **ตั้งค่าสีเติมกลับด้านสำหรับซีรีส์แผนภูมิ**

สำหรับซีรีส์บาร์, คอลัมน์, และบับเบิล, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/invertifnegative/) สามารถแสดงค่าลบด้วยสีเติมที่ต่างออกไป ตั้งค่าสีเติมปกติให้เป็นสีทึบ, เปิดการกลับด้าน, แล้วกำหนดสีค่าลบผ่าน[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). ค่าติดลบใน workbook จะไม่เปลี่ยน; มีเพียงสีการแสดงผลที่เปลี่ยนเท่านั้น

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิเบื้องต้นด้วยซีรีส์เดียว Worksheet แถว 0 มีชื่อซีรีส์, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่าต่าง ๆ:

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

![สีเติมทึบกลับด้าน](inverted_solid_fill_color.png)

คุณสามารถเปิดการกลับด้านสำหรับจุดเดียวผ่าน[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). ในตัวอย่างต่อไปนี้ การกลับด้านถูกปิดสำหรับซีรีส์และเปิดเฉพาะสำหรับจุดที่เลือก จุดนั้นยังได้รับค่าลบเพื่อให้เห็นผลของการกลับด้าน:

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

## **ลบค่าจุดข้อมูลเฉพาะ**

เพื่อทำให้จุดหนึ่งเป็นค่าว่างโดยไม่ลบจุดอื่น ใหตั้งค่าเซลล์ workbook ที่สนับสนุนจุดนั้นเป็น `null` สำหรับแผนภูมิคอลัมน์, ค่าที่พล็อตได้มาจาก[IChartDataPoint.YValue](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/yvalue/). จุดข้อมูลจะอยู่ตำแหน่งหมวดหมู่เดียวกัน, แต่แผนภูมิจะมองว่าค่าของมันเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ลบเฉพาะจุดที่สองในซีรีส์แรก:

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

แผนภูมิกระจาย (scatter) ใช้เซลล์ X และ Y แยกกัน, และแผนภูมิบับเบิลยังใช้เซลล์ขนาดด้วย ให้ลบเฉพาะเซลล์ที่เป็นค่าที่คุณต้องการลบ อย่าเรียก[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapointcollection/clear/) เมื่อคุณต้องการเก็บจุดอื่นไว้ เพราะเมธอดนั้นจะลบจุดข้อมูลทั้งหมดจากคอลเลกชัน

## **ตั้งค่าความกว้างของช่องว่างระหว่างซีรีส์**

ความกว้างของช่องว่างคือระยะห่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์ เช่นเดียวกับการทับซ้อน, มันเป็นของกลุ่มซีรีส์แม่ ไม่ใช่ของซีรีส์เดียว ตั้งค่า[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) ครั้งเดียวสำหรับกลุ่ม ค่าใหญ่ขึ้นจะสร้างช่องว่างระหว่างกลุ่มมากขึ้น; ค่าเล็กลงจะทำให้กลุ่มแน่นขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างของช่องว่างและบันทึกเพียงการนำเสนอสุดท้าย:

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

![ความกว้างของช่องว่าง](gap_width.png)

## **คำถามที่พบบ่อย**

**ประเภทแผนภูมิใดสนับสนุนซีรีส์ข้อมูล?**

ทุกประเภทแผนภูมิที่แสดงโดยการนับจำนวน[ChartType](https://reference.aspose.com/slides/th/net/aspose.slides.charts/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ซีรีส์ของพวกมันไม่ได้มีโครงสร้างค่าหรือการตั้งค่าเดียวกัน ตัวอย่างเช่น แผนภูมิจัดหมวดใช้หมวดและค่า, แผนภูมิกระจายใช้ค่า X และ Y, ส่วนแผนภูมิบับเบิลเพิ่มขนาดบับเบิล ใช้วิธีการสร้างจุดข้อมูลที่สอดคล้องกับประเภทซีรีส์ ตัวเลือกอย่างการทับซ้อนและความกว้างช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้

**กลุ่มซีรีส์แผนภูมิคืออะไร?**

[IChartSeriesGroup](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseriesgroup/) ประกอบด้วยซีรีส์ที่เข้ากันได้ซึ่งใช้การตั้งค่าการพล็อตระดับกลุ่ม แผนภูมิแบบผสมอาจมีมากกว่าหนึ่งกลุ่ม ดังนั้นการเปลี่ยนแปลงกลุ่มผ่านซีรีส์หนึ่งไม่จำเป็นต้องเปลี่ยนแปลงทุกซีรีส์ในแผนภูมิ

**แผนภูมิใหม่ที่สร้างขึ้นมามีข้อมูลเริ่มต้นหรือไม่?**

มี. โดยค่าเริ่มต้น, [IShapeCollection.AddChart](https://reference.aspose.com/slides/th/net/aspose.slides/ishapecollection/addchart/) จะสร้างซีรีส์ตัวอย่าง, หมวดหมู่, และค่า คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์คอลเลกชันซีรีส์และหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองทั้งหมด การ overload ยังสามารถสร้างแผนภูมิที่ไม่มีข้อมูลเริ่มต้นได้

**วัตถุแผนภูมิเชื่อมโยงกับเซลล์ workbook อย่างไร?**

ชื่อซีรีส์, ป้ายหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน[IChartDataWorkbook](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdataworkbook/). การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิที่สอดคล้องกัน เมื่อคุณสร้างข้อมูลแบบกำหนดเอง, ให้รักษาแถวหมวดหมู่และแถวค่าซีรีส์ให้สอดคล้องกันเพื่อให้แต่ละจุดพล็อตอยู่ภายใต้หมวดหมู่ที่ต้องการ

**ฉันจะลบจุดเดียวแทนที่จะลบทั้งซีรีส์ได้อย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดเป็นจุดว่าง ใช้[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapointcollection/clear/) เฉพาะเมื่อคุณต้องการลบจุดทั้งหมดจากซีรีส์นั้น หากคุณลบหมวดหมู่ด้วย, ควรอัปเดตทุกซีรีส์เพื่อให้ค่าของพวกมันยังคงสอดคล้องกับคอลเลกชันหมวดหมู่

**จุดว่างแสดงผลอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและ[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichart/displayblanksas/). แผนภูมิที่รองรับสามารถแสดงค่าว่างเป็นช่องว่าง, เป็นค่าเป็นศูนย์, หรือโดยการเชื่อมต่อจุดใกล้เคียง เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ

**ค่าติดลบถูกจัดรูปแบบอย่างไร?**

สำหรับบาร์, คอลัมน์, และซีรีส์บับเบิลที่รองรับ, เปิด[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/invertifnegative/) แล้วตั้ง[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). คุณสามารถครอบคลุมพฤติกรรมสำหรับจุดเดียวด้วย[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). คุณสมบัติเหล่านี้มีผลต่อการจัดรูปแบบ, ไม่ได้เปลี่ยนค่าตัวเลขที่เก็บไว้

**การจัดรูปแบบใดชนะเมื่อทั้งซีรีส์และจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดข้อมูลอย่างชัดเจนมีลำดับความสำคัญสำหรับจุดนั้น จุดอื่น ๆ ยังคงใช้รูปแบบซีรีส์ที่กำหนดไว้หรือหากไม่มีการกำหนดรูปแบบซีรีส์ ระบบจะใช้สไตล์และธีมของแผนภูมิอัตโนมัติ คุณสมบัติกลุ่มเช่นการทับซ้อนและความกว้างของช่องว่างควบคุมการจัดวางและไม่ใช่การครอบคลุมระดับจุด

**แผนภูมิสามารถมีซีรีส์ได้มากที่สุดเท่าใด?**

Aspose.Slides ไม่กำหนดขีดจำกัดจำนวนซีรีส์ที่แยกต่างหาก อย่างไรก็ตาม ขีดจำกัดจริงจะขึ้นกับข้อจำกัดของไฟล์การนำเสนอ, หน่วยความจำที่ใช้, เวลาเรนเดอร์, และความอ่านง่ายของแผนภูมิ

**ต้องปรับอะไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

ตั้งค่า[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/th/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) บนกลุ่มซีรีส์แม่ที่เหมาะสม เพิ่มค่าที่ทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น หรือ ลดค่าเพื่อให้กลุ่มใกล้กันมากขึ้น