---
title: "Python에서 슬라이드 레이아웃 적용 또는 변경"
linktitle: "슬라이드 레이아웃"
type: docs
weight: 60
url: /ko/python-net/slide-layout/
keywords:
  - "슬라이드 레이아웃"
  - "콘텐츠 레이아웃"
  - "자리표시자"
  - "프레젠테이션 디자인"
  - "슬라이드 디자인"
  - "사용되지 않는 레이아웃"
  - "바닥글 가시성"
  - "제목 슬라이드"
  - "제목 및 내용"
  - "섹션 헤더"
  - "두 개의 콘텐츠"
  - "비교"
  - "제목만"
  - "빈 레이아웃"
  - "캡션이 있는 콘텐츠"
  - "캡션이 있는 그림"
  - "제목 및 세로 텍스트"
  - "세로 제목 및 텍스트"
  - "PowerPoint"
  - "OpenDocument"
  - "프레젠테이션"
  - "Python"
  - "Aspose.Slides"
description: "Aspose.Slides for Python을 .NET을 통해 사용하여 슬라이드 레이아웃을 적용, 생성 및 수정하고, 자리표시자를 추가하며, 사용되지 않는 레이아웃을 제거하고, 바닥글 가시성을 제어합니다."
---
## **개요**

슬라이드 레이아웃은 제목, 텍스트, 그림, 차트 및 표와 같은 자리표시자의 위치와 서식을 정의합니다. 레이아웃을 적용하면 슬라이드마다 고유한 내용을 가질 수 있으면서도 일관된 구조를 유지할 수 있습니다.

가장 일반적인 레이아웃은 다음과 같습니다:

- **제목 슬라이드**: 제목 및 부제목 자리표시자를 포함합니다.
- **제목 및 내용**: 제목 자리표시자와 일반 목적의 내용 자리표시자를 포함합니다.
- **빈 슬라이드**: 내용 자리표시자가 없으며 모든 도형을 수동으로 배치할 때 유용합니다.

## **레이아웃 상속 이해**

프레젠테이션에는 세 가지 관련 수준이 있습니다:

1. A [마스터 슬라이드](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslide/) defines the theme, shared formatting, backgrounds, and common objects.
2. A [레이아웃 슬라이드](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/) belongs to a master and defines a particular arrangement of placeholders.
3. A [일반 슬라이드](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/) uses one layout and stores the content entered for that slide.

A normal slide inherits theme and formatting from its layout, and the layout inherits from its master. A value set directly on a normal slide overrides the inherited value at that level. When a normal slide is created, its placeholder shapes are generated from the selected layout, while the content entered into those placeholders belongs to the normal slide.

Add required placeholders to a layout before creating slides from it. Adding another placeholder to a layout later does not automatically add a corresponding placeholder shape to existing normal slides.

This relationship has two important consequences:

- Changing inherited formatting or existing placeholder geometry on a layout can update every slide that depends on it. Before editing a layout that is already in use, inspect its dependent slides and review the resulting presentation.
- A layout that is still used by a slide cannot be removed. Reassign its dependent slides to another layout first, or remove only unused layouts.

For more information about the top level of this hierarchy, see [Slide Master](/slides/ko/python-net/slide-master/).

## **슬라이드 레이아웃 선택 및 적용**

Use a layout type when the presentation follows standard PowerPoint layout definitions. Layout names are user-editable and can be localized, so name-based selection is less reliable unless you control the source template.

The following example looks for **Title and Content** on the first master. If that layout is unavailable, it deliberately falls back to **Blank**. The second null check is necessary because a presentation can contain only custom layouts. The selected layout is then applied to the first normal slide through the [Slide.layout_slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/layout_slide/) property.

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

Changing a slide's layout does not remove ordinary shapes added directly to the slide. However, placeholder positions, inherited formatting, and the correspondence between existing placeholders and the new layout can change, so inspect the output when switching between substantially different layouts.

