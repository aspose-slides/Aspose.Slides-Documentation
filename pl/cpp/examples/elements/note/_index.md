---
title: Notatka
type: docs
weight: 240
url: /pl/cpp/examples/elements/note/
keywords:
- przykład kodu
- notatka
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Pracuj z notatkami slajdów w Aspose.Slides dla C++: dodawaj, odczytuj, edytuj i eksportuj notatki prelegenta w formatach PPT, PPTX i ODP przy użyciu czytelnych przykładów C++."
---
Ten artykuł demonstruje, jak dodawać, odczytywać, usuwać i aktualizować slajdy notatek przy użyciu **Aspose.Slides for C++**.

## **Dodaj slajd notatek**

Utwórz slajd notatek i przypisz do niego tekst.

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

## **Uzyskaj dostęp do slajdu notatek**

Odczytaj tekst z istniejącego slajdu notatek.

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

## **Usuń slajd notatek**

Usuń slajd notatek powiązany ze slajdem.

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

## **Zaktualizuj tekst notatek**

Zmień tekst slajdu notatek.

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