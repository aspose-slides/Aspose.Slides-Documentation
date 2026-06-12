---
title: Poznámka
type: docs
weight: 240
url: /cs/cpp/examples/elements/note/
keywords:
- příklad kódu
- poznámka
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Pracujte s poznámkami snímků v Aspose.Slides for C++: přidejte, přečtěte, upravte a exportujte poznámky řečníka ve formátech PPT, PPTX a ODP pomocí přehledných příkladů v C++."
---
Tento článek ukazuje, jak přidávat, číst, odstraňovat a aktualizovat snímky poznámek pomocí **Aspose.Slides for C++**.

## **Přidání snímku poznámek**

Vytvořte snímek poznámek a přiřaďte mu text.

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

## **Přístup k snímku poznámek**

Přečtěte text z existujícího snímku poznámek.

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

## **Odstranění snímku poznámek**

Odstraňte snímek poznámek spojený se snímkem.

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

## **Aktualizace textu poznámek**

Změňte text snímku poznámek.

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