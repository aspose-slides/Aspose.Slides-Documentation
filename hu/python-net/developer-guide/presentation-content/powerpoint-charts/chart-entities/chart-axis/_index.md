---
title: Diagramtengelyek testreszabása prezentációkban Python segítségével
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
- tengelyhelyzet
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan használhatja az Aspose.Slides for Python via .NET-et a diagramtengelyek testreszabásához PowerPoint és OpenDocument prezentációkban jelentések és vizualizációk készítéséhez."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides for Python via .NET segítségével. A számított tengelyértékek, a diagram sorainak és oszlopainak átváltása, a tengelyek láthatósága, a kategória címkék és a jelölő-márkák intervallumai, a dátumkategóriák és formázásuk, a cím forgatása, a tengelyek elhelyezése, a megjelenítési egységek és a logaritmikus méretezés is szerepel.

## **A függőleges tengely maximális értékének lekérése diagramokon**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) és adjon hozzá egy alapértelmezett adatokkal ellátott területdiagramot. Hívja meg a [validate_chart_layout](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/validate_chart_layout/) függvényt a számított tengelyértékek beolvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa ki az [actual_max_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_max_value/) és [actual_min_value](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_min_value/) értékeket a tengelyhatárokhoz, valamint a [actual_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit/) és [actual_minor_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit/) értékeket a jelölőlépésekhez. Az [actual_major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_major_unit_scale/) és [actual_minor_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/actual_minor_unit_scale/) időegység skálákat adnak vissza, amelyek a dátumtengelyeknél relevánsak. A példa ezeket az értékeket helyi változókba tárolja, és elmenti a diagramot.

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

## **Adatok átváltása a tengelyek között**

Használja a [switch_row_column](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/switch_row_column/) függvényt a sorozatok és kategóriák szerepének felcseréléséhez a diagram adataiban. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává válik. Ez megváltoztatja az adatok csoportosítási módját; a vízszintes és függőleges tengelyeket nem cseréli fel. A példa a [set_range](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/set_range/) metódust használja az alapértelmezett adatok `Sheet1!A1:D5` tartományhoz kötéséhez, beleértve a fejléc sort és a kategória oszlopot, mielőtt a sorokat és oszlopokat felcserélné. Egy négy sorozatú és három kategóriás diagramot ment el.

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

## **A függőleges tengely letiltása vonaldiagramoknál**

Állítsa a [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) értékét `False`-ra a függőleges tengelyen a rejtéshez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és a függőleges tengely rejtve menti el.

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

Állítsa a [is_visible](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_visible/) értékét `False`-ra a vízszintes tengelyen a rejtéshez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és a vízszintes tengely rejtve menti el.

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

Állítsa a [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) értékét, hogy dátum vagy szöveg kategóriatengelyt válasszon. Ez a példa megköveteli a `ExistingChart.pptx` fájlt, amelyben a diagram az első dián az első alakzat, és a kategória cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátumtengellyé alakítja. Az [is_automatic_major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_major_unit/) `False`, a [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) `1`, valamint a [major_unit_scale](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit_scale/) hónap értékek beállítása egyhónapos főjelölőket eredményez.

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

## **Kategóriatengely címke intervallumainak vezérlése**

Amikor egy diagramon sok kategória van, csökkenthető a látható tengelycímkék száma a kategóriák vagy adatpontok eltávolítása nélkül. Állítsa az [is_automatic_tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_label_spacing/) értékét `False`-ra, majd a [tick_label_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_spacing/) értékét a kívánt kategória intervallumra. Szöveges kategóriák esetén a normál sorrendben a számlálás az első kategóriától indul:

| Intervallum | A példában megjelenített címkék |
| --- | --- |
| `1` | Kategória 1, Kategória 2, Kategória 3, ... Kategória 24 |
| `2` | Kategória 1, Kategória 3, Kategória 5, ... Kategória 23 |
| `3` | Kategória 1, Kategória 4, Kategória 7, ... Kategória 22 |

A `3` intervallum minden harmadik címkét jelenít meg, két címkét rejtve hagyva a megjelenő címkék között. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

A jelölő-márkák külön vezérléssel rendelkeznek. Állítsa az [is_automatic_tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_automatic_tick_marks_spacing/) értékét `False`-ra, és használja a [tick_marks_spacing](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_marks_spacing/) értékét az intervallum beállításához. Például az `1` minden kategória intervallumban egy jelölőt hagy, míg a címkék csak minden harmadik kategórián jelennek meg. Állítsa a [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) értékét látható stílusra, hogy lássa az eredményt. Bármely automatikus távolság tulajdonság `True`-ra állítása lehetővé teszi, hogy a diagram újra kiválassza az intervallumot.

