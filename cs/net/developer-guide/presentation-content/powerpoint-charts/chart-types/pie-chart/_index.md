---
title: Přizpůsobení koláčových grafů v prezentacích v .NET
linktitle: Koláčový graf
type: docs
url: /cs/net/pie-chart/
keywords:
- koláčový graf
- správa grafu
- přizpůsobení grafu
- možnosti grafu
- nastavení grafu
- možnosti vykreslení
- barva výseče
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se vytvářet a přizpůsobovat koláčové grafy v .NET pomocí Aspose.Slides, exportovatelné do PowerPointu, a během několik vteřin vylepšit vyprávění vašich dat."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s koláčovými grafy v Aspose.Slides. Ukazuje, jak nastavit možnosti sekundárního vykreslení pro grafy Pie of Pie a Bar of Pie a jak povolit automatické barevné odlíšení výsečů pro standardní koláčový graf.

Příklady se zaměřují na praktické kroky přizpůsobení grafu, jako je přidání grafu na snímek, úprava nastavení řad a štítků, nahrazení výchozích dat grafu vlastními kategoriemi a hodnotami a uložení aktualizované prezentace.

## **Možnosti sekundárního vykreslení pro grafy Pie of Pie a Bar of Pie**
Aspose.Slides pro .NET nyní podporuje možnosti sekundárního vykreslení pro grafy Pie of Pie nebo Bar of Pie. V tomto tématu si ukážeme na příkladu, jak tyto možnosti specifikovat pomocí Aspose.Slides. Pro zadání vlastností postupujte podle níže uvedených kroků:

1. Instanciovat objekt třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
1. Přidejte graf na snímek.
1. Zadejte možnosti sekundárního vykreslení grafu.
1. Uložte prezentaci na disk.

V níže uvedeném příkladu jsme nastavili různé vlastnosti grafu Pie of Pie.

```c#
// Vytvořte instanci třídy Presentation
Presentation presentation = new Presentation();

// Přidejte graf na snímek
IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
     
// Nastavte různé vlastnosti
chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
chart.ChartData.Series[0].ParentSeriesGroup.SecondPieSize = 149;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitBy = Aspose.Slides.Charts.PieSplitType.ByPercentage;
chart.ChartData.Series[0].ParentSeriesGroup.PieSplitPosition = 53;

// Uložte prezentaci na disk
presentation.Save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
```




## **Nastavte automatické barvy výsečí koláčového grafu**
Aspose.Slides pro .NET poskytuje jednoduché rozhraní API pro nastavení automatických barev výsečí koláčového grafu. Ukázkový kód aplikuje výše uvedená nastavení.

1. Vytvořte instanci třídy Presentation.
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Nastavte titulek grafu.
1. Nastavte první řadu, aby zobrazovala hodnoty.
1. Nastavte index listu s daty grafu.
1. Získání listu s daty grafu.
1. Odstraňte výchozí generované řady a kategorie.
1. Přidejte nové kategorie.
1. Přidejte nové řady.

Uložte upravenou prezentaci do souboru PPTX.

```c#
// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
using (Presentation presentation = new Presentation())
{
	// Vytvořte instanci třídy Presentation, která představuje soubor PPTX
	Presentation presentation = new Presentation();

	// Získejte první snímek
	ISlide slides = presentation.Slides[0];

	// Přidejte graf s výchozími daty
	IChart chart = slides.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

	// Nastavení titulku grafu
	chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
	chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
	chart.ChartTitle.Height = 20;
	chart.HasTitle = true;

	// Nastavte první řadu, aby zobrazovala hodnoty
	chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

	// Nastavení indexu listu s daty grafu
	int defaultWorksheetIndex = 0;

	// Získání listu s daty grafu
	IChartDataWorkbook fact = chart.ChartData.ChartDataWorkbook;

	// Odstraňte výchozí generované řady a kategorie
	chart.ChartData.Series.Clear();
	chart.ChartData.Categories.Clear();

	// Přidání nových kategorií
	chart.ChartData.Categories.Add(fact.GetCell(0, 1, 0, "First Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 2, 0, "2nd Qtr"));
	chart.ChartData.Categories.Add(fact.GetCell(0, 3, 0, "3rd Qtr"));

	// Přidání nové řady
	IChartSeries series = chart.ChartData.Series.Add(fact.GetCell(0, 0, 1, "Series 1"), chart.Type);

	// Nyní naplňujeme data řady
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 1, 1, 20));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 2, 1, 50));
	series.DataPoints.AddDataPointForPieSeries(fact.GetCell(defaultWorksheetIndex, 3, 1, 30));

	series.ParentSeriesGroup.IsColorVaried = true;
	presentation.Save("C:\\Aspose Data\\Pie.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**Jsou podporovány varianty „Pie of Pie“ a „Bar of Pie“?**

Ano, knihovna [podporuje](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/charttype/) sekundární vykreslení pro koláčové grafy, včetně typů „Pie of Pie“ a „Bar of Pie“.

**Mohu exportovat jen graf jako obrázek (např. PNG)?**

Ano, můžete [exportovat samotný graf jako obrázek](https://reference.aspose.com/slides/cs/net/aspose.slides/shape/getimage/) (např. PNG) bez celé prezentace.