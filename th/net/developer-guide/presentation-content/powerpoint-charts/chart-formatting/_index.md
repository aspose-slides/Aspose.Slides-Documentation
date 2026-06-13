---
title: การจัดรูปแบบแผนภูมิการนำเสนอใน .NET
linktitle: การจัดรูปแบบแผนภูมิ
type: docs
weight: 60
url: /th/net/chart-formatting/
keywords:
- จัดรูปแบบแผนภูมิ
- การจัดรูปแบบแผนภูมิ
- เอนทิตี้แผนภูมิ
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
description: "เรียนรู้การจัดรูปแบบแผนภูมิใน Aspose.Slides สำหรับ .NET และยกระดับการนำเสนอ PowerPoint ของคุณด้วยสไตล์มืออาชีพที่ดึงดูดสายตา."
---
## **ภาพรวม**

บทความนี้อธิบายวิธีจัดรูปแบบแผนภูมิในงานนำเสนอ PowerPoint ด้วย Aspose.Slides ซึ่งจะแสดงวิธีปรับแต่งส่วนสำคัญของแผนภูมิ เช่น แกน, เส้นกริด, ชื่อเรื่อง, คำอธิบาย, พื้นที่พล็อต, และการเติมสีกำแพง เพื่อปรับปรุงรูปลักษณ์และความอ่านง่ายของข้อมูลแผนภูมิ

นอกจากนี้ยังสาธิตวิธีตั้งค่าคุณสมบัติของฟอนต์สำหรับข้อความในแผนภูมิ, ใช้รูปแบบตัวเลขที่กำหนดล่วงหน้าและกำหนดเองกับข้อมูลแผนภูมิ, รวมถึงการเปิดใช้มุมโค้งสำหรับพื้นที่แผนภูมิ ตัวอย่างเหล่านี้แสดงวิธีควบคุมทั้งสไตล์การแสดงผลและการนำเสนอข้อมูลของแผนภูมิในงานนำเสนอ

## **จัดรูปแบบเอนทิตี้ของแผนภูมิ**
Aspose.Slides for .NET ให้ผู้พัฒนาสามารถเพิ่มแผนภูมิกำหนดเองลงในสไลด์ตั้งแต่ต้นได้ บทความนี้อธิบายวิธีจัดรูปแบบเอนทิตี้แผนภูมิหลายประเภทรวมถึงแกนหมวดหมู่และแกนค่า

Aspose.Slides for .NET มี API ง่ายสำหรับจัดการเอนทิตี้แผนภูมิต่าง ๆ และจัดรูปแบบโดยใช้ค่าแบบกำหนดเอง:

1. สร้างอินสแตนซ์ของคลาส **Presentation**.
2. รับอ้างอิงสไลด์ตามดัชนี.
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นโดยเลือกประเภทที่ต้องการ (ในตัวอย่างนี้จะใช้ ChartType.LineWithMarkers).
4. เข้าถึงแกนค่า (Value Axis) ของแผนภูมิและตั้งค่าคุณสมบัติดังต่อไปนี้:
   1. ตั้งค่า **Line format** สำหรับเส้นกริดหลักของแกนค่า
   2. ตั้งค่า **Line format** สำหรับเส้นกริดรองของแกนค่า
   3. ตั้งค่า **Number Format** สำหรับแกนค่า
   4. ตั้งค่า **Min, Max, Major and Minor units** สำหรับแกนค่า
   5. ตั้งค่า **Text Properties** สำหรับข้อมูลแกนค่า
   6. ตั้งค่า **Title** สำหรับแกนค่า
   7. ตั้งค่า **Line Format** สำหรับแกนค่า
5. เข้าถึงแกนหมวดหมู่ (Category Axis) ของแผนภูมิและตั้งค่าคุณสมบัติดังต่อไปนี้:
   1. ตั้งค่า **Line format** สำหรับเส้นกริดหลักของแกนหมวดหมู่
   2. ตั้งค่า **Line format**สำหรับเส้นกริดรองของแกนหมวดหมู่
   3. ตั้งค่า **Text Properties** สำหรับข้อมูลแกนหมวดหมู่
   4. ตั้งค่า **Title** สำหรับแกนหมวดหมู่
   5. ตั้งค่า **Label Positioning** สำหรับแกนหมวดหมู่
   6. ตั้งค่า **Rotation Angle** สำหรับป้ายกำกับแกนหมวดหมู่
