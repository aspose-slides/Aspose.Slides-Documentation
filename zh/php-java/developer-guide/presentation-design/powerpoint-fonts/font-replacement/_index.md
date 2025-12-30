---
title: 使用 PHP 简化演示文稿中的字体替换
linktitle: 字体替换
type: docs
weight: 60
url: /zh/php-java/font-replacement/
keywords:
- 字体
- 替换字体
- 字体替换
- 更改字体
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "通过 Java 在 Aspose.Slides for PHP 中无缝替换字体，确保 PowerPoint 和 OpenDocument 演示文稿的排版一致。"
---

## **替换字体**

如果您改变了使用字体的想法，可以用另一种字体替换该字体。旧字体的所有实例都将被新字体取代。

Aspose.Slides 允许您以以下方式替换字体：

1. 加载相关演示文稿。 
2. 加载将被替换的字体。 
3. 加载新字体。 
4. 替换字体。 
5. 将修改后的演示文稿写入 PPTX 文件。

此 PHP 代码演示了字体替换：
```php
  # 加载演示文稿
  $pres = new Presentation("Fonts.pptx");
  try {
    # 加载将被替换的源字体
    $sourceFont = new FontData("Arial");
    # 加载新字体
    $destFont = new FontData("Times New Roman");
    # 替换字体
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # 保存演示文稿
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Note" color="warning" %}} 
要设置在特定条件下（例如无法访问字体）会发生什么的规则，请参阅[**字体替代**](/slides/zh/php-java/font-substitution/)。
{{% /alert %}}

## **常见问题**

**“字体替换”、 “字体替代” 和 “后备字体” 有何区别？**

替换是有意地在整个文档中将一个字体族切换为另一个。 [**字体替代**](/slides/zh/php-java/font-substitution/) 是一种规则，例如“如果字体不可用，使用 X”。 [**后备字体**](/slides/zh/php-java/fallback-font/) 则在单个缺失字形时进行局部应用，当基础字体已安装但不包含所需字符时使用。

**替换是否适用于母版幻灯片、布局、备注和批注？**

是的。替换会影响所有使用原始字体的演示文稿对象，包括母版幻灯片和备注；批注也是文档的一部分，字体引擎会考虑它们。

**嵌入的 OLE 对象（例如 Excel）内部的字体会变化吗？**

不会。[**OLE 内容**](/slides/zh/php-java/manage-ole/) 由其自身的应用程序控制。演示文稿中的替换不会重新格式化内部 OLE 数据；它可能会显示为图像或作为可外部编辑的内容。

**我能只在演示文稿的某部分（按幻灯片或区域）替换字体吗？**

如果在所需对象/范围层面更改字体，而不是对整个文档进行全局替换，则可以实现针对性替换。渲染期间的整体字体选择逻辑保持不变。

**如何提前确定演示文稿使用了哪些字体？**

使用演示文稿的[**字体管理器**](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/)：它提供[**正在使用的字体族**](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getfonts/)列表以及关于[**替代/“未知”字体**](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/)的信息，帮助规划替换工作。

**字体替换在转换为 PDF/图像时是否有效？**

有效。在导出期间，Aspose.Slides 应用相同的[**字体选择/替代顺序**](/slides/zh/php-java/font-selection-sequence/)，因此预先进行的替换将在转换时得到尊重。

**我需要在系统中安装目标字体，还是可以附加一个字体文件夹？**

无需安装：库允许从用户文件夹[**加载外部字体**](/slides/zh/php-java/custom-font/)，以便在[**渲染和导出**](/slides/zh/php-java/convert-powerpoint/)期间使用。

**替换能解决字符显示为“豆腐块”（方框）的问题吗？**

仅当目标字体实际包含所需字形时才会解决。如果不包含，请[**配置后备字体**](/slides/zh/php-java/fallback-font/)以覆盖缺失字符。