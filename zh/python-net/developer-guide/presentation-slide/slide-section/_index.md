---
title: 使用 Python 管理演示文稿中的幻灯片章节
linktitle: 幻灯片章节
type: docs
weight: 100
url: /zh/python-net/slide-section/
keywords:
- 创建章节
- 添加章节
- 编辑章节
- 更改章节
- 章节名称
- 检索章节幻灯片
- 处理章节幻灯片
- PowerPoint
- 演示文稿
- Python
- Aspose.Slides
description: "使用 Aspose.Slides for Python via .NET 管理幻灯片章节：在 PPTX 演示文稿中创建、重命名、重新排序、检索和处理章节幻灯片。"
---
## **介绍**

章节将连续的幻灯片组织成具名的组，而不会更改幻灯片内容。使用 Aspose.Slides for Python via .NET，您可以通过 [Presentation.sections](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/sections/) 属性创建、重新排序、重命名、检查和删除章节。

在以下情况下，章节特别有用：

- 大型演示文稿需要划分为逻辑主题或章节；
- 不同的幻灯片组分配给不同的协作者；
- 需要对幻灯片进行成组处理、移动或合并。

请为分组的幻灯片选择简洁的章节名称，以描述其用途。由于章节是演示文稿结构的一部分，请使用章节 API 来确定成员关系，而不是根据幻灯片位置推断。

## **创建和管理章节**

使用 [SectionCollection.add_section](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sectioncollection/add_section/) 可通过指定名称和起始幻灯片来创建章节。Aspose.Slides 根据演示文稿当前的章节结构确定哪些幻灯片属于该章节。

同一 [SectionCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sectioncollection/) 还可以让您：

- 使用 [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/) 将章节连同其幻灯片一起移动；
- 使用 [SectionCollection.remove_section](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sectioncollection/remove_section/) 仅删除章节定义，保留其幻灯片；
- 使用 [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sectioncollection/remove_section_with_slides/) 删除章节及其幻灯片；
- 使用 [SectionCollection.append_empty_section](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sectioncollection/append_empty_section/) 在末尾添加空章节。

下面的示例创建了两个章节，移动其中一个，连同其幻灯片一起删除它，并追加一个空章节：

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

执行这些操作后，演示文稿包含带有幻灯片的 `Introduction` 章节和一个空的 `Appendix` 章节。`Results` 章节及其幻灯片已被删除。

## **重命名章节**

要重命名章节，请设置其 [Section.name](https://reference.aspose.com/slides/zh/python-net/aspose.slides/section/name/) 属性。章节的幻灯片和位置保持不变。

下面的示例创建了一个章节并更改其名称：

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **从章节中检索幻灯片**

[Presentation.sections](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/sections/) 属性返回一个可遍历的 [SectionCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sectioncollection/)。对于每个 [Section](https://reference.aspose.com/slides/zh/python-net/aspose.slides/section/)，调用 [Section.get_slides_list_of_section](https://reference.aspose.com/slides/zh/python-net/aspose.slides/section/get_slides_list_of_section/) 可获取当前属于该章节的幻灯片。该方法返回一个 [SectionSlideCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/sectionslidecollection/)，提供计数、索引访问和迭代功能。

下面的示例创建了两个已填充的章节和一个空章节，然后打印每个章节的 [name](https://reference.aspose.com/slides/zh/python-net/aspose.slides/section/name/)、[identifier](https://reference.aspose.com/slides/zh/python-net/aspose.slides/section/section_id/)、[starting slide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/section/started_from_slide/)、幻灯片计数和幻灯片编号。它使用索引访问读取第一张幻灯片，并使用 `for` 循环处理每张幻灯片。对于空章节，返回的集合计数为零，索引未被访问，迭代不执行任何步骤。

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

章节成员资格由演示文稿的章节结构决定。请勿根据 [Section.started_from_slide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/section/started_from_slide/)、幻灯片索引以及下一个章节的起始幻灯片手动计算章节范围。

结构编辑可能会更改返回给章节的幻灯片以及它们的幻灯片编号。这包括重新排序幻灯片、将幻灯片克隆到章节、移动章节及其幻灯片、删除幻灯片以及删除章节。下一个示例在每次此类更改后调用 [Section.get_slides_list_of_section](https://reference.aspose.com/slides/zh/python-net/aspose.slides/section/get_slides_list_of_section/)，而不是保留对章节先前边界的假设。

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

每当幻灯片或章节被重新排序、克隆、移动或删除时，请再次调用 [Section.get_slides_list_of_section](https://reference.aspose.com/slides/zh/python-net/aspose.slides/section/get_slides_list_of_section/)。这样可确保后续处理与当前演示文稿结构保持一致。

PPT（PowerPoint 97–2003）格式不保留章节元数据。请使用支持章节的格式（如 PPTX）来执行此工作流；转换为 PPT 会移除后续迭代所需的章节结构。

## **常见问题**

**将章节保存为 PPT（PowerPoint 97–2003）格式时会被保留吗？**

不会。PPT 格式不支持章节元数据，保存为 .ppt 时章节分组会丢失。

**可以将整个章节“隐藏”吗？**

不能。章节没有可见性状态。若要隐藏其内容，需要为该章节中的每张幻灯片设置 [Slide.hidden](https://reference.aspose.com/slides/zh/python-net/aspose.slides/slide/hidden/) 属性。

**如何找到包含某张幻灯片的章节？**

遍历 [Presentation.sections](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/sections/)，对每个章节调用 [Section.get_slides_list_of_section](https://reference.aspose.com/slides/zh/python-net/aspose.slides/section/get_slides_list_of_section/)，并将返回的幻灯片与目标幻灯片进行比较。对于非空章节，[Section.started_from_slide](https://reference.aspose.com/slides/zh/python-net/aspose.slides/section/started_from_slide/) 返回其第一张幻灯片；对于空章节，则返回 `None`。