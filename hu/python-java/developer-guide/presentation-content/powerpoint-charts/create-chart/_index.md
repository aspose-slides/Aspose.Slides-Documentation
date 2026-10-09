---
title: PowerPoint prezentáció diagramjainak létrehozása vagy frissítése Pythonban
linktitle: Diagramok létrehozása vagy frissítése
type: docs
weight: 10
url: /hu/python-java/create-chart/
keywords:
- diagram hozzáadása
- diagram létrehozása
- diagram szerkesztése
- diagram módosítása
- diagram frissítése
- szórásdiagram
- kördiagram
- vonaldiagram
- fa térképes diagram
- részvénydiagram
- doboz- és szárnydiagram
- tölcsérdiagram
- sunburst diagram
- hisztogram diagram
- radar diagram
- többkategóriás diagram
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Diagramok létrehozása és testreszabása PowerPoint prezentációkban az Aspose.Slides for Python via Java használatával. Diagramok hozzáadása, formázása és szerkesztése gyakorlati Python kódpéldákkal."
---
## **Áttekintés**

Ez a cikk átfogó útmutatót nyújt a diagramok létrehozásához és testreszabásához az Aspose.Slides használatával. Megtanulja, hogyan lehet programozott módon diagramot hozzáadni egy diához, adatokat betölteni, és különféle formázási beállításokat alkalmazni a specifikus tervezési követelményekhez. A cikk során részletes kódpéldák illusztrálják az egyes lépéseket, az előadás és a diagramobjektum inicializálásától a sorozatok, tengelyek és jelmagyarázatok konfigurálásáig. Az útmutató követésével alapos megértést szerez a dinamikus diagramgenerálás integrálásáról alkalmazásaiba, ezáltal leegyszerűsítve az adat‑vezérelt prezentációk elkészítését.

## **Diagram létrehozása**

A diagramok segítenek az embereknek gyorsan megjeleníteni az adatokat és felismerni azokat a meglátásokat, amelyek nem feltétlenül láthatók egy táblázatból vagy egy táblázatkezelőből.

**Miért hozzunk létre diagramokat?**

Diagramokkal:

* nagymennyiségű adatot aggregálni, sűríteni vagy összefoglalni egyetlen dián egy prezentációban
* felfedni az adatokban rejlő mintákat és trendeket
* meghatározni az adatok irányát és lendületét az idő múlásával vagy egy adott mérőegységhez viszonyítva
* azonosítani kiugró értékeket, eltéréseket, hibákat, értelmetlen adatokat stb.
* kommunikálni vagy bemutatni összetett adatokat

A PowerPointban a *Beszúrás* funkcióval hozhatók létre diagramok, amely sablonokat biztosít számos diagramtípus megtervezéséhez. Az Aspose.Slides segítségével létrehozhatunk mind szabványos diagramokat (népszerű diagramtípusokon alapulókat), mind egyedi diagramokat.

{{% alert color="info" title="Note" %}}
A diagramok létrehozásához használja a [ChartType](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) osztályt. Ennek az osztálynak a mezői a különböző diagramtípusoknak felelnek meg.
{{% /alert %}}

### **Csoportosított oszlopdiagramok létrehozása**

Ez a szakasz bemutatja, hogyan hozhatók létre csoportosított oszlopdiagramok az Aspose.Slides használatával. Megtanulja, hogyan kell inicializálni egy prezentációt, diagramot hozzáadni, és testreszabni annak elemeit, mint például címet, adatokat, sorozatokat, kategóriákat és stílusokat. Kövesse az alábbi lépéseket, hogy lássa, hogyan generálódik egy szabványos csoportosított oszlopdiagram:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot némi adatokkal, és adja meg a `ChartType.ClusteredColumn` típust.
4. Adjon címet a diagramhoz.
5. Érje el a diagram adat‑munkalapját.
6. Törölje az összes alapértelmezett sorozatot és kategóriát.
7. Adjon hozzá új sorozatokat és kategóriákat.
8. Adjon hozzá új diagramadatokat a diagram sorozatokhoz.
9. Alkalmazzon kitöltőszínt a diagram sorozatokra.
10. Adjon címkéket a diagram sorozatokhoz.
11. Mentse a módosított prezentációt PPTX fájlként.

