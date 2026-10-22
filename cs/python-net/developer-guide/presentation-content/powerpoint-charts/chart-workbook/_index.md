---
title: Správa pracovních sešitů grafů v prezentacích s Pythonem
linktitle: Pracovní sešit grafu
type: docs
weight: 70
url: /cs/python-net/chart-workbook/
keywords:
- pracovní sešit grafu
- data grafu
- buňka pracovního sešitu
- popisek dat
- list
- zdroj dat
- externí pracovní sešit
- externí data
- mezipaměť grafu
- obnova pracovního sešitu
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Objevte Aspose.Slides pro Python via .NET: snadno spravujte pracovní sešity grafů v PowerPoint a formátech OpenDocument, abyste zjednodušili data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s sešity grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu pomocí streamů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat ke kolekcím listů a specifikovat typ zdroje dat pro hodnoty grafu.

Také se zabývá prací s externími sešity jako zdroji dat pro grafy. Příklady ukazují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

Pro buňky sešitu představující chybějící data viz [Ovládání zobrazení prázdných buněk](/slides/cs/python-net/chart-series/) pro rozdíl mezi prázdnou buňkou a nulou a srovnání v čárovém grafu dostupných režimů zobrazení.

## **Zahrnutí dat ze skrytých řádků a sloupců**

Použijte [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) k ovládání, zda graf zobrazuje data ze skrytých řádků a sloupců listu. Nastavte na `True` pro vykreslení pouze viditelných buněk nebo na `False` pro zahrnutí jak viditelných, tak skrytých buněk. Toto nastavení řídí vykreslování grafu; neprovádí skrytí ani zobrazení řádků nebo sloupců listu.

Ukázková prezentace ([hidden-source-data.pptx](hidden-source-data.pptx)) obsahuje sloupcový graf jako první tvar na první snímku. Vložený list, `Sheet1`, obsahuje následující zdrojový rozsah `A1:C4`. Řádek 3 a sloupec C jsou skryté, ale jejich buňky stále obsahují hodnoty.

| Řádek listu | A: Měsíc | B: Maloobchod | C: Velkoobchod (skrytý sloupec) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (skrytý řádek) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Přístup ke zdrojovým buňkám získáte přes [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) a přečtete [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) pro kontrolu skrytého stavu. Tato vlastnost je jen pro čtení. V tomto souboru je B2 viditelný, B3 patří ke skrytému řádku a C2 patří ke skrytému sloupci; příklad vypíše `False`, `True` a `True`.

