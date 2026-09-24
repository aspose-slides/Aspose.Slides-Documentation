---
title: Diagrammunkafüzetek kezelése prezentációkban Python (Java) segítségével
linktitle: Diagrammunkafüzet
type: docs
weight: 70
url: /hu/python-java/chart-workbook/
keywords:
- diagrammunkafüzet
- diagramadat
- munkafüzetcella
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
description: "Fedezze fel az Aspose.Slides for Python via Java megoldást: egyszerűen kezelheti a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, optimalizálva prezentációi adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhat a diagrammunkakönyvekkel az Aspose.Slides-ban. Bemutatja, hogyan olvashat és írhat diagramadatokat munkafüzet‑adatfolyamokon keresztül, hogyan használhatja a munkafüzet‑cellákat diagramcímkékként, hogyan érheti el a munkalap‑gyűjteményeket, és hogyan adhatja meg az adatforrás‑típust a diagramértékekhez.

Az is tárgyalja a külső munkafüzetek diagramadat‑forrásként való használatát. A példák bemutatják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan kérdezheti le egy diagramhoz kapcsolt külső munkafüzet útvonalát, valamint hogyan szerkesztheti a diagramadatokat, ha a munkafüzet elérhető.

A hiányzó adatot jelző munkafüzet‑cellák esetén lásd a [Control the Display of Empty Cells](/slides/hu/python-java/chart-series/) című cikket, ahol a üres cella és a nulla közti különbséget, valamint a vonaldiagram‑összehasonlítást a lehetséges megjelenítési módok között is megtalálja.

## **Diagramadatok olvasása és írása munkafüzetből**
Az Aspose.Slides a [readWorkbookStream](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#readWorkbookStream) és a [writeWorkbookStream](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#writeWorkbookStream) metódusokat biztosítja, amelyekkel diagramadat‑munkafüzeteket (az Aspose.Cells‑kel szerkesztett diagramadatokat tartalmazó) olvashat és írhat. **Megjegyzés**, hogy a diagramadatoknak ugyanúgy kell felépülniük, vagy hasonló szerkezetűnek kell lenniük, mint a forrásnak.

Ez a Python‑kód egy példaműveletet mutat be:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    workbook_data = chart_data.readWorkbookStream()
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(workbook_data)
finally:
    presentation.dispose()
```

### **Diagramelrendezés ellenőrzése a munkafüzet‑módosítás után**

Ha egy beágyazott munkafüzetet egy módosítottra cserél, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez az inkonzisztencia azt okozhatja, hogy a [Chart.validateChartLayout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#validateChartLayout) `ArgumentOutOfRangeException`‑t (paraméter: index) dob. Az exception elkerülése érdekében törölje a meglévő sorozatokat és kategóriákat **a** frissített munkafüzet diagramhez való visszaírása **előtt**.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Olvasd be a munkafüzetet a módosítás után (például az Aspose.Cells használatával).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # Töröld a meglévő adatreferenciákat.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

A gyűjtemények törlése biztosítja, hogy a diagramadat‑szerkezet összhangban legyen az új munkafüzettel, így a [validateChartLayout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#validateChartLayout) hibamentesen befejeződik.

## **Munkafüzet‑cellát beállítás diagramcímkének**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
1. Szerezze meg egy dia referencia‑indexét.  
1. Adjon hozzá egy Buborék‑diagramot némi adattal.  
1. Hozzáférés a diagram sorozatához.  
1. Állítsa be a munkafüzet‑cellát adatcímkének.  
1. Mentse a prezentációt.

Ez a Python‑kód megmutatja, hogyan állíthat be egy munkafüzet‑cellát diagramcímkének:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart2.pptx")
try:
    label_values = ["Label 0 cell value", "Label 1 cell value", "Label 2 cell value"]
    slide = presentation.getSlides().get_Item(0)
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

Ez a Python‑kód egy olyan műveletet mutat be, ahol a [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/#getWorksheets) metódust használja a munkalap‑gyűjtemény eléréséhez:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500)
    workbook = chart.getChartData().getChartDataWorkbook()
    for i in range(workbook.getWorksheets().size()):
        print(workbook.getWorksheets().get_Item(i).getName())
finally:
    presentation.dispose()
```

## **Az adatforrás típusának meghatározása**

Ez a Python‑kód bemutatja, hogyan adhat meg egy típust egy adatforráshoz:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DataSourceType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, True)
    series_name = chart.getChartData().getSeries().get_Item(0).getName()
    series_name.setDataSourceType(DataSourceType.StringLiterals)
    series_name.setData("LiteralString")
    series_name = chart.getChartData().getSeries().get_Item(1).getName()
    name_cell = chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell")
    series_name.setData(name_cell)
    presentation.save("pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nem támogatott beágyazott munkafüzet‑formátumok észlelése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumát, amelyet egyes diagramokba be lehet ágyazni. A [getEmbeddedWorkbookType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) metódust a [ChartData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/) osztályon a [WorkbookType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/workbooktype/) felsorolással együtt használva észlelheti a nem támogatott formátumokat, és átugorhatja az érintett diagramokat.

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
        if chart_data.getDataSourceType() == ChartDataSourceType.InternalWorkbook and chart_data.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro:
            # Beágyazott munkafüzet .xlsb formátumú, amely nem támogatott.
            continue
        # Olvassa vagy módosítsa itt a diagram munkafüzet adatokat.
finally:
    presentation.dispose()
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramadat‑forrásként való használatát.

### **Külső munkafüzet létrehozása**

A [readWorkbookStream](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#readWorkbookStream) és a [setExternalWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#setExternalWorkbook) metódusok segítségével vagy egy új külső munkafüzetet hozhat létre, vagy egy belső munkafüzetet tehet külsővé.

Ez a Python‑kód demonstrálja a külső munkafüzet létrehozási folyamatát:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

from pathlib import Path

presentation = Presentation()
try:
    workbook_path = "externalWorkbook1.xlsx"
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600)
    workbook_data = chart.getChartData().readWorkbookStream()
    Path(workbook_path).write_bytes(bytes(workbook_data))
    chart.getChartData().setExternalWorkbook(workbook_path)
    presentation.save("externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Külső munkafüzet beállítása**

A [setExternalWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#setExternalWorkbook) metódussal egy külső munkafüzetet rendelhet a diagram adatforrásaként. Ezzel a metódussal frissíthető a külső munkafüzet elérési útja is (ha a fájl el lett helyezve).

Bár a távoli helyen vagy erőforráson tárolt munkafüzetek adatait nem szerkesztheti közvetlenül, továbbra is használhatja őket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útvonallá alakul.

Ez a Python‑kód megmutatja, hogyan állíthat be egy külső munkafüzetet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, False)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("externalWorkbook.xlsx")
    workbook = chart_data.getChartDataWorkbook()
    series_name_cell = workbook.getCell(0, "B1")
    series = chart_data.getSeries().add(series_name_cell, ChartType.Pie)
    for row in range(2, 5):
        value_cell = workbook.getCell(0, f"B{row}")
        series.getDataPoints().addDataPointForPieSeries(value_cell)
    for row in range(2, 5):
        category_cell = workbook.getCell(0, f"A{row}")
        chart_data.getCategories().add(category_cell)
    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A [setExternalWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#setExternalWorkbook) metódus második (`bool`) paramétere azt határozza meg, hogy egy Excel‑munkafüzet betöltődik‑e vagy sem.

* Ha az értéke `False`, csak a munkafüzet útvonala frissül – a diagramadatok nem lesznek betöltve vagy frissítve a cél‑munkafüzetről. Ezt a beállítást olyan helyzetekben érdemes használni, amikor a cél‑munkafüzet nem létezik vagy nem érhető el.  
* Ha az értéke `True`, a diagramadatok a cél‑munkafüzetről frissülnek.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, True)
    chart_data = chart.getChartData()
    chart_data.setExternalWorkbook("http://path/doesnt/exists", False)
    presentation.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **A diagram külső adatforrás‑munkafüzete útvonalának lekérdezése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
1. Szerezze meg egy dia referencia‑indexét.  
1. Hozzon létre egy objektumot a diagram alakzatához.  
1. Hozzon létre egy objektumot a forrás ([ChartDataSourceType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatasourcetype/)) típusához, amely a diagram adatforrását képviseli.  
1. Adja meg a releváns feltételt a forrástípus és a külső munkafüzet adatforrás‑típus egyezősége alapján.

Ez a Python‑kód bemutatja a műveletet:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartDataSourceType, Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    slide = presentation.getSlides().get_Item(1)
    chart = slide.getShapes().get_Item(0)
    source_type = chart.getChartData().getDataSourceType()
    if source_type == ChartDataSourceType.ExternalWorkbook:
        path = chart.getChartData().getExternalWorkbookPath()
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Diagramadatok szerkesztése**

Külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogy a belső munkafüzetek tartalmát. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a Python‑kód a leírt folyamat megvalósítása:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()
    chart_data.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(jpype.JInt(100))
    presentation.save("presentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram egy hiányzó vagy elérhetetlen külső munkafüzetet használ, az Aspose.Slides helyreállíthatja a diagram munkafüzettét a prezentációban tárolt gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/) objektumot, konfigurálja a [SpreadsheetOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/spreadsheetoptions/)‑val, és a megnyitás előtt hívja meg a [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) metódust `True` értékkel.

Az alábbi Python‑példa megnyit egy olyan prezentációt, amelynek diagramja egy nem elérhető külső munkafüzetre hivatkozik, és a helyreállított adatokat a [Chart.getChartData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#getChartData) és a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével érheti el:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SpreadsheetOptions

spreadsheet_options = SpreadsheetOptions()
spreadsheet_options.setRecoverWorkbookFromChartCache(True)
load_options = LoadOptions()
load_options.setSpreadsheetOptions(spreadsheet_options)

presentation = Presentation("presentation.pptx", load_options)
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    recovered_workbook = chart.getChartData().getChartDataWorkbook()

    # Olvassa vagy módosítsa itt a helyreállított munkafüzet adatait.
finally:
    presentation.dispose()
```

Ha a külső munkafüzet nem érhető el, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárazott diagramadatok használata elfogadható tartalék, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció utolsó mentése óta végzett módosításokat.

## **GYIK**

**Meg tudom állapítani, hogy egy adott diagram külső vagy beágyazott munkafüzethez van-e kapcsolva?**

Igen. A diagramnek van egy [data source type](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getDataSourceType) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); ha a forrás egy külső munkafüzet, kiolvashatja a teljes útvonalat, hogy megbizonyosodjon róla, hogy külső fájlt használ.

**Támogatottak-e a relatív útvonalak külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, azt a rendszer automatikusan abszolút útvonallá alakítja. Ez a projekt hordozhatóságát könnyíti, azonban a prezentáció az abszolút útvonalat tárolja a PPTX‑fájlban.

**Használhatók-e hálózati erőforrásokon/megosztott mappákon lévő munkafüzetek?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja‑e a külső XLSX‑et a prezentáció mentésekor?**

Nem. A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) tárol, és azt használja az adatok olvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mi a teendő, ha a külső fájl jelszóval van védve?**

Az Aspose.Slides nem fogad jelszót a kapcsolódáskor. Egy gyakori megoldás, hogy előzetesen eltávolítja a védelmet, vagy egy dekódolt másolatot (például a [Aspose.Cells](/cells/python-java/) segítségével) készít, majd ahhoz kapcsolódik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját linket tárol. Ha mind ugyanarra a fájlra mutatnak, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.