---
title: Spravovat sešity grafů v prezentacích pomocí Pythonu
linktitle: Sešit grafu
type: docs
weight: 70
url: /cs/python-net/chart-workbook/
keywords:
- sešit grafu
- data grafu
- buňka sešitu
- popisek dat
- list
- zdroj dat
- externí sešit
- externí data
- mezipaměť grafu
- obnova sešitu
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Objevte Aspose.Slides pro Python via .NET: snadno spravujte sešity grafů v formátech PowerPoint a OpenDocument a zefektivněte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s sešity grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu prostřednictvím streamů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat ke kolekcím listů a specifikovat typ zdroje dat pro hodnoty grafu. Také se zabývá prací s externími sešity jako zdroji dat pro grafy. Příklady demonstrují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici. Pro buňky sešitu, které představují chybějící data, viz [Control the Display of Empty Cells](/slides/cs/python-net/chart-series/) pro rozdíl mezi prázdnou buňkou a nulou a pro srovnání režimů zobrazení dostupných v lineárním grafu.

## **Zahrnout data ze skrytých řádků a sloupců**

Použijte [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) k řízení, zda graf vykresluje data ze skrytých řádků a sloupců listu. Nastavte na `True`, aby se vykreslovaly pouze viditelné buňky, nebo na `False`, aby se zahrnovaly jak viditelné, tak skryté buňky. Toto nastavení řídí vykreslování grafu; neukrývá ani neodkrývá řádky ani sloupce listu.

Stáhněte [hidden-source-data.pptx](hidden-source-data.pptx) a umístěte jej do pracovního adresáře. Jeho první snímek obsahuje sloupcový graf jako první tvar. Vložený list, `Sheet1`, obsahuje následující zdrojový rozsah, `A1:C4`. Řádek 3 a sloupec C jsou skryté, ale jejich buňky stále obsahují hodnoty.

| Řádek listu | A: Měsíc | B: Maloobchod | C: Velkoobchod (skrytý sloupec) |
| --- | --- | --- | --- |
| 2 | Leden | 10 | 30 |
| 3 (skrytý řádek) | Únor | 40 | 60 |
| 4 | Březen | 20 | 50 |

Přistupujte ke zdrojovým buňkám přes [ChartData.chart_data_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) a čtěte [ChartDataCell.is_hidden](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatacell/is_hidden/) k prozkoumání jejich skrytého stavu. Tato vlastnost je jen pro čtení. V tomto souboru je B2 viditelná, B3 patří do skrytého řádku a C2 patří do skrytého sloupce; příklad vytiskne `False`, `True` a `True`.

Pro tento příklad obnovte data grafu po změně nastavení vykreslování: zachovejte vložený sešit pomocí [read_workbook_stream](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) a načtěte jej znovu pomocí [write_workbook_stream](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/write_workbook_stream/). Při zahrnutí všech buněk také použijte [set_range](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_range/) k obnovení kompletního rozsahu, včetně skryté kategorie únor. Pouhé změnění příznaku není dostačující k obnovení kešovaných dat grafu a popisků kategorií v tomto příkladu.

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

            # Obnovit data grafu z vloženého sešitu.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Obnovit kompletní zdrojový rozsah, včetně skrytých kategorií.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

Příklad uloží `hidden_cells_True.pptx` pouze s viditelnými hodnotami Maloobchodu (10 a 20) a `hidden_cells_False.pptx` se všemi šesti hodnotami. Obrázky níže byly vygenerovány ze uložených prezentací po jejich opětovném otevření; oba soubory zachovávají přiřazené nastavení vykreslování. Řádek 3 a sloupec C zůstávají skryté v obou vložených sešitech.

| Pouze viditelné buňky (`True`) | Všechny buňky (`False`) |
| --- | --- |
| ![Pouze viditelné buňky: Hodnoty maloobchodu 10 a 20 pro leden a březen.](hidden_cells_True.png) | ![Všechny buňky: Hodnoty maloobchodu a velkoobchodu pro leden, únor a březen.](hidden_cells_False.png) |

