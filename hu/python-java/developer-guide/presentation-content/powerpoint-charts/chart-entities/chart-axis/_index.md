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
- tengely tulajdonságai
- max érték
- min érték
- tengelyvonal
- dátumformátum
- tengelycím
- tengelypozíció
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja az Aspose.Slides for Python via Java könyvtárat a diagram tengelyek testreszabásához PowerPoint prezentációkban jelentésekhez és vizualizációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides for Python via Java segítségével. Kitér a kiszámított tengelyértékekre, a diagram sorok és oszlopok cseréjére, a tengely láthatóságára, a kategória címke- és jelölőintervallumokra, a dátumkategóriákra és formázásra, a cím forgatására, a tengely elhelyezésére, a megjelenítési egységekre és a logaritmikus skálázásra.

## **A diagram függőleges tengelyének legnagyobb értékeinek lekérése**

Hozzon létre egy [Prezentáció](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) és adjon hozzá egy területdiagramot alapértelmezett adatokkal. Hívja meg a [validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) a kiszámított tengelyértékek beolvasása előtt, hogy a diagramelrendezés naprakész legyen.

Olvassa el a [getActualMaxValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMaxValue) és a [getActualMinValue](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinValue) értékeket a tengelykorlátokhoz, valamint a [getActualMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnit) és a [getActualMinorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnit) értékeket a jelölőintervallumokhoz. A [getActualMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMajorUnitScale) és a [getActualMinorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getActualMinorUnitScale) időegység skálákat adnak vissza, amelyek a dátumtengelyek esetén relevánsak. A példa ezeket az értékeket helyi változókba menti, majd elmenti a diagramot.

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

Használja a [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) metódust, hogy megcserélje a sorozatok és kategóriák szerepét a diagram adatainál. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává válik. Ez módosítja az adatok csoportosítását; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) metódust használja, hogy a alapértelmezett adatokat a `Sheet1!A1:D5` tartományra kötse, beleértve a fejlécsort és a kategóriaoszlopot, mielőtt sorokat és oszlopokat cserélne. Egy négy sorozatos és három kategóriás diagramot ment el.

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

## **Egy tengely ábrázolási sorrendjének megfordítása**

