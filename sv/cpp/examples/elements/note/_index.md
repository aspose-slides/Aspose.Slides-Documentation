---
title: Anteckning
type: docs
weight: 240
url: /sv/cpp/examples/elements/note/
keywords:
- kodexempel
- anteckning
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Arbeta med bildanteckningar i Aspose.Slides för C++: lägg till, läs, redigera och exportera talaranteckningar i PPT, PPTX och ODP med tydliga C++-exempel."
---
Den här artikeln visar hur man lägger till, läser, tar bort och uppdaterar anteckningsbilder med **Aspose.Slides for C++**.

## **Lägg till en anteckningsbild**

Skapa en anteckningsbild och tilldela text till den.

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

## **Åtkomst till en anteckningsbild**

Läs text från en befintlig anteckningsbild.

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

## **Ta bort en anteckningsbild**

Ta bort anteckningsbilden som är associerad med en bild.

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

## **Uppdatera anteckningstext**

Ändra texten på en anteckningsbild.

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