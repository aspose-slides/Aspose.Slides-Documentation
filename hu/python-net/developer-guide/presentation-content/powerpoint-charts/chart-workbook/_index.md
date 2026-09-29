---
title: Diagram munkafüzetek kezelése prezentációkban Python használatával
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/python-net/chart-workbook/
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
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Python via .NET-et: könnyedén kezelje a diagram munkafüzeteket a PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet dolgozni diagram munkafüzetekkel az Aspose.Slides-ban. Bemutatja, hogyan lehet olvasni és írni diagram adatokat munkafüzet adatfolyamokon keresztül, a munkafüzet cellákat diagram adatcímkékként használni, a munkalap-gyűjteményekhez hozzáférni, és megadni az adatforrás típusát a diagram értékekhez.

A cikk kitér a külső munkafüzetek diagram adatforrásként történő használatára is. A példák bemutatják, hogyan lehet létrehozni és hozzárendelni egy külső munkafüzetet, lekérni a diagramhoz kapcsolt külső munkafüzet útvonalát, és szerkeszteni a diagram adatokat, ha a munkafüzet elérhető.

A hiányzó adatot jelző munkafüzet cellák esetén lásd a [Control the Display of Empty Cells](/slides/hu/python-net/chart-series/) című oldalát az üres cella és a nulla közti különbségről, valamint egy vonaldiagram‑összehasonlítást a rendelkezésre álló megjelenítési módokról.

## **Rejtett sorok és oszlopok adatainak bevonása**

Használd a [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) metódust annak szabályozására, hogy a diagram a rejtett munkalap sorok és oszlopok adatait is felhasználja-e. Állítsd `True`‑ra, hogy csak a látható cellákat ábrázolja, vagy `False`‑ra, hogy a látható és rejtett cellákat egyaránt vegye számításba. Ez a beállítás a diagram rajzolását befolyásolja; nem rejti el vagy jeleníti meg a munkalap sorait vagy oszlopait.

Töltsd le a [hidden-source-data.pptx](hidden-source-data.pptx) fájlt, és helyezd a munkakönyvtárba. Az első dia egy oszlopdiagramot tartalmaz első alakzatként. A beágyazott munkalap, `Sheet1`, a következő forrástartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik továbbra is tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | Január | 10 | 30 |
| 3 (rejtett sor) | Február | 40 | 60 |
| 4 | Március | 20 | 50 |

A forráscellákhoz a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) segítségével férhetsz hozzá, és a [ChartDataCell.is_hidden](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdatacell/is_hidden/) segítségével ellenőrizheted azok rejtett állapotát. Ez a tulajdonság csak olvasható. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa sorban `False`, `True`, `True` értékeket ír ki.

Ehhez a példához frissítsd a diagram adatot a rajzolási beállítás módosítása után: tartsd meg a beágyazott munkafüzetet a [read_workbook_stream](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) segítségével, és töltse be újra a [write_workbook_stream](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) használatával. Ha minden cellát fel szeretnél venni, használd a [set_range](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_range/) metódust a teljes tartomány, köztük a rejtett februári kategória visszaállításához. Csak a jelző megváltoztatása nem elegendő a mintában tárolt diagram adat és kategóriacímkék frissítéséhez.

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

            # Frissítse a diagram adatot a beágyazott munkafüzetről.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Állítsa vissza a teljes forrástartományt, beleértve a rejtett kategóriákat.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

