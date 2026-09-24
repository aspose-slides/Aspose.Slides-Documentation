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
description: "Objevte Aspose.Slides pro Python via .NET: snadno spravujte sešity grafů v formátech PowerPoint a OpenDocument pro zjednodušení dat vaší prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s sešity grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu pomocí streamů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat ke kolekcím listů a specifikovat typ zdroje dat pro hodnoty grafu.

Také popisuje práci s externími sešity jako zdroji dat grafů. Příklady ukazují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

Pro buňky sešitu, které představují chybějící data, viz [Kontrola zobrazení prázdných buněk](/slides/cs/python-net/chart-series/) pro rozdíl mezi prázdnou buňkou a nulou a srovnání režimů zobrazení v čárovém grafu.

## **Čtení a zápis dat grafu ze sešitu**

Aspose.Slides poskytuje metody pro čtení a zápis sešitů dat grafu (které obsahují data grafu upravená pomocí Aspose.Cells). **Poznámka:** Data grafu musí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

Následující Python kód demonstruje ukázkovou operaci:

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

Když nahradíte vložený sešit upraveným, graf si zachová své původní sbírky sérií a kategorií. Tento nesoulad může způsobit, že [IChart.validate_chart_layout](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/ichart/validate_chart_layout/) selže s chybou indexu mimo rozsah. Vymažte existující série a kategorie před zápisem aktualizovaného sešitu zpět do grafu.

```python
# Po úpravě streamu sešitu (např. pomocí Aspose.Cells)
updated_workbook = chart_data.read_workbook_stream()

# Vymažte existující odkazy na data.
chart_data.series.clear()
chart_data.categories.clear()

updated_workbook.seek(0)
chart_data.write_workbook_stream(updated_workbook)

chart.validate_chart_layout()
```

Vymazání kolekcí zajistí, že struktura dat grafu bude konzistentní s novým sešitem, což umožní `validate_chart_layout` dokončit bez chyb.

## **Nastavení buňky sešitu jako popisku dat grafu**

Někdy potřebujete popisky grafu, které pocházejí přímo z buněk v podkladovém sešitu dat. Aspose.Slides umožňuje svázat popisky s konkrétními buňkami sešitu, aby text popisky vždy odrážel hodnotu buňky. Níže uvedený příklad ukazuje, jak aktivovat popisky z hodnoty buňky a nasměrovat vybrané popisky na vlastní buňky v sešitu grafu.

1. Vytvořte instanci třídy [Presentation](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle indexu.
1. Přidejte bublinový graf se vzorovými daty.
1. Přistupte k sérii grafu.
1. Použijte buňku sešitu jako popisek dat.
1. Uložte prezentaci.

Následující Python kód ukazuje, jak nastavit buňku sešitu jako popisek dat grafu:

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

Následující Python kód demonstruje, jak použít vlastnost `worksheets` pro přístup ke kolekci listů:

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

## **Určení typu zdroje dat**

Následující Python kód ukazuje, jak určit typ zdroje dat:

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

Aspose.Slides nepodporuje formát binárního sešitu Excel (.xlsb), který může být vložen v některých grafech. Můžete použít vlastnost `embedded_workbook_type` na [ChartData](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/) společně s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/workbooktype/) pro detekci nepodporovaných formátů a přeskočení těchto grafů.

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

        # Zde přečtěte nebo upravte data sešitu grafu.
