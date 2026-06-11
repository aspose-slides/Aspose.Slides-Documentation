---
title: Dostosowywanie wykresów pierścieniowych w prezentacjach na Androidzie
linktitle: Wykres pierścieniowy
type: docs
weight: 30
url: /pl/androidjava/doughnut-chart/
keywords:
- wykres pierścieniowy
- otwór centralny
- rozmiar otworu
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Poznaj sposoby tworzenia i dostosowywania wykresów pierścieniowych w Aspose.Slides for Android via Java, obsługujących formaty PowerPoint dla dynamicznych prezentacji."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z wykresem pierścieniowym w Aspose.Slides, dodając wykres do slajdu, ustawiając rozmiar otworu w jego środku oraz zapisując prezentację. Skupia się na metodzie `setDoughnutHoleSize` i demonstruje podstawowe kroki niezbędne do dostosowania tego typu wykresu w kodzie.

Zawiera również krótkie FAQ obejmujące powiązane scenariusze wykresów pierścieniowych, takie jak użycie wielu serii do stworzenia wielu pierścieni, praca z wykresami pierścieniowymi z eksplozją oraz eksport wykresu jako obrazu rastrowego lub SVG.

## **Określenie otworu centralnego w wykresie pierścieniowym**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java obsługuje teraz określanie rozmiaru otworu w wykresie pierścieniowym. W tym temacie zobaczymy na przykładzie, jak określić rozmiar otworu w wykresie pierścieniowym.

{{% /alert %}} 

Aby określić rozmiar otworu w wykresie pierścieniowym, wykonaj poniższe kroki:

1. Utwórz obiekt [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
1. Dodaj wykres pierścieniowy na slajdzie.
1. Określ rozmiar otworu w wykresie pierścieniowym.
1. Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy rozmiar otworu w wykresie pierścieniowym.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400);
    
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize((byte)90);

    // Zapisz prezentację na dysku
    pres.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę utworzyć wielopoziomowy wykres pierścieniowy z wieloma pierścieniami?**

Tak. Dodaj wiele serii do jednego wykresu pierścieniowego — każda seria staje się osobnym pierścieniem. Kolejność pierścieni jest określana kolejnością serii w kolekcji.

**Czy obsługiwany jest „eksplodowany” wykres pierścieniowy (oddzielone części)?**

Tak. Istnieje typ wykresu Exploded Doughnut [chart type](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/charttype/) oraz właściwość eksplozji dla punktów danych; możesz oddzielić poszczególne części.

**Jak mogę uzyskać obraz wykresu pierścieniowego (PNG/SVG) do raportu?**

Wykres jest obiektem shape; możesz wyrenderować go jako [obraz rastrowy](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) lub wyeksportować wykres do [obrazu SVG](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-).