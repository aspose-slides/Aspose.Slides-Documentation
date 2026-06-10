---
title: 3D diagramok testreszabása prezentációkban Python segítségével
linktitle: 3D diagram
type: docs
url: /hu/python-net/3d-chart/
keywords:
- 3D diagram
- forgás
- mélység
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat 3D diagramokat az Aspose.Slides for Python via .NET segítségével, PPT, PPTX és ODP fájlok támogatásával – növelje prezentációi hatékonyságát még ma."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testre szabni egy 3D diagramot az Aspose.Slides-ban a `rotation_3d` beállítások konfigurálásával, például `rotation_x`, `rotation_y`, `depth_percents` és `right_angle_axes`. Lépésről lépésre bemutatja egy prezentáció létrehozását, egy alapértelmezett adatokkal rendelkező 3D diagram hozzáadását, a szükséges 3D nézet beállításainak alkalmazását, és a módosított prezentáció PPTX fájlként való mentését.

## **A 3D diagram RotationX, RotationY és DepthPercents tulajdonságainak beállítása**
Az Aspose.Slides for Python via .NET egyszerű API-t biztosít ezen tulajdonságok beállításához. A következő cikk segít megérteni, hogyan állíthatók be különböző tulajdonságok, mint az X, Y forgatás, **DepthPercents** stb. A minta kód alkalmazza a fent említett tulajdonságok beállítását.

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Elérje az első diát.
1. Adjon hozzá diagramot alapértelmezett adatokkal.
1. Állítsa be a Rotation3D tulajdonságokat.
1. Írja ki a módosított prezentációt PPTX fájlként.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Létrehozza a Presentation osztály egy példányát
with slides.Presentation() as presentation:
            
    # Első dia elérése
    slide = presentation.slides[0]

    # Diagram hozzáadása alapértelmezett adatokkal
    chart = slide.shapes.add_chart(charts.ChartType.STACKED_COLUMN_3D, 0, 0, 500, 500)

    # A diagram adatlapon lévő index beállítása
    defaultWorksheetIndex = 0

    # A diagram adatlapon (worksheet) lekérése
    fact = chart.chart_data.chart_data_workbook

    # Sorozat hozzáadása
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.type)
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.type)

    # Kategóriák hozzáadása
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"))
    chart.chart_data.categories.add(fact.get_cell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"))

    # Rotation3D tulajdonságok beállítása
    chart.rotation_3d.right_angle_axes = True
    chart.rotation_3d.rotation_x = 40
    chart.rotation_3d.rotation_y = 270
    chart.rotation_3d.depth_percents = 150

    # Második diagram sorozat kivétele
    series = chart.chart_data.series[1]

    # Sorozat adatok feltöltése
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 20))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 50))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 1, 2, 30))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 2, 2, 10))
    series.data_points.add_data_point_for_bar_series(fact.get_cell(defaultWorksheetIndex, 3, 2, 60))

    # Overlap érték beállítása
    series.parent_series_group.overlap = 100         

    # Prezentáció mentése lemezre
    presentation.save("Rotation3D_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Gyakran Ismételt Kérdések**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ban?**

Az Aspose.Slides támogatja a oszlopdiagramok 3D változatait, beleértve a Column 3D, Clustered Column 3D, Stacked Column 3D és a 100% Stacked Column 3D diagramokat, valamint a kapcsolódó 3D típusokat, amelyeket a [ChartType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/charttype/) felsorolás tartalmaz. A pontos, naprakész lista megtekintéséhez ellenőrizze a [ChartType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/charttype/) elemeit a telepített verzió API-referenciájában.

**Kaphatok raszteres képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatja képként a [chart API](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/chart/get_image/) vagy [az egész dia renderelésével](/slides/hu/python-net/convert-powerpoint-to-png/) PNG vagy JPEG formátumba. Ez akkor hasznos, ha pixelpontosságú előnézetre van szüksége, vagy be szeretné ágyazni a diagramot dokumentumokba, irányítópultokba vagy weboldalakba anélkül, hogy a PowerPointra lenne szükség.

**Milyen teljesítményű a nagy 3D diagramok felépítése és renderelése?**

A teljesítmény az adatmennyiségtől és a vizuális összetettségtől függ. A legjobb eredmény érdekében tartsa minimálisra a 3D hatásokat, kerülje a nehéz textúrákat a falakon és a diagramterületeken, korlátozza az adatpontok számát sorozatonként, ha lehetséges, és rendereljen egy megfelelő méretű kimenetre (felbontás és méretek) a célkijelző vagy nyomtatási igényekhez.