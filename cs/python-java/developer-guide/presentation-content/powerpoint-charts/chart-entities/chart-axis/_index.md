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
description: "Objevte, jak pomocí Aspose.Slides pro Python přes Java přizpůsobit osy grafu v prezentacích PowerPoint pro zprávy a vizualizace."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit osy grafu pomocí Aspose.Slides pro Python přes Java. Pokrývá vypočítané hodnoty os, výměnu řádků a sloupců grafu, viditelnost os, intervaly popisků kategorií a značek, datumové kategorie a formátování, rotaci názvu, umístění os, zobrazovací jednotky a logaritmické škálování.

## **Získání maximálních hodnot na svislé ose grafu**

Vytvořte [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) a přidejte plošný graf s výchozími daty. Zavolejte [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) před čtením vypočítaných hodnot os, aby byl rozvržení grafu aktuální.

Přečtěte [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) a [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) pro limity osy a [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) a [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) pro intervaly značek. [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) a [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) poskytují časové jednotky, které jsou relevantní pro datumové osy. Příklad ukládá tyto hodnoty do lokálních proměnných a ukládá graf.

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

## **Vyměnit data mezi osami**

Použijte [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) k výměně rolí řad a kategorií v datech grafu. Každá bývalá kategorie se stane řadou a každá bývalá řada se stane kategorií. Toto mění způsob seskupení dat; neprovádí výměnu vodorovné a svislé osy. Příklad používá [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) k navázání výchozích dat na `Sheet1!A1:D5`, včetně řádku záhlaví a sloupce kategorií, před výměnou řádků a sloupců. Uloží graf se čtyřmi řadami a třemi kategoriemi.

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

## **Zakázat svislou osu pro čárové grafy**

Zavolejte [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) s hodnotou `False` na svislé ose, aby byla skryta. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou svislou osou.

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

## **Zakázat vodorovnou osu pro čárové grafy**

Zavolejte [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) s `False` na vodorovné ose, aby byla skryta. Příklad vytvoří čárový graf s výchozími daty a uloží jej se skrytou vodorovnou osou.

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

## **Změna osy kategorií**

Použijte [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) k výběru datumové nebo textové osy kategorií. Tento příklad vyžaduje `ExistingChart.pptx`, kde je graf jako první tvar na první snímku a buňky kategorií obsahují číselné hodnoty dat v Excelu. Změní vodorovnou osu na datumovou osu. Voláním [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) s `False`, [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) s `1` a [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) s [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) umístíte hlavní značky v měsíčních intervalech.

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

## **Ovládání intervalů popisků osy kategorií**

Když má graf mnoho kategorií, snižte počet viditelných popisků osy bez odebrání kategorií nebo datových bodů. Zavolejte [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) s `False`, poté předávejte požadovaný interval kategorií do [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing). Pro textové kategorie v jejich normálním pořadí počítá od první kategorie:

| Interval | Popisky zobrazené v příkladu |
| --- | --- |
| `1` | Kategorie 1, Kategorie 2, Kategorie 3, ... Kategorie 24 |
| `2` | Kategorie 1, Kategorie 3, Kategorie 5, ... Kategorie 23 |
| `3` | Kategorie 1, Kategorie 4, Kategorie 7, ... Kategorie 22 |

Interval `3` zobrazuje každý třetí popisek, přičemž dva popisky mezi zobrazenými jsou skryté. Neodstraňuje odpovídající sloupce. Automatické rozestupy volí interval na základě dostupného prostoru; nemusí nutně zobrazovat každý popisek.

Značky mají samostatné ovládací prvky. Zavolejte [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) s `False` a použijte [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) pro nastavení jejich intervalu. Například `1` ponechá značku na každém intervalu kategorie, zatímco popisky se zobrazí jen každou třetí kategorií. Použijte [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) s viditelným stylem, abyste viděli výsledek. Volání kteréhokoli setteru automatického rozestupu s `True` opět nechá graf zvolit tento interval.

Následující samostatný příklad vytvoří 24 kategorií a jednu řadu, poté uloží tři snímky v `CategoryAxisIntervals.pptx`: automatické rozestupy, ruční rozestup popisků s nezávislými značkami a obnovené automatické rozestupy. Obě kopie zachovávají původní data grafu. Není vyžadována vstupní prezentace. Text vodorovných popisků usnadňuje rozeznat hustotu.

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

    # Snímek 3: nechat graf znovu vybrat oba intervaly.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Automatické rozestupy (snímek 1):** V tomto vykreslení se zobrazuje každý druhý popisek kategorie a zalamuje se na dva řádky. Automatický výsledek se může lišit podle velikosti grafu, fontů a vykreslovacího engine.

![Automatické rozestupy popisků kategorií se všemi 24 sloupci viditelnými](category-axis-automatic.png)

**Ruční rozestupy (snímek 2):** Každý třetí popisek se zobrazí na jednom řádku, zatímco značky zůstávají na každém intervalu kategorie. Všechny 24 sloupce, včetně těch bez popisků, zůstávají viditelné se stejnými hodnotami. Snímek 3 obnoví automatický vzhled zobrazený výše.

![Manuální interval popisků kategorií tři se všemi 24 sloupci viditelnými](category-axis-manual.png)

### **Zvolte správnou osu a interval**

