---
title: Přizpůsobení os grafu v prezentacích pomocí Pythonu
linktitle: Osa grafu
type: docs
url: /cs/python-net/chart-axis/
keywords:
- osa grafu
- vertikální osa
- horizontální osa
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
description: "Objevte, jak pomocí Aspose.Slides for Python via .NET přizpůsobit osy grafu v prezentacích PowerPoint a OpenDocument pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafů pomocí Aspose.Slides for Python via .NET. Pokrývá vypočtené hodnoty os, přepínání řádků a sloupců grafu, viditelnost os, intervaly popisků kategorií a značek, datumové kategorie a formátování, otáčení názvu, umístění os, jednotky zobrazení a logaritmické škálování.

## **Získání maximálních hodnot na svislé ose grafů**

Vytvořte [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) a přidejte plošný graf s výchozími daty. Zavolejte [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) před načtením vypočtených hodnot os, aby byl rozložení grafu aktuální.

Přečtěte [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) a [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) pro limity osy a [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) a [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) pro intervaly značek. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) a [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) poskytují časové jednotky, které jsou relevantní pro datumové osy. Příklad uloží tyto hodnoty do místních proměnných a uloží graf.

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

## **Prohození dat mezi osami**

Použijte [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) aby jste vyměnili role sérií a kategorií v datech grafu. Každá dřívější kategorie se stane sérií a každá dřívější série se stane kategorií. Tím se změní způsob, jakým jsou data seskupena; neprohne to vodorovnou a svislou osu. Příklad používá [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) aby svázal výchozí data s `Sheet1!A1:D5`, včetně řádku záhlaví a sloupce kategorií, před přepnutím řádků a sloupců. Uloží graf se čtyřmi sériemi a třemi kategoriemi.

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

Použijte [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) abyste obrátili kategorickou nebo hodnotovou osu. Například vodorovný sloupcový graf může zobrazovat fáze projektu shora dolů ve stejném pořadí jako list: Plánování, Vývoj, Testování. Obrácení osy změní směr vykreslování; neseřadí ani nepřeskupí data listu. Naopak [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) prohodí role sérií a kategorií.

Následující příklad vytvoří vodorovný sloupcový graf se třemi fázemi a jednou sérií. Uloží prezentaci se třemi snímky: normální pořadí, obrácené kategorie a obrácené hodnoty. Každá kopie používá stejnou datovou sadu a v každé kopii je obrácena pouze jedna osa.

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
    # Udržet vodorovnou hodnotovou osu dole.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # Snímek 3: obrátit pouze vodorovnou číselnou stupnici.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

