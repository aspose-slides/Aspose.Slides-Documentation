---
title: Diagram munkafüzeteinek kezelése prezentációkban Python használatával
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
description: "Fedezze fel az Aspose.Slides for Python via .NET-et: könnyedén kezelje a diagram munkafüzeteit PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációi adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhat a diagrammunkafüzetekkel az Aspose.Slides-ben. Bemutatja, hogyan olvashat és írhat diagram adatokat munkafüzet adatfolyamokon keresztül, hogyan használhat munkafüzet cellákat diagram adatok címkéiként, hogyan érheti el a munkalap-gyűjteményeket, és hogyan adhatja meg az adatforrás típusát a diagram értékekhez.

Az is bemutatja, hogyan használhat külső munkafüzeteket diagram adatforrásként. A példák demonstrálják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan kérheti le egy diagramhoz csatolt külső munkafüzet útvonalát, és hogyan szerkesztheti a diagram adatokat, ha a munkafüzet elérhető.

A hiányzó adatot tartalmazó munkafüzet cellákhoz lásd a [Control the Display of Empty Cells](/slides/hu/python-net/chart-series/) cikket, amely a különbséget mutatja be az üres cella és a nulla között, valamint egy vonaldiagramot a rendelkezésre álló megjelenítési módok összehasonlításával.

## **Rejtett sorok és oszlopok adatainak felvétele**

Használja a [Chart.plot_visible_cells_only](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_visible_cells_only/) metódust annak szabályozására, hogy a diagram a rejtett munkalap sorokból és oszlopokból származó adatokat ábrázolja-e. Állítsa `True`‑ra, ha csak a látható cellákat kívánja ábrázolni, vagy `False`‑ra, ha a látható és a rejtett cellákat egyaránt fel kívánja venni. Ez a beállítás csak a diagram ábrázolását szabályozza; nem rejti el vagy mutatja fel a munkalap sorokat vagy oszlopokat.

A [sample presentation](hidden-source-data.pptx) első diáján egy oszlopdiagramként jelenik meg az első alakzat. A beágyazott munkalap, `Sheet1`, a következő forrás tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik továbbra is tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | Január | 10 | 30 |
| 3 (rejtett sor) | Február | 40 | 60 |
| 4 | Március | 20 | 50 |

A forrás cellák eléréséhez használja a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) tulajdonságot, és olvassa a [ChartDataCell.is_hidden](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/is_hidden/) értékét a rejtettség állapotának ellenőrzéséhez. Ez a tulajdonság csak olvasható. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példakód ennek megfelelően `False`, `True`, `True` értékeket ír ki.

Ehhez a példához frissítse a diagram adatokat a megjelenítési beállítás módosítása után: tartsa meg a beágyazott munkafüzetet a [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) segítségével, és töltse be újra a [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) használatával. Az összes cella felvételekor használja a [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) metódust a teljes tartomány, köztük a rejtett februári kategória visszaállításához. A zászló egyszerű megváltoztatása nem elegendő a pufferezett diagram adatok és kategóriacímkék frissítéséhez.

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

            # Frissítse a diagram adatait a beágyazott munkafüzetből.
            workbook_stream.seek(0)
            chart.chart_data.write_workbook_stream(workbook_stream)
            if not visible_only:
                # Állítsa vissza a teljes forrás tartományt, beleértve a rejtett kategóriákat.
                chart.chart_data.set_range("Sheet1!$A$1:$C$4")

            presentation.save(f"hidden_cells_{visible_only}.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The first shape is not a chart.")
