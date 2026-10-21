---
title: "Grafikon munkafüzetek kezelése prezentációkban Python segítségével"
linktitle: "Grafikon munkafüzet"
type: docs
weight: 70
url: /hu/python-net/chart-workbook/
keywords:
- "grafikon munkafüzet"
- "grafikon adat"
- "munkafüzet cella"
- "adatcímke"
- "munkalap"
- "adatforrás"
- "külső munkafüzet"
- "külső adat"
- "grafikon gyorsítótár"
- "munkafüzet helyreállítás"
- "PowerPoint"
- "prezentáció"
- "Python"
- "Aspose.Slides"
description: "Fedezze fel az Aspose.Slides for Python via .NET-et: könnyedén kezelje a grafikon munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse a prezentáció adatokat."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet dolgozni diagram munkafüzetekkel az Aspose.Slides-ben. Megmutatja, hogyan lehet beolvasni és írni diagram adatokat munkafüzet adatfolyamokon keresztül, hogyan lehet munkafüzet cellákat használni diagram adatcímkeként, a munkalapgyűjtemények elérését, és hogyan lehet megadni az adatforrás típusát a diagram értékekhez.

Az is bemutatásra kerül, hogyan lehet külső munkafüzeteket használni diagram adatforrásként. A példák azt demonstrálják, hogyan hozhatunk létre és adhatunk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz csatolt külső munkafüzet útvonalát, és hogyan szerkeszthetjük a diagram adatokat, ha a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzet cellákkal kapcsolatban lásd a [Az üres cellák megjelenítésének szabályozása](/slides/hu/python-net/chart-series/) oldalt, ahol az üres cella és a null érték közti különbséget, valamint a rendelkezésre álló megjelenítési módok vonaldiagram összehasonlítását mutatják be.

## **Rejtett sorok és oszlopok adatinak belefoglalása**

Használd a [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) metódust annak szabályozására, hogy a diagram csak a látható munkalap sorokból és oszlopokból vegye figyelembe az adatokat. Állítsd `True` értékre, ha csak a látható cellákat szeretnéd ábrázolni, vagy `False` értékre, ha a látható és rejtett cellákat egyaránt fel akarod venni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejt el vagy jelenít meg munkalap sorokat vagy oszlopokat.

A [példa bemutató](hidden-source-data.pptx) egy oszlopdiagramot tartalmaz, amely az első dián az első alakzat. A beágyazott munkalap, `Sheet1`, a következő forrás tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de a celláik továbbra is tartalmaznak értékeket.

| Munkalap sora | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (rejtett sor) | February | 40 | 60 |
| 4 | March | 20 | 50 |

A forrás cellák eléréséhez használd a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) tulajdonságot, és olvasd a [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) értékét a rejtett állapot vizsgálatához. Ez a tulajdonság csak olvasható. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa `False`, `True`, és `True` értékeket ír ki.

Ehhez a példához frissíteni kell a diagram adatot a beállítás módosítása után: tartsd meg a beágyazott munkafüzetet a [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) metódussal, majd töltsd be újra a [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) segítségével. Ha az összes cellát felveszed, használd a [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) metódust a teljes tartomány helyreállításához, beleértve a rejtett februári kategóriát is. Csak a jelző megváltoztatása nem elegendő a gyorsítótárazott diagram adat és a kategória címkék frissítéséhez.

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

A példa két változatban menti a bemutatót: egyben csak a látható Kiskereskedelem értékek (10 és 20) szerepelnek, a másikban mind a hat érték. Az alábbi képek a mentett bemutatók újra megnyitása után kerültek renderelésre; mindkét fájl megőrzi a beállított ábrázolási módot. A 3. sor és a C oszlop továbbra is rejtett marad mindkét beágyazott munkafüzetben.

