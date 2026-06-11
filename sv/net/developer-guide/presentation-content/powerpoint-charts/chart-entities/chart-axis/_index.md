---
title: Anpassa diagramaxlar i presentationer i .NET
linktitle: Diagramaxel
type: docs
url: /sv/net/chart-axis/
keywords:
- diagramaxel
- vertikal axel
- horisontell axel
- anpassa axel
- manipulera axel
- hantera axel
- axelegenskaper
- maxvärde
- minvärde
- axellinje
- datumformat
- axeltitel
- axelposition
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck hur du använder Aspose.Slides för .NET för att anpassa diagramaxlar i PowerPoint-presentationer för rapporter och visualiseringar."
---
## **Översikt**

Den här artikeln förklarar hur du anpassar diagramaxlar i Aspose.Slides. Den visar hur du får faktiska axelvärden, byter data mellan axlar, döljer den vertikala eller horisontella axeln för linjediagram, ändrar kategoriaxeltyp, anger datumformatet för kategoriaxelvärden, roterar en axeltitel, ställer in axelpositionen och visar en enhetsetikett på värdeaxeln.

## **Hämta maxvärdena på den vertikala axeln i diagram**
Aspose.Slides för .NET låter dig hämta minsta och största värdena på en vertikal axel. Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
1. Öppna den första bilden.
1. Lägg till ett diagram med standarddata.
1. Hämta det faktiska maximivärdet på axeln.
1. Hämta det faktiska minimivärdet på axeln.
1. Hämta den faktiska huvudenheten för axeln.
1. Hämta den faktiska delenheten för axeln.
1. Hämta den faktiska skalan för huvudenheten på axeln.
1. Hämta den faktiska skalan för delenheten på axeln.

Den här exempel koden — en implementering av stegen ovan — visar hur du hämtar de nödvändiga värdena i C#:

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// Sparar presentationen
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **Byt data mellan axlar**
Aspose.Slides låter dig snabbt byta data mellan axlar — data som representeras på den vertikala axeln (y-axeln) flyttas till den horisontella axeln (x-axeln) och vice versa. 

Denna C#-kod visar hur du utför datautbytesuppgiften mellan axlar i ett diagram:

```c#
// Skapar tom presentation
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Byter rader och kolumner
	chart.ChartData.SwitchRowColumn();
		   
	// Sparar presentationen
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **Inaktivera den vertikala axeln för linjediagram**

Denna C#-kod visar hur du döljer den vertikala axeln för ett linjediagram:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Inaktivera den horisontella axeln för linjediagram**

Denna kod visar hur du döljer den horisontella axeln för ett linjediagram:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Ändra en kategoriaxel**

Med egenskapen **CategoryAxisType** kan du ange din föredragna kategoriaxeltyp (**date** eller **text**). Den här C#-koden demonstrerar operationen: 

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

## **Ange datumformatet för kategoriaxelvärden**
Aspose.Slides för .NET låter dig ange datumformatet för ett kategoriaxelvärde. Operationen demonstreras i denna C#-kod:

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

## **Ange en rotationsvinkel för en diagramaxeltitel**
Aspose.Slides för .NET låter dig ange rotationsvinkeln för en diagramaxeltitel. Denna C#-kod demonstrerar operationen:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Ange axelpositionen på en kategori- eller värdeaxel**
Aspose.Slides för .NET låter dig ange positionsaxeln i en kategori- eller värdeaxel. Denna C#-kod visar hur du utför uppgiften:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **Aktivera visning av enhetsetikett på diagrammets värdeaxel**
Aspose.Slides för .NET låter dig konfigurera ett diagram så att det visar en enhetsetikett på dess värdeaxel. Denna C#-kod demonstrerar operationen:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **Vanliga frågor**

**Hur ställer jag in värdet där en axel korsar den andra (axelkorsning)?**

Axlar erbjuder en [crossing setting](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/axis/crosstype/): du kan välja att korsa vid noll, vid den maximala kategori-/värdet, eller vid ett specifikt numeriskt värde. Detta är användbart för att förflytta X-axeln upp eller ner eller för att framhäva en referenslinje.

**Hur kan jag placera tick-etiketter i förhållande till axeln (vid sidan, utanför, inuti)?**

Ställ in [label position](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/axis/majortickmark/) till "cross", "outside" eller "inside". Detta påverkar läsbarheten och hjälper till att spara utrymme, särskilt i små diagram.