---
title: Kördiagramok testreszabása prezentációkban Python segítségével
linktitle: Kördiagram
type: docs
url: /hu/python-net/pie-chart/
keywords:
- kördiagram
- diagram kezelése
- diagram testreszabása
- diagram opciók
- diagram beállítások
- ábrázolási opciók
- szelet szín
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Készítsen és testreszabjon kördiagramokat Pythonban az Aspose.Slides segítségével. Konfigurálja a másodlagos ábrákat, jelenítse meg az adatcímkéket, és alkalmazzon automatikus szelet színeket a PowerPointban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk kördiagramokkal az Aspose.Slides-ban. Megmutatja, hogyan lehet beállítani a másodlagos ábra opciókat a Pie of Pie és Bar of Pie diagramokhoz, valamint hogyan lehet engedélyezni az automatikus szelet színezést egy szabványos kördiagramnál.

A példák a diagram testreszabására irányuló feladatokra összpontosítanak, például diagram hozzáadása egy diára, sorok és címkék beállításának módosítása, az alapértelmezett diagram adatok helyettesítése egyéni kategóriákkal és értékekkel, valamint a frissített bemutató mentése.

## **Másodlagos ábra opciók a Pie of Pie és Bar of Pie diagramokhoz**

Aspose.Slides for Python via .NET támogatja a másodlagos ábra opciókat a Pie of Pie és Bar of Pie diagramokhoz. Ezek az opciók vezérlik a másodlagos ábra méretét és azt, hogy az adatpontok hogyan oszlanak el a két ábra között.

A következő példa egy Pie of Pie diagramot hoz létre egy új prezentációban, és megjeleníti az adatpontok értékeit címkeként. A [second_pie_size](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/second_pie_size/) tulajdonság a másodlagos ábra méretét a fő ábra 149%-ára állítja. A [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) százalékos felosztást választja, és a [pie_split_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_position/) a küszöböt 53%-ra állítja.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
    series = chart.chart_data.series[0]

    # Értékek megjelenítése és a másodlagos ábra konfigurálása.
    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.second_pie_size = 149
    series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    series_group.pie_split_position = 53

    presentation.save("pie_of_pie.pptx", slides.export.SaveFormat.PPTX)
```

### **Válasszon kategóriákat a másodlagos ábrához**

Egyéni felosztást használjon, amikor bizonyos kategóriákat szeretne csoportosítani a másodlagos ábrában a százalékos értékek függetlenül. Például egy értékesítési jelentésben az Online és az Events kategóriákat együtt jelenítheti meg, hogy az olvasók összehasonlíthassák ezt a két csatornát, még ha azok az összes eladás 35%-át és 10%-át teszik ki.

Állítsa a [pie_split_by](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_by/) értékét [PieSplitType.CUSTOM](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplittype/) -ra, és válassza ki a pontokat a [pie_split_custom_points](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/pie_split_custom_points/) segítségével. A gyűjtemény [add](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/add/) metódusa elfogadja vagy a sorozat nulla alapú indexét, vagy egy adatpont objektumot. Ebben a példában az 1-es index az Online-ot választja, a 3-as index az Events-et. A Partners kategóriát is ideiglenesen hozzáadják, majd a [remove](https://reference.aspose.com/slides/python-net/aspose.slides.charts/piesplitcustompointcollection/) használatával kizárják.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 600, 200)

    # Cserélje le az alapértelmezett adatokat a csatornák szerinti értékesítéssel.
    workbook = chart.chart_data.chart_data_workbook
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["Retail", "Online", "Partners", "Events"]
    values = [40, 35, 15, 10]
    series_name_cell = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    series.labels.default_data_label_format.show_value = True
    series_group = series.parent_series_group
    series_group.pie_split_by = charts.PieSplitType.CUSTOM
    series_group.is_color_varied = True

    # Válassza ki az Online-t a nulla-alapú indexe alapján, és az Events-et az adatpont objektuma alapján.
    series_group.pie_split_custom_points.add(1)
    series_group.pie_split_custom_points.add(series.data_points[3])

    # Zárja ki a Partners-t a kiválasztásból anélkül, hogy törölné a forrásadatait.
    series_group.pie_split_custom_points.add(2)
    series_group.pie_split_custom_points.remove(series.data_points[2])

    presentation.save("pie_of_pie_custom.pptx", slides.export.SaveFormat.PPTX)
```

Az Online (35) és az Events (10) külön szeletekként jelennek meg a másodlagos ábrában. Az elsődleges ábrában egy közös szelettel 45 értékkel vannak ábrázolva, mellette a Retail (40) és a Partners (15). A Partners eltávolítása az egyéni kiválasztásból az elsődleges ábrában marad; nem távolítja el a kategóriát vagy annak értékét a diagram forrásadataiból.

A következő kép mutatja a mentett prezentációt a PowerPointban:

![Pie of Pie diagram Online és Events elemekkel a másodlagos ábrában, valamint a 45-ös összértékük az elsődleges ábrában](pie_of_pie_custom.png)

## **Automatikus kördiagram szelet színek beállítása**

Az Aspose.Slides for Python via .NET automatikusan különböző színeket rendelhet a kördiagram szeleteihez. A következő példa egy középre igazított címmel rendelkező kördiagramot hoz létre, és az alapértelmezett adatokat három negyedéves kategóriával és azok értékeivel helyettesíti. A [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) tulajdonság megjeleníti a 20, 50 és 30 értékeket címkeként, míg az [is_color_varied](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/is_color_varied/) egyedi színt biztosít minden szeletnek.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

    # Középre igazított diagramcím hozzáadása.
    chart.chart_title.add_text_frame_for_overriding("Sample Title")
    chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = slides.NullableBool.TRUE
    chart.chart_title.height = 20
    chart.has_title = True

    # Az alapértelmezett adatok lecserélése az első munkalap használatával.
    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()
    category_names = ["First Qtr", "2nd Qtr", "3rd Qtr"]
    values = [20, 50, 30]
    series_name_cell = workbook.get_cell(worksheet_index, 0, 1, "Series 1")
    series = chart.chart_data.series.add(series_name_cell, chart.type)

    for i, category_name in enumerate(category_names):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(worksheet_index, i + 1, 1, values[i])
        series.data_points.add_data_point_for_pie_series(value_cell)

    # Értékek megjelenítése és a szeleteknek különböző színek hozzárendelése.
    series.labels.default_data_label_format.show_value = True
    series.parent_series_group.is_color_varied = True

    presentation.save("pie.pptx", slides.export.SaveFormat.PPTX)
```

## **Gyakran Ismételt Kérdések**

**Támogatottak a Pie of Pie és Bar of Pie változatok?**

Igen, a könyvtár [támogat](https://reference.aspose.com/slides/python-net/aspose.slides.charts/charttype/) egy másodlagos ábrát a kördiagramokhoz, beleértve a Pie of Pie és Bar of Pie típusokat.

**Exportálhatom csak a diagramot képként (például PNG)?**

Igen, a [exportálja a diagramot képként](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/get_image/) (például PNG) exportálása nélkül a teljes prezentáció.