| Csak látható cellák (`True`) | Összes cella (`False`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelmi értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelmi és nagykereskedelmi értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy értéket tartalmazó rejtett cella különbözik egy üres cellától. A [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) szabályozza, hogyan jelennek meg a hiányzó értékek; nem befolyásolja a forrás adat rejtett vagy nem rejtett állapotát. Lásd a [Az üres cellák megjelenítésének szabályozása](/slides/hu/python-net/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat tartományának lekérdezése**

Mielőtt egy meglévő bemutatóban módosítanád a munkafüzet adatát, ellenőrizd a forrás tartományokat, hogy megtudd, mely munkalap cellákat használja egy diagram. A [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) metódus a jelenlegi adat tartományt adja vissza munkalapra hivatkozó képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, az `!` elválasztja a cellatartományt, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli. A dollárjelek abszolút sor- és oszlophivatkozást jelentenek.

A metódus a tartományt csak olvassa, anélkül, hogy módosítaná a diagramot vagy a munkafüzetet. Ha a diagram nem használ munkafüzetet adatforrásként, kivételt dob. További információért lásd a [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) oldalt.

Ez a példa megnyit egy bemutatót, és közvetlenül a diák alakzataiban keresi a diagramokat. Kiírja minden diagram nevét és forrás tartományát. Ha a tartományt nem lehet lekérdezni, diagnosztikus üzenetet jelenít meg, majd a következő diagramra lép tovább.

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

## **Diagram adatok olvasása és írása munkafüzetből**

Az Aspose.Slides for Python via .NET biztosítja a [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) és a [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) metódusokat, amelyek lehetővé teszik a diagram adat munkafüzetek (az Aspose.Cells‑kel szerkesztett diagram adatokat tartalmazó) beolvasását és írását. **Megjegyzés** hogy a diagram adatainak ugyanúgy kell felépülniük, vagy hasonló struktúrával kell rendelkezniük, mint a forrás.

Ez a példa egy bemutatót használ, amelynek első diáján az első alakzat egy diagram. Beolvassa a beágyazott munkafüzetet egy adatfolyamba, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet visszaírja. A változtatások csak a memóriában maradnak; a példa nem menti a bemutatót.

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

Amikor egy beágyazott munkafüzetet egy módosított verzióval cserélsz, a diagram megtartja az eredeti sorozat- és kategória gyűjteményeit. Ez a nem egyezés a [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) hibához vezethet, ha a sorozat indexe kívül esik a tartományon. Töröld a meglévő sorozatokat és kategóriákat, mielőtt visszaírnád a frissített munkafüzetet a diagramra. Ez a példa egy diagramot használ, amely az első dián az első alakzat. A megjegyzés jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet, és a memóriában ellenőrzi az elrendezést.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Módosítsa itt a munkafüzet adatfolyamot, például az Aspose.Cells használatával.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

A gyűjtemények törlése megszünteti a régi adat hivatkozásokat, mielőtt a munkafüzet visszaírásra kerül. Építsd újra a szükséges sorozat- és kategória leképezéseket a frissített munkafüzethez, mielőtt használod a diagramot.

## **Egyedi számformátumok beállítása munkafüzet cellákhoz**

Használd a [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) metódust annak szabályozására, hogyan jelenjenek meg a numerikus értékek egy diagram beágyazott munkafüzetében. Például egy jelentésnek százalékos arányt kell megjelenítenie négy tizedesjeggyel, illetve egy koefficiens öt tizedesjeggyel. Mindkét értéket numeric formában tartsd, hogy elérhetőek maradjanak a számításokhoz és a diagram ábrázoláshoz.

Egy számformátum csak a megjelenítést változtatja, nem a tárolt értéket. A `0.0000%` formátum `0.125` értéket `12.5000%`‑ként jelenít meg; nem helyettesíti a tárolt számot `12.5`‑tel. Hasonlóképpen a `0.00000` formátum `0.1234567`‑et `0.12346`‑ként jelenít meg, anélkül, hogy a tárolt értéket kerekítené. Ha az egyedi formátum üres karakterlánc (`""`), akkor a [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) lesz használva.

Az alábbi példa egy oszlopdiagramot hoz létre, és a celláit a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) segítségével érinti. A 0. munkalapon a B2 tartalmazza a konverziós rátát, a C2 pedig a koefficienset. Mindkét cella diagramértéket szolgáltat. A példa a forrás formátumokhoz kapcsolt értékcímkéket is engedélyezi.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    presentation.slide_size.set_size(720, 270, slides.SlideSizeScaleType.DO_NOT_SCALE)
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 20, 620, 210)
    chart.has_title = False

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00"
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = 0

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    category_cell = workbook.get_cell(0, "A2", "Sample")
    chart.chart_data.categories.add(category_cell)

    percentage_cell = workbook.get_cell(0, "B2", 0.125)
    percentage_cell.custom_number_format = "0.0000%"
    percentage_name = workbook.get_cell(0, "B1", "Conversion rate")
    percentage_series = chart.chart_data.series.add(percentage_name, chart.type)
    percentage_series.data_points.add_data_point_for_bar_series(percentage_cell)

    precision_cell = workbook.get_cell(0, "C2", 0.1234567)
    precision_cell.custom_number_format = "0.00000"
    precision_name = workbook.get_cell(0, "C1", "Coefficient")
    precision_series = chart.chart_data.series.add(precision_name, chart.type)
    precision_series.data_points.add_data_point_for_bar_series(precision_cell)

    for series in chart.chart_data.series:
        label_format = series.data_points[0].label.data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = True

    presentation.save("CustomCellFormats.pptx", slides.export.SaveFormat.PPTX)
