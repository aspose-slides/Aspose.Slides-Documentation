---
title: Vytvořit nebo aktualizovat grafy PowerPoint prezentace v Pythonu
linktitle: Vytvořit nebo aktualizovat grafy
type: docs
weight: 10
url: /cs/python-net/create-chart/
keywords:
- přidat graf
- vytvořit graf
- upravit graf
- změnit graf
- aktualizovat graf
- rozptylový graf
- koláčový graf
- čarový graf
- stromový mapový graf
- akciový graf
- krabicový a fousový graf
- trychlový graf
- sluneční diagram
- histogramový graf
- radarový graf
- vícekategoriový graf
- PowerPoint prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak vytvářet a přizpůsobovat grafy v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides for Python via .NET. Pokrývá přidávání, formátování a úpravu grafů v prezentacích s praktickými příklady kódu v Pythonu."
---
## **Přehled**

Tento článek vysvětluje, jak vytvářet a přizpůsobovat grafy pomocí Aspose.Slides for Python via .NET. Naučíte se, jak přidat graf do snímku, naplnit jej daty a formátovat jej tak, aby odpovídal vašim požadavkům na design. Příklady kódu pokrývají vytváření prezentací a grafů, konfiguraci řad, os a legend a integraci generování grafů do vašich aplikací.

## **Vytvoření grafu**

Grafy pomáhají lidem rychle vizualizovat data a získávat poznatky, které nemusí být okamžitě zřejmé z tabulky nebo kalkulace.

**Proč vytvářet grafy?**

Používáním grafů můžete:

* agregovat, zhutňovat nebo shrnovat velké množství dat na jednom snímku v prezentaci;
* odhalovat vzory a trendy v datech;
* odhadovat směr a dynamiku dat v čase nebo vzhledem k konkrétní jednotce měření;
* identifikovat odlehlé hodnoty, odchylky, chyby a nesmyslná data;
* komunikovat nebo prezentovat složitá data.

V PowerPointu můžete vytvářet grafy pomocí funkce *Insert*, která poskytuje šablony pro navrhování mnoha typů grafů. Pomocí Aspose.Slides můžete vytvořit jak běžné grafy (založené na populárních typech grafů), tak i vlastní grafy.

