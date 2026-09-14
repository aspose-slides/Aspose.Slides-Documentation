---
title: Python을 통한 Java에서 프레젠테이션 머리글 및 바닥글 관리
linktitle: 머리글 및 바닥글
type: docs
weight: 140
url: /ko/python-java/presentation-header-and-footer/
keywords:
- 머리글
- 머리글 텍스트
- 바닥글
- 바닥글 텍스트
- 머리글 설정
- 바닥글 설정
- 유인물
- 노트
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 슬라이드, 노트 페이지 및 유인물에서 바닥글, 날짜/시간, 슬라이드 번호 및 머리글 자리 표시자를 관리하는 방법을 배웁니다."
---
## **개요**

PowerPoint는 페이지 유형에 따라 다른 머리글 및 바닥글 자리 표시자를 사용합니다. Aspose.Slides for Python via Java를 사용하면 머리글/바닥글 관리자 클래스를 통해 이러한 자리 표시자의 텍스트와 표시 여부를 제어할 수 있습니다.

사용 가능한 자리 표시자는 범위에 따라 다릅니다:

| 범위 | 머리글 | 바닥글 | 날짜/시간 | 슬라이드/페이지 번호 |
|---|---|---|---|---|
| 일반 슬라이드 | 아니오 | 예 | 예 | 예 |
| 노트 마스터 | 예 | 예 | 예 | 예 |
| 노트 슬라이드 | 예 | 예 | 예 | 예 |
| 유인물 마스터 | 예 | 예 | 예 | 예 |

일반 프레젠테이션 슬라이드에는 머리글 자리 표시자가 없습니다. 머리글은 노트 페이지와 유인물에서 사용할 수 있습니다. 일반 슬라이드에서는 바닥글, 날짜/시간 및 슬라이드 번호 자리 표시자를 대신 사용하십시오.

변경의 범위는 사용하는 관리자에 따라 달라집니다. [SlideHeaderFooterManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slideheaderfootermanager/) 클래스는 하나의 일반 슬라이드를 제어합니다. [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notesslideheaderfootermanager/) 클래스는 하나의 노트 슬라이드를 제어합니다. 마스터 및 레이아웃 관리자는 종속 슬라이드에 설정을 전파할 수 있으며, [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) 클래스는 유인물 마스터를 제어합니다.

## **일반 슬라이드에서 바닥글, 날짜/시간 및 슬라이드 번호 설정**

일반 슬라이드의 기본 작업 흐름은 각 슬라이드의 머리글/바닥글 관리자를 가져와 바닥글 및 날짜/시간 텍스트를 설정하고 필요한 자리 표시자를 활성화한 뒤 프레젠테이션을 저장하는 것입니다. 슬라이드 번호는 프레젠테이션에서 자동으로 생성되므로 표시 여부만 제어하면 됩니다.

