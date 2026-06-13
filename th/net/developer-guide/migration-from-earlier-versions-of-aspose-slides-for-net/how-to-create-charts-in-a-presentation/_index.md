---
title: วิธีสร้างแผนภูมิในการนำเสนอบน .NET
linktitle: สร้างแผนภูมิ
type: docs
weight: 30
url: /th/net/how-to-create-charts-in-a-presentation/
keywords:
- การย้าย
- สร้างแผนภูมิ
- โค้ดรุ่นเก่า
- โค้ดสมัยใหม่
- วิธีการรุ่นเก่า
- วิธีการสมัยใหม่
- PowerPoint
- OpenDocument
- การนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีสร้างแผนภูมิในงานนำเสนอ PowerPoint PPT, PPTX และ ODP ด้วย .NET ผ่าน Aspose.Slides โดยใช้ API แผนภูมิรุ่นเก่าและรุ่นสมัยใหม่"
---
{{% alert color="primary" %}} 
มีการเปิดตัว [Aspose.Slides for .NET API](/slides/th/net/) ใหม่และขณะนี้ผลิตภัณฑ์เดียวนี้รองรับความสามารถในการสร้างเอกสาร PowerPoint ตั้งแต่เริ่มต้นและแก้ไขเอกสารที่มีอยู่แล้ว
{{% /alert %}} 
## **Support for Legacy Code**
เพื่อใช้โค้ดรุ่นเก่าที่พัฒนาด้วย Aspose.Slides for .NET เวอร์ชันก่อน 13.x คุณจำเป็นต้องทำการเปลี่ยนแปลงเล็กน้อยในโค้ดของคุณและโค้ดจะทำงานเช่นเดิม ทั้งคลาสที่เคยอยู่ใน Aspose.Slides for .NET เวอร์ชันเก่าภายใต้เนมสเปซ Aspose.Slide และ Aspose.Slides.Pptx ตอนนี้ได้ถูกรวมอยู่ในเนมสเปซ Aspose.Slides เพียงอันเดียว โปรดดูตัวอย่างโค้ดง่ายต่อไปนี้สำหรับการสร้างแผนภูมิโดยทั่วไปตั้งแต่เริ่มต้นในงานพรีเซนเทชันโดยใช้ Aspose.Slides API รุ่นเก่าและทำตามขั้นตอนที่อธิบายวิธีการย้ายไปยัง API ที่รวมใหม่
## **Legacy Aspose.Slides for .NET Approach**
```c#
//สร้างอินสแตนซ์ของคลาส PresentationEx ที่แทนไฟล์ PPTX file
using (PresentationEx pres = new PresentationEx())
{
	//เข้าถึงสไลด์แรก
	SlideEx sld = pres.Slides[0];

	// เพิ่มแชートด้วยข้อมูลเริ่มต้น
	ChartEx chart = sld.Shapes.AddChart(ChartTypeEx.ClusteredColumn, 0, 0, 500, 500);

	//ตั้งค่าชื่อแชート
	chart.ChartTitle.Text.Text = "Sample Title";
	chart.ChartTitle.Text.CenterText = true;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	//ตั้งค่าชุดข้อมูลแรกให้แสดงค่า
	chart.ChartData.Series[0].Labels.ShowValue = true;

	//กำหนดดัชนีของชีทข้อมูลแชート 
	int defaultWorksheetIndex = 0;

	//ดึงชีทข้อมูลแชート
	ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

	//ลบชุดข้อมูลและหมวดหมู่ที่สร้างโดยอัตโนมัติ
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();
	int s = chart.ChartData.Series.Count;
	s = chart.ChartData.Categories.Count;

	//เพิ่มชุดข้อมูลใหม่
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
	chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

	//เพิ่มหมวดหมู่ใหม่
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
	chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

	//รับชุดข้อมูลแชートแรก
	ChartSeriesEx series = chart.ChartData.Series[0];

	//กำลังเติมข้อมูลให้ชุดข้อมูล
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	//ตั้งค่าสีเติมสำหรับชุดข้อมูล
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Red;


	//รับชุดข้อมูลแชートที่สอง
	series = chart.ChartData.Series[1];

	//กำลังเติมข้อมูลให้ชุดข้อมูล
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
	series.Values.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

	//ตั้งค่าสีเติมสำหรับชุดข้อมูล
	series.Format.Fill.FillType = FillTypeEx.Solid;
	series.Format.Fill.SolidFillColor.Color = Color.Green;


	//สร้างป้ายกำกับแบบกำหนดเองสำหรับแต่ละหมวดหมู่ของชุดข้อมูลใหม่

	//ป้ายกำกับแรกจะแสดงชื่อหมวดหมู่
	DataLabelEx lbl = new DataLabelEx(series);
	lbl.ShowCategoryName = true;
	lbl.Id = 0;
	series.Labels.Add(lbl);

	//แสดงชื่อชุดข้อมูลสำหรับป้ายกำกับที่สอง
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

	//บันทึกงานนำเสนอพร้อมแชート
	pres.Write(@"D:\AsposeChart.pptx");
}
```



