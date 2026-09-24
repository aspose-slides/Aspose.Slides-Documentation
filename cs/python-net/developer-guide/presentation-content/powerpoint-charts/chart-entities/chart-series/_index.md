---
title: Správa sérií dat diagramu v prezentacích v Pythonu
linktitle: Datové série
type: docs
url: /cs/python-net/chart-series/
keywords:
- série diagramu
- překrytí série
- barva série
- barva kategorie
- název série
- datový bod
- mezera mezi sériemi
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak spravovat série diagramu, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích pomocí Pythonu."
---
## **Přehled**

Diagram ukládá svá vykreslená data do sešitu s daty diagramu. Objekt **ChartSeries** představuje jednu sadu souvisejících hodnot a každý **ChartDataPoint** v sérii odkazuje na jednu nebo více buněk sešitu. Objekt **ChartCategory** poskytuje popisky nebo hodnoty seskupení sdílené sérií. Název série, kategorie a hodnoty bodů jsou tedy propojeny s objekty **ChartDataCell**, místo aby byly uloženy jen jako zobrazovaný text.

Pro typický kategoriový diagram výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty sérií. Indexy listu, řádku a sloupce předávané metodě **ChartDataWorkbook.get_cell** jsou založeny na nule. Toto rozložení je užitečné při vytváření diagramu s výchozími daty, ale ne předpokládejte, že každý existující diagram jej používá. U načtené prezentace prohlédněte buňky, na které odkazují série, kategorie a datové body, než změníte hodnoty v sešitu.

Nastavení diagramu mají tři různé úrovně:

- Nastavení na úrovni série, například **ChartSeries.format**, poskytuje výchozí vzhled pro všechny body v jedné sérii.
- Nastavení na úrovni datového bodu, například **ChartDataPoint.format**, přepíše vzhled série pro jeden bod.
- Skupinová nastavení se vztahují na kompatibilní série, které patří do stejné **ChartSeriesGroup**. Přístup ke skupině získáte přes **ChartSeries.parent_series_group**, když potřebujete nastavit možnosti jako překrytí nebo šířka mezery.

Když není nastaven explicitní výplň pro bod ani sérii, určuje automatický vzhled styl a motiv diagramu. Když jsou přítomny formátování série i bodu, formátování bodu má přednost pro daný bod.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí sérií diagramu**

**ChartSeries.overlap** udává, jak moc se překrývají pruhy nebo sloupce v 2D diagramu, v rozmezí –100 až 100 procent. Jedná se o jen‑read‑only projekci nastavení ve skupině rodičovské série. Nastavte **ChartSeriesGroup.overlap** pro aktualizaci všech kompatibilních sérií v této skupině. Tato možnost se vztahuje na typy diagramů, které zobrazují seskupené pruhy nebo sloupce; neovlivní nesouvisející skupiny sérií v kombinovaném diagramu.

Níže uvedený příklad nastavuje překrytí pro skupinu, která obsahuje první sérii:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

first_slide_index = 0
first_series_index = 0
overlap_percent = 30

with slides.Presentation() as presentation:
    slide = presentation.slides[first_slide_index]

    # Nový diagram obsahuje vzorové série, kategorie a hodnoty.
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 200)

    series = chart.chart_data.series[first_series_index]
    series.parent_series_group.overlap = overlap_percent

    presentation.save("series_overlap.pptx", slides.export.SaveFormat.PPTX)
