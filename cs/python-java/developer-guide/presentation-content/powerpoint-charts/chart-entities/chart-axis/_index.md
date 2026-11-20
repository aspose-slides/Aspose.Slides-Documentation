---
title: Přizpůsobení os grafu v prezentacích pomocí Pythonu
linktitle: Osa grafu
type: docs
url: /cs/python-java/chart-axis/
keywords:
- osa grafu
- svislá osa
- vodorovná osa
- přizpůsobení osy
- manipulace s osou
- správa osy
- vlastnosti osy
- maximální hodnota
- minimální hodnota
- čára osy
- formát data
- název osy
- pozice osy
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Objevte, jak pomocí Aspose.Slides pro Python prostřednictvím Javy přizpůsobit osy grafu v prezentacích PowerPoint pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu pomocí Aspose.Slides pro Python prostřednictvím Javy. Pokrývá vypočítané hodnoty os, přepínání řádků a sloupců grafu, viditelnost os, intervaly popisků kategorií a značek os, datumové kategorie a formátování, otočení názvu, umístění os, jednotky zobrazení a logaritmické škálování.

## **Získání maximálních hodnot na svislé ose grafu**

Vytvořte [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) a přidejte plošný graf s výchozími daty. Zavolejte [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) před načtením vypočítaných hodnot os, aby byl rozvržení grafu aktuální.

Přečtěte [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) a [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) pro limity os a [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) a [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) pro intervaly značek. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) a [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) poskytují časové jednotky, které jsou relevantní pro datumové osy. Příklad ukládá tyto hodnoty do lokálních proměnných a ukládá graf.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350)
    chart.validateChartLayout()

    max_value = chart.getAxes().getVerticalAxis().getActualMaxValue()
    min_value = chart.getAxes().getVerticalAxis().getActualMinValue()

    major_unit = chart.getAxes().getVerticalAxis().getActualMajorUnit()
    minor_unit = chart.getAxes().getVerticalAxis().getActualMinorUnit()

    major_unit_scale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale()
    minor_unit_scale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale()

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Prohození dat mezi osami**

Použijte [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) k výměně rolí sérií a kategorií v datech grafu. Každá bývalá kategorie se stane sérií a každá bývalá série se stane kategorií. Tím se změní způsob, jakým jsou data seskupena; neprohodí se vodorovná a svislá osa. Příklad používá [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) k navázání výchozích dat na `Sheet1!A1:D5`, včetně řádku záhlaví a sloupce kategorií, před výměnou řádků a sloupců. Uloží graf se čtyřmi sériemi a třemi kategoriemi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300)
    chart.getChartData().setRange("Sheet1!A1:D5")
    chart.getChartData().switchRowColumn()

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Obrácení pořadí vykreslování osy**

Použijte [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) k obrácení osy kategorií nebo hodnot. Například vodorovný sloupcový graf může zobrazovat fáze projektu shora dolů ve stejném pořadí jako list: Plánování, Vývoj, Testování. Obrácení osy mění směr vykreslování; neřadí ani nepřeskupuje data sešitu. Ve srovnání s tím [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) vyměňuje role sérií a kategorií.

Následující příklad vytváří vodorovný sloupcový graf se třemi fázemi a jednou sérií. Ukládá prezentaci se třemi snímky: normální pořadí, obrácené kategorie a obrácené hodnoty. Každá kopie používá stejnou datovou sadu a na každé kopii je obrácena jen jedna osa.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CrossesType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredBar, 50, 40, 620, 320)
    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredBar)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.getCell(0, i + 1, 0, stage)
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(values[i]))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    # Snímek 2: zobraz první kategorii nahoře.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # Zachovat vodorovnou osu hodnot dole.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # Snímek 3: obrátit jen vodorovnou číselnou stupnici.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Obrácení osy může také přesunout kolmou osu na opačnou stranu grafu. [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) určuje, kde se druhá osa protíná s konfigurovanou osou. Na snímku 2 se volá s [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) na obrácené ose kategorií, aby vodorovná osa hodnot zůstala dole. Pro konkrétní průsečík použijte [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Zkontrolujte nastavení průsečíků při změně směru, zvláště pokud má graf již vlastní průsečík. Zavolejte [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) s `False` pro obnovení normálního směru vykreslování; nastavení průsečíků jsou oddělená.

