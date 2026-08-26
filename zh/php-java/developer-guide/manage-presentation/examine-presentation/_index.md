---
title: 检索和更新 PHP 中的演示文稿信息
linktitle: 演示文稿信息
type: docs
weight: 30
url: /zh/php-java/examine-presentation/
keywords:
- 演示文稿格式
- 演示文稿属性
- 文档属性
- 获取属性
- 读取属性
- 更改属性
- 修改属性
- 更新属性
- 检查 PPTX
- 检查 PPT
- 检查 ODP
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP 在 PowerPoint 和 OpenDocument 演示文稿中探索幻灯片、结构和元数据，以获得更快的洞察和更智能的内容审计。"
---
## **概述**

本文展示了如何在 Aspose.Slides 中检查演示文稿信息。它解释了如何在不加载完整文件的情况下确定演示文稿的当前格式、读取其文档属性以及在需要时更新这些属性。

示例基于 [PresentationInfo](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentationinfo/) 和 [DocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/) API，并演示了处理演示文稿元数据的典型操作。

## **检查演示文稿格式**

在处理演示文稿之前，您可能想了解当前演示文稿的格式（PPT、PPTX、ODP 等）。

您可以在不加载演示文稿的情况下检查其格式。请参见以下 PHP 代码：

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **获取演示文稿属性**

以下 PHP 代码演示如何获取演示文稿属性（有关演示文稿的信息）：

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

您可能想查看 [DocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/documentproperties/#DocumentProperties--) 类下的属性。

## **更新演示文稿属性**

Aspose.Slides 提供了 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/zh/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 方法，允许您对演示文稿属性进行更改。

假设我们有一个 PowerPoint 演示文稿，其文档属性如下所示。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

以下代码示例展示如何编辑部分演示文稿属性：

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

更改文档属性后的结果如下所示。

![PowerPoint 演示文稿的更改后文档属性](output_properties.png)

## **有用链接**

要获取有关演示文稿及其安全属性的更多信息，您可能会发现以下链接有用：

- [对演示文稿进行密码保护](/slides/zh/php-java/password-protected-presentation/)
- [对演示文稿进行写入保护](/slides/zh/php-java/write-protected-presentation/)

## **常见问题**

**如何检查是否嵌入了字体以及具体哪些字体？**

在演示文稿级别查找 [embedded-font information](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/getembeddedfonts/)，然后将这些条目与 [fonts actually used across content](https://reference.aspose.com/slides/zh/php-java/aspose.slides/fontsmanager/getfonts/) 的集合进行比较，以识别对渲染至关重要的字体。

**如何快速判断文件中是否有隐藏的幻灯片以及数量？**

遍历 [slide collection](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slidecollection/)，检查每个幻灯片的 [visibility flag](https://reference.aspose.com/slides/zh/php-java/aspose.slides/slide/gethidden/)。

**我能检测是否使用了自定义幻灯片尺寸和方向，以及它们是否与默认值不同吗？**

可以。将当前的 [slide size](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/getslidesize/) 和方向与标准预设进行比较；这有助于预判打印和导出时的行为。

**有没有快速方法查看图表是否引用外部数据源？**

可以。遍历所有 [charts](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chart/)，检查其 [data source](https://reference.aspose.com/slides/zh/php-java/aspose.slides/chartdata/getdatasourcetype/)，并记录数据是内部的还是基于链接的，包括任何失效的链接。

**如何评估可能导致渲染或 PDF 导出变慢的“重量”幻灯片？**

对于每张幻灯片，统计对象数量并查找大尺寸图像、透明度、阴影、动画以及多媒体等因素；给出一个粗略的复杂度评分，以标记潜在的性能热点。