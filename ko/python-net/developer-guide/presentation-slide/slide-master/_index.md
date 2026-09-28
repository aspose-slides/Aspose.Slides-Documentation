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
- 다중 마스터 슬라이드
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

A **슬라이드 마스터** defines shared design settings for a group of slides. It can contain common shapes, logos, backgrounds, text styles, theme settings, and footer settings. In PowerPoint, editing a slide master is the usual way to keep a presentation consistent without repeating the same formatting on every slide.

Aspose.Slides for Python via .NET supports the same model. A presentation can contain one or more master slides, and each master slide can contain several layout slides. Normal slides do not usually refer to a master slide directly. Instead, a normal slide uses a layout slide, and that layout slide belongs to a master slide.

The hierarchy is:

1. **슬라이드 마스터** - defines the shared design and theme.  
1. **레이아웃 슬라이드** - defines a specific arrangement of placeholders and layout-level formatting.  
1. **일반 슬라이드** - contains the actual presentation content and uses one layout slide.

![마스터 슬라이드, 레이아웃 슬라이드 및 일반 슬라이드의 계층 구조](slide-master_2.jpg)

In Aspose.Slides, a slide master is represented by the [MasterSlide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslide/) class. All master slides in a presentation are available through the `Presentation.masters` collection.

{{% alert color="info" title="상속" %}}
When the same property is defined at more than one level, the more specific level wins. For example, if a master slide and a layout slide both define a background, slides based on that layout use the layout background. For more information about layout slides, see [슬라이드 레이아웃 적용 또는 변경](/slides/ko/python-net/slide-layout/).
{{% /alert %}}

## **슬라이드 마스터 액세스**

In PowerPoint, you can open the Slide Master view from **View** > **Slide Master**.

![PowerPoint 보기 탭에 있는 슬라이드 마스터 명령](slide-master_3.jpg)

In Aspose.Slides, use the `masters` collection to access master slides:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

You can also get the master slide used by a normal slide through its layout:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **슬라이드 마스터에 포함되는 내용**

A master slide is a slide-like object. It inherits common slide behavior from the [BaseSlide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslide/) class, so it exposes many of the same slide properties used by normal and layout slides. Master-specific members are listed on the [MasterSlide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslide/) API page.

Commonly used master slide members include:

| Member | 용도 |
| --- | --- |
| `background` | 마스터 수준 슬라이드 배경을 설정합니다. |
| `shapes` | 로고, 그림 프레임 및 공유 텍스트와 같이 마스터에 배치된 도형을 저장합니다. |
| `layout_slides` | 마스터에 속하는 레이아웃 슬라이드를 저장합니다. |
| `theme_manager` | 마스터 테마 API에 대한 액세스를 제공합니다. |
| `header_footer_manager` | 마스터와 해당 하위 레이아웃의 머리글, 바닥글, 날짜 및 슬라이드 번호를 제어합니다. |
| `get_depending_slides` | 레이아웃을 통해 마스터에 의존하는 일반 슬라이드를 반환합니다. |

## **슬라이드 마스터에 이미지 추가**

When you add an image to a master slide, it appears on slides that use layouts from that master. This is useful for logos, watermarks, decorative bands, and other repeated visual elements.

The following example adds a logo to the first master slide:

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

For more information about picture frames, see [그림 프레임](/slides/ko/python-net/picture-frame/).

## **마스터 그래픽 가시성 제어**

Use [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslide/show_master_shapes/) to hide inherited master graphics, such as logos or decorative shapes, without deleting them from the master. Set [Slide.show_master_shapes](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/show_master_shapes/) to `False` on the slide that should omit those graphics and keep it `True` on slides that should display them.

The following self-contained example creates a blue decorative band on a master and two slides that use the same blank layout. The band is visible on the first slide and hidden on the second. No input presentation or image is required.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

The example uses the **Blank** layout supplied with a new presentation and removes the initial slide's own placeholders.

### **설정 범위 선택**

A normal slide uses its master through [Slide.layout_slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/layout_slide/) and [LayoutSlide.master_slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/master_slide/). Setting the property on an individual slide affects only that slide. Setting [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/show_master_shapes/) to `False` hides master graphics for slides that use that shared layout, even if their own setting is `True`. To hide graphics on just one slide, change the slide property and leave the shared layout unchanged.

The setting is not supported as a visibility control on the master slide itself. On a master it always returns `False`, and assigning `True` raises an exception. Apply it to a normal slide or a layout instead.

### **그래픽과 배경 구분**

| Operation | Effect |
| --- | --- |
| 마스터 그래픽 숨기기 | 도형을 삭제하거나 슬라이드 자체 도형을 변경하지 않고 상속된 마스터 도형의 가시성을 제어합니다. |
| 슬라이드 배경 채우기 변경 | 배경 색상, 그라디언트 또는 이미지를 변경합니다. 마스터 그래픽은 별도 도형이므로 해당 배경 위에 계속 표시될 수 있습니다. See [Presentation Background](/slides/ko/python-net/presentation-background/). |
| 마스터에서 도형 삭제 | 공유 소스 도형을 제거하므로 해당 마스터를 사용하는 어떤 슬라이드에서도 더 이상 사용할 수 없습니다. |