A következő önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment el a `CategoryAxisIntervals.pptx` fájlba: automatikus távolság, kézi címke‑távolság független jelölő-márkákkal, és a visszaállított automatikus távolság. A két másolat az eredeti diagram adatokat megtartja. Bemeneti prezentációra nincs szükség. A vízszintes címkeszöveg könnyen láthatóvá teszi a sűrűség különbségét.

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

    # Dia 2: minden harmadik címkét jelenítsen meg, de minden kategóriához egy jelölőt tartson.
    manual_slide = presentation.slides.add_clone(slide)
    manual_chart = manual_slide.shapes[0]
    manual_axis = manual_chart.axes.horizontal_axis
    manual_axis.is_automatic_tick_label_spacing = False
    manual_axis.tick_label_spacing = 3
    manual_axis.is_automatic_tick_marks_spacing = False
    manual_axis.tick_marks_spacing = 1

    # Dia 3: engedje, hogy a diagram újra kiválassza mindkét intervallumot.
    restored_slide = presentation.slides.add_clone(manual_slide)
    restored_chart = restored_slide.shapes[0]
    restored_chart.axes.horizontal_axis.is_automatic_tick_label_spacing = True
    restored_chart.axes.horizontal_axis.is_automatic_tick_marks_spacing = True

    presentation.save("CategoryAxisIntervals.pptx", slides.export.SaveFormat.PPTX)
```

**Automatikus távolság (1. dia):**  
Ezen megjelenítésben minden második kategória címke jelenik meg, és két sorba törik. Az automatikus eredmény a diagram méretétől, betűkészlettől és a megjelenítőtől függően változhat.

![Automatikus kategória címke távolság, 24 oszlop látható](category-axis-automatic.png)

**Kézi távolság (2. dia):**  
Minden harmadik címke egy sorban jelenik meg, míg a jelölő-márkák minden kategória intervallumban megmaradnak. Az összes 24 oszlop, beleértve a címke nélküli oszlopokat is, ugyanazokkal az értékekkel látható marad. A 3. dia visszaállítja a fent látható automatikus megjelenést.

![Kézi háromas kategória címke intervallum, 24 oszlop látható](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Használja ezt a kategória‑szám intervallumot szöveges kategóriatengelyhez, például egy oszlop-, vonal-, terület- vagy sávdiagram kategóriatengelyéhez. Oszlopdiagram esetén ez a vízszintes tengely. Vízszintes sávdiagram esetén a kategóriatengely függőleges, ezért ezeket a beállításokat a [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/)‑ra kell alkalmazni. A jelölő-márka távolság a sorozat tengelyre is vonatkozik, ha a diagram rendelkezik ilyen tengellyel.

Ne használja a kategória címke távolságot a numerikus értéktengely skála beállításához. Az értéktengelyen a [major_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_unit/) a különböző értékek közti eltérést határozza meg: például a `10` főegység 0, 10, 20 stb. jelölőket hoz létre, ha a tengely a nullánál kezdődik. A `3` intervallumú kategória címke a kategória pozíciókat számolja, függetlenül az adatértékektől. Szórt és buborék diagramok értéktengelyt használnak szöveges kategóriatengely helyett. Dátumtengely esetén használjon időalapú főegységeket és skálákat, ahogy az a [Change a Category Axis](#change-a-category-axis) szakaszban le van írva.

## **A kategóriatengely értékek dátumformátumának beállítása**

A példa az alapértelmezett diagram adatokat négy éves értékkel helyettesíti. A dátumok OLE Automation sorozatszámként vannak tárolva az első munkalapon (index `0`). Állítsa a [category_axis_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/category_axis_type/) értékét dátumtengelyre, tiltsa le a [is_number_format_linked_to_source](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_number_format_linked_to_source/), és adja a `yyyy` értéket a [number_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/number_format/)‑nek, hogy a kategória címkék a négy számjegyű éveket a cella formázástól függetlenül jelenítsék meg.

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

## **Forgatási szög beállítása diagramtengely címhez**

Aktiválja a [has_title](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/has_title/) beállítást a függőleges tengelyen, adja meg a címszöveget, és állítsa be a [rotation_angle](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/rotation_angle/) értékét a cím forgatásához. A szög fokban van megadva; ez a példa egy olyan oszlopdiagramot ment, amelynek értéktengely címkéje 90 fokkal van elforgatva.

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

## **A tengely pozíciójának beállítása kategória vagy értéktengelyen**

Használja a [axis_between_categories](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/axis_between_categories/) beállítást, hogy szabályozza, az értéktengely a kategóriatengelyt a kategóriák között vagy a kategória jelölőnél metszze. Ez a tulajdonság a kategóriatengelyekre vonatkozik. A példa `True` értékre állítja ezt a vízszintes kategóriatengelyen egy oszlopdiagram esetén, és elmenti az eredményt.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.horizontal_axis.axis_between_categories = True

    presentation.save("AxisBetweenCategories.pptx", slides.export.SaveFormat.PPTX)
```

## **Megjelenítési egység beállítása diagram értéktengelyen**

Állítsa a [display_unit](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/display_unit/) értékét, hogy a címkéket egy értéktengelyen a háttéradatok módosítása nélkül méretezze. A [DisplayUnitType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/displayunittype/) `MILLIONS` értékre állításával a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a millió megjelenítési egységet alkalmazza a függőleges tengelyére.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS

    presentation.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **Logaritmikus értéktengely konfigurálása**

