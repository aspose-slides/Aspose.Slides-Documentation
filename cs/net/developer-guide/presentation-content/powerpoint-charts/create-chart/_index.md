---
title: Vytvoření nebo aktualizace grafů PowerPoint prezentací v .NET
linktitle: Vytvořit nebo aktualizovat grafy
type: docs
weight: 10
url: /cs/net/create-chart/
keywords:
- přidat graf
- vytvořit graf
- upravit graf
- změnit graf
- aktualizovat graf
- rozptýlený graf
- koláčový graf
- čárový graf
- stromový mapový graf
- akciový graf
- krabicový a vousatý graf
- trychytový graf
- sluneční graf
- histogramový graf
- radiální graf
- vícekategoriový graf
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte grafy v PowerPoint prezentacích pomocí Aspose.Slides pro .NET. Přidávejte, formátujte a upravujte grafy s praktickými příklady kódu v C#."
---
## **Přehled**

Tento článek poskytuje kompletní průvodce, jak vytvářet a přizpůsobovat grafy pomocí Aspose.Slides pro .NET. Naučíte se, jak programově přidat graf do snímku, naplnit jej daty a použít různé možnosti formátování tak, aby odpovídaly vašim konkrétním požadavkům na design. V průběhu článku podrobné ukázky kódu ilustrují každý krok, od inicializace prezentace a objektu grafu po konfiguraci sérií, os a legend. Dodržením tohoto návodu získáte pevné pochopení toho, jak integrovat dynamické generování grafů do vašich .NET aplikací a zjednodušit proces vytváření prezentací založených na datech.

## **Vytvoření grafu**

Grafy pomáhají lidem rychle vizualizovat data a získat postřehy, které nemusí být okamžitě patrné z tabulky nebo tabulkového procesoru.

**Proč vytvářet grafy?**

Pomocí grafů můžete:

* agregovat, zhutnit nebo shrnout velké množství dat na jediném snímku prezentace;
* odhalit vzory a trendy v datech;
* odhadnout směr a dynamiku dat v čase nebo vzhledem k určité měrné jednotce;
* odhalit odlehlé hodnoty, odchylky, chyby a nesmyslná data;
* komunikovat nebo představovat složitá data.

V PowerPointu můžete grafy vytvořit pomocí funkce *Insert*, která poskytuje šablony pro návrh mnoha typů grafů. Pomocí Aspose.Slides můžete vytvářet jak běžné grafy (založené na populárních typech), tak vlastní grafy.

{{% alert color="primary" %}} 
Použijte výčtový typ [ChartType](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/charttype/) v rámci jmenného prostoru [Aspose.Slides.Charts](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/). Hodnoty v tomto výčtu odpovídají různým typům grafů.
{{% /alert %}} 

### **Vytvoření seskupených sloupcových grafů**

Tato část vysvětluje, jak vytvořit seskupené sloupcové grafy pomocí Aspose.Slides pro .NET. Naučíte se inicializovat prezentaci, přidat graf a přizpůsobit jeho prvky, jako je nadpis, data, série, kategorie a stylování. Postupujte podle níže uvedených kroků a uvidíte, jak se generuje standardní seskupený sloupcový graf:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s některými daty a specifikujte typ `ChartType.ClusteredColumn`.
4. Přidejte nadpis grafu.
5. Přistupte k datovému listu grafu.
6. Vymažte všechny výchozí série a kategorie.
7. Přidejte nové série a kategorie.
8. Přidejte nová data do série grafu.
9. Použijte barvu výplně pro sérii grafu.
10. Přidejte popisky k sérii grafu.
11. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód ukazuje, jak vytvořit seskupený sloupcový graf:

