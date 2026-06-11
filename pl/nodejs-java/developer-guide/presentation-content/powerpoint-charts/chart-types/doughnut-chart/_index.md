---
title: Personalizowanie wykresów pierścieniowych w prezentacjach przy użyciu JavaScript
linktitle: Wykres pierścieniowy
type: docs
weight: 30
url: /pl/nodejs-java/doughnut-chart/
keywords:
- wykres pierścieniowy
- luka centralna
- rozmiar otworu
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i personalizować wykresy pierścieniowe przy użyciu JavaScript i Aspose.Slides dla Node.js, obsługując formaty PowerPoint w dynamicznych prezentacjach."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z wykresem pierścieniowym w Aspose.Slides, dodając wykres do slajdu, ustawiając rozmiar jego centralnej dziury i zapisując prezentację. Skupia się na metodzie `setDoughnutHoleSize` i demonstruje podstawowe kroki niezbędne do dostosowania tego typu wykresu w kodzie.

Zawiera również krótkie FAQ obejmujące scenariusze związane z wykresem pierścieniowym, takie jak użycie wielu serii do stworzenia wielu pierścieni, praca z wykresem pierścieniowym wybuchniętym oraz eksport wykresu jako obrazu rastrowego lub SVG.

## **Zmienianie odstępu centralnego w wykresie pierścieniowym**

Aby określić rozmiar otworu w wykresie pierścieniowym, proszę postępować zgodnie z poniższymi krokami:

1. Zainicjalizuj obiekt [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
2. Dodaj wykres pierścieniowy na slajdzie.
3. Określ rozmiar otworu w wykresie pierścieniowym.
4. Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy rozmiar otworu w wykresie pierścieniowym.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Doughnut, 50, 50, 400, 400);
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(90);
    // Zapisz prezentację na dysku
    pres.save("DoughnutHoleSize_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę utworzyć wielopoziomowy wykres pierścieniowy z wieloma pierścieniami?**

Tak. Dodaj wiele serii do jednego wykresu pierścieniowego — każda seria staje się osobnym pierścieniem. Kolejność pierścieni jest określana przez kolejność serii w kolekcji.

**Czy obsługiwany jest „wybuchnięty” wykres pierścieniowy (oddzielone wycinki)?**

Tak. Istnieje typ wykresu Exploded Doughnut [chart type](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/charttype/) oraz właściwość eksplozji na punktach danych; możesz oddzielić poszczególne wycinki.

**Jak mogę uzyskać obraz wykresu pierścieniowego (PNG/SVG) do raportu?**

Wykres jest kształtem; możesz wyrenderować go jako [obraz rastrowy](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getImage) lub wyeksportować wykres do [obraz SVG](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/writeassvg/).