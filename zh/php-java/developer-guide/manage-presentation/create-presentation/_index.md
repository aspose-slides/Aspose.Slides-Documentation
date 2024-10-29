---
title: 使用 PHP 创建 PowerPoint 演示文稿
linktitle: 创建演示文稿
type: docs
weight: 10
url: /zh/php-java/create-presentation/
keywords: 创建 ppt java, 创建 ppt 演示文稿, 创建 pptx java
description: 学习如何使用 PHP 从头开始创建 PowerPoint 演示文稿，例如 PPT、PPTX。
---

## **创建 PowerPoint 演示文稿**
要向演示文稿的选定幻灯片添加一条简单的纯线，请按照以下步骤操作：

1. 创建 Presentation 类的实例。
1. 使用索引获取幻灯片的引用。
1. 使用 Shapes 对象暴露的 addAutoShape 方法添加类型为 Line 的 AutoShape。
1. 将修改后的演示文稿写入 PPTX 文件。

在下面给出的示例中，我们向演示文稿的第一张幻灯片添加了一条线。

```php
  # 实例化一个表示演示文稿文件的 Presentation 对象
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $slide = $pres->getSlides()->get_Item(0);
    # 添加类型为线的自动形状
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```