{{% alert color="info" title="Note" %}}
Použijte výčtový typ [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) v rámci jmenného prostoru [Aspose.Slides.Charts](https://reference.aspose.com/slides/python-net/aspose.slides.charts/). Hodnoty v tomto výčtu odpovídají různým typům grafů.
{{% /alert %}}

### **Vytvoření seskupených sloupcových grafů**

Tato sekce popisuje, jak pomocí Aspose.Slides for Python via .NET vytvořit seskupené sloupcové grafy. Naučíte se inicializovat prezentaci, přidat graf a přizpůsobit jeho prvky, jako jsou název, data, řady, kategorie a stylování. Postupujte podle níže uvedených kroků a uvidíte, jak se vygeneruje standardní seskupený sloupcový graf:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s nějakými daty a určete typ `ChartType.CLUSTERED_COLUMN`.
1. Přidejte název grafu.
1. Získejte přístup k datovému listu grafu.
1. Vymažte všechny výchozí řady a kategorie.
1. Přidejte nové řady a kategorie.
1. Přidejte nová data do řady grafu.
1. Použijte barvu výplně pro řadu grafu.
1. Přidejte popisky k řadě grafu.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento Python kód ukazuje, jak vytvořit seskupený sloupcový graf:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

    # Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
    with slides.Presentation() as presentation:

        # Získejte první snímek.
        slide = presentation.slides[0]

        # Přidejte seskupený sloupcový graf s výchozími daty.
        chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

        # Nastavte název grafu.
        chart.chart_title.add_text_frame_for_overriding("Sample Title")
        chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
        chart.chart_title.height = 20
        chart.has_title = True

        # Nastavte index datového listu grafu.
        worksheet_index = 0

        # Získejte sešit dat grafu.
        workbook = chart.chart_data.chart_data_workbook

        # Odstraňte výchozí generované řady a kategorie.
        chart.chart_data.series.clear()
        chart.chart_data.categories.clear()

        # Přidejte nové řady.
        chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Series 1"), chart.type)
        chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Series 2"), chart.type)

        # Přidejte nové kategorie.
        chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
        chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
        chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))

        # Získejte první řadu grafu.
        series = chart.chart_data.series[0]

        # Naplněte data řady.
        series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 20))
        series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 50))
        series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 30))

        # Nastavte barvu výplně pro řadu.
        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = draw.Color.red

        # Získejte druhou řadu grafu.
        series = chart.chart_data.series[1]

        # Naplněte data řady.
        series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 30))
        series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 10))
        series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 60))

        # Nastavte barvu výplně pro řadu.
        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = draw.Color.green

        # Nastavte první popisek tak, aby zobrazoval název kategorie.
        label = series.data_points[0].label
        label.data_label_format.show_category_name = True

        label = series.data_points[1].label
        label.data_label_format.show_series_name = True

        # Nastavte řadu tak, aby pro třetí popisek zobrazovala hodnotu.
        label = series.data_points[2].label
        label.data_label_format.show_value = True
        label.data_label_format.show_series_name = True
        label.data_label_format.separator = "/"
                    
        # Uložte prezentaci na disk jako soubor PPTX.
        presentation.save("ClusteredColumnChart.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Seskupený sloupcový graf](clustered_column_chart.png)

### **Vytvoření rozptylových grafů**

Rozptylové grafy (známé také jako rozptylové diagramy nebo x‑y grafy) se často používají k ověření vzorů nebo ukázání korelací mezi dvěma proměnnými.

Použijte rozptylový graf, když:

* Máte párová číselná data.
* Máte dvě proměnné, které se dobře doplňují.
* Chcete zjistit, zda jsou dvě proměnné navzájem spojeny.
* Máte nezávislou proměnnou, která má pro závislou proměnnou více hodnot.

Tento Python kód ukazuje, jak vytvořit rozptylový graf s různými značkami pro každou řadu:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Vytvořte výchozí rozptylový graf.
    chart = slide.shapes.add_chart(charts.ChartType.SCATTER_WITH_SMOOTH_LINES, 20, 20, 500, 300)

    # Nastavte index datového listu grafu.
    worksheet_index = 0

    # Získejte sešit dat grafu.
    workbook = chart.chart_data.chart_data_workbook

    # Odstraňte výchozí řadu.
    chart.chart_data.series.clear()

    # Přidejte nové řady.
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(worksheet_index, 1, 3, "Series 2"), chart.type)

    # Získejte první řadu grafu.
    series = chart.chart_data.series[0]

    # Přidejte nový bod (1:3) do řady.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 1, 1), workbook.get_cell(worksheet_index, 2, 2, 3))

    # Přidejte nový bod (2:10).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 1, 2), workbook.get_cell(worksheet_index, 3, 2, 10))

    # Změňte typ řady.
    series.type = charts.ChartType.SCATTER_WITH_STRAIGHT_LINES_AND_MARKERS

    # Změňte značku řady grafu.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.STAR

    # Získejte druhou řadu grafu.
    series = chart.chart_data.series[1]

    # Přidejte nový bod (5:2) do řady grafu.
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 2, 3, 5), workbook.get_cell(worksheet_index, 2, 4, 2))

    # Přidejte nový bod (3:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 3, 3, 3), workbook.get_cell(worksheet_index, 3, 4, 1))

    # Přidejte nový bod (2:2).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 4, 3, 2), workbook.get_cell(worksheet_index, 4, 4, 2))

    # Přidejte nový bod (5:1).
    series.data_points.add_data_point_for_scatter_series(workbook.get_cell(worksheet_index, 5, 3, 5), workbook.get_cell(worksheet_index, 5, 4, 1))

    # Změňte značku řady grafu.
    series.marker.size = 10
    series.marker.symbol = charts.MarkerStyleType.CIRCLE

    presentation.save("ScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Rozptylový graf](scatter_chart.png)

### **Vytvoření koláčových grafů**

Koláčové grafy jsou nejvhodnější pro zobrazení vztahu část‑celku v datech, zejména když data obsahují kategorické štítky s číselnými hodnotami. Pokud však data obsahují mnoho částí nebo štítků, můžete zvážit použití sloupcového grafu.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a určete typ `ChartType.PIE`.
1. Získejte přístup k sešitu dat grafu ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Vymažte výchozí řady a kategorie.
1. Přidejte nové řady a kategorie.
1. Přidejte nová data do řady grafu.
1. Přidejte nové body do grafu a použijte vlastní barvy na sektory koláčového grafu.
1. Nastavte popisky pro řady.
1. Povolte čáry ukazatele pro popisky řad.
1. Nastavte úhel otáčení koláčového grafu.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento Python kód ukazuje, jak vytvořit koláčový graf:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
with slides.Presentation() as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    # Přidejte graf s výchozími daty.
    chart = slide.shapes.add_chart(charts.ChartType.PIE, 20, 20, 500, 300)

    # Nastavte název grafu.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Nastavte index datového listu grafu.
    worksheet_index = 0

    # Získejte sešit dat grafu.
    workbook = chart.chart_data.chart_data_workbook

    # Odstraňte výchozí generované řady a kategorie.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    # Přidejte nové kategorie.
    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "First Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "2nd Qtr"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "3rd Qtr"))

    # Přidejte nové řady.
    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    # Naplněte data řady.
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 1, 1, 20))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 2, 1, 50))
    series.data_points.add_data_point_for_pie_series(workbook.get_cell(worksheet_index, 3, 1, 30))

    # Nastavte barvu sektoru.
    chart.chart_data.series_groups[0].is_color_varied = True

    point = series.data_points[0]
    point.format.fill.fill_type = slides.FillType.SOLID
    point.format.fill.solid_fill_color.color = draw.Color.cyan

    # Nastavte ohraničení sektoru.
    point.format.line.fill_format.fill_type = slides.FillType.SOLID
    point.format.line.fill_format.solid_fill_color.color = draw.Color.gray
    point.format.line.width = 3.0
    point.format.line.style = slides.LineStyle.THIN_THICK
    point.format.line.dash_style = slides.LineDashStyle.DASH_DOT

    point1 = series.data_points[1]
    point1.format.fill.fill_type = slides.FillType.SOLID
    point1.format.fill.solid_fill_color.color = draw.Color.brown

    # Nastavte ohraničení sektoru.
    point1.format.line.fill_format.fill_type = slides.FillType.SOLID
    point1.format.line.fill_format.solid_fill_color.color = draw.Color.blue
    point1.format.line.width = 3.0
    point1.format.line.style = slides.LineStyle.SINGLE
    point1.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT

    point2 = series.data_points[2]
    point2.format.fill.fill_type = slides.FillType.SOLID
    point2.format.fill.solid_fill_color.color = draw.Color.coral

    # Nastavte ohraničení sektoru.
    point2.format.line.fill_format.fill_type = slides.FillType.SOLID
    point2.format.line.fill_format.solid_fill_color.color = draw.Color.red
    point2.format.line.width = 2.0
    point2.format.line.style = slides.LineStyle.THIN_THIN
    point2.format.line.dash_style = slides.LineDashStyle.LARGE_DASH_DOT_DOT

    # Vytvořte vlastní popisky pro každou kategorii v nové řadě.
    label1 = series.data_points[0].label

    label1.data_label_format.show_value = True

    label2 = series.data_points[1].label
    label2.data_label_format.show_value = True
    label2.data_label_format.show_legend_key = True
    label2.data_label_format.show_percentage = True

    label3 = series.data_points[2].label
    label3.data_label_format.show_series_name = True
    label3.data_label_format.show_percentage = True

    # Nastavte řadu tak, aby zobrazovala čáry ukazatele pro graf.
    series.labels.default_data_label_format.show_leader_lines = True

    # Nastavte úhel otáčení sektorů koláčového grafu.
    chart.chart_data.series_groups[0].first_slice_angle = 180

    # Uložte prezentaci na disk jako soubor PPTX.
    presentation.save("PieChart.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Koláčový graf](pie_chart.png)

### **Vytvoření čarových grafů**

Čarové grafy (známé také jako čárové diagramy) jsou nejvhodnější v situacích, kdy chcete ukázat změny hodnot v čase. Pomocí čarového grafu můžete porovnat velké množství dat najednou, sledovat změny a trendy v čase, zvýraznit anomálie v řadách dat a další.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a určete typ `ChartType.LINE`.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento Python kód ukazuje, jak vytvořit čarový graf:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 20, 20, 500, 300)
    
    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

