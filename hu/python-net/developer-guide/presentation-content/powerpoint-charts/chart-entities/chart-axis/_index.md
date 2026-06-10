---
title: "Diagram tengelyek testreszabása prezentációkban Python segítségével"
linktitle: "Diagram tengely"
type: docs
url: /hu/python-net/chart-axis/
keywords:
- "diagram tengely"
- "függőleges tengely"
- "vízszintes tengely"
- "tengely testreszabása"
- "tengely manipulálása"
- "tengely kezelése"
- "tengely tulajdonságok"
- "maximális érték"
- "minimális érték"
- "tengelyvonal"
- "dátumformátum"
- "tengelycím"
- "tengely pozíció"
- "PowerPoint"
- "OpenDocument"
- "prezentáció"
- "Python"
- "Aspose.Slides"
description: "Ismerje meg, hogyan használhatja az Aspose.Slides for Python via .NET-et a diagram tengelyek testreszabásához PowerPoint és OpenDocument prezentációkban jelentések és vizualizációk készítéséhez."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides-ben. Megmutatja, hogyan lehet lekérdezni a tényleges tengelyértékeket, adatcserét végezni a tengelyek között, elrejteni a függőleges vagy vízszintes tengelyt vonaldiagramoknál, megváltoztatni a kategória tengely típusát, beállítani a dátumformátumot a kategória tengely értékeihez, elforgatni egy tengelycímkét, beállítani a tengely pozícióját, és megjeleníteni egy egységcímkét az értéktengelyen.

## **A függőleges tengely maximális értékeinek lekérése diagramokban**
Az Aspose.Slides for Python via .NET lehetővé teszi a minimum és maximum értékek lekérését egy függőleges tengelyen. Kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
2. Hozzáférés az első diára.
3. Adjon hozzá egy diagramot az alapértelmezett adatokkal.
4. Szerezze meg a tényleges maximális értéket a tengelyen.
5. Szerezze meg a tényleges minimum értéket a tengelyen.
6. Szerezze meg a tényleges fő egységet a tengelyen.
7. Szerezze meg a tényleges al‑egységet a tengelyen.
8. Szerezze meg a tényleges fő egység skálát a tengelyen.
9. Szerezze meg a tényleges al‑egység skálát a tengelyen.

Ez a példakód – a fenti lépések megvalósítása – bemutatja, hogyan lehet lekérni a szükséges értékeket Pythonban:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 100, 100, 500, 350)
	chart.validate_chart_layout()

	maxValue = chart.axes.vertical_axis.actual_max_value
	minValue = chart.axes.vertical_axis.actual_min_value

	majorUnit = chart.axes.horizontal_axis.actual_major_unit
	minorUnit = chart.axes.horizontal_axis.actual_minor_unit
	
	# Mentés a prezentációt
	pres.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Adatcsere a tengelyek között**
Aspose.Slides lehetővé teszi az adatok gyors cseréjét a tengelyek között – a függőleges tengelyen (y‑tengely) lévő adatok a vízszintes tengelyre (x‑tengely) kerülnek, és fordítva.

Ez a Python kód megmutatja, hogyan lehet a diagram tengelyei között adatcserét végezni:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

    # Üres prezentáció létrehozása
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 400, 300)

    #Sorok és oszlopok felcserélése
    chart.chart_data.switch_row_column()
            
    # Mentés a prezentációt
    pres.save("SwitchChartRowColumns_out.pptx", slides.export.SaveFormat.PPTX)
```

## **A függőleges tengely letiltása vonaldiagramoknál**

Ez a Python kód megmutatja, hogyan lehet elrejteni a függőleges tengelyt egy vonaldiagramnál:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.vertical_axis.is_visible = False
    
    pres.save("chart-is_visible.pptx", slides.export.SaveFormat.PPTX)
```

## **A vízszintes tengely letiltása vonaldiagramoknál**

Ez a kód megmutatja, hogyan lehet elrejteni a vízszintes tengelyt egy vonaldiagramnál:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
 
with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.LINE, 100, 100, 400, 300)
    chart.axes.horizontal_axis.is_visible = False

    pres.save("chart-2.pptx", slides.export.SaveFormat.PPTX)
