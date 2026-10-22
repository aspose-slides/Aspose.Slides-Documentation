---
title: Diagram munkafüzetek kezelése prezentációkban Python via Java segítségével
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
description: "Fedezze fel az Aspose.Slides for Python via Java-t: könnyedén kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációja adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozzunk a diagram munkafüzetekkel az Aspose.Slides-ban. Bemutatja, hogyan olvassunk és írjunk diagram adatokat munkafüzet adatfolyamokon keresztül, hogyan használjunk munkafüzet cellákat diagram adatcímkékként, hogyan férjünk hozzá a munkalap gyűjteményekhez, és hogyan határozzuk meg az adatforrás típusát a diagram értékekhez.

Továbbá tárgyalja a külső munkafüzetek diagram adatforrásként való használatát. A példák bemutatják, hogyan hozzunk létre és rendeljünk hozzá egy külső munkafüzetet, hogyan kérjük le egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkesszük a diagram adatokat, amikor a munkafüzet elérhető.

Hiányzó adatokat tartalmazó munkafüzet cellák esetén lásd a [Az üres cellák megjelenítésének szabályozása](/slides/hu/python-java/chart-series/) cikket, amely bemutatja az üres cella és a nulla közti különbséget, valamint egy vonaldiagramot a rendelkezésre álló megjelenítési módok összehasonlításával.

## **Rejtett sorok és oszlopok adatainak felvétele**

Használd a [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) metódust annak vezérlésére, hogy a diagram a rejtett munkalap sorokból és oszlopokból származó adatokat jelenítse‑e meg. Állítsd `True`‑ra, ha csak a látható cellákat szeretnéd ábrázolni, vagy `False`‑ra, ha a látható és rejtett cellákat egyaránt fel akarod venni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejti el vagy jeleníti meg a munkalap sorait vagy oszlopait.

A [példaprezentáció](hidden-source-data.pptx) egy oszlopdiagrammal rendelkezik, amely az első dia első alakzataként jelenik meg. A beágyazott munkalap, `Sheet1`, a következő forrástartományt tartalmazza, `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik továbbra is tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | január | 10 | 30 |
| 3 (rejtett sor) | február | 40 | 60 |
| 4 | március | 20 | 50 |

A forráscellákhoz a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével férhetsz hozzá, és a [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) segítségével ellenőrizheted a rejtett állapotukat. Ez a módszer a rejtett állapotot anélkül jelzi, hogy megváltoztatná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, és a C2 a rejtett oszlophoz; a példa ennek megfelelően `False`, `True`, és `True` értékeket ír ki.

Ehhez a példához frissítsd a diagram adatokat a plot beállítás módosítása után: tartsd meg a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) segítségével, és töltsd be újra a [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) használatával. Ha minden cellát fel szeretnél venni, használd a [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) metódust a teljes tartomány visszaállításához, beleértve a rejtett februári kategóriát is. Csak a jelző megváltoztatása nem elegendő a minta gyorsítótárazott diagram adatainak és kategória címkéinek frissítéséhez.

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

            # Frissítse a diagram adatokat a beágyazott munkafüzettől.
            chart.getChartData().writeWorkbookStream(workbook_data)
            if not visible_only:
                # Állítsa vissza a teljes forrásintervallumot, beleértve a rejtett kategóriákat.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

A példa két verziót ment a prezentációból: egyet, amely csak a látható Kiskereskedelem értékeket (10 és 20) tartalmazza, és egyet, amely mind a hat értéket tartalmazza. Az alábbi képek a két ábrázolási módot mutatják. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`True`) | Minden cella (`False`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelem értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelem és Nagykereskedelem értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy rejtett, értéket tartalmazó cella különbözik egy üres cellától. A [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) szabályozza, hogy a hiányzó értékek hogyan jelenjenek meg; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd a [Az üres cellák megjelenítésének szabályozása](/slides/hu/python-java/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adatintervallumának lekérdezése**

Mielőtt frissítenéd a munkafüzet adatokat egy meglévő prezentációban, vizsgáld meg a forrásintervallumokat, hogy meghatározd, mely munkalap cellákat használja az egyes diagramok. A [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) metódus visszaadja a jelenlegi adatintervallumot egy munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` választja el a cellatartománytól, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli. A dollárjelek abszolút sor‑ és oszlopreferenciákat jelölnek.

