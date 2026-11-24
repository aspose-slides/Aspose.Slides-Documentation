---
title: Diagrammunkafüzeteinek kezelése prezentációkban Python via Java
linktitle: Diagrammunkafüzet
type: docs
weight: 70
url: /hu/python-java/chart-workbook/
keywords:
- diagrammunkafüzet
- diagram adat
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
description: "Fedezze fel az Aspose.Slides for Python via Java-t: könnyedén kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a diagrammunkafüzettel az Aspose.Slides-ban. Megmutatja, hogyan olvassa és írja a diagramadatokat munkafüzet‑stream‑eken keresztül, hogyan használja a munkafüzetcellákat diagramadat‑címkeként, hogyan éri el a munkalap‑gyűjteményeket, és hogyan adja meg az adatforrás típusát a diagramértékekhez.

Emellett tárgyalja a külső munkafüzetek diagramadat‑forrásként történő használatát. A példák bemutatják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan kérdezheti le egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkesztheti a diagramadatokat, ha a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzetcellák esetén lásd a [Az üres cellák megjelenítésének vezérlése](/slides/hu/python-java/chart-series/) oldalt, ahol megtudhatja az üres cella és a nulla közti különbséget, valamint egy vonaldiagram összehasonlítását a rendelkezésre álló megjelenítési módokkal.

## **Rejtett sorok és oszlopok adatainak beillesztése**

Használja a [Chart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setPlotVisibleCellsOnly) metódust annak szabályozására, hogy a diagram a rejtett munkalap‑sorok és -oszlopok adatait is felhasználja-e. Állítsa `True`‑ra, hogy csak a látható cellákat használja, vagy `False`‑ra, hogy a látható és a rejtett cellákat egyaránt belevegye. Ez a beállítás a diagram ábrázolását szabályozza; nem rejt el vagy jelenít meg munkalap‑sorokat vagy -oszlopokat.

A [minta prezentáció](hidden-source-data.pptx) első diájának első alakja egy oszlopdiagram. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik továbbra is tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | január | 10 | 30 |
| 3 (rejtett sor) | február | 40 | 60 |
| 4 | március | 20 | 50 |

A forráscellákhoz a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével férhet hozzá, és a [ChartDataCell.isHidden](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#isHidden) metódussal ellenőrizheti a rejtett állapotukat. Ez a metódus a rejtett állapotot jelzi anélkül, hogy megváltoztatná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 a rejtett oszlophoz; a példa `False`, `True`, és `True` értékeket ír ki.

Ehhez a példához frissítse a diagramadatot a plot‑beállítás módosítása után: tartsa meg a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) használatával, és töltse be újra a [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) segítségével. Az összes cella belefoglalásakor használja a [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) metódust a teljes tartomány visszaállításához, beleértve a rejtett februári kategóriát is. Csak a jelző módosítása nem elegendő a minta gyorsítótárazott diagramadatai és kategóriacímkéinek frissítéséhez.

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
                # Állítsa vissza a teljes forrás‑tartományt, beleértve a rejtett kategóriákat.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a chart.")
finally:
    presentation.dispose()
```

A példa két verzióban menti a prezentációt: egyben csak a látható Kiskereskedelem‑értékek (10 és 20) szerepelnek, a másikban mind a hat érték. Az alábbi képek a két ábrázolási módot mutatják. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`True`) | Minden cella (`False`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelem értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelem és Nagykereskedelem értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy értéket tartalmazó rejtett cella különbözik egy üres cellától. A [Chart.setDisplayBlanksAs](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setDisplayBlanksAs) szabályozza, hogy a hiányzó értékek hogyan jelenjenek meg; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd a [Az üres cellák megjelenítésének vezérlése](/slides/hu/python-java/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat‑tartományának lekérése**

Mielőtt frissítené a munkafüzet adatokat egy meglévő prezentációban, ellenőrizze a forrás‑tartományokat, hogy megtudja, mely munkalap‑cellákat használja az egyes diagramok. A [ChartData.getRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getRange) metódus visszaadja a jelenlegi adat‑tartományt munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` elválasztja a cellatartományt, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli, mindkettő beleértve. A dollárjelek abszolút sor‑ és oszlophivatkozásra utalnak.

A metódus a jelenlegi tartományt olvassa anélkül, hogy módosítaná a diagramot vagy annak munkafüzetét. Ha a diagram nem használ munkafüzetet adatforrásként, `InvalidOperationException`‑t dob. További információkért tekintse meg a [ChartData API Referenciát](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/).

Ez a példa megnyit egy prezentációt, és közvetlenül minden dián ellenőrzi a formákat diagramok után. Kiírja minden diagram nevét és forrás‑tartományát. Ha egy diagram nem használ munkafüzetet, üzenetet ír ki, majd a következő diagramra lép.

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

