---
title: จัดการชุดข้อมูลแผนภูมิในงานนำเสนอใน .NET
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
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์ workbook, การจัดรูปแบบ, การทับซ้อน, ความกว้างช่องว่าง, และค่าติดลบในงานนำเสนอด้วย C#."
---
## **ภาพรวม**

แผนภูมิสามารถเก็บค่าที่พล็อตไว้ในเซลล์ของ workbook หรือโดยตรงเป็นค่าตัวเลขลิตเตรัลได้ [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) แสดงชุดค่าที่เกี่ยวข้องหนึ่งชุด และแต่ละ [IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) แทนจุดหนึ่งในชุดนั้น [IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) ให้ฉลากหรือค่ากลุ่มที่ใช้ร่วมกันระหว่างชุดข้อมูล ในแผนภูมิที่สร้างด้วยข้อมูลเริ่มต้น ชื่อชุดข้อมูล หมวดหมู่ และค่าจุดต่าง ๆ จะใช้วัตถุ [IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) จาก workbook ของแผนภูมิ

สำหรับแผนภูมิกลุ่มประเภททั่วไป workbook เริ่มต้นจะใช้แถว 0 สำหรับชื่อชุดข้อมูล คอลัมน์ 0 สำหรับชื่อหมวดหมู่ และเซลล์ที่เหลือสำหรับค่าชุดข้อมูล ดัชนี worksheet, แถว และคอลัมน์ที่ส่งให้ [IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) มีค่าเริ่มจาก 0 Layout นี้เป็นประโยชน์เมื่อต้องการสร้างแผนภูมิด้วยข้อมูลเริ่มต้น แต่ห้ามสันนิษฐานว่าแผนภูมิที่มีอยู่ทุกแผนภูมิใช้รูปแบบนี้ สำหรับการนำเสนอที่โหลดแล้ว ให้ตรวจสอบเซลล์ที่อ้างอิงโดยชุดข้อมูล หมวดหมู่ และจุดข้อมูลก่อนที่จะเปลี่ยนค่าใน workbook

การตั้งค่าแผนภูมิมีสามระดับที่แตกต่างกัน:

- การตั้งค่าระดับชุดข้อมูล เช่น [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) ให้ลักษณะเริ่มต้นสำหรับทุกจุดในชุดเดียว
- การตั้งค่าจุดข้อมูล เช่น [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) จะทับลักษณะของชุดข้อมูลสำหรับจุดเดียว
- การตั้งค่ากลุ่มนำไปใช้กับชุดข้อมูลที่เข้ากันซึ่งอยู่ภายใต้ [IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) เดียวกัน เข้าถึงกลุ่มผ่าน [IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) เมื่อจำเป็นต้องตั้งค่าตัวเลือกเช่น overlap หรือ gap width

เมื่อไม่มีการกำหนดสีเติมของจุดหรือชุดข้อมูลอย่างชัดเจน สไตล์และธีมของแผนภูมิจะกำหนดลักษณะที่สร้างโดยอัตโนมัติ เมื่อมีการกำหนดรูปแบบทั้งระดับชุดและระดับจุด รูปแบบจุดจะมีลำดับความสำคัญสูงกว่า

![แผนภูมิ-ซีรีส์-พาวเวอร์พอยท์](chart-series-powerpoint.png)

## **กำหนดค่าชุดข้อมูลโดยใช้ค่าตัวเลขลิตเตรัล**

ใช้ค่าตัวเลขลิตเตรัลเมื่อค่าชุดข้อมูลมาจากข้อมูลหรือการคำนวนในแอปพลิเคชันและไม่ต้องอ้างอิงเซลล์ worksheet ตั้งค่า [DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/) ให้เป็น [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/) ก่อนกำหนดค่า [Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/) ของแต่ละจุดผ่าน [AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/)

