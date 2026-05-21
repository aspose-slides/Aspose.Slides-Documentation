---
title: 使用 JavaScript 管理演示文稿中的标签和自定义数据
linktitle: 标签和自定义数据
type: docs
weight: 300
url: /zh/nodejs-java/managing-tags-and-custom-data/
keywords:
- 文档属性
- 标签
- 自定义数据
- 添加标签
- 键值对
- PowerPoint
- 演示文稿
- Node.js
- JavaScript
- Aspose.Slides
description: "学习如何在 Aspose.Slides for Node.js 中添加、读取、更新和删除标签和自定义数据，示例针对 PowerPoint 和 OpenDocument 演示文稿。"
---
## **概述**

本文介绍了 Aspose.Slides 如何在 PowerPoint 演示文稿中处理标签和自定义数据。简要说明了 PPTX 文件中数据的存储方式，指出演示文稿特定的数据可以以标签和自定义 XML 部分的形式存在，并将标签描述为键值字符串对。

文章还展示了如何读取标签值以及如何向演示文稿、单个幻灯片或形状添加标签。此外，还覆盖了常见的标签管理任务，如清除所有标签、按名称删除标签以及获取标签名称列表。

## **演示文稿文件中的数据存储**

PPTX 文件——即扩展名为 .pptx 的文件——采用 PresentationML 格式存储，该格式是 Office Open XML 规范的一部分。Office Open XML 格式定义了演示文稿中数据的结构。

在演示文稿中，*幻灯片* 是组成元素之一，*幻灯片部件* 包含单个幻灯片的内容。幻灯片部件可以显式关联到许多部件——例如用户自定义标签——这些关系由 ISO/IEC 29500 定义。

自定义数据（特定于演示文稿）或用户可以以标签（[TagCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/TagCollection)）和自定义 XML 部分（[CustomXmlPartCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/CustomXmlPartCollection)）的形式存在。

{{% alert color="primary" %}} 
标签本质上是字符串键值对。 
{{% /alert %}} 

## **获取标签的值**

在 Slides 中，标签对应于 [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) 和 [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-) 方法。以下示例代码展示了如何使用 Aspose.Slides for Node.js via Java 获取 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 中标签的值：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **向演示文稿添加标签**

Aspose.Slides 允许向演示文稿添加标签。标签通常由两部分组成：

- 自定义属性的名称 - `MyTag` 
- 自定义属性的值 - `My Tag Value`

如果需要根据特定规则或属性对一些演示文稿进行分类，则可以通过添加标签来实现。例如，若想将所有北美国家的演示文稿归类在一起，可以创建一个“North American”标签，并将相关国家（美国、墨西哥和加拿大）设为标签值。

以下示例代码演示了如何使用 Aspose.Slides for Node.js via Java 向 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 添加标签：

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

标签也可以为 [Slide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Slide) 设置：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

或为任意单独的 [Shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/AutoShape) 设置：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **局限性**

通过 `getCustomData().getTags()` 添加到自定义数据标签集合的标签仅存储在 PowerPoint 文件内部。导出为 PDF 时，这些标签 **不会** 转移到 PDF 的标签结构中。因此，作为标签分配的自定义标识符无法从已标记的 PDF 中检索。

**解决办法**：可以将自定义标识符存储在对象的 **Alt Text** 中（例如 `shape.setAlternativeText("MyId")`）。导出为 PDF 后，Alt Text 可能会出现在 PDF 的标签结构中。

## **常见问答**

**我可以一次性删除演示文稿、幻灯片或形状中的所有标签吗？**

可以。[tag collection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tagcollection/) 支持 [clear](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tagcollection/clear/) 操作，可一次性删除所有键‑值对。

**如何在不遍历整个集合的情况下按名称删除单个标签？**

使用 [remove(name)](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tagcollection/remove/) 操作在 [TagCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tagcollection/) 上按键删除标签。

**如何检索完整的标签名称列表以进行分析或过滤？**

在 [tag collection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tagcollection/) 上调用 [getNamesOfTags](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/tagcollection/getnamesoftags/)，它会返回所有标签名称的数组。