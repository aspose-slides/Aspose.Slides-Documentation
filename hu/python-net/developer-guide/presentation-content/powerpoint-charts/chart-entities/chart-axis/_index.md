---
title: Diagramtengelyek testreszabása bemutatókban Python segítségével
linktitle: Diagramtengely
type: docs
url: /hu/python-net/chart-axis/
keywords:
- diagramtengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságok
- maximális érték
- minimális érték
- tengelyvonal
- dátumformátum
- tengelycím
- tengelypozíció
- PowerPoint
- OpenDocument
- bemutató
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan használhatja az Aspose.Slides for Python via .NET-et a diagramtengelyek testreszabásához PowerPoint és OpenDocument bemutatókban jelentések és vizualizációk készítéséhez."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testre szabni a diagram tengelyeket az Aspose.Slides for Python via .NET segítségével. Tárgyalja a kiszámított tengelyértékeket, a diagram sorok és oszlopok cseréjét, a tengely láthatóságát, a kategória címke- és jelölő távolságokat, a dátumkategóriákat és formázást, a cím forgatását, a tengely elhelyezését, a megjelenítési egységeket és a logaritmikus skálázást.

## **A függőleges tengely legnagyobb értékeinek lekérése diagramokon**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) és adjon hozzá egy területdiagramot az alapértelmezett adatokkal. Hívja meg a [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) metódust a kiszámított tengelyértékek olvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa ki a [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) és a [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) a tengelykorlátokhoz, valamint a [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) és a [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) a jelölő távolságokhoz. A [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) és a [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) időegység skálákat adnak, amelyek a dátumtengelyek esetén relevánsak. A példában ezek az értékek helyi változókba kerülnek, majd a diagram mentésre kerül.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
    chart.validate_chart_layout()

    max_value = chart.axes.vertical_axis.actual_max_value
    min_value = chart.axes.vertical_axis.actual_min_value

    major_unit = chart.axes.vertical_axis.actual_major_unit
    minor_unit = chart.axes.vertical_axis.actual_minor_unit

    major_unit_scale = chart.axes.vertical_axis.actual_major_unit_scale
    minor_unit_scale = chart.axes.vertical_axis.actual_minor_unit_scale

    presentation.save("AxisValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Adatok cseréje tengelyek között**

Használja a [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) metódust a sorok és oszlopok cseréjéhez a diagram adatában, ezzel megcserélve a sorozatok és a kategóriák szerepét. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává válik. Ez a csoportosítás módját változtatja; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) metódust használja az alapértelmezett adatok a `Sheet1!A1:D5` tartományra kötéséhez, beleértve a fejlécsort és a kategóriaoszlopot, mielőtt sorokat és oszlopokat cserélne. Egy négy sorozatból és három kategóriából álló diagramot ment.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    chart.chart_data.set_range("Sheet1!A1:D5")
    chart.chart_data.switch_row_column()

    presentation.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **A tengely rajzolási sorrendjének megfordítása**

Használja a [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) metódust egy kategória- vagy értéktengely megfordításához. Például egy vízszintes oszlopdiagram a projekt szakaszait felülről lefelé ugyanabban a sorrendben mutathatja, mint a munkalap: Tervezés, Fejlesztés, Tesztelés. Egy tengely megfordítása megváltoztatja a rajzolás irányát; nem rendezi vagy átrendezi a munkafüzet adatait. Összehasonlításként a [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) metódus megcseréli a sorozatok és a kategóriák szerepét.

A következő példa egy vízszintes oszlopdiagramot hoz létre három szakaszzal és egy sorozattal. Három diát ment: normál sorrend, megfordított kategóriák és megfordított értékek. Minden másolat ugyanazt az adatkészletet használja, és minden másolaton csak egy tengely van megfordítva.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_BAR, 50, 40, 620, 320)
    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_BAR)
    stages = ["Planning", "Development", "Testing"]
    values = [10, 30, 20]
    for i, stage in enumerate(stages):
        category_cell = workbook.get_cell(0, i + 1, 0, stage)
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, values[i])
        series.data_points.add_data_point_for_bar_series(value_cell)

    # Dia 2: az első kategóriát felülre jeleníti meg.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # A vízszintes értéktengelyt alul hagyja.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # Dia 3: csak a vízszintes numerikus skálát fordítja meg.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