การตั้งค่าคอลเลกชันควบคุมประเภทแหล่งข้อมูลของค่าจุดทั้งหมดในชุดนั้น แต่ละจุดจะรายงานประเภทที่เลือกผ่าน [Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/) ซึ่งสามารถเปลี่ยนได้โดยการแก้ไขการตั้งค่าคอลเลกชัน เมื่ใช้ `Worksheet` ให้ใช้ [AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/) เพื่อเข้าถึงเซลล์ที่อ้างอิง เมื่ใช้ `DoubleLiterals` ให้ใช้ `AsLiteralDouble` เพื่ออ่านหรือเขียนตัวเลขโดยตรง

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์พร้อมชุดข้อมูลและหมวดหมู่เริ่มต้น แล้วกำหนดค่าที่คำนวนได้ 10, 20 ฯลฯ ให้กับจุดที่มีอยู่ของชุดแรก บันทึกการนำเสนอ เปิดใหม่อีกครั้งและพิมพ์ค่าที่เก็บไว้

```cs
using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
var series = chart.ChartData.Series[0];

series.DataPoints.DataSourceTypeForValues = DataSourceType.DoubleLiterals;
for (var i = 0; i < series.DataPoints.Count; i++)
{
    series.DataPoints[i].Value.AsLiteralDouble = (i + 1) * 10;
}

presentation.Save("numeric_literals.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("numeric_literals.pptx");
var reopenedSlide = reopenedPresentation.Slides[0];
var reopenedChart = (IChart)reopenedSlide.Shapes[0];
var reopenedSeries = reopenedChart.ChartData.Series[0];
foreach (var point in reopenedSeries.DataPoints)
{
    Console.WriteLine(point.Value.AsLiteralDouble);
}
```

ประเภทแหล่งข้อมูลของค่าจุดแยกจาก [IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/) ซึ่งระบุการตั้งค่า workbook ภายในหรือภายนอกของแผนภูมิ การใช้ค่าตัวเลขลิตเตรัลไม่ได้ลบ workbook ที่ฝังอยู่โดยอัตโนมัติ ในตัวอย่างนี้ workbook ยังคงใช้สำหรับฉลากหมวดหมู่ ชื่อชุดข้อมูล และชุดข้อมูลอื่น ๆ ดู [Chart Workbook](/slides/th/net/chart-workbook/) เพื่อเรียนรู้การจัดการ workbook

สำหรับแผนภูมิ scatter และ bubble ให้ตั้งค่า [DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/) และ [DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/) เพื่อเลือกแหล่งข้อมูลของ [XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/) และ [YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) แผนภูมิ bubble ยังใช้ [DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/) สำหรับ [BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/) ตั้งค่าแต่ละแหล่งที่เกี่ยวข้องเป็น `DoubleLiterals` ก่อนกำหนดตัวเลขผ่านคุณสมบัติ `AsLiteralDouble` ของค่าดังกล่าว

## **กำหนดค่า Overlap ของชุดข้อมูลในแผนภูมิ**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) รายงานว่าคอลลัมน์หรือแถบทับซ้อนกันเท่าใดในแผนภูมิ 2 มิติ จาก -100 ถึง 100 เปอร์เซ็นต์ ค่านี้เป็นการฉายผลแบบอ่านอย่างเดียวจากการตั้งค่าที่กลุ่มชุดข้อมูลแม่ ตั้งค่า [IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/) เพื่ออัปเดตทุกชุดที่เข้ากันในกลุ่มนั้น ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงแถบหรือคอลลัมน์เป็นกลุ่ม และไม่ส่งผลต่อกลุ่มชุดข้อมูลที่ไม่ได้เกี่ยวข้องในแผนภูมิแบบผสม

ตัวอย่างต่อไปนี้ตั้งค่า overlap สำหรับกลุ่มที่บรรจุชุดแรก

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// แผนภูมิใหม่มีชุดข้อมูลตัวอย่าง, หมวดหมู่, และค่า.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![การทับซ้อนของชุดข้อมูล](series_overlap.png)

## **เปลี่ยนสีเติมของชุดข้อมูล**

ใช้ [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/) เพื่อตั้งค่าสีเติมเริ่มต้นสำหรับทั้งชุด หากจุดหนึ่งมีการกำหนดสีเติมอย่างชัดเจน การตั้งค่า [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/) จะทับสีเติมของชุดสำหรับจุดนั้น

