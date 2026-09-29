---
title: Správa sérií dat grafu v prezentacích v Pythonu
linktitle: Datové série
type: docs
url: /cs/python-java/chart-series/
keywords:
- série grafu
- překrytí sérií
- barva série
- název série
- datový bod
- buňka sešitu
- mezera série
- záporná hodnota
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se, jak spravovat série grafu, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Graf ukládá svá vykreslená data do sešitu s daty grafu. A [ChartSeries](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/) představuje jednu sadu souvisejících hodnot a každý [ChartDataPoint](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapoint/) v sérii odkazuje na jednu nebo více buněk sešitu. Objekty [ChartCategory](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartcategory/) poskytují štítky nebo hodnoty seskupení sdílené sériemi. Název série, kategorie a hodnoty bodů jsou tedy propojeny s objekty [ChartDataCell](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatacell/), nikoli uloženy pouze jako zobrazovaný text.

Pro typický kategoriální graf výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty sérií. Indexy listu, řádku a sloupce předávané metodě [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdataworkbook/#getCell) jsou nulové (zero‑based). Toto uspořádání je užitečné, když vytvoříte graf s výchozími daty, ale nepředpokládejte, že každý existující graf jej používá. U načtené prezentace prohlédněte buňky, na které odkazují série, kategorie a datové body, před tím, než změníte hodnoty v sešitu.

Nastavení grafu mají tři různé rozsahy:

- Nastavení na úrovni série, jako je [ChartSeries.getFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#getFormat), poskytuje výchozí vzhled pro všechny body v jedné sérii.
- Nastavení datových bodů, jako je [ChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapoint/#getFormat), přepíše vzhled série pro jeden bod.
- Nastavení skupiny se vztahuje na kompatibilní série, které patří do stejné [ChartSeriesGroup](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseriesgroup/). Přístup ke skupině získáte pomocí [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#getParentSeriesGroup), když potřebujete nastavit možnosti jako překrytí nebo šířka mezery.

Když není nastaveno žádné explicitní vyplnění bodu nebo série, určuje automatický vzhled styl grafu a motiv. Když jsou přítomny formátování série i bodu, formátování bodu má přednost pro daný bod.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí série grafu**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#getOverlap) udává, jak moc se překrývají sloupce nebo pruhy v 2D grafu, v rozmezí od -100 do 100 procent. Jedná se o jen pro čtení projekci nastavení na rodičovskou skupinu sérií. Použijte [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseriesgroup/#setOverlap), abyste aktualizovali každou kompatibilní sérii v této skupině. Tato možnost se vztahuje na typy grafů, které zobrazují seskupené sloupce nebo pruhy; neovlivňuje nesouvisející skupiny sérií v kombinovaném grafu.

Následující příklad nastavuje překrytí pro skupinu, která obsahuje první sérii:

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

Použijte [ChartSeries.getFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#getFormat), abyste nastavili výchozí výplň pro celou sérii. Pokud má bod již explicitní výplň, jeho nastavení [ChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapoint/#getFormat) přepíše výplň série pro tento bod.

Následující příklad aplikuje pevnou modrou výplň na první sérii:

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

Název série je uložen v sešitu s daty grafu a obvykle se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro seskupený sloupcový graf je buňka B1 v řádku 0, sloupci 1 a obsahuje název první série. Pojmenované proměnné v následujícím příkladu tuto strukturu explicitně ukazují:

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

Můžete také aktualizovat buňku, na kterou již odkazuje [ChartSeries.getName](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#getName). Tento přístup se vyhýbá předpokládání konkrétního řádku a sloupce v existujícím grafu:

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

## **Získání automatické barvy výplně série**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) vrací barvu vypočítanou z indexu série a stylu grafu. Toto je barva použitá, když výplň série není explicitně definována. Volání metody načte vypočítanou barvu; nepřiřadí novou výplň.

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

Ukázkový výstup pro výchozí styl grafu:

```text
Series 0: java.awt.Color[r=79,g=129,b=189]
Series 1: java.awt.Color[r=192,g=80,b=77]
Series 2: java.awt.Color[r=155,g=187,b=89]
```

Přesné barvy závisí na stylu grafu a motivu.

## **Nastavení invertované barvy výplně pro sérii grafu**

Pro řádkové, sloupcové a bublinové série může [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#setInvertIfNegative) zobrazit záporné hodnoty s odlišnou výplní. Nastavte běžnou výplň série na pevnou, povolte inverzi a přiřaďte barvu záporné hodnoty pomocí [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Záporná čísla zůstávají v sešitu beze změny; mění se pouze jejich zobrazovaná barva.

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

Inverzi můžete povolit pro jeden bod pomocí [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). V následujícím příkladu je inverze pro sérii zakázána a povolena jen pro vybraný bod. Bod také získá zápornou hodnotu, aby byl efekt viditelný:

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

Aby byl jeden bod prázdný, aniž by se odstranily ostatní body, nastavte jeho podkladovou buňku sešitu na `None`. Pro sloupcový graf je vykreslená hodnota dostupná přes [ChartDataPoint.getValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapoint/#getValue). Datový bod zůstane na stejné pozici kategorie, ale graf zachází s jeho hodnotou jako s prázdnou podle nastavení prázdných hodnot grafu.

Následující příklad vymaže pouze druhý bod v první sérii:

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

Rozptylové grafy používají samostatné buňky X a Y a bublinové grafy také používají buňku velikosti. Vymažte pouze buňku, která představuje hodnotu, kterou chcete odstranit. Nepoužívejte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapointcollection/#clear), pokud chcete zachovat ostatní body, protože tato metoda odstraní všechny datové body ze sbírky.

## **Řízení zobrazení prázdných buněk**

Skryté buňky, které obsahují hodnoty, jsou odlišným případem od prázdných buněk. Pro zahrnutí nebo vyloučení dat ze skrytých řádků a sloupců listu viz [Zahrnout data ze skrytých řádků a sloupců](/slides/cs/python-java/chart-workbook/#include-data-from-hidden-rows-and-columns).

Prázdná buňka sešitu představuje chybějící data; buňka obsahující `0` představuje známou číselnou hodnotu. Zavolejte [ChartDataCell.setValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatacell/#setValue) s `None`, aby buňka byla prázdná. Číselná nula zůstane nulou bez ohledu na nastavení prázdné buňky.

Použijte [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#setDisplayBlanksAs), abyste zvolili, jak graf zobrazuje prázdné buňky. Toto nastavení se vztahuje na celý graf. Mění způsob, jakým jsou prázdné hodnoty vykreslovány, aniž by se prázdná buňka sešitu vyplnila nulou nebo interpolovanou hodnotou.

Následující samostatný příklad vytvoří čárový graf s jednou sérií, vymaže hodnotu pro den 3 a uloží stejný graf v každém režimu. Vstupní soubor není potřeba. [ChartDataWorkbook](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdataworkbook/) používá list 0, sloupec 0 pro štítky kategorií a sloupec 1 pro hodnoty; řádek 0 obsahuje název série. Konečná data jsou `10, 20, empty, 30, 40`.

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

    # Nechte den 3 skutečně prázdný, přičemž zachováte jeho kategorii a datový bod.
    workbook.getCell(0, 3, 1).setValue(None)

    modes = [DisplayBlanksAsType.Gap, DisplayBlanksAsType.Zero, DisplayBlanksAsType.Span]
    mode_names = ["Gap", "Zero", "Span"]
    for mode, mode_name in zip(modes, mode_names):
        chart.setDisplayBlanksAs(mode)
        presentation.save(f"empty_cells_{mode_name}.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Každý výstupní soubor uloží režim přiřazený před uložením: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` a `empty_cells_Span.pptx`. Pro uložení jen jedné verze přiřaďte požadovaný režim a uložte prezentaci jednou místo iterace přes režimy.

Porovnání níže ukazuje stejná data ve všech třech souborech. Den 3 je v sešitu prázdný ve všech případech:

![Čárové grafy se stejnými daty: Gap přeruší čáru v den 3, Zero snižuje čáru na nulu a Span spojuje den 2 s dnem 4.](display_blanks_as.png)

Viditelný efekt závisí na typu grafu. Čárový graf usnadňuje porovnání všech tří režimů. Proužkové a sloupcové grafy nemají čáru, která by spojovala chybějící kategorii, takže `Span` nemůže vytvořit spojovací segment zobrazený výše; chybějící sloupec a sloupec s nulovou výškou mohou také vypadat podobně. Podobně rozptylový graf s pouze značkami nemá spojovací čáru. Neočekávejte tři odlišné výsledky pro každý typ grafu; zkontrolujte výstup pro typ, který používáte.

## **Nastavení šířky mezery série**

Šířka mezery je prostor mezi sousedními shluky sloupců nebo pruhů, vyjádřený jako procento šířky sloupce nebo pruhu. Podobně jako překrytí patří k rodičovské skupině sérií, nikoli k jedné sérii. Zavolejte [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseriesgroup/#setGapWidth) jednou pro skupinu. Větší hodnota vytvoří více prostoru mezi shluky; menší hodnota je učiní hustšími.

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

## **FAQ**

**Které typy grafů podporují datové série?**

Všechny typy grafů zastoupené výčtem [ChartType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/charttype/) používají data grafu, ale jejich série nemají vždy stejnou strukturu hodnot nebo nastavení. Například kategoriální grafy používají kategorie a hodnoty, rozptylové grafy používají hodnoty X a Y a bublinové grafy přidávají velikosti bublin. Použijte metodu tvorby datových bodů, která odpovídá typu série. Možnosti jako překrytí a šířka mezery se vztahují pouze na kompatibilní skupiny pruhových nebo sloupcových grafů.

**Co je skupina sérií grafu?**

[ChartSeriesGroup](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseriesgroup/) obsahuje kompatibilní série, které sdílejí nastavení vykreslování na úrovni skupiny. Kombinovaný graf může obsahovat více než jednu skupinu, takže změna skupiny získané přes jednu sérii nutně neovlivní všechny série v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení [ShapeCollection.addChart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addChart) vytvoří ukázkové série, kategorie a hodnoty. Můžete tyto buňky upravit nebo vymazat jak sbírky sérií, tak kategorií před přidáním zcela vlastního datového souboru. Přetížení může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu propojeny s buňkami sešitu?**

Názvy sérií, štítky kategorií a hodnoty datových bodů odkazují na buňky v [ChartDataWorkbook](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající prvek grafu. Při tvorbě vlastních dat udržujte řádky kategorií a řádky hodnot sérií zarovnané tak, aby každý bod byl vykreslen pod zamýšlenou kategorií.

**Jak vymazat jeden bod místo celé série?**

Nastavte relevantní buňku hodnoty na `None`, aby se pozice kategorie bodu zachovala jako prázdný bod. Používejte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapointcollection/#clear) jen když chcete odstranit všechny body z dané série. Pokud také odstraňujete kategorie, aktualizujte každou sérii, aby jejich hodnoty zůstaly zarovnány se sbírkou kategorií.

**Jak jsou prázdné body zobrazovány?**

Výsledek závisí na typu grafu a hodnotě nastavené pomocí [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#setDisplayBlanksAs). Podporované grafy mohou zobrazovat prázdné hodnoty jako mezery, jako nulové hodnoty nebo spojením sousedních bodů. Zvolte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci. Viz [Řízení zobrazení prázdných buněk](#control-the-display-of-empty-cells) pro kompletní příklad a vizuální srovnání.

**Jak jsou záporné hodnoty formátovány?**

U podporovaných řádkových, sloupcových a bublinových sérií zavolejte [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#setInvertIfNegative) a nastavte barvu vrácenou metodou [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Chování můžete přepsat pro jednotlivý bod pomocí [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Tyto metody ovlivňují formátování, nikoli uložené číselné hodnoty.

**Které formátování má přednost, když jsou formátovány jak série, tak bod?**

Explicitní formátování datového bodu má přednost pro daný bod. Ostatní body nadále používají explicitní formát sérií nebo, pokud formát série není definován, automatický styl a motiv grafu. Skupinová nastavení jako překrytí a šířka mezery řídí rozvržení a nejsou přepisováním formátování na úrovni bodu.

**Existuje limit na počet sérií, které může graf obsahovat?**

Aspose.Slides neukládá samostatný pevný limit počtu sérií. V praxi omezují souborové limity prezentace, dostupná paměť, čas vykreslování a čitelnost grafu praktický limit.

**Co změnit, když jsou sloupce příliš blízko u sebe nebo příliš daleko?**

Zavolejte [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseriesgroup/#setGapWidth) na příslušné rodičovské skupině sérií. Zvýšením hodnoty rozšíříte prostor mezi shluky, snížením ho přiblížíte.