Ez a C# kód bemutatja, hogyan hozható létre egy csoportosított oszlopdiagram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Példányosít egy prezentációosztályt, amely egy PPTX fájlt képvisel.
presentation = Presentation()
try:
    # Eléri az első diát
    slide = presentation.getSlides().get_Item(0)

    # Diagramot ad hozzá alapértelmezett adatokkal
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 0, 0, 500, 500)

    # Beállítja a diagram címét
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Beállítja a diagram adatlap indexét
    default_worksheet_index = 0

    # Lekéri a diagram adatlapját
    workbook = chart.getChartData().getChartDataWorkbook()

    # Törli az alapértelmezett generált sorozatokat és kategóriákat
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Új sorozatokat ad hozzá
    cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell,chart.getType())
    cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell,chart.getType())

    # Új kategóriákat ad hozzá
    cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)

    # Lekéri az első diagram sorozatot
    series = chart.getChartData().getSeries().get_Item(0)

    # Most feltölti a sorozat adatait
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Beállítja a sorozat kitöltőszínét
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    # Lekéri a második diagram sorozatot
    series = chart.getChartData().getSeries().get_Item(1)

    # Feltölti a sorozat adatait
    cell = workbook.getCell(default_worksheet_index, 1, 2, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 2, 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 2, 60)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Beállítja a sorozat kitöltőszínét
    series.getFormat().getFill().setFillType(FillType.Solid)
    series.getFormat().getFill().getSolidFillColor().setColor(Color.GREEN)

    #Készít egyéni címkéket az új sorozat minden kategóriájához
    # Beállítja az első címkét, hogy a kategória nevét mutassa
    label = series.getDataPoints().get_Item(0).getLabel()
    label.getDataLabelFormat().setShowCategoryName(True)

    label = series.getDataPoints().get_Item(1).getLabel()
    label.getDataLabelFormat().setShowSeriesName(True)

    # Megjeleníti az értéket a harmadik címkén
    label = series.getDataPoints().get_Item(2).getLabel()
    label.getDataLabelFormat().setShowValue(True)
    label.getDataLabelFormat().setShowSeriesName(True)
    label.getDataLabelFormat().setSeparator("/")

    # Mentés a diagrammal a prezentációba
    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Szórásdiagramok létrehozása**

A szórásdiagramok (más néven szóráspontdiagramok vagy x‑y grafikonok) gyakran használatosak minták keresésére vagy két változó közötti korreláció bemutatására.

Használjon szórásdiagramot, ha:

* párosított numerikus adatai vannak
* két változója van, amely jól összeillik
* meg szeretné határozni, hogy a két változó összefügg-e
* független változója több értékkel rendelkezik egy függő változóra vonatkozóan