ตัวอย่างต่อไปนี้ใช้สีเติมแบบโซลิดสีน้ำเงินให้กับชุดแรก

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

![สีของชุดข้อมูล](series_color.png)

## **เปลี่ยนชื่อชุดข้อมูล**

ชื่อชุดข้อมูลถูกเก็บไว้ใน workbook ของแผนภูมิและปกติจะแสดงใน legend ใน workbook เริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบ clustered เซลล์ B1 อยู่ที่แถว 0 คอลัมน์ 1 และมีชื่อของชุดแรก ค่าคงที่ที่ตั้งชื่อในตัวอย่างต่อไปนี้ทำให้โครงสร้างนี้ชัดเจน

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

คุณยังสามารถอัปเดตเซลล์ที่อ้างอิงโดย [IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/) ได้ วิธีนี้จะหลีกเลี่ยงการสันนิษฐานแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่แล้ว

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

![ชื่อชุดข้อมูล](series_name.png)

### **สร้างชุดข้อมูลโดยใช้ชื่อจากหลายเซลล์**

ชื่อชุดข้อมูลแบบคอมโพสท์มีประโยชน์เมื่อชื่อสินค้าและช่วงเวลารายงานถูกเก็บในเซลล์ workbook แยกกัน ตัวอย่างเช่น สามารถรวม `Product A` ใน B1 กับ `2026` ใน C1 เป็นชื่อชุดเดียวโดยยังคงเชื่อมโยงทั้งสองส่วนไปยังเซลล์ต้นทาง

ใช้ [IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/) เพื่อดึงช่วงชื่อ แล้วส่งคอลเลกชันนั้นให้กับ [IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/) พารามิเตอร์ `skipHiddenCells` ควบคุมว่าจะรวมเซลล์ที่ซ่อนหรือไม่: `true` จะยกเว้น, `false` จะรวม ตัวอย่างนี้ใช้ `false` เพื่อรวมทุกเซลล์ในช่วงชื่อ

ตัวอย่างต่อไปนี้สร้างการนำเสนอที่มีหนึ่งชุดและสองจุดข้อมูล เซลล์ B1:C1 มีชื่อชุดเท่านั้น; A2:A3 มีฉลากหมวดหมู่; B2:B3 มีค่าตัวเลข

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

// เซลล์สองเซลล์นี้จัดหาให้ชื่อชุดข้อมูล.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// เซลล์แยกต่างหากจัดหาให้หมวดหมู่และจุดข้อมูลเชิงตัวเลข.
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

ชื่อชุดที่ได้คือ `Product A 2026` (มีช่องว่างระหว่างค่าจากสองเซลล์) legend แสดงผลเป็นรายการเดียวสำหรับทั้งสองคอลัมน์ ภาพด้านล่างได้เรนเดอร์จากการบันทึกการนำเสนอแล้ว

![แผนภูมิคอลัมน์พร้อมค่าทิศเหนือและทิศใต้และชื่อชุดคอมโพสท์ Product A 2026 ใน legend](composite_series_name.png)

## **รับสีเติมอัตโนมัติของชุดข้อมูล**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) คืนค่าสีที่คำนวนจากดัชนีชุดข้อมูลและสไตล์ของแผนภูมิ นี่คือสีที่ใช้เมื่อไม่มีการกำหนดสีเติมของชุดข้อมูลอย่างชัดเจน การเรียกเมธอดนี้เพียงอ่านสีที่คำนวน ไม่ได้กำหนดสีเติมใหม่

ตัวอย่างต่อไปนี้พิมพ์สีอัตโนมัติของแต่ละชุดข้อมูลเริ่มต้น

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

ผลลัพธ์ตัวอย่างสำหรับสไตล์แผนภูมิเบื้องต้น

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

สีที่ได้ขึ้นกับสไตล์และธีมของแผนภูมิ

## **ตั้งค่าสีเติมกลับด้านสำหรับชุดข้อมูลในแผนภูมิ**

