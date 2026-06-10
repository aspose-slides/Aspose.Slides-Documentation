---
title: Prezentációs diagramok hibasávjainak testreszabása Pythonban
linktitle: Hibasáv
type: docs
url: /hu/python-net/error-bar/
keywords:
- hibasáv
- egyéni érték
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan adhat hozzá és testreszabhat hibasávokat diagramokhoz az Aspose.Slides for Python via .NET segítségével—optimalizálja az adatmegjelenítést PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk hibasávokkal a prezentációs diagramokban az Aspose.Slides használatával. Megmutatja, hogyan adhatunk hibasávokat egy diagram sorozathoz, hogyan konfigurálhatjuk az X és Y hibasáv beállításait, és hogyan alkalmazhatunk különböző értéktípusokat, mint például rögzített, százalékos és egyéni értékek.

Továbbá bemutatja, hogyan rendelhetünk egyéni hibasáv értékeket egy sorozat egyedi adatpontjaihoz a megfelelő adatpontgyűjtemény használatával. Emellett a cikk rövid megjegyzéseket tartalmaz arról, hogyan viselkednek a hibasávok exportálás során, kompatibilitásukról a jelölőkkel és adatcímkékkel, valamint arról, hol találhatók a kapcsolódó API referenciak osztályok és enumok.

## **Hibasáv hozzáadása**
Az Aspose.Slides for Python via .NET egyszerű API-t biztosít a hibasáv értékek kezelésére. A minta kód akkor használható, amikor egy egyéni értéktípust alkalmazunk. Érték megadásához használja a **ErrorBarCustomValues** tulajdonságot a sorozat **DataPoints** gyűjteményében lévő adott adatponthoz:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Adjon hozzá egy buborékdiagramot a kívánt diára.
1. Hozzáférés az első diagram sorozathoz, és állítsa be a hibasáv X formátumát.
1. Hozzáférés az első diagram sorozathoz, és állítsa be a hibasáv Y formátumát.
1. A sávok értékének és formátumának beállítása.
1. Írja a módosított prezentációt PPTX fájlba.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Üres prezentáció létrehozása
with slides.Presentation() as presentation:
    # Buborékdiagram létrehozása
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Hibasávok hozzáadása és formátumuk beállítása
    errBarX = chart.chart_data.series[0].error_bars_x_format
    errBarY = chart.chart_data.series[0].error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.FIXED
    errBarX.value = 0.1
    errBarY.value_type = charts.ErrorBarValueType.PERCENTAGE
    errBarY.value = 5
    errBarX.type = charts.ErrorBarType.PLUS
    errBarY.format.line.width = 2
    errBarX.has_end_cap = True

    # Prezentáció mentése
    presentation.save("ErrorBars_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Egyéni hibasáv érték hozzáadása**
Az Aspose.Slides for Python via .NET egyszerű API-t biztosít egyéni hibasáv értékek kezelésére. A minta kód akkor használható, amikor az **IErrorBarsFormat.ValueType** tulajdonság **Custom** értékre van állítva. Érték megadásához használja a **ErrorBarCustomValues** tulajdonságot a sorozat **DataPoints** gyűjteményében lévő adott adatponthoz:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályból.
1. Adjon hozzá egy buborékdiagramot a kívánt diára.
1. Hozzáférés az első diagram sorozathoz, és állítsa be a hibasáv X formátumát.
1. Hozzáférés az első diagram sorozathoz, és állítsa be a hibasáv Y formátumát.
1. Hozzáférés a diagram sorozat egyedi adatpontjaihoz, és az egyes sorozati adatpontok hibasáv értékeinek beállítása.
1. A sávok értékének és formátumának beállítása.
1. Írja a módosított prezentációt PPTX fájlba.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Üres prezentáció létrehozása
with slides.Presentation() as presentation:
    # Buborékdiagram létrehozása
    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 400, 300, True)

    # Egyéni hibasávok hozzáadása és formátumuk beállítása
    series = chart.chart_data.series[0]
    errBarX = series.error_bars_x_format
    errBarY = series.error_bars_y_format
    errBarX.is_visible = True
    errBarY.is_visible = True
    errBarX.value_type = charts.ErrorBarValueType.CUSTOM
    errBarY.value_type = charts.ErrorBarValueType.CUSTOM

    # Diagram sorozat adatpontjának elérése és hibasáv értékek beállítása egyedi ponthoz
    points = series.data_points
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_x_minus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_plus_values = charts.DataSourceType.DOUBLE_LITERALS
    points.data_source_type_for_error_bars_custom_values.data_source_type_for_y_minus_values = charts.DataSourceType.DOUBLE_LITERALS

    # Hibasávok beállítása a diagram sorozat pontjaihoz
    for i in range(len(points)):
        points[i].error_bars_custom_values.x_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.x_plus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_minus.as_literal_double = i + 1
        points[i].error_bars_custom_values.y_plus.as_literal_double = i + 1

    # Prezentáció mentése
    presentation.save("ErrorBarsCustomValues_out.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Mi történik a hibasávokkal, amikor egy prezentációt PDF-re vagy képekre exportálunk?**

A hibasávok a diagram részeként kerülnek renderelésre, és a konverzió során a diagram többi formázásával együtt megmaradnak, feltéve, hogy kompatibilis verzió vagy renderelő áll rendelkezésre.

**A hibasávok kombinálhatók jelölőkkel és adatcímkékkel?**

Igen. A hibasávok különálló elemek, és kompatibilisek a jelölőkkel és adatcímkékkel; ha az elemek átfednek, előfordulhat, hogy a formázást módosítani kell.

**Hol találom az API-ban a hibasávokhoz kapcsolódó tulajdonságok és enumok listáját?**

Az API referencia: a [ErrorBarsFormat](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/errorbarsformat/) osztály és a kapcsolódó enumok [ErrorBarType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/errorbartype/) és [ErrorBarValueType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/errorbarvaluetype/).