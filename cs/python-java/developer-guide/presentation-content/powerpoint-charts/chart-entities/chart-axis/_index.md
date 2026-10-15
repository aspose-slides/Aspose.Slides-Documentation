---
title: Přizpůsobení os grafu v prezentacích pomocí Pythonu
linktitle: Osa grafu
type: docs
url: /cs/python-java/chart-axis/
keywords:
- osa grafu
- vertikální osa
- horizontální osa
- přizpůsobit osu
- manipulovat osou
- spravovat osu
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
description: "Objevte, jak použít Aspose.Slides pro Python přes Java k přizpůsobení os grafu v prezentacích PowerPoint pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu pomocí Aspose.Slides pro Python přes Java. Pokrývá vypočítané hodnoty os, výměnu řádků a sloupců grafu, viditelnost os, intervaly popisků kategorií a značek os, datumové kategorie a formátování, otáčení nadpisu, umístění os, jednotky zobrazení a logaritmické škálování.

## **Získání největších hodnot na svislé ose grafu**

Vytvořte [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) a přidejte plošný graf s výchozími daty. Zavolejte [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) před čtením vypočítaných hodnot os, aby byl rozvržení grafu aktuální.

Přečtěte [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) a [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) pro limity osy a [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) a [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) pro intervaly značek. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) a [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) poskytují časové jednotkové škály, které jsou relevantní pro datumové osy. Příklad ukládá tyto hodnoty do lokálních proměnných a ukládá graf.

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

## **Výměna dat mezi osami**

Použijte [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) k výměně rolí sérií a kategorií v datech grafu. Každá bývalá kategorie se stane sérií a každá bývalá série se stane kategorií. Tím se změní způsob seskupení dat; neproběhne výměna vodorovné a svislé osy. Příklad používá [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) k navázání výchozích dat na `Sheet1!A1:D5`, včetně řádku záhlaví a sloupce kategorií, před výměnou řádků a sloupců. Uloží graf se čtyřmi sériemi a třemi kategoriemi.

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

Použijte [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) k obrácení kategoriální nebo hodnotové osy. Například vodorovný pruhový graf může zobrazovat fáze projektu z vrchu dolů ve stejném pořadí jako list: Planning, Development, Testing. Obrácení osy změní směr vykreslování; neřadí ani nepřeskupuje data sešitu. Ve srovnání [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) vyměňuje role sérií a kategorií.

Následující příklad vytvoří vodorovný pruhový graf se třemi fázemi a jednou sérií. Uloží prezentaci se třemi snímky: normální pořadí, obrácené kategorie a obrácené hodnoty. Každá kopie používá stejnou datovou sadu a na každé kopii je obrácena jen jedna osa.

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

    # Snímek 2: zobraz první kategorii na vrcholu.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # Nechá horizontální hodnotovou osu ve spodní části.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # Snímek 3: obrátit pouze horizontální číselnou stupnici.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Obrácení osy může také přesunout kolmicou osu na opačnou stranu grafu. [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) určuje, kde druhá osa protíná konfigurovanou osu. Na snímku 2 zůstane voláním s [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) na obrácené kategoriální ose horizontální hodnotová osa ve spodní části. Pro konkrétní průsečík použijte [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Zkontrolujte nastavení průsečíků při změně směru, zejména pokud má graf již vlastní průsečík. Zavolejte [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) s `False` pro obnovení normálního směru vykreslování; nastavení průsečíků jsou samostatná.

| Normální pořadí (snímek 1) | Obrácené kategorie (snímek 2) | Obrácené hodnoty (snímek 3) |
| --- | --- | --- |
| ![Vodorovný pruhový graf s normálním pořadím kategorií a hodnotové osy](axis-order-normal.png) | ![Vodorovný pruhový graf s kategoriemi zobrazenými shora dolů](axis-order-categories-reversed.png) | ![Vodorovný pruhový graf s obrácenou hodnotovou osou a nulou vpravo](axis-order-values-reversed.png) |
| Kategorie běží odspodu nahoru; hodnoty rostou zleva doprava. | Planning, Development a Testing běží shora dolů. Hodnoty a pořadí řádků sešitu zůstávají nezměněny. | Kategorie zachovávají svůj normální pořádek; hodnoty rostou zprava doleva. Kategorie osa protíná v nule vpravo. |

## **Skrytí svislé osy pro čárové grafy**

Zavolejte [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) s `False` na svislé ose, aby se skryla. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou svislou osou.

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

## **Skrytí vodorovné osy pro čárové grafy**

Zavolejte [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) s `False` na vodorovné ose, aby se skryla. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou vodorovnou osou.

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