| Normální pořadí (snímek 1) | Obrácené kategorie (snímek 2) | Obrácené hodnoty (snímek 3) |
| --- | --- | --- |
| ![Vodorovný sloupcový graf s normálním pořadím kategorií a hodnot os](axis-order-normal.png) | ![Vodorovný sloupcový graf se zobrazenými kategoriemi shora dolů](axis-order-categories-reversed.png) | ![Vodorovný sloupcový graf s obrácenou osou hodnot a nulou vpravo](axis-order-values-reversed.png) |
| Kategorie běží odspodu nahoru; hodnoty rostou zleva doprava. | Plánování, vývoj a testování běží shora dolů. Hodnoty a pořadí řádků sešitu zůstávají nezměněny. | Kategorie zachovávají svůj normální pořadí; hodnoty rostou zprava doleva. Osa kategorií protíná nulu vpravo. |

## **Zakázání svislé osy pro čárové grafy**

Zavolejte [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) s `False` na svislé ose, aby se skryla. Příklad vytváří čárový graf s výchozími daty a ukládá jej se skrytou svislou osou.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getVerticalAxis().setVisible(False)

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zakázání vodorovné osy pro čárové grafy**

Zavolejte [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) s `False` na vodorovné ose, aby se skryla. Příklad vytváří čárový graf s výchozími daty a ukládá jej se skrytou vodorovnou osou.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300)
    chart.getAxes().getHorizontalAxis().setVisible(False)

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zobrazení nebo skrytí mřížky grafu**

