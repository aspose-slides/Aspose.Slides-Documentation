---
title: 为 PHP 中的演示文稿指定回退字体
linktitle: 回退字体
type: docs
weight: 10
url: /zh/php-java/create-fallback-font/
keywords:
- 回退字体
- 回退规则
- 应用字体
- 替换字体
- Unicode 范围
- 缺失字形
- 正确字形
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "通过 Java 掌握适用于 PHP 的 Aspose.Slides，在 PPT、PPTX 和 ODP 文件中设置回退字体，确保在任何设备或操作系统上保持文本显示一致。"
---

## **回退规则**

Aspose.Slides 支持 [IFontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/IFontFallBackRule) 接口和 [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) 类，以指定回退字体的规则。[FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) 类表示在指定的 Unicode 范围（用于搜索缺失的字形）与可能包含正确字形的字体列表之间的关联：
```php
  $startUnicodeIndex = 0xb80;
  $endUnicodeIndex = 0xbff;
  $firstRule = new FontFallBackRule($startUnicodeIndex, $endUnicodeIndex, "Vijaya");
  $secondRule = new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic");
  # 使用多种方式可以添加字体列表:
  $fontNames = array("Segoe UI Emoji, Seggue UI Symbol", "Arial" );
  $thirdRule = new FontFallBackRule(0x1f300, 0x1f64f, $fontNames);
```


也可以 [remove](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) 回退字体或 [addFallBackFonts](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) 到已有的 [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) 对象中。

[FontFallBackRulesCollection](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRulesCollection) 可用于组织一系列 [FontFallBackRule](https://reference.aspose.com/slides/php-java/aspose.slides/FontFallBackRule) 对象，以便为多个 Unicode 范围指定回退字体替换规则。

{{% alert color="primary" title="另请参阅" %}} 
- [创建回退字体集合](/slides/zh/php-java/create-fallback-fonts-collection/)
{{% /alert %}}

## **常见问题**

**回退字体、字体替代和字体嵌入之间有什么区别？**

回退字体仅在主字体缺少字符时使用。[字体替代](/slides/zh/php-java/font-substitution/) 会用另一种字体完全替换指定的字体。[字体嵌入](/slides/zh/php-java/embedded-font/) 将字体打包到输出文件中，以便接收者能够按预期查看文本。

**回退字体是在导出为 PDF、PNG、SVG 等时生效，还是仅在屏幕渲染时生效？**

是的。回退会影响所有需要绘制字符但源字体中不存在字符的 [渲染和导出操作](/slides/zh/php-java/convert-presentation/)。

**配置回退会更改演示文稿文件本身吗？该设置在以后打开时会保留吗？**

不会。回退规则是代码中的运行时渲染设置；它们不会存储在 .pptx 文件中，也不会出现在 PowerPoint 中。

**操作系统（Windows/Linux/macOS）及字体目录集合会影响回退选择吗？**

会。引擎会从可用的系统文件夹以及您提供的任何 [附加路径](/slides/zh/php-java/custom-font/) 中解析字体。如果字体实际上不存在，则引用该字体的规则无法生效。

**回退对 WordArt、SmartArt 和图表有效吗？**

有效。当这些对象包含文本时，同样的字形替代机制会用于渲染缺失的字符。