```

## **Externí sešity**

Aspose.Slides podporuje použití externích sešitů jako zdrojů dat pro grafy.

### **Nastavení externích sešitů**

Pomocí metody [ChartData.set_external_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_external_workbook/) můžete přiřadit externí sešit grafu jako jeho zdroj dat. Tato metoda může také aktualizovat cestu k externímu sešitu, pokud byl přesunut.

Ačkoliv nelze upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete tyto sešity i nadále používat jako externí zdroje dat. Pokud zadáte relativní cestu k externímu sešitu, je automaticky převedena na úplnou cestu.

Následující Python kód ukazuje, jak nastavit externí sešit:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    # Předávejte False, aby se uložila pouze cesta: cílový sešit nemusí ještě existovat.
    chart.chart_data.set_external_workbook("external_workbook.xlsx", False)

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Parametr `update_chart_data` metody [set_external_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_external_workbook/) určuje, zda bude Excel sešit načten.

- Když je `update_chart_data` nastaven na `False`, aktualizuje se pouze cesta k sešitu; data grafu nejsou načtena ani aktualizována z cílového sešitu. Použijte toto nastavení, když cílový sešit neexistuje nebo není dostupný.
- Když je `update_chart_data` nastaven na `True` (výchozí), data grafu jsou načtena a aktualizována z cílového sešitu. Pokud se tento sešit nepodaří otevřít, je vyvolána výjimka se zprávou "External workbook is not available".

### **Vytvoření externích sešitů**

Pomocí metod [read_workbook_stream](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) a [set_external_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_external_workbook/) můžete buď vytvořit externí sešit od nuly, nebo převést interní sešit na externí.

Tento Python kód demonstruje proces vytvoření externího sešitu:

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

### **Získání cesty k externímu sešitu zdroje dat pro graf**

Někdy jsou data grafu propojena s externím Excel sešitem místo vložených dat prezentace. S Aspose.Slides můžete prozkoumat zdroj dat grafu a pokud je to externí sešit, přečíst úplnou cestu k sešitu.

1. Vytvořte instanci třídy [Presentation](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/).
1. Získejte odkaz na snímek podle jeho indexu.
1. Získejte odkaz na tvar grafu.
1. Získejte zdroj ([ChartDataSourceType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatasourcetype/)), který představuje zdroj dat grafu.
1. Zkontrolujte, zda typ zdroje odpovídá typu externího sešitu.

Následující Python kód demonstruje operaci:

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

Data v externích sešitech můžete upravovat stejným způsobem, jako v interních sešitech. Pokud nelze externí sešit načíst, je vyvolána výjimka.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Obnovení sešitu z mezipaměti grafu**

Pokud graf používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může rekonstruovat sešit grafu ze zprůměrovaných dat v prezentaci. Vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/), pak povolte [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/cs/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) přes [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/spreadsheet_options/) před otevřením prezentace.

Následující Python příklad otevírá prezentaci, jejíž graf odkazuje na nedostupný externí sešit, a přistupuje k obnoveným datům přes [Chart.chart_data](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/chart_data/) a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Zde přečtěte nebo upravte data obnoveného sešitu.
```

Pokud je externí sešit nedostupný a obnovení je zakázáno, Aspose.Slides vyvolá výjimku. Povolit obnovení použijte jen tehdy, když je akceptovatelný fallback s použitím cachovaných dat grafu, protože cache nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu určit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [typ zdroje dat](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/data_source_type/) a [cestu k externímu sešitu](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/external_workbook_path/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ujistit se, že je použito externí soubor.

**Jsou relativní cesty k externím sešitům podporovány a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, je automaticky převedena na absolutní cestu. To je výhodné pro přenositelnost projektu; však si uvědomte, že prezentace uloží absolutní cestu do souboru PPTX.

**Mohu používat sešity umístěné na síťových zdrojích/sdílených složkách?**

Ano, takové sešity mohou být použity jako externí zdroj dat. Úprava vzdálených sešitů přímo z Aspose.Slides není podporována – mohou být použity pouze jako zdroj.

**Přepisuje Aspose.Slides externí XLSX při ukládání prezentace?**

Pouze pokud jste upravili data grafu. Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/external_workbook_path/) a používá jej pro čtení dat, takže otevření a uložení prezentace ponechá sešit nedotčený. Nicméně hodnoty, které změníte přes data grafu (viz **Úprava dat grafu** výše), jsou při uložení prezentace zapsány zpět do externího sešitu – pracujte s kopií, pokud originál musí zůstat neporušený.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při linkování. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](/cells/python-net/)) a odkazovat na tuto kopii.

**Může více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny ukazují na stejný soubor, aktualizace tohoto souboru se projeví v každém grafu při dalším načtení dat.