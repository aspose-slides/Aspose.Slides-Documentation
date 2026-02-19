---
title: Заметка
type: docs
weight: 240
url: /ru/cpp/examples/elements/note/
keywords:
- пример кода
- примечание
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Работа со слайдами заметок в Aspose.Slides для C++: добавление, чтение, редактирование и экспорт нот выступающего в PPT, PPTX и ODP с помощью понятных примеров на C++."
---
В этой статье демонстрируется, как добавлять, читать, удалять и обновлять слайды с заметками, используя **Aspose.Slides for C++**.

## **Add a Notes Slide**
Создайте слайд с заметками и задайте ему текст.

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
Прочитайте текст существующего слайда с заметками.

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
Удалите слайд с заметками, связанный со слайдом.

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
Измените текст слайда с заметками.

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