## **Změna kategoriální osy**

Použijte [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) k výběru datumové nebo textové kategoriální osy. Tento příklad vyžaduje `ExistingChart.pptx`, kde je graf jako první tvar na prvním snímku a buňky kategorií obsahují číselné datumové hodnoty Excelu. Změní vodorovnou osu na datumovou osu. Volání [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) s `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) s `1` a [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) s [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) umístí hlavní značky v intervalech jednoho měsíce.

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

## **Řízení intervalů popisků kategoriální osy**

Když má graf mnoho kategorií, snižte počet viditelných popisků osy, aniž byste odstraňovali kategorie nebo datové body. Zavolejte [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) s `False` a poté předáte požadovaný interval kategorií do [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing). Pro textové kategorie v normálním pořadí se číslování začíná od první kategorie:

| Interval | Popisky zobrazené v příkladu |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, ... Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, ... Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, ... Kategorie 22 |

Interval `3` zobrazuje každou třetí popisek a mezi zobrazenými popisky jsou skryté dva popisky. Neodstraňuje odpovídající sloupce. Automatické rozestupy vybírají interval na základě dostupného prostoru; nemusí zobrazovat každý popisek.

Značky os mají samostatné ovládání. Zavolejte [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) s `False` a použijte [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) k nastavení jejich intervalu. Například `1` ponechá značku na každém intervalu kategorie, zatímco popisky se zobrazí jen každou třetí kategorii. Použijte [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) s viditelným stylem, abyste viděli výsledek. Volání kteréhokoli nastavení automatického rozestupu s `True` znovu umožní grafu zvolit tento interval.

Následující samostatný příklad vytvoří 24 kategorií a jednu sérii, poté uloží tři snímky do `CategoryAxisIntervals.pptx`: automatické rozestupy, ruční rozestupy popisků s nezávislými značkami a obnovené automatické rozestupy. Obě kopie zachovají původní data grafu. Vstupní prezentace není vyžadována. Vodorovný text popisků usnadňuje vidět rozdíl v hustotě.

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

    # Snímek 2: zobrazit každý třetí popisek, ale zachovat značku pro každou kategorii.
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

**Automatické rozestupy (snímek 1):** V tomto zobrazení je každý druhý popisek kategorie zobrazen a zalamuje se do dvou řádků. Automatický výsledek se může lišit podle velikosti grafu, fontů a renderu.

![Automatické rozestupy popisků kategorií se všemi 24 sloupci viditelnými](category-axis-automatic.png)

**Ruční rozestupy (snímek 2):** Každý třetí popisek je zobrazen na jednom řádku, zatímco značky zůstávají na každém intervalu kategorie. Všechny 24 sloupce, včetně těch bez popisků, zůstávají viditelné se stejnými hodnotami. Snímek 3 obnovuje automatický vzhled zobrazený výše.

![Ruční interval popisků kategorií třetí s všemi 24 sloupci viditelnými](category-axis-manual.png)

### **Vyberte správnou osu a interval**

Použijte tento interval počtu kategorií pro textovou kategoriální osu, například pro kategoriální osu sloupcového, čárového, plošného nebo pruhového grafu. Ve sloupcovém grafu je to vodorovná osa. Ve vodorovném pruhovém grafu je kategoriální osa svislá, takže aplikujte tato nastavení na osu vrácenou pomocí [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Rozestup značek osy se také vztahuje na osu sérií v grafech, které ji mají.

Neměřte interval popisků kategorií k nastavení číselné škály hodnotové osy. Na hodnotové ose [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) určuje rozdíl hodnot: například hlavní jednotka `10` vytváří značky při 0, 10, 20 atd., pokud osa začíná na nule. Interval popisků kategorií `3` počítá pozice kategorií bez ohledu na jejich hodnoty. Rozptylové a bublinové grafy používají hodnotové osy místo textové kategoriální osy. Pro datumovou osu použijte časové hlavní jednotky a škály, jak je popsáno v [Změna kategoriální osy](#change-a-category-axis).

## **Nastavení formátu data pro hodnoty kategoriální osy**

Příklad nahradí výchozí data grafu čtyřmi ročními hodnotami. Data jsou uložena jako sériová čísla OLE Automation v první tabulce (index `0`), vypočtená jako počet dní od 30. prosince 1899. Použijte [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) s [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date), zavolejte [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) s `False` a předávejte `yyyy` do [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat), aby popisky kategorií zobrazovaly čtyřciferná roky nezávisle na formátování buňky.

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

## **Nastavení úhlu otáčení pro nadpis osy grafu**

Zavolejte [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) s `True` na svislé ose, zadejte text nadpisu a nastavte úhel otáčení v formátování textového bloku nadpisu. Úhel se měří ve stupních; tento příklad uloží sloupcový graf s nadpisem hodnotové osy otočeným o 90 stupňů.

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

## **Nastavení polohy osy na kategoriální nebo hodnotové ose**

Použijte [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories), abyste určili, zda hodnotová osa protíná kategoriální osu mezi kategoriemi nebo na značkách kategorie. Toto nastavení se vztahuje na kategoriální osy. Příklad nastaví `True` na vodorovné kategoriální ose sloupcového grafu a uloží výsledek.

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

Použijte [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit), abyste škálovali popisky na hodnotové ose bez změny podkladových dat. S [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) nastaveným na `Millions` se hodnota 60 000 000 zobrazí jako 60. Příklad vytvoří sloupcový graf a použije jednotku zobrazení milionů na jeho svislé ose.

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

Logaritmická hodnotová osa je užitečná, když kladné hodnoty zasahují několik řádů velikosti. Například služba může během pěti období získat 10, 100, 1 000, 10 000 a 100 000 požadavků. Na lineární stupnici se menší hodnoty zobrazují těsně u nuly. Logaritmická stupnice usnadňuje porovnání relativního růstu: stejné vzdálenosti představují stejné poměry, nikoli stejné rozdíly.

Zavolejte [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) s `True` na hodnotové ose a použijte [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase), abyste vybrali základnu. Tím se změní způsob zobrazení existujících hodnot; data se nemění ani se nepřidává logaritmická regresní čára. Regresní čára představuje přizpůsobený vztah v datech a je samostatnou funkcí.

### **Vyberte hodnotovou osu a základnu**

U čárového nebo sloupcového grafu je hodnotová osa vrácena pomocí [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). U vodorovného pruhového grafu je vrácena pomocí [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis). Rozptylové a bublinové grafy mají dvě hodnotové osy, takže vyberte vodorovnou osu pro hodnoty X, svislou osu pro hodnoty Y nebo obě. Logaritmické škálování neaplikujte na kategoriální osu.

Výchozí logaritmická základna je `10`. U PPTX grafů použijte základnu od `2` do `1000` včetně; podporovány jsou i zlomkové základny jako `2.5`. Se základnou `10` jsou po sobě jdoucí mocniny 10, 100, 1 000 a 10 000 rovnoměrně rozloženy.

### **Porovnání lineárního a logaritmického škálování**

Následující samostatný příklad vytvoří čárový graf s pěti počty požadavků na prvním snímku, poté klonuje tento snímek a na druhém povolí logaritmickou hodnotovou osu s bází 10. Oba snímky zachovávají stejná data.

```python
import jpype
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

    # Udržte první snímek lineární a změňte jen měřítko hodnotové osy kopie.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Lineární škála (snímek 1):** Stejné svislé vzdálenosti představují stejné rozdíly v počtech požadavků. Největší hodnota dominuje grafu, což ztěžuje rozpoznání menších hodnot.

