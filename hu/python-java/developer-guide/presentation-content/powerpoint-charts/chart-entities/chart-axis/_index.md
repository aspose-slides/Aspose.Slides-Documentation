---
title: Diagram tengelyek testreszabása prezentációkban Python használatával
linktitle: Diagram tengely
type: docs
url: /hu/python-java/chart-axis/
keywords:
- diagram tengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságok
- maximális érték
- minimális érték
- tengelyvonal
- dátumformátum
- tengelycím
- tengely pozíció
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan használhatja az Aspose.Slides for Python via Java könyvtárat a diagram tengelyek testreszabásához PowerPoint-prezentációkban jelentések és vizualizációk számára."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides for Python via Java segítségével. Kitér a kiszámított tengelyértékekre, a diagram sorok és oszlopok cseréjére, a tengely láthatóságára, a kategória címke- és jelölőskála intervallumokra, a dátumkategóriákra és formázásra, a cím forgatására, a tengely elhelyezésére, a megjelenítési egységekre és a logaritmikus skálázásra.

## **A diagram függőleges tengelyének legnagyobb értékeinek lekérése**

Hozzon létre egy [Prezentáció](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) és adjon hozzá egy területdiagramot alapértelmezett adatokkal. Hívja meg a [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) metódust a kiszámított tengelyértékek olvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa el a [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) és a [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) a tengely határértékeihez, valamint a [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) és a [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) a jelölőskála intervallumaihoz. A [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) és a [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) időegység skálákat ad, amelyek a dátum tengelyek esetén relevánsak. A példa ezeket az értékeket helyi változókban tárolja, és elmenti a diagramot.

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

## **Az adatok cseréje a tengelyek között**

Használja a [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) metódust a sorozatok és kategóriák szerepkörének felcseréléséhez a diagram adataiban. Minden korábbi kategória sorozattá válik, és minden korábbi sorozat kategóriává. Ez megváltoztatja az adatok csoportosítását; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) metódust használja az alapértelmezett adatok `Sheet1!A1:D5` tartományra kötéséhez, beleértve a fejléc sort és a kategória oszlopot, mielőtt sorokat és oszlopokat cserélne. A példa négy sorozattal és három kategóriával rendelkező diagramot ment.

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

## **A tengely ábrázolási sorrendjének megfordítása**

Használja a [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) metódust egy kategória vagy értéktengely megfordításához. Például egy vízszintes sávdiagram a projekt fázisait felülről lefelé ugyanabban a sorrendben jelenítheti meg, mint a munkalapon: Tervezés, Fejlesztés, Tesztelés. A tengely megfordítása megváltoztatja az ábrázolás irányát; nem rendezi vagy átrendezi a munkafüzet adatokat. Összehasonlításként a [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) felcseréli a sorozatok és kategóriák szerepkörét.

Az alábbi példa egy három szakaszú és egy sorozatú vízszintes sávdiagramot hoz létre. Három diát ment egy prezentációban: normál sorrend, megfordított kategóriák és megfordított értékek. Minden másolat ugyanazt az adatkészletet használja, és minden másolaton csak egy tengely van megfordítva.

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

    # Dia 2: az első kategória a tetején jelenik meg.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # A vízszintes értéktengelyt alul tartsa.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # Dia 3: csak a vízszintes numerikus skálát fordítsa meg.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A tengely megfordítása áthelyezheti a merőleges tengelyt a diagram ellenkező oldalára is. A [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) határozza meg, hogy a másik tengely hol keresztezi a konfigurálandó tengelyt. A 2. dián a [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) használata a megfordított kategóriatengelyen megőrzi a vízszintes értéktengelyt az alján. Egy adott keresztponthoz használja a [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) metódust. Ellenőrizze a keresztbeállításokat irányváltáskor, különösen ha a diagram már egyedi keresztponttal rendelkezik. Hívja a [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) metódust `False` értékkel a normál ábrázolási irány visszaállításához; a keresztbeállítások külön kezelendők.