6. เข้าถึงคำอธิบายแผนภูมิ (Legend) และตั้งค่า **Text Properties** สำหรับมัน
7. ตั้งค่าให้คำอธิบายแผนภูมิไม่ทับกับแผนภูมิ
8. เข้าถึง **Secondary Value Axis** ของแผนภูมิและตั้งค่าคุณสมบัติดังต่อไปนี้:
   1. เปิดใช้ **Value Axis** รอง
   2. ตั้งค่า **Line Format** สำหรับแกนค่ารอง
   3. ตั้งค่า **Number Format** สำหรับแกนค่ารอง
   4. ตั้งค่า **Min, Max, Major and Minor units** สำหรับแกนค่ารอง
9. ตอนนี้ให้พล็อตซีรีส์แผนภูมิแรกบนแกนค่ารอง
10. ตั้งค่าสีเติมกำแพงด้านหลังของแผนภูมิ
11. ตั้งค่าสีเติมพื้นที่พล็อตของแผนภูมิ
12. เขียนงานนำเสนอที่แก้ไขแล้วเป็นไฟล์ PPTX

```c#
// สร้างการนำเสนอ// สร้างการนำเสนอ
Presentation pres = new Presentation();

// เข้าถึงสไลด์แรก
ISlide slide = pres.Slides[0];

// เพิ่มแผนภูมิ ตัวอย่าง
IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

// ตั้งค่าชื่อแผนภูมิ
chart.HasTitle = true;
chart.ChartTitle.AddTextFrameForOverriding("");
IPortion chartTitle = chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].Portions[0];
chartTitle.Text = "Sample Chart";
chartTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
chartTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
chartTitle.PortionFormat.FontHeight = 20;
chartTitle.PortionFormat.FontBold = NullableBool.True;
chartTitle.PortionFormat.FontItalic = NullableBool.True;

// ตั้งค่ารูปแบบเส้นกริดหลักสำหรับแกนค่า
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Blue;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.Width = 5;
chart.Axes.VerticalAxis.MajorGridLinesFormat.Line.DashStyle = LineDashStyle.DashDot;

// ตั้งค่ารูปแบบเส้นกริดรองสำหรับแกนค่า
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Red;
chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.Width = 3;

// ตั้งค่ารูปแบบตัวเลขของแกนค่า
chart.Axes.VerticalAxis.IsNumberFormatLinkedToSource = false;
chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Thousands;
chart.Axes.VerticalAxis.NumberFormat = "0.0%";

// ตั้งค่าค่าสูงสุดและค่าต่ำสุดของแผนภูมิ
chart.Axes.VerticalAxis.IsAutomaticMajorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.IsAutomaticMinorUnit = false;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;

chart.Axes.VerticalAxis.MaxValue = 15f;
chart.Axes.VerticalAxis.MinValue = -2f;
chart.Axes.VerticalAxis.MinorUnit = 0.5f;
chart.Axes.VerticalAxis.MajorUnit = 2.0f;

// ตั้งค่าคุณสมบัติข้อความของแกนค่า
IChartPortionFormat txtVal = chart.Axes.VerticalAxis.TextFormat.PortionFormat;
txtVal.FontBold = NullableBool.True;
txtVal.FontHeight = 16;
txtVal.FontItalic = NullableBool.True;
txtVal.FillFormat.FillType = FillType.Solid; ;
txtVal.FillFormat.SolidFillColor.Color = Color.DarkGreen;
txtVal.LatinFont = new FontData("Times New Roman");

// ตั้งค่าชื่อแกนค่า
chart.Axes.VerticalAxis.HasTitle = true;
chart.Axes.VerticalAxis.Title.AddTextFrameForOverriding("");
IPortion valtitle = chart.Axes.VerticalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
valtitle.Text = "Primary Axis";
valtitle.PortionFormat.FillFormat.FillType = FillType.Solid;
valtitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
valtitle.PortionFormat.FontHeight = 20;
valtitle.PortionFormat.FontBold = NullableBool.True;
valtitle.PortionFormat.FontItalic = NullableBool.True;

// ตั้งค่ารูปแบบเส้นแกนค่า : ตอนนี้ล้าสมัย
// chart.Axes.VerticalAxis.aVerticalAxis.l.AxisLine.Width = 10;
// chart.Axes.VerticalAxis.AxisLine.FillFormat.FillType = FillType.Solid;
// Chart.Axes.VerticalAxis.AxisLine.FillFormat.SolidFillColor.Color = Color.Red;

// ตั้งค่ารูปแบบเส้นกริดหลักสำหรับแกนหมวดหมู่
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Green;
chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.Width = 5;

// ตั้งค่ารูปแบบเส้นกริดรองสำหรับแกนหมวดหมู่
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.Solid;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.FillFormat.SolidFillColor.Color = Color.Yellow;
chart.Axes.HorizontalAxis.MinorGridLinesFormat.Line.Width = 3;

// ตั้งค่าคุณสมบัติข้อความของแกนหมวดหมู่
IChartPortionFormat txtCat = chart.Axes.HorizontalAxis.TextFormat.PortionFormat;
txtCat.FontBold = NullableBool.True;
txtCat.FontHeight = 16;
txtCat.FontItalic = NullableBool.True;
txtCat.FillFormat.FillType = FillType.Solid; ;
txtCat.FillFormat.SolidFillColor.Color = Color.Blue;
txtCat.LatinFont = new FontData("Arial");

// ตั้งค่าชื่อหมวดหมู่
chart.Axes.HorizontalAxis.HasTitle = true;
chart.Axes.HorizontalAxis.Title.AddTextFrameForOverriding("");

IPortion catTitle = chart.Axes.HorizontalAxis.Title.TextFrameForOverriding.Paragraphs[0].Portions[0];
catTitle.Text = "Sample Category";
catTitle.PortionFormat.FillFormat.FillType = FillType.Solid;
catTitle.PortionFormat.FillFormat.SolidFillColor.Color = Color.Gray;
catTitle.PortionFormat.FontHeight = 20;
catTitle.PortionFormat.FontBold = NullableBool.True;
catTitle.PortionFormat.FontItalic = NullableBool.True;

// ตั้งค่าตำแหน่งป้ายกำกับแกนหมวดหมู่
chart.Axes.HorizontalAxis.TickLabelPosition = TickLabelPositionType.Low;

// ตั้งค่ามุมการหมุนของป้ายกำกับแกนหมวดหมู่
chart.Axes.HorizontalAxis.TickLabelRotationAngle = 45;

// ตั้งค่าคุณสมบัติข้อความของคำอธิบายแผนภูมิ
IChartPortionFormat txtleg = chart.Legend.TextFormat.PortionFormat;
txtleg.FontBold = NullableBool.True;
txtleg.FontHeight = 16;
txtleg.FontItalic = NullableBool.True;
txtleg.FillFormat.FillType = FillType.Solid; ;
txtleg.FillFormat.SolidFillColor.Color = Color.DarkRed;

// ตั้งค่าให้แสดงคำอธิบายแผนภูมิโดยไม่ทับกับแผนภูมิ

chart.Legend.Overlay = true;
            
// พล็อตซีรีส์แรกบนแกนค่ารอง
// Chart.ChartData.Series[0].PlotOnSecondAxis = true;

// ตั้งค่าสีกำแพงด้านหลังของแผนภูมิ
chart.BackWall.Thickness = 1;
chart.BackWall.Format.Fill.FillType = FillType.Solid;
chart.BackWall.Format.Fill.SolidFillColor.Color = Color.Orange;

chart.Floor.Format.Fill.FillType = FillType.Solid;
chart.Floor.Format.Fill.SolidFillColor.Color = Color.Red;
// ตั้งค่าสีพื้นที่พล็อต
chart.PlotArea.Format.Fill.FillType = FillType.Solid;
chart.PlotArea.Format.Fill.SolidFillColor.Color = Color.LightCyan;

// Save Presentation
pres.Save("FormattedChart_out.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าคุณสมบัติของฟอนต์สำหรับแผนภูมิ**
Aspose.Slides for .NET รองรับการตั้งค่าคุณสมบัติเกี่ยวกับฟอนต์สำหรับแผนภูมิ โปรดทำตามขั้นตอนต่อไปนี้เพื่อกำหนดคุณสมบัติของฟอนต์สำหรับแผนภูมิ

- สร้างอ็อบเจกต์คลาส `Presentation`.
- เพิ่มแผนภูมิบนสไลด์.
- ตั้งค่าความสูงของฟอนต์.
- บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่างโค้ดด้านล่างนี้เป็นตัวอย่างให้ดู

```c#
using (Presentation pres = new Presentation())
{               
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.TextFormat.PortionFormat.FontHeight = 20;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    pres.Save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
}
```

## **ตั้งค่ารูปแบบตัวเลข**
Aspose.Slides for .NET มี API ง่ายสำหรับจัดการรูปแบบข้อมูลของแผนภูมิ:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation).
2. รับอ้างอิงสไลด์ตามดัชนี.
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้นโดยเลือกประเภทที่ต้องการ (ตัวอย่างนี้ใช้ **ChartType.ClusteredColumn**).
4. ตั้งค่ารูปแบบตัวเลขจากค่าที่กำหนดล่วงหน้าที่เป็นไปได้.
5. เดินทางผ่านเซลล์ข้อมูลของแต่ละซีรีส์แผนภูมิและตั้งค่ารูปแบบตัวเลขของข้อมูลแผนภูมิ.
6. บันทึกงานนำเสนอ.
7. ตั้งค่ารูปแบบตัวเลขแบบกำหนดเอง.
8. เดินทางผ่านเซลล์ข้อมูลของแต่ละซีรีส์แผนภูมิและตั้งค่ารูปแบบตัวเลขของข้อมูลแผนภูมิที่แตกต่างกัน.
9. บันทึกงานนำเสนอ.

```c#
// สร้างการนำเสนอ// สร้างการนำเสนอ
Presentation pres = new Presentation();

