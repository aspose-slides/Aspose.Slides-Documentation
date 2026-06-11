---
title: Hiperłącze
type: docs
weight: 130
url: /pl/python-net/examples/elements/hyperlink/
keywords:
- hiperłącze
- dodaj hiperłącze
- dostęp do hiperłącza
- usuń hiperłącze
- aktualizuj hiperłącze
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dodawaj, edytuj i usuwaj hiperłącza w Pythonie przy użyciu Aspose.Slides: tekst linku, kształty, slajdy, adresy URL i e-mail; ustawiaj cele i akcje dla PPT, PPTX i ODP."
---
Prezentuje dodawanie, odczytywanie, usuwanie i aktualizowanie hiperłączy w kształtach przy użyciu **Aspose.Slides for Python via .NET**.

## **Dodaj hiperłącze**

Utwórz prostokątny kształt z hiperłączem prowadzącym do zewnętrznej witryny.

```py
def add_hyperlink():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 50)
        shape.text_frame.text = "Aspose"

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = slides.Hyperlink("https://www.aspose.com")

        presentation.save("hyperlink.pptx", slides.export.SaveFormat.PPTX)
```

## **Uzyskaj dostęp do hiperłącza**

Odczytaj informacje o hiperłączu z fragmentu tekstu kształtu.

```py
def access_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        hyperlink = text_portion.portion_format.hyperlink_click
```

## **Usuń hiperłącze**

Wyczyść hiperłącze z tekstu kształtu.

```py
def remove_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_click = None

        presentation.save("hyperlink_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Zaktualizuj hiperłącze**

Zmień docelowy adres istniejącego hiperłącza. Użyj `HyperlinkManager`, aby zmodyfikować tekst, który już zawiera hiperłącze, co imituje sposób, w jaki PowerPoint bezpiecznie aktualizuje hiperłącza.

```py
def update_hyperlink():
    with slides.Presentation("hyperlink.pptx") as presentation:
        slide = presentation.slides[0]
        shape = slide.shapes[0]

        # Zmiana hiperłącza w istniejącym tekście powinna być dokonywana za pomocą
        # HyperlinkManager, a nie poprzez bezpośrednie ustawianie właściwości.
        # To naśladuje sposób, w jaki PowerPoint bezpiecznie aktualizuje hiperłącza.
        text_portion = shape.text_frame.paragraphs[0].portions[0]
        text_portion.portion_format.hyperlink_manager.set_external_hyperlink_click("https://new.example.com")

        presentation.save("hyperlink_updated.pptx", slides.export.SaveFormat.PPTX)
```