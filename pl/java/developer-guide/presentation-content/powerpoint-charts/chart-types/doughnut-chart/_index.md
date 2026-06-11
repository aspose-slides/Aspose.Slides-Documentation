---
title: Dostosowywanie wykresów pierścieniowych w prezentacjach przy użyciu języka Java
linktitle: Wykres pierścieniowy
type: docs
weight: 30
url: /pl/java/doughnut-chart/
keywords:
- wykres pierścieniowy
- przerwa w centrum
- rozmiar otworu
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Poznaj sposób tworzenia i dostosowywania wykresów pierścieniowych w Aspose.Slides dla języka Java, obsługujących formaty PowerPoint dla dynamicznych prezentacji."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z wykresem pierścieniowym w Aspose.Slides, dodając wykres do slajdu, ustawiając rozmiar centralnej dziury oraz zapisując prezentację. Skupia się na metodzie `setDoughnutHoleSize` i demonstruje podstawowe kroki niezbędne do dostosowania tego typu wykresu w kodzie.

Zawiera także krótkie FAQ obejmujące powiązane scenariusze wykresów pierścieniowych, takie jak użycie wielu serii do utworzenia wielu pierścieni, praca z wykresami pierścieniowymi z wybuchniętymi segmentami oraz eksport wykresu jako obrazu rastrowego lub SVG.

## **Określenie przerwy w centrum wykresu pierścieniowego**
{{% alert color="primary" %}} 

Aspose.Slides for Java obsługuje teraz określanie rozmiaru otworu w wykresie pierścieniowym. W tym temacie, za pomocą przykładu, pokażemy, jak określić rozmiar otworu w wykresie pierścieniowym.

{{% /alert %}} 

Aby określić rozmiar otworu w wykresie pierścieniowym, wykonaj poniższe kroki:

1. Utwórz obiekt [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
2. Dodaj wykres pierścieniowy na slajdzie.
3. Określ rozmiar otworu w wykresie pierścieniowym.
4. Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy rozmiar otworu w wykresie pierścieniowym.

```java
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

**Czy mogę utworzyć wielopoziomowy wykres pierścieniowy z wieloma pierścieniami?**

Tak. Dodaj wiele serii do jednego wykresu pierścieniowego — każda seria staje się osobnym pierścieniem. Kolejność pierścieni jest określona kolejnością serii w kolekcji.

**Czy obsługiwany jest wykres pierścieniowy „wybuchnięty” (oddzielone sekcje)?**

Tak. Istnieje typ wykresu Exploded Doughnut [chart type](https://reference.aspose.com/slides/pl/java/com.aspose.slides/charttype/) oraz właściwość explosion na punktach danych; możesz oddzielić poszczególne sekcje.

**Jak mogę uzyskać obraz wykresu pierścieniowego (PNG/SVG) do raportu?**

Wykres jest kształtem; możesz go wyrenderować do [obrazu rastrowego](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#getImage-int-float-float-) lub wyeksportować wykres jako [obraz SVG](https://reference.aspose.com/slides/pl/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).