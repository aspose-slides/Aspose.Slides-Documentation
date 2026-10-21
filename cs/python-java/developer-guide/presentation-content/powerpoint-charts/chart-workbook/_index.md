---
title: Správa sešitů grafů v prezentacích pomocí Pythonu přes Java
linktitle: Sešit grafu
type: docs
weight: 70
url: /cs/python-java/chart-workbook/
keywords:
- sešit grafu
- data grafu
- buňka sešitu
- popisek dat
- list
- zdroj dat
- externí sešit
- externí data
- keš grafu
- obnovení sešitu
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Objevíte Aspose.Slides pro Python přes Java: snadno spravujte sešity grafů v formátech PowerPoint a OpenDocument a zefektivněte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s grafickými sešity v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu prostřednictvím proudů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat ke kolekcím listů a určit typ zdroje dat pro hodnoty grafu.

Také se zabývá používáním externích sešitů jako zdrojů dat pro grafy. Příklady demonstrují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

Pro buňky sešitu, které představují chybějící data, viz [Control the Display of Empty Cells](/slides/cs/python-java/chart-series/) pro rozdíl mezi prázdnou buňkou a nulou a srovnání režimů zobrazení u čárových grafů.

## **Zahrnout data z skrytých řádků a sloupců**

Použijte [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) k ovládání, zda graf vykresluje data ze skrytých řádků a sloupců listu. Nastavte jej na `True`, chcete-li vykreslovat jen viditelné buňky, nebo na `False`, chcete-li zahrnout jak viditelné, tak skryté buňky. Toto nastavení řídí vykreslování grafu; neskrývá ani nezobrazí řádky či sloupce listu.

[Ukázková prezentace](hidden-source-data.pptx) obsahuje sloupcový graf jako první objekt na první snímku. Vložený list `Sheet1` obsahuje zdrojový rozsah `A1:C4`. Řádek 3 a sloupec C jsou skryté, ale jejich buňky stále obsahují hodnoty.

| Řádek listu | A: Měsíc | B: Maloobchod | C: Velkoobchod (skrytý sloupec) |
| --- | --- | --- | --- |
| 2 | Leden | 10 | 30 |
| 3 (skrytý řádek) | Únor | 40 | 60 |
| 4 | Březen | 20 | 50 |

Přistupujte ke zdrojovým buňkám pomocí [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) a čtěte [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) k inspekci jejich skrytého stavu. Tato metoda vrací stav skrytí, aniž by jej měnila. V tomto souboru je B2 viditelná, B3 patří ke skrytému řádku a C2 ke skrytému sloupci; příklad vypíše `False`, `True` a `True`.

