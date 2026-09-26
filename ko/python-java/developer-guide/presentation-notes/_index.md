---
title: Java를 통해 Python에서 프레젠테이션 노트 관리
linktitle: 프레젠테이션 노트
type: docs
weight: 110
url: /ko/python-java/presentation-notes/
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
- Java
- Aspose.Slides
description: "Java를 통해 Python용 Aspose.Slides로 프레젠테이션 노트를 사용자 정의합니다. PowerPoint 및 OpenDocument 노트와 원활하게 작업하여 생산성을 높일 수 있습니다."
---
## **개요**

Aspose.Slides는 프레젠테이션에서 노트 슬라이드를 제거하는 기능을 지원합니다. 이 문서에서는 노트를 제거하는 방법과 프레젠테이션의 노트 슬라이드에 스타일을 적용하는 방법을 소개합니다. Aspose.Slides를 사용하면 모든 슬라이드에서 노트를 제거하고 기존 노트에 스타일을 적용할 수 있습니다. 개발자는 다음과 같은 방법으로 노트를 제거할 수 있습니다:

- 프레젠테이션의 특정 슬라이드에서 노트를 제거합니다.
- 프레젠테이션의 모든 슬라이드에서 노트를 제거합니다.

노트 페이지 크기, 방향 전환, 내보내기 동작을 읽거나 변경하려면 [노트 페이지 크기](/slides/ko/python-java/notes-size/)를 참조하십시오.

## **슬라이드에서 노트 제거**

특정 슬라이드의 노트를 아래 예제와 같이 제거할 수 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다.
presentation = Presentation("presWithNotes.pptx")
try:
    # 첫 번째 슬라이드에서 노트를 제거합니다.
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **프레젠테이션에서 노트 제거**

프레젠테이션의 모든 슬라이드에서 노트를 아래 예제와 같이 제거할 수 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다.
presentation = Presentation("presWithNotes.pptx")
try:
    # 모든 슬라이드에서 노트를 제거합니다.
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **노트 스타일 추가**

[getNotesStyle](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masternotesslide/#getNotesStyle) 메서드와 [MasterNotesSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masternotesslide/) 클래스를 사용하면 노트 텍스트의 스타일에 접근할 수 있습니다. 구현은 아래 예제에서 보여줍니다.

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

        # 첫 번째 수준 단락에 기호 글머리표를 설정합니다.
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**특정 슬라이드의 노트에 접근할 수 있는 API 엔터티는 무엇입니까?**

노트는 슬라이드의 노트 관리자를 통해 접근합니다: 슬라이드에는 [NotesSlideManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notesslidemanager/)가 있으며, 노트 객체를 반환하거나 노트가 없을 경우 `None`을 반환하는 [getNotesSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notesslidemanager/#getNotesSlide) 메서드가 있습니다.

**라이브러리가 지원하는 PowerPoint 버전 간에 노트 지원에 차이가 있습니까?**

이 라이브러리는 Microsoft PowerPoint 형식(97 버전 이후) 및 ODP의 광범위한 범위를 대상으로 하며, 노트는 이러한 형식에서 PowerPoint가 설치되어 있지 않아도 지원됩니다.