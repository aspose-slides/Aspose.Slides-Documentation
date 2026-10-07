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
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์ workbook, การจัดรูปแบบ, การทับซ้อน, ความกว้างช่องว่าง, และค่าลบในงานนำเสนอด้วย C#."
---
## **ภาพรวม**

แผนภูมิจะเก็บข้อมูลที่แสดงผลในแบบ workbook ของข้อมูลแผนภูมิ [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) ในชุดอ้างอิงถึงเซลล์ workbook หนึ่งหรือหลายเซลล์ [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) ให้ป้ายหรือค่าการจัดกลุ่มที่ใช้ร่วมกันระหว่างชุด ชื่อชุด, หมวดหมู่ และค่าจุดจึงเชื่อมต่อกับวัตถุ [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) แทนที่จะถูกเก็บไว้เป็นข้อความที่แสดงเท่านั้น

สำหรับแผนภูมิประเภทหมวดหมู่ทั่วไป workbook เริ่มต้นจะใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าชุด [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) รับดัชนีแผ่นงาน, แถวและคอลัมน์โดยอิงศูนย์ การจัดวางนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิกับข้อมูลเริ่มต้น, แต่ไม่ควรสันนิษฐานว่าแผนภูมิก่อนหน้าทุกอันใช้รูปแบบนี้ สำหรับงานนำเสนอที่โหลดแล้วควรตรวจสอบเซลล์ที่อ้างอิงโดยชุด, หมวดหมู่และจุดข้อมูลก่อนทำการเปลี่ยนแปลงค่าใน workbook

การตั้งค่าของแผนภูมิมี 3 ขอบเขตแตกต่างกัน

- การตั้งค่าระดับชุด เช่น [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) กำหนดรูปลักษณ์เริ่มต้นสำหรับจุดทั้งหมดในชุดหนึ่ง
- การตั้งค่าระดับจุดข้อมูล เช่น [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) ทับรูปลักษณ์ของชุดสำหรับจุดเดียว
- การตั้งค่ากลุ่มใช้กับชุดที่เข้ากันได้ซึ่งอยู่ใน [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) เข้าถึงกลุ่มผ่าน [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) เมื่อคุณต้องการกำหนดตัวเลือกเช่น overlap หรือ gap width

เมื่อไม่ได้ตั้งค่าการเติมสีจุดหรือชุดอย่างชัดเจน, รูปแบบและธีมของแผนภูมิจะกำหนดรูปลักษณ์อัตโนมัติ เมื่อมีการกำหนดรูปแบบทั้งชุดและจุด, การกำหนดรูปแบบของจุดจะมีลำดับความสำคัญสำหรับจุดนั้น

![แผนภูมิซีรีส์ใน PowerPoint](chart-series-powerpoint.png)

## **ตั้งค่า Overlap ของชุดแผนภูมิ**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) แสดงว่าบาร์หรือคอลัมน์ทับกันเท่าไหร่ในแผนภูมิ 2‑มิติ, ตั้งแต่ ‑100 ถึง 100 เปอร์เซ็นต์ เป็นการแสดงผลแบบอ่านอย่างเดียวของการตั้งค่าบนกลุ่มชุดพาเรนต์ ตั้งค่า [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; ไม่กระทบกับกลุ่มชุดที่ไม่เกี่ยวข้องในแผนภูมิแบบผสม

ตัวอย่างต่อไปนี้ตั้งค่า overlap สำหรับกลุ่มที่มีชุดแรกอยู่

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// แผนภูมิใหม่มีชุดตัวอย่าง, หมวดหมู่, และค่า.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![การทับซ้อนของชุด](series_overlap.png)

## **เปลี่ยนสีเติมของชุด**

ใช้ [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) เพื่อกำหนดสีเติมเริ่มต้นสำหรับชุดทั้งหมด หากจุดมีการกำหนดสีเติมอย่างชัดเจนแล้ว, การตั้งค่า [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) จะทับสีเติมของชุดสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ทำสีเติมแบบทึบสีฟ้าให้กับชุดแรก

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

ชื่อชุดจะถูกเก็บใน workbook ของข้อมูลแผนภูมิและปกติจะแสดงในคำอธิบาย legend ใน workbook เริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบกลุ่ม, เซลล์ B1 อยู่ที่แถว 0 คอลัมน์ 1 และบรรจุชื่อของชุดแรก ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนั้นชัดเจน

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

คุณยังสามารถอัปเดตเซลล์ที่ [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) อ้างอิงอยู่ วิธีนี้หลีกเลี่ยงการสันนิษฐานแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่

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

