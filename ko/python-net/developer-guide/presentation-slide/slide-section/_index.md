---
title: Python으로 프레젠테이션 슬라이드 섹션 관리
linktitle: 슬라이드 섹션
type: docs
weight: 100
url: /ko/python-net/slide-section/
keywords:
- 섹션 만들기
- 섹션 추가
- 섹션 편집
- 섹션 변경
- 섹션 이름
- 섹션 슬라이드 검색
- 섹션 슬라이드 처리
- PowerPoint
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PPTX 프레젠테이션에서 슬라이드 섹션을 관리합니다: 만들기, 이름 바꾸기, 순서 변경, 검색 및 처리."
---
## **소개**

Sections organize consecutive slides into named groups without changing the slide content. With Aspose.Slides for Python via .NET, you can create, reorder, rename, inspect, and remove sections through the [Presentation.sections](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/sections/) property.

Sections are especially useful when:

- a large presentation needs to be divided into logical topics or chapters;
- different groups of slides are assigned to different collaborators;
- slides need to be processed, moved, or merged as groups.

Choose concise section names that describe the purpose of the grouped slides. Because sections are part of the presentation structure, use the section APIs to determine membership instead of deriving it from slide positions.

## **섹션 만들기 및 관리**

Use [SectionCollection.add_section](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sectioncollection/add_section/) to create a section by specifying its name and starting slide. Aspose.Slides determines which slides belong to the section from the presentation's current section structure.

The same [SectionCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sectioncollection/) also lets you:

- move a section together with its slides by using [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/);
- remove only the section definition with [SectionCollection.remove_section](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sectioncollection/remove_section/), which retains its slides;
- remove a section and its slides with [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sectioncollection/remove_section_with_slides/);
- add an empty section at the end with [SectionCollection.append_empty_section](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sectioncollection/append_empty_section/).

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

## **섹션 이름 바꾸기**

To rename a section, set its [Section.name](https://reference.aspose.com/slides/ko/python-net/aspose.slides/section/name/) property. The section's slides and position remain unchanged.

The following example creates a section and changes its name:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **섹션에서 슬라이드 가져오기**

The [Presentation.sections](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/sections/) property returns a [SectionCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sectioncollection/) that you can iterate over. For each [Section](https://reference.aspose.com/slides/ko/python-net/aspose.slides/section/), call [Section.get_slides_list_of_section](https://reference.aspose.com/slides/ko/python-net/aspose.slides/section/get_slides_list_of_section/) to obtain the slides that currently belong to it. The method returns a [SectionSlideCollection](https://reference.aspose.com/slides/ko/python-net/aspose.slides/sectionslidecollection/), which provides a count, indexed access, and iteration.

The following example creates two populated sections and one empty section, then prints each section's [name](https://reference.aspose.com/slides/ko/python-net/aspose.slides/section/name/), [identifier](https://reference.aspose.com/slides/ko/python-net/aspose.slides/section/section_id/), [starting slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/section/started_from_slide/), slide count, and slide numbers. It uses indexed access to read the first slide and a `for` loop to process every slide. For the empty section, the returned collection has a count of zero, the index is not accessed, and iteration performs no steps.

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

Section membership is determined by the presentation's section structure. Do not calculate a section's range manually from [Section.started_from_slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/section/started_from_slide/), slide indexes, and the next section's starting slide.

Structural edits can change both the slides returned for a section and their slide numbers. This includes reordering slides, cloning a slide into a section, moving a section together with its slides, removing slides, and removing sections. The next example calls [Section.get_slides_list_of_section](https://reference.aspose.com/slides/ko/python-net/aspose.slides/section/get_slides_list_of_section/) after every such change instead of retaining assumptions about the section's former boundaries.

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

Call [Section.get_slides_list_of_section](https://reference.aspose.com/slides/ko/python-net/aspose.slides/section/get_slides_list_of_section/) again whenever slides or sections are reordered, cloned, moved, or removed. This keeps subsequent processing aligned with the current presentation structure.

The PPT (PowerPoint 97–2003) format does not preserve section metadata. Use this workflow with a format that supports sections, such as PPTX; converting to PPT removes the section structure needed for later iteration.

## **FAQ**

**PPT(PowerPoint 97–2003) 형식으로 저장할 때 섹션이 보존되나요?**

No. The PPT format does not support section metadata, so section grouping is lost when saving to .ppt.

**전체 섹션을 "숨김" 처리할 수 있나요?**

No. A section has no visibility state. To hide its contents, set the [Slide.hidden](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/hidden/) property for each slide in the section.

**슬라이드를 포함하는 섹션을 어떻게 찾을 수 있나요?**

Iterate over [Presentation.sections](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/sections/), call [Section.get_slides_list_of_section](https://reference.aspose.com/slides/ko/python-net/aspose.slides/section/get_slides_list_of_section/) for each section, and compare the returned slides with the target slide. For a non-empty section, [Section.started_from_slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/section/started_from_slide/) returns its first slide; for an empty section, it returns `None`.