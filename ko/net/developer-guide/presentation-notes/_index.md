---
title: .NET에서 프레젠테이션 노트 관리
linktitle: 프레젠테이션 노트
type: docs
weight: 110
url: /ko/net/presentation-notes/
keywords:
- 노트
- 노트 슬라이드
- 노트 추가
- 노트 제거
- 노트 스타일
- 마스터 노트
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 프레젠테이션 노트를 사용자 정의하세요. PowerPoint와 OpenDocument 노트를 원활하게 작업하여 생산성을 높일 수 있습니다."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 노트 슬라이드를 제거하는 기능을 지원합니다. 이 문서에서는 노트를 제거하는 방법과 프레젠테이션의 노트 슬라이드에 스타일을 적용하는 방법을 소개합니다. Aspose.Slides를 사용하면 모든 슬라이드에서 노트를 제거하고 기존 노트에 스타일을 적용할 수 있습니다. 개발자는 다음과 같은 방법으로 노트를 제거할 수 있습니다:

- 프레젠테이션의 특정 슬라이드에서 노트를 제거합니다.
- 프레젠테이션의 모든 슬라이드에서 노트를 제거합니다.

노트 페이지 크기 확인 또는 변경, 방향 전환, 내보내기 동작 확인은 [Notes Page Size](/slides/ko/net/notes-size/)를 참조하세요.

## **슬라이드에서 노트 제거**
특정 슬라이드의 노트를 아래 예제와 같이 제거할 수 있습니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation presentation = new Presentation("AccessSlides.pptx");

// 첫 번째 슬라이드의 노트를 제거합니다
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// 프레젠테이션을 디스크에 저장합니다
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **모든 슬라이드에서 노트 제거**
프레젠테이션의 모든 슬라이드에서 노트를 아래 예제와 같이 제거할 수 있습니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation presentation = new Presentation("AccessSlides.pptx");

// 모든 슬라이드의 노트를 제거합니다
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// 프레젠테이션을 디스크에 저장합니다
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```

## **노트 스타일 추가**
NotesStyle 속성이 [IMasterNotesSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/imasternotesslide) 인터페이스와 [MasterNotesSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/masternotesslide) 클래스에 각각 추가되었습니다. 이 속성은 노트 텍스트의 스타일을 지정합니다. 구현 예시는 아래 예제에서 확인할 수 있습니다.

```c#
using Aspose.Slides;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // MasterNotesSlide 텍스트 스타일을 가져옵니다
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // 첫 번째 수준 단락에 기호 총알을 설정합니다
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // PPTX 파일을 디스크에 저장합니다
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **FAQ**

### 특정 슬라이드의 노트에 접근할 수 있는 API 엔터티는 무엇입니까?

노트는 슬라이드의 노트 관리자를 통해 접근합니다: 슬라이드에는 [NotesSlideManager](https://reference.aspose.com/slides/ko/net/aspose.slides/notesslidemanager/)가 있고, 노트 객체를 반환하거나 노트가 없을 경우 `null`을 반환하는 [property](https://reference.aspose.com/slides/ko/net/aspose.slides/notesslidemanager/notesslide/)가 있습니다.

### 라이브러리가 지원하는 PowerPoint 버전 간에 노트 지원에 차이가 있습니까?

이 라이브러리는 Microsoft PowerPoint 형식(97‑버전부터 최신 버전) 및 ODP를 광범위하게 지원하며, 설치된 PowerPoint 사본에 의존하지 않고 이러한 형식에서 노트를 지원합니다.