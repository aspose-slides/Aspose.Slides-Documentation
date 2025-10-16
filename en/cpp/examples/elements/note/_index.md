---
title: Note
type: docs
weight: 240
url: /cpp/examples/elements/elements/note/
keywords:
- code example
- note
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Work with slide notes in Aspose.Slides for C++: add, read, edit, and export speaker notes in PPT, PPTX, and ODP using clear C++ examples."
---

This article demonstrates how to add, read, remove, and update notes slides using **Aspose.Slides for C++**.

## **Add a Notes Slide**

Create a notes slide and assign text to it.

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

## **Access a Notes Slide**

Read text from an existing notes slide.

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

## **Remove a Notes Slide**

Remove the notes slide associated with a slide.

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

## **Update Notes Text**

Change the text of a notes slide.

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
