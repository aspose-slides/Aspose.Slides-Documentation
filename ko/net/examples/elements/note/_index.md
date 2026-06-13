---
title: 노트
type: docs
weight: 240
url: /ko/net/examples/elements/note/
keywords:
- 노트
- 노트 슬라이드 추가
- 노트 슬라이드 액세스
- 노트 슬라이드 제거
- 노트 텍스트 업데이트
- 코드 예제
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 슬라이드 노트를 작업합니다: PPT, PPTX 및 ODP에서 스피커 노트를 추가, 읽기, 편집 및 내보내기를 명확한 C# 예제를 사용하여 수행합니다."
---
이 문서에서는 **Aspose.Slides for .NET**을 사용하여 노트 슬라이드를 추가, 읽기, 삭제 및 업데이트하는 방법을 보여줍니다.

## **노트 슬라이드 추가**

노트 슬라이드를 만들고 텍스트를 할당합니다.

```csharp
static void AddNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "My note";
}
```

## **노트 슬라이드 액세스**

기존 노트 슬라이드에서 텍스트를 읽습니다.

```csharp
static void AccessNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    var notes = notesSlide.NotesTextFrame.Text;
}
```

## **노트 슬라이드 제거**

슬라이드에 연결된 노트 슬라이드를 제거합니다.

```csharp
static void RemoveNote()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```

## **노트 텍스트 업데이트**

노트 슬라이드의 텍스트를 변경합니다.

```csharp
static void UpdateNoteText()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var notesSlide = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Old";
    slide.NotesSlideManager.NotesSlide.NotesTextFrame.Text = "Updated";
}
```