---
title: Prezentációkban lévő diagram munkafüzetek kezelése Python via Java használatával
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
description: "Fedezze fel az Aspose.Slides for Python via Java-t: könnyedén kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációi adatait."
---
## **Áttekintés**

Ez a cikk azt magyarázza el, hogyan lehet a diagram munkafüzetekkel dolgozni az Aspose.Slides-ben. Bemutatja, hogyan lehet a diagram adatokat munkafüzet adatfolyamokon keresztül olvasni és írni, a munkafüzet cellákat diagram adatcímkeként használni, a munkalap gyűjteményekhez hozzáférni, és meghatározni az adatforrás típusát a diagram értékekhez.

A külső munkafüzetek diagram adatforrásként történő használatát is bemutatja. A példák demonstrálják, hogyan lehet külső munkafüzetet létrehozni és hozzárendelni, lekérni a diagramhoz csatolt külső munkafüzet útvonalát, és szerkeszteni a diagram adatokat, amikor a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzetcellák esetén lásd [Az üres cellák megjelenítésének szabályozása](/slides/hu/python-java/chart-series/) a különbségért az üres cella és a nulla között, valamint egy vonaldiagram összehasonlítást a rendelkezésre álló megjelenítési módokról.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használja a [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) metódust annak szabályozására, hogy a diagram rejtett munkalap sorokból és oszlopokból származó adatokat jelenítsen-e meg. Állítsa `True`-ra, hogy csak a látható cellákat ábrázolja, vagy `False`-ra, hogy a látható és rejtett cellákat egyaránt belefoglalja. Ez a beállítás a diagram ábrázolását szabályozza; nem rejti el vagy jeleníti meg a munkalap sorait vagy oszlopait.

A [példa prezentáció](hidden-source-data.pptx) tartalmaz egy oszlopdiagramot, mint az első alakzatot az első diájon. A beágyazott munkalap, `Sheet1`, a következő forrás tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de a celláik továbbra is értékeket tartalmaznak.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | január | 10 | 30 |
| 3 (rejtett sor) | február | 40 | 60 |
| 4 | március | 20 | 50 |

A forráscellákhoz hozzáférhet a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével, és olvashatja a [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) metódussal a rejtett státuszuk ellenőrzéséhez. Ez a metódus a rejtett státuszt anélkül jelzi, hogy módosítaná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 a rejtett oszlophoz; a példa a `False`, `True`, `True` értékeket írja ki.

Ehhez a példához a diagramadatot frissíteni kell a ábrázolási beállítás megváltoztatása után: a beágyazott munkafüzetet megtartja a [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) segítségével, és újratölti a [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) használatával. Az összes cella belefoglalásakor használja még a [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) metódust a teljes tartomány, beleértve a rejtett februári kategóriát, visszaállításához. A zászló egyszerű módosítása nem elegendő a minta gyorsítótárazott diagramadatai és kategóriacímkéi frissítéséhez.

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

