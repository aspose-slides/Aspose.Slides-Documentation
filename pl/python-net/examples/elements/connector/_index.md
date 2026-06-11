---
title: Łącznik
type: docs
weight: 190
url: /pl/python-net/examples/elements/connector/
keywords:
- łącznik
- dodaj łącznik
- dostęp do łącznika
- usuń łącznik
- ponowne połączenie kształtów
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Rysuj i steruj łącznikami w Pythonie przy użyciu Aspose.Slides: dodawaj, wyznaczaj trasy, zmieniaj trasy, ustawiaj punkty połączeń, strzałki i style, aby łączyć kształty w PPT, PPTX i ODP."
---
Pokazuje, jak łączyć kształty przy pomocy łączników i zmieniać ich cele przy użyciu **Aspose.Slides for Python via .NET**.

## **Dodaj łącznik**

Wstaw kształt łącznika pomiędzy dwa punkty na slajdzie.

```py
def add_connector():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Dodaj zakrzywiony kształt łącznika.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        presentation.save("connector.pptx", slides.export.SaveFormat.PPTX)
```

## **Dostęp do łącznika**

Pobierz pierwszy kształt łącznika dodany do slajdu.

```py
def access_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Uzyskaj dostęp do pierwszego łącznika na slajdzie.
        first_connector = None
        for shape in slide.shapes:
            if isinstance(shape, slides.Connector):
                first_connector = shape
                break
```

## **Usuń łącznik**

Usuń łącznik ze slajdu.

```py
def remove_connector():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że pierwszy kształt jest łącznikiem.
        connector = slide.shapes[0]

        # Usuń łącznik.
        slide.shapes.remove(connector)

        presentation.save("connector_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ponowne połączenie kształtów**

Podłącz łącznik do dwóch kształtów, przypisując cele początkowe i końcowe.

```py
def reconnect_shapes():
    with slides.Presentation("connector.pptx") as presentation:
        slide = presentation.slides[0]

        # Dodaj pierwszy kształt prostokąta.
        shape1 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 50, 50)
        # Dodaj drugi kształt prostokąta.
        shape2 = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 50, 50)

        # Dodaj zakrzywiony kształt łącznika.
        connector = slide.shapes.add_connector(slides.ShapeType.BENT_CONNECTOR2, 0, 0, 100, 100)

        # Połącz początek łącznika z pierwszym kształtem.
        connector.start_shape_connected_to = shape1
        # Połącz koniec łącznika z drugim kształtem.
        connector.end_shape_connected_to = shape2

        presentation.save("shapes_reconnected.pptx", slides.export.SaveFormat.PPTX)
```