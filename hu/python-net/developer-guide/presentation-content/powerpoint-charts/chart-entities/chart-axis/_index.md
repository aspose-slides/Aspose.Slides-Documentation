---
title: Diagram tengelyek testreszabása prezentációkban Python segítségével
linktitle: Diagramtengely
type: docs
url: /hu/python-net/chart-axis/
keywords:
- diagram tengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságok
- maximális érték
- minimális érték
- tengely vonala
- dátum formátum
- tengely címe
- tengely pozíció
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja az Aspose.Slides for Python via .NET-et a diagram tengelyek testreszabásához PowerPoint és OpenDocument prezentációkban jelentések és vizualizációk készítéséhez."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagram tengelyeket az Aspose.Slides for Python via .NET segítségével. Kitér a számított tengelyértékekre, a diagram sorok és oszlopok cseréjére, a tengely láthatóságára, a kategória címke és jelölő‑intervallumokra, a dátumkategóriákra és azok formázására, a cím forgatására, a tengely elhelyezésére, a megjelenítő egységekre és a logaritmikus méretezésre.

## **A függőleges tengely legnagyobb értékeinek lekérése diagramokban**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) és adjon hozzá egy területdiagramot alapértelmezett adatokkal. Hívja meg a [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) mielőtt a számított tengelyértékeket olvasná, hogy a diagram elrendezése naprakész legyen.

Olvassa a [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) és a [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) értékeket a tengelykorlátokhoz, illetve a [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) és a [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) értékeket a jelölő‑intervallumokhoz. A [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) és a [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) időegység‑skálákat adnak, amelyek a dátumtengelyeknél relevánsak. A példa ezeket az értékeket helyi változókba menti, majd elmenti a diagramot.

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

## **Az adatok cseréje a tengelyek között**

Használja a [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) metódust a sorozatok és kategóriák szerepének felcseréléséhez a diagram adataiban. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává válik. Ez az adatcsoportosítást változtatja meg; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) metódust használja, hogy az alapértelmezett adatot a `Sheet1!A1:D5` tartományra kötse, beleértve a fejlécsort és a kategóriaoszlopot, mielőtt a sorokat és oszlopokat felcserélné. Négy sorozattal és három kategóriával ment egy diagramot.

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

## **A tengely ábrázolási sorrendjének megfordítása**

Használja a [is_plot_order_reversed](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_plot_order_reversed/) tulajdonságot egy kategória vagy érték tengely megfordításához. Például egy vízszintes oszlopdiagram a projektszakaszokat felülről lefelé ugyanabban a sorrendben mutathatja, mint a munkalapon: Planning, Development, Testing. A tengely megfordítása megváltoztatja a rajzolási irányt; nem rendezi át a munkafüzet adatokat. Ezzel szemben a [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) felcseréli a sorozatok és kategóriák szerepét.

Az alábbi példa egy vízszintes oszlopdiagramot hoz létre három szakaszzal és egy sorozattal. Három diát ment el: normál sorrend, megfordított kategóriák és megfordított értékek. Minden másolat ugyanazt az adatkészletet használja, és egyetlen tengely fordul meg minden másolaton.

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

    # 2. dia: az első kategóriát felül jeleníti meg.
    category_slide = presentation.slides.add_clone(slide)
    category_chart = category_slide.shapes[0]
    category_chart.axes.vertical_axis.is_plot_order_reversed = True
    # A vízszintes értéktengelyt alul tartja.
    category_chart.axes.vertical_axis.cross_type = charts.CrossesType.MAXIMUM

    # 3. dia: csak a vízszintes numerikus skálát fordítja meg.
    value_slide = presentation.slides.add_clone(slide)
    value_chart = value_slide.shapes[0]
    value_chart.axes.horizontal_axis.is_plot_order_reversed = True

    presentation.save("ReversedAxes.pptx", slides.export.SaveFormat.PPTX)
