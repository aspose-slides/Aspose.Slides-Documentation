---
title: Note
type: docs
weight: 240
url: /it/cpp/examples/elements/note/
keywords:
- esempio di codice
- nota
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Lavora con le note delle diapositive in Aspose.Slides per C++: aggiungi, leggi, modifica ed esporta le note del relatore in PPT, PPTX e ODP usando esempi chiari in C++."
---
Questo articolo dimostra come aggiungere, leggere, rimuovere e aggiornare le diapositive di note utilizzando **Aspose.Slides for C++**.

## **Aggiungi una diapositiva di note**

Crea una diapositiva di note e assegna del testo.

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

## **Accedi a una diapositiva di note**

Leggi il testo da una diapositiva di note esistente.

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

## **Rimuovi una diapositiva di note**

Rimuovi la diapositiva di note associata a una diapositiva.

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

## **Aggiorna il testo delle note**

Modifica il testo di una diapositiva di note.

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