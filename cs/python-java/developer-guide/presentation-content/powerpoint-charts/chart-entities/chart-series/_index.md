---
title: Správa datových sérií grafu v prezentacích v Pythonu
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
- mezera mezi sériemi
- záporná hodnota
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se, jak spravovat série grafu, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích s Aspose.Slides pro Python pomocí Java."
---
## **Přehled**

Graf ukládá svá vykreslená data do sešitu dat grafu. [ChartSeries](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/) představuje jednu sadu souvisejících hodnot a každá [ChartDataPoint](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapoint/) ve sérii odkazuje na jednu nebo více buněk sešitu. Objekt [ChartCategory](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartcategory/) poskytuje popisky nebo hodnoty seskupení sdílené mezi sériemi. Název série, kategorie a hodnoty bodů jsou tedy propojeny s objekty [ChartDataCell](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatacell/), nikoli uloženy pouze jako zobrazovaný text.

U typického kategoriálního grafu výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty sérií. Indexy listu, řádku a sloupce předávané metodě [ChartDataWorkbook.getCell](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdataworkbook/#getCell) jsou nulové. Toto uspořádání je užitečné, když vytváříte graf s výchozími daty, ale nepředpokládejte, že každý existující graf ho používá. Pro načtenou prezentaci si před změnou hodnot v sešitu prohlédněte buňky odkazované sériemi, kategoriemi a datovými body.

Nastavení grafu mají tři různé úrovně:

- Nastavení na úrovni série, například [ChartSeries.getFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#getFormat), poskytuje výchozí vzhled pro všechny body v jedné sérii.
- Nastavení datového bodu, například [ChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapoint/#getFormat), přepíše vzhled série pro jeden bod.
- Skupinová nastavení se vztahují na kompatibilní série, které patří do stejné [ChartSeriesGroup](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseriesgroup/). Přístup ke skupině získáte přes [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#getParentSeriesGroup), když potřebujete nastavit volby jako překrytí nebo šířku mezery.

Když není nastaven žádný explicitní výplň bodu nebo série, určuje automatický vzhled styl a motiv grafu. Když jsou přítomna formátování série i bodu, formátování bodu má přednost pro daný bod.

![graf-serií-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí sérií grafu**

[ChartSeries.getOverlap](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#getOverlap) udává, jak moc se překrývají pruhy nebo sloupce ve 2D grafu, v rozmezí -100 až 100 procent. Jedná se o jen‑čtení projekce nastavení na nadřazenou skupinu sérií. Použijte [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseriesgroup/#setOverlap) k aktualizaci všech kompatibilních sérií v této skupině. Tato volba se vztahuje na typy grafů, které zobrazují seskupené pruhy nebo sloupce; neovlivňuje nesouvisející skupiny sérií v kombinovaném grafu.

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

![Překrytí sérií](series_overlap.png)

## **Změna barvy výplně série**

Pomocí [ChartSeries.getFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#getFormat) můžete nastavit výchozí výplň pro celou sérii. Pokud má bod již explicitní výplň, jeho nastavení [ChartDataPoint.getFormat](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapoint/#getFormat) přepíše výplň série pro tento bod.

Následující příklad aplikuje jednolitou modrou výplň na první sérii:

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

![Barva série](series_color.png)

## **Změna názvu série**

Název série je uložen v sešitu dat grafu a obvykle se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro seskupený sloupcový graf je buňka B1 na řádku 0, sloupci 1 a obsahuje název první série. Pojmenované proměnné v následujícím příkladu tuto strukturu explicitně zobrazuje:

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

Můžete také aktualizovat buňku, na kterou již odkazuje [ChartSeries.getName](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#getName). Tento přístup se vyhýbá předpokladu konkrétního řádku a sloupce v existujícím grafu:

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

![Název série](series_name.png)

## **Získání automatické barvy výplně série**

[ChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#getAutomaticSeriesColor) vrací barvu vypočítanou z indexu série a stylu grafu. Jedná se o barvu použitou, když výplň série nebyla explicitně definována. Volání metody pouze načte vypočítanou barvu; nenastavuje novou výplň.

Následující příklad vypíše automatickou barvu každé výchozí série:

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

Přesné barvy závisí na stylu a motivu grafu.

## **Nastavení obrácené barvy výplně pro sérii grafu**

U sérií sloupců, pruhů a bublin může [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#setInvertIfNegative) zobrazit záporné hodnoty jinou výplní. Nastavte normální výplň série na jednolitou, povolte invertování a přiřaďte barvu záporných hodnot pomocí [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Záporná čísla zůstávají v sešitu beze změny; mění se pouze jejich zobrazená barva.

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

![Obrácená jednolitá výplň](inverted_solid_fill_color.png)

Invertování můžete povolit pro jeden bod pomocí [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). V následujícím příkladu je invertování zakázáno pro sérii a povoleno jen pro vybraný bod. Bod má také přiřazenou zápornou hodnotu, aby byl efekt viditelný:

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

Chcete‑li učinit jeden bod prázdný, aniž byste odstraňovali ostatní body, nastavte jeho podpůrnou buňku v sešitu na `None`. Pro sloupcový graf je vykreslená hodnota dostupná přes [ChartDataPoint.getValue](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapoint/#getValue). Datový bod zůstává na stejném místě kategorie, ale graf s jeho hodnotou zachází jako s prázdným podle nastavení prázdných hodnot grafu.

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

Rozptylové grafy používají samostatné buňky X a Y a bublinové grafy také buňku velikosti. Vymažte jen buňku, která představuje hodnotu, kterou chcete odstranit. Nepoužívejte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapointcollection/#clear), když chcete zachovat ostatní body, protože tato metoda odstraňuje všechny datové body ze sbírky.

## **Nastavení šířky mezery mezi sériemi**

Šířka mezery je prostor mezi sousedními skupinami pruhů nebo sloupců, vyjádřený jako procento šířky pruhu nebo sloupce. Stejně jako překrytí patří k nadřazené skupině sérií, nikoli k jedné sérii. Zavolejte [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseriesgroup/#setGapWidth) jednou pro celou skupinu. Větší hodnota vytváří větší prostor mezi skupinami; menší hodnota je činí hustšími.

Následující příklad mění šířku mezery a ukládá jen finální prezentaci:

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

![Šířka mezery](gap_width.png)

## **Často kladené otázky**

**Které typy grafů podporují datové série?**

Všechny typy grafů reprezentované výčtem [ChartType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/charttype/) používají data grafu, ale jejich série nemají vždy stejnou strukturu hodnot nebo nastavení. Například kategoriální grafy používají kategorie a hodnoty, rozptylové grafy používají hodnoty X a Y a bublinové grafy přidávají velikosti bublin. Použijte metodu vytváření datových bodů, která odpovídá typu série. Volby jako překrytí a šířka mezery se vztahují jen na kompatibilní skupiny pruhů nebo sloupců.

**Co je skupina sérií grafu?**

[ChartSeriesGroup](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseriesgroup/) obsahuje kompatibilní série, které sdílejí nastavení úrovně skupiny. Kombinovaný graf může obsahovat více než jednu skupinu, takže změna skupiny dosažené přes jednu sérii nemusí nutně změnit všechny série v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení metoda [ShapeCollection.addChart](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/#addChart) vytvoří ukázkové série, kategorie a hodnoty. Tyto buňky můžete upravit nebo vymazat jak série, tak kolekce kategorií před přidáním zcela vlastního datasetu. Přetížení může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu propojeny s buňkami sešitu?**

Názvy sérií, popisky kategorií a hodnoty datových bodů odkazují na buňky v [ChartDataWorkbook](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající prvek grafu. Při tvorbě vlastních dat udržujte řádky kategorií a řádky hodnot sérií zarovnané, aby každý bod byl vykreslen pod zamýšlenou kategorií.

**Jak vymažu jeden bod místo celé série?**

Nastavte příslušnou buňku hodnoty na `None`, aby bod zůstal na pozici kategorie jako prázdný bod. Používejte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapointcollection/#clear) jen tehdy, když chcete odstranit všechny body ze série. Pokud také odstraňujete kategorie, aktualizujte všechny série, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak se zobrazují prázdné body?**

Výsledek závisí na typu grafu a na nastavení hodnoty konfigurované přes [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chart/#setDisplayBlanksAs). Podporované grafy mohou zobrazovat prázdné hodnoty jako mezery, jako nuly nebo spojením sousedních bodů. Vyberte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci.

**Jak jsou formátovány záporné hodnoty?**

U podporovaných sérií sloupců, pruhů a bublin zavolejte [ChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#setInvertIfNegative) a nastavte barvu vrácenou metodou [ChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseries/#getInvertedSolidFillColor). Chování můžete přepsat pro jednotlivý bod pomocí [ChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartdatapoint/#setInvertIfNegative). Tyto metody ovlivňují formátování, ne uložené číselné hodnoty.

**Které formátování má přednost, když je formátována jak série, tak bod?**

Explicitní formátování datového bodu má přednost pro daný bod. Ostatní body nadále používají explicitní formát série nebo, pokud není formát série definován, automatický styl a motiv grafu. Skupinová nastavení, jako jsou překrytí a šířka mezery, řídí rozvržení a nejsou přepisovány na úrovni bodu.

**Existuje limit počtu sérií, které může graf obsahovat?**

Aspose.Slides neukládá samostatný pevný limit počtu sérií. V praxi určují omezení souboru prezentace, dostupná paměť, doba vykreslování a čitelnost grafu užitečný limit.

**Co změnit, když jsou sloupce příliš blízko u sebe nebo příliš daleko?**

Zavolejte [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/cs/python-java/aspose.slides/chartseriesgroup/#setGapWidth) na odpovídající nadřazenou skupinu sérií. Zvýšte hodnotu pro rozšíření prostoru mezi skupinami nebo ji snižte, aby se skupiny přiblížily.