Ve výchozím nastavení jsou body v čarovém grafu spojeny rovnými souvislými čarami. Pokud chcete, aby byly body spojeny čárkovanými čarami, můžete specifikovat požadovaný typ čárky následovně:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    line_chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.LINE, 10, 50, 600, 350)

    for series in line_chart.chart_data.series:
        series.format.line.dash_style = slides.LineDashStyle.DASH

    presentation.save("LineChart.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Čarový graf](line_chart.png)

### **Vytvoření stromových mapových grafů**

Stromové mapové grafy jsou nejvhodnější pro prodejní data, když chcete zobrazit relativní velikost kategorií a rychle upozornit na položky, které jsou velkými přispěvateli v rámci každé kategorie.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a určete typ `ChartType.TREEMAP`.
1. Získejte přístup k sešitu dat grafu ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Vymažte výchozí řady a kategorie.
1. Přidejte nové řady a kategorie.
1. Přidejte nová data do řady grafu.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento Python kód ukazuje, jak vytvořit stromový mapový graf:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.TREEMAP, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Větev 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Větev 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.TREEMAP)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_treemap_series(workbook.get_cell(0, "D8", 3))

    series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING

    presentation.save("TreeMap.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Stromový mapový graf](treemap_chart.png)

### **Vytvoření akciových grafů**

Akciové grafy se používají k zobrazení finančních údajů, jako jsou otevírací, nejvyšší, nejnižší a závěrečné ceny, což pomáhá analyzovat tržní trendy a volatilitu. Poskytují klíčové poznatky o výkonnosti akcií a pomáhají investorům a analytikům činit informovaná rozhodnutí.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a určete typ `ChartType.OPEN_HIGH_LOW_CLOSE`.
1. Získejte přístup k sešitu dat grafu ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Vymažte výchozí řady a kategorie.
1. Přidejte nové řady a kategorie.
1. Přidejte nová data do řady grafu.
1. Určete formát čar vysokých a nízkých hodnot.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento Python kód ukazuje, jak vytvořit akciový graf:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.OPEN_HIGH_LOW_CLOSE, 20, 20, 500, 300, False)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "A"))
    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "B"))
    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C"))

    chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Open"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "High"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 3, "Low"), chart.type)
    chart.chart_data.series.add(workbook.get_cell(0, 0, 4, "Close"), chart.type)

    series = chart.chart_data.series[0]

    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 1, 72))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 1, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 1, 38))

    series = chart.chart_data.series[1]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 2, 172))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 2, 57))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 2, 57))

    series = chart.chart_data.series[2]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 3, 12))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 3, 13))

    series = chart.chart_data.series[3]
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 1, 4, 25))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 2, 4, 38))
    series.data_points.add_data_point_for_stock_series(workbook.get_cell(0, 3, 4, 50))

    chart.chart_data.series_groups[0].up_down_bars.has_up_down_bars = True
    chart.chart_data.series_groups[0].hi_low_lines_format.line.fill_format.fill_type = slides.FillType.SOLID

    for ser in chart.chart_data.series:
        ser.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("StockChart.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Akciový graf](stock_chart.png)

### **Vytvoření krabicových a fousových grafů**

Krabicové a fousové grafy se používají k zobrazení rozdělení dat shrnutím klíčových statistických měření, jako jsou medián, kvartily a potenciální odlehlé hodnoty. Jsou zvláště užitečné při průzkumné analýze dat a statistických studiích pro rychlé pochopení variability dat a identifikaci anomálií.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a určete typ `ChartType.BOX_AND_WHISKER`.
1. Získejte přístup k sešitu dat grafu ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Vymažte výchozí řady a kategorie.
1. Přidejte nové řady a kategorie.
1. Přidejte nová data do řady grafu.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento Python kód ukazuje, jak vytvořit krabicový a fousový graf:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BOX_AND_WHISKER, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 1"))

    series = chart.chart_data.series.add(charts.ChartType.BOX_AND_WHISKER)

    series.quartile_method = charts.QuartileMethodType.EXCLUSIVE
    series.show_mean_line = True
    series.show_mean_markers = True
    series.show_inner_points = True
    series.show_outlier_points = True

    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B1", 15))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B2", 41))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B3", 16))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B4", 10))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B5", 23))
    series.data_points.add_data_point_for_box_and_whisker_series(workbook.get_cell(0, "B6", 16))

    presentation.save("BoxAndWhiskerChart.pptx", slides.export.SaveFormat.PPTX)
