---
title: 在 Android 上管理演示文稿中的幻灯片章节
linktitle: 幻灯片章节
type: docs
weight: 90
url: /zh/androidjava/slide-section/
keywords:
- 创建章节
- 添加章节
- 编辑章节
- 更改章节
- 章节名称
- PowerPoint
- OpenDocument
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "使用 Aspose.Slides for Android via Java 简化 PowerPoint 和 OpenDocument 中的幻灯片章节——分割、重命名和重新排序，以优化 PPTX 和 ODP 工作流。"
---

使用 Aspose.Slides for Android via Java，您可以将 PowerPoint 演示文稿组织成章节。您可以创建包含特定幻灯片的章节。

在以下情况下，您可能需要创建章节并使用它们来组织或划分演示文稿中的幻灯片：

- 当您与其他人或团队一起处理大型演示文稿时，需要将特定幻灯片分配给同事或团队成员。  
- 当演示文稿包含大量幻灯片且您难以一次性管理或编辑其内容时。

理想情况下，您应当创建一个包含相似幻灯片的章节——这些幻灯片具有共同点或可以根据某个规则归为一组——并为该章节命名，以描述其中的幻灯片。

## **在演示文稿中创建章节**

要在演示文稿中添加用于容纳幻灯片的章节，Aspose.Slides for Android via Java 提供了 [addSection()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) 方法，允许您指定要创建的章节名称以及章节起始的幻灯片。

以下示例代码展示了如何在 Java 中创建演示文稿的章节：
```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 将在 newSlide2 结束，随后 section2 将开始   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **更改章节名称**

在 PowerPoint 演示文稿中创建章节后，您可能决定更改其名称。

以下示例代码展示了如何在 Java 中使用 Aspose.Slides 更改演示文稿中章节的名称：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**在保存为 PPT（PowerPoint 97–2003）格式时，章节会被保留吗？**

不会。PPT 格式不支持章节元数据，保存为 .ppt 时章节分组会丢失。

**可以将整个章节“隐藏”吗？**

不能。只能隐藏单个幻灯片。章节本身没有“隐藏”状态。

**我能否通过幻灯片快速找到所属章节，或者反过来找到章节的第一张幻灯片？**

可以。章节由其起始幻灯片唯一确定；给定一张幻灯片，您可以判断它所属的章节；对于章节，您可以访问其第一张幻灯片。