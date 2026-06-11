---
title: Zarządzanie znacznikami danych wykresu w prezentacjach przy użyciu JavaScript
linktitle: Znacznik danych
type: docs
url: /pl/nodejs-java/chart-data-marker/
keywords:
- wykres
- punkt danych
- znacznik
- opcje znacznika
- rozmiar znacznika
- typ wypełnienia
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak dostosować znaczniki danych wykresu w Aspose.Slides dla Node.js, zwiększając wpływ prezentacji w formatach PPT i PPTX dzięki przejrzystym przykładom kodu."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować ze znacznikami danych wykresu w Aspose.Slides. Pokazuje, jak utworzyć wykres, uzyskać dostęp do serii i jej punktów danych, zastosować wypełnienia obrazem do znaczników na poziomie punktu danych, dostosować rozmiar znacznika i zapisać zaktualizowaną prezentację. Zawiera również informację, że standardowe kształty znaczników są dostępne poprzez wyliczenie `MarkerStyleType` oraz że wygląd znacznika jest zachowywany przy eksportowaniu wykresów do formatów rastrowych lub SVG.

## **Ustaw opcje znaczników wykresu**

Znaczniki można ustawić na punktach danych wykresu w określonych seriach. Aby ustawić opcje znaczników wykresu, proszę wykonać poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
- Utwórz domyślny wykres.
- Ustaw obraz.
- Weź pierwszą serię wykresu.
- Dodaj nowy punkt danych.
- Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy opcje znaczników wykresu na poziomie punktów danych.

```javascript
// Tworzenie pustej prezentacji
var pres = new aspose.slides.Presentation();
try {
    // Dostęp do pierwszego slajdu
    var slide = pres.getSlides().get_Item(0);
    // Tworzenie domyślnego wykresu
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 0, 0, 400, 400);
    // Pobieranie domyślnego indeksu arkusza danych wykresu
    var defaultWorksheetIndex = 0;
    // Pobieranie arkusza danych wykresu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Usunięcie serii demonstracyjnej
    chart.getChartData().getSeries().clear();
    // Dodanie nowej serii
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 1, 1, "Series 1"), chart.getType());
    // Załadowanie obrazu 1
    var imgx1 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Desert.jpg")));
    // Załadowanie obrazu 2
    var imgx2 = pres.getImages().addImage(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "Tulips.jpg")));
    // Pobranie pierwszej serii wykresu
    var series = chart.getChartData().getSeries().get_Item(0);
    // Dodanie nowego punktu (1:3) tam.
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
    // Zmiana znacznika serii wykresu
    series.getMarker().setSize(15);
    // Zapisanie prezentacji z wykresem
    pres.save("ScatterChart.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Jakie kształty znaczników są dostępne od razu?**

Standardowe kształty są dostępne (koło, kwadrat, romb, trójkąt itd.); lista jest zdefiniowana przez wyliczenie [MarkerStyleType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/markerstyletype/). Jeśli potrzebujesz niestandardowego kształtu, użyj znacznika z wypełnieniem obrazem, aby symulować własne elementy wizualne.

**Czy znaczniki są zachowywane przy eksportowaniu wykresu do obrazu lub SVG?**

Tak. Podczas renderowania wykresów do [raster formats](/slides/pl/nodejs-java/convert-powerpoint-to-png/) lub zapisywania [shapes as SVG](/slides/pl/nodejs-java/render-a-slide-as-an-svg-image/), znaczniki zachowują swój wygląd i ustawienia, w tym rozmiar, wypełnienie i obrys.