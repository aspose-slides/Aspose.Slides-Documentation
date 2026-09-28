---
title: Python에서 슬라이드 레이아웃 적용 및 변경
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
- 바닥글 가시성
- 제목 슬라이드
- 제목 및 내용
- 섹션 헤더
- 두 콘텐츠
- 비교
- 제목만
- 빈 레이아웃
- 캡션이 있는 콘텐츠
- 캡션이 있는 그림
- 제목 및 세로 텍스트
- 세로 제목 및 텍스트
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 .NET을 통해 사용하여 슬라이드 레이아웃을 적용, 생성 및 수정하고, 자리표시자를 추가하고, 사용되지 않은 레이아웃을 제거하며, 바닥글 가시성을 제어합니다."
---
## **개요**

슬라이드 레이아웃은 제목, 텍스트, 그림, 차트 및 표와 같은 자리표시자의 위치와 형식을 정의합니다. 레이아웃을 적용하면 슬라이드가 일관된 구조를 가지면서도 각 슬라이드가 자체 콘텐츠를 포함할 수 있습니다.

가장 일반적인 레이아웃은 다음과 같습니다:

- **제목 슬라이드**: 제목 및 부제목 자리표시자를 포함합니다.
- **제목 및 내용**: 제목 자리표시자와 범용 콘텐츠 자리표시자를 포함합니다.
- **빈**: 콘텐츠 자리표시자가 없으며 모든 도형을 수동으로 배치할 때 유용합니다.

## **레이아웃 상속 이해**

프레젠테이션에는 서로 관련된 세 가지 수준이 있습니다:

1. A [마스터 슬라이드](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslide/) 정의는 테마, 공유 형식, 배경 및 공통 개체를 정의합니다.
2. A [레이아웃 슬라이드](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/) 은 마스터에 속하며 특정 자리표시자 배열을 정의합니다.
3. A [일반 슬라이드](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/) 은 하나의 레이아웃을 사용하고 해당 슬라이드에 입력된 콘텐츠를 저장합니다.

일반 슬라이드는 레이아웃으로부터 테마와 형식을 상속하고, 레이아웃은 마스터로부터 상속합니다. 일반 슬라이드에 직접 설정된 값은 해당 수준에서 상속된 값을 덮어씁니다. 일반 슬라이드가 생성될 때, 그 자리표시자 도형은 선택된 레이아웃에서 생성되며, 해당 자리표시자에 입력된 콘텐츠는 일반 슬라이드에 속합니다.

레이아웃에서 슬라이드를 만들기 전에 필요한 자리표시자를 추가하십시오. 나중에 레이아웃에 다른 자리표시자를 추가해도 기존 일반 슬라이드에 해당 자리표시자 도형이 자동으로 추가되지는 않습니다.

이 관계에는 두 가지 중요한 결과가 있습니다:

- 레이아웃에서 상속된 형식이나 기존 자리표시자 기하학을 변경하면 해당 레이아웃에 의존하는 모든 슬라이드가 업데이트될 수 있습니다. 이미 사용 중인 레이아웃을 편집하기 전에, 의존 슬라이드를 확인하고 결과 프레젠테이션을 검토하십시오.
- 슬라이드에서 아직 사용 중인 레이아웃은 제거할 수 없습니다. 먼저 해당 레이아웃에 의존하는 슬라이드를 다른 레이아웃으로 재할당하거나, 사용되지 않은 레이아웃만 제거하십시오.

이 계층 구조의 최상위에 대한 자세한 내용은 [슬라이드 마스터](/slides/ko/python-net/slide-master/)를 참조하십시오.

한 슬라이드에서 또는 공유 레이아웃을 통해 상속된 로고나 장식 마스터 도형을 숨기려면 [마스터 그래픽 가시성 제어](/slides/ko/python-net/slide-master/)를 보십시오. 이 예제는 동일한 마스터를 사용하는 두 슬라이드를 비교합니다.

## **슬라이드 레이아웃 선택 및 적용**

프레젠테이션이 표준 PowerPoint 레이아웃 정의를 따를 때 레이아웃 유형을 사용합니다. 레이아웃 이름은 사용자가 편집할 수 있으며 현지화될 수 있으므로, 소스 템플릿을 제어하지 않는 한 이름 기반 선택은 신뢰성이 떨어집니다.

다음 예제는 첫 번째 마스터에서 **제목 및 내용** 레이아웃을 찾습니다. 해당 레이아웃이 없으면 의도적으로 **빈** 레이아웃으로 대체합니다. 프레젠테이션에 사용자 정의 레이아웃만 포함될 수 있기 때문에 두 번째 null 검사가 필요합니다. 선택된 레이아웃은 [Slide.layout_slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/layout_slide/) 속성을 통해 첫 번째 일반 슬라이드에 적용됩니다.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

슬라이드의 레이아웃을 변경해도 슬라이드에 직접 추가된 일반 도형은 제거되지 않습니다. 하지만 자리표시자 위치, 상속된 형식 및 기존 자리표시자와 새로운 레이아웃 간의 매핑이 변경될 수 있으므로, 크게 다른 레이아웃으로 전환할 때 출력물을 확인하십시오.

## **레이아웃 슬라이드 추가**

선택과 생성을 별개의 작업으로 수행합니다. 이전 예제는 기존 레이아웃을 선택했으며, 레이아웃을 생성하지는 않았습니다. 레이아웃을 생성하려면 대상 마스터의 레이아웃 컬렉션에서 [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterlayoutslidecollection/add/) 메서드를 호출하십시오.