สำหรับชุดข้อมูลแบบบาร์, คอลลัมน์และบับเบิล [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) สามารถแสดงค่าลบด้วยสีเติมที่ต่างออกไป ตั้งค่าสีเติมปกติให้เป็นโซลิด เปิดใช้งานการกลับด้าน และกำหนดสีค่าลบผ่าน [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) ค่าตัวเลขลบใน workbook จะไม่เปลี่ยนแปลง เพียงสีที่แสดงเท่านั้นที่เปลี่ยน

ตัวอย่างต่อไปนี้แทนข้อมูลแผนภูมิเริ่มต้นด้วยชุดข้อมูลหนึ่ง Worksheet แถว 0 มีชื่อชุด, คอลัมน์ 0 มีชื่อหมวดหมู่, คอลัมน์ 1 มีค่าต่าง ๆ

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

![สีเติมโซลิดกลับด้าน](inverted_solid_fill_color.png)

คุณสามารถเปิดใช้งานการกลับด้านสำหรับจุดเดียวได้ผ่าน [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) ตัวอย่างต่อไปนี้ปิดการกลับด้านสำหรับชุดข้อมูลและเปิดเฉพาะสำหรับจุดที่เลือก พร้อมกำหนดค่าติดลบเพื่อให้เห็นผล

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

หากต้องการทำให้จุดหนึ่งเป็นค่าว่างโดยไม่ลบจุดอื่น ให้ตั้งค่าเซลล์ workbook ที่เป็นพื้นหลังของจุดนั้นเป็น `null` สำหรับแผนภูมิคอลัมน์ ค่าที่พล็อตได้อยู่ใน [IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/) จุดข้อมูลยังคงอยู่ในตำแหน่งหมวดหมู่เดิม แต่แผนภูมิจะถือค่าดังกล่าวว่าเป็นค่าว่างตามการตั้งค่าการแสดงค่าว่างของแผนภูมิ

ตัวอย่างต่อไปนี้ลบค่าเฉพาะจุดที่สองของชุดแรก

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

แผนภูมิสเก็ตเตอร์ใช้เซลล์ X และ Y แยกกัน และแผนภูมิบับเบิลยังใช้เซลล์ขนาดด้วย ให้ลบเฉพาะเซลล์ที่แทนค่าที่ต้องการลบ อย่าดำเนินการเรียก [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) หากต้องการคงจุดอื่นไว้ เพราะเมธอดนี้จะลบจุดข้อมูลทั้งหมดในคอลเลกชัน

## **ควบคุมการแสดงผลของเซลล์ที่ว่าง**

