---
title: Python으로 프레젠테이션 머리글 및 바닥글 관리
linktitle: 머리글 및 바닥글
type: docs
weight: 140
url: /ko/python-net/presentation-header-and-footer/
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
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 슬라이드, 노트 페이지 및 유인물의 바닥글, 날짜-시간, 슬라이드 번호 및 머리글 자리 표시자를 관리하는 방법을 배웁니다."
---
## **개요**

PowerPoint는 페이지 유형에 따라 서로 다른 머리글 및 바닥글 자리 표시자를 사용합니다. .NET을 통한 Python용 Aspose.Slides를 사용하면 헤더/바닥글 관리자 클래스를 통해 이러한 자리 표시자의 텍스트와 표시 여부를 제어할 수 있습니다.

사용 가능한 자리 표시자는 범위에 따라 다릅니다:

| 범위 | 머리글 | 바닥글 | 날짜/시간 | 슬라이드/페이지 번호 |
|---|---|---|---|---|
| 보통 슬라이드 | 없음 | 있음 | 있음 | 있음 |
| 노트 마스터 | 있음 | 있음 | 있음 | 있음 |
| 노트 슬라이드 | 있음 | 있음 | 있음 | 있음 |
| 유인물 마스터 | 있음 | 있음 | 있음 | 있음 |

보통 프레젠테이션 슬라이드에는 머리글 자리 표시자가 없습니다. 머리글은 노트 페이지와 유인물에서 사용할 수 있습니다. 보통 슬라이드에서는 대신 바닥글, 날짜/시간 및 슬라이드 번호 자리 표시자를 사용하십시오.

변경의 범위는 사용하는 관리자에 따라 달라집니다. [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slideheaderfootermanager/) 클래스는 하나의 보통 슬라이드를 제어합니다. [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/notesslideheaderfootermanager/) 클래스는 하나의 노트 슬라이드를 제어합니다. 마스터 및 레이아웃 관리자는 종속 슬라이드에 설정을 전파할 수 있으며, [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) 클래스는 유인물 마스터를 제어합니다.

## **보통 슬라이드에 바닥글, 날짜/시간 및 슬라이드 번호 설정**

보통 슬라이드의 기본 워크플로는 각 슬라이드의 헤더/바닥글 관리자에 접근하여 바닥글 및 날짜/시간 텍스트를 설정하고 필요한 자리 표시자를 활성화한 뒤 프레젠테이션을 저장하는 것입니다. 슬라이드 번호는 프레젠테이션에서 자동으로 생성되므로 표시 여부만 제어하면 됩니다.

텍스트를 설정하려면 [`set_footer_text`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) 및 [`set_date_time_text`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/)를 사용하고, 해당 자리 표시자를 표시하려면 [`set_footer_visibility`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/) 및 [`set_slide_number_visibility`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/)를 사용합니다.

다음 전체 예제는 모든 보통 슬라이드에 동일한 바닥글, 날짜/시간 텍스트 및 슬라이드 번호 표시를 적용합니다:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

하나의 슬라이드만 업데이트하려면 전체 컬렉션을 반복하는 대신 [`slides`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/slides/ko/) 컬렉션을 통해 해당 슬라이드에 직접 접근하십시오.

## **노트 마스터에 머리글 및 바닥글 설정**

노트 마스터는 노트 페이지에 대한 공통 서식 및 자리 표시자 동작을 정의합니다. 노트 마스터 자체만 변경하려면 [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masternotesslideheaderfootermanager/) 클래스를 사용하십시오.

다음 예제는 노트 마스터에 머리글, 바닥글 및 날짜/시간 텍스트를 설정하고 해당 마스터에서 지원되는 모든 자리 표시자를 표시합니다:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

프레젠테이션에 노트 마스터가 포함되지 않을 수 있으므로 변경하기 전에 반환값이 `None`인지 확인하십시오.

## **노트 마스터 설정을 하위 노트 슬라이드에 적용**

노트 마스터는 자체와 모든 종속 노트 슬라이드에 머리글 및 바닥글 설정을 적용할 수 있습니다. 동일한 설정을 노트 계층 전체에 적용하려면 [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masternotesslideheaderfootermanager/)의 전파 전용 메서드를 사용하십시오.

예를 들어, [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/)와 [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/)는 노트 마스터 머리글과 모든 하위 머리글을 업데이트합니다. 바닥글, 날짜/시간 및 슬라이드 번호에 대한 동등한 메서드도 제공됩니다.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

