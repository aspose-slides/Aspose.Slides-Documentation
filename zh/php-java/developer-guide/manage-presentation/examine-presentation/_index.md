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
description: "使用 Aspose.Slides for PHP 探索 PowerPoint 和 OpenDocument 演示文稿中的幻灯片、结构和元数据，以获得更快速的洞察和更智能的内容审计。"
---

Aspose.Slides for PHP via Java 允许您检查演示文稿的属性并了解其行为。

{{% alert title="Info" color="info" %}} 

The [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) and [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) classes contain the properties and methods used in operations here.

{{% /alert %}} 

## **检查演示文稿格式**

在处理演示文稿之前，您可能想了解当前演示文稿的格式（PPT、PPTX、ODP 等）。

您可以在不加载演示文稿的情况下检查其格式。请参阅以下 PHP 代码：
```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP
```


## **获取演示文稿属性**

此 PHP 代码演示了如何获取演示文稿属性（关于演示文稿的信息）：
```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```


您可能想查看 [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#DocumentProperties--) 类下的属性。

## **更新演示文稿属性**

Aspose.Slides 提供了 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 方法，可用于修改演示文稿属性。

假设我们有一个 PowerPoint 演示文稿，其文档属性如下所示。

![PowerPoint 演示文稿的原始文档属性](input_properties.png)

以下代码示例展示了如何编辑某些演示文稿属性：
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

![PowerPoint 演示文稿的已更改文档属性](output_properties.png)

## **有用链接**

要获取有关演示文稿及其安全属性的更多信息，您可能会发现以下链接有帮助：

- [Checking whether a Presentation is Encrypted](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Checking whether a Presentation is Write Protected (read-only)](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Checking whether a Presentation is Password Protected Before Loading it](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirming the Password Used to Protect a Presentation](https://docs.aspose.com/slides/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **常见问题**

**如何检查字体是否已嵌入以及具体是哪几种？**

在演示文稿级别查找 [embedded-font 信息](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getembeddedfonts/)，然后将这些条目与实际在内容中使用的 [字体列表](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getfonts/) 进行比较，以确定哪些字体对渲染至关重要。

**如何快速判断文件中是否存在隐藏幻灯片以及数量？**

遍历 [slide collection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/)，检查每个幻灯片的 [visibility flag](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/)。

**我能检测是否使用了自定义幻灯片尺寸和方向，并且它们是否与默认值不同吗？**

可以。将当前的 [slide size](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslidesize/) 和方向与标准预设进行比较；这有助于预测打印和导出时的行为。

**有没有快速方法查看图表是否引用了外部数据源？**

可以。遍历所有 [charts](https://reference.aspose.com/slides/php-java/aspose.slides/chart/)，检查它们的 [data source](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/)，并记录数据是内部的还是基于链接的，包括任何失效的链接。

**我如何评估可能导致渲染或 PDF 导出变慢的“重量”幻灯片？**

对每张幻灯片统计对象数量，查找大尺寸图像、透明度、阴影、动画和多媒体；给出一个粗略的复杂度评分，以标记潜在的性能瓶颈。