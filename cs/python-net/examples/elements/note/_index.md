---
title: Poznámka
type: docs
weight: 240
url: /cs/python-net/examples/elements/note/
keywords:
- poznámka
- přidat poznámkový snímek
- přístup k poznámkovému snímku
- odstranit poznámkový snímek
- aktualizovat text poznámek
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Přidávejte, čtěte, upravujte a exportujte poznámky řečníka v Pythonu pomocí Aspose.Slides: formátujte text, spravujte poznámky u každého snímku a ovládejte jejich viditelnost v PowerPointu i OpenDocumentu."
---
Ukazuje, jak pomocí **Aspose.Slides for Python via .NET** přidávat, číst, odstraňovat a aktualizovat poznámkové snímky.

## **Přidat poznámkový snímek**

Vytvořte poznámkový snímek a přiřaďte mu text.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **Přístup k poznámkovému snímku**

Přečtěte text z existujícího poznámkového snímku.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **Odstranit poznámkový snímek**

Odstraňte poznámkový snímek spojený se snímkem.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Odstraňte poznámkový snímek.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Aktualizovat text poznámkového snímku**

Změňte text poznámkového snímku.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Aktualizovat text poznámky.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```