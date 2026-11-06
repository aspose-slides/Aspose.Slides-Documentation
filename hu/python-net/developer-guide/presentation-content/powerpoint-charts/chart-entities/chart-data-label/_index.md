---
title: Diagram adatcímkék kezelése előadásokban Python használatával
linktitle: Adatcímke
type: docs
url: /hu/python-net/chart-data-label/
keywords:
- diagram
- adatcímke
- adat pontosság
- százalék
- címke távolság
- címke elhelyezkedés
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Tanulja meg, hogyan adjon hozzá és formázzon diagram adatcímkéket PowerPoint előadásokban az Aspose.Slides for Python via .NET segítségével, hogy vonzóbb diákat hozzon létre."
---
## **Bevezetés**

Az adatcímkék információkat jelenítenek meg a diagram sorozatairól és az egyes adatpontokról, segítve az olvasókat az értékek azonosításában és a diagram megértésében. Ez a cikk bemutatja, hogyan formázzuk az értékeket, jelenítsünk meg százalékokat, olvassuk el a címke szöveget, szabályozzuk a címkéket a tengely maximumán túl, állítsuk be a kategória tengely címkék távolságát, és helyezzük el a kördiagram címkéket.

## **Látható adatcímkék számlálása**

Használja a [count_of_visible_data_labels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/count_of_visible_data_labels/) metódust, hogy ellenőrizze, hány adatcímke van engedélyezve a megjelenítéshez a prezentáció közzététele előtt. A `len(labels)`-től eltérően, amely a gyűjteményben lévő címkék teljes számát adja vissza, ez figyelembe veszi a sorozat alapértelmezéseit és az egyes címkék beállításait.

Ez a példa egy oszlopdiagramot hoz létre egy sorozattal és három adatponttal. Eléri a sorozat [labels](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/labels/) gyűjteményét, és a beállítások változtatásakor kiírja a látható számot: **0, 3, 2, 3**. A teljes szám **3** marad.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    series_cell = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_cell, chart.type)

    for i in range(3):
        category_cell = workbook.get_cell(0, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)
        value_cell = workbook.get_cell(0, i + 1, 1, (i + 1) * 10)
        series.data_points.add_data_point_for_bar_series(value_cell)

    labels = series.labels
    print(f"Total: {len(labels)}; visible: {labels.count_of_visible_data_labels}")  # Összes: 3; látható: 0

    labels.default_data_label_format.show_value = True
    print(f"Visible: {labels.count_of_visible_data_labels}")  # Látható: 3

    labels[1].data_label_format.show_value = False
    print(f"Visible: {labels.count_of_visible_data_labels}")  # Látható: 2

    labels[1].data_label_format.show_legend_key = True
    print(f"Visible: {labels.count_of_visible_data_labels}")  # Látható: 3
```

A sorozat [default_data_label_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/default_data_label_format/) biztosítja az alapértelmezett beállításokat. A [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) engedélyezése itt minden három címkének az értékét megjeleníti. `False`‑ra állítása egy címke [data_label_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/data_label_format/) segítségével felülírja ezt a beállítást a kiválasztott címkénél. A [show_legend_key](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_legend_key/) engedélyezése újra láthatóvá teszi azt a címkét, még akkor is, ha az értéke rejtve marad.

A látható szám a láthatósági beállításokat tükrözi. Nem méri, hogy a címkék átfedik‑e egymást, levágottak‑e, vagy olvashatóak‑e a megjelenített diagramon.

## **Adatpont precizitásának beállítása a diagram adatcímkéiben**

Használja a [number_format_of_values](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseries/number_format_of_values/) metódust a sorozat értékeinek formázásához. Ez a példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, megjeleníti az adat táblázatát, és engedélyezi az értékcímkéket az első sorozatnál. A `#,##0.00` formátum ezres elválasztót és két tizedesjegyet jelenít meg anélkül, hogy megváltoztatná a mögöttes értékeket.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.LINE, 50, 50, 450, 300)
    chart.has_data_table = True

    series = chart.chart_data.series[0]
    series.number_format_of_values = "#,##0.00"
    series.labels.default_data_label_format.show_value = True

    presentation.save("PrecisionOfDatalabels_out.pptx", slides.export.SaveFormat.PPTX)