Skrytá buňka obsahující hodnotu se liší od prázdné buňky. [Chart.display_blanks_as](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/display_blanks_as/) řídí, jak jsou chybějící hodnoty zobrazovány; nezahrnuje ani nevynechává skrytá zdrojová data. Viz [Control the Display of Empty Cells](/slides/cs/python-net/chart-series/#control-the-display-of-empty-cells) pro příklad.

## **Čtení a zápis dat grafu ze sešitu**

Aspose.Slides pro Python via .NET poskytuje metody [read_workbook_stream](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) a [write_workbook_stream](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/write_workbook_stream/), které umožňují číst a zapisovat sešity dat grafů (obsahující data grafu upravená pomocí Aspose.Cells). **Poznámka**: data grafu musí být uspořádána stejným způsobem nebo musí mít strukturu podobnou zdroji.

Tento příklad otevře `chart.pptx`, který musí obsahovat graf jako první tvar na svém prvním snímku. Načte vložený sešit do streamu, vymaže existující řady a kategorie a zapíše zpět stejný sešit. Změny zůstávají v paměti; příklad neukládá prezentaci.

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

Když nahradíte vložený sešit upraveným, graf si zachová původní kolekce řad a kategorií. Tento nesoulad může způsobit, že [Chart.validate_chart_layout](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/validate_chart_layout/) selže s chybou index-out-of-range. Vymažte existující řady a kategorie před zápisem aktualizovaného sešitu zpět do grafu. Tento příklad vyžaduje `chart.pptx` s grafem jako první tvar na prvním snímku. Komentář označuje, kde by úprava sešitu proběhla; spustitelný příklad zapíše originální sešit zpět a ověří rozvržení v paměti.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Upravit stream sešitu zde, například pomocí Aspose.Cells.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

Vymazání kolekcí odstraní zastaralé odkazy na data před zápisem sešitu zpět. Před použitím grafu znovu vytvořte potřebné mapování řad a kategorií pro aktualizovaný sešit.

## **Nastavit buňku sešitu jako popisek dat grafu**

Můžete použít text z buněk sešitu jako popisky dat grafu. Následující kroky ukazují, jak propojit popisky v bublinovém grafu s buňkami v jeho datovém sešitu.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte první snímek pomocí jeho nulového indexu.
3. Přidejte bublinový graf s výchozími daty.
4. Přistupte k řadám grafu.
5. Nastavte buňku sešitu jako popisek dat.
6. Uložte prezentaci.

Tento příklad otevře `chart2.pptx`, který musí obsahovat alespoň jeden snímek, a přidá bublinový graf s výchozími daty. Používá buňky A10:A12 na listu 0 pro první tři popisky v první řadě, povolí popisky z buněk a uloží výsledek do `resultchart.pptx`.

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

## **Spravovat listy**

Vlastnost [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) poskytuje přístup k listům v sešitu grafu. Tento příklad vytvoří koláčový graf s výchozími daty a vytiskne název každého listu do konzole.

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

## **Zadat typ zdroje dat**

Tento příklad vytvoří 3D sloupcový graf s výchozími daty a nastaví dva názvy řad pomocí různých zdrojů dat. První název používá doslovný řetězec; druhý používá buňku C1 na listu 0. Výčtová hodnota [DataSourceType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/datasourcetype/) volí zdroj pro každý název. Výsledek je uložen do `pres.pptx`.

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

## **Detekovat nepodporované formáty vložených sešitů**

Aspose.Slides nepodporuje binární formát Excel sešitu (.xlsb), který může být vložen v některých grafech. Můžete použít vlastnost [embedded_workbook_type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) na [ChartData](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/workbooktype/) k detekci nepodporovaných formátů a vynechání těchto grafů. Tento příklad prozkoumá tvary na prvním snímku `sample.pptx`, vynechá tvary, které nejsou grafy, a vytiskne diagnostickou zprávu pro každý graf s vloženým sešitem .xlsb.

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

        # Přečíst nebo upravit podporovaná data sešitu grafu zde.
```

## **Externí sešit**

Aspose.Slides podporuje použití externích sešitů jako zdroje dat pro grafy.

### **Vytvořit externí sešit**

Použijte [read_workbook_stream](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) a [set_external_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_external_workbook/), abyste exportovali vložený sešit grafu do souboru a propojili graf s tímto externím sešitem.

Tento příklad vytvoří koláčový graf s výchozími daty, zapíše jeho sešit do `externalWorkbook1.xlsx` a zavře výstupní stream před přiřazením souboru jako zdroj dat grafu. Uloží propojenou prezentaci do `externalWorkbook.pptx`.

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

Pomocí metody [set_external_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_external_workbook/) můžete přiřadit externí sešit grafu jako jeho zdroj dat. Tato metoda může být také použita k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

I když nemůžete upravovat data v sešitech uložených na vzdálených místech nebo prostředcích, můžete takové sešity stále použít jako externí zdroj dat. Pokud je zadána relativní cesta k externímu sešitu, je automaticky převedena na úplnou cestu.

Tento příklad vyžaduje `externalWorkbook.xlsx` v pracovním adresáři. Jeho list s názvem `Sheet1` musí obsahovat název řady v B1, názvy kategorií v A2:A4 a číselné hodnoty v B2:B4. Příklad vytvoří koláčový graf, propojí sešit a použije [set_range](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_range/) k mapování A1:B4 na jednu řadu a tři kategorie. Uloží výsledek do `Presentation_with_externalWorkbook.pptx`.

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

Parametr `update_chart_data` metody [set_external_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_external_workbook/) řídí, zda je sešit načten.

* Když je `update_chart_data` nastaven na `False`, aktualizuje se pouze cesta k sešitu. Data grafu nejsou načtena ani aktualizována ze cílového sešitu, takže sešit může být nedostupný.
* Když je `update_chart_data` nastaven na `True`, data grafu jsou aktualizována ze cílového sešitu.

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

### **Získat cestu ke zdrojovému externímu sešitu grafu**

Pro identifikaci sešitu propojeného s grafem nejprve zkontrolujte, zda graf používá externí zdroj dat. Pokud ano, můžete získat cestu k sešitu následujícími kroky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
2. Získejte první snímek pomocí jeho nulového indexu.
3. Zkontrolujte, že první tvar je graf.
4. Přečtěte typ zdroje dat grafu.
5. Pokud je zdroj externí sešit, přečtěte jeho cestu.

Tento příklad otevře `externalWorkbook.pptx`, vytvořený v předchozím příkladu, a prozkoumá první tvar na prvním snímku. Pokud je to graf propojený s externím sešitem, příklad vytiskne [external_workbook_path](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/external_workbook_path/) do konzole. Pak uloží kopii prezentace do `Result.pptx`.

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

Můžete upravovat data v externích sešitech stejným způsobem, jako provádíte změny v obsahu interních sešitů. Když externí sešit nelze načíst, je vyvolána výjimka.

Tento příklad vyžaduje `presentation.pptx` s grafem jako prvním tvarem na prvním snímku a přístupný externí sešit. Nastaví hodnotu podporovanou buňkou prvního datového bodu v první řadě na 100 a uloží prezentaci do `presentation_out.pptx`. Úprava hodnot buněk může aktualizovat propojený externí soubor XLSX, proto použijte kopii, pokud potřebujete zachovat originální sešit.

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

Pokud graf používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může rekonstruovat sešit grafu z dat uložených v mezipaměti prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/), nastavte jeho [spreadsheet_options](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/spreadsheet_options/), a nastavte [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/cs/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) na `True` před otevřením prezentace.

Následující Python příklad otevře `presentation.pptx`, jehož první tvar na prvním snímku musí být graf odkazující na nedostupný externí sešit, a přistoupí k obnoveným datům přes [Chart.chart_data](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/chart_data/) a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

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

        # Přečíst nebo upravit obnovená data sešitu zde.
    else:
        print("The first shape is not a chart.")
```

Pokud je externí sešit nedostupný a obnova je vypnuta, Aspose.Slides vyvolá výjimku. Povolit obnovu pouze v případě, že použití dat z mezipaměti grafu je přijatelnou náhradou, protože mezipaměť nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **FAQ**

**Mohu zjistit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [data source type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/data_source_type/) a [cestu k externímu sešitu](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/external_workbook_path/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ujistit se, že je používán externí soubor.

**Podporují se relativní cesty k externím sešitům a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, je automaticky převedena na absolutní cestu. Prezentace ukládá absolutní cestu v souboru PPTX, takže při přesunu sešitu může být nutné aktualizovat odkaz.

**Mohu použít sešity umístěné na síťových zdrojích/sdílených složkách?**

Ano, takové sešity mohou být použity jako externí zdroj dat. Nicméně úprava vzdálených sešitů přímo z Aspose.Slides není podporována – mohou být použity pouze jako zdroj.

**Přepisuje Aspose.Slides externí XLSX při ukládání prezentace?**

Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Úprava buněk podporovaných dat grafu může také aktualizovat propojený lokální soubor XLSX. Použijte kopii sešitu, pokud musí originál zůstat nezměněn.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při propojování. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) a odkazovat na tuto kopii.

**Může více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny ukazují na stejný soubor, aktualizace tohoto souboru se projeví v každém grafu při dalším načtení dat.