A példa két változatban menti a prezentációt: az egyik csak a látható kiskereskedelmi értékekkel (10 és 20), a másik minden hat értékkel. Az alábbi képek a két ábrázolási módot illusztrálják. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`True`) | Minden cella (`False`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelmi értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelmi és Nagykereskedelmi értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy értéket tartalmazó rejtett cella különbözik egy üres cellától. A [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) szabályozza, hogyan jelenjenek meg a hiányzó értékek; nem foglalja bele vagy zárja ki a rejtett forrásadatokat. Lásd [Az üres cellák megjelenítésének szabályozása](/slides/hu/python-java/chart-series/#control-the-display-of-empty-cells) egy példáért.

## **Diagram adat tartományának lekérdezése**

Mielőtt egy meglévő prezentációban frissítené a munkafüzet adatokat, ellenőrizze a forrás tartományokat, hogy azonosítsa, mely munkalap cellákat használja az egyes diagramok. A [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) metódus a jelenlegi adat tartományt adja vissza munkalap-kvótált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` választja el a cellatartománytól, a `$A$1:$D$5` pedig a $A$1‑től $D$5‑ig terjedő cellákat jelöli. A dollárjelek abszolút sor- és oszlophivatkozásokat jelölnek.

A metódus a jelenlegi tartományt olvassa anélkül, hogy módosítaná a diagramot vagy annak munkafüzetét. Ha a diagram nem munkafüzetet használ adatforrásként, `InvalidOperationException`-t dob. További információért lásd a [ChartData API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) oldalt.

Ez a példa megnyit egy prezentációt, és közvetlenül minden dián ellenőrzi az alakzatokat diagramok után. Kiírja minden diagram nevét és forrás tartományát. Ha egy diagram nem használ munkafüzetet, üzenetet ír ki, és a következő diagramra lép.

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

## **Diagram adatok olvasása és írása munkafüzetből**

Az Aspose.Slides for Python via Java biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) és a [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) metódusokat, amelyek lehetővé teszik a diagram adat munkafüzetek (az Aspose.Cells‑szel szerkesztett diagram adatokkal) olvasását és írását. **Megjegyzés**: a diagram adatainak ugyanúgy kell felépülniük, vagy hasonló struktúrával kell rendelkezniük, mint a forrás.

Ez a példa egy olyan prezentációt használ, amelynek első alakzata egy diagram az első dián. A beágyazott munkafüzetet bájt tömbbe olvassa, kitörli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet visszaírja. A változtatások a memóriában maradnak; a példa nem menti a prezentációt.

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

### **Diagram elrendezés ellenőrzése a munkafüzet módosítása után**

Amikor egy beágyazott munkafüzetet egy módosított változattal helyettesít, a diagram megtartja az eredeti sorozat- és kategóriagyűjteményeit. Ez az eltérés a [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) hibához vezethet, amely index‑out‑of‑range hibát dob. Törölje a meglévő sorozatokat és kategóriákat a módosított munkafüzet visszaírása előtt. Ez a példa egy olyan diagramot használ, amely az első dián az első alakzat. A megjegyzés azt jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet, és a memóriában ellenőrzi az elrendezést.

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

        # Módosítsa itt a munkafüzet bájtjait, például az Aspose.Cells használatával.

        chart_data.getSeries().clear()
        chart_data.getCategories().clear()

        chart_data.writeWorkbookStream(workbook_data)
        chart.validateChartLayout()
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

A gyűjtemények törlése megakadályozza a elavult adat hivatkozásait, mielőtt a munkafüzet visszaíródna. Újra kell építeni a szükséges sorozat- és kategória-leképezéseket a módosított munkafüzethez, mielőtt a diagramot használja.

## **Munkafüzetcellát beállítani diagram adatcímkeként**

Szöveget használhat a munkafüzetcellákból diagram adatcímkeként.

Ez a példa buborékdiagramot ad hozzá alapértelmezett adatokkal a meglévő prezentáció első diájához. Az 0‑as munkalap A10:A12 celláit használja az első sorozat első három címkéjéhez, engedélyezi a cellákból származó címkéket, és menti a frissített prezentációt.

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

A [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) metódus hozzáférést biztosít a diagram munkafüzetben lévő munkalapokhoz. Ez a példa kördiagramot hoz létre alapértelmezett adatokkal, és a konzolra írja minden munkalap nevét.

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

Ez a példa háromdimenziós oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat nevet állít be különböző adatforrások használatával. Az első név egy karakterlánc literál, a második a 0‑as munkalap C1 celláját használja. A [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) felsorolt típus választja ki a forrást minden névhez. A példa a frissített sorozatnevekkel menti a prezentációt.

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

## **Nem támogatott beágyazott munkafüzet formátumok felderítése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely bizonyos diagramokban beágyazható. A [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) metódust a [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) osztályon a [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) felsorolással együtt használva felderítheti a nem támogatott formátumokat, és kihagyhatja az érintett diagramokat. Ez a példa az első dián ellenőrzi a alakzatokat egy meglévő prezentációban, kihagyja a nem diagram alakzatokat, és diagnosztikus üzenetet ír ki minden .xlsb munkafüzettel beágyazott diagramra.

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

Az Aspose.Slides támogatja a külső munkafüzetek diagram adatforrásként történő használatát.

### **Külső munkafüzet létrehozása**

Használja a [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) és a [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) metódusokat egy beágyazott diagram munkafüzet exportálásához fájlba, és a diagram külső munkafüzethez való csatolásához.

Ez a példa kördiagramot hoz létre alapértelmezett adatokkal, és exportálja a munkafüzetét. A fájlírás befejezése után rendeli hozzá a külső munkafüzetet diagram adatforrásként, majd menti a hivatkozott prezentációt.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) metódus segítségével egy külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ez a metódus felhasználható a külső munkafüzet útvonalának frissítésére is (ha a fájlt áthelyezték).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem lehet szerkeszteni, továbbra is használhatók külső adatforrásként. Ha relatív útvonalat ad meg a külső munkafüzethez, az automatikusan teljes úttá konvertálódik.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` nevű munkalapja B1‑ben tartalmaz egy sorozatnevet, A2:A4‑ben kategória neveket, és B2:B4‑ben számértékeket. A példa kördiagramot hoz létre, csatolja a munkafüzetet, és a [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) metódussal az A1:B4 tartományt egy sorozatra és három kategóriára képezi le. A prezentációt a hivatkozott diagrammal menti.

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

A `updateChartData` paraméter a [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) metódusban vezérli, hogy a munkafüzet betöltődik‑e.

* Ha `updateChartData` **False**, csak a munkafüzet útvonalát frissíti. A diagram adat nem töltődik be vagy frissül a célmunkafüzetről, így a munkafüzet hiányozhat.
* Ha `updateChartData` **True**, a diagram adat frissül a célmunkafüzetről.

A következő példa egy helyőrző URL‑t ad meg, a `updateChartData` **False** értékkel. Megőrzi a kördiagram alapértelmezett adatait, és a prezentációt a nem betöltött munkafüzet nélkül menti.

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

A diagramhoz csatolt munkafüzet azonosításához ellenőrizze, hogy a diagram külső adatforrást használ‑e, és kérje le a munkafüzet útvonalát.

Ez a példa az első dián lévő első alakzatot ellenőrzi egy hivatkozott külső munkafüzettel rendelkező prezentációban. Ha diagramról van szó, amely külső munkafüzethez van csatolva, a példa a [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) útvonalat írja a konzolra. Ezután ment egy másolatot a prezentációról.

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

### **Diagram adat szerkesztése**

A külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetekét. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első dián az első alakzat, és hozzáférhető külső munkafüzethez van csatolva. Beállítja az első sorozat első adatpontjának cella‑alapú értékét 100‑ra, majd menti a frissített prezentációt. A cellaértékek szerkesztése frissítheti a hivatkozott külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet meg akarja őrizni.

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

Ha egy diagram külső, hiányzó vagy nem elérhető munkafüzetet használ, az Aspose.Slides helyreállíthatja a diagram munkafüzetet a prezentáció gyorsítótárában tárolt adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) objektumot, hívja meg a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) metódust, és állítsa a [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) tulajdonságot **True**‑ra a prezentáció megnyitása előtt.

