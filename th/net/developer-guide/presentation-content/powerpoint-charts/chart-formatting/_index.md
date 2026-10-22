---
title: จัดรูปแบบแผนภูมิการนำเสนอใน .NET
linktitle: การจัดรูปแบบแผนภูมิ
type: docs
weight: 60
url: /th/net/chart-formatting/
keywords:
- จัดรูปแบบแผนภูมิ
- การจัดรูปแบบแผนภูมิ
- องค์ประกอบแผนภูมิ
- คุณสมบัติของแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกแผนภูมิ
- คุณสมบัติฟอนต์
- ขอบโค้ง
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ .NET และยกระดับการนำเสนอ PowerPoint ของคุณด้วยแกนที่กำหนดเอง, ฟอนต์, รูปแบบตัวเลข, และขอบแผนภูมิที่โค้ง"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการจัดรูปแบบแผนภูมิในงานนำเสนอ PowerPoint ด้วยการใช้ Aspose.Slides โดยแสดงวิธีการปรับแต่งองค์ประกอบสำคัญของแผนภูมิ เช่น แกน, เส้นกริด, ชื่อเรื่อง, คำอธิบาย, พื้นที่พล็อตและการเติมผนัง เพื่อปรับปรุงรูปลักษณ์และความอ่านง่ายของข้อมูลแผนภูมิ

นอกจากนี้ยังสาธิตวิธีการตั้งค่าคุณสมบัติฟอนต์สำหรับข้อความในแผนภูมิ, การใช้รูปแบบตัวเลขที่กำหนดไว้ล่วงหน้ากับข้อมูลแผนภูมิ, และการเปิดใช้งานมุมโค้งสำหรับพื้นที่แผนภูมิ ตัวอย่างเหล่านี้แสดงให้เห็นวิธีการควบคุมทั้งสไตล์ด้านภาพและการนำเสนอข้อมูลของแผนภูมิในงานนำเสนอ

## **จัดรูปแบบเอนทิตีของแผนภูมิ**

ใช้ [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) เพื่อจัดรูปแบบชื่อเรื่องของแผนภูมิ, แกน, เส้นกริด, คำอธิบาย และพื้นที่พล็อต ตัวอย่างนี้สร้างแผนภูมิเส้นพร้อมเครื่องหมายและข้อมูลเริ่มต้น จากนั้นนำสไตล์ข้อความและเส้นที่แยกต่างหากไปใช้กับแกนค่าที่และแกนประเภท ความสูงของฟอนต์และความกว้างของเส้นกำหนดเป็นจุด; ป้ายชื่อประเภทถูกหมุน 45 องศา

แกนค่าที่ใช้ [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) แยกจากเซลล์ต้นทาง ช่วงสเกลตั้งแต่ -2 ถึง 15, มีช่วงหลักที่ 2 และช่วงย่อยที่ 0.5 ตัวอย่างนี้ยังรวมการจัดรูปแบบเป็นเปอร์เซ็นต์พร้อม [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) ที่ตั้งค่าเป็นพัน ดังนั้นควรปรับการตั้งค่าเหล่านี้ให้สอดคล้องกับความหมายและขนาดของข้อมูลของคุณ คำอธิบายอยู่ด้านนอกพื้นที่พล็อตเนื่องจาก [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) ถูกปิดใช้งาน การเติมผนังหลังและพื้นดินกำหนดผ่าน [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) และ [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/) แต่ผิวเหล่านี้จะมองเห็นได้เฉพาะในแผนภูมิ 3D

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
var chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

var valueAxisText = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
valueAxisText.FontBold = NullableBool.True;
valueAxisText.FontHeight = 16;
valueAxisText.FontItalic = NullableBool.True;
valueAxisText.FillFormat.FillType = FillType.Solid;
valueAxisText.FillFormat.SolidFillColor.Color = Color.DarkGreen;
valueAxisText.LatinFont = new FontData("Times New Roman");

chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
var valueAxisTitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valueAxisTitle.Text = "Primary Axis";
valueAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valueAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valueAxisTitle.PortionFormat.FontHeight = 20;
valueAxisTitle.PortionFormat.FontBold = NullableBool.True;
valueAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

var categoryAxisText = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
categoryAxisText.FontBold = NullableBool.True;
categoryAxisText.FontHeight = 16;
categoryAxisText.FontItalic = NullableBool.True;
categoryAxisText.FillFormat.FillType = FillType.Solid;
categoryAxisText.FillFormat.SolidFillColor.Color = Color.Blue;
categoryAxisText.LatinFont = new FontData("Arial");

chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

var categoryAxisTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
categoryAxisTitle.Text = "Sample Category";
categoryAxisTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
categoryAxisTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
categoryAxisTitle.PortionFormat.FontHeight = 20;
categoryAxisTitle.PortionFormat.FontBold = NullableBool.True;
categoryAxisTitle.PortionFormat.FontItalic = NullableBool.True;

chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

var legendText = chart.Legend.TextFormat.PortionFormat;
legendText.FontBold = NullableBool.True;
legendText.FontHeight = 16;
legendText.FontItalic = NullableBool.True;
legendText.FillFormat.FillType = FillType.Solid;
legendText.FillFormat.SolidFillColor.Color = Color.DarkRed;

chart.Legend.Overlay = false;

chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;

chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

presentation.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าคุณสมบัติฟอนต์สำหรับแผนภูมิ**

กำหนดขนาดฟอนต์เริ่มต้นสำหรับข้อความในแผนภูมิโดยใช้ [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/). ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มพร้อมฟอนต์ขนาด 20 จุดและเปิดใช้งานป้ายค่าให้กับซีรีส์แรกผ่าน [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/). องค์ประกอบข้อความที่มีการตั้งค่าฟอนต์เฉพาะของตนสามารถลบค่าตั้งต้นของแผนภูมิได้

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
chart.TextFormat.PortionFormat.FontHeight = 20;
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

presentation.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
```

## **ตั้งค่ารูปแบบตัวเลข**

ใช้ [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) เพื่อใช้รูปแบบตัวเลขที่สร้างไว้ล่วงหน้าในเซลล์เวิร์กบุ๊กของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มพร้อมข้อมูลที่อิงเซลล์เริ่มต้น และกำหนดรูปแบบดัชนี 10 (`0.00%`) ให้กับแต่ละเซลล์ค่าของซีรีส์ ซึ่งจะเปลี่ยนการแสดงค่าที่เวิร์กบุ๊กโดยไม่เปลี่ยนตัวเลขพื้นฐาน; ตัวอย่างเช่น 0.25 จะปรากฏเป็น 25.00% รูปแบบแกนและป้ายข้อมูลสามารถกำหนดแยกกันได้

```csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
var series = chart.ChartData.Series;

