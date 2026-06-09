---
title: Not
type: docs
weight: 240
url: /tr/cpp/examples/elements/note/
keywords:
- kod örneği
- not
- PowerPoint
- OpenDocument
- sunum
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ içinde slayt notlarıyla çalışın: net C++ örnekleri kullanarak PPT, PPTX ve ODP formatlarında konuşmacı notlarını ekleyin, okuyun, düzenleyin ve dışa aktarın."
---
Bu makale, **Aspose.Slides for C++** kullanarak not slaytlarını ekleme, okuma, kaldırma ve güncelleme işlemlerini göstermektedir.

## **Not Slaytı Ekle**

Bir not slaytı oluşturun ve ona metin atayın.

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

## **Not Slaytına Erişim**

Mevcut bir not slaytından metni okuyun.

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

## **Not Slaytını Kaldır**

Bir slayt ile ilişkili not slaytını kaldırın.

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

## **Not Metnini Güncelle**

Bir not slaytının metnini değiştirin.

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