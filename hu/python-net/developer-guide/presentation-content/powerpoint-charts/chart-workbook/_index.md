---
title: Diagram munkafüzetek kezelése bemutatókban Python segítségével
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
- bemutató
- Python
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Python via .NET-et: könnyedén kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse bemutatóinak adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan kell dolgozni diagram munkafüzetekkel az Aspose.Slides-ban. Bemutatja, hogyan lehet beolvasni és írni a diagram adatait munkafüzet‑adatfolyamokon keresztül, hogyan lehet a munkafüzet cellákat diagram adatcímkékként használni, hogyan lehet elérni a munkalap‑gyűjteményeket, és hogyan lehet megadni az adatforrás típusát a diagram értékekhez.

Emellett tárgyalja a külső munkafüzetek diagram adatforrásként való használatát. A példák bemutatják, hogyan lehet külső munkafüzetet létrehozni és hozzárendelni, hogyan lehet lekérdezni egy diagramhoz csatolt külső munkafüzet útvonalát, és hogyan lehet szerkeszteni a diagram adatokat, ha a munkafüzet rendelkezésre áll.

A hiányzó adatot jelző munkafüzet‑cellák esetén lásd a [Üres cellák megjelenítésének szabályozása](/slides/hu/python-net/chart-series/) az üres cella és a nulla közti különbségért, valamint egy vonaldiagram összehasonlítást a rendelkezésre álló megjelenítési módokról.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használja a [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) tulajdonságot annak szabályozására, hogy a diagram a rejtett munkalap‑sorok és -oszlopok adatait ábrázolja-e. Állítsa `True`‑ra, hogy csak a látható cellákat ábrázolja, vagy `False`‑ra, hogy a látható és a rejtett cellákat is belefoglalja. Ez a beállítás a diagram ábrázolását szabályozza; nem rejt el vagy mutat fel munkalap‑sorokat vagy -oszlopokat.

A [példa bemutató](hidden-source-data.pptx) első diájának első alakzata egy oszlopdiagram. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de a celláik még mindig tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | január | 10 | 30 |
| 3 (rejtett sor) | február | 40 | 60 |
| 4 | március | 20 | 50 |

A forráscellákat a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) segítségével érheti el, és a [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) segítségével ellenőrizheti rejtett állapotukat. Ez a tulajdonság csak olvasható. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, és a C2 a rejtett oszlophoz; a példában `False`, `True`, és `True` értékek jelennek meg.

Ehhez a példához frissítse a diagram adatokat a ábrázolási beállítás módosítása után: tartsa meg a beágyazott munkafüzetet a [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) használatával, és töltse be újra a [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) segítségével. Az összes cella belefoglalása esetén használja a [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) metódust a teljes tartomány visszaállításához, beleértve a rejtett februári kategóriát is. Az egyszerű zászlóváltoztatás nem elegendő a példa gyorsítótárba helyezett diagram adatainak és kategóriacímkéknek a frissítéséhez.

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

            # Frissítse a diagram adatokat a beágyazott munkafüzetből.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Állítsa vissza a teljes forrástartományt, beleértve a rejtett kategóriákat.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