```

### **Vytvoření trychlových grafů**

Trychlové grafy se používají k vizualizaci procesů, které zahrnují sekvenční fáze, kde objem dat klesá s postupem od jednoho kroku k dalšímu. Jsou zvláště užitečné pro analýzu konverzních poměrů, identifikaci úzkých míst a sledování efektivity prodejních nebo marketingových procesů.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a určete typ `ChartType.FUNNEL`.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento Python kód ukazuje, jak vytvořit trychlový graf:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.FUNNEL, 50, 50, 500, 400)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    chart.chart_data.categories.add(workbook.get_cell(0, "A1", "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A2", "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A3", "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A4", "Category 4"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A5", "Category 5"))
    chart.chart_data.categories.add(workbook.get_cell(0, "A6", "Category 6"))

    series = chart.chart_data.series.add(charts.ChartType.FUNNEL)

    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B1", 50))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B2", 100))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B3", 200))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B4", 300))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B5", 400))
    series.data_points.add_data_point_for_funnel_series(workbook.get_cell(0, "B6", 500))

    presentation.save("FunnelChart.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Trychlový graf](funnel_chart.png)

### **Vytvoření slunečních diagramů**

Sluneční diagramy se používají k vizualizaci hierarchických dat, zobrazujících úrovně jako soustředné kruhy. Pomáhají ilustrovat vztahy část‑celku a jsou ideální pro reprezentaci vnořených kategorií a podkategorií přehledně a kompaktně.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a určete typ `ChartType.SUNBURST`.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento Python kód ukazuje, jak vytvořit sluneční diagram:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.SUNBURST, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Větev 1
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C1", "Leaf1"))
    leaf.grouping_levels.set_grouping_item(1, "Stem1")
    leaf.grouping_levels.set_grouping_item(2, "Branch1")

    chart.chart_data.categories.add(workbook.get_cell(0, "C2", "Leaf2"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C3", "Leaf3"))
    leaf.grouping_levels.set_grouping_item(1, "Stem2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C4", "Leaf4"))

    # Větev 2
    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C5", "Leaf5"))
    leaf.grouping_levels.set_grouping_item(1, "Stem3")
    leaf.grouping_levels.set_grouping_item(2, "Branch2")

    chart.chart_data.categories.add(workbook.get_cell(0, "C6", "Leaf6"))

    leaf = chart.chart_data.categories.add(workbook.get_cell(0, "C7", "Leaf7"))
    leaf.grouping_levels.set_grouping_item(1, "Stem4")

    chart.chart_data.categories.add(workbook.get_cell(0, "C8", "Leaf8"))

    series = chart.chart_data.series.add(charts.ChartType.SUNBURST)
    series.labels.default_data_label_format.show_category_name = True
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D1", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D2", 5))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D3", 3))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D4", 6))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D5", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D6", 9))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D7", 4))
    series.data_points.add_data_point_for_sunburst_series(workbook.get_cell(0, "D8", 3))

    presentation.save("SunburstChart.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Sluneční diagram](sunburst_chart.png)

### **Vytvoření histogramových grafů**

Histogramové grafy se používají k reprezentaci rozdělení číselných dat seskupením hodnot do intervalů nebo košů. Jsou zvláště užitečné pro identifikaci vzorů v datech, jako jsou četnost, zkosení a rozptyl, a pro odhalování odlehlých hodnot v datové sadě.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s některými daty a určete typ `ChartType.HISTOGRAM`.
1. Získejte přístup k sešitu dat grafu ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Vymažte výchozí řady a kategorie.
1. Přidejte novou řadu a naplňte ji datovými body. Histogram nemá kategorie; koše jsou vypočítány z hodnot.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento Python kód ukazuje, jak vytvořit histogramový graf:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.HISTOGRAM, 20, 20, 500, 300)
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.HISTOGRAM)
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A1", 15))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A2", -41))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A3", 16))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A4", 10))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A5", -23))
    series.data_points.add_data_point_for_histogram_series(workbook.get_cell(0, "A6", 16))

    chart.axes.horizontal_axis.aggregation_type = charts.AxisAggregationType.AUTOMATIC

    presentation.save("HistogramChart.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Histogram](histogram_chart.png)

### **Vytvoření radarových grafů**

Radarové grafy se používají k zobrazení multivariačních dat ve dvourozměrném formátu, což umožňuje snadné porovnání několika proměnných současně. Jsou zvláště užitečné pro identifikaci vzorů, silných a slabých stránek napříč více měřítky výkonnosti nebo atributy.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s některými daty a určete typ `ChartType.RADAR`.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento Python kód ukazuje, jak vytvořit radarový graf:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides[0].shapes.add_chart(slides.charts.ChartType.RADAR, 20, 20, 500, 300)
    presentation.save("RadarChart.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Radarový graf](radar_chart.png)

### **Vytvoření vícekategoriových grafů**

Vícekategoriové grafy se používají k zobrazení dat, která zahrnují více než jednu kategorickou skupinu, což umožňuje porovnat hodnoty napříč více dimenzemi současně. Jsou zvláště užitečné při analýze trendů a vztahů v komplexních, vícevrstvých datových sadách.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) .
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přidejte graf s výchozími daty a určete typ `ChartType.CLUSTERED_COLUMN`.
1. Získejte přístup k sešitu dat grafu ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)).
1. Vymažte výchozí řady a kategorie.
1. Přidejte nové řady a kategorie.
1. Přidejte nová data do řady grafu.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento Python kód ukazuje, jak vytvořit vícekategoriový graf:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    worksheet_index = 0

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c2", "A"))
    category.grouping_levels.set_grouping_item(1, "Group1")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c3", "B"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c4", "C"))
    category.grouping_levels.set_grouping_item(1, "Group2")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c5", "D"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c6", "E"))
    category.grouping_levels.set_grouping_item(1, "Group3")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c7", "F"))

    category = chart.chart_data.categories.add(workbook.get_cell(0, "c8", "G"))
    category.grouping_levels.set_grouping_item(1, "Group4")
    category = chart.chart_data.categories.add(workbook.get_cell(0, "c9", "H"))

    # Přidejte řadu.
    series = chart.chart_data.series.add(workbook.get_cell(0, "D1", "Series 1"), charts.ChartType.CLUSTERED_COLUMN)

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D2", 10))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D3", 20))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D4", 30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D5", 40))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D6", 50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D7", 60))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D8", 70))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, "D9", 80))

    # Uložte prezentaci s grafem.
    presentation.save("MultiCategoryChart.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Vícekategoriový graf](multi_category_chart.png)

### **Vytvoření mapových grafů**

Mapové grafy se používají k vizualizaci geografických dat mapováním informací na konkrétní místa, jako jsou země, státy nebo města. Jsou zvláště užitečné pro analýzu regionálních trendů, demografických dat a prostorových rozložení v jasném, vizuálně atraktivním formátu.

Tento Python kód ukazuje, jak vytvořit mapový graf:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    chart = presentation.slides[0].shapes.add_chart(slides.charts.ChartType.MAP, 20, 20, 500, 300)
    presentation.save("mapChart.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![Mapový graf](map_chart.png)

### **Vytvoření kombinovaných grafů**

Kombinovaný graf (nebo combo graf) kombinuje dva nebo více typů grafů v jednom diagramu. Tento graf vám umožní zvýraznit, porovnat nebo prozkoumat rozdíly mezi dvěma nebo více datovými sadami, což pomáhá identifikovat vztahy mezi nimi.

![Kombinovaný graf](combination_chart.png)

Následující Python kód ukazuje, jak vytvořit výše uvedený kombinovaný graf v PowerPoint prezentaci:

```python
import aspose.slides.charts as charts
import aspose.pydrawing as draw
import aspose.slides as slides

