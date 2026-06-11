---
title: Dostosowywanie wykresów pierścieniowych w prezentacjach w .NET
linktitle: Wykres pierścieniowy
type: docs
weight: 30
url: /pl/net/doughnut-chart/
keywords:
- wykres pierścieniowy
- odstęp centralny
- rozmiar dziury
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy pierścieniowe w Aspose.Slides dla .NET, obsługując formaty PowerPoint dla dynamicznych prezentacji."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z wykresem pierścieniowym w Aspose.Slides, dodając wykres do slajdu, ustawiając rozmiar jego centralnej dziury oraz zapisując prezentację. Skupia się na ustawieniu `DoughnutHoleSize` i demonstruje podstawowe kroki niezbędne do dostosowania tego typu wykresu w kodzie.

Zawiera również krótkie FAQ obejmujące powiązane scenariusze wykresów pierścieniowych, takie jak użycie wielu serii do tworzenia wielu pierścieni, pracę z wykresami pierścieniowymi z eksplozją oraz eksportowanie wykresu jako obrazu rastrowego lub SVG.

## **Określenie odstępu centralnego w wykresie pierścieniowym**
Aby określić rozmiar dziury w wykresie pierścieniowym, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
- Dodaj wykres pierścieniowy do slajdu.
- Określ rozmiar dziury w wykresie pierścieniowym.
- Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy rozmiar dziury w wykresie pierścieniowym.

```c#
 // Utwórz instancję klasy Presentation
 Presentation presentation = new Presentation();

 IChart chart = presentation.Slides[0].Shapes.AddChart(ChartType.Doughnut, 50, 50, 400, 400);
 chart.ChartData.SeriesGroups[0].DoughnutHoleSize = 90;

 // Zapisz prezentację na dysk
 presentation.Save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Czy mogę utworzyć wielopoziomowy wykres pierścieniowy z wieloma pierścieniami?**

Tak. Dodaj wiele serii do jednego wykresu pierścieniowego — każda seria staje się osobnym pierścieniem. Kolejność pierścieni jest określana kolejnością serii w kolekcji.

**Czy obsługiwany jest „wybuchający” wykres pierścieniowy (oddzielone części)?**

Tak. Istnieje typ wykresu Exploded Doughnut [chart type](https://reference.aspose.com/slides/pl/net/aspose.slides.charts/charttype/) oraz właściwość eksplozji dla punktów danych; możesz oddzielić poszczególne części.

**Jak uzyskać obraz wykresu pierścieniowego (PNG/SVG) do raportu?**

Wykres jest kształtem; możesz go wyrenderować jako [obraz rastrowy](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/getimage/) lub wyeksportować wykres do [obrazu SVG](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/writeassvg/).