A példa két változatban menti a bemutatót: az egyik csak a látható kiskereskedelmi értékeket (10 és 20) tartalmazza, a másik pedig mind a hat értéket. Az alábbi képek a mentett bemutatókat újra megnyitva renderelték; mindkét fájl megőrzi a hozzárendelt ábrázolási beállítást. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`True`) | Minden cella (`False`) |
| --- | --- |
| ![Csak látható cellák: kiskereskedelmi értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: kiskereskedelmi és nagykereskedelmi értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy értéket tartalmazó rejtett cella különbözik egy üres cellától. A [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) szabályozza, hogy a hiányzó értékek hogyan jelenjenek meg; nem vonja ki vagy adja hozzá a rejtett forrásadatokat. Lásd a [Üres cellák megjelenítésének szabályozása](/slides/hu/python-net/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat-tartományának lekérése**

Mielőtt frissítené a munkafüzet adatokat egy meglévő bemutatóban, ellenőrizze a forrás‑tartományokat, hogy mely munkalap‑cellákat használja az egyes diagramok. A [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) metódus a jelenlegi adat‑tartományt adja vissza egy munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` választja el a cellatartományt, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli. A dollárjelzések abszolút sor‑ és oszlopreferenciákat jelölnek.

A metódus a jelenlegi tartományt olvassa anélkül, hogy megváltoztatná a diagramot vagy annak munkafüzetét. Ha a diagram nem munkafüzetet használ adatforrásként, kivételt dob. További információk a [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) oldalon.

Ez a példa megnyit egy bemutatót, és minden dián közvetlenül ellenőrzi a diagram alakzatokat. Kiírja minden diagram nevét és forrás‑tartományát. Ha a tartomány nem lekérdezhető, diagnosztikai üzenetet ír ki, és tovább lép a következő diagramra.

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

## **Diagram adatok beolvasása és írása munkafüzetből**

Az Aspose.Slides for Python via .NET a [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) és a [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) metódusokkal teszi lehetővé a diagram adat‑munkafüzetek (amelyek Aspose.Cells‑szel szerkesztett diagram adatokat tartalmaznak) beolvasását és írását. **Megjegyzés**: a diagram adatot ugyanúgy kell szervezni, mint a forrás, vagy hasonló struktúrával kell rendelkeznie.

Ez a példa egy bemutatót használ, amelynek első diáján az első alakzat egy diagram. Beolvassa a beágyazott munkafüzetet egy adatfolyamba, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet visszaírja. A változások memóriában maradnak; a példa nem menti a bemutatót.

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

### **Diagram elrendezésének érvényesítése munkafüzet módosítása után**

Amikor egy beágyazott munkafüzetet módosított munkafüzettel helyettesít, a diagram megőrzi az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez az eltérés a [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) hibához vezethet, ha index‑túl‑határ hiba keletkezik. Törölje a meglévő sorozatokat és kategóriákat, mielőtt a módosított munkafüzetet visszaírná a diagramra. Ez a példa egy olyan diagramot használ, amely az első dián az első alakzat. A megjegyzés jelzi, hol történne a munkafüzet‑szerkesztés; a futtatható példa visszaírja az eredeti munkafüzetet, és memóriában ellenőrzi az elrendezést.

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

A gyűjtemények törlése eltávolítja a lejárt adat‑referenciákat, mielőtt a munkafüzet visszaírásra kerül. Építse újjá a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használná.

## **Egyéni számformátumok beállítása munkafüzetcellákhoz**

Használja a [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) metódust, hogy szabályozza, hogyan jelenjenek meg a numerikus értékek egy diagram beágyazott munkafüzetében. Például egy jelentésnek lehet szüksége egy konverziós ráta százalékos megjelenítésére négy tizedes jellel, illetve egy együttható öt tizedes jellel. Mindkét értéket tartsuk numerikus formában, hogy továbbra is elérhetők legyenek a számítások és a diagram ábrázolás számára.

Egy számformátum csak a megjelenítést változtatja, nem az eltárolt értéket. A `0.0000%` formátum a `0.125` értéket `12.5000%`‑ként mutatja; nem helyettesíti a tárolt számot `12.5`‑tel. Hasonlóképpen a `0.00000` a `0.1234567`‑et `0.12346`‑ként jeleníti meg anélkül, hogy a tárolt értéket kerekítené. Ha az egyéni formátum egy üres karakterlánc (`""`), akkor a [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) lesz használva.

Az alábbi példa egy oszlopdiagramot hoz létre, és a cellákat a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) segítségével éri el. A 0‑s munkalapon a B2 tartalmazza a konverziós rátát, a C2 pedig az együtthatót. Mindkét cella diagramértékeket szolgáltat. A példa engedélyezi a forrás‑formátumhoz kapcsolt értékcímkéket is.

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

A munkafüzetcellák formátumai különállóak a diagram tengelyeken vagy adatcímkéken közvetlenül beállított formátumoktól. Ebben a példában minden címke a forráscellájuk értékét mutatja, mert a [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) engedélyezve van, és a forrás számformátumát követi, mivel a [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) `True`. A mentés és újra megnyitás után a címkék `12.5000%`‑ot és `0.12346`‑t jelenítenek meg, ahogy alább látható. A függőleges tengely saját [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) `0.00`‑t használ, a [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) pedig `False`.

Ha egy adatcímkét önállóan szeretne formázni, állítsa a forrás‑hivatkozási jelzőt `False`‑ra, és adja meg a [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) értékét. Ez nem módosítja a munkafüzetcellához tartozó formátumot. Például egy önálló címkeformátum `0.00` a első értéket `0.13`‑ként jeleníti meg, míg a B2 továbbra is `12.5000%`‑ot mutat. Lásd a [Diagram adatcímkék](/slides/hu/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) példát a címkék közvetlen formázásához.

![Oszlopdiagram forrásra hivatkozó címkékkel, amelyek 12.5000% és 0.12346 értékeket mutatnak, valamint önállóan formázott numerikus tengely.](custom-cell-formats.png)

## **Munkafüzetcella beállítása diagram adatcímkeként**

A munkafüzetcellák szövegét használhatja diagram adatcímkeként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal a meglévő bemutató első diájához. A 0‑s munkalap A10:A12 celláit használja az első sorozat első három címkéjének, engedélyezi a cellákból származó címkéket, és elmenti a frissített bemutatót.

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

A [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) tulajdonság biztosítja a hozzáférést a diagram munkafüzetében lévő munkalapokhoz. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és kiírja minden munkalap nevét a konzolra.

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

A sorpont értékek közvetlenül numerikus literálokként is tárolhatók. Lásd a [Sorértékek beállítása numerikus literálok használatával](/slides/hu/python-net/chart-series/#set-series-values-using-numeric-literals) példát a teljes körű mentés és beolvasás érdekében. A pontértékek forrás típusa elkülönül a diagram belső vagy külső munkafüzet‑konfigurációjától; numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet.

Ez a példa egy 3D-oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozatnevet állít be különböző adatforrásokkal. Az első nevet egy karakterlánc‑literál adja; a másodikat a 0‑s munkalap C1 cellája adja. A [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) felsorolás választja ki minden név forrását. A példa elmenti a bemutatót a frissített sorozatnevekkel.

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

## **Nem támogatott beágyazott munkafüzet formátumok észlelése**

Az Aspose.Slides nem támogatja a néhány diagramhoz beágyazott Excel bináris munkafüzet (.xlsb) formátumot. A [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) tulajdonságot a [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) osztályon együtt a [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) felsorolással használva észlelhető a nem támogatott formátum, és ilyen diagramokat kihagyható. Ez a példa megvizsgálja az első dián lévő alakzatokat egy meglévő bemutatóban, kihagyja a nem‑diagram alakzatokat, és diagnosztikai üzenetet ír ki minden .xlsb‑t beágyazott munkafüzetű diagramhoz.

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

        # Olvassa vagy módosítsa itt a támogatott diagram munkafüzet adatokat.
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagram adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) és a [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódusokat egy beágyazott diagram munkafüzet exportálásához fájlba, és a diagram külső munkafüzettel való összekapcsolásához.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és exportálja a munkafüzetét. Az output adatfolyamot a külső munkafüzet diagramadat‑forrásként történő hozzárendelése előtt zárja le, majd elmenti a kapcsolt bemutatót.

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

A [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódus segítségével külső munkafüzetet rendelhet diagramhoz adatforrásként. Ezzel a metódussal a külső munkafüzet útvonalát is frissítheti (ha az áthelyezésre került).

Bár távoli helyeken vagy erőforrásokban tárolt munkafüzeteket nem szerkeszthet közvetlenül, továbbra is használhatja őket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útvonallá alakul.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` munkalapja B1‑ben egy sorozatnevet, A2:A4‑ben kategórianeveket, és B2:B4‑ben numerikus értékeket tartalmaz. A példa kördiagramot hoz létre, összekapcsolja a munkafüzetet, és a [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) segítségével A1:B4‑et egy sorozatra és három kategóriára map‑olja. A kapcsolt diagrammal menti a bemutatót.

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

* Ha az `update_chart_data` `False`, csak a munkafüzet útvonala frissül. A diagram adatai nem töltődnek be vagy frissülnek a célmunkafüzetről, így a munkafüzet lehet, hogy nem is érhető el.
* Ha az `update_chart_data` `True`, a diagram adatai a célmunkafüzetről frissülnek.

Az alábbi példa egy helyőrző URL‑t ad meg, miközben az `update_chart_data` `False`‑ra van állítva. Megtartja a kördiagram alapértelmezett adatait, és elmenti a bemutatót anélkül, hogy a nem elérhető munkafüzetet betöltené.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **A diagram külső adatforrás munkafüzet útvonalának lekérése**

A diagramhoz kapcsolt munkafüzet azonosításához ellenőrizze, hogy a diagram külső adatforrást használ‑e, és kérdezze le annak munkafüzet‑útvonalát.

Ez a példa megvizsgálja egy bemutató első diájának első alakzatát, amely külső munkafüzettel van összekapcsolva. Ha ez egy diagram, amely külső munkafüzettel van kapcsolva, a példa kiírja a [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) értékét a konzolra, majd egy másolatot ment a bemutatóról.

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

### **Diagram adatok szerkesztése**

A külső munkafüzettel ugyanúgy szerkesztheti az adatokat, ahogy a belső munkafüzet tartalmát is módosítaná. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első dián az első alakzat, és egy elérhető külső munkafüzettel van összekapcsolva. Az első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, majd menti a frissített bemutatót. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzet megőrzése szükséges.

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

Ha egy diagram külső, hiányzó vagy nem elérhető munkafüzetet használ, az Aspose.Slides helyreállíthatja a diagram munkafüzetét a bemutatóban gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) objektumot, állítsa be a [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/) részét, és a [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/) értékét `True`‑ra állítsa a bemutató megnyitása előtt.

Az alábbi Python példa helyreállítja a munkafüzet adatokat egy diagramhoz, amely az első dián az első alakzat, és egy nem elérhető külső munkafüzethez hivatkozik. A helyreállított adatokat a [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) és a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) segítségével érheti el:

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

        # Olvassa vagy módosítsa itt a helyreállított munkafüzet adatait.
    else:
        print("The first shape is not a chart.")