다음 예제는 `Report Title and Content` 라는 새 **제목 및 내용** 레이아웃을 항상 추가하고, 그 레이아웃을 기반으로 일반 슬라이드를 추가합니다. 레이아웃 이름은 컬렉션 내에서 고유해야 합니다.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

템플릿에 실제로 추가 재사용 가능한 구조가 필요할 때만 레이아웃을 추가하십시오. 적절한 레이아웃이 이미 존재한다면 중복을 만들지 말고 선택하여 재사용하십시오.

## **레이아웃 슬라이드에 자리표시자 추가**

[LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/placeholder_manager/) 속성은 레이아웃에 자리표시자 도형을 추가하기 위한 [LayoutPlaceholderManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/)를 제공합니다.

| PowerPoint 자리표시자               | LayoutPlaceholderManager 메서드 |
| ----------------------------------- | -------------------------------- |
| ![Content](content.png)             | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Content (Vertical)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Text](text.png)                   | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Text (Vertical)](textV.png)       | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Picture](picture.png)             | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Chart](chart.png)                 | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Table](table.png)                 | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)           | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Media](media.png)                 | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Online Image](onlineImage.png)    | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

다음 예제는 **빈** 레이아웃이 존재하는지 확인하고, 네 개의 자리표시자를 추가한 뒤 수정된 레이아웃을 사용하는 일반 슬라이드를 생성합니다. 순서는 의도된 것으로, 자리표시자는 일반 슬라이드가 생성되기 전에 추가되므로 Aspose.Slides가 해당 슬라이드에 대응하는 자리표시자 도형을 생성할 수 있습니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

결과:

![레이아웃 슬라이드의 자리표시자](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
상속된 형식이나 기존 레이아웃 자리표시자의 기하학을 변경하면 의존 슬라이드에 영향을 줄 수 있습니다. 새로 추가된 레이아웃 자리표시자는 기존 일반 슬라이드에 자동으로 채워지지 않습니다. 프레젠테이션 복사본에서 레이아웃 변경을 테스트하고 모든 의존 슬라이드를 확인하십시오.
{{% /alert %}}

## **사용되지 않는 레이아웃 슬라이드 제거**

[Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) 메서드를 사용하여 일반 슬라이드가 참조하지 않는 레이아웃을 제거합니다. 이 메서드는 여전히 사용 중인 레이아웃은 그대로 둡니다.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

특정 레이아웃을 제거하려면 먼저 해당 레이아웃의 [has_depending_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/has_depending_slides/) 속성이나 [get_depending_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/get_depending_slides/) 메서드를 사용하십시오. [LayoutSlide.remove](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/remove/)를 호출하기 전에 의존 슬라이드를 재할당합니다. 사용 중인 레이아웃을 제거하려고 하면 [PptxEditException](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pptxeditexception/)이 발생합니다.

## **레이아웃 슬라이드에서 바닥글 가시성 제어**

레이아웃에는 자체 바닥글, 슬라이드 번호 및 날짜‑시간 자리표시자가 있습니다. [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/header_footer_manager/) 속성을 사용하여 하나의 레이아웃에 대한 이러한 자리표시자를 제어할 수 있습니다. 예를 들어 콘텐츠 레이아웃은 바닥글을 표시하고 제목 레이아웃은 표시하지 않아야 할 경우에 유용합니다.

다음 예제는 레이아웃을 안전하게 선택하고 해당 바닥글 요소를 표시합니다:

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **마스터 및 하위 레이아웃에서 바닥글 가시성 제어**

마스터 계층 전체에 일관된 바닥글 설정을 적용하려면 [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslide/header_footer_manager/) 속성을 사용하십시오. [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslideheaderfootermanager/)의 전파 메서드는 마스터와 해당 의존 레이아웃 슬라이드 및 일반 슬라이드에 적용되며, 단일 일반 슬라이드만을 대상으로 하지는 않습니다.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**마스터 슬라이드와 레이아웃 슬라이드의 차이점은 무엇입니까?**

마스터 슬라이드는 프레젠테이션의 테마와 공유 형식을 정의합니다. 레이아웃 슬라이드는 마스터에 속하며, 하나의 재사용 가능한 자리표시자 배열을 정의합니다. 일반 슬라이드는 해당 레이아웃을 사용하고 슬라이드별 콘텐츠를 저장합니다.

**한 프레젠테이션에서 다른 프레젠테이션으로 레이아웃 슬라이드를 복사할 수 있습니까?**

예. [add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/globallayoutslidecollection/add_clone/) 메서드를 사용하여 대상 컬렉션에 복사본을 추가하면 됩니다. 프레젠테이션 간에 복사할 때는 원본 레이아웃에서 사용된 글꼴, 테마, 이미지 및 기타 리소스도 확인하십시오.

**이미 사용 중인 레이아웃을 수정하면 어떻게 됩니까?**

의존 슬라이드는 해당 레이아웃이 변경될 경우 로컬에서 영향을 받는 형식이나 객체를 재정의하지 않는 한 변경 내용을 상속합니다. 따라서 많은 슬라이드에서 자리표시자 기하학 및 상속된 스타일이 동시에 변경될 수 있습니다. 레이아웃을 편집하기 전에 [get_depending_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/get_depending_slides/)를 사용하여 영향을 받는 슬라이드를 확인하십시오.

**여전히 사용 중인 레이아웃을 제거하면 어떻게 됩니까?**

Aspose.Slides는 [PptxEditException](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pptxeditexception/)을 발생시킵니다. 먼저 의존 슬라이드를 재할당하거나, [remove_unused_layout_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/)를 사용하여 참조되지 않은 레이아웃만 제거하십시오.