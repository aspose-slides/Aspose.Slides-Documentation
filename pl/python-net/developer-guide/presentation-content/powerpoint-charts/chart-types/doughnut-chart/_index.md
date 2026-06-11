---
title: Dostosowywanie wykresów pierścieniowych w prezentacjach przy użyciu Pythona
linktitle: Wykres pierścieniowy
type: docs
weight: 30
url: /pl/python-net/doughnut-chart/
keywords:
- wykres pierścieniowy
- przerwa centralna
- rozmiar otworu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Poznaj sposób tworzenia i dostosowywania wykresów pierścieniowych w Aspose.Slides dla Pythona poprzez .NET, obsługującego formaty PowerPoint i OpenDocument w dynamicznych prezentacjach."
---
## **Przegląd**

Ten artykuł pokazuje, jak pracować z wykresem pierścieniowym w Aspose.Slides, dodając wykres do slajdu, ustawiając rozmiar otworu w jego środku oraz zapisując prezentację. Skupia się na ustawieniu `doughnut_hole_size` i demonstruje podstawowe kroki niezbędne do dostosowania tego typu wykresu w kodzie.

Zawiera również krótkie FAQ obejmujące powiązane scenariusze wykresów pierścieniowych, takie jak użycie wielu serii do tworzenia wielu pierścieni, pracę z wykresami pierścieniowymi z wybuchniętymi (rozłączonymi) segmentami oraz eksport wykresu jako obrazu rastrowego lub SVG.

## **Określenie przerwy środkowej w wykresie pierścieniowym**
Aby określić rozmiar otworu w wykresie pierścieniowym, postępuj zgodnie z poniższymi krokami:

- Instancjonuj klasę [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) .
- Dodaj wykres pierścieniowy na slajdzie.
- Określ rozmiar otworu w wykresie pierścieniowym.
- Zapisz prezentację na dysku.

W poniższym przykładzie ustawiliśmy rozmiar otworu w wykresie pierścieniowym.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

# Utwórz instancję klasy Presentation
with slides.Presentation() as presentation:

    chart = presentation.slides[0].shapes.add_chart(charts.ChartType.DOUGHNUT, 50, 50, 400, 400)
    chart.chart_data.series_groups[0].doughnut_hole_size = 90

    # Zapisz prezentację na dysku
    presentation.save("DoughnutHoleSize_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę utworzyć wielopoziomowy wykres pierścieniowy z wieloma pierścieniami?**

Tak. Dodaj wiele serii do jednego wykresu pierścieniowego — każda seria staje się osobnym pierścieniem. Kolejność pierścieni jest określana przez kolejność serii w kolekcji.

**Czy obsługiwany jest „rozbity” wykres pierścieniowy (oddzielone sektory)?**

Tak. Istnieje typ wykresu Exploded Doughnut [chart type](https://reference.aspose.com/slides/pl/python-net/aspose.slides.charts/charttype/) oraz właściwość explosion na punktach danych; możesz oddzielić poszczególne sektory.

**Jak mogę uzyskać obraz wykresu pierścieniowego (PNG/SVG) do raportu?**

Wykres jest obiektem typu kształt; możesz wyrenderować go jako [obraz rastrowy](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/get_image/) lub wyeksportować wykres do [obrazu SVG](https://reference.aspose.com/slides/pl/python-net/aspose.slides/shape/write_as_svg/).