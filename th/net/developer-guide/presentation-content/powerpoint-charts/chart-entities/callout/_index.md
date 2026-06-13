---
title: จัดการคอลเอาท์ในแผนภูมิการพรีเซนเทชั่นใน .NET
linktitle: คอลเอาท์
type: docs
url: /th/net/callout/
keywords:
- คอลเอาท์แผนภูมิ
- ใช้คอลเอาท์
- ป้ายข้อมูล
- รูปแบบป้าย
- PowerPoint
- พรีเซนเทชั่น
- .NET
- C#
- Aspose.Slides
description: "สร้างและตกแต่งคอลเอาท์ใน Aspose.Slides for .NET ด้วยตัวอย่างโค้ด C# ที่กระชับ รองรับ PPT และ PPTX เพื่ออัตโนมัติขั้นตอนการทำพรีเซนเทชั่น"
---
## **ภาพรวม**

บทความนี้อธิบายวิธีการทำงานกับ Callout สำหรับป้ายข้อมูลแผนภูมิใน Aspose.Slides แสดงวิธีใช้คุณสมบัติ `ShowLabelAsDataCallout` เพื่อแสดงป้ายเป็น Callout วิธีกำหนดค่าการตั้งค่าป้ายที่เกี่ยวกับ Callout สำหรับแผนภูมิโดนัต และกล่าวว่าการแสดงผลของ Callout จะถูกเก็บไว้เมื่อทำการส่งออกงานนำเสนอเป็น PDF, HTML5, SVG และรูปแบบภาพแบบราสเตอร์

## **การใช้ Callout**
คุณสมบัติใหม่ **ShowLabelAsDataCallout** ได้ถูกเพิ่มเข้าไปในคลาส **DataLabelFormat** และอินเทอร์เฟซ **IDataLabelFormat** ซึ่งกำหนดว่าป้ายข้อมูลของแผนภูมิที่ระบุจะถูกแสดงเป็น Callout หรือเป็นป้ายข้อมูล ในตัวอย่างด้านล่าง เราได้ตั้งค่า Callout แล้ว

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;
    chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;
    presentation.Save("DisplayChartLabels_out.pptx", SaveFormat.Pptx);
}
```

## **ตั้ง Callout สำหรับแผนภูมิโดนัต**
Aspose.Slides for .NET มีการสนับสนุนการตั้งรูปร่าง Callout ของป้ายข้อมูลชุดสำหรับแผนภูมิโดนัต ตัวอย่างโค้ดต่อไปนี้แสดงวิธีการ

```c#
Presentation pres = new Presentation("testc.pptx");
ISlide slide = pres.Slides[0];
IChart chart = slide.Shapes.AddChart(ChartType.Doughnut, 10, 10, 500, 500, false);
IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
chart.HasLegend = false;
int seriesIndex = 0;
while (seriesIndex < 15)
{
	IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, seriesIndex + 1, "SERIES " + seriesIndex), chart.Type);
	series.Explosion = 0;
	series.ParentSeriesGroup.DoughnutHoleSize = (byte)20;
	series.ParentSeriesGroup.FirstSliceAngle = 351;
	seriesIndex++;
}
int categoryIndex = 0;
while (categoryIndex < 15)
{
	chart.ChartData.Categories.Add(workBook.GetCell(0, categoryIndex + 1, 0, "CATEGORY " + categoryIndex));
	int i = 0;
	while (i < chart.ChartData.Series.Count)
	{
		IChartSeries iCS = chart.ChartData.Series[i];
		IChartDataPoint dataPoint = iCS.DataPoints.AddDataPointForDoughnutSeries(workBook.GetCell(0, categoryIndex + 1, i + 1, 1));
		dataPoint.Format.Fill.FillType = FillType.Solid;
		dataPoint.Format.Line.FillFormat.FillType = FillType.Solid;
		dataPoint.Format.Line.FillFormat.SolidFillColor.Color = Color.White;
		dataPoint.Format.Line.Width = 1;
		dataPoint.Format.Line.Style = LineStyle.Single;
		dataPoint.Format.Line.DashStyle = LineDashStyle.Solid;
		if (i == chart.ChartData.Series.Count - 1)
		{
			IDataLabel lbl = dataPoint.Label;
			lbl.TextFormat.TextBlockFormat.AutofitType = TextAutofitType.Shape;
			lbl.DataLabelFormat.TextFormat.PortionFormat.FontBold = NullableBool.True;
			lbl.DataLabelFormat.TextFormat.PortionFormat.LatinFont = new FontData("DINPro-Bold");
			lbl.DataLabelFormat.TextFormat.PortionFormat.FontHeight = 12;
			lbl.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
			lbl.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.LightGray;
			lbl.DataLabelFormat.Format.Line.FillFormat.SolidFillColor.Color = Color.White;
			lbl.DataLabelFormat.ShowValue = false;
			lbl.DataLabelFormat.ShowCategoryName = true;
			lbl.DataLabelFormat.ShowSeriesName = false;
			//lbl.DataLabelFormat.ShowLabelAsDataCallout = true;
			lbl.DataLabelFormat.ShowLeaderLines = true;
			lbl.DataLabelFormat.ShowLabelAsDataCallout = false;
			chart.ValidateChartLayout();
			lbl.AsILayoutable.X = (float)lbl.AsILayoutable.X + (float)0.5;
			lbl.AsILayoutable.Y = (float)lbl.AsILayoutable.Y + (float)0.5;
		}
		i++;
	}
	categoryIndex++;
}
pres.Save("chart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **คำถามที่พบบ่อย**

**Callout จะถูกเก็บไว้เมื่อแปลงงานพรีเซนเทชั่นเป็น PDF, HTML5, SVG หรือรูปภาพหรือไม่?**

ใช่. Callout เป็นส่วนหนึ่งของการแสดงผลแผนภูมิ ดังนั้นเมื่อคุณส่งออกเป็น[PDF](/slides/th/net/convert-powerpoint-to-pdf/),[HTML5](/slides/th/net/export-to-html5/),[SVG](/slides/th/net/render-a-slide-as-an-svg-image/)หรือ[ภาพราสเตอร์](/slides/th/net/convert-powerpoint-to-png/), Callout จะถูกเก็บไว้พร้อมกับรูปแบบของสไลด์

**ฟอนต์ที่กำหนดเองทำงานใน Callout หรือไม่ และการแสดงผลของมันสามารถถูกเก็บไว้เมื่อส่งออกหรือไม่?**

ใช่. Aspose.Slides รองรับ[embedding fonts](/slides/th/net/embedded-font/)ในงานพรีเซนเทชั่นและควบคุมการฝังฟอนต์ในระหว่างการส่งออกเช่น[PDF](/slides/th/net/convert-powerpoint-to-pdf/), ทำให้ Callout มีลักษณะเดียวกันบนระบบต่าง ๆ