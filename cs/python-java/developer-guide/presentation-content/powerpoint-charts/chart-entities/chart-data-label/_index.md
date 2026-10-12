---
title: Správa datových popisků v grafech v prezentacích pomocí Pythonu
linktitle: Datový popisek
type: docs
url: /cs/python-java/chart-data-label/
keywords:
- graf
- datový popisek
- přesnost dat
- procento
- vzdálenost popisku
- umístění popisku
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se přidávat a formátovat datové popisky v grafech v prezentacích PowerPoint pomocí Aspose.Slides pro Python prostřednictvím Javy pro poutavější snímky."
---
## **Úvod**

Datové popisky zobrazují informace o sériích grafu a jednotlivých datových bodech, čímž čtenářům pomáhají identifikovat hodnoty a pochopit graf. Tento článek vysvětluje, jak formátovat hodnoty, zobrazovat procenta, číst text popisku, ovládat popisky mimo maximální hodnotu osy, upravit rozestup popisků na kategoriální ose a umístit popisky v koláčovém grafu.

## **Nastavení přesnosti dat v popiscích grafu**

Použijte [setNumberFormatOfValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setNumberFormatOfValues) k formátování hodnot série. Tento příklad vytváří čárový graf s výchozími daty, zobrazuje jeho datovou tabulku a povoluje popisky hodnot pro první sérii. Formát `#,##0.00` zobrazuje oddělovač tisíců a dvě desetinná místa, aniž by měnil podkladové hodnoty.

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

Pro „stacked column“ graf vypočítejte každou hodnotu jako procento celkové kategorie a přiřaďte text do textového rámečku vráceného metodou [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding). Tento příklad používá výchozí data grafu a zobrazuje procenta se dvěma desetinnými místy v písmu o velikosti 8 bodů. Kategorie s celkovou nulou jsou přeskočeny, aby se zabránilo dělení nulou. Vlastní text popisku přepočítejte, pokud se data grafu změní.

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

## **Nastavení znaku procenta v popiscích grafu**

Když jsou hodnoty uloženy jako zlomky, použijte [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) k zobrazení procent. Předávejte `False` metodě [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource), aby se formát popisku aplikoval nezávisle na zdrojových buňkách.

Tento příklad vytváří 100 % „stacked column“ graf s červenou a modrou sérií ve čtyřech kategoriích. Každý pár hodnot dohromady dává 1. Formát popisku `0.0%` zobrazí 0,30 jako 30,0 %, zatímco vertikální osa používá dvě desetinná místa. Obě série používají bílý popisek o velikosti 10 bodů.

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

## **Čtení skutečného textu datových popisků**

Použijte [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) k získání textu vytvořeného nastavením datového popisku. To je užitečné při extrahování popisků pro zprávy, vyhledávání obsahu prezentace nebo ověřování vygenerovaných grafů. V níže uvedeném příkladu výchozí [data label format](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/) kombinuje název kategorie, název série a hodnotu. Jeden bod formátuje svou hodnotu jako procento a další používá vlastní text z [getTextFrameForOverriding](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getTextFrameForOverriding).

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