### **สร้างชุดด้วยชื่อจากหลายเซลล์**

ชื่อชุดแบบประกอบมีประโยชน์เมื่อชื่อผลิตภัณฑ์และช่วงเวลารายงานถูกเก็บในเซลล์ workbook แยกกัน ตัวอย่างเช่น คุณสามารถรวม `Product A` ใน B1 และ `2026` ใน C1 เป็นชื่อชุดเดียวโดยยังคงเชื่อมโยงทั้งสองส่วนกับเซลล์ต้นทางของพวกมัน

ใช้ [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) เพื่อดึงช่วงชื่อ, แล้วส่งคอลเลกชันนั้นไปยัง [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/) อาร์กิวเมนต์ skipHiddenCells ควบคุมว่าจะรวมเซลล์ที่ซ่อนไว้หรือไม่: true ยกเว้น, false รวม ตัวอย่างนี้ใช้ false เพื่อรวมทุกเซลล์ในช่วงชื่อ

ตัวอย่างต่อไปนี้สร้างงานนำเสนอที่มีชุดหนึ่งและจุดข้อมูลสองจุด เซลล์ B1:C1 ให้ชื่อชุดเท่านั้น; A2:A3 ให้ป้ายหมวดหมู่; B2:B3 ให้ค่าตัวเลข

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 620, 180);

chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = true;

var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);

// เซลล์สองเซลล์นี้ให้ชื่อชุด.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// เซลล์แยกกันให้หมวดหมู่และจุดข้อมูลเชิงตัวเลข.
var northCategory = workbook.GetCell(0, 1, 0, "North");
var southCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(northCategory);
chart.ChartData.Categories.Add(southCategory);
var northValue = workbook.GetCell(0, 1, 1, 120);
var southValue = workbook.GetCell(0, 2, 1, 150);
series.DataPoints.AddDataPointForBarSeries(northValue);
series.DataPoints.AddDataPointForBarSeries(southValue);

presentation.Save("composite_series_name.pptx", SaveFormat.Pptx);
```

ชื่อชุดที่ได้คือ `Product A 2026` (มีช่องว่างระหว่างค่าจากสองเซลล์) คำอธิบายจะแสดงเป็นรายการเดียวสำหรับสองคอลัมน์ ภาพต่อไปนี้สร้างจากงานนำเสนอที่บันทึกไว้:

![แผนภูมิคอลัมน์ที่มีค่าทิศเหนือและทิศใต้พร้อมชื่อชุดประกอบ Product A 2026 ใน legend](composite_series_name.png)

## **รับสีเติมอัตโนมัติของชุด**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) คืนค่าสีที่คำนวณจากดัชนีชุดและสไตล์แผนภูมิ นี่คือสีที่ใช้เมื่อสีเติมของชุดไม่ได้กำหนดอย่างชัดเจน การเรียกเมธอดนี้อ่านสีที่คำนวณได้; ไม่ได้กำหนดสีเติมใหม่

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดเริ่มต้น

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

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิโดยปริยาย:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

สีที่ได้จะขึ้นอยู่กับสไตล์และธีมของแผนภูมิ

## **ตั้งค่าสีเติมกลับด้านสำหรับชุดแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์และบับเบิล, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) สามารถแสดงค่าลบด้วยสีเติมที่ต่างออกไป ตั้งค่าสีเติมปกติเป็นสีทึบ, เปิดใช้งานการกลับด้าน, และกำหนดสีค่าลบผ่าน [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) ค่าตัวเลขลบจะไม่เปลี่ยนใน workbook; มีเพียงสีการแสดงผลที่เปลี่ยน

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิโดยกำหนดชุดเดียว แผ่นงานแถว 0 บรรจุชื่อชุด, คอลัมน์ 0 บรรจุชื่อหมวดหมู่, และคอลัมน์ 1 บรรจุค่าต่าง ๆ

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

![สีเติมแบบทึบที่กลับด้าน](inverted_solid_fill_color.png)

คุณสามารถเปิดการกลับด้านสำหรับจุดเดียวผ่าน [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) ในตัวอย่างต่อไปนี้ การกลับด้านถูกปิดสำหรับชุดและเปิดเฉพาะจุดที่เลือก จุดนั้นยังถูกกำหนดค่าลบเพื่อให้เห็นผลลัพธ์

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

เพื่อทำให้จุดหนึ่งเป็นค่าว่างโดยไม่ลบจุดอื่น ๆ ให้ตั้งค่าเซลล์ workbook ที่รองรับเป็น `null` สำหรับแผนภูมิคอลัมน์, ค่าที่แสดงผลได้จาก [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) จุดข้อมูลจะคงตำแหน่งหมวดหมู่เดิม, แต่แผนภูมิจะแTreat ค่าดังกล่าวเป็นค่าว่างตามการตั้งค่าค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ลบเฉพาะจุดที่สองในชุดแรก

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

แผนภูมิสเก็ตเตอร์ใช้เซลล์ X และ Y แยกกัน, แผนภูมิบับเบิลยังใช้เซลล์ขนาดด้วย ลบเฉพาะเซลล์ที่แทนค่าที่คุณต้องการลบ อย่าเรียก [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) เมื่อคุณต้องการเก็บจุดอื่น ๆ เพราะเมธอดนั้นจะลบจุดทั้งหมดจากคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ซ่อนที่มีค่าเป็นกรณีที่แตกต่างจากเซลล์ว่าง เพื่อรวมหรือแยกข้อมูลจากแถวและคอลัมน์ที่ซ่อน, ดู [Include Data from Hidden Rows and Columns](/slides/th/net/chart-workbook/#include-data-from-hidden-rows-and-columns)

เซลล์ workbook ที่ว่างเปล่าแสดงว่าขาดข้อมูล; เซลล์ที่มีค่า `0` แสดงว่ามีค่าตัวเลขที่รู้จัก ตั้งค่า [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) เป็น `null` เพื่อทำให้เซลล์ว่าง ค่าตัวเลขศูนย์จะคงเป็นศูนย์ไม่ว่าการตั้งค่าเซลล์ว่างจะเป็นอย่างไร

ใช้ [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) เพื่อเลือกวิธีที่แผนภูมิจะแสดงเซลล์ว่าง การตั้งค่านี้ใช้กับแผนภูมิทั้งหมดและเปลี่ยนวิธีการพล็อตค่าว่างโดยไม่เติมค่า 0 หรือค่าประมาณใด ๆ ลงในเซลล์ workbook

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นเดียวที่มีชุดหนึ่ง, ลบค่าของ Day 3, แล้วบันทึกแผนภูมิกับแต่ละโหมด ไม่ต้องใช้ไฟล์อินพุต [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) ใช้แผ่นงาน 0, คอลัมน์ 0 สำหรับป้ายหมวดหมู่, คอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อชุด ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`

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

