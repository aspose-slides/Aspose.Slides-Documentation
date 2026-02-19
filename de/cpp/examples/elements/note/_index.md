---
title: Notiz
type: docs
weight: 240
url: /de/cpp/examples/elements/note/
keywords:
- Codebeispiel
- Notiz
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Arbeiten Sie mit Foliennotizen in Aspose.Slides für C++: Hinzufügen, Lesen, Bearbeiten und Exportieren von Sprecher-Notizen in PPT, PPTX und ODP mit klaren C++-Beispielen."
---
Dieser Artikel demonstriert, wie man Notizfolien hinzufügt, liest, entfernt und aktualisiert, indem man **Aspose.Slides für C++** verwendet.

## **Notizfolie hinzufügen**

Erstellen Sie eine Notizfolie und weisen Sie ihr Text zu.

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

## **Zugriff auf eine Notizfolie**

Lesen Sie den Text einer vorhandenen Notizfolie.

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

## **Notizfolie entfernen**

Entfernen Sie die mit einer Folie verbundene Notizfolie.

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

## **Notiztext aktualisieren**

Ändern Sie den Text einer Notizfolie.

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