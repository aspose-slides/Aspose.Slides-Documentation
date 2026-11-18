---
title: Vytvoření nebo aktualizace grafů v PowerPoint prezentacích v Pythonu
linktitle: Vytvoření nebo aktualizace grafů
type: docs
weight: 10
url: /cs/python-java/create-chart/
keywords:
- přidat graf
- vytvořit graf
- upravit graf
- změnit graf
- aktualizovat graf
- bodový graf
- koláčový graf
- čarový graf
- graf stromové mapy
- akciový graf
- krabicový a vousatý graf
- trychtýřový graf
- sluneční diagram
- histogramový graf
- radarový graf
- vícekategoriový graf
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Vytvořte a přizpůsobte grafy v PowerPoint prezentacích pomocí Aspose.Slides pro Python prostřednictvím Javy. Přidejte, naformátujte a upravte grafy s praktickými příklady kódu v Pythonu."
---
## **Přehled**

Tento článek poskytuje komplexní průvodce, jak vytvářet a přizpůsobovat grafy pomocí Aspose.Slides pro Python prostřednictvím Javy. Naučíte se, jak programově přidat graf na snímek, naplnit jej daty a použít různé možnosti formátování, aby odpovídaly vašim konkrétním designovým požadavkům. V celém článku podrobné ukázky kódu ilustrují každý krok, od inicializace prezentace a objektu grafu až po konfiguraci sérií, os a legend. Dodržováním tohoto průvodce získáte solidní pochopení, jak integrovat dynamické generování grafů do vašich Python aplikací a zjednodušit proces tvorby datově řízených prezentací.

## **Vytvoření grafu**

Grafy pomáhají lidem rychle vizualizovat data a získat poznatky, které nemusí být okamžitě zřejmé z tabulky nebo tabulkového procesoru.

**Proč vytvářet grafy?**

Pomocí grafů můžete:

* agregovat, zhušťovat nebo shrnout velké množství dat na jediném snímku v prezentaci;
* odhalit vzory a trendy v datech;
* odhadnout směr a hybnost dat v čase nebo vzhledem k určité jednotce měření;
* identifikovat odlehlé hodnoty, odchylky, chyby a nesmyslná data;
* komunikovat nebo prezentovat složitá data.

V PowerPointu můžete grafy vytvářet přes funkci *Insert*, která poskytuje šablony pro navrhování mnoha typů grafů. Pomocí Aspose.Slides můžete vytvářet jak běžné grafy (založené na populárních typech grafů), tak vlastní grafy.

