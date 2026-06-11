---
title: Dostosuj wykresy 3D w prezentacjach za pomocą JavaScript
linktitle: Wykres 3D
type: docs
url: /pl/nodejs-java/3d-chart/
keywords:
- wykres 3D
- obrót
- głębokość
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy 3-D w Aspose.Slides dla Node.js za pośrednictwem Java, z obsługą plików PPT i PPTX — zwiększ jakość swoich prezentacji już dziś."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak dostosować wykres 3D w Aspose.Slides poprzez konfigurację ustawień `Rotation3D`, takich jak `RotationX`, `RotationY`, `DepthPercents` i `RightAngleAxes`. Przejmuje proces tworzenia prezentacji, dodawania wykresu 3D z domyślnymi danymi, zastosowania wymaganych ustawień widoku 3D oraz zapisania zmodyfikowanej prezentacji jako pliku PPTX.

## **Ustaw właściwości RotationX, RotationY i DepthPercents wykresu 3D**

Aspose.Slides for Node.js via Java udostępnia prosty interfejs API do ustawiania tych właściwości. Poniższy artykuł pomoże Ci ustawić różne właściwości, takie jak **X,Y Rotation, DepthPercents** itp. Przykładowy kod stosuje ustawienia wymienionych powyżej właściwości.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/).
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj wykres z domyślnymi danymi.
1. Ustaw właściwości Rotation3D.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Uzyskaj dostęp do pierwszego slajdu
    var slide = pres.getSlides().get_Item(0);
    // Dodaj wykres z domyślnymi danymi
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn3D, 0, 0, 500, 500);
    // Ustawianie indeksu arkusza danych wykresu
    var defaultWorksheetIndex = 0;
    // Pobieranie arkusza danych wykresu
    var fact = chart.getChartData().getChartDataWorkbook();
    // Dodaj serię
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Dodaj kategorie
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Ustaw właściwości Rotation3D
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);
    // Pobierz drugą serię wykresu
    var series = chart.getChartData().getSeries().get_Item(1);
    // Teraz wypełniamy dane serii
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Ustaw wartość OverLap
    series.getParentSeriesGroup().setOverlap(100);
    // Zapisz prezentację na dysk
    pres.save("Rotation3D_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Jakie typy wykresów obsługują tryb 3D w Aspose.Slides?**

Aspose.Slides obsługuje trójwymiarowe warianty wykresów słupkowych, w tym Column 3D, Clustered Column 3D, Stacked Column 3D i 100% Stacked Column 3D, wraz z powiązanymi typami 3D udostępnianymi przez wyliczenie [ChartType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/charttype/). Aby uzyskać dokładną, aktualną listę, sprawdź członków [ChartType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/charttype/) w dokumentacji API zainstalowanej wersji.

**Czy mogę uzyskać rastrowy obraz wykresu 3D do raportu lub strony internetowej?**

Tak. Możesz wyeksportować wykres do obrazu za pomocą [API wykresu](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getImage) lub [wykonać renderowanie całego slajdu](/slides/pl/nodejs-java/convert-powerpoint-to-png/) do formatów takich jak PNG lub JPEG. Jest to przydatne, gdy potrzebny jest podgląd pixel-perfect lub chcesz osadzić wykres w dokumentach, pulpitach nawigacyjnych lub stronach internetowych bez konieczności używania PowerPointa.

**Jak wydajne jest budowanie i renderowanie dużych wykresów 3D?**

Wydajność zależy od ilości danych i złożoności wizualnej. Aby uzyskać najlepsze wyniki, zachowaj minimalne efekty 3D, unikaj ciężkich tekstur na ścianach i obszarach wykresu, ogranicz liczbę punktów danych na serię, gdy to możliwe, oraz renderuj do odpowiednio dobranej rozdzielczości i wymiarów, aby dopasować się do docelowego wyświetlacza lub wymagań druku.