## **레이아웃 슬라이드 추가**

Selection and creation are separate operations. The previous example selects an existing layout; it does not create one. To create a layout, call the [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterlayoutslidecollection/add/) method on the target master's layout collection.

The following example always adds a new **Title and Content** layout named `Report Title and Content`, then adds a normal slide based on it. Layout names must be unique within the collection.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Add a layout only when the template genuinely needs another reusable structure. If a suitable layout already exists, select and reuse it instead of creating a duplicate.

## **레이아웃 슬라이드에 자리표시자 추가**

The [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/placeholder_manager/) property provides a [LayoutPlaceholderManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/) for adding placeholder shapes to a layout.

| PowerPoint 자리표시자              | `LayoutPlaceholderManager` Method |
| ----------------------------------- | --------------------------------- |
| ![내용](content.png)             | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![내용 (세로)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![텍스트](text.png)                   | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![텍스트 (세로)](textV.png)       | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![그림](picture.png)             | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![차트](chart.png)                 | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![표](table.png)                 | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)           | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![미디어](media.png)                 | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![온라인 이미지](onlineImage.png)    | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

The following example verifies that the **Blank** layout exists, adds four placeholders to it, and then creates a normal slide that uses the modified layout. The order is intentional: the placeholders are added before the normal slide is created, so Aspose.Slides can generate the corresponding placeholder shapes on that slide.

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

The result:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="경고" %}}
Changing inherited formatting or the geometry of existing layout placeholders can affect dependent slides. A newly added layout placeholder is not backfilled into existing normal slides. Test layout changes on a copy of the presentation and inspect every dependent slide.
{{% /alert %}}

## **사용되지 않는 레이아웃 슬라이드 제거**

Use the [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) method to remove layouts that no normal slide references. The method leaves layouts that are still in use intact.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

To remove one specific layout, first use its [has_depending_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/has_depending_slides/) property or [get_depending_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/get_depending_slides/) method. Reassign any dependent slides before calling [LayoutSlide.remove](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/remove/). Attempting to remove a used layout raises a [PptxEditException](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pptxeditexception/).

## **레이아웃 슬라이드에서 바닥글 가시성 제어**

A layout has its own footer, slide-number, and date-time placeholders. Use the [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/header_footer_manager/) property to control those placeholders for one layout. This is useful when, for example, content layouts should show footers but title layouts should not.

The following example selects a layout safely and makes its footer elements visible:

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

## **마스터와 해당 자식 레이아웃에서 바닥글 가시성 제어**

To apply consistent footer settings across a master hierarchy, use the [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslide/header_footer_manager/) property. The propagation methods of [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/ko/python-net/aspose.slides/masterslideheaderfootermanager/) operate on the master and its dependent layout slides and normal slides; they do not target just one normal slide.

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

**What Is the Difference Between a Master Slide and a Layout Slide?**

A master slide defines the presentation's theme and shared formatting. A layout slide belongs to a master and defines one reusable arrangement of placeholders. Normal slides use those layouts and store slide-specific content.

**Can I Copy a Layout Slide from One Presentation to Another?**

Yes. Add a copy to the destination collection with the [add_clone](https://reference.aspose.com/slides/ko/python-net/aspose.slides/globallayoutslidecollection/add_clone/) method. When copying between presentations, also verify fonts, themes, images, and other resources used by the source layout.

**What Happens When I Modify a Layout That Is Already in Use?**

Dependent slides inherit the layout changes unless they override the affected formatting or objects locally. Placeholder geometry and inherited styling can therefore change on many slides at once. Use [get_depending_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/layoutslide/get_depending_slides/) to identify the affected slides before editing the layout.

**What Happens If I Remove a Layout That Is Still in Use?**

Aspose.Slides raises a [PptxEditException](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pptxeditexception/). Reassign the dependent slides first, or use [remove_unused_layout_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) to remove only unreferenced layouts.