Obrácení osy může také přesunout kolmé osu na opačnou stranu grafu. [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) řídí, kde se druhá osa protíná s konfigurovanou osou. Ve snímku 2 nastavení na `MAXIMUM` na obrácené kategorické ose ponechává vodorovnou hodnotovou osu dole. Pro konkrétní průsečík použijte [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Při změně směru zkontrolujte nastavení průsečíků, zejména pokud má graf již vlastní průsečík. Nastavte `is_plot_order_reversed` zpět na `False`, aby se obnovil normální směr vykreslování; nastavení průsečíků jsou samostatná.

| Normální pořadí (snímek 1) | Obrácené kategorie (snímek 2) | Obrácené hodnoty (snímek 3) |
| --- | --- | --- |
| ![Vodorovný sloupcový graf s normálním pořádkem kategorií a hodnotových os](axis-order-normal.png) | ![Vodorovný sloupcový graf s kategoriemi zobrazovanými shora dolů](axis-order-categories-reversed.png) | ![Vodorovný sloupcový graf s obrácenou hodnotovou osou a nulou vpravo](axis-order-values-reversed.png) |
| Kategorie běží od spodku nahoru; hodnoty rostou zleva doprava. | Plánování, Vývoj a Testování běží shora dolů. Hodnoty a pořadí řádků listu zůstávají nezměněny. | Kategorie zachovávají svůj normální pořádek; hodnoty rostou zprava doleva. Kategorická osa se protíná v nule vpravo. |

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

## **Změna kategoriální osy**

Nastavte [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) abyste zvolili datumovou nebo textovou kategoriální osu. Tento příklad vyžaduje `ExistingChart.pptx`, kde je graf jako první objekt na prvním snímku a buňky kategorií obsahují číselné datumové hodnoty z Excelu. Změní vodorovnou osu na datumovou osu. Nastavením [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) na `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) na `1` a [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) na měsíce umístí hlavní značky do intervalů jednoho měsíce.

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

## **Řízení intervalů popisků kategoriální osy**

Když má graf mnoho kategorií, snižte počet viditelných popisků osy, aniž byste odstraňovali kategorie nebo datové body. Nastavte [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) na `False` a poté nastavte [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) na požadovaný interval kategorií. Pro textové kategorie v jejich normálním pořadí se počítá od první kategorie:

| Interval | Popisky zobrazené v příkladu |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, ... Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, ... Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, ... Kategorie 22 |

Interval `3` zobrazuje každý třetí popisek a mezi zobrazenými popisky jsou skryty dva popisky. Neuklízí související sloupce. Automatické rozestupování vybírá interval podle dostupného prostoru; nemusí zobrazit každý popisek.

Značky mají samostatné ovládání. Nastavte [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) na `False` a použijte [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) k nastavení jejich intervalu. Například `1` ponechá značku u každého intervalu kategorie, zatímco popisky se objeví jen u každé třetí kategorie. Nastavte [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) na viditelný styl, abyste viděli výsledek. Nastavení kteréhokoli automatického rozestupování zpět na `True` nechá graf znovu zvolit tento interval.

Následující příklad vytvoří 24 kategorií a jednu sérii, pak uloží tři snímky v `CategoryAxisIntervals.pptx`: automatické rozestupování, manuální rozestupování popisků s nezávislými značkami a obnovené automatické rozestupování. Obě kopie zachovávají původní data grafu. Vstupní prezentace není vyžadována. Vodorovný text popisků usnadňuje vnímat rozdíl v hustotě.

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

**Automatické rozestupování (snímek 1):** V tomto vykreslení je zobrazen každý druhý popisek kategorie a zalamuje se do dvou řádků. Automatický výsledek se může lišit podle velikosti grafu, písem a vykreslovacího enginu.

![Automatické rozestupování popisků kategorií se všemi 24 sloupci viditelnými](category-axis-automatic.png)

**Manuální rozestupování (snímek 2):** Každý třetí popisek je zobrazen v jednom řádku, zatímco značky zůstávají u každého intervalu kategorie. Všechny 24 sloupců, včetně těch bez popisků, zůstávají viditelné se stejnými hodnotami. Snímek 3 obnovuje automatický vzhled uvedený výše.

![Manuální interval popisků kategorií tři se všemi 24 sloupci viditelnými](category-axis-manual.png)

### **Zvolte správnou osu a interval**

Použijte tento interval počtu kategorií pro textovou kategoriální osu, například pro kategoriální osu sloupcového, čárového, plošného nebo sloupcového grafu. Ve sloupcovém grafu je to vodorovná osa. Ve vodorovném sloupcovém grafu je kategoriální osa svislá, takže tyto nastavení použijte na [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Rozestupování značek se také vztahuje na sériovou osu v grafech, které ji mají.

Nepožadujte rozestupování popisků kategorií k nastavení číselné stupnice hodnotové osy. Na hodnotové ose [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) určuje rozdíl v hodnotách: například hlavní jednotka `10` vytvoří značky na 0, 10, 20 atd., pokud osa začíná nulou. Interval popisků kategorií `3` počítá místo kategorií, nezávisle na jejich hodnotách. Bodové a bublinové grafy používají hodnotové osy místo textové kategoriální osy. Pro datumovou osu použijte časově založené hlavní jednotky a stupnice, jak je popsáno v [Změna kategoriální osy](#change-a-category-axis).

## **Nastavení formátu data pro hodnoty kategoriální osy**

Příklad nahradí výchozí data grafu čtyřmi ročními hodnotami. Data jsou uložena jako sériová čísla OLE Automation v první tabulce (index `0`). Nastavte [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) na datumovou osu, vypněte [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) a přiřaďte `yyyy` k [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/), aby se popisky kategorií zobrazovaly jako čtyřciferné roky nezávisle na formátování buňky.

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

Povolte [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) na svislé ose, zadejte text názvu a nastavte [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) k otáčení názvu. Úhel se měří ve stupních; tento příklad ukládá sloupcový graf s názvem hodnotové osy otočeným o 90°.

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

## **Nastavení pozice osy na kategoriální nebo hodnotové ose**

Použijte [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) aby jste určili, zda se hodnotová osa protíná s kategoriální osou mezi kategoriemi nebo na značkách kategorií. Toto nastavení platí pro kategoriální osy. Příklad nastaví tuto vlastnost na `True` na vodorovné kategoriální ose sloupcového grafu a uloží výsledek.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení jednotky zobrazení na hodnotové ose grafu**

Nastavte [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) k měřítku popisků na hodnotové ose, aniž by se změnila podkladová data. S [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) nastaveným na `MILLIONS` se hodnota 60 000 000 zobrazí jako 60. Příklad vytvoří sloupcový graf a použije jednotku milionů na jeho svislé ose.

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

Logaritmická hodnotová osa je užitečná, když kladné hodnoty zasahují několik řádů velikosti. Například služba může během pěti období přijímat 10, 100, 1 000, 10 000 a 100 000 požadavků. Na lineární stupnici jsou menší hodnoty blízko sebe u nuly. Logaritmická stupnice usnadňuje porovnání relativního růstu: stejné vzdálenosti představují stejné poměry, ne stejné rozdíly.

Nastavte [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) na `True` na hodnotové ose a použijte [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) k výběru základu. Toto změní, jak jsou existující hodnoty zobrazovány; nezmění data ani nepřidá logaritmickou trendovou čáru. Trendová čára představuje aproximaci vztahu v datech a je samostatnou funkcí.

### **Zvolte hodnotovou osu a základnu**

Pro čárový nebo sloupcový graf je hodnotová osa [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Pro vodorovný sloupcový graf je to [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Bodové a bublinové grafy mají dvě hodnotové osy, takže vyberte vodorovnou osu pro hodnoty X, svislou pro hodnoty Y, nebo obě. Logaritmické škálování neaplikujte na kategoriální osu.

Výchozí logaritmický základ je `10`. Pro PPTX grafy použijte základ od `2` do `1000` inkluzivně; podporovány jsou i zlomek základny jako `2.5`. Se základnou `10` jsou po sobě jdoucí mocniny 10, 100, 1 000 a 10 000 rovnoměrně rozloženy.

### **Porovnání lineárního a logaritmického škálování**

Následující příklad vytvoří čárový graf s pěti počty požadavků na prvním snímku, poté tento snímek klonuje a na druhém povolí logaritmickou hodnotovou osu s bází 10. Oba snímky zachovávají stejná data.

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

    # Zachovat první snímek lineární a změnit jen stupnici hodnotové osy v kopii.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Lineární škála (snímek 1):** Stejné vertikální vzdálenosti představují stejné rozdíly v počtu požadavků. Největší hodnota dominuje grafu, což ztěžuje rozlišení menších hodnot.

![Čárový graf v PowerPointu ukazující pět požadavků na lineární hodnotové ose](value-axis-linear.png)

**Logaritmická škála (snímek 2):** Stejné vertikální vzdálenosti představují stejné poměry. Každé období má desetkrát více požadavků než předchozí, takže body tvoří rovnou stoupající čáru na logaritmické stupnici s bází 10. Popisky osy stále ukazují původní počty požadavků.

![Stejných pět požadavků v PowerPointu na logaritmické hodnotové ose s bází 10](value-axis-logarithmic.png)

### **Zpracování nulových a záporných hodnot**

Logaritmická stupnice může zobrazovat jen striktně kladné hodnoty. Před jejím povolením data zkontrolujte. Pokud jsou nuly nebo záporné hodnoty smysluplné, zachovejte lineární stupnici nebo je zobrazte samostatně. Pokud je vyloučení těchto hodnot vhodné pro analýzu, uveďte důvod. Nepřepisujte je tiše malými kladnými čísly, protože to mění význam dat. Každý ručně nastavený minimální nebo maximální limit pro logaritmickou osu musí být také kladný.

## **FAQ**

**Jak nastavit hodnotu, při které se jedna osa protíná s druhou (průsečík osy)?**

Použijte [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) k výběru chování průsečíku. Pro specifikaci číselné hodnoty průsečíku nastavte [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Tím můžete posunout průsečík osy na vhodnou úroveň.

**Jak mohu umístit popisky značek relativně k ose?**

Nastavte [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) pomocí [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/): `LOW`, `HIGH`, `NEXT_TO` nebo `NONE`. Pro řízení samotných značek použijte [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) nebo [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/); jsou oddělené od umístění popisků.