```

A tengely megfordítása a merőleges tengelyt a diagram másik oldalára is átmozgathatja. A [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) szabályozza, hogy a másik tengely hol metszze a konfigurált tengelyt. A 2. dia esetében a `MAXIMUM` érték beállítása a megfordított kategória tengelyen megtartja a vízszintes érték tengelyt alul. Egy konkrét metszésponthoz használja a [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/). Ellenőrizze a metszési beállításokat irányváltáskor, különösen ha a diagram már egyedi metszésponttal rendelkezik. Állítsa vissza az `is_plot_order_reversed` értéket `False`‑ra a normál ábrázolási irány visszaállításához; a metszési beállítások különállóak.

| Normál sorrend (1. dia) | Megfordított kategóriák (2. dia) | Megfordított értékek (3. dia) |
| --- | --- | --- |
| ![Horizontal bar chart with normal category and value axis order](axis-order-normal.png) | ![Horizontal bar chart with categories displayed from top to bottom](axis-order-categories-reversed.png) | ![Horizontal bar chart with a reversed value axis and zero on the right](axis-order-values-reversed.png) |
| A kategóriák alulról felfelé haladnak; az értékek balról jobbra nőnek. | Planning, Development, és Testing felülről lefelé halad. Az értékek és a munkafüzet sor sorrendje változatlan. | A kategóriák megtartják normál sorrendjüket; az értékek jobbról balra nőnek. A kategória tengely a jobb oldalon, nullánál metszi. |

## **A függőleges tengely letiltása vonaldiagramoknál**

Állítsa az [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) tulajdonságot `False`‑ra a függőleges tengelyen, hogy elrejtse azt. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, és a függőleges tengely elrejtésével menti el.

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

Állítsa az [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) tulajdonságot `False`‑ra a vízszintes tengelyen, hogy elrejtse azt. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, és a vízszintes tengely elrejtésével menti el.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    presentation.save("HiddenHorizontalAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Diagram rácsvonalak megjelenítése vagy elrejtése**

Olvassa a [show_major_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_major_grid_lines/) és a [show_minor_grid_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/show_minor_grid_lines/) tulajdonságokat, hogy megtudja, mely rácsvonalakat jeleníti meg egy tengely. Mindkét tulajdonság csak olvasható. A kisebb rácsvonalak megjelenítéséhez állítsa a [minor_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_grid_lines_format/) kitöltését szilárd színre, és válasszon látható színt. Elrejtéshez állítsa a kitöltést `FillType.NO_FILL`‑ra. A fő rácsvonalakhoz használja a [major_grid_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_grid_lines_format/)`.line.fill_format`. A kitöltés módosítása megőrzi a tengely láthatóságát és jelölőit.

A csoportosított oszlopdiagram függőleges tengelye eleve látható fő rácsvonalakkal és rejtett kisebb rácsvonalakkal indul. A példa először narancssárga színnel jeleníti meg a kisebb rácsvonalakat, majd újból elrejti őket, mielőtt a prezentációt mentené.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 30, 660, 230)
    axis = chart.axes.vertical_axis
    print(f"Initial: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    minor_fill = axis.minor_grid_lines_format.line.fill_format
    minor_fill.fill_type = slides.FillType.SOLID
    minor_fill.solid_fill_color.color = slides.Color.dark_orange
    print(f"Enabled: minor={axis.show_minor_grid_lines}")

    minor_fill.fill_type = slides.FillType.NO_FILL
    print(f"Hidden: major={axis.show_major_grid_lines}, minor={axis.show_minor_grid_lines}")

    presentation.save("ChartGridlines.pptx", slides.export.SaveFormat.PPTX)
```

| Kisebb rácsvonalak engedélyezve | Kisebb rácsvonalak elrejtve |
| --- | --- |
| ![Orange minor gridlines between the major gridlines on the vertical axis](minor-gridlines-enabled.png) | ![The same column chart with only major gridlines visible](minor-gridlines-hidden.png) |

## **Kategória tengely módosítása**

Állítsa a [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) tulajdonságot, hogy dátum vagy szöveg kategória tengelyt válasszon. Ez a példa az `ExistingChart.pptx` fájlt igényli, amelynek első diáján az első alakzat egy diagram, és a kategória cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátum tengelyre állítja. Az [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) `False`, a [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) `1`, és a [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) `months` beállítása egyhónapos fő jelölőket eredményez.

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

