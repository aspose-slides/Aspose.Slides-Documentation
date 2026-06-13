---
title: ปรับแต่งแผนภูมิวงกลมในงานนำเสนอด้วย .NET
linktitle: แผนภูมิวงกลม
type: docs
url: /th/net/pie-chart/
keywords:
- แผนภูมิวงกลม
- จัดการแผนภูมิ
- ปรับแต่งแผนภูมิ
- ตัวเลือกแผนภูมิ
- การตั้งค่าแผนภูมิ
- ตัวเลือกการพล็อต
- สีของส่วนแผนภูมิ
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีสร้างและปรับแต่งแผนภูมิวงกลมใน .NET ด้วย Aspose.Slides ที่สามารถส่งออกเป็น PowerPoint เพื่อเพิ่มประสิทธิภาพการเล่าเรื่องข้อมูลของคุณในไม่กี่วินาที"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับแผนภูมิวงกลมใน Aspose.Slides โดยแสดงวิธีการกำหนดค่าตัวเลือกพล็อตที่สองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie รวมถึงวิธีเปิดใช้งานการจัดสีสไลซ์อัตโนมัติสำหรับแผนภูมิวงกลมมาตรฐาน

ตัวอย่างมุ่งเน้นที่ขั้นตอนการปรับแต่งแผนภูมิอย่างเป็นประโยชน์ เช่น การเพิ่มแผนภูมิลงในสไลด์ การปรับการตั้งค่า series และ label การแทนที่ข้อมูลแผนภูมิเริ่มต้นด้วยหมวดหมู่และค่าแบบกำหนดเอง และการบันทึกงานนำเสนอที่อัปเดต

## **ตัวเลือกแผนภูมิที่สองสำหรับแผนภูมิ Pie of Pie และ Bar of Pie**

Aspose.Slides for .NET ตอนนี้รองรับตัวเลือกพล็อตที่สองสำหรับแผนภูมิ Pie of Pie หรือ Bar of Pie ในหัวข้อนี้เราจะดูตัวอย่างวิธีระบุตัวเลือกเหล่านี้โดยใช้ Aspose.Slides เพื่อระบุคุณสมบัติต่าง ๆ โปรดทำตามขั้นตอนด้านล่าง:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) 
1. เพิ่มแผนภูมิบนสไลด์
1. ระบุตัวเลือกพล็อตที่สองของแผนภูมิ
1. เขียนงานนำเสนอไปยังดิสก์

ในตัวอย่างด้านล่าง เราได้ตั้งค่าคุณสมบัติต่าง ๆ ของแผนภูมิ Pie of Pie

```c#
// สร้างอินสแตนซ์ของคลาส Presentation
Presentation presentation = new Presentation();

// เพิ่มแผนภูมิลงบนสไลด์
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// ตั้งค่าคุณสมบัติต่าง ๆ
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// บันทึกงานนำเสนอลงดิสก์
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```

## **ตั้งค่าสีของส่วนแผนภูมิวงกลมอัตโนมัติ**

Aspose.Slides for .NET มี API อย่างง่ายสำหรับการตั้งค่าสีส่วนแผนภูมิวงกลมอัตโนมัติ ตัวอย่างโค้ดด้านล่างแสดงการตั้งค่าคุณสมบัติดังกล่าว

1. สร้างอินสแตนซ์ของคลาส Presentation
1. เข้าถึงสไลด์แรก
1. เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้น
1. ตั้งค่า Title ของแผนภูมิ
1. ตั้งค่า Series แรกให้แสดงค่า (Show Values)
1. ตั้งค่าดัชนีของแผ่นงานข้อมูลแผนภูมิ
1. ดึงแผ่นงานข้อมูลแผนภูมิ
1. ลบ Series และ Category ที่สร้างโดยอัตโนมัติ
1. เพิ่ม Category ใหม่
1. เพิ่ม Series ใหม่

บันทึกงานนำเสนอที่แก้ไขเป็นไฟล์ PPTX

```c#
// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
using (Presentation presentation = new Presentation())
{
	// สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX
	Presentation presentation = new Presentation();

	// เข้าถึงสไลด์แรก
	ISlide slides = presentation.Slides[0];

	// เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้น
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// ตั้งค่า Title ของแผนภูมิ
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// ตั้งค่า series แรกให้แสดงค่า
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// ตั้งค่าดัชนีของแผ่นข้อมูลแผนภูมิ
	int defaultWorksheetIndex = 0;

	// ดึง worksheet ข้อมูลแผนภูมิ
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// ลบ series และ category ที่สร้างโดยอัตโนมัติ
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// เพิ่ม category ใหม่
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// เพิ่ม series ใหม่
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// กำลังใส่ข้อมูลให้ series
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**รูปแบบ 'Pie of Pie' และ 'Bar of Pie' รองรับหรือไม่?**

ใช่, ไลบรารี [supports](https://reference.aspose.com/slides/th/net/aspose.slides.charts/charttype/) พล็อตทุติยภูมิสำหรับแผนภูมิวงกลม รวมถึงประเภท 'Pie of Pie' และ 'Bar of Pie'

**ฉันสามารถส่งออกเฉพาะแผนภูมิเป็นภาพ (เช่น PNG) ได้หรือไม่?**

ใช่, คุณสามารถ [export the chart itself as an image](https://reference.aspose.com/slides/th/net/aspose.slides/shape/getimage/) (เช่น PNG) ได้โดยไม่ต้องรวมการนำเสนอทั้งหมด