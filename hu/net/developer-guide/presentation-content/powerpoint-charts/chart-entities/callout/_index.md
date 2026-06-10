---
title: .NET-ben a prezentációs diagramok felhívásainak kezelése
linktitle: Felhívás
type: docs
url: /hu/net/callout/
keywords:
- diagram felhívás
- felhívás használata
- adatcímke
- címkeformátum
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Hozzon létre és formázzon felhívásokat az Aspose.Slides for .NET-ben tömör C# kódrészletekkel, kompatibilis PPT és PPTX formátumokkal, hogy automatizálja a prezentációs munkafolyamatokat."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozzunk felhívásokkal a diagram adatcímkéihez az Aspose.Slides‑ben. Bemutatja, hogyan használjuk a `ShowLabelAsDataCallout` tulajdonságot a címkék felhívásként való megjelenítéséhez, hogyan konfiguráljuk a felhívással kapcsolatos címke‑beállításokat egy gyűrűdiagram esetén, és megjegyzi, hogy a felhívások és megjelenésük megmarad, amikor a prezentációkat PDF, HTML5, SVG vagy raszteres képformátumokra exportálják.

## **Felhívások használata**
Új **ShowLabelAsDataCallout** tulajdonság lett hozzáadva a **DataLabelFormat** osztályhoz és az **IDataLabelFormat** interfészhez, amely meghatározza, hogy a megadott diagram adatcímkéje adatfelhívásként vagy adatcímkeként jelenjen meg. Az alább látható példában beállítottuk a felhívásokat.

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



## **Felhívás beállítása gyűrűdiagramhoz**
Az Aspose.Slides for .NET támogatja a sorozat adatcímke‑felhívás alakzatának beállítását gyűrűdiagramhoz. Az alábbi minta példa látható. 

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

## **GYIK**

**Megmaradnak a felhívások, ha a prezentációt PDF, HTML5, SVG vagy képek formátumába konvertálják?**

Igen. A felhívások a diagram renderelésének részei, ezért exportáláskor a [PDF](/slides/hu/net/convert-powerpoint-to-pdf/), [HTML5](/slides/hu/net/export-to-html5/), [SVG](/slides/hu/net/render-a-slide-as-an-svg-image/) vagy a [raszteres képek](/slides/hu/net/convert-powerpoint-to-png/) formátumba a diák formázásával együtt megmaradnak.

**Működnek-e egyéni betűtípusok a felhívásokban, és megőrizhető-e a megjelenésük exportáláskor?**

Igen. Az Aspose.Slides támogatja a [betűtípusok beágyazását](/slides/hu/net/embedded-font/) a prezentációba, és szabályozza a betűtípus‑beágyazást az olyan exportok során, mint a [PDF](/slides/hu/net/convert-powerpoint-to-pdf/), ezáltal a felhívások ugyanúgy jelennek meg különböző rendszereken.