```

A diagram beágyazott munkafüzetének numerikus celláinak formázásához tekintse meg a [Set Custom Number Formats for Workbook Cells](/slides/hu/python-net/chart-workbook/#set-custom-number-formats-for-workbook-cells) cikket. Az a példa szintén megmutatja, hogy az értékcímkék a forráscellák formátumát követik, miközben az eltárolt számértékek változatlanok maradnak.

## **Százalék megjelenítése címkékként**

Egy halmozott oszlopdiagram esetén számolja ki minden értéket a kategória összegének százalékaként, és rendelje a szöveget a [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) elemhez. Ez a példa az alapértelmezett diagram adatokat használja, és százalékokat jelenít meg két tizedesjeggyel, 8 pontos betűmérettel. A nullával egyenlő összegű kategóriákat kihagyja, hogy elkerülje a nullával való osztást. Számolja újra a saját címke szöveget, ha a diagram adatai megváltoznak.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN, 20, 20, 400, 400)

    category_totals = [0.0] * len(chart.chart_data.categories)
    for k in range(len(chart.chart_data.categories)):
        for series in chart.chart_data.series:
            point_value = float(series.data_points[k].value.data)
            category_totals[k] += point_value

    for series in chart.chart_data.series:
        series.labels.default_data_label_format.show_legend_key = False

        for j in range(len(series.data_points)):
            label = series.data_points[j].label
            if category_totals[j] == 0:
                continue

            point_value = float(series.data_points[j].value.data)
            data_point_percent = point_value / category_totals[j] * 100

            portion = slides.Portion()
            portion.text = f"{data_point_percent:.2f} %"
            portion.portion_format.font_height = 8

            label.text_frame_for_overriding.text = ""

            paragraph = label.text_frame_for_overriding.paragraphs[0]
            paragraph.portions.add(portion)

            label.data_label_format.show_value = True
            label.data_label_format.show_series_name = False
            label.data_label_format.show_percentage = False
            label.data_label_format.show_legend_key = False
            label.data_label_format.show_category_name = False
            label.data_label_format.show_bubble_size = False

    presentation.save("DisplayPercentageAsLabels_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Százalékjel beállítása diagram adatcímkékkel**

Ha az értékek tört formában vannak tárolva, használja a [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/number_format/) beállítást a százalék megjelenítéséhez. Állítsa a [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/is_number_format_linked_to_source/) értékét `False`‑ra, hogy a címke formátuma független legyen a forráscelláktól.

Ez a példa egy 100 %‑os halmozott oszlopdiagramot hoz létre piros és kék sorozatokkal négy kategóriában. Minden értéppár összege 1. A `0.0%` címkeformátum a 0.30‑at 30.0 %-ként jeleníti meg, míg a függőleges tengely két tizedesjegyet használ. Mindkét sorozat fehér, 10 pontos címkeszöveget használ.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PERCENTS_STACKED_COLUMN, 20, 20, 500, 400)

    chart.axes.vertical_axis.is_number_format_linked_to_source = False
    chart.axes.vertical_axis.number_format = "0.00%"

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    worksheet_index = 0
    for i in range(4):
        category_cell = workbook.get_cell(worksheet_index, i + 1, 0, f"Category {i + 1}")
        chart.chart_data.categories.add(category_cell)

    series_names = ["Reds", "Blues"]
    series_colors = [drawing.Color.red, drawing.Color.blue]
    values = [[0.30, 0.50, 0.80, 0.65], [0.70, 0.50, 0.20, 0.35]]

    for i in range(len(series_names)):
        series_cell = workbook.get_cell(worksheet_index, 0, i + 1, series_names[i])
        series = chart.chart_data.series.add(series_cell, chart.type)
        for j in range(4):
            value_cell = workbook.get_cell(worksheet_index, j + 1, i + 1, values[i][j])
            series.data_points.add_data_point_for_bar_series(value_cell)

        series.format.fill.fill_type = slides.FillType.SOLID
        series.format.fill.solid_fill_color.color = series_colors[i]

        label_format = series.labels.default_data_label_format
        label_format.show_value = True
        label_format.is_number_format_linked_to_source = False
        label_format.number_format = "0.0%"
        label_format.text_format.portion_format.font_height = 10
        label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
        label_format.text_format.portion_format.fill_format.solid_fill_color.color = drawing.Color.white

    presentation.save("SetDataLabelsPercentageSign_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Az adatcímkék tényleges szövegének lekérdezése**

Használja a [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) metódust a címke beállításai által létrehozott szöveg visszakereséséhez. Ez akkor hasznos, ha címkéket kell kinyerni jelentésekhez, keresni a prezentáció tartalmában, vagy validálni a generált diagramokat. Az alábbi példában az alapértelmezett [data label format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/) minden kategória‑nevet, sorozat‑nevet és értéket kombinál. Egy pont értékét százalékos formátumban jeleníti meg, míg egy másik a [text_frame_for_overriding](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/text_frame_for_overriding/) egyedi szövegét használja.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    for i, category_name in enumerate(["Q1", "Q2"]):
        category_cell = workbook.get_cell(0, i + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    north_cell = workbook.get_cell(0, 0, 1, "North")
    north = chart.chart_data.series.add(north_cell, chart.type)
    for i, value in enumerate([0.25, 0.75]):
        value_cell = workbook.get_cell(0, i + 1, 1, value)
        north.data_points.add_data_point_for_bar_series(value_cell)

    south_cell = workbook.get_cell(0, 0, 2, "South")
    south = chart.chart_data.series.add(south_cell, chart.type)
    for i, value in enumerate([0.40, 0.60]):
        value_cell = workbook.get_cell(0, i + 1, 2, value)
        south.data_points.add_data_point_for_bar_series(value_cell)

    for series in chart.chart_data.series:
        label_format = series.labels.default_data_label_format
        label_format.show_category_name = True
        label_format.show_series_name = True
        label_format.show_value = True

    north.labels[1].data_label_format.is_number_format_linked_to_source = False
    north.labels[1].data_label_format.number_format = "0%"
    south.labels[0].text_frame_for_overriding.text = "Reviewed"

    for series in chart.chart_data.series:
        for point in series.data_points:
            label = point.label
            if not label.is_visible:
                continue

            label_text = label.get_actual_label_text()
            print(f"Value: {point.value.data}; label: {label_text}")
```