{{% alert color="info" title="Note" %}}Použijte výčet [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) v balíčku [asposeslides.api](https://reference.aspose.com/slides/python-java/aspose.slides/). Hodnoty v tomto výčtu odpovídají různým typům grafů.{{% /alert %}}

### **Vytvoření sloupcových seskupených grafů**

Tento příklad používá [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) k vytvoření seskupeného sloupcového grafu, který porovnává dvě série ve třech kategoriích. Série používají červené a zelené výplně a jednotlivé popisky ukazují názvy kategorií, názvy sérií a hodnoty. Index listu 0 odkazuje na první list v zabudovaném sešitu grafu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())
    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    category_cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().get_Item(0)

    value_cell = workbook.getCell(worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    series = chart.getChartData().getSeries().get_Item(1)

    value_cell = workbook.getCell(worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    series.getFormat().getFill().setFillType(FillType.Solid)
    color = Color(0, 128, 0)
    series.getFormat().getFill().getSolidFillColor().setColor(color)

    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Seskupený sloupcový graf](clustered_column_chart.png)

### **Vytvoření bodových grafů**

Bodové grafy (také známé jako scatter ploty nebo grafy x‑y) se často používají k ověření vzorů nebo demonstraci korelací mezi dvěma proměnnými.

Použijte bodový graf, když:

* máte párová číselná data;
* máte dvě proměnné, které spolu dobře souvisejí;
* chcete zjistit, zda jsou dvě proměnné navzájem spjaty;
* máte nezávislou proměnnou, která má pro závislou proměnnou více hodnot.

Tento příklad vykresluje dvě sady hodnot x‑y. První série používá přímé čáry se hvězdicovými značkami, zatímco druhá používá hladké čáry s kruhovými značkami; obě používají velikost značky 10, nastavenou pomocí [setSize](https://reference.aspose.com/slides/python-java/aspose.slides/marker/#setSize). Metoda [setSymbol](https://reference.aspose.com/slides/python-java/aspose.slides/marker/#setSymbol) řídí tvar značky.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 20, 20, 500, 300)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()

    series_name_cell = workbook.getCell(worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())
    series_name_cell = workbook.getCell(worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    x_value_cell = workbook.getCell(worksheet_index, 2, 1, 1)
    y_value_cell = workbook.getCell(worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 3, 1, 2)
    y_value_cell = workbook.getCell(worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    series = chart.getChartData().getSeries().get_Item(1)

    x_value_cell = workbook.getCell(worksheet_index, 2, 3, 5)
    y_value_cell = workbook.getCell(worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 3, 3, 3)
    y_value_cell = workbook.getCell(worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 4, 3, 2)
    y_value_cell = workbook.getCell(worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    x_value_cell = workbook.getCell(worksheet_index, 5, 3, 5)
    y_value_cell = workbook.getCell(worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_value_cell, y_value_cell)

    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Bodový graf](scatter_chart.png)

### **Vytvoření koláčových grafů**

Koláčové grafy jsou nejvhodnější pro zobrazení poměru částí k celku v datech, zejména když data obsahují kategorické popisky s číselnými hodnotami. Pokud však vaše data obsahují mnoho částí nebo popisků, mohli byste zvážit použití sloupcového grafu místo toho.

Tento příklad vytváří koláčový graf se třemi čtvrtletními hodnotami. Každý výsek má vlastní výplň a okraj a popisky zobrazují různé kombinace hodnot, procent a informací o sérii. Metoda [setFirstSliceAngle](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#setFirstSliceAngle) nastavuje první výsek tak, aby začínal ve 180 stupních.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Pie, 20, 20, 500, 300)

    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    category_cell = workbook.getCell(0, 1, 0, "1st Qtr")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    value_cell = workbook.getCell(worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(value_cell)

    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    first_slice = series.getDataPoints().get_Item(0)
    first_slice.getFormat().getFill().setFillType(FillType.Solid)
    first_slice.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    first_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    first_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    first_slice.getFormat().getLine().setWidth(3.0)
    first_slice.getFormat().getLine().setStyle(LineStyle.ThinThick)
    first_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDash)

    second_slice = series.getDataPoints().get_Item(1)
    second_slice.getFormat().setFill().setFillType(FillType.Solid)
    color = Color(165, 42, 42)
    second_slice.getFormat().getFill().getSolidFillColor().setColor(color)

    second_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_slice.getFormat().getLine().setWidth(3.0)
    second_slice.getFormat().getLine().setStyle(LineStyle.Single)
    second_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_slice = series.getDataPoints().get_Item(2)
    third_slice.getFormat().getFill().setFillType(FillType.Solid)
    color = Color(255, 127, 80)
    third_slice.getFormat().getFill().getSolidFillColor().setColor(color)

    third_slice.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_slice.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_slice.getFormat().getLine().setWidth(2.0)
    third_slice.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_slice.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    first_label = series.getDataPoints().get_Item(0).getLabel()
    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    presentation.save("PieChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Koláčový graf](pie_chart.png)

Pro zlepšení čitelnosti popisků mimo koláč viz [Format Leader Lines](/slides/cs/python-java/chart-data-label/#format-leader-lines) pro příklad, který umisťuje popisky a přizpůsobuje barvu, šířku, průhlednost a styl čáry vodících čar.

### **Vytvoření čarových grafů**

Čarové grafy (také známé jako lineární grafy) jsou nejvhodnější v situacích, kdy chcete ukázat změny hodnot v čase. Pomocí čarového grafu můžete najednou porovnat velké množství dat, sledovat změny a trendy v čase, zvýraznit anomálie v sériích dat a další.

Tento příklad používá [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) k vytvoření čarového grafu s výchozími sériemi a kategoriemi, poté uloží prezentaci jako PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    line_chart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ve výchozím nastavení jsou body v čarovém grafu spojeny přímými souvislými čarami. Pokud chcete, aby byly body spojeny pomlčkami, zavolejte [setDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setDashStyle) s hodnotou z [LineDashStyle](https://reference.aspose.com/slides/python-java/aspose.slides/linedashstyle/):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    line_chart = slide.getShapes().addChart(ChartType.Line, 20, 20, 500, 300)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)
finally:
    presentation.dispose()
```

Výsledek:

![Čarový graf](line_chart.png)

### **Vytvoření stromových mapových grafů**

Stromové mapové grafy jsou nejvhodnější pro prodejní data, když chcete zobrazit relativní velikost datových kategorií a rychle upoutat pozornost na položky, které jsou ve své kategorii velkými přispěvateli.

Tento příklad vytváří stromovou mapu s osmi listy seskupenými do čtyř kořenů a dvou větví. Metoda [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem) přiřazuje kořeny na úrovni seskupení 1 a větve na úrovni 2. Hodnoty určují relativní velikosti obdélníků, zatímco popisky kategorií a překrývající se nadřazené popisky identifikují hierarchii.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Treemap, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Větev 1
    category_cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    category_cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    category_cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(category_cell)

    # Větev 2
    category_cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    category_cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    category_cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    value_cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)
    value_cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(value_cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Stromová mapa](treemap_chart.png)

### **Vytvoření vodopádových grafů**

Vodopádový graf ukazuje, jak pozitivní a negativní změny přispívají k konečné hodnotě. Například rozpis zisku může začínat tržbami, odečítat náklady a přidávat další příjmy. Sloupce změn se vznášejí mezi předchozí a novou běžící hodnotou, zatímco celkové sloupce sahají od nuly k akumulované hodnotě.

Následující příklad používá částky v tisících amerických dolarů:

| Kategorie | Hodnota v sešitu | Typ sloupce |
| --- | ---: | --- |
| Tržby | 1000 | Nárůst |
| Náklady na prodej | -400 | Pokles |
| Hrubý zisk | 600 | Mezičtový součet |
| Provozní náklady | -200 | Pokles |
| Ostatní příjmy | 50 | Nárůst |
| Čistý zisk | 450 | Konečný součet |

Chcete‑li označit bod jako mezičtvrtý nebo konečný součet, zavolejte jeho metodu [setSetAsTotal](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#setSetAsTotal) s hodnotou `True`. Do buňky sešitu pro tento bod vložte skutečnou akumulovanou částku: `600` pro hrubý zisk (`1000 - 400`) a `450` pro čistý zisk (`600 - 200 + 50`). Metoda označí sloupec jako součet; nepočítá ani nevyplňuje hodnotu buňky. Nepoužívejte nulu jako zástupný znak ani neposkytujte jinou změnu pro součtový bod. Sloupec součtu zobrazuje akumulovanou hodnotu bez jejího opětovného přičtení k běžící hodnotě.

Tento kompletní Python příklad vytváří graf pomocí členu `Waterfall` výčtu [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/), vymaže výchozí data a naplní zabudovaný sešit. Index listu `0` vybírá první list; sloupec A obsahuje názvy kategorií a sloupec B obsahuje hodnoty. Každá buňka s hodnotou je přidána pomocí [addDataPointForWaterfallSeries](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapointcollection/#addDataPointForWaterfallSeries). Indexy bodů od nuly `2` a `5` určují mezičtvrtý a konečný součet. Volání [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) s `True` zobrazí částky na sloupcích. Vstupní prezentace ani sešit nejsou požadovány.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Waterfall, 20, 20, 680, 200)

    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Profit breakdown (USD thousands)")
    chart.getChartTitle().setOverlay(False)
    chart.setLegend(False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    workbook.clear(worksheet_index)

    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Profit")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Waterfall)
    categories = ["Revenue", "Cost of sales", "Gross profit", "Operating expenses", "Other income", "Net profit"]
    values = [1000, -400, 600, -200, 50, 450]

    for i in range(len(categories)):
        category_cell = workbook.getCell(worksheet_index, i + 1, 0, categories[i])
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(worksheet_index, i + 1, 1, values[i])
        series.getDataPoints().addDataPointForWaterfallSeries(value_cell)

    # Třetí a šestý bod představují součty, ne další změny.
    series.getDataPoints().get_Item(2).setSetAsTotal(True)
    series.getDataPoints().get_Item(5).setSetAsTotal(True)
    series.setShowConnectorLines(True)
    series.getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("WaterfallChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Vyvolejte metodu úrovně série [setShowConnectorLines](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setShowConnectorLines) s `True`, aby se zobrazily čáry propojující po sobě jdoucí sloupce a usnadnily sledování běžící hodnoty. Chcete‑li tyto čáry skrýt, nahraďte volání metody v příkladu za `series.setShowConnectorLines(False)` před uložením. Tím se změní pouze viditelnost čar, ne data ani součty.

Uložená prezentace ukazuje hrubý zisk 600 a čistý zisk 450, přičemž oba součty jsou kresleny od nuly:

![Vodopádový graf zobrazující tržby, náklady, hrubý zisk 600 a čistý zisk 450, s popisky hodnot a spojovacími čarami](waterfall_chart.png)

### **Vytvoření akciových grafů**

Akciové grafy se používají k zobrazení finančních dat, jako jsou otevírací, nejvyšší, nejnižší a uzavírací ceny, a pomáhají analyzovat tržní trendy a volatilitu. Poskytují klíčové poznatky o výkonnosti akcií, což usnadňuje investorům a analytikům činit informovaná rozhodnutí.

Tento příklad vytváří graf otevření‑nejvyšší‑nejnižší‑uzavření se čtyřmi sériemi v tomto pořadí a třemi kategoriemi. Metoda [setUpDownBars](https://reference.aspose.com/slides/python-java/aspose.slides/updownbarsmanager/#setUpDownBars) povoluje up/down pruhy a [getHiLowLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getHiLowLinesFormat) řídí čáry vysoká‑nízká, které ukazují cenové rozpětí, zatímco jednotlivé čáry sérií a drobné vodorovné mřížkové čáry jsou skryty.

Správce vrácený metodou [getUpDownBars](https://reference.aspose.com/slides/python-java/aspose.slides/chartseriesgroup/#getUpDownBars) poskytuje samostatné objekty formátování prostřednictvím [getUpBarsFormat](https://reference.aspose.com/slides/python-java/aspose.slides/updownbarsmanager/#getUpBarsFormat) a [getDownBarsFormat](https://reference.aspose.com/slides/python-java/aspose.slides/updownbarsmanager/#getDownBarsFormat). Použijte metody [getFill](https://reference.aspose.com/slides/python-java/aspose.slides/format/#getFill) a [getLine](https://reference.aspose.com/slides/python-java/aspose.slides/format/#getLine) každého objektu, abyste nezávisle nastavili výplň a obrys. Tento příklad používá zelené pruhy s tmavozelenými obrysy pro rostoucí intervaly a oranžovo‑červené pruhy s tmavě červenými obrysy pro klesající intervaly.

Poskytněte číselné hodnoty pro všechny čtyři série v každé kategorii, přičemž High a Low obklopují Open a Close. Pruhy porovnávají Close s Open **v rámci stejné kategorie**, ne s předchozí kategorií: A klesá z 72 na 25, zatímco B roste z 25 na 38 a C roste z 38 na 50. Stejné hodnoty Open a Close nevytvářejí viditelný vyplněný interval. Up/down pruhy sahají od Open–Close; high‑low čáry sahají od Low–High. Tyto pruhy patří do skupiny sérií a nejsou obyčejnými sloupcovými sériemi.

Toto formátování funguje také u grafů [Line and LineWithMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) obsahujících alespoň dvě série ve stejné skupině a odpovídající číselné hodnoty pro každou kategorii. U těchto nestackovaných čarových grafů up/down pruhy porovnávají první a poslední sérii: vyšší poslední hodnota vytváří up bar, nižší poslední hodnota vytváří down bar. Obrácení těchto sérií obrátí klasifikaci. Níže uvedený příklad používá [OpenHighLowClose](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/); nepředpokládejte, že jiné akciové, stacked‑line nebo 3D varianty používají stejnou strukturu dat nebo interpretaci intervalu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.OpenHighLowClose, 20, 20, 500, 150, False)

    workbook = chart.getChartData().getChartDataWorkbook()

    category_cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)
    series_name_cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(series_name_cell, ChartType.OpenHighLowClose)

    series = chart.getChartData().getSeries().get_Item(0)
    value_cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(1)
    value_cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(2)
    value_cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    series = chart.getChartData().getSeries().get_Item(3)
    value_cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(value_cell)

    up_down_bars = chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars()
    up_down_bars.setUpDownBars(True)

    up_down_bars.getUpBarsFormat().getFill().setFillType(FillType.Solid)
    up_fill_color = Color(50, 205, 50)
    up_down_bars.getUpBarsFormat().getFill().getSolidFillColor().setColor(up_fill_color)
    up_down_bars.getUpBarsFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    up_line_color = Color(0, 100, 0)
    up_down_bars.getUpBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(up_line_color)
    up_down_bars.getUpBarsFormat().getLine().setWidth(2)

    up_down_bars.getDownBarsFormat().getFill().setFillType(FillType.Solid)
    down_fill_color = Color(255, 69, 0)
    up_down_bars.getDownBarsFormat().getFill().getSolidFillColor().setColor(down_fill_color)
    up_down_bars.getDownBarsFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    down_line_color = Color(139, 0, 0)
    up_down_bars.getDownBarsFormat().getLine().getFillFormat().getSolidFillColor().setColor(down_line_color)
    up_down_bars.getDownBarsFormat().getLine().setWidth(2)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for stock_series in chart.getChartData().getSeries():
        stock_series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("Stock-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek, exportovaný z PowerPointu:

![Akciový graf s oranžovo‑červeným klesajícím intervalem pro A a zelenými rostoucími intervaly pro B a C](stock_chart.png)

### **Vytvoření krabicových a vousatých grafů**

Krabicové a vousaté grafy slouží k zobrazení rozdělení dat shrnutím klíčových statistických opatření, jako jsou medián, kvartily a potenciální odlehlé hodnoty. Jsou obzvláště užitečné při průzkumné datové analýze a statistických studiích pro rychlé pochopení variability dat a identifikaci anomálií.

Tento příklad vytváří krabicový a vousatý graf ze šesti hodnot. Metoda [setQuartileMethod](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setQuartileMethod) volí exkluzivní výpočet kvartilů. Příklad také povoluje čáry průměru, značky průměru, vnitřní body a odlehlé body.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.BoxAndWhisker, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    value_cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)
    value_cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(value_cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Vytvoření trychtýřových grafů**

Trychtýřové grafy slouží k vizualizaci procesů, které zahrnují sekvenční fáze, kde se objem dat snižuje s postupem od jednoho kroku k dalšímu. Jsou zvláště užitečné pro analýzu konverzních poměrů, identifikaci úzkých míst a sledování efektivity prodejních nebo marketingových procesů.

Tento příklad používá [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) k přidání trychtýřového grafu na první snímek existující prezentace. Nahrazuje výchozí data šesti kategoriemi a hodnotami v rozmezí 50 až 500, poté uloží aktualizovanou prezentaci. Vstupní prezentace musí obsahovat alespoň jeden snímek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    value_cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)
    value_cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(value_cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Trychtýřový graf](funnel_chart.png)

### **Vytvoření slunečních diagramů**

Sluneční diagramy slouží k vizualizaci hierarchických dat, zobrazujících úrovně jako soustředné kruhy. Pomáhají ilustrovat vztahy část‑k‑celku a jsou ideální pro reprezentaci vnořených kategorií a podkategorií v přehledném, kompaktním formátu.

Tento příklad vytváří sluneční diagram s osmi listy seskupenými do čtyř kořenů a dvou větví. Metoda [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem) přiřazuje kořeny na úrovni seskupení 1 a větve na úrovni 2. Popisky kategorií identifikují segmenty a hodnoty určují jejich relativní velikosti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Sunburst, 20, 20, 500, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    # Větev 1
    category_cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    category_cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    category_cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(category_cell)

    # Větev 2
    category_cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    category_cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(category_cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    category_cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(category_cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    value_cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)
    value_cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(value_cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Sluneční diagram](sunburst_chart.png)

### **Vytvoření histogramových grafů**

Histogramové grafy ukazují, jak jsou číselné hodnoty rozloženy do intervalů (binů). Pro měsíční zprávy o časech zpracování objednávek použijte stejnou šířku binu a prahové hodnoty, aby byly intervaly konzistentní a usnadnily porovnání rozdělení.

Volání [setAggregationType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAggregationType) na vodorovné ose s režimem z [AxisAggregationType](https://reference.aspose.com/slides/python-java/aspose.slides/axisaggregationtype/). [setBinWidth](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setBinWidth) se použije jen pro `ByBinWidth`; [setNumberOfBins](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberOfBins) jen pro `ByNumberOfBins`. Použijte `Automatic`, aby graf sám určil biny.

#### **Použití pevné šířky binu**

Tento příklad seskupuje časy zpracování do 10‑minutových intervalů, s oddělenými biny pro časy ≤ 10 min a > 40 min. Povolit tyto biny můžete pomocí [setUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setUnderflowBin) a [setOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setOverflowBin). Při zadávání explicitních prahů pomocí [setUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setUnderflowBin) a [setOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setOverflowBin) zavolejte [setAutomaticUnderflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticUnderflowBin) a [setAutomaticOverflowBin](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticOverflowBin) s hodnotou `False`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200)

    chart.setLegend(False)
    chart.setTitle(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.getCell(0, i, 0, float(value))
        series.getDataPoints().addDataPointForHistogramSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setAggregationType(AxisAggregationType.ByBinWidth)
    axis.setBinWidth(10.0)
    axis.setUnderflowBin(True)
    axis.setAutomaticUnderflowBin(False)
    axis.setUnderflowBin(10.0)
    axis.setOverflowBin(True)
    axis.setAutomaticOverflowBin(False)
    axis.setOverflowBin(40.0)

    presentation.save("Histogram-bin-width.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Prezentace v PowerPointu ukazuje počty binů **3, 4, 4, 4 a 2**. Bin podprůběhu zahrnuje `5, 10, 10`, takže jeho práh je inkluzivní. Bin přetečení zahrnuje jen `41, 50`, takže jeho práh je exkluzivní; hodnoty rovné `40` zůstávají v předchozím intervalu. Vnitřní biny obsahují hodnoty větší než jejich dolní hranice a menší nebo rovné jejich horní hranici.

![Histogram s 10‑minutovými biny a explicitními prahy podprůběhu a přetečení](histogram_bin_width.png)

#### **Určení počtu binů**

Pro pevnou úroveň detailu místo pevných intervalů požádejte o pět binů pro stejná data. Tento příklad ponechává biny podprůběhu a přetečení vypnuté. Graf určuje šířku z rozsahu dat, takže hranice se mohou mezi zprávami měnit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Histogram, 20, 20, 680, 200)

    chart.setLegend(False)
    chart.setTitle(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    values = [5, 10, 10, 11, 15, 20, 20, 21, 25, 30, 30, 31, 35, 40, 40, 41, 50]
    for i, value in enumerate(values):
        value_cell = workbook.getCell(0, i, 0, float(value))
        series.getDataPoints().addDataPointForHistogramSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setAggregationType(AxisAggregationType.ByNumberOfBins)
    axis.setNumberOfBins(5)

    presentation.save("Histogram-bin-count.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pět binů má počty **4, 4, 4, 4 a 1**. Porovnejte toto rozdělení s výsledkem pevné šířky výše: vstupní hodnoty jsou identické, ale hranice se liší.

![Histogram s pěti biny vypočtenými ze stejných dat](histogram_bin_count.png)

### **Vytvoření radarových grafů**

Radarové grafy slouží k zobrazení multivariátních dat ve dvourozměrném formátu, což umožňuje snadné porovnání několika proměnných současně. Jsou zvláště užitečné pro identifikaci vzorů, silných a slabých stránek napříč více výkonnostními metrikami nebo atributy.

Tento příklad používá [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) k vytvoření radarového grafu s výchozími sériemi a kategoriemi, poté uloží prezentaci jako PPTX.

```python
import jpype
import asposeslides

if not jp?isJVMStarted():"
# Correct the code snippet
```

Výsledek:

![Radarový graf](radar_chart.png)

### **Vytvoření vícekategoriových grafů**

Vícekategoriové grafy slouží k zobrazení dat, která zahrnují více než jedno kategorické seskupení, což vám umožňuje porovnávat hodnoty napříč více dimenzemi současně. Jsou zvláště užitečné, když potřebujete analyzovat trendy a vztahy v komplexních, vícevýškových datových sadách.

Tento příklad vytváří seskupený sloupcový graf se osmi kategoriemi uspořádanými do čtyř dvojic. Metoda [setGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#setGroupingItem) dává každé dvojici sdílený popisek na úrovni seskupení 1, čímž vzniká osa kategorií s jak individuálními, tak skupinovými popisky.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    worksheet_index = 0

    category_cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    category_cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    category_cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    category_cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(category_cell)

    category_cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(category_cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    category_cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(category_cell)

    series_name_cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    value_cell = workbook.getCell(worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(value_cell)
    value_cell = workbook.getCell(worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(value_cell)

    presentation.save("AsposeChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Vícekategoriový graf](multi_category_chart.png)

#### **Odstranění popisku čtvrtletí**

Stáhněte si [quarters.pptx](quarters.pptx) a umístěte jej do pracovního adresáře. Jeho graf ukazuje devět měsíců a jedinou prodejní sérii s hodnotami od 10 do 18. Na ose kategorií Q1 zahrnuje leden až březen, Q2 zahrnuje duben až červen a Q3 zahrnuje červenec až září.

Duben je čtvrtou kategorií (index 3) a obsahuje popisek Q2. Použijte [getGroupingLevels](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/#getGroupingLevels) k přístupu k úrovním seskupení dubna, pak zavolejte [deleteGroupingItem](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorylevelsmanager/#deleteGroupingItem) s úrovní 1 k odstranění jeho popisku čtvrtletí. Úroveň 0 představuje samotný měsíc a nemůže být touto metodou odstraněna.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("quarters.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    april = chart.getChartData().getCategories().get_Item(3)
    april.getGroupingLevels().deleteGroupingItem(1)

    presentation.save("quarters-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened = Presentation("quarters-updated.pptx")
try:
    chart = reopened.getSlides().get_Item(0).getShapes().get_Item(0)
    data = chart.getChartData()
    
    points = data.getSeries().get_Item(0).getDataPoints()
    print(", ".join(str(month.getAsCell().getValue()) for month in data.getCategories()))
    print(", ".join(str(point.getValue().getData()) for point in points))
finally:
    reopened.dispose()
```

Po opětovném otevření grafu příklad vypíše původní měsíce (`Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep`) a prodejní hodnoty (`10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0`) ve stejném pořadí. Otevřete `quarters-updated.pptx` v PowerPointu a porovnejte popisky os. Popisek Q2 a hranice skupiny před dubnem zmizí, takže Q1 zahrnuje leden až červen. Q3 stále začíná v červenci.

![Popisky čtvrtletí před a po odstranění. Vlevo Q2 zahrnuje duben až červen. Vpravo Q1 zahrnuje leden až červen.](quarter-label-comparison.png)

### **Vytvoření mapových grafů**

Mapové grafy slouží k vizualizaci geografických dat přiřazením informací k konkrétním místům, jako jsou země, státy nebo města. Jsou obzvláště užitečné pro analýzu regionálních trendů, demografických dat a prostorových rozdělení v přehledném, vizuálně poutavém formátu.

Tento příklad používá [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) k vytvoření mapového grafu s výchozími geografickými daty a uloží jej pro zobrazení v PowerPointu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Map, 20, 20, 500, 300)

    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Výsledek:

![Mapový graf](map_chart.png)

{{% alert color="info" title="Note" %}}Obrázek výše ukazuje uloženou prezentaci otevřenou v PowerPointu. Aspose.Slides zapisuje mapový graf a jeho data správně, ale samotné mapové grafy nevykresluje: když je snímek s takovým grafem vykreslen do obrázku nebo převeden do PDF či SVG, oblast grafu zůstane prázdná. Ostatní tvary na stejném snímku nejsou ovlivněny.{{% /alert %}}

### **Vytvoření kombinovaných grafů**

Kombinovaný graf (nebo combo graf) spojuje dva nebo více typů grafů v jednom diagramu. Tento graf vám umožní zvýraznit, porovnat nebo prozkoumat rozdíly mezi dvěma či více datovými sadami, což vám pomůže identifikovat vztahy mezi nimi.

![Kombinovaný graf](combination_chart.png)

Tento příklad kombinuje dva seskupené sloupcové řady s čárovou řadou napříč čtyřmi kategoriemi. Sloupce používají primární svislou osu, zatímco [setPlotOnSecondAxis](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#setPlotOnSecondAxis) umisťuje čáru na sekundární svislou osu vpravo. Pomocné funkce nastavují název, legendu, popisky os a mřížkové čáry.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisPositionType, ChartType, CrossesType, FillType, LegendPositionType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

def create_combo_chart():
    presentation = Presentation()
    slide = presentation.getSlides().get_Item(0)
    try:
        chart = create_chart_with_first_series(slide)

        add_second_series_to_chart(chart)
        add_third_series_to_chart(chart)

        set_primary_axes_format(chart)
        set_secondary_axes_format(chart)

        presentation.save("combo-chart.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()

def create_chart_with_first_series(slide):
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    # Nastavte název grafu.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # Nastavte legendu grafu.
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # Odstraňte výchozí vygenerované řady a kategorie.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # Přidejte nové kategorie.
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # Přidejte první řadu.
    series_name_cell = workbook.getCell(worksheet_index, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 1, 4.3)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 1, 2.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 1, 3.5)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 1, 4.5)
    series.getDataPoints().addDataPointForBarSeries(cell)

    return chart

def add_second_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 2, "Series 2")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.ClusteredColumn)

    series.getParentSeriesGroup().setOverlap(jpype.JByte(-25))
    series.getParentSeriesGroup().setGapWidth(220)

    cell = workbook.getCell(worksheet_index, 1, 2, 2.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 2, 4.4)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 2, 1.8)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 2, 2.8)
    series.getDataPoints().addDataPointForBarSeries(cell)

def add_third_series_to_chart(chart):
    workbook = chart.getChartData().getChartDataWorkbook()
    worksheet_index = 0

    series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
    series = chart.getChartData().getSeries().add(series_name_cell, ChartType.Line)

    cell = workbook.getCell(worksheet_index, 1, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 2, 3, 2.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 3, 3, 3.0)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(worksheet_index, 4, 3, 5.0)
    series.getDataPoints().addDataPointForLineSeries(cell)

    series.setPlotOnSecondAxis(True)

def set_primary_axes_format(chart):
    # Nastavte vodorovnou osu.
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # Nastavte svislou osu.
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # Nastavte barvu hlavních mřížkových čar svislé osy.
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # Nastavte sekundární vodorovnou osu.
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Nastavte sekundární svislou osu.
    secondary_vertical_axis = chart.getAxes().getSecondaryVerticalAxis()
    secondary_vertical_axis.setPosition(AxisPositionType.Right)
    secondary_vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    secondary_vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_vertical_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(secondary_vertical_axis, "Y Axis 2")

def set_axis_title(axis, axis_title):
    axis.setTitle(True)
    axis.getTitle().setOverlay(False)
    title_paragraph = axis.getTitle().addTextFrameForOverriding(axis_title).getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(12.0)

create_combo_chart()
```

## **Aktualizace grafů**

Aspose.Slides pro Python prostřednictvím Javy umožňuje aktualizovat PowerPoint grafy úpravou dat grafu, formátování a stylování. Tato funkčnost zjednodušuje proces udržování prezentací aktuálních s dynamickým obsahem a zajišťuje, že grafy přesně odrážejí současná data a vizuální standardy.

Tento příklad aktualizuje graf pojmenovaný „My chart“ na prvním snímku existující prezentace. Vyžaduje dvě sloupcové řady se třemi datovými body každá, s popisky kategorií ve sloupci A a názvy sérií v prvním řádku prvního listu. Příklad používá [getCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getCell) ke změně buněk sešitu, aktualizuje hodnoty sérií, přidá třetí sérii a změní typ grafu na seskupené válcové přes [setType](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setType).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, ChartType, Presentation, SaveFormat

chart_name = "My chart"

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, Chart) and chart_name == shape.getName():
            chart = shape
            worksheet_index = 0

            workbook = chart.getChartData().getChartDataWorkbook()

            workbook.getCell(worksheet_index, 1, 0, "Modified Category 1")
            workbook.getCell(worksheet_index, 2, 0, "Modified Category 2")

            series = chart.getChartData().getSeries().get_Item(0)

            workbook.getCell(worksheet_index, 0, 1, "New_Series 1")
            series.getDataPoints().get_Item(0).getValue().setData(90)
            series.getDataPoints().get_Item(1).getValue().setData(123)
            series.getDataPoints().get_Item(2).getValue().setData(44)

            series = chart.getChartData().getSeries().get_Item(1)

            workbook.getCell(worksheet_index, 0, 2, "New_Series 2")
            series.getDataPoints().get_Item(0).getValue().setData(23)
            series.getDataPoints().get_Item(1).getValue().setData(67)
            series.getDataPoints().get_Item(2).getValue().setData(99)

            series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Series 3")
            series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

            value_cell = workbook.getCell(worksheet_index, 1, 3, 20)
            series.getDataPoints().addDataPointForBarSeries(value_cell)
            value_cell = workbook.getCell(worksheet_index, 2, 3, 50)
            series.getDataPoints().addDataPointForBarSeries(value_cell)
            value_cell = workbook.getCell(worksheet_index, 3, 3, 30)
            series.getDataPoints().addDataPointForBarSeries(value_cell)

            chart.setType(ChartType.ClusteredCylinder)

    presentation.save("AsposeChartModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení rozsahu dat pro graf**

Chcete‑li prozkoumat rozsah, který již používá existující graf, viz [Retrieve a Chart's Data Range](/slides/cs/python-java/chart-workbook/#retrieve-a-charts-data-range).

Aspose.Slides pro Python prostřednictvím Javy poskytuje flexibilitu definovat konkrétní rozsah dat z listu jako zdroj pro data vašeho grafu. To znamená, že můžete přímo mapovat část vašeho listu do grafu, což vám umožní kontrolovat, které buňky přispívají k sériím a kategoriím grafu. Výsledkem je snadná aktualizace a synchronizace grafů s nejnovějšími změnami v listu, což zajišťuje, že vaše PowerPoint prezentace odrážejí aktuální a přesné informace.

Tento příklad používá [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) k nastavení datového zdroje grafu pojmenovaného „My chart“ na prvním snímku existující prezentace na `Sheet1!A1:B4`. Sešit grafu musí obsahovat tento list a naplněný rozsah s názvem série v prvním řádku, popisky kategorií ve sloupci A a třemi hodnotami ve sloupci B.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation, SaveFormat

chart_name = "My chart"

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        if isinstance(shape, Chart) and chart_name == shape.getName():
            chart = shape
            chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Použití výchozích značek v grafech**

Když používáte výchozí značky v grafech, každá série grafu automaticky získá jiný výchozí symbol značky.

Tento příklad používá [addChart](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addChart) k vytvoření grafu se dvěma čárovými sériemi a legendou. Nastavení značek přístupných přes [getMarker](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getMarker) zachovává automaticky přiřazené symboly značek. První série zahrnuje zápornou hodnotu a chybějící hodnotu, reprezentovanou `None`, zatímco druhá má hodnotu pro každou kategorii.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 10, 10, 400, 400)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    series_name_cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    category_cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    category_cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(category_cell)
    value_cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(value_cell)

    series_name_cell = workbook.getCell(0, 0, 2, "Series 2")
    second_series = chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    value_cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)
    value_cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Jaké typy grafů jsou podporovány Aspose.Slides pro Python prostřednictvím Javy?**

Aspose.Slides pro Python prostřednictvím Javy podporuje širokou škálu typů grafů, včetně sloupcových, čarových, koláčových, plošných, bodových, histogramových, radarových a mnoha dalších. Tato flexibilita vám umožní vybrat nejvhodnější typ grafu pro vaše potřeby vizualizace dat.

**Jak přidám nový graf na snímek?**

Chcete‑li přidat graf, nejprve vytvoříte instanci třídy [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), získáte požadovaný snímek pomocí jeho indexu a poté zavoláte metodu pro přidání grafu, specifikujete typ grafu a počáteční data. Tento proces integruje graf přímo do vaší prezentace.

**Jak mohu aktualizovat data zobrazená v grafu?**

Data grafu můžete aktualizovat přístupem k jeho sešitu dat ([ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/)), vymazáním výchozích sérií a kategorií a následným přidáním vlastních dat. To vám umožní programově obnovit graf tak, aby odrážel nejnovější data.

**Je možné přizpůsobit vzhled grafu?**

Ano, Aspose.Slides pro Python prostřednictvím Javy poskytuje rozsáhlé možnosti přizpůsobení. Můžete měnit barvy, písma, popisky, legendy a další formátovací prvky tak, aby vzhled grafu odpovídal vašim konkrétním požadavkům na design.