def create_combo_chart():
    with slides.Presentation() as presentation:
        chart = create_chart_with_first_series(presentation.slides[0])

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", slides.export.SaveFormat.PPTX)


def create_chart_with_first_series(slide):
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    # Nastavte název grafu.
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Chart Title")
    chart.chart_title.overlay = False
    title_paragraph = chart.chart_title.text_frame_for_overriding.paragraphs[0]
    title_format = title_paragraph.paragraph_format.default_portion_format

    title_format.font_bold = slides.NullableBool.FALSE
    title_format.font_height = 18

    # Nastavte legendu grafu.
    chart.legend.position = charts.LegendPositionType.BOTTOM
    chart.legend.text_format.portion_format.font_height = 12

    # Odstraňte výchozí generované řady a kategorie.
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    worksheet_index = 0
    workbook = chart.chart_data.chart_data_workbook

    # Přidejte nové kategorie.
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 1, 0, "Category 1"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 2, 0, "Category 2"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 3, 0, "Category 3"))
    chart.chart_data.categories.add(workbook.get_cell(worksheet_index, 4, 0, "Category 4"))

    # Přidejte první řadu.
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 4.3))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 2.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 3.5))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 4.5))

    return chart


def add_second_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 2, "Series 2")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.CLUSTERED_COLUMN)

    series.parent_series_group.overlap = -25
    series.parent_series_group.gap_width = 220

    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 2.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 4.4))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 1.8))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 2.8))