A logaritmikus skála akkor hasznos, ha a pozitív értékek több nagyságrendi szintet fednek le. Például egy szolgáltatás öt időszakban 10, 100, 1 000, 10 000 és 100 000 kérést kaphat. Lineáris skálán a kisebb értékek közel egymáshoz jelennek meg a nulla közelében. A logaritmikus skála könnyebbé teszi a relatív növekedés összehasonlítását: az egyenlő távolságok egyenlő arányokat jelentenek ahelyett, hogy egyenlő különbségeket jelentenének.

Állítsa a [is_logarithmic](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/is_logarithmic/) értékét `True`-ra az értéktengelyen, és használja a [log_base](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/log_base/) beállítást az alap választásához. Ez megváltoztatja a meglévő értékek megjelenítését; nem módosítja az adatot, és nem ad hozzá logaritmikus trendvonalat. A trendvonal az adatokhoz illesztett kapcsolatot jelenti, és külön funkció.

### **Az értéktengely és az alap kiválasztása**

Vonal- vagy oszlopdiagram esetén az értéktengely a [vertical_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/vertical_axis/). Vízszintes sávdiagram esetén a [horizontal_axis](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axesmanager/horizontal_axis/). Szórt és buborék diagramok két értéktengellyel rendelkeznek, ezért válassza ki a vízszintes tengelyt az X értékekhez, a függőleges tengelyt az Y értékekhez, vagy mindkettőt. Ne alkalmazzon logaritmikus méretezést kategóriatengelyre.

Az alapértelmezett logaritmikus alap a `10`. PPTX diagramok esetén 2‑től 1000‑ig (beleértve) használható alap; a törtalapok, például a `2.5` is támogatott. A `10` alap esetén a sorozatos hatványok (10, 100, 1 000, 10 000) egyenlő távolságra vannak.

### **Lineáris és logaritmikus skála összehasonlítása**

A következő önálló példa egy vonaldiagramot hoz létre az öt kérés számával az első dián, majd klónozza azt a diát, és a másodikon beállít egy 10‑es alapú logaritmikus értéktengelyt. Mindkét dia ugyanazt az adatot tartja.

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

    # Tartsa az első diát lineárisnak, és csak a másolat értéktengelyének skáláját változtassa meg.
    logarithmic_slide = presentation.slides.add_clone(slide)
    logarithmic_chart = logarithmic_slide.shapes[0]
    value_axis = logarithmic_chart.axes.vertical_axis
    value_axis.is_logarithmic = True
    value_axis.log_base = 10

    presentation.save("LogarithmicAxis.pptx", slides.export.SaveFormat.PPTX)
```

**Lineáris skála (1. dia):**  
Egyenlő függőleges távolságok azonos különbséget jelentenek a kérés számában. A legnagyobb érték uralja a diagramot, így a kisebb értékek nehezen megkülönböztethetők.

![Vonaldiagram PowerPointban, öt kérés száma lineáris értéktengelyen](value-axis-linear.png)

**Logaritmikus skála (2. dia):**  
Egyenlő függőleges távolságok egyenlő arányokat jelentenek. Minden periódus tízszer annyi kérést tartalmaz, mint az előző, így a pontok egy egyenes növekvő vonalat alkotnak a 10‑es alapú skálán. A tengelycímkék még mindig az eredeti kérés számát mutatják.

![Azonos öt kérés szám PowerPointban, 10‑es alapú logaritmikus értéktengelyen](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

A logaritmikus skála csak szigorúan pozitív értékeket tud megjeleníteni. Ellenőrizze az adatokat a bekapcsolása előtt. Ha a nulla vagy negatív értékek jelentősek, használjon lineáris skálát vagy jelenítse meg őket külön. Ha a kizárásuk megfelelő az elemzéshez, magyarázza meg az elhagyást. Ne helyettesítse csendben ezeket kis pozitív számokkal, mert ez megváltoztatja az adatok jelentését. A logaritmikus tengely manuálisan beállított minimumának vagy maximumának is pozitívnak kell lennie.

## **FAQ**

**Hogyan állíthatom be azt az értéket, ahol egy tengely keresztezi a másikat (tengelymetszet)?**  
Használja a [cross_type](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_type/) beállítást a metszet viselkedésének kiválasztásához. Numerikus metszőérték megadásához állítsa be a [cross_at](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/cross_at/) értékét. Ezek a beállítások lehetővé teszik, hogy a tengelymetszetet egy megfelelő alapvonalra helyezze.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez viszonyítva?**  
Állítsa be a [tick_label_position](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/tick_label_position/) értékét a [TickLabelPositionType](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ticklabelpositiontype/) segítségével: `LOW`, `HIGH`, `NEXT_TO` vagy `NONE`. A jelölő-márkák saját szabályozásához használja a [major_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/major_tick_mark/) vagy a [minor_tick_mark](https://reference.aspose.com/slides/python-net/aspose.slides.charts/axis/minor_tick_mark/) beállítást; ezek különállóak a címkeelhelyezéstől.