1. Kövesse a [Csoportosított oszlopdiagramok létrehozása](#create-clustered-column-charts) lépéseit.
2. A harmadik lépésnél adjon hozzá egy diagramot némi adatokkal, és adja meg a diagram típusát az alábbiak közül:
   1. [ChartType.ScatterWithMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithMarkers) - _Egy szórásdiagramot képvisel._
   2. [ChartType.ScatterWithSmoothLinesAndMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithSmoothLinesAndMarkers) - _Egy görbékkel összekapcsolt szórásdiagramot képvisel, adatjelölőkkel._
   3. [ChartType.ScatterWithSmoothLines](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithSmoothLines) - _Görbékkel összekapcsolt szórásdiagram, adatjelölők nélkül._
   4. [ChartType.ScatterWithStraightLinesAndMarkers](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithStraightLinesAndMarkers) - _Vonalakkal összekapcsolt szórásdiagram, adatjelölőkkel._
   5. [ChartType.ScatterWithStraightLines](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ScatterWithStraightLines) - _Vonalakkal összekapcsolt szórásdiagram, adatjelölők nélkül._

Ez a Python kód bemutatja, hogyan hozható létre szórásdiagram különböző jelölőkkel minden sorozathoz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, MarkerStyleType, Presentation, SaveFormat

    # Példányosít egy prezentációosztályt, amely egy PPTX fájlt képvisel.
presentation = Presentation()
try:
    # Eléri az első diát
    slide = presentation.getSlides().get_Item(0)

    # Létrehozza az alapértelmezett diagramot
    chart = slide.getShapes().addChart(ChartType.ScatterWithSmoothLines, 0, 0, 400, 400)

    # Lekéri az alapértelmezett diagram adatlap indexét
    default_worksheet_index = 0

    # Lekéri a diagram adatlapját
    workbook = chart.getChartData().getChartDataWorkbook()

    # Törli a demo sorozatot
    chart.getChartData().getSeries().clear()

    # Új sorozatokat ad hozzá
    cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(default_worksheet_index, 1, 3, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # Lekéri az első diagram sorozatot
    series = chart.getChartData().getSeries().get_Item(0)

    # Új pontot (1:3) ad hozzá a sorozathoz
    x_cell = workbook.getCell(default_worksheet_index, 2, 1, 1)
    y_cell = workbook.getCell(default_worksheet_index, 2, 2, 3)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Új pontot (2:10) ad hozzá
    x_cell = workbook.getCell(default_worksheet_index, 3, 1, 2)
    y_cell = workbook.getCell(default_worksheet_index, 3, 2, 10)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Módosítja a sorozat típusát
    series.setType(ChartType.ScatterWithStraightLinesAndMarkers)

    # Módosítja a diagram sorozat jelölőjét
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Star)

    # Lekéri a második diagram sorozatot
    series = chart.getChartData().getSeries().get_Item(1)

    # Új pontot (5:2) ad hozzá ott
    x_cell = workbook.getCell(default_worksheet_index, 2, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 2, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Új pontot (3:1) ad hozzá
    x_cell = workbook.getCell(default_worksheet_index, 3, 3, 3)
    y_cell = workbook.getCell(default_worksheet_index, 3, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Új pontot (2:2) ad hozzá
    x_cell = workbook.getCell(default_worksheet_index, 4, 3, 2)
    y_cell = workbook.getCell(default_worksheet_index, 4, 4, 2)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Új pontot (5:1) ad hozzá
    x_cell = workbook.getCell(default_worksheet_index, 5, 3, 5)
    y_cell = workbook.getCell(default_worksheet_index, 5, 4, 1)
    series.getDataPoints().addDataPointForScatterSeries(x_cell, y_cell)

    # Módosítja a diagram sorozat jelölőjét
    series.getMarker().setSize(10)
    series.getMarker().setSymbol(MarkerStyleType.Circle)

    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kördiagramok létrehozása**

A kördiagramok leginkább a részek és az egész közötti kapcsolatok bemutatására alkalmasak, különösen akkor, ha az adatok kategóriákat tartalmaznak numerikus értékekkel. Ha azonban az adatok sok részt vagy címkét tartalmaznak, érdemes inkább oszlopdiagramot használni.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Pie](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Pie) típust.
4. Érje el a diagram adatmunkafüzetét a [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) segítségével.
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozatokhoz.
8. Adjon hozzá új pontokat a diagramhoz, és alkalmazzon egyéni színeket a kördiagram szeleteihez.
9. Állítsa be a sorozat címkéit.
10. Engedélyezze a vezetővonalakat a sorozatcímkékhez.
11. Állítsa be a kördiagram szeleteinek forgásszögét.
12. Mentse a módosított prezentációt PPTX fájlként.

Ez a Python kód bemutatja, hogyan hozható létre egy kördiagram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineDashStyle, LineStyle, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Példányosít egy prezentációosztályt, amely egy PPTX fájlt képvisel.
presentation = Presentation()
try:
    # Eléri az első diát
    slide = presentation.getSlides().get_Item(0)

    # Diagramot ad hozzá alapértelmezett adatokkal
    chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400)

    # Beállítja a diagram címét
    chart.getChartTitle().addTextFrameForOverriding("Sample Title")
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True_)
    chart.getChartTitle().setHeight(20)
    chart.setTitle(True)

    # Beállítja a diagram adatlap indexét
    default_worksheet_index = 0

    # Lekéri a diagram adatlapját
    workbook = chart.getChartData().getChartDataWorkbook()

    # Törli az alapértelmezett generált sorozatokat és kategóriákat
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    # Új kategóriákat ad hozzá
    cell = workbook.getCell(0, 1, 0, "First Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "2nd Qtr")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "3rd Qtr")
    chart.getChartData().getCategories().add(cell)

    # Új sorozatokat ad hozzá
    cell = workbook.getCell(0, 0, 1, "Series 1")
    series = chart.getChartData().getSeries().add(cell, chart.getType())

    #Feltölti a sorozat adatait
    cell = workbook.getCell(default_worksheet_index, 1, 1, 20)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 1, 50)
    series.getDataPoints().addDataPointForPieSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 1, 30)
    series.getDataPoints().addDataPointForPieSeries(cell)

    # Új pontok hozzáadása és a szektor színének beállítása
    chart.getChartData().getSeriesGroups().get_Item(0).setColorVaried(True)

    point = series.getDataPoints().get_Item(0)
    point.getFormat().getFill().setFillType(FillType.Solid)
    point.getFormat().getFill().getSolidFillColor().setColor(Color.CYAN)

    # Beállítja a szektor szegélyét
    point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    point.getFormat().getLine().setWidth(3.0)
    point.getFormat().getLine().setStyle(LineStyle.ThinThick)
    point.getFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    second_point = series.getDataPoints().get_Item(1)
    second_point.getFormat().getFill().setFillType(FillType.Solid)
    second_point.getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    # Beállítja a szektor szegélyét
    second_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    second_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    second_point.getFormat().getLine().setWidth(3.0)
    second_point.getFormat().getLine().setStyle(LineStyle.Single)
    second_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDot)

    third_point = series.getDataPoints().get_Item(2)
    third_point.getFormat().getFill().setFillType(FillType.Solid)
    third_point.getFormat().getFill().getSolidFillColor().setColor(Color.YELLOW)

    # Beállítja a szektor szegélyét
    third_point.getFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    third_point.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    third_point.getFormat().getLine().setWidth(2.0)
    third_point.getFormat().getLine().setStyle(LineStyle.ThinThin)
    third_point.getFormat().getLine().setDashStyle(LineDashStyle.LargeDashDotDot)

    # Egyéni címkéket hoz létre minden kategóriához az új sorozathoz
    first_label = series.getDataPoints().get_Item(0).getLabel()

    first_label.getDataLabelFormat().setShowValue(True)

    second_label = series.getDataPoints().get_Item(1).getLabel()
    second_label.getDataLabelFormat().setShowValue(True)
    second_label.getDataLabelFormat().setShowLegendKey(True)
    second_label.getDataLabelFormat().setShowPercentage(True)

    third_label = series.getDataPoints().get_Item(2).getLabel()
    third_label.getDataLabelFormat().setShowSeriesName(True)
    third_label.getDataLabelFormat().setShowPercentage(True)

    # Megjeleníti a vezetővonalakat a diagramon
    series.getLabels().getDefaultDataLabelFormat().setShowLeaderLines(True)

    # Beállítja a kördiagram szektorok forgásszögét
    chart.getChartData().getSeriesGroups().get_Item(0).setFirstSliceAngle(180)

    # Mentés diagrammal a prezentációt
    presentation.save("PieChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Vonaldiagramok létrehozása**

A vonaldiagramok (más néven vonalgrafikonok) leginkább akkor hasznosak, amikor az értékek időbeli változását kívánja bemutatni. Egy vonaldiagram segítségével egyszerre nagy mennyiségű adatot hasonlíthat össze, nyomon követheti az időbeli változásokat és trendeket, kiemelheti az anomáliákat az adat sorozatokban, és sok más feladatot is elvégezhet.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Line](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Line) típust.
4. Mentse a módosított prezentációt PPTX fájlként.

