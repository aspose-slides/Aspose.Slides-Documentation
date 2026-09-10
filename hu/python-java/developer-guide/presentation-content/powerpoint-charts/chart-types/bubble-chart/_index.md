---
title: Buborékdiagramok testreszabása prezentációkban Python használatával
linktitle: Buborékdiagram
type: docs
url: /hu/python-java/bubble-chart/
keywords:
- buborékdiagram
- buborék méret
- méret skálázás
- méret ábrázolás
- PowerPoint
- prezentáció
- Python
- Java
- Aspose.Slides
description: "Készítsen és testreszabjon hatékony buborékdiagramokat a PowerPointban az Aspose.Slides for Python via Java segítségével, hogy könnyedén javítsa adatvizualizációját."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet buborékdiagramokkal dolgozni az Aspose.Slides‑ben. Két konkrét testreszabási lehetőséget tárgyal: a buborékméretek skálázását a [setBubbleSizeScale](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) metódussal, valamint a buborékméret‑értékek megjelenítésének vezérlését a [setBubbleSizeRepresentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) metódussal.

A példák bemutatják, hogyan hozhatunk létre egy buborékdiagramot, állíthatjuk be a méret skálázását, és válthatjuk a buborékméret ábrázolását szélességre. A cikk egy rövid GYIK‑szekciót is tartalmaz, amely tisztázza a „Bubble with 3‑D” diagramtípus támogatását, megjegyzi, hogy a gyakorlati diagramkorlátok a teljesítménytől és a cél PowerPoint‑verziótól függenek, valamint elmagyarázza, hogy az exportálás megőrzi a diagram megjelenését az Aspose.Slides renderelőmotorjával.

## **Buborékdiagram méretezésének skálázása**
Az Aspose.Slides for Python via Java támogatja a buborékdiagram méretezésének skálázását a [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale) és a [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) metódusokkal. Az alábbi példa bemutatja, hogyan kell skálázni a buborékméreteket.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Adatok ábrázolása buborékdiagram méretekkel**
A [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) és a [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) metódusok a [ChartSeriesGroup](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chartseriesgroup/) osztályban érhetők el. A buborékméret ábrázolása meghatározza, hogyan jelennek meg a buborékméret‑értékek a buborékdiagramon. Lehetséges értékek a [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bubblesizerepresentationtype/#Area) és a [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bubblesizerepresentationtype/#Width). A [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/hu/python-java/aspose.slides/bubblesizerepresentationtype/) felsorolt típusa a lehetséges módokat határozza meg, hogyan képviseljük az adatokat buborékdiagram méretekként. Az alábbi példa bemutatja, hogyan ábrázolhatók a buborékméretek szélesség használatával.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **GYIK**

**Támogatott a „3‑D‑effektusú buborékdiagram”, és miben különbözik a normálistól?**

Igen. Létezik egy külön diagramtípus, a „Bubble with 3‑D”. 3‑D stílust alkalmaz a buborékokra, de nem ad hozzá további tengelyt; az adatok továbbra X‑Y‑S (méret) maradnak. A típus a [chart type](https://reference.aspose.com/slides/hu/python-java/aspose.slides/charttype/) osztályban érhető el.

**Van korlátozás a sorozatok és pontok számára egy buborékdiagramon?**

Az API szintjén nincs szigorú korlát; a korlátozások a teljesítménytől és a cél PowerPoint‑verziótól függenek. Ajánlott a pontok számát ésszerűen tartani az olvashatóság és a renderelési sebesség érdekében.

**Hogyan befolyásolja az exportálás egy buborékdiagram megjelenését (PDF, képek)?**

Az exportálás a támogatott formátumokba megőrzi a diagram megjelenését; a renderelést az Aspose.Slides motor végzi. Raszter/vektor formátumok esetén általános diagramgrafikai renderelési szabályok érvényesek (felbontás, élsimítás), ezért nyomtatáshoz elegendő DPI‑t válasszunk.