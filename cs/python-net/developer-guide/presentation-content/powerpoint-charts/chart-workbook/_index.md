---
title: Spravovat pracovní knihy grafů v prezentacích pomocí Pythonu
linktitle: Pracovní kniha grafu
type: docs
weight: 70
url: /cs/python-net/chart-workbook/
keywords:
- pracovní kniha grafu
- data grafu
- buňka pracovní knihy
- popisek dat
- list
- datový zdroj
- externí pracovní kniha
- externí data
- mezipaměť grafu
- obnovení pracovní knihy
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Objevte Aspose.Slides pro Python prostřednictvím .NET: snadno spravujte pracovní knihy grafů v PowerPoint a OpenDocument formátech a zjednodušte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s pracovými knihami grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu pomocí streamů pracovních knih, používat buňky pracovní knihy jako popisky dat grafu, přistupovat k kolekcím listů a specifikovat typ datového zdroje pro hodnoty grafu.

Také se zabývá používáním externích pracovních knih jako zdrojů dat pro grafy. Příklady demonstrují, jak vytvořit a přiřadit externí pracovní knihu, získat cestu k externí pracovní knize propojené s grafem a upravit data grafu, když je pracovní kniha dostupná.

## **Čtení a zápis dat grafu z pracovní knihy**

Aspose.Slides poskytuje metody pro čtení a zápis pracovních knih s daty grafu (které obsahují data grafu upravená pomocí Aspose.Cells). **Poznámka:** Data grafu musí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

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

## **Nastavení buňky pracovního listu jako popisku dat grafu**

Někdy potřebujete popisky grafu, které pocházejí přímo z buněk v podkladové pracovní knize. Aspose.Slides vám umožňuje svázat popisky dat s konkrétními buňkami pracovní knihy, aby text popisku vždy odrážel hodnotu buňky. Následující příklad ukazuje, jak povolit popisky s hodnotou z buňky a nasměrovat vybrané popisky na vlastní buňky v pracovní knize grafu.

1. Vytvořte instanci třídy [Presentation](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/) .
2. Získejte odkaz na snímek podle indexu.
3. Přidejte bublinový graf s ukázkovými daty.
4. Přistupte k sériím grafu.
5. Použijte buňku pracovního listu jako popisek dat.
6. Uložte prezentaci.

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

Následující Python kód ukazuje, jak použít vlastnost `worksheets` k přístupu ke kolekci listů:

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

## **Zadání typu datového zdroje**

Následující Python kód ukazuje, jak zadat typ datového zdroje:

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

## **Detekce nepodporovaných formátů vložených pracovních knih**

Aspose.Slides nepodporuje binární formát Excel pracovní knihy (.xlsb), který může být vložen do některých grafů. Můžete použít vlastnost `embedded_workbook_type` na [ChartData](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/workbooktype/) k detekci nepodporovaných formátů a přeskočení těchto grafů.

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
            # Vložená pracovní kniha je ve formátu .xlsb, který není podporován.
            continue

        # Přečtěte nebo upravte data pracovní knihy grafu zde.
