---
title: Diagrammunkafüzetek kezelése bemutatókban Python via Java használatával
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/python-java/chart-workbook/
keywords:
- diagram munkafüzet
- diagramadat
- munkafüzet cella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- diagram gyorsítótár
- munkafüzet helyreállítás
- PowerPoint
- bemutató
- Python
- Java
- Aspose.Slides
description: "Ismerje meg az Aspose.Slides for Python via Java megoldást: könnyedén kezelje a diagrammunkafüzeteket a PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse bemutatóadatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a diagram munkafüzetekkel az Aspose.Slides-ban. Megmutatja, hogyan olvashat és írhat diagramadatokat munkafüzet-áramokon keresztül, hogyan használhat munkafüzetcellákat diagramadat‑címkékként, hogyan érheti el a munkalap‑gyűjteményeket, és hogyan adhatja meg az adatforrás típusát a diagramértékekhez.

Továbbá kiterjed a külső munkafüzetek diagramadat‑forrásként való használatára. A példák bemutatják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan szerezheti meg a diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkesztheti a diagramadatokat, ha a munkafüzet elérhető.

A hiányzó adatot jelző munkafüzetcellák esetén lásd a [Üres cellák megjelenítésének szabályozása](/slides/hu/python-java/chart-series/) oldalt az üres cella és a nulla közti különbségért, valamint egy vonaldiagram-összehasonlítást a rendelkezésre álló megjelenítési módokról.

## **Rejtett sorok és oszlopok adatainak belevonása**

Használja a [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) metódust, hogy szabályozza, a diagram a rejtett munkalap‑sorok és -oszlopok adatait ábrázolja‑e. Állítsa `True`‑ra, ha csak a látható cellákat szeretné ábrázolni, vagy `False`‑ra, ha mind a látható, mind a rejtett cellákat bele akarja venni. Ez a beállítás a diagram ábrázolását vezérli; nem rejt el vagy jelenít meg munkalap‑sorokat vagy -oszlopokat.

A [példa bemutató](hidden-source-data.pptx) egy oszlopdiagramot tartalmaz első alakzatként az első diáján. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik továbbra is tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | január | 10 | 30 |
| 3 (rejtett sor) | február | 40 | 60 |
| 4 | március | 20 | 50 |

A forráscellák eléréséhez használja a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) metódust, és olvassa a [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) értékét a rejtett állapot vizsgálatához. Ez a metódus a rejtett állapotot anélkül jelzi, hogy módosítaná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz, a C2 pedig a rejtett oszlophoz tartozik; a példa `False`, `True` és `True` értékeket ír ki.

Ehhez a példához frissítse a diagramadatokat a ábrázolási beállítás változtatása után: tartsa meg a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) használatával, és töltse be újra a [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) segítségével. Az összes cella belevonásakor használja a [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) metódust is, hogy visszaállítsa a teljes tartományt, beleértve a rejtett februári kategóriát. Egyszerűen a jelző módosítása nem elegendő a mintában cache‑elt diagramadatok és kategória címkék frissítéséhez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpway.startJVM()

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

            # Frissítse a diagramadatokat a beágyazott munkafüzetről.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Állítsa vissza a teljes forrástartományt, beleértve a rejtett kategóriákat.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

