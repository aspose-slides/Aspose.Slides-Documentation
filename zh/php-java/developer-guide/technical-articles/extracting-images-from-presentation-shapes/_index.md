---
title: 从演示文稿形状中提取图像
linktitle: 来自形状的图像
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

图像通常会添加到形状中，也常被用作幻灯片的背景。图像对象是通过[ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) 添加的，该集合包含[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 对象。

本文说明了如何提取已添加到演示文稿中的图像。 

{{% /alert %}} 

要从演示文稿中提取图像，必须先遍历每张幻灯片，再遍历每个形状以定位图像。找到或识别出图像后，即可提取并将其保存为新文件。 
```php

```


## **FAQ**

**我可以提取未经过裁剪、特效或形状转换的原始图像吗？**

可以。当您访问形状的图像时，获取的是演示文稿的[image collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) 中的图像对象，也就是未裁剪或未应用样式特效的原始像素。工作流会遍历演示文稿的图像集合以及[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 对象，这些对象存储原始数据。

**一次保存大量图像时会有重复相同文件的风险吗？**

会，如果不加区分地全部保存。演示文稿的[image collection](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getimages/) 可能包含相同的二进制数据，这些数据可能被不同的形状或幻灯片引用。为避免重复，写入前应比较哈希值、文件大小或提取数据的内容。

**如何确定演示文稿集合中哪些形状关联了特定图像？**

Aspose.Slides 不会从[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 反向链接到形状。您需要在遍历时手动建立映射：每当发现对某个[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 的引用时，记录使用该图像的形状。

**我可以提取嵌入在 OLE 对象（如附加文档）中的图像吗？**

不能直接提取，因为 OLE 对象是一个容器。您需要先提取 OLE 包本身，然后使用其他工具分析其内容。演示文稿的图片形状通过[PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) 工作，而 OLE 是另一种对象类型。