```

Výsledek:

![The series overlap](series_overlap.png)

## **Změna barvy výplně série**

Použijte **ChartSeries.format** k nastavení výchozí výplně celé série. Pokud má bod již explicitní výplň, jeho nastavení **ChartDataPoint.format** přepíše výplň série pro tento bod.

Níže uvedený příklad aplikuje plnou modrou výplň na první sérii:

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

Název série je uložen v sešitu s daty diagramu a obvykle se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro seskupený sloupcový diagram je buňka **B1** na řádku 0, sloupci 1 a obsahuje název první série. V následujícím příkladu pojmenované konstanty explicitně vyjadřují tuto strukturu:

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

Můžete také aktualizovat buňku, na kterou již odkazuje **ChartSeries.name**. Tento postup se vyhýbá předpokladu konkrétního řádku a sloupce v existujícím diagramu:

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

**ChartSeries.get_automatic_series_color** vrací barvu vypočtenou z indexu série a stylu diagramu. Jedná se o barvu použitou, když výplň série není explicitně definována. Volání metody pouze načte vypočtenou barvu; nenastavuje novou výplň.

Níže uvedený příklad vypisuje automatickou barvu každé výchozí série:

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

Příklad výstupu pro výchozí styl diagramu:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Přesné barvy závisí na stylu a motivu diagramu.

## **Nastavení obrácené výplně pro sérii diagramu**

U sérií pruhů, sloupců a bublin může **ChartSeries.invert_if_negative** zobrazit záporné hodnoty jinou výplní. Nastavte běžnou výplň série na plnou, povolte inverzi a přiřaďte barvu záporných hodnot pomocí **ChartSeries.inverted_solid_fill_color**. Záporná čísla zůstávají v sešitu nezměněna; mění se jen jejich zobrazovaná barva.

Níže uvedený příklad nahrazuje výchozí data diagramu jednou sérií. Řádek 0 listu obsahuje název série, sloupec 0 názvy kategorií a sloupec 1 hodnoty:

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

Inverzi můžete povolit pro jeden bod pomocí **ChartDataPoint.invert_if_negative**. V následujícím příkladu je inverze zakázána pro sérii a povolena jen pro vybraný bod. Bodu je také přiřazena záporná hodnota, aby byl efekt viditelný:

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

Aby se jeden bod vyprázdnil bez odstranění ostatních bodů, nastavte jeho backingovou buňku v sešitu na `None`. U sloupcového diagramu je vykreslená hodnota dostupná přes **ChartDataPoint.value**. Datový bod zůstane na stejném místě kategorie, ale diagram bude jeho hodnotu považovat za prázdnou podle nastavení prázdných hodnot diagramu.

Níže uvedený příklad vymaže jen druhý bod v první sérii:

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

Bodové diagramy používají samostatné buňky X a Y, a bublinové diagramy také buňku velikosti. Vymažte jen buňku, která představuje hodnotu, kterou chcete odstranit. Nevolajte **ChartDataPointCollection.clear**, pokud chcete zachovat ostatní body, protože tato metoda odstraní všechny datové body ze sbírky.

## **Řízení zobrazení prázdných buněk**

Prázdná buňka sešitu představuje chybějící data; buňka obsahující `0` představuje známou číselnou hodnotu. Nastavte **ChartDataCell.value** na `None`, aby byla buňka prázdná. Číselná nula zůstane nulou bez ohledu na nastavení prázdné buňky.

Pomocí **Chart.display_blanks_as** vyberte, jak má diagram zobrazovat prázdné buňky. Toto nastavení platí pro celý diagram. Mění způsob, jakým jsou prázdné body vykreslovány, aniž by se prázdná buňka naplnila nulou nebo interpolovanou hodnotou.

Níže uvedený samostatný příklad vytvoří čárový diagram s jednou sérií, vymaže hodnotu pro den 3 a uloží stejný diagram ve všech režimech. Vstupní soubor není nutný. **ChartDataWorkbook** používá list 0, sloupec 0 pro popisky kategorií a sloupec 1 pro hodnoty; řádek 0 obsahuje název série. Výsledná data jsou `10, 20, empty, 30, 40`.

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

    # Nechte den 3 skutečně prázdný, přičemž zachováte jeho kategorii a datový bod.
    workbook.get_cell(0, 3, 1).value = None

    modes = [("Gap", charts.DisplayBlanksAsType.GAP), ("Zero", charts.DisplayBlanksAsType.ZERO), ("Span", charts.DisplayBlanksAsType.SPAN)]
    for mode_name, mode in modes:
        chart.display_blanks_as = mode
        presentation.save(f"empty_cells_{mode_name}.pptx", slides.export.SaveFormat.PPTX)
```