Zavolejte [getShowMajorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMajorGridLines) a [getShowMinorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMinorGridLines), abyste zjistili, které mřížky osa zobrazuje. Pro zobrazení drobných mřížek použijte [getMinorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMinorGridLinesFormat) a nastavte výplň čáry na plnou, viditelnou barvu. Pro jejich skrytí nastavte výplň na [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/#NoFill). Použijte [getMajorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMajorGridLinesFormat) k úpravě výplně čáry pro hlavní mřížky stejným způsobem. Změna výplně zachovává viditelnost os a značek.

Svislá osa tohoto seskupeného sloupcového grafu zpočátku zobrazuje jen hlavní mřížky. Příklad zobrazuje drobné mřížky v tmavě oranžové barvě, poté je opět skryje před uložením prezentace. Vypisuje viditelnost mřížek v každém kroku.

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

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 30, 660, 230)
    axis = chart.getAxes().getVerticalAxis()
    print(f"Initial: major={axis.getShowMajorGridLines()}, minor={axis.getShowMinorGridLines()}")

    minor_fill = axis.getMinorGridLinesFormat().getLine().getFillFormat()
    minor_fill.setFillType(FillType.Solid)
    minor_fill.getSolidFillColor().setColor(Color(255, 140, 0))
    print(f"Enabled: minor={axis.getShowMinorGridLines()}")

    minor_fill.setFillType(FillType.NoFill)
    print(f"Hidden: major={axis.getShowMajorGridLines()}, minor={axis.getShowMinorGridLines()}")

    presentation.save("ChartGridlines.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| Drobné mřížky zapnuty | Drobné mřížky skryty |
| --- | --- |
| ![Oranžové drobné mřížky mezi hlavními mřížkami na svislé ose](minor-gridlines-enabled.png) | ![Stejný sloupcový graf pouze s viditelnými hlavními mřížkami](minor-gridlines-hidden.png) |

## **Změna osy kategorií**

Použijte [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) k výběru datumové nebo textové osy kategorií. Tento příklad vyžaduje `ExistingChart.pptx`, kde je graf prvním tvarem na prvním snímku a buňky kategorií obsahují číselné datumové hodnoty Excelu. Mění vodorovnou osu na datumovou osu. Volání [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) s `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) s `1` a [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) s [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) umístí hlavní značky v měsíčních intervalech.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, CategoryAxisType, TimeUnitType

presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().get_Item(0)
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getHorizontalAxis().setMajorUnit(1)
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months)

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Určení typu osy kategorií z dat**

Zavolejte [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisTypeAutomatically) po naplnění kategorií a potom přečtěte [getCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getCategoryAxisType) pro zjištění výběru. To je užitečné, když stejný graf může mít buď textové popisky, nebo číselné datumové hodnoty. Metoda určuje typ při volání; neumožňuje trvalý režim, který by po pozdější změně dat znovu vyhodnocoval. Zavolejte ji znovu po nahrazení kategorií.

Následující příklad vytváří graf s textovými kategoriemi a vypisuje `True`, když je vybraný typ [CategoryAxisType.Text](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Text). Pak nahradí hodnoty buněk kategorií daty a znovu volá metodu, přičemž vypisuje `True`, když je vybraný typ [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date). Data jsou uložena jako číselné hodnoty OLE Automation, vypočtené jako počet dní od 30. prosince 1899, nikoli jako řetězce datumů. [setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) řídí, jak jsou tyto hodnoty zobrazeny; nepřevádí text na číselná data. Více o buňkách kategorií najdete v [Pracovní sešit grafu](/slides/cs/python-java/chart-workbook/).

Používejte automatické určení, když je vstup znám jako obsahující textové kategorie nebo číselná data, jako v tomto příkladu. Pro běžné číselné popisky, smíšené kategorie nebo prázdná data explicitně zavolejte [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType), aby odpovídal zamýšlenému významu. Pouze číselné hodnoty samy o sobě neznamenají, že kategorie představují data.

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, CategoryAxisType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series_name = workbook.getCell(0, 0, 1, "Sales")
    series = chart.getChartData().getSeries().add(series_name, chart.getType())
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.getCell(0, i + 1, 0, label)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float((i + 1) * 10))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Text)  # True

    base_date = date(1899, 12, 30)
    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.getCell(0, i + 1, 0)
        category_cell.setValue(float((category_date - base_date).days))
        category_cell.setCustomNumberFormat("yyyy-mm-dd")

    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Date)  # True

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Řízení intervalů popisků osy kategorií**

Když má graf mnoho kategorií, snižte počet viditelných popisků osy, aniž byste odstraňovali kategorie nebo datové body. Zavolejte [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) s `False` a pak zadejte požadovaný interval kategorií do [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing). Pro textové kategorie v jejich normálním pořadí se počítá od první kategorie:

| Interval | Popisky zobrazené v příkladu |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, … Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, … Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, … Kategorie 22 |

Interval `3` zobrazí každý třetí popisek a mezi zobrazenými popisky skryje dva. Neodstraňuje odpovídající sloupce. Automatické rozestupy zvolí interval podle dostupného prostoru; nemusí zobrazit každý popisek.

Značky mají samostatné ovládání. Zavolejte [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) s `False` a použijte [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) k nastavení jejich intervalu. Například `1` ponechá značku u každého intervalu kategorie, zatímco popisky se zobrazí jen každou třetí kategorii. Použijte [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) s viditelným stylem, abyste viděli výsledek. Opětovné nastavení automatického rozestupu (`True`) nechá graf zvolit tento interval znovu.

Následující samostatně fungující příklad vytváří 24 kategorií a jednu sérii, pak uloží tři snímky v `CategoryAxisIntervals.pptx`: automatické rozestupy, ruční rozestupy popisků s nezávislými značkami a obnovené automatické rozestupy. Obě kopie zachovávají původní data grafu. Vstupní prezentace není vyžadována. Vodorovný text popisků usnadňuje rozpoznání hustoty.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType, TickMarkType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320)

    chart.setLegend(False)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn)
    for i in range(24):
        category_cell = workbook.getCell(0, i + 1, 0, f"Category {i + 1}")
        chart.getChartData().getCategories().add(category_cell)
        value_cell = workbook.getCell(0, i + 1, 1, float(10 + i % 6 * 5))
        series.getDataPoints().addDataPointForBarSeries(value_cell)

    axis = chart.getAxes().getHorizontalAxis()
    axis.setCategoryAxisType(CategoryAxisType.Text)
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0)
    axis.getTextFormat().getPortionFormat().setFontHeight(12)
    axis.setMajorTickMark(TickMarkType.Outside)
    axis.setAutomaticTickLabelSpacing(True)
    axis.setAutomaticTickMarksSpacing(True)

    # Snímek 2: zobraz každý třetí popisek, ale zachovej značku pro každou kategorii.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # Snímek 3: nechat graf znovu zvolit oba intervaly.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Automatické rozestupy (snímek 1):** V tomto vykreslení je zobrazen každý druhý popisek kategorie a zalamuje se do dvou řádků. Výsledek může lišit podle velikosti grafu, písma a vykreslovače.

![Automatické rozestupy popisků kategorií se všemi 24 sloupci viditelnými](category-axis-automatic.png)

**Manuální rozestupy (snímek 2):** Každý třetí popisek je zobrazen v jednom řádku, zatímco značky zůstávají u každého intervalu kategorie. Všechny 24 sloupců, včetně těch bez popisků, zůstávají viditelné se stejnými hodnotami. Snímek 3 obnoví automatický vzhled uvedený výše.

![Manuální interval popisků kategorií tři se všemi 24 sloupci viditelnými](category-axis-manual.png)

### **Výběr správné osy a intervalu**

Použijte tento interval počtu kategorií pro textovou osu kategorií, například osu kategorií sloupcového, čárového, plošného nebo sloupcového grafu. Ve sloupcovém grafu je to vodorovná osa. Ve vodorovném sloupcovém grafu je osa kategorií svislá, takže tato nastavení aplikujte na osu vrácenou metodou [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Rozestupy značek se také vztahují na osu sérií v grafech, které ji mají.

Neužívejte rozestupy popisků kategorií k nastavení číselné stupnice hodnotové osy. Na hodnotové ose [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) určuje rozdíl v hodnotách: např. hlavní jednotka `10` vytvoří značky při 0, 10, 20 atd., pokud osa začíná nulou. Interval popisků kategorií `3` počítá pozice kategorií bez ohledu na jejich hodnoty. Grafy rozptylu a bublin používají hodnotové osy místo textové osy kategorií. Pro datumovou osu používejte časové jednotky a měřítka popsaná v části [Změna osy kategorií](#změna-osy-kategorií).

## **Nastavení formátu data pro hodnoty osy kategorií**

Příklad nahrazuje výchozí data grafu čtyřmi ročními hodnotami. Data jsou uložena jako sériová čísla OLE Automation v první tabulce (index `0`), vypočtená jako počet dní od 30. prosince 1899. Použijte [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) s [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date), zavolejte [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) s `False` a předávejte `yyyy` metodě [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat), aby popisky kategorií zobrazovaly čtyřciferné roky nezávisle na formátování buňky.

```python
from datetime import date

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, CategoryAxisType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    base_date = date(1899, 12, 30)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        category_value = float((category_date - base_date).days)
        category_cell = workbook.getCell(0, i + 1, 0, category_value)
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(i + 1))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date)
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy")

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení úhlu otočení názvu osy grafu**