Pro tento příklad obnovte data grafu po změně nastavení vykreslování: ponechte vložený sešit pomocí [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) a načtěte jej znovu s [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Při zahrnutí všech buněk také použijte [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) k obnovení kompletního rozsahu, včetně skrytého únorového kategorií. Pouhé změnění příznaku neobnoví cache grafu a popisků kategorií v tomto příkladu.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # Obnovte data grafu z vloženého sešitu.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Obnovte kompletní zdrojový rozsah, včetně skrytých kategorií.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Příklad uloží dvě verze prezentace: jednu pouze s viditelnými hodnotami Maloobchodu (10 a 20) a druhou se všemi šesti hodnotami. Obrázky níže byly vygenerovány ze uložených prezentací po jejich znovuotevření; oba soubory zachovávají nastavené vykreslování. Řádek 3 a sloupec C zůstávají skryté v obou vložených sešitech.

| Pouze viditelné buňky (`True`) | Všechny buňky (`False`) |
| --- | --- |
| ![Pouze viditelné buňky: hodnoty maloobchodu 10 a 20 pro leden a březen.](hidden_cells_True.png) | ![Všechny buňky: hodnoty maloobchodu a velkoobchodu pro leden, únor a březen.](hidden_cells_False.png) |

Skrytá buňka obsahující hodnotu se liší od prázdné buňky. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) určuje, jak se zobrazují chybějící hodnoty; nezasahuje do zahrnutí nebo vyloučení skrytých zdrojových dat. Viz [Ovládání zobrazení prázdných buněk](/slides/cs/python-net/chart-series/#control-the-display-of-empty-cells) pro příklad.

## **Získání rozsahu dat grafu**

Před aktualizací dat sešitu v existující prezentaci si prohlédněte zdrojové rozsahy, abyste zjistili, které buňky listu každý graf používá. Metoda [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) vrací aktuální datový rozsah jako listem kvalifikovaný vzorec, např. `Sheet1!$A$1:$D$5`. Zde `Sheet1` je název listu, `!` jej odděluje od rozsahu buněk a `$A$1:$D$5` určuje buňky A1 až D5 včetně. Znaky `$` označují absolutní odkazy na řádky a sloupce.

Metoda čte aktuální rozsah, aniž by měnila graf nebo jeho sešit. Pokud graf nepoužívá sešit jako zdroj dat, vyvolá výjimku. Další informace naleznete v [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

Tento příklad otevře prezentaci a zkontroluje tvary přímo na každém snímku, zda jsou grafy. Vypíše název každého grafu a jeho zdrojový rozsah. Pokud se rozsah nepodaří získat, vypíše diagnostickou zprávu a pokračuje dalším grafem.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **Čtení a zápis dat grafu ze sešitu**

Aspose.Slides for Python via .NET poskytuje metody [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) a [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/), které umožňují číst a zapisovat sešity dat grafu (obsahující data upravená pomocí Aspose.Cells). **Poznámka**: data grafu musí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

Tento příklad používá prezentaci s grafem jako první tvar na první snímku. Načte vložený sešit do streamu, vymaže existující série a kategorie a zapíše stejný sešit zpět. Změny zůstávají v paměti; příklad neukládá prezentaci.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **Ověření rozvržení grafu po úpravě sešitu**

Když nahradíte vložený sešit upraveným, graf si zachová původní kolekce sérií a kategorií. Tento nesoulad může způsobit, že [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) selže s chybou indexu mimo rozsah. Před zápisem aktualizovaného sešitu vraťte grafu původní kolekce vymazáním existujících sérií a kategorií. Tento příklad používá graf, který je první tvar na první snímku. Komentář označuje místo, kde by se upravoval sešit; spustitelný příklad zapíše původní sešit zpět a ověří rozvržení v paměti.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Zde upravte stream pracovního sešitu, například pomocí Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Vymazání kolekcí odstraní zastaralé odkazy na data před zápisem sešitu zpět. Před použitím grafu znovu vytvořte požadované mapování sérií a kategorií pro aktualizovaný sešit.

## **Nastavení vlastních číselných formátů pro buňky sešitu**

Použijte [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) k ovládání, jak se číselné hodnoty zobrazují ve vloženém sešitu grafu. Například zpráva může potřebovat zobrazit konverzní míru jako procento se čtyřmi desetinnými místy a koeficient se pěti desetinnými místy. Obě hodnoty ponechte číselné, aby byly dostupné pro výpočty a vykreslování grafu.

Číselný formát mění jen zobrazení, ne uloženou hodnotu. Formát `0.0000%` zobrazí `0.125` jako `12.5000 %`; nehmění uložené číslo na `12.5`. Podobně `0.00000` zobrazí `0.1234567` jako `0.12346` bez zaokrouhlení uložené hodnoty. Pokud je vlastní formát prázdný řetězec (`""`), použije se místo něj [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/).

Následující příklad vytvoří sloupcový graf a přistoupí k jeho buňkám přes [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/). Na listu 0 B2 obsahuje konverzní míru a C2 koeficient. Obě buňky poskytují hodnoty pro graf. Příklad také povolí popisky hodnot propojené se zdrojovým formátem.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

Formáty buněk sešitu jsou oddělené od formátů nastavených přímo na osách grafu nebo popiscích dat. V tomto příkladu každý popisek zobrazuje hodnotu své zdrojové buňky, protože je povoleno [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) a je nastaveno [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) na `True`. Po uložení a opětovném otevření prezentace popisky zobrazí `12.5000%` a `0.12346`, jak je ukázáno níže. Vertikální osa používá vlastní [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) `0.00` a má [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) nastaveno na `False`.

Pro samostatné formátování popisku nastavte jeho příznak propojení se zdrojem na `False` a přiřaďte mu [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/). Tím se nezmění formát buňky sešitu. Například nezávislý formát popisku `0.00` zobrazí první hodnotu jako `0.13`, zatímco B2 stále zobrazuje `12.5000%`. Viz [Popisky dat grafu](/slides/cs/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) pro přímé formátování popisků.

![Sloupcový graf se zdrojově propojenými popisky ukazujícími 12,5000 % a 0,12346 a nezávisle formátovanou číselnou osou.](custom-cell-formats.png)

## **Nastavení buňky sešitu jako popisku dat grafu**

Můžete použít text z buněk sešitu jako popisky dat grafu.

Tento příklad přidá bublinový graf s výchozími daty na první snímek existující prezentace. Použije buňky A10:A12 na listu 0 pro první tři popisky v první sérii, povolí popisky z buněk a uloží aktualizovanou prezentaci.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Správa listů**

Vlastnost [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) poskytuje přístup k listům v sešitu grafu. Tento příklad vytvoří koláčový graf s výchozími daty a vypíše název každého listu do konzole.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **Specifikace typu zdroje dat**

Hodnoty bodů série mohou být také uloženy přímo jako číselné literály. Viz [Set Series Values Using Numeric Literals](/slides/cs/python-net/chart-series/#set-series-values-using-numeric-literals) pro kompletní příklad, který je ukládá a čte. Typ zdroje hodnot bodů je oddělený od vnitřní nebo externí konfigurace sešitu grafu; použití číselných literálů samo o sobě neodstraňuje vložený sešit.

Tento příklad vytvoří 3D sloupcový graf s výchozími daty a nastaví dva názvy sérií pomocí různých zdrojů dat. První název používá řetězcový literál; druhý používá buňku C1 na listu 0. Výčtová hodnota [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) volí zdroj pro každý název. Příklad uloží prezentaci s aktualizovanými názvy sérií.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Detekce nepodporovaných formátů vložených sešitů**

Aspose.Slides nepodporuje binární formát Excelu (.xlsb), který může být vložen v některých grafech. Můžete použít vlastnost [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) na [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) společně s výčtem [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) k detekci nepodporovaných formátů a přeskočení takových grafů. Tento příklad prozkoumá tvary na první snímku existující prezentace, přeskočí netypické tvary a pro každý graf s vloženým .xlsb sešitem vypíše diagnostickou zprávu.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # Přečtěte nebo upravte podporovaná data pracovního sešitu grafu zde.
```

## **Externí sešit**

Aspose.Slides podporuje používání externích sešitů jako zdroje dat pro grafy.

### **Vytvoření externího sešitu**

Použijte [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) a [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) k exportu vloženého sešitu grafu do souboru a propojení grafu s tímto externím sešitem.

Tento příklad vytvoří koláčový graf s výchozími daty a exportuje jeho sešit. Před přiřazením externího sešitu jako zdroj dat grafu uzavře výstupní stream a poté uloží propojenou prezentaci.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)

    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Nastavení externího sešitu**

Pomocí metody [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) můžete přiřadit externí sešit grafu jako jeho zdroj dat. Tuto metodu lze také použít k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

I když nemůžete upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete je i nadále používat jako externí zdroj dat. Pokud je poskytnuta relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

Tento příklad používá externí sešit, jehož list pojmenovaný `Sheet1` obsahuje název série v B1, názvy kategorií v A2:A4 a číselné hodnoty v B2:B4. Příklad vytvoří koláčový graf, propojí sešit a použije [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) k mapování A1:B4 na jednu sérii a tři kategorie. Uloží prezentaci s propojeným grafem.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

Parametr `update_chart_data` metody [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) řídí, zda je sešit načten.

* Když je `update_chart_data` `False`, aktualizuje se jen cesta k sešitu. Data grafu nejsou načtena ani aktualizována z cílového sešitu, takže sešit může být nedostupný.
* Když je `update_chart_data` `True`, data grafu jsou aktualizována z cílového sešitu.

Následující příklad přiřadí zástupnou URL s `update_chart_data` nastaveným na `False`. Zachová výchozí data koláčového grafu a uloží prezentaci bez načtení nedostupného sešitu.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Získání cesty k externímu sešitu datového zdroje grafu**

Chcete‑li zjistit, který sešit je propojen s grafem, zkontrolujte, zda graf používá externí datový zdroj, a získejte jeho cestu k sešitu.

Tento příklad prozkoumá první tvar na první snímku prezentace s propojeným externím sešitem. Pokud jde o graf propojený s externím sešitem, vypíše [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) do konzole. Poté uloží kopii prezentace.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **Úprava dat grafu**

Můžete upravit data v externích sešitech stejným způsobem, jako měníte obsah interních sešitů. Když není externí sešit načten, vyvolá se výjimka.

Tento příklad používá graf, který je první tvar na první snímku a je propojen s přístupným externím sešitem. Nastaví hodnotu první datové bodu první série na 100 a uloží aktualizovanou prezentaci. Úprava hodnot v buňkách může aktualizovat propojený externí soubor XLSX, proto použijte kopii, pokud potřebujete zachovat originální sešit.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **Obnovení sešitu z cache grafu**

Pokud graf používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může rekonstruovat sešit grafu z dat uložených v cache prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), nakonfigurujte jeho [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), a nastavte [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) na `True` před otevřením prezentace.

Následující Python příklad obnoví data sešitu pro graf, který je první tvar na první snímku a odkazuje na nedostupný externí sešit. Přistupuje k obnoveným datům přes [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # Přečtěte nebo upravte obnovená data pracovního sešitu zde.
    else:
        print("The first shape is not a chart.")
```

Pokud je externí sešit nedostupný a obnova je vypnutá, Aspose.Slides vyvolá výjimku. Povolit obnovu použijte jen tehdy, když je akceptovatelná práce s daty z cache, protože cache nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu zjistit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) a [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ověřit, že je používán externí soubor.

**Jsou relativní cesty k externím sešitum podporovány a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. Prezentace ukládá absolutní cestu v souboru PPTX, takže při přesunu sešitu může být nutné aktualizovat odkaz.

**Mohu používat sešity umístěné na síťových zdrojích/sdílených složkách?**

Ano, takové sešity mohou být použity jako externí datový zdroj. Úprava vzdálených sešitů přímo z Aspose.Slides však není podporována – mohou být použity jen jako zdroj.

**Přepisuje Aspose.Slides externí soubor XLSX při ukládání prezentace?**

Prezentace ukládá [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Úprava dat grafu založených na buňkách může také aktualizovat propojený lokální soubor XLSX. Použijte kopii sešitu, pokud musí originál zůstat nezměněn.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při vytváření odkazu. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (např. pomocí [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) a odkazovat na tuto kopii.

**Mohou více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf uloží svůj vlastní odkaz. Pokud všechny odkazují na stejný soubor, aktualizace tohoto souboru se projeví v každém grafu při dalším načtení dat.