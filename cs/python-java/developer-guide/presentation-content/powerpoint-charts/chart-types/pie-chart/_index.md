---
title: Přizpůsobení koláčových grafů v prezentacích pomocí Pythonu přes Java
linktitle: Koláčový graf
type: docs
url: /cs/python-java/pie-chart/
keywords:
- koláčový graf
- správa grafu
- přizpůsobení grafu
- možnosti grafu
- nastavení grafu
- možnosti vykreslení
- barva výseku
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Zjistěte, jak vytvářet a přizpůsobovat koláčové grafy v Pythonu přes Java s Aspose.Slides, exportovatelné do PowerPointu, a během několika sekund vylepšit vyprávění dat."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s koláčovými grafy v Aspose.Slides. Ukazuje, jak nastavit možnosti sekundárního výkresu pro grafy Pie of Pie a Bar of Pie a jak povolit automatické barvení výseků pro standardní koláčový graf.

Příklady se zaměřují na praktické kroky přizpůsobení grafu, jako je přidání grafu na snímek, úprava nastavení řad a popisků, nahrazení výchozích dat grafu vlastními kategoriemi a hodnotami a uložení aktualizované prezentace.

## **Možnosti sekundárního výkresu pro grafy Pie of Pie a Bar of Pie**

Aspose.Slides for Python via Java podporuje možnosti sekundárního výkresu pro grafy Pie of Pie a Bar of Pie. Tento oddíl ukazuje, jak pomocí Aspose.Slides tyto možnosti specifikovat. Postupujte podle následujících kroků:

1. Vytvořte instanci objektu [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Přidejte graf na snímek.
1. Zadejte možnosti sekundárního výkresu grafu.
1. Zapište prezentaci na disk.

Následující příklad nastavuje různé vlastnosti grafu Pie of Pie.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

# Vytvořte instanci třídy Presentation.
presentation = Presentation()
try:
    # Přidejte graf na snímek.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)

    # Nastavte různé vlastnosti.
    series = chart.getChartData().getSeries().get_Item(0)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    # Uložte prezentaci na disk.
    presentation.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení automatických barev výseků koláčového grafu**

Aspose.Slides for Python via Java poskytuje jednoduché rozhraní API pro nastavení automatických barev výseků koláčového grafu. Následující příklad ukazuje, jak tato nastavení použít.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Získejte první snímek.
1. Přidejte graf s výchozími daty.
1. Nastavte nadpis grafu.
1. Nastavte index listu s daty grafu.
1. Získejte sešit s daty grafu.
1. Odstraňte výchozí řady a kategorie.
1. Přidejte nové kategorie.
1. Přidejte novou řadu.
1. Nastavte novou řadu tak, aby zobrazovala hodnoty.

Zapište upravenou prezentaci do souboru PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

# Vytvořte instanci třídy Presentation.
presentation = Presentation()
try:
    # Přidejte graf s výchozími daty.
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Nastavte název grafu.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Nastavte index listu s daty grafu.
    default_worksheet_index = 0

    # Získejte sešit s daty grafu.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Odstraňte výchozí řady a kategorie.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Přidejte nové kategorie.
    first_category_cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(second_category_cell)
    third_category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(third_category_cell)

    # Přidejte novou řadu.
    series_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Naplněte data řady.
    first_value_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForPieSeries(first_value_cell)
    second_value_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForPieSeries(second_value_cell)
    third_value_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForPieSeries(third_value_cell)

    # Nastavte novou řadu tak, aby zobrazovala hodnoty.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    series.getParentSeriesGroup().setColorVaried(True)
    presentation.save("Pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Jsou podporovány varianty 'Pie of Pie' a 'Bar of Pie'?**

Ano, knihovna [podporuje](https://reference.aspose.com/slides/cs/python-java/aspose.slides/charttype/) sekundární výkres pro koláčové grafy, včetně typů 'Pie of Pie' a 'Bar of Pie'.

**Mohu exportovat jen graf jako obrázek (například PNG)?**

Ano, můžete [exportovat samotný graf jako obrázek](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shape/#getImage) (například PNG) bez celé prezentace.