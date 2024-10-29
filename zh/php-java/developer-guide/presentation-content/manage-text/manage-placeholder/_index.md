---
title: 管理占位符
type: docs
weight: 10
url: /zh/php-java/manage-placeholder/
description: 使用PHP更改PowerPoint幻灯片中占位符的文本。使用PHP在PowerPoint幻灯片中设置占位符的提示文本。
---

## **更改占位符中的文本**
使用 [Aspose.Slides for PHP via Java](/slides/zh/php-java/)，您可以查找并修改演示文稿中幻灯片上的占位符。Aspose.Slides允许您更改占位符中的文本。

**前提条件**：您需要一个包含占位符的演示文稿。您可以在标准的Microsoft PowerPoint应用程序中创建这样的演示文稿。

以下是使用Aspose.Slides替换该演示文稿中占位符文本的方法：

1. 实例化 [`Presentation`](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类，并将演示文稿作为参数传递。
2. 通过索引获取幻灯片引用。
3. 遍历形状以查找占位符。
4. 将占位符形状强制转换为[`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape)，并使用与[`AutoShape`](https://reference.aspose.com/slides/php-java/aspose.slides/AutoShape)关联的[`TextFrame`](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrame)更改文本。
5. 保存修改后的演示文稿。

以下PHP代码演示如何更改占位符中的文本：

```php
  # 实例化一个Presentation类
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # 访问第一张幻灯片
    $sld = $pres->getSlides()->get_Item(0);
    # 遍历形状以查找占位符
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # 更改每个占位符中的文本
        $shp->getTextFrame()->setText("这是占位符");
      }
    }
    # 将演示文稿保存到磁盘
    $pres->save("output_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **在占位符中设置提示文本**
标准和预构建的布局包含占位符提示文本，例如 ***单击添加标题*** 或 ***单击添加副标题***。使用Aspose.Slides，您可以将自己喜欢的提示文本插入到占位符布局中。

以下PHP代码展示了如何在占位符中设置提示文本：

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # 遍历幻灯片
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint显示"单击添加标题"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "添加标题";
        } else // 添加副标题
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "添加副标题";
        }
        $shape->getTextFrame()->setText($text);
        echo("带文本的占位符: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **设置占位符图像透明度**

Aspose.Slides允许您设置文本占位符中背景图像的透明度。通过调整该框中的图像透明度，您可以使文本或图像突出显示（根据文本和图片的颜色）。

以下PHP代码展示了如何为图像背景（在形状内部）设置透明度：

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("当前透明度值: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```