A pontban tárolt szám `0.75` marad, még akkor is, ha a címke `75%`‑ként jelenik meg a kategória‑ és sorozatnevekkel együtt. Az egyedi szöveg felülírja a generált címkeszöveget. A [get_actual_label_text](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/get_actual_label_text/) mindkét esetben a végső címkestringet adja vissza. Ellenőrizze külön a [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/is_visible/) értékét, ahogyan fent is látható, ha csak a látható címkéket szeretné kinyerni.

## **Címkék szabályozása a tengely maximumán túl**

Ha manuálisan korlátozza egy tengely tartományát, egyes adatpontok meghaladhatják a maximumot. Használja a [show_data_labels_over_maximum](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/show_data_labels_over_maximum/) beállítást annak meghatározására, hogy a címkék megjelenjenek‑e. Ez a beállítás csak a címke láthatóságát módosítja; nem változtatja meg a tengely tartományát vagy a mögöttes adatértékeket.

Az alábbi példa egy 2D‑es csoportosított oszlopdiagramot hoz létre 60 és 120 értékekkel. A függőleges tengelyen a [is_automatic_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_max_value/) értékét `False`‑ra, a [max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/max_value/) értékét pedig 100‑ra állítja. Az első dián a címkék a maximumon túl is megjelennek; egy másolatban ez ki van kapcsolva. Mindkét dia a `DataLabelsOverMaximum.pptx` fájlba van mentve.

