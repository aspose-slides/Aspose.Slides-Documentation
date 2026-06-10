---
title: Kördiagramok testreszabása prezentációkban Python használatával
linktitle: Kördiagram
type: docs
url: /hu/python-net/pie-chart/
keywords:
- kördiagram
- diagram kezelése
- diagram testreszabása
- diagram opciók
- diagram beállítások
- ábrázolási beállítások
- szelet szín
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat kördiagramokat Pythonban az Aspose.Slides használatával, exportálható PowerPoint és OpenDocument formátumba, és növelje adatmesélését néhány másodperc alatt."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozzunk kördiagramokkal az Aspose.Slides-ban. Megmutatja, hogyan állítható be a másodlagos ábrázolási beállítás a Pie of Pie és Bar of Pie diagramoknál, valamint hogyan engedélyezhető az automatikus szeletszínezés egy szokásos kördiagramhoz.

A példák gyakorlati diagram testreszabási lépésekre fókuszálnak, mint például a diagram hozzáadása egy diára, a sorozat- és címke beállítások módosítása, az alapértelmezett diagramadatok helyettesítése egyéni kategóriákkal és értékekkel, valamint a frissített prezentáció mentése.

## **Másodlagos ábrázolási beállítások a Pie of Pie és Bar of Pie diagramokhoz**
Az Aspose.Slides for Python via .NET most már támogatja a másodlagos ábrázolási beállításokat a Pie of Pie vagy Bar of Pie diagramoknál. Ebben a témában egy példán keresztül mutatjuk be, hogyan lehet ezeket a beállításokat megadni az Aspose.Slides használatával. A tulajdonságok megadásához kövesse az alábbi lépéseket:

1. Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályt.
1. Adjon diagramot a diára.
1. Adja meg a diagram másodlagos ábrázolási beállításait.
1. Írja a prezentációt lemezre.

Az alább bemutatott példában a Pie of Pie diagram különböző tulajdonságait állítottuk be.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Hozzon létre egy példányt a Presentation osztályból
with slides.Presentation() as presentation:
    # Adjon diagramot a diára
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.PIE_OF_PIE, 50, 50, 500, 400)
        
    # Állítson be különböző tulajdonságokat
    chart.chart_data.series[0].labels.default_data_label_format.show_value = True
    chart.chart_data.series[0].parent_series_group.second_pie_size = 149
    chart.chart_data.series[0].parent_series_group.pie_split_by = charts.PieSplitType.BY_PERCENTAGE
    chart.chart_data.series[0].parent_series_group.pie_split_position = 53

    # Mentse a prezentációt lemezre
    presentation.save("SecondPlotOptionsforCharts_out.pptx", slides.export.SaveFormat.PPTX)
```




## **Automatikus kördiagram szelet színek beállítása**
Az Aspose.Slides for Python via .NET egyszerű API-t biztosít az automatikus kördiagram szelet színek beállításához. A minta kód a fent említett tulajdonságok beállítását valósítja meg.

1. Hozzon létre egy példányt a Presentation osztályból.
1. Hozzáférés az első diához.
1. Adjon diagramot az alapértelmezett adatokkal.
1. Állítsa be a diagram címét.
1. Állítsa az első sorozatot a Értékek megjelenítésére.
1. Állítsa be a diagram adatlap indexét.
1. Szerezze meg a diagram adatlap munkalapját.
1. Törölje az alapértelmezett generált sorozatokat és kategóriákat.
1. Adjon új kategóriákat.
1. Adjon új sorozatot.

Mentse a módosított prezentációt egy PPTX fájlba.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Példányosítsa a Presentation osztályt, amely egy PPTX fájlt képvisel
with slides.Presentation() as presentation:
	# Első dia elérése
	slide = presentation.slides[0]

	# Diagram hozzáadása alapértelmezett adatokkal
	chart = slide.shapes.add_chart(charts.ChartType.PIE, 100, 100, 400, 400)

	# Diagram címének beállítása
	chart.chart_title.add_text_frame_for_overriding("Sample Title")
	chart.chart_title.text_frame_for_overriding.text_frame_format.center_text = 1
	chart.chart_title.height = 20
	chart.has_title = True

	# Az első sorozat beállítása Értékek megjelenítésére
	chart.chart_data.series[0].labels.default_data_label_format.show_value = True

	# A diagram adatlap indexének beállítása
	defaultWorksheetIndex = 0

	# A diagram adatlap munkalapjának lekérése
	fact = chart.chart_data.chart_data_workbook

	# Alapértelmezett generált sorozatok és kategóriák törlése
	chart.chart_data.series.clear()
	chart.chart_data.categories.clear()

	# Új kategóriák hozzáadása
	chart.chart_data.categories.add(fact.get_cell(0, 1, 0, "First Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 2, 0, "2nd Qtr"))
	chart.chart_data.categories.add(fact.get_cell(0, 3, 0, "3rd Qtr"))

	# Új sorozat hozzáadása
	series = chart.chart_data.series.add(fact.get_cell(0, 0, 1, "Series 1"), chart.type)

	# Sorozat adatok feltöltése
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
	series.data_points.add_data_point_for_pie_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))

	series.parent_series_group.is_color_varied = True
	presentation.save("Pie.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Támogatja a 'Pie of Pie' és a 'Bar of Pie' változatokat?**

Igen, a könyvtár [támogatja](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/charttype/) a kördiagramok másodlagos ábrázolását, beleértve a 'Pie of Pie' és a 'Bar of Pie' típusokat.

**Exportálhatom a diagramot csak képként (például PNG)?**

Igen, [exportálja a diagramot képként](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/get_image/) (például PNG) a teljes prezentáció nélkül.