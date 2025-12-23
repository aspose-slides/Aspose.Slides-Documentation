---
title: 在 PHP 中将 PPTX 转换为 PPT
linktitle: PPTX 转 PPT
type: docs
weight: 21
url: /zh/php-java/convert-pptx-to-ppt/
keywords:
- 转换 PowerPoint
- 转换 演示文稿
- 转换 幻灯片
- 转换 PPTX
- PPTX 转 PPT
- 将 PPTX 保存为 PPT
- 导出 PPTX 为 PPT
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides 轻松将 PPTX 转换为 PPT — 确保与 PowerPoint 格式的无缝兼容，同时保留演示文稿的布局和质量。"
---

## **概述**

本文说明如何使用 PHP 将 PPTX 格式的 PowerPoint 演示文稿转换为 PPT 格式。以下主题涵盖内容。

- 将 PPTX 转换为 PPT

## **在 PHP 中将 PPTX 转换为 PPT**

有关将 PPTX 转换为 PPT 的 Java 示例代码，请参见下面的章节，即 [将 PPTX 转换为 PPT](#convert-pptx-to-ppt)。它只加载 PPTX 文件并保存为 PPT 格式。通过指定不同的保存格式，您还可以将 PPTX 文件保存为许多其他格式，如 PDF、XPS、ODP、HTML 等，如这些文章所述。

- [Java 将 PPTX 转换为 PDF](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-pdf/)
- [Java 将 PPTX 转换为 XPS](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-xps/)
- [Java 将 PPTX 转换为 HTML](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-html/)
- [Java 将 PPTX 转换为 ODP](https://docs.aspose.com/slides/php-java/save-presentation/)
- [Java 将 PPTX 转换为 Image](https://docs.aspose.com/slides/php-java/convert-powerpoint-to-png/)

## **将 PPTX 转换为 PPT**

要将 PPTX 转换为 PPT，只需将文件名和保存格式传递给 [**Presentation**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) 类的 **Save** 方法。下面的 PHP 代码示例使用默认选项将演示文稿从 PPTX 转换为 PPT。

```php
  # 实例化一个表示 PPTX 文件的 Presentation 对象
  $presentation = new Presentation("template.pptx");
  # 将演示文稿保存为 PPT
  $presentation->save("output.ppt", SaveFormat::Ppt);
```


## **常见问题**

**将 PPTX 的所有效果和功能在保存为旧版 PPT（97–2003）格式时都会保留吗？**

并非总是如此。PPT 格式缺少一些较新的功能（例如，某些效果、对象和行为），因此在转换过程中可能会对功能进行简化或栅格化处理。

**我能仅将选定的幻灯片转换为 PPT，而不是整个演示文稿吗？**

直接保存会针对整个演示文稿。要转换特定幻灯片，需创建仅包含这些幻灯片的新演示文稿并将其保存为 PPT；或者使用支持按幻灯片转换参数的服务/API。

**支持受密码保护的演示文稿吗？**

是的。您可以检测文件是否受保护，使用密码打开它，并且还可以为保存的 PPT [配置保护/加密设置](/slides/zh/php-java/password-protected-presentation/)。