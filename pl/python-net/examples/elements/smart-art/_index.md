---
title: SmartArt
type: docs
weight: 140
url: /pl/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- dodaj SmartArt
- dostęp do SmartArt
- usuń SmartArt
- układ SmartArt
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Twórz i edytuj SmartArt w Pythonie przy użyciu Aspose.Slides: dodawaj węzły, zmieniaj układy i style, konwertuj na kształty z precyzją oraz eksportuj do PPT, PPTX i ODP."
---
Pokazuje, jak dodać grafiki SmartArt, uzyskać do nich dostęp, usuwać je i zmieniać układy przy użyciu **Aspose.Slides for Python via .NET**.

## **Dodaj SmartArt**

Wstaw grafikę SmartArt, używając jednego z wbudowanych układów.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **Uzyskaj dostęp do SmartArt**

Pobierz pierwszy obiekt SmartArt na slajdzie.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Uzyskaj dostęp do pierwszego kształtu SmartArt.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **Usuń SmartArt**

Usuń kształt SmartArt ze slajdu.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że pierwszy kształt jest obiektem SmartArt.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Zmień układ SmartArt**

Zaktualizuj typ układu istniejącej grafiki SmartArt.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że pierwszy kształt jest obiektem SmartArt.
        smart_art = slide.shapes[0]

        # Zmień układ SmartArt.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```