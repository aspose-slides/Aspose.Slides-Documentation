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
description: "Vytvářejte a přizpůsobujte koláčové grafy v .NET s Aspose.Slides. Konfigurujte sekundární grafy, zobrazujte popisky dat a aplikujte automatické barvy výsečí v PowerPointu."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s koláčovými grafy v Aspose.Slides. Ukazuje, jak nakonfigurovat možnosti sekundárního grafu pro grafy Pie of Pie a Bar of Pie a jak povolit automatické barvení výsečů pro standardní koláčový graf.

Příklady se zaměřují na úkoly přizpůsobení grafu, jako je přidání grafu na snímek, úprava nastavení sérií a popisků, nahrazení výchozích dat grafu vlastními kategoriemi a hodnotami a uložení aktualizované prezentace.

## **Možnosti sekundárního grafu pro grafy Pie of Pie a Bar of Pie**

Aspose.Slides pro .NET podporuje možnosti sekundárního grafu pro grafy Pie of Pie a Bar of Pie. Tyto možnosti řídí velikost sekundárního grafu a způsob, jakým jsou datové body rozděleny mezi oba grafy.

Následující příklad vytvoří graf Pie of Pie v nové prezentaci a zobrazí hodnoty datových bodů jako popisky. Vlastnost [SecondPieSize](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/secondpiesize/) nastaví velikost sekundárního grafu na 149 % hlavního grafu. [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitby/) vybírá rozdělení založené na procentech a [PieSplitPosition](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/piesplitposition/) nastavuje práh na 53 %.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 500, 400);
var series = chart.ChartData.Series[0];

// Display values and configure the secondary plot.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.SecondPieSize = 149;
seriesGroup.PieSplitBy = PieSplitType.ByPercentage;
seriesGroup.PieSplitPosition = 53;

presentation.Save("pie_of_pie.pptx", SaveFormat.Pptx);
```

### **Vybrat kategorie pro sekundární graf**

Použijte vlastní rozdělení, pokud chcete seskupit konkrétní kategorie v sekundárním grafu bez ohledu na jejich procentuální hodnoty. Například prodejní zpráva může zobrazovat Online a Events společně, aby si čtenáři mohli porovnat tyto dva kanály, i když představují 35 % a 10 % celkových prodejů.

Nastavte [PieSplitBy](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitby/) na [PieSplitType.Custom](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplittype/) a vyberte body pomocí [PieSplitCustomPoints](https://reference.aspose.com/slides/net/aspose.slides.charts/chartseriesgroup/piesplitcustompoints/). Metoda [Add](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/add/) kolekce přijímá buď nulově indexovaný index v sérii, nebo objekt datového bodu. V tomto příkladu index 1 vybírá Online a bod s indexem 3 vybírá Events. Partners je také dočasně přidán a poté vyloučen pomocí [Remove](https://reference.aspose.com/slides/net/aspose.slides.charts/piesplitcustompointcollection/remove/).

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.PieOfPie, 50, 50, 600, 200);

// Nahraďte výchozí data prodeji podle kanálu.
var workbook = chart.ChartData.ChartDataWorkbook;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "Retail", "Online", "Partners", "Events" };
var values = new[] { 40, 35, 15, 10 };
var seriesNameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(0, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(0, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

series.Labels.DefaultDataLabelFormat.ShowValue = true;
var seriesGroup = series.ParentSeriesGroup;
seriesGroup.PieSplitBy = PieSplitType.Custom;
seriesGroup.IsColorVaried = true;

// Vyberte Online pomocí jeho nulově založeného indexu a Events pomocí objektu datového bodu.
seriesGroup.PieSplitCustomPoints.Add(1);
seriesGroup.PieSplitCustomPoints.Add(series.DataPoints[3]);

// Vylučte Partners ze výběru bez smazání jeho zdrojových dat.
seriesGroup.PieSplitCustomPoints.Add(2);
seriesGroup.PieSplitCustomPoints.Remove(series.DataPoints[2]);

presentation.Save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
```

Online (35) a Events (10) se zobrazují jako samostatné výseče v sekundárním grafu. V hlavním grafu jsou představovány jednou spojenou výsečí s hodnotou 45, spolu s Retail (40) a Partners (15). Odebrání Partners z vlastní volby jej ponechá v hlavním grafu; neodstraní kategorii ani její hodnotu ze zdrojových dat grafu.

Následující obrázek ukazuje uloženou prezentaci v PowerPointu:

![Graf Pie of Pie s Online a Events v sekundárním grafu a jejich spojenou hodnotou 45 v hlavním grafu](pie_of_pie_custom.png)

## **Nastavit automatické barvy výsečů koláčového grafu**

Aspose.Slides pro .NET může automaticky přiřadit různé barvy výsečím koláčového grafu. Následující příklad vytvoří koláčový graf se středovým nadpisem a nahradí výchozí data třemi čtvrtletními kategoriemi a jejich hodnotami. Vlastnost [ShowValue](https://reference.aspose.com/slides/net/aspose.slides.charts/idatalabelformat/showvalue/) zobrazí hodnoty 20, 50 a 30 jako popisky, zatímco [IsColorVaried](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseriesgroup/iscolorvaried/) umožňuje odlišnou barvu pro každou výseč.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.Pie, 100, 100, 400, 400);

// Přidejte středový název grafu.
chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
chart.ChartTitle.Height = 20;
chart.HasTitle = true;

// Nahraďte výchozí data pomocí prvního listu.
var workbook = chart.ChartData.ChartDataWorkbook;
var worksheetIndex = 0;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var categoryNames = new[] { "First Qtr", "2nd Qtr", "3rd Qtr" };
var values = new[] { 20, 50, 30 };
var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 1, "Series 1");
var series = chart.ChartData.Series.Add(seriesNameCell, chart.Type);

for (var i = 0; i < categoryNames.Length; i++)
{
    var categoryCell = workbook.GetCell(worksheetIndex, i + 1, 0, categoryNames[i]);
    chart.ChartData.Categories.Add(categoryCell);

    var valueCell = workbook.GetCell(worksheetIndex, i + 1, 1, values[i]);
    series.DataPoints.AddDataPointForPieSeries(valueCell);
}

// Zobrazte hodnoty a přiřaďte výsečím různé barvy.
series.Labels.DefaultDataLabelFormat.ShowValue = true;
series.ParentSeriesGroup.IsColorVaried = true;

presentation.Save("pie.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Jsou podporovány varianty Pie of Pie a Bar of Pie?**

Ano, knihovna [supports](https://reference.aspose.com/slides/net/aspose.slides.charts/charttype/) sekundární graf pro koláčové grafy, včetně typů Pie of Pie a Bar of Pie.

**Mohu exportovat pouze graf jako obrázek (například PNG)?**

Ano, můžete [export the chart itself as an image](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) (například PNG) bez exportu celé prezentace.