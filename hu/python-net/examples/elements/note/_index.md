---
title: Jegyzet
type: docs
weight: 240
url: /hu/python-net/examples/elements/note/
keywords:
- jegyzet
- jegyzetdia hozzáadása
- jegyzetdia elérése
- jegyzetdia eltávolítása
- jegyzet szövegének frissítése
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- Python
- Aspose.Slides
description: "Jegyzetek hozzáadása, olvasása, szerkesztése és exportálása Pythonban az Aspose.Slides használatával: szöveg formázása, jegyzetek kezelése diánként, és láthatóság szabályozása PowerPointban és OpenDocumentben."
---
Megmutatja, hogyan adhat hozzá, olvashat, távolíthat el és frissíthet jegyzetdiákat a **Aspose.Slides for Python via .NET** használatával.

## **Jegyzetdia hozzáadása**

Hozzon létre egy jegyzetdiát, és rendeljen hozzá szöveget.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **Jegyzetdia elérése**

Olvassa ki a szöveget egy meglévő jegyzetdiáról.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **Jegyzetdia eltávolítása**

Távolítsa el a diához tartozó jegyzetdiát.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Távolítsa el a jegyzetdiát.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Jegyzet szövegének frissítése**

Módosítsa a jegyzetdia szövegét.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Frissítse a jegyzet szövegét.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```