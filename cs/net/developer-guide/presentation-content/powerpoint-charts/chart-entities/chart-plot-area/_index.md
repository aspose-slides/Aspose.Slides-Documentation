---
title: Přizpůsobení oblastí vykreslení grafů v prezentacích v .NET
linktitle: Oblast vykreslení
type: docs
url: /cs/net/chart-plot-area/
keywords:
- graf
- oblast vykreslení
- šířka oblasti vykreslení
- výška oblasti vykreslení
- velikost oblasti vykreslení
- režim rozvržení
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte, jak přizpůsobit oblasti vykreslení grafů v prezentacích PowerPoint pomocí Aspose.Slides pro .NET. Zlepšete vizuální vzhled svých snímků snadno."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s oblastí vykreslení grafu v Aspose.Slides. Vysvětluje, jak získat skutečnou polohu a velikost oblasti vykreslení ověřením rozvržení grafu a následným přečtením hodnot X, Y, šířky a výšky.

Také demonstruje, jak nakonfigurovat režim rozvržení oblasti vykreslení, když je rozvržení nastaveno ručně, pomocí `LayoutTargetType` k definování, zda je oblast vykreslení vypočítána podle svého vnitřního regionu nebo podle vnějšího regionu spolu s osami a popisky os.

## **Získání šířky a výšky oblasti vykreslení grafu**
Aspose.Slides pro .NET poskytuje jednoduché API pro .

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Zavolejte metodu IChart.ValidateChartLayout() předtím, abyste získali skutečné hodnoty.
1. Získá skutečnou souřadnici X (levá) prvku grafu relativně k levému hornímu rohu grafu.
1. Získá skutečnou horní souřadnici prvku grafu relativně k levému hornímu rohu grafu.
1. Získá skutečnou šířku prvku grafu.
1. Získá skutečnou výšku prvku grafu.

```c#
using (Presentation pres = new Presentation("test.Pptx"))
{
    Chart chart = (Chart)pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 100, 100, 500, 350);
    chart.ValidateChartLayout();

    double x = chart.PlotArea.ActualX;
    double y = chart.PlotArea.ActualY;
    double w = chart.PlotArea.ActualWidth;
    double h = chart.PlotArea.ActualHeight;
	
	// Uložit prezentaci s grafem
	pres.Save("Chart_out.pptx", SaveFormat.Pptx);
}
```




## **Nastavení režimu rozvržení oblasti vykreslení grafu**
Aspose.Slides pro .NET poskytuje jednoduché API pro nastavení režimu rozvržení oblasti vykreslení grafu. Vlastnost **LayoutTargetType** byla přidána do tříd **ChartPlotArea** a **IChartPlotArea**. Pokud je rozvržení oblasti vykreslení definováno ručně, tato vlastnost určuje, zda rozvrhnout oblast vykreslení podle jejího vnitřku (bez os a popisků os) nebo podle vnějšího okraje (včetně os a popisků os). Existují dvě možné hodnoty, které jsou definovány v enum **LayoutTargetType**.

- **LayoutTargetType.Inner** – určuje, že velikost oblasti vykreslení určuje velikost oblasti vykreslení, aniž by zahrnovala značky a popisky os.
- **LayoutTargetType.Outer** – určuje, že velikost oblasti vykreslení určuje velikost oblasti vykreslení, značky a popisky os.

Ukázkový kód je uveden níže.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.PlotArea.AsILayoutable.X = 0.2f;
    chart.PlotArea.AsILayoutable.Y = 0.2f;
    chart.PlotArea.AsILayoutable.Width = 0.7f;
    chart.PlotArea.AsILayoutable.Height = 0.7f;
    chart.PlotArea.LayoutTargetType = LayoutTargetType.Inner;

    presentation.Save("SetLayoutMode_outer.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**V jakých jednotkách jsou vráceny ActualX, ActualY, ActualWidth a ActualHeight?**

V bodech; 1 palec = 72 bodů. Jedná se o souřadnicové jednotky Aspose.Slides.

**Jak se oblast vykreslení liší od oblasti grafu, pokud jde o obsah?**

Oblast vykreslení je oblast pro vykreslování dat (serií, mřížek, trendových čar atd.); oblast grafu zahrnuje okolní prvky (název, legendu atd.). V 3D grafech oblast vykreslení také zahrnuje stěny/podlahu a osy.

**Jak jsou X, Y, šířka a výška oblasti vykreslení interpretovány při ručním rozvržení?**

Jedná se o zlomky (0–1) celkové velikosti grafu; v tomto režimu je automatické umístění vypnuté a použijí se zadané zlomky.

**Proč se pozice oblasti vykreslení změnila po přidání/přesunutí legendy?**

Legenda se nachází v oblasti grafu mimo oblast vykreslení, ale ovlivňuje rozvržení a dostupný prostor, takže oblast vykreslení může posunout, když je aktivní automatické umístění. (Jedná se o standardní chování grafů v PowerPointu.)