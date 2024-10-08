---
title: 替换演示文稿图像集合中的图像
type: docs
weight: 80
url: /php-java/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java 使得在幻灯片形状中替换图像成为可能。本文解释了如何使用不同的方法替换添加到演示文稿图像集合中的图像。

{{% /alert %}} 
## **替换演示文稿图像集合中的图像**
Aspose.Slides for PHP via Java 提供了简单的 API 方法，用于替换演示文稿图像集合中的图像。请按照以下步骤操作：

1. 使用 Presentation 类加载包含图像的演示文稿文件。
1. 从文件加载图像到字节数组中。
1. 用新的字节数组中的图像替换目标图像。
1. 第二种方法是加载 Image 对象中的图像，并用加载的图像替换目标图像。
1. 第三种方法是用已经添加的图像替换演示文稿图像集合中的图像。
1. 将修改后的演示文稿写入一个 PPTX 文件。



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Images-ReplaceImage-ReplaceImage.java" >}}