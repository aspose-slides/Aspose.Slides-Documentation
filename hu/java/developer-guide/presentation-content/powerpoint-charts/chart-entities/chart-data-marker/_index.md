---
title: Diagram adatjelölők kezelése bemutatókban Java használatával
linktitle: Adatjelölő
type: docs
url: /hu/java/chart-data-marker/
keywords:
- diagram
- adatpont
- jelölő
- jelölő beállítások
- jelölő méret
- kitöltés típusa
- PowerPoint
- bemutató
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan lehet testreszabni a diagram adatjelölőket az Aspose.Slides for Java-ban, növelve a bemutatók hatását a PPT és PPTX formátumokban, világos Java kódrészletekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet dolgozni diagram adatjelölőkkel az Aspose.Slides-ban. Megmutatja, hogyan hozhatunk létre diagramot, érhetünk el egy sorozatot és annak adatpontjait, alkalmazhatunk képtöltést a jelölőkre adatpont szinten, állíthatjuk a jelölő méretét, és menthetjük a frissített bemutatót. Emellett megjegyzi, hogy a szabványos jelölőformák a `MarkerStyleType` felsorolásban érhetők el, és a jelölő megjelenése megmarad, amikor a diagramot raszteres formátumokra vagy SVG-re exportáljuk.

## **Diagram jelölő beállításainak megadása**
Az egyes sorozatokon belüli diagram adatpontokra beállíthatók a jelölők. A diagram jelölő beállításainak megadásához kövesse az alábbi lépéseket:

- Példányosítsa a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályt.
- Alapértelmezett diagram létrehozása.
- Állítsa be a képet.
- Vegye az első diagram sorozatot.
- Adjon hozzá új adatpontot.
- Mentse a bemutatót lemezre.

Az alább bemutatott példában a diagram jelölő beállításait adatpontos szinten állítottuk be.

```java
// Üres bemutató létrehozása
Presentation pres = new Presentation();
try {
    // Első diát elérése
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Alapértelmezett diagram létrehozása
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Az alapértelmezett diagramadat munkalap indexének lekérése
    int defaultWorksheetIndex = 0;
    
    // Diagramadat munkalap lekérése
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Demó sorozat törlése
    chart.getChartData().getSeries().clear();
    
    // Új sorozat hozzáadása
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // 1. kép betöltése
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // 2. kép betöltése
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Az első diagram sorozat kiválasztása
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Új pont hozzáadása (1:3) ott.
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
    
    // Bemutató mentése diagrammal
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Mely jelölőformák érhetők el alapértelmezésként?**

A szabványos formák elérhetők (kör, négyzet, rombusz, háromszög stb.); a lista a [MarkerStyleType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/markerstyletype/) osztályban van meghatározva. Ha nem szabványos formára van szüksége, használjon képtöltéssel rendelkező jelölőt az egyedi megjelenés szimulálásához.

**Megmaradnak a jelölők, amikor diagramot képként vagy SVG-ként exportáljuk?**

Igen. Amikor a diagramokat [raszteres formátumokra](/slides/hu/java/convert-powerpoint-to-png/) rendereljük, vagy [alakzatokat SVG-ként](/slides/hu/java/render-a-slide-as-an-svg-image/) mentjük, a jelölők megtartják megjelenésüket és beállításaikat, beleértve a méretet, a kitöltést és a körvonalat.