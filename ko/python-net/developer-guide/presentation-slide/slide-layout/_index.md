---
title: Python에서 슬라이드 레이아웃 적용 또는 변경
linktitle: 슬라이드 레이아웃
type: docs
weight: 60
url: /ko/python-net/slide-layout/
keywords:
- 슬라이드 레이아웃
- 콘텐츠 레이아웃
- 자리표시자
- 프레젠테이션 디자인
- 슬라이드 디자인
- 사용되지 않은 레이아웃
- 바닥글 표시 여부
- 제목 슬라이드
- 제목 및 내용
- 섹션 헤더
- 두 개의 콘텐츠
- 비교
- 제목만
- 빈 레이아웃
- 캡션이 있는 콘텐츠
- 캡션이 있는 그림
- 제목 및 세로 텍스트
- 세로 제목 및 텍스트
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python(.NET)를 사용하여 슬라이드 레이아웃을 관리하고 사용자 정의하는 방법을 배웁니다. 레이아웃 유형, 자리표시자 제어, 바닥글 표시 여부 및 레이아웃 조작을 Python 코드 예제로 탐색하십시오."
---
## **소개**

슬라이드 레이아웃은 슬라이드에 있는 콘텐츠에 대한 자리표시자 상자의 배치와 서식을 정의합니다. 사용 가능한 자리표시자와 그 위치를 제어합니다. 슬라이드 레이아웃을 사용하면 간단한 프레젠테이션이든 복잡한 프레젠테이션이든 빠르고 일관되게 디자인할 수 있습니다. PowerPoint에서 가장 일반적인 슬라이드 레이아웃은 다음과 같습니다:

**제목 슬라이드 레이아웃** – 두 개의 텍스트 자리표시자를 포함합니다: 하나는 제목용, 하나는 부제목용.

**제목 및 내용 레이아웃** – 상단에 작은 제목 자리표시자와 그 아래에 주요 콘텐츠(텍스트, 글머리표, 차트, 이미지 등)를 위한 큰 자리표시자를 배치합니다.

**빈 레이아웃** – 자리표시자가 없으며, 슬라이드를 처음부터 직접 설계할 수 있는 완전한 제어를 제공합니다.

슬라이드 레이아웃은 슬라이드 마스터의 일부이며, 슬라이드 마스터는 프레젠테이션에 대한 레이아웃 스타일을 정의하는 최상위 슬라이드입니다. 레이아웃 슬라이드는 유형, 이름 또는 고유 ID를 사용해 슬라이드 마스터를 통해 접근하고 수정할 수 있습니다. 또는 프레젠테이션 내에서 특정 레이아웃 슬라이드를 직접 편집할 수도 있습니다.

Aspose.Slides for Python에서 슬라이드 레이아웃을 사용하려면 다음을 사용할 수 있습니다:

- Presentation 클래스 아래의 [layout_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/layout_slides/) 및 [masters](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/masters/)와 같은 속성
- LayoutSlide, MasterLayoutSlideCollection, LayoutPlaceholderManager 및 LayoutSlideHeaderFooterManager와 같은 타입

{{% alert title="Info" color="info" %}}

마스터 슬라이드 작업에 대해 자세히 알아보려면 [Manage PowerPoint Slide Masters in Python](/slides/ko/python-net/slide-master/) 문서를 확인하십시오.

{{% /alert %}}

## **프레젠테이션에 슬라이드 레이아웃 추가**

슬라이드의 모양과 구조를 맞춤화하려면 프레젠테이션에 새 레이아웃 슬라이드를 추가해야 할 수 있습니다. Aspose.Slides for Python은 특정 레이아웃이 이미 존재하는지 확인하고, 필요하면 새 레이아웃을 추가한 뒤 해당 레이아웃을 기반으로 슬라이드를 삽입할 수 있도록 합니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
1. MasterLayoutSlideCollection에 접근합니다.
1. 컬렉션에 원하는 레이아웃 슬라이드가 이미 존재하는지 확인합니다. 없으면 필요한 레이아웃 슬라이드를 추가합니다.
1. 새 레이아웃 슬라이드를 기반으로 빈 슬라이드를 추가합니다.
1. 프레젠테이션을 저장합니다.

다음 Python 코드는 PowerPoint 프레젠테이션에 슬라이드 레이아웃을 추가하는 방법을 보여줍니다:

