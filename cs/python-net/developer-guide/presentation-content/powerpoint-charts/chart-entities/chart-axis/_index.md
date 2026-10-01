---
title: Přizpůsobení os diagramů v prezentacích pomocí Pythonu
linktitle: Osa diagramu
type: docs
url: /cs/python-net/chart-axis/
keywords:
- osa diagramu
- svislá osa
- vodorovná osa
- přizpůsobení osy
- manipulace s osou
- správa osy
- vlastnosti osy
- maximální hodnota
- minimální hodnota
- čára osy
- formát data
- název osy
- umístění osy
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Objevte, jak použít Aspose.Slides for Python via .NET k přizpůsobení os diagramů v prezentacích PowerPoint a OpenDocument pro zprávy a vizualizace."
---
## **Přehled**

Tento článek popisuje, jak přizpůsobit osy diagramu pomocí Aspose.Slides for Python via .NET. Pokrývá vypočítané hodnoty os, přepínání řádků a sloupců diagramu, viditelnost os, intervaly popisků kategorií a značek os, datumové kategorie a formátování, otáčení názvu, umístění os a jednotky zobrazení.

## **Získání maximálních hodnot na svislé ose v diagramech**

Vytvořte [Prezentaci](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) a přidejte plošný diagram s výchozími daty. Před načtením vypočítaných hodnot os zavolejte [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/), aby byl rozvržení diagramu aktuální.

Přečtěte [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) a [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) pro limity osy a [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) a [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) pro intervaly značek. [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) a [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) poskytují časové jednotkové měřítka, která jsou relevantní pro datumové osy. Příklad ukládá tyto hodnoty do lokálních proměnných a ukládá diagram.

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

Použijte [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) k výměně rolí řad a kategorií v datech diagramu. Každá dřívější kategorie se stane řadou a každá dřívější řada se stane kategorií. Tím se změní způsob seskupování dat; neprohodí to vodorovné a svislé osy. Příklad používá [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) k přiřazení výchozích dat na `Sheet1!A1:D5`, včetně řádku záhlaví a sloupce kategorií, před výměnou řádků a sloupců. Uloží diagram se čtyřmi řadami a třemi kategoriemi.

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

## **Zakázání svislé osy pro spojnicové diagramy**

Nastavte [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) na `False` na svislé ose, aby se skryla. Příklad vytvoří spojnicový diagram s výchozími daty a uloží jej se skrytou svislou osou.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Zakázání vodorovné osy pro spojnicové diagramy**

Nastavte [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) na `False` na vodorovné ose, aby se skryla. Příklad vytvoří spojnicový diagram s výchozími daty a uloží jej se skrytou vodorovnou osou.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Změna osy kategorií**

Nastavte [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) pro výběr datumové nebo textové osy kategorií. Tento příklad vyžaduje soubor `ExistingChart.pptx`, kde je diagram jako první tvar na první snímku a buňky kategorií obsahují číselné datumové hodnoty Excelu. Změní vodorovnou osu na datumovou osu. Nastavením [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) na `False`, [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) na `1` a [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) na měsíce umístíte hlavní značky v intervalech jednoho měsíce.

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

## **Ovládání intervalů popisků osy kategorií**

Když má diagram mnoho kategorií, snižte počet viditelných popisků os, aniž byste odstraňovali kategorie nebo datové body. Nastavte [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) na `False` a poté nastavte [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) na požadovaný interval kategorií. Pro textové kategorie v normálním pořadí se počítání začíná od první kategorie:

| Interval | Popisky zobrazené v příkladu |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, ... Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, ... Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, ... Kategorie 22 |

Interval `3` zobrazí každý třetí popisek, přičemž mezi zobrazenými popisky jsou skryty dva popisky. Neodstraňuje to odpovídající sloupce. Automatické rozestupování vybírá interval na základě dostupného místa; nemusí nutně zobrazit každý popisek.

Značky os mají samostatná nastavení. Nastavte [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) na `False` a použijte [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/), abyste určili jejich interval. Například `1` zachová značku na každém intervalu kategorií, zatímco popisky se zobrazí jen každou třetí kategorii. Nastavte [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) na viditelný styl, aby byl výsledek patrný. Nastavením libovolné automatické vlastnosti zpět na `True` umožní diagramu znovu zvolit tento interval.

