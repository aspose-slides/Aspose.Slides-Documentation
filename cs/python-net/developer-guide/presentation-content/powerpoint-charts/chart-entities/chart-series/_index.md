---
title: Správa řad dat grafu v prezentacích v Pythonu
linktitle: Datové řady
type: docs
url: /cs/python-net/chart-series/
keywords:
- řada grafu
- překrytí řady
- barva řady
- barva kategorie
- název řady
- datový bod
- mezera řady
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Zjistěte, jak spravovat řady grafu, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích pomocí Pythonu."
---
## **Přehled**

Graf ukládá svá vykreslená data do sešitu s daty grafu. [ChartSeries](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/) představuje jeden soubor souvisejících hodnot a každý [ChartDataPoint](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapoint/) v řadě odkazuje na jednu nebo více buněk sešitu. Objekt [ChartCategory](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartcategory/) poskytuje štítky nebo skupinové hodnoty sdílené řadami. Název řady, kategorie a hodnoty bodů jsou tedy propojeny s objekty [ChartDataCell](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatacell/), nikoli uloženy pouze jako zobrazovaný text.

Pro typický kategoriový graf výchozí sešit používá řádek 0 pro názvy řad, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty řad. Indexy listu, řádku a sloupce předávané metodě [ChartDataWorkbook.get_cell](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/get_cell/) jsou nulové. Toto uspořádání je užitečné, když vytváříte graf s výchozími daty, ale nepředpokládejte, že každý existující graf jej používá. U načtené prezentace nejprve prozkoumejte buňky, na které odkazují řady, kategorie a datové body, před změnou hodnot v sešitu.

Nastavení grafu mají tři různé úrovně:

- Nastavení na úrovni řady, například [ChartSeries.format](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/format/), poskytují výchozí vzhled pro všechny body v jedné řadě.
- Nastavení datového bodu, například [ChartDataPoint.format](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapoint/format/), přepisuje vzhled řady pro jeden bod.
- Nastavení skupiny se vztahují na kompatibilní řady, které patří do stejné [ChartSeriesGroup](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseriesgroup/). Přístup ke skupině získáte přes [ChartSeries.parent_series_group](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/parent_series_group/), když potřebujete nastavit možnosti jako překrytí nebo šířku mezery.

Když není nastaven žádný explicitní výplňový styl bodu nebo řady, určuje automatický vzhled styl grafu a motiv. Když jsou přítomny jak formátování řady, tak bodu, má přednost formátování bodu pro daný bod.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavit překrytí řady grafu**

[ChartSeries.overlap](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/overlap/) udává, jak moc se překrývají sloupce nebo pruhy v 2D grafu, v rozmezí od –100 do 100 procent. Jedná se o jen ke čtení projekci nastavení v nadřazené skupině řad. Nastavte [ChartSeriesGroup.overlap](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseriesgroup/overlap/) pro aktualizaci všech kompatibilních řad v této skupině. Tato možnost se vztahuje na typy grafů, které zobrazují seskupené sloupce nebo pruhy; neovlivňuje nesouvisející skupiny řad v kombinovaném grafu.

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

![Překrytí řad](series_overlap.png)

## **Změnit barvu výplně řady**

Použijte [ChartSeries.format](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/format/) k nastavení výchozí výplně celé řady. Pokud má bod již explicitní výplň, jeho nastavení [ChartDataPoint.format](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapoint/format/) přepíše výplň řady pro tento bod.

Následující příklad použije plnou modrou výplň na první řadu:

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

![Barva řady](series_color.png)

## **Změnit název řady**

Název řady je uložen v sešitu s daty grafu a obvykle se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro seskupený sloupcový graf je buňka B1 na řádku 0, sloupci 1 a obsahuje název první řady. Pojmenované konstanty v následujícím příkladu tuto strukturu explicitně uvádějí:

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

Můžete také aktualizovat buňku, na kterou již odkazuje [ChartSeries.name](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/name/). Tento přístup zabraňuje předpokladu konkrétního řádku a sloupce v existujícím grafu:

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

![Název řady](series_name.png)

## **Získat automatickou barvu výplně řady**

[ChartSeries.get_automatic_series_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/get_automatic_series_color/) vrací barvu vypočítanou z indexu řady a stylu grafu. Jedná se o barvu použitou, když výplň řady není explicitně definována. Volání metody pouze načte vypočtenou barvu; nepřiděluje novou výplň.

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

## **Nastavit invertovanou barvu výplně pro řadu grafu**

