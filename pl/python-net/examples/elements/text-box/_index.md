---
title: Pudełko tekstowe
type: docs
weight: 40
url: /pl/python-net/examples/elements/text-box/
keywords:
- pudełko tekstowe
- dodaj pudełko tekstowe
- dostęp do pudełka tekstowego
- usuń pudełko tekstowe
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Twórz i formatuj pudełka tekstowe w Pythonie przy użyciu Aspose.Slides: ustaw czcionki, wyrównanie, zawijanie, automatyczne dopasowanie oraz linki do polskich slajdów dla PowerPoint i OpenDocument."
---
W Aspose.Slides **pudełko tekstowe** jest reprezentowane przez `AutoShape`. Prawie każdy kształt może zawierać tekst, ale typowe pudełko tekstowe nie ma wypełnienia ani obramowania i wyświetla tylko tekst.

Ten przewodnik wyjaśnia, jak programowo dodawać, uzyskiwać dostęp i usuwać pudełka tekstowe.

## **Dodaj pudełko tekstowe**

Pudełko tekstowe to po prostu `AutoShape` bez wypełnienia i obramowania oraz z pewnym sformatowanym tekstem. Oto jak je utworzyć:

```py
def add_text_box():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Utwórz prostokątny kształt (domyślnie wypełniony obramowaniem i bez tekstu).
        text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 75, 150, 100)

        # Usuń wypełnienie i obramowanie, aby wyglądało jak typowe pudełko tekstowe.
        text_box.fill_format.fill_type = slides.FillType.NO_FILL
        text_box.line_format.fill_format.fill_type = slides.FillType.NO_FILL

        # Ustaw formatowanie tekstu.
        paragraph_format = text_box.text_frame.paragraphs[0].paragraph_format
        paragraph_format.default_portion_format.fill_format.fill_type = slides.FillType.SOLID
        paragraph_format.default_portion_format.fill_format.solid_fill_color.color = drawing.Color.black

        # Przypisz rzeczywistą treść tekstu.
        text_box.text_frame.text = "Some text..."

        presentation.save("text_box.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Uwaga:** Każdy `AutoShape`, który zawiera niepusty `TextFrame`, może pełnić funkcję pudełka tekstowego.

## **Uzyskaj dostęp do pudełek tekstowych według zawartości**

Aby znaleźć wszystkie pudełka tekstowe zawierające określone słowo kluczowe (np. "Slide"), przeiteruj kształty i sprawdź ich tekst:

```py
def access_text_box():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        for shape in slide.shapes:
            # Tylko AutoShape'y mogą zawierać edytowalny tekst.
            if isinstance(shape, slides.AutoShape):
                if "Slide" in shape.text_frame.text:
                    # Zrób coś z dopasowanym pudełkiem tekstowym.
                    pass
```

## **Usuń pudełka tekstowe według zawartości**

Ten przykład znajduje i usuwa wszystkie pudełka tekstowe na pierwszym slajdzie, które zawierają określone słowo kluczowe:

```py
def remove_text_boxes():
    with slides.Presentation("text_box.pptx") as presentation:
        slide = presentation.slides[0]

        # Znajdź kształty do usunięcia, które są AutoShape'ami zawierającymi słowo "Slide".
        shapes_to_remove = [
            shape for shape in slide.shapes
            if isinstance(shape, slides.AutoShape) and "Slide" in shape.text_frame.text
        ]

        # Usuń każdy pasujący kształt ze slajdu.
        for shape in shapes_to_remove:
            slide.shapes.remove(shape)

        presentation.save("text_boxes_removed.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Wskazówka:** Zawsze twórz kopię kolekcji kształtów przed jej modyfikacją podczas iteracji, aby uniknąć błędów modyfikacji kolekcji.