Az Aspose.Slides for Python via Java biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) és a [writeWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#writeWorkbookStream) metódusokat, amelyekkel a diagramadat‑munkafüzeteket (amelyek Aspose.Cells‑szel szerkesztett diagramadatokat tartalmaznak) olvashatja és írhatja. **Megjegyzés:** a diagramadatoknak ugyanolyan módon kell felépülniük, vagy hasonló struktúrával kell rendelkezniük, mint a forrás.

Ez a példa egy prezentációt használ, amelynek első diájának első alakja egy diagram. Beolvassa a beágyazott munkafüzetet egy bájt‑tömbbe, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet visszaírja. A változások memóriában maradnak; a példa nem menti a prezentációt.

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

### **Diagramelrendezés ellenőrzése a munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet egy módosítottal cserél, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez az eltérés a [Chart.validateChartLayout](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#validateChartLayout) metódus index‑túl‑határ hibához vezethet. Írja ki a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírná a diagramba. Ez a példa egy diagramot használ, amely az első diájának első alakja. A megjegyzés jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet, és memóriában ellenőrzi az elrendezést.

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

A gyűjtemények törlése megszünteti a régi adat‑referenciákat, mielőtt a munkafüzet visszaíródna. Építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot felhasználná.

## **Kategória címkék tárolásának módja**

Hívja meg a [ChartCategoryCollection.setUseCells](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategorycollection/#setUseCells) metódust az üres kategória‑gyűjteményen, mielőtt címkéket adna hozzá. Használjon munkalap‑cellákat, ha a címkék munkafüzet‑adatokra hivatkoznak vagy hierarchiát alkotnak, például év szerint csoportosított negyedévek. Használjon karakterlánc‑literálokat egyetlen szinten, ahol nincs szükség cella‑referenciára. Ez a beállítás csak a kategóriákra vonatkozik. Az alábbi két diagram a számsorozat‑értékekhez munkalap‑cellákat alkalmazza.

A példa két oszlopdiagramot hoz létre, és kiírja a tárolási módot, majd `Q1 Q2 Q3 Q4` felirattal megjeleníti mindkettőt. Munkalap‑alapú címkék esetén a [ChartCategory.getAsCell](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/#getAsCell) visszaadja az alatta lévő cellát, a [ChartDataCell.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getValue) pedig beolvassa a címkét. Literális címkék esetén a [ChartCategory.getValue](https://reference.aspose.com/slides/python-java/aspose.slides/chartcategory/#getValue) közvetlenül visszaadja a karakterláncot.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    for use_cells in (True, False):
        x = 20 if use_cells else 360
        chart = shapes.addChart(ChartType.ClusteredColumn, x, 20, 320, 250)
        chart_data = chart.getChartData()
        chart_data.getSeries().clear()
        categories = chart_data.getCategories()
        categories.clear()
        categories.setUseCells(use_cells)

        workbook = chart_data.getChartDataWorkbook()
        series_name = workbook.getCell(0, 0, 1, "Sales")
        series = chart_data.getSeries().add(series_name, chart.getType())
        for row in range(1, 5):
            label = f"Q{row}"
            if use_cells:
                label_cell = workbook.getCell(0, row, 0, label)
                categories.add(label_cell)
            else:
                categories.add(label)

            value_cell = workbook.getCell(0, row, 1, jpype.JInt(row * 10))
            series.getDataPoints().addDataPointForBarSeries(value_cell)

        stored_in_cells = categories.getUseCells()
        labels = []
        for category in categories:
            value = category.getAsCell().getValue() if stored_in_cells else category.getValue()
            labels.append(str(value))
        print(f"UseCells = {stored_in_cells}:", *labels)

    presentation.save("category-labels.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Egyéni számformátum beállítása a munkafüzet cellákhoz**

Használja a [ChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setCustomNumberFormat) metódust a numerikus értékek diagramba ágyazott munkafüzetben való megjelenésének szabályozásához. Például egy jelentésnek a konverziós arányt százalékban, négy tizedesjeggyel, a koefficienset pedig öt tizedesjeggyel kell megjelenítenie. Tartsa mindkét értéket numerikus formában, hogy elérhetőek maradjanak a számításokhoz és a diagramábrázoláshoz.

A számformátum csak a megjelenítést változtatja, nem a tárolt értéket. A `0.0000%` formátum a `0.125`‑öt `12.5000%`‑ként jeleníti meg; a tárolt szám továbbra is `0.125`. Hasonlóképpen a `0.00000` a `0.1234567`‑et `0.12346`‑ként jeleníti meg, anélkül, hogy a tárolt értéket kerekítené. Ha az egyéni formátum üres karakterlánc (`""`), akkor a [getPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#getPresetNumberFormat) által visszaadott formátumot használja.

A következő példa egy oszlopdiagramot hoz létre, és a cellákhoz a [getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével fér hozzá. Az 0‑s munkalapon a B2 tartalmazza a konverziós arányt, a C2 a koefficienst. Mindkét cella diagramértékeket szolgáltat. A példa engedélyezi az értékcímkéket, amelyek a forrásformátumokhoz vannak kötve.

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

A munkafüzet‑cellák formátumai különállóak a diagram tengelyeken vagy adatcímkéken közvetlenül beállított formátumoktól. Ebben a példában minden címke a forrás‑cellák értékét jeleníti meg, mivel a [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) `True`‑ra van állítva, és a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormatLinkedToSource) szintén `True`. A prezentáció mentése és újranyitása után a címkék `12.5000%` és `0.12346` értékeket mutatják, ahogyan az alább látható. A függőleges tengely saját számformátumot használ, amelyet a [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) `0.00`‑ra állít, a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormatLinkedToSource) pedig `False`.

Ha egy adatcímkét függetlenül szeretne formázni, állítsa forrás‑kapcsolati zászlóját `False`‑ra, és adjon meg egy formátumot a [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setNumberFormat) metódussal. Ez nem változtatja meg a munkafüzet‑cellák formátumát. Például egy `0.00`‑as független címkeformátum az első értéket `0.13`‑ként jeleníti meg, míg a B2 továbbra is `12.5000%`‑ot mutat. Lásd a [Diagram adatcímkék](/slides/hu/python-java/chart-data-label/#set-percentage-sign-with-chart-data-labels) fejezetet a címkék közvetlen formázásához.

Az alábbi kép a mentett prezentáció újranyitása után készült:

![Oszlopdiagram forrás‑kapcsolt címkékkel, amelyek `12.5000%` és `0.12346` értékeket mutatnak, valamint egy függetlenül formázott numerikus tengely.](custom-cell-formats.png)

## **Munkafüzetcellát beállítani diagram adatcímkének**

Használhat szöveget munkafüzetcellákból diagram adatcímkeként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal egy meglévő prezentáció első diájához. Az 0‑s munkalap A10:A12 tartományát használja az első sorozat első három címkéjéhez, engedélyezi a cellákból származó címkéket, és menti a frissített prezentációt.

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

A [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/python-java/aspose.slides/chartdataworkbook/#getWorksheets) metódus hozzáférést biztosít a diagrammunkafüzet munkalapjaihoz. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és kiírja minden munkalap nevét a konzolra.

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

## **Adatforrás típusának megadása**

A sorozat‑pont értékek tárolhatók numerikus literálokként is. Lásd a [Sorozatértékek beállítása numerikus literálokkal](/slides/hu/python-java/chart-series/#set-series-values-using-numeric-literals) fejezetet a teljes példáért, amely elmenti és beolvassa őket. A pontértékek forrás‑típusa különálló a diagram belső vagy külső munkafüzet‑konfigurációjától; a numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet.

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozatnevet állít be különböző adatforrásokkal. Az első név egy karakterlánc‑literál, a második a 0‑s munkalap C1 celláját használja. A [DataSourceType](https://reference.aspose.com/slides/python-java/aspose.slides/datasourcetype/) felsorolás kiválasztja az egyes nevek forrását. A példa menti a prezentációt a módosított sorozatnevekkel.

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

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely néhány diagramba beágyazható. A [getEmbeddedWorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getEmbeddedWorkbookType) metódust a [ChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/) osztállyal és a [WorkbookType](https://reference.aspose.com/slides/python-java/aspose.slides/workbooktype/) felsorolással együtt használhatja a nem támogatott formátumok felismerésére és a diagramok kihagyására. Ez a példa az első dián lévő alakzatokat vizsgálja, kihagyja a nem‑diagram alakzatokat, és diagnosztikus üzenetet ír ki minden .xlsb‑t beágyazott munkafüzettel rendelkező diagramra.

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
        # Olvassa vagy módosítsa a támogatott diagrammunkafüzet adatokat itt.
finally:
    presentation.dispose()
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramok adatforrásként történő használatát.

### **Külső munkafüzet létrehozása**

Használja a [readWorkbookStream](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#readWorkbookStream) és a [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) metódusokat egy beágyazott diagrammunkafüzet exportálásához fájlba, majd a diagram összekapcsolásához a külső munkafüzettel.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és exportálja a munkafüzetet. A fájlírás befejezése után rendeli hozzá a külső munkafüzettet a diagram adatforrásaként, majd menti a kapcsolt prezentációt.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setExternalWorkbook) metódussal külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ezzel a módszerrel frissítheti is a külső munkafüzet elérési útját (ha az áthelyezésre került).

Miközben a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti, továbbra is használhatja ezeket a munkafüzeteket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, azt automatikusan teljes útra konvertálja a rendszer.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` nevű munkalapja B1‑ben egy sorozatnevet, A2:A4‑ben kategória‑neveket, és B2:B4‑ben numerikus értékeket tartalmaz. A példa egy kördiagramot hoz létre, összekapcsolja a munkafüzetet, és a [setRange](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#setRange) segítségével az A1:B4‑et egy sorozatra és három kategóriára map-olja. Mentés után a diagram a kapcsolt munkafüzettel rendelkezik.

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

* Ha az `updateChartData` `False`, csak a munkafüzet útvonalát frissíti. A diagramadata nem töltődik be, és nem frissül a cél‑munkafüzetről, ezért a munkafüzet hiányozhat.
* Ha az `updateChartData` `True`, a diagramadatai a cél‑munkafüzetről frissülnek.

A következő példa egy helyettesítő URL‑t ad meg `updateChartData` `False`‑ra állítva. A kördiagram alapértelmezett adatait megtartja, és a prezentációt anélkül menti, hogy betöltené a nem‑elérhető munkafüzetet.

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

### **Diagram külső adatforrás munkafüzet útvonalának lekérése**

Annak meghatározásához, hogy egy diagram milyen munkafüzethez van kapcsolva, ellenőrizze, hogy a diagram külső adatforrást használ‑e, majd kérdezze le annak munkafüzet‑útvonalát.

Ez a példa az első diájának első alakzatát vizsgálja, amely egy külső munkafüzettel kapcsolt diagram. Ha ez egy diagram, amely külső munkafüzettel van összekapcsolva, a példa kiírja a [getExternalWorkbookPath](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath) értékét a konzolra, majd ment egy másolatot a prezentációról.

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

Külső munkafüzettek adatait ugyanúgy szerkesztheti, mint a belső munkafüzettekét. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első diájának első alakja, és egy elérhető külső munkafüzethez van kapcsolva. A első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, majd a frissített prezentációt menti. A cella‑értékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet meg kell őrizni.

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

Ha egy diagram külső munkafüzetet használ, amely hiányzik vagy nem érhető el, az Aspose.Slides helyreállíthatja a diagrammunkafüzetet a prezentációban tárolt gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/) objektumot, hívja meg a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setSpreadsheetOptions) metódust, és állítsa a [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/python-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) értékét `True`‑ra, mielőtt megnyitná a prezentációt.

Az alábbi Python példa helyreállítja a munkafüzet adatokat egy diagramhoz, amely az első diájának első alakja, és nem elérhető külső munkafüzettel hivatkozik. A helyreállított adatokat a [Chart.getChartData](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getChartData) és a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével éri el:

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

Ha a külső munkafüzet nem érhető el, és a helyreállítás ki van kapcsolva, az Aspose.Slides kivételt dob. Csak akkor engedélyezze a helyreállítást, ha a gyorsítótár‑adatok használata elfogadható tartalék, mivel a gyorsítótár nem biztos, hogy tartalmazza a külső munkafüzeten végzett változtatásokat a prezentáció legutóbbi frissítése óta.

## **GYIK**

**Meg tudom állapítani, hogy egy adott diagram külső vagy beágyazott munkafüzettel van-e összekapcsolva?**

Igen. Egy diagramnek van egy [adatforrás típusa](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getDataSourceType) és egy [útvonala egy külső munkafüzettel](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath); ha a forrás külső munkafüzet, a teljes útvonal lekérdezésével ellenőrizhető, hogy külső fájlt használ‑e.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Relatív útvonal megadása esetén az automatikusan abszolút útra konvertálódik. A prezentáció a PPTX fájlban tárolja az abszolút útvonalat, így a munkafüzet áthelyezése esetén frissíteni kell a hivatkozást.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztott meghajtókon?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzettek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [hivatkozást tárol a külső fájlra](https://reference.aspose.com/slides/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt. Használjon másolatot a munkafüzetről, ha az eredetit változatlanul kell hagyni.

**Mi a teendő, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a csatoláskor. Általános megoldás a védelem eltávolítása előzetesen, vagy egy dekódolt másolat (például az [Aspose.Cells](https://reference.aspose.com/cells/python-java/)) létrehozása és arra való hivatkozás.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját hivatkozást tárol. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramot érint a következő adatbetöltéskor.