| Normál sorrend (1. dia) | Megfordított kategóriák (2. dia) | Megfordított értékek (3. dia) |
| --- | --- | --- |
| ![Vízszintes sávdiagram normál kategória- és értéktengely sorrenddel](axis-order-normal.png) | ![Vízszintes sávdiagram a kategóriák felülről lefelé jelenítve](axis-order-categories-reversed.png) | ![Vízszintes sávdiagram megfordított értéktengellyel, a nulla jobbra](axis-order-values-reversed.png) |
| A kategóriák alulról felfelé haladnak; az értékek balról jobbra nőnek. | A Tervezés, Fejlesztés és Tesztelés felülről lefelé halad. Az értékek és a munkafüzet sorainak sorrendje változatlan. | A kategóriák megtartják a normál sorrendet; az értékek jobbról balra nőnek. A kategóriatengely a jobb oldalon, nullánál keresztezi. |

## **A függőleges tengely letiltása vonaldiagramoknál**

Hívja a [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) metódust `False` értékkel a függőleges tengelyen a rejtéshez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és elmenti a függőleges tengely elrejtve.

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

## **A vízszintes tengely letiltása vonaldiagramoknál**

Hívja a [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) metódust `False` értékkel a vízszintes tengelyen a rejtéshez. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, és elmenti a vízszintes tengely elrejtve.

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

## **Kategória tengely módosítása**

Használja a [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) metódust, hogy dátum vagy szöveges kategória tengelyt válasszon. Ez a példa a `ExistingChart.pptx` fájlt igényli, amelynek első diáján az első alakzat egy diagram, és a kategória cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátum tengelyre változtatja. A [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) `False`, a [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) `1`, és a [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) használatával a fő jelölők egy hónapos intervallumra kerülnek.

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

## **Kategória tengely címke intervallumok vezérlése**

Ha egy diagram sok kategóriát tartalmaz, csökkentse a látható tengelycímkék számát anélkül, hogy eltávolítaná a kategóriákat vagy adatpontokat. Hívja a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) `False` értékkel, majd adja meg a kívánt kategória intervallumot a [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing) metódusnak. Szöveges kategóriák esetén a normál sorrendben a számolás az első kategóriától kezdődik:

| Intervallum | A példában megjelenített címkék |
| --- | --- |
| `1` | Kategória 1, Kategória 2, Kategória 3, … Kategória 24 |
| `2` | Kategória 1, Kategória 3, Kategória 5, … Kategória 23 |
| `3` | Kategória 1, Kategória 4, Kategória 7, … Kategória 22 |

Az `3` intervallum minden harmadik címkét jelenít meg, két címkét rejtve hagyva a megjelenítettek között. Nem távolítja el a megfelelő oszlopokat. Az automatikus beállítás a rendelkezésre álló hely alapján választ intervallumot, és nem feltétlenül jeleníti meg az összes címkét.

A jelölősközt is külön lehet beállítani. Hívja a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) `False` értékkel és használja a [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) a periódus beállításához. Például az `1` minden kategória intervallumra tesz egy jelölőt, miközben a címkék csak minden harmadik kategórián jelennek meg. Használja a [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) látható stílussal, hogy lássa az eredményt. Bármelyik automatikus beállítót `True`-ra állítva a diagram újra kiválasztja azt az intervallumot.

A következő önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment a `CategoryAxisIntervals.pptx` fájlba: automatikus beállítás, kézi címke beállítás független jelölőkkel, és az automatikus visszaállítás. A két másolat megtartja az eredeti diagramadatokat. Bemutató bemenet nem szükséges. A vízszintes címke szöveg segít megkülönböztetni a sűrűséget.

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

    # Dia 2: minden harmadik címkét jelenítse meg, de minden kategóriához tartson egy jelölőt.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # Dia 3: engedje, hogy a diagram újból kiválassza mindkét intervallumot.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Automatikus beállítás (1. dia):**  
