---
title: Přizpůsobení výsečových grafů v prezentacích pomocí Python via Java
linktitle: Výsečový graf
type: docs
url: /cs/python-java/pie-chart/
keywords:
- výsečový graf
- správa grafu
- přizpůsobení grafu
- možnosti grafu
- nastavení grafu
- možnosti vykreslení
- barva výseče
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vytvořte a přizpůsobte výsečové grafy v Python via Java pomocí Aspose.Slides. Nastavte sekundární diagramy, zobrazte popisky dat a použijte automatické barvy výsečí v PowerPointu."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s výsečovými grafy v Aspose.Slides. Ukazuje, jak nastavit možnosti sekundárního diagramu pro grafy Pie of Pie a Bar of Pie a jak povolit automatické barvení výsečů u standardního výsečového grafu.

Příklady se zaměřují na úlohy přizpůsobení grafu, jako je přidání grafu do snímku, úprava nastavení řad a popisků, nahrazení výchozích dat grafu vlastními kategoriemi a hodnotami a uložení aktualizované prezentace.

## **Možnosti sekundárního diagramu pro grafy Pie of Pie a Bar of Pie**

Aspose.Slides pro Python via Java podporuje možnosti sekundárního diagramu pro grafy Pie of Pie a Bar of Pie. Tyto možnosti řídí velikost sekundárního diagramu a způsob rozdělení datových bodů mezi oba diagramy.

Následující příklad vytvoří graf Pie of Pie v nové prezentaci a zobrazí hodnoty datových bodů jako popisky. Metoda [setSecondPieSize](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setSecondPieSize) nastaví velikost sekundárního diagramu na 149% hlavního diagramu. [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) vybere rozdělení založené na procentech a [setPieSplitPosition](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitPosition) nastaví práh na 53%.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400)
    series = chart.getChartData().getSeries().get_Item(0)

    # Zobrazte hodnoty a nakonfigurujte sekundární diagram.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setSecondPieSize(149)
    series_group.setPieSplitBy(PieSplitType.ByPercentage)
    series_group.setPieSplitPosition(53)

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Vyberte kategorie pro sekundární diagram**

Použijte vlastní rozdělení, pokud chcete seskupit konkrétní kategorie v sekundárním diagramu bez ohledu na jejich procentuální hodnoty. Například prodejní zpráva může zobrazit Online a Events společně, aby čtenáři mohli porovnat tyto dva kanály, i když představují 35% a 10% celkových prodejů.

Zavolejte [setPieSplitBy](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setPieSplitBy) s [PieSplitType.Custom](https://reference.aspose.com/slides/python-java/aspose.slides/piesplittype/#Custom) a vyberte body pomocí [getPieSplitCustomPoints](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getPieSplitCustomPoints). Metoda [add](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#add) kolekce přijímá index začínající nulou v řadě; použijte [addItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#addItem), abyste přidali objekt datového bodu. V tomto příkladu index 1 vybírá Online a bod s indexem 3 vybírá Events. Partners je také přidán dočasně a poté vyloučen pomocí [removeItem](https://reference.aspose.com/slides/python-java/aspose.slides/piesplitcustompointcollection/#removeItem).

```python
import jpype
import asposeslides

if not jpage.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, PieSplitType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200)

    # Nahraďte výchozí data prodejem podle kanálu.
    workbook = chart.getChartData().getChartDataWorkbook()
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(0, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series_group = series.getParentSeriesGroup()
    series_group.setPieSplitBy(PieSplitType.Custom)
    series_group.setColorVaried(True)

    # Vyberte Online podle jeho nulového indexu a Events podle jeho objektu datového bodu.
    series_group.getPieSplitCustomPoints().add(1)
    series_group.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3))

    # Vyloučte Partners z výběru bez mazání jeho zdrojových dat.
    series_group.getPieSplitCustomPoints().add(2)
    series_group.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2))

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Online (35) a Events (10) se v sekundárním diagramu zobrazí jako samostatné výseče. V primárním diagramu jsou reprezentovány jednou spojenou výsečí s hodnotou 45, vedle Retail (40) a Partners (15). Odebrání Partners z vlastní volby jej ponechá v primárním diagramu; neodstraní kategorii ani její hodnotu ze zdrojových dat grafu.

Následující obrázek ukazuje uloženou prezentaci v PowerPointu:

![Graf Pie of Pie s Online a Events ve sekundárním diagramu a jejich spojenou hodnotou 45 v primárním diagramu](pie_of_pie_custom.png)

## **Nastavte automatické barvy výsečí výsečového grafu**

Aspose.Slides pro Python via Java může automaticky přiřadit různé barvy výsečím výsečového grafu. Následující příklad vytvoří výsečový graf se středovým nadpisem a nahradí výchozí data třemi čtvrtletními kategoriemi a jejich hodnotami. Metoda [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) zobrazí hodnoty 20, 50 a 30 jako popisky, zatímco [setColorVaried](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setColorVaried) umožní odlišnou barvu pro každou výseč.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Přidejte centrovaný nadpis grafu.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Nahraďte výchozí data pomocí prvního listu.
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    for i in range(len(category_names)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, category_names[i])
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(worksheet_index, i + 1, 1, jpype.JInt(values[i]))
        series.getDataPoints().addDataPointForPieSeries(value_cell)

    # Zobrazte hodnoty a přiřaďte různé barvy výsečím.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)
    series.getParentSeriesGroup().setColorVaried(True)

    presentation.save("pie.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Jsou varianty Pie of Pie a Bar of Pie podporovány?**

Ano, knihovna [podporuje](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) sekundární diagram pro výsečové grafy, včetně typů Pie of Pie a Bar of Pie.

**Mohu exportovat pouze graf jako obrázek (například PNG)?**

Ano, můžete [exportovat samotný graf jako obrázek](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getImage) (například PNG) bez exportu celé prezentace.