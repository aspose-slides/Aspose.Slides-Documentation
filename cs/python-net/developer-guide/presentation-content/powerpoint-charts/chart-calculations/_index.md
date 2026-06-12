---
title: Optimalizujte výpočty grafů pro prezentace v Pythonu
linktitle: Výpočty grafů
type: docs
weight: 50
url: /cs/python-net/chart-calculations/
keywords:
- výpočty grafů
- prvky grafu
- pozice prvku
- skutečná pozice
- podřízený prvek
- nadřazený prvek
- hodnoty grafu
- skutečná hodnota
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Pochopte výpočty grafů, aktualizace dat a řízení přesnosti v Aspose.Slides pro Python přes .NET pro formáty PPT, PPTX a ODP, s praktickými příklady kódu."
---
## **Přehled**

Aspose.Slides poskytuje rozhraní API pro práci s výpočty grafů a daty rozvržení v prezentacích. Tento článek ukazuje, jak získat skutečné hodnoty prvků grafu, včetně skutečné polohy a velikosti prvků, které implementují `ActualLayout`, a skutečné hodnoty os grafu. Také vysvětluje, že tyto hodnoty jsou naplněny po ověření rozvržení grafu.

Dále článek ukazuje, jak získat skutečnou polohu nadřazených prvků grafu a jak skrýt komponenty grafu, jako jsou název, osy, legenda a mřížkové čáry. Tyto příklady vám pomohou programově prozkoumat informace o rozvržení grafu a řídit viditelnost prvků grafu v prezentacích PowerPoint.

## **Vypočítat skutečné hodnoty prvků grafu**
Aspose.Slides for Python via .NET poskytuje jednoduché API pro získávání těchto vlastností. To vám pomůže vypočítat skutečné hodnoty prvků grafu. Skutečné hodnoty zahrnují polohu prvků, které dědí třídu [IActualLayout](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/iactuallayout/) (IActualLayout.ActualX, IActualLayout.ActualY, IActualLayout.ActualWidth, IActualLayout.ActualHeight) a skutečné hodnoty os (IAxis.ActualMaxValue, IAxis.ActualMinValue, IAxis.ActualMajorUnit, IAxis.ActualMinorUnit, IAxis.ActualMajorUnitScale, IAxis.ActualMinorUnitScale).

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    maxValue = chart.axes.vertical_axis.actual_max_value
    minValue = chart.axes.vertical_axis.actual_min_value
    majorUnit = chart.axes.horizontal_axis.actual_major_unit
    minorUnit = chart.axes.horizontal_axis.actual_minor_unit
```

## **Vypočítat skutečnou polohu nadřazených prvků grafu**
Aspose.Slides for Python via .NET poskytuje jednoduché API pro získávání těchto vlastností. Vlastnosti IActualLayout poskytují informace o skutečné poloze nadřazeného prvku grafu. Před tím je třeba zavolat metodu IChart.ValidateChartLayout(), aby se vlastnosti naplnily skutečnými hodnotami.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
```

## **Skrýt informace v grafu**
Toto téma vám pomůže pochopit, jak skrýt informace v grafu. Pomocí Aspose.Slides for Python via .NET můžete skrýt **Název, Vertikální osu, Horizontální osu** a **Mřížkové čáry** v grafu. Níže uvedený příklad kódu ukazuje, jak tyto vlastnosti použít.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 140, 118, 320, 370)

    # Skrytí názvu grafu
    chart.has_title = False

    # Skrytí osy hodnot
    chart.axes.vertical_axis.is_visible = False

    # Viditelnost osy kategorií
    chart.axes.horizontal_axis.is_visible = False

    # Skrytí legendy
    chart.has_legend = False

    # Skrytí hlavních čar mřížky
    chart.axes.horizontal_axis.major_grid_lines_format.line.fill_format.fill_type = slides.FillType.NO_FILL

    #for i in range(len(chart.chart_data.series)):
    #    chart.chart_data.series.remove_at(i)

    series = chart.chart_data.series[0]

    series.marker.symbol = charts.MarkerStyleType.CIRCLE
    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.TOP
    series.marker.size = 15

    # Nastavení barvy čáry řady
    series.format.line.fill_format.fill_type = slides.FillType.SOLID
    series.format.line.fill_format.solid_fill_color.color = draw.Color.purple
    series.format.line.dash_style = slides.LineDashStyle.SOLID

    pres.save("HideInformationFromChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Používají se externí sešity Excelu jako zdroj dat a jak to ovlivňuje přepočet?**

Ano. Graf může odkazovat na externí sešit: když připojíte nebo obnovíte externí zdroj, vzorce a hodnoty jsou převzaty z tohoto sešitu a graf odráží aktualizace během operací otevření/úpravy. API vám umožňuje [specifikovat cestu k externímu sešitu](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_external_workbook/) a spravovat propojená data.

**Mohu vypočítat a zobrazit čáry trendu bez implementace regrese sami?**

Ano. [Trendlines](/slides/cs/python-net/trend-line/) (lineární, exponenciální a další) jsou přidávány a aktualizovány pomocí Aspose.Slides; jejich parametry jsou automaticky přepočítány ze sériových dat, takže není nutné implementovat vlastní výpočty.

**Pokud má prezentace více grafů s externími odkazy, mohu řídit, který sešit každý graf používá pro vypočtené hodnoty?**

Ano. Každý graf může ukazovat na svůj vlastní [externí sešit](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_external_workbook/), nebo můžete pro každý graf vytvořit/nahradit externí sešit nezávisle na ostatních.