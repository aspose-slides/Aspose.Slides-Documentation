---
title: ปรับแต่งคำอธิบายภาพแผนภูมิในงานนำเสนอด้วย .NET
linktitle: คำอธิบายภาพแผนภูมิ
type: docs
url: /th/net/chart-legend/
keywords:
- คำอธิบายภาพแผนภูมิ
- ตำแหน่งคำอธิบายภาพ
- ขนาดฟอนต์
- PowerPoint
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ปรับแต่งคำอธิบายภาพแผนภูมิด้วย Aspose.Slides สำหรับ .NET เพื่อเพิ่มประสิทธิภาพงานนำเสนอ PowerPoint ด้วยการจัดรูปแบบคำอธิบายภาพที่กำหนดเอง."
---
## **ภาพรวม**

Aspose.Slides สำหรับ .NET มีตัวเลือกสำหรับการปรับแต่งคำอธิบายภาพแผนภูมิในงานนำเสนอ PowerPoint บทความนี้จะแสดงวิธีการกำหนดตำแหน่งและขนาดของคำอธิบายภาพ, ตั้งค่าขนาดฟอนต์สำหรับคำอธิบายภาพทั้งหมด, จัดรูปแบบรายการคำอธิบายภาพรายบุคคล, และซ่อนหรือกู้คืนรายการที่เลือก

FAQ ครอบคลุมพฤติกรรมที่เกี่ยวข้อง รวมถึงการสำรองพื้นที่สำหรับคำอธิบายภาพ, การแสดงป้ายหลายบรรทัด, และการสืบทอดการจัดรูปแบบจากธีมของงานนำเสนอ

## **การกำหนดตำแหน่งคำอธิบายภาพ**

ใช้คุณสมบัติ [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/), และ [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) ของคำอธิบายภาพเพื่อระบุตำแหน่งและขนาดของมันเป็นส่วนสัดส่วนของมิติของแผนภูมิ

ตัวอย่างนี้สร้างงานนำเสนอและเพิ่มแผนภูมิคอลัมน์แบบกลุ่มที่มีข้อมูลเริ่มต้นลงในสไลด์แรก การหารค่าออฟเซตและขนาดของคำอธิบายภาพที่ต้องการด้วยความกว้างและความสูงของแผนภูมิจะทำให้เป็นค่าสัมพัทธ์: คำอธิบายภาพถูกย่อออฟเซต 50 จุดจากมุมบนซ้ายของแผนภูมิและมีขนาด 100 x 100 จุด

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Express the legend's position and size relative to the chart.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าขนาดฟอนต์ของคำอธิบายภาพ**

ใช้ [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) ของคำอธิบายภาพเพื่อเข้าถึงการจัดรูปแบบข้อความและตั้งค่า [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) เป็นจุด

ตัวอย่างนี้สร้างแผนภูมิที่มีข้อมูลเริ่มต้นและตั้งข้อความคำอธิบายภาพเป็น 20 จุด นอกจากนี้ยังปิดการกำหนดขอบอัตโนมัติสำหรับแกนแนวตั้งและตั้งช่วงจาก -5 ถึง 10

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าขนาดฟอนต์ของรายการคำอธิบายภาพรายบุคคล**

ใช้คอลเล็กชัน [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) ของคำอธิบายภาพเพื่อเข้าถึงการจัดรูปแบบของรายการเฉพาะ ดัชนีของรายการเริ่มจากศูนย์ ดังนั้นดัชนี `1` หมายถึงรายการที่สอง

ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มที่ข้อมูลเริ่มต้นมีอย่างน้อยสองซีรีส์ โดยจัดรูปแบบรายการคำอธิบายภาพที่สองให้เป็นตัวหนา, ตัวเอียง, และข้อความสีน้ำเงินขนาด 20 จุด

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **ซ่อนรายการคำอธิบายภาพรายบุคคล**

เพื่อยกเลิกการแสดงซีรีส์เสริมจากคำอธิบายภาพในขณะที่ข้อมูลของมันยังคงมองเห็นได้ ให้ตั้งค่า [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) เป็น `true` ผ่าน [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/) การทำเช่นนี้จะซ่อนเฉพาะรายการคำอธิบายภาพที่เลือก; ไม่ได้ลบซีรีส์หรือจุดข้อมูลของมัน การตั้งค่า [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) เป็น `false` ในทางกลับกัน จะซ่อนคำอธิบายภาพทั้งหมด

ตัวอย่างด้านล่างสร้างแผนภูมิคอลัมน์แบบกลุ่มที่มีหลายซีรีส์โดยใช้ข้อมูลเริ่มต้น มันซ่อนรายการคำอธิบายภาพของซีรีส์ที่สอง (ดัชนี `1`) และบันทึกงานนำเสนอ จากนั้นกู้คืนรายการโดยตั้งค่า `Hide` เป็น `false` และบันทึกสำเนาที่สอง คอลัมน์ยังคงมองเห็นได้ในทั้งสองไฟล์

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// กู้คืนรายการเดียวกันโดยไม่เปลี่ยนแปลงข้อมูลแผนภูมิ
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

การเปรียบเทียบด้านล่างแสดงแผนภูมิเดียวกันที่มีรายการทั้งหมดมองเห็นและรายการที่สองถูกซ่อน คอลัมน์ของซีรีส์ที่สองยังคงไม่เปลี่ยนแปลง

![การเปรียบเทียบแผนภูมิที่มีคำอธิบายภาพทั้งหมดมองเห็นและซีรีส์ 2 ถูกซ่อนจากคำอธิบายภาพ; คอลัมน์ทั้งหมดยังคงมองเห็นได้.](hide-legend-entry.png)

ในแผนภูมิคอลัมน์, แถบ, และเส้น รายการคำอธิบายภาพระบุซีรีส์ สำหรับแผนภูมิพาย พวกมันระบุจุดข้อมูลแต่ละจุด (ส่วนของพาย) ดังนั้นให้ใช้ [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) กับส่วนที่เลือกแทน API บันทึกคุณสมบัติจุดข้อมูลนี้สำหรับประเภทแผนภูมิ `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` และ `BarOfPie` อย่ากล่าวว่ามันใช้ได้กับแผนภูมิโดนัท ซึ่งไม่ได้รวมอยู่ในรายการนั้น

## **คำถามที่พบบ่อย**

**ฉันสามารถทำให้แผนภูมิสำรองพื้นที่สำหรับคำอธิบายภาพแทนการซ้อนทับได้หรือไม่?**

ใช่. ตั้งค่า [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) เป็น `false` เพื่อสำรองพื้นที่สำหรับคำอธิบายภาพแทนการให้มันซ้อนทับกับพื้นที่แสดง

**ฉันสามารถทำให้ป้ายคำอธิบายภาพหลายบรรทัดได้อย่างไร?**

ใช่. ป้ายที่ยาวสามารถตัดบรรทัดเมื่อความกว้างที่มีไม่เพียงพอ คุณยังสามารถใช้ตัวอักษรขึ้นบรรทัดใหม่ในชื่อซีรีส์เพื่อขอให้ขึ้นบรรทัดใหม่

**ฉันจะทำให้คำอธิบายภาพใช้ชุดสีของธีมงานนำเสนอได้อย่างไร?**

ปล่อยให้สี, การเติมและฟอนต์ของคำอธิบายภาพไม่ได้ตั้งค่า เพื่อให้มันสามารถสืบทอดการจัดรูปแบบของธีม การจัดรูปแบบอย่างชัดเจนจะทับการตั้งค่าธีมที่สอดคล้อง