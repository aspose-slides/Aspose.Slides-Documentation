---
title: Správa sešitů grafů v prezentacích pomocí Pythonu
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
- obnovení sešitu
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Objevte Aspose.Slides pro Python přes .NET: snadno spravujte sešity grafů ve formátech PowerPoint a OpenDocument a zjednodušte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s sešity grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu přes streamy sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat ke kolekcím listů a specifikovat typ zdroje dat pro hodnoty grafu.

Také se zabývá používáním externích sešitů jako zdrojů dat pro grafy. Příklady demonstrují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

## **Čtení a zápis dat grafu ze sešitu**

Aspose.Slides poskytuje metody pro čtení a zápis sešitů dat grafu (které obsahují data grafu upravená pomocí Aspose.Cells). **Poznámka:** Data grafu musí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

Následující kód v Pythonu ukazuje ukázkovou operaci:

```py
import aspose.slides as slides

with slides.Presentation("chart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]

    data_stream = chart.chart_data.read_workbook_stream()

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    data_stream.seek(0)
    chart.chart_data.write_workbook_stream(data_stream)
```

### **Ověření rozvržení grafu po úpravě sešitu**

Když nahradíte vložený sešit upraveným, graf si zachová své původní kolekce řad a kategorií. Tento nesoulad může způsobit, že [IChart.validate_chart_layout](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichart/validate_chart_layout/) selže s chybou index-out-of-range. Vymažte existující řady a kategorie před zápisem aktualizovaného sešitu zpět do grafu.

```python
# Po úpravě proudu sešitu (např. pomocí Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Vymazat existující odkazy na data.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Vymazání kolekcí zajistí, že struktura dat grafu bude konzistentní s novým sešitem, což umožní `validate_chart_layout` dokončit bez chyb.

## **Nastavení buňky sešitu jako popisku dat grafu**

Někdy potřebujete popisky grafu, které pocházejí přímo z buněk v podkladovém sešitu. Aspose.Slides vám umožňuje svázat popisky s konkrétními buňkami sešitu, takže text popisky vždy odráží hodnotu buňky. Níže uvedený příklad ukazuje, jak povolit popisky s hodnotou z buňky a nasměrovat vybrané popisky na vlastní buňky v sešitu grafu.

1. Vytvořte instanci třídy [Presentation](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle indexu.
3. Přidejte bublinový graf s ukázkovými daty.
4. Přistupte k řadám grafu.
5. Použijte buňku sešitu jako popisek dat.
6. Uložte prezentaci.

Následující kód v Pythonu ukazuje, jak nastavit buňku sešitu jako popisek dat grafu:

```py
import aspose.slides as slides
import aspose.slides.charts as charts

# Vytvořte instanci třídy Presentation, která představuje soubor prezentace.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)

    series = chart.chart_data.series[0]

    series.labels.default_data_label_format.show_label_value_from_cell = True

    workbook = chart.chart_data.chart_data_workbook

    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2")

    presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Správa listů**

Následující kód v Pythonu demonstruje, jak použít vlastnost `worksheets` k přístupu ke kolekci listů:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)

    workbook = chart.chart_data.chart_data_workbook
    for i in range(len(workbook.worksheets)):
        print(workbook.worksheets[i].name)
```

## **Specifikace typu zdroje dat**

Následující kód v Pythonu ukazuje, jak specifikovat typ zdroje dat:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)

    series_name = chart.chart_data.series[0].name
    series_name.data_source_type = slides.charts.DataSourceType.STRING_LITERALS
    series_name.data = "LiteralString"

    series_name = chart.chart_data.series[1].name
    series_name.data = chart.chart_data.chart_data_workbook.get_cell(0, "B1", "NewCell")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Detekce nepodporovaných formátů vložených sešitů**

Aspose.Slides nepodporuje binární formát Excel sešitu (.xlsb), který může být vložen v některých grafech. Můžete použít vlastnost `embedded_workbook_type` na [ChartData](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/workbooktype/) k detekci nepodporovaných formátů a přeskočení těchto grafů.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart = shape
        chart_data = chart.chart_data

        if (chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK and
                chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO):
            # Vložený sešit je ve formátu .xlsb, který není podporován.
            continue

        # Zde načtěte nebo upravte data sešitu grafu.
```

## **Externí sešity**

Aspose.Slides podporuje používání externích sešitů jako zdroje dat pro grafy.

### **Nastavení externích sešitů**

Pomocí metody [ChartData.set_external_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_external_workbook/) můžete přiřadit externí sešit grafu jako jeho zdroj dat. Tato metoda může také aktualizovat cestu k externímu sešitu, pokud byl přesunut.