A példa a `hidden_cells_True.pptx` fájlt csak a látható Kiskereskedelem értékekkel (10 és 20) menti, míg a `hidden_cells_False.pptx` fájlt mind a hat értékkel. Az alábbi képek a mentett prezentációk újbóli megnyitása után lettek renderelve; mindkét fájl megőrzi a beállított rajzolási módot. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`True`) | Minden cella (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Egy rejtett, értéket tartalmazó cella különbözik az üres cellától. A [Chart.display_blanks_as](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/display_blanks_as/) szabályozza, hogyan jelenjenek meg a hiányzó értékek; ez nem vonja be vagy zárja ki a rejtett forrásadatot. Lásd a [Control the Display of Empty Cells](/slides/hu/python-net/chart-series/#control-the-display-of-empty-cells) oldalt egy példáért.

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides for Python via .NET biztosítja a [read_workbook_stream](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) és a [write_workbook_stream](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) metódusokat, amelyek lehetővé teszik diagramadat munkafüzetek (Aspose.Cells‑sel szerkesztett diagramadatok) olvasását és írását. **Note** hogy a diagramadatnak ugyanúgy kell felépítve lennie, vagy hasonló szerkezettel kell rendelkeznie, mint a forrás.

Ez a példa megnyitja a `chart.pptx` fájlt, amelynek első diájának első alakzata diagram kell legyen. A beágyazott munkafüzetet egy adatfolyamba olvassa, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet visszaírja. A változtatások csak memóriában maradnak; a példa nem menti a prezentációt.

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

### **Diagramelrendezés ellenőrzése a munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet egy módosított változatra cserélsz, a diagram megtartja az eredeti sorozat- és kategóriagyűjteményeket. Ez a nem egyezés a [Chart.validate_chart_layout](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/validate_chart_layout/) hibához vezethet index‑out‑of‑range kivétellel. Töröld a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírnád a diagramba. Ez a példa `chart.pptx`‑t igényel, amelynek első alakzata diagram legyen az első dián. A megjegyzés jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet, és ellenőrzi a kiosztást memóriában.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Módosítsa a munkafüzet adatfolyamot itt, például az Aspose.Cells használatával.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

A gyűjtemények törlése eltávolítja a régi adatreferenciákat, mielőtt a munkafüzet visszaírásra kerül. Építsd fel újra a szükséges sorozat- és kategória-leképezéseket a frissített munkafüzethez, mielőtt a diagramot használnád.

## **Munkafüzet cella beállítása diagramadatcímkeként**

A munkafüzet cellák szövegét felhasználhatod diagramadatcímkeként. Az alábbi lépések bemutatják, hogyan kapcsolható a buborékdiagram címkéi a data‑workbook celláihoz.

1. Hozz létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt.
1. Érd el az első diát a nullás index alapján.
1. Adj hozzá egy buborékdiagramot alapértelmezett adatokkal.
1. Érd el a diagram sorozatát.
1. Állítsd be a munkafüzet cellát adatcímkének.
1. Mentsd el a prezentációt.

Ez a példa megnyitja a `chart2.pptx` fájlt, amelynek legalább egy diát tartalmaznia kell, majd hozzáad egy buborékdiagramot alapértelmezett adatokkal. Az 0‑adik munkalap A10:A12 celláit használja az első sorozat első három címkéjéhez, engedélyezi a cellákból származó címkéket, és elmenti az eredményt `resultchart.pptx`‑ként.

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

A [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) tulajdonság a diagram munkafüzetének munkalapjaihoz biztosít hozzáférést. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és minden munkalap nevét kiírja a konzolra.

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

## **Az adatforrás típusának meghatározása**

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat nevet állít be különböző adatforrások használatával. Az első név egy karakterlánc literál, a második a 0‑adik munkalap C1 cellája. A [DataSourceType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/datasourcetype/) felsorolás választja ki az egyes nevek forrását. Az eredményt `pres.pptx`‑ként menti.

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

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely néhány diagramba beágyazható. Használhatod a [embedded_workbook_type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) tulajdonságot a [ChartData](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/) osztályon együtt a [WorkbookType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/workbooktype/) felsorolással a nem támogatott formátumok észleléséhez, és kihagyhatod azokat a diagramokat. Ez a példa az `sample.pptx` első diáján lévő alakzatokat vizsgálja, kihagyja a nem‑diagram alakzatokat, és diagnosztikai üzenetet ír ki minden olyan diagramhoz, amely beágyazott .xlsb munkafüzetet tartalmaz.

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

        # Olvassa vagy módosítsa a támogatott diagram munkafüzet adatokat itt.
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramok adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használd a [read_workbook_stream](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) és a [set_external_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódusokat a beágyazott diagram munkafüzet exportálásához egy fájlba, és a diagram külső munkafüzethez való kapcsolásához.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, a munkafüzetét `externalWorkbook1.xlsx`‑re írja, majd a kimeneti adatfolyamot bezárja, mielőtt a fájlt a diagram adatforrásaként hozzárendeli. A kapcsolt prezentációt `externalWorkbook.pptx`‑ként menti.

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

A [set_external_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódus segítségével egy külső munkafüzetet rendelhetsz a diagramhoz adatforrásként. Ezzel a módszerrel frissítheted a külső munkafüzet útvonalát is (ha azt áthelyezték).

Bár távoli helyen vagy erőforrásban tárolt munkafüzeteket nem szerkeszthetsz közvetlenül, továbbra is használhatók külső adatforrásként. Ha relatív útvonalat adsz meg a külső munkafüzethez, az automatikusan teljes úttá konvertálódik.

Ez a példa egy `externalWorkbook.xlsx` fájlt igényel a munkakönyvtárban. Ennek a `Sheet1` munkalapnak B1‑ben sorozatnevet, A2:A4‑ben kategórianéveket és B2:B4‑ben numerikus értékeket kell tartalmaznia. A példa egy kördiagramot hoz létre, kapcsolja a munkafüzetet, és a [set_range](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_range/) metódussal az A1:B4 tartományt egy sorozatra és három kategóriára képezi le. Az eredményt `Presentation_with_externalWorkbook.pptx`‑ként menti.

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

A [set_external_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/set_external_workbook/) `update_chart_data` paramétere szabályozza, hogy a munkafüzet betöltődjön‑e.

* Ha `update_chart_data` értéke `False`, csak a munkafüzet útvonala frissül. A diagram adatokat nem tölti be vagy frissíti a célmunkafüzetről, így a munkafüzet hiányozhat.
* Ha `update_chart_data` értéke `True`, a diagram adatokat frissíti a célmunkafüzetről.

Az alábbi példa egy helyőrző URL‑t ad meg `update_chart_data` értékével `False`‑ra állítva. Megőrzi a kördiagram alapértelmezett adatait, és a prezentációt a nem‑betöltött munkafüzet nélkül menti.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)

    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **A diagram külső adatforrás munkafüzetének útvonalának lekérése**

A diagramhoz kapcsolt munkafüzet azonosításához először ellenőrizd, hogy a diagram külső adatforrást használ‑e. Ha igen, a következő lépésekkel szerezheted meg a munkafüzet útvonalát.

1. Hozz létre egy [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) példányt.
1. Érd el az első diát a nullás index alapján.
1. Ellenőrizd, hogy az első alakzat diagram‑e.
1. Olvasd ki a diagram adatforrás típusát.
1. Ha a forrás külső munkafüzet, olvasd ki annak útvonalát.

Ez a példa megnyitja a `externalWorkbook.pptx` fájlt, amelyet az előző példában hoztunk létre, és ellenőrzi az első dián lévő első alakzatot. Ha ez egy külső munkafüzethez kapcsolt diagram, a példa a [external_workbook_path](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/external_workbook_path/) értékét írja a konzolra. Ezután a prezentáció egy másolatát `Result.pptx`‑ként menti.

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

### **Diagram adatainak szerkesztése**

A külső munkafüzet adatainak szerkesztése ugyanúgy történik, mint a belső munkafüzet esetén. Ha a külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a példa egy `presentation.pptx` fájlt igényel, amelynek első diáján az első alakzatnak diagramnak kell lennie, valamint egy elérhető külső munkafüzetnek. A példa az első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, és a prezentációt `presentation_out.pptx`‑ként menti. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért használj másolatot, ha az eredeti munkafüzetet meg akarod őrizni.

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

### **Munkafüzet visszaállítása a diagram gyorsítótárából**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides helyreállíthatja a diagram munkafüzetet a prezentációban tárolt gyorsítótárból. Hozz létre egy [LoadOptions](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/) példányt, konfiguráld a [spreadsheet_options](https://reference.aspose.com/slides/hu/python-net/aspose.slides/loadoptions/spreadsheet_options/) beállítást, és a [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/hu/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) tulajdonságot állítsd `True`‑ra a prezentáció megnyitása előtt.

Az alábbi Python példa megnyitja a `presentation.pptx` fájlt, amelynek első diáján az első alakzatnak egy diagramnak kell lennie, amely egy nem elérhető külső munkafüzetre hivatkozik, majd a helyreállított adatokat a [Chart.chart_data](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/chart_data/) és a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) segítségével érheti el:

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

        # Olvassa vagy módosítsa a helyreállított munkafüzet adatokat itt.
    else:
        print("The first shape is not a chart.")
```

Ha a külső munkafüzet nem érhető el és a visszaállítás ki van kapcsolva, az Aspose.Slides kivételt dob. Engedélyezd a visszaállítást csak akkor, ha a gyorsítótárbeli diagramadatok használata elfogadható alternatíva, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció legutóbbi frissítése után történt módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez kapcsolódik?**

Igen. A diagramnak van egy [data source type](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/data_source_type/) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/external_workbook_path/); ha a forrás külső munkafüzet, a teljes útvonal kiolvasásával ellenőrizheted, hogy külső fájlt használnak‑e.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat adsz meg, az automatikusan átalakul abszolút útvonalá. A prezentáció az abszolút útvonalat tárolja a PPTX fájlban, így a munkafüzet áthelyezése esetén a hivatkozás frissítése szükséges lehet.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztásokon?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑el nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chartdata/external_workbook_path/) tárol. A cella‑alapú diagramadatok szerkesztése szintén frissítheti a kapcsolt helyi XLSX fájlt. Használj másolatot a munkafüzetről, ha az eredetit érintetlenül kell hagyni.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad el jelszót a hivatkozáskor. Általános megoldás a védelem előzetes eltávolítása vagy egy dekódolt másolat előkészítése (például az [Aspose.Cells](https://reference.aspose.com/cells/python-net/) használatával), majd a másolatra való hivatkozás.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha ugyanarra a fájlra mutatnak, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.