---
title: Přizpůsobení os grafu v prezentacích pomocí Pythonu
linktitle: Osa grafu
type: docs
url: /cs/python-net/chart-axis/
keywords:
- osa grafu
- svislá osa
- vodorovná osa
- přizpůsobit osu
- manipulovat s osou
- spravovat osu
- vlastnosti osy
- maximální hodnota
- minimální hodnota
- čára osy
- formát data
- název osy
- pozice osy
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Objevte, jak pomocí Aspose.Slides pro Python prostřednictvím .NET přizpůsobit osy grafu v prezentacích PowerPoint a OpenDocument pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu v Aspose.Slides. Ukazuje, jak získat skutečné hodnoty os, vyměnit data mezi osami, skrýt svislou nebo vodorovnou osu u čarových grafů, změnit typ osy kategorií, nastavit formát data pro hodnoty osy kategorií, otočit nadpis osy, nastavit pozici osy a zobrazit jednotkový štítek na hodnotové ose.

## **Získání maximálních hodnot na svislé ose v grafech**
Aspose.Slides pro Python prostřednictvím .NET umožňuje získat minimální a maximální hodnoty na svislé ose. Projděte následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Přistupte k prvnímu snímku.
3. Přidejte graf s výchozími daty.
4. Získejte skutečnou maximální hodnotu na ose.
5. Získejte skutečnou minimální hodnotu na ose.
6. Získejte skutečnou hlavní jednotku osy.
7. Získejte skutečnou vedlejší jednotku osy.
8. Získejte skutečné měřítko hlavní jednotky osy.
9. Získejte skutečné měřítko vedlejší jednotky osy.

Tento ukázkový kód — implementace výše uvedených kroků — vám ukazuje, jak získat požadované hodnoty v jazyce Python:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Uloží prezentaci
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Prohození dat mezi osami**
Aspose.Slides vám umožňuje rychle prohodit data mezi osami — data zobrazená na svislé ose (y-osa) se přesune na vodorovnou osu (x-osa) a naopak.

Tento kód v Pythonu vám ukazuje, jak provést úlohu prohození dat mezi osami v grafu:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Vytvoří prázdnou prezentaci
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Přepne řádky a sloupce
            
    # Uloží prezentaci
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Zakázání svislé osy pro čarové grafy**
Tento kód v Pythonu vám ukazuje, jak skrýt svislou osu pro čarový graf:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **Zakázání vodorovné osy pro čarové grafy**
Tento kód vám ukazuje, jak skrýt vodorovnou osu pro čarový graf:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Změna osy kategorií**
Pomocí vlastnosti **CategoryAxisType** můžete určit preferovaný typ osy kategorií (**date** nebo **text**). Tento kód v Pythonu demonstruje operaci: 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení formátu data pro hodnotu osy kategorií**
Aspose.Slides pro Python prostřednictvím .NET vám umožňuje nastavit formát data pro hodnotu osy kategorií. Operace je demonstrována v tomto kódu v Pythonu:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení úhlu otáčení názvu osy grafu**
Aspose.Slides pro Python prostřednictvím .NET vám umožňuje nastavit úhel otáčení názvu osy grafu. Tento kód v Pythonu demonstruje operaci:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení polohy osy v ose kategorií nebo hodnot**
Aspose.Slides pro Python prostřednictvím .NET vám umožňuje nastavit polohu osy v ose kategorií nebo hodnot. Tento kód v Pythonu ukazuje, jak úlohu provést:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Povolení zobrazení jednotkového štítku na hodnotové ose grafu**
Aspose.Slides pro Python prostřednictvím .NET vám umožňuje nakonfigurovat graf tak, aby zobrazoval jednotkový štítek na své hodnotové ose. Tento kód v Pythonu demonstruje operaci:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Jak nastavit hodnotu, při které se jedna osa protíná s druhou (průsečík osy)?**

Osy nabízejí [nastavení průsečíku](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/axis/cross_type/): můžete si vybrat průsečík v nule, při maximální hodnotě kategorie/hodnoty nebo při konkrétní číselné hodnotě. To je užitečné pro posunutí osy X nahoru nebo dolů či pro zvýraznění základní linie.

**Jak mohu umístit popisky značek relativně k ose (vedle, venku, uvnitř)?**

Nastavte [pozici popisku](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/axis/major_tick_mark/) na "cross", "outside" nebo "inside". To ovlivňuje čitelnost a pomáhá šetřit místo, zejména u malých grafů.