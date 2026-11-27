---
title: "จัดรูปแบบแผนภูมิการนำเสนอใน .NET"
linktitle: "การจัดรูปแบบแผนภูมิ"
type: docs
weight: 60
url: /th/net/chart-formatting/
keywords:
- "จัดรูปแบบแผนภูมิ"
- "การจัดรูปแบบแผนภูมิ"
- "เอนทิตี้ของแผนภูมิ"
- "คุณสมบัติของแผนภูมิ"
- "การตั้งค่าแผนภูมิ"
- "ตัวเลือกแผนภูมิ"
- "คุณสมบัติฟอนต์"
- "ขอบโค้ง"
- PowerPoint
- "การนำเสนอ"
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ .NET และยกระดับการนำเสนอ PowerPoint ของคุณด้วยแกนที่กำหนดเอง, ฟอนต์, รูปแบบตัวเลข, และขอบแผนภูมิที่โค้ง"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีกำหนดรูปแบบแผนภูมิในงานนำเสนอ PowerPoint โดยใช้ Aspose.Slides แสดงวิธีการปรับแต่งองค์ประกอบสำคัญของแผนภูมิ เช่น แกน, เส้นกริด, ชื่อเรื่อง, คำอธิบาย, พื้นที่แผนภูมิ, และการเติมผนัง เพื่อปรับปรุงลักษณะและความอ่านง่ายของข้อมูลแผนภูมิ

ยังแสดงวิธีตั้งค่าคุณสมบัติตัวอักษรสำหรับข้อความในแผนภูมิ, ใช้รูปแบบตัวเลขสำเร็จรูปกับข้อมูลแผนภูมิ, และเปิดใช้งานมุมโค้งสำหรับพื้นที่แผนภูมิ ตัวอย่างเหล่านี้แสดงวิธีควบคุมสไตล์ภาพและการนำเสนอข้อมูลของแผนภูมิในงานนำเสนอพร้อมกัน

