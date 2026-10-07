---
title: Spravovat řady grafu v prezentacích v Pythonu
linktitle: Datové řady
type: docs
url: /cs/python-net/chart-series/
keywords:
- řada grafu
- překrytí řad
- barva řady
- barva kategorie
- název řady
- datový bod
- mezera mezi řadami
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak spravovat řady grafu, datové body, buňky pracovního sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích pomocí Pythonu."
---
## **Přehled**

Graf ukládá svá vykreslená data do pracovního sešitu grafových dat. [ChartSeries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/) představuje jednu sadu souvisejících hodnot a každá [ChartDataPoint](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/) v řadě odkazuje na jednu nebo více buněk sešitu. Objekt [ChartCategory](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/) poskytuje popisky nebo hodnoty seskupení sdílené řadami. Název řady, kategorie a hodnoty bodů jsou tedy napojeny na objekty [ChartDataCell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/), nikoli uloženy pouze jako zobrazovaný text.

Pro typický kategoriální graf výchozí sešit používá řádek 0 pro názvy řad, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty řad. Indexy listu, řádku a sloupce předávané metodě [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) jsou nulové. Toto uspořádání je užitečné při vytváření grafu s výchozími daty, ale nepředpokládejte, že každé existující graf takto funguje. U načtené prezentace si před změnou hodnot v sešitu prohlédněte buňky, na které odkazují řady, kategorie a datové body.

Nastavení grafu mají tři různé úrovně:

- Nastavení na úrovni řady, například [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/), poskytuje výchozí vzhled pro všechny body v jedné řadě.
- Nastavení datového bodu, například [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/), přepíše vzhled řady pro konkrétní bod.
- Skupinová nastavení se vztahují na kompatibilní řady patřící do stejné [ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/). Přístup ke skupině získáte pomocí [ChartSeries.parent_series_group](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/parent_series_group/), když potřebujete nastavit například překrytí nebo šířku mezery.

Když není explicitně nastaveno vyplnění bodu ani řady, určuje automatický vzhled styl a motiv grafu. Když jsou přítomny jak formátování řady, tak bodu, formátování bodu má přednost pro daný bod.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí řady grafu**

[ChartSeries.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/overlap/) udává, jak moc se překrývají pruhy nebo sloupce ve 2D grafu, v rozmezí -100 až 100 procent. Jedná se o jen‑čtení projekci nastavení v nadřazené skupině řad. Nastavte [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) pro aktualizaci všech kompatibilních řad v dané skupině. Tato možnost se vztahuje k typům grafů, které zobrazují seskupené pruhy nebo sloupce; neovlivní nesouvisející skupiny řad v kombinovaném grafu.

Následující příklad nastaví překrytí pro skupinu, která obsahuje první řadu:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Nový graf obsahuje ukázkové řady, kategorie a hodnoty.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![The series overlap](series_overlap.png)

## **Změna barvy vyplnění řady**

Použijte [ChartSeries.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/format/) k nastavení výchozího vyplnění celé řady. Pokud má bod již explicitní vyplnění, jeho nastavení [ChartDataPoint.format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/format/) přepíše vyplnění řady pro tento bod.

Následující příklad použije jednotné modré vyplnění na první řadu:

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

## **Změna názvu řady**

Název řady je uložen v pracovním sešitu grafu a obvykle se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro sloupcový graf s seskupením je buňka B1 v řádku 0, sloupci 1 a obsahuje název první řady. Pojmenované konstanty v následujícím příkladu tuto strukturu explicitně uvádějí:

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

Můžete také aktualizovat buňku, na kterou již odkazuje [ChartSeries.name](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/name/). Tento přístup se vyhýbá předpokladu konkrétního řádku a sloupce v existujícím grafu:

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

### **Vytvoření řady s názvem ze více buněk**

Kompozitní název řady se hodí, když jsou název produktu a období zprávy uloženy v oddělených buňkách sešitu. Například můžete sloučit `Product A` v B1 a `2026` v C1 do jednoho názvu řady a zároveň ponechat oba díly propojené se svými zdrojovými buňkami.

Použijte [ChartDataWorkbook.get_cell_collection](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/get_cell_collection/) k načtení rozsahu názvu, poté tuto kolekci předávejte metodě [ChartSeriesCollection.add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriescollection/add/). Argument `skip_hidden_cells` určuje, zda se zahrnou skryté buňky: `True` je vyloučí, `False` zahrne. V tomto příkladu je použito `False`, aby se zahrnuly všechny buňky v rozsahu názvu.

