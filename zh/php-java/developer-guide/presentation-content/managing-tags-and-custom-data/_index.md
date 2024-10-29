---
title: 管理标签和自定义数据
type: docs
weight: 300
url: /zh/php-java/managing-tags-and-custom-data

---

## 演示文件中的数据存储

PPTX 文件——以 .pptx 为扩展名的项目——存储在 PresentationML 格式中，该格式是 Office Open XML 规范的一部分。Office Open XML 格式定义了演示文稿中包含的数据的结构。

在演示文稿中，*幻灯片*是其中一个元素，*幻灯片部分*包含单个幻灯片的内容。幻灯片部分可以与许多部分（例如用户定义的标签）有明确的关系，这些关系由 ISO/IEC 29500 定义。

自定义数据（特定于演示文稿）或用户可以作为标签（[ITagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ITagCollection)）和 CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICustomXmlPartCollection)）存在。

{{% alert color="primary" %}} 

标签基本上是字符串-键值对。

{{% /alert %}} 

## 获取标签的值

在幻灯片中，标签对应于 [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#getKeywords--) 和 [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) 方法。以下示例代码展示了如何使用 Aspose.Slides for PHP 通过 Java 获取标签的值，针对 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)：

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

## 向演示文稿添加标签

Aspose.Slides 允许您向演示文稿添加标签。标签通常由两个项目组成：

- 自定义属性的名称 - `MyTag`
- 自定义属性的值 - `My Tag Value`

如果您需要根据特定规则或属性对某些演示文稿进行分类，您可以通过向这些演示文稿添加标签来受益。例如，如果您想要对来自北美国家的所有演示文稿进行分类或放在一起，您可以创建一个北美标签，然后将相关国家（美国、墨西哥和加拿大）指定为值。

以下示例代码展示了如何使用 Aspose.Slides for PHP 通过 Java 向 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 添加标签：

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

标签也可以设置为 [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide)：

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

或者对任何单独的 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)：

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