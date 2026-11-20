---
title: Přizpůsobení os grafu v prezentacích s Pythonem
linktitle: Osa grafu
type: docs
url: /cs/python-net/chart-axis/
keywords:
- osa grafu
- svislá osa
- vodorovná osa
- přizpůsobit osu
- manipulovat osou
- spravovat osu
- vlastnosti osy
- maximální hodnota
- minimální hodnota
- čára osy
- formát data
- název osy
- pozice osy
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Objevte, jak pomocí Aspose.Slides pro Python via .NET přizpůsobit osy grafu v prezentacích PowerPoint a OpenDocument pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu pomocí Aspose.Slides pro Python via .NET. Pokrývá vypočítané hodnoty os, přepínání řádků a sloupců grafu, viditelnost os, intervaly popisků kategorií a značek os, datumové kategorie a formátování, otáčení názvu, umístění os, zobrazovací jednotky a logaritmické škálování.

## **Získání maximálních hodnot na svislé ose v grafech**

Vytvořte [Prezentaci](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) a přidejte plošný graf s výchozími daty. Zavolejte [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) před čtením vypočítaných hodnot os, aby byl rozvržení grafu aktuální.

Přečtěte [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) a [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) pro limity osy a [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) a [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) pro intervaly značek. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) a [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) poskytují měřítka časových jednotek, která jsou relevantní pro datumové osy. Příklad ukládá tyto hodnoty do lokálních proměnných a ukládá graf.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Výměna dat mezi osami**

Použijte [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) k výměně rolí řad a kategorií v datech grafu. Každá bývalá kategorie se stane řadou a každá bývalá řada se stane kategorií. Tím se změní způsob seskupení dat; neproběhne výměna vodorovné a svislé osy. Příklad používá [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) k navázání výchozích dat na `Sheet1!A1:D5`, včetně řádku záhlaví a sloupce kategorií, před výměnou řádků a sloupců. Uloží graf se čtyřmi řadami a třemi kategoriemi.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Obrácení pořadí vykreslování osy**

Použijte [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) k obrácení osy kategorií nebo hodnot. Například vodorovný sloupcový graf může zobrazovat fáze projektu shora dolů ve stejném pořadí jako list: Plánování, Vývoj, Testování. Obrácení osy mění směr vykreslování; neřadí ani nepřeskupuje data v sešitu. V porovnání s tím [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) mění role řad a kategorií.

Následující příklad vytvoří vodorovný sloupcový graf se třemi fázemi a jednou řadou. Uloží prezentaci se třemi snímky: normální pořadí, obrácené kategorie a obrácené hodnoty. Každá kopie používá stejnou datovou sadu a na každé kopii je obrácena jen jedna osa.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # Snímek 2: zobrazit první kategorii nahoře.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # Udržet vodorovnou osu hodnot na dně.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # Snímek 3: obrátit pouze vodorovnou číselnou stupnici.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