Pro tento příklad po změně nastavení vykreslování obnovte data grafu: ponechte vložený sešit pomocí [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) a načtěte jej znovu pomocí [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream). Při zahrnutí všech buněk použijte také [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) k obnovení úplného rozsahu včetně skrytého únorového kategorie. Pouze změna příznaku nestačí k obnovení keše dat a popisků kategorií v této ukázce.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("hidden-source-data.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        workbook = chart.getChartData().getChartDataWorkbook()
        print("B2 hidden:", workbook.getCell(0, "B2").isHidden())
        print("B3 hidden:", workbook.getCell(0, "B3").isHidden())
        print("C2 hidden:", workbook.getCell(0, "C2").isHidden())

        workbook_data = chart.getChartData().readWorkbookStream()
        for visible_only in (True, False):
            chart.setPlotVisibleCellsOnly(visible_only)

            # Obnoví data grafu z vloženého sešitu.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Obnoví celý zdrojový rozsah, včetně skrytých kategorií.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Příklad uloží dvě verze prezentace: jednu pouze s viditelnými hodnotami maloobchodu (10 a 20) a druhou se všemi šesti hodnotami. Obrázky níže ilustrují oba režimy vykreslování. Řádek 3 a sloupec C zůstávají skryté v obou vložených sešitech.

| Pouze viditelné buňky (`True`) | Všechny buňky (`False`) |
| --- | --- |
| ![Pouze viditelné buňky: hodnoty maloobchodu 10 a 20 pro leden a březen.](hidden_cells_True.png) | ![Všechny buňky: hodnoty maloobchodu a velkoobchodu pro leden, únor a březen.](hidden_cells_False.png) |

Skrytá buňka obsahující hodnotu se liší od prázdné buňky. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) řídí, jak jsou zobrazovány chybějící hodnoty; neovlivňuje zahrnutí nebo vyloučení skrytých zdrojových dat. Viz [Control the Display of Empty Cells](/slides/cs/python-java/chart-series/#control-the-display-of-empty-cells) pro příklad.

## **Získat rozsah dat grafu**

Před aktualizací dat sešitu v existující prezentaci zkontrolujte zdrojové rozsahy, abyste zjistili, které buňky listu každý graf používá. Metoda [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) vrací aktuální datový rozsah jako vzorec kvalifikovaný listem, např. `Sheet1!$A$1:$D$5`. Zde je `Sheet1` název listu, `!` jej odděluje od rozsahu buněk a `$A$1:$D$5` určuje buňky A1 až D5 včetně. Znaky `$` označují absolutní odkazy na řádky a sloupce.

Metoda čte aktuální rozsah, aniž by měnila graf či jeho sešit. Pokud graf nepoužívá sešit jako zdroj dat, vyvolá výjimku `InvalidOperationException`. Další informace najdete v [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

Tento příklad otevře prezentaci a přímo na každém snímku prověří objekty, zda jsou grafy. Vypíše název každého grafu a jeho zdrojový rozsah. Pokud graf nevyužívá sešit, vypíše zprávu a pokračuje dalším grafem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **Číst a zapisovat data grafu ze sešitu**

Aspose.Slides for Python via Java poskytuje metody [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) a [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream), které umožňují číst a zapisovat sešity dat grafu (obsahující data grafu upravená pomocí Aspose.Cells). **Poznámka**: data grafu musejí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

Příklad používá prezentaci s grafem jako první objekt na první snímku. Načte vložený sešit do pole bajtů, vymaže existující řady a kategorie a zapíše stejný sešit zpět. Změny zůstanou v paměti; příklad neukládá prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Ověřit rozvržení grafu po úpravě sešitu**

Když nahradíte vložený sešit upraveným, graf si zachová původní kolekce řad a kategorií. Tento nesoulad může způsobit selhání [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) s chybou indexu mimo rozsah. Před zápisem aktualizovaného sešitu zpět do grafu vymažte existující řady a kategorie. Tento příklad používá graf, který je první objekt na první snímku. Komentář označuje místo, kde by se upravoval sešit; spustitelný příklad zapíše původní sešit zpět a ověří rozvržení v paměti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        workbook_data = chart_data.readWorkbookStream()

        # Zde upravte bajty sešitu, například pomocí Aspose.Cells.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Vyprázdnění kolekcí odstraní zastaralé odkazy před zápisem sešitu. Před použitím grafu znovu sestavte potřebné mapování řad a kategorií pro aktualizovaný sešit.

## **Nastavit vlastní formáty čísel pro buňky sešitu**

Použijte [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) k řízení, jak se číselné hodnoty zobrazují ve vloženém sešitu grafu. Například zpráva může potřebovat konverzní poměr zobrazený jako procento se čtyřmi desetinnými místy a koeficient se pěti desetinnými místy. Obě hodnoty ponechte číselné, aby zůstaly k dalším výpočtům a vykreslování grafu.

Formát čísla mění jen zobrazení, nikoli uloženou hodnotu. Formát `0.0000%` zobrazí `0.125` jako `12.5000%`; nenahradí uložené číslo `12.5`. Podobně `0.00000` zobrazí `0.1234567` jako `0.12346` bez zaokrouhlení uložené hodnoty. Pokud je vlastní formát prázdný řetězec (`""`), použije se formát vrácený metodou [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat).

Následující příklad vytvoří sloupcový graf a získá jeho buňky pomocí [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook). Na listu 0 B2 obsahuje konverzní poměr a C2 koeficient. Obě buňky poskytují hodnoty grafu. Příklad také povolí popisky hodnot propojené se zdrojovými formáty.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Formáty buněk sešitu jsou oddělené od formátů nastavených přímo na osách grafu nebo popiscích dat. V tomto příkladu každý popisek zobrazuje hodnotu ze své zdrojové buňky, protože [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) je nastaven na `True`, a používá zdrojový číselný formát, protože [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) je `True`. Po uložení a opětovném otevření prezentace popisky zobrazí `12.5000%` a `0.12346`, jak ukazuje obrázek níže. Vertikální osa používá vlastní číselný formát nastavený pomocí [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) na `0.00`, přičemž [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) je `False`.

Pro samostatné formátování popisku nastavte jeho příznak propojení na `False` a přiřaďte formát pomocí [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat). Tím se nezmění formát buňky sešitu. Například nezávislý formát popisku `0.00` zobrazí první hodnotu jako `0.13`, zatímco B2 nadále zobrazuje `12.5000%`. Viz [Chart Data Labels](/slides/cs/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) pro přímé formátování popisků.

Obrázek níže byl vygenerován ze uložené prezentace po jejím opětovném otevření:

![Sloupcový graf se zdrojově propojenými popisky ukazujícími 12.5000% a 0.12346 a nezávisle formátovanou číselnou osou.](custom-cell-formats.png)

## **Nastavit buňku sešitu jako popisek dat grafu**

Můžete použít text z buněk sešitu jako popisky dat grafu.

Tento příklad přidá bublinový graf s výchozími daty na první snímek existující prezentace. Použije buňky A10:A12 na listu 0 pro první tři popisky v prvním seriálu, povolí popisky z buněk a uloží aktualizovanou prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    
    chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)
    series = chart.getChartData().getSeries()
    data_labels = series.get_Item(0).getLabels()
    data_labels.getDefaultDataLabelFormat().setShowLabelValueFromCell(True)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(3):
        label_cell = workbook.getCell(0, f"A{10 + i}", label_values[i])
        data_labels.get_Item(i).setValueFromCell(label_cell)

    presentation.save("resultchart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Správa listů**

Metoda [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) poskytuje přístup k listům v grafickém sešitu. Tento příklad vytvoří koláčový graf s výchozími daty a vypíše názvy jednotlivých listů do konzole.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Určit typ zdroje dat**

Tento příklad vytvoří 3D sloupcový graf s výchozími daty a nastaví dva názvy řad pomocí různých zdrojů dat. První název používá řetězcový literál; druhý používá buňku C1 na listu 0. Výčtový typ [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) vybírá zdroj pro každý název. Příklad uloží prezentaci s aktualizovanými názvy řad.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    literal_name = chart.getChartData().getSeries().get_Item(0).getName()
    literal_name.setDataSourceType(DataSourceType.StringLiterals)
    literal_name.setData("LiteralString")
    cell_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell")
    cell_name.setDataSourceType(DataSourceType.Worksheet)
    cell_name.setData(name_cell)
    
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Detekce nepodporovaných formátů vložených sešitů**

Aspose.Slides nepodporuje binární formát Excel sešitu (.xlsb), který lze některé grafy vložit. Můžete použít metodu [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) na [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) k detekci nepodporovaných formátů a přeskočení těchto grafů. Tento příklad prozkoumá objekty na první snímek existující prezentace, přeskočí ne‑grafické objekty a vypíše diagnostickou zprávu pro každý graf s vloženým sešitem .xlsb.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, WorkbookType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        chart_data = shape.getChartData()

        is_internal_workbook = chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook
        is_binary_macro = chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue
        # Přečtěte nebo upravte podporovaná data sešitu grafu zde.
finally:
    presentation.dispose()
```

## **Externí sešit**

Aspose.Slides podporuje používání externích sešitů jako zdroje dat pro grafy.

### **Vytvořit externí sešit**

Použijte [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) a [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) k exportu vloženého sešitu grafu do souboru a propojení grafu s tímto externím sešitem.

Tento příklad vytvoří koláčový graf s výchozími daty a exportuje jeho sešit. Po dokončení zápisu souboru přiřadí externí sešit jako zdroj dat grafu a uloží propojenou prezentaci.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_path = Path("externalWorkbook1.xlsx").resolve()
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(str(workbook_path))

    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Nastavit externí sešit**

Pomocí metody [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) můžete přiřadit externí sešit grafu jako jeho zdroj dat. Tato metoda může také sloužit k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

Nelze upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, ale takové sešity lze použít jako externí zdroj dat. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

Tento příklad používá externí sešit, jehož list pojmenovaný `Sheet1` obsahuje název řady v B1, názvy kategorií v A2:A4 a číselné hodnoty v B2:B4. Příklad vytvoří koláčový graf, propojí sešit a použije [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) k namapování A1:B4 na jednu řadu a tři kategorie. Uloží prezentaci s propojeným grafem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())
    chart_data.setExternalWorkbook(workbook_path)
    chart_data.setRange("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Parametr `updateChartData` metody [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) určuje, zda se sešit načte.

* Když je `updateChartData` `False`, aktualizuje se jen cesta k sešitu. Data grafu nejsou načtena ani aktualizována ze cílového sešitu, takže sešit může být nedostupný.
* Když je `updateChartData` `True`, data grafu jsou aktualizována ze cílového sešitu.

Následující příklad přiřadí zástupnou URL s `updateChartData` nastaveným na `False`. Zachová výchozí data koláčového grafu a uloží prezentaci, aniž by načítal nedostupný sešit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", False)

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Získat cestu k externímu zdroji dat grafu**

Chcete‑li zjistit, který sešit je propojen s grafem, ověřte, zda graf používá externí zdroj dat, a načtěte jeho cestu k sešitu.

Tento příklad prozkoumá první objekt na první snímek prezentace s propojeným externím sešitem. Pokud jde o graf propojený s externím sešitem, vypíše [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) do konzole. Poté uloží kopii prezentace.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("externalWorkbook.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        chart_data = chart.getChartData()
        if chart_data.getDataSourceType() == ChartDataSourceType.ExternalWorkbook:
            print(chart_data.getExternalWorkbookPath())
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Upravit data grafu**

Data v externích sešitech můžete upravovat stejným způsobem, jako měníte obsah interních sešitů. Když se externí sešit načíst nepodaří, vyvolá se výjimka.

Tento příklad používá graf, který je první objekt na první snímek a je propojen s přístupným externím sešitem. Nastaví hodnotu buňky podporující první datový bod v prvním seriálu na 100 a uloží aktualizovanou prezentaci. Úprava hodnot buněk může aktualizovat propojený externí soubor XLSX, proto použijte kopii, pokud chcete zachovat původní sešit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        series = chart.getChartData().getSeries()
        if series.size() > 0 and series.get_Item(0).getDataPoints().size() > 0:
            value_cell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell()
            if value_cell is not None:
                value_cell.setValue(jpype.JInt(100))
                presentation.save("presentation_out.pptx", SaveFormat.Pptx)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

### **Obnovit sešit z keše grafu**

Pokud graf používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může rekonstruovat sešit grafu z dat uložených v keši prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), zavolejte [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) a nastavte [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) na `True` před otevřením prezentace.

Následující příklad v Pythonu obnoví data sešitu pro graf, který je první objekt na první snímek a odkazuje na nedostupný externí sešit. Přistupuje k obnoveným datům prostřednictvím [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)

load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    shape_count = slide.getShapes().size()
    if shape_count > 0 and isinstance(slide.getShapes().get_Item(0), Chart):
        chart = slide.getShapes().get_Item(0)
        recovered_workbook = chart.getChartData().getChartDataWorkbook()

        # Přečtěte nebo upravte obnovená data sešitu zde.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Pokud je externí sešit nedostupný a obnova je vypnutá, Aspose.Slides vyvolá výjimku. Povolit obnovu použijte jen tehdy, když je použití kešovaných dat grafu přijatelnou alternativou, protože keš nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu zjistit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) a [cestu k externímu sešitu](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ověřit, že je použita externí soubor.

**Jsou podporovány relativní cesty k externím sešitům a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní. Prezentace uloží absolutní cestu v souboru PPTX, takže přesunutí sešitu může vyžadovat aktualizaci odkazu.

**Mohu používat sešity umístěné na síťových zdrojích/sdíleních?**

Ano, takové sešity lze použít jako externí zdroj dat. Přímé úpravy vzdálených sešitů z Aspose.Slides však nejsou podporovány – lze je jen použít jako zdroj.

**Přepisuje Aspose.Slides externí soubor XLSX při ukládání prezentace?**

Prezentace ukládá [link to the external file](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Úprava dat grafu podporovaných buňkami může také aktualizovat propojený místní soubor XLSX. Použijte kopii sešitu, pokud originál musí zůstat nezměněn.

**Co mám dělat, když je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při vytváření odkazu. Obvyklý postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (např. pomocí [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) a odkazovat na tuto kopii.

**Může více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny ukazují na stejný soubor, aktualizace tohoto souboru se projeví ve všech grafech při dalším načtení dat.