---
title: Trendvonalak hozzáadása prezentációs diagramokhoz Pythonban
linktitle: Trendvonal
type: docs
url: /hu/python-net/trend-line/
keywords:
- diagram
- trendvonal
- exponenciális trendvonal
- lineáris trendvonal
- logaritmikus trendvonal
- mozgó átlag trendvonal
- polinomiális trendvonal
- hatvány trendvonal
- egyedi trendvonal
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Gyorsan adjon hozzá és testreszabjon trendvonalakat a PowerPoint és OpenDocument diagramokban az Aspose.Slides for Python via .NET segítségével — egy gyakorlati útmutató és kódrészletek a előrejelzési pontosság javításához és a közönség bevonásához."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet trendvonalakat hozzáadni a prezentációs diagramokhoz az Aspose.Slides használatával. Megmutatja, hogyan kell diagramot létrehozni, trendvonalakat hozzáadni a diagram sorozataihoz, és többféle trendvonal típussal dolgozni, beleértve az exponenciális, lineáris, logaritmikus, mozgó átlag, polinomiális és hatvány vonalakat.

Leírja továbbá, hogyan lehet egy egyedi vonalat hozzáadni a diagramhoz vonal alakzat beillesztésével, és tartalmaz egy rövid GYIK-ot a trendvonal előre és hátra irányú kivetítési értékeiről, valamint arról, hogy a trendvonalak megmaradnak-e PDF vagy SVG exportáláskor, illetve diagramok képként történő renderelésekor.

## **Trendvonal hozzáadása**
Az Aspose.Slides for Python via .NET egyszerű API-t biztosít különböző diagram Trendvonalak kezeléséhez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Szerezze meg egy dia hivatkozását az indexe alapján.
1. Adjon hozzá egy diagramot alapértelmezett adatokkal, valamint a kívánt típus valamelyikét (ez a példában a ChartType.CLUSTERED_COLUMN-t használja).
1. Exponenciális trendvonal hozzáadása az 1. diagram sorozathoz.
1. Lineáris trendvonal hozzáadása az 1. diagram sorozathoz.
1. Logaritmikus trendvonal hozzáadása a 2. diagram sorozathoz.
1. Mozgó átlag trendvonal hozzáadása a 2. diagram sorozathoz.
1. Polinomiális trendvonal hozzáadása a 3. diagram sorozathoz.
1. Hatvány trendvonal hozzáadása a 3. diagram sorozathoz.
1. Írja a módosított prezentációt egy PPTX fájlba.

Az alábbi kódot használják diagram Trendvonalakkal történő létrehozásához.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

# Üres prezentáció létrehozása
with slides.Presentation() as pres:

    # Klaszterezett oszlopdiagram létrehozása
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 20, 500, 400)

    # Exponenciális trendvonal hozzáadása az 1. diagram sorozathoz
    tredLinep = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.EXPONENTIAL)
    tredLinep.display_equation = False
    tredLinep.display_r_squared_value = False

    # Lineáris trendvonal hozzáadása az 1. diagram sorozathoz
    tredLineLin = chart.chart_data.series[0].trend_lines.add(charts.TrendlineType.LINEAR)
    tredLineLin.trendline_type = charts.TrendlineType.LINEAR
    tredLineLin.format.line.fill_format.fill_type = slides.FillType.SOLID
    tredLineLin.format.line.fill_format.solid_fill_color.color = draw.Color.red


    # Logaritmikus trendvonal hozzáadása a 2. diagram sorozathoz
    tredLineLog = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.LOGARITHMIC)
    tredLineLog.trendline_type = charts.TrendlineType.LOGARITHMIC
    tredLineLog.add_text_frame_for_overriding("New log trend line")

    # Mozgó átlag trendvonal hozzáadása a 2. diagram sorozathoz
    tredLineMovAvg = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.MOVING_AVERAGE)
    tredLineMovAvg.trendline_type = charts.TrendlineType.MOVING_AVERAGE
    tredLineMovAvg.period = 3
    tredLineMovAvg.trendline_name = "New TrendLine Name"

    # Polinomiális trendvonal hozzáadása a 3. diagram sorozathoz
    tredLinePol = chart.chart_data.series[2].trend_lines.add(charts.TrendlineType.POLYNOMIAL)
    tredLinePol.trendline_type = charts.TrendlineType.POLYNOMIAL
    tredLinePol.forward = 1
    tredLinePol.order = 3

    # Hatvány trendvonal hozzáadása a 3. diagram sorozathoz
    tredLinePower = chart.chart_data.series[1].trend_lines.add(charts.TrendlineType.POWER)
    tredLinePower.trendline_type = charts.TrendlineType.POWER
    tredLinePower.backward = 1

    # Prezentáció mentése
    pres.save("Charttrend_lines_out.pptx", slides.export.SaveFormat.PPTX)
```



## **Egyedi vonal hozzáadása**
Az Aspose.Slides for Python via .NET egyszerű API-t biztosít egyedi vonalak diagramhoz való hozzáadásához. Egy egyszerű egyenes vonal hozzáadásához a prezentáció egy kiválasztott diájához, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a Presentation osztályból
- Szerezze meg egy dia hivatkozását az Index használatával
- Hozzon létre egy új diagramot a Shapes objektum által biztosított AddChart metódus használatával
- Adjon hozzá egy Line típusú AutoShape-et a Shapes objektum által biztosított AddAutoShape metódus használatával
- Állítsa be a forma vonalainak színét.
- Írja a módosított prezentációt PPTX fájlként

Az alábbi kódot használják diagram Custom Lines hozzáadásával.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 400)
    shape = chart.user_shapes.shapes.add_auto_shape(slides.ShapeType.LINE, 0, chart.height / 2, chart.width, 0)
    shape.line_format.fill_format.fill_type = slides.FillType.SOLID
    shape.line_format.fill_format.solid_fill_color.color = draw.Color.red
    pres.save("AddCustomLines.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Mit jelent a 'forward' és a 'backward' egy trendvonal esetén?**

Azok a trendvonal hosszak, amelyeket előre/hátra vetítenek: szórásdiagramok (XY) esetén – tengelyegységekben; nem szórás diagramok esetén – kategóriák számában. Csak nemnegatív értékek engedélyezettek.

**Megmarad a trendvonal a prezentáció PDF vagy SVG formátumba exportálásakor, vagy egy dia képként való renderelésekor?**

Yes. Az Aspose.Slides prezentációkat konvertálja [PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/)/[SVG](/slides/hu/python-net/render-a-slide-as-an-svg-image/) formátumba, és diagramokat képekké renderel; a trendvonalak, mint a diagram részei, megmaradnak ezek során. Egy módszer is elérhető a diagram [képének exportálására](/slides/hu/python-net/create-shape-thumbnails/) közvetlenül.