```

A példa két verziót ment a prezentációból: egyet, amely csak a látható Kiskereskedelem értékeket (10 és 20) tartalmazza, és egyet, amely az összes hat értéket tartalmazza. Az alábbi képek a mentett prezentációk újranyitása után lettek renderelve; mindkét fájl megőrzi a hozzárendelt megjelenítési beállítást. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| csak látható cellák (`True`) | összes cella (`False`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Egy rejtett, értékkel rendelkező cella különbözik egy üres cellától. A [Chart.display_blanks_as](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/display_blanks_as/) szabályozza, hogy a hiányzó értékek hogyan jelenjenek meg; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd a [Control the Display of Empty Cells](/slides/hu/python-net/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat tartományának lekérdezése**

Mielőtt frissítené a munkafüzet adatokat egy meglévő prezentációban, ellenőrizze a forrás tartományokat, hogy meghatározza, mely munkalap cellákat használja az egyes diagramok. A [ChartData.get_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/get_range/) metódus visszaadja a jelenlegi adat tartományt munkalap‑minősített képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` választja el a cellatartománytól, és a `$A$1:$D$5` az A1‑től D5‑ig terjedő cellákat jelöli. A dollár jelek abszolút sor‑ és oszlophivatkozásokat jelölnek.

A metódus a jelenlegi tartományt olvassa anélkül, hogy módosítaná a diagramot vagy a munkafüzetét. Ha a diagram nem használ munkafüzetet adatforrásként, kivételt dob. További információkért lásd a [ChartData API Reference](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/) oldalt.

Ez a példa megnyit egy prezentációt, és minden dián közvetlenül ellenőrzi az alakzatokat diagramok után. Kiírja minden diagram nevét és forrás tartományát. Ha a tartomány nem nyerhető ki, diagnosztikai üzenetet ír ki, majd a következő diagramra lép.

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

Az Aspose.Slides for Python via .NET biztosítja a [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) és a [write_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/write_workbook_stream/) metódusokat, amelyek lehetővé teszik a diagram adat munkafüzetek (az Aspose.Cells‑szel szerkesztett diagram adatokat tartalmazó) olvasását és írását. **Note** hogy a diagram adatnak ugyanúgy kell felépítve lennie, vagy hasonló szerkezettel kell rendelkeznie, mint a forrás.

Ez a példa egy prezentációt használ, amelynek első alakzata egy diagram az első dián. Beolvassa a beágyazott munkafüzetet egy adatfolyamba, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet írja vissza. A módosítások memóriában maradnak; a példa nem menti a prezentációt.

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

Ha egy beágyazott munkafüzetet egy módosított változattal helyettesít, a diagram megtartja az eredeti sorozat- és kategória‑gyűjteményeit. Ez az eltérés okozhatja, hogy a [Chart.validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) hibával “index-out-of-range” hibát dob. Törölje a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírná a diagramba. Ez a példa egy diagramot használ, amely az első dián az első alakzat. A megjegyzés azt jelzi, ahol a munkafüzet szerkesztése történne; a futtatható példa visszaírja az eredeti munkafüzetet, és ellenőrzi a layoutot memóriában.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart.pptx") as presentation:
    slide = presentation.slides[0]

    if len(slide.shapes) > 0 and isinstance(slide.shapes[0], charts.Chart):
        chart = slide.shapes[0]
        chart_data = chart.chart_data
        workbook_stream = chart_data.read_workbook_stream()

        # Módosítsa a munkafüzet adatfolyamát itt, például az Aspose.Cells használatával.

        chart_data.series.clear()
        chart_data.categories.clear()

        workbook_stream.seek(0)
        chart_data.write_workbook_stream(workbook_stream)
        chart.validate_chart_layout()
    else:
        print("The first shape is not a chart.")