Az alábbi Python példa helyreállítja a munkafüzet adatokat egy olyan diagramhoz, amely az első dián az első alakzat, és egy nem elérhető külső munkafüzetre hivatkozik. A helyreállított adatokat a [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) és a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével érheti el:

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

        # Olvassa vagy módosítsa a helyreállított munkafüzet adatokat itt.
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

Ha a külső munkafüzet nem érhető el, és a helyreállítás ki van kapcsolva, az Aspose.Slides kivételt dob. Csak akkor engedélyezze a helyreállítást, ha a gyorsítótárból származó diagramadatok használata elfogadható megoldás, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzeten végzett módosításokat a legutóbbi prezentációfrissítés után.

## **FAQ**

**Megállapíthatom, hogy egy adott diagram külső vagy beágyazott munkafüzethez van‑e csatolva?**

Igen. A diagramnek van egy [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) és egy [path to an external workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); ha a forrás egy külső munkafüzet, a teljes útvonalat leolvashatja, hogy megbizonyosodjon a külső fájl használatáról.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút úttá. A prezentáció az abszolút útvonalat tárolja a PPTX fájlban, ezért a munkafüzet áthelyezése esetén frissíteni kell a hivatkozást.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztásokon?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [link to the external file](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) tárol. A cella‑alapú diagramadatok szerkesztése frissítheti a hivatkozott helyi XLSX fájlt. Használjon másolatot a munkafüzetről, ha az eredetit változatlanul kell hagyni.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a hivatkozás során. Gyakori megoldás a védelem előzetes eltávolítása vagy egy dekódolt másolat (például az [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) létrehozása, majd arra a másolatra való hivatkozás.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját hivatkozást tárol. Ha mind ugyanarra a fájlra mutatnak, a fájl frissítése minden diagramra kihat a következő adatbetöltéskor.