![Čárový graf v PowerPointu zobrazující pět počtů požadavků na lineární hodnotové ose](value-axis-linear.png)

**Logaritmická škála (snímek 2):** Stejné svislé vzdálenosti představují stejné poměry. Každé období má desetkrát více požadavků než předchozí, takže body tvoří přímou rostoucí čáru na bází 10 stupnici. Popisky osy stále ukazují původní počty požadavků.

![Stejných pět požadavků v PowerPointu na logaritmické hodnotové ose s bází 10](value-axis-logarithmic.png)

### **Zpracování nulových a záporných hodnot**

Logaritmická stupnice může zobrazovat pouze přísně kladné hodnoty. Před jejím zapnutím zkontrolujte data. Pokud jsou nula nebo záporné hodnoty významné, zachovejte lineární stupnici nebo je zobrazte odděleně. Pokud je vyloučení těchto hodnot vhodné pro analýzu, vysvětlete vynechání. Ne nahrazujte je tiše malými kladnými čísly, protože to mění význam dat. Jakýkoli ručně nastavený minimum nebo maximum pro logaritmickou osu musí být také kladný.

## **Často kladené otázky**

**Jak nastavit hodnotu, při které se jedna osa protíná s druhou (průsečík osy)?**  
Použijte [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) k výběru chování průsečíku. Pro zadání číselné hodnoty průsečíku použijte [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Tímto nastavením můžete posunout průsečík osy na vhodnou referenční úroveň.

**Jak mohu umístit popisky značek relativně k ose?**  
Zavolejte [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) pomocí [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` nebo `None`. Pro řízení samotných značek použijte [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) nebo [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark); jsou oddělené od umístění popisků.