def add_third_series_to_chart(chart):
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Series 3")
    series = chart.chart_data.series.add(series_name_cell, charts.ChartType.LINE)

    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 1, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 2, 3, 2.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 3, 3, 3.0))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(worksheet_index, 4, 3, 5.0))

    series.plot_on_second_axis = True


def set_primary_axes_format(chart):
    # Nastavte vodorovnou osu.
    horizontal_axis = chart.axes.horizontal_axis
    horizontal_axis.text_format.portion_format.font_height = 12.0
    horizontal_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(horizontal_axis, "X Axis")

    # Nastavte svislou osu.
    vertical_axis = chart.axes.vertical_axis
    vertical_axis.text_format.portion_format.font_height = 12.0
    vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(vertical_axis, "Y Axis 1")

    # Nastavte barvu hlavních mřížek na svislé ose.
    major_grid_lines_format = vertical_axis.major_grid_lines_format.line.fill_format
    major_grid_lines_format.fill_type = slides.FillType.SOLID
    major_grid_lines_format.solid_fill_color.color = draw.Color.from_argb(217, 217, 217)


def set_secondary_axes_format(chart):
    # Nastavte sekundární vodorovnou osu.
    secondary_horizontal_axis = chart.axes.secondary_horizontal_axis
    secondary_horizontal_axis.position = charts.AxisPositionType.BOTTOM
    secondary_horizontal_axis.cross_type = charts.CrossesType.MAXIMUM
    secondary_horizontal_axis.is_visible = False
    secondary_horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_horizontal_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    # Nastavte sekundární svislou osu.
    secondary_vertical_axis = chart.axes.secondary_vertical_axis
    secondary_vertical_axis.position = charts.AxisPositionType.RIGHT
    secondary_vertical_axis.text_format.portion_format.font_height = 12.0
    secondary_vertical_axis.format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL
    secondary_vertical_axis.minor_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    set_axis_title(secondary_vertical_axis, "Y Axis 2")