แต่ละไฟล์ผลลัพธ์บันทึกโหมดที่กำหนดก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx` เพื่อบันทึกเวอร์ชันเดียวให้กำหนดโหมดที่ต้องการแล้วบันทึกงานนำเสนอหนึ่งครั้งแทนการวนลูปตามโหมด

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในสามไฟล์ Day 3 เป็นค่าว่างใน workbook ทั้งกรณี

![แผนภูมิเส้นที่มีข้อมูลเดียวกัน: Gap ทำให้เส้นขาดที่ Day 3, Zero ทำให้เส้นตกลงเป็นศูนย์, และ Span เชื่อม Day 2 กับ Day 4](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับประเภทแผนภูมิ แผนภูมิแบบเส้นทำให้เปรียบเทียบสามโหมดได้ง่าย แผนภูมิแบบบาร์และคอลัมน์ไม่มีเส้นเชื่อมข้ามหมวดหมู่ที่หายไป ดังนั้น Span ไม่สามารถสร้างส่วนเชื่อมที่แสดงด้านบนได้; คอลัมน์ที่หายไปและคอลัมน์ศูนย์อาจดูคล้ายกันเช่นกัน เช่นเดียวกับแผนภูมิสเก็ตเตอร์ที่มีเครื่องหมายเท่านั้นไม่มีเส้นเชื่อม อย่าคาดหวังผลลัพธ์ที่แตกต่างสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้

## **ตั้งค่าความกว้างช่องว่างของชุด**

ความกว้างช่องว่างคือระยะห่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์ เช่นเดียวกับ overlap มันเป็นของกลุ่มชุดพาเรนต์ ไม่ใช่ของชุดเดียวตั้งค่า [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) ครั้งเดียวสำหรับกลุ่ม ค่าใหญ่สร้างช่องว่างมากขึ้นระหว่างคลัสเตอร์; ค่าเล็กทำให้คลัสเตอร์แน่นขึ้น

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างช่องว่างและบันทึกงานนำเสนอขั้นสุดท้ายเท่านั้น

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

**แผนภูมิประเภทใดสนับสนุนชุดข้อมูล?**

ทุกประเภทแผนภูมิที่แสดงโดยการนับ [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) ใช้ข้อมูลแผนภูมิ, แต่ชุดของพวกมันไม่ได้มีโครงสร้างค่าหรือการตั้งค่าเดียวกัน ตัวอย่างเช่น แผนภูมิเจือบใช้หมวดหมู่และค่า, แผนภูมิสเก็ตเตอร์ใช้ค่า X และ Y, และแผนภูมิบับเบิลเพิ่มขนาดบับเบิล ใช้วิธีการสร้างจุดข้อมูลที่ตรงกับประเภทชุด ตัวเลือกเช่น overlap และ gap width ใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้

**กลุ่มชุดแผนภูมิคืออะไร?**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) บรรจุชุดที่เข้ากันได้ซึ่งแชร์การตั้งค่าการพล็อตระดับกลุ่ม แผนภูมิแบบผสมอาจมีมากกว่าหนึ่งกลุ่ม ดังนั้นการเปลี่ยนกลุ่มผ่านชุดหนึ่งอาจไม่ได้เปลี่ยนทุกชุดในแผนภูมิ

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่ โดยค่าเริ่มต้น [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) สร้างชุดตัวอย่าง, หมวดหมู่และค่า คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์ทั้งชุดและคอลเลกชันหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างสมบูรณ์ การ overload ยังสามารถสร้างแผนภูมิที่ไม่มีข้อมูลเริ่มต้นได้

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์ workbook อย่างไร?**

ชื่อชุด, ป้ายหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิที่สอดคล้องกัน เมื่อคุณสร้างข้อมูลกำหนดเองให้รักษาแถวหมวดหมู่และแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุดถูกพล็อตภายใต้หมวดหมู่ที่ตั้งใจ

**ฉันจะลบจุดเดียวแทนการลบทั้งชุดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดเป็นจุดว่าง ใช้ [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) เฉพาะเมื่อคุณต้องการลบทุกจุดจากชุดนั้น หากคุณลบหมวดหมู่ด้วย ให้ปรับทุกชุดเพื่อให้ค่าของพวกมันยังคงสอดคล้องกับคอลเลกชันหมวดหมู่

**จุดว่างแสดงผลอย่างไร?**

ผลลัพธ์ขึ้นอยู่กับประเภทแผนภูมิและ [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) แผนภูมิที่รองรับสามารถแสดงช่องว่างเป็นช่องว่าง, ค่า 0 หรือโดยเชื่อมจุดใกล้เคียง เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในงานนำเสนอของคุณ ดู [Control the Display of Empty Cells](#control-the-display-of-empty-cells) สำหรับตัวอย่างสมบูรณ์และการเปรียบเทียบภาพ

**ค่าติดลบจะถูกจัดรูปแบบอย่างไร?**

สำหรับชุดบาร์, คอลัมน์และบับเบิลที่รองรับ, เปิด [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) และตั้งค่า [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) คุณสามารถทับพฤติกรรมสำหรับจุดเดี่ยวด้วย [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) คุณสมบัติเหล่านี้มีผลต่อการจัดรูปแบบ, ไม่ได้เปลี่ยนค่าตัวเลขที่จัดเก็บ

**การจัดรูปแบบใดชนะเมื่อทั้งชุดและจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดข้อมูลที่ระบุอย่างชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น จุดอื่น ๆ จะใช้การจัดรูปแบบชุดที่ระบุหรือถ้าไม่มีการกำหนดชุดจะใช้สไตล์และธีมแผนภูมิโดยอัตโนมัติ คุณสมบัติของกลุ่มเช่น overlap และ gap width ควบคุมการวางตำแหน่งและไม่ใช่การทับการจัดรูปแบบระดับจุด

**มีขีดจำกัดจำนวนชุดที่แผนภูมิสามารถมีได้หรือไม่?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดแบบแยก อย่างไรก็ตามข้อจำกัดของไฟล์นำเสนอ, หน่วยความจำ, เวลาเรนเดอร์และความอ่านง่ายของแผนภูมินั้นจะกำหนดขีดจำกัดที่ใช้ได้จริง

**ฉันควรทำอย่างไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันเกินไป?**

ตั้งค่า [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) บนกลุ่มพาเรนต์ที่เหมาะสม เพิ่มค่เพื่อขยายช่องว่างระหว่างคลัสเตอร์ หรือ ลดค่าเพื่อทำให้คลัสเตอร์เข้าใกล้กันขึ้น