```c#
// Vytvořte instanci třídy Presentation.
using (Presentation presentation = new Presentation())
{
    // Přistupte k prvnímu snímku.
    ISlide slide = presentation.Slides[0];

    // Přidejte seskupený sloupcový graf s výchozími daty.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    // Nastavte nadpis grafu.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Nastavte první sérii, aby zobrazovala hodnoty.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Nastavte index listu s daty grafu.
    int worksheetIndex = 0;

    // Získejte sešit s daty grafu.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Odstraňte výchozí generované série a kategorie.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Přidejte nové série.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), chart.Type);

    // Přidejte nové kategorie.
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));

    // Získejte první sérii grafu.
    IChartSeries series = chart.ChartData.Series[0];

    // Naplňte data série.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Nastavte barvu výplně pro sérii.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Red;

    // Získejte druhou sérii grafu.
    series = chart.ChartData.Series[1];

    // Naplňte data série.
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 60));

    // Nastavte barvu výplně pro sérii.
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = Color.Green;

    // Nastavte první popisek tak, aby zobrazoval název kategorie.
    IDataLabel label = series.DataPoints[0].Label;
    label.DataLabelFormat.ShowCategoryName = true;

    label = series.DataPoints[1].Label;
    label.DataLabelFormat.ShowSeriesName = true;

    // Nastavte sérii, aby pro třetí popisek zobrazovala hodnotu.
    label = series.DataPoints[2].Label;
    label.DataLabelFormat.ShowValue = true;
    label.DataLabelFormat.ShowSeriesName = true;
    label.DataLabelFormat.Separator = "/";

    // Uložte prezentaci na disk jako soubor PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Graf seskupených sloupců](clustered_column_chart.png)

### **Vytvoření rozptylových grafů**

Rozptylové grafy (také známé jako scatter ploty nebo grafy x‑y) se často používají k ověření vzorů nebo demonstraci korelací mezi dvěma proměnnými.

Použijte rozptylový graf, když:

* máte párovaná číselná data;
* máte dvě proměnné, které spolu dobře souvisejí;
* chcete zjistit, zda jsou dvě proměnné navzájem spjaty;
* máte nezávislou proměnnou s více hodnotami pro závislou proměnnou.

Tento C# kód ukazuje, jak vytvořit rozptylový graf s různými sériemi značek:

```c#
// Vytvořte instanci třídy Presentation.
using (Presentation presentation = new Presentation())
{
    // Přistupte k prvnímu snímku.
    ISlide slide = presentation.Slides[0];

    // Vytvořte výchozí rozptylový graf.
    IChart chart = slide.Shapes.AddChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300);

    // Nastavte index listu s daty grafu.
    int worksheetIndex = 0;

    // Získejte sešit s daty grafu.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Odstraňte výchozí sérii.
    chart.ChartData.Series.Clear();

    // Přidejte nové série.
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 1, "Series 1"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 1, 3, "Series 2"), chart.Type);

    // Získejte první sérii grafu.
    IChartSeries series = chart.ChartData.Series[0];

    // Přidejte nový bod (1:3) do série.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 1, 1), workbook.GetCell(worksheetIndex, 2, 2, 3));

    // Přidejte nový bod (2:10).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 1, 2), workbook.GetCell(worksheetIndex, 3, 2, 10));

    // Změňte typ série.
    series.Type = ChartType.ScatterWithStraightLinesAndMarkers;

    // Změňte značku série grafu.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Star;

    // Získejte druhou sérii grafu.
    series = chart.ChartData.Series[1];

    // Přidejte nový bod (5:2) do série grafu.
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 2, 3, 5), workbook.GetCell(worksheetIndex, 2, 4, 2));

    // Přidejte nový bod (3:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 3, 3, 3), workbook.GetCell(worksheetIndex, 3, 4, 1));

    // Přidejte nový bod (2:2).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 4, 3, 2), workbook.GetCell(worksheetIndex, 4, 4, 2));

    // Přidejte nový bod (5:1).
    series.DataPoints.AddDataPointForScatterSeries(workbook.GetCell(worksheetIndex, 5, 3, 5), workbook.GetCell(worksheetIndex, 5, 4, 1));

    // Změňte značku série grafu.
    series.Marker.Size = 10;
    series.Marker.Symbol = MarkerStyleType.Circle;

    // Uložte prezentaci na disk jako soubor PPTX.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Rozptylový graf](scatter_chart.png)

### **Vytvoření koláčových grafů**

Koláčové grafy jsou nejvhodnější pro zobrazení vztahu část‑celku v datech, zejména když data obsahují kategoriální štítky s číselnými hodnotami. Pokud však vaše data obsahují mnoho částí nebo štítků, zvažte raději sloupcový graf.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ `ChartType.Pie`.
4. Přistupte k datovému sešitu grafu ([IChartDataWorkbook](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/)).
5. Vymažte výchozí sérii a kategorie.
6. Přidejte nové sérii a kategorie.
7. Přidejte nová data do série grafu.
8. Přidejte nové body do grafu a aplikujte vlastní barvy na sektory koláčového grafu.
9. Nastavte popisky pro sérii.
10. Aktivujte čáry pro popisky sérií.
11. Nastavte úhel otočení koláčového grafu.
12. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód ukazuje, jak vytvořit koláčový graf:

```c#
// Vytvořte instanci třídy Presentation.
using (Presentation presentation = new Presentation())
{
    // Přistupte k prvnímu snímku.
    ISlide slide = presentation.Slides[0];

    // Přidejte graf s výchozími daty.
    IChart chart = slide.Shapes.AddChart(ChartType.Pie, 20, 20, 500, 300);

    // Nastavte nadpis grafu.
    chart.ChartTitle.AddTextFrameForOverriding("Sample Title");
    chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;
    chart.ChartTitle.Height = 20;
    chart.HasTitle = true;

    // Nastavte první sérii, aby zobrazovala hodnoty.
    chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

    // Nastavte index listu s daty grafu.
    int worksheetIndex = 0;

    // Získejte sešit s daty grafu.
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Odstraňte výchozí generované série a kategorie.
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Přidejte nové kategorie.
    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "1st Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "2nd Qtr"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "3rd Qtr"));

    // Přidejte novou sérii.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Naplňte data série.
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 1, 1, 20));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 2, 1, 50));
    series.DataPoints.AddDataPointForPieSeries(workbook.GetCell(worksheetIndex, 3, 1, 30));

    // Nastavte barvu sektoru.
    chart.ChartData.SeriesGroups[0].IsColorVaried = true;

    IChartDataPoint point = series.DataPoints[0];
    point.Format.Fill.FillType = FillType.Solid;
    point.Format.Fill.SolidFillColor.Color = Color.Cyan;

    // Nastavte okraj sektoru.
    point.Format.Line.FillFormat.FillType = FillType.Solid;
    point.Format.Line.FillFormat.SolidFillColor.Color = Color.Gray;
    point.Format.Line.Width = 3.0;
    point.Format.Line.Style = LineStyle.ThinThick;
    point.Format.Line.DashStyle = LineDashStyle.LargeDash;

    IChartDataPoint point1 = series.DataPoints[1];
    point1.Format.Fill.FillType = FillType.Solid;
    point1.Format.Fill.SolidFillColor.Color = Color.Brown;

    // Nastavte okraj sektoru.
    point1.Format.Line.FillFormat.FillType = FillType.Solid;
    point1.Format.Line.FillFormat.SolidFillColor.Color = Color.Blue;
    point1.Format.Line.Width = 3.0;
    point1.Format.Line.Style = LineStyle.Single;
    point1.Format.Line.DashStyle = LineDashStyle.LargeDashDot;

    IChartDataPoint point2 = series.DataPoints[2];
    point2.Format.Fill.FillType = FillType.Solid;
    point2.Format.Fill.SolidFillColor.Color = Color.Coral;

    // Nastavte okraj sektoru.
    point2.Format.Line.FillFormat.FillType = FillType.Solid;
    point2.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;
    point2.Format.Line.Width = 2.0;
    point2.Format.Line.Style = LineStyle.ThinThin;
    point2.Format.Line.DashStyle = LineDashStyle.LargeDashDotDot;

    // Vytvořte vlastní popisky pro každou kategorii v nové sérii.
    IDataLabel label1 = series.DataPoints[0].Label;

    label1.DataLabelFormat.ShowValue = true;

    IDataLabel label2 = series.DataPoints[1].Label;
    label2.DataLabelFormat.ShowValue = true;
    label2.DataLabelFormat.ShowLegendKey = true;
    label2.DataLabelFormat.ShowPercentage = true;

    IDataLabel label3 = series.DataPoints[2].Label;
    label3.DataLabelFormat.ShowSeriesName = true;
    label3.DataLabelFormat.ShowPercentage = true;

    // Nastavte sérii, aby pro graf zobrazovala čáry ukazatele.
    series.Labels.DefaultDataLabelFormat.ShowLeaderLines = true;

    // Nastavte úhel otočení sektoru koláčového grafu.
    chart.ChartData.SeriesGroups[0].FirstSliceAngle = 180;

    // Uložte prezentaci na disk jako soubor PPTX.
    presentation.Save("PieChart_out.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Koláčový graf](pie_chart.png)

### **Vytvoření čárových grafů**

Čárové grafy (také nazývané čárové diagramy) jsou nejvhodnější v situacích, kdy chcete demonstrovat změny hodnot v čase. Pomocí čárového grafu můžete najednou porovnat velké množství dat, sledovat změny a trendy v čase, zvýraznit anomálie v datových sériích a další.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ `ChartType.Line`.
4. Přistupte k datovému sešitu grafu ([IChartDataWorkbook](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/)).
5. Vymažte výchozí sérii a kategorie.
6. Přidejte nové sérii a kategorie.
7. Přidejte nová data do série grafu.
8. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód ukazuje, jak vytvořit čárový graf:

```c#
using (Presentation presentation = new Presentation())
{
    IChart lineChart = presentation.Slides[0].Shapes.AddChart(ChartType.Line, 20, 20, 500, 300);

    presentation.Save("lineChart.pptx", SaveFormat.Pptx);
}
```

Ve výchozím nastavení jsou body na čárovém grafu spojeny přímými souvislými čarami. Pokud chcete, aby byly body spojeny čárkovanými úseky, můžete specifikovat požadovaný typ čárky následovně:

```c#
foreach (IChartSeries series in lineChart.ChartData.Series)
{
    series.Format.Line.DashStyle = LineDashStyle.Dash;
}
```

Výsledek:

![Čárový graf](line_chart.png)

### **Vytvoření stromových mapových grafů**

Stromové mapové grafy jsou nejvhodnější pro prodejní data, když chcete zobrazit relativní velikost kategorií a rychle upoutat pozornost na položky, které představují významné příspěvky v rámci každé kategorie.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ `ChartType.Treemap`.
4. Přistupte k datovému sešitu grafu ([IChartDataWorkbook](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/)).
5. Vymažte výchozí sérii a kategorie.
6. Přidejte nové sérii a kategorie.
7. Přidejte nová data do série grafu.
8. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód ukazuje, jak vytvořit stromový mapový graf:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Treemap, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Větev 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Větev 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Treemap);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForTreemapSeries(workbook.GetCell(0, "D8", 3));

    series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;

    presentation.Save("Treemap.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Stromový mapový graf](treemap_chart.png)

### **Vytvoření akciových grafů**

Akciové grafy slouží k zobrazení finančních údajů jako otevření, nejvyšší, nejnižší a uzavření cen, což pomáhá analyzovat tržní trendy a volatilitu. Poskytují zásadní pohled na výkonnost akcií a pomáhají investorům i analytikům činit informovaná rozhodnutí.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ `ChartType.OpenHighLowClose`.
4. Přistupte k datovému sešitu grafu ([IChartDataWorkbook](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/)).
5. Vymažte výchozí sérii a kategorie.
6. Přidejte nové sérii a kategorie.
7. Přidejte nová data do série grafu.
8. Specifikujte formát HiLowLines.
9. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód ukazuje, jak vytvořit akciový graf:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.OpenHighLowClose, 20, 20, 500, 300, false);

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "A"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "B"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C"));

    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Open"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "High"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 3, "Low"), chart.Type);
    chart.ChartData.Series.Add(workbook.GetCell(0, 0, 4, "Close"), chart.Type);

    IChartSeries series = chart.ChartData.Series[0];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 1, 72));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 1, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 1, 38));

    series = chart.ChartData.Series[1];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 2, 172));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 2, 57));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 2, 57));

    series = chart.ChartData.Series[2];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 3, 12));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 3, 13));

    series = chart.ChartData.Series[3];
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 1, 4, 25));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 2, 4, 38));
    series.DataPoints.AddDataPointForStockSeries(workbook.GetCell(0, 3, 4, 50));

    chart.ChartData.SeriesGroups[0].UpDownBars.HasUpDownBars = true;
    chart.ChartData.SeriesGroups[0].HiLowLinesFormat.Line.FillFormat.FillType = FillType.Solid;

    foreach (IChartSeries ser in chart.ChartData.Series)
    {
        ser.Format.Line.FillFormat.FillType = FillType.NoFill;
    }

    chart.Axes.VerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    presentation.Save("Stock-chart.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Akciový graf](stock_chart.png)

### **Vytvoření krabicových a vousatých grafů**

Krabicové a vousaté grafy slouží k zobrazení rozdělení dat shrnutím klíčových statistických ukazatelů, jako jsou medián, kvartily a potenciální odlehlé hodnoty. Jsou zvláště užitečné při průzkumné analýze dat a statistických studiích k rychlému pochopení variability dat a identifikaci anomálií.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ `ChartType.BoxAndWhisker`.
4. Přistupte k datovému sešitu grafu ([IChartDataWorkbook](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/)).
5. Vymažte výchozí sérii a kategorie.
6. Přidejte nové sérii a kategorie.
7. Přidejte nová data do série grafu.
8. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód ukazuje, jak vytvořit krabicový a vousatý graf:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.BoxAndWhisker, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.BoxAndWhisker);

    series.QuartileMethod = QuartileMethodType.Exclusive;
    series.ShowMeanLine = true;
    series.ShowMeanMarkers = true;
    series.ShowInnerPoints = true;
    series.ShowOutlierPoints = true;

    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B1", 15));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B2", 41));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B3", 16));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B4", 10));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B5", 23));
    series.DataPoints.AddDataPointForBoxAndWhiskerSeries(workbook.GetCell(0, "B6", 16));

    presentation.Save("BoxAndWhisker.pptx", SaveFormat.Pptx);
}
```