def set_axis_title(axis, axis_title):
    axis.has_title = True
    axis.title.overlay = False
    title_portion_format = axis.title.add_text_frame_for_overriding(axis_title).paragraphs[0].paragraph_format.default_portion_format
    title_portion_format.font_bold = slides.NullableBool.FALSE
    title_portion_format.font_height = 12.0
```

## **Aktualizace grafů**

Aspose.Slides for Python via .NET vám umožňuje aktualizovat data grafu, formátování a stylování, aby vaše PowerPoint prezentace zůstaly aktuální.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pro otevření prezentace obsahující graf.
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Procházejte všechny tvary a najděte graf.
1. Získejte přístup k datovému listu grafu.
1. Modifikujte řadu dat grafu změnou hodnot řady.
1. Přidejte novou řadu a naplňte ji daty.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento Python kód ukazuje, jak aktualizovat graf:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape

            # Nastavte index listu s daty grafu.
            worksheet_index = 0

            # Získejte sešit dat grafu.
            workbook = chart.chart_data.chart_data_workbook

            # Změňte názvy kategorií grafu.
            workbook.get_cell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.get_cell(worksheet_index, 2, 0, "Modified Category 2")

            # Získejte první řadu grafu.
            series = chart.chart_data.series[0]

            # Aktualizujte data řady.
            workbook.get_cell(worksheet_index, 0, 1, "New_Series1")  # Úprava názvu řady.
            series.data_points[0].value.data = 90
            series.data_points[1].value.data = 123
            series.data_points[2].value.data = 44

            # Získejte druhou řadu grafu.
            series = chart.chart_data.series[1]

            # Aktualizujte data řady.
            workbook.get_cell(worksheet_index, 0, 2, "New_Series2")  # Úprava názvu řady.
            series.data_points[0].value.data = 23
            series.data_points[1].value.data = 67
            series.data_points[2].value.data = 99

            # Přidejte novou řadu.
            series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 3, "Series 3"), chart.type)

            # Naplněte data řady.
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 3, 20))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 3, 50))
            series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 3, 30))

            chart.type = charts.ChartType.CLUSTERED_CYLINDER

            # Uložte prezentaci s grafem.
            presentation.save("ModifiedChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení rozsahu dat pro graf**

Chcete-li zkontrolovat rozsah již použitý existujícím grafem, viz [Získání rozsahu dat grafu](/slides/cs/python-net/chart-workbook/#retrieve-a-charts-data-range).

Aspose.Slides for Python via .NET vám umožňuje použít konkrétní rozsah listu jako zdroj dat pro graf. Tím řídíte, které buňky dodávají řady a kategorie grafu, a můžete aktualizovat graf tak, aby odrážel změny v listu.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pro otevření prezentace obsahující graf.
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Procházejte všechny tvary a najděte graf.
1. Přistupte k datům grafu a nastavte rozsah.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento Python kód ukazuje, jak nastavit rozsah dat pro graf:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

chart_name = "My chart"

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX.
with slides.Presentation("ExistingChart.pptx") as presentation:

    # Získejte první snímek.
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.name == chart_name:
            chart = shape
            chart.chart_data.set_range("Sheet1!A1:B4")

    presentation.save("DataRange.pptx", slides.export.SaveFormat.PPTX)
```