## **New Aspose.Slides for .NET 13.x Approach**
``` csharp
//สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX file//สร้างอินสแตนซ์ของคลาส Presentation ที่แทนไฟล์ PPTX file
Presentation pres = new Presentation();

//เข้าถึงสไลด์แรก
ISlide sld = pres.Slides[0];

// เพิ่มแชาร์ทด้วยข้อมูลเริ่มต้น
IChart chart = sld.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

//ตั้งค่าชื่อแชาร์ท
//chart.ChartTitle.TextFrameForOverriding.Text = "Sample Title";
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

//ตั้งค่าชุดข้อมูลแรกให้แสดงค่า
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

//กำหนดดัชนีของชีทข้อมูลแชาร์ท
int defaultWorksheetIndex = 0;

//ดึงชีทข้อมูลแชาร์ท
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//ลบชุดข้อมูลและหมวดหมู่ที่สร้างโดยอัตโนมัติ
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
int s = chart.ChartData.Series.Count;
s = chart.ChartData.Categories.Count;

//เพิ่มชุดข้อมูลใหม่
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.Type);

//เพิ่มหมวดหมู่ใหม่
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
chart.ChartData.Categories.Add(fact.GetCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));

//รับชุดข้อมูลแชาร์ทแรก
IChartSeries series = chart.ChartData.Series[0];

//กำลังเติมข้อมูลให้ชุดข้อมูล
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

//ตั้งค่าสีเติมสำหรับชุดข้อมูล
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Red;


//รับชุดข้อมูลแชาร์ทที่สอง
series = chart.ChartData.Series[1];

//กำลังเติมข้อมูลให้ชุดข้อมูล
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 1, 2, 30));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 2, 2, 10));
series.DataPoints.AddDataPointForBarSeries(fact.GetCell(defaultWorksheetIndex, 3, 2, 60));

//ตั้งค่าสีเติมสำหรับชุดข้อมูล
series.Format.Fill.FillType = FillType.Solid;
series.Format.Fill.SolidFillColor.Color = Color.Green;


//สร้างป้ายกำกับแบบกำหนดเองสำหรับแต่ละหมวดหมู่ของชุดข้อมูลใหม่

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

//บันทึกงานนำเสนอพร้อมแชาร์ท
pres.Save("AsposeChart.pptx", SaveFormat.Pptx);
```

