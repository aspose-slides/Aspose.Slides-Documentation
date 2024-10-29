---
title: 向演示文稿添加幻灯片
type: docs
weight: 10
url: /zh/java/add-slide-to-presentation/
---

## **向演示文稿添加幻灯片**
{{% alert color="primary" %}} 

在讨论如何向演示文稿文件添加幻灯片之前，我们先来讨论一些关于幻灯片的事实。每个 PowerPoint 演示文稿文件包含 **母版 / 布局** 幻灯片和其他 **正常** 幻灯片。这意味着一个演示文稿文件至少包含一张或多张幻灯片。重要的是要知道，Aspose.Slides for Java 不支持没有幻灯片的演示文稿文件。每张幻灯片都有一个唯一的 Id，所有正常幻灯片按零基索引指定的顺序排列。

{{% /alert %}} 

Aspose.Slides for Java 允许开发人员向他们的演示文稿添加空幻灯片。要在演示文稿中添加空幻灯片，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 类的实例。
- 通过设置对 [Slides](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getSlides--)（内容幻灯片对象集合）属性的引用，实例化 [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) 类，该属性由 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 对象暴露。
- 通过调用 [**addEmptySlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) 方法，在内容幻灯片集合的末尾添加一张空幻灯片，该方法由 [ISlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection) 对象暴露。
- 对新添加的空幻灯片进行一些操作。
- 最后，使用 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) 对象写入演示文稿文件。

```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 实例化 SlideCollection 类
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // 向 Slides 集合添加一张空幻灯片
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // 对新添加的幻灯片进行一些操作

    // 将 PPTX 文件保存到磁盘
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```