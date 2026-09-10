---
title: Dostosowywanie wykresów pierścieniowych w prezentacjach przy użyciu Pythona poprzez Java
linktitle: Wykres pierścieniowy
type: docs
weight: 30
url: /pl/python-java/doughnut-chart/
keywords:
- wykres pierścieniowy
- przerwa środkowa
- rozmiar otworu
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać wykresy pierścieniowe w Aspose.Slides dla Pythona poprzez Java, obsługując formaty PowerPoint dla dynamicznych prezentacji."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z wykresem pierścieniowym w Aspose.Slides, dodając wykres do slajdu, ustawiając rozmiar centralnej dziury oraz zapisując prezentację. Skupia się na metodzie [setDoughnutHoleSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chartseriesgroup/#setDoughnutHoleSize) i demonstruje podstawowe kroki niezbędne do dostosowania tego typu wykresu w kodzie.

Zawiera także krótkie FAQ obejmujące powiązane scenariusze wykresów pierścieniowych, takie jak użycie wielu serii do tworzenia wielu pierścieni, praca z wykresami pierścieniowymi z wybuchniętymi segmentami oraz eksport wykresu jako obrazu rastrowego lub SVG.

## **Określenie centralnej dziury w wykresie pierścieniowym**

{{% alert color="info" title="Uwaga" %}}
Aspose.Slides for Python via Java obsługuje określanie rozmiaru dziury w wykresie pierścieniowym. Ten fragment pokazuje, jak określić rozmiar dziury przy użyciu przykładu.
{{% /alert %}}

Aby określić rozmiar dziury w wykresie pierścieniowym, wykonaj następujące kroki:

1. Utwórz obiekt [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Dodaj wykres pierścieniowy do slajdu.
3. Określ rozmiar dziury w wykresie pierścieniowym.
4. Zapisz prezentację na dysk.

Poniższy przykład ustawia rozmiar dziury w wykresie pierścieniowym.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Utwórz instancję klasy Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Doughnut, 50, 50, 400, 400)
    chart.getChartData().getSeriesGroups().get_Item(0).setDoughnutHoleSize(jpype.JByte(90))

    # Zapisz prezentację na dysku.
    presentation.save("DoughnutHoleSize_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę stworzyć wielopoziomowy wykres pierścieniowy z wieloma pierścieniami?**

Tak. Dodaj wiele serii do jednego wykresu pierścieniowego — każda seria staje się osobnym pierścieniem. Kolejność pierścieni jest określana przez kolejność serii w kolekcji.

**Czy obsługiwany jest wykres pierścieniowy „wybuchnięty” (oddzielone fragmenty)?**

Tak. Istnieje typ wykresu [Exploded Doughnut](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/) oraz właściwość eksplozji dla punktów danych; możesz oddzielić pojedyncze fragmenty.

**Jak mogę uzyskać obraz wykresu pierścieniowego (PNG/SVG) do raportu?**

Wykres jest [shape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/); możesz wyrenderować go do [raster image](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getImage) lub wyeksportować wykres jako obraz SVG.