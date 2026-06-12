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
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak v Pythonu s Aspose.Slides vytvářet a přizpůsobovat výsečové grafy, exportovatelné do PowerPointu a OpenDocument, a tak během několika sekund vylepšit vyprávění o datech."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s výsečovými grafy v Aspose.Slides. Ukazuje, jak nastavit možnosti sekundárního grafu pro grafy Pie of Pie a Bar of Pie a jak povolit automatické barvení výsečů pro standardní výsečný graf.

Příklady se zaměřují na praktické kroky přizpůsobení grafu, jako je přidání grafu na snímek, úprava nastavení řad a popisků, nahrazení výchozích dat grafu vlastními kategoriemi a hodnotami a uložení aktualizované prezentace.

## **Možnosti sekundárního grafu pro grafy Pie of Pie a Bar of Pie**
Aspose.Slides for Python via .NET nyní podporuje možnosti sekundárního grafu pro grafy Pie of Pie nebo Bar of Pie. V tomto tématu si ukážeme na příkladu, jak tyto možnosti specifikovat pomocí Aspose.Slides. Pro zadání vlastností postupujte podle následujících kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) .
2. Přidejte graf na snímek.
3. Zadejte možnosti sekundárního grafu.
4. Uložte prezentaci na disk.

V níže uvedeném příkladu jsme nastavili různé vlastnosti grafu Pie of Pie.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Vytvořte instanci třídy Presentation
with slides.Presentation() as presentation:
    # Přidejte graf na snímek
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Nastavte různé vlastnosti
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Uložte prezentaci na disk
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Nastavte automatické barvy výsečí výsečového grafu**
Aspose.Slides for Python via .NET poskytuje jednoduché API pro nastavení automatických barev výsečí výsečového grafu. Ve vzorovém kódu jsou nastaveny výše uvedené vlastnosti.

1. Vytvořte instanci třídy Presentation.
2. Získejte první snímek.
3. Přidejte graf s výchozími daty.
4. Nastavte název grafu.
5. Nastavte první řadu na Zobrazit hodnoty.
6. Nastavte index listu s daty grafu.
7. Získání listu s daty grafu.
8. Odstraňte výchozí generované řady a kategorie.
9. Přidejte nové kategorie.
10. Přidejte nové řady.

Uložte upravenou prezentaci do souboru PPTX.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX
with slides.Presentation() as presentation:
	# Získejte první snímek
	slide = presentation.slides[0]

	# Přidejte graf s výchozími daty
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Nastavení názvu grafu
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Nastavte první řadu na Zobrazit hodnoty
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# Nastavení indexu listu s daty grafu
	defaultWorksheetIndex = 0

	# Získání listu s daty grafu
	fact = chart.chart_data.chart_data_workbook

	# Odstraňte výchozí generované řady a kategorie
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Přidání nových kategorií
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# Přidání nové řady
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# Nyní naplňujeme data řady
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Jsou podporovány varianty 'Pie of Pie' a 'Bar of Pie'?**

Ano, knihovna [supports](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/charttype/) sekundární graf pro výsečové grafy, včetně typů 'Pie of Pie' a 'Bar of Pie'.

**Mohu exportovat jen samotný graf jako obrázek (například PNG)?**

Ano, můžete [export the chart itself as an image](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/get_image/) (např. PNG) bez celé prezentace.