### **Vytvoření trychytových grafů**

Trychytové grafy se používají k vizualizaci procesů zahrnujících sekvenční fáze, kde objem dat klesá při postupu z jednoho kroku na další. Jsou zvláště užitečné pro analýzu konverzních poměrů, identifikaci úzkých míst a sledování efektivity prodejních či marketingových procesů.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ `ChartType.Funnel`.
4. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód ukazuje, jak vytvořit trychytový graf:

```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Funnel, 50, 50, 500, 400);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    chart.ChartData.Categories.Add(workbook.GetCell(0, "A1", "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A2", "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A3", "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A4", "Category 4"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A5", "Category 5"));
    chart.ChartData.Categories.Add(workbook.GetCell(0, "A6", "Category 6"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Funnel);

    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B1", 50));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B2", 100));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B3", 200));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B4", 300));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B5", 400));
    series.DataPoints.AddDataPointForFunnelSeries(workbook.GetCell(0, "B6", 500));

    presentation.Save("Funnel.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Trychytový graf](funnel_chart.png)

### **Vytvoření slunečních grafů**

Sluneční grafy slouží k vizualizaci hierarchických dat, přičemž úrovně jsou zobrazeny jako soustředné kruhy. Pomáhají ilustrovat vztahy část‑celku a jsou ideální pro představování vnořených kategorií a podkategorií v přehledném a kompaktním formátu.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ `ChartType.Sunburst`.
4. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód ukazuje, jak vytvořit sluneční graf:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Sunburst, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    // Větev 1
    IChartCategory leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C1", "Leaf1"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem1");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch1");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C2", "Leaf2"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C3", "Leaf3"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C4", "Leaf4"));

    // Větev 2
    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C5", "Leaf5"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem3");
    leaf.GroupingLevels.SetGroupingItem(2, "Branch2");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C6", "Leaf6"));

    leaf = chart.ChartData.Categories.Add(workbook.GetCell(0, "C7", "Leaf7"));
    leaf.GroupingLevels.SetGroupingItem(1, "Stem4");

    chart.ChartData.Categories.Add(workbook.GetCell(0, "C8", "Leaf8"));

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Sunburst);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D1", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D2", 5));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D3", 3));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D4", 6));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D5", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D6", 9));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D7", 4));
    series.DataPoints.AddDataPointForSunburstSeries(workbook.GetCell(0, "D8", 3));

    presentation.Save("Sunburst.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Sluneční graf](sunburst_chart.png)

### **Vytvoření histogramových grafů**

Histogramové grafy slouží k znázornění rozdělení číselných dat seskupováním hodnot do intervalů nebo košů. Jsou zvláště užitečné pro identifikaci datových vzorů, jako jsou četnost, šikmost a rozptyl, a pro odhalování odlehlých hodnot v datové sadě.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s některými daty a specifikujte typ `ChartType.Histogram`.
4. Přistupte k datovému sešitu grafu ([IChartDataWorkbook](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/)).
5. Vymažte výchozí sérii a kategorie.
6. Přidejte nové sérii a kategorie.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód ukazuje, jak vytvořit histogramový graf:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Histogram, 20, 20, 500, 300);
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    IChartSeries series = chart.ChartData.Series.Add(ChartType.Histogram);
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A1", 15));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A2", -41));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A3", 16));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A4", 10));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A5", -23));
    series.DataPoints.AddDataPointForHistogramSeries(workbook.GetCell(0, "A6", 16));

    chart.Axes.HorizontalAxis.AggregationType = AxisAggregationType.Automatic;

    presentation.Save("Histogram.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Histogramový graf](histogram_chart.png)

### **Vytvoření radiálních grafů**

Radiální grafy slouží k zobrazení vícevariabilních dat ve dvourozměrném formátu, což umožňuje snadné porovnání několika proměnných současně. Jsou zvláště užitečné pro identifikaci vzorů, silných a slabých stránek napříč několika výkonnostními metrikami nebo atributy.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s některými daty a specifikujte typ `ChartType.Radar`.
4. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód ukazuje, jak vytvořit radiální graf:

```c#
using (Presentation presentation = new Presentation())
{
    presentation.Slides[0].Shapes.AddChart(ChartType.Radar, 20, 20, 500, 300);
    presentation.Save("Radar-chart.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Radiální graf](radar_chart.png)

### **Vytvoření vícekategoriových grafů**

Vícekategoriové grafy slouží k zobrazení dat, která zahrnují více než jedno kategoriální seskupení, což vám umožňuje porovnat hodnoty napříč několika dimenzemi současně. Jsou zvláště užitečné, když potřebujete analyzovat trendy a vztahy v komplexních, vícevrstvých datových sadách.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte graf s výchozími daty a specifikujte typ `ChartType.ClusteredColumn`.
4. Přistupte k datovému sešitu grafu ([IChartDataWorkbook](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/)).
5. Vymažte výchozí sérii a kategorie.
6. Přidejte nové sérii a kategorie.
7. Přidejte nová data do série grafu.
8. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód ukazuje, jak vytvořit vícekategoriový graf:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(0);

    int worksheetIndex = 0;

    IChartCategory category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c2", "A"));
    category.GroupingLevels.SetGroupingItem(1, "Group1");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c3", "B"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c4", "C"));
    category.GroupingLevels.SetGroupingItem(1, "Group2");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c5", "D"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c6", "E"));
    category.GroupingLevels.SetGroupingItem(1, "Group3");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c7", "F"));

    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c8", "G"));
    category.GroupingLevels.SetGroupingItem(1, "Group4");
    category = chart.ChartData.Categories.Add(workbook.GetCell(0, "c9", "H"));

    // Přidejte sérii.
    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, "D1", "Series 1"), ChartType.ClusteredColumn);

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D2", 10));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D3", 20));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D4", 30));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D5", 40));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D6", 50));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D7", 60));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D8", 70));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, "D9", 80));

    // Uložte prezentaci s grafem.
    presentation.Save("AsposeChart_out.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Vícekategoriový graf](multi_category_chart.png)

### **Vytvoření mapových grafů**

Mapové grafy slouží k vizualizaci geografických dat mapováním informací na konkrétní místa, jako jsou země, státy nebo města. Jsou zvláště užitečné pro analýzu regionálních trendů, demografických údajů a prostorových rozdělení přehledným a vizuálně atraktivním způsobem.

Tento C# kód ukazuje, jak vytvořit mapový graf:

```c#
using (Presentation presentation = new Presentation())
{
    IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Map, 20, 20, 500, 300);
    presentation.Save("mapChart.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Mapový graf](map_chart.png)

### **Vytvoření kombinovaných grafů**

Kombinovaný graf (nebo combo graf) spojuje dva nebo více typů grafů v jednom diagramu. Tento graf vám umožní zdůraznit, porovnat nebo zkoumat rozdíly mezi dvěma či více datovými sadami, což pomáhá identifikovat vztahy mezi nimi.

![Kombinovaný graf](combination_chart.png)

Následující C# kód ukazuje, jak vytvořit výše uvedený kombinovaný graf v prezentaci PowerPoint:

```c#
private static void CreateComboChart()
{
    using (Presentation presentation = new Presentation())
    {
        IChart chart = CreateChartWithFirstSeries(presentation.Slides[0]);

        AddSecondSeriesToChart(chart);
        AddThirdSeriesToChart(chart);

        SetPrimaryAxesFormat(chart);
        SetSecondaryAxesFormat(chart);

        presentation.Save("combo-chart.pptx", SaveFormat.Pptx);
    }
}

private static IChart CreateChartWithFirstSeries(ISlide slide)
{
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    // Nastavuje nadpis grafu
    chart.HasTitle = true;
    chart.ChartTitle.AddTextFrameForOverriding("Chart Title");
    chart.ChartTitle.Overlay = false;
    IPortionFormat portionFormat = 
       chart.ChartTitle.TextFrameForOverriding.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    portionFormat.FontBold = NullableBool.False;
    portionFormat.FontHeight = 18f;

    // Nastavuje legendu grafu
    chart.Legend.Position = LegendPositionType.Bottom;
    chart.Legend.TextFormat.PortionFormat.FontHeight = 12f;

    // Odstraňuje výchozí generované série a kategorie
    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    int worksheetIndex = 0;
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    // Přidá nové kategorie
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 3, 0, "Category 3"));
    chart.ChartData.Categories.Add(workbook.GetCell(worksheetIndex, 4, 0, "Category 4"));

    // Přidejte první sérii
    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 1, "Series 1"), chart.Type);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 1, 4.3));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 1, 2.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 1, 3.5));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 1, 4.5));

    return chart;
}

