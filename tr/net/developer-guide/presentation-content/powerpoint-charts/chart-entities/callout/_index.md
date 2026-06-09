---
title: .NET'te Sunum Grafiklerinde Çağrı Kutularını Yönetme
linktitle: Çağrı Kutusu
type: docs
url: /tr/net/callout/
keywords:
- grafik çağrı kutusu
- çağrı kutusu kullanımı
- veri etiketi
- etiket biçimi
- PowerPoint
- sunum
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET içinde çağrı kutularını oluşturun ve biçimlendirin, PPT ve PPTX ile uyumlu, sunum iş akışlarını otomatikleştiren özlü C# kod örnekleriyle."
---
## **Genel Bakış**

Bu makale, Aspose.Slides'ta grafik veri etiketleri için çağrı kutularıyla nasıl çalışılacağını açıklar. `ShowLabelAsDataCallout` özelliğinin etiketleri çağrı kutusu olarak görüntülemek için nasıl kullanılacağını, bir halka grafik için çağrı kutusu ile ilgili etiket ayarlarının nasıl yapılandırılacağını ve çağrı kutularının ve görünümünün sunumlar PDF, HTML5, SVG ve raster görüntü formatlarına dışa aktarıldığında korunduğunu gösterir.

## **Çağrı Kutularını Kullanma**

Yeni **ShowLabelAsDataCallout** özelliği **DataLabelFormat** sınıfına ve **IDataLabelFormat** arabirimine eklenmiştir; bu, belirtilen grafiğin veri etiketinin veri çağrısı olarak mı yoksa veri etiketi olarak mı görüntüleneceğini belirler. Aşağıdaki örnekte, Çağrı Kutularını ayarladık.

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

## **Halka Grafik İçin Çağrı Kutusu Ayarlama**

Aspose.Slides for .NET, bir halka grafik için seri veri etiketi çağrı kutusu şeklini ayarlama desteği sunar. Aşağıda örnek bir örnek verilmiştir.

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

## **SSS**

**Sunumu PDF, HTML5, SVG veya görsellere dönüştürürken çağrı kutuları korunur mu?**

**Evet.** Çağrı kutuları grafik oluşturmanın bir parçasıdır; bu nedenle dışa aktarırken [PDF](/slides/tr/net/convert-powerpoint-to-pdf/), [HTML5](/slides/tr/net/export-to-html5/), [SVG](/slides/tr/net/render-a-slide-as-an-svg-image/) veya [rastr görüntüler](/slides/tr/net/convert-powerpoint-to-png/) formatlarına, slaytın biçimlendirmesiyle birlikte korunur.

**Özel fontlar çağrı kutularında çalışır mı ve görünüşleri dışa aktarımda korunabilir mi?**

**Evet.** Aspose.Slides, sunuma [fontları gömmeyi](/slides/tr/net/embedded-font/) destekler ve [PDF](/slides/tr/net/convert-powerpoint-to-pdf/) gibi dışa aktarımlar sırasında font yerleştirmeyi kontrol eder, böylece çağrı kutuları farklı sistemlerde aynı görünür.