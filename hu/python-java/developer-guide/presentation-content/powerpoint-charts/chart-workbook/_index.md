---
title: Diagram munkafüzetek kezelése prezentációkban Python (Java) segítségével
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
description: "Ismerje meg az Aspose.Slides for Python via Java megoldást: könnyedén kezelheti a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációi adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhat a diagram munkafüzetekkel az Aspose.Slides-ban. Bemutatja, hogyan olvashat és írhat diagram adatokat munkafüzet streameken keresztül, hogyan használhat munkafüzet cellákat diagramadatcímkeként, hogyan érheti el a munkalapgyűjteményeket, és hogyan adhatja meg az adatforrás típusát a diagramértékekhez.

Emellett lefedi a külső munkafüzetek diagramadat-forrásként való használatát is. A példák bemutatják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan kérdezheti le egy diagramhoz csatolt külső munkafüzet útvonalát, és hogyan szerkeszthet diagramadatokat, ha a munkafüzet elérhető.

## **Diagramadatok olvasása és írása munkafüzetből**
Az Aspose.Slides biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#readWorkbookStream) és a [writeWorkbookStream](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#writeWorkbookStream) metódusokat, amelyek lehetővé teszik diagramadat-munkafüzetek (az Aspose.Cells‑szel szerkesztett diagramadatokat tartalmazó) olvasását és írását. **Megjegyzés**: a diagramadatokat ugyanúgy kell elrendezni, vagy szerkezetüknek hasonlónak kell lennie a forráshoz.

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

### **A diagramelrendezés ellenőrzése a munkafüzet módosítása után**
Ha egy beágyazott munkafüzetet egy módosítottra cserél, a diagram megőrzi az eredeti sorozat- és kategória-gyűjteményeit. Ez az inkonzisztencia okozhatja, hogy a [Chart.validateChartLayout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#validateChartLayout) `ArgumentOutOfRangeException`‑t dob (paraméter: index). Az exception elkerülése érdekében törölje a meglévő sorozatokat és kategóriákat **előtt**, mielőtt a frissített munkafüzetet visszaírná a diagramba.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

from pathlib import Path

# Olvassa be a munkafüzetet a módosítás után (pl. az Aspose.Cells használatával).
updated_workbook = Path("updatedWorkbook.xlsx").read_bytes()

presentation = Presentation("chart.pptx")
try:
    chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    chart_data = chart.getChartData()

    # Törölje a meglévő adat hivatkozásokat.
    chart_data.getSeries().clear()
    chart_data.getCategories().clear()
    chart_data.writeWorkbookStream(jpype.JArray(jpype.JByte)(updated_workbook))
    chart.validateChartLayout()
finally:
    presentation.dispose()
```

A gyűjtemények törlése biztosítja, hogy a diagram adatstruktúrája megfeleljen az új munkafüzetének, lehetővé téve a [validateChartLayout](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#validateChartLayout) hibamentes befejezését.

## **Munkafüzet cellájának beállítása diagramadatcímkeként**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
2. Szerezzen be egy diát az indexe alapján.  
3. Adjon hozzá egy Buborék diagramot némi adattal.  
4. Érje el a diagram sorozatait.  
5. Állítsa be a munkafüzet celláját adatcímkeként.  
6. Mentse a prezentációt.  

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
Ez a Python kód egy olyan műveletet mutat be, ahol a [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdataworkbook/#getWorksheets) metódust használják a munkalapgyűjtemény eléréséhez:

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

## **Adatforrás típusának meghatározása**
Ez a Python kód megmutatja, hogyan adhat meg egy típust egy adatforráshoz:

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

## **Nem támogatott beágyazott munkafüzet-formátumok észlelése**
Az Aspose.Slides nem támogatja a Excel bináris munkafüzet (.xlsb) formátumát, amely néhány diagramba beágyazható. A [getEmbeddedWorkbookType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) metódust a [ChartData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/) osztályon, a [WorkbookType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/workbooktype/) felsorolással együtt használhatja nem támogatott formátumok felismerésére és az ilyen diagramok kihagyására.

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
            # A beágyazott munkafüzet .xlsb formátumban van, ami nem támogatott.
            continue
        # Itt olvashatja vagy módosíthatja a diagram munkafüzet adatait.
finally:
    presentation.dispose()
```

### **Külső munkafüzet létrehozása**
A [readWorkbookStream](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#readWorkbookStream) és a [setExternalWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#setExternalWorkbook) metódusok használatával akár egy külső munkafüzetet hozhat létre a semmiből, akár egy belső munkafüzetet tehet külsővé.

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
A [setExternalWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#setExternalWorkbook) metódus segítségével egy külső munkafüzetet rendelhet egy diagram adatforrásaként. Ez a metódus használható a külső munkafüzet útvonalának frissítésére is (ha a második helyet megváltoztatták).

Bár nem szerkesztheti a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait, továbbra is használhatja ezeket külső adatforrásként. Ha egy külső munkafüzethez relatív útvonalat ad meg, azt automatikusan teljes útvonallá konvertálja a rendszer.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#setExternalWorkbook) metódus második (`bool`) paramétere annak meghatározására szolgál, hogy egy Excel munkafüzet betöltődjön-e vagy sem.
* Ha az érték `False`, csak a munkafüzet útvonala frissül – a diagram adatai nem töltődnek be vagy frissülnek a célmunkafüzetről. Ezt a beállítást akkor érdemes használni, ha a célmunkafüzet nem létezik vagy nem érhető el.  
* Ha az érték `True`, a diagram adatai a célmunkafüzetről frissülnek.

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

### **A diagram külső adatforrás‑munkafüzete útvonalának lekérése**
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
2. Szerezzen be egy diát az indexe alapján.  
3. Hozzon létre egy objektumot a diagram alakzatához.  
4. Hozzon létre egy objektumot a forrás ([ChartDataSourceType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdatasourcetype/)) típusához, amely a diagram adatforrását képviseli.  
5. Adja meg a megfelelő feltételt a forrástípus és a külső munkafüzet adatforrás típusának egyezése alapján.  

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
Külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetek tartalmát. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

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
Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides képes a diagram munkafüzettet a prezentációban cache‑elt adatokból újjáépíteni. Hozzon létre [LoadOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/loadoptions/) objektumot, konfigurálja [SpreadsheetOptions](https://reference.aspose.com/slides/hu/python-java/aspose.slides/spreadsheetoptions/) segítségével, és hívja meg a [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) metódust `True` értékkel a prezentáció megnyitása előtt.

A következő Python példa megnyit egy prezentációt, amelynek diagramja egy nem elérhető külső munkafüzetre hivatkozik, és a helyreállított adatokat a [Chart.getChartData](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#getChartData) és a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével érheti el:

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

    # Itt olvashatja vagy módosíthatja a helyreállított munkafüzet adatait.
finally:
    presentation.dispose()
```

Ha a külső munkafüzet nem elérhető és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. A helyreállítást csak akkor engedélyezze, ha a cache‑elt diagramadatok használata elfogadható tartalék, mivel a cache nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció utolsó frissítése óta végzett módosításokat.

## **GYIK**

**Meg tudom állapítani, hogy egy adott diagram egy külső vagy beágyazott munkafüzettel van-e összekapcsolva?**  
Igen. A diagram rendelkezik egy [adatforrás típus](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getDataSourceType) és egy [úttal egy külső munkafüzettel](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); ha a forrás egy külső munkafüzet, kiolvashatja a teljes útvonalat annak megerősítésére, hogy egy külső fájlt használ.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**  
Igen. Ha relatív útvonalat ad meg, azt a rendszer automatikusan abszolút útvonallá alakítja. Ez a projekt hordozhatóságát könnyíti, azonban vegye figyelembe, hogy a prezentáció az abszolút útvonalat tárolja a PPTX fájlban.

**Használhatok hálózati erőforrásokban/megosztásokon lévő munkafüzeteket?**  
Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Felülírja az Aspose.Slides a külső XLSX‑et a prezentáció mentésekor?**  
Nem. A prezentáció egy [hivatkozást tárol a külső fájlra](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartdata/#getExternalWorkbookPath), és ezt használja az adatok olvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit tegyek, ha a külső fájl jelszóval védett?**  
Az Aspose.Slides nem fogad el jelszót a hivatkozásnál. Egy gyakori megoldás, hogy előre eltávolítja a védelmet, vagy egy dekódolt másolatot készít (például a [Aspose.Cells](/cells/python-java/) segítségével), és arra a másolatra hivatkozik.

**Több diagram is hivatkozhat ugyanarra a külső munkafüzetre?**  
Igen. Minden diagram saját hivatkozást tárol. Ha mind ugyanarra a fájlra mutatnak, a fájl frissítése a következő adatbetöltéskor minden diagramnál megjelenik.