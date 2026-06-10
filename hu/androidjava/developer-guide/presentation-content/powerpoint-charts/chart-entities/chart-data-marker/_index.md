---
title: Diagram adatjelölők kezelése prezentációkban Androidon
linktitle: Adatjelölő
type: docs
url: /hu/androidjava/chart-data-marker/
keywords:
- diagram
- adatpont
- jelölő
- jelölő beállítások
- jelölő méret
- kitöltés típusa
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Testreszabja a diagram adatjelölőket az Aspose.Slides for Android-ban, növelve a prezentáció hatását PPT és PPTX formátumokban, világos Java kódrészletekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kell dolgozni diagram adatjelölőkkel az Aspose.Slides-ban. Megmutatja, hogyan hozhatunk létre diagramot, hogyan érhetjük el egy sorozatot és annak adatpontjait, hogyan alkalmazhatunk képes kitöltést a jelölőkre adatpont szinten, hogyan állíthatjuk be a jelölő méretét, és hogyan menthetjük el a frissített bemutatót. Emellett megjegyzi, hogy a szabványos jelölő alakzatok a `MarkerStyleType` felsorolásban érhetők el, és a jelölő megjelenése megmarad a diagramok raszteres formátumokba vagy SVG-be történő exportálásakor.

## **Diagram jelölő beállítások megadása**
A jelölőket a diagram adatpontjainak egy adott sorozatán belül lehet beállítani. A diagram jelölő beállítások megadásához kérjük, kövesse az alábbi lépéseket:

- Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályt.
- Hozzon létre egy alapértelmezett diagramot.
- Állítsa be a képet.
- Vegye az első diagram sorozatot.
- Adjon hozzá egy új adatpontot.
- Írja a bemutatót a lemezre.

Az alább bemutatott példában a diagram jelölő beállításait adatpont szinten állítottuk be.

```java
// Üres prezentáció létrehozása
Presentation pres = new Presentation();
try {
    // Első dia elérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Az alapértelmezett diagram létrehozása
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Az alapértelmezett diagram adat WorkSheet indexének lekérése
    int defaultWorksheetIndex = 0;
    
    // A diagram adat WorkSheet lekérése
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Demo sorozat törlése
    chart.getChartData().getSeries().clear();
    
    // Új sorozat hozzáadása
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // 1. kép betöltése
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // 2. kép betöltése
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Első diagram sorozat kivétele
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Új pont (1:3) hozzáadása ott.
    IChartDataPoint point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 1, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 2, 1, (double) 2.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 3, 1, (double) 3.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx1);
    
    point = series.getDataPoints().addDataPointForLineSeries(fact.getCell(defaultWorksheetIndex, 4, 1, (double) 4.5));
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture);
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(imgx2);
    
    // Diagram sorozat jelölőjének módosítása
    series.getMarker().setSize(15);
    
    // Prezentáció mentése diagrammal
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Milyen jelölő alakzatok érhetők el alapból?**

A szabványos alakzatok (kör, négyzet, rombusz, háromszög stb.) elérhetők; a lista a [MarkerStyleType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/markerstyletype/) osztályban van definiálva. Ha nem szabványos alakzatra van szüksége, használjon képes kitöltésű jelölőt a saját vizuális elemek megjelenítéséhez.

**Megmaradnak a jelölők, amikor egy diagramot képre vagy SVG-re exportálunk?**

Igen. Amikor diagramokat [raszteres formátumokba](/slides/hu/androidjava/convert-powerpoint-to-png/) renderelünk vagy [alakzatokat SVG-ként](/slides/hu/androidjava/render-a-slide-as-an-svg-image/) mentünk, a jelölők megtartják megjelenésüket és beállításaikat, beleértve a méretet, a kitöltést és a körvonalat.