```

A gyűjtemények törlése eltávolítja a régi adat hivatkozásokat, mielőtt a munkafüzet visszaírásra kerül. Építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használja.

## **A kategória címkék tárolásának módjának kiválasztása**

Állítsa be a [ChartCategoryCollection.use_cells](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategorycollection/use_cells/) értékét, amíg a kategória‑gyűjtemény üres. Állítsa `True`‑ra olyan címkékhez, amelyek munkalap cellákra hivatkoznak, vagy hierarchiát alkotnak, például egy évhez csoportosított negyedek. Állítsa `False`‑ra egyetlen szintű, sztringként megadott címkékhez. Ez a beállítás csak a kategóriákra vonatkozik. Mindkét diagram a példában munkalap cellákat használ a numerikus sorozatértékekhez.

A példa két oszlopdiagramot hoz létre, és kiírja a tárolási módot és a `Q1 Q2 Q3 Q4` címkéket mindegyikhez. A cella‑alapú címkékhez a [ChartCategory.as_cell](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/as_cell/) visszaadja a munkalap cellát, a [ChartDataCell.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/value/) pedig a benne tárolt címkét. Szöveges címkék esetén közvetlenül a [ChartCategory.value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartcategory/value/)‑ból olvassa a sztringet.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    shapes = presentation.slides[0].shapes
    
    for use_cells, x in [(True, 20), (False, 360)]:
        chart = shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, x, 20, 320, 250)
        data = chart.chart_data
        data.series.clear()
        data.categories.clear()
        data.categories.use_cells = use_cells

        workbook = data.chart_data_workbook
        series_name = workbook.get_cell(0, 0, 1, "Sales")
        series = data.series.add(series_name, chart.type)
        for row in range(1, 5):
            label = f"Q{row}"
            if use_cells:
                label_cell = workbook.get_cell(0, row, 0, label)
                data.categories.add(label_cell)
            else:
                data.categories.add(label)

            value_cell = workbook.get_cell(0, row, 1, row * 10)
            series.data_points.add_data_point_for_bar_series(value_cell)

        labels = [category.as_cell.value if use_cells else category.value for category in data.categories]
        print(f"use_cells = {data.categories.use_cells}:", *labels)

    presentation.save("category-labels.pptx", slides.export.SaveFormat.PPTX)
```

## **Egyéni számformátumok beállítása munkafüzet cellákhoz**

Használja a [ChartDataCell.custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) metódust annak szabályozására, hogy a numerikus értékek hogyan jelenjenek meg a diagram beágyazott munkafüzetében. Például egy jelentésnek szüksége lehet egy átváltási rátára, amelyet négy tizedesjegyű százalékban, illetve egy együtthatóra, amelyet öt tizedesjegyben jelenít meg. Tartsa mindkét értéket numerikusként, hogy számításokhoz és diagram ábrázoláshoz is elérhetők legyenek.

A számformátum a megjelenítést változtatja, a tárolt értéket nem. A `0.0000%` formátum a `0.125`‑et `12.5000%`‑ként jeleníti meg; a tárolt szám nem változik `12.5`‑re. Hasonlóan, a `0.00000` a `0.1234567`‑et `0.12346`‑ként jeleníti, a tárolt érték nem kerekítve. Ha az egyéni formátum egy üres karakterlánc (`""`), akkor a [preset_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/preset_number_format/) kerül felhasználásra.

Az alábbi példa egy oszlopdiagramot hoz létre, és a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) segítségével hozzáfér a cellákhoz. A 0‑s munkalapon a B2 tartalmazza az átváltási rátát, a C2 pedig az együtthatót. Mindkét cella diagramértékeket szolgáltat. A példa engedélyezi továbbá a forrás formátumokhoz kötött értékcímkéket.

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

A munkafüzet cellaformátumok különállóak a diagram tengelyeken vagy adatcímkéken közvetlenül beállított formátumoktól. Ebben a példában minden címke a forráscellájának értékét jeleníti meg, mert a [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) engedélyezve van, és a forrás számformátumot követi, mivel az [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) `True`. A prezentáció mentése és újranyitása után a címkék `12.5000%` és `0.12346` értékeket mutatják, ahogy alább látható. A függőleges tengely saját `0.00` [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/)‑et használ, az [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) `False` értékkel.