Následující příklad vytvoří prezentaci s jednou řadou a dvěma datovými body. Buňky B1:C1 dodávají jen název řady; A2:A3 poskytují popisky kategorií a B2:B3 číselné hodnoty.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 620, 180)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    chart.has_legend = True

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    # Tyto dvě buňky poskytují název řady.
    workbook.get_cell(0, 0, 1, "Product A")
    workbook.get_cell(0, 0, 2, "2026")
    name_cells = workbook.get_cell_collection("Sheet1!$B$1:$C$1", False)
    series = chart.chart_data.series.add(name_cells, charts.ChartType.CLUSTERED_COLUMN)

    # Samostatné buňky poskytují kategorie a číselné datové body.
    north_category = workbook.get_cell(0, 1, 0, "North")
    south_category = workbook.get_cell(0, 2, 0, "South")
    chart.chart_data.categories.add(north_category)
    chart.chart_data.categories.add(south_category)
    north_value = workbook.get_cell(0, 1, 1, 120)
    south_value = workbook.get_cell(0, 2, 1, 150)
    series.data_points.add_data_point_for_bar_series(north_value)
    series.data_points.add_data_point_for_bar_series(south_value)

    presentation.save("composite_series_name.pptx", slides.export.SaveFormat.PPTX)
```

Výsledný název řady je `Product A 2026`, s mezerou mezi hodnotami dvou buněk. Legenda jej zobrazuje jako jediný záznam pro oba sloupce. Obrázek níže byl vygenerován ze uložené prezentace:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Získání automatické barvy vyplnění řady**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) vrací barvu vypočítanou z indexu řady a stylu grafu. Jedná se o barvu použitou, když vyplnění řady není explicitně definováno. Volání metody pouze načte vypočítanou barvu; nenastavuje nové vyplnění.

Následující příklad vypíše automatickou barvu každé výchozí řady:

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

Ukázkový výstup pro výchozí styl grafu:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Přesné barvy závisí na stylu a motivu grafu.

## **Nastavení inverzní barvy vyplnění pro řadu grafu**

U pruhových, sloupcových a bublinových řad může [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) zobrazit záporné hodnoty jiným vyplněním. Nastavte běžné vyplnění řady na jednotné, povolte inverzi a přiřaďte barvu záporných hodnot pomocí [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Záporná čísla zůstávají v sešitu beze změny; mění se jen jejich barva při zobrazení.

Následující příklad nahradí výchozí data grafu jednou řadou. Řádek 0 listu obsahuje název řady, sloupec 0 názvy kategorií a sloupec 1 hodnoty:

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

Inverzi můžete povolit jen pro jeden bod pomocí [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). V následujícím příkladu je inverze vypnuta pro řadu a povolena jen pro vybraný bod. Bod má také přiřazenou zápornou hodnotu, aby byl efekt viditelný:

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

Chcete‑li učinit jeden bod prázdným, aniž byste odstraňovali ostatní body, nastavte buňku v pozadí na `None`. U sloupcového grafu je vykreslená hodnota dostupná přes [ChartDataPoint.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/value/). Datový bod zůstane na stejné pozici kategorie, ale graf jej bude považovat za prázdný dle nastavení prázdných hodnot grafu.

Následující příklad vymaže jen druhý bod v první řadě:

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

Grafy rozptylu používají oddělené buňky X a Y a bublinové grafy také buňku velikosti. Vymažte jen buňku, která představuje hodnotu, kterou chcete odstranit. Nepoužívejte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/), pokud chcete zachovat ostatní body, protože tato metoda odstraní všechny datové body ze sbírky.

## **Řízení zobrazení prázdných buněk**

Skryté buňky obsahující hodnoty jsou odlišný případ od prázdných buněk. Pro zahrnutí nebo vyloučení dat ze skrytých řádků a sloupců listu viz [Include Data from Hidden Rows and Columns](/slides/cs/python-net/chart-workbook/#include-data-from-hidden-rows-and-columns).

Prázdná buňka pracovního sešitu představuje chybějící data; buňka obsahující `0` představuje známou číselnou hodnotu. Nastavte [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) na `None`, aby buňka byla prázdná. Číselná nula zůstává nulou bez ohledu na nastavení prázdných buněk.

Použijte [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) pro výběr, jak graf zobrazuje prázdné buňky. Toto nastavení se vztahuje na celý graf. Mění způsob, jak jsou mezery vykresleny, aniž by se prázdná buňka vyplňovala nulou nebo interpolovanou hodnotou.

Následující samostatný příklad vytvoří čárový graf s jednou řadou, vymaže hodnotu pro den 3 a uloží tři verze grafu, každou s jiným režimem. Nevstupní soubor není vyžadován. [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/) používá list 0, sloupec 0 pro popisky kategorií a sloupec 1 pro hodnoty; řádek 0 obsahuje název řady. Konečná data jsou `10, 20, empty, 30, 40`.

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

    # Nechte den 3 skutečně prázdný, přičemž zachovejte jeho kategorii a datový bod.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Každý výstupní soubor ukládá režim přiřazený před uložením: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` a `empty_cells_Span.pptx`. Pro uložení pouze jedné verze nastavte požadovaný režim a prezentaci uložte jednou místo iterace přes režimy.