텍스트를 설정하려면 [setFooterText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText)와 [setDateTimeText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText)를 사용하고, 해당 자리 표시자를 표시하려면 [setFooterVisibility](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [setDateTimeVisibility](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility), [setSlideNumberVisibility](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility)를 사용합니다.

다음은 모든 일반 슬라이드에 동일한 바닥글, 날짜/시간 텍스트 및 슬라이드 번호 표시를 적용하는 전체 예제입니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

하나의 슬라이드만 업데이트해야 하는 경우 전체 컬렉션을 순회하지 말고 [getSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getSlides) 메서드를 통해 해당 슬라이드에 직접 접근하십시오.

## **노트 마스터에서 머리글 및 바닥글 설정**

노트 마스터는 노트 페이지에 대한 공통 서식과 자리 표시자 동작을 정의합니다. 노트 마스터 자체만 변경하려면 [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masternotesslideheaderfootermanager/) 클래스를 사용하십시오.

다음 예제는 노트 마스터에 머리글, 바닥글 및 날짜/시간 텍스트를 설정하고 해당 마스터에서 지원되는 모든 자리 표시자를 표시합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

프레젠테이션에 노트 마스터가 포함되어 있지 않으면 `getMasterNotesSlide` 메서드는 `None`을 반환합니다.

## **노트 마스터 설정을 하위 노트 슬라이드에 적용**

노트 마스터는 자체와 모든 종속 노트 슬라이드에 머리글 및 바닥글 설정을 전파할 수 있습니다. 동일한 설정을 노트 계층 전체에 적용하려면 [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masternotesslideheaderfootermanager/)의 전용 전파 메서드를 사용하십시오.

예를 들어, [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText)와 [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility)는 노트 마스터 머리글과 모든 하위 머리글을 업데이트합니다. 바닥글, 날짜/시간 및 슬라이드 번호에 대해서도 동일한 메서드가 제공됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

위에서 사용한 전파 메서드는 [setFooterAndChildFootersText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility), 그리고 [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility)입니다.

## **개별 노트 슬라이드에 머리글 및 바닥글 설정**

노트 슬라이드는 특정 일반 슬라이드에 속합니다. 해당 노트 페이지만 사용자 지정하려면 [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notesslideheaderfootermanager/) 클래스를 사용하십시오.

[addNotesSlide](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notesslidemanager/#addNotesSlide) 메서드는 현재 슬라이드에 대한 노트 슬라이드를 반환하며, 존재하지 않을 경우 새로 생성합니다. 다음 예제는 첫 번째 프레젠테이션 슬라이드와 연결된 노트 페이지를 구성합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

먼저 노트 마스터에서 설정을 전파한 뒤 개별 노트 슬라이드를 변경하면, 이후 슬라이드별 설정이 해당 노트 페이지를 독립적으로 맞춤화할 수 있게 합니다.

## **유인물 마스터에 머리글 및 바닥글 설정**

유인물 페이지는 머리글, 바닥글, 날짜/시간 및 페이지 번호 자리 표시자를 위해 유인물 마스터를 사용합니다. 노트 페이지와 달리 유인물 설정은 개별 유인물 슬라이드가 아닌 유인물 마스터를 통해 관리됩니다.

`getMasterHandoutSlide` 메서드를 사용하여 유인물 마스터에 접근하십시오. 마스터가 존재하지 않을 경우 `setDefaultMasterHandoutSlide`를 호출하여 기본 유인물 마스터를 생성합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **범위 및 상속 이해**

변경하려는 범위에 맞는 머리글/바닥글 관리자를 선택하십시오:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slideheaderfootermanager/)은 하나의 일반 슬라이드에 대한 바닥글, 날짜/시간 및 슬라이드 번호 설정을 변경합니다.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/layoutslideheaderfootermanager/)은 레이아웃 슬라이드를 제어하고 지원되는 설정을 종속 슬라이드에 전파할 수 있습니다.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterslideheaderfootermanager/)은 일반 슬라이드 마스터를 제어하고 지원되는 설정을 종속 슬라이드에 전파합니다.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masternotesslideheaderfootermanager/)은 노트 마스터를 제어하고 모든 종속 노트 슬라이드에 설정을 전파합니다.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/notesslideheaderfootermanager/)은 하나의 노트 슬라이드를 변경하며 머리글 자리 표시자와 바닥글, 날짜/시간, 슬라이드 번호를 지원합니다.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/python-java/aspose.slides/masterhandoutslideheaderfootermanager/)는 유인물 마스터를 변경하고 네 가지 자리 표시자 유형 모두를 지원합니다.

동일한 설정을 계층 전체에 적용하려면 마스터 또는 레이아웃에서 전파하십시오. 하나의 페이지에만 로컬 설정이 필요하면 개별 슬라이드 또는 노트 슬라이드 관리자를 사용하십시오.

## **FAQ**

**일반 슬라이드에 머리글을 추가할 수 있나요?**

아니오. PowerPoint는 일반 슬라이드에 머리글 자리 표시자를 정의하지 않습니다. 일반 슬라이드에서는 바닥글, 날짜/시간 및 슬라이드 번호 자리 표시자를 사용하십시오. 머리글 자리 표시자는 노트 페이지와 유인물에서 사용할 수 있습니다.

**바닥글, 날짜/시간 또는 슬라이드 번호 자리 표시자가 보이지 않으면 어떻게 해야 하나요?**

해당 머리글/바닥글 관리자를 사용하여 표시 여부를 확인하고 필요할 때 활성화하십시오. 예를 들어, [isFooterVisible](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible)는 바닥글 자리 표시자가 있는지 여부를 반환하고, [setFooterVisibility](https://reference.aspose.com/slides/ko/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility)는 표시 여부를 변경합니다.

**슬라이드 번호를 1이 아닌 다른 값부터 시작하려면 어떻게 해야 하나요?**

프레젠테이션의 [setFirstSlideNumber](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#setFirstSlideNumber) 메서드를 호출하십시오. 그러면 슬라이드 번호 자리 표시자가 업데이트된 번호 순서를 사용합니다.

**PDF, 이미지 또는 HTML로 내보낼 때 머리글과 바닥글은 어떻게 처리되나요?**

보이는 머리글 및 바닥글 요소는 출력 형식에서 프레젠테이션 내용과 함께 렌더링됩니다. 표시 여부 설정은 내보내는 페이지 유형에 따라 달라집니다.