Použijte tento interval počtu kategorií pro textovou osu kategorií, například osu kategorií sloupcového, čárového, plošného nebo pruhového grafu. V sloupcovém grafu je to vodorovná osa. V horizontálním pruhovém grafu je osa kategorií svislá, takže použijte tato nastavení na osu vrácenou metodou [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Rozestup značek se také vztahuje na osu řad v grafech, které ji mají.

Neužívejte rozestup popisků kategorií k nastavení číselné stupnice osy hodnot. Na ose hodnot [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) specifikuje rozdíl v hodnotách: například hlavní jednotka `10` vytvoří značky při 0, 10, 20 atd., když osa začíná nulou. Interval popisků kategorií `3` místo toho počítá pozice kategorií bez ohledu na jejich hodnoty. Rozptýlené a bublinové grafy používají osy hodnot místo textové osy kategorií. Pro datumovou osu použijte časové hlavní jednotky a stupnice popsané v [Změna osy kategorií](#změna-osy-kategorií).

## **Nastavení formátu data pro hodnoty osy kategorií**

Příklad nahrazuje výchozí data grafu čtyřmi ročními hodnotami. Data jsou uložena jako sériová čísla OLE Automation v prvním listu (index `0`), vypočítaná jako počet dnů od 30. prosince 1899 pro tyto datumy. Použijte [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) s [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date), zavolejte [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) s `False` a předávejte `yyyy` do [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat), aby se popisky kategorií zobrazovaly jako čtyřciferné roky nezávisle na formátování buňky.

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

## **Nastavení úhlu otočení pro název osy grafu**

Zavolejte [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) s `True` na svislé ose, zadejte text názvu a nastavte úhel otočení v formátování textového bloku názvu. Úhel je udáván ve stupních; tento příklad ukládá sloupcový graf s názvem osy hodnot otočeným o 90 stupňů.

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

## **Nastavení polohy osy na ose kategorií nebo hodnoty**

Použijte [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) k řízení, zda osa hodnot protíná osu kategorií mezi kategoriemi nebo na značkách kategorií. Toto nastavení platí pro osy kategorií. Příklad nastaví hodnotu `True` na vodorovné ose kategorií sloupcového grafu a uloží výsledek.

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

## **Nastavení zobrazovací jednotky na ose hodnoty grafu**

Použijte [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) s [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) nastaveným na `Millions`, aby se hodnota 60 000 000 zobrazila jako 60. Příklad vytvoří sloupcový graf a použije jednotku milionů na jeho svislé ose.

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

## **Konfigurace logaritmické osy hodnot**

Logaritmická osa hodnot je užitečná, když kladné hodnoty pokrývají několik řádů velikosti. Například služba může během pěti období přijímat 10, 100, 1 000, 10 000 a 100 000 požadavků. Na lineární stupnici se menší hodnoty zobrazují těsně u nuly. Logaritmická stupnice usnadňuje srovnání relativního růstu: stejné vzdálenosti představují stejné poměry, nikoli stejné rozdíly.

Zavolejte [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) s `True` na ose hodnot a použijte [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) k výběru základu. Tím se změní způsob zobrazení existujících hodnot; data nebo logaritmická trendová čára se nemění. Trendová čára představuje vyhovující vztah v datech a je samostatnou funkcí.

### **Zvolte osu hodnot a základ**

Pro čárový nebo sloupcový graf je osa hodnot vrácena metodou [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis). Pro horizontální pruhový graf je vrácena metodou [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis). Rozptýlené a bublinové grafy mají dvě osy hodnot, takže pro hodnoty X použijte vodorovnou osu, pro hodnoty Y svislou osu, nebo obě. Na osu kategorií logaritmické škálování nepoužívejte.

Výchozí logaritmický základ je `10`. Pro PPTX grafy použijte základ od `2` do `1000` včetně; podporovány jsou i zlomkové základy jako `2.5`. Se základem `10` jsou po sobě jdoucí mocniny 10, 100, 1 000 a 10 000 rovnoměrně rozloženy.

### **Porovnání lineárního a logaritmického škálování**

Následující samostatný příklad vytvoří čárový graf s pěti počty požadavků na prvním snímku, poté tento snímek zkopíruje a na druhém povolí logaritmickou osu hodnot se základem 10. Oba snímky zachovávají stejná data.

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

    # Zachovejte první snímek lineární a změňte pouze měřítko hodnotové osy kopie.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Lineární měřítko (snímek 1):** Stejné vertikální vzdálenosti představují stejné rozdíly v počtech požadavků. Největší hodnota dominuje grafu a menší hodnoty jsou obtížně rozlišitelné.

![Čárový graf v PowerPointu zobrazující pět požadavků na lineární ose hodnot](value-axis-linear.png)

**Logaritmické měřítko (snímek 2):** Stejné vertikální vzdálenosti představují stejné poměry. Každé období má desetkrát více požadavků než předchozí, takže body tvoří přímou rostoucí linii na logaritmické stupnici se základem 10. Osa stále ukazuje původní počty požadavků.

![Stejné pět požadavků v PowerPointu na logaritmické ose hodnot se základem 10](value-axis-logarithmic.png)

### **Zpracování nulových a záporných hodnot**

Logaritmická stupnice může zobrazovat pouze striktně kladné hodnoty. Před jejím povolením zkontrolujte data. Pokud jsou nuly nebo záporné hodnoty významné, zachovejte lineární stupnici nebo je zobrazte odděleně. Pokud je jejich vyloučení vhodné pro analýzu, uveďte důvod. Nenahrazujte je tiše malými kladnými čísly, protože by to změnilo význam dat. Jakýkoli ručně nastavený minimum nebo maximum pro logaritmickou osu musí být také kladné.

## **Často kladené otázky**

**Jak nastavit hodnotu, při které se jedna osa protíná s druhou (průsečík osy)?**

Použijte [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) k výběru chování průsečíku. Pro určení číselné hodnoty průsečíku použijte [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Tím můžete přesunout průsečík osy na vhodnou referenční čáru.

**Jak mohu umístit popisky značek relativně k ose?**

Zavolejte [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) s typem [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/): `Low`, `High`, `NextTo` nebo `None`. Pro ovládání samotných značek použijte [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) nebo [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark); jsou oddělené od umístění popisků.