```

A munkafüzet cellaformátumok különböznek a diagram tengelyeken vagy adatcímkéken közvetlenül beállított formátumoktól. Ebben a példában minden címke a forrás cellájának értékét jeleníti meg, mert a [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) engedélyezve van, és a forrás számformátumot követi, mivel az [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) `True`. A bemutató mentése és újra megnyitása után a címkék `12.5000%` és `0.12346` értékeket mutatják, ahogy alább látható. A függőleges tengely saját [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) `0.00`‑t használ, és az [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) `False`.

Egy adatcímke független formázásához állítsd a forrás‑link zászlót `False`‑ra, és add meg a saját [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) értékét. Ez nem változtatja meg a munkafüzet cellájának formátumát. Például egy önálló címkeformátum `0.00` megjeleníti az első értéket `0.13`‑ként, míg a B2 továbbra is `12.5000%`‑ot mutat. Lásd a [Diagram adatcímkék](/slides/hu/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) oldalt a címkék közvetlen formázásához.

![Oszlopdiagram forrásra hivatkozó címkékkel, amelyek 12.5000%-ot és 0.12346-ot mutatnak, valamint önállóan formázott numerikus tengely.](custom-cell-formats.png)

## **Munkafüzet cella beállítása diagram adatcímkeként**

Használhatod a munkafüzet cellákban lévő szöveget diagram adatcímkeként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal a meglévő bemutató első diájához. A 0. munkalap A10:A12 tartományát használja az első három címke első sorozatában, engedélyezi a cellákból származó címkéket, és elmenti a módosított bemutatót.

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

A [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) tulajdonság biztosítja a diagram munkafüzetében lévő munkalapok elérését. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és a konzolra kiírja minden munkalap nevét.

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

## **Adatforrás típusának megadása**

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozatnévhez különböző adatforrásokat állít be. Az első név egy karakterlánc literál, a második a 0. munkalap C1 cellájából származik. A [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) felsorolás választja ki a forrást minden névhez. A példa elmenti a bemutatót a frissített sorozatnevekkel.

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

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely bizonyos diagramokban beágyazható. Használhatod a [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) tulajdonságot a [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) mellett a [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) felsorolással, hogy észleld a nem támogatott formátumokat, és kihagyd az ilyen diagramokat. Ez a példa a meglévő bemutató első diáján lévő alakzatokat vizsgálja, kihagyja a nem diagram alakzatokat, és diagnosztikus üzenetet ír ki minden, .xlsb beágyazott munkafüzettel rendelkező diagramhoz.

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

Az Aspose.Slides támogatja a külső munkafüzetek diagram adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használd a [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) és a [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódusokat egy beágyazott diagram munkafüzet exportálásához fájlba, majd a diagram csatolásához ehhez a külső munkafüzethez.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, majd exportálja a munkafüzetet. A kimeneti adatfolyamot lezárja, mielőtt a külső munkafüzetet diagram adatforrásként beállítaná, majd elmenti a csatolt bemutatót.

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

A [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódus segítségével egy külső munkafüzetet rendelhetsz egy diagramhoz adatforrásként. Ez a metódus használható a külső munkafüzet útvonalának frissítésére is (ha azt elmozdították).

Bár nem szerkesztheted a távoli helyen vagy erőforrásban tárolt munkafüzetek adatait, továbbra is használhatod őket külső adatforrásként. Ha relatív útvonalat adsz meg egy külső munkafüzethez, az automatikusan teljes útvonallá alakul.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` nevű munkalapján a B1 cellában egy sorozatnév, az A2:A4 tartományban kategórianevek, a B2:B4 tartományban pedig numerikus értékek vannak. A példa egy kördiagramot hoz létre, csatolja a munkafüzetet, és a [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) segítségével az A1:B4 tartományt egy sorozatra és három kategóriára leképezi. Elmenti a bemutatót a csatolt diagrammal.

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

