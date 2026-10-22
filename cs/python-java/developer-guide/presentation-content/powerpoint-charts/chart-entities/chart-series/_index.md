---
title: Správa datových sérií grafu v prezentacích v Pythonu
linktitle: Datové řady
type: docs
url: /cs/python-java/chart-series/
keywords:
- série grafu
- překrytí sérií
- barva série
- název série
- datový bod
- buňka sešitu
- mezera mezi sériemi
- záporná hodnota
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se, jak spravovat řady grafu, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích s Aspose.Slides pro Python přes Java."
---
## **Přehled**

Graf může ukládat své vykreslené hodnoty do buněk sešitu nebo přímo jako číselné literály. [ChartSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/) představuje jednu sadu souvisejících hodnot a každý [ChartDataPoint](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/) představuje bod v této sérii. Objekt [ChartCategory](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/) poskytuje popisky nebo seskupovací hodnoty sdílené sériemi. V grafech vytvořených s výchozími daty používají názvy sérií, kategorie a hodnoty bodů objekty [ChartDataCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/) z pracovního sešitu grafu.

U typického kategoriového grafu výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty sérií. Indexy listu, řádku a sloupce předávané metodě [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) jsou nulové‑založené. Toto rozložení je užitečné, když vytvoříte graf s výchozími daty, ale nepředpokládejte, že takto funguje každý existující graf. Pro načtenou prezentaci si před změnou hodnot v sešitu prohlédněte buňky, na které odkazují série, kategorie a datové body.

Nastavení grafu mají tři různé rozsahy:

- Nastavení na úrovni série, například [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat), poskytuje výchozí vzhled pro všechny body v jedné sérii.
- Nastavení jednotlivých bodů, například [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat), přebíjí vzhled série pro jeden bod.
- Skupinová nastavení se vztahují na kompatibilní série, které patří do stejné [ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/). Skupinu získáte pomocí [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getParentSeriesGroup), když potřebujete nastavit například překrytí nebo šířku mezery.

Když není nastaven žádný explicitní výplň bodu nebo série, určuje automatický vzhled styl a motiv grafu. Když jsou přítomna jak nastavení série, tak bodu, převáží nastavení bodu pro daný bod.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení hodnot série pomocí číselných literálů**

