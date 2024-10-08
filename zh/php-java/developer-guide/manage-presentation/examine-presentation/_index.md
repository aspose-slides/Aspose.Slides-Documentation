---
title: 检查演示文稿
type: docs
weight: 30
url: /php-java/examine-presentation/
keywords:
- PowerPoint
- 演示文稿
- 演示文稿格式
- 演示文稿属性
- 文档属性
- 获取属性
- 读取属性
- 更改属性
- 修改属性
- PPTX
- PPT
- PHP
- Java
description: "通过Java在PHP中读取和修改PowerPoint演示文稿属性"
---

Aspose.Slides for PHP via Java允许您检查演示文稿，以了解其属性并理解其行为。

{{% alert title="信息" color="info" %}} 

[PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) 和 [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) 类包含此处操作中使用的属性和方法。

{{% /alert %}} 

## **检查演示文稿格式**

在处理演示文稿之前，您可能想要了解当前演示文稿的格式（PPT、PPTX、ODP 等）。

您可以在不加载演示文稿的情况下检查演示文稿的格式。请参阅以下PHP代码：

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **获取演示文稿属性**

以下PHP代码向您展示如何获取演示文稿属性（有关演示文稿的信息）：

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

您可能希望查看 [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#DocumentProperties--) 类下的属性。

## **更新演示文稿属性**

Aspose.Slides提供了 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 方法，允许您更改演示文稿属性。

假设我们有一个PowerPoint演示文稿，其文档属性如下所示。

![原始PowerPoint演示文稿的文档属性](input_properties.png)

此代码示例向您展示如何编辑一些演示文稿属性：

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("我的标题");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

更改文档属性的结果如下所示。

![更改后的PowerPoint演示文稿的文档属性](output_properties.png)

## **有用链接**

要获取有关演示文稿及其安全属性的更多信息，您可能会发现以下链接很有用：

- [检查演示文稿是否加密](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [检查演示文稿是否只读保护](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [检查在加载演示文稿之前是否受密码保护](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [确认用于保护演示文稿的密码](https://docs.aspose.com/slides/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).