---
title: Python에서 프레젠테이션 슬라이드 마스터 관리
linktitle: 슬라이드 마스터
type: docs
weight: 80
url: /ko/python-net/slide-master/
keywords:
- 슬라이드 마스터
- 마스터 슬라이드
- PPT 마스터 슬라이드
- 여러 마스터 슬라이드
- 마스터 슬라이드 비교
- 배경
- 플레이스홀더
- 마스터 슬라이드 복제
- 마스터 슬라이드 복사
- 마스터 슬라이드 중복
- 사용되지 않는 마스터 슬라이드
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET에서 슬라이드 마스터를 관리합니다: PowerPoint 및 OpenDocument 프레젠테이션에서 마스터 슬라이드를 액세스, 편집, 복제, 비교 및 제거합니다."
---
## **개요**

**슬라이드 마스터**는 그룹 슬라이드에 대한 공유 디자인 설정을 정의합니다. 일반 도형, 로고, 배경, 텍스트 스타일, 테마 설정 및 바닥글 설정을 포함할 수 있습니다. PowerPoint에서 슬라이드 마스터를 편집하는 것이 같은 형식을 모든 슬라이드에 반복하지 않고 프레젠테이션을 일관되게 유지하는 일반적인 방법입니다.

Aspose.Slides for Python via .NET은 동일한 모델을 지원합니다. 프레젠테이션에는 하나 이상의 마스터 슬라이드가 포함될 수 있으며, 각 마스터 슬라이드에는 여러 레이아웃 슬라이드가 포함될 수 있습니다. 일반 슬라이드는 보통 마스터 슬라이드를 직접 참조하지 않습니다. 대신 일반 슬라이드는 레이아웃 슬라이드를 사용하고, 해당 레이아웃 슬라이드는 마스터 슬라이드에 속합니다.

계층 구조는 다음과 같습니다:

1. **슬라이드 마스터** – 공유 디자인 및 테마를 정의합니다.  
1. **레이아웃 슬라이드** – 플레이스홀더와 레이아웃 수준 서식의 특정 배치를 정의합니다.  
1. **일반 슬라이드** – 실제 프레젠테이션 내용을 포함하고 하나의 레이아웃 슬라이드를 사용합니다.

![마스터 슬라이드, 레이아웃 슬라이드 및 일반 슬라이드의 계층 구조](slide-master_2.jpg)

Aspose.Slides에서 슬라이드 마스터는 [MasterSlide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslide/) 클래스로 표현됩니다. 프레젠테이션의 모든 마스터 슬라이드는 `Presentation.masters` 컬렉션을 통해 사용할 수 있습니다.

{{% alert color="info" title="Inheritance" %}}

같은 속성이 둘 이상의 레벨에서 정의된 경우, 더 구체적인 레벨이 우선합니다. 예를 들어 마스터 슬라이드와 레이아웃 슬라이드가 모두 배경을 정의하면 해당 레이아웃을 기반으로 하는 슬라이드는 레이아웃 배경을 사용합니다. 레이아웃 슬라이드에 대한 자세한 내용은 [Apply or Change Slide Layouts](/python-net/slide-layout/)를 참조하세요.

{{% /alert %}}

## **슬라이드 마스터 액세스**

PowerPoint에서는 **보기** > **슬라이드 마스터**를 통해 슬라이드 마스터 보기를 열 수 있습니다.

![PowerPoint 보기 탭에 있는 슬라이드 마스터 명령](slide-master_3.jpg)

Aspose.Slides에서는 `masters` 컬렉션을 사용하여 마스터 슬라이드에 액세스합니다:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

일반 슬라이드가 사용하는 레이아웃을 통해 해당 슬라이드가 사용 중인 마스터 슬라이드를 가져올 수도 있습니다:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **슬라이드 마스터에 포함된 내용**

