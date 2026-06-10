---
title: Ábrák adatjelzőinek kezelése prezentációkban JavaScript használatával
linktitle: Adatjelző
type: docs
url: /hu/nodejs-java/chart-data-marker/
keywords:
- diagram
- adatpont
- jelző
- jelző opciók
- jelző méret
- kitöltés típusa
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan testreszabhatja a diagram adatjelzőket az Aspose.Slides Node.js verziójában, növelve a prezentáció hatását a PPT és PPTX formátumokban, világos kódrészletekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kell a diagram adatjelzőkkel dolgozni az Aspose.Slides-ben. Megmutatja, hogyan hozhatunk létre diagramot, hogyan érhetünk el egy sorozatot és annak adatpontjait, hogyan alkalmazhatunk képes kitöltést a jelzőkre adatpont-szinten, hogyan állíthatjuk be a jelző méretét, és hogyan menthetjük a frissített prezentációt. Emellett megjegyzi, hogy a standard jelző alakzatok a `MarkerStyleType` felsorolásban érhetők el, és hogy a jelző megjelenése megmarad a diagramok raszteres formátumokba vagy SVG-be exportálásakor.

## **Diagram jelző beállítások megadása**

A jelzőket egy adott sorozat adatpontjain állíthatjuk be. A diagram jelző beállításához kövesse az alábbi lépéseket:

- Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation) osztályt.
- Az alapértelmezett diagram létrehozása.
- Állítsa be a képet.
- Vegye az első diagram sorozatot.
- Adjon hozzá új adatpontot.
- Mentse a prezentációt lemezre.

Az alább bemutatott példában a diagram jelző beállításait adatpont szinten állítottuk be.

```javascript
// Üres prezentáció létrehozása
var pres = new aspose.slides.Presentation();
try {
    // Az első dia elérése
    var slide = pres.getSlides().get_Item(0);
    // Az alapértelmezett diagram létrehozása
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // Az alapértelmezett diagram adat munkalap indexének lekérése
    var defaultWorksheetIndex = 0;
    // A diagram adat munkalapjának lekérése
    var fact = chart.getChartData().getChartDataWorkbook();
    // Demó sorozat törlése
    chart.getChartData().getSeries().clear();
    // Új sorozat hozzáadása
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // 1. kép betöltése
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // 2. kép betöltése
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // Az első diagram sorozat kivétele
    var series = chart.getChartData().getSeries().get_Item(0);
    // Új pont (1:3) hozzáadása
    var point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 2.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 3.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, 4.5));
    point.getMarker().getFormat().getFill().setFillType(aspose.slides.FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    // A diagram sorozat jelzőjének módosítása
    series.getMarker().setSize(15);
    // A prezentáció mentése diagrammal
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Mely jelző alakzatok érhetők el alapból?**

Az alapértelmezett alakzatok (kör, négyzet, rombusz, háromszög stb.) elérhetők; a lista a [MarkerStyleType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/markerstyletype/) felsorolásban van definiálva. Ha nem szabványos alakzatra van szüksége, használjon képes kitöltésű jelzőt, hogy testreszabott megjelenést szimuláljon.

**Megmaradnak a jelzők, ha egy diagramot képre vagy SVG-re exportálunk?**

Igen. A diagramok raszteres formátumokba ([raster formats](/slides/hu/nodejs-java/convert-powerpoint-to-png/)) történő renderelésekor vagy a [alakzatok SVG-ként mentése](/slides/hu/nodejs-java/render-a-slide-as-an-svg-image/) esetén a jelzők megőrzik megjelenésüket és beállításaikat, beleértve a méretet, a kitöltést és a körvonalat.