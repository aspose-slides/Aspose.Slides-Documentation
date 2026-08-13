---
title: Dostosowywanie wykresów pierścieniowych w prezentacjach przy użyciu Java
linktitle: Wykres pierścieniowy
type: docs
weight: 30
url: /pl/java/doughnut-chart/
keywords:
- wykres pierścieniowy
- przerwa centralna
- rozmiar otworu
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Odkryj, jak tworzyć i dostosowywać wykresy pierścieniowe w Aspose.Slides for Java, obsługujące formaty PowerPoint dla dynamicznych prezentacji."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z wykresem pierścieniowym w Aspose.Slides, dodając wykres do slajdu, ustawiając rozmiar jego centralnego otworu oraz zapisując prezentację. Skupia się na metodzie `setDoughnutHoleSize` i demonstruje podstawowe kroki niezbędne do dostosowania tego typu wykresu w kodzie.

Zawiera także krótkie FAQ dotyczące scenariuszy związanych z wykresami pierścieniowymi, takich jak użycie wielu serii do utworzenia wielu pierścieni, praca z eksplodowanymi wykresami pierścieniowymi oraz eksport wykresu jako obrazu rastrowego lub SVG.

## **Określenie centralnej przerwy w wykresie pierścieniowym**
{{% alert color="info" %}} 

Aspose.Slides for Java obsługuje teraz określanie rozmiaru otworu w wykresie pierścieniowym. W tym temacie pokażemy na przykładzie, jak ustawić rozmiar otworu w wykresie pierścieniowym.

{{% /alert %}} 

Aby określić rozmiar otworu w wykresie pierścieniowym, wykonaj następujące kroki:

1. Utwórz obiekt [Prezentacja](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
1. Dodaj wykres pierścieniowy na slajdzie.
1. Określ rozmiar otworu w wykresie pierścieniowym.
1. Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy rozmiar otworu w wykresie pierścieniowym.

```java
import com.aspose.slides.*;

// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Zapisz prezentację na dysk
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Czy mogę utworzyć wielopoziomowy wykres pierścieniowy z wieloma pierścieniami?

Tak. Dodaj wiele serii do jednego wykresu pierścieniowego — każda seria staje się osobnym pierścieniem. Kolejność pierścieni jest określana kolejnością serii w kolekcji.

### Czy obsługiwany jest „eksplodowany” wykres pierścieniowy (oddzielone segmenty)?

Tak. Istnieje typ wykresu [Exploded Doughnut](https://reference.aspose.com/slides/pl/java/com.aspose.slides/charttype/) oraz własność eksplozji dla punktów danych; możesz oddzielić poszczególne segmenty.

### Jak uzyskać obraz wykresu pierścieniowego (PNG/SVG) do raportu?

Wykres jest kształtem; możesz go renderować do [obrazu rastrowego](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getImage-int-float-float-) lub wyeksportować wykres jako [obraz SVG](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).