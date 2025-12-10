---
title: 使用 Java 管理演示文稿中的标签和自定义数据
linktitle: 标签和自定义数据
type: docs
weight: 300
url: /zh/java/managing-tags-and-custom-data/
keywords:
- 文档属性
- 标签
- 自定义数据
- 添加标签
- 键值对
- PowerPoint
- 演示文稿
- Java
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Java 中添加、读取、更新和删除标签及自定义数据，示例涵盖 PowerPoint 和 OpenDocument 演示文稿。"
---

## **演示文稿文件中的数据存储**

PPTX 文件——扩展名为 .pptx 的项目——采用 PresentationML 格式存储，这是 Office Open XML 规范的一部分。Office Open XML 格式定义了演示文稿中数据的结构。

在演示文稿中，*幻灯片* 是元素之一，*幻灯片部件* 包含单个幻灯片的内容。幻灯片部件可以显式关联到许多部件——例如由 ISO/IEC 29500 定义的用户自定义标签。

自定义数据（特定于某个演示文稿）或用户可以作为标签（[ITagCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ITagCollection)）和 CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICustomXmlPartCollection)）存在。

{{% alert color="primary" %}} 
标签本质上是字符串键值对。 
{{% /alert %}} 

## **获取标签值**

在幻灯片中，标签对应于 [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#getKeywords--) 和 [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) 方法。以下示例代码展示了如何使用 Aspose.Slides for Java 获取 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 中标签的值：
```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```


## **向演示文稿添加标签**

Aspose.Slides 允许向演示文稿添加标签。标签通常由两个项目组成：

- 自定义属性的名称 - `MyTag` 
- 自定义属性的值 - `My Tag Value`

如果需要根据特定规则或属性对一些演示文稿进行分类，则可以通过添加标签受益。例如，如果想将所有北美国家的演示文稿归类在一起，可以创建一个 North American 标签，然后将相关国家（美国、墨西哥和加拿大）设为其值。

以下示例代码展示了如何使用 Aspose.Slides for Java 向 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) 添加标签：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```


标签也可以为 [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) 设置：
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```


或为任意单个 [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) 设置：
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


## **常见问题**

**我可以一次性删除演示文稿、幻灯片或形状中的所有标签吗？**

可以。[tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) 支持 [clear](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#clear--) 操作，一次性删除所有键值对。

**如何在不遍历整个集合的情况下，根据名称删除单个标签？**

对 [tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) 使用 [Remove(name)](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) 操作即可按键删除标签。

**如何获取完整的标签名称列表以进行分析或过滤？**

在 [tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) 上使用 [getNamesOfTags](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#getNamesOfTags--)；它返回所有标签名称的数组。