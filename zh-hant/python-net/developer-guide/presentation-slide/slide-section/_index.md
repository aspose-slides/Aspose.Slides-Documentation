---
title: 使用 Python 管理簡報中的投影片區段
linktitle: 投影片區段
type: docs
weight: 100
url: /zh-hant/python-net/slide-section/
keywords:
- 建立區段
- 新增區段
- 編輯區段
- 更改區段
- 區段名稱
- 取得區段投影片
- 處理區段投影片
- PowerPoint
- 簡報
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 管理投影片區段：在 PPTX 簡報中建立、重新命名、重新排序、取得與處理區段投影片。"
---
## **Introduction**

Sections organize consecutive slides into named groups without changing the slide content. With Aspose.Slides for Python via .NET, you can create, reorder, rename, inspect, and remove sections through the [Presentation.sections](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/sections/) property.

Sections are especially useful when:

- 大型簡報需要分成邏輯主題或章節；
- 不同投影片群組指派給不同的協作者；
- 投影片需要作為群組進行處理、移動或合併。

請選擇簡潔的部分名稱，以描述該群組投影片的用途。由於部分是簡報結構的一部份，請使用部分 API 來判斷所屬關係，而不要根據投影片位置推算。

## **Create and Manage Sections**

Use [SectionCollection.add_section](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sectioncollection/add_section/) to create a section by specifying its name and starting slide. Aspose.Slides determines which slides belong to the section from the presentation's current section structure.

The same [SectionCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sectioncollection/) also lets you:

- 使用 [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/) 搬移包含投影片的部分；
- 僅使用 [SectionCollection.remove_section](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sectioncollection/remove_section/) 移除部分定義，保留其投影片；
- 使用 [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sectioncollection/remove_section_with_slides/) 移除部分及其投影片；
- 使用 [SectionCollection.append_empty_section](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sectioncollection/append_empty_section/) 在末尾新增空白部分。

The following example creates two sections, moves one of them, removes it together with its slides, and appends an empty section:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    title_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    results_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", title_slide)
    results_section = presentation.sections.add_section("Results", results_slide)

    presentation.sections.reorder_section_with_slides(results_section, 0)
    presentation.sections.remove_section_with_slides(results_section)
    presentation.sections.append_empty_section("Appendix")
```

After these operations, the presentation contains the `Introduction` section with its slides and an empty `Appendix` section. The `Results` section and its slides have been removed.

## **Rename Sections**

To rename a section, set its [Section.name](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/section/name/) property. The section's slides and position remain unchanged.

The following example creates a section and changes its name:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **Retrieve Slides from Sections**

The [Presentation.sections](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/sections/) property returns a [SectionCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sectioncollection/) that you can iterate over. For each [Section](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/section/), call [Section.get_slides_list_of_section](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/section/get_slides_list_of_section/) to obtain the slides that currently belong to it. The method returns a [SectionSlideCollection](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/sectionslidecollection/), which provides a count, indexed access, and iteration.

The following example creates two populated sections and one empty section, then prints each section's [name](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/section/name/), [identifier](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/section/section_id/), [starting slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/section/started_from_slide/), slide count, and slide numbers. It uses indexed access to read the first slide and a `for` loop to process every slide. For the empty section, the returned collection has a count of zero, the index is not accessed, and iteration performs no steps.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", first_slide)
    presentation.sections.add_section("Details", third_slide)
    presentation.sections.append_empty_section("Appendix")

    for section in presentation.sections:
        section_slides = section.get_slides_list_of_section()
        starting_slide = "none" if section.started_from_slide is None else str(section.started_from_slide.slide_number)

        print(f"Section: {section.name}")
        print(f"ID: {section.section_id}")
        print(f"Starting slide: {starting_slide}")
        print(f"Slide count: {section_slides.count}")

        if section_slides.count > 0:
            print(f"First slide via index: {section_slides[0].slide_number}")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(f" {slide.slide_number}", end="")
        print()
```

Section membership is determined by the presentation's section structure. Do not calculate a section's range manually from [Section.started_from_slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/section/started_from_slide/), slide indexes, and the next section's starting slide.

Structural edits can change both the slides returned for a section and their slide numbers. This includes reordering slides, cloning a slide into a section, moving a section together with its slides, removing slides, and removing sections. The next example calls [Section.get_slides_list_of_section](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/section/get_slides_list_of_section/) after every such change instead of retaining assumptions about the section's former boundaries.

```py
import aspose.slides as slides


def print_section_slides(label, section):
    section_slides = section.get_slides_list_of_section()
    print(f"{label} ({section_slides.count} slides):", end="")
    for slide in section_slides:
        print(f" {slide.slide_number}", end="")
    print()


with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    first_section = presentation.sections.add_section("First", first_slide)
    second_section = presentation.sections.add_section("Second", third_slide)

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.get_slides_list_of_section()
    presentation.slides.add_clone(slides_before_clone[0], first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.get_slides_list_of_section()
    first_section_position = slides_before_reorder[0].slide_number - 1
    presentation.slides.reorder(first_section_position, slides_before_reorder[slides_before_reorder.count - 1])
    print_section_slides("After reordering slides", first_section)

    presentation.sections.reorder_section_with_slides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.get_slides_list_of_section()
    presentation.slides.remove(slides_before_removal[0])
    print_section_slides("After removing a slide", first_section)

    presentation.sections.remove_section_with_slides(second_section)
    for section in presentation.sections:
        print_section_slides("Remaining section", section)
```

Call [Section.get_slides_list_of_section](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/section/get_slides_list_of_section/) again whenever slides or sections are reordered, cloned, moved, or removed. This keeps subsequent processing aligned with the current presentation structure.

The PPT (PowerPoint 97–2003) format does not preserve section metadata. Use this workflow with a format that supports sections, such as PPTX; converting to PPT removes the section structure needed for later iteration.

## **FAQ**

**Are sections preserved when saving to the PPT (PowerPoint 97–2003) format?**

No. The PPT format does not support section metadata, so section grouping is lost when saving to .ppt.

**Can an entire section be "hidden"?**

No. A section has no visibility state. To hide its contents, set the [Slide.hidden](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/slide/hidden/) property for each slide in the section.

**How can I find the section that contains a slide?**

Iterate over [Presentation.sections](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/presentation/sections/), call [Section.get_slides_list_of_section](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/section/get_slides_list_of_section/) for each section, and compare the returned slides with the target slide. For a non-empty section, [Section.started_from_slide](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/section/started_from_slide/) returns its first slide; for an empty section, it returns `None`.