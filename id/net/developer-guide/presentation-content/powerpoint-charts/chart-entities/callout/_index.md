---
title: Kelola Callout dalam Grafik Presentasi di .NET
linktitle: Callout
type: docs
url: /id/net/callout/
keywords:
- callout grafik
- gunakan callout
- label data
- format label
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buat dan gaya callout di Aspose.Slides untuk .NET dengan contoh kode C# yang ringkas, kompatibel dengan PPT dan PPTX untuk mengotomatiskan alur kerja presentasi."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara bekerja dengan callout untuk label data grafik di Aspose.Slides. Artikel ini menunjukkan cara menggunakan properti `ShowLabelAsDataCallout` untuk menampilkan label sebagai callout, cara mengonfigurasi pengaturan label terkait callout untuk grafik donat, dan mencatat bahwa callout serta tampilannya dipertahankan saat presentasi diekspor ke format PDF, HTML5, SVG, dan gambar raster.

## **Menggunakan Callout**
Properti baru **ShowLabelAsDataCallout** telah ditambahkan ke kelas **DataLabelFormat** dan antarmuka **IDataLabelFormat**, yang menentukan apakah label data grafik yang ditentukan akan ditampilkan sebagai data callout atau sebagai label data. Pada contoh di bawah ini, kami telah mengatur Callout.

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



## **Mengatur Callout untuk Grafik Donat**
Aspose.Slides untuk .NET menyediakan dukungan untuk mengatur bentuk callout label data seri pada grafik Donat. Contoh sampel di bawah ini diberikan. 

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

## **FAQ**

**Apakah callout dipertahankan saat mengonversi presentasi ke PDF, HTML5, SVG, atau gambar?**

Ya. Callout merupakan bagian dari proses rendering grafik, sehingga saat Anda mengekspor ke [PDF](/slides/id/net/convert-powerpoint-to-pdf/), [HTML5](/slides/id/net/export-to-html5/), [SVG](/slides/id/net/render-a-slide-as-an-svg-image/), atau [gambar raster](/slides/id/net/convert-powerpoint-to-png/), mereka dipertahankan bersama dengan format slide.

**Apakah font khusus berfungsi pada callout, dan apakah tampilannya dapat dipertahankan saat ekspor?**

Ya. Aspose.Slides mendukung [menyematkan font](/slides/id/net/embedded-font/) ke dalam presentasi dan mengontrol penyematan font selama ekspor seperti [PDF](/slides/id/net/convert-powerpoint-to-pdf/), memastikan callout terlihat sama di berbagai sistem.