Engedélyezze az értékcímkéket a [show_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_value/) segítségével. A diagram‑szintű beállítás önmagában nem jeleníti meg az értékeket, és nem írja felül egy adott címke letiltott megjelenítését. Ez a példa az egész sorozatra engedélyezi az értékeket, és a [position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/position/) használatával a címkéket az oszlopok külső végére helyezi.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = False

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook

    first_category = workbook.get_cell(0, 1, 0, "Within range")
    second_category = workbook.get_cell(0, 2, 0, "Above maximum")

    chart.chart_data.categories.add(first_category)
    chart.chart_data.categories.add(second_category)

    series_name = workbook.get_cell(0, 0, 1, "Values")
    series = chart.chart_data.series.add(series_name, chart.type)

    first_value = workbook.get_cell(0, 1, 1, 60)
    second_value = workbook.get_cell(0, 2, 1, 120)

    series.data_points.add_data_point_for_bar_series(first_value)
    series.data_points.add_data_point_for_bar_series(second_value)

    series.labels.default_data_label_format.show_value = True
    series.labels.default_data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END

    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 100
    chart.show_data_labels_over_maximum = True

    second_slide = presentation.slides.add_clone(slide)
    second_chart = second_slide.shapes[0]
    second_chart.show_data_labels_over_maximum = False

    presentation.save("DataLabelsOverMaximum.pptx", slides.export.SaveFormat.PPTX)
```

Az alábbi képek a Microsoft PowerPoint‑ben renderelt mentett diák. `True` esetén a **120** címke a felső határon látható; `False` esetén rejtett. A **60** címke továbbra is látható, a tengely maximuma **100** marad, és a második adatpont **120** mindkét esetben.

| show_data_labels_over_maximum = True | show_data_labels_over_maximum = False |
| --- | --- |
| ![PowerPoint diagram, amely a 120 értékcímkét mutatja 100 tengelymaximum mellett](data-labels-over-maximum-true.png) | ![PowerPoint diagram, amely elrejti a 120 értékcímkét 100 tengelymaximum mellett](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Ez a példa egy 2D‑es oszlopdiagramot használ értéktengellyel. Az olyan diagramok, amelyek nem rendelkeznek értéktengellyel (például kör‑ és fánkok diagramok), nem rendelkeznek ilyen módon korlátozható tengely‑maximumszal.
{{% /alert %}}

## **Címke távolságának beállítása egy tengelytől**

Használja a [label_offset](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/label_offset/) beállítást a kategória tengely címkék és a tengely közti távolság vezérléséhez. Az érték a tengelycímkék legnagyobb betűméretének százaléka. Ez a példa egy csoportosított oszlopdiagramot hoz létre, és a vízszintes tengely címkeeltolását 500‑ra állítja. Ez a beállítás a kategória tengely címkéire vonatkozik, nem pedig az egyes adatpontokhoz csatolt címkékre.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 300)
    chart.axes.horizontal_axis.label_offset = 500

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Címke elhelyezésének módosítása**

Kördiagram esetén állítsa be az adatcímkék pozícióját a távolság javítása és a vezető vonalak számára hely biztosítása érdekében.

Ez a példa az első adatpont értékét jeleníti meg, címkéjét a szelet kívülre helyezi, és módosítja a [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) és [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) eltolásokat. Ezek az eltolások a diagram szélességére és magasságára vonatkozó törtként értendők.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 50, 50, 200, 200)
    series = chart.chart_data.series

    label = series[0].labels[0]
    label.data_label_format.show_value = True
    label.data_label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label.x = 0.71
    label.y = 0.04

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

![Kördiagram, amelynek adatcímkéjét módosították](pie-chart-adjusted-label.png)

## **Vezető vonalak formázása**

Amikor a kördiagram címkéi a szeletek kívül helyezkednek el, a vezető vonalak segítik az olvasót, hogy az egyes értékeket a megfelelő szelethez kapcsolja. Egy kontrasztos szín és egy kissé vastagabb vonal könnyebbé teheti a kapcsolatok követését, míg a átlátszóság és a szaggatott stílus kevésbé zavaróvá teszi a vonalakat.

Használja a [leader_lines_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelcollection/leader_lines_format/) metódust a sorozat adatcímke‑gyűjtemény szintjén a vezető vonalak formázásához. A `series.labels.leader_lines_format.line` beállítások a gyűjteményre vonatkoznak, nem egyedi címkékre.

Ez a példa egy alapértelmezett adatokkal rendelkező kördiagramot hoz létre, a változó értékeket a szeletek kívül jeleníti meg, és engedélyezi a [show_leader_lines](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabelformat/show_leader_lines/) opciót. Két címkét a [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) és [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) eltolásokkal mozgat távolabb a szeletektől, a diagram szélességének és magasságának törtjeként kifejezve. Nincs bemeneti prezentáció szükséges.

A vonal [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) egy szilárd kék színt állít be 191‑es alfa értékkel a 255‑ből, ami körülbelül 25 % átlátszóságot eredményez. A [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) 2 pont vastagságot, a [dash_style](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/dash_style/) pedig szaggatott vonalat ad.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.PIE, 80, 50, 560, 400)
    chart.has_legend = False

    series = chart.chart_data.series[0]

    label_format = series.labels.default_data_label_format
    label_format.show_value = True
    label_format.position = charts.LegendDataLabelPosition.OUTSIDE_END
    label_format.show_leader_lines = True

    # Mozgassa el a két címkét a szeleteiktől távolabb.
    series.labels[0].x = 0.10
    series.labels[0].y = -0.05
    series.labels[1].x = -0.10
    series.labels[1].y = 0.05

    line = series.labels.leader_lines_format.line
    line.fill_format.fill_type = slides.FillType.SOLID
    line.fill_format.solid_fill_color.color = drawing.Color.from_argb(191, 30, 90, 160)
    line.width = 2
    line.dash_style = slides.LineDashStyle.DASH

    presentation.save("FormattedLeaderLines.pptx", slides.export.SaveFormat.PPTX)
```

