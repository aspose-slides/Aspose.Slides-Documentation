---
title: Optimalizace výpočtů grafů pro prezentace v Pythonu přes Java
linktitle: Výpočty grafů
type: docs
weight: 50
url: /cs/python-java/chart-calculations/
keywords:
- výpočty grafů
- prvky grafu
- pozice prvku
- skutečná pozice
- potomkový prvek
- rodičovský prvek
- hodnoty grafu
- skutečná hodnota
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Pochopte výpočty grafů, aktualizace dat a řízení přesnosti v Aspose.Slides pro Python přes Java pro PPT a PPTX, s praktickými příklady kódu v Pythonu."
---
## **Přehled**

Aspose.Slides poskytuje rozhraní API pro práci s výpočty grafů a daty rozvržení v prezentacích. Tento článek ukazuje, jak získat skutečné hodnoty prvků grafu, včetně skutečné polohy a velikosti prvků grafu a skutečných hodnot os grafu. Vysvětluje také, že tyto hodnoty jsou naplněny po validaci rozvržení grafu.

Kromě toho článek demonstruje, jak získat skutečnou polohu nadřazených prvků grafu a jak skrýt komponenty grafu, jako jsou název, osy, legenda a mřížkové čáry. Tyto příklady vám pomohou programově zkontrolovat informace o rozvržení grafu a řídit viditelnost prvků grafu v PowerPoint prezentacích.

## **Vypočítat skutečné hodnoty prvků grafu**
Aspose.Slides for Python via Java poskytuje jednoduché API pro získání těchto vlastností. Metody třídy [Axis](https://reference.aspose.com/slides/cs/python-java/aspose.slides/axis/) poskytují informace o skutečných hodnotách os grafu ([getActualMaxValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/axis/#getActualMaxValue), [getActualMinValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/axis/#getActualMinValue), [getActualMajorUnit](https://reference.aspose.com/slides/cs/python-java/aspose.slides/axis/#getActualMajorUnit), [getActualMinorUnit](https://reference.aspose.com/slides/cs/python-java/aspose.slides/axis/#getActualMinorUnit), [getActualMajorUnitScale](https://reference.aspose.com/slides/cs/python-java/aspose.slides/axis/#getActualMajorUnitScale), [getActualMinorUnitScale](https://reference.aspose.com/slides/cs/python-java/aspose.slides/axis/#getActualMinorUnitScale)). Nejprve zavolejte metodu [Chart.validateChartLayout](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#validateChartLayout), aby se tyto vlastnosti naplnily skutečnými hodnotami.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getHorizontalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getHorizontalAxis().getActualMinorUnit()
finally:
    presentation.dispose()
```

## **Vypočítat skutečnou polohu nadřazených prvků grafu**
Aspose.Slides for Python via Java poskytuje jednoduché API pro získání těchto vlastností. Metody třídy [ChartPlotArea](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartplotarea/) poskytují informace o skutečné poloze a velikosti oblasti vykreslování grafu ([getActualX](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartplotarea/#getActualX), [getActualY](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartplotarea/#getActualY), [getActualWidth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartplotarea/#getActualWidth), [getActualHeight](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartplotarea/#getActualHeight)). Nejprve zavolejte metodu [Chart.validateChartLayout](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#validateChartLayout), aby se tyto vlastnosti naplnily skutečnými hodnotami.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    x = chart.getPlotArea().getActualX()
    y = chart.getPlotArea().getActualY()
    width = chart.getPlotArea().getActualWidth()
    height = chart.getPlotArea().getActualHeight()
finally:
    presentation.dispose()
```

## **Skrýt prvky grafu**
Tato část vysvětluje, jak skrýt informace v grafu. Pomocí Aspose.Slides for Python via Java můžete skrýt **Název, Vertikální osu, Horizontální osu** a **Mřížkové čáry**. Následující ukázka kódu demonstruje použití těchto vlastností.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LegendDataLabelPosition, LineDashStyle, MarkerStyleType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 140, 118, 320, 370)

    # Skrýt název grafu.
    chart.setTitle(False)

    # Skrýt hodnotovou osu.
    chart.getAxes().getVerticalAxis().setVisible(False)

    # Skrýt kategorickou osu.
    chart.getAxes().getHorizontalAxis().setVisible(False)

    # Skrýt legendu.
    chart.setLegend(False)

    # Skrýt hlavní mřížkové čáry.
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Ponechat pouze první řadu. Odstraňování od konce zachovává platnost zbývajících indexů.
    series_collection = chart.getChartData().getSeries()
    while series_collection.size() > 1:
        series_collection.removeAt(series_collection.size() - 1)

    series = series_collection.get_Item(0)

    series.getMarker().setSymbol(MarkerStyleType.Circle)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.Top)
    series.getMarker().setSize(15)

    # Nastavit barvu čáry řady.
    series.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    series.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    series.getFormat().getLine().setDashStyle(LineDashStyle.Solid)

    presentation.save("HideInformationFromChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Fungují externí sešity Excelu jako zdroj dat a jak to ovlivňuje přepočet?**

Ano. Graf může odkazovat na externí sešit: když připojíte nebo obnovíte externí zdroj, vzorce a hodnoty jsou převzaty z tohoto sešitu a graf během operací otevření/úpravy odráží aktualizace. API vám umožňuje [specifikovat cestu k externímu sešitu](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdata/#setExternalWorkbook) a spravovat propojená data.

**Mohu vypočítat a zobrazit trendové čáry, aniž bych implementoval regresi sám?**

Ano. [Trendlines](/slides/cs/python-java/trend-line/) (lineární, exponenciální a další) jsou přidávány a aktualizovány pomocí Aspose.Slides; jejich parametry jsou automaticky přepočítány z dat řady, takže není nutné implementovat vlastní výpočty.

**Pokud má prezentace více grafů s externími odkazy, mohu řídit, který sešit používá pro výpočet hodnot u každého grafu?**

Ano. Každý graf může odkazovat na svůj vlastní [externí sešit](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdata/#setExternalWorkbook), nebo můžete pro každý graf nezávisle vytvořit/nahradit externí sešit.