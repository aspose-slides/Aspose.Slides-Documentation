---
title: Optimalizovat výpočty grafů pro prezentace v .NET
linktitle: Výpočty grafů
type: docs
weight: 50
url: /cs/net/chart-calculations/
keywords:
- výpočty grafů
- prvky grafu
- pozice prvku
- skutečná pozice
- podřazený prvek
- nadřazený prvek
- hodnoty grafu
- skutečná hodnota
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Pochopte výpočty grafů, aktualizace dat a řízení přesnosti v Aspose.Slides pro .NET pro PPT a PPTX, s praktickými příklady kódu v C#."
---
## **Přehled**

Aspose.Slides poskytuje rozhraní API pro práci s výpočty grafů a daty rozložení v prezentacích. Tento článek ukazuje, jak získat skutečné hodnoty prvků grafu, včetně skutečné polohy a velikosti prvků, které implementují `IActualLayout`, a skutečné hodnoty os grafu. Také vysvětluje, že tyto hodnoty jsou doplněny po ověření rozložení grafu.

Dále článek ukazuje, jak získat skutečnou polohu nadřazených prvků grafu a jak skrýt komponenty grafu, jako je název, osy, legenda a mřížkové čáry. Společně tyto příklady pomáhají prozkoumat informace o rozložení grafu a programově řídit viditelnost prvků grafu v prezentacích PowerPoint.

## **Vypočítat skutečné hodnoty prvků grafu**
Aspose.Slides pro .NET poskytuje jednoduché API pro získání těchto vlastností. To vám pomůže vypočítat skutečné hodnoty prvků grafu. Skutečné hodnoty zahrnují polohu prvků, které implementují rozhraní IActualLayout (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) a skutečné hodnoty os (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```c#
using (Presentation pres = new Presentation("test.pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();
    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Ukládání prezentace
	pres.Save("Result.pptx", SaveFormat.Pptx);
}
```



## **Vypočítat skutečnou polohu nadřazených prvků grafu**
Aspose.Slides pro .NET poskytuje jednoduché API pro získání těchto vlastností. Vlastnosti IActualLayout poskytují informace o skutečné poloze nadřazeného prvku grafu. Je nutné předtím zavolat metodu IChart.ValidateChartLayout(), aby se vlastnosti naplnily skutečnými hodnotami.

```c#
// Vytvoření prázdné prezentace
using (Presentation pres = new Presentation())
{
   Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
   chart.ValidateChartLayout();

   double x = chart.PlotArea.ActualX;
   double y = chart.PlotArea.ActualY;
   double w = chart.PlotArea.ActualWidth;
   double h = chart.PlotArea.ActualHeight;
}
```



## **Skrýt prvky grafu**
Toto téma vám pomůže pochopit, jak skrýt informace v grafu. Pomocí Aspose.Slides pro .NET můžete skrýt **Název, Vertikální osu, Horizontální osu** a **Mřížkové čáry** v grafu. Níže uvedený ukázkový kód ukazuje, jak tyto vlastnosti použít.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.LineWithMarkers, 140, 118, 320, 370);

    //Skrytí názvu grafu
    chart.HasTitle = false;

    ///Skrytí osy hodnot
    chart.Axes.VerticalAxis.IsVisible = false;

    //Viditelnost osy kategorií
    chart.Axes.HorizontalAxis.IsVisible = false;

    //Skrytí legendy
    chart.HasLegend = false;

    //Skrytí hlavních mřížkových čar
    chart.Axes.HorizontalAxis.MajorGridLinesFormat.Line.FillFormat.FillType = FillType.NoFill;

    for (int i = 0; i < chart.ChartData.Series.Count; i++)
    {
        chart.ChartData.Series.RemoveAt(i);
    }

    IChartSeries series = chart.ChartData.Series[0];

    series.Marker.Symbol = MarkerStyleType.Circle;
    series.Labels.DefaultDataLabelFormat.ShowValue = true;
    series.Labels.DefaultDataLabelFormat.Position = LegendDataLabelPosition.Top;
    series.Marker.Size = 15;

    //Nastavení barvy čáry série
    series.Format.Line.FillFormat.FillType = FillType.Solid;
    series.Format.Line.FillFormat.SolidFillColor.Color = Color.Purple;
    series.Format.Line.DashStyle = LineDashStyle.Solid;

    pres.Save("HideInformationFromChart.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Používají se externí sešity Excelu jako zdroj dat a jak to ovlivňuje přepočet?**

Ano. Graf může odkazovat na externí sešit: když připojíte nebo obnovíte externí zdroj, vzorce a hodnoty jsou převzaty z tohoto sešitu a graf během operací otevření/úpravy odráží aktualizace. API vám umožňuje [specifikovat cestu k externímu sešitu](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdata/setexternalworkbook/) a spravovat propojená data.

**Mohu vypočítat a zobrazit čáry trendu bez implementace regrese sami?**

Ano. [Trendlines](/slides/cs/net/trend-line/) (lineární, exponenciální a další) jsou přidávány a aktualizovány Aspose.Slides; jejich parametry jsou automaticky přepočítány z dat řady, takže nemusíte implementovat vlastní výpočty.

**Pokud má prezentace více grafů s externími odkazy, mohu řídit, který sešit každý graf používá pro vypočtené hodnoty?**

Ano. Každý graf může ukazovat na svůj vlastní [externí sešit](https://reference.aspose.com/slides/cs/net/aspose.slides.charts/chartdata/setexternalworkbook/), nebo můžete pro každý graf samostatně vytvořit/nahrazovat externí sešit nezávisle na ostatních.