สำหรับการเติมและขอบแยกต่างหากในช่วงที่เพิ่มและลดลง ดูที่ [ตัวอย่างแผนภูมิหุ้น](/slides/th/net/create-chart/#create-stock-charts)

## **กำหนดรูปแบบเอนทิตี้ของแผนภูมิ**

ใช้ [IChart](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/) เพื่อกำหนดรูปแบบชื่อเรื่อง, แกน, เส้นกริด, คำอธิบาย, และพื้นที่แผนภูมิ ตัวอย่างนี้สร้างแผนภูมิเส้นพร้อมเครื่องหมายและข้อมูลเริ่มต้น จากนั้นใช้สไตล์ข้อความและเส้นแยกต่างหากกับแกนค่าและแกนประเภท ขนาดฟอนต์และความกว้างเส้นระบุเป็นจุด; ป้ายชื่อประเภทถูกหมุน 45 องศา

แกนค่าจะใช้ [NumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/numberformat/) อย่างอิสระจากเซลล์ต้นฉบับ ช่วงของแกนเป็นจาก -2 ถึง 15, ด้วยช่วงหลัก 2 และช่วงย่อย 0.5 ตัวอย่างนี้ยังรวมการจัดรูปแบบเปอร์เซ็นต์กับ [DisplayUnit](https://reference.aspose.com/slides/net/aspose.slides.charts/iaxis/displayunit/) ตั้งค่าเป็นพัน ดังนั้นให้ปรับการตั้งค่าเหล่านี้ให้สอดคล้องกับความหมายและขนาดของข้อมูลของคุณ คำอธิบายอยู่ด้านนอกพื้นที่แผนภูมิเนื่องจาก [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegend/overlay/) ถูกปิด การเติมผนังหลังและพื้นผ่าน [BackWall](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/backwall/) และ [Floor](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/floor/) แต่พื้นผิวเหล่านี้จะมองเห็นได้เฉพาะในแผนภูมิ 3D

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

## **ตั้งค่าคุณสมบัติตัวอักษรสำหรับแผนภูมิ**

ตั้งขนาดฟอนต์เริ่มต้นสำหรับข้อความแผนภูมิผ่าน [Chart.TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/textformat/) ตัวอย่างสร้างแผนภูมิคอลัมน์แบบกลุ่มด้วยฟอนต์ 20 จุดและเปิดใช้งานป้ายค่าของชุดแรกผ่าน [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) ส่วนประกอบข้อความที่มีการตั้งค่าฟอนต์เฉพาะของตนเองสามารถครอบคลุมค่าปริยายของแผนภูมิได้

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

## **ใช้การจัดรูปแบบกรอบข้อความซ้ำสำหรับคำอธิบายแผนภูมิ**

เพื่อให้คำอธิบายตรงกับหัวข้อสไลด์ ให้ตั้งค่าฟอนต์ใน [DefaultPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/defaultportionformat/) ของย่อหน้าที่แรก เรียก [CopyFrom](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyfrom/) บน [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/iformattedtextcontainer/textformat/) ของคำอธิบาย มันจะอ่านการตั้งค่ากรอบข้อความ, การจัดรูปแบบของย่อหน้าที่แรก, และคุณสมบัติตัวอักษรปริยายของย่อหน้านั้น การจัดรูปแบบที่ใช้โดยตรงกับส่วนย่อยหรือย่อหน้าต่อมาจะคงอยู่ในแหล่งที่มานั้น

ตัวอย่างใช้หัวข้อหนา, 26 จุด Calibri สีกรมท่าเป็นแม่แบบ หลังจากจัดรูปแบบคำอธิบายแล้ว ใช้ [CopyTo](https://reference.aspose.com/slides/net/aspose.slides.charts/icharttextformat/copyto/) เพื่อใช้การจัดรูปแบบเดียวกันกับคำอธิบายแยก

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shapes = presentation.Slides[0].Shapes;

var heading = shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
var sourceTextFrame = heading.AddTextFrame("Quarterly sales");
var font = sourceTextFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
font.LatinFont = new FontData("Calibri");
font.FontHeight = 26;
font.FontBold = NullableBool.True;
font.FillFormat.FillType = FillType.Solid;
font.FillFormat.SolidFillColor.Color = Color.FromArgb(32, 64, 96);

var chart = shapes.AddChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
chart.Style = StyleType.Style3;
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.GetCell(0, 0, 1).Value = "Retail";
workbook.GetCell(0, 0, 2).Value = "Online";
workbook.GetCell(0, 0, 3).Value = "Wholesale";
for (var quarter = 1; quarter <= 4; quarter++)
    workbook.GetCell(0, quarter, 0).Value = $"Q{quarter}";

chart.HasLegend = true;
chart.Legend.Position = LegendPositionType.Bottom;
chart.Legend.TextFormat.CopyFrom(sourceTextFrame);

var caption = shapes.AddAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
var captionTextFrame = caption.AddTextFrame("Sales in millions of dollars");
chart.Legend.TextFormat.CopyTo(captionTextFrame);

presentation.Save("legend-formatting.pptx", SaveFormat.Pptx);
```

ในงานนำเสนอที่บันทึก คำอธิบายและคำอธิบายแคปชั่นตรงกับหัวข้อในด้านขนาด, น้ำหนัก, และสี คำอธิบายยังคงแสดงชื่อชุดข้อมูล, และแคปชั่นเก็บข้อความของตนเอง หากส่วนหนึ่งในแคปชั่นมีขนาดฟอนต์ที่ระบุไว้แล้ว ขนาดนั้นจะมีลำดับความสำคัญเหนือค่าปริยายที่คัดลอกมา

| ก่อนคัดลอก | หลังคัดลอก |
| --- | --- |
| ![แผนภูมิการขายไตรมาสที่มีป้ายคำอธิบายสีดำธรรมดาและแคปชั่นสีดำ](legend-formatting-before.png) | ![แผนภูมิเดียวกันที่มีป้ายคำอธิบายสีกรมท่าใหญ่ขึ้น, หนาและแคปชั่นที่ตรงกัน](legend-formatting.png) |

## **กำหนดรูปแบบตัวเลข**

ใช้ [IChartDataCell.PresetNumberFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatacell/presetnumberformat/) เพื่อนำรูปแบบตัวเลขที่สร้างไว้ล่วงหน้าไปใช้กับเซลล์ในสมุดงานของแผนภูมิ ตัวอย่างนี้สร้างแผนภูมิคอลัมน์แบบกลุ่มด้วยข้อมูลเริ่มต้นที่รองรับเซลล์และกำหนดรูปแบบดัชนี 10 (`0.00%`) ให้กับเซลล์ค่าชุดข้อมูลแต่ละชุด การทำเช่นนี้ทำให้ค่าที่แสดงในสมุดงานเปลี่ยนไปโดยไม่เปลี่ยนตัวเลขพื้นฐาน; ตัวอย่างเช่น 0.25 จะแสดงเป็น 25.00% รูปแบบแกนและป้ายข้อมูลสามารถกำหนดแยกกันได้

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

ตารางต่อไปนี้แสดงดัชนีรูปแบบตัวเลขที่สร้างไว้ล่วงหน้าพร้อมรูปแบบ Excel ตัวอย่างสำหรับพื้นที่ภาษาอังกฤษ (สหรัฐอเมริกา) สตริงรูปแบบที่แน่นอนและการแสดงผลอาจแตกต่างกันตามแอปพลิเคชันและภูมิภาค, โดยเฉพาะอย่างยิ่งสำหรับสกุลเงินและวันที่ รูปแบบ Excel บางอย่างยังแตกต่างจากค่าเริ่มต้นในมาตรฐาน OOXML ตามที่อธิบายใน [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528)

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

เปิดใช้งาน [IChart.HasRoundedCorners](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/hasroundedcorners/) เพื่อทำให้มุมของพื้นที่แผนภูมิเป็นโค้ง ตัวอย่างสร้างแผนภูมิคอลัมน์แบบกลุ่มและใช้ [LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) เพื่อกำหนดขอบด้วยสีเทาแบบทึบและสไตล์เส้นเดี่ยวก่อนบันทึกงานนำเสนอ

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

แผนภูมิสามารถมีรูปทรงแบบกำหนดเองได้, เช่น คำอธิบายข้อความที่อธิบายสถานะของรายงาน เข้าถึงรูปทรงเหล่านี้ผ่าน [IChart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/usershapes/), ซึ่งยังแสดงใน [Chart.UserShapes](https://reference.aspose.com/slides/net/aspose.slides.charts/chart/usershapes/) ในอ้างอิง API ของ Chart คอลเลกชัน [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) ของมันประกอบด้วยรูปทรงที่เป็นของแผนภูมิ

กล่องข้อความปกติที่วางอยู่เหนือแผนภูมิเป็นของสไลด์ แม้ว่ามันอาจดูเหมือนเป็นส่วนหนึ่งของแผนภูมิ การวนลูปผ่าน [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) จะพบแผนภูมิและรูปทรงสไลด์ปกติ, แต่จะไม่แสดงรูปทรงแต่ละรูปภายในแผนภูมิ ชื่อเรื่องแผนภูมิและป้ายข้อมูลเป็นองค์ประกอบแผนภูมิแยกจากกัน, ไม่ใช่คำอธิบายกำหนดเองในคอลเลกชันนี้

ดาวน์โหลด [chart-annotations.pptx](chart-annotations.pptx) และวางไว้ในไดเรกทอรีทำงานของแอปพลิเคชัน สไลด์แรกของไฟล์มีแผนภูมิพร้อมคำอธิบายที่ไม่ได้จัดกลุ่มว่า “Preliminary results”, เส้นที่เป็นของแผนภูมิ, และกล่องข้อความสไลด์ปกติที่มีคำว่า “Slide overlay” ตัวอย่างค้นหาแผนภูมิแรกบนสไลด์นั้นและเปลี่ยนคำอธิบายเป็น “Final results” เมื่อรายงานพร้อมเผยแพร่ จะตรวจสอบคอลเลกชันที่ว่างเปล่าและแก้ไขเฉพาะ [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) ที่มี [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/) ไม่เป็นค่า null และมีข้อความที่คาดหวัง

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

เส้นและกล่องข้อความสไลด์ยังคงไม่เปลี่ยนแปลง ภาพต่อไปนี้แสดงผลอินพุตและผลลัพธ์ที่บันทึกและเปิดใหม่

| ก่อนแก้ไข | หลังแก้ไข |
| --- | --- |
| ![คำอธิบายแผนภูมิที่อ่านว่า Preliminary results](chart-annotations-before.png) | ![คำอธิบายแผนภูมิที่อ่านว่า Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
ตัวอย่างตรวจสอบเฉพาะรูปทรงระดับบนสุดที่เป็นของแผนภูมิ หากคำอธิบายอยู่ภายใน [IGroupShape](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/), ให้ตรวจสอบคอลเลกชัน [Shapes](https://reference.aspose.com/slides/net/aspose.slides/igroupshape/shapes/) ของกลุ่มนั้นด้วย แล้วทำซ้ำแบบเรียกซ้ำสำหรับกลุ่มซ้อนกัน, ใช้การตรวจสอบข้อความเดียวกันกับรูปทรงลูกของพวกมัน กลุ่มเองเป็นคอนเทนเนอร์; อย่าปฏิบัติเช่นเป็นกล่องข้อความ
{{% /alert %}}

## **คำถามที่พบบ่อย**

**ฉันสามารถตั้งค่าการเติมสีกึ่งโปร่งใสสำหรับคอลัมน์/พื้นที่ในขณะที่ยังคงขอบสีทึบได้หรือไม่?**

ได้ การโปร่งแสงของการเติมและขอบถูกกำหนดแยกกัน ซึ่งเป็นประโยชน์ในการปรับปรุงการอ่านของกริดและข้อมูลในภาพที่หนาแน่น

**ฉันจะจัดการกับป้ายข้อมูลเมื่อติดกันอย่างไร?**

ลดขนาดฟอนต์, ปิดใช้งานส่วนประกอบของป้ายที่ไม่สำคัญ (เช่น ประเภท), ปรับตำแหน่งป้าย, แสดงป้ายเฉพาะจุดที่เลือกถ้าจำเป็น, หรือสลับรูปแบบเป็น “ค่า + คำอธิบาย”

**ฉันสามารถใช้การเติมแบบไล่สีหรือแบบลายเส้นให้กับชุดข้อมูลได้หรือไม่?**

ได้ ชุดข้อมูลรองรับการเติมแบบทึบ, ไล่สี, และลายเส้น ในการใช้งานจริงควรใช้ไล่สีอย่างระมัดระวังและหลีกเลี่ยงการผสมผสานที่ลดความคอนทราสต์กับกริดและข้อความ