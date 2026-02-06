---
title: Заметка
type: docs
weight: 240
url: /ru/python-net/examples/elements/note/
keywords:
- заметка
- добавить слайд заметок
- получить доступ к слайду заметок
- удалить слайд заметок
- обновить текст заметок
- примеры кода
- PowerPoint
- OpenDocument
- презентация
- Python
- Aspose.Slides
description: "Добавляйте, читайте, редактируйте и экспортируйте заметки докладчика в Python с помощью Aspose.Slides: форматируйте текст, управляйте заметками для каждого слайда и контролируйте их видимость в PowerPoint и OpenDocument."
---
Показано, как добавлять, читать, удалять и обновлять слайды заметок с помощью **Aspose.Slides for Python via .NET**.

## **Добавить слайд заметок**

Создайте слайд заметок и назначьте ему текст.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **Получить доступ к слайду заметок**

Считайте текст из существующего слайда заметок.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **Удалить слайд заметок**

Удалите слайд заметок, связанный со слайдом.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Удалить слайд заметок.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Обновить текст заметок**

Измените текст слайда заметок.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Обновить текст заметки.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```