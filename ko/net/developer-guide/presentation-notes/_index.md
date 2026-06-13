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
description: "Aspose.Slides for .NET을 사용하여 프레젠테이션 노트를 사용자 정의하십시오. PowerPoint 및 OpenDocument 노트를 원활하게 작업하여 생산성을 높이세요."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 노트 슬라이드를 제거하는 것을 지원합니다. 이 항목에서는 노트를 제거하는 방법과 프레젠테이션의 노트 슬라이드에 스타일을 적용하는 방법을 포함하여 이 기능을 소개합니다. Aspose.Slides를 사용하면 모든 슬라이드에서 노트를 제거하고 기존 노트에 스타일을 적용할 수 있습니다. 개발자는 다음과 같은 방법으로 노트를 제거할 수 있습니다:

- 프레젠테이션의 특정 슬라이드에서 노트를 제거합니다.
- 프레젠테이션의 모든 슬라이드에서 노트를 제거합니다.

## **슬라이드에서 노트 제거**
아래 예제와 같이 특정 슬라이드의 노트를 제거할 수 있습니다:

```c#
// 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// 첫 번째 슬라이드의 노트를 제거합니다
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// 프레젠테이션을 디스크에 저장합니다
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **모든 슬라이드에서 노트 제거**
아래 예제와 같이 프레젠테이션의 모든 슬라이드에서 노트를 제거할 수 있습니다:

```c#
// 프레젠테이션 파일을 나타내는 Presentation 객체를 생성합니다 
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
NotesStyle 속성이 각각 [IMasterNotesSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/imasternotesslide) 인터페이스와 [MasterNotesSlide](https://reference.aspose.com/slides/ko/net/aspose.slides/masternotesslide) 클래스에 추가되었습니다. 이 속성은 노트 텍스트의 스타일을 지정합니다. 구현은 아래 예제에서 보여집니다.

```c#
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // MasterNotesSlide 텍스트 스타일을 가져옵니다
        ITextStyle notesStyle = notesMaster.NotesStyle;

        // 첫 번째 수준 단락에 기호 글머리표를 설정합니다
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // PPTX 파일을 디스크에 저장합니다
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **FAQ**

**특정 슬라이드의 노트에 접근할 수 있는 API 엔터티는 무엇입니까?**

노트는 슬라이드의 노트 관리자를 통해 접근합니다: 슬라이드에는 노트 객체를 반환하는 [NotesSlideManager](https://reference.aspose.com/slides/ko/net/aspose.slides/notesslidemanager/)와 [property](https://reference.aspose.com/slides/ko/net/aspose.slides/notesslidemanager/notesslide/)가 있으며, 노트가 없으면 `null`을 반환합니다.

**라이브러리가 지원하는 PowerPoint 버전마다 노트 지원에 차이가 있습니까?**

이 라이브러리는 Microsoft PowerPoint 형식(97버전 이상) 및 ODP를 광범위하게 지원하도록 설계되었으며; 노트는 PowerPoint가 설치되어 있지 않아도 이러한 형식에서 지원됩니다.