Ezen megjelenítésben minden második kategória címke látható és két sorra törik. Az automatikus eredmény a diagram méretétől, betűtípustól és a renderertől függően változhat.

![Automatikus kategória címke elosztás, az összes 24 oszlop látható](category-axis-automatic.png)

**Kézi beállítás (2. dia):**  
Minden harmadik címke egy sorban jelenik meg, miközben a jelölők minden kategória intervallumon maradnak. Az összes 24 oszlop, beleértve azokat is, amelyeken nincs címke, látható ugyanazzal az értékkel. A 3. dia visszaállítja a fenti automatikus megjelenést.

![Kézi kategória címke három intervalluma, az összes 24 oszlop látható](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Használja ezt a kategória-számláló intervallumot szöveges kategória tengelyhez, például egy oszlop-, vonal-, terület- vagy sávdiagram kategória tengelyén. Oszlopdiagram esetén ez a vízszintes tengely. Vízhorizontal sávdiagram esetén a kategória tengely függőleges, ezért alkalmazza ezeket a beállításokat a [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) által visszaadott tengelyre. A jelölősközt is alkalmazni lehet egy sorozat tengelyre az olyan diagramokban, amelyeknek van ilyen.

Ne használja a kategória címke beállítást az értéktengely numerikus skálájának meghatározására. Értéktengelyen a [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) értékegységbeli különbséget ad meg: például egy 10-es fő egység 0, 10, 20 stb. jelölőket hoz létre, ha a tengely nulláról indul. A `3` kategória címke intervallum csak a kategória pozíciókat számolja, az adatértékek függetlenül. Szórt és buborék diagramok értéktengelyt használnak, nem szöveges kategória tengelyt. Dátum tengely esetén használjon időalapú fő egységeket és skálákat, ahogy a [Change a Category Axis](#change-a-category-axis) részben leírt.

## **A kategória tengely értékek dátumformátumának beállítása**

A példa az alapértelmezett diagram adatokat négy éves értékekkel cseréli. A dátumok az első munkalapban (index `0`) OLE Automation sorozatszámként vannak tárolva, ami a 1899. december 30. óta eltelt napok száma. Használja a [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) opcióval, hívja a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) `False` értékkel, és adja át a `yyyy` értéket a [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) metódusnak, hogy a kategória címkék a négyjegyű évszámot jelenítsék meg a cella formázásától függetlenül.

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

## **A diagram tengelycím forgatásának beállítása**

Hívja a [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) metódust `True` értékkel a függőleges tengelyen, adja meg a címszöveget, és állítsa be a forgásszöget a cím szövegdoboz formázásában. A szög fokban van mérve; ez a példa egy oszlopdiagramot ment, ahol az értéktengely címe 90 fokkal van elforgatva.

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

## **A tengely pozíciójának beállítása kategória vagy értéktengelyen**

Használja a [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) metódust annak szabályozására, hogy az értéktengely a kategóriatengelyhez a kategóriák között vagy a kategória jelölő pontoknál keresse kereszte. Ez a beállítás csak kategóriatengelyekre vonatkozik. A példa a vízszintes kategóriatengelyen egy oszlopdiagramon `True`-ra állítja, és elmenti az eredményt.

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

## **Megjelenítési egység beállítása a diagram értéktengelyén**

Használja a [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) metódust a értéktengely feliratainak méretezésére az adatok megváltoztatása nélkül. A [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) `Millions` beállításával a 60 000 000 érték 60-ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyen a millió egységet alkalmazza.

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

## **Logaritmikus értéktengely konfigurálása**

Egy logaritmikus értéktengely hasznos, ha a pozitív értékek több nagyságrendben terjednek. Például egy szolgáltatás 10, 100, 1 000, 10 000 és 100 000 kérést kaphat öt időszakban. Lineáris skálán a kisebb értékek közel nulla csoportosulnak. A logaritmikus skála a relatív növekedést könnyebben összehasonlíthatóvá teszi: az egyenlő távolság egyenlő arányokat jelent, nem egyenlő különbségeket.

Hívja a [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) `True` értékkel az értéktengelyen, és használja a [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) a bázis kiválasztásához. Ez megváltoztatja a meglévő értékek megjelenítését; nem módosítja az adatokat vagy ad logaritmikus trendvonalat. A trendvonal egy adatot illesztő kapcsolat, és külön funkció.

### **Az értéktengely és a bázis kiválasztása**

Egy vonal- vagy oszlopdiagram esetén az értéktengely a [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) által visszaadott. Egy vízszintes sávdiagram esetén a [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis) adja vissza. Szórt és buborék diagramoknak két értéktengelyük van, így válassza a vízszintes tengelyt az X értékekhez, a függőleges tengelyt a Y értékekhez, vagy mindkettőt. Ne alkalmazzon logaritmikus skálázást kategóriatengelyen.

A logaritmikus alap alapértelmezett értéke `10`. PPTX diagramok esetén a `2`-tól `1000`-ig terjedő bázist lehet használni, tizedes alapok, például `2.5` is támogatott. `10` alappal a sorozatos hatványok, mint 10, 100, 1 000, 10 000 egyenlő távolságokra lesznek.

### **Lineáris és logaritmikus skálázás összehasonlítása**

A következő önálló példa egy vonaldiagramot hoz létre, amelyen az öt kérési szám szerepel az első dián, majd klónozza a diát, és a második dián alap-10 logaritmikus értéktengelyt aktivál. Mindkét dia ugyanazt az adatot tartja.

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

    # Tartsa az első diát lineárisnak, és csak a másolat értéktengely skáláját változtassa meg.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Lineáris skála (1. dia):**  
Az egyenlő függőleges távolságok egyenlő különbségeket jelentnek a kérési számokban. A legnagyobb érték uralja a diagramot, a kisebb értékek nehezen láthatóak.

![Vonaldiagram PowerPointban, amely öt kérési számot mutat lineáris értéktengelyen](value-axis-linear.png)

**Logaritmikus skála (2. dia):**  
Az egyenlő függőleges távolságok egyenlő arányokat jelentnek. Minden időszak tízszer több kérést tartalmaz az előzőhöz képest, így a pontok egy egyenesedő vonalat alkotnak a 10-es alapú skálán. A tengelycímkék továbbra is az eredeti kérési számokat mutatják.

![Ugyanaz az öt kérési szám PowerPointban, alap-10 logaritmikus értéktengelyen](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

Egy logaritmikus skála csak szigorúan pozitív értékeket jeleníthet meg. Ellenőrizze az adatokat a bekapcsolás előtt. Ha a nulla vagy negatív értékek jelentősek, használjon lineáris skálát vagy jelenítse meg őket külön. Ha az értékek kizárása megfelelő az elemzéshez, magyarázza meg a kihagyást. Ne helyettesítse őket csendben kis pozitív számokkal, mivel ez megváltoztatja az adatok jelentését. Bármely manuálisan beállított minimum vagy maximum logaritmikus tengelyen szintén pozitívnak kell lennie.

## **FAQ**

**Hogyan állíthatom be azt az értéket, ahol egy tengely a másikat keresztezze (tengely keresztpont)?**

Használja a [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) metódust a keresztelési viselkedés kiválasztásához. Numerikus keresztérték megadásához használja a [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) metódust. Ezek a beállítások lehetővé teszik, hogy a tengelykeresztet egy megfelelő alapvonalra mozgassa.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez viszonyítva?**

Hívja a [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) metódust a [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/) használatával: `Low`, `High`, `NextTo` vagy `None`. A jelölőpontok magának a vezérléséhez használja a [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) vagy a [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) metódust; ezek különállóak a címke elhelyezésétől.