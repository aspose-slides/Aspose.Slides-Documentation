---
title: Zarządzanie znacznikami danych wykresu w prezentacjach na Androidzie
linktitle: Znacznik danych
type: docs
url: /pl/androidjava/chart-data-marker/
keywords:
- wykres
- punkt danych
- znacznik
- opcje znacznika
- rozmiar znacznika
- typ wypełnienia
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dostosuj znaczniki danych wykresu w Aspose.Slides dla Androida, zwiększając efekt prezentacji w formatach PPT i PPTX dzięki przejrzystym przykładom kodu Java."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować ze znacznikami danych wykresu w Aspose.Slides. Pokazuje, jak utworzyć wykres, uzyskać dostęp do serii i jej punktów danych, zastosować wypełnienia obrazem do znaczników na poziomie punktu danych, dostosować rozmiar znacznika oraz zapisać zaktualizowaną prezentację. Zauważa również, że standardowe kształty znaczników są dostępne poprzez wyliczenie `MarkerStyleType`, a wygląd znacznika jest zachowywany przy eksportowaniu wykresów do formatów rastrowych lub SVG.

## **Ustaw opcje markerów wykresu**
Markery można ustawiać na punktach danych wykresu w określonych seriach. Aby ustawić opcje markerów wykresu, wykonaj następujące kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
- Utwórz domyślny wykres.
- Ustaw obraz.
- Pobierz pierwszą serię wykresu.
- Dodaj nowy punkt danych.
- Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy opcje markerów wykresu na poziomie punktów danych.

```java
// Tworzenie pustej prezentacji
Presentation pres = new Presentation();
try {
    // Dostęp do pierwszego slajdu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Tworzenie domyślnego wykresu
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400);
    
    // Pobieranie indeksu domyślnego arkusza danych wykresu
    int defaultWorksheetIndex = 0;
    
    // Pobieranie arkusza danych wykresu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Usuń serię demonstracyjną
    chart.getChartData().getSeries().clear();
    
    // Dodaj nową serię
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Wczytaj obraz 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Wczytaj obraz 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Pobierz pierwszą serię wykresu
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Dodaj nowy punkt (1:3) tam.
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
    
    // Zmiana znacznika serii wykresu
    series.getMarker().setSize(15);
    
    // Zapisz prezentację z wykresem
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Jakie kształty markerów są dostępne od razu?**

Standardowe kształty są dostępne (koło, kwadrat, romb, trójkąt itp.); lista jest zdefiniowana w klasie [MarkerStyleType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/markerstyletype/). Jeśli potrzebujesz niestandardowego kształtu, użyj znacznika z wypełnieniem obrazem, aby emulować własne elementy wizualne.

**Czy markery są zachowywane przy eksportowaniu wykresu do obrazu lub SVG?**

Tak. Podczas renderowania wykresów do [raster formats](/slides/pl/androidjava/convert-powerpoint-to-png/) lub zapisywania [shapes as SVG](/slides/pl/androidjava/render-a-slide-as-an-svg-image/), markery zachowują swój wygląd i ustawienia, w tym rozmiar, wypełnienie i kontur.