---
title: Přizpůsobení os grafu v prezentacích v .NET
linktitle: Osa grafu
type: docs
url: /cs/net/chart-axis/
keywords:
- osa grafu
- svislá osa
- vodorovná osa
- přizpůsobení osy
- manipulace s osou
- správa osy
- vlastnosti osy
- maximální hodnota
- minimální hodnota
- čára osy
- formát data
- název osy
- pozice osy
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte, jak použít Aspose.Slides pro .NET k přizpůsobení os grafu v prezentacích PowerPoint pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu v Aspose.Slides. Ukazuje, jak získat skutečné hodnoty os, prohodit data mezi osami, skrýt svislou nebo vodorovnou osu u čárových grafů, změnit typ osy kategorií, nastavit formát data pro hodnoty osy kategorií, otočit název osy, nastavit pozici osy a zobrazit popisek jednotky na ose hodnot.

## **Získání maximálních hodnot na svislé ose v grafech**
Aspose.Slides pro .NET vám umožňuje získat minimální a maximální hodnoty na svislé ose. Proveďte následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Získejte skutečnou maximální hodnotu na ose.
1. Získejte skutečnou minimální hodnotu na ose.
1. Získejte skutečnou hlavní jednotku osy.
1. Získejte skutečnou vedlejší jednotku osy.
1. Získejte skutečnou měřítko hlavní jednotky osy.
1. Získejte skutečnou měřítko vedlejší jednotky osy.

Tento ukázkový kód – implementace výše uvedených kroků – vám ukazuje, jak získat požadované hodnoty v jazyce C#:

```c#
using (Presentation pres = new Presentation())
{
	Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.Area, 100, 100, 500, 350);
	chart.ValidateChartLayout();

	double maxValue = chart.Axes.VerticalAxis.ActualMaxValue;
	double minValue = chart.Axes.VerticalAxis.ActualMinValue;

	double majorUnit = chart.Axes.HorizontalAxis.ActualMajorUnit;
	double minorUnit = chart.Axes.HorizontalAxis.ActualMinorUnit;
	
	// Uloží prezentaci
	presentation.Save("ErrorBars_out.pptx", SaveFormat.Pptx);
}
```

## **Prohození dat mezi osami**
Aspose.Slides vám umožňuje rychle prohodit data mezi osami – data zobrazená na svislé ose (y‑osa) se přesunou na vodorovnou osu (x‑osa) a naopak.

Tento C# kód vám ukazuje, jak provést úkol prohození dat mezi osami v grafu:

```c#
 // Vytvoří prázdnou prezentaci
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 400, 300);

	//Přepne řádky a sloupce
		   
	 // Uloží prezentaci
	 pres.Save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
 }
```

## **Zakázat svislou osu pro čárové grafy**

Tento C# kód vám ukazuje, jak skrýt svislou osu u čárového grafu:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.VerticalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Zakázat vodorovnou osu pro čárové grafy**

Tento kód vám ukazuje, jak skrýt vodorovnou osu u čárového grafu:

```c#
using (Presentation pres = new Presentation())
{
    IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Line, 100, 100, 400, 300);
    chart.Axes.HorizontalAxis.IsVisible = false; 
    
    pres.Save("chart.pptx", SaveFormat.Pptx);
}
```

## **Změna osy kategorií**

Pomocí vlastnosti **CategoryAxisType** můžete určit preferovaný typ osy kategorií (**date** nebo **text**). Tento C# kód demonstruje operaci:

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

## **Nastavení formátu data pro hodnoty osy kategorií**
Aspose.Slides pro .NET vám umožňuje nastavit formát data pro hodnotu osy kategorií. Operace je demonstrována v tomto C# kódu:

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

## **Nastavení úhlu otáčení názvu osy grafu**
Aspose.Slides pro .NET vám umožňuje nastavit úhel otáčení názvu osy grafu. Tento C# kód demonstruje operaci:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.HasTitle = true;
             chart.Axes.VerticalAxis.Title.TextFormat.TextBlockFormat.RotationAngle = 90;

	pres.Save("test.pptx", SaveFormat.Pptx);
}
```

## **Nastavení pozice osy na ose kategorií nebo hodnot**
Aspose.Slides pro .NET vám umožňuje nastavit pozici osy v ose kategorií nebo hodnot. Tento C# kód ukazuje, jak úkol provést:

```c#
using (Presentation pres = new Presentation())
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.HorizontalAxis.AxisBetweenCategories = true;

	pres.Save("AsposeScatterChart.pptx", SaveFormat.Pptx);
}
```

## **Povolení zobrazování popisku jednotky na ose hodnot grafu**
Aspose.Slides pro .NET vám umožňuje nakonfigurovat graf tak, aby zobrazoval popisek jednotky na své ose hodnot. Tento C# kód demonstruje operaci:

```c#
using (Presentation pres = new Presentation(dataDir+"Test.pptx"))
{
	IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
	chart.Axes.VerticalAxis.DisplayUnit = DisplayUnitType.Millions;
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Jak nastavit hodnotu, při které se jedna osa protíná s druhou (průsečík os)?**

Osy poskytují [nastavení průsečíku](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/axis/crosstype/): můžete zvolit průsečík v nule, na maximální kategorii/hodnotě nebo na konkrétní číselné hodnotě. To je užitečné pro posunutí osy X nahoru nebo dolů či pro zdůraznění referenční čáry.

**Jak mohu umístit popisky značek relativně k ose (vedle, venku, uvnitř)?**

Nastavte [pozici popisku](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/axis/majortickmark/) na „cross“, „outside“ nebo „inside“. Toto ovlivňuje čitelnost a pomáhá šetřit místo, zejména u malých grafů.