---
title: Správa datových popisků v grafech v prezentacích pomocí Pythonu
linktitle: Datový popisek
type: docs
url: /cs/python-java/chart-data-label/
keywords:
- graf
- datový popisek
- přesnost dat
- procenta
- vzdálenost popisku
- umístění popisku
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se přidávat a formátovat datové popisky v grafech v PowerPoint prezentacích pomocí Aspose.Slides pro Python přes Java pro zajímavější snímky."
---
## **Úvod**

Datové popisky zobrazují informace o sériích grafu a jednotlivých bodech, pomáhají čtenářům rozpoznat hodnoty a pochopit graf. Tento článek vysvětluje, jak formátovat hodnoty, zobrazovat procenta, číst text popisku, ovládat popisky mimo maximální hodnotu osy, upravit rozestup popisků osy kategorií a umístit popisky koláčového grafu.

## **Nastavení přesnosti dat v popiscích grafu**

Použijte [setNumberFormatOfValues](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) k formátování hodnot sérií. Tento příklad vytvoří čárový graf s výchozími daty, zobrazí jeho datovou tabulku a povolí hodnotové popisky pro první sérii. Formát `#,##0.00` zobrazuje oddělovač tisíců a dvě desetinná místa, aniž by měnil podkladové hodnoty.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)
    chart.setDataTable(True)

    series = chart.getChartData().getSeries().get_Item(0)
    series.setNumberFormatOfValues("#,##0.00")
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zobrazení procent jako popisků**

U sloupcového grafu se skládanými sloupci vypočítejte každou hodnotu jako procento celkového součtu kategorie a přiřaďte text do textového rámce vráceného metodou [getTextFrameForOverriding](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Tento příklad používá výchozí data grafu a zobrazuje procenta se dvěma desetinnými místy ve 8‑bodovém písmu. Kategorie s nulovým součtem jsou přeskočeny, aby nedošlo k dělení nulou. Přepočítejte vlastní text popisku, pokud se data grafu změní.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Portion, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400)

    chart_series = chart.getChartData().getSeries()
    category_totals = [0.0] * chart.getChartData().getCategories().size()
    for category_index in range(len(category_totals)):
        for series_index in range(chart_series.size()):
            data_point = chart_series.get_Item(series_index).getDataPoints().get_Item(category_index)
            category_totals[category_index] += float(data_point.getValue().getData())

    for series_index in range(chart_series.size()):
        series = chart_series.get_Item(series_index)
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(False)

        for point_index in range(series.getDataPoints().size()):
            data_point = series.getDataPoints().get_Item(point_index)
            label = data_point.getLabel()
            if category_totals[point_index] == 0:
                print(f"Cannot calculate a percentage for category {point_index}: the total is zero.")
                continue
            point_percentage = float(data_point.getValue().getData()) / category_totals[point_index] * 100

            portion = Portion()
            portion.setText(f"{point_percentage:.2f} %")
            portion.getPortionFormat().setFontHeight(8)
            label.getTextFrameForOverriding().setText("")
            paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0)
            paragraph.getPortions().add(portion)

            label_format = label.getDataLabelFormat()
            label_format.setShowValue(True)
            label_format.setShowSeriesName(False)
            label_format.setShowPercentage(False)
            label_format.setShowLegendKey(False)
            label_format.setShowCategoryName(False)
            label_format.setShowBubbleSize(False)

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení symbolu procenta u popisků grafu**