Porovnání níže ukazuje stejná data ve všech třech souborech. Den 3 je ve všech případech v sešitu prázdný:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Viditelný efekt závisí na typu grafu. Čárový graf umožňuje snadno porovnat všechny tři režimy. Pruhové a sloupcové grafy nemají čáru, kterou by se dalo spojit přes chybějící kategorii, takže `SPAN` nedokáže vytvořit spojovací úsek, který je na výše uvedeném obrázku; chybějící sloupec a sloupec s nulovou výškou mohou vypadat podobně. Podobně scatter graf s jen značkami nemá spojovací čáru. Neočekávejte tři odlišné výsledky u každého typu grafu; ověřte výstup pro konkrétní typ, který používáte.

## **Nastavení šířky mezery mezi řadami**

Šířka mezery je prostor mezi sousedními seskupeními pruhů nebo sloupců, vyjádřený v procentech šířky pruhu nebo sloupce. Podobně jako překrytí patří k nadřazené skupině řad, nikoli k jedné řadě. Nastavte [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) jednou pro skupinu. Větší hodnota vytvoří větší prostor mezi seskupeními; menší hodnota je učiní hustšími.

Následující příklad změní šířku mezery a uloží pouze finální prezentaci:

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

## **Často kladené otázky**

**Které typy grafů podporují datové řady?**

Všechny typy grafů reprezentované výčtem [ChartType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) používají grafová data, ale jejich řady nemají vždy stejnou strukturu hodnot nebo nastavení. Například kategoriální grafy používají kategorie a hodnoty, scatter grafy používají X a Y hodnoty a bublinové grafy přidávají velikosti bublin. Použijte metodu tvorby datových bodů, která odpovídá typu řady. Možnosti jako překrytí a šířka mezery se vztahují jen na kompatibilní pruhové nebo sloupcové skupiny.

**Co je skupina řad grafu?**

[ChartSeriesGroup](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/) obsahuje kompatibilní řady, které sdílejí nastavení plotování na úrovni skupiny. Kombinovaný graf může obsahovat více než jednu skupinu, takže změna skupiny dosažená přes jednu řadu nemusí nutně změnit všechny řady v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení metoda [ShapeCollection.add_chart](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_chart/) vytvoří ukázkové řady, kategorie a hodnoty. Můžete tyto buňky upravit nebo vymazat jak řady, tak i kolekce kategorií před tím, než přidáte zcela vlastní datovou sadu. Přetížená verze může také vytvořit graf bez výchozích dat.

**Jak jsou grafové objekty napojeny na buňky pracovního sešitu?**

Názvy řad, popisky kategorií a hodnoty datových bodů odkazují na buňky v [ChartDataWorkbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající prvek grafu. Při tvorbě vlastních dat udržujte řádky kategorií a řádky hodnot řad zarovnané, aby každý bod byl vykreslen pod požadovanou kategorií.

**Jak vymazat jeden bod místo celé řady?**

Nastavte příslušnou buňku hodnoty na `None`, aby bod zachoval svou pozici kategorie jako prázdný bod. Používejte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapointcollection/clear/) pouze tehdy, když chcete odstranit všechny body z dané řady. Pokud také odstraňujete kategorie, aktualizujte všechny řady, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou prázdné body zobrazeny?**

Výsledek závisí na typu grafu a na [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/). Podporované grafy mohou zobrazovat mezery jako prázdná místa, jako nulové hodnoty nebo spojením sousedních bodů. Vyberte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci. Viz sekce [Control the Display of Empty Cells](#control-the-display-of-empty-cells) pro úplný příklad a vizuální srovnání.

**Jak jsou formátovány záporné hodnoty?**

U podporovaných pruhových, sloupcových a bublinových řad povolte [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/invert_if_negative/) a nastavte [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Chování můžete přepsat pro jednotlivý bod pomocí [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Tyto vlastnosti ovlivňují formátování, ne uložené číselné hodnoty.

**Které formátování má přednost, pokud jsou formátovány jak řada, tak bod?**

Explicitní formátování datového bodu má přednost pro daný bod. Ostatní body nadále používají explicitní formát řady nebo, pokud není definován, automatický styl a motiv grafu. Vlastnosti skupiny jako překrytí a šířka mezery řídí rozvržení a nejsou formátovacími přepsáními na úrovni bodu.

**Existuje limit počtu řad, které může graf obsahovat?**

Aspose.Slides neukládá pevný omezený limit počtu řad. V praxi určují omezení velikosti souboru prezentace, dostupná paměť, doba renderování a čitelnost grafu praktické limity.

**Co změnit, když jsou sloupce příliš blízko sebe nebo příliš daleko?**

Nastavte [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) na příslušné nadřazené skupině řad. Zvyšte hodnotu pro rozšíření prostoru mezi seskupeními nebo ji snižte, aby se seskupení přiblížila.