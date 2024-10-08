---
title: 组
type: docs
weight: 40
url: /php-java/group/
---

## **添加组形状**
Aspose.Slides 支持在幻灯片上处理组形状。此功能帮助开发人员支持更丰富的演示文稿。Aspose.Slides for PHP via Java 支持添加或访问组形状。可以向添加的组形状中添加形状以填充它，或访问组形状的任何属性。使用 Aspose.Slides for PHP via Java 向幻灯片添加组形状的方法如下：

1. 创建 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的实例。
1. 使用索引获取幻灯片的引用。
1. 向幻灯片添加组形状。
1. 向添加的组形状中添加形状。
1. 将修改后的演示文稿保存为 PPTX 文件。

以下示例向幻灯片添加了一个组形状。

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
    # 在添加的组形状内添加形状
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
本主题展示了通过代码示例添加组形状和访问幻灯片上组形状的 AltText 属性的简单步骤。要使用 Aspose.Slides for PHP via Java 访问幻灯片中组形状的 AltText：

1. 实例化表示 PPTX 文件的 [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类。
1. 使用索引获取幻灯片的引用。
1. 访问幻灯片的形状集合。
1. 访问组形状。
1. 访问 [AlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/IShape#getAlternativeText--) 属性。

以下示例访问组形状的替代文本。

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