// เข้าถึงสไลด์การนำเสนอแรก
ISlide slide = pres.Slides[0];

// เพิ่มแผนภูมิคอลัมน์แบบกลุ่มเริ่มต้น
IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

// เข้าถึงคอลเลกชันซีรีส์ของแผนภูมิ
IChartSeriesCollection series = chart.ChartData.Series;

// ตั้งค่ารูปแบบตัวเลขที่กำหนดล่วงหน้า
// วนผ่านทุกซีรีส์ของแผนภูมิ
foreach (ChartSeries ser in series)
{
    // วนผ่านทุกเซลล์ข้อมูลในซีรีส์
    foreach (IChartDataPoint cell in ser.DataPoints)
    {
        // ตั้งค่ารูปแบบตัวเลข
        cell.Value.AsCell.PresetNumberFormat = 10; //0.00%
    }
}

// บันทึกการนำเสนอ
pres.Save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
```

ค่ารูปแบบตัวเลขที่กำหนดล่วงหน้าที่สามารถใช้ได้พร้อมดัชนีของแต่ละรูปแบบมีดังต่อไปนี้:

|**0**|General|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **ตั้งค่าขอบโค้งของพื้นที่แผนภูมิ**
Aspose.Slides for .NET รองรับการตั้งค่าพื้นที่แผนภูมิ คุณลักษณะ **IChart.HasRoundedCorners** และ **Chart.HasRoundedCorners** ถูกเพิ่มใน Aspose.Slides

1. สร้างอ็อบเจกต์คลาส `Presentation`.
2. เพิ่มแผนภูมิบนสไลด์.
3. ตั้งค่าประเภทการเติมและสีเติมของแผนภูมิ
4. ตั้งค่า **rounded corner** เป็น True.
5. บันทึกงานนำเสนอที่แก้ไขแล้ว.

ตัวอย่างโค้ดด้านล่างนี้เป็นตัวอย่างให้ดู

```c#
using (Presentation presentation = new Presentation())
{
	ISlide slide = presentation.Slides[0];
	IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
	chart.LineFormat.FillFormat.FillType = FillType.Solid;
	chart.LineFormat.Style = LineStyle.Single;
	chart.HasRoundedCorners = true;

	presentation.Save("out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**ฉันสามารถตั้งค่าสีเติมกึ่งโปร่งใสสำหรับคอลัมน์/พื้นที่โดยให้เส้นขอบยังคงเป็นมั่นคงได้ไหม?**

ได้ การตั้งค่าความโปร่งใสของสีเติมและเส้นขอบทำแยกกัน ซึ่งช่วยให้การอ่านกริดและข้อมูลในภาพที่หนาแน่นทำได้ดีขึ้น

**ฉันจะรับมือกับป้ายข้อมูลที่ทับกันอย่างไร?**

ลดขนาดฟอนต์, ปิดการทำงานส่วนประกอบป้ายข้อมูลที่ไม่จำเป็น (เช่น หมวดหมู่), ตั้งค่าการออฟเซ็ต/ตำแหน่งของป้าย, แสดงป้ายเฉพาะจุดที่เลือกหากจำเป็น, หรือเปลี่ยนรูปแบบเป็น “value + legend”

**ฉันสามารถใช้การเติมแบบไล่ระดับสีหรือแบบลายเส้นกับซีรีส์ได้ไหม?**

ได้ ทั้งการเติมสีทึบและการเติมแบบไล่ระดับสี/ลายเส้นมักจะมีให้ใช้งาน ในการใช้งานจริงควรใช้การไล่ระดับสีอย่างจำกัดและหลีกเลี่ยงการผสมผสานที่ลดความคมชัดกับกริดและข้อความ