โปรดดูตัวอย่างโค้ดง่ายต่อไปนี้สำหรับการสร้างแผนภูมิ scatterd ตั้งแต่เริ่มต้นในงานพรีเซนเทชันโดยใช้ Aspose.Slides API รุ่นเก่าและวิธีการทำเช่นเดียวกับ API ที่รวมใหม่
## **Legacy Aspose.Slides for .NET Approach**
```c#
using (PresentationEx pres = new PresentationEx())
{
    SlideEx slide = pres.Slides[0];

    //สร้างแผนภูมิเริ่มต้น
    ChartEx chart = slide.Shapes.AddChart(ChartTypeEx.ScatterWithSmoothLines, 0, 0, 400, 400);

    //ดึงดัชนีของชีทข้อมูลแผนภูมิเริ่มต้น
    int defaultWorksheetIndex = 0;

    //เข้าถึงชีทข้อมูลแผนภูมิ
    ChartDataCellFactory fact = chart.ChartData.ChartDataCellFactory;

    //ลบชุดข้อมูลตัวอย่าง
    chart.ChartData.Series.Clear();

    //เพิ่มชุดข้อมูลใหม่
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

    //รับชุดแผนภูมิแรก
    ChartSeriesEx series = chart.ChartData.Series[0];

    //เพิ่มจุดใหม่ (1:3) ที่นี่
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 1, 1));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

    //เพิ่มจุดใหม่ (2:10)
    series.XValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 1, 2));
    series.YValues.Add(fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

    //แก้ไขประเภทของชุดข้อมูล
    series.Type = ChartTypeEx.ScatterWithStraightLinesAndMarkers;

    //เปลี่ยนเครื่องหมายของชุดแผนภูมิ
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Star;

    //รับชุดแผนภูมิที่สอง
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

    //เปลี่ยนเครื่องหมายของชุดแผนภูมิ
    series.MarkerSize = 10;
    series.MarkerSymbol = MarkerStyleTypeEx.Circle;

    pres.Write("D:\\AsposeSeriesChart.pptx");
}
```


## **New Aspose.Slides for .NET 13.x Approach**
``` csharp
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];

//สร้างแผนภูมิเริ่มต้น
IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400);

//ดึงดัชนีของชีทข้อมูลแผนภูมิเริ่มต้น
int defaultWorksheetIndex = 0;

//เข้าถึงชีทข้อมูลแผนภูมิ
IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

//ลบชุดข้อมูลตัวอย่าง
chart.ChartData.Series.Clear();

//เพิ่มชุดข้อมูลใหม่
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.Type);
chart.ChartData.Series.Add(fact.GetCell(defaultWorksheetIndex, 1, 3, "Series 2"), chart.Type);

//รับชุดแผนภูมิแรก
IChartSeries series = chart.ChartData.Series[0];

//เพิ่มจุดใหม่ (1:3) ที่นี่.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 1), fact.GetCell(defaultWorksheetIndex, 2, 2, 3));

//เพิ่มจุดใหม่ (2:10)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 2), fact.GetCell(defaultWorksheetIndex, 3, 2, 10));

//แก้ไขประเภทของชุดข้อมูล
series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

//เปลี่ยนเครื่องหมายของชุดแผนภูมิ
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Star;

//รับชุดแผนภูมิที่สอง
series = chart.ChartData.Series[1];

//เพิ่มจุดใหม่ (5:2) ที่นี่.
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 2, 3, 5), fact.GetCell(defaultWorksheetIndex, 2, 4, 2));

//เพิ่มจุดใหม่ (3:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 3, 3, 3), fact.GetCell(defaultWorksheetIndex, 3, 4, 1));

//เพิ่มจุดใหม่ (2:2)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 4, 3, 2), fact.GetCell(defaultWorksheetIndex, 4, 4, 2));

//เพิ่มจุดใหม่ (5:1)
series.DataPoints.AddDataPointForScatterSeries(fact.GetCell(defaultWorksheetIndex, 5, 3, 5), fact.GetCell(defaultWorksheetIndex, 5, 4, 1));

//เปลี่ยนเครื่องหมายของชุดแผนภูมิ
series.Marker.Size = 10;
series.Marker.Symbol = MarkerStyleType.Circle;

pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
```