## **Použití výchozích značek v grafech**

Když používáte výchozí značky v grafech, každá řada grafu automaticky získá jiný symbol značky.

Tento Python kód ukazuje, jak automaticky nastavit značku řady grafu:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 10, 10, 400, 400)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    series = chart.chart_data.series.add(workbook.get_cell(0, 0, 1, "Series 1"), chart.type)

    chart.chart_data.categories.add(workbook.get_cell(0, 1, 0, "C1"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 1, 24))

    chart.chart_data.categories.add(workbook.get_cell(0, 2, 0, "C2"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 1, 23))

    chart.chart_data.categories.add(workbook.get_cell(0, 3, 0, "C3"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 1, -10))

    chart.chart_data.categories.add(workbook.get_cell(0, 4, 0, "C4"))
    series.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 1, None))

    series2 = chart.chart_data.series.add(workbook.get_cell(0, 0, 2, "Series 2"), chart.type)

    # Naplňte data řady.
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 1, 2, 30))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 2, 2, 10))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 3, 2, 60))
    series2.data_points.add_data_point_for_line_series(workbook.get_cell(0, 4, 2, 40))

    chart.has_legend = True
    chart.legend.overlay = False

    presentation.save("DefaultMarkersInChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Jaké typy grafů podporuje Aspose.Slides for Python via .NET?**

Aspose.Slides for Python via .NET podporuje širokou škálu typů grafů, včetně sloupcových, čarových, koláčových, plošných, rozptylových, histogramových, radarových a mnoha dalších. Tato flexibilita vám umožní vybrat nejvhodnější typ grafu pro potřeby vizualizace vašich dat.

**Jak přidám nový graf do snímku?**

Pro přidání grafu nejprve vytvoříte instanci třídy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/), získáte požadovaný snímek pomocí jeho indexu a poté zavoláte metodu pro přidání grafu, přičemž určíte typ grafu a počáteční data. Tento proces integruje graf přímo do vaší prezentace.

**Jak mohu aktualizovat data zobrazená v grafu?**

Data grafu můžete aktualizovat tím, že získáte přístup k jeho sešitu dat ([ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/)), vymažete výchozí řady a kategorie a poté přidáte vlastní data. To vám umožní programově obnovit graf tak, aby odrážel nejnovější data.

**Je možné přizpůsobit vzhled grafu?**

Ano, Aspose.Slides for Python via .NET poskytuje rozsáhlé možnosti přizpůsobení. Můžete měnit barvy, písma, popisky, legendy a další formátovací prvky, abyste graf přizpůsobili konkrétním požadavkům na design.