```python
import aspose.slides as slides

# Presentation 클래스를 인스턴스화하여 프레젠테이션 파일을 엽니다.
with slides.Presentation("sample.pptx") as presentation:
    # 레이아웃 슬라이드 유형을 순회하여 레이아웃 슬라이드를 선택합니다.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # 프레젠테이션에 모든 레이아웃 유형이 포함되지 않은 상황입니다.
        # 프레젠테이션 파일에는 빈 레이아웃과 사용자 정의 레이아웃 유형만 포함됩니다.
        # 하지만 사용자 정의 유형의 레이아웃 슬라이드에는 인식 가능한 이름이 있을 수 있습니다,
        # "Title", "Title and Content" 등과 같은 이름이 레이아웃 슬라이드 선택에 사용될 수 있습니다.
        # 또한 자리표시자 형태 유형 집합에 의존할 수도 있습니다.
        # 예를 들어, 제목 슬라이드에는 제목 자리표시자 유형만 있어야 합니다.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # 추가된 레이아웃 슬라이드를 사용하여 빈 슬라이드를 추가합니다.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # 프레젠테이션을 디스크에 저장합니다.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **사용되지 않는 레이아웃 슬라이드 제거**

Aspose.Slides는 Compress 클래스의 [remove_unused_layout_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) 메서드를 제공하여 원하지 않거나 사용되지 않는 레이아웃 슬라이드를 삭제할 수 있게 합니다.

다음 Python 코드는 PowerPoint 프레젠테이션에서 레이아웃 슬라이드를 제거하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **슬라이드 레이아웃에 자리표시자 추가**

Aspose.Slides는 [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/placeholder_manager/) 속성을 제공하며, 이를 사용해 레이아웃 슬라이드에 새 자리표시자를 추가할 수 있습니다.

이 매니저에는 다음 자리표시자 유형에 대한 메서드가 포함되어 있습니다:

| PowerPoint 자리표시자 | 메서드 |
| --------------------- | ------------------------------------------------------------ |
| ![콘텐츠](content.png) | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![콘텐츠(세로)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![텍스트](text.png) | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![텍스트(세로)](textV.png) | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![그림](picture.png) | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![차트](chart.png) | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![표](table.png) | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png) | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![미디어](media.png) | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![온라인 이미지](onlineimage.png) | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

다음 Python 코드는 빈 레이아웃 슬라이드에 새 자리표시자 모양을 추가하는 방법을 보여줍니다:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Blank 레이아웃 슬라이드를 가져옵니다.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # 레이아웃 슬라이드의 자리표시자 관리자를 가져옵니다.
    placeholder_manager = layout.placeholder_manager

    # Blank 레이아웃 슬라이드에 다양한 자리표시자를 추가합니다.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # Blank 레이아웃으로 새 슬라이드를 추가합니다.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![레이아웃 슬라이드의 자리표시자](add_placeholders.png)

## **레이아웃 슬라이드에 대한 바닥글 표시 설정**

PowerPoint 프레젠테이션에서 날짜, 슬라이드 번호, 사용자 정의 텍스트와 같은 바닥글 요소는 슬라이드 레이아웃에 따라 표시하거나 숨길 수 있습니다. Aspose.Slides for Python은 이러한 바닥글 자리표시자의 표시 여부를 제어할 수 있게 합니다. 이는 특정 레이아웃에서는 바닥글 정보를 표시하고 다른 레이아웃은 깔끔하게 유지하고 싶을 때 유용합니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 인덱스로 레이아웃 슬라이드 참조를 가져옵니다.
1. 슬라이드 바닥글 자리표시자를 보이도록 설정합니다.
1. 슬라이드 번호 자리표시자를 보이도록 설정합니다.
1. 날짜/시간 자리표시자를 보이도록 설정합니다.
1. 프레젠테이션을 저장합니다.

다음 Python 코드는 슬라이드 바닥글의 표시 여부를 설정하고 관련 작업을 수행하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```

## **슬라이드에 대한 하위 바닥글 표시 설정**

PowerPoint 프레젠테이션에서 날짜, 슬라이드 번호, 사용자 정의 텍스트와 같은 바닥글 요소는 마스터 슬라이드 수준에서 제어하여 모든 레이아웃 슬라이드에 일관성을 부여할 수 있습니다. Aspose.Slides for Python은 마스터 슬라이드에서 이러한 바닥글 자리표시자의 표시 및 내용을 설정하고 이러한 설정을 모든 하위 레이아웃 슬라이드에 전파하도록 합니다. 이 방식은 프레젠테이션 전체에 동일한 바닥글 정보를 유지하는 데 도움이 됩니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 인덱스로 마스터 슬라이드에 대한 참조를 가져옵니다.
1. 마스터와 모든 하위 바닥글 자리표시자를 보이도록 설정합니다.
1. 마스터와 모든 하위 슬라이드 번호 자리표시자를 보이도록 설정합니다.
1. 마스터와 모든 하위 날짜/시간 자리표시자를 보이도록 설정합니다.
1. 프레젠테이션을 저장합니다.

다음 Python 코드는 이 작업을 시연합니다:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**마스터 슬라이드와 레이아웃 슬라이드의 차이점은 무엇인가요?**

마스터 슬라이드는 전체 테마와 기본 서식을 정의하고, 레이아웃 슬라이드는 다양한 유형의 콘텐츠에 맞는 특정 자리표시자 배열을 정의합니다.

**한 프레젠테이션에서 다른 프레젠테이션으로 레이아웃 슬라이드를 복사할 수 있나요?**

예, 한 프레젠테이션의 [layout_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/layout_slides/) 컬렉션에서 레이아웃 슬라이드를 복제하고 `add_clone` 메서드를 사용해 다른 프레젠테이션에 삽입할 수 있습니다.

**여전히 슬라이드에서 사용 중인 레이아웃 슬라이드를 삭제하면 어떻게 되나요?**

프레젠테이션에 최소 하나의 슬라이드가 아직 해당 레이아웃 슬라이드를 참조하고 있는 상태에서 삭제를 시도하면 Aspose.Slides는 [PptxEditException](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pptxeditexception/)을 발생시킵니다. 이를 방지하려면 사용되지 않은 레이아웃 슬라이드만 안전하게 삭제하는 [remove_unused_layout_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/)를 사용하십시오.