Ez a Python kód bemutatja, hogyan hozható létre egy vonaldiagram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Alapértelmezés szerint a vonaldiagram pontjai szintű, folyamatos vonalakkal vannak összekötve. Ha a pontokat vonalkavácsokkal szeretné összekötni, adja meg a kívánt vonalkavács típusát a következő módon:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LineDashStyle, Presentation, SaveFormat

presentation = Presentation()
try:
    line_chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Line, 10, 50, 600, 350)

    for series in line_chart.getChartData().getSeries():
        series.getFormat().getLine().setDashStyle(LineDashStyle.Dash)

    presentation.save("line_chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Fa térképes diagramok létrehozása**

A fa térképes diagramok leginkább értékesítési adatoknál használandók, amikor a kategóriák relatív méretét szeretné megjeleníteni, és gyorsan felhívni a figyelmet az egyes kategóriákon belüli nagy hozzájárulású elemekre.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Treemap](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Treemap) típust.
4. Érje el a diagram adatmunkafüzetét a [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) segítségével.
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozatokhoz.
8. Mentse a módosított prezentációt PPTX fájlként.

Ez a Python kód bemutatja, hogyan hozható létre egy fa térképes diagram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ParentLabelLayoutType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Treemap, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #ág 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #ág 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Treemap)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForTreemapSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForTreemapSeries(cell)

    series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("Treemap.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Részvénydiagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.OpenHighLowClose](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#OpenHighLowClose) típust.
4. Érje el a diagram adatmunkafüzetét a [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) segítségével.
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozatokhoz.
8. Adja meg a magas‑alacsony vonalak formátumát.
9. Mentse a módosított prezentációt PPTX fájlként.

Ez a Python kód bemutatja, hogyan hozható létre egy részvénydiagram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.OpenHighLowClose, 50, 50, 600, 400, False)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    cell = workbook.getCell(0, 1, 0, "A")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 0, "B")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 0, "C")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, 0, 1, "Open")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 2, "High")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 3, "Low")
    chart.getChartData().getSeries().add(cell, chart.getType())
    cell = workbook.getCell(0, 0, 4, "Close")
    chart.getChartData().getSeries().add(cell, chart.getType())

    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 1, 72)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 1, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 1, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(1)
    cell = workbook.getCell(0, 1, 2, 172)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 2, 57)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(2)
    cell = workbook.getCell(0, 1, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 3, 12)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 3, 13)
    series.getDataPoints().addDataPointForStockSeries(cell)

    series = chart.getChartData().getSeries().get_Item(3)
    cell = workbook.getCell(0, 1, 4, 25)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 2, 4, 38)
    series.getDataPoints().addDataPointForStockSeries(cell)
    cell = workbook.getCell(0, 3, 4, 50)
    series.getDataPoints().addDataPointForStockSeries(cell)

    chart.getChartData().getSeriesGroups().get_Item(0).getUpDownBars().setUpDownBars(True)
    chart.getChartData().getSeriesGroups().get_Item(0).getHiLowLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)

    for series in chart.getChartData().getSeries():
        series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Doboz- és szárnydiagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.BoxAndWhisker](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#BoxAndWhisker) típust.
4. Érje el a diagram adatmunkafüzetét a [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) segítségével.
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozatokhoz.
8. Mentse a módosított prezentációt PPTX fájlként.

Ez a Python kód bemutatja, hogyan hozható létre egy doboz‑ és szárnydiagram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, QuartileMethodType, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.BoxAndWhisker, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 1")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.BoxAndWhisker)

    series.setQuartileMethod(QuartileMethodType.Exclusive)
    series.setShowMeanLine(True)
    series.setShowMeanMarkers(True)
    series.setShowInnerPoints(True)
    series.setShowOutlierPoints(True)

    cell = workbook.getCell(0, "B1", 15)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B2", 41)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B3", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B4", 10)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B5", 23)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)
    cell = workbook.getCell(0, "B6", 16)
    series.getDataPoints().addDataPointForBoxAndWhiskerSeries(cell)

    presentation.save("BoxAndWhisker.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Tölcsérdiagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Funnel](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Funnel) típust.
4. Mentse a módosított prezentációt PPTX fájlként.

Ez a Python kód bemutatja, hogyan hozható létre egy tölcsérdiagram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Funnel, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()

    workbook.clear(0)

    cell = workbook.getCell(0, "A1", "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A2", "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A3", "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A4", "Category 4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A5", "Category 5")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, "A6", "Category 6")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Funnel)

    cell = workbook.getCell(0, "B1", 50)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B2", 100)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B3", 200)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B4", 300)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B5", 400)
    series.getDataPoints().addDataPointForFunnelSeries(cell)
    cell = workbook.getCell(0, "B6", 500)
    series.getDataPoints().addDataPointForFunnelSeries(cell)

    presentation.save("Funnel.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Sunburst diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Sunburst](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Sunburst) típust.
4. Mentse a módosított prezentációt PPTX fájlként.

Ez a Python kód bemutatja, hogyan hozható létre egy sunburst diagram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Sunburst, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    #ág 1
    cell = workbook.getCell(0, "C1", "Leaf1")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem1")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch1")

    cell = workbook.getCell(0, "C2", "Leaf2")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C3", "Leaf3")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem2")

    cell = workbook.getCell(0, "C4", "Leaf4")
    chart.getChartData().getCategories().add(cell)

    #ág 2
    cell = workbook.getCell(0, "C5", "Leaf5")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem3")
    leaf.getGroupingLevels().setGroupingItem(2, "Branch2")

    cell = workbook.getCell(0, "C6", "Leaf6")
    chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "C7", "Leaf7")
    leaf = chart.getChartData().getCategories().add(cell)
    leaf.getGroupingLevels().setGroupingItem(1, "Stem4")

    cell = workbook.getCell(0, "C8", "Leaf8")
    chart.getChartData().getCategories().add(cell)

    series = chart.getChartData().getSeries().add(ChartType.Sunburst)
    series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)
    cell = workbook.getCell(0, "D1", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D2", 5)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D3", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D4", 6)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D5", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D6", 9)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D7", 4)
    series.getDataPoints().addDataPointForSunburstSeries(cell)
    cell = workbook.getCell(0, "D8", 3)
    series.getDataPoints().addDataPointForSunburstSeries(cell)

    presentation.save("Sunburst.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Hisztogram diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.Histogram](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Histogram) típust.
4. Érje el a diagram adatmunkafüzetét a [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) segítségével.
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Mentse a módosított prezentációt PPTX fájlként.

Ez a Python kód bemutatja, hogyan hozható létre egy hisztogram diagram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AxisAggregationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Histogram, 50, 50, 500, 400)
    chart.getChartData().getCategories().clear()
    chart.getChartData().getSeries().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    series = chart.getChartData().getSeries().add(ChartType.Histogram)
    cell = workbook.getCell(0, "A1", 15)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A2", -41)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A3", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A4", 10)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A5", -23)
    series.getDataPoints().addDataPointForHistogramSeries(cell)
    cell = workbook.getCell(0, "A6", 16)
    series.getDataPoints().addDataPointForHistogramSeries(cell)

    chart.getAxes().getHorizontalAxis().setAggregationType(AxisAggregationType.Automatic)

    presentation.save("Histogram.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Radar diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot némi adatokkal, és adja meg a kívánt diagramtípust ([ChartType.Radar](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#Radar) ebben az esetben).
4. Mentse a módosított prezentációt PPTX fájlként.

Ez a Python kód bemutatja, hogyan hozható létre egy radar diagram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Radar, 20, 20, 400, 300)
    presentation.save("Radar-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Többkategóriás diagramok létrehozása**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal, és adja meg a [ChartType.ClusteredColumn](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/#ClusteredColumn) típust.
4. Érje el a diagram adatmunkafüzetét a [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) segítségével.
5. Törölje az alapértelmezett sorozatokat és kategóriákat.
6. Adjon hozzá új sorozatokat és kategóriákat.
7. Adjon hozzá új diagramadatokat a diagram sorozatokhoz.
8. Mentse a módosított prezentációt PPTX fájlként.

Ez a Python kód bemutatja, hogyan hozható létre egy többkategóriás diagram:

```python
import jpype
import asposeslides

if not jpython.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 600, 450)
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)
    default_worksheet_index = 0

    cell = workbook.getCell(0, "c2", "A")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group1")
    cell = workbook.getCell(0, "c3", "B")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c4", "C")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group2")
    cell = workbook.getCell(0, "c5", "D")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c6", "E")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group3")
    cell = workbook.getCell(0, "c7", "F")
    category = chart.getChartData().getCategories().add(cell)

    cell = workbook.getCell(0, "c8", "G")
    category = chart.getChartData().getCategories().add(cell)
    category.getGroupingLevels().setGroupingItem(1, "Group4")
    cell = workbook.getCell(0, "c9", "H")
    category = chart.getChartData().getCategories().add(cell)

    # Sorozat hozzáadása
    cell = workbook.getCell(0, "D1", "Series 1")
    series = chart.getChartData().getSeries().add(cell, ChartType.ClusteredColumn)

    cell = workbook.getCell(default_worksheet_index, "D2", 10)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D3", 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D4", 30)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D5", 40)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D6", 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D7", 60)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D8", 70)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, "D9", 80)
    series.getDataPoints().addDataPointForBarSeries(cell)

    # Prezentáció mentése diagrammal
    presentation.save("AsposeChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Térképi diagramok létrehozása**

A térképi diagramok földrajzi adatokat jelenítenek meg, és segítenek összehasonlítani az értékeket a régiók között.

Ez a Python kód bemutatja, hogyan hozható létre egy térképi diagram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Map, 50, 50, 500, 400)
    presentation.save("mapChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kombinációs diagramok létrehozása**

A kombinációs diagram (vagy combo diagram) több diagramtípust egyesít egyetlen grafikonban. Ez a diagram lehetővé teszi, hogy kiemelje, összehasonlítsa vagy megvizsgálja a különböző adathalmazok közti különbségeket, segítve a köztük lévő összefüggések felismerését.

![A kombinációs diagram](combination_chart.png)

Az alábbi Python kód mutatja, hogyan hozható létre a fent látható kombinációs diagram egy PowerPoint‑prezentációban:

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

    # Beállítja a diagram címét.
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("Chart Title")
    chart.getChartTitle().setOverlay(False)
    title_paragraph = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0)
    title_format = title_paragraph.getParagraphFormat().getDefaultPortionFormat()
    title_format.setFontBold(NullableBool.False_)
    title_format.setFontHeight(18.0)

    # Beállítja a diagram jelmagyarázatát.
    chart.getLegend().setPosition(LegendPositionType.Bottom)
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(12.0)

    # Törli az alapértelmezett generált sorozatokat és kategóriákat.
    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    worksheet_index = 0
    workbook = chart.getChartData().getChartDataWorkbook()

    # Új kategóriákat ad hozzá.
    cell = workbook.getCell(worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(worksheet_index, 4, 0, "Category 4")
    chart.getChartData().getCategories().add(cell)

    # Hozzáadja az első sorozatot.
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
    # Beállítja a vízszintes tengelyt.
    horizontal_axis = chart.getAxes().getHorizontalAxis()
    horizontal_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    horizontal_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(horizontal_axis, "X Axis")

    # Beállítja a függőleges tengelyt.
    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.getTextFormat().getPortionFormat().setFontHeight(12.0)
    vertical_axis.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    set_axis_title(vertical_axis, "Y Axis 1")

    # Beállítja a függőleges fő rácsvonalak színét.
    major_grid_lines_format = vertical_axis.getMajorGridLinesFormat().getLine().getFillFormat()
    major_grid_lines_format.setFillType(FillType.Solid)
    color = Color(217, 217, 217)
    major_grid_lines_format.getSolidFillColor().setColor(color)

def set_secondary_axes_format(chart):
    # Beállítja a másodlagos vízszintes tengelyt.
    secondary_horizontal_axis = chart.getAxes().getSecondaryHorizontalAxis()
    secondary_horizontal_axis.setPosition(AxisPositionType.Bottom)
    secondary_horizontal_axis.setCrossType(CrossesType.Maximum)
    secondary_horizontal_axis.setVisible(False)
    secondary_horizontal_axis.getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)
    secondary_horizontal_axis.getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.NoFill)

    # Beállítja a másodlagos függőleges tengelyt.
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

## **Diagramok frissítése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból, amely a frissíteni kívánt diagramot tartalmazó prezentációt képviseli.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Járja be az összes alakzatot a kívánt diagram megtalálásához.
4. Érje el a diagram adat‑munkalapját.
5. Módosítsa a diagram adat sorozatát a sorozat értékeinek megváltoztatásával.
6. Adjon hozzá egy új sorozatot és töltse fel annak adatait.
7. Mentse a módosított prezentációt PPTX fájlként.

Ez a Python kód mutatja, hogyan frissíthető egy diagram:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Megnyitja a prezentációt, amely tartalmazza a frissítendő diagramot
presentation = Presentation("ExistingChart.pptx")
try:
    # Az első diát éri el
    slide = presentation.getSlides().get_Item(0)

    # Lekéri a diagramot a diáról
    chart = slide.getShapes().get_Item(0)

    # Beállítja a diagram adatlapjának indexét
    default_worksheet_index = 0

    # Lekéri a diagram adatlapját
    workbook = chart.getChartData().getChartDataWorkbook()

    # A diagram kategória nevének módosítása
    workbook.getCell(default_worksheet_index, 1, 0, "Modified Category 1")
    workbook.getCell(default_worksheet_index, 2, 0, "Modified Category 2")

    # Az első diagram sorozatot veszi
    series = chart.getChartData().getSeries().get_Item(0)

    # Most frissíti a sorozat adatait
    workbook.getCell(default_worksheet_index, 0, 1, "New_Series1")# Sorozatnév módosítása
    series.getDataPoints().get_Item(0).getValue().setData(90)
    series.getDataPoints().get_Item(1).getValue().setData(123)
    series.getDataPoints().get_Item(2).getValue().setData(44)

    # A második diagram sorozatot veszi
    series = chart.getChartData().getSeries().get_Item(1)

    # Most frissíti a sorozat adatait
    workbook.getCell(default_worksheet_index, 0, 2, "New_Series2")# Sorozatnév módosítása
    series.getDataPoints().get_Item(0).getValue().setData(23)
    series.getDataPoints().get_Item(1).getValue().setData(67)
    series.getDataPoints().get_Item(2).getValue().setData(99)

    # Most új sorozatot ad hozzá
    cell = workbook.getCell(default_worksheet_index, 0, 3, "Series 3")
    chart.getChartData().getSeries().add(cell, chart.getType())

    # A 3. diagram sorozatot veszi
    series = chart.getChartData().getSeries().get_Item(2)

    # Most feltölti a sorozat adatait
    cell = workbook.getCell(default_worksheet_index, 1, 3, 20)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 2, 3, 50)
    series.getDataPoints().addDataPointForBarSeries(cell)
    cell = workbook.getCell(default_worksheet_index, 3, 3, 30)
    series.getDataPoints().addDataPointForBarSeries(cell)

    chart.setType(ChartType.ClusteredCylinder)

    # Mentés diagrammal a prezentációt
    presentation.save("AsposeChartModified_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Diagram adatintervallumának beállítása**

A meglévő diagram által már használt tartomány megtekintéséhez lásd a [A diagram adatintervallumának lekérése](/slides/hu/python-java/chart-workbook/#retrieve-a-charts-data-range) oldalt.

A diagram adatintervallumának beállításához tegye a következőket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból, amely a diagramot tartalmazó prezentációt képviseli.
2. Szerezzen referenciát egy diára az indexe alapján.
3. Járja be az összes alakzatot a kívánt diagram megtalálásához.
4. Érje el a diagram adatot és állítsa be a tartományt.
5. Mentse a módosított prezentációt PPTX fájlként.

Ez a Python kód mutatja, hogyan állítható be a diagram adatintervalluma:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Megnyitja a prezentációt, amely tartalmazza a diagramot
presentation = Presentation("ExistingChart.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().get_Item(0)

    chart.getChartData().setRange("Sheet1!A1:B4")

    presentation.save("SetDataRange_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Alapértelmezett jelölők használata diagramokban**

Alapértelmezett jelölők használata esetén minden diagram sorozat automatikusan különböző jelölőszimbólumot kap.

Ez a Python kód mutatja, hogyan állítható be automatikusan egy diagram sorozat jelölője:

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
    cell = workbook.getCell(0, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(cell, chart.getType())
    series = chart.getChartData().getSeries().get_Item(0)

    cell = workbook.getCell(0, 1, 0, "C1")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 1, 1, 24)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 0, "C2")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 2, 1, 23)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 0, "C3")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 3, 1, -10)
    series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 0, "C4")
    chart.getChartData().getCategories().add(cell)
    cell = workbook.getCell(0, 4, 1, None)
    series.getDataPoints().addDataPointForLineSeries(cell)

    cell = workbook.getCell(0, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(cell, chart.getType())
    #Veszi a második diagram sorozatot
    second_series = chart.getChartData().getSeries().get_Item(1)

    #Most feltölti a sorozat adatait
    cell = workbook.getCell(0, 1, 2, 30)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 2, 2, 10)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 3, 2, 60)
    second_series.getDataPoints().addDataPointForLineSeries(cell)
    cell = workbook.getCell(0, 4, 2, 40)
    second_series.getDataPoints().addDataPointForLineSeries(cell)

    chart.setLegend(True)
    chart.getLegend().setOverlay(False)

    presentation.save("DefaultMarkersInChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Milyen diagramtípusokat támogat az Aspose.Slides?**

Az Aspose.Slides széles körű [diagramtípusokat](https://reference.aspose.com/slides/python-java/aspose.slides/charttype/) támogat, többek között oszlop, vonal, kör, terület, szórás, hisztogram, radar és még sok mást. Ez a rugalmasság lehetővé teszi, hogy az adatvizualizációs igényeknek legmegfelelőbb diagramtípust válassza.

**Hogyan adhatok hozzá új diagramot egy diára?**

Új diagram hozzáadásához először hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) osztályból, szerezze be a kívánt diát az indexe alapján, majd hívja meg a diagram hozzáadására szolgáló metódust, megadva a diagram típusát és a kezdeti adatokat. Ez a folyamat közvetlenül integrálja a diagramot a prezentációba.

**Hogyan frissíthetem egy diagramon megjelenített adatokat?**

A diagram adatait a [ChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/) elérésével, az alapértelmezett sorozatok és kategóriák törlésével, majd saját adatainak hozzáadásával frissítheti. Így a diagram mindig a legújabb adatokat tükrözi.

**Lehetősége van a diagram megjelenésének testreszabására?**

Igen, az Aspose.Slides kiterjedt testreszabási lehetőségeket kínál. Módosíthatja a színeket, betűtípusokat, címkéket, jelmagyarázatokat és egyéb [formázási elemeket](/slides/hu/python-java/chart-entities/), hogy a diagram megjelenése megfeleljen a konkrét tervezési követelményeknek.