```

Ha a külső munkafüzet nem elérhető, és a helyreállítás ki van kapcsolva, az Aspose.Slides kivételt dob. Csak akkor engedélyezze a helyreállítást, ha a gyorsítótárazott diagramadatok használata elfogadható tartalék, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben végzett módosításokat a bemutató legutóbbi frissítése óta.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van‑e csatolva?**

Igen. A diagramnek van egy [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) és egy [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/); ha a forrás egy külső munkafüzet, akkor a teljes útvonalat beolvashatja, hogy megbizonyosodjon, egy külső fájl kerül‑e felhasználásra.

**Támogatottak‑e a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút útvonallá. A bemutató az abszolút útvonalat tárolja a PPTX fájlban, ezért a munkafüzet áthelyezése esetén frissíteni kell a hivatkozást.

**Használhatok‑e munkafüzeteket hálózati erőforrásokon/megosztott mappákon?**

Igen, az ilyen munkafüzetek felhasználhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja‑e a külső XLSX‑et a bemutató mentésekor?**

A bemutató egy [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) tárol. A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt is. Ha a munkafüzet eredeti állapotát változatlanul kell hagyni, használjon egy másolatot.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a csatoláskor. Általános megoldás, hogy előre eltávolítja a védelmet, vagy egy dekódolt másolatot készít (például az [Aspose.Cells](https://reference.aspose.com/cells/python-net/) segítségével), és arra hivatkozik.

**Több diagram hivatkozhat‑e ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozást tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.