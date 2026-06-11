---
title: Dostosowywanie wykresów 3D w prezentacjach przy użyciu Java
linktitle: Wykres 3D
type: docs
url: /pl/java/3d-chart/
keywords:
- wykres 3D
- obrót
- głębokość
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy 3D w Aspose.Slides dla Java, obsługując pliki PPT i PPTX - podnieś jakość swoich prezentacji już dziś."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować wykres 3D w Aspose.Slides, konfigurując ustawienia `Rotation3D`, takie jak `RotationX`, `RotationY`, `DepthPercents` i `RightAngleAxes`. Przedstawia proces tworzenia prezentacji, dodawania wykresu 3D z domyślnymi danymi, stosowania wymaganych ustawień widoku 3D oraz zapisywania zmodyfikowanej prezentacji jako plik PPTX.

## **Ustaw właściwości RotationX, RotationY i DepthPercents wykresu 3D**
Aspose.Slides for Java udostępnia prosty interfejs API do ustawiania tych właściwości. Ten artykuł pomoże Ci ustawić różne właściwości, takie jak **X,Y Rotation, DepthPercents** itp. Przykładowy kod stosuje ustawienia wymienionych powyżej właściwości.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z domyślnymi danymi.
4. Ustaw właściwości Rotation3D.
5. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```java
Presentation pres = new Presentation();
try {
    // Uzyskaj dostęp do pierwszego slajdu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Dodaj wykres z danymi domyślnymi
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Ustawianie indeksu arkusza danych wykresu
    int defaultWorksheetIndex = 0;
    
    // Pobieranie arkusza danych wykresu
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Dodaj serie
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Dodaj kategorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Ustaw właściwości Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte)40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    
    // Pobierz drugą serię wykresu
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Teraz uzupełnianie danych serii
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Ustaw wartość OverLap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Zapisz prezentację na dysku
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Jakie typy wykresów obsługują tryb 3D w Aspose.Slides?**

Aspose.Slides obsługuje warianty 3D wykresów kolumnowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D i 100% Stacked Column 3D, a także powiązane typy 3D udostępniane przez klasę [ChartType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/charttype/). Aby uzyskać dokładną, aktualną listę, sprawdź członków [ChartType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/charttype/) w dokumentacji API swojej zainstalowanej wersji.

**Czy mogę uzyskać rastrowy obraz wykresu 3D do raportu lub sieci?**

Tak. Możesz wyeksportować wykres do obrazu za pomocą [chart API](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getImage-int-float-float-) lub [renderować cały slajd](/slides/pl/java/convert-powerpoint-to-png/) do formatów takich jak PNG lub JPEG. Jest to przydatne, gdy potrzebujesz podglądu pixel-perfect lub chcesz osadzić wykres w dokumentach, pulpitach nawigacyjnych lub stronach internetowych bez konieczności używania PowerPointa.

**Jak wydajna jest budowa i renderowanie dużych wykresów 3D?**

Wydajność zależy od ilości danych i złożoności wizualnej. Aby uzyskać najlepsze rezultaty, ogranicz efekty 3D do minimum, unikaj ciężkich tekstur na ścianach i obszarach wykresu, ogranicz liczbę punktów danych w serii, gdy to możliwe, oraz renderuj do odpowiednio dobranego rozmiaru wyjścia (rozdzielczość i wymiary), aby dopasować je do docelowego wyświetlacza lub wymagań druku.