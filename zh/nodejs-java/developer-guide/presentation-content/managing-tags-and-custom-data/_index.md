---
title: 管理标签和自定义数据
type: docs
weight: 300
url: /zh/nodejs-java/managing-tags-and-custom-data
---

## **演示文稿文件中的数据存储**

PPTX 文件——具有 .pptx 扩展名的项目——采用 PresentationML 格式存储，该格式是 Office Open XML 规范的一部分。Office Open XML 规范定义了演示文稿中数据的结构。

在演示文稿中，*幻灯片* 是其中的一个元素，*幻灯片部件* 包含单个幻灯片的内容。幻灯片部件可以与许多部件建立显式关系——例如由 ISO/IEC 29500 定义的用户自定义标签——。

自定义数据（特定于某个演示文稿）或用户可以以标签（[TagCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TagCollection)）和 CustomXmlPart（[CustomXmlPartCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CustomXmlPartCollection)）的形式存在。

{{% alert color="primary" %}} 
标签本质上是字符串键值对。 
{{% /alert %}} 

## **获取标签的值**

在幻灯片中，标签对应于 [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) 和 [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-) 方法。下面的示例代码演示了如何使用 Aspose.Slides for Node.js via Java 从 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 获取标签的值：
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

Aspose.Slides 允许您向演示文稿添加标签。标签通常包含两个项目：

- 自定义属性的名称 - `MyTag`
- 自定义属性的值 - `My Tag Value`

如果您需要根据特定规则或属性对演示文稿进行分类，添加标签会有所帮助。例如，若想将所有来自北美国家的演示文稿归类在一起，您可以创建一个北美标签，并将相关国家（美国、墨西哥和加拿大）设为其值。

下面的示例代码演示了如何使用 Aspose.Slides for Node.js via Java 向 [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) 添加标签：
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


标签也可以设置到 [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide)：
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


或任意单独的 [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape)：
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


## **常见问题**

**我可以一次性删除演示文稿、幻灯片或形状中的所有标签吗？**

可以。[tag collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/) 支持 [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/clear/) 操作，可一次性删除所有键值对。

**如何在不遍历整个集合的情况下，仅通过标签名称删除单个标签？**

使用 [TagCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/) 上的 [remove(name)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/remove/) 操作即可通过键删除该标签。

**如何获取所有标签名称的完整列表以用于分析或过滤？**

在 [tag collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/) 上调用 [getNamesOfTags](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/getnamesoftags/)；它会返回所有标签名称的数组。