A példa két változatban menti a bemutatót: egyben csak a látható Kiskereskedelem értékekkel (10 és 20), a másikban mind a hat értékkel. Az alábbi képek a két ábrázolási módot illusztrálják. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`True`) | Minden cella (`False`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelem értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelem és Nagykereskedelem értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy rejtett cella, amely értéket tartalmaz, különbözik egy üres cellától. A [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) szabályozza, hogy a hiányzó értékek hogyan jelennek meg; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd a [Üres cellák megjelenítésének szabályozása](/slides/hu/python-java/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat‑tartományának lekérése**

Mielőtt frissítené a munkafüzet adatait egy meglévő bemutatóban, ellenőrizze a forrás‑tartományokat, hogy azonosítsa, mely munkalap‑cellákat használja az egyes diagramok. A [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) metódus visszaadja az aktuális adat‑tartományt munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` választja el a cellatartománytól, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli, mindkettő tartalmazva. A dollárjelek abszolút sor‑ és oszlop‑hivatkozásokat jeleznek.

A metódus a jelenlegi tartományt anélkül olvassa, hogy módosítaná a diagramot vagy annak munkafüzetét. Ha a diagram nem használ munkafüzetet adatforrásként, `InvalidOperationException`‑t dob. További információért lásd a [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) oldalt.

Ez a példa megnyit egy bemutatót, és közvetlenül minden dián ellenőrzi az alakzatokat diagramok után. Kiírja minden diagram nevét és forrás‑tartományát. Ha egy diagram nem használ munkafüzetet, üzenetet ír ki, és a következő diagramra lép.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Chart, Presentation

InvalidOperationException = jpype.JClass("com.aspose.slides.exceptions.InvalidOperationException")

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if isinstance(shape, Chart):
                try:
                    data_range = shape.getChartData().getRange()
                    print(f"{shape.getName()}: {data_range}")
                except InvalidOperationException:
                    print(f"{shape.getName()}: The chart does not use a workbook as its data source.")
finally:
    presentation.dispose()
```

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides for Python via Java biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) és a [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) metódusokat, amelyek lehetővé teszik a diagramadat‑munkafüzetek (az Aspose.Cells‑szel szerkesztett diagramadatok) be‑ és kimenetét. **Megjegyzés**: a diagramadatot ugyanolyan módon vagy hasonló szerkezettel kell rendezni, mint a forrás.

Ez a példa egy bemutatót használ, amelynek első alakzata az első dián egy diagram. Beolvassa a beágyazott munkafüzetet egy byte‑tömbbe, törli a meglévő sorozatokat és kategóriákat, majd visszaírja ugyanazt a munkafüzetet. A módosítások memóriában maradnak; a példa nem menti a bemutatót.

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

### **Diagram elrendezésének érvényesítése a munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet egy módosítottval helyettesít, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez a nem egyezés a [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) hibához vezethet, ha index‑túl‑nagy hiba lép fel. Törölje a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírná a diagramba. Ez a példa egy diagramot használ, amely az első dián az első alakzat. A megjegyzés jelzi, hol történne a munkafüzet‑szerkesztés; a futtatható példa visszaírja az eredeti munkafüzetet, és memóriában ellenőrzi az elrendezést.

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

        # Módosítsa a munkafüzet bájtjait itt, például az Aspose.Cells használatával.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

A gyűjtemények törlése megszünteti a megromlott adat‑hivatkozásokat, mielőtt a munkafüzet visszaírásra kerül. Az új, frissített munkafüzethez építsen fel minden szükséges sorozat‑ és kategória‑leképezést, mielőtt a diagramot használja.

## **Egyéni számformátumok beállítása a munkafüzet celláira**

Használja a [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) metódust, hogy szabályozza, a numerikus értékek hogyan jelennek meg egy diagram beágyazott munkafüzetében. Például egy jelentésnek lehet szüksége a konverziós arány megjelenítésére százalékosan négy tizedesjeggyel, valamint egy együttható megjelenítésére öt tizedesjeggyel. Tartsa mindkét értéket numerikus formában, hogy elérhetőek maradjanak a számításokhoz és a diagram ábrázolásához.

A számformátum a megjelenítést változtatja, nem a tárolt értéket. A `0.0000%` formátum `0.125`‑et `12.5000%`‑ként jelenít meg; nem cseréli le a tárolt számot `12.5`‑re. Hasonlóan, a `0.00000` formátum `0.1234567`‑et `0.12346`‑ként jelenít meg anélkül, hogy a tárolt értéket kerekítené. Ha az egyéni formátum egy üres karakterlánc (`""`), akkor a [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) által visszaadott formátumot használja helyette.

Az alábbi példa egy oszlopdiagramot hoz létre, és a celláit a [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével érheti el. Az 0‑s munkalapon a B2 a konverziós arányt, a C2 pedig az együtthatót tartalmazza. Mindkét cella diagramértékeket szolgáltat. A példa emellett engedélyezi a forrás‑formátumokra hivatkozó értékcímkéket.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210)
    chart.setTitle(False)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00")
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(0)

    chart.getChartData().getSeries().clear()
    chart.getChartData().getCategories().clear()

    workbook = chart.getChartData().getChartDataWorkbook()
    workbook.clear(0)

    category_cell = workbook.getCell(0, "A2", "Sample")
    chart.getChartData().getCategories().add(category_cell)

    percentage_cell = workbook.getCell(0, "B2", jpype.JDouble(0.125))
    percentage_cell.setCustomNumberFormat("0.0000%")
    percentage_name = workbook.getCell(0, "B1", "Conversion rate")
    percentage_series = chart.getChartData().getSeries().add(percentage_name, chart.getType())
    percentage_series.getDataPoints().addDataPointForBarSeries(percentage_cell)

    precision_cell = workbook.getCell(0, "C2", jpype.JDouble(0.1234567))
    precision_cell.setCustomNumberFormat("0.00000")
    precision_name = workbook.getCell(0, "C1", "Coefficient")
    precision_series = chart.getChartData().getSeries().add(precision_name, chart.getType())
    precision_series.getDataPoints().addDataPointForBarSeries(precision_cell)

    for series in chart.getChartData().getSeries():
        label_format = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat()
        label_format.setShowValue(True)
        label_format.setNumberFormatLinkedToSource(True)

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A munkafüzet‑cellák formátumai elkülönülnek a diagram tengelyeire vagy adatcímkéire közvetlenül beállított formátumoktól. Ebben a példában minden címke a forrás‑cellájának értékét jeleníti meg, mert a [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) `True`‑ra van állítva, és a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) is `True`. A mentés és újranyitás után a címkék `12.5000%`‑et és `0.12346`‑t jelenítenek meg, ahogy lent látható. A függőleges tengely saját számformátumot használ, amelyet a [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) `0.00`‑ra állít, a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) pedig `False`.

