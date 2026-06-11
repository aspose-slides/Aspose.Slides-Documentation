---
title: Notatka
type: docs
weight: 240
url: /pl/python-net/examples/elements/note/
keywords:
- notatka
- dodaj slajd z notatkami
- uzyskaj dostęp do slajdu z notatkami
- usuń slajd z notatkami
- zaktualizuj tekst notatek
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dodaj, odczytuj, edytuj i eksportuj notatki prelegenta w Pythonie przy użyciu Aspose.Slides: formatowanie tekstu, zarządzanie notatkami per slajd oraz kontrola widoczności w PowerPoint i OpenDocument."
---
Pokazuje, jak dodać, odczytać, usunąć i zaktualizować slajdy z notatkami przy użyciu **Aspose.Slides for Python via .NET**.

## **Dodaj slajd z notatkami**

Utwórz slajd z notatkami i przypisz do niego tekst.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **Uzyskaj dostęp do slajdu z notatkami**

Odczytaj tekst z istniejącego slajdu z notatkami.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **Usuń slajd z notatkami**

Usuń slajd z notatkami powiązany ze slajdem.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Usuń slajd z notatkami.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Zaktualizuj tekst notatek**

Zmień tekst slajdu z notatkami.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Zaktualizuj tekst notatki.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```