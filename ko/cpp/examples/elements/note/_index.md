---
title: 노트
type: docs
weight: 240
url: /ko/cpp/examples/elements/note/
keywords:
- 코드 예제
- 노트
- PowerPoint
- OpenDocument
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++에서 슬라이드 노트를 사용합니다: 명확한 C++ 예제를 사용하여 PPT, PPTX 및 ODP에서 발표자 노트를 추가, 읽기, 편집 및 내보냅니다."
---
이 문서에서는 **Aspose.Slides for C++**를 사용하여 노트 슬라이드를 추가, 읽기, 제거 및 업데이트하는 방법을 보여줍니다.

## **노트 슬라이드 추가**

노트 슬라이드를 만들고 텍스트를 할당합니다.

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

## **노트 슬라이드 가져오기**

기존 노트 슬라이드에서 텍스트를 읽습니다.

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

## **노트 슬라이드 제거**

슬라이드와 연결된 노트 슬라이드를 제거합니다.

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

## **노트 텍스트 업데이트**

노트 슬라이드의 텍스트를 변경합니다.

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