A tengely megfordítása a merőleges tengelyt is áthelyezheti a diagram másik oldalára. A [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) határozza meg, hol keresztezi a másik tengely a konfigurált tengelyt. A 2. dián a `MAXIMUM` érték beállítása a megfordított kategóriatengelyen a vízszintes értéktengelyt alul tartja. Egy adott metszésponthoz használja a [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Ellenőrizze a metszési beállításokat az irányváltáskor, különösen ha a diagram már rendelkezik egy egyéni metszésponttal. Állítsa vissza az `is_plot_order_reversed` értéket `False`-ra a normál rajzolási irány visszaállításához; a metszési beállítások külön kezelendők.

| Normál sorrend (dia 1) | Megfordított kategóriák (dia 2) | Megfordított értékek (dia 3) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| A kategóriák alulról felfelé futnak; az értékek balról jobbra nőnek. | Tervezés, Fejlesztés és Tesztelés felülről lefelé fut. Az értékek és a munkafüzet sorok sorrendje változatlan. | A kategóriák megtartják a normál sorrendjüket; az értékek jobbról balra nőnek. A kategóriatengely a jobb oldalon, nullánál metsződik. |

## **A függőleges tengely letiltása vonaldiagramoknál**

Állítsa a [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) értékét `False`-ra a függőleges tengelyen a elrejtéshez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, amelyben a függőleges tengely rejtve van.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False

    presentation.save("HiddenVerticalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **A vízszintes tengely letiltása vonaldiagramoknál**

Állítsa a [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) értékét `False`-ra a vízszintes tengelyen a elrejtéshez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, amelyben a vízszintes tengely rejtve van.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Kategóriatengely módosítása**

Állítsa a [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) értékét egy dátum- vagy szöveges kategóriatengely kiválasztásához. Ez a példa az `ExistingChart.pptx` fájlt igényli, amelynek első diáján első alakzatként szerepel egy diagram, és a kategória cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátumtengelyre állítja. A [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) `False`, a [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) `1`, és a [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) a hónapokra állítva, a fő jelölőket egy hónapos intervallumra helyezi.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("ExistingChart.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS

    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Kategóriatengely címke intervallumok vezérlése**

Amikor egy diagram sok kategóriát tartalmaz, csökkentse a látható tengelycímkék számát a kategóriák vagy adatpontok eltávolítása nélkül. Állítsa a [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) `False` értékre, majd a [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) értékét a kívánt kategória intervallumra. Szöveges kategóriák esetén a normál sorrendben a számozás az első kategóriától indul:

| Intervallum | A példában megjelenített címkék |
| --- | --- |
| `1` | Kategória 1, Kategória 2, Kategória 3, ... Kategória 24 |
| `2` | Kategória 1, Kategória 3, Kategória 5, ... Kategória 23 |
| `3` | Kategória 1, Kategória 4, Kategória 7, ... Kategória 22 |

A `3` intervallum minden harmadik címkét jelenít meg, a megjelenített címkék között két címke rejtve marad. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

A jelölő vonalaknak külön vezérlése van. Állítsa a [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) `False` értékre, és használja a [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) a távolság beállításához. Például az `1` minden kategória intervallumban megtart egy jelölőt, míg a címkék csak minden harmadik kategórián jelennek meg. Állítsa a [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) egy látható stílusra, hogy láthassa a végeredményt. Bármely automatikus-távolság tulajdonság `True`-ra állítása lehetővé teszi, hogy a diagram újra a megfelelő intervallumot válassza.

A következő önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment a `CategoryAxisIntervals.pptx` fájlba: automatikus távolság, kézi címke távolság független jelölőkkel, és visszaállított automatikus távolság. A két másolat az eredeti diagram adatot tartja meg. Bemutató bemeneti fájlra nincs szükség. A vízszintes címkeszöveg könnyen láthatóvá teszi a sűrűség különbségét.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.CLUSTERED_COLUMN)
    for i in range(24):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, 10 + i % 6 * 5)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.category_axis_type = charts.CategoryAxisType.TEXT
    axis.text_format.text_block_format.rotation_angle = 0
    axis.text_format.portion_format.font_height = 12
    axis.major_tick_mark = charts.TickMarkType.OUTSIDE
    axis.is_automatic_tick_label_spacing = True
    axis.is_automatic_tick_marks_spacing = True

    # Dia 2: minden harmadik címkét mutassa, de minden kategóriához tartson meg egy jelölőt.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Dia 3: engedje a diagramnak, hogy újra mindkét intervallumot válassza.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Automatikus távolság (dia 1):** Ebben a megjelenítésben minden második kategória címke látható és két sorba törik. Az automatikus eredmény a diagram méretétől, betűtípusától és a renderelőtől függően változhat.

![Automatikus kategória címke távolság, 24 oszlop látható](category-axis-automatic.png)

**Kézi távolság (dia 2):** Minden harmadik címke egy sorban jelenik meg, míg a jelölő vonalak minden kategória intervallumban maradnak. Az összes 24 oszlop, beleértve a címke nélküli oszlopokat is, látható ugyanazzal az értékkel. A 3. dia visszaállítja a fenti automatikus megjelenést.

![Kézi kategória címke intervallum hárommal, 24 oszlop látható](category-axis-manual.png)

### **A megfelelő tengely és intervallum választása**

Ezt a kategória-szám intervallumot szöveges kategóriatengelyhez használja, például egy oszlop-, vonal-, terület- vagy sávdiagram kategóriatengelyéhez. Oszlopdiagram esetén ez a vízszintes tengely. Horizontális sávdiagram esetén a kategóriatengely függőleges, így ezeket a beállításokat a [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) -ra alkalmazza. A jelölő távolság a sorozattengelyre is vonatkozik azokban a diagramokban, ahol van ilyen.

Ne használja a kategória címke távolságot az értéktengely numerikus skálájának beállításához. Értéktengelyen a [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) egy értékkülönbséget határoz meg: például a `10` fő egység 0, 10, 20 stb. jelölőket eredményez, ha a tengely nulláról indul. A `3` kategória címke intervallum a kategória helyeket számolja, függetlenül azok adatértékétől. Szórás- és buborékdiagramok értéktengelyt használnak a szöveges kategóriatengely helyett. Dátumtengely esetén használjon időalapú fő egységeket és skálákat, ahogy a [Change a Category Axis](#change-a-category-axis) szakaszban leírták.

## **Dátumformátum beállítása a kategóriatengely értékeihez**

A példa az alapértelmezett diagramadatokat négy éves értékkel helyettesíti. A dátumok OLE Automation sorozatszámokként tárolódnak az első munkalapon (index `0`). Állítsa a [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) dátumtengelyre, kapcsolja ki a [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/), és adja meg a `yyyy` értéket a [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) számára, hogy a kategória címkék a négyjegyű éveket a cellaformázástól függetlenül jelenítsék meg.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    for i in range(4):
        category_date = date(2015 + i, 1, 1)
        serial_date = (category_date - date(1899, 12, 30)).days
        category_cell = workbook.get_cell(0, i + 1, 0, serial_date)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, i + 1)
        series.data_points.add_data_point_for_line_series(value_cell)

    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"

    presentation.save("DateAxisFormat.pptx", slides.export.SaveFormat.PPTX)
```

## **Forgatási szög beállítása a diagram tengely címéhez**

A [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) engedélyezése a függőleges tengelyen, a cím szövegének megadása, majd a [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) beállítása a cím forgatásához. A szög fokban mérhető; ez a példa egy oszlopdiagramot ment, amelynek az értéktengely címe 90 fokkal van elfordítva.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.add_text_frame_for_overriding("Value")
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    presentation.save("RotatedAxisTitle.pptx", slides.export.SaveFormat.PPTX)
```

## **A tengely pozíciójának beállítása kategória- vagy értéktengelyen**

Használja a [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) tulajdonságot annak szabályozásához, hogy az értéktengely a kategóriatengelyt kategóriák között vagy a kategória jelölőknél keresztezi-e. Ez a tulajdonság a kategóriatengelyekre vonatkozik. A példa a `True` értéket állítja be egy oszlopdiagram vízszintes kategóriatengelyén, és elmenti az eredményt.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Megjelenítési egység beállítása a diagram értéktengelyén**

Állítsa a [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) értékét a értéktengely címkéinek skálázásához az alapadatok módosítása nélkül. A [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) `MILLIONS` értékre állításakor a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a milliók megjelenítési egységet alkalmazza a függőleges tengelyre.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Logaritmikus értéktengely beállítása**

Egy logaritmikus értéktengely hasznos, ha a pozitív értékek több nagyságrendet fednek le. Például egy szolgáltatás 10, 100, 1 000, 10 000 és 100 000 kérést kaphat öt időszakban. Lineáris skálán a kisebb értékek közel a nullához helyezkednek el. A logaritmikus skála a relatív növekedést könnyebbé teszi összehasonlítani: az egyenlő távolságok egyenlő arányokat jelentenek a különbségek helyett.

Állítsa a [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) értékét `True`-ra az értéktengelyen, és a [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) segítségével válassza ki az alapot. Ez módosítja a meglévő értékek megjelenítését; nem változtatja meg az adatot, és nem ad hozzá logaritmikus trendvonalat. A trendvonal az adatokhoz illesztett kapcsolatot jelenti, és külön funkció.

### **Az értéktengely és az alap kiválasztása**

Vonal- vagy oszlopdiagram esetén az értéktengely a [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Horizontális sávdiagram esetén a [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Szórás- és buborékdiagramok két értéktengellyel rendelkeznek, ezért X‑értékekhez a horizontális, Y‑értékekhez a függőleges tengelyt, vagy akár mindkettőt válassza. Ne alkalmazzon logaritmikus skálázást kategóriatengelyre.

Az alapértelmezett logaritmikus alap a `10`. PPTX diagramok esetén a `2` és `1000` közötti (beleértve) bázist használhat; a tört alapok, például a `2.5`, szintén támogatottak. A `10` alap esetén a sorrendben következő hatványok (10, 100, 1 000, 10 000) egyenlő távolságra vannak.

### **Lineáris és logaritmikus skálázás összehasonlítása**

A következő önálló példa egy vonaldiagramot hoz létre az öt kérési számmal az első dián, majd lemásolja azt, és a második dián bekapcsolja a 10‑es alapú logaritmikus értéktengelyt. Mindkét dia ugyanazt az adatot tartja meg.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 30, 40, 660, 200)

    chart.has_legend = False

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    values = [10, 100, 1000, 10000, 100000]

    for i, value in enumerate(values):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Period {i + 1}")
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, value)
        series.data_points.add_data_point_for_line_series(value_cell)

    # Tartsa az első diát lineárisnak, és csak a másolat értéktengely skáláját változtassa meg.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Lineáris skála (dia 1):** Az egyenlő függőleges távolságok egyenlő különbségeket jelentenek a kérési számokban. A legnagyobb érték uralja a diagramot, így a kisebb értékek nehezen megkülönböztethetők.

![Vonaldiagram PowerPointban, amely öt kérési számot mutat lineáris értéktengelyen](value-axis-linear.png)

**Logaritmikus skála (dia 2):** Az egyenlő függőleges távolságok egyenlő arányokat jelentenek. Minden időszak tízszer több kérést tartalmaz, mint az előző, ezért a pontok egy egyenes, emelkedő vonalat alkotnak a 10‑es alapú skálán. A tengelycímkék továbbra is az eredeti kérési számokat mutatják.

![Ugyanaz az öt kérési szám PowerPointban, 10‑es alapú logaritmikus értéktengelyen](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

A logaritmikus skála csak szigorúan pozitív értékeket jeleníthet meg. Ellenőrizze az adatokat a bekapcsolás előtt. Ha a nulla vagy a negatív értékek jelentősek, használjon lineáris skálát vagy jelenítse meg őket külön. Ha az értékek kizárása megfelelő az elemzéshez, magyarázza meg a hiányt. Ne cserélje le őket hallgatólagosan kis pozitív számokra, mivel ez megváltoztatja az adatok jelentését. Bármely kézzel beállított minimum vagy maximum a logaritmikus tengelyen szintén pozitív kell legyen.

## **FAQ**

**Hogyan állíthatom be azt az értéket, ahol egy tengely a másikat metszik (tengelykereszteződés)?**

A [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) használatával választhatja ki a metszés viselkedését. Numerikus metszési érték megadásához állítsa be a [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) értékét. Ezek a beállítások lehetővé teszik a tengelykereszteződés áthelyezését egy megfelelő alapvonalra.

**Hogyan pozícionálhatom a jelölőcímkéket a tengelyhez képest?**

Állítsa a [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) értékét a [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/)‑t használva: `LOW`, `HIGH`, `NEXT_TO` vagy `NONE`. A jelölő vonalak szabályozásához használja a [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) vagy a [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) beállítást; ezek külön állnak a címke pozicionálásától.