A data címke önálló formázásához állítsa a forrás‑link zászlót `False`‑ra, és adja meg a [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/)‑et. Ez nem változtatja meg a munkafüzet cellaformátumát. Például egy önálló címke `0.00` formátuma az első értéket `0.13`‑ként jeleníti meg, míg a B2 továbbra is `12.5000%`‑t mutat. Lásd a [Chart Data Labels](/slides/hu/python-net/chart-data-label/#set-percentage-sign-with-chart-data-labels) cikket a közvetlen címkeformázáshoz.

Az alábbi kép a mentett prezentáció újranyitása után került renderelésre:

![Oszlopdiagram forrás‑hivatkozott címkékkel, amelyek 12.5000% és 0.12346 értékeket jelenítenek, valamint önállóan formázott numerikus tengellyel.](custom-cell-formats.png)

## **Munkafüzet cella beállítása diagram adat címkének**

Használhatja a munkafüzet cellák szövegét diagram adatcímkének.

Ez a példa buborékdiagramot ad hozzá alapértelmezett adatokkal egy létező prezentáció első diájához. A 0‑s munkalap A10:A12 celláit használja az első sorozat első három címkéjéhez, engedélyezi a cellákból származó címkéket, és elmenti a frissített prezentációt.

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

A [ChartDataWorkbook.worksheets](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdataworkbook/worksheets/) tulajdonság hozzáférést biztosít a diagram munkafüzetének munkalapjaihoz. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és kiírja minden munkalap nevét a konzolra.

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

## **Adatforrás típusának meghatározása**

A sorozatpont értékek tárolhatók közvetlenül numerikus literálokként is. Lásd a [Set Series Values Using Numeric Literals](/slides/hu/python-net/chart-series/#set-series-values-using-numeric-literals) cikket egy teljes példáért, amely menti és olvassa őket. A pontértékek forrás típusa különálló a diagram belső vagy külső munkafüzet‑konfigurációjától; a numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet.

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat nevet állít be különböző adatforrásokkal. Az első név egy sztring literált használ; a második a 0‑s munkalap C1 celláját. A [DataSourceType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datasourcetype/) felsorolás választja ki a forrást minden névhez. A példa elmenti a prezentációt a frissített sorozat nevekkel.

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

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely néhány diagramhoz beágyazható. Használhatja a [embedded_workbook_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/embedded_workbook_type/) tulajdonságot a [ChartData](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/)‑on együtt a [WorkbookType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/workbooktype/) felsorolással a nem támogatott formátumok észleléséhez és az érintett diagramok kihagyásához. Ez a példa megvizsgálja az első dián lévő alakzatokat egy meglévő prezentációban, kihagyja a nem diagram alakzatokat, és diagnosztikai üzenetet ír ki minden .xlsb beágyazott munkafüzettel rendelkező diagramhoz.

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

Az Aspose.Slides támogatja a külső munkafüzetek diagram adatforrásként történő használatát.

### **Külső munkafüzet létrehozása**

Használja a [read_workbook_stream](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/read_workbook_stream/) és a [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódusokat a beágyazott diagram munkafüzet fájlba exportálásához, majd a diagramhoz való csatolásához.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és exportálja a munkafüzetét. Bezárja a kimeneti adatfolyamot, mielőtt a külső munkafüzetet diagram adatforrásként hozzárendeli, majd elmenti a kapcsolt prezentációt.

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

A [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/) metódus használatával egy külső munkafüzetet rendelhet diagramhoz adatforrásként. Ezzel a metódussal frissíthető a külső munkafüzet útvonala is (ha az áthelyezésre került).

Miközben távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatainak szerkesztése nem lehetséges, ezek továbbra is használhatók külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes úttá alakul.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` nevű munkalapján B1‑ben egy sorozatnév, A2:A4‑ben kategória‑nevek, B2:B4‑ben numerikus értékek vannak. A példa kördiagramot hoz létre, összekapcsolja a munkafüzetet, és a [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/)‑et használja az A1:B4 tartomány egy sorozatra és három kategóriára való leképezéséhez. Elmenti a prezentációt a kapcsolt diagrammal.

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

A `update_chart_data` paraméter a [set_external_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_external_workbook/)‑nél szabályozza, hogy a munkafüzet be legyen‑töltve.

* Ha `update_chart_data` **False**, csak a munkafüzet útvonala frissül. A diagram adat nem töltődik be vagy frissül a cél munkafüzettel, így a munkafüzet hiányzhat.
* Ha `update_chart_data` **True**, a diagram adat frissül a cél munkafüzettel.

Az alábbi példa egy helyőrző URL‑t rendel a `update_chart_data` **False** értékével. Megőrzi a kördiagram alapértelmezett adatait, és elmenti a prezentációt a nem betöltött munkafüzet nélkül.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 400, 600, True)
    chart.chart_data.set_external_workbook("https://example.com/unavailable-workbook.xlsx", False)
    
    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", slides.export.SaveFormat.PPTX)
```

### **A diagram külső adatforrás munkafüzet útvonalának lekérdezése**

A diagramhoz csatolt munkafüzet azonosításához ellenőrizze, hogy a diagram külső adatforrást használ‑e, és kérje le a munkafüzet útvonalát.

Ez a példa az első dián az első alakzatot vizsgálja egy olyan prezentációban, amelyhez külső munkafüzet van csatolva. Ha a diagram külső munkafüzethez van csatolva, a példa kiírja az [external_workbook_path](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)‑t a konzolra, majd elment egy másolatot a prezentációból.

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

Külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogy a belső munkafüzetek tartalmát módosítja. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első dián az első alakzat, és egy elérhető külső munkafüzethez van csatolva. Beállítja az első sorozat első adatpontjának cella‑alapú értékét 100‑ra, majd elmenti a frissített prezentációt. A cella értékek szerkesztése frissítheti a csatolt külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet meg kell őrizni.

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

Ha egy diagram olyan külső munkafüzetet használ, amely hiányzik vagy nem érhető el, az Aspose.Slides rekonstruálhatja a diagram munkafüzetét a prezentációban gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) objektumot, konfigurálja a [spreadsheet_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/spreadsheet_options/)‑t, és állítsa a [SpreadsheetOptions.recover_workbook_from_chart_cache](https://reference.aspose.com/slides/python-net/aspose.slides/spreadsheetoptions/recover_workbook_from_chart_cache/)‑t **True**‑ra a prezentáció megnyitása előtt.

Az alábbi Python példa helyreállítja a munkafüzet adatokat egy olyan diagramhoz, amely az első dián az első alakzat, és egy nem elérhető külső munkafüzetet hivatkozik. A helyreállított adatokat a [Chart.chart_data](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/chart_data/) és a [ChartData.chart_data_workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/chart_data_workbook/) segítségével éri el:

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

Ha a külső munkafüzet nem érhető el, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárazott diagram adatok használata elfogadható tartalék, mivel a gyorsítótár nem biztos, hogy tartalmazza a külső munkafüzetben a prezentáció legutóbbi frissítése után történt változtatásokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van-e csatolva?**

Igen. A diagramnek van egy [data source type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) és egy [path to an external workbook](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/) attribútuma; ha a forrás egy külső munkafüzet, kiolvashatja a teljes útvonalat, hogy megbizonyosodjon, egy külső fájl kerül használatra.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, azt a rendszer automatikusan abszolút útvonallá konvertálja. A prezentáció az abszolút útvonalat tárolja a PPTX‑ben, ezért a munkafüzet áthelyezésekor a hivatkozást frissíteni kell.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztott meghajtókon?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [link to the external file](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/external_workbook_path/)‑et tárol. A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX‑fájlt is. Ha az eredeti munkafüzetnek változatlanul kell maradnia, használjon másolatot.

**Mi a teendő, ha a külső fájl jelszó‑védett?**

Az Aspose.Slides nem fogad jelszót a csatoláskor. Általános megoldás, hogy előzetesen eltávolítja a védelmet, vagy egy dekriptált másolatot (például az [Aspose.Cells](https://reference.aspose.com/cells/python-net/)) készít, majd ahhoz csatlakozik.  

**Több diagram is hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját hivatkozást tárol. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramra kihat a következő adatbetöltéskor.