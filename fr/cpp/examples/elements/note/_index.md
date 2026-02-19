---
title: Note
type: docs
weight: 240
url: /fr/cpp/examples/elements/note/
keywords:
- exemple de code
- note
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Travaillez avec les notes de diapositives dans Aspose.Slides for C++: ajoutez, lisez, modifiez et exportez les notes du présentateur au format PPT, PPTX et ODP à l’aide d’exemples C++ clairs."
---
Cet article montre comment ajouter, lire, supprimer et mettre à jour les diapositives de notes en utilisant **Aspose.Slides for C++**.

## **Ajouter une diapositive de notes**

Créer une diapositive de notes et lui assigner du texte.

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

## **Accéder à une diapositive de notes**

Lire le texte d’une diapositive de notes existante.

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

## **Supprimer une diapositive de notes**

Supprimer la diapositive de notes associée à une diapositive.

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

## **Mettre à jour le texte des notes**

Modifier le texte d’une diapositive de notes.

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