Pro řady typu pruh, sloupec a bublina může [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/invert_if_negative/) zobrazit záporné hodnoty jinou výplní. Nastavte běžnou výplň řady na plnou, povolte inverzi a přiřaďte barvu záporných hodnot pomocí [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Záporná čísla zůstávají v sešitu nezměněna; mění se pouze jejich zobrazovaná barva.

Následující příklad nahradí výchozí data grafu jednou řadou. Řádek 0 listu obsahuje název řady, sloupec 0 obsahuje názvy kategorií a sloupec 1 hodnoty:

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

![Invertovaná plná výplň](inverted_solid_fill_color.png)

Inverzi lze povolit i pro jeden bod pomocí [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). V následujícím příkladu je inverze vypnuta pro řadu a povolena pouze pro vybraný bod. Bod je také přiřazen zápornou hodnotou, aby byl efekt viditelný:

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

## **Vymazat konkrétní hodnotu datového bodu**

Aby byl jeden bod prázdný, aniž by se odstranily ostatní body, nastavte jeho podkladovou buňku sešitu na `None`. Pro sloupcový graf je vykreslená hodnota dostupná přes [ChartDataPoint.value](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapoint/value/). Datový bod zůstává na stejné pozici kategorie, ale graf jeho hodnotu považuje za prázdnou podle nastavení zobrazení prázdných hodnot grafu.

Následující příklad vymaže pouze druhý bod v první řadě:

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

Grafy rozptýlení používají samostatné buňky X a Y a bublinové grafy také buňku velikosti. Vymažte pouze buňku, která představuje hodnotu, kterou chcete odstranit. Nevolajte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapointcollection/clear/), pokud chcete zachovat ostatní body, protože tato metoda odstraní každý datový bod ze sbírky.

## **Nastavit šířku mezery řady**

Šířka mezery je prostor mezi sousedními klastery pruhů nebo sloupců, vyjádřený v procentech šířky pruhu nebo sloupce. Stejně jako překrytí patří k nadřazené skupině řad, nikoli k jedné řadě. Nastavte [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) jednou pro skupinu. Větší hodnota vytvoří více prostoru mezi klastery; menší hodnota je učiní hustšími.

Následující příklad změní šířku mezery a uloží jen finální prezentaci:

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

![Šířka mezery](gap_width.png)

## **Často kladené otázky**

**Které typy grafů podporují datové řady?**

Všechny typy grafů reprezentované výčtem [ChartType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/charttype/) používají datový sešit, ale jejich řady nemají stejnou strukturu hodnot ani nastavení. Například kategoriové grafy používají kategorie a hodnoty, rozptylové grafy používají hodnoty X a Y a bublinové grafy přidávají velikosti bublin. Použijte metodu pro vytvoření datového bodu, která odpovídá typu řady. Možnosti jako překrytí a šířka mezery se vztahují pouze na kompatibilní skupiny pruhů nebo sloupců.

**Co je skupina řad grafu?**

[ChartSeriesGroup](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseriesgroup/) obsahuje kompatibilní řady, které sdílejí nastavení úrovně skupiny. Kombinovaný graf může obsahovat více než jednu skupinu, takže změna skupiny přes jednu řadu nemusí nutně změnit všechny řady v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení metoda [ShapeCollection.add_chart](https://reference.aspose.com/slides/cs/python-net/aspose.slides/shapecollection/add_chart/) vytvoří ukázkové řady, kategorie a hodnoty. Můžete tyto buňky upravit nebo vymazat kolekce řad a kategorií před přidáním zcela vlastního datového souboru. Přetížená verze může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu propojeny s buňkami sešitu?**

Názvy řad, štítky kategorií a hodnoty datových bodů odkazují na buňky v [ChartDataWorkbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající prvek grafu. Při vytváření vlastních dat udržujte řádky kategorií a řádky hodnot řad zarovnané, aby každý bod byl vykreslen pod zamýšlenou kategorií.

**Jak vymazat jeden bod místo celé řady?**

Nastavte příslušnou buňku hodnoty na `None`, abyste zachovali pozici kategorie bodu jako prázdný bod. Použijte [ChartDataPointCollection.clear](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapointcollection/clear/) pouze tehdy, když chcete odstranit všechny body z dané řady. Pokud zároveň odstraňujete kategorie, aktualizujte každou řadu, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou prázdné body zobrazeny?**

Výsledek závisí na typu grafu a na [Chart.display_blanks_as](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/display_blanks_as/). Podporované grafy mohou prázdná místa zobrazovat jako mezery, jako nuly nebo spojením sousedních bodů. Vyberte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci.

**Jak jsou formátovány záporné hodnoty?**

U podporovaných řad typu pruh, sloupec a bublina povolte [ChartSeries.invert_if_negative](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/invert_if_negative/) a nastavte [ChartSeries.inverted_solid_fill_color](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseries/inverted_solid_fill_color/). Chování můžete přepsat pro jednotlivý bod pomocí [ChartDataPoint.invert_if_negative](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatapoint/invert_if_negative/). Tyto vlastnosti ovlivňují pouze formátování, ne uložené číselné hodnoty.

**Které formátování má přednost, když je formátována jak řada, tak bod?**

Explicitní formátování datového bodu má přednost pro tento bod. Ostatní body nadále používají explicitní formát řady nebo, pokud formát řady není definován, automatický styl a motiv grafu. Vlastnosti skupiny, jako jsou překrytí a šířka mezery, řídí rozvržení a nejsou přepisovány na úrovni bodu.

**Existuje limit počtu řad, které může graf obsahovat?**

Aspose.Slides neklade samostatný pevný limit počtu řad. V praxi určují omezení souboru prezentace, dostupná paměť, doba renderování a čitelnost grafu praktické limity.

**Co změnit, když jsou sloupce příliš blízko u sebe nebo příliš daleko?**

Nastavte [ChartSeriesGroup.gap_width](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartseriesgroup/gap_width/) na příslušné nadřazené skupině řad. Zvýšením hodnoty rozšíříte prostor mezi klastery, snížením jej přiblížíte.