Zavolejte [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) s `True` na svislé ose, zadejte text názvu a nastavte úhel otočení v formátování textového bloku názvu. Úhel se měří ve stupních; tento příklad ukládá sloupcový graf s názvem hodnotové osy otočeným o 90 stupňů.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value")
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90)

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení polohy osy na ose kategorií nebo hodnot**

Použijte [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) k ovlivnění, zda se hodnotová osa protíná s osou kategorií mezi kategoriemi nebo na značkách kategorií. Toto nastavení platí pro osy kategorií. Příklad nastaví tuto volbu na `True` na vodorovné ose kategorií sloupcového grafu a uloží výsledek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(True)

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nastavení jednotky zobrazení na hodnotové ose grafu**

Použijte [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) ke škálování popisků na hodnotové ose bez změny podkladových dat. S [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) nastaveným na `Millions` se hodnota 60 000 000 zobrazí jako 60. Příklad vytváří sloupcový graf a použije jednotku milionů na jeho svislé ose.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat, DisplayUnitType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Konfigurace logaritmické hodnotové osy**

Logaritmická hodnotová osa je užitečná, když kladné hodnoty zasahují několik řádů velikosti. Například služba může během pěti období přijmout 10, 100, 1 000, 10 000 a 100 000 požadavků. Na lineární stupnici jsou menší hodnoty těsně u nuly. Logaritmická stupnice usnadňuje porovnání růstu: stejné vzdálenosti představují stejné poměry, nikoli stejné rozdíly.