위에서 사용한 전파 메서드는 [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/), 및 [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/)입니다.

## **개별 노트 슬라이드에 머리글 및 바닥글 설정**

노트 슬라이드는 특정 보통 슬라이드에 속합니다. 해당 노트 페이지만 사용자 지정하려면 [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/notesslideheaderfootermanager/) 클래스를 사용하십시오.

[`add_notes_slide`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/notesslidemanager/add_notes_slide/) 메서드는 현재 슬라이드에 대한 노트 슬라이드를 반환하고, 아직 존재하지 않으면 생성합니다. 다음 예제는 첫 번째 프레젠테이션 슬라이드와 연결된 노트 페이지를 구성합니다:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

먼저 노트 마스터에서 설정을 전파한 다음 개별 노트 슬라이드를 변경하면 이후의 슬라이드별 설정을 통해 해당 노트 페이지를 독립적으로 사용자 지정할 수 있습니다.

## **유인물 마스터에 머리글 및 바닥글 설정**

유인물 페이지는 머리글, 바닥글, 날짜/시간 및 페이지 번호 자리 표시자를 위해 유인물 마스터를 사용합니다. 노트 페이지와 달리 유인물 설정은 개별 유인물 슬라이드가 아니라 유인물 마스터를 통해 관리됩니다.

`master_handout_slide` 속성을 사용하여 유인물 마스터에 접근하십시오. 마스터가 없을 경우 [`set_default_master_handout_slide`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/)을 호출하여 기본 유인물 마스터를 생성합니다.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **범위 및 상속 이해**

변경하려는 범위에 맞는 헤더/바닥글 관리자를 선택하십시오:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slideheaderfootermanager/)은 하나의 보통 슬라이드에 대한 바닥글, 날짜/시간 및 슬라이드 번호 설정을 변경합니다.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslideheaderfootermanager/)은 레이아웃 슬라이드를 제어하고 지원되는 설정을 종속 슬라이드에 전파할 수 있습니다.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslideheaderfootermanager/)은 일반 슬라이드 마스터를 제어하고 지원되는 설정을 종속 슬라이드에 전파할 수 있습니다.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masternotesslideheaderfootermanager/)은 노트 마스터를 제어하고 모든 종속 노트 슬라이드에 설정을 전파할 수 있습니다.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/notesslideheaderfootermanager/)은 하나의 노트 슬라이드를 변경하며 머리글 자리 표시자와 함께 바닥글, 날짜/시간 및 슬라이드 번호를 지원합니다.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterhandoutslideheaderfootermanager/)은 유인물 마스터를 변경하고 네 가지 자리 표시자 유형을 모두 지원합니다.

동일한 설정을 전체 계층에 적용해야 할 경우 마스터 또는 레이아웃에서 전파를 사용하십시오. 한 페이지에만 로컬 설정이 필요할 때는 개별 슬라이드 또는 노트 슬라이드 관리자를 사용하십시오.

## **FAQ**

**보통 슬라이드에 머리글을 추가할 수 있나요?**

아니요. PowerPoint는 보통 슬라이드에 머리글 자리 표시자를 정의하지 않습니다. 보통 슬라이드에서는 바닥글, 날짜/시간 및 슬라이드 번호 자리 표시자를 사용하십시오. 머리글 자리 표시자는 노트 페이지와 유인물에 제공됩니다.

**바닥글, 날짜/시간 또는 슬라이드 번호 자리 표시자가 표시되지 않으면 어떻게 해야 하나요?**

해당 헤더/바닥글 관리자를 사용하여 표시 여부를 확인하고 필요할 때 활성화하십시오. 예를 들어, [`is_footer_visible`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/)은 바닥글 자리 표시자가 존재하는지 여부를 반환하고, [`set_footer_visibility`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/)은 표시 여부를 변경합니다.

**슬라이드 번호를 1이 아닌 다른 값부터 시작하려면 어떻게 합니까?**

프레젠테이션의 [`first_slide_number`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/first_slide_number/) 속성을 설정하십시오. 그러면 슬라이드 번호 자리 표시자는 업데이트된 번호 순서를 사용합니다.

**PDF, 이미지 또는 HTML로 내보낼 때 머리글과 바닥글은 어떻게 처리되나요?**

표시된 머리글 및 바닥글 요소는 출력 형식의 프레젠테이션 콘텐츠와 함께 렌더링됩니다. 그 외관은 내보내는 페이지 유형 및 해당 자리 표시자의 가시성 설정에 따라 달라집니다.