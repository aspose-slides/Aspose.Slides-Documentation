---
title: Nota
type: docs
weight: 240
url: /pt/python-net/examples/elements/note/
keywords:
- nota
- adicionar slide de notas
- acessar slide de notas
- remover slide de notas
- atualizar texto das notas
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Adicionar, ler, editar e exportar notas do apresentador em Python com Aspose.Slides: formatar texto, gerenciar notas por slide e controlar a visibilidade no PowerPoint e OpenDocument."
---
Mostra como adicionar, ler, remover e atualizar notas de slides usando **Aspose.Slides for Python via .NET**.

## **Adicionar um slide de notas**

Crie um slide de notas e atribua texto a ele.

```py
def add_note():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.add_notes_slide()
        notes_slide.notes_text_frame.text = "My note"

        presentation.save("note.pptx", slides.export.SaveFormat.PPTX)
```

## **Acessar um slide de notas**

Leia o texto de um slide de notas existente.

```py
def access_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        notes_slide = slide.notes_slide_manager.notes_slide
        notes = notes_slide.notes_text_frame.text
```

## **Remover um slide de notas**

Remova o slide de notas associado a um slide.

```py
def remove_note():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Remover o slide de notas.
        slide.notes_slide_manager.remove_notes_slide()

        presentation.save("note_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Atualizar texto das notas**

Altere o texto de um slide de notas.

```py
def update_note_text():
    with slides.Presentation("note.pptx") as presentation:
        slide = presentation.slides[0]

        # Atualizar texto da nota.
        slide.notes_slide_manager.notes_slide.notes_text_frame.text = "Updated"

        presentation.save("note_updated.pptx", slides.export.SaveFormat.PPTX)
```