### **A kategória tengely típusának meghatározása adatok alapján**

Hívja meg a [set_category_axis_type_automatically](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/set_category_axis_type_automatically/) metódust a kategóriák feltöltése után, majd olvassa a [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) értékét a kiválasztás ellenőrzéséhez. Hasznos, ha ugyanaz a diagram szöveges címkéket vagy numerikus dátumértékeket kap. A metódus a meghíváskor határozza meg a típust; nem kapcsol be egy állandó módot, amely későbbi adatváltozásokat újraértékelne. Hívja meg újra a kategóriák cseréje után.

A következő példa egy szöveges kategóriákkal rendelkező diagramot hoz létre, és a `TEXT` szöveget írja ki. Ezután a kategória cellaértékeket dátumokra cseréli, újra meghívja a metódust, amely a `DATE` értéket adja. A dátumok numerikus OLE Automation értékekként vannak tárolva, a 1899. december 30-i nap óta eltelt napok számaként, nem dátumkénti karakterláncokként. A [custom_number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdatacell/custom_number_format/) szabályozza, hogyan jelennek meg ezek az értékek; nem konvertálja a szöveget numerikus dátummá. További információért lásd a [Chart Workbook](/slides/hu/python-net/chart-workbook/).

Használja az automatikus meghatározást, ha a bemenet szöveges kategóriákat vagy numerikus dátumokat tartalmaz, ahogy ez a példa is mutatja. Általános numerikus címkék, vegyes kategóriák vagy üres adatok esetén állítsa be kézzel a [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) értékét a kívánt jelentésnek megfelelően. Csak numerikus értékek önmagukban nem határozzák meg, hogy a kategóriák dátumot jelentenek.

```python
from datetime import date

import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 30, 40, 660, 320)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    series_name = workbook.get_cell(0, 0, 1, "Sales")
    series = chart.chart_data.series.add(series_name, chart.type)
    labels = ["First", "Second", "Third"]

    for i, label in enumerate(labels):
        category_cell = workbook.get_cell(0, i + 1, 0, label)
        chart.chart_data.categories.add(category_cell)

        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    axis = chart.axes.horizontal_axis
    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # SZÖVEG

    dates = [date(2026, 1, 1), date(2026, 1, 2), date(2026, 2, 1)]

    for i, category_date in enumerate(dates):
        category_cell = workbook.get_cell(0, i + 1, 0)
        category_cell.value = float((category_date - date(1899, 12, 30)).days)
        category_cell.custom_number_format = "yyyy-mm-dd"

    axis.set_category_axis_type_automatically()
    print(axis.category_axis_type.name)  # DÁTUM

    presentation.save("AutomaticCategoryAxis.pptx", slides.export.SaveFormat.PPTX)
```

## **Kategória tengely címkeintervallumok szabályozása**

Amikor egy diagram sok kategóriát tartalmaz, csökkentheti a látható tengelycímkék számát anélkül, hogy a kategóriákat vagy adatpontokat eltávolítaná. Állítsa az [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) tulajdonságot `False`‑ra, majd adja meg a [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) értékét a kívánt kategória intervallumnak. Szöveges kategóriák esetén, normál sorrendben, a számolás az első kategóriától indul:

| Intervallum | Példában megjelenített címkék |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

A `3` intervallum minden harmadik címkét jelenít meg, a megjelenő címkék között két címke rejtve marad. Ez nem távolítja el a megfelelő oszlopokat. Az automatikus távolság a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

A jelölő‑pontoknak külön vezérlése van. Állítsa az [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) tulajdonságot `False`‑ra, és használja a [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) értékét az intervallum beállításához. Például az `1` minden kategória‑intervallumban elhelyez egy jelölő‑pontot, miközben a címkék csak minden harmadik kategóriánál jelennek meg. Állítsa a [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) látható stílusra, hogy látható legyen az eredmény. Bármely automatikus‑távolság‑tulajdonság visszaállítása `True`‑ra hagyja, hogy a diagram újra kiválassza az intervallumot.

