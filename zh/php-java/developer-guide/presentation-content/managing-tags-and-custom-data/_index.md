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
- 键值对
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何在 Aspose.Slides for PHP via Java 中添加、读取、更新和删除标签及自定义数据，并提供 PowerPoint 和 OpenDocument 演示文稿的示例。"
---

## **演示文稿文件中的数据存储**

PPTX 文件（扩展名为 .pptx 的项目）以 PresentationML 格式存储，该格式是 Office Open XML 规范的一部分。Office Open XML 规范定义了演示文稿中数据的结构。

在演示文稿中，*幻灯片* 是其中的一个元素，*幻灯片部件* 包含单个幻灯片的内容。幻灯片部件可以与许多部件建立显式关系——例如由 ISO/IEC 29500 定义的用户自定义标签。

自定义数据（特定于演示文稿）或用户可以以标签（[TagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/)）和 CustomXmlParts（[CustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/customxmlpartcollection/)）的形式存在。

{{% alert color="primary" %}} 
标签本质上是字符串键值对。 
{{% /alert %}} 

## **获取标签的值**

在幻灯片中，标签对应于 [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#getKeywords) 和 [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setKeywords) 方法。下面的示例代码展示了如何使用 Aspose.Slides for PHP via Java 从 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 获取标签的值：
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

如果您需要根据特定规则或属性对演示文稿进行分类，则可以通过向这些演示文稿添加标签来实现。例如，如果您想将所有来自北美国家的演示文稿归类在一起，可以创建一个 North American 标签，然后将相关国家（美国、墨西哥和加拿大）作为其值。

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


标签也可以为 [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) 设置：
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


或者为任意单独的 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) 设置：
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

**我可以一次性从演示文稿、幻灯片或形状中删除所有标签吗？**

可以。[tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) 支持 [clear](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/clear/) 操作，可一次性删除所有键值对。

**如何在不遍历整个集合的情况下，仅通过名称删除单个标签？**

在 [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) 上使用 [remove(name)](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/remove/) 操作，可通过键删除标签。

**如何获取所有标签名称的完整列表以进行分析或过滤？**

在 [tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) 上调用 [getNamesOfTags](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/getnamesoftags/)；它返回所有标签名称的数组。