---
title: จัดการชุดข้อมูลแผนภูมิในพรีเซนเทชันด้วย .NET
linktitle: ชุดข้อมูล
type: docs
url: /th/net/chart-series/
keywords:
- ชุดข้อมูลแผนภูมิ
- การซ้อนกันของชุด
- สีชุด
- สีหมวดหมู่
- ชื่อชุด
- จุดข้อมูล
- ช่องว่างของชุด
- PowerPoint
- พรีเซนเทชัน
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีจัดการชุดข้อมูลแผนภูมิ, จุดข้อมูล, เซลล์เวิร์กบุ๊ก, การกำหนดรูปแบบ, การซ้อน, ความกว้างของช่องว่าง, และค่าติดลบในพรีเซนเทชันด้วย C#."
---
## **ภาพรวม**

แผนภูมิสามารถจัดเก็บค่าที่พลอตไว้ในเซลล์ของเวิร์กบุ๊กหรือโดยตรงเป็นค่าตัวเลขลิตเทอรัล. [IChartSeries](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/) แทนชุดค่าที่เกี่ยวข้องหนึ่งชุด, และแต่ละ[IChartDataPoint](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/) แทนจุดในชุดนั้น. วัตถุ[IChartCategory](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartcategory/) ให้ป้ายหรือค่ากลุ่มที่ใช้ร่วมกันโดยชุดข้อมูล. ในแผนภูมิที่สร้างด้วยข้อมูลเริ่มต้น, ชื่อชุด, หมวดหมู่, และค่าจุดจะใช้วัตถุ[IChartDataCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/) จากเวิร์กบุ๊กของแผนภูมิ.

สำหรับแผนภูมิประเภทหมวดหมู่อันดับต้น, เวิร์กบุ๊กเริ่มต้นใช้แถว 0 สำหรับชื่อชุด, คอลัมน์ 0 สำหรับชื่อหมวดหมู่, และเซลล์ที่เหลือสำหรับค่าชุด. ดัชนี Worksheet, แถว, และคอลัมน์ที่ส่งให้[IChartDataWorkbook.GetCell](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcell/) นั้นเริ่มที่ศูนย์. การจัดวางนี้เป็นประโยชน์เมื่อคุณสร้างแผนภูมิกับข้อมูลเริ่มต้น, แต่ไม่ควรสันนิษฐานว่าทุกแผนภูมิที่มีอยู่ใช้รูปแบบนี้. สำหรับพรีเซนเทชันที่โหลดแล้ว, ตรวจสอบเซลล์ที่ชุด, หมวดหมู่, และจุดข้อมูลอ้างอิงก่อนที่จะเปลี่ยนค่าในเวิร์กบุ๊ก.

Chart settings have three different scopes:

- การตั้งค่าระดับชุดข้อมูล, เช่น [IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/), ให้ลักษณะการแสดงผลเริ่มต้นสำหรับจุดทั้งหมดในชุดเดียว.
- การตั้งค่าจุดข้อมูล, เช่น [IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/), จะทับลักษณะการแสดงผลของชุดข้อมูลสำหรับจุดเดียว.
- การตั้งค่ากลุ่มใช้กับชุดข้อมูลที่เข้ากันได้ซึ่งอยู่ใน[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) เดียวกัน. เข้าถึงกลุ่มผ่าน[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/) เมื่อคุณต้องการตั้งค่าตัวเลือกเช่นการซ้อนกันหรือความกว้างของช่องว่าง.

เมื่อไม่มีการกำหนดรูปแบบการเติมสีจุดหรือชุดข้อมูลอย่างชัดเจน, สไตล์และธีมของแผนภูมิจะกำหนดลักษณะอัตโนมัติ. เมื่อมีการกำหนดรูปแบบทั้งชุดและจุด, รูปแบบของจุดจะมีลำดับความสำคัญสำหรับจุดนั้น.

![แผนภูมิซีรีส์ PowerPoint](chart-series-powerpoint.png)