```

## **Externí pracovní knihy**

Aspose.Slides podporuje používání externích pracovních knih jako zdroje dat pro grafy.

### **Nastavení externích pracovních knih**

Pomocí metody [ChartData.set_external_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_external_workbook/) můžete přiřadit externí pracovní knihu ke grafu jako jeho zdroj dat. Tato metoda může také aktualizovat cestu k externí pracovní knize, pokud byla přesunuta.

Ačkoliv nemůžete upravovat data v pracovních knihách uložených na vzdálených místech nebo zdrojích, můžete i tak tyto pracovní knihy použít jako externí zdroje dat. Pokud zadáte relativní cestu k externí pracovní knize, je automaticky převedena na úplnou cestu.

Následující Python kód ukazuje, jak nastavit externí pracovní knihu:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Parametr `update_chart_data` metody [set_external_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_external_workbook/) určuje, zda bude Excelová pracovní kniha načtena.

- Když je `update_chart_data` nastaven na `False`, aktualizuje se pouze cesta k pracovní knize; data grafu nejsou načtena ani obnovená z cílové pracovní knihy. Použijte toto nastavení, když cílová pracovní kniha neexistuje nebo není dostupná.
- Když je `update_chart_data` nastaven na `True`, data grafu jsou načtena a aktualizována z cílové pracovní knihy.

### **Vytvoření externích pracovních knih**

Pomocí metod [read_workbook_stream](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) a [set_external_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_external_workbook/) můžete buď vytvořit externí pracovní knihu od nuly, nebo převést interní pracovní knihu na externí.

Tento Python kód demonstruje proces vytvoření externí pracovní knihy:

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

### **Získání cesty k externí pracovní knize datového zdroje pro graf**

Někdy jsou data grafu propojena s externí Excelovou pracovní knihou místo vložených dat v prezentaci. S Aspose.Slides můžete prozkoumat datový zdroj grafu a pokud jde o externí pracovní knihu, přečíst celou cestu k ní.

1. Vytvořte instanci třídy [Presentation](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/) .
2. Získejte odkaz na snímek podle jeho indexu.
3. Získejte odkaz na tvar grafu.
4. Získáte zdroj ([ChartDataSourceType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatasourcetype/)), který představuje datový zdroj grafu.
5. Zkontrolujte, zda typ zdroje odpovídá typu datového zdroje externí pracovní knihy.

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

Můžete upravovat data v externích pracovních knihách stejným způsobem jako v interních pracovních knihách. Pokud není externí pracovní kniha načtena, je vyvolána výjimka.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

### **Obnovení pracovní knihy z mezipaměti grafu**

Pokud graf používá externí pracovní knihu, která chybí nebo není dostupná, Aspose.Slides může rekonstruovat pracovní knihu grafu z dat uložených v mezipaměti prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/), poté povolte [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/cs/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) prostřednictvím [LoadOptions.spreadsheet_options](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/spreadsheet_options/) před otevřením prezentace.

Následující Python příklad otevře prezentaci, jejíž graf odkazuje na nedostupnou externí pracovní knihu, a přistupuje k obnoveným datům prostřednictvím [Chart.chart_data](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chart/chart_data/) a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/chart_data_workbook/):

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    chart = presentation.slides[0].shapes[0]
    recovered_workbook = chart.chart_data.chart_data_workbook

    # Přečtěte nebo upravte data obnovené pracovní knihy zde.
```

Pokud je externí pracovní kniha nedostupná a obnovení je vypnuto, Aspose.Slides vyvolá výjimku. Povolit obnovení jen tehdy, když je použití dat z mezipaměti grafu přijatelnou alternativou, protože mezipaměť nemusí obsahovat změny provedené v externí pracovní knize po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu zjistit, zda je konkrétní graf propojen s externí nebo vloženou pracovní knihou?**

Ano. Graf má [typ datového zdroje](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/data_source_type/) a [cestu k externí pracovní knize](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/external_workbook_path/); pokud je zdroj externí pracovní kniha, můžete přečíst celou cestu a ujistit se, že je používán externí soubor.

**Jsou podporovány relativní cesty k externím pracovním knihám a jak jsou ukládány?**

Ano. Pokud zadáte relativní cestu, je automaticky převedena na absolutní cestu. To je výhodné pro přenositelnost projektu; však si uvědomte, že prezentace uloží absolutní cestu v souboru PPTX.

**Mohu používat pracovní knihy umístěné na síťových zdrojích/sdílených složkách?**

Ano, takové pracovní knihy lze použít jako externí zdroj dat. Úprava vzdálených pracovních knih přímo z Aspose.Slides však není podporována – lze je použít jen jako zdroj.

**Přepisuje Aspose.Slides externí XLSX při ukládání prezentace?**

Ne. Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/external_workbook_path/) a používá jej pro čtení dat. Externí soubor samotný není při uložení prezentace upravován.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides při propojení heslo nepřijímá. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](/cells/python-net/)) a odkazovat na tuto kopii.

**Může více grafů odkazovat na stejnou externí pracovní knihu?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny ukazují na stejný soubor, aktualizace tohoto souboru se projeví v každém grafu při dalším načtení dat.