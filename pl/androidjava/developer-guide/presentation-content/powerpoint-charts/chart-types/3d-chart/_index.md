---
title: Dostosuj wykresy 3D w prezentacjach na Androidzie
linktitle: Wykres 3D
type: docs
url: /pl/androidjava/3d-chart/
keywords:
- wykres 3D
- obrót
- głębokość
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy 3-D w Aspose.Slides dla Androida przy użyciu Javy, obsługując pliki PPT i PPTX — zwiększ jakość swoich prezentacji już dziś."
---
## **Overview**

Ten artykuł wyjaśnia, jak dostosować wykres 3D w Aspose.Slides, konfigurując ustawienia `Rotation3D`, takie jak `RotationX`, `RotationY`, `DepthPercents` i `RightAngleAxes`. Przeprowadza przez tworzenie prezentacji, dodawanie wykresu 3D z domyślnymi danymi, zastosowanie wymaganych ustawień widoku 3D oraz zapis zmodyfikowanej prezentacji jako plik PPTX.

## **Set RotationX, RotationY and DepthPercents Properties of a 3D Chart**
Aspose.Slides for Android via Java udostępnia prosty interfejs API do ustawiania tych właściwości. Poniższy artykuł pomoże Ci ustawić różne właściwości, takie jak **X,Y Rotation, DepthPercents** itp. Przykładowy kod pokazuje, jak zastosować wymienione wyżej właściwości.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation/).
2. Uzyskaj dostęp do pierwszego slajdu.
3. Dodaj wykres z domyślnymi danymi.
4. Ustaw właściwości Rotation3D.
5. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```java
Presentation pres = new Presentation();
try {
    // Uzyskaj dostęp do pierwszego slajdu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Dodaj wykres z domyślnymi danymi
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);
    
    // Ustawienie indeksu arkusza danych wykresu
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
    
    // Teraz wypełniamy dane serii
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Ustaw wartość Overlap
    series.getParentSeriesGroup().setOverlap((byte)100);
    
    // Zapisz prezentację na dysku
    pres.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Which chart types support 3D mode in Aspose.Slides?**

Aspose.Slides obsługuje warianty 3D wykresów kolumnowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D oraz 100% Stacked Column 3D, a także powiązane typy 3D dostępne poprzez klasę [ChartType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/charttype/). Aby uzyskać dokładną, aktualną listę, sprawdź członków [ChartType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/charttype/) w dokumentacji API swojej zainstalowanej wersji.

**Can I get a raster image of a 3D chart for a report or the web?**

Tak. Możesz wyeksportować wykres do obrazu za pomocą [chart API](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) lub [render the entire slide](/slides/pl/androidjava/convert-powerpoint-to-png/) do formatów takich jak PNG lub JPEG. Jest to przydatne, gdy potrzebujesz podglądu piksel po pikselu lub chcesz osadzić wykres w dokumentach, pulpitach nawigacyjnych lub stronach internetowych bez konieczności posiadania PowerPointa.

**How performant is building and rendering large 3D charts?**

Wydajność zależy od wielkości danych i złożoności wizualnej. Aby uzyskać najlepsze wyniki, zachowaj efekty 3D na minimalnym poziomie, unikaj ciężkich tekstur na ścianach i obszarach wykresu, ogranicz liczbę punktów danych na serię, gdy to możliwe, oraz renderuj do odpowiednio dobranego rozmiaru wyjścia (rozdzielczość i wymiary), aby dopasować się do docelowego wyświetlacza lub wymagań drukowania.