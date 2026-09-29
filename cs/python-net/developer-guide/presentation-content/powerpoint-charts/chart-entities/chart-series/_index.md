---
title: Správa datových sérií diagramu v prezentacích v Pythonu
linktitle: Datové série
type: docs
url: /cs/python-net/chart-series/
keywords:
- série diagramu
- překrytí sérií
- barva série
- barva kategorie
- název série
- datový bod
- mezera série
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Zjistěte, jak spravovat série diagramů, datové body, buňky pracovního sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích pomocí Pythonu."
---
## **Přehled**

Diagram ukládá svá vykreslená data do sešitu dat diagramu. [ChartSeries](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/) představuje jednu sadu souvisejících hodnot a každý [ChartDataPoint](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapoint/) v sérii odkazuje na jednu nebo více buněk sešitu. Objekt [ChartCategory](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartcategory/) poskytuje popisky nebo skupinové hodnoty sdílené sériemi. Název série, kategorie a hodnoty bodů jsou proto propojeny s objekty [ChartDataCell](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatacell/), místo aby byly uloženy pouze jako zobrazovaný text.

Pro typický kategoriální diagram výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty sérií. Indexy listu, řádku a sloupce předávané metodě [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) jsou nulové‑založené. Toto rozvržení je užitečné, když vytváříte diagram s výchozími daty, ale nepředpokládejte, že každý existující diagram jej používá. Pro načtenou prezentaci si před změnou hodnot sešitu prohlédněte buňky, na které odkazují série, kategorie a datové body.

Nastavení diagramu má tři různé úrovně:

- Nastavení na úrovni série, např. [ChartSeries.format](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/format/), poskytuje výchozí vzhled pro všechny body v jedné sérii.
- Nastavení datového bodu, např. [ChartDataPoint.format](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapoint/format/), přepíše vzhled série pro jeden bod.
- Skupinová nastavení se vztahují na kompatibilní série, které patří do stejné [ChartSeriesGroup](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseriesgroup/). Skupinu získáte přes [ChartSeries.parent_series_group](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/parent_series_group/), když potřebujete nastavit například překrytí nebo šířku mezery.

Když není explicitně nastaven výplň bodu ani série, určuje automatický vzhled styl a motiv diagramu. Když jsou současně přítomny formátování série i bodu, formátování bodu má přednost pro daný bod.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí sérií diagramu**

[ChartSeries.overlap](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/overlap/) udává, o kolik procent se překrývají pruhy nebo sloupce v 2D diagramu, v rozmezí -100 až 100 %. Jedná se o jen‑čtení projekci nastavení v nadřazené skupině sérií. Nastavte [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseriesgroup/overlap/) pro aktualizaci všech kompatibilních sérií v této skupině. Tato možnost se vztahuje na typy diagramů, které zobrazují seskupené pruhy nebo sloupce; neovlivní nesouvisející skupiny sérií v kombinovaném diagramu.

Následující příklad nastaví překrytí pro skupinu, která obsahuje první sérii:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Nový diagram obsahuje ukázkové série, kategorie a hodnoty.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![The series overlap](series_overlap.png)

## **Změna barvy výplně série**

Pomocí [ChartSeries.format](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/format/) můžete nastavit výchozí výplň pro celou sérii. Pokud má bod již explicitní výplň, jeho nastavení [ChartDataPoint.format](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapoint/format/) přepíše výplň série pro tento bod.

