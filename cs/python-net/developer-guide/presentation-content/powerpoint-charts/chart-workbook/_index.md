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
- obnovení pracovního sešitu
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Objevte Aspose.Slides pro Python prostřednictvím .NET: snadno spravujte pracovní sešity grafů v PowerPoint a formátech OpenDocument, aby byl váš prezentační data efektivnější."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s sešity grafů v Aspose.Slides. Popisuje, jak číst a zapisovat data grafu prostřednictvím proudů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat ke kolekcím listů a určovat typ zdroje dat pro hodnoty grafu.

Také se zabývá používáním externích sešitů jako zdrojů dat pro grafy. Příklady ukazují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

Pro buňky sešitu, které představují chybějící data, viz [Control the Display of Empty Cells](/slides/cs/python-net/chart-series/) pro rozdíl mezi prázdnou buňkou a nulou a porovnání čárového grafu dostupných režimů zobrazení.

## **Zahrnout data ze skrytých řádků a sloupců**

Použijte [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) k ovládání, zda graf vykresluje data ze skrytých řádků a sloupců listu. Nastavte jej na `True`, aby se vykreslovaly pouze viditelné buňky, nebo na `False`, aby se zahrnovaly jak viditelné, tak skryté buňky. Toto nastavení řídí vykreslování grafu; neskrývá ani nezobrazí řádky nebo sloupce listu.

[Sample presentation](hidden-source-data.pptx) obsahuje sloupcový graf jako první tvar na první snímku. Vložený list `Sheet1` obsahuje následující zdrojový rozsah `A1:C4`. Řádek 3 a sloupec C jsou skryté, ale jejich buňky stále obsahují hodnoty.

| Řádek listu | A: Měsíc | B: Retail | C: Wholesale (skrytý sloupec) |
| --- | --- | --- | --- |
| 2 | Leden | 10 | 30 |
| 3 (skrytý řádek) | Únor | 40 | 60 |
| 4 | Březen | 20 | 50 |

Přistupujte ke zdrojovým buňkám přes [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) a čtěte [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) k ověření jejich skrytého stavu. Tato vlastnost je jen pro čtení. V tomto souboru je B2 viditelná, B3 patří ke skrytému řádku a C2 patří ke skrytému sloupci; příklad vypíše `False`, `True` a `True` v tomto pořadí.