Následující samostatný příklad vytvoří 24 kategorií a jednu řadu, poté uloží tři snímky do souboru `CategoryAxisIntervals.pptx`: automatické rozestupování, ruční rozestupování popisků s nezávislými značkami a obnovené automatické rozestupování. Obě kopie zachovají původní data diagramu. Vstupní prezentace není vyžadována. Horizontální text popisku usnadňuje vidět rozdíl v hustotě.

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

    # Snímek 3: nechat diagram znovu zvolit oba intervaly.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Automatické rozestupování (snímek 1):** V tomto vykreslení je zobrazena každá druhá kategorie a text se zalamuje do dvou řádků. Automatický výsledek se může lišit podle velikosti diagramu, písem a vykreslovacího nástroje.

![Automatické rozestupování popisků kategorií se všemi 24 sloupci viditelnými](category-axis-automatic.png)

**Ruční rozestupování (snímek 2):** Každý třetí popisek je zobrazen v jednom řádku, zatímco značky zůstávají na každém intervalu kategorií. Všechny 24 sloupce, včetně těch bez popisků, zůstávají viditelné se stejnými hodnotami. Snímek 3 obnoví automatický vzhled uvedený výše.

![Ruční interval popisků kategorií třemi se všemi 24 sloupci viditelnými](category-axis-manual.png)

### **Vyberte správnou osu a interval**

Použijte tento interval počtu kategorií pro textovou osu kategorií, například osu kategorií sloupcového, spojnicového, plošného nebo pruhového diagramu. V sloupcovém diagramu je to vodorovná osa. V horizontálním pruhovém diagramu je osa kategorií vertikální, takže tyto nastavení aplikujte na [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Rozestupování značek se také vztahuje na osu řady v diagramech, které ji mají.

Nepoužívejte rozestupování popisků kategorií k nastavení číselného měřítka hodnotové osy. Na hodnotové ose [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) určuje rozdíl v hodnotách: například hlavní jednotka `10` vytvoří značky při 0, 10, 20 atd., když osa začíná nulou. Interval popisků kategorií `3` počítá pozice kategorií, nezávisle na jejich hodnotách. Bodové a bublinové diagramy používají hodnotové osy místo textové osy kategorií. Pro datumovou osu použijte časové jednotky a měřítka, jak je popsáno v [Change a Category Axis](#change-a-category-axis).

## **Nastavení formátu data pro hodnoty osy kategorií**

Příklad nahradí výchozí data diagramu čtyřmi ročními hodnotami. Datum jsou uložena jako sériová čísla OLE Automation v první listu (index `0`). Nastavte [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) na datumovou osu, zakažte [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/), a přiřaďte `yyyy` do [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/), aby popisky kategorií zobrazovaly čtyřciferné roky nezávisle na formátování buňky.

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

## **Nastavení úhlu otočení názvu osy diagramu**

Povolte [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) na svislé ose, zadejte text názvu a nastavte [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) , aby se název otočil. Úhel se měří ve stupních; tento příklad uloží sloupcový diagram s názvem hodnotové osy otočeným o 90 stupňů.

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

## **Nastavení polohy osy na ose kategorií nebo hodnotové ose**

Použijte [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) , abyste určili, zda hodnotová osa protíná osu kategorií mezi kategoriemi nebo na značkách kategorií. Tato vlastnost se vztahuje na osy kategorií. Příklad nastaví tuto hodnotu na `True` na vodorovné ose kategorií sloupcového diagramu a uloží výsledek.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Nastavení jednotky zobrazení na hodnotové ose diagramu**

Nastavte [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) , aby se štítky na hodnotové ose škálovaly bez změny podkladových dat. S [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) nastaveným na `MILLIONS` se hodnota 60 000 000 zobrazí jako 60. Příklad vytvoří sloupcový diagram a použije jednotku zobrazení milionů na jeho svislé ose.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Jak nastavit hodnotu, kde se jedna osa protíná s druhou (průsečík osy)?**

Použijte [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) , abyste vybrali chování průsečíku. Pro zadání číselné hodnoty průsečíku nastavení [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) . Tato nastavení vám umožní přesunout průsečík osy na vhodnou úroveň.

**Jak mohu umístit popisky značek vzhledem k ose?**

Nastavte [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) pomocí [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) : `LOW`, `HIGH`, `NEXT_TO` nebo `NONE`. Pro ovládání samotných značek použijte [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) nebo [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) ; tyto jsou oddělené od umístění popisků.