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
- datový zdroj
- externí sešit
- externí data
- mezipaměť grafu
- obnovení sešitu
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Objevte Aspose.Slides pro Python přes Java: snadno spravujte sešity grafů v formátech PowerPoint a OpenDocument a optimalizujte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s sešity grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu pomocí streamů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat ke kolekcím listů a určovat typ datového zdroje pro hodnoty grafu.

Dále se zabývá prací s externími sešity jako zdroji dat grafu. Příklady ukazují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

Pro buňky sešitu, které představují chybějící data, viz [Řízení zobrazování prázdných buněk](/slides/cs/python-java/chart-series/) pro rozdíl mezi prázdnou buňkou a nulou a porovnání čárového grafu dostupných režimů zobrazení.

## **Zahrnout data ze skrytých řádků a sloupců**

Použijte [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) k řízení, zda graf vykresluje data ze skrytých řádků a sloupců listu. Nastavte na `True` pro vykreslení pouze viditelných buněk nebo na `False` pro zahrnutí jak viditelných, tak skrytých buněk. Toto nastavení řídí vykreslování grafu; neskryje ani neodkryje řádky či sloupce listu.

Ukázková prezentace ([sample presentation](hidden-source-data.pptx)) obsahuje sloupcový graf jako první objekt na první snímku. Vložený list `Sheet1` obsahuje následující zdrojový rozsah `A1:C4`. Řádek 3 a sloupec C jsou skryté, ale jejich buňky stále obsahují hodnoty.

| Řádek listu | A: Měsíc | B: Maloobchod | C: Velkoobchod (skrytý sloupec) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (skrytý řádek) | February | 40 | 60 |
| 4 | March | 20 | 50 |

Přistupujte ke zdrojovým buňkám přes [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) a čtěte [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) pro kontrolu jejich skrytého stavu. Tato metoda vrací stav skrytí bez jeho změny. V tomto souboru je B2 viditelný, B3 patří ke skrytému řádku a C2 patří ke skrytému sloupci; příklad vytiskne `False`, `True` a `True`.

Pro tento příklad obnovte data grafu po změně nastavení vykreslování: zachovejte vložený sešit pomocí [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) a načtěte jej znovu pomocí [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream). Při zahrnutí všech buněk použijte také [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) k obnovení úplného rozsahu, včetně skryté kategorie únor. Pouhé změnění příznaku nestačí k obnovení cache dat grafu a popisků kategorií v tomto vzorku.

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

            # Obnovit data grafu z vloženého sešitu.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Obnovit kompletní zdrojový rozsah, včetně skrytých kategorií.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Příklad uloží dvě verze prezentace: jednu pouze s viditelnými hodnotami maloobchodu (10 a 20) a druhou se všemi šesti hodnotami. Obrázky níže ilustrují dva režimy vykreslování. Řádek 3 a sloupec C zůstávají skryté v obou vložených sešitech.

| Pouze viditelné buňky (`True`) | Všechny buňky (`False`) |
| --- | --- |
| ![Pouze viditelné buňky: Maloobchodní hodnoty 10 a 20 pro leden a březen.](hidden_cells_True.png) | ![Všechny buňky: Maloobchodní a velkoobchodní hodnoty pro leden, únor a březen.](hidden_cells_False.png) |