Pro tento příklad po změně nastavení vykreslování obnovte data grafu: zachovejte vložený sešit pomocí [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) a načtěte jej znovu pomocí [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Při zahrnutí všech buněk také použijte [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) k obnovení úplného rozsahu, včetně skryté kategorie únor. Pouze změna příznaku není dostačující k obnovení kešovaných dat grafu a popisků kategorií v tomto vzorku.

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

            # Obnovte data grafu z vloženého pracovního sešitu.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Obnovte celý zdrojový rozsah, včetně skrytých kategorií.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Příklad uloží dvě verze prezentace: jednu pouze s viditelnými hodnotami Retail (10 a 20) a druhou se všemi šesti hodnotami. Obrázky níže byly vygenerovány ze uložených prezentací po jejich opětovném otevření; oba soubory zachovávají své nastavené vykreslování. Řádek 3 a sloupec C zůstávají skryté v obou vložených sešitech.

| Pouze viditelné buňky (`True`) | Všechny buňky (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Skrytá buňka obsahující hodnotu se liší od prázdné buňky. [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) řídí, jak se zobrazují chybějící hodnoty; neovlivňuje zahrnutí nebo vyloučení skrytých zdrojových dat. Viz [Control the Display of Empty Cells](/slides/cs/python-net/chart-series/#control-the-display-of-empty-cells) pro příklad.

## **Získat rozsah dat grafu**

Před aktualizací dat sešitu v existující prezentaci prověřte zdrojové rozsahy, abyste identifikovali, které buňky listu každý graf používá. Metoda [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) vrací aktuální datový rozsah jako vzorec s odkazem na list, například `Sheet1!$A$1:$D$5`. Zde `Sheet1` je název listu, `!` odděluje název od rozsahu buněk a `$A$1:$D$5` určuje buňky A1 až D5 včetně. Znaky `$` označují absolutní odkazy na řádky a sloupce.

Metoda čte aktuální rozsah bez změny grafu nebo jeho sešitu. Pokud graf nepoužívá sešit jako zdroj dat, vyvolá výjimku. Další informace najdete v [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/).

Tento příklad otevře prezentaci a přímo na každém snímku zkontroluje tvary pro grafy. Vypíše název každého grafu a jeho zdrojový rozsah. Pokud nelze rozsah získat, vypíše diagnostickou zprávu a pokračuje k dalšímu grafu.

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

## **Číst a zapisovat data grafu ze sešitu**

Aspose.Slides for Python via .NET poskytuje metody [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) a [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/), které umožňují číst a zapisovat sešity dat grafu (obsahující data grafu upravená pomocí Aspose.Cells). **Note** že data grafu musí být uspořádána stejným způsobem nebo mít strukturu podobnou zdrojovým.

Tento příklad používá prezentaci s grafem jako první tvar na první snímku. Načte vložený sešit do proudu, vymaže existující řady a kategorie a zapíše stejný sešit zpět. Změny zůstanou v paměti; příklad neukládá prezentaci.

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

### **Ověřit rozvržení grafu po úpravě sešitu**

Když nahradíte vložený sešit upraveným, graf si zachová původní kolekce řad a kategorií. Toto nesoulad může způsobit selhání [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) s chybou indexu mimo rozsah. Před zápisem upraveného sešitu zpět do grafu vymažte existující řady a kategorie. Tento příklad používá graf, který je první tvar na první snímku. Komentář označuje místo, kde by úprava sešitu proběhla; spustitelný příklad zapíše původní sešit zpět a ověří rozvržení v paměti.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Modifikujte zde stream pracovního sešitu, například pomocí Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Vymazání kolekcí odstraní zastaralé odkazy na data před zápisem sešitu. Přestavte jakékoli potřebné mapování řad a kategorií pro aktualizovaný sešit před použitím grafu.

## **Nastavit buňku sešitu jako popisek dat grafu**

Můžete použít text z buněk sešitu jako popisky dat grafu.

Tento příklad přidá bublinový graf s výchozími daty na první snímek existující prezentace. Použije buňky A10:A12 na listu 0 pro první tři popisky v první řadě, povolí popisky z buněk a uloží aktualizovanou prezentaci.

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

Vlastnost [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) poskytuje přístup k listům v sešitu grafu. Tento příklad vytvoří koláčový graf s výchozími daty a vypíše každé jméno listu do konzole.

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

## **Určit typ zdroje dat**

Tento příklad vytvoří 3D sloupcový graf s výchozími daty a nastaví dvě názvy řad pomocí různých zdrojů dat. První název používá řetězcový literál; druhý používá buňku C1 na listu 0. Výčtová hodnota [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) vybírá zdroj pro každý název. Příklad uloží prezentaci s aktualizovanými názvy řad.

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

Aspose.Slides nepodporuje formát binárního sešitu Excel (.xlsb), který může být vložen v některých grafech. Můžete použít vlastnost [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) na [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) k detekci nepodporovaných formátů a přeskočit tyto grafy. Tento příklad prověří tvary na první snímek existující prezentace, přeskočí tvary, které nejsou grafy, a pro každý graf s vloženým .xlsb sešitem vypíše diagnostickou zprávu.

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

Aspose.Slides podporuje použití externích sešitů jako zdroje dat pro grafy.

### **Vytvořit externí sešit**

Použijte [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) a [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) k exportu vloženého sešitu grafu do souboru a propojení grafu s tímto externím sešitem.

Tento příklad vytvoří koláčový graf s výchozími daty a exportuje jeho sešit. Před přiřazením externího sešitu jako zdroje dat grafu uzavře výstupní proud a poté uloží propojenou prezentaci.

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

### **Nastavit externí sešit**

Pomocí metody [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) můžete přiřadit externí sešit grafu jako jeho zdroj dat. Tuto metodu lze také použít k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

I když nelze upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete takové sešity i nadále používat jako externí zdroj dat. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

Tento příklad používá externí sešit, jehož list s názvem `Sheet1` obsahuje název řady v B1, názvy kategorií v A2:A4 a číselné hodnoty v B2:B4. Příklad vytvoří koláčový graf, propojí sešit a použije [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) k mapování A1:B4 na jednu řadu a tři kategorie. Uloží prezentaci s propojeným grafem.

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

Parametr `update_chart_data` metody [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) řídí, zda se sešit načte.

* Když je `update_chart_data` `False`, aktualizuje se pouze cesta k sešitu. Data grafu nejsou načtena ani aktualizována z cílového sešitu, takže sešit může být nedostupný.
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

### **Získat cestu k externímu sešitu zdroje dat grafu**

Pro identifikaci sešitu propojeného s grafem zkontrolujte, zda graf používá externí zdroj dat, a získejte jeho cestu k sešitu.

Tento příklad prověří první tvar na první snímku prezentace s propojeným externím sešitem. Pokud je to graf propojený s externím sešitem, vypíše [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) do konzole. Poté uloží kopii prezentace.

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

### **Upravit data grafu**

Můžete upravit data v externích sešitech stejným způsobem, jako upravujete obsah v interních sešitech. Když není externí sešit načten, vyvolá se výjimka.

Tento příklad používá graf, který je první tvar na první snímku a je propojen s dostupným externím sešitem. Nastaví hodnotu první datové položky v první řadě na 100 a uloží aktualizovanou prezentaci. Úprava hodnot buněk může aktualizovat propojený externí soubor XLSX, proto použijte kopii, pokud potřebujete zachovat původní sešit.

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

### **Obnovit sešit z mezipaměti grafu**

Pokud graf používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může rekonstruovat sešit grafu z dat uložených v mezipaměti prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/), nakonfigurujte jeho [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/), a nastavte [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) na `True` před otevřením prezentace.

Následující ukázka v Pythonu obnoví data sešitu pro graf, který je první tvar na první snímku a odkazuje na nedostupný externí sešit. Přistupuje k obnoveným datům přes [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

Pokud je externí sešit nedostupný a obnovení je zakázáno, Aspose.Slides vyvolá výjimku. Povolení obnovy použijte jen tehdy, když je akceptovatelná náhrada pomocí kešovaných dat grafu, protože keš nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu zjistit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) a [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ujistit se, že je používán externí soubor.

**Jsou podporovány relativní cesty k externím sešitům a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. Prezentace uloží absolutní cestu v souboru PPTX, takže přesunutí sešitu může vyžadovat aktualizaci odkazu.

**Mohu použít sešity umístěné na síťových zdrojích/sdílených složkách?**

Ano, takové sešity lze použít jako externí zdroj dat. Úprava vzdálených sešitů přímo z Aspose.Slides však není podporována – mohou být použity jen jako zdroj.

**Přepisuje Aspose.Slides externí XLSX při ukládání prezentace?**

Prezentace ukládá [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Úprava dat grafu založených na buňkách může také aktualizovat propojený místní soubor XLSX. Použijte kopii sešitu, pokud originál musí zůstat nezměněn.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při vytváření odkazu. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) a odkazovat na tuto kopii.

**Může více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny ukazují na stejný soubor, aktualizace tohoto souboru se projeví ve všech grafech při dalším načtení dat.