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
description: "Aspose.Slides for Python via .NET를 사용하여 프레젠테이션 노트를 사용자 정의하십시오. PowerPoint 및 OpenDocument 노트를 원활하게 작업하여 생산성을 향상시킵니다."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 노트 슬라이드를 제거하는 기능을 지원합니다. 이 항목에서는 노트를 제거하는 방법과 프레젠테이션의 노트 슬라이드에 스타일을 적용하는 방법을 소개합니다. Aspose.Slides를 사용하면 모든 슬라이드에서 노트를 제거하고 기존 노트에 스타일을 적용할 수 있습니다. 개발자는 다음과 같은 방법으로 노트를 제거할 수 있습니다:

- 프레젠테이션의 특정 슬라이드에서 노트를 제거합니다.
- 프레젠테이션의 모든 슬라이드에서 노트를 제거합니다.

## **슬라이드에서 노트 제거**
특정 슬라이드의 노트를 아래 예제와 같이 제거할 수 있습니다:

```py
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 첫 번째 슬라이드의 노트를 제거합니다
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # 프레젠테이션을 디스크에 저장합니다
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **모든 슬라이드에서 노트 제거**
프레젠테이션의 모든 슬라이드에서 노트를 아래 예제와 같이 제거할 수 있습니다:

```py
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # 모든 슬라이드의 노트를 제거합니다
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # 프레젠테이션을 디스크에 저장합니다
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **NotesStyle 추가**
The [notes_style](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masternotesslide/notes_style/) 속성이 [MasterNotesSlide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masternotesslide/) 클래스에 추가되었습니다. 이 속성은 노트 텍스트의 스타일을 지정합니다. 구현은 아래 예제에서 보여줍니다.

```py
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # MasterNotesSlide 텍스트 스타일 가져오기
        notesStyle = notesMaster.notes_style

        # 첫 번째 수준 단락에 기호 글머리표 설정
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # PPTX 파일을 디스크에 저장합니다
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**특정 슬라이드의 노트에 접근할 수 있는 API 엔터티는 무엇입니까?**

노트는 슬라이드의 노트 관리자를 통해 접근합니다: 슬라이드에는 [NotesSlideManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/notesslidemanager/)와 노트 객체를 반환하는 [property](https://reference.aspose.com/slides/ko/python-net/aspose.slides/notesslidemanager/notes_slide/)가 있으며, 노트가 없으면 `None`을 반환합니다.

**라이브러리가 지원하는 PowerPoint 버전마다 노트 지원에 차이가 있습니까?**

이 라이브러리는 Microsoft PowerPoint 형식(97-버전부터 최신) 및 ODP를 폭넓게 지원합니다; 노트는 이러한 형식에서 PowerPoint가 설치되어 있지 않아도 지원됩니다.