Když jsou hodnoty uloženy jako zlomky, použijte [setNumberFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datalabelformat/#setNumberFormat) k zobrazení procent. Předávejte `False` metodě [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource), aby se formát popisku aplikoval nezávisle na zdrojových buňkách.

Tento příklad vytvoří 100 % skládaný sloupcový graf s červenou a modrou sérií ve čtyřech kategoriích. Každý pár hodnot sečte na 1. Formát popisku `0.0%` zobrazí 0.30 jako 30.0 %, zatímco svislá osa používá dvě desetinná místa. Obě série používají bílý, 10‑bodový text popisku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%")

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [Color.RED, Color.BLUE]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i, series_name in enumerate(series_names):
        series_cell = workbook.getCell(worksheet_index, 0, i + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, chart.getType())
        for j, value in enumerate(values[i]):
            value_cell = workbook.getCell(worksheet_index, j + 1, i + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        series.getFormat().getFill().setFillType(FillType.Solid)
        series.getFormat().getFill().getSolidFillColor().setColor(series_colors[i])

        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(False)
        label_format.setNumberFormat("0.0%")
        portion_format = label_format.getTextFormat().getPortionFormat()
        portion_format.setFontHeight(10)
        portion_format.getFillFormat().setFillType(FillType.Solid)
        portion_format.getFillFormat().getSolidFillColor().setColor(Color.WHITE)

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Načtení skutečného textu datových popisků**

Použijte [getActualLabelText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datalabel/#getActualLabelText) k získání textu vytvořeného nastavením datového popisku. To je užitečné při extrahování popisků pro zprávy, vyhledávání obsahu prezentace nebo ověřování vygenerovaných grafů. V níže uvedeném příkladu výchozí [data label format](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datalabelformat/) kombinuje název kategorie, název série a hodnotu. Jeden bod formátuje svou hodnotu jako procento a další používá vlastní text z [getTextFrameForOverriding](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    first_category_cell = workbook.getCell(0, 1, 0, "Q1")
    chart.getChartData().getCategories().add(first_category_cell)
    second_category_cell = workbook.getCell(0, 2, 0, "Q2")
    chart.getChartData().getCategories().add(second_category_cell)

    north_series_cell = workbook.getCell(0, 0, 1, "North")
    north = chart.getChartData().getSeries().add(north_series_cell, chart.getType())
    north_first_value_cell = workbook.getCell(0, 1, 1, jpype.JDouble(0.25))
    north.getDataPoints().addDataPointForBarSeries(north_first_value_cell)
    north_second_value_cell = workbook.getCell(0, 2, 1, jpype.JDouble(0.75))
    north.getDataPoints().addDataPointForBarSeries(north_second_value_cell)

    south_series_cell = workbook.getCell(0, 0, 2, "South")
    south = chart.getChartData().getSeries().add(south_series_cell, chart.getType())
    south_first_value_cell = workbook.getCell(0, 1, 2, jpype.JDouble(0.40))
    south.getDataPoints().addDataPointForBarSeries(south_first_value_cell)
    south_second_value_cell = workbook.getCell(0, 2, 2, jpype.JDouble(0.60))
    south.getDataPoints().addDataPointForBarSeries(south_second_value_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getLabels().getDefaultDataLabelFormat()
        label_format.setShowCategoryName(True)
        label_format.setShowSeriesName(True)
        label_format.setShowValue(True)

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(False)
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%")
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed")

    for series in chart.getChartData().getSeries():
        for point in series.getDataPoints():
            label = point.getLabel()
            if not label.isVisible():
                continue

            print(f"Value: {point.getValue().getData()}; label: {label.getActualLabelText()}")
finally:
    presentation.dispose()
```

Číslo uložené v datovém bodě zůstává `0.75`, i když jeho popisek zobrazuje `75 %` spolu s názvy kategorie a série. Vlastní text nahrazuje vygenerovaný text popisku. [getActualLabelText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datalabel/#getActualLabelText) vrací výsledný řetězec popisku v obou případech. Zkontrolujte [isVisible](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datalabel/#isVisible) zvlášť, jak je ukázáno výše, pokud chcete extrahovat jen viditelné popisky.

## **Ovládání datových popisků mimo maximální hodnotu osy**

Když omezíte rozsah osy ručně, některé datové body mohou přesáhnout její maximum. Použijte [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) k určení, zda se jejich popisky zobrazí. Toto nastavení mění viditelnost popisků; nemění rozsah osy ani podkladové hodnoty.

Níže uvedený příklad vytvoří 2D seskupený sloupcový graf s hodnotami 60 a 120. Předá `False` metodě [setAutomaticMaxValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/axis/#setAutomaticMaxValue) a nastaví maximum na 100 metodou [setMaxValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/axis/#setMaxValue) na svislé ose. První snímek povoluje popisky i po maximu; kopie tohoto snímku je zakáže. Oba snímky jsou uloženy v souboru `DataLabelsOverMaximum.pptx`.

Povolte hodnotové popisky pomocí [setShowValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datalabelformat/#setShowValue). Nastavení na úrovni grafu neaktivuje zobrazení hodnot samo o sobě ani nepřepíše zakázané zobrazení hodnot u jednotlivých popisků. Tento příklad povolí hodnoty pro celou sérii a použije [setPosition](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datalabelformat/#setPosition) k umístění popisků na vnější konec každého sloupce.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    first_category = workbook.getCell(0, 1, 0, "Within range")
    second_category = workbook.getCell(0, 2, 0, "Above maximum")

    chart.getChartData().getCategories().add(first_category)
    chart.getChartData().getCategories().add(second_category)

    series_name = workbook.getCell(0, 0, 1, "Values")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())

    first_value = workbook.getCell(0, 1, 1, jpype.JDouble(60))
    second_value = workbook.getCell(0, 2, 1, jpype.JDouble(120))

    series.getDataPoints().addDataPointForBarSeries(first_value)
    series.getDataPoints().addDataPointForBarSeries(second_value)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(100)
    chart.setShowDataLabelsOverMaximum(True)

    second_slide = presentation.getSlides().addClone(slide)
    second_chart = second_slide.getShapes().get_Item(0)
    second_chart.setShowDataLabelsOverMaximum(False)

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Následující obrázky ukazují uložené snímky vykreslené aplikací Microsoft PowerPoint. S `True` je popisek **120** viditelný na horní hranici; s `False` je skrytý. Popisek **60** zůstává viditelný, maximum osy zůstává na **100** a druhý datový bod zůstává **120** v obou případech.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Tento příklad používá 2D sloupcový graf s hodnotovou osou. Grafy bez hodnotové osy, jako jsou koláčové a prstencové grafy, nemají maximální hodnotu osy, kterou by bylo možné tímto způsobem omezit.
{{% /alert %}}

## **Nastavení vzdálenosti popisku od osy**

Použijte [setLabelOffset](https://reference.aspose.com/slides/cs/python-java/aspose.slides/axis/#setLabelOffset) k ovládání vzdálenosti mezi popisky osy kategorií a samotnou osou. Hodnota je vyjádřena procentem maximální velikosti písma popisků osy. Tento příklad vytvoří seskupený sloupcový graf a nastaví offset popisků vodorovné osy na 500. Toto nastavení ovlivňuje popisky osy kategorií, nikoli popisky připojené k jednotlivým datovým bodům.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    chart.getAxes().getHorizontalAxis().setLabelOffset(500)

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Úprava umístění popisků**

U koláčového grafu upravte pozice datových popisků, aby se zlepšilo rozestupování a vytvořilo místo pro čáry ukazatele.

Tento příklad zobrazuje hodnotu prvního datového bodu, umístí jeho popisek mimo výseč a upraví horizontální a vertikální posuny pomocí [setX](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datalabel/#setX) a [setY](https://reference.aspose.com/slides/cs/python-java/aspose.slides/datalabel/#setY). Tyto posuny jsou relativní k šířce a výšce grafu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LegendDataLabelPosition, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200)
    series = chart.getChartData().getSeries()
    
    label = series.get_Item(0).getLabels().get_Item(0)
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd)
    label.setX(0.71)
    label.setY(0.04)

    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **Často kladené otázky**

**Jak mohu zabránit překrývání datových popisků u hustých grafů?**

Kombinujte automatické umístění popisků, čáry ukazatele a sníženou velikost písma; pokud je potřeba, skryjte některá pole (například kategorii) nebo zobrazujte popisky jen pro extrémní hodnoty či klíčové body.

**Jak mohu zakázat popisky jen pro nulové, záporné nebo prázdné hodnoty?**

Před povolením popisků odfiltrujte datové body a vypněte zobrazování pro hodnoty 0, záporné hodnoty nebo chybějící hodnoty podle definovaného pravidla.

**Jak zajistit konzistentní styl popisků při exportu do PDF/obrazů?**

Explicitně nastavte rodinu písma a velikost a ověřte, že požadované písmo je dostupné v prostředí renderování, aby nedošlo k jeho náhradě.