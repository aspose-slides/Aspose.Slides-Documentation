---
title: Nota
type: docs
weight: 240
url: /es/cpp/examples/elements/note/
keywords:
- ejemplo de código
- nota
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Trabaje con notas de diapositivas en Aspose.Slides for C++: añada, lea, edite y exporte notas del presentador en PPT, PPTX y ODP usando ejemplos claros en C++."
---
Este artículo muestra cómo agregar, leer, eliminar y actualizar diapositivas de notas usando **Aspose.Slides for C++**.

## **Agregar una diapositiva de notas**

Cree una diapositiva de notas y asígnele texto.

```cpp
static void AddNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();
    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"My note");

    presentation->Dispose();
}
```

## **Acceder a una diapositiva de notas**

Lea el texto de una diapositiva de notas existente.

```cpp
static void AccessNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    auto notes = notesSlide->get_NotesTextFrame()->get_Text();

    presentation->Dispose();
}
```

## **Eliminar una diapositiva de notas**

Elimine la diapositiva de notas asociada a una diapositiva.

```cpp
static void RemoveNote()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    slide->get_NotesSlideManager()->RemoveNotesSlide();

    presentation->Dispose();
}
```

## **Actualizar el texto de notas**

Cambie el texto de una diapositiva de notas.

```cpp
static void UpdateNoteText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto notesSlide = slide->get_NotesSlideManager()->AddNotesSlide();

    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"Old");
    slide->get_NotesSlideManager()->get_NotesSlide()->get_NotesTextFrame()->set_Text(u"Updated");

    presentation->Dispose();
}
```