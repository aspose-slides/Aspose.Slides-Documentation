---
title: PHP 中的组演示形状
linktitle: 形状组
type: docs
weight: 40
url: /zh/php-java/group/
keywords:
- 组形状
- 形状组
- 添加组
- 替代文本
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP via Java 对 PowerPoint 幻灯片中的形状进行分组和取消分组——快速、一步步的免费代码指南。"
---

## **添加组形状**
Aspose.Slides 支持在幻灯片上处理组形状。此功能帮助开发者创建更丰富的演示文稿。Aspose.Slides for PHP via Java 支持添加或访问组形状。可以向已添加的组形状中加入形状以填充它，或访问组形状的任何属性。使用 Aspose.Slides for PHP via Java 将组形状添加到幻灯片的步骤如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 通过其 Index 获取幻灯片的引用。
1. 向幻灯片添加组形状。
1. 向已添加的组形状中添加形状。
1. 将修改后的演示文稿保存为 PPTX 文件。

下面的示例向幻灯片添加组形状。
```php
  # 实例化 Presentation 类
  $pres = new Presentation();
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 访问幻灯片的形状集合
    $slideShapes = $sld->getShapes();
    # 向幻灯片添加组形状
    $groupShape = $slideShapes->addGroupShape();
    # 向已添加的组形状中添加形状
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # 添加组形状框架
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # 将 PPTX 文件写入磁盘
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **访问 AltText 属性**
本章节展示了添加组形状并访问幻灯片上组形状 AltText 属性的简要步骤和代码示例。使用 Aspose.Slides for PHP via Java 在幻灯片中访问组形状的 AltText 方法如下：

1. 实例化代表 PPTX 文件的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类。
1. 通过其 Index 获取幻灯片的引用。
1. 访问幻灯片的形状集合。
1. 访问组形状。
1. 访问 [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--) 属性。

下面的示例访问组形状的替代文本。
```php
  # 实例化表示 PPTX 文件的 Presentation 类
  $pres = new Presentation("AltText.pptx");
  try {
    # 获取第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # 访问幻灯片的形状集合
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # 访问组形状。
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # 访问 AltText 属性
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **常见问题**

**是否支持嵌套分组（组内还有组）？**

是。[GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) 具有 [getParentGroup](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getparentgroup/) 方法，直接表明支持层级结构（一个组可以是另一个组的子组）。

**如何控制组相对于幻灯片上其他对象的 Z 顺序？**

使用 [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) 的 [getZOrderPosition](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) 方法检查其在显示堆栈中的位置。

**我可以防止移动/编辑/取消分组吗？**

可以。组的锁定部分通过 [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/getgroupshapelock/) 公开，您可以限制对该对象的操作。