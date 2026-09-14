---
title: Java를 통한 Python에서 프레젠테이션 메모 관리
linktitle: 프레젠테이션 메모
type: docs
weight: 110
url: /ko/python-java/presentation-notes/
keywords:
- 메모
- 메모 슬라이드
- 메모 추가
- 메모 제거
- 메모 스타일
- 마스터 메모
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 프레젠테이션 메모를 맞춤 설정합니다. PowerPoint와 OpenDocument 메모를 원활하게 작업하여 생산성을 높입니다."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 메모 슬라이드를 제거하는 것을 지원합니다. 이 항목에서는 메모를 제거하는 방법과 프레젠테이션의 메모 슬라이드에 스타일을 적용하는 방법을 소개합니다. Aspose.Slides를 사용하면任意의 슬라이드에서 메모를 제거하고 기존 메모에 스타일을 적용할 수 있습니다. 개발자는 다음과 같은 방식으로 메모를 제거할 수 있습니다:

- 프레젠테이션 내 특정 슬라이드에서 메모를 제거합니다.
- 프레젠테이션의 모든 슬라이드에서 메모를 제거합니다.

## **슬라이드에서 메모 제거**

특정 슬라이드의 메모는 아래 예시와 같이 제거할 수 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다.
presentation = Presentation("presWithNotes.pptx")
try:
    # 첫 번째 슬라이드에서 메모를 제거합니다.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **프레젠테이션에서 메모 제거**

프레젠테이션의 모든 슬라이드에서 메모는 아래 예시와 같이 제거할 수 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다.
presentation = Presentation("presWithNotes.pptx")
try:
    # 모든 슬라이드에서 메모를 제거합니다.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **메모 스타일 추가**

[MasterNotesSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masternotesslide/) 클래스의 [getNotesStyle](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masternotesslide/#getNotesStyle) 메서드는 메모 텍스트 스타일에 대한 접근을 제공합니다. 구현 예시는 아래에示됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다.
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # 마스터 노트 슬라이드 텍스트 스타일을 가져옵니다.
        notes_style = notes_master.getNotesStyle()

        # 첫 번째 레벨 단락에 심볼 글머리표를 설정합니다.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **자주 묻는 질문**

**특정 슬라이드의 메모에 접근할 수 있는 API 엔터티는 무엇입니까?**

메모는 슬라이드의 메모 관리자 통해 접근합니다: 슬라이드에는 [NotesSlideManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notesslidemanager/)가 있으며, 해당 매니저의 [getNotesSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notesslidemanager/#getNotesSlide) 메서드는 메모 객체를 반환하고, 메모가 없을 경우 `None`을 반환합니다.

**라이브러리가 지원하는 PowerPoint 버전마다 메모 지원에 차이가 있습니까?**

이 라이브러리는 Microsoft PowerPoint 포맷(97 버전 이후) 및 ODP를 폭넓게 지원하며, 이러한 포맷 내에서 메모가 지원됩니다. PowerPoint가 설치돼 있어야 할 필요는 없습니다.