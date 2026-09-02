---
title: 使用 JavaScript 管理演示文稿中的幻灯片章节
linktitle: 幻灯片章节
type: docs
weight: 90
url: /zh/nodejs-java/slide-section/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "使用 Aspose.Slides for Node.js via Java 管理幻灯片章节：在 PPTX 演示文稿中创建、重命名、重新排序、检索和处理章节幻灯片。"
---
## **介绍**

章节将连续幻灯片组织为具名组，而不更改幻灯片内容。使用 Aspose.Slides for Node.js via Java，您可以通过 [Presentation.getSections](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getSections) 方法创建、重新排序、重命名、检查和删除章节。

章节在以下情况下尤为有用：

- 大型演示文稿需要划分为逻辑主题或章节；
- 不同的幻灯片组分配给不同的协作者；
- 幻灯片需要作为组进行处理、移动或合并。

请选择能够描述分组幻灯片用途的简洁章节名称。由于章节是演示文稿结构的一部分，请使用章节 API 来确定成员关系，而不要根据幻灯片位置推算。

## **创建和管理章节**

使用 [SectionCollection.addSection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sectioncollection/#addSection) 通过指定名称和起始幻灯片来创建章节。Aspose.Slides 根据演示文稿当前的章节结构确定哪些幻灯片属于该章节。

同一 [SectionCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sectioncollection/) 还可以让您：

- 使用 [SectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sectioncollection/#reorderSectionWithSlides) 将章节及其幻灯片一起移动；
- 仅使用 [SectionCollection.removeSection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sectioncollection/#removeSection) 删除章节定义，保留其幻灯片；
- 使用 [SectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sectioncollection/#removeSectionWithSlides) 删除章节及其幻灯片；
- 使用 [SectionCollection.appendEmptySection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sectioncollection/#appendEmptySection) 在末尾添加空章节。

下面的示例创建了两个章节，移动其中一个，将其连同幻灯片一起删除，并追加一个空章节：

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const titleSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    const resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

执行这些操作后，演示文稿包含带有幻灯片的 `Introduction` 章节和一个空的 `Appendix` 章节。`Results` 章节及其幻灯片已被删除。

## **重命名章节**

要重命名章节，请调用其 [Section.setName](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/section/#setName) 方法。章节的幻灯片和位置保持不变。

下面的示例创建了一个章节并更改其名称：

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **从章节检索幻灯片**

[Presentation.getSections](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getSections) 方法返回一个可按索引访问的 [SectionCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sectioncollection/)。对每个 [Section](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/section/) ，调用 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/section/#getSlidesListOfSection) 可获得当前属于该章节的幻灯片。该方法返回一个 [SectionSlideCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sectionslidecollection/)，提供计数和索引访问。

下面的示例创建了两个已填充的章节和一个空章节，然后打印每个章节的 [name](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/section/#getName)、[identifier](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/section/#getSectionId)、[starting slide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/section/#getStartedFromSlide)、幻灯片计数和幻灯片编号。它使用 [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/sectionslidecollection/#get_Item) 读取第一张幻灯片以及集合中的每张幻灯片。对于空章节，返回的集合大小为零，跳过索引访问，循环不执行任何操作。

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    const sections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < sections.size(); sectionIndex++) {
        const section = sections.get_Item(sectionIndex);
        const sectionSlides = section.getSlidesListOfSection();
        const startingSlideObject = section.getStartedFromSlide();
        const startingSlide = startingSlideObject === null ? "none" : startingSlideObject.getSlideNumber().toString();

        console.log("Section: " + section.getName());
        console.log("ID: " + section.getSectionId().toString());
        console.log("Starting slide: " + startingSlide);
        console.log("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            console.log("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        let slideNumbers = "Slide numbers:";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            slideNumbers += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(slideNumbers);
    }
} finally {
    presentation.dispose();
}
```

章节成员资格由演示文稿的章节结构决定。不要从 [Section.getStartedFromSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/section/#getStartedFromSlide)、幻灯片索引以及下一个章节的起始幻灯片手动计算章节范围。

结构性编辑可能会改变章节返回的幻灯片以及它们的幻灯片编号。包括重新排序幻灯片、将幻灯片克隆到章节、移动章节及其幻灯片、删除幻灯片以及删除章节。下面的示例在每次此类更改后调用 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/section/#getSlidesListOfSection)，而不是保留对章节先前边界的假设。

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    const firstSection = presentation.getSections().addSection("First", firstSlide);
    const secondSection = presentation.getSections().addSection("Second", thirdSlide);

    const printSectionSlides = (label, section) => {
        const sectionSlides = section.getSlidesListOfSection();
        let output = label + " (" + sectionSlides.size() + " slides):";
        for (let slideIndex = 0; slideIndex < sectionSlides.size(); slideIndex++) {
            output += " " + sectionSlides.get_Item(slideIndex).getSlideNumber();
        }
        console.log(output);
    };

    printSectionSlides("Initially", firstSection);

    const slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides("After cloning into the section", firstSection);

    const slidesBeforeReorder = firstSection.getSlidesListOfSection();
    const firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    const lastSlideInSection = slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1);
    presentation.getSlides().reorder(firstSectionPosition, lastSlideInSection);
    printSectionSlides("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides("After moving the section", firstSection);

    const slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    const remainingSections = presentation.getSections();
    for (let sectionIndex = 0; sectionIndex < remainingSections.size(); sectionIndex++) {
        printSectionSlides("Remaining section", remainingSections.get_Item(sectionIndex));
    }
} finally {
    presentation.dispose();
}
```

只要幻灯片或章节被重新排序、克隆、移动或删除，请再次调用 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/section/#getSlidesListOfSection)。这可确保后续处理与当前演示文稿结构保持一致。

PPT（PowerPoint 97–2003）格式不保留章节元数据。请在支持章节的格式（如 PPTX）中使用此工作流；转换为 PPT 会删除后续遍历所需的章节结构。

## **常见问题**

**保存为 PPT（PowerPoint 97–2003）格式时章节会被保留吗？**

不会。PPT 格式不支持章节元数据，因此保存为 .ppt 时章节分组会丢失。

**整个章节可以被“隐藏”吗？**

不会。章节没有可见性状态。要隐藏其内容，请对章节中的每张幻灯片调用 [Slide.setHidden](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/#setHidden)。

**如何查找包含某张幻灯片的章节？**

访问 [Presentation.getSections](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getSections) 返回的集合中的每个章节，对每个章节调用 [Section.getSlidesListOfSection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/section/#getSlidesListOfSection)，并将返回的幻灯片与目标幻灯片进行比较。对于非空章节，[Section.getStartedFromSlide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/section/#getStartedFromSlide) 返回其第一张幻灯片；对于空章节，它返回 `null`。