foreach (var chartSeries in series)
{
    foreach (var dataPoint in chartSeries.DataPoints)
    {
        dataPoint.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

presentation.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

ตารางต่อไปนี้แสดงดัชนีรูปแบบตัวเลขที่สร้างไว้ล่วงหน้าพร้อมรูปแบบ Excel ตัวอย่างสำหรับภาษอังกฤษ (สหรัฐอเมริกา) รูปแบบสตริงที่แน่นอนและการแสดงผลอาจแตกต่างกันไปตามแอปพลิเคชันและภาษาท้องถิ่น โดยเฉพาะอย่างยิ่งสำหรับสกุลเงินและวันที่ รูปแบบ Excel บางอย่างก็แตกต่างจากค่าเริ่มต้นในมาตรฐาน OOXML ตามที่อธิบายใน [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528)

| ดัชนี | รูปแบบ |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **ตั้งค่าขอบโค้งของพื้นที่แผนภูมิ**

เปิดใช้งาน [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) เพื่อทำให้มุมของพื้นที่แผนภูมิเป็นโค้ง ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มและใช้ [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) เพื่อกำหนดโครงร่างเป็นสีเทาแบบทึบและสไตล์เส้นเดี่ยวก่อนบันทึกงานนำเสนอ

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
chart.LineFormat.FillFormat.FillType = FillType.Solid;
chart.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chart.LineFormat.Style = LineStyle.Single;
chart.HasRoundedCorners = true;

presentation.Save("out.pptx", SaveFormat.Pptx);
```

## **แก้ไขคำอธิบายแผนภูมิที่มีอยู่**

แผนภูมิสามารถมีรูปทรงที่กำหนดเองได้ เช่น คำอธิบายข้อความที่อธิบายสถานะของรายงาน เข้าถึงรูปทรงเหล่านี้ผ่าน [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/), ซึ่งยังปรากฏภายใต้ [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) ในอ้างอิง API ของ Chart คอลเลกชัน [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) จะบรรจุรูปทรงที่เป็นของแผนภูมิ

กล่องข้อความธรรมดาที่วางเหนือแผนภูมิจัดเป็นของสไลด์ แม้ว่ามันจะดูเหมือนเป็นส่วนหนึ่งของแผนภูมิ การวนลูปผ่าน [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) จะพบบแผนภูมิและรูปทรงสไลด์ธรรมดา แต่จะไม่แสดงรูปทรงแต่ละอันภายในแผนภูมิ ชื่อเรื่องของแผนภูมิและป้ายข้อมูลเป็นองค์ประกอบแผนภูมิแยกต่างหาก ไม่ใช่คำอธิบายที่กำหนดเองในคอลเลกชันนี้

ดาวน์โหลด [chart-annotations.pptx](chart-annotations.pptx) แล้ววางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกมีแผนภูมิที่มีคำอธิบายที่ไม่รวมกลุ่มแสดงว่า "Preliminary results", เส้นที่เป็นของแผนภูมิ, และกล่องข้อความสไลด์ธรรมดาที่เขียนว่า "Slide overlay". ตัวอย่างจะค้นหาแผนภูมิแรกบนสไลด์นั้นและเปลี่ยนคำอธิบายเป็น "Final results" เมื่อรายงานพร้อมเผยแพร่ จะตรวจสอบว่าคอลเลกชันว่างหรือไม่และแก้ไขเฉพาะ [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ที่มี [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) ไม่เป็นค่า null และข้อความตรงตามที่คาดหวัง

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("chart-annotations.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.OfType<IChart>().FirstOrDefault();

if (chart == null || chart.UserShapes.Shapes.Count == 0)
{
    Console.WriteLine("No chart or chart-owned shapes found.");
    return;
}

var updated = false;
foreach (var shape in chart.UserShapes.Shapes)
{
    if (shape is IAutoShape annotation && 
        annotation.TextFrame != null && 
        annotation.TextFrame.Text == "Preliminary results")
    {
        annotation.TextFrame.Text = "Final results";
        updated = true;
        break;
    }
}

if (updated)
{
    presentation.Save("chart-annotations-updated.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("No matching text annotation found.");
}
```

เส้นและกล่องข้อความสไลด์จะคงเดิม ตารางต่อไปนี้แสดงภาพก่อนและหลังการบันทึกใหม่:

| ก่อนแก้ไข | หลังแก้ไข |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
ตัวอย่างจะตรวจสอบเฉพาะรูปทรงระดับบนสุดที่เป็นของแผนภูมิ หากคำอธิบายอยู่ภายใน [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), ให้ตรวจสอบคอลเลกชัน [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) ของกลุ่มนั้นด้วย ทำซ้ำแบบเรียกซ้ำสำหรับกลุ่มซ้อนกัน และใช้การตรวจสอบข้อความเดียวกันกับรูปทรงลูกของพวกมัน กลุ่มเองเป็นตัวคอนเทนเนอร์; อย่าถือว่ามันเป็นกล่องข้อความ
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งค่าการเติมสีกึ่งโปร่งใสสำหรับคอลัมน์/พื้นที่ในขณะที่ยังคงขอบไม่โปร่งใสได้หรือไม่?**

ใช่ การตั้งค่าความโปร่งใสของการเติมและโครงร่างทำแยกกัน ซึ่งมีประโยชน์สำหรับการปรับปรุงความอ่านง่ายของกริดและข้อมูลในภาพที่แน่นหนา

**ฉันจะจัดการกับป้ายข้อมูลเมื่อมันทับกันได้อย่างไร?**

ลดขนาดฟอนต์, ปิดใช้งานส่วนประกอบของป้ายที่ไม่จำเป็น (เช่น ประเภท), ปรับตำแหน่งป้าย, แสดงป้ายเฉพาะสำหรับจุดที่เลือกหากจำเป็น, หรือเปลี่ยนรูปแบบเป็น "ค่า + คำอธิบาย"

**ฉันสามารถใช้การเติมไล่สีหรือแบบลวดลายกับซีรีส์ได้หรือไม่?**

ได้ ซีรีส์รองรับการเติมแบบทึบ, ไล่สี, และลวดลาบ ในการใช้งานจริงควรใช้ไล่สีอย่างระมัดระวังและหลีกเลี่ยงการผสมผสานที่ทำให้ความคอนทราสต์กับกริดและข้อความลดลง