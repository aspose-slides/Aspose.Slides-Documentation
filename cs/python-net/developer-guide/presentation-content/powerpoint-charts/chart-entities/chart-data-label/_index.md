---
title: Správa datových popisků v grafech v prezentacích pomocí Pythonu
linktitle: Datový popisek
type: docs
url: /cs/python-net/chart-data-label/
keywords:
- graf
- datový popisek
- přesnost dat
- procento
- vzdálenost popisku
- umístění popisku
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se přidávat a formátovat datové popisky v grafech v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Python prostřednictvím .NET pro poutavější snímky."
---
## **Přehled**

Datové popisky v grafu zobrazují podrobnosti o datových řadách grafu nebo jednotlivých bodech. Umožňují čtenářům rychle rozpoznat řady a také usnadňují pochopení grafů. V Aspose.Slides pro Python můžete povolit, přizpůsobit a formátovat datové popisky pro libovolný graf – vybrat, co zobrazit (hodnoty, procenta, názvy řad nebo kategorií), kde popisky umístit a jak budou vypadat (písmo, formát čísel, oddělovače, čáry vedoucí k popisku a další). Tento článek popisuje základní API a příklady, které potřebujete k přidání jasných, informativních popisků do vašich grafů.

## **Nastavení přesnosti datových popisků**

Datové popisky v grafu často zobrazují číselné hodnoty, které vyžadují jednotnou přesnost. V této části se dozvíte, jak v Aspose.Slides ovládat počet desetinných míst pro datové popisky pomocí vhodného formátu čísla.

Následující příklad v Pythonu ukazuje, jak nastavit číselnou přesnost pro datové popisky grafu:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 500, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.number_format_of_values = "#,##0.00"

    presentation.save("data_label_precision.pptx", slides.export.SaveFormat.PPTX)
```

## **Zobrazování procent jako popisků**

S Aspose.Slides můžete na grafech zobrazovat procenta jako datové popisky. Níže uvedený příklad vypočítá podíl každého bodu v rámci jeho kategorie a naformátuje popisek tak, aby zobrazoval procenta.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 600, 400)
    series = chart.chart_data.series[0]

    total_for_categories = [0]*len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for i in range(len(chart.chart_data.series)):
            total_for_categories[k] += chart.chart_data.series[i].data_points[k].value.data

    for i in range(len(chart.chart_data.series)):
        series = chart.chart_data.series[i]
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            data_point_percent = series.data_points[j].value.data / total_for_categories[j] * 100

            text_portion = slides.Portion()
            text_portion.text = "{0:.2f} %".format(data_point_percent)
            text_portion.portion_format.font_height = 8

            label = series.data_points[j].label
            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(text_portion)

            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    # Uložte prezentaci obsahující graf.
    presentation.save("percentage_as_label.pptx", slides.export.SaveFormat.PPTX)
```

## **Zobrazení znaků procent v datových popiscích grafu**

Tato část ukazuje, jak v datových popiscích grafu zobrazit procenta a přidat znak % pomocí Aspose.Slides. Naučíte se, jak povolit procentuální hodnoty pro celé řady nebo konkrétní body (ideální pro koláčové, prstencové a 100 % vrstvené grafy) a jak řídit formátování pomocí možností popisku nebo vlastního formátu čísla.

Následující příklad v Pythonu ukazuje, jak přidat znak procenta do datového popisku grafu:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:

    # Získejte referenci na snímek podle indexu.
    slide = presentation.slides[0]

    # Vytvořte graf PercentsStackedColumn na snímku.
    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 600, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()

    # Získejte sešit s daty grafu.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0

    # Přidejte novou řadu.
    series = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 1, "Reds"), chart.type)
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 1, 0.30))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 1, 0.50))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 1, 0.80))
    series.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 1, 0.65))

    # Nastavte barvu výplně řady.
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = draw.Color.red

    # Nastavte vlastnosti formátu popisku.
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.is_number_format_linked_to_source = False
    series.labels.default_data_label_format.number_format = "0.0%"
    series.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white
    series.labels.default_data_label_format.show_value = True

    # Přidejte novou řadu.
    series2 = chart.chart_data.series.add(workbook.get_cell(worksheet_index, 0, 2, "Blues"), chart.type)
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 1, 2, 0.70))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 2, 2, 0.50))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 3, 2, 0.20))
    series2.data_points.add_data_point_for_bar_series(workbook.get_cell(worksheet_index, 4, 2, 0.35))

    # Nastavte typ výplně a barvu.
    series2.format.fill.fill_type = slides.FillType.SOLID
    series2.format.fill.solid_fill_color.color = draw.Color.blue
    series2.labels.default_data_label_format.show_value = True
    series2.labels.default_data_label_format.is_number_format_linked_to_source = False
    series2.labels.default_data_label_format.number_format = "0.0%"
    series2.labels.default_data_label_format.text_format.portion_format.font_height = 10
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    series2.labels.default_data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.white

    # Uložte prezentaci.
    presentation.save("percentage_sign.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení vzdálenosti popisku od osy**

Tato část ukazuje, jak v Aspose.Slides nastavit vzdálenost mezi datovými popisky a osou grafu. Úprava tohoto odsazení pomáhá předcházet překrývání a zlepšuje čitelnost u hustých vizualizací.

Následující kód v Pythonu ukazuje, jak nastavit vzdálenost popisku od osy kategorií při práci s grafem založeným na osách:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:
    # Získejte referenci na snímek.
    slide = presentation.slides[0]

    # Vytvořte seskupený sloupcový graf na snímku.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    # Nastavte vzdálenost popisku od kategorie (horizontální) osy.
    chart.axes.horizontal_axis.label_offset = 500

    # Uložte prezentaci.
    presentation.save("axis_label_distance.pptx", slides.export.SaveFormat.PPTX)
```

## **Úprava polohy popisku**

Když vytváříte graf, který nepoužívá osy, například koláčový graf, mohou být datové popisky příliš blízko okraji. V takovém případě upravte polohu popisku, aby čáry vedoucí k popisku byly zřetelně viditelné.

Následující kód v Pythonu ukazuje, jak upravit polohu popisku v koláčovém grafu:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 600, 300)

    series = chart.chart_data.series[0]
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.show_leader_lines = True

    label = series.labels[0]
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    label.x = 0.05
    label.y = 0.1

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Změněná poloha popisku](changed_label_position.png)

## **Často kladené otázky**

**Jak mohu zabránit překrývání datových popisků v hustých grafech?**

Zkombinujte automatické umisťování popisků, čáry vedoucí k popiskům a zmenšení velikosti písma; v případě potřeby skryjte některé položky (například kategorii) nebo zobrazujte popisky jen pro extrémní/klíčové body.

**Jak mohu zakázat popisky pouze pro nulové, záporné nebo prázdné hodnoty?**

Filtrováním datových bodů před povolením popisků vypněte zobrazení pro hodnoty 0, záporné hodnoty nebo chybějící hodnoty podle definovaného pravidla.

**Jak mohu zajistit jednotný styl popisků při exportu do PDF/obrázků?**

Explicitně nastavte písma (rodinu, velikost) a ověřte, že písmo je k dispozici na straně vykreslování, aby nedocházelo k náhradě.