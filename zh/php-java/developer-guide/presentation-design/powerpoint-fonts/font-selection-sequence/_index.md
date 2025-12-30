---
title: Aspose.Slides for PHP 中的字体选择序列
linktitle: 字体选择
type: docs
weight: 80
url: /zh/php-java/font-selection-sequence/
keywords:
- 字体选择
- 字体替代
- 字体替换
- 替代规则
- 可用字体
- 缺失字体
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "了解 Aspose.Slides for PHP（通过 Java）如何选择字体，确保 PPT、PPTX 和 ODP 文件呈现清晰一致 — 立即提升您的幻灯片。"
---

## **字体选择**

在加载、渲染或转换为其他格式时，演示文稿中的字体需遵循特定规则。例如，当您尝试将演示文稿（其幻灯片）转换为图像时，会检查演示文稿的字体以确认所选字体是否在操作系统中可用。如果确认字体缺失，则会进行替换——参见[**字体替换**](https://docs.aspose.com/slides/php-java/font-replacement/)和[**字体替代**](https://docs.aspose.com/slides/php-java/font-substitution/)。

以下是 Aspose.Slides 处理字体的过程：

1. Aspose.Slides 在操作系统中搜索字体，以查找与演示文稿所选字体匹配的字体。  
2. 如果找到了所选字体，Aspose.Slides 将使用它。否则，Aspose.Slides 将使用一种尽可能接近 PowerPoint 所使用的替代字体。  
3. 如果通过[FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) 设置了字体替换规则，则会应用这些规则。

Aspose.Slides 允许您向 Aspose 运行时添加字体，然后使用这些字体。参见[**自定义字体**](https://docs.aspose.com/slides/php-java/custom-font/)。

当在演示文稿中放置额外字体时，这些字体称为[**嵌入式字体**](https://docs.aspose.com/slides/php-java/embedded-font/)。

Aspose.Slides 允许您添加仅应用于 *输出文档* 的字体。例如，如果您希望将演示文稿转换为 PDF，但其中包含系统和嵌入式字体缺失的情况，您可以将所需字体添加或加载为 **外部字体**。

## **常见问题**

**在转换之前，我如何确定演示文稿实际使用了哪些字体？**

Aspose.Slides 通过[font manager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/)让您检查所使用的字体，从而可以决定是[嵌入](/slides/zh/php-java/embedded-font/)、[替换](/slides/zh/php-java/font-replacement/)还是添加[外部来源](/slides/zh/php-java/custom-font/)。这有助于防止在渲染和导出过程中出现不期望的替换。

**我能否在不将字体安装到操作系统的情况下添加额外的字体目录？**

可以。您可以注册[外部字体来源](/slides/zh/php-java/custom-font/)（例如文件夹或内存流）用于渲染和导出。这样可消除对主机系统字体的依赖，并保持布局的可预测性。

**当缺少字形时，我如何防止静默回退到不合适的字体？**

预先定义显式的[字体替换](/slides/zh/php-java/font-replacement/)和字体[回退规则](/slides/zh/php-java/fallback-font/)。通过分析使用的字体并为替代字体设定受控的优先级，您可以确保排版一致性，避免意外结果。