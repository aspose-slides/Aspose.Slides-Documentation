---
title: Přizpůsobení oblastí vykreslení grafů v prezentaci v Pythonu
linktitle: Oblast vykreslení
type: docs
url: /cs/python-net/chart-plot-area/
keywords:
- graf
- oblast vykreslení
- šířka oblasti vykreslení
- výška oblasti vykreslení
- velikost oblasti vykreslení
- režim rozvržení
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Objevte, jak přizpůsobit oblasti vykreslení grafů v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python přes .NET. Zlepšte vizuál svých snímků snadno."
---
## **Přehled**

Tento článek ukazuje, jak pracovat s oblastí vykreslení grafu v Aspose.Slides. Vysvětluje, jak získat skutečnou polohu a velikost oblasti vykreslení validací rozvržení grafu a následným čtením hodnot X, Y, šířky a výšky.

Také ukazuje, jak nastavit režim rozvržení oblasti vykreslení, když je rozvržení nastaveno ručně, pomocí `LayoutTargetType` k určení, zda je oblast vykreslení počítána podle svého vnitřního regionu nebo podle vnějšího regionu spolu s osami a popisky os.

## **Získání šířky a výšky oblasti vykreslení grafu**
Aspose.Slides pro Python přes .NET poskytuje jednoduché API pro . 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Před získáním skutečných hodnot zavolejte metodu IChart.ValidateChartLayout().
1. Získá skutečnou polohu X (levý) prvku grafu relativně k levému hornímu rohu grafu.
1. Získá skutečný horní okraj prvku grafu relativně k levému hornímu rohu grafu.
1. Získá skutečnou šířku prvku grafu.
1. Získá skutečnou výšku prvku grafu.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# Uložit prezentaci s grafem
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Nastavení režimu rozvržení oblasti vykreslení grafu**
Aspose.Slides pro Python přes .NET poskytuje jednoduché API pro nastavení režimu rozvržení oblasti vykreslení grafu. Vlastnost **LayoutTargetType** byla přidána do tříd **ChartPlotArea** a **IChartPlotArea**. Pokud je rozvržení oblasti vykreslení definováno ručně, tato vlastnost určuje, zda rozvržení oblasti vykreslení probíhá podle vnitřní části (bez os a popisků os) nebo podle vnější části (s osami a popisky os). Existují dvě možné hodnoty, které jsou definovány v enumu **LayoutTargetType**.

- **LayoutTargetType.Inner** – určuje, že velikost oblasti vykreslení určuje velikost oblasti vykreslení, aniž by zahrnovala značky os a popisky os.
- **LayoutTargetType.Outer** – určuje, že velikost oblasti vykreslení určuje velikost oblasti vykreslení, značky os i popisky os.

Ukázkový kód je uveden níže.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**V jakých jednotkách jsou vráceny actual_x, actual_y, actual_width a actual_height?**

V bodech; 1 palec = 72 bodů. Jedná se o souřadnicové jednotky Aspose.Slides.

**Jak se oblast vykreslení liší od oblasti grafu z hlediska obsahu?**

Oblast vykreslení je oblast pro kreslení dat (řady, mřížky, čáry trendů apod.); oblast grafu zahrnuje okolní prvky (název, legendu apod.). Ve 3D grafech oblast vykreslení také zahrnuje stěny/podlahu a osy.

**Jak jsou X, Y, šířka a výška oblasti vykreslení interpretovány, když je rozvržení nastaveno ručně?**

Jedná se o zlomky (0–1) celkové velikosti grafu; v tomto režimu je automatické umístění zakázáno a používají se zadané zlomky.

**Proč se pozice oblasti vykreslení změnila po přidání/přesunutí legendy?**

Legenda se nachází v oblasti grafu mimo oblast vykreslení, ale ovlivňuje rozvržení a dostupný prostor, takže oblast vykreslení se může posunout, když je zapnuto automatické umístění. (Jedná se o standardní chování grafů v PowerPointu.)