## **플레이스홀더 작업**

Placeholders are normally defined on layout slides. The master slide provides the shared style and theme that those layouts inherit, while each layout decides which placeholders are available and where they are placed.

In PowerPoint, placeholder commands are available in Slide Master view.

![PowerPoint 슬라이드 마스터 보기의 삽입 플레이스홀더 명령](slide-master_5.png)

To add new placeholders with Aspose.Slides, work with the layout slide that belongs to the master:

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

You can also format placeholder shapes that already exist on a master slide. The following example finds the title placeholder and applies a linear gradient fill:

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![일반 슬라이드가 상속한 서식이 지정된 제목 플레이스홀더](slide-master_8.png)

For more placeholder and text formatting options, see [플레이스홀더에 프롬프트 텍스트 설정](/slides/ko/python-net/manage-placeholder/) and [텍스트 서식](/slides/ko/python-net/text-formatting/).

## **슬라이드 마스터 배경 변경**

A master background is inherited by layouts and slides that do not override it. The following example sets a solid background color for the first master slide:

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

For related topics, see [Presentation Background](/slides/ko/python-net/presentation-background/) and [Presentation Theme](/slides/ko/python-net/presentation-theme/).

## **슬라이드 마스터를 다른 프레젠테이션에 복제**

Use the `add_clone` method on the [MasterSlideCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslidecollection/) class to copy a master slide into another presentation. The copied master can then be used by layouts and slides in the destination presentation.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

If you need to clone normal slides together with their master, see [슬라이드 복제](/slides/ko/python-net/clone-slides/).

## **다중 슬라이드 마스터 추가**

A presentation can contain multiple master slides. This is useful when different sections require different branding, page structure, or theme settings.

![마스터 슬라이드 삽입 및 관리에 대한 PowerPoint 명령](slide-master_9.jpg)

The following example clones the default master, gives the clone a different background, gets a blank layout under that cloned master, and adds a new slide based on that layout:

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

Master slides can be compared with the `equals` method inherited from the [BaseSlide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/baseslide/) class. The comparison checks structure and static content, such as shapes, text, formatting, animations, and other slide settings. It does not compare unique identifiers, such as slide IDs, or dynamic placeholder values, such as the current date.

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

For more information, see [프레젠테이션 슬라이드 비교](/slides/ko/python-net/compare-slides/).

## **슬라이드 마스터 보기를 기본 보기로 설정**

Use the `last_view` property on the presentation [ViewProperties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/viewproperties/) to control the view that PowerPoint opens first. The following example opens the presentation in Slide Master view:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

For more view settings, see [프레젠테이션 저장](/slides/ko/python-net/save-presentation/).

## **사용되지 않는 마스터 슬라이드 제거**

Presentations sometimes contain master slides that are no longer used by any normal slides. Removing unused masters can reduce file size and simplify template maintenance.

Use `remove_unused` to remove unused masters from the `masters` collection:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

You can also use the low-code `remove_unused_master_slides` method from the [Compress](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/) class:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**슬라이드 마스터와 레이아웃 슬라이드의 차이점은 무엇인가요?**

슬라이드 마스터는 테마, 배경, 공통 도형 및 텍스트 스타일과 같은 공유 디자인 설정을 정의합니다. 레이아웃 슬라이드는 마스터에 속하며 플레이스홀더의 구체적인 배치를 정의합니다. 일반 슬라이드는 레이아웃 슬라이드를 사용하므로 레이아웃과 마스터 모두로부터 상속받습니다.

**하나의 프레젠테이션에 여러 슬라이드 마스터를 포함할 수 있나요?**

예. 프레젠테이션은 여러 슬라이드 마스터를 포함할 수 있습니다. 섹션마다 다른 시각적 시스템이나 브랜딩이 필요할 때 여러 마스터를 사용하세요.

**플레이스홀더는 마스터 슬라이드에 추가해야 하나요, 레이아웃 슬라이드에 추가해야 하나요?**

대부분의 경우 레이아웃 슬라이드에 플레이스홀더를 추가합니다. 공유 시각 요소와 공통 서식을 마스터 슬라이드에 두고, 실제 콘텐츠 플레이스홀더는 일반 슬라이드가 사용할 레이아웃에 배치합니다.

**사용 중인 마스터 슬라이드를 삭제할 수 있나요?**

아니요. 종속 슬라이드가 있는 마스터 슬라이드는 직접 삭제할 수 없습니다. 먼저 해당 슬라이드를 다른 마스터의 레이아웃으로 이동하거나 사용되지 않는 마스터만 정리하는 방법을 사용하세요.