마스터 슬라이드는 슬라이드와 유사한 객체입니다. [BaseSlide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslide/) 클래스로부터 일반 슬라이드 동작을 상속받아 일반 및 레이아웃 슬라이드와 동일한 많은 슬라이드 속성을 제공합니다. 마스터 전용 멤버는 [MasterSlide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslide/) API 페이지에 나열되어 있습니다.

일반적으로 사용되는 마스터 슬라이드 멤버는 다음과 같습니다:

| Member | Purpose |
| --- | --- |
| `background` | 마스터 수준 슬라이드 배경을 설정합니다. |
| `shapes` | 로고, 그림 프레임, 공유 텍스트 등 마스터에 배치된 도형을 저장합니다. |
| `layout_slides` | 마스터에 속한 레이아웃 슬라이드를 저장합니다. |
| `theme_manager` | 마스터 테마 API에 대한 접근을 제공합니다. |
| `header_footer_manager` | 마스터 및 해당 하위 레이아웃에 대한 머리글, 바닥글, 날짜 및 슬라이드 번호를 제어합니다. |
| `get_depending_slides` | 레이아웃을 통해 마스터에 종속된 일반 슬라이드를 반환합니다. |

## **슬라이드 마스터에 이미지 추가**

마스터 슬라이드에 이미지를 추가하면 해당 마스터의 레이아웃을 사용하는 슬라이드에 나타납니다. 로고, 워터마크, 장식 밴드 및 기타 반복되는 시각 요소에 유용합니다.

다음 예제는 첫 번째 마스터 슬라이드에 로고를 추가합니다:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

그림 프레임에 대한 자세한 내용은 [Picture Frame](/python-net/picture-frame/)를 참조하세요.

## **플레이스홀더 작업**

플레이스홀더는 일반적으로 레이아웃 슬라이드에 정의됩니다. 마스터 슬라이드는 해당 레이아웃이 상속받는 공유 스타일 및 테마를 제공하며, 각 레이아웃은 어떤 플레이스홀더가 사용 가능하고 어디에 배치되는지를 결정합니다.

PowerPoint에서는 슬라이드 마스터 보기에 플레이스홀더 명령이 제공됩니다.

![PowerPoint 슬라이드 마스터 보기에서 삽입 플레이스홀더 명령](slide-master_5.png)

Aspose.Slides에서 새 플레이스홀더를 추가하려면 마스터에 속한 레이아웃 슬라이드를 작업합니다:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

이미 마스터 슬라이드에 존재하는 플레이스홀더 도형을 서식 지정할 수도 있습니다. 다음 예제는 제목 플레이스홀더를 찾아 선형 그라데이션 채우기를 적용합니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![일반 슬라이드에 상속된 서식이 적용된 제목 플레이스홀더](slide-master_8.png)

플레이스홀더 및 텍스트 서식 옵션에 대한 자세한 내용은 [Set Prompt Text in Placeholder](/python-net/manage-placeholder/)와 [Text Formatting](/python-net/text-formatting/)을 참조하십시오.

## **슬라이드 마스터 배경 변경**

마스터 배경은 레이아웃 및 이를 재정의하지 않는 슬라이드에 상속됩니다. 다음 예제는 첫 번째 마스터 슬라이드에 단색 배경 색을 설정합니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

관련 주제는 [Presentation Background](/python-net/presentation-background/)와 [Presentation Theme](/python-net/presentation-theme/)를 참조하세요.

## **슬라이드 마스터를 다른 프레젠테이션에 복제**

[MasterSlideCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslidecollection/) 클래스의 `add_clone` 메서드를 사용하여 마스터 슬라이드를 다른 프레젠테이션에 복사합니다. 복제된 마스터는 대상 프레젠테이션의 레이아웃 및 슬라이드에서 사용할 수 있습니다.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

마스터와 함께 일반 슬라이드도 복제해야 하는 경우 [Clone Slides](/python-net/clone-slides/)를 참조하세요.

