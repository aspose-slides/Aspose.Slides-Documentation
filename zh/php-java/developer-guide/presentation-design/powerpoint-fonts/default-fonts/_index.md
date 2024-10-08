---
title: 默认字体 - PowerPoint Java API
linktitle: 默认字体
type: docs
weight: 30
url: /php-java/default-font/
description: PowerPoint Java API 让您设置用于将演示文稿呈现为 PDF、XPS 或缩略图的默认字体。本文展示了如何定义 DefaultRegular Font 和 DefaultAsian Font 作为默认字体。
---

## **使用默认字体渲染演示文稿**
Aspose.Slides 让您设置用于将演示文稿呈现为 PDF、XPS 或缩略图的默认字体。本文展示了如何定义 DefaultRegular Font 和 DefaultAsian Font 作为默认字体。请按照以下步骤使用 Aspose.Slides for PHP 通过 Java API 从外部目录加载字体：

1. 创建 [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions) 的实例。
1. [设置 DefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) 为您希望的字体。在以下示例中，我使用了 Wingdings。
1. [设置 DefaultAsianFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) 为您希望的字体。在下面的示例中我使用了 Wingdings。
1. 使用 Presentation 和设置加载选项加载演示文稿。
1. 现在，生成幻灯片缩略图、PDF 和 XPS 来验证结果。

上述实现如下所示。

```php
  # 使用加载选项定义默认的常规和亚洲字体
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # 加载演示文稿
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # 生成幻灯片缩略图
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # 将图像保存到磁盘。
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # 生成 PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # 生成 XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```