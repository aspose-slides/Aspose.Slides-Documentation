---
title: Atrament
type: docs
weight: 180
url: /pl/python-net/examples/elements/ink/
keywords:
- atrament
- dostęp do atramentu
- usuwanie atramentu
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Obsłuż cyfrowy atrament na slajdach w Pythonie przy użyciu Aspose.Slides: dodaj pociągnięcia pióra, edytuj ścieżki, ustaw kolor i szerokość, oraz wyeksportuj wyniki do PowerPoint i OpenDocument."
---
Zawiera przykłady dostępu do istniejących kształtów atramentu i ich usuwania przy użyciu **Aspose.Slides for Python via .NET**.

> ❗ **Uwaga:** Kształty atramentu reprezentują dane wejściowe użytkownika z specjalistycznych urządzeń. Aspose.Slides nie może programowo tworzyć nowych pociągnięć atramentu, ale możesz odczytywać i modyfikować istniejący atrament.

## **Dostęp do atramentu**

Pobierz pierwszy kształt atramentu ze slajdu.

```py
def access_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        first_ink = None
        for shape in slide.shapes:
            if isinstance(shape, slides.ink.Ink):
                first_ink = shape
                break
```

## **Usuwanie atramentu**

Usuń kształt atramentu ze slajdu.

```py
def remove_ink():
    with slides.Presentation("ink.pptx") as presentation:
        slide = presentation.slides[0]

        # Zakładając, że pierwszy kształt jest obiektem Ink.
        ink = slide.shapes[0]

        slide.shapes.remove(ink)

        presentation.save("ink_removed.pptx", slides.export.SaveFormat.PPTX)
```