Zavolejte [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) s `True` na hodnotové ose a použijte [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) pro výběr základu. To mění způsob, jak jsou existující hodnoty zobrazovány; nemění data ani nepřidává logaritmickou čáru trendu. Čára trendu představuje vhodnou vztahovou křivku v datech a je samostatnou funkcí.

### **Výběr hodnotové osy a základu**

Pro čárový nebo sloupcový graf je hodnotová osa vrácena metodou [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Pro vodorovný sloupcový graf je vrácena metodou [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis). Grafy rozptylu a bublin mají dvě hodnotové osy, takže pro X‑hodnoty použijte vodorovnou osu, pro Y‑hodnoty svislou, nebo obě. Na osu kategorií logaritmické škálování nepoužívejte.

Výchozí logaritmický základ je `10`. Pro PPTX grafy použijte základ od `2` do `1000` včetně; podporovány jsou i zlomkové základy jako `2.5`. Se základem `10` jsou po sobě jdoucí mocniny (10, 100, 1 000, 10 000) stejně rozloženy.

### **Porovnání lineárního a logaritmického škálování**

Následující samostatně fungující příklad vytváří čárový graf s pěti počty požadavků na prvním snímku, potom klonuje tento snímek a zapíná na druhém logaritmickou hodnotovou osu se základem 10. Oba snímky zachovávají stejná data.

```python
import jpime
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ChartType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200)

    chart.setLegend(False)

    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Line)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.getCell(0, i + 1, 0, f"Period {i + 1}")
        chart.getChartData().getCategories().add(category_cell)

        value_cell = workbook.getCell(0, i + 1, 1, float(value))
        series.getDataPoints().addDataPointForLineSeries(value_cell)

    # Zachovat první snímek lineárně a změnit jen měřítko hodnotové osy kopie.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Lineární stupnice (snímek 1):** Stejné vertikální vzdálenosti představují stejné rozdíly v počtech požadavků. Největší hodnota dominuje grafu, takže menší hodnoty jsou těžko rozlišitelné.

![Čárový graf v PowerPointu zobrazující pět požadavků na lineární hodnotové ose](value-axis-linear.png)

**Logaritmická stupnice (snímek 2):** Stejné vertikální vzdálenosti představují stejné poměry. Každé období má desetkrát více požadavků než předchozí, takže body tvoří přímku stoupající na logaritmické stupnici se základem 10. Popisky osy stále ukazují původní počty požadavků.

![Stejných pět požadavků v PowerPointu na logaritmické hodnotové ose s základem 10](value-axis-logarithmic.png)

### **Zpracování nulových a záporných hodnot**

Logaritmická stupnice může zobrazovat jen striktně kladné hodnoty. Data před aktivací zkontrolujte. Pokud jsou nuly nebo záporné hodnoty významné, zachovejte lineární stupnici nebo je zobrazte odděleně. Pokud je jejich vyloučení vhodné pro analýzu, vysvětlete vynechání. Neskrývejte je tichým nahrazením malými kladnými čísly, protože by to změnilo význam dat. Jakýkoli ručně nastavený minimum nebo maximum pro logaritmickou osu musí být také kladné.

## **Často kladené dotazy**

**Jak nastavit hodnotu, ve které se jedna osa protíná s druhou (průsečík osy)?**

Použijte [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) pro výběr chování průsečíku. Pro určení číselné hodnoty průsečíku použijte [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Tato nastavení umožňují přesunout průsečík osy na vhodnou základnu.

**Jak mohu umístit popisky značek relativně k ose?**

Zavolejte [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) s použitím [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` nebo `None`. Pro řízení samotných značek použijte [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) nebo [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark); jsou oddělené od umístění popisků.