---
title: 管理标签和自定义数据
type: docs
weight: 300
url: /androidjava/managing-tags-and-custom-data

---

## 演示文件中的数据存储

PPTX 文件（.pptx 扩展名的项目）以 PresentationML 格式存储，这是 Office Open XML 规范的一部分。 Office Open XML 格式定义了演示文稿中数据的结构。

在演示文稿中，*幻灯片* 是其中一个元素，*幻灯片部分* 包含单个幻灯片的内容。一个幻灯片部分可以与多个部分（如用户定义的标签）有明确的关系，这些关系由 ISO/IEC 29500 定义。

自定义数据（特定于某个演示文稿）或用户可以存在于标签（[ITagCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITagCollection)）和 CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICustomXmlPartCollection)）中。

{{% alert color="primary" %}}

标签本质上是字符串键值对。

{{% /alert %}}

## 获取标签的值

在幻灯片中，标签对应于 [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) 和 [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) 方法。以下示例代码演示了如何通过 Java 使用 Aspose.Slides for Android 获取标签的值，以便于 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation):

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## 向演示文稿添加标签

Aspose.Slides 允许您向演示文稿添加标签。标签通常由两个项目组成：

- 自定义属性的名称 - `MyTag` 
- 自定义属性的值 - `My Tag Value`

如果您需要根据特定规则或属性对某些演示文稿进行分类，则可以通过向这些演示文稿添加标签来受益。例如，如果您想将所有来自北美国家的演示文稿归类在一起，可以创建一个北美标签，并将相关国家（美国、墨西哥和加拿大）作为值进行分配。

以下示例代码演示了如何使用 Aspose.Slides for Android 通过 Java 向 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) 添加标签：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

标签也可以设置在 [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) 上：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

或者任何单独的 [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)：

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