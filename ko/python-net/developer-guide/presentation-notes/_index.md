---
title: Python에서 프레젠테이션 노트 관리
linktitle: 프레젠테이션 노트
type: docs
weight: 110
url: /ko/python-net/presentation-notes/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 .NET을 통해 사용하여 프레젠테이션 노트를 사용자 정의하세요. PowerPoint 및 OpenDocument 노트를 원활하게 작업하여 생산성을 높일 수 있습니다."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 노트 슬라이드를 제거하는 기능을 지원합니다. 이 항목에서는 노트를 제거하는 방법과 프레젠테이션의 노트 슬라이드에 스타일을 적용하는 방법을 소개합니다. Aspose.Slides를 사용하면 모든 슬라이드에서 노트를 제거하고 기존 노트에 스타일을 적용할 수 있습니다. 개발자는 다음과 같은 방법으로 노트를 제거할 수 있습니다:

- 프레젠테이션의 특정 슬라이드에서 노트를 제거합니다.
- 프레젠테이션의 모든 슬라이드에서 노트를 제거합니다.

노트 페이지 크기를 읽거나 변경하고, 방향을 전환하며, 내보내기 동작을 확인하려면 [노트 페이지 크기](/slides/ko/python-net/notes-size/)를 참조하세요.

## **슬라이드에서 노트 제거**
특정 슬라이드의 노트를 제거하는 예는 다음과 같습니다:

```py
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
with slides.Presentation("AccessSlides.pptx") as presentation:
    # 첫 번째 슬라이드의 노트를 제거합니다
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # 프레젠테이션을 디스크에 저장합니다
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **전체 슬라이드에서 노트 제거**
프레젠테이션의 모든 슬라이드에서 노트를 제거하는 예는 다음과 같습니다:

```py
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # 모든 슬라이드의 노트를 제거합니다
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # 프레젠테이션을 디스크에 저장합니다
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **노트 스타일 적용**
[notes_style](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masternotesslide/notes_style/) 속성이 [MasterNotesSlide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masternotesslide/) 클래스에 추가되었습니다. 이 속성은 노트 텍스트의 스타일을 지정합니다. 구현은 아래 예제에서 확인할 수 있습니다.

```py
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # MasterNotesSlide 텍스트 스타일을 가져옵니다
        notesStyle = notesMaster.notes_style

        #Set 첫 번째 수준 단락에 심볼 글머리표를 설정합니다
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # PPTX 파일을 디스크에 저장합니다
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**특정 슬라이드의 노트에 접근할 수 있는 API 엔터티는 무엇입니까?**

노트는 슬라이드의 노트 관리자를 통해 접근합니다: 슬라이드에는 [NotesSlideManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/notesslidemanager/)와 노트 객체를 반환하는 [property](https://reference.aspose.com/slides/ko/python-net/aspose.slides/notesslidemanager/notes_slide/)가 있으며, 노트가 없으면 `None`을 반환합니다.

**라이브러리가 지원하는 PowerPoint 버전마다 노트 지원에 차이가 있습니까?**

이 라이브러리는 Microsoft PowerPoint 형식(97‑버전부터 최신 버전) 및 ODP를 광범위하게 지원하며, 설치된 PowerPoint에 의존하지 않고 이러한 형식에서 노트를 지원합니다.