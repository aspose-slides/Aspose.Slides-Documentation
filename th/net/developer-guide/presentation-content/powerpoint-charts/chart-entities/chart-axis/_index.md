---
title: ปรับแต่งแกนแผนภูมิในงานนำเสนอด้วย .NET
linktitle: แกนแผนภูมิ
type: docs
url: /th/net/chart-axis/
keywords:
- แกนแผนภูมิ
- แกนแนวตั้ง
- แกนแนวนอน
- ปรับแต่งแกน
- จัดการแกน
- ควบคุมแกน
- คุณสมบัติของแกน
- ค่าสูงสุด
- ค่าต่ำสุด
- เส้นแกน
- รูปแบบวันที่
- ชื่อแกน
- ตำแหน่งแกน
- PowerPoint
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "ค้นพบวิธีการใช้ Aspose.Slides สำหรับ .NET ในการปรับแต่งแกนแผนภูมิในงานนำเสนอ PowerPoint สำหรับรายงานและการแสดงภาพ"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีปรับแต่งแกนแผนภูมิใน Aspose.Slides โดยจะแสดงวิธีการรับค่าแกนจริง, สลับข้อมูลระหว่างแกน, ซ่อนแกนแนวตั้งหรือแนวนอนสำหรับแผนภูมิเส้น, เปลี่ยนประเภทแกนประเภท, ตั้งรูปแบบวันที่สำหรับค่าแกนประเภท, หมุนชื่อแกน, ตั้งตำแหน่งแกน, และแสดงป้ายหน่วยบนแกนค่าที่แสดงผล

## **รับค่าสูงสุดบนแกนแนวตั้งในแผนภูมิ**

Aspose.Slides for .NET ให้คุณได้ค่าต่ำสุดและค่าสูงสุดบนแกนแนวตั้ง ให้ทำตามขั้นตอนต่อไปนี้:

1. สร้างอินสแตนซ์ของคลาส [Presentation](https://reference.aspose.com/slides/th/net/aspose.slides/presentation) .
2. เข้าถึงสไลด์แรก
3. เพิ่มแผนภูมิพร้อมข้อมูลเริ่มต้น
4. รับค่ามากที่สุดจริงบนแกน
5. รับค่าน้อยที่สุดจริงบนแกน
6. รับหน่วยหลักจริงของแกน
7. รับหน่วยรองจริงของแกน
8. รับสเกลหน่วยหลักจริงของแกน
9. รับสเกลหน่วยรองจริงของแกน

ตัวอย่างโค้ดนี้—การดำเนินการตามขั้นตอนข้างต้น—จะแสดงวิธีการรับค่าที่ต้องการใน C#:

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// บันทึกการนำเสนอ
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **สลับข้อมูลระหว่างแกน**

Aspose.Slides ช่วยให้คุณสลับข้อมูลระหว่างแกนได้อย่างรวดเร็ว—ข้อมูลที่แสดงบนแกนแนวตั้ง (y-axis) จะย้ายไปยังแกนแนวนอน (x-axis) และกลับกัน

โค้ด C# นี้จะแสดงวิธีการดำเนินการสลับข้อมูลระหว่างแกนบนแผนภูมิ:

```c#
 // สร้างงานนำเสนอเปล่า
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//สลับแถวและคอลัมน์
		   
	 // บันทึกการนำเสนอ
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **ปิดการแสดงแกนแนวตั้งสำหรับแผนภูมิเส้น**

โค้ด C# นี้จะแสดงวิธีการซ่อนแกนแนวตั้งสำหรับแผนภูมิเส้น:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **ปิดการแสดงแกนแนวนอนสำหรับแผนภูมิเส้น**

โค้ดนี้จะแสดงวิธีการซ่อนแกนแนวนอนสำหรับแผนภูมิเส้น:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **เปลี่ยนแกนประเภท**

โดยใช้ property **CategoryAxisType** คุณสามารถกำหนดประเภทแกนประเภทที่ต้องการ (**date** หรือ **text**) โค้ด C# นี้แสดงการทำงานนี้:

```c#
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes[0] as IChart;
    chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
    chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;
    chart.Axes.HorizontalAxis.MajorUnit = 1;
    chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;
    presentation.Save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
}
```

## **ตั้งรูปแบบวันที่สำหรับค่าแกนประเภท**

Aspose.Slides for .NET ให้คุณตั้งรูปแบบวันที่สำหรับค่าแกนประเภท การทำงานนี้แสดงในโค้ด C# นี้:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Area, 50, 50, 450, 300);

	IChartDataWorkbook wb = chart.ChartData.ChartDataWorkbook;

	wb.Clear(0);

	chart.ChartData.Categories.Clear();
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Add(wb.GetCell(0, "A2", new DateTime(2015, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A3", new DateTime(2016, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A4", new DateTime(2017, 1, 1).ToOADate()));
	chart.ChartData.Categories.Add(wb.GetCell(0, "A5", new DateTime(2018, 1, 1).ToOADate()));

	IChartSeries series = chart.ChartData.Series.Add(ChartType.Line);
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B2", 1));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B3", 2));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B4", 3));
	series.DataPoints.AddDataPointForLineSeries(wb.GetCell(0, "B5", 4));
	chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;
	chart.Axes.HorizontalAxis.IsNumberFormatLinkedToSource = false;
	chart.Axes.HorizontalAxis.NumberFormat = "yyyy";
	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **ตั้งมุมการหมุนสำหรับชื่อแกนแผนภูมิ**

Aspose.Slides for .NET ให้คุณตั้งมุมการหมุนสำหรับชื่อแกนแผนภูมิ โค้ด C# นี้แสดงการทำงาน:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **ตั้งตำแหน่งแกนบนแกนประเภทหรือแกนค่า**

Aspose.Slides for .NET ให้คุณตั้งตำแหน่งแกนในแกนประเภทหรือแกนค่า โค้ด C# นี้แสดงวิธีการทำงานนี้:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **เปิดการแสดงป้ายหน่วยบนแกนค่าของแผนภูมิ**

Aspose.Slides for .NET ให้คุณกำหนดค่าแผนภูมิให้แสดงป้ายหน่วยบนแกนค่าของแผนภูมิ โค้ด C# นี้แสดงการทำงาน:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **คำถามที่พบบ่อย**

**ฉันจะตั้งค่าที่แกนหนึ่งตัดกับอีกแกนได้อย่างไร (axis crossing)?**

แกนมีการตั้งค่า [crossing setting](https://reference.aspose.com/slides/th/net/aspose.slides.charts/axis/crosstype/) ซึ่งคุณสามารถเลือกให้ตัดที่ศูนย์, ที่ค่าประเภท/ค่ามากสุด, หรือที่ค่าตัวเลขที่กำหนดได้ สิ่งนี้มีประโยชน์สำหรับการย้ายแกน X ขึ้นหรือลงหรือเพื่อเน้นเส้นฐาน

**ฉันจะกำหนดตำแหน่งป้ายติ๊กที่สัมพันธ์กับแกน (ด้านข้าง, ด้านนอก, ด้านใน) อย่างไร?**

ตั้งค่า [ตำแหน่งป้าย](https://reference.aspose.com/slides/th/net/aspose.slides.charts/axis/majortickmark/) เป็น "cross", "outside" หรือ "inside" สิ่งนี้ส่งผลต่อการอ่านและช่วยประหยัดพื้นที่ โดยเฉพาะในแผนภูมิขนาดเล็ก