A vezető vonalak engedélyezése nem garantálja, hogy minden címkéhez megjelenik vonal. A láthatóság a címke elhelyezésétől és a diagram elrendezési viselkedésétől függ. Ebben a példában a két eltolódott címke látható vezető vonallal rendelkezik; a szeletekhez közel maradt címkéknek nincs rájuk szükségük.

Az alábbi kép a `FormattedLeaderLines.pptx` fájl mentett változatát mutatja, az Aspose.Slides‑del renderelve:

![Kördiagram, amely kék, félig átlátszó, szaggatott vezető vonalakkal kapcsolja a két külső címkét a szeletekhez](formatted-leader-lines.png)

## **Több sor adatcímke hozzáadása egy oszlopdiagram fölé**

Ez a példa egy oszlopdiagramot hoz létre, amely két sor adatcímkét helyez a diagramrajz terület felett. Az A sorozat a látható oszlopokat jeleníti meg, míg a B és C sorozatok a további címkéket biztosítják. Oszlopjaikat a kitöltés és a körvonal eltávolításával rejtik el. A [overlap](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartseriesgroup/overlap/) tulajdonság az összes három sorozatot ugyanazon kategória‑középpontokhoz igazítja.

A [plot_area](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/plot_area/) beállítás helyet biztosít a címkesoroknak. A [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) alapértelmezett pozíciókat számolja ki, a [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/x/) és [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/datalabel/y/) eltolások pedig megőrzik a vízszintes igazítást, és függőleges eltolást alkalmaznak a címkék két sorban való elrendezéséhez. A számok továbbra is a sorozatértékekhez kapcsolt adatcímkék; csak a sorfejlécek külön szöveges alakzatok.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 40, 40, 640, 200)
    chart.has_title = False
    chart.has_legend = False
    chart.text_format.portion_format.font_height = 12

    chart.chart_data.series.clear()
    chart.chart_data.categories.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(0)

    categories = ["North", "South", "East", "West"]
    series_names = ["Series A", "Series B", "Series C"]
    series_values = [
        [35, 42, 28, 47],
        [22, 31, 19, 26],
        [12, 16, 14, 18]
    ]

    for category_index, category_name in enumerate(categories):
        category_cell = workbook.get_cell(0, category_index + 1, 0, category_name)
        chart.chart_data.categories.add(category_cell)

    for series_index, series_name in enumerate(series_names):
        series_cell = workbook.get_cell(0, 0, series_index + 1, series_name)
        series = chart.chart_data.series.add(series_cell, charts.ChartType.CLUSTERED_COLUMN)

        for category_index in range(len(categories)):
            value_cell = workbook.get_cell(0, category_index + 1, series_index + 1, series_values[series_index][category_index])
            series.data_points.add_data_point_for_bar_series(value_cell)

        if series_index > 0:
            # Rejtse el a B és C oszlopokat, de tartsa meg az adatcímkéiket.
            series.format.fill.fill_type = slides.FillType.NO_FILL
            series.format.line.fill_format.fill_type = slides.FillType.NO_FILL
            label_format = series.labels.default_data_label_format
            label_format.show_value = True
            label_format.text_format.portion_format.font_height = 12
            label_fill = label_format.text_format.portion_format.fill_format
            label_fill.fill_type = slides.FillType.SOLID
            label_fill.solid_fill_color.color = drawing.Color.black
            label_format.position = charts.LegendDataLabelPosition.INSIDE_BASE

    # Igazítsa a három sorozatot ugyanarra a kategóriaközépre.
    chart.chart_data.series[0].parent_series_group.overlap = 100

    # Használjon kevesebb rácsvonalat ebben a kompakt példában.
    chart.axes.vertical_axis.is_automatic_major_unit = False
    chart.axes.vertical_axis.major_unit = 10

    # Tartson helyet a diagram felett két sor adatcímkének.
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER
    chart.plot_area.x = 0.15
    chart.plot_area.y = 0.32
    chart.plot_area.width = 0.80
    chart.plot_area.height = 0.48
    chart.validate_chart_layout()

    for series_index in range(1, len(series_names)):
        series = chart.chart_data.series[series_index]
        row_top = 0.15 if series_index == 1 else 0.03

        for category_index in range(len(categories)):
            data_label = series.data_points[category_index].label
            # Tartsa meg az alapértelmezett vízszintes pozíciót. Az Y egy eltolás a
            # alapértelmezett címkepozíciótól, a diagrammagasság törtjeként kifejezve.
            data_label.x = 0
            data_label.y = row_top - data_label.actual_y / chart.height

        # Csak a sorfejléc egy külön szöveges alakzat.
        row_heading = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, chart.x, chart.y + row_top * chart.height, 85, 18)
        row_heading.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.line_format.fill_format.fill_type = slides.FillType.NO_FILL
        row_heading.add_text_frame(series_names[series_index])
        row_heading.text_frame.text_frame_format.margin_top = 0
        row_heading.text_frame.text_frame_format.margin_bottom = 0
        heading_format = row_heading.text_frame.paragraphs[0].portions[0].portion_format
        heading_format.font_height = 12
        heading_format.fill_format.fill_type = slides.FillType.SOLID
        heading_format.fill_format.solid_fill_color.color = drawing.Color.black

    presentation.save("multiple-rows-of-labels.pptx", slides.export.SaveFormat.PPTX)
```

![Oszlopdiagram, amely két sor adatcímkét helyez a diagramrajz terület felett](multiple-rows-of-labels.png)

## **GYIK**

**Hogyan lehet megakadályozni, hogy az adatcímkék átfedjék egymást sűrű diagramok esetén?**

Használjon automatikus címke‑elhelyezést, vezető vonalakat és kisebb betűméretet; ha szükséges, rejtsen el néhány mezőt (például a kategóriát), vagy csak a szélső vagy kulcsfontosságú pontokhoz jelenítsen meg címkéket.

**Hogyan lehet letiltani a címkéket csak a nulla, negatív vagy üres értékeknél?**

Szűrje ki az adatpontokat a címkék engedélyezése előtt, és kapcsolja ki a megjelenítést a 0‑ás, negatív vagy hiányzó értékekre egy meghatározott szabály szerint.

**Hogyan biztosítható a konzisztens címkestílus PDF‑/képfájlok exportálásakor?**

Állítson be kifejezetten betűtípust és méretet, és ellenőrizze, hogy a betűtípus elérhető‑e a renderelési környezetben, hogy elkerülje a helyettesítést.