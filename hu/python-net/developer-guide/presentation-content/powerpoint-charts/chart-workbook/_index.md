---
title: Diagram munkafüzetek kezelése bemutatókban Python segítségével
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/python-net/chart-workbook/
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
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Python via .NET-et: egyszerűen kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy optimalizálja a bemutató adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a diagram munkafüzetekkel dolgozni az Aspose.Slides-ben. Megmutatja, hogyan lehet a diagramadatokat munkafüzetfolyamok segítségével olvasni és írni, a munkafüzet cellákat diagram adatcímkékként használni, a munkalapgyűjteményekhez hozzáférni, és megadni az adatforrás típusát a diagramértékekhez.

Emellett bemutatja a külső munkafüzetek diagramadat-forrásként való használatát. A példák azt mutatják, hogyan hozhatunk létre és rendelhetünk hozzá egy külső munkafüzetet, hogyan szerezhetjük meg egy diagramhoz csatolt külső munkafüzet elérési útját, és hogyan szerkeszthetjük a diagram adatokat, ha a munkafüzet elérhető.

A hiányzó adatokat képviselő munkafüzetcellák esetén lásd a [Control the Display of Empty Cells](/slides/hu/python-net/chart-series/) szakaszt az üres cella és a nulla közti különbségről, valamint a különböző megjelenítési módok vonaldiagram-összehasonlításáról.

## **Adatok bevonása rejtett sorokból és oszlopokból**

Használja a [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) metódust, hogy szabályozza, a diagram csak látható munkalap sorokból és oszlopokból ábrázolja-e az adatokat. Állítsa `True` értékre, ha csak a látható cellákat szeretné ábrázolni, vagy `False` értékre, ha a látható és a rejtett cellákat egyaránt fel szeretné venni. Ez a beállítás a diagram ábrázolását érinti; nem rejti el vagy jeleníti meg a munkalap sorait vagy oszlopait.

A [példa bemutató](hidden-source-data.pptx) egy oszlopdiagramot tartalmaz első alakzatként az első dián. A beágyazott munkalap, `Sheet1`, a következő forrás‐tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik továbbra is tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (rejtett sor) | February | 40 | 60 |
| 4 | March | 20 | 50 |

A forráscellákat a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) segítségével érheti el, és a [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) segítségével vizsgálhatja meg a rejtett állapotukat. Ez a tulajdonság csak olvasható. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa sorban `False`, `True`, `True` értékeket ír ki.

