---
title: 添加幻灯片到演示文稿
type: docs
weight: 10
url: /androidjava/add-slide-to-presentation/
---

## **添加幻灯片到演示文稿**
{{% alert color="primary" %}} 

在讨论如何将幻灯片添加到演示文稿文件之前，让我们先讨论关于幻灯片的一些事实。每个 PowerPoint 演示文稿文件包含 **母版 / 布局** 幻灯片和其他 **普通** 幻灯片。这意味着演示文稿文件至少包含一个或多个幻灯片。重要的是要知道没有幻灯片的演示文稿文件不被 Aspose.Slides for Android via Java 支持。每个幻灯片都有一个唯一的 ID，所有普通幻灯片都按零基索引指定的顺序排列。

{{% /alert %}} 

Aspose.Slides for Android via Java 允许开发人员向他们的演示文稿添加空幻灯片。如要在演示文稿中添加空幻灯片，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 类的实例。
- 通过设置对 [Slides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getSlides--)（内容幻灯片对象集合）属性的引用，实例化 [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) 类，该属性由 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 对象公开。
- 通过调用由 [ISlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection) 对象公开的 [**addEmptySlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) 方法，将一个空幻灯片添加到内容幻灯片集合的末尾。
- 对新添加的空幻灯片进行一些操作。
- 最后，使用 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) 对象写入演示文稿文件。

```java
// 实例化表示演示文稿文件的 Presentation 类
Presentation pres = new Presentation();
try {
    // 实例化 SlideCollection 类
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // 将空幻灯片添加到 Slides 集合
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // 对新添加的幻灯片进行一些操作

    // 将 PPTX 文件保存到磁盘
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```