## **여러 슬라이드 마스터 추가**

프레젠테이션에 여러 마스터 슬라이드를 포함할 수 있습니다. 이는 섹션마다 다른 브랜딩, 페이지 구조 또는 테마 설정이 필요할 때 유용합니다.

![마스터 슬라이드 삽입 및 관리용 PowerPoint 명령](slide-master_9.jpg)

다음 예제는 기본 마스터를 복제하고 복제본에 다른 배경을 지정한 뒤, 해당 복제 마스터 아래에 빈 레이아웃을 가져와 그 레이아웃을 기반으로 새 슬라이드를 추가합니다:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **슬라이드 마스터 비교**

마스터 슬라이드는 [BaseSlide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslide/) 클래스에서 상속받은 `equals` 메서드를 사용하여 비교할 수 있습니다. 비교는 도형, 텍스트, 서식, 애니메이션 및 기타 슬라이드 설정과 같은 구조와 정적 콘텐츠를 확인합니다. 슬라이드 ID와 같은 고유 식별자나 현재 날짜와 같은 동적 플레이스홀더 값은 비교하지 않습니다.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

자세한 내용은 [Compare Presentation Slides](/python-net/compare-slides/)를 참조하세요.

## **슬라이드 마스터 보기를 기본 보기로 설정**

프레젠테이션 [ViewProperties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/)의 `last_view` 속성을 사용하면 PowerPoint가 처음 열 때 표시할 보기를 제어할 수 있습니다. 다음 예제는 프레젠테이션을 슬라이드 마스터 보기로 엽니다:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

다른 보기 설정에 대해서는 [Save Presentation](/python-net/save-presentation/)를 참조하십시오.

## **사용하지 않는 마스터 슬라이드 제거**

프레젠테이션에 사용되지 않는 마스터 슬라이드가 포함될 수 있습니다. 사용되지 않는 마스터를 제거하면 파일 크기를 줄이고 템플릿 관리를 간소화할 수 있습니다.

`masters` 컬렉션에서 `remove_unused`를 사용하여 사용되지 않는 마스터를 제거합니다:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

또는 [Compress](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/) 클래스의 저코드 `remove_unused_master_slides` 메서드를 사용할 수 있습니다:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**슬라이드 마스터와 레이아웃 슬라이드의 차이점은 무엇인가요?**

슬라이드 마스터는 테마, 배경, 공통 도형 및 텍스트 스타일과 같은 공유 디자인 설정을 정의합니다. 레이아웃 슬라이드는 마스터 슬라이드에 속하며 플레이스홀더의 특정 배치를 정의합니다. 일반 슬라이드는 레이아웃 슬라이드를 사용하므로 레이아웃과 마스터 양쪽으로부터 상속받습니다.

**하나의 프레젠테이션에 여러 슬라이드 마스터가 포함될 수 있나요?**

예. 프레젠테이션에 여러 슬라이드 마스터를 포함할 수 있습니다. 서로 다른 섹션에 서로 다른 시각 시스템이나 브랜딩이 필요할 때 여러 마스터를 사용하세요.

**플레이스홀더는 마스터 슬라이드에 추가해야 하나요, 레이아웃 슬라이드에 추가해야 하나요?**

대부분의 경우 레이아웃 슬라이드에 플레이스홀더를 추가합니다. 공유 시각 요소와 공유 서식은 마스터 슬라이드에 두고, 실제 콘텐츠 플레이스홀더는 일반 슬라이드가 사용할 레이아웃에 배치합니다.

**사용 중인 마스터 슬라이드를 삭제할 수 있나요?**

아니요. 종속된 슬라이드가 있는 마스터 슬라이드는 직접 삭제하면 안전하지 않습니다. 먼저 해당 슬라이드를 다른 마스터의 레이아웃으로 이동하거나, 사용되지 않은 마스터만 제거하는 정리 방법을 사용하세요.