เซลล์ที่ซ่อนอยู่แต่มีค่าเป็นกรณีที่แยกจากเซลล์ที่ว่างเปล่า หากต้องการรวมหรือยกเว้นข้อมูลจากแถวและคอลัมน์ที่ซ่อนอยู่ ให้ดูที่ [Include Data from Hidden Rows and Columns](/slides/th/net/chart-workbook/#include-data-from-hidden-rows-and-columns)

เซลล์ workbook ที่ว่างเปล่าจะแสดงว่าขาดข้อมูล; เซลล์ที่มีค่า `0` แสดงว่ามีค่าตัวเลขที่ทราบ ตั้งค่า [IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/) เป็น `null` เพื่อทำให้เซลล์เป็นค่าว่าง ศูนย์ตัวเลขจะคงเป็นศูนย์ไม่ว่าเซลล์ว่างจะถูกตั้งค่าอย่างไร

ใช้ [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) เพื่อเลือกวิธีที่แผนภูมิจะแสดงเซลล์ที่ว่าง การตั้งค่านี้ใช้กับแผนภูมิทั้งหมดและจะเปลี่ยนวิธีการพล็อตค่าว่างโดยไม่ต้องเติมค่า `0` หรือค่าเฉลี่ยลงในเซลล์

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นที่มีชุดข้อมูลหนึ่ง ลบค่าใน Day 3 และบันทึกแผนภูมิเดียวกันด้วยโหมดแต่ละแบบ ไม่ต้องใช้ไฟล์อินพุต [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) ใช้ worksheet 0, คอลัมน์ 0 สำหรับฉลากหมวดหมู่, คอลัมน์ 1 สำหรับค่า; แถว 0 เก็บชื่อชุด ค่าข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`

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

// ทำให้ Day 3 เป็นค่าว่างจริง ๆ ขณะยังคงหมวดหมู่และจุดข้อมูล
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

แต่ละไฟล์ผลลัพธ์จะบันทึกโหมดที่ตั้งไว้ก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` และ `empty_cells_Span.pptx` หากต้องการบันทึกเฉพาะหนึ่งเวอร์ชัน ให้กำหนดโหมดที่ต้องการแล้วบันทึกการนำเสนอเพียงครั้งเดียวแทนการวนลูปหลายโหมด

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในไฟล์ทั้งสาม Day 3 เป็นค่าว่างใน workbook ทุกกรณี

![แผนภูมิเส้นที่มีข้อมูลเดียวกัน: Gap ทำให้เส้นขาดที่ Day 3, Zero ทำให้เส้นลงถึงศูนย์, Span เชื่อม Day 2 ไปยัง Day 4](display_blanks_as.png)

ผลลัพธ์ที่มองเห็นขึ้นอยู่กับประเภทของแผนภูมิ แผนภูมิเส้นทำให้สามโหมดดูง่าย บาร์และคอลลัมน์ไม่มีเส้นเชื่อมระหว่างคอลัมน์ที่หายไป ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมได้; คอลัมน์ที่หายไปและคอลัมน์ศูนย์อาจดูคล้ายกันเช่นกัน แผนภูมิ scatter ที่มีเพียงมาร์คเกอร์ก็ไม่มีเส้นเชื่อม อย่าคาดหวังผลลัพธ์ที่แตกต่างสามแบบสำหรับทุกประเภทแผนภูมิ; ให้ตรวจสอบผลลัพธ์สำหรับประเภทที่ใช้

## **ตั้งค่าความกว้าง Gap ของชุดข้อมูล**

Gap width คือระยะห่างระหว่างกลุ่มบาร์หรือคอลลัมน์ที่อยู่ติดกัน ซึ่งแสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลลัมน์ เช่นเดียวกับ overlap มันเป็นของกลุ่มชุดข้อมูลแม่ ไม่ได้เป็นของชุดข้อมูลเดียว ตั้งค่า [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) หนึ่งครั้งสำหรับกลุ่ม ค่าใหญ่จะทำให้ช่องว่างระหว่างกลุ่มเพิ่มขึ้น ค่าเล็กจะทำให้กลุ่มแน่นขึ้น

ตัวอย่างต่อไปนี้ปรับเปลี่ยนความกว้าง Gap และบันทึกการนำเสนอสุดท้ายเท่านั้น

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

![ความกว้าง Gap](gap_width.png)

## **FAQ**

**แผนภูมิประเภทใดบ้างที่รองรับชุดข้อมูล?**

ทุกประเภทแผนภูมิที่แสดงโดยการนับเป็น [ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) จะใช้ข้อมูลแผนภูมิ แต่ชุดข้อมูลของแต่ละประเภทไม่จำเป็นต้องมีโครงสร้างค่าและการตั้งค่าเดียวกัน ตัวอย่างเช่น แผนภูมิกลุ่มประเภทใช้หมวดหมู่และค่า, แผนภูมิ scatter ใช้ค่า X และ Y, แผนภูมิ bubble เพิ่มขนาดบับเบิล ใช้วิธีการสร้างจุดข้อมูลที่สอดคล้องกับประเภทชุดข้อมูล ตัวเลือกเช่น overlap และ gap width จะใช้เฉพาะกลุ่มบาร์หรือคอลลัมน์ที่เข้ากันได้

**ชุดข้อมูลของแผนภูมิคืออะไร?**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) ประกอบด้วยชุดข้อมูลที่เข้ากันและใช้การตั้งค่าการพล็อตระดับกลุ่ม แผนภูมิแบบผสมอาจมีหลายกลุ่ม ดังนั้นการเปลี่ยนแปลงที่ทำผ่านชุดข้อมูลหนึ่งอาจไม่กระทบต่อทุกชุดในแผนภูมิ

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