A [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) `update_chart_data` paramétere szabályozza, hogy a munkafüzet betöltődjön‑e.

* Ha `update_chart_data` **False**, csak a munkafüzet útvonalát frissíti. A diagram adatai nem töltődnek be vagy frissülnek a célmunkafüzetről, így a munkafüzet elérhetetlen is lehet.
* Ha `update_chart_data` **True**, a diagram adatai a célmunkafüzetről frissülnek.

Az alábbi példa egy helyőrző URL‑t ad meg, ahol az `update_chart_data` **False** értékre van állítva. A kördiagram alapértelmezett adatait megtartja, és a bemutatót anélkül menti el, hogy betöltené a nem elérhető munkafüzetet.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **Diagram külső adatforrás munkafüzet útvonalának lekérdezése**

A diagramhoz csatolt munkafüzet azonosításához ellenőrizd, hogy a diagram külső adatforrást használ‑e, majd kérd le annak munkafüzet útvonalát.

Ez a példa a bemutató első diájának első alakzatát vizsgálja, amely egy külső munkafüzettel csatolt diagram. Ha ez egy diagram, amely külső munkafüzettel kapcsolódik, a példa a [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) értékét írja ki a konzolra, majd ment egy másolatot a bemutatóból.

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

A külső munkafüzetek adatait ugyanúgy szerkesztheted, mint a belső munkafüzetekét. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első dián az első alakzat, és egy elérhető külső munkafüzettel van összekapcsolva. A első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, majd elmenti a frissített bemutatót. A cellaértékek szerkesztése frissítheti a csatolt külső XLSX fájlt, ezért használj másolatot, ha az eredeti munkafüzetet meg akarod őrizni.

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

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides helyre tudja állítani a diagram munkafüzetet a bemutatóban gyorsítótárazott adatokból. Hozz létre egy [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) objektumot, konfiguráld a [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/) beállítást, és állítsd a [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) értékét **True**-ra, mielőtt megnyitnád a bemutatót.

Az alábbi Python példa helyreállítja a munkafüzet adatokat egy olyan diagramhoz, amely az első dián az első alakzat, és egy nem elérhető külső munkafüzettel hivatkozik. A helyreállított adatokat a [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) és a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) segítségével érheti el:

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

Ha a külső munkafüzet nem érhető el, és a helyreállítás ki van kapcsolva, az Aspose.Slides kivételt dob. Csak akkor engedélyezd a helyreállítást, ha a gyorsítótárazott diagram adatok használata elfogadható megoldás, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a bemutató legutóbbi frissítése után történt változásokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van‑e csatolva?**

Igen. A diagramnak van egy [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) és egy [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); ha a forrás egy külső munkafüzet, kiolvashatod a teljes útvonalat, hogy megbizonyosodj róla, egy külső fájlt használsz.

**Támogatottak-e a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat adsz meg, azt a rendszer automatikusan abszolút útvonallá konvertálja. A bemutató az abszolút útvonalat tárolja a PPTX fájlban, ezért a munkafüzet áthelyezése esetén a hivatkozást frissíteni kell.

**Használhatók‑e a hálózati erőforrásokon/megosztott helyeken lévő munkafüzetek?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑el nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja‑e a külső XLSX‑et a bemutató mentésekor?**

A bemutató egy [linket a külső fájlhoz](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) tárol. A cella‑alapú diagram adat szerkesztése frissítheti a kapcsolt helyi XLSX‑fájlt is. Ha az eredetit változatlanul kell hagyni, használj másolatot a munkafűzetből.

**Mit kell tenni, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a hivatkozáskor. Egy általános megoldás a védelem eltávolítása előre, vagy egy dekódolt másolat előkészítése (például az [Aspose.Cells](https://reference.aspose.com/cells/python-net/) használatával), majd a másolatra való hivatkozás.

**Több diagram hivatkozhat‑e ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját hivatkozást tárol. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.