Obrácení osy může také přesunout kolmé osy na opačnou stranu grafu. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) určuje, kde druhá osa protíná konfigurovanou osu. Ve snímku 2 nastavení na `MAXIMUM` na obrácené ose kategorií udrží vodorovnou osu hodnot dole. Pro konkrétní průsečík použijte [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Zkontrolujte nastavení průsečíků při změně směru, zejména pokud graf již má vlastní průsečík. Nastavte `is_plot_order_reversed` zpět na `False` pro obnovení normálního směru; nastavení průsečíků jsou samostatná.

| Normální pořadí (snímek 1) | Obrácené kategorie (snímek 2) | Obrácené hodnoty (snímek 3) |
| --- | --- | --- |
| ![Vodorovný sloupcový graf s normálním pořadím os kategorií a hodnot](axis-order-normal.png) | ![Vodorovný sloupcový graf s kategoriemi zobrazenými shora dolů](axis-order-categories-reversed.png) | ![Vodorovný sloupcový graf s obrácenou osou hodnot a nulou vpravo](axis-order-values-reversed.png) |
| Kategorie běží od spodní k horní; hodnoty rostou zleva doprava. | Plánování, Vývoj a Testování běží shora dolů. Hodnoty a pořadí řádků sešitu zůstávají beze změny. | Kategorie zachovávají svůj normální pořádek; hodnoty rostou zprava doleva. Osa kategorií protíná nulu vpravo. |

## **Zakázání svislé osy pro čárové grafy**

Nastavte [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) na `False` na svislé ose, aby byla skryta. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou svislou osou.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Zakázání vodorovné osy pro čárové grafy**

Nastavte [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) na `False` na vodorovné ose, aby byla skryta. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou vodorovnou osou.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Zobrazit nebo skrýt mřížky grafu**

Přečtěte [show_major_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_major_grid_lines/) a [show_minor_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_minor_grid_lines/) pro kontrolu, které mřížky osa zobrazuje. Oba vlastnosti jsou jen pro čtení. Pro zobrazení menších mřížek nastavte výplň čáry v [minor_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_grid_lines_format/) na plnou výplň a vyberte viditelnou barvu. Pro jejich skrytí nastavte typ výplně na `FillType.NO_FILL`. Pro hlavní mřížky použijte [major_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_grid_lines_format/)`.line.fill_format`. Změna výplně zachovává viditelnost osy a značek.

Svislá osa tohoto seskupeného sloupcového grafu začíná s viditelnými hlavními mřížkami a skrytými menšími mřížkami. Příklad nejprve zobrazí menší mřížky oranžově, pak je opět skryje před uložením prezentace.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 30, 660, 230)
    axis = chart.axes.vertical_axis
    print(f"Initial: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    minor_fill = axis.minor_grid_lines_format.line.fill_format
    minor_fill.fill_type = slides.FillType.SOLID
    minor_fill.solid_fill_color.color = slides.Color.dark_orange
    print(f"Enabled: minor={axis.show_minor_grid_lines}")

    minor_fill.fill_type = slides.FillType.NO_FILL
    print(f"Hidden: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    presentation.save("ChartGridlines.pptx", slides.export.SaveFormat.PPTX)
```

| Menší mřížky povoleny | Menší mřížky skryté |
| --- | --- |
| ![Oranžové menší mřížky mezi hlavními mřížkami na svislé ose](minor-gridlines-enabled.png) | ![Stejný sloupcový graf s viditelnými jen hlavními mřížkami](minor-gridlines-hidden.png) |

## **Změna osy kategorií**

Nastavte [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) pro výběr datumové nebo textové osy kategorií. Tento příklad vyžaduje `ExistingChart.pptx`, kde je graf jako první tvar na prvním snímku a buňky kategorií obsahují číselné datumové hodnoty Excelu. Změní vodorovnou osu na datumovou. Nastavením [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) na `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) na `1` a [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) na měsíce umístí hlavní značky v jednoměsíčních intervalech.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Určení typu osy kategorií z dat**

Po naplnění kategorií zavolejte [set_category_axis_type_automatically](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/set_category_axis_type_automatically/) a poté přečtěte [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) pro kontrolu výběru. Toto je užitečné, když stejný graf může mít buď textové popisky, nebo číselné datumové hodnoty. Metoda určuje typ při volání; neaktivuje trvalý režim, který by po změně dat znovu vyhodnocoval typ. Zavolejte ji znovu po nahrazení kategorií.

Následující příklad vytvoří graf s textovými kategoriemi a vypíše `TEXT`. Pak nahradí hodnoty buněk kategorií daty a znovu zavolá metodu, která vypíše `DATE`. Data jsou uložena jako číselné hodnoty OLE Automation, zde vypočtené jako počet dní od 30 . prosince 1899, nikoli jako řetězce datumů. [custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) řídí, jak se tyto hodnoty zobrazují; nepřevádí text na číselná data. Další informace o buňkách kategorií najdete v [Pracovní sešit grafu](/slides/cs/python-net/chart-workbook/).

Používejte automatické určení, když je vstup známý jako textové kategorie nebo číselná data, jako v tomto příkladu. Pro obyčejné číselné popisky, smíšené kategorie nebo prázdná data nastavte explicitně [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) tak, aby odpovídal zamýšlenému významu. Pouze číselné hodnoty samy o sobě nestanovují, že kategorie představují data.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series_name = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name, chart.type)
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.get_cell(0, i + 1, 0, label)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # TEXT

    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.get_cell(0, i + 1, 0)
        category_cell.value = float((category_date - date(1899, 12, 30)).days)
        category_cell.custom_number_format = "yyyy-mm-dd"

    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # DATUM

    presentation.save("AutomaticCategoryAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Řízení intervalů popisků osy kategorií**

Když má graf mnoho kategorií, můžete snížit počet viditelných popisků osy, aniž byste odstraňovali kategorie nebo datové body. Nastavte [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) na `False` a poté [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) na požadovaný interval kategorií. Pro textové kategorie v jejich normálním pořadí číslování začíná od první kategorie:

| Interval | Popisky zobrazené v příkladu |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

Interval `3` zobrazuje každý třetí popisek a mezi zobrazenými popisky skryje dva. Nepořadí odpovídající sloupce. Automatické rozestupování volí interval podle dostupného prostoru; nemusí zobrazovat všechny popisky.

Značky mají samostatná nastavení. Nastavte [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) na `False` a použijte [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) pro nastavení jejich intervalu. Například `1` ponechá značku u každého intervalu kategorie, zatímco popisky se zobrazí jen každé třetí kategorie. Nastavte [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) na viditelný styl, aby byl výsledek patrný. Návrat automatického rozestupování (nastavení automatického rozestupu zpět na `True`) umožní grafu znovu vybrat interval.

Následující samostatný příklad vytvoří 24 kategorií a jednou řadu, poté uloží tři snímky v souboru `CategoryAxisIntervals.pptx`: automatické rozestupování, ruční rozestupování popisků s nezávislými značkami a obnovené automatické rozestupování. Obě kopie zachovají původní data grafu. Vstupní prezentace není vyžadována. Vodorovný text popisků usnadňuje rozlišení hustoty.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # Snímek 2: zobrazit každý třetí popisek, ale zachovat značku pro každou kategorii.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Snímek 3: nechat graf znovu zvolit oba intervaly.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Automatické rozestupování (snímek 1):** V tomto zobrazení jsou zobrazeny každé druhé popisky kategorií a jsou zalomeny do dvou řádků. Automatický výsledek se může lišit podle velikosti grafu, fontů a rendereru.

![Automatické rozestupování popisků kategorií se všemi 24 sloupci viditelnými](category-axis-automatic.png)

**Ruční rozestupování (snímek 2):** Každý třetí popisek je zobrazen na jednom řádku, zatímco značky zůstávají u každého intervalu kategorie. Všechny 24 sloupců, včetně těch bez popisků, zůstávají viditelné se stejnými hodnotami. Snímek 3 obnovuje automatický vzhled uvedený výše.

![Ruční interval popisků kategorií tři se všemi 24 sloupci viditelnými](category-axis-manual.png)

### **Vyberte správnou osu a interval**

Použijte tento interval počtu kategorií pro textovou osu kategorií, například pro osu kategorií sloupcového, čárového, plošného nebo sloupcového grafu. Ve sloupcovém grafu je to vodorovná osa. Ve vodorovném sloupcovém grafu je osa kategorií svislá, takže použijte tato nastavení pro [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Rozestup značek se také vztahuje na osu řad v grafech, které je mají.

Nekombinujte rozestup popisků kategorií s nastavením číselné stupnice hodnotové osy. Na hodnotové ose [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) určuje rozdíl v hodnotách: například hlavní jednotka `10` vytvoří značky v 0, 10, 20 … když osa začíná nulou. Interval popisků kategorií `3` počítá pozice kategorií bez ohledu na jejich hodnoty. Bodové a bublinové grafy používají hodnotové osy místo textové osy kategorií. Pro datumovou osu použijte časové hlavní jednotky a měřítka, jak je popsáno v [Změna osy kategorií](#změna-osy-kategorií).

## **Nastavení formátu data pro hodnoty osy kategorií**

Příklad nahradí výchozí data grafu čtyřmi ročními hodnotami. Data jsou uložena jako sériová čísla OLE Automation v první listu (index `0`). Nastavte [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) na datumovou osu, zakažte [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) a přiřaďte `yyyy` k [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/), aby popisky kategorií zobrazovaly čtyřciferné roky nezávisle na formátování buňky.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení úhlu otočení názvu osy grafu**

Povolte [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) na svislé ose, zadejte text názvu a nastavte [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) pro otočení názvu. Úhel je udáván ve stupních; tento příklad uloží sloupcový graf s názvem osy hodnot otočeným o 90 stupňů.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení polohy osy na ose kategorií nebo hodnot**

Použijte [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) k řízení, zda osová hodnota protíná osu kategorií mezi kategoriemi nebo na značkách kategorií. Toto nastavení platí pro osy kategorií. Příklad nastaví tuto volbu na `True` na vodorovné ose kategorií sloupcového grafu a uloží výsledek.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení zobrazovací jednotky na hodnotové ose grafu**

Nastavte [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) pro škálování popisků na hodnotové ose bez změny podkladových dat. S [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) nastaveným na `MILLIONS` se hodnota 60 000 000 zobrazí jako 60. Příklad vytvoří sloupcový graf a použije jednotku miliony na jeho svislé ose.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Konfigurace logaritmické hodnotové osy**

Logaritmická hodnotová osa je užitečná, když kladné hodnoty zasahují několik řádů velikosti. Například služba může během pěti období přijmout 10, 100, 1 000, 10 000 a 100 000 požadavků. Na lineárním měřítku jsou menší hodnoty těsně u nuly. Logaritmické měřítko usnadňuje porovnání relativního růstu: stejné vzdálenosti představují stejné poměry, ne stejné rozdíly.

Nastavte [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) na `True` na hodnotové ose a použijte [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) pro výběr základu. Toto mění způsob, jak jsou existující hodnoty zobrazovány; nemění data ani nepřidává logaritmickou čáru trendu. Čára trendu představuje fitovaný vztah v datech a je samostatnou funkcí.

### **Vyberte hodnotovou osu a základ**

Pro čárový nebo sloupcový graf je hodnotová osa [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Pro vodorovný sloupcový graf je to [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Bodové a bublinové grafy mají dvě hodnotové osy, takže vyberte vodorovnou osu pro hodnoty X, svislou osu pro hodnoty Y nebo obě. Na osu kategorií nepoužívejte logaritmické škálování.

Výchozí logaritmický základ je `10`. Pro PPTX grafy můžete použít základ od `2` do `1000` včetně; podporovány jsou i zlomečné základy jako `2.5`. Se základem `10` jsou po sobě jdoucí mocniny 10, 100, 1 000 a 10 000 rovnoměrně rozloženy.

### **Porovnání lineárního a logaritmického měřítka**

Následující samostatný příklad vytvoří čárový graf s pěti počty požadavků na prvním snímku, pak tento snímek klonuje a na druhém povolí logaritmickou hodnotovou osu se základem 10. Oba snímky zachovají stejná data.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Udržet první snímek lineární a změnit pouze měřítko osy hodnot kopie.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Lineární měřítko (snímek 1):** Stejné vertikální vzdálenosti představují stejné rozdíly v počtech požadavků. Největší hodnota dominuje grafu a menší hodnoty jsou těžko rozlišitelné.

![Čárový graf v PowerPointu ukazující pět počtů požadavků na lineární hodnotové ose](value-axis-linear.png)

**Logaritmické měřítko (snímek 2):** Stejné vertikální vzdálenosti představují stejné poměry. Každé období má desetkrát více požadavků než předchozí, takže body tvoří přímou rostoucí čáru na logaritmickém měřítku se základem 10. Osa stále zobrazuje původní počty požadavků.

![Stejných pět požadavků v PowerPointu na logaritmické hodnotové ose se základem 10](value-axis-logarithmic.png)

### **Zpracování nulových a záporných hodnot**

Logaritmické měřítko může zobrazovat jen výhradně kladné hodnoty. Před jeho povolením data zkontrolujte. Pokud jsou nula nebo záporné hodnoty významné, zachovejte lineární měřítko nebo je zobrazte odděleně. Pokud je vyloučení těchto hodnot vhodné pro analýzu, vysvětlete vynechání. Nekrémujte je tiše malými kladnými čísly, protože by to změnilo význam dat. Jakékoli ručně nastavené minimum nebo maximum pro logaritmickou osu musí být také kladné.

## **Často kladené otázky**

**Jak nastavit hodnotu, kde jedna osa protíná druhou (průsečík os)?**

Použijte [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) pro výběr chování průsečíku. Pro zadání číselné hodnoty průsečíku nastavte [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Tato nastavení umožňují přesunout průsečík osy na vhodnou úroveň.

**Jak mohu umístit popisky značek relativně k ose?**

Nastavte [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) pomocí [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO` nebo `NONE`. Pro řízení samotných značek použijte [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) nebo [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); jsou oddělené od umístění popisků.