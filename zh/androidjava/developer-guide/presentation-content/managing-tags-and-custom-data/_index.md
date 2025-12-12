---
title: 在 Android 上管理演示文稿中的标签和自定义数据
linktitle: 标签和自定义数据
type: docs
weight: 300
url: /zh/androidjava/managing-tags-and-custom-data
keywords:
- 文档属性
- 标签
- 自定义数据
- 添加标签
- 键值对
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "在 Aspose.Slides for Android 中添加、读取、更新和删除标签及自定义数据，提供针对 PowerPoint 和 OpenDocument 演示文稿的 Java 示例。"
---

## **演示文稿文件中的数据存储**

PPTX 文件——扩展名为 .pptx 的项目——使用 PresentationML 格式存储，该格式是 Office Open XML 规范的一部分。Office Open XML 格式定义了演示文稿中数据的结构。

在演示文稿中，*幻灯片* 是其中的一个元素，*幻灯片部件* 包含单个幻灯片的内容。幻灯片部件可以与许多部件建立显式关系——例如由 ISO/IEC 29500 定义的用户自定义标签。

自定义数据（特定于演示文稿）或用户可以以标签（[ITagCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITagCollection)）和 CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICustomXmlPartCollection)）的形式存在。

{{% alert color="primary" %}} 
标签本质上是字符串-键 对值。 
{{% /alert %}} 

## **获取标签的值**

在幻灯片中，标签对应于 [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) 和 [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) 方法。下面的示例代码展示了如何使用 Aspose.Slides for Android（Java）获取 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 中标签的值：
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

如果需要根据特定规则或属性对演示文稿进行分类，向演示文稿添加标签会很有帮助。例如，如果想将所有来自北美国家的演示文稿归类在一起，可以创建一个北美标签，并将相关国家（美国、墨西哥和加拿大）设为其值。

下面的示例代码展示了如何使用 Aspose.Slides for Android（Java）向 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 添加标签：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```


标签也可以为 [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) 设置：
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```


或任意单个 [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)：
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

**我可以一次性删除演示文稿、幻灯片或形状上的所有标签吗？**

可以。[tag collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/) 支持 [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#clear--) 操作，可一次删除所有键-值对。

**如何在不遍历整个集合的情况下通过名称删除单个标签？**

在 [tag collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/) 上使用 [remove(name)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) 操作即可通过键删除标签。

**如何获取标签名称的完整列表用于分析或过滤？**

在 [tag collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/) 上使用 [getNamesOfTags](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--)；它会返回所有标签名称的数组。