มีโดยค่าเริ่มต้น [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) จะสร้างตัวอย่างชุดข้อมูล, หมวดหมู่และค่า คุณสามารถแก้ไขเซลล์เหล่านั้นหรือทำความสะอาดคอลเลกชันชุดข้อมูลและหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองได้ อีกทางเลือกหนึ่งคือใช้ overload ที่สร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้น

**วัตถุแผนภูมิเชื่อมโยงกับเซลล์ workbook อย่างไร?**

ชื่อชุดข้อมูล, ฉลากหมวดหมู่และค่าจุดข้อมูลอ้างอิงเซลล์ใน [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) การเปลี่ยนแปลงเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิที่สอดคล้องกัน เมื่อสร้างข้อมูลกำหนดเองให้รักษาแถวหมวดหมู่และแถวค่าชุดข้อมูลให้สอดคล้องกันเพื่อให้แต่ละจุดพล็อตอยู่ภายใต้หมวดหมู่ที่ตั้งใจ

**จะลบจุดเดียวอย่างไรโดยไม่ลบชุดทั้งหมด?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อให้จุดยังคงตำแหน่งหมวดหมู่เป็นจุดว่าง ใช้ [IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/) เฉพาะเมื่อต้องการลบจุดทั้งหมดในชุดนั้น หากลบหมวดหมู่ด้วย ต้องอัปเดตทุกชุดเพื่อให้ค่าตรงกับคอลเลกชันหมวดหมู่

**จุดที่ว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นกับประเภทแผนภูมิและ [IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/) แผนภูมิที่รองรับสามารถแสดงค่าว่างเป็นช่องว่าง, ค่าศูนย์ หรือเชื่อมจุดใกล้เคียงกัน ให้เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่ขาดหาย ดูที่ [Control the Display of Empty Cells](#control-the-display-of-empty-cells) สำหรับตัวอย่างเต็มและการเปรียบเทียบภาพ

**ค่าติดลบถูกจัดรูปแบบอย่างไร?**

สำหรับชุดข้อมูลบาร์, คอลลัมน์ และบับเบิลที่รองรับ ให้เปิดใช้งาน [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) แล้วตั้งค่า [IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/) คุณสามารถกำหนดพฤติกรรมให้กับจุดเดียวผ่าน [IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/) คุณสมบัติเหล่านี้มีผลต่อการจัดรูปแบบ ไม่ใช่ค่าตัวเลขที่ถูกเก็บ

**เมื่อตั้งค่าทั้งระดับชุดและระดับจุด แกะเอาใครชนะ?**

การจัดรูปแบบจุดข้อมูลโดยชัดเจนจะมีลำดับความสำคัญสูงกว่าสำหรับจุดนั้น จุดอื่น ๆ จะใช้การจัดรูปแบบระดับชุดที่กำหนดไว้ หรือหากระดับชุดไม่ได้กำหนด จะใช้สไตล์และธีมของแผนภูมิอัตโนมัติ คุณสมบัติกลุ่มเช่น overlap และ gap width ควบคุมการวางเลย์เอาต์และไม่ใช่การจัดรูปแบบระดับจุด

**แผนภูมิสามารถมีชุดข้อมูลได้สูงสุดกี่ชุด?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดข้อมูลแบบคงที่ อย่างไรก็ตาม ข้อจำกัดของไฟล์นำเสนอ, หน่วยความจำที่ใช้, เวลาเรนเดอร์และความอ่านง่ายของแผนภูมิจะเป็นปัจจัยที่กำหนดขีดจำกัดที่ใช้งานได้จริง

**ควรทำอย่างไรเมื่อคอลลัมน์หรือบาร์อยู่ใกล้กันเกินไปหรือห่างกันมากเกินไป?**

ตั้งค่า [IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/) บนกลุ่มชุดข้อมูลแม่ที่เกี่ยวข้อง เพิ่มค่าจะทำให้ช่องว่างระหว่างกลุ่มกว้างขึ้น ลดค่าจะทำให้กลุ่มเข้าหากันมากขึ้น