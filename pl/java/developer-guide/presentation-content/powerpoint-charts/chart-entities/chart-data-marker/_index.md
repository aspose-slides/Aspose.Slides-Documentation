---
title: Zarządzaj znacznikami danych wykresu w prezentacjach przy użyciu Java
linktitle: Znacznik danych
type: docs
url: /pl/java/chart-data-marker/
keywords:
- wykres
- punkt danych
- znacznik
- opcje znacznika
- rozmiar znacznika
- typ wypełnienia
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak dostosować znaczniki danych wykresu w Aspose.Slides dla Javy, zwiększając wpływ prezentacji w formatach PPT i PPTX dzięki przejrzystym przykładom kodu Java."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować ze znacznikami danych wykresu w Aspose.Slides. Pokazuje, jak utworzyć wykres, uzyskać dostęp do serii i jej punktów danych, zastosować wypełnienie obrazem do znaczników na poziomie punktu danych, dostosować rozmiar znacznika oraz zapisać zaktualizowaną prezentację. Zauważa również, że standardowe kształty znaczników są dostępne przez wyliczenie `MarkerStyleType` oraz że wygląd znacznika jest zachowywany przy eksportowaniu wykresów do formatów rastrowych lub SVG.

## **Ustaw opcje znaczników wykresu**
Markery mogą być ustawiane na punktach danych wykresu w określonych seriach. Aby ustawić opcje znaczników wykresu, postępuj zgodnie z poniższymi krokami:

- Zainstancjuj klasę [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
- Utwórz domyślny wykres.
- Ustaw obraz.
- Pobierz pierwszą serię wykresu.
- Dodaj nowy punkt danych.
- Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy opcje znaczników wykresu na poziomie punktów danych.

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
    
    // Usuwanie serii demonstracyjnej
    chart.getChartData().getSeries().clear();
    
    // Dodawanie nowej serii
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());

    // Wczytywanie obrazu 1
    IPPImage imgx1 = pres.getImages().addImage(new FileInputStream(new File("Desert.jpg")));
    
    // Wczytywanie obrazu 2
    IPPImage imgx2 = pres.getImages().addImage(new FileInputStream(new File("Tulips.jpg")));
    
    // Pobranie pierwszej serii wykresu
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    
    // Dodanie nowego punktu (1:3) w tym miejscu.
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
    
    // Zapisanie prezentacji z wykresem
    pres.save("ScatterChart.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Jakie kształty znaczników są dostępne od razu?**

Standardowe kształty są dostępne (koło, kwadrat, romb, trójkąt itp.); lista jest zdefiniowana przez klasę [MarkerStyleType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/markerstyletype/). Jeśli potrzebujesz niestandardowego kształtu, użyj znacznika z wypełnieniem obrazem, aby emulować własną grafikę.

**Czy znaczniki są zachowywane przy eksportowaniu wykresu do obrazu lub SVG?**

Tak. Podczas renderowania wykresów do [formatów rastrowych](/slides/pl/java/convert-powerpoint-to-png/) lub zapisywania [kształtów jako SVG](/slides/pl/java/render-a-slide-as-an-svg-image/), znaczniki zachowują swój wygląd i ustawienia, w tym rozmiar, wypełnienie i obramowanie.