private static void AddSecondSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 2, "Series 2"), ChartType.ClusteredColumn);

    series.ParentSeriesGroup.Overlap = -25;
    series.ParentSeriesGroup.GapWidth = 220;

    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 2, 2.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 2, 4.4));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 2, 1.8));
    series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 4, 2, 2.8));
}

private static void AddThirdSeriesToChart(IChart chart)
{
    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
    const int worksheetIndex = 0;

    IChartSeries series = chart.ChartData.Series.Add(
        workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), ChartType.Line);

    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 1, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 2, 3, 2.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 3, 3, 3.0));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(worksheetIndex, 4, 3, 5.0));

    series.PlotOnSecondAxis = true;
}

private static void SetPrimaryAxesFormat(IChart chart)
{
    // Nastavuje vodorovnou osu
    IAxis horizontalAxis = chart.Axes.HorizontalAxis;
    horizontalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    horizontalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(horizontalAxis, "X Axis");

    // Nastavuje svislou osu
    IAxis verticalAxis = chart.Axes.VerticalAxis;
    verticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    verticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(verticalAxis, "Y Axis 1");

    // Nastavuje barvu hlavních svislých mřížek
    ILineFillFormat majorGridLinesFormat = verticalAxis.MajorGridLinesFormat.Line.FillFormat;
    majorGridLinesFormat.FillType = FillType.Solid;
    majorGridLinesFormat.SolidFillColor.Color = Color.FromArgb(217, 217, 217);
}

