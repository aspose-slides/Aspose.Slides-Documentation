---
title: 3D diagramok testreszabása prezentációkban Python használatával
linktitle: 3D diagram
type: docs
url: /hu/python-java/3d-chart/
keywords:
- 3D diagram
- forgás
- mélység
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és testreszabhat 3D diagramokat az Aspose.Slides for Python via Java segítségével, PPT és PPTX fájlok támogatásával — növelje prezentációi hatékonyságát még ma."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni egy 3D diagramot az Aspose.Slides-ban a [Rotation3D](https://reference.aspose.com/slides/hu/python-java/aspose.slides/rotation3d/) beállítások konfigurálásával, például a [setRotationX](https://reference.aspose.com/slides/hu/python-java/aspose.slides/rotation3d/#setRotationX), [setRotationY](https://reference.aspose.com/slides/hu/python-java/aspose.slides/rotation3d/#setRotationY), [setDepthPercents](https://reference.aspose.com/slides/hu/python-java/aspose.slides/rotation3d/#setDepthPercents) és a [setRightAngleAxes](https://reference.aspose.com/slides/hu/python-java/aspose.slides/rotation3d/#setRightAngleAxes) használatával. A cikk végigvezeti a prezentáció létrehozását, egy alapértelmezett adatokkal rendelkező 3D diagram hozzáadását, a szükséges 3D nézetbeállítások alkalmazását, valamint a módosított prezentáció PPTX fájlként történő mentését.

## **X forgatás, Y forgatás és a 3D diagram mélységének beállítása**
Az Aspose.Slides for Python via Java egyszerű API‑t biztosít ezen tulajdonságok beállításához. Az alábbi példa azt mutatja be, hogyan állítható be az X forgatás, Y forgatás és a 3D diagram mélysége.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.
2. Érje el az első diát.
3. Adjon hozzá egy diagramot alapértelmezett adatokkal.
4. Állítsa be a 3D forgatási tulajdonságokat.
5. Írja ki a módosított prezentációt PPTX fájlba.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    # Hozzáférés az első diához.
    slide = presentation.getSlides().get_Item(0)

    # Diagram hozzáadása alapértelmezett adatokkal.
    chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500)

    # A diagram adat munkalap indexének beállítása.
    default_worksheet_index = 0

    # A diagram adat munkafüzetének lekérése.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Sorozat hozzáadása.
    series_cell = workbook.getCell(default_worksheet_index, 0, 1, "Series 1")
    chart.getChartData().getSeries().add(series_cell, chart.getType())
    series_cell = workbook.getCell(default_worksheet_index, 0, 2, "Series 2")
    chart.getChartData().getSeries().add(series_cell, chart.getType())

    # Kategóriák hozzáadása.
    category_cell = workbook.getCell(default_worksheet_index, 1, 0, "Category 1")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 2, 0, "Category 2")
    chart.getChartData().getCategories().add(category_cell)
    category_cell = workbook.getCell(default_worksheet_index, 3, 0, "Category 3")
    chart.getChartData().getCategories().add(category_cell)

    # A 3D forgatási tulajdonságok beállítása.
    chart.getRotation3D().setRightAngleAxes(True)
    chart.getRotation3D().setRotationX(jpype.JByte(40))
    chart.getRotation3D().setRotationY(270)
    chart.getRotation3D().setDepthPercents(150)

    # A második diagram sorozat elérése.
    series = chart.getChartData().getSeries().get_Item(1)

    # A sorozat adatainak feltöltése.
    data_cell = workbook.getCell(default_worksheet_index, 1, 1, jpype.JInt(20))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 1, jpype.JInt(50))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 1, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 1, 2, jpype.JInt(30))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 2, 2, jpype.JInt(10))
    series.getDataPoints().addDataPointForBarSeries(data_cell)
    data_cell = workbook.getCell(default_worksheet_index, 3, 2, jpype.JInt(60))
    series.getDataPoints().addDataPointForBarSeries(data_cell)

    # A prezentáció mentése.
    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Mely diagramtípusok támogatják a 3D módot az Aspose.Slides-ban?**

Az Aspose.Slides támogatja a 3D oszlopdiagramok változatait, többek között a Column 3D, Clustered Column 3D, Stacked Column 3D és 100% Stacked Column 3D típusokat, valamint a [ChartType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/charttype/) osztályon keresztül elérhető kapcsolódó 3D típusokat. A pontos, naprakész lista megtekintéséhez ellenőrizze a [ChartType](https://reference.aspose.com/slides/hu/python-java/aspose.slides/charttype/) tagjait a telepített verzió API‑referenciájában.

**Kaphatok raszteres képet egy 3D diagramról jelentéshez vagy a webhez?**

Igen. A diagramot exportálhatja képként a [chart API](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shape/#getImage) segítségével, vagy a [render the entire slide](/slides/hu/python-java/convert-powerpoint-to-png/) segítségével PNG vagy JPEG formátumba. Ez akkor hasznos, ha pixelpontos előnézetre van szüksége, vagy a diagramot dokumentumokba, műszerfalakba vagy weboldalakba szeretné beágyazni anélkül, hogy a PowerPointra lenne szükség.

**Mennyire teljesítményhatékony a nagy 3D diagramok felépítése és renderelése?**

Az teljesítmény az adatmennyiségtől és a vizuális összetettségtől függ. A legjobb eredmény érdekében tartsa minimálisra a 3D hatásokat, kerülje a nehéz textúrák használatát a falakon és a diagram területén, korlátozza az adatpontok számát sorozatonként, ahol csak lehetséges, és rendereljen megfelelő méretű (felbontású és dimenziós) kimenetre, hogy megfeleljen a célkijelző vagy nyomtatási igényeknek.