Egy adatcímke független formázásához állítsa a forrás‑hivatkozás zászlót `False`‑ra, és adjon meg formátumot a [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) segítségével. Ez nem módosítja a munkafüzet‑cellához tartozó formátumot. Például egy független címkeformátum `0.00` az első értéket `0.13`‑ként jeleníti meg, míg a B2 továbbra is `12.5000%`‑t mutat. Lásd a [Diagram adatcímkék](/slides/hu/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) oldalt a közvetlen címkeformázáshoz.

Az alábbi kép a mentett bemutató újranyitása után készült:

![Oszlopdiagram a forrásra hivatkozó címkékkel, amelyek `12.5000%` és `0.12346` értékeket mutatnak, valamint egy önállóan formázott numerikus tengellyel.](custom-cell-formats.png)

## **Munkafüzet cella beállítása diagram adatcímkeként**

A munkafüzet celláiból származó szöveget használhatja diagram adatcímkékként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal az első diára egy meglévő bemutatóban. Az 0‑s munkalap A10‑A12 celláit használja az első sorozat első három címkéjéhez, engedélyezi a címkéket a cellákból, és elmenti a frissített bemutatót.

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

A [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) metódus hozzáférést biztosít a diagram munkafüzetében lévő munkalapokhoz. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és kiírja minden munkalap nevét a konzolra.

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

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozatnevet állít be különböző adatforrásokkal. Az első név egy karakterlánc‑literál; a második a 0‑s munkalap C1 cellájából származik. A [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) felsorolás választja ki az egyes nevek forrását. A példa elmenti a bemutatót a frissített sorozatnevekkel.

```python
import jpype
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

## **Nem támogatott beágyazott munkafüzetformátumok észlelése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely néhány diagramba beágyazható. A [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) metódust a [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/)‑on együtt a [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) felsorolással használhatja a nem támogatott formátumok felismerésére és az érintett diagramok kihagyására. Ez a példa az első dián lévő alakzatokat vizsgálja egy meglévő bemutatóban, kihagyja a diagram‑tól eltérő alakzatokat, és diagnosztikai üzenetet ír ki minden .xlsb‑t tartalmazó diagramhoz.

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
        # Olvassa vagy módosítsa a támogatott diagram munkafüzet adatait itt.
finally:
    presentation.dispose()
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetelek diagramok adatforrásaként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) és a [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) metódusokat, hogy exportálja a beágyazott diagram munkafüzetét egy fájlba, majd a diagramot erre a külső munkafüzetre hivatkoztassa.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és exportálja a munkafüzetét. A fájlírás befejezése után állítja be a külső munkafüzetet diagram adatforrásként, majd elmenti a hivatkozott bemutatót.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) metódussal egy külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ezzel a metódussal frissítheti a külső munkafüzet útvonalát is (ha az áthelyezésre került).

Bár a távoli helyen vagy erőforrásban tárolt munkafüzetelek adatainak szerkesztése nem lehetséges, továbbra is használhatja ezeket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útra konvertálódik.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` nevű munkalapja B1‑ben egy sorozatnevet, A2‑A4‑ben kategória neveket, és B2‑B4‑ben numerikus értékeket tartalmaz. A példa egy kördiagramot hoz létre, a munkafüzetet összekapcsolja, és a [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) segítségével A1:B4‑et egy sorozathoz és három kategóriához rendeli. A bemutatót a hivatkozott diagrammal menti.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) `updateChartData` paramétere szabályozza, hogy a munkafüzet be legyen‑töltve.