Používejte číselné literály, když hodnoty série pocházejí z aplikačních dat nebo výpočtů a nepotřebují odkazy na buňky listu. Zavolejte [setDataSourceTypeForValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForValues) s [DataSourceType.DoubleLiterals](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/#DoubleLiterals) před přiřazením výsledku [getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue) každého bodu pomocí [setAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#setAsLiteralDouble).

Nastavení kolekce řídí typ zdroje všech hodnot bodů v dané sérii. Metoda [getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/basechartvalue/#getDataSourceType) každé hodnoty bodu udává vybraný typ; změňte jej pomocí nastavení kolekce. S `Worksheet` použijte [getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsCell) pro přístup k odkazované buňce. S `DoubleLiterals` použijte [getAsLiteralDouble](https://reference.aspose.com/slides/python-java/aspose.slides/doublechartvalue/#getAsLiteralDouble) nebo `setAsLiteralDouble` pro přímé čtení nebo zápis čísla.

Následující příklad vytvoří sloupcový graf s výchozími sériemi a kategoriemi a přiřadí vypočtené hodnoty 10, 20 atd. k existujícím bodům první série. Uloží prezentaci, znovu ji otevře a vytiskne uložené hodnoty.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)
    series = chart.getChartData().getSeries().get_Item(0)

    series.getDataPoints().setDataSourceTypeForValues(DataSourceType.DoubleLiterals)
    for i in range(series.getDataPoints().size()):
        series.getDataPoints().get_Item(i).getValue().setAsLiteralDouble((i + 1) * 10)

    presentation.save("numeric_literals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("numeric_literals.pptx")
try:
    reopened_slide = reopened_presentation.getSlides().get_Item(0)
    reopened_chart = reopened_slide.getShapes().get_Item(0)
    reopened_series = reopened_chart.getChartData().getSeries().get_Item(0)
    for point in reopened_series.getDataPoints():
        print(point.getValue().getAsLiteralDouble())
finally:
    reopened_presentation.dispose()
```

Typ zdroje hodnoty bodu je oddělený od [ChartData.getDataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType), který určuje interní nebo externí konfiguraci pracovního sešitu grafu. Použití číselných literálů samo o sobě neodstraňuje vložený sešit. V tomto příkladu zůstává sešit dostupný pro popisky kategorií, názvy sérií a ostatní série. Viz [Chart Workbook](/slides/cs/python-java/chart-workbook/) pro správu sešitu.

U rozptylových a bublinových grafů použijte [setDataSourceTypeForXValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForXValues) a [setDataSourceTypeForYValues](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForYValues) pro výběr zdrojů pro [getXValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getXValue) a [getYValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getYValue). Bublinové grafy také používají [setDataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#setDataSourceTypeForBubbleSizes) pro [getBubbleSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getBubbleSize). Nastavte každý relevantní zdroj na `DoubleLiterals` před přiřazením čísel pomocí metody `setAsLiteralDouble`.

## **Nastavení překrytí sérií v grafu**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getOverlap) udává, jak moc se překrývají pruhy nebo sloupce v 2‑D grafu, v rozmezí –100 % až 100 %. Jedná se o čtení‑pouze projekci nastavení v rodičovské skupině sérií. Použijte [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setOverlap) pro aktualizaci všech kompatibilních sérií v této skupině. Tato volba se vztahuje na typy grafů, které zobrazují seskupené pruhy nebo sloupce; neovlivňuje nesouvisející skupiny sérií v kombinovaném grafu.

Následující příklad nastaví překrytí pro skupinu, která obsahuje první sérii:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    # Nový graf obsahuje ukázkové série, kategorie a hodnoty.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setOverlap(overlap_percent)

    presentation.save("series_overlap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![The series overlap](series_overlap.png)

## **Změna barvy výplně série**

Použijte [ChartSeries.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getFormat) pro nastavení výchozí výplně celé série. Pokud má bod již explicitní výplň, jeho nastavení [ChartDataPoint.getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getFormat) přebíjí výplň série pro daný bod.

Následující příklad aplikuje jednolitý modrý odkaz na první sérii:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("series_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![The color of the series](series_color.png)

## **Změna názvu série**

Název série je uložen v pracovním sešitu grafu a obvykle se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro seskupený sloupcový graf je buňka B1 (řádek 0, sloupec 1) a obsahuje název první série. Pojmenované proměnné v následujícím příkladu tuto strukturu explicitně zobrazují:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    workbook = chart.getChartData().getChartDataWorkbook()
    series_name_cell = workbook.getCell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Můžete také upravit buňku, na kterou již odkazuje [ChartSeries.getName](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getName). Tento přístup se vyhýbá předpokladu konkrétního řádku a sloupce v existujícím grafu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series_name_cell = series.getName().getAsCells().get_Item(first_name_cell_index)
    series_name_cell.setValue("Revenue")

    presentation.save("series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![The series name](series_name.png)

### **Vytvoření série s názvem ze více buněk**

Složený název série je užitečný, když jsou název produktu a období vykazování uloženy v samostatných buňkách sešitu. Například můžete zkombinovat `Product A` v B1 a `2026` v C1 do jednoho názvu série a přitom mít oba části propojené na jejich zdrojové buňky.

Použijte [ChartDataWorkbook.getCellCollection](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCellCollection) pro získání rozsahu názvu a poté předáte tuto kolekci metodě [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriescollection/#add). Argument `skipHiddenCells` určuje, zda jsou zahrnuty skryté buňky: `True` je vyloučí, `False` zahrne. Tento příklad používá `False` pro zahrnutí všech buněk v rozsahu názvu.

Následující příklad vytvoří prezentaci s jednou sérií a dvěma datovými body. Buňky B1:C1 poskytují jen název série; A2:A3 poskytují popisky kategorií a B2:B3 poskytují číselné hodnoty.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 620, 180)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    chart.setLegend(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Tyto dvě buňky poskytují název řady.
    workbook.getCell(0, 0, 1, "Product A")
    workbook.getCell(0, 0, 2, "2026")
    name_cells = workbook.getCellCollection("Sheet1!$B$1:$C$1", False)
    series = chart.getChartData().getSeries().add(name_cells, ChartType.ClusteredColumn)

    # Samostatné buňky poskytují kategorie a číselné datové body.
    north_category = workbook.getCell(0, 1, 0, "North")
    south_category = workbook.getCell(0, 2, 0, "South")
    chart.getChartData().getCategories().add(north_category)
    chart.getChartData().getCategories().add(south_category)
    north_value = workbook.getCell(0, 1, 1, jpype.JInt(120))
    south_value = workbook.getCell(0, 2, 1, jpype.JInt(150))
    series.getDataPoints().addDataPointForBarSeries(north_value)
    series.getDataPoints().addDataPointForBarSeries(south_value)

    presentation.save("composite_series_name.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledný název série je `Product A 2026` s mezerou mezi hodnotami dvou buněk. Legenda jej zobrazuje jako jeden záznam pro oba sloupce. Obrázek níže ukazuje výsledek:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Získání automatické barvy výplně série**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) vrací barvu vypočítanou z indexu série a stylu grafu. Jedná se o barvu použité, když výplň série není explicitně definována. Volání metody načte vypočítanou barvu; nepřiřadí novou výplň.

Následující příklad vytiskne automatickou barvu každé výchozí série:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

first_slide_index = 0

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series_count = chart.getChartData().getSeries().size()
    for series_index in range(series_count):
        series = chart.getChartData().getSeries().get_Item(series_index)
        automatic_color = series.getAutomaticSeriesColor()
        print(f"Series {series_index}: {automatic_color}")
finally:
    presentation.dispose()
```

Výstup příkladu pro výchozí styl grafu:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Přesné barvy závisí na stylu a motivu grafu.

## **Nastavení invertované výplně pro sérii grafu**

U sérií pruhů, sloupců a bublin může [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) zobrazit záporné hodnoty jinou výplní. Nastavte běžnou výplň série na jednolitý, povolte inverzi a přiřaďte barvu záporných hodnot pomocí [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Záporná čísla zůstávají v sešitu nezměněna; mění se jen jejich zobrazovací barva.

Následující příklad nahradí výchozí data grafu jednou sérií. Řádek 0 listu obsahuje název série, sloupec 0 obsahuje názvy kategorií a sloupec 1 obsahuje hodnoty:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    chart_type = chart.getType()
    series = chart_data.getSeries().add(series_name_cell, chart_type)

    for category_index in range(len(category_names)):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.getCell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.setInvertIfNegative(True)
    series.getInvertedSolidFillColor().setColor(Color.RED)

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![The inverted solid fill color](inverted_solid_fill_color.png)

Inverzi můžete povolit pro jeden bod pomocí [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). V následujícím příkladu je inverze zakázána pro sérii a povolena jen pro vybraný bod. Bod je navíc přiřazen zápornou hodnotou, aby byl efekt viditelný:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    automatic_series_color = series.getAutomaticSeriesColor()
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(automatic_series_color)
    series.getInvertedSolidFillColor().setColor(Color.RED)
    series.setInvertIfNegative(False)

    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(negative_value)
    data_point.setInvertIfNegative(True)

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Vymazání konkrétní hodnoty datového bodu**

Chcete‑li jeden bod učinit prázdným bez odebrání ostatních bodů, nastavte jeho podkladovou buňku sešitu na `None`. U sloupcového grafu je vykreslená hodnota dostupná přes [ChartDataPoint.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getValue). Datový bod zůstane ve stejné pozici kategorie, ale graf jej bude považovat za prázdnou hodnotu podle nastavení prázdných hodnot grafu.

Následující příklad vymaže jen druhý bod v první sérii:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    data_point = series.getDataPoints().get_Item(target_data_point_index)
    data_point.getValue().getAsCell().setValue(None)

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Rozptylové grafy používají samostatné buňky X a Y a bublinové grafy také buňku velikosti. Vymažte jen buňku, která představuje hodnotu, kterou chcete odstranit. Nezavolejte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear), když chcete zachovat ostatní body, protože tato metoda odstraní všechny datové body z kolekce.

## **Řízení zobrazení prázdných buněk**

Skryté buňky, které obsahují hodnoty, jsou odlišným případem než prázdné buňky. Pro zahrnutí nebo vyloučení dat ze skrytých řádků a sloupců listu viz [Include Data from Hidden Rows and Columns](/slides/cs/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Prázdná buňka sešitu představuje chybějící data; buňka obsahující `0` představuje známou číselnou hodnotu. Zavolejte [ChartDataCell.setValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setValue) s `None` pro prázdnění buňky. Číselná nula zůstává nulou bez ohledu na nastavení prázdných buněk.

Použijte [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) k výběru, jak má graf zobrazovat prázdné buňky. Toto nastavení platí pro celý graf. Mění způsob, jakým jsou prázdná místa vykreslena, aniž by se prázdná buňka v sešitu vyplňovala nulou nebo interpolovanou hodnotou.

Následující samostatný příklad vytvoří čárový graf s jednou sérií, vymaže hodnotu pro den 3 a uloží stejný graf ve všech třech režimech. Vstupní soubor není potřeba. [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) používá list 0, sloupec 0 pro popisky kategorií a sloupec 1 pro hodnoty; řádek 0 obsahuje název série. Konečná data jsou `10, 20, empty, 30, 40`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayBlanksAsType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 40, 40, 640, 400)
    chart_data = chart.getChartData()
    workbook = chart_data.getChartDataWorkbook()

    chart_data.getSeries().clear()
    chart_data.getCategories().clear()

    series_name_cell = workbook.getCell(0, 0, 1, "Measurements")
    series = chart_data.getSeries().add(series_name_cell, chart.getType())
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Nechte den 3. den skutečně prázdný, při zachování jeho kategorie a datového bodu.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Každý výstupní soubor uloží režim přiřazený před uložením: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` a `empty_cells_Span.pptx`. Pro uložení jen jedné verze nastavte požadovaný režim a uložte prezentaci jednou místo iterace přes režimy.

Porovnání níže ukazuje stejná data ve všech třech souborech. Den 3 je v sešitu prázdný ve všech případech:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Viditelný efekt závisí na typu grafu. Čárový graf umožňuje snadno porovnat všechny tři režimy. Pruhové a sloupcové grafy nemají čáru, kterou by spojila chybějící kategorii, takže `Span` nemůže vytvořit spojovací segment jako výše; prázdný sloupec a sloupec nulové výšky mohou také vypadat podobně. Podobně rozptylový graf jen s body nemá spojovací čáru. Neočekávejte tři odlišné výsledky u každého typu grafu; ověřte výstup pro typ, který používáte.

## **Nastavení šířky mezery mezi sériemi**

Šířka mezery je prostor mezi sousedními shluky pruhů nebo sloupců, vyjádřený v procentech šířky pruhu nebo sloupce. Stejně jako překrytí patří této hodnotě nadřazená skupina sérií, nikoli konkrétní série. Zavolejte [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) jednou pro skupinu. Větší hodnota vytvoří více prostoru mezi shluky; menší hodnota je učiní hustšími.

Následující příklad změní šířku mezery a uloží jen konečnou prezentaci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(first_slide_index)

    chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200)

    series = chart.getChartData().getSeries().get_Item(first_series_index)
    series.getParentSeriesGroup().setGapWidth(gap_width_percent)

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![The gap width](gap_width.png)

## **Často kladené otázky**

**Které typy grafů podporují datové série?**

Všechny typy grafů reprezentované výčtem [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) používají data grafu, ale jejich série nemají všechny stejnou strukturu hodnot nebo nastavení. Například kategoriové grafy používají kategorie a hodnoty, rozptylové grafy používají X a Y hodnoty a bublinové grafy přidávají velikosti bublin. Použijte metodu tvorby datových bodů, která odpovídá typu série. Volby jako překrytí a šířka mezery se vztahují jen na kompatibilní skupiny pruhů nebo sloupců.

**Co je skupina sérií grafu?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/) obsahuje kompatibilní série, které sdílejí nastavení na úrovni skupiny. Kombinovaný graf může obsahovat více než jednu skupinu, takže změna skupiny získaná skrze jednu sérii nutně nemění všechny série v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení [ShapeCollection.addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) vytvoří ukázkové série, kategorie a hodnoty. Můžete tyto buňky upravit nebo vymazat jak série, tak kolekce kategorií před přidáním zcela vlastního datového souboru. Přetížení může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu propojeny s buňkami sešitu?**

Názvy sérií, popisky kategorií a hodnoty datových bodů odkazují na buňky v [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající prvek grafu. Při vytváření vlastních dat udržujte řádky kategorií a řádky hodnot sérií zarovnané, aby každý bod byl vykreslen pod správnou kategorií.

**Jak vymazat jeden bod místo celé série?**

Nastavte příslušnou buňku hodnoty na `None`, aby bod zůstal ve své pozici kategorie jako prázdný bod. Použijte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#clear) pouze tehdy, když chcete odstranit všechny body z dané série. Pokud odstraňujete i kategorie, aktualizujte všechny série, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou prázdné body zobrazovány?**

Výsledek závisí na typu grafu a na hodnotě nastavené pomocí [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs). Podporované grafy mohou zobrazovat prázdná místa jako mezery, jako nulové hodnoty nebo spojováním sousedních bodů. Vyberte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci. Viz [Control the Display of Empty Cells](#control-the-display-of-empty-cells) pro kompletní příklad a vizuální srovnání.

**Jak jsou formátovány záporné hodnoty?**

Pro podporované pruhové, sloupcové a bublinové série zavolejte [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setInvertIfNegative) a nastavte barvu vrácenou metodou [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Chování můžete přebít pro jednotlivý bod pomocí [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Tyto metody ovlivňují formátování, nikoli uložené číselné hodnoty.

**Které formátování má přednost, když je formátována jak série, tak bod?**

Explicitní formátování datového bodu má přednost pro daný bod. Ostatní body nadále používají explicitní formátování série nebo, pokud není formát série definován, automatický styl a motiv grafu. Skupinová nastavení jako překrytí a šířka mezery řídí rozložení a nejsou přebíjeni na úrovni bodu.

**Existuje limit počtu sérií, které může graf obsahovat?**

Aspose.Slides neukládá zvláštní pevný limit počtu sérií. V praxi určují omezení souboru prezentace, dostupná paměť, čas renderování a čitelnost grafu praktické limity.

**Co změnit, když jsou sloupce příliš blízko nebo příliš daleko od sebe?**

Zavolejte [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setGapWidth) na příslušné nadřazené skupině sérií. Zvyšte hodnotu pro zvětšení prostoru mezi shluky nebo ji snižte pro jejich přiblížení.