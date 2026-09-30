---
title: Diagram jelmagyarázatának testreszabása prezentációkban Python használatával
linktitle: Diagram jelmagyarázat
type: docs
url: /hu/python-java/chart-legend/
keywords:
- diagram jelmagyarázat
- jelmagyarázat pozíció
- betűméret
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Testreszabja a diagram jelmagyarázatát az Aspose.Slides for Python via Java segítségével, hogy a PowerPoint prezentációkat a legendák egyedi formázásával optimalizálja."
---
## **Áttekintés**

Az Aspose.Slides for Python via Java lehetőséget biztosít a diagram jelmagyarázatának testreszabására a PowerPoint‑prezentációkban. Ez a cikk bemutatja, hogyan lehet elhelyezni és méretezni egy jelmagyarázatot, beállítani a teljes jelmagyarázat betűméretét, egy adott jelmagyarázati bejegyzést formázni, valamint elrejteni vagy visszaállítani a kiválasztott bejegyzéseket.

Az FAQ kapcsolódó viselkedéseket fed le, beleértve a jelmagyarázat számára fenntartott helyet, a több soros címkék megjelenítését és a formázás öröklését a prezentáció témájától.

## **Jelmagyarázat pozicionálása**

Használja a jelmagyarázat [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth) és [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) metódusait a pozíció és a méret megadásához a diagram dimenzióinak tört részében.

Ez a példa létrehoz egy prezentációt, és az első diára egy csoportosított oszlopdiagramot ad hozzá alapértelmezett adatokkal. A kívánt jelmagyarázati eltolásokat és méreteket a diagram szélességével és magasságával osztva relatív értékekké konvertálja: a jelmagyarázat 50 ponttal van eltolva a diagram bal felső sarkától, és 100 × 100 pont méretű.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # A legend pozíciójának és méretének kifejezése a diagramhoz képest.
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **A jelmagyarázat betűméretének beállítása**

Használja a jelmagyarázat [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) metódusát a szövegformázás eléréséhez, és a [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) metódust a betűméret pontban történő beállításához.

Ez a példa létrehoz egy diagramot alapértelmezett adatokkal, és a jelmagyarázat szövegét 20 pontra állítja. Emellett letiltja a függőleges tengely automatikus határait, és a tartományt -5‑tól 10‑ig állítja be.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Egyéni jelmagyarázati bejegyzés betűméretének beállítása**

Használja a jelmagyarázat [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries) metódusa által visszaadott gyűjteményt egy adott bejegyzés formázásához. A bejegyzés indexelése nullától indul, így az `1` index a második bejegyzést jelöli.

Ez a példa létrehoz egy csoportosított oszlopdiagramot, amelynek alapértelmezett adatai legalább két sorozatot tartalmaznak. Formázza a második jelmagyarázati bejegyzést félkövér, dőlt, 20 pontos kék szöveggel.

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

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Egyéni jelmagyarázati bejegyzések elrejtése**

Egy segédsorozat kizárásához a jelmagyarázatból, miközben az adatokat láthatóan megtartja, hívja meg a [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) metódust `True` értékkel a [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry) segítségével. Ez csak a kiválasztott jelmagyarázati bejegyzést rejti el; a sorozatot vagy az adatpontokat nem távolítja el. Ezzel szemben a [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) `False` értékkel történő hívása az egész jelmagyarázatot elrejti.

Az alábbi példa egy csoportosított oszlopdiagramot hoz létre több sorozattal alapértelmezett adatokkal. Elrejti a második sorozat jelmagyarázati bejegyzését (index `1`), majd elmenti a prezentációt. Ezután a [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) `False` értékkel való meghívásával visszaállítja a bejegyzést, és egy második másolatot ment el. Az oszlopok mindkét fájlban láthatóak maradnak.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # A bejegyzés visszaállítása a diagram adatait módosítás nélkül.
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az alábbi összehasonlítás ugyanazt a diagramot mutatja, egyszer az összes bejegyzés látható, egyszer a második bejegyzés rejtve. A második sorozat oszlopai változatlanok maradnak.

![Comparison of a chart with all legend entries visible and with Series 2 hidden from the legend; all columns remain visible.](hide-legend-entry.png)

Oszlop-, sáv‑ és vonaldiagramok esetén a jelmagyarázati bejegyzések a sorozatokat azonosítják. Kördiagramoknál egyedi adatelempontokat (szeleteket) jelölnek, ezért a kiválasztott szeletre a [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) metódust kell használni. Az API ezt a metódust dokumentálja a `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` és `BarOfPie` diagramtípusoknál. Ne tételezze, hogy ez a fánkkör diagramokra is vonatkozik, amelyek nincsenek a listában.

## **FAQ**

**Készíthetek úgy a diagramot, hogy helyet foglaljon a jelmagyarázatnak a felülírás helyett?**

Igen. Hívja meg a [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) metódust `False` értékkel, hogy a jelmagyarázat számára helyet foglaljon a felület átfedése helyett.

**Készíthetek több soros jelmagyarázati címkéket?**

Igen. A hosszú címkék megtörhetnek, ha a rendelkezésre álló szélesség nem elegendő. Új sor karaktereket is beilleszthet a sorozatnevekbe a sortörés kéréséhez.

**Hogyan tehetem a jelmagyarázatot a prezentáció téma színsémájához igazítottá?**

Hagyja a jelmagyarázat színeit, kitöltéseit és betűtípusait beállítatlanul, hogy örökölje a téma formázását. A kifejezett formázás felülbírálja a megfelelő téma beállításokat.