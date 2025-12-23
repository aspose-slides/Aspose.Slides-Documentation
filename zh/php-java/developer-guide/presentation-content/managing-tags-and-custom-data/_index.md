---
title: 使用 PHP 管理演示文稿中的标签和自定义数据
linktitle: 标签和自定义数据
type: docs
weight: 300
url: /zh/php-java/managing-tags-and-custom-data/
keywords:
- 文档属性
- 标签
- 自定义数据
- 添加标签
- 成对值
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何在 Aspose.Slides for PHP via Java 中添加、读取、更新和删除标签及自定义数据，并提供 PowerPoint 和 OpenDocument 演示文稿的示例。"
---

## **演示文件中的数据存储**

PPTX 文件——扩展名为 .pptx 的项目——以 PresentationML 格式存储，该格式是 Office Open XML 规范的一部分。Office Open XML 格式定义了演示文稿中数据的结构。  

在演示文稿中，*幻灯片* 是其中的元素之一，*幻灯片部件* 包含单个幻灯片的内容。幻灯片部件可以与许多部件（例如用户自定义标签）建立明确的关系，这些关系由 ISO/IEC 29500 定义。  

自定义数据（特定于演示文稿）或用户可以以标签（[ITagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ITagCollection)）和 CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICustomXmlPartCollection)）的形式存在。  

{{% alert color="primary" %}} 
标签本质上是字符串-键 对值。 
{{% /alert %}} 

## **获取标签的值**

在幻灯片中，标签对应于 [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#getKeywords--) 和 [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) 方法。本示例代码展示了如何使用 Aspose.Slides for PHP via Java 获取 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 中标签的值：
```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **向演示文稿添加标签**

Aspose.Slides 允许您向演示文稿添加标签。标签通常由两项组成：

- 自定义属性的名称 - `MyTag` 
- 自定义属性的值 - `My Tag Value`

如果您需要根据特定规则或属性对某些演示文稿进行分类，则可以通过添加标签获益。例如，若想对来自北美国家的所有演示文稿进行归类，您可以创建一个北美标签，然后将相关国家（美国、墨西哥和加拿大）作为其值进行分配。  

以下示例代码展示了如何使用 Aspose.Slides for PHP via Java 向 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 添加标签：
```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


标签也可以为 [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) 设置：
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


或者任意单独的 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)：
```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**我可以一次性删除演示文稿、幻灯片或形状上的所有标签吗？**

可以。[tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) 支持 [clear](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/clear/) 操作，可一次删除所有键-值对。  

**如何在不遍历整个集合的情况下，仅通过标签名称删除单个标签？**

在 [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) 上使用 [Remove(name)](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/remove/) 操作即可按键删除标签。  

**如何检索标签名称的完整列表以进行分析或过滤？**

在 [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) 上使用 [getNamesOfTags](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/getnamesoftags/)；它返回包含所有标签名称的数组。