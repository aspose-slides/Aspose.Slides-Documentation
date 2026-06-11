---
title: Dostosowywanie wykresów pierścieniowych w prezentacjach przy użyciu C++
linktitle: Wykres pierścieniowy
type: docs
weight: 30
url: /pl/cpp/doughnut-chart/
keywords:
- wykres pierścieniowy
- przerwa w centrum
- rozmiar dziury
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy pierścieniowe w Aspose.Slides dla C++, obsługując formaty PowerPoint dla dynamicznych prezentacji."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z wykresem pierścieniowym w Aspose.Slides, dodając wykres do slajdu, ustawiając rozmiar centralnej dziury i zapisując prezentację. Skupia się na metodzie `set_DoughnutHoleSize` i demonstruje podstawowe kroki niezbędne do dostosowania tego typu wykresu w kodzie.

## **Określenie przerwy w centrum wykresu pierścieniowego**

Aby określić rozmiar dziury w wykresie pierścieniowym, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
- Dodaj wykres pierścieniowy na slajdzie.
- Określ rozmiar dziury w wykresie pierścieniowym.
- Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy rozmiar dziury w wykresie pierścieniowym.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-DoughnutChartHole-DoughnutChartHole.cpp" >}}

## **FAQ**

**Czy mogę stworzyć wielopoziomowy wykres pierścieniowy z wieloma pierścieniami?**

Tak. Dodaj wiele serii do jednego wykresu pierścieniowego — każda seria staje się osobnym pierścieniem. Kolejność pierścieni jest określana kolejnością serii w kolekcji.

**Czy obsługiwany jest „rozsadzany” wykres pierścieniowy (oddzielone kawałki)?**

Tak. Istnieje typ wykresu Exploded Doughnut [chart type](https://reference.aspose.com/slides/pl/cpp/aspose.slides.charts/charttype/) oraz właściwość explosion na punktach danych; możesz oddzielić poszczególne kawałki.

**Jak mogę uzyskać obraz wykresu pierścieniowego (PNG/SVG) do raportu?**

Wykres jest kształtem; możesz wyrenderować go do [obrazka rastrowego](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/getimage/) lub wyeksportować wykres jako [obraz SVG](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/writeassvg/).