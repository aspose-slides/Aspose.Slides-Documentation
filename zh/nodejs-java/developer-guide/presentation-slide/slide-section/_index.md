---
title: 幻灯片章节
type: docs
weight: 90
url: /zh/nodejs-java/slide-section/
---

使用 Aspose.Slides for Node.js via Java，您可以将 PowerPoint 演示文稿组织成章节。您可以创建包含特定幻灯片的章节。

当出现以下情况时，您可能希望创建章节并使用它们来组织或划分演示文稿中的幻灯片：

- 当您与其他人或团队共同处理大型演示文稿，并且需要将某些幻灯片分配给同事或团队成员时。 
- 当演示文稿包含大量幻灯片，且您难以一次性管理或编辑其内容时。

理想情况下，您应该创建一个包含相似幻灯片的章节——这些幻灯片具有共同点，或可以基于某个规则归为一组——并为该章节命名，以描述其中的幻灯片。

## **在演示文稿中创建章节**

要在演示文稿中添加用于容纳幻灯片的章节，Aspose.Slides for Node.js via Java 提供了 [addSection()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) 方法，您可以指定要创建的章节名称以及章节开始的幻灯片。

此示例代码展示了如何在 JavaScript 中创建演示文稿的章节：
```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// section1 将在 newSlide2 结束，随后 section2 将开始
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **更改章节名称**

在 PowerPoint 演示文稿中创建章节后，您可能会决定更改其名称。

此示例代码展示了如何使用 Aspose.Slides 在 JavaScript 中更改演示文稿章节的名称：
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **常见问题**

**章节在保存为 PPT（PowerPoint 97–2003）格式时会保留吗？**

不会。PPT 格式不支持章节元数据，因此保存为 .ppt 时章节分组会丢失。

**可以将整个章节“隐藏”吗？**

不能。只能隐藏单个幻灯片。章节作为实体没有“隐藏”状态。

**我能否通过幻灯片快速找到所属章节，或反过来找到章节的第一张幻灯片？**

可以。章节由其起始幻灯片唯一确定；给定一张幻灯片，您可以判断它属于哪个章节；对于章节，您可以访问其第一张幻灯片。