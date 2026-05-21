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
## **概述**

本文阐述了 Aspose.Slides 在 PowerPoint 演示文稿中如何使用标签和自定义数据。简要概述了 PPTX 文件中数据的存储方式，指出演示文稿特定的数据可以以标签和自定义 XML 部分的形式存在，并将标签描述为键值字符串对。

文章还展示了如何读取标签值以及如何向演示文稿、单个幻灯片或形状添加标签。此外，还介绍了常见的标签管理任务，如清除所有标签、按名称删除标签以及获取标签名称列表。

## **演示文稿文件中的数据存储**

PPTX 文件（扩展名为 .pptx）采用 PresentationML 格式存储，这是 Office Open XML 规范的一部分。Office Open XML 格式定义了演示文稿中数据的结构。

在演示文稿中，*幻灯片* 是其中的一个元素，*幻灯片部件* 包含单个幻灯片的内容。幻灯片部件可以显式关联许多部件——例如 ISO/IEC 29500 定义的用户自定义标签。

自定义数据（特定于演示文稿）或用户可以以标签（[TagCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tagcollection/)）和自定义 XML 部分（[CustomXmlPartCollection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/customxmlpartcollection/)）的形式存在。

{{% alert color="primary" %}} 
标签本质上是字符串键值对。 
{{% /alert %}} 

## **获取标签值**

在 Slides 中，标签对应于 [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/#getKeywords) 和 [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/#setKeywords) 方法。以下示例代码展示了如何使用 Aspose.Slides for PHP via Java 获取 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation) 的标签值：

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

Aspose.Slides 允许向演示文稿添加标签。标签通常由两部分组成：

- 自定义属性的名称 - `MyTag` 
- 自定义属性的值 - `My Tag Value`

如果需要基于特定规则或属性对演示文稿进行分类，添加标签会很有帮助。例如，若要将所有来自北美国家的演示文稿归类在一起，可创建一个 North American 标签，然后将相关国家（美国、墨西哥和加拿大）作为其值。

以下示例代码展示了如何使用 Aspose.Slides for PHP via Java 向 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/Presentation) 添加标签：

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

标签也可以为 [Slide](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/) 设置：

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

或为任意单个 [Shape](https://reference.aspose.com/slides/zh/php-java/aspose.slides/shape/) 设置：

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

### **限制**

通过 `getCustomData()->getTags()` 的自定义数据标签集合添加的标签仅存储在 PowerPoint 文件中。导出为 PDF 时，它们 **不会** 转移到 PDF 的标签结构。因此，作为标签分配的自定义标识符无法从已标记的 PDF 中检索。

**解决方法**：可以将自定义标识符存储在对象的 **Alt Text** 中（例如 `$shape->setAlternativeText("MyId")`）。导出为 PDF 后，Alt Text 可能会出现在 PDF 的标签结构中。

## **常见问题解答**

**我可以一次性删除演示文稿、幻灯片或形状上的所有标签吗？**

可以。[标签集合](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tagcollection/) 支持 [clear](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tagcollection/clear/) 操作，可一次性删除所有键值对。

**如何在不遍历整个集合的情况下按名称删除单个标签？**

对 [标签集合](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tagcollection/) 使用 [remove(name)](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tagcollection/remove/) 操作即可按键删除标签。

**如何检索完整的标签名称列表以进行分析或过滤？**

在 [标签集合](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tagcollection/) 上调用 [getNamesOfTags](https://reference.aspose.com/slides/zh/php-java/aspose.slides/tagcollection/getnamesoftags/)；它会返回所有标签名称的数组。