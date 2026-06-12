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
- datový zdroj
- externí sešit
- externí data
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Objevte Aspose.Slides pro Python prostřednictvím .NET: snadno spravujte sešity grafů ve formátech PowerPoint a OpenDocument a zjednodušte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s sešity grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu prostřednictvím streamů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat k kolekcím listů a určovat typ datového zdroje pro hodnoty grafu.

Také se zabývá používáním externích sešitů jako datových zdrojů pro grafy. Příklady ukazují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

## **Čtení a zápis dat grafu ze sešitu**

Aspose.Slides poskytuje metody pro čtení a zápis sešitů s daty grafu (které obsahují data grafu upravená pomocí Aspose.Cells). **Poznámka:** Data grafu musí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

Následující kód v Pythonu demonstruje ukázkovou operaci:

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

## **Nastavení buňky sešitu jako popisku dat grafu**

Někdy potřebujete popisky grafu, které pocházejí přímo z buněk v podkladovém sešitu s daty. Aspose.Slides vám umožňuje svázat popisky dat s konkrétními buňkami sešitu, aby text popisku vždy odrážel hodnotu buňky. Níže uvedený příklad ukazuje, jak povolit popisky získané z buňky a nasměrovat vybrané popisky na vlastní buňky v sešitu grafu.

1. Vytvořte instanci třídy [Presentation](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle indexu.
3. Přidejte bublinový graf se vzorovými daty.
4. Přistupte k sériím grafu.
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

## **Určení typu datového zdroje**

Následující kód v Pythonu ukazuje, jak určit typ datového zdroje:

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

Aspose.Slides nepodporuje binární formát Excelu (.xlsb), který může být vložen v některých grafech. Můžete použít vlastnost `embedded_workbook_type` na [ChartData](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/workbooktype/), abyste detekovali nepodporované formáty a tyto grafy přeskočili.

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

Aspose.Slides podporuje použití externích sešitů jako datového zdroje pro grafy.

### **Nastavení externích sešitů**

Pomocí metody [ChartData.set_external_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_external_workbook/) můžete přiřadit externí sešit k grafu jako jeho datový zdroj. Tato metoda může také aktualizovat cestu k externímu sešitu, pokud byl přesunut.

Ačkoliv nemůžete upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete tyto sešity nadále používat jako externí datové zdroje. Pokud zadáte relativní cestu k externímu sešitu, je automaticky převedena na úplnou cestu.

Následující kód v Pythonu ukazuje, jak nastavit externí sešit:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, False)
    chart.chart_data.set_external_workbook("external_workbook.xlsx")

    presentation.save("chart_with_external_workbook.pptx", slides.export.SaveFormat.PPTX)
```

Parametr `update_chart_data` metody [set_external_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_external_workbook/) určuje, zda bude Excelový sešit načten.

- Když je `update_chart_data` nastaven na `False`, aktualizuje se pouze cesta k sešitu; data grafu nejsou načtena ani obnovena z cílového sešitu. Použijte toto nastavení, pokud cílový sešit neexistuje nebo není dostupný.
- Když je `update_chart_data` nastaven na `True`, data grafu jsou načtena a aktualizována z cílového sešitu.

### **Vytvoření externích sešitů**

Pomocí metod [read_workbook_stream](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) a [set_external_workbook](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/set_external_workbook/) můžete buď vytvořit externí sešit od nuly, nebo převést interní sešit na externí.

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

### **Získání cesty k externímu datovému sešitu pro graf**

Někdy jsou data grafu propojena s externím Excelovým sešitem místo vložených dat v prezentaci. S Aspose.Slides můžete prozkoumat datový zdroj grafu a pokud jde o externí sešit, přečíst úplnou cestu k sešitu.

1. Vytvořte instanci třídy [Presentation](https://docs.aspose.com/slides/cs/python-net/api-reference/aspose.slides/presentation/).
2. Získejte odkaz na snímek podle jeho indexu.
3. Získejte odkaz na tvar grafu.
4. Získejte zdroj ([ChartDataSourceType](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdatasourcetype/)), který představuje datový zdroj grafu.
5. Zkontrolujte, zda typ zdroje odpovídá typu externího sešitu jako datového zdroje.

Následující kód v Pythonu demonstruje operaci:

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

Data v externích sešitech můžete upravovat stejným způsobem, jako upravujete data v interních sešitech. Pokud nelze externí sešit načíst, vyvolá se výjimka.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.chart_data.series[0].data_points[0].value.as_cell.value = 100
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Mohu zjistit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [typ datového zdroje](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/data_source_type/) a [cestu k externímu sešitu](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/external_workbook_path/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ověřit, že je používán externí soubor.

**Jsou relativní cesty k externím sešitům podporovány a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, je automaticky převedena na absolutní cestu. To je výhodné pro přenositelnost projektu; však mějte na paměti, že prezentace uloží absolutní cestu do souboru PPTX.

**Mohu použít sešity umístěné na síťových zdrojích/sdílených složkách?**

Ano, takové sešity lze použít jako externí datový zdroj. Úprava vzdálených sešitů přímo z Aspose.Slides však není podporována – mohou být použity pouze jako zdroj.

**Přepisuje Aspose.Slides externí XLSX při ukládání prezentace?**

Ne. Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/cs/python-net/aspose.slides.charts/chartdata/external_workbook_path/) a používá jej k načítání dat. Samotný externí soubor není při ukládání prezentace upravován.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při vytváření odkazu. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](/cells/python-net/)) a odkazovat na tuto kopii.

**Může více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny ukazují na stejný soubor, aktualizace tohoto souboru se projeví v každém grafu při dalším načtení dat.