Skrytá buňka obsahující hodnotu se liší od prázdné buňky. [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) určuje, jak jsou chybějící hodnoty zobrazovány; nevybírá ani nevynechává skrytá zdrojová data. Viz [Řízení zobrazování prázdných buněk](/slides/cs/python-java/chart-series/#control-the-display-of-empty-cells) pro příklad.

## **Získat rozsah dat grafu**

Před aktualizací dat sešitu v existující prezentaci prozkoumejte zdrojové rozsahy, abyste zjistili, které buňky listu každý graf používá. Metoda [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) vrací aktuální datový rozsah jako vzorec s uvedením listu, např. `Sheet1!$A$1:$D$5`. Zde `Sheet1` je název listu, `!` jej odděluje od rozsahu buněk a `$A$1:$D$5` určuje buňky A1 až D5 včetně. Znak `$` označuje absolutní odkazy na řádky a sloupce.

Metoda načte aktuální rozsah bez změny grafu nebo jeho sešitu. Pokud graf nepoužívá sešit jako datový zdroj, vyhodí `InvalidOperationException`. Další informace najdete v [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

Tento příklad otevře prezentaci a přímo na každém snímku prověří tvary, zda jsou grafy. Vytiskne název každého grafu a jeho zdrojový rozsah. Pokud graf nepoužívá sešit, vypíše zprávu a pokračuje dalším grafem.

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

Aspose.Slides for Python via Java poskytuje metody [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) a [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream), které umožňují číst a zapisovat sešity dat grafu (obsahující data grafu upravená pomocí Aspose.Cells). **Note** že data grafu musí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

Tento příklad používá prezentaci s grafem jako první objekt na první snímku. Načte vložený sešit do pole bajtů, vymaže existující řady a kategorie a zapíše stejný sešit zpět. Změny zůstávají v paměti; příklad prezentaci neukládá.

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

Když nahradíte vložený sešit upraveným, graf si ponechá původní sbírky řad a kategorií. Tento nesoulad může způsobit selhání [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) s chybou indexu mimo rozsah. Před zápisem aktualizovaného sešitu do grafu vymažte existující řady a kategorie. Tento příklad používá graf, který je první objekt na první snímku. Komentář označuje místo, kde by probíhala úprava sešitu; spustitelný příklad zapíše původní sešit zpět a ověří rozvržení v paměti.

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

Vyprázdnění sbírek odstraní zastaralé odkazy na data před zápisem sešitu zpět. Před použitím grafu znovu vytvořte potřebné mapování řad a kategorií pro aktualizovaný sešit.

## **Nastavit buňku sešitu jako popisek dat grafu**

Můžete použít text z buněk sešitu jako popisky dat grafu.

Tento příklad přidá bublinový graf s výchozími daty na první snímek existující prezentace. Použije buňky A10:A12 na listu 0 pro první tři popisky v první řadě, povolí popisky z buněk a uloží aktualizovanou prezentaci.

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

## **Spravovat listy**

Metoda [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) poskytuje přístup k listům v sešitu grafu. Tento příklad vytvoří koláčový graf s výchozími daty a vypíše každé jméno listu do konzole.

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

## **Zadat typ datového zdroje**

Tento příklad vytvoří 3D sloupcový graf s výchozími daty a nastaví dvě jména řad pomocí různých datových zdrojů. První jméno používá řetězcový literál; druhé používá buňku C1 na listu 0. Výčtová hodnota [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) určuje zdroj pro každé jméno. Příklad uloží prezentaci s aktualizovanými názvy řad.

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

## **Detekovat nepodporované formáty vložených sešitů**

Aspose.Slides nepodporuje formát binárního Excel sešitu (.xlsb), který může být vložen v některých grafech. Metodu [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) na [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) můžete použít spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) k detekci nepodporovaných formátů a přeskočení těchto grafů. Tento příklad prověří tvary na první snímek existující prezentace, přeskočí tvary, které nejsou grafy, a vytiskne diagnostickou zprávu pro každý graf s vloženým .xlsb sešitem.

```python
import jpage
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

Aspose.Slides podporuje používání externích sešitů jako datového zdroje pro grafy.

### **Vytvořit externí sešit**

Použijte [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) a [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) k exportu vloženého sešitu grafu do souboru a propojení grafu s tímto externím sešitem.

Tento příklad vytvoří koláčový graf s výchozími daty a exportuje jeho sešit. Dokončí zápis souboru před přiřazením externího sešitu jako zdroje dat grafu, poté uloží propojenou prezentaci.

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

Pomocí metody [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) můžete přiřadit externí sešit grafu jako jeho datový zdroj. Tuto metodu lze také použít k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

I když nemůžete upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete takové sešity i nadále používat jako externí datový zdroj. Pokud je zadána relativní cesta k externímu sešitui, automaticky se převede na úplnou cestu.

Tento příklad používá externí sešit, jehož list pojmenovaný `Sheet1` obsahuje jméno řady v B1, názvy kategorií v A2:A4 a číselné hodnoty v B2:B4. Příklad vytvoří koláčový graf, propojí sešit a pomocí [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) namapuje A1:B4 na jednu řadu a tři kategorie. Uloží prezentaci s propojeným grafem.

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

Parametr `updateChartData` metody [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) řídí, zda se sešit načte.

* Když je `updateChartData` nastaveno na `False`, aktualizuje se pouze cesta k sešitu. Data grafu nejsou načtena ani aktualizována ze cílového sešitu, takže sešit může být nedostupný.
* Když je `updateChartData` nastaveno na `True`, data grafu jsou aktualizována ze cílového sešitu.

Následující příklad přiřadí zástupnou URL s `updateChartData` nastaveným na `False`. Zachová výchozí data koláčového grafu a uloží prezentaci bez načtení nedostupného sešitu.

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

### **Získat cestu k externímu sešitu datového zdroje grafu**

Pro identifikaci sešitu propojeného s grafem zjistěte, zda graf používá externí datový zdroj, a získejte jeho cestu k sešitu.

Tento příklad prověří první objekt na první snímek prezentace s propojeným externím sešitem. Pokud jde o graf propojený s externím sešitem, vytiskne [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) do konzole. Pak uloží kopii prezentace.

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

Data v externích sešitech můžete upravovat stejným způsobem jako obsah interních sešitů. Když nelze externí sešit načíst, vyvolá se výjimka.

Tento příklad používá graf, který je první objekt na první snímek a je propojen s dostupným externím sešitem. Nastaví hodnotu podporovanou buňkou prvního datového bodu v první řadě na 100 a uloží aktualizovanou prezentaci. Úprava hodnot v buňkách může aktualizovat propojený externí XLSX soubor, proto použijte kopii, pokud potřebujete zachovat originální sešit.

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

### **Obnovit sešit z mezipaměti grafu**

Pokud graf používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může rekonstruovat sešit grafu z dat uložených v mezipaměti prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/), zavolejte [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) a nastavte [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) na `True` před otevřením prezentace.

Následující Python příklad obnoví data sešitu pro graf, který je první objekt na první snímek a odkazuje na nedostupný externí sešit. Přistupuje k obnoveným datům přes [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook):

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

        # Přečtěte nebo upravte data obnoveného sešitu zde.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Pokud je externí sešit nedostupný a obnova je zakázána, Aspose.Slides vyvolá výjimku. Povolit obnovu použijte jen tehdy, když je použití cache grafu přijatelnou alternativou, protože cache nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu určit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) a [path to an external workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ověřit, že je používán externí soubor.

**Jsou podporovány relativní cesty k externím sešitům a jak jsou ukládány?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. Prezentace ukládá absolutní cestu v souboru PPTX, takže přesunutí sešitu může vyžadovat aktualizaci odkazu.

**Mohu použít sešity umístěné na síťových zdrojích/ sdíleních?**

Ano, takové sešity lze použít jako externí datový zdroj. Úprava vzdálených sešitů přímo z Aspose.Slides však není podporována – mohou být použity jen jako zdroj.

**Přepíše Aspose.Slides externí XLSX při ukládání prezentace?**

Prezentace ukládá [link to the external file](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Úprava dat grafu podporovaných buňkami může také aktualizovat propojený lokální XLSX soubor. Použijte kopii sešitu, pokud originál musí zůstat nezměněn.

**Co mám dělat, když je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při vytváření odkazu. Běžný přístup je odstranit ochranu předem nebo připravit dešifrovanou kopii (např. pomocí [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) a odkazovat na tuto kopii.

**Může více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny odkazují na stejný soubor, aktualizace tohoto souboru se projeví ve všech grafech při příštím načtení dat.