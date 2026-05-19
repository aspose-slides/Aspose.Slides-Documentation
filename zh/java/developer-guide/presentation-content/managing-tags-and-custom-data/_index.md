---
title: "使用 Java 管理演示文稿中的标签和自定义数据"
linktitle: "标签和自定义数据"
type: docs
weight: 300
url: /zh/java/managing-tags-and-custom-data/
keywords:
  - "文档属性"
  - "标签"
  - "自定义数据"
  - "添加标签"
  - "键值对"
  - "PowerPoint"
  - "演示文稿"
  - "Java"
  - "Aspose.Slides"
description: "了解如何在 Aspose.Slides for Java 中添加、读取、更新和删除标签及自定义数据，并提供 PowerPoint 和 OpenDocument 演示文稿的示例。"
---
## **概述**

本文说明 Aspose.Slides 如何在 PowerPoint 演示文稿中使用标签和自定义数据。它简要概述了数据在 PPTX 文件中的存储方式，指出演示文稿特定的数据可以以标签和自定义 XML 部分的形式存在，并将标签描述为键值字符串对。

它还展示了如何读取标签值以及如何向演示文稿、单个幻灯片或形状添加标签。此外，文章还涵盖了常见的标签管理任务，如清除所有标签、按名称删除标签以及检索标签名称列表。

## **演示文稿文件中的数据存储**

PPTX 文件——扩展名为 .pptx 的项目——采用 PresentationML 格式存储，该格式是 Office Open XML 规范的一部分。Office Open XML 格式定义了演示文稿中数据的结构。

在演示文稿中，*幻灯片* 是一种元素，*幻灯片部件* 包含单个幻灯片的内容。幻灯片部件可以与许多部件建立显式关系，例如由 ISO/IEC 29500 定义的用户自定义标签。

自定义数据（特定于演示文稿）或用户可以以标签（[ITagCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ITagCollection)）和 CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ICustomXmlPartCollection)）的形式存在。

{{% alert color="primary" %}} 
标签本质上是字符串键值对。 
{{% /alert %}} 

## **获取标签的值**

在 Slides 中，标签对应于 [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IDocumentProperties#getKeywords--) 和 [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) 方法。下面的示例代码展示了如何使用 Aspose.Slides for Java 获取 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 中标签的值：

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **向演示文稿添加标签**

Aspose.Slides 允许向演示文稿添加标签。标签通常由两部分组成：

- 自定义属性的名称 - `MyTag`
- 自定义属性的值 - `My Tag Value`

如果需要根据特定规则或属性对一些演示文稿进行分类，则可以通过添加标签来实现。例如，若想将所有北美国家的演示文稿归为一类，可以创建一个北美标签，并将相关国家（美国、墨西哥和加拿大）设为其值。

下面的示例代码展示了如何使用 Aspose.Slides for Java 向 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 添加标签：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

标签也可以为 [Slide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ISlide) 设置：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

或为任意单独的 [Shape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/IAutoShape) 设置：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

### **局限性**

通过 `getCustomData().getTags()` 添加的自定义数据标签集合仅存储在 PowerPoint 文件中。导出为 PDF 时，这些标签 **不会** 转移到 PDF 的标签结构中。因此，作为标签分配的自定义标识符无法从带标签的 PDF 中检索。

**解决方法**：可以将自定义标识符存储在对象的 **Alt Text** 中（例如 `shape.setAlternativeText("MyId")`）。导出为 PDF 后，Alt Text 可能会出现在 PDF 的标签结构中。

## **常见问题**

**我可以一次性删除演示文稿、幻灯片或形状上的所有标签吗？**

可以。[tag collection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/tagcollection/) 支持 [clear](https://reference.aspose.com/slides/zh/java/com.aspose.slides/tagcollection/#clear--) 操作，一次性删除所有键值对。

**如何在不遍历整个集合的情况下按名称删除单个标签？**

在 [tag collection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/tagcollection/) 上使用 [Remove(name)](https://reference.aspose.com/slides/zh/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) 操作即可按键删除标签。

**如何检索标签名称的完整列表以便进行分析或过滤？**

使用 [getNamesOfTags](https://reference.aspose.com/slides/zh/java/com.aspose.slides/tagcollection/#getNamesOfTags--) 在 [tag collection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/tagcollection/) 上获取，它返回所有标签名称的数组。