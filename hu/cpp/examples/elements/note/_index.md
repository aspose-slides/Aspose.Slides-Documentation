---
title: Jegyzet
type: docs
weight: 240
url: /hu/cpp/examples/elements/note/
keywords:
- kódpélda
- jegyzet
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Adiákat jegyzetekkel kezelni az Aspose.Slides for C++-ben: hozzáadás, olvasás, szerkesztés és előadói jegyzetek exportálása PPT, PPTX és ODP formátumba tiszta C++ példákkal."
---
Ez a cikk bemutatja, hogyan lehet jegyzetdiákat hozzáadni, olvasni, eltávolítani és frissíteni a **Aspose.Slides for C++** használatával.

## **Jegyzetdia hozzáadása**

Készítsen egy jegyzetdiát, és adjon hozzá szöveget.

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

## **Jegyzetdia elérése**

Olvassa el egy meglévő jegyzetdia szövegét.

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

## **Jegyzetdia eltávolítása**

Távolítsa el a diával kapcsolatos jegyzetdiát.

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

## **Jegyzet szövegének frissítése**

Módosítsa egy jegyzetdia szövegét.

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