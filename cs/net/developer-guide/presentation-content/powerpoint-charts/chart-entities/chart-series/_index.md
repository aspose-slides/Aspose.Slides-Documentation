---
title: Správa datových řad grafu v prezentacích v .NET
linktitle: Datové řady
type: docs
url: /cs/net/chart-series/
keywords:
- řady grafu
- překrytí řad
- barva řady
- barva kategorie
- název řady
- datový bod
- mezera řady
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se spravovat řady grafů v C# pro PowerPoint (PPT/PPTX) s praktickými ukázkami kódu a osvědčenými postupy pro vylepšení vašich datových prezentací."
---
## **Přehled**

Tento článek popisuje roli [ChartSeries](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartseries/) v Aspose.Slides pro .NET, se zaměřením na to, jak jsou data strukturovaná a vizualizovaná v prezentacích. Tyto objekty poskytují základní prvky, které definují jednotlivé sady datových bodů, kategorie a parametry vzhledu v grafu. Prací s [ChartSeries](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartseries/), vývojáři mohou bezproblémově integrovat podkladové zdroje dat a mít úplnou kontrolu nad tím, jak jsou informace zobrazovány, což vede k dynamickým, na datech založeným prezentacím, které jasně předávají postřehy a analýzu.

Řada je řádek nebo sloupec čísel vykreslených v grafu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí řady grafu**

Vlastnost [IChartSeriesOverlap](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/ichartseries/properties/overlap) řídí, jak se sloupce a pruhy překrývají v 2D grafu, přičemž lze zadat rozsah od -100 do 100. Protože je tato vlastnost přiřazena ke skupině řad, nikoli k jednotlivé řadě grafu, je na úrovni řady jen pro čtení. Pro nastavení hodnot překrytí použijte vlastnost `ParentSeriesGroup.Overlap`, která je čtení/zápis a aplikuje zadané překrytí na všechny řady v této skupině.

Níže je ukázka v jazyce C#, která ukazuje, jak vytvořit prezentaci, přidat seskupený sloupcový graf, získat první řadu grafu, nastavit překrytí a poté výsledek uložit jako soubor PPTX:

```cs
sbyte overlap = 30;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Přidejte seskupený sloupcový graf s výchozími daty.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.ChartData.Series[0];
    if (series.Overlap == 0)
    {
        // Nastavte překrytí řady.
        series.ParentSeriesGroup.Overlap = overlap;
    }

    // Uložte soubor prezentace na disk.
    presentation.Save("series_overlap.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Překrytí řad](series_overlap.png)

## **Změna barvy výplně řady**

Aspose.Slides usnadňuje přizpůsobení barev výplně řad grafu, což vám umožní zvýraznit konkrétní datové body a vytvořit vizuálně atraktivní grafy. To je dosaženo pomocí objektu [IFormat](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/iformat/), který podporuje různé typy výplní, konfigurace barev a další pokročilé možnosti stylování. Po přidání grafu na snímek a získání požadované řady jednoduše získáte řadu a použijete odpovídající barvu výplně. Kromě plných výplní můžete také využít gradientní nebo vzorové výplně pro větší flexibilitu návrhu. Po nastavení barev podle požadavků uložte prezentaci, čímž dokončíte aktualizovaný vzhled.

Následující ukázka v C# ukazuje, jak změnit barvu první řady:

```cs
Color seriesColor = Color.Blue;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Přidejte seskupený sloupcový graf s výchozími daty.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Nastavte barvu první řady.
    IChartSeries series = chart.ChartData.Series[0];
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;

    // Uložte soubor prezentace na disk.
    presentation.Save("series_color.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Barva řady](series_color.png)

## **Změna názvu řady**

Aspose.Slides nabízí jednoduchý způsob, jak upravit názvy řad grafu, což usnadňuje označování dat jasným a smysluplným způsobem. Přístupem k příslušné buňce listu v datech grafu mohou vývojáři přizpůsobit způsob, jak jsou data prezentována. Tato úprava je zvláště užitečná, když je třeba názvy řad aktualizovat nebo upřesnit podle kontextu dat. Po přejmenování řady lze prezentaci uložit, aby se změny zachovaly.

Níže je ukázka kódu C#, který tento postup demonstruje.

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Přidejte seskupený sloupcový graf s výchozími daty.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Nastavte název první řady.
    IChartDataCell seriesCell = chart.ChartData.ChartDataWorkbook.GetCell(0, 0, 1);
    seriesCell.Value = seriesName;

    // Uložte soubor prezentace na disk.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

Následující kód v C# ukazuje alternativní způsob změny názvu řady:

```cs
string seriesName = "New name";

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Přidejte seskupený sloupcový graf s výchozími daty.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    // Nastavte název první řady.
    IChartSeries series = chart.ChartData.Series[0];
    series.Name.AsCells[0].Value = seriesName;

    // Uložte soubor prezentace na disk.
    presentation.Save("series_name.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Název řady](series_name.png)

## **Získání automatické barvy výplně řady**

Aspose.Slides pro .NET umožňuje získat automatickou barvu výplně řady grafu v oblasti vykreslení. Po vytvoření instance třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) můžete získat odkaz na požadovaný snímek podle indexu, poté přidat graf pomocí preferovaného typu (např. `ChartType.ClusteredColumn`). Přístupem k řadám v grafu můžete získat automatickou barvu výplně.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Přidejte seskupený sloupcový graf s výchozími daty.
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        // Získejte barvu výplně řady.
        Color color = chart.ChartData.Series[i].GetAutomaticSeriesColor();
        Console.WriteLine($"Series {i} color: {color.Name}");
    }
}
```

Výstup:
```text
Series 0 color: ff4f81bd
Series 1 color: ffc0504d
Series 2 color: ff9bbb59
```

## **Nastavení invertované barvy výplně pro řadu grafu**

Když vaše datová řada obsahuje jak kladné, tak záporné hodnoty, barevné označení každého sloupce nebo pruhu stejnou barvou může graf ztížit čitelnost. Aspose.Slides pro .NET vám umožňuje přiřadit invertovanou barvu výplně – samostatnou výplň aplikovanou automaticky na datové body pod nulou – takže záporné hodnoty jsou na první pohled výrazné. V této sekci se naučíte, jak tuto možnost povolit, vybrat vhodnou barvu a uložit aktualizovanou prezentaci.

Následující ukázka kódu demonstruje operaci:

```cs
Color inverColor = Color.Red;

using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartDataWorkbook workBook = chart.ChartData.ChartDataWorkbook;

    chart.ChartData.Series.Clear();
    chart.ChartData.Categories.Clear();

    // Přidejte nové kategorie.
    chart.ChartData.Categories.Add(workBook.GetCell(0, 1, 0, "Category 1"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 2, 0, "Category 2"));
    chart.ChartData.Categories.Add(workBook.GetCell(0, 3, 0, "Category 3"));

    // Přidejte novou řadu.
    IChartSeries series = chart.ChartData.Series.Add(workBook.GetCell(0, 0, 1, "Series 1"), chart.Type);

    // Naplněte data řady.
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 1, 1, -20));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 2, 1, 50));
    series.DataPoints.AddDataPointForBarSeries(workBook.GetCell(0, 3, 1, -30));

    // Nastavte nastavení barvy řady.
    var seriesColor = series.GetAutomaticSeriesColor();
    series.InvertIfNegative = true;
    series.Format.Fill.FillType = FillType.Solid;
    series.Format.Fill.SolidFillColor.Color = seriesColor;
    series.InvertedSolidFillColor.Color = inverColor;

    presentation.Save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Invertovaná plná barva výplně](inverted_solid_fill_color.png)

Můžete invertovat barvu výplně pro jediný datový bod místo celé řady. Stačí získat požadovaný `IChartDataPoint` a nastavit jeho vlastnost `InvertIfNegative` na true.

Následující ukázka kódu ukazuje, jak to provést:

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 20, 500, 200, true);

    chart.ChartData.Series.Clear();
    IChartSeries series = chart.ChartData.Series.Add(chart.ChartData.ChartDataWorkbook.GetCell(0, "B1"), chart.Type);

    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B2", -5));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B3", 3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B4", -3));
    series.DataPoints.AddDataPointForBarSeries(chart.ChartData.ChartDataWorkbook.GetCell(0, "B5", 1));

    // Invertovat barvu, pokud je datový bod na indexu 2 záporný.
    series.InvertIfNegative = false;
    series.DataPoints[2].InvertIfNegative = true;
                
    presentation.Save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
}
```

## **Vymazání konkrétních hodnot datových bodů**

Někdy graf obsahuje testovací hodnoty, odlehlé body nebo zastaralé záznamy, které je třeba odstranit bez nutnosti přestavovat celou řadu. Aspose.Slides pro .NET vám umožňuje cíleně vymazat libovolný datový bod podle indexu, vyčistit jeho obsah a okamžitě obnovit vykreslení, takže zbývající body se posunou a osy se automaticky přepočítají.

Ukázkový kód níže demonstruje operaci:

```cs
using (Presentation presentation = new Presentation("test_chart.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = (IChart)slide.Shapes[0];
    IChartSeries series = chart.ChartData.Series[0];

    foreach (IChartDataPoint dataPoint in series.DataPoints)
    {
        dataPoint.XValue.AsCell.Value = null;
        dataPoint.YValue.AsCell.Value = null;
    }

    series.DataPoints.Clear();

    presentation.Save("clear_data_points.pptx", SaveFormat.Pptx);
}
```

## **Nastavení šířky mezery řady**

Šířka mezery řídí množství prázdného prostoru mezi sousedními sloupci nebo pruhy – širší mezery zdůrazňují jednotlivé kategorie, zatímco užší mezery vytvářejí hustší, kompaktnější vzhled. Pomocí Aspose.Slides pro .NET můžete tento parametr jemně doladit pro celou řadu, čímž dosáhnete přesně takové vizuální rovnováhy, jakou vaše prezentace požaduje, aniž byste měnili podkladová data.

Následující ukázka kódu ukazuje, jak nastavit šířku mezery pro řadu:

```cs
ushort gapWidth = 30;

// Vytvořte prázdnou prezentaci.
using (Presentation presentation = new Presentation())
{
    // Získejte první snímek.
    ISlide slide = presentation.Slides[0];

    // Přidejte graf s výchozími daty.
    IChart chart = slide.Shapes.AddChart(ChartType.StackedColumn, 20, 20, 500, 200);

    // Uložte prezentaci na disk.
    presentation.Save("default_gap_width.pptx", SaveFormat.Pptx);

    // Nastavte hodnotu GapWidth.
    IChartSeries series = chart.ChartData.Series[0];
    series.ParentSeriesGroup.GapWidth = gapWidth;

    // Uložte prezentaci na disk.
    presentation.Save("gap_width_30.pptx", SaveFormat.Pptx);
}
```

Výsledek:

![Šířka mezery](gap_width.png)

## **Často kladené otázky**

**Existuje limit počtu řad, které může jeden graf obsahovat?**

Aspose.Slides neklade žádný pevný limit na počet řad, které můžete přidat. Praktický strop je dán čitelností grafu a dostupnou pamětí vaší aplikace.

**Co když jsou sloupce v rámci shluku příliš blízko u sebe nebo naopak příliš daleko?**

Upravte nastavení `GapWidth` pro tuto řadu (nebo její nadřazenou skupinu řad). Zvýšením hodnoty zvětšíte mezeru mezi sloupci, snížením ji přiblížíte.