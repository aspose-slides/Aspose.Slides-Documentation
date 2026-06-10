---
title: Diagram adatjelölők kezelése prezentációkban Python segítségével
linktitle: Adatjelölő
type: docs
url: /hu/python-net/chart-data-marker/
keywords:
- diagram
- adatpont
- jelölő
- jelölő beállítások
- jelölő méret
- kitöltési típus
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan testre szabhatja a diagram adatjelölőket az Aspose.Slides-ban, növelve a prezentáció hatását a PPT, PPTX és ODP formátumokban, világos kódrészletekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kell kezelni a diagram adatjelölőket az Aspose.Slides-ban. Megmutatja, hogyan hozhatunk létre diagramot, hogyan érhetjük el egy sorozatot és annak adatpontjait, hogyan alkalmazhatunk képkitöltést a jelölőkre az adatpont szinten, hogyan állíthatjuk be a jelölő méretét, és hogyan menthetjük el a frissített prezentációt. Azt is megjegyzi, hogy a standard jelölőformák a `MarkerStyleType` felsorolásban érhetők el, és a jelölő megjelenése megmarad a diagramok raszteres formátumokba vagy SVG-be exportálásakor.

## **Diagram jelölőbeállítások beállítása**
A jelölőket a diagram adatpontjain belül, egy adott sorozatban állíthatjuk be. A diagram jelölőbeállítások megadásához kövesse az alábbi lépéseket:

- Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/python-net/aspose.slides/presentation/) osztályt.
- Készítse el az alapértelmezett diagramot.
- Állítsa be a képet.
- Vegye az első diagram sorozatot.
- Adjon hozzá új adatpontot.
- Írja a prezentációt a lemezre.

Az alábbi példában a diagram jelölőbeállításokat adatpont szinten állítottuk be.

```py
import aspose.slides.charts as charts
import aspose.slides as slides
import aspose.pydrawing as draw

    # Hozzon létre egy példányt a Presentation osztályból
with slides.Presentation() as presentation:

    slide = presentation.slides[0]

    # Az alapértelmezett diagram létrehozása
    chart = slide.shapes.add_chart(charts.ChartType.LINE_WITH_MARKERS, 0, 0, 400, 400)

    # Az alapértelmezett diagram adat munkalap indexének lekérése
    defaultWorksheetIndex = 0

    # A diagram adat munkalapjának lekérése
    fact = chart.chart_data.chart_data_workbook

    # Demo sorozat törlése
    chart.chart_data.series.clear()

    # Új sorozat hozzáadása
    chart.chart_data.series.add(fact.get_cell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.type)
            
    # Kép beállítása
    image1 = draw.Bitmap(path + "aspose-logo.jpg")
    imgx1 = presentation.images.add_image(image1)

    # Kép beállítása
    image2 = draw.Bitmap(path + "Tulips.jpg")
    imgx2 = presentation.images.add_image(image2)

    # Az első diagram sorozatának kiválasztása
    series = chart.chart_data.series[0]

    # Új pont (1:3) hozzáadása oda.
    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 1, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 2, 1, 2.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 3, 1, 3.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx1

    point = series.data_points.add_data_point_for_line_series(fact.get_cell(defaultWorksheetIndex, 4, 1, 4.5))
    point.marker.format.fill.fill_type = slides.FillType.PICTURE
    point.marker.format.fill.picture_fill_format.picture.image = imgx2

    # A diagram sorozat jelölőjének módosítása
    series.marker.size = 15

    # A prezentáció mentése a lemezre
    presentation.save("MarkOptions_out.pptx", slides.export.SaveFormat.PPTX)
```

## **GYIK**

**Milyen jelölőformák állnak rendelkezésre alapértelmezetten?**

A standard formák elérhetők (kör, négyzet, rombusz, háromszög stb.); a lista a [MarkerStyleType](https://reference.aspose.com/slides/hu/python-net/aspose.slides.charts/markerstyletype/) felsorolásban van definiálva. Ha nem szabványos formára van szüksége, használjon kékkel kitöltött jelölőt a saját vizuális elemek szimulálásához.

**Megmaradnak a jelölők, amikor a diagramot képre vagy SVG-re exportálják?**

Igen. Amikor a diagramokat [raszteres formátumokra](/slides/hu/python-net/convert-powerpoint-to-png/) rendereli, vagy a [alakzatokat SVG-ként](/slides/hu/python-net/render-a-slide-as-an-svg-image/) menti, a jelölők megtartják megjelenésüket és beállításaikat, beleértve a méretet, a kitöltést és a körvonalat.