Každý výstupní soubor ukládá režim přiřazený před uložením: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` a `empty_cells_Span.pptx`. Pro uložení jen jedné verze přiřaďte požadovaný režim a uložte prezentaci jednou místo iterace přes režimy.

Níže uvedené srovnání ukazuje stejná data ve všech třech souborech. Den 3 je v sešitu prázdný v každém případě:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

Viditelný efekt závisí na typu diagramu. Čárový diagram usnadňuje porovnání všech tří režimů. Diagramy pruhů a sloupců nemají čáru, kterou by spojila chybějící kategorii, takže `SPAN` nemůže vytvořit ukázaný spojovací úsek; chybějící sloupec a sloupec nulové výšky mohou také vypadat podobně. Podobně u bodového diagramu pouze s markery není žádná spojovací čára. Neočekávejte tři odlišné výsledky pro každý typ diagramu; zkontrolujte výstup pro typ, který používáte.

## **Nastavení šířky mezery mezi sériemi**

Šířka mezery je prostor mezi sousedními shluky pruhů nebo sloupců, vyjádřený v procentech šířky pruhu nebo sloupce. Stejně jako překrytí patří k rodičovské skupině sérií, nikoli k jedné sérii. Nastavte **ChartSeriesGroup.gap_width** jednou pro skupinu. Větší hodnota vytvoří více prostoru mezi shluky; menší hodnota je učiní hustšími.

Níže uvedený příklad mění šířku mezery a ukládá pouze finální prezentaci:

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

**Které typy diagramů podporují datové série?**

Všechny typy diagramů reprezentované výčtem **ChartType** používají datový sešit, ale jejich série nemají vždy stejnou strukturu hodnot nebo nastavení. Například kategoriové diagramy používají kategorie a hodnoty, bodové diagramy používají hodnoty X a Y a bublinové diagramy přidávají velikosti bublin. Použijte metodu pro vytváření datových bodů, která odpovídá typu série. Možnosti jako překrytí a šířka mezery se vztahují jen na kompatibilní skupiny pruhů nebo sloupců.

**Co je skupina sérií diagramu?**

**ChartSeriesGroup** obsahuje kompatibilní série, které sdílejí nastavení na úrovni skupiny. Kombinovaný diagram může obsahovat více než jednu skupinu, takže změna skupiny získaná přes jednu sérii nemusí nutně změnit všechny série v diagramu.

**Obsahuje nově vytvořený diagram výchozí data?**

Ano. Ve výchozím nastavení **ShapeCollection.add_chart** vytváří vzorové série, kategorie a hodnoty. Můžete tyto buňky upravit nebo vymazat jak série, tak kolekce kategorií před přidáním zcela vlastního datového souboru. Přetížená metoda může také vytvořit diagram bez výchozích dat.

**Jak jsou objekty diagramu propojeny s buňkami sešitu?**

Názvy sérií, popisky kategorií a hodnoty datových bodů odkazují na buňky v **ChartDataWorkbook**. Změna referencované buňky aktualizuje odpovídající prvek diagramu. Při vytváření vlastních dat udržujte řádky kategorií a řádky hodnot sérií zarovnané tak, aby každý bod byl vykreslen pod zamýšlenou kategorií.

**Jak vymazat jeden bod místo celé série?**

Nastavte příslušnou hodnotovou buňku na `None`, aby bod zůstal na své pozici kategorie jako prázdný bod. Používejte **ChartDataPointCollection.clear** pouze tehdy, když chcete odstranit všechny body ze série. Pokud také odstraňujete kategorie, aktualizujte všechny série tak, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou prázdné body zobrazovány?**

Výsledek závisí na typu diagramu a na **Chart.display_blanks_as**. Podporované diagramy mohou prázdné body zobrazovat jako mezery, jako nuly nebo spojením sousedních bodů. Vyberte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci. Viz **Řízení zobrazení prázdných buněk** pro kompletní příklad a vizuální srovnání.

**Jak jsou formátovány záporné hodnoty?**

U podporovaných sérií pruhů, sloupců a bublin povolte **ChartSeries.invert_if_negative** a nastavte **ChartSeries.inverted_solid_fill_color**. Chování můžete přepsat pro jednotlivý bod pomocí **ChartDataPoint.invert_if_negative**. Tyto vlastnosti ovlivňují formátování, nikoli uložené číselné hodnoty.

**Které formátování má přednost, když jsou formátovány jak série, tak bod?**

Explicitní formátování datového bodu má přednost pro ten bod. Ostatní body pokračují v používání explicitního formátu série nebo, když není definován, automatického stylu a motivu diagramu. Skupinové vlastnosti, jako překrytí a šířka mezery, řídí rozložení a nejsou přepisovány na úrovni bodu.

**Existuje limit počtu sérií, které může diagram obsahovat?**

Aspose.Slides neukládá samostatný pevný limit počtu sérií. V praxi určují omezení souboru prezentace, dostupná paměť, doba vykreslování a čitelnost diagramu praktický limit.

**Co změnit, když jsou sloupce příliš blízko nebo příliš daleko od sebe?**

Nastavte **ChartSeriesGroup.gap_width** na příslušné rodičovské skupině sérií. Zvýšte hodnotu pro zvětšení prostoru mezi shluky nebo ji snižte pro jejich přiblížení.