Číslo uložené v datovém bodě zůstává `0.75`, i když jeho popisek zobrazuje `75 %` spolu s názvy kategorie a série. Vlastní text nahrazuje vygenerovaný text popisku. [getActualLabelText](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#getActualLabelText) vrací výsledný řetězec popisku v obou případech. Zkontrolujte [isVisible](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#isVisible) samostatně, jak je ukázáno výše, když chcete extrahovat jen viditelné popisky.

## **Ovládání datových popisků mimo maximální hodnotu osy**

Když omezíte rozsah osy ručně, některé datové body mohou překročit její maximum. Použijte [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setShowDataLabelsOverMaximum) k určení, zda se jejich popisky zobrazí. Toto nastavení mění viditelnost popisků; nemění rozsah osy ani podkladové hodnoty dat.

Níže uvedený příklad vytváří 2D seskupený sloupcový graf s hodnotami 60 a 120. Předá `False` metodě [setAutomaticMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMaxValue) a nastaví maximum na 100 pomocí [setMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMaxValue) na svislé ose. První snímek povoluje popisky za maximem; kopie tohoto snímku je zakáže. Oba snímky jsou uloženy v souboru `DataLabelsOverMaximum.pptx`.

Povolte popisky hodnot pomocí [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). Nastavení na úrovni grafu samo o sobě nezpůsobí zobrazení hodnot ani nepřepíše individuální zakázané zobrazení hodnot popisku. Tento příklad povoluje hodnoty pro celou sérii a používá [setPosition](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setPosition) k umístění popisků na vnější konec každého sloupce.

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

Následující obrázky ukazují uložené snímky vykreslené v Microsoft PowerPoint. S `True` je popisek **120** viditelný na horní hranici; s `False` je skrytý. Popisek **60** zůstává viditelný, maximum osy zůstává na **100** a druhý datový bod zůstává **120** v obou případech.

| setShowDataLabelsOverMaximum(True) | setShowDataLabelsOverMaximum(False) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Typ grafu" %}}

Tento příklad používá 2D sloupcový graf s hodnotovou osou. Grafy bez hodnotové osy, jako jsou koláčové a prstencové grafy, nemají maximální hodnotu osy, kterou by bylo možné tímto způsobem omezovat.

{{% /alert %}}

## **Nastavení vzdálenosti popisku od osy**

Použijte [setLabelOffset](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLabelOffset) k ovládání vzdálenosti mezi popisky kategoriální osy a osou. Hodnota je procento maximální velikosti písma popisků osy. Tento příklad vytváří seskupený sloupcový graf a nastavuje offset popisků horizontální osy na 500. Toto nastavení ovlivňuje popisky kategoriální osy, nikoli popisky připojené k jednotlivým datovým bodům.

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

## **Úprava umístění popisku**

V koláčovém grafu upravte polohu datových popisků, aby se zlepšil rozestup a vytvořil prostor pro čáry vedoucí k popiskům.

Tento příklad zobrazuje hodnotu prvního datového bodu, umisťuje jeho popisek mimo výseč a upravuje jeho horizontální a vertikální offset pomocí [setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) a [setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY). Tyto offsety jsou relativní k šířce a výšce grafu.

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

## **Přidání více řádků datových popisků nad sloupcový graf**

Tento příklad vytváří sloupcový graf se dvěma řádky datových popisků nad oblasti grafu. Série A zobrazuje viditelné sloupce, zatímco série B a C poskytují další popisky. Jejich sloupce jsou skryté odstraněním výplně a obrysu. Metoda [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) zarovnává všechny tři série ke stejným středům kategorií.

Nastavení [ChartPlotArea](https://reference.aspose.com/slides/python-java/aspose.slides/chartplotarea/) vyhrazuje místo pro řádky popisků. Po výpočtu výchozích pozic metodou [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) zachovají [DataLabel.setX](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setX) a [DataLabel.setY](https://reference.aspose.com/slides/python-java/aspose.slides/datalabel/#setY) horizontální zarovnání a aplikují vertikální offsety pro uspořádání popisků ve dvou řádcích. Čísla zůstávají datovými popisky spojenými s hodnotami sérií; pouze nadpisy řádků jsou samostatné textové tvary.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LayoutTargetType, LegendDataLabelPosition, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200)
    chart.setTitle(False)
    chart.setLegend(False)
    chart.getTextFormat().getPortionFormat().setFontHeight(12)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [[35, 42, 28, 47], [22, 31, 19, 26], [12, 16, 14, 18]]

    for category_index, category in enumerate(categories):
        category_cell = workbook.getCell(0, category_index + 1, 0, category)
        chart.getChartData().getCategories().add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.getCell(0, 0, series_index + 1, series_name)
        series = chart.getChartData().getSeries().add(series_cell, ChartType.ClusteredColumn)

        for category_index, value in enumerate(series_values[series_index]):
            value_cell = workbook.getCell(0, category_index + 1, series_index + 1, jpype.JDouble(value))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        if series_index > 0:
            # Skryjte sloupce B a C, ale zachovejte jejich datové popisky.
            series.getFormat().getFill().setFillType(FillType.NoFill)
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
            label_format = series.getLabels().getDefaultDataLabelFormat()
            label_format.setShowValue(True)
            label_format.getTextFormat().getPortionFormat().setFontHeight(12)
            label_fill = label_format.getTextFormat().getPortionFormat().getFillFormat()
            label_fill.setFillType(FillType.Solid)
            label_fill.getSolidFillColor().setColor(Color.BLACK)
            label_format.setPosition(LegendDataLabelPosition.InsideBase)

    # Zarovnejte všechny tři série ke stejným středům kategorií.
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setOverlap(jpype.JByte(100))

    # Použijte méně mřížkových čar pro tento kompaktní příklad.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setMajorUnit(10)

    # Rezervujte místo nad grafem pro dva řádky datových popisků.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner)
    chart.getPlotArea().setX(0.15)
    chart.getPlotArea().setY(0.32)
    chart.getPlotArea().setWidth(0.80)
    chart.getPlotArea().setHeight(0.48)
    chart.validateChartLayout()

    for series_index in range(1, len(series_names)):
        series = chart.getChartData().getSeries().get_Item(series_index)
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.getDataPoints().get_Item(category_index).getLabel()
            # Zachovejte výchozí vodorovnou pozici. Y je posun od
            # výchozí pozice popisku, vyjádřené jako zlomek výšky grafu.
            data_label.setX(0)
            data_label.setY(row_top - data_label.getActualY() / chart.getHeight())

        # Pouze nadpis řádku je samostatný textový tvar.
        heading_y = chart.getY() + row_top * chart.getHeight()
        row_heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, chart.getX(), heading_y, 85, 18)
        row_heading.getFillFormat().setFillType(FillType.NoFill)
        row_heading.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        row_heading.addTextFrame(series_names[series_index])
        row_heading.getTextFrame().getTextFrameFormat().setMarginTop(0)
        row_heading.getTextFrame().getTextFrameFormat().setMarginBottom(0)
        heading_format = row_heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        heading_format.setFontHeight(12)
        heading_format.getFillFormat().setFillType(FillType.Solid)
        heading_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **Často kladené otázky**

**Jak mohu zabránit překrývání datových popisků v hustých grafech?**

Kombinujte automatické umístění popisků, čáry vedoucí k popiskům a snížení velikosti písma; v případě potřeby skryjte některá pole (například kategorii) nebo zobrazujte popisky jen pro extrémní nebo klíčové hodnoty.

**Jak mohu zakázat popisky jen pro nulové, záporné nebo prázdné hodnoty?**

Filtrovejte datové body před povolením popisků a vypněte zobrazení pro hodnoty 0, záporné hodnoty nebo chybějící hodnoty podle definovaného pravidla.

**Jak zajistit jednotný styl popisků při exportu do PDF/obrázků?**

Explicitně nastavte rodinu písma a velikost a ověřte, že písmo je dostupné v renderovacím prostředí, aby nedošlo k náhradnímu písmu.