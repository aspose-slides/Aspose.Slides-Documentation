---
title: Управление выносами в диаграммах презентаций в .NET
linktitle: Вынос
type: docs
url: /ru/net/callout/
keywords:
- вынос диаграммы
- использовать вынос
- метка данных
- формат метки
- PowerPoint
- презентация
- .NET
- C#
- Aspose.Slides
description: "Создавайте и оформляйте выносы в Aspose.Slides для .NET с помощью лаконичных примеров кода на C#, совместимых с PPT и PPTX, для автоматизации рабочих процессов презентаций."
---

## **Использование выносов**
Новый свойство **ShowLabelAsDataCallout** добавлено в класс **DataLabelFormat** и интерфейс **IDataLabelFormat**, которое определяет, будет ли метка данных указанной диаграммы отображаться как вынос или как метка данных. В приведённом ниже примере мы настроили выноски.
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


## **Настройка выноски для кольцевой диаграммы**
Aspose.Slides для .NET предоставляет возможность задавать форму выноски метки данных серии для кольцевой диаграммы. Ниже приведён пример.
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

**Сохраняются ли выноски при конвертации презентации в PDF, HTML5, SVG или изображения?**

Да. Выноски являются частью отрисовки диаграммы, поэтому при экспорте в [PDF](/slides/ru/net/convert-powerpoint-to-pdf/), [HTML5](/slides/ru/net/export-to-html5/), [SVG](/slides/ru/net/render-a-slide-as-an-svg-image/), или [raster images](/slides/ru/net/convert-powerpoint-to-png/), они сохраняются вместе с форматированием слайда.

**Работают ли пользовательские шрифты в выносах, и можно ли сохранить их внешний вид при экспорте?**

Да. Aspose.Slides поддерживает [embedding fonts](/slides/ru/net/embedded-font/) в презентацию и контролирует встраивание шрифтов при экспорте, например в [PDF](/slides/ru/net/convert-powerpoint-to-pdf/), обеспечивая одинаковый внешний вид выносов на разных системах.