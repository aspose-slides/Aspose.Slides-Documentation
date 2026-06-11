---
title: Wykres
type: docs
weight: 60
url: /pl/python-net/examples/elements/chart/
keywords:
- wykres
- dodaj wykres
- dostęp do wykresu
- usuń wykres
- aktualizuj wykres
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Twórz i dostosowuj wykresy w języku Python przy użyciu Aspose.Slides: dodawaj dane, formatowanie serii, osi i etykiet, zmieniaj typy oraz eksportuj—działa z formatami PPT, PPTX i ODP."
---
Przykłady dodawania, uzyskiwania dostępu, usuwania i aktualizacji różnych typów wykresów przy użyciu **Aspose.Slides for Python via .NET**. Poniższe fragmenty kodu demonstrują podstawowe operacje na wykresach.

## **Dodaj wykres**

Ta metoda dodaje prosty wykres obszarowy do pierwszego slajdu.

```py
def add_chart():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Dodaj prosty wykres kolumnowy do pierwszego slajdu.
        chart = slide.shapes.add_chart(slides.charts.ChartType.AREA, 50, 50, 400, 300)

        presentation.save("chart.pptx", slides.export.SaveFormat.PPTX)
```

## **Dostęp do wykresu**

Poniższy kod pobiera wykres z kolekcji kształtów.

```py
def access_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Uzyskaj dostęp do pierwszego wykresu na slajdzie.
        first_chart = None
        for shape in slide.shapes:
            if isinstance(shape, slides.charts.Chart):
                first_chart = shape
                break
```

## **Usuń wykres**

Poniższy kod usuwa wykres ze slajdu.

```py
def remove_chart():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że pierwszy kształt jest wykresem.
        chart = slide.shapes[0]

        # Usuń wykres.
        slide.shapes.remove(chart)

        presentation.save("chart_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Aktualizuj dane wykresu**

Możesz zmienić właściwości wykresu, takie jak tytuł.

```py
def update_chart_data():
    with slides.Presentation("chart.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że pierwszy kształt jest wykresem.
        chart = slide.shapes[0]

        # Zmień tytuł wykresu.
        chart.chart_title.add_text_frame_for_overriding("Sales Report")

        presentation.save("chart_updated.pptx", slides.export.SaveFormat.PPTX)
```