```

## **Kategória tengely módosítása**

A **CategoryAxisType** tulajdonság használatával meghatározhatja a kívánt kategória tengely típusát (**date** vagy **text**). Ez a Python kód demonstrálja a műveletet:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation(path + "ExistingChart.pptx") as presentation:
    chart = presentation.slides[0].shapes[0]
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_automatic_major_unit = False
    chart.axes.horizontal_axis.major_unit = 1
    chart.axes.horizontal_axis.major_unit_scale = charts.TimeUnitType.MONTHS
    presentation.save("ChangeChartCategoryAxis_out.pptx", slides.export.SaveFormat.PPTX)
```

## **A kategória tengely értékének dátumformátuma beállítása**

Aspose.Slides for Python via .NET lehetővé teszi a dátumformátum beállítását egy kategória tengely értékéhez. A műveletet ebben a Python kódban mutatjuk be:

```py
import aspose.slides.charts as charts
import aspose.slides as slides
from datetime import date

def to_oadate(dt):
    delta = dt - date(1899, 12, 30)
    return delta.days + (delta.seconds + delta.microseconds / 1e6) / (24 * 3600)

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.AREA, 50, 50, 450, 300)

    wb = chart.chart_data.chart_data_workbook

    wb.clear(0)

    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    chart.chart_data.categories.add(wb.get_cell(0, "A2", to_oadate(date(2015, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A3", to_oadate(date(2016, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A4", to_oadate(date(2017, 1, 1))))
    chart.chart_data.categories.add(wb.get_cell(0, "A5", to_oadate(date(2018, 1, 1))))

    series = chart.chart_data.series.add(charts.ChartType.LINE)
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B2", 1))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B3", 2))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B4", 3))
    series.data_points.add_data_point_for_line_series(wb.get_cell(0, "B5", 4))
    chart.axes.horizontal_axis.category_axis_type = charts.CategoryAxisType.DATE
    chart.axes.horizontal_axis.is_number_format_linked_to_source = False
    chart.axes.horizontal_axis.number_format = "yyyy"
    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **A diagram tengelycím forgatási szögének beállítása**

Aspose.Slides for Python via .NET lehetővé teszi a diagram tengelycímének forgatási szögének beállítását. Ez a Python kód demonstrálja a műveletet:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
    chart.axes.vertical_axis.has_title = True
    chart.axes.vertical_axis.title.text_format.text_block_format.rotation_angle = 90

    pres.save("test.pptx", slides.export.SaveFormat.PPTX)
```

## **A tengely pozíciójának beállítása egy kategória vagy értéktengelyen**

Aspose.Slides for Python via .NET lehetővé teszi a tengely pozíciójának beállítását egy kategória vagy értéktengelyen. Ez a Python kód bemutatja, hogyan hajtható végre a feladat:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.horizontal_axis.axis_between_categories = True

	pres.save("AsposeScatterChart.pptx", slides.export.SaveFormat.PPTX)
```

## **Egységcímke megjelenítésének engedélyezése a diagram értéktengelyén**

Aspose.Slides for Python via .NET lehetővé teszi, hogy a diagram értéktengelyén egységcímkét jelenítsen meg. Ez a Python kód demonstrálja a műveletet:

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 450, 300)
	chart.axes.vertical_axis.display_unit = charts.DisplayUnitType.MILLIONS
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Hogyan állíthatom be azt az értéket, ahol az egyik tengely a másikat metszik (tengelykereszt)?**

A tengelyek egy [crossing setting](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/axis/cross_type/) beállítást kínálnak: választhat, hogy a nullán, a legnagyobb kategórián/értéken vagy egy adott numerikus értéken keresztezik egymást. Ez hasznos az X‑tengely felfelé vagy lefelé mozgatásához, illetve egy alapvonal hangsúlyozásához.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez képest (oldalán, kívül, belül)?**

Állítsa be a [label position](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/axis/major_tick_mark/) értékét „cross”, „outside” vagy „inside” értékre. Ez befolyásolja az olvashatóságot, és segít helyet takarítani, különösen kis diagramok esetén.