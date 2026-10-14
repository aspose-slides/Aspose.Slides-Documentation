---
title: Přizpůsobení výsečových grafů v prezentacích pomocí Pythonu
linktitle: Výsečový graf
type: docs
url: /cs/python-net/pie-chart/
keywords:
- výsečový graf
- správa grafu
- přizpůsobení grafu
- možnosti grafu
- nastavení grafu
- možnosti vykreslení
- barva výseče
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte výsečové grafy v Pythonu s Aspose.Slides. Nakonfigurujte sekundární diagramy, zobrazte popisky dat a použijte automatické barvy výsečí v PowerPointu."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s výsečovými grafy v Aspose.Slides. Ukazuje, jak nakonfigurovat možnosti sekundárního diagramu pro grafy Pie of Pie a Bar of Pie a jak povolit automatické barvení výsečí u standardního výsečového grafu.

Příklady se zaměřují na úkoly přizpůsobení grafu, jako je přidání grafu na snímek, úprava nastavení řad a popisků, nahrazení výchozích dat grafu vlastními kategoriemi a hodnotami a uložení aktualizované prezentace.

## **Možnosti sekundárního diagramu pro grafy Pie of Pie a Bar of Pie**

Aspose.Slides for Python via .NET podporuje možnosti sekundárního diagramu pro grafy Pie of Pie a Bar of Pie. Tyto možnosti řídí velikost sekundárního diagramu a způsob, jakým jsou datové body rozděleny mezi oba diagramy.

Následující příklad vytváří graf Pie of Pie v nové prezentaci a zobrazuje hodnoty datových bodů jako popisky. Vlastnost [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) nastavuje velikost sekundárního diagramu na 149 % hlavního diagramu. [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) vybírá rozdělení založené na procentech a [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) nastavuje práh na 53 %.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # Zobrazte hodnoty a nakonfigurujte sekundární diagram.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **Vyberte kategorie pro sekundární diagram**

Použijte vlastní rozdělení, pokud chcete seskupit konkrétní kategorie v sekundárním diagramu bez ohledu na jejich procentuální hodnoty. Například prodejní zpráva může zobrazovat Online a Events společně, aby čtenáři mohli porovnat tyto dva kanály, i když představují 35 % a 10 % celkových prodejů.

Nastavte [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) na [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) a vyberte body pomocí [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/). Metoda [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) kolekce akceptuje buď index založený na nulovém základu v řadě, nebo objekt datového bodu. V tomto příkladu index 1 vybírá Online a bod na indexu 3 vybírá Events. Partners je také dočasně přidán, poté vyloučen pomocí [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/).

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # Nahraďte výchozí data prodejem podle kanálu.
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # Vyberte Online podle jeho nulového indexu a Events podle jeho objektu datového bodu.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # Vyloučte Partners ze výběru bez odstranění jeho zdrojových dat.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Online (35) a Events (10) se objevují jako samostatné výseče v sekundárním diagramu. V primárním diagramu jsou reprezentovány jednou spojenou výsečí s hodnotou 45, spolu s Retail (40) a Partners (15). Odebrání Partners z vlastního výběru jej ponechává v primárním diagramu; neodstraňuje kategorii ani její hodnotu ze zdrojových dat grafu.

Následující obrázek zobrazuje uloženou prezentaci v PowerPointu:

![Pie of Pie chart with Online and Events in the secondary plot and their combined value of 45 in the primary plot](pie_of_pie_custom.png)

## **Nastavte automatické barvy výsečí výsečového grafu**

Aspose.Slides for Python via .NET může automaticky přiřadit různé barvy výsečím výsečového grafu. Následující příklad vytváří výsečový graf se středovým nadpisem a nahrazuje výchozí data třemi čtvrtletními kategoriemi a jejich hodnotami. Vlastnost [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) zobrazuje hodnoty 20, 50 a 30 jako popisky, zatímco [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) umožňuje odlišnou barvu pro každou výseč.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Přidejte centrovaný nadpis grafu.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Nahraďte výchozí data pomocí prvního listu.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # Zobrazte hodnoty a přiřaďte různé barvy výsečím.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Jsou podporovány varianty Pie of Pie a Bar of Pie?**

Ano, knihovna [podporuje](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) sekundární diagram pro výsečové grafy, včetně typů Pie of Pie a Bar of Pie.

**Mohu exportovat jen samotný graf jako obrázek (například PNG)?**

Ano, můžete [exportovat samotný graf jako obrázek](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (například PNG) bez exportu celé prezentace.