Ehhez a példához a diagram adatainak frissítése a megjelenítési beállítás módosítása után: a beágyazott munkafüzetet a [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) módszerrel tartsa meg, és töltsön be újra a [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) segítségével. Az összes cella bevonásakor használja a [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) metódust a teljes tartomány visszaállításához, beleértve a rejtett februári kategóriát is. Csak a jelző megváltoztatása nem elegendő a mintában tárolt diagram adatainak és kategóriacímkéinek frissítéséhez.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("hidden-source-data.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        workbook = chart.chart_data.chart_data_workbook
        print(f"B2 hidden: {workbook.get_cell(0, 'B2').is_hidden}")
        print(f"B3 hidden: {workbook.get_cell(0, 'B3').is_hidden}")
        print(f"C2 hidden: {workbook.get_cell(0, 'C2').is_hidden}")

        workbook_stream = chart.chart_data.read_workbook_stream()
        for visible_only in [True, False]:
            chart.plot_visible_cells_only = visible_only

            # Frissítse a diagram adatokat a beágyazott munkafüzetről.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Állítsa vissza a teljes forrástartományt, beleértve a rejtett kategóriákat.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

A példa két verzióban menti a bemutatót: egyben csak a látható Kiskereskedelem értékek (10 és 20), a másikban mind a hat érték. Az alábbi képek a mentett, újra megnyitott bemutatókból származnak; mindkét fájl megőrizte a hozzárendelt megjelenítési beállítást. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`True`) | Minden cella (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Egy rejtett, értékkel rendelkező cella különbözik egy üres cellától. A [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) szabályozza, hogyan jelennek meg a hiányzó értékek; nem vonja be vagy zárja ki a rejtett forrásadatot. Lásd a [Control the Display of Empty Cells](/slides/hu/python-net/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat-tartományának lekérése**

Mielőtt egy meglévő bemutatóban a munkafüzet adatokat frissítené, ellenőrizze a forrás‐tartományokat, hogy mely munkalapcellákat használja a diagram. A [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) metódus visszaadja az aktuális adat‑tartományt munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` választja el a cellatartománytól, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli. A dollárjelek abszolút sor‑ és oszlophivatkozásokat jelölnek.

A metódus a jelenlegi tartományt olvassa anélkül, hogy megváltoztatná a diagramot vagy annak munkafüzetét. Ha a diagram nem munkafüzetet használ adatforrásként, kivételt dob. További információért lásd a [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) oldalt.

Ez a példa megnyit egy bemutatót, és közvetlenül minden dián ellenőrzi az alakzatokat diagramokra. Kiírja minden diagram nevét és forrás‑tartományát. Ha a tartomány lekérése sikertelen, diagnosztikai üzenetet ír ki, és a következő diagramra lép.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        for shape in slide.shapes:
            if isinstance(shape, charts.Chart):
                try:
                    data_range = shape.chart_data.get_range()
                    print(f"{shape.name}: {data_range}")
                except RuntimeError as error:
                    print(f"{shape.name}: Unable to retrieve the chart data range. {error}")
```

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides for Python via .NET biztosítja a [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) és a [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) metódusokat, amelyek lehetővé teszik a diagramadat‑munkafüzetek (Az Aspose.Cells‑kel szerkesztett diagramadatokat tartalmazó) olvasását és írását. **Megjegyzés:** a diagramadatoknak ugyanúgy kell felépítve lenniük, vagy hasonló szerkezettel kell rendelkezniük, mint a forrás.

Ez a példa egy olyan bemutatót használ, amelynek első alakzata az első dián egy diagram. Beolvassa a beágyazott munkafüzetet egy folyamba, törli a meglévő sorozatokat és kategóriákat, majd visszaírja ugyanazt a munkafüzetet. A változások memóriában maradnak; a példa nem menti a bemutatót.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
    else:
        print("The first shape is not a chart.")
```

### **Diagram elrendezésének ellenőrzése munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet egy módosított változattal helyettesít, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeket. Ez az eltérés miatt a [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) index‑tartomány‑hibával bukhat meg. Törölje a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírná a diagramba. Ez a példa egy olyan diagramot használ, amely az első dián az első alakzat. A megjegyzés azt jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet, és memóriában ellenőrzi az elrendezést.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Módosítsa a munkafüzet áramlatát itt, például az Aspose.Cells használatával.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

A gyűjtemények törlése megszünteti a régimódi adat‑hivatkozásokat, mielőtt a munkafüzet visszaírásra kerülne. Újra kell építeni a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használja.

## **Munkafüzetcellát diagramadat‑címkének beállítása**

A munkafüzet cellák szövegét használhatja diagram adatcímkékként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal egy meglévő bemutató első diájához. Az első sorozat első három címkéjéhez az 0‑s munkalap A10:A12 celláit használja, engedélyezi a cellákból származó címkéket, és menti a frissített bemutatót.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart2.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    series = chart.chart_data.series[0]
    workbook = chart.chart_data.chart_data_workbook

    series.labels.default_data_label_format.show_label_value_from_cell = True
    series.labels[0].value_from_cell = workbook.get_cell(0, "A10", "Label 0 cell value")
    series.labels[1].value_from_cell = workbook.get_cell(0, "A11", "Label 1 cell value")
    series.labels[2].value_from_cell = workbook.get_cell(0, "A12", "Label 2 cell value")

    presentation.save("resultchart.pptx", slides.export.SaveFormat.PPTX)
```

## **Munkalapok kezelése**

A [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) tulajdonság lehetővé teszi a diagram munkafüzet munkalapjaihoz való hozzáférést. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és minden munkalap nevét kiírja a konzolra.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 500)
    workbook = chart.chart_data.chart_data_workbook

    for worksheet in workbook.worksheets:
        print(worksheet.name)
```

## **Az adatforrás típusának megadása**

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozatnevet állít be különböző adatforrásokkal. Az első név egy szöveges literált használ; a második a 0‑s munkalap C1 celláját. A [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) enumerációval választható ki a forrás minden névhez. A példa menti a bemutatót a frissített sorozatnevekkel.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.COLUMN_3D, 50, 50, 600, 400, True)
    literal_name = chart.chart_data.series[0].name

    literal_name.data_source_type = charts.DataSourceType.STRING_LITERALS
    literal_name.data = "LiteralString"

    cell_name = chart.chart_data.series[1].name
    name_cell = chart.chart_data.chart_data_workbook.get_cell(0, "C1", "NewCell")
    cell_name.data_source_type = charts.DataSourceType.WORKSHEET
    cell_name.data = name_cell

    presentation.save("pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Nem támogatott beágyazott munkafüzetformátumok észlelése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely bizonyos diagramokban beágyazható. A [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) tulajdonságát a [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) enumerációval együtt használva észlelheti a nem támogatott formátumokat, és kihagyhatja az érintett diagramokat. Ez a példa a meglévő bemutató első diájának alakzatait vizsgálja, a nem‑diagram alakzatokat átugorja, és diagnosztikai üzenetet ír ki minden .xlsb munkafüzetet beágyazott diagramhoz.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if not isinstance(shape, charts.Chart):
            continue

        chart_data = shape.chart_data
        is_internal_workbook = chart_data.data_source_type == charts.ChartDataSourceType.INTERNAL_WORKBOOK
        is_binary_macro = chart_data.embedded_workbook_type == charts.WorkbookType.WORKBOOK_BINARY_MACRO

        if is_internal_workbook and is_binary_macro:
            print("Skipping a chart with an unsupported .xlsb workbook.")
            continue

        # Olvassa vagy módosítsa a támogatott diagram munkafüzet adatait itt.
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramadat‑forrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) és a [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódusokat a beágyazott diagram munkafüzet exportálásához fájlba, majd a diagram összekapcsolásához a külső munkafüzettel.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és exportálja a munkafüzetét. A kimeneti folyamot bezárja, mielőtt a külső munkafüzetet diagramadat‑forrásként beállítaná, majd elmenti a csatolt bemutatót.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600)
    workbook_path = str(Path("externalWorkbook1.xlsx").resolve())

    workbook_stream = chart.chart_data.read_workbook_stream()
    workbook_data = workbook_stream.read()
    with open(workbook_path, "wb") as file_stream:
        file_stream.write(workbook_data)

    chart.chart_data.set_external_workbook(workbook_path)

    presentation.save("externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

### **Külső munkafüzet beállítása**

A [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódussal külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ezzel a metódussal frissíthető a külső munkafüzettel való elérési út (ha az áthelyezésre került).

Miközben a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkeszthető közvetlenül, továbbra is használhatók külső adatforrásként. Ha relatív elérési utat ad meg egy külső munkafüzettel, azt automatikusan teljes elérési úttá alakítja a rendszer.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` nevű munkalapja B1‑ben tartalmaz egy sorozatnevet, A2:A4‑ben kategórianév‑listát, és B2:B4‑ben számértékeket. A példa egy kördiagramot hoz létre, összekapcsolja a munkafüzetet, és a [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) segítségével az A1:B4‑et egy sorozatra és három kategóriára térképezi. A diagrammal együtt menti a bemutatót.

```python
from pathlib import Path
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart_data = chart.chart_data
    workbook_path = str(Path("externalWorkbook.xlsx").resolve())

    chart_data.set_external_workbook(workbook_path)
    chart_data.set_range("Sheet1!$A$1:$B$4")

    presentation.save("Presentation_with_externalWorkbook.pptx", slides.export.SaveFormat.PPTX)
```

A [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) `update_chart_data` paramétere szabályozza, hogy a munkafüzet be legyen‑töltve.

* Ha `update_chart_data` `False`, csak a munkafüzet elérési útja frissül. A diagramadatok nem töltődnek be vagy frissülnek a célmunkafüzetről, így a munkafüzet lehet, hogy nem is érhető el.
* Ha `update_chart_data` `True`, a diagramadatok a célmunkafüzetről frissülnek.

Az alábbi példa egy helyettesítő URL‑t rendel hozzá `update_chart_data` értéke `False`. A kördiagram alapértelmezett adatai megmaradnak, és a bemutató mentésre kerül anélkül, hogy a nem elérhető munkafüzet betöltésre kerülne.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Diagram külső adatforrás‑munkafüzete elérési útjának lekérése**

A diagramhoz csatolt munkafüzet azonosításához ellenőrizze, hogy a diagram külső adatforrást használ‑e, és szerezze meg annak munkafüzet‑elérési útját.

Ez a példa a bemutató első diájának első alakzatát vizsgálja, amely egy külső munkafüzettel csatolt diagram. Ha ez egy diagram, amely külső munkafüzettel van összekapcsolva, a példa kiírja a [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) értékét a konzolra, majd elmenti a bemutató egy másolatát.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("externalWorkbook.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        if chart_data.data_source_type == charts.ChartDataSourceType.EXTERNAL_WORKBOOK:
            print(chart_data.external_workbook_path)
        else:
            print("The chart does not use an external workbook.")
    else:
        print("The first shape is not a chart.")

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

### **Diagramadatok szerkesztése**

A külső munkafüzet adatai szerkeszthetők ugyanúgy, ahogy a belső munkafüzet esetén. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első dián az első alakzat, és egy hozzáférhető külső munkafüzettel van összekapcsolva. A első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, és menti a frissített bemutatót. A cella értékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért szükség esetén használjon másolatot, ha az eredeti munkafüzetet meg kell őrizni.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        series = chart.chart_data.series
        if len(series) > 0 and len(series[0].data_points) > 0:
            value_cell = series[0].data_points[0].value.as_cell
            if value_cell is not None:
                value_cell.value = 100
                presentation.save("presentation_out.pptx", slides.export.SaveFormat.PPTX)
            else:
                print("The first data point is not linked to a workbook cell.")
        else:
            print("The chart has no data points to edit.")
    else:
        print("The first shape is not a chart.")
```

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides helyreállíthatja a diagram munkafüzetét a bemutatóban tárolt gyorsítótár‑adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) objektumot, konfigurálja a [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/) beállítást, és állítsa a [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) értékét `True`‑re, mielőtt megnyitná a bemutatót.

Az alábbi Python‑példa helyreállítja a munkafüzet adatokat egy olyan diagramhoz, amely az első dián az első alakzat, és egy nem elérhető külső munkafüzettel hivatkozik. A helyreállított adatokat a [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) és a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) segítségével érheti el:

```python
import aspose.slides as slides
import aspose.slides.charts as charts

load_options = slides.LoadOptions()
load_options.spreadsheet_options.recover_workbook_from_chart_cache = True

with slides.Presentation("presentation.pptx", load_options) as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        recovered_workbook = chart.chart_data.chart_data_workbook

        # Olvassa vagy módosítsa a helyreállított munkafüzet adatait itt.
    else:
        print("The first shape is not a chart.")
```

Ha a külső munkafüzet nem elérhető és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótár‑diagramadatok használata elfogadható tartalék, mivel a gyorsítótár nem tartalmazhatja a külső munkafüzetben a bemutató legutóbbi frissítése után történt változásokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzettel van-e összekapcsolva?**

Igen. A diagramnek van egy [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) és egy [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); ha a forrás külső munkafüzet, akkor kiolvashatja a teljes elérési utat, hogy megbizonyosodjon egy külső fájl használatáról.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hol tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút útvonallá. A bemutató az abszolút útvonalat tárolja a PPTX fájlban, így a munkafüzet áthelyezésekor frissíteni kell a hivatkozást.

**Használhatók hálózati erőforrások/ megosztásokon lévő munkafüzetek?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a bemutató mentésekor?**

A bemutató tárol egy [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/). A cellákra alapozott diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt. Ha az eredetit változatlanul kell hagyni, használjon másolatot a munkafüzetről.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad el jelszót a csatoláshoz. Általános megoldás, hogy a védelmet előzetesen eltávolítja, vagy egy dekódolt másolatot készít (például az [Aspose.Cells](https://reference.aspose.com/cells/python-net/) segítségével), és arra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mind ugyanarra a fájlra mutatnak, a fájl frissítése minden diagramnál megjelenik a következő alkalommal, amikor az adat betöltődik.