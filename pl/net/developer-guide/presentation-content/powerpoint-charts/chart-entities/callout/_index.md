---
title: Zarządzanie wyróżnieniami w wykresach prezentacji w .NET
linktitle: Wyróżnienie
type: docs
url: /pl/net/callout/
keywords:
- wyróżnienie wykresu
- użycie wyróżnienia
- etykieta danych
- format etykiety
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Twórz i stylizuj wyróżnienia w Aspose.Slides dla .NET przy użyciu zwięzłych przykładów kodu C#, kompatybilnych z PPT i PPTX, aby automatyzować przepływy pracy prezentacji."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z wyróżnieniami dla etykiet danych wykresu w Aspose.Slides. Pokazuje, jak używać właściwości `ShowLabelAsDataCallout`, aby wyświetlać etykiety jako wyróżnienia, jak konfigurować ustawienia etykiet związane z wyróżnieniami dla wykresu pierścieniowego oraz zauważa, że wyróżnienia i ich wygląd są zachowywane podczas eksportu prezentacji do formatów PDF, HTML5, SVG i rastrów.

## **Używanie wyróżnień**
Nową właściwość **ShowLabelAsDataCallout** dodano do klasy **DataLabelFormat** i interfejsu **IDataLabelFormat**, która określa, czy etykieta danych wybranego wykresu będzie wyświetlana jako wyróżnienie, czy jako etykieta danych. W poniższym przykładzie ustawiliśmy wyróżnienia.

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



## **Ustaw wyróżnienie dla wykresu pierścieniowego**
Aspose.Slides for .NET zapewnia wsparcie dla ustawiania kształtu wyróżnienia etykiety danych serii dla wykresu pierścieniowego. Poniżej przedstawiono przykładowy kod.

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

**Czy wyróżnienia są zachowywane przy konwertowaniu prezentacji do PDF, HTML5, SVG lub obrazów?**

Tak. Wyróżnienia są częścią renderowania wykresu, więc przy eksporcie do [PDF](/slides/pl/net/convert-powerpoint-to-pdf/), [HTML5](/slides/pl/net/export-to-html5/), [SVG](/slides/pl/net/render-a-slide-as-an-svg-image/) lub [raster images](/slides/pl/net/convert-powerpoint-to-png/), są zachowywane razem z formatowaniem slajdu.

**Czy niestandardowe czcionki działają w wyróżnieniach i czy ich wygląd może być zachowany przy eksporcie?**

Tak. Aspose.Slides obsługuje [embedding fonts](/slides/pl/net/embedded-font/) w prezentacji i kontroluje osadzanie czcionek podczas eksportu, takiego jak [PDF](/slides/pl/net/convert-powerpoint-to-pdf/), zapewniając, że wyróżnienia wyglądają tak samo na różnych systemach.