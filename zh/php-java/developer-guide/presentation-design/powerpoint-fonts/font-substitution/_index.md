---
title: 使用 PHP 在演示文稿中配置字体替代
linktitle: 字体替代
type: docs
weight: 70
url: /zh/php-java/font-substitution/
keywords:
- 字体
- 替代字体
- 字体替代
- 替换字体
- 字体替换
- 替代规则
- 替换规则
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "在将 PowerPoint 和 OpenDocument 演示文稿转换为其他文件格式时，通过 Java 为 Aspose.Slides for PHP 启用最佳字体替代。"
---

## **设置字体替代规则**

Aspose.Slides 允许您设置字体规则，以确定在特定条件下（例如无法访问某个字体）应采取的操作，方法如下：

1. 加载相关的演示文稿。
2. 加载需要被替换的字体。
3. 加载新的字体。
4. 为替换添加规则。
5. 将规则添加到演示文稿的字体替换规则集合中。
6. 生成幻灯片图像以观察效果。

以下 PHP 代码演示了字体替代过程：
```php
  # 加载演示文稿
  $pres = new Presentation("Fonts.pptx");
  try {
    # 加载将被替换的源字体
    $sourceFont = new FontData("SomeRareFont");
    # 加载新字体
    $destFont = new FontData("Arial");
    # 为字体替换添加规则
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # 将规则添加到字体替代规则集合中
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # 将字体规则集合添加到规则列表中
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # 当 SomeRareFont 不可访问时，将使用 Arial 字体代替
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # 将图像保存为 JPEG 格式到磁盘
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{%  alert title="注意"  color="warning"   %}} 
您可能想查看[**字体替换**](/slides/zh/php-java/font-replacement/)。
{{% /alert %}}

## **常见问题**

**字体替换和字体替代有什么区别？**

[Replacement](/slides/zh/php-java/font-replacement/) 是在整个演示文稿中强制用另一种字体覆盖原字体。替代是一条在特定条件下触发的规则，例如原始字体不可用时，会使用指定的回退字体。

**替代规则到底何时生效？**

这些规则参与标准的[font selection](/slides/zh/php-java/font-selection-sequence/) 流程，在加载、渲染和转换期间都会进行评估；如果选定的字体不可用，则会应用替换或替代。

**如果既未配置替换也未配置替代，而系统缺少该字体，默认行为是什么？**

库会尝试选取最接近的系统可用字体，行为类似于 PowerPoint。

**我可以在运行时附加自定义外部字体以避免替代吗？**

可以。您可以在运行时[add external fonts](/slides/zh/php-java/custom-font/)，库会将其纳入选择和渲染过程，包括后续的转换。

**Aspose 是否随库分发任何字体？**

不。Aspose 不分发付费或免费字体；您需自行添加并自行负责使用字体。

**在 Windows、Linux 和 macOS 上的替代行为是否有差异？**

有。字体发现从操作系统的字体目录开始。不同平台的默认可用字体集合和搜索路径不同，这会影响可用性以及是否需要替代。

**我应如何准备环境，以在批量转换时最小化意外的替代？**

在机器或容器之间同步字体集，[add the external fonts](/slides/zh/php-java/custom-font/) 以满足输出文档的需求，并在可能的情况下[embed fonts](/slides/zh/php-java/embedded-font/) 到演示文稿中，这样在渲染时所选字体即可用。