Az alábbi önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment el a `CategoryAxisIntervals.pptx` fájlba: automatikus távolság, kézi címke‑távolság független jelölőpontokkal, és a visszaállított automatikus távolság. A két másolat az eredeti diagram adatokat tartja. Input prezentációra nincs szükség. A vízszintes címke‑szöveg megkönnyíti a sűrűség vizuális összehasonlítását.

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

    # 2. dia: minden harmadik címkét jelenítse meg, de minden kategóriához legyen egy jelölőpont.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # 3. dia: engedje, hogy a diagram újra kiválassza mindkét intervallumot.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Automatikus távolság (1. dia):** Ebben a megjelenítésben minden második kategória címke látható, és két sorba törik. Az automatikus eredmény a diagram méretétől, betűtípusától és a renderelőtől függően változhat.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Kézi távolság (2. dia):** Minden harmadik címke jelenik meg egy sorban, míg a jelölő‑pontok minden kategória‑intervallumban megmaradnak. Az összes 24 oszlop, beleértve azokat is, amelyekhez nincs címke, látható, azonos értékekkel. A 3. dia visszaállítja a fenti automatikus megjelenést.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Használja ezt a kategória‑szám intervallumot szöveges kategória tengely esetén, például oszlop, vonal, terület vagy oszlopdiagram esetén. Oszlopdiagram esetén ez a vízszintes tengely. Vízi­szintes oszlopdiagram esetén a kategória tengely függőleges, ezért ezeket a beállításokat a [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/) tulajdonságra alkalmazza. A jelölő‑pont távolság a sorozat‑tengelyre is vonatkozik, ha a diagram rendelkezik ilyen‑vel.