private static void SetSecondaryAxesFormat(IChart chart)
{
    // Nastavuje sekundární vodorovnou osu
    IAxis secondaryHorizontalAxis = chart.Axes.SecondaryHorizontalAxis;
    secondaryHorizontalAxis.Position = AxisPositionType.Bottom;
    secondaryHorizontalAxis.CrossType = CrossesType.Maximum;
    secondaryHorizontalAxis.IsVisible = false;
    secondaryHorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryHorizontalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    // Nastavuje sekundární svislou osu
    IAxis secondaryVerticalAxis = chart.Axes.SecondaryVerticalAxis;
    secondaryVerticalAxis.Position = AxisPositionType.Right;
    secondaryVerticalAxis.TextFormat.PortionFormat.FontHeight = 12f;
    secondaryVerticalAxis.Format.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;
    secondaryVerticalAxis.MinorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    SetAxisTitle(secondaryVerticalAxis, "Y Axis 2");
}

private static void SetAxisTitle(IAxis axis, string axisTitle)
{
    axis.HasTitle = true;
    axis.Title.Overlay = false;
    IPortionFormat titlePortionFormat =
        axis.Title.AddTextFrameForOverriding(axisTitle).Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
    titlePortionFormat.FontBold = NullableBool.False;
    titlePortionFormat.FontHeight = 12f;
}
```

## **Aktualizace grafů**

Aspose.Slides pro .NET vám umožňuje aktualizovat grafy v PowerPointu úpravou dat grafu, formátování a stylu. Tato funkce zjednodušuje proces udržování prezentací aktuálních s dynamickým obsahem a zajišťuje, že grafy přesně odrážejí aktuální data a vizuální standardy.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) představující prezentaci obsahující graf.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Projděte všechny tvary a najděte graf.
4. Přistupte k datovému listu grafu.
5. Změňte sérii dat grafu úpravou hodnot sérií.
6. Přidejte novou sérii a vyplňte její data.
7. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód ukazuje, jak aktualizovat graf:

```c#
const string chartName = "My chart";

// Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Přistupte k prvnímu snímku.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            // Nastavte index listu s daty grafu.
            int worksheetIndex = 0;

            // Získejte sešit s daty grafu.
            IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

            // Změňte názvy kategorií grafu.
            workbook.GetCell(worksheetIndex, 1, 0, "Modified Category 1");
            workbook.GetCell(worksheetIndex, 2, 0, "Modified Category 2");

            // Získejte první sérii grafu.
            IChartSeries series = chart.ChartData.Series[0];

            // Aktualizujte data série.
            workbook.GetCell(worksheetIndex, 0, 1, "New_Series 1"); // Úprava názvu série.
            series.DataPoints[0].Value.Data = 90;
            series.DataPoints[1].Value.Data = 123;
            series.DataPoints[2].Value.Data = 44;

            // Získejte druhou sérii grafu.
            series = chart.ChartData.Series[1];

            // Aktualizujte data série.
            workbook.GetCell(worksheetIndex, 0, 2, "New_Series 2"); // Úprava názvu série.
            series.DataPoints[0].Value.Data = 23;
            series.DataPoints[1].Value.Data = 67;
            series.DataPoints[2].Value.Data = 99;

            // Přidejte novou sérii.
            series = chart.ChartData.Series.Add(workbook.GetCell(worksheetIndex, 0, 3, "Series 3"), chart.Type);

            // Naplněte data série.
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 1, 3, 20));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 2, 3, 50));
            series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(worksheetIndex, 3, 3, 30));

            chart.Type = ChartType.ClusteredCylinder;
        }
    }

    // Uložte prezentaci s grafem.
    presentation.Save("AsposeChartModified_out.pptx", SaveFormat.Pptx);
}
```

## **Nastavení rozsahu dat pro graf**

Aspose.Slides pro .NET poskytuje flexibilitu definovat konkrétní datový rozsah z listu jako zdroj pro data vašeho grafu. To znamená, že můžete přímo mapovat část listu na graf, což vám umožní řídit, které buňky přispívají k sériím a kategoriím grafu. Výsledkem je snadná aktualizace a synchronizace vašich grafů s nejnovějšími změnami v listu, čímž vaše PowerPoint prezentace vždy odrážejí aktuální a přesné informace.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) představující prezentaci obsahující graf.
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Projděte všechny tvary a najděte graf.
4. Přistupte k datům grafu a nastavte rozsah.
5. Uložte upravenou prezentaci jako soubor PPTX.

Tento C# kód ukazuje, jak nastavit datový rozsah pro graf:

```c#
const string chartName = "My chart";

// Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
using (Presentation presentation = new Presentation("ExistingChart.pptx"))
{
    // Přistupte k prvnímu snímku.
    ISlide slide = presentation.Slides[0];

    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IChart chart && chart.Name == chartName)
        {
            chart.ChartData.SetRange("Sheet1!A1:B4");
        }
    }

    presentation.Save("SetDataRange_out.pptx", SaveFormat.Pptx);
}
```

## **Použití výchozích značek v grafech**

Když používáte výchozí značky v grafech, každá série grafu automaticky získá jiný výchozí symbol značky.

Tento C# kód ukazuje, jak automaticky nastavit značku série grafu:

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 10, 10, 400, 400);

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

    IChartSeries series = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "C1"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 1, 24));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "C2"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 1, 23));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "C3"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 1, -10));

    chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "C4"));
    series.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 1, null));

    IChartSeries series2 = chart.ChartData.Series.Add(workbook.GetCell(0, 0, 2, "Series 2"), chart.Type);

    // Naplňte data série.
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 1, 2, 30));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 2, 2, 10));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 3, 2, 60));
    series2.DataPoints.AddDataPointForLineSeries(workbook.GetCell(0, 4, 2, 40));

    chart.HasLegend = true;
    chart.Legend.Overlay = false;

    presentation.Save("DefaultMarkersInChart.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Jaké typy grafů podporuje Aspose.Slides pro .NET?**

Aspose.Slides pro .NET podporuje širokou škálu typů grafů, včetně sloupcových, čárových, koláčových, plošných, rozptylových, histogramových, radiálních a mnoha dalších. Tato flexibilita vám umožní vybrat nejvhodnější typ grafu pro vaše potřeby vizualizace dat.

**Jak přidám nový graf do snímku?**

Chcete‑li přidat graf, nejprve vytvoříte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation), získáte požadovaný snímek pomocí jeho indexu a poté zavoláte metodu pro přidání grafu, kde určíte typ grafu a počáteční data. Tento proces graf přímo vloží do vaší prezentace.

**Jak mohu aktualizovat data zobrazovaná v grafu?**

Data grafu můžete aktualizovat přístupem k jeho datovému sešitu ([IChartDataWorkbook](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartdataworkbook/)), vymazáním výchozích sérií a kategorií a následným přidáním vlastních dat. To vám umožní programově obnovit graf tak, aby odrážel nejnovější data.

**Je možné přizpůsobit vzhled grafu?**

Ano, Aspose.Slides pro .NET poskytuje rozsáhlé možnosti přizpůsobení. Můžete měnit barvy, písma, popisky, legendy a další formátovací prvky tak, aby vzhled grafu odpovídal vašim konkrétním návrhovým požadavkům.