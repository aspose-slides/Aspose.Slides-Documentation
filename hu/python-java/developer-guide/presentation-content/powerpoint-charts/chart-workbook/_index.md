---
title: Diagram munkafüzetek kezelése prezentációkban Pythonon keresztül Java-val
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/python-java/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adatok
- munkafüzet cella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- diagram gyorsítótár
- munkafüzet helyreállítás
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for Python via Java megoldást: egyszerűen kezelheti a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy hatékonyabbá tegye a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a diagram munkafüzetekkel az Aspose.Slides-ban. Megmutatja, hogyan olvashat és írhat diagramadatokat munkafüzet adatfolyamokon keresztül, hogyan használhatja a munkafüzet cellákat diagramadatcímkeként, hogyan érheti el a munkalap-gyűjteményeket, és hogyan adhatja meg az adatforrás típusát a diagramértékekhez.

A cikk kitér arra is, hogyan dolgozzon külső munkafüzetekkel diagramadatforrásként. A példák bemutatják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan kérdezheti le egy diagramhoz csatolt külső munkafüzet útvonalát, és hogyan szerkesztheti a diagramadatokat, ha a munkafüzet elérhető.

A hiányzó adatot jelző munkafüzet cellákkal kapcsolatban lásd a [Control the Display of Empty Cells](/slides/hu/python-java/chart-series/) oldalt, amely elmagyarázza a különbséget az üres cella és a nulla között, valamint egy vonaldiagram-összehasonlítást a rendelkezésre álló megjelenítési módokról.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használja a [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) metódust annak vezérlésére, hogy a diagram adatot ábrázoljon-e a rejtett munkalap sorokból és oszlopokból. Állítsa `True`-ra, ha csak a látható cellákat akarja ábrázolni, vagy `False`-ra, ha a látható és a rejtett cellákat is bele akarja foglalni. Ez a beállítás a diagram rajzolását szabályozza; nem rejti el vagy jeleníti meg a munkalap sorokat vagy oszlopokat.

Töltse le a [hidden-source-data.pptx](hidden-source-data.pptx) fájlt, és helyezze a munkakönyvtárba. Az első diája egy oszlopdiagramot tartalmaz első alakzatként. A beágyazott munkalap, `Sheet1`, a következő forrás tartományt tartalmazza, `A1:C4`. A 3. sor és a C oszlop rejtett, de a celláik még mindig értékeket tartalmaznak.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | január | 10 | 30 |
| 3 (rejtett sor) | február | 40 | 60 |
| 4 | március | 20 | 50 |

A forráscellákat a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével érheti el, és a [ChartDataCell.isHidden](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatacell/#isHidden) metódussal ellenőrizheti rejtett állapotukat. Ez a módszer a rejtett állapotot jelenti anélkül, hogy megváltoztatná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa `False`, `True` és `True` értékeket ír ki.

Ehhez a példához frissítse a diagram adatot a rajzolási beállítás megváltoztatása után: tartsa meg a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#readWorkbookStream) segítségével, és töltse be újra a [writeWorkbookStream](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#writeWorkbookStream) segítségével. Az összes cella belefoglalásakor használja még a [setRange](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#setRange) metódust a teljes tartomány visszaállításához, beleértve a rejtett februári kategóriát is. A flag egyszerű módosítása nem elegendő a minta gyorsítótárba tárolt diagramadatainak és kategóriacímkéknek a frissítéséhez.

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

            # Frissítse a diagram adatokat a beágyazott munkafüzetről.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Állítsa vissza a teljes forrás tartományt, beleértve a rejtett kategóriákat.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

A példa a `hidden_cells_True.pptx` fájlt csak a látható Kiskereskedelem értékekkel (10 és 20) menti, a `hidden_cells_False.pptx` fájlt pedig mind a hat értékkel. Az alábbi képek a két rajzolási módot illusztrálják. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`True`) | Minden cella (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Egy értéket tartalmazó rejtett cella különbözik egy üres cellától. A [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#setDisplayBlanksAs) szabályozza, hogy a hiányzó értékek hogyan jelennek meg; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd a [Control the Display of Empty Cells](/slides/hu/python-java/chart-series/#control-the-display-of-empty-cells) című oldalt egy példáért.

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides for Python via Java a [readWorkbookStream](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#readWorkbookStream) és a [writeWorkbookStream](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#writeWorkbookStream) metódusokkal lehetővé teszi diagramadatok munkafüzeteinek (amelyek az Aspose.Cells‑sel szerkesztett diagramadatokat tartalmazzák) olvasását és írását. **Note** that the chart data has to be organized in the same manner or must have a structure similar to the source.

Ez a példa megnyitja a `chart.pptx` fájlt, amelynek első alakzatként diagramot kell tartalmaznia az első dián. Beolvassa a beágyazott munkafüzetet egy bájt tömbbe, törli a meglévő sorozatokat és kategóriákat, majd visszaírja ugyanazt a munkafüzetet. A változtatások memóriában maradnak; a példa nem menti a prezentációt.

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

### **A diagram elrendezésének ellenőrzése a munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet módosított példánnyal cserélünk le, a diagram megtartja az eredeti sorozat- és kategória-gyűjteményeit. Ez a nem egyezés a [Chart.validateChartLayout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#validateChartLayout) hibájához vezethet index‑out‑of‑range hibával. Törölje a meglévő sorozatokat és kategóriákat a frissített munkafüzet visszaírása előtt a diagramra. Ez a példa `chart.pptx` fájlt igényel, amelynek első alakzatként diagramot kell tartalmaznia az első dián. A megjegyzés jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet, és memóriában ellenőrzi a layoutot.

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

        # Módosítsa a munkafüzet bájtjait itt, például az Aspose.Cells segítségével.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

A gyűjtemények törlése megszünteti a régóta fennálló adatreferenciákat, mielőtt a munkafüzet visszaírásra kerül. Építse újra a szükséges sorozat- és kategória-leképezéseket a frissített munkafüzethez, mielőtt a diagramot használná.

## **Munkafüzet cella beállítása diagramadatcímkeként**

Használhatja a munkafüzet cellák szövegét diagramadatcímkeként. Az alábbi lépések megmutatják, hogyan kapcsolhatja a feliratokat egy buborékdiagramhoz a munkafüzet celláihoz.

1. Hozzon létre egy példányt a Presentation osztályból.
1. Hozza el az első diát a nullás indexével.
1. Adjon hozzá egy buborékdiagramot alapértelmezett adatokkal.
1. Hozza el a diagram sorozatát.
1. Állítsa be a munkafüzet cellát adatcímkének.
1. Mentse a prezentációt.

Ez a példa megnyitja a `chart2.pptx` fájlt, amelynek legalább egy diát kell tartalmaznia, és egy buborékdiagramot ad hozzá alapértelmezett adatokkal. A 0‑s munkalapon az A10:A12 cellákat használja az első sorozat első három felirataihoz, engedélyezi a cellákból származó feliratokat, és a `resultchart.pptx` fájlba menti az eredményt.

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

## **Munkalapok kezelése**

A [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/#getWorksheets) metódus hozzáférést biztosít a diagram munkafüzeteiben lévő munkalapokhoz. Ez a példa létrehoz egy kördiagramot alapértelmezett adatokkal, és minden munkalap nevét kiírja a konzolra.

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

## **Az adatforrás típusának megadása**

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozatnévhez különböző adatforrásokat állít be. Az első név egy karakterlánc‑literal, a második a 0‑s munkalap C1 cellájából származik. A [DataSourceType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/datasourcetype/) felsorolás választja ki a forrást minden névhez. Az eredmény a `pres.pptx` fájlba kerül mentésre.

```python
import jpime
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

## **Nem támogatott beágyazott munkafüzet formátumok észlelése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely néhány diagramba beágyazható. Használja a [getEmbeddedWorkbookType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) metódust a [ChartData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/) osztályon, valamint a [WorkbookType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/workbooktype/) felsorolást a nem támogatott formátumok felismeréséhez és a diagramok kihagyásához. Ez a példa az `sample.pptx` első diáján lévő alakzatokat vizsgálja, kihagyja a nem diagram alakzatokat, és diagnosztikus üzenetet ír ki minden .xlsb‑t beágyazott munkafüzettel rendelkező diagramhoz.

```python
import jpype
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
        # Olvassa vagy módosítsa a támogatott diagram munkafüzet adatokat itt.
finally:
    presentation.dispose()
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek használatát diagramok adatforrásaként.

### **Külső munkafüzet létrehozása**

Használja a [readWorkbookStream](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#readWorkbookStream) és a [setExternalWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#setExternalWorkbook) metódusokat egy beágyazott diagram munkafüzete exportálásához egy fájlba, és a diagram összekapcsolásához azzal a külső munkafüzettel.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, a munkafüzetet az `externalWorkbook1.xlsx` fájlba írja, és a fájl írása befejezése után rendeli hozzá a diagram adatforrásaként. A linkelt prezentációt az `externalWorkbook.pptx` fájlba menti.

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

### **Külső munkafüzet beállítása**

A [setExternalWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#setExternalWorkbook) metódussal egy külső munkafüzetet rendelhet a diagramhoz adatforrásként. Ezzel a módszerrel a külső munkafüzet elérési útját is frissítheti (ha a fájlt áthelyezték).

Bár távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti közvetlenül, továbbra is használhatja ezeket külső adatforrásként. Ha relatív útvonalat ad meg a külső munkafüzethez, az automatikusan teljes útvonalra konvertálódik.

Ez a példa az `externalWorkbook.xlsx` fájlt igényli a munkakönyvtárban. A `Sheet1` nevű munkalapnak tartalmaznia kell egy sorozatnevet a B1 cellában, kategória neveket az A2:A4 tartományban, és számértékeket a B2:B4 tartományban. A példa egy kördiagramot hoz létre, összekapcsolja a munkafüzetet, és a [setRange](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#setRange) metódussal az A1:B4 tartományt egy sorozathoz és három kategóriához rendeli. Az eredményt a `Presentation_with_externalWorkbook.pptx` fájlba menti.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#setExternalWorkbook) `updateChartData` paramétere szabályozza, hogy a munkafüzet be legyen‑töltve.

* Amikor `updateChartData` **False**, csak a munkafüzet útvonalát frissíti. A diagram adatai nem töltődnek be vagy frissülnek a célmunkafüzetről, így a munkafüzet akár nem is elérhető.
* Amikor `updateChartData` **True**, a diagram adatai frissülnek a célmunkafüzetről.

Az alábbi példa egy helyettesítő URL‑t rendeli hozzá, a `updateChartData` értéke **False**. A kördiagram alapértelmezett adatait megőrzi, és a prezentációt anélkül menti, hogy betöltené a nem elérhető munkafüzetet.

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

### **A diagram külső adatforrás munkafüzet útvonalának lekérdezése**

A diagramhoz csatolt munkafüzet azonosításához először ellenőrizze, hogy a diagram külső adatforrást használ‑e. Ha igen, a következő lépésekkel kérdezheti le a munkafüzet útvonalát.

1. Hozzon létre egy példányt a Presentation osztályból.
1. Hozza el az első diát a nullás indexével.
1. Ellenőrizze, hogy az első alakzat diagram‑e.
1. Olvassa le a diagram adatforrás típusát.
1. Ha a forrás egy külső munkafüzet, olvassa le az útvonalát.

Ez a példa megnyitja a `externalWorkbook.pptx` fájlt, amelyet az előző példában hoztak létre, és ellenőrzi az első dián lévő első alakzatot. Ha ez egy külső munkafüzettel összekapcsolt diagram, a példa a [getExternalWorkbookPath](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) értékét a konzolra írja. Ezután egy másolatot ment a prezentációból a `Result.pptx` fájlba.

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

### **Diagramadatok szerkesztése**

A külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetek tartalmát. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa egy `presentation.pptx` fájlt igényel, amelynek első alakzatként diagramot kell tartalmaznia az első dián, valamint egy elérhető külső munkafüzetet. A példa az első sorozat első adatpontjának értékét 100‑ra állítja, és a `presentation_out.pptx` fájlba menti a prezentációt. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért másolatot használjon, ha az eredeti munkafüzetet meg kell őrizni.

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

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram olyan külső munkafüzetet használ, amely hiányzik vagy nem érhető el, az Aspose.Slides helyreállíthatja a diagram munkafüzeteit a prezentációban tárolt gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/) objektumot, hívja meg a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) metódust, és a [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) értékét állítsa **True**‑ra a prezentáció megnyitása előtt.

Az alábbi Python példa megnyitja a `presentation.pptx` fájlt, amelynek első diáján lévő első alakzatnak diagramnak kell lennie, amely egy nem elérhető külső munkafüzetre hivatkozik, majd a [Chart.getChartData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#getChartData) és a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével hozzáfér a helyreállított adatokhoz:

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

        # Olvassa vagy módosítsa a helyreállított munkafüzet adatait itt.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Ha a külső munkafüzet nem érhető el, és a helyreállítás nincs engedélyezve, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárazott diagramadatok használata elfogadható tartalékmegoldás, mivel a gyorsítótár esetleg nem tartalmazza a külső munkafüzetben a prezentáció legutóbbi frissítése óta történt módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van‑e csatolva?**

Igen. A diagramnek van egy [data source type](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getDataSourceType) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); ha a forrás egy külső munkafüzet, akkor leolvashatja a teljes útvonalat, hogy megbizonyosodjon arról, hogy egy külső fájlt használ.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút útvonallá. A prezentáció az abszolút útvonalat tárolja a PPTX fájlban, ezért a munkafüzet áthelyezésekor frissíteni kell a hivatkozást.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztásokon?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑szal nem támogatott – csak forrásként használhatók.

**Felülírja az Aspose.Slides a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) tárolja. A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt is. Használjon másolatot a munkafüzetről, ha az eredetit változatlanul kell hagyni.

**Mit kell tennem, ha a külső fájl jelszóval van védve?**

Az Aspose.Slides nem fogad jelszót a linkelés során. Egy gyakori megoldás, hogy előzetesen eltávolítja a védelmet, vagy egy dekódolt másolatot készít (például az [Aspose.Cells](https://reference.aspose.com/cells/python-java/) segítségével), majd arra a másolatra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját linket tárol. Ha mind ugyanarra a fájlra mutatnak, a fájl frissítése minden diagramra hatással lesz a következő adatbetöltéskor.