Následující příklad použije plnou modrou výplň na první sérii:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = drawing.Color.blue

    presentation.save("series_color.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![The color of the series](series_color.png)

## **Změna názvu série**

Název série je uložen v sešitu dat diagramu a obvykle se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro seskupený sloupcový diagram je buňka B1 v řádku 0, sloupci 1 a obsahuje název první série. Pojmenované konstanty v následujícím příkladu tuto strukturu explicitně uvádějí:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
series_name_row_index = 0
first_series_column_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    workbook = chart.chart_data.chart_data_workbook
    series_name_cell = workbook.get_cell(worksheet_index, series_name_row_index, first_series_column_index)
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Můžete také aktualizovat buňku, na kterou již odkazuje [ChartSeries.name](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/name/). Tento přístup eliminuje předpokládání konkrétního řádku a sloupce v existujícím diagramu:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
first_name_cell_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series_name_cell = series.name.as_cells[first_name_cell_index]
    series_name_cell.value = "Revenue"

    presentation.save("series_name.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![The series name](series_name.png)

## **Získání automatické barvy výplně série**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) vrací barvu vypočítanou z indexu série a stylu diagramu. Jedná se o barvu použitou, když není výplň série explicitně definována. Volání metody pouze načte vypočítanou barvu; nepřiřadí novou výplň.

Následující příklad vytiskne automatickou barvu každé výchozí série:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series_count = len(chart.chart_data.series)
    for series_index in range(series_count):
        series = chart.chart_data.series[series_index]
        automatic_color = series.get_automatic_series_color()
        print(f"Series {series_index}: {automatic_color.name}")
```

Ukázkový výstup pro výchozí styl diagramu:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Přesné barvy závisí na stylu a motivu diagramu.

## **Nastavení převrácené barvy výplně pro sérii diagramu**

Pro pruhové, sloupcové a bublinové série může [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/invert_if_negative/) zobrazovat záporné hodnoty jinou výplní. Nastavte běžnou výplň série na plnou, povolte převrácení a přiřaďte barvu záporných hodnot pomocí [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Záporná čísla v sešitu zůstávají beze změny; mění se jen jejich zobrazovaná barva.

Následující příklad nahradí výchozí data diagramu jednou sérií. Řádek 0 listu obsahuje název série, sloupec 0 obsahuje názvy kategorií a sloupec 1 obsahuje hodnoty:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
worksheet_index = 0
header_row_index = 0
category_column_index = 0
first_series_column_index = 1
first_data_row_index = 1

category_names = ["Category 1", "Category 2", "Category 3"]
series_values = [-20, 50, -30]

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(worksheet_index, header_row_index, first_series_column_index, "Series 1")
    series = chart_data.series.add(series_name_cell, chart.type)

    category_count = len(category_names)
    for category_index in range(category_count):
        data_row_index = first_data_row_index + category_index
        category_name = category_names[category_index]
        series_value = series_values[category_index]

        category_cell = workbook.get_cell(worksheet_index, data_row_index, category_column_index, category_name)
        chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, data_row_index, first_series_column_index, series_value)
        series.data_points.add_data_point_for_bar_series(value_cell)

    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.invert_if_negative = True
    series.inverted_solid_fill_color.color = drawing.Color.red

    presentation.save("inverted_solid_fill_color.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![The inverted solid fill color](inverted_solid_fill_color.png)

Převrácení můžete povolit pro jeden bod pomocí [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). V následujícím příkladu je převrácení deaktivováno pro sérii a povoleno pouze pro vybraný bod. Bod také dostane zápornou hodnotu, aby byl efekt viditelný:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 2
negative_value = -30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    automatic_series_color = series.get_automatic_series_color()
    series.format.fill.fill_type = slides.FillType.SOLID
    series.format.fill.solid_fill_color.color = automatic_series_color
    series.inverted_solid_fill_color.color = drawing.Color.red
    series.invert_if_negative = False

    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = negative_value
    data_point.invert_if_negative = True

    presentation.save("data_point_invert_color_if_negative.pptx", slides.export.SaveFormat.PPTX)
```

## **Vymazání konkrétní hodnoty datového bodu**

Chcete‑li učinit jeden bod prázdným, aniž byste odstranili ostatní body, nastavte jeho podpůrnou buňku sešitu na `None`. U sloupcového diagramu je vykreslená hodnota dostupná přes [ChartDataPoint.value](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapoint/value/). Datový bod zůstane na stejné pozici kategorie, ale diagram s ním zachází jako s prázdným podle nastavení prázdných hodnot diagramu.

Následující příklad vymaže pouze druhý bod v první sérii:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
target_data_point_index = 1

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    data_point = series.data_points[target_data_point_index]
    data_point.value.as_cell.value = None

    presentation.save("clear_data_point_value.pptx", slides.export.SaveFormat.PPTX)
```

Rozptylové diagramy používají samostatné buňky X a Y, bublinové diagramy také buňku velikosti. Vymažte jen buňku, která představuje hodnotu, kterou chcete odstranit. Nepoužívejte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapointcollection/clear/), pokud chcete zachovat ostatní body, protože tato metoda odstraní všechny datové body ze sbírky.

## **Řízení zobrazení prázdných buněk**

Skryté buňky, které obsahují hodnoty, jsou odlišným případem než prázdné buňky. Pro zahrnutí nebo vyloučení dat ze skrytých řádků a sloupců listu viz [Include Data from Hidden Rows and Columns](/slides/cs/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Prázdná buňka sešitu představuje chybějící data; buňka obsahující `0` představuje známou číselnou hodnotu. Nastavte [ChartDataCell.value](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatacell/value/) na `None`, aby buňka byla prázdná. Číselná nula zůstane nulou bez ohledu na nastavení prázdných buněk.

Pomocí [Chart.display_blanks_as](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/display_blanks_as/) vyberte, jak má diagram zobrazovat prázdné buňky. Toto nastavení platí pro celý diagram. Mění způsob vykreslování mezer, aniž by prázdná buňka sešitu byla vyplněna nulou nebo interpolovanou hodnotou.

Následující samostatný příklad vytvoří čárový diagram s jednou sérií, vymaže hodnotu pro Den 3 a uloží diagram ve všech třech režimech. Vstupní soubor není vyžadován. [ChartDataWorkbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/) používá list 0, sloupec 0 pro popisky kategorií a sloupec 1 pro hodnoty; řádek 0 obsahuje název série. Konečná data jsou `10, 20, empty, 30, 40`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 40, 40, 640, 400)
    chart_data = chart.chart_data
    workbook = chart_data.chart_data_workbook

    chart_data.series.clear()
    chart_data.categories.clear()

    series_name_cell = workbook.get_cell(0, 0, 1, "Measurements")
    series = chart_data.series.add(series_name_cell, chart.type)
    values = [10, 20, 25, 30, 40]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Day {i + 1}")
        chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Nechá Day 3 skutečně prázdný, přičemž zachová jeho kategorii a datový bod.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Každý výstupní soubor ukládá režim nastavený před uložením: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` a `empty_cells_Span.pptx`. Pro uložení jen jedné verze nastavte požadovaný režim a prezentaci uložte jednou místo iterace přes režimy.

Níže uvedené srovnání ukazuje stejná data ve všech třech souborech. Den 3 je v sešitu v každém případě prázdný:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Viditelný efekt závisí na typu diagramu. Čárový diagram usnadňuje porovnání všech tří režimů. Pruhové a sloupcové diagramy nemají čáru, která by propojila chybějící kategorii, takže `SPAN` nemůže vytvořit spojující úsek, jak je ukázáno výše; chybějící sloupec a sloupec o výšce nula mohou vypadat podobně. Podobně rozptylový diagram jen s body nemá žádnou spojující čáru. Neočekávejte tři odlišné výsledky pro každý typ diagramu; vždy zkontrolujte výstup pro konkrétní typ, který používáte.

## **Nastavení šířky mezery mezi sériemi**

Šířka mezery je prostor mezi sousedními seskupeními pruhů nebo sloupců, vyjádřený v procentech šířky pruhu nebo sloupce. Stejně jako překrytí patří k nadřazené skupině sérií, nikoli k jedné sérii. Nastavte [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) jednou pro celou skupinu. Větší hodnota vytvoří více prostoru mezi seskupeními; menší hodnota je učiní hustšími.

Následující příklad změní šířku mezery a uloží pouze konečnou prezentaci:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
gap_width_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.gap_width = gap_width_percent

    presentation.save("gap_width_30.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![The gap width](gap_width.png)

## **FAQ**

**Které typy diagramů podporují datové série?**

Všechny typy diagramů reprezentované výčtem [ChartType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/charttype/) používají data diagramu, ale jejich série nemají všechny stejnou strukturu hodnot nebo nastavení. Například kategoriální diagramy používají kategorie a hodnoty, rozptylové diagramy používají hodnoty X a Y a bublinové diagramy přidávají velikosti bublin. Použijte metodu vytvoření datového bodu, která odpovídá typu série. Možnosti jako překrytí a šířka mezery platí jen pro kompatibilní skupiny pruhů nebo sloupců.

**Co je skupina sérií diagramu?**

[ChartSeriesGroup](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseriesgroup/) obsahuje kompatibilní série, které sdílejí nastavení úrovně skupiny. Kombinovaný diagram může obsahovat více než jednu skupinu, takže změna skupiny dosažené přes jednu sérii nemusí nutně změnit všechny série v diagramu.

**Obsahuje nově vytvořený diagram výchozí data?**

Ano. Ve výchozím nastavení metoda [ShapeCollection.add_chart](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_chart/) vytváří ukázkové série, kategorie a hodnoty. Můžete tyto buňky upravit nebo vymazat jak série, tak sbírky kategorií před přidáním zcela vlastního datového souboru. Přetížená metoda může také vytvořit diagram bez výchozích dat.

**Jak jsou objekty diagramu propojeny s buňkami sešitu?**

Názvy sérií, popisky kategorií a hodnoty datových bodů odkazují na buňky v [ChartDataWorkbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající prvek diagramu. Při vytváření vlastních dat udržujte řádky kategorií a řádky hodnot sérií zarovnané tak, aby každý bod byl vykreslen pod zamýšlenou kategorií.

**Jak vymazat jen jeden bod místo celé série?**

Nastavte příslušnou buňku s hodnotou na `None`, aby bod zůstal na své pozici kategorie jako prázdný bod. Použijte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapointcollection/clear/) pouze v případě, že chcete odstranit všechny body z dané série. Pokud také odstraňujete kategorie, aktualizujte všechny série, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou prázdné body zobrazovány?**

Výsledek závisí na typu diagramu a na [Chart.display_blanks_as](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/display_blanks_as/). Podporované diagramy mohou zobrazovat prázdné hodnoty jako mezery, jako nuly nebo spojením sousedních bodů. Zvolte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci. Viz část **Řízení zobrazení prázdných buněk** pro kompletní příklad a vizuální srovnání.

**Jak jsou formátovány záporné hodnoty?**

U podporovaných pruhových, sloupcových a bublinových sérií povolte [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/invert_if_negative/) a nastavte [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Chování můžete přepsat pro jednotlivý bod pomocí [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Tyto vlastnosti ovlivňují formátování, ne uložené číselné hodnoty.

**Které formátování má přednost, když je série i bod formátován?**

Explicitní formátování datového bodu má přednost pro tento bod. Ostatní body pokračují v používání explicitního formátu série nebo, pokud není definován, automatického stylu a motivu diagramu. Skupinové vlastnosti, jako překrytí a šířka mezery, řídí rozvržení a nejsou přepisovány na úrovni bodu.

**Existuje limit počtu sérií, které může diagram obsahovat?**

Aspose.Slides neuvádí samostatný pevný limit počtu sérií. V praxi limit určuje omezení souboru prezentace, dostupná paměť, doba vykreslování a čitelnost diagramu.

**Co změnit, když jsou sloupce příliš blízko nebo příliš daleko od sebe?**

Nastavte [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) na příslušné nadřazené skupině sérií. Zvýšením hodnoty rozšíříte prostor mezi seskupeními, snížením jej přiblížíte.