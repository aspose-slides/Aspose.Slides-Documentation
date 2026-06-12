---
title: Přizpůsobení datových bodů v grafech Treemap a Sunburst v Pythonu
linktitle: Datové body v grafech Treemap a Sunburst
type: docs
url: /cs/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- graf Treemap
- graf Sunburst
- datový bod
- barva popisku
- barva větve
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak spravovat datové body v grafech Treemap a Sunburst pomocí Aspose.Slides pro Python přes .NET, kompatibilní s formáty PowerPoint a OpenDocument."
---
## **Úvod**

Mezi ostatními typy grafů v PowerPointu existují dva hierarchické — **Treemap** a **Sunburst** (také známé jako Sunburst Graph, Sunburst Diagram, Radial Chart, Radial Graph nebo Multi-Level Pie Chart). Tyto grafy zobrazují hierarchická data uspořádaná jako strom – od listů až po vrchol větve. Listy jsou definovány datovými body řady a každá následná vnořená úroveň skupiny je definována odpovídající kategorií. Aspose.Slides for Python via .NET umožňuje v Pythonu formátovat datové body grafů Sunburst a Treemap.

Zde je graf Sunburst, kde data ve sloupci Series1 definují listové uzly, zatímco ostatní sloupce definují hierarchické datové body:

![Příklad grafu Sunburst](sunburst_example.png)

Začněme přidáním nového grafu Sunburst do prezentace:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="Viz také" %}}
- [**Vytvořit Sunburst grafy**](/slides/cs/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Pokud potřebujete formátovat datové body grafu, použijte následující rozhraní API:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapointlevel/) a vlastnost [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/). Poskytují přístup k formátování datových bodů v grafech Treemap a Sunburst. [ChartDataPointLevelsManager] se používá pro přístup k vícestupňovým kategoriím; představuje kontejner objektů [ChartDataPointLevel]. Ve skutečnosti jde o obálku kolem [ChartCategoryLevelsManager] s dalšími vlastnostmi specifickými pro datové body. Typ [ChartDataPointLevel] vystavuje dvě vlastnosti — [format] a [label] — které poskytují přístup k odpovídajícím nastavením.

## **Zobrazení hodnot datových bodů**

Tato sekce ukazuje, jak zobrazit hodnotu jednotlivých datových bodů v grafech Treemap a Sunburst. Ukážeme, jak povolit popisky hodnot pro vybrané body.

Zobrazte hodnotu datového bodu „Leaf 4“:

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Hodnota datového bodu](data_point_value.png)

## **Nastavení popisků a barev pro datové body**

Tato sekce ukazuje, jak nastavit vlastní popisky a barvy pro jednotlivé datové body v grafech Treemap a Sunburst. Naučíte se, jak získat konkrétní datový bod, přiřadit mu popisek a aplikovat plnou výplň pro zvýraznění důležitých uzlů.

Nastavte popisek dat „Branch 1“ tak, aby zobrazoval název řady („Series1“) místo názvu kategorie, a potom nastavte barvu textu na žlutou:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Popisek a barva datového bodu](data_point_color.png)

## **Nastavení barev větví pro datové body**

Použijte barvy větví k řízení vizuálního seskupení rodičovských a podřízených uzlů v grafech Treemap a Sunburst. Tato sekce ukazuje, jak nastavit vlastní barvu větve pro konkrétní datový bod, abyste mohli zvýraznit důležité podstromy a zlepšit čitelnost grafu.

Změňte barvu větve „Stem 4“:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```

![Barva větve](branch_color.png)

## **Často kladené otázky**

**Mohu změnit pořadí (třídění) segmentů v Sunburst/Treemap?**

Ne. PowerPoint segmenty řadí automaticky (obvykle sestupně podle hodnot, po směru hodinových ručiček). Aspose.Slides tento chování napodobuje: pořadí nelze změnit přímo; dosáhnete toho předzpracováním dat.

**Jak ovlivňuje téma prezentace barvy segmentů a popisků?**

Barvy grafu dědí téma/paletu prezentace (/slides/cs/python-net/presentation-theme/), pokud výslovně nenastavíte výplně/písma. Pro konzistentní výsledek zamkněte plné výplně a formátování textu na požadovaných úrovních.

**Zachová se při exportu do PDF/PNG vlastní barva větve a nastavení popisků?**

Ano. Při exportu prezentace jsou nastavení grafu (výplně, popisky) zachována v výstupních formátech, protože Aspose.Slides vykresluje s aplikovaným formátováním grafu.

**Mohu vypočítat skutečné souřadnice popisku/elementu pro vlastní umístění překrytí nad grafem?**

Ano. Po ověření rozvržení grafu jsou k dispozici `actual_x`/`actual_y` pro elementy (například pro [DataLabel](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datalabel/)), což usnadňuje přesné umístění překrytí.