สำหรับแผนภูมิทรงกระบอกแบบทำกลุ่ม, ดูว่า [การเปลี่ยนประเภทชุด 3D หรือรูปแบบแท่ง](/slides/th/net/3d-chart/#change-the-3d-series-type-and-bar-shape) มีผลต่อชุดแรกอย่างไร.

## **ตั้งค่าค่าชุดข้อมูลโดยใช้ค่าตัวเลขลิตเทอรัล**

ใช้ค่าตัวเลขลิตเทอรัลเมื่อค่าชุดมาจากข้อมูลหรือการคำนวณของแอปพลิเคชันและไม่ต้องอ้างอิงเซลล์ในเวิร์กชีต. ตั้งค่า[DataSourceTypeForValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforvalues/)เป็น[DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/net/aspose.slides.charts/datasourcetype/)ก่อนกำหนด[Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/value/)ของแต่ละจุดผ่าน[AsLiteralDouble](https://reference.aspose.com/slides/net/aspose.slides.charts/idoublechartvalue/asliteraldouble/).

การตั้งค่าคอลเลกชันควบคุมประเภทแหล่งที่มาของค่าจุดทั้งหมดในชุดนั้น. แต่ละจุดมี[Value.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ibasechartvalue/datasourcetype/)ที่รายงานประเภทที่เลือก; เปลี่ยนผ่านการตั้งค่าคอลเลกชัน. เมื่อใช้`Worksheet`, ใช้[AsCell](https://reference.aspose.com/slides/net/aspose.slides.charts/isinglecellchartvalue/ascell/)เพื่อเข้าถึงเซลล์ที่อ้างอิง. เมื่อใช้`DoubleLiterals`, ใช้`AsLiteralDouble`เพื่ออ่านหรือเขียนตัวเลขโดยตรง.

ตัวอย่างต่อไปนี้สร้างแผนภูมิคอลัมน์ด้วยชุดและหมวดหมู่เริ่มต้น, แล้วกำหนดค่าที่คำนวณได้ 10, 20, เป็นต้นให้กับจุดที่มีอยู่ของชุดแรก. จากนั้นบันทึกพรีเซนเทชัน, เปิดใหม่, และพิมพ์ค่าที่จัดเก็บไว้.

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

ประเภทแหล่งที่มาของค่าจุดแยกจาก[IChartData.DataSourceType](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdata/datasourcetype/), ซึ่งระบุการกำหนดค่าเวิร์กบุ๊กภายในหรือภายนอกของแผนภูมิ. การใช้ค่าตัวเลขลิตเทอรัลไม่ได้ทำให้เวิร์กบุ๊กที่ฝังอยู่หายไปโดยอัตโนมัติ. ในตัวอย่างนี้, เวิร์กบุ๊กยังคงใช้สำหรับป้ายหมวดหมู่, ชื่อชุด, และชุดอื่น ๆ. ดู[Chart Workbook](/slides/th/net/chart-workbook/)สำหรับการจัดการเวิร์กบุ๊ก.

สำหรับแผนภูมิแบบกระจายและฟองอากาศ, ตั้งค่า[DataSourceTypeForXValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforxvalues/)และ[DataSourceTypeForYValues](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforyvalues/)เพื่อเลือกแหล่งที่มาสำหรับ[XValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/xvalue/)และ[YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). แผนภูมิบับอากาศยังใช้[DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/datasourcetypeforbubblesizes/)สำหรับ[BubbleSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/bubblesize/). ตั้งค่าแหล่งที่เกี่ยวข้องแต่ละอย่างเป็น`DoubleLiterals`ก่อนกำหนดตัวเลขผ่านคุณสมบัติ`AsLiteralDouble`ของค่าดังกล่าว.

## **ตั้งค่าการซ้อนกันของชุดแผนภูมิ**

[IChartSeries.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/overlap/) รายงานว่าบาร์หรือคอลัมน์ซ้อนทับกันเท่าไหร่ในแผนภูมิ 2D, ตั้งแต่ -100 ถึง 100 เปอร์เซ็นต์. มันเป็นการฉายภาพแบบอ่าน‑อย่างเดียวของการตั้งค่าในกลุ่มชุดพาเรนต์. ตั้งค่า[IChartSeriesGroup.Overlap](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/overlap/)เพื่ออัปเดตทุกชุดที่เข้ากันได้ในกลุ่มนั้น. ตัวเลือกนี้ใช้กับประเภทแผนภูมิที่แสดงบาร์หรือคอลัมน์เป็นกลุ่ม; ไม่ส่งผลต่อกลุ่มชุดอื่น ๆ ในแผนภูมิกำเนิด.

ตัวอย่างต่อไปนี้ตั้งค่าการซ้อนกันสำหรับกลุ่มที่มีชุดแรกอยู่:

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const sbyte overlapPercent = 30;

using var presentation = new Presentation();
var slide = presentation.Slides[firstSlideIndex];

// แผนภูมิใหม่ประกอบด้วยชุดตัวอย่าง, หมวดหมู่, และค่า.
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

var series = chart.ChartData.Series[firstSeriesIndex];
series.ParentSeriesGroup.Overlap = overlapPercent;

presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
```

ผลลัพธ์:

![การซ้อนกันของชุด](series_overlap.png)

## **เปลี่ยนสีเติมของชุดแผนภูมิ**

ใช้[IChartSeries.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/format/)เพื่อกำหนดสีเติมเริ่มต้นสำหรับชุดทั้งหมด. หากจุดใดจุดหนึ่งมีการกำหนดสีเติมอย่างชัดเจน, การตั้งค่า[IChartDataPoint.Format](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/format/)ของจุดนั้นจะทับสีเติมของชุดสำหรับจุดนั้น.

ตัวอย่างต่อไปนี้ใช้สีเติมสีฟ้าเข้มแบบทึบกับชุดแรก:

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

## **เปลี่ยนชื่อชุดข้อมูล**

ชื่อชุดถูกเก็บไว้ในเวิร์กบุ๊กของแผนภูมิและโดยปกติจะแสดงในคำอธิบาย. ในเวิร์กบุ๊กเริ่มต้นที่สร้างสำหรับแผนภูมิคอลัมน์แบบทำกลุ่ม, เซลล์ B1 อยู่ที่แถว 0, คอลัมน์ 1 และมีชื่อของชุดแรก. ค่าคงที่ที่ตั้งชื่อไว้ในตัวอย่างต่อไปทำให้โครงสร้างนี้ชัดเจน:

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

คุณสามารถอัปเดตเซลล์ที่[IChartSeries.Name](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/name/)อ้างอิงอยู่ได้เช่นกัน. วิธีนี้หลีกเลี่ยงการสันนิษฐานแถวและคอลัมน์เฉพาะในแผนภูมิที่มีอยู่:

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

### **สร้างชุดข้อมูลจากหลายเซลล์**

ชื่อชุดผสมเป็นประโยชน์เมื่อชื่อผลิตภัณฑ์และช่วงเวลารายงานถูกเก็บในเซลล์เวิร์กบุ๊กแยกกัน. ตัวอย่างเช่น, คุณสามารถรวม `Product A` ใน B1 และ `2026` ใน C1 ให้เป็นชื่อชุดเดียวในขณะที่ยังคงเชื่อมโยงทั้งสองส่วนกับเซลล์ต้นทางของมันได้.

ใช้[IChartDataWorkbook.GetCellCollection](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/getcellcollection/)เพื่อดึงช่วงชื่อ, จากนั้นส่งคอลเลกชันนั้นไปยัง[IChartSeriesCollection.Add](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriescollection/add/). พารามิเตอร์`skipHiddenCells`ควบคุมว่าควรรวมเซลล์ที่ซ่อนไว้หรือไม่: `true` จะไม่รวม, `false` จะรวม. ตัวอย่างนี้ใช้ `false` เพื่อรวมทุกเซลล์ในช่วงชื่อ.

ตัวอย่างต่อไปนี้สร้างพรีเซนเทชันที่มีหนึ่งชุดและสองจุดข้อมูล. เซลล์ B1:C1 มีเพียงชื่อชุด; A2:A3 มีป้ายหมวดหมู่, และ B2:B3 มีค่าตัวเลข.

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

// เซลล์สองเซลล์นี้ใช้เป็นชื่อชุดข้อมูล.
workbook.GetCell(0, 0, 1, "Product A");
workbook.GetCell(0, 0, 2, "2026");
var nameCells = workbook.GetCellCollection("Sheet1!$B$1:$C$1", skipHiddenCells: false);
var series = chart.ChartData.Series.Add(nameCells, ChartType.ClusteredColumn);

// เซลล์แยกต่างหากใช้เป็นหมวดหมู่และจุดข้อมูลเชิงตัวเลข.
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

ชื่อชุดที่ได้คือ `Product A 2026`, มีช่องว่างระหว่างค่าจากสองเซลล์. คำอธิบายจะแสดงเป็นรายการเดียวสำหรับทั้งสองคอลัมน์. ภาพด้านล่างแสดงจากพรีเซนเทชันที่บันทึกแล้ว:

![แผนภูมิคอลัมน์ที่มีค่าเหนือและใต้และชื่อชุดผสม Product A 2026 ในคำอธิบาย](composite_series_name.png)

## **รับสีเติมอัตโนมัติของชุดแผนภูมิ**

[IChartSeries.GetAutomaticSeriesColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/getautomaticseriescolor/) คืนค่าสีที่คำนวณจากดัชนีชุดและสไตล์ของแผนภูมิ. นี่คือลักษณะที่ใช้เมื่อสีเติมชุดไม่ได้กำหนดอย่างชัดเจน. การเรียกเมธอดนี้อ่านสีที่คำนวณแล้ว; ไม่ได้กำหนดสีเติมใหม่.

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

สีที่ได้จะขึ้นกับสไตล์และธีมของแผนภูมิ.

## **ตั้งค่าสีเติมกลับกลับสำหรับชุดแผนภูมิ**

สำหรับชุดบาร์, คอลัมน์, และฟองอากาศ, [IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/) สามารถแสดงค่าติดลบด้วยสีเติมที่ต่างออกไป. ตั้งค่าสีเติมปกติเป็นสีทึบ, เปิดการกลับสี, แล้วกำหนดสีค่าติดลบผ่าน[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). ตัวเลขติดลบจะไม่เปลี่ยนแปลงในเวิร์กบุ๊ก; มีเพียงสีแสดงที่เปลี่ยน.

ตัวอย่างต่อไปนี้แทนที่ข้อมูลแผนภูมิจำนวนเริ่มต้นด้วยชุดเดียว. แถว 0 ของเวิร์กชีตมีชื่อชุด, คอลัมน์ 0 มีชื่อหมวดหมู่, และคอลัมน์ 1 มีค่าตัวเลข:

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

![สีเติมทึบที่กลับสี](inverted_solid_fill_color.png)

คุณสามารถเปิดการกลับสีสำหรับจุดเดียวผ่าน[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). ในตัวอย่างต่อไปนี้ การกลับสีถูกปิดสำหรับชุดและเปิดสำหรับจุดที่เลือกเท่านั้น. จุดนั้นยังถูกกำหนดค่าเป็นค่าติดลบเพื่อให้เห็นผล:

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

เพื่อทำให้จุดหนึ่งเป็นค่าว่างโดยไม่ลบจุดอื่น, ตั้งค่าเซลล์เวิร์กบุ๊กที่สนับสนุนเป็น `null`. สำหรับแผนภูมิคอลัมน์, ค่าที่พลอตได้สามารถเข้าถึงได้ผ่าน[IChartDataPoint.YValue](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/yvalue/). จุดข้อมูลจะยังคงอยู่ในตำแหน่งหมวดหมู่เดิม, แต่แผนภูมิจะถือค่าของมันว่าเป็นค่าว่างตามการตั้งค่าแสดงค่าว่างของแผนภูมิ.

ตัวอย่างต่อไปนี้ล้างเฉพาะจุดที่ 2 ของชุดแรก:

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

แผนภูมิกระจายใช้เซลล์ X และ Y แยกกัน, ส่วนแผนภูมิฟองอากาศยังใช้เซลล์ขนาด. ให้ล้างเฉพาะเซลล์ที่แทนค่าที่คุณต้องการลบ. อย่าเรียก[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/)เมื่อคุณต้องการเก็บจุดอื่น ๆ ไว้, เนื่องจากเมธอดนี้จะลบทุกจุดจากคอลเลกชัน.

## **ควบคุมการแสดงผลของเซลล์ว่าง**

เซลล์ที่ซ่อนแต่มีค่าเป็นกรณีที่แตกต่างจากเซลล์ว่าง. เพื่อรวมหรือยกเว้นข้อมูลจากแถวและคอลัมน์ที่ซ่อน, ดู[Include Data from Hidden Rows and Columns](/slides/th/net/chart-workbook/#include-data-from-hidden-rows-and-columns).

เซลล์เวิร์กบุ๊กที่ว่างเปล่าจะแสดงว่าขาดข้อมูล; เซลล์ที่มีค่า `0` แสดงค่าตัวเลขที่ทราบ. ตั้งค่า[IChartDataCell.Value](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/value/)เป็น `null` เพื่อทำให้เซลล์เป็นค่าว่าง. ศูนย์ตัวเลขยังคงเป็นศูนย์ไม่ว่าการตั้งค่าเซลล์ว่างจะเป็นอย่างไร.

ใช้[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/)เพื่อเลือกว่าจะแสดงค่าว่างอย่างไร. การตั้งค่านี้ใช้กับแผนภูมิทั้งหมด. มันเปลี่ยนวิธีที่ค่าว่างถูกพลอต, โดยไม่เติมเซลล์ว่างด้วยศูนย์หรือค่าที่ประมาณ.

ตัวอย่างต่อไปนี้สร้างแผนภูมิเส้นหนึ่งชุด, ล้างค่าของวัน 3, แล้วบันทึกแผนภูมิเดียวกันด้วยแต่ละโหมด. ไม่ต้องใช้ไฟล์อินพุต. [IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/) ใช้ Worksheet 0, คอลัมน์ 0 สำหรับป้ายหมวดหมู่, และคอลัมน์ 1 สำหรับค่าตัวเลข; แถว 0 มีชื่อชุด. ข้อมูลสุดท้ายคือ `10, 20, empty, 30, 40`.

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

// ปล่อยให้วัน 3 ว่างจริงๆ ขณะที่ยังคงหมวดหมู่และจุดข้อมูลของมันไว้.
workbook.GetCell(0, 3, 1).Value = null;

var modes = new[] { DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span };
foreach (var mode in modes)
{
    chart.DisplayBlanksAs = mode;
    presentation.Save($"empty_cells_{mode}.pptx", SaveFormat.Pptx);
}
```

แต่ละไฟล์ผลลัพธ์บันทึกโหมดที่ตั้งค่าก่อนบันทึก: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, และ `empty_cells_Span.pptx`. หากต้องการบันทึกเพียงเวอร์ชันเดียว, ตั้งค่าโหมดที่ต้องการแล้วบันทึกพรีเซนเทชันหนึ่งครั้งแทนที่จะวนลูปหลายโหมด.

การเปรียบเทียบด้านล่างแสดงข้อมูลเดียวกันในทั้งสามไฟล์. วัน 3 เป็นค่าว่างในเวิร์กบุ๊กในทุกกรณี:

![แผนภูมิเส้นที่มีข้อมูลเดียวกัน: Gap ทำให้เส้นขาดที่วัน 3, Zero ทำให้เส้นลดลงเป็นศูนย์, และ Span เชื่อมต่อวัน 2 ไปยังวัน 4.](display_blanks_as.png)

ผลที่มองเห็นขึ้นกับประเภทแผนภูมิ. แผนภูมิเส้นทำให้เปรียบเทียบสามโหมดได้ง่าย. แผนภูมิแท่งและคอลัมน์ไม่มีเส้นเชื่อมต่อระหว่างคอลัมน์ที่ขาดหาย, ดังนั้น `Span` ไม่สามารถสร้างส่วนเชื่อมต่อที่แสดงในภาพได้; คอลัมน์ที่หายและคอลัมน์ศูนย์อาจดูคล้ายกัน. เช่นเดียวกับแผนภูมิกระจายที่มีเพียงมาร์คเกอร์ไม่มีเส้นเชื่อมต่อ. อย่าคาดหวังผลลัพธ์ที่แตกต่างกันสามแบบสำหรับทุกประเภทแผนภูมิ; ตรวจสอบผลลัพธ์สำหรับประเภทที่คุณใช้.

## **ตั้งค่าความกว้างช่องว่างของชุด**

ความกว้างช่องว่างคือช่องว่างระหว่างกลุ่มบาร์หรือคอลัมน์ที่อยู่ติดกัน, แสดงเป็นเปอร์เซ็นต์ของความกว้างบาร์หรือคอลัมน์. เช่นเดียวกับการซ้อน, มันเป็นคุณสมบัติของกลุ่มชุดพาเรนต์ ไม่ได้เป็นของชุดเดียว. ตั้งค่า[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)หนึ่งครั้งสำหรับกลุ่ม. ค่าใหญ่กว่าจะสร้างช่องว่างมากขึ้นระหว่างกลุ่ม; ค่าเล็กกว่าจะทำให้กลุ่มหนาแน่นขึ้น.

ตัวอย่างต่อไปนี้เปลี่ยนความกว้างช่องว่างและบันทึกพรีเซนเทชันสุดท้ายเท่านั้น:

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

## **แสดงหรือซ่อนเส้นเชื่อมชุด**

เส้นเชื่อมชุดเชื่อมต่อส่วนที่เกี่ยวข้องของแผนภูมิแบบเชิงภาพ. ใช้[IChartSeriesGroup.HasSeriesLines](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/hasserieslines/)เพื่อแสดงหรือซ่อนเส้นเหล่านี้ในแผนภูมิแบบ stacked bar และ OfPie ที่รองรับ. ในแผนภูมิ stacked bar และ column สองมิติ, เส้นเหล่านี้เชื่อมขอบสแตกที่สอดคล้องกันข้ามหมวดหมู่. ในแผนภูมิ Pie of Pie และ Bar of Pie, เส้นเชื่อมแผนภูมิหลักกับแผนภูมิรอง. การตั้งค่านี้ไม่ใช่การเชื่อมต่อทั่วไปสำหรับประเภทแผนภูมิอื่น ๆ.

เข้าถึงกลุ่มผ่าน[IChartSeries.ParentSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/parentseriesgroup/). การตั้งค้านี้ใช้กับทุกชุดในกลุ่มนั้น. [IChartSeries.HasSeriesLines](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/hasserieslines/)เป็นแบบอ่าน‑อย่างเดียวและสะท้อนการตั้งค่ากลุ่มพาเรนต์; เปลี่ยนคุณสมบัติกลุ่มเพื่ออัปเดต.

ตัวอย่างต่อไปนี้สร้างแผนภูมิ[PieOfPie](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)หนึ่งชุดด้วยข้อมูลเริ่มต้น. จากนั้นบันทึกแผนภูมิเดียวกันโดยเปิดใช้งานเส้นเชื่อมชุดและปิดใช้งาน, ผลลัพธ์เป็นพรีเซนเทชันสองไฟล์เพื่อนำไปเปรียบเทียบ.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 400);
var series = chart.ChartData.Series[0];
var seriesGroup = series.ParentSeriesGroup;

seriesGroup.HasSeriesLines = true;
presentation.Save("series_lines_enabled.pptx", SaveFormat.Pptx);

seriesGroup.HasSeriesLines = false;
presentation.Save("series_lines_disabled.pptx", SaveFormat.Pptx);
```

| เปิดใช้งานเส้นเชื่อมชุด | ปิดใช้งานเส้นเชื่อมชุด |
| --- | --- |
| ![แผนภูมิ Pie of Pie ที่เปิดใช้งานเส้นเชื่อมชุด](series_lines_enabled.png) | ![แผนภูมิ Pie of Pie ที่ปิดการใช้งานเส้นเชื่อมชุด](series_lines_disabled.png) |
| สองเส้นนี้เชื่อมพายหลักกับพายรอง. | พายทั้งสองยังคงมองเห็นได้, แต่เส้นเชื่อมจะถูกซ่อน. |

เส้นเชื่อมชุดต่างจากเส้นนำของป้ายข้อมูลที่เชื่อมป้ายกับจุดข้อมูล; เส้นกริดที่ระบุช่วงบนแกนแผนภูมิ; และเส้นในแผนภูมิเส้นที่แสดงค่าข้อมูล. การตั้งค่านี้ไม่ควบคุมองค์ประกอบเหล่านั้น.

## **FAQ**

**ประเภทแผนภูมิใดบ้างที่รองรับชุดข้อมูล?**

ทุกประเภทแผนภูมิที่ระบุโดย[ChartType](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/)ใช้ข้อมูลแผนภูมิ, แต่ชุดข้อมูลของแต่ละประเภทอาจมีโครงสร้างค่าหรือการตั้งค่าที่ต่างกัน. ตัวอย่างเช่น, แผนภูมิเกรดใช้หมวดหมู่และค่า, แผนภูมิกระจายใช้ค่า X และ Y, แผนภูมิบับอากาศเพิ่มขนาดฟอง. ใช้วิธีสร้างจุดข้อมูลที่สอดคล้องกับประเภทชุด. ตัวเลือกเช่นการซ้อนและความกว้างช่องว่างใช้ได้เฉพาะกับกลุ่มบาร์หรือคอลัมน์ที่เข้ากันได้.

**ชุดข้อมูลกลุ่มคืออะไร?**

[IChartSeriesGroup](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/) ประกอบด้วยชุดข้อมูลที่เข้ากันได้และแชร์การตั้งค่าการพลอตระดับกลุ่ม. แผนภูมิกำเนิดอาจมีหลายกลุ่ม, ดังนั้นการเปลี่ยนกลุ่มผ่านชุดหนึ่งไม่จำเป็นต้องเปลี่ยนทุกชุดในแผนภูมิ.

**แผนภูมิที่สร้างใหม่มีข้อมูลเริ่มต้นหรือไม่?**

ใช่. ตามค่าเริ่มต้น, [IShapeCollection.AddChart](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addchart/) จะสร้างชุดตัวอย่าง, หมวดหมู่, และค่า. คุณสามารถแก้ไขเซลล์เหล่านั้นหรือเคลียร์ทั้งชุดและคอลเลกชันหมวดหมู่ก่อนเพิ่มชุดข้อมูลที่กำหนดเองอย่างเต็มที่. การโอเวอร์โหลดบางตัวยังสามารถสร้างแผนภูมิโดยไม่มีข้อมูลเริ่มต้นได้.

**วัตถุแผนภูมิเชื่อมต่อกับเซลล์เวิร์กบุ๊กอย่างไร?**

ชื่อชุด, ป้ายหมวดหมู่, และค่าจุดข้อมูลอ้างอิงเซลล์ใน[IChartDataWorkbook](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdataworkbook/). การเปลี่ยนเซลล์ที่อ้างอิงจะอัปเดตองค์ประกอบแผนภูมิเกี่ยวข้อง. เมื่อคุณสร้างข้อมูลแบบกำหนดเอง, ใหรักษาแถวหมวดหมู่และแถวค่าชุดให้สอดคล้องกันเพื่อให้แต่ละจุดพลอตอยู่ภายใต้หมวดหมู่ที่ต้องการ.

**ฉันจะลบจุดเดียวแทนการลบทั้งชุดอย่างไร?**

ตั้งค่าเซลล์ค่าที่เกี่ยวข้องเป็น `null` เพื่อรักษาตำแหน่งหมวดหมู่ของจุดเป็นจุดว่าง. ใช้[IChartDataPointCollection.Clear](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapointcollection/clear/)เฉพาะเมื่อคุณต้องการลบทุกจุดจากชุดนั้น. หากคุณลบหมวดหมู่ด้วย, ให้อัปเดตทุกชุดเพื่อให้ค่าของพวกเขายังคงสอดคล้องกับคอลเลกชันหมวดหมู่.

**จุดว่างจะแสดงอย่างไร?**

ผลลัพธ์ขึ้นกับประเภทแผนภูมิและ[IChart.DisplayBlanksAs](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/displayblanksas/). แผนภูมิที่รองรับสามารถแสดงค่าว่างเป็นช่องว่าง, เป็นค่าศูนย์, หรือโดยการเชื่อมจุดใกล้เคียง. เลือกการตั้งค่าที่สอดคล้องกับความหมายของข้อมูลที่หายไปในพรีเซนเทชันของคุณ. ดู[Control the Display of Empty Cells](#control-the-display-of-empty-cells)สำหรับตัวอย่างครบถ้วนและการเปรียบเทียบภาพ.

**ค่าติดลบจะถูกจัดรูปแบบอย่างไร?**

สำหรับชุดบาร์, คอลัมน์, และฟองอากาศที่รองรับ, เปิด[IChartSeries.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertifnegative/)และตั้ง[IChartSeries.InvertedSolidFillColor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/invertedsolidfillcolor/). คุณสามารถทำให้พฤติกรรมนี้แยกสำหรับจุดเดียวด้วย[IChartDataPoint.InvertIfNegative](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/invertifnegative/). คุณสมบัติเหล่านี้ส่งผลต่อการจัดรูปแบบ, ไม่ใช่ค่าตัวเลขที่จัดเก็บ.

**การจัดรูปแบบใดชนะเมื่อทั้งชุดและจุดถูกจัดรูปแบบ?**

การจัดรูปแบบจุดข้อมูลโดยชัดเจนจะมีลำดับความสำคัญสำหรับจุดนั้น. จุดอื่น ๆ จะใช้การจัดรูปแบบชุดที่กำหนดหรือ, เมื่อไม่มีการกำหนดชุด, สไตล์และธีมของแผนภูมิอัตโนมัติ. คุณสมบัติกลุ่มเช่นการซ้อนและความกว้างช่องว่างควบคุมการจัดวางและไม่ใช่การทับซ้อนระดับจุด.

**มีขีดจำกัดจำนวนชุดที่แผนภูมิกี่ชุดหรือไม่?**

Aspose.Slides ไม่ได้กำหนดขีดจำกัดจำนวนชุดแยกจากกัน. อย่างไรก็ตาม ข้อจำกัดของไฟล์พรีเซนเทชัน, หน่วยความจำที่มี, เวลาเรนเดอร์, และการอ่านค่าแผนภูมิจะกำหนดขีดจำกัดที่ใช้ได้จริง.

**ควรเปลี่ยนอะไรเมื่อคอลัมน์ใกล้กันเกินไปหรือห่างกันมากเกินไป?**

ตั้งค่า[IChartSeriesGroup.GapWidth](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/gapwidth/)บนกลุ่มพาเรนต์ที่เหมาะสม. เพิ่มค่าจะทำให้ช่องว่างระหว่างคลัสเตอร์กว้างขึ้น, ลดค่าจะทำให้คลัสเตอร์เข้ากลุ่มกันมากขึ้น.