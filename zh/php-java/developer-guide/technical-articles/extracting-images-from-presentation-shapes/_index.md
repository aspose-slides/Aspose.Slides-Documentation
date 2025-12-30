---
title: 从演示文稿形状中提取图像
linktitle: 形状中的图像
type: docs
weight: 100
url: /zh/php-java/extracting-images-from-presentation-shapes/
keywords:
- 提取图像
- 检索图像
- 幻灯片背景
- 形状背景
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "使用 Aspose.Slides for PHP via Java 从 PowerPoint 和 OpenDocument 演示文稿的形状中提取图像 — 快速、代码友好的解决方案。"
---

## **从形状中提取图像**

{{% alert color="primary" %}} 

图像经常被添加到形状中，也常用作幻灯片的背景。图像对象通过[IImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/iimagecollection/) 添加，它是[IPPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ippimage/)对象的集合。

本文说明如何提取演示文稿中添加的图像。 

{{% /alert %}} 

要从演示文稿中提取图像，必须先遍历每一张幻灯片并遍历每个形状以定位图像。找到或识别图像后，即可提取并将其保存为新文件。 
```php

```


## **常见问题**

**我能在不进行任何裁剪、效果或形状变换的情况下提取原始图像吗？**

是的。当您访问形状的图像时，会从演示文稿的[图像集合](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/)获取图像对象，这意味着获取的是未裁剪或未应用样式效果的原始像素。工作流遍历演示文稿的图像集合和[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)对象，这些对象存储原始数据。

**一次保存大量图像时是否有重复相同文件的风险？**

是的，如果不加区分地保存所有图像。演示文稿的[图像集合](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/)可能包含由不同形状或幻灯片引用的相同二进制数据。为避免重复，写入之前请比较哈希值、大小或提取数据的内容。

**如何确定哪些形状链接到演示稿集合中的特定图像？**

Aspose.Slides 不会存储从[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)到形状的反向链接。遍历时手动构建映射：每当找到对[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)的引用时，记录使用该图像的形状。

**我能提取嵌入在 OLE 对象（如附件文档）中的图像吗？**

不能直接提取，因为 OLE 对象是一个容器。需要先提取 OLE 包本身，然后使用其他工具分析其内容。演示文稿的图片形状通过[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)工作；OLE 是一种不同的对象类型。