I když nemůžete upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete tyto sešity stále používat jako externí zdroje dat. Pokud zadáte relativní cestu k externímu sešitu, automaticky se převede na úplnou cestu.

Následující kód v Pythonu ukazuje, jak nastavit externí sešit:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Předávejte False, aby se uložila pouze cesta: cílový sešit ještě nemusí existovat.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Parametr `update_chart_data` metody [set_external_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_external_workbook/) určuje, zda bude Excel sešit načten.

- Když je `update_chart_data` nastaven na `False`, aktualizuje se pouze cesta k sešitu; data grafu nejsou načtena ani obnovena ze cílového sešitu. Toto nastavení použijte, když cílový sešit neexistuje nebo není dostupný.
- Když je `update_chart_data` nastaven na `True` (výchozí), data grafu jsou načtena a aktualizována ze cílového sešitu. Pokud se tento sešit nepřeruší, vyvolá se výjimka s hlášením „External workbook is not available“.

### **Vytvoření externích sešitů**

Pomocí metod [read_workbook_stream](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) a [set_external_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_external_workbook/) můžete buď vytvořit externí sešit od začátku, nebo převést interní sešit na externí.

Tento kód v Pythonu demonstruje proces vytváření externího sešitu:

```python
import pathlib
import aspose.slides as slides
import aspose.slides.charts as charts

workbook_path = "external_workbook.xlsx"

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)

    workbook_data = chart.chart_data.read_workbook_stream().read()

    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    full_path = str(pathlib.Path(workbook_path).resolve())
    chart.chart_data.set_external_workbook(full_path)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Získání cesty k externímu zdroji sešitu pro graf**

Někdy jsou data grafu propojena s externím Excel sešitem místo vložených dat prezentace. S Aspose.Slides můžete prozkoumat zdroj dat grafu a pokud se jedná o externí sešit, přečíst úplnou cestu k sešitu.

1. Vytvořte instanci třídy [Presentation](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Získejte odkaz na tvar grafu.
4. Získejte zdroj ([ChartDataSourceType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatasourcetype/)), který představuje zdroj dat grafu.
5. Zkontrolujte, zda typ zdroje odpovídá typu externího sešitu.

Následující kód v Pythonu demonstruje tuto operaci:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart_with_external_workbook.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    source_type = chart.chart_data.data_source_type
    if source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
        print(chart.chart_data.external_workbook_path)
```

### **Úprava dat grafu**

Data v externích sešitech můžete upravovat stejným způsobem jako v interních sešitech. Pokud se externí sešit nepodaří načíst, vyvolá se výjimka.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Obnovení sešitu z mezipaměti grafu**

Pokud graf používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může rekonstruovat sešit grafu z dat uložených v prezentaci. Vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/), poté povolte [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/cs/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) přes [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/spreadsheet_options/) před otevřením prezentace.

Následující příklad v Pythonu otevírá prezentaci, jejíž graf odkazuje na nedostupný externí sešit, a přistupuje k obnoveným datům přes [Chart.chart_data](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/chart_data/) a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Zde načtěte nebo upravte obnovená data sešitu.
```

Pokud je externí sešit nedostupný a obnovení je zakázáno, Aspose.Slides vyvolá výjimku. Povolit obnovení by se mělo pouze tehdy, když je použití dat z mezipaměti akceptovatelnou náhradou, protože mezipaměť nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu určit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [data source type](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/data_source_type/) a [cestu k externímu sešitu](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/external_workbook_path/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ujistit se, že je používán externí soubor.

**Podporují se relativní cesty k externím sešitům a jak jsou ukládány?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. To je výhodné pro přenositelnost projektu; mějte však na paměti, že prezentace uloží absolutní cestu v souboru PPTX.

**Mohu použít sešity umístěné na síťových zdrojích/úložištích?**

Ano, takové sešity lze použít jako externí zdroj dat. Úprava vzdálených sešitů přímo z Aspose.Slides však není podporována – mohou být použity pouze jako zdroj.

**Přepíše Aspose.Slides externí XLSX při ukládání prezentace?**

Pouze pokud jste upravili data grafu. Prezentace ukládá [link to the external file](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/external_workbook_path/) a používá jej pro čtení dat, takže otevření a uložení prezentace nechá sešit nedotčený. Hodnoty, které změníte přes data grafu (viz [Edit Chart Data](#edit-chart-data) výše), jsou však při uložení prezentace zapsány zpět do externího sešitu – pracujte s kopií, pokud musí originál zůstat nezměněn.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při propojení. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](/cells/python-net/)) a odkazovat na tuto kopii.

**Mohou více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny ukazují na stejný soubor, aktualizace tohoto souboru se projeví v každém grafu při dalším načtení dat.