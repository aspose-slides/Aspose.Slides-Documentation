---
title: 向演示文稿添加幻灯片
type: docs
weight: 10
url: /zh/nodejs-java/add-slide-to-presentation/
---

## **向演示文稿添加幻灯片**
{{% alert color="primary" %}} 

在讨论向演示文件添加幻灯片之前，让我们先了解一些关于幻灯片的事实。每个 PowerPoint 演示文件包含 **母版/布局** 幻灯片和其他 **普通** 幻灯片。这意味着演示文件至少包含一个或多个幻灯片。需要注意的是，不支持没有幻灯片的演示文件，Aspose.Slides for Node.js via Java 亦是如此。每个幻灯片都有唯一的 Id，所有普通幻灯片按照零基索引的顺序排列。

{{% /alert %}} 

Aspose.Slides for Node.js via Java 允许开发人员向演示文稿添加空幻灯片。要在演示文稿中添加空幻灯片，请按照以下步骤操作：

- 创建一个 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 类的实例。
- 通过设置对由 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 对象公开的 [Slides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getSlides--)（内容幻灯片对象集合）属性的引用，实例化 [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection) 类。
- 调用由 [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection) 对象公开的 [**addEmptySlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-) 方法，在内容幻灯片集合的末尾添加空幻灯片。
- 对新添加的空幻灯片进行相应操作。
- 最后，使用 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation) 对象写入演示文件。
```javascript
// 实例化表示演示文件的 Presentation 类
var pres = new aspose.slides.Presentation();
try {
    // 实例化 SlideCollection 类
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // 向 Slides 集合添加一个空白幻灯片
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // 对新添加的幻灯片进行一些操作
    // 将 PPTX 文件保存到磁盘
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **常见问题**

**我可以在特定位置插入新幻灯片，而不仅仅是在末尾吗？**

可以。库支持幻灯片集合以及 [insert](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/insertclone/) 操作，因此您可以在所需的索引处添加幻灯片，而不仅仅是末尾。

**基于布局添加幻灯片时，主题/样式会被保留吗？**

会。布局继承其母版的格式，新幻灯片继承所选布局及其关联的母版。

**在添加幻灯片之前，新“空”演示文稿中包含哪个幻灯片？**

新创建的演示文稿已包含一个索引为零的空白幻灯片。计算插入索引时需考虑此情况。

**如果母版有很多选项，如何为新幻灯片选择“合适”的布局？**

通常选择与所需结构（例如 [标题和内容、双内容等](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidelayouttype/)）匹配的 [LayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/layoutslide/)。如果缺少此类布局，您可以 [将其添加到母版](/slides/zh/nodejs-java/slide-layout/) 然后使用。