Ne használja a kategória címke‑intervallumot a numerikus skála beállítására érték­tengelyen. Érték­tengelyen a [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) egy értékkülönbséget határoz meg: például a `10` fő egység 0, 10, 20… értékeket hoz létre, ha a tengely nulláról indul. A `3` kategória címke‑intervallum csak a kategória‑pozíciókat számolja, függetlenül az adatértékektől. Szórt‑ és buborékdiagramok érték­tengelyeket használnak, nem szöveges kategória tengelyt. Dátum‑tengelyhez használjon időalapú fő egységeket és skálákat, ahogy a [Kategória tengely módosítása](#kategória-tengely-módosítása) szekcióban le van írva.

## **A kategória tengely értékek dátumformátumának beállítása**

A példa az alapértelmezett diagram adatokat négy éves értékkel helyettesíti. A dátumok OLE Automation sorozatszámként vannak tárolva az első munkalapon (index `0`). Állítsa a [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) értékét dátum‑tengelyre, tiltsa le a [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/) kapcsolatot, és adja a [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/) értéknek a `yyyy`‑et, hogy a kategória címkék négy számjegyű éveket jelenítsenek meg a cella formázásától függetlenül.

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

Engedélyezze a [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) tulajdonságot a függőleges tengelyen, adja meg a címszöveget, és állítsa a [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) értékét a cím elforgatásához. A szöget fokban mérik; ez a példa egy oszlopdiagramot ment el, amelynek érték‑tengely címkéje 90 fokban van elforgatva.

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

## **A tengely pozíciójának beállítása kategória vagy érték tengelyen**

Használja a [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) tulajdonságot, hogy szabályozza, az érték‑tengely a kategória‑tengelyet kategóriák között vagy a kategória‑jelölő‑pontoknál metszze. Ez a tulajdonság a kategória‑tengelyekre vonatkozik. A példa a vízszintes kategória‑tengelyen `True`‑ra állítja egy oszlopdiagramon, és elmenti az eredményt.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Megjelenítő egység beállítása diagram érték‑tengelyen**

Állítsa a [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) tulajdonságot, hogy a címkéket az érték‑tengelyen átskálázzák anélkül, hogy az alapadat változna. A [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) `MILLIONS` értékével a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyére a milliók megjelenítő egységét alkalmazza.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Logaritmikus érték‑tengely beállítása**

A logaritmikus érték‑tengely hasznos, ha a pozitív értékek több nagyságrendben is eltérnek. Például egy szolgáltatás 10, 100, 1 000, 10 000 és 100 000 kérést kaphat öt időszakban. Lineáris skálán a kisebb értékek közel a nullához helyezkednek. A logaritmikus skála a relatív növekedést könnyebben összevethetővé teszi: az egyenlő távolságok egyenlő arányokat jelentenek, nem egyenlő különbségeket.

Állítsa az [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) tulajdonságot `True`‑ra az érték‑tengelyen, és a [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) segítségével válassza ki az alapot. Ez megváltoztatja, hogyan jelennek meg a meglévő értékek; nem módosítja az adatot, és nem ad hozzá logaritmikus trendvonalat. A trendvonal egy külön funkció, amely az adatokhoz illesztett összefüggést ábrázolja.

### **Az érték‑tengely és az alap kiválasztása**

Vonal‑ vagy oszlopdiagram esetén az érték‑tengely a [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Vízszintes oszlopdiagram esetén a [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/) a megfelelő. Szórt‑ és buborékdiagramoknak két érték‑tengelye van, így a horizontális tengely az X‑értékekhez, a vertikális a Y‑értékekhez, vagy mindkettőhöz használható. Ne alkalmazzon logaritmikus skálázást kategória‑tengelyre.

Az alapértelmezett logaritmikus alap `10`. PPTX diagramoknál az `2`‑tól `1000`‑ig terjedő értékek megengedettek; törtalapú értékek, például `2.5`, szintén támogatottak. A `10`‑es alap esetén a 10, 100, 1 000, 10 000 hatványok egyenlő távolságra helyezkednek el.

### **Lineáris és logaritmikus skála összehasonlítása**

Az alábbi önálló példa egy vonaldiagramot hoz létre az első dián az öt kérés‑számot tartalmazva, majd a második diát klónozza, és a másodikon engedélyezi a 10‑es alapú logaritmikus érték‑tengelyt. Mindkét dia ugyanazokat az adatokat tartja.

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

    # Az első diát lineárisnak hagyja, és csak a másolat érték‑tengely skáláját változtassa meg.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Lineáris skála (1. dia):** Az egyenlő függőleges távolságok egyenlő kérés‑szám‑különbségeket jelentik. A legnagyobb érték elnyomja a diagramot, így a kisebb értékek nehezen láthatók.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Logaritmikus skála (2. dia):** Az egyenlő függőleges távolságok egyenlő arányokat jelentenek. Minden időszak tízszer annyi kérést tartalmaz, mint az előző, ezért a pontok egy egyenes vonalat alkotnak a 10‑es alapon. A tengelycímkék továbbra is az eredeti kérés‑számokat mutatják.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

A logaritmikus skála csak szigorúan pozitív értékeket jeleníthet meg. Ellenőrizze az adatokat, mielőtt engedélyezi. Ha a nulla vagy negatív értékek jelentősek, tartsa meg a lineáris skálát vagy jelenítse meg őket külön. Ha az értékek kizárása megfelelő az elemzéshez, magyarázza meg az elhagyást. Ne cserélje őket hallgatólagosan kis pozitív számokra, mivel ez megváltoztatja az adatok jelentését. Bármely manuálisan beállított minimum vagy maximum a logaritmikus tengelyen is pozitív kell legyen.

## **GYIK**

**Hogyan állíthatom be, hogy egy tengely hol metszi a másikat (tengelykereszteződés)?**

Használja a [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) beállítást a metszési viselkedés kiválasztásához. Numerikus metszési érték megadásához állítsa a [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) értékét. Ezek a beállítások lehetővé teszik a tengely keresztezésének mozgatását egy megfelelő alapvonalra.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez viszonyítva?**

Állítsa a [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) tulajdonságot a [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) segítségével: `LOW`, `HIGH`, `NEXT_TO` vagy `NONE`. A jelölő‑pontok szabályozásához használja a [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) vagy a [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) beállításokat; ezek különállóak a címke‑pozicionálástól.