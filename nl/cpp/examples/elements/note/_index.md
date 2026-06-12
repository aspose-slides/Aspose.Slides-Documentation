---
title: Notitie
type: docs
weight: 240
url: /nl/cpp/examples/elements/note/
keywords:
- codevoorbeeld
- notitie
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Werk met notitieslides in Aspose.Slides voor C++: toevoegen, lezen, bewerken en exporteren van spreker-notities in PPT, PPTX en ODP met duidelijke C++-voorbeelden."
---
Dit artikel laat zien hoe je notitieslides kunt toevoegen, lezen, verwijderen en bijwerken met **Aspose.Slides for C++**.

## **Notitieslide toevoegen**

Maak een notitieslide aan en ken er tekst aan toe.

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

## **Toegang tot een notitieslide**

Lees de tekst van een bestaande notitieslide.

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

## **Notitieslide verwijderen**

Verwijder de notitieslide die bij een slide hoort.

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

## **Tekst van notitieslide bijwerken**

Wijzig de tekst van een notitieslide.

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