Használja a [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) metódust, hogy megfordítsa egy kategória vagy értéktengely sorrendjét. Például egy vízszintes oszlopdiagram megjelenítheti a projekt szakaszait felülről lefelé ugyanabban a sorrendben, mint a munkalapon: tervezés, fejlesztés, tesztelés. A tengely megfordítása megváltoztatja a rajzolási irányt; nem rendezi vagy átrendezi a munkafüzet adatokat. Ezzel szemben a [switchRowColumn](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#switchRowColumn) megcseréli a sorozatok és kategóriák szerepét.

Az alábbi példa egy három szakaszos és egy sorozatos vízszintes oszlopdiagramot hoz létre. Egy prezentációt ment három diával: normál sorrend, megfordított kategóriák és megfordított értékek. Minden másolat ugyanazt az adatkészletet használja, és minden másolaton csak egy tengely van megfordítva.

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

    # Dia 2: az első kategória megjelenítése felül.
    category_slide = presentation.getSlides().addClone(slide)
    category_chart = category_slide.getShapes().get_Item(0)
    category_chart.getAxes().getVerticalAxis().setPlotOrderReversed(True)
    # A vízszintes értéktengely megtartása alul.
    category_chart.getAxes().getVerticalAxis().setCrossType(CrossesType.Maximum)

    # Dia 3: csak a vízszintes numerikus skála megfordítása.
    value_slide = presentation.getSlides().addClone(slide)
    value_chart = value_slide.getShapes().get_Item(0)
    value_chart.getAxes().getHorizontalAxis().setPlotOrderReversed(True)

    presentation.save("ReversedAxes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A tengely megfordítása a merőleges tengelyt a diagram másik oldalára is helyezheti. A [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) szabályozza, hogy a másik tengely hol metszi a konfigurált tengelyt. A 2. dián a [CrossesType.Maximum](https://reference.aspose.com/slides/python-java/aspose.slides/crossestype/#Maximum) használata a megfordított kategóriatengelyen megtartja a vízszintes értéktengelyt alul. Egy konkrét metszésponthoz használja a [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt). Ellenőrizze a metszés beállításait irányváltáskor, különösen ha a diagram már egy egyéni metszésponttal rendelkezik. A [setPlotOrderReversed](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setPlotOrderReversed) `False` értékkel visszaállítja a normál rajzolási irányt; a metszés beállításai különállóak.

| Normál sorrend (dia 1) | Megfordított kategóriák (dia 2) | Megfordított értékek (dia 3) |
| --- | --- | --- |
| ![Normál kategória‑ és értéktengely sorrendű vízszintes oszlopdiagram](axis-order-normal.png) | ![Vízszintes oszlopdiagram, ahol a kategóriák felülről lefelé jelennek meg](axis-order-categories-reversed.png) | ![Vízszintes oszlopdiagram megfordított értéktengellyel, a nulla jobbra mutat](axis-order-values-reversed.png) |
| A kategóriák alulról felfelé haladnak; az értékek balról jobbra nőnek. | Tervezés, fejlesztés és tesztelés felülről lefelé halad. Az értékek és a munkafüzet sorainak sorrendje változatlan. | A kategóriák megtartják normál sorrendjüket; az értékek jobbról balra nőnek. A kategóriatengely a jobb oldalon nullánál metszi. |

## **A függőleges tengely letiltása vonaldiagramokhoz**

Hívja meg a [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) metódust `False` értékkel a függőleges tengelyen, hogy elrejtse. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, majd elmenti a függőleges tengely rejtve.

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

## **A vízszintes tengely letiltása vonaldiagramokhoz**

Hívja meg a [setVisible](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setVisible) metódust `False` értékkel a vízszintes tengelyen, hogy elrejtse. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, majd elmenti a vízszintes tengely rejtve.

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

## **Diagram rácsvonalainak megjelenítése vagy elrejtése**

Hívja meg a [getShowMajorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMajorGridLines) és a [getShowMinorGridLines](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getShowMinorGridLines) metódusokat, hogy megállapítsa, mely rácsvonalakat jeleníti meg egy tengely. A kisebb rácsvonalak megjelenítéséhez használja a [getMinorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMinorGridLinesFormat) metódust, és állítsa be a vonalfeltöltést egy szilárd, látható színre. Elrejtéshez állítsa a feltöltést a [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/#NoFill) értékre. A fő rácsvonalak színének módosításához használja a [getMajorGridLinesFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getMajorGridLinesFormat) metódust ugyanígy. A feltöltés módosítása megőrzi a tengely láthatóságát és a jelölőket.

Ennek a csoportosított oszlopdiagramnak a függőleges tengelye eleinte csak fő rácsvonalakat jelenít meg. A példa először sötét narancssárga kisebb rácsvonalakat mutat, majd elrejti ezeket, mielőtt elmentené a prezentációt. Minden lépésben kiírja a rácsvonalak láthatóságát.

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

| Kisebb rácsvonalak engedélyezve | Kisebb rácsvonalak rejtve |
| --- | --- |
| ![Narancssárga kisebb rácsvonalak a fő rácsvonalak között a függőleges tengelyen](minor-gridlines-enabled.png) | ![Ugyanaz a oszlopdiagram, csak a fő rácsvonalak láthatók](minor-gridlines-hidden.png) |

## **Kategóriatengely módosítása**

Használja a [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) metódust, hogy dátum‑ vagy szöveges kategóriatengelyt válasszon. Ez a példa az `ExistingChart.pptx` fájlt igényli, amelynek első diáján az első alakzat egy diagram, a kategória cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátumtengellyé változtatja. A [setAutomaticMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticMajorUnit) `False`, a [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) `1`, valamint a [setMajorUnitScale](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnitScale) [TimeUnitType.Months](https://reference.aspose.com/slides/python-java/aspose.slides/timeunittype/#Months) használata havi fő jelölőket eredményez.

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

### **A kategóriatengely típusának meghatározása adatokból**

A kategóriák betöltése után hívja meg a [setCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisTypeAutomatically) metódust, majd olvassa ki a [getCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#getCategoryAxisType) értéket a választás ellenőrzéséhez. Ez akkor hasznos, ha ugyanaz a diagram szöveges címkéket vagy numerikus dátumértékeket kap. A módszer a híváskor meghatározza a típust; nem aktivál tartós módot, amely későbbi adatmódosításokat újraértékelné. Hívja meg újra a kategóriák cseréje után.

Az alábbi példa egy szöveges kategóriákat tartalmazó diagramot hoz létre, és `True` értéket kiír, ha a kiválasztott típus a [CategoryAxisType.Text](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Text). Ezután a kategória cellaértékeket dátumokra cseréli, újra meghívja a metódust, és `True` értéket kiír, ha a kiválasztott típus a [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date). A dátumok numerikus OLE Automation értékekként tárolódnak, amelyek a 1899. december 30. óta eltelt napok számát jelentik, nem dátumkarakterláncokként. A [setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) szabályozza, hogyan jelennek meg ezek az értékek; nem konvertálja a szöveget numerikus dátumokká. További információkért a kategória cellákról lásd a [Chart Workbook](/slides/hu/python-java/chart-workbook/) oldalt.

Használja az automatikus meghatározást, ha a bemenet szöveges kategóriákat vagy numerikus dátumokat tartalmaz, ahogyan ebben a példában is. Általános numerikus címkék, vegyes kategóriák vagy üres adatok esetén expliciten hívja meg a [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) metódust a kívánt jelentésnek megfelelően. Csak numerikus értékek önmagukban nem bizonyítják, hogy a kategóriák dátumokat jelentenek.

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
    print(axis.getCategoryAxisType() == CategoryAxisType.Text)  # Igaz

    base_date = date(1899, 12, 30)
    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.getCell(0, i + 1, 0)
        category_cell.setValue(float((category_date - base_date).days))
        category_cell.setCustomNumberFormat("yyyy-mm-dd")

    axis.setCategoryAxisTypeAutomatically()
    print(axis.getCategoryAxisType() == CategoryAxisType.Date)  # Igaz

    presentation.save("AutomaticCategoryAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kategóriatengely címkeintervallumok vezérlése**

Amikor egy diagram sok kategóriát tartalmaz, csökkentheti a látható tengelycímkék számát anélkül, hogy eltávolítaná a kategóriákat vagy adatpontokat. Hívja meg a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickLabelSpacing) metódust `False` értékkel, majd adja át a kívánt kategóriaintervallumot a [setTickLabelSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelSpacing) metódusnak. Szöveges kategóriák esetén a normál sorrendben a számlálás az első kategóriától indul:

| Intervallum | A példában megjelenített címkék |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

A `3` intervallum minden harmadik címkét jelenít meg, és két címke marad rejtve a megjelenített címkék között. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

A jelölőket külön lehet szabályozni. Hívja meg a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAutomaticTickMarksSpacing) metódust `False` értékkel, és használja a [setTickMarksSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickMarksSpacing) metódust az intervallum beállításához. Például az `1` minden kategóriaintervallumban jelölőt helyez el, míg a címkék csak minden harmadik kategóriánál jelennek meg. A [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) látható stílussal segíti az eredmény megtekintését. Az automatikus beállítások `True` értékkel való visszahívása ismét a diagramra bízza az intervallum kiválasztását.

Az alábbi önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment el a `CategoryAxisIntervals.pptx` fájlba: automatikus távolság, manuális címke-távolság független jelölőkkel, és visszaállított automatikus távolság. A két másolat az eredeti diagramadatokat őrzi. Bemeneti prezentációra nincs szükség. A vízszintes címkeszöveg megkönnyíti a sűrűség különbségének felismerését.

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

    # Dia 2: minden harmadik címke megjelenítése, de jelölő megtartása minden kategóriához.
    manual_slide = presentation.getSlides().addClone(slide)
    manual_chart = manual_slide.getShapes().get_Item(0)
    manual_axis = manual_chart.getAxes().getHorizontalAxis()
    manual_axis.setAutomaticTickLabelSpacing(False)
    manual_axis.setTickLabelSpacing(3)
    manual_axis.setAutomaticTickMarksSpacing(False)
    manual_axis.setTickMarksSpacing(1)

    # Dia 3: hagyja, hogy a diagram újra kiválassza mindkét intervallumot.
    restored_slide = presentation.getSlides().addClone(manual_slide)
    restored_chart = restored_slide.getShapes().get_Item(0)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(True)
    restored_chart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(True)

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Automatikus távolság (dia 1):** Ebben a megjelenítésben minden második kategóriacímke látható, és két sorra törik. Az automatikus eredmény a diagram méretétől, betűtípusától és a renderertől függően változhat.

![Automatikus kategóriacímke-távolság, az összes 24 oszlop látható](category-axis-automatic.png)

**Manuális távolság (dia 2):** Minden harmadik címke jelenik meg egy sorban, míg a jelölők minden kategóriaintervallumban maradnak. Az összes 24 oszlop, beleértve a címke nélküli oszlopokat is, látható ugyanazzal az értékkel. A 3. dia visszaállítja a fenti automatikus megjelenést.

![Manuális háromas kategóriacímke-intervallum, az összes 24 oszlop látható](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Ezt a kategóriaszám-intervallumot szöveges kategóriatengelyhez használja, például oszlop-, vonal-, terület- vagy oszlopdiagram kategóriatengelyéhez. Oszlopdiagram esetén ez a vízszintes tengely. Vízszintes oszlopdiagram esetén a kategóriatengely függőleges, ezért alkalmazza ezeket a beállításokat a [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) által visszaadott tengelyre. A jelölőtávolság sorozattengelyekre is vonatkozik, ha a diagram rendelkezik ilyennel.

Ne használja a kategóriacímke-távolságot a értéktengely numerikus skálájának beállításához. Értéktengelyen a [setMajorUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorUnit) egy értékbeli különbséget határoz meg: például a `10` főegység 0, 10, 20 stb. jelölőket eredményez, ha a tengely nulláról indul. A `3` kategóriacímke-intervallum ezzel szemben a kategóriahelyeket számolja, függetlenül azok adatértékétől. Szórt és buborékdiagramok értéktengelyt használnak, nem szöveges kategóriatengelyt. Dátumtengely esetén használjon időalapú fő egységeket és skálákat, ahogy a [Kategóriatengely módosítása](#change-a-category-axis) részben leírták.

## **A kategóriatengely értékek dátumformátumának beállítása**

A példa a alapértelmezett diagramadatokat négy éves értékre cseréli. A dátumok OLE Automation sorozatszámként tárolódnak az első munkalapon (index `0`), a 1899. december 30. óta eltelt napok számaként számítva. Használja a [setCategoryAxisType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCategoryAxisType) metódust [CategoryAxisType.Date](https://reference.aspose.com/slides/python-java/aspose.slides/categoryaxistype/#Date) értékkel, a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) `False` beállítással, és adja át a `yyyy` formátumot a [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) metódusnak, hogy a kategóriacímkék négyjegyű évet jelenítsenek meg, függetlenül a cella formázásától.

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

## **Tengelycím forgatási szögének beállítása**

Hívja meg a [setTitle](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTitle) metódust `True` értékkel a függőleges tengelyen, adjon meg címszöveget, és állítsa be a forgatási szöget a cím szövegtömbjének formázásában. A szög fokokban mérve; ez a példa egy oszlopdiagramot ment el, amelynek értéktengely-címe 90 fokban van elforgatva.

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

## **A tengely helyének beállítása kategória- vagy értéktengelyen**

Használja a [setAxisBetweenCategories](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setAxisBetweenCategories) metódust, hogy szabályozza, az értéktengely a kategóriatengelyet a kategóriák között vagy a kategória jelölőknél metszze. Ez a beállítás a kategóriatengelyekre vonatkozik. A példa a vízszintes kategóriatengelyen `True` értékkel állítja be egy oszlopdiagramon, és elmenti az eredményt.

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

## **Megjelenítési egység beállítása diagram értéktengelyen**

Használja a [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) metódust, hogy a címkéket egy értéktengelyen átméretezze anélkül, hogy a mögöttes adatokat módosítaná. A [DisplayUnitType](https://reference.aspose.com/slides/python-java/aspose.slides/displayunittype/) `Millions` értékével a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyen a milliók megjelenítési egységét alkalmazza.

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

A logaritmikus értéktengely akkor hasznos, ha a pozitív értékek több nagyságrendben terjednek. Például egy szolgáltatás öt időszak alatt 10, 100, 1 000, 10 000 és 100 000 kérésre kap válasz. Lineáris skálán a kisebb értékek szorosan, a nulla közelében helyezkednek el. Logaritmikus skála esetén a relatív növekedés könnyebben összehasonlítható: az egyenlő távolságok azonos arányt, nem azonos különbséget jelentenek.

Hívja meg a [setLogarithmic](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogarithmic) metódust `True` értékkel az értéktengelyen, és használja a [setLogBase](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setLogBase) metódust az alap kiválasztásához. Ez megváltoztatja a meglévő értékek megjelenítését; nem módosítja az adatokat, és nem ad hozzá logaritmikus trendvonalat. A trendvonal adatfüggő illesztett kapcsolatot jelent, és külön funkció.

### **Az értéktengely és az alap kiválasztása**

Vonal vagy oszlop diagram esetén az értéktengely a [getVerticalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getVerticalAxis) által visszaadott. Vízszintes oszlopdiagram esetén a [getHorizontalAxis](https://reference.aspose.com/slides/python-java/aspose.slides/axesmanager/#getHorizontalAxis) adja vissza. Szórt és buborék diagramok két értéktengellyel rendelkeznek, ezért válassza a vízszintes tengelyt az X értékekhez, a függőleges tengelyt az Y értékekhez, vagy mindkettőt. Ne alkalmazzon logaritmikus skálázást kategóriatengelyen.

Az alapértelmezett logaritmikus alap a `10`. PPTX diagramok esetén a `2` és `1000` közötti (beleértve) alapok használhatók; a törtalapú értékek, például `2.5`, szintén támogatottak. A `10` alap esetén a 10, 100, 1 000 és 10 000 egymás utáni hatványok egyenlő távolságra helyezkednek el.

### **Lineáris és logaritmikus skálázás összehasonlítása**

Az alábbi önálló példa egy vonaldiagramot hoz létre, amelyben az öt kérés száma az első dián jelenik meg, majd a második diát lemásolja és bekapcsolja a 10‑es alapú logaritmikus értéktengelyt. Mindkét dia ugyanazt az adatot tartja meg.

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

    # Az első diát hagyja lineárisnak, és csak a másolat értéktengelyének skáláját módosítsa.
    logarithmic_slide = presentation.getSlides().addClone(slide)
    logarithmic_chart = logarithmic_slide.getShapes().get_Item(0)
    value_axis = logarithmic_chart.getAxes().getVerticalAxis()
    value_axis.setLogarithmic(True)
    value_axis.setLogBase(10)

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

**Lineáris skála (dia 1):** Az egyenlő függőleges távolságok egyenlő különbségeket jelentnek a kérés számában. A legnagyobb érték uralja a diagramot, így a kisebb értékek nehezen megkülönböztethetők.

![Vonaldiagram PowerPointban, amely öt kérésszámot mutat lineáris értéktengelyen](value-axis-linear.png)

**Logaritmikus skála (dia 2):** Az egyenlő függőleges távolságok egyenlő arányt jelentenek. Minden időszak tízszer több kérést kap, mint az előző, így a pontok egy egyenes, emelkedő vonalat alkotnak a 10‑es alapú skálán. A tengelycímkék továbbra is az eredeti kérésszámokat mutatják.

![Ugyanazon öt kérésszám PowerPointban egy 10‑es alapú logaritmikus értéktengelyen](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

Logaritmikus skála csak szigorúan pozitív értékeket jeleníthet meg. Ellenőrizze az adatokat, mielőtt engedélyezi. Ha a nulla vagy negatív értékek jelentőséggel bírnak, használjon lineáris skálát, vagy jelenítse meg őket külön. Ha az értékek kizárása megfelelő az elemzéshez, magyarázza meg a kihagyást. Ne cserélje őket automatikusan kis pozitív számokra, mert ezzel megváltoztatja az adatok jelentését. Bármely, kézzel beállított minimum vagy maximum logaritmikus tengely esetén is pozitívnak kell lennie.

## **GYIK**

**Hogyan állítható be az a pont, ahol az egyik tengely a másikat metszi (tengelymetszés)?**

Használja a [setCrossType](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossType) metódust a metszési viselkedés kiválasztásához. Numerikus metszési érték megadásához hívja meg a [setCrossAt](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setCrossAt) metódust. Ezek a beállítások lehetővé teszik a tengelymetszés áthelyezését egy megfelelő alapvonalra.

**Hogyan helyezhetők el a jelölőcímkék viszonylag a tengelyhez?**

Hívja meg a [setTickLabelPosition](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setTickLabelPosition) metódust a [TickLabelPositionType](https://reference.aspose.com/slides/python-java/aspose.slides/ticklabelpositiontype/) valamelyikével: `Low`, `High`, `NextTo` vagy `None`. A jelölőket magukat a [setMajorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMajorTickMark) vagy a [setMinorTickMark](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setMinorTickMark) metódusokkal szabályozhatja; ezek különállnak a címkepozíciótól.