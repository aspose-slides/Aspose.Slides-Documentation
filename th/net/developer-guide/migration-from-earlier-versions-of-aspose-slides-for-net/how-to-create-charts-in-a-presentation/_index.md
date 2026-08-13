---
title: วิธีสร้างแผนภูมิในงานนำเสนอด้วย .NET
linktitle: สร้างแผนภูมิ
type: docs
weight: 30
url: /th/net/how-to-create-charts-in-a-presentation/
keywords:
- การย้าย
- สร้างแผนภูมิ
- โค้ดเก่า
- โค้ดใหม่
- วิธีการเก่า
- วิธีการใหม่
- PowerPoint
- OpenDocument
- งานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีสร้างแผนภูมิในงานนำเสนอ PowerPoint PPT, PPTX และ ODP ด้วย .NET และ Aspose.Slides โดยใช้ทั้ง API แผนภูมิแบบเก่าและแบบใหม่"
---
{{% alert color="info" %}} 
มีการเปิดตัว [Aspose.Slides for .NET API](/slides/th/net/) ใหม่และตอนนี้ผลิตภัณฑ์เดียวนี้รองรับความสามารถในการสร้างเอกสาร PowerPoint ตั้งแต่ต้นและแก้ไขเอกสารที่มีอยู่
{{% /alert %}} 
## **การสนับสนุนโค้ดเก่า**
เพื่อใช้โค้ดเก่าที่พัฒนาด้วย Aspose.Slides for .NET เวอร์ชันก่อนหน้า 13.x คุณต้องทำการเปลี่ยนแปลงเล็กน้อยในโค้ดของคุณและโค้ดจะทำงานเช่นเดิม คลาสทั้งหมดที่เคยอยู่ใน Aspose.Slides for .NET รุ่นเก่าภายใต้เนมสเปซ Aspose.Slide และ Aspose.Slides.Pptx ตอนนี้ถูกรวมเข้าในเนมสเปซ Aspose.Slides เพียงหนึ่งเดียว โปรดดูตัวอย่างโค้ดง่าย ๆ ด้านล่างสำหรับการสร้างแผนภูมิปกติจากศูนย์ในงานนำเสนอโดยใช้ Aspose.Slides API เก่าและทำตามขั้นตอนที่อธิบายวิธีการย้ายไปยัง API ที่รวมใหม่
## **แนวทางการใช้ Aspose.Slides for .NET รุ่นเก่า**
```c#
using System.Drawing;

//สร้างอินสแตนซ์ของคลาส PresentationEx ที่แสดงไฟล์ PPTX
using (PresentationEx pres = new PresentationEx())
{
	//เข้าถึงสไลด์แรก
	SlideEx sld = pres.Slides[0];

	// เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้น
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//ตั้งค่าชื่อแผนภูมิ
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//ตั้งซีรีส์แรกให้แสดงค่า
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//ตั้งดัชนีของชีตข้อมูลแผนภูมิ 
	int defaultWorksheetIndex = 0;

	//รับ worksheet ข้อมูลแผนภูมิ
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//ลบซีรีส์และหมวดหมู่ที่สร้างโดยค่าเริ่มต้น
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//เพิ่มซีรีส์ใหม่
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//เพิ่มหมวดหมู่ใหม่
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//รับซีรีส์แผนภูมิแรก
	ChartSeriesEx series = chart.ChartData.Series[0];

	//กำลังเติมข้อมูลให้ซีรีส์
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//ตั้งค่าสีเติมสำหรับซีรีส์
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//รับซีรีส์แผนภูมิที่สอง
	series = chart.ChartData.Series[1];

	//กำลังเติมข้อมูลให้ซีรีส์
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//ตั้งค่าสีเติมสำหรับซีรีส์
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//สร้างป้ายกำกับแบบกำหนดเองสำหรับแต่ละหมวดหมู่ของซีรีส์ใหม่

	//ป้ายกำกับแรกจะแสดงชื่อหมวดหมู่
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//แสดงชื่อซีรีส์สำหรับป้ายกำกับที่สอง
	lbl = new DataLabelEx(series);
	lbl.ShowSeriesName = true;
	lbl.Id = 1;
	series.Labels.Add(lbl);

	//แสดงค่าสำหรับป้ายกำกับที่สาม
	lbl = new DataLabelEx(series);
	lbl.ShowValue = true;
	lbl.ShowSeriesName = true;
	lbl.Separator = "/";
	lbl.Id = 2;
	series.Labels.Add(lbl);

	//แสดงค่าและข้อความกำหนดเอง
	lbl = new DataLabelEx(series);
	lbl.TextFrame.Text = "My text";
	lbl.Id = 3;
	series.Labels.Add(lbl);

	//บันทึกงานนำเสนอพร้อมแผนภูมิ
	pres.Write(@"D:\AsposeChart.pptx");
}
```

## **แนวทางการใช้ Aspose.Slides for .NET 13.x ใหม่**
``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

//สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX//สร้างอินสแตนซ์ของคลาส Presentation ที่แสดงไฟล์ PPTX
Presentation pres = new Presentation();

//เข้าถึงสไลด์แรก
ISlide sld = pres.Slides[0];

// เพิ่มแผนภูมิด้วยข้อมูลเริ่มต้น
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//ตั้งค่าชื่อแผนภูมิ
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//ตั้งดัชนีของชีตข้อมูลแผนภูมิ
int defaultWorksheetIndex = 0;

//รับ worksheet ข้อมูลแผนภูมิ
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//ลบซีรีส์และหมวดหมู่ที่สร้างโดยค่าเริ่มต้น
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//เพิ่มซีรีส์ใหม่
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//ตั้งค่าให้ซีรีส์แรกแสดงค่า
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//เพิ่มหมวดหมู่ใหม่
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//รับซีรีส์แผนภูมิแรก
IChartSeries series = chart.ChartData.Series[0];

//กำลังเติมข้อมูลให้ซีรีส์
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//ตั้งค่าสีเติมสำหรับซีรีส์
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//รับซีรีส์แผนภูมิที่สอง
series = chart.ChartData.Series[1];

//กำลังเติมข้อมูลให้ซีรีส์
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//ตั้งค่าสีเติมสำหรับซีรีส์
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//สร้างป้ายกำกับแบบกำหนดเองสำหรับแต่ละหมวดหมู่ของซีรีส์ใหม่

//ป้ายกำกับแรกจะแสดงชื่อหมวดหมู่
IDataLabel lbl = series.DataPoints[0].Label;
lbl.DataLabelFormat.ShowCategoryName = true;

lbl = series.DataPoints[1].Label;
lbl.DataLabelFormat.ShowSeriesName = true;

//แสดงค่าสำหรับป้ายกำกับที่สาม
lbl = series.DataPoints[2].Label;
lbl.DataLabelFormat.ShowValue = true;
lbl.DataLabelFormat.ShowSeriesName = true;
lbl.DataLabelFormat.Separator = "/";

//บันทึกงานนำเสนอพร้อมแผนภูมิ
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

โปรดดูตัวอย่างโค้ดง่าย ๆ ด้านล่างสำหรับการสร้างแผนภูมิแบบกระจายจากศูนย์ในงานนำเสนอโดยใช้ Aspose.Slides API รุ่นเก่าและวิธีทำเช่นเดียวกันด้วย API ที่รวมใหม่
## **แนวทางการใช้ Aspose.Slides for .NET รุ่นเก่า**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //สร้างแผนภูมิเริ่มต้น
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //รับดัชนี worksheet ข้อมูลแผนภูมิเริ่มต้น
    int defaultWorksheetIndex = 0;

    //เข้าถึง worksheet ข้อมูลแผนภูมิ
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //ลบซีรีส์ตัวอย่าง
    chart.ChartData.Series.Clear();

    //เพิ่มซีรีส์ใหม่
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //รับซีรีส์แผนภูมิแรก
    ChartSeriesEx series = chart.ChartData.Series[0];

    //เพิ่มจุดใหม่ (1:3) ที่นี่
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //เพิ่มจุดใหม่ (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //แก้ไขประเภทของซีรีส์
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //เปลี่ยนเครื่องหมายของซีรีส์แผนภูมิ
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //รับซีรีส์แผนภูมิที่สอง
    series = chart.ChartData.Series[1];

    //เพิ่มจุดใหม่ (5:2) ที่นี่
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

    //เพิ่มจุดใหม่ (3:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 3, 3));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

    //เพิ่มจุดใหม่ (2:2)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 3, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

    //เพิ่มจุดใหม่ (5:1)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 3, 5));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

    //เปลี่ยนเครื่องหมายของซีรีส์แผนภูมิ
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```

## **แนวทางการใช้ Aspose.Slides for .NET 13.x ใหม่**
``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//สร้างแผนภูมิเริ่มต้น
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//รับดัชนี worksheet ข้อมูลแผนภูมิเริ่มต้น
int defaultWorksheetIndex = 0;

//เข้าถึง worksheet ข้อมูลแผนภูมิ
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//ลบซีรีส์ตัวอย่าง
chart.ChartData.Series.Clear();

//เพิ่มซีรีส์ใหม่
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//รับซีรีส์แผนภูมิแรก
IChartSeries series = chart.ChartData.Series[0];

//เพิ่มจุดใหม่ (1:3) ที่นี่
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//เพิ่มจุดใหม่ (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//แก้ไขประเภทของซีรีส์
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//เปลี่ยนเครื่องหมายของซีรีส์แผนภูมิ
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//รับซีรีส์แผนภูมิที่สอง
series = chart.ChartData.Series[1];

//เพิ่มจุดใหม่ (5:2) ที่นี่
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//เพิ่มจุดใหม่ (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//เพิ่มจุดใหม่ (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//เพิ่มจุดใหม่ (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//เปลี่ยนเครื่องหมายของซีรีส์แผนภูมิ
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```