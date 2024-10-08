---
title: 幻灯片部分
type: docs
weight: 90
url: /androidjava/slide-section/
---

通过 Aspose.Slides for Android 通过 Java，您可以将 PowerPoint 演示文稿组织成多个部分。您可以创建包含特定幻灯片的部分。

在以下情况下，您可能希望创建部分并使用它们来组织或将演示文稿中的幻灯片划分为逻辑部分：

- 当您与其他人或团队合作处理大型演示文稿时—并且您需要将某些幻灯片分配给同事或部分团队成员。
- 当您处理包含很多幻灯片的演示文稿时—并且您在一次性管理或编辑其内容时遇到困难。

理想情况下，您应该创建一个包含相似幻灯片的部分—这些幻灯片有共同点，或者可以基于某个规则存在于一个组中—并为该部分命名，以描述其中的幻灯片。

## 在演示文稿中创建部分

要在演示文稿中添加一个用于放置幻灯片的部分，Aspose.Slides for Android 通过 Java 提供了 [addSection()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) 方法，该方法允许您指定要创建的部分的名称和该部分开始的幻灯片。

以下示例代码演示了如何在 Java 中在演示文稿中创建一个部分：

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("部分 1", newSlide1);
    ISection section2 = pres.getSections().addSection("部分 2", newSlide3); // section1 将在 newSlide2 结束，然后 section2 将开始   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("最后一个空部分");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## 更改部分名称

在 PowerPoint 演示文稿中创建部分后，您可能决定更改其名称。

以下示例代码演示了如何使用 Aspose.Slides 在 Java 中更改演示文稿中部分的名称：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("我的部分");
} finally {
    if (pres != null) pres.dispose();
}
```