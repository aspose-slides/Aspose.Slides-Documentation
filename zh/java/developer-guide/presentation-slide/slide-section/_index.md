---
title: 使用 Java 管理演示文稿中的幻灯片章节
linktitle: 幻灯片章节
type: docs
weight: 90
url: /zh/java/slide-section/
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
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Java 管理幻灯片章节：在 PPTX 演示文稿中创建、重命名、重新排序、检索和处理章节幻灯片。"
---
## **简介**

章节将连续的幻灯片组织为具有名称的组，而不更改幻灯片内容。使用 Aspose.Slides for Java，您可以通过 [Presentation.getSections](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getSections--) 方法创建、重新排序、重命名、检查和删除章节。

在以下情况下，章节尤其有用：

- 需要将大型演示文稿划分为逻辑主题或章节；
- 不同的幻灯片组分配给不同的协作者；
- 需要将幻灯片作为组进行处理、移动或合并。

请选择能够描述分组幻灯片目的的简洁章节名称。由于章节是演示文稿结构的一部分，请使用章节 API 来确定成员资格，而不是从幻灯片位置推断。

## **创建和管理章节**

使用 [ISectionCollection.addSection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isectioncollection/#addSection-java.lang.String-com.aspose.slides.ISlide-) 通过指定名称和起始幻灯片来创建章节。Aspose.Slides 根据演示文稿当前的章节结构确定哪些幻灯片属于该章节。

同一个 [ISectionCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isectioncollection/) 还允许您：

- 使用 [ISectionCollection.reorderSectionWithSlides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isectioncollection/#reorderSectionWithSlides-com.aspose.slides.ISection-int-) 将章节及其幻灯片一起移动；
- 仅使用 [ISectionCollection.removeSection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isectioncollection/#removeSection-com.aspose.slides.ISection-) 删除章节定义，保留其幻灯片；
- 使用 [ISectionCollection.removeSectionWithSlides](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isectioncollection/#removeSectionWithSlides-com.aspose.slides.ISection-) 删除章节及其幻灯片；
- 使用 [ISectionCollection.appendEmptySection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isectioncollection/#appendEmptySection-java.lang.String-) 在末尾添加空章节。

下面的示例创建了两个章节，移动其中一个，连同其幻灯片一起删除，并追加一个空章节：

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide titleSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide resultsSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", titleSlide);
    ISection resultsSection = presentation.getSections().addSection("Results", resultsSlide);

    presentation.getSections().reorderSectionWithSlides(resultsSection, 0);
    presentation.getSections().removeSectionWithSlides(resultsSection);
    presentation.getSections().appendEmptySection("Appendix");
} finally {
    presentation.dispose();
}
```

执行这些操作后，演示文稿包含带有幻灯片的 `Introduction` 章节和一个空的 `Appendix` 章节。`Results` 章节及其幻灯片已被删除。

## **重命名章节**

要重命名章节，请调用其 [ISection.setName](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isection/#setName-java.lang.String-) 方法。章节的幻灯片和位置保持不变。

以下示例创建了一个章节并更改其名称：

```java
import com.aspose.slides.ISection;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISection section = presentation.getSections().addSection("Overview", slide);
    section.setName("Introduction");
} finally {
    presentation.dispose();
}
```

## **从章节检索幻灯片**

[Presentation.getSections](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getSections--) 方法返回一个 [ISectionCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isectioncollection/)，您可以对其进行遍历。对于每个 [ISection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isection/)，调用 [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isection/#getSlidesListOfSection--) 以获取当前属于该章节的幻灯片。该方法返回一个 [ISectionSlideCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isectionslidecollection/)，提供计数、索引访问和迭代功能。

下面的示例创建了两个包含内容的章节和一个空章节，然后打印每个章节的 [name](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isection/#getName--)、[identifier](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isection/#getSectionId--)、[starting slide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isection/#getStartedFromSlide--)、幻灯片计数和幻灯片编号。它使用 [ISectionSlideCollection.get_Item](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isectionslidecollection/#get_Item-int-) 读取第一张幻灯片，并使用增强的 `for` 语句处理每张幻灯片。对于空章节，返回的集合大小为零，不会调用该方法，迭代也不执行任何操作。

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    presentation.getSections().addSection("Introduction", firstSlide);
    presentation.getSections().addSection("Details", thirdSlide);
    presentation.getSections().appendEmptySection("Appendix");

    for (ISection section : presentation.getSections()) {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        String startingSlide = section.getStartedFromSlide() == null ? "none" : Integer.toString(section.getStartedFromSlide().getSlideNumber());

        System.out.println("Section: " + section.getName());
        System.out.println("ID: " + section.getSectionId());
        System.out.println("Starting slide: " + startingSlide);
        System.out.println("Slide count: " + sectionSlides.size());

        if (sectionSlides.size() > 0) {
            System.out.println("First slide via get_Item: " + sectionSlides.get_Item(0).getSlideNumber());
        }

        System.out.print("Slide numbers:");
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    }
} finally {
    presentation.dispose();
}
```

章节成员资格由演示文稿的章节结构决定。不要根据 [ISection.getStartedFromSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isection/#getStartedFromSlide--)、幻灯片索引以及下一个章节的起始幻灯片手动计算章节范围。

结构编辑可能会更改针对某个章节返回的幻灯片以及它们的幻灯片编号。这包括重新排序幻灯片、将幻灯片克隆到章节、将章节及其幻灯片一起移动、删除幻灯片以及删除章节。下一个示例在每次此类更改后调用 [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isection/#getSlidesListOfSection--)，而不是保留对章节先前边界的假设。

```java
import com.aspose.slides.ILayoutSlide;
import com.aspose.slides.ISection;
import com.aspose.slides.ISectionSlideCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;

import java.util.function.BiConsumer;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().get_Item(0);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISlide thirdSlide = presentation.getSlides().addEmptySlide(layoutSlide);
    presentation.getSlides().addEmptySlide(layoutSlide);
    ISection firstSection = presentation.getSections().addSection("First", firstSlide);
    ISection secondSection = presentation.getSections().addSection("Second", thirdSlide);

    BiConsumer<String, ISection> printSectionSlides = (label, section) -> {
        ISectionSlideCollection sectionSlides = section.getSlidesListOfSection();
        System.out.printf("%s (%d slides):", label, sectionSlides.size());
        for (ISlide slide : sectionSlides) {
            System.out.print(" " + slide.getSlideNumber());
        }
        System.out.println();
    };

    printSectionSlides.accept("Initially", firstSection);

    ISectionSlideCollection slidesBeforeClone = firstSection.getSlidesListOfSection();
    presentation.getSlides().addClone(slidesBeforeClone.get_Item(0), firstSection);
    printSectionSlides.accept("After cloning into the section", firstSection);

    ISectionSlideCollection slidesBeforeReorder = firstSection.getSlidesListOfSection();
    int firstSectionPosition = slidesBeforeReorder.get_Item(0).getSlideNumber() - 1;
    presentation.getSlides().reorder(firstSectionPosition, slidesBeforeReorder.get_Item(slidesBeforeReorder.size() - 1));
    printSectionSlides.accept("After reordering slides", firstSection);

    presentation.getSections().reorderSectionWithSlides(firstSection, 1);
    printSectionSlides.accept("After moving the section", firstSection);

    ISectionSlideCollection slidesBeforeRemoval = firstSection.getSlidesListOfSection();
    presentation.getSlides().remove(slidesBeforeRemoval.get_Item(0));
    printSectionSlides.accept("After removing a slide", firstSection);

    presentation.getSections().removeSectionWithSlides(secondSection);
    for (ISection section : presentation.getSections()) {
        printSectionSlides.accept("Remaining section", section);
    }
} finally {
    presentation.dispose();
}
```

每当幻灯片或章节重新排序、克隆、移动或删除时，请再次调用 [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isection/#getSlidesListOfSection--)。这可确保后续处理与当前演示文稿结构保持一致。

PPT（PowerPoint 97–2003）格式不保留章节元数据。请使用支持章节的格式（如 PPTX）进行此工作流；转换为 PPT 会删除后续迭代所需的章节结构。

## **常见问题**

**将演示文稿保存为 PPT（PowerPoint 97–2003）格式时，章节会被保留吗？**

不会。PPT 格式不支持章节元数据，保存为 .ppt 时章节分组会丢失。

**整个章节可以被“隐藏”吗？**

不能。章节本身没有可见性状态。若要隐藏其内容，需要对该章节中的每张幻灯片调用 [ISlide.setHidden](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islide/#setHidden-boolean-)。

**如何找到包含某张幻灯片的章节？**

遍历 [Presentation.getSections](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/#getSections--) 返回的集合，对每个章节调用 [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isection/#getSlidesListOfSection--)，并将返回的幻灯片与目标幻灯片进行比较。对于非空章节，[ISection.getStartedFromSlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/isection/#getStartedFromSlide--) 返回其第一张幻灯片；对于空章节，则返回 `null`。