* Ha `updateChartData` **False**, csak a munkafüzet útvonalát frissíti. A diagramadatok nem töltődnek be vagy frissülnek a célmunkafüzetről, ezért a munkafüzet lehet elérhetetlen.
* Ha `updateChartData` **True**, a diagramadatok a célmunkafüzetről frissülnek.

Az alábbi példa egy helyettesítő URL‑t ad meg `updateChartData` **False** értékkel. A kördiagram alapértelmezett adatait megtartja, és a bemutatót anélkül menti, hogy a nem elérhető munkafüzetet betöltené.

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

### **A diagram külső adatforrás munkafüzetejének útvonalának lekérése**

A diagramhoz kapcsolt munkafüzet azonosításához ellenőrizze, hogy a diagram külső adatforrást használ‑e, és kérdezze le a munkafüzet útvonalát.

Ez a példa az első dián az első alakzatot vizsgálja egy hivatkozott külső munkafüzettel rendelkező bemutatóban. Ha egy diagram külső munkafüzettel van összekapcsolva, a példa a [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) értékét írja a konzolra. Ezután egy másolatot ment a bemutatóról.

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

Ez a példa egy diagramot használ, amely az első dián az első alakzat, és hozzáférhető külső munkafüzethez van csatolva. Az első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, majd elmenti a frissített bemutatót. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX‑fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet meg kell őrizni.

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

Ha egy diagram olyan külső munkafüzetet használ, amely hiányzik vagy nem érhető el, az Aspose.Slides képes rekonstruálni a diagram munkafüzetét a bemutatóban cache‑elt adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) objektumot, hívja meg a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions)‑t, és állítsa a [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache)‑t **True**‑ra, mielőtt megnyitná a bemutatót.

A következő Python‑példa helyreállítja a munkafüzet‑adatokat egy diagramhoz, amely az első dián az első alakzat, és egy nem elérhető külső munkafüzert hivatkozik. A helyreállított adatot a [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) és a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével éri el:

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

Ha a külső munkafüzet nem érhető el, és a helyreállítás ki van kapcsolva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a cache‑elt diagramadat használata elfogadható tartalék, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a diagram utolsó frissítése után végzett változtatásokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzettel van‑e összekapcsolva?**

Igen. A diagramnek van egy [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) és egy [path to an external workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); ha a forrás egy külső munkafüzet, a teljes útvonalat kiolvashatja, hogy megbizonyosodjon arról, egy külső fájlt használ‑e.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút útvonallá. A bemutató az abszolút útvonalat a PPTX‑fájlban tárolja, így a munkafüzet áthelyezése esetén a hivatkozás frissítése szükséges lehet.

**Használhatok hálózati erőforrásokon/megosztott helyeken lévő munkafüzete­ket?**

Igen, az ilyen munkafüzete­ket használhatja külső adatforrásként. Azonban a távoli munkafüzete­k közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑fájlt a bemutató mentésekor?**

A bemutató egy [link to the external file](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)‑et tárol. A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX‑fájlt is. Használjon másolatot a munkafüzetről, ha az eredetit változatlanul kell hagyni.

**Mit tegyek, ha a külső fájl jelszó‑védett?**

Az Aspose.Slides nem fogad jelszót a hivatkozáshoz. Egy gyakori megoldás, hogy előre eltávolítja a védelmet, vagy egy dekódolt másolatot (például az [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) készít, majd arra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját hivatkozást tárol. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.