A módszer a jelenlegi tartományt anélkül olvassa ki, hogy módosítaná a diagramot vagy annak munkafüzetét. Ha a diagram nem használ munkafüzetet adatforrásként, `InvalidOperationException`‑t dob. További információkért lásd a [ChartData API hivatkozás](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) oldalát.

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

## **Diagram adatainak olvasása és írása munkafüzetből**

Az Aspose.Slides for Python via Java biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) és a [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) metódusokat, amelyek lehetővé teszik a diagram adat munkafüzetek (az Aspose.Cells‑el szerkesztett diagram adatokkal) olvasását és írását. **Megjegyzés**: a diagram adatokat ugyanabban a módon vagy hasonló szerkezettel kell elrendezni, mint a forrás.

Ez a példa egy olyan prezentációt használ, amelynek első diájának első alakzata egy diagram. Beolvassa a beágyazott munkafüzetet egy bájt‑tömbbe, törli a meglévő sorozatokat és kategóriákat, majd visszaírja ugyanazt a munkafüzetet. A módosítások memóriában maradnak; a példa nem menti a prezentációt.

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

### **Diagram elrendezésének ellenőrzése a munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet egy módosított változattal cserélsz, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez a nem‑egyezés a [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) hibához vezethet, ha index‑túl‑tartomány hiba lép fel. Töröld a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírnád a diagramba. Ez a példa egy olyan diagramot használ, amely az első dia első alakzataként jelenik meg. A megjegyzés jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet, és memória‑szinten ellenőrzi az elrendezést.

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

A gyűjtemények törlése eltávolítja a régi adatreferenciákat, mielőtt a munkafüzet visszaírásra kerül. Építsd újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használnád.

## **Egyedi számformátumok beállítása munkafüzet cellákhoz**

Használd a [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) metódust, hogy szabályozd, hogyan jelennek meg a numerikus értékek egy diagram beágyazott munkafüzetében. Például egy jelentésnek szüksége lehet a konverziós arányra, amelyet négy tizedesjegyű százalékban, valamint egy együtthatóra, amelyet öt tizedesjegyben szeretnénk megjeleníteni. A két értéket tartsd numerikus formában, hogy a számítások és a diagram ábrázolása továbbra is lehetséges legyen.

A számformátum csak a megjelenítést változtatja, nem a tárolt értéket. A `0.0000%` formátum a `0.125` értéket `12.5000%`‑ként jeleníti meg; a tárolt szám nem lesz `12.5`. Hasonlóképpen a `0.00000` formátum a `0.1234567`‑et `0.12346`‑ként mutatja anélkül, hogy a tárolt értéket kerekítené. Ha az egyedi formátum egy üres karakterlánc (`""`), akkor a [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) által visszaadott formátum kerül felhasználásra.

A következő példa egy oszlopdiagramot hoz létre, és a celláihoz a [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével fér hozzá. Az 0‑s munkalapon a B2 tartalmazza a konverziós rátát, a C2 pedig az együtthatót. Mindkét cella a diagram értékét szolgáltatja. A példa emellett engedélyezi a forrásformátumokhoz kapcsolt értékcímkéket.

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

A munkafüzet cellaformátumok különállóak a diagram tengelyeire vagy adatcímkéire közvetlenül beállított formátumoktól. Ebben a példában minden címke a forráscellájának értékét jeleníti meg, mivel a [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) `True`‑ra van állítva, és a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) szintén `True`. A prezentáció mentése és újranyitása után a címkék `12.5000%` és `0.12346` értékeket mutatják, ahogy az alább látható. A függőleges tengely saját számformátumot használ, amelyet a [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) `0.00`‑ra állít, a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) pedig `False`.

Az adatcímke független formázásához állítsd a forrásra mutató jelzőt `False`‑ra, és rendelj hozzá egy formátumot a [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) segítségével. Ez nem változtatja meg a munkafüzet cellájának formátumát. Például egy önálló `0.00` formátumú címke az első értéket `0.13`‑ként jeleníti meg, míg a B2 továbbra `12.5000%`‑t mutat. Lásd a [Diagram adatcímkék](/slides/hu/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) cikket a közvetlen címkeformázáshoz.

![Oszlopdiagram, amely forrás‑kapcsolt címkékkel jeleníti meg a 12.5000% és 0.12346 értékeket, valamint egy önállóan formázott numerikus tengelyt.](custom-cell-formats.png)

## **Munkafüzet cella beállítása diagram adatcímkének**

Használhatod a munkafüzet cellák szövegét diagram adatcímkeként.

Ez a példa egy buborékdiagramot ad hozzá az első diához egy meglévő prezentációban. A 0‑s munkalapon az A10:A12 tartományt használja az első sorozat három első címkéjének, engedélyezi a címkék cellákból származását, és elmenti a frissített prezentációt.

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

A [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) metódus hozzáférést biztosít a diagram munkafüzet munkalapjaihoz. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és a konzolra írja minden munkalap nevét.

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

A sorozat pontértékei közvetlenül numerikus literálokként is tárolhatók. Lásd a [Sorozatértékek beállítása numerikus literálokkal](/slides/hu/python-java/chart-series/#set-series-values-using-numeric-literals) példát a teljes példához, amely menti és olvassa őket. A pontértékek forrás típusa különbözik a diagram belső vagy külső munkafüzet beállításától; a numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet.

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozatnevet állít be különböző adatforrásokkal. Az első nevet karakterlánc literálként, a másodikat a 0‑s munkalap C1 cellájából veszi. A [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) felsorolás választja ki a forrást minden névhez. A példa elmenti a prezentációt a frissített sorozatnevekkel.

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

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely bizonyos diagramokban beágyazható. Használhatod a [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) metódust a [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/)‑n együtt a [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) felsorolással, hogy észleld a nem támogatott formátumokat, és kihagyjad ezeket a diagramokat. Ez a példa vizsgálja az első dia alakzatait egy meglévő prezentációban, kihagyja a nem diagram alakzatokat, és diagnosztikai üzenetet ír ki minden .xlsb munkafüzettel rendelkező diagramhoz.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

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

Az Aspose.Slides támogatja a külső munkafüzetek diagram adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használd a [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) és a [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) metódusokat, hogy egy beágyazott diagram munkafüzetet exportálj egy fájlba, és a diagramot ehhez a külső munkafüzethez kapcsoljad.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és exportálja a munkafüzett. A fájlírás befejezése után a külső munkafüzetet a diagram adatforrásaként állítja be, majd elmenti a kapcsolt prezentációt.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) metódus segítségével egy külső munkafüzetet rendelhetsz a diagramhoz adatforrásként. Ez a metódus használható a külső munkafüzet elérési útjának frissítésére is (ha az áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheted, továbbra is használhatod őket külső adatforrásként. Ha relatív elérési út van megadva egy külső munkafüzethez, az automatikusan teljes útvonalra konvertálódik.

Ez a példa egy külső munkafüzettet használ, amelynek `Sheet1` nevű munkalapján B1 cellában egy sorozatnév, A2:A4 cellákban kategórianév, B2:B4 cellákban numerikus értékek vannak. A példa egy kördiagramot hoz létre, a munkafüzetet összekapcsolja, és a [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) segítségével A1:B4‑et egy sorozat és három kategória leképezésére használja. A prezentációt a kapcsolt diagrammal menti.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) `updateChartData` paramétere szabályozza, hogy a munkafüzet betöltődjön‑e.

* Ha az `updateChartData` `False`, csak a munkafüzet útvonala frissül. A diagram adatainak betöltése vagy frissítése a célmunkafüzettel nem történik, így a munkafüzet hiányozhat.
* Ha az `updateChartData` `True`, a diagram adatai frissülnek a célmunkafüzettel.

A következő példa egy helyettesítő URL‑t rendeli a `updateChartData` `False` értékével. A kördiagram alapértelmezett adatait megtartja, és a prezentációt úgy menti, hogy a nem elérhető munkafüzetet nem tölti be.

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

### **Diagram külső adatforrás munkafüzetének elérési útjának lekérdezése**

A diagramhoz kapcsolt munkafüzet azonosításához ellenőrizd, hogy a diagram külső adatforrást használ‑e, majd kérd le a munkafüzet elérési útját.

Ez a példa az első dián lévő első alakzatot vizsgálja egy olyan prezentációban, amely külső munkafüzettel van összekapcsolva. Ha a diagram külső munkafüzettel van összekapcsolva, a példa a [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) értékét írja ki a konzolra, majd elment egy másolatot a prezentációról.

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

### **Diagram adatainak szerkesztése**

A külső munkafüzetek adatait ugyanúgy szerkesztheted, ahogyan a belső munkafüzetek tartalmát módosítanád. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első dián lévő első alakzat, és egy elérhető külső munkafüzettel van összekapcsolva. A első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, majd menti a frissített prezentációt. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért másolatot használj, ha az eredeti munkafüzettet meg akarod őrizni.

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

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides helyreállíthatja a diagram munkafüzetét a prezentációban gyorsítótárazott adatokból. Hozd létre a [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) objektumot, hívd meg a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) metódust, és a [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache)‑t állítsd `True`‑ra a prezentáció megnyitása előtt.

Az alábbi Python példa helyreállítja a munkafüzet adatokat egy olyan diagramhoz, amely az első dián lévő első alakzat, és egy nem elérhető külső munkafüzettel hivatkozik. A helyreállított adatokat a [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) és a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével érheti el:

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

Ha a külső munkafüzet nem érhető el, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Engedélyezd a helyreállítást csak akkor, ha a gyorsítótárazott diagramadatok használata elfogadható tartalék, mivel a gyorsítótár nem tartalmazhatja a külső munkafüzetben a prezentáció utolsó frissítése óta végzett változtatásokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzetre hivatkozik‑e?**

Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) és egy [path to an external workbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) tulajdonsággal; ha a forrás egy külső munkafüzet, a teljes útvonal lekérdezésével ellenőrizheted, hogy egy külső fájl kerül‑e felhasználásra.

**Támogatottak‑e a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat adsz meg, az automatikusan átalakul abszolút útvonallá. A prezentáció az abszolút útvonalat tárolja a PPTX fájlban, így a munkafüzet áthelyezése esetén a hivatkozást frissíteni kell.

**Használhatok‑e hálózati erőforrásokon vagy megosztott helyeken tárolt munkafüzeteket?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑sel nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja‑e a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [link to the external file](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath)‑et tárol. A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt is. Használj másolatot a munkafüzetről, ha az eredetit változatlanul szeretnéd hagyni.

**Mi a teendő, ha a külső fájl jelszó‑védett?**

Az Aspose.Slides nem fogad jelszót a hivatkozáshoz. Gyakori megoldás a védelem előzetes eltávolítása vagy egy feloldott másolat előkészítése (például az [Aspose.Cells](https://reference.aspose.com